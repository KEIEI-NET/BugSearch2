//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �F���Ӑ�R�[�h�ݒ�̈��p
// �v���O�����T�v   �F���Ӑ�R�[�h�ݒ�̈��p
// ---------------------------------------------------------------------//
//					Copyright(c) 2011 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.04  �C�����e : �V�K�쐬       
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�R�[�h���p�̃t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Node        :  ���Ӑ�R�[�h���p�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : ���C��</br>
    /// <br>Date        : 2011.08.04 </br>
    /// </remarks>
    public partial class PMPCC09010UB : Form
    {
        /// <summary>
        /// ���Ӑ�R�[�h���p�̃t�H�[���N���X
        /// </summary>
        /// <param name="pccCmpnyStTable">PCC���Аݒ�</param>
        /// <remarks>
        /// <br>Node        :  ���Ӑ�R�[�h���p�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        public PMPCC09010UB(Hashtable pccCmpnyStTable)
        {
            InitializeComponent();
            _customerInfoAcs = new CustomerInfoAcs();
            this.DialogResult = DialogResult.Cancel;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Save_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.DECISION];
            this.Cancel_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.UNDO];
            this._pccCmpnyStTable = pccCmpnyStTable;
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._pccInqCondition = string.Empty;
            InitCustomer();
            this.tNedit_CustomerCode.Focus();
        }
       
        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        private int _customCode;
        //�⍇������ƃR�[�h
        private string _inqOriginalEpCd = string.Empty;
        //�⍇�������_�R�[�h
        private string _inqOriginalSecCd = string.Empty;
        //�⍇��
        private string _pccInqCondition;
        //�O�⍇������ƃR�[�h
        private string _inqOriginalEpCdPre = string.Empty;
        //�O�⍇�������_�R�[�h
        private string _inqOriginalSecCdPre = string.Empty;
        private int _preCustomCode = 0;
        private CustomerInfoAcs _customerInfoAcs;
        private string _enterpriseCode;
        private string _sectionCode;
        /// <summary>
        /// PCC���Аݒ�
        /// </summary>
        private Hashtable _pccCmpnyStTable = null;
        // ���Ӑ�e�[�v��
        private Dictionary<int, PccCmpnySt> _customerHTable;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";
        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        public int CustomCode
        {
            get { return this._customCode; }
            set { this._customCode = value; }
        }

        /// <summary>
        /// ���Ӑ�
        /// </summary>
        public string PccInqCondition
        {
            get { return this._pccInqCondition; }
            set { this._pccInqCondition = value; }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.tNedit_CustomerCode.Focus();
            this.Close();
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �m��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {

            //�K�{���̓`�F�b�N
            int customerCode = this.tNedit_CustomerCode.GetInt();

            if (_pccCmpnyStTable == null || !_pccCmpnyStTable.ContainsKey(this._pccInqCondition))
            {
                //���C���ɖ߂�
                TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                           this.Name,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�}�X�^�ɖ��o�^���߈��p�ł��܂���B", 	// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                InitCustomer();
                this.tNedit_CustomerCode.Focus();
                return;
            }
            else
            {
                if (_pccCmpnyStTable[_pccInqCondition] != null)
                {
                    PccCmpnySt pccCmpnySt = _pccCmpnyStTable[_pccInqCondition] as PccCmpnySt;
                    if (pccCmpnySt.LogicalDeleteCode == 1)
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                           this.Name,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          //"���͂��ꂽ�R�[�h��PCC���Аݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                          "���͂��ꂽ�R�[�h��BL�߰µ��ް���Аݒ�}�X�^���͊��ɍ폜����Ă��܂��B", �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��

                        // PCC�i�ڐݒ�}�X�^�����e�R�[�h�̃N���A
                        InitCustomer();
                        this.tNedit_CustomerCode.Focus();
                        return;
                    }
                }
            }

            this._customCode = customerCode;
            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();
            this.DialogResult = DialogResult.OK;
            this.tNedit_CustomerCode.Focus();
            this.Close();
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }


            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }

            // ���Ӑ����UI�ɐݒ�
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
            this.tNedit_CustomerCode.Enabled = true;
            this.uButton_CustomerGuide.Enabled = true;
            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
            this._inqOriginalSecCd = customerInfo.CustomerSecCode;
            //�O�⍇������ƃR�[�h
            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
            //�O�⍇�������_�R�[�h
            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();
        }
        #endregion

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // PrevCtrl�ݒ�
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            // ���O�ɂ�蕪��
            switch (prevCtrl.Name)
            {
                #region ���Ӑ�R�[�h
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();

                        PccCmpnySt pccCmpnySt;
                        if (_customerHTable == null || !_customerHTable.ContainsKey(inputValue))
                        {
                            this.GetCustomerHTable();
                        }
                        if (_customerHTable != null && _customerHTable.Count > 0 && _customerHTable.ContainsKey(inputValue))
                        {
                            pccCmpnySt = _customerHTable[inputValue];
                            this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                            _preCustomCode = inputValue;
                            this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                            this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                            //�O�⍇������ƃR�[�h
                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                            //�O�⍇�������_�R�[�h
                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                                + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();

                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                //"PCC���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                                "BL�߰µ��ް���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",�@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
                                -1,
                                MessageBoxButtons.OK);
                            tNedit_CustomerCode.SetInt(_preCustomCode);
                            e.NextCtrl = e.PrevCtrl;
                        }

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_CustomerGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerGuide;
                                        }
                                        break;
                                    }
                            }

                        }

                        break;
                    }
                #endregion
                case "uButton_CustomerGuide":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = uButton_CustomerGuide;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʂ̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̃N���A���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void InitCustomer()
        {
            this.tNedit_CustomerCode.Clear();
            uLabel_CustomerName.Text = string.Empty;
            //�O�⍇������ƃR�[�h
            this._inqOriginalEpCdPre = string.Empty;
            //�O�⍇�������_�R�[�h
            this._inqOriginalSecCdPre = string.Empty;
            //�⍇������ƃR�[�h
            this._inqOriginalEpCd = string.Empty;
            //�⍇�������_�R�[�h
            this._inqOriginalSecCd = string.Empty;
            this._preCustomCode = 0;
            this._pccInqCondition = string.Empty;
        }

        #region ���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
        /// <summary>
        /// ���Аݒ�ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Аݒ蓾�Ӑ�ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void GetCustomerHTable()
        {
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._sectionCode;
            List<PccCmpnySt> pccCmpnyStList = null;
            if (this._customerHTable == null)
            {
                this._customerHTable = new Dictionary<int, PccCmpnySt>();
            }
            else
            {
                this._customerHTable.Clear();
            }
            PccCmpnySt pccCmpnySt0 = new PccCmpnySt();
            pccCmpnySt0.PccCompanyCode = 0;
            pccCmpnySt0.PccCompanyName = CUSTOMEMPTY_BASE;
            pccCmpnySt0.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt0.InqOtherSecCd = this._sectionCode;
            pccCmpnySt0.InqOriginalEpCd = string.Empty;
            pccCmpnySt0.InqOriginalSecCd = string.Empty;
            this._customerHTable.Add(pccCmpnySt0.PccCompanyCode, pccCmpnySt0);
            int status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    if (!this._customerHTable.ContainsKey(pccCmpnySt.PccCompanyCode))
                    {
                        this._customerHTable.Add(pccCmpnySt.PccCompanyCode, pccCmpnySt);
                    }
                }
            }

        }
        #endregion
    }
}