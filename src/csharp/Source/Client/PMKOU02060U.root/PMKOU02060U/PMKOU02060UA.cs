//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2013/04/08  �C�����e : 2013/05/15�z�M��
//                                  Redmine#34806 ���j���[�N������A��ʂ����G���[������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2013/05/03  �C�����e : 2013/05/15�z�M��
//                                  Redmine#34806 #31�������O�ɏI�������ꍇ��ʂ̏�����ۑ����Ȃ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using System.IO;
using Broadleaf.Library.Text;
using System.Net.NetworkInformation;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �d��������ѕ\�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d��������ѕ\�t�H�[���N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    public partial class PMKOU02060UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {

        #region �� Constructor

        /// <summary>
        /// �d��������ѕ\UI�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\UI�N���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02060UA()
        {
            //������
            InitializeComponent();

            //�G���[�`�F�b�N
            hasCheckError = false;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            //���O�C���S���҂̋��_
            _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            //�d����A�N�Z�X
            this._supplierAcs = new SupplierAcs();

            // ���O�C���S����
            this._loginEmployee = LoginInfoAcquisition.Employee.Clone();

            //���_���ݒ�A�N�Z�X�N���X
            this._mSecInfoAcs = new SecInfoAcs();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

        }
        #endregion �� Constructor

        #region �� Private Member

        #region �� Interface member

        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B  
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;

        #endregion �� Interface member

        #region
        // ��ƃR�[�h
        private string _enterpriseCode = string.Empty;

        // ����S�̐ݒ�}�X�^
        private SalesTtlStAcs _salesTtlStAcs;
        private SalesTtlSt _salesTtlSt;

        //���_�A�N�Z�X
        private SecInfoAcs _mSecInfoAcs = null;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();

        //���t�擾���i
        private DateGetAcs _dateGet;

        //�d����A�N�Z�X
        SupplierAcs _supplierAcs;

        //���O�C���S���ҋ��_�R�[�h
        private string _loginSectionCode = string.Empty;

        //���O�C���S����
        private Employee _loginEmployee = null;

        //�G���[�`�F�b�N
        private bool hasCheckError = false;

        private Control _prevControl = null;

        #endregion

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMKOU02060UA";
        // �v���O����ID
        private const string ct_PGID = "PMKOU02060U";
        // ���[����
        private const string ct_PrintName = "�d��������ѕ\";
        // ���[�L�[	
        private const string ct_PrintKey = "c1521de4-9268-48d3-af87-ea5ad569213b";
        //�S��
        private const string ct_All = "00";

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_CustomerConditionGroup = "CustomerConditionGroup";
        private const string ct_ExBarGroupNm_ExtraConditionCodeGroup = "ExtraConditionCodeGroup";

        //�Ώ۔N���@�ݒ�`�F�b�N
        private const string ct_MustInputError = "��ݒ肵�Ă��������B";

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�̓��͂��s���ł��B";
        const string ct_NoInput = "����͂��ĉ������B";
        const string ct_RangeError = "�͈̔͂Ɍ�肪����܂��B";
        const string ct_RangeOverError = "�͂R�����͈͓̔��œ��͂��Ă��������B";

        #endregion �� Interface member

        #endregion

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[</summary>
        /// <value>PrintKey</value>               
        /// <remarks>���[�L�[�擾�v���p�e�B </remarks>  
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> ���[��</summary>
        /// <value>PrintName</value>               
        /// <remarks>���[���擾�v�v���p�e�B </remarks>  
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        /// <summary> �v�㋒�_�I��\��</summary>
        /// <value>VisibledSelectAddUpCd</value>               
        /// <remarks>�v�㋒�_�I��\���擾���̓Z�b�g�v�v���p�e�B</remarks>  
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
            set { _visibledSelectAddUpCd = value; }
        }

        /// <summary> ���_�I�v�V�����v</summary>
        /// <value>IsOptSection</value>               
        /// <remarks>���_�I�v�V�����v�擾���̓Z�b�g�v�v���p�e�B</remarks>  
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> �{�Ћ@�\</summary>
        /// <value>IsMainOfficeFunc</value>               
        /// <remarks>�{�Ћ@�\�擾���̓Z�b�g�v���p�e�B</remarks>  
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� IPrintConditionInpType �����o

        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        /// <remarks>�e�c�[���o�[�ݒ�C�x���g�����s���܂��B</remarks>   
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^�����</summary>
        /// <value>CanExtract</value>               
        /// <remarks>���o�{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^�����</summary>
        /// <value>CanPdf</value>               
        /// <remarks>PDF�o�̓{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^�����</summary>
        /// <value>CanPrint</value>               
        /// <remarks>����{�^����Ԏ擾�v���p�e�B </remarks> 
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>���o�{�^���\���L���擾�v���p�e�B </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L��</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF�o�̓{�^���\���L���v���p�e�B�擾�v���p�e�B </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\��</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>����{�^���\���擾�v���p�e�B </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.StockDateStRF_tDateEdit);
            saveCtrAry.Add(this.StockDateEdRF_tDateEdit);
            saveCtrAry.Add(this.InputDayStRF_tDateEdit);
            saveCtrAry.Add(this.InputDayEdRF_tDateEdit);

            saveCtrAry.Add(this.tComboEditor_NewPageType);
            saveCtrAry.Add(this.tNedit_SupplierCd_St);
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);

            saveCtrAry.Add(this.tComboEditor_WayToOrderType);
            saveCtrAry.Add(this.tComboEditor_StockOrderDivCdType);
            saveCtrAry.Add(this.tComboEditor_SalesType);
            saveCtrAry.Add(this.tComboEditor_StockUnitChngDivType);


            saveCtrAry.Add(this.GrsProfitCheckLower_tNedit);
            saveCtrAry.Add(this.GrossMarginSt_Nedit);
            saveCtrAry.Add(this.GrossMargin2Ed_Nedit);
            saveCtrAry.Add(this.GrossMargin3Ed_Nedit);
            saveCtrAry.Add(this.GrsProfitCheckBest_tNedit);
            saveCtrAry.Add(this.GrsProfitCheckUpper_tNedit);
            saveCtrAry.Add(this.GrossMargin1Mark_tEdit);
            saveCtrAry.Add(this.GrossMargin2Mark_tEdit);
            saveCtrAry.Add(this.GrossMargin3Mark_tEdit);
            saveCtrAry.Add(this.GrossMargin4Mark_tEdit);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note		: ���o�������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�d��������ѕ\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // ���o�����N���X
            StockSalesResultInfoMainCndtn extrInfo = new StockSalesResultInfoMainCndtn();

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            // ���o�����̐ݒ�
            printInfo.jyoken = extrInfo;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.uiMemInput1.OptionCode = "0";

            return;
        }

        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            if (this._prevControl != null)
            {
                hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tArrowKeyControl1_ChangeFocus(this, e);
            }

            bool status = true;

            if (hasCheckError)
            {
                status = false;
                return status;
            }


            string message;
            Control errControl = null;

            // ��ʓ��͏����`�F�b�N
            bool result = this.ScreenInputCheck(out message, ref errControl);
            if (!result)
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0);
                if (errControl != null) errControl.Focus();
            }
            return result;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <param name="mode"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ���t�`�F�b�N�����Ăяo�����s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int range)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode, false);

            if (tde_St_OrderDataCreateDate.Name == "InputDayStRF_tDateEdit")
            {
                if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver)
                {
                    cdrResult = DateGetAcs.CheckDateRangeResult.OK;
                }
            }

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���͓��t�`�F�b�N�����Ăяo��(�͈̓`�F�b�N�Ȃ��A������OK)
        /// </summary>
        /// <param name="cdrResult">�`�F�b�N����</param>
        /// <param name="tde_St_AddUpADate">���͓��i�J�n�j</param>
        /// <param name="tde_Ed_AddUpADate">���͓��i�I���j</param>
        /// <param name="mode">���[�h</param>
        /// <param name="range">�͈�</param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        /// <remarks>
        /// <br>Note		: ���͓��t�`�F�b�N�����Ăяo��(�͈̓`�F�b�N�Ȃ��A������OK)���s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit tde_St_AddUpADate,
            ref TDateEdit tde_Ed_AddUpADate,
            bool mode,
            int range
        )
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private bool ScreenInputCheck(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            DateGetAcs.CheckDateRangeResult cdrResult;

            // �d�����i�J�n�E�I���j
            //if ((this.StockDateStRF_tDateEdit.LongDate != 0) ||
            //    (this.StockDateEdRF_tDateEdit.LongDate != 0))
            //{
            if (CallCheckInputDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, false, 3) == false)   // ADD 2008/07/16
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        //{
                        //    message = "�d��������͂��ĉ������B";
                        //    errControl = this.StockDateStRF_tDateEdit;
                        //}
                        //break;
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = "�d�����̓��͂��s���ł��B";
                            errControl = this.StockDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        //{
                        //    message = "�d��������͂��ĉ������B";
                        //    errControl = this.StockDateEdRF_tDateEdit;
                        //}
                        //break;
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = "�d�����̓��͂��s���ł��B";
                            errControl = this.StockDateEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            //message = "���t�͈͎̔w��Ɍ�肪����܂�";
                            message = "�d�����͈̔͂Ɍ�肪����܂��B";
                            errControl = this.StockDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        //{
                        //    //message = "���t�͂R�����͈̔͂œ��͂��ĉ�����";
                        //    message = "�d�����͂R�����͈̔͂œ��͂��Ă��������B";
                        //    errControl = this.StockDateStRF_tDateEdit;
                        //}
                        //break;
                        return true;
                }
                return result;
            }
            //}
            //else
            //{
            //    // �J�n���ƏI�����̗���������
            //    message = "�d��������͂��ĉ������B";
            //    errControl = this.StockDateStRF_tDateEdit;
            //    return result;
            //}


            // ���͓��t�i�J�n�`�I���j
            //if (CallCheckInputDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, false, 3) == false)   
            if (CallCheckInputDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, false, 3) == false)   
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("���͓�{0}", ct_InputError);
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        return true;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("���͓�{0}", ct_InputError);
                            errControl = this.InputDayEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("���͓�{0}", ct_RangeError);
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        //{
                        //    message = string.Format("���͓�{0}", ct_RangeOverError);
                        //    errControl = this.InputDayStRF_tDateEdit;
                        //}
                        //break;
                        return true;
                }
                //result = false;
                //return result;
                return result;
            }


            // �d����͈̓`�F�b�N
            if ((this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                (this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
            {
                message = "�d����͈̔͂Ɍ�肪����܂��B";
                errControl = this.tNedit_SupplierCd_St;
                return result;
            }


            // �e���`�F�b�N�̓��͔͈� �󔒂��ƃG���[�\��
            if (this.GrsProfitCheckLower_tNedit.Text == "")
            {
                message = "�e���`�F�b�N����͂��ĉ������B";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // �e���`�F�b�N�̓K���Ə���̃`�F�b�N��ύX 
            if ((this.GrsProfitCheckBest_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckBest_tNedit.Text) == 0.0))
            {
                message = "�e���`�F�b�N����͂��ĉ������B";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }


            if ((this.GrsProfitCheckUpper_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckUpper_tNedit.Text) == 0.0))
            {
                message = "�e���`�F�b�N����͂��ĉ������B";
                errControl = this.GrsProfitCheckUpper_tNedit;
                return result;
            }

            // �e���`�F�b�N�͈̔͂������l�̏ꍇ�G���[�Ƃ��� 
            if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) >= 0))
            {
                message = "�e���`�F�b�N�͈̔͂Ɍ�肪����܂��B";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // ������K���l���傫���ƃG���[�\��
            if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) >= 0))
            {
                message = "�e���`�F�b�N�͈̔͂Ɍ�肪����܂��B";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            return true;
        }

        #endregion
        #endregion

        #region �� IPrintConditionInpTypeSelectedSection �����o
        #region �� ���_�I������
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();
                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }
            }
            // ���_�I��������������
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }

        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈���i�����̕K�v���Ȃ��j
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: �����̕K�v���Ȃ�</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂ŁA�����̕K�v���Ȃ�
        }
        #endregion

        #region �� �����I�����_�ݒ菈��
        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, wk);
            }
        }
        #endregion

        #region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region �� �v�㋒�_�I������( �����̕K�v���Ȃ� )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: �����̕K�v���Ȃ�</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŏ����̕K�v���Ȃ�
        }
        #endregion
        #endregion

        #region �� Control Event
        #region �� PMKOU02060UA
        #region �� PMKOU02060UA_Load Event
        /// <summary>
        /// PMKOU02060UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ���������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void PMKOU02060UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // ���_�I�v�V�����L���`�F�b�N
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                _isOptSection = true;
            }
            else
            {
                _isOptSection = false;
            }

            // ����S�̐ݒ�}�X�^����e�����Ƒe���}�[�N���擾����
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._salesTtlSt = new SalesTtlSt();
            int status = 0;
            ArrayList retList = null;

            // ���_�R�[�h"0"�̃��R�[�h���擾 
            status = this._salesTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (SalesTtlSt wkSalesTtlSt in retList)
                {
                    if ((wkSalesTtlSt.SectionCode.Trim().Equals(this._loginSectionCode.TrimEnd())) 
                        && (0==wkSalesTtlSt.LogicalDeleteCode))
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                        break;
                    }

                    if ((wkSalesTtlSt.SectionCode.Trim().Equals(ct_All))
                        &&(0==wkSalesTtlSt.LogicalDeleteCode))
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                    }
                }
            }

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
        }
        #endregion
        #endregion �� PMKOU02060UA

        #region �� Initialize_Timer
        #region �� Tick Event
        /// <summary>
        /// Tick �C�x���g                                               
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>                             
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : timer tick���ɔ������܂����s���B</br>                  
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = string.Empty;

                this.Initialize_Timer.Enabled = false;

                // ��ʏ����\��
                int status = this.InitialScreenSetting(out errMsg);

                // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
                if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
            }
            finally
            {
                // �����t�H�[�J�X�ݒ�
                this.StockDateStRF_tDateEdit.Focus();
                _prevControl = this.StockDateStRF_tDateEdit;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion �� Initialize_Timer

        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private int InitialScreenSetting(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);

                // �d����
                this.StockDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                this.StockDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                this.StockDateStRF_tDateEdit.SetLongDate(nowLongDate);
                this.StockDateEdRF_tDateEdit.SetLongDate(nowLongDate);

                //����
                tComboEditor_NewPageType.SelectedIndex = 0;
                //�o�͎w��
                this.tComboEditor_WayToOrderType.SelectedIndex = 0;
                //�ݎ���w��
                this.tComboEditor_StockOrderDivCdType.SelectedIndex = 0;
                //����`�[�w��
                this.tComboEditor_SalesType.SelectedIndex = 0;
                //�����w��
                this.tComboEditor_StockUnitChngDivType.SelectedIndex = 0;

                // �e���`�F�b�N�̏����l(����S�̐ݒ�}�X�^����ǂݍ���)
                //�e�����̉����l
                this.GrsProfitCheckLower_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckLower);

                //�e�����̓K���l
                this.GrsProfitCheckBest_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckBest);

                //�e�����̏���l
                this.GrsProfitCheckUpper_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckUpper);

                //�e���}�[�N(�����l�����̋L��)
                this.GrossMargin1Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkLowSign.Trim();

                //�e���}�[�N(�K���l���牺���l�܂ł̋L��)
                this.GrossMargin2Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkBestSign.Trim();

                //�e���}�[�N(����l����K���l�܂ł̋L��)
                this.GrossMargin3Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkUprSign.Trim();

                //�e���}�[�N(�e���`�F�b�N�̏���l�I�[�o�[�̋L��)
                this.GrossMargin4Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkMaxSign.Trim();

                // �K�C�h�{�^���̃A�C�R���ݒ�
                this.SetIconImage(this.SupplierCdSt_GuideBtn, Size16_Index.STAR1);
                this.SetIconImage(this.SupplierCdEd_GuideBtn, Size16_Index.STAR1);

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();

                //--- ADD By ������ 2013/05/03 For Redmine #34806 #31---->>>>>
                //�������O�ɏI�������ꍇ��ʂ̏�����ۑ����Ȃ�
                uiMemInput1.WriteOnClose = true;
                //--- ADD By ������ 2013/05/03 For Redmine #34806 #31----<<<<<
            }

            catch (Exception ex)
            {

                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }


        /// <summary> 
        /// UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g 
        /// </summary> 
        /// <param name="targetControls">�R���|�[�l���g</param> 
        /// <param name="customizeData">�ۑ��f�[�^</param> 
        /// <remarks> 
        /// <br>Programmer : ���痈 </br> 
        /// <br>Date       : 2009.05.11</br> 
        /// <br>���s�����`�F�b�N�{�b�N�X�̏�Ԃ𕜌�����B</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                this.StockDateStRF_tDateEdit.LongDate = int.Parse(customizeData[0]);
                this.StockDateEdRF_tDateEdit.LongDate = int.Parse(customizeData[1]);
                this.InputDayStRF_tDateEdit.LongDate = int.Parse(customizeData[2]);
                this.InputDayEdRF_tDateEdit.LongDate = int.Parse(customizeData[3]);
                this.tComboEditor_NewPageType.SelectedIndex = int.Parse(customizeData[4]);
                if (!"-1".Equals(customizeData[5]))
                {
                    this.tNedit_SupplierCd_St.SetInt(int.Parse(customizeData[5]));
                }
                if (!"-1".Equals(customizeData[6]))
                {
                    this.tNedit_SupplierCd_Ed.SetInt(int.Parse(customizeData[6]));
                }
                this.tComboEditor_WayToOrderType.SelectedIndex = int.Parse(customizeData[7]);
                this.tComboEditor_StockOrderDivCdType.SelectedIndex = int.Parse(customizeData[8]);
                this.tComboEditor_SalesType.SelectedIndex = int.Parse(customizeData[9]);
                this.tComboEditor_StockUnitChngDivType.SelectedIndex = int.Parse(customizeData[10]);

                this.GrsProfitCheckLower_tNedit.Text = customizeData[11];
                this.GrossMarginSt_Nedit.Text = customizeData[12];
                this.GrossMargin2Ed_Nedit.Text = customizeData[13];
                this.GrossMargin3Ed_Nedit.Text = customizeData[14];
                this.GrsProfitCheckBest_tNedit.Text = customizeData[15];
                this.GrsProfitCheckUpper_tNedit.Text = customizeData[16];
                this.GrossMargin1Mark_tEdit.Text = customizeData[17];
                this.GrossMargin2Mark_tEdit.Text = customizeData[18];
                this.GrossMargin3Mark_tEdit.Text = customizeData[19];
                this.GrossMargin4Mark_tEdit.Text = customizeData[20];


            }
        }

        /// <summary> 
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g 
        /// </summary> 
        /// <param name="targetControls">�R���|�[�l���g</param> 
        /// <param name="customizeData">�ۑ��f�[�^</param> 
        /// <remarks> 
        /// <br>Programmer : ���痈</br> 
        /// <br>Date       : 2009.05.11</br> 
        /// <br>���s�����`�F�b�N�{�b�N�X�̏�Ԃ�ۑ�����B</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[21];
            customizeData[0] = this.StockDateStRF_tDateEdit.LongDate.ToString();
            customizeData[1] = this.StockDateEdRF_tDateEdit.LongDate.ToString();
            customizeData[2] = this.InputDayStRF_tDateEdit.LongDate.ToString();
            customizeData[3] = this.InputDayEdRF_tDateEdit.LongDate.ToString();

            //customizeData[4] = Convert.ToInt32(tComboEditor_NewPageType.SelectedItem.DataValue).ToString();// DEL By ������ 2013/04/08 For Redmine #34806
            customizeData[4] = tComboEditor_NewPageType.SelectedIndex.ToString();// ADD By ������ 2013/04/08 For Redmine #34806
            if (!string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text))
            {
                customizeData[5] = this.tNedit_SupplierCd_St.GetInt().ToString();
            }
            else
            {
                customizeData[5] = "-1";
            }
            if (!string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text))
            {
                customizeData[6] = this.tNedit_SupplierCd_Ed.GetInt().ToString();
            }
            else
            {
                customizeData[6] = "-1";
            }

            //------------ DEL By ������ 2013/04/08 For Redmine #34806----------------------------------------->>>>>
            //customizeData[7] = Convert.ToInt32(tComboEditor_WayToOrderType.SelectedItem.DataValue).ToString();
            //customizeData[8] = Convert.ToInt32(tComboEditor_StockOrderDivCdType.SelectedItem.DataValue).ToString();
            //customizeData[9] = Convert.ToInt32(tComboEditor_SalesType.SelectedItem.DataValue).ToString();
            //customizeData[10] = Convert.ToInt32(tComboEditor_StockUnitChngDivType.SelectedItem.DataValue).ToString();
            //------------ DEL By ������ 2013/04/08 For Redmine #34806-----------------------------------------<<<<<
            //------------ ADD By ������ 2013/04/08 For Redmine #34806----------------------------------------->>>>>
            customizeData[7] = tComboEditor_WayToOrderType.SelectedIndex.ToString();
            customizeData[8] = tComboEditor_StockOrderDivCdType.SelectedIndex.ToString();
            customizeData[9] = tComboEditor_SalesType.SelectedIndex.ToString();
            customizeData[10] = tComboEditor_StockUnitChngDivType.SelectedIndex.ToString();
            //------------ ADD By ������ 2013/04/08 For Redmine #34806-----------------------------------------<<<<<

            customizeData[11] = this.GrsProfitCheckLower_tNedit.Text;
            customizeData[12] = this.GrossMarginSt_Nedit.Text;
            customizeData[13] = this.GrossMargin2Ed_Nedit.Text;
            customizeData[14] = this.GrossMargin3Ed_Nedit.Text;
            customizeData[15] = this.GrsProfitCheckBest_tNedit.Text;
            customizeData[16] = this.GrsProfitCheckUpper_tNedit.Text;
            customizeData[17] = this.GrossMargin1Mark_tEdit.Text;
            customizeData[18] = this.GrossMargin2Mark_tEdit.Text;
            customizeData[19] = this.GrossMargin3Mark_tEdit.Text;
            customizeData[20] = this.GrossMargin4Mark_tEdit.Text;
        }

        /// <summary>
        /// Control.Click �C�x���g(SupplierCdSt_GuideBtn)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �d����i�J�n�j�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(SupplierCdEd_GuideBtn)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �d����i�I���j�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // 2008.10.02 30413 ���� �t�H�[�J�X�����ǉ� >>>>>>START
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 ���� �t�H�[�J�X�����ǉ� <<<<<<END
            }
        }

        /// <summary>
        /// �e���`�F�b�N�̉���Control.ValueChanged �C�x���g(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̉���Control.ValueChanged�ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckLower_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMarginSt_Nedit.Text = this.GrsProfitCheckLower_tNedit.Text;
        }

        /// <summary>
        /// �e���`�F�b�N�̍œK.ValueChanged �C�x���g(GrsProfitCheckBest_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̍œK.ValueChanged�ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckBest_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMargin2Ed_Nedit.Text = this.GrsProfitCheckBest_tNedit.Text;
        }

        /// <summary>
        /// �e���`�F�b�N�̏��.ValueChanged �C�x���g(GrsProfitCheckUpper_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̏��.ValueChanged�ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckUpper_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMargin3Ed_Nedit.Text = this.GrsProfitCheckUpper_tNedit.Text;
        }

        /// <summary>
        /// Control.Leave �C�x���g(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̉����l����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckLower_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // ��̏ꍇ�́A�����l��ݒ�
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave �C�x���g(GrsProfitCheckBest_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̓K���l����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckBest_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // ��̏ꍇ�́A�����l��ݒ�
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave �C�x���g(GrsProfitCheckUpper_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̏���l����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void GrsProfitCheckUpper_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // ��̏ꍇ�́A�����l��ݒ�
                tNedit.Text = "0.0";
            }
        }

        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>PrintSettingGroup
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_CustomerConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtraConditionCodeGroup))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region �� GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_CustomerConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtraConditionCodeGroup))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        #endregion

        #endregion

        #region �� Private Method
        #region �� ��ʏ������֌W





        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ���L�[�ł̃t�H�[�J�X�ړ��C�x���g���s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // �K�C�h�{�^���J�ڐ��� >>>>>>START
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���o�͎w��
                        e.NextCtrl = this.tComboEditor_WayToOrderType;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                //if (e.Key == Keys.Tab)
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_WayToOrderType)
                    {
                        // �o�͎w�聨�d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }

            //leave event
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;
            switch (e.PrevCtrl.Name)
            {
                //�d����R�[�h(�J�n)
                case "tNedit_SupplierCd_St":
                    if ((!string.IsNullOrEmpty(tNedit_SupplierCd_St.Text))
                         && (!IsNumber(tNedit_SupplierCd_St.Text)))
                    {
                        tNedit_SupplierCd_St.Text = string.Empty;
                        tNedit_SupplierCd_St.Focus();
                        return;
                    }
                    break;
                //�d����R�[�h(�I��)
                case "tNedit_SupplierCd_Ed":
                    if ((!string.IsNullOrEmpty(tNedit_SupplierCd_Ed.Text))
                        && (!IsNumber(tNedit_SupplierCd_Ed.Text)))
                    {
                        tNedit_SupplierCd_Ed.Text = string.Empty;
                        tNedit_SupplierCd_Ed.Focus();
                        return;
                    }
                    break;
                //�e������ 2
                case "GrsProfitCheckLower_tNedit":
                    if ((!string.IsNullOrEmpty(GrsProfitCheckLower_tNedit.Text))
                        && (!IsNumberOrDot(GrsProfitCheckLower_tNedit.Text)))
                    {
                        GrsProfitCheckLower_tNedit.Text = string.Empty;
                        GrsProfitCheckLower_tNedit.Focus();
                        return;
                    }
                    break;
                //�e������ 4
                case "GrsProfitCheckBest_tNedit":
                    if ((!string.IsNullOrEmpty(GrsProfitCheckBest_tNedit.Text))
                        && (!IsNumberOrDot(GrsProfitCheckBest_tNedit.Text)))
                    {
                        GrsProfitCheckBest_tNedit.Text = string.Empty;
                        GrsProfitCheckBest_tNedit.Focus();
                        return;
                    }
                    break;
                //�e������ 6
                case "GrsProfitCheckUpper_tNedit":
                    if ((!string.IsNullOrEmpty(GrsProfitCheckUpper_tNedit.Text))
                        && (!IsNumberOrDot(GrsProfitCheckUpper_tNedit.Text)))
                    {
                        GrsProfitCheckUpper_tNedit.Text = string.Empty;
                        GrsProfitCheckUpper_tNedit.Focus();
                        return;
                    }
                    break;
                default: return;
            }
        }

        /// <summary>
        /// �����𔻒f����
        /// </summary>
        /// <param name="s">str</param>
        /// <remarks>
        /// <br>Note		: �����𔻒f�������s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �����𔻒f����
        /// </summary>
        /// <param name="s">str</param>
        /// <remarks>
        /// <br>Note		: �����𔻒f�������s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private static bool IsNumberOrDot(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            char dotChar = '.';
            for (int i = 0; i < str.Length; i++)
            {
                if ((dotChar.Equals(str[i])) || (Char.IsNumber(str[i])))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date	   : 2009.05.11</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date	   : 2009.05.11</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(StockSalesResultInfoMainCndtn extraInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {

                // ���_�I�v�V����
                extraInfo.IsOptSection = this._isOptSection;
                // ��ƃR�[�h
                extraInfo.EnterpriseCode = this._enterpriseCode;

                // �I�����_
                extraInfo.CollectAddupSecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

                // �d����(�J�n)        
                extraInfo.StStockDate = this.StockDateStRF_tDateEdit.GetLongDate();
                // �d����(�I��)        
                extraInfo.EdStockDate = this.StockDateEdRF_tDateEdit.GetLongDate();

                // �d����(�J�n)        
                extraInfo.StInputDay = this.InputDayStRF_tDateEdit.GetLongDate();
                // �d����(�I��)        
                extraInfo.EdInputDay = this.InputDayEdRF_tDateEdit.GetLongDate();

                //����
                extraInfo.NewPageType = Convert.ToInt32(tComboEditor_NewPageType.SelectedItem.DataValue);
                extraInfo.NewPageTypeName = Convert.ToString(tComboEditor_NewPageType.SelectedItem.DisplayText);

                // �d����(�J�n)
                extraInfo.StSupplierCd = this.tNedit_SupplierCd_St.GetInt();

                // �d����(�I��)
                extraInfo.EdSupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

                //�o�͎w��
                extraInfo.WayToOrderType = Convert.ToInt32(tComboEditor_WayToOrderType.SelectedItem.DataValue);
                extraInfo.WayToOrderTypeName = Convert.ToString(tComboEditor_WayToOrderType.SelectedItem.DisplayText);

                //�݌Ɏ��w��
                extraInfo.StockOrderDivCdType = Convert.ToInt32(tComboEditor_StockOrderDivCdType.SelectedItem.DataValue);
                extraInfo.StockOrderDivCdTypeName = Convert.ToString(tComboEditor_StockOrderDivCdType.SelectedItem.DisplayText);

                //����`�[�w��
                extraInfo.SalesType = Convert.ToInt32(tComboEditor_SalesType.SelectedItem.DataValue);
                extraInfo.SalesTypeName = Convert.ToString(tComboEditor_SalesType.SelectedItem.DisplayText);

                //�����w��
                extraInfo.StockUnitChngDivType = Convert.ToInt32(tComboEditor_StockUnitChngDivType.SelectedItem.DataValue);
                extraInfo.StockUnitChngDivTypeName = Convert.ToString(tComboEditor_StockUnitChngDivType.SelectedItem.DisplayText);

                //�e���`�F�b�N����
                extraInfo.GrsProfitCheckLower = double.Parse(this.GrsProfitCheckLower_tNedit.Text);

                //�e���`�F�b�N2
                extraInfo.GrossMarginSt = this.GrossMarginSt_Nedit.GetValue();

                //�e���`�F�b�N3
                extraInfo.GrossMargin2Ed = this.GrossMargin2Ed_Nedit.GetValue();

                //�e���`�F�b�N4
                extraInfo.GrossMargin3Ed = this.GrossMargin3Ed_Nedit.GetValue();

                //�e���`�F�b�N�K��
                extraInfo.GrsProfitCheckBest = double.Parse(this.GrsProfitCheckBest_tNedit.Text);

                //�e���`�F�b�N���
                extraInfo.GrsProfitCheckUpper = double.Parse(this.GrsProfitCheckUpper_tNedit.Text);

                //�e���`�F�b�N1(�}�[�N)
                extraInfo.GrossMargin1Mark = this.GrossMargin1Mark_tEdit.Text;

                //�e���`�F�b�N2(�}�[�N)
                extraInfo.GrossMargin2Mark = this.GrossMargin2Mark_tEdit.Text;

                //�e���`�F�b�N3(�}�[�N)
                extraInfo.GrossMargin3Mark = this.GrossMargin3Mark_tEdit.Text;

                //�e���`�F�b�N4(�}�[�N)
                extraInfo.GrossMargin4Mark = this.GrossMargin4Mark_tEdit.Text;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CheckOnline()
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
        /// <remarks>
        /// <br>Note		: �����[�g�ڑ��\������s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private bool CheckRemoteOn()
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

        #endregion

    }
}