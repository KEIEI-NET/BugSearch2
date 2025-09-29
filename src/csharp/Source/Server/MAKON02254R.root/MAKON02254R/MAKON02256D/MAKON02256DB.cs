using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockConfWork
    /// <summary>
    ///                      �d���m�F�\(����)�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���m�F�\(����)�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/30  �c��</br>
    /// <br>                 :   Partsman.NS�Ή�</br>
    /// <br>                 :   �E���_�K�C�h���́����_�K�C�h���̂ɕύX</br>
    /// <br>                 :   �E���Ӑ�R�[�h�E���́��d����R�[�h�E���̂ɕύX</br>
    /// <br>                 :   �E���i�敪�֘A�A�P�ʃR�[�h�E���́A�������ԍ��̍��ڍ폜</br>
    /// <br>                 :   �EUOE���}�[�N�A�ύX�O�艿�A�ύX�O�d���P���̒ǉ�</br>
    /// <br>                 :   �E����`�[�ԍ��A���Ӑ�R�[�h�̒ǉ�</br>
    /// <br>Update Note      :   2020/02/27 3H ����</br>
    /// <br>                 :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Update Note      : 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j </br>
    /// <br>Date             : 2022/09/28</br>
    /// <br>                 : ���O </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockConfWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�c�Ə��R�[�h</remarks>
        private string _stockSectionCd = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���͓�</summary>
        /// <remarks>���͓��t</remarks>
        private Int32 _inputDay;

        /// <summary>���ד�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _arrivalGoodsDay;

        /// <summary>�d����</summary>
        /// <remarks>�`�[���t</remarks>
        private DateTime _stockDate;

        /// <summary>�d���v����t</summary>
        /// <remarks>�v���</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�@���d��SEQ</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�d���s�ԍ�</summary>
        /// <remarks>���׍s��</remarks>
        private Int32 _stockRowNo;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>10:�d��,20:�ԕi</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accPayDivCd;

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>���Е��ރR�[�h</summary>
        /// <remarks>���Е���</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        /// <remarks>���Е��ޖ�</remarks>
        private string _enterpriseGanreName = "";

        /// <summary>�d���S���҃R�[�h</summary>
        /// <remarks>�S���҃R�[�h</remarks>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        /// <remarks>�S���Җ�</remarks>
        private string _stockAgentName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>���i�R�[�h</remarks>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        /// <remarks>���i��</remarks>
        private string _goodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�[�R�[�h����</remarks>
        private string _makerName = "";

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>0:���,1:�݌�</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q��</remarks>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�q��</remarks>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>BL�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        /// <remarks>BL�R�[�h��</remarks>
        private string _bLGoodsFullName = "";

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>�ԓ`�敪</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�d���`�[���ה��l1</summary>
        /// <remarks>���l</remarks>
        private string _stockDtiSlipNote1 = "";

        /// <summary>�d����</summary>
        /// <remarks>�d����</remarks>
        private Double _stockCount;

        /// <summary>�ύX�O�艿</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfListPrice;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�ύX�O�d���P���i�����j</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�d���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���P���i�ō��C�����j</summary>
        private Double _stockUnitTaxPriceFl;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        /// <remarks>�d�����z</remarks>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z�i�ō��݁j</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�����</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���旪��</summary>
        /// <remarks>�x���於</remarks>
        private string _payeeSnm = "";

        /// <summary>�d���`�[���l1</summary>
        private string _supplierSlipNote1 = "";

        /// <summary>�d���`�[���l2</summary>
        private string _supplierSlipNote2 = "";

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationCode;

        /// <summary>�d���`�[�敪�i���ׁj</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>�d�����z�v�i�Ŕ����j[�`�[]</summary>
        /// <remarks>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>�d�����z����Ŋz[�`�[]</summary>
        /// <remarks>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</remarks>
        private Int64 _stockPriceConsTaxDen;

        /// <summary>�d���l�����z�v�i�Ŕ����j[�`�[]</summary>
        /// <remarks>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</remarks>
        private Int64 _stckDisTtlTaxExc;

        /// <summary>�d���l������Ŋz�i�O�Łj[�`�[]</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _stockDisOutTax;

        /// <summary>�d���l������Ŋz�i���Łj[�`�[]</summary>
        /// <remarks>���ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _stckDisTtlTaxInclu;

        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary>�d�������Őŗ�</summary>
        private Double _supplierConsTaxRate;

        // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        /// <summary>�d�����׉ېő��݃t���O</summary>
        private Boolean _taxRateExistFlag;

        /// public propaty name  :  TaxRateExistFlag
        /// <summary>�d�����׉ېő��݃t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �d�����׉ېő��݃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean TaxRateExistFlag
        {
            get { return _taxRateExistFlag; }
            set { _taxRateExistFlag = value; }
        }
        // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>�d�������Őŗ��v���p�e�B</summary>
        /// <value>�d�������Őŗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

        /// public propaty name  :  StockSectionCd
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�c�Ə��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
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

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>���͓��t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>�`�[���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockAddUpADate
        /// <summary>�d���v����t�v���p�e�B</summary>
        /// <value>�v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
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
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�@���d��SEQ</value>
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
        /// <value>���׍s��</value>
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

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
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

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,20:�ԕi</value>
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

        /// public propaty name  :  AccPayDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>UserOrderEntory</value>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// <value>���Е���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// <value>���Е��ޖ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// <value>�S���҃R�[�h</value>
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
        /// <value>�S���Җ�</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>���i�R�[�h</value>
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
        /// <value>���i��</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>���[�J�[�R�[�h</value>
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
        /// <value>���[�J�[�R�[�h����</value>
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

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:���,1:�݌�</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q��</value>
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
        /// <value>�q��</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>BL�R�[�h</value>
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
        /// <value>BL�R�[�h��</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>�ԓ`�敪</value>
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

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>�d���`�[���ה��l1�v���p�e�B</summary>
        /// <value>���l</value>
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

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>�d����</value>
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

        /// public propaty name  :  BfListPrice
        /// <summary>�ύX�O�艿�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
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

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�d���P���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�d���P��</value>
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

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�d�����z</value>
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

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�����</value>
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

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</value>
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

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// <value>�x���於</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>�d���`�[���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>�d���`�[���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
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

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
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

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
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

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>�d�����z�v�i�Ŕ����j[�`�[]�v���p�e�B</summary>
        /// <value>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v�i�Ŕ����j[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  StockPriceConsTaxDen
        /// <summary>�d�����z����Ŋz[�`�[]�v���p�e�B</summary>
        /// <value>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTaxDen
        {
            get { return _stockPriceConsTaxDen; }
            set { _stockPriceConsTaxDen = value; }
        }

        /// public propaty name  :  StckDisTtlTaxExc
        /// <summary>�d���l�����z�v�i�Ŕ����j[�`�[]�v���p�e�B</summary>
        /// <value>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l�����z�v�i�Ŕ����j[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxExc
        {
            get { return _stckDisTtlTaxExc; }
            set { _stckDisTtlTaxExc = value; }
        }

        /// public propaty name  :  StockDisOutTax
        /// <summary>�d���l������Ŋz�i�O�Łj[�`�[]�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l������Ŋz�i�O�Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockDisOutTax
        {
            get { return _stockDisOutTax; }
            set { _stockDisOutTax = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>�d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
        }


        /// <summary>
        /// �d���m�F�\(����)�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockConfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockConfWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockConfWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockConfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programer        :   2020/02/27 3H ����</br>
    /// </remarks>
    public class StockConfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockConfWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockConfWork || graph is ArrayList || graph is StockConfWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockConfWork).FullName));

            if (graph != null && graph is StockConfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockConfWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockConfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockConfWork[])graph).Length;
            }
            else if (graph is StockConfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�d���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //���Е��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //�d���݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�d���`�[���ה��l1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�ύX�O�艿
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�ύX�O�d���P���i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�d���`�[���l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //�d���`�[���l2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //�d���`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //�d�����z�v�i�Ŕ����j[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�d�����z����Ŋz[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTaxDen
            //�d���l�����z�v�i�Ŕ����j[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc
            //�d���l������Ŋz�i�O�Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDisOutTax
            //�d���l������Ŋz�i���Łj[�`�[]
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            //�d�������Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<

            serInfo.MemberInfo.Add(typeof(Boolean));// ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j

            serInfo.Serialize(writer, serInfo);
            if (graph is StockConfWork)
            {
                StockConfWork temp = (StockConfWork)graph;

                SetStockConfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockConfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockConfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockConfWork temp in lst)
                {
                    SetStockConfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockConfWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 57; // --- DEL 3H ���� 2020/02/27
        // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        //private const int currentMemberCount = 58; // --- ADD 3H ���� 2020/02/27
        private const int currentMemberCount = 59;
        // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
        /// <summary>
        ///  StockConfWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
        /// </remarks>
        private void SetStockConfWork(System.IO.BinaryWriter writer, StockConfWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.StockSectionCd);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���͓�
            writer.Write(temp.InputDay);
            //���ד�
            writer.Write(temp.ArrivalGoodsDay);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���v����t
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�d���s�ԍ�
            writer.Write(temp.StockRowNo);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //���|�敪
            writer.Write(temp.AccPayDivCd);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���Е��ޖ���
            writer.Write(temp.EnterpriseGanreName);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //�d���݌Ɏ�񂹋敪
            writer.Write(temp.StockOrderDivCd);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�d���`�[���ה��l1
            writer.Write(temp.StockDtiSlipNote1);
            //�d����
            writer.Write(temp.StockCount);
            //�ύX�O�艿
            writer.Write(temp.BfListPrice);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�ύX�O�d���P���i�����j
            writer.Write(temp.BfStockUnitPriceFl);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���P���i�ō��C�����j
            writer.Write(temp.StockUnitTaxPriceFl);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z�i�ō��݁j
            writer.Write(temp.StockPriceTaxInc);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�d���`�[���l1
            writer.Write(temp.SupplierSlipNote1);
            //�d���`�[���l2
            writer.Write(temp.SupplierSlipNote2);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�ېŋ敪
            writer.Write(temp.TaxationCode);
            //�d���`�[�敪�i���ׁj
            writer.Write(temp.StockSlipCdDtl);
            //�d�����z�v�i�Ŕ����j[�`�[]
            writer.Write(temp.StockTtlPricTaxExc);
            //�d�����z����Ŋz[�`�[]
            writer.Write(temp.StockPriceConsTaxDen);
            //�d���l�����z�v�i�Ŕ����j[�`�[]
            writer.Write(temp.StckDisTtlTaxExc);
            //�d���l������Ŋz�i�O�Łj[�`�[]
            writer.Write(temp.StockDisOutTax);
            //�d���l������Ŋz�i���Łj[�`�[]
            writer.Write(temp.StckDisTtlTaxInclu);
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            //�d�������Őŗ�
            writer.Write(temp.SupplierConsTaxRate);
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            writer.Write(temp.TaxRateExistFlag); // ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
        }

        /// <summary>
        ///  StockConfWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockConfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
        /// </remarks>
        private StockConfWork GetStockConfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockConfWork temp = new StockConfWork();

            //���_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���͓�
            temp.InputDay = reader.ReadInt32();
            //���ד�
            temp.ArrivalGoodsDay = reader.ReadInt32();
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���v����t
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�d���s�ԍ�
            temp.StockRowNo = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //���|�敪
            temp.AccPayDivCd = reader.ReadInt32();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���Е��ޖ���
            temp.EnterpriseGanreName = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //�d���݌Ɏ�񂹋敪
            temp.StockOrderDivCd = reader.ReadInt32();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�d���`�[���ה��l1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�ύX�O�艿
            temp.BfListPrice = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�ύX�O�d���P���i�����j
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���P���i�ō��C�����j
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z�i�ō��݁j
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�d���`�[���l1
            temp.SupplierSlipNote1 = reader.ReadString();
            //�d���`�[���l2
            temp.SupplierSlipNote2 = reader.ReadString();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�ېŋ敪
            temp.TaxationCode = reader.ReadInt32();
            //�d���`�[�敪�i���ׁj
            temp.StockSlipCdDtl = reader.ReadInt32();
            //�d�����z�v�i�Ŕ����j[�`�[]
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�d�����z����Ŋz[�`�[]
            temp.StockPriceConsTaxDen = reader.ReadInt64();
            //�d���l�����z�v�i�Ŕ����j[�`�[]
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            //�d���l������Ŋz�i�O�Łj[�`�[]
            temp.StockDisOutTax = reader.ReadInt64();
            //�d���l������Ŋz�i���Łj[�`�[]
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            //�d�������Őŗ�
            temp.SupplierConsTaxRate = reader.ReadDouble();
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            temp.TaxRateExistFlag = reader.ReadBoolean();// ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j

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
        /// <returns>StockConfWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockConfWork temp = GetStockConfWork(reader, serInfo);
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
                    retValue = (StockConfWork[])lst.ToArray(typeof(StockConfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
