//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/09/08  �C�����e : #14404�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�10704766-00             �쐬�S�� : �����
// �C �� ��  2011/08/03  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��984�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�10704766-00              �쐬�S�� : caohh
// �C �� ��  2011/08/04  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��513�A520�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�10704766-00              �쐬�S�� : wangf
// �C �� ��  2011/08/29  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��1016�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/28  �C�����e : Redmine#8179 �f�t�H���g�I��l�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10806793-00  �쐬�S�� : �c����
// �C �� ��  2012/12/13  �C�����e : 2013/03/13�z�M��  Redmine#33835
//                                  �o�׉񐔂�ǉ�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : huangt
// �C �� ��  2014/01/15  �C�����e : Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11770032-00  �쐬�S�� : 杍^
// �C �� �� K2021/05/17  �C�����e : BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή�
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
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid; // ADD 2012/12/13 �c���� Redmine#33835
using Infragistics.Win; // ADD 2012/12/13 �c���� Redmine#33835

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ƀ}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2010/09/08 ������ #14404�̑Ή��B</br>
    /// <br>Update Note: 2011/08/03 ����� NS���[�U�[���Ǘv�]�ꗗ�A��984�̑Ή��B</br>
    /// <br>Update Note: 2011/08/04 caohh NS���[�U�[���Ǘv�]�ꗗ�A��513�A520�̑Ή��B</br>
    /// <br>Update Note: 2011/08/29 wangf NS���[�U�[���Ǘv�]�ꗗ�A��1016�̑Ή��B</br>
    /// <br>Update Note: 2011/11/28 ������ Redmine#8179 �f�t�H���g�I��l�̕ύX�B</br>
    /// <br>Update Note: 2012/12/13 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#33835 �o�׉񐔂�ǉ�����Ή�</br>
    /// <br>Update Note: K2021/05/17 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>           : BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή�</br>
    /// </remarks>
    public partial class PMKHN09491UA : Form
    {
        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        #region �� Private Const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        private const string TOOLBAR_NEWBUTTON_KEY = "ButtonTool_New";							// �V�K
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";							// �ۑ�
        private const string TOOLBAR_DELETEBUTTON_KEY = "ButtonTool_Delete";						// �폜
        private const string TOOLBAR_COMPLETEDELETEBUTTON_KEY = "ButtonTool_CompleteDelete";		 // ���S�폜
        private const string TOOLBAR_REVIVEBUTTON_KEY = "ButtonTool_Revive";						// ����
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_Renewal";						// �ŐV���
        private const string ct_Tool_LoginEmployee = "LabelTool_LoginTitle";				// ���O�C���S���҃^�C�g��
        private const string ct_Tool_LoginEmployeeName = "LabelTool_LoginName";		     // ���O�C���S���Җ���
        // --- ADD 2010/09/08 ----->>>>>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";		         // �K�C�h
        // --- ADD 2010/09/08 -----<<<<<

        // ���[�U�[�K�C�h�敪�l�i���i�Ǘ��敪�P�j
        private const int ct_UserGdDiv_PartsManagementDivide1 = 72;
        // ���[�U�[�K�C�h�敪�l�i���i�Ǘ��敪�Q�j
        private const int ct_UserGdDiv_PartsManagementDivide2 = 73;

        private const string CT_PGID = "PMKHN09490U";
        private const string CT_PGNM = "�݌Ƀ}�X�^";

        private const string NEW_INPUT_TITLE = "�V�K";
        private const string UPDATE_INPUT_TITLE = "�X�V";
        private const string DELETE_INPUT_TITLE = "�폜";

        //----- ADD 2012/12/13 �c���� Redmine#33835 ----------->>>>>
        // �O���b�h��
        private const string COLUMN_TITLE = "Title1";   �@ //�q��^�C�g��
        private const string COLUMN_SALESTIMES = "SalesTimes";  //�o�׉�

        private DateTime _thisYearMonth;
        private TotalDayCalculator _totalDayCalculator = null; //�����擾���i
        private DateTime _stMonth;
        private DateTime _edMonth;
        private int _stAddUpDate;
        private int _edAddUpDate;
        //----- ADD 2012/12/13 �c���� Redmine#33835 -----------<<<<<


        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
        //���͕s�̔w�i�F
        private readonly Color BACKCOLOR_DISABLE = Color.FromArgb(224, 224, 224);
        //���͉̔w�i�F
        private readonly Color BACKCOLOR_ENABLE = Color.FromArgb(255, 255, 255);
        // �O��ݏo��
        private double _preShipmentCnt = 0;
        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<
        #endregion �� Private Const

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// �݌Ƀ}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public PMKHN09491UA()
        {
            InitializeComponent();

            try
            {
                this._stockMstAcs = StockMstAcs.GetInstance();
                this._dateGet = DateGetAcs.GetInstance();
                //-----------------------------------------------------------------------------
                // �e��I�u�W�F�N�g�C���X�^���X����
                //-----------------------------------------------------------------------------
                this._goodsAcs = new GoodsAcs();
                this._goodsAcs.IsLocalDBRead = false;

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }
            }
            catch
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        //======================================================================================= //
        //  ���������o�[
        //======================================================================================= //
        #region ��Private Members
        private string _enterpriseCode;
        private ImageList _imageList16;
        private string _preGoodsNo = string.Empty;
        private Int32 _preMakerCode = 0;
        private string _preWarehouseCode = string.Empty;
        private double _priceValue = 0;
        private double _shipmentPosCountOrigin;
        private DateTime updateTimeDt = new DateTime();

        // -------------------------------------------------------------------------------
        #region < �e��I�u�W�F�N�g >
        /// <summary>���i���̓A�N�Z�X�N���X</summary>
        GoodsAcs _goodsAcs;
        /// <summary>�ύX�O�݌Ƀ��X�g�o�b�t�@</summary>
        private List<Stock> _prevStockList;
        /// <summary>���[�U�[�K�C�h�}�X�^ �A�N�Z�X�N���X</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>�����_�R�[�h</summary>
        private string _loginSectionCode = "";
        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>�d����A�N�Z�X�N���X</summary>
        private SupplierAcs _supplierAcs;
        /// <summary>�q�ɃA�N�Z�X�N���X</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>���[�J�[�}�X�^�@�A�N�Z�X�N���X</summary>
        private MakerAcs _makerAcs;
        /// <summary>�݌Ƀ}�X�^�@�A�N�Z�X�N���X</summary>
        private StockMstAcs _stockMstAcs;
        /// <summary>���t�擾���i�@�A�N�Z�X�N���X</summary>
        private DateGetAcs _dateGet;
        private GoodsUnitData _goodsUnitData; // ADD 2010/09/01
        private Stock _stockBak; // ADD 2010/09/06
        // -- add wangf 2011/08/29 ---------->>>>>
        /// <summary>�݌ɊǗ��S�̐ݒ�ݒ�A�N�Z�X�N���X</summary>
        private StockMngTtlStAcs _stockMngTtlStAcs;
        // -- add wangf 2011/08/29 ----------<<<<<

        #endregion

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2012/12/13 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33835 �o�׉񐔂�ǉ�����Ή�</br>
        /// </remarks>
        private void PMKHN09491UA_Load(object sender, EventArgs e)
        {
            // ��ʂ��\�z
            this.ScreenInitialSetting();

            //-----------------------------------------------------------------------------
            // �V�K
            //-----------------------------------------------------------------------------
            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

            this.ChangeEditMode(3);

            this.tComboEditor_StockDiv.SelectedIndex = 0;
            this.tNedit_PartsManagementDivide1.SetInt(0);
            this.tNedit_PartsManagementDivide2.SetInt(0);
            this.tNedit_MinimumStockCnt.SetInt(0);
            this.tNedit_MaximumStockCnt.SetInt(0);
            this.tNedit_SalesOrderCount.SetInt(0);
            this.tNedit_SupplierStock.SetInt(0);
            this.tNedit_ArrivalCnt.SetInt(0);
            this.tNedit_ShipmentCnt.SetInt(0);
            this.tNedit_AcpOdrCount.SetInt(0);
            this.tNedit_MovingSupliStock.SetInt(0);
            this.tNedit_ShipmentPosCnt.SetInt(0);

            this.Initial_timer.Enabled = true;
            // --- ADD 2010/09/01 --- >>>>>
            // �Ǘ��敪1�A2�̖��̂������ݒ�
            bool readStatus;
            int code;
            string name;

            // �Ǘ��敪1�̖��̓ǂݍ���
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt(), out code, out name);

            // ���̂��X�V
            if (readStatus)
            {
                tEdit_PartsManagementDivide1Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide1Name.Text = string.Empty;
            }

            // �Ǘ��敪2�̖��̓ǂݍ���
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt(), out code, out name);

            // ���̂��X�V
            if (readStatus)
            {
                tEdit_PartsManagementDivide2Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide2Name.Text = string.Empty;
            }
            // --- ADD 2010/09/01 --- <<<<<

            //----- ADD 2012/12/13 �c���� Redmine#33835 -------->>>>>
            // �����擾���i
            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthly();

            // ���ݏ����N���擾����
            GetThisYearMonth();

            CreateGrid();

            SetGridLayout();
            //----- ADD 2012/12/13 �c���� Redmine#33835 --------<<<<<
        }

        /// <summary>
        ///	��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����ݒ���������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {

            // �C���[�W���X�g�ݒ�
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // �c�[���A�C�R���ݒ�
            //----------------------------
            // �I��
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �V�K
            this.tToolsManager_MainMenu.Tools[TOOLBAR_NEWBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // �ۑ�
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // �폜
            this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // ���S�폜
            this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // ����
            this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;
            // �ŐV���
            this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ���O�C���S����
            this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // --- ADD 2010/09/08 ----->>>>>
            // �K�C�h
            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // --- ADD 2010/09/08 -----<<<<<

            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployeeName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // �A�C�R���ݒ�
            this._imageList16 = IconResourceManagement.ImageList16;

            this.GoodsMakerGuide_uButton.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SectionGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_PartsManagementDivide1.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_PartsManagementDivide2.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �t�H�J�X�ύX���ɃC�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�J�X�ύX���ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// <br>Update Note: 2010/09/01 �k���r #14025��4�̑Ή��B</br>
        /// <br>Update Note: 2010/09/08 ������ #14404�̑Ή��B</br>
        /// <br>Update Note: 2011/08/03 ����� NS���[�U�[���Ǘv�]�ꗗ�A��984�̑Ή��B</br>
        /// <br>Update Note: 2012/12/13 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33835 �o�׉񐔂�ǉ�����Ή�</br>
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            int status = 0;
            bool changedGoods = false;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            //----- ADD 2012/12/13 �c���� Redmine#33835 ---------->>>>>
            if (e.NextCtrl.Name == "uGrid_SalesTimes")
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            //----- ADD 2012/12/13 �c���� Redmine#33835 ----------<<<<<

            #region �t�H�[�J�X�ړ�
            if (!e.ShiftKey)
            {
                if (e.Key == Keys.Right)
                {
                    if (e.PrevCtrl == this.tEdit_GoodsNo
                        || e.PrevCtrl == this.GoodsMakerGuide_uButton
                        || e.PrevCtrl == this.tNedit_StockUnitPriceFl
                        //|| e.PrevCtrl == this.tNedit_SalesOrderUnit // DEL 2012/12/13 �c���� Redmine#33835
                        //----- ADD 2012/12/13 �c���� Redmine#33835 ---------->>>>>
                        || e.PrevCtrl == this.tNedit_StockUnitPriceRate // �I���]����
                        || e.PrevCtrl == this.tNedit_StockUnitPriceFl // �I���]���P��
                        || e.PrevCtrl == this.tNedit_SupplierStock // �d���݌ɐ�
                        //----- ADD 2012/12/13 �c���� Redmine#33835 ----------<<<<<
                        || e.PrevCtrl == this.tNedit_SalesOrderCount
                        || e.PrevCtrl == this.uButton_SupplierGuide
                        || e.PrevCtrl == this.tDateEdit_lastSalesDate
                        || e.PrevCtrl == this.tDateEdit_lastStockDate
                        || e.PrevCtrl == this.uButton_PartsManagementDivide1
                        || e.PrevCtrl == this.uButton_PartsManagementDivide2
                        || e.PrevCtrl == this.tEdit_StockNote1
                        || e.PrevCtrl == this.tEdit_StockNote2)
                    {
                        e.NextCtrl = null;
                        return;
                    }
                }
            }
            
            #endregion

            #region ���ڏ���
            switch (e.PrevCtrl.Name)
            {
                // �q�Ƀ{�^��
                case "uButton_WarehouseGuide":
                    {
                        #region �q�Ƀ{�^��
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                    break;
                            }
                        }
                        #endregion
                        break;
                    }
                

                // �I���]����
                case "tNedit_StockUnitPriceRate":
                    {
                        #region �I���]����
                        if (this.tNedit_StockUnitPriceRate.GetValue() == 0)
                        {
                            return;
                        }

                        // �I���]����
                        double priceRate = this.tNedit_StockUnitPriceRate.GetValue();

                        this.tNedit_StockUnitPriceFl.SetValue(priceRate * this._priceValue / 100);

                        #endregion
                        break;
                    }

                // �Ǘ����_�R�[�h
                case "tEdit_SectionCode":
                    {
                        # region [���_]
                        bool readStatus = false;
                        if (!string.IsNullOrEmpty(tEdit_SectionCode.Text.Trim()))
                        {
                            string code;
                            string name;

                            this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);

                            // ���_�ǂݍ���
                            readStatus = ReadSection(tEdit_SectionCode.Text, out code, out name);

                            // �R�[�h�E���̂��X�V
                            tEdit_SectionCode.Text = code;
                            tEdit_SectionName.Text = name;
                        }
                        else
                        {
                            this.tEdit_SectionName.Text = string.Empty;

                            readStatus = true;
                        }

                        if (readStatus == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                if (this.tEdit_GoodsNo.Enabled == false)
                                                {
                                                    e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tEdit_GoodsNo;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            this.tEdit_SectionCode.Text = string.Empty;
                            e.NextCtrl = this.tEdit_SectionCode;

                        }
                        // --- ADD 2010/09/08 ----->>>>>
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl == this.tEdit_StockNote2)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        // --- ADD 2010/09/08 -----<<<<<
                        # endregion
                        break;
                    }

                // �ō��݌ɐ�
                case "tNedit_MaximumStockCnt":
                    {
                        # region [�ō��݌ɐ�]
                        if (tNedit_MinimumStockCnt.GetValue() > tNedit_MaximumStockCnt.GetValue())
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Œ�݌ɐ����ō��݌ɐ��ƂȂ�悤�ɓ��͂��ĉ������B",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                // �������b�g
                case "tNedit_SalesOrderUnit":
                    {
                        # region [�������b�g]
                        if (tNedit_SalesOrderUnit.GetValue() > tNedit_MaximumStockCnt.GetValue())
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�������b�g���ō��݌ɐ��ƂȂ�悤�ɓ��͂��ĉ������B",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                // ������R�[�h
                case "tNedit_SupplierCd":
                    {
                        # region [������i�d����j]
                        bool readStatus;
                        if (tNedit_SupplierCd.GetInt() == 0)
                        {
                            readStatus = true;
                            this.tEdit_SupplierName.Text = string.Empty;
                        }
                        else
                        {
                            int code;
                            string name;

                            // �d����ǂݍ���
                            readStatus = ReadSupplier(tNedit_SupplierCd.GetInt(), out code, out name);

                            // �R�[�h�E���̂��X�V
                            tNedit_SupplierCd.SetInt(code);
                            tEdit_SupplierName.Text = name;
                        }

                        if (readStatus == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {

                                            if (this.tNedit_SupplierCd.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.uButton_SupplierGuide;
                                            }
                                            else
                                            {
                                                //e.NextCtrl = this.tDateEdit_lastSalesDate;     // DEL huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
                                                // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
                                                if (this.tNedit_ShipmentCnt.Enabled)
                                                {
                                                    e.NextCtrl = this.tNedit_ShipmentCnt;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tDateEdit_lastSalesDate;
                                                }
                                                // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<
                                            }

                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�����悪���݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            this.tNedit_SupplierCd.Text = string.Empty;
                            e.NextCtrl = this.uButton_SupplierGuide;

                        }
                        # endregion
                        break;
                    }
                // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
                case "uButton_SupplierGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_ShipmentCnt.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_ShipmentCnt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_lastSalesDate;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_ShipmentCnt":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_lastSalesDate;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = this.uButton_SupplierGuide;
                        }
                        break;
                    }
                case "tDateEdit_lastSalesDate":
                    {
                        if (e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_ShipmentCnt.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_ShipmentCnt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_SupplierGuide;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tDateEdit_lastStockDate":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_PartsManagementDivide1;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<

                // �Ǘ��敪�P
                case "tNedit_PartsManagementDivide1":
                    {
                        # region [�Ǘ��敪�P]
                        bool readStatus;
                        // --- DEL 2010/09/01 --- >>>>>
                        //if (tNedit_PartsManagementDivide1.GetInt() != 0)
                        //{
                        // --- DEL 2010/09/01 --- <<<<<
                        int code;
                        string name;

                        // ���[�U�[�K�C�h�ǂݍ���
                        readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt(), out code, out name);

                        // �R�[�h�E���̂��X�V
                        // (���}�X�^���o�^�R�[�h�ł��n�j)
                        if (readStatus)
                        {
                            tEdit_PartsManagementDivide1Name.Text = name;
                            // --- ADD 2010/09/01 --- >>>>>
                            if ("".Equals(this.tNedit_PartsManagementDivide1.DataText))
                            {
                                this.tNedit_PartsManagementDivide1.SetInt(0);
                            }
                            // --- ADD 2010/09/01 --- <<<<<
                        }
                        else
                        {
                            // --- DEL 2010/09/01 --- >>>>>
                            //this.tNedit_PartsManagementDivide1.SetInt(0);
                            // --- DEL 2010/09/01 --- <<<<<
                            tEdit_PartsManagementDivide1Name.Text = string.Empty;
                        }
                        // --- DEL 2010/09/01 --- >>>>>
                        //}
                        //else
                        //{
                        //    this.tNedit_PartsManagementDivide1.SetInt(0);
                        //    this.tEdit_PartsManagementDivide1Name.Text = string.Empty;
                        //}
                        // --- DEL 2010/09/01 --- <<<<<

                        // (���}�X�^���o�^�R�[�h�ł��n�j)
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (tEdit_PartsManagementDivide1Name.Text == string.Empty)
                                        {
                                            e.NextCtrl = this.uButton_PartsManagementDivide1;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_PartsManagementDivide2;
                                        }
                                        break;
                                    }
                            }
                        }
                        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
                        else
                        {
                            e.NextCtrl = tDateEdit_lastStockDate;
                        }
                        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<

                        # endregion
                        break;
                    }
                // �Ǘ��敪�Q
                case "tNedit_PartsManagementDivide2":
                    {
                        # region [�Ǘ��敪�Q]
                        bool readStatus;
                        // --- DEL 2010/09/01 --- >>>>>
                        //if (this.tNedit_PartsManagementDivide2.GetInt() != 0)
                        //{
                        // --- DEL 2010/09/01 --- <<<<<
                        int code;
                        string name;

                        // ���[�U�[�K�C�h�ǂݍ���
                        readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt(), out code, out name);

                        // �R�[�h�E���̂��X�V
                        // (���}�X�^���o�^�R�[�h�ł��n�j)
                        if (readStatus)
                        {
                            tEdit_PartsManagementDivide2Name.Text = name;
                            // --- ADD 2010/09/01 --- >>>>>
                            if ("".Equals(this.tNedit_PartsManagementDivide2.DataText))
                            {
                                this.tNedit_PartsManagementDivide2.SetInt(0);
                            }
                            // --- ADD 2010/09/01 --- <<<<<
                        }
                        else
                        {
                            // --- DEL 2010/09/01 --- >>>>>
                            //this.tNedit_PartsManagementDivide2.SetInt(0);
                            // --- DEL 2010/09/01 --- <<<<<
                            tEdit_PartsManagementDivide2Name.Text = string.Empty;
                        }
                        // --- DEL 2010/09/01 --- >>>>>
                        //}
                        //else
                        //{
                        //    this.tNedit_PartsManagementDivide2.SetInt(0);
                        //    this.tEdit_PartsManagementDivide2Name.Text = string.Empty;
                        //}
                        // --- DEL 2010/09/01 --- <<<<<

                        // (���}�X�^���o�^�R�[�h�ł��n�j)
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (tEdit_PartsManagementDivide2Name.Text == string.Empty)
                                        {
                                            e.NextCtrl = this.uButton_PartsManagementDivide2;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_StockNote1;
                                        }


                                        break;
                                    }
                            }
                        }

                        # endregion
                        break;
                    }

                // �q��
                case "tEdit_WarehouseCode":
                    {
                        #region �q��
                        if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim())
                            && !_preWarehouseCode.Equals(this.tEdit_WarehouseCode.Text.Trim()))
                        {

                            this.tEdit_WarehouseCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_WarehouseCode.Name, this.tEdit_WarehouseCode.Text);

                            string code;
                            string name;
                            string sectionCode;
                            string sectionName;

                            // �q��(+�Ǘ����_)�ǂݍ���
                            bool readStatus = ReadWarehouseWithSection(tEdit_WarehouseCode.Text.Trim(), out code, out name, out sectionCode, out sectionName);

                            // �R�[�h�E���̂��X�V
                            tEdit_WarehouseCode.Text = code;
                            tEdit_WarehouseName.Text = name;

                            tEdit_SectionCode.Text = sectionCode;
                            tEdit_SectionName.Text = sectionName;

                            # region [�t�H�[�J�X����]
                            if (readStatus == true)
                            {
                                if (!e.ShiftKey)
                                {
                                    // NextCtrl����
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                        //-----UPD 2010/09/01---------->>>>>
                                        case Keys.Down:
                                            //-----UPD 2010/09/01----------<<<<<
                                            {
                                                e.NextCtrl = null;

                                                if (this._prevStockList != null && this._prevStockList.Count > 0)
                                                {
                                                    GetStockFromStockWarehouse(tEdit_WarehouseCode.Text.Trim(), e);
                                                }

                                                if (this.tEdit_GoodsNo.Enabled != false)
                                                {
                                                    e.NextCtrl = this.tEdit_GoodsNo;
                                                }
                                                else if (this.tEdit_WarehouseShelfNo.Enabled != false)
                                                {
                                                    e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                                break;
                                            }
                                        //-----UPD 2010/09/01---------->>>>>
                                        case Keys.Right:
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;

                                                if (this._prevStockList != null && this._prevStockList.Count > 0)
                                                {
                                                    GetStockFromStockWarehouse(tEdit_WarehouseCode.Text.Trim(), e);
                                                }
                                                break;
                                            }
                                        //-----UPD 2010/09/01----------<<<<<
                                    }
                                }
                                // --- ADD 2010/09/08 ----->>>>>
                                else
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                e.NextCtrl = null;
                                            }
                                            break;
                                    }
                                }
                                // --- ADD 2010/09/08 -----<<<<<
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�q�ɂ����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                            }
                            # endregion
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
                            {
                                this._preWarehouseCode = string.Empty;
                                this.tEdit_WarehouseName.Text = string.Empty;
                            }
                            // --- ADD 2010/09/01 ------------------>>>>>
                            if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text))
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Right:
                                            {
                                                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text))
                                                {
                                                    e.NextCtrl = this.uButton_WarehouseGuide;
                                                }
                                                break;
                                            }
                                    }
                                }
                            }
                            // --- ADD 2010/09/08 ----->>>>>
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                            // --- ADD 2010/09/08 -----<<<<<
                            // --- ADD 2010/09/01 ------------------<<<<<
                        }

                        this._preWarehouseCode = this.tEdit_WarehouseCode.Text.Trim();

                        #endregion
                        break;
                    }

                // ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    {
                        #region ���[�J�[�R�[�h
                        if (this._preMakerCode == this.tNedit_GoodsMakerCd.GetInt())
                        {
                            // --- ADD 2010/09/01 ------------------>>>>>
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                            break;
                                        }
                                }
                            }
                            // --- ADD 2010/09/01 ------------------<<<<<
                            break;
                        }

                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            MakerUMnt makerUMnt;

                            // ���[�J�[���擾����
                            status = this._goodsAcs.GetMaker(this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt(), out makerUMnt);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                                this._preMakerCode = makerUMnt.GoodsMakerCd;

                                // ���i�R�[�h�͓��͂���Ă��邩�@���@���i�ύXON
                                if (!this.tEdit_GoodsNo.DataText.Equals(string.Empty))
                                {
                                    changedGoods = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���[�J�[�}�X�^�����o�^�ł��B",
                                    -1,
                                    MessageBoxButtons.OK);
                                // �񑶍ݎ��̓t�H�[�J�X�ړ�����
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                            this.GoodsMakerName_tEdit.DataText = string.Empty;
                            this._preMakerCode = 0;
                            this._priceValue = 0;
                            this._prevStockList = null;
                        }
                        #endregion
                        break;
                    }

                // �i��
                
                case "tEdit_GoodsNo":
                    {
                        #region �i��
                        if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
                        {
                            if (!this._preGoodsNo.Equals(this.tEdit_GoodsNo.DataText.Trim()))
                            {
                                changedGoods = true;
                                this._preGoodsNo = this.tEdit_GoodsNo.DataText.Trim();
                            }
                        }
                        else
                        {
                            this._preGoodsNo = string.Empty;
                            this._priceValue = 0;
                            this._prevStockList = null;
                            this.tEdit_GoodsName.Text = string.Empty;
                        }
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 ----->>>>>
                // �݌ɔ��l�Q
                case "tEdit_StockNote2":
                    {
                        #region �݌ɔ��l�Q
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            { 
                                DialogResult dialogResult = TMsgDisp.Show(this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "�o�^���Ă���낵���ł����B",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                                switch (dialogResult)
                                {
                                    case (DialogResult.Yes):
                                        {
                                            #region �ۑ�
                                            e.NextCtrl = null;
                                            // �ۑ�
                                            bool saveFlag = this.SaveProc();

                                            if (saveFlag)
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCode;
                                            }
                                            #endregion
                                            break;
                                        }
                                    case (DialogResult.No):
                                        {
                                            if (this.uLabel_InputModeTitle.Text == NEW_INPUT_TITLE)
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                            }
                                            break;
                                        }
                                }
                            }

                        }
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 -----<<<<<
            }
            #endregion

            #region ���i����
            // ���i�R�[�h�ύX����I
            if (changedGoods)
            {
                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                string msg = string.Empty;
                GoodsCndtn cndtn = new GoodsCndtn();
                cndtn.EnterpriseCode = this._enterpriseCode;
                cndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                cndtn.GoodsNo = this.tEdit_GoodsNo.DataText;
                cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                cndtn.PriceApplyDate = DateTime.Today; 
                cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;

                // --- ADD 2011/08/03 ---------->>>>>
                // �q�ɂɒl������ꍇ�͓��͒l��D�悳����
                if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.TrimEnd()) == false)
                {
                    List<string> priorWarehouseList = new List<string>();
                    priorWarehouseList.Add(this.tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4, '0'));
                    cndtn.ListPriorWarehouse = priorWarehouseList;
                }
                // --- ADD 2011/08/03  ----------<<<<<

                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                if (goodsUnitDataList.Count > 0)
                {
                    goodsUnitData = goodsUnitDataList[0];
                    this._goodsUnitData = goodsUnitData; // ADD 2010/09/01

                    tEdit_GoodsNo.Text = goodsUnitData.GoodsNo.Trim();
                    // ADD 2010/08/26 --- >>>>
                    if (!string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode))
                    {
                        tEdit_WarehouseCode.Text = goodsUnitData.SelectedWarehouseCode.Trim();

                        // ADD 2010/08/27 --- >>>>
                        string code;
                        string name;
                        string sectionCode;
                        string sectionName;

                        // �q��(+�Ǘ����_)�ǂݍ���
                        bool readStatus = ReadWarehouseWithSection(tEdit_WarehouseCode.Text.Trim(), out code, out name, out sectionCode, out sectionName);

                        // ���̂��X�V
                        tEdit_WarehouseName.Text = name;
                        // ADD 2010/08/27 --- <<<<
                    }
                    // ADD 2010/08/26 --- <<<<

                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                    {
                        if (goodsUnitData.GoodsPriceList.Count > 0)
                        {
                            GoodsPrice goodsPrice = goodsUnitData.GoodsPriceList[0];
                            this._priceValue = goodsPrice.ListPrice;
                        }
                    }
                }
                else
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                            CT_PGID,
                                            "���i�}�X�^�����o�^�ł��B",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);

                        if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                            this.GoodsMakerName_tEdit.Text = string.Empty;
                            this._preMakerCode = 0;
                            e.NextCtrl = tNedit_GoodsMakerCd;
                        }
                        else
                        {
                            this.tEdit_GoodsNo.Text = string.Empty;
                            this._preGoodsNo = string.Empty;
                            e.NextCtrl = tEdit_GoodsNo;
                        }

                        this.tEdit_GoodsName.Text = string.Empty; 
                    }
                    else
                    {
                        e.NextCtrl = tNedit_GoodsMakerCd;
                        // --- ADD 2010/09/08 ----->>>>>
                        this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                        // --- ADD 2010/09/08 -----<<<<<
                    }
                    this._priceValue = 0;
                    return;
                }

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        {
                            switch (goodsUnitData.OfferKubun)
                            {
                                case 0: // ���[�U�[�o�^
                                case 1: // �񋟏����ҏW
                                case 2: // �񋟗D�ǕҏW

                                    if (goodsUnitData.LogicalDeleteCode != 0)
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        CT_PGID,
                                        "���i�}�X�^�����o�^�ł��B",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);

                                        if (this.tNedit_GoodsMakerCd.Focused)
                                        {
                                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                                            this.GoodsMakerName_tEdit.Text = string.Empty;
                                            this._preMakerCode = 0;
                                            e.NextCtrl = tNedit_GoodsMakerCd;
                                        }
                                        else
                                        {
                                            this.tEdit_GoodsNo.Text = string.Empty;
                                            this._preGoodsNo = string.Empty;
                                            e.NextCtrl = tEdit_GoodsNo;
                                        }
                                        this.tEdit_GoodsName.Text = string.Empty;
                                        this._priceValue = 0;
                                        return;
                                    }

                                    ArrayList stockList = new ArrayList();
                                    string retMessage = string.Empty;
                                    this._prevStockList = new List<Stock>();
                                    int stockInfoStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                                    try
                                    {
                                        stockInfoStatus = _stockMstAcs.SearchStockInfo(_enterpriseCode, goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd, out stockList, out retMessage);
                                    }
                                    catch
                                    {
                                        stockInfoStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }

                                    if (stockInfoStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        CT_PGID,
                                        "�݌ɏ��̎擾�Ɏ��s���܂����B",
                                        stockInfoStatus,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                                        this.tEdit_GoodsNo.Text = string.Empty;
                                        this.tEdit_GoodsName.Text = string.Empty;
                                        this._preGoodsNo = string.Empty;
                                        e.NextCtrl = tEdit_GoodsNo;
                                        return;
                                    }

                                    // Ұ���R�[�h
                                    this.tNedit_GoodsMakerCd.Text = goodsUnitData.GoodsMakerCd.ToString("d4");
                                    this.GoodsMakerName_tEdit.Text = goodsUnitData.MakerName;
                                    this._preMakerCode = goodsUnitData.GoodsMakerCd;
                                    // �i��
                                    this.tEdit_GoodsName.Text = goodsUnitData.GoodsName;

                                    

                                    foreach (Stock stock in stockList)
                                    {
                                        this._prevStockList.Add(stock.Clone());
                                    }

                                    string warehouseCodeStr = this.tEdit_WarehouseCode.Text.Trim();

                                    if (!string.IsNullOrEmpty(warehouseCodeStr))
                                    {
                                        this.GetStockFromStockWarehouse(warehouseCodeStr, e);

                                        //----- ADD 2012/12/13 �c���� Redmine#33835 ------------->>>>>
                                        // ���������i�[
                                        StockHistoryDspSearchParam extrInfo;
                                        SetExtrInfo(out extrInfo);
                                        List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

                                        // �o�׉񐔌�������
                                        _stockMstAcs.SearchStockHisDsp(extrInfo, out stockHistoryDspSearchResultList);

                                        CreateGrid();
                                        ShipmentPartsDspResultToScreen(stockHistoryDspSearchResultList);
                                        //----- ADD 2012/12/13 �c���� Redmine#33835 -------------<<<<<
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_WarehouseCode;
                                    }

                                    break;
                                // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                                case 4: // �񋟗D��
                                    {
                                        // �i��
                                        this.tEdit_GoodsNo.Text = goodsUnitData.GoodsNo.Trim();
                                        // Ұ���R�[�h
                                        this.tNedit_GoodsMakerCd.Text = goodsUnitData.GoodsMakerCd.ToString("d4");
                                        this.GoodsMakerName_tEdit.Text = goodsUnitData.MakerName;
                                        this._preMakerCode = goodsUnitData.GoodsMakerCd;
                                        // �i��
                                        this.tEdit_GoodsName.Text = goodsUnitData.GoodsName;
                                        // �݌ɏ��
                                        this._prevStockList = new List<Stock>();
 
                                        string warehouseCodeStrTmp = this.tEdit_WarehouseCode.Text.Trim();

                                        if (!string.IsNullOrEmpty(warehouseCodeStrTmp))
                                        {
                                            this.GetStockFromStockWarehouse(warehouseCodeStrTmp, e);
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_WarehouseCode;
                                        }
                                    }
                                    break;
                                // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
                                default:
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        CT_PGID,
                                        "���i�}�X�^�����o�^�ł��B",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);

                                        if (this.tNedit_GoodsMakerCd.Focused)
                                        {
                                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                                            this.GoodsMakerName_tEdit.Text = string.Empty; 
                                            this._preMakerCode = 0;
                                            e.NextCtrl = tNedit_GoodsMakerCd;
                                        }
                                        else
                                        {
                                            this.tEdit_GoodsNo.Text = string.Empty;
                                            this._preGoodsNo = string.Empty;
                                            e.NextCtrl = tEdit_GoodsNo;
                                        }

                                        this.tEdit_GoodsName.Text = string.Empty;
                                        this._priceValue = 0;
                                        return;
                                }
                            break;
                        }
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                        {
                            break;
                        }
                    default:
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                            CT_PGID,
                            "���i���̎擾�Ɏ��s���܂����B",
                            status,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                        break;
                }
            }
            #endregion

            // --- ADD 2010/09/08 ----->>>>>
            #region �t�H�[�J�X�ړ�
            if (e.NextCtrl != null && (this.uLabel_InputModeTitle.Text.Equals("�V�K") || this.uLabel_InputModeTitle.Text.Equals("�X�V")))
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_WarehouseCode":
                    case "tEdit_SectionCode":
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_SupplierCd":
                    case "tNedit_PartsManagementDivide1":
                    case "tNedit_PartsManagementDivide2":
                        {
                            // �K�C�h
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                            break;
                        }
                    default:
                        {
                            // �K�C�h
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                            break;
                        }
                }
            }
            #endregion
            // --- ADD 2010/09/08 -----<<<<<
        }

        //----- ADD 2012/12/13 �c���� Redmine#33835 ------------------------------------->>>>>
        /// <summary>
        /// ���ݏ����N���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ݏ����N�����擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private void GetThisYearMonth()
        {
            try
            {
                // ���񌎎��X�V�����擾
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    this._thisYearMonth = currentTotalMonth;
                }
                else
                {
                    this._dateGet.GetThisYearMonth(out this._thisYearMonth);
                }

                this._dateGet.GetDaysFromMonth(_thisYearMonth, out _stMonth, out _edMonth);

                _stAddUpDate = _stMonth.Year * 10000 + _stMonth.Month * 100 + _stMonth.Day;
                _edAddUpDate = _edMonth.Year * 10000 + _edMonth.Month * 100 + _edMonth.Day;
            }
            catch
            {
                this._thisYearMonth = new DateTime();
            }
        }

        /// <summary>
        /// �O���b�h���C�A�E�g�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h���C�A�E�g��ݒ肵�܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // �O���b�h�O�ϐݒ�
            //--------------------------------------

            this.uGrid_SalesTimes.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            ColumnsCollection columns = this.uGrid_SalesTimes.DisplayLayout.Bands[0].Columns;

            NoFocusRect noFocusRect = new NoFocusRect();
            this.uGrid_SalesTimes.DrawFilter = noFocusRect;
            this.uGrid_SalesTimes.Refresh();
            
            // �L���v�V����
            columns[COLUMN_TITLE].Header.Caption = "";
            columns[COLUMN_SALESTIMES].Header.Caption = "�o�׉�";

            columns[COLUMN_TITLE].Width = 50;
            columns[COLUMN_SALESTIMES].Width = 100;

            // �e�L�X�g�ʒu(HAlign)
            columns[COLUMN_TITLE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_SALESTIMES].CellAppearance.TextHAlign = HAlign.Right;

            // �e�L�X�g�ʒu(VAlign)
            columns[COLUMN_TITLE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SALESTIMES].CellAppearance.TextVAlign = VAlign.Middle;

            // �Z���J���[
            columns[COLUMN_TITLE].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_TITLE].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_TITLE].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_TITLE].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_TITLE].CellAppearance.ForeColorDisabled = Color.White;

            // �Œ�w�b�_�[
            columns[COLUMN_TITLE].Header.Fixed = true;
        }

        /// <summary>
        /// ���������i�[����
        /// </summary>
        /// <param name="extrInfo">��������(�����I��out�p�����[�^�œn���܂�)</param>
        /// <remarks>
        /// <br>Note       : �����������i�[���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private void SetExtrInfo(out StockHistoryDspSearchParam extrInfo)
        {
            extrInfo = new StockHistoryDspSearchParam();

            // ��ƃR�[�h
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �i��
            extrInfo.GoodsNo = this.tEdit_GoodsNo.DataText.Trim();
            //���[�J�[
            extrInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // �q�ɃR�[�h
            extrInfo.WarehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            // �J�n�N��
            extrInfo.StAddUpYearMonth = this._thisYearMonth.AddMonths(-12).Year * 100 + this._thisYearMonth.AddMonths(-12).Month;
            // �I���N��
            extrInfo.EdAddUpYearMonth = this._thisYearMonth.AddMonths(-1).Year * 100 + this._thisYearMonth.AddMonths(-1).Month;
            // �J�n�N����
            extrInfo.StAddUpDate = this._stAddUpDate;
            // �I���N����
            extrInfo.EdAddUpDate = this._edAddUpDate;
        }

        /// <summary>
        /// �O���b�h�쐬����
        /// </summary>
        /// <param name="updHisDspWorkList">�X�V�������X�g</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���쐬���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private void CreateGrid()
        {
            //--------------------------------------
            // �O���b�h��A�f�[�^�ݒ�
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_TITLE, typeof(string));

            dataTable.Columns.Add(COLUMN_SALESTIMES, typeof(string));

            string[] titleArray = new string[13];
            for (int i = 0; i < 12; i++)
            {
                titleArray[i] = _thisYearMonth.AddMonths(-i - 1).Month.ToString() + "��";
            }
            titleArray[12] = "���v";

            for (int index = 0; index < 13; index++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_TITLE] = titleArray[index];
                dataRow[COLUMN_SALESTIMES] = "0";

                dataTable.Rows.Add(dataRow);
            }
            this.uGrid_SalesTimes.DataSource = dataTable;
            this.uGrid_SalesTimes.ActiveRow = null;
        }

        /// <summary>
        /// �o�׉񐔒��o���ʉ�ʕ\������
        /// </summary>
        /// <param name="shipmentPartsDspResultList">�o�׉񐔒��o���ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �o�׉񐔒��o���ʃ��X�g����ʕ\�����܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private void ShipmentPartsDspResultToScreen(List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            int salesTimes, sumsalesTimes = 0;

            int i = 0;
            ArrayList avgList = new ArrayList();

            for (i = 0; i <= 12; i++)
            {
                // ����
                this.uGrid_SalesTimes.Rows[i].Cells[COLUMN_SALESTIMES].Value = "0";
            }

            if (stockHistoryDspSearchResultList.Count != 0)
            {
                foreach (StockHistoryDspSearchResult stockHistoryDspSearchResult in stockHistoryDspSearchResultList)
                {
                    #region �O���`1�N��
                    for (i = 12; i > 0; i--)
                    {
                        int month = _thisYearMonth.AddMonths(-i).Month;
                        int year = _thisYearMonth.AddMonths(-i).Year;
                        if (stockHistoryDspSearchResult.AddUpYearMonth.Month == month && stockHistoryDspSearchResult.AddUpYearMonth.Year == year)
                        {
                            salesTimes = stockHistoryDspSearchResult.SalesTimes;
                            if (salesTimes.ToString().Length > 7)
                            {
                                salesTimes = int.Parse(salesTimes.ToString().Substring(salesTimes.ToString().Length - 7, 7));
                            }
                            this.uGrid_SalesTimes.Rows[i - 1].Cells[COLUMN_SALESTIMES].Value = salesTimes.ToString("#,###,##0");
                            sumsalesTimes += salesTimes;
                        }
                    }
                    #endregion
                }
            }

            // ���v
            if (sumsalesTimes.ToString().Length > 7)
            {
                sumsalesTimes = int.Parse(sumsalesTimes.ToString().Substring(sumsalesTimes.ToString().Length - 7, 7));
            }
            this.uGrid_SalesTimes.Rows[12].Cells[COLUMN_SALESTIMES].Value = sumsalesTimes.ToString("#,###,##0");
        }
        //----- ADD 2012/12/13 �c���� Redmine#33835 -------------------------------------<<<<<

        /// <summary>
        /// �񋟁E���[�U�[��ʐؑ�
        /// </summary>
        /// <param name="modeFlg">��ʐؑ֋敪</param>
        /// <remarks>
        /// <br>Note       : �񋟁E���[�U�[��ʐؑւɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks> 
        private void ChangeEditMode(int modeFlg)
        {
            if (modeFlg == 0)
            {
                // �Ȃ�
            }
            // ������̍폜���[�h
            else if (modeFlg == 1)
            {
                // �폜
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Visible = false;
                // ���S�폜�A����
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Enabled = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Visible = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Enabled = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Visible = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.Enabled = false;
                // --- ADD 2010/09/08 ----->>>>>
                // �K�C�h
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                // �ŐV���
                this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.Enabled = false;
                // --- ADD 2010/09/08 -----<<<<<
            }
            // ������̍X�V���[�h
            else if (modeFlg == 2)
            {
                // �폜
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Enabled = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Visible = true;
                // ���S�폜�A����
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 ----->>>>>
                // �K�C�h
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                // �ŐV���
                this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
            }
            // �V�K�̏ꍇ�A
            else if (modeFlg == 3)
            {
                // �폜
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Visible = true;
                // ���S�폜�A����
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 ----->>>>>
                // �K�C�h
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // �ŐV���
                this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<

            }
        }

        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text">���l</param>
        /// <remarks>
        /// <br>Note       : ���l�ϊ������ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks> 
        /// <returns></returns>
        private int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h���̎擾����
        /// </summary>
        /// <param name="div">���[�U�[�K�C�h�敪</param>
        /// <param name="userGuideCode">���[�U�[�K�C�h�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h���̎擾�����ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks> 
        /// <returns></returns>
        private string GetUserGuideName(int div, int userGuideCode)
        {
            int code;
            string name;
            ReadUserGuide(div, userGuideCode, out code, out name);

            return name;
        }

        /// <summary>
        /// ���[�U�[�K�C�hRead
        /// </summary>
        /// <param name="guideDivCode">���[�U�[�敪�K�C�h</param>
        /// <param name="guideCode">���[�U�[�K�C�h�R�[�h</param>
        /// <param name="code">�R�[�h</param>
        /// <param name="name">����</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h���̎擾�����ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks>
        /// <returns></returns>
        private bool ReadUserGuide(int guideDivCode, int guideCode, out int code, out string name)
        {
            bool result = false;

            // �ǂݍ���
            if (_userGuideAcs == null)
            {
                _userGuideAcs = new UserGuideAcs();
            }
            UserGdBd userGdBd;
            UserGuideAcsData userGuideAcsData = UserGuideAcsData.UserBodyData;
            int status = _userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, guideDivCode, guideCode, ref userGuideAcsData);

            if (status == 0 && userGdBd != null && userGdBd.LogicalDeleteCode == 0)
            {
                // �Y�����聨�\��
                code = userGdBd.GuideCode;
                name = userGdBd.GuideName.TrimEnd();

                result = true;
            }
            else
            {
                // �Y���Ȃ����N���A
                code = 0;
                name = string.Empty;

                // �m�f�ɂ���
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : Timer.Tick �C�x���g �C�x���g(Initial_Timer)�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void Initial_timer_Tick(object sender, EventArgs e)
        {
            this.Initial_timer.Enabled = false;

            try
            {
                string msg;

                // ���j���[���[�h���̓T�[�o�[�ǂݍ��݌Œ�
                this._goodsAcs.IsLocalDBRead = false;

                // �����l�f�[�^�擾
                int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception)
            {
                // �Ȃ��B
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, emErrorLevel iLevel)
        {
            // ���b�Z�[�W�\��
            return TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                iLevel,                             // �G���[���x��
                this.GetType().ToString(),          // �A�Z���u���h�c�܂��̓N���X�h�c
                message,                            // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);             // �\������{�^��
        }

        /// <summary>
        /// �݌Ɂ@���@���
        /// </summary>
        /// <param name="data">�݌Ƀf�[�^</param>
        /// <remarks>
        /// <br>Note       : �݌Ɂ@���@��ʂ̕\�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2011/08/29 wangf �A��1016�̑Ή�</br>
        /// </remarks>
        private void SetScreenFromStock(Stock data)
        {
            try
            {
                // �`����~�߂遄��
                this.SuspendLayout();

                //----------------------------------------------
                // ���ڂ̃Z�b�g
                //----------------------------------------------
                // �쐬��
                CreateDateTime_tDateEdit.SetDateTime(data.CreateDateTime);
                // �X�V��
                UpdateDateTime_tDateEdit.SetDateTime(data.UpdateDateTime);

                // �q�ɃR�[�h
                tEdit_WarehouseCode.Text = data.WarehouseCode.TrimEnd();
                // �i��
                tEdit_GoodsNo.Text = data.GoodsNo.Trim();

                // �Ǘ����_�R�[�h
                tEdit_SectionCode.Text = data.SectionCode.TrimEnd();
                // �Ǘ����_����
                tEdit_SectionName.Text = this.GetSectionName(data.SectionCode.TrimEnd());

                // ���i���[�J�[�R�[�h
                this.tNedit_GoodsMakerCd.Text = data.GoodsMakerCd.ToString();

                // �I��
                tEdit_WarehouseShelfNo.Text = data.WarehouseShelfNo.TrimEnd();
                // �d���I�ԂP
                tEdit_DuplicationShelfNo1.Text = data.DuplicationShelfNo1.TrimEnd();
                // �d���I�ԂQ
                tEdit_DuplicationShelfNo2.Text = data.DuplicationShelfNo2.TrimEnd();

                // �Œ�݌ɐ�
                tNedit_MinimumStockCnt.SetValue(data.MinimumStockCnt);
                // �ō��݌ɐ�
                tNedit_MaximumStockCnt.SetValue(data.MaximumStockCnt);

                // �������b�g
                tNedit_SalesOrderUnit.SetValue(data.SalesOrderUnit);
                // ������R�[�h
                tNedit_SupplierCd.SetInt(data.StockSupplierCode);
                // �����於��
                tEdit_SupplierName.Text = this.GetSupplierName(data.StockSupplierCode).TrimEnd();

                // �����c
                tNedit_SalesOrderCount.SetValue(data.SalesOrderCount);

                // �ŏI�����
                tDateEdit_lastSalesDate.SetDateTime(data.LastSalesDate);
                // �ŏI�d����
                tDateEdit_lastStockDate.SetDateTime(data.LastStockDate);


                // �I���]����
                tNedit_StockUnitPriceRate.Clear();
                // �I���]���P��
                if (data.StockUnitPriceFl == 0)
                {
                    tNedit_StockUnitPriceFl.Clear();
                }
                else
                {
                    tNedit_StockUnitPriceFl.SetValue(data.StockUnitPriceFl);
                }
                // �݌ɔ��l�P
                tEdit_StockNote1.DataText = data.StockNote1.Trim();
                // �݌ɔ��l�Q
                tEdit_StockNote2.DataText = data.StockNote2.Trim();

                // �Ǘ��敪�P�R�[�h
                tNedit_PartsManagementDivide1.SetInt(ToInt(data.PartsManagementDivide1));
                // �Ǘ��敪�P����
                tEdit_PartsManagementDivide1Name.Text = this.GetUserGuideName(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt()).TrimEnd();
                // �Ǘ��敪�Q�R�[�h
                tNedit_PartsManagementDivide2.SetInt(ToInt(data.PartsManagementDivide2));
                // �Ǘ��敪�Q����
                tEdit_PartsManagementDivide2Name.Text = this.GetUserGuideName(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt()).TrimEnd();
                // �݌ɋ敪
                tComboEditor_StockDiv.Value = data.StockDiv;

                //-----------------------------------------------
                // �i�폜�Ή��j
                //-----------------------------------------------
                if (data.LogicalDeleteCode == 0)
                {
                    // -- add wangf 2011/08/29 ---------->>>>>
                    if (this._stockMngTtlStAcs == null)
                    {
                        this._stockMngTtlStAcs = new StockMngTtlStAcs();
                    }
                    StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
                    this._stockMngTtlStAcs.Read(out stockMngTtlSt, this._enterpriseCode);
                    // -- add wangf 2011/08/29 ----------<<<<<
                    // �d���݌ɐ�
                    tNedit_SupplierStock.SetValue(data.SupplierStock);
                    // ���א��i���v��j
                    tNedit_ArrivalCnt.SetValue(data.ArrivalCnt);
                    // �o�א��i���v��j
                    tNedit_ShipmentCnt.SetValue(data.ShipmentCnt);
                    // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
                    this._preShipmentCnt = data.ShipmentCnt;
                    if (data.ShipmentCnt < 0)
                    {
                        tNedit_ShipmentCnt.Enabled = true;
                        tNedit_ShipmentCnt.Appearance.BackColor = BACKCOLOR_ENABLE;
                    }
                    // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<
                    // �󒍐�
                    tNedit_AcpOdrCount.SetValue(data.AcpOdrCount);
                    // �ړ����d���݌ɐ�
                    tNedit_MovingSupliStock.SetValue(data.MovingSupliStock);
                    // ���݌ɐ�(�o�׉\��)
                    tNedit_ShipmentPosCnt.SetValue(data.ShipmentPosCnt);

                    /* -- del wangf 2011/08/29 ---------->>>>>
                    _shipmentPosCountOrigin = data.ShipmentPosCnt - data.SupplierStock
                                                                  - data.ArrivalCnt
                                                                  + data.ShipmentCnt
                                                                  + data.AcpOdrCount
                                                                  + data.MovingSupliStock;
                    // -- del wangf 2011/08/29 ----------<<<<<*/
                    // -- add wangf 2011/08/29 ---------->>>>>
                    if (stockMngTtlSt.PreStckCntDspDiv == 0)
                    {
                        // �󒍕��܂�
                        _shipmentPosCountOrigin = data.ShipmentPosCnt - data.SupplierStock
                                                                  - data.ArrivalCnt
                                                                  + data.ShipmentCnt
                                                                  + data.AcpOdrCount
                                                                  + data.MovingSupliStock;
                    }
                    else
                    {
                        // �󒍕��܂܂Ȃ�
                        _shipmentPosCountOrigin = data.ShipmentPosCnt - data.SupplierStock
                                                                  - data.ArrivalCnt
                                                                  + data.ShipmentCnt
                                                                  + data.MovingSupliStock;
                    }
                    // -- add wangf 2011/08/29 ----------<<<<<
                }
                else
                {
                    //-----------------------------------------------------------------
                    // �_���폜or���S�폜�Ȃ�΃[���ŕ\��
                    // �i�����I�ɂ͌��̐��ʁ~�}�C�i�X�ŕێ�����K�v������ׁj
                    //-----------------------------------------------------------------
                    // �d���݌ɐ�
                    tNedit_SupplierStock.SetValue(0);
                    // ���א��i���v��j
                    tNedit_ArrivalCnt.SetValue(0);
                    // �o�א��i���v��j
                    tNedit_ShipmentCnt.SetValue(0);
                    // �󒍐�
                    tNedit_AcpOdrCount.SetValue(0);
                    // �ړ����d���݌ɐ�
                    tNedit_MovingSupliStock.SetValue(0);
                    // ���݌ɐ�(�o�׉\��)
                    tNedit_ShipmentPosCnt.SetValue(0);
                    _shipmentPosCountOrigin = 0;
                }

                updateTimeDt = data.UpdateDateTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // �`����ĊJ����
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���_���̎擾�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private string GetSectionName(string sectionCode)
        {
            string code;
            string name;
            ReadSection(sectionCode, out code, out name);

            return name;
        }

        /// <summary>
        /// ���_Read
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="code">�R�[�h</param>
        /// <param name="name">����</param>
        /// <remarks>
        /// <br>Note       : ���_���̎擾�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool ReadSection(string sectionCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (sectionCode != string.Empty)
            {
                // �ǂݍ���
                if (_secInfoSetAcs == null)
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);

                if (status == 0 && secInfoSet != null)
                {
                    // �Y�����聨�\��
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm.TrimEnd();

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���_���̎擾�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private string GetSupplierName(int supplierCd)
        {
            int code;
            string name;
            ReadSupplier(supplierCd, out code, out name);

            return name;
        }

        /// <summary>
        /// �d����Read
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="code">�R�[�h</param>
        /// <param name="name">����</param>
        /// <remarks>
        /// <br>Note       : �d���於�̎擾�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool ReadSupplier(int supplierCd, out int code, out string name)
        {
            bool result = false;

            // �����͔���
            if (supplierCd != 0)
            {
                // �ǂݍ���
                if (_supplierAcs == null)
                {
                    _supplierAcs = new SupplierAcs();
                }
                Supplier supplier;
                int status = _supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd);

                if (status == 0 && supplier != null && supplier.LogicalDeleteCode == 0)
                {
                    // �Y�����聨�\��
                    code = supplier.SupplierCd;
                    name = supplier.SupplierNm1.TrimEnd();

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = 0;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = 0;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// ���̓R���g���[���̓��͉E�s�ݒ菈���i�݌Ɂj
        /// </summary>
        /// <param name="modeFlg">���[�h�t���O</param>
        /// <remarks>
        /// <br>Note       : ���̓R���g���[���̓��͉E�s�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void SettingControlsEnabled(int modeFlg)
        {
            // ������̐V�K���[�h
            if (modeFlg == 0)
            {
                // �Ȃ��B
            }
            // ������̍폜���[�h
            else if (modeFlg == 1)
            {
                this.tEdit_WarehouseCode.Enabled = false;
                this.uButton_WarehouseGuide.Enabled = false;
                this.tEdit_SectionCode.Enabled = false;
                this.uButton_SectionGuide.Enabled = false;
                this.tEdit_GoodsNo.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.GoodsMakerGuide_uButton.Enabled = false;

                this.tEdit_WarehouseShelfNo.Enabled = false;
                this.tEdit_DuplicationShelfNo1.Enabled = false;
                this.tEdit_DuplicationShelfNo2.Enabled = false;
                this.tComboEditor_StockDiv.Enabled = false;
                this.tNedit_SupplierCd.Enabled = false;
                this.uButton_SupplierGuide.Enabled = false;
                this.tDateEdit_lastSalesDate.Enabled = false;
                this.tDateEdit_lastStockDate.Enabled = false;
                this.tNedit_PartsManagementDivide1.Enabled = false;
                this.uButton_PartsManagementDivide1.Enabled = false;
                this.tNedit_PartsManagementDivide2.Enabled = false;
                this.uButton_PartsManagementDivide2.Enabled = false;
                this.tEdit_StockNote1.Enabled = false;
                this.tEdit_StockNote2.Enabled = false;
                this.tNedit_MinimumStockCnt.Enabled = false;
                this.tNedit_MaximumStockCnt.Enabled = false;
                this.tNedit_SalesOrderUnit.Enabled = false;
                this.tNedit_SalesOrderCount.Enabled = false;
                this.tNedit_StockUnitPriceRate.Enabled = false;
                this.tNedit_StockUnitPriceFl.Enabled = false;
                this.tNedit_SupplierStock.Enabled = false;
            }
            // ������̍X�V���[�h
            else if (modeFlg == 2)
            {
                this.tEdit_WarehouseCode.Enabled = false;
                this.uButton_WarehouseGuide.Enabled = false;
                this.tEdit_GoodsNo.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.GoodsMakerGuide_uButton.Enabled = false;

                this.tEdit_SectionCode.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;
                this.tEdit_WarehouseShelfNo.Enabled = true;
                this.tEdit_DuplicationShelfNo1.Enabled = true;
                this.tEdit_DuplicationShelfNo2.Enabled = true;
                this.tComboEditor_StockDiv.Enabled = true;
                this.tNedit_SupplierCd.Enabled = true;
                this.uButton_SupplierGuide.Enabled = true;
                this.tDateEdit_lastSalesDate.Enabled = true;
                this.tDateEdit_lastStockDate.Enabled = true;
                this.tNedit_PartsManagementDivide1.Enabled = true;
                this.uButton_PartsManagementDivide1.Enabled = true;
                this.tNedit_PartsManagementDivide2.Enabled = true;
                this.uButton_PartsManagementDivide2.Enabled = true;
                this.tEdit_StockNote1.Enabled = true;
                this.tEdit_StockNote2.Enabled = true;
                this.tNedit_MinimumStockCnt.Enabled = true;
                this.tNedit_MaximumStockCnt.Enabled = true;
                this.tNedit_SalesOrderUnit.Enabled = true;
                this.tNedit_SalesOrderCount.Enabled = true;
                this.tNedit_StockUnitPriceRate.Enabled = true;
                this.tNedit_StockUnitPriceFl.Enabled = true;
                this.tNedit_SupplierStock.Enabled = true;
            }
            // ��ʐV�K���[�h
            else if (modeFlg == 3)
            {
                this.tEdit_WarehouseCode.Enabled = true;
                this.uButton_WarehouseGuide.Enabled = true;
                this.tEdit_SectionCode.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;
                this.tEdit_GoodsNo.Enabled = true;
                this.tNedit_GoodsMakerCd.Enabled = true;
                this.GoodsMakerGuide_uButton.Enabled = true;

                this.tEdit_WarehouseShelfNo.Enabled = true;
                this.tEdit_DuplicationShelfNo1.Enabled = true;
                this.tEdit_DuplicationShelfNo2.Enabled = true;
                this.tComboEditor_StockDiv.Enabled = true;
                this.tNedit_SupplierCd.Enabled = true;
                this.uButton_SupplierGuide.Enabled = true;
                this.tDateEdit_lastSalesDate.Enabled = true;
                this.tDateEdit_lastStockDate.Enabled = true;
                this.tNedit_PartsManagementDivide1.Enabled = true;
                this.uButton_PartsManagementDivide1.Enabled = true;
                this.tNedit_PartsManagementDivide2.Enabled = true;
                this.uButton_PartsManagementDivide2.Enabled = true;
                this.tEdit_StockNote1.Enabled = true;
                this.tEdit_StockNote2.Enabled = true;
                this.tNedit_MinimumStockCnt.Enabled = true;
                this.tNedit_MaximumStockCnt.Enabled = true;
                this.tNedit_SalesOrderUnit.Enabled = true;
                this.tNedit_SalesOrderCount.Enabled = true;
                this.tNedit_StockUnitPriceRate.Enabled = true;
                this.tNedit_StockUnitPriceFl.Enabled = true;
                this.tNedit_SupplierStock.Enabled = true;
            }

        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: K2021/05/17 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>           : BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή�</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.uiSetControl1.SettingAllControlsZeroPaddedText();

            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // �I��
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        #region �I��
                        if (this.CloseCheck())
                        {
                            this.Close();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_QUESTION, 
                                CT_PGID,
                                "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H", 
                                0,
                                MessageBoxButtons.YesNoCancel);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    this.Close();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.Close();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                            }
                        }
                        #endregion
                        break;
                    }
				// -------------------------------------------------------------------------------
				// �ۑ�
				// -------------------------------------------------------------------------------
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        #region �ۑ�
                        this.SaveProc();
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
				// �V�K
				// -------------------------------------------------------------------------------
                case TOOLBAR_NEWBUTTON_KEY:
                    {
                        #region �V�K
                        if (this.CloseCheck())
                        {
                            this.NewProc();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                            emErrorLevel.ERR_LEVEL_QUESTION,
                                            CT_PGID,
                                            "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + "�o�^���Ă���낵���ł����H",
                                            0,
                                            //MessageBoxButtons.YesNoCancel);  // DEL by gezh 2011/11/28 redmine#8179
                                            // ADD by gezh 2011/11/28 redmine#8179 begin ----------->>>>>
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxDefaultButton.Button2);
                                            // ADD by gezh 2011/11/28 redmine#8179 end -------------<<<<<
                            switch (dr)
                            {
                                case DialogResult.No:
                                    this.NewProc();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.NewProc();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                            }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
				// �폜
				// -------------------------------------------------------------------------------
                case TOOLBAR_DELETEBUTTON_KEY:
                    {
                        #region �폜
                        // �����X�V��ł���΍݌Ƀf�[�^�̍X�V�͍s���Ȃ�
                        if (!CanWrite(DateTime.Now)) return;

                        DialogResult dialogResult = TMsgDisp.Show(this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "�f�[�^��_���폜���܂��B" + "\r\n" + "\r\n" +
                                                    "��낵���ł����H",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                        switch (dialogResult)
                        {
                            case (DialogResult.Yes):
                                {
                                    // �_���폜����
                                    // --- UPD 2010/09/07 ---------->>>>>
                                    //#region �폜�f�[�^
                                    //Stock retStock = new Stock();
                                    //retStock.EnterpriseCode = this._enterpriseCode;
                                    //retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                                    //retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
                                    //retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                                    //retStock.UpdateDateTime = this.updateTimeDt;
                                    //#endregion

                                    //int status = _stockMstAcs.LogicalDelete(retStock);

                                    List<Rate> rateList = new List<Rate>();
                                    string msg = string.Empty;

                                    for (int i = 0; i < this._goodsUnitData.StockList.Count; i++)
                                    {
                                        if (this.tEdit_WarehouseCode.Text.Equals(this._goodsUnitData.StockList[i].WarehouseCode))
                                        {
                                            Stock stock = this._goodsUnitData.StockList[i];
                                            stock.LogicalDeleteCode = 1;
                                            //this._goodsUnitData.StockList[i] = stock;
                                            break;
                                        }
                                    }
                                    // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� ----->>>>>
                                    //�폜�O�̑q�ɏ���ێ�����B
                                    List<Stock> bkStockList = new List<Stock>();
                                    foreach (Stock stock in _goodsUnitData.StockList)
                                    {
                                        bkStockList.Add(stock.Clone());
                                    }
                                    // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� -----<<<<<
                                    int status = this._goodsAcs.Write(ref this._goodsUnitData, this._prevStockList, ref rateList, out msg);
                                    // --- UPD 2010/09/07 ----------<<<<<

                                    #region < �_���폜�㏈�� >
                                    switch (status)
                                    {
                                        #region -- �ʏ�I�� --
                                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                                            // --- UPD 2010/09/08 ----->>>>>
                                            //// ��ʂ�����������
                                            //this.ClearScreen();
                                            //this.SettingControlsEnabled(3);
                                            //this.ChangeEditMode(3);

                                            //this._preGoodsNo = string.Empty;
                                            //this._preMakerCode = 0;
                                            //this._preWarehouseCode = string.Empty;
                                            //this._prevStockList = null;
                                            //this.updateTimeDt = new DateTime();

                                            //// �q�ɂփt�H�[�J�X�ړ�
                                            //this.tEdit_WarehouseCode.Focus();

                                            //this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

                                            // �폜���[�h��ݒ�
                                            this.SettingControlsEnabled(1);
                                            this.ChangeEditMode(1);

                                            for (int i = 0; i < this._prevStockList.Count; i++)
                                            {
                                                if (this.tEdit_WarehouseCode.Text.Equals(this._prevStockList[i].WarehouseCode.Trim()))
                                                {
                                                    Stock preStock = this._prevStockList[i];
                                                    preStock.SupplierStock = 0;
                                                    break;
                                                }
                                            }

                                            Stock stock = this._goodsUnitData.StockList.Find(delegate(Stock targetStock) {
                                                if (this.tEdit_WarehouseCode.Text.Equals(targetStock.WarehouseCode))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
                                            this.updateTimeDt = stock.UpdateDateTime;
                                            this.tNedit_SupplierStock.SetValue(0);

                                            this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;
                                            // --- UPD 2010/09/08 -----<<<<<

                                            break;
                                        #endregion

                                        #region -- �r������ --
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                            ExclusiveTransaction(status, true);
                                            break;
                                        #endregion

                                        #region -- �_���폜���s --
                                        default:
                                            TMsgDisp.Show(
                                                this,                                 // �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                                                CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                                CT_PGNM,                                // �v���O��������
                                                "LogicalDelete",                           // ��������
                                                TMsgDisp.OPE_DELETE,                  // �I�y���[�V����
                                                "��ʘ_���폜�����Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                                                status,                      // �X�e�[�^�X�l
                                                this._stockMstAcs,                    // �G���[�����������I�u�W�F�N�g
                                                MessageBoxButtons.OK,                 // �\������{�^��
                                                MessageBoxDefaultButton.Button1);     // �����\���{�^��
                                            break;
                                        #endregion
                                    }
                                    // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� ----->>>>>
                                    //�폜���s�̏ꍇ
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        //�폜�O�̑q�ɏ��ɖ߂�
                                        this._goodsUnitData.StockList = bkStockList;
                                    }
                                    // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� -----<<<<<
                                    #endregion

                                    break;
                                }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // ���S�폜
                // -------------------------------------------------------------------------------
                case TOOLBAR_COMPLETEDELETEBUTTON_KEY:
                    {
                        #region ���S�폜
                        // �����X�V��ł���΍݌Ƀf�[�^�̍X�V�͍s���Ȃ�
                        if (!CanWrite(DateTime.Now)) return;

                        DialogResult dialogResult = TMsgDisp.Show(this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "�f�[�^�����S�폜���܂��B" + "\r\n" + "\r\n" +
                                                    "��낵���ł����H",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                        switch (dialogResult)
                        {
                            case (DialogResult.Yes):
                                {
                                    // ���S�폜����
                                    #region �폜�f�[�^
                                    Stock retStock = new Stock();
                                    retStock.EnterpriseCode = this._enterpriseCode;
                                    retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                                    retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
                                    retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                                    retStock.UpdateDateTime = this.updateTimeDt;
                                    #endregion

                                    int status = _stockMstAcs.Delete(retStock);

                                    #region < ���S�폜�㏈�� >
                                    switch (status)
                                    {
                                        #region -- �ʏ�I�� --
                                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                                            // ��ʂ�����������
                                            this.ClearScreen();
                                            this.SettingControlsEnabled(3);
                                            this.ChangeEditMode(3);

                                            this._preGoodsNo = string.Empty;
                                            this._preMakerCode = 0;
                                            this._prevStockList = null;
                                            this._preWarehouseCode = string.Empty;
                                            this.updateTimeDt = new DateTime();

                                            // �q�ɂփt�H�[�J�X�ړ�
                                            this.tEdit_WarehouseCode.Focus();
                                            // --- ADD 2010/09/08 ----->>>>>
                                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                                            // --- ADD 2010/09/08 -----<<<<<

                                            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

                                            break;
                                        #endregion

                                        #region -- �r������ --
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                            ExclusiveTransaction(status, true);
                                            break;
                                        #endregion

                                        #region -- ���S�폜���s --
                                        default:
                                            TMsgDisp.Show(
                                                this,                                 // �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                                                CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                                CT_PGNM,                                // �v���O��������
                                                "Delete",                           // ��������
                                                TMsgDisp.OPE_DELETE,                  // �I�y���[�V����
                                                "��ʊ��S�폜�����Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                                                status,                      �@�@�@�@�@// �X�e�[�^�X�l
                                                this._stockMstAcs,                    // �G���[�����������I�u�W�F�N�g
                                                MessageBoxButtons.OK,                 // �\������{�^��
                                                MessageBoxDefaultButton.Button1);     // �����\���{�^��
                                            break;
                                        #endregion
                                    }
                                    #endregion

                                    break;
                                }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // ����
                // -------------------------------------------------------------------------------
                case TOOLBAR_REVIVEBUTTON_KEY:
                    {
                        #region ����
                        // �����X�V��ł���΍݌Ƀf�[�^�̍X�V�͍s���Ȃ�
                        if (!CanWrite(DateTime.Now)) return;

                        // ��������
                        #region �����f�[�^
                        Stock retStock = new Stock();
                        retStock.EnterpriseCode = this._enterpriseCode;
                        retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                        retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
                        retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                        retStock.UpdateDateTime = this.updateTimeDt;
                        #endregion

                        int status = _stockMstAcs.RevivalLogicalDelete(ref retStock);
                        this._stockBak.UpdateDateTime = retStock.UpdateDateTime; // ADD 2010/09/06
                        this._stockBak.UpdEmployeeCode = retStock.UpdEmployeeCode; // ADD 2010/09/06
                        this._stockBak.UpdAssemblyId1 = retStock.UpdAssemblyId1; // ADD 2010/09/06
                        this._stockBak.UpdAssemblyId2 = retStock.UpdAssemblyId2; // ADD 2010/09/06
                        this._stockBak.LogicalDeleteCode = retStock.LogicalDeleteCode; // ADD 2010/09/06
                        this._stockBak.SupplierStock = retStock.SupplierStock; // ADD 2010/09/06

                        // --- ADD 2010/09/08 ----->>>>>
                        for (int i = 0; i < this._goodsUnitData.StockList.Count; i++)
                        {
                            if (this.tEdit_WarehouseCode.Text.Equals(this._goodsUnitData.StockList[i].WarehouseCode))
                            {
                                Stock stock = this._goodsUnitData.StockList[i];
                                stock.UpdateDateTime = retStock.UpdateDateTime;
                                stock.UpdEmployeeCode = retStock.UpdEmployeeCode;
                                stock.UpdAssemblyId1 = retStock.UpdAssemblyId1;
                                stock.UpdAssemblyId2 = retStock.UpdAssemblyId2;
                                stock.LogicalDeleteCode = retStock.LogicalDeleteCode;
                                stock.SupplierStock = retStock.SupplierStock;
                                this._goodsUnitData.StockList[i] = stock;
                                break;
                            }
                        }
                        // --- ADD 2010/09/08 -----<<<<<

                        #region < �����㏈�� >
                        switch (status)
                        {
                            #region -- �ʏ�I�� --
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                                // ��ʂ�����������
                                this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;

                                this.SettingControlsEnabled(2);
                                this.ChangeEditMode(2);

                                // �I�Ԃփt�H�[�J�X�ړ�
                                this.tEdit_WarehouseShelfNo.Focus();

                                this.updateTimeDt = retStock.UpdateDateTime;

                                break;
                            #endregion

                            #region -- �r������ --
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                ExclusiveTransaction(status, true);
                                break;
                            #endregion

                            #region -- �������s --
                            default:
                                TMsgDisp.Show(
                                    this,                                 // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                                    CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                    CT_PGNM,                                // �v���O��������
                                    "RevivalLogicalDelete",                           // ��������
                                    TMsgDisp.OPE_RECIEVE,                  // �I�y���[�V����
                                    "��ʕ��������Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                                    status,                      �@�@�@�@�@// �X�e�[�^�X�l
                                    this._stockMstAcs,                    // �G���[�����������I�u�W�F�N�g
                                    MessageBoxButtons.OK,                 // �\������{�^��
                                    MessageBoxDefaultButton.Button1);     // �����\���{�^��
                                break;
                            #endregion
                        }
                        #endregion
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // �ŐV���
                // -------------------------------------------------------------------------------
                case TOOLBAR_RENEWALBUTTON_KEY:
                    {
                        #region �ŐV���
                        string msg;
                        this._goodsAcs.SearchInitial(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);

                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "�ŐV�����擾���܂����B",
                                      0,
                                      MessageBoxButtons.OK);
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 ----->>>>>
                // -------------------------------------------------------------------------------
                // �K�C�h
                // -------------------------------------------------------------------------------
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        #region �K�C�h
                        // �K�C�h�N������
                        this.ExecuteGuide();
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 -----<<<<<
            }
        }

        /// <summary>
        /// �����X�V����Ă��邩�`�F�b�N���A�����݉\�ł��邩���f���܂��B
        /// </summary>
        /// <param name="updateingDateTime">�X�V��</param>
        /// <remarks>
        /// <br>Note       : �����X�V����Ă��邩�`�F�b�N���A�����݉\�ł��邩���f���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>
        /// <c>true</c> :�����݉\�ł��B<br/>
        /// <c>false</c>:�����ݕs�ł��B
        /// </returns>
        private bool CanWrite(DateTime updateingDateTime)
        {
            return CanWrite(new List<Stock>(), null, updateingDateTime);
        }

        /// <summary>
        /// �����X�V����Ă��邩�`�F�b�N���A�����݉\�ł��邩���f���܂��B
        /// </summary>
        /// <param name="writingStockList">�����ލ݌Ƀ��R�[�h�̃��X�g</param>
        /// <param name="previousStockList">�����ޑO�̍݌Ƀ��R�[�h�̃��X�g</param>
        /// <param name="updatingDateTime">�X�V��</param>
        /// <remarks>
        /// <br>Note       : �����X�V����Ă��邩�`�F�b�N���A�����݉\�ł��邩���f���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>
        /// <c>true</c> :�����݉\�ł��B<br/>
        /// <c>false</c>:�����ݕs�ł��B
        /// </returns>
        private bool CanWrite(
            List<Stock> writingStockList,
            List<Stock> previousStockList,
            DateTime updatingDateTime
        )
        {

            // �����X�V�̃`�F�b�N
            DateTime updatingDate = new DateTime(updatingDateTime.Year, updatingDateTime.Month, updatingDateTime.Day);
            DateTime prevTotalDay = DateTime.Now;   // 3�p����
            StockMoveInputInitDataAcs checker = StockMoveInputInitDataAcs.GetInstance();
            bool canWrite = checker.CheckHisTotalDayMonthly(
                string.Empty, 
                updatingDate,
                out prevTotalDay
            );
            if (!canWrite)
            {
                string message = "�X�V�����O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�o�^�ł��܂���B" + Environment.NewLine + Environment.NewLine;
                message += string.Format("�@�O�񌎎��X�V�� �F {0}", prevTotalDay.ToString("yyyy�NMM��dd��"));

                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                            CT_PGID,
                            message,
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
            }
            return canWrite;
        }

        /// <summary>
		/// ��ʏ�����
		/// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void ClearScreen()
        {
            this._stockBak = null; // ADD 2010/09/06
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.tEdit_SectionCode.Text = string.Empty;
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tNedit_GoodsMakerCd.Text = string.Empty;

            this.tEdit_WarehouseShelfNo.Text = string.Empty;
            this.tEdit_DuplicationShelfNo1.Text = string.Empty;
            this.tEdit_DuplicationShelfNo2.Text = string.Empty;
            this.tComboEditor_StockDiv.SelectedIndex = 0;
            this.tNedit_SupplierCd.Text = string.Empty;
            this.tDateEdit_lastSalesDate.Clear();
            this.tDateEdit_lastStockDate.Clear();
            this.tNedit_PartsManagementDivide1.Text = string.Empty;
            this.tNedit_PartsManagementDivide2.Text = string.Empty;
            this.tEdit_StockNote1.Text = string.Empty;
            this.tEdit_StockNote2.Text = string.Empty;
            this.tNedit_MinimumStockCnt.Text = string.Empty;
            this.tNedit_MaximumStockCnt.Text = string.Empty;
            this.tNedit_SalesOrderUnit.Text = string.Empty;
            this.tNedit_SalesOrderCount.Text = string.Empty;
            this.tNedit_StockUnitPriceRate.Text = string.Empty;
            this.tNedit_StockUnitPriceFl.Text = string.Empty;
            this.tNedit_SupplierStock.Text = string.Empty;

            this.CreateDateTime_tDateEdit.Clear();
            this.UpdateDateTime_tDateEdit.Clear();
            this.tEdit_WarehouseName.Text = string.Empty;
            this.tEdit_SectionName.Text = string.Empty;
            this.GoodsMakerName_tEdit.Text = string.Empty;
            this.tEdit_GoodsName.Text = string.Empty;
            this.tEdit_SupplierName.Text = string.Empty;
            this.tEdit_PartsManagementDivide1Name.Text = string.Empty;
            this.tEdit_PartsManagementDivide2Name.Text = string.Empty;
            this.tNedit_ArrivalCnt.Text = string.Empty;
            this.tNedit_ShipmentCnt.Text = string.Empty;
            this.tNedit_AcpOdrCount.Text = string.Empty;
            this.tNedit_MovingSupliStock.Text = string.Empty;
            this.tNedit_ShipmentPosCnt.Text = string.Empty;

            this.tNedit_PartsManagementDivide1.SetInt(0);
            this.tNedit_PartsManagementDivide2.SetInt(0); 

            this.tNedit_MinimumStockCnt.SetInt(0);
            this.tNedit_MaximumStockCnt.SetInt(0);
            this.tNedit_SalesOrderCount.SetInt(0);
            this.tNedit_SupplierStock.SetInt(0);
            this.tNedit_ArrivalCnt.SetInt(0);
            this.tNedit_ShipmentCnt.SetInt(0);
            this.tNedit_AcpOdrCount.SetInt(0);
            this.tNedit_MovingSupliStock.SetInt(0);
            this.tNedit_ShipmentPosCnt.SetInt(0);

            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
            // --- ADD 2010/09/01 --- >>>>>
            // �Ǘ��敪1�A2�̖��̂������ݒ�
            bool readStatus;
            int code;
            string name;

            // �Ǘ��敪1�̖��̓ǂݍ���
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt(), out code, out name);

            // ���̂��X�V
            if (readStatus)
            {
                tEdit_PartsManagementDivide1Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide1Name.Text = string.Empty;
            }

            // �Ǘ��敪2�̖��̓ǂݍ���
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt(), out code, out name);

            // ���̂��X�V
            if (readStatus)
            {
                tEdit_PartsManagementDivide2Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide2Name.Text = string.Empty;
            }
            // --- ADD 2010/09/01 --- <<<<<

            CreateGrid(); // ADD 2012/12/13 �c���� Redmine#33835
        }

        /// <summary>
        /// ��ʐV�K����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʐV�K�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void NewProc()
        {
            // ��ʂ�����������
            this.ClearScreen();
            this.SettingControlsEnabled(3);
            this.ChangeEditMode(3);

            this._preGoodsNo = string.Empty;
            this._preMakerCode = 0;
            this._preWarehouseCode = string.Empty;
            this._priceValue = 0;
            this._prevStockList = null;
            this.updateTimeDt = new DateTime();

            // �q�ɂփt�H�[�J�X�ړ�
            this.tEdit_WarehouseCode.Focus();
            // --- ADD 2010/09/08 ----->>>>>
            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
            // --- ADD 2010/09/08 -----<<<<<

            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
        }

        /// <summary>
        /// ��ʐV�K����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʐV�K�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: K2021/05/17 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>           : BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή�</br>
        /// </remarks>
        /// <returns></returns>
        private bool SaveProc()
        {
            bool saveFlg = true;

            // ���͓��e���`�F�b�N����
            if (!this.CheckInputScreen())
            {
                saveFlg = false;
                return saveFlg;
            }
                

            // �����X�V��ł���΍݌Ƀf�[�^�̍X�V�͍s���Ȃ�
            if (!CanWrite(DateTime.Now))
            {
                saveFlg = false;
                return saveFlg;
            } 

            // �ۑ�����
            #region �ۑ��f�[�^
            Stock retStock = new Stock();
            retStock.EnterpriseCode = this._enterpriseCode;
            retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
            retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            retStock.SectionCode = tEdit_SectionCode.Text.TrimEnd(); // �Ǘ����_�i���_�j�R�[�h
            retStock.WarehouseShelfNo = tEdit_WarehouseShelfNo.Text.TrimEnd(); // �q�ɒI��
            retStock.DuplicationShelfNo1 = tEdit_DuplicationShelfNo1.Text.TrimEnd(); // �d���I�ԂP
            retStock.DuplicationShelfNo2 = tEdit_DuplicationShelfNo2.Text.TrimEnd(); // �d���I�ԂQ
            retStock.SupplierStock = tNedit_SupplierStock.GetValue(); // �d���݌ɐ�
            retStock.ShipmentPosCnt = tNedit_ShipmentPosCnt.GetValue(); // �o�׉\��(���݌ɐ�)
            retStock.MinimumStockCnt = tNedit_MinimumStockCnt.GetValue(); // �Œ�݌ɐ�
            retStock.MaximumStockCnt = tNedit_MaximumStockCnt.GetValue(); // �ō��݌ɐ�
            retStock.SalesOrderUnit = tNedit_SalesOrderUnit.GetInt(); // �������b�g
            retStock.StockSupplierCode = tNedit_SupplierCd.GetInt(); // ������i�d����j�R�[�h
            // �ŏI�����
            retStock.LastSalesDate = tDateEdit_lastSalesDate.GetDateTime();
            // �ŏI�d����
            retStock.LastStockDate = tDateEdit_lastStockDate.GetDateTime();
            retStock.ArrivalCnt = tNedit_ArrivalCnt.GetValue(); // ���א��i���v��j
            retStock.ShipmentCnt = tNedit_ShipmentCnt.GetValue(); // �o�א��i���v��j
            retStock.AcpOdrCount = tNedit_AcpOdrCount.GetValue(); // �󒍐�
            retStock.MovingSupliStock = tNedit_MovingSupliStock.GetValue(); // �ړ����d���݌ɐ�
            retStock.SalesOrderCount = tNedit_SalesOrderCount.GetValue();   // �����c
            retStock.StockUnitPriceFl = tNedit_StockUnitPriceFl.GetValue(); // �I���]���P��
            retStock.StockNote1 = tEdit_StockNote1.DataText.Trim();         // �݌ɔ��l�P
            retStock.StockNote2 = tEdit_StockNote2.DataText.Trim();         // �݌ɔ��l�Q
            retStock.PartsManagementDivide1 = tNedit_PartsManagementDivide1.GetInt().ToString(); // ���i�Ǘ��敪�P
            retStock.PartsManagementDivide2 = tNedit_PartsManagementDivide2.GetInt().ToString(); // ���i�Ǘ��敪�Q
            retStock.StockDiv = (int)tComboEditor_StockDiv.Value; // �݌ɋ敪
            //-----------------------------
            // ����͍���
            //-----------------------------
            retStock.GoodsNoNoneHyphen = retStock.GoodsNo.Replace("-", "").TrimEnd(); // �n�C�t�����i��

            if (this.updateTimeDt != DateTime.MinValue)
            {
                retStock.UpdateDateTime = this.updateTimeDt;
            }

            DateTime today = DateTime.Today;
            retStock.UpdateDate = today; // �݌ɍX�V��
            if (retStock.UpdateDateTime == DateTime.MinValue)
            {
                retStock.StockCreateDate = today; // �݌ɓo�^��
            }
            #endregion

            string retMessage = string.Empty;
            //int stockSaveStatus = _stockMstAcs.SaveStockInfo(retStock, out retMessage); // DEL 2010/09/01
            // --- ADD 2010/09/01 ---------->>>>>
            List<Rate> rateList = new List<Rate>();

            bool findFlg = false;
            for (int i = 0; i < this._goodsUnitData.StockList.Count; i++)
            {
                if (this.tEdit_WarehouseCode.Text.Equals(this._goodsUnitData.StockList[i].WarehouseCode))
                {
                    Stock stock = this._goodsUnitData.StockList[i];
                    this.copyProterty(ref stock, retStock);
                    this._goodsUnitData.StockList[i] = stock;
                    findFlg = true;
                    break;
                }
            }
            if (!findFlg)
            {
                // --- ADD 2010/09/06 ---------->>>>>
                if (this._stockBak != null) {
                    this.copyProterty(ref this._stockBak, retStock);
                    this._goodsUnitData.StockList.Add(this._stockBak);
                } else 
                {
                // --- ADD 2010/09/06 ----------<<<<<
                    this._goodsUnitData.StockList.Add(retStock);
                } // ADD 2010/09/06
            }
            // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� ----->>>>>
            //�X�V���O�̑q�ɏ���ێ�����B
            List<Stock> bkStockList = new List<Stock>();
            foreach (Stock stock in _goodsUnitData.StockList)
            {
                bkStockList.Add(stock.Clone());
            }
            // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� -----<<<<<
            //int stockSaveStatus = this._goodsAcs.Write(ref this._goodsUnitData, this._prevStockList, ref rateList, out retMessage);   // DEL huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��
            // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
            int stockSaveStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            if (retStock.ShipmentCnt.Equals(this._preShipmentCnt))
            {
                stockSaveStatus = this._goodsAcs.Write(ref this._goodsUnitData, this._prevStockList, ref rateList, out retMessage);
            }
            else
            {
                stockSaveStatus = this._goodsAcs.WriteForShipmentCnt(ref this._goodsUnitData, this._prevStockList, ref rateList, out retMessage);
            }
            // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<
            // --- ADD 2010/09/01 ----------<<<<<

            #region < �o�^�㏈�� >
            switch (stockSaveStatus)
            {
                #region -- �ʏ�I�� --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // --- ADD 2010/09/01 ------------------>>>>>
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    // --- ADD 2010/09/01 ------------------<<<<<

                    // ��ʂ�����������
                    this.ClearScreen();
                    this.SettingControlsEnabled(3);
                    this.ChangeEditMode(3);

                    this._preGoodsNo = string.Empty;
                    this._preMakerCode = 0;
                    this._preWarehouseCode = string.Empty;
                    this._prevStockList = null;
                    this.updateTimeDt = new DateTime();

                    // �q�ɂփt�H�[�J�X�ړ�
                    this.tEdit_WarehouseCode.Focus();
                    // --- ADD 2010/09/08 ----->>>>>
                    this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                    // --- ADD 2010/09/08 -----<<<<<

                    this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

                    // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
                    tNedit_ShipmentCnt.Enabled = false;
                    tNedit_ShipmentCnt.Appearance.BackColor = BACKCOLOR_DISABLE;
                    this._preShipmentCnt = 0;
                    // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<

                    break;

                // �d���G���[
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �R�[�h�d��
                    TMsgDisp.Show(
                        this, 									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                        CT_PGID,				        		// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",  	// �\�����郁�b�Z�[�W
                        0, 										// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                    break;
                #endregion

                #region -- �r������ --
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(stockSaveStatus, true);
                    saveFlg = false;
                    break;
                #endregion

                #region -- �o�^���s --
                default:
                    TMsgDisp.Show(
                        this,                                 // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        CT_PGNM,                                // �v���O��������
                        "SaveProc",                           // ��������
                        TMsgDisp.OPE_UPDATE,                  // �I�y���[�V����
                        "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                        stockSaveStatus,                      // �X�e�[�^�X�l
                        this._stockMstAcs,                    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,                 // �\������{�^��
                        MessageBoxDefaultButton.Button1);     // �����\���{�^��
                    saveFlg = false;
                    break;
                #endregion
            }
            #endregion
            // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� ----->>>>>
            //�X�V���s�̏ꍇ
            if (stockSaveStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //�X�V���O�̑q�ɏ��ɖ߂�
                this._goodsUnitData.StockList = bkStockList;
            }
            // --- ADD K2021/05/17 杍^ BLINCIDENT-3025 ���ݐ���0�ɂȂ�Ή� -----<<<<<

            return saveFlg;
        }

        /// <summary>
		/// ��ʕ���O�̃`�F�b�N
		/// </summary>
        /// <remarks>
        /// <br>Note       : ��ʕ���O�̃`�F�b�N�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool CloseCheck()
        {
            bool closeFlg = true;

            if (NEW_INPUT_TITLE.Equals(this.uLabel_InputModeTitle.Text)
                || UPDATE_INPUT_TITLE.Equals(this.uLabel_InputModeTitle.Text))
            {
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim())) return false;
                if (this.tNedit_GoodsMakerCd.GetInt() != 0) return false;
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseShelfNo.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_DuplicationShelfNo1.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_DuplicationShelfNo2.Text.Trim())) return false;
                if (this.tComboEditor_StockDiv.SelectedIndex != 0) return false;
                if (this.tNedit_SupplierCd.GetInt() != 0) return false;
                if (this.tDateEdit_lastSalesDate.GetDateTime() != DateTime.MinValue) return false;
                if (this.tDateEdit_lastStockDate.GetDateTime() != DateTime.MinValue) return false;
                if (this.tNedit_PartsManagementDivide1.GetInt() != 0) return false;
                if (this.tNedit_PartsManagementDivide2.GetInt() != 0) return false;
                if (!string.IsNullOrEmpty(this.tEdit_StockNote1.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_StockNote2.Text.Trim())) return false;
                if (this.tNedit_MinimumStockCnt.GetInt() != 0) return false;
                if (this.tNedit_MaximumStockCnt.GetInt() != 0) return false;
                if (this.tNedit_SalesOrderUnit.GetInt() != 0) return false;
                if (this.tNedit_SalesOrderCount.GetInt() != 0) return false;
                if (this.tNedit_StockUnitPriceRate.GetInt() != 0) return false;
                if (this.tNedit_StockUnitPriceFl.GetInt() != 0) return false;
                if (this.tNedit_SupplierStock.GetInt() != 0) return false;
                
            }
            return closeFlg;
        }

        /// <summary>
		/// �݌ɏ��ˉ��
		/// </summary>
        /// <param name="warehouseCodeStr">�q�ɃR�[�h</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �݌ɏ��ˉ�ʏ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2010/09/01 �k���r #14025��4�̑Ή��B</br>
        /// </remarks>
        private void GetStockFromStockWarehouse(string warehouseCodeStr, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //-----ADD 2010/09/08---------->>>>>
            int dialogFlag = 0;
            //-----ADD 2010/09/08----------<<<<<
            foreach (Stock stock in this._prevStockList)
            {
                //-----ADD 2010/09/08---------->>>>>
                if (dialogFlag != 2)
                {
                    dialogFlag = 1;
                }
                //-----ADD 2010/09/08----------<<<<<
                if (warehouseCodeStr.Equals(stock.WarehouseCode.Trim()))
                {
                    this._stockBak = stock.Clone(); // ADD 2010/09/06
                    // �_���폜�敪 = 0:�L��
                    if (stock.LogicalDeleteCode == 0)
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_QUESTION,
                                        this.Name,
                                        "���͂��ꂽ�i�Ԃ͍݌Ƀ}�X�^�Ɋ��ɓo�^����Ă��܂��B" + "\r\n" + "\r\n" +
                                        "�ҏW���s���܂����H",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);

                        switch (dialogResult)
                        {
                            case (DialogResult.Yes):
                                {
                                    this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;
                                    this.SetScreenFromStock(stock);

                                    this.SettingControlsEnabled(2);
                                    this.ChangeEditMode(2);
                                    break;
                                }
                            case (DialogResult.No):
                                {
                                    //-----UPD 2010/09/01---------->>>>>
                                    //e.NextCtrl = tNedit_GoodsMakerCd;
                                    string sectionCode = this.tEdit_SectionCode.Text;
                                    string sectionName = this.tEdit_SectionName.Text;
                                    string warehouseName = this.tEdit_WarehouseName.Text;
                                    // ��ʂ�����������
                                    this.ClearScreen();
                                    this.SettingControlsEnabled(3);
                                    this.ChangeEditMode(3);

                                    this.tEdit_WarehouseCode.Text = warehouseCodeStr;
                                    this.tEdit_WarehouseName.Text = warehouseName;
                                    this.tEdit_SectionName.Text = sectionName;
                                    this.tEdit_SectionCode.Text = sectionCode;

                                    this._preGoodsNo = string.Empty;
                                    this._preMakerCode = 0;
                                    this._preWarehouseCode = string.Empty;
                                    this._prevStockList = null;
                                    this.updateTimeDt = new DateTime();

                                    // �i�Ԃփt�H�[�J�X�ړ�
                                    e.NextCtrl = tEdit_GoodsNo;
                                    this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
                                    //-----UPD 2010/09/01---------->>>>>
                                    //-----ADD 2010/09/08---------->>>>>
                                    dialogFlag = 2;
                                    //-----ADD 2010/09/08----------<<<<<
                                    break;
                                }
                        }
                    }
                    // �_���폜�敪 = 1:�_���폜
                    else if (stock.LogicalDeleteCode == 1)
                    {
                        this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;
                        this.SetScreenFromStock(stock);

                        
                        this.SettingControlsEnabled(1);

                        this.tNedit_StockUnitPriceRate.Enabled = true;
                        this.tNedit_SupplierStock.Enabled = true;

                        this.tNedit_StockUnitPriceRate.Focus();

                        this.tNedit_SupplierStock.Enabled = false;
                        this.tNedit_StockUnitPriceRate.Enabled = false;
                        

                        this.ChangeEditMode(1);

                        DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���͂��ꂽ�i�Ԃ͍݌Ƀ}�X�^����폜����Ă��܂��B" + "\r\n" + "\r\n",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                    }
                }
                //-----ADD 2010/09/08---------->>>>>
                if (dialogFlag == 0 || dialogFlag == 1)
                {
                    e.NextCtrl = this.tEdit_WarehouseShelfNo;
                }
                //-----ADD 2010/09/08----------<<<<<
            }
            //-----ADD 2010/09/08---------->>>>>
            if (dialogFlag == 0)
            {
                e.NextCtrl = this.tEdit_WarehouseShelfNo;
            }
            //-----ADD 2010/09/08----------<<<<<
        }

        /// <summary>
		/// ��ʓ��̓`�F�b�N
		/// </summary>
        /// <remarks>
        /// <br>Note       : ��ʓ��̓`�F�b�N�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckInputScreen()
        {
            bool checkFlg = true;

            // �q�ɂ𖢓��͂���ꍇ�A�G���[�Ƃ���B
            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�q�ɂ���͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tEdit_WarehouseCode.Focus();
                // --- ADD 2010/09/08 ----->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
                return checkFlg;
            }

            // �Ǘ����_�𖢓��͂���ꍇ�A�G���[�Ƃ���B
            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���_����͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tEdit_SectionCode.Focus();
                return checkFlg;
            }

            // �i�Ԃ𖢓��͂���ꍇ�A�G���[�Ƃ���B
            if (string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�i�Ԃ���͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tEdit_GoodsNo.Focus();
                return checkFlg;
            }

            // Ұ���𖢓��͂���ꍇ�A�G���[�Ƃ���B
            if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "Ұ������͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tNedit_GoodsMakerCd.Focus();
                // --- ADD 2010/09/08 ----->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
                return checkFlg;
            }

            // �Œ�݌ɐ����ő�݌ɐ��`�F�b�N
            if (this.tNedit_MinimumStockCnt.GetValue() > this.tNedit_MaximumStockCnt.GetValue())
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�Œ�݌ɐ����ő�݌ɐ��ƂȂ�悤�ɓ��͂��ĉ������B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tNedit_MaximumStockCnt.Focus();
                return checkFlg;
            }

            // �ŏI�����
            if (_dateGet.CheckDate(ref tDateEdit_lastSalesDate, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�ŏI��������s���ł��B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tDateEdit_lastSalesDate.Focus();
                return checkFlg;
            }
            // �ŏI�d����
            if (_dateGet.CheckDate(ref tDateEdit_lastStockDate, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�ŏI�d�������s���ł��B",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tDateEdit_lastStockDate.Focus();
                return checkFlg;
            }

            return checkFlg;
        }

        /// <summary>
        /// �q��(+�Ǘ����_)�ǂݍ���
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="code">�R�[�h</param>
        /// <param name="name">����</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_����</param>
        /// <remarks>
        /// <br>Note       : �q��(+�Ǘ����_)�ǂݍ��ݏ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool ReadWarehouseWithSection(string warehouseCode, out string code, out string name, out string sectionCode, out string sectionName)
        {
            bool result = false;

            sectionCode = string.Empty;
            sectionName = string.Empty;


            // �����͔���
            if (warehouseCode != string.Empty)
            {
                // �ǂݍ���
                if (_warehouseAcs == null)
                {
                    _warehouseAcs = new WarehouseAcs();
                }
                Warehouse warehouse;
                int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCode);

                if (status == 0 && warehouse != null && warehouse.LogicalDeleteCode == 0)
                {
                    // �Y�����聨�\��
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName.TrimEnd();

                    // ���_�ǂݍ���
                    ReadSection(warehouse.SectionCode, out sectionCode, out sectionName);

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// ���[�J�[�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void GoodsMakerGuide_uButton_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status != 0) return;

            // ���[�J�[�R�[�h�ɕύX�����邩
            if (this.tNedit_GoodsMakerCd.GetInt() != makerUMnt.GoodsMakerCd)
            {
                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                this._preMakerCode = makerUMnt.GoodsMakerCd;

                if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()))
                {
                    // ���i����������
                    GoodsUWork goodsUWork;

                    this._stockMstAcs.SearchGoodsUInfo(_enterpriseCode, this.tEdit_GoodsNo.Text.Trim(), makerUMnt.GoodsMakerCd, out goodsUWork);

                    if (goodsUWork != null)
                    {
                        this.tEdit_GoodsName.Text = goodsUWork.GoodsName;
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                CT_PGID,
                                                "���i�}�X�^�����o�^�ł��B",
                                                0,
                                                MessageBoxButtons.OK,
                                                MessageBoxDefaultButton.Button1);


                        this.tNedit_GoodsMakerCd.Text = string.Empty;
                        this.GoodsMakerName_tEdit.Text = string.Empty;
                        this._preMakerCode = 0;
                        //-----UPD 2010/09/01---------->>>>>
                        //GoodsMakerGuide_uButton.Focus();
                        //this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;

                        if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.tNedit_GoodsMakerCd.Focus();
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                        }
                        else if (GoodsMakerGuide_uButton.Focused)
                        {
                            GoodsMakerGuide_uButton.Focus();
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                        }
                        //-----UPD 2010/09/01----------<<<<<

                        this.tEdit_GoodsName.Text = string.Empty;

                        return;
                    }
                }
                else
                {
                    this.tEdit_GoodsNo.Focus();
                    //-----ADD 2010/09/01---------->>>>>
                    this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                    //-----ADD 2010/09/01----------<<<<<
                }
            }
            //-----ADD 2010/09/08---------->>>>>
            else
            {
                this.tEdit_WarehouseShelfNo.Focus();
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
            }
            //-----ADD 2010/09/08----------<<<<<
        }

        /// <summary>
        /// �q�ɃR�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2010/09/01 �k���r #14025��4�̑Ή��B</br>
        /// </remarks> 
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            // �A�N�Z�X�N���X�C���X�^���X����
            if (_warehouseAcs == null)
            {
                _warehouseAcs = new WarehouseAcs();
            }

            // �K�C�h���s
            Warehouse warehouse;
            int status = _warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);

            // ���ʔ��f
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && warehouse != null)
            {
                if (warehouse.WarehouseCode.Trim() != this.tEdit_WarehouseCode.Text.Trim())
                {
                    string code;
                    string name;
                    string sectionCode;
                    string sectionName;

                    // �q��(+�Ǘ����_)�ǂݍ���
                    bool readStatus = ReadWarehouseWithSection(warehouse.WarehouseCode.Trim(), out code, out name, out sectionCode, out sectionName);

                    // �R�[�h�E���̂��X�V
                    tEdit_WarehouseCode.Text = code;
                    tEdit_WarehouseName.Text = name;

                    tEdit_SectionCode.Text = sectionCode;
                    tEdit_SectionName.Text = sectionName;

                    string warehouseCodeStr = warehouse.WarehouseCode.Trim();

                    if (this._prevStockList != null && this._prevStockList.Count > 0)
                    {
                        foreach (Stock stock in this._prevStockList)
                        {
                            if (warehouseCodeStr.Equals(stock.WarehouseCode.Trim()))
                            {

                                // �_���폜�敪 = 0:�L��
                                if (stock.LogicalDeleteCode == 0)
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "���͂��ꂽ�i�Ԃ͍݌Ƀ}�X�^�Ɋ��ɓo�^����Ă��܂��B" + "\r\n" + "\r\n" +
                                                    "�ҏW���s���܂����H",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                                    switch (dialogResult)
                                    {
                                        case (DialogResult.Yes):
                                            {
                                                this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;
                                                this.SetScreenFromStock(stock);

                                                this.SettingControlsEnabled(2);
                                                this.ChangeEditMode(2);
                                                break;
                                            }
                                        case (DialogResult.No):
                                            {
                                                //-----UPD 2010/09/01---------->>>>>
                                                //this.tEdit_WarehouseCode.Focus();
                                                string sectionCodeStr = this.tEdit_SectionCode.Text;
                                                string sectionNameStr = this.tEdit_SectionName.Text;
                                                string warehouseName = this.tEdit_WarehouseName.Text;
                                                // ��ʂ�����������
                                                this.ClearScreen();
                                                this.SettingControlsEnabled(3);
                                                this.ChangeEditMode(3);

                                                this.tEdit_WarehouseCode.Text = warehouseCodeStr;
                                                this.tEdit_WarehouseName.Text = warehouseName;
                                                this.tEdit_SectionName.Text = sectionNameStr;
                                                this.tEdit_SectionCode.Text = sectionCodeStr;

                                                this._preGoodsNo = string.Empty;
                                                this._preMakerCode = 0;
                                                this._preWarehouseCode = string.Empty;
                                                this._prevStockList = null;
                                                this.updateTimeDt = new DateTime();

                                                // �i�Ԃփt�H�[�J�X�ړ�
                                                this.tEdit_GoodsNo.Focus();
                                                this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
                                                //-----UPD 2010/09/01---------->>>>>
                                                return;
                                            }
                                    }
                                }
                                // �_���폜�敪 = 1:�_���폜
                                else if (stock.LogicalDeleteCode == 1)
                                {
                                    this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;
                                    this.SetScreenFromStock(stock);

                                    this.SettingControlsEnabled(1);
                                    this.ChangeEditMode(1);
                                }
                            }
                        }
                    }

                    if (this.tEdit_GoodsNo.Enabled != false)
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/09/08---------->>>>>
                        this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                        //-----ADD 2010/09/08----------<<<<<
                    }
                    else if (this.tEdit_WarehouseShelfNo.Enabled != false)
                    {
                        this.tEdit_WarehouseShelfNo.Focus();
                        //-----ADD 2010/09/08---------->>>>>
                        this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                        //-----ADD 2010/09/08----------<<<<<
                    }
                }
                //-----ADD 2010/09/08---------->>>>>
                else
                {
                    this.tEdit_GoodsNo.Focus();
                    this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                }
                //-----ADD 2010/09/08----------<<<<<
            }
        }

        /// <summary>
        /// ���_�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // �A�N�Z�X�N���X�C���X�^���X����
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            // �K�C�h���s
            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            // ���ʔ��f
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && secInfoSet != null)
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.TrimEnd();
                tEdit_SectionName.Text = secInfoSet.SectionGuideNm.TrimEnd();

                //-----ADD 2010/09/08---------->>>>>
                // �t�H�[�J�X�ړ�(������)
                //tEdit_WarehouseShelfNo.Focus();
                if (tEdit_GoodsNo.Enabled)
                {
                    tEdit_GoodsNo.Focus();
                }
                else
                {
                    tEdit_WarehouseShelfNo.Focus();
                }
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                //-----ADD 2010/09/08----------<<<<<
            }
            else
            {
                // �t�H�[�J�X�ړ�(�ړ����Ȃ�)
            }
        }

        /// <summary>
        /// ������R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ������R�[�h�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // �A�N�Z�X�N���X�C���X�^���X����
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }

            // �K�C�h���s
            Supplier supplier;
            int status = _supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);

            // ���ʔ��f
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && supplier != null)
            {
                tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                tEdit_SupplierName.Text = supplier.SupplierNm1.TrimEnd();

                // �t�H�[�J�X�ړ�(������)
                this.tDateEdit_lastSalesDate.Focus();
                //-----ADD 2010/09/08---------->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                //-----ADD 2010/09/08----------<<<<<
            }
            else
            {
                // �t�H�[�J�X�ړ�(�ړ����Ȃ�)
            }
        }

        /// <summary>
        /// �Ǘ��敪�P�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       :�Ǘ��敪�P�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_PartsManagementDivide1_Click(object sender, EventArgs e)
        {
            // �A�N�Z�X�N���X�C���X�^���X����
            if (_userGuideAcs == null)
            {
                _userGuideAcs = new UserGuideAcs();
            }

            // �ǂݍ���
            UserGdHd userGdHd;
            UserGdBd userGdBd;
            int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, ct_UserGdDiv_PartsManagementDivide1);

            // ���ʔ��f
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ���ʃZ�b�g
                tNedit_PartsManagementDivide1.SetInt(userGdBd.GuideCode);
                tEdit_PartsManagementDivide1Name.Text = userGdBd.GuideName.TrimEnd();

                // �t�H�[�J�X�ړ�(������)
                tNedit_PartsManagementDivide2.Focus();
                // --- ADD 2010/09/08 ----->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
            }
            else
            {
                // �t�H�[�J�X�ړ�(�ړ����Ȃ�)
            }
        }

        /// <summary>
        /// �Ǘ��敪�Q�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       :�Ǘ��敪�Q�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_PartsManagementDivide2_Click(object sender, EventArgs e)
        {
            // �A�N�Z�X�N���X�C���X�^���X����
            if (_userGuideAcs == null)
            {
                _userGuideAcs = new UserGuideAcs();
            }

            // �ǂݍ���
            UserGdHd userGdHd;
            UserGdBd userGdBd;
            int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, ct_UserGdDiv_PartsManagementDivide2);

            // ���ʔ��f
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ���ʃZ�b�g
                tNedit_PartsManagementDivide2.SetInt(userGdBd.GuideCode);
                tEdit_PartsManagementDivide2Name.Text = userGdBd.GuideName.TrimEnd();

                // �t�H�[�J�X�ړ�(������)
                // --- UPD 2010/09/01 ------------------>>>>>
                //tComboEditor_StockDiv.Focus();
                this.tEdit_StockNote1.Focus();
                // --- UPD 2010/09/01 ------------------<<<<<
                //-----ADD 2010/09/08---------->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                //-----ADD 2010/09/08----------<<<<<
            }
            else
            {
                // �t�H�[�J�X�ړ�(�ړ����Ȃ�)
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ�r���������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            CT_PGID, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            CT_PGID, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// ���݌ɐ��Z�o����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���݌ɐ��Z�o�������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2011/08/29 wangf �A��1016�̑Ή�</br>
        /// </remarks>
        private void tNedit_SupplierStock_ValueChanged(object sender, EventArgs e)
        {
            /* -- del wangf 2011/08/29 ---------->>>>>
            tNedit_ShipmentPosCnt.SetValue(_shipmentPosCountOrigin + tNedit_SupplierStock.GetValue()
                                                                   + tNedit_ArrivalCnt.GetValue()
                                                                   - tNedit_ShipmentCnt.GetValue()
                                                                   - tNedit_AcpOdrCount.GetValue()
                                                                   - tNedit_MovingSupliStock.GetValue());
            // -- del wangf 2011/08/29 ----------<<<<<*/
            // -- add wangf 2011/08/29 ---------->>>>>
            // �݌ɊǗ��S�̐ݒ�́u���݌ɕ\���敪�v�ɂ��A�󒍐��͎Z�o�����ǉ��̔��f
            if (this._stockMngTtlStAcs == null)
            {
                this._stockMngTtlStAcs = new StockMngTtlStAcs();
            }
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
            this._stockMngTtlStAcs.Read(out stockMngTtlSt, this._enterpriseCode);
            if (stockMngTtlSt.PreStckCntDspDiv == 0)
            {
                // �󒍕��܂�
                tNedit_ShipmentPosCnt.SetValue(_shipmentPosCountOrigin + tNedit_SupplierStock.GetValue()
                                                                       + tNedit_ArrivalCnt.GetValue()
                                                                       - tNedit_ShipmentCnt.GetValue()
                                                                       - tNedit_AcpOdrCount.GetValue()
                                                                       - tNedit_MovingSupliStock.GetValue());
            }
            else
            {
                // �󒍕��܂܂Ȃ�
                tNedit_ShipmentPosCnt.SetValue(_shipmentPosCountOrigin + tNedit_SupplierStock.GetValue()
                                                                       + tNedit_ArrivalCnt.GetValue()
                                                                       - tNedit_ShipmentCnt.GetValue()
                                                                       - tNedit_MovingSupliStock.GetValue());
            }
            // -- add wangf 2011/08/29 ----------<<<<<
        }

        /// <summary>
        /// tEdit_DuplicationShelfNo1_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : tEdit_DuplicationShelfNo1_KeyPress�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void tEdit_DuplicationShelfNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo1.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo1.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo1.Text.Length - (this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_DuplicationShelfNo2_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : tEdit_DuplicationShelfNo2_KeyPress�C�x���g�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void tEdit_DuplicationShelfNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo2.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo2.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo2.Text.Length - (this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        // --- ADD 2010/09/01 ---------->>>>>
        /// <summary>
        /// copyProterty
        /// </summary>
        /// <param name="toStock"></param>
        /// <param name="fromStock"></param>
        /// <remarks>
        /// <br>Note       : copyProterty</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/09/01</br>
        /// </remarks>
        private void copyProterty(ref Stock toStock, Stock fromStock)
        {
            toStock.EnterpriseCode = fromStock.EnterpriseCode;
            toStock.WarehouseCode = fromStock.WarehouseCode;
            toStock.GoodsNo = fromStock.GoodsNo;
            toStock.GoodsMakerCd = fromStock.GoodsMakerCd;

            toStock.SectionCode = fromStock.SectionCode; // �Ǘ����_�i���_�j�R�[�h
            toStock.WarehouseShelfNo = fromStock.WarehouseShelfNo; // �q�ɒI��
            toStock.DuplicationShelfNo1 = fromStock.DuplicationShelfNo1; // �d���I�ԂP
            toStock.DuplicationShelfNo2 = fromStock.DuplicationShelfNo2; // �d���I�ԂQ
            toStock.SupplierStock = fromStock.SupplierStock; // �d���݌ɐ�
            toStock.ShipmentPosCnt = fromStock.ShipmentPosCnt; // �o�׉\��(���݌ɐ�)
            toStock.MinimumStockCnt = fromStock.MinimumStockCnt; // �Œ�݌ɐ�
            toStock.MaximumStockCnt = fromStock.MaximumStockCnt; // �ō��݌ɐ�
            toStock.SalesOrderUnit = fromStock.SalesOrderUnit; // �������b�g
            toStock.StockSupplierCode = fromStock.StockSupplierCode; // ������i�d����j�R�[�h
            // �ŏI�����
            toStock.LastSalesDate = fromStock.LastSalesDate;
            // �ŏI�d����
            toStock.LastStockDate = fromStock.LastStockDate;
            toStock.ArrivalCnt = fromStock.ArrivalCnt; // ���א��i���v��j
            toStock.ShipmentCnt = fromStock.ShipmentCnt; // �o�א��i���v��j
            toStock.AcpOdrCount = fromStock.AcpOdrCount; // �󒍐�
            toStock.MovingSupliStock = fromStock.MovingSupliStock; // �ړ����d���݌ɐ�
            toStock.SalesOrderCount = fromStock.SalesOrderCount;   // �����c
            toStock.StockUnitPriceFl = fromStock.StockUnitPriceFl; // �I���]���P��
            toStock.StockNote1 = fromStock.StockNote1;         // �݌ɔ��l�P
            toStock.StockNote2 = fromStock.StockNote2;         // �݌ɔ��l�Q
            toStock.PartsManagementDivide1 = fromStock.PartsManagementDivide1; // ���i�Ǘ��敪�P
            toStock.PartsManagementDivide2 = fromStock.PartsManagementDivide2; // ���i�Ǘ��敪�Q
            toStock.StockDiv = fromStock.StockDiv; // �݌ɋ敪
            //-----------------------------
            // ����͍���
            //-----------------------------
            toStock.GoodsNoNoneHyphen = fromStock.GoodsNoNoneHyphen; // �n�C�t�����i��

            toStock.UpdateDateTime = fromStock.UpdateDateTime;

            toStock.UpdateDate = fromStock.UpdateDate; // �݌ɍX�V��
        }
        // --- ADD 2010/09/01 ----------<<<<<

        #endregion

        // --- ADD 2010/09/08 ----->>>>>
        #region  �K�C�h�N������
        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �K�C�h�N������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/09/08</br>
        /// </remarks>
        public void ExecuteGuide()
        {
            if (this.tEdit_WarehouseCode.Focused)
            {
                this.uButton_WarehouseGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_SectionCode.Focused)
            {
                this.uButton_SectionGuide_Click(this, new EventArgs());
            }
            else if (this.tNedit_GoodsMakerCd.Focused)
            {
                this.GoodsMakerGuide_uButton_Click(this, new EventArgs());
            }
            else if (this.tNedit_SupplierCd.Focused)
            {
                this.uButton_SupplierGuide_Click(this, new EventArgs());
            }
            else if (this.tNedit_PartsManagementDivide1.Focused)
            {
                this.uButton_PartsManagementDivide1_Click(this, new EventArgs());
            }
            else if (this.tNedit_PartsManagementDivide2.Focused)
            {
                this.uButton_PartsManagementDivide2_Click(this, new EventArgs());
            }
        }
        #endregion
        // --- ADD 2010/09/08 -----<<<<<

        // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
        /// <summary>
        /// ���[�J�[�ݒ�
        /// </summary>
        /// <param name="maker">���[�J�[</param>
        /// <param name="data">���i�A���f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[ �� ���i�A���f�[�^���s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/04 NS���[�U�[���Ǘv�]�ꗗ�A��513�A520�̑Ή�</br>
        /// </remarks>
        private void SetGoodsUnitDataFromMaker(MakerUMnt makerUMnt, ref GoodsUnitData data)
        {
            if (makerUMnt != null)
            {
                data.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                data.MakerName = makerUMnt.MakerName;

                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
            }
            else
            {
                this.tNedit_GoodsMakerCd.SetInt(data.GoodsMakerCd);
                this.GoodsMakerName_tEdit.DataText = data.MakerName;
            }
        }
        // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
    }

    //----- ADD 2012/12/13 �c���� Redmine#33835 ------------------------------------->>>>>
    /// <summary>
    /// Grid�̃t�H�[�J�X��`���I�t����
    /// </summary>
    /// <remarks>
    /// <br>Note       : Grid�̃t�H�[�J�X��`���I�t����B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2012/12/13</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// </remarks>
    public class NoFocusRect : Infragistics.Win.IUIElementDrawFilter
    {
        #region Implementation of IUIElementDrawFilter
        public bool DrawElement(Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams)
        {
            return true;
        }
        public Infragistics.Win.DrawPhase GetPhasesToFilter(ref Infragistics.Win.UIElementDrawParams drawParams)
        {
            return Infragistics.Win.DrawPhase.BeforeDrawFocus;
        }
        #endregion
    }
    //----- ADD 2012/12/13 �c���� Redmine#33835 -------------------------------------<<<<<
}