using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppPrtPprWork
    /// <summary>
    ///                      �d����d�q������������(�c���E�`�[�E����)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����d�q������������(�c���E�`�[�E����)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprWork
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


        /// <summary>
        /// �d����d�q������������(�c���E�`�[�E����)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppPrtPprWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPprWork()
        {
        }
    }
}