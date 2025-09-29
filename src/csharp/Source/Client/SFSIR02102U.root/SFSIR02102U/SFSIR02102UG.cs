//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���`�[�ԍ�����
// �v���O�����T�v   : �x���`�[�ԍ����͂̌������s��
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
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �x���`�[�ԍ����͉��
    /// </summary>
    /// <remarks>
    /// <br>Note		: �x���`�[�ԍ����͉�ʂł��B</br>
    /// <br>Programmer	: ���N</br>
    /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
    /// <br>            : Redmine#33741�̑Ή�</br> 
    /// <br>Date		: 2012/12/24</br>
    /// <br></br>
    public partial class SFSIR02102UG : Form
    {   
        # region [Dispose]
        /// <summary>
        /// �x���`�[���͎x���`�[�ďo�K�C�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : �x���`�[���͎x���`�[�ďo�K�C�h�t�h�̋@�\���������܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ��@ : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33741�̑Ή�</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        public SFSIR02102UG(PaymentSlpSearch paymentSlpSearch, SearchPaySlpInfoParameter searchPaySlpInfoParameter)
        {
            InitializeComponent();
            this._paymentSlpSearchUG = paymentSlpSearch;
            this._searchPaySlpInfoParameterUG = searchPaySlpInfoParameter;
            this._supplierAcs = new SupplierAcs();
        }

        public int status
        {
            set { _status = value; }
            get { return _status; }
        }

        public bool flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        public Employee Employee
        {
            set { _employee = value; }
            get { return _employee; }
        }

        #endregion
       
        #region [Private Members]

        private int _status;

        private PaymentSlpSearch _paymentSlpSearchUG;

        private SearchPaySlpInfoParameter _searchPaySlpInfoParameterUG;

        private bool _flag;

        private SupplierAcs _supplierAcs;

        /// <summary>���O�C���S����</summary>
        private Employee _employee;

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        #endregion

        #region[Event]
        /// <summary>
        /// �`�[�ԍ����̓K�C�h�x���`�[�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ����̓K�C�h�A�`�[�`�[�ďo�t�h�̋@�\���������܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33741�̑Ή�</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void SFSIR02102UG_Load(object sender, EventArgs e)
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this._flag = false;
            this.tEdit1.DataText = "�x��";
            this.tNedit_SalesSlipNum.Focus();
            this.status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            this.Btn_SalesSlipGuide.ImageList = imageList16;
            this.Btn_SalesSlipGuide.Appearance.Image = Size16_Index.STAR1;
        }

        /// <summary>
        /// �m��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            //�x���`�[�ԍ�
            int PaymentSlipNo = this.tNedit_SalesSlipNum.GetInt();
            _searchPaySlpInfoParameterUG.PaymentSlipNo = PaymentSlipNo;
            if (checkData(PaymentSlipNo))
            {
                this._flag = true;
                status = this._paymentSlpSearchUG.SearchPaySlpInfoUG(_searchPaySlpInfoParameterUG, 31);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            DataTable dt = this._paymentSlpSearchUG.GetPaymentInfoDataTable();
                            int supplierCode = Convert.ToInt32(dt.Rows[0][PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].ToString().Trim());
                            Supplier supplier;
                            int statusScode = GetSupplier(out supplier, supplierCode);
                            if (statusScode != 0)
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  "�d����R�[�h�����݂��܂���B",
                                  0,
                                  MessageBoxButtons.OK);
                                this._paymentSlpSearchUG.ClearPaymentDataTable();
                                this.tNedit_SalesSlipNum.Clear();
                                this.tNedit_SalesSlipNum.Focus();
                                break;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                this._paymentSlpSearchUG.ErrorMessage,
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
                                          "�x���`�[�̓Ǎ������Ɏ��s���܂����B" + "\r\n" + this._paymentSlpSearchUG.ErrorMessage,
                                          status,
                                          MessageBoxButtons.OK);
                            break;
                        }
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  "�x���`�[�ԍ��������͂ł��B",
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
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
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
                    if (e.ShiftKey == false && e.Key == Keys.Enter)
                    {
                        if (this.tNedit_SalesSlipNum.GetInt() != 0)
                        {
                            this.uButton_Save_Click(uButton_Save, new EventArgs());
                            e.NextCtrl = this.tNedit_SalesSlipNum;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �x���`�[�K�C�h��ʂ�\������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �K�C�h���������ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void Btn_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            string sectionCode = this._employee.BelongSectionCode.TrimEnd();
            //���O�C�����_���̎��
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._searchPaySlpInfoParameterUG.EnterpriseCode, sectionCode);
            SFSIR02102UH sFSIR02102UH = new SFSIR02102UH();
            sFSIR02102UH.SearchPaySlpInfoParameter = this._searchPaySlpInfoParameterUG;
            sFSIR02102UH.PaymentSlpSearchUH = this._paymentSlpSearchUG;
            //���O�C�����_
            sFSIR02102UH.SectionCode = sectionCode;
            //���O�C�����_��
            sFSIR02102UH.SectionName = sectionInfo.SectionGuideNm;
            sFSIR02102UH.ShowDialog();
            if (sFSIR02102UH.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this._flag = true;
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion
   
        #region [Private Methord]
        /// <summary>
        /// �x���`�[���̓`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : �x���`�[���̓`�F�b�N����B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private bool checkData(int PaymentSlipNo)
        {
            if (PaymentSlipNo == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// �d��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������ɍs���B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ� �@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33741�̑Ή�</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private int GetSupplier(out Supplier supplier, int supplierCode)
        {
            int status = 0;
            supplier = new Supplier();

            try
            {
                string enterpriseCode = this._searchPaySlpInfoParameterUG.EnterpriseCode;
                status = this._supplierAcs.Read(out supplier, enterpriseCode, supplierCode);
                if ((status == 0) && (supplier.LogicalDeleteCode != 0))
                {
                    return 9;
                }
            }
            catch
            {
                status = -1;
                supplier = new Supplier();
            }

            return (status);
        }
        #endregion    
    }
}