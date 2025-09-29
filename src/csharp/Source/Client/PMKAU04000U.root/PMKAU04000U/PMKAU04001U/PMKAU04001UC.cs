using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;      // ConstantManagement�̎g�p�ɕK�v(SFCMN00006C)
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
    /// ���Ӑ�d�q�����c���ꗗ�e�L�X�g�o�͏����ݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q�����c���ꗗ�e�L�X�g�o�͐ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2010/04/15</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/13 30744 ���� ����q</br>
    /// <br>           : 10801804-00�@�o�͏����̒ǉ��A�e�L�X�g�o�̗͂^�M���يz�̒ǉ�</br>
    /// <br>Update Note: 2013/03/29 shijx</br>
    /// <br>           : 10800003-00�@2013/05/15�z�M�� Redmine#35205���Ӑ�d�q�����̑Ή�</br>
    /// <br>           : �@�t�H�[�J�X�����_�A���Ӑ�Ɏw�肵�Ă���ꍇ�Ashift+tab�����A�t�H�[�J�X���ړ��ł��܂���</br>
    /// <br>           : �A�����̐���s��</br>
    /// <br>           : �B�o�̓t�@�C������"\\"���L��ꍇ�A�K�C�h�����A�G���[����</br>
    /// <br>Update Note: 2019/08/19 ���O</br>
    /// <br>           : 11570163-00 PMKOBETSU-1379 �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
    public partial class PMKAU04001UC : Form
    {
        #region �R���X�g���N�^
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //public PMKAU04001UC(bool excelFlg, int balanceDiv)
        public PMKAU04001UC(bool excelFlg, int balanceDiv, int RemainSectionType)
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        {
            InitializeComponent();

            _imageList16 = IconResourceManagement.ImageList16;

            uButton_SectionCodeSt.ImageList = _imageList16;
            uButton_SectionCodeSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SectionCodeEd.ImageList = _imageList16;
            uButton_SectionCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_CustomerCodeSt.ImageList = _imageList16;
            uButton_CustomerCodeSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_CustomerCodeEd.ImageList = _imageList16;
            uButton_CustomerCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_FileSelect.ImageList = _imageList16;
            uButton_FileSelect.Appearance.Image = (int)Size16_Index.STAR1;

            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            // ���o���_
            tComboEditor_rl_RemainSectionType.SelectedIndex = RemainSectionType;
            // �^�M�c���o�̓`�F�b�N�{�b�N�X
            uCheckEditor_CreditMoneyOutputDiv.Checked = false;
            uCheckEditor_CreditMoneyOutputDiv.Font = uLabel_BalanceDiv.Font;
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

            tComboEditor_BalanceDiv.Value = balanceDiv;

            _excelFlg = excelFlg;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            if (prevTotalMonth != DateTime.MinValue)
            {
                tDateEdit_CheckDateSt.SetDateTime(prevTotalMonth);
                tDateEdit_CheckDateEd.SetDateTime(prevTotalMonth);
            }
            else
            {
                tDateEdit_CheckDateSt.SetDateTime(DateTime.Now);
                tDateEdit_CheckDateEd.SetDateTime(DateTime.Now);
            }

            ChangeFileName();
        }
        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�����o
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        PrevInputValue _prevInputValue = new PrevInputValue();
        // **** �{�^���p�C���[�W���X�g ****
        private ImageList _imageList16 = null;                  // �C���[�W���X�g

        private bool _excelFlg;
        //private List<int> _customerList = new List<int>(); // DEL 2010/09/26
        private List<CustomerInfo> _customerList = new List<CustomerInfo>(); // ADD 2010/09/26
        private CustPrtPprBlnce _custPrtPprBlnce = new CustPrtPprBlnce();
        private int _balanceDiv = 0;
        private string _fileName;
        private DialogResult _dialogResult = DialogResult.Cancel;
        //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        /// <summary>�J�n���_�R�[�h</summary>
        private string sectionCdSt;
        /// <summary>�I�����_�R�[�h</summary>
        private string sectionCdEd;
        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private string customerCdSt;
        /// <summary>�I�����Ӑ�R�[�h</summary>
        private string customerCdEd;
        /// <summary>�J�n�Ώ۔N��</summary>
        private string addUpYearMonthSt;
        /// <summary>�I���Ώ۔N��</summary>
        private string addUpYearMonthEd;
        //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
        #endregion // �v���C�x�[�g�����o

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

        #region �v���p�e�B
        // �Ώۓ��Ӑ惊�X�g
        //public List<int> CustomerList // DEL 2010/09/26
        public List<CustomerInfo> CustomerList // ADD 2010/09/26
        {
            get { return _customerList; }
            set { _customerList = value; }
        }

        // ���o����
        public CustPrtPprBlnce CustPrtPprBlnce
        {
            get { return _custPrtPprBlnce; }
            set { _custPrtPprBlnce = value; }
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
            get { return sectionCdSt; }
            set { sectionCdSt = value; }
        }

        /// <summary>�I�����_�R�[�h</summary>
        public string SectionCodeEd
        {
            get { return sectionCdEd; }
            set { sectionCdEd = value; }
        }

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        public string CustomerCodeSt
        {
            get { return customerCdSt; }
            set { customerCdSt = value; }
        }

        /// <summary>�I�����Ӑ�R�[�h</summary>
        public string CustomerCodeEd
        {
            get { return customerCdEd; }
            set { customerCdEd = value; }
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
        /// �J�n���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// �I�����Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �擾�������Ӑ�R�[�h(�J�n)����ʂɕ\������
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                int inputValue = this.tNedit_CustomerCode_St.GetInt();
                int code;
                ReadCustomerName(out code, inputValue, true);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
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
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �擾�������Ӑ�R�[�h(�I��)����ʂɕ\������
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                int inputValue = this.tNedit_CustomerCode_Ed.GetInt();
                int code;
                ReadCustomerName(out code, inputValue, false);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
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
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// �J�n���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                string code;
                ReadSectionCodeAllowZero(out code, inputValue, true);
            }
        }

        /// <summary>
        /// �I�����_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                string code;
                ReadSectionCodeAllowZero(out code, inputValue, false);
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2013/03/29 shijx </br>
        /// <br>            : 10800003-00�@2013/05/15�z�M�� Redmine#35205���Ӑ�d�q�����̑Ή�</br>
        /// <br>            : �@�t�H�[�J�X�����_�A���Ӑ�Ɏw�肵�Ă���ꍇ�Ashift+tab�����A�t�H�[�J�X���ړ��ł��܂���</br>
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
                        if (status == true)
                        {
                            this.tNedit_SectionCodeSt.Text = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text.Trim()))
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
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ----------<<<<<
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
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
                        if (status == true)
                        {
                            this.tNedit_SectionCodeEd.Text = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode_St;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ----------<<<<<
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tNedit_SectionCodeEd.Text = code;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // �J�n���Ӑ�R�[�h
                case "tNedit_CustomerCode_St":
                    {
                        int inputValue = this.tNedit_CustomerCode_St.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, true);
                        if (status == true)
                        {
                            this.tNedit_CustomerCode_St.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ----------<<<<<
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tNedit_CustomerCode_St.Text = code.ToString();
                            this.tNedit_CustomerCode_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // �I�����Ӑ�R�[�h
                case "tNedit_CustomerCode_Ed":
                    {
                        int inputValue = this.tNedit_CustomerCode_Ed.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, false);
                        if (status == true)
                        {
                            this.tNedit_CustomerCode_Ed.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_CheckDateSt;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205�@ ----------<<<<<
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tNedit_CustomerCode_Ed.Text = code.ToString();
                            this.tNedit_CustomerCode_Ed.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OK�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>              Redmine #15080 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2019/08/19 ���O</br>
        /// <br>           : 11570163-00 PMKOBETSU-1379 �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            #region ���̓`�F�b�N
            // ���_
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.SectionCodeSt))
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.SectionCodeSt = "00";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.SectionCodeEd))
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.SectionCodeEd = "00";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd))
            if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd)))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
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

            // ���Ӑ�
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.CustomerCodeSt))
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.CustomerCodeSt = "0";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.CustomerCodeEd))
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.CustomerCodeEd = "0";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd))
            if (Convert.ToInt32(_prevInputValue.CustomerCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd)))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�J�n���Ӑ�R�[�h�̒l���I�����Ӑ�R�[�h�̒l�������Ă��܂��B",
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
            //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
            // �J�n���_�R�[�h
            this.sectionCdSt = this.tNedit_SectionCodeSt.Text;
            // �I�����_�R�[�h
            this.sectionCdEd = this.tNedit_SectionCodeEd.Text;
            // �J�n���Ӑ�R�[�h
            this.customerCdSt = this.tNedit_CustomerCode_St.Text;
            // �I�����Ӑ�R�[�h
            this.customerCdEd = this.tNedit_CustomerCode_Ed.Text;
            // �J�n�Ώ۔N��
            this.addUpYearMonthSt = this.tDateEdit_CheckDateSt.GetDateYear().ToString() + this.tDateEdit_CheckDateSt.GetDateMonth().ToString("00");
            // �I���Ώ۔N��
            this.addUpYearMonthEd = this.tDateEdit_CheckDateEd.GetDateYear().ToString() + this.tDateEdit_CheckDateEd.GetDateMonth().ToString("00");
            //----- ADD 2019/08/19 ���O �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
            SetCustPrtPprBlnce();

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_BalanceDiv_ValueChanged(object sender, EventArgs e)
        {
            ChangeFileName();

            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            // �^�M�c���̏o�̓`�F�b�N�{�b�N�X
            // �����̎�
            if (Convert.ToInt32(tComboEditor_BalanceDiv.Value) == 0)
            {
                uCheckEditor_CreditMoneyOutputDiv.Enabled = false;
            }
            // ���|�̎�
            else
            {
                uCheckEditor_CreditMoneyOutputDiv.Enabled = true;
            }
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2010/09/16 tianjw</br>
        /// <br>           �@��Q�� #14483�Ή�</br>
        /// <br>Update Note : 2013/03/29 zhaimm</br>
        /// <br>            : 10800003-00�@2013/05/15�z�M�� Redmine#35205���Ӑ�d�q�����̑Ή�</br>
        /// <br>            : �B�o�̓t�@�C������"\\"���L��ꍇ�A�K�C�h�����A�G���[����</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                //this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim(); // DEL 2013/03/29 zhaimm Redmine#35205�B
                //----- ADD 2013/03/29 zhaimm Redmine#35205�B ---------->>>>>
                try
                {
                    FileInfo objFileInfo = new FileInfo(this.tEdit_SettingFileName.Text.Trim());
                    this.openFileDialog.FileName = objFileInfo.FullName;
                }
                catch (Exception)
                {
                    this.openFileDialog.FileName = string.Empty;
                }
                //----- ADD 2013/03/29 zhaimm Redmine#35205�B ----------<<<<<
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // ------------- ADD 2010/09/16 ------------------------>>>>>
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excel�t�@�C��(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("�e�L�X�g�t�@�C��(*.CSV) | *.CSV");
            }
            // ------------- ADD 2010/09/16 ------------------------<<<<<
            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // �C�x���g

        #region �v���C�x�[�g�����o
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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
            if ( sectionCode == "00" )
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
            else if ( !String.IsNullOrEmpty( sectionCode.Trim() ) )
            {
                // ���_�����擾
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/29
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/29
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
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool ReadCustomerName(out int code,int inputValue, bool stFlg)
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
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer) // DEL 2010/09/29
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer && customerInfo.LogicalDeleteCode ==0) // ADD 2010/09/29
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
        /// �O��l�ێ�
        /// </summary>
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
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>              Redmine #15080 �e�L�X�g�o�͑Ή�</br>
        private void SetCustPrtPprBlnce()
        {
            // �Ώۋ��_�R�[�h
            string[] sectionCode;
            //List<int> customerList = new List<int>(); // DEL 2010/09/26
            List<CustomerInfo> customerList = new List<CustomerInfo>(); // ADD 2010/09/26
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            // �����^�C�v
            this._custPrtPprBlnce.RemainSectionType = Convert.ToInt32(tComboEditor_rl_RemainSectionType.SelectedItem.DataValue.ToString());
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

            if (_prevInputValue.SectionCodeSt == _prevInputValue.SectionCodeEd)
            {
                if (_prevInputValue.SectionCodeSt == "00")
                {
                    sectionCode = null; // �S�Ўw��
                }
                else
                {
                    sectionCode = new string[] { _prevInputValue.SectionCodeSt };
                }
                this._custPrtPprBlnce.SectionCode = sectionCode;
            }
            else
            {
                int i = Convert.ToInt32(_prevInputValue.SectionCodeSt);
                int addCnt = 0;
                string code;
                ArrayList relList;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = 0;
                if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0)
                {
                    sectionCode = new string[Convert.ToInt32(_prevInputValue.SectionCodeEd) - Convert.ToInt32(_prevInputValue.SectionCodeSt) + 1];
                    for (; i <= Convert.ToInt32(_prevInputValue.SectionCodeEd); i++)
                    {
                        code = i.ToString();
                        code = code.Trim().PadLeft(2, '0');
                        status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
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
                    this._custPrtPprBlnce.SectionCode = retSecCode;
                }
                else 
                {
                    status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sectionCode = new string[relList.Count];
                        foreach (SecInfoSet sectionCdInfo in relList)
                        {
                            if (Convert.ToInt32(_prevInputValue.SectionCodeSt) <= Convert.ToInt32(sectionCdInfo.SectionCode))
                            {
                                sectionCode[addCnt] = sectionCdInfo.SectionCode;
                                addCnt++;
                            }
                        }
                        string[] retSecCode = new string[addCnt];
                        for (i = 0; i < addCnt; i++)
                        {
                            retSecCode[i] = sectionCode[i];
                        }
                        this._custPrtPprBlnce.SectionCode = retSecCode;
                    }
                }
            }

            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            this._custPrtPprBlnce.CreditMoneyOutputDiv = false;
            // �^�M�c���o�͋敪���u�o�͂���v���̂�
            if (uCheckEditor_CreditMoneyOutputDiv.Enabled && uCheckEditor_CreditMoneyOutputDiv.Checked)
            {
                this._custPrtPprBlnce.CreditMoneyOutputDiv = true;
            }
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

            // �Ώۓ��t
            int dts = this.tDateEdit_CheckDateSt.GetLongDate();
            int dte = this.tDateEdit_CheckDateEd.GetLongDate();
            // DEL 2013/03/29 RedMine#35205�A�@---------------------------------------->>>>>
            //dts++;
            //dte++;
            // DEL 2013/03/29 RedMine#35205�A�@----------------------------------------<<<<<
            // ADD 2013/03/29 RedMine#35205�A�@---------------------------------------->>>>>
            dts = (dts / 100) * 100 + 1;
            dte = (dte / 100) * 100 + 1;
            // ADD 2013/03/29 RedMine#35205�A�@----------------------------------------<<<<<
            this.tDateEdit_CheckDateSt.SetLongDate(dts);
            this.tDateEdit_CheckDateEd.SetLongDate(dte);
            this._custPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime();
            this._custPrtPprBlnce.Ed_AddUpYearMonth = this.tDateEdit_CheckDateEd.GetDateTime();
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            this._custPrtPprBlnce.Input_St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime();
            // �^�M�c�����o�͂��鎞�͑Ώۓ��t�̊J�n����͔N���̑O������Ƃ���
            //if (this._custPrtPprBlnce.CreditMoneyOutputDiv)// DEL 2013/03/29 RedMine#35205�A
            if (this._custPrtPprBlnce.CreditMoneyOutputDiv && (this.tDateEdit_CheckDateSt.GetLongDate() / 100 > 101))// ADD 2013/03/29 RedMine#35205�A
            {
                this._custPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime().AddMonths(-1);
            }
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<


            // �Ώۓ��Ӑ�
            if (_prevInputValue.CustomerCodeSt == _prevInputValue.CustomerCodeEd)
            {
                if (_prevInputValue.CustomerCodeSt == "0" || string.IsNullOrEmpty(_prevInputValue.CustomerCodeSt))
                {
                    // --- DEL 2010/09/26 ---------->>>>>
                    // �S���Ӑ�擾
                    //CustomerSearchRet[] customerSearchRet;
                    //CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                    //CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                    //customerSearchPara.EnterpriseCode = _enterpriseCode;
                    //customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                    //foreach (CustomerSearchRet ret in customerSearchRet)
                    //{
                    //    customerList.Add(ret.CustomerCode);
                    //}
                    // --- DEL 2010/09/26 ----------<<<<<
                    // --- ADD 2010/09/26 ---------->>>>>
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    customerInfoAcs.Search(_enterpriseCode, false, false, out customerList);
                    // --- ADD 2010/09/26 ----------<<<<<
                }
                else
                {
                    // --- UPD 2010/09/26 ---------->>>>>
                    //customerList.Add(Convert.ToInt32(_prevInputValue.CustomerCodeSt));
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    CustomerInfo customer;
                    int readStatus = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _enterpriseCode, Convert.ToInt32(_prevInputValue.CustomerCodeSt), true, true, out customer);
                    if (readStatus == 0 && customer != null && customer.LogicalDeleteCode == 0)
                    {
                        customerList.Add(customer);
                    }
                    // --- UPD 2010/09/26 ----------<<<<<
                }
            }
            else
            {
                // --- DEL 2010/09/26 ---------->>>>>
                //CustomerSearchRet[] customerSearchRet;
                //CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                //CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                //customerSearchPara.EnterpriseCode = _enterpriseCode;
                //customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                //foreach (CustomerSearchRet ret in customerSearchRet)
                //{
                //    if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt) &&
                //        ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                //    {
                //        customerList.Add(ret.CustomerCode);
                //    }
                //}
                // --- DEL 2010/09/26 ----------<<<<<

                // --- ADD 2010/09/26 ---------->>>>>
                List<CustomerInfo> customerInfoList = null;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                customerInfoAcs.Search(_enterpriseCode, false, false, out customerInfoList);

                foreach (CustomerInfo ret in customerInfoList)
                {
                    // ------------------ UPD 2010/09/28 ------------------------------------>>>>>
                    // �J�n���͂��Ȃ��A�I�����͂���
                    if (_prevInputValue.CustomerCodeSt == "0" && _prevInputValue.CustomerCodeEd != "0")
                    {
                        if (ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                        {
                            customerList.Add(ret);
                        }
                    }
                    // �J�n���͂���A�I�����͂��Ȃ�
                    else if (_prevInputValue.CustomerCodeSt != "0" && _prevInputValue.CustomerCodeEd == "0")
                    {
                        if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt))
                        {
                            customerList.Add(ret);
                        }
                    }
                    // �J�n���͂���A�I�����͂���
                    else 
                    {
                        if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt) &&
                        ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                        {
                            customerList.Add(ret);
                        }
                    }
                    //if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt) &&
                    //    ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                    //{
                    //    customerList.Add(ret);
                    //}
                    // ------------------ UPD 2010/09/28 ------------------------------------<<<<<
                }
                // --- ADD 2010/09/26 ----------<<<<<
            }

            this.CustomerList = customerList;

            // �c�����
            this.BalanceDiv = Convert.ToInt32(this.tComboEditor_BalanceDiv.Value);

            // �o�͐�t�@�C����
            this.FileName = this.tEdit_SettingFileName.Text;

            // ��ƃR�[�h
            this._custPrtPprBlnce.EnterpriseCode = _enterpriseCode;
        }

        /// <summary>
        /// �o�̓t�@�C�����ύX����
        /// </summary>
        private void ChangeFileName()
        {
            PMKAU04004UA userSettingForm = new PMKAU04004UA();
            string fileName = string.Empty;
            string path = string.Empty;
            userSettingForm.Deserialize();
            if (Convert.ToInt32(tComboEditor_BalanceDiv.Value) == 0)
            {
                // ����
                fileName = userSettingForm.UserSetting.ClaimeFileName;
            }
            else
            {
                // ���|
                fileName = userSettingForm.UserSetting.ChargeFileName;
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
                    fileName += ".csv";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }
        #endregion // �v���C�x�[�g�����o
    }
}
