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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�ʉߔN�x���v�\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʉߔN�x���v�\UI�t�H�[���N���X</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHNB04130UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB04130UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();

            // ���o�����N���X
            this._custFinancialListCndtn = new CustFinancialListCndtn();
        }
        #endregion

        #region �� private�萔
        #region Interface�֘A
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
        private const string ct_ClassID         = "PMHNB04130UA";
		// �v���O����ID
        private const string ct_PGID            = "PMHNB04130U";
		//// ���[����
		private string _printName				= "�ߔN�x���v�\";    
        // ���[�L�[	
        private string _printKey                = "9b7209b2-71b8-483a-bb1e-9833b38d1b1f";
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

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;
        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ���Ӑ�ʉߔN�x���v�\ ���o�����f�[�^�N���X
        private CustFinancialListCndtn _custFinancialListCndtn;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // ���������t���O (�C�x���g����p)
        private bool _initializeFinish = true;

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
        /// <br>Date		: 2008.10.31</br>
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
            printInfo.jyoken = this._custFinancialListCndtn;
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            _initializeFinish = false;

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �K�C�h�{�^���ݒ�
                this.SetIconImage(this.uButton_CustomerCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCodeEdGuid, Size16_Index.STAR1);

                // �Ώۊ��Ԏ擾
                DateTime stDate;
                DateTime edDate;

                // ��v�N�x�擾
                _dateGet.GetThisYearMonth(out edDate);
                // �����l��7�N�O(���N�܂߂�8�N��)
                stDate = edDate.AddYears(-7);

                tde_St_AddUpYearMonth.SetDateTime(stDate);
                tde_Ed_AddUpYearMonth.SetDateTime(edDate);

                // ���z�P�� �~
                this.uos_MoneyUnitDiv.Value = (int)CustFinancialListCndtn.MoneyUnitState.One;

                // ���s�^�C�v
                this.tComboEditor_PrintType.SelectedIndex = 0;
                // ����^�C�v
                this.tComboEditor_PrintMoneyType.SelectedIndex = 0;

                // ����
                Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

                this.uos_NewPageDiv.ResetValueList();

                for (int i = 0; i < valueList1.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList1.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                    this.uos_NewPageDiv.Items.Add(vlltem);
                }

                // �����l��"���Ȃ�"
                this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.None;

                // ���Ӑ�
                this.tNedit_CustomerCode_St.SetInt(0);
                this.tNedit_CustomerCode_Ed.SetInt(0);

                this.tde_St_AddUpYearMonth.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                _initializeFinish = true;
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
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "����͂��ĉ�����";
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            const string ct_RangeError1 = "�͈͎̔w��Ɍ�肪����܂�(�W�N�ȓ��Őݒ肵�ĉ�����)";

            // �Ώۊ���
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n�Ώۊ���{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n�Ώۊ���{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I���Ώۊ���{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I���Ώۊ���{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώۊ���{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("�Ώۊ���{0}", ct_RangeError1);
                            errComponent = this.tde_St_AddUpYearMonth;
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

            return status;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpYearMonth"></param>
        /// <param name="tde_Ed_AddUpYearMonth"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpYearMonth, ref TDateEdit tde_Ed_AddUpYearMonth)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.Year, 8, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.10.31</br>
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
                this._custFinancialListCndtn.IsOptSection = this._isOptSection;
                // ���_�R�[�h
                this._custFinancialListCndtn.AddUpSecCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // ��ƃR�[�h
                this._custFinancialListCndtn.EnterpriseCode = this._enterpriseCode;

                // �Ώ۔N��
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                // DateTime�ɕϊ�
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 10000) * 10000 + 1; // ��
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 10000) * 10000 + 1;
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 100) * 100 + 1; // ��
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                this.tde_St_AddUpYearMonth.SetLongDate(iSMonth);
                this.tde_Ed_AddUpYearMonth.SetLongDate(iEMonth);

                // �J�n�N�x
                this._custFinancialListCndtn.St_Year = this.tde_St_AddUpYearMonth.GetDateTime();
                // �I���N�x
                this._custFinancialListCndtn.Ed_Year = this.tde_Ed_AddUpYearMonth.GetDateTime();

                // �v��N���擾
                DateTime yearMonth;
                Int32 intMonthDay;
                this._dateGet.GetThisYearMonth(out yearMonth);

                // Datetime�ALongeDate�ϊ��pTDateEdit
                TDateEdit tmpTDateEdit = new TDateEdit();
                tmpTDateEdit.SetDateTime(yearMonth);
                intMonthDay = tmpTDateEdit.GetLongDate() % 10000; // ���񌎓����擾

                // �I���Ώۊ��Ԃ̔N�x + ���񌎂��擾
                int edAddUpYearMonth = ((this.tde_Ed_AddUpYearMonth.GetLongDate() / 10000) * 10000) + intMonthDay;
                tmpTDateEdit.SetLongDate(edAddUpYearMonth);

                // �J�n�v��N��
                this._custFinancialListCndtn.St_AddUpYearMonth = tmpTDateEdit.GetDateTime();
                // �I���v��N��
                this._custFinancialListCndtn.Ed_AddUpYearMonth = tmpTDateEdit.GetDateTime().AddMonths(12);

                // ���z�P��
                this._custFinancialListCndtn.MoneyUnit = (CustFinancialListCndtn.MoneyUnitState) this.uos_MoneyUnitDiv.CheckedItem.DataValue;
                // ����
                this._custFinancialListCndtn.NewPageDiv = (CustFinancialListCndtn.NewPageDivState) this.uos_NewPageDiv.CheckedItem.DataValue;
                // ���s�^�C�v
                this._custFinancialListCndtn.PrintDiv = (CustFinancialListCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue;
                // ����^�C�v
                this._custFinancialListCndtn.PrintMoneyDiv = (CustFinancialListCndtn.PrintMoneyDivState)this.tComboEditor_PrintMoneyType.SelectedItem.DataValue;

                // �J�n���Ӑ�R�[�h
                this._custFinancialListCndtn.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // �I�����Ӑ�R�[�h
                this._custFinancialListCndtn.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        #region �� ����ValueList�擾
        /// <summary>
        /// ����ValueList�擾
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetNewPageDivValueList()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            if ((CustFinancialListCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue
                == CustFinancialListCndtn.PrintDivState.CustomerSection)
            {
                valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 0;
                        valueListItem.DataValue = 2;
                        valueListItem.DisplayText = "���Ӑ�";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 1;
                        valueListItem.DataValue = 0;
                        valueListItem.DisplayText = "���Ȃ�";
                        valueList.ValueListItems.Add(valueListItem);
            }
            else
            {
                 valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 0;
                        valueListItem.DataValue = 1;
                        valueListItem.DisplayText = "���_";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 1;
                        valueListItem.DataValue = 0;
                        valueListItem.DisplayText = "���Ȃ�";
                        valueList.ValueListItems.Add(valueListItem);
            }
            
            return valueList;
        }
        #endregion

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.10.31</br>
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
        /// PMHNB04130UA_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �t�H�[���Ǎ��C�x���g�B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void PMHNB04130UA_Load(object sender, EventArgs e)
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

        /// <summary>
        /// ���^�[���L�[�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPrintDivGroup") ||
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
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPrintDivGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }

        /// <summary>
        /// ���s�^�C�v�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PrintType_SelectionChanged(object sender, EventArgs e)
        {
            if (_initializeFinish)
            {
                // �I�����ڕۑ�
                CustFinancialListCndtn.NewPageDivState dataValue
                    = (CustFinancialListCndtn.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;

                // ����
                Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

                this.uos_NewPageDiv.ResetValueList();

                for (int i = 0; i < valueList1.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList1.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                    this.uos_NewPageDiv.Items.Add(vlltem);
                }

                if (dataValue == CustFinancialListCndtn.NewPageDivState.None)
                {
                    // ���Ȃ�
                    this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.None;
                }
                else
                {
                    if ((CustFinancialListCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue
                        == CustFinancialListCndtn.PrintDivState.CustomerSection)
                    {
                        // ���Ӑ�
                        this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.Customer;
                    }
                    else
                    {
                        // ���_
                        this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.Section;
                    }
                }
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
                    this.tde_St_AddUpYearMonth.Focus();
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
        #endregion
    }
}