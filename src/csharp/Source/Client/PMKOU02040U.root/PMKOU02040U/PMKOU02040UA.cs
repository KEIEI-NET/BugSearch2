//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���s�����m�F�\
// �v���O�����T�v   : �d���s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/13  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �d���s�����m�F�\�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���s�����m�F�\�t�H�[���N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.13</br>
    /// </remarks>
    public partial class PMKOU02040UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {

        #region �� Constructor

        /// <summary>
        /// �d���s�����m�F�\UI�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���s�����m�F�\UI�N���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02040UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // �d��������ꗗ�\�A�N�Z�X�N���X
            this._stockSalesInfoMainAcs = new StockSalesInfoMainAcs();

            //_loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

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

        //���_�A�N�Z�X
        private SecInfoAcs _mSecInfoAcs = null;

        // �d��������ꗗ�\�A�N�Z�X�N���X
        private StockSalesInfoMainAcs _stockSalesInfoMainAcs;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();

        //���t�擾���i
        private DateGetAcs _dateGet;

        //���_�R�[�h
        private string _loginSectionCode = string.Empty;

        #endregion

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMKOU02040UA";
        // �v���O����ID
        private const string ct_PGID = "PMKOU02040U";
        // ���[����
        private const string ct_PrintName = "�d���s�����m�F�\";
        // ���[�L�[	
        private const string ct_PrintKey = "a1521de4-9264-48d5-af87-ea5ad569213b";
        //�S��
        private const string ct_All = "00";

        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���

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
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tDateEdit_YearMonth);
            saveCtrAry.Add(this.tDateEdit_LastCAddUpUpdDate);
            saveCtrAry.Add(this.tDateEdit_CAddUpUpdDate);

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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�d���s�����m�F�\�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
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
            StockSalesInfoMainCndtn extrInfo = new StockSalesInfoMainCndtn();

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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŏ����̕K�v���Ȃ�
        }
        #endregion
        #endregion

        #region �� Control Event
        #region �� PMKOU02040UA
        #region �� PMKOU02040UA_Load Event
        /// <summary>
        /// PMKOU02040UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ���������s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void PMKOU02040UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
        }
        #endregion
        #endregion �� PMKOU02040UA

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
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R���g���[��������
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }

                ParentToolbarSettingEvent(this);	// �c�[���o�[�ݒ�C�x���g
            }
            finally
            {
                this.tDateEdit_YearMonth.Focus();
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion �� Initialize_Timer

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009/04/13</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup))
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
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009/04/13</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary> 
        /// UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g 
        /// </summary> 
        /// <param name="targetControls">�R���|�[�l���g</param> 
        /// <param name="customizeData">�ۑ��f�[�^</param> 
        /// <remarks> 
        /// <br>Programmer : ���痈 </br> 
        /// <br>Date       : 2009.04.13</br> 
        /// <br>���s�����`�F�b�N�{�b�N�X�̏�Ԃ𕜌�����B</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                this.tDateEdit_YearMonth.LongDate = int.Parse(customizeData[0]);
                this.tDateEdit_LastCAddUpUpdDate.LongDate = int.Parse(customizeData[1]);
                this.tDateEdit_CAddUpUpdDate.LongDate = int.Parse(customizeData[2]);
            }
        }

        /// <summary> 
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g 
        /// </summary> 
        /// <param name="targetControls">�R���|�[�l���g</param> 
        /// <param name="customizeData">�ۑ��f�[�^</param> 
        /// <remarks> 
        /// <br>Programmer : ���痈</br> 
        /// <br>Date       : 2009.04.13</br> 
        /// <br>���s�����`�F�b�N�{�b�N�X�̏�Ԃ�ۑ�����B</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[3];
            customizeData[0] = this.tDateEdit_YearMonth.LongDate.ToString();
            customizeData[1] = this.tDateEdit_LastCAddUpUpdDate.LongDate.ToString();
            customizeData[2] = this.tDateEdit_CAddUpUpdDate.LongDate.ToString();
        }
        #endregion

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                //�O���������
                DateTime prevTotalDay = DateTime.MinValue;
                //�����������
                DateTime currentTotalDay = DateTime.MinValue;
                //�O���������
                DateTime prevTotalMonth = DateTime.MinValue;
                //�����������
                DateTime currentTotalMonth = DateTime.MinValue;

                int convertProcessDivCd = 0;

                // �����������擾����
                totalDayCalculator.InitializeHisMonthlyAccPay();
                //ct_All
                totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd);

                if (currentTotalMonth != DateTime.MinValue)
                {
                    // �Ώ۔N����ݒ�
                    this.tDateEdit_YearMonth.SetDateTime(currentTotalMonth);
                    // �O�����������ݒ�
                    //this.tDateEdit_LastCAddUpUpdDate.SetDateTime(prevTotalDay);
                    this.tDateEdit_LastCAddUpUpdDate.SetDateTime(prevTotalDay.AddDays(1.0));
                    // �������������ݒ�
                    this.tDateEdit_CAddUpUpdDate.SetDateTime(currentTotalDay);
                }
                else
                {
                    //�N���x ( ����01 )
                    DateTime thisYearMonth;
                    //�N�x
                    Int32 thisYear;
                    //�N���x�J�n��
                    DateTime startMonthDate;
                    //�N���x�I����
                    DateTime endMonthDate;
                    //�N�x�J�n��
                    DateTime startYearDate;
                    //�N�x�I����
                    DateTime endYearDate;

                    this._dateGet.GetThisYearMonth(out thisYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);
                    // �Ώ۔N����ݒ�
                    this.tDateEdit_YearMonth.SetDateTime(thisYearMonth);
                    // �N�x�J�n����ݒ�
                    this.tDateEdit_LastCAddUpUpdDate.SetDateTime(startYearDate);
                    // �N�x�I������ݒ�
                    this.tDateEdit_CAddUpUpdDate.SetDateTime(endYearDate);
                }

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                //this.uiMemInput1.ReadMemInput();

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
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

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
        /// <br>Date	   : 2009.04.13</br>
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

        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(StockSalesInfoMainCndtn extraInfo)
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

                //�Ώ۔N��
                int longDate = this.tDateEdit_YearMonth.LongDate;
                longDate = (longDate / 100) * 100 + 1;
                this.tDateEdit_YearMonth.SetLongDate(longDate);
                extraInfo.YearMonth = this.tDateEdit_YearMonth.GetDateTime();

                //�O���������
                extraInfo.PrevTotalDay = this.tDateEdit_LastCAddUpUpdDate.GetDateTime();
                //�����������
                extraInfo.CurrentTotalDay = this.tDateEdit_CAddUpUpdDate.GetDateTime();

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
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Date		: 2009.04.13</br>
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