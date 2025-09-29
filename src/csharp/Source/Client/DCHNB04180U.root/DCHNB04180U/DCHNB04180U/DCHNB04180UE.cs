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
    /// ����N�Ԏ��яƉ�e�L�X�g�o�͏����ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����N�Ԏ��яƉ�e�L�X�g�o�͐ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : ����p</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/08/12 chenyd</br>
    /// <br>            �E��QID:13021 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/25 chenyd</br>
    /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/09/09 �k���r</br>
    /// <br>            �E��QID:13278 PM1010F�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2024/11/29 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
    public partial class DCHNB04180UE : Form
    {
        #region �v���C�x�[�g����

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;                  

        /// <summary>��ƃR�[�h</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>�W�v�敪</summary>
        private bool _excelFlg;

        /// <summary>�W�v�敪</summary>
        private int _totalDiv = 0;

        /// <summary>�Ώ۔N�x</summary>
        private int _financialYear = 0;

        /// <summary>�o�̓t�@�C����</summary>
        private string _settingFileName = string.Empty;

        /// <summary>���_�R�[�h���X�g</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>SelectionCode���X�g</summary>
        private List<string[]> _selectionCodeList = new List<string[]>();

        /// <summary>���_����</summary>
        private string _sectionName = string.Empty;

        /// <summary>SelectionName</summary>
        private string _selectionName = string.Empty;
        /// <summary>��v�N�x</summary>
        private int _financialYearsd;
        /// <summary>�O��l�ێ�</summary>
        PrevInputValue _prevInputValue = new PrevInputValue();
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _sectionCodeSt = string.Empty;
        /// <summary>�I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _sectionCodeEd = string.Empty;
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        // --- ADD 2010/08/25 -------------------------------->>>>>
        /// <summary>stSelectionName</summary>
        private string _st_selectionCode = string.Empty;

        /// <summary>edSelectionName</summary>
        private string _ed_selectionCode = string.Empty;

        // --- ADD 2010/10/09 ---------->>>>>
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
        // --- ADD 2010/10/09 ----------<<<<<

        /// <summary>_searDiv</summary>
        private int _searDiv;
        // --- ADD 2010/08/25 --------------------------------<<<<<
        private const string TOTALDIV_ALL = "�S��";
        private const string TOTALDIV_SECT = "���_";
        private const string TOTALDIV_CUST = "���Ӑ�";
        private const string TOTALDIV_SEMP = "�S����";
        private const string TOTALDIV_FEMP = "�󒍎�";
        private const string TOTALDIV_INPU = "���s��";
        private const string TOTALDIV_AREA = "�n��";
        private const string TOTALDIV_TYPE = "�Ǝ�";

        private const int SELECT_CUST = 77;
        private const int SELECT_EMP = 44;
        private const int SELECT_AREA = 44;
        private const int SELECT_TYPE = 44;
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public DCHNB04180UE()
        {
            InitializeComponent();
        }
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// �W�v�敪
        /// </summary>
        public int TotalDiv
        {
            get { return this._totalDiv; }
            set { this._totalDiv = value; }
        }

        /// <summary>
        /// �Ώ۔N��
        /// </summary>
        public int FinancialYear
        {
            get { return this._financialYear; }
            set { this._financialYear = value; }
        }
        /// <summary>
        /// �o�̓t�@�C����
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

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
        // --- ADD 2010/08/25 -------------------------------->>>>>
        /// <summary>
        /// �����敪
        /// </summary>
        public int SearDiv
        {
            get { return this._searDiv; }
            set { this._searDiv = value; }
        }

        /// <summary>
        /// St_SelectionCode
        /// </summary>
        public string St_SelectionCode
        {
            get { return _st_selectionCode; }
            set { this._st_selectionCode = value; }
        }
        /// <summary>
        /// Ed_SelectionCode
        /// </summary>
        public string Ed_SelectionCode
        {
            get { return _ed_selectionCode; }
            set { this._ed_selectionCode = value; }
        }
        // --- ADD 2010/08/25 --------------------------------<<<<<
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// <summary>�I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        #endregion

        #region �C�x���g
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g�ł��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void DCHNB04180UE_Load(object sender, EventArgs e)
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeSt.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.ImageList = this._imageList16;
            this.uButton_SelectionCodeSt.ImageList = this._imageList16;
            this.uButton_SelectionCodeEd.ImageList = this._imageList16;
            this.uButton_FileSelect.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1;

            // �R���{�{�b�N�X�ɏ��Z�b�g
            this.tComboEditor_TotalDiv1.Items.Clear();
            this.tComboEditor_TotalDiv1.Items.Add(0, TOTALDIV_SECT);
            this.tComboEditor_TotalDiv1.Items.Add(1, TOTALDIV_CUST);
            this.tComboEditor_TotalDiv1.Items.Add(2, TOTALDIV_SEMP);
            this.tComboEditor_TotalDiv1.Items.Add(3, TOTALDIV_FEMP);
            this.tComboEditor_TotalDiv1.Items.Add(4, TOTALDIV_INPU);
            this.tComboEditor_TotalDiv1.Items.Add(5, TOTALDIV_AREA);
            this.tComboEditor_TotalDiv1.Items.Add(6, TOTALDIV_TYPE);
            this.tComboEditor_TotalDiv1.MaxDropDownItems = this.tComboEditor_TotalDiv1.Items.Count;

            // �W�v�敪�̏������̐ݒ�
            this.tComboEditor_TotalDiv1.SelectedIndex = this._totalDiv;
            // �Ώ۔N���̏������̐ݒ�
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);
            int _companyBiginMonthsd = 0;
            SelesAnnualDataAcs _SelesAnnualDataAcs = new SelesAnnualDataAcs();
            // ��v�N�x�擾
            _SelesAnnualDataAcs.GetCompanyInf(this._enterpriseCode, out _financialYearsd, out _companyBiginMonthsd);
            
            // �o�̓t�@�C�����̏������̐ݒ�
            this.ChangeFileName();
        }

        /// <summary>
        /// �I�����ύX���ꂽ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �I�����ύX���ꂽ�ꍇ�ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void tComboEditor_TotalDiv_SelectionChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Height = this.tNedit_SectionCodeSt.Size.Height;
            int totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;
            switch (totalDiv)
            {
                case 0: // ���_
                    {
                        this.tNedit_SelectionCode_St.Visible = false;
                        this.tNedit_SelectionCode_Ed.Visible = false;
                        this.uLabel_SelectionCode.Visible = false;
                        this.ultraLabel11.Visible = false;
                        this.uButton_SelectionCodeSt.Visible = false;
                        this.uButton_SelectionCodeEd.Visible = false;
                        break;
                    }
                case 1: // ���Ӑ�
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        this.uLabel_SelectionCode.Text = TOTALDIV_CUST;
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 8;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 8;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = false;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = false;
                        break;
                    }
                case 2: // �S����
                case 3: // �󒍎�
                case 4: // ���s��
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        if (totalDiv == 2) { this.uLabel_SelectionCode.Text = TOTALDIV_SEMP; }
                        else if (totalDiv == 3) { this.uLabel_SelectionCode.Text = TOTALDIV_FEMP; }
                        else if (totalDiv == 4) { this.uLabel_SelectionCode.Text = TOTALDIV_INPU; }
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 4;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 4;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = false;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = false;
                        break;
                    }
                case 5: // �n��
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        this.uLabel_SelectionCode.Text = TOTALDIV_AREA;
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 4;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 4;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = true;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = true;
                        break;
                    }
                case 6: // �Ǝ�
                    {
                        this.uLabel_SelectionCode.Visible = true;
                        this.uLabel_SelectionCode.Text = TOTALDIV_TYPE;
                        this.tNedit_SelectionCode_St.Visible = true;
                        this.tNedit_SelectionCode_St.ExtEdit.Column = 4;
                        this.tNedit_SelectionCode_Ed.Visible = true;
                        this.tNedit_SelectionCode_Ed.ExtEdit.Column = 4;
                        this.ultraLabel11.Visible = true;
                        this.uButton_SelectionCodeSt.Visible = true;
                        this.uButton_SelectionCodeEd.Visible = true;

                        this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = true;
                        this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = true;
                        break;
                    }
            }
            // �o�̓t�@�C�����̐ݒ�
            this.ChangeFileName();
            this.Clear();
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
                this.DResult = DialogResult.OK;
                // --- UPD 2010/10/09 ---------->>>>>
                //this.Close();
                bool outputRslt = true;
                if (this.OutputData != null)
                {
                    outputRslt = this.OutputData();
                }
                if (outputRslt)
                {
                    this.Close();
                }
                // --- UPD 2010/10/09 ----------<<<<<
            }
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
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
        /// <br>Programmer : ����p</br>
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
                    this._prevInputValue.SectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/09/15
                }
                else
                {
                    this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                    this._prevInputValue.SectionCodeEd = this.tNedit_SectionCodeEd.Text; // ADD 2010/09/15
                }
            }
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SelectionCode_Click(object sender, EventArgs e)
        {
            int totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;

            if (totalDiv == 1)
            {

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                if (((Control)sender).Name.EndsWith("St"))
                {
                    customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerStSelect);
                }
                else
                {
                    customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerEdSelect);
                }
                customerSearchForm.ShowDialog(this);
            }
            else if ((totalDiv == 2) || (totalDiv == 3) || (totalDiv == 4))
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                Employee employee;
                int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (((Control)sender).Name.EndsWith("St"))
                    {
                        this.tNedit_SelectionCode_St.Text = employee.EmployeeCode.Trim();
                        this._selectionName = employee.Name;
                        this._prevInputValue.SelectionCodeSt = this.tNedit_SelectionCode_St.Text; // ADD 2010/09/15
                    }
                    else
                    {
                        this.tNedit_SelectionCode_Ed.Text = employee.EmployeeCode.Trim();
                        this._prevInputValue.SelectionCodeEd = this.tNedit_SelectionCode_Ed.Text; // ADD 2010/09/15
                    }
                }
            }
            else if ((totalDiv == 5) || (totalDiv == 6))
            {
                int userGuideDivCd;

                if (totalDiv == 5)
                {
                    userGuideDivCd = 21; // �n��i�̔��G���A�j
                } 
                else
                {
                    userGuideDivCd = 33; // �Ǝ�
                }

                UserGuideAcs _userGuideAcs = new UserGuideAcs();
                UserGdHd userGdHd = new UserGdHd();
                UserGdBd userGdBd = new UserGdBd();
                int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (((Control)sender).Name.EndsWith("St"))
                    {
                        this.tNedit_SelectionCode_St.SetInt(userGdBd.GuideCode);
                        this._selectionName = userGdBd.GuideName;
                        this._prevInputValue.SelectionCodeSt = this.tNedit_SelectionCode_St.DataText; // ADD 2010/09/15
                    }
                    else
                    {
                        this.tNedit_SelectionCode_Ed.SetInt(userGdBd.GuideCode);
                        this._prevInputValue.SelectionCodeEd = this.tNedit_SelectionCode_Ed.DataText; // ADD 2010/09/15
                    }
                }
            }
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excel�t�@�C��(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("�e�L�X�g�t�@�C��(*.CSV) | *.CSV");
            }
            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <br>Note       : ���Ӑ悪�I�����ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void CustomerSearchForm_CustomerStSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            this.tNedit_SelectionCode_St.SetInt(customerInfo.CustomerCode);
            this._selectionName = customerInfo.Name;
            this._prevInputValue.SelectionCodeSt = this.tNedit_SelectionCode_St.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <br>Note       : ���Ӑ悪�I�����ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void CustomerSearchForm_CustomerEdSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            this.tNedit_SelectionCode_Ed.SetInt(customerInfo.CustomerCode);
            this._selectionName = customerInfo.Name;
            this._prevInputValue.SelectionCodeEd = this.tNedit_SelectionCode_Ed.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�[�J�X���ύX���ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            �E��QID:13021 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2010/09/20 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            string errMessage = string.Empty;
            int totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;
            switch (prevCtrl.Name)
            {
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, true);
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
                            // �R�[�h�߂�
                            this.tNedit_SectionCodeSt.Text = code;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, false);
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
                                                if (this.tNedit_SelectionCode_St.Visible == true)
                                                {
                                                    e.NextCtrl = this.tNedit_SelectionCode_St;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tDateEdit_FinancialYear;
                                                }
                                                
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
                            // �R�[�h�߂�
                            this.tNedit_SectionCodeEd.Text = code;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SelectionCode_St":
                    {
                        // ---------- UPD 2010/09/20 ------------------------------>>>>>
                        //int inputValue = this.tNedit_SelectionCode_Ed.GetInt();
                        string inputValueStr = this.tNedit_SelectionCode_St.DataText;
                        // ---------- UPD 2010/09/20 ------------------------------<<<<<
                        int code;
                        // ---------- UPD 2010/09/21 ------------------------------>>>>>
                        //if (inputValue != 0)
                        if (!string.IsNullOrEmpty(inputValueStr))
                        // ---------- UPD 2010/09/21 ------------------------------<<<<<
                        {
                            int inputValue = Convert.ToInt32(inputValueStr); // ADD 2010/09/21
                            if (totalDiv == 1)
                            {
                                // ���Ӑ�
                                // ---------- UPD 2010/09/21 ------------------------------>>>>>
                                string customerCode = string.Empty;
                                //bool status = ReadCustomerName(out code, inputValue, true, totalDiv);
                                bool status = ReadCustomerName(out customerCode, inputValue, true, totalDiv);
                                // ---------- UPD 2010/09/21 ------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_St.SetInt(code); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = customerCode; //ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeSt;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_SelectionCode_Ed;
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
                                        "�J�n���Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    //this.tNedit_SelectionCode_St.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = customerCode; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                            else if ((totalDiv == 5) || (totalDiv == 6))
                            {
                                int userGuideDivCd = 0;
                                if (totalDiv == 5)
                                {
                                    // �n��i�̔��G���A�j
                                    userGuideDivCd = 21;
                                    errMessage = "�J�n�n��R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";
                                }
                                else
                                {
                                    // �Ǝ�
                                    userGuideDivCd = 33;
                                    errMessage = "�J�n�Ǝ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";
                                }
                                // --------- UPD 2010/09/21 ------------------------------------------------->>>>>
                                string codeStr = string.Empty;
                                //bool status = ReadSelectionName(out code, inputValue, true, userGuideDivCd);
                                bool status = ReadSelectionName(out codeStr, inputValue, true, userGuideDivCd);
                                // --------- UPD 2010/09/21 -------------------------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_St.SetInt(code); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = codeStr; // ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeSt;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_SelectionCode_Ed;
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
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    //this.tNedit_SelectionCode_St.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_St.Text = codeStr; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            else
                            {
                                string employeeInputValue = this.tNedit_SelectionCode_St.Text.Trim().PadLeft(4, '0');// ADD 2010/08/12 ��QID:13021�Ή�
                                string employeeCode;// ADD 2010/08/12 ��QID:13021�Ή�

                                // �S���ҁE�󒍎ҁE���s��
                                //bool status = ReadCustomerName(out code, inputValue, true, totalDiv);// DEL 2010/08/12 ��QID:13021�Ή�
                                bool status = ReadEmployee(out employeeCode, employeeInputValue, true);// ADD 2010/08/12 ��QID:13021�Ή�
                                if (!status)
                                {
                                    if (totalDiv == 2)
                                    {
                                        errMessage = "�J�n�S���҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";
                                    }
                                    else if (totalDiv == 3)
                                    {
                                        errMessage = "�J�n�󒍎҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";
                                    }
                                    else if (totalDiv == 4)
                                    {
                                        errMessage = "�J�n���s�҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";
                                    }
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    //this.tNedit_SelectionCode_St.Text = code.ToString();// DEL 2010/08/12 ��QID:13021�Ή�
                                    this.tNedit_SelectionCode_St.Text = employeeCode;// ADD 2010/08/12 ��QID:13021�Ή�
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    //this.tNedit_SelectionCode_St.SetInt(code);// DEL 2010/08/12 ��QID:13021�Ή�
                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeSt;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_SelectionCode_Ed;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SelectionCode_Ed":
                    {
                        // ---------- UPD 2010/09/20 ------------------------------>>>>>
                        //int inputValue = this.tNedit_SelectionCode_Ed.GetInt();
                        string inputValueStr = this.tNedit_SelectionCode_Ed.DataText;
                        // ---------- UPD 2010/09/20 ------------------------------<<<<<
                        int code;
                        // ---------- UPD 2010/09/21 ------------------------------>>>>>
                        //if (inputValue != 0)
                        if (!string.IsNullOrEmpty(inputValueStr))
                        // ---------- UPD 2010/09/21 ------------------------------<<<<<
                        {
                            int inputValue = Convert.ToInt32(inputValueStr); // ADD 2010/09/21
                            if (totalDiv == 1)
                            {
                                // ---------- UPD 2010/09/21 ------------------------------>>>>>
                                string customerCode = string.Empty;
                                //bool status = ReadCustomerName(out code, inputValue, false, totalDiv);
                                bool status = ReadCustomerName(out customerCode, inputValue, false, totalDiv);
                                // ---------- UPD 2010/09/21 ------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_Ed.SetInt(code); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = customerCode; // ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeEd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tDateEdit_FinancialYear;
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
                                        //"�J�n���Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B", // DEL 2010/08/12 ��QID:13021�Ή�
                                        "�I�����Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",   // ADD 2010/08/12 ��QID:13021�Ή�
                                        -1,
                                        MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    //this.tNedit_SelectionCode_Ed.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = customerCode; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                            else if ((totalDiv == 5) || (totalDiv == 6))
                            {
                                int userGuideDivCd = 0;
                                if (totalDiv == 5)
                                {
                                    // �n��i�̔��G���A�j
                                    userGuideDivCd = 21;
                                    //errMessage = "�J�n�n��R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// DEL 2010/08/12 ��QID:13021�Ή�
                                    errMessage = "�I���n��R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// ADD 2010/08/12 ��QID:13021�Ή�
                                }
                                else
                                {
                                    // �Ǝ�
                                    userGuideDivCd = 33;
                                    //errMessage = "�J�n�Ǝ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// DEL 2010/08/12 ��QID:13021�Ή�
                                    errMessage = "�I���Ǝ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// ADD 2010/08/12 ��QID:13021�Ή�
                                }
                                // --------- UPD 2010/09/21 ---------------------------------------------------->>>>>
                                string codeStr = string.Empty;
                                //bool status = ReadSelectionName(out code, inputValue, false, userGuideDivCd);
                                bool status = ReadSelectionName(out codeStr, inputValue, false, userGuideDivCd);
                                // --------- UPD 2010/09/21 ----------------------------------------------------<<<<<
                                if (status)
                                {
                                    //this.tNedit_SelectionCode_Ed.SetInt(code);  // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = codeStr; // ADD 2010/09/21

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeEd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tDateEdit_FinancialYear;
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
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    // �R�[�h�߂�
                                    //this.tNedit_SelectionCode_Ed.Text = code.ToString(); // DEL 2010/09/21
                                    this.tNedit_SelectionCode_Ed.Text = codeStr; // ADD 2010/09/21
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            else
                            {
                                string employeeInputValue = this.tNedit_SelectionCode_Ed.Text.Trim().PadLeft(4, '0');// ADD 2010/08/12 ��QID:13021�Ή�
                                string employeeCode;// ADD 2010/08/12 ��QID:13021�Ή�
                                
                                // �S���ҁE�󒍎ҁE���s��
                                //bool status = ReadCustomerName(out code, inputValue, false, totalDiv);// DEL 2010/08/12 ��QID:13021�Ή�
                                bool status = ReadEmployee(out employeeCode, employeeInputValue, false);// ADD 2010/08/12 ��QID:13021�Ή�
                                if (!status)
                                {
                                    if (totalDiv == 2)
                                    {
                                        //errMessage = "�J�n�S���҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// DEL 2010/08/12 ��QID:13021�Ή�
                                        errMessage = "�I���S���҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// ADD 2010/08/12 ��QID:13021�Ή�
                                    }
                                    else if (totalDiv == 3)
                                    {
                                        //errMessage = "�J�n�󒍎҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// DEL 2010/08/12 ��QID:13021�Ή�
                                        errMessage = "�I���󒍎҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// ADD 2010/08/12 ��QID:13021�Ή�
                                    }
                                    else if (totalDiv == 4)
                                    {
                                        //errMessage = "�J�n���s�҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// DEL 2010/08/12 ��QID:13021�Ή�
                                        errMessage = "�I�����s�҃R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B";// ADD 2010/08/12 ��QID:13021�Ή�
                                    }
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        errMessage,
                                        -1,
                                        MessageBoxButtons.OK);
                                    //this.tNedit_SelectionCode_Ed.Text = code.ToString();// DEL 2010/08/12 ��QID:13021�Ή�
                                    this.tNedit_SelectionCode_Ed.Text = employeeCode;// ADD 2010/08/12 ��QID:13021�Ή�
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    //this.tNedit_SelectionCode_Ed.SetInt(code);// DEL 2010/08/12 ��QID:13021�Ή�

                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Tab:
                                            case Keys.Return:
                                                {
                                                    if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                                    {
                                                        e.NextCtrl = this.uButton_SelectionCodeEd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tDateEdit_FinancialYear;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                // �Ώ۔N�x
                case "tDateEdit_FinancialYear":
                    {
                        int code = this.tDateEdit_FinancialYear.GetDateYear();
                        if (code == 0 || code == 1)
                        {
                            this.tDateEdit_FinancialYear.SetLongDate(this._financialYearsd * 10000);
                            e.NextCtrl = e.PrevCtrl;
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
                            }
                        }
                        break;
                    }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ��ʂ̃N���A
        /// </summary>
        /// <br>Note       : ��ʂ̃N���A�����B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void Clear()
        {
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();

            this.tNedit_SelectionCode_St.Clear();
            this.tNedit_SelectionCode_Ed.Clear();

            this._sectionName = string.Empty;
            this._selectionName = string.Empty;
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N
        /// </summary>
        /// <br>Note       : ��ʓ��̓`�F�b�N�ł��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             �E��Q�� #14643 �e�L�X�g�o�͑Ή�</br>
        private bool InputCheck()
        {
            // ���_
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                _prevInputValue.SectionCodeSt = "00";
            }
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                _prevInputValue.SectionCodeEd = "00";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd))
            if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n���_�R�[�h�̒l���I�����_�R�[�h�̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            // SelectionCode
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text))
            {
                _prevInputValue.SelectionCodeSt = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text))
            {
                _prevInputValue.SelectionCodeEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SelectionCodeSt) > Convert.ToInt32(_prevInputValue.SelectionCodeEd) && this.tComboEditor_TotalDiv1.SelectedIndex != 0)
            if (Convert.ToInt32(_prevInputValue.SelectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SelectionCodeSt) > Convert.ToInt32(_prevInputValue.SelectionCodeEd) && this.tComboEditor_TotalDiv1.SelectedIndex != 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                string errMessage = string.Empty;
                switch (this.tComboEditor_TotalDiv1.SelectedIndex)
                {
                    case 1:
                        {
                            errMessage = "�J�n���Ӑ�R�[�h�̒l���I�����Ӑ�R�[�h�̒l�������Ă��܂��B";
                            break;
                        }
                    case 2:
                        {
                            errMessage = "�J�n�S���҃R�[�h�̒l���I���S���҃R�[�h�̒l�������Ă��܂��B";
                            break;
                        }
                    case 3:
                        {
                            errMessage = "�J�n�󒍎҃R�[�h�̒l���I���󒍎҃R�[�h�̒l�������Ă��܂��B";
                            break;
                        }
                    case 4:
                        {
                            errMessage = "�J�n���s�҃R�[�h�̒l���I�����s�҃R�[�h�̒l�������Ă��܂��B";
                            break;
                        }
                    case 5:
                        {
                            errMessage = "�J�n�n��R�[�h�̒l���I���n��R�[�h�̒l�������Ă��܂��B";
                            break;
                        }
                    case 6:
                        {
                            errMessage = "�J�n�Ǝ�R�[�h�̒l���I���Ǝ�R�[�h�̒l�������Ă��܂��B";
                            break;
                        }
                }
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            
            // �Ώ۔N��
            if (_financialYearsd < this.tDateEdit_FinancialYear.GetDateYear())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���N�x�͓��͏o���܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
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
        /// <param name="code">���͒l</param>
        /// <param name="name">�Ԃ�l</param>
        /// <param name="stFlg">��ʋ��_�R�[�h(�J�n)�A���_�R�[�h(�I��)</param>
        /// <returns>bool</returns>
        /// <br>Note       : ���_���̎擾�����ł��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private bool ReadSectionCodeAllowZero(out string code, string inputValue, bool stFlg)
        {
            // ���͒l���擾
            string sectionCode = inputValue.Trim().PadLeft(2, '0');
            code = sectionCode;

            if (stFlg)
            {
                if (_prevInputValue.SectionCodeSt == sectionCode)
                {
                    this.tNedit_SectionCodeSt.Text = sectionCode;
                    return true;
                }
            }
            else
            {
                if (_prevInputValue.SectionCodeEd == sectionCode)
                {
                    this.tNedit_SectionCodeEd.Text = sectionCode;
                    return true;
                }
            }

            // 00:�S��
            if (sectionCode == "00")
            {
                sectionCode = "00";
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = sectionCode;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = sectionCode;
                }
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --------------- UPD 2010/09/20 ------------>>>>>
                    if (sectionInfo.LogicalDeleteCode == 0)
                    {
                        code = sectionInfo.SectionCode.TrimEnd();
                        if (stFlg)
                        {
                            _prevInputValue.SectionCodeSt = code;
                        }
                        else
                        {
                            _prevInputValue.SectionCodeEd = code;
                        }
                        return true;
                    }
                    else
                    {
                        if (stFlg)
                        {
                            code = _prevInputValue.SectionCodeSt;
                        }
                        else
                        {
                            code = _prevInputValue.SectionCodeEd;
                        }
                        return false;
                    }
                    //code = sectionInfo.SectionCode.TrimEnd();
                    //if (stFlg)
                    //{
                    //    _prevInputValue.SectionCodeSt = code;
                    //}
                    //else
                    //{
                    //    _prevInputValue.SectionCodeEd = code;
                    //}
                    //return true;
                    // --------------- UPD 2010/09/20 ------------<<<<<
                }
                else
                {
                    if (stFlg)
                    {
                        code = _prevInputValue.SectionCodeSt;
                    }
                    else
                    {
                        code = _prevInputValue.SectionCodeEd;
                    }
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = code;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = code;
                }
                return true;
            }
        }

        /// <summary>
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="code">�����擾SelectionCode</param>
        /// <param name="inputValue">���SelectionCode</param>
        /// <param name="stFlg">��ʊJ�n�R�[�h�A�I���R�[�h</param>
        /// <param name="totalDiv">�敪</param>
        /// <returns>true�Afalse</returns>
        /// <br>Note       : ���̎擾�����ł��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            �E��QID:13021 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        // ------------ UPD 2010/09/21 ----------------------------------------------------->>>>>
        //private bool ReadCustomerName(out int code, int inputValue, bool stFlg, int totalDiv)
        private bool ReadCustomerName(out string code, int inputValue, bool stFlg, int totalDiv)
        // ------------ UPD 2010/09/21 -----------------------------------------------------<<<<<
        {
            int customerCode = inputValue;
            code = customerCode.ToString();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (stFlg)
            {
                if (_prevInputValue.SelectionCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.SelectionCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode > 0)
            {
                if (totalDiv == 1)
                {
                    CustomerInfo customerInfo;
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        this._selectionName = customerInfo.Name;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                }
                // --- DEL 2010/08/12 ��QID:13021�Ή�-------------------------------->>>>>
                //else if (totalDiv == 2 || totalDiv == 3 || totalDiv == 4)
                //{
                //    // �S���ҁE�󒍎ҁE���s��
                //    EmployeeAcs employeeAcs = new EmployeeAcs();
                //    Employee employee;
                //    status = employeeAcs.Read(out employee, this._enterpriseCode, inputValue.ToString());
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        this._selectionName = employee.Name;
                //    }
                //}
                // --- DEL 2010/08/12 ��QID:13021�Ή�-------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stFlg)
                    {
                        _prevInputValue.SelectionCodeSt = customerCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.SelectionCodeEd = customerCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeSt); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeSt; // ADD 2010/09/21
                    }
                    else
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeEd); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeEd; // ADD 2010/09/21
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SelectionCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.SelectionCodeEd = customerCode.ToString();
                }
                return true;
            }
        }
        // --- ADD 2010/08/12 ��QID:13021�Ή�-------------------------------->>>>>
        /// <summary>
        /// �S���Җ��̎擾
        /// </summary>
        /// <param name="code">�����擾SelectionCode</param>
        /// <param name="inputValue">���SelectionCode</param>
        /// <param name="stFlg">��ʊJ�n�R�[�h�A�I���R�[�h</param>
        /// <returns>true�Afalse</returns>
        /// <br>Note       : ���̎擾�����ł��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/12</br>
        private bool ReadEmployee(out string code, string inputValue, bool stFlg)
        {
            string customerCode = inputValue;
            code = customerCode;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (stFlg)
            {
                if (_prevInputValue.SelectionCodeSt == customerCode) return true;
            }
            else
            {
                if (_prevInputValue.SelectionCodeEd == customerCode) return true;
            }

            if (customerCode != string.Empty)
            {
                // �S���ҁE�󒍎ҁE���s��
                EmployeeAcs employeeAcs = new EmployeeAcs();
                Employee employee;
                status = employeeAcs.Read(out employee, this._enterpriseCode, inputValue);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ------- UPD 2010/09/20 ----------------------------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    if (employee.LogicalDeleteCode == 0)
                    {
                        this._selectionName = employee.Name;
                        if (stFlg)
                        {
                            _prevInputValue.SelectionCodeSt = customerCode;
                        }
                        else
                        {
                            _prevInputValue.SelectionCodeEd = customerCode;
                        }
                        return true;
                    }
                    else
                    {
                        if (stFlg)
                        {
                            code = _prevInputValue.SelectionCodeSt;
                        }
                        else
                        {
                            code = _prevInputValue.SelectionCodeEd;
                        }
                        return false;
                    }
                    //this._selectionName = employee.Name;
                    //if (stFlg)
                    //{
                    //    _prevInputValue.SelectionCodeSt = customerCode;
                    //}
                    //else
                    //{
                    //    _prevInputValue.SelectionCodeEd = customerCode;
                    //}
                    //return true;
                    // ------- UPD 2010/09/20 -----------------------------<<<<<  
                }
                else
                {
                    if (stFlg)
                    {
                        code = _prevInputValue.SelectionCodeSt;
                    }
                    else
                    {
                        code = _prevInputValue.SelectionCodeEd;
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SelectionCodeSt = customerCode;
                }
                else
                {
                    _prevInputValue.SelectionCodeEd = customerCode;
                }
                return true;
            }
        }
        // --- ADD 2010/08/12 ��QID:13021�Ή�--------------------------------<<<<<
        /// <summary>
        /// �n��Ǝ�擾
        /// </summary>
        /// <param name="code">�����擾SelectionCode</param>
        /// <param name="inputValue">���SelectionCode</param>
        /// <param name="stFlg">��ʊJ�n�R�[�h�A�I���R�[�h</param>
        /// <param name="totalDiv">�敪</param>
        /// <param name="userGuideDivCd">�敪</param>
        /// <returns>true�Afalse</returns>
        /// <br>Note       : �n��Ǝ�擾�����ł��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/20 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        // ------------ UPD 2010/09/21 ------------------------------------------------------------->>>>>
        //private bool ReadSelectionName(out int code, int inputValue, bool stFlg, int userGuideDivCd)
        private bool ReadSelectionName(out string code, int inputValue, bool stFlg, int userGuideDivCd)
        // ------------ UPD 2010/09/21 -------------------------------------------------------------<<<<<
        {
            int customerCode = inputValue;
            //code = customerCode; // DEL 2010/09/21
            code = customerCode.ToString(); // ADD 2010/09/21
            bool chkflg = false;

            if (stFlg)
            {
                if (_prevInputValue.SelectionCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.SelectionCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode >= 0)
            {
                UserGuideAcs _userGuideAcs = new UserGuideAcs();
                UserGdHd userGdHd = new UserGdHd();
                ArrayList userGdBdList = new ArrayList();
                int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UserGdBd userGdBd in userGdBdList)
                    {
                        // ---------- UPD 2010/09/21 ----------------------------------------------------->>>>>
                        //if ((userGdBd.UserGuideDivCd == userGuideDivCd) && (userGdBd.GuideCode == code))
                        if ((userGdBd.UserGuideDivCd == userGuideDivCd) && (userGdBd.GuideCode == Convert.ToInt32(code)))
                        // ---------- UPD 2010/09/21 -----------------------------------------------------<<<<<
                        {
                            this._selectionName = userGdBd.GuideName;
                            chkflg = true;
                            break;
                        }
                    }
                    if (chkflg)
                    {
                        if (stFlg)
                        {
                            _prevInputValue.SelectionCodeSt = customerCode.ToString();
                        }
                        else
                        {
                            _prevInputValue.SelectionCodeEd = customerCode.ToString();
                        }
                        return true;
                    }
                    else
                    {
                        if (stFlg)
                        {
                            //code = Convert.ToInt32(_prevInputValue.SelectionCodeSt); // DEL 2010/09/21
                            code = _prevInputValue.SelectionCodeSt; // ADD 2010/09/21
                        }
                        else
                        {
                            //code = Convert.ToInt32(_prevInputValue.SelectionCodeEd); // DEL 2010/09/21
                            code = _prevInputValue.SelectionCodeEd; // ADD 2010/09/21
                        }
                        return false;
                    }
  
                }
                else
                {
                    if (stFlg)
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeSt); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeSt; // ADD 2010/09/21
                    }
                    else
                    {
                        //code = Convert.ToInt32(_prevInputValue.SelectionCodeEd); // DEL 2010/09/21
                        code = _prevInputValue.SelectionCodeEd; // ADD 2010/09/21
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SelectionCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.SelectionCodeEd = customerCode.ToString();
                }
                return true;
            }
        }


        /// <summary>
        /// �O��l�ێ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O��l�ێ��������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/16</br>
        /// </remarks>
        private struct PrevInputValue
        {
            /// <summary>�J�n���_�R�[�h</summary>
            private string _sectionCodeSt;
            /// <summary>�I�����_�R�[�h</summary>
            private string _sectionCodeEd;
            /// <summary>�J�nSelectionCode</summary>
            private string _selectionCodeSt;
            /// <summary>�I��SelectionCode</summary>
            private string _selectionCodeEd;

            /// <summary>�J�n���_�R�[�h</summary>
            public string SectionCodeSt
            {
                get { return _sectionCodeSt; }
                set { _sectionCodeSt = value; }
            }

            /// <summary>�I�����_�R�[�h</summary>
            public string SectionCodeEd
            {
                get { return _sectionCodeEd; }
                set { _sectionCodeEd = value; }
            }

            /// <summary>�J�n�d����R�[�h</summary>
            public string SelectionCodeSt
            {
                get { return _selectionCodeSt; }
                set { _selectionCodeSt = value; }
            }

            /// <summary>�I���d����R�[�h</summary>
            public string SelectionCodeEd
            {
                get { return _selectionCodeEd; }
                set { _selectionCodeEd = value; }
            }
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            DCHNB04180UC userSettingFrm = new DCHNB04180UC();
            userSettingFrm.AnalysisChartSettingAcs.Deserialize();
            switch(this.tComboEditor_TotalDiv1.SelectedIndex)
            {
                case 0:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SectionFileNameValue;
                        break;
                    }
                case 1:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.CustomerFileNameValue;
                        break;
                    }
                case 2:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SalesEmployeeFileNameValue;
                        break;
                    }
                case 3:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.FrontEmployeeFileNameValue;
                        break;
                    }
                case 4:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SalesInputFileNameValue;
                        break;
                    }
                case 5:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.SalesAreaFileNameValue;
                        break;
                    }
                case 6:
                    {
                        fileName = userSettingFrm.AnalysisChartSettingAcs.BusinessTypeFileNameValue;
                        break;
                    }
                case 7:
                    {
                        break;
                    }
            }
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
                    fileName += ".CSV";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }

        /// <summary>
        /// ���o�����Z�b�g
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/09 �k���r</br>
        /// <br>            �E��QID:13278 PM1010F�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2024/11/29 ���O</br>
        /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private void SetExtratConst()
        {
            // �Ώۋ��_�R�[�h
            List<string[]> sectionCodeList = new List<string[]>();
            // SelectionCode���X�g
            List<string[]> selectionCodeList = new List<string[]>();
            //string selectName = null; // DEL 2010/08/30

            // ���_�̎擾
            // ---------------- UPD 2010/09/19 ----------------------------------------------->>>>>
            //if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt())
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt() ||
                this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
            // ---------------- UPD 2010/09/19 -----------------------------------------------<<<<<
            {
                // ---------------- UPD 2010/09/19 ----------------------->>>>>
                //if (this.tNedit_SectionCodeSt.GetInt() == 0)
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                // ---------------- UPD 2010/09/19 -----------------------<<<<<
                {
                    // �S�Ўw��
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    ArrayList relList = new ArrayList();
                    int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in relList)
                        {
                            // --------------- UPD 2010/09/19 -------------------------------------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeEd.GetInt() == 0 && this.tNedit_SectionCodeSt.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0)
                            {
                                // �S�Ўw��
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
                            // --------------- UPD 2010/09/19 --------------------------------------------------<<<<<

                        }
                    }
                }
                else
                {
                    string[] sectionArr = new string[2];
                    sectionArr[0] = this.tNedit_SectionCodeSt.Text;
                    if (!string.IsNullOrEmpty(this._sectionName))
                    {
                        sectionArr[1] = this._sectionName;
                    }
                    else
                    {
                        // ���_�����擾
                        SecInfoSet sectionInfo;
                        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tNedit_SectionCodeSt.Text);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                            sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09

                        }
                    }
                    
                    sectionCodeList.Add(sectionArr);
                }
            }
            else
            {
                // --- UPD 2010/09/20 ---------->>>>>
                //string code;
                //SecInfoSet sectionInfo;
                //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                //int status = 0;

                //for (int i = this.tNedit_SectionCodeSt.GetInt(); i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                //{
                //    code = i.ToString();
                //    code = code.Trim().PadLeft(2, '0');
                //    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        //-----ADD 2010/09/09---------->>>>>
                //        if (sectionInfo.LogicalDeleteCode != 0)
                //        {
                //            continue;
                //        }
                //        //-----ADD 2010/09/09----------<<<<<
                //        string[] sectionArr = new string[2];
                //        sectionArr[0] = code;
                //        sectionArr[1] = sectionInfo.SectionGuideNm;
                //        sectionCodeList.Add(sectionArr);
                //    }
                //}
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                ArrayList relList = new ArrayList();
                int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet sectionInfo in relList)
                    {
                        if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode) && this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode))
                        {
                            string[] sectionArr = new string[2];
                            sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                            sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                            sectionCodeList.Add(sectionArr);
                        }
                    }
                }
                // --- UPD 2010/09/20 ----------<<<<<
            }
            this._sectionCodeList = sectionCodeList;

            // --- DEL 2010/08/25 -------------------------------->>>>>
            // SelectionCode�̎擾
            //if (this.tNedit_SelectionCode_St.GetInt() == this.tNedit_SelectionCode_Ed.GetInt())
            //{
            //    if (this.tNedit_SelectionCode_St.GetInt() == 0)
            //    {
            //        // SelectionCode�S�擾
            //        this.GetALLSelectionCodeList(out selectionCodeList, this.tComboEditor_TotalDiv1.SelectedIndex);
            //    }
            //    else
            //    {
            //        string[] selectionArray = new string[2];
            //        selectionArray[0] = this.tNedit_SelectionCode_St.Text;
            //        if (!string.IsNullOrEmpty(this._selectionName))
            //        {
            //            selectionArray[1] = this._selectionName;
            //        }
            //        else
            //        {
            //            this.GetSelectionName(out selectName, this.tNedit_SelectionCode_St.Text, this.tComboEditor_TotalDiv1.SelectedIndex);
            //            selectionArray[1] = _selectionName;
            //        }
            //        selectionCodeList.Add(selectionArray);
            //    }
            //}
            //else
            //{
            //    this.GetSelectionCodeList(out selectionCodeList, this.tNedit_SelectionCode_St.Text, this.tNedit_SelectionCode_Ed.Text, this.tComboEditor_TotalDiv1.SelectedIndex);
            //}
            //this._selectionCodeList = selectionCodeList;
            // --- DEL 2010/08/25 --------------------------------<<<<<

            this._ed_selectionCode = this.tNedit_SelectionCode_Ed.Text.Trim();

            this._st_selectionCode = this.tNedit_SelectionCode_St.Text.Trim();

            // �W�v�敪
            this._totalDiv = this.tComboEditor_TotalDiv1.SelectedIndex;
            // �Ώ۔N�x
            this._financialYear = this.tDateEdit_FinancialYear.GetDateYear();
            // �o�̓t�@�C����
            this._settingFileName = this.tEdit_SettingFileName.Text;
            //�����敪
            this.SearDiv = 1; // ADD 2010/08/25
            //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v
            SectionCodeSt = this.tNedit_SectionCodeSt.Text.Trim();
            // �I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v
            SectionCodeEd = this.tNedit_SectionCodeEd.Text.Trim();
            //--- ADD 2024/11/29 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        }

        /// <summary>
        /// SelectionCode�S�擾
        /// </summary>
        /// <param name="selectionCodeList">SelectionCode���X�g</param>
        /// <param name="totalDiv">�W�v�敪</param>
        /// <br>Note       : SelectionCode�S�擾�������s���B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void GetALLSelectionCodeList(out List<string[]> selectionCodeList, int totalDiv)
        {
            selectionCodeList = new List<string[]>();
            switch (totalDiv)
            {
                case 1:
                    {
                        // ���Ӑ�
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            string[] customerArray = new string[2];
                            customerArray[0] = ret.CustomerCode.ToString();
                            customerArray[1] = ret.Name;
                            selectionCodeList.Add(customerArray);
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        // �S���ҁE�󒍎ҁE���s��
                        EmployeeAcs employeeAcs = new EmployeeAcs();
                        ArrayList retList;
                        ArrayList retList2;
                        int status = employeeAcs.Search(out retList, out retList2, this._enterpriseCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (Employee employee in retList)
                            {
                                if (employee.LogicalDeleteCode == 0)
                                {
                                    string[] employeeArray = new string[2];
                                    employeeArray[0] = employee.EmployeeCode;
                                    employeeArray[1] = employee.Name;
                                    selectionCodeList.Add(employeeArray);
                                }
                            }
                        }
                        break;
                    }
                case 5:
                case 6:
                    {
                        UserGuideAcs _userGuideAcs = new UserGuideAcs();
                        UserGdHd userGdHd = new UserGdHd();
                        ArrayList userGdBdList = new ArrayList();
                        int userGuideDivCd;
                        if (totalDiv == 5)
                        {
                            // �n��i�̔��G���A�j
                            userGuideDivCd = 21;
                        }
                        else
                        {
                            // �Ǝ�
                            userGuideDivCd = 33;
                        }
                        int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData, userGuideDivCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (UserGdBd userGdBd in userGdBdList)
                            {
                                string[] userArray = new string[2];
                                userArray[0] = userGdBd.GuideCode.ToString();
                                userArray[1] = userGdBd.GuideName;
                                selectionCodeList.Add(userArray);
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// SelectionCode�S�擾
        /// </summary>
        /// <param name="selectionCodeList">SelectionCode���X�g</param>
        /// <param name="selectionCodeSt">SelectionCodeSt</param>
        /// <param name="selectionCodeEd">SelectionCodeEd</param>
        /// <param name="totalDiv">�W�v�敪</param>
        /// <returns>bool</returns>
        /// <br>Note       : SelectionCode�S�擾�������s���B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void GetSelectionCodeList(out List<string[]> selectionCodeList, string selectionCodeSt, string selectionCodeEd, int totalDiv)
        {
            selectionCodeList = new List<string[]>();
            switch (totalDiv)
            {
                case 1:
                    {
                        // ���Ӑ�
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                            {
                                string[] customerAyyary = new string[2];
                                customerAyyary[0] = ret.CustomerCode.ToString();
                                customerAyyary[1] = ret.Name;
                                selectionCodeList.Add(customerAyyary);
                            }
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        // �S���ҁE�󒍎ҁE���s��
                        EmployeeAcs employeeAcs = new EmployeeAcs();
                        ArrayList retList;
                        ArrayList retList2;
                        int status = employeeAcs.Search(out retList, out retList2, this._enterpriseCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (Employee employee in retList)
                            {
                                if (employee.LogicalDeleteCode == 0)
                                {
                                    if (employee.EmployeeCode.CompareTo(selectionCodeSt) >= 0 && employee.EmployeeCode.CompareTo(selectionCodeEd) <= 0)
                                    {
                                        string[] employeeArray = new string[2];
                                        employeeArray[0] = employee.EmployeeCode;
                                        employeeArray[1] = employee.Name;
                                        selectionCodeList.Add(employeeArray);
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 5:
                case 6:
                    {
                        UserGuideAcs _userGuideAcs = new UserGuideAcs();
                        UserGdHd userGdHd = new UserGdHd();
                        ArrayList userGdBdList = new ArrayList();
                        int userGuideDivCd;
                        if (totalDiv == 5)
                        {
                            // �n��i�̔��G���A�j
                            userGuideDivCd = 21;
                        }
                        else
                        {
                            // �Ǝ�
                            userGuideDivCd = 33;
                        }
                        int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData, userGuideDivCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (UserGdBd userGdBd in userGdBdList)
                            {
                                if (userGdBd.GuideCode >= Convert.ToInt32(selectionCodeSt) && userGdBd.GuideCode <= Convert.ToInt32(selectionCodeEd))
                                {
                                    string[] userArray = new string[2];
                                    userArray[0] = userGdBd.GuideCode.ToString();
                                    userArray[1] = userGdBd.GuideName;
                                    selectionCodeList.Add(userArray);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// SelectionName�擾
        /// </summary>
        /// <param name="selectionName">SelectionName</param>
        /// <param name="selectionCode">SelectionCode</param>
        /// <param name="totalDiv">�W�v�敪</param>
        /// <br>Note       : SelectionName�擾�擾�������s���B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        private void GetSelectionName(out string selectName, string selectionCode, int totalDiv)
        {
            selectName = null;
            switch (totalDiv)
            {
                case 1:
                    {
                        // ���Ӑ�
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            if (ret.CustomerCode == Convert.ToInt64(selectionCode))
                            {
                                selectName = ret.Name;
                                break;

                            }
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        // �S���ҁE�󒍎ҁE���s��
                        EmployeeAcs employeeAcs = new EmployeeAcs();
                        ArrayList retList;
                        ArrayList retList2;
                        int status = employeeAcs.Search(out retList, out retList2, this._enterpriseCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (Employee employee in retList)
                            {
                                if (employee.LogicalDeleteCode == 0)
                                {
                                    if (employee.EmployeeCode == selectionCode)
                                    {
                                        selectName = employee.Name;
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 5:
                case 6:
                    {
                        UserGuideAcs _userGuideAcs = new UserGuideAcs();
                        UserGdHd userGdHd = new UserGdHd();
                        ArrayList userGdBdList = new ArrayList();
                        int userGuideDivCd;
                        if (totalDiv == 5)
                        {
                            // �n��i�̔��G���A�j
                            userGuideDivCd = 21;
                        }
                        else
                        {
                            // �Ǝ�
                            userGuideDivCd = 33;
                        }
                        int status = _userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.OfferDivCodeMergeBodyData, userGuideDivCd);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (UserGdBd userGdBd in userGdBdList)
                            {
                                if (userGdBd.GuideCode == Convert.ToInt64(selectionCode))
                                {
                                    selectName = userGdBd.GuideName;
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }
        }
        #endregion

        /// <summary>
        /// tComboEditor���̒l��ω����鏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : tComboEditor���̒l��ω����鏈���B</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2010/09/21</br>
        private void tComboEditor_TotalDiv1_ValueChanged(object sender, EventArgs e)
        {
            this._prevInputValue.SelectionCodeSt = string.Empty;
            this._prevInputValue.SelectionCodeEd = string.Empty;
        }
    }
}