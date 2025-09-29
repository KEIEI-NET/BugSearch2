using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UnPrcInfoConf
    /// <summary>
    ///                      �P�����m�F
    /// </summary>
    /// <remarks>
    /// <br>note             :   �P�����m�F�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      : K2014/02/09 yangyi</br>
    /// <br>�Ǘ��ԍ�         : 10970681-00 �O�����a����ʌʑΉ�</br>
    /// <br>                 : ����`�[���͂̉��ǑΉ�</br>
    /// </remarks>
    public class UnPrcInfoConf
    {
        /// <summary>�|���ݒ�敪</summary>
        private string _rateSettingDivide = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>�����ނ��g�p</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i�|���O���[�v�R�[�h����</summary>
        /// <remarks>�����ނ��g�p</remarks>
        private string _goodsRateGrpCodeNm = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���i�K�p��</summary>
        private DateTime _priceApplyDate;

        /// <summary>����</summary>
        private Double _countFl;

        /// <summary>�P���Z�o�敪</summary>
        /// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
        private Int32 _unitPrcCalcDiv;

        /// <summary>�|��</summary>
        /// <remarks>�|��</remarks>
        private Double _rateVal;

        /// <summary>�P���[�������P��</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>�P���[�������敪</summary>
        private Int32 _unPrcFracProcDiv;

        /// <summary>��P��</summary>
        private Double _stdUnitPrice;

        /// <summary>�P���i�Ŕ��C�����j</summary>
        private Double _unitPriceTaxExcFl;

        /// <summary>�P���i�ō��C�����j</summary>
        private Double _unitPriceTaxIncFl;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�����P���i�ō��C�����j</summary>
        private Double _salesUnitCostTaxIncFl;

        /// <summary>�����P���i�Ŕ��C�����j</summary>
        private Double _salesUnitCostTaxExcFl;

        /// <summary>�ېŋ敪</summary>
        private Int32 _taxationDivCd;

        /// <summary>����Œ[�������P��</summary>
        private Double _taxFractionProcUnit;

        /// <summary>����Œ[�������敪</summary>
        private Int32 _taxFractionProcCd;

        /// <summary>�ŗ�</summary>
        private Double _taxRate;

        /// <summary>���z�\�����@�敪</summary>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���z�\���|���K�p�敪</summary>
        private Int32 _ttlAmntDspRateDivCd;

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- >>>>>
        /// <summary>�W�����i�I���敪</summary>
        /// <remarks>0:�D��,1:����,2:������(1:N),,3:������(1:1)</remarks>
        private Int32 _priceSelectDiv;

        /// <summary>�K�C�h����</summary>
        private string _sectionGuideNm = "";
        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- <<<<<

        // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
        /// <summary>�|���X�V��</summary>
        private string _rateUpdateTimeSales = "";

        /// <summary>�|���X�V��</summary>
        private string _rateUpdateTimeUnit = "";
        // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

        /// public propaty name  :  RateSettingDivide
        /// <summary>�|���ݒ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSettingDivide
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�����ނ��g�p</value>
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

        /// public propaty name  :  GoodsRateGrpCodeNm
        /// <summary>���i�|���O���[�v�R�[�h���̃v���p�e�B</summary>
        /// <value>�����ނ��g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateGrpCodeNm
        {
            get { return _goodsRateGrpCodeNm; }
            set { _goodsRateGrpCodeNm = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  PriceApplyDate
        /// <summary>���i�K�p���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�p���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceApplyDate
        {
            get { return _priceApplyDate; }
            set { _priceApplyDate = value; }
        }

        /// public propaty name  :  CountFl
        /// <summary>���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CountFl
        {
            get { return _countFl; }
            set { _countFl = value; }
        }

        /// public propaty name  :  UnitPrcCalcDiv
        /// <summary>�P���Z�o�敪�v���p�e�B</summary>
        /// <value>1:�|��,2:�����t�o��,3:�e����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnitPrcCalcDiv
        {
            get { return _unitPrcCalcDiv; }
            set { _unitPrcCalcDiv = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>�|���v���p�e�B</summary>
        /// <value>�|��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  UnPrcFracProcUnit
        /// <summary>�P���[�������P�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���[�������P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnPrcFracProcUnit
        {
            get { return _unPrcFracProcUnit; }
            set { _unPrcFracProcUnit = value; }
        }

        /// public propaty name  :  UnPrcFracProcDiv
        /// <summary>�P���[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcFracProcDiv
        {
            get { return _unPrcFracProcDiv; }
            set { _unPrcFracProcDiv = value; }
        }

        /// public propaty name  :  StdUnitPrice
        /// <summary>��P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnitPrice
        {
            get { return _stdUnitPrice; }
            set { _stdUnitPrice = value; }
        }

        /// public propaty name  :  UnitPriceTaxExcFl
        /// <summary>�P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnitPriceTaxExcFl
        {
            get { return _unitPriceTaxExcFl; }
            set { _unitPriceTaxExcFl = value; }
        }

        /// public propaty name  :  UnitPriceTaxIncFl
        /// <summary>�P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnitPriceTaxIncFl
        {
            get { return _unitPriceTaxIncFl; }
            set { _unitPriceTaxIncFl = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
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

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
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

        /// public propaty name  :  SalesUnitCostTaxIncFl
        /// <summary>�����P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCostTaxIncFl
        {
            get { return _salesUnitCostTaxIncFl; }
            set { _salesUnitCostTaxIncFl = value; }
        }

        /// public propaty name  :  SalesUnitCostTaxExcFl
        /// <summary>�����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCostTaxExcFl
        {
            get { return _salesUnitCostTaxExcFl; }
            set { _salesUnitCostTaxExcFl = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
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

        /// public propaty name  :  TaxFractionProcUnit
        /// <summary>����Œ[�������P�ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ[�������P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxFractionProcUnit
        {
            get { return _taxFractionProcUnit; }
            set { _taxFractionProcUnit = value; }
        }

        /// public propaty name  :  TaxFractionProcCd
        /// <summary>����Œ[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxFractionProcCd
        {
            get { return _taxFractionProcCd; }
            set { _taxFractionProcCd = value; }
        }

        /// public propaty name  :  TaxRate
        /// <summary>�ŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDspRateDivCd
        /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlAmntDspRateDivCd
        {
            get { return _ttlAmntDspRateDivCd; }
            set { _ttlAmntDspRateDivCd = value; }
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

        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- >>>>>
        /// public propaty name  :  PriceSelectDiv
        /// <summary>�W�����i�I���敪�v���p�e�B</summary>
        /// <value>0:�D��,1:����,2:������(1:N),,3:������(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I���敪�v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  SectionGuideNm 
        /// <summary>�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }
        // ----ADD 2013/01/24 ���N�n�� REDMINE#34605---- <<<<<

        // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
        /// public propaty name  :  RateUpdateTimeSales 
        /// <summary>�|���X�V���i���P���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public string RateUpdateTimeSales
        {
            get { return _rateUpdateTimeSales; }
            set { _rateUpdateTimeSales = value; }
        }

        /// public propaty name  :  RateUpdateTimeUnit 
        /// <summary>�|���X�V���i���P���j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public string RateUpdateTimeUnit
        {
            get { return _rateUpdateTimeUnit; }
            set { _rateUpdateTimeUnit = value; }
        }
        // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

        /// <summary>
        /// �P�����m�F�R���X�g���N�^
        /// </summary>
        /// <returns>UnPrcInfoConf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnPrcInfoConf()
        {
        }

        /// <summary>
        /// �P�����m�F�R���X�g���N�^
        /// </summary>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsRateRank">���i�|�������N(�w��)</param>
        /// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h(�����ނ��g�p)</param>
        /// <param name="goodsRateGrpCodeNm">���i�|���O���[�v�R�[�h����(�����ނ��g�p)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="priceApplyDate">���i�K�p��</param>
        /// <param name="countFl">����</param>
        /// <param name="unitPrcCalcDiv">�P���Z�o�敪(1:�|��,2:�����t�o��,3:�e����)</param>
        /// <param name="rateVal">�|��(�|��)</param>
        /// <param name="unPrcFracProcUnit">�P���[�������P��</param>
        /// <param name="unPrcFracProcDiv">�P���[�������敪</param>
        /// <param name="stdUnitPrice">��P��</param>
        /// <param name="unitPriceTaxExcFl">�P���i�Ŕ��C�����j</param>
        /// <param name="unitPriceTaxIncFl">�P���i�ō��C�����j</param>
        /// <param name="listPriceTaxIncFl">�艿�i�ō��C�����j(�Ŕ���)</param>
        /// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�ō���)</param>
        /// <param name="salesUnitCostTaxIncFl">�����P���i�ō��C�����j</param>
        /// <param name="salesUnitCostTaxExcFl">�����P���i�Ŕ��C�����j</param>
        /// <param name="taxationDivCd">�ېŋ敪</param>
        /// <param name="taxFractionProcUnit">����Œ[�������P��</param>
        /// <param name="taxFractionProcCd">����Œ[�������敪</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <param name="ttlAmntDspRateDivCd">���z�\���|���K�p�敪</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="priceSelectDiv">�W�����i�I���敪</param>// ADD 2013/01/24 ���N�n�� REDMINE#34605
        /// <param name="sectionGuideNm">�K�C�h����</param>// ADD 2013/01/24 ���N�n�� REDMINE#34605
        /// <param name="rateUpdateTimeSales">�|���X�V���i���P���j</param>//ADD yangyi K2014/02/09
        /// <param name="rateUpdateTimeUnit">�|���X�V���i���P���j</param>//ADD yangyi K2014/02/09 
        /// <returns>UnPrcInfoConf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public UnPrcInfoConf( string rateSettingDivide, string sectionCode, Int32 customerCode, string customerSnm, Int32 supplierCd, string supplierSnm, Int32 custRateGrpCode, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsRateRank, Int32 goodsRateGrpCode, string goodsRateGrpCodeNm, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, DateTime priceApplyDate, Double countFl, Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Double salesUnitCostTaxIncFl, Double salesUnitCostTaxExcFl, Int32 taxationDivCd, Double taxFractionProcUnit, Int32 taxFractionProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, string bLGoodsName )// DEL 2013/01/24 ���N�n�� REDMINE#34605  
        //public UnPrcInfoConf(string rateSettingDivide, string sectionCode, Int32 customerCode, string customerSnm, Int32 supplierCd, string supplierSnm, Int32 custRateGrpCode, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsRateRank, Int32 goodsRateGrpCode, string goodsRateGrpCodeNm, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, DateTime priceApplyDate, Double countFl, Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Double salesUnitCostTaxIncFl, Double salesUnitCostTaxExcFl, Int32 taxationDivCd, Double taxFractionProcUnit, Int32 taxFractionProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, string bLGoodsName, Int32 priceSelectDiv, string sectionGuideNm)// ADD 2013/01/24 ���N�n�� REDMINE#34605    //DEL yangyi K2014/02/09 
        public UnPrcInfoConf(string rateSettingDivide, string sectionCode, Int32 customerCode, string customerSnm, Int32 supplierCd, string supplierSnm, Int32 custRateGrpCode, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsRateRank, Int32 goodsRateGrpCode, string goodsRateGrpCodeNm, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, DateTime priceApplyDate, Double countFl, Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Double salesUnitCostTaxIncFl, Double salesUnitCostTaxExcFl, Int32 taxationDivCd, Double taxFractionProcUnit, Int32 taxFractionProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, string bLGoodsName, Int32 priceSelectDiv, string sectionGuideNm, string rateUpdateTimeSales, string rateUpdateTimeUnit)// ADD 2013/01/24 ���N�n�� REDMINE#34605   //ADD yangyi K2014/02/09   
       {
            this._rateSettingDivide = rateSettingDivide;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._custRateGrpCode = custRateGrpCode;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsRateRank = goodsRateRank;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._goodsRateGrpCodeNm = goodsRateGrpCodeNm;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._priceApplyDate = priceApplyDate;
            this._countFl = countFl;
            this._unitPrcCalcDiv = unitPrcCalcDiv;
            this._rateVal = rateVal;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._stdUnitPrice = stdUnitPrice;
            this._unitPriceTaxExcFl = unitPriceTaxExcFl;
            this._unitPriceTaxIncFl = unitPriceTaxIncFl;
            this._listPriceTaxIncFl = listPriceTaxIncFl;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._salesUnitCostTaxIncFl = salesUnitCostTaxIncFl;
            this._salesUnitCostTaxExcFl = salesUnitCostTaxExcFl;
            this._taxationDivCd = taxationDivCd;
            this._taxFractionProcUnit = taxFractionProcUnit;
            this._taxFractionProcCd = taxFractionProcCd;
            this._taxRate = taxRate;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
            this._bLGoodsName = bLGoodsName;
            // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- >>>>>
            this._priceSelectDiv = priceSelectDiv;
            this._sectionGuideNm = sectionGuideNm;
            // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- <<<<<
            this._rateUpdateTimeSales = rateUpdateTimeSales;
            this._rateUpdateTimeUnit = rateUpdateTimeUnit;

        }

        /// <summary>
        /// �P�����m�F��������
        /// </summary>
        /// <returns>UnPrcInfoConf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UnPrcInfoConf�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UnPrcInfoConf Clone()
        {
            //return new UnPrcInfoConf(this._rateSettingDivide, this._sectionCode, this._customerCode, this._customerSnm, this._supplierCd, this._supplierSnm, this._custRateGrpCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsRateRank, this._goodsRateGrpCode, this._goodsRateGrpCodeNm, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._priceApplyDate, this._countFl, this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._salesUnitCostTaxIncFl, this._salesUnitCostTaxExcFl, this._taxationDivCd, this._taxFractionProcUnit, this._taxFractionProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._bLGoodsName);// DEL 2013/01/24 ���N�n�� REDMINE#34605
            //return new UnPrcInfoConf(this._rateSettingDivide, this._sectionCode, this._customerCode, this._customerSnm, this._supplierCd, this._supplierSnm, this._custRateGrpCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsRateRank, this._goodsRateGrpCode, this._goodsRateGrpCodeNm, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._priceApplyDate, this._countFl, this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._salesUnitCostTaxIncFl, this._salesUnitCostTaxExcFl, this._taxationDivCd, this._taxFractionProcUnit, this._taxFractionProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._bLGoodsName, this._priceSelectDiv, this._sectionGuideNm);// ADD 2013/01/24 ���N�n�� REDMINE#34605                 //DEL yangyi K2014/02/09 
            return new UnPrcInfoConf(this._rateSettingDivide, this._sectionCode, this._customerCode, this._customerSnm, this._supplierCd, this._supplierSnm, this._custRateGrpCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsRateRank, this._goodsRateGrpCode, this._goodsRateGrpCodeNm, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._priceApplyDate, this._countFl, this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._salesUnitCostTaxIncFl, this._salesUnitCostTaxExcFl, this._taxationDivCd, this._taxFractionProcUnit, this._taxFractionProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._bLGoodsName, this._priceSelectDiv, this._sectionGuideNm, this._rateUpdateTimeSales, this._rateUpdateTimeUnit);// ADD 2013/01/24 ���N�n�� REDMINE#34605  //ADD yangyi K2014/02/09 

        }

        /// <summary>
        /// �P�����m�F��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UnPrcInfoConf�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConf�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( UnPrcInfoConf target )
        {
            return ( ( this.RateSettingDivide == target.RateSettingDivide )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.CustomerSnm == target.CustomerSnm )
                 && ( this.SupplierCd == target.SupplierCd )
                 && ( this.SupplierSnm == target.SupplierSnm )
                 && ( this.CustRateGrpCode == target.CustRateGrpCode )
                 && ( this.GoodsMakerCd == target.GoodsMakerCd )
                 && ( this.MakerName == target.MakerName )
                 && ( this.GoodsNo == target.GoodsNo )
                 && ( this.GoodsName == target.GoodsName )
                 && ( this.GoodsRateRank == target.GoodsRateRank )
                 && ( this.GoodsRateGrpCode == target.GoodsRateGrpCode )
                 && ( this.GoodsRateGrpCodeNm == target.GoodsRateGrpCodeNm )
                 && ( this.BLGroupCode == target.BLGroupCode )
                 && ( this.BLGroupName == target.BLGroupName )
                 && ( this.BLGoodsCode == target.BLGoodsCode )
                 && ( this.BLGoodsFullName == target.BLGoodsFullName )
                 && ( this.PriceApplyDate == target.PriceApplyDate )
                 && ( this.CountFl == target.CountFl )
                 && ( this.UnitPrcCalcDiv == target.UnitPrcCalcDiv )
                 && ( this.RateVal == target.RateVal )
                 && ( this.UnPrcFracProcUnit == target.UnPrcFracProcUnit )
                 && ( this.UnPrcFracProcDiv == target.UnPrcFracProcDiv )
                 && ( this.StdUnitPrice == target.StdUnitPrice )
                 && ( this.UnitPriceTaxExcFl == target.UnitPriceTaxExcFl )
                 && ( this.UnitPriceTaxIncFl == target.UnitPriceTaxIncFl )
                 && ( this.ListPriceTaxIncFl == target.ListPriceTaxIncFl )
                 && ( this.ListPriceTaxExcFl == target.ListPriceTaxExcFl )
                 && ( this.SalesUnitCostTaxIncFl == target.SalesUnitCostTaxIncFl )
                 && ( this.SalesUnitCostTaxExcFl == target.SalesUnitCostTaxExcFl )
                 && ( this.TaxationDivCd == target.TaxationDivCd )
                 && ( this.TaxFractionProcUnit == target.TaxFractionProcUnit )
                 && ( this.TaxFractionProcCd == target.TaxFractionProcCd )
                 && ( this.TaxRate == target.TaxRate )
                 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
                 && ( this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd )
                 && ( this.BLGoodsName == target.BLGoodsName )
                 // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- >>>>>
                 && ( this.PriceSelectDiv == target.PriceSelectDiv)
                 && ( this.SectionGuideNm == target.SectionGuideNm)
                 // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- <<<<<
                 && (this.RateUpdateTimeSales == target.RateUpdateTimeSales)  //ADD yangyi K2014/02/09
                 && (this.RateUpdateTimeUnit == target.RateUpdateTimeUnit));  //ADD yangyi K2014/02/09
        }

        /// <summary>
        /// �P�����m�F��r����
        /// </summary>
        /// <param name="unPrcInfoConf1">
        ///                    ��r����UnPrcInfoConf�N���X�̃C���X�^���X
        /// </param>
        /// <param name="unPrcInfoConf2">��r����UnPrcInfoConf�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConf�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( UnPrcInfoConf unPrcInfoConf1, UnPrcInfoConf unPrcInfoConf2 )
        {
            return ( ( unPrcInfoConf1.RateSettingDivide == unPrcInfoConf2.RateSettingDivide )
                 && ( unPrcInfoConf1.SectionCode == unPrcInfoConf2.SectionCode )
                 && ( unPrcInfoConf1.CustomerCode == unPrcInfoConf2.CustomerCode )
                 && ( unPrcInfoConf1.CustomerSnm == unPrcInfoConf2.CustomerSnm )
                 && ( unPrcInfoConf1.SupplierCd == unPrcInfoConf2.SupplierCd )
                 && ( unPrcInfoConf1.SupplierSnm == unPrcInfoConf2.SupplierSnm )
                 && ( unPrcInfoConf1.CustRateGrpCode == unPrcInfoConf2.CustRateGrpCode )
                 && ( unPrcInfoConf1.GoodsMakerCd == unPrcInfoConf2.GoodsMakerCd )
                 && ( unPrcInfoConf1.MakerName == unPrcInfoConf2.MakerName )
                 && ( unPrcInfoConf1.GoodsNo == unPrcInfoConf2.GoodsNo )
                 && ( unPrcInfoConf1.GoodsName == unPrcInfoConf2.GoodsName )
                 && ( unPrcInfoConf1.GoodsRateRank == unPrcInfoConf2.GoodsRateRank )
                 && ( unPrcInfoConf1.GoodsRateGrpCode == unPrcInfoConf2.GoodsRateGrpCode )
                 && ( unPrcInfoConf1.GoodsRateGrpCodeNm == unPrcInfoConf2.GoodsRateGrpCodeNm )
                 && ( unPrcInfoConf1.BLGroupCode == unPrcInfoConf2.BLGroupCode )
                 && ( unPrcInfoConf1.BLGroupName == unPrcInfoConf2.BLGroupName )
                 && ( unPrcInfoConf1.BLGoodsCode == unPrcInfoConf2.BLGoodsCode )
                 && ( unPrcInfoConf1.BLGoodsFullName == unPrcInfoConf2.BLGoodsFullName )
                 && ( unPrcInfoConf1.PriceApplyDate == unPrcInfoConf2.PriceApplyDate )
                 && ( unPrcInfoConf1.CountFl == unPrcInfoConf2.CountFl )
                 && ( unPrcInfoConf1.UnitPrcCalcDiv == unPrcInfoConf2.UnitPrcCalcDiv )
                 && ( unPrcInfoConf1.RateVal == unPrcInfoConf2.RateVal )
                 && ( unPrcInfoConf1.UnPrcFracProcUnit == unPrcInfoConf2.UnPrcFracProcUnit )
                 && ( unPrcInfoConf1.UnPrcFracProcDiv == unPrcInfoConf2.UnPrcFracProcDiv )
                 && ( unPrcInfoConf1.StdUnitPrice == unPrcInfoConf2.StdUnitPrice )
                 && ( unPrcInfoConf1.UnitPriceTaxExcFl == unPrcInfoConf2.UnitPriceTaxExcFl )
                 && ( unPrcInfoConf1.UnitPriceTaxIncFl == unPrcInfoConf2.UnitPriceTaxIncFl )
                 && ( unPrcInfoConf1.ListPriceTaxIncFl == unPrcInfoConf2.ListPriceTaxIncFl )
                 && ( unPrcInfoConf1.ListPriceTaxExcFl == unPrcInfoConf2.ListPriceTaxExcFl )
                 && ( unPrcInfoConf1.SalesUnitCostTaxIncFl == unPrcInfoConf2.SalesUnitCostTaxIncFl )
                 && ( unPrcInfoConf1.SalesUnitCostTaxExcFl == unPrcInfoConf2.SalesUnitCostTaxExcFl )
                 && ( unPrcInfoConf1.TaxationDivCd == unPrcInfoConf2.TaxationDivCd )
                 && ( unPrcInfoConf1.TaxFractionProcUnit == unPrcInfoConf2.TaxFractionProcUnit )
                 && ( unPrcInfoConf1.TaxFractionProcCd == unPrcInfoConf2.TaxFractionProcCd )
                 && ( unPrcInfoConf1.TaxRate == unPrcInfoConf2.TaxRate )
                 && ( unPrcInfoConf1.TotalAmountDispWayCd == unPrcInfoConf2.TotalAmountDispWayCd )
                 && ( unPrcInfoConf1.TtlAmntDspRateDivCd == unPrcInfoConf2.TtlAmntDspRateDivCd )
                 && ( unPrcInfoConf1.BLGoodsName == unPrcInfoConf2.BLGoodsName )
                 // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- >>>>>
                 && (unPrcInfoConf1.PriceSelectDiv == unPrcInfoConf2.PriceSelectDiv)
                 && (unPrcInfoConf1.SectionGuideNm == unPrcInfoConf2.SectionGuideNm)
                 // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- <<<<<
                 && (unPrcInfoConf1.RateUpdateTimeSales == unPrcInfoConf2.RateUpdateTimeSales) //ADD yangyi K2014/02/09
                 && (unPrcInfoConf1.RateUpdateTimeUnit == unPrcInfoConf2.RateUpdateTimeUnit)); //ADD yangyi K2014/02/09
        }
        /// <summary>
        /// �P�����m�F��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UnPrcInfoConf�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConf�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( UnPrcInfoConf target )
        {
            ArrayList resList = new ArrayList();
            if (this.RateSettingDivide != target.RateSettingDivide) resList.Add("RateSettingDivide");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.GoodsRateGrpCodeNm != target.GoodsRateGrpCodeNm) resList.Add("GoodsRateGrpCodeNm");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.PriceApplyDate != target.PriceApplyDate) resList.Add("PriceApplyDate");
            if (this.CountFl != target.CountFl) resList.Add("CountFl");
            if (this.UnitPrcCalcDiv != target.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.StdUnitPrice != target.StdUnitPrice) resList.Add("StdUnitPrice");
            if (this.UnitPriceTaxExcFl != target.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (this.UnitPriceTaxIncFl != target.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (this.ListPriceTaxIncFl != target.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.SalesUnitCostTaxIncFl != target.SalesUnitCostTaxIncFl) resList.Add("SalesUnitCostTaxIncFl");
            if (this.SalesUnitCostTaxExcFl != target.SalesUnitCostTaxExcFl) resList.Add("SalesUnitCostTaxExcFl");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.TaxFractionProcUnit != target.TaxFractionProcUnit) resList.Add("TaxFractionProcUnit");
            if (this.TaxFractionProcCd != target.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
            if (this.TaxRate != target.TaxRate) resList.Add("TaxRate");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- >>>>>
            if (this.PriceSelectDiv != target.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- <<<<<
            if (this.RateUpdateTimeSales != target.RateUpdateTimeSales) resList.Add("RateUpdateTimeSales"); //ADD yangyi K2014/02/09
            if (this.RateUpdateTimeUnit != target.RateUpdateTimeUnit) resList.Add("RateUpdateTimeUnit"); //ADD yangyi K2014/02/09

            return resList;
        }

        /// <summary>
        /// �P�����m�F��r����
        /// </summary>
        /// <param name="unPrcInfoConf1">��r����UnPrcInfoConf�N���X�̃C���X�^���X</param>
        /// <param name="unPrcInfoConf2">��r����UnPrcInfoConf�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConf�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( UnPrcInfoConf unPrcInfoConf1, UnPrcInfoConf unPrcInfoConf2 )
        {
            ArrayList resList = new ArrayList();
            if (unPrcInfoConf1.RateSettingDivide != unPrcInfoConf2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (unPrcInfoConf1.SectionCode != unPrcInfoConf2.SectionCode) resList.Add("SectionCode");
            if (unPrcInfoConf1.CustomerCode != unPrcInfoConf2.CustomerCode) resList.Add("CustomerCode");
            if (unPrcInfoConf1.CustomerSnm != unPrcInfoConf2.CustomerSnm) resList.Add("CustomerSnm");
            if (unPrcInfoConf1.SupplierCd != unPrcInfoConf2.SupplierCd) resList.Add("SupplierCd");
            if (unPrcInfoConf1.SupplierSnm != unPrcInfoConf2.SupplierSnm) resList.Add("SupplierSnm");
            if (unPrcInfoConf1.CustRateGrpCode != unPrcInfoConf2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (unPrcInfoConf1.GoodsMakerCd != unPrcInfoConf2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (unPrcInfoConf1.MakerName != unPrcInfoConf2.MakerName) resList.Add("MakerName");
            if (unPrcInfoConf1.GoodsNo != unPrcInfoConf2.GoodsNo) resList.Add("GoodsNo");
            if (unPrcInfoConf1.GoodsName != unPrcInfoConf2.GoodsName) resList.Add("GoodsName");
            if (unPrcInfoConf1.GoodsRateRank != unPrcInfoConf2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (unPrcInfoConf1.GoodsRateGrpCode != unPrcInfoConf2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (unPrcInfoConf1.GoodsRateGrpCodeNm != unPrcInfoConf2.GoodsRateGrpCodeNm) resList.Add("GoodsRateGrpCodeNm");
            if (unPrcInfoConf1.BLGroupCode != unPrcInfoConf2.BLGroupCode) resList.Add("BLGroupCode");
            if (unPrcInfoConf1.BLGroupName != unPrcInfoConf2.BLGroupName) resList.Add("BLGroupName");
            if (unPrcInfoConf1.BLGoodsCode != unPrcInfoConf2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (unPrcInfoConf1.BLGoodsFullName != unPrcInfoConf2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (unPrcInfoConf1.PriceApplyDate != unPrcInfoConf2.PriceApplyDate) resList.Add("PriceApplyDate");
            if (unPrcInfoConf1.CountFl != unPrcInfoConf2.CountFl) resList.Add("CountFl");
            if (unPrcInfoConf1.UnitPrcCalcDiv != unPrcInfoConf2.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
            if (unPrcInfoConf1.RateVal != unPrcInfoConf2.RateVal) resList.Add("RateVal");
            if (unPrcInfoConf1.UnPrcFracProcUnit != unPrcInfoConf2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (unPrcInfoConf1.UnPrcFracProcDiv != unPrcInfoConf2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (unPrcInfoConf1.StdUnitPrice != unPrcInfoConf2.StdUnitPrice) resList.Add("StdUnitPrice");
            if (unPrcInfoConf1.UnitPriceTaxExcFl != unPrcInfoConf2.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
            if (unPrcInfoConf1.UnitPriceTaxIncFl != unPrcInfoConf2.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");
            if (unPrcInfoConf1.ListPriceTaxIncFl != unPrcInfoConf2.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (unPrcInfoConf1.ListPriceTaxExcFl != unPrcInfoConf2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (unPrcInfoConf1.SalesUnitCostTaxIncFl != unPrcInfoConf2.SalesUnitCostTaxIncFl) resList.Add("SalesUnitCostTaxIncFl");
            if (unPrcInfoConf1.SalesUnitCostTaxExcFl != unPrcInfoConf2.SalesUnitCostTaxExcFl) resList.Add("SalesUnitCostTaxExcFl");
            if (unPrcInfoConf1.TaxationDivCd != unPrcInfoConf2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (unPrcInfoConf1.TaxFractionProcUnit != unPrcInfoConf2.TaxFractionProcUnit) resList.Add("TaxFractionProcUnit");
            if (unPrcInfoConf1.TaxFractionProcCd != unPrcInfoConf2.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
            if (unPrcInfoConf1.TaxRate != unPrcInfoConf2.TaxRate) resList.Add("TaxRate");
            if (unPrcInfoConf1.TotalAmountDispWayCd != unPrcInfoConf2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (unPrcInfoConf1.TtlAmntDspRateDivCd != unPrcInfoConf2.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (unPrcInfoConf1.BLGoodsName != unPrcInfoConf2.BLGoodsName) resList.Add("BLGoodsName");
            // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- >>>>>
            if (unPrcInfoConf1.PriceSelectDiv != unPrcInfoConf2.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (unPrcInfoConf1.SectionGuideNm != unPrcInfoConf2.SectionGuideNm) resList.Add("SectionGuideNm");
            // ----ADD 2013/01/24 ���N�n�� REDMINE#34605-------- <<<<<
            if (unPrcInfoConf1.RateUpdateTimeSales != unPrcInfoConf2.RateUpdateTimeSales) resList.Add("RateUpdateTimeSales"); //ADD yangyi K2014/02/09
            if (unPrcInfoConf1.RateUpdateTimeUnit != unPrcInfoConf2.RateUpdateTimeUnit) resList.Add("RateUpdateTimeUnit"); //ADD yangyi K2014/02/09

            return resList;
        }
    }
}
