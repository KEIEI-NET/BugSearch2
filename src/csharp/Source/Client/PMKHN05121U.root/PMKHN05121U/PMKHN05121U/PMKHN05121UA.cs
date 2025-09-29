//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ�UI�t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinStatusBar;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ�UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ�UI�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public partial class PMKHN05121UA : Form
    {
        #region -- Constant --

        /// <summary>�v���O����ID��\���萔:PMKHN05121UA</summary>
        private readonly string pgId = "PMKHN05121U";
        /// <summary>�O���b�h�̃O���[�v�w�b�_No��\���萔</summary>
        private readonly string hdrGrpKeyNo = "NoGrp";
        /// <summary>�O���b�h�̃O���[�v�w�b�_�ύX�O��\���萔</summary>
        private readonly string hdrGrpKeyBefore = "BeforeGrp";
        /// <summary>�O���b�h�̃O���[�v�w�b�_�ύX���\���萔</summary>
        private readonly string hdrGrpKeyAfter = "AfterGrp";
        /// <summary>���o�����A�ꊇ�ݒ�̏k�����̃T�C�Y</summary>
        private readonly int egbGrpBoxCntrctSize = 25;
        /// <summary>���Ӑ於�̂��o�^����Ă��Ȃ����Ƃ������萔�F���o�^</summary>
        private readonly string noCustomerName = "���o�^";
        /// <summary>�擪�s��\����ʐ�</summary>
        private readonly int firstRow = 0;
        /// <summary>���Ӑ�R�[�h�ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private const int ILLEGAL_DATA = 997;
        /// <summary>���Ӑ�R�[�h�ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private const int NO_DATA = 998;
        /// <summary>���Ӑ�R�[�h�ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private const int NO_FILE = 999;
        /// <summary>���l�`�F�b�N�p�̐��K�\���F^\d+$</summary>
        private readonly string regPttrnNum = @"^\d+$";

        #region -- ���O�֘A --
        /// <summary>���O�o�͐�̃f�B���N�g������\���萔�F./LOG/PMKHN05120U</summary>
        private const string LOG_DIR_PATH = @"./LOG/PMKHN05120U";
        /// <summary>���O�t�@�C������\���萔�FPMKHN05120U.log</summary>
        private const string LOG_FILE_NAME = @"PMKHN05120U_{0}.log";
        /// <summary>���O�t�@�C�����̓��t�����̃t�H�[�}�b�g�FyyyyMMdd</summary>
        private const string LOG_FORMAT_DATE = "yyyyMMdd";
        /// <summary>���O�t�H�[�}�b�g�FHH:mm:ss</summary>
        private const string LOG_FORMAT_PROCESSING_TIME = "HH:mm:ss";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] ���Ӑ�R�[�h�ϊ��������J�n���܂��B</summary>
        private const string LOG_FORMAT_START = "[{0}] ���Ӑ�R�[�h�ϊ��������J�n���܂��B";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] ���Ӑ�R�[�h�ϊ��������������܂����B</summary>
        private const string LOG_FORMAT_END = "[{0}] ���Ӑ�R�[�h�ϊ��������������܂����B";
        /// <summary>���O�t�H�[�}�b�g�F[{0}],�X�V�ΏہF{1},�X�V�����F{2}��,�������ԁF{3}</summary>
        private const string LOG_FORMAT_CASE_BY_BASE = "[{0}],�X�V�ΏہF{1},�X�V�����F{2}��,�������ԁF{3}";
        /// <summary>���O�t�H�[�}�b�g�F[{0}],���������ԁF{1},���X�V�����F{2}��</summary>
        private const string LOG_FORMAT_TOTAL = "[{0}],���������ԁF{1},���X�V�����F{2}��";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] {1}�̕ϊ����ɃG���[���������܂����B�ϊ������𒆎~���܂��B</summary>
        private const string LOG_FORMAT_ERROR = "[{0}] {1}�̕ϊ����ɃG���[���������܂����B�ϊ������𒆎~���܂��B";
        /// <summary>���O�t�@�C�����̓��t�t�H�[�}�b�g�Fyyyy/MM/dd HH:mm:ss</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd HH:mm:ss";
        #endregion

        /// <summary>���Ӑ�R�[�h�̃t�H�[�}�b�g</summary>
        private static readonly string cdFormat = "{0:D8}";

        #endregion

        #region -- Member --

        /// <summary>
        /// �X�e�[�^�X�o�[�X�V�����f���Q�[�g
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���X�V���邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        delegate void UpdateStatusBarDelegate(string mes);

        /// <summary>
        /// �X�e�[�^�X�o�[�����������f���Q�[�g
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[�����������邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        delegate void InitStatusBarDelegate(int cnvTrgCount);

        // �A�N�Z�X�N���X�֘A
        /// <summary>���Ӑ�K�C�h</summary>
        private CustomerInfoAcs customerAcs;
        /// <summary>���Ӑ�R�[�h�ϊ�</summary>
        private CustomerConvertAcs customerCnvAcs;
        /// <summary>���_�}�X�^</summary>
        private SecInfoAcs secInfoAcs;
        /// <summary>�������_�C�A���O</summary>
        private SFCMN00299CA procDlg = null;

        /// <summary>���O�C�����[�U�̏������_</summary>
        private string loginSecCd = String.Empty;
        /// <summary>��ƃR�[�h</summary>
        private string enterPriseCd = String.Empty;
        /// <summary>���o�����ƈꊇ�ݒ��UltraExpandableGroupBox�̓W�J���̍��������i�[�����}�b�v</summary>
        private IDictionary<EgbGrpBoxType, int> egbGrpBoxHeighMap = null;
        /// <summary>��ʂ̃X�L�������i�[</summary>
        private ControlScreenSkin ctrlScrnSkin;
        /// <summary>���_�����i�[�}�b�v</summary>
        private Dictionary<string, String> secInfoMap;
        /// <summary>���Ӑ���i�[�}�b�v</summary>
        private Dictionary<string, String> customerInfoMap;
        /// <summary>�X�V�t���O(true:�X�V�ς�/false:���X�V)</summary>
        private bool isUpdate = false;
        /// <summary>�ҏW�ς݊m�F�t���O(true:�ҏW�ς�/false:���ҏW)</summary>
        private bool isEdit = false;
        /// <summary>���̓`�F�b�N�̌��ʂ��i�[����ϐ�(true:�`�F�b�NOK/false:�`�F�b�NNG)</summary>
        private bool isCheckOK = false;
        /// <summary>�R�[�h�̌���</summary>
        private readonly int codeLength;
        /// <summary>�X���b�h���s���̃G���[���b�Z�[�W��ۑ�</summary>
        private string cnvErrMes = String.Empty;
        /// <summary>FormCloing�C�x���g�Ŏ��{���ꂽ���𔻒肷��t���O(true:FormCloig������{/false:FormCloing�ȊO�Ŏ��{)</summary>
        private bool isCallFormCloseingEvent = false;
        /// <summary>�ꊇ�ݒ�̊e���ڂ̓��͒l��ۑ�����}�b�v</summary>
        private IDictionary<AllSettingType, int> allSttngPrevValMap = null;
        /// <summary>�������ꂽ�K�C�h�{�^����ێ�����ϐ�</summary>
        private GuidButtonType btnType;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ�UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���Ӑ�}�X�^�R�[�h�ϊ�UI�t�H�[���N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public PMKHN05121UA()
        {
            InitializeComponent();

            // �e�핔�i�̏��������s���܂��B
            this.ctrlScrnSkin = new ControlScreenSkin();
            // ���o�����ƈꊇ�ݒ�̓W�J���̍�������ۑ����܂��B
            this.egbGrpBoxHeighMap = new Dictionary<EgbGrpBoxType, int>(Enum.GetValues(typeof(EgbGrpBoxType)).Length);
            this.egbGrpBoxHeighMap[EgbGrpBoxType.CollectiveSetting] = this.ultrEgbCllctvSttng.Height;
            this.egbGrpBoxHeighMap[EgbGrpBoxType.Condition] = this.ultrEgbCondition.Height;

            // �ꊇ�ݒ�̊e���ڂ̓��͒l��ۑ�����}�b�v�����������܂��B
            this.InitAllSttngPrevValMap();

            // �R�[�h�̌�����ݒ肵�܂��B
            this.codeLength = 8;
        }

        #endregion

        #region -- Protected Method --

        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                // ���N���X�̃��[�h�����s���܂��B
                base.OnLoad(e);

                // ��ʂ̕`����ꎞ��~���܂��B
                this.SuspendLayout();

                // �e�R���g���[���̏����������s���܂��B
                this.InitSetting();

                // ��ʂ̃X�L����ݒ肵�܂��B
                this.InitSkin();

                // ���j���[�A�y�у{�^���̃A�C�R����ݒ肵�܂��B
                this.tToolBarMain.ImageListSmall = IconResourceManagement.ImageList16;
                this.ultrBtnCstmrStart.ImageList = IconResourceManagement.ImageList16;
                this.ultrBtnCstmrEnd.ImageList = IconResourceManagement.ImageList16;

                // ���_�}�X�^�̏�����
                this.secInfoAcs = new SecInfoAcs();
                this.SaveSecInfoToMemory();

                // ��ƃR�[�h
                this.enterPriseCd = LoginInfoAcquisition.EnterpriseCode;
                // ���O�C�����_�R�[�h
                this.loginSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                // ���O�C�����[�U����������
                this.SetUserInfo();

                // ���Ӑ�}�X�^�̏�����
                this.customerAcs = new CustomerInfoAcs();

                // �O���b�h�̏����ݒ���s���܂��B
                this.InitGrid();

                // ���Ӑ�R�[�h�ϊ��A�N�Z�X�N���X
                this.customerCnvAcs = new CustomerConvertAcs();
                this.SaveCustomerInfoToMemory();

                // ���l���͗��̏�����
                this.SetTnEditMaxLength(this.pnlCllctvSttng);
                this.SetTnEditMaxLength(this.pnlCondtion);

                // �ꊇ�ݒ�̓��͗������������܂��B
                this.SetAllSettingTypeOnTNEdit();

                // ��ʂ̕`����ĊJ���܂��B
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                this.ShowError(String.Format(MessageMng.ERR_MES_012, ex.Message), 
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
        }

        #endregion

        #region -- Private Method --

        #region -- �����ݒ�֘A --

        /// <summary>
        /// ��ʃX�L���t�@�C�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃX�L���t�@�C���̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitSkin()
        {
            // �X�L���K�p�O�̃R���g���[����ۑ����܂�
            List<string> exclustionList = new List<string>();
            exclustionList.Add(this.ultrEgbCllctvSttng.Name);
            exclustionList.Add(this.ultrEgbCondition.Name);
            this.ctrlScrnSkin.SetExceptionCtrl(exclustionList);

            // ��ʃX�L���t�@�C����ݒ肵�܂��B
            this.ctrlScrnSkin.LoadSkin();
            this.ctrlScrnSkin.SettingScreenSkin(this);
        }

        /// <summary>
        /// �e�R���g���[������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�R���g���[���̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitSetting()
        {
            // UltraExpandableGroupBox�̏�����
            // ���o����
            this.ultrEgbCondition.Tag = EgbGrpBoxType.Condition;
            // �ꊇ�ݒ�
            this.ultrEgbCllctvSttng.Tag = EgbGrpBoxType.CollectiveSetting;

            // ���Ӑ�K�C�h�{�^���̏�����
            // ���Ӑ�K�C�h�J�n
            this.ultrBtnCstmrStart.Tag = GuidButtonType.Start;
            // ���Ӑ�K�C�h�I��
            this.ultrBtnCstmrEnd.Tag = GuidButtonType.End;
        }

        /// <summary>
        /// ���[�U��񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�C�����[�U�������Ƀ��[�U�̕\������ݒ肵�܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetUserInfo()
        {
            // ���O�C����񂪖����ꍇ�́A����ȍ~�̏��������s���܂���B
            if (LoginInfoAcquisition.Employee == null)
            {
                return;
            }

            // ���j���[�o�[�̋��_���ƃ��O�C�����ɒl���Z�b�g���܂��B
            foreach (ToolBase tlBase in this.tToolBarMain.Tools)
            {
                switch (tlBase.Key)
                {
                    case ToolMenuType.LBL_TOOL_SECTION:
                        // ���_���̏ꍇ
                        tlBase.SharedProps.Caption = this.GetSecName(LoginInfoAcquisition.Employee.BelongSectionCode);
                        break;
                    case ToolMenuType.LBL_TOOL_NAME:
                        // ���O�C�����̏ꍇ
                        tlBase.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
                        break;
                    default:
                        // ��L�ȊO�̏ꍇ�́A�����������܂���B
                        break;
                }
            }
        }

        /// <summary>
        /// ���l���͗�����������
        /// </summary>
        /// <param name="parent">�R���g���[��</param>
        /// <remarks>
        /// <br>Note       : ���l���͗��̏��������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetTnEditMaxLength(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                TNedit edit = child as TNedit;
                if (edit == null)
                {
                    // null�̏ꍇ�͔�TNEdit�Ȃ̂ŁA�q�R���g���[����TNEdit��������
                    // �ċA�I�ɒ��ׂ܂��B
                    this.SetTnEditMaxLength(child);
                }
                else
                {
                    // TNedit�̏ꍇ�́A�ő包����ݒ肵�܂��B
                    edit.MaxLength = this.codeLength +1; //�}�C�i�X���l��
                }
            }
        }

        /// <summary>
        /// �ꊇ�ݒ���͗�����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ꊇ�ݒ���͗��̏��������s���܂��B</br>
        /// <br>             Tag�ɂ��ꂼ��̓��͗����ǂ̈ꊇ�ݒ��\���񋓎q��ݒ肵�܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetAllSettingTypeOnTNEdit()
        {
            // ���Z
            this.tNdtAdd.Tag = AllSettingType.ADD;
            // ��Z
            this.tNdtMul.Tag = AllSettingType.Multiplication;
            // �A��
            this.tNdtSerNum.Tag = AllSettingType.Sequence;
        }

        /// <summary>
        /// �ꊇ�ݒ���͗��ݒ�l����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������ɕێ����Ă���ꊇ�ݒ�œ��͂����e���ڂ̒l�����������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitAllSttngPrevValMap()
        {
            // �C���X�^���X����������Ă��Ȃ��ꍇ�́A�C���X�^���X�̐������s����������Map�̏����������s���܂��B
            if (this.allSttngPrevValMap == null)
            {
                this.allSttngPrevValMap = new Dictionary<AllSettingType, int>(Enum.GetValues(typeof(AllSettingType)).Length - 1);
            }

            foreach (AllSettingType type in Enum.GetValues(typeof(AllSettingType)))
            {
                switch (type)
                {
                    case AllSettingType.Equivalence:
                        // �����������܂���B
                        break;
                    default:
                        // ���l�ȊO��key�F�ꊇ�ݒ�̎��(AllSettingType)�Avalue�F0�ŏ��������܂��B
                        this.allSttngPrevValMap[type] = 0;
                        break;
                }
            }
        }

        #endregion

        #region -- �R���g���[���̏����� --

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�������̓��͓��e�A�y�уO���b�h�̏����N���A���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void Clear()
        {
            // ���o�����̃N���A
            this.InitControl(this.pnlCondtion);
            // �ꊇ�ݒ�̃N���A
            this.InitControl(this.pnlCllctvSttng);

            // �O���b�h�̃N���A
            ((DataView)this.ultrGrid.DataSource).Table.Clear();

            // �X�e�[�^�X�o�[��������Ԃɖ߂��܂��B
            this.InitStatusBar();

            // �X�V�ς݃t���O�ƕҏW�ς݃t���O��off�ɂ��܂��B
            this.isUpdate = false;
            this.isEdit = false;

            // �t�H�[�J�X��擪�ɖ߂��܂��B
            this.tNdtCstmrCdStart.Focus();
        }

        /// <summary>
        /// �R���g���[������������
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : TEdit�ATNedit�AUltraOptionSet�̓��e�����������܂��B</br>
        /// <br>             ��L�ȊO�̃R���g���[���̏ꍇ�A�z���̃R���g���[�����ċA�I�ɌĂяo����</br>
        /// <br>             �q�R���g���[���������Ȃ�܂ŒT���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void InitControl(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TEdit || child is TNedit)
                {
                    // �G�f�B�b�g�֘A�̃R���g���[���́A���͓��e���N���A���܂��B
                    child.Text = String.Empty;
                }
                else if (child is UltraOptionSet)
                {
                    // ���W�I�{�^���͓��l��I�����܂��B
                    UltraOptionSet optSet = child as UltraOptionSet;
                    optSet.FocusedIndex = (int)AllSettingType.Equivalence;
                    optSet.Value = (int)AllSettingType.Equivalence;
                }
                else
                {
                    // ����ȊO�̏ꍇ�́A�ċA�I�ɃR���g���[�����Ăяo���܂��B
                    this.InitControl(child);
                }
            }
        }

        /// <summary>
        /// �X�e�[�^�X�o�[����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[��������Ԃɖ߂��܂��B�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void InitStatusBar()
        {
            // �X�e�[�^�X�o�[����v���O���X�o�[���\���ɂ��܂��B
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].Visible = false;
            // �X�e�[�^�X�o�[�ɕ\�����̃R�[�h�ϊ��X�e�[�^�X���󕶎��ɕύX���܂��B
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = String.Empty;
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Black;
        }

        #endregion

        #region -- �}�X�^�֘A --

        /// <summary>
        /// / ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^��ǂݍ��݁A���_���̂��������ɕێ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SaveSecInfoToMemory()
        {
            // ���_�}�X�^���狒�_�����擾���܂��B
            this.secInfoAcs.ResetSectionInfo();
            if (this.secInfoAcs.SecInfoSetList != null && this.secInfoAcs.SecInfoSetList.Length != 0)
            {
                this.secInfoMap = new Dictionary<string, string>(this.secInfoAcs.SecInfoSetList.Length);
            }
            else
            {
                this.secInfoMap = new Dictionary<string, string>();
            }

            // ���_�����������ɃL���b�V�����܂��B
            foreach (SecInfoSet secInfoSet in this.secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this.secInfoMap[secInfoSet.SectionCode.Trim()] = secInfoSet.SectionGuideNm.Trim();
                }
            }
        }

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h�ɊY�����鋒�_�����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GetSecName(string secCd)
        {
            string cd = secCd.Trim().PadLeft(2, '0');
            return this.secInfoMap.ContainsKey(cd) ? this.secInfoMap[cd] : String.Empty;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��ǂݍ��݁A���Ӑ於�̂��������ɕێ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SaveCustomerInfoToMemory()
        {
            // �X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {                
                // ���Ӑ�}�X�^����f�[�^���擾���܂��B
                CustomerSearchDispWork dispwk = new CustomerSearchDispWork();
                dispwk.EnterpriseCode = this.enterPriseCd;
                dispwk.CustomerCodeStart = 0;
                dispwk.CustomerCodeEnd = 0;
                List<CustomerDispInfo> customerInfoList = new List<CustomerDispInfo>();
                status = this.customerCnvAcs.SearchCustomer(dispwk, customerInfoList);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.customerInfoMap = new Dictionary<string, string>(customerInfoList.Count);
                    customerInfoList.ForEach(delegate(CustomerDispInfo wk)
                    {
                        this.customerInfoMap[String.Format(PMKHN05121UA.cdFormat, wk.CustomerCode)] = wk.CustomerName;
                    });
                }
                else
                {
                    this.customerInfoMap = new Dictionary<string, string>();
                }
            }
            catch
            {
                this.customerInfoMap = new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// ���Ӑ於�擾����
        /// </summary>
        /// <param name="employeeCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�ɊY�����链�Ӑ於���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GetCustomerName(string customerCode)
        {
            // ���Ӑ�R�[�h�������ꍇ�́A�󕶎���ԋp���܂��B
            if (String.IsNullOrEmpty(customerCode))
            {
                return String.Empty;
            }

            // ���Ӑ�R�[�h�����͂���Ă���ꍇ�ŁA�Y������R�[�h������ꍇ�͕R�t�����Ӑ於��
            // �Y������R�[�h�������ꍇ�́A���o�^���Ăяo�����ɕԋp���܂��B
            string cd = customerCode.Trim().PadLeft(this.codeLength, '0');
            return this.customerInfoMap.ContainsKey(cd) ? this.customerInfoMap[cd] : this.noCustomerName;
        }

        #endregion

        #region -- �O���b�h�֘A�̃��\�b�h --

        /// <summary>
        /// �O���b�h�R���g���[������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�R���g���[���̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitGrid()
        {
            // �e�[�u�����쐬���A�O���b�h�Ƀo�C���h���܂��B
            this.ultrGrid.DataSource = new DataView(this.CreateDataTable());
            // �O�ρA�e��ݒ�����������܂��B
            this.InitGridLayout();
            // �J�����̏�����
            this.InitGridColumns();
            // �O���b�h�L�[�}�b�s���O�ݒ菈��(���������AShift + Enter���t�H�[�J�X�J��)
            this.MakeKeyMappingForGrid(this.ultrGrid);
        }

        /// <summary>
        /// �O���b�h�O�Ϗ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̊O�ς̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23/br>
        /// </remarks>
        private void InitGridLayout()
        {
            #region -- �O�ϐݒ� --

            // �O���b�h�S�̂̊O�ϐݒ�
            this.ultrGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.ultrGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.ultrGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.ultrGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.ultrGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            this.ultrGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            this.ultrGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �^�C�g���̊O�ϐݒ�
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �s�Z���N�^�̊O�ϐݒ�
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

            // �A�N�e�B�u�Z���̊O�ϐݒ�
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.White;
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor = Color.Black;

            #endregion

            #region -- ���̑��ݒ� --
            // �s�����I��ݒ�
            this.ultrGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �s�̃T�C�Y�ύX�ݒ�
            this.ultrGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // ��̕����I��ݒ�
            this.ultrGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            // �s�̒ǉ��ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̍폜�ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // ��̈ړ��ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            // ��̌����ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̗��p�ۂ̐ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // IME�̐ݒ�
            this.ultrGrid.ImeMode = ImeMode.Disable;
            // HeaderSort�̐ݒ�
            this.ultrGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // �݂��Ⴂ�̍s�̔w�i�F�̐ݒ�
            this.ultrGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�̕\���ݒ�
            this.ultrGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            // �N���b�N���̃Z���̑I��͈͂̐ݒ�
            this.ultrGrid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            // �X�N���[���o�[�̕\���ݒ�
            this.ultrGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Automatic;
            this.ultrGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToLastItem;
            // �����ʒu(�c)�̐ݒ�
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultrGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultrGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            // �s�Ԃ̌r���F�̐ݒ�
            this.ultrGrid.DisplayLayout.Override.RowAlternateAppearance.BorderColor = Color.FromArgb(1, 68, 208);
            // �ҏW���̐F�̐ݒ�
            this.ultrGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            // �}�E�X�|�C���^�̃J�[�\���`��̐ݒ�
            this.ultrGrid.Cursor = Cursors.Arrow;
            #endregion

            #region -- �O���[�v�w�b�_�̐ݒ� --

            // �w�b�_�̃O���[�v���ݒ�
            this.ultrGrid.DisplayLayout.Bands[0].Groups.Add(this.hdrGrpKeyNo, String.Empty);
            this.ultrGrid.DisplayLayout.Bands[0].Groups.Add(this.hdrGrpKeyBefore, "�ύX�O");
            this.ultrGrid.DisplayLayout.Bands[0].Groups.Add(this.hdrGrpKeyAfter, "�ύX��");
            // �O���[�v�̗�ړ��̐ݒ�
            this.ultrGrid.DisplayLayout.Override.AllowGroupMoving = AllowGroupMoving.NotAllowed;

            #endregion
        }

        /// <summary>
        /// �O���b�h�J��������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�����̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitGridColumns()
        {
            ColumnsCollection columns = this.ultrGrid.DisplayLayout.Bands[0].Columns;
            // No.��
            UltraGridColumn column = columns[GridSettingInfo.COL_NO];
            this.SetColInfo(column, GridSettingInfo.COL_NO_WIDTH, GridSettingInfo.COL_NO_CAP,
                this.hdrGrpKeyNo, Infragistics.Win.HAlign.Right, false, null);
            // ��̌Œ艻
            column.Header.Fixed = true;
            column.Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            column.CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            column.CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            column.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            column.CellAppearance.ForeColor = Color.White;
            column.CellAppearance.ForeColorDisabled = Color.White;
            
            // �_���폜��
            column = columns[GridSettingInfo.COL_LDEL];
            this.SetColInfo(column, 0, GridSettingInfo.COL_LDEL_NM, this.hdrGrpKeyNo,
                Infragistics.Win.HAlign.Right, false, null);
            // �_���폜��͔�\���ɂ��܂�
            column.Hidden = true;

            // �ύX�O���Ӑ�R�[�h
            column = columns[GridSettingInfo.COL_BF_CD];
            this.SetColInfo(column, GridSettingInfo.COL_BF_CD_WIDTH, GridSettingInfo.COL_CD_CAP,
                this.hdrGrpKeyBefore, Infragistics.Win.HAlign.Right, false, "00000000");

            // �ύX�O���Ӑ於��
            column = columns[GridSettingInfo.COL_BF_NM];
            this.SetColInfo(column, GridSettingInfo.COL_BF_NM_WIDTH, GridSettingInfo.COL_NM_CAP,
                this.hdrGrpKeyBefore, Infragistics.Win.HAlign.Left, false, null);

            // �ύX�㓾�Ӑ�R�[�h
            column = columns[GridSettingInfo.COL_AF_CD];
            this.SetColInfo(column, GridSettingInfo.COL_AF_CD_WIDTH, GridSettingInfo.COL_CD_CAP,
                this.hdrGrpKeyAfter, Infragistics.Win.HAlign.Right, true, "00000000;0000000; ");
            column.NullText = String.Empty;
            column.MaxLength = 8;

            // �ύX�㓾�Ӑ於��
            column = columns[GridSettingInfo.COL_AF_NM];
            this.SetColInfo(column, GridSettingInfo.COL_AF_NM_WIDTH, GridSettingInfo.COL_NM_CAP,
                this.hdrGrpKeyAfter, Infragistics.Win.HAlign.Left, false, null);
        }

        /// <summary>
        /// �񏉊�������
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="width">��</param>
        /// <param name="caption">�񌩏o��</param>
        /// <param name="blngGrp">��������O���[�v(�ύX�O/�ύX��)</param>
        /// <param name="hAlign">�e�L�X�g�̐����ʒu</param>
        /// <param name="isAllowEdit">�ҏW�̉�(true:��/false:�s��)</param>
        /// <param name="format">���͒l�̏���(�R�[�h�̂ݎw�肵�܂�)</param>        
        /// <remarks>
        /// <br>Note       : ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetColInfo(UltraGridColumn col, int width, string caption,
            string blnGrp, Infragistics.Win.HAlign hAlign, Boolean isAllowEdit, string format)
        {
            // �񕝂̐ݒ�
            col.Width = width;
            // �񌩏o���̐ݒ�
            col.Header.Caption = caption;
            // �e�L�X�g�̐���/���������̐ݒ�
            col.CellAppearance.TextHAlign = hAlign;
            col.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            // �s�t�B���^�̐ݒ�
            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // ���͒l�̏���
            if (!String.IsNullOrEmpty(format))
            {
                col.Format = format;
            }
            // �Z���̕ҏW�ۂƕ����F�̐ݒ�
            if (!isAllowEdit)
            {
                // �Z���̕ҏW�������Ȃ��ꍇ�́A�Z���̑I��s�ƑI��s���̕����F��ύX���܂��B
                col.CellActivation = Activation.Disabled;
                // �����F�̐ݒ�
                col.CellAppearance.ForeColorDisabled = Color.Black;
            }
            // SortIndicator�̐ݒ�
            col.SortIndicator = SortIndicator.Disabled;
            // �O���[�v�̐ݒ�
            this.ultrGrid.DisplayLayout.Bands[0].Groups[blnGrp].Columns.Add(col);
        }

        /// <summary>
        /// �f�[�^�e�[�u���쐬����
        /// </summary>
        /// <remarks>
        /// <returns>�e�[�u���I�u�W�F�N�g</returns>
        /// <br>Note       : �f�[�^�e�[�u���̍쐬���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable(GridSettingInfo.TBL_NAME);
            // No.��
            table.Columns.Add(GridSettingInfo.COL_NO, typeof(int));
            // �_���폜��
            table.Columns.Add(GridSettingInfo.COL_LDEL, typeof(LogicalDeleteType));
            // �ϊ��O���Ӑ�R�[�h��
            table.Columns.Add(GridSettingInfo.COL_BF_CD, typeof(int));
            // �ϊ��O���Ӑ於�̗�
            table.Columns.Add(GridSettingInfo.COL_BF_NM, typeof(string));
            // �ϊ��㓾�Ӑ�R�[�h��
            table.Columns.Add(GridSettingInfo.COL_AF_CD, typeof(int));
            // �ϊ��㓾�Ӑ於�̗�
            table.Columns.Add(GridSettingInfo.COL_AF_NM, typeof(string));

            return table;
        }

        /// <summary>
        /// �O���b�h�\�����Z�b�g����
        /// </summary>
        /// <param name="employeeList">�S���ҏ��ꗗ</param>
        /// <returns>�e�[�u���I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɕ\������f�[�^���Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetDataToGrid(List<CustomerDispInfo> customerList)
        {
            // �f�[�^�e�[�u���Ƀf�[�^���Z�b�g���܂��B
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            // �s�f�[�^
            DataRow row = null;
            int no = 1;
            customerList.ForEach(delegate(CustomerDispInfo wk) {
                // �s�̒ǉ�
                row = table.NewRow();
                // No.��
                row[GridSettingInfo.COL_NO] = no++;
                // �_���폜��
                LogicalDeleteType delType = (LogicalDeleteType)Enum.ToObject(typeof(LogicalDeleteType), wk.LogicalDelete);
                row[GridSettingInfo.COL_LDEL] = delType;
                // �ϊ��O�̓��Ӑ�R�[�h
                row[GridSettingInfo.COL_BF_CD] = String.Format(PMKHN05121UA.cdFormat, wk.CustomerCode);
                // �ϊ��O�̓��Ӑ於��
                row[GridSettingInfo.COL_BF_NM] = wk.CustomerName;
                table.Rows.Add(row);
                // �_���폜�ς݂ł���΁A�����F��ԂɕύX
                if (delType == LogicalDeleteType.Logical)
                {
                    this.ultrGrid.Rows[no - 2].CellAppearance.ForeColor = Color.Red;
                    this.ultrGrid.Rows[no - 2].CellAppearance.ForeColorDisabled = Color.Red;
                    this.ultrGrid.Rows[no - 2].Cells[GridSettingInfo.COL_NO].Appearance.ForeColorDisabled = Color.White;
                    this.ultrGrid.Rows[no - 2].ToolTipText = MessageMng.INFO_MES_007;
                }
                else
                {
                    this.ultrGrid.Rows[no - 2].CellAppearance.ForeColor = Color.Black;
                    this.ultrGrid.Rows[no - 2].Appearance.ForeColorDisabled = Color.Black;
                    this.ultrGrid.Rows[no - 2].ToolTipText = String.Empty;
                }
            });
        }

        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        /// <remarks>
        /// <br>Note       : �{�^���̏����ݒ�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);
        }

        #endregion

        #region -- ���b�Z�[�W�_�C�A���O�\���֘A --

        /// <summary>
        /// �G���[���b�Z�[�W�_�C�A���O�\������
        /// </summary>
        /// <param name="mes">�\������G���[���b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>Note       : ��ʂɃG���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowError(string mes, int status)
        {
            // �G���[���b�Z�[�W��\�����܂�
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_STOP, MessageBoxButtons.OK, mes, status);
        }

        /// <summary>
        /// �x�����b�Z�[�W�_�C�A���O�\������
        /// </summary>
        /// <param name="mes">�\������G���[���b�Z�[�W</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>Note       : ��ʂɌx�����b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowExclamation(string mes)
        {
            // �x���H
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_EXCLAMATION, MessageBoxButtons.OK, mes, 0);
        }

        /// <summary>
        /// �C���t�H���b�Z�[�W�_�C�A���O�\������
        /// </summary>
        /// <param name="mes">�\������C���t�H���b�Z�[�W</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>Note       : ��ʂɃC���t�H���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowInfo(string mes)
        {
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_INFO, MessageBoxButtons.OKCancel, mes, 0);
        }

        /// <summary>
        /// ���b�Z�[�W�_�C�A���O�\������
        /// </summary>
        /// <param name="errLevel">�\������A�C�R��</param>
        /// <param name="btn">�\������{�^�����</param>        
        /// <param name="mes">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>Note       : ��ʂɃC���t�H���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowMessage(emErrorLevel errLevel, MessageBoxButtons btn, string mes, int status)
        {
            return TMsgDisp.Show(errLevel, this.pgId, mes, status, btn);
        }

        #endregion

        #region -- ���������֘A --

        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void Search()
        {
            try
            {
                // ���o�����ɕs���Ȓl�����͂���Ă��Ȃ����`�F�b�N���܂��B
                if (!this.IsAllowSearchCondition())
                {
                    return;
                }

                // �X�e�[�^�X�o�[��������Ԃɂ��܂��B
                this.InitStatusBar();

                // �v���O���X�_�C�A���O��\�����܂��B
                this.ShowProgressDlg(MessageMng.INFO_MES_010, MessageMng.INFO_MES_011, true);

                // ���o����������DB����f�[�^���擾���܂��B
                List<CustomerDispInfo> searchResult = new List<CustomerDispInfo>();
                // �����X�e�[�^�X�������A���������ʂ�0���ł͂Ȃ��Ƃ��͎擾���ʂ�
                // �O���b�h�ɕ\�����܂��B
                int status = this.customerCnvAcs.SearchCustomer(this.SetSearchCondition(), searchResult);
                this.SetDataToGrid(searchResult);

                // �X�V�ς݃t���O�ƕҏW�ς݃t���O��off�ɂ��܂��B
                this.isUpdate = false;
                this.isEdit = false;

                // �v���O���X�_�C�A���O����܂��B
                this.procDlg.Close();

                // �������ʂ������ꍇ�́A���b�Z�[�W��\�����܂��B
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    this.ShowInfo(MessageMng.INFO_MES_013);
                }
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.ShowError(MessageMng.ERR_MES_011, status);
                }
            }
            catch (Exception ex)
            {
                // �v���O���X�_�C�A���O���I����ɃG���[�_�C�A���O��\�����܂��B
                this.procDlg.Close();
                this.ShowError(String.Format(MessageMng.ERR_MES_004, ex.Message),
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
        }

        /// <summary>
        /// ���o�����Z�b�g����
        /// </summary>
        /// <returns>���o����</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵���������Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerSearchDispWork SetSearchCondition()
        {
            CustomerSearchDispWork dispWork = new CustomerSearchDispWork();
            // ��ƃR�[�h
            dispWork.EnterpriseCode = this.enterPriseCd;
            // ���Ӑ�R�[�h(�J�n)
            dispWork.CustomerCodeStart = Convert.ToInt32(this.tNdtCstmrCdStart.Value);
            // ���Ӑ�R�[�h(�I��)
            dispWork.CustomerCodeEnd = Convert.ToInt32(this.tNdtCstmrCdEnd.Value);

            return dispWork;
        }

        #endregion

        #region -- �`�F�b�N�����֘A --

        /// <summary>
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <returns>���茋��(true:OK/false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ���o�����Ƃ��Ďw�肵���l���������l�ł��邩���`�F�b�N���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool IsAllowSearchCondition()
        {
            // ���͂��ꂽ�l�����l�ł��邩���`�F�b�N���܂��B
            if (this.IsNotNumber(this.tNdtCstmrCdStart) || this.IsNotNumber(this.tNdtCstmrCdEnd))
            {
                return false;
            }            

            // ���o�����ŊJ�n�ƏI���̒l���t�]���Ă��Ȃ������`�F�b�N���܂��B
            if ((this.tNdtCstmrCdStart.GetInt() != 0 && this.tNdtCstmrCdEnd.GetInt() != 0)
                && (this.tNdtCstmrCdStart.GetInt() > this.tNdtCstmrCdEnd.GetInt()))
            {
                this.ShowExclamation(MessageMng.ERR_MES_010);
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���l�`�F�b�N����
        /// </summary>
        /// <param name="tNEdit"></param>
        /// <returns>���茋��(true:�񐔒l/false:���l)</returns>
        /// <remarks>
        /// <br>Note       : ���o�����w�肵���l���񐔒l�ł��邩���`�F�b�N���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool IsNotNumber(TNedit tNEdit)
        {
            // ���͒l������ꍇ�̂݃`�F�b�N���܂��B
            if (tNEdit.GetInt() == 0 && tNEdit.Text.Length != 0 && 
                !Regex.IsMatch(tNEdit.Text, this.regPttrnNum))
            {
                tNEdit.Focus();
                this.ShowExclamation(MessageMng.ERR_MES_016);
                return true;
            }

            return false;
        }

        /// <summary>
        /// �ύX��q�ɃR�[�h���菈��(0�`�F�b�N)
        /// </summary>
        /// <param name="cell">�Z���f�[�^</param>
        /// <returns>true:0/false:��0</returns>
        /// <remarks>
        /// <br>Note       : �ϊ���̒l��0�ł��邩�ۂ��𔻒肵�܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10<</br>
        /// </remarks>
        private bool IsCodeZero(UltraGridCell cell)
        {
            return Convert.ToInt32(cell.Text.Trim()) == 0 ? true : false;
        }

        /// <summary>
        /// �ύX�O�A�ύX��q�ɃR�[�h���菈��(����l�`�F�b�N)
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <returns>true:����l/false:�񓯈�l</returns>
        /// <remarks>
        /// <br>Note       : �ύX�O�ƕύX��̃R�[�h������ł��邩�ǂ������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private bool IsBfCdAndAfCdSameValue(UltraGridRow row)
        {
            return Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value) ==
                Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) ? true : false;
        }

        #endregion

        #region -- �R�[�h�ϊ��֘A --

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɒS���҃R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ConvertCustomerCode()
        {
            try
            {
                // ���ɃR���o�[�g�ς݂����`�F�b�N����
                if (this.isUpdate)
                {
                    this.ShowExclamation(MessageMng.INFO_MES_006);
                    return;
                }

                // �R���o�[�g���������s����O�ɃR���o�[�g������u�����Ȃ����ۂ������[�U��
                // �₢���킹�܂��B
                if (this.ShowInfo(MessageMng.INFO_MES_004) == DialogResult.Cancel)
                {
                    return;
                }

                // �R���o�[�g�Ώۃf�[�^���L�邩�ǂ������`�F�b�N���܂��B
                if (!this.HasConvertData())
                {
                    this.ShowExclamation(MessageMng.ERR_MES_009);
                    return;
                }

                // ���O�̕ۑ���f�B���N�g�����쐬���܂��B
                this.CreateLogSaveDir();

                // ���͒l�`�F�b�N
                this.isCheckOK = this.IsAllowData();
                if (this.isCheckOK)
                {
                    // �v���O���X�_�C�A���O��\�����܂��B
                    this.ShowProgressDlg(MessageMng.INFO_MES_008, MessageMng.INFO_MES_009, false);
                    // �R�[�h�ϊ��������o�b�N�O���E���h�Ŏ��s���܂��B
                    this.bgWrkr.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(String.Format(MessageMng.ERR_MES_005, ex.Message), 
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
        }

        /// <summary>
        /// �R���o�[�g�ΏۃR�[�h���݃`�F�b�N����
        /// </summary>
        /// <returns>true:�ΏۃR�[�h�L/false:�ΏۃR�[�h����</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���ɃR���o�[�g�ΏۂƂȂ�q�ɃR�[�h�����݂��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool HasConvertData()
        {
            // �O���b�h�ɃR���o�[�g�ΏۂƂȂ�f�[�^�����݂��邩�m�F���܂��B
            if (this.ultrGrid.Rows.Count != 0)
            {
                // �O���b�h�Ƀf�[�^���L��ꍇ�A�ϊ���̓��Ӑ�R�[�h��ɓ��͒l�����邩�ǂ������m�F���܂��B
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    // ��ł͂Ȃ��Z���A���͕ύX�O�ƕύX�オ��v���Ȃ��Z���𔭌������珈���𔲂��܂��B
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()) &&
                        !this.IsCodeZero(row.Cells[GridSettingInfo.COL_AF_CD]) && !this.IsBfCdAndAfCdSameValue(row))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// ���͒l�`�F�b�N����
        /// </summary>
        /// <returns>���茋��(true:OK/false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵���R�[�h�ϊ��̓��͒l�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool IsAllowData()
        {
            // �`�F�b�N�ς݂̃R�[�h��ۑ�����ϐ�
            IDictionary<string, CustomerInputData> checkCodeMap = new Dictionary<string, CustomerInputData>();

            // ���͂����ϊ���R�[�h��4���ȓ��A���͓��͂����l���ŏd�������l���������`�F�b�N���܂��B
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // �Z������R�[�h���擾���܂��B
                string code = String.Format(PMKHN05121UA.cdFormat, row.Cells[GridSettingInfo.COL_AF_CD].Value);
                // �����`�F�b�N
                if (code.Length > this.codeLength)
                {
                    this.SetFocusToErrorCell(row, String.Format(MessageMng.ERR_MES_007, this.codeLength));
                    return false;
                }

                // �ύX�㓾�Ӑ�R�[�h�������͂̏ꍇ�A�ύX�O�̓��Ӑ�R�[�h���d�����Ȃ����`�F�b�N���܂��B
                if (String.IsNullOrEmpty(code) || Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) == 0)
                {
                    code = String.Format(PMKHN05121UA.cdFormat, Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value));
                }

                // �d���`�F�b�N
                if (checkCodeMap.ContainsKey(code))
                {
                    // �d�����Ă����ꍇ�́A���b�Z�[�W��\�����ď����𒆎~
                    this.SetFocusToErrorCell(row, MessageMng.ERR_MES_008);
                    return false;
                }
                else
                {
                    // �`�F�b�N�ς݂̃R�[�h��ۑ����܂�
                    CustomerInputData inputData = new CustomerInputData();
                    inputData.BfCustomerCode = String.Format(PMKHN05121UA.cdFormat, Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value));
                    inputData.AfCustomerCode = code;
                    inputData.RowIndex = row.Index;
                    checkCodeMap[code] = inputData;

                    // �`�F�b�N�ς݃R�[�h�}�b�v�ɕϊ��O�̃R�[�h�����邩�𔻒肵�܂��B
                    if (inputData.IsEdit() && checkCodeMap.ContainsKey(inputData.BfCustomerCode))
                    {
                        // �`�F�b�N�ς݃R�[�h�}�b�v�ɕϊ��O�R�[�h���������ꍇ�́A�`�F�b�N�ς݃R�[�h�Ƃ�
                        // �����ł���ׁA�R�[�h�̕ϊ������������Ƃ������t���O��on�ɂ��܂��B
                        checkCodeMap[inputData.BfCustomerCode].SetOtherCodeChange(inputData.BfCustomerCode, inputData.AfCustomerCode);
                        checkCodeMap[code].SetOtherCodeChange(checkCodeMap[inputData.BfCustomerCode].BfCustomerCode,
                            checkCodeMap[inputData.BfCustomerCode].AfCustomerCode);
                    }
                }
            }

            // �O���b�h�̏�񂪓��Ӑ�}�X�^�̃f�[�^�����ƈ�v���Ȃ��ꍇ�́A���o�����ŕ\��������
            // �i���Ă���ׁA�\������Ă��Ȃ��R�[�h�ɂ��Ă��d�����Ȃ������肵�܂��B
            // �܂��A��x�X�V�����ꍇ�����l�Ƀ`�F�b�N���܂��B
            if ((this.isUpdate) || (this.ultrGrid.Rows.Count != this.customerInfoMap.Count))
            {
                foreach (string checkedCode in checkCodeMap.Keys)
                {
                    int index = checkCodeMap[checkedCode].RowIndex;
                    if (checkCodeMap[checkedCode].IsEdit() && !checkCodeMap[checkedCode].IsOtherCodeChange
                        && this.customerInfoMap.ContainsKey(checkedCode))
                    {
                        this.SetFocusToErrorCell(this.ultrGrid.Rows[index], MessageMng.ERR_MES_008);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ���O�ۑ���f�B���N�g���쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O��ۑ�����f�B���N�g�������݂��Ȃ��ꍇ�A�f�B���N�g���̍쐬���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void CreateLogSaveDir()
        {
            // ���O�ۑ��f�B���N�g�������݂��邩���m�F���A�����ꍇ�̓f�B���N�g�����쐬���܂��B
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05121UA.LOG_DIR_PATH);
            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(dirInfo.FullName);
            }
        }

        #endregion

        #region -- �X���b�h�֘A --

        /// <summary>
        /// �X�e�[�^�X�o�[����������
        /// </summary>
        /// <param name="cnvTrgTblCount">�R�[�h�ϊ��Ώۃe�[�u���̌���</param>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�������s���O���ɃX�e�[�^�X�o�[�̏��������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitStatusBar(int cnvTrgTblCount)
        {
            // ��ʂ̕`����ꎞ��~���܂��B
            this.SuspendLayout();

            // �v���O���X�o�[�����������܂��B
            UltraStatusPanel pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS];
            // �v���O���X�o�[��\�����܂��B
            pnl.Visible = true;
            // �v���O���X�o�[�̍ŏ��l�ƍő�l��ݒ肵�܂��B
            pnl.ProgressBarInfo.Minimum = 0;
            pnl.ProgressBarInfo.Maximum = cnvTrgTblCount;
            pnl.ProgressBarInfo.Value = 0;
            pnl.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;

            // �X�e�[�^�X�\���̈�����������܂��B
            pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS];
            pnl.Text = MessageMng.INFO_MES_001;
            pnl.Appearance.ForeColor = Color.Black;

            // ��ʂ̕`����ĊJ���܂��B
            this.ResumeLayout(false);
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�X�V����
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���X�V���邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void UpdateStatusBar(string mes)
        {
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = mes;
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃf�[�^�擾����
        /// </summary>
        /// <returns>�R�[�h�ϊ��Ώۂ̃f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ����̑ΏۂƂȂ��Ă���f�[�^���O���b�h����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private IList<CustomerConvertData> GetConvertData()
        {
            // �R�[�h�ϊ��Ώۂ̃f�[�^���O���b�h����擾���܂��B
            IList<CustomerConvertData> cnvDataList = new List<CustomerConvertData>(this.ultrGrid.Rows.Count);
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // �ύX�㓾�Ӑ�R�[�h�񂩂�l���擾���A�l�������ꍇ�͎��̍s��
                UltraGridCell afCell = row.Cells[GridSettingInfo.COL_AF_CD];
                if (String.IsNullOrEmpty(afCell.Text.Trim()) || 
                    this.IsCodeZero(afCell) || this.IsBfCdAndAfCdSameValue(row))
                {
                    continue;
                }

                // �X�V������ۑ����܂��B
                CustomerConvertData cnvData = new CustomerConvertData();
                // �ύX�O���Ӑ�R�[�h
                cnvData.BfCustomerCd = Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value);
                // �ύX�㓾�Ӑ�R�[�h
                cnvData.AfCustomerCd = Convert.ToInt32(afCell.Value);
                cnvDataList.Add(cnvData);
            }

            return cnvDataList;
        }

        #region -- ���O�֘A --

        /// <summary>
        /// ���O�t�@�C���p�X�쐬����
        /// </summary>
        /// <returns>���O�t�@�C���̐�΃p�X</returns>
        /// <remarks>
        /// <br>Note       : ���O�t�@�C���̐�΃p�X���쐬���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string CreateLogFilePath()
        {
            // �f�B���N�g�������쐬
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05121UA.LOG_DIR_PATH);
            // ���O�t�@�C�������쐬
            string fileName = String.Format(PMKHN05121UA.LOG_FILE_NAME, 
                DateTime.Now.ToString(PMKHN05121UA.LOG_FORMAT_DATE));

            return Path.Combine(dirInfo.FullName, fileName);
        }

        /// <summary>
        /// ���O�o�͌`����������
        /// </summary>
        /// <param name="format">���O�ɏo�͂���t�H�[�}�b�g</param>
        /// <param name="prms">�o�͂��������e</param>
        /// <returns>���O�̃t�H�[�}�b�g�ɐ��`����������</returns>
        /// <remarks>
        /// <br>Note       : �����Ŏw�肳�ꂽ�f�[�^�����O�̏o�͌`���ɕϊ����܂��B</br>
        /// <br>             ���O�t�H�[�}�b�g�̑�1�����͓��t�ɂȂ��Ă��܂����A���t�͖{���\�b�h����</br>
        /// <br>             �擾����ׁAprms�ɓ��t���w�肷��K�v�͂���܂���B</br>
        /// <br>             �܂��A���O�t�H�[�}�b�g�ɑ�2�����ȍ~�������ꍇ�́Anew String[0]��</br>
        /// <br>             prms�̈����Ɏw�肵�Ă��������B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private string GenerateLogFormat(string format, string[] prms)
        {
            List<string> prmList = new List<string>();
            prmList.Add(DateTime.Now.ToString(PMKHN05121UA.DATE_FORMAT));
            foreach (string prm in prms)
            {
                prmList.Add(prm);
            }

            return String.Format(format, prmList.ToArray());
        }

        #endregion

        #endregion

        #region -- ���̑� --

        /// <summary>
        /// �v���O���X�_�C�A���O�\������
        /// </summary>
        /// <param name="mess">���b�Z�[�W</param>
        /// <param name="title">�_�C�A���O�^�C�g��</param>
        /// <param name="canCancel">�L�����Z���̉�(true:�L�����Z���\/false:�L�����Z���s��)</param>
        /// <remarks>
        /// <br>Note       : �v���O���X�_�C�A���O��\�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void ShowProgressDlg(string title, string mess, bool canCancel)
        {
            // �v���O���X�_�C�A���O��\�����܂�
            if (this.procDlg == null)
            {
                this.procDlg = new SFCMN00299CA();
            }

            // �_�C�A���O�̃^�C�g����ݒ肵�܂��B
            this.procDlg.Title = title;
            // �_�C�A���O�ɕ\�����郁�b�Z�[�W��ݒ肵�܂��B
            this.procDlg.Message = mess;
            // �L�����Z���{�^���̗L��
            this.procDlg.DispCancelButton = canCancel;

            // �v���O���X�_�C�A���O��\�����܂��B
            this.procDlg.Show(this);
        }

        /// <summary>
        /// �R�[�h�[�����ߏ���
        /// </summary>
        /// <param name="trgVal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �R�[�h���u0001�v�̂悤�Ƀ[�����߂��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string ZeroPadding(string trgVal) 
        {
            return String.IsNullOrEmpty(trgVal) ? String.Empty :
                trgVal.Trim().PadLeft(this.codeLength, '0');
        }

        /// <summary>
        /// ���̃Z�b�g����
        /// </summary>
        /// <param name="tNEdit">�R�[�h���͗�</param>
        /// <param name="tEdit">���̗�</param>
        /// <remarks>
        /// <br>Note       : �R�[�h���͗��œ��͂����R�[�h�ɑΉ����閼�̂𖼏̗��ɃZ�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void SetName(TNedit tNEdit, TEdit tEdit)
        {
            string customerCd = tNEdit.Text.Trim();
            string customerNm = this.GetCustomerName(customerCd);
            tEdit.Text = customerNm == this.noCustomerName ? String.Empty : customerNm;
            if (!String.IsNullOrEmpty(customerCd))
            {
                tNEdit.Text = tNEdit.Text.Trim().PadLeft(this.codeLength, '0');
            }
        }

        #region -- �t�H�[�J�X�Z�b�g�֘A --

        /// <summary>
        /// �G���[�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <param name="errMes">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���̓`�F�b�N�ŃG���[�����������Z���Ƀt�H�[�J�X���Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetFocusToErrorCell(UltraGridRow row, string errMs)
        {
            this.ultrGrid.Focus();
            row.Cells[GridSettingInfo.COL_AF_CD].Activate();
            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            this.ShowExclamation(errMs);
        }

        /// <summary>
        /// �t�H�[�J�X�J�ڎ��̃A�N�e�B�u�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="rowIndex">�A�N�e�B�u�ɂ������s�ԍ�</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�J�ڎ��ŃO���b�h���A�N�e�B�u�R���g���[���ɂȂ����ꍇ�A�w�肵���s�ԍ���</br>
        /// <br>             �ύX��R�[�h��̃Z�����A�N�e�B�u�ɂ��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void SetFocusEditCellFromNoUltraGrid(int rowIndex, ChangeFocusEventArgs e)
        {
            // ���̃R���g���[����UltraGrid�̎��̂ݎ��{���܂��B
            if (e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
            {
                e.NextCtrl = null;
                // UltraGrid�Ƀt�H�[�J�X�𓖂āArowIndex�Ŏw�肵���ύX��Z�����A�N�e�B�u�ɂ��܂��B
                this.ultrGrid.Focus();
                this.ultrGrid.Rows[rowIndex].Cells[GridSettingInfo.COL_AF_CD].Activate();
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// �O���b�h���̃t�H�[�J�X�J�ڎ��̃A�N�e�B�u�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="cmpRowIndex">��r�������s�̍s�ԍ�(�擪�̏ꍇ��0�A�����̏ꍇ�͍s��-1)</param>
        /// <param name="nextCtrl">���ɑJ�ڂ���R���g���[��(�q�ɃK�C�hor�ꊇ�ݒ�{�^��)</param>
        /// <param name="gridAction">�O���b�h�Ŏ��s�������A�N�V����</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���̃t�H�[�J�X�J�ڎ��Ɏ��̃Z�����A�N�e�B�u�ɂ��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetFocusEditCellInUltraGrid(int cmpRowIndex, Control nextCtrl,
            UltraGridAction gridAction, ChangeFocusEventArgs e)
        {
            // NextCtrl��null���Z�b�g���܂��B
            e.NextCtrl = null;
            if (this.ultrGrid.ActiveCell.Row.Index == cmpRowIndex)
            {
                // NextCtrl�Ɏ��Ɉړ��������R���g���[�����Z�b�g���܂��B
                e.NextCtrl = nextCtrl;
            }
            else
            {
                // ���̃Z���Ɉړ����܂��B
                this.ultrGrid.PerformAction(gridAction);
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// �O���b�h���̃t�H�[�J�X�J�ڎ��̃A�N�e�B�u�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="cmpRowIndex">��r�������s�̍s�ԍ�(�擪�̏ꍇ��0�A�����̏ꍇ�͍s��-1)</param>
        /// <param name="nextCtrl">���ɑJ�ڂ���R���g���[��</param>
        /// <param name="gridAction">�O���b�h�Ŏ��s�������A�N�V����</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���̃t�H�[�J�X�J�ڎ��Ɏ��̃Z���A���̓R���g���[�����A�N�e�B�u�ɂ��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetFocusEditCellOnKeyDown(int cmpRowIndex, Control nextCtrl,
            UltraGridAction gridAction, KeyEventArgs e)
        {
            if (this.ultrGrid.ActiveCell.Row.Index == cmpRowIndex)
            {
                // ���̃R���g���[���Ƀt�H�[�J�X���Z�b�g���܂��B
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                }
            }
            else
            {
                // ���̃Z�����A�N�e�B�u�Z���ɂ��܂��B
                this.ultrGrid.PerformAction(gridAction);
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

            e.Handled = true;
        }

        #endregion

        #endregion

        #endregion

        #region -- Event --

        #region -- UltraExpandableGroupBox�֘A�̃C�x���g --

        /// <summary>
        /// ���o�����R���g���[���̓W�J�E�k���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̓W�J�E�k�������Ƃ��ɃR���g���[���̃T�C�Y��ύX���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrEgbCllctvSttng_ExpandedStateChanged(object sender, EventArgs e)
        {
            // �C�x���g�\�[�X��UltraExpandableGroupBox�ɕϊ����܂��B
            UltraExpandableGroupBox edgGrpBox = sender as UltraExpandableGroupBox;
            // UltraExpandableGroupBox�̎��̂ݏ��������{���܂��B
            if (edgGrpBox != null)
            {
                // �W�J�E�k���ɉ����ăp�l���̃T�C�Y��ύX���܂��B
                Size pnlSize = new Size();
                pnlSize.Width = edgGrpBox.Parent.Size.Width;
                pnlSize.Height = edgGrpBox.Expanded ? 
                    (this.egbGrpBoxHeighMap[(EgbGrpBoxType)edgGrpBox.Tag]) : this.egbGrpBoxCntrctSize;
                edgGrpBox.Parent.Size = pnlSize;
            }
        }

        #endregion

        #region -- �X���b�h�֘A --

        /// <summary>
        /// �o�b�N�O�����h�̃C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �o�b�N�O���E���h�ŏ��������s����Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void bgWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // XML����R�[�h�ϊ��̑ΏۂƂȂ�e�[�u�����擾���܂��B
                IDictionary<string, TargetTableListResult> trgTblMap = new Dictionary<string, TargetTableListResult>();
                status = this.customerCnvAcs.GetConvertTableList(trgTblMap);
                // ����ȊO�̏ꍇ�͑Ώۃf�[�^���i�[����XML���s���ł���ׁA�����𒆎~���܂��B
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (status)
                    {
                        case PMKHN05121UA.ILLEGAL_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_014;
                            break;
                        case PMKHN05121UA.NO_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_013;
                            break;
                        case PMKHN05121UA.NO_FILE:
                            this.cnvErrMes = MessageMng.ERR_MES_015;
                            break;
                        default:
                            this.cnvErrMes = String.Empty;
                            break;
                    }
                    e.Cancel = true;
                    return;
                }

                // �R�[�h�ϊ��Ώۂ̃f�[�^���O���b�h����擾���܂��B
                IList<CustomerConvertData> cnvDataList = this.GetConvertData();

                // �X�e�[�^�X�o�[�����������܂��B
                this.Invoke(new InitStatusBarDelegate(this.InitStatusBar), trgTblMap.Count);

                // �e�[�u���P�ʂŃR�[�h�ϊ������{���܂��B
                // �X�e�[�^�X�o�[�̃X�e�[�^�X�̈�̏���������\�����邽�߂̃J�E���^
                int index = 0;
                // 1�e�[�u�����̃R�[�h�ϊ����s�������R�[�h����
                int prcssngCnt;
                // �R�[�h�ϊ����s�������R�[�h�̑�����(�S�e�[�u����)
                int ttlPrcssngCnt = 0;
                // �R���o�[�g�Ώۂ̃e�[�u������
                int maxTbl = trgTblMap.Count;
                // �������Ԃ⏈���������R�[�h�̌������L�^����ׁA�����������e�����O�ɏo�͂��܂��B
                using (FileStream fs = new FileStream(this.CreateLogFilePath(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //���엚�����O�ɓ��l�̓��e���o�͂��Ă����܂��B
                        OperationHistoryLog opLog = new OperationHistoryLog();
                        string pgid = "PMKHN05120U";
                        string pgnm = "�����R�[�h�ϊ�";

                        // ���������Ԃ��v������Stopwatch
                        Stopwatch totalProcessingTime = new Stopwatch();
                        // �ʂ̃e�[�u���̏������Ԃ��v������Stopwatch
                        Stopwatch processingTime = new Stopwatch();

                        sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_START, new string[0]));
                        opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                            this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_START, new string[0]), "");

                        // ���������Ԃ̌v�����J�n���܂��B
                        totalProcessingTime.Start();
                        foreach (string table in trgTblMap.Keys)
                        {
                            prcssngCnt = 0;
                            // �R�[�h�ϊ��O�ɃX�e�[�^�X�o�[���X�V���܂��B
                            this.Invoke(new UpdateStatusBarDelegate(this.UpdateStatusBar),
                                String.Format(MessageMng.INFO_MES_005, trgTblMap[table].TargetTableName, index, maxTbl));
                            // �ʃe�[�u���̏������Ԃ��v�����܂��B
                            processingTime.Start();

                            // �R�[�h�ϊ����������s���܂��B
                            status = this.customerCnvAcs.ConvertCustomer(trgTblMap[table], cnvDataList, this.enterPriseCd, ref prcssngCnt);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_ERROR, new string[] { trgTblMap[table].TargetTableName }));
                                opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                    this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_ERROR, new string[] { trgTblMap[table].TargetTableName }), "");
                                e.Cancel = true;
                                break;
                            }

                            processingTime.Stop();
                            ttlPrcssngCnt += prcssngCnt;
                            // �X�̏��������A�y�я������Ԃ����O�ɏo�͂��܂��B
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] {trgTblMap[table].TargetTableName, prcssngCnt.ToString(),
                                    new DateTime(0).Add(processingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME) }));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] {trgTblMap[table].TargetTableName, prcssngCnt.ToString(),
                                    new DateTime(0).Add(processingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME) }), "");

                            // �ϊ�������ɃX�e�[�^�X�o�[���X�V���܂��B
                            this.bgWrkr.ReportProgress(++index,
                                String.Format(MessageMng.INFO_MES_005, trgTblMap[table].TargetTableName, index, maxTbl));

                            // �ʃe�[�u���̏������Ԃ��v������Stopwatch�����Z�b�g���܂��B
                            processingTime.Reset();
                        }
                        totalProcessingTime.Stop();
                        // �����������Ƒ��������Ԃ����O�ɏo�͂��܂��B
                        if (!e.Cancel)
                        {
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME),
                                ttlPrcssngCnt.ToString() }));
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_END, new string[0]));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME),
                                ttlPrcssngCnt.ToString() }), "");
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_END, new string[0]), "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // �G���[�̏ꍇ�́A��O���b�Z�[�W���t�B�[���h�ϐ��ɕۑ����A�C�x���g���L�����Z�����܂��B
                this.cnvErrMes = ex.Message;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ReportProgress�C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ReportProgress���\�b�h���R�[���������ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void bgWrkr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value = e.ProgressPercentage;
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = e.UserState.ToString();
        }

        /// <summary>
        /// �o�b�N�O���E���h�����I�����̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �o�b�N�O���E���h���������������Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>   
        private void bgWrkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // ������������t���O
            bool isSuccess = false;
            try
            {
                // �v���O���X�_�C�A���O���I�����܂��B
                this.procDlg.Close();
                if (e.Cancelled)
                {
                    // �X�e�[�^�X�o�[���X�V
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_003;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Red;
                    // �G���[���b�Z�[�W��\��
                    string errMs = String.IsNullOrEmpty(this.cnvErrMes) ? MessageMng.ERR_MES_006 : this.cnvErrMes;
                    this.ShowError(errMs, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    this.cnvErrMes = String.Empty;
                }
                else
                {
                    // �X�e�[�^�X�o�[���X�V
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value =
                        this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Maximum;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_002;

                    // �������̓������Ɋi�[���Ă���d���`�F�b�N�ɗp����}�b�v�f�[�^���ŐV�����܂��B
                    this.SaveCustomerInfoToMemory();

                    // ������������t���O��on�ɂ��܂��B
                    isSuccess = true;

                    // �X�V�ς݃t���O��on�ɂ��܂��B
                    this.isUpdate = true;
                    // �ҏW�ς݃t���O��off�ɂ��܂��B
                    this.isEdit = false;
                }
            }
            catch (Exception ex)
            {
                // �v���O���X�_�C�A���O���I�����܂��B
                this.procDlg.Close();
                this.ShowError(String.Format(MessageMng.ERR_MES_005, ex.Message), (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            finally
            {
                // �����������́A�o�^�����_�C�A���O��\�����܂��B
                if (isSuccess)
                {
                    // �o�^�����_�C�A���O��\�����܂��B
                    using (SaveCompletionDialog dlg = new SaveCompletionDialog())
                    {
                        dlg.ShowDialog(2);
                    }
                }

                // FormClosing�C�x���g����R�[�����ꂽ�ꍇ�́A�t�H�[������܂��B
                if (isSuccess && this.isCallFormCloseingEvent)
                {
                    // �I�����͐e�t�H�[��������܂��B
                    ((Form)this.Parent).Close();
                }
            }
        }

        #endregion

        #region -- �O���b�h�֘A --

        /// <summary>
        /// �Z���ҏW���[�h�I���O�̃C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Z���ҏW���[�h���I������O�ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            UltraGrid grid = sender as UltraGrid;
            // �Z���̏�Ԃ�null�̏ꍇ�́A�㑱�̏��������s���܂���B
            if (grid.ActiveCell.Value == null) 
            {
                return;
            }

            // ���l�����͂��ꂽ�ꍇ�́A�[���p�e�B���O���܂��B
            // �񐔒l�̏ꍇ�́Anull���Z�b�g���܂��B
            string inputData = grid.ActiveCell.Text.Trim();
            int str2IntNum;
            if (Int32.TryParse(inputData, out str2IntNum))
            {
                grid.ActiveCell.Value = grid.ActiveCell.Text.PadLeft(this.codeLength, '0');
            }
            else
            {
                grid.ActiveCell.Value = 0;
            }
        }

        /// <summary>
        /// �Z���V�K���͎�t��̃C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Z�����V�K���͂��󂯕t������ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGridRow row = e.Cell.Row as UltraGridRow;
            // �ϊ���̒l���󕶎��A���͔񐔒l�ł���Γ��Ӑ於���󔒂ɂ��܂��B
            if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()))
            {
                row.Cells[GridSettingInfo.COL_AF_NM].Value = String.Empty;
            }
            else
            {
                // ���͂��ꂽ�ꍇ�A�Y�����链�Ӑ於���Z�b�g���܂��B���݂��Ȃ��ꍇ�́A���o�^��\�����܂��B
                row.Cells[GridSettingInfo.COL_AF_NM].Value = this.GetCustomerName(
                    row.Cells[GridSettingInfo.COL_AF_CD].Text);
                // �ҏW�ς݃t���O��on�ɂ��܂��B
                this.isEdit = true;
            }
        }

        /// <summary>
        /// Grid�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: Grid�A�N�V����������ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer	: 30365 �{��</br>
        /// <br>Date		: 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case UltraGridAction.ActivateCell:
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.PrevCell:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:
                    {
                        // �A�N�e�B�u�ȃZ�������邩�H���͕ҏW�\�Z�����H
                        if ((this.ultrGrid.ActiveCell != null) &&
                            (this.ultrGrid.ActiveCell.Column.CellActivation == Activation.AllowEdit) &&
                            (this.ultrGrid.ActiveCell.Activation == Activation.AllowEdit))
                        {
                            // �A�N�e�B�u�Z���̃X�^�C�����擾
                            switch (this.ultrGrid.ActiveCell.StyleResolved)
                            {
                                // �G�f�B�b�g�n�X�^�C��
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                    {
                                        // �ҏW���[�h�ɂ��邩�H
                                        if (this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode))
                                        {
                                            if (!(this.ultrGrid.ActiveCell.Value is DBNull))
                                            {
                                                // �S�I����Ԃɂ���B
                                                this.ultrGrid.ActiveCell.SelStart = 0;
                                                this.ultrGrid.ActiveCell.SelLength = this.ultrGrid.ActiveCell.Text.Length;
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                            }
                        }
                    }
                    break;
            }
        }

        #endregion

        #region -- �t�H�[�J�X����֘A --

        /// <summary>
        /// �t�H�[�J�XChange�C�x���g(tArrwKyCntrl, tRtKyCntrl)
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�XChange�C�x���g�����������Ƃ��Ƀt�H�[�J�X�̐�����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10<</br>
        /// </remarks>
        private void tArrwKyCntrl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ���O�A����̃R���g���[�������݂��Ȃ��ꍇ�́A�����������܂���
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.ultrGrid)
            {
                if (this.ultrGrid.ActiveCell != null)
                {
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        if (!e.ShiftKey)
                        {
                            // ���̃Z�����A�N�e�B�u�Z���ɂ��܂��B
                            this.SetFocusEditCellInUltraGrid(this.ultrGrid.Rows.Count - 1,
                                this.tNdtCstmrCdStart, UltraGridAction.NextCell, e);
                        }
                        else
                        {
                            // �O�̃Z�����A�N�e�B�u�Z���ɂ��܂��B
                            this.SetFocusEditCellInUltraGrid(this.firstRow, this.ultrBtnSttng,
                                UltraGridAction.PrevCell, e);
                        }
                    }
                }
                else if (this.ultrGrid.ActiveRow != null)
                {
                    // �Z�����A�N�e�B�u�ł͂Ȃ��ꍇ
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = null;
                        // 1�s�ڂ̕ϊ���R�[�h���A�N�e�B�u�ɂ��܂��B
                        this.ultrGrid.ActiveRow.Cells[GridSettingInfo.COL_AF_CD].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                else
                {
                    // ���l���ړ��͗��ł���΁A�S���҃R�[�h(�J�n)���͗��Ƀt�H�[�J�X���Z�b�g
                    if (e.NextCtrl is TNedit)
                    {
                        this.tNdtCstmrCdStart.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtCstmrCdStart)
            {
                // �S���҃R�[�h���擾���A�l������ꍇ�͒S���Җ����Z�b�g���܂�
                this.SetName(this.tNdtCstmrCdStart, this.tEdtCstmrNmStart);

                // �t�H�[�J�X�𐧌䂵�܂�
                if (e.ShiftKey && e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
                {
                    e.NextCtrl = null;
                    this.ultrGrid.Focus();
                    this.ultrGrid.Rows[this.ultrGrid.Rows.Count - 1].Cells[GridSettingInfo.COL_AF_CD].Activate();
                    this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (e.ShiftKey && (e.Key == Keys.Return || e.Key == Keys.Tab) &&
                        this.ultrGrid.Rows.Count == 0)
                    {
                        e.NextCtrl = null;
                        this.ultrBtnSttng.Focus();
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        this.ultrRbtnCllctvSttng.FocusedIndex = this.ultrRbtnCllctvSttng.CheckedIndex;
                        this.ultrRbtnCllctvSttng.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtCstmrCdEnd)
            {
                // �S���҃R�[�h���擾���A�l������ꍇ�͒S���Җ����Z�b�g���܂�
                this.SetName(this.tNdtCstmrCdEnd, this.tEdtCstmrNmEnd);
                if (!e.ShiftKey && (e.Key == Keys.Return || e.Key == Keys.Tab))
                {
                    // ���W�I�{�^���̃t�H�[�J�X�����݃`�F�b�N���Ă��鍀�ڂɕύX���܂��B
                    this.ultrRbtnCllctvSttng.FocusedIndex = this.ultrRbtnCllctvSttng.CheckedIndex;
                }
            }
            else if (e.PrevCtrl == this.ultrBtnSttng)
            {
                // �O���b�h�̐擪�s���A�N�e�B�u�ȃZ���ɂ��܂��B
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    this.tNdtCstmrCdEnd.Focus();
                }
                else if (this.ultrGrid.Rows.Count != 0)
                {
                    this.SetFocusEditCellFromNoUltraGrid(this.firstRow, e);
                }
                else if (!e.ShiftKey)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        this.tNdtCstmrCdStart.Focus();
                    }
                    else if (e.Key == Keys.Left)
                    {
                        this.tNdtSerNum.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtCstmrCdStart)
            {
                // �O���b�h�̍ŏI�s���A�N�e�B�u�ȃZ���ɂ��܂��B
                this.SetFocusEditCellFromNoUltraGrid(this.ultrGrid.Rows.Count - 1, e);
            }
            else if (e.PrevCtrl == this.ultrRbtnCllctvSttng)
            {
                if (!e.ShiftKey)
                {
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tNdtAdd;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        switch (this.ultrRbtnCllctvSttng.FocusedIndex)
                        {
                            case 0:
                            case 1:
                                e.NextCtrl = this.tNdtAdd;
                                break;
                            case 2:
                                e.NextCtrl = this.tNdtMul;
                                break;
                            case 3:
                                e.NextCtrl = this.tNdtSerNum;
                                break;
                            default:
                                // �����Ȃ�
                                break;
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        if (this.ultrGrid.Rows.Count != 0)
                        {
                            this.ultrGrid.Focus();
                            this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_AF_CD].Activate();
                            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtAdd)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.ADD);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Down)
                    {
                        this.tNdtMul.Focus();
                    }
                    else
                    {
                        this.tNdtCstmrCdStart.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtMul)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.Multiplication);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Down)
                    {
                        this.tNdtSerNum.Focus();
                    }
                    else
                    {
                        this.tNdtAdd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtSerNum)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.Sequence);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Up)
                    {
                        this.tNdtMul.Focus();
                    }
                    else if (this.ultrGrid.Rows.Count != 0)
                    {
                        this.ultrGrid.Focus();
                        this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_AF_CD].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
        }

        /// <summary>
        /// �t�H�[���̃L�[�_�E�����̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[���̃L�[�_�E�����ɔ������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10<</br>
        /// </remarks>
        private void PMKHN05121UA_KeyDown(object sender, KeyEventArgs e)
        {
            // UltraOptionSet�Ƀt�H�[�J�X���������Ă���󋵂ŁA
            // ���J�[�\���L�[(��)���������ꂽ��
            if (this.ultrRbtnCllctvSttng.Focused && (e.KeyCode == Keys.Right))
            {
                switch (this.ultrRbtnCllctvSttng.FocusedIndex)
                {
                    case 0:
                    case 1:
                        this.tNdtAdd.Focus();
                        break;
                    case 2:
                        this.tNdtMul.Focus();
                        break;
                    case 3:
                        this.tNdtSerNum.Focus();
                        break;
                    default:
                        // �����Ȃ�
                        break;
                }
            }
        }

        /// <summary>
        /// �O���b�h�L�[�_�E�����̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note	   : �O���b�h������L�[�_�E�����ɔ������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_KeyDown(object sender, KeyEventArgs e)
        {
            // �Z�����A�N�e�B�u��ԂŁA���ҏW���[�h�̎��̂ݏ������s���܂��B
            if (this.ultrGrid.ActiveCell != null && this.ultrGrid.ActiveCell.IsInEditMode)
            {
                int activeRowIndex = this.ultrGrid.ActiveCell.Row.Index;
                int activeColIndex = this.ultrGrid.ActiveCell.Column.Index;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        // ���̃Z���A���̓R���g���[���Ƀt�H�[�J�X���Z�b�g���܂��B
                        this.SetFocusEditCellOnKeyDown(this.firstRow, this.ultrBtnSttng, UltraGridAction.AboveCell, e);
                        break;
                    case Keys.Down:
                        // �O�̃Z���A���̓R���g���[���Ƀt�H�[�J�X���Z�b�g���܂��B
                        this.SetFocusEditCellOnKeyDown(this.ultrGrid.Rows.Count - 1, null,
                            UltraGridAction.BelowCell, e);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region -- ���̑� --

        /// <summary>
        /// ��ʏI�����̏���
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʂ��I������Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public void PMKHN05121UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �ҏW�ς݃t���O��off�̏ꍇ�A�����ŏ������I�����܂��B
            if (!this.isEdit)
            {
                return;
            }

            // �t�H�[�J�X��擪�ɖ߂��܂��B
            this.tNdtCstmrCdStart.Focus();

            // �ϊ���̓��Ӑ�R�[�h��œ��͂���Ă���Z���̐��𐔂��܂��B
            int editedCount = 0;
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                UltraGridCell cell = row.Cells[GridSettingInfo.COL_AF_CD];
                if (!String.IsNullOrEmpty(cell.Text.Trim()) && Convert.ToInt32(cell.Value) != 0)
                {
                    editedCount++;
                }
            }

            // �ύX��R�[�h������ꍇ�́A�X�V���������s���邩�ۂ���
            // ���[�U�ɖ₢���킹�܂��B
            if (editedCount != 0)
            {
                // �m�F�_�C�A���O��\�����܂��B
                DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.pgId,
                    MessageMng.INFO_MES_012, 0, MessageBoxButtons.YesNoCancel);

                // DialogResult�̌��ʂɉ����ď����𕪊򂳂��܂��B
                if (result == DialogResult.Yes)
                {
                    // close�C���x���g���L�����Z�����܂��B
                    e.Cancel = true;
                    // FormClosing�C�x���g����R�[�h�ϊ������s����̂Ńt���O��on�ɂ��܂��B
                    this.isCallFormCloseingEvent = true;
                    // OK�������������́A�o�^�����{���Ă���I�����܂��B
                    this.ConvertCustomerCode();
                }
                else if (result == DialogResult.Cancel)
                {
                    // �L�����Z���������������́A�I���������L�����Z�����܂��B
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// �t�H�[������\�����̃C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[��������\�������Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void PMKHN05121UA_Shown(object sender, EventArgs e)
        {
            // ���Ӑ�R�[�h(�J�n)���͗��Ƀt�H�[�J�X���Z�b�g
            this.tNdtCstmrCdStart.Focus();
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^�����N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrBtnCstmrStart_Click(object sender, EventArgs e)
        {
            // �������ꂽ�{�^����ۑ�
            UltraButton btnCtrl = sender as UltraButton;
            this.btnType = (GuidButtonType)btnCtrl.Tag;

            // ���Ӑ�K�C�h���N�� 
            PMKHN04005UA customerSearchFrm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchFrm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchFrm_CustomerSelect);
            customerSearchFrm.Show(this);
        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="searchRet">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^�����N���b�N����ƃC�x���g�̏����B</br>
        /// <br>             ���Ӑ�R�[�h���͗��Ɠ��Ӑ於�̂ɃK�C�h����擾�����f�[�^���Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        void customerSearchFrm_CustomerSelect(object sender, CustomerSearchRet searchRet)
        {
            if (searchRet == null) return;

            CustomerInfo cstmrInf;
            int status = this.customerAcs.ReadDBData(ConstantManagement.LogicalMode.GetDataAll, searchRet.EnterpriseCode,
                searchRet.CustomerCode, true, out cstmrInf);
            if (status != 0) return;

            TNedit tNEdit = this.btnType == GuidButtonType.Start ? this.tNdtCstmrCdStart : this.tNdtCstmrCdEnd;
            tNEdit.Text = String.Format(PMKHN05121UA.cdFormat, cstmrInf.CustomerCode);
            TEdit tEdit = this.btnType == GuidButtonType.Start ? this.tEdtCstmrNmStart : this.tEdtCstmrNmEnd;
            tEdit.Text = cstmrInf.Name;
        }

        /// <summary>
        /// �c�[�����j���[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �c�[�����j���[���N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void tToolBarMain_ToolClick(object sender, ToolClickEventArgs e)
        {
            // �t�H�[�J�X��擪�ɖ߂��܂��B
            tNdtCstmrCdStart.Focus();
            // �N���b�N�������j���[�ɂ���ď����𕪊�
            switch (e.Tool.Key)
            {
                // �I��
                case ToolMenuType.BTN_TOOL_CLOSE:
                    // �I�����͐e�t�H�[��������܂��B
                    ((Form)this.Parent).Close();
                    break;
                // ���s
                case ToolMenuType.BTN_TOOL_EXEC:
                    this.ConvertCustomerCode();
                    break;
                // ����
                case ToolMenuType.BTN_TOOL_SEARCH:
                    this.Search();
                    break;
                // �N���A
                case ToolMenuType.BTN_TOOL_CLEAR:
                    this.Clear();
                    break;
                // ����ȊO
                default:
                    // �����Ȃ�
                    break;
            }
        }

        /// <summary>
        /// �ꊇ�ݒ�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ꊇ�ݒ�{�^�����N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void ultrBtnSttng_Click(object sender, EventArgs e)
        {
            // �ꊇ�ݒ�̃^�C�v
            AllSettingType type = (AllSettingType)Enum.ToObject(typeof(AllSettingType), Convert.ToInt32(this.ultrRbtnCllctvSttng.Value));
            // �O���b�h�̃f�[�^
            DataTable tbl = ((DataView)this.ultrGrid.DataSource).Table;
            // �ϊ��̕␳�l���i�[����ϐ�
            int offset = 0;
            // �ϊ������I�u�W�F�N�g
            AllSetting convObj = null;

            switch (type)
            {
                case AllSettingType.Equivalence:
                    // ���l��I����
                    convObj = new AllSettingEquivalence();
                    break;
                case AllSettingType.ADD:
                    // ���Z��I����
                    // ���l�`�F�b�N
                    if (this.IsNotNumber(this.tNdtAdd))
                    {
                        return;
                    }
                    // ���͒l���`�F�b�N���܂��B
                    if (this.tNdtAdd.GetInt() == 0)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_001);
                        this.tNdtAdd.Focus();
                        return;
                    }

                    offset = this.tNdtAdd.GetInt();
                    convObj = new AllSettingAdd();
                    break;
                case AllSettingType.Multiplication:
                    // ��Z��I����
                    // ���l�`�F�b�N
                    if (this.IsNotNumber(this.tNdtMul))
                    {
                        return;
                    }
                    // ���͒l���`�F�b�N���܂�
                    if (this.tNdtMul.GetInt() == 0)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_002);
                        this.tNdtMul.Focus();
                        return;
                    }                    

                    offset = this.tNdtMul.GetInt();
                    convObj = new AllSettingMultiplication();
                    break;
                default:
                    // ����ȊO(�A��)��I����
                    // ���l�`�F�b�N
                    if (this.IsNotNumber(this.tNdtSerNum))
                    {
                        return;
                    }
                    // ���͒l���`�F�b�N���܂�
                    if (this.tNdtSerNum.GetInt() == 0)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_003);
                        this.tNdtSerNum.Focus();
                        return;
                    }                    

                    offset = this.tNdtSerNum.GetInt();
                    convObj = new AllSettingSequence();
                    break;
            }

            // �ϊ������s���܂��B
            string cnvCode = String.Empty;
            foreach (DataRow row in tbl.Rows)
            {
                if (String.IsNullOrEmpty(row[GridSettingInfo.COL_AF_CD].ToString()) ||
                    Convert.ToInt32(row[GridSettingInfo.COL_AF_CD]) == 0)
                {
                    cnvCode = convObj.Convert(
                        Convert.ToInt32(row[GridSettingInfo.COL_BF_CD]), ref offset);

                    //�ݒ�l��0�ȉ��A�܂���MAX�𒴂��Ă�����A�ݒ肵�Ȃ��B
                    if (Convert.ToInt32(cnvCode) <= 0 || Convert.ToInt32(cnvCode) > 99999999)
                    {
                        continue;
                    }

                    // �ϊ��㓾�Ӑ�R�[�h
                    row[GridSettingInfo.COL_AF_CD] = cnvCode;
                    // �ϊ��㓾�Ӑ於
                    row[GridSettingInfo.COL_AF_NM] = this.GetCustomerName(cnvCode);
                    // �ҏW�ς݃t���O��on�ɂ��܂��B
                    this.isEdit = true;
                }
            }
        }

        /// <summary>
        /// �ꊇ�ݒ���͗��ҏW���[�h�I����̏���
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ꊇ�ݒ���͗��ҏW���[�h�I����ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void tNdtAdd_AfterExitEditMode(object sender, EventArgs e)
        {
            TNedit nEdit = sender as TNedit;
            if (nEdit != null)
            {
                //�}�C�i�X�����e����֌W��5�P�^���e�ɂ��Ă��邪�A��Βl��5�P�^�𒴂�����C���B
                if (nEdit == this.tNdtAdd)
                {
                    int buf = Math.Abs(nEdit.GetInt());
                    if (buf > 99999999)
                    {
                        nEdit.SetValue(99999999);
                    }
                }

                if (nEdit.GetInt() != 0 && this.allSttngPrevValMap[(AllSettingType)nEdit.Tag] != nEdit.GetInt())
                {
                    this.ultrRbtnCllctvSttng.Value = (int)nEdit.Tag;
                    this.ultrRbtnCllctvSttng.FocusedIndex = (int)nEdit.Tag;
                }
                // �������ɕۑ������ꊇ�ݒ�̏���ύX�����㏑�����܂��B
                // ������ or 0�̏ꍇ��0�ŏ㏑�����܂��B
                this.allSttngPrevValMap[(AllSettingType)nEdit.Tag] = nEdit.GetInt();
            }
        }

        #endregion

        #endregion

        #region -- Enumeration --

        /// <summary>
        /// UltraExpandableGroupBox�̃^�C�v��\���񋓎q
        /// </summary>
        private enum EgbGrpBoxType
        {
            // ���o�����p
            Condition,
            // �ꊇ�ݒ�p
            CollectiveSetting
        }

        /// <summary>
        /// ���������K�C�h�{�^���̎�ʂ�\���񋓎q
        /// </summary>
        private enum GuidButtonType
        {
            // �J�n�{�^��
            Start,
            // �I���{�^��
            End
        }

        /// <summary>
        /// �ꊇ�ݒ�̃^�C�v��\���񋓎q
        /// </summary>
        private enum AllSettingType
        {
            /// <summary>���l</summary>
            Equivalence = 0,
            /// <summary>�ǉ�</summary>
            ADD,
            /// <summary>��Z</summary>
            Multiplication,
            /// <summary>�A��</summary>
            Sequence
        }

        /// <summary>
        /// �_���폜�̎�ʂ�\���񋓎q
        /// </summary>
        private enum LogicalDeleteType
        {
            /// <summary>�L��</summary>
            Valid = 0,
            /// <summary>�_���폜</summary>
            Logical,
            /// <summary>�ۗ�/summary>
            Hold,
            /// <summary>���S�폜</summary>
            Deleted
        }

        #endregion

        #region -- Inner Class --

        #region -- Constant Class --

        /// <summary>
        /// PM.NS�����c�[���@���b�Z�[�W����ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W����ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class MessageMng
        {
            #region -- �G���[���b�Z�[�W --

            /// <summary>ERR_MES_001:���Z�l�������͂ł��B</summary>
            public const string ERR_MES_001 = "���Z�l�������͂ł��B";
            /// <summary>ERR_MES_002:��Z�l�������͂ł��B</summary>
            public const string ERR_MES_002 = "��Z�l�������͂ł��B";
            /// <summary>ERR_MES_003:�J�n�ԍ��������͂ł��B</summary>
            public const string ERR_MES_003 = "�J�n�ԍ��������͂ł��B";
            /// <summary>ERR_MES_004:�f�[�^�̎擾�Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_004 = "�f�[�^�̎擾�Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_005:���Ӑ�R�[�h�̕ϊ��Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_005 = "���Ӑ�R�[�h�̕ϊ��Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_006:���Ӑ�R�[�h�̕ϊ��Ɏ��s���܂����B</summary>
            public const string ERR_MES_006 = "���Ӑ�R�[�h�̕ϊ��Ɏ��s���܂����B";
            /// <summary>ERR_MES_007:�ϊ���R�[�h��4���ȓ��œo�^���Ă��������B</summary>
            public const string ERR_MES_007 = "�ϊ���R�[�h��{0}���ȓ��œo�^���Ă��������B";
            /// <summary>ERR_MES_008:�ύX��̓��Ӑ�R�[�h���d�����Ă��܂��B</summary>
            public const string ERR_MES_008 = "�ύX��̓��Ӑ�R�[�h���d�����Ă��܂��B";
            /// <summary>ERR_MES_009:�ϊ��Ώۂ̃R�[�h������܂���B</summary>
            public const string ERR_MES_009 = "�ϊ��Ώۂ̃R�[�h������܂���B";
            /// <summary>ERR_MES_010:���Ӑ�͈͎̔w�肪�s���ł��B</summary>
            public const string ERR_MES_010 = "���Ӑ�͈͎̔w�肪�s���ł��B";
            /// <summary>ERR_MES_011:�f�[�^�̎擾�Ɏ��s���܂����B</summary>
            public const string ERR_MES_011 = "�f�[�^�̎擾�Ɏ��s���܂����B";
            /// <summary>ERR_MES_012:��ʋN�����ɃG���[���������܂����B\r\n�ڍׁF{0}</summary>
            public const string ERR_MES_012 = "��ʋN�����ɃG���[���������܂����B\r\n�ڍׁF{0}";
            /// <summary>ERR_MES_013:���Ӑ�R�[�h�ϊ��Ώۃt�@�C���ɑΏۂƂȂ�e�[�u��������܂���B\r\n�t�@�C�����e���������Ă��������B</summary>
            public const string ERR_MES_013 = "���Ӑ�R�[�h�ϊ��Ώۃt�@�C���ɑΏۂƂȂ�e�[�u��������܂���B\r\n�t�@�C�����e���������Ă��������B";
            /// <summary>ERR_MES_014:���Ӑ�R�[�h�ϊ��Ώۃt�@�C���ɕs���ȃf�[�^���L��܂��B\r\n�t�@�C���̓��e���������Ă��������B</summary>
            public const string ERR_MES_014 = "���Ӑ�R�[�h�ϊ��Ώۃt�@�C���ɕs���ȃf�[�^���L��܂��B\r\n�t�@�C���̓��e���������Ă��������B";
            /// <summary>ERR_MES_015:���Ӑ�R�[�h�ϊ��Ώۃt�@�C��������܂���B</summary>
            public const string ERR_MES_015 = "���Ӑ�R�[�h�ϊ��Ώۃt�@�C��������܂���B";
            /// <summary>ERR_MES_016:���l�ł͂Ȃ��l�����͂���Ă��܂��B</summary>
            public const string ERR_MES_016 = "���l�ł͂Ȃ��l�����͂���Ă��܂��B";

            #endregion

            #region -- �C���t�H���b�Z�[�W --

            /// <summary>INFO_MES_001:�R�[�h�ϊ��J�n</summary>
            public const string INFO_MES_001 = "�R�[�h�ϊ��J�n";
            /// <summary>INFO_MES_002:�R�[�h�ϊ�����</summary>
            public const string INFO_MES_002 = "�R�[�h�ϊ�����";
            /// <summary>INFO_MES_003:�G���[</summary>
            public const string INFO_MES_003 = "�G���[";
            /// <summary>INFO_MES_004:�R���o�[�g�����s���܂����A��낵���ł����H</summary>
            public const string INFO_MES_004 = "�R���o�[�g�����s���܂����A��낵���ł����H";
            /// <summary>INFO_MES_005:�R�[�h�F�R�[�h�F{0}��ϊ���... {1}/{2}��</summary>
            public const string INFO_MES_005 = "{0}��ϊ���... {1}/{2}��";
            /// <summary>INFO_MES_006:�R�[�h�F�R���o�[�g���������s�ς݂ł��B\r\n�ēx���s����ꍇ�͌����{�^�����N���b�N����\r\n�f�[�^���ŐV�����Ă��������B</summary>
            public const string INFO_MES_006 = "�R���o�[�g���������s�ς݂ł��B\r\n�ēx���s����ꍇ�͌����{�^�����N���b�N����\r\n�f�[�^���ŐV�����Ă��������B";
            /// <summary>INFO_MES_007:�폜�ς݂̃f�[�^�ł��B</summary>
            public const string INFO_MES_007 = "�폜�ς݂̃f�[�^�ł��B";
            /// <summary>INFO_MES_008:���Ӑ�R�[�h�ϊ�����</summary>
            public const string INFO_MES_008 = "���Ӑ�R�[�h�ϊ�����";
            /// <summary>INFO_MES_009:���Ӑ�R�[�h�ϊ���ϊ����ł��c</summary>
            public const string INFO_MES_009 = "���Ӑ�R�[�h�ϊ���ϊ����ł��c";
            /// <summary>INFO_MES_010:���Ӑ�}�X�^���o����</summary>
            public const string INFO_MES_010 = "���Ӑ�}�X�^���o����";
            /// <summary>INFO_MES_011:���Ӑ�}�X�^�𒊏o���ł��c</summary>
            public const string INFO_MES_011 = "���Ӑ�}�X�^�𒊏o���ł��c";
            /// <summary>INFO_MES_012:�ҏW���̃f�[�^���݂��܂��B\r\n�R�[�h�ϊ����������s���܂����H</summary>
            public const string INFO_MES_012 = "�ҏW���̃f�[�^���݂��܂��B\r\n�R�[�h�ϊ����������s���܂����H";
            /// <summary>INFO_MES_013:���������ɊY�����链�Ӑ�}�X�^�͑��݂��܂���B</summary>
            public const string INFO_MES_013 = "���������ɊY�����链�Ӑ�}�X�^�͑��݂��܂���B";

            #endregion
        }

        /// <summary>
        /// PM.NS�����c�[���@�O���b�h�̌Œ�ݒ����ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̌Œ�ݒ����ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class GridSettingInfo
        {
            #region -- Constractor --

            /// <summary>
            /// PM.NS�����c�[���@�O���b�h�̌Œ�ݒ����ۑ����������N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : PM.NS�����c�[���A�O���b�h�̌Œ�ݒ����ۑ����������N���X�̏����������s���܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            private GridSettingInfo()
            {
                // �萔�N���X�ׁ̈A�����Ȃ�
            }

            #endregion

            #region -- �萔 --

            /// <summary>�f�[�^�e�[�u���̃e�[�u����</summary>
            public const string TBL_NAME = "cdCnvDt";

            #region -- �� --

            /// <summary>No.��̗�</summary>
            public const string COL_NO_CAP = "No.";
            /// <summary>No.��̎��ʎq</summary>
            public const string COL_NO = "No";

            /// <summary>���Ӑ�R�[�h��̗�</summary>
            public const string COL_CD_CAP = "���Ӑ�R�[�h";
            /// <summary>�ύX�O���Ӑ�R�[�h��̎��ʎq</summary>
            public const string COL_BF_CD = "BeforeCd";
            /// <summary>�ύX�㓾�Ӑ�R�[�h��̎��ʎq</summary>
            public const string COL_AF_CD = "AeforeCd";

            /// <summary>���Ӑ於��̗�</summary>
            public const string COL_NM_CAP = "���Ӑ於";
            /// <summary>�ύX�O���Ӑ於��̎��ʎq</summary>
            public const string COL_BF_NM = "BeforeNm";
            /// <summary>�ύX�㓾�Ӑ於��̎��ʎq</summary>
            public const string COL_AF_NM = "AeforeNm";

            /// <summary>�폜�ςݗ�̗�</summary>
            public const string COL_LDEL_NM = "�폜�ς�";
            /// <summary>�폜�ςݗ�̎��ʎq</summary>
            public const string COL_LDEL = "LogicalDel";

            #endregion

            #region -- �� --

            /// <summary>No.��̗�:45</summary>
            public const int COL_NO_WIDTH = 45;
            /// <summary>�ύX�O���Ӑ�R�[�h��̗�:150</summary>
            public const int COL_BF_CD_WIDTH = 150;
            /// <summary>�ύX�㓾�Ӑ�R�[�h��̗�:150</summary>
            public const int COL_AF_CD_WIDTH = 150;
            /// <summary>�ύX�O���Ӑ於��̗�:200</summary>
            public const int COL_BF_NM_WIDTH = 200;
            /// <summary>�ύX�㓾�Ӑ於��̗�:200</summary>
            public const int COL_AF_NM_WIDTH = 200;

            #endregion

            #endregion
        }

        /// <summary>
        /// PM.NS�����c�[���@�c�[�����j���[�̏���ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[�����j���[�̏���ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class ToolMenuType
        {
            #region -- �萔 --

            /// <summary>�I���{�^����\���萔</summary>
            public const string BTN_TOOL_CLOSE = "btnToolClose";
            /// <summary>���s�{�^����\���萔</summary>
            public const string BTN_TOOL_EXEC = "btnToolExcec";
            /// <summary>�����{�^����\���萔</summary>
            public const string BTN_TOOL_SEARCH = "btnToolSearch";
            /// <summary>�N���A�{�^����\���萔</summary>
            public const string BTN_TOOL_CLEAR = "btnToolClear";
            /// <summary>���_������\���萔</summary>
            public const string LBL_TOOL_SECTION = "lblSecName";
            /// <summary>���O�C�����[�U������\���萔</summary>
            public const string LBL_TOOL_NAME = "lblLoginName";

            #endregion
        }

        /// <summary>
        /// PM.NS�����c�[���@�X�e�[�^�X�o�[�̏���ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[�̏���ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class StatusKeyType
        {
            #region -- �萔 --

            /// <summary>�X�e�[�^�X�o�[�̃X�e�[�^�X�\���̈�������L�[:status</summary>
            public const string STTS_KEY_STATUS = "status";
            /// <summary>�X�e�[�^�X�o�[�̃v���O���X�o�[�\���̈�������L�[:status</summary>
            public const string STTS_KEY_PROGRESS = "progress";
            /// <summary>�X�e�[�^�X�o�[�̓��t�\���̈�������L�[:date</summary>
            public const string STTS_KEY_DATE = "date";
            /// <summary>�X�e�[�^�X�o�[�̎����\���̈�������L�[:status</summary>
            public const string STTS_KEY_TIME = "time";

            /// <summary>�X�e�[�^�X�o�[�̃v���O���X�o�[�̃C���f�b�N�X:0</summary>
            public const int STTS_IDX_PROGRESS = 0;

            #endregion
        }

        #endregion

        #region -- ���͒l�`�F�b�N�p�Ɉꎞ�I�ɒl��ۑ�����N���X --

        /// <summary>
        /// ���͒l�`�F�b�N�p�Ɉꎞ�I�ɒl��ۑ�����N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͒l�`�F�b�N�p�Ɉꎞ�I�ɒl��ۑ�����N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private sealed class CustomerInputData
        {
            #region -- Member --

            /// <summary>���Ӑ�R�[�h(�ύX�O)</summary>
            private string bfCustomerCd = String.Empty;
            /// <summary>���Ӑ�R�[�h(�ύX��)</summary>
            private string afCustomerCd = String.Empty;
            /// <summary>�����Ώۂ̓��Ӑ�R�[�h(�ύX�O)</summary>
            private string chgBfCusCd = String.Empty;
            /// <summary>�����Ώۂ̓��Ӑ�R�[�h(�ύX��)</summary>
            private string chgAfCusCd = String.Empty;
            /// <summary>�O���b�h���̍s�ԍ�</summary>
            private int rowIndex = 0;
            /// <summary>�ʂ̓��Ӑ�R�[�h�ƃR�[�h�̕ϊ������������Ƃ�\���t���O</summary>
            private bool isOtherCodeChand = false;

            #endregion

            #region -- Property --

            /// <summary>���Ӑ�R�[�h(�ύX�O)�v���p�e�B</summary>
            public String BfCustomerCode
            {
                get { return this.bfCustomerCd; }
                set { this.bfCustomerCd = value; }
            }

            /// <summary>���Ӑ�R�[�h(�ύX��)�v���p�e�B</summary>
            public String AfCustomerCode
            {
                get { return this.afCustomerCd; }
                set { this.afCustomerCd = value; }
            }

            /// <summary>�O���b�h���̍s�ԍ�</summary>
            public int RowIndex
            {
                get { return this.rowIndex; }
                set { this.rowIndex = value; }
            }

            /// <summary>�ʓ��Ӑ�R�[�h�ƃR�[�h�̌��������������Ƃ������t���O�̃v���p�e�B</summary>
            public bool IsOtherCodeChange
            {
                get { return this.isOtherCodeChand; }
            }

            #endregion

            #region -- Method --

            /// <summary>
            /// �ʓ��Ӑ�R�[�h�ۑ�����
            /// </summary>
            /// <param name="bfCode">�����Ώۂ̓��Ӑ�R�[�h(�ϊ��O)</param>
            /// <param name="afCode">�����Ώۂ̓��Ӑ�R�[�h(�ϊ���)</param>
            /// <remarks>
            /// <br>Note       : �ʂ̓��Ӑ�R�[�h�ƃR�[�h�̌������������ꍇ�́A���������R�[�h��ۑ����܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public void SetOtherCodeChange(string bfCode, string afCode)
            {
                this.chgBfCusCd = bfCode;
                this.chgAfCusCd = afCode;
                this.isOtherCodeChand = (this.bfCustomerCd == this.chgAfCusCd) &&
                    (this.afCustomerCd == this.chgBfCusCd);
            }

            /// <summary>
            /// �ҏW�ςݔ��菈��
            /// </summary>
            /// <returns>true:�ҏW�L��/false:�ҏW����</returns>
            /// <remarks>
            /// <br>Note       : �I�𒆂̓��Ӑ�R�[�h���ҏW�����f�[�^���ۂ��𔻒肵�܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public bool IsEdit()
            {
                return this.bfCustomerCd != this.afCustomerCd;
            }

            #endregion
        }

        #endregion

        #region -- �v�Z�p�̃N���X --

        /// <summary>
        /// PM.NS�����c�[���@�ꊇ�ϊ����s���N���X�̊��N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ꊇ�ϊ����s���N���X�̊��N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private abstract class AllSetting
        {
            /// <summary>
            /// �ϊ�����
            /// </summary>
            /// <param name="bfrVal">�ϊ��Ώۂ̒l</param>
            /// <param name="offset">�␳�l</param>
            /// <returns>�ϊ���̒l</returns>
            /// <remarks>
            /// <br>Note       : �ꊇ�ϊ����s���N���X�̊��N���X�ł��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            abstract public string Convert(int bfrVal, ref int offset);
        }

        /// <summary>
        /// PM.NS�����c�[���@���l�̈ꊇ�ϊ����s���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���l�̈ꊇ�ϊ����s���N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class AllSettingEquivalence : AllSetting
        {
            /// <summary>
            /// �ϊ�����
            /// </summary>
            /// <param name="bfrVal">�ϊ��Ώۂ̒l</param>
            /// <param name="offset">�␳�l</param>
            /// <returns>�ϊ���̒l</returns>
            /// <remarks>
            /// <br>Note       : �ϊ���̒l��ϊ��O�Ɠ����l�ɕϊ����܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/02/18</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05121UA.cdFormat, bfrVal);
            }
        }

        /// <summary>
        /// PM.NS�����c�[���@���Z�̈ꊇ�ϊ����s���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Z�̈ꊇ�ϊ����s���N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class AllSettingAdd : AllSetting
        {
            /// <summary>
            /// �ϊ�����
            /// </summary>
            /// <param name="bfrVal">�ϊ��Ώۂ̒l</param>
            /// <param name="offset">�␳�l</param>
            /// <returns>�ϊ���̒l</returns>
            /// <remarks>
            /// <br>Note       : �w�肵���l��ϊ��O�̒l�ɉ��Z�����l��ϊ���̒l�ɂ��܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05121UA.cdFormat, bfrVal + offset);
            }
        }

        /// <summary>
        /// PM.NS�����c�[���@��Z�̈ꊇ�ϊ����s���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��Z�̈ꊇ�ϊ����s���N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class AllSettingMultiplication : AllSetting
        {
            /// <summary>
            /// �ϊ�����
            /// </summary>
            /// <param name="bfrVal">�ϊ��Ώۂ̒l</param>
            /// <param name="offset">�␳�l</param>
            /// <returns>�ϊ���̒l</returns>
            /// <remarks>
            /// <br>Note       : �w�肵���l��ϊ��O�̒l�ɏ�Z�����l��ϊ���̒l�ɂ��܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05121UA.cdFormat, bfrVal * offset);
            }
        }

        /// <summary>
        /// PM.NS�����c�[���@�A�Ԃ̈ꊇ�ϊ����s���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A�Ԃ̈ꊇ�ϊ����s���N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class AllSettingSequence : AllSetting
        {
            /// <summary>
            /// �ϊ�����
            /// </summary>
            /// <param name="bfrVal">�ϊ��Ώۂ̒l</param>
            /// <param name="offset">�␳�l</param>
            /// <returns>�ϊ���̒l</returns>
            /// <remarks>
            /// <br>Note       : �ϊ���̒l���w�肵���l�̘A�Ԃɕϊ����܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                string convVal = String.Format(PMKHN05121UA.cdFormat, offset);
                offset++;
                return convVal;
            }
        }

        #endregion                                               
      
        #endregion
    }
}