//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���Ӑ�R�[�h���p
// �v���O�����T�v   : ���Ӑ�R�[�h���p �t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/02/17  �C�����e : 2013/03/13�z�M�� SCM��Q��10276�Ή� 
//                                  SCM_DB�ɓo�^����ہASF���̊�ƃR�[�h�E���_�R�[�h�̎擾���𓾈Ӑ�}�X�^�ɕύX����       
// --------------------------------------------------------------------------//
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�R�[�h���p�̃t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Node        :  ���Ӑ�R�[�h���p�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : ���C��</br>
    /// <br>Date        : 2011.07.20</br>
    /// <br>Update Note : 2013/02/17 ����</br>
    /// <br>�Ǘ��ԍ�    : 2013/03/13�z�M��</br>
    /// <br>            : SCM��Q��10276�Ή� SCM_DB�ɓo�^����ہASF���̊�ƃR�[�h�E���_�R�[�h�̎擾���𓾈Ӑ�}�X�^�ɕύX����</br>  
    /// </remarks>
    public partial class PMPCC09040UD : Form
    {
        /// <summary>
        /// ���Ӑ�R�[�h���p�̃t�H�[���N���X
        /// </summary>
        /// <param name="pccItemGrpDict">PCC�i�ڃO���[�v�f�B�N�V���i���[</param>
        /// <remarks>
        /// <br>Node        :  ���Ӑ�R�[�h���p�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        public PMPCC09040UD(Dictionary<string, List<PccItemGrp>> pccItemGrpDict)
        {
            InitializeComponent();
            _customerInfoAcs = new CustomerInfoAcs();
            this.DialogResult = DialogResult.Cancel;
            ImageList imageList16 = IconResourceManagement.ImageList16;
             ImageList imageList24 = IconResourceManagement.ImageList24;
            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.UButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.Save_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.DECISION];
            
            this._pccItemGrpDict = pccItemGrpDict;
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._pccInqCondition = string.Empty;
            this.tNedit_CustomerCode.Focus();
            InitCustomer();
            GetCustomerHTable();
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
        // ���Ӑ�e�[�v��
        private Dictionary<int, PccCmpnySt> _customerHTable;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        /// <summary>
        /// PCC�i�ڃO���[�v�f�B�N�V���i���[
        /// </summary>
        private Dictionary<string, List<PccItemGrp>> _pccItemGrpDict = null;
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
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {

            //�K�{���̓`�F�b�N
            int customerCode = this.tNedit_CustomerCode.GetInt();

            if (_pccItemGrpDict == null || !_pccItemGrpDict.ContainsKey(this._pccInqCondition))
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
                if (_pccItemGrpDict[_pccInqCondition] != null && _pccItemGrpDict[_pccInqCondition].Count > 0)
                {
                    PccItemGrp pccItemGrp = _pccItemGrpDict[_pccInqCondition][0];
                    if (pccItemGrp.LogicalDeleteCode == 1)
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                           this.Name,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            //"���͂��ꂽ�R�[�h��PCC�i�ڐݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W�@�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                          "���͂��ꂽ�R�[�h��BL�߰µ��ް�i�ڐݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 	//ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
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
            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();//@@@@20230303
            this.DialogResult = DialogResult.OK;
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
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void UButton_CustomerGuide_Click(object sender, EventArgs e)
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
        /// <br>Date       : 2011.07.20</br>
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
            this.UButton_CustomerGuide.Enabled = true;
            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
            this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
            //�O�⍇������ƃR�[�h
            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
            //�O�⍇�������_�R�[�h
            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();//@@@@20230303
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
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: 2013/02/17 ����</br>
        /// <br>�Ǘ��ԍ�   : 2013/03/13�z�M��</br>
        /// <br>           : ���Ӑ���͂�����A���Ӑ���Č���������ǉ�����</br>  
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
                                // ----ADD 2013/02/17 ����--------->>>>>
                                CustomerInfo customerInfo;
                                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, _enterpriseCode, inputValue);
                                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || customerInfo == null) && inputValue != 0)
                                {
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                         "���Ӑ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",
                                        -1,
                                        MessageBoxButtons.OK);
                                    if (_preCustomCode == -1)
                                    {
                                        _preCustomCode = 0;
                                    }
                                    tNedit_CustomerCode.SetInt(_preCustomCode);
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // ----ADD 2013/02/17 ����---------<<<<<
                                this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                                _preCustomCode = inputValue;
                                //�O�⍇������ƃR�[�h
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //�O�⍇�������_�R�[�h
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                // ----DEL 2013/02/17 ����--------->>>>>
                                //this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd;
                                //this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                                // ----DEL 2013/02/17 ����---------<<<<<

                                // ----ADD 2013/02/17 ����--------->>>>>
                                if (customerInfo != null)
                                {
                                    //�⍇������ƃR�[�h
                                    this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                    //�⍇�������_�R�[�h
                                    this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                }
                                else
                                {
                                    //�⍇������ƃR�[�h
                                    this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                                    //�⍇�������_�R�[�h
                                    this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                                }
                                // ----ADD 2013/02/17 ����---------<<<<<

                                this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();//@@@@20230303
                                
                            }
                            else
                            {
                                // �G���[��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    //"PCC���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",  //DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                                    "BL�߰µ��ް���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@ 
                                    -1,
                                    MessageBoxButtons.OK);
                                if (_preCustomCode == -1)
                                {
                                    _preCustomCode = 0;
                                }
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
                                            e.NextCtrl = this.UButton_CustomerGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.UButton_CustomerGuide;
                                        }
                                        break;
                                    }
                            }

                        }

                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// ��ʂ̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̃N���A���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
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
            this._preCustomCode = -1;
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