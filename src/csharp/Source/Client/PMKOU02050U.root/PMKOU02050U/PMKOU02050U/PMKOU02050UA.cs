//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/06/19  �C�����e : ��ʒ����̓�>=28���A31�Ƃ��܂�
//                                  ��ʂ̋��_�͈͎w��͍폜�i��\���j�֕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : ����
// �C �� ��  2014/04/18  �C�����e : PM.NS�d�|�ꗗNo2370
//                                  Redmine#42500 �e�L�X�g���ڂ��W�����̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : WUPF
// �C �� ��  2014/10/30  �C�����e : Redmine#43866
//                                  �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ���Q��
// �C �� ��  2014/12/26  �C�����e : Redmine43866 #17
//                                  �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C��
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d���`�F�b�N���X�gUI�N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���`�F�b�N���X�gUI�ŁA���o��������͂��܂��B</br>       
    /// <br>Programmer : ����</br>                                   
    /// <br>Date       : 2009.05.10</br> 
    /// <br>Update Note: 2014/04/18 ����</br>
    /// <br>�Ǘ��ԍ�   �F10904597-00 PM.NS�d�|�ꗗNo2370</br>
    /// <br>             Redmine#42500�@�e�L�X�g���ڂ��W�����̑Ή�</br>
    /// </remarks>
    public partial class PMKOU02050UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// �d���`�F�b�N���X�gUI�N���X�R���X�g���N�^�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �@
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���`�F�b�N���X�gUI����������уC���X�^���X�̐������s��</br>                 
        /// <br>Programmer : ����</br>                                  
        /// <br>Date       : 2009.05.10</br>                                     
        /// </remarks>
        public PMKOU02050UA()
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
            this._billAllStAcs = new BillAllStAcs();
            this._billAllStDic = new Dictionary<string, BillAllSt>();

            // �����S�̐ݒ�}�X�^�Ǎ�
            LoadBillAllSt();
        }

        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member

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
        // �ݒ�{�^���\���L���v���p�e�B
        private bool _visibledSetButton = true;
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // ���O�C�����
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private StockSlipCndtn _stockSlipCndtn;

        //���t�擾���i
        private DateGetAcs _dateGet;

        //�G���[�`�F�b�N
        private bool hasCheckError = false;

        //�t�@�C���f�[�^
        private ArrayList _csvData;

        private DateTime stData_st;
        private DateTime stData_ed;

        private Dictionary<string, BillAllSt> _billAllStDic;

        private BillAllStAcs _billAllStAcs;

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private Int32 _tmpSupplierCode;
        // ���݂̃R���g���[��
        private Control _prevControl = null;

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMKOU02050UA";
        // �v���O����ID
        private const string ct_PGID = "PMKOU02050U";
        // ���[����
        private const string PDF_PRINT_NAME = "�d���`�F�b�N���X�g";
        private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "156cc2cb-3afc-45bc-ac54-5017c884fa2f";
        private string _printKey = PDF_PRINT_KEY;
        #endregion �� Interface member

        /// <summary>PMKHN09022A)�d����</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>PMKHN09021E)�d������f�[�^�N���X</summary>
        private Supplier _supplier = null;

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�͐���������܂���B";
        const string ct_NoInput = "���w�肵�Ă��������B";
        const string ct_RangeError = "�͈̔͂Ɍ�肪����܂��B";

        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
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

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            int status = -1;
            if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 0)
            {
                this._csvData = null;
                //�t�@�C���f�[�^
                if (null == this._csvData || 0 == this._csvData.Count)
                {
                    status = this.GetCsvData(out _csvData);
                }
                else
                {
                    status = 0;
                }

                if (status == -1)
                {

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�w�肳�ꂽ�t�@�C���͑��݂��܂���B",
                        status,
                        MessageBoxButtons.OK);
                    this.tEdit_FileName.Focus();
                    return status;
                }
                if (status == -2)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�e�L�X�g�`�����قȂ�܂��B",
                       status,
                       MessageBoxButtons.OK);
                    this.tComboEditor_TextTypeDiv.Focus();
                    return status;
                }
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

            // ���o�����̐ݒ�
            printInfo.jyoken = this._stockSlipCndtn;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion


        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_CheckSectionDiv);
            saveCtrAry.Add(this.tComboEditor_TextTypeDiv);
            saveCtrAry.Add(this.tComboEditor_SupDayCheckDiv);
            saveCtrAry.Add(this.tComboEditor_SectionCdCheckDiv);
            saveCtrAry.Add(this.tComboEditor_SlipNumCheckDiv);
            saveCtrAry.Add(this.tComboEditor_PrintDiv);
            saveCtrAry.Add(this.tEdit_FileName);
            saveCtrAry.Add(this.tNedit_SupplierCd);
            saveCtrAry.Add(this.tEdit_SupplierName);
            saveCtrAry.Add(this.ultraButton_SectionChangeSet);

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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            if (this._prevControl != null)
            {
                hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            bool status = true;

            if (hasCheckError)
            {
                status = false;
                return status;
            }

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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            //return isDefaultState;
            return false;  // UPD 2009/06/18 ��ʂ̋��_�͈͎w��͍폜�i��\���j�֕ύX
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                this.tEdit_FileName.DataText = string.Empty;
                this.tNedit_SupplierCd.DataText = string.Empty;

                // �����l�Z�b�g�E�h���b�v�_�E�����X�g
                Infragistics.Win.ValueListItem listItem;
                // �`�F�b�N�敪
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�o�l�^�d����";
                this.tComboEditor_CheckSectionDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "�d���f�[�^�d��";
                this.tComboEditor_CheckSectionDiv.Items.Add(listItem);

                this.tComboEditor_CheckSectionDiv.Value = 0;

                // �e�L�X�g�`��
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "CSV";
                this.tComboEditor_TextTypeDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "TAB";
                this.tComboEditor_TextTypeDiv.Items.Add(listItem);

                this.tComboEditor_TextTypeDiv.Value = 0;

                // �d�����`�F�b�N
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�Ȃ�";
                this.tComboEditor_SupDayCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "����";
                this.tComboEditor_SupDayCheckDiv.Items.Add(listItem);

                this.tComboEditor_SupDayCheckDiv.Value = 0;

                // ���_�`�F�b�N
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�Ȃ�";
                this.tComboEditor_SectionCdCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "����";
                this.tComboEditor_SectionCdCheckDiv.Items.Add(listItem);

                this.tComboEditor_SectionCdCheckDiv.Value = 0;

                // �`�[�ԍ��`�F�b�N
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�ʏ�";
                this.tComboEditor_SlipNumCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "��6���̂�";
                this.tComboEditor_SlipNumCheckDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "��6���̂�";
                this.tComboEditor_SlipNumCheckDiv.Items.Add(listItem);

                this.tComboEditor_SlipNumCheckDiv.Value = 0;

                // ����敪
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�S��";
                this.tComboEditor_PrintDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "�s��v��";
                this.tComboEditor_PrintDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "��v��";
                this.tComboEditor_PrintDiv.Items.Add(listItem);

                this.tComboEditor_PrintDiv.Value = 0;

                // ���t
                // ��ʒ��������Ɂu�����Z�o���W���[���v���g�p���āA�x�������̊J�n���`�I�������擾����B

                TotalDayCalculator ttlDayCalc = TotalDayCalculator.GetInstance();
                status = ttlDayCalc.InitializeHisPayment();
                DateTime stDate;
                DateTime edDate;
                int convert;
                // �����擾����
                status = ttlDayCalc.GetHisTotalDayPayment(string.Empty, out stDate, out edDate, out convert, out stData_st);

                stData_ed = stDate;

                this.tde_St_AddUpDate.SetDateTime(stData_st);
                this.tde_Ed_AddUpDate.SetDateTime(stDate);
                this.tde_TotalDay.SetDateTime(stDate);

                // �{�^���ݒ�
                this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SupplierGuide, Size16_Index.STAR1);

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();
                if (!string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
                {
                    this._tmpSupplierCode = Convert.ToInt32(this.tNedit_SupplierCd.Text.Trim());
                }
                else
                {
                    this._tmpSupplierCode = 0;
                }


                // �����t�H�[�J�X�Z�b�g
                this.tComboEditor_CheckSectionDiv.Focus();
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
        /// ���t�͈̓`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;

            int checkCode = (int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue;

            // �Ώۓ��t�i�J�n�`�I���j
            if (checkCode == 0 && CallCheckDateRange(out cdrResult, ref tde_St_AddUpDate, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�Ώۓ��t(�J�n){0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�Ώۓ��t(�J�n){0}", ct_InputError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�Ώۓ��t(�I��){0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�Ώۓ��t(�I��){0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώۓ��t{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                }
                status = false;
                this.tde_St_AddUpDate.ResetText();
                this.tde_Ed_AddUpDate.ResetText();
                return status;
            }

            // ����
            if (checkCode == 0)
            {
                if (this.tde_TotalDay.GetLongDate() == 0)
                {
                    errMessage = string.Format("����{0}", ct_NoInput);
                    errComponent = this.tde_TotalDay;
                    status = false;
                    this.tde_TotalDay.ResetText();
                    return status;
                }
            }
            // ����
            if ((this.tde_TotalDay.GetLongDate() != 0) && (TDateTime.IsAvailableDate(this.tde_TotalDay.GetDateTime()) == false))
            {
                errMessage = string.Format("����{0}", ct_InputError);
                errComponent = this.tde_TotalDay;
                status = false;
                this.tde_TotalDay.ResetText();
                return status;
            }
            // ���͒l�́u���v�������S�̐ݒ�́u�����Ώے����v�ɑ��݂��Ȃ��ꍇ�A�G���[���b�Z�[�W�\������B
            if (this.tde_TotalDay.GetLongDate() != 0)
            {
                int day = this.tde_TotalDay.GetDateDay();

                BillAllSt billAllSt;
                // �Ώۋ��_�̐����S�̐ݒ�}�X�^���擾
                billAllSt = this._billAllStDic["00"];

                if (day >= 28)
                {
                    if ((28 > billAllSt.CustomerTotalDay1) && (28 > billAllSt.CustomerTotalDay2) &&
                        (28 > billAllSt.CustomerTotalDay3) && (28 > billAllSt.CustomerTotalDay4) &&
                        (28 > billAllSt.CustomerTotalDay5) && (28 > billAllSt.CustomerTotalDay6) &&
                        (28 > billAllSt.CustomerTotalDay7) && (28 > billAllSt.CustomerTotalDay8) &&
                        (28 > billAllSt.CustomerTotalDay9) && (28 > billAllSt.CustomerTotalDay10) &&
                        (28 > billAllSt.CustomerTotalDay11) && (28 > billAllSt.CustomerTotalDay12))
                    {
                        errMessage = "�����S�̐ݒ�̏����Ώے����ɊY������������܂���B";
                        errComponent = this.tde_TotalDay;
                        return (false);
                    }
                }
                else
                {
                    if ((day != billAllSt.SupplierTotalDay1) && (day != billAllSt.SupplierTotalDay2) &&
                        (day != billAllSt.SupplierTotalDay3) && (day != billAllSt.SupplierTotalDay4) &&
                        (day != billAllSt.SupplierTotalDay5) && (day != billAllSt.SupplierTotalDay6) &&
                        (day != billAllSt.SupplierTotalDay7) && (day != billAllSt.SupplierTotalDay8) &&
                        (day != billAllSt.SupplierTotalDay9) && (day != billAllSt.SupplierTotalDay10) &&
                        (day != billAllSt.SupplierTotalDay11) && (day != billAllSt.SupplierTotalDay12))
                    {
                        errMessage = "�����S�̐ݒ�̏����Ώے����ɊY������������܂���B";
                        errComponent = this.tde_TotalDay;
                        return (false);
                    }
                }
            }

            // �e�L�X�g�t�@�C���� 
            if (checkCode == 0 && string.IsNullOrEmpty(this.tEdit_FileName.Text))
            {
                //errMessage = "�t�@�C���������͂̂��߁A�o�͂ł��Ȃ��B";
                errMessage = "�t�@�C�����������ׁ͂̈A�o�͂ł��܂���B";
                errComponent = this.tEdit_FileName;
                status = false;
                return status;
            }

            // �d���� 
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
            {
                errMessage = string.Format("�d����{0}", ct_NoInput);
                errComponent = this.tNedit_SupplierCd;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �����S�̐ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private int LoadBillAllSt()
        {
            int status = 0;

            try
            {
                ArrayList retList;

                status = this._billAllStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BillAllSt billAllSt in retList)
                    {
                        this._billAllStDic.Add(billAllSt.SectionCode.Trim(), billAllSt);
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #endregion

        #region �� CSV�t�@�C������

        /// <summary>
        /// CSV���擾����
        /// </summary>
        /// <param name="data">�t�@�C���f�[�^</param>
        /// <returns>STATUS�i-1:�t�@�C�����݂��Ȃ�,-2:�e�L�X�g�`�����قȂ�j</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// <br>Update Note: 2014/04/18 ����</br>
        /// <br>�Ǘ��ԍ�   �F10904597-00 PM.NS�d�|�ꗗNo2370</br>
        /// <br>             Redmine#42500�@�e�L�X�g���ڂ��W�����̑Ή�</br>
        /// <br>Update Note: 2014/10/30 WUPF</br>
        /// <br>�Ǘ��ԍ�   �F11070149-00  Redmine#43866</br>
        /// <br>           �F�X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C��</br>
        /// <br>Update Note: 2014/12/26 ���Q��</br>
        /// <br>�Ǘ��ԍ�   �F11070149-00  Redmine43866 #17</br>
        /// <br>           �F�X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C��</br>
        /// </remarks>
        public int GetCsvData(out ArrayList data)
        {
            data = new ArrayList();
            string fileName = this.tEdit_FileName.Text;
            // �e�L�X�g�t�@�C�����݂��Ȃ������ꍇ
            if (!File.Exists(fileName))
            {
                return -1;
            }
            StreamReader sr;

            char splitStr;
            // �e�L�X�g�t�@�C���̌`��
            if ((int)this.tComboEditor_TextTypeDiv.SelectedItem.DataValue == 0)
            {
                // �J���}��؂�
                splitStr = ',';

            }
            else
            {
                // TAB��؂�
                splitStr = '	';
            }

            try
            {
                sr = new StreamReader(fileName, Encoding.GetEncoding("shift_jis"));

                StockSlipTextData stockSlipTextData = null;
                string nowYear1 = DateTime.Now.ToString("yyyyMMdd").Substring(0, 3);
                string nowYear2 = DateTime.Now.ToString("yyyyMMdd").Substring(0, 2);

                while (sr.Peek() >= 0)
                {
                    string lineText = sr.ReadLine();

                    if (lineText.Trim().Length != 0)
                    {
                        stockSlipTextData = new StockSlipTextData();
                        string[] csvData = new string[10];
                        csvData = lineText.Split(splitStr);
                        // �d����
                        // ADD ���Q�� 2014/12/26 Redmine43866 #17 �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C�� ---->>>>>
                        if (csvData[2] != null)
                        {
                            csvData[2] = csvData[2].Trim();
                        }
                        // ADD ���Q�� 2014/12/26 Redmine43866 #17 �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C�� ----<<<<<
                        bool dateIsNum = IsNum(csvData[2]);
                        if (dateIsNum)
                        {
                            // �d�����ϊ�
                            if (csvData[2].Length == 5)
                            {
                                stockSlipTextData.StockDate = nowYear1 + csvData[2];
                            }
                            else if (csvData[2].Length == 6)
                            {
                                stockSlipTextData.StockDate = nowYear2 + csvData[2];
                            }
                            else if (csvData[2].Length == 8)
                            {
                                stockSlipTextData.StockDate = csvData[2];
                            }
                            else
                            {
                                stockSlipTextData.StockDate = "17000101";
                            }

                            try
                            {
                                DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                            }
                            catch
                            {
                                stockSlipTextData.StockDate = "17000101";
                            }
                        }
                        else
                        {
                            stockSlipTextData.StockDate = "17000101";
                        }

                        // �d���`�[��
                        //stockSlipTextData.SupplierSlipNo = csvData[3];// DEL WUPF 2014/10/30 Redmine#43866 �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C��

                        // ADD WUPF 2014/10/30 Redmine#43866 �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C�� ---->>>>>
                        if (csvData[3] != null)
                        {
                            stockSlipTextData.SupplierSlipNo = csvData[3].Trim();
                        }
                        else
                        {
                            stockSlipTextData.SupplierSlipNo = csvData[3];
                        }
                        // ADD WUPF 2014/10/30 Redmine#43866 �X�y�[�X���Z�b�g����Ă���ƕs��v ��Q�Ή��̏C���̏C�� ----<<<<<

                        // �d�����z
                        stockSlipTextData.StockPrice = Convert.ToInt64(csvData[4]);
                        // �c�Ə��R�[�h
                        string zero = "0000000000";
                        // --- ADD 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�---------->>>>>
                        if (csvData.Length <= 6)
                        {
                            stockSlipTextData.StockSectionCd = zero;
                        }
                        else
                        {
                        // --- ADD 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�---------->>>>>
                            if (!string.IsNullOrEmpty(csvData[6]))
                            {
                                bool cdIsNum = IsNum(csvData[6].Trim());
                                if (cdIsNum)
                                {
                                    if (csvData[6].Trim().Length < 10)
                                    {
                                        stockSlipTextData.StockSectionCd = zero.Substring(0, (10 - csvData[6].Trim().Length)) + csvData[6].Trim();
                                    }
                                    else
                                    {
                                        stockSlipTextData.StockSectionCd = csvData[6].Trim().Substring(0, 10);
                                    }

                                }
                                else
                                {
                                    stockSlipTextData.StockSectionCd = zero;
                                }
                            }
                            else
                            {
                                stockSlipTextData.StockSectionCd = zero;
                            }
                        }//ADD 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�

                        // --- DEL 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�---------->>>>>
                        //// ���l
                        //stockSlipTextData.Note = csvData[7];
                        // --- DEL 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�----------<<<<<
                        // --- ADD 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�---------->>>>>
                        try
                        {
                            // ���l
                            stockSlipTextData.Note = csvData[7];
                        }
                        catch
                        {
                            // ���l
                            stockSlipTextData.Note = string.Empty;
                        }
                        // --- ADD 2014/04/18 PM.NS�d�|�ꗗNo2370  �e�L�X�g���ڂ��W�����̑Ή�----------<<<<<

                        stockSlipTextData.IsChecked = false;
                        // �d���悩��̐����f�[�^(�e�L�X�g�t�@�C��)�̒��o�͈͂�ݒ�
                        if (DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null) >= this.tde_St_AddUpDate.GetDateTime()
                            && DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null) <= this.tde_Ed_AddUpDate.GetDateTime())
                        {
                            data.Add(stockSlipTextData);
                        }

                    }
                }
                return 0;
            }
            catch
            {
                return -2;
            }
        }


        /// <summary>
        /// �S��NUM�̔��f����
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>false�FNUM�ȊO���݁Gtrue�F�S��NUM</returns>
        /// <remarks>
        /// <br>Note       : �S��NUM�̔��f��������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public bool IsNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str, i))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion �� CSV�t�@�C������

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._stockSlipCndtn = new StockSlipCndtn();
            try
            {
                // ��ƃR�[�h
                this._stockSlipCndtn.EnterpriseCode = this._enterpriseCode;
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

                // ���_�I�v�V����
                this._stockSlipCndtn.IsOptSection = this._isOptSection;
                // �v�㋒�_�R�[�h�i�����w��j
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._stockSlipCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // �`�F�b�N�敪
                this._stockSlipCndtn.CheckSectionDiv = (StockSlipCndtn.CheckSectionDivState)this.tComboEditor_CheckSectionDiv.Value;

                // �Ώۓ��t
                if (!DateTime.MinValue.Equals(this.tde_TotalDay.GetDateTime()))
                {
                    int day = this.tde_TotalDay.GetDateDay();
                    
                    if (day >= 28)
                    {
                        this._stockSlipCndtn.St_addUpDate = this.tde_TotalDay.GetDateTime().AddDays(1-day);
                        this._stockSlipCndtn.Ed_addUpDate = this.tde_TotalDay.GetDateTime().AddDays(1 - day).AddMonths(1).AddDays(-1);
                    }
                    else
                    {
                        this._stockSlipCndtn.St_addUpDate = this.tde_TotalDay.GetDateTime().AddMonths(-1).AddDays(1);
                        this._stockSlipCndtn.Ed_addUpDate = this.tde_TotalDay.GetDateTime();
                    }
                    
                }
                else
                {
                    this._stockSlipCndtn.St_addUpDate = this.stData_ed.AddDays(1);

                }

                this._stockSlipCndtn.St_addUpDateShow = this.tde_St_AddUpDate.GetDateTime();
                this._stockSlipCndtn.Ed_addUpDateShow = this.tde_Ed_AddUpDate.GetDateTime();


                // ����
                this._stockSlipCndtn.TotalDay = this.tde_TotalDay.GetDateTime();

                // �d�����`�F�b�N
                this._stockSlipCndtn.SupDayCheckDiv = (StockSlipCndtn.SupDayCheckDivState)this.tComboEditor_SupDayCheckDiv.SelectedItem.DataValue;

                // ���_�`�F�b�N
                this._stockSlipCndtn.SectionCdCheckDiv = (StockSlipCndtn.SectionCdCheckDivState)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue;

                // �`�[�ԍ��`�F�b�N
                this._stockSlipCndtn.SlipNumCheckDiv = (StockSlipCndtn.SlipNumCheckDivState)this.tComboEditor_SlipNumCheckDiv.SelectedItem.DataValue;

                // ����敪
                this._stockSlipCndtn.PrintDiv = (StockSlipCndtn.PrintDivState)this.tComboEditor_PrintDiv.SelectedItem.DataValue;

                // �d����R�[�h
                this._stockSlipCndtn.SupplierCd = this.tNedit_SupplierCd.GetInt();

                // �d���於
                this._stockSlipCndtn.SupplierNm = this.tEdit_SupplierName.Text;

                // CSV�f�[�^
                this._stockSlipCndtn.CsvData = this._csvData;
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.05.10</br>
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

        #endregion �� Private Method

        # region Control Events

        /// <summary>
        /// PMKOU02050UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void PMKOU02050UA_Load(object sender, EventArgs e)
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
            this.SetIconImage(this.ub_SupplierGuide, Size16_Index.STAR1);

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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // �^�C�g���o�[�̕�����
                    openFileDialog.Title = "�d���搿���f�[�^�t�@�C���I��";
                    openFileDialog.RestoreDirectory = true;
                    if (this.tEdit_FileName.Text.Trim() == string.Empty)
                    {
                        openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                    }
                    else
                    {
                        openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_FileName.Text);
                        openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_FileName.Text);
                    }

                    //�u�t�@�C���̎�ށv���w��
                    openFileDialog.Filter = "�e�L�X�g�t�@�C�� (*.TXT)|*.TXT|���ׂẴt�@�C�� (*.*)|*.*";

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
        /// �d����K�C�h�N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SupplierGuide_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�\��
            int status = 0;
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }
            status = this._supplierAcs.ExecuteGuid(out _supplier, this._enterpriseCode, "");

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd.SetInt(_supplier.SupplierCd);
                this.tEdit_SupplierName.Text = _supplier.SupplierSnm.Trim();
                _tmpSupplierCode = _supplier.SupplierCd;
                this.tComboEditor_CheckSectionDiv.Focus();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Text = "";
            }
        }

        /// <summary>
        /// �`�F�b�N�敪�@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CheckSectionDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 1)
            {
                // �`�F�b�N�敪���d���f�[�^�d���̏ꍇ
                this.tde_St_AddUpDate.Enabled = false;
                this.tde_Ed_AddUpDate.Enabled = false;
                this.tComboEditor_TextTypeDiv.Enabled = false;
                this.tEdit_FileName.Enabled = false;
                this.ultraButton_FileName.Enabled = false;
                this.ultraButton_SectionChangeSet.Enabled = false;
                this.tComboEditor_SlipNumCheckDiv.Enabled = false;
                this.tComboEditor_PrintDiv.Enabled = false;
            }
            else if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 0)
            {
                // �`�F�b�N�敪��PM/�d����̏ꍇ
                this.tde_St_AddUpDate.Enabled = true;
                this.tde_Ed_AddUpDate.Enabled = true;
                this.tComboEditor_TextTypeDiv.Enabled = true;
                this.tEdit_FileName.Enabled = true;
                this.ultraButton_FileName.Enabled = true;
                this.tComboEditor_SlipNumCheckDiv.Enabled = true;
                // ���_�`�F�b�N������̏ꍇ
                this.ultraButton_SectionChangeSet.Enabled = true;
                this.tComboEditor_PrintDiv.Enabled = true;

                if (this.tComboEditor_SectionCdCheckDiv.SelectedItem != null)
                {
                    if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 0)
                    {
                        // ���_�`�F�b�N���Ȃ��̏ꍇ
                        this.ultraButton_SectionChangeSet.Enabled = false;
                    }
                    else if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 1)
                    {
                        // ���_�`�F�b�N������̏ꍇ
                        this.ultraButton_SectionChangeSet.Enabled = true;
                    }
                }

            }
        }

        /// <summary>
        /// ���_�`�F�b�N�@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SectionCdCheckDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 0)
            {
                if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 0)
                {
                    // ���_�`�F�b�N���Ȃ��̏ꍇ
                    this.ultraButton_SectionChangeSet.Enabled = false;
                }
                else if ((int)this.tComboEditor_SectionCdCheckDiv.SelectedItem.DataValue == 1)
                {
                    // ���_�`�F�b�N������̏ꍇ
                    this.ultraButton_SectionChangeSet.Enabled = true;
                }
            }

        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            if (e.NextCtrl != this.ueb_MainExplorerBar)
            {
                this._prevControl = e.NextCtrl;
            }
            switch (e.PrevCtrl.Name)
            {
                // �d����R�[�h
                case "tNedit_SupplierCd":
                    {
                        int code = this.tNedit_SupplierCd.GetInt();
                        string name = this.tEdit_SupplierName.Text.Trim();

                        if (this._tmpSupplierCode != code)
                        {
                            if (code == 0)
                            {
                                this._tmpSupplierCode = code;
                                name = "";

                                this.tNedit_SupplierCd.SetInt(code);
                                this.tEdit_SupplierName.Text = name;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.ub_SupplierGuide;
                                }
                            }
                            else
                            {
                                Supplier supplier;
                                if (this._supplierAcs == null)
                                {
                                    this._supplierAcs = new SupplierAcs();
                                }
                                int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._tmpSupplierCode = code;
                                    this.tNedit_SupplierCd.SetInt(code);
                                    this.tEdit_SupplierName.Text = supplier.SupplierSnm;
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tComboEditor_CheckSectionDiv;
                                    }

                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�d���悪���݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                    hasCheckError = true;
                                    this.tNedit_SupplierCd.SetInt(_tmpSupplierCode);

                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        // �� 2009.07.07 ���m modify PVCS NO.307
                                        // e.NextCtrl = this.ub_SupplierGuide;
                                        e.NextCtrl = e.PrevCtrl;
                                        // �� 2009.07.07 ���m modify
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "�d����̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);
                                    hasCheckError = true;
                                    this.tNedit_SupplierCd.SetInt(_tmpSupplierCode);
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.ub_SupplierGuide;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (code == 0)
                            {
                                this._tmpSupplierCode = code;
                                name = "";

                                this.tNedit_SupplierCd.SetInt(code);
                                this.tEdit_SupplierName.Text = name;

                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.ub_SupplierGuide;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if ((int)this.tComboEditor_CheckSectionDiv.SelectedItem.DataValue == 1)
                                        {
                                            e.NextCtrl = this.tComboEditor_SectionCdCheckDiv;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ultraButton_FileName;
                                        }

                                    }
                                }


                            }
                        }
                        break;
                    }
                case "ub_SupplierGuide":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {

                                e.NextCtrl = this.tNedit_SupplierCd;
                            }
                        }
                        break;
                    }
                case "tComboEditor_CheckSectionDiv":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ub_SupplierGuide;
                            }
                        }
                        break;
                    }
            }

        }

        /// <summary>
        /// Control.Click �C�x���g(New_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �V�K�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2009.05.10</br>
        /// </remarks>
        private void ultraButton_SectionChangeSet_Click(object sender, EventArgs e)
        {
            PMKOU02050UB pmkou02050 = new PMKOU02050UB();
            DialogResult dialogResult = pmkou02050.ShowDialog(this);
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
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
