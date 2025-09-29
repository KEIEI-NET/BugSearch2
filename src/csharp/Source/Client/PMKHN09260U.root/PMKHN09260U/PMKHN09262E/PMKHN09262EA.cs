using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustCreditCndtn
    /// <summary>
    ///                      �^�M�z�ݒ菈�����o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �^�M�z�ݒ菈�����o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustCreditCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���Ӑ�R�[�h�i�����w��j</summary>
        /// <remarks>�i�z��jnull�̏ꍇ�A�J�n�I���Ŕ���</remarks>
        private Int32[] _customerCodes;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _st_CustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�����敪</summary>
        /// <remarks>0:���ݔ��|�c���ݒ�,1:�^�M�z�N���A</remarks>
        private Int32 _procDiv;

        /// <summary>�^�M�z�t���O</summary>
        /// <remarks>True�ŏ���</remarks>
        private Boolean _creditMoneyFlg;

        /// <summary>�x���^�M�z�t���O</summary>
        /// <remarks>True�ŏ���</remarks>
        private Boolean _warningCrdMnyFrg;

        /// <summary>���ݔ��|�c���t���O</summary>
        /// <remarks>True�ŏ���</remarks>
        private Boolean _accRecDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  CustomerCodes
        /// <summary>���Ӑ�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i�z��jnull�̏ꍇ�A�J�n�I���Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] CustomerCodes
        {
            get { return _customerCodes; }
            set { _customerCodes = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:���ݔ��|�c���ݒ�,1:�^�M�z�N���A</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  CreditMoneyFlg
        /// <summary>�^�M�z�t���O�v���p�e�B</summary>
        /// <value>True�ŏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�z�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean CreditMoneyFlg
        {
            get { return _creditMoneyFlg; }
            set { _creditMoneyFlg = value; }
        }

        /// public propaty name  :  WarningCrdMnyFrg
        /// <summary>�x���^�M�z�t���O�v���p�e�B</summary>
        /// <value>True�ŏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���^�M�z�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean WarningCrdMnyFrg
        {
            get { return _warningCrdMnyFrg; }
            set { _warningCrdMnyFrg = value; }
        }

        /// public propaty name  :  AccRecDiv
        /// <summary>���ݔ��|�c���t���O�v���p�e�B</summary>
        /// <value>True�ŏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݔ��|�c���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean AccRecDiv
        {
            get { return _accRecDiv; }
            set { _accRecDiv = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>CustCreditCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustCreditCndtn()
        {
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="customerCodes">���Ӑ�R�[�h�i�����w��j(�i�z��jnull�̏ꍇ�A�J�n�I���Ŕ���)</param>
        /// <param name="st_CustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="ed_CustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="totalDay">����(DD)</param>
        /// <param name="procDiv">�����敪(0:���ݔ��|�c���ݒ�,1:�^�M�z�N���A)</param>
        /// <param name="creditMoneyFlg">�^�M�z�t���O(True�ŏ���)</param>
        /// <param name="warningCrdMnyFrg">�x���^�M�z�t���O(True�ŏ���)</param>
        /// <param name="accRecDiv">���ݔ��|�c���t���O(True�ŏ���)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>CustCreditCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustCreditCndtn(string enterpriseCode, Int32[] customerCodes, Int32 st_CustomerCode, Int32 ed_CustomerCode, Int32 totalDay, Int32 procDiv, Boolean creditMoneyFlg, Boolean warningCrdMnyFrg, Boolean accRecDiv, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCodes = customerCodes;
            this._st_CustomerCode = st_CustomerCode;
            this._ed_CustomerCode = ed_CustomerCode;
            this._totalDay = totalDay;
            this._procDiv = procDiv;
            this._creditMoneyFlg = creditMoneyFlg;
            this._warningCrdMnyFrg = warningCrdMnyFrg;
            this._accRecDiv = accRecDiv;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X��������
        /// </summary>
        /// <returns>CustCreditCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustCreditCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustCreditCndtn Clone()
        {
            return new CustCreditCndtn(this._enterpriseCode, this._customerCodes, this._st_CustomerCode, this._ed_CustomerCode, this._totalDay, this._procDiv, this._creditMoneyFlg, this._warningCrdMnyFrg, this._accRecDiv, this._enterpriseName);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustCreditCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustCreditCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.CustomerCodes == target.CustomerCodes)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.TotalDay == target.TotalDay)
                 && (this.ProcDiv == target.ProcDiv)
                 && (this.CreditMoneyFlg == target.CreditMoneyFlg)
                 && (this.WarningCrdMnyFrg == target.WarningCrdMnyFrg)
                 && (this.AccRecDiv == target.AccRecDiv)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X��r����
        /// </summary>
        /// <param name="custCreditCndtn1">
        ///                    ��r����CustCreditCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="custCreditCndtn2">��r����CustCreditCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustCreditCndtn custCreditCndtn1, CustCreditCndtn custCreditCndtn2)
        {
            return ((custCreditCndtn1.EnterpriseCode == custCreditCndtn2.EnterpriseCode)
                 && (custCreditCndtn1.CustomerCodes == custCreditCndtn2.CustomerCodes)
                 && (custCreditCndtn1.St_CustomerCode == custCreditCndtn2.St_CustomerCode)
                 && (custCreditCndtn1.Ed_CustomerCode == custCreditCndtn2.Ed_CustomerCode)
                 && (custCreditCndtn1.TotalDay == custCreditCndtn2.TotalDay)
                 && (custCreditCndtn1.ProcDiv == custCreditCndtn2.ProcDiv)
                 && (custCreditCndtn1.CreditMoneyFlg == custCreditCndtn2.CreditMoneyFlg)
                 && (custCreditCndtn1.WarningCrdMnyFrg == custCreditCndtn2.WarningCrdMnyFrg)
                 && (custCreditCndtn1.AccRecDiv == custCreditCndtn2.AccRecDiv)
                 && (custCreditCndtn1.EnterpriseName == custCreditCndtn2.EnterpriseName));
        }
        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustCreditCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustCreditCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.CustomerCodes != target.CustomerCodes) resList.Add("CustomerCodes");
            if (this.St_CustomerCode != target.St_CustomerCode) resList.Add("St_CustomerCode");
            if (this.Ed_CustomerCode != target.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.ProcDiv != target.ProcDiv) resList.Add("ProcDiv");
            if (this.CreditMoneyFlg != target.CreditMoneyFlg) resList.Add("CreditMoneyFlg");
            if (this.WarningCrdMnyFrg != target.WarningCrdMnyFrg) resList.Add("WarningCrdMnyFrg");
            if (this.AccRecDiv != target.AccRecDiv) resList.Add("AccRecDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�^�M�ݒ�)���o�����N���X��r����
        /// </summary>
        /// <param name="custCreditCndtn1">��r����CustCreditCndtn�N���X�̃C���X�^���X</param>
        /// <param name="custCreditCndtn2">��r����CustCreditCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustCreditCndtn custCreditCndtn1, CustCreditCndtn custCreditCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (custCreditCndtn1.EnterpriseCode != custCreditCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custCreditCndtn1.CustomerCodes != custCreditCndtn2.CustomerCodes) resList.Add("CustomerCodes");
            if (custCreditCndtn1.St_CustomerCode != custCreditCndtn2.St_CustomerCode) resList.Add("St_CustomerCode");
            if (custCreditCndtn1.Ed_CustomerCode != custCreditCndtn2.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (custCreditCndtn1.TotalDay != custCreditCndtn2.TotalDay) resList.Add("TotalDay");
            if (custCreditCndtn1.ProcDiv != custCreditCndtn2.ProcDiv) resList.Add("ProcDiv");
            if (custCreditCndtn1.CreditMoneyFlg != custCreditCndtn2.CreditMoneyFlg) resList.Add("CreditMoneyFlg");
            if (custCreditCndtn1.WarningCrdMnyFrg != custCreditCndtn2.WarningCrdMnyFrg) resList.Add("WarningCrdMnyFrg");
            if (custCreditCndtn1.AccRecDiv != custCreditCndtn2.AccRecDiv) resList.Add("AccRecDiv");
            if (custCreditCndtn1.EnterpriseName != custCreditCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
