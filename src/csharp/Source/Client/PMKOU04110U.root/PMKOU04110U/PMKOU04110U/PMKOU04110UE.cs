using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d���N�Ԏ��яƉ�e�L�X�g�o�͏����ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���N�Ԏ��яƉ�ꗗ�e�L�X�g�o�͐ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : �m�u��</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/08/19 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13279</br>
    /// <br>Update Note: 2010/09/21 liyp</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�14867</br>
    /// <br>Update Note: 2010/10/09 tianjw</br>
    /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2024/11/22 ���O</br>
    /// <br>            �EPMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
    /// </remarks>
    public partial class PMKOU04110UE : Form
    {
        #region �v���C�x�[�g����

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>�Ώ۔N�x</summary>
        private int _financialYear = 0;

        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;    

        /// <summary>�o�̓t�@�C����</summary>
        private string _settingFileName = string.Empty;

        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCodeSt = string.Empty;

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCodeEd = string.Empty;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _supplierCodeSt = 0;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _supplierCodeEd = 0;

        /// <summary>�o�͋敪</summary>
        private bool _excelFlg;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_TextOutput;

        /// <summary>�t�H�[���N���X�t���O</summary>
        private bool _formcloseFlg = false;

        /// <summary>�J�n���_</summary>
        private string _prevInputSectionSt = null;

        /// <summary>�I�����_</summary>
        private string _prevInputSectionEd = null;

        /// <summary>�J�n�d����</summary>
        private string _prevInputSupplierSt = null;

        /// <summary>�I���d����</summary>
        private string _prevInputSupplierEd = null;

        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n�d����R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _suppPrtPprCdSt;
        /// <summary>�I���d����R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        private string _suppPrtPprCdEd;
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

        /// <summary>����v�N�x</summary>
        /// <remarks>�J�n���Ɏ��Аݒ肩��擾���A�ύX����܂���</remarks>
        private int _currentFinancialYear = 0;

        /// <summary>�N�x�J�n��</summary>
        private int _companyBeginMonth;

        /// <summary>�G���[���b�Z�[�W�F�u���N�x�͓��͏o���܂���B�v</summary>
        private const string CT_CANNOT_INPUT_FOLLOWING = "���N�x�͓��͏o���܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�{�N�x�܂��͍�N�x�̂ݓ��͉\�ł��B�v</summary>
        private const string CT_CAN_INPUT_ONLY_TWICE = "�{�N�x�܂��͍�N�x�̂ݓ��͉\�ł��B";

        const int WM_COPYDATA = 0x004A;

        public IntPtr parentHanPtr;

        /// <summary>�d����N�Ԏ��яƉ� �A�N�Z�X�N���X</summary>
        private SuppYearResultAcs _suppYearResultAcs = null;

        #endregion
        public PMKOU04110UE()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;

            // ���������F��
            this.tNedit_SectionCodeSt.Text = string.Empty;
            this.tNedit_SectionCodeEd.Text = string.Empty;
            
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            PMKOU04110UC userSettingFrm = new PMKOU04110UC();
            userSettingFrm._textFileSettingAcs.Deserialize();
            fileName = userSettingFrm._textFileSettingAcs.SupplierFileName;
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

        #region �C�x���g
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ胍�[�h�C�x���g�ł��B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMKOU04110UE_Load(object sender, EventArgs e)
        {
            this.ultraButton_OK.ImageList = this._imageList16;
            this.ultraButton_Cancel.ImageList = this._imageList16;

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

            // �Ώ۔N���̏������̐ݒ�
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);

            // �d���N�Ԏ��яƉ�A�N�Z�X�N���X�������A���ʃf�[�^�Z�b�g�擾
            this._suppYearResultAcs = new SuppYearResultAcs();
            // ��v�N�x�擾
            this._suppYearResultAcs.GetCompanyInf(this._enterpriseCode, out this._currentFinancialYear, out this._companyBeginMonth);
            this._financialYear = this._currentFinancialYear;

            ChangeFileName();
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �m�u��</br>
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
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
                this.DResult = DialogResult.OK;
                FormcloseFlg = true;
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
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/08 �k���r</br>
        /// <br>            �E��QID:14443 �e�L�X�g�o�͑Ή�</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // --------ADD 2010/09/08--------->>>>>
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excel�t�@�C��(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("�e�L�X�g�t�@�C��(*.CSV) | *.CSV");
            }
            // --------ADD 2010/09/08---------<<<<<
            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �m�u��</br>
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
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SelectionCode_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            Supplier supplierInfo;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, "0");

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((Control)sender).Name.EndsWith("St"))
                {
                    this.tNedit_SelectionCode_St.SetInt(supplierInfo.SupplierCd);
                    _prevInputSupplierSt = supplierInfo.SupplierCd.ToString();
                }
                else
                {
                    this.tNedit_SelectionCode_Ed.SetInt(supplierInfo.SupplierCd);
                    _prevInputSupplierEd = supplierInfo.SupplierCd.ToString();
                }
            }
        }


        #region �N�x�ύX��
        // --- DEL 2010/08/19 -------------------------------->>>>>
        ///// <summary>
        ///// �N�x�ύX��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tDateEdit_FinancialYear_Leave(object sender, EventArgs e)
        //{
        //    SendMessage(this.parentHanPtr, WM_COPYDATA, 0, this.tDateEdit_FinancialYear.GetDateYear());

        //}
        // --- DEL 2010/08/19 --------------------------------<<<<<
        #endregion // �N�x�ύX��

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�[�J�X���ύX���ꂽ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�14876</br>
        /// <br>Update Note : 2010/09/26 tianjw</br>
        /// <br>            : Redmine#14876�Ή�</br>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
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

                        // NextCtrl����
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SectionCodeSt.Text.Trim() == "00")
                                        {
                                            e.NextCtrl = this.uButton_SectionCodeSt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SectionCodeEd;
                                        }
                                        if (!status)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
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

                        // NextCtrl����
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SectionCodeEd.Text.Trim() == "00")
                                        {
                                            e.NextCtrl = this.uButton_SectionCodeEd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SelectionCode_St;
                                        }
                                        if (!status)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_SelectionCode_St":
                    {
                        int code = this.tNedit_SelectionCode_St.GetInt();
                        int status = 0;
                        if (code != 0)
                        {
                            // �d����
                            Supplier supplierInfo;
                            SupplierAcs supplierAcs = new SupplierAcs();
                            status = supplierAcs.Read(out supplierInfo, this._enterpriseCode, code);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�J�n�d����R�[�h [" + code + "] �ɊY������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_SelectionCode_St.Text = _prevInputSupplierSt;
                                this.tNedit_SelectionCode_St.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // --------UPD 2010/09/21-------->>>>>

                                if (supplierInfo.LogicalDeleteCode == 1)
                                {
                                    // �G���[��
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "�J�n�d����R�[�h [" + code + "] �ɊY������f�[�^�����݂��܂���B", -1, MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    this.tNedit_SelectionCode_St.Text = this._prevInputSupplierSt;
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // --------UPD 2010/09/21--------<<<<<

                                _prevInputSupplierSt = supplierInfo.SupplierCd.ToString();
                            }
                        }
                        // NextCtrl����
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_SelectionCodeSt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SelectionCode_Ed;
                                        }
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_SelectionCode_Ed":
                    {
                        int code = this.tNedit_SelectionCode_Ed.GetInt();
                        int status = 0;
                        if (code != 0)
                        {
                            // �d����
                            Supplier supplierInfo;
                            SupplierAcs supplierAcs = new SupplierAcs();
                            status = supplierAcs.Read(out supplierInfo, this._enterpriseCode, code);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�I���d����R�[�h [" + code + "] �ɊY������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_SelectionCode_Ed.Text = _prevInputSupplierEd;
                                this.tNedit_SelectionCode_Ed.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // --------UPD 2010/09/21-------->>>>>

                                if (supplierInfo.LogicalDeleteCode == 1)
                                {
                                    // �G���[��
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "�I���d����R�[�h [" + code + "] �ɊY������f�[�^�����݂��܂���B", -1, MessageBoxButtons.OK);

                                    // �R�[�h�߂�
                                    // --------- UPD 2010/09/26 ----------------------------------->>>>>
                                    //this.tNedit_SelectionCode_St.Text = this._prevInputSupplierSt;
                                    //this.tNedit_SelectionCode_St.SelectAll();
                                    this.tNedit_SelectionCode_Ed.Text = this._prevInputSupplierEd;
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    // --------- UPD 2010/09/26 -----------------------------------<<<<<
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // --------UPD 2010/09/21--------<<<<<

                                _prevInputSupplierEd = supplierInfo.SupplierCd.ToString();
                            }
                        }
                        // NextCtrl����
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_SelectionCodeEd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_FinancialYear;
                                        }
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            e.NextCtrl = e.PrevCtrl;
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

        /// <summary>
        /// �t�H�[���N���[�X�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : �t�H�[���N���[�X���ɔ������܂��B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMKOU04110UE_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_formcloseFlg)
                this._dialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ��ʓ��̓`�F�b�N
        /// </summary>
        /// <br>Note       : ��ʓ��̓`�F�b�N�ł��B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/19 chenyd</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�13279</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             �E��Q�� #14643 �e�L�X�g�o�͑Ή�</br>
        private bool InputCheck()
        {
            // ���_
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                this._sectionCodeSt = "00";
                _prevInputSectionSt = "00";
            }
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                this._sectionCodeEd = "00";
                _prevInputSectionEd = "00";
            }

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
                return false;
            }
            // SelectionCode
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierSt))
            if (string.IsNullOrEmpty(tNedit_SelectionCode_St.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                this._supplierCodeSt = 0; // ADD 2010/09/15
                _prevInputSupplierSt = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierEd))
            if (string.IsNullOrEmpty(tNedit_SelectionCode_Ed.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                this._supplierCodeEd = 0; // ADD 2010/09/15
                _prevInputSupplierEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd))
            if (Convert.ToInt32(_prevInputSupplierEd) != 0 && (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n�d����R�[�h�̒l���I���d����R�[�h�̒l�������Ă��܂��B",
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
            // --- ADD 2010/08/19 -------------------------------->>>>>
            // ��v�N�x�v�Z
            if (this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear ||
                this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear - 1)
            {
                this._financialYear = this.tDateEdit_FinancialYear.GetDateYear();
            }
            else if (this.tDateEdit_FinancialYear.GetDateYear() > this._currentFinancialYear)
            {
                // ���N�x�֏C��
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // ���N�x�֏C��
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK);

                return false;
            }
            // --- ADD 2010/08/19 --------------------------------<<<<<
            return true;
        }

        /// <summary>
        /// ���o�����Z�b�g
        /// </summary>
        /// <br>Note       : �o�̓t�@�C�����ύX�������s���B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2024/11/22 ���O</br>
        /// <br>             PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή�</br>
        private void SetExtratConst()
        {
            // �J�n���_�R�[�h
            this.SectionCodeSt = this.tNedit_SectionCodeSt.Text.Trim();
            // �I�����_�R�[�h
            this.SectionCodeEd = this.tNedit_SectionCodeEd.Text.Trim();
            // �J�n�d����R�[�h
            this.SupplierCodeSt = this.tNedit_SelectionCode_St.GetInt();
            // �I���d����R�[�h
            this.SupplierCodeEd = this.tNedit_SelectionCode_Ed.GetInt();
            // �Ώ۔N�x
            this.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();
            // �o�̓t�@�C����
            this.SettingFileName = this.tEdit_SettingFileName.Text.Trim();
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
            // �J�n�d����R�[�h�u���O�I�y���[�V�����f�[�^�v
            this.SuppPrtPprCodeSt = this.tNedit_SelectionCode_St.Text.Trim();
            // �I���d����R�[�h�u���O�I�y���[�V�����f�[�^�v
            this.SuppPrtPprCodeEd = this.tNedit_SelectionCode_Ed.Text.Trim();
            //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="code">�Ԃ�l</param>
        /// <param name="inputValue">���͒l</param>
        /// <param name="startEnd">�J�n�I���敪</param>
        /// <returns>bool</returns>
        /// <br>Note       : ���_���̎擾�����ł��B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 liyp</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�14876</br>
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --------UPD 2010/09/21-------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    //name = sectionInfo.SectionGuideSnm.TrimEnd();
                    //return true;

                    if (sectionInfo.LogicalDeleteCode == 1)
                    {
                        if ("st".Equals(startEnd))
                            code = _prevInputSectionSt;
                        else
                            code = _prevInputSectionEd;
                        return false;
                    }
                    else
                    {
                        // --------UPD 2010/09/21--------<<<<<
                        code = sectionInfo.SectionCode.Trim();
                        if ("st".Equals(startEnd))
                            _prevInputSectionSt = code;
                        else
                            _prevInputSectionEd = code;
                        return true;
                    }
                    
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

        #endregion
        #region�@�v���p�e�B
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
        /// �o�͌`��
        /// </summary>
        public bool ExcelFlg
        {
            get { return _excelFlg; }
            set { this._excelFlg = value; }
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

        /// <summary>
        /// �J�n�d����R�[�h
        /// </summary>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { this._supplierCodeSt = value; }
        }

        /// <summary>
        /// �I���d����R�[�h
        /// </summary>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { this._supplierCodeEd = value; }
        }

        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�������
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }

        /// <summary>
        /// �t�H�[���N���X�t���O
        /// </summary>
        public bool FormcloseFlg
        {
            get { return this._formcloseFlg; }
            set { this._formcloseFlg = value; }
        }

        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ---->>>>>
        /// <summary>�J�n�d����R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string SuppPrtPprCodeSt
        {
            get { return _suppPrtPprCdSt; }
            set { _suppPrtPprCdSt = value; }
        }

        /// <summary>�I���d����R�[�h�u���O�I�y���[�V�����f�[�^�v</summary>
        public string SuppPrtPprCodeEd
        {
            get { return _suppPrtPprCdEd; }
            set { _suppPrtPprCdEd = value; }
        }
        //--- ADD 2024/11/22 ���O PMKOBETSU-4368 2024�NPKG�i��̃��O�o�͑Ή� ----<<<<<
        #endregion

        /// <summary>
        /// �|�b�v�A�b�v��ʂ���Ɖ��ʂ܂ł̃p�����[�^�[�̑��M
        /// </summary>
        /// <param name="hWnd">hWnd</param>
        /// <param name="Msg">Msg</param>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        /// <returns>int</returns>
        /// <br>Note       : �|�b�v�A�b�v��ʂ���Ɖ��ʂ܂ł̃p�����[�^�[�̑��M���s��</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
               IntPtr hWnd,�@�@�@// handle to destination window
               int Msg,�@�@�@ // message
               int wParam,�@// first message parameter
               int lParam // second message parameter
         );
    }
}
