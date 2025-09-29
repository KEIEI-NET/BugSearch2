using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���㑬��\��
    /// </summary>
    ///<remarks>
    /// <br>Note        : ���㑬��\��UI�t�H�[���N���X</br>
    /// <br>Programmer  : 30418 ���i</br>
    /// <br>Date        : 2008/11/21</br>
    /// </remarks>
    public partial class PMHNB04151UA : Form
    {

        #region �v���C�x�[�g�ϐ�

        #region ���[�J���N���X

        /// <summary>���㑬��\�����o�����N���X</summary>
        SalesReportOrderCndtn _salesReportOrderCndtn = null;

        /// <summary>���㑬��\���A�N�Z�X�N���X</summary>
        SalesReportAcs _salesReportAcs = null;

        /// <summary>���㑬��ݒ�\���A�N�Z�X�N���X</summary>
        SalesReportSettingAcs _salesReportSettingAcs = null;

        #endregion // ���[�J���N���X

        #region �N���X

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoAcs _secInfoAcs;

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>���_���f�[�^�N���X</summary>
        private SecInfoSet _sectionInfo;

        /// <summary>���Џ��A�N�Z�X�N���X</summary>
        private DateGetAcs _dateGetAcs = null;

        /// <summary>UI�X�L���ݒ�R���g���[��</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        #endregion // �N���X

        #region �f�[�^�Z�b�g

        /// <summary>���㑬��\�����f�[�^�Z�b�g</summary>
        SalesReportDataSet _dataSet = null;

        #endregion // �f�[�^�Z�b�g

        #region �R�[�h��

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>�����_�R�[�h</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>���O�C�����[�U�[�R�[�h</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>���O�C�����[�U�[��</summary>
        private string _loginUserName = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        /// <summary>�{�^���p�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;

        /// <summary>�ݒ���s�t���O</summary>
        private bool _alreadySetup = false;

        /// <summary>�N�����̒��o</summary>
        private int _startupSearch = 0;

        /// <summary>�����X�V</summary>
        private int _autoUpdate = 0;

        /// <summary>���_�̏����l</summary>
        private int _initialSectionCode = 0;

        /// <summary>�t�H���g�ݒ�l</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        #endregion // �R�[�h��

        #endregion // �v���C�x�[�g�ϐ�

        #region �萔

        /// <summary>�S�ЃR�[�h���́F�����l�u�S�Ёv</summary>
        private const string CT_NAME_ALLSECCODE = "�S��";

        /// <summary>�S�ЃR�[�h�F�����l�u00�v</summary>
        private const string CT_CODE_ALLSECCODE = "00";

        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>�N���������F����</summary>
        private const int CT_STARTUP_SEARCH_ON = 0;

        /// <summary>�N���������F���Ȃ�</summary>
        private const int CT_STARTUP_SEARCH_OFF = 1;

        /// <summary>���_�R�[�h�����l�F�����_</summary>
        private const int CT_DEFSECTIONCODE_BELONG = 0;

        /// <summary>���_�R�[�h�����l�F�S��</summary>
        private const int CT_DEFSECTIONCODE_WHOLE = 1;

        /// <summary>XML�t�@�C�����́F�����l�uPMKHN04150U_Construction.XML�v</summary>
        private const string CT_XML_FILE_NAME = "PMKHN04150U_Construction.XML";

        #region ���b�Z�[�W�萔

        /// <summary>�G���[���b�Z�[�W�F�u������͕K�{���͍��ڂł��B�v</summary>
        private const string CT_DATE_NOT_INPUT = "������͕K�{���͍��ڂł��B";

        // 2008.12.01 add start [8486]
        /// <summary>�G���[���b�Z�[�W�F�u�ɐ��������t����͂��Ă��������B�v</summary>
        private const string CT_DATE_INVALID = "�ɐ��������t����͂��Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u������̊J�n���́A�I���������O�̓��t��I�����Ă��������B�v</summary>
        private const string CT_DATE_RANGE_INVALID = "������̊J�n���́A�I���������O�̓��t��I�����Ă��������B";
        // 2008.12.01 add end [8486]

        /// <summary>�G���[���b�Z�[�W�F�u���͂��ꂽ���_�R�[�h���g�p�ł��܂���B�v</summary>
        private const string CT_INVALID_SECTION = "���͂��ꂽ���_�R�[�h���g�p�ł��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�I�����ꂽ������͓��ꌎ���ł͂���܂���B�v</summary>
        private const string CT_DATE_NOT_IN_TERM = "�I�����ꂽ������͓��ꌎ���ł͂���܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u��ƃR�[�h���擾����Ă��܂���B�v</summary>
        private const string CT_ENTERPRISE_CODE_NOT_QUALIFIED = "��ƃR�[�h���擾����Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�Y������f�[�^��������܂���ł����B�v</summary>
        private const string CT_NOT_FOUND = "�Y������f�[�^��������܂���ł����B";

        /// <summary>���b�Z�[�W�F�u ���̃f�[�^��������܂����B�v</summary>
        private const string CT_FOUND_RECORD = " ���̃f�[�^��������܂����B";

        /// <summary>���b�Z�[�W�F�u�����X�V�̊Ԋu��{0}���ɐݒ肵�܂����B�v</summary>
        private const string CT_AUTOUPDATE_SET_FOR = "�����X�V�̊Ԋu��{0}���ɐݒ肵�܂����B";

        /// <summary>���b�Z�[�W�F�u�ŏI�X�V�����F{0}�v</summary>
        private const string CT_LASTTIMEUPDATE = "�ŏI�X�V�����F{0}";

        #endregion // ���b�Z�[�W�萔

        #region �O���b�h�z�F

        /// <summary>�O���b�h �J���[1</summary>
        private readonly Color _rowFiscalColBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>�O���b�h �J���[2</summary>
        private readonly Color _rowFiscalColBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _rowFiscalColForeColor1 = Color.FromArgb(255, 255, 255);

        /// <summary>�O���b�h �w�b�_�[�J���[1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>�O���b�h �w�b�_�[�J���[2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>�O���b�h �����F1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);

        #endregion // �O���b�h�z�F

        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB04151UA()
        {
            InitializeComponent();
            
            // �����ݒ�
            InitializeVariable();

        }

        /// <summary>
        /// �t�H�[���\����C�x���g�i�����t�H�[�J�X�֘A�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04121UA_Shown(object sender, System.EventArgs e)
        {
            // �����t�H�[�J�X�i���_�j
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�֐�

        #region �����z�u

        /// <summary>
        /// �R���g���[���ޏ����z�u
        /// </summary>
        private void InitializeVariable()
        {

            // UI�X�L���ݒ�R���g���[��������
            this._controlScreenSkin = new ControlScreenSkin();

            #region �ݒ�̎擾

            this._salesReportSettingAcs = new SalesReportSettingAcs();

            // �ݒ���擾
            this._salesReportSettingAcs.Deserialize();

            // �ݒ���e���擾
            this._alreadySetup = this._salesReportSettingAcs.AlreadySetup;
            this._startupSearch = this._salesReportSettingAcs.StartupSearch;
            this._autoUpdate = this._salesReportSettingAcs.AutoUpdateTime;
            this._initialSectionCode = this._salesReportSettingAcs.InitialSectionCode;

            // �^�C�}�[�Z�b�g
            if (this._autoUpdate > 0)
            {
                // �^�C�}�[�̋N�����Ԃ��Z�b�g(���P�ʂȂ̂�*60(�b),*1000(�~���b))
                this.timer_AutoUpdate.Interval = this._autoUpdate * 60 * 1000;
                this.timer_AutoUpdate.Enabled = true;

                this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Format(CT_AUTOUPDATE_SET_FOR, this._autoUpdate.ToString());
            }
            else
            {
                this.timer_AutoUpdate.Enabled = false;
            }

            #endregion // �ݒ�̎擾

            #region �A�N�Z�X�N���X������

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();          // ���_
            this._dateGetAcs = DateGetAcs.GetInstance();        // ���Аݒ�擾

            #endregion // �A�N�Z�X�N���X������

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // ��ƃR�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // �����_�R�[�h
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ���O�C�����[�U�[�R�[�h
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ���O�C�����[�U�[��

            #region �{�^���C���[�W�ݒ�

            // �C���[�W���X�g���w��(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // �{�^���C���[�W��ݒ�
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // �c�[���o�[�A�C�R��
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 ��QID:12293�Ή�------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            // --- CHG 2009/03/12 ��QID:12293�Ή�------------------------------------------------------<<<<<
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setting"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SETUP1;

            #endregion // �{�^���C���[�W�ݒ�

            #region ���������N���X�쐬

            this._salesReportOrderCndtn = new SalesReportOrderCndtn();
                        
            #endregion // ���������N���X�쐬

            #region �R���g���[���X�L���Ή�

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // �R���g���[���X�L���Ή�

            #region �O���b�h�ݒ�

            //// �A�N�Z�X�N���X�����������A�f�[�^�Z�b�g���擾
            this._salesReportAcs = new SalesReportAcs();
            this._dataSet = this._salesReportAcs.DataSet;

            //// �O���b�h�ŕ\���Ɏg�p����f�[�^�r���[���쐬
            DataView dView = new DataView(this._dataSet.SalesReportResult);

            //// �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = dView;

            //// �O���b�h���ݒ�
            InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

            #endregion // �O���b�h�ݒ�

            // ��ʃN���A
            InitializeScreen();

            // �O���b�h�𒲐����Ă���
            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = true;
            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }

            // �N���������ł���Ό���
            if (this._startupSearch == CT_STARTUP_SEARCH_ON)
            {
                this.Search();
            }
        }

        #endregion // �����z�u

        #region ���_���̎擾

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCd">�������鋒�_�R�[�h</param>
        /// <returns>���_��</returns>
        private string GetSectionName(string sectionCd)
        {
            int status = this._secInfoSetAcs.Read(out _sectionInfo, this._enterpriseCode, sectionCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 2008.12.01 add start [8495]
                if (_sectionInfo.LogicalDeleteCode == 0)
                {
                    return _sectionInfo.SectionGuideNm;
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                        CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                    this.tEdit_SectionCodeAllowZero.Clear();
                    return string.Empty;
                }
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                    CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                this.tEdit_SectionCodeAllowZero.Clear();
                // 2008.12.01 add end [8495]
                return string.Empty;
            }
        }

        #endregion // ���_���̎擾

        #region ��ʂ̏�����

        /// <summary>
        /// ��ʂ̏�����
        /// </summary>
        private void InitializeScreen()
        {
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();

            // �f�[�^�Z�b�g���N���A
            this._dataSet.SalesReportResult.Clear();

            // �����l��ݒ�l�ɏ]���ĕ\��
            if (this._initialSectionCode == CT_DEFSECTIONCODE_BELONG) // �����_
            {
                this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode.Trim().PadLeft(2, '0');
                this.tEdit_SectionName.Text = GetSectionName(this._loginSectionCode);
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = CT_CODE_ALLSECCODE;
                this.tEdit_SectionName.Text = CT_NAME_ALLSECCODE;
            }

            // ������i�ǂ���������j
            this.tDateEdit_SalesDateSt.SetDateTime(DateTime.Today);
            this.tDateEdit_SalesDateEd.SetDateTime(DateTime.Today);

            // ���O�C�����[�U�[���\��
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;

            // �����T�C�Y�ݒ�
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }

            // �����T�C�Y�����l
            this.tComboEditor_StatusBar_FontSize.Text = CT_DEF_FONT_SIZE.ToString();

            // 2008.12.01 add start [8507]
            // �X�e�[�^�X�o�[���N���A
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;
            // 2008.12.01 add end [8507]

            // �t�H�[�J�X�����_��
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // ��ʂ̏�����

        #region �O���b�h�񏉊���

        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="Columns"></param>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // �\���`���̂����Ŏg�p
            string formatCurrency = "#,##0;-#,##0;";
            string formatPercentage = "##0.00;";

            // �\���ʒu�����l
            int visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------

            // ���_�i���_�K�C�h���́j
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Width = 130;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Caption = "���_";
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ������
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Caption = "������";
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ����ڕW
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Caption = "����ڕW";
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �B����
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Width = 80;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Caption = "�B����";
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Format = formatPercentage;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �e��
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Caption = "�e��";
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �e���ڕW
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Caption = "�e���ڕW";
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �B����
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Width = 80;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Caption = "�B����";
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Format = formatPercentage;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ғ���
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Caption = "�ғ���";
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
        }

        #endregion // �O���b�h�񏉊���

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        private void Search()
        {
            // ���b�Z�[�W���N���A
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;


            // ��ʂ��猟�������N���X���쐬

            // ��ƃR�[�h���Z�b�g
            this._salesReportOrderCndtn.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h���Z�b�g
            if (this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("0") ||
                this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("00"))
            {
                this._salesReportOrderCndtn.SectionCode = string.Empty;
            }
            else if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                this._salesReportOrderCndtn.SectionCode = string.Empty;
            }
            else
            {
                this._salesReportOrderCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            }

            // ������J�n���Z�b�g
            this._salesReportOrderCndtn.St_SalesDate = this.tDateEdit_SalesDateSt.GetLongDate();

            // ������I�����Z�b�g
            this._salesReportOrderCndtn.Ed_SalesDate = this.tDateEdit_SalesDateEd.GetLongDate();

            // �p�����[�^�`�F�b�N
            string errorMsg = string.Empty;
            Control checkControl = null;
            checkControl = CheckParameter(out errorMsg);
            if (checkControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                checkControl.Focus();
                return;
            }
            else
            {
                int recordCount = 0;

                // �f�[�^�Z�b�g���N���A
                this._dataSet.SalesReportResult.Clear();

                // �������s
                this._salesReportAcs.Search(this._salesReportOrderCndtn, out recordCount);

                if (recordCount > 0)
                {
                    // �\�[�g�����쐬
                    DataView dView = (DataView)this.uGrid_Details.DataSource;
                    dView.Sort = "RowNo Asc";

                    // �����X�VON�̏ꍇ�͍ŏI�X�V������\��
                    if (this._autoUpdate > 0)
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_FOUND_RECORD + "�@" + string.Format(CT_LASTTIMEUPDATE, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                    }
                    else
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_FOUND_RECORD;
                    }
                }
                else
                {
                    // �����X�VON�̏ꍇ�͍ŏI�X�V������\��
                    if (this._autoUpdate > 0)
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_NOT_FOUND + "�@" + string.Format(CT_LASTTIMEUPDATE, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                    }
                    else
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_NOT_FOUND;
                    }
                }

                // �S�ẴO���b�h�̔w�i�F�𒲐�
                //RowColorChangeAll(false, 0);

            }
        }

        #endregion // ����

        #region �p�����[�^�`�F�b�N

        /// <summary>
        /// �p�����[�^�`�F�b�N�֐�
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private Control CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // �p�����[�^���K�{�̂��̂��`�F�b�N

            // �����(�J�n)
            if (this._salesReportOrderCndtn.St_SalesDate == 0)
            {
                errorMsg = CT_DATE_NOT_INPUT;
                return this.tDateEdit_SalesDateSt;
            }
            // 2008.12.01 add start [8486]
            if (!TDateTime.IsAvailableDate(this.tDateEdit_SalesDateSt.GetDateTime()))
            {
                errorMsg = "�����(�J�n)" + CT_DATE_INVALID;
                return this.tDateEdit_SalesDateSt;
            }
            // 2008.12.01 add end [8486]

            // �����(�I��)
            if (this._salesReportOrderCndtn.Ed_SalesDate == 0)
            {
                errorMsg = CT_DATE_NOT_INPUT;
                return this.tDateEdit_SalesDateEd;
            }
            // 2008.12.01 add start [8486]
            if (!TDateTime.IsAvailableDate(this.tDateEdit_SalesDateEd.GetDateTime()))
            {
                errorMsg = "�����(�I��)" + CT_DATE_INVALID;
                return this.tDateEdit_SalesDateEd;
            }
            // 2008.12.01 add end [8486]

            if (this._salesReportOrderCndtn.St_SalesDate - this._salesReportOrderCndtn.Ed_SalesDate > 0)
            {
                errorMsg = CT_DATE_RANGE_INVALID;
                return this.tDateEdit_SalesDateEd;
            }

            //// ��ƃR�[�h
            //if (String.IsNullOrEmpty(this._salesReportOrderCndtn.EnterpriseCode))
            //{
            //    errorMsg = CT_ENTERPRISE_CODE_NOT_QUALIFIED;
            //    return null;
            //}

            // �J�n�����猎�̏I�������擾
            DateTime dYearMonth;
            int iYear = 0;
            DateTime dStartDate;
            DateTime dEndDate;

            this._dateGetAcs.GetYearMonth(TDateTime.LongDateToDateTime(this._salesReportOrderCndtn.St_SalesDate), out dYearMonth, out iYear, out dStartDate, out dEndDate);
            if (TDateTime.LongDateToDateTime(this._salesReportOrderCndtn.Ed_SalesDate) > dEndDate)
            {
                errorMsg = CT_DATE_NOT_IN_TERM;
                return this.tDateEdit_SalesDateEd;
            }

            return null;
        }

        #endregion // �p�����[�^�`�F�b�N

        #region �O���b�h�̔w�i�F��ύX

        /// <summary>
        /// �s�̔w�i�F�ύX����
        /// </summary>
        /// <param name="isSelected">bool �I������Ă���</param>
        /// <param name="gridRow">�s�I�u�W�F�N�g</param>
        private void RowColorChangeAll(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            //// �Ώۍs���I������Ă��邩�����łȂ����Ŕz�F���قȂ�
            //if (isSelected)
            ////{
            //    // �O���b�h�̔w�i�F��ݒ�
            //    gridRow.Appearance.BackColor = _rowBackColor1;
            //    gridRow.Appearance.BackColor2 = _rowBackColor2;
            //    // �O���f�[�V������ݒ�
            //    gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //}
            //else
            //{
            // �w�i�F��W���̔z�F�ɖ߂�
            if (gridRow.Index % 2 == 1)
            {
                gridRow.Appearance.BackColor = Color.Lavender;
            }
            else
            {
                gridRow.Appearance.BackColor = Color.White;
            }
            // �O���f�[�V������ݒ�
            gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            //}
        }

        #endregion // �O���b�h�̔w�i�F��ύX

        #region �ݒ���

        /// <summary>
        /// �ݒ���
        /// </summary>
        private void OptionSetup()
        {
            // ���b�Z�[�W�N���A
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;

            PMHNB04151UB OptionSetupForm = new PMHNB04151UB();
            OptionSetupForm.AlreadySetup = this._alreadySetup;
            OptionSetupForm.XmlFileName = CT_XML_FILE_NAME;
            OptionSetupForm.AutoUpdate = this._autoUpdate;
            OptionSetupForm.StartupSearch = this._startupSearch;
            OptionSetupForm.InitialSectionCode = this._initialSectionCode;

            DialogResult result = OptionSetupForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this._alreadySetup = OptionSetupForm.AlreadySetup;
                this._autoUpdate = OptionSetupForm.AutoUpdate;
                this._startupSearch = OptionSetupForm.StartupSearch;
                this._initialSectionCode = OptionSetupForm.InitialSectionCode;

                // �ݒ��ۑ�
                this._salesReportSettingAcs.AlreadySetup = this._alreadySetup;
                this._salesReportSettingAcs.AutoUpdateTime = this._autoUpdate;
                this._salesReportSettingAcs.StartupSearch = this._startupSearch;
                this._salesReportSettingAcs.InitialSectionCode = this._initialSectionCode;

                this._salesReportSettingAcs.Serialize();

                // �����X�V���ݒ肳�ꂽ�ꍇ�͓K�p����
                if (this._autoUpdate > 0)
                {
                    this.timer_AutoUpdate.Interval = this._autoUpdate * 60 * 1000;
                    this.timer_AutoUpdate.Enabled = true;

                    this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Format(CT_AUTOUPDATE_SET_FOR, this._autoUpdate.ToString());
                }
            }
        }

        #endregion // �ݒ���

        #endregion // �v���C�x�[�g�֐�

        #region �R���g���[�����\�b�h

        #region �K�C�h�{�^��

        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out _sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = _sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = _sectionInfo.SectionGuideNm.Trim();
                // 2008.12.10 add start [9003]
                this.tDateEdit_SalesDateSt.Focus();
                // 2008.12.10 add start [9003]
            }
            else
            {
                // 2008.12.01 del start [8482]
                //this.tEdit_SectionCodeAllowZero.Clear();
                //this.tEdit_SectionName.Text = "";
                // 2008.12.01 del end [8482]
            }
        }
        
        #endregion // �K�C�h�{�^��

        #region �c�[���o�[

        /// <summary>
        /// �c�[���o�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region �I���{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // �I���{�^��

                #region �m��{�^��
                case "ButtonTool_Decision":
                    {
                        Search();
                        break;
                    }
                #endregion // �m��{�^��

                #region �N���A�{�^��
                case "ButtonTool_Clear":
                    {
                        InitializeScreen();
                        break;
                    }
                #endregion // �N���A�{�^��


                #region �ݒ�{�^��
                case "ButtonTool_Setting":
                    {
                        OptionSetup();
                        break;
                    }
                #endregion // �ݒ�{�^��

                default: break;
            }
        }

        #endregion // �c�[���o�[

        #region ���̕ϊ�(Leave�C�x���g)

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // ���̕ϊ�
            this._sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // �S�БΉ�����
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // �R�[�h�͋K��̑S�̃R�[�h�ցi�������ɂ͋K��̑S�̃R�[�h�̂Ƃ��󔒂ɂ���j
                this._sectionCode = CT_CODE_ALLSECCODE;
                sectionName = CT_NAME_ALLSECCODE;
                this.tEdit_SectionName.Text = sectionName;
                // 2008.12.10 add start [9003]
                this.tDateEdit_SalesDateSt.Focus();
                // 2008.12.10 add end [9003]
            }
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    this.tEdit_SectionName.Text = sectionName;
                }
                else
                {
                    this.tEdit_SectionName.Clear();
                    this.tEdit_SectionCodeAllowZero.Focus();
                }
            }
        }

        #endregion // ���̕ϊ�(Leave�C�x���g)

        #region �A���[�L�[�R���g���[��

        /// <summary>
        /// �A���[�L�[�R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // �t�B�[���h�Ԉړ�
                //---------------------------------------------------------------

                #region ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SectionGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_SalesDateSt;
                                    }
                                    break;
                                }
                            // 2008.12.01 del start [8489]
                            //case Keys.Down:
                            //    {
                            //        e.NextCtrl = this.;
                            //        break;
                            //    }
                            //case Keys.Up:
                            //    {
                            //        e.NextCtrl = this.tNedit_CustomerCode;
                            //        break;
                            //    }
                            // 2008.12.01 del end [8489]
                        }
                        break;
                    }
                #endregion // ���_�R�[�h

                #region ���_�K�C�h
                case "uButton_SectionGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            //case Keys.Up:
                            //case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_SalesDateSt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ���_�K�C�h

                #region ������i�J�n�j
                case "tDateEdit_SalesDateSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_SalesDateEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ������i�J�n�j

                #region ������i�I���j
                case "tDateEdit_SalesDateEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero; //2008.12.10 modify [9003]
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // ������i�I���j

                default: break;

            }
        }

        #endregion // �A���[�L�[�R���g���[��

        #region ��T�C�Y�̎�������

        /// <summary>
        /// ��T�C�Y�̎�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }

            // �S�Ă̗�ŃT�C�Y����
            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
        }

        #endregion // ��T�C�Y�̎�������

        #region �t�H���g�T�C�Y�̎�������

        /// <summary>
        /// �t�H���g�T�C�Y�̎�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this.uGrid_Details.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        #endregion // �t�H���g�T�C�Y�̎�������

        #region �����X�V�^�C�}�[

        /// <summary>
        /// �����X�V�^�C�}�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_AutoUpdate_Tick(object sender, EventArgs e)
        {
            this.Search();
        }

        #endregion // �����X�V�^�C�}�[

        #endregion // �R���g���[�����\�b�h

    }
}