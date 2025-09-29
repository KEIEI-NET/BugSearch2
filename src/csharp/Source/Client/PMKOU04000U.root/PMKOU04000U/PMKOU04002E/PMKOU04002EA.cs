using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SuppPrtPpr
    /// <summary>
    ///                      �d����d�q������������(�c���E�`�[�E����)
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����d�q������������(�c���E�`�[�E����)�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SuppPrtPpr
    {
        /// <summary>�������</summary>
        /// <remarks>���������+1���Z�b�g</remarks>
        private Int64 _searchCnt;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�J�n�d����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_StockDate;

        /// <summary>�I���d����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_StockDate;

        /// <summary>�J�n���͓�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_InputDay;

        /// <summary>�I�����͓�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_InputDay;

        /// <summary>�d���`��</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}�@0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32[] _supplierFormal;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}�@10:�d��,20:�ԕi</remarks>
        private Int32[] _supplierSlipCd;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�d��SEQ/�x����</summary>
        /// <remarks>�x���`�[�ԍ�/�d���`�[�ԍ�</remarks>
        private Int32 _paymentSlipNo;

        /// <summary>�S����</summary>
        /// <remarks>�d���S���҃R�[�h</remarks>
        private string _stockAgentCode = "";

        /// <summary>���s��</summary>
        /// <remarks>�d�����͎҃R�[�h</remarks>
        private string _stockInputCode = "";

        /// <summary>�t�n�d����</summary>
        /// <remarks>�������@�@0:�S�� 1:�ʏ� 2:UOE����</remarks>
        private Int32 _wayToOrder;

        /// <summary>���l�P</summary>
        /// <remarks>�d���`�[���l1</remarks>
        private string _supplierSlipNote1 = "";

        /// <summary>���l�Q</summary>
        /// <remarks>�d���`�[���l2</remarks>
        private string _supplierSlipNote2 = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>�t�n�d���}�[�N�P</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        /// <remarks>�t�n�d���}�[�N�Q</remarks>
        private string _uoeRemark2 = "";

        /// <summary>�a�k�O���[�v</summary>
        /// <remarks>BL�O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>�a�k�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>�i��</summary>
        /// <remarks>���i����</remarks>
        private string _goodsName = "";

        /// <summary>�i��</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>�݌Ɏ��敪</summary>
        /// <remarks>�d���݌Ɏ�񂹋敪�@-1:�S�� 0:��� 1:�݌�</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _warehouseCode = "";

        /// <summary>�`�[�����敪</summary>
        /// <remarks>0:�S�� 1:�d���̂� 2:�x���̂�</remarks>
        private Int32 _searchType;

        /// <summary>�d���`�[�敪�i���ׁj[����]</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";


        /// public propaty name  :  SearchCnt
        /// <summary>��������v���p�e�B</summary>
        /// <value>���������+1���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SearchCnt
        {
            get { return _searchCnt; }
            set { _searchCnt = value; }
        }

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
        /// <value>(�z��)�@�S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  St_StockDate
        /// <summary>�J�n�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_StockDate
        {
            get { return _st_StockDate; }
            set { _st_StockDate = value; }
        }

        /// public propaty name  :  Ed_StockDate
        /// <summary>�I���d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_StockDate
        {
            get { return _ed_StockDate; }
            set { _ed_StockDate = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>�J�n���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>�I�����͓��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}�@0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}�@10:�d��,20:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>�d��SEQ/�x�����v���p�e�B</summary>
        /// <value>�x���`�[�ԍ�/�d���`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��SEQ/�x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�S���҃v���p�e�B</summary>
        /// <value>�d���S���҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>���s�҃v���p�e�B</summary>
        /// <value>�d�����͎҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>�t�n�d�����v���p�e�B</summary>
        /// <value>�������@�@0:�S�� 1:�ʏ� 2:UOE����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>���l�P�v���p�e�B</summary>
        /// <value>�d���`�[���l1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>���l�Q�v���p�e�B</summary>
        /// <value>�d���`�[���l2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>�t�n�d���}�[�N�P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// <value>�t�n�d���}�[�N�Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>�a�k�O���[�v�v���p�e�B</summary>
        /// <value>BL�O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�O���[�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>�a�k�R�[�h�v���p�e�B</summary>
        /// <value>BL���i�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
        /// <value>���i����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// <value>���i�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>���i���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�݌Ɏ��敪�v���p�e�B</summary>
        /// <value>�d���݌Ɏ�񂹋敪�@-1:�S�� 0:��� 1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q�ɃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  SearchType
        /// <summary>�`�[�����敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:�d���̂� 2:�x���̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj[����]�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
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

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }


        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)�R���X�g���N�^
        /// </summary>
        /// <returns>SuppPrtPpr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPpr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPpr()
        {
        }

        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)�R���X�g���N�^
        /// </summary>
        /// <param name="searchCnt">�������(���������+1���Z�b�g)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h((�z��)�@�S�Ўw���{""})</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="st_StockDate">�J�n�d����(YYYYMMDD)</param>
        /// <param name="ed_StockDate">�I���d����(YYYYMMDD)</param>
        /// <param name="st_InputDay">�J�n���͓�(YYYYMMDD)</param>
        /// <param name="ed_InputDay">�I�����͓�(YYYYMMDD)</param>
        /// <param name="supplierFormal">�d���`��((�z��)�@�S�w��̏ꍇ��{""}�@0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="supplierSlipCd">�d���`�[�敪((�z��)�@�S�w��̏ꍇ��{""}�@10:�d��,20:�ԕi)</param>
        /// <param name="partySaleSlipNum">�`�[�ԍ�(�����`�[�ԍ�)</param>
        /// <param name="paymentSlipNo">�d��SEQ/�x����(�x���`�[�ԍ�/�d���`�[�ԍ�)</param>
        /// <param name="stockAgentCode">�S����(�d���S���҃R�[�h)</param>
        /// <param name="stockInputCode">���s��(�d�����͎҃R�[�h)</param>
        /// <param name="wayToOrder">�t�n�d����(�������@�@0:�S�� 1:�ʏ� 2:UOE����)</param>
        /// <param name="supplierSlipNote1">���l�P(�d���`�[���l1)</param>
        /// <param name="supplierSlipNote2">���l�Q(�d���`�[���l2)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P(�t�n�d���}�[�N�P)</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q(�t�n�d���}�[�N�Q)</param>
        /// <param name="bLGroupCode">�a�k�O���[�v(BL�O���[�v�R�[�h)</param>
        /// <param name="bLGoodsCode">�a�k�R�[�h(BL���i�R�[�h)</param>
        /// <param name="goodsName">�i��(���i����)</param>
        /// <param name="goodsNo">�i��(���i�ԍ�)</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h(���i���[�J�[�R�[�h)</param>
        /// <param name="stockOrderDivCd">�݌Ɏ��敪(�d���݌Ɏ�񂹋敪�@-1:�S�� 0:��� 1:�݌�)</param>
        /// <param name="warehouseCode">�q�ɃR�[�h(�q�ɃR�[�h)</param>
        /// <param name="searchType">�`�[�����敪(0:�S�� 1:�d���̂� 2:�x���̂�)</param>
        /// <param name="stockSlipCdDtl">�d���`�[�敪�i���ׁj[����](0:�d��,1:�ԕi,2:�l��)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="stockAgentName">�d���S���Җ���</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <returns>SuppPrtPpr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPpr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPpr( Int64 searchCnt, string enterpriseCode, string[] sectionCode, Int32 supplierCd, Int32 payeeCode, DateTime st_StockDate, DateTime ed_StockDate, DateTime st_InputDay, DateTime ed_InputDay, Int32[] supplierFormal, Int32[] supplierSlipCd, string partySaleSlipNum, Int32 paymentSlipNo, string stockAgentCode, string stockInputCode, Int32 wayToOrder, string supplierSlipNote1, string supplierSlipNote2, string uoeRemark1, string uoeRemark2, Int32 bLGroupCode, Int32 bLGoodsCode, string goodsName, string goodsNo, Int32 goodsMakerCd, Int32 stockOrderDivCd, string warehouseCode, Int32 searchType, Int32 stockSlipCdDtl, string enterpriseName, string stockAgentName, string bLGoodsName, string warehouseName )
        {
            this._searchCnt = searchCnt;
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            this._payeeCode = payeeCode;
            this._st_StockDate = st_StockDate;
            this._ed_StockDate = ed_StockDate;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._supplierFormal = supplierFormal;
            this._supplierSlipCd = supplierSlipCd;
            this._partySaleSlipNum = partySaleSlipNum;
            this._paymentSlipNo = paymentSlipNo;
            this._stockAgentCode = stockAgentCode;
            this._stockInputCode = stockInputCode;
            this._wayToOrder = wayToOrder;
            this._supplierSlipNote1 = supplierSlipNote1;
            this._supplierSlipNote2 = supplierSlipNote2;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsName = goodsName;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._stockOrderDivCd = stockOrderDivCd;
            this._warehouseCode = warehouseCode;
            this._searchType = searchType;
            this._stockSlipCdDtl = stockSlipCdDtl;
            this._enterpriseName = enterpriseName;
            this._stockAgentName = stockAgentName;
            this._bLGoodsName = bLGoodsName;
            this._warehouseName = warehouseName;

        }

        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)��������
        /// </summary>
        /// <returns>SuppPrtPpr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuppPrtPpr�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPpr Clone()
        {
            return new SuppPrtPpr( this._searchCnt, this._enterpriseCode, this._sectionCode, this._supplierCd, this._payeeCode, this._st_StockDate, this._ed_StockDate, this._st_InputDay, this._ed_InputDay, this._supplierFormal, this._supplierSlipCd, this._partySaleSlipNum, this._paymentSlipNo, this._stockAgentCode, this._stockInputCode, this._wayToOrder, this._supplierSlipNote1, this._supplierSlipNote2, this._uoeRemark1, this._uoeRemark2, this._bLGroupCode, this._bLGoodsCode, this._goodsName, this._goodsNo, this._goodsMakerCd, this._stockOrderDivCd, this._warehouseCode, this._searchType, this._stockSlipCdDtl, this._enterpriseName, this._stockAgentName, this._bLGoodsName, this._warehouseName );
        }

        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SuppPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPpr�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( SuppPrtPpr target )
        {
            return ((this.SearchCnt == target.SearchCnt)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.St_StockDate == target.St_StockDate)
                 && (this.Ed_StockDate == target.Ed_StockDate)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.SupplierSlipCd == target.SupplierSlipCd)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.PaymentSlipNo == target.PaymentSlipNo)
                 && (this.StockAgentCode == target.StockAgentCode)
                 && (this.StockInputCode == target.StockInputCode)
                 && (this.WayToOrder == target.WayToOrder)
                 && (this.SupplierSlipNote1 == target.SupplierSlipNote1)
                 && (this.SupplierSlipNote2 == target.SupplierSlipNote2)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.StockOrderDivCd == target.StockOrderDivCd)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.SearchType == target.SearchType)
                 && (this.StockSlipCdDtl == target.StockSlipCdDtl)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.StockAgentName == target.StockAgentName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.WarehouseName == target.WarehouseName));
        }

        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="suppPrtPpr1">
        ///                    ��r����SuppPrtPpr�N���X�̃C���X�^���X
        /// </param>
        /// <param name="suppPrtPpr2">��r����SuppPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPpr�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( SuppPrtPpr suppPrtPpr1, SuppPrtPpr suppPrtPpr2 )
        {
            return ((suppPrtPpr1.SearchCnt == suppPrtPpr2.SearchCnt)
                 && (suppPrtPpr1.EnterpriseCode == suppPrtPpr2.EnterpriseCode)
                 && (suppPrtPpr1.SectionCode == suppPrtPpr2.SectionCode)
                 && (suppPrtPpr1.SupplierCd == suppPrtPpr2.SupplierCd)
                 && (suppPrtPpr1.PayeeCode == suppPrtPpr2.PayeeCode)
                 && (suppPrtPpr1.St_StockDate == suppPrtPpr2.St_StockDate)
                 && (suppPrtPpr1.Ed_StockDate == suppPrtPpr2.Ed_StockDate)
                 && (suppPrtPpr1.St_InputDay == suppPrtPpr2.St_InputDay)
                 && (suppPrtPpr1.Ed_InputDay == suppPrtPpr2.Ed_InputDay)
                 && (suppPrtPpr1.SupplierFormal == suppPrtPpr2.SupplierFormal)
                 && (suppPrtPpr1.SupplierSlipCd == suppPrtPpr2.SupplierSlipCd)
                 && (suppPrtPpr1.PartySaleSlipNum == suppPrtPpr2.PartySaleSlipNum)
                 && (suppPrtPpr1.PaymentSlipNo == suppPrtPpr2.PaymentSlipNo)
                 && (suppPrtPpr1.StockAgentCode == suppPrtPpr2.StockAgentCode)
                 && (suppPrtPpr1.StockInputCode == suppPrtPpr2.StockInputCode)
                 && (suppPrtPpr1.WayToOrder == suppPrtPpr2.WayToOrder)
                 && (suppPrtPpr1.SupplierSlipNote1 == suppPrtPpr2.SupplierSlipNote1)
                 && (suppPrtPpr1.SupplierSlipNote2 == suppPrtPpr2.SupplierSlipNote2)
                 && (suppPrtPpr1.UoeRemark1 == suppPrtPpr2.UoeRemark1)
                 && (suppPrtPpr1.UoeRemark2 == suppPrtPpr2.UoeRemark2)
                 && (suppPrtPpr1.BLGroupCode == suppPrtPpr2.BLGroupCode)
                 && (suppPrtPpr1.BLGoodsCode == suppPrtPpr2.BLGoodsCode)
                 && (suppPrtPpr1.GoodsName == suppPrtPpr2.GoodsName)
                 && (suppPrtPpr1.GoodsNo == suppPrtPpr2.GoodsNo)
                 && (suppPrtPpr1.GoodsMakerCd == suppPrtPpr2.GoodsMakerCd)
                 && (suppPrtPpr1.StockOrderDivCd == suppPrtPpr2.StockOrderDivCd)
                 && (suppPrtPpr1.WarehouseCode == suppPrtPpr2.WarehouseCode)
                 && (suppPrtPpr1.SearchType == suppPrtPpr2.SearchType)
                 && (suppPrtPpr1.StockSlipCdDtl == suppPrtPpr2.StockSlipCdDtl)
                 && (suppPrtPpr1.EnterpriseName == suppPrtPpr2.EnterpriseName)
                 && (suppPrtPpr1.StockAgentName == suppPrtPpr2.StockAgentName)
                 && (suppPrtPpr1.BLGoodsName == suppPrtPpr2.BLGoodsName)
                 && (suppPrtPpr1.WarehouseName == suppPrtPpr2.WarehouseName));
        }
        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SuppPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPpr�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( SuppPrtPpr target )
        {
            ArrayList resList = new ArrayList();
            if ( this.SearchCnt != target.SearchCnt ) resList.Add( "SearchCnt" );
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.SupplierCd != target.SupplierCd ) resList.Add( "SupplierCd" );
            if ( this.PayeeCode != target.PayeeCode ) resList.Add( "PayeeCode" );
            if ( this.St_StockDate != target.St_StockDate ) resList.Add( "St_StockDate" );
            if ( this.Ed_StockDate != target.Ed_StockDate ) resList.Add( "Ed_StockDate" );
            if ( this.St_InputDay != target.St_InputDay ) resList.Add( "St_InputDay" );
            if ( this.Ed_InputDay != target.Ed_InputDay ) resList.Add( "Ed_InputDay" );
            if ( this.SupplierFormal != target.SupplierFormal ) resList.Add( "SupplierFormal" );
            if ( this.SupplierSlipCd != target.SupplierSlipCd ) resList.Add( "SupplierSlipCd" );
            if ( this.PartySaleSlipNum != target.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( this.PaymentSlipNo != target.PaymentSlipNo ) resList.Add( "PaymentSlipNo" );
            if ( this.StockAgentCode != target.StockAgentCode ) resList.Add( "StockAgentCode" );
            if ( this.StockInputCode != target.StockInputCode ) resList.Add( "StockInputCode" );
            if ( this.WayToOrder != target.WayToOrder ) resList.Add( "WayToOrder" );
            if ( this.SupplierSlipNote1 != target.SupplierSlipNote1 ) resList.Add( "SupplierSlipNote1" );
            if ( this.SupplierSlipNote2 != target.SupplierSlipNote2 ) resList.Add( "SupplierSlipNote2" );
            if ( this.UoeRemark1 != target.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( this.UoeRemark2 != target.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( this.BLGroupCode != target.BLGroupCode ) resList.Add( "BLGroupCode" );
            if ( this.BLGoodsCode != target.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( this.GoodsName != target.GoodsName ) resList.Add( "GoodsName" );
            if ( this.GoodsNo != target.GoodsNo ) resList.Add( "GoodsNo" );
            if ( this.GoodsMakerCd != target.GoodsMakerCd ) resList.Add( "GoodsMakerCd" );
            if ( this.StockOrderDivCd != target.StockOrderDivCd ) resList.Add( "StockOrderDivCd" );
            if ( this.WarehouseCode != target.WarehouseCode ) resList.Add( "WarehouseCode" );
            if ( this.SearchType != target.SearchType ) resList.Add( "SearchType" );
            if ( this.StockSlipCdDtl != target.StockSlipCdDtl ) resList.Add( "StockSlipCdDtl" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( this.StockAgentName != target.StockAgentName ) resList.Add( "StockAgentName" );
            if ( this.BLGoodsName != target.BLGoodsName ) resList.Add( "BLGoodsName" );
            if ( this.WarehouseName != target.WarehouseName ) resList.Add( "WarehouseName" );

            return resList;
        }

        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)��r����
        /// </summary>
        /// <param name="suppPrtPpr1">��r����SuppPrtPpr�N���X�̃C���X�^���X</param>
        /// <param name="suppPrtPpr2">��r����SuppPrtPpr�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPpr�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( SuppPrtPpr suppPrtPpr1, SuppPrtPpr suppPrtPpr2 )
        {
            ArrayList resList = new ArrayList();
            if ( suppPrtPpr1.SearchCnt != suppPrtPpr2.SearchCnt ) resList.Add( "SearchCnt" );
            if ( suppPrtPpr1.EnterpriseCode != suppPrtPpr2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( suppPrtPpr1.SectionCode != suppPrtPpr2.SectionCode ) resList.Add( "SectionCode" );
            if ( suppPrtPpr1.SupplierCd != suppPrtPpr2.SupplierCd ) resList.Add( "SupplierCd" );
            if ( suppPrtPpr1.PayeeCode != suppPrtPpr2.PayeeCode ) resList.Add( "PayeeCode" );
            if ( suppPrtPpr1.St_StockDate != suppPrtPpr2.St_StockDate ) resList.Add( "St_StockDate" );
            if ( suppPrtPpr1.Ed_StockDate != suppPrtPpr2.Ed_StockDate ) resList.Add( "Ed_StockDate" );
            if ( suppPrtPpr1.St_InputDay != suppPrtPpr2.St_InputDay ) resList.Add( "St_InputDay" );
            if ( suppPrtPpr1.Ed_InputDay != suppPrtPpr2.Ed_InputDay ) resList.Add( "Ed_InputDay" );
            if ( suppPrtPpr1.SupplierFormal != suppPrtPpr2.SupplierFormal ) resList.Add( "SupplierFormal" );
            if ( suppPrtPpr1.SupplierSlipCd != suppPrtPpr2.SupplierSlipCd ) resList.Add( "SupplierSlipCd" );
            if ( suppPrtPpr1.PartySaleSlipNum != suppPrtPpr2.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( suppPrtPpr1.PaymentSlipNo != suppPrtPpr2.PaymentSlipNo ) resList.Add( "PaymentSlipNo" );
            if ( suppPrtPpr1.StockAgentCode != suppPrtPpr2.StockAgentCode ) resList.Add( "StockAgentCode" );
            if ( suppPrtPpr1.StockInputCode != suppPrtPpr2.StockInputCode ) resList.Add( "StockInputCode" );
            if ( suppPrtPpr1.WayToOrder != suppPrtPpr2.WayToOrder ) resList.Add( "WayToOrder" );
            if ( suppPrtPpr1.SupplierSlipNote1 != suppPrtPpr2.SupplierSlipNote1 ) resList.Add( "SupplierSlipNote1" );
            if ( suppPrtPpr1.SupplierSlipNote2 != suppPrtPpr2.SupplierSlipNote2 ) resList.Add( "SupplierSlipNote2" );
            if ( suppPrtPpr1.UoeRemark1 != suppPrtPpr2.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( suppPrtPpr1.UoeRemark2 != suppPrtPpr2.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( suppPrtPpr1.BLGroupCode != suppPrtPpr2.BLGroupCode ) resList.Add( "BLGroupCode" );
            if ( suppPrtPpr1.BLGoodsCode != suppPrtPpr2.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( suppPrtPpr1.GoodsName != suppPrtPpr2.GoodsName ) resList.Add( "GoodsName" );
            if ( suppPrtPpr1.GoodsNo != suppPrtPpr2.GoodsNo ) resList.Add( "GoodsNo" );
            if ( suppPrtPpr1.GoodsMakerCd != suppPrtPpr2.GoodsMakerCd ) resList.Add( "GoodsMakerCd" );
            if ( suppPrtPpr1.StockOrderDivCd != suppPrtPpr2.StockOrderDivCd ) resList.Add( "StockOrderDivCd" );
            if ( suppPrtPpr1.WarehouseCode != suppPrtPpr2.WarehouseCode ) resList.Add( "WarehouseCode" );
            if ( suppPrtPpr1.SearchType != suppPrtPpr2.SearchType ) resList.Add( "SearchType" );
            if ( suppPrtPpr1.StockSlipCdDtl != suppPrtPpr2.StockSlipCdDtl ) resList.Add( "StockSlipCdDtl" );
            if ( suppPrtPpr1.EnterpriseName != suppPrtPpr2.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( suppPrtPpr1.StockAgentName != suppPrtPpr2.StockAgentName ) resList.Add( "StockAgentName" );
            if ( suppPrtPpr1.BLGoodsName != suppPrtPpr2.BLGoodsName ) resList.Add( "BLGoodsName" );
            if ( suppPrtPpr1.WarehouseName != suppPrtPpr2.WarehouseName ) resList.Add( "WarehouseName" );

            return resList;
        }
    }
}
