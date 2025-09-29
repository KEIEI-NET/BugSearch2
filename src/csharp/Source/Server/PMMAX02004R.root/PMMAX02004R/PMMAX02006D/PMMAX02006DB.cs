//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���iMAX���ח\��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270001-00  �쐬�S�� : ���O
// �� �� ��  2016/01/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockArrivalWork
    /// <summary>
    ///                      ���iMAX���ח\��f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���iMAX���ח\��f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/01/21</br>
    /// <br>Genarated Date   :   2016/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockArrivalWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�o�ד�</summary>
        private DateTime _shipDate;

        /// <summary>�`�[�ԍ�</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>�`�[�s�ԍ�</summary>
        private Int32 _stockMoveSlipRowNo;

        /// <summary>�i��</summary>
        private string _goodsName = "";

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�ȏ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[��</summary>
        private string _goodsMakerNm = "";

        /// <summary>BL�R�[�h</summary>
        /// <remarks>1�ȏ�</remarks>
        private Int32 _bLGoodsCod;

        /// <summary>�o�א�</summary>
        /// <remarks>�����_��2�ʂ܂ŕێ�(000.00)�B0.00�`99.99�͈̔�</remarks>
        private Double _shipmentCount;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>�̔��P��</summary>
        /// <remarks>0�`9,999,999</remarks>
        private Int64 _salesPrice;

        /// <summary>������</summary>
        /// <remarks>�����_��2�ʂ܂ŕێ�(000.00)�B0.00�`999.99�͈̔�</remarks>
        private Double _salesRate;

        /// <summary>�o�ɋ��_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>�o�ɋ��_��</summary>
        private string _bfSectionName = "";

        /// <summary>�o�ɑq�ɃR�[�h</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>�o�ɑq�ɖ�</summary>
        private string _bfEnterWarehName = "";

        /// <summary>���ɋ��_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>���ɋ��_��</summary>
        private string _afSectionName = "";

        /// <summary>���ɑq�ɃR�[�h</summary>
        private string _afEnterWarehCode = "";

        /// <summary>���ɑq�ɖ�</summary>
        private string _afEnterWarehName = "";

        /// <summary>���ח\���</summary>
        /// <remarks>"yyyy/MM/dd"�`���̕�����</remarks>
        private string _stockArrivalDate = "";

        /// <summary>�x�����R</summary>
        private string _alertReason = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>���Ӑ�̔���P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>���Ӑ�̔������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>������</summary>
        private Int32 _goodsMGroup;

        /// <summary>���i�}�X�^�̌����P��</summary>
        private Double _gpuSalesUnitCost;

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>�艿</summary>
        private Double _listPrice;

        /// <summary>�d����</summary>
        private Double _stockRate;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>�P��</summary>
        private Double _salesUnitCost;


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>"yyyy/MM/dd"�`���̕�����</value>
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

        /// public propaty name  :  ShipDate
        /// <summary>�o�ד��v���p�e�B</summary>
        /// <value>"yyyy/MM/dd"�`���̕�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipDate
        {
            get { return _shipDate; }
            set { _shipDate = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveSlipRowNo
        /// <summary>�`�[�s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveSlipRowNo
        {
            get { return _stockMoveSlipRowNo; }
            set { _stockMoveSlipRowNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
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
        /// <value>1�ȏ�</value>
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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>���[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  BLGoodsCod
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>1�ȏ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCod
        {
            get { return _bLGoodsCod; }
            set { _bLGoodsCod = value; }
        }

        /// public propaty name  :  ShipmentCount
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>�����_��2�ʂ܂ŕێ�(000.00)�B0.00�`99.99�͈̔�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCount
        {
            get { return _shipmentCount; }
            set { _shipmentCount = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SalesPrice
        /// <summary>�̔��P���v���p�e�B</summary>
        /// <value>0�`9,999,999</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>�������v���p�e�B</summary>
        /// <value>�����_��2�ʂ܂ŕێ�(000.00)�B0.00�`999.99�͈̔�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>�o�ɋ��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɋ��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionName
        /// <summary>�o�ɋ��_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɋ��_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionName
        {
            get { return _bfSectionName; }
            set { _bfSectionName = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�o�ɑq�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɑq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>�o�ɑq�ɖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɑq�ɖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>���ɋ��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɋ��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionName
        /// <summary>���ɋ��_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɋ��_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionName
        {
            get { return _afSectionName; }
            set { _afSectionName = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>���ɑq�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɑq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>���ɑq�ɖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɑq�ɖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  StockArrivalDate
        /// <summary>���ח\����v���p�e�B</summary>
        /// <value>"yyyy/MM/dd"�`���̕�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ח\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockArrivalDate
        {
            get { return _stockArrivalDate; }
            set { _stockArrivalDate = value; }
        }

        /// public propaty name  :  AlertReason
        /// <summary>�x�����R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AlertReason
        {
            get { return _alertReason; }
            set { _alertReason = value; }
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�������ނ��Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>���Ӑ�̔���P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�̔���P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>���Ӑ�̔������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�̔������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GpuSalesUnitCost
        /// <summary>���i�}�X�^�̌����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�̌����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GpuSalesUnitCost
        {
            get { return _gpuSalesUnitCost; }
            set { _gpuSalesUnitCost = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }


        /// <summary>
        /// ���iMAX�o�ח\�胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsMaxStockArrivalWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsMaxStockArrivalWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsMaxStockArrivalWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsMaxStockArrivalWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsMaxStockArrivalWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsMaxStockArrivalWork || graph is ArrayList || graph is PartsMaxStockArrivalWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsMaxStockArrivalWork).FullName));

            if (graph != null && graph is PartsMaxStockArrivalWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockArrivalWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsMaxStockArrivalWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsMaxStockArrivalWork[])graph).Length;
            }
            else if (graph is PartsMaxStockArrivalWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�o�ד�
            serInfo.MemberInfo.Add(typeof(DateTime)); //ShipDate
            //�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //�`�[�s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipRowNo
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCod
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCount
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //�̔��P��
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPrice
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //�o�ɋ��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //�o�ɋ��_��
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionName
            //�o�ɑq�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //�o�ɑq�ɖ�
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //���ɋ��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //���ɋ��_��
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionName
            //���ɑq�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //���ɑq�ɖ�
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //���ח\���
            serInfo.MemberInfo.Add(typeof(string)); //StockArrivalDate
            //�x�����R
            serInfo.MemberInfo.Add(typeof(string)); //AlertReason
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���i�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //���Ӑ�̔���P���[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //���Ӑ�̔������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            // ���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //�P��
            serInfo.MemberInfo.Add(typeof(Double)); //GpuSalesUnitCost
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //�艿
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsMaxStockArrivalWork)
            {
                PartsMaxStockArrivalWork temp = (PartsMaxStockArrivalWork)graph;

                SetPartsMaxStockArrivalWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsMaxStockArrivalWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsMaxStockArrivalWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsMaxStockArrivalWork temp in lst)
                {
                    SetPartsMaxStockArrivalWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsMaxStockArrivalWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  PartsMaxStockArrivalWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPartsMaxStockArrivalWork(System.IO.BinaryWriter writer, PartsMaxStockArrivalWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�o�ד�
            writer.Write((Int64)temp.ShipDate.Ticks);
            //�`�[�ԍ�
            writer.Write(temp.StockMoveSlipNo);
            //�`�[�s�ԍ�
            writer.Write(temp.StockMoveSlipRowNo);
            //�i��
            writer.Write(temp.GoodsName);
            //�i��
            writer.Write(temp.GoodsNo);
            //���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[��
            writer.Write(temp.GoodsMakerNm);
            //BL�R�[�h
            writer.Write(temp.BLGoodsCod);
            //�o�א�
            writer.Write(temp.ShipmentCount);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //�̔��P��
            writer.Write(temp.SalesPrice);
            //������
            writer.Write(temp.SalesRate);
            //�o�ɋ��_�R�[�h
            writer.Write(temp.BfSectionCode);
            //�o�ɋ��_��
            writer.Write(temp.BfSectionName);
            //�o�ɑq�ɃR�[�h
            writer.Write(temp.BfEnterWarehCode);
            //�o�ɑq�ɖ�
            writer.Write(temp.BfEnterWarehName);
            //���ɋ��_�R�[�h
            writer.Write(temp.AfSectionCode);
            //���ɋ��_��
            writer.Write(temp.AfSectionName);
            //���ɑq�ɃR�[�h
            writer.Write(temp.AfEnterWarehCode);
            //���ɑq�ɖ�
            writer.Write(temp.AfEnterWarehName);
            //���ח\���
            writer.Write(temp.StockArrivalDate);
            //�x�����R
            writer.Write(temp.AlertReason);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���i�|���O���[�v�R�[�h
            writer.Write(temp.GoodsRateGrpCode);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //���Ӑ�̔���P���[�������R�[�h
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //���Ӑ�̔������Œ[�������R�[�h
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //�P��
            writer.Write(temp.GpuSalesUnitCost);
            //���i�J�n��
            writer.Write(temp.PriceStartDate);
            //�艿
            writer.Write(temp.ListPrice);
            //�d����
            writer.Write(temp.StockRate);
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //�X�V�N����
            writer.Write(temp.UpdateDate);
            //�P��
            writer.Write(temp.SalesUnitCost);

        }

        /// <summary>
        ///  PartsMaxStockArrivalWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsMaxStockArrivalWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsMaxStockArrivalWork GetPartsMaxStockArrivalWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsMaxStockArrivalWork temp = new PartsMaxStockArrivalWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�o�ד�
            temp.ShipDate = new DateTime(reader.ReadInt64());
            //�`�[�ԍ�
            temp.StockMoveSlipNo = reader.ReadInt32();
            //�`�[�s�ԍ�
            temp.StockMoveSlipRowNo = reader.ReadInt32();
            //�i��
            temp.GoodsName = reader.ReadString();
            //�i��
            temp.GoodsNo = reader.ReadString();
            //���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[��
            temp.GoodsMakerNm = reader.ReadString();
            //BL�R�[�h
            temp.BLGoodsCod = reader.ReadInt32();
            //�o�א�
            temp.ShipmentCount = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //�̔��P��
            temp.SalesPrice = reader.ReadInt64();
            //������
            temp.SalesRate = reader.ReadDouble();
            //�o�ɋ��_�R�[�h
            temp.BfSectionCode = reader.ReadString();
            //�o�ɋ��_��
            temp.BfSectionName = reader.ReadString();
            //�o�ɑq�ɃR�[�h
            temp.BfEnterWarehCode = reader.ReadString();
            //�o�ɑq�ɖ�
            temp.BfEnterWarehName = reader.ReadString();
            //���ɋ��_�R�[�h
            temp.AfSectionCode = reader.ReadString();
            //���ɋ��_��
            temp.AfSectionName = reader.ReadString();
            //���ɑq�ɃR�[�h
            temp.AfEnterWarehCode = reader.ReadString();
            //���ɑq�ɖ�
            temp.AfEnterWarehName = reader.ReadString();
            //���ח\���
            temp.StockArrivalDate = reader.ReadString();
            //�x�����R
            temp.AlertReason = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���i�|���O���[�v�R�[�h
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //���Ӑ�̔���P���[�������R�[�h
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //���Ӑ�̔������Œ[�������R�[�h
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //�P��
            temp.GpuSalesUnitCost = reader.ReadDouble();
            //���i�J�n��
            temp.PriceStartDate = reader.ReadInt32();
            //�艿
            temp.ListPrice = reader.ReadDouble();
            //�d����
            temp.StockRate = reader.ReadDouble();
            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //�X�V�N����
            temp.UpdateDate = reader.ReadInt32();
            //�P��
            temp.SalesUnitCost = reader.ReadDouble();


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
        /// <returns>PartsMaxStockArrivalWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsMaxStockArrivalWork temp = GetPartsMaxStockArrivalWork(reader, serInfo);
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
                    retValue = (PartsMaxStockArrivalWork[])lst.ToArray(typeof(PartsMaxStockArrivalWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}