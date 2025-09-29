//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[�� �`�[�ԍ��ϊ��@UI�t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//****************************************************************************//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �q��
// �C �� ��  2018/09/27  �C�����e : NS�W�v�c�[��PG�g�ݍ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���
// �C �� ��  2018/10/02  �C�����e : �󒍃X�e�[�^�X�R�[�h�̐ݒ�s���̏C��
//****************************************************************************//
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
    /// PM.NS�����c�[�� �`�[�ԍ��ϊ��@UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[�� �`�[�ԍ��ϊ��@UI�t�H�[���N���X���B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/04</br>
    /// </remarks>
    public partial class PMKHN05151UA : Form
    {
        #region -- �萔 --

        /// <summary>�v���O����ID��\���萔:PMKHN05151UA</summary>
        private readonly string pgId = "PMKHN05151UA";
        /// <summary>���o�����A�ꊇ�ݒ�̏k�����̃T�C�Y</summary>
        private readonly int egbGrpBoxCntrctSize = 25;
        
        /// <summary>UOE�����f�[�^�ԍ��̔ԍ��R�[�h</summary>
        private const int uoeNo = 3300;

        /// <summary>�S�Ћ��ʂ̋��_�R�[�h</summary>
        private const string allSectionCd = "000000";
        
        ///// <summary>���_���̂��o�^����Ă��Ȃ����Ƃ������萔�F���o�^</summary>
        private readonly string noSectionName = "���o�^";
        ///// <summary>�S�Ћ���</summary>
        private readonly string allSectionName = "�S�Ћ���";

        ///// <summary>�擪�s��\����ʐ�</summary>
        private readonly int firstRow = 0;
        /// <summary>�`�[�ԍ��ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private const int ILLEGAL_DATA = 997;
        /// <summary>�`�[�ԍ��ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private const int NO_DATA = 998;
        /// <summary>�`�[�ԍ��ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private const int NO_FILE = 999;
        /// <summary>���l�`�F�b�N�p�̐��K�\���F^\d+$</summary>
        private readonly string regPttrnNum = @"^\d+$";

        #region -- ���O�֘A --
        /// <summary>���O�o�͐�̃f�B���N�g������\���萔�F./LOG/PMKHN05130U</summary>
        private const string LOG_DIR_PATH = @"./LOG/PMKHN05150U";
        /// <summary>���O�t�@�C������\���萔�FPMKHN05130U.log</summary>
        private const string LOG_FILE_NAME = @"PMKHN05150U_{0}.log";
        /// <summary>���O�t�@�C�����̓��t�����̃t�H�[�}�b�g�FyyyyMMdd</summary>
        private const string LOG_FORMAT_DATE = "yyyyMMdd";
        /// <summary>���O�t�H�[�}�b�g�FHH:mm:ss</summary>
        private const string LOG_FORMAT_PROCESSING_TIME = "HH:mm:ss";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] �`�[�ԍ��ϊ��������J�n���܂��B</summary>
        private const string LOG_FORMAT_START = "[{0}],�`�[�ԍ��ϊ��������J�n���܂��B";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] �`�[�ԍ��ϊ��������������܂����B</summary>
        private const string LOG_FORMAT_END = "[{0}],�`�[�ԍ��ϊ��������������܂����B";
        /// <summary>���O�t�H�[�}�b�g�F[{0}],�X�V�ΏہF{1},�X�V�����F{2}��,�������ԁF{3}</summary>
        private const string LOG_FORMAT_CASE_BY_BASE = "[{0}],�X�V�ΏہF{1},�X�V�����F{2}��,�������ԁF{3}";
        /// <summary>���O�t�H�[�}�b�g�F[{0}],���������ԁF{1},���X�V�����F{2}��</summary>
        private const string LOG_FORMAT_TOTAL = "[{0}],���������ԁF{1},���X�V�����F{2}��";
        /// <summary>���O�t�H�[�}�b�g�F[{0}] {1}�̕ϊ����ɃG���[���������܂����B�ϊ������𒆎~���܂��B</summary>
        private const string LOG_FORMAT_ERROR = "[{0}],{1}�̕ϊ����ɃG���[���������܂����B�ϊ������𒆎~���܂��B";
        /// <summary>���O�t�@�C�����̓��t�t�H�[�}�b�g�Fyyyy/MM/dd HH:mm:ss</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd HH:mm:ss";
        #endregion

        #endregion

        #region -- Member --

        /// <summary>
        /// �X�e�[�^�X�o�[�X�V�����f���Q�[�g
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���X�V���邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04<</br>
        /// </remarks>
        delegate void UpdateStatusBarDelegate(string mes);

        /// <summary>
        /// �X�e�[�^�X�o�[�����������f���Q�[�g
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[�����������邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04
        /// </remarks>
        delegate void InitStatusBarDelegate(int cnvTrgTblCount);


        // �A�N�Z�X�N���X�֘A
        /// <summary>���_�}�X�^</summary>
        private SecInfoAcs secInfoAcs;
        ///// <summary>�`�[�ԍ��ϊ�</summary>
        private SlipNoConvertAcs slipNoConvertAcs;
        /// <summary>�������_�C�A���O</summary>
        private SFCMN00299CA procDlg = null;
        /// <summary>���O�C�����[�U�̏������_</summary>
        private string loginSecCd = String.Empty;
        /// <summary>��ƃR�[�h</summary>
        private string enterPriseCd = String.Empty;
        /// <summary>�ϊ��Ώۋ��_�R�[�h</summary>
        private string tgsectionCd = String.Empty;
        /// <summary>���o�����ƈꊇ�ݒ��UltraExpandableGroupBox�̓W�J���̍��������i�[�����}�b�v</summary>
        private IDictionary<EgbGrpBoxType, int> egbGrpBoxHeighMap = null;
        /// <summary>��ʂ̃X�L�������i�[</summary>
        private ControlScreenSkin ctrlScrnSkin;        
        /// <summary>���_�����i�[�}�b�v</summary>
        private Dictionary<string, String> secInfoMap;
        /// <summary>�ԍ��^�C�v�Ǘ��}�X�^���i�[�}�b�v</summary>
        private Dictionary<Int32, String> noTypeMngMap;
        /// <summary>�X�V�t���O(true:�X�V�ς�/false:���X�V)</summary>
        private bool isUpdate = false;
        /// <summary>�ҏW�ς݊m�F�t���O(true:�ҏW�ς�/false:���ҏW)</summary>
        private bool isEdit = false;
        /// <summary>���̓`�F�b�N�̌��ʂ��i�[����ϐ�(true:�`�F�b�NOK/false:�`�F�b�NNG)</summary>
        private bool isCheckOK = false;
        ///// <summary>�R�[�h�̌���</summary>
        private int codeLength = 0;
        ///// <summary>�R�[�h�̌���</summary>
        private int secCodeLength = 0;
        /// <summary>�X���b�h���s���̃G���[���b�Z�[�W��ۑ�</summary>
        private string cnvErrMes = String.Empty;
        /// <summary>FormCloing�C�x���g�Ŏ��{���ꂽ���𔻒肷��t���O(true:FormCloig������{/false:FormCloing�ȊO�Ŏ��{)</summary>
        private bool isCallFormCloseingEvent = false;
        /// <summary>�`�[�ԍ��@�ϊ��f�[�^���i�[</summary>
        private IList<SlpNoConvertData> slipConvertDtList;
        /// <summary>�ԍ��Ǘ��}�X�^�f�[�^���i�[</summary>
        private ArrayList noMgSetWork;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�`�[�ԍ��ϊ������c�[���@UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�`�[�ԍ��ϊ������c�[��UI�t�H�[���N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30175 �q��
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        public PMKHN05151UA()
        {
            InitializeComponent();
            // �e�핔�i�̏��������s���܂��B
            this.ctrlScrnSkin = new ControlScreenSkin();
            // ���o�����ƈꊇ�ݒ�̓W�J���̍�������ۑ�
            this.egbGrpBoxHeighMap = new Dictionary<EgbGrpBoxType, int>();
            this.egbGrpBoxHeighMap[EgbGrpBoxType.Conditon] = this.ultrEgbCondition.Height;
            this.egbGrpBoxHeighMap[EgbGrpBoxType.CollectiveSetting] = this.ultrEgbCllctvSttng.Height;

            // �R�[�h�̌�����ݒ肵�܂��B
            this.codeLength = 9;
            this.secCodeLength = 2;
        }

        #endregion

        #region -- Protected Method --

        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
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
            this.ultrBtnWrhs.ImageList = IconResourceManagement.ImageList16;

            // ���_�}�X�^�̏�����
            this.secInfoAcs = new SecInfoAcs();
            this.GetSecInfoSet();

            // ��ƃR�[�h
            this.enterPriseCd = LoginInfoAcquisition.EnterpriseCode;
            // ���O�C�����_�R�[�h
            this.loginSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ���O�C�����[�U���̏�����
            this.SetUserInfo();

            // �O���b�h�̏����ݒ��ݒ肵�܂��B
            this.InitGrid();

            // �������_�C�A���O
            this.procDlg = new SFCMN00299CA();

            //�A�N�Z�X�N���X
            this.slipNoConvertAcs = new SlipNoConvertAcs();

            // ���l���͗��̏�����
            this.SetTnEditMaxLength(this.pnlCllctvSttng);
            this.SetTnEditMaxLength(this.pnlCondtion);

            // �ꊇ�ݒ�̓��͗������������܂��B            
            this.SetAllSettingTypeOnTNEdit();
            this.tNdtSub.Enabled = false;


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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void InitSetting()
        {
            /// UltraExpandableGroupBox�̏�����
            // ���o����
            this.ultrEgbCondition.Tag = EgbGrpBoxType.Conditon;
            // �ꊇ�ݒ�
            this.ultrEgbCllctvSttng.Tag = EgbGrpBoxType.CollectiveSetting;

        }

        /// <summary>
        /// ���[�U��񏉊�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�C�����[�U�������Ƀ��[�U�̕\������ݒ肵�܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void SetUserInfo()
        {
            // ���_��
            ToolBase secNm = tTooBarMain.Tools[ToolMenuType.LBL_TOOL_SECTION];
            if (secNm != null && LoginInfoAcquisition.Employee != null)
            {
                secNm.SharedProps.Caption = this.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void SetTnEditMaxLength(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TNedit)
                {
                    TNedit edit = child as TNedit;
                    edit.MaxLength = this.codeLength;
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
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
        /// �ԍ��^�C�v�Ǘ��}�X�^���擾����
        /// </summary>
        /// <param name="noTypeMngArry"></param>
        /// <remarks>
        /// <br>Note       : �ԍ��^�C�v�Ǘ��}�X�^��ǂݍ��݁A�ԍ����̂��������ɕێ����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void GetNoTypeSet(ArrayList noTypeMngArry)
        {
            //�ԍ��^�C�v�Ǘ��}�X�^����ԍ����̂��擾���܂��B
            this.noTypeMngMap = new Dictionary<int, string>();

            //�ԍ��^�C�v�Ǘ��}�X�^���������ɃL���b�V�����܂�
            foreach(NoTypeMng noTypeMag in noTypeMngArry)
            {
                if(noTypeMag.LogicalDeleteCode == 0)
                {
                    this.noTypeMngMap[noTypeMag.NoCode] = noTypeMag.NoName.Trim();
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCd)
        {
            // ���_�R�[�h�����͂���Ă���ꍇ�́A�Y������R�[�h������ꍇ�͕R�t�����_���̂�
            // �Y���R�[�h�������ꍇ�͖��o�^���Ăяo�����ɕԋp����
            string cd = sectionCd.Trim().PadLeft(this.secCodeLength, '0');

            if(!this.secInfoMap.ContainsKey(cd))
            {
                if (cd == "00")
                {
                    return this.allSectionName;
                }
                else
                {
                    return this.noSectionName;
                }
            }

            return this.secInfoMap[cd];
        }

        #endregion

        #region -- �R���g���[���̏����� --

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�������̓��͓��e�A�y�уO���b�h�̏����N���A���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06<</br>
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

            //�������ɕۑ����Ă���`�[�ϊ��f�[�^���N���A
            if (this.slipConvertDtList != null)
            {
                this.slipConvertDtList.Clear();
            }

            //�������ɕۑ����Ă���`�[�Ǘ��f�[�^�̃N���A
            if(this.noMgSetWork != null)
            {
                this.noMgSetWork.Clear();
            }

            // �t�H�[�J�X��擪�ɖ߂��܂�
            this.tNdtWrHsCd.Focus();
        }

        /// <summary>
        /// �R���g���[������������
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : TEdit�ATNedit�AUltraOptionSet�AUltraWinGrid�̓��e�����������܂��B</br>
        /// <br>             ��L�ȊO�̃R���g���[���̏ꍇ�A�z���̃R���g���[�����ċA�I�ɌĂяo����</br>
        /// <br>             �q�R���g���[���������Ȃ�܂ŒT���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/15<</br>
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
                    // ���W�I�{�^���͉��Z��I�����܂�
                    UltraOptionSet optSet = child as UltraOptionSet;
                    optSet.FocusedIndex = (int)AllSettingType.ADD;
                    optSet.Value = (int)AllSettingType.ADD;
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
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

        }

        /// <summary>
        /// �O���b�h�J��������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�����̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void InitGridColumns()
        {
            ColumnsCollection columns = this.ultrGrid.DisplayLayout.Bands[0].Columns;

            //�ԍ�
            UltraGridColumn column = columns[GridSettingInfo.COL_NO];
            this.SetColInfo(column, 0, GridSettingInfo.COL_NO, Infragistics.Win.HAlign.Right, false, null);
            //��\���ɂ��܂�
            column.Hidden = true;

            // �ԍ���
            column = columns[GridSettingInfo.COL_NO_NM];
            this.SetColInfo(column, GridSettingInfo.COL_NO_NM_WIDTH, GridSettingInfo.COL_NO_NM,
                Infragistics.Win.HAlign.Left,false,null);

            // �ԍ����ݒl
            column = columns[GridSettingInfo.COL_NO_PT];
            this.SetColInfo(column, GridSettingInfo.COL_NO_IDV_WIDTH, GridSettingInfo.COL_NO_PT,
                Infragistics.Win.HAlign.Right, false,"0");

            // �ݒ�J�n�ԍ�
            column = columns[GridSettingInfo.COL_NO_ST];
            this.SetColInfo(column, GridSettingInfo.COL_NO_ST_WIDTH, GridSettingInfo.COL_NO_ST,
                Infragistics.Win.HAlign.Right, false, "0");

            // �ݒ�I���ԍ�
            column = columns[GridSettingInfo.COL_NO_ED];
            this.SetColInfo(column, GridSettingInfo.COL_NO_ED_WIDTH, GridSettingInfo.COL_NO_ED,
                Infragistics.Win.HAlign.Right, false, "0");

            // �ԍ������l
            column = columns[GridSettingInfo.COL_NO_IDV];
            this.SetColInfo(column, GridSettingInfo.COL_NO_IDV_WIDTH, GridSettingInfo.COL_NO_IDV,
                Infragistics.Win.HAlign.Right, true , "0");
            //���͕������𐧌�����
            column.MaxLength = codeLength;

            // �ԍ�������
            column = columns[GridSettingInfo.COL_NO_IDW];
            this.SetColInfo(column, 0, GridSettingInfo.COL_NO_IDW, Infragistics.Win.HAlign.Right, false, null);
            //��\���ɂ��܂�
            column.Hidden = true;

        }

        /// <summary>
        /// �񏉊�������
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="width">��</param>
        /// <param name="caption">�񌩏o��</param>
        /// <param name="hAlign">�e�L�X�g�̐����ʒu</param>
        /// <param name="isAllowEdit">�ҏW�̉�(true:��/false:�s��)</param>
        /// <param name="format">���͒l�̏���(�R�[�h�̂ݎw�肵�܂�)</param>        
        /// <remarks>
        /// <br>Note       : ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void SetColInfo(UltraGridColumn col, int width, string caption,
            Infragistics.Win.HAlign hAlign, Boolean isAllowEdit, string format)
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

        }

        /// <summary>
        /// �f�[�^�e�[�u���쐬����
        /// </summary>
        /// <remarks>
        /// <returns>�e�[�u���I�u�W�F�N�g</returns>
        /// <br>Note       : �f�[�^�e�[�u���̍쐬���s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable(GridSettingInfo.TBL_NAME);
            //�ԍ�
            table.Columns.Add(GridSettingInfo.COL_NO, typeof(Int32));
            // �ԍ���
            table.Columns.Add(GridSettingInfo.COL_NO_NM, typeof(string));
            // �ԍ����ݒl
            table.Columns.Add(GridSettingInfo.COL_NO_PT, typeof(Int64));
            // �ݒ�J�n�ԍ�
            table.Columns.Add(GridSettingInfo.COL_NO_ST, typeof(Int64));
            // �ݒ�I���ԍ�
            table.Columns.Add(GridSettingInfo.COL_NO_ED, typeof(Int64));
            // �ԍ������l
            table.Columns.Add(GridSettingInfo.COL_NO_IDV, typeof(Int64));
            // �ԍ�������
            table.Columns.Add(GridSettingInfo.COL_NO_IDW, typeof(Int32));


            return table;
        }

        ///// <summary>
        ///// �O���b�h�\�����Z�b�g����
        ///// </summary>
        ///// <param name="sectionList">���_���ꗗ</param>
        ///// <returns>�e�[�u���I�u�W�F�N�g</returns>
        ///// <remarks>
        ///// <br>Note       : �O���b�h�ɕ\������f�[�^���Z�b�g���܂��B</br>
        ///// <br>Programmer : 30175 �q��</br>
        ///// <br>Date       : 2018/09/05</br>
        ///// </remarks>
        /// <summary>
        /// �O���b�h�\�����Z�b�g����
        /// </summary>
        /// <param name="noMngList">�ԍ��Ǘ��}�X�^�f�[�^</param>
        private void SetDataToGrid(ArrayList noMngList,string sectionCode)
        {
            //�f�[�^�e�[�u���Ƀf�[�^���Z�b�g���܂�
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            //�f�[�^���N���A����
            if (this.noMgSetWork == null)
            {
                this.noMgSetWork = new ArrayList();
            }
            noMgSetWork.Clear();

            //�s�f�[�^
            DataRow dr = null;

            foreach (NoMngSet wk in noMngList)
            {
                if (wk.SectionCode.Trim() == sectionCode || wk.SectionCode == allSectionCd)
                {
                    if (wk.SectionCode == allSectionCd && sectionCode != "00")
                    {
                        //�������Ȃ��B

                    }
                    else
                    {
                        //�s�̒ǉ�
                        dr = table.NewRow();
                        //�ԍ�
                        dr[GridSettingInfo.COL_NO] = wk.NoCode;
                        // �ԍ���
                        dr[GridSettingInfo.COL_NO_NM] = noTypeMngMap[wk.NoCode];
                        // �ԍ����ݒl
                        dr[GridSettingInfo.COL_NO_PT] = wk.NoPresentVal;
                        // �ݒ�J�n�ԍ�
                        dr[GridSettingInfo.COL_NO_ST] = wk.SettingStartNo;
                        // �ݒ�I���ԍ�
                        dr[GridSettingInfo.COL_NO_ED] = wk.SettingEndNo;
                        // �ԍ������l
                        dr[GridSettingInfo.COL_NO_IDV] = 0;
                        // �ԍ�������
                        dr[GridSettingInfo.COL_NO_IDW] = wk.NoIncDecWidth;
                        //�f�[�^�e�[�u���֒ǉ�
                        table.Rows.Add(dr);

                        //�ԍ��Ǘ��}�X�^�����i�[���܂��B
                        this.noMgSetWork.Add(wk);
                    }
                }

            }

        }

        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        /// <remarks>
        /// <br>Note       : �{�^���̏����ݒ�����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
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

        ///// <summary>
        ///// ��������
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ��ʂŎw�肵�����������ɔԍ��Ǘ��ݒ�f�[�^�̌������s���܂��B</br>
        ///// <br>Programmer : 30175 �q��</br>
        ///// <br>Date       : 2018/09/05</br>
        ///// </remarks>
        private void Search()
        {
            //���_�R�[�h�����͂���Ă��邩�`�F�b�N���s���܂��B
            if (tNdtWrHsCd != null) 
            {
                //���_���o�^���_���m�F����
                if(tNdtWrHsCd.Text == this.noSectionName)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_001);
                    return;
                }

                //�ԍ��Ǘ��}�X�^�f�[�^���擾����
                NoMngSetAcs noMngSetAcs = new NoMngSetAcs();

                try
                {
                    ArrayList retNoMngSetList = new ArrayList();
                    ArrayList retNoTypeMngList = new ArrayList();
                    
                    int status = noMngSetAcs.Search(out retNoMngSetList, out retNoTypeMngList, enterPriseCd);

                    if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && retNoMngSetList == null)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_015 + status);
                        return;
                    }

                    //�ԍ��^�C�v�Ǘ��}�X�^�̏����i�[���܂��B
                    GetNoTypeSet(retNoTypeMngList);

                    //�l��Gurid�ɃZ�b�g���܂��B
                    this.SetDataToGrid(retNoMngSetList, tNdtWrHsCd.Text.Trim().PadLeft(secCodeLength,'0'));

                    //���̃R���g���[���Ƀt�H�[�J�X��J�ڂ��܂��B
                    tNdtAdd.Focus();
                    

                }
                catch(Exception ex)
                {
                    // �G���[�_�C�A���O��\�����܂��B
                    this.ShowError(String.Format(MessageMng.ERR_MES_004, ex.Message),
                                (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                }

            }
            else
            {
                //�G���[���b�Z�[�W��\������
                this.ShowExclamation(MessageMng.ERR_MES_001);
                //�t�H�[�J�X�����_�R�[�h�ɖ߂�
                this.tNdtWrHsCd.Focus();
                
                return;
            }

        }


        /// <summary>
        /// ���l�`�F�b�N����
        /// </summary>
        /// <param name="tNEdit"></param>
        /// <returns>���茋��(true:�񐔒l/false:���l)</returns>
        /// <remarks>
        /// <br>Note       : ���o�����w�肵���l���񐔒l�ł��邩���`�F�b�N���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private bool IsNotNumber(TNedit tNEdit)
        {
            // ���͒l������ꍇ�̂݃`�F�b�N���܂��B
            if (tNEdit.GetInt() == 0 && tNEdit.Text.Length == 0 &&
                !Regex.IsMatch(tNEdit.Text, this.regPttrnNum))
            {
                tNEdit.Focus();

                if(tNEdit == tNdtAdd)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_009);
                }
                else if(tNEdit == tNdtSub)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_010);
                }
                else
                {
                    this.ShowExclamation(MessageMng.ERR_MES_011);
                }

                return true;
            }

            return false;
        }

        #endregion

        #region -- �R�[�h�ϊ��֘A --

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ`�[�ԍ���ϊ����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private void SlpNoConvert()
        {
            try
            {
                int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                //�y�ԍ������l���w�肳��Ă��邩�`�F�b�N������z
                this.isCheckOK = this.CheckNoIncDec();

                //�w�肳��Ă��Ȃ��ꍇ�͏������I������
                if (!isCheckOK)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_003);
                    return;
                }
                
                //�Ώۂ̋��_�R�[�h���Z�b�g����
                this.tgsectionCd = this.tNdtWrHsCd.Text.Trim().PadLeft(this.secCodeLength, '0');

                //�w�肳��Ă���ꍇ�͏����𑱂���
                //�����J�n�O�̊m�F���b�Z�[�W��\������
                //�L�����Z���F�����I��
                if (this.ShowInfo(MessageMng.INFO_MES_001) == DialogResult.Cancel)
                {
                    return;
                }

                #region�y�ԍ������l�̎w�肪���������`�F�b�N���s���z

                this.isCheckOK = false;
                
                this.isCheckOK = this.CheckSettingNo();
                //�`�F�b�N�̌��ʕs��
                if(!isCheckOK)
                {
                    return;
                }

                #endregion

                #region�yXML����R�[�h�ϊ��̑ΏۂƂȂ�e�[�u�����擾���܂��z

                IDictionary<int, IList<SlpNoTargetTableListResult>> trgTblMap = new Dictionary<int, IList<SlpNoTargetTableListResult>>();
                int secDiv = 0;
                //���_���w�肳��Ă���ꍇ
                if(this.tgsectionCd != "00" || this.tgsectionCd == "")
                {
                    secDiv = 1;
                }
                status = this.slipNoConvertAcs.GetTargetTableList(secDiv,trgTblMap);

                if(status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (status)
                    {
                        //�s���f�[�^������ꍇ
                        case PMKHN05151UA.ILLEGAL_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_018;
                            break;

                        //�f�[�^���Ȃ��ꍇ
                        case PMKHN05151UA.NO_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_017;
                            break;

                        //�t�@�C�������݂��Ȃ��ꍇ
                        case PMKHN05151UA.NO_FILE:
                            this.cnvErrMes = MessageMng.ERR_MES_019;
                            break;

                    }

                    return;
                }

                #endregion

                //�R�[�h�ϊ��Ώۂ̃f�[�^���O���b�h����擾���܂�
                IList<SlipNOConvertDispInfo> dispDataList = this.GetConvertDispData();

                #region�y�R�[�h�ϊ��Ώۂ̃f�[�^�̃`�F�b�N�������s���܂��z

                bool check = false;
                //�ϊ��f�[�^List
                this.slipConvertDtList = new List<SlpNoConvertData>();
                //�`�F�b�N�G���[���b�Z���pList
                IList <string> errList = new List<string>();

                foreach(SlipNOConvertDispInfo displist in dispDataList)
                {
                    //XML�f�[�^�̎擾
                    IList<SlpNoTargetTableListResult> targetList = this.GetTargetTableList(displist.NoCode, trgTblMap);

                    //XML���X�g���Ȃ��ꍇ�͎��̏����ԍ���
                    if (targetList.Count != 0)
                    {
                        //�ϊ��f�[�^���쐬�E�`�F�b�N���s��
                        foreach (SlpNoTargetTableListResult list in targetList)
                        {
                            SlpNoConvertData slipdtWork = new SlpNoConvertData();

                            #region//�l���Z�b�g����

                            //�ԍ��R�[�h(�����Ώ۔ԍ�)
                            slipdtWork.NoCode = displist.NoCode;
                            //�e�[�u��ID(������)
                            slipdtWork.Table = list.TargetTable;
                            //�e�[�u����(�_����)
                            slipdtWork.TableName = list.TargetTableName;
                            //�J������(������)
                            slipdtWork.Colum = list.TargetColum;
                            //�J������(�_����)
                            slipdtWork.ColumName = list.TargetColumName;
                            //�󒍃X�e�[�^�XID
                            slipdtWork.AcptStatusId = list.TargetAcptStatusId;
                            //�󒍃X�e�[�^�X�R�[�h
//                            slipdtWork.AcptStatusId = list.TargetAcptStatusId;     2018/10/02
                            slipdtWork.AcptStatus = list.TargetAcptStatus;         //2018/10/02
                            //�ԍ����ݒl
                            slipdtWork.NoPresentVal = displist.NoPresentVal;
                            //�ݒ�J�n�ԍ�
                            slipdtWork.SettingStartNo = displist.SettingStartNo;
                            //�ݒ�I���ԍ�
                            slipdtWork.SettingEndNo = displist.SettingEndNo;
                            //�ԍ������l
                            slipdtWork.NoIncDecWidth = displist.NoIncDecWidth;

                            #endregion

                            //�ϊ��̍ہA���Ȃ����`�F�b�N�������s��
                            check = false;
                            status = slipNoConvertAcs.CheckCOnvertSlipNo(this.enterPriseCd, slipdtWork, out check);

                            //DB�G���[����
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.ShowExclamation(MessageMng.ERR_MES_020);
                                return;
                            }

                            //�`�F�b�N�Ɉ������������ꍇ
                            if (!check)
                            {
                                //���X�g�Ɋ܂܂�Ă��邩�m�F����
                                if (!errList.Contains(Convert.ToString(noTypeMngMap[displist.NoCode])))
                                {
                                    //���X�g��Add
                                    errList.Add(Convert.ToString(noTypeMngMap[displist.NoCode]));
                                }
                            }
                            else
                            {
                                //�ύX����f�[�^��ێ�����
                                this.slipConvertDtList.Add(slipdtWork);
                            }
                        }
                    }
                }

                //�`�F�b�N���ʂ��m�F
                if(errList.Count != 0)
                {
                    string errMg = "";

                    foreach(string st in errList)
                    {
                        if (errMg == "")
                        {
                            errMg = st;
                        }
                        else
                        {
                            errMg += "\r\n" + st;
                        }
                    }

                    this.ShowExclamation(MessageMng.ERR_MES_013 + errMg);
                    return;
                }

                #endregion

                // ���O�̕ۑ���f�B���N�g�����쐬���܂��B
                this.CreateLogSaveDir();

                //�ϊ����������{
                // �v���O���X�_�C�A���O��\�����܂��B
                this.ShowProgressDlg(MessageMng.INFO_MES_002, MessageMng.INFO_MES_003, false);
                // �R�[�h�ϊ��������o�b�N�O���E���h�Ŏ��s���܂��B
                this.bgWrkr.RunWorkerAsync();

            }
             catch (Exception ex)
            {
                this.ShowError(String.Format(MessageMng.ERR_MES_021, ex.Message),
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

        }

        /// <summary>
        /// �R���o�[�g�Ώۃf�[�^�L���`�F�b�N����
        /// </summary>
        /// <returns>true:�ΏۗL/false:�Ώۖ���</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���ɃR���o�[�g�ΏۂƂȂ�f�[�^�����݂��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private bool CheckNoIncDec()
        {
            // �O���b�h�Ƀf�[�^�����݂��邩�m�F���܂��B
            if (this.ultrGrid.Rows.Count != 0)
            {
                // �O���b�h�Ƀf�[�^���L��ꍇ�A�ԍ������l��ɓ��͒l�����邩�ǂ������m�F���܂��B
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    // ��ł͂Ȃ��Z���𔭌������珈���𔲂��܂�
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) && !this.IsCodeZero(row))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// �R���o�[�gNo�̓��͒l�`�F�b�N����
        /// </summary>
        /// <returns>true:����/false:��肠��</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�ΏۂƂȂ�f�[�^�ɐݒ肳��Ă���ԍ����Z�l�����Ȃ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private bool CheckSettingNo()
        {
            // �O���b�h�Ƀf�[�^�����݂��邩�m�F���܂��B
            if (this.ultrGrid.Rows.Count != 0)
            {
                //�ݒ�l�m�F����
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) && !this.IsCodeZero(row))
                    {

                        //�ݒ肳��Ă���ݒ�I���ԍ����ő�l�𒴂��Ȃ����`�F�b�N����
                        if (999999999 <= Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Text.Trim())
                            + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()))
                        {
                            this.SetFocusErrorCell(row, row.Cells[GridSettingInfo.COL_NO_NM].Text.Trim() + MessageMng.ERR_MES_006);
                            return false;
                        }

                        //UOE�����f�[�^�̏ꍇ
                        if (Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO].Text.Trim()) == uoeNo &&
                            999999 <= Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Text.Trim()) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()))
                        {
                            this.SetFocusErrorCell(row, row.Cells[GridSettingInfo.COL_NO_NM].Text.Trim() + MessageMng.ERR_MES_007);
                            return false;
                        }

                        //�ݒ肳��Ă���ݒ�J�n�ԍ����}�C�i�X�l�ɂȂ�Ȃ����`�F�b�N����
                        if (0 > Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ST].Text.Trim()) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()))
                        {
                            this.SetFocusErrorCell(row, row.Cells[GridSettingInfo.COL_NO_NM].Text.Trim() + MessageMng.ERR_MES_005);
                            return false;
                        }
                    }
                }

                return true;

            }
            //�O���b�h�Ƀf�[�^�����݂��Ȃ��ꍇ
            else
            {
                this.ShowExclamation(MessageMng.ERR_MES_003 + MessageMng.ERR_MES_012);
                return false;
            }
            
        }


        /// <summary>
        /// �X�e�[�^�X�o�[����������
        /// </summary>
        /// <param name="cnvTrgTblCount">�R�[�h�ϊ��Ώۃe�[�u���̌���</param>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�������s���O���ɃX�e�[�^�X�o�[�̏��������s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/19</br>
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
        /// �G���[�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <param name="errMes">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���̓`�F�b�N�ŃG���[�����������Z���Ƀt�H�[�J�X���Z�b�g���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private void SetFocusErrorCell(UltraGridRow row, string errMes)
        {
            this.ultrGrid.Focus();
            row.Cells[GridSettingInfo.COL_NO_IDV].Activate();
            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            this.ShowExclamation(errMes);
        }

        /// <summary>
        /// ���O�ۑ���f�B���N�g���쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O��ۑ�����f�B���N�g�������݂��Ȃ��ꍇ�A�f�B���N�g���̍쐬���s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private void CreateLogSaveDir()
        {
            // ���O�ۑ��f�B���N�g�������݂��邩�m�F���A�����ꍇ�̓f�B���N�g�����쐬���܂��B
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05151UA.LOG_DIR_PATH);
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private DialogResult ShowExclamation(string mes)
        {
            // �x�����b�Z�[�W��\�����܂�
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_EXCLAMATION, MessageBoxButtons.OK, mes, 0);
        }

        /// <summary>
        /// �C���t�H���b�Z�[�W�_�C�A���O�\������(OK/Cancel)
        /// </summary>
        /// <param name="mes">�\������C���t�H���b�Z�[�W</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>Note       : ��ʂɃC���t�H���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private DialogResult ShowInfo(string mes)
        {
            // �C���t�H���b�Z�[�W��\�����܂��B
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_INFO, MessageBoxButtons.OKCancel, mes, 0);
        }

        /// <summary>
        /// �C���t�H���b�Z�[�W�_�C�A���O�\������(Yes/No/Cancel)
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        private DialogResult ShowInfo2(string mes)
        {
            // �C���t�H���b�Z�[�W��\�����܂��B
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_INFO, MessageBoxButtons.YesNoCancel, mes, 0);
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/12/15</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void SetName(TNedit tNEdit, TEdit tEdit)
        {
            string sectionCd = tNEdit.Text.Trim();
            string sectionNm = this.GetSectionName(sectionCd);
            tEdit.Text = sectionNm;
            if (!String.IsNullOrEmpty(sectionCd))
            {
                tNEdit.Text = tNEdit.Text.Trim().PadLeft(this.secCodeLength, '0');
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05<</br>
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
                this.ultrGrid.Rows[rowIndex].Cells[GridSettingInfo.COL_NO_IDV].Activate();
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// �O���b�h���̃t�H�[�J�X�J�ڎ��̃A�N�e�B�u�Z���t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="cmpRowIndex">��r�������s�̍s�ԍ�(�擪�̏ꍇ��0�A�����̏ꍇ�͍s��-1)</param>
        /// <param name="nextCtrl">���ɑJ�ڂ���R���g���[��(���_�K�C�hor�ꊇ�ݒ�{�^��)</param>
        /// <param name="gridAction">�O���b�h�Ŏ��s�������A�N�V����</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���̃t�H�[�J�X�J�ڎ��Ɏ��̃Z�����A�N�e�B�u�ɂ��܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void SetAllSettingTypeOnTNEdit()
        {

            // ���Z
            this.tNdtAdd.Tag = AllSettingType.ADD;
            // ���Z
            this.tNdtSub.Tag = AllSettingType.Multiplication;
            
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05<</br>
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
                                this.tNdtWrHsCd, UltraGridAction.NextCell, e);
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
                        // 1�s�ڂ̔ԍ������l���A�N�e�B�u�ɂ��܂�
                        this.ultrGrid.ActiveRow.Cells[GridSettingInfo.COL_NO_IDV].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                else
                {
                    // ���l���ړ��͗��ł���΁A���_�R�[�h���͗��Ƀt�H�[�J�X���Z�b�g
                    if (e.NextCtrl is TNedit)
                    {
                        this.tNdtWrHsCd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtWrHsCd)
            {
                // ���_�R�[�h���擾���l������ꍇ�́A���_���̂��Z�b�g����
                this.SetName(this.tNdtWrHsCd, this.tEdtWrHsNm);

                //�f�[�^����������Ă��Ȃ������猟������
                if (this.ultrGrid.Rows.Count == 0)
                {
                    //�f�[�^����������
                    this.Search();
                }

                // �t�H�[�J�X�𐧌䂵�܂��B
                if (e.ShiftKey && e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
                {
                    e.NextCtrl = null;
                    this.ultrGrid.Focus();
                    this.ultrGrid.Rows[this.ultrGrid.Rows.Count - 1].Cells[GridSettingInfo.COL_NO_IDV].Activate();
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
            else if (e.PrevCtrl == this.ultrBtnSttng)
            {
                // �O���b�h�̐擪�s���A�N�e�B�u�ȃZ���ɂ��܂��B
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    this.tNdtWrHsCd.Focus();
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
                        this.tNdtWrHsCd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtWrHsCd)
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
                                e.NextCtrl = this.tNdtSub;
                                break;
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        if (this.ultrGrid.Rows.Count != 0)
                        {
                            this.ultrGrid.Focus();
                            this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_NO_IDV].Activate();
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
                        this.tNdtSub.Focus();
                    }
                    else
                    {
                        this.tNdtWrHsCd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtSub)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.Multiplication);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (this.ultrGrid.Rows.Count != 0)
                    {
                        this.ultrGrid.Focus();
                        this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_NO_IDV].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.tNdtAdd.Focus();
                    }
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06<</br>
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
        /// Grid�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: Grid�A�N�V����������ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer	: 39175  �q��</br>
        /// <br>Date		: 2018/09/15</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void bgWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                //�y�ϊ��������s���z

                // �X�e�[�^�X�o�[�����������܂��B
                this.Invoke(new InitStatusBarDelegate(this.InitStatusBar), this.slipConvertDtList.Count);

                // �e�[�u���P�ʂŃR�[�h�̕ϊ������{���܂��B
                int index = 0;
                long prcssngCnt;
                long ttlPrcssngCnt = 0;
                int maxlist = slipConvertDtList.Count;

                // ���O���o�͂��܂��B
                using (FileStream fs = new FileStream(this.CreateLogFilePath(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //���엚�����O�ɓ��l�̓��e���o�͂��Ă����܂��B
                        OperationHistoryLog opLog = new OperationHistoryLog();
                        string pgid = "PMKHN05150U";
                        string pgnm = "�`�[�ԍ��ϊ�";

                        // ���������Ԃ��v������Stopwatch
                        Stopwatch totalProcessingTime = new Stopwatch();
                        // �ʂ̃e�[�u���̏������Ԃ��v������Stopwatch
                        Stopwatch processingTime = new Stopwatch();

                        sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_START, new string[0]));
                        opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_START + "�y" + tEdtWrHsNm.Text.ToString() + "�z", new String[0]), "");

                        // �����������Ԃ̌v���J�n���܂��B
                        totalProcessingTime.Start();

                        foreach (SlpNoConvertData target in this.slipConvertDtList)
                        {
                            prcssngCnt = 0;
                            //�R�[�h�ϊ��O�ɃX�e�[�^�X�o�[���X�V���܂�
                            Invoke(new UpdateStatusBarDelegate(this.UpdateStatusBar),
                                String.Format(MessageMng.INFO_MES_004, this.noTypeMngMap[target.NoCode], index, maxlist));

                            //�ʂ̎��Ԃ��v��
                            processingTime.Start();

                            //�R�[�h�ϊ����������{���܂�
                            status = this.slipNoConvertAcs.SlipNoConvert(this.enterPriseCd, target, ref prcssngCnt);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_ERROR, new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName + ",�����l�F" + target.NoIncDecWidth }));
                                opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_ERROR, new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName }), "");
                                e.Cancel = true;
                                break;
                            }

                            processingTime.Stop();
                            ttlPrcssngCnt += prcssngCnt;

                            // �X�̏��������A�������Ԃ����O�ɏo�͂��܂��B
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName + ",�����l�F" + target.NoIncDecWidth, prcssngCnt.ToString(), 
                                    new DateTime (0).Add(processingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME) }));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName + ",�����l�F" + target.NoIncDecWidth, prcssngCnt.ToString(), 
                                    new DateTime (0).Add(processingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME) }), "");

                            // �ϊ��I������X�e�[�^�X�o�[���X�V���܂��B
                            this.bgWrkr.ReportProgress(++index,
                                String.Format(MessageMng.INFO_MES_004, target.TableName, index, maxlist));

                            // �ʃe�[�u���̏������Ԃ��v������Stopwatch�����Z�b�g���܂��B
                            processingTime.Reset();

                        }
                        totalProcessingTime.Stop();

                        //�y���������������O�ɏo�́z
                        if (!e.Cancel)
                        {
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME),
                                    ttlPrcssngCnt.ToString() }));
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_END, new String[0]));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME),
                                    ttlPrcssngCnt.ToString() }), "");
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_END, new String[0]), "");



                            //�y�ԍ��Ǘ��ݒ�}�X�^�̍X�V�����z
                            NoMngSetAcs noMgSetAcs = new NoMngSetAcs();
                            ArrayList noMgArryList = new ArrayList();

                            //�o�^����f�[�^���Z�b�g����
                            foreach (UltraGridRow row in this.ultrGrid.Rows)
                            {
                                // �ԍ������l����l���擾���A�l�������ꍇ�͎��̍s��
                                if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) ||
                                        this.IsCodeZero(row))
                                {
                                    continue;
                                }

                                NoMngSet noMgWork = GetnoMgWork(row);                              

                                noMgArryList.Add(noMgWork);
                            }

                            status = noMgSetAcs.Write(ref noMgArryList);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.ShowExclamation(MessageMng.ERR_MES_014 + status);
                                return;
                            }

                            //�y��ʂ����������A�ԍ��Ǘ�����\������z
                            ArrayList retNoMngSetList = new ArrayList();
                            ArrayList retNoTypeMngList = new ArrayList();

                            status = noMgSetAcs.Search(out retNoMngSetList, out retNoTypeMngList, enterPriseCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && retNoMngSetList == null)
                            {
                                this.ShowExclamation(MessageMng.ERR_MES_015 + status);
                                return;
                            }

                            //�l��Gurid�ɃZ�b�g���܂��B
                            this.SetDataToGrid(retNoMngSetList, tNdtWrHsCd.Text.Trim().PadLeft(secCodeLength,'0'));
                            //���̃R���g���[���Ƀt�H�[�J�X��J�ڂ��܂��B
                            tNdtAdd.Focus();
                        }
                    }

                }


            }
            catch(Exception ex)
            {
                this.cnvErrMes = ex.Message;
                e.Cancel = true;
            }

        }

        /// <summary>
        /// NS�W�v�c�[���N��
        /// </summary>
        /// <param name="exeName">PG����</param>
        /// <remarks>
        /// <br>Note       : ���p���ꂽ���Ƃ����m�点����NS�W�v�v���O�������N�����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/27<</br>
        /// </remarks>
        private void NsToolLogLoad(string exeName)
        {
            try
            {
                // �N������PG�����w�肵�܂��B
                string wkPg = ".\\" + "NsToologUploader.exe";

                // PG���N�����܂��B
                // �������APG�����݂��Ȃ������牽�����Ȃ��ŁA�����̏����͒��f���܂��B
                if (System.IO.File.Exists(wkPg.ToString()))
                {
                    // ����܂����B
                    // ���̂܂ܑ����܂��傤�B
                }
                else
                {
                    // PG�N���͂�����߂܂��B
                    return;
                }

                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                // �N������PG���Z�b�g���܂��B
                startInfo.FileName = wkPg.ToString();

                // �������Z�b�g���܂��B
                startInfo.Arguments = exeName.ToString();

                // PG��ʃv���Z�X�Ƃ��ċN��
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(startInfo);

            }
            catch
            {
                //�G���[���łĂ��X���[����
                return;
            }
            
        }

        /// <summary>
        /// �ԍ��Ǘ��}�X�^�̍X�V���e��ݒ肵�܂�
        /// </summary>
        /// <param name="row">���DataGrid�̖��׃f�[�^</param>
        /// <returns>�ԍ��Ǘ��}�X�^�X�V�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �ԍ��Ǘ��}�X�^�̍X�V���e��ݒ肵�܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/9<</br>
        /// </remarks>
        private NoMngSet GetnoMgWork(UltraGridRow row)
        {
            NoMngSet noMgSet = new NoMngSet();

            foreach (NoMngSet noMgWork in this.noMgSetWork)
            {
                if (noMgWork.NoCode == Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO].Value))
                {
                    //�ԍ����ݒl
                    noMgWork.NoPresentVal = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);
                    //�ݒ�J�n�ԍ�
                    noMgWork.SettingStartNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ST].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);

                    //�ݒ�I���ԍ�
                    switch (noMgWork.NoCode)
                    {

                        case uoeNo:
                            if (999999 == Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value))
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value);
                            }
                            else
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);
                            }
                            break;

                        default:
                            if (999999999 == Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value))
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value);
                            }
                            else
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);
                            }
                            break;
                    }

                    noMgSet = noMgWork;
                    break;
                }
            }

            return noMgSet;
 
        }


        /// <summary>
        /// �R�[�h�ϊ��Ώۃf�[�^�擾����
        /// </summary>
        /// <returns>�R�[�h�ϊ��Ώۂ̃f�[�^�̃��X�g</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ��̑ΏۂƂȂ��Ă���f�[�^���O���b�h����擾���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/11<</br>
        /// </remarks>
        private IList<SlipNOConvertDispInfo> GetConvertDispData()
        {
            //�R�[�h�ϊ��Ώۂ̃f�[�^���O���b�h����擾���܂�
            IList<SlipNOConvertDispInfo> dispDataList = new List<SlipNOConvertDispInfo>(this.ultrGrid.Rows.Count);

            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // �ԍ������l����l���擾���A�l�������ꍇ�͎��̍s��
                if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) ||
                        this.IsCodeZero(row))
                {
                    continue;
                }
                
                //�X�V������ۑ����܂��B
                SlipNOConvertDispInfo dispData = new SlipNOConvertDispInfo();

                //�ԍ��R�[�h(�����Ώ۔ԍ�)
                dispData.NoCode = Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO].Value);
                //�ԍ��R�[�h����(�����Ώ۔ԍ�)
                dispData.NoCodeName = Convert.ToString(row.Cells[GridSettingInfo.COL_NO_NM].Value);
                //�ԍ����ݒl
                dispData.NoPresentVal = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Value);
                //�ݒ�J�n�ԍ�
                dispData.SettingStartNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ST].Value);
                //�ݒ�I���ԍ�
                dispData.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value);
                //�ԍ������l
                dispData.NoIncDecWidth = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);

                dispDataList.Add(dispData);
            }

            return dispDataList;
        }

        /// <summary>
        /// �ϊ��e�[�u�����擾����
        /// </summary>
        /// <param name="no">�ԍ��R�[�h(�����Ώ۔ԍ�)</param>
        /// <returns>�ϊ��e�[�u�����̃��X�g</returns>
        /// <remarks>
        /// <br>Note       : �ϊ��Ώۂ̃e�[�u������ێ����Ă���XML�f�[�^����擾���܂�</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/11<</br>
        /// </remarks>
        private IList<SlpNoTargetTableListResult> GetTargetTableList(int no,IDictionary<int, IList<SlpNoTargetTableListResult>> trgTblMap)
        {
            //������
            IList<SlpNoTargetTableListResult> targetList = new List<SlpNoTargetTableListResult>();

            //XML�f�[�^�ɔԍ��R�[�h�̃f�[�^�����邩�`�F�b�N����
            if(!trgTblMap.ContainsKey(no))
            {
                return targetList;
            }

            //�擾�����ԍ��R�[�h�i�����Ώ۔ԍ��j�̃��X�g���쐬����
            foreach(SlpNoTargetTableListResult work in trgTblMap[no])
            {
                targetList.Add (work);
            }

            return targetList;
        }

        /// <summary>
        /// ���O�t�@�C���p�X�쐬����
        /// </summary>
        /// <returns>���O�t�@�C���̐�΃p�X</returns>
        /// <remarks>
        /// <br>Note       : ���O�t�@�C���̐�΃p�X���쐬���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14<</br>
        /// </remarks>
        private string CreateLogFilePath()
        {
            // �f�B���N�g�������쐬
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05151UA.LOG_DIR_PATH);
            // ���O�t�@�C�������쐬
            string fileName = String.Format(PMKHN05151UA.LOG_FILE_NAME, 
                DateTime.Now.ToString(PMKHN05151UA.LOG_FORMAT_DATE));

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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/15<</br>
        /// </remarks>
        private string GenerateLogFormat(string format, string[] prms)
        {
            List<string> prmList = new List<string>();
            prmList.Add(DateTime.Now.ToString(PMKHN05151UA.DATE_FORMAT));
            foreach (string prm in prms)
            {
                prmList.Add(prm);
            }

            return String.Format(format, prmList.ToArray());
        }
        /// <summary>
        /// �ԍ������l���菈��(0�`�F�b�N)
        /// </summary>
        /// <param name="row">�s�f�[�^</param>
        /// <returns>true:0/false:��0</returns>
        /// <remarks>
        /// <br>Note       : �ԍ������l��0�ł��邩�ۂ��𔻒肵�܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/06<</br>
        /// </remarks>
        private bool IsCodeZero(UltraGridRow row)
        {
            return Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) == 0 ?
                true : false;
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�X�V����
        /// </summary>
        /// <param name="mes">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[���X�V���邽�߂̃f���Q�[�g�B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14<</br>
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
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_007;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Red;
                    // �G���[���b�Z�[�W��\��
                    string errMes = String.IsNullOrEmpty(this.cnvErrMes) ? MessageMng.ERR_MES_016: this.cnvErrMes;
                    this.ShowError(errMes, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    this.cnvErrMes = String.Empty;
                }
                else
                {
                    // �X�e�[�^�X�o�[���X�V
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value =
                        this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Maximum;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_006;

                    // �������̓������Ɋi�[���Ă���X�V�f�[�^���N���A���܂�
                    this.slipConvertDtList.Clear();

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
                this.ShowError(String.Format(MessageMng.ERR_MES_022, ex.Message), (int)ConstantManagement.MethodResult.ctFNC_ERROR);
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

                    //-------2018.09.27 NS�c�[���W�v�v���O�����ǉ��@�q���@Start---------------------------------------------------------------------//

                    string exeName = "PMKHN05150U.exe";
                    this.NsToolLogLoad(exeName);

                    //-------2018.09.27 NS�c�[���W�v�v���O�����ǉ��@�q���@End-----------------------------------------------------------------------//

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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14<</br>
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
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void PMKHN05131UA_Shown(object sender, EventArgs e)
        {
            // ���_�K�C�h���͂Ƀt�H�[�J�X���Z�b�g
            this.tNdtWrHsCd.Focus();
        }

        /// <summary>
        /// ���_�K�C�h�{�^���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^�����N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h���N��
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            bool isMainOffice = false;
            int status = secInfoSetAcs.ExecuteGuid(this.enterPriseCd, isMainOffice, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSet != null)
            {
                // �l����͗��ɃZ�b�g���܂��B
                this.tNdtWrHsCd.DataText = secInfoSet.SectionCode.Trim().PadLeft(secCodeLength,'0');
                this.tEdtWrHsNm.DataText = secInfoSet.SectionGuideNm.Trim();
                // ���̃R���g���[���Ƀt�H�[�J�X��J�ڂ��܂��B
                tNdtAdd.Focus();

                //�f�[�^���������Z�b�g����
                this.Search();
            }
        }

        /// <summary>
        /// �c�[�����j���[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �c�[�����j���[���N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void tTooBarMain_ToolClick(object sender, ToolClickEventArgs e)
        {
            // �t�H�[�J�X��擪�ɖ߂��܂��B
            this.tNdtWrHsCd.Focus();

            // �N���b�N�������j���[�ɂ���ď����𕪊�
            switch (e.Tool.Key)
            {
                // �I��
                case ToolMenuType.BTN_TOOL_CLOSE:
                �@�@//�X�V�f�[�^�����邩�m�F������ꍇ�̓��b�Z�[�W���o���I
                    //�y�ԍ������l���w�肳��Ă��邩�`�F�b�N������z
                    this.isCheckOK = this.CheckNoIncDec();
                    if (isCheckOK)
                    {
                        DialogResult dlr = this.ShowInfo2(MessageMng.INFO_MES_008);

                        if(dlr == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (dlr == DialogResult.Yes)
                        {
                            this.SlpNoConvert();
                            return;
                        }
                        else
                        {
                            ((Form)this.Parent).Close();
                            break;
                        }

                    }
                    else
                    {
                        ((Form)this.Parent).Close();
                        break;
                    }

                // ���s
                case ToolMenuType.BTN_TOOL_EXEC:
                    this.SlpNoConvert();
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
        /// �ꊇ�ݒ�敪��ύX���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ꊇ�ݒ�敪��ύX���̏����ł��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/11</br>
        /// </remarks>
        private void ultrRbtnCllctvSttng_ValueChanged(object sender, EventArgs e)
        {
            AllSettingType type = (AllSettingType)Enum.ToObject(typeof(AllSettingType), Convert.ToInt32(this.ultrRbtnCllctvSttng.Value));

            switch (type)
            {
                //���Z
                case AllSettingType.ADD:
                    tNdtSub.Text = "";
                    tNdtSub.Enabled = false;
                    tNdtAdd.Enabled = true;
                    break;

                //���Z
                case AllSettingType.Multiplication:
                    tNdtAdd.Text = "";
                    tNdtSub.Enabled = true;
                    tNdtAdd.Enabled = false;

                    break;
            }

        }

        /// <summary>
        /// ���_�R�[�h���ύX���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���ύX���ꂽ�ۂ̏���</br>
        /// <br>Programmer : 30175 �q��/br>
        /// <br>Date       : 2018/09/20</br>
        /// </remarks>
        private void tNdtWrHsCd_ValueChanged(object sender, EventArgs e)
        {
            // ���_�R�[�h���擾���l������ꍇ�́A���_���̂��Z�b�g����
            this.SetName(this.tNdtWrHsCd, this.tEdtWrHsNm);

            //�f�[�^���������Z�b�g����
            this.Search();

            // �X�e�[�^�X�o�[��������Ԃɖ߂��܂��B
            this.InitStatusBar();


        }

        /// <summary>
        /// �ꊇ�ݒ�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ꊇ�ݒ�{�^�����N���b�N����ƃC�x���g���������܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void ultrBtnSttng_Click(object sender, EventArgs e)
        {

            // �ꊇ�ݒ�̃^�C�v
            AllSettingType type = (AllSettingType)Enum.ToObject(typeof(AllSettingType), Convert.ToInt32(this.ultrRbtnCllctvSttng.Value));
            bool bl = false;
            
            // �O���b�h�̃f�[�^
            DataTable tbl = ((DataView)this.ultrGrid.DataSource).Table;

            //�l�����͂���Ă��邩�`�F�b�N���s��
            switch(type)
            {
                //�y���Z��I�����z
                case AllSettingType.ADD:

                    //�`�F�b�N���s��
                    bl = this.IsNotNumber(tNdtAdd);

                    //�l�����͂���Ă��Ȃ��ꍇ
                    if(bl)
                    {
                        break;
                    }

                    //�e�s�ɒl���Z�b�g����
                    foreach(DataRow row in tbl.Rows)
                    {
                        row[GridSettingInfo.COL_NO_IDV] = Convert.ToInt64(tNdtAdd.Text);
                    }
                    
                    break;


                //�y���Z��I�����z
                case AllSettingType.Multiplication:

                    //�`�F�b�N���s��
                    bl = this.IsNotNumber(tNdtSub);
                    
                �@�@//�l�����͂���Ă��Ȃ��ꍇ
                    if(bl)
                    {
                        break;
                    }

                    //�e�s�ɒl���Z�b�g����
                    foreach(DataRow row in tbl.Rows)
                    {
                        row[GridSettingInfo.COL_NO_IDV] = Convert.ToInt64(tNdtSub.Text) * -1;
                    }
                    
                    break;

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
        /// <br>Date       : 2017/12/15<</br>
        /// </remarks>
        public void PMKHN05151UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �ҏW�ς݃t���O��on�̎��̂ݏ������s���܂��B
            if (this.isEdit)
            {
                // �t�H�[�J�X��擪�ɖ߂��܂��B
                this.tNdtWrHsCd.Focus();

                // �ύX��̔ԍ�������œ��͂���Ă���Z���̐��𐔂��܂�
                int editedCount = 0;
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text) &&
                        Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO_IDV].Value) != 0)
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
                        MessageMng.INFO_MES_005, 0, MessageBoxButtons.YesNoCancel);

                    // DialogResult�̌��ʂɉ����ď����𕪊򂳂��܂�
                    if (result == DialogResult.Yes)
                    {
                        // close�C�x���g���L�����Z�����܂�
                        e.Cancel = true;
                        // FormCloseing�C�x���g����R�[�h�ϊ������s����̂Ńt���O��on�ɂ��܂��B
                        this.isCallFormCloseingEvent = true;
                        // OK�������������́A�o�^�����{���Ă���I�����܂��B
                        this.SlpNoConvert();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // �L�����Z���������������́A�I���������L�����Z�����܂��B
                        e.Cancel = true;
                    }
                }
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
        /// �ꊇ�ݒ�̃^�C�v��\���񋓎q
        /// </summary>
        private enum AllSettingType
        {
            /// <summary>���Z</summary>
            ADD,
            /// <summary>���Z</summary>
            Multiplication,
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
        /// PM.NS�`�[�ԍ��ϊ������c�[���@�O���b�h�̌Œ�ݒ����ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̌Œ�ݒ����ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private class GridSettingInfo
        {
            #region -- Constractor --

            /// <summary>
            /// PM.NS�`�[�ԍ��ϊ������c�[���@�O���b�h�̌Œ�ݒ����ۑ����������N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : PM.NS�`�[�ԍ��ϊ������c�[���A�O���b�h�̌Œ�ݒ����ۑ����������N���X�̏����������s���܂��B</br>
            /// <br>Programmer : 30175 �q��</br>
            /// <br>Date       : 2018/09/04</br>
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

            /// <summary>�ԍ�</summary>
            public const string COL_NO = "�ԍ�";
            /// <summary>�ԍ���</summary>
            public const string COL_NO_NM = "�ԍ���";
            /// <summary>�ԍ����ݒl</summary>
            public const string COL_NO_PT = "�ԍ����ݒl";
            /// <summary>�ݒ�J�n�ԍ�</summary>
            public const string COL_NO_ST = "�ݒ�J�n�ԍ�";
            /// <summary>�ݒ�I���ԍ�</summary>
            public const string COL_NO_ED = "�ݒ�I���ԍ�";
            /// <summary>�ԍ������l</summary>
            public const string COL_NO_IDV = "�ԍ������l";
            /// <summary>�ԍ�������</summary>
            public const string COL_NO_IDW = "�ԍ�������";

            #endregion

            #region -- �� --

            /// <summary>�ԍ�����̗�</summary>
            public const int COL_NO_NM_WIDTH = 350;
            /// <summary>�ԍ����ݒl��̗�</summary>
            public const int COL_NO_PT_WIDTH = 110;
            /// <summary>�ݒ�J�n�ԍ���̗�</summary>
            public const int COL_NO_ST_WIDTH = 110;
            /// <summary>�ݒ�I���ԍ���̗�</summary>
            public const int COL_NO_ED_WIDTH = 110;
            /// <summary>�ԍ������l��̗�</summary>
            public const int COL_NO_IDV_WIDTH = 110;

            #endregion

            #endregion
        }

        /// <summary>
        /// PM.NS�`�[�ԍ��ϊ������c�[���@���j���[�̏���ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[�����j���[�̏���ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
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
        ///  PM.NS�`�[�ԍ��ϊ������c�[���@�X�e�[�^�X�o�[�̏���ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �X�e�[�^�X�o�[�̏���ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/05</br>
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
        /// PM.NS�`�[�ԍ��ϊ������c�[���@���b�Z�[�W����ۑ����������N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W����ۑ����������N���X�ł��B</br>
        /// <br>Programmer : 30175 �q��/br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private class MessageMng
        {
            #region -- �G���[���b�Z�[�W --

            /// <summary>ERR_MES_001:���_�R�[�h���w�肳��Ă��܂���B</summary>
            public const string ERR_MES_001 = "���_�R�[�h���w�肳��Ă��܂���B";
            /// <summary>ERR_MES_002:�f�[�^�̎擾�Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_002= "�f�[�^�̎擾�Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_003:�ԍ������l���w�肳��Ă��܂���B</summary>
            public const string ERR_MES_003 = "�ԍ������l���w�肳��Ă��܂���B";
            /// <summary>ERR_MES_004:���������Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_004 = "���������Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_005:���}�C�i�X�l�ɂȂ��Ă��܂��܂��B</summary>
            public const string ERR_MES_005 = "���}�C�i�X�l�ɂȂ��Ă��܂��܂��B";
            /// <summary>ERR_MES_006:���ő�l�u999999999�v�𒴂��Ă��܂��B</summary>
            public const string ERR_MES_006 = "���ő�l�u999999999�v�𒴂��Ă��܂��B";
            /// <summary>ERR_MES_007:���ő�l�u999999�v�𒴂��Ă��܂��B</summary>
            public const string ERR_MES_007 = "���ő�l�u999999�v�𒴂��Ă��܂��B";
            /// <summary>ERR_MES_008:���ő�l�u99999999�v�𒴂��Ă��܂��B</summary>
            public const string ERR_MES_008 = "���ő�l�u99999999�v�𒴂��Ă��܂��B";
            /// <summary>ERR_MES_009:���Z���鐔�l���w�肳��Ă��܂���B</summary>
            public const string ERR_MES_009 = "���Z���鐔�l���w�肳��Ă��܂���B";
            /// <summary>ERR_MES_010:���Z���鐔�l���w�肳��Ă��܂���B</summary>
            public const string ERR_MES_010 = "���Z���鐔�l���w�肳��Ă��܂���B";
            /// <summary>ERR_MES_011:���l���w�肳��Ă��܂���B</summary>
            public const string ERR_MES_011 = "���l�ł͂Ȃ��l�����͂���Ă��܂��B";
            /// <summary>ERR_MES_012:�u�����v�����{���ēx�������s���Ă��������B</summary>
            public const string ERR_MES_012 = "\r\n�u�����v�����{���ēx�������s���Ă��������B";
            /// <summary>ERR_MES_013:���ɁA�Đݒ��̔ԍ������݂��܂��B</summary>
            public const string ERR_MES_013 = "���ɁA�Đݒ��̔ԍ������݂��܂��B\r\n";
            /// <summary>ERR_MES_014:�ԍ��Ǘ��}�X�^�̓o�^�Ɏ��s���܂����Bst="</summary>
            public const string ERR_MES_014 = "�ԍ��Ǘ��}�X�^�̓o�^�Ɏ��s���܂����Bst=";
            /// <summary>ERR_MES_015:�ԍ��Ǘ��}�X�^�̎擾�Ɏ��s���܂����Bst=</summary>
            public const string ERR_MES_015 = "�ԍ��Ǘ��}�X�^�̎擾�Ɏ��s���܂����Bst=";
            /// <summary>ERR_MES_016:�`�[�ԍ��ϊ������Ɏ��s���܂����B</summary>
            public const string ERR_MES_016 = "�`�[�ԍ��ϊ������Ɏ��s���܂����B";
            /// <summary>ERR_MES_017:�`�[�ԍ��ϊ��Ώۃt�@�C���ɑΏۂƂȂ�e�[�u��������܂���B\r\n�t�@�C�����e���������Ă��������B</summary>
            public const string ERR_MES_017 = "�`�[�ԍ��ϊ��Ώۃt�@�C���ɑΏۂƂȂ�e�[�u��������܂���B\r\n�t�@�C�����e���������Ă��������B";
            /// <summary>ERR_MES_018:�`�[�ԍ��ϊ��Ώۃt�@�C���ɕs���ȃf�[�^���L��܂��B\r\n�t�@�C���̓��e���������Ă��������B</summary>
            public const string ERR_MES_018 = "�`�[�ԍ��ϊ��Ώۃt�@�C���ɕs���ȃf�[�^���L��܂��B\r\n�t�@�C���̓��e���������Ă��������B";
            /// <summary>ERR_MES_019:�`�[�ԍ��ϊ��Ώۃt�@�C��������܂���B</summary>
            public const string ERR_MES_019 = "�`�[�ԍ��ϊ��Ώۃt�@�C��������܂���B";
            /// <summary>ERR_MES_020:�`�[�ԍ��ϊ� �`�F�b�N�����Ɏ��s���܂����B</summary>
            public const string ERR_MES_020 = "�`�[�ԍ��ϊ� �`�F�b�N�����Ɏ��s���܂����B";
            /// <summary>ERR_MES_021:�`�[�ԍ��ϊ� �`�F�b�N�����Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_021 = "�`�[�ԍ��ϊ� �`�F�b�N�����Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_022:�`�[�ԍ��ϊ������Ɏ��s���܂����B\r\n�ڍ�\r\n{0}</summary>
            public const string ERR_MES_022 = "�`�[�ԍ��ϊ������Ɏ��s���܂����B\r\n�ڍ�\r\n{0}";
            /// <summary>ERR_MES_023:�̕ϊ��Ώۃt�@�C��������܂���B\r\n�ԍ��Ǘ��ݒ�̂ݍX�V���s���܂��B</summary>
            public const string ERR_MES_023 = "�̕ϊ��Ώۃt�@�C��������܂���B\r\n�ԍ��Ǘ��ݒ�̂ݍX�V���s���܂��B";

            #endregion

            #region -- �C���t�H���b�Z�[�W --

            /// <summary>INFO_MES_001:�������J�n���Ă���낵���ł����H</summary>
            public const string INFO_MES_001 = "�������J�n���Ă���낵���ł����H";
            /// <summary>INFO_MES_002:�`�[�ԍ��ϊ�����</summary>
            public const string INFO_MES_002 = "�`�[�ԍ��ϊ�����";
            /// <summary>INFO_MES_003:���݁A�ԍ��ϊ��������ł��B\r\n���΂炭���҂���������</summary>
            public const string INFO_MES_003 = "���݁A�ԍ��ϊ��������ł��B\r\n���΂炭���҂���������";
            /// <summary>INFO_MES_004:�R�[�h�F�R�[�h�F{0}��ϊ���... {1}/{2}��</summary>
            public const string INFO_MES_004 = "{0}��ϊ���... {1}/{2}��";
            /// <summary>INFO_MES_005:�ҏW���̃f�[�^���݂��܂��B\r\n�R�[�h�ϊ����������s���܂����H</summary>
            public const string INFO_MES_005 = "�ҏW���̃f�[�^���݂��܂��B\r\n�`�[�ԍ��ϊ����������s���܂����H";
            /// <summary>INFO_MES_006:�R�[�h�ϊ�����</summary>
            public const string INFO_MES_006 = "�R�[�h�ϊ�����";
            /// <summary>INFO_MES_007:�G���[</summary>
            public const string INFO_MES_007 = "�G���[";
            /// <summary>INFO_MES_008:�ҏW���̃f�[�^�����݂��܂��B�`�[�ԍ������������s���܂����H</summary>
            public const string INFO_MES_008 = "�ҏW���̃f�[�^�����݂��܂��B�`�[�ԍ������������s���܂����H";
            
            #endregion
        }

        #endregion

        
       
    }
}