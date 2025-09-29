//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �����`�[�ԍ�����
// �v���O�����T�v   : �����`�[�ԍ����͂̌������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2012/12/24  �C�����e : 2013/03/13�z�M�� Redmine#33741�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����`�[�ԍ����̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����`�[�ԍ��̓��͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : ���N</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#33741�̑Ή�</br>
    /// <br>Date       : 2012/12/24</br>
    /// <br></br>
    /// </remarks>
    public partial class SFUKK01403UD : Form
    {
        #region[Private Members]

        /// <summary>�����`�[���͉��(�����^)�A�N�Z�X�N���X</summary>
        private InputDepositNormalTypeAcs inputDepositNormalTypeAcsUD;

        private InputDepositNormalTypeAcs.SearchDepositParameter searchDepParameter;

        /// <summary>���Ӑ���N���X</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>������������</summary>
        private int _status;

        /// <summary>����</summary>
        private bool _flag;

        /// <summary>���O�C���S����</summary>
        private Employee _employee;

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        #endregion

        # region Dispose

        /// <summary>
        /// �����`�[���́i�����^�j�����`�[�ďo�K�C�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����`�[���́i�����^�j�����`�[�ďo�K�C�h�t�h�̋@�\���������܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        public SFUKK01403UD(InputDepositNormalTypeAcs.SearchDepositParameter searchDepositParameter, InputDepositNormalTypeAcs inputDepositNormalTypeAcs)
        {
            InitializeComponent();
            this.searchDepParameter = searchDepositParameter;
            this._customerInfoAcs = new CustomerInfoAcs();
            this.inputDepositNormalTypeAcsUD = inputDepositNormalTypeAcs;
        }

        /// <summary>
        /// ����status
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// ����status
        /// </summary>
        public bool flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// ���O�C���S����
        /// </summary>
        public Employee Employee
        {
            set { _employee = value; }
            get { return _employee; }
        }
        # endregion

        #region[Private Event]
        /// <summary>
        /// �m��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �m��{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                this.flag = true;
                string message;
                searchDepParameter.DepositSlipNo = this.tNedit_SalesSlipNum.GetInt();
                
                this.status = inputDepositNormalTypeAcsUD.SearchDepositOnlyMode(searchDepParameter, out message);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            CustomerInfo customerInfo;
                            DataTable dt = inputDepositNormalTypeAcsUD.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositDataTable];
                            //�`�[�̓��Ӑ�R�[�h
                            int customerCode = Convert.ToInt32(dt.Rows[0][InputDepositNormalTypeAcs.ctCustomerCode].ToString());
                            //���Ӑ���擾����
                            status = GetCustomerInfo(out customerInfo, customerCode);
                            if (status == 0)
                            {
                                // �[������̓`�F�b�N
                                if (customerInfo.IsCustomer != true)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�[����͓��͂ł��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                    inputDepositNormalTypeAcsUD.ClearDsDepositInfo();
                                    this.tNedit_SalesSlipNum.Clear();
                                    this.tNedit_SalesSlipNum.Focus();
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    break;
                                }
                                else
                                {
                                    int claimCode = customerInfo.ClaimCode;
                                    CustomerInfo claimInfo;
                                    status = GetCustomerInfo(out claimInfo, claimCode);
                                    if (claimInfo.IsCustomer != true)
                                    {
                                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�[����͓��͂ł��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                        inputDepositNormalTypeAcsUD.ClearDsDepositInfo();
                                        this.tNedit_SalesSlipNum.Clear();
                                        this.tNedit_SalesSlipNum.Focus();
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                        break;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���Ӑ�͑��݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                inputDepositNormalTypeAcsUD.ClearDsDepositInfo();
                                this.tNedit_SalesSlipNum.Clear();
                                this.tNedit_SalesSlipNum.Focus();
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                break;
                            } 
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            //�����`�[�����݂��Ȃ�������
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              message,
                                              0,
                                              MessageBoxButtons.OK);
                            this.tNedit_SalesSlipNum.Clear();
                            this.tNedit_SalesSlipNum.Focus();
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                          this.Name,
                                          "�����`�[�̓Ǎ������Ɏ��s���܂����B" + "\r\n\r\n" + message,
                                          status,
                                          MessageBoxButtons.OK);
                            return;
                        }
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                 this.Name,
                                                 "�����`�[�ԍ��������͂ł��B",
                                                 0,
                                                 MessageBoxButtons.OK);
                this.tNedit_SalesSlipNum.Focus();
            }
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ����{�^���N���b�N�C�x���g</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �L�[�R���g���[�� �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_SalesSlipNum":
                    {
                        if (this.tNedit_SalesSlipNum.GetInt() != 0)
                        {
                            if (e.ShiftKey == false && e.Key == Keys.Enter)
                            {
                                uButton_Save_Click(uButton_Save, new EventArgs());
                                if (this.status != 0)
                                {
                                    e.NextCtrl = this.tNedit_SalesSlipNum;
                                }
                                return;
                            }
                        }
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.Btn_SalesSlipGuide;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void SFUKK01403UD_Load(object sender, EventArgs e)
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.flag = false;
            this.status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this.tEdit1.Text = "����";
            this.tNedit_SalesSlipNum.Focus();
            this.Btn_SalesSlipGuide.ImageList = imageList16;
            this.Btn_SalesSlipGuide.Appearance.Image = Size16_Index.STAR1;
        }

        private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            string sectionCode = this._employee.BelongSectionCode.TrimEnd();
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this.searchDepParameter.EnterpriseCode, sectionCode);
            SFUKK01403UE sFUKK01403UE = new SFUKK01403UE();
            sFUKK01403UE.SearchDepositParameter = this.searchDepParameter;
            sFUKK01403UE.InputDepositNormalTypeAcsUE = this.inputDepositNormalTypeAcsUD;
            sFUKK01403UE.SectionCode = sectionInfo.SectionCode.TrimEnd();
            sFUKK01403UE.SectionName = sectionInfo.SectionGuideNm.Trim();
            sFUKK01403UE.ShowDialog();
            if (sFUKK01403UE.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
            }
        }
        #endregion

        #region[private methord]

        /// <summary>
        /// �����`�[�ԍ��̃`�F�b�N�B
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �����`�[�ԍ����`�F�b�N����B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private bool saveCheck()
        {
            if (this.tNedit_SalesSlipNum.GetInt() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ���Ӑ���擾����
        /// </summary>
        /// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h����Ώۂ̓��Ӑ�����擾���܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private int GetCustomerInfo(out CustomerInfo customerInfo, int customerCode)
        {
            string enterpriseCode = searchDepParameter.EnterpriseCode;
            customerInfo = new CustomerInfo();
            int status;
            try
            {
                status = this._customerInfoAcs.ReadDBData(enterpriseCode, customerCode, true, out customerInfo);
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }
            return (status);
        }
        #endregion
     
    }
}