//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ�UI�t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ�UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ�UI�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public partial class PMKHN05101UA : Form
    {
        #region -- �萔 --

        /// <summary>�v���O����ID��\���萔:PMKHN05101UA</summary>
        private readonly string pgId = "PMKHN05101UA";
        /// <summary>�O���b�h�̃O���[�v�w�b�_No��\���萔</summary>
        private readonly string hdrGrpKeyNo = "NoGrp";
        /// <summary>�O���b�h�̃O���[�v�w�b�_�ύX�O��\���萔</summary>
        private readonly string hdrGrpKeyBefore = "BeforeGrp";
        /// <summary>�O���b�h�̃O���[�v�w�b�_�ύX���\���萔</summary>
        private readonly string hdrGrpKeyAfter = "AfterGrp";
        /// <summary>���o�����A�ꊇ�ݒ�̏k�����̃T�C�Y</summary>
        private readonly int egbGrpBoxCntrctSize = 25;
        /// <summary>�q�ɖ��̂��o�^����Ă��Ȃ����Ƃ������萔�F���o�^</summary>
        private readonly string noWarehouseName = "���o�^";
        /// <summary>�擪�s��\����ʐ�</summary>
        private readonly int firstRow = 0;
        /// <summary>�S���҃R�[�h�ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private const int ILLEGAL_DATA = 997;
        /// <summary>�S���҃R�[�h�ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private const int NO_DATA = 998;
        /// <summary>�S���҃R�[�h�ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private const int NO_FILE = 999;
        /// <summary>���l�`�F�b�N�p�̐��K�\���F^\d+$</summary>
        private readonly string regPttrnNum = @"^\d+$";

#region -- ���O�֘A --
        /// <summary>���O�o�͐�̃f�B���N�g������\���萔�F./LOG/PMKHN05100U</summary>
        private const string LOG_DIR_PATH = @"./LOG/PMKHN05100U";
        /// <summary>���O�t�@�C������\���萔�FPMKHN05100U.log</summary>
        private const string LOG_FILE_NAME = @"PMKHN05100U_{0}.log";
        /// <summary>���O�t�@�C�����̓��t�����̃t�H�[�}�b�g�FyyyyMMdd</summary>
        private const string LOG_FORMAT_DATE = "yyyyMMdd";
        /// <summary>���O�t�H�[�}�b�g�FHH:mm:ss</summary>
        private const string LOG_FORMAT_PROCESSING_TIME = "HH:mm:ss";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] �q�ɃR�[�h�ϊ��������J�n���܂��B</summary>
        private const string LOG_FORMAT_START = "[{0}] �q�ɃR�[�h�ϊ��������J�n���܂��B";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] �q�ɃR�[�h�ϊ��������������܂����B</summary>
        private const string LOG_FORMAT_END = "[{0}] �q�ɃR�[�h�ϊ��������������܂����B";
        /// <summary>���O�t�H�[�}�b�g�F[{0}],�X�V�ΏہF{1},�X�V�����F{2}��,�������ԁF{3}</summary>
        private const string LOG_FORMAT_CASE_BY_BASE = "[{0}],�X�V�ΏہF{1},�X�V�����F{2}��,�������ԁF{3}";
        /// <summary>���O�t�H�[�}�b�g�F[{0}],���������ԁF{1},���X�V�����F{2}��</summary>
        private const string LOG_FORMAT_TOTAL = "[{0}],���������ԁF{1},���X�V�����F{2}��";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] {1}�̕ϊ����ɃG���[���������܂����B�ϊ������𒆎~���܂��B</summary>
        private const string LOG_FORMAT_ERROR = "[{0}] {1}�̕ϊ����ɃG���[���������܂����B�ϊ������𒆎~���܂��B";
        /// <summary>���O�t�@�C�����̓��t�t�H�[�}�b�g�Fyyyy/MM/dd HH:mm:ss</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd HH:mm:ss";
#endregion

        /// <summary>�q�ɃR�[�h�̃t�H�[�}�b�g</summary>
        private static readonly string cdFormat = "{0:D4}";

        #endregion

        #region -- Member --

        /// <summary>
        /// �X�e�[�^�X�o�[�X�V�����f���Q�[�g
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���X�V���邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        delegate void UpdateStatusBarDelegate(string mes);

        /// <summary>
        /// �X�e�[�^�X�o�[�����������f���Q�[�g
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[�����������邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        delegate void InitStatusBarDelegate(int cnvTrgTblCount);

        // �A�N�Z�X�N���X�֘A
        /// <summary>�q�ɃK�C�h</summary>
        private WarehouseAcs warehouseAcs;
        /// <summary>���_�}�X�^</summary>
        private SecInfoAcs secInfoAcs;
        /// <summary>�q�ɃR�[�h�ϊ�</summary>
        private WarehouseConvertAcs warehouseCnvAcs;
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
        /// <summary>�q�ɏ��i�[�}�b�v</summary>
        private Dictionary<string, String> warehouseInfoMap;
        /// <summary>�X�V�t���O(true:�X�V�ς�/false:���X�V)</summary>
        private bool isUpdate = false;
        /// <summary>�ҏW�ς݊m�F�t���O(true:�ҏW�ς�/false:���ҏW)</summary>
        private bool isEdit = false;
        /// <summary>���̓`�F�b�N�̌��ʂ��i�[����ϐ�(true:�`�F�b�NOK/false:�`�F�b�NNG)</summary>
        private bool isCheckOK = false;
        /// <summary>�R�[�h�̌���</summary>
        private int codeLength = 0;
        /// <summary>�X���b�h���s���̃G���[���b�Z�[�W��ۑ�</summary>
        private string cnvErrMes = String.Empty;
        /// <summary>FormCloing�C�x���g�Ŏ��{���ꂽ���𔻒肷��t���O(true:FormCloig������{/false:FormCloing�ȊO�Ŏ��{)</summary>
        private bool isCallFormCloseingEvent = false;
        /// <summary>�ꊇ�ݒ�̊e���ڂ̓��͒l��ۑ�����}�b�v</summary>
        private IDictionary<AllSettingType, int> allSttngPrevValMap = null;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ�UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�q�Ƀ}�X�^�R�[�h�ϊ�UI�t�H�[���N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public PMKHN05101UA()
        {
            InitializeComponent();
            // �e�핔�i�̏��������s���܂��B
            this.ctrlScrnSkin = new ControlScreenSkin();
            // ���o�����ƈꊇ�ݒ�̓W�J���̍�������ۑ�
            this.egbGrpBoxHeighMap = new Dictionary<EgbGrpBoxType, int>();
            this.egbGrpBoxHeighMap[EgbGrpBoxType.Conditon] = this.ultrEgbCondition.Height;
            this.egbGrpBoxHeighMap[EgbGrpBoxType.CollectiveSetting] = this.ultrEgbCllctvSttng.Height;

            // �ꊇ�ݒ�̊e���ڂ̓��͒l��ۑ�����}�b�v�����������܂��B
            this.InitAllSttngPrevValMap();

            // �R�[�h�̌�����ݒ肵�܂��B
            this.codeLength = 4;
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            // ���N���X�̃��[�h�����s���܂��B
            base.OnLoad(e);

            // ��ʂ̕`����ꎞ��~���܂��B
            this.SuspendLayout();

            // �e�R���g���[���̏��������s���܂�
            this.InitSetting();

            // ��ʂ̃X�L����ݒ肵�܂��B
            this.InitSkin();

            // ���j���[�A�y�у{�^���̃A�C�R����ݒ肵�܂��B
            this.tTooBarMain.ImageListSmall = IconResourceManagement.ImageList16;
            this.ultrBtnWrhsStart.ImageList = IconResourceManagement.ImageList16;
            this.ultrBtnWrhsEnd.ImageList = IconResourceManagement.ImageList16;

            // ���_�}�X�^�̏�����
            this.secInfoAcs = new SecInfoAcs();
            this.GetSecInfoSet();

            // ��ƃR�[�h
            this.enterPriseCd = LoginInfoAcquisition.EnterpriseCode;
            // ���O�C�����_�R�[�h
            this.loginSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ���O�C�����[�U���̏�����
            this.SetUserInfo();

            // �q�ɃK�C�h�̏�����
            this.warehouseAcs = new WarehouseAcs();            

            // �O���b�h�̏����ݒ��ݒ肵�܂��B
            this.InitGrid();

            // �q�ɃR�[�h�ϊ��A�N�Z�X�N���X
            this.warehouseCnvAcs = new WarehouseConvertAcs();
            this.GetWarehouseInfo();

            // �������_�C�A���O
            this.procDlg = new SFCMN00299CA();

            // ���l���͗��̏�����
            this.SetTnEditMaxLength(this.pnlCllctvSttng);
            this.SetTnEditMaxLength(this.pnlCondtion);

            // �ꊇ�ݒ�̓��͗������������܂��B            
            this.SetAllSettingTypeOnTNEdit();

            // ��ʂ̕`����ĊJ���܂��B
            this.ResumeLayout(false);
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void InitSkin()
        {
            // �X�L���K�p�O�̃R���g���[����ۑ����܂��B
            List<string> exclustionList = new List<string>();
            exclustionList.Add(this.ultrEgbCondition.Name);
            exclustionList.Add(this.ultrEgbCllctvSttng.Name);
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void InitSetting()
        {
            /// UltraExpandableGroupBox�̏�����
            // ���o����
            this.ultrEgbCondition.Tag = EgbGrpBoxType.Conditon;
            // �ꊇ�ݒ�
            this.ultrEgbCllctvSttng.Tag = EgbGrpBoxType.CollectiveSetting;

            // �q�ɃK�C�h�{�^���̏�����
            // �q�ɃK�C�h�{�^���J�n
            this.ultrBtnWrhsStart.Tag = GuidButtonType.Start;
            // �q�ɃK�C�h�{�^���I��
            this.ultrBtnWrhsEnd.Tag = GuidButtonType.End;
        }

        /// <summary>
        /// ���[�U��񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�C�����[�U�������Ƀ��[�U�̕\������ݒ肵�܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void SetUserInfo()
        {
            // ���_��
            ToolBase secNm = tTooBarMain.Tools[ToolMenuType.LBL_TOOL_SECTION];
            if (secNm != null && LoginInfoAcquisition.Employee != null)
            {
                secNm.SharedProps.Caption = this.GetSecName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }
            // ���O�C����
            ToolBase loginNm = tTooBarMain.Tools[ToolMenuType.LBL_TOOL_NAME];
            if (loginNm != null && LoginInfoAcquisition.Employee != null)
            {
                loginNm.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }
        }

        /// <summary>
        /// ���l���͗�����������
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : ���l���͗��̏��������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void SetTnEditMaxLength(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TNedit)
                {
                    TNedit edit = child as TNedit;
                    edit.MaxLength = this.codeLength +1;
                }
                else
                {
                    SetTnEditMaxLength(child);
                }
            }
        }

        /// <summary>
        /// / ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^��ǂݍ��݁A���_���̂��������ɕێ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void GetSecInfoSet()
        {
            // ���_�}�X�^���狒�_�����擾���܂�
            this.secInfoMap = new Dictionary<string, string>();
            this.secInfoAcs.ResetSectionInfo();

            // ���_�����������ɃL���b�V�����܂�
            foreach (SecInfoSet secInfoSet in this.secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this.secInfoMap[secInfoSet.SectionCode.Trim()] = secInfoSet.SectionGuideNm.Trim();
                }
            }
        }

        /// <summary>
        /// / �q�Ƀ}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^��ǂݍ��݁A�q�ɖ��̂��������ɕێ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void GetWarehouseInfo()
        {
            // �X�e�[�^�X�����������܂�
            int status = 0;
            this.warehouseInfoMap = new Dictionary<string, string>();

            try
            {
                // ���������̏���(�S�������Ȃ̂ŁA�q�ɃR�[�h(�J�n)�Ƒq�ɃR�[�h(�I��)�͖��ݒ�)
                WarehouseConvertDispInfo dispInfo = new WarehouseConvertDispInfo();
                dispInfo.EnterpriseCode = this.enterPriseCd;
                dispInfo.WarehouseCdStart = String.Empty;
                dispInfo.WarehouseCdEnd = String.Empty;

                // �������ʊi�[�p�̕ϐ�
                List<WarehouseDispInfo> resultList = new List<WarehouseDispInfo>();

                // �q�Ƀ}�X�^����f�[�^���擾���܂�
                status = this.warehouseCnvAcs.SearchWarehouse(dispInfo, resultList);
                if (status == 0)
                {
                    foreach (WarehouseDispInfo warehouse in resultList)
                    {
                        this.warehouseInfoMap[warehouse.WarehouseCode.Trim()] = warehouse.WarehouseName.Trim();
                    }
                }
            }
            catch
            {
                this.warehouseInfoMap = new Dictionary<string, string>();
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private string GetSecName(string secCd)
        {
            string cd = secCd.Trim().PadLeft(2, '0');
            return this.secInfoMap.ContainsKey(cd) ? this.secInfoMap[cd] : String.Empty;
        }

        /// <summary>
        /// �q�ɖ��擾����
        /// </summary>
        /// <param name="sectionCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ�</returns>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�ɊY�����鋒�_�����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCd)
        {
            // �q�ɃR�[�h�������ꍇ�́A�󕶎���ԋp����
            if (String.IsNullOrEmpty(warehouseCd))
            {
                return String.Empty;
            }

            // �q�ɃR�[�h�����͂���Ă���ꍇ�́A�Y������R�[�h������ꍇ�͕R�t���q�ɖ��̂�
            // �Y���R�[�h�������ꍇ�͖��o�^���Ăяo�����ɕԋp����
            string cd = warehouseCd.Trim().PadLeft(this.codeLength, '0');
            return this.warehouseInfoMap.ContainsKey(cd) ? this.warehouseInfoMap[cd] : this.noWarehouseName;
        }

        /// <summary>
        /// �ꊇ�ݒ���͗��ݒ�l����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������ɕێ����Ă���ꊇ�ݒ�œ��͂����e���ڂ̒l�����������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private void InitAllSttngPrevValMap()
        {
            // �C���X�^���X����������Ă��Ȃ��ꍇ�́A�C���X�^���X�𐶐����s����������Map�̏��������s���܂��B
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
                        // ���l�ȊO�́Akey�F�ꊇ�ݒ�̎��(AllSettingType)�Avalue�F0�ŏ��������܂��B
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void Clear()
        {
            // ���o�����̃N���A
            this.InitControl(this.pnlCondtion);

            // �ꊇ�ݒ�̃N���A
            this.InitControl(this.pnlCllctvSttng);

            // �O���b�h�̃N���A
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            // �X�e�[�^�X�o�[��������Ԃɖ߂��܂��B
            this.InitStatusBar();

            // �X�V�ς݃t���O��off�ɂ��܂��B
            this.isUpdate = false;
            // �ҏW�ς݃t���O��off�ɂ��܂��B
            this.isEdit = false;

            // �������ɕۑ����Ă���ꊇ�ݒ�̊e���ڂ̓��͓��e�����������܂��B
            this.InitAllSttngPrevValMap();

            // �t�H�[�J�X��擪�ɖ߂��܂�
            this.tNdtWrHsCdStart.Focus();
        }

        /// <summary>
        /// �R���g���[������������
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : TEdit�ATNedit�AUltraOptionSet�AUltraWinGrid�̓��e�����������܂��B</br>
        /// <br>             ��L�ȊO�̃R���g���[���̏ꍇ�A�z���̃R���g���[�����ċA�I�ɌĂяo����</br>
        /// <br>             �q�R���g���[���������Ȃ�܂ŒT���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void InitControl(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TEdit || child is TNedit)
                {
                    // �G�f�B�b�g�֌W�̃R���g���[���͓��e���N���A���܂�
                    child.Text = String.Empty;
                }
                else if (child is UltraOptionSet)
                {
                    // ���W�I�{�^���͓��l��I�����܂�
                    UltraOptionSet optSet = child as UltraOptionSet;
                    optSet.FocusedIndex = (int)AllSettingType.Equivalence;
                    optSet.Value = (int)AllSettingType.Equivalence;
                }
                else
                {
                    // ����ȊO�̏ꍇ�͍ċA�I�ɃR���g���[�����Ăяo���܂�
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
        /// <br>Date       : 2016/02/18<</br>
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

        #region -- grid�֘A�̃��\�b�h --

        /// <summary>
        /// �O���b�h�R���g���[������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�R���g���[���̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void InitGrid()
        {
            // �e�[�u���̍쐬���A�O���b�h�Ƀo�C���h���܂��B
            this.ultrGrid.DataSource = new DataView(this.CreateDataTable());
            // �O�ρA�e��ݒ�̏�����
            this.InitGridLayout();
            // �J�����̏�����
            this.InitGridColumns();
            // �O���b�h�L�[�}�b�s���O�ݒ菈��(���������A�@Shift + Enter���t�H�[�J�X�J��)
            this.MakeKeyMappingForGrid(this.ultrGrid);
        }

        /// <summary>
        /// �O���b�h�O�Ϗ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̊O�ς̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
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
            this.ultrGrid.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            #endregion
        }

        /// <summary>
        /// �O���b�h�J��������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�����̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void InitGridColumns()
        {
            ColumnsCollection columns = this.ultrGrid.DisplayLayout.Bands[0].Columns;
            // No.
            UltraGridColumn column = columns[GridSettingInfo.COL_NO];
            this.SetColInfo(column, GridSettingInfo.COL_NO_WIDTH, GridSettingInfo.COL_NO_CAP,
                this.hdrGrpKeyNo, Infragistics.Win.HAlign.Right, false, null);
            // ��̌Œ艻
            column.Header.Fixed = true;
            column.Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            column.CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            column.CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            column.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            column.CellAppearance.ForeColor = Color.White;
            column.CellAppearance.ForeColorDisabled = Color.White;

            // �_���폜��
            column = columns[GridSettingInfo.COL_LDEL];
            this.SetColInfo(column, 0, GridSettingInfo.COL_LDEL_NM, this.hdrGrpKeyNo, Infragistics.Win.HAlign.Right, false, null);
            // �_���폜��͔�\���ɂ��܂�
            column.Hidden = true;

            // �ύX�O�q�ɃR�[�h
            column = columns[GridSettingInfo.COL_BF_CD];
            this.SetColInfo(column, GridSettingInfo.COL_BF_CD_WIDTH, GridSettingInfo.COL_CD_CAP,
                this.hdrGrpKeyBefore, Infragistics.Win.HAlign.Right, false, "0000");
            
            // �ύX�O�q�ɖ�
            column = columns[GridSettingInfo.COL_BF_NM];
            this.SetColInfo(column, GridSettingInfo.COL_BF_NM_WIDTH, GridSettingInfo.COL_NM_CAP,
                this.hdrGrpKeyBefore, Infragistics.Win.HAlign.Left, false, null);
            
            // �ύX��q�ɃR�[�h
            column = columns[GridSettingInfo.COL_AF_CD];
            this.SetColInfo(column, GridSettingInfo.COL_AF_CD_WIDTH, GridSettingInfo.COL_CD_CAP,
                this.hdrGrpKeyAfter, Infragistics.Win.HAlign.Right, true, "0000;0000; ");
            column.NullText = String.Empty;
            column.MaxLength = 4;
            
            // �ύX��q�ɖ�
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void SetColInfo(UltraGridColumn col, int width, string caption,
            string blngGrp, Infragistics.Win.HAlign hAlign, Boolean isAllowEdit, string format)
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
            this.ultrGrid.DisplayLayout.Bands[0].Groups[blngGrp].Columns.Add(col);
        }

        /// <summary>
        /// �f�[�^�e�[�u���쐬����
        /// </summary>
        /// <remarks>
        /// <returns>�e�[�u���I�u�W�F�N�g</returns>
        /// <br>Note       : �f�[�^�e�[�u���̍쐬���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable(GridSettingInfo.TBL_NAME);
            // No.
            table.Columns.Add(GridSettingInfo.COL_NO, typeof(int));
            // �_���폜��
            table.Columns.Add(GridSettingInfo.COL_LDEL, typeof(LogicalDeleteType));
            // �ϊ��O�q�ɃR�[�h
            table.Columns.Add(GridSettingInfo.COL_BF_CD, typeof(int));
            // �ϊ��O�q�ɖ�
            table.Columns.Add(GridSettingInfo.COL_BF_NM, typeof(string));
            // �ϊ���q�ɃR�[�h
            table.Columns.Add(GridSettingInfo.COL_AF_CD, typeof(int));
            // �ϊ���q�ɖ�
            table.Columns.Add(GridSettingInfo.COL_AF_NM, typeof(string));

            return table;
        }

        /// <summary>
        /// �O���b�h�\�����Z�b�g����
        /// </summary>
        /// <param name="warehouseList">�q�ɏ��ꗗ</param>
        /// <returns>�e�[�u���I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɕ\������f�[�^���Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void SetDataToGrid(List<WarehouseDispInfo> warehouseList)
        {
            // �f�[�^�e�[�u���Ƀf�[�^���Z�b�g���܂�
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            // �s�f�[�^
            DataRow dr = null;
            int no = 1;
            warehouseList.ForEach(delegate(WarehouseDispInfo wk)
            {
                // �s�̒ǉ�
                dr = table.NewRow();
                // No.��
                dr[GridSettingInfo.COL_NO] = no++;
                // �_���폜��
                LogicalDeleteType delType = (LogicalDeleteType)Enum.ToObject(typeof(LogicalDeleteType), wk.LogicalDelete);
                dr[GridSettingInfo.COL_LDEL] = delType;
                // �ϊ��O�q�ɃR�[�h
                dr[GridSettingInfo.COL_BF_CD] = wk.WarehouseCode;
                // �q�ɖ���
                dr[GridSettingInfo.COL_BF_NM] = wk.WarehouseName;             
                table.Rows.Add(dr);
                // �_���폜�ς݂ł���΁A�����F��ԐF�ɕύX
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
        /// <br>Date       : 2016/02/18</br>
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

        #region -- �����֘A --

        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void Search()
        {
            // ���o����������DB����f�[�^���擾���܂��B
            List<WarehouseDispInfo> searchResult = new List<WarehouseDispInfo>();
            try
            {
                // ���o�����ɕs���Ȓl�����͂���Ă��Ȃ����`�F�b�N���܂��B
                if (!this.IsAllowSeachCondition())
                {
                    return;
                }

                // �X�e�[�^�X�o�[��������Ԃɖ߂��܂��B
                this.InitStatusBar();

                // �v���O���X�_�C�A���O��\�����܂�
                this.ShowProgressDlg(MessageMng.INFO_MES_010, MessageMng.INFO_MES_011, true);              
                // �����X�e�[�^�X�������A���������ʂ�0���ł͂Ȃ��Ƃ��͎擾���ʂ�
                // �O���b�h�ɕ\�����܂�
                int status = this.warehouseCnvAcs.SearchWarehouse(this.SetSearchCondition(), searchResult);
                this.SetDataToGrid(searchResult);                
                // �X�V�ς݃t���O��off�ɂ��܂��B
                this.isUpdate = false;
                // �ҏW�ς݃t���O��off�ɂ��܂��B
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
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <returns>���茋��(true:OK/false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ���o�����Ƃ��āB</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private bool IsAllowSeachCondition()
        {
            // ���͂��ꂽ�l�����l�ł��邩���`�F�b�N���܂��B
            if (this.IsNotNumber(this.tNdtWrHsCdStart) || this.IsNotNumber(this.tNdtWrHsCdEnd))
            {
                return false;
            }    

            // ���o�����ŊJ�n�ƏI���̒l���t�]���Ă��Ȃ������`�F�b�N���܂�
            if ((this.tNdtWrHsCdStart.GetInt() != 0 && this.tNdtWrHsCdEnd.GetInt() != 0) 
                && (this.tNdtWrHsCdStart.GetInt() > this.tNdtWrHsCdEnd.GetInt()))
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
        /// <br>Date       : 2016/02/18</br>
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
        /// ���o�����Z�b�g����
        /// </summary>
        /// <returns>���o����</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵���������Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private WarehouseConvertDispInfo SetSearchCondition()
        {
            WarehouseConvertDispInfo dispInfo = new WarehouseConvertDispInfo();
            // ��ƃR�[�h
            dispInfo.EnterpriseCode = this.enterPriseCd;
            // ���͗����A�N�e�B�u�̏�ԂŌ����{�^���������������́A�R�[�h���[���p�f�B���O�����
            // ���Ȃ��ׁA�����ł��[���p�f�B���O���s���܂��B
            // �q�ɃR�[�h(�J�n)           
            dispInfo.WarehouseCdStart = this.ZeroPadding(this.tNdtWrHsCdStart.Text.Trim());
            // �q�ɃR�[�h(�I��)
            dispInfo.WarehouseCdEnd = this.ZeroPadding(this.tNdtWrHsCdEnd.Text.Trim());

            return dispInfo;
        }

        /// <summary>
        /// �R�[�h�[�����ߏ���
        /// </summary>
        /// <param name="trgVal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �R�[�h���u0001�v�̂悤�Ƀ[�����߂��܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private string ZeroPadding(string trgVal)
        {
            return String.IsNullOrEmpty(trgVal) ? String.Empty : trgVal.Trim().PadLeft(4, '0');
        }

        #endregion

        #region -- �R�[�h�ϊ��֘A --

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɑq�ɃR�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void ConvertWarehouseCode()
        {
            try
            {
                // ���ɃR���o�[�g�ς݂����`�F�b�N���܂�
                if (this.isUpdate)
                {
                    this.ShowExclamation(MessageMng.INFO_MES_006);
                    return;
                }

                // �R���o�[�g���������s����O�ɃR���o�[�g�������s�����ۂ������[�U��
                // �₢���킹�܂��B
                if (this.ShowInfo(MessageMng.INFO_MES_004) == DialogResult.Cancel)
                {
                    return;
                }

                // �R���o�[�g�Ώۂ̃f�[�^���L�邩�ǂ������`�F�b�N���܂��B
                if (!this.hasConvertData())
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private bool hasConvertData()
        {
            // �O���b�h�ɃR���o�[�g�ΏۂƂȂ�f�[�^�����݂��邩�m�F���܂��B
            if (this.ultrGrid.Rows.Count != 0)
            {
                // �O���b�h�Ƀf�[�^���L��ꍇ�A�ϊ���̑q�ɃR�[�h��ɓ��͒l�����邩�ǂ������m�F���܂��B
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    // ��ł͂Ȃ��Z���𔭌������珈���𔲂��܂�
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()) && 
                        !this.IsCodeZero(row) && !this.IsBfCdAndAfCdSameValue(row))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// �X�e�[�^�X�o�[����������
        /// </summary>
        /// <param name="cnvTrgTblCount">�R�[�h�ϊ��Ώۃe�[�u���̌���</param>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�������s���O���ɃX�e�[�^�X�o�[�̏��������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void InitStatusBar(int cnvTrgTblCount)
        {            
            // ��ʂ̕`����ꎞ��~���܂��B
            this.SuspendLayout();

            // �v���O���X�o�[�̏��������܂��B
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].Visible = true;
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS];
            // �v���O���X�o�[�̍ŏ��l�ƍő�l��ݒ肵�܂��B
            pnl.ProgressBarInfo.Minimum = 0;
            pnl.ProgressBarInfo.Maximum = cnvTrgTblCount;
            pnl.ProgressBarInfo.Value = 0;
            pnl.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;

            // �X�e�[�^�X�̈�����������܂��B
            pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS];
            pnl.Text = MessageMng.INFO_MES_001;
            pnl.Appearance.ForeColor = Color.Black;

            // ��ʂ̕`����ĊJ���܂��B
            this.ResumeLayout(false);
        }

        /// <summary>
        /// ���͒l�`�F�b�N����
        /// </summary>
        /// <returns>���茋��(true:OK/false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵���R�[�h�ϊ��̓��͒l�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private bool IsAllowData()
        {
            // �`�F�b�N�ς݂̃R�[�h��ۑ�����ϐ�
            IDictionary<string, EmployeeInputData> checkedCodeMap = new Dictionary<string, EmployeeInputData>();

            // ���͂����ϊ���R�[�h��4���ȓ��A���͓��͂����l���ŏd�������l���������`�F�b�N���܂�
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // �Z������R�[�h���擾���܂�
                string code = String.Format(PMKHN05101UA.cdFormat, row.Cells[GridSettingInfo.COL_AF_CD].Value);
                // �����`�F�b�N                
                if (code.Length > this.codeLength)
                {
                    this.SetFocusErrorCell(row, MessageMng.ERR_MES_007);
                    return false;
                }

                // �ύX��q�ɃR�[�h�������͂̏ꍇ�A�ύX�O�̑q�ɃR�[�h���d�����Ȃ����`�F�b�N���܂�
                if (String.IsNullOrEmpty(code) || Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) == 0)
                {
                    code = String.Format(PMKHN05101UA.cdFormat, Convert.ToUInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value));
                }

                // �d���`�F�b�N
                if (checkedCodeMap.ContainsKey(code))
                {
                    // �d�����Ă����ꍇ�́A���b�Z�[�W��\�����ď����𒆎~
                    this.SetFocusErrorCell(row, MessageMng.ERR_MES_008);
                    return false;
                }
                else
                {
                    // �`�F�b�N�ς݂̃R�[�h��ۑ����܂�
                    EmployeeInputData inputData = new EmployeeInputData();
                    inputData.BfEmployeeCode = String.Format(PMKHN05101UA.cdFormat, Convert.ToUInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value));
                    inputData.AfEmployeeCode = code;
                    inputData.RowIndex = row.Index;
                    checkedCodeMap[code] = inputData;

                    //�@�`�F�b�N�ς݃R�[�h�}�b�v�ɕϊ��O�̃R�[�h�����邩�𔻒�
                    if (inputData.IsEdit() && checkedCodeMap.ContainsKey(inputData.BfEmployeeCode))
                    {
                        // �`�F�b�N�ς݃R�[�h�}�b�v�ɂ������ꍇ�́A�`�F�b�N�ς݃R�[�h�Ƃ�
                        // �����ł���ׁA�R�[�h�̌��������������Ƃ������t���O��on�ɂ��܂��B
                        checkedCodeMap[inputData.BfEmployeeCode].SetOtherCodeChange(inputData.BfEmployeeCode, inputData.AfEmployeeCode);
                        checkedCodeMap[code].SetOtherCodeChange(checkedCodeMap[inputData.BfEmployeeCode].BfEmployeeCode,
                            checkedCodeMap[inputData.BfEmployeeCode].AfEmployeeCode);
                    }
                }
            }

            // �O���b�h�̏�񂪑q�Ƀ}�X�^�̃f�[�^�����ƈ�v���Ȃ��ꍇ�́A���o�����ŕ\��������
            // �i���Ă���ׁA�\������Ă��Ȃ��R�[�h�ɂ��Ă��d�����Ȃ������肵�܂�
            // �܂��A��x�X�V�����ꍇ�����l�Ƀ`�F�b�N���܂��B
            if ((this.isUpdate) || (this.ultrGrid.Rows.Count != this.warehouseInfoMap.Count))
            {
                foreach (string checkedCode in checkedCodeMap.Keys)
                {
                    int index = checkedCodeMap[checkedCode].RowIndex;
                    if (checkedCodeMap[checkedCode].IsEdit() && !checkedCodeMap[checkedCode].IsOtherCodeChange
                         && this.warehouseInfoMap.ContainsKey(checkedCode))
                    {
                        this.SetFocusErrorCell(this.ultrGrid.Rows[index], MessageMng.ERR_MES_008);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// �G���[�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <param name="errMes">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���̓`�F�b�N�ŃG���[�����������Z���Ƀt�H�[�J�X���Z�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void SetFocusErrorCell(UltraGridRow row, string errMes)
        {
            this.ultrGrid.Focus();
            row.Cells[GridSettingInfo.COL_AF_CD].Activate();
            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            this.ShowExclamation(errMes);
        }

        /// <summary>
        /// ���O�ۑ���f�B���N�g���쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O��ۑ�����f�B���N�g�������݂��Ȃ��ꍇ�A�f�B���N�g���̍쐬���s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private void CreateLogSaveDir()
        {
            // ���O�ۑ��f�B���N�g�������݂��邩�m�F���A�����ꍇ�̓f�B���N�g�����쐬���܂��B
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05101UA.LOG_DIR_PATH);
            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(dirInfo.FullName);
            }
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
        /// <br>Date       : 2016/02/18</br>
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private DialogResult ShowExclamation(string mes)
        {
            // �x�����b�Z�[�W��\�����܂�
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private DialogResult ShowInfo(string mes)
        {
            // �C���t�H���b�Z�[�W��\�����܂��B
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private DialogResult ShowMessage(emErrorLevel errLevel, MessageBoxButtons btn, string mes, int status)
        {
            return TMsgDisp.Show(errLevel, this.pgId, mes, status, btn);
        }

        #endregion

        #region -- ���̑� --

        /// <summary>
        /// ���̃Z�b�g����
        /// </summary>
        /// <param name="tNEdit">�R�[�h���͗�</param>
        /// <param name="tEdit">���̗�</param>
        /// <remarks>
        /// <br>Note       : �R�[�h���͗��œ��͂����R�[�h�ɑΉ����閼�̂𖼏̗��ɃZ�b�g���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void SetName(TNedit tNEdit, TEdit tEdit)
        {
            string warehouseCd = tNEdit.Text.Trim();
            string warehouseNm = this.GetWarehouseName(warehouseCd);
            tEdit.Text = warehouseNm == this.noWarehouseName ? String.Empty : warehouseNm;
            if (!String.IsNullOrEmpty(warehouseCd))
            {
                tNEdit.Text = tNEdit.Text.Trim().PadLeft(this.codeLength, '0');
            }
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void SetFocusEditCellFromNoUltraGrid(int rowIndex, ChangeFocusEventArgs e)
        {
            // ���̃R���g���[����UltraGrid�̎��̂ݎ��{���܂��B
            if (e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
            {
                e.NextCtrl = null;
                // UltraGrid�Ƀt�H�[�J�X�𓖂āArowIndex�Ŏw�肵���s�̕ύX��Z����
                // �A�N�e�B�u�ɂ��܂��B
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void SetFocusEeditCellInUltraGrid(int cmpRowIndex, Control nextCtrl,
            UltraGridAction gridAction, ChangeFocusEventArgs e)
        {
            // NextCtrl��null���Z�b�g���܂�
            e.NextCtrl = null;
            if (this.ultrGrid.ActiveCell.Row.Index == cmpRowIndex)
            {
                // NextCtrl�Ɏ��ɑJ�ڂ������R���g���[�����Z�b�g���܂�
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
        /// <br>Date       : 2016/02/18<</br>
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

        /// <summary>
        /// �ꊇ�ݒ���͗�����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ꊇ�ݒ���͗��̏��������s���܂��B</br>
        /// <br>             Tag�ɂ��ꂼ��̓��͗����ǂ̈ꊇ�ݒ��\���񋓎q��ݒ肵�܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void ultrEgbCllctvSttng_ExpandedStateChanged(object sender, EventArgs e)
        {
            // �C�x���g�\�[�X��UltraExpandableGroupBox�ɕϊ����܂�
            UltraExpandableGroupBox edgGrpBox = sender as UltraExpandableGroupBox;
            // UltraExpandableGroupBox�̎��̂ݏ��������{���܂��B
            if (edgGrpBox != null)
            {
                // �W�J�E�k���ɉ����ăp�l���̃T�C�Y��ύX���܂�
                Size pnlSize = new Size();
                pnlSize.Width = edgGrpBox.Parent.Size.Width;
                pnlSize.Height = edgGrpBox.Expanded ?
                    (this.egbGrpBoxHeighMap[(EgbGrpBoxType)edgGrpBox.Tag]) : this.egbGrpBoxCntrctSize;
                edgGrpBox.Parent.Size = pnlSize;
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void tArrwKyCntrl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
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
                            this.SetFocusEeditCellInUltraGrid(this.ultrGrid.Rows.Count - 1, 
                                this.tNdtWrHsCdStart, UltraGridAction.NextCell, e);
                        }
                        else
                        {
                            // �O�̃Z�����A�N�e�B�u�Z���ɂ��܂��B
                            this.SetFocusEeditCellInUltraGrid(this.firstRow, this.ultrBtnSttng,
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
                        // 1�s�ڂ̕ϊ���R�[�h���A�N�e�B�u�ɂ��܂�
                        this.ultrGrid.ActiveRow.Cells[GridSettingInfo.COL_AF_CD].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                else
                {
                    // ���l���ړ��͗��ł���΁A�q�ɃR�[�h(�J�n)���͗��Ƀt�H�[�J�X���Z�b�g
                    if (e.NextCtrl is TNedit)
                    {
                        this.tNdtWrHsCdStart.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtWrHsCdStart)
            {
                // �q�ɃR�[�h���擾���l������ꍇ�́A�q�ɖ��̂��Z�b�g����
                this.SetName(this.tNdtWrHsCdStart, this.tEdtWrHsNmStart);

                // �t�H�[�J�X�𐧌䂵�܂��B
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
            else if (e.PrevCtrl == this.tNdtWrHsCdEnd)
            {
                // �q�ɃR�[�h���擾���l������ꍇ�́A�q�ɖ��̂��Z�b�g����
                this.SetName(this.tNdtWrHsCdEnd, this.tEdtWrHsNmEnd);
                if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    // ���W�I�{�^���̃t�H�[�J�X�����݃`�F�b�N���Ă��鍀�ڂɕύX���܂�
                    this.ultrRbtnCllctvSttng.FocusedIndex = this.ultrRbtnCllctvSttng.CheckedIndex;
                }
            }
            else if (e.PrevCtrl == this.ultrBtnSttng)
            {
                // �O���b�h�̐擪�s���A�N�e�B�u�ȃZ���ɂ��܂��B
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    this.tNdtWrHsCdEnd.Focus();
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
                        this.tNdtWrHsCdStart.Focus();
                    }
                    else if (e.Key == Keys.Left)
                    {
                        this.tNdtSerNum.Focus();
                    }
                } 
            }
            else if (e.PrevCtrl == this.tNdtWrHsCdStart)
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
                        this.tNdtWrHsCdStart.Focus();
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void PMKHN05101UA_KeyDown(object sender, KeyEventArgs e)
        {
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void ultrGrid_KeyDown(object sender, KeyEventArgs e)
        {
            // �Z�����A�N�e�B�u��ԂŁA���ҏW���[�h�̂Ƃ��ɂ̂ݏ������s���܂�
            if (this.ultrGrid.ActiveCell != null && this.ultrGrid.ActiveCell.IsInEditMode)
            {
                int activeRowIndex = this.ultrGrid.ActiveCell.Row.Index;
                int activeColIndex = this.ultrGrid.ActiveCell.Column.Index;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        // ���̃Z���A�܂��̓R���g���[���Ƀt�H�[�J�X���Z�b�g���܂��B
                        this.SetFocusEditCellOnKeyDown(this.firstRow, this.ultrBtnSttng, UltraGridAction.AboveCell, e); 
                        break;
                    case Keys.Down:
                        // �O�̃Z���A�܂��̓R���g���[���Ƀt�H�[�J�X���Z�b�g���܂��B
                        //this.SetFocusEditCellOnKeyDown(this.ultrGrid.Rows.Count - 1, this.tNdtWrHsCdStart,
                        //    UltraGridAction.BelowCell, e);
                        this.SetFocusEditCellOnKeyDown(this.ultrGrid.Rows.Count - 1, null,
                            UltraGridAction.BelowCell, e);
                        break;
                    default:
                        break;
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void ultrGrid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {                        
            UltraGrid grid = sender as UltraGrid;
            // �Z���̏�Ԃ�null�̏ꍇ�́A�㑱�̏��������s���܂���B
            if (grid.ActiveCell.Value == null)
            {
                return;
            }

            // ���l�����͂��ꂽ�ꍇ�́A�[���p�f�B���O���܂��B
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void ultrGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGridRow row = e.Cell.Row as UltraGridRow;
            // �ϊ���̒l���󕶎��A���͔񐔒l�ł���Αq�ɖ����󔒂ɂ��܂��B
            if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()))
            {
                row.Cells[GridSettingInfo.COL_AF_NM].Value = String.Empty;
            }
            else
            {
                // ���͂��ꂽ�l����A�Y������q�ɖ����Z�b�g���܂��B�����ꍇ�͖��o�^��\�����܂��B
                row.Cells[GridSettingInfo.COL_AF_NM].Value = this.GetWarehouseName(
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
        /// <br>Date		: 2016/03/01</br>
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

        #region  -- �X���b�h�֘A --

        /// <summary>
        /// �o�b�N�O�����h�̃C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �o�b�N�O���E���h�ŏ��������s����Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void bgWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // XML����R�[�h�ϊ��̑ΏۂƂȂ�e�[�u�����擾���܂�
                IDictionary<string, TargetTableListResult> trgTblMap = new Dictionary<string, TargetTableListResult>();
                status = this.warehouseCnvAcs.GetConvertTableList(trgTblMap);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (status)
                    {
                        case PMKHN05101UA.ILLEGAL_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_014;
                            break;
                        case PMKHN05101UA.NO_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_013;
                            break;
                        case PMKHN05101UA.NO_FILE:
                            this.cnvErrMes = MessageMng.ERR_MES_015;
                            break;
                        default:
                            this.cnvErrMes = String.Empty;
                            break;
                    }
                    e.Cancel = true;
                    return;
                }

                // �R�[�h�ϊ��Ώۂ̃f�[�^���O���b�h����擾���܂�
                IList<WarehouseConvertData> cnvDataList = this.GetConvertData();

                // �X�e�[�^�X�o�[�����������܂��B
                this.Invoke(new InitStatusBarDelegate(this.InitStatusBar), trgTblMap.Count);

                // �e�[�u���P�ʂŃR�[�h�̕ϊ������{���܂��B
                int index = 0;
                long prcssngCnt;
                long ttlPrcssngCnt = 0;
                int maxTbl = trgTblMap.Count;
                // ���O���o�͂��܂��B
                using (FileStream fs = new FileStream(this.CreateLogFilePath(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //���엚�����O�ɓ��l�̓��e���o�͂��Ă����܂��B
                        OperationHistoryLog opLog = new OperationHistoryLog();
                        string pgid = "PMKHN05100U";
                        string pgnm = "�q�ɃR�[�h�ϊ�";

                        // ���������Ԃ��v������Stopwatch
                        Stopwatch totalProcessingTime = new Stopwatch();
                        // �ʂ̃e�[�u���̏������Ԃ��v������Stopwatch
                        Stopwatch processingTime = new Stopwatch();

                        sw.WriteLine(this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_START, new String[0]));
                        opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                            this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_START, new String[0]), "");

                        // �����������Ԃ̌v���J�n���܂��B
                        totalProcessingTime.Start();
                        foreach (string table in trgTblMap.Keys)
                        {
                            prcssngCnt = 0;
                            // �R�[�h�ϊ��O�ɃX�e�[�^�X�o�[���X�V���܂��B
                            Invoke(new UpdateStatusBarDelegate(this.UpdateStatusBar),
                                String.Format(MessageMng.INFO_MES_005, trgTblMap[table].TargetTableName, index, maxTbl));
                            // �ʃe�[�u���̏����������v���J�n���܂��B
                            processingTime.Start();

                            // �R�[�h�ϊ����������s���܂�
                            status = this.warehouseCnvAcs.ConvertWarehouse(trgTblMap[table], cnvDataList, this.enterPriseCd, ref prcssngCnt);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sw.WriteLine(this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_ERROR, new string[] { trgTblMap[table].TargetTableName }));
                                opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                    this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_ERROR, new string[] { trgTblMap[table].TargetTableName }), "");
                                e.Cancel = true;
                                break;
                            }

                            processingTime.Stop();
                            ttlPrcssngCnt += prcssngCnt;
                            // �X�̏��������A�������Ԃ����O�ɏo�͂��܂��B
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] { trgTblMap[table].TargetTableName, prcssngCnt.ToString(), 
                                    new DateTime (0).Add(processingTime.Elapsed).ToString(PMKHN05101UA.LOG_FORMAT_PROCESSING_TIME) }));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] { trgTblMap[table].TargetTableName, prcssngCnt.ToString(), 
                                    new DateTime (0).Add(processingTime.Elapsed).ToString(PMKHN05101UA.LOG_FORMAT_PROCESSING_TIME) }), "");

                            // �ϊ��I������X�e�[�^�X�o�[���X�V���܂��B
                            this.bgWrkr.ReportProgress(++index,
                                String.Format(MessageMng.INFO_MES_005, trgTblMap[table].TargetTableName, index, maxTbl));

                            // �ʃe�[�u���̏������Ԃ��v������Stopwatch�����Z�b�g���܂��B
                            processingTime.Reset();
                        }
                        totalProcessingTime.Stop();
                        // ���������������O�ɏo�͂��܂��B
                        if (!e.Cancel)
                        {
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05101UA.LOG_FORMAT_PROCESSING_TIME),
                                    ttlPrcssngCnt.ToString() }));
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_END, new String[0]));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05101UA.LOG_FORMAT_PROCESSING_TIME),
                                    ttlPrcssngCnt.ToString() }), "");
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05101UA.LOG_FORMAT_END, new String[0]), "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.cnvErrMes = ex.Message;
                e.Cancel = true;
            }
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
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private string GenerateLogFormat(string format, string[] prms)
        {
            List<string> prmList = new List<string>();
            prmList.Add(DateTime.Now.ToString(PMKHN05101UA.DATE_FORMAT));
            foreach (string prm in prms)
            {
                prmList.Add(prm);
            }

            return String.Format(format, prmList.ToArray());
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃf�[�^�擾����
        /// </summary>
        /// <returns>�R�[�h�ϊ��Ώۂ̃f�[�^�̃��X�g</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ��̑ΏۂƂȂ��Ă���f�[�^���O���b�h����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private IList<WarehouseConvertData> GetConvertData()
        {
            // �R�[�h�ϊ��Ώۂ̃f�[�^���O���b�h����擾���܂�
            IList<WarehouseConvertData> cnvDataList = new List<WarehouseConvertData>(this.ultrGrid.Rows.Count);
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // �ύX��q�ɃR�[�h�񂩂�l���擾���A�l�������ꍇ�͎��̍s��
                if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()) ||
                        this.IsCodeZero(row) || this.IsBfCdAndAfCdSameValue(row))
                {
                    continue;
                }

                // �X�V������ۑ����܂��B
                WarehouseConvertData cnvData = new WarehouseConvertData();
                // �ύX�O�q�ɃR�[�h
                cnvData.BfWarehouseCd = String.Format(PMKHN05101UA.cdFormat, row.Cells[GridSettingInfo.COL_BF_CD].Value);
                // �ύX��q�ɃR�[�h
                cnvData.AfWarehouseCd = String.Format(PMKHN05101UA.cdFormat, row.Cells[GridSettingInfo.COL_AF_CD].Value);
                cnvDataList.Add(cnvData);
            }

            return cnvDataList;
        }

        /// <summary>
        /// ���O�t�@�C���p�X�쐬����
        /// </summary>
        /// <returns>���O�t�@�C���̐�΃p�X</returns>
        /// <remarks>
        /// <br>Note       : ���O�t�@�C���̐�΃p�X���쐬���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private string CreateLogFilePath()
        {
            // �f�B���N�g�������쐬
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05101UA.LOG_DIR_PATH);
            // ���O�t�@�C�������쐬
            string fileName = String.Format(PMKHN05101UA.LOG_FILE_NAME, 
                DateTime.Now.ToString(PMKHN05101UA.LOG_FORMAT_DATE));

            return Path.Combine(dirInfo.FullName, fileName);
        }

        /// <summary>
        /// �ύX��q�ɃR�[�h���菈��(0�`�F�b�N)
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <returns>true:0/false:��0</returns>
        /// <remarks>
        /// <br>Note       : �ϊ���̒l��0�ł��邩�ۂ��𔻒肵�܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private bool IsCodeZero(UltraGridRow row)
        {
            return Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()) == 0 ?
                true : false;
        }

        /// <summary>
        /// �ύX�O�A�ύX��q�ɃR�[�h���菈��(����l�`�F�b�N)
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <returns>true:����l/false:�񓯈�l</returns>
        /// <remarks>
        /// <br>Note       : �ύX�O�ƕύX��̃R�[�h������ł��邩�ǂ������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private bool IsBfCdAndAfCdSameValue(UltraGridRow row)
        {
            return Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value)
                == Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) ? true : false;
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�X�V����
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���X�V���邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void UpdateStatusBar(string mes)
        {
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = mes;
        }

        /// <summary>
        /// ReportProgress�C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ReportProgress���\�b�h���R�[���������ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
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
        /// <br>Date       : 2016/02/18<</br>
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
                    // �X�e�[�^�X�o�[�̍X�V
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_003;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Red;
                    // �G���[���b�Z�[�W��\��
                    string errMes = String.IsNullOrEmpty(this.cnvErrMes) ? MessageMng.ERR_MES_006 : this.cnvErrMes;
                    this.ShowError(errMes, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    this.cnvErrMes = String.Empty;
                }
                else
                {
                    // �X�e�[�^�X�o�[���X�V
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value =
                        this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Maximum;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_002;

                    // �������̓������Ɋi�[���Ă���d���`�F�b�N���ɗp����}�b�v�f�[�^���ŐV�����܂�
                    this.GetWarehouseInfo();

                    // ������������t���O��on�ɂ��܂��B
                    isSuccess = true;

                    // �X�V�ς݃t���O��on�ɂ��܂�
                    this.isUpdate = true;

                    // �ҏW�ς݃t���O��off�ɂ��܂�
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
                    // �o�^�����_�C�A���O��\�����܂�
                    using (SaveCompletionDialog dlg = new SaveCompletionDialog())
                    {
                        dlg.ShowDialog(2);
                    }
                }

                // FormCloing�C�x���g����R�[�����ꂽ�ꍇ�́A�t�H�[������܂�
                if (isSuccess && this.isCallFormCloseingEvent)
                {
                    ((Form)this.Parent).Close();
                }
            }
        }

        /// <summary>
        /// �v���O���X�_�C�A���O�\������
        /// </summary>
        /// <param name="mess">���b�Z�[�W</param>
        /// <param name="title">�_�C�A���O�^�C�g��</param>
        /// <param name="canCancel">�L�����Z���̉�(true:�L�����Z���\/false:�L�����Z���s��)</param>
        /// <remarks>
        /// <br>Note       : �v���O���X�_�C�A���O��\�����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void ShowProgressDlg(string title, string mess, bool canCancel)
        {
            // �v���O���X�_�C�A���O��\�����܂��B
            if (this.procDlg == null)
            {
                this.procDlg = new SFCMN00299CA();
            }
            // �_�C�A���O�̃^�C�g����ݒ肵�܂�
            this.procDlg.Title = title;
            // �_�C�A���O�ɕ\�����郁�b�Z�[�W��ݒ肵�܂��B
            this.procDlg.Message = mess;
            // �L�����Z���{�^���̗L��
            this.procDlg.DispCancelButton = canCancel;

            // �v���O���X�_�C�A���O��\�����܂��B            
            this.procDlg.Show(this);
        }

        #endregion

        #region -- ���̑� --

        /// <summary>
        /// �t�H�[������\�����̃C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[��������\�������Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void PMKHN05101UA_Shown(object sender, EventArgs e)
        {
            // �q�ɃK�C�h���͗��J�n�Ƀt�H�[�J�X���Z�b�g
            this.tNdtWrHsCdStart.Focus();
        }

        /// <summary>
        /// �q�ɃK�C�h�{�^���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            // �q�ɃK�C�h���N��
            Warehouse warehouse = null;
            int status = this.warehouseAcs.ExecuteGuid(out warehouse, this.enterPriseCd, this.loginSecCd);

            // ����I���̎��A�q�ɃR�[�h���͗��ɃR�[�h���Z�b�g���܂�
            if (status == 0 && warehouse != null)
            {
                // �N���b�N���ꂽ�{�^�����ǂ̃{�^�����𔻒肵�A�q�ɃK�C�h����擾����
                // �l����͗��ɃZ�b�g���܂��B
                GuidButtonType btnType = (GuidButtonType)((UltraButton)sender).Tag;
                if (btnType == GuidButtonType.Start)
                {
                    // �J�n�{�^���̏ꍇ
                    this.tNdtWrHsCdStart.DataText = warehouse.WarehouseCode.Trim();
                    this.tEdtWrHsNmStart.DataText = warehouse.WarehouseName.Trim();
                    // ���̃R���g���[���Ƀt�H�[�J�X��J�ڂ��܂��B
                    tNdtWrHsCdEnd.Focus();
                }
                else
                {
                    // �I���{�^���̏ꍇ
                    this.tNdtWrHsCdEnd.DataText = warehouse.WarehouseCode.Trim();
                    this.tEdtWrHsNmEnd.DataText = warehouse.WarehouseName.Trim();
                    // ���̃R���g���[���Ƀt�H�[�J�X��J�ڂ��܂��B
                    ultrRbtnCllctvSttng.Focus();
                }
            }
        }

        /// <summary>
        /// �c�[�����j���[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �c�[�����j���[���N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        private void tTooBarMain_ToolClick(object sender, ToolClickEventArgs e)
        {
            // �t�H�[�J�X��擪�ɖ߂��܂��B
            this.tNdtWrHsCdStart.Focus();

            // �N���b�N�������j���[�ɂ���ď����𕪊�
            switch (e.Tool.Key)
            {
                // �I��
                case ToolMenuType.BTN_TOOL_CLOSE:
                    // �I���̏ꍇ�͐e�t�H�[������܂��B
                    ((Form)this.Parent).Close();
                    break;
                // ���s
                case ToolMenuType.BTN_TOOL_EXEC:
                    this.ConvertWarehouseCode();
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
        /// <br>Date       : 2016/02/18<</br>
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
                    // ���͒l�`�F�b�N�����܂�
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
                    // ���͒l�`�F�b�N�����܂�
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

            // �ϊ������s���܂�
            string cnvCode = String.Empty;
            foreach (DataRow row in tbl.Rows)
            {
                if (String.IsNullOrEmpty(row[GridSettingInfo.COL_AF_CD].ToString()) ||
                    Convert.ToInt32(row[GridSettingInfo.COL_AF_CD]) == 0)
                {
                    cnvCode = convObj.Convert(
                        Convert.ToInt32(row[GridSettingInfo.COL_BF_CD]), ref offset);

                    //�ݒ�l��0�ȉ��A�܂���MAX�𒴂��Ă�����A�ݒ肵�Ȃ��B
                    if (Convert.ToInt32(cnvCode) <= 0 || Convert.ToInt32(cnvCode) > 9999)
                    {
                        continue;
                    }

                    // �ϊ���q�ɃR�[�h
                    row[GridSettingInfo.COL_AF_CD] = cnvCode;
                    // �ϊ���q�ɖ���
                    row[GridSettingInfo.COL_AF_NM] = this.GetWarehouseName(cnvCode);
                    // �ҏW�ς݃t���O��on�ɂ��܂��B
                    this.isEdit = true;
                }
            }
        }

        /// <summary>
        /// ��ʏI�����̏���
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʂ��I������Ƃ��ɃC�x���g���������܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18<</br>
        /// </remarks>
        public void PMKHN05101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �ҏW�ς݃t���O��on�̎��̂ݏ������s���܂��B
            if (this.isEdit)
            {
                // �t�H�[�J�X��擪�ɖ߂��܂��B
                this.tNdtWrHsCdStart.Focus();

                // �ύX��̑q�ɃR�[�h��œ��͂���Ă���Z���̐��𐔂��܂�
                int editedCount = 0;
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text) &&
                        Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) != 0)
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

                    // DialogResult�̌��ʂɉ����ď����𕪊򂳂��܂�
                    if (result == DialogResult.Yes)
                    {
                        // close�C�x���g���L�����Z�����܂�
                        e.Cancel = true;
                        // FormCloseing�C�x���g����R�[�h�ϊ������s����̂Ńt���O��on�ɂ��܂��B
                        this.isCallFormCloseingEvent = true;
                        // OK�������������́A�o�^�����{���Ă���I�����܂��B
                        this.ConvertWarehouseCode();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // �L�����Z���������������́A�I���������L�����Z�����܂��B
                        e.Cancel = true;
                    }
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
        /// <br>Date       : 2016/02/18<</br>
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
                    if (buf > 9999)
                    {
                        nEdit.SetValue(9999);
                    }
                }

                if (nEdit.GetInt() != 0 && this.allSttngPrevValMap[(AllSettingType)nEdit.Tag] != nEdit.GetInt())
                {
                    this.ultrRbtnCllctvSttng.Value = (int)nEdit.Tag;
                    this.ultrRbtnCllctvSttng.FocusedIndex = (int)nEdit.Tag;
                }
                // �������ɕۑ������ꊇ�ݒ�̏���ύX�������͂����l�ŏ㏑�����܂��B
                // ������or0�̏ꍇ��0�ŏ㏑�����܂��B
                this.allSttngPrevValMap[(AllSettingType)nEdit.Tag] = nEdit.GetInt();
            }
        }

        #endregion

        #endregion

        #region -- �񋓑� --

        /// <summary>
        /// UltraExpandableGroupBox�̃^�C�v��\���񋓎q
        /// </summary>
        private enum EgbGrpBoxType
        {
            // ���o�����p
            Conditon,
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

        /// <summary>
        /// PM.NS�����c�[���@�O���b�h�̌Œ�ݒ����ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̌Œ�ݒ����ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
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
            /// <br>Date       : 2016/02/18</br>
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

            /// <summary>�q�ɃR�[�h��̗�</summary>
            public const string COL_CD_CAP = "�q�ɃR�[�h";
            /// <summary>�ύX�O�q�ɃR�[�h��̎��ʎq</summary>
            public const string COL_BF_CD = "BeforeCd";
            /// <summary>�ύX��q�ɃR�[�h��̎��ʎq</summary>
            public const string COL_AF_CD = "AeforeCd";

            /// <summary>�q�ɖ���̗�</summary>
            public const string COL_NM_CAP = "�q�ɖ�";
            /// <summary>�ύX�O�q�ɖ���̎��ʎq</summary>
            public const string COL_BF_NM = "BeforeNm";
            /// <summary>�ύX��q�ɖ���̎��ʎq</summary>
            public const string COL_AF_NM = "AeforeNm";

            /// <summary>�폜�ςݗ�̗�</summary>
            public const string COL_LDEL_NM = "�폜�ς�";
            /// <summary>�폜�ςݗ�̎��ʎq</summary>
            public const string COL_LDEL = "LogicalDel";

            #endregion

            #region -- �� --

            /// <summary>No.��̗�:45</summary>
            public const int COL_NO_WIDTH = 45;
            /// <summary>�ύX�O�q�ɃR�[�h��̗�:100</summary>
            public const int COL_BF_CD_WIDTH = 100;
            /// <summary>�ύX��q�ɃR�[�h��̗�:100</summary>
            public const int COL_AF_CD_WIDTH = 100;
            /// <summary>�ύX�O�q�ɖ���̗�:275</summary>
            public const int COL_BF_NM_WIDTH = 275;
            /// <summary>�ύX��q�ɖ���̗�:275</summary>
            public const int COL_AF_NM_WIDTH = 275;

            #endregion

            #endregion
        }

        /// <summary>
        /// PM.NS�����c�[���@�c�[�����j���[�̏���ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[�����j���[�̏���ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
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
        /// <br>Date       : 2016/02/18</br>
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
            /// <summary>ERR_MES_005:�q�ɃR�[�h�̕ϊ��Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_005 = "�q�ɃR�[�h�̕ϊ��Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_006:�q�ɃR�[�h�̕ϊ��Ɏ��s���܂����B</summary>
            public const string ERR_MES_006 = "�q�ɃR�[�h�̕ϊ��Ɏ��s���܂����B";
            /// <summary>ERR_MES_007:�ϊ���R�[�h��4���ȓ��œo�^���Ă��������B</summary>
            public const string ERR_MES_007 = "�ϊ���R�[�h��4���ȓ��œo�^���Ă��������B";
            /// <summary>ERR_MES_008:�ύX��̑q�ɃR�[�h���d�����Ă��܂��B</summary>
            public const string ERR_MES_008 = "�ύX��̑q�ɃR�[�h���d�����Ă��܂��B";
            /// <summary>ERR_MES_009:�ϊ��Ώۂ̃R�[�h������܂���B</summary>
            public const string ERR_MES_009 = "�ϊ��Ώۂ̃R�[�h������܂���B";
            /// <summary>ERR_MES_010:�q�ɂ͈͎̔w�肪�s���ł��B</summary>
            public const string ERR_MES_010 = "�q�ɂ͈͎̔w�肪�s���ł��B";
            /// <summary>ERR_MES_011:�f�[�^�̎擾�Ɏ��s���܂����B</summary>
            public const string ERR_MES_011 = "�f�[�^�̎擾�Ɏ��s���܂����B";
            /// <summary>ERR_MES_012:��ʋN�����ɃG���[���������܂����B\r\n�ڍׁF{0}</summary>
            public const string ERR_MES_012 = "��ʋN�����ɃG���[���������܂����B\r\n�ڍׁF{0}";
            /// <summary>ERR_MES_013:�q�ɃR�[�h�ϊ��Ώۃt�@�C���ɑΏۂƂȂ�e�[�u��������܂���B\r\n�t�@�C�����e���������Ă��������B</summary>
            public const string ERR_MES_013 = "�q�ɃR�[�h�ϊ��Ώۃt�@�C���ɑΏۂƂȂ�e�[�u��������܂���B\r\n�t�@�C�����e���������Ă��������B";
            /// <summary>ERR_MES_014:�q�ɃR�[�h�ϊ��Ώۃt�@�C���ɕs���ȃf�[�^���L��܂��B\r\n�t�@�C���̓��e���������Ă��������B</summary>
            public const string ERR_MES_014 = "�q�ɃR�[�h�ϊ��Ώۃt�@�C���ɕs���ȃf�[�^���L��܂��B\r\n�t�@�C���̓��e���������Ă��������B";
            /// <summary>ERR_MES_015:�q�ɃR�[�h�ϊ��Ώۃt�@�C��������܂���B</summary>
            public const string ERR_MES_015 = "�q�ɃR�[�h�ϊ��Ώۃt�@�C��������܂���B";
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
            /// <summary>INFO_MES_008:�q�ɃR�[�h�ϊ�����</summary>
            public const string INFO_MES_008 = "�q�ɃR�[�h�ϊ�����";
            /// <summary>INFO_MES_009:�q�ɃR�[�h�ϊ���ϊ����ł��c</summary>
            public const string INFO_MES_009 = "�q�ɃR�[�h�ϊ���ϊ����ł��c";
            /// <summary>INFO_MES_010:�q�Ƀ}�X�^���o����</summary>
            public const string INFO_MES_010 = "�q�Ƀ}�X�^���o����";
            /// <summary>INFO_MES_011:�q�Ƀ}�X�^�𒊏o���ł��c</summary>
            public const string INFO_MES_011 = "�q�Ƀ}�X�^�𒊏o���ł��c";
            /// <summary>INFO_MES_012:�ҏW���̃f�[�^���݂��܂��B\r\n�R�[�h�ϊ����������s���܂����H</summary>
            public const string INFO_MES_012 = "�ҏW���̃f�[�^���݂��܂��B\r\n�R�[�h�ϊ����������s���܂����H";
            /// <summary>INFO_MES_013:���������ɊY������q�Ƀ}�X�^�͑��݂��܂���B</summary>
            public const string INFO_MES_013 = "���������ɊY������q�Ƀ}�X�^�͑��݂��܂���B";

            #endregion
        }

        #region -- ���͒l�`�F�b�N�p�Ɉꎞ�I�ɒl��ۑ�����N���X --

        /// <summary>
        /// ���͒l�`�F�b�N�p�Ɉꎞ�I�ɒl��ۑ�����N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͒l�`�F�b�N�p�Ɉꎞ�I�ɒl��ۑ�����N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private sealed class EmployeeInputData
        {
            #region -- Member --

            /// <summary>�S���҃R�[�h(�ύX�O)</summary>
            private string bfEmployeeCd = String.Empty;
            /// <summary>�S���҃R�[�h(�ύX��)</summary>
            private string afEmployeeCd = String.Empty;
            /// <summary>�����Ώۂ̒S���҃R�[�h(�ύX�O)</summary>
            private string chgBfEmpCd = String.Empty;
            /// <summary>�����Ώۂ̒S���҃R�[�h(�ύX��)</summary>
            private string chgAfEmpCd = String.Empty;
            /// <summary>�O���b�h���̍s�ԍ�</summary>
            private int rowIndex = 0;
            /// <summary>�ʂ̒S���҃R�[�h�ƃR�[�h�̕ϊ������������Ƃ�\���t���O</summary>
            private bool isOtherCodeChand = false;

            #endregion

            #region -- Property --

            /// <summary>�S���҃R�[�h(�ύX�O)�v���p�e�B</summary>
            public String BfEmployeeCode
            {
                get { return this.bfEmployeeCd; }
                set { this.bfEmployeeCd = value; }
            }

            /// <summary>�S���҃R�[�h(�ύX��)�v���p�e�B</summary>
            public String AfEmployeeCode
            {
                get { return this.afEmployeeCd; }
                set { this.afEmployeeCd = value; }
            }

            /// <summary>�O���b�h���̍s�ԍ�</summary>
            public int RowIndex
            {
                get { return this.rowIndex; }
                set { this.rowIndex = value; }
            }

            /// <summary>�ʒS���҃R�[�h�ƃR�[�h�̌��������������Ƃ������t���O�̃v���p�e�B</summary>
            public bool IsOtherCodeChange
            {
                get { return this.isOtherCodeChand; }
            }

            #endregion

            #region -- Method --

            /// <summary>
            /// �ʒS���҃R�[�h�ۑ�����
            /// </summary>
            /// <param name="bfCode">�����Ώۂ̒S���҃R�[�h(�ϊ��O)</param>
            /// <param name="afCode">�����Ώۂ̒S���҃R�[�h(�ϊ���)</param>
            /// <remarks>
            /// <br>Note       : �ʂ̒S���҃R�[�h�ƃR�[�h�̌������������ꍇ�́A���������R�[�h��ۑ����܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/10</br>
            /// </remarks>
            public void SetOtherCodeChange(string bfCode, string afCode)
            {
                this.chgBfEmpCd = bfCode;
                this.chgAfEmpCd = afCode;
                this.isOtherCodeChand = (this.bfEmployeeCd == this.chgAfEmpCd) &&
                    (this.afEmployeeCd == this.chgBfEmpCd);
            }

            /// <summary>
            /// �ҏW�ςݔ��菈��
            /// </summary>
            /// <returns>true:�ҏW�L��/false:�ҏW����</returns>
            /// <remarks>
            /// <br>Note       : �I�𒆂̒S���҃R�[�h���ҏW�����f�[�^���ۂ��𔻒肵�܂��B</br>
            /// <br>Programmer : 30365 �{��</br>
            /// <br>Date       : 2016/03/10</br>
            /// </remarks>
            public bool IsEdit()
            {
                return this.bfEmployeeCd != this.afEmployeeCd;
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
        /// <br>Date       : 2016/02/18</br>
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
            /// <br>Date       : 2016/02/18</br>
            /// </remarks>
            abstract public string Convert(int bfrVal, ref int offset);
        }

        /// <summary>
        /// PM.NS�����c�[���@���l�̈ꊇ�ϊ����s���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���l�̈ꊇ�ϊ����s���N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
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
                return String.Format(PMKHN05101UA.cdFormat, bfrVal);
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
            /// <br>Date       : 2016/02/18</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05101UA.cdFormat, bfrVal + offset);
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
            /// <br>Date       : 2016/02/18</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05101UA.cdFormat, bfrVal * offset);
            }
        }

        /// <summary>
        /// PM.NS�����c�[���@�A�Ԃ̈ꊇ�ϊ����s���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A�Ԃ̈ꊇ�ϊ����s���N���X�ł��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
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
            /// <br>Date       : 2016/02/18</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                string convVal = String.Format(PMKHN05101UA.cdFormat, offset);
                offset++;
                return convVal;
            }
        }

        #endregion                        


        #endregion
    }
}