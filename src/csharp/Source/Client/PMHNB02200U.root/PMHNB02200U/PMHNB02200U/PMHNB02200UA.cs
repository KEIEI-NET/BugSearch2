//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������A���}�b�`���X�g
// �v���O�����T�v   : ���������A���}�b�`���X�gUI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/07/22  �C�����e : �폜������̃E�B���h�E�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/07/22  �C�����e : �o�c�e�\�������̕ύX
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������A���}�b�`���X�gUI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������A���}�b�`���X�gUI�t�H�[���N���X</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public partial class PMHNB02200UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypeUpdate,
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���������A���}�b�`���X�gUI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������A���}�b�`���X�gUI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        public PMHNB02200UA()
        {
            InitializeComponent();

            _updateBtnClicked = false;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionHashtable = new Hashtable();

            // ���������A���}�b�`���X�g�A�N�Z�X
            this._rateUnMatchAcs = new RateUnMatchAcs();
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member

        // ���s�{�^�����N���b�N���邩�ǂ���
        private bool _updateBtnClicked;

        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���s�{�^����Ԏ擾�v���p�e�B
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

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;
        // �I�����_�n�b�V���e�[�u��
        private Hashtable _selectedSectionHashtable = new Hashtable();
        // ���������A���}�b�`���X�g�A�N�Z�X�N���X
        private RateUnMatchAcs _rateUnMatchAcs;
        // �L�����Z�����ǂ���
        private bool _isCancel = false;
        // �폜�p�̑S�ăf�[�^���X�g
        private ArrayList _delList;
        // �폜�����p�̃R���g���[��
        private BackgroundWorker bw;
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        #endregion �� Private Member

        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���s�{�^����Ԏ擾�v���p�e�B </summary>
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
        #endregion �� Public Property

        #region �� Private Const
        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMHNB02200UA";
        // �v���O����ID
        private const string ct_PGID = "PMHNB02200U";
        // ���[����
        private string _printName = "���������A���}�b�`���X�g";
        // ���[�L�[	
        private string _printKey = "461a402f-20c6-4b5e-817f-790237550131";
        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ProcessConditionGroup = "ProcessConditionGroup";	// ��������
        private const string ct_ExBarGroupNm_ProcessResultGroup = "ProcessResultGroup";		    // ��������
        #endregion �� Interface member

        #region �����敪�̃f�[�^�ƃ^�C�g��
        const string ct_ProcessKbn_Print = "����̂�";
        const string ct_ProcessKbn_PrintDelete = "������폜";
        const string ct_ProcessKbn_Delete = "�폜�̂�";
        #endregion
        const string ct_ErrorMsg = "�I���o���Ȃ��敪�ł��B";
        #endregion �� Private Const

        #region �� PMHNB02200UA_Load Event
        /// <summary>
        /// PMHNB02200UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void PMHNB02200UA_Load(object sender, EventArgs e)
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
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��  
        }
        #endregion

        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
                // ����̂�
                listItem0.DataValue = 0;
                listItem0.DisplayText = ct_ProcessKbn_Print;

                // ������폜
                Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
                listItem1.DataValue = 1;
                listItem1.DisplayText = ct_ProcessKbn_PrintDelete;

                // �폜�̂�
                Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
                listItem2.DataValue = 2;
                listItem2.DisplayText = ct_ProcessKbn_Delete;

                this.tComboEditor_ProcessKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });

                // �u����̂݁v��I������Ă��܂�
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();

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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            // ������
            return true;
        }

        #region �� ���j���[�{�^���`�F�b�N����
        /// <summary>
        /// ���j���[�{�^���`�F�b�N����
        /// </summary>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̃��j���[�{�^���`�F�b�N���s���B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private bool MenuButtonCheck()
        {
            bool status = true;
            // PDF�\���{�^�����N���b�N����ꍇ�A�����敪���`�F�b�N����
            if (_updateBtnClicked == false)
            {
                // �u������폜�v�Ɓu�폜�̂݁v��I������ꍇ
                // upd by liuxz on 2009/07/22 start
                // if ((int)this.tComboEditor_ProcessKbn.Value == 2)
                if ((int)this.tComboEditor_ProcessKbn.Value == 1 || (int)this.tComboEditor_ProcessKbn.Value == 2)
                // upd by liuxz on 2009/07/22 end
                {
                    status = false;
                    // ���b�Z�[�W��\��
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_ErrorMsg, 0);
                    this.tComboEditor_ProcessKbn.Focus();
                }
            }
            return status;
        }
        #endregion �� ���̓`�F�b�N����
        #endregion �� ����O�m�F����

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // �����ݒ�폜����
            this.uLabel_DelUnitPriceKind1Cnt.Text = "0��";
            // �����ݒ�폜����
            this.uLabel_DelUnitPriceKind2Cnt.Text = "0��";
            // �艿�ݒ�폜����
            this.uLabel_DelUnitPriceKind3Cnt.Text = "0��";

            // �����敪���u�폜�̂݁v�̏ꍇ�APDF�{�^�����N���b�N����`�F�b�N
            if (MenuButtonCheck() == false)
            {
                _updateBtnClicked = false;
                return -1;
            }
            _updateBtnClicked = false;

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = _printKey;
            printInfo.prpnm = _printName;
            printInfo.PrintPaperSetCd = 0;
            // ���o�����N���X
            RateUnMatchCndtn extrInfo = new RateUnMatchCndtn();

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
            if (dialogResult != DialogResult.Cancel)
            {
                // �v���r���[�̏ꍇ
                if (printDialog.EnablePreview == 1)
                {
                    // �v���r���[��ʂ����ꍇ
                    if (printInfo.status == -1)
                    {
                        printInfo.status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                switch (printInfo.status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
                        break;
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        break;
                }

                parameter = printInfo;
                this._isCancel = false;
            }
            else
            {
                // �L�����Z��
                this._isCancel = true;
            }

            return printInfo.status;
        }

        #region �� �����̃t�H�[�}�b�g
        /// <summary>
        /// �����̃t�H�[�}�b�g
        /// </summary>
        /// <param name="number">����</param>
        /// <remarks>
        /// <br>Note		: �����̃t�H�[�}�b�g(999,999,999)��ϊ�����</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }

            return ret;
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(RateUnMatchCndtn rateUnMatchCndtn)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ���_�I�v�V����
                rateUnMatchCndtn.IsOptSection = this._isOptSection;
                // ��ƃR�[�h
                rateUnMatchCndtn.EnterpriseCode = this._enterpriseCode;
                // �I�����_
                // �S�БI�����ǂ���
                if ((this._selectedSectionHashtable.Count == 1) && this._selectedSectionHashtable.ContainsKey("0"))
                {
                    rateUnMatchCndtn.SectionCodes = null;
                }
                else
                {
                    rateUnMatchCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionHashtable.Values).ToArray(typeof(string));
                }
                // �����敪
                rateUnMatchCndtn.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion

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

        #region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // �I���n�b�V���e�[�u��������
            this._selectedSectionHashtable.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionHashtable.Add(wk, wk);
            }
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� ���_�I������
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if (sectionCode == "0")
                {
                    this._selectedSectionHashtable.Clear();

                }

                if (!this._selectedSectionHashtable.ContainsKey(sectionCode))
                {
                    this._selectedSectionHashtable.Add(sectionCode, sectionCode);
                }
            }
            // ���_�I��������������
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionHashtable.ContainsKey(sectionCode))
                {
                    this._selectedSectionHashtable.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region �� ���s����
        /// <summary>
        /// ���s����
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �X�V�{����������s���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            string errMsg = string.Empty;

            // �����ݒ�폜����
            this.uLabel_DelUnitPriceKind1Cnt.Text = "0��";
            // �����ݒ�폜����
            this.uLabel_DelUnitPriceKind2Cnt.Text = "0��";
            // �艿�ݒ�폜����
            this.uLabel_DelUnitPriceKind3Cnt.Text = "0��";

            // �����敪���u�폜�̂݁v�̏ꍇ
            if ((int)this.tComboEditor_ProcessKbn.Value == 2)
            {
                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                             ct_ClassID,
                             "�Ώۃf�[�^�̍폜�����s���܂����H",
                             0,
                             MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                // ���o����ʕ��i�̃C���X�^���X���쐬
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "���o��";
                form.Message = "���݁A�f�[�^�𒊏o���ł��B";

                this._rateUnMatchAcs = new RateUnMatchAcs();
                try
                {
                    // �_�C�A���O�\��
                    form.Show();

                    // ���o�����N���X
                    RateUnMatchCndtn extrInfo = new RateUnMatchCndtn();

                    // ��ʁ����o�����N���X
                    status = this.SetExtraInfoFromScreen(extrInfo);
                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return -1;
                    }

                    // ��������
                    status = this._rateUnMatchAcs.SearchAllForDelete(extrInfo, out this._delList, out errMsg);

                    // �_�C�A���O�����
                    form.Close();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
                    }
                    else if (status != (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                    {
                         // �\��������ݒ�
                        form.Title = "�폜��";
                        form.Message = "���݁A�f�[�^���폜���ł��B";
                        // �_�C�A���O�\��
                        form.Show();
                        // �폜����
                        status = this._rateUnMatchAcs.Delete(this._delList, out errMsg);
                        // �_�C�A���O�����
                        form.Close();
                        switch (status)
                        {
                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                // �����ݒ�폜����
                                this.uLabel_DelUnitPriceKind1Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind1Cnt) + "��";
                                // �����ݒ�폜����
                                this.uLabel_DelUnitPriceKind2Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind2Cnt) + "��";
                                // �艿�ݒ�폜����
                                this.uLabel_DelUnitPriceKind3Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind3Cnt) + "��";

                                // upd by liuxz on 2009/07/22 start
                                //// �o�^����
                                //SaveCompletionDialog dialog = new SaveCompletionDialog();
                                //dialog.ShowDialog(2);
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�폜���܂����B", 0);
                                // upd by liuxz on 2009/07/22 end
                                break;
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�X�V�����Ŕr���G���[�ƂȂ�܂����B���̊|���}�X�^�֘A�o�f���I�������A�ēx���������s���ĉ������B", status);
                                break;
                            default:
                                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // �_�C�A���O�����
                    form.Close();
                    errMsg = ex.Message;
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                this._updateBtnClicked = true;
                bw = new BackgroundWorker();
                bw.DoWork += bw_DoWork;
                bw.RunWorkerAsync();

                // �������
                status = Print(ref parameter);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && this._isCancel == false)
                {
                    // �u����̂݁v�ȊO�̏ꍇ
                    if ((int)this.tComboEditor_ProcessKbn.Value != 0)
                    {
                        // �x�����b�Z�[�W
                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                    ct_ClassID,
                                                    "�Ώۃf�[�^�̍폜�����s���܂����H",
                                                    0,
                                                    MessageBoxButtons.YesNo);
                        if (dr != DialogResult.No)
                        {
                            // ���o����ʕ��i�̃C���X�^���X���쐬
                            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                            // �\��������ݒ�
                            form.Title = "�폜��";
                            form.Message = "���݁A�f�[�^���폜���ł��B";
                            // �_�C�A���O�\��
                            form.Show();

                            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^
                            status = this._rateUnMatchAcs.Delete(this._delList, out errMsg);
                            // �_�C�A���O�����
                            form.Close();
                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    // �����ݒ�폜����
                                    this.uLabel_DelUnitPriceKind1Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind1Cnt) + "��";
                                    // �����ݒ�폜����
                                    this.uLabel_DelUnitPriceKind2Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind2Cnt) + "��";
                                    // �艿�ݒ�폜����
                                    this.uLabel_DelUnitPriceKind3Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind3Cnt) + "��";

                                    // upd by liuxz on 2009/07/22 start
                                    //// �o�^����
                                    //SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    //dialog.ShowDialog(2);
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�폜���܂����B", 0);
                                    // upd by liuxz on 2009/07/22 end
                                    break;
                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�X�V�����Ŕr���G���[�ƂȂ�܂����B���̊|���}�X�^�֘A�o�f���I�������A�ēx���������s���ĉ������B", status);
                                    break;
                                default:
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                                    break;
                            }
                        }
                    }
                }
            }

            return status;
        }
        #endregion

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ProcessConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ProcessResultGroup))
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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ProcessConditionGroup) ||
               (e.Group.Key == ct_ExBarGroupNm_ProcessResultGroup))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }
        #endregion
        #endregion �� ueb_MainExplorerBar

        #region �� BackgroundWorker Event
        /// <summary>
        /// �폜�����p�̃C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �폜�����p�̃C�x���g�����B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void bw_DoWork(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // ���o�����N���X
            RateUnMatchCndtn extrInfo = new RateUnMatchCndtn();

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }

            // ��������
            status = this._rateUnMatchAcs.SearchAllForDelete(extrInfo, out this._delList, out errMsg);
        }
        #endregion

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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
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
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.01</br>
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

    }
}