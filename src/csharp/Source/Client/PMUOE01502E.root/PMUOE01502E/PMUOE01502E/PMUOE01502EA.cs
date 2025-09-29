//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��������
// �v���O�����T�v   : �����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2008/06/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpDisplay
    /// <summary>
    ///                      ��ʓ��̓N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��ʓ��̓N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/06/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpDisplay
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_��</summary>
        private string _sectionName = "";

        /// <summary>���͒S���҃R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>���͒S���Җ�</summary>
        private string _employeeName = "";

        /// <summary>�Ɩ��敪</summary>
        /// <remarks>1:���� 2:���� 3:�݌Ɋm�F 4:�������</remarks>
        private Int32 _businessCode;

        /// <summary>�[���ԍ��敪</summary>
        /// <remarks>0:���[�� 1:���[�� 2:�S�[��</remarks>
        private Int32 _cashRegisterNoDiv;

        /// <summary>�[���ԍ�</summary>
        /// <remarks>�[���ԍ�</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:�`������ 1:��������</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE�����ԍ��i�J�n�j</summary>
        private Int32 _uOESalesOrderNoSt;

        /// <summary>UOE�����ԍ��i�I���j</summary>
        private Int32 _uOESalesOrderNoEd;

        /// <summary>�J�n������t</summary>
        private DateTime _salesDateSt;

        /// <summary>�I��������t</summary>
        private DateTime _salesDateEd;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於</summary>
        private string _customerName = "";

        /// <summary>������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�Ɩ��敪����</summary>
        private string _businessName = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>���_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>���͒S���Җ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>�Ɩ��敪�v���p�e�B</summary>
        /// <value>1:���� 2:���� 3:�݌Ɋm�F 4:�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  CashRegisterNoDiv
        /// <summary>�[���ԍ��敪�v���p�e�B</summary>
        /// <value>0:���[�� 1:���[�� 2:�S�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���ԍ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNoDiv
        {
            get { return _cashRegisterNoDiv; }
            set { _cashRegisterNoDiv = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>�[���ԍ��v���p�e�B</summary>
        /// <value>�[���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:�`������ 1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  UOESalesOrderNoSt
        /// <summary>UOE�����ԍ��i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����ԍ��i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderNoSt
        {
            get { return _uOESalesOrderNoSt; }
            set { _uOESalesOrderNoSt = value; }
        }

        /// public propaty name  :  UOESalesOrderNoEd
        /// <summary>UOE�����ԍ��i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����ԍ��i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderNoEd
        {
            get { return _uOESalesOrderNoEd; }
            set { _uOESalesOrderNoEd = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>�J�n������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>�I��������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
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

        /// public propaty name  :  BusinessName
        /// <summary>�Ɩ��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }


        /// <summary>
        /// ��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay()
        {
        }

        /// <summary>
        /// ��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_��</param>
        /// <param name="employeeCode">���͒S���҃R�[�h</param>
        /// <param name="employeeName">���͒S���Җ�</param>
        /// <param name="businessCode">�Ɩ��敪(1:���� 2:���� 3:�݌Ɋm�F 4:�������)</param>
        /// <param name="cashRegisterNoDiv">�[���ԍ��敪(0:���[�� 1:���[�� 2:�S�[��)</param>
        /// <param name="cashRegisterNo">�[���ԍ�(�[���ԍ�)</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:�`������ 1:��������)</param>
        /// <param name="uOESalesOrderNoSt">UOE�����ԍ��i�J�n�j</param>
        /// <param name="uOESalesOrderNoEd">UOE�����ԍ��i�I���j</param>
        /// <param name="salesDateSt">�J�n������t</param>
        /// <param name="salesDateEd">�I��������t</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於</param>
        /// <param name="uOESupplierCd">������R�[�h</param>
        /// <param name="uOESupplierName">UOE�����於��</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="businessName">�Ɩ��敪����</param>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay(string enterpriseCode, string sectionCode, string sectionName, string employeeCode, string employeeName, Int32 businessCode, Int32 cashRegisterNoDiv, Int32 cashRegisterNo, Int32 systemDivCd, Int32 uOESalesOrderNoSt, Int32 uOESalesOrderNoEd, DateTime salesDateSt, DateTime salesDateEd, Int32 customerCode, string customerName, Int32 uOESupplierCd, string uOESupplierName, string enterpriseName, string businessName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._businessCode = businessCode;
            this._cashRegisterNoDiv = cashRegisterNoDiv;
            this._cashRegisterNo = cashRegisterNo;
            this._systemDivCd = systemDivCd;
            this._uOESalesOrderNoSt = uOESalesOrderNoSt;
            this._uOESalesOrderNoEd = uOESalesOrderNoEd;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._enterpriseName = enterpriseName;
            this._businessName = businessName;

        }

        /// <summary>
        /// ��ʓ��̓N���X��������
        /// </summary>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����InpDisplay�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay Clone()
        {
            return new InpDisplay(this._enterpriseCode, this._sectionCode, this._sectionName, this._employeeCode, this._employeeName, this._businessCode, this._cashRegisterNoDiv, this._cashRegisterNo, this._systemDivCd, this._uOESalesOrderNoSt, this._uOESalesOrderNoEd, this._salesDateSt, this._salesDateEd, this._customerCode, this._customerName, this._uOESupplierCd, this._uOESupplierName, this._enterpriseName, this._businessName);
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(InpDisplay target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.CashRegisterNoDiv == target.CashRegisterNoDiv)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.UOESalesOrderNoSt == target.UOESalesOrderNoSt)
                 && (this.UOESalesOrderNoEd == target.UOESalesOrderNoEd)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpDisplay1">
        ///                    ��r����InpDisplay�N���X�̃C���X�^���X
        /// </param>
        /// <param name="inpDisplay2">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            return ((inpDisplay1.EnterpriseCode == inpDisplay2.EnterpriseCode)
                 && (inpDisplay1.SectionCode == inpDisplay2.SectionCode)
                 && (inpDisplay1.SectionName == inpDisplay2.SectionName)
                 && (inpDisplay1.EmployeeCode == inpDisplay2.EmployeeCode)
                 && (inpDisplay1.EmployeeName == inpDisplay2.EmployeeName)
                 && (inpDisplay1.BusinessCode == inpDisplay2.BusinessCode)
                 && (inpDisplay1.CashRegisterNoDiv == inpDisplay2.CashRegisterNoDiv)
                 && (inpDisplay1.CashRegisterNo == inpDisplay2.CashRegisterNo)
                 && (inpDisplay1.SystemDivCd == inpDisplay2.SystemDivCd)
                 && (inpDisplay1.UOESalesOrderNoSt == inpDisplay2.UOESalesOrderNoSt)
                 && (inpDisplay1.UOESalesOrderNoEd == inpDisplay2.UOESalesOrderNoEd)
                 && (inpDisplay1.SalesDateSt == inpDisplay2.SalesDateSt)
                 && (inpDisplay1.SalesDateEd == inpDisplay2.SalesDateEd)
                 && (inpDisplay1.CustomerCode == inpDisplay2.CustomerCode)
                 && (inpDisplay1.CustomerName == inpDisplay2.CustomerName)
                 && (inpDisplay1.UOESupplierCd == inpDisplay2.UOESupplierCd)
                 && (inpDisplay1.UOESupplierName == inpDisplay2.UOESupplierName)
                 && (inpDisplay1.EnterpriseName == inpDisplay2.EnterpriseName)
                 && (inpDisplay1.BusinessName == inpDisplay2.BusinessName));
        }
        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(InpDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.CashRegisterNoDiv != target.CashRegisterNoDiv) resList.Add("CashRegisterNoDiv");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.UOESalesOrderNoSt != target.UOESalesOrderNoSt) resList.Add("UOESalesOrderNoSt");
            if (this.UOESalesOrderNoEd != target.UOESalesOrderNoEd) resList.Add("UOESalesOrderNoEd");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpDisplay1">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <param name="inpDisplay2">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpDisplay1.EnterpriseCode != inpDisplay2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (inpDisplay1.SectionCode != inpDisplay2.SectionCode) resList.Add("SectionCode");
            if (inpDisplay1.SectionName != inpDisplay2.SectionName) resList.Add("SectionName");
            if (inpDisplay1.EmployeeCode != inpDisplay2.EmployeeCode) resList.Add("EmployeeCode");
            if (inpDisplay1.EmployeeName != inpDisplay2.EmployeeName) resList.Add("EmployeeName");
            if (inpDisplay1.BusinessCode != inpDisplay2.BusinessCode) resList.Add("BusinessCode");
            if (inpDisplay1.CashRegisterNoDiv != inpDisplay2.CashRegisterNoDiv) resList.Add("CashRegisterNoDiv");
            if (inpDisplay1.CashRegisterNo != inpDisplay2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (inpDisplay1.SystemDivCd != inpDisplay2.SystemDivCd) resList.Add("SystemDivCd");
            if (inpDisplay1.UOESalesOrderNoSt != inpDisplay2.UOESalesOrderNoSt) resList.Add("UOESalesOrderNoSt");
            if (inpDisplay1.UOESalesOrderNoEd != inpDisplay2.UOESalesOrderNoEd) resList.Add("UOESalesOrderNoEd");
            if (inpDisplay1.SalesDateSt != inpDisplay2.SalesDateSt) resList.Add("SalesDateSt");
            if (inpDisplay1.SalesDateEd != inpDisplay2.SalesDateEd) resList.Add("SalesDateEd");
            if (inpDisplay1.CustomerCode != inpDisplay2.CustomerCode) resList.Add("CustomerCode");
            if (inpDisplay1.CustomerName != inpDisplay2.CustomerName) resList.Add("CustomerName");
            if (inpDisplay1.UOESupplierCd != inpDisplay2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (inpDisplay1.UOESupplierName != inpDisplay2.UOESupplierName) resList.Add("UOESupplierName");
            if (inpDisplay1.EnterpriseName != inpDisplay2.EnterpriseName) resList.Add("EnterpriseName");
            if (inpDisplay1.BusinessName != inpDisplay2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }

}
