//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/07/20  �C�����e : �e�L�X�g�o��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenyd
// �C �� ��  2010/08/17  �C�����e : ��QID:13038 �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �C �� ��  2010/09/15  �C�����e : ��Q�� #14643 �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhume
// �C �� ��  2010/09/21  �C�����e : ��Q�� #14876 �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/10/09  �C�����e : ��QID:15880�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O
// �C �� ��  2024/11/29  �C�����e : PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �S���ҕʎ��яƉ�e�L�X�g�o�͏����ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ�e�L�X�g�o�͐ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/08/17�A 2010/08/20 chenyd</br>
    /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2024/11/29 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
    public partial class PMHNB04161UC : Form
    {
        #region �v���C�x�[�g����

        /// <summary>�]�ƈ��}�X�^�A�N�Z�X�N���X</summary>
        /// <remarks></remarks>
        private EmployeeAcs _employeeAcs;

        //���t�擾���i
        private DateGetAcs _dateGet;

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;                  

        /// <summary>��ƃR�[�h</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>�e�L�X�g/�G�N�Z���敪</summary>
        private bool _excelFlg;

        /// <summary>�Q�Ƌ敪</summary>
        private int _referDiv = 0;

        /// <summary>���ԋ敪</summary>
        private int _duringDiv = 0;

        /// <summary>�J�n����</summary>
        private DateTime _duringSt = new DateTime();

        /// <summary>�I������</summary>
        private DateTime _duringEd = new DateTime();

        /// <summary>�J�n����(�N��)</summary>
        private int _duringYmSt = 0;

        /// <summary>�I������(�N��)</summary>
        private int _duringYmEd = 0;

        /// <summary>�o�̓t�@�C����</summary>
        private string _settingFileName = string.Empty;
        private string _settingFileNameSeller = string.Empty; // ADD 2010/10/09
        private string _settingFileNamePublisher = string.Empty; // ADD 2010/10/09

        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCodeSt = string.Empty;

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCodeEd = string.Empty;

        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _sectionCodeLogSt = string.Empty;
        /// <summary>�I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _sectionCodeLogEd = string.Empty;
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

        /// <summary>�J�n�S���҃R�[�h</summary>
        private string _employeeCodeSt = string.Empty;

        /// <summary>�I���S���҃R�[�h</summary>
        private string _employeeCodeEd = string.Empty;

        /// <summary>�J�n���_</summary>
        private string _prevInputSectionSt = null;

        /// <summary>�I�����_</summary>
        private string _prevInputSectionEd = null;

        /// <summary>�J�n�d����</summary>
        private string _prevInputSupplierSt = null;

        /// <summary>�I���d����</summary>
        private string _prevInputSupplierEd = null;

        /// <summary>���_�R�[�h���X�g</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>SelectionCode���X�g</summary>
        private List<string[]> _selectionCodeList = new List<string[]>();

        /// <summary>���_����</summary>
        private string _sectionName = string.Empty;

        /// <summary>SelectionName</summary>
        private string _selectionName = string.Empty;

        /// <summary>�t�H�[���N���X�t���O</summary>
        private bool _formcloseFlg = false;

        // --- ADD 2010/10/09 ---------->>>
        # region Delegate
        /// <summary>
        /// �f�[�^���o��
        /// </summary>
        /// <returns>�o�͌���</returns>
        internal delegate bool OutputDataEvent();
        #endregion

        # region Event
        /// <summary>�f�[�^���o�̓C�x���g</summary>
        internal event OutputDataEvent OutputData;
        #endregion
        // --- ADD 2010/10/09 ----------<<<

        /// <summary> ���� [�S����] </summary>
        private const string SALESINPUT_NAME = "�S����";
        /// <summary> ���� [�󒍎�] </summary>
        private const string FRONTEMPLOYEE_SECTION_NAME = "�󒍎�";
        /// <summary> ���� [���s��] </summary>
        private const string SALESEMPLOYEE_NAME = "���s��";

        //�G���[�������b�Z�[�W
        /// <summary> �K�{���̓`�F�b�N</summary>
        const string MESSAGE_NoInput = "����͂��Ă��������B";
        const string ct_InputError = "�̎w��Ɍ�肪����܂��B";
        const string ct_NoInput = "����͂��ĉ������B";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
        const string ct_RangeOverError = "�͒������P�����͈͓̔��œ��͂��ĉ������B";

        const string ct_RangeYearMonthOverError = "��12�����ȓ��œ��͂��ĉ������B";
        const string ct_NotOnYearError = "������N�x���ł͂���܂���B";
        const string ct_NotOnMonthError = "�����ꌎ���ł͂���܂���B";
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMHNB04161UC()
        {
            InitializeComponent();

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
        }
        #endregion

        #region �v���p�e�B

        /// <summary>
        /// �J�n���_�R�[�h
        /// </summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { this._sectionCodeSt = value; }
        }

        /// <summary>
        /// �I�����_�R�[�h
        /// </summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { this._sectionCodeEd = value; }
        }

        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string SectionCodeLogSt
        {
            get { return _sectionCodeLogSt; }
            set { _sectionCodeLogSt = value; }
        }

        /// <summary>�I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string SectionCodeLogEd
        {
            get { return _sectionCodeLogEd; }
            set { _sectionCodeLogEd = value; }
        }
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

        /// <summary>
        /// �Q�Ƌ敪
        /// </summary>
        public int ReferDiv
        {
            get { return this._referDiv; }
            set { this._referDiv = value; }
        }

        /// <summary>
        /// ���ԋ敪
        /// </summary>
        public int DuringDiv
        {
            get { return this._duringDiv; }
            set { this._duringDiv = value; }
        }

        /// <summary>
        /// �J�n����
        /// </summary>
        public DateTime DuringSt
        {
            get { return this._duringSt; }
            set { this._duringSt = value; }
        }

        /// <summary>
        /// �I������
        /// </summary>
        public DateTime DuringEd
        {
            get { return this._duringEd; }
            set { this._duringEd = value; }
        }

        /// <summary>
        /// �J�n����(�N��)
        /// </summary>
        public int DuringYmSt
        {
            get { return this._duringYmSt; }
            set { this._duringYmSt = value; }
        }

        /// <summary>
        /// �I������(�N��)
        /// </summary>
        public int DuringYmEd
        {
            get { return this._duringYmEd; }
            set { this._duringYmEd = value; }
        }

        /// <summary>
        /// �J�n�S���҃R�[�h
        /// </summary>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { this._employeeCodeSt = value; }
        }

        /// <summary>
        /// �I���S���҃R�[�h
        /// </summary>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { this._employeeCodeEd = value; }
        }

        /// <summary>
        /// �o�̓t�@�C����
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>
        /// �o�̓t�@�C�����i�󒍎ҁj
        /// </summary>
        public string SettingFileNameSeller
        {
            get { return _settingFileNameSeller; }
            set { this._settingFileNameSeller = value; }
        }

        /// <summary>
        /// �o�̓t�@�C�����i���s�ҁj
        /// </summary>
        public string SettingFileNamePublisher
        {
            get { return _settingFileNamePublisher; }
            set { this._settingFileNamePublisher = value; }
        }
        // ---ADD 2010/10/09 ---------------------<<<

        /// <summary>
        /// �t�H�[���I���X�e�[�^�X
        /// </summary>
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { this._dialogResult = value; }
        }

        /// <summary>
        /// �o�͌`��
        /// </summary>
        public bool ExcelFlg
        {
            get { return _excelFlg; }
            set { this._excelFlg = value; }
        }

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }

        /// <summary>
        /// SelectionCode���X�g
        /// </summary>
        public List<string[]> SelectionCodeList
        {
            get { return this._selectionCodeList; }
            set { this._selectionCodeList = value; }
        }

        /// <summary>
        /// �t�H�[���N���X�t���O
        /// </summary>
        public bool FormcloseFlg
        {
            get { return this._formcloseFlg; }
            set { this._formcloseFlg = value; }
        }
        #endregion

        #region �C�x���g
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g�ł��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMHNB04161UC_Load(object sender, EventArgs e)
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeSt.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.ImageList = this._imageList16;
            this.uButton_St_EmployeeCode.ImageList = this._imageList16;
            this.ultraButton_Ed_EmployeeCode.ImageList = this._imageList16;
            this.uButton_FileSelect.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_St_EmployeeCode.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_Ed_EmployeeCode.Appearance.Image = Size16_Index.STAR1;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1;

            // �J�n���_
            this.tNedit_SectionCodeSt.Text = this.SectionCodeSt;
            _prevInputSectionSt = this.SectionCodeSt; //  ADD 2010/08/17 ��QID:13038�Ή�
            // �I�����_
            this.tNedit_SectionCodeEd.Text = this.SectionCodeEd;
            _prevInputSectionEd = this.SectionCodeEd; //  ADD 2010/08/17 ��QID:13038�Ή�

            //�Q�Ƌ敪
            this.tComboEditor_Refer.Items.Clear();
            this.tComboEditor_Refer.Items.Add(1, SALESINPUT_NAME);
            this.tComboEditor_Refer.Items.Add(2, FRONTEMPLOYEE_SECTION_NAME);
            this.tComboEditor_Refer.Items.Add(3, SALESEMPLOYEE_NAME);
            this.tComboEditor_Refer.MaxDropDownItems = this.tComboEditor_Refer.Items.Count;

            //���ԋ敪
            this.tComboEditor_During.Items.Clear();
            this.tComboEditor_During.Items.Add(1, "���v");
            this.tComboEditor_During.Items.Add(2, "���v");
            this.tComboEditor_During.Items.Add(3, "����");
            this.tComboEditor_During.MaxDropDownItems = this.tComboEditor_During.Items.Count;


            // �Q�Ƌ敪�̏������̐ݒ�
            this.tComboEditor_Refer.SelectedIndex = this._referDiv;
            // ���ԋ敪�̏������̐ݒ�
            this.tComboEditor_During.SelectedIndex = this._duringDiv;
            // �J�n�S����
            this.tEdit_EmployeeCode_St.Text = this.EmployeeCodeSt;
            _prevInputSupplierSt = this.EmployeeCodeSt; //  ADD 2010/08/17 ��QID:13038�Ή�
            // �I���S����
            this.tEdit_EmployeeCode_Ed.Text = this.EmployeeCodeEd;
            _prevInputSupplierEd = this.EmployeeCodeEd; //  ADD 2010/08/17 ��QID:13038�Ή�
            // ���Ԃ̏������̐ݒ�
            this.tDateEdit_St_During.SetDateTime(this._duringSt);
            this.tDateEdit_Ed_During.SetDateTime(this._duringEd);
            this.tDateEdit_St_YearMonth.SetLongDate(this._duringYmSt);
            this.tDateEdit_Ed_YearMonth.SetLongDate(this._duringYmEd);
            this.ChangeFileName();
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
                this.DResult = DialogResult.OK;
                // --- UPD 2010/10/09 ---------->>>
                //FormcloseFlg = true;
                //this.Close();
                bool outputRslt = true;
                if (this.OutputData != null)
                {
                    outputRslt = this.OutputData();
                }
                if (outputRslt)
                {
                    FormcloseFlg = true;
                    this.Close();
                }
                // --- UPD 2010/10/09 ----------<<<
            }
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();   
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SectionCode_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((Control)sender).Name.EndsWith("St"))
                {
                    this.tNedit_SectionCodeSt.Text = sectionInfo.SectionCode.Trim();
                    this._sectionName = sectionInfo.SectionGuideNm;
                    _prevInputSectionSt = sectionInfo.SectionCode.Trim();
                }
                else
                {
                    this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                    _prevInputSectionEd = sectionInfo.SectionCode.Trim();
                }
            }
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // --- ADD 2010/09/09 ---------->>>>>
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excel�t�@�C��(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("�e�L�X�g�t�@�C��(*.CSV) | *.CSV");
            }
            // --- ADD 2010/09/09 ----------<<<<<
            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }


        /// <summary>
        /// �S����(�J�n)�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S����(�J�n)�K�C�h�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uButton_St_EmployeeCode_Click(object sender, EventArgs e)
        {
            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_St.Text = employee.EmployeeCode.Trim();
                _prevInputSupplierSt = employee.EmployeeCode.Trim();

                tEdit_EmployeeCode_Ed.Focus();
            }
        }

        /// <summary>
        /// �S����(�I��)�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S����(�I��)�K�C�h�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ultraButton_Ed_EmployeeCode_Click(object sender, EventArgs e)
        {

            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.Trim();
                _prevInputSupplierEd = employee.EmployeeCode.Trim();

                tComboEditor_During.Focus();
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�[�J�X���ύX���ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            string errMessage = string.Empty;
            switch (prevCtrl.Name)
            {
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, "st");
                        if (status)
                        {
                            this.tNedit_SectionCodeSt.Text = code;
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SectionCodeSt.Text.Trim() == "00")
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeEd;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�J�n���_�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_SectionCodeSt.Text = _prevInputSectionSt;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        
                        break;
                    }
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, "ed");
                        if (status)
                        {
                            this.tNedit_SectionCodeEd.Text = code;
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SectionCodeEd.Text.Trim() == "00")
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_EmployeeCode_St;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�I�����_�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_SectionCodeEd.Text = _prevInputSectionEd;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tEdit_EmployeeCode_St":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_St.DataText))
                        {
                            string code_St = tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                            string inputValue = this.tEdit_EmployeeCode_St.Text.Trim();
                            string code;
                            string name;
                            bool status = ReadEmployee(code_St, out code, out name);
                            if (!status)
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�S����(�J�n) [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_EmployeeCode_St.Text = _prevInputSupplierSt;
                                this.tEdit_EmployeeCode_St.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                                break; // ADD 2010/09/26
                            }
                            else
                            {
                                _prevInputSupplierSt = code;
                            }
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_EmployeeCode_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_St_EmployeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_Ed.DataText))
                        {
                            string code_Ed = tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                            string inputValue = this.tEdit_EmployeeCode_Ed.Text.Trim();
                            string code;
                            string name;
                            bool status = ReadEmployee(code_Ed, out code, out name);
                            if (!status)
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�S����(�I��) [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_EmployeeCode_Ed.Text = _prevInputSupplierEd;
                                this.tEdit_EmployeeCode_Ed.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                                break; // ADD 2010/09/26
                            }
                            else
                            {
                                _prevInputSupplierEd = code;
                            }
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.ultraButton_Ed_EmployeeCode;
                                            }
                                            else
                                            {
                                                int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                                                if (2 == duringFlg)
                                                    e.NextCtrl = this.tDateEdit_St_YearMonth;
                                                else if (1 == duringFlg)
                                                    e.NextCtrl = this.tDateEdit_St_During;
                                                else
                                                    e.NextCtrl = this.tEdit_SettingFileName;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }

                case "tEdit_SettingFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = ultraButton_OK;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ��ʂ̃N���A
        /// </summary>
        /// <br>Note       : ��ʂ̃N���A�����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void Clear()
        {
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();

            this.tEdit_EmployeeCode_St.Clear();
            this.tEdit_EmployeeCode_Ed.Clear();

            this._sectionName = string.Empty;
            this._selectionName = string.Empty;
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N
        /// </summary>
        /// <br>Note       : ��ʓ��̓`�F�b�N�ł��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             �E��Q�� #14643 �e�L�X�g�o�͑Ή�</br>
        private bool InputCheck()
        {
            string errMessage = null;
            // ���_
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                this._sectionCodeSt = "00";
                _prevInputSectionSt = "00";
            }
            // --- ADD 2010/09/21 ---------->>>>>
            else
            {
                this._sectionCodeSt = this.tNedit_SectionCodeSt.Text;
                _prevInputSectionSt = this.tNedit_SectionCodeSt.Text;
            }
            // --- ADD 2010/09/21 ----------<<<<<
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                this._sectionCodeEd = "00";
                _prevInputSectionEd = "00";
            }
            // --- ADD 2010/09/21 ---------->>>>>
            else
            {
                this._sectionCodeEd = this.tNedit_SectionCodeEd.Text;
                _prevInputSectionEd = this.tNedit_SectionCodeEd.Text;
            }
            // --- ADD 2010/09/21 ----------<<<<<

            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputSectionSt) > Convert.ToInt32(_prevInputSectionEd))
            if (Convert.ToInt32(_prevInputSectionEd) != 0 && (Convert.ToInt32(_prevInputSectionSt) > Convert.ToInt32(_prevInputSectionEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n���_�R�[�h�̒l���I�����_�R�[�h�̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                this.tNedit_SectionCodeSt.Focus();
                return false;
            }

            //�S���҃R�[�h�i�J�n�j���@�S���҃R�[�h�i�I���j�̃`�F�b�N
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierSt))
            if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                _prevInputSupplierSt = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierEd))
            if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                _prevInputSupplierEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd))
            if (Convert.ToInt32(_prevInputSupplierEd) != 0 && (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                errMessage = "�S���Ҕ͈͂̎w��Ɍ�肪����܂��B";
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            errMessage,
                            0,
                            MessageBoxButtons.OK);
                tEdit_EmployeeCode_St.Focus();
                return false;
            }

            # region �K�{���̓`�F�b�N
            //���ԋ敪
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            //���t
            DateGetAcs.CheckDateRangeResult cdrResult;
            PMHNB04161UA checkForm = new PMHNB04161UA();

            if (duringFlg == 1)
            {
                // ���ԁi�J�n�`�I���j
                if (checkForm.CallCheckDateForYearMonthDayRange(out cdrResult, ref tDateEdit_St_During, ref tDateEdit_Ed_During) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("����(�J�n){0}", MESSAGE_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("����(�J�n){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("����{0}", ct_RangeError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                            {
                                errMessage = string.Format("�J�n�E�I�����t{0}", ct_NotOnMonthError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("����{0}", ct_RangeOverError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                    }
                }
            }
            else if (duringFlg == 2)
            {
                // ���ԁi�J�n�`�I���j
                if (checkForm.CallCheckDateForYearMonthRange(out cdrResult, ref tDateEdit_St_YearMonth, ref tDateEdit_Ed_YearMonth) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("����(�J�n){0}", ct_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("����(�J�n){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("����(�I��){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("����{0}", ct_RangeError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("����{0}", ct_RangeYearMonthOverError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                            {
                                errMessage = string.Format("�J�n�E�I���N��{0}", ct_NotOnYearError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                    }
                }
            }
            # endregion �K�{���̓`�F�b�N

            // �o�̓t�@�C����
            if (string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�o�̓t�@�C������ݒ肵�Ă��������B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="code">�Ԃ�l</param>
        /// <param name="inputValue">���͒l</param>
        /// <param name="startEnd">�J�n�I���敪</param>
        /// <returns>bool</returns>
        /// <br>Note       : ���_���̎擾�����ł��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private bool ReadSectionCodeAllowZero(out string code, string inputValue, string startEnd)
        {
            // ���͒l���擾
            string sectionCode = inputValue.Trim().PadLeft(2, '0');
            code = sectionCode;

            if ("st".Equals(startEnd))
            {
                if (_prevInputSectionSt == sectionCode)
                {
                    this.tNedit_SectionCodeSt.Text = sectionCode;
                    return true;
                }
            }
            else
            {
                if (_prevInputSectionEd == sectionCode)
                {
                    this.tNedit_SectionCodeEd.Text = sectionCode;
                    return true;
                }

            }

            // 00:�S��
            if (sectionCode == "00")
            {
                sectionCode = "00";
                if ("st".Equals(startEnd))
                    _prevInputSectionSt = sectionCode;
                else
                    _prevInputSectionEd = sectionCode;
                code = sectionCode;
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // ���_�����擾
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    code = sectionInfo.SectionCode.Trim();
                    if ("st".Equals(startEnd))
                        _prevInputSectionSt = code;
                    else
                        _prevInputSectionEd = code;
                    this._sectionName = sectionInfo.SectionGuideNm;
                    return true;
                }
                else
                {
                    code = string.Empty;
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                return true;
            }
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            //PMHNB04161UD userSettingFrm = new PMHNB04161UD(); // DEL 2010/10/09
            PMHNB04161UD userSettingFrm = new PMHNB04161UD(this.ReferDiv); // ADD 2010/10/09
            userSettingFrm.AnalysisTextSettingAcs.Deserialize();

            // --- UPD 2010/10/09 ---------->>>
            //fileName = userSettingFrm.AnalysisTextSettingAcs.SalesEmployeeFileNameValue;
            //�Q�Ƌ敪flg
            int duringFlg = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);

            if (duringFlg == 1)
            {
                fileName = userSettingFrm.AnalysisTextSettingAcs.SalesEmployeeFileNameValue;
            }
            else if (duringFlg == 2)
            {
                fileName = userSettingFrm.AnalysisTextSettingAcs.SalesSellerFileNameValue;
            }
            else
            {
                fileName = userSettingFrm.AnalysisTextSettingAcs.SalesPublisherFileNameValue;
            }
            // --- UPD 2010/10/09 ----------<<<
            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (this._excelFlg)
                {
                    // �g���q��XLS�ɂ���
                    fileName += ".xls";
                }
                else
                {
                    // �g���q��CSV�ɂ���
                    fileName += ".csv";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }

        /// <summary>
        /// ���o�����Z�b�g
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private void SetExtratConst()
        {
            // �Ώۋ��_�R�[�h
            List<string[]> sectionCodeList = new List<string[]>();
            // SelectionCode���X�g
            List<string[]> selectionCodeList = new List<string[]>();

            // ���_�̎擾
            // ---------------------- UPD 2010/09/19 ---------------------------------------->>>>>
            //if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt())
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt() ||
                this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
            // ---------------------- UPD 2010/09/19 ----------------------------------------<<<<<
            {
                // ---------------------- UPD 2010/09/19 ---------------------------------------->>>>>
                //if (this.tNedit_SectionCodeSt.GetInt() == 0)
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                // ---------------------- UPD 2010/09/19 ----------------------------------------<<<<<
                {
                    // �S�Ўw��
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    ArrayList relList = new ArrayList();
                    int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in relList)
                        {
                            // --------------------------- UPD 2010/09/19 -------------------------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() != 0)
                            {
                                //if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode)) // DEL 2010/09/21
                                if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode) && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() != 0 && this.tNedit_SectionCodeEd.GetInt() == 0)
                            {
                                //if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode)) // DEL 2010/09/21
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode) && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            //else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0) // DEL 2010/09/21
                            else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0 && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                            {
                                string[] sectionArr = new string[2];
                                sectionArr[0] = sectionInfo.SectionCode;
                                //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                sectionCodeList.Add(sectionArr);
                            }
                            //string[] sectionArr = new string[2];
                            //sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm;
                            //sectionCodeList.Add(sectionArr);
                            // --------------------------- UPD 2010/09/19 --------------------------------------<<<<<
                        }
                    }
                }
                else
                {
                    string[] sectionArr = new string[2];
                    sectionArr[0] = this.tNedit_SectionCodeSt.Text;
                    if (!string.IsNullOrEmpty(this._sectionName)) //ADD 2010/08/20 ��QID:13038�Ή�
                    {
                        sectionArr[1] = this._sectionName;
                    // --- ADD 2010/08/20 ��QID:13038�Ή�-------------------------------->>>>>
                    }
                    else
                    {
                        // ���_�����擾
                        SecInfoSet sectionInfo;
                        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tNedit_SectionCodeSt.Text);
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                        {
                            //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                            sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09

                        }
                    }
                    // --- ADD 2010/08/20 ��QID:13038�Ή�--------------------------------<<<<<
                    sectionCodeList.Add(sectionArr);
                }
            }
            else
            {
                string code;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = 0;

                for (int i = this.tNedit_SectionCodeSt.GetInt(); i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                {
                    code = i.ToString();
                    code = code.Trim().PadLeft(2, '0');
                    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                    {
                        string[] sectionArr = new string[2];
                        sectionArr[0] = code;
                        //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                        sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                        sectionCodeList.Add(sectionArr);
                    }
                }
            }
            this._sectionCodeList = sectionCodeList;

            // �Q�Ƌ敪
            this._referDiv = Convert.ToInt16(this.tComboEditor_Refer.Value);
            // ���ԋ敪
            this._duringDiv = Convert.ToInt16(this.tComboEditor_During.Value);
            // �Ώ۔N�x
            this._duringSt = this.tDateEdit_St_During.GetDateTime();
            this._duringEd = this.tDateEdit_Ed_During.GetDateTime();
            // �Ώ۔N�x(�N��)
            this._duringYmSt = this.tDateEdit_St_YearMonth.GetLongDate();
            this._duringYmEd = this.tDateEdit_Ed_YearMonth.GetLongDate();
            // �S����
            this._employeeCodeSt = this.tEdit_EmployeeCode_St.Text;
            this._employeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;

            // �o�̓t�@�C����
            // ---UPD 2010/10/09 --------------------->>>
            //this._settingFileName = this.tEdit_SettingFileName.Text;
            // �Q�Ƌ敪�͎󒍎҂̏ꍇ
            if (this._referDiv == 2)
            {
                this._settingFileNameSeller = this.tEdit_SettingFileName.Text;
            }
            // �Q�Ƌ敪�͔��s�҂̏ꍇ
            else if (this._referDiv == 3)
            {
                this._settingFileNamePublisher = this.tEdit_SettingFileName.Text;
            }
            // ���̂ق��̏ꍇ
            else
            {
                this._settingFileName = this.tEdit_SettingFileName.Text;
            }
            // ---UPD 2010/10/09 ---------------------<<<
            //this._sectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/08/20 // DEL 2010/09/21

            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v
            SectionCodeLogSt = this.tNedit_SectionCodeSt.Text.Trim();
            // �I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v
            SectionCodeLogEd = this.tNedit_SectionCodeEd.Text.Trim();
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        }
        #endregion


        #region �l�ύX�㔭���C�x���g
        /// <summary>
        /// �Q�Ƌ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Q�Ƌ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tComboEditor_Refer_ValueChanged(object sender, EventArgs e)
        {
            //�Q�Ƌ敪flg
            int duringFlg = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);

            if (duringFlg == 1)
            {
                uLabel_EmployeeCode.Text = SALESINPUT_NAME;
            }
            else if (duringFlg == 2)
            {
                uLabel_EmployeeCode.Text = FRONTEMPLOYEE_SECTION_NAME;
            }
            else
            {
                uLabel_EmployeeCode.Text = SALESEMPLOYEE_NAME;
            }

            // ---ADD 2010/10/09 --------------------->>>
            this.ReferDiv = duringFlg;
            this.ChangeFileName();
            // ---ADD 2010/10/09 ---------------------<<<

        }

        /// <summary>
        /// ���ԋ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���ԋ敪�R���{�{�b�N�X�l�ύX�㔭���C�x���g���s���B </br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tComboEditor_During_ValueChanged(object sender, EventArgs e)
        {
            //���ԋ敪flg
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
            if (duringFlg == 1)
            {
                uLabel_During_From_To.Visible = true;

                //����(�J�n)YYYYMMDD
                tDateEdit_St_During.Visible = true;

                //����(�I��)YYYYMMDD
                tDateEdit_Ed_During.Visible = true;


                //����(�J�n)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //����(�I��)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = true;

                // �����
                DateTime staratDate;
                DateTime endDate;
                this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

                if (tDateEdit_St_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //����(�J�n)YYYYMMDD
                    this.tDateEdit_St_During.Visible = true;
                    this.tDateEdit_St_During.Clear();
                    this.tDateEdit_St_During.SetDateTime(staratDate);
                }

                if (tDateEdit_Ed_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //����(�I��)YYYYMMDD
                    this.tDateEdit_Ed_During.Visible = true;
                    this.tDateEdit_Ed_During.Clear();
                    this.tDateEdit_Ed_During.SetDateTime(endDate);
                }

            }
            else if (duringFlg == 2)
            {
                uLabel_During_From_To.Visible = true;

                //����(�J�n)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //����(�I��)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //����(�J�n)YYYYMM
                tDateEdit_St_YearMonth.Visible = true;

                //����(�I��)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = true;

                uLabel_To_OutputDay.Visible = true;


                // ������ݒ�
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate);

                if (tDateEdit_St_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_St_YearMonth.SetDateTime(startMonthDate);
                }

                if (tDateEdit_Ed_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_Ed_YearMonth.SetDateTime(endMonthDate);
                }
            }
            else
            {

                uLabel_During_From_To.Visible = false;

                //����(�J�n)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //����(�I��)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //����(�J�n)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //����(�I��)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = false;

                //������ݒ�
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                DateTime startYearDate;
                DateTime endYearDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);

                this.tDateEdit_St_YearMonth.SetDateTime(startYearDate);
                this.tDateEdit_Ed_YearMonth.SetDateTime(endYearDate);

            }

        }
        #endregion

        /// <summary>
        /// �]�ƈ�Read
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="code">�]�ƈ��R�[�h</param>
        /// <param name="name">�]�ƈ�����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ�Read���s���B </br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private bool ReadEmployee(string employeeCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (employeeCode != string.Empty)
            {
                // �ǂݍ���
                if (_employeeAcs == null)
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

                //if (status == 0 && employee != null) // DEL 2010/09/21
                if (status == 0 && employee != null && employee.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    // �Y�����聨�\��
                    code = employee.EmployeeCode.TrimEnd();
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// �t�H�[���N���[�X�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�[���N���[�X���ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMHNB04161UC_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_formcloseFlg)
                this._dialogResult = DialogResult.Cancel;

        }
    }
}