using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderListResultWork
    /// <summary>
    ///                      �����c�Ɖ���[�g���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����c�Ɖ���[�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OrderListResultWork
    {
        /// <summary>�ԓ`�敪</summary>
        /// <remarks>�d��</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>�d��</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d��</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>���͓�</summary>
        /// <remarks>�d��</remarks>
        private DateTime _inputDay;

        /// <summary>�󒍔ԍ�</summary>
        /// <remarks>�d������</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>�d���`��</summary>
        /// <remarks>�d������</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d������</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�d���s�ԍ�</summary>
        /// <remarks>�d������</remarks>
        private Int32 _stockRowNo;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�d������</remarks>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���_���ݒ�</remarks>
        private string _sectionGuideNm = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���_���ݒ�</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�d���S���҃R�[�h</summary>
        /// <remarks>�d������</remarks>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        /// <remarks>�d������</remarks>
        private string _stockAgentName = "";

        /// <summary>�d�����͎҃R�[�h</summary>
        /// <remarks>�d������</remarks>
        private string _stockInputCode = "";

        /// <summary>�d�����͎Җ���</summary>
        /// <remarks>�d������</remarks>
        private string _stockInputName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�d������</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>�d������</remarks>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>�d������</remarks>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        /// <remarks>�d������</remarks>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        /// <remarks>�d������</remarks>
        private string _goodsNameKana = "";

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>�d������</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        /// <remarks>�d������</remarks>
        private string _bLGoodsFullName = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�d������</remarks>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�d������</remarks>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        /// <remarks>�d������</remarks>
        private string _warehouseShelfNo = "";

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>�d������</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�d������</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�d������</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�d������</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���P���i�ō��C�����j</summary>
        /// <remarks>�d������</remarks>
        private Double _stockUnitTaxPriceFl;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�d������</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>�d����</summary>
        /// <remarks>�d������</remarks>
        private Double _stockCount;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        /// <remarks>�d������</remarks>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z�i�ō��݁j</summary>
        /// <remarks>�d������</remarks>
        private Int64 _stockPriceTaxInc;

        /// <summary>�d���`�[���ה��l1</summary>
        /// <remarks>�d������</remarks>
        private string _stockDtiSlipNote1 = "";

        /// <summary>�̔���R�[�h</summary>
        /// <remarks>�d������</remarks>
        private Int32 _salesCustomerCode;

        /// <summary>�̔��旪��</summary>
        /// <remarks>�d������</remarks>
        private string _salesCustomerSnm = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d������</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        /// <remarks>�d������</remarks>
        private string _supplierSnm = "";

        /// <summary>�[�i��R�[�h</summary>
        /// <remarks>�d������</remarks>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        /// <remarks>�d������</remarks>
        private string _addresseeName = "";

        /// <summary>�c���X�V��</summary>
        /// <remarks>�d������</remarks>
        private DateTime _remainCntUpdDate;

        /// <summary>�����敪</summary>
        /// <remarks>�d������</remarks>
        private Int32 _directSendingCd;

        /// <summary>�����ԍ�</summary>
        /// <remarks>�d������</remarks>
        private string _orderNumber = "";

        /// <summary>�������@</summary>
        /// <remarks>�d������</remarks>
        private Int32 _wayToOrder;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�d������</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>��]�[��</summary>
        /// <remarks>�d������</remarks>
        private DateTime _expectDeliveryDate;

        /// <summary>��������</summary>
        /// <remarks>�d������</remarks>
        private Double _orderCnt;

        /// <summary>����������</summary>
        /// <remarks>�d������</remarks>
        private Double _orderAdjustCnt;

        /// <summary>�����c��</summary>
        /// <remarks>�d������</remarks>
        private Double _orderRemainCnt;

        /// <summary>���������s�ϋ敪</summary>
        /// <remarks>�d������</remarks>
        private Int32 _orderFormIssuedDiv;

        /// <summary>�����f�[�^�쐬��</summary>
        /// <remarks>�d������</remarks>
        private DateTime _orderDataCreateDate;

        /// <summary>�`�[�����P</summary>
        /// <remarks>�d������</remarks>
        private string _slipMemo1 = "";

        /// <summary>�`�[�����Q</summary>
        /// <remarks>�d������</remarks>
        private string _slipMemo2 = "";

        /// <summary>�`�[�����R</summary>
        /// <remarks>�d������</remarks>
        private string _slipMemo3 = "";

        /// <summary>�Г������P</summary>
        /// <remarks>�d������</remarks>
        private string _insideMemo1 = "";

        /// <summary>�Г������Q</summary>
        /// <remarks>�d������</remarks>
        private string _insideMemo2 = "";

        /// <summary>�Г������R</summary>
        /// <remarks>�d������</remarks>
        private string _insideMemo3 = "";

        /// <summary>�d�����גʔ�</summary>
        /// <remarks>�d������</remarks>
        private Int64 _stockSlipDtlNum;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�  �d��</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj  �d������</remarks>
        private Int32 _taxationCode;


        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>�d��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>�d��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>�d��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>�d���s�ԍ��v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���_���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���_���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// <value>�d������</value>
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

        /// public propaty name  :  StockInputCode
        /// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  StockInputName
        /// <summary>�d�����͎Җ��̃v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
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

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// <value>�d������</value>
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

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>�d���P���i�ō��C�����j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>�d�����z�i�ō��݁j�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>�d���`�[���ה��l1�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���ה��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set { _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>�̔���R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set { _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerSnm
        /// <summary>�̔��旪�̃v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCustomerSnm
        {
            get { return _salesCustomerSnm; }
            set { _salesCustomerSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>�c���X�V���v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set { _remainCntUpdDate = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>�������@�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  ExpectDeliveryDate
        /// <summary>��]�[���v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExpectDeliveryDate
        {
            get { return _expectDeliveryDate; }
            set { _expectDeliveryDate = value; }
        }

        /// public propaty name  :  OrderCnt
        /// <summary>�������ʃv���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderCnt
        {
            get { return _orderCnt; }
            set { _orderCnt = value; }
        }

        /// public propaty name  :  OrderAdjustCnt
        /// <summary>�����������v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderAdjustCnt
        {
            get { return _orderAdjustCnt; }
            set { _orderAdjustCnt = value; }
        }

        /// public propaty name  :  OrderRemainCnt
        /// <summary>�����c���v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderRemainCnt
        {
            get { return _orderRemainCnt; }
            set { _orderRemainCnt = value; }
        }

        /// public propaty name  :  OrderFormIssuedDiv
        /// <summary>���������s�ϋ敪�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderFormIssuedDiv
        {
            get { return _orderFormIssuedDiv; }
            set { _orderFormIssuedDiv = value; }
        }

        /// public propaty name  :  OrderDataCreateDate
        /// <summary>�����f�[�^�쐬���v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OrderDataCreateDate
        {
            get { return _orderDataCreateDate; }
            set { _orderDataCreateDate = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>�`�[�����P�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set { _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>�`�[�����Q�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set { _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>�`�[�����R�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set { _slipMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>�Г������P�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set { _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>�Г������Q�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set { _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>�Г������R�v���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set { _insideMemo3 = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// <value>�d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�  �d��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj  �d������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }


        /// <summary>
        /// �����c�Ɖ���[�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OrderListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OrderListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OrderListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OrderListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OrderListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OrderListResultWork || graph is ArrayList || graph is OrderListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OrderListResultWork).FullName));

            if (graph != null && graph is OrderListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OrderListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OrderListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OrderListResultWork[])graph).Length;
            }
            else if (graph is OrderListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�d���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�d�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //�d�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //�d���`�[���ה��l1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //�̔���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //�̔��旪��
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�[�i��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //�[�i�於��
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //�c���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�������@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //��]�[��
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectDeliveryDate
            //��������
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            //����������
            serInfo.MemberInfo.Add(typeof(Double)); //OrderAdjustCnt
            //�����c��
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainCnt
            //���������s�ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderFormIssuedDiv
            //�����f�[�^�쐬��
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDate
            //�`�[�����P
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //�`�[�����Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //�`�[�����R
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //�Г������P
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //�Г������Q
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //�Г������R
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //�d�����גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode


            serInfo.Serialize(writer, serInfo);
            if (graph is OrderListResultWork)
            {
                OrderListResultWork temp = (OrderListResultWork)graph;

                SetOrderListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OrderListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OrderListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OrderListResultWork temp in lst)
                {
                    SetOrderListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OrderListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 62;

        /// <summary>
        ///  OrderListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOrderListResultWork(System.IO.BinaryWriter writer, OrderListResultWork temp)
        {
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //�󒍔ԍ�
            writer.Write(temp.AcceptAnOrderNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�d���s�ԍ�
            writer.Write(temp.StockRowNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�d�����͎҃R�[�h
            writer.Write(temp.StockInputCode);
            //�d�����͎Җ���
            writer.Write(temp.StockInputName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���݌Ɏ�񂹋敪
            writer.Write(temp.StockOrderDivCd);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�艿�i�ō��C�����j
            writer.Write(temp.ListPriceTaxIncFl);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���P���i�ō��C�����j
            writer.Write(temp.StockUnitTaxPriceFl);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�d����
            writer.Write(temp.StockCount);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z�i�ō��݁j
            writer.Write(temp.StockPriceTaxInc);
            //�d���`�[���ה��l1
            writer.Write(temp.StockDtiSlipNote1);
            //�̔���R�[�h
            writer.Write(temp.SalesCustomerCode);
            //�̔��旪��
            writer.Write(temp.SalesCustomerSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�[�i��R�[�h
            writer.Write(temp.AddresseeCode);
            //�[�i�於��
            writer.Write(temp.AddresseeName);
            //�c���X�V��
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //�����敪
            writer.Write(temp.DirectSendingCd);
            //�����ԍ�
            writer.Write(temp.OrderNumber);
            //�������@
            writer.Write(temp.WayToOrder);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //��]�[��
            writer.Write((Int64)temp.ExpectDeliveryDate.Ticks);
            //��������
            writer.Write(temp.OrderCnt);
            //����������
            writer.Write(temp.OrderAdjustCnt);
            //�����c��
            writer.Write(temp.OrderRemainCnt);
            //���������s�ϋ敪
            writer.Write(temp.OrderFormIssuedDiv);
            //�����f�[�^�쐬��
            writer.Write((Int64)temp.OrderDataCreateDate.Ticks);
            //�`�[�����P
            writer.Write(temp.SlipMemo1);
            //�`�[�����Q
            writer.Write(temp.SlipMemo2);
            //�`�[�����R
            writer.Write(temp.SlipMemo3);
            //�Г������P
            writer.Write(temp.InsideMemo1);
            //�Г������Q
            writer.Write(temp.InsideMemo2);
            //�Г������R
            writer.Write(temp.InsideMemo3);
            //�d�����גʔ�
            writer.Write(temp.StockSlipDtlNum);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //�ېŋ敪
            writer.Write(temp.TaxationCode);

        }

        /// <summary>
        ///  OrderListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OrderListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OrderListResultWork GetOrderListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OrderListResultWork temp = new OrderListResultWork();

            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�d���s�ԍ�
            temp.StockRowNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�d�����͎҃R�[�h
            temp.StockInputCode = reader.ReadString();
            //�d�����͎Җ���
            temp.StockInputName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���݌Ɏ�񂹋敪
            temp.StockOrderDivCd = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�艿�i�ō��C�����j
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���P���i�ō��C�����j
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z�i�ō��݁j
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�d���`�[���ה��l1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //�̔���R�[�h
            temp.SalesCustomerCode = reader.ReadInt32();
            //�̔��旪��
            temp.SalesCustomerSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�[�i��R�[�h
            temp.AddresseeCode = reader.ReadInt32();
            //�[�i�於��
            temp.AddresseeName = reader.ReadString();
            //�c���X�V��
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //�����敪
            temp.DirectSendingCd = reader.ReadInt32();
            //�����ԍ�
            temp.OrderNumber = reader.ReadString();
            //�������@
            temp.WayToOrder = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //��]�[��
            temp.ExpectDeliveryDate = new DateTime(reader.ReadInt64());
            //��������
            temp.OrderCnt = reader.ReadDouble();
            //����������
            temp.OrderAdjustCnt = reader.ReadDouble();
            //�����c��
            temp.OrderRemainCnt = reader.ReadDouble();
            //���������s�ϋ敪
            temp.OrderFormIssuedDiv = reader.ReadInt32();
            //�����f�[�^�쐬��
            temp.OrderDataCreateDate = new DateTime(reader.ReadInt64());
            //�`�[�����P
            temp.SlipMemo1 = reader.ReadString();
            //�`�[�����Q
            temp.SlipMemo2 = reader.ReadString();
            //�`�[�����R
            temp.SlipMemo3 = reader.ReadString();
            //�Г������P
            temp.InsideMemo1 = reader.ReadString();
            //�Г������Q
            temp.InsideMemo2 = reader.ReadString();
            //�Г������R
            temp.InsideMemo3 = reader.ReadString();
            //�d�����גʔ�
            temp.StockSlipDtlNum = reader.ReadInt64();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�ېŋ敪
            temp.TaxationCode = reader.ReadInt32();


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
        /// <returns>OrderListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OrderListResultWork temp = GetOrderListResultWork(reader, serInfo);
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
                    retValue = (OrderListResultWork[])lst.ToArray(typeof(OrderListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
