//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_��������
// �v���O�����T�v   : �}�c�_�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �����
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//                                  �}�c�_WebUOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^����}�c�_�p�V�X�e���A�g�A�h���X�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/12/02  �C�����e : Redmine#8304�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections.Generic;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �}�c�_��������UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �}�c�_��������UI�t�H�[���N���X</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2011/05/18</br>
    /// </remarks>
    public partial class PMUOE01541UA : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        ///  �}�c�_���������t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �}�c�_���������t�H�[���N���X �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/05/18</br>
        /// </remarks>
        public PMUOE01541UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._detailInput = new PMUOE01541UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._retryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];

            this._controlScreenSkin = new ControlScreenSkin();
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._uoeSupplierAcs = new UOESupplierAcs();
        }

        # endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region Const Members
        //�Ɩ��敪
        private const Int32 ctTerminalDiv_Order = 1;	//����
        private const Int32 ctTerminalDiv_Cancel = 2;//�������

        //�[���ԍ��敪
        private const Int32 ctTerminalNoDiv_Own = 0;	//���[��
        private const Int32 ctTerminalNoDiv_Other = 1;	//���[��
        private const Int32 ctTerminalNoDiv_All = 2;	//�S�[��

        //�V�X�e���敪
        private const Int32 ctSysDiv_Input = 0;	//�����
        private const Int32 ctSysDiv_Slip = 1;	//�`������
        private const Int32 ctSysDiv_Srch = 2;	//��������
        private const Int32 ctSysDiv_Stock = 3;	//�݌Ɉꊇ

        //���̓��b�Z�[�W
        private const string MESSAGE_SupplierCd = "�������I�����ĉ������B";
        private const string MESSAGE_TerminalDiv = "�Ɩ��敪��I�����ĉ������B";
        private const string MESSAGE_TerminalNoDiv = "�[���敪��I�����ĉ������B";
        private const string MESSAGE_TerminalNo = "�[���ԍ�����͂��ĉ������B";
        private const string MESSAGE_SysDiv = "�V�X�e���敪��I�����ĉ������B";
        private const string MESSAGE_St_OnlineNo = "�ďo�ԍ�(�J�n)����͂��ĉ������B";
        private const string MESSAGE_Ed_OnlineNo = "�ďo�ԍ�(�I��)����͂��ĉ������B";
        private const string MESSAGE_InputDateSt = "���͓�(�J�n)����͂��ĉ������B";
        private const string MESSAGE_InputDateEd = "���͓�(�I��)����͂��ĉ������B";
        private const string MESSAGE_CustomerCode = "���Ӑ����͂��ĉ������B";

        private const string MESSAGE_NoPass = "�񓚕ۑ��t�H���_�������͂ł��BUOE������}�X�^�̐ݒ�����m�F���������B";
        private const string MESSAGE_PassError = "�񓚕ۑ��t�H���_�����݂��܂���BUOE������}�X�^�̐ݒ�����m�F���������B";
        private const string MESSAGE_ExclusiveError = "�ʒ[���Ŕ����������ł��B";
        //�}�c�_
        private const string key = "0403";
        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMUOE01541U";
        // �ő喾�א�
        private const int MAX_DETAILCOUNT = 30;
        // �ő�u���b�N��
        private const int MAX_BLOCCOUNT = 30;
        // �ő�UOE�����s�ԍ�
        private const int MAX_UOEORDERDTLNO = 5;
        //�}�c�_(����)
        private const string autoKey = "0403";
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private PMUOE01541UB _detailInput;
        private ImageList _imageList16 = null;                                                // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // �m��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;                    // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // �����{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;              // ���O�C���S���Җ���
        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private UOESupplierAcs _uoeSupplierAcs;                                     //�t�n�d������A�N�Z�X�N���X
        //�t�n�d������
        private List<UOESupplier> _uoeSupplier01521;
        private UOEConnectInfo _uOEConnectInfo;// UOE�ڑ�����}�X�^
        //���Ӑ�}�X�^
        private Dictionary<int, CustomerSearchRet> _customerSearchRet;
        //��ʓ��̓N���X
        private MazdaInpDisplay _inpDisplay;
        //�[���ԍ�
        int _cashRegisterNo;
        //�}�c�_���������A�N�Z�X�N���X
        private MazdaOrderProcAcs _detailInputAcs;

        private bool buttonDisFlg = true;

        // �O�񔭒���
        private Int32 _bfSupplier = 0;

        // ��ʕ���t���O
        private string mitsubishiFlod = string.Empty;
        private UOESupplier _uoeSupplier = null;
        private int inqOrdDivCd = 0;
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods

        # region �� �����ݒ�֘A ��
        # region �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            //tToolbarsManager_MainMenu
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            //ImageList
            this.uButton_CustomerGuide.ImageList = this._imageList16;

            //Appearance.Image
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion �� �{�^�������ݒ菈�� ��

        #region �����f�[�^�擾����
        /// <summary>
        /// �����f�[�^�擾����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����f�[�^�擾�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>r>
        /// </remarks>
        public void ReadInitData()
        {
            //-----------------------------------------------------------
            // �t�n�d������L���b�V������
            //-----------------------------------------------------------
            this.CacheUOESupplier_01521();

            //-----------------------------------------------------------
            // ���Ӑ�}�X�^�L���b�V������
            //-----------------------------------------------------------
            this.CacheCustomerSearch();

            //-----------------------------------------------------------
            // �]�ƈ��}�X�^�L���b�V������
            //-----------------------------------------------------------
            this.CacheEmployee();

            //-----------------------------------------------------------
            // �[���Ǘ��ݒ�(���[���ԍ����擾)
            //-----------------------------------------------------------
            int cashRegisterNo = 0;
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            int status = posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._cashRegisterNo = cashRegisterNo;
            }
        }

        /// <summary>
        /// �t�n�d��������L���b�V�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�n�d��������L���b�V�����䏈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheUOESupplier_01521()
        {
            _uoeSupplier01521 = new List<UOESupplier>();
            List<UOESupplier> resultList = new List<UOESupplier>();
            try
            {
                ArrayList retList;
                int status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._loginSectionCode.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UOESupplier uoeSupplier in retList)
                    {
                        if (uoeSupplier.LogicalDeleteCode == 0)
                        {
                            resultList.Add(uoeSupplier);
                        }
                    }
                }

                resultList = resultList.FindAll(delegate(UOESupplier target)
                {
                    if (key.Equals(target.CommAssemblyId) || autoKey.Equals(target.CommAssemblyId))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (resultList != null && resultList.Count > 0)
                {
                    _uoeSupplier01521 = resultList;
                }
            }
            catch (Exception)
            {
                _uoeSupplier01521 = new List<UOESupplier>();
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�L���b�V���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheCustomerSearch()
        {
            _customerSearchRet = new Dictionary<int, CustomerSearchRet>();
            CustomerSearchRet[] customerSearchRetArray = null;

            // �����ݒ�
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            try
            {
                // ���Ӑ�}�X�^�f�[�^�擾(PMKHN09012A)
                CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                int status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0 &&
                            _customerSearchRet.ContainsKey(customerSearchRet.CustomerCode) != true)
                        {
                            this._customerSearchRet.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }

                }
            }
            catch (Exception)
            {
                _customerSearchRet = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// �]�ƈ��}�X�^�L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^�L���b�V���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheEmployee()
        {
            this.DetailInputAcs.CacheEmployee();
        }

        /// <summary>
        /// UOE�ڑ�����}�X�^�L���b�V�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�L���b�V�����䏈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheUOEConnectInfo()
        {
            try
            {
                //�w�肳�ꂽ��ƃR�[�h�E�ʐM�A�Z���u��ID�E���W�ԍ���UOE�ڑ�����LIST��S�Ė߂��܂�
                UOEConnectInfoAcs uOEConnectInfoAcs = new UOEConnectInfoAcs();
                UOEConnectInfo uOEConnectInfo = null;
                _uOEConnectInfo = null;
                int status = uOEConnectInfoAcs.Read(out uOEConnectInfo, this._enterpriseCode, _uoeSupplier.CommAssemblyId, _cashRegisterNo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _uOEConnectInfo = uOEConnectInfo;
                }
            }
            catch (Exception)
            {
                _uOEConnectInfo = null;
            }
        }
        # endregion �����f�[�^�擾����

        # region �� ���������� ��
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
        /// <param name="detail">true:�S�N���A false:���ו��N���A</param>
        /// <returns>true:���������s false:�����������s</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool Clear(bool isConfirm, bool detail)
        {
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "���s���Ă��X�����ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return false;
                }
            }

            // �f�[�^�ύX�t���O�v���p�e�B��false�ɂ���
            this.DetailInputAcs.IsDataChanged = false;

            // ��ʏ���
            if (detail)
            {
                ComboEditorItemInitialSetting();
                EventArgs e = new EventArgs();
                tComEd_SupplierCd_ValueChanged(null, e);

            }

            // �e�[�u���N���A����
            this._detailInput.Clear();

            //�w�b�_�[����ʓ����͕��̃N���A
            this._detailInput.ClearHedaerItem();

            //�R���g���[���֘A�L�������ݒ菈��
            SettingControlEnabled();

            return true;
        }


        # endregion �� ���������� ��

        # endregion �� �����ݒ�֘A ��

        # region �� �R���{�G�f�B�^�A�C�e�������ݒ菈�� ��
        /// <summary>
        /// �R���{�G�f�B�^�A�C�e�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���{�G�f�B�^�A�C�e�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ComboEditorItemInitialSetting()
        {
            //������R�[�h�F�����於�̂̏����ݒ菈��
            this.tComEd_SupplierCd.Items.Clear();

            for (int i = 0; i < _uoeSupplier01521.Count; i++)
            {
                UOESupplier uoeSupplier = (UOESupplier)_uoeSupplier01521[i];

                object dataValue = (object)uoeSupplier.UOESupplierCd;
                string displayText = uoeSupplier.UOESupplierCd.ToString("000000") + ":" + uoeSupplier.UOESupplierName;
                tComEd_SupplierCd.Items.Add(dataValue, displayText);
            }

            ClearOrderInpDisplay(MazdaInpDisplay);
            SetDisplay(MazdaInpDisplay);
        }
        # endregion �� �R���{�G�f�B�^�A�C�e�������ݒ菈�� ��

        # region �� ��ʃf�[�^����ʊi�[���� ��
        /// <summary>
        /// ��ʃf�[�^�N���X����ʊi�[����
        /// </summary>
        /// <param name="inpDisplay">�݌Ɉꊇ�f�[�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʃf�[�^�N���X����ʊi�[�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SetDisplay(MazdaInpDisplay inpDisplay)
        {
            //���͍���
            this.tComboEditor_TerminalDiv.Value = inpDisplay.BusinessCode;		//�Ɩ��敪
            this.tComboEditor_TerminalNoDiv.Value = inpDisplay.CashRegisterNoDiv;	//�[���敪


            //�[���ԍ�
            switch (inpDisplay.CashRegisterNoDiv)
            {
                //���[��
                case ctTerminalNoDiv_Own:
                    {
                        inpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }

                //���[��
                case ctTerminalNoDiv_Other:
                    {
                        tNedit_TerminalNo.Enabled = true;
                        break;
                    }

                //�S�[��
                case ctTerminalNoDiv_All:
                    {
                        inpDisplay.CashRegisterNo = 0;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }
            }

            this.tNedit_TerminalNo.SetInt(inpDisplay.CashRegisterNo);

            //�V�X�e���敪
            this.tComboEditor_SysDiv.Value = inpDisplay.SystemDivCd;

            this.tNedit_St_OnlineNo.SetInt(inpDisplay.UOESalesOrderNoSt); //�I�����C���ԍ�(�J�n�j
            this.tNedit_Ed_OnlineNo.SetInt(inpDisplay.UOESalesOrderNoEd); //�I�����C���ԍ�(�I���j
            this.tDateEdit_InputDateSt.SetDateTime(inpDisplay.SalesDateSt); //���͓��i�J�n�j
            this.tDateEdit_InputDateEd.SetDateTime(inpDisplay.SalesDateEd); //���͓��i�I���j
            this.tNedit_CustomerCode.SetInt(inpDisplay.CustomerCode); //���Ӑ溰��
            this.tComEd_SupplierCd.Value = inpDisplay.UOESupplierCd; //�����溰��

            //�o�͍���
            this.uLabel_CustomerName.Text = inpDisplay.CustomerName; //���Ӑ於��

        }

        # endregion �� ��ʃf�[�^����ʊi�[���� ��

        # region �� ��ʃf�[�^�N���X�̏����� ��
        /// <summary>
        /// ��ʃf�[�^�N���X�̏�����
        /// </summary>
        /// <param name="inpDisplay"></param>
        /// <remarks>
        /// <br>Note       : ��ʃf�[�^�N���X�̏������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ClearOrderInpDisplay(MazdaInpDisplay inpDisplay)
        {
            //������
            inpDisplay.EnterpriseCode = this._enterpriseCode;   //��ƃR�[�h

            //���͍���
            inpDisplay.BusinessCode = ctTerminalDiv_Order;   //�Ɩ��敪
            inpDisplay.CashRegisterNoDiv = ctTerminalNoDiv_Own;   //�[���ԍ�
            inpDisplay.CashRegisterNo = _cashRegisterNo;         //�[���ԍ�
            inpDisplay.SystemDivCd = ctSysDiv_Slip;            //�V�X�e���敪

            inpDisplay.UOESalesOrderNoSt = 0;               //�I�����C���ԍ�(�J�n�j
            inpDisplay.UOESalesOrderNoEd = 0;               //�I�����C���ԍ�(�I���j
            inpDisplay.SalesDateSt = DateTime.Now;   //���͓��i�J�n�j
            inpDisplay.SalesDateEd = DateTime.Now;   //���͓��i�I���j
            inpDisplay.CustomerCode = 0;            //���Ӑ溰��

            //�����溰��
            if (_uoeSupplier01521.Count > 0)
            {
                inpDisplay.UOESupplierCd = _uoeSupplier01521[0].UOESupplierCd;

                PMUOE01541UB._supplierCd = _uoeSupplier01521[0].UOESupplierCd;
                PMUOE01541UB._sectionCode = _loginSectionCode;
            }
            //�o�͍���
            inpDisplay.CustomerName = "";            //���Ӑ於��
        }
        # endregion �� ��ʃf�[�^�N���X�̏����� ��

        # region �� ��ʁ���ʃf�[�^�N���X�i�[���� ��
        /// <summary>
        /// ��ʁ���ʃf�[�^�N���X�i�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʁ���ʃf�[�^�N���X�i�[�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private MazdaInpDisplay GetDisplay()
        {
            MazdaInpDisplay inpDisplay = new MazdaInpDisplay();

            //������
            inpDisplay.EnterpriseCode = this._enterpriseCode;   //��ƃR�[�h

            //���͍���
            inpDisplay.BusinessCode = (Int32)this.tComboEditor_TerminalDiv.Value; //�Ɩ��敪
            inpDisplay.CashRegisterNoDiv = (Int32)this.tComboEditor_TerminalNoDiv.Value;//�[���敪

            //�[���ԍ�
            inpDisplay.CashRegisterNo = (Int32)this.tNedit_TerminalNo.GetInt();

            inpDisplay.SystemDivCd = (Int32)this.tComboEditor_SysDiv.Value;          //�V�X�e���敪

            inpDisplay.UOESalesOrderNoSt = this.tNedit_St_OnlineNo.GetInt(); //�I�����C���ԍ�(�J�n�j
            inpDisplay.UOESalesOrderNoEd = this.tNedit_Ed_OnlineNo.GetInt();     //�I�����C���ԍ�(�I���j
            inpDisplay.SalesDateSt = this.tDateEdit_InputDateSt.GetDateTime(); //���͓��i�J�n�j
            inpDisplay.SalesDateEd = this.tDateEdit_InputDateEd.GetDateTime(); //���͓��i�I���j
            inpDisplay.CustomerCode = this.tNedit_CustomerCode.GetInt();       //���Ӑ溰��
            if (this.tComEd_SupplierCd.Value != null)
            {
                inpDisplay.UOESupplierCd = (int)this.tComEd_SupplierCd.Value;        //�����溰��
            }

            //�o�͍���
            inpDisplay.CustomerName = this.uLabel_CustomerName.Text;           //���Ӑ於��

            return inpDisplay;
        }

        /// <summary>��ʃf�[�^�N���X�̃v���p�e�B</summary>
        private MazdaInpDisplay MazdaInpDisplay
        {
            get
            {
                if (_inpDisplay == null)
                {
                    _inpDisplay = new MazdaInpDisplay();
                }
                return _inpDisplay;
            }
            set
            {
                this._inpDisplay = value;
            }
        }

        /// <summary>�}�c�_���������A�N�Z�X�N���X�̃v���p�e�B</summary>
        private MazdaOrderProcAcs DetailInputAcs
        {
            get
            {
                if (_detailInputAcs == null)
                {
                    _detailInputAcs = MazdaOrderProcAcs.GetInstance();
                }
                return _detailInputAcs;
            }
        }

        # endregion �� ��ʁ���ʃf�[�^�N���X�i�[���� ��

        # region �� StatusBar���b�Z�[�W�\������ ��
        /// <summary>
        /// StatusBar���b�Z�[�W�\������
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note       : StatusBar���b�Z�[�W�\���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void StatusBarMessageSettingProc(Control nextControl)
        {
            string message = "";

            if (nextControl.Name == tComEd_SupplierCd.Name)
            {
                message = MESSAGE_SupplierCd;
            }
            else if (nextControl.Name == tComboEditor_TerminalDiv.Name)
            {
                message = MESSAGE_TerminalDiv;
            }
            else if (nextControl.Name == tComboEditor_TerminalNoDiv.Name)
            {
                message = MESSAGE_TerminalNoDiv;
            }
            else if (nextControl.Name == tNedit_TerminalNo.Name)
            {
                message = MESSAGE_TerminalNo;
            }
            else if (nextControl.Name == tComboEditor_SysDiv.Name)
            {
                message = MESSAGE_SysDiv;
            }
            else if (nextControl.Name == tNedit_St_OnlineNo.Name)
            {
                message = MESSAGE_St_OnlineNo;
            }
            else if (nextControl.Name == tNedit_Ed_OnlineNo.Name)
            {
                message = MESSAGE_Ed_OnlineNo;
            }
            else if (nextControl.Name == tDateEdit_InputDateSt.Name)
            {
                message = MESSAGE_InputDateSt;
            }
            else if (nextControl.Name == tDateEdit_InputDateEd.Name)
            {
                message = MESSAGE_InputDateEd;
            }
            else if (nextControl.Name == tNedit_CustomerCode.Name)
            {
                message = MESSAGE_CustomerCode;
            }
            else
            {
                message = "";
            }
            StockDetailInput_StatusBarMessageSetting(this, message);
        }
        # endregion ��  StatusBar���b�Z�[�W�\������ ��

        # region �� �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g ��
        /// <summary>
        /// �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void StockDetailInput_StatusBarMessageSetting(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }
        # endregion �� �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g ��

        # region �� �I������ ��
        /// <summary>
        /// �I������
        /// </summary>
        /// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
        /// <remarks>
        /// <br>Note       : �I���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void Close(bool isConfirm)
        {
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "���s���Ă��X�����ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }

            }
            else
            {
                this.Close();
            }
        }
        # endregion �� �I������ ��

        #region �`�F�b�N����
        /// <summary>
        /// ���������`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������`�F�b�N���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/05/18</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            MazdaInpDisplay = this.GetDisplay();

            try
            {
                //������
                if (MazdaInpDisplay.UOESupplierCd == 0)
                {
                    errMsg = "�����悪�I������Ă��܂���B";
                    this.tComEd_SupplierCd.Focus();
                    return (false);
                }

                //�[���ԍ�
                if ((MazdaInpDisplay.CashRegisterNoDiv == ctTerminalNoDiv_Other)
                    && (MazdaInpDisplay.CashRegisterNo == 0))
                {
                    errMsg = "�[���ԍ��������͂ł��B";
                    this.tNedit_TerminalNo.SetInt(0);
                    this.tNedit_TerminalNo.Focus();
                    return (false);
                }

                //���͊J�n���t
                if (tDateEdit_InputDateSt.GetLongDate() == 0)
                {
                    errMsg = "���͊J�n���t�������͂ł��B";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                if (!InputDateEditCheack(tDateEdit_InputDateSt))
                {
                    errMsg = "���͊J�n���t�̎w��Ɍ�肪����܂��B";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                //���͏I�����t
                if (tDateEdit_InputDateEd.GetLongDate() == 0)
                {
                    errMsg = "���͏I�����t�������͂ł��B";
                    this.tDateEdit_InputDateEd.Focus();
                    return (false);
                }

                if (!InputDateEditCheack(tDateEdit_InputDateEd))
                {
                    errMsg = "���͏I�����t�̎w��Ɍ�肪����܂��B";
                    this.tDateEdit_InputDateEd.Focus();
                    return (false);
                }

                //���͓��͈�
                if ((MazdaInpDisplay.SalesDateSt != DateTime.MinValue)
                && (MazdaInpDisplay.SalesDateEd != DateTime.MinValue)
                && (MazdaInpDisplay.SalesDateSt > MazdaInpDisplay.SalesDateEd))
                {
                    errMsg = "���͓��t�͈̔͂��s���ł��B";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                //�ďo�ԍ�
                if ((MazdaInpDisplay.UOESalesOrderNoSt != 0)
                    && (MazdaInpDisplay.UOESalesOrderNoEd != 0)
                    && (MazdaInpDisplay.UOESalesOrderNoSt > MazdaInpDisplay.UOESalesOrderNoEd))
                {
                    errMsg = "�ďo�ԍ��͈̔͂��s���ł��B";
                    this.tNedit_St_OnlineNo.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// �N�������̓`�F�b�N����
        /// </summary>
        /// <param name="control">�N����control</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note       : �N�������̓`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // ���t�𐔒l�^�Ŏ擾
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;
            // ���t�����̓`�F�b�N
            if (date == 0) return false;
            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) { return false; }
            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;

                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;

                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;

                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;

                // ��        �\����
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;

                // ��        �\����
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD", date);

            // �P�����t�Ó����`�F�b�N

            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }

        /// <summary>
        /// ������t�@�C���`�F�b�N����
        /// </summary>
        /// <param name="folder">������t�H���_</param>
        /// <param name="initFlg">���������t���O</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ������t�@�C���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool UOESupplierFileCheck(string folder, bool initFlg)
        {
            bool status = true;
            string mess = string.Empty;
            // �񓚕ۑ��t�H���_�������͏ꍇ
            if (string.IsNullOrEmpty(folder))
            {
                mess = MESSAGE_NoPass;
                status = false;
            }
            // �񓚕ۑ��t�H���_���݂��Ȃ��ꍇ
            else if (!Directory.Exists(folder))
            {
                mess = MESSAGE_PassError;
                status = false;
            }

            if (!string.IsNullOrEmpty(mess))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    mess.ToString(),
                    0,
                    MessageBoxButtons.OK);
            }
            return status;
        }
        # endregion

        #region ���b�Z�[�W�{�b�N�X�\��
        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                        // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }
        #endregion ���b�Z�[�W�{�b�N�X�\��

        # region �� �t�n�d�����f�[�^ �������� ��
        /// <summary>
        /// �t�n�d�����f�[�^ ��������
        /// </summary>
        /// <param name="inpDisplay">���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�n�d�����f�[�^ �����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int SearchDB(MazdaInpDisplay inpDisplay)
        {
            //�������s����
            string message = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "����������";
            msgForm.Message = "�����������ł��B";

            try
            {
                msgForm.Show();
                status = this.DetailInputAcs.SearchDB(MazdaInpDisplay, out message);
            }
            finally
            {
                msgForm.Close();
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�Y���f�[�^�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.SetControlFocus(this.tComEd_SupplierCd);

                    return status;
                }
                else
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_STOPDISP,
                       this.Name,
                       message,
                       -1,
                       MessageBoxButtons.OK);
                    this.SetControlFocus(this.tComEd_SupplierCd);

                    return status;
                }

            }

            // �K�C�h�{�^���c�[���L�������ݒ菈��
            this.SettingGuideButtonToolEnabled();

            //�R���g���[���֘A�L�������ݒ菈��
            this.SettingControlEnabled();

            return status;
        }

        # endregion �� �t�n�d�����f�[�^ �������� ��

        # region �� �ۑ����� ��
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>true:�ۑ����� false:���ۑ�</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool UpdateDB()
        {
            bool isSave = false;
            string retMessage = "";
            int status = 0;

            try
            {
                //�ۑ������̃`�F�b�N
                if (this.DetailInputAcs.IsDataChanged == false) return (isSave);
                this.Cursor = Cursors.WaitCursor;
                StringBuilder messageBuilder = new StringBuilder();
                if (this.DetailInputAcs.GetDeleteCount() <= 0)
                {
                    messageBuilder.Append("���ׂ��I������Ă��܂���B" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }
                else if (this.DetailInputAcs.GetDeleteCount() > MAX_DETAILCOUNT)
                {
                    messageBuilder.Append("���׍��v��" + MAX_DETAILCOUNT + "�𒴂��Ȃ��l�ɑI�����Ă��������B" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }

                if (this._detailInput.BoCodeCheck(MazdaInpDisplay.BusinessCode, MazdaInpDisplay.SystemDivCd) != true)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("�����͂̍��ڂ����݂��邽�߁A�m��ł��܂���B" + "\r\n" + "\r\n");
                    message.Append("BO�敪" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    return isSave;
                }

                // ���s���b�Z�[�W�\��
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "�������������s���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return isSave;
                }

                if (inqOrdDivCd == 1)
                {
                    this.uLabel_CustomerName.Focus();  // �����������A�utEdit_UoeRemark1_Leave�v���s���B
                    ScreenEnableSet(false);
                }

                // UOE������}�X�^�̎���
                UOESupplier uOESupplier = GetUOESupplier(MazdaInpDisplay);
                if (!UOESupplierFileCheck(uOESupplier.AnswerSaveFolder, false))
                {
                    return isSave;
                }

                // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "�X�V������";
                form.Message = "�X�V�������ł��B";
                // �_�C�A���O�\��
                form.Show();

                List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();

                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                List<StockDetailWork> stockDetailWorkDelList = new List<StockDetailWork>();

                if (_uoeSupplier != null && key.Equals(_uoeSupplier.CommAssemblyId))
                {
                    this.DetailInputAcs.SetUOESupplier(_uoeSupplier);
                }

                // ��������
                //----------DEL BY ������ on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>
                //status = this.DetailInputAcs.WriteDB(this._cashRegisterNo, MazdaInpDisplay.SystemDivCd, out retMessage,
                //out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList);
                //----------DEL BY ������ on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<
                //----------ADD BY ������ on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>
                status = this.DetailInputAcs.WriteDB(this._cashRegisterNo, MazdaInpDisplay.SystemDivCd, out retMessage,
                out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, ref uOESupplier);
                //----------ADD BY ������ on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<
                // �_�C�A���O�����
                form.Close();

                //�ۑ������̎��s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSave = true;                    

                    // ���׃O���b�h�ݒ菈��
                    this._detailInput.SettingGrid();
                }
            }
            catch (Exception ex)
            {
                isSave = false;
                retMessage = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;

                if (status != 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "(" + status.ToString() + ")" +
                        "�X�V�Ɏ��s���܂����B" + "\r\n" + "\r\n" + retMessage,
                        status,
                        MessageBoxButtons.OK);
                }
            }

            if (inqOrdDivCd == 1)
            {
                ScreenEnableSet(true);
            }

            return isSave;
        }

        /// <summary>
        /// ���Enable�ݒ菈��
        /// </summary>
        /// <param name="enable">enable</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : ���Enable�ݒ���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ScreenEnableSet(bool enable)
        {
            this.tToolbarsManager_MainMenu.Enabled = enable;
            this.panel_Header.Enabled = enable;
            this.panel_Detail.Enabled = enable;
        }
        # endregion �� �ۑ����� ��

        # region �� �폜���� ��
        /// <summary>
        /// �폜����
        /// </summary>
        /// <returns>true:�폜���� false:�폜���s</returns>
        /// <remarks>
        /// <br>Note       : �폜�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        bool DeleteDB()
        {
            bool retBool = false;
            int status = 0;
            string message = "";

            try
            {
                //�폜�����̃`�F�b�N
                if (this.DetailInputAcs.IsDataChanged == false) return (retBool);
                if (this.DetailInputAcs.GetDeleteCount() <= 0)
                {
                    StringBuilder messageBuilder = new StringBuilder();
                    messageBuilder.Append("�폜�Ώۂ̃f�[�^��I�����Ă��������B" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return retBool;
                }

                //�폜���b�Z�[�W�\��
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "�I���s���폜���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return retBool;
                }

                // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "�폜������";
                form.Message = "�폜�������ł��B";
                // �_�C�A���O�\��
                form.Show();

                status = this.DetailInputAcs.DeleteDB(out message);

                // �_�C�A���O�����
                form.Close();

                //�폜�����̎��s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (this.DetailInputAcs.GetNoSelectCount() > 0)
                    {
                        //�Č���
                        this._detailInput.Clear1();
                        SearchDB(MazdaInpDisplay);
                        this._detailInput.SettingGrid(MazdaInpDisplay.BusinessCode);

                        // �e�[�u���N���A����
                        this._detailInput.ClearUltr();
                        retBool = false;
                    }
                    else
                    {
                        retBool = true;
                    }

                    // ���׃O���b�h�ݒ菈��
                    this._detailInput.SettingGrid();

                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
            }
            catch (Exception ex)
            {
                retBool = false;
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (status != 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "(" + status.ToString() + ")" +
                        "�폜�Ɏ��s���܂����B" + "\r\n" + "\r\n" + message,
                        status,
                        MessageBoxButtons.OK);
                }

            }
            return (retBool);
        }

        # endregion

        # region �� UOE������}�X�^�̎��� ��
        /// <summary>
        /// UOE������}�X�^����
        /// </summary>
        /// <param name="inpDisplay">��ʂ̏��</param>
        /// <returns>UOE������}�X�^</returns>
        /// <remarks>
        /// <br>Note       :  UOE������}�X�^�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private UOESupplier GetUOESupplier(MazdaInpDisplay inpDisplay)
        {
            UOESupplier uOESupplier = new UOESupplier();
            List<UOESupplier> resultList;

            resultList = _uoeSupplier01521.FindAll(delegate(UOESupplier target)
            {
                if (inpDisplay.UOESupplierCd.Equals(target.UOESupplierCd))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (resultList != null && resultList.Count > 0)
            {
                uOESupplier = (UOESupplier)resultList[0];
            }

            return uOESupplier;
        }

        # endregion �� UOE������}�X�^�̎��� ��

        # endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : 2011/05/18 ����� UOE����������</br>
        /// </remarks>
        private void PMUOE01541UA_Load(object sender, EventArgs e)
        {
            // Skin�ݒ�
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailInput);

            this.panel_Detail.Controls.Add(this._detailInput);
            this._detailInput.Dock = DockStyle.Fill;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // �����f�[�^�擾����
            this.ReadInitData();

            // �R���{�G�f�B�^�A�C�e�������ݒ菈��
            this.ComboEditorItemInitialSetting();
            this._bfSupplier = PMUOE01541UB._supplierCd;

            // �N���A����
            this.Clear(false, false);

            // �w�肳�ꂽUOE������̉񓚕ۑ��t�H���_�̎擾
            if (this._uoeSupplier01521 != null && this._uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        mitsubishiFlod = uoeSupplier.AnswerSaveFolder;
                        _uoeSupplier = uoeSupplier;

                        if (key.Equals(uoeSupplier.CommAssemblyId))
                        {
                            inqOrdDivCd = 0;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else if (autoKey.Equals(uoeSupplier.CommAssemblyId))
                        {
                            inqOrdDivCd = 1;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else
                        {
                            //�Ȃ��B
                        }
                    }
                }
            }

            // UOE�ڑ�����}�X�^�̎擾
            if (_uoeSupplier != null)
            {
                this.CacheUOEConnectInfo();
            }
            else
            {
                //�Ȃ��B
            }

            this.timer_InitialSet.Enabled = true;

        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�R���g���[���C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            bool canChangeFocus;
            int code;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (MazdaInpDisplay == null) return;

            switch (e.PrevCtrl.Name)
            {
                // �O���b�h =============================================== //
                case "uGrid_Details":
                    {
                        #region [ uGrid_Details ]
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this._detailInput.uGrid_Details.ActiveCell != null)
                                    {
                                        if (this._detailInput.ReturnKeyDown())
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false; // ADD 2011/05/18
                                            this._detailInput.uGrid_Details.ActiveCell = null; // ADD 2011/05/18
                                        }
                                    }
                                    break;
                                }
                        }
                        #endregion
                        break;
                    }

                // UOE������R�[�h ============================================ //
                case "tComEd_SupplierCd":
                    {
                        #region [ tComEd_SupplierCd ]
                        if (tComEd_SupplierCd.Value != null)
                        {
                            MazdaInpDisplay.UOESupplierCd = (Int32)tComEd_SupplierCd.Value;
                        }

                        code = this.tNedit_CustomerCode.GetInt();

                        if (e.ShiftKey)
                        {
                            if (code == 0)
                            {
                                // �t�H�[�J�X�ݒ�
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.uButton_CustomerGuide;
                                }
                            }
                            else
                            {
                                string customerNameFouce = "";
                                if (GetMakerName(code, out customerNameFouce) == true)
                                {
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                    }
                                }
                            }
                        }

                        #endregion
                        break;
                    }

                // �Ɩ��敪 ============================================ //
                case "tComboEditor_TerminalDiv":
                    {
                        #region [ tComboEditor_TerminalDiv ]
                        MazdaInpDisplay.BusinessCode = (Int32)tComboEditor_TerminalDiv.Value;
                        #endregion
                        break;
                    }

                // �[���敪 ============================================ //
                case "tComboEditor_TerminalNoDiv":
                    #region [ tComboEditor_TerminalNoDiv ]
                    MazdaInpDisplay.CashRegisterNoDiv = (Int32)tComboEditor_TerminalNoDiv.Value;
                    #endregion
                    break;

                // �[���ԍ� ============================================ //
                case "tNedit_TerminalNo":
                    #region [ tNedit_TerminalNo ]
                    MazdaInpDisplay.CashRegisterNo = this.tNedit_TerminalNo.GetInt();
                    #endregion
                    break;

                // �V�X�e���敪 ============================================ //
                case "tComboEditor_SysDiv":
                    #region [ tComboEditor_SysDiv ]
                    MazdaInpDisplay.SystemDivCd = (Int32)tComboEditor_SysDiv.Value;
                    #endregion
                    break;

                // �I�����C���ԍ�(�J�n�j ============================================ //
                case "tNedit_St_OnlineNo":
                    #region [ St_OnlineNo ]
                    MazdaInpDisplay.UOESalesOrderNoSt = tNedit_St_OnlineNo.GetInt();
                    #endregion
                    break;

                // �I�����C���ԍ�(�I���j ============================================ //
                case "tNedit_Ed_OnlineNo":
                    #region [ Ed_OnlineNo ]
                    MazdaInpDisplay.UOESalesOrderNoEd = tNedit_Ed_OnlineNo.GetInt();
                    #endregion
                    break;

                // ���͓��i�J�n�j ============================================ //
                case "tDateEdit_InputDateSt":
                    #region [ tDateEdit_InputDateSt ]
                    MazdaInpDisplay.SalesDateSt = tDateEdit_InputDateSt.GetDateTime();
                    #endregion
                    break;

                // ���͓��i�I���j ============================================ //
                case "tDateEdit_InputDateEd":
                    #region [ tDateEdit_InputDateEd ]
                    MazdaInpDisplay.SalesDateEd = tDateEdit_InputDateEd.GetDateTime();
                    #endregion
                    break;

                // ���Ӑ溰�� ============================================ //
                case "tNedit_CustomerCode":
                    #region [ tNedit_CustomerCode ]
                    canChangeFocus = true;
                    code = this.tNedit_CustomerCode.GetInt();

                    if (MazdaInpDisplay.CustomerCode != code)
                    {
                        if (code == 0)
                        {
                            MazdaInpDisplay.CustomerCode = 0;
                            MazdaInpDisplay.CustomerName = "";
                        }
                        else
                        {
                            string customerName = "";
                            if (GetMakerName(code, out customerName) == true)
                            {
                                MazdaInpDisplay.CustomerCode = code;
                                MazdaInpDisplay.CustomerName = customerName;

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
                                canChangeFocus = false;
                            }
                        }

                        // NextCtrl����
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.tNedit_CustomerCode.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.uButton_CustomerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComEd_SupplierCd;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    else
                    {
                        if (!e.ShiftKey)
                        {
                            if (code == 0)
                            {
                                // �t�H�[�J�X�ݒ�
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.uButton_CustomerGuide;
                                }
                            }
                            else
                            {
                                string customerNameFouce = "";
                                if (GetMakerName(code, out customerNameFouce) == true)
                                {
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        e.NextCtrl = this.tComEd_SupplierCd;
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                    break;

                // ���Ӑ�{�^��
                case "uButton_CustomerGuide":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tComEd_SupplierCd;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode;
                            }
                        }
                        break;
                    }
            }

            // ��������̓��e�Ɣ�r����
            MazdaInpDisplay InpDisplayNow = this.GetDisplay();
            ArrayList arRetList = MazdaInpDisplay.Compare(InpDisplayNow);

            if (arRetList.Count > 0)
            {
                // ��ʏ��N���X����ʊi�[����
                this.SetDisplay(MazdaInpDisplay);
            }

            // �K�C�h�{�^���c�[���L�������ݒ菈��
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                SettingGuideButtonToolEnabled();
                this.StatusBarMessageSettingProc(e.NextCtrl);
            }
        }

        /// <summary>
        /// ���Ӑ溰�ޖ��擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <returns>True�F�f�[�^����AFalse�F�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ溰�ޖ��擾�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool GetMakerName(int customerCode, out string customerName)
        {
            customerName = string.Empty;

            if (!this._customerSearchRet.ContainsKey(customerCode))
            {
                return false;
            }

            customerName = this._customerSearchRet[customerCode].Name.Trim() + this._customerSearchRet[customerCode].Name2.Trim();

            return true;
        }

        # region �� ���Ӑ�K�C�h�{�^���N���b�N�C�x���g ��
        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I���������C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this.MazdaInpDisplay.CustomerCode = customerSearchRet.CustomerCode;                    // ���Ӑ�R�[�h
            this.MazdaInpDisplay.CustomerName = customerSearchRet.Name + customerSearchRet.Name2;   // ���Ӑ於��

            this.tNedit_CustomerCode.SetInt(this.MazdaInpDisplay.CustomerCode);
            this.uLabel_CustomerName.Text = this.MazdaInpDisplay.CustomerName;

            // ����
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }

        # endregion �� ���Ӑ�K�C�h�{�^���N���b�N�C�x���g ��

        /// <summary>
        /// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void timer_InitialSet_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSet.Enabled = false;

            //-----------------------------------------------------------
            // �}�c�_Web-UOE�p�A�g�t�@�C���̃I�[�v������
            //-----------------------------------------------------------
            if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uOESupplier in _uoeSupplier01521)
                {
                    if (uOESupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        if (!UOESupplierFileCheck(uOESupplier.AnswerSaveFolder, true))
                        {
                            // [����]�{�^�������[�m��]�{�^���������s�Ƃ��܂�
                            buttonDisFlg = false;
                        }
                        else
                        {
                            buttonDisFlg = true;
                        }
                    }
                }
            }

            SetControlFocus(this.tComEd_SupplierCd);

        }

        # region �� �w��t�H�[�J�X�ݒ菈�� ��
        /// <summary>
        /// �w��t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w��t�H�[�J�X�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SetControlFocus(Control control)
        {
            if (control == null) return;
            if (control.Enabled != true) return;
            if (control.Visible != true) return;
            control.Focus();

            // �K�C�h�{�^���c�[���L�������ݒ菈��
            this.SettingGuideButtonToolEnabled();
            this.StatusBarMessageSettingProc(control);
        }
        # endregion

        # region �� �K�C�h�{�^���c�[���L�������ݒ菈�� ��
        /// <summary>
        /// �K�C�h�{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���c�[���L�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled()
        {
            if (this.DetailInputAcs.IsDataChanged == true)
            {
                // �����{�^��
                _searchButton.SharedProps.Enabled = false;
                // �m��{�^��
                this._saveButton.SharedProps.Enabled = true;
            }
            else
            {
                // �����{�^��
                _searchButton.SharedProps.Enabled = true;
                // �m��{�^��
                this._saveButton.SharedProps.Enabled = false;
            }
            if (this.buttonDisFlg == false)
            {
                // �����{�^��
                _searchButton.SharedProps.Enabled = false;
                // �m��{�^��
                this._saveButton.SharedProps.Enabled = false;
            }
        }

        # endregion �� �K�C�h�{�^���c�[���L�������ݒ菈�� ��

        # region �� �R���g���[���֘A ��
        /// <summary>
        /// �R���g���[���֘A�L�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���֘A�L�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SettingControlEnabled()
        {
            if (this.DetailInputAcs.IsDataChanged == true)
            {

                this.tComEd_SupplierCd.Enabled = false;
                this.tComboEditor_TerminalNoDiv.Enabled = false;
                this.tNedit_TerminalNo.Enabled = false;
                this.tComboEditor_TerminalDiv.Enabled = false;
                this.tComboEditor_SysDiv.Enabled = false;
                this.tNedit_St_OnlineNo.Enabled = false;
                this.tNedit_Ed_OnlineNo.Enabled = false;
                this.tDateEdit_InputDateSt.Enabled = false;
                this.tDateEdit_InputDateEd.Enabled = false;
                this.tNedit_CustomerCode.Enabled = false;
                this.uButton_CustomerGuide.Enabled = false;
            }
            else
            {
                this.tComEd_SupplierCd.Enabled = true;
                this.tComboEditor_TerminalNoDiv.Enabled = true;

                //���[��
                if ((Int32)(this.tComboEditor_TerminalNoDiv.Value) == ctTerminalNoDiv_Other)
                {
                    this.tNedit_TerminalNo.Enabled = true;
                }
                //���[���E�S�[��
                else
                {
                    this.tNedit_TerminalNo.Enabled = false;
                }
                this.tComboEditor_TerminalDiv.Enabled = true;
                this.tComboEditor_SysDiv.Enabled = true;
                this.tNedit_St_OnlineNo.Enabled = true;
                this.tNedit_Ed_OnlineNo.Enabled = true;
                this.tDateEdit_InputDateSt.Enabled = true;
                this.tDateEdit_InputDateEd.Enabled = true;
                this.tNedit_CustomerCode.Enabled = true;
                this.uButton_CustomerGuide.Enabled = true;
            }
        }

        # endregion �� �R���g���[���֘A ��

        # region �� �[���敪�l�ύX�C�x���g ��
        /// <summary>
        /// �[���敪�l�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �[���敪�l�ύX�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tComboEditor_TerminalNoDiv_ValueChanged(object sender, EventArgs e)
        {
            Int32 code = (Int32)this.tComboEditor_TerminalNoDiv.Value;
            if (code == MazdaInpDisplay.CashRegisterNoDiv) return;
            MazdaInpDisplay.CashRegisterNoDiv = code;

            //�[���ԍ�
            switch (MazdaInpDisplay.CashRegisterNoDiv)
            {
                //���[��
                case ctTerminalNoDiv_Own:
                    {
                        MazdaInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }

                //���[��
                case ctTerminalNoDiv_Other:
                    {
                        MazdaInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = true;
                        break;
                    }
                //�S�[��
                case ctTerminalNoDiv_All:
                    {
                        MazdaInpDisplay.CashRegisterNo = 0;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }
            }
            this.tNedit_TerminalNo.SetInt(MazdaInpDisplay.CashRegisterNo);
        }
        # endregion �� �[���敪�l�ύX�C�x���g ��

        #region �� UOE������l�ύX�C�x���g ��
        /// <summary>
        /// UOE������l�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : UOE������l�ύX�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tComEd_SupplierCd_ValueChanged(object sender, EventArgs e)
        {
            if (this._bfSupplier == 0) return;

            if (this.tComEd_SupplierCd.Value != null &&
                (int)this.tComEd_SupplierCd.Value != this._bfSupplier)
            {
                PMUOE01541UB._supplierCd = (int)this.tComEd_SupplierCd.Value;
                this._bfSupplier = (int)this.tComEd_SupplierCd.Value;

                // �}�c�_Web-UOE�p�A�g�t�@�C���̃I�[�v������
                if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
                {
                    List<UOESupplier> resultList;
                    resultList = _uoeSupplier01521.FindAll(delegate(UOESupplier target)
                    {
                        if (PMUOE01541UB._supplierCd.Equals(target.UOESupplierCd))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (resultList != null && resultList.Count > 0)
                    {
                        mitsubishiFlod = resultList[0].AnswerSaveFolder;
                        _uoeSupplier = resultList[0];

                        this._detailInput.CacheUOEGuideName_01531();

                        if (key.Equals(resultList[0].CommAssemblyId))
                        {
                            inqOrdDivCd = 0;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else if (autoKey.Equals(resultList[0].CommAssemblyId))
                        {
                            inqOrdDivCd = 1;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else
                        {
                            //�Ȃ��B
                        }

                        // UOE�ڑ�����}�X�^�̎擾
                        if (_uoeSupplier != null)
                        {
                            this.CacheUOEConnectInfo();
                        }
                        else
                        {
                            //�Ȃ��B
                        }

                        if (!UOESupplierFileCheck(resultList[0].AnswerSaveFolder, true))
                        {
                            // [����]�{�^�������[�m��]�{�^���������s�Ƃ��܂�
                            this._searchButton.SharedProps.Enabled = false;
                            this._saveButton.SharedProps.Enabled = false;
                            this.buttonDisFlg = false;
                        }
                        else
                        {
                            this.buttonDisFlg = true;
                        }
                        this.SettingGuideButtonToolEnabled();
                    }

                }
            }
        }
        #endregion

        # region �� �c�[���o�[�C�x���g ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�{�^���N���b�N�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            //��ʁ����o�����N���X
            MazdaInpDisplay = this.GetDisplay();

            switch (e.Tool.Key)
            {
                //�I������
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close(true);
                        break;
                    }
                //��������
                case "ButtonTool_Search":
                    {
                        //��������
                        if (this.CheckSearchCondition() == true)
                        {
                            // �V�X�e���敪���݌Ɉꊇ���̂ݓ��͉\�Ƃ��܂��B
                            if (this.tComboEditor_SysDiv.SelectedIndex == 3)
                            {
                                PMUOE01541UB._countFlg = true;
                            }
                            else
                            {
                                PMUOE01541UB._countFlg = false;
                            }

                            int status = SearchDB(MazdaInpDisplay);
                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                PMUOE01541UB._searchNoDateFlg = true;
                            }
                            // ���׃O���b�h�Z���ݒ菈��
                            this._detailInput.SettingGrid(MazdaInpDisplay.BusinessCode);
                            PMUOE01541UB._searchNoDateFlg = false;
                            this._detailInput.uGrid_Details.Focus();
                        }
                        break;
                    }
                //�m�菈��
                case "ButtonTool_Save":
                    {
                        bool isStatus = false;

                        // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                        if (this._detailInput.uGrid_Details.ActiveCell != null)
                        {
                            this._detailInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        //�������
                        if (MazdaInpDisplay.BusinessCode == ctTerminalDiv_Cancel)
                        {
                            isStatus = this.DeleteDB();
                        }
                        //�X�V����
                        else
                        {
                            isStatus = this.UpdateDB();
                        }

                        //��ʏ���������
                        if (isStatus)
                        {
                            this.Clear(false, true);
                            this.SetControlFocus(this.tComEd_SupplierCd);
                        }

                        break;
                    }
                //�V�K����
                case "ButtonTool_Undo":
                    {
                        bool isSave = this.Clear(true, true);

                        if (isSave)
                        {
                            PMUOE01541UB._countFlg = false;
                            this.SetControlFocus(this.tComEd_SupplierCd);
                        }
                        break;
                    }
            }
        }
        # endregion �� �c�[���o�[�C�x���g ��
        # endregion
    }
}