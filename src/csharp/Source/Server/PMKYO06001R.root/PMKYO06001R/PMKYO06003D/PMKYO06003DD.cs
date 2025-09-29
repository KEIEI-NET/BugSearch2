using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MstSearchCountWorkWork
    /// <summary>
    ///                      �f�[�^�v�����[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �f�[�^�v�����[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/3/13</br>
    /// <br>Genarated Date   :   2009/05/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      : 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�         : 11770021-00</br>
    /// <br>                 : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MstSearchCountWorkWork
    {
        /// <summary>���_���ݒ�}�X�^</summary>
        private Int32 _secInfoSetCount;

        /// <summary>����}�X�^</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private Int32 _subSectionCount;

        /// <summary>�]�ƈ��}�X�^</summary>
        private Int32 _employeeCount;

        /// <summary>�]�ƈ��ڍ׃}�X�^</summary>
        private Int32 _employeeDtlCount;

        /// <summary>�q�Ƀ}�X�^</summary>
        private Int32 _warehouseCount;

        /// <summary>���Ӑ�}�X�^</summary>
        private Int32 _customerCount;

        /// <summary>���Ӑ�}�X�^(�ϓ����)</summary>
        private Int32 _customerChangeCount;

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// <summary>���Ӑ�}�X�^(�������)�f�[�^</summary>
        private Int32 _customerMemoCount;
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>���Ӑ�}�X�^�i�`�[�Ǘ��j</summary>
        private Int32 _custSlipMngCount;

        /// <summary>���Ӑ�}�X�^�i�|���O���[�v�j</summary>
        private Int32 _custRateGroupCount;

        /// <summary>���Ӑ�}�X�^(�`�[�ԍ�)</summary>
        private Int32 _custSlipNoSetCount;

        /// <summary>�d����}�X�^</summary>
        private Int32 _supplierCount;

        /// <summary>���[�J�[�}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _makerUCount;

        /// <summary>BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _bLGoodsCdUCount;

        /// <summary>���i�}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _goodsUCount;

        /// <summary>���i�}�X�^�i���[�U�[�o�^�j</summary>
        private Int32 _goodsPriceCount;

        /// <summary>���i�Ǘ����}�X�^</summary>
        private Int32 _goodsMngCount;

        /// <summary>�������i�}�X�^</summary>
        private Int32 _isolIslandPrcCount;

        /// <summary>�݌Ƀ}�X�^</summary>
        private Int32 _stockCount;

        /// <summary>���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j</summary>
        private Int32 _userGdAreaDivUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j</summary>
        private Int32 _userGdBusDivUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�Ǝ�j</summary>
        private Int32 _userGdCateUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�E��j</summary>
        private Int32 _userGdBusUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i���i�敪�j</summary>
        private Int32 _userGdGoodsDivUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j</summary>
        private Int32 _userGdCusGrouPUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i��s�j</summary>
        private Int32 _userGdBankUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i���i�敪�j</summary>
        private Int32 _userGdPriDivUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�[�i�敪�j</summary>
        private Int32 _userGdDeliDivUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i���i�啪�ށj</summary>
        private Int32 _userGdGoodsBigUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�̔��敪�j</summary>
        private Int32 _userGdBuyDivUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j</summary>
        private Int32 _userGdStockDivOUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j</summary>
        private Int32 _userGdStockDivTUCount;

        /// <summary>���[�U�[�K�C�h�}�X�^�i�ԕi���R�j</summary>
        private Int32 _userGdReturnReaUCount;

        /// <summary>�|���D��Ǘ��}�X�^</summary>
        private Int32 _rateProtyMngCount;

        /// <summary>�|���}�X�^</summary>
        private Int32 _rateCount;

        /// <summary>���i�Z�b�g�}�X�^</summary>
        private Int32 _goodsSetCount;

        /// <summary>���i��փ}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _partsSubstUCount;

        /// <summary>�]�ƈ��ʔ���ڕW�ݒ�}�X�^</summary>
        private Int32 _empSalesTargetCount;

        /// <summary>���Ӑ�ʔ���ڕW�ݒ�}�X�^</summary>
        private Int32 _custSalesTargetCount;

        /// <summary>���i�ʔ���ڕW�ݒ�}�X�^</summary>
        private Int32 _gcdSalesTargetCount;

        /// <summary>���i�����ރ}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _goodsMGroupUCount;

        /// <summary>BL�O���[�v�}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _bLGroupUCount;

        /// <summary>�����}�X�^�i���[�U�[�o�^���j</summary>
        private Int32 _joinPartsUCount;

        /// <summary>TBO�����}�X�^�i���[�U�[�o�^�j</summary>
        private Int32 _tBOSearchUCount;

        /// <summary>���ʃR�[�h�}�X�^�i���[�U�[�o�^�j</summary>
        private Int32 _partsPosCodeUCount;

        /// <summary>BL�R�[�h�K�C�h�}�X�^</summary>
        private Int32 _bLCodeGuideCount;

        /// <summary>�Ԏ햼�̃}�X�^</summary>
        private Int32 _modelNameUCount;

        /// <summary>�G���[�敪</summary>
        private Int32 _errorKubun;


        /// public propaty name  :  SecInfoSetCount
        /// <summary>���_���ݒ�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���ݒ�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecInfoSetCount
        {
            get { return _secInfoSetCount; }
            set { _secInfoSetCount = value; }
        }

        /// public propaty name  :  SubSectionCount
        /// <summary>����}�X�^�v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCount
        {
            get { return _subSectionCount; }
            set { _subSectionCount = value; }
        }

        /// public propaty name  :  EmployeeCount
        /// <summary>�]�ƈ��}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeCount
        {
            get { return _employeeCount; }
            set { _employeeCount = value; }
        }

        /// public propaty name  :  EmployeeDtlCount
        /// <summary>�]�ƈ��ڍ׃}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��ڍ׃}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeDtlCount
        {
            get { return _employeeDtlCount; }
            set { _employeeDtlCount = value; }
        }

        /// public propaty name  :  WarehouseCount
        /// <summary>�q�Ƀ}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�Ƀ}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseCount
        {
            get { return _warehouseCount; }
            set { _warehouseCount = value; }
        }

        /// public propaty name  :  CustomerCount
        /// <summary>���Ӑ�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCount
        {
            get { return _customerCount; }
            set { _customerCount = value; }
        }

        /// public propaty name  :  CustomerChangeCount
        /// <summary>���Ӑ�}�X�^(�ϓ����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�}�X�^(�ϓ����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerChangeCount
        {
            get { return _customerChangeCount; }
            set { _customerChangeCount = value; }
        }

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// public propaty name  :  CustomerMemoCount
        /// <summary>���Ӑ�}�X�^(�������)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�}�X�^(�������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerMemoCount
        {
            get { return _customerMemoCount; }
            set { _customerMemoCount = value; }
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// public propaty name  :  CustSlipMngCount
        /// <summary>���Ӑ�}�X�^�i�`�[�Ǘ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�}�X�^�i�`�[�Ǘ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipMngCount
        {
            get { return _custSlipMngCount; }
            set { _custSlipMngCount = value; }
        }

        /// public propaty name  :  CustRateGroupCount
        /// <summary>���Ӑ�}�X�^�i�|���O���[�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�}�X�^�i�|���O���[�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGroupCount
        {
            get { return _custRateGroupCount; }
            set { _custRateGroupCount = value; }
        }

        /// public propaty name  :  CustSlipNoSetCount
        /// <summary>���Ӑ�}�X�^(�`�[�ԍ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�}�X�^(�`�[�ԍ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNoSetCount
        {
            get { return _custSlipNoSetCount; }
            set { _custSlipNoSetCount = value; }
        }

        /// public propaty name  :  SupplierCount
        /// <summary>�d����}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCount
        {
            get { return _supplierCount; }
            set { _supplierCount = value; }
        }

        /// public propaty name  :  MakerUCount
        /// <summary>���[�J�[�}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerUCount
        {
            get { return _makerUCount; }
            set { _makerUCount = value; }
        }

        /// public propaty name  :  BLGoodsCdUCount
        /// <summary>BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCdUCount
        {
            get { return _bLGoodsCdUCount; }
            set { _bLGoodsCdUCount = value; }
        }

        /// public propaty name  :  GoodsUCount
        /// <summary>���i�}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsUCount
        {
            get { return _goodsUCount; }
            set { _goodsUCount = value; }
        }

        /// public propaty name  :  GoodsPriceCount
        /// <summary>���i�}�X�^�i���[�U�[�o�^�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�i���[�U�[�o�^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsPriceCount
        {
            get { return _goodsPriceCount; }
            set { _goodsPriceCount = value; }
        }

        /// public propaty name  :  GoodsMngCount
        /// <summary>���i�Ǘ����}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ����}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMngCount
        {
            get { return _goodsMngCount; }
            set { _goodsMngCount = value; }
        }

        /// public propaty name  :  IsolIslandPrcCount
        /// <summary>�������i�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IsolIslandPrcCount
        {
            get { return _isolIslandPrcCount; }
            set { _isolIslandPrcCount = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�݌Ƀ}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ƀ}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  UserGdAreaDivUCount
        /// <summary>���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdAreaDivUCount
        {
            get { return _userGdAreaDivUCount; }
            set { _userGdAreaDivUCount = value; }
        }

        /// public propaty name  :  UserGdBusDivUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdBusDivUCount
        {
            get { return _userGdBusDivUCount; }
            set { _userGdBusDivUCount = value; }
        }

        /// public propaty name  :  UserGdCateUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�Ǝ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�Ǝ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdCateUCount
        {
            get { return _userGdCateUCount; }
            set { _userGdCateUCount = value; }
        }

        /// public propaty name  :  UserGdBusUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�E��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�E��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdBusUCount
        {
            get { return _userGdBusUCount; }
            set { _userGdBusUCount = value; }
        }

        /// public propaty name  :  UserGdGoodsDivUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i���i�敪�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i���i�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdGoodsDivUCount
        {
            get { return _userGdGoodsDivUCount; }
            set { _userGdGoodsDivUCount = value; }
        }

        /// public propaty name  :  UserGdCusGrouPUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdCusGrouPUCount
        {
            get { return _userGdCusGrouPUCount; }
            set { _userGdCusGrouPUCount = value; }
        }

        /// public propaty name  :  UserGdBankUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i��s�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i��s�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdBankUCount
        {
            get { return _userGdBankUCount; }
            set { _userGdBankUCount = value; }
        }

        /// public propaty name  :  UserGdPriDivUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i���i�敪�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i���i�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdPriDivUCount
        {
            get { return _userGdPriDivUCount; }
            set { _userGdPriDivUCount = value; }
        }

        /// public propaty name  :  UserGdDeliDivUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�[�i�敪�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdDeliDivUCount
        {
            get { return _userGdDeliDivUCount; }
            set { _userGdDeliDivUCount = value; }
        }

        /// public propaty name  :  UserGdGoodsBigUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i���i�啪�ށj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdGoodsBigUCount
        {
            get { return _userGdGoodsBigUCount; }
            set { _userGdGoodsBigUCount = value; }
        }

        /// public propaty name  :  UserGdBuyDivUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�̔��敪�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�̔��敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdBuyDivUCount
        {
            get { return _userGdBuyDivUCount; }
            set { _userGdBuyDivUCount = value; }
        }

        /// public propaty name  :  UserGdStockDivOUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdStockDivOUCount
        {
            get { return _userGdStockDivOUCount; }
            set { _userGdStockDivOUCount = value; }
        }

        /// public propaty name  :  UserGdStockDivTUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdStockDivTUCount
        {
            get { return _userGdStockDivTUCount; }
            set { _userGdStockDivTUCount = value; }
        }

        /// public propaty name  :  UserGdReturnReaUCount
        /// <summary>���[�U�[�K�C�h�}�X�^�i�ԕi���R�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGdReturnReaUCount
        {
            get { return _userGdReturnReaUCount; }
            set { _userGdReturnReaUCount = value; }
        }

        /// public propaty name  :  RateProtyMngCount
        /// <summary>�|���D��Ǘ��}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���D��Ǘ��}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateProtyMngCount
        {
            get { return _rateProtyMngCount; }
            set { _rateProtyMngCount = value; }
        }

        /// public propaty name  :  RateCount
        /// <summary>�|���}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateCount
        {
            get { return _rateCount; }
            set { _rateCount = value; }
        }

        /// public propaty name  :  GoodsSetCount
        /// <summary>���i�Z�b�g�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Z�b�g�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsSetCount
        {
            get { return _goodsSetCount; }
            set { _goodsSetCount = value; }
        }

        /// public propaty name  :  PartsSubstUCount
        /// <summary>���i��փ}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i��փ}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsSubstUCount
        {
            get { return _partsSubstUCount; }
            set { _partsSubstUCount = value; }
        }

        /// public propaty name  :  EmpSalesTargetCount
        /// <summary>�]�ƈ��ʔ���ڕW�ݒ�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��ʔ���ڕW�ݒ�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmpSalesTargetCount
        {
            get { return _empSalesTargetCount; }
            set { _empSalesTargetCount = value; }
        }

        /// public propaty name  :  CustSalesTargetCount
        /// <summary>���Ӑ�ʔ���ڕW�ݒ�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�ʔ���ڕW�ݒ�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSalesTargetCount
        {
            get { return _custSalesTargetCount; }
            set { _custSalesTargetCount = value; }
        }

        /// public propaty name  :  GcdSalesTargetCount
        /// <summary>���i�ʔ���ڕW�ݒ�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ʔ���ڕW�ݒ�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GcdSalesTargetCount
        {
            get { return _gcdSalesTargetCount; }
            set { _gcdSalesTargetCount = value; }
        }

        /// public propaty name  :  GoodsMGroupUCount
        /// <summary>���i�����ރ}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރ}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroupUCount
        {
            get { return _goodsMGroupUCount; }
            set { _goodsMGroupUCount = value; }
        }

        /// public propaty name  :  BLGroupUCount
        /// <summary>BL�O���[�v�}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupUCount
        {
            get { return _bLGroupUCount; }
            set { _bLGroupUCount = value; }
        }

        /// public propaty name  :  JoinPartsUCount
        /// <summary>�����}�X�^�i���[�U�[�o�^���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����}�X�^�i���[�U�[�o�^���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinPartsUCount
        {
            get { return _joinPartsUCount; }
            set { _joinPartsUCount = value; }
        }

        /// public propaty name  :  TBOSearchUCount
        /// <summary>TBO�����}�X�^�i���[�U�[�o�^�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TBO�����}�X�^�i���[�U�[�o�^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TBOSearchUCount
        {
            get { return _tBOSearchUCount; }
            set { _tBOSearchUCount = value; }
        }

        /// public propaty name  :  PartsPosCodeUCount
        /// <summary>���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsPosCodeUCount
        {
            get { return _partsPosCodeUCount; }
            set { _partsPosCodeUCount = value; }
        }

        /// public propaty name  :  BLCodeGuideCount
        /// <summary>BL�R�[�h�K�C�h�}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�K�C�h�}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCodeGuideCount
        {
            get { return _bLCodeGuideCount; }
            set { _bLCodeGuideCount = value; }
        }

        /// public propaty name  :  ModelNameUCount
        /// <summary>�Ԏ햼�̃}�X�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�̃}�X�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelNameUCount
        {
            get { return _modelNameUCount; }
            set { _modelNameUCount = value; }
        }

        /// public propaty name  :  ErrorKubun
        /// <summary>�G���[�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorKubun
        {
            get { return _errorKubun; }
            set { _errorKubun = value; }
        }


        /// <summary>
        /// �f�[�^�v�����[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MstSearchCountWorkWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MstSearchCountWorkWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MstSearchCountWorkWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MstSearchCountWorkWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MstSearchCountWorkWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MstSearchCountWorkWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MstSearchCountWorkWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MstSearchCountWorkWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MstSearchCountWorkWork || graph is ArrayList || graph is MstSearchCountWorkWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MstSearchCountWorkWork).FullName));

            if (graph != null && graph is MstSearchCountWorkWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MstSearchCountWorkWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MstSearchCountWorkWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MstSearchCountWorkWork[])graph).Length;
            }
            else if (graph is MstSearchCountWorkWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_���ݒ�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //SecInfoSetCount
            //����}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCount
            //�]�ƈ��}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeCount
            //�]�ƈ��ڍ׃}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeDtlCount
            //�q�Ƀ}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseCount
            //���Ӑ�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCount
            //���Ӑ�}�X�^(�ϓ����)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerChangeCount
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            //���Ӑ�}�X�^(�������)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerMemoCount
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            //���Ӑ�}�X�^�i�`�[�Ǘ��j
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipMngCount
            //���Ӑ�}�X�^�i�|���O���[�v�j
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGroupCount
            //���Ӑ�}�X�^(�`�[�ԍ�)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNoSetCount
            //�d����}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCount
            //���[�J�[�}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerUCount
            //BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdUCount
            //���i�}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsUCount
            //���i�}�X�^�i���[�U�[�o�^�j
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsPriceCount
            //���i�Ǘ����}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMngCount
            //�������i�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //IsolIslandPrcCount
            //�݌Ƀ}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCount
            //���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdAreaDivUCount
            //���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBusDivUCount
            //���[�U�[�K�C�h�}�X�^�i�Ǝ�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdCateUCount
            //���[�U�[�K�C�h�}�X�^�i�E��j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBusUCount
            //���[�U�[�K�C�h�}�X�^�i���i�敪�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdGoodsDivUCount
            //���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdCusGrouPUCount
            //���[�U�[�K�C�h�}�X�^�i��s�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBankUCount
            //���[�U�[�K�C�h�}�X�^�i���i�敪�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdPriDivUCount
            //���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdDeliDivUCount
            //���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdGoodsBigUCount
            //���[�U�[�K�C�h�}�X�^�i�̔��敪�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBuyDivUCount
            //���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdStockDivOUCount
            //���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdStockDivTUCount
            //���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdReturnReaUCount
            //�|���D��Ǘ��}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //RateProtyMngCount
            //�|���}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //RateCount
            //���i�Z�b�g�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSetCount
            //���i��փ}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSubstUCount
            //�]�ƈ��ʔ���ڕW�ݒ�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //EmpSalesTargetCount
            //���Ӑ�ʔ���ڕW�ݒ�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSalesTargetCount
            //���i�ʔ���ڕW�ݒ�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //GcdSalesTargetCount
            //���i�����ރ}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroupUCount
            //BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupUCount
            //�����}�X�^�i���[�U�[�o�^���j
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinPartsUCount
            //TBO�����}�X�^�i���[�U�[�o�^�j
            serInfo.MemberInfo.Add(typeof(Int32)); //TBOSearchUCount
            //���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPosCodeUCount
            //BL�R�[�h�K�C�h�}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCodeGuideCount
            //�Ԏ햼�̃}�X�^
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelNameUCount
            //�G���[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorKubun


            serInfo.Serialize(writer, serInfo);
            if (graph is MstSearchCountWorkWork)
            {
                MstSearchCountWorkWork temp = (MstSearchCountWorkWork)graph;

                SetMstSearchCountWorkWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MstSearchCountWorkWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MstSearchCountWorkWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MstSearchCountWorkWork temp in lst)
                {
                    SetMstSearchCountWorkWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MstSearchCountWorkWork�����o��(public�v���p�e�B��)
        /// </summary>
        // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        //private const int currentMemberCount = 47;
        private const int currentMemberCount = 48;
        // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        ///  MstSearchCountWorkWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MstSearchCountWorkWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMstSearchCountWorkWork(System.IO.BinaryWriter writer, MstSearchCountWorkWork temp)
        {
            //���_���ݒ�}�X�^
            writer.Write(temp.SecInfoSetCount);
            //����}�X�^
            writer.Write(temp.SubSectionCount);
            //�]�ƈ��}�X�^
            writer.Write(temp.EmployeeCount);
            //�]�ƈ��ڍ׃}�X�^
            writer.Write(temp.EmployeeDtlCount);
            //�q�Ƀ}�X�^
            writer.Write(temp.WarehouseCount);
            //���Ӑ�}�X�^
            writer.Write(temp.CustomerCount);
            //���Ӑ�}�X�^(�ϓ����)
            writer.Write(temp.CustomerChangeCount);
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            //���Ӑ�}�X�^(�������)
            writer.Write(temp.CustomerMemoCount);
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            //���Ӑ�}�X�^�i�`�[�Ǘ��j
            writer.Write(temp.CustSlipMngCount);
            //���Ӑ�}�X�^�i�|���O���[�v�j
            writer.Write(temp.CustRateGroupCount);
            //���Ӑ�}�X�^(�`�[�ԍ�)
            writer.Write(temp.CustSlipNoSetCount);
            //�d����}�X�^
            writer.Write(temp.SupplierCount);
            //���[�J�[�}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.MakerUCount);
            //BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.BLGoodsCdUCount);
            //���i�}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.GoodsUCount);
            //���i�}�X�^�i���[�U�[�o�^�j
            writer.Write(temp.GoodsPriceCount);
            //���i�Ǘ����}�X�^
            writer.Write(temp.GoodsMngCount);
            //�������i�}�X�^
            writer.Write(temp.IsolIslandPrcCount);
            //�݌Ƀ}�X�^
            writer.Write(temp.StockCount);
            //���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
            writer.Write(temp.UserGdAreaDivUCount);
            //���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
            writer.Write(temp.UserGdBusDivUCount);
            //���[�U�[�K�C�h�}�X�^�i�Ǝ�j
            writer.Write(temp.UserGdCateUCount);
            //���[�U�[�K�C�h�}�X�^�i�E��j
            writer.Write(temp.UserGdBusUCount);
            //���[�U�[�K�C�h�}�X�^�i���i�敪�j
            writer.Write(temp.UserGdGoodsDivUCount);
            //���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
            writer.Write(temp.UserGdCusGrouPUCount);
            //���[�U�[�K�C�h�}�X�^�i��s�j
            writer.Write(temp.UserGdBankUCount);
            //���[�U�[�K�C�h�}�X�^�i���i�敪�j
            writer.Write(temp.UserGdPriDivUCount);
            //���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
            writer.Write(temp.UserGdDeliDivUCount);
            //���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
            writer.Write(temp.UserGdGoodsBigUCount);
            //���[�U�[�K�C�h�}�X�^�i�̔��敪�j
            writer.Write(temp.UserGdBuyDivUCount);
            //���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
            writer.Write(temp.UserGdStockDivOUCount);
            //���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
            writer.Write(temp.UserGdStockDivTUCount);
            //���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
            writer.Write(temp.UserGdReturnReaUCount);
            //�|���D��Ǘ��}�X�^
            writer.Write(temp.RateProtyMngCount);
            //�|���}�X�^
            writer.Write(temp.RateCount);
            //���i�Z�b�g�}�X�^
            writer.Write(temp.GoodsSetCount);
            //���i��փ}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.PartsSubstUCount);
            //�]�ƈ��ʔ���ڕW�ݒ�}�X�^
            writer.Write(temp.EmpSalesTargetCount);
            //���Ӑ�ʔ���ڕW�ݒ�}�X�^
            writer.Write(temp.CustSalesTargetCount);
            //���i�ʔ���ڕW�ݒ�}�X�^
            writer.Write(temp.GcdSalesTargetCount);
            //���i�����ރ}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.GoodsMGroupUCount);
            //BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.BLGroupUCount);
            //�����}�X�^�i���[�U�[�o�^���j
            writer.Write(temp.JoinPartsUCount);
            //TBO�����}�X�^�i���[�U�[�o�^�j
            writer.Write(temp.TBOSearchUCount);
            //���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            writer.Write(temp.PartsPosCodeUCount);
            //BL�R�[�h�K�C�h�}�X�^
            writer.Write(temp.BLCodeGuideCount);
            //�Ԏ햼�̃}�X�^
            writer.Write(temp.ModelNameUCount);
            //�G���[�敪
            writer.Write(temp.ErrorKubun);

        }

        /// <summary>
        ///  MstSearchCountWorkWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MstSearchCountWorkWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MstSearchCountWorkWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MstSearchCountWorkWork GetMstSearchCountWorkWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MstSearchCountWorkWork temp = new MstSearchCountWorkWork();

            //���_���ݒ�}�X�^
            temp.SecInfoSetCount = reader.ReadInt32();
            //����}�X�^
            temp.SubSectionCount = reader.ReadInt32();
            //�]�ƈ��}�X�^
            temp.EmployeeCount = reader.ReadInt32();
            //�]�ƈ��ڍ׃}�X�^
            temp.EmployeeDtlCount = reader.ReadInt32();
            //�q�Ƀ}�X�^
            temp.WarehouseCount = reader.ReadInt32();
            //���Ӑ�}�X�^
            temp.CustomerCount = reader.ReadInt32();
            //���Ӑ�}�X�^(�ϓ����)
            temp.CustomerChangeCount = reader.ReadInt32();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            //���Ӑ�}�X�^(�������)
            temp.CustomerMemoCount = reader.ReadInt32();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            //���Ӑ�}�X�^�i�`�[�Ǘ��j
            temp.CustSlipMngCount = reader.ReadInt32();
            //���Ӑ�}�X�^�i�|���O���[�v�j
            temp.CustRateGroupCount = reader.ReadInt32();
            //���Ӑ�}�X�^(�`�[�ԍ�)
            temp.CustSlipNoSetCount = reader.ReadInt32();
            //�d����}�X�^
            temp.SupplierCount = reader.ReadInt32();
            //���[�J�[�}�X�^�i���[�U�[�o�^���j
            temp.MakerUCount = reader.ReadInt32();
            //BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            temp.BLGoodsCdUCount = reader.ReadInt32();
            //���i�}�X�^�i���[�U�[�o�^���j
            temp.GoodsUCount = reader.ReadInt32();
            //���i�}�X�^�i���[�U�[�o�^�j
            temp.GoodsPriceCount = reader.ReadInt32();
            //���i�Ǘ����}�X�^
            temp.GoodsMngCount = reader.ReadInt32();
            //�������i�}�X�^
            temp.IsolIslandPrcCount = reader.ReadInt32();
            //�݌Ƀ}�X�^
            temp.StockCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
            temp.UserGdAreaDivUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
            temp.UserGdBusDivUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�Ǝ�j
            temp.UserGdCateUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�E��j
            temp.UserGdBusUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i���i�敪�j
            temp.UserGdGoodsDivUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
            temp.UserGdCusGrouPUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i��s�j
            temp.UserGdBankUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i���i�敪�j
            temp.UserGdPriDivUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
            temp.UserGdDeliDivUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
            temp.UserGdGoodsBigUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�̔��敪�j
            temp.UserGdBuyDivUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
            temp.UserGdStockDivOUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
            temp.UserGdStockDivTUCount = reader.ReadInt32();
            //���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
            temp.UserGdReturnReaUCount = reader.ReadInt32();
            //�|���D��Ǘ��}�X�^
            temp.RateProtyMngCount = reader.ReadInt32();
            //�|���}�X�^
            temp.RateCount = reader.ReadInt32();
            //���i�Z�b�g�}�X�^
            temp.GoodsSetCount = reader.ReadInt32();
            //���i��փ}�X�^�i���[�U�[�o�^���j
            temp.PartsSubstUCount = reader.ReadInt32();
            //�]�ƈ��ʔ���ڕW�ݒ�}�X�^
            temp.EmpSalesTargetCount = reader.ReadInt32();
            //���Ӑ�ʔ���ڕW�ݒ�}�X�^
            temp.CustSalesTargetCount = reader.ReadInt32();
            //���i�ʔ���ڕW�ݒ�}�X�^
            temp.GcdSalesTargetCount = reader.ReadInt32();
            //���i�����ރ}�X�^�i���[�U�[�o�^���j
            temp.GoodsMGroupUCount = reader.ReadInt32();
            //BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            temp.BLGroupUCount = reader.ReadInt32();
            //�����}�X�^�i���[�U�[�o�^���j
            temp.JoinPartsUCount = reader.ReadInt32();
            //TBO�����}�X�^�i���[�U�[�o�^�j
            temp.TBOSearchUCount = reader.ReadInt32();
            //���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            temp.PartsPosCodeUCount = reader.ReadInt32();
            //BL�R�[�h�K�C�h�}�X�^
            temp.BLCodeGuideCount = reader.ReadInt32();
            //�Ԏ햼�̃}�X�^
            temp.ModelNameUCount = reader.ReadInt32();
            //�G���[�敪
            temp.ErrorKubun = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>MstSearchCountWorkWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MstSearchCountWorkWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MstSearchCountWorkWork temp = GetMstSearchCountWorkWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (MstSearchCountWorkWork[])lst.ToArray(typeof(MstSearchCountWorkWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
