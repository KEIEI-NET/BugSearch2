using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic; // ADD 2010/09/10

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateRlationWork
    /// <summary>
    ///                      �|���֘A���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���֘A���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2010/08/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/19  ����</br>
    /// <br>                 :   ���敪�ύX</br>
    /// <br>                 :   1:����P���@2:���㌴���@3:�d���P�� 4:�艿 5:��ƌ��� 6:��Ɣ���</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RateRlationWork : IFileHeader
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
        /// <remarks>�P����ށ{�|���ݒ�敪�i1A1,2A2���j</remarks>
        private string _unitRateSetDivCd = "";

        /// <summary>�P�����</summary>
        /// <remarks>1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���</remarks>
        private string _unitPriceKind = "";

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

        /// <summary>���i���[�J�[�R�[�h��</summary>
        private Int32 _goodsMakerNm;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i��</summary>
        private string _goodsName = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>�����ނ��g�p</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _bLGroupCode;

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
        /// <remarks>�����ݒ�/����P���A�����ݒ�/�d���P���A�艿�ݒ�/�艿</remarks>
        private Double _priceFl;

        /// <summary>�|��</summary>
        /// <remarks>�|���i�����ݒ�/�������A�d���ݒ�/�d�����j</remarks>
        private Double _rateVal;

        /// <summary>UP��</summary>
        /// <remarks>UP���i�����ݒ�/����UP���A�艿/�艿UP���j</remarks>
        private Double _upRate;

        /// <summary>�e���m�ۗ�</summary>
        /// <remarks>����P���̂�</remarks>
        private Double _grsProfitSecureRate;

        /// <summary>�P���[�������P��</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>�P���[�������敪</summary>
        /// <remarks>1:�؎̂�, 2:�l�̌ܓ�, 3:�؏グ</remarks>
        private Int32 _unPrcFracProcDiv;

        /// <summary>���i�|���O���[�v��</summary>
        /// <remarks>�����ނ��g�p</remarks>
        private string _goodsRateGrpNm = "";

        /// <summary>BL�O���[�v��</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private string _bLGroupNm = "";

        /// <summary>�}�X�^��</summary>
        private string _masterNm = "";

        /// <summary>���Ӑ於</summary>
        private string _customerNm = "";

        /// <summary>���Ӑ�|���O���[�v��</summary>
        private string _custRateGrNm = "";

        /// <summary>�d���於</summary>
        private string _supplierNm = "";

        /// <summary>�W�����i</summary>
        private double _listPrice;

        /// <summary>�d������</summary>
        private double _salesUnitCost;

        /// <summary>�C���s�t���O</summary> // ADD 2010/09/10
        private bool _updateLineFlg; // ADD 2010/09/10


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
        /// <value>�P����ށ{�|���ݒ�敪�i1A1,2A2���j</value>
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
        /// <value>1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���</value>
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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>���i���[�J�[�R�[�h���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
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
        /// <summary>���i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���v���p�e�B</br>
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
        /// <value>�����ݒ�/����P���A�����ݒ�/�d���P���A�艿�ݒ�/�艿</value>
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
        /// <value>�|���i�����ݒ�/�������A�d���ݒ�/�d�����j</value>
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

        /// public propaty name  :  UpRate
        /// <summary>UP���v���p�e�B</summary>
        /// <value>UP���i�����ݒ�/����UP���A�艿/�艿UP���j</value>
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

        /// public propaty name  :  GrsProfitSecureRate
        /// <summary>�e���m�ۗ��v���p�e�B</summary>
        /// <value>����P���̂�</value>
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
        /// <value>1:�؎̂�, 2:�l�̌ܓ�, 3:�؏グ</value>
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

        /// public propaty name  :  GoodsRateGrpNm
        /// <summary>���i�|���O���[�v���v���p�e�B</summary>
        /// <value>�����ނ��g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateGrpNm
        {
            get { return _goodsRateGrpNm; }
            set { _goodsRateGrpNm = value; }
        }

        /// public propaty name  :  BLGroupNm
        /// <summary>BL�O���[�v���v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupNm
        {
            get { return _bLGroupNm; }
            set { _bLGroupNm = value; }
        }

        /// public propaty name  :  MasterNm
        /// <summary>�}�X�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MasterNm
        {
            get { return _masterNm; }
            set { _masterNm = value; }
        }

        /// public propaty name  :  CustomerNm
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerNm
        {
            get { return _customerNm; }
            set { _customerNm = value; }
        }

        /// public propaty name  :  CustRateGrNm
        /// <summary>���Ӑ�|���O���[�v���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustRateGrNm
        {
            get { return _custRateGrNm; }
            set { _custRateGrNm = value; }
        }

        /// public propaty name  :  SupplierNm
        /// <summary>�d���於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm
        {
            get { return _supplierNm; }
            set { _supplierNm = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�W�����i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�d�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }
        // --- ADD 2010/09/10 ---------->>>>>
        /// public propaty name  :  UpdateLineFlg
        /// <summary>�C���s�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �C���s�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool UpdateLineFlg
        {
            get { return _updateLineFlg; }
            set { _updateLineFlg = value; }
        }
        // --- ADD 2010/09/10 ----------<<<<<



        /// <summary>
        /// �|���֘A���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RateRlationWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateRlationWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RateRlationWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RateRlationWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RateRlationWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RateRlationWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateRlationWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RateRlationWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RateRlationWork || graph is ArrayList || graph is RateRlationWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RateRlationWork).FullName));

            if (graph != null && graph is RateRlationWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RateRlationWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RateRlationWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RateRlationWork[])graph).Length;
            }
            else if (graph is RateRlationWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�P���|���ݒ�敪
            serInfo.MemberInfo.Add(typeof(string)); //UnitRateSetDivCd
            //�P�����
            serInfo.MemberInfo.Add(typeof(string)); //UnitPriceKind
            //�|���ݒ�敪
            serInfo.MemberInfo.Add(typeof(string)); //RateSettingDivide
            //�|���ݒ�敪�i���i�j
            serInfo.MemberInfo.Add(typeof(string)); //RateMngGoodsCd
            //�|���ݒ薼�́i���i�j
            serInfo.MemberInfo.Add(typeof(string)); //RateMngGoodsNm
            //�|���ݒ�敪�i���Ӑ�j
            serInfo.MemberInfo.Add(typeof(string)); //RateMngCustCd
            //�|���ݒ薼�́i���Ӑ�j
            serInfo.MemberInfo.Add(typeof(string)); //RateMngCustNm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i���[�J�[�R�[�h��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerNm
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���i�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���b�g��
            serInfo.MemberInfo.Add(typeof(Double)); //LotCount
            //���i�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //PriceFl
            //�|��
            serInfo.MemberInfo.Add(typeof(Double)); //RateVal
            //UP��
            serInfo.MemberInfo.Add(typeof(Double)); //UpRate
            //�e���m�ۗ�
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitSecureRate
            //�P���[�������P��
            serInfo.MemberInfo.Add(typeof(Double)); //UnPrcFracProcUnit
            //�P���[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcFracProcDiv
            //���i�|���O���[�v��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateGrpNm
            //BL�O���[�v��
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupNm
            //BL�R�[�h��
            serInfo.MemberInfo.Add(typeof(string)); //MasterNm
            //���Ӑ於
            serInfo.MemberInfo.Add(typeof(string)); //CustomerNm
            //���Ӑ�|���O���[�v��
            serInfo.MemberInfo.Add(typeof(string)); //CustRateGrNm
            //�d���於
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm
            //�W�����i
            serInfo.MemberInfo.Add(typeof(double)); //ListPrice
            //�d������
            serInfo.MemberInfo.Add(typeof(double)); //SalesUnitCost


            serInfo.Serialize(writer, serInfo);
            if (graph is RateRlationWork)
            {
                RateRlationWork temp = (RateRlationWork)graph;

                SetRateRlationWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RateRlationWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RateRlationWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RateRlationWork temp in lst)
                {
                    SetRateRlationWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RateRlationWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 42;

        /// <summary>
        ///  RateRlationWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateRlationWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRateRlationWork(System.IO.BinaryWriter writer, RateRlationWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�P���|���ݒ�敪
            writer.Write(temp.UnitRateSetDivCd);
            //�P�����
            writer.Write(temp.UnitPriceKind);
            //�|���ݒ�敪
            writer.Write(temp.RateSettingDivide);
            //�|���ݒ�敪�i���i�j
            writer.Write(temp.RateMngGoodsCd);
            //�|���ݒ薼�́i���i�j
            writer.Write(temp.RateMngGoodsNm);
            //�|���ݒ�敪�i���Ӑ�j
            writer.Write(temp.RateMngCustCd);
            //�|���ݒ薼�́i���Ӑ�j
            writer.Write(temp.RateMngCustNm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i���[�J�[�R�[�h��
            writer.Write(temp.GoodsMakerNm);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i��
            writer.Write(temp.GoodsName);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���i�|���O���[�v�R�[�h
            writer.Write(temp.GoodsRateGrpCode);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���b�g��
            writer.Write(temp.LotCount);
            //���i�i�����j
            writer.Write(temp.PriceFl);
            //�|��
            writer.Write(temp.RateVal);
            //UP��
            writer.Write(temp.UpRate);
            //�e���m�ۗ�
            writer.Write(temp.GrsProfitSecureRate);
            //�P���[�������P��
            writer.Write(temp.UnPrcFracProcUnit);
            //�P���[�������敪
            writer.Write(temp.UnPrcFracProcDiv);
            //���i�|���O���[�v��
            writer.Write(temp.GoodsRateGrpNm);
            //BL�O���[�v��
            writer.Write(temp.BLGroupNm);
            //�}�X�^��
            writer.Write(temp.MasterNm);
            //���Ӑ於
            writer.Write(temp.CustomerNm);
            //���Ӑ�|���O���[�v��
            writer.Write(temp.CustRateGrNm);
            //�d���於
            writer.Write(temp.SupplierNm);
            //�W�����i
            writer.Write(temp.ListPrice);
            //�d������
            writer.Write(temp.SalesUnitCost);

        }

        /// <summary>
        ///  RateRlationWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RateRlationWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateRlationWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RateRlationWork GetRateRlationWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RateRlationWork temp = new RateRlationWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�P���|���ݒ�敪
            temp.UnitRateSetDivCd = reader.ReadString();
            //�P�����
            temp.UnitPriceKind = reader.ReadString();
            //�|���ݒ�敪
            temp.RateSettingDivide = reader.ReadString();
            //�|���ݒ�敪�i���i�j
            temp.RateMngGoodsCd = reader.ReadString();
            //�|���ݒ薼�́i���i�j
            temp.RateMngGoodsNm = reader.ReadString();
            //�|���ݒ�敪�i���Ӑ�j
            temp.RateMngCustCd = reader.ReadString();
            //�|���ݒ薼�́i���Ӑ�j
            temp.RateMngCustNm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i���[�J�[�R�[�h��
            temp.GoodsMakerNm = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i��
            temp.GoodsName = reader.ReadString();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���i�|���O���[�v�R�[�h
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���b�g��
            temp.LotCount = reader.ReadDouble();
            //���i�i�����j
            temp.PriceFl = reader.ReadDouble();
            //�|��
            temp.RateVal = reader.ReadDouble();
            //UP��
            temp.UpRate = reader.ReadDouble();
            //�e���m�ۗ�
            temp.GrsProfitSecureRate = reader.ReadDouble();
            //�P���[�������P��
            temp.UnPrcFracProcUnit = reader.ReadDouble();
            //�P���[�������敪
            temp.UnPrcFracProcDiv = reader.ReadInt32();
            //���i�|���O���[�v��
            temp.GoodsRateGrpNm = reader.ReadString();
            //BL�O���[�v��
            temp.BLGroupNm = reader.ReadString();
            //�}�X�^��
            temp.MasterNm = reader.ReadString();
            //���Ӑ於
            temp.CustomerNm = reader.ReadString();
            //���Ӑ�|���O���[�v��
            temp.CustRateGrNm = reader.ReadString();
            //�d���於
            temp.SupplierNm = reader.ReadString();
            //�W�����i
            temp.ListPrice = reader.ReadDouble();
            //�d������
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
        /// <returns>RateRlationWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RateRlationWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RateRlationWork temp = GetRateRlationWork(reader, serInfo);
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
                    retValue = (RateRlationWork[])lst.ToArray(typeof(RateRlationWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
