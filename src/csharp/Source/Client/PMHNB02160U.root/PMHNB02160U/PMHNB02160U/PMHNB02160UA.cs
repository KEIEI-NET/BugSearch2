using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 �s��Ή�[12911]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ������e���͕\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������e���͕\UI�t�H�[���N���X</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>Update Note: 2008.11.21 30452 ��� �r��</br>
    /// <br>            �E�Ώۓ��t�`�F�b�N�C��</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHNB02160UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB02160UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // ���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            // �K�C�h�A�N�Z�X�N���X������
            this._employeeAcs = new EmployeeAcs();
            this._userGuideAcs = new UserGuideAcs();

            // ���o�����N���X
            this._salesHistAnalyzeCndtn = new SalesHistAnalyzeCndtn();
        }
        #endregion

        #region �� private�萔
        #region Interface�֘A
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMHNB02160UA";
        // �v���O����ID
        private const string ct_PGID = "PMHNB02160U";
        //// ���[����
        private string _printName = "������e���͕\";
        // ���[�L�[	
        private string _printKey = "95eb6a52-7c60-44e7-bea3-b58a452a8d31";
        #endregion
        #endregion

        #region �� private�ϐ�

        #region Interface�֘A
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
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ���t�擾���i
        private DateGetAcs _dateGet;
        // �]�ƈ��}�X�^�A�N�Z�X�N���X
        EmployeeAcs _employeeAcs;
        // ���[�U�}�X�^�A�N�Z�X�N���X�i�n��K�C�h�p�j
        private UserGuideAcs _userGuideAcs;
        

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;
        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ������e���͕\ ���o�����f�[�^�N���X
        private SalesHistAnalyzeCndtn _salesHistAnalyzeCndtn;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // ADD 2009/03/31 �s��Ή�[12911]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
        /// <summary>�݌v������W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _monthReportDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// �݌v������W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>�݌v������W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper MonthReportDivRadioKeyPressHelper
        {
            get { return _monthReportDivRadioKeyPressHelper; }
        }

        /// <summary>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _newPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 �s��Ή�[12911]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<

        #endregion

        #region �� IPrintConditionInpType �����o
        #region �C�x���g
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Public�v���p�e�B
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

        #endregion

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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            printInfo.PrintPaperSetCd = 0;
            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._salesHistAnalyzeCndtn;
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

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
            return;
        }
        #endregion

        #endregion
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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
            get { return this._printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� private���\�b�h
        /// <summary>
		/// ��ʏ���������
		/// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ��������s��</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �K�C�h�{�^���ݒ�
                this.SetIconImage(this.uButton_CustomerCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCodeEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCodeEdGuid, Size16_Index.STAR1);

                // �����N�����擾
                DateTime yearMonth = DateTime.Now;

                this.tde_Date_St.SetDateTime(yearMonth);
                this.tde_Date_Ed.SetDateTime(yearMonth);

                // �݌v���
                this.uos_MonthReportDiv.Value = 1;
                this.uos_MonthReportDiv.FocusedIndex = 1;   // ADD 2008/03/31 �s��Ή�[12911]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������

                // ����
                this.uos_NewPageDiv.Value = 0;

                // ���s�^�C�v
                this.tComboEditor_PrintType.SelectedIndex = 0;

                // ���Ӑ�
                this.tNedit_CustomerCode_St.SetInt(0);
                this.tNedit_CustomerCode_Ed.SetInt(0);
                // �S����
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                // �n��
                this.tNedit_SalesAreaCode_St.SetInt(0);
                this.tNedit_SalesAreaCode_Ed.SetInt(0);

                // �����t�H�[�J�X�ݒ�
                this.tde_Date_St.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

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

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "����͂��ĉ�����";
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            // �Ώۓ��t
            if (!CallCheckDateRange(out cdrResult, ref this.tde_Date_St, ref this.tde_Date_Ed))
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n�Ώۓ��t{0}", ct_NoInput);
                            errComponent = this.tde_Date_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n�Ώۓ��t{0}", ct_InputError);
                            errComponent = this.tde_Date_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I���Ώۓ��t{0}", ct_NoInput);
                            errComponent = this.tde_Date_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I���Ώۓ��t{0}", ct_InputError);
                            errComponent = this.tde_Date_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("�Ώۓ��t{0}", ct_RangeError);
                            errComponent = this.tde_Date_St;
                        }
                        break;
                }

                status = false;
            }
            // ���Ӑ�
            else if ((this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            // �S����
            else if ((this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() ) > 0 ))
            {
                errMessage = string.Format( "�S����{0}", ct_RangeError );
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
            }
            // �n��
            else if ((this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()) && (this.tNedit_SalesAreaCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("�n��{0}", ct_RangeError);
                errComponent = this.tNedit_SalesAreaCode_St;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="stDate"></param>
        /// <param name="edDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit stDate, ref TDateEdit edDate)
        {
            // --- ADD 2008/11/21 -------------------------------->>>>>
            // �J�n���t�̕ϊ��O�ɓ��̓`�F�b�N
            DateGetAcs.CheckDateResult cdr = _dateGet.CheckDate(ref stDate);

            if (cdr == DateGetAcs.CheckDateResult.ErrorOfNoInput)
            {
                // ���͂Ȃ�
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput;
                return false;
            }
            else if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                // ���͕s��
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid;
                return false;
            }
            // --- ADD 2008/11/21 --------------------------------<<<<<

            // ���ԃ`�F�b�N�͗݌v�̊J�n���ƏI�����ōs��
            TDateEdit monthStartDate = new TDateEdit();
            monthStartDate.SetDateTime(this.GetMonthStartDate(stDate.GetDateTime()));

            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref monthStartDate, ref tde_Date_Ed, false);
            if (cdrResult != DateGetAcs.CheckDateRangeResult.OK)
            {
                return false;
            }

            // �J�n���ƏI����(��ʓ���)�͈̔̓`�F�b�N (�݌v�J�n�����Ƌt�]����\��������)
            if (stDate.GetDateTime().CompareTo(edDate.GetDateTime()) > 0)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfReverse;
                return false;
            }

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �S���_�`�F�b�N
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
                this._salesHistAnalyzeCndtn.IsOptSection = this._isOptSection;
                // ���_�R�[�h
                this._salesHistAnalyzeCndtn.SectionCode = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // ��ƃR�[�h
                this._salesHistAnalyzeCndtn.EnterpriseCode = this._enterpriseCode;

                // �Ώ۔N��
                // �J�n�Ώۓ��t
                this._salesHistAnalyzeCndtn.St_SalesDate = this.tde_Date_St.GetLongDate();
                // �I���Ώۓ��t
                this._salesHistAnalyzeCndtn.Ed_SalesDate = this.tde_Date_Ed.GetLongDate();

                // ���В��ߓ����l�������J�n�����擾�iDateTime �� int�j
                TDateEdit tmpTDE = new TDateEdit();
                tmpTDE.SetDateTime(this.GetMonthStartDate(this.tde_Date_St.GetDateTime()));

                // �v����N��(�J�n)
                this._salesHistAnalyzeCndtn.St_MonthReportDate = tmpTDE.GetLongDate();
                // �v����N��(�I��)
                this._salesHistAnalyzeCndtn.Ed_MonthReportDate = this.tde_Date_Ed.GetLongDate();
                
                // �݌v���
                this._salesHistAnalyzeCndtn.MonthReportDiv = (SalesHistAnalyzeCndtn.MonthReportDivState)this.uos_MonthReportDiv.CheckedItem.DataValue;

                // ����
                this._salesHistAnalyzeCndtn.NewPageDiv = (SalesHistAnalyzeCndtn.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;
                
                // ���s�^�C�v
                this._salesHistAnalyzeCndtn.PrintDiv = (SalesHistAnalyzeCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue;

                // �J�n���Ӑ�R�[�h
                this._salesHistAnalyzeCndtn.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // �I�����Ӑ�R�[�h
                this._salesHistAnalyzeCndtn.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

                // �J�n�S���҃R�[�h
                this._salesHistAnalyzeCndtn.St_SalesEmployeeCd = this.tEdit_EmployeeCode_St.DataText;
                // �I���S���҃R�[�h
                this._salesHistAnalyzeCndtn.Ed_SalesEmployeeCd = this.tEdit_EmployeeCode_Ed.DataText;

                // �J�n�n��R�[�h
                this._salesHistAnalyzeCndtn.St_SalesAreaCode = this.tNedit_SalesAreaCode_St.GetInt();
                // �I���n��R�[�h
                this._salesHistAnalyzeCndtn.Ed_SalesAreaCode = this.tNedit_SalesAreaCode_Ed.GetInt();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���В��ߓ��ɑΉ������݌v�J�n�����擾����B
        /// </summary>
        /// <returns></returns>
        private DateTime GetMonthStartDate(DateTime startDate)
        {
            int targetYear;
            DateTime yearMonth;
            DateTime startMonthDate;
            DateTime endMonthDate;
            this._dateGet.GetYearMonth(startDate, out yearMonth, out targetYear, out startMonthDate, out endMonthDate);

            return startMonthDate;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
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

        #region �� �R���g���[���C�x���g
        /// <summary>
        /// PMHNB02160UA_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �t�H�[���Ǎ��C�x���g�B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private void PMHNB02160UA_Load(object sender, EventArgs e)
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

            // ADD 2009/03/31 �s��Ή�[12911]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
            MonthReportDivRadioKeyPressHelper.ControlList.Add(this.uos_MonthReportDiv);
            MonthReportDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 �s��Ή�[12911]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }

        /// <summary>
        /// ���Ӑ�K�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCodeGuid_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (sender == this.uButton_CustomerCodeStGuid)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_St.Focus();
                }
            }

        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCodeStGuid)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

            _customerGuideOK = true;
        }

        /// <summary>
        /// �S���҃K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeCdGuid_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            Employee employee = new Employee();
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.uButton_EmployeeCdStGuid)
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tNedit_SalesAreaCode_St.Focus();
                }
            }
        }

        /// <summary>
        /// �n��K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AreaCodeGuid_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status == 0)
            {
                if (sender == this.uButton_AreaCodeStGuid)
                {
                    this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
                    this.tNedit_SalesAreaCode_Ed.Focus();
                }
                else
                {
                    this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
                    this.tde_Date_St.Focus();
                }
            }
        }

        /// <summary>
        /// ���^�[���L�[�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }
        #endregion
    }
}