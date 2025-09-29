//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Y��������
// �v���O�����T�v   : ���Y�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �� �� ��  2010/03/08  �C�����e : �V�K�쐬
//                                  ���YWeb-UOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^������YWeb-UOE�p�V�X�e���A�g�t�@�C���̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �C �� ��  2010/03/18  �C�����e : Redmine4005�A4030-4031�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �C �� ��  2010/03/19  �C�����e : Redmine#4031�A4032�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �C �� ��  2010/03/19  �C�����e : Redmine#4065�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : 杍^
// �C �� ��  2010/12/31  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/02/25  �C�����e : ���YUOE�������A�a�Ή����̑g�ݍ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/15  �C�����e : Redmine #19908�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/17  �C�����e : Redmine #19971�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/12/02  �C�����e : Redmine#8304�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Globarization;

using System.Runtime.InteropServices;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Y��������UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���Y��������UI�t�H�[���N���X</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date        : 2010/03/08</br>
    /// <br>UpdateNote  : 2010/03/18 ������ Redmine4005�A4030-4031�Ή�</br>
    /// <br>UpdateNote  : 2010/03/19 ������ Redmine#4031�A4032�Ή�</br>
    /// <br>UpdateNote  : 2010/12/31 杍^ UOE����������</br>
    /// <br>UpdateNote  : 2011/02/25 ������ ���YUOE�������A�a�Ή����̑g�ݍ���</br>
 /// <br>UpdateNote  : 2011/03/17 ������ </br>
    /// <br>              Redmine #19971�̑Ή�</br>
    /// </remarks>
    public partial class PMUOE01521UA : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        ///  ���Y���������t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���Y���������t�H�[���N���X �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/03/08</br>
        /// <br>UpdateNote  : 2010/03/19 ������ Redmine4031�A4032�Ή�</br>
        /// </remarks>
        public PMUOE01521UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._detailInput = new PMUOE01521UB();
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

            // -----------DEL 2010/03/19------------>>>>>
            //_inpDisplay = new NissanInpDisplay();
            //this._detailInputAcs = NissanOrderProcAcs.GetInstance();
            // -----------DEL 2010/03/19------------<<<<<
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
        //���Y
        private const string key = "0203";
        //���Y
        private const string fileName = "F2WUOE.TXT";
        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMUOE01521U";

        // --------ADD 2010/12/31--------->>>>>
        // ���Y�i�����j
        private const string auto_key = "0204";  
        private const string preFileName = "F2WUOE_";
        private const string preSubFileName = "F2WUOESUB_";
        private const string endSubFileName = ".TXT";
        private const string endFileName = ".TXT";
        private const string timeFormat = "yyyyMMddHHmmss";
        // --------ADD 2010/12/31---------<<<<<

        // ---ADD 2011/02/25-------------------->>>>>
        private const string key205 = "0205";
        private const string key206 = "0206";  
        // ---ADD 2011/02/25--------------------<<<<<
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private PMUOE01521UB _detailInput;
        private ImageList _imageList16 = null;                                                // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // �m��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;                    // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // �����{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;                  // ���O�C���S���Җ���
        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        //�t�n�d������A�N�Z�X�N���X
        private UOESupplierAcs _uoeSupplierAcs;         // ADD 2010/12/31                              
        //�t�n�d������
        private List<UOESupplier> _uoeSupplier01521;
        private UOEConnectInfo _uOEConnectInfo;// UOE�ڑ�����}�X�^ 
        //���Ӑ�}�X�^
        private Dictionary<int, CustomerSearchRet> _customerSearchRet;
        //��ʓ��̓N���X
        private NissanInpDisplay _inpDisplay;
        //�[���ԍ�
        int _cashRegisterNo;
        //���Y���������A�N�Z�X�N���X
        private NissanOrderProcAcs _detailInputAcs;

        private bool buttonDisFlg = true;

        // �O�񔭒���
        private Int32 _bfSupplier = 0;

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// ��ʕ���t���O
        /// </summary>
        public bool closeCheck = true;
        private string nissanFlod = string.Empty;
        private UOESupplier _uoeSupplier = null;
        // --------ADD 2010/12/31---------<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2011/02/25 ������ </br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
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
                    // ---UPD 2011/02/25--------------->>>>>
                    //if (key.Equals(target.CommAssemblyId)
                    //    || auto_key.Equals(target.CommAssemblyId))  // ADD 2010/12/31

                    if (key.Equals(target.CommAssemblyId)
                        || auto_key.Equals(target.CommAssemblyId)
                        || key205.Equals(target.CommAssemblyId)
                        || key206.Equals(target.CommAssemblyId))
                    // ---UPD 2011/02/25---------------<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4032�Ή�</br>
        /// </remarks>
        public void CacheEmployee()
        {
            //this._detailInputAcs.CacheEmployee();// DEL 2010/03/19
            this.DetailInputAcs.CacheEmployee();// ADD 2010/03/19
        }

        // --------- ADD 2010/12/31 -------------------->>>>
        /// <summary>
        /// UOE�ڑ�����}�X�^�L���b�V�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�L���b�V�����䏈�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public void CacheUOEConnectInfo(string commAssemblyId)
        {
            try
            {
                //�w�肳�ꂽ��ƃR�[�h�E�ʐM�A�Z���u��ID�E���W�ԍ���UOE�ڑ�����LIST��S�Ė߂��܂�
                UOEConnectInfoAcs uOEConnectInfoAcs = new UOEConnectInfoAcs();
                UOEConnectInfo uOEConnectInfo = null;
                _uOEConnectInfo = null;
                int status = uOEConnectInfoAcs.Read(out uOEConnectInfo, this._enterpriseCode, commAssemblyId, _cashRegisterNo);
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
        // --------- ADD 2010/12/31 --------------------<<<<

        # endregion �����f�[�^�擾����

        # region �� ���������� ��
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
        /// <param name="detail">true:�S�N���A false:���ו��N���A</param>
        /// <returns>true:���������s false:�����������s</returns>
        /// <remarks>
        /// <br>Note       :  ��ʏ������������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4032�Ή�</br>
        /// </remarks>
        private bool Clear(bool isConfirm, bool detail)
        {
            //if ((isConfirm) && this._detailInputAcs.IsDataChanged && this._detailInputAcs.StockRowExists())// DEL 2010/03/19
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())// ADD 2010/03/19
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
            //this._detailInputAcs.IsDataChanged = false;// DEL 2010/03/19
            this.DetailInputAcs.IsDataChanged = false;// ADD 2010/03/19

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
            this._detailInput.ClearHedaerItem();   // ADD 2010/12/31

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine#4031�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4031�Ή�</br>
        /// </remarks>
        private void ComboEditorItemInitialSetting()
        {
            // -----------DEL 2010/03/19------------>>>>>
            //if (NissanInpDisplay == null)
            //{
            //    //_inpDisplay = new NissanInpDisplay();// DEL 2010/03/18
            //    NissanInpDisplay = new NissanInpDisplay();// ADD 2010/03/18
            //}
            // -----------DEL 2010/03/19------------<<<<<

            //������R�[�h�F�����於�̂̏����ݒ菈��
            this.tComEd_SupplierCd.Items.Clear();

            for (int i = 0; i < _uoeSupplier01521.Count; i++)
            {
                UOESupplier uoeSupplier = (UOESupplier)_uoeSupplier01521[i];

                object dataValue = (object)uoeSupplier.UOESupplierCd;
                string displayText = uoeSupplier.UOESupplierCd.ToString("000000") + ":" + uoeSupplier.UOESupplierName;
                tComEd_SupplierCd.Items.Add(dataValue, displayText);
            }

            ClearOrderInpDisplay(NissanInpDisplay);
            SetDisplay(NissanInpDisplay);
        }
        # endregion �� �R���{�G�f�B�^�A�C�e�������ݒ菈�� ��

        # region �� ��ʃf�[�^����ʊi�[���� ��
        /// <summary>
        /// ��ʃf�[�^�N���X����ʊi�[����
        /// </summary>
        /// <param name="inpDisplay">�݌Ɉꊇ�f�[�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʃf�[�^�N���X����ʊi�[�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4031�Ή�</br>
        /// </remarks>
        private void SetDisplay(NissanInpDisplay inpDisplay)
        {
            // ----------DEL 2010/03/19------------>>>>>
            //if (inpDisplay == null)
            //{
            //    inpDisplay = new NissanInpDisplay();
            //    ClearOrderInpDisplay(inpDisplay);
            //}
            // ----------DEL 2010/03/19------------<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ClearOrderInpDisplay(NissanInpDisplay inpDisplay)
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

                PMUOE01521UB._supplierCd = _uoeSupplier01521[0].UOESupplierCd;
                PMUOE01521UB._sectionCode = _loginSectionCode;
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private NissanInpDisplay GetDisplay()
        {
            NissanInpDisplay inpDisplay = new NissanInpDisplay();

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
        //public NissanInpDisplay NissanInpDisplay// DEL 2010/03/18
        private NissanInpDisplay NissanInpDisplay// ADD 2010/03/18
        {
            // -----------UPD 2010/03/19------------>>>>>
            //get
            //{
            //    return this._inpDisplay;
            //}
            get
            {
                if (_inpDisplay == null)
                {
                    _inpDisplay = new NissanInpDisplay();
                }
                return _inpDisplay;
            }
            // -----------UPD 2010/03/19------------<<<<<
            set
            {
                this._inpDisplay = value;
            }
        }

        // -----------ADD 2010/03/19------------>>>>>
        /// <summary>���Y���������A�N�Z�X�N���X�̃v���p�e�B</summary>
        private NissanOrderProcAcs  DetailInputAcs
        {
            get
            {
                if (_detailInputAcs == null)
                {
                    _detailInputAcs = NissanOrderProcAcs.GetInstance();
                }
                return _detailInputAcs;
            }
        }
        // -----------ADD 2010/03/19------------<<<<<

        # endregion �� ��ʁ���ʃf�[�^�N���X�i�[���� ��

        # region �� StatusBar���b�Z�[�W�\������ ��
        /// <summary>
        /// StatusBar���b�Z�[�W�\������
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note       : StatusBar���b�Z�[�W�\���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4005�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4032�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4065�Ή�</br>
        /// </remarks>
        private void Close(bool isConfirm)
        {
            //if ((isConfirm) && this._detailInputAcs.IsDataChanged && this._detailInputAcs.StockRowExists())// DEL 2010/03/19
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())// ADD 2010/03/19
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
                    DialogResult dr = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "�����������I���O�ɓ��Y���i�����V�X�e���ɂđ��M���Ă��������B" + "\r\n" + "\r\n" +
                    "�����������I�����܂����H" + "\r\n" +
                    "�y����!!�z" + "\r\n" +
                    //"�����M�̏ꍇ�A�쐬�����A�g�t�@�C�����폜����Ă��܂��\��������܂��B" + "\r\n" + "\r\n",// DEL 2010/03/19
                    "�����M�̏ꍇ�A�쐬�����A�g�t�@�C�����폜����Ă��܂��\��������܂��B" + "\r\n",// ADD 2010/03/19
                    0,
                    MessageBoxButtons.YesNo,
                    //MessageBoxDefaultButton.Button1);// DEL 2010/03/19
                    MessageBoxDefaultButton.Button2);// ADD 2010/03/19
                    if (dr == DialogResult.Yes)
                    {
                        //this._detailInputAcs.CloseFileStream(_detailInputAcs.UoeFileStream);// DEL 2010/03/18
                        // -----------UPD 2010/03/19------------>>>>>
                        //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
                        this.DetailInputAcs.CloseFileStream();
                        // -----------UPD 2010/03/19------------<<<<<
                        this.Close();
                    }
                }

            }
            else
            {
                DialogResult dr = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "�����������I���O�ɓ��Y���i�����V�X�e���ɂđ��M���Ă��������B" + "\r\n" +�@"\r\n" + 
                "�����������I�����܂����H" + "\r\n" +
                "�y����!!�z" + "\r\n" +
                //"�����M�̏ꍇ�A�쐬�����A�g�t�@�C�����폜����Ă��܂��\��������܂��B" + "\r\n" + "\r\n",// DEL 2010/03/19
                "�����M�̏ꍇ�A�쐬�����A�g�t�@�C�����폜����Ă��܂��\��������܂��B" + "\r\n",// ADD 2010/03/19
                0,
                MessageBoxButtons.YesNo,
                //MessageBoxDefaultButton.Button1);// DEL 2010/03/19
                MessageBoxDefaultButton.Button2);// ADD 2010/03/19
                if (dr == DialogResult.Yes)
                {
                    //this._detailInputAcs.CloseFileStream(_detailInputAcs.UoeFileStream);// DEL 2010/03/18
                    // -----------UPD 2010/03/19------------>>>>>
                    //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
                    this.DetailInputAcs.CloseFileStream();
                    // -----------UPD 2010/03/19------------<<<<<
                    this.Close();
                }
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            NissanInpDisplay = this.GetDisplay();

            try
            {
                //������
                if (NissanInpDisplay.UOESupplierCd == 0)
                {
                    errMsg = "�����悪�I������Ă��܂���B";
                    this.tComEd_SupplierCd.Focus();
                    return (false);
                }

                //�[���ԍ�
                if ((NissanInpDisplay.CashRegisterNoDiv == ctTerminalNoDiv_Other)
                    && (NissanInpDisplay.CashRegisterNo == 0))
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
                if ((NissanInpDisplay.SalesDateSt != DateTime.MinValue)
                && (NissanInpDisplay.SalesDateEd != DateTime.MinValue)
                && (NissanInpDisplay.SalesDateSt > NissanInpDisplay.SalesDateEd))
                {
                    errMsg = "���͓��t�͈̔͂��s���ł��B";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                //�ďo�ԍ�
                if ((NissanInpDisplay.UOESalesOrderNoSt != 0)
                    && (NissanInpDisplay.UOESalesOrderNoEd != 0)
                    && (NissanInpDisplay.UOESalesOrderNoSt > NissanInpDisplay.UOESalesOrderNoEd))
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ������t�@�C���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4032�Ή�</br>
        /// <br>UpdateNote : 2011/02/25 ������ ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// </remarks>
        private bool UOESupplierFileCheck(string folder)
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
            // �t�@�C�����I�[�v�����̏ꍇ
            //else if (!this._detailInputAcs.GetCanWriteFlg(folder + "\\" + fileName))// DEL 2010/03/19
            // --------UPD 2010/12/31--------->>>>>
            //else if (!this.DetailInputAcs.GetCanWriteFlg(folder + "\\" + fileName))// ADD 2010/03/19
            //{
            //    mess = MESSAGE_ExclusiveError;
            //    status = false;
            //}
            // --------UPD 2011/02/25--------->>>>>
            //else if (key.Equals(this._uoeSupplier.CommAssemblyId))
            else if (key.Equals(this._uoeSupplier.CommAssemblyId)
             || (key205.Equals(this._uoeSupplier.CommAssemblyId) && this._uoeSupplier.InqOrdDivCd == 0))
            // --------UPD 2011/02/25---------<<<<<
            {
                if (!this.DetailInputAcs.GetCanWriteFlg(folder + "\\" + fileName))
                {
                    mess = MESSAGE_ExclusiveError;
                    status = false;
                }
            }
            // --------UPD 2010/12/31---------<<<<<

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

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// ������t�@�C���`�F�b�N����
        /// </summary>
        /// <param name="path">������t�H���_</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ������t�@�C���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        private bool UOESupplierSubFileCheck(string path)
        {
            bool status = true;
            string mess = string.Empty;

            if (!this.DetailInputAcs.GetCanWriteFlg(path))
            {
                mess = MESSAGE_ExclusiveError;
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
        // --------ADD 2010/12/31---------<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009/04/07</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4032�Ή�</br>
        /// <br>UpdateNote : 2011/02/25 ������ </br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// </remarks>
        public int SearchDB(NissanInpDisplay inpDisplay)
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
                //status = _detailInputAcs.SearchDB(NissanInpDisplay, out message);// DEL 2010/03/19
                status = this.DetailInputAcs.SearchDB(NissanInpDisplay, out message);// ADD 2010/03/19
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

            // ---ADD 2011/02/25---------------->>>>
            #region ���͂���R�[�h�ƃ��}�[�N�Q�L�������ݒ菈��
            // �w�肳�ꂽUOE������̃v���O�����̎擾
            if (this._uoeSupplier01521 != null && this._uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        if (key205.Equals(uoeSupplier.CommAssemblyId))
                        {
                            this._detailInput.SetRemark2Enabled(false);
                            this._detailInput.SetShippingCdEnabled(true);
                        }
                        else if (key206.Equals(uoeSupplier.CommAssemblyId))
                        {
                            this._detailInput.SetRemark2Enabled(true);
                            this._detailInput.SetShippingCdEnabled(true);
                        }
                        else
                        {
                            this._detailInput.SetRemark2Enabled(false);
                            this._detailInput.SetShippingCdEnabled(false);
                        }
                        break;
                    }
                }
            }
            #endregion
            // ---ADD 2011/02/25----------------<<<<

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4032�Ή�</br>
        /// <br>UpdateNote : 2011/02/25 ������ </br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// <br>UpdateNote : 2011/03/15 ������ </br>
        /// <br>             Redmine #19908�̑Ή�</br>
        /// <br>UpdateNote : 2011/03/17 ������ </br>
        /// <br>             Redmine #19971�̑Ή�</br>
        /// </remarks>
        private bool UpdateDB()
        {
            bool isSave = false;
            string retMessage = "";
            int status = 0;

            try
            {
                // ---ADD 2011/02/25----------->>>>>
                if (key205.Equals(this._uoeSupplier.CommAssemblyId)
                    || key206.Equals(this._uoeSupplier.CommAssemblyId)
                    || auto_key.Equals(this._uoeSupplier.CommAssemblyId))
                {
                    // �w�b�_�[�����͒l�̕ۑ�����
                    this._detailInput.ResetHeaderInfo();
                }
                // ---ADD 2011/02/25-----------<<<<<
                //�ۑ������̃`�F�b�N
                //if (this._detailInputAcs.IsDataChanged == false) return (isSave);// DEL 2010/03/19
                if (this.DetailInputAcs.IsDataChanged == false) return (isSave);// ADD 2010/03/19
                this.Cursor = Cursors.WaitCursor;
                // ---ADD 2011/02/25----------------->>>>>
                this._detailInput.CodeToNameUpdate(NissanInpDisplay.SystemDivCd);

                List<string> itemNameList = new List<string>();
                List<string> itemList = new List<string>();

                // ---UPD 2011/03/17------------->>>>
                if (key205.Equals(this._uoeSupplier.CommAssemblyId)
                    || key206.Equals(this._uoeSupplier.CommAssemblyId)
                    || auto_key.Equals(this._uoeSupplier.CommAssemblyId))
                {
                if (this.DetailInputAcs.SaveDataCheck(NissanInpDisplay.BusinessCode, NissanInpDisplay.SystemDivCd, out itemNameList, out itemList) != true)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B" + "\r\n" + "\r\n");

                    foreach (string s in itemNameList)
                    {
                        message.Append(s + "\r\n");
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    string itemName = "";
                    if (itemList.Count > 0)
                    {
                        itemName = itemList[0].ToString();
                    }
                    return isSave;
                }
                }
                // ---UPD 2011/03/17-------------<<<<
                // ---ADD 2011/02/25-----------------<<<<<
                StringBuilder messageBuilder = new StringBuilder();
                //if (this._detailInputAcs.GetDeleteCount() <= 0)// DEL 2010/03/19
                if (this.DetailInputAcs.GetDeleteCount() <= 0)// ADD 2010/03/19
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
                // ---ADD 2011/02/25-------------->>>>>
                else if (key206.Equals(this._uoeSupplier.CommAssemblyId) && this.DetailInputAcs.GetDeleteCount() > 114)
                {
                    messageBuilder.Append("���׍��v��114�𒴂��Ȃ��l�ɑI�����Ă��������B" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }
                // ---ADD 2011/02/25--------------<<<<<
                //else if (this._detailInputAcs.GetDeleteCount() > 152)// DEL 2010/03/19
                else if (this.DetailInputAcs.GetDeleteCount() > 152)// ADD 2010/03/19
                {
                    messageBuilder.Append("���׍��v��152�𒴂��Ȃ��l�ɑI�����Ă��������B" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }

                // ---ADD 2011/02/25-------------->>>>>
                // �t�n�d�����f�[�^�����Z�b�g���̎Z�o�p
                this.DetailInputAcs.SetCommAssemblyId(this._uoeSupplier.CommAssemblyId);
                // ---ADD 2011/02/25--------------<<<<<
                //if (this._detailInputAcs.GetBlocCount() > 19)// DEL 2010/03/19
                if (this.DetailInputAcs.GetBlocCount() > 19)// ADD 2010/03/19
                {
                    messageBuilder.Append("�����\�����s���ł��B" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;

                }

                // ----ADD 2010/12/31 ---------------->>>>
                if (this._detailInput.BoCodeCheck(NissanInpDisplay.BusinessCode, NissanInpDisplay.SystemDivCd) != true)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("���ו��ɖ����͂̍��ڂ����݂��邽�߁A�m��ł��܂���B" + "\r\n" + "\r\n");
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
                // ----ADD 2010/12/31 ----------------<<<<

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

                // --------ADD 2010/12/31-------->>>>>
                // ---UPD 2011/02/25----------->>>>>
                //if (auto_key.Equals(this._uoeSupplier.CommAssemblyId))
                if (auto_key.Equals(this._uoeSupplier.CommAssemblyId)
                    || (key205.Equals(this._uoeSupplier.CommAssemblyId) && _uoeSupplier.InqOrdDivCd == 1)
                    || key206.Equals(this._uoeSupplier.CommAssemblyId))
                // ---UPD 2011/02/25-----------<<<<<
                {
                    this.uButton_CustomerGuide.Focus();
                    ScreenEnableSet(false);
                    this.closeCheck = false;
                }
                // --------ADD 2010/12/31--------<<<<<

                // UOE������}�X�^�̎���
                UOESupplier uOESupplier = GetUOESupplier(NissanInpDisplay);

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

                // ---ADD 2011/03/15--------------->>>>>
                // 0206�̏ꍇ�AUOE������}�X�^���A�N�Z�X�ɐݒ肷��B�iWriteDB�p�j
                if (_uoeSupplier != null && key206.Equals(_uoeSupplier.CommAssemblyId))
                {
                    this.DetailInputAcs.SetUOESupplier(_uoeSupplier);
                }
                // ---ADD 2011/03/15---------------<<<<<
                // ��������
                // -----------UPD 2010/03/19------------>>>>>
                //status = this._detailInputAcs.WriteDB(this._cashRegisterNo, NissanInpDisplay.SystemDivCd, out retMessage,
                         //out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList);
                status = this.DetailInputAcs.WriteDB(this._cashRegisterNo, NissanInpDisplay.SystemDivCd, out retMessage,
                out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList);
                // -----------UPD 2010/03/19------------<<<<<

                // �_�C�A���O�����
                form.Close();

                //�ۑ������̎��s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSave = true;

                    // ���׃O���b�h�ݒ菈��
                    this._detailInput.SettingGrid();

                    // --------DEL 2010/12/31-------->>>>>
                    //SaveCompletionDialog dialog = new SaveCompletionDialog();
                    //dialog.ShowDialog(2);
                    // --------DEL 2010/12/31--------<<<<<

                    if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0
                        && stockDetailWorkList != null && stockDetailWorkList.Count > 0)
                    {
                        // --------UPD 2010/12/31-------->>>>>
                        //this.WriteTextProc(NissanInpDisplay.SystemDivCd,
                        //     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);

                        if (_uoeSupplier != null)
                        {
                            int subStatus = 0;
                            // �蓮�F0
                            if (key.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                subStatus = this.WriteTextProc(NissanInpDisplay.SystemDivCd,
                                     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                //--------ADD BY������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                DateTime dt = DateTime.Now;
                                if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + fileName))
                                {
                                    string BakFileName = preFileName + dt.ToString(timeFormat) + endFileName;
                                    File.Copy(uOESupplier.AnswerSaveFolder + "\\" + fileName, uOESupplier.AnswerSaveFolder + "\\" + BakFileName);
                                }
                                //--------ADD BY������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                // �_�C�A���O�����
                                form.Close();
                                if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                }
                            }
                            // �����F1
                            else if (auto_key.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                DateTime dt = DateTime.Now;
                                // HATTU_YYYYMMDDHHMMSS_�[���ԍ�.TXT
                                string autoFileName = preFileName + dt.ToString(timeFormat) + "_" + _cashRegisterNo.ToString("000") + endFileName;                               

                                if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
                                {
                                    return false;
                                }

                                subStatus = this.WriteAutoTextProc(NissanInpDisplay.SystemDivCd,
                                     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                //--------ADD BY������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + autoFileName))
                                {
                                    string autoBakFileName = preFileName + dt.ToString(timeFormat) + "BAK" + endFileName;
                                    File.Copy(uOESupplier.AnswerSaveFolder + "\\" + autoFileName, uOESupplier.AnswerSaveFolder + "\\" + autoBakFileName);
                                }
                                //--------ADD BY������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                // �_�C�A���O�����
                                form.Close();
                                if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    // �����X�V����
                                    subStatus = this.AutoUpdate(NissanInpDisplay.SystemDivCd, nissanFlod, autoFileName,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList, _cashRegisterNo, _uoeSupplier, out retMessage);
                                }
                            }
                            // ---ADD 2011/02/25----------------->>>>>
                            else if (key205.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                // �蓮�F0
                                if (_uoeSupplier.InqOrdDivCd == 0)
                                {
                                    subStatus = this.WriteTextProc2(NissanInpDisplay.SystemDivCd,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                    //--------ADD BY������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                    DateTime dt = DateTime.Now;
                                    if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + fileName))
                                    {
                                        string BakFileName = preFileName + dt.ToString(timeFormat) + endFileName;
                                        File.Copy(uOESupplier.AnswerSaveFolder + "\\" + fileName, uOESupplier.AnswerSaveFolder + "\\" + BakFileName);
                                    }
                                    //--------ADD BY������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                    // �_�C�A���O�����
                                    form.Close();
                                    if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                    }                                    
                                }
                                // �����F1
                                else
                                {
                                    DateTime dt = DateTime.Now;
                                    // HATTU_YYYYMMDDHHMMSS_�[���ԍ�.TXT
                                    string autoFileName = preFileName + dt.ToString(timeFormat) + "_" + _cashRegisterNo.ToString("000") + endFileName;                                    

                                    if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
                                    {
                                        return false;
                                    }

                                    subStatus = this.WriteTextProc2(NissanInpDisplay.SystemDivCd,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                    //--------ADD BY������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                    if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + autoFileName))
                                    {
                                        string autoBakFileName = preFileName + dt.ToString(timeFormat) + "BAK" + endFileName;
                                        File.Copy(uOESupplier.AnswerSaveFolder + "\\" + autoFileName, uOESupplier.AnswerSaveFolder + "\\" + autoBakFileName);
                                    }
                                    //--------ADD BY������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                    // �_�C�A���O�����
                                    form.Close();
                                    if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                        // �����X�V����
                                        subStatus = this.AutoUpdate(NissanInpDisplay.SystemDivCd, nissanFlod, autoFileName,
                                             uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList, _cashRegisterNo, _uoeSupplier, out retMessage);
                                    }
                                }
                            }
                            else if (key206.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                DateTime dt = DateTime.Now;
                                // HATTU_YYYYMMDDHHMMSS_�[���ԍ�.TXT
                                string autoFileName = preFileName + dt.ToString(timeFormat) + "_" + _cashRegisterNo.ToString("000") + endFileName;

                                if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
                                {
                                    return false;
                                }

                                #region ���ו������g�p���ĘA�g�ԍ��̃Z�b�g���s��
                                List<UOEOrderDtlWork> newUOEOrderDtlWL = new List<UOEOrderDtlWork>();
                                int count = 0;
                                int onlineNo = -1;

                                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        count++;
                                        onlineNo = uOEOrderDtlWorkList[i].OnlineNo;

                                        newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);

                                        if (uOEOrderDtlWorkList.Count == 1)
                                        {
                                            newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                        }
                                    }
                                    else
                                    {
                                        // �����ԍ����ύX���ꂽ
                                        if (onlineNo != uOEOrderDtlWorkList[i].OnlineNo)
                                        {
                                            if (count != 0)
                                            {
                                                newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i - 1]));
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);
                                            }
                                            else
                                            {
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);
                                            }

                                            if (i == uOEOrderDtlWorkList.Count - 1)
                                            {
                                                newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                            }
                                            count = 1;
                                            onlineNo = uOEOrderDtlWorkList[i].OnlineNo;
                                        }
                                        // �����ԍ����ύX�Ȃ�
                                        else
                                        {
                                            count++;

                                            if (count == 3)
                                            {
                                                count = 0;
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);
                                                newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                            }
                                            else
                                            {
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);

                                                if (i == uOEOrderDtlWorkList.Count - 1)
                                                {
                                                    newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion

                                subStatus = this.WriteTextProc2(NissanInpDisplay.SystemDivCd,
                                     newUOEOrderDtlWL, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                //--------ADD BY������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + autoFileName))
                                {
                                    string autoBakFileName = preFileName + dt.ToString(timeFormat) + "BAK" + endFileName;
                                    File.Copy(uOESupplier.AnswerSaveFolder + "\\" + autoFileName, uOESupplier.AnswerSaveFolder + "\\" + autoBakFileName);
                                }
                                //--------ADD BY������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                // �_�C�A���O�����
                                form.Close();
                                if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    // �����X�V����
                                    subStatus = this.AutoUpdate(NissanInpDisplay.SystemDivCd, nissanFlod, autoFileName,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList, _cashRegisterNo, _uoeSupplier, out retMessage);
                                }
                            }
                            // ---ADD 2011/02/25-----------------<<<<<
                        }

                        // --------UPD 2010/12/31--------<<<<<
                    }
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

            // --------ADD 2010/12/31--------->>>>>
            // ---UPD 2011/02/25----------->>>>>
            //if (auto_key.Equals(this._uoeSupplier.CommAssemblyId))
            if (auto_key.Equals(this._uoeSupplier.CommAssemblyId)
                || (key205.Equals(this._uoeSupplier.CommAssemblyId) && _uoeSupplier.InqOrdDivCd == 1)
                || key206.Equals(this._uoeSupplier.CommAssemblyId))
            // ---UPD 2011/02/25-----------<<<<<
            {
                ScreenEnableSet(true);
                this.closeCheck = true;
            }
            // --------ADD 2010/12/31---------<<<<<

            return isSave;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// ���Enable�ݒ菈��
        /// </summary>
        /// <param name="enable">enable</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : ���Enable�ݒ���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/26</br>
        /// </remarks>
        private void ScreenEnableSet(bool enable)
        {
            this.tToolbarsManager_MainMenu.Enabled = enable;
            this.panel_Header.Enabled = enable;
            this.panel_Detail.Enabled = enable;
        }
        // --------ADD 2010/12/31---------<<<<<

        /// <summary>
        /// �t�@�C�����I�[�v�����`�F�b�N
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int WriteTextProc(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            // -----------UPD 2010/03/19------------>>>>>
            //status = this._detailInputAcs.WriteText(systemDiv, out retMessage,
            //                            uOEOrderDtlWorkList);
            status = this.DetailInputAcs.WriteText(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);
            // -----------UPD 2010/03/19------------<<<<<
            return status;
        }

        /// <summary>
        /// �t�@�C�����I�[�v�����`�F�b�N
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int WriteAutoTextProc(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            status = this.DetailInputAcs.WriteAutoText(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);

            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// �t�@�C�����I�[�v�����`�F�b�N
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        private int WriteSubTextProc(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            status = this.DetailInputAcs.WriteSubText(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);

            return status;
        }

        /// <summary>
        /// �����X�V����
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="nissanFlod">�t�H���_</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <param name="cashRegisterNo">���[���ԍ�</param>
        /// <param name="uoeSupplier">UOE�}�X�^�f�[�^</param>
        /// <param name="errMess">errMess</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : �����X�V�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        private int AutoUpdate(int systemDiv, string nissanFlod, string fileName,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList, int cashRegisterNo, UOESupplier uoeSupplier, out string errMess)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMess = string.Empty;
            string autoFileName = string.Empty; // �T�u�t�@�C����

            #region �������M�f�[�^�T�u�t�@�C������
            // HATTUSUB_YYYYMMDDHHMMSS_�[���ԍ�.TXT
            DateTime dt = DateTime.Now;
            autoFileName = preSubFileName + dt.ToString(timeFormat) + "_" + cashRegisterNo.ToString("000") + endSubFileName;

            if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }

            int subStatus = this.WriteSubTextProc(NissanInpDisplay.SystemDivCd,
                                     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);


            #endregion

            // �����X�V����
            status = this._detailInputAcs.AutoUpdateProc(nissanFlod + "\\" + fileName, uoeSupplier.AnswerSaveFolder + "\\" + autoFileName, uoeSupplier, _uOEConnectInfo, out errMess);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    errMess,
                                    0,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
            }

            return status;
        }
        // --------ADD 2010/12/31---------<<<<<

        // ---ADD 2011/02/25---------------->>>>>
        /// <summary>
        /// �t�@�C�����I�[�v�����`�F�b�N(�v���O����ID���u0205�v�Ɓu0206�v�̏ꍇ)
        /// </summary>
        /// <param name="systemDiv">�V�X�e���敪</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE�����폜�f�[�^</param>
        /// <param name="stockDetailWorkDelList">�d�����׍폜�f�[�^</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/02/25</br>
        /// </remarks>
        private int WriteTextProc2(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            status = this.DetailInputAcs.WriteText2(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);
            return status;
        }

        /// <summary>
        /// ���ו������g�p���ĘA�g�ԍ��̃Z�b�g���s��(�v���O����ID���u0206�v�̏ꍇ)
        /// </summary>
        /// <param name="uOEOrderDtlWork">UOE�����f�[�^���[�N</param>
        /// <returns>UOE�����f�[�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : ���ו������g�p���ĘA�g�ԍ��̃Z�b�g���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        private UOEOrderDtlWork GetUOEOrderDtlWork(UOEOrderDtlWork uOEOrderDtlWork)
        {
            UOEOrderDtlWork work = new UOEOrderDtlWork();
            work.BoCode = " ";
            work.AcceptAnOrderCnt = 1;
            work.GoodsNoNoneHyphen = uOEOrderDtlWork.UoeRemark2;
            work.OnlineNo = uOEOrderDtlWork.OnlineNo;
            return work;
        }
        // ---ADD 2011/02/25----------------<<<<<
        # endregion �� �ۑ����� ��

        # region �� �폜���� ��
        /// <summary>
        /// �폜����
        /// </summary>
        /// <returns>true:�폜���� false:�폜���s</returns>
        /// <remarks>
        /// <br>Note       : �폜�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4032�Ή�</br>
        /// </remarks>
        bool DeleteDB()
        {
            bool retBool = false;
            int status = 0;
            string message = "";

            try
            {
                //�폜�����̃`�F�b�N
                // -----------UPD 2010/03/19------------>>>>>
                //if (this._detailInputAcs.IsDataChanged == false) return (retBool);
                //if (this._detailInputAcs.GetDeleteCount() <= 0)
                if (this.DetailInputAcs.IsDataChanged == false) return (retBool);
                if (this.DetailInputAcs.GetDeleteCount() <= 0)
                // -----------UPD 2010/03/19------------<<<<<
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

                //status = this._detailInputAcs.DeleteDB(out message);// DEL 2010/03/19
                status = this.DetailInputAcs.DeleteDB(out message);// ADD 2010/03/19

                // �_�C�A���O�����
                form.Close();

                //�폜�����̎��s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //if (this._detailInputAcs.GetNoSelectCount() > 0)// DEL 2010/03/19
                    if (this.DetailInputAcs.GetNoSelectCount() > 0)// ADD 2010/03/19
                    {
                        //�Č���
                        this._detailInput.Clear1();

                        SearchDB(NissanInpDisplay);

                        this._detailInput.SettingGrid(NissanInpDisplay.BusinessCode);

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private UOESupplier GetUOESupplier(NissanInpDisplay inpDisplay)
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void PMUOE01521UA_Load(object sender, EventArgs e)
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
            this._bfSupplier = PMUOE01521UB._supplierCd;

            // �N���A����
            this.Clear(false, false);

            // --------ADD 2010/12/31--------->>>>>
            // �w�肳�ꂽUOE������̉񓚕ۑ��t�H���_�̎擾
            if (this._uoeSupplier01521 != null && this._uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        nissanFlod = uoeSupplier.AnswerSaveFolder;
                        _uoeSupplier = uoeSupplier;

                        // �蓮�̏ꍇ�A
                        if (key.Equals(uoeSupplier.CommAssemblyId))
                        {
                            PMUOE01521UB._inqOrdDivCdFlg = 0;
                            //-----------------------------------------------------------
                            // UOE�ڑ�����}�X�^
                            //-----------------------------------------------------------
                            this.CacheUOEConnectInfo(uoeSupplier.CommAssemblyId); 
                            break;
                        }
                        // �����̏ꍇ�A
                        // ---UPD 2011/02/25------------>>>>>
                        //else if (auto_key.Equals(uoeSupplier.CommAssemblyId))
                        else if (auto_key.Equals(uoeSupplier.CommAssemblyId)
                              || key205.Equals(uoeSupplier.CommAssemblyId)
                              || key206.Equals(uoeSupplier.CommAssemblyId))
                        // ---UPD 2011/02/25------------<<<<<
                        {
                            PMUOE01521UB._inqOrdDivCdFlg = 1;
                            //-----------------------------------------------------------
                            // UOE�ڑ�����}�X�^
                            //-----------------------------------------------------------
                            this.CacheUOEConnectInfo(uoeSupplier.CommAssemblyId); 
                            break;
                        }
                        else
                        {
                            // �Ȃ��B
                        }
                    }
                }
            }

            // --------ADD 2010/12/31---------<<<<<

            this.timer_InitialSet.Enabled = true;

        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�R���g���[���C�x���g�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            bool canChangeFocus;
            int code;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (NissanInpDisplay == null) return;

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
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
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
                            NissanInpDisplay.UOESupplierCd = (Int32)tComEd_SupplierCd.Value;
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
                        NissanInpDisplay.BusinessCode = (Int32)tComboEditor_TerminalDiv.Value;
                        #endregion
                        break;
                    }

                // �[���敪 ============================================ //
                case "tComboEditor_TerminalNoDiv":
                    #region [ tComboEditor_TerminalNoDiv ]
                    NissanInpDisplay.CashRegisterNoDiv = (Int32)tComboEditor_TerminalNoDiv.Value;
                    #endregion
                    break;

                // �[���ԍ� ============================================ //
                case "tNedit_TerminalNo":
                    #region [ tNedit_TerminalNo ]
                    NissanInpDisplay.CashRegisterNo = this.tNedit_TerminalNo.GetInt();
                    #endregion
                    break;

                // �V�X�e���敪 ============================================ //
                case "tComboEditor_SysDiv":
                    #region [ tComboEditor_SysDiv ]
                    NissanInpDisplay.SystemDivCd = (Int32)tComboEditor_SysDiv.Value;
                    #endregion
                    break;

                // �I�����C���ԍ�(�J�n�j ============================================ //
                case "tNedit_St_OnlineNo":
                    #region [ St_OnlineNo ]
                    NissanInpDisplay.UOESalesOrderNoSt = tNedit_St_OnlineNo.GetInt();
                    #endregion
                    break;

                // �I�����C���ԍ�(�I���j ============================================ //
                case "tNedit_Ed_OnlineNo":
                    #region [ Ed_OnlineNo ]
                    NissanInpDisplay.UOESalesOrderNoEd = tNedit_Ed_OnlineNo.GetInt();
                    #endregion
                    break;

                // ���͓��i�J�n�j ============================================ //
                case "tDateEdit_InputDateSt":
                    #region [ tDateEdit_InputDateSt ]
                    NissanInpDisplay.SalesDateSt = tDateEdit_InputDateSt.GetDateTime();
                    #endregion
                    break;

                // ���͓��i�I���j ============================================ //
                case "tDateEdit_InputDateEd":
                    #region [ tDateEdit_InputDateEd ]
                    NissanInpDisplay.SalesDateEd = tDateEdit_InputDateEd.GetDateTime();
                    #endregion
                    break;

                // ���Ӑ溰�� ============================================ //
                case "tNedit_CustomerCode":
                    #region [ tNedit_CustomerCode ]
                    canChangeFocus = true;
                    code = this.tNedit_CustomerCode.GetInt();

                    if (NissanInpDisplay.CustomerCode != code)
                    {
                        if (code == 0)
                        {
                            NissanInpDisplay.CustomerCode = 0;
                            NissanInpDisplay.CustomerName = "";
                        }
                        else
                        {
                            string customerName = "";
                            if (GetMakerName(code, out customerName) == true)
                            {
                                NissanInpDisplay.CustomerCode = code;
                                NissanInpDisplay.CustomerName = customerName;

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
            NissanInpDisplay InpDisplayNow = this.GetDisplay();
            ArrayList arRetList = NissanInpDisplay.Compare(InpDisplayNow);

            if (arRetList.Count > 0)
            {
                // ��ʏ��N���X����ʊi�[����
                this.SetDisplay(NissanInpDisplay);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this.NissanInpDisplay.CustomerCode = customerSearchRet.CustomerCode;                    // ���Ӑ�R�[�h
            this.NissanInpDisplay.CustomerName = customerSearchRet.Name + customerSearchRet.Name2;   // ���Ӑ於��

            this.tNedit_CustomerCode.SetInt(this.NissanInpDisplay.CustomerCode);
            this.uLabel_CustomerName.Text = this.NissanInpDisplay.CustomerName;

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void timer_InitialSet_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSet.Enabled = false;

            //-----------------------------------------------------------
            // ���YWeb-UOE�p�A�g�t�@�C���̃I�[�v������
            //-----------------------------------------------------------
            if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
            {
                // --- UPD 2010/12/31 ---------------->>>>>>>>>>>>>>
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        //if (!UOESupplierFileCheck(_uoeSupplier01521[0].AnswerSaveFolder))
                        if (!UOESupplierFileCheck(uoeSupplier.AnswerSaveFolder))
                        {
                            // [����]�{�^�������[�m��]�{�^���������s�Ƃ��܂�
                            buttonDisFlg = false;
                        }
                        else
                        {
                            buttonDisFlg = true;
                        }
                        break;
                    }
                }
                // --- UPD 2010/12/31 ----------------<<<<<<<<<<<<<
            }

            SetControlFocus(this.tComEd_SupplierCd);

        }

        /// <summary>
        /// �t�@�C���i�X�g���[���j���N���[�Y
        /// </summary>
        /// <remarks>
        /// <br>Note       :  �t�@�C���i�X�g���[���j���N���[�Y����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4005�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine4032�Ή�</br>
        /// </remarks>
        public void CloseFileStreamU()
        {
            //this._detailInputAcs.CloseFileStream(_detailInputAcs.UoeFileStream);// DEL 2010/03/18
            // -----------UPD 2010/03/19------------>>>>>
            //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
            this.DetailInputAcs.CloseFileStream();
            // -----------UPD 2010/03/19------------<<<<<
        }

        # region �� �w��t�H�[�J�X�ݒ菈�� ��
        /// <summary>
        /// �w��t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w��t�H�[�J�X�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#032�Ή�</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled()
        {
            //if (this._detailInputAcs.IsDataChanged == true)// DEL 2010/03/19
            if (this.DetailInputAcs.IsDataChanged == true)// ADD 2010/03/19
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4032�Ή�</br>
        /// </remarks>
        private void SettingControlEnabled()
        {
            //if (this._detailInputAcs.IsDataChanged == true)// DEL 2010/03/19
            if (this.DetailInputAcs.IsDataChanged == true)// ADD 2010/03/19
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void tComboEditor_TerminalNoDiv_ValueChanged(object sender, EventArgs e)
        {
            Int32 code = (Int32)this.tComboEditor_TerminalNoDiv.Value;
            if (code == NissanInpDisplay.CashRegisterNoDiv) return;
            NissanInpDisplay.CashRegisterNoDiv = code;

            //�[���ԍ�
            switch (NissanInpDisplay.CashRegisterNoDiv)
            {
                //���[��
                case ctTerminalNoDiv_Own:
                    {
                        NissanInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }

                //���[��
                case ctTerminalNoDiv_Other:
                    {
                        NissanInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = true;
                        break;
                    }
                //�S�[��
                case ctTerminalNoDiv_All:
                    {
                        NissanInpDisplay.CashRegisterNo = 0;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }
            }
            this.tNedit_TerminalNo.SetInt(NissanInpDisplay.CashRegisterNo);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 ������ Redmine4005�Ή�</br>
        /// <br>UpdateNote : 2010/03/19 ������ Redmine#4032�Ή�</br>
        /// <br>UpdateNote : 2011/02/25 ������ </br>
        /// <br>             ���YUOE�������A�a�Ή����̑g�ݍ���</br>
        /// </remarks>
        private void tComEd_SupplierCd_ValueChanged(object sender, EventArgs e)
        {
            if (this._bfSupplier == 0) return;

            if (this.tComEd_SupplierCd.Value != null &&
                (int)this.tComEd_SupplierCd.Value != this._bfSupplier)
            {
                // �O�񔭒���̃t�@�C���i�X�g���[���j���N���[�Y����
                //this._detailInputAcs.CloseFileStream(this._detailInputAcs.UoeFileStream);// DEL 2010/03/18
                // -----------UPD 2010/03/19------------>>>>>
                //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
                this.DetailInputAcs.CloseFileStream();
                // -----------UPD 2010/03/19------------<<<<<
                PMUOE01521UB._supplierCd = (int)this.tComEd_SupplierCd.Value;
                this._bfSupplier = (int)this.tComEd_SupplierCd.Value;

                // ���YWeb-UOE�p�A�g�t�@�C���̃I�[�v������
                if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
                {
                    List<UOESupplier> resultList;
                    resultList = _uoeSupplier01521.FindAll(delegate(UOESupplier target)
                    {
                        if (PMUOE01521UB._supplierCd.Equals(target.UOESupplierCd))
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
                        _uoeSupplier = resultList[0];

                        nissanFlod = resultList[0].AnswerSaveFolder;

                        if (!UOESupplierFileCheck(resultList[0].AnswerSaveFolder))
                        {
                            // [����]�{�^�������[�m��]�{�^���������s�Ƃ��܂�
                            this._searchButton.SharedProps.Enabled = false;
                            this._saveButton.SharedProps.Enabled = false;
                            this.buttonDisFlg = false;
                        }
                        else
                        {
                            this.buttonDisFlg = true;

                            this._detailInput.CacheUOEGuideName_01521();

                            // �蓮�̏ꍇ�A
                            if (key.Equals(resultList[0].CommAssemblyId))
                            {
                                PMUOE01521UB._inqOrdDivCdFlg = 0;
                            }
                            // ---UPD 2011/02/25------------>>>>>
                            //else if (auto_key.Equals(resultList[0].CommAssemblyId))
                            else if (auto_key.Equals(resultList[0].CommAssemblyId)
                                || key205.Equals(resultList[0].CommAssemblyId)
                                || key206.Equals(resultList[0].CommAssemblyId))
                            // ---UPD 2011/02/25------------<<<<<
                            {
                                PMUOE01521UB._inqOrdDivCdFlg = 1;
                            }
                            else
                            {
                                // �Ȃ��B
                            }
                            
                            //-----------------------------------------------------------
                            // UOE�ڑ�����}�X�^
                            //-----------------------------------------------------------
                            this.CacheUOEConnectInfo(resultList[0].CommAssemblyId); 
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            //��ʁ����o�����N���X
            NissanInpDisplay = this.GetDisplay();

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
                                PMUOE01521UB._countFlg = true;
                            }
                            else
                            {
                                PMUOE01521UB._countFlg = false;
                            }

                            int status = SearchDB(NissanInpDisplay);

                            // ADD 2010/12/31 ------------------------------>>>>>
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                PMUOE01521UB._dataListFlg = true;
                            }
                            else
                            {
                                PMUOE01521UB._dataListFlg = false;
                            }
                            // ADD 2010/12/31 ------------------------------<<<<<

                            // ���׃O���b�h�Z���ݒ菈��
                            this._detailInput.SettingGrid(NissanInpDisplay.BusinessCode);
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
                        if (NissanInpDisplay.BusinessCode == ctTerminalDiv_Cancel)
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
                            PMUOE01521UB._countFlg = false;
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