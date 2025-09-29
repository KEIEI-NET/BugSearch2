using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_PrevYearComparisonWork
    /// <summary>
    ///                      �O�N�Δ�\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �O�N�Δ�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_PrevYearComparisonWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private String[] _secCodeList;

        /// <summary>�W�v���@</summary>
        /// <remarks>0:�S�ЁA1:���_��</remarks>
        private Int32 _totalWay;

        /// <summary>���[�^�C�v</summary>
        /// <remarks>0:���Ӑ��,1:�S���ҕ�,2:�󒍎ҕ�,3:�n���,4:�Ǝ��,5:�O���[�v�R�[�h��,6:BL�R�[�h��</remarks>
        private Int32 _listType;

        /// <summary>���z�P��</summary>
        /// <remarks>0:�~,1:��~</remarks>
        private Int32 _moneyUnit;

        /// <summary>���s�^�C�v</summary>
        private Int32 _printType;

        /// <summary>�J�n�Ώ۔N��</summary>
        private Int32 _st_AddUpYearMonth;

        /// <summary>�I���Ώ۔N��</summary>
        private Int32 _ed_AddUpYearMonth;

        /// <summary>�O�N��(�J�n����������)</summary>
        private Double _st_MonthSalesRatio;

        /// <summary>�O�N��(�I������������)</summary>
        private Double _ed_MonthSalesRatio;

        /// <summary>�O�N��(�J�n���N�e��)</summary>
        private Double _st_YearSalesRatio;

        /// <summary>�O�N��(�I�����N�e��)</summary>
        private Double _ed_YearSalesRatio;

        /// <summary>�O�N��(�J�n�����e��)</summary>
        private Double _st_MonthGrossRatio;

        /// <summary>�O�N��(�I�������e��)</summary>
        private Double _ed_MonthGrossRatio;

        /// <summary>�O�N��(�J�n���N�e��)</summary>
        private Double _st_YearGrossRatio;

        /// <summary>�O�N��(�I�����N�e��)</summary>
        private Double _ed_YearGrossRatio;

        /// <summary>���Ӑ�R�[�h�J�n</summary>
        private Int32 _st_CustomerCode;

        /// <summary>���Ӑ�R�[�h�I��</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>�S���҃R�[�h�J�n</summary>
        /// <remarks>�󒍎҃R�[�h�����˂�</remarks>
        private string _st_EmployeeCode = "";

        /// <summary>�S���҃R�[�h�I��</summary>
        /// <remarks>�󒍎҃R�[�h�����˂�</remarks>
        private string _ed_EmployeeCode = "";

        /// <summary>BL�R�[�h�J�n</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>BL�R�[�h�I��</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>���i�啪�ރR�[�h�J�n</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>���i�啪�ރR�[�h�I��</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>���i�����ރR�[�h�J�n</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>���i�����ރR�[�h�I��</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>�O���[�v�R�[�h�J�n</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�O���[�v�R�[�h�I��</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>�n��R�[�h�J�n</summary>
        private Int32 _st_SalesAreaCode;

        /// <summary>�n��R�[�h�I��</summary>
        private Int32 _ed_SalesAreaCode;

        /// <summary>�Ǝ�R�[�h�J�n</summary>
        private Int32 _st_BusinessTypeCode;

        /// <summary>�Ǝ�R�[�h�I��</summary>
        private Int32 _ed_BusinessTypeCode;


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

        /// public propaty name  :  secCodeList
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>(�z��)�@�S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] secCodeList
        {
            get { return _secCodeList; }
            set { _secCodeList = value; }
        }

        /// public propaty name  :  TotalWay
        /// <summary>�W�v���@�v���p�e�B</summary>
        /// <value>0:�S�ЁA1:���_��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalWay
        {
            get { return _totalWay; }
            set { _totalWay = value; }
        }

        /// public propaty name  :  ListType
        /// <summary>���[�^�C�v�v���p�e�B</summary>
        /// <value>0:���Ӑ��,1:�S���ҕ�,2:�󒍎ҕ�,3:�n���,4:�Ǝ��,5:�O���[�v�R�[�h��,6:BL�R�[�h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListType
        {
            get { return _listType; }
            set { _listType = value; }
        }

        /// public propaty name  :  MoneyUnit
        /// <summary>���z�P�ʃv���p�e�B</summary>
        /// <value>0:�~,1:��~</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }

        /// public propaty name  :  printType
        /// <summary>���s�^�C�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 printType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>�I���Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
        }

        /// public propaty name  :  St_MonthSalesRatio
        /// <summary>�O�N��(�J�n����������)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n����������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_MonthSalesRatio
        {
            get { return _st_MonthSalesRatio; }
            set { _st_MonthSalesRatio = value; }
        }

        /// public propaty name  :  Ed_MonthSalesRatio
        /// <summary>�O�N��(�I������������)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I������������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Ed_MonthSalesRatio
        {
            get { return _ed_MonthSalesRatio; }
            set { _ed_MonthSalesRatio = value; }
        }

        /// public propaty name  :  St_YearSalesRatio
        /// <summary>�O�N��(�J�n���N�e��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n���N�e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_YearSalesRatio
        {
            get { return _st_YearSalesRatio; }
            set { _st_YearSalesRatio = value; }
        }

        /// public propaty name  :  Ed_YearSalesRatio
        /// <summary>�O�N��(�I�����N�e��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I�����N�e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Ed_YearSalesRatio
        {
            get { return _ed_YearSalesRatio; }
            set { _ed_YearSalesRatio = value; }
        }

        /// public propaty name  :  St_MonthGrossRatio
        /// <summary>�O�N��(�J�n�����e��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n�����e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_MonthGrossRatio
        {
            get { return _st_MonthGrossRatio; }
            set { _st_MonthGrossRatio = value; }
        }

        /// public propaty name  :  Ed_MonthGrossRatio
        /// <summary>�O�N��(�I�������e��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I�������e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Ed_MonthGrossRatio
        {
            get { return _ed_MonthGrossRatio; }
            set { _ed_MonthGrossRatio = value; }
        }

        /// public propaty name  :  St_YearGrossRatio
        /// <summary>�O�N��(�J�n���N�e��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n���N�e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_YearGrossRatio
        {
            get { return _st_YearGrossRatio; }
            set { _st_YearGrossRatio = value; }
        }

        /// public propaty name  :  Ed_YearGrossRatio
        /// <summary>�O�N��(�I�����N�e��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I�����N�e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Ed_YearGrossRatio
        {
            get { return _ed_YearGrossRatio; }
            set { _ed_YearGrossRatio = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>���Ӑ�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>���Ӑ�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>�S���҃R�[�h�J�n�v���p�e�B</summary>
        /// <value>�󒍎҃R�[�h�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>�S���҃R�[�h�I���v���p�e�B</summary>
        /// <value>�󒍎҃R�[�h�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>BL�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>BL�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>���i�����ރR�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>���i�����ރR�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�O���[�v�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�O���[�v�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_SalesAreaCode
        /// <summary>�n��R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n��R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesAreaCode
        {
            get { return _st_SalesAreaCode; }
            set { _st_SalesAreaCode = value; }
        }

        /// public propaty name  :  Ed_SalesAreaCode
        /// <summary>�n��R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n��R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SalesAreaCode
        {
            get { return _ed_SalesAreaCode; }
            set { _ed_SalesAreaCode = value; }
        }

        /// public propaty name  :  St_BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BusinessTypeCode
        {
            get { return _st_BusinessTypeCode; }
            set { _st_BusinessTypeCode = value; }
        }

        /// public propaty name  :  Ed_BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BusinessTypeCode
        {
            get { return _ed_BusinessTypeCode; }
            set { _ed_BusinessTypeCode = value; }
        }


        /// <summary>
        /// �O�N�Δ�\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_PrevYearComparisonWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_PrevYearComparisonWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_PrevYearComparisonWork()
        {
        }

    }
}
