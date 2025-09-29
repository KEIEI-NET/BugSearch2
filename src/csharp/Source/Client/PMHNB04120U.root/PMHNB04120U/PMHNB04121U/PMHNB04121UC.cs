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
    /// ���Ӑ�ߔN�x���яƉ�e�L�X�g�o�͏����ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ߔN�x���яƉ�e�L�X�g�o�͐ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/10/09 yangmj</br>
    /// <br>            �E�e�L�X�g�o�͑Ή� �s��Ή�#15879</br>
    /// <br>Update Note: 2024/11/22 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
    public partial class PMHNB04121UC : Form
    {
        #region �v���C�x�[�g����

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;                  

        /// <summary>��ƃR�[�h</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>�o�͌`��</summary>
        private bool _excelFlg;

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

        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _sectionCodeSt = string.Empty;
        /// <summary>�I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _sectionCodeEd = string.Empty;
        /// <summary>�J�n���Ӑ�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _customerCodeSt = string.Empty;
        /// <summary>�I�����Ӑ�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _customerCodeEd = string.Empty;
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<

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

        PrevInputValue _prevInputValue = new PrevInputValue();
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="excelFlg">�o�͌`���t���O</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMHNB04121UC()
        {
            InitializeComponent();
        }
        #endregion

        #region �v���p�e�B
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

        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
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

        /// <summary>�J�n���Ӑ�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// <summary>�I�����Ӑ�R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        #endregion

        #region �C�x���g
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g�ł��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private void DCHNB04180UE_Load(object sender, EventArgs e)
        {
            this._dialogResult = DialogResult.Cancel;
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
            // �o�̓t�@�C�����̏������̐ݒ�
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();
            this.tNedit_SelectionCode_St.Clear();
            this.tNedit_SelectionCode_Ed.Clear();
            this.tEdit_SettingFileName.Text = this._settingFileName;
            this.ChangeFileName();
        }

        /// <summary>
        /// �I�����ύX���ꂽ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �I�����ύX���ꂽ�ꍇ�ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private void tComboEditor_TotalDiv_SelectionChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Height = this.tNedit_SectionCodeSt.Size.Height;

            this.uLabel_SelectionCode.Visible = true;
            this.tNedit_SelectionCode_St.Visible = true;
            this.tNedit_SelectionCode_St.ExtEdit.Column = 8;
            this.tNedit_SelectionCode_Ed.Visible = true;
            this.tNedit_SelectionCode_Ed.ExtEdit.Column = 8;
            this.ultraLabel11.Visible = true;
            this.uButton_SelectionCodeSt.Visible = true;
            this.uButton_SelectionCodeEd.Visible = true;

            this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = false;
            this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = false;
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
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SelectionCode_Click(object sender, EventArgs e)
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

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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
            this._prevInputValue.CustomerCodeSt = this.tNedit_SelectionCode_St.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <br>Note       : ���Ӑ悪�I�����ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
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
            this._prevInputValue.CustomerCodeEd = this.tNedit_SelectionCode_Ed.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�[�J�X���ύX���ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
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
                            this.tNedit_SectionCodeSt.Text = code;
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
                                                e.NextCtrl = this.tNedit_SelectionCode_St;
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
                            this.tNedit_SectionCodeEd.Text = code;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SelectionCode_St":
                    {
                        int inputValue = this.tNedit_SelectionCode_St.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, true);
                        if (status)
                        {
                            this.tNedit_SelectionCode_St.SetInt(code);

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
                            this.tNedit_SelectionCode_St.Text = code.ToString();
                            this.tNedit_SelectionCode_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SelectionCode_Ed":
                    {
                        int inputValue = this.tNedit_SelectionCode_Ed.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, false);
                        if (status)
                        {
                            this.tNedit_SelectionCode_Ed.SetInt(code);

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
                                                e.NextCtrl = this.tEdit_SettingFileName;
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
                                "�I�����Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tNedit_SelectionCode_Ed.Text = code.ToString();
                            this.tNedit_SelectionCode_Ed.SelectAll();
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

        /// <summary>
        /// �t�H������C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�������鎞�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMHNB04121UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this._dialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ��ʂ̃N���A
        /// </summary>
        /// <br>Note       : ��ʂ̃N���A�����B</br>
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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

            // ���Ӑ�
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text))
            {
                _prevInputValue.CustomerCodeSt = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text))
            {
                _prevInputValue.CustomerCodeEd = "0";
            }
            // ���Ӑ�
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd))
            if (Convert.ToInt32(_prevInputValue.CustomerCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                string errMessage = string.Empty;

                errMessage = "�J�n���Ӑ�R�[�h�̒l���I�����Ӑ�R�[�h�̒l�������Ă��܂��B";

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
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
        /// <param name="code">�����擾���_�R�[�h</param>
        /// <param name="inputValue">��ʋ��_�R�[�h</param>
        /// <param name="stFlg">��ʋ��_�R�[�h(�J�n)�A���_�R�[�h(�I��)</param>
        /// <returns>true�Afalse</returns>
        /// <br>Note       : ���_���̎擾�����ł��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
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
                    // ------- UPD 2010/09/21 ----------------------------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
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
                    //if (stFlg)
                    //{
                    //    _prevInputValue.SectionCodeSt = code;
                    //}
                    //else
                    //{
                    //    _prevInputValue.SectionCodeEd = code;
                    //}
                    //return true;
                    // ------- UPD 2010/09/21 -----------------------------<<<<<
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
        /// <param name="code">�����擾���Ӑ�R�[�h</param>
        /// <param name="inputValue">��ʓ��Ӑ�R�[�h</param>
        /// <param name="stFlg">��ʓ��Ӑ�R�[�h(�J�n)�A���Ӑ�R�[�h(�I��)</param>
        /// <returns>true�Afalse</returns>
        /// <br>Note       : ���Ӑ於�̎擾�����ł��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private bool ReadCustomerName(out int code, int inputValue, bool stFlg)
        {
            int customerCode = inputValue;
            code = customerCode;

            if (stFlg)
            {
                if (_prevInputValue.CustomerCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.CustomerCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                {
                    if (stFlg)
                    {
                        _prevInputValue.CustomerCodeSt = customerCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.CustomerCodeEd = customerCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = Convert.ToInt32(_prevInputValue.CustomerCodeSt);
                    }
                    else
                    {
                        code = Convert.ToInt32(_prevInputValue.CustomerCodeEd);
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.CustomerCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.CustomerCodeEd = customerCode.ToString();
                }
                return true;
            }
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            PMHNB04121UB userSettingFrm = new PMHNB04121UB();
            userSettingFrm.AnalysisChartSettingAcs.Deserialize();

            fileName = userSettingFrm.AnalysisChartSettingAcs.CustomInqFileNameValue;

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
        /// �O��l�ێ�
        /// </summary>
        /// <br>Note       : �O��l�ێ��������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        private struct PrevInputValue
        {
            /// <summary>�J�n���_�R�[�h</summary>
            private string _sectionCodeSt;
            /// <summary>�I�����_�R�[�h</summary>
            private string _sectionCodeEd;
            /// <summary>�J�n���Ӑ�R�[�h</summary>
            private string _customerCodeSt;
            /// <summary>�I�����Ӑ�R�[�h</summary>
            private string _customerCodeEd;

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

            /// <summary>�J�n���Ӑ�R�[�h</summary>
            public string CustomerCodeSt
            {
                get { return _customerCodeSt; }
                set { _customerCodeSt = value; }
            }

            /// <summary>�I�����Ӑ�R�[�h</summary>
            public string CustomerCodeEd
            {
                get { return _customerCodeEd; }
                set { _customerCodeEd = value; }
            }
        }

        /// <summary>
        /// ���o�����Z�b�g
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note :2024/11/22 ���O</br>
        /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private void SetExtratConst()
        {
            // �Ώۋ��_�R�[�h
            List<string[]> sectionCodeList = new List<string[]>();
            // SelectionCode���X�g
            List<string[]> selectionCodeList = new List<string[]>();

            // ���_�̎擾
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt()
                || this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
            {
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                {
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    ArrayList relList = new ArrayList();
                    int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in relList)
                        {
                            // --------------------- UPD 2010/09/21 --------------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    sectionArr[1] = sectionInfo.SectionGuideNm;
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeEd.GetInt() == 0 && this.tNedit_SectionCodeSt.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    sectionArr[1] = sectionInfo.SectionGuideNm;
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0)
                            {
                                // �S�Ўw��
                                string[] sectionArr = new string[2];
                                sectionArr[0] = sectionInfo.SectionCode;
                                sectionArr[1] = sectionInfo.SectionGuideNm;
                                sectionCodeList.Add(sectionArr);
                            }
                            //string[] sectionArr = new string[2];
                            //sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm;
                            //sectionCodeList.Add(sectionArr);
                            // --------------------- UPD 2010/09/21 ---------------------------<<<<<
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
                            sectionArr[1] = sectionInfo.SectionGuideNm;

                        }
                    }

                    sectionCodeList.Add(sectionArr);
                }
            }
            else
            {
                // --- UPD 2010/09/21 ---------->>>>>
                //string code;
                //SecInfoSet sectionInfo;
                //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                //int status = 0;

                //for (int i = this.tNedit_SectionCodeSt.GetInt(); i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                //{
                //    code = i.ToString();
                //    code = code.Trim().PadLeft(2, '0');
                //    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                //    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEl 2010/09/20
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/20
                //    {
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
                        if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode) && this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode) && sectionInfo.LogicalDeleteCode == 0)
                        {
                            string[] sectionArr = new string[2];
                            sectionArr[0] = sectionInfo.SectionCode;
                            sectionArr[1] = sectionInfo.SectionGuideNm;
                            sectionCodeList.Add(sectionArr);
                        }
                    }
                }
                // --- UPD 2010/09/21 ----------<<<<<
            }
            this._sectionCodeList = sectionCodeList;

                // SelectionCode�̎擾
            if (this.tNedit_SelectionCode_St.GetInt() == this.tNedit_SelectionCode_Ed.GetInt())
            {
                if (this.tNedit_SelectionCode_St.GetInt() == 0)
                {
                    // SelectionCode�S�擾
                    this.GetALLSelectionCodeList(out selectionCodeList);
                }
                else
                {
                    string[] selectionArray = new string[2];
                    selectionArray[0] = this.tNedit_SelectionCode_St.Text;
                    if (!string.IsNullOrEmpty(this._selectionName))
                    {
                        selectionArray[1] = this._selectionName;
                    }
                    else
                    {
                        // ���Ӑ�
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            if (ret.CustomerCode == this.tNedit_SelectionCode_St.GetInt())
                            {
                                selectionArray[1] = ret.Name;
                                break;

                            }
                        }
                    }
                    selectionCodeList.Add(selectionArray);
                }
            }
            else
            {
                this.GetSelectionCodeList(out selectionCodeList, this.tNedit_SelectionCode_St.Text, this.tNedit_SelectionCode_Ed.Text);
            }
            this._selectionCodeList = selectionCodeList;
            // �o�̓t�@�C����
            this._settingFileName = this.tEdit_SettingFileName.Text;

            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �J�n���_�R�[�h�u���O�I�y���[�V�����f�[�^�v
            SectionCodeSt = this.tNedit_SectionCodeSt.Text.Trim();
            // �I�����_�R�[�h�u���O�I�y���[�V�����f�[�^�v
            SectionCodeEd = this.tNedit_SectionCodeEd.Text.Trim();
            // �J�n���Ӑ�R�[�h�u���O�I�y���[�V�����f�[�^�v
            CustomerCodeSt = this.tNedit_SelectionCode_St.Text.Trim();
            // �I�����Ӑ�R�[�h�u���O�I�y���[�V�����f�[�^�v
            CustomerCodeEd = this.tNedit_SelectionCode_Ed.Text.Trim();
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        }

        /// <summary>
        /// SelectionCode�S�擾
        /// </summary>
        /// <param name="selectionCodeList">SelectionCode���X�g</param>
        /// <br>Note       : SelectionCode�S�擾�������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private void GetALLSelectionCodeList(out List<string[]> selectionCodeList)
        {
            selectionCodeList = new List<string[]>();
            // ���Ӑ�
            CustomerSearchRet[] customerSearchRet;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;
            customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

            foreach (CustomerSearchRet ret in customerSearchRet)
            {
                // --------- ADD 2010/09/21 -------------------->>>>>
                if (ret.LogicalDeleteCode == 0) { 
                    string[] customerArray = new string[2];
                    customerArray[0] = ret.CustomerCode.ToString();
                    customerArray[1] = ret.Name;
                    selectionCodeList.Add(customerArray);
                }
                // --------- ADD 2010/09/21 --------------------<<<<<
            }
              
        }

        /// <summary>
        /// SelectionCode�S�擾
        /// </summary>
        /// <param name="selectionCodeList">SelectionCode���X�g</param>
        /// <param name="selectionCodeSt">SelectionCodeSt</param>
        /// <param name="selectionCodeEd">SelectionCodeEd</param>
        /// <returns>bool</returns>
        /// <br>Note       : SelectionCode�S�擾�������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 �e�L�X�g�o�͑Ή�</br>
        private void GetSelectionCodeList(out List<string[]> selectionCodeList, string selectionCodeSt, string selectionCodeEd)
        {
            selectionCodeList = new List<string[]>();
            // ���Ӑ�
            CustomerSearchRet[] customerSearchRet;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;
            customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

            foreach (CustomerSearchRet ret in customerSearchRet)
            {
                // ------------UPD 2010/09/21 -------------------------------------->>>>>
                if (string.IsNullOrEmpty(selectionCodeSt))
                {
                    // ---------------------- UPD 2010/09/21 -------------------------------->>>>>
                    //if (ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                    if (ret.CustomerCode <= Convert.ToInt32(selectionCodeEd) && ret.LogicalDeleteCode == 0)
                    // ---------------------- UPD 2010/09/21 --------------------------------<<<<<
                    {
                        string[] customerAyyary = new string[2];
                        customerAyyary[0] = ret.CustomerCode.ToString();
                        customerAyyary[1] = ret.Name;
                        selectionCodeList.Add(customerAyyary);
                    } 
                }
                else if (string.IsNullOrEmpty(selectionCodeEd))
                {
                    // ---------------------- UPD 2010/09/21 -------------------------------->>>>>
                    //if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt))
                    if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.LogicalDeleteCode == 0)
                    // ---------------------- UPD 2010/09/21 --------------------------------<<<<<
                    {
                        string[] customerAyyary = new string[2];
                        customerAyyary[0] = ret.CustomerCode.ToString();
                        customerAyyary[1] = ret.Name;
                        selectionCodeList.Add(customerAyyary);
                    } 
                }
                else
                {
                    // ---------------------- UPD 2010/09/21 -------------------------------->>>>>
                    //if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                    if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd) && ret.LogicalDeleteCode == 0)
                    // ---------------------- UPD 2010/09/21 --------------------------------<<<<<
                    {
                        string[] customerAyyary = new string[2];
                        customerAyyary[0] = ret.CustomerCode.ToString();
                        customerAyyary[1] = ret.Name;
                        selectionCodeList.Add(customerAyyary);
                    } 
                }
                //if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                //{
                //    string[] customerAyyary = new string[2];
                //    customerAyyary[0] = ret.CustomerCode.ToString();
                //    customerAyyary[1] = ret.Name;
                //    selectionCodeList.Add(customerAyyary);
                //} 
                // ------------UPD 2010/09/21 --------------------------------------<<<<<
            }
        }
        #endregion

    }
}