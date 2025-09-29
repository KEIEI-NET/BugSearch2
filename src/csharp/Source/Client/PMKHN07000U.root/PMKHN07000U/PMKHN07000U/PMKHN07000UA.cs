//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �t���E�����E�c�l�e�L�X�g�o��
// �v���O�����T�v   : �t���E�����E�c�l�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : zhouyu   �A�� 967�975
// �C �� ��  2011/07/21  �C�����e : �����E�Ώۓ��t(�J�n/�I��)�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : zhouyu   redmine #23381 FOR 8���[�i
// �C �� ��  2011/08/03  �C�����e : �g�p�}�X�^�F���Ӑ�A�o�͋敪�F�S�ĂɕύX�̌�A
//                                : �G���^�[����������Œ��o�����ɐi��
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �t���E�����E�c�l�e�L�X�g�o�̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t���E�����E�c�l�e�L�X�g�o�̓t�H�[���N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public partial class PMKHN07000UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypeTextOutPut        // CSV�o��
    {
        #region �� Constructor
        /// <summary>
        /// �N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07000UA()
        {
            InitializeComponent();
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �d����K�C�h
            this._supplierAcs = new SupplierAcs();
            // �擾DATA
            this._dateGet = DateGetAcs.GetInstance();
            this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            this._postEnvelDMInstsMainAcs = PostEnvelDMInstsMainAcs.GetInstance();
        }
        #endregion

        #region  �� Private member

        #region �� Interface member

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;

        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = true;
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

        // --IPrintConditionInpTypeTextOutPut�̃v���p�e�B�p�ϐ� -------------------
        // �e�L�X�g�o�͕\���L���v���p�e�B
        private bool _canTextOutPut = true;

        #endregion �� Interface member

        //���t�擾���i
        private DateGetAcs _dateGet;

        // �d����K�C�h�A�N�Z�X�N���X
        private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;

        // �t���E�����E�c�l�e�L�X�g�o�̓A�N�Z�X�N���X
        private PostEnvelDMInstsMainAcs _postEnvelDMInstsMainAcs;

        // ��ƃR�[�h
        private string _enterpriseCode;

        // SFCMN00391U�̃e�L�X�g�o�̓��[�h
        private int _outPutMode;

        // �K�C�h�n�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;

        // ���Ӑ�K�C�hFLAG
        private bool _customerGuid;

        //ADD START ZHOUYU 2011/07/21 �A�� 967�975
        private bool useMast = false;
        private bool outPutCD = false;
        //ADD END ZHOUYU 2011/07/21 �A�� 967�975

        #endregion

        #region  �� Private cost
        //�G���[�������b�Z�[�W
        private const string ct_INPUTERROR = "���s���ł��B";
        private const string ct_NOINPUT = "����͂��Ă��������B";
        private const string ct_RANGEERROR = "�͈̔͂Ɍ�肪����܂��B";
        // �N���XID
        private const string ct_CLASSID = "PMKHN07000UA";
        // �N���X��
        private string ct_PRINTNAME = "�t���E�����E�c�l�e�L�X�g�o��";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07000U";
        // ExporerBar �O���[�v����
        private const string ct_EXBARGROUPNM_REPORTSELECTGROUP = "ReportSelectGroup";
        private const string ct_EXBARGROUPNM_PRINTCONDITIONGROUP = "PrintConditionGroup";
        private const string ct_EXBARGROUPNM_PRINTODERGROUP = "PrintOderGroup";

        #endregion

        #region ��IPrintConditionInpTypeTextOutPut �����o

        #region �� Public Property
        /// public propaty name  :  CanTextOutPut
        /// <summary>�e�L�X�g�o�̓v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �e�L�X�g�o�̓v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool CanTextOutPut
        {
            get { return this._canTextOutPut; }
        }
        #endregion �� Public Method

        #region �� Public Method

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        public int OutPutText(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�t���E�����E�c�l�e�L�X�g�o��" + "�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return status;
            }
            // ���o�����N���X
            PostcardEnvelopeDMTextCndtn condtionWork = new PostcardEnvelopeDMTextCndtn();
            // ��ʁ����o�����N���X
            SetCondtionWork(ref condtionWork);
            // ��������List
            ArrayList retList;
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";
            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                // ����
                status = _postEnvelDMInstsMainAcs.Search(condtionWork, out retList);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = 0;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���������ɊY������f�[�^�͑��݂��܂���B", 0);
                return status;
            }
            else
            {
                TMsgDisp.Show(						    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN07000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            ct_PRINTNAME, 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._postEnvelDMInstsMainAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                return status;
            }

            // �e�L�X�g�o�͗p�_�C�A���O�ɕK�v�ȏ����Z�b�g����
            SFCMN06002C printInfo;
            status = this.GetPrintInfo(out printInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;
            // �㏑���^�ǉ��t���O���Z�b�g(true:�ǉ�����Afalse:�㏑������)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // �X�L�[�}�擾
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            DataSet dsOutData = new DataSet();
            dsOutData = _postEnvelDMInstsMainAcs.UseMastDs;
            // CSV�o��
            status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            dsOutData.Tables.Clear();
            string resultMessage = "";
            switch (status)
            {
                case 0:    // ��������
                    resultMessage = "CSV�o�͂��������܂����B";
                    break;
                case -9:    // �o�͑ΏۊO�̃f�[�^���w�肳�ꂽ
                    resultMessage = "�o�͑ΏۊO�̃f�[�^���w�肳��܂����B";
                    break;
                default:    // ���̑��G���[
                    resultMessage = "���̑��̃G���[���������܂����B�X�e�[�^�X(" + status.ToString() + ")";
                    break;
            }

            if (!string.IsNullOrEmpty(resultMessage))
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                            , resultMessage
                            , status
                            , MessageBoxButtons.OK
                            , MessageBoxDefaultButton.Button1);
            }

            return status;
        }
        #endregion

        #endregion �� Public Method

        #endregion ��IPrintConditionInpTypeTextOutPut �����o

        #region �� IPrintConditionInpType �����o

        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// public propaty name  :  CanExtract
        /// <summary>���o�{�^����Ԏ擾�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���o�{�^����Ԏ擾�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// public propaty name  :  CanPdf
        /// <summary>PDF�o�̓{�^����Ԏ擾�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   PDF�o�̓{�^����Ԏ擾�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// public propaty name  :  CanPrint
        /// <summary>����{�^����Ԏ擾�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ����{�^����Ԏ擾�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// public propaty name  :  VisibledExtractButton
        /// <summary>���o�{�^���\���L���擾�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���o�{�^���\���L���擾�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// public propaty name  :  VisibledPdfButton
        /// <summary>PDF�o�̓{�^���\���L���v���p�e�B�擾�v���p�e�B </summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   PDF�o�̓{�^���\���L���v���p�e�B�擾�v���p�e�B ���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// public propaty name  :  VisibledPrintButton
        /// <summary>����{�^���\���擾�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ����{�^���\���擾�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
            InitMenuButton();
            return;
        }

        /// <summary>
        /// ��ʕ\�����[�h�{�^�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����[�h�{�^�����䏈�����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitMenuButton()
        {
            // CSV
            // ���o�{�^����Ԏ擾�v���p�e�B
            _canExtract = true;
            // PDF�o�̓{�^����Ԏ擾�v���p�e�B  
            _canPdf = false;
            // ����{�^����Ԏ擾�v���p�e�B
            _canPrint = false;
            // ���o�{�^���\���L���v���p�e�B
            _visibledExtractButton = false;
            // PDF�o�̓{�^���\���L���v���p�e�B	
            _visibledPdfButton = false;
            // ����{�^���\���L���v���p�e�B
            _visibledPrintButton = false;
            //--IPrintConditionInpTypeTextOutPut�̃v���p�e�B
            _canTextOutPut = true;

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
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
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
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            string errMessage = "";
            Control errComponent = null;
            if (ScreenInputCheck(ref errMessage, ref errComponent))
            {
                return true;
            }
            else
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                return false;
            }

        }

        #endregion

        #endregion �� Public Method

        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypeSelectedSection �����o

        #region �� Public Property

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �{�Ћ@�\�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�I�v�V�����v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  VisibledSelectAddUpCd
        /// <summary>�v�㋒�_�I��\���擾�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �v�㋒�_�I��\���擾�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���_�I������( ������ )
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �����I�����_�ݒ菈��( ������ )
        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // ���_�I�����Ȃ��̂Ŗ�����
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
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return false;
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion
        #endregion �� Public Method

        #endregion �� IPrintConditionInpTypeSelectedSection �����o

        #region �� Private Event

        #region �� ChangeFocus
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���L�[�ł̃t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.04.01</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.Mast_tComboEditor)
                    {
                        switch (this.Mast_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    // �g�p�}�X�^���o�͋敪
                                    e.NextCtrl = this.OutputDiv_tComboEditor;
                                }
                                break;
                            case (1):
                                {
                                    // �g�p�}�X�^�����_(�J�n)
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                break;
                            case (3):
                                {
                                    // �g�p�}�X�^�����_(�J�n)
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.OutputDiv_tComboEditor)
                    {
                        switch (this.OutputDiv_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    /*DEL START 2011/08/03 redmine #23381 FOR 8���[�i----------------
                                    // �o�͋敪������
                                    e.NextCtrl = this.tDateEdit_TotalDay;
                                    ----------------DEL END 2011/08/03 redmine #23381 FOR 8���[�i*/
                                    //ADD START 2011/08/03 redmine #23381 FOR 8���[�i
                                    //�o�͋敪�����_
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                    //ADD END 2011/08/03 redmine #23381 FOR 8���[�i
                                }
                                break;
                            case (1):
                                {
                                    // �o�͋敪������
                                    e.NextCtrl = this.tDateEdit_TotalDay;
                                }
                                break;
                            case (2):
                                {
                                    // �o�͋敪���Ώۓ��t(�J�n)
                                    e.NextCtrl = this.tDateEdit_St_AddUpDay;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.tDateEdit_TotalDay)
                    {
                        switch (this.OutputDiv_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {

                                    // �������Ώۓ��t(�J�n)
                                    e.NextCtrl = this.tDateEdit_St_AddUpDay;
                                }
                                break;
                            case (1):
                                {
                                    // ���������_(�J�n)
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.tDateEdit_St_AddUpDay)
                    {
                        // �Ώۓ��t(�J�n)���Ώۓ��t(�I��)
                        e.NextCtrl = this.tDateEdit_Ed_AddUpDay;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_Ed_AddUpDay)
                    {
                        // �Ώۓ��t(�I��)�����_(�J�n)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // ���_(�J�n)�����_(�I��)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        if (this.Mast_tComboEditor.SelectedIndex == 0)
                        {
                            // ���_(�I��)�����Ӑ�(�J�n)
                            e.NextCtrl = this.tNedit_CustomerCode_St;
                        }
                        else if (this.Mast_tComboEditor.SelectedIndex == 1)
                        {
                            // ���_(�I��)���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (this.Mast_tComboEditor.SelectedIndex == 3)
                        {
                            // ���_(�I��)���g�p�}�X�^
                            e.NextCtrl = this.Mast_tComboEditor;
                        }

                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)���g�p�}�X�^
                        e.NextCtrl = this.Mast_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���g�p�}�X�^
                        e.NextCtrl = this.Mast_tComboEditor;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.Mast_tComboEditor)
                    {
                        switch (this.Mast_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    // �g�p�}�X�^�����Ӑ�(�I��)
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                                break;
                            case (1):
                                {
                                    // �g�p�}�X�^���d����(�I��)
                                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                                }
                                break;
                            case (3):
                                {
                                    // �g�p�}�X�^�����_(�I��)
                                    e.NextCtrl = this.tEdit_SectionCode_Ed;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.OutputDiv_tComboEditor)
                    {
                        // �o�͋敪���g�p�}�X�^
                        e.NextCtrl = this.Mast_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_TotalDay)
                    {
                        // �������o�͋敪
                        e.NextCtrl = this.OutputDiv_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_St_AddUpDay)
                    {
                        switch (this.OutputDiv_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    // �Ώۓ��t(�J�n)������
                                    e.NextCtrl = this.tDateEdit_TotalDay;
                                }
                                break;
                            case (1):
                                {
                                    // �Ώۓ��t(�J�n)���o�͋敪
                                    e.NextCtrl = this.OutputDiv_tComboEditor;
                                }
                                break;
                            case (2):
                                {
                                    // �Ώۓ��t(�J�n)���o�͋敪
                                    e.NextCtrl = this.OutputDiv_tComboEditor;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.tDateEdit_Ed_AddUpDay)
                    {
                        // �Ώۓ��t(�I��)���Ώۓ��t(�J�n)
                        e.NextCtrl = this.tDateEdit_St_AddUpDay;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        if (this.Mast_tComboEditor.SelectedIndex == 0)
                        {
                            switch (this.OutputDiv_tComboEditor.SelectedIndex)
                            {
                                case (0):
                                    {
                                       /*DEL START 2011/08/03 redmine #23381 FOR 8���[�i----------------
                                       // ���_(�J�n)���Ώۓ��t(�I��)
                                       e.NextCtrl = this.tDateEdit_Ed_AddUpDay;
                                       ----------------DEL END 2011/08/03 redmine #23381 FOR 8���[�i*/
                                        //ADD START 2011/08/03 redmine #23381 FOR 8���[�i
                                        //���_���o�͋敪
                                        e.NextCtrl = this.OutputDiv_tComboEditor;
                                        //ADD END 2011/08/03 redmine #23381 FOR 8���[�i
                                    }
                                    break;
                                case (1):
                                    {
                                        // ���_(�J�n)������
                                        e.NextCtrl = this.tDateEdit_TotalDay;
                                    }
                                    break;
                                case (2):
                                    {
                                        // ���_(�J�n)���Ώۓ��t(�I��)
                                        e.NextCtrl = this.tDateEdit_Ed_AddUpDay;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // ���_(�J�n)���g�p�}�X�^
                            e.NextCtrl = this.Mast_tComboEditor;
                        }

                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // ���_(�I��)�����_(�J�n)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)�����_(�I��)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)�����_(�I��)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion


        #region �� �K�C�h����
        /// <summary>
        /// ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h(�J�n)�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_St_CustomerCode_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
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
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
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
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_Ed_CustomerCode_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            if (_customerGuid)
            {
                Control nextControl = null;
                nextControl = this.Mast_tComboEditor;
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
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

        /// <summary>
        /// �d����R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �d����R�[�h(�J�n)�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_St_SupplierCode_Click(object sender, EventArgs e)
        {
            Supplier retSupplier;
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }
            int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, this._stockSlipInputInitDataAcs.OwnSectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_St.DataText = retSupplier.SupplierCd.ToString();
                Control nextControl = null;
                nextControl = this.tNedit_SupplierCd_Ed;
                // �t�H�[�J�X
                nextControl.Focus();
            }

        }

        /// <summary>
        /// �d����R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �d����R�[�h(�I��)�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_Ed_SupplierCode_Click(object sender, EventArgs e)
        {
            Supplier retSupplier;
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }
            int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, this._stockSlipInputInitDataAcs.OwnSectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this.SettingSupplier(false, retSupplier);
                this.tNedit_SupplierCd_Ed.DataText = retSupplier.SupplierCd.ToString();
                Control nextControl = null;
                nextControl = this.Mast_tComboEditor;
                // �t�H�[�J�X
                nextControl.Focus();
            }

        }

        /// <summary>
        /// ���_�R�[�h�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���_�R�[�h�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ub_St_SectionCode_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // ���_�K�C�h�\��
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            TEdit targetControl = null;
            Control nextControl = null;
            string tag = (string)((UltraButton)sender).Tag;
            if (status == 0)
            {
                
                
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this.tEdit_SectionCode_St;
                    nextControl = this.tEdit_SectionCode_Ed;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this.tEdit_SectionCode_Ed;
                    // ���Ӑ�̏ꍇ
                    if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
                    {
                        nextControl = this.tNedit_CustomerCode_St;
                    }
                    // �d����̏ꍇ
                    else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Supplier)
                    {
                        nextControl = this.tNedit_SupplierCd_St;
                    }
                    //  ���_�̏ꍇ
                    else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
                    {
                        nextControl = this.Mast_tComboEditor;
                    }
                }
                else
                {
                    return;
                }
                // �R�[�h�W�J
                targetControl.DataText = secInfoSet.SectionCode.Trim();
                // �t�H�[�J�X
                nextControl.Focus();
            }
            else
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.ub_SectionCodeStGuid;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    nextControl = this.ub_SectionCodeEdGuid;
                }
                nextControl.Focus();
            }
            

        }
        #endregion

        #region �� �g�p�}�X�^�I��
        /// <summary>
        /// �g�p�}�X�^Combox��I������                                             
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �g�p�}�X�^Combox�I�����ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_MastRF_ValueChanged(object sender, EventArgs e)
        {
            // �ݒu�R���|�[�l���gState
            ToolBackState();
            // �g�p�}�X�^ = ���Ӑ�}�X�^��
            if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
            {
                this._outPutMode = 0;
                // �d����(�J�n)�͑���s��
                this.tNedit_SupplierCd_St.Enabled = false;
                // �d����(�J�n)�K�C�h�͑���s��
                this.tNedit_SupplierCd_Ed.Enabled = false;
                // �d����(�I��)�͑���s��
                this.ub_SupplierCodeStGuid.Enabled = false;
                // �d����(�I��)�K�C�h�͑���s��
                this.ub_SupplierCodeEdGuid.Enabled = false;

                // ���̑��͑���ł���
                this.OutputDiv_tComboEditor.Enabled = true;
                this.OutputDiv_tComboEditor.SelectedIndex = 0;
                /*DEL START ZHOUYU 2011/07/21 �A�� 967�975----------------
                this.tDateEdit_TotalDay.Enabled = true;
                this.tDateEdit_St_AddUpDay.Enabled = true;
                this.tDateEdit_Ed_AddUpDay.Enabled = true;
                ----------------DEL START ZHOUYU 2011/07/21 �A�� 967�975*/
                this.tNedit_CustomerCode_St.Enabled = true;
                this.ub_CustomerCodeStGuid.Enabled = true;
                this.tNedit_CustomerCode_Ed.Enabled = true;
                this.ub_CustomerCodeEdGuid.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.ub_SectionCodeStGuid.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.ub_SectionCodeEdGuid.Enabled = true;
                //ADD START ZHOUYU 2011/07/21 �A�� 967�975
                this.useMast = true;
                if (useMast && outPutCD)
                {
                    this.tDateEdit_TotalDay.Clear();
                    this.tDateEdit_St_AddUpDay.Clear();
                    this.tDateEdit_Ed_AddUpDay.Clear();
                    this.tDateEdit_TotalDay.Enabled = false;
                    this.tDateEdit_St_AddUpDay.Enabled = false;
                    this.tDateEdit_Ed_AddUpDay.Enabled = false;
                }
                //ADD END ZHOUYU 2011/07/21 �A�� 967�975

            }
            // �g�p�}�X�^ = �d����}�X�^��
            else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Supplier)
            {
                this._outPutMode = 1;
                // �o�͋敪�͑���s��  
                this.OutputDiv_tComboEditor.SelectedIndex = -1;
                this.OutputDiv_tComboEditor.Enabled = false;
                // �����͑���s��
                this.tDateEdit_TotalDay.Enabled = false;
                // �Ώۓ��t(�J�n)�͑���s��
                this.tDateEdit_St_AddUpDay.Enabled = false;
                // �Ώۓ��t(�I��)�͑���s��
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                // ���Ӑ�(�J�n)�͑���s��
                this.tNedit_CustomerCode_St.Enabled = false;
                // ���Ӑ�(�J�n)�K�C�h�͑���s��
                this.ub_CustomerCodeStGuid.Enabled = false;
                // ���Ӑ�(�I��)�͑���s��
                this.tNedit_CustomerCode_Ed.Enabled = false;
                // ���Ӑ�(�I��)�K�C�h�͑���s��
                this.ub_CustomerCodeEdGuid.Enabled = false;

                // ���̑��͑���ł���
                this.tNedit_SupplierCd_St.Enabled = true;
                this.ub_SupplierCodeStGuid.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.ub_SupplierCodeEdGuid.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.ub_SectionCodeStGuid.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.ub_SectionCodeEdGuid.Enabled = true;
                //ADD START ZHOUYU 2011/07/21 �A�� 967�975
                this.useMast = false;
                //ADD END ZHOUYU 2011/07/21 �A�� 967�975
            }
            // �g�p�}�X�^ = ���Ѓ}�X�^��
            else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Company)
            {
                this._outPutMode = 2;
                // �S�Ă͑���s��
                this.OutputDiv_tComboEditor.SelectedIndex = -1;
                this.OutputDiv_tComboEditor.Enabled = false;
                this.tDateEdit_TotalDay.Enabled = false;
                this.tDateEdit_St_AddUpDay.Enabled = false;
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                this.tNedit_SupplierCd_St.Enabled = false;
                this.ub_SupplierCodeStGuid.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.ub_SupplierCodeEdGuid.Enabled = false;
                this.tNedit_CustomerCode_St.Enabled = false;
                this.ub_CustomerCodeStGuid.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.ub_CustomerCodeEdGuid.Enabled = false;
                this.tEdit_SectionCode_Ed.Enabled = false;
                this.ub_SectionCodeStGuid.Enabled = false;
                this.tEdit_SectionCode_St.Enabled = false;
                this.ub_SectionCodeEdGuid.Enabled = false;
                //ADD START ZHOUYU 2011/07/21 �A�� 967�975
                this.useMast = false;
                //ADD END ZHOUYU 2011/07/21 �A�� 967�975
            }
            // �g�p�}�X�^ = ���_�}�X�^��
            else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
            {
                this._outPutMode = 3;
                // ���_�͑����
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.ub_SectionCodeStGuid.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.ub_SectionCodeEdGuid.Enabled = true;
                // ���̑��͑���s��
                this.OutputDiv_tComboEditor.SelectedIndex = -1;
                this.OutputDiv_tComboEditor.Enabled = false;
                this.tDateEdit_TotalDay.Enabled = false;
                this.tDateEdit_St_AddUpDay.Enabled = false;
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                this.tNedit_SupplierCd_St.Enabled = false;
                this.ub_SupplierCodeStGuid.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.ub_SupplierCodeEdGuid.Enabled = false;
                this.tNedit_CustomerCode_St.Enabled = false;
                this.ub_CustomerCodeStGuid.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.ub_CustomerCodeEdGuid.Enabled = false;
                //ADD START ZHOUYU 2011/07/21 �A�� 967�975
                this.useMast = false;
                //ADD END ZHOUYU 2011/07/21 �A�� 967�975

            }

        }
        #endregion

        #region �� �o�͋敪�I��
        /// <summary>
        /// �o�͋敪Combox��I������                                             
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �o�͋敪Combox�I�����ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void tComboEditor_OutputDiv_ValueChanged(object sender, EventArgs e)
        {
            // �o�͋敪�́u�����L��v��
            if (OutputDiv_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.Claim)
            {
                // �����͑���ł���
                this.tDateEdit_TotalDay.Enabled = true;
                // �Ώۓ��t(�J�n)�͑���s��
                this.tDateEdit_St_AddUpDay.Enabled = false;
                // �Ώۓ��t(�I��)�͑���s��
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                this.outPutCD = false;
            }
            // �o�͋敪�́u�`�[�L��v��
            else if (OutputDiv_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.Slip)
            {
                // �����͑���s��
                this.tDateEdit_TotalDay.Enabled = false;
                // �Ώۓ��t(�J�n)�͑���ł���
                this.tDateEdit_St_AddUpDay.Enabled = true;
                // �Ώۓ��t(�I��)�͑���ł���
                this.tDateEdit_Ed_AddUpDay.Enabled = true;
                this.outPutCD = false;
            }
            // �o�͋敪�́u�S�āv��
            else if (OutputDiv_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.All)
            {
                // �S�Ă͑���ł���
                /*DEL START ZHOUYU 2011/07/21 �A�� 967�975----------------
                this.tDateEdit_TotalDay.Enabled = true;
                this.tDateEdit_St_AddUpDay.Enabled = true;
                this.tDateEdit_Ed_AddUpDay.Enabled = true;
                ----------------DEL START ZHOUYU 2011/07/21 �A�� 967�975*/
                //ADD START ZHOUYU 2011/07/21 �A�� 967�975
                this.outPutCD = true;
                if (outPutCD && useMast)
                {
                    this.tDateEdit_TotalDay.Enabled = false;
                    this.tDateEdit_St_AddUpDay.Enabled = false;
                    this.tDateEdit_Ed_AddUpDay.Enabled = false;
                    this.tDateEdit_TotalDay.Clear();
                    this.tDateEdit_St_AddUpDay.Clear();
                    this.tDateEdit_Ed_AddUpDay.Clear();
                }
                //ADD START ZHOUYU 2011/07/21 �A�� 967�975
            }
            ToolBackState();
        }
        #endregion

        /// <summary> 
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g 
        /// </summary> 
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param> 
        /// <param name="e">�C�x���g���</param> 
        /// <remarks> 
        /// <br>Note : �O���[�v���k�������O�ɔ������܂��B</br> 
        /// <br>Programer : ���R</br> 
        /// <br>Date : 2009.04.01</br> 
        /// </remarks> 
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_EXBARGROUPNM_REPORTSELECTGROUP) ||
                (e.Group.Key == ct_EXBARGROUPNM_PRINTODERGROUP) ||
                (e.Group.Key == ct_EXBARGROUPNM_PRINTCONDITIONGROUP))
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
        /// <br>Note : �O���[�v���W�J�����O�ɔ������܂��B</br> 
        /// <br>Programer : ���R</br> 
        /// <br>Date : 2009.04.01</br> 
        /// </remarks> 
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_EXBARGROUPNM_REPORTSELECTGROUP) ||
               (e.Group.Key == ct_EXBARGROUPNM_PRINTODERGROUP) ||
               (e.Group.Key == ct_EXBARGROUPNM_PRINTCONDITIONGROUP))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }

        #endregion�@�� Private Event

        #region �� Control Event
        /// <summary>
        /// PMKHN07000U_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void PMKHN07000U_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            // �R���g���[��������
            this.InitializeScreen();
            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N�� 
        }
        #endregion

        #region �� Private Method

        #region �� ���̓`�F�b�N����

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate">�J�n���t</param>
        /// <param name="tde_Ed_OrderDataCreateDate">�I�����t</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            // ���Ӑ�R�[�h
            int customerStCode = this.tNedit_CustomerCode_St.GetInt();
            int customerEdCode = this.tNedit_CustomerCode_Ed.GetInt();
            if (customerStCode == 0 && this.tNedit_CustomerCode_St.Text.Trim().Length > 0)
            {
                this.tNedit_CustomerCode_St.Text = String.Empty;
            }
            if (customerEdCode == 0 && this.tNedit_CustomerCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_CustomerCode_Ed.Text = String.Empty;
            }
            // �d����R�[�h
            int supplierStCode = this.tNedit_SupplierCd_St.GetInt();
            int supplierEdCode = this.tNedit_SupplierCd_Ed.GetInt();
            if (supplierStCode == 0 && this.tNedit_SupplierCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_SupplierCd_St.Text = String.Empty;
            }
            if (supplierEdCode == 0 && this.tNedit_SupplierCd_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_SupplierCd_Ed.Text = String.Empty;
            }

            // ���_�R�[�h
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (this.tEdit_SectionCode_St.DataText.TrimEnd() != String.Empty && !r.IsMatch(this.tEdit_SectionCode_St.DataText))
            {
                this.tEdit_SectionCode_St.Text = String.Empty;
            }
            if (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != String.Empty && !r.IsMatch(this.tEdit_SectionCode_Ed.DataText))
            {
                this.tEdit_SectionCode_Ed.Text = String.Empty;
            }
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;
            // Copy�`�F�b�N
            WordCoopyCheck();

            // �g�p�}�X�^
            if (this.Mast_tComboEditor.SelectedIndex == -1)
            {
                errMessage = string.Format("�g�p�}�X�^{0}", ct_NOINPUT);
                errComponent = this.Mast_tComboEditor;
                status = false;
            }
            // ����
            if (status != false && tDateEdit_TotalDay.GetLongDate() != 0)
            {
                if (this.tDateEdit_TotalDay.GetDateTime() == DateTime.MinValue)
                {
                    errMessage = string.Format("����{0}", ct_INPUTERROR);
                    errComponent = tDateEdit_TotalDay;
                    status = false;
                }
            }
            //else if (status != false && tDateEdit_TotalDay.GetLongDate() == 0)  //DEL ZHOUYU 2011/07/21 �A�� 967�975
            else if (status != false && tDateEdit_TotalDay.GetLongDate() == 0 && (!useMast || !outPutCD))  //ADD ZHOUYU 2011/07/21 �A�� 967�975
            {
                if (this.OutputDiv_tComboEditor.SelectedIndex == 0 || this.OutputDiv_tComboEditor.SelectedIndex == 1)
                {
                    errMessage = string.Format("����{0}", ct_NOINPUT);
                    errComponent = tDateEdit_TotalDay;
                    status = false;
                }
            }
            // �Ώۓ��t�i�J�n�`�I���j
            //if (this.OutputDiv_tComboEditor.SelectedIndex == 0 || this.OutputDiv_tComboEditor.SelectedIndex == 2)  //DEL ZHOUYU 2011/07/21 �A�� 967�975
            if ((this.OutputDiv_tComboEditor.SelectedIndex == 0 || this.OutputDiv_tComboEditor.SelectedIndex == 2) && (!useMast || !outPutCD))   //ADD ZHOUYU 2011/07/21 �A�� 967�975
            {
                if (status != false && CallCheckDateRange(out cdrResult, ref tDateEdit_St_AddUpDay, ref tDateEdit_Ed_AddUpDay) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("�Ώۓ��t(�J�n){0}", ct_INPUTERROR);
                                errComponent = this.tDateEdit_St_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("�Ώۓ��t(�J�n){0}", ct_NOINPUT);
                                errComponent = this.tDateEdit_St_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("�Ώۓ��t(�I��){0}", ct_INPUTERROR);
                                errComponent = this.tDateEdit_Ed_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("�Ώۓ��t(�I��){0}", ct_NOINPUT);
                                errComponent = this.tDateEdit_Ed_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("�Ώۓ��t{0}", ct_RANGEERROR);
                                errComponent = this.tDateEdit_St_AddUpDay;
                            }
                            status = false;
                            break;
                    }
                }
            }
            // ���_�i�J�n�`�I���j
            if (status != false && !string.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText.TrimEnd()) &&
                !string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("���_{0}", ct_RANGEERROR);
                errComponent = this.tEdit_SectionCode_St;
                status = false;

            }

            // ���Ӑ�i�J�n�`�I���j
            if (status != false && !string.IsNullOrEmpty(this.tNedit_CustomerCode_St.DataText)
                && !string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.DataText))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    errMessage = string.Format("���Ӑ�{0}", ct_RANGEERROR);
                    errComponent = this.tNedit_CustomerCode_St;
                    status = false;
                }
            }
            // �d����i�J�n�`�I���j
            if (status != false && !string.IsNullOrEmpty(this.tNedit_SupplierCd_St.DataText)
                && !string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.DataText))
            {
                if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
                {
                    errMessage = string.Format("�d����{0}", ct_RANGEERROR);
                    errComponent = this.tNedit_SupplierCd_St;
                    status = false;
                }
            }


            return status;
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        /// <summary>�G���[���b�Z�[�W�\������</summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>�G���[���b�Z�[�W��\�����܂��B
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string message, int status, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel
                                , this.Name
                                , message
                                , status
                                , iButton
                                , iDefButton);
        }
        /// <summary>�G���[���b�Z�[�W�\������</summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this.ct_PRINTNAME,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
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
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note		: �����[�g�ڑ��\������s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
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

        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ��ʏ������������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitializeScreen()
        {

            Infragistics.Win.ValueListItem listItemMast = new Infragistics.Win.ValueListItem();
            // �g�p�}�X�^Combox
            // ���Ӑ�}�X�^
            listItemMast.DataValue = 0;
            listItemMast.DisplayText = "���Ӑ�}�X�^";
            this.Mast_tComboEditor.Items.Add(listItemMast);
            // �d����}�X�^
            listItemMast = new Infragistics.Win.ValueListItem();
            listItemMast.DataValue = 1;
            listItemMast.DisplayText = "�d����}�X�^";
            this.Mast_tComboEditor.Items.Add(listItemMast);
            // ���Ѓ}�X�^
            listItemMast = new Infragistics.Win.ValueListItem();
            listItemMast.DataValue = 2;
            listItemMast.DisplayText = "���Ѓ}�X�^";
            this.Mast_tComboEditor.Items.Add(listItemMast);
            // ���_�}�X�^
            listItemMast = new Infragistics.Win.ValueListItem();
            listItemMast.DataValue = 3;
            listItemMast.DisplayText = "���_�}�X�^";
            this.Mast_tComboEditor.Items.Add(listItemMast);

            Infragistics.Win.ValueListItem listItemDiv = new Infragistics.Win.ValueListItem();
            // �o�͋敪Combox
            // �S��
            listItemDiv.DataValue = 0;
            listItemDiv.DisplayText = "�S��";
            this.OutputDiv_tComboEditor.Items.Add(listItemDiv);
            // �����L��
            listItemDiv = new Infragistics.Win.ValueListItem();
            listItemDiv.DataValue = 1;
            listItemDiv.DisplayText = "�����L��";
            this.OutputDiv_tComboEditor.Items.Add(listItemDiv);
            // �`�[�L��
            listItemDiv = new Infragistics.Win.ValueListItem();
            listItemDiv.DataValue = 2;
            listItemDiv.DisplayText = "�`�[�L��";
            this.OutputDiv_tComboEditor.Items.Add(listItemDiv);
            this.OutputDiv_tComboEditor.Enabled = false;

            ToolBackState();

            this.Mast_tComboEditor.SelectedIndex = 0;

            this.Mast_tComboEditor.Focus();

        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #region �� ������擾����
        /// <summary>
        /// ������擾����
        /// </summary>
        /// <param name="printInfo">������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ��������擾���܂��B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private int GetPrintInfo(out SFCMN06002C printInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ������p�����[�^
            printInfo = new SFCMN06002C();
            // ���[�I���K�C�h
            SFCMN00391U printDialog = new SFCMN00391U();

            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �N���o�f�h�c
            printInfo.kidopgid = ct_PGID;
            printInfo.selectInfoCode = 1;
            printInfo.PrintPaperSetCd = this._outPutMode;
            // ���[�I���K�C�h
            printDialog.PrintMode = 1;
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    if (File.Exists(printInfo.outPutFilePathName) == false)
                    {
                        // �t�@�C���Ȃ�
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        // �t�@�C�������݂���ꍇ�́A�I�[�v���`�F�b�N
                        try
                        {
                            // ���ɖ��̂�ύX
                            string tempFileName = printInfo.outPutFilePathName
                                                + DateTime.Now.Ticks.ToString();
                            FileInfo fi = new FileInfo(printInfo.outPutFilePathName);
                            fi.MoveTo(tempFileName);
                            // ���̂̕ύX���������s�����̂ŁA���̂����ɖ߂�
                            fi.MoveTo(printInfo.outPutFilePathName);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        catch (Exception)
                        {
                            // ���̕ύX���s -> ���̃A�v���P�[�V�������r���Ŏg�p��
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                                        , "�w�肳�ꂽ�t�@�C���͎g�p�ł��܂���B\r\n"
                                        + "Excel�����g�p���Ă��Ȃ����m�F���āA\r\n"
                                        + "�g�p���Ă���Ƃ��̓t�@�C������ĉ������B"
                                        , 0
                                        , MessageBoxButtons.OK
                                        , MessageBoxDefaultButton.Button1);
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                default:
                    // ��O������
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    break;
            }

            return status;
        }
        #endregion

        #region �� ������񏈗�
        /// <summary>
        /// ������񏈗�
        /// </summary>
        /// <param name="condtionWork">�������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ������񏈗����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void SetCondtionWork(ref PostcardEnvelopeDMTextCndtn condtionWork)
        {
            // ��ƃR�[�h
            condtionWork.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h�J�n
            condtionWork.St_SectionCode = this.tEdit_SectionCode_St.DataText.TrimEnd();

            // ���_�R�[�h�I��
            condtionWork.Ed_SectionCode = this.tEdit_SectionCode_Ed.DataText.TrimEnd();

            // �g�p�}�X�^
            condtionWork.UseMast = this.Mast_tComboEditor.SelectedIndex;

            // �o�͋敪
            if (this.Mast_tComboEditor.SelectedIndex != -1)
            {
                condtionWork.OutShipDiv = this.OutputDiv_tComboEditor.SelectedIndex;
            }
            else
            {
                condtionWork.OutShipDiv = 0;
            }
            // ����
            condtionWork.TotalDay = this.tDateEdit_TotalDay.GetDateTime();

            // �Ώۓ��t�J�n��
            condtionWork.St_AddUpDay = this.tDateEdit_St_AddUpDay.GetDateTime();

            // �Ώۓ��t�I����
            condtionWork.Ed_AddUpDay = this.tDateEdit_Ed_AddUpDay.GetDateTime();

            // ���Ӑ�R�[�h�J�n
            condtionWork.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();

            // ���Ӑ�R�[�h�I��
            condtionWork.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

            // �d����R�[�h�J�n
            condtionWork.St_SupplierCode = this.tNedit_SupplierCd_St.GetInt();

            // �d����R�[�h�I��
            condtionWork.Ed_SupplierCode = this.tNedit_SupplierCd_Ed.GetInt();

        }
        #endregion

        /// <summary>
        /// �ݒu�R���|�[�l���gState
        /// </summary>
        /// <remarks>
        /// <br>Note		: �R���|�[�l���gState�ݒu���s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void ToolBackState()
        {
            //ADD START ZHOUYU 2011/07/21 �A�� 967�975
            if (!useMast || !outPutCD)
            {
            //ADD END ZHOUYU 2011/07/21 �A�� 967�975
                // �Ώۓ��t
                if (this.Mast_tComboEditor.SelectedIndex == 0)
                {
                    if (this.OutputDiv_tComboEditor.SelectedIndex == 1)
                    {
                        this.tDateEdit_St_AddUpDay.SetDateTime(DateTime.MinValue);
                        this.tDateEdit_Ed_AddUpDay.SetDateTime(DateTime.MinValue);
                    }
                    else
                    {
                        this.tDateEdit_St_AddUpDay.SetDateTime(DateTime.Now);
                        this.tDateEdit_Ed_AddUpDay.SetDateTime(DateTime.Now);
                    }
                }
                else
                {
                    this.tDateEdit_St_AddUpDay.SetDateTime(DateTime.MinValue);
                    this.tDateEdit_Ed_AddUpDay.SetDateTime(DateTime.MinValue);
                }

                // ����
                this.tDateEdit_TotalDay.SetDateTime(DateTime.MinValue);
            }   //ADD ZHOUYU 2011/07/21 �A�� 967�975
            // ���_
            this.tEdit_SectionCode_Ed.Clear();
            this.tEdit_SectionCode_St.Clear();
            // ���Ӑ�
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            //�d����
            this.tNedit_SupplierCd_St.Clear();
            this.tNedit_SupplierCd_Ed.Clear();
            // �{�^���ݒ�
            this.SetIconImage(this.ub_CustomerCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SupplierCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SupplierCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
        }

        #endregion�@�� Private Method


    }
}