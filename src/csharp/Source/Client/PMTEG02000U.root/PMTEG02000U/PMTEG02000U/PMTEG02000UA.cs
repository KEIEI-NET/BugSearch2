//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�m�F�\
// �v���O�����T�v   : ��`�m�F�\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��`�m�F�\ ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�m�F�\PDF�o�͑�����s���N���X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public partial class PMTEG02000UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02000UA()
        {
            InitializeComponent();
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion �� Constructor

        #region �� Const Memebers ��
        //������
        private const string STR_DEPOSITDATE = "������";
        //�x����
        private const string STR_PAYMENTDATE = "�x����";
        //�`�F�b�N�����b�Z�[�W�u���㌎�������擾�̏��������ŃG���[���������܂����B�v
        private const string MSG_TOTALDAYREC_INITIALIE_FAILED = "���㌎�������擾�̏��������ŃG���[���������܂����B";
        //�`�F�b�N�����b�Z�[�W�u�d�����������擾�̏��������ŃG���[���������܂����B�v
        private const string MSG_TOTALDAYPAY_INITIALIE_FAILED = "�d�����������擾�̏��������ŃG���[���������܂����B";
        #endregion �� Const Memebers ��

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

        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = string.Empty;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private TegataConfirmReport _tegataConfirmReport;

        // �K�C�h�n�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;

        //���t�擾���i
        private DateGetAcs _dateGet;

        // �t�H�[�J�XControl
        private Control _prevControl = null;

        // �`�F�b�N�G���[
        private bool hasCheckError = false;

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
        private const string ct_ClassID = "PMTEG02000UA";
		// �v���O����ID
        private const string ct_PGID = "PMTEG02000U";
		//// ���[����
        private const string PDF_PRINT_NAME1 = "����`�m�F�\";
        private const string PDF_PRINT_NAME2 = "�x����`�m�F�\";
		private string _printName = string.Empty;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "bf814cb3-97d8-4836-a2bd-618e232b300f";
        
		private string _printKey = PDF_PRINT_KEY;
		#endregion �� Interface member
        #endregion Private Const

        #region �� IPrintConditionInpType �����o

        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
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

        #region �� Public Method

        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note		: ���o�������s���B</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;
            string errMessage = "";
            Control errComponent = null;
            
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                // �t�H�[�J�X�A�E�g����
                if (this._prevControl != null)
                {
                    hasCheckError = false;
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                    this.tArrowKeyControl1_ChangeFocus(this, e);
                }
                if (hasCheckError)
                {
                    status = false;
                }

                status = false;
            }
            return status;
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
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "��`�m�F�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            if (this._tegataConfirmReport.DraftDivide == 0)
                this._printName = PDF_PRINT_NAME1;
            else
                this._printName = PDF_PRINT_NAME2;
            printInfo.prpnm = this._printName;

            // �e���v���[�g�̑I��
            if (this._tegataConfirmReport.DraftDivide == 0)
            {
                printInfo.PrintPaperSetCd = 0;
            }
            else
            {
                printInfo.PrintPaperSetCd = 1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._tegataConfirmReport;
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
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._tegataConfirmReport = new TegataConfirmReport();

            // �����^�`�F�b�N
            this.Show();

            return;
        }
        #endregion

        #endregion �� Public Method

        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return _printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Control Event
        #region �� PMTEG02000UA
        #region �� PMTEG02000UA_Load Event
        /// <summary>
        /// PMTEG02000UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void PMTEG02000UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            // ��ʃX�L���ύX		
            this._controlScreenSkin.SettingScreenSkin(this);		
            // �c�[���o�[�{�^���ݒ�C�x���g�N�� 
            ParentToolbarSettingEvent(this);						    
            // �������t�H�[�J�X
            this.Cursor = Cursors.WaitCursor;
            // �d���x���Ǘ��I�v�V����(*1)�ɂ��A�����t�H�[�J�X�ʒu��ύX����
            int option = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            // ���|�L�̏ꍇ�A�����t�H�[�J�X�� ��`�敪�Ƃ���B
            if (0 < option)
            {
                this.tComboEditor_DraftDivide.Focus();
                _prevControl = tComboEditor_DraftDivide;
            }
            // ���|���̏ꍇ�A�����t�H�[�J�X�� �������Ƃ��A��`�敪�͓��͕s�i�O���[�A�E�g�j�Ƃ���B
            else
            {
                this.tDateEdit_DepositDate_St.Focus();
                _prevControl = tDateEdit_DepositDate_St;
                this.tComboEditor_DraftDivide.Enabled = false;
            }

            this.Cursor = Cursors.Default;

        }
        #endregion

        #region �� tArrowKeyControl1
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_DraftDivide)
                    {
                        // ��`�敪��������(�J�n)
                        e.NextCtrl = this.tDateEdit_DepositDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_St)
                    {
                        // ������(�J�n)��������(�I��)
                        e.NextCtrl = this.tDateEdit_DepositDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_Ed)
                    {
                        // ������(�I��)����`�敪
                        e.NextCtrl = this.tComboEditor_DraftDivide;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_DraftDivide)
                    {
                        // ��`�敪��������(�I��)
                        e.NextCtrl = this.tDateEdit_DepositDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_Ed)
                    {
                        // ������(�I��)��������(�J�n)
                        e.NextCtrl = this.tDateEdit_DepositDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_St)
                    {
                        // ������(�J�n)����`�敪
                        e.NextCtrl = this.tComboEditor_DraftDivide;
                    }

                }
            }
        }
        #endregion

        #endregion �� PMTEG02000UA

        /// <summary>
        /// tComboEditor_DraftDivide_ValueChanged �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��`�敪�ύX�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���`</br>                                  
        /// <br>Date       : 2010.05.05</br> 
        /// </remarks> 
        private void tComboEditor_DraftDivide_ValueChanged(object sender, EventArgs e)
        {
            // �E��`�敪���u����`�v�̎�
            if ((int)this.tComboEditor_DraftDivide.SelectedIndex == 0)
            {
                // ��`�敪�u����`�v��I�����́A���t���ڂ̃^�C�g�����u�������v�ɕύX����B
                this.Lbl_DepositDate.Text = STR_DEPOSITDATE;
            }
            // �E��`�敪���u�x����`�v�̎�
            else
            {
                // ��`�敪�u�x����`�v��I�����́A���t���ڂ̃^�C�g�����u�x�����v�ɕύX����B
                this.Lbl_DepositDate.Text = STR_PAYMENTDATE;
            }

            //�J�n�������ƊJ�n�������擾��������
            GetHisTotalDayProc();
            this.tDateEdit_DepositDate_Ed.SetDateTime(DateTime.Now);
        }
        
        #endregion �� Control Event

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ������
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();

                // ������(�J�n)�Ɩ�����(�J�n)�擾��������
                GetHisTotalDayProc();

                // ������(�I��)��ݒ�F�V�X�e�����t
                this.tDateEdit_DepositDate_Ed.SetDateTime(DateTime.Now);
                // ��`�敪
                if (this.tComboEditor_DraftDivide.Value == null)
                {
                    this.tComboEditor_DraftDivide.Value = 0;   // DEF:0:����`
                } 

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        #region �� �O�񌎎��X�V���擾�������� ��
        /// <summary>
        /// �J�n�������ƊJ�n�������擾��������
        /// </summary>
        /// <returns>�V�X�e�����t</returns>
        /// <remarks>
        /// <br>Note       : �������Ɩ������擾���������ł��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            //�O�񌎎��X�V��
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            // �O�񌎎��X�V���擾�O��������
            status = totalDayCalculator.InitializeHisMonthlyAccRec();

            int billDivIndex = this.tComboEditor_DraftDivide.SelectedIndex;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���񂨂�ёO��̒��ߓ�/�����擾(���Ɠ��͈قȂ�ꍇ������)
                //����`
                if (billDivIndex == 0)
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                else
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }

				if (prevTotalDay == DateTime.MinValue)
                {

                    // ������(�J�n)��ݒ�F�V�X�e�����t
                    this.tDateEdit_DepositDate_St.SetDateTime(DateTime.Now);
                }
                else
                {
                    // ���㍡�񌎎��X�V����ݒ�
                    // ������(�J�n)��ݒ�F�O�񌎎��X�V���̗���
					this.tDateEdit_DepositDate_St.SetDateTime(prevTotalDay.AddDays(1));
                }
            }
            else
            {
                // �����������s
                //����`
                if (billDivIndex == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYREC_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYPAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
            }
        }
        #endregion
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R����ݒ肷��</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
            const string ct_NoInputError = "���K�{���͂ł��B";
            const string ct_InputError = "�̓��͂��s���ł��B";

            bool status = true;
            string dateStr = null;
            // ����`
            if (this.tComboEditor_DraftDivide.SelectedIndex == 0)
                dateStr = STR_DEPOSITDATE;
            // �x����`
            else
                dateStr = STR_PAYMENTDATE;

            // ������/�x����
            if (DateGetAcs.CheckDateResult.ErrorOfNoInput.Equals(this._dateGet.CheckDate(ref this.tDateEdit_DepositDate_St)))
            {
                errMessage = string.Format("�J�n��{0}", ct_NoInputError);
                errComponent = this.tDateEdit_DepositDate_St;
                status = false;
            }
            else if (DateGetAcs.CheckDateResult.ErrorOfInvalid.Equals(this._dateGet.CheckDate(ref this.tDateEdit_DepositDate_St)))
            {
                errMessage = string.Format("�J�n��{0}", ct_InputError);
                errComponent = this.tDateEdit_DepositDate_St;
                status = false;
            }
            else if (DateGetAcs.CheckDateResult.ErrorOfNoInput.Equals(this._dateGet.CheckDate(ref this.tDateEdit_DepositDate_Ed)))
            {
                errMessage = string.Format("�I����{0}", ct_NoInputError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            else if (DateGetAcs.CheckDateResult.ErrorOfInvalid.Equals(this._dateGet.CheckDate(ref this.tDateEdit_DepositDate_Ed)))
            {
                errMessage = string.Format("�I����{0}", ct_InputError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            else if (
                this.tDateEdit_DepositDate_St.LongDate != 0 &&
                this.tDateEdit_DepositDate_Ed.LongDate != 0 &&
                !DateGetAcs.CheckDateRangeResult.OK.Equals(this._dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_DepositDate_St, ref this.tDateEdit_DepositDate_Ed, false)))
            {

                errMessage = string.Format(dateStr + "{0}", ct_RangeError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            
            return status;
        }

        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : ���`</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                this._tegataConfirmReport.EnterpriseCode = this._enterpriseCode;
                // ������
                this._tegataConfirmReport.DepositDateSt = this.tDateEdit_DepositDate_St.GetDateTime();
                this._tegataConfirmReport.DepositDateEd = this.tDateEdit_DepositDate_Ed.GetDateTime();

                //��`�敪
                this._tegataConfirmReport.DraftDivide = Convert.ToInt32(this.tComboEditor_DraftDivide.Value);
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
            
        }
        #endregion
        #endregion �� ����O����

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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        /// <summary>
        /// �O���[�v���k���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param> 
        /// <remarks> 
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br> 
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == "ReportSelectGroup")
            {
                // �O���[�v�̏k�����L�����Z�� 
                e.Cancel = true;
            }

        }
        
        /// <summary> 
        /// �G�N�X�v���[���[�o�[ �O���[�v�W�J �C�x���g 
        /// </summary> 
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param> 
        /// <param name="e">�C�x���g���</param> 
        /// <remarks> 
        /// <br>Note       : �O���[�v���W�J�����O�ɔ������܂��B</br> 
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == "ReportSelectGroup")
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s��</br>
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010.05.05</br>
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
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010.05.05</br>
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
        #endregion �� Private Method

    }
}