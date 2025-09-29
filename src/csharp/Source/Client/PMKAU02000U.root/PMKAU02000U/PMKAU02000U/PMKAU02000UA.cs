//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������ꗗ�\
// �v���O�����T�v   : �������ꗗ�\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2010/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2010/11/02  �C�����e : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)
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
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������ꗗ�\ ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ꗗ�\PDF�o�͑�����s���N���X�ł��B</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2010/07/01</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// </remarks>
    public partial class PMKAU02000UA : Form
    {
        # region [private enum]
        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        private enum OperationCode : int
        {
            /// <summary>PDF�o��</summary>
            PDFOut = 1,
            /// <summary>���</summary>
            PrintOut = 2,
        }
        # endregion

        #region [Private Const]
        /// <summary>�N���XID</summary>
        private const string ct_ClassID = "PMKAU02000UA";
        /// <summary>�v���O����ID</summary>
        private const string ct_PGID = "PMKAU02000U";
        /// <summary>���[����</summary>
        private const string PDF_PRINT_NAME1 = "�������ꗗ�\";
        /// <summary>���[�L�[	</summary>
        private const string PDF_PRINT_KEY = "ed734bd2-444a-4780-b3fc-237f642231fe";
        /// <summary>�t�b�^�{�^���P���ʒu</summary>
        private const int ct_FooterButton1_Left = 194;
        /// <summary>�t�b�^�{�^���Q���ʒu</summary>
        private const int ct_FooterButton2_Left = 336;
        #endregion

        #region [Private Member]
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;
        /// <summary>��ʃC���[�W�R���g���[�����i</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>���o�����N���X</summary>
        private NoDepSalListCdtn _noDepSalListCdtn;
        /// <summary>�K�C�h�n�A�N�Z�X�N���X</summary>
        private EmployeeAcs _employeeAcs;
        /// <summary>���t�擾���i</summary>
        private DateGetAcs _dateGet;
        /// <summary>�t�H�[�J�XControl</summary>
        private Control _prevControl = null;
        /// <summary>�`�F�b�N�G���[</summary>
        private Control _errorComponent = null;
        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>���Ӑ挟������</summary>
        private CustomerSearchRet _customerSearchRet;
        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private IOperationAuthority _operationAuthority;
        /// <summary>���쌠���̐��䃊�X�g(���ڎQ�Ƃ���ƒx���̂Ńf�B�N�V���i����)</summary>
        private Dictionary<OperationCode, bool> _operationAuthorityList;
        /// <summary></summary>
        private string _printName = string.Empty;
        /// <summary></summary>
        private string _printKey = PDF_PRINT_KEY;
        /// <summary>�������_(�O������̎w��p)</summary>
        private string _paraDmdSectionCode;
        /// <summary>������(�O������̎w��p)</summary>
        private int _paraClaimCode;
        #endregion

        # region [private �v���p�e�B]
        /// <summary>
        /// ���_�A�N�Z�X�N���X
        /// </summary>
        private SecInfoSetAcs SecInfoSetAcs
        {
            get
            {
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                return _secInfoSetAcs;
            }
        }
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g
        /// </summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if ( _operationAuthority == null )
                {
                    _operationAuthority = new OperationAuthorityImpl( Broadleaf.Application.Controller.Util.EntityUtil.CategoryCode.Report, "PMKAU02000U", this );
                }
                return _operationAuthority;
            }
        }
        /// <summary>
        /// ���쌠���̐��䃊�X�g
        /// </summary>
        private Dictionary<OperationCode, bool> OpeAuthDictionary
        {
            get
            {
                if ( _operationAuthorityList == null )
                {
                    _operationAuthorityList = new Dictionary<OperationCode, bool>();
                    _operationAuthorityList.Add( OperationCode.PDFOut, !MyOpeCtrl.Disabled( (int)OperationCode.PDFOut ) );
                    _operationAuthorityList.Add( OperationCode.PrintOut, !MyOpeCtrl.Disabled( (int)OperationCode.PrintOut ) );
                }
                return _operationAuthorityList;
            }
        }
        # endregion

        #region [public �v���p�e�B]
        /// <summary>
        /// �������_(�O������̎w��p)
        /// </summary>
        public string ParaDmdSectionCode
        {
            get { return _paraDmdSectionCode; }
            set { _paraDmdSectionCode = value; }
        }
        /// <summary>
        /// ������(�O������̎w��p)
        /// </summary>
        public int ParaClaimCode
        {
            get { return _paraClaimCode; }
            set { _paraClaimCode = value; }
        }
        #endregion

        #region [�R���X�g���N�^]
        /// <summary>
        /// ���[����(�������̓^�C�v)�t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public PMKAU02000UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion

        #region �� IPrintConditionInpType �����o

        #region �� Public Method

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;
            string errMessage = "";
            _errorComponent = null;

            if ( !this.ScreenInputCheck( ref errMessage, ref _errorComponent ) )
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if ( _errorComponent != null )
                {
                    _errorComponent.Focus();
                }

                // �t�H�[�J�X�A�E�g����
                if ( this._prevControl != null )
                {
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs( false, false, false, Keys.Return, this._prevControl, this._prevControl );
                    this.tArrowKeyControl1_ChangeFocus( this, e );
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
        /// <br>Note       : ����������s���B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public int Print( ref object parameter )
        {

            // �I�t���C����ԃ`�F�b�N	
            if ( !CheckOnline() )
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�������ꗗ�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if ( status != 0 )
            {
                return -1;
            }

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = PDF_PRINT_NAME1;

            // �e���v���[�g�̑I��
            printInfo.PrintPaperSetCd = 0;

            // ���o�����̐ݒ�
            printInfo.jyoken = this._noDepSalListCdtn;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if ( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN )
            {
                MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0 );
            }

            parameter = printInfo;

            // �_�C�A���O�L�����Z������
            if ( dialogResult == DialogResult.Cancel )
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            // STATUS�ԋp
            return printInfo.status;
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
        #region �� PMKAU02000UA
        #region �� PMKAU02000UA_Load Event
        /// <summary>
        /// PMKAU02000UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void PMKAU02000UA_Load( object sender, EventArgs e )
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen( out errMsg );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
                return;
            }

            // ��ʃC���[�W����
            # region [��ʃC���[�W����]
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            // ��ʃX�L���ύX		
            this._controlScreenSkin.SettingScreenSkin( this );
            // �\���X�^�C���␳
            ultraGroupBox1.ViewStyle = GroupBoxViewStyle.XP;
            # endregion

            // ���o�����C���X�^���X����
            this._noDepSalListCdtn = new NoDepSalListCdtn();


            // �������J�[�\��������
            this.Cursor = Cursors.WaitCursor;

            # region [�Z�L�����e�B�Ǘ������ݒ�]
            // �����ݒ�.PDF�o��
            if ( OpeAuthDictionary[OperationCode.PDFOut] )
            {
                this.ub_PDF.Visible = true;
                this.ub_Print.Left = ct_FooterButton1_Left;
            }
            else
            {
                this.ub_PDF.Visible = false;
                this.ub_Print.Left = ct_FooterButton2_Left;
            }

            // �����ݒ�.���
            if ( OpeAuthDictionary[OperationCode.PrintOut] )
            {
                this.ub_Print.Visible = true;
            }
            else
            {
                this.ub_Print.Visible = false;
            }
            # endregion

            // �����t�H�[�J�X�˓��t�敪
            this.tComboEditor_DateDiv.Focus();

            // �J�[�\���߂�������
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
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            if ( e == null || e.PrevCtrl == null ) return;

            // �����ڂ̎Z��{�{�^��Enter�L�[�Ή�
            # region [�����ڂ̎Z��{�{�^��Enter�L�[�Ή�]
            switch ( e.PrevCtrl.Name )
            {
                // ���t�敪
                case "tComboEditor_DateDiv":
                    {
                        Control ctrl = EasyArrowKeyControl( e, null, tDateEdit_SalesDate_St, 
                                                            null, tComboEditor_DateDiv,
                                                            tComboEditor_DateDiv, tDateEdit_SalesDate_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // �Ώۓ��i�J�n�j
                case "tDateEdit_SalesDate_St":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tComboEditor_DateDiv, tEdit_SectionCode_St, 
                                                            null, null, 
                                                            tComboEditor_DateDiv, tDateEdit_SalesDate_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // �Ώۓ��i�I���j
                case "tDateEdit_SalesDate_Ed":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tComboEditor_DateDiv, tEdit_SectionCode_Ed, 
                                                            null, null, 
                                                            tDateEdit_SalesDate_St, tEdit_SectionCode_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // �������_�i�J�n�j
                case "tEdit_SectionCode_St":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_St, tNedit_ClaimCode_St, 
                                                            null, null, 
                                                            tDateEdit_SalesDate_Ed, tEdit_SectionCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_SectionCode_St_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_St, tNedit_ClaimCode_St, 
                                                            null, null, 
                                                            tEdit_SectionCode_St, tEdit_SectionCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // �������_�i�I���j
                case "tEdit_SectionCode_Ed":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_Ed, tNedit_ClaimCode_Ed, 
                                                            null, ub_SectionCode_Ed_Guide, 
                                                            tEdit_SectionCode_St, tNedit_ClaimCode_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_SectionCode_Ed_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_Ed, tNedit_ClaimCode_Ed, 
                                                            null, ub_SectionCode_Ed_Guide, 
                                                            tEdit_SectionCode_Ed, tNedit_ClaimCode_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // ������i�J�n�j
                case "tNedit_ClaimCode_St":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_St, GetFooterFirstButton(), 
                                                            null, null, 
                                                            tEdit_SectionCode_Ed, tNedit_ClaimCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_ClaimCode_St_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_St, GetFooterFirstButton(), 
                                                            null, null, 
                                                            tNedit_ClaimCode_St, tNedit_ClaimCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // ������i�I���j
                case "tNedit_ClaimCode_Ed":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_Ed, GetFooterFirstButton(),
                                                            null, ub_ClaimCode_Ed_Guide,
                                                            tNedit_ClaimCode_St, GetFooterFirstButton() );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_ClaimCode_Ed_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_Ed, GetFooterFirstButton(),
                                                            null, ub_ClaimCode_Ed_Guide,
                                                            tNedit_ClaimCode_Ed, GetFooterFirstButton() );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // ����{�^��
                case "ub_Print":
                    {
                        if ( e.Key == Keys.Return )
                        {
                            // Enter�L�[�Ŏ��s
                            ub_Print_Click( ub_Print, new EventArgs() );
                            if ( _errorComponent != null )
                            {
                                e.NextCtrl = _errorComponent;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            Control printNextCtrl;
                            if (ub_PDF.Visible )
                            {
                                printNextCtrl = ub_PDF;
                            }
                            else
                            {
                                printNextCtrl = ub_Cancel;
                            }
                            Control ctrl = EasyArrowKeyControl( e, tNedit_ClaimCode_St, null, 
                                                                ub_Print, null, 
                                                                tNedit_ClaimCode_Ed, printNextCtrl );
                            if ( ctrl != null ) e.NextCtrl = ctrl;
                        }
                    }
                    break;
                // PDF�\���{�^��
                case "ub_PDF":
                    {
                        if ( e.Key == Keys.Return )
                        {
                            // Enter�L�[�Ŏ��s
                            ub_PDF_Click( ub_PDF, new EventArgs() );
                            if ( _errorComponent != null )
                            {
                                e.NextCtrl = _errorComponent;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            Control pdfPrevCtrl;
                            if ( ub_Print.Visible )
                            {
                                pdfPrevCtrl = ub_Print;
                            }
                            else
                            {
                                pdfPrevCtrl = tNedit_ClaimCode_Ed;
                            }
                            Control ctrl = EasyArrowKeyControl( e, tNedit_ClaimCode_St, null,
                                                                GetFooterFirstButton(), null,
                                                                pdfPrevCtrl, ub_Cancel );
                            if ( ctrl != null ) e.NextCtrl = ctrl;
                        }
                    }
                    break;
                // �L�����Z���{�^��
                case "ub_Cancel":
                    {
                        if ( e.Key == Keys.Return )
                        {
                            // Enter�L�[�Ŏ��s
                            ub_Cancel_Click( ub_Cancel, new EventArgs() );
                            if ( _errorComponent != null )
                            {
                                e.NextCtrl = _errorComponent;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            Control cancelPrevCtrl;
                            if ( ub_PDF.Visible )
                            {
                                cancelPrevCtrl = ub_PDF;
                            }
                            else
                            {
                                cancelPrevCtrl = ub_Print;
                            }
                            Control ctrl = EasyArrowKeyControl( e, tNedit_ClaimCode_St, null,
                                                                null, null,
                                                                cancelPrevCtrl, ub_Cancel );
                            if ( ctrl != null ) e.NextCtrl = ctrl;
                        }
                    }
                    break;
                default:
                    break;
            }
            # endregion

        }
        /// <summary>
        /// �t�b�^���擪�{�^���擾
        /// </summary>
        /// <returns></returns>
        private Control GetFooterFirstButton()
        {
            if ( ub_Print.Visible )
            {
                return ub_Print;
            }
            else
            {
                return ub_PDF;
            }
        }
        /// <summary>
        /// �ȈՃA���[�L�[�R���g���[��
        /// </summary>
        /// <param name="e"></param>
        /// <param name="upCtrl"></param>
        /// <param name="downCtrl"></param>
        /// <param name="leftCtrl"></param>
        /// <param name="rightCtrl"></param>
        /// <returns></returns>
        private Control EasyArrowKeyControl( ChangeFocusEventArgs e, Control upCtrl, Control downCtrl, Control leftCtrl, Control rightCtrl, Control prevCtrl, Control nextCtrl )
        {
            switch ( e.Key )
            {
                case Keys.Up: return upCtrl;
                case Keys.Down: return downCtrl;
                case Keys.Left: return leftCtrl;
                case Keys.Right: return rightCtrl;

                case Keys.Return:
                case Keys.Tab:
                    {
                        if ( !e.ShiftKey )
                        {
                            return nextCtrl;
                        }
                        else
                        {
                            return prevCtrl;
                        }
                    }
                default: return null;
            }
        }
        #endregion

        #endregion �� PMKAU02000UA

        /// <summary>
        /// tComboEditor_DraftDivide_ValueChanged �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��`�敪�ύX�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks> 
        private void tComboEditor_DraftDivide_ValueChanged( object sender, EventArgs e )
        {
        }

        #endregion �� Control Event

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int InitializeScreen( out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                # region [���o�����̏����\��]
                // ���t�敪
                this.tComboEditor_DateDiv.SelectedIndex = 0;

                // �Ώۓ�
                DateTime today = DateTime.Today;
                this.tDateEdit_SalesDate_St.SetDateTime( today.AddMonths( -1 ).AddDays( 1 ) );
                this.tDateEdit_SalesDate_Ed.SetDateTime( today );

                // �������_
                if ( !string.IsNullOrEmpty( ParaDmdSectionCode ) )
                {
                    this.tEdit_SectionCode_St.Text = ParaDmdSectionCode.Trim();
                    this.tEdit_SectionCode_Ed.Text = ParaDmdSectionCode.Trim();
                }

                // ������
                if ( ParaClaimCode > 0 )
                {
                    this.tNedit_ClaimCode_St.SetInt( ParaClaimCode );
                    this.tNedit_ClaimCode_Ed.SetInt( ParaClaimCode );
                }
                # endregion

                # region [�{�^���C���[�W]
                // �K�C�h�{�^��
                SetIconImage( ub_SectionCode_St_Guide, Size16_Index.STAR1 );
                SetIconImage( ub_SectionCode_Ed_Guide, Size16_Index.STAR1 );
                SetIconImage( ub_ClaimCode_St_Guide, Size16_Index.STAR1 );
                SetIconImage( ub_ClaimCode_Ed_Guide, Size16_Index.STAR1 );

                // �t�b�^���{�^��
                SetIconImage( ub_Print, Size16_Index.PRINT );
                SetIconImage( ub_PDF, Size16_Index.VIEW );
                SetIconImage( ub_Cancel, Size16_Index.BEFORE );
                # endregion
            }
            catch ( Exception ex )
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �{�^���A�C�R����ݒ肷��</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void SetIconImage( object settingControl, Size16_Index iconIndex )
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
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
        {
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
            //const string ct_NoInputError = "���K�{���͂ł��B";
            const string ct_InputError = "�̓��͂��s���ł��B";

            bool status = true;

            //--------------------------------------------------
            // �Ώۓ��i�J�n�E�I���j
            //--------------------------------------------------
            switch ( this._dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_SalesDate_St, ref this.tDateEdit_SalesDate_Ed, true ) )
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                    {
                        errMessage = string.Format( "�J�n�Ώۓ�{0}", ct_InputError );
                        errComponent = this.tDateEdit_SalesDate_St;
                        status = false;
                    }
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                    {
                        errMessage = string.Format( "�I���Ώۓ�{0}", ct_InputError );
                        errComponent = this.tDateEdit_SalesDate_Ed;
                        status = false;
                    }
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    {
                        errMessage = string.Format( "�Ώۓ�{0}", ct_RangeError );
                        errComponent = this.tDateEdit_SalesDate_St;
                        status = false;
                    }
                    break;
            }
            if ( status == false )
            {
                return false;
            }
            //--------------------------------------------------
            // �������_�i�J�n�E�I���j
            //--------------------------------------------------
            else if ( !string.IsNullOrEmpty( tEdit_SectionCode_St.Text ) &&
                      !string.IsNullOrEmpty( tEdit_SectionCode_Ed.Text ) &&
                      (ToInt( tEdit_SectionCode_St.Text ) > ToInt( tEdit_SectionCode_Ed.Text )) )
            {
                errMessage = string.Format( "�������_{0}", ct_RangeError );
                errComponent = this.tEdit_SectionCode_St;
                status = false;
            }
            //--------------------------------------------------
            // ������i�J�n�E�I���j
            //--------------------------------------------------
            else if ( tNedit_ClaimCode_St.GetInt() != 0 &&
                      tNedit_ClaimCode_Ed.GetInt() != 0 &&
                      (tNedit_ClaimCode_St.GetInt() > tNedit_ClaimCode_Ed.GetInt()) )
            {
                errMessage = string.Format( "������{0}", ct_RangeError );
                errComponent = this.tNedit_ClaimCode_St;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// ������ː��l�ϊ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                this._noDepSalListCdtn.EnterpriseCode = this._enterpriseCode;

                // ���t�敪
                this._noDepSalListCdtn.TargetDateDiv = (int)this.tComboEditor_DateDiv.Value;

                // �Ώۓ�
                this._noDepSalListCdtn.DateSt = this.tDateEdit_SalesDate_St.GetLongDate();
                this._noDepSalListCdtn.DateEd = this.tDateEdit_SalesDate_Ed.GetLongDate();

                // �������_�R�[�h�i�J�n�E�I���j
                this._noDepSalListCdtn.DemandAddUpSecCdSt = this.tEdit_SectionCode_St.Text.Trim();
                this._noDepSalListCdtn.DemandAddUpSecCdEd = this.tEdit_SectionCode_Ed.Text.Trim();

                // �������Ӑ�R�[�h�i�J�n�E�I���j
                this._noDepSalListCdtn.ClaimCodeSt = this.tNedit_ClaimCode_St.GetInt();
                this._noDepSalListCdtn.ClaimCodeEd = this.tNedit_ClaimCode_Ed.GetInt();

            }
            catch ( Exception )
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
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void MsgDispProc( emErrorLevel iLevel, string message, int status )
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
                MessageBoxDefaultButton.Button1 );	// �����\���{�^��
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
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
        }

        /// <summary> 
        /// �G�N�X�v���[���[�o�[ �O���[�v�W�J �C�x���g 
        /// </summary> 
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param> 
        /// <param name="e">�C�x���g���</param> 
        /// <remarks> 
        /// <br>Note       : �O���[�v���W�J�����O�ɔ������܂��B</br> 
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
        }

        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s��</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if ( Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false )
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if ( CheckRemoteOn() == false )
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
        /// <br>Note       : �����[�g�ڑ��\������s��</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if ( isLocalAreaConnected == false )
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

        # region [�{�^���N���b�N]
        /// <summary>
        /// ����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Print_Click( object sender, EventArgs e )
        {
            if ( PrintBeforeCheck() )
            {
                object printInfo = CreatePrintParameter( 0 ); // 0:���
                int status = Print( ref printInfo );

                if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    this.Close();
                }
            }
        }
        /// <summary>
        /// PDF�\���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_PDF_Click( object sender, EventArgs e )
        {
            if ( PrintBeforeCheck() )
            {
                object printInfo = CreatePrintParameter( 1 ); // 1:PDF
                int status = Print( ref printInfo );

                if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // PDF�\��
                    # region [PDF�\��]
                    PMKAU02000UB pdfForm = new PMKAU02000UB( (this.Owner as Form) );
                    try
                    {
                        pdfForm.PDFShow( (printInfo as SFCMN06002C).pdftemppath );
                    }
                    finally
                    {
                        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                        pdfForm.Close();
                        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
                        pdfForm.Dispose();
                    }
                    # endregion

                    this.Close();
                }
            }
        }
        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Cancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }
        /// <summary>
        /// ���/PDF�o�̓p�����[�^����
        /// </summary>
        /// <param name="mode">0:���,1:PDF</param>
        /// <returns></returns>
        private SFCMN06002C CreatePrintParameter( int mode )
        {
            SFCMN06002C printInfo = new SFCMN06002C();

            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            printInfo.kidopgid = "PMKAU02000U";
            printInfo.prpnm = "";
            printInfo.PrintPaperSetCd = 0;

            if ( mode == 0 )
            {
                // ���
                printInfo.printmode = 1; // 1�F����̂�
            }
            else
            {
                // PDF
                printInfo.printmode = 2; // 2�FPDF�\���̂�
            }
            return printInfo;
        }
        # endregion

        # region [�K�C�h�{�^���N���b�N]
        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SectionCode_Guide_Click( object sender, EventArgs e )
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            int status = this.SecInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out sectionInfo );

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( sender == ub_SectionCode_St_Guide )
                {
                    tEdit_SectionCode_St.Text = sectionInfo.SectionCode.Trim();
                    tEdit_SectionCode_Ed.Focus();
                }
                else
                {
                    tEdit_SectionCode_Ed.Text = sectionInfo.SectionCode.Trim();
                    tNedit_ClaimCode_St.Focus();
                }
            }
        }
        /// <summary>
        /// ���Ӑ�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_ClaimCode_Guide_Click( object sender, EventArgs e )
        {
            _customerSearchRet = null;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA( PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY );
            customerSearchForm.CustomerSelect += new Broadleaf.Windows.Forms.PMKHN04005UA.CustomerSelectEventHandler( this.CustomerSearchForm_CustomerSelect );

            DialogResult result = customerSearchForm.ShowDialog( this );
            if ( result == DialogResult.OK && _customerSearchRet != null )
            {
                if ( sender == ub_ClaimCode_St_Guide )
                {
                    tNedit_ClaimCode_St.SetInt( _customerSearchRet.CustomerCode );
                    tNedit_ClaimCode_Ed.Focus();
                }
                else
                {
                    tNedit_ClaimCode_Ed.SetInt( _customerSearchRet.CustomerCode );
                    GetFooterFirstButton().Focus();
                }
            }
        }
        /// <summary>
        /// ���Ӑ�K�C�h�Ŋm�莞�̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if ( customerSearchRet == null ) return;

            // ���ʂ�ޔ�
            _customerSearchRet = customerSearchRet;
        }
        # endregion
    }
}