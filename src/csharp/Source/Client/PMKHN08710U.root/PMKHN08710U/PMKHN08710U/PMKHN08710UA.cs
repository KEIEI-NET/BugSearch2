//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^�i����j
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;

using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�}�X�^�i����jUI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�i����jUI�t�H�[���N���X</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN08710UA : Form,
                                        IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                        IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Private Member

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";

        //���_�K�C�h�p
        private SecInfoSetAcs _secInfoSetAcs;

        //�L�����y�[���K�C�h�p
        private CampaignLinkAcs _campaignLinkAcs;

        // �S���҃K�C�h�p
        private EmployeeAcs _employeeAcs;

        // ���[�U�[�K�C�h�p
        private UserGuideAcs _userGuideAcs;

        // �O���[�v�R�[�h�K�C�h
        private BLGroupUAcs _blGroupUAcs;

        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;
        
        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;
        private UltraButton _customerGuideSender;

        // ���o�����N���X
        private CampaignTargetPrintWork _campaignTargetPrintWork;

        private CampaignTargetSetAcs _campaignTargetSetAcs;

        // ����
        private DateTime _startMonth;

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
        #endregion �� Interface member

        #endregion

        #region �� Private Const
        private const string PRINTSET_TABLE = "CAMPAIGNTARGET";

        // dataview���̗p
        private const string CAMPAIGNCODE = "campaigncode";
        private const string CAMPAIGNNAME = "campaignname";
        private const string SECTIONCODE = "sectioncode";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string CUSTOMERCODE = "customercode";
        private const string CUSTOMERSNM = "customersnm";
        private const string SALESEMPLOYEECD = "salesemployeecd";
        private const string SALESEMPLOYEENM = "salesemployeenm";
        private const string FRONTEMPLOYEECD = "frontemployeecd";
        private const string FRONTEMPLOYEENM = "frontemployeenm";
        private const string SALESINPUTCODE = "salesinputcode";
        private const string SALESINPUTNAME = "salesinputname";
        private const string SALESAREACODE = "salesareacode";
        private const string SALESAREACODENAME = "salesareacodename";
        private const string BLGROUPCODE = "blgroupcode";
        private const string BLGROUPCODENAME = "blgroupcodename";
        private const string BLGOODSCODE = "blgoodscode";
        private const string BLGOODSCODENAME = "blgoodscodename";
        private const string SALESCODE = "salescode";
        private const string SALESCODENAME = "salescodename";

        private const string MONTHLYSALESTARGET = "monthlysalestarget";
        private const string TERMSALESTARGET = "termsalestarget";
        private const string SALESTARGETMONEY1 = "salestargetmoney1";
        private const string SALESTARGETMONEY2 = "salestargetmoney2";
        private const string SALESTARGETMONEY3 = "salestargetmoney3";
        private const string SALESTARGETMONEY4 = "salestargetmoney4";
        private const string SALESTARGETMONEY5 = "salestargetmoney5";
        private const string SALESTARGETMONEY6 = "salestargetmoney6";
        private const string SALESTARGETMONEY7 = "salestargetmoney7";
        private const string SALESTARGETMONEY8 = "salestargetmoney8";
        private const string SALESTARGETMONEY9 = "salestargetmoney9";
        private const string SALESTARGETMONEY10 = "salestargetmoney10";
        private const string SALESTARGETMONEY11 = "salestargetmoney11";
        private const string SALESTARGETMONEY12 = "salestargetmoney12";
        private const string SALESTARGETMONEYALL = "salestargetmoneyall";

        private const string MONTHLYSALESTARGETPROFIT = "monthlysalestargetprofit";
        private const string TERMSALESTARGETPROFIT = "termsalestargetprofit";
        private const string SALESTARGETPROFIT1 = "salestargetprofit1";
        private const string SALESTARGETPROFIT2 = "salestargetprofit2";
        private const string SALESTARGETPROFIT3 = "salestargetprofit3";
        private const string SALESTARGETPROFIT4 = "salestargetprofit4";
        private const string SALESTARGETPROFIT5 = "salestargetprofit5";
        private const string SALESTARGETPROFIT6 = "salestargetprofit6";
        private const string SALESTARGETPROFIT7 = "salestargetprofit7";
        private const string SALESTARGETPROFIT8 = "salestargetprofit8";
        private const string SALESTARGETPROFIT9 = "salestargetprofit9";
        private const string SALESTARGETPROFIT10 = "salestargetprofit10";
        private const string SALESTARGETPROFIT11 = "salestargetprofit11";
        private const string SALESTARGETPROFIT12 = "salestargetprofit12";
        private const string SALESTARGETPROFITALL = "salestargetprofitall";

        private const string APPLYDATEALL = "applydate";

        private const string MONTHLYSALESTARGETCOUNT = "monthlysalestargetcount";
        private const string TERMSALESTARGETCOUNT = "termsalestargetcount";
        private const string SALESTARGETCOUNT1 = "salestargetcount1";
        private const string SALESTARGETCOUNT2 = "salestargetcount2";
        private const string SALESTARGETCOUNT3 = "salestargetcount3";
        private const string SALESTARGETCOUNT4 = "salestargetcount4";
        private const string SALESTARGETCOUNT5 = "salestargetcount5";
        private const string SALESTARGETCOUNT6 = "salestargetcount6";
        private const string SALESTARGETCOUNT7 = "salestargetcount7";
        private const string SALESTARGETCOUNT8 = "salestargetcount8";
        private const string SALESTARGETCOUNT9 = "salestargetcount9";
        private const string SALESTARGETCOUNT10 = "salestargetcount10";
        private const string SALESTARGETCOUNT11 = "salestargetcount11";
        private const string SALESTARGETCOUNT12 = "salestargetcount12";
        private const string SALESTARGETCOUNTALL = "salestargetcountall";

        private const string CAMPAIGNCODE_TITLE = "����߰�";
        private const string CAMPAIGNNAME_TITLE = "����߰ݖ�";
        private const string SECTIONCODE_TITLE = "���_";
        private const string SECTIONGUIDESNM_TITLE = "���_��";
        private const string CUSTOMERCODE_TITLE = "���Ӑ�";
        private const string CUSTOMERSNM_TITLE = "���Ӑ於";
        private const string SALESEMPLOYEECD_TITLE = "�S����";
        private const string SALESEMPLOYEENM_TITLE = "�S���Җ�";
        private const string FRONTEMPLOYEECD_TITLE = "�󒍎�";
        private const string FRONTEMPLOYEENM_TITLE = "�󒍎Җ�";
        private const string SALESINPUTCODE_TITLE = "���s��";
        private const string SALESINPUTNAME_TITLE = "���s�Җ�";
        private const string SALESAREACODE_TITLE = "�n��";
        private const string SALESAREACODENAME_TITLE = "�n�於";
        private const string BLGROUPCODE_TITLE = "��ٰ�ߺ���";
        private const string BLGROUPCODENAME_TITLE = "��ٰ�ߺ��ޖ�";
        private const string BLGOODSCODE_TITLE = "BL����";
        private const string BLGOODSCODENAME_TITLE = "BL���ޖ�";
        private const string SALESCODE_TITLE = "�̔��敪";
        private const string SALESCODENAME_TITLE = "�̔��敪��";

        private const string MONTHLYSALESTARGET_TITLE = "����";
        private const string TERMSALESTARGET_TITLE = "����";
        private const string SALESTARGETMONEY1_TITLE = "����P";
        private const string SALESTARGETMONEY2_TITLE = "����Q";
        private const string SALESTARGETMONEY3_TITLE = "����R";
        private const string SALESTARGETMONEY4_TITLE = "����S";
        private const string SALESTARGETMONEY5_TITLE = "����T";
        private const string SALESTARGETMONEY6_TITLE = "����U";
        private const string SALESTARGETMONEY7_TITLE = "����V";
        private const string SALESTARGETMONEY8_TITLE = "����W";
        private const string SALESTARGETMONEY9_TITLE = "����X";
        private const string SALESTARGETMONEY10_TITLE = "����P�O";
        private const string SALESTARGETMONEY11_TITLE = "����P�P";
        private const string SALESTARGETMONEY12_TITLE = "����P�Q";
        private const string SALESTARGETMONEYALL_TITLE = "���㍇�v";

        private const string SALESTARGETPROFIT1_TITLE = "�e���P";
        private const string SALESTARGETPROFIT2_TITLE = "�e���Q";
        private const string SALESTARGETPROFIT3_TITLE = "�e���R";
        private const string SALESTARGETPROFIT4_TITLE = "�e���S";
        private const string SALESTARGETPROFIT5_TITLE = "�e���T";
        private const string SALESTARGETPROFIT6_TITLE = "�e���U";
        private const string SALESTARGETPROFIT7_TITLE = "�e���V";
        private const string SALESTARGETPROFIT8_TITLE = "�e���W";
        private const string SALESTARGETPROFIT9_TITLE = "�e���X";
        private const string SALESTARGETPROFIT10_TITLE = "�e���P�O";
        private const string SALESTARGETPROFIT11_TITLE = "�e���P�P";
        private const string SALESTARGETPROFIT12_TITLE = "�e���P�Q";
        private const string SALESTARGETPROFITALL_TITLE = "�e�����v";

        private const string SALESTARGETCOUNT1_TITLE = "����1";
        private const string SALESTARGETCOUNT2_TITLE = "����2";
        private const string SALESTARGETCOUNT3_TITLE = "����3";
        private const string SALESTARGETCOUNT4_TITLE = "����4";
        private const string SALESTARGETCOUNT5_TITLE = "����5";
        private const string SALESTARGETCOUNT6_TITLE = "����6";
        private const string SALESTARGETCOUNT7_TITLE = "����7";
        private const string SALESTARGETCOUNT8_TITLE = "����8";
        private const string SALESTARGETCOUNT9_TITLE = "����9";
        private const string SALESTARGETCOUNT10_TITLE = "����10";
        private const string SALESTARGETCOUNT11_TITLE = "����11";
        private const string SALESTARGETCOUNT12_TITLE = "����12";
        private const string SALESTARGETCOUNTALL_TITLE = "���ʍ��v";

        // �v���O����ID
        private const string ct_PGID = "PMKHN08710U";

        private const string ct_ClassID = "PMKHN08710UA";
        // ���[����
        private string _printName = "�L�����y�[���ڕW�ݒ�}�X�^�i����j";
        // ���[�L�[	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����

        #endregion
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�i����jUI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�i����jUI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08710UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._campaignTargetSetAcs = new CampaignTargetSetAcs();

            this._campaignLinkAcs = new CampaignLinkAcs();

            this._secInfoSetAcs = new SecInfoSetAcs();

            // ���Џ��}�X�^.���񌎂��擾����B
            DateGetAcs _dateGetAcs;
            _dateGetAcs = DateGetAcs.GetInstance();
            List<DateTime> startMonth;
            List<DateTime> endMonth;
            List<DateTime> yearMonth;
            int year;                                  // ��v�N�x
            try
            {
                _dateGetAcs.GetFinancialYearTable(0,
                                                       out startMonth,
                                                       out endMonth,
                                                       out yearMonth,
                                                       out year);
                _startMonth = yearMonth[0];
            }
            catch
            {
                startMonth = new List<DateTime>();
                endMonth = new List<DateTime>();
                yearMonth = new List<DateTime>();
                year = 0;
            }

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();
        }

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

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : ���o�������s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = 0;
            ArrayList PrintSets = null;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._campaignTargetSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._campaignTargetPrintWork);
            }
            else
            {
                status = this._campaignTargetSetAcs.SearchDelete(
                    out PrintSets,
                    this._enterpriseCode,
                    this._campaignTargetPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        
                        // ���i�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (CampaignTargetSet campaignTargetSet in PrintSets)
                        {

                            SecPrintSetToDataSet(campaignTargetSet.Clone(), index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN08630U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�L�����y�[���ڕW�ݒ�}�X�^�i����j", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._campaignTargetSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
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
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
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

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._campaignTargetPrintWork;
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

        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            DateGetAcs _dateGetAcs;
            _dateGetAcs = DateGetAcs.GetInstance();

            int inputValueSt = 0;
            int inputValueEd = 0;
            int.TryParse(this.tEdit_CampaingCode_St.DataText.TrimEnd(), out inputValueSt);
            int.TryParse(this.tEdit_CampaingCode_Ed.DataText.TrimEnd(), out inputValueEd);
            // �L�����y�[���R�[�h
            if (
                (this.tEdit_CampaingCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_CampaingCode_Ed.DataText.TrimEnd() != string.Empty) &&
                inputValueSt > inputValueEd)
            {
                errMessage = string.Format("�L�����y�[���R�[�h{0}", ct_RangeError);
                errComponent = this.tEdit_CampaingCode_St;
                return (false);
            }

            int.TryParse(this.tEdit_SectionCode_St.DataText.TrimEnd(), out inputValueSt);
            int.TryParse(this.tEdit_SectionCode_Ed.DataText.TrimEnd(), out inputValueEd);
            // ���_�R�[�h
            if (
                (this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                inputValueSt > inputValueEd)
            {
                errMessage = string.Format("���_{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                return (false);
            }

            int.TryParse(this.tEdit_EmployeeCode_St.DataText.TrimEnd(), out inputValueSt);
            int.TryParse(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd(), out inputValueEd);
            // �S���҃R�[�h
            if (
                (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                inputValueSt > inputValueEd)
            {
                errMessage = string.Format("�S����{0}", ct_RangeError);
                errComponent = this.tEdit_EmployeeCode_St;
                return (false);
            }

            // �a�k�R�[�h
            if (
                (this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return (false);
            }

            // �a�k�O���[�v
            if (
                (this.tNedit_GroupCode_St.GetInt() != 0) &&
                (this.tNedit_GroupCode_Ed.GetInt() != 0) &&
                this.tNedit_GroupCode_St.GetInt() > this.tNedit_GroupCode_Ed.GetInt())
            {
                errMessage = string.Format("�a�k�O���[�v{0}", ct_RangeError);
                errComponent = this.tNedit_GroupCode_St;
                status = false;
                return (false);
            }

            // �e��R�[�h
            if (
                (this.tNedit_GuideCode_St.GetInt() != 0) &&
                (this.tNedit_GuideCode_Ed.GetInt() != 0) &&
                this.tNedit_GuideCode_St.GetInt() > this.tNedit_GuideCode_Ed.GetInt())
            {
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 5:
                        errMessage = string.Format("�n��{0}", ct_RangeError);
                        break;
                    case 8:
                        errMessage = string.Format("�̔��敪{0}", ct_RangeError);
                        break;
                }
                errComponent = this.tNedit_GuideCode_St;
                status = false;
                return (false);
            }

            // ���Ӑ�
            if (
                (this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return (false);
            }

            // �폜���t
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, true, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    return (false);
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, true, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    return (false);
                }

                // �͈̓`�F�b�N
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "�폜���t�͈͎̔w��Ɍ�肪����܂��B";
                        errComponent = SerchSlipDataStRF_tDateEdit;
                        return (false);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="minValueCheck">�����̓`�F�b�N�t���O(True:�����͕s�� False:�����͉�)</param>
        /// <param name="DayCheck"></param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, bool DayCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if (DayCheck)
                {
                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "���t���w�肵�Ă��������B";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0))
                    {
                        errMsg = "���t���w�肵�Ă��������B";
                        return (false);
                    }
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }
                if (DayCheck)
                {

                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "���t���w�肵�Ă��������B";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0))
                    {
                        errMsg = "���t���w�肵�Ă��������B";
                        return (false);
                    }
                }
            }

            if (year < 1900)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            return (true);
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
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
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._campaignTargetPrintWork = new CampaignTargetPrintWork();

            this.Show();
            return;
        }
        #endregion

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���C���t���[���O���b�g���C�A�E�g�ݒ�
        /// </summary>
        /// <param name="UGrid"></param>
        /// <remarks>
        /// <br>Note       : ���C���t���[���O���b�g���C�A�E�g�ݒ���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            UGrid.DisplayLayout.Bands[0].UseRowLayout = true;

            // �񕝂̎����������@
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            UGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            UGrid.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            UGrid.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UGrid.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            #region ���ڂ̃T�C�Y��ݒ�
            sizeCell.Height = 22;
            sizeCell.Width = 60;
            sizeHeader.Height = 20;
            sizeHeader.Width = 60;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATEALL].Hidden = true;
            // �R�[�h
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 100;
            sizeHeader.Width = 100;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 320;
            sizeHeader.Width = 320;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���z
            sizeCell.Width = 120;
            sizeHeader.Width = 120;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            sizeCell.Width = 150;
            sizeHeader.Width = 150;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  ���ڂ̃T�C�Y��ݒ�

            #region LabelSpan�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpan�̐ݒ�

            #region �w�b�_����
            // �w�b�_���̂�ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].Header.Caption = CAMPAIGNCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].Header.Caption = CAMPAIGNNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Header.Caption = BLGOODSCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Header.Caption = SALESEMPLOYEECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Header.Caption = SALESEMPLOYEENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Header.Caption = FRONTEMPLOYEECD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Header.Caption = FRONTEMPLOYEENM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Header.Caption = SALESINPUTCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Header.Caption = SALESINPUTNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Header.Caption = SALESCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Header.Caption = SALESCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Header.Caption = BLGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Header.Caption = BLGROUPCODENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Header.Caption = SALESAREACODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Header.Caption = SALESAREACODENAME_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].Hidden = false;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].Hidden = false;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].Header.Caption = MONTHLYSALESTARGET_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].Header.Caption = TERMSALESTARGET_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].Header.Caption = MONTHLYSALESTARGET_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].Header.Caption = TERMSALESTARGET_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].Header.Caption = MONTHLYSALESTARGET_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].Header.Caption = TERMSALESTARGET_TITLE;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Header.Caption = _startMonth.Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Header.Caption = _startMonth.Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].Header.Caption = _startMonth.Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Header.Caption = _startMonth.AddMonths(1).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Header.Caption = _startMonth.AddMonths(1).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].Header.Caption = _startMonth.AddMonths(1).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Header.Caption = _startMonth.AddMonths(2).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Header.Caption = _startMonth.AddMonths(2).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].Header.Caption = _startMonth.AddMonths(2).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Header.Caption = _startMonth.AddMonths(3).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Header.Caption = _startMonth.AddMonths(3).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].Header.Caption = _startMonth.AddMonths(3).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Header.Caption = _startMonth.AddMonths(4).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Header.Caption = _startMonth.AddMonths(4).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].Header.Caption = _startMonth.AddMonths(4).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Header.Caption = _startMonth.AddMonths(5).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Header.Caption = _startMonth.AddMonths(5).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].Header.Caption = _startMonth.AddMonths(5).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Header.Caption = _startMonth.AddMonths(6).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Header.Caption = _startMonth.AddMonths(6).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].Header.Caption = _startMonth.AddMonths(6).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Header.Caption = _startMonth.AddMonths(7).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Header.Caption = _startMonth.AddMonths(7).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].Header.Caption = _startMonth.AddMonths(7).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Header.Caption = _startMonth.AddMonths(8).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Header.Caption = _startMonth.AddMonths(8).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].Header.Caption = _startMonth.AddMonths(8).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Header.Caption = _startMonth.AddMonths(9).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Header.Caption = _startMonth.AddMonths(9).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].Header.Caption = _startMonth.AddMonths(9).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Header.Caption = _startMonth.AddMonths(10).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Header.Caption = _startMonth.AddMonths(10).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].Header.Caption = _startMonth.AddMonths(10).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Header.Caption = _startMonth.AddMonths(11).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Header.Caption = _startMonth.AddMonths(11).Month + "��";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].Header.Caption = _startMonth.AddMonths(11).Month + "��";

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Header.Caption = SALESTARGETMONEYALL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Header.Caption = SALESTARGETPROFITALL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].Header.Caption = SALESTARGETCOUNTALL_TITLE;

            #endregion

            #region ��\������

            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: //���_
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 1: //���_-���Ӑ�
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 2: //���_-�S���� 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 3: //���_-�󒍎� 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 4: //���_-���s�� 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 5: //���_�{�n��
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = false;

                    break;
                case 6: //���_�{��ٰ�ߺ���
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 7: //���_�{BL����
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
                case 8: //���_�{�̔��敪
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].Hidden = false;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].Hidden = true;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].Hidden = true;
                    break;
            }
            #endregion

            // �����\���ʒu�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �\���t�H�[�}�b�g�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].Format = "#,##0";
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].Format = "#,##0";

            #region ��z�u

            int i_spanY = 4;

            // 1�s��

            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //���_-���Ӑ� 
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 2: //���_-�S���� 
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEECD].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESEMPLOYEENM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 3: //���_-�󒍎� 
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEECD].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[FRONTEMPLOYEENM].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 4: //���_-���s�� 
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESINPUTNAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 5: //���_-�n��
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESAREACODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 6: //���_�{��ٰ�ߺ���
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 7: //���_�{BL���� 
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
                case 8: //���_-�̔��敪
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginX = 10;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanY = 2 + i_spanY;

                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.OriginX = 12;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.OriginY = 0;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.SpanX = 2;
                    UGrid.DisplayLayout.Bands[0].Columns[SALESCODENAME].RowLayoutColumnInfo.SpanY = 2 + i_spanY;
                    break;
             
            }


            int cnt = 0;

            if ((int)this.tComboEditor_PrintType.Value != 0)
            {
                cnt = 4;
            }

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGET].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGET].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.OriginX = 32 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.OriginX = 34 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.OriginX = 36 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEY12].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.OriginX = 38 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETMONEYALL].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETPROFIT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETPROFIT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.OriginX = 32 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.OriginX = 34 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.OriginX = 36 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFIT12].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.OriginX = 38 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.OriginY = 0 + 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETPROFITALL].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.OriginX = 10 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MONTHLYSALESTARGETCOUNT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.OriginX = 12 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[TERMSALESTARGETCOUNT].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.OriginX = 14 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT1].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.OriginX = 16 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT2].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.OriginX = 18 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT3].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.OriginX = 20 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT4].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.OriginX = 22 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT5].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.OriginX = 24 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT6].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.OriginX = 26 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT7].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.OriginX = 28 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT8].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.OriginX = 30 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT9].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.OriginX = 32 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT10].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.OriginX = 34 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT11].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.OriginX = 36 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNT12].RowLayoutColumnInfo.SpanY = 2;


            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.OriginX = 38 + cnt;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.OriginY = 0 + i_spanY;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESTARGETCOUNTALL].RowLayoutColumnInfo.SpanY = 2;

            #endregion ��z�u

        }

        /// <summary>
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�����`�F�b�N�������s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public bool DataCheck()
        {
            bool status = true;

            //����p�^�[��
            if (this._campaignTargetPrintWork.PrintType != (int)this.tComboEditor_PrintType.Value)
            {
                status = false;
                return status;
            }

            int inputValue = 0;
            int.TryParse(tEdit_CampaingCode_St.DataText, out inputValue);
            //�J�n�L�����y�[���R�[�h
            if (this._campaignTargetPrintWork.CampaignCodeSt != inputValue)
            {
                status = false;
                return status;
            }

            int.TryParse(this.tEdit_CampaingCode_Ed.DataText, out inputValue);
            //�I���L�����y�[���R�[�h
            if (this._campaignTargetPrintWork.CampaignCodeEd != inputValue)
            {
                status = false;
                return status;
            }

            //�J�n���_
            if (this._campaignTargetPrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }

            //�I�����_
            if (this._campaignTargetPrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //���_-���Ӑ�
                    if (this._campaignTargetPrintWork.CustomerCodeSt != this.tNedit_CustomerCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.CustomerCodeEd != this.tNedit_CustomerCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 2: //���_-�S���� 
                case 3: //���_-�󒍎� 
                case 4: //���_-���s�� 
                    if (this._campaignTargetPrintWork.EmployeeCodeSt != this.tEdit_EmployeeCode_St.DataText)
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.EmployeeCodeEd != this.tEdit_EmployeeCode_Ed.DataText)
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 5: //���_-�n�� 
                    if (this._campaignTargetPrintWork.SalesAreaCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.SalesAreaCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 6: //���_�{��ٰ�ߺ���
                    if (this._campaignTargetPrintWork.BlGroupCodeSt != this.tNedit_GroupCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.BlGroupCodeEd != this.tNedit_GroupCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 7: //���_-BL���� 
                    if (this._campaignTargetPrintWork.BlGoodsCdSt != this.tNedit_BLGoodsCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.BlGoodsCdEd != this.tNedit_BLGoodsCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
                case 8: //���_-�̔��敪

                    if (this._campaignTargetPrintWork.SalesCodeSt != this.tNedit_GuideCode_St.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    if (this._campaignTargetPrintWork.SalesCodeEd != this.tNedit_GuideCode_Ed.GetInt())
                    {
                        status = false;
                        return status;
                    }
                    break;
            }

            // �폜�w��
            if (this._campaignTargetPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // �J�n�폜�N����
            if (this._campaignTargetPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // �I���폜�N����
            if (this._campaignTargetPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            return status;
        }
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
            get { return this._printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        /// <summary>
        /// PMKHN08710UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private void PMKHN08710UA_Load(object sender, EventArgs e)
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
            this.tComboEditor_PrintType.Focus();
        }

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
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
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
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
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

        #region DataSet�֘A
        /// <summary>
        /// ���i�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="campaignTargetSet">���i�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���i�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SecPrintSetToDataSet(CampaignTargetSet campaignTargetSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (campaignTargetSet.CampaignCode.Trim().PadLeft(6, '0').Equals("000000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = campaignTargetSet.CampaignCode.Trim().PadLeft(6, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNNAME] = campaignTargetSet.CampaignCodeName;

            if (string.IsNullOrEmpty(campaignTargetSet.SectionCode.Trim()))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = campaignTargetSet.SectionCode.Trim().PadLeft(2, '0');
            }
            if (campaignTargetSet.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = "�S��";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = campaignTargetSet.SectionGuideSnm;
            }
            if (campaignTargetSet.BlGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = campaignTargetSet.BlGoodsCode.ToString("00000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODENAME] = campaignTargetSet.BlGoodsCodeName;
            if (campaignTargetSet.SalesEmployeeCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEECD] = campaignTargetSet.SalesEmployeeCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESEMPLOYEENM] = campaignTargetSet.SalesEmployeeNm;
            if (campaignTargetSet.FrontEmployeeCd.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEECD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEECD] = campaignTargetSet.FrontEmployeeCd.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][FRONTEMPLOYEENM] = campaignTargetSet.FrontEmployeeNm;
            if (campaignTargetSet.SalesInputCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTCODE] = campaignTargetSet.SalesInputCode.Trim().PadLeft(4, '0');
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESINPUTNAME] = campaignTargetSet.SalesInputName;
            if (campaignTargetSet.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = campaignTargetSet.SalesCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODENAME] = campaignTargetSet.SalesCodeName;
            if (campaignTargetSet.BlGroupCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = campaignTargetSet.BlGroupCode.ToString("00000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODENAME] = campaignTargetSet.BlGroupCodeName;
            if (campaignTargetSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = campaignTargetSet.CustomerCode.ToString("00000000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = campaignTargetSet.CustomerSnm;
            if (campaignTargetSet.SalesAreaCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODE] = campaignTargetSet.SalesAreaCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESAREACODENAME] = campaignTargetSet.SalesAreaCodeName;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MONTHLYSALESTARGET] = campaignTargetSet.MonthlySalesTarget;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TERMSALESTARGET] = campaignTargetSet.TermSalesTarget;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY1] = campaignTargetSet.SalesTargetMoney1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY2] = campaignTargetSet.SalesTargetMoney2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY3] = campaignTargetSet.SalesTargetMoney3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY4] = campaignTargetSet.SalesTargetMoney4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY5] = campaignTargetSet.SalesTargetMoney5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY6] = campaignTargetSet.SalesTargetMoney6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY7] = campaignTargetSet.SalesTargetMoney7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY8] = campaignTargetSet.SalesTargetMoney8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY9] = campaignTargetSet.SalesTargetMoney9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY10] = campaignTargetSet.SalesTargetMoney10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY11] = campaignTargetSet.SalesTargetMoney11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEY12] = campaignTargetSet.SalesTargetMoney12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETMONEYALL] = campaignTargetSet.SalesTargetMoney1 +
                                                                                        campaignTargetSet.SalesTargetMoney2 +
                                                                                        campaignTargetSet.SalesTargetMoney3 +
                                                                                        campaignTargetSet.SalesTargetMoney4 +
                                                                                        campaignTargetSet.SalesTargetMoney5 +
                                                                                        campaignTargetSet.SalesTargetMoney6 +
                                                                                        campaignTargetSet.SalesTargetMoney7 +
                                                                                        campaignTargetSet.SalesTargetMoney8 +
                                                                                        campaignTargetSet.SalesTargetMoney9 +
                                                                                        campaignTargetSet.SalesTargetMoney10 +
                                                                                        campaignTargetSet.SalesTargetMoney11 +
                                                                                        campaignTargetSet.SalesTargetMoney12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MONTHLYSALESTARGETPROFIT] = campaignTargetSet.MonthlySalesTargetProfit;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TERMSALESTARGETPROFIT] = campaignTargetSet.TermSalesTargetProfit;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT1] = campaignTargetSet.SalesTargetProfit1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT2] = campaignTargetSet.SalesTargetProfit2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT3] = campaignTargetSet.SalesTargetProfit3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT4] = campaignTargetSet.SalesTargetProfit4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT5] = campaignTargetSet.SalesTargetProfit5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT6] = campaignTargetSet.SalesTargetProfit6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT7] = campaignTargetSet.SalesTargetProfit7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT8] = campaignTargetSet.SalesTargetProfit8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT9] = campaignTargetSet.SalesTargetProfit9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT10] = campaignTargetSet.SalesTargetProfit10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT11] = campaignTargetSet.SalesTargetProfit11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFIT12] = campaignTargetSet.SalesTargetProfit12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETPROFITALL] = campaignTargetSet.SalesTargetProfit1 +
                                                                                        campaignTargetSet.SalesTargetProfit2 +
                                                                                        campaignTargetSet.SalesTargetProfit3 +
                                                                                        campaignTargetSet.SalesTargetProfit4 +
                                                                                        campaignTargetSet.SalesTargetProfit5 +
                                                                                        campaignTargetSet.SalesTargetProfit6 +
                                                                                        campaignTargetSet.SalesTargetProfit7 +
                                                                                        campaignTargetSet.SalesTargetProfit8 +
                                                                                        campaignTargetSet.SalesTargetProfit9 +
                                                                                        campaignTargetSet.SalesTargetProfit10 +
                                                                                        campaignTargetSet.SalesTargetProfit11 +
                                                                                        campaignTargetSet.SalesTargetProfit12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MONTHLYSALESTARGETCOUNT] = campaignTargetSet.MonthlySalesTargetCount;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][TERMSALESTARGETCOUNT] = campaignTargetSet.TermSalesTargetCount;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT1] = campaignTargetSet.SalesTargetCount1;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT2] = campaignTargetSet.SalesTargetCount2;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT3] = campaignTargetSet.SalesTargetCount3;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT4] = campaignTargetSet.SalesTargetCount4;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT5] = campaignTargetSet.SalesTargetCount5;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT6] = campaignTargetSet.SalesTargetCount6;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT7] = campaignTargetSet.SalesTargetCount7;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT8] = campaignTargetSet.SalesTargetCount8;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT9] = campaignTargetSet.SalesTargetCount9;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT10] = campaignTargetSet.SalesTargetCount10;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT11] = campaignTargetSet.SalesTargetCount11;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNT12] = campaignTargetSet.SalesTargetCount12;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESTARGETCOUNTALL] = campaignTargetSet.SalesTargetCount1 +
                                                                                        campaignTargetSet.SalesTargetCount2 +
                                                                                        campaignTargetSet.SalesTargetCount3 +
                                                                                        campaignTargetSet.SalesTargetCount4 +
                                                                                        campaignTargetSet.SalesTargetCount5 +
                                                                                        campaignTargetSet.SalesTargetCount6 +
                                                                                        campaignTargetSet.SalesTargetCount7 +
                                                                                        campaignTargetSet.SalesTargetCount8 +
                                                                                        campaignTargetSet.SalesTargetCount9 +
                                                                                        campaignTargetSet.SalesTargetCount10 +
                                                                                        campaignTargetSet.SalesTargetCount11 +
                                                                                        campaignTargetSet.SalesTargetCount12;
            const string dateFormat = "YYYY/MM/DD";
            string stTarget = TDateTime.DateTimeToString(dateFormat, campaignTargetSet.ApplyStaDate);
            string edTarget = TDateTime.DateTimeToString(dateFormat, campaignTargetSet.ApplyEndDate);
            if (!string.IsNullOrEmpty(stTarget) && !string.IsNullOrEmpty(edTarget))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYDATEALL] = "[" + stTarget + "�`" + edTarget + "]";
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            PrintSetTable.Columns.Add(CAMPAIGNCODE, typeof(string));		        // 	����߰�
            PrintSetTable.Columns.Add(CAMPAIGNNAME, typeof(string));		        // 	����߰ݖ�
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));		            // 	���_
            PrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));		        // 	���_��
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		        // 	���Ӑ�
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		            // 	���Ӑ於
            PrintSetTable.Columns.Add(SALESEMPLOYEECD, typeof(string));		        // 	�S����
            PrintSetTable.Columns.Add(SALESEMPLOYEENM, typeof(string));		        // 	�S���Җ�
            PrintSetTable.Columns.Add(FRONTEMPLOYEECD, typeof(string));		        // 	�󒍎�
            PrintSetTable.Columns.Add(FRONTEMPLOYEENM, typeof(string));		        // 	�󒍎Җ�
            PrintSetTable.Columns.Add(SALESINPUTCODE, typeof(string));		        // 	���s��
            PrintSetTable.Columns.Add(SALESINPUTNAME, typeof(string));		        // 	���s�Җ�
            PrintSetTable.Columns.Add(SALESAREACODE, typeof(string));		        // 	�n��
            PrintSetTable.Columns.Add(SALESAREACODENAME, typeof(string));		    // 	�n�於
            PrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));		            // 	��ٰ�ߺ���
            PrintSetTable.Columns.Add(BLGROUPCODENAME, typeof(string));		        // 	��ٰ�ߺ��ޖ�
            PrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));		            // 	BL����
            PrintSetTable.Columns.Add(BLGOODSCODENAME, typeof(string));		        // 	BL���ޖ�
            PrintSetTable.Columns.Add(SALESCODE, typeof(string));		            // 	�̔��敪
            PrintSetTable.Columns.Add(SALESCODENAME, typeof(string));		        // 	�̔��敪��

            PrintSetTable.Columns.Add(MONTHLYSALESTARGET, typeof(Int64));		    // 	���ԁ@����ڕW
            PrintSetTable.Columns.Add(TERMSALESTARGET, typeof(Int64));		        // 	���ԁ@����ڕW
            PrintSetTable.Columns.Add(SALESTARGETMONEY1, typeof(Int64));		    // 	����P
            PrintSetTable.Columns.Add(SALESTARGETMONEY2, typeof(Int64));		    // 	����Q
            PrintSetTable.Columns.Add(SALESTARGETMONEY3, typeof(Int64));		    // 	����R
            PrintSetTable.Columns.Add(SALESTARGETMONEY4, typeof(Int64));		    // 	����S
            PrintSetTable.Columns.Add(SALESTARGETMONEY5, typeof(Int64));		    // 	����T
            PrintSetTable.Columns.Add(SALESTARGETMONEY6, typeof(Int64));		    // 	����U
            PrintSetTable.Columns.Add(SALESTARGETMONEY7, typeof(Int64));		    // 	����V
            PrintSetTable.Columns.Add(SALESTARGETMONEY8, typeof(Int64));		    // 	����W
            PrintSetTable.Columns.Add(SALESTARGETMONEY9, typeof(Int64));		    // 	����X
            PrintSetTable.Columns.Add(SALESTARGETMONEY10, typeof(Int64));		    // 	����P�O
            PrintSetTable.Columns.Add(SALESTARGETMONEY11, typeof(Int64));		    // 	����P�P
            PrintSetTable.Columns.Add(SALESTARGETMONEY12, typeof(Int64));		    // 	����P�Q
            PrintSetTable.Columns.Add(SALESTARGETMONEYALL, typeof(Int64));		    // 	���㍇�v

            PrintSetTable.Columns.Add(MONTHLYSALESTARGETPROFIT, typeof(Int64));		// 	���ԁ@�e���ڕW
            PrintSetTable.Columns.Add(TERMSALESTARGETPROFIT, typeof(Int64));		// 	���ԁ@�e���ڕW
            PrintSetTable.Columns.Add(SALESTARGETPROFIT1, typeof(Int64));		    // 	�e���P
            PrintSetTable.Columns.Add(SALESTARGETPROFIT2, typeof(Int64));		    // 	�e���Q
            PrintSetTable.Columns.Add(SALESTARGETPROFIT3, typeof(Int64));		    // 	�e���R
            PrintSetTable.Columns.Add(SALESTARGETPROFIT4, typeof(Int64));		    // 	�e���S
            PrintSetTable.Columns.Add(SALESTARGETPROFIT5, typeof(Int64));		    // 	�e���T
            PrintSetTable.Columns.Add(SALESTARGETPROFIT6, typeof(Int64));		    // 	�e���U
            PrintSetTable.Columns.Add(SALESTARGETPROFIT7, typeof(Int64));		    // 	�e���V
            PrintSetTable.Columns.Add(SALESTARGETPROFIT8, typeof(Int64));		    // 	�e���W
            PrintSetTable.Columns.Add(SALESTARGETPROFIT9, typeof(Int64));		    // 	�e���X
            PrintSetTable.Columns.Add(SALESTARGETPROFIT10, typeof(Int64));		    // 	�e���P�O
            PrintSetTable.Columns.Add(SALESTARGETPROFIT11, typeof(Int64));		    // 	�e���P�P
            PrintSetTable.Columns.Add(SALESTARGETPROFIT12, typeof(Int64));		    // 	�e���P�Q
            PrintSetTable.Columns.Add(SALESTARGETPROFITALL, typeof(Int64));		    // 	�e�����v

            PrintSetTable.Columns.Add(MONTHLYSALESTARGETCOUNT, typeof(Int64));		// 	���ԁ@���ʖڕW
            PrintSetTable.Columns.Add(TERMSALESTARGETCOUNT, typeof(Int64));		// 	���ԁ@���ʖڕW
            PrintSetTable.Columns.Add(SALESTARGETCOUNT1, typeof(Int64));		    // 	���ʂP
            PrintSetTable.Columns.Add(SALESTARGETCOUNT2, typeof(Int64));		    // 	���ʂQ
            PrintSetTable.Columns.Add(SALESTARGETCOUNT3, typeof(Int64));		    // 	���ʂR
            PrintSetTable.Columns.Add(SALESTARGETCOUNT4, typeof(Int64));		    // 	���ʂS
            PrintSetTable.Columns.Add(SALESTARGETCOUNT5, typeof(Int64));		    // 	���ʂT
            PrintSetTable.Columns.Add(SALESTARGETCOUNT6, typeof(Int64));		    // 	���ʂU
            PrintSetTable.Columns.Add(SALESTARGETCOUNT7, typeof(Int64));		    // 	���ʂV
            PrintSetTable.Columns.Add(SALESTARGETCOUNT8, typeof(Int64));		    // 	���ʂW
            PrintSetTable.Columns.Add(SALESTARGETCOUNT9, typeof(Int64));		    // 	���ʂX
            PrintSetTable.Columns.Add(SALESTARGETCOUNT10, typeof(Int64));		    // 	���ʂP�O
            PrintSetTable.Columns.Add(SALESTARGETCOUNT11, typeof(Int64));		    // 	���ʂP�P
            PrintSetTable.Columns.Add(SALESTARGETCOUNT12, typeof(Int64));		    // 	���ʂP�Q
            PrintSetTable.Columns.Add(SALESTARGETCOUNTALL, typeof(Int64));		    // 	���ʍ��v
            PrintSetTable.Columns.Add(APPLYDATEALL, typeof(string));		        // 	���ʍ��v
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet�֘A

        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                this.tEdit_SectionCode_St.DataText = string.Empty;
                this.tEdit_SectionCode_Ed.DataText = string.Empty;
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                this.tNedit_GroupCode_St.DataText = string.Empty;
                this.tNedit_GroupCode_Ed.DataText = string.Empty;
                this.tNedit_GuideCode_St.DataText = string.Empty;
                this.tNedit_GuideCode_Ed.DataText = string.Empty;
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_CampaingCode_St.DataText = string.Empty;
                this.tEdit_CampaingCode_Ed.DataText = string.Empty;

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GroupCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GroupCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CustomerCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BlCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BlCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CampaingCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CampaingCode, Size16_Index.STAR1);

                // �R���{�̏�����
                this.tComboEditor_PrintType.Value = 0;

                // �폜�w��R���{�̐ݒ�
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // �T�u���ڂ̔�\��
                this.pn_Employee.Visible = false;
                this.pn_GroupCode.Visible = false;
                this.pn_Guide.Visible = false;
                this.pn_Customer.Visible = false;

                // �����t�H�[�J�X�Z�b�g
                this.tComboEditor_PrintType.Focus();
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
        /// <br>Note       : �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                this._campaignTargetPrintWork.StartMonth = this._startMonth;

                //����p�^�[��
                this._campaignTargetPrintWork.PrintType = this.tComboEditor_PrintType.SelectedIndex;

                int inputValue = 0;
                int.TryParse(this.tEdit_CampaingCode_St.DataText, out inputValue);
                //�J�n�L�����y�[���R�[�h
                if (!string.IsNullOrEmpty(this.tEdit_CampaingCode_St.DataText))
                {
                    this._campaignTargetPrintWork.CampaignCodeSt = inputValue;
                }
                else
                {
                    this._campaignTargetPrintWork.CampaignCodeSt = 0;
                }

                int.TryParse(this.tEdit_CampaingCode_Ed.DataText, out inputValue);
                //�I���L�����y�[���R�[�h
                if (!string.IsNullOrEmpty(this.tEdit_CampaingCode_Ed.DataText))
                {
                    this._campaignTargetPrintWork.CampaignCodeEd = inputValue;
                }
                else
                {
                    this._campaignTargetPrintWork.CampaignCodeEd = 0;
                }

                //�J�n���_
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText))
                {
                    this._campaignTargetPrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignTargetPrintWork.SectionCodeSt))
                    {
                        this._campaignTargetPrintWork.SectionCodeSt = string.Empty;
                    }
                }
                else
                {
                    this._campaignTargetPrintWork.SectionCodeSt = string.Empty;
                }

                //�I�����_
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText))
                {
                    this._campaignTargetPrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignTargetPrintWork.SectionCodeEd))
                    {
                        this._campaignTargetPrintWork.SectionCodeEd = string.Empty;
                    }
                }
                else
                {
                    this._campaignTargetPrintWork.SectionCodeEd = string.Empty;
                }

                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: //���_
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;

                        break;
                    case 1: //���_�{���Ӑ�
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                        this._campaignTargetPrintWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 2: //���_-�S���� 
                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0');
                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeSt))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0');

                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeEd))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                        }

                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 10;
                        break;
                    case 3: //���_-�󒍎� 
                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0');
                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeSt))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0');

                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeEd))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                        }
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 20;
                        break;
                    case 4: //���_-���s�� 
                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = this.tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0');
                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeSt))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeSt = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0');

                            if ("0000".Equals(this._campaignTargetPrintWork.EmployeeCodeEd))
                            {
                                this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                            }
                        }
                        else
                        {
                            this._campaignTargetPrintWork.EmployeeCodeEd = string.Empty;
                        }
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 30;
                        break;
                    case 5: //���_�{�n��
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._campaignTargetPrintWork.SalesAreaCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 6: //���_�{��ٰ�ߺ���
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = 0;
                        this._campaignTargetPrintWork.SalesCodeEd = 0;
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = this.tNedit_GroupCode_St.GetInt();
                        this._campaignTargetPrintWork.BlGroupCodeEd = this.tNedit_GroupCode_Ed.GetInt();
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 7: //���_�{BL����
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = this.tNedit_BLGoodsCode_St.GetInt();
                        this._campaignTargetPrintWork.BlGoodsCdEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                    case 8: //���_�{�̔��敪
                        this._campaignTargetPrintWork.EmployeeCodeSt = "";
                        this._campaignTargetPrintWork.EmployeeCodeEd = "";
                        this._campaignTargetPrintWork.SalesCodeSt = this.tNedit_GuideCode_St.GetInt();
                        this._campaignTargetPrintWork.SalesCodeEd = this.tNedit_GuideCode_Ed.GetInt();
                        this._campaignTargetPrintWork.CustomerCodeSt = 0;
                        this._campaignTargetPrintWork.CustomerCodeEd = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeSt = 0;
                        this._campaignTargetPrintWork.SalesAreaCodeEd = 0;
                        this._campaignTargetPrintWork.BlGoodsCdSt = 0;
                        this._campaignTargetPrintWork.BlGoodsCdEd = 0;
                        this._campaignTargetPrintWork.BlGroupCodeSt = 0;
                        this._campaignTargetPrintWork.BlGroupCodeEd = 0;
                        this._campaignTargetPrintWork.EmployeeDivCd = 0;
                        break;
                }
                // �폜�w��敪
                this._campaignTargetPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // �J�n�폜���t
                this._campaignTargetPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // �I���폜���t
                this._campaignTargetPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        #endregion

        /// <summary>
        /// ����p�^�[���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ����p�^�[���ύX���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: //���_
                    this.pn_GroupCode.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;
                    break;

                case 1: //���_�{���Ӑ� 
                    this.pn_GroupCode.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = true;
                    this.pn_Customer.Location = this.pn_Employee.Location;
                    this.pn_Bl.Visible = false;
                    break;
                case 2: //���_-�S���� 
                case 3: //���_-�󒍎� 
                case 4: //���_-���s�� 
                    this.pn_Employee.Visible = true;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Guide.Visible = false;
                    this.pn_Customer.Visible = false;

                    break;
                case 5: //���_�{�n�� 
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;

                    this.Lb_Guide.Text = "�n��";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�n��K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk.ToolTipText = "�n��K�C�h";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk);

                    break;
                case 6: //���_�{��ٰ�ߺ���
                    this.pn_Guide.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = true;
                    this.pn_GroupCode.Location = this.pn_Employee.Location;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;
                    break;
                case 7: //���_�{BL����
                    this.pn_Bl.Visible = true;
                    this.pn_Bl.Location = this.pn_Employee.Location;

                    this.pn_Customer.Visible = false;
                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Guide.Visible = false;

                    break;
                case 8: //���_�{�̔��敪
                    this.pn_Guide.Visible = true;
                    this.pn_Guide.Location = this.pn_Employee.Location;

                    this.pn_Employee.Visible = false;
                    this.pn_GroupCode.Visible = false;
                    this.pn_Customer.Visible = false;
                    this.pn_Bl.Visible = false;

                    this.Lb_Guide.Text = "�̔��敪";
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfowk3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�̔��敪�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
                    ultraToolTipInfowk3.ToolTipText = "�̔��敪�K�C�h";
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_St_GuideCode, ultraToolTipInfowk3);
                    this.ultraToolTipManager1.SetUltraToolTip(this.ub_Ed_GuideCode, ultraToolTipInfowk3);
                    break;
            }

            this.tEdit_EmployeeCode_St.DataText = string.Empty;
            this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
            this.tNedit_GroupCode_St.DataText = string.Empty;
            this.tNedit_GroupCode_Ed.DataText = string.Empty;
            this.tNedit_GuideCode_St.DataText = string.Empty;
            this.tNedit_GuideCode_Ed.DataText = string.Empty;
            this.tNedit_CustomerCode_St.DataText = string.Empty;
            this.tNedit_CustomerCode_Ed.DataText = string.Empty;
            this.tNedit_BLGoodsCode_St.DataText = string.Empty;
            this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
        }

        /// <summary>
        /// �L�����y�[���{�^���̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���{�^���̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_CampaingCode_Click(object sender, EventArgs e)
        {
            CampaignSt campaignSt;
            TEdit targetControl = null;
            Control nextControl = null;
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                // �K�C�h�N��
                int status = _campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    string tag = (string)((UltraButton)sender).Tag;

                    if (tag.ToString().CompareTo("1") == 0)
                    {
                        targetControl = this.tEdit_CampaingCode_St;
                        nextControl = this.tEdit_CampaingCode_Ed;
                    }
                    else if (tag.ToString().CompareTo("2") == 0)
                    {
                        targetControl = this.tEdit_CampaingCode_Ed;
                        nextControl = this.tEdit_SectionCode_St;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                // �R�[�h�W�J
                targetControl.DataText = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                // �t�H�[�J�X
                nextControl.Focus();
            }
            finally
            {
                //this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// ���_�{�^���̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���_�{�^���̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_SectionCode_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // ���_�K�C�h�\��
            status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tEdit_SectionCode_St;
                nextControl = this.tEdit_SectionCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tEdit_SectionCode_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: //���_ 
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                    case 1: //���_-���Ӑ�  
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 2: //���_-�S���� 
                    case 3: //���_-�󒍎� 
                    case 4: //���_-���s�� 
                        nextControl = this.tEdit_EmployeeCode_St;
                        break;
                    case 5: //���_-�n��
                    case 8: //���_-�̔��敪 
                        nextControl = this.tNedit_GuideCode_St;
                        break;
                    case 6: //���_�{��ٰ�ߺ���
                        nextControl = this.tNedit_GroupCode_St;
                        break;
                    case 7: //���_�{BL����
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                }

            }
            else
            {
                return;
            }

            if (status != 0)
            {
                return;
            }

            // �R�[�h�W�J
            targetControl.DataText = secInfoSet.SectionCode.Trim();
            // �t�H�[�J�X
            nextControl.Focus();
        }

        /// <summary>
        /// �S���҃K�C�h�{�^���̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �S���҃K�C�h�{�^���̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.ub_St_EmployeeGuide)
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tComboEditor_LogicalDeleteCode.Focus();
                }
            }
        }

        /// <summary>
        /// BL�O���[�v�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_GroupCode_Click(object sender, EventArgs e)
        {
            // BL�O���[�v�K�C�h�N��

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    this.tNedit_GroupCode_St.SetInt(blGroupU.BLGroupCode);
                    this.tNedit_GroupCode_Ed.Focus();
                }
                else
                {
                    this.tNedit_GroupCode_Ed.SetInt(blGroupU.BLGroupCode);
                    this.tComboEditor_LogicalDeleteCode.Focus();
                }
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_GuideCode_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 0;
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 5: //���_-�n��
                    GuideNo = 21;
                    break;
                case 8: //���_-�̔��敪  
                    GuideNo = 71;
                    break;
            }

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GuideCode_St;
                nextControl = this.tNedit_GuideCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GuideCode_Ed;
                nextControl = this.tComboEditor_LogicalDeleteCode;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // �t�H�[�J�X�ړ�
            nextControl.Focus();
        }

        /// <summary>
        /// ���Ӑ�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_CustomerCd_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // �K�C�h�㎟�t�H�[�J�X
            if (_customerGuideOK)
            {
                Control nextControl;
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.tNedit_CustomerCode_Ed;
                }
                else
                {
                    nextControl = this.tComboEditor_LogicalDeleteCode;
                }
                // �t�H�[�J�X�ړ�
                nextControl.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I���������C�x���g���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (_customerGuideSender == this.ub_St_CustomerCd)
            {
                this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
        }

        /// <summary>
        /// Bl�R�[�h�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Bl�R�[�h�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_BlCode_Click(object sender, EventArgs e)
        {
             BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

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
                this.tComboEditor_LogicalDeleteCode.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// �폜�w��ݒ莞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �폜�w��ݒ���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_LogicalDeleteCode_ValueChanged(object sender, EventArgs e)
        {
         if ((int)tComboEditor_LogicalDeleteCode.Value == 1)
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.Now);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.Now);
            }
            else
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
            }
        }
    }
}