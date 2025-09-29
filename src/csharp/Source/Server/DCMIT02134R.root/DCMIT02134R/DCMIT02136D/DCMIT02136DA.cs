using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMonthYearReportParamWork
    /// <summary>
    ///                      �d������N�񒊏o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d������N�񒊏o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMonthYearReportParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖ځ@�������Ǘ��敪��[0:���_]�̎��Ɏg�p</remarks>
        private string[] _sectionCodes;

        /// <summary>�����Ǘ��敪</summary>
        /// <remarks>0:���_�@1:���_�{���@2:���_�{���{��</remarks>
        private Int32 _sectionDiv;

        /// <summary>���_�R�[�h(�J�n)</summary>
        /// <remarks>�������Ǘ��敪��[1 �܂��� 2]�̎��Ɏg�p</remarks>
        private string _sectionCodeSt = "";

        /// <summary>���_�R�[�h(�I��)</summary>
        /// <remarks>�������Ǘ��敪��[1 �܂��� 2]�̎��Ɏg�p</remarks>
        private string _sectionCodeEd = "";

        /// <summary>����R�[�h(�J�n)</summary>
        /// <remarks>�������Ǘ��敪��[1 �܂��� 2]�̎��Ɏg�p</remarks>
        private Int32 _subSectionCodeSt;

        /// <summary>����R�[�h(�I��)</summary>
        /// <remarks>�������Ǘ��敪��[1 �܂��� 2]�̎��Ɏg�p</remarks>
        private Int32 _subSectionCodeEd;

        /// <summary>�ۃR�[�h(�J�n)</summary>
        /// <remarks>�������Ǘ��敪��[1 �܂��� 2]�̎��Ɏg�p</remarks>
        private Int32 _minSectionCodeSt;

        /// <summary>�ۃR�[�h(�I��)</summary>
        /// <remarks>�������Ǘ��敪��[1 �܂��� 2]�̎��Ɏg�p</remarks>
        private Int32 _minSectionCodeEd;

        /// <summary>�W�v���@</summary>
        /// <remarks>0:�S�� 1:�c�Ə���</remarks>
        private Int32 _ttlType;

        /// <summary>�d���N��(�J�n)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stockDateYmSt;

        /// <summary>�d���N��(�I��)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stockDateYmEd;

        /// <summary>�d�����N��(�J�n)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualStockDateYmSt;

        /// <summary>�d�����N��(�I��)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualStockDateYmEd;

        /// <summary>�d����R�[�h(�J�n)</summary>
        /// <remarks>���d����Ƃ��Ďg�p</remarks>
        private Int32 _supplierCdSt;

        /// <summary>�d����R�[�h(�I��)</summary>
        /// <remarks>���d����Ƃ��Ďg�p</remarks>
        private Int32 _supplierCdEd;

        /// <summary>�S���҃R�[�h(�J�n)</summary>
        /// <remarks>�����͎��͋󕶎�("")</remarks>
        private string _employeeCodeSt = "";

        /// <summary>�S���҃R�[�h(�I��)</summary>
        /// <remarks>�����͎��͋󕶎�("")</remarks>
        private string _employeeCodeEd = "";

        /// <summary>���[�J�[�R�[�h(�J�n)</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>���[�J�[�R�[�h(�I��)</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�W�v�P��</summary>
        /// <remarks>0:���_�� 1:�d����� 2:�S���ҕ� 3:������ 4:���[�J�[�� 5:�d����ʃ��[�J�[��</remarks>
        private Int32 _totalType;

        /// <summary>����^�C�v</summary>
        /// <remarks>0:���� 1:���� 2:����������</remarks>
        private Int32 _printType;


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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖ځ@�������Ǘ��敪��[0:���_]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SectionDiv
        /// <summary>�����Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���_ 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SectionDiv
        {
            get { return _sectionDiv; }
            set { _sectionDiv = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>���_�R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�������Ǘ��敪��[1:����]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>���_�R�[�h(�I��)�v���p�e�B</summary>
        /// <value>�������Ǘ��敪��[1:����]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>����R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�������Ǘ��敪��[1:����]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCodeSt
        {
            get { return _subSectionCodeSt; }
            set { _subSectionCodeSt = value; }
        }

        /// public propaty name  :  SubSectionCodeEd
        /// <summary>����R�[�h(�I��)�v���p�e�B</summary>
        /// <value>�������Ǘ��敪��[1:����]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCodeEd
        {
            get { return _subSectionCodeEd; }
            set { _subSectionCodeEd = value; }
        }

        /// public propaty name  :  MinSectionCodeSt
        /// <summary>�ۃR�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�������Ǘ��敪��[1:����]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۃR�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MinSectionCodeSt
        {
            get { return _minSectionCodeSt; }
            set { _minSectionCodeSt = value; }
        }

        /// public propaty name  :  MinSectionCodeEd
        /// <summary>�ۃR�[�h(�I��)�v���p�e�B</summary>
        /// <value>�������Ǘ��敪��[1:����]�̎��Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۃR�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MinSectionCodeEd
        {
            get { return _minSectionCodeEd; }
            set { _minSectionCodeEd = value; }
        }

        /// public propaty name  :  TtlType
        /// <summary>�W�v���@�v���p�e�B</summary>
        /// <value>0:�S�� 1:�c�Ə���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlType
        {
            get { return _ttlType; }
            set { _ttlType = value; }
        }

        /// public propaty name  :  StockDateYmSt
        /// <summary>�d���N��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���N��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDateYmSt
        {
            get { return _stockDateYmSt; }
            set { _stockDateYmSt = value; }
        }

        /// public propaty name  :  StockDateYmEd
        /// <summary>�d���N��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���N��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDateYmEd
        {
            get { return _stockDateYmEd; }
            set { _stockDateYmEd = value; }
        }

        /// public propaty name  :  AnnualStockDateYmSt
        /// <summary>�d�����N��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����N��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AnnualStockDateYmSt
        {
            get { return _annualStockDateYmSt; }
            set { _annualStockDateYmSt = value; }
        }

        /// public propaty name  :  AnnualStockDateYmEd
        /// <summary>�d�����N��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����N��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AnnualStockDateYmEd
        {
            get { return _annualStockDateYmEd; }
            set { _annualStockDateYmEd = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>���d����Ƃ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
        /// <value>���d����Ƃ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>�S���҃R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�����͎��͋󕶎�("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>�S���҃R�[�h(�I��)�v���p�e�B</summary>
        /// <value>�����͎��͋󕶎�("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>���[�J�[�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>���[�J�[�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  TotalType
        /// <summary>�W�v�P�ʃv���p�e�B</summary>
        /// <value>0:���_�� 1:�d����� 2:�S���ҕ� 3:������ 4:���[�J�[�� 5:�d����ʃ��[�J�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v�P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>����^�C�v�v���p�e�B</summary>
        /// <value>0:���� 1:���� 2:����������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }


        /// <summary>
        /// �d������N�񒊏o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMonthYearReportParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMonthYearReportParamWork()
        {
        }

    }
}
