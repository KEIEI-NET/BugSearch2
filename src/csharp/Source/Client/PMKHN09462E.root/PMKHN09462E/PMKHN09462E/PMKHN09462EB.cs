//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsRateSetSearchResult
    /// <summary>
    ///                      �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsRateSetSearchResult
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

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

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

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�y�D�ǐݒ�}�X�^�z</remarks>
        private Int32 _prmGoodsMGroup;

        /// <summary>BL�R�[�h</summary>
        /// <remarks>�y�D�ǐݒ�}�X�^�z</remarks>
        private Int32 _prmTbsPartsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�y�D�ǐݒ�}�X�^�z</remarks>
        private Int32 _prmPartsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�y���i�Ǘ����}�X�^�z</remarks>
        private Int32 _goodsSupplierCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        /// <summary>�W�����i</summary>
        private double _listPrice;

        /// <summary>�d������</summary>
        private double _salesUnitCost;

        /// <summary>���i�i�����j</summary>
        /// <remarks>�����ݒ�/����P���A�����ݒ�/�d���P���A�艿�ݒ�/�艿</remarks>
        private Double _bfPriceFl;

        /// <summary>�|��</summary>
        /// <remarks>�|���i�����ݒ�/�������A�d���ݒ�/�d�����j</remarks>
        private Double _bfRateVal;

        /// <summary>UP��</summary>
        /// <remarks>UP���i�����ݒ�/����UP���A�艿/�艿UP���j</remarks>
        private Double _bfUpRate;

        /// <summary>�e���m�ۗ�</summary>
        /// <remarks>����P���̂�</remarks>
        private Double _bfGrsProfitSecureRate;

        /// <summary>�X�V�敪</summary>
        /// <remarks>�X�V�敪</remarks>
        private int _updateDiv;

        /// <summary>BL�O���[�v�R�[�h(�|���}�X�^)</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _ratebLGroupCode;

        /// <summary>BL���i�R�[�h(�|���}�X�^)</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _ratebLGoodsCode;

        /// <summary>�_���폜�敪(���i�}�X�^)</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _goodsLogicalDeleteCode;

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

        /// public propaty name  :  PrmGoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�y�D�ǐݒ�}�X�^�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmGoodsMGroup
        {
            get { return _prmGoodsMGroup; }
            set { _prmGoodsMGroup = value; }
        }

        /// public propaty name  :  PrmTbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>�y�D�ǐݒ�}�X�^�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmTbsPartsCode
        {
            get { return _prmTbsPartsCode; }
            set { _prmTbsPartsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  PrmPartsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�y�D�ǐݒ�}�X�^�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmPartsMakerCd
        {
            get { return _prmPartsMakerCd; }
            set { _prmPartsMakerCd = value; }
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

        /// public propaty name  :  GoodsSupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�y���i�Ǘ����}�X�^�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsSupplierCd
        {
            get { return _goodsSupplierCd; }
            set { _goodsSupplierCd = value; }
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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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

        /// public propaty name  :  PriceFl
        /// <summary>���i�i�����j�v���p�e�B</summary>
        /// <value>�����ݒ�/����P���A�����ݒ�/�d���P���A�艿�ݒ�/�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfPriceFl
        {
            get { return _bfPriceFl; }
            set { _bfPriceFl = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>�|���v���p�e�B</summary>
        /// <value>�|���i�����ݒ�/�������A�d���ݒ�/�d�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfRateVal
        {
            get { return _bfRateVal; }
            set { _bfRateVal = value; }
        }

        /// public propaty name  :  UpRate
        /// <summary>UP���v���p�e�B</summary>
        /// <value>UP���i�����ݒ�/����UP���A�艿/�艿UP���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfUpRate
        {
            get { return _bfUpRate; }
            set { _bfUpRate = value; }
        }

        /// public propaty name  :  GrsProfitSecureRate
        /// <summary>�e���m�ۗ��v���p�e�B</summary>
        /// <value>����P���̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���m�ۗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfGrsProfitSecureRate
        {
            get { return _bfGrsProfitSecureRate; }
            set { _bfGrsProfitSecureRate = value; }
        }

        /// public propaty name  :  UpdateDiv
        /// <summary>�X�V�敪�v���p�e�B</summary>
        /// <value>�X�V�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int UpdateDiv
        {
            get { return _updateDiv; }
            set { _updateDiv = value; }
        }

        /// public propaty name  :  RatebLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RatebLGroupCode
        {
            get { return _ratebLGroupCode; }
            set { _ratebLGroupCode = value; }
        }

        /// public propaty name  :  RatebLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RatebLGoodsCode
        {
            get { return _ratebLGoodsCode; }
            set { _ratebLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsLogicalDeleteCode
        /// <summary>�_���폜�敪(���i�}�X�^)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪(���i�}�X�^)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLogicalDeleteCode
        {
            get { return _goodsLogicalDeleteCode; }
            set { _goodsLogicalDeleteCode = value; }
        }


        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsRateSetSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsRateSetSearchResult()
        {
        }

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X�R���X�g���N�^
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
        /// <param name="unitRateSetDivCd">�P���|���ݒ�敪(�P����ށ{�|���ݒ�敪�i1A1,2A2���j)</param>
        /// <param name="unitPriceKind">�P�����(1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���)</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪(A1,A2��)</param>
        /// <param name="rateMngGoodsCd">�|���ݒ�敪�i���i�j(A�`O�@)</param>
        /// <param name="rateMngGoodsNm">�|���ݒ薼�́i���i�j(A�F "���[�J�[�{���i")</param>
        /// <param name="rateMngCustCd">�|���ݒ�敪�i���Ӑ�j(1�`9�@)</param>
        /// <param name="rateMngCustNm">�|���ݒ薼�́i���Ӑ�j(1�F "���Ӑ�{�d����")</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsRateRank">���i�|�������N(�w��)</param>
        /// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h(�����ނ��g�p)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���i�敪�ڍ�)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="lotCount">���b�g��(�\�����ʂ̓��b�g���̏����Ƃ���)</param>
        /// <param name="priceFl">���i�i�����j(�����ݒ�/����P���A�����ݒ�/�d���P���A�艿�ݒ�/�艿)</param>
        /// <param name="rateVal">�|��(�|���i�����ݒ�/�������A�d���ݒ�/�d�����j)</param>
        /// <param name="upRate">UP��(UP���i�����ݒ�/����UP���A�艿/�艿UP���j)</param>
        /// <param name="grsProfitSecureRate">�e���m�ۗ�(����P���̂�)</param>
        /// <param name="unPrcFracProcUnit">�P���[�������P��</param>
        /// <param name="unPrcFracProcDiv">�P���[�������敪(1:�؎̂�, 2:�l�̌ܓ�, 3:�؏グ)</param>
        /// <param name="prmGoodsMGroup">���i�����ރR�[�h(�y�D�ǐݒ�}�X�^�z)</param>
        /// <param name="prmTbsPartsCode">BL�R�[�h(�y�D�ǐݒ�}�X�^�z)</param>
        /// <param name="bLGoodsHalfName">BL���i�R�[�h���́i���p�j</param>
        /// <param name="prmPartsMakerCd">���i���[�J�[�R�[�h(�y�D�ǐݒ�}�X�^�z)</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsSupplierCd">�d����R�[�h(�y���i�Ǘ����}�X�^�z)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="listPrice">�W�����i</param>
        /// <param name="salesUnitCost">�d������</param>
        /// <param name="bfPriceFl">���i�i�����j</param>
        /// <param name="bfRateVal">�|��</param>
        /// <param name="bfUpRate">UP��</param>
        /// <param name="bfGrsProfitSecureRate">�e���m�ۗ�</param>
        /// <param name="updateDiv">�X�V�敪</param>
        /// <param name="ratebLGroupCode">BL�O���[�v�R�[�h(�|���}�X�^)</param>
        /// <param name="ratebLGoodsCode">BL���i�R�[�h(�|���}�X�^)</param>
        /// <param name="goodsLogicalDeleteCode">�_���폜�敪(���i�}�X�^)</param>
        /// <returns>GoodsRateSetSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsRateSetSearchResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string unitRateSetDivCd, string unitPriceKind, string rateSettingDivide, string rateMngGoodsCd, string rateMngGoodsNm, string rateMngCustCd, string rateMngCustNm, Int32 goodsMakerCd, string goodsNo, string goodsRateRank, Int32 goodsRateGrpCode, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 customerCode, Int32 custRateGrpCode, Int32 supplierCd, Double lotCount, Double priceFl, Double rateVal, Double upRate, Double grsProfitSecureRate, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Int32 prmGoodsMGroup, Int32 prmTbsPartsCode, string bLGoodsHalfName, Int32 prmPartsMakerCd, string makerName, Int32 goodsSupplierCd, string enterpriseName, string updEmployeeName, string bLGoodsName, double listPrice, double salesUnitCost, double bfPriceFl, double bfRateVal, double bfUpRate, double bfGrsProfitSecureRate, int updateDiv, Int32 ratebLGroupCode, Int32 ratebLGoodsCode, Int32 goodsLogicalDeleteCode)
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
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._customerCode = customerCode;
            this._custRateGrpCode = custRateGrpCode;
            this._supplierCd = supplierCd;
            this._lotCount = lotCount;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._upRate = upRate;
            this._grsProfitSecureRate = grsProfitSecureRate;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._prmGoodsMGroup = prmGoodsMGroup;
            this._prmTbsPartsCode = prmTbsPartsCode;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._prmPartsMakerCd = prmPartsMakerCd;
            this._makerName = makerName;
            this._goodsSupplierCd = goodsSupplierCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            this._listPrice = listPrice;
            this._salesUnitCost = salesUnitCost;
            this._bfPriceFl = bfPriceFl;
            this._bfRateVal = bfRateVal;
            this._bfUpRate = bfUpRate;
            this._bfGrsProfitSecureRate = bfGrsProfitSecureRate;
            this._updateDiv = updateDiv;
            this._ratebLGroupCode = ratebLGroupCode;
            this._ratebLGoodsCode = ratebLGoodsCode;
            this._goodsLogicalDeleteCode = goodsLogicalDeleteCode;

        }

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X��������
        /// </summary>
        /// <returns>GoodsRateSetSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsRateSetSearchResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsRateSetSearchResult Clone()
        {
            return new GoodsRateSetSearchResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._unitRateSetDivCd, this._unitPriceKind, this._rateSettingDivide, this._rateMngGoodsCd, this._rateMngGoodsNm, this._rateMngCustCd, this._rateMngCustNm, this._goodsMakerCd, this._goodsNo, this._goodsRateRank, this._goodsRateGrpCode, this._bLGroupCode, this._bLGoodsCode, this._customerCode, this._custRateGrpCode, this._supplierCd, this._lotCount, this._priceFl, this._rateVal, this._upRate, this._grsProfitSecureRate, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._prmGoodsMGroup, this._prmTbsPartsCode, this._bLGoodsHalfName, this._prmPartsMakerCd, this._makerName, this._goodsSupplierCd, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._listPrice, this._salesUnitCost, this._bfPriceFl, this._bfRateVal, this._bfUpRate, this._bfGrsProfitSecureRate, this._updateDiv, this._ratebLGroupCode, this._ratebLGoodsCode, this._goodsLogicalDeleteCode);
        }

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsRateSetSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(GoodsRateSetSearchResult target)
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
                 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.LotCount == target.LotCount)
                 && (this.PriceFl == target.PriceFl)
                 && (this.RateVal == target.RateVal)
                 && (this.UpRate == target.UpRate)
                 && (this.GrsProfitSecureRate == target.GrsProfitSecureRate)
                 && (this.UnPrcFracProcUnit == target.UnPrcFracProcUnit)
                 && (this.UnPrcFracProcDiv == target.UnPrcFracProcDiv)
                 && (this.PrmGoodsMGroup == target.PrmGoodsMGroup)
                 && (this.PrmTbsPartsCode == target.PrmTbsPartsCode)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.PrmPartsMakerCd == target.PrmPartsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsSupplierCd == target.GoodsSupplierCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.ListPrice == target.ListPrice)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.BfPriceFl == target.BfPriceFl)
                 && (this.BfRateVal == target.BfRateVal)
                 && (this.BfUpRate == target.BfUpRate)
                 && (this.BfGrsProfitSecureRate == target.BfGrsProfitSecureRate)
                 && (this.UpdateDiv == target.UpdateDiv)
                 && (this.RatebLGroupCode == target.RatebLGroupCode)
                 && (this.RatebLGoodsCode == target.RatebLGoodsCode)
                 && (this.GoodsLogicalDeleteCode == target.GoodsLogicalDeleteCode));
        }

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X��r����
        /// </summary>
        /// <param name="rateSearchResult1">
        ///                    ��r����GoodsRateSetSearchResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="rateSearchResult2">��r����GoodsRateSetSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(GoodsRateSetSearchResult rateSearchResult1, GoodsRateSetSearchResult rateSearchResult2)
        {
            return ((rateSearchResult1.CreateDateTime == rateSearchResult2.CreateDateTime)
                 && (rateSearchResult1.UpdateDateTime == rateSearchResult2.UpdateDateTime)
                 && (rateSearchResult1.EnterpriseCode == rateSearchResult2.EnterpriseCode)
                 && (rateSearchResult1.FileHeaderGuid == rateSearchResult2.FileHeaderGuid)
                 && (rateSearchResult1.UpdEmployeeCode == rateSearchResult2.UpdEmployeeCode)
                 && (rateSearchResult1.UpdAssemblyId1 == rateSearchResult2.UpdAssemblyId1)
                 && (rateSearchResult1.UpdAssemblyId2 == rateSearchResult2.UpdAssemblyId2)
                 && (rateSearchResult1.LogicalDeleteCode == rateSearchResult2.LogicalDeleteCode)
                 && (rateSearchResult1.SectionCode == rateSearchResult2.SectionCode)
                 && (rateSearchResult1.UnitRateSetDivCd == rateSearchResult2.UnitRateSetDivCd)
                 && (rateSearchResult1.UnitPriceKind == rateSearchResult2.UnitPriceKind)
                 && (rateSearchResult1.RateSettingDivide == rateSearchResult2.RateSettingDivide)
                 && (rateSearchResult1.RateMngGoodsCd == rateSearchResult2.RateMngGoodsCd)
                 && (rateSearchResult1.RateMngGoodsNm == rateSearchResult2.RateMngGoodsNm)
                 && (rateSearchResult1.RateMngCustCd == rateSearchResult2.RateMngCustCd)
                 && (rateSearchResult1.RateMngCustNm == rateSearchResult2.RateMngCustNm)
                 && (rateSearchResult1.GoodsMakerCd == rateSearchResult2.GoodsMakerCd)
                 && (rateSearchResult1.GoodsNo == rateSearchResult2.GoodsNo)
                 && (rateSearchResult1.GoodsRateRank == rateSearchResult2.GoodsRateRank)
                 && (rateSearchResult1.GoodsRateGrpCode == rateSearchResult2.GoodsRateGrpCode)
                 && (rateSearchResult1.BLGroupCode == rateSearchResult2.BLGroupCode)
                 && (rateSearchResult1.BLGoodsCode == rateSearchResult2.BLGoodsCode)
                 && (rateSearchResult1.CustomerCode == rateSearchResult2.CustomerCode)
                 && (rateSearchResult1.CustRateGrpCode == rateSearchResult2.CustRateGrpCode)
                 && (rateSearchResult1.SupplierCd == rateSearchResult2.SupplierCd)
                 && (rateSearchResult1.LotCount == rateSearchResult2.LotCount)
                 && (rateSearchResult1.PriceFl == rateSearchResult2.PriceFl)
                 && (rateSearchResult1.RateVal == rateSearchResult2.RateVal)
                 && (rateSearchResult1.UpRate == rateSearchResult2.UpRate)
                 && (rateSearchResult1.GrsProfitSecureRate == rateSearchResult2.GrsProfitSecureRate)
                 && (rateSearchResult1.UnPrcFracProcUnit == rateSearchResult2.UnPrcFracProcUnit)
                 && (rateSearchResult1.UnPrcFracProcDiv == rateSearchResult2.UnPrcFracProcDiv)
                 && (rateSearchResult1.PrmGoodsMGroup == rateSearchResult2.PrmGoodsMGroup)
                 && (rateSearchResult1.PrmTbsPartsCode == rateSearchResult2.PrmTbsPartsCode)
                 && (rateSearchResult1.BLGoodsHalfName == rateSearchResult2.BLGoodsHalfName)
                 && (rateSearchResult1.PrmPartsMakerCd == rateSearchResult2.PrmPartsMakerCd)
                 && (rateSearchResult1.MakerName == rateSearchResult2.MakerName)
                 && (rateSearchResult1.GoodsSupplierCd == rateSearchResult2.GoodsSupplierCd)
                 && (rateSearchResult1.EnterpriseName == rateSearchResult2.EnterpriseName)
                 && (rateSearchResult1.UpdEmployeeName == rateSearchResult2.UpdEmployeeName)
                 && (rateSearchResult1.BLGoodsName == rateSearchResult2.BLGoodsName)
                 && (rateSearchResult1.ListPrice == rateSearchResult2.ListPrice)
                 && (rateSearchResult1.SalesUnitCost == rateSearchResult2.SalesUnitCost)
                 && (rateSearchResult1.BfPriceFl == rateSearchResult2.BfPriceFl)
                 && (rateSearchResult1.BfRateVal == rateSearchResult2.BfRateVal)
                 && (rateSearchResult1.BfUpRate == rateSearchResult2.BfUpRate)
                 && (rateSearchResult1.BfGrsProfitSecureRate == rateSearchResult2.BfGrsProfitSecureRate)
                 && (rateSearchResult1.UpdateDiv == rateSearchResult2.UpdateDiv)
                 && (rateSearchResult1.RatebLGroupCode == rateSearchResult2.RatebLGroupCode)
                 && (rateSearchResult1.RatebLGoodsCode == rateSearchResult2.RatebLGoodsCode)
                 && (rateSearchResult1.GoodsLogicalDeleteCode == rateSearchResult2.GoodsLogicalDeleteCode));
        }
        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsRateSetSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(GoodsRateSetSearchResult target)
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
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.LotCount != target.LotCount) resList.Add("LotCount");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UpRate != target.UpRate) resList.Add("UpRate");
            if (this.GrsProfitSecureRate != target.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.PrmGoodsMGroup != target.PrmGoodsMGroup) resList.Add("PrmGoodsMGroup");
            if (this.PrmTbsPartsCode != target.PrmTbsPartsCode) resList.Add("PrmTbsPartsCode");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.PrmPartsMakerCd != target.PrmPartsMakerCd) resList.Add("PrmPartsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsSupplierCd != target.GoodsSupplierCd) resList.Add("GoodsSupplierCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.BfPriceFl != target.BfPriceFl) resList.Add("BfPriceFl");
            if (this.BfRateVal != target.BfRateVal) resList.Add("BfRateVal");
            if (this.BfUpRate != target.BfUpRate) resList.Add("BfUpRate");
            if (this.BfGrsProfitSecureRate != target.BfGrsProfitSecureRate) resList.Add("BfGrsProfitSecureRate");
            if (this.UpdateDiv != target.UpdateDiv) resList.Add("UpdateDiv");
            if (this.RatebLGroupCode != target.RatebLGroupCode) resList.Add("RatebLGroupCode");
            if (this.RatebLGoodsCode != target.RatebLGoodsCode) resList.Add("RatebLGoodsCode");
            if (this.GoodsLogicalDeleteCode != target.GoodsLogicalDeleteCode) resList.Add("GoodsLogicalDeleteCode");

            return resList;
        }

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����o���ʃN���X��r����
        /// </summary>
        /// <param name="rateSearchResult1">��r����GoodsRateSetSearchResult�N���X�̃C���X�^���X</param>
        /// <param name="rateSearchResult2">��r����GoodsRateSetSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsRateSetSearchResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(GoodsRateSetSearchResult rateSearchResult1, GoodsRateSetSearchResult rateSearchResult2)
        {
            ArrayList resList = new ArrayList();
            if (rateSearchResult1.CreateDateTime != rateSearchResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (rateSearchResult1.UpdateDateTime != rateSearchResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rateSearchResult1.EnterpriseCode != rateSearchResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rateSearchResult1.FileHeaderGuid != rateSearchResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (rateSearchResult1.UpdEmployeeCode != rateSearchResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (rateSearchResult1.UpdAssemblyId1 != rateSearchResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (rateSearchResult1.UpdAssemblyId2 != rateSearchResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (rateSearchResult1.LogicalDeleteCode != rateSearchResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rateSearchResult1.SectionCode != rateSearchResult2.SectionCode) resList.Add("SectionCode");
            if (rateSearchResult1.UnitRateSetDivCd != rateSearchResult2.UnitRateSetDivCd) resList.Add("UnitRateSetDivCd");
            if (rateSearchResult1.UnitPriceKind != rateSearchResult2.UnitPriceKind) resList.Add("UnitPriceKind");
            if (rateSearchResult1.RateSettingDivide != rateSearchResult2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (rateSearchResult1.RateMngGoodsCd != rateSearchResult2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (rateSearchResult1.RateMngGoodsNm != rateSearchResult2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (rateSearchResult1.RateMngCustCd != rateSearchResult2.RateMngCustCd) resList.Add("RateMngCustCd");
            if (rateSearchResult1.RateMngCustNm != rateSearchResult2.RateMngCustNm) resList.Add("RateMngCustNm");
            if (rateSearchResult1.GoodsMakerCd != rateSearchResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (rateSearchResult1.GoodsNo != rateSearchResult2.GoodsNo) resList.Add("GoodsNo");
            if (rateSearchResult1.GoodsRateRank != rateSearchResult2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (rateSearchResult1.GoodsRateGrpCode != rateSearchResult2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (rateSearchResult1.BLGroupCode != rateSearchResult2.BLGroupCode) resList.Add("BLGroupCode");
            if (rateSearchResult1.BLGoodsCode != rateSearchResult2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (rateSearchResult1.CustomerCode != rateSearchResult2.CustomerCode) resList.Add("CustomerCode");
            if (rateSearchResult1.CustRateGrpCode != rateSearchResult2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (rateSearchResult1.SupplierCd != rateSearchResult2.SupplierCd) resList.Add("SupplierCd");
            if (rateSearchResult1.LotCount != rateSearchResult2.LotCount) resList.Add("LotCount");
            if (rateSearchResult1.PriceFl != rateSearchResult2.PriceFl) resList.Add("PriceFl");
            if (rateSearchResult1.RateVal != rateSearchResult2.RateVal) resList.Add("RateVal");
            if (rateSearchResult1.UpRate != rateSearchResult2.UpRate) resList.Add("UpRate");
            if (rateSearchResult1.GrsProfitSecureRate != rateSearchResult2.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");
            if (rateSearchResult1.UnPrcFracProcUnit != rateSearchResult2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (rateSearchResult1.UnPrcFracProcDiv != rateSearchResult2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (rateSearchResult1.PrmGoodsMGroup != rateSearchResult2.PrmGoodsMGroup) resList.Add("PrmGoodsMGroup");
            if (rateSearchResult1.PrmTbsPartsCode != rateSearchResult2.PrmTbsPartsCode) resList.Add("PrmTbsPartsCode");
            if (rateSearchResult1.BLGoodsHalfName != rateSearchResult2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (rateSearchResult1.PrmPartsMakerCd != rateSearchResult2.PrmPartsMakerCd) resList.Add("PrmPartsMakerCd");
            if (rateSearchResult1.MakerName != rateSearchResult2.MakerName) resList.Add("MakerName");
            if (rateSearchResult1.GoodsSupplierCd != rateSearchResult2.GoodsSupplierCd) resList.Add("GoodsSupplierCd");
            if (rateSearchResult1.EnterpriseName != rateSearchResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchResult1.UpdEmployeeName != rateSearchResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (rateSearchResult1.BLGoodsName != rateSearchResult2.BLGoodsName) resList.Add("BLGoodsName");
            if (rateSearchResult1.ListPrice != rateSearchResult2.ListPrice) resList.Add("ListPrice");
            if (rateSearchResult1.SalesUnitCost != rateSearchResult2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (rateSearchResult1.BfPriceFl != rateSearchResult2.BfPriceFl) resList.Add("BfPriceFl");
            if (rateSearchResult1.BfRateVal != rateSearchResult2.BfRateVal) resList.Add("BfRateVal");
            if (rateSearchResult1.BfUpRate != rateSearchResult2.BfUpRate) resList.Add("BfUpRate");
            if (rateSearchResult1.BfGrsProfitSecureRate != rateSearchResult2.BfGrsProfitSecureRate) resList.Add("BfGrsProfitSecureRate");
            if (rateSearchResult1.UpdateDiv != rateSearchResult2.UpdateDiv) resList.Add("UpdateDiv");
            if (rateSearchResult1.RatebLGroupCode != rateSearchResult2.RatebLGroupCode) resList.Add("RatebLGroupCode");
            if (rateSearchResult1.RatebLGoodsCode != rateSearchResult2.RatebLGoodsCode) resList.Add("RatebLGoodsCode");
            if (rateSearchResult1.GoodsLogicalDeleteCode != rateSearchResult2.GoodsLogicalDeleteCode) resList.Add("GoodsLogicalDeleteCode");

            return resList;
        }
    }
}
