using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

using System.IO;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d����d�q�����c���ꗗ�e�L�X�g�o�͏����ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����d�q�����c���ꗗ�e�L�X�g�o�͐ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : chenyd</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>UpdateNote : 2010/09/21 ������</br>
    /// <br>            �Eredmine#14876</br>
    /// <br>Update Note: 2016/01/18 ����</br>
    /// <br>�Ǘ��ԍ�   : 11200002-00 2016�N2���z�M��</br>
    /// <br>             Redmine#48327 �d����d�q�����c���e�L�X�g�o�͂őΏ۔N���̏������C������B</br>
    /// <br>Update Note: 2019/08/19 ���O</br>
    /// <br>           : PMKOBETSU-1379 �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
    public partial class PMKOU04001UC : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �e�L�X�g�o�͏����ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="excelFlg">�o�͌`���t���O</param>
        /// <param name="balanceDiv">�c�����</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͏����ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMKOU04001UC(bool excelFlg, int balanceDiv)
        {
            InitializeComponent();

            _imageList16 = IconResourceManagement.ImageList16;

            uButton_SectionCodeSt.ImageList = _imageList16;
            uButton_SectionCodeSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SectionCodeEd.ImageList = _imageList16;
            uButton_SectionCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SupplierCdSt.ImageList = _imageList16;
            uButton_SupplierCdSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SupplierCdEd.ImageList = _imageList16;
            uButton_SupplierCdEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_FileSelect.ImageList = _imageList16;
            uButton_FileSelect.Appearance.Image = (int)Size16_Index.STAR1;

            tComboEditor_BalanceDiv.Value = balanceDiv;

            _excelFlg = excelFlg;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccPay("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            // ���ߓ�
            if (prevTotalDay == DateTime.MinValue)
            {
                // ��ʂփZ�b�g
                // ����(�N���x)�擾
                DateTime thisYearMonth;
                DateGetAcs _dateGetAcs = DateGetAcs.GetInstance();
                _dateGetAcs.GetThisYearMonth(out thisYearMonth);
                tDateEdit_CheckDateSt.SetDateTime(thisYearMonth);
                tDateEdit_CheckDateEd.SetDateTime(thisYearMonth);
            }
            else
            {
                // ��ʂփZ�b�g
                tDateEdit_CheckDateSt.SetDateTime(prevTotalMonth); // �O���������
                tDateEdit_CheckDateEd.SetDateTime(prevTotalMonth); // �O���������
            }

            ChangeFileName();
        }
        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�����o
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        PrevInputValue _prevInputValue = new PrevInputValue();
        // **** �{�^���p�C���[�W���X�g ****
        private ImageList _imageList16 = null;

        private bool _excelFlg;
        private SuppPrtPprBlnce _suppPrtPprBlnce = new SuppPrtPprBlnce();
        private int _balanceDiv = 0;
        private string _fileName;
        private DialogResult _dialogResult = DialogResult.Cancel;

        //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        /// <summary>�J�n���_�R�[�h</summary>
        private string SectionCdSt;
        /// <summary>�I�����_�R�[�h</summary>
        private string SectionCdEd;
        /// <summary>�J�n�d����R�[�h</summary>
        private string SuppPrtPprCdSt;
        /// <summary>�I���d����R�[�h</summary>
        private string SuppPrtPprCdEd;
        /// <summary>�J�n�Ώ۔N��</summary>
        private string addUpYearMonthSt;
        /// <summary>�I���Ώ۔N��</summary>
        private string addUpYearMonthEd;
        //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
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

        #endregion // �v���C�x�[�g�����o

        #region �v���p�e�B

        // ���o����
        public SuppPrtPprBlnce SuppPrtPprBlnce
        {
            get { return _suppPrtPprBlnce; }
            set { _suppPrtPprBlnce = value; }
        }

        // �c�����
        public int BalanceDiv
        {
            get { return _balanceDiv; }
            set { _balanceDiv = value; }
        }

        // �o�͐�t�@�C����
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        // �t�H�[���I���X�e�[�^�X
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }

        //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        /// <summary>�J�n���_�R�[�h</summary>
        public string SectionCodeSt
        {
            get { return SectionCdSt; }
            set { SectionCdSt = value; }
        }

        /// <summary>�I�����_�R�[�h</summary>
        public string SectionCodeEd
        {
            get { return SectionCdEd; }
            set { SectionCdEd = value; }
        }

        /// <summary>�J�n�d����R�[�h</summary>
        public string SuppPrtPprCodeSt
        {
            get { return SuppPrtPprCdSt; }
            set { SuppPrtPprCdSt = value; }
        }

        /// <summary>�I���d����R�[�h</summary>
        public string SuppPrtPprCodeEd
        {
            get { return SuppPrtPprCdEd; }
            set { SuppPrtPprCdEd = value; }
        }

        /// <summary>�J�n�Ώ۔N��</summary>
        public string AddUpYearMonthSt
        {
            get { return addUpYearMonthSt; }
            set { addUpYearMonthSt = value; }
        }

        /// <summary>�I���Ώ۔N��</summary>
        public string AddUpYearMonthEd
        {
            get { return addUpYearMonthEd; }
            set { addUpYearMonthEd = value; }
        }
        //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
        #endregion // �v���p�e�B

        #region �C�x���g
        /// <summary>
        /// �J�n�d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �J�n�d����K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�\��
            int status = 0;
            Supplier supplierInfo;
            string sectionCd = string.Empty;
            SupplierAcs _supplierAcs = new SupplierAcs();
            // �K�C�h�\��
            status = _supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, sectionCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ��ʏ�ɃZ�b�g
                this.tNedit_SupplierCd_St.SetInt(supplierInfo.SupplierCd);
                this._prevInputValue.SuppPrtPprCodeSt = this.tNedit_SupplierCd_St.DataText; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// �I���d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �I���d����K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�\��
            int status = 0;
            Supplier supplierInfo;
            string sectionCd = string.Empty;
            SupplierAcs _supplierAcs = new SupplierAcs();
            // �K�C�h�\��
            status = _supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, sectionCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ��ʏ�ɃZ�b�g
                this.tNedit_SupplierCd_Ed.SetInt(supplierInfo.SupplierCd);
                this._prevInputValue.SuppPrtPprCodeEd = this.tNedit_SupplierCd_Ed.DataText; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// �J�n���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �J�n���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_SectionCodeSt_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeSt.Text = sectionInfo.SectionCode.Trim();
                this._prevInputValue.SectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// �I�����_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �I�����_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_SectionCodeEd_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                this._prevInputValue.SectionCodeEd = this.tNedit_SectionCodeEd.Text; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                // �J�n���_�R�[�h
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, true);
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
                // �I�����_�R�[�h
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, false);
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
                                                e.NextCtrl = this.tNedit_SupplierCd_St;
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
                // �J�n�d����R�[�h
                case "tNedit_SupplierCd_St":
                    {
                        int inputValue = this.tNedit_SupplierCd_St.GetInt();
                        int code;
                        bool status = ReadSuppPrtPprName(out code, inputValue, true);
                        if (status)
                        {
                            this.tNedit_SupplierCd_St.SetInt(code);
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SupplierCdSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd_Ed;
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
                                "�J�n�d����R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tNedit_SupplierCd_St.Text = code.ToString();
                            this.tNedit_SupplierCd_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // �I���d����R�[�h
                case "tNedit_SupplierCd_Ed":
                    {
                        int inputValue = this.tNedit_SupplierCd_Ed.GetInt();
                        int code;
                        bool status = ReadSuppPrtPprName(out code, inputValue, false);
                        if (status)
                        {
                            this.tNedit_SupplierCd_Ed.SetInt(code);
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SupplierCdEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_CheckDateSt;
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
                                "�I���d����R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tNedit_SupplierCd_Ed.Text = code.ToString();
                            this.tNedit_SupplierCd_Ed.SelectAll();
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
                                            e.NextCtrl = uButton_OK;
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
        /// �L�����Z���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�����Z���{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : chenyd</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OK�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : OK�{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : chenyd</br>
        /// <br>Date        : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             �E��Q�� #14643 �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            #region ���̓`�F�b�N
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
                return;
            }
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text))
            {
                _prevInputValue.SuppPrtPprCodeSt = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text))
            {
                _prevInputValue.SuppPrtPprCodeEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SuppPrtPprCodeSt) > Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd))
            if (Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SuppPrtPprCodeSt) > Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n�d����R�[�h�̒l���I���d����R�[�h�̒l�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            // �Ώ۔N��
            int sMonth = (this.tDateEdit_CheckDateSt.GetLongDate() / 100) % 100;
            int sYear = this.tDateEdit_CheckDateSt.GetLongDate() / 10000;
            int eMonth = (this.tDateEdit_CheckDateEd.GetLongDate() / 100) % 100;
            int eYear = this.tDateEdit_CheckDateEd.GetLongDate() / 10000;

            if (sMonth == 0 || sYear == 0)
            {
                TMsgDisp.Show(
              this,
              emErrorLevel.ERR_LEVEL_INFO,
              this.Name,
              "�J�n�Ώۓ��t���s���ł��B",
              -1,
              MessageBoxButtons.OK);
                return;
            }

            if (eMonth == 0 || eYear == 0)
            {
                TMsgDisp.Show(
              this,
              emErrorLevel.ERR_LEVEL_INFO,
              this.Name,
              "�I���Ώۓ��t���s���ł��B",
              -1,
              MessageBoxButtons.OK);
                return;
            }

            if (this.tDateEdit_CheckDateSt.GetLongDate() > this.tDateEdit_CheckDateEd.GetLongDate())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n�Ώۓ��t���I���Ώۓ��t�������Ă��܂��B",
                    -1,
                    MessageBoxButtons.OK);
                return;
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
                return;
            }
            #endregion  // ���̓`�F�b�N

            SetSuppPrtPprBlnce();

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

        /// <summary>
        /// �c�����ValueChangeed�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �c����ʃR���g���[���̃e�L�X�g���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : chenyd</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void tComboEditor_BalanceDiv_ValueChanged(object sender, EventArgs e)
        {
            ChangeFileName();
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�@�C���_�C�A���O�R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
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
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // �C�x���g

        #region �v���C�x�[�g�����o
        /// <summary>
        /// ���_�擾����
        /// </summary>
        /// <param name="code">�����擾���_�R�[�h</param>
        /// <param name="inputValue">��ʋ��_�R�[�h</param>
        /// <param name="stFlg">��ʋ��_�R�[�h(�J�n)�A���_�R�[�h(�I��)</param>
        /// <returns>true�Afalse</returns>
        /// <remarks>
        /// <br>Note       : ���_�擾�������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote : 2010/09/21 ������</br>
        /// <br>            �Eredmine#14876</br>
        /// </remarks>
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
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
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
        /// �d����擾
        /// </summary>
        /// <param name="code">�����擾�d����R�[�h</param>
        /// <param name="inputValue">��ʎd����R�[�h</param>
        /// <param name="stFlg">��ʎd����R�[�h(�J�n)�A�d����R�[�h(�I��)</param>
        /// <returns>true�Afalse</returns>
        /// <remarks>
        /// <br>Note       : �d����擾�������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote : 2010/09/21 ������</br>
        /// <br>            �Eredmine#14876</br>
        /// </remarks>
        private bool ReadSuppPrtPprName(out int code, int inputValue, bool stFlg)
        {
            int supplierCode = inputValue;
            code = supplierCode;
            
            if (stFlg)
            {
                if (_prevInputValue.SuppPrtPprCodeSt == supplierCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.SuppPrtPprCodeEd == supplierCode.ToString()) return true;
            }

            if (supplierCode > 0)
            {
                Supplier supplierInfo;
                SupplierAcs supplierAcs = new SupplierAcs();
                int status = supplierAcs.Read(out supplierInfo, this._enterpriseCode, inputValue);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    if (stFlg)
                    {
                        _prevInputValue.SuppPrtPprCodeSt = supplierCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.SuppPrtPprCodeEd = supplierCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = Convert.ToInt32(_prevInputValue.SuppPrtPprCodeSt);
                    }
                    else
                    {
                        code = Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd);
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SuppPrtPprCodeSt = supplierCode.ToString();
                }
                else
                {
                    _prevInputValue.SuppPrtPprCodeEd = supplierCode.ToString();
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
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private struct PrevInputValue
        {
            /// <summary>�J�n���_�R�[�h</summary>
            private string _sectionCodeSt;
            /// <summary>�I�����_�R�[�h</summary>
            private string _sectionCodeEd;
            /// <summary>�J�n�d����R�[�h</summary>
            private string _suppPrtPprCodeSt;
            /// <summary>�I���d����R�[�h</summary>
            private string _suppPrtPprCodeEd;

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
            public string SuppPrtPprCodeSt
            {
                get { return _suppPrtPprCodeSt; }
                set { _suppPrtPprCodeSt = value; }
            }

            /// <summary>�I���d����R�[�h</summary>
            public string SuppPrtPprCodeEd
            {
                get { return _suppPrtPprCodeEd; }
                set { _suppPrtPprCodeEd = value; }
            }
        }

        /// <summary>
        /// ���o�����Z�b�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����Z�b�g�������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote : 2010/09/21 ������</br>
        /// <br>            �Eredmine#14876</br>
        /// <br>Update Note: 2016/01/18 ����</br>
        /// <br>�Ǘ��ԍ�   : 11200002-00 2016�N2���z�M��</br>
        /// <br>             Redmine#48327 �d����d�q�����c���e�L�X�g�o�͂őΏ۔N���̏������C������B</br>
        /// <br>Update Note: 2019/08/19 ���O</br>
        /// <br>           : PMKOBETSU-1379 �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// </remarks>
        private void SetSuppPrtPprBlnce()
        {
            // �Ώۋ��_�R�[�h
            string[] sectionCode;
            int status = 0;
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt() || this.tNedit_SectionCodeEd.GetInt() == 0)
            {
                // ----------------- UPD 2010/09/19 --------------------------------------------->>>>>
                //if (this.tNedit_SectionCodeEd.GetInt() == 0)
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                // ----------------- UPD 2010/09/19 ---------------------------------------------<<<<<
                {
                    // �S�Ўw��
                    ArrayList retList;
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    int all = 0;
                    status = secInfoSetAcs.Search(out retList, this._enterpriseCode);
                    sectionCode = new string[retList.Count];
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in retList)
                        {
                            // ---------------- UPD 2010/09/19 -------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0)
                            {
                                sectionCode[all] = sectionInfo.SectionCode;
                                all++;
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    sectionCode[all] = sectionInfo.SectionCode;
                                    all++;
                                }
                            }
                            //sectionCode[all] = sectionInfo.SectionCode;
                            //all++;
                            // ---------------- UPD 2010/09/19 --------------------<<<<<
                        }
                    }
                }
                else
                {
                    sectionCode = new string[] { this.tNedit_SectionCodeSt.Text };
                }
                this._suppPrtPprBlnce.SectionCode = sectionCode;
            }
            else
            {
                int i = this.tNedit_SectionCodeSt.GetInt();
                int addCnt = 0;
                string code;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                sectionCode = new string[(this.tNedit_SectionCodeEd.GetInt() - this.tNedit_SectionCodeSt.GetInt()) + 1];
                for (; i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                {
                    code = i.ToString();
                    code = code.Trim().PadLeft(2, '0');
                    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                    {
                        sectionCode[addCnt] = code;
                        addCnt++;
                    }
                }
                string[] retSecCode = new string[addCnt];
                for (i = 0; i < addCnt; i++)
                {
                    retSecCode[i] = sectionCode[i];
                }
                this._suppPrtPprBlnce.SectionCode = retSecCode;
            }

            int dts = this.tDateEdit_CheckDateSt.GetLongDate();
            int dte = this.tDateEdit_CheckDateEd.GetLongDate();
            // --- DEL 2016/01/18 ���� Redmine#48327 �d����d�q�����c���e�L�X�g�o�͂őΏ۔N���̏������C������ ----->>>>>
            //dts++;
            //dte++;
            // --- DEL 2016/01/18 ���� Redmine#48327 �d����d�q�����c���e�L�X�g�o�͂őΏ۔N���̏������C������ -----<<<<<
            // --- ADD 2016/01/18 ���� Redmine#48327 �d����d�q�����c���e�L�X�g�o�͂őΏ۔N���̏������C������ ----->>>>>
            // �e�L�X�g�o�͂őΏ۔N���̏������C������B��ʂ���̔N��+��(�Œ�F01)
            dts = (dts / 100) * 100 + 1;
            dte = (dte / 100) * 100 + 1;
            // --- ADD 2016/01/18 ���� Redmine#48327 �d����d�q�����c���e�L�X�g�o�͂őΏ۔N���̏������C������ -----<<<<<
            this.tDateEdit_CheckDateSt.SetLongDate(dts);
            this.tDateEdit_CheckDateEd.SetLongDate(dte);

            // �J�n�Ώ۔N��
            this._suppPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime();
            // �I���Ώ۔N��
            this._suppPrtPprBlnce.Ed_AddUpYearMonth = this.tDateEdit_CheckDateEd.GetDateTime();

            //�d����(�J�n)
            this._suppPrtPprBlnce.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
            //�d����(�I��)
            this._suppPrtPprBlnce.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

            // �c�����
            this.BalanceDiv = Convert.ToInt32(this.tComboEditor_BalanceDiv.Value);

            // �o�͐�t�@�C����
            this.FileName = this.tEdit_SettingFileName.Text;

            // ��ƃR�[�h
            this._suppPrtPprBlnce.EnterpriseCode = _enterpriseCode;
            //�����敪
            this._suppPrtPprBlnce.SearchDiv = 1;

            //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
            // �J�n���_�R�[�h
            this.SectionCdSt = this.tNedit_SectionCodeSt.Text;
            // �I�����_�R�[�h
            this.SectionCdEd = this.tNedit_SectionCodeEd.Text;
            // �J�n�d����R�[�h
            this.SuppPrtPprCdSt = this.tNedit_SupplierCd_St.Text;
            // �I���d����R�[�h
            this.SuppPrtPprCdEd = this.tNedit_SupplierCd_Ed.Text;
            // �J�n�Ώ۔N��
            this.addUpYearMonthSt = this.tDateEdit_CheckDateSt.GetDateYear().ToString() + this.tDateEdit_CheckDateSt.GetDateMonth().ToString("00");
            // �I���Ώ۔N��
            this.addUpYearMonthEd = this.tDateEdit_CheckDateEd.GetDateYear().ToString() + this.tDateEdit_CheckDateEd.GetDateMonth().ToString("00");
            //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�̓t�@�C�����ύX�������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void ChangeFileName()
        {
            PMKOU04004UA userSettingForm = new PMKOU04004UA();
            string fileName = string.Empty;
            string path = string.Empty;
            userSettingForm.Deserialize();
            if (Convert.ToInt32(tComboEditor_BalanceDiv.Value) == 0)
            {
                // �x��
                fileName = userSettingForm.UserSetting.SuplierFileName;
            }
            else
            {
                // ���|
                fileName = userSettingForm.UserSetting.SuplAccFileName;
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (_excelFlg)
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
        #endregion // �v���C�x�[�g�����o
    }
}