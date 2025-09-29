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
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\�QUI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\�QUI�t�H�[���N���X</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>Update Note: 2009/02/27 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12036</br>
    /// <br>           : 2009/03/05       �Ɠc �M�u�@�s��Ή�[12191]</br>
    /// <br>Update Note: 2014/12/30 ������</br>
    /// <br>            �E�����Y�Ɓ@Seiken�i�ԕύX�o�f�J�� ���[���Ǖ��Ή�</br>
    /// <br>Update Note: 2015/03/27 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           : Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX</br>
    /// </remarks>
    public partial class PMHNB02150UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB02150UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // ���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            // �K�C�h
            // �������[�J�[�K�C�h
            this._makerAcs = new MakerAcs();
            // ���[�U�}�X�^�K�C�h�i���i�啪�ޗp�j
            this._userGuideAcs = new UserGuideAcs();
            // ���i�����ރK�C�h
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            // �O���[�v�R�[�h�K�C�h
            this._blGroupUAcs = new BLGroupUAcs();
            // BL�R�[�h�K�C�h
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            // ���o�����N���X
            this._shipGdsPrimeListCndtn2 = new ShipGdsPrimeListCndtn2();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
        }
        #endregion

        #region �� private�萔
        #region Interface�֘A
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMHNB02150UA";
        // �v���O����ID
        private const string ct_PGID = "PMHNB02150U";
        //// ���[����
        private string _printName = "�o�׏��i�D�ǑΉ��\�U";
        // ���[�L�[	
        private string _printKey = "f3295b12-611c-4c4d-a017-5e8802014183";
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

        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // ���[�U�}�X�^�K�C�h�i���i�啪�ޗp�j
        private UserGuideAcs _userGuideAcs;
        // ���i�����ރK�C�h
        private GoodsGroupUAcs _goodsGroupUAcs;
        // �O���[�v�R�[�h�K�C�h
        private BLGroupUAcs _blGroupUAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

        // �o�׏��i�D�ǑΉ��\2 ���o�����f�[�^�N���X
        private ShipGdsPrimeListCndtn2 _shipGdsPrimeListCndtn2;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        /// <summary>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _uos_NewPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// ���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper Uos_NewPageDivRadioKeyPressHelper
        {
            get { return _uos_NewPageDivRadioKeyPressHelper; }
        }

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
        /// <br>Date		: 2008.11.25</br>
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
            printInfo.jyoken = this._shipGdsPrimeListCndtn2;
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2014/12/30 ������</br>
        /// <br>             �����Y�Ɓ@Seiken�i�ԕύX�o�f�J�� ���[���Ǖ��Ή�</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �K�C�h�{�^���ݒ�
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                // �Ώۊ��Ԏ擾
                /* ---DEL 2009/03/05 �s��Ή�[12191] -------------------------------->>>>>
                DateTime yearMonth;
                _dateGet.GetThisYearMonth(out yearMonth);

                tde_St_AddUpYearMonth.SetDateTime(yearMonth);
                tde_Ed_AddUpYearMonth.SetDateTime(yearMonth);
                   ---DEL 2009/03/05 �s��Ή�[12191] --------------------------------<<<<< */
                // ---ADD 2009/03/05 �s��Ή�[12191] -------------------------------->>>>>
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    // ���㍡�񌎎��X�V����ݒ�
                    this.tde_St_AddUpYearMonth.SetDateTime(currentTotalMonth);
                    this.tde_Ed_AddUpYearMonth.SetDateTime(currentTotalMonth);
                }
                else
                {
                    // ������ݒ�
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.tde_St_AddUpYearMonth.SetDateTime(nowYearMonth);
                    this.tde_Ed_AddUpYearMonth.SetDateTime(nowYearMonth);
                }
                // ---ADD 2009/03/05 �s��Ή�[12191] --------------------------------<<<<<

                // �o�͋敪
                this.tComboEditor_OutputDiv.SelectedIndex = 0;

                // �o�׉�
                this.tNedit_ShipCount.SetInt(1);

                // ����
                this.uos_NewPageDiv.Value = 0;

                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                //�i�ԏW�v�敪
                this.tComboEditor_GoodsNoTtlDiv.SelectedIndex = 0;

                //�i�ԕ\���敪
                this.tComboEditor_GoodsNoShowDiv.SelectedIndex = 0;
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                // ����^�C�v
                this.tComboEditor_PrintType.SelectedIndex = 0;

                // ���o�敪
                this.tComboEditor_ExtractDiv.SelectedIndex = 0;

                // ���o����
                this.tNedit_GoodsMakerCd_St.SetInt(0);
                this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                this.tNedit_GoodsLGroup_St.SetInt(0);
                this.tNedit_GoodsLGroup_Ed.SetInt(0);
                this.tNedit_GoodsMGroup_St.SetInt(0);
                this.tNedit_GoodsMGroup_Ed.SetInt(0);
                this.tNedit_BLGloupCode_St.SetInt(0);
                this.tNedit_BLGloupCode_Ed.SetInt(0);
                this.tNedit_BLGoodsCode_St.SetInt(0);
                this.tNedit_BLGoodsCode_Ed.SetInt(0);

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();

                // �����t�H�[�J�X
                this.tde_St_AddUpYearMonth.Focus();
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
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "����͂��ĉ�����";
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            const string ct_RangeOverError = "�͓���N�x���œ��͂��ĉ�����";

            // �Ώ۔N��
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n�Ώ۔N��{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n�Ώ۔N��{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I���Ώ۔N��{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I���Ώ۔N��{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώ۔N��{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                        {
                            errMessage = string.Format("�Ώ۔N��{0}", ct_RangeOverError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                status = false;
            }
            // �o�׉�
            else if (string.IsNullOrEmpty(this.tNedit_ShipCount.Text))
            {
                errMessage = string.Format("�o�׉�{0}", ct_NoInput);
                errComponent = this.tNedit_ShipCount;
                status = false;
            }
            // �������[�J�[
            else if ((this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���[�J�[�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)ShipGdsPrimeListCndtn2.ExtractDivState.Pure
                && this.tNedit_GoodsMakerCd_St.GetInt() > 99
                && (this.tNedit_GoodsMakerCd_St.GetInt() != 0))
            {
                errMessage = string.Format("���o�敪�������̏ꍇ�A���[�J�[�R�[�h��99�ȉ��œ��͂��Ă�������");
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)(ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                && this.tNedit_GoodsMakerCd_Ed.GetInt() > 99
           && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���o�敪�������̏ꍇ�A���[�J�[�R�[�h��99�ȉ��œ��͂��Ă�������");
                errComponent = this.tNedit_GoodsMakerCd_Ed;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)(ShipGdsPrimeListCndtn2.ExtractDivState.Superior)
                && this.tNedit_GoodsMakerCd_St.GetInt() < 100
                && (this.tNedit_GoodsMakerCd_St.GetInt() != 0))
            {
                errMessage = string.Format("���o�敪���D�ǂ̏ꍇ�A���[�J�[�R�[�h��100�ȏ�œ��͂��Ă�������");
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)(ShipGdsPrimeListCndtn2.ExtractDivState.Superior)
                && this.tNedit_GoodsMakerCd_Ed.GetInt() < 100
                && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���o�敪���D�ǂ̏ꍇ�A���[�J�[�R�[�h��100�ȏ�œ��͂��Ă�������");
                errComponent = this.tNedit_GoodsMakerCd_Ed;
                status = false;
            }
            // ���i�啪��
            else if ((this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()) && (this.tNedit_GoodsLGroup_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���i�啪�ރR�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // ���i������
            else if ((this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()) && (this.tNedit_GoodsMGroup_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���i�����ރR�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // �O���[�v�R�[�h
            else if ((this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()) && (this.tNedit_BLGloupCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("�O���[�v�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // �a�k�R�[�h
            else if ((this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()) && (this.tNedit_BLGoodsCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
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
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2014/12/30 ������</br>
        /// <br>             �����Y�Ɓ@Seiken�i�ԕύX�o�f�J�� ���[���Ǖ��Ή�</br>
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
                this._shipGdsPrimeListCndtn2.IsOptSection = this._isOptSection;
                // ���_�R�[�h
                this._shipGdsPrimeListCndtn2.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // ��ƃR�[�h
                this._shipGdsPrimeListCndtn2.EnterpriseCode = this._enterpriseCode;

                // �Ώ۔N��
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                // DateTime�ɕϊ�
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 100) * 100 + 1; // ��
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                this.tde_St_AddUpYearMonth.SetLongDate(iSMonth);
                this.tde_Ed_AddUpYearMonth.SetLongDate(iEMonth);

                // �J�n�N�x
                this._shipGdsPrimeListCndtn2.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // �I���N�x
                this._shipGdsPrimeListCndtn2.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();

                // �����p
                // �J�n�����܂ޔN�̏����擾
                int year;
                int addYears;
                DateTime stYMonth;
                DateTime edYMonth;
                _dateGet.GetYearFromMonth(tde_Ed_AddUpYearMonth.GetDateTime(), out year, out addYears, out stYMonth, out edYMonth);
                // --- DEL 2009/02/27 -------------------------------->>>>>
                //int tmpStMonth = stYMonth.Month; // ����
                //int tmpEdMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Month; // �I�����͓��͂���擾

                //int annualStYMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Year * 10000 + tmpStMonth * 100 + 1;
                //int annualEdYMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Year * 10000 + tmpEdMonth * 100 + 1;

                //TDateEdit tmpTDateEdit = new TDateEdit();
                //tmpTDateEdit.SetLongDate(annualStYMonth);
                //// �J�n�N�x(����)
                //this._shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth = tmpTDateEdit.GetDateTime();

                //tmpTDateEdit.SetLongDate(annualEdYMonth);
                //this._shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth = tmpTDateEdit.GetDateTime();
                // --- DEL 2009/02/27 --------------------------------<<<<<
                // --- ADD 2009/02/27 -------------------------------->>>>>
                this._shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth = stYMonth;
                this._shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // --- ADD 2009/02/27 --------------------------------<<<<<

                // �o�͋敪
                this._shipGdsPrimeListCndtn2.OutputDiv = (ShipGdsPrimeListCndtn2.OutputDivState)this.tComboEditor_OutputDiv.SelectedItem.DataValue;

                // �o�׉�
                this._shipGdsPrimeListCndtn2.ShipCount = this.tNedit_ShipCount.GetInt();
                
                // ����
                this._shipGdsPrimeListCndtn2.NewPageDiv = (ShipGdsPrimeListCndtn2.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;

                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                //�i�ԏW�v�敪
                this._shipGdsPrimeListCndtn2.GoodsNoTtlDiv = (ShipGdsPrimeListCndtn2.GoodsNoTtlDivState)this.tComboEditor_GoodsNoTtlDiv.SelectedItem.DataValue;

                //�i�ԕ\���敪
                this._shipGdsPrimeListCndtn2.GoodsNoShowDiv = (ShipGdsPrimeListCndtn2.GoodsNoShowDivState)this.tComboEditor_GoodsNoShowDiv.SelectedItem.DataValue;
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                // ����^�C�v
                this._shipGdsPrimeListCndtn2.PrintType = (ShipGdsPrimeListCndtn2.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue;

                // ���o�敪
                this._shipGdsPrimeListCndtn2.ExtractDiv = (ShipGdsPrimeListCndtn2.ExtractDivState)this.tComboEditor_ExtractDiv.SelectedItem.DataValue;

                // �J�n���[�J�[�R�[�h
                this._shipGdsPrimeListCndtn2.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // �I�����[�J�[�R�[�h
                this._shipGdsPrimeListCndtn2.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // �J�n���i�啪�ރR�[�h
                this._shipGdsPrimeListCndtn2.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                // �I�����i�啪�ރR�[�h
                this._shipGdsPrimeListCndtn2.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();
                // �J�n���i�����ރR�[�h
                this._shipGdsPrimeListCndtn2.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                // �I�����i�����ރR�[�h
                this._shipGdsPrimeListCndtn2.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // �J�n�O���[�v�R�[�h
                this._shipGdsPrimeListCndtn2.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                // �I���O���[�v�R�[�h
                this._shipGdsPrimeListCndtn2.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // �J�n�a�k�R�[�h
                this._shipGdsPrimeListCndtn2.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // �I���a�k�R�[�h
                this._shipGdsPrimeListCndtn2.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            //saveCtrAry.Add(this.tde_St_AddUpYearMonth);           //DEL 2009/03/05 �s��Ή�[12191]
            //saveCtrAry.Add(this.tde_Ed_AddUpYearMonth);           //DEL 2009/03/05 �s��Ή�[12191]
            saveCtrAry.Add(this.tComboEditor_OutputDiv);
            saveCtrAry.Add(this.tNedit_ShipCount);
            saveCtrAry.Add(this.uos_NewPageDiv);
            saveCtrAry.Add(this.tComboEditor_PrintType);
            saveCtrAry.Add(this.tComboEditor_ExtractDiv);
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            // �i�ԏW�v�敪
            saveCtrAry.Add(this.tComboEditor_GoodsNoTtlDiv);
            // �i�ԕ\���敪
            saveCtrAry.Add(this.tComboEditor_GoodsNoShowDiv); 
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tNedit_BLGloupCode_St);
            saveCtrAry.Add(this.tNedit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_St);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_Ed);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
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
        /// <br>Date		: 2008.11.25</br>
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
        /// PMHNB02150UA_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02150UA_Load(object sender, EventArgs e)
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

            Uos_NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            Uos_NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            if ((e.PrevCtrl == this.tComboEditor_ExtractDiv) && (e.Key == Keys.Up))
            {
                if (tComboEditor_GoodsNoShowDiv.Enabled == true)
                {
                    e.NextCtrl = this.tComboEditor_GoodsNoShowDiv;
                }
                else
                {
                    e.NextCtrl = this.tComboEditor_GoodsNoTtlDiv;
                } 
            }
            else
            {
                //�Ȃ�
            }
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            // �^�u�AEnter�L�[�ł̃K�C�h�J�ڕs��
            if (e.PrevCtrl == this.tde_St_AddUpYearMonth)
            {
                if (e.NextCtrl == ub_Ed_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                if (e.NextCtrl == this.ub_St_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                if (e.NextCtrl == this.ub_St_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                }
                else if (e.NextCtrl == this.ub_Ed_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
            {
                if (e.NextCtrl == this.ub_Ed_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
                else if (e.NextCtrl == this.ub_St_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            {
                if (e.NextCtrl == this.ub_St_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_St;
                }
                else if (e.NextCtrl == this.ub_Ed_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
            {
                if (e.NextCtrl == this.ub_Ed_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                }
                else if (e.NextCtrl == this.ub_St_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            {
                if (e.NextCtrl == this.ub_St_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_St;
                }
                else if (e.NextCtrl == this.ub_Ed_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
            {
                if (e.NextCtrl == this.ub_Ed_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                }
                else if (e.NextCtrl == this.ub_St_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                if (e.NextCtrl == this.ub_St_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_St;
                }
                else if (e.NextCtrl == this.ub_Ed_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            {
                if (e.NextCtrl == this.ub_Ed_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                }
                else if (e.NextCtrl == this.ub_St_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                if (e.NextCtrl == this.ub_St_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                }
                else if (e.NextCtrl == this.ub_Ed_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tde_St_AddUpYearMonth;
                }
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsLGroup_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ���i�啪�ރK�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            UserGdBd userGdBd;
            UserGdHd userGdHd;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsMGroup_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ���i�����ރK�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodgroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_BLGloupCode_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// BL�O���[�v�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            // BL�O���[�v�K�C�h�N��
            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tde_St_AddUpYearMonth.Focus();
            }
            else
            {
                return;
            }
        }

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>
        /// �i�ԏW�v�敪SelectionChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GoodsNoTtlDiv_ValueChanged(object sender, EventArgs e)
        {
            if (tComboEditor_GoodsNoTtlDiv.Value.Equals(0))
            {
                tComboEditor_GoodsNoShowDiv.Value = 0;
                tComboEditor_GoodsNoShowDiv.Enabled = false;
            }
            else
            {
                tComboEditor_GoodsNoShowDiv.Value = 0;
                tComboEditor_GoodsNoShowDiv.Enabled = true;
            }
        }
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
        #endregion

    }
}