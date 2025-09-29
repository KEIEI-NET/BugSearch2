using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesRsltListCndtnWork
    /// <summary>
    ///                      ������ѕ\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ������ѕ\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/16 �� ��</br>
    /// <br>�Ǘ��ԍ�         :   11070263-00</br>
    /// <br>                 :   �����Y�ƗlSeiken�i�ԕύX</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesRsltListCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>�W�v�P��</summary>
        /// <remarks>0:���i�� 1:���Ӑ�� 2:�S���ҕ� 3:�q�ɕ�</remarks>
        private Int32 _totalType;

        /// <summary>�W�v���@</summary>
        /// <remarks>0:�S�� 1:���_��</remarks>
        private Int32 _ttlType;

        /// <summary>�o�׎w��敪</summary>
        /// <remarks>0:����(����) 1:����</remarks>
        private Int32 _printRangeDiv;

        /// <summary>�݌Ɏ�񂹋敪</summary>
        /// <remarks>0:���v 1:�݌�, 2:���</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>�������</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _annualPrintDiv;

        /// <summary>���[�J�[�ʈ��</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _makerPrintDiv;

        // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
        /// <summary>�i�ԏW�v�敪</summary>
        /// <remarks>0:�ʁX 1:���Z</remarks>
        private Int32 _goodsNoSumDiv;

        /// <summary>�i�ԕ\���敪</summary>
        /// <remarks>0:�V�i�� 1:���i��</remarks>
        private Int32 _goodsNoDisDiv;
        // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<

        /// <summary>���גP��</summary>
        private Int32 _detail;

        /// <summary>���s�^�C�v</summary>
        /// <remarks>0:���_�ʑq�ɕ� 1:�q�ɕʓ��Ӑ�� 2:�q�ɕʋ��_��</remarks>
        private Int32 _printType;

        /// <summary>�J�n�Ώ۔N��(����)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthSt;

        /// <summary>�I���Ώ۔N��(����)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthEd;

        /// <summary>�J�n�Ώ۔N��(����)</summary>
        /// <remarks>YYYYMM(����)</remarks>
        private DateTime _annualAddUpYearMonthSt;

        /// <summary>�I���Ώ۔N��(����)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualAddUpYaerMonthEd;

        /// <summary>�J�n�Ώۊ���(����)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateSt;

        /// <summary>�I���Ώۊ���(����)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateEd;

        /// <summary>�J�n�Ώۊ���(����)</summary>
        /// <remarks>YYYYMMDD(����)</remarks>
        private DateTime _annualSalesDateSt;

        /// <summary>�I���Ώۊ���(����)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _annualSalesDateEd;

        /// <summary>�J�n����͈͎w��</summary>
        private Int32 _printRangeSt;

        /// <summary>�I������͈͎w��</summary>
        private Int32 _printRangeEd;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _customerCodeSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _customerCodeEd;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _supplierCodeSt;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _supplierCodeEd;

        /// <summary>�J�n�]�ƈ��R�[�h</summary>
        private string _employeeCodeSt = "";

        /// <summary>�I���]�ƈ��R�[�h</summary>
        private string _employeeCodeEd = "";

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _warehouseCodeSt = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _warehouseCodeEd = "";

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�J�n���i�啪�ރR�[�h</summary>
        private Int32 _goodsLGroupSt;

        /// <summary>�I�����i�啪�ރR�[�h</summary>
        private Int32 _goodsLGroupEd;

        /// <summary>�J�n���i�����ރR�[�h</summary>
        private Int32 _goodsMGroupSt;

        /// <summary>�I�����i�����ރR�[�h</summary>
        private Int32 _goodsMGroupEd;

        /// <summary>�J�nBL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>�I��BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n���i�ԍ�</summary>
        private string _goodsNoSt = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _goodsNoEd = "";


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
        /// <value>(�z��)�@�S�Ўw���{""}</value>
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

        /// public propaty name  :  TotalType
        /// <summary>�W�v�P�ʃv���p�e�B</summary>
        /// <value>0:���i�� 1:���Ӑ�� 2:�S���ҕ� 3:�q�ɕ�</value>
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

        /// public propaty name  :  TtlType
        /// <summary>�W�v���@�v���p�e�B</summary>
        /// <value>0:�S�� 1:���_��</value>
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

        /// public propaty name  :  PrintRangeDiv
        /// <summary>�o�׎w��敪�v���p�e�B</summary>
        /// <value>0:����(����) 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׎w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintRangeDiv
        {
            get { return _printRangeDiv; }
            set { _printRangeDiv = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>�݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:���v 1:�݌�, 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  AnnualPrintDiv
        /// <summary>��������v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnnualPrintDiv
        {
            get { return _annualPrintDiv; }
            set { _annualPrintDiv = value; }
        }

        /// public propaty name  :  MakerPrintDiv
        /// <summary>���[�J�[�ʈ���v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�ʈ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerPrintDiv
        {
            get { return _makerPrintDiv; }
            set { _makerPrintDiv = value; }
        }

        // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
        /// public propaty name  :  GoodsNoSumDiv
        /// <summary>�i�ԕ\���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �i�ԏW�v�敪�v���p�e�B</br>
        /// <br>Programer        :  ��������</br>
        /// </remarks>
        public Int32 GoodsNoSumDiv
        {
            get { return _goodsNoSumDiv; }
            set { _goodsNoSumDiv = value; }
        }

        /// public propaty name  :  GoodsNoDisDiv
        /// <summary>�i�ԑI���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �i�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :  ��������</br>
        /// </remarks>
        public Int32 GoodsNoDisDiv
        {
            get { return _goodsNoDisDiv; }
            set { _goodsNoDisDiv = value; }
        }
        // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<

        /// public propaty name  :  Detail
        /// <summary>���גP�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���גP�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>���s�^�C�v�v���p�e�B</summary>
        /// <value>0:���_�ʑq�ɕ� 1:�q�ɕʓ��Ӑ�� 2:�q�ɕʋ��_��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  AddUpYearMonthSt
        /// <summary>�J�n�Ώ۔N��(����)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώ۔N��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonthSt
        {
            get { return _addUpYearMonthSt; }
            set { _addUpYearMonthSt = value; }
        }

        /// public propaty name  :  AddUpYearMonthEd
        /// <summary>�I���Ώ۔N��(����)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώ۔N��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonthEd
        {
            get { return _addUpYearMonthEd; }
            set { _addUpYearMonthEd = value; }
        }

        /// public propaty name  :  AnnualAddUpYearMonthSt
        /// <summary>�J�n�Ώ۔N��(����)�v���p�e�B</summary>
        /// <value>YYYYMM(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώ۔N��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AnnualAddUpYearMonthSt
        {
            get { return _annualAddUpYearMonthSt; }
            set { _annualAddUpYearMonthSt = value; }
        }

        /// public propaty name  :  AnnualAddUpYaerMonthEd
        /// <summary>�I���Ώ۔N��(����)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώ۔N��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AnnualAddUpYaerMonthEd
        {
            get { return _annualAddUpYaerMonthEd; }
            set { _annualAddUpYaerMonthEd = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>�J�n�Ώۊ���(����)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۊ���(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>�I���Ώۊ���(����)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۊ���(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  AnnualSalesDateSt
        /// <summary>�J�n�Ώۊ���(����)�v���p�e�B</summary>
        /// <value>YYYYMMDD(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۊ���(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AnnualSalesDateSt
        {
            get { return _annualSalesDateSt; }
            set { _annualSalesDateSt = value; }
        }

        /// public propaty name  :  AnnualSalesDateEd
        /// <summary>�I���Ώۊ���(����)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۊ���(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AnnualSalesDateEd
        {
            get { return _annualSalesDateEd; }
            set { _annualSalesDateEd = value; }
        }

        /// public propaty name  :  PrintRangeSt
        /// <summary>�J�n����͈͎w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����͈͎w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintRangeSt
        {
            get { return _printRangeSt; }
            set { _printRangeSt = value; }
        }

        /// public propaty name  :  PrintRangeEd
        /// <summary>�I������͈͎w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������͈͎w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintRangeEd
        {
            get { return _printRangeEd; }
            set { _printRangeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  SupplierCodeSt
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { _supplierCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { _supplierCodeEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  WarehouseCodeSt
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  GoodsLGroupSt
        /// <summary>�J�n���i�啪�ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroupSt
        {
            get { return _goodsLGroupSt; }
            set { _goodsLGroupSt = value; }
        }

        /// public propaty name  :  GoodsLGroupEd
        /// <summary>�I�����i�啪�ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroupEd
        {
            get { return _goodsLGroupEd; }
            set { _goodsLGroupEd = value; }
        }

        /// public propaty name  :  GoodsMGroupSt
        /// <summary>�J�n���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroupSt
        {
            get { return _goodsMGroupSt; }
            set { _goodsMGroupSt = value; }
        }

        /// public propaty name  :  GoodsMGroupEd
        /// <summary>�I�����i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroupEd
        {
            get { return _goodsMGroupEd; }
            set { _goodsMGroupEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>�J�nBL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>�I��BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }


        /// <summary>
        /// ������ѕ\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesRsltListCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesRsltListCndtnWork()
        {
        }

    }
}
