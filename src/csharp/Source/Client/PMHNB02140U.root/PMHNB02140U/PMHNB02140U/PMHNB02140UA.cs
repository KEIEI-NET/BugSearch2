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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 �s��Ή�[12923]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\UI�t�H�[���N���X</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br>Update Note: 2009/02/27 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12036</br>
    /// <br>           : 2009/03/05       �Ɠc �M�u�@�s��Ή�[12190]</br>
    /// <br>Update Note: 2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>Update Note: 2015/03/27 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           : Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX</br>
    /// </remarks>
    public partial class PMHNB02140UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB02140UA()
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
            this._shipGdsPrimeListCndtn = new ShipGdsPrimeListCndtn();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
        }
        #endregion

        #region �� private�萔
        #region Interface�֘A
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMHNB02140UA";
        // �v���O����ID
        private const string ct_PGID = "PMHNB02140U";
        //// ���[����
        private string _printName = "�o�׏��i�D�ǑΉ��\";
        // ���[�L�[	
        private string _printKey = "ae4c2d91-e5f3-42a0-8f9d-3f5df00aa374";
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

        // todo �K�C�h�쐬�҂�
        // �������[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // ���[�U�}�X�^�K�C�h�i���i�啪�ޗp�j
        private UserGuideAcs _userGuideAcs;
        // ���i�����ރK�C�h
        private GoodsGroupUAcs _goodsGroupUAcs;
        // �O���[�v�R�[�h�K�C�h
        private BLGroupUAcs _blGroupUAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

        // �o�׏��i�D�ǑΉ��\ ���o�����f�[�^�N���X
        private ShipGdsPrimeListCndtn _shipGdsPrimeListCndtn;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // ADD 2009/03/31 �s��Ή�[12923]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
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
        // ADD 2009/03/31 �s��Ή�[12923]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<

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
        /// <br>Date		: 2008.11.14</br>
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
            printInfo.jyoken = this._shipGdsPrimeListCndtn;
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
        /// <br>Update Note : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�    : 11070263-00</br>
        /// <br>            :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �K�C�h�{�^���ݒ�
                this.SetIconImage(this.ub_St_PureGoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_PureGoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                // �Ώۊ��Ԏ擾
                /* ---DEL 2009/03/05 �s��Ή�[12190] -------------------------------->>>>>
                DateTime yearMonth;

                // ��v�N�x�擾
                _dateGet.GetThisYearMonth(out yearMonth);

                tde_St_AddUpYearMonth.SetDateTime(yearMonth);
                tde_Ed_AddUpYearMonth.SetDateTime(yearMonth);
                   ---DEL 2009/03/05 �s��Ή�[12190] --------------------------------<<<<< */
                // ---ADD 2009/03/05 �s��Ή�[12190] -------------------------------->>>>>
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
                // ---ADD 2009/03/05 �s��Ή�[12190] --------------------------------<<<<<

                // �����敪
                this.tComboEditor_ComvDiv.SelectedIndex = 0;

                // ���ʕt�ݒ�
                // �敪
                this.tComboEditor_RankSection.SelectedIndex = 0;
                // ��ʁE����
                this.tComboEditor_RankHighLow.SelectedIndex = 0;
                // �ő�l
                this.tNedit_RankOrderMax.SetInt(99999999);

                // ����
                this.uos_NewPageDiv.Value = 0;

                //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------>>>>>
                // �i�ԏW�v�敪
                this.tComboEditor_GoodsNoTtlDiv.SelectedIndex = 0;

                // �i�ԕ\���敪
                this.tComboEditor_GoodsNoShowDiv.SelectedIndex = 0;
                //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------<<<<<

                // ����^�C�v
                this.tComboEditor_PrintType.SelectedIndex = 0;

                // ���o����
                this.tNedit_PureGoodsMakerCd_St.SetInt(0);
                this.tNedit_PureGoodsMakerCd_Ed.SetInt(0);
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
        /// <br>Date		: 2008.11.14</br>
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
            // ���ʕt�ݒ�@�ő�l
            else if(string.IsNullOrEmpty(this.tNedit_RankOrderMax.Text) ||
                this.tNedit_RankOrderMax.GetInt() == 0)
            {
                errMessage = string.Format("���ʕt���ݒ�{0}", ct_NoInput);
                errComponent = this.tNedit_RankOrderMax;
                status = false;
            }
            // �������[�J�[
            else if ((this.tNedit_PureGoodsMakerCd_St.GetInt() > this.tNedit_PureGoodsMakerCd_Ed.GetInt()) && (this.tNedit_PureGoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("�������[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_PureGoodsMakerCd_St;
                status = false;
            }
            // --- ADD 2009/01/19 -------------------------------->>>>>
            // �������[�J�[�K�C�h�����������܂ł̉��Ή�
            // �������[�J�[�K�C�h������������3���ȏ�̓��͂͂Ȃ��Ȃ�
            else if(this.tNedit_PureGoodsMakerCd_St.GetInt() > 99)
            {
                errMessage = string.Format("�������[�J�[�R�[�h��99�ȉ��œ��͂��Ă�������");
                errComponent = this.tNedit_PureGoodsMakerCd_St;
                status = false;
            }
            else if (this.tNedit_PureGoodsMakerCd_Ed.GetInt() > 99)
            {
                errMessage = string.Format("�������[�J�[�R�[�h��99�ȉ��œ��͂��Ă�������");
                errComponent = this.tNedit_PureGoodsMakerCd_Ed;
                status = false;
            }
            // --- ADD 2009/01/19 --------------------------------<<<<<
            // ���i�啪��
            else if ((this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()) && (this.tNedit_GoodsLGroup_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���i�啪��{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // ���i������
            else if ((this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()) && (this.tNedit_GoodsMGroup_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���i������{0}", ct_RangeError);
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
        /// <br>Date		: 2008.11.14</br>
        /// <br>Update Note : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�    : 11070263-00</br>
        /// <br>            :�E�����Y�ƗlSeiken�i�ԕύX</br>
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
                this._shipGdsPrimeListCndtn.IsOptSection = this._isOptSection;
                // ���_�R�[�h
                this._shipGdsPrimeListCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // ��ƃR�[�h
                this._shipGdsPrimeListCndtn.EnterpriseCode = this._enterpriseCode;

                // �Ώ۔N��
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                // DateTime�ɕϊ�
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 100) * 100 + 1; // ��
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                this.tde_St_AddUpYearMonth.SetLongDate(iSMonth);
                this.tde_Ed_AddUpYearMonth.SetLongDate(iEMonth);

                // �J�n�N�x
                this._shipGdsPrimeListCndtn.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // �I���N�x
                this._shipGdsPrimeListCndtn.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();

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
                //this._shipGdsPrimeListCndtn.St_AnnualAddUpYearMonth = tmpTDateEdit.GetDateTime();

                //tmpTDateEdit.SetLongDate(annualEdYMonth);
                //this._shipGdsPrimeListCndtn.Ed_AnnualAddUpYearMonth = tmpTDateEdit.GetDateTime();
                // --- DEL 2009/02/27 --------------------------------<<<<<
                // --- ADD 2009/02/27 -------------------------------->>>>>
                this._shipGdsPrimeListCndtn.St_AnnualAddUpYearMonth = stYMonth;
                this._shipGdsPrimeListCndtn.Ed_AnnualAddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // --- ADD 2009/02/27 --------------------------------<<<<<
                
                // �����敪
                this._shipGdsPrimeListCndtn.ComvDiv = (ShipGdsPrimeListCndtn.ComvDivState) this.tComboEditor_ComvDiv.SelectedItem.DataValue;
                
                // ���ʕt�ݒ�
                // �P��
                this._shipGdsPrimeListCndtn.RankSection = (ShipGdsPrimeListCndtn.RankSectionState)this.tComboEditor_RankSection.SelectedItem.DataValue;
                // ��ʁE����
                this._shipGdsPrimeListCndtn.RankHighLow = (ShipGdsPrimeListCndtn.RankHighLowState)this.tComboEditor_RankHighLow.SelectedItem.DataValue;
                // �ő�l
                this._shipGdsPrimeListCndtn.RankOrderMax = this.tNedit_RankOrderMax.GetInt();

                // ����
                this._shipGdsPrimeListCndtn.NewPageDiv = (ShipGdsPrimeListCndtn.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;

                //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------>>>>>
                // �i�ԏW�v�敪
                this._shipGdsPrimeListCndtn.GoodsNoTtlDiv = (ShipGdsPrimeListCndtn.GoodsNoTtlDivState)this.tComboEditor_GoodsNoTtlDiv.SelectedItem.DataValue;

                // �i�ԕ\���敪
                this._shipGdsPrimeListCndtn.GoodsNoShowDiv = (ShipGdsPrimeListCndtn.GoodsNoShowDivState)this.tComboEditor_GoodsNoShowDiv.SelectedItem.DataValue;
                //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------<<<<<

                // ����^�C�v
                this._shipGdsPrimeListCndtn.PrintType = (ShipGdsPrimeListCndtn.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue;

                // �J�n�������[�J�[�R�[�h
                this._shipGdsPrimeListCndtn.St_GoodsMakerCd = this.tNedit_PureGoodsMakerCd_St.GetInt();
                // �I���������[�J�[�R�[�h
                this._shipGdsPrimeListCndtn.Ed_GoodsMakerCd = this.tNedit_PureGoodsMakerCd_Ed.GetInt();
                // �J�n���i�啪�ރR�[�h
                this._shipGdsPrimeListCndtn.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                // �I�����i�啪�ރR�[�h
                this._shipGdsPrimeListCndtn.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();
                // �J�n���i�����ރR�[�h
                this._shipGdsPrimeListCndtn.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                // �I�����i�����ރR�[�h
                this._shipGdsPrimeListCndtn.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // �J�n�O���[�v�R�[�h
                this._shipGdsPrimeListCndtn.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                // �I���O���[�v�R�[�h
                this._shipGdsPrimeListCndtn.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // �J�n�a�k�R�[�h
                this._shipGdsPrimeListCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // �I���a�k�R�[�h
                this._shipGdsPrimeListCndtn.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
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
        /// <br>Date		: 2008.11.14</br>
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

        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�    : 11070263-00</br>
        /// <br>            :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            //saveCtrAry.Add(this.tde_St_AddUpYearMonth);           //DEL 2009/03/05 �s��Ή�[12190]
            //saveCtrAry.Add(this.tde_Ed_AddUpYearMonth);           //DEL 2009/03/05 �s��Ή�[12190]
            saveCtrAry.Add(this.tComboEditor_ComvDiv);
            saveCtrAry.Add(this.tComboEditor_RankSection);
            saveCtrAry.Add(this.tComboEditor_RankHighLow);
            saveCtrAry.Add(this.tNedit_RankOrderMax);
            saveCtrAry.Add(this.uos_NewPageDiv);
            //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------>>>>>
            saveCtrAry.Add(this.tComboEditor_GoodsNoTtlDiv);
            saveCtrAry.Add(this.tComboEditor_GoodsNoShowDiv);
            //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------<<<<<
            saveCtrAry.Add(this.tComboEditor_PrintType);
            saveCtrAry.Add(this.tNedit_PureGoodsMakerCd_St);
            saveCtrAry.Add(this.tNedit_PureGoodsMakerCd_Ed);
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
        #endregion

        #region �� �R���g���[���C�x���g

        /// <summary>
        /// PMHNB02140UA_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02140UA_Load(object sender, EventArgs e)
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

            // ADD 2009/03/31 �s��Ή�[12923]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 �s��Ή�[12923]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.11.14</br>
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
        /// <br>Date		: 2008.11.14</br>
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

        //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------>>>>>
        /// <summary>
        /// �i�ԏW�v�敪SelectionChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GoodsNoTtlDiv_SelectionChanged(object sender, EventArgs e)
        {
            // �i�ԏW�v�敪���u���Z�v��
            if (this.tComboEditor_GoodsNoTtlDiv.SelectedIndex == 1)
            {
                this.tComboEditor_GoodsNoShowDiv.Enabled = true;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
            else
            {
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
        }
        //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX------<<<<<

        /// <summary>
        /// ���^�[���L�[�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note  : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // �^�u�AEnter�L�[�ł̃K�C�h�J�ڕs��
            if (e.PrevCtrl == this.tde_St_AddUpYearMonth)
            {
                if (e.NextCtrl == ub_Ed_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                }
            }
            //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
            else if (e.PrevCtrl == this.tComboEditor_GoodsNoTtlDiv)
            {
                if (e.Key == Keys.Right)
                {
                    e.NextCtrl = this.uos_NewPageDiv;
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_GoodsNoShowDiv)
            {
                if (e.Key == Keys.Right)
                {
                    e.NextCtrl = this.uos_NewPageDiv;
                }
            }
            //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<
            else if (e.PrevCtrl == this.tNedit_PureGoodsMakerCd_St)
            {
                if (e.NextCtrl == this.ub_St_PureGoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_PureGoodsMakerCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_PureGoodsMakerCd_Ed)
            {
                if (e.NextCtrl == this.ub_St_PureGoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_PureGoodsMakerCd_St;
                }
                else if (e.NextCtrl == this.ub_Ed_PureGoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
            {
                if (e.NextCtrl == this.ub_Ed_PureGoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_PureGoodsMakerCd_Ed;
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
        /// �������[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_PureGoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_PureGoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_PureGoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_PureGoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
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

        #endregion
    }
}