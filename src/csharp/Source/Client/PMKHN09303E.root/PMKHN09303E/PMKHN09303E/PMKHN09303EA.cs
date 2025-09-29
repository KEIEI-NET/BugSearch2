using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Rate
    /// <summary>
    ///                      �|���}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class Rate
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�P���|���ݒ�敪</summary>
        /// <remarks>�P����ށ{�|���ݒ�敪�{�V���敪�i1A10,2A21���j</remarks>
        private string _unitRateSetDivCd = "";

        /// <summary>�P�����</summary>
        /// <remarks>1:����P���@2:���㌴���@3:�d���P�� 4:�艿</remarks>
        private string _unitPriceKind = "1";

        /// <summary>�|���ݒ�敪</summary>
        /// <remarks>A1,A2��</remarks>
        private string _rateSettingDivide = "";

        /// <summary>�|���ݒ�敪�i���i�j</summary>
        /// <remarks>A�`O�@</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>�|���ݒ薼�́i���i�j</summary>
        /// <remarks>A�F "���[�J�[�{���i"</remarks>
        private string _rateMngGoodsNm = "";

        /// <summary>�|���ݒ�敪�i���Ӑ�j</summary>
        /// <remarks>1�`9�@</remarks>
        private string _rateMngCustCd = "";

        /// <summary>�|���ݒ薼�́i���Ӑ�j</summary>
        /// <remarks>1�F "���Ӑ�{�d����"</remarks>
        private string _rateMngCustNm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i�|�������N</summary>
        private string _goodsRateRank = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���b�g��</summary>
        /// <remarks>�\�����ʂ̓��b�g���̏����Ƃ���</remarks>
        private Double _lotCount;

        /// <summary>���i�i�����j</summary>
        /// <remarks>���΂�l</remarks>
        private Double _priceFl;

        /// <summary>�|��</summary>
        /// <remarks>�|��</remarks>
        private Double _rateVal;

        /// <summary>�P���[�������P��</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>�P���[�������敪</summary>
        private Int32 _unPrcFracProcDiv;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>UP��</summary>
        private Double _upRate;

        /// <summary>�e���m�ۗ�</summary>
        private Double _grsProfitSecureRate;

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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

        /// public propaty name  :  UnitRateSetDivCd
        /// <summary>�P���|���ݒ�敪�v���p�e�B</summary>
        /// <value>�P����ށ{�|���ݒ�敪�{�V���敪�i1A10,2A21���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���|���ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitRateSetDivCd
        {
            get { return _unitRateSetDivCd; }
            set { _unitRateSetDivCd = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>�P����ރv���p�e�B</summary>
        /// <value>1:����P���@2:���㌴���@3:�d���P�� 4:�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitPriceKind
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>�|���ݒ�敪�v���p�e�B</summary>
        /// <value>A1,A2��</value>
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

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>�|���ݒ�敪�i���i�j�v���p�e�B</summary>
        /// <value>A�`O�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngGoodsNm
        /// <summary>�|���ݒ薼�́i���i�j�v���p�e�B</summary>
        /// <value>A�F "���[�J�[�{���i"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ薼�́i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsNm
        {
            get { return _rateMngGoodsNm; }
            set { _rateMngGoodsNm = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>�|���ݒ�敪�i���Ӑ�j�v���p�e�B</summary>
        /// <value>1�`9�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i���Ӑ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }

        /// public propaty name  :  RateMngCustNm
        /// <summary>�|���ݒ薼�́i���Ӑ�j�v���p�e�B</summary>
        /// <value>1�F "���Ӑ�{�d����"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ薼�́i���Ӑ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustNm
        {
            get { return _rateMngCustNm; }
            set { _rateMngCustNm = value; }
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

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
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

        /// public propaty name  :  LotCount
        /// <summary>���b�g���v���p�e�B</summary>
        /// <value>�\�����ʂ̓��b�g���̏����Ƃ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���b�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double LotCount
        {
            get { return _lotCount; }
            set { _lotCount = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>���i�i�����j�v���p�e�B</summary>
        /// <value>���΂�l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
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

        /// public property name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
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

        /// public property name  :  BLGroupCode
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

        /// public property name  :  UpRate
        /// <summary>UP���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// public property name  :  GrsProfitSecureRate
        /// <summary>�e���m�ۗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���m�ۗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrsProfitSecureRate
        {
            get { return _grsProfitSecureRate; }
            set { _grsProfitSecureRate = value; }
        }

        /// <summary>
        /// �|���}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>Rate�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Rate�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Rate()
        {
        }

        /// <summary>
        /// �|���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="unitRateSetDivCd">�P���|���ݒ�敪(�P����ށ{�|���ݒ�敪�{�V���敪�i1A10,2A21���j)</param>
        /// <param name="unitPriceKind">�P�����(1:����P���@2:���㌴���@3:�d���P�� 4:�艿)</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪(A1,A2��)</param>
        /// <param name="rateMngGoodsCd">�|���ݒ�敪�i���i�j(A�`O)</param>
        /// <param name="rateMngGoodsNm">�|���ݒ薼�́i���i�j(A�F "���[�J�[�{���i")</param>
        /// <param name="rateMngCustCd">�|���ݒ�敪�i���Ӑ�j(1�`9)</param>
        /// <param name="rateMngCustNm">�|���ݒ薼�́i���Ӑ�j(1�F "���Ӑ�{�d����")</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsRateRank">���i�|�������N</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="customerCode">>���Ӑ�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="lotCount">���b�g��(�\�����ʂ̓��b�g���̏����Ƃ���)</param>
        /// <param name="priceFl">���i�i�����j(���΂�l)</param>
        /// <param name="rateVal">�|��</param>
        /// <param name="unPrcFracProcUnit">�P���[�������P��</param>
        /// <param name="unPrcFracProcDiv">�P���[�������敪</param>
        /// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="upRate">UP��</param>
        /// <param name="grsProfitSecureRate">�e���m�ۗ�</param>
        /// <returns>Rate�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Rate�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Rate(
                            DateTime createDateTime,
                            DateTime updateDateTime,
                            string enterpriseCode,
                            Guid fileHeaderGuid,
                            string updEmployeeCode,
                            string updAssemblyId1,
                            string updAssemblyId2,
                            Int32 logicalDeleteCode,
                            string sectionCode,
                            string unitRateSetDivCd,
                            string unitPriceKind,
                            string rateSettingDivide,
                            string rateMngGoodsCd,
                            string rateMngGoodsNm,
                            string rateMngCustCd,
                            string rateMngCustNm,
                            Int32 goodsMakerCd,
                            string goodsNo,
                            string goodsRateRank,
                            Int32 bLGoodsCode,
                            Int32 customerCode,
                            Int32 custRateGrpCode,
                            Int32 supplierCd,
                            Double lotCount,
                            Double priceFl,
                            Double rateVal,
                            Double unPrcFracProcUnit,
                            Int32 goodsRateGrpCode,
                            Int32 bLGroupCode,
                            Double upRate,
                            Double grsProfitSecureRate,
                            Int32 unPrcFracProcDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._unitRateSetDivCd = unitRateSetDivCd;
            this._unitPriceKind = unitPriceKind;
            this._rateSettingDivide = rateSettingDivide;
            this._rateMngGoodsCd = rateMngGoodsCd;
            this._rateMngGoodsNm = rateMngGoodsNm;
            this._rateMngCustCd = rateMngCustCd;
            this._rateMngCustNm = rateMngCustNm;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsRateRank = goodsRateRank;
            this._bLGoodsCode = bLGoodsCode;
            this._customerCode = customerCode;
            this._custRateGrpCode = custRateGrpCode;
            this._supplierCd = supplierCd;
            this._lotCount = lotCount;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._bLGroupCode = bLGroupCode;
            this._upRate = upRate;
            this._grsProfitSecureRate = grsProfitSecureRate;
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <returns>Rate�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Rate�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Rate Clone()
        {
            return new Rate(
                                    this._createDateTime,
                                    this._updateDateTime,
                                    this._enterpriseCode,
                                    this._fileHeaderGuid,
                                    this._updEmployeeCode,
                                    this._updAssemblyId1,
                                    this._updAssemblyId2,
                                    this._logicalDeleteCode,
                                    this._sectionCode,
                                    this._unitRateSetDivCd,
                                    this._unitPriceKind,
                                    this._rateSettingDivide,
                                    this._rateMngGoodsCd,
                                    this._rateMngGoodsNm,
                                    this._rateMngCustCd,
                                    this._rateMngCustNm,
                                    this._goodsMakerCd,
                                    this._goodsNo,
                                    this._goodsRateRank,
                                    this._bLGoodsCode,
                                    this._customerCode,
                                    this._custRateGrpCode,
                                    this._supplierCd,
                                    this._lotCount,
                                    this._priceFl,
                                    this._rateVal,
                                    this._unPrcFracProcUnit,
                                    this._goodsRateGrpCode,
                                    this._bLGroupCode,
                                    this._upRate,
                                    this._grsProfitSecureRate,
                                    this._unPrcFracProcDiv);
        }

        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Rate�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Rate�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(Rate target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                && (this.UpdateDateTime == target.UpdateDateTime)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.FileHeaderGuid == target.FileHeaderGuid)
                && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                && (this.SectionCode == target.SectionCode)
                && (this.UnitRateSetDivCd == target.UnitRateSetDivCd)
                && (this.UnitPriceKind == target.UnitPriceKind)
                && (this.RateSettingDivide == target.RateSettingDivide)
                && (this.RateMngGoodsCd == target.RateMngGoodsCd)
                && (this.RateMngGoodsNm == target.RateMngGoodsNm)
                && (this.RateMngCustCd == target.RateMngCustCd)
                && (this.RateMngCustNm == target.RateMngCustNm)
                && (this.GoodsMakerCd == target.GoodsMakerCd)
                && (this.GoodsNo == target.GoodsNo)
                && (this.GoodsRateRank == target.GoodsRateRank)
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.CustomerCode == target.CustomerCode)
                && (this.CustRateGrpCode == target.CustRateGrpCode)
                && (this.SupplierCd == target.SupplierCd)
                && (this.LotCount == target.LotCount)
                && (this.PriceFl == target.PriceFl)
                && (this.RateVal == target.RateVal)
                && (this.UnPrcFracProcUnit == target.UnPrcFracProcUnit)
                && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                && (this.BLGroupCode == target.BLGroupCode)
                && (this.UpRate == target.UpRate)
                && (this.GrsProfitSecureRate == target.GrsProfitSecureRate)
                && (this.UnPrcFracProcDiv == target.UnPrcFracProcDiv));
        }

        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="rate1">
        ///                    ��r����Rate�N���X�̃C���X�^���X
        /// </param>
        /// <param name="rate2">��r����Rate�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Rate�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(Rate rate1, Rate rate2)
        {
            return ((rate1.CreateDateTime == rate2.CreateDateTime)
                && (rate1.UpdateDateTime == rate2.UpdateDateTime)
                && (rate1.EnterpriseCode == rate2.EnterpriseCode)
                && (rate1.FileHeaderGuid == rate2.FileHeaderGuid)
                && (rate1.UpdEmployeeCode == rate2.UpdEmployeeCode)
                && (rate1.UpdAssemblyId1 == rate2.UpdAssemblyId1)
                && (rate1.UpdAssemblyId2 == rate2.UpdAssemblyId2)
                && (rate1.LogicalDeleteCode == rate2.LogicalDeleteCode)
                && (rate1.SectionCode == rate2.SectionCode)
                && (rate1.UnitRateSetDivCd == rate2.UnitRateSetDivCd)
                && (rate1.UnitPriceKind == rate2.UnitPriceKind)
                && (rate1.RateSettingDivide == rate2.RateSettingDivide)
                && (rate1.RateMngGoodsCd == rate2.RateMngGoodsCd)
                && (rate1.RateMngGoodsNm == rate2.RateMngGoodsNm)
                && (rate1.RateMngCustCd == rate2.RateMngCustCd)
                && (rate1.RateMngCustNm == rate2.RateMngCustNm)
                && (rate1.GoodsMakerCd == rate2.GoodsMakerCd)
                && (rate1.GoodsNo == rate2.GoodsNo)
                && (rate1.GoodsRateRank == rate2.GoodsRateRank)
                && (rate1.BLGoodsCode == rate2.BLGoodsCode)
                && (rate1.CustomerCode == rate2.CustomerCode)
                && (rate1.CustRateGrpCode == rate2.CustRateGrpCode)
                && (rate1.SupplierCd == rate2.SupplierCd)
                && (rate1.LotCount == rate2.LotCount)
                && (rate1.PriceFl == rate2.PriceFl)
                && (rate1.RateVal == rate2.RateVal)
                && (rate1.UnPrcFracProcUnit == rate2.UnPrcFracProcUnit)
                && (rate1.GoodsRateGrpCode == rate2.GoodsRateGrpCode)
                && (rate1.BLGroupCode == rate2.BLGroupCode)
                && (rate1.UpRate == rate2.UpRate)
                && (rate1.GrsProfitSecureRate == rate2.GrsProfitSecureRate)
                && (rate1.UnPrcFracProcDiv == rate2.UnPrcFracProcDiv));
        }
        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Rate�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Rate�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(Rate target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UnitRateSetDivCd != target.UnitRateSetDivCd) resList.Add("UnitRateSetDivCd");
            if (this.UnitPriceKind != target.UnitPriceKind) resList.Add("UnitPriceKind");
            if (this.RateSettingDivide != target.RateSettingDivide) resList.Add("RateSettingDivide");
            if (this.RateMngGoodsCd != target.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (this.RateMngGoodsNm != target.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (this.RateMngCustCd != target.RateMngCustCd) resList.Add("RateMngCustCd");
            if (this.RateMngCustNm != target.RateMngCustNm) resList.Add("RateMngCustNm");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.LotCount != target.LotCount) resList.Add("LotCount");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.UpRate != target.UpRate) resList.Add("UpRate");
            if (this.GrsProfitSecureRate != target.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");

            return resList;
        }

        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="rate1">��r����Rate�N���X�̃C���X�^���X</param>
        /// <param name="rate2">��r����Rate�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Rate�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(Rate rate1, Rate rate2)
        {
            ArrayList resList = new ArrayList();
            if (rate1.CreateDateTime != rate2.CreateDateTime) resList.Add("CreateDateTime");
            if (rate1.UpdateDateTime != rate2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rate1.EnterpriseCode != rate2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rate1.FileHeaderGuid != rate2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (rate1.UpdEmployeeCode != rate2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (rate1.UpdAssemblyId1 != rate2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (rate1.UpdAssemblyId2 != rate2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (rate1.LogicalDeleteCode != rate2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rate1.SectionCode != rate2.SectionCode) resList.Add("SectionCode");
            if (rate1.UnitRateSetDivCd != rate2.UnitRateSetDivCd) resList.Add("UnitRateSetDivCd");
            if (rate1.UnitPriceKind != rate2.UnitPriceKind) resList.Add("UnitPriceKind");
            if (rate1.RateSettingDivide != rate2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (rate1.RateMngGoodsCd != rate2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (rate1.RateMngGoodsNm != rate2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (rate1.RateMngCustCd != rate2.RateMngCustCd) resList.Add("RateMngCustCd");
            if (rate1.RateMngCustNm != rate2.RateMngCustNm) resList.Add("RateMngCustNm");
            if (rate1.GoodsMakerCd != rate2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (rate1.GoodsNo != rate2.GoodsNo) resList.Add("GoodsNo");
            if (rate1.GoodsRateRank != rate2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (rate1.BLGoodsCode != rate2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (rate1.CustomerCode != rate2.CustomerCode) resList.Add("CustomerCode");
            if (rate1.CustRateGrpCode != rate2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (rate1.SupplierCd != rate2.SupplierCd) resList.Add("SupplierCd");
            if (rate1.LotCount != rate2.LotCount) resList.Add("LotCount");
            if (rate1.PriceFl != rate2.PriceFl) resList.Add("PriceFl");
            if (rate1.RateVal != rate2.RateVal) resList.Add("RateVal");
            if (rate1.UnPrcFracProcUnit != rate2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (rate1.UnPrcFracProcDiv != rate2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (rate1.GoodsRateGrpCode != rate2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (rate1.BLGroupCode != rate2.BLGroupCode) resList.Add("BLGroupCode");
            if (rate1.UpRate != rate2.UpRate) resList.Add("UpRate");
            if (rate1.GrsProfitSecureRate != rate2.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");

            return resList;
        }
    }
}
