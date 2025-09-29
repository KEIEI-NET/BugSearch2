//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00      �쐬�S�� : �c����
// �� �� ��  2019/12/02       �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00      �쐬�S�� : ����
// �� �� ��  2020/02/04       �C�����e : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11675168-00      �쐬�S�� : �i�N
// �� �� ��  2021/07/29       �C�����e : PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Application.Resources;
using System.Xml;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����A�g�e�L�X�g�o�̓N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����A�g�e�L�X�g�o��UI�ŁA���o��������͂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br>UpdateNote : PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή�</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2021/07/29</br>
    /// </remarks>
    public partial class PMSDC02010UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer,	    // ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
                                IPrintConditionInpTypeUpdate
    {
        #region �� Constructor
        /// <summary>
        /// ����A�g�e�L�X�g�o��UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����A�g�e�L�X�g�o��UI����������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public PMSDC02010UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_���擾
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();

            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            _salesCprtAcs = new SalesCprtAcs();

            _secInfoSetAcs = new SecInfoSetAcs();
            _customerInfoAcs = new CustomerInfoAcs();

        }

        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member

        // �m��{�^����Ԏ擾�v���p�e�B
        private bool _canUpdate = true;
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = false;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = false;
        // �ݒ�{�^���\���L���v���p�e�B
        private bool _visibledSetButton = true;
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // ���O�C�����
        private Employee _loginWorker = null;

        private bool _customerGuid;

        private int _mode = 0;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private SalesCprtCndtnWork _salesCprtCndtnWork;

        private SalesCprtAcs _salesCprtAcs;
        //���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;
        // ���Ӑ�
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;
        /// <summary>�O����͒l</summary>
        private PrevInputValue _prevInputValue;
        //�ڑ����}�X�^
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs = null;

        //���t�擾���i
        private DateGetAcs _dateGet;

        private SFCMN00299CA msgForm = null;

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMSDC02010UA";
        // �v���O����ID
        private const string ct_PGID = "PMSDC02010U";
        // ���[����
        private const string PDF_PRINT_NAME = "�m�F���X�g";
        private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "0DC0CAB9-9645-4a27-8B61-03F651EBA3EA";
        private string _printKey = PDF_PRINT_KEY;
        #endregion �� Interface member

        //�G���[�������b�Z�[�W
        private const string ct_InputError = "�̓��͂��s���ł��B";
        private const string ct_NoInput = "����͂��ĉ������B";
        private const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
        private const string ct_NotOnYearError = "�͂P�Q�����͈͓̔��œ��͂��ĉ������B";
        /// <summary>���b�Z�[�W �u���Ӑ���̎擾�Ɏ��s���܂����B�v</summary>
        private const string ct_CustNotFound = "���Ӑ���̎擾�Ɏ��s���܂����B";
        /// <summary>�G���[���b�Z�[�W�F�u�����݂��܂���B�v</summary>
        private const string ct_NotExists = "�����݂��܂���B";
        /// <summary>���_�Ɠ��Ӑ旼���ݒ肳��Ă��Ȃ��ꍇ�G���[</summary>
        private const string ct_NotInput = "���_�A���Ӑ�̂����ꂩ����͂��Ă��������B";

        /// <summary>���O���b�Z�[�W�F���M�����G���[</summary>
        private const string LOGMSG_ERROR = "���M�����G���[";

        private char[] _fileCharArr = new char[9] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

        #endregion

        # region �\����
        /// <summary>
        /// �O��l�ێ�
        /// </summary>
        private struct PrevInputValue
        {
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;
            /// <summary>���Ӑ�R�[�h</summary>
            private int _customerCode;

            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
        }
        # endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property

        /// <summary> �m��{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        /// <summary> �ݒ�{�^���\���v���p�e�B </summary>
        public bool VisibledSetButton
        {
            get { return this._visibledSetButton; }
        }

        #endregion �� Public Property

        #region �� Public Method

        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        /// <summary>
        /// �t�@�C�����̐��m���`�F�b�N
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns></returns>
        private bool CheckFileStr(string fileName)
        {
            bool errFlg = false;
            List<char> fileCharList = new List<char>(_fileCharArr);

            foreach (char c in fileName)
            {
                if (fileCharList.Contains(c))
                {
                    errFlg = true;
                    break;
                }
            }

            return errFlg;
        }

        #region �� �m�菈��
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = -1;
            string errMsg = "";

            int logStatus = 0;
            SalCprtSndLogListResultWork salCprtSndLogWork = null;

            // �m�菈���m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                ct_ClassID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���s���Ă���낵���ł����H",       // �\�����郁�b�Z�[�W, 				
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);    // �\������{�^��

            if (result != DialogResult.Yes)
            {
                return status;
            }

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            SalCprtConnectInfoWork connectInfoWork = null;
            try
            {
                if (null == this._connectInfoWorkAcs)
                {
                    this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
                }
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, _salesCprtCndtnWork.EnterpriseCode, 0, _salesCprtCndtnWork.SectionCode, _salesCprtCndtnWork.CustomerCode);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
                return status;
            }
            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = -1;
                this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
                msgForm.Close();
                return status;
            }
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<

            try
            {
                //�f�[�^���o����
                // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
                //status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesCprtCndtnWork, out errMsg);
                status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesCprtCndtnWork, out errMsg, connectInfoWork);
                // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, status);
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, status);
                }
                else
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, status);
                }
                return status;
            }

            msgForm = new SFCMN00299CA();
            msgForm.Title = "���M��";
            msgForm.Message = "���݁A�f�[�^���M���ł��B                  ��n���΂炭���҂���������";
            msgForm.Show();
            // --- DEL 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            //SalCprtConnectInfoWork connectInfoWork = null;
            //try
            //{
            //    if (null == this._connectInfoWorkAcs)
            //    {
            //        this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
            //    }
            //    status = this._connectInfoWorkAcs.Read(out connectInfoWork, _salesCprtCndtnWork.EnterpriseCode, 0, _salesCprtCndtnWork.SectionCode, _salesCprtCndtnWork.CustomerCode);
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //    status = -1;
            //    this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
            //    return status;
            //}
            //if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    status = -1;
            //    this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
            //    msgForm.Close();
            //    return status;
            //}
            // --- DEL 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            string fileName = string.Empty;
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                fileName = connectInfoWork.CnectFileId;
            }
            this.DeleteXmlFile(fileName);
            status = SaveNetSendSetting(fileName);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = this._salesCprtAcs.SendAndReceive(ref this._salesCprtCndtnWork, fileName, out salCprtSndLogWork, out logStatus);
            }
            else
            {
                msgForm.Close();
            }
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                msgForm.Close();
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�������M�����Ɏ��s���܂����B", status);

                if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M���O�́A���ɑ��̒[���œo�^����Ă��܂��B", status);
                }
                return status;
            }
            else
            {
                msgForm.Close();
                if (this._salesCprtCndtnWork.ConFirmDiv != 0 && status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�蓮���M���s���܂����B", status);
                }

                if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M���O�́A���ɑ��̒[���œo�^����Ă��܂��B", status);
                }
            }

            //���㒊�o�f�[�^�X�V����
            try
            {
                //�f�[�^���o����
                status = this._salesCprtAcs.Write(out errMsg);
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, status);
            }

            if (this._salesCprtCndtnWork.ConFirmDiv == 0)
            {
                //�������
                _mode = 1;

                this._salesCprtCndtnWork.Mode = 1;

                Print(ref parameter);

                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�蓮���M���s���܂����B", status);
            }
            //��ʃ��[�h�̏�����
            _mode = 0;

            this._salesCprtCndtnWork.Mode = 0;

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
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            int status = -1;

            if(1 == (int)this.tComboEditor_ConFirmDiv.Value && _mode == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�I���o���Ȃ��敪�ł��B",
                status,
                MessageBoxButtons.OK);

                this.tComboEditor_ConFirmDiv.Focus();
                return status;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            if (_mode == 1)
            {
                this._salesCprtCndtnWork.Mode = 1;
            }
            else
            {
                this._salesCprtCndtnWork.Mode = 0;

            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._salesCprtCndtnWork;
            printDialog.PrintInfo = printInfo;

            printInfo.rdData = this._salesCprtAcs.GetprintdataTable();

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", printInfo.status);
            }

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�f�[�^���o�����Ɏ��s���܂����B", printInfo.status);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ۑ����ڐݒ菈�����s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tde_St_AddUpDate);
            saveCtrAry.Add(this.tde_Ed_AddUpDate);
            saveCtrAry.Add(this.tComboEditor_ConFirmDiv);
            saveCtrAry.Add(this.tNedit_CustomerCode);
            saveCtrAry.Add(this.tComboEditor_PdfOutDiv);
            saveCtrAry.Add(this.tEdit_SectionCode);
            saveCtrAry.Add(this.tEdit_SectionName);
            saveCtrAry.Add(this.uLabel_CustomerName);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
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

                status = false;
            }

            return status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
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

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ConFirmDiv.Value = 0;

                this.tComboEditor_PdfOutDiv.Value = 0;
                // �O����͒l�ێ��p
                _prevInputValue = new PrevInputValue();

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();

                // �����t�H�[�J�X�Z�b�g
                this.tde_St_AddUpDate.Focus();
            }
            catch (Exception ex)
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
        /// ���t���̓`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdrResult, ref TDateEdit tde_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDate(ref tde_OrderDataCreateDate, false);
            return (cdrResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// ���t�͈̓`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckPeriod(out DateGetAcs.CheckPeriodResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckPeriod(DateGetAcs.YmdType.Year, 1, DateGetAcs.YmdType.YearMonthDay, tde_St_OrderDataCreateDate.GetDateTime(), tde_Ed_OrderDataCreateDate.GetDateTime());
            return (cdrResult == DateGetAcs.CheckPeriodResult.OK);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateResult cdrResultSt;
            DateGetAcs.CheckDateResult cdrResultEd;
            DateGetAcs.CheckPeriodResult cdrResultStEd;

            // �v����i�J�n�j
            if (CallCheckDate(out cdrResultSt, ref tde_St_AddUpDate) == false)
            {
                switch (cdrResultSt)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("�J�n��{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("�J�n��{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                }

                status = false;
                this.tde_St_AddUpDate.ResetText();
                return status;
            }

            // �v����i�I���j
            if (CallCheckDate(out cdrResultEd, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResultEd)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("�I����{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("�I����{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                }

                status = false;
                this.tde_Ed_AddUpDate.ResetText();
                return status;
            }


            // �v����i�J�n�`�I���j
            if (CallCheckPeriod(out cdrResultStEd, ref tde_St_AddUpDate, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResultStEd)
                {
                    case DateGetAcs.CheckPeriodResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώۓ�{0}", ct_RangeError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckPeriodResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("�Ώۓ�{0}", ct_NotOnYearError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                }
                status = false;
                this.tde_St_AddUpDate.ResetText();
                this.tde_Ed_AddUpDate.ResetText();
                return status;
            }

            if (string.IsNullOrEmpty(this.tNedit_CustomerCode.DataText.TrimEnd())
                && string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.TrimEnd()))
            {
                errMessage = ct_NotInput;
                errComponent = this.tEdit_SectionCode;
                status = false;
                return status;
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
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._salesCprtCndtnWork = new SalesCprtCndtnWork();
            try
            {
                // ��ƃR�[�h
                this._salesCprtCndtnWork.EnterpriseCode = this._enterpriseCode;

                // ���_�R�[�h
                this._salesCprtCndtnWork.SectionCode = this.tEdit_SectionCode.Text;

                // �v���(�J�n)
                this._salesCprtCndtnWork.AddUpADateSt = this.tde_St_AddUpDate.GetLongDate();

                // �v���(�I��)
                this._salesCprtCndtnWork.AddUpADateEd = this.tde_Ed_AddUpDate.GetLongDate();

                //�m�F���X�g
                this._salesCprtCndtnWork.ConFirmDiv = (int)tComboEditor_ConFirmDiv.Value;

                // ���Ӑ�
                this._salesCprtCndtnWork.CustomerCode = this.tNedit_CustomerCode.GetInt();

                // �o�͎w��
                this._salesCprtCndtnWork.PdfOutDiv = (int)this.tComboEditor_PdfOutDiv.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �������MXML����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �������MXML�𐶐�����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>UpdateNote : PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2021/07/29</br>
        /// </remarks>
        private int SaveNetSendSetting(string fileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            try
            {
                int rowsCount = this._salesCprtAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // �X�V����������
                XmlElement update = null;
                // �`�[�敪������
                XmlElement kubun = null;
                // ���Ӑ溰�ޏ�����
                XmlElement kjcd = null;
                // ������t������
                XmlElement dndt = null;
                // ����`�[�ԍ�������
                XmlElement dnno = null;
                // ����s�ԍ�������uButton_SectionGuide
                XmlElement dngyno = null;
                // �i��������
                XmlElement pmncd = null;
                // ���[�J�[��������
                XmlElement mkname = null;
                // BL���i�R�[�h������
                XmlElement blcd = null;
                // �o�א�������
                XmlElement sksu = null;
                // ����P��������
                XmlElement unprc = null;
                // ������z������
                XmlElement taxexc = null;
                // ���l�P������
                XmlElement note = null;
                // ���l2������
                XmlElement note2 = null;
                // ���l3������
                XmlElement note3 = null;
                // �����`�[�ԍ�������
                XmlElement mtdnno = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // �X�V����
                    update = xmldoc.CreateElement("KOSINBI");
                    update.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["UpdateDateTime"].ToString();
                    data.AppendChild(update);

                    // �v���
                    dndt = xmldoc.CreateElement("KEIJOBI");
                    dndt.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // ����`�[�ԍ�
                    dnno = xmldoc.CreateElement("DENNO");
                    dnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // ����s�ԍ�
                    dngyno = xmldoc.CreateElement("ROWNO");
                    dngyno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // �`�[�敪
                    kubun = xmldoc.CreateElement("DENKUBUN");
                    kubun.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipCd"].ToString();
                    data.AppendChild(kubun);

                    // ���Ӑ溰��
                    kjcd = xmldoc.CreateElement("TOKUCD");
                    kjcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["CustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // BL���i�R�[�h
                    blcd = xmldoc.CreateElement("HINCD");
                    blcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["BLGoodsCode"].ToString();
                    data.AppendChild(blcd);

                    // �i��
                    pmncd = xmldoc.CreateElement("HINMEI");
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� ----->>>>>
                    //pmncd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString()))
                    {
                        pmncd.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString());
                    }
                    else
                    {
                        pmncd.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� -----<<<<<
                    data.AppendChild(pmncd);

                    // ���[�J�[��
                    mkname = xmldoc.CreateElement("MAKERMEI");
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� ----->>>>>
                    //mkname.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString()))
                    {
                        mkname.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString());
                    }
                    else
                    {
                        mkname.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� -----<<<<<
                    data.AppendChild(mkname);

                    // �o�א�
                    sksu = xmldoc.CreateElement("SYUKKASU");
                    sksu.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // ����P��
                    unprc = xmldoc.CreateElement("URITAN");
                    unprc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesUnPrcTaxExcFl"].ToString();
                    data.AppendChild(unprc);

                    // ������z
                    taxexc = xmldoc.CreateElement("URIKIN");
                    taxexc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesMoneyTaxExc"].ToString();
                    data.AppendChild(taxexc);

                    // ���l�P
                    note = xmldoc.CreateElement("BIKO1");
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� ----->>>>>
                    //note.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString()))
                    {
                        note.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString());
                    }
                    else
                    {
                        note.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� -----<<<<<
                    data.AppendChild(note);
                    // ���l�Q
                    note2 = xmldoc.CreateElement("BIKO2");
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� ----->>>>>
                    //note2.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString()))
                    {
                        note2.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString());
                    }
                    else
                    {
                        note2.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� -----<<<<<
                    data.AppendChild(note2);
                    // ���l�R
                    note3 = xmldoc.CreateElement("BIKO3");
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� ----->>>>>
                    //note3.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString()))
                    {
                        note3.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString());
                    }
                    else
                    {
                        note3.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� -----<<<<<
                    data.AppendChild(note3);

                    // �����`�[�ԍ�
                    mtdnno = xmldoc.CreateElement("MOTODENNO");
                    mtdnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["DebitNLnkSalesSlNum"].ToString();
                    data.AppendChild(mtdnno);

                    root.AppendChild(data);
                }

                //XML��������
                xmlFileName = this.GetXmlFileName(fileName);                
                xmldoc.Save(xmlFileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageIn = "XML�t�@�C���̏������݂Ɏ��s���܂����B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageIn, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

            return status;
        }

        // --- ADD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� ----->>>>>
        /// <summary>
        /// �֑������ϊ�����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �֑����������𔲂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2021/07/29</br>
        /// </remarks>
        private string ChangeIllegalChar(string bfString)
        {
            string afString = bfString;
            //NULL����
            afString = afString.Replace("\0", string.Empty);
            //�L�����b�W���^�[��
            afString = afString.Replace("\r", string.Empty);
            //���s
            afString = afString.Replace("\n", string.Empty);
            //�^�u����
            afString = afString.Replace("\t", string.Empty);
            //�A���[�g����
            afString = afString.Replace("\a", string.Empty);
            //�o�b�N�X�y�[�X
            afString = afString.Replace("\b", string.Empty);
            //���y�[�W
            afString = afString.Replace("\f", string.Empty);
            //�����^�u
            afString = afString.Replace("\v", string.Empty);

            return afString;
        }
        // --- ADD 2021/07/29 �i�N PMKOBETSU-4115 ����f�[�^�A�g���M�����s���Ή� -----<<<<<
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
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
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
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
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

        /// <summary>
        /// XML�̍폜
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: XML�̍폜����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private int DeleteXmlFile(string fileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            string xmlFileName = this.GetXmlFileName(fileName);
            try
            {
                // �t�@�C�����폜
                FileInfo info = new FileInfo(xmlFileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageDe = "XML�t�@�C���̍폜�Ɏ��s���܂����B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageDe, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            return status;
        }

        /// <summary>
        /// ���M�t�@�C���������
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note		: ���M�t�@�C���������</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private String GetXmlFileName(string fileName) 
        {
            string xmlFileName = string.Empty;
            if (!String.IsNullOrEmpty(fileName))
            {
                if (fileName.Contains("."))
                {
                    int index = fileName.LastIndexOf(".");
                    fileName = fileName.Substring(0, index) + ".XML";
                }
                else
                {
                    fileName = fileName + ".XML";
                }
                xmlFileName = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT) + "\\" + fileName;
            }
            return xmlFileName;
        }

        #endregion �� Private Method

        # region Control Events

        /// <summary>
        /// PMSDC02010UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void PMSDC02010UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SetIconImage(this.ub_CustomerCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_SectionGuide, Size16_Index.STAR1);

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// ���Ӑ�K�C�h�N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/02</br>
        private void ub_CustomerCode_St_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            if (_customerGuid)
            {
                Control nextControl = null;
                nextControl = this.tComboEditor_PdfOutDiv;
                // �t�H�[�J�X
                nextControl.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h�K�C�h�N���b�N���ɔ����C�x���g</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
            {
                // ���Ӑ����UI�ɐݒ�
                _prevInputValue.CustomerCode = customerInfo.CustomerCode;
                // ���Ӑ�R�[�h�̃Z�b�g
                this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                // ���Ӑ於�̂̃Z�b�g
                this.uLabel_CustomerName.Text = SubStringOfByte(customerInfo.CustomerSnm.TrimEnd(), 20);
            }
            // ���Ӑ���̎擾�Ɏ��s
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID,
                    ct_CustNotFound,
                    status, MessageBoxButtons.OK);

                this.tNedit_CustomerCode.SetInt(_prevInputValue.CustomerCode);
                return;
            }
        }

        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : tNedit_CustomerCode_Leave �C�x���g�B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            int customerCode = 0;
            // ���Ӑ�R�[�h���͒l�s��
            if (!Int32.TryParse(this.tNedit_CustomerCode.Text.Trim(), out customerCode))
            {
                this.tNedit_CustomerCode.Clear();
                this.uLabel_CustomerName.Text = string.Empty;

                return;
            }
            // ��ʂɓ��Ӑ�R�[�h�̎擾
            customerCode = this.tNedit_CustomerCode.GetInt();
            // ���Ӑ�R�[�h�����͂��ꂽ�ꍇ
            if (customerCode > 0)
            {
                // ���Ӑ於�̂̎擾
                string customerName = string.Empty;
                int status = GetCustomerName(customerCode, out customerName);
                // ���Ӑ於�̎擾����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��ʂɓ��Ӑ於�̂̃Z�b�g
                    this.uLabel_CustomerName.Text = SubStringOfByte(customerName, 20);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID,
                                    "���Ӑ�" + ct_NotExists,
                                    0, MessageBoxButtons.OK);
                    // �O��l�\��
                    // �O��l������ꍇ
                    if (_prevInputValue.CustomerCode != 0)
                    {
                        this.tNedit_CustomerCode.Text = _prevInputValue.CustomerCode.ToString();
                    }
                    // �O��l���Ȃ��ꍇ
                    else
                    {
                        this.tNedit_CustomerCode.Text = string.Empty;
                    }
                    this.tNedit_CustomerCode.SelectAll();
                    this.tNedit_CustomerCode.Focus();
                }
            }
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">�������链�Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ於�̎擾�������s���B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private int GetCustomerName(int customerCode, out string customerName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ���Ӑ於��
            customerName = string.Empty;
            // ���Ӑ���
            CustomerInfo customerInfo;
            // �w�肵�����Ӑ�̏��̎擾
            status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
            // ���Ӑ���擾�����ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.LogicalDeleteCode == 0 && customerInfo.IsCustomer)
            {
                // ���Ӑ於�̂�߂�
                _prevInputValue.CustomerCode = customerCode;
                customerName = customerInfo.CustomerSnm.TrimEnd();
            }

            return status; 
        }

        #region[������@�o�C�g���w��؂蔲��]
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        /// <remarks>
        /// <br>Note        : ������@�o�C�g���w��؂蔲�����s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            // �����p�����[�^
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.Default;
            // �߂�l
            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);
            // �o�C�g��
            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // �I�[�̋󔒂͍폜
            return resultString;
        }
        #endregion

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup"))
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        # endregion

        #region ���_
        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^���̃N���b�N���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            // ���_���̎擾
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _prevInputValue.SectionCode = sectionInfo.SectionCode.Trim();
                this.tEdit_SectionCode.Text = sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.Trim();

                this.tNedit_CustomerCode.Focus();
            }
            // �X�e�[�^�X���ُ펞�A�O�񋒓_������ʂɃZ�b�g����
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tEdit_SectionCode.Text = _prevInputValue.SectionCode;
            }
        }

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : tEdit_SectionCode_Leave �C�x���g�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            int sectionCd = 0;
            // ���_���͒l�s��
            if (!Int32.TryParse(this.tEdit_SectionCode.Text.Trim(), out sectionCd))
            {
                // ���_�����l���Z�b�g����
                // ���_�R�[�h�͋󔒂ł͂Ȃ��ꍇ
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                {
                    this.tEdit_SectionCode.Text = _prevInputValue.SectionCode.Trim();
                    if (("0").Equals(_prevInputValue.SectionCode.Trim()) || ("00").Equals(_prevInputValue.SectionCode.Trim()))
                    {
                        this.tEdit_SectionName.Text = string.Empty;
                    }
                    else
                    {
                        this.tEdit_SectionName.Text = this.GetSectionName(_prevInputValue.SectionCode.Trim());
                    }
                }
                // ���_�R�[�h�͋󔒂̏ꍇ
                else
                {
                    this.tEdit_SectionCode.Text = string.Empty;
                    this.tEdit_SectionName.Text = string.Empty;
                }

                return;
            }

            // ���̕ϊ�
            this._sectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // �S�БΉ�����
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // �R�[�h�͋K��̑S�̃R�[�h�ցi�������ɂ͋K��̑S�̃R�[�h�̂Ƃ��󔒂ɂ���j
                _prevInputValue.SectionCode = string.Empty;
                this._sectionCode = string.Empty;
                this.tEdit_SectionCode.Text = string.Empty;
                sectionName = string.Empty;
                this.tEdit_SectionName.Text = sectionName;
            }
            // ���_�R�[�h�����͂��ꂽ�ꍇ
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                // ���_���̂̎擾
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    // ��ʂɋ��_���̂̃Z�b�g
                    this.tEdit_SectionName.Text = sectionName;
                }
                // ���_���̎擾���s�ꍇ
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID,
                    "���_" + ct_NotExists,
                    0, MessageBoxButtons.OK);
                    // �O��l�\��
                    this.tEdit_SectionCode.Text = _prevInputValue.SectionCode;
                    this.tEdit_SectionCode.Focus();
                    this.tEdit_SectionCode.SelectAll();
                }
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCd">�������鋒�_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note        : ���_���̎擾�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetSectionName(string sectionCd)
        {
            // ���_����
            string sectionName = string.Empty;
            // ���_���
            SecInfoSet sectionInfo;
            // �w�肵�����_�̏��̎擾
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCd);
            // ���_���擾�����ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
            {
                // ���_���̂�߂�
                _prevInputValue.SectionCode = sectionCd;
                sectionName = sectionInfo.SectionGuideNm;
            }

            return sectionName;
        }

        #endregion // ���_
        
    }
}
