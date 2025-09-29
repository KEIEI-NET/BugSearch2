using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignMng
    /// <summary>
    ///                      �L�����y�[���Ώۏ��i�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���Ώۏ��i�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :    2009/5/11  ����</br>
    /// <br>                 :   �����ڍ폜</br>
    /// <br>                 :   ���Ӑ�R�[�h</br>
    /// <br>                 :   �d����R�[�h</br>
    /// <br>                 :   BL�O���[�v�R�[�h</br>
    /// <br>Update Note      :    2009/5/13  ����</br>
    /// <br>                 :   ���^�ύX</br>
    /// <br>                 :   �L�����y�[���R�[�h</br>
    /// <br>                 :   nvarchar �� Int32</br>
    /// <br>Update Note      :   2011/3/29  �Ԍ�</br>
    /// <br>                 :   �����ڒǉ��A�j�d�x�ύX</br>
    /// <br>                 :   BL�O���[�v�R�[�h�`���i�J�n��</br>
    /// <br>                 :   3,9,10,11,12,13��3,9,17,22,10,20,11,21,12,13,24,25,26</br>
    /// </remarks>
    public class CampaignObjGoodsSt
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
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
        private Int32 _campaignCode;

        /// <summary>���i�i�����j</summary>
        /// <remarks>����P���i�i�ԒP�ʂ̂ݐݒ�j</remarks>
        private Double _priceFl;

        /// <summary>�|��</summary>
        /// <remarks>������</remarks>
        private Double _rateVal;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>�̔��敪�R�[�h</summary>
        /// <remarks>���[�U�[�K�C�h</remarks>
        private Int32 _salesCode;

        /// <summary>�L�����y�[���ݒ���</summary>
        /// <remarks>1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _campaignSettingKind;

        /// <summary>�����ݒ�敪</summary>
        /// <remarks>0�Ȃ��A1�F����</remarks>
        private Int32 _salesPriceSetDiv;

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>0�͑S���Ӑ�</remarks>
        private Int32 _customerCode;

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>���i�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceEndDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�l����</summary>
        private Double _discountRate;

        /// <summary>�s��</summary>
        private Int32 _rowIndex;

        /// <summary>�V�K�s�t���O</summary>
        private Boolean _isUpdRow;

        /// <summary>�i��</summary>
        private string _goodsNameKana = "";

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
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>���i�i�����j�v���p�e�B</summary>
        /// <value>����P���i�i�ԒP�ʂ̂ݐݒ�j</value>
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
        /// <value>������</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
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

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  CampaignSettingKind
        /// <summary>�L�����y�[���ݒ��ʃv���p�e�B</summary>
        /// <value>1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���ݒ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignSettingKind
        {
            get { return _campaignSettingKind; }
            set { _campaignSettingKind = value; }
        }

        /// public propaty name  :  SalesPriceSetDiv
        /// <summary>�����ݒ�敪�v���p�e�B</summary>
        /// <value>0�Ȃ��A1�F����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesPriceSetDiv
        {
            get { return _salesPriceSetDiv; }
            set { _salesPriceSetDiv = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�͑S���Ӑ�</value>
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

        /// public propaty name  :  PriceEndDate
        /// <summary>���i�I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceEndDate
        {
            get { return _priceEndDate; }
            set { _priceEndDate = value; }
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

        /// public propaty name  :  DiscountRate
        /// <summary>�l�����v���p�e�B</summary>
        /// <value>�l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        /// public propaty name  :  RowIndex
        /// <summary>�s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        /// public propaty name  :  IsUpdRow
        /// <summary>�V�K�s�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�K�s�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsUpdRow
        {
            get { return _isUpdRow; }
            set { _isUpdRow = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>�i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignObjGoodsSt()
        {
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h(�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j)</param>
        /// <param name="priceFl">���i�i�����j(����P���i�i�ԒP�ʂ̂ݐݒ�j)</param>
        /// <param name="rateVal">�|��(������)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
        /// <param name="salesCode">�̔��敪�R�[�h(���[�U�[�K�C�h)</param>
        /// <param name="campaignSettingKind">�L�����y�[���ݒ���(1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="salesPriceSetDiv">�����ݒ�敪(0�Ȃ��A1�F����)</param>
        /// <param name="customerCode">���Ӑ�R�[�h(0�͑S���Ӑ�)</param>
        /// <param name="priceStartDate">���i�J�n��(YYYYMMDD)</param>
        /// <param name="priceEndDate">���i�I����(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="discountRate">�l����</param>
        /// <param name="rowIndex">�s��</param>
        /// <param name="isUpdRow">�V�K�s�t���O</param>
        /// <param name="goodsNameKana">�V�K�s�t���O</param>
        /// <returns>CampaignMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignObjGoodsSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 goodsMGroup, Int32 bLGoodsCode, Int32 goodsMakerCd, string goodsNo, Int64 salesTargetMoney, Int64 salesTargetProfit, Double salesTargetCount, Int32 campaignCode, Double priceFl, Double rateVal, Int32 bLGroupCode, Int32 salesCode, Int32 campaignSettingKind, Int32 salesPriceSetDiv, Int32 customerCode, Int32 priceStartDate, Int32 priceEndDate, string enterpriseName, string updEmployeeName, Int32 rowIndex, Double discountRate, Boolean isUpdRow, string goodsNameKana)
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
            this._goodsMGroup = goodsMGroup;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
            this._campaignCode = campaignCode;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._bLGroupCode = bLGroupCode;
            this._salesCode = salesCode;
            this._campaignSettingKind = campaignSettingKind;
            this._salesPriceSetDiv = salesPriceSetDiv;
            this._customerCode = customerCode;
            this._priceStartDate = priceStartDate;
            this._priceEndDate = priceEndDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._discountRate = discountRate;
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
            this._goodsNameKana = goodsNameKana;

        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��������
        /// </summary>
        /// <returns>CampaignMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignMng�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignObjGoodsSt Clone()
        {
            return new CampaignObjGoodsSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._goodsMGroup, this._bLGoodsCode, this._goodsMakerCd, this._goodsNo, this._salesTargetMoney, this._salesTargetProfit, this._salesTargetCount, this._campaignCode, this._priceFl, this._rateVal, this._bLGroupCode, this._salesCode, this._campaignSettingKind, this._salesPriceSetDiv, this._customerCode, this._priceStartDate, this._priceEndDate, this._enterpriseName, this._updEmployeeName, this._rowIndex, this._discountRate, this._isUpdRow, this._goodsNameKana);
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CampaignObjGoodsSt target)
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
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.PriceFl == target.PriceFl)
                 && (this.RateVal == target.RateVal)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.SalesCode == target.SalesCode)
                 && (this.CampaignSettingKind == target.CampaignSettingKind)
                 && (this.SalesPriceSetDiv == target.SalesPriceSetDiv)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.PriceEndDate == target.PriceEndDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DiscountRate == target.DiscountRate)
                 && (this.RowIndex == target.RowIndex)
                 && (this.IsUpdRow == target.IsUpdRow)
                 && (this.GoodsNameKana == target.GoodsNameKana));
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignMng1">
        ///                    ��r����CampaignMng�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignMng2">��r����CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            return ((campaignMng1.CreateDateTime == campaignMng2.CreateDateTime)
                 && (campaignMng1.UpdateDateTime == campaignMng2.UpdateDateTime)
                 && (campaignMng1.EnterpriseCode == campaignMng2.EnterpriseCode)
                 && (campaignMng1.FileHeaderGuid == campaignMng2.FileHeaderGuid)
                 && (campaignMng1.UpdEmployeeCode == campaignMng2.UpdEmployeeCode)
                 && (campaignMng1.UpdAssemblyId1 == campaignMng2.UpdAssemblyId1)
                 && (campaignMng1.UpdAssemblyId2 == campaignMng2.UpdAssemblyId2)
                 && (campaignMng1.LogicalDeleteCode == campaignMng2.LogicalDeleteCode)
                 && (campaignMng1.SectionCode == campaignMng2.SectionCode)
                 && (campaignMng1.GoodsMGroup == campaignMng2.GoodsMGroup)
                 && (campaignMng1.BLGoodsCode == campaignMng2.BLGoodsCode)
                 && (campaignMng1.GoodsMakerCd == campaignMng2.GoodsMakerCd)
                 && (campaignMng1.GoodsNo == campaignMng2.GoodsNo)
                 && (campaignMng1.SalesTargetMoney == campaignMng2.SalesTargetMoney)
                 && (campaignMng1.SalesTargetProfit == campaignMng2.SalesTargetProfit)
                 && (campaignMng1.SalesTargetCount == campaignMng2.SalesTargetCount)
                 && (campaignMng1.CampaignCode == campaignMng2.CampaignCode)
                 && (campaignMng1.PriceFl == campaignMng2.PriceFl)
                 && (campaignMng1.RateVal == campaignMng2.RateVal)
                 && (campaignMng1.BLGroupCode == campaignMng2.BLGroupCode)
                 && (campaignMng1.SalesCode == campaignMng2.SalesCode)
                 && (campaignMng1.CampaignSettingKind == campaignMng2.CampaignSettingKind)
                 && (campaignMng1.SalesPriceSetDiv == campaignMng2.SalesPriceSetDiv)
                 && (campaignMng1.CustomerCode == campaignMng2.CustomerCode)
                 && (campaignMng1.PriceStartDate == campaignMng2.PriceStartDate)
                 && (campaignMng1.PriceEndDate == campaignMng2.PriceEndDate)
                 && (campaignMng1.EnterpriseName == campaignMng2.EnterpriseName)
                 && (campaignMng1.UpdEmployeeName == campaignMng2.UpdEmployeeName)
                 && (campaignMng1.DiscountRate == campaignMng2.DiscountRate)
                 && (campaignMng1.RowIndex == campaignMng2.RowIndex)
                 && (campaignMng1.IsUpdRow == campaignMng2.IsUpdRow)
                 && (campaignMng1.GoodsNameKana == campaignMng2.GoodsNameKana));
        }
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CampaignObjGoodsSt target)
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
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.CampaignSettingKind != target.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (this.SalesPriceSetDiv != target.SalesPriceSetDiv) resList.Add("SalesPriceSetDiv");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.PriceEndDate != target.PriceEndDate) resList.Add("PriceEndDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.DiscountRate != target.DiscountRate) resList.Add("DiscountRate");
            if (this.RowIndex != target.RowIndex) resList.Add("RowIndex");
            if (this.IsUpdRow != target.IsUpdRow) resList.Add("IsUpdRow");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");

            return resList;
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignMng1">��r����CampaignMng�N���X�̃C���X�^���X</param>
        /// <param name="campaignMng2">��r����CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            ArrayList resList = new ArrayList();
            if (campaignMng1.CreateDateTime != campaignMng2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignMng1.UpdateDateTime != campaignMng2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignMng1.EnterpriseCode != campaignMng2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignMng1.FileHeaderGuid != campaignMng2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignMng1.UpdEmployeeCode != campaignMng2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignMng1.UpdAssemblyId1 != campaignMng2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignMng1.UpdAssemblyId2 != campaignMng2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignMng1.LogicalDeleteCode != campaignMng2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignMng1.SectionCode != campaignMng2.SectionCode) resList.Add("SectionCode");
            if (campaignMng1.GoodsMGroup != campaignMng2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignMng1.GoodsNo != campaignMng2.GoodsNo) resList.Add("GoodsNo");
            if (campaignMng1.SalesTargetMoney != campaignMng2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (campaignMng1.SalesTargetProfit != campaignMng2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (campaignMng1.SalesTargetCount != campaignMng2.SalesTargetCount) resList.Add("SalesTargetCount");
            if (campaignMng1.CampaignCode != campaignMng2.CampaignCode) resList.Add("CampaignCode");
            if (campaignMng1.PriceFl != campaignMng2.PriceFl) resList.Add("PriceFl");
            if (campaignMng1.RateVal != campaignMng2.RateVal) resList.Add("RateVal");
            if (campaignMng1.BLGroupCode != campaignMng2.BLGroupCode) resList.Add("BLGroupCode");
            if (campaignMng1.SalesCode != campaignMng2.SalesCode) resList.Add("SalesCode");
            if (campaignMng1.CampaignSettingKind != campaignMng2.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (campaignMng1.SalesPriceSetDiv != campaignMng2.SalesPriceSetDiv) resList.Add("SalesPriceSetDiv");
            if (campaignMng1.CustomerCode != campaignMng2.CustomerCode) resList.Add("CustomerCode");
            if (campaignMng1.PriceStartDate != campaignMng2.PriceStartDate) resList.Add("PriceStartDate");
            if (campaignMng1.PriceEndDate != campaignMng2.PriceEndDate) resList.Add("PriceEndDate");
            if (campaignMng1.EnterpriseName != campaignMng2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignMng1.UpdEmployeeName != campaignMng2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (campaignMng1.DiscountRate != campaignMng2.DiscountRate) resList.Add("DiscountRate");
            if (campaignMng1.RowIndex != campaignMng2.RowIndex) resList.Add("RowIndex");
            if (campaignMng1.IsUpdRow != campaignMng2.IsUpdRow) resList.Add("IsUpdRow");
            if (campaignMng1.GoodsNameKana != campaignMng2.GoodsNameKana) resList.Add("GoodsNameKana");

            return resList;
        }
    }
}