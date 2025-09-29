//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o��
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �C �� ��  2012/12/07  �C�����e : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/02/25  �C�����e : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/03/06  �C�����e : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/06/26  �C�����e : ���M���O�̓o�^
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
using System.Xml; // ADD zhuhh 2013/03/06 for Redmine#35011
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����f�[�^�e�L�X�g�o�̓N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�o��UI�ŁA���o��������͂��܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.13</br>
    /// <br>UpdateNote : 2012/12/07 zhuhh</br>
    /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
    /// <br>UpdateNote : 2013/02/25 zhuhh</br>
    /// <br>           : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
    /// <br>UpdateNote : 2013/03/06 zhuhh</br>
    /// <br>           : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�</br>
    /// <br>UpdateNote  : 2013/06/26 �c����</br>
    /// <br>            : ���M���O�̓o�^</br>
    /// </remarks>
    public partial class PMSAE02010UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer,	    // ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
                                IPrintConditionInpTypeUpdate
    {
        #region �� Constructor
        /// <summary>
        /// ����f�[�^�e�L�X�g�o��UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o��UI����������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        public PMSAE02010UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_���擾
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            _salesHistoryAcs = new SalesHistoryAcs();

            _formattedTextWriter = new FormattedTextWriter();
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
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = true;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = true;
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // ���O�C�����
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";

        private bool _customerGuid;

        private int _mode = 0;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private SalesHistoryCndtn _salesHistoryCndtn;

        private SalesHistoryAcs _salesHistoryAcs;

        private FormattedTextWriter _formattedTextWriter;

        //���t�擾���i
        private DateGetAcs _dateGet;

        private int _totalCount;

        private SFCMN00299CA msgForm = null;// ADD zhuhh 2013/03/06 for Redmine#35011

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMSAE02010UA";
        // �v���O����ID
        private const string ct_PGID = "PMSAE02010U";
        // ���[����
        private const string PDF_PRINT_NAME = "���v�m�F���X�g";
        private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "12a0cb5b-871f-4769-8fd8-1a671eedc610";
        private string _printKey = PDF_PRINT_KEY;
        #endregion �� Interface member

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�̓��͂��s���ł��B";
        const string ct_NoInput = "����͂��ĉ������B";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
        const string ct_NotOnYearError = "�͂P�Q�����͈͓̔��œ��͂��ĉ������B";

        // ----- ADD �c���� 2013/06/26 ----->>>>>
        /// <summary>���O���b�Z�[�W�F���M�����G���[</summary>
        private const string LOGMSG_ERROR = "���M�����G���[";

        private char[] _fileCharArr = new char[9] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };
        // ----- ADD �c���� 2013/06/26 -----<<<<<

        #endregion

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

        // ----- ADD �c���� 2013/06/26 ----->>>>>
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
        // ----- ADD �c���� 2013/06/26 -----<<<<<

        #region �� �m�菈��
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2013/03/06 zhuhh</br>
        /// <br>            : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�</br>
        /// <br>UpdateNote  : 2013/06/26 �c����</br>
        /// <br>            : ���M���O�̓o�^</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = -1;
            string errMsg = "";

            // ----- ADD �c���� 2013/06/26 ----->>>>>
            int logStatus = 0;
            SAndESalSndLogListResultWork sAndESalSndLogWork = null;
            // ----- ADD �c���� 2013/06/26 -----<<<<<

            // �e�L�X�g�t�@�C���� 
            string fileName = tEdit_FileName.Text.Trim();
            if (string.IsNullOrEmpty(fileName))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                 "�t�@�C��������͂��ĉ������B",
                status,
                MessageBoxButtons.OK);
                this.tEdit_FileName.Focus();
                return status;
            }

            // ----- DEL �c���� 2013/06/26 ----->>>>>
            //if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            //{
            //    TMsgDisp.Show(
            //    this,
            //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //    this.Name,
            //     "�w�肵���t�H���_������܂���B",
            //    status,
            //    MessageBoxButtons.OK);
            //    this.tEdit_FileName.Focus();
            //    return status;
            //}
            // ----- DEL �c���� 2013/06/26 -----<<<<<

            // ----- ADD �c���� 2013/06/26 ----->>>>>            
            bool fileNameErrFlg = true;
            // �t�@�C��������(�g���q��'.TXT'�̂�)
            string str = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            int suffixIndex = str.LastIndexOf(".");
            if (suffixIndex > 0 && !str.Substring(0, 1).Equals(" "))
            {
                if (CheckFileStr(str))
                {
                    fileNameErrFlg = false;
                }
                else
                {
                    string suffixName = str.Substring(suffixIndex).ToUpper();
                    if (suffixName != ".TXT")
                    {
                        fileNameErrFlg = false;
                    }
                }
            }
            else
            {
                fileNameErrFlg = false;
            }

            if (!fileNameErrFlg)
            {
                TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                  this.Name,
                   "�w�肳�ꂽ�t�@�C�������s���ł��B",
                  status,
                  MessageBoxButtons.OK);
                this.tEdit_FileName.Focus();
                return status;
            }

            bool directoryNameErrFlg = true;
            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
                {
                    directoryNameErrFlg = false;
                }
            }
            catch (ArgumentException)
            {
                directoryNameErrFlg = false;
            }

            if (!directoryNameErrFlg)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                 "�w�肵���t�H���_������܂���B",
                status,
                MessageBoxButtons.OK);
                this.tEdit_FileName.Focus();
                return status;
            }
            // ----- ADD �c���� 2013/06/26 -----<<<<<

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

            try
            {
                //�f�[�^���o����
                status = this._salesHistoryAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg);
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                }
                else
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);
                }
                return status;
            }

            //�e�L�X�g�o�͏���
            try
            {
                _totalCount = 0;

                //FormattedTextWriter�N���X�̃v���p�e�B
                SetFormattedTextWriter();

                status = _formattedTextWriter.TextOut(out _totalCount);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                // ----- ADD �c���� 2013/06/26 --------------->>>>>
                if (this._salesHistoryCndtn.AutoDataSendDiv == 0)
                {
                    status = -1;
                    this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    logStatus = this._salesHistoryAcs.WriteLogInfo(this._salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                }
                // ----- ADD �c���� 2013/06/26 ---------------<<<<<
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ----- ADD �c���� 2013/06/26 --------------->>>>>
                if (this._salesHistoryCndtn.AutoDataSendDiv == 0)
                {
                    status = -1;
                    this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    logStatus = this._salesHistoryAcs.WriteLogInfo(this._salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                }
                // ----- ADD �c���� 2013/06/26 ---------------<<<<<
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�e�L�X�g�o�͂Ɏ��s���܂����B", 0);

                return status;
            }

            // ----- ADD zhuhh 2013/03/06 for Redmine#35011----- >>>>>
            if (this._salesHistoryCndtn.AutoDataSendDiv == 0)
            {
                msgForm = new SFCMN00299CA();
                msgForm.Title = "���M��";
                msgForm.Message = "���݁A�f�[�^���M���ł��B                  ��n���΂炭���҂���������";
                msgForm.Show();
                this.DeleteXmlFile();
                status=SaveNetSendSetting();
                if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {                    
                    //status = this._salesHistoryAcs.SendAndReceive(ref this._salesHistoryCndtn, fileName); // DEL �c���� 2013/06/26
                    // 0:�������M;1:�蓮���M
                    status = this._salesHistoryAcs.SendAndReceive(ref this._salesHistoryCndtn, fileName, out sAndESalSndLogWork, out logStatus); // ADD �c���� 2013/06/26
                }
                else 
                {
                    //�Ȃ�
                }
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    msgForm.Close();
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�������M�����Ɏ��s���܂����B", 0);
                    
                    // ----- ADD �c���� 2013/06/26 --------------->>>>>
                    if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M���O�́A���ɑ��̒[���œo�^����Ă��܂��B", 0);
                    }
                    // ----- ADD �c���� 2013/06/26 ---------------<<<<<
                    return status;
                }
                else 
                {
                    msgForm.Close(); 

                    // ----- ADD �c���� 2013/06/26 --------------->>>>>
                    if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���M���O�́A���ɑ��̒[���œo�^����Ă��܂��B", 0);
                    }
                    // ----- ADD �c���� 2013/06/26 ---------------<<<<<
                }
            }
            else 
            {
                //�Ȃ�
            }
            // ----- ADD zhuhh 2013/03/06 for Redmine#35011----- <<<<<

            //S&E���㒊�o�f�[�^�X�V����
            try
            {
                //�f�[�^���o����
                status = this._salesHistoryAcs.Write(out errMsg);
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // �t�@�C���폜
                status = this.DeleteFile();

                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);

                return status;
            }

            //�������
            _mode = 1;

            this._salesHistoryCndtn.Mode = 1;

            Print(ref parameter);

            //��ʃ��[�h�̏�����
            _mode = 0;

            this._salesHistoryCndtn.Mode = 0;

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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            int status = -1;
            if (1 == (int)this.tComboEditor_ConFirmDiv.Value && _mode == 1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    _totalCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B",
                    status,
                    MessageBoxButtons.OK);

                return status;
            }

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
                this._salesHistoryCndtn.Mode = 1;
            }
            else
            {
                this._salesHistoryCndtn.Mode = 0;

            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._salesHistoryCndtn;
            printDialog.PrintInfo = printInfo;

            printInfo.rdData = this._salesHistoryAcs.GetprintdataTable();

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
            }

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�f�[�^���o�����Ɏ��s���܂����B", 0);
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2013/03/06 zhuhh</br>
        /// <br>            : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tde_St_AddUpDate);
            saveCtrAry.Add(this.tde_Ed_AddUpDate);
            saveCtrAry.Add(this.tComboEditor_ConFirmDiv);
            saveCtrAry.Add(this.tNedit_CustomerCode_St);
            saveCtrAry.Add(this.tNedit_CustomerCode_Ed);
            saveCtrAry.Add(this.tComboEditor_PdfOutDiv);
            saveCtrAry.Add(this.tEdit_FileName);
            saveCtrAry.Add(this.uos_DataSendDiv);// ADD zhuhh 2013/03/06 for Redmine#35011

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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypeSelectedSection �����o
        #region �� Public Property

        /// <summary> �{�Ћ@�\�v���p�e�B </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> ���_�I�v�V�����v���p�e�B </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion �� Public Property

        #region �� Public Method

        #region �� ���_�I������
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
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

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �����I�����_�ݒ菈��
        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypeSelectedSection �����o

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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ConFirmDiv.Value = 0;

                this.tComboEditor_PdfOutDiv.Value = 2;

                this.tEdit_FileName.Text = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT) + "\\URI.TXT";

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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
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

            // ���Ӑ�i�J�n�`�I���j
            if (!string.IsNullOrEmpty(this.tNedit_CustomerCode_St.DataText.TrimEnd())
                && !string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.DataText.TrimEnd()))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                    errComponent = this.tNedit_CustomerCode_Ed;
                    status = false;
                    return status;
                }
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2013/03/06 zhuhh</br>
        /// <br>            : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._salesHistoryCndtn = new SalesHistoryCndtn();
            try
            {
                // ��ƃR�[�h
                this._salesHistoryCndtn.EnterpriseCode = this._enterpriseCode;
                // �u�S���_�v���I������Ă���ꍇ�̓��X�g���N���A
                bool allSections = false;

                foreach (object obj in _selectedSectionList.Values)
                {
                    if (obj is string)
                    {
                        if ((obj as string) == "0")
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if (allSections)
                {
                    _selectedSectionList.Clear();
                }

                // �v�㋒�_�R�[�h�i�����w��j
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._salesHistoryCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // �v���(�J�n)
                this._salesHistoryCndtn.AddUpADateSt = this.tde_St_AddUpDate.GetLongDate();

                // �v���(�I��)
                this._salesHistoryCndtn.AddUpADateEd = this.tde_Ed_AddUpDate.GetLongDate();

                //�m�F���X�g
                this._salesHistoryCndtn.ConFirmDiv = (int)tComboEditor_ConFirmDiv.Value;

                // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
                //�������M�敪
                this._salesHistoryCndtn.AutoDataSendDiv = (int)this.uos_DataSendDiv.CheckedIndex;
                // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

                // ���Ӑ�(�J�n)
                this._salesHistoryCndtn.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();

                // ���Ӑ�(�J�n)
                this._salesHistoryCndtn.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();

                // �o�͎w��
                this._salesHistoryCndtn.PdfOutDiv = (int)this.tComboEditor_PdfOutDiv.Value;

                // �t�@�C����
                this._salesHistoryCndtn.FileName = this.tEdit_FileName.Text;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        ///FormattedTextWriter�N���X�ݒ菈��FormattedTextWriter�N���X����)
        /// </summary>
        /// <remarks>
        /// <br>Note		: FormattedTextWriter�N���X�����֐ݒ肷��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
        /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// <br>UpdateNote  : 2013/02/25 zhuhh</br>
        /// <br>            : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
        /// </remarks>
        private void SetFormattedTextWriter()
        {
            List<string> schemeList = new List<string>();
            schemeList.Add(PMSAE02014EA.ct_Col_SalesSlipNum);
            schemeList.Add(PMSAE02014EA.ct_Col_RequestDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd);
            schemeList.Add(PMSAE02014EA.ct_Col_AddUpADate);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompCd);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompRate);
            schemeList.Add(PMSAE02014EA.ct_Col_AbSalesRate);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesRowNo);
            schemeList.Add(PMSAE02014EA.ct_Col_AdministrationNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNameKana);
            schemeList.Add(PMSAE02014EA.ct_Col_AbGoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_ShipmentCnt);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoney);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----- >>>>>
            schemeList.Add(PMSAE02014EA.ct_Col_ShopMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_PriceMoney);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----- <<<<<
            schemeList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode);
            schemeList.Add(PMSAE02014EA.ct_Col_AreaCd);
            schemeList.Add(PMSAE02014EA.ct_Col_SearchSlipDate);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierCd);
            schemeList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd);
            schemeList.Add(PMSAE02014EA.ct_Col_OrderNum);// ADD zhuhh 2013/02/25
            schemeList.Add(PMSAE02014EA.ct_Col_Filler);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesSlipNum, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_RequestDiv, 3);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddUpADate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodDiv, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbSalesRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesRowNo, 2);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AdministrationNo, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNo, 16);
            //maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNameKana, 16);// DEL zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNameKana, 20);// ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
            //maxLengthList.Add(PMSAE02014EA.ct_Col_AbGoodsNo, 6);// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbGoodsNo, 8);// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShipmentCnt, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc, 8);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShopMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_PriceMoney, 8);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AreaCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SearchSlipDate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierCd, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_OrderNum, 6);// Add zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
            maxLengthList.Add(PMSAE02014EA.ct_Col_Filler, 1);

            _formattedTextWriter.DataSource = this._salesHistoryAcs.SalesHistoryDt;
            _formattedTextWriter.DataMember = String.Empty;
            _formattedTextWriter.OutputFileName = this.tEdit_FileName.Text.Trim();
            //�e�L�X�g�o�͂��鍀�ږ��̃��X�g
            _formattedTextWriter.SchemeList = schemeList;
            _formattedTextWriter.Splitter = String.Empty;
            _formattedTextWriter.Encloser = String.Empty;
            _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            _formattedTextWriter.FormatList = null;
            _formattedTextWriter.CaptionOutput = false;
            _formattedTextWriter.FixedLength = true;
            _formattedTextWriter.ReplaceList = null;
            _formattedTextWriter.MaxLengthList = maxLengthList;
        }

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        /// <summary>
        /// �������MXML����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �������MXML�𐶐�����B</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>
        /// </remarks>
        private int SaveNetSendSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            try
            {
                int rowsCount = this._salesHistoryAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // �f�[�^�敪������
                XmlElement dtkbn = null;
                // TMY-ID��������
                XmlElement pmwscd = null;
                // ���Ӑ溰�ޏ�����
                XmlElement kjcd = null;
                // ������t������
                XmlElement dndt = null;
                // ����`�[�ԍ�������
                XmlElement dnno = null;
                // ����s�ԍ�������
                XmlElement dngyno = null;
                // ���i�ԍ�������
                XmlElement pmncd = null;
                // ���i���[�J�[�R�[�h������
                XmlElement mkcd = null;
                // BL���i�R�[�h������
                XmlElement blcd = null;
                // �o�א�������
                XmlElement sksu = null;
                // �d����R�[�h������
                XmlElement psicd = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // �f�[�^�敪
                    dtkbn = xmldoc.CreateElement("DTKBN");
                    dtkbn.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["DataDiv"].ToString();
                    data.AppendChild(dtkbn);

                    // �p�[�c�}���[���R�[�h
                    pmwscd = xmldoc.CreateElement("PMWSCD");
                    if (!String.IsNullOrEmpty(this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString()))
                    {
                        pmwscd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString();
                    }                     
                    data.AppendChild(pmwscd);

                    // ���Ӑ溰��
                    kjcd = xmldoc.CreateElement("KJCD");
                    kjcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["TxtCustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // ������t
                    dndt = xmldoc.CreateElement("DNDT");
                    dndt.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // ����`�[�ԍ�
                    dnno = xmldoc.CreateElement("DNNO");
                    dnno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // ����s�ԍ�
                    dngyno = xmldoc.CreateElement("DNGYNO");
                    dngyno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // ���i�ԍ�
                    pmncd = xmldoc.CreateElement("PHNCD");
                    pmncd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsNo"].ToString();
                    data.AppendChild(pmncd);

                    // ���i���[�J�[�R�[�h
                    mkcd = xmldoc.CreateElement("MKCD");
                    mkcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsMakerCd"].ToString();
                    data.AppendChild(mkcd);

                    // BL���i�R�[�h
                    blcd = xmldoc.CreateElement("BLCD");
                    if (this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"] == DBNull.Value || this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString() == "")
                    {
                        blcd.InnerText = "0000";
                    }
                    else
                    {
                        blcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString();
                    }
                    data.AppendChild(blcd);

                    // �o�א�
                    sksu = xmldoc.CreateElement("SKSU");
                    sksu.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // �d����R�[�h
                    psicd = xmldoc.CreateElement("PSICD");
                    psicd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SupplierCd"].ToString();
                    data.AppendChild(psicd);

                    root.AppendChild(data);
                }

                //XML��������
                xmlFileName = this.GetXmlFileName();                
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
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
        #endregion

        #region �� �t�@�C���̍폜����
        /// <summary>
        /// �t�@�C���̍폜����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�����폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private int DeleteFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList fileList = new ArrayList();

            try
            {
                // �t�@�C�����폜
                FileInfo info = new FileInfo(this.tEdit_FileName.DataText);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.13</br>
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
        /// <summary>
        /// XML�̍폜
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: XML�̍폜����B</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// </remarks>
        private int DeleteXmlFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            string xmlFileName = this.GetXmlFileName();
            string xmlRecvName = this.GetXmlRecFileName();
            try
            {
                // �t�@�C�����폜
                FileInfo info = new FileInfo(xmlFileName);
                info.Delete();

                info = new FileInfo(xmlRecvName);
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
        /// <remarks>
        /// <br>Note		: ���M�t�@�C���������</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// </remarks>
        private String GetXmlFileName() 
        {
            string xmlFileName = tEdit_FileName.Text.Trim();
            if (!String.IsNullOrEmpty(xmlFileName))
            {
                if (xmlFileName.Contains("."))
                {
                    int index = xmlFileName.LastIndexOf(".");
                    xmlFileName = xmlFileName.Substring(0, index) + ".XML";
                }
                else
                {
                    xmlFileName = xmlFileName + ".XML";
                }
            }
            else 
            {
                xmlFileName = "R:\\SFNETASM\\PRTOUT\\URI.XML";
            }
            return xmlFileName;
        }

        /// <summary>
        /// ��M�t�@�C���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��M�t�@�C���������</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// </remarks>
        private String GetXmlRecFileName()
        {
            string xmlFileName = tEdit_FileName.Text.Trim();
            if (!String.IsNullOrEmpty(xmlFileName))
            {
                if (xmlFileName.Contains("."))
                {
                    int index = xmlFileName.LastIndexOf(".");
                    xmlFileName = xmlFileName.Substring(0, index) + "RECV.XML";
                }
                else
                {
                    xmlFileName = xmlFileName + "RECV.XML";
                }
            }
            else
            {
                xmlFileName = "R:\\SFNETASM\\PRTOUT\\URIRECV.XML";
            }
            return xmlFileName;
        }
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<

        #endregion �� Private Method

        # region Control Events

        /// <summary>
        /// PMSAE02010UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void PMSAE02010UA_Load(object sender, EventArgs e)
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
            this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCode_Ed, Size16_Index.STAR1);

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);
        }
        # endregion

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���̓t�@�C�����{�^�����N���b�N�������ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // �^�C�g���o�[�̕�����
                    openFileDialog.Title = "�o�̓t�@�C���I��";
                    openFileDialog.RestoreDirectory = true;
                    if (this.tEdit_FileName.Text.Trim() == string.Empty)
                    {
                        openFileDialog.InitialDirectory = ConstantManagement_ClientDirectory.PRTOUT;

                    }
                    else
                    {
                        openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_FileName.Text);
                        openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_FileName.Text);
                    }

                    //�u�t�@�C���̎�ށv���w��
                    openFileDialog.Filter = "���ׂẴt�@�C�� (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FileName.Text = openFileDialog.FileName;
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�(�J�n)�K�C�h�N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009.08.13</br>
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
                nextControl = this.tNedit_CustomerCode_Ed;
                // �t�H�[�J�X
                nextControl.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�(�J�n)�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�J�n)�K�C�h�N���b�N���ɔ����C�x���g</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009.08.13</br>
        /// </remarks>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�I��)�K�C�h�N���b�N���ɔ������܂�</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009.08.13</br>
        /// </remarks>
        private void ub_CustomerCode_Ed_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
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
        /// ���Ӑ�R�[�h(�I��)�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�J�n)�K�C�h�N���b�N���ɔ����C�x���g</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009.08.13</br>
        /// </remarks>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
    }
}
