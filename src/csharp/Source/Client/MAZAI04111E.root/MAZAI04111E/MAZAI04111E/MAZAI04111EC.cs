using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockExpansion
    /// <summary>
    ///                      ���i�݌ɏ��N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�݌ɏ��N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/10  (CSharp File Generated Date)</br>
    /// <br>-------------------------------------------------------------</br>
    /// <br>Update Note      :   2008/02/18 ��� ���b  �@�ŐV�̃��C�A�E�g�ɑΉ�</br>
    /// <br>                                           �A�t�@�C�����C�A�E�g�̍��ڈȊO�ŕK�v�ȍ��ڂ�ǉ�</br>
    /// <br>                 :   2009/04/01 �Ɠc �M�u�@�s��Ή�[12836]</br>
    /// </remarks>
    public class StockExpansion
    {
        # region [ private Fields (�e�[�u�����C�A�E�g��莩��������) ]
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>���݌ɕ]���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���݌ɐ�</summary>
        /// <remarks>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
        private Double _supplierStock;

        /// <summary>�����</summary>
        /// <remarks>������Ă���݌ɐ��i���Ѝ݌Ɂj</remarks>
        private Double _trustCount;

        /// <summary>�󒍐�</summary>
        private Double _acpOdrCount;

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�d���݌ɕ��ϑ���</summary>
        /// <remarks>�ϑ����Ă���݌ɐ��i���Ѝ݌Ɂj</remarks>
        private Double _entrustCnt;

        /// <summary>���ؐ�</summary>
        private Double _soldCnt;

        /// <summary>�ړ����d���݌ɐ�</summary>
        /// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
        private Double _movingSupliStock;

        /// <summary>�ړ�������݌ɐ�</summary>
        /// <remarks>�@�@�V</remarks>
        private Double _movingTrustStock;

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</remarks>
        private Double _shipmentPosCnt;

        /// <summary>�݌ɕۗL���z</summary>
        /// <remarks>�l���܂�</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�ŏI�d���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastStockDate;

        /// <summary>�ŏI�����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastSalesDate;

        /// <summary>�ŏI�I���X�V��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastInventoryUpdate;

        /// <summary>�Œ�݌ɐ�</summary>
        private Double _minimumStockCnt;

        /// <summary>�ō��݌ɐ�</summary>
        private Double _maximumStockCnt;

        /// <summary>�������</summary>
        private Double _nmlSalOdrCount;

        /// <summary>�����P��</summary>
        /// <remarks>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>�݌ɕ]����</summary>
        private Double _stockAssessmentRate;

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�d���I�ԂP</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        private string _partsManagementDivide1 = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        private string _partsManagementDivide2 = "";

        /// <summary>�݌ɔ��l�P</summary>
        /// <remarks>�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@</remarks>
        private string _stockNote1 = "";

        /// <summary>�݌ɔ��l�Q</summary>
        private string _stockNote2 = "";

        /// <summary>�o�א��i���v��j</summary>
        /// <remarks>�ݏo�A�o�ׂƓ���</remarks>
        private Double _shipmentCnt;

        /// <summary>���א��i���v��j</summary>
        /// <remarks>����</remarks>
        private Double _arrivalCnt;

        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>���i�敪�O���[�v�R�[�h</summary>
        /// <remarks>���F���i�啪�ރR�[�h</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>���i�敪�O���[�v����</summary>
        /// <remarks>���F���i�啪�ޖ���</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>���i�敪�R�[�h</summary>
        /// <remarks>���F���i�����ރR�[�h</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>���i�敪����</summary>
        /// <remarks>���F���i�����ޖ���</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>���i�敪�ڍ׃R�[�h</summary>
        private string _detailGoodsGanreCode = "";

        /// <summary>���i�敪�ڍז���</summary>
        private string _detailGoodsGanreName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���i������</summary>
        private string _goodsShortName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        private string _enterpriseGanreName = "";

        /// <summary>JAN�R�[�h</summary>
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
        private string _jan = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        # region [ private Fields (�蓮�Œǉ�) ]
        /// <summary>���i�敪</summary>
        private Int32 _priceDivCd;

        /// <summary>�V���i</summary>
        private Double _newPrice;

        /// <summary>�V���i�J�n��</summary>
        private DateTime _newPriceStartDate;

        /// <summary>�����i</summary>
        private Double _oldPrice;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        
        /// <summary>M/O������</summary>
        private Double _monthOrderCount;

        /// <summary>�݌ɋ敪</summary>
        private Int32 _stockDiv;

        /// <summary>�݌ɔ�����R�[�h</summary>
        private Int32 _stockSupplierCode;

        /// <summary>�X�V�N����</summary>
        private Int32 _updateDate;


        // �����[�g�N���X����擾�͂��Ȃ����\���̂��߂ɕێ����鍀��

        /// <summary>�������b�g</summary>
        private Double _supplierLot;

        /// <summary>�K�i�E���L����</summary>
        private string _goodsSpecialNote;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm;

        /// <summary>�W�����i</summary>
        private Double _listPrice;

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
        
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        # region [ public Propaties (�e�[�u�����C�A�E�g��莩��������) ]
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
        /// <value>���݌ɕ]���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  SupplierStock
        /// <summary>�d���݌ɐ��v���p�e�B</summary>
        /// <value>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  TrustCount
        /// <summary>������v���p�e�B</summary>
        /// <value>������Ă���݌ɐ��i���Ѝ݌Ɂj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TrustCount
        {
            get { return _trustCount; }
            set { _trustCount = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>�󒍐��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  EntrustCnt
        /// <summary>�d���݌ɕ��ϑ����v���p�e�B</summary>
        /// <value>�ϑ����Ă���݌ɐ��i���Ѝ݌Ɂj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌ɕ��ϑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double EntrustCnt
        {
            get { return _entrustCnt; }
            set { _entrustCnt = value; }
        }

        /// public propaty name  :  SoldCnt
        /// <summary>���ؐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ؐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SoldCnt
        {
            get { return _soldCnt; }
            set { _soldCnt = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
        /// <value>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  MovingTrustStock
        /// <summary>�ړ�������݌ɐ��v���p�e�B</summary>
        /// <value>�@�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ�������݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MovingTrustStock
        {
            get { return _movingTrustStock; }
            set { _movingTrustStock = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>�݌ɕۗL���z�v���p�e�B</summary>
        /// <value>�l���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕۗL���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  LastStockDate
        /// <summary>�ŏI�d���N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastStockDate
        {
            get { return _lastStockDate; }
            set { _lastStockDate = value; }
        }

        /// public propaty name  :  LastStockDateJpFormal
        /// <summary>�ŏI�d���N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d���N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastStockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastStockDateJpInFormal
        /// <summary>�ŏI�d���N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d���N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastStockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastStockDateAdFormal
        /// <summary>�ŏI�d���N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d���N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastStockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastStockDateAdInFormal
        /// <summary>�ŏI�d���N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d���N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastStockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastStockDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDate
        /// <summary>�ŏI������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastSalesDate
        {
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  LastSalesDateJpFormal
        /// <summary>�ŏI����� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI����� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastSalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDateJpInFormal
        /// <summary>�ŏI����� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI����� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastSalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDateAdFormal
        /// <summary>�ŏI����� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI����� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastSalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastSalesDateAdInFormal
        /// <summary>�ŏI����� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI����� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastSalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastSalesDate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>�ŏI�I���X�V���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastInventoryUpdate
        {
            get { return _lastInventoryUpdate; }
            set { _lastInventoryUpdate = value; }
        }

        /// public propaty name  :  LastInventoryUpdateJpFormal
        /// <summary>�ŏI�I���X�V�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastInventoryUpdateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdateJpInFormal
        /// <summary>�ŏI�I���X�V�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastInventoryUpdateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdateAdFormal
        /// <summary>�ŏI�I���X�V�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastInventoryUpdateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  LastInventoryUpdateAdInFormal
        /// <summary>�ŏI�I���X�V�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�I���X�V�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastInventoryUpdateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastInventoryUpdate); }
            set { }
        }

        /// public propaty name  :  MinimumStockCnt
        /// <summary>�Œ�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Œ�݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MinimumStockCnt
        {
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>�ō��݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ō��݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  NmlSalOdrCount
        /// <summary>��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NmlSalOdrCount
        {
            get { return _nmlSalOdrCount; }
            set { _nmlSalOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderUnit
        /// <summary>�����P�ʃv���p�e�B</summary>
        /// <value>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderUnit
        {
            get { return _salesOrderUnit; }
            set { _salesOrderUnit = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  StockAssessmentRate
        /// <summary>�݌ɕ]�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ]�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockAssessmentRate
        {
            get { return _stockAssessmentRate; }
            set { _stockAssessmentRate = value; }
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

        /// public propaty name  :  DuplicationShelfNo1
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DuplicationShelfNo1
        {
            get { return _duplicationShelfNo1; }
            set { _duplicationShelfNo1 = value; }
        }

        /// public propaty name  :  DuplicationShelfNo2
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DuplicationShelfNo2
        {
            get { return _duplicationShelfNo2; }
            set { _duplicationShelfNo2 = value; }
        }

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }

        /// public propaty name  :  StockNote1
        /// <summary>�݌ɔ��l�P�v���p�e�B</summary>
        /// <value>�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockNote1
        {
            get { return _stockNote1; }
            set { _stockNote1 = value; }
        }

        /// public propaty name  :  StockNote2
        /// <summary>�݌ɔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockNote2
        {
            get { return _stockNote2; }
            set { _stockNote2 = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��i���v��j�v���p�e�B</summary>
        /// <value>�ݏo�A�o�ׂƓ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��i���v��j�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���F���i�啪�ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LargeGoodsGanreCode
        {
            get { return _largeGoodsGanreCode; }
            set { _largeGoodsGanreCode = value; }
        }

        /// public propaty name  :  LargeGoodsGanreName
        /// <summary>���i�敪�O���[�v���̃v���p�e�B</summary>
        /// <value>���F���i�啪�ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�O���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LargeGoodsGanreName
        {
            get { return _largeGoodsGanreName; }
            set { _largeGoodsGanreName = value; }
        }

        /// public propaty name  :  MediumGoodsGanreCode
        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
        /// <value>���F���i�����ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MediumGoodsGanreCode
        {
            get { return _mediumGoodsGanreCode; }
            set { _mediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  MediumGoodsGanreName
        /// <summary>���i�敪���̃v���p�e�B</summary>
        /// <value>���F���i�����ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MediumGoodsGanreName
        {
            get { return _mediumGoodsGanreName; }
            set { _mediumGoodsGanreName = value; }
        }

        /// public propaty name  :  DetailGoodsGanreCode
        /// <summary>���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DetailGoodsGanreCode
        {
            get { return _detailGoodsGanreCode; }
            set { _detailGoodsGanreCode = value; }
        }

        /// public propaty name  :  DetailGoodsGanreName
        /// <summary>���i�敪�ڍז��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�ڍז��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DetailGoodsGanreName
        {
            get { return _detailGoodsGanreName; }
            set { _detailGoodsGanreName = value; }
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

        /// public propaty name  :  GoodsShortName
        /// <summary>���i�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsShortName
        {
            get { return _goodsShortName; }
            set { _goodsShortName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  Jan
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
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
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        # region [ public Propaties (�蓮�Œǉ�) ]
        /// public propaty name  :  PriceDivCd
        /// <summary>���i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceDivCd
        {
            get { return _priceDivCd; }
            set { _priceDivCd = value; }
        }

        /// public propaty name  :  NewPrice
        /// <summary>�V���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewPrice
        {
            get { return _newPrice; }
            set { _newPrice = value; }
        }

        /// public propaty name  :  NewPriceStartDate
        /// <summary>�V���i�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime NewPriceStartDate
        {
            get { return _newPriceStartDate; }
            set { _newPriceStartDate = value; }
        }

        /// public propaty name  :  OldPrice
        /// <summary>�����i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OldPrice
        {
            get { return _oldPrice; }
            set { _oldPrice = value; }
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START

        /// public propaty name  :  MonthOrderCount
        /// <summary>M/O�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   M/O�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthOrderCount
        {
            get { return _monthOrderCount; }
            set { _monthOrderCount = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  StockSupplierCode
        /// <summary>�݌ɔ�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
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

        /// public propaty name  :  UpdateDateDT
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateDT
        {
            get { return TDateTime.LongDateToDateTime(_updateDate); 
            }
            set { _updateDate = TDateTime.DateTimeToLongDate(value); }
        }


        /// public propaty name  :  UpdateDateString
        /// <summary>�X�V�N����������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N����������v���p�e�B</br>
        /// </remarks>
        public string UpdateDateString
        {
            get { return TDateTime.DateTimeToString("yyyy/mm/dd", TDateTime.LongDateToDateTime(_updateDate)); }
        }

        /// public propaty name  :  StockCreateDateString
        /// <summary>�݌ɓo�^��������v���p�e�B</summary>
        /// <value>YYYY/MM/DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^��������v���p�e�B</br>
        /// </remarks>
        public string StockCreateDateString
        {
            get { return TDateTime.DateTimeToString("yyyy/mm/dd", _stockCreateDate); }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>�������b�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������b�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
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
        /// <summary>�d���旪���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�W�����i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


        # region [ constructor��methods (�蓮�ŕύX) ]
        /// <summary>
        /// �݌Ƀ}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockExpansion�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockExpansion�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockExpansion()
        {
        }

        /// <summary>
        /// �݌Ƀ}�X�^�R���X�g���N�^
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        /// <param name="sectionGuideNm">���_�K�C�h����</param>
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="stockUnitPriceFl">�d���P���i�Ŕ�,�����j(���݌ɕ]���P��)</param>
        /// <param name="supplierStock">�d���݌ɐ�(��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj)</param>
        /// <param name="trustCount">�����(������Ă���݌ɐ��i���Ѝ݌Ɂj)</param>
        /// <param name="acpOdrCount">�󒍐�</param>
        /// <param name="salesOrderCount">������</param>
        /// <param name="entrustCnt">�d���݌ɕ��ϑ���(�ϑ����Ă���݌ɐ��i���Ѝ݌Ɂj)</param>
        /// <param name="soldCnt">���ؐ�</param>
        /// <param name="movingSupliStock">�ړ����d���݌ɐ�(�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B)</param>
        /// <param name="movingTrustStock">�ړ�������݌ɐ�(�@�@�V)</param>
        /// <param name="shipmentPosCnt">�o�׉\��(�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�)</param>
        /// <param name="stockTotalPrice">�݌ɕۗL���z(�l���܂�)</param>
        /// <param name="lastStockDate">�ŏI�d���N����(YYYYMMDD)</param>
        /// <param name="lastSalesDate">�ŏI�����(YYYYMMDD)</param>
        /// <param name="lastInventoryUpdate">�ŏI�I���X�V��(YYYYMMDD)</param>
        /// <param name="minimumStockCnt">�Œ�݌ɐ�</param>
        /// <param name="maximumStockCnt">�ō��݌ɐ�</param>
        /// <param name="nmlSalOdrCount">�������</param>
        /// <param name="salesOrderUnit">�����P��(��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j)</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
        /// <param name="stockAssessmentRate">�݌ɕ]����</param>
        /// <param name="warehouseShelfNo">�q�ɒI��</param>
        /// <param name="duplicationShelfNo1">�d���I�ԂP</param>
        /// <param name="duplicationShelfNo2">�d���I�ԂQ</param>
        /// <param name="partsManagementDivide1">���i�Ǘ��敪�P</param>
        /// <param name="partsManagementDivide2">���i�Ǘ��敪�Q</param>
        /// <param name="stockNote1">�݌ɔ��l�P(�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@)</param>
        /// <param name="stockNote2">�݌ɔ��l�Q</param>
        /// <param name="shipmentCnt">�o�א��i���v��j(�ݏo�A�o�ׂƓ���)</param>
        /// <param name="arrivalCnt">���א��i���v��j(����)</param>
        /// <param name="stockCreateDate">�݌ɓo�^��(YYYYMMDD)</param>
        /// <param name="largeGoodsGanreCode">���i�敪�O���[�v�R�[�h(���F���i�啪�ރR�[�h)</param>
        /// <param name="largeGoodsGanreName">���i�敪�O���[�v����(���F���i�啪�ޖ���)</param>
        /// <param name="mediumGoodsGanreCode">���i�敪�R�[�h(���F���i�����ރR�[�h)</param>
        /// <param name="mediumGoodsGanreName">���i�敪����(���F���i�����ޖ���)</param>
        /// <param name="detailGoodsGanreCode">���i�敪�ڍ׃R�[�h</param>
        /// <param name="detailGoodsGanreName">���i�敪�ڍז���</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="goodsShortName">���i������</param>
        /// <param name="goodsNameKana">���i���̃J�i</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <param name="enterpriseGanreName">���Е��ޖ���</param>
        /// <param name="jan">JAN�R�[�h(�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        /// <param name="monthOrderCount">M/O������</param>
        /// <param name="stockDiv">�݌ɋ敪</param>
        /// <param name="stockSupplierCode">�݌ɔ�����R�[�h</param>
        /// <param name="updateDate">�X�V�N����</param>
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
        /// <returns>StockExpansion�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockExpansion�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockExpansion(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionGuideNm, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, Double stockUnitPriceFl, Double supplierStock, Double trustCount, Double acpOdrCount, Double salesOrderCount, Double entrustCnt, Double soldCnt, Double movingSupliStock, Double movingTrustStock, Double shipmentPosCnt, Int64 stockTotalPrice, DateTime lastStockDate, DateTime lastSalesDate, DateTime lastInventoryUpdate, Double minimumStockCnt, Double maximumStockCnt, Double nmlSalOdrCount, Int32 salesOrderUnit, string warehouseCode, string warehouseName, string goodsNoNoneHyphen, Double stockAssessmentRate, string warehouseShelfNo, string duplicationShelfNo1, string duplicationShelfNo2, string partsManagementDivide1, string partsManagementDivide2, string stockNote1, string stockNote2, Double shipmentCnt, Double arrivalCnt, DateTime stockCreateDate, string largeGoodsGanreCode, string largeGoodsGanreName, string mediumGoodsGanreCode, string mediumGoodsGanreName, string detailGoodsGanreCode, string detailGoodsGanreName, Int32 bLGoodsCode, string bLGoodsFullName, string goodsShortName, string goodsNameKana, Int32 enterpriseGanreCode, string enterpriseGanreName, string jan, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 priceDivCd, Double newPrice, DateTime newPriceStartDate, Double oldPrice, Int32 openPriceDiv, Double monthOrderCount, Int32 stockDiv, Int32 stockSupplierCode, Int32 updateDate, double supplierLot, string goodsSpecialNote, int supplierCd, string supplierSnm, double listPrice)
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            this._sectionGuideNm = sectionGuideNm;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._supplierStock = supplierStock;
            this._trustCount = trustCount;
            this._acpOdrCount = acpOdrCount;
            this._salesOrderCount = salesOrderCount;
            this._entrustCnt = entrustCnt;
            this._soldCnt = soldCnt;
            this._movingSupliStock = movingSupliStock;
            this._movingTrustStock = movingTrustStock;
            this._shipmentPosCnt = shipmentPosCnt;
            this._stockTotalPrice = stockTotalPrice;
            this.LastStockDate = lastStockDate;
            this.LastSalesDate = lastSalesDate;
            this.LastInventoryUpdate = lastInventoryUpdate;
            this._minimumStockCnt = minimumStockCnt;
            this._maximumStockCnt = maximumStockCnt;
            this._nmlSalOdrCount = nmlSalOdrCount;
            this._salesOrderUnit = salesOrderUnit;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._stockAssessmentRate = stockAssessmentRate;
            this._warehouseShelfNo = warehouseShelfNo;
            this._duplicationShelfNo1 = duplicationShelfNo1;
            this._duplicationShelfNo2 = duplicationShelfNo2;
            this._partsManagementDivide1 = partsManagementDivide1;
            this._partsManagementDivide2 = partsManagementDivide2;
            this._stockNote1 = stockNote1;
            this._stockNote2 = stockNote2;
            this._shipmentCnt = shipmentCnt;
            this._arrivalCnt = arrivalCnt;
            this._stockCreateDate = stockCreateDate;
            this._largeGoodsGanreCode = largeGoodsGanreCode;
            this._largeGoodsGanreName = largeGoodsGanreName;
            this._mediumGoodsGanreCode = mediumGoodsGanreCode;
            this._mediumGoodsGanreName = mediumGoodsGanreName;
            this._detailGoodsGanreCode = detailGoodsGanreCode;
            this._detailGoodsGanreName = detailGoodsGanreName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._goodsShortName = goodsShortName;
            this._goodsNameKana = goodsNameKana;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this._jan = jan;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._priceDivCd = priceDivCd;
            this._newPrice = newPrice;
            this._newPriceStartDate = newPriceStartDate;
            this._oldPrice = oldPrice;
            this._openPriceDiv = openPriceDiv;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
            this._monthOrderCount = monthOrderCount;
            this._stockDiv = stockDiv;
            this._stockSupplierCode = stockSupplierCode;
            this._updateDate = updateDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
            _supplierLot = supplierLot;
            //_goodsSpecialNote = GoodsSpecialNote;         //DEL 2009/04/01 �s��Ή�[12836]
            _goodsSpecialNote = goodsSpecialNote;           //ADD 2009/04/01 �s��Ή�[12836]
            _supplierCd = supplierCd;
            _supplierSnm = supplierSnm;
            _listPrice = listPrice;
        }

        /// <summary>
        /// �݌Ƀ}�X�^��������
        /// </summary>
        /// <returns>StockExpansion�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockExpansion�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockExpansion Clone()
        {
            return new StockExpansion(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionGuideNm, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._stockUnitPriceFl, this._supplierStock, this._trustCount, this._acpOdrCount, this._salesOrderCount, this._entrustCnt, this._soldCnt, this._movingSupliStock, this._movingTrustStock, this._shipmentPosCnt, this._stockTotalPrice, this._lastStockDate, this._lastSalesDate, this._lastInventoryUpdate, this._minimumStockCnt, this._maximumStockCnt, this._nmlSalOdrCount, this._salesOrderUnit, this._warehouseCode, this._warehouseName, this._goodsNoNoneHyphen, this._stockAssessmentRate, this._warehouseShelfNo, this._duplicationShelfNo1, this._duplicationShelfNo2, this._partsManagementDivide1, this._partsManagementDivide2, this._stockNote1, this._stockNote2, this._shipmentCnt, this._arrivalCnt, this._stockCreateDate, this._largeGoodsGanreCode, this._largeGoodsGanreName, this._mediumGoodsGanreCode, this._mediumGoodsGanreName, this._detailGoodsGanreCode, this._detailGoodsGanreName, this._bLGoodsCode, this._bLGoodsFullName, this._goodsShortName, this._goodsNameKana, this._enterpriseGanreCode, this._enterpriseGanreName, this._jan, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._priceDivCd, this._newPrice, this._newPriceStartDate, this._oldPrice, this._openPriceDiv, this._monthOrderCount, this._stockDiv, this._stockSupplierCode, this._updateDate, _supplierLot, _goodsSpecialNote, _supplierCd, _supplierSnm, _listPrice);
        }

        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockExpansion�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockExpansion�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockExpansion target)
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
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.SupplierStock == target.SupplierStock)
                 && (this.TrustCount == target.TrustCount)
                 && (this.AcpOdrCount == target.AcpOdrCount)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.EntrustCnt == target.EntrustCnt)
                 && (this.SoldCnt == target.SoldCnt)
                 && (this.MovingSupliStock == target.MovingSupliStock)
                 && (this.MovingTrustStock == target.MovingTrustStock)
                 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
                 && (this.StockTotalPrice == target.StockTotalPrice)
                 && (this.LastStockDate == target.LastStockDate)
                 && (this.LastSalesDate == target.LastSalesDate)
                 && (this.LastInventoryUpdate == target.LastInventoryUpdate)
                 && (this.MinimumStockCnt == target.MinimumStockCnt)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.NmlSalOdrCount == target.NmlSalOdrCount)
                 && (this.SalesOrderUnit == target.SalesOrderUnit)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.StockAssessmentRate == target.StockAssessmentRate)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.DuplicationShelfNo1 == target.DuplicationShelfNo1)
                 && (this.DuplicationShelfNo2 == target.DuplicationShelfNo2)
                 && (this.PartsManagementDivide1 == target.PartsManagementDivide1)
                 && (this.PartsManagementDivide2 == target.PartsManagementDivide2)
                 && (this.StockNote1 == target.StockNote1)
                 && (this.StockNote2 == target.StockNote2)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.ArrivalCnt == target.ArrivalCnt)
                 && (this.StockCreateDate == target.StockCreateDate)
                 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
                 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
                 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
                 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
                 && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
                 && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.GoodsShortName == target.GoodsShortName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.Jan == target.Jan)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.PriceDivCd == target.PriceDivCd)
                 && (this.NewPrice == target.NewPrice)
                 && (this.NewPriceStartDate == target.NewPriceStartDate)
                 && (this.OldPrice == target.OldPrice)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                 && (this.MonthOrderCount == target.MonthOrderCount)
                 && (this.StockDiv == target.StockDiv)
                 && (this.StockSupplierCode == target.StockSupplierCode)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.SupplierLot == target.SupplierLot)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.ListPrice == target.ListPrice)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
                 );
        }

        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="stockExpansion1">
        ///                    ��r����StockExpansion�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockExpansion2">��r����StockExpansion�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockExpansion�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockExpansion stockExpansion1, StockExpansion stockExpansion2)
        {
            return ((stockExpansion1.CreateDateTime == stockExpansion2.CreateDateTime)
                 && (stockExpansion1.UpdateDateTime == stockExpansion2.UpdateDateTime)
                 && (stockExpansion1.EnterpriseCode == stockExpansion2.EnterpriseCode)
                 && (stockExpansion1.FileHeaderGuid == stockExpansion2.FileHeaderGuid)
                 && (stockExpansion1.UpdEmployeeCode == stockExpansion2.UpdEmployeeCode)
                 && (stockExpansion1.UpdAssemblyId1 == stockExpansion2.UpdAssemblyId1)
                 && (stockExpansion1.UpdAssemblyId2 == stockExpansion2.UpdAssemblyId2)
                 && (stockExpansion1.LogicalDeleteCode == stockExpansion2.LogicalDeleteCode)
                 && (stockExpansion1.SectionCode == stockExpansion2.SectionCode)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                 && (stockExpansion1.SectionGuideNm == stockExpansion2.SectionGuideNm)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
                 && (stockExpansion1.GoodsMakerCd == stockExpansion2.GoodsMakerCd)
                 && (stockExpansion1.MakerName == stockExpansion2.MakerName)
                 && (stockExpansion1.GoodsNo == stockExpansion2.GoodsNo)
                 && (stockExpansion1.GoodsName == stockExpansion2.GoodsName)
                 && (stockExpansion1.StockUnitPriceFl == stockExpansion2.StockUnitPriceFl)
                 && (stockExpansion1.SupplierStock == stockExpansion2.SupplierStock)
                 && (stockExpansion1.TrustCount == stockExpansion2.TrustCount)
                 && (stockExpansion1.AcpOdrCount == stockExpansion2.AcpOdrCount)
                 && (stockExpansion1.SalesOrderCount == stockExpansion2.SalesOrderCount)
                 && (stockExpansion1.EntrustCnt == stockExpansion2.EntrustCnt)
                 && (stockExpansion1.SoldCnt == stockExpansion2.SoldCnt)
                 && (stockExpansion1.MovingSupliStock == stockExpansion2.MovingSupliStock)
                 && (stockExpansion1.MovingTrustStock == stockExpansion2.MovingTrustStock)
                 && (stockExpansion1.ShipmentPosCnt == stockExpansion2.ShipmentPosCnt)
                 && (stockExpansion1.StockTotalPrice == stockExpansion2.StockTotalPrice)
                 && (stockExpansion1.LastStockDate == stockExpansion2.LastStockDate)
                 && (stockExpansion1.LastSalesDate == stockExpansion2.LastSalesDate)
                 && (stockExpansion1.LastInventoryUpdate == stockExpansion2.LastInventoryUpdate)
                 && (stockExpansion1.MinimumStockCnt == stockExpansion2.MinimumStockCnt)
                 && (stockExpansion1.MaximumStockCnt == stockExpansion2.MaximumStockCnt)
                 && (stockExpansion1.NmlSalOdrCount == stockExpansion2.NmlSalOdrCount)
                 && (stockExpansion1.SalesOrderUnit == stockExpansion2.SalesOrderUnit)
                 && (stockExpansion1.WarehouseCode == stockExpansion2.WarehouseCode)
                 && (stockExpansion1.WarehouseName == stockExpansion2.WarehouseName)
                 && (stockExpansion1.GoodsNoNoneHyphen == stockExpansion2.GoodsNoNoneHyphen)
                 && (stockExpansion1.StockAssessmentRate == stockExpansion2.StockAssessmentRate)
                 && (stockExpansion1.WarehouseShelfNo == stockExpansion2.WarehouseShelfNo)
                 && (stockExpansion1.DuplicationShelfNo1 == stockExpansion2.DuplicationShelfNo1)
                 && (stockExpansion1.DuplicationShelfNo2 == stockExpansion2.DuplicationShelfNo2)
                 && (stockExpansion1.PartsManagementDivide1 == stockExpansion2.PartsManagementDivide1)
                 && (stockExpansion1.PartsManagementDivide2 == stockExpansion2.PartsManagementDivide2)
                 && (stockExpansion1.StockNote1 == stockExpansion2.StockNote1)
                 && (stockExpansion1.StockNote2 == stockExpansion2.StockNote2)
                 && (stockExpansion1.ShipmentCnt == stockExpansion2.ShipmentCnt)
                 && (stockExpansion1.ArrivalCnt == stockExpansion2.ArrivalCnt)
                 && (stockExpansion1.StockCreateDate == stockExpansion2.StockCreateDate)
                 && (stockExpansion1.LargeGoodsGanreCode == stockExpansion2.LargeGoodsGanreCode)
                 && (stockExpansion1.LargeGoodsGanreName == stockExpansion2.LargeGoodsGanreName)
                 && (stockExpansion1.MediumGoodsGanreCode == stockExpansion2.MediumGoodsGanreCode)
                 && (stockExpansion1.MediumGoodsGanreName == stockExpansion2.MediumGoodsGanreName)
                 && (stockExpansion1.DetailGoodsGanreCode == stockExpansion2.DetailGoodsGanreCode)
                 && (stockExpansion1.DetailGoodsGanreName == stockExpansion2.DetailGoodsGanreName)
                 && (stockExpansion1.BLGoodsCode == stockExpansion2.BLGoodsCode)
                 && (stockExpansion1.BLGoodsFullName == stockExpansion2.BLGoodsFullName)
                 && (stockExpansion1.GoodsShortName == stockExpansion2.GoodsShortName)
                 && (stockExpansion1.GoodsNameKana == stockExpansion2.GoodsNameKana)
                 && (stockExpansion1.EnterpriseGanreCode == stockExpansion2.EnterpriseGanreCode)
                 && (stockExpansion1.EnterpriseGanreName == stockExpansion2.EnterpriseGanreName)
                 && (stockExpansion1.Jan == stockExpansion2.Jan)
                 && (stockExpansion1.EnterpriseName == stockExpansion2.EnterpriseName)
                 && (stockExpansion1.UpdEmployeeName == stockExpansion2.UpdEmployeeName)
                 && (stockExpansion1.BLGoodsName == stockExpansion2.BLGoodsName)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (stockExpansion1.PriceDivCd == stockExpansion2.PriceDivCd)
                 && (stockExpansion1.NewPrice == stockExpansion2.NewPrice)
                 && (stockExpansion1.NewPriceStartDate == stockExpansion2.NewPriceStartDate)
                 && (stockExpansion1.OldPrice == stockExpansion2.OldPrice)
                 && (stockExpansion1.OpenPriceDiv == stockExpansion2.OpenPriceDiv)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                 && (stockExpansion1.MonthOrderCount == stockExpansion2.MonthOrderCount)
                 && (stockExpansion1.StockDiv == stockExpansion2.StockDiv)
                 && (stockExpansion1.StockSupplierCode == stockExpansion2.StockSupplierCode)
                 && (stockExpansion1.UpdateDate == stockExpansion2.UpdateDate)
                 && (stockExpansion1.SupplierLot == stockExpansion2.SupplierLot)
                 && (stockExpansion1.GoodsSpecialNote == stockExpansion2.GoodsSpecialNote)
                 && (stockExpansion1.SupplierSnm == stockExpansion2.SupplierSnm)
                 && (stockExpansion1.SupplierCd == stockExpansion2.SupplierCd)
                 && (stockExpansion1.ListPrice == stockExpansion2.ListPrice)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
                 );
        }
        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockExpansion�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockExpansion�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockExpansion target)
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.SupplierStock != target.SupplierStock) resList.Add("SupplierStock");
            if (this.TrustCount != target.TrustCount) resList.Add("TrustCount");
            if (this.AcpOdrCount != target.AcpOdrCount) resList.Add("AcpOdrCount");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.EntrustCnt != target.EntrustCnt) resList.Add("EntrustCnt");
            if (this.SoldCnt != target.SoldCnt) resList.Add("SoldCnt");
            if (this.MovingSupliStock != target.MovingSupliStock) resList.Add("MovingSupliStock");
            if (this.MovingTrustStock != target.MovingTrustStock) resList.Add("MovingTrustStock");
            if (this.ShipmentPosCnt != target.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (this.StockTotalPrice != target.StockTotalPrice) resList.Add("StockTotalPrice");
            if (this.LastStockDate != target.LastStockDate) resList.Add("LastStockDate");
            if (this.LastSalesDate != target.LastSalesDate) resList.Add("LastSalesDate");
            if (this.LastInventoryUpdate != target.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (this.MinimumStockCnt != target.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.NmlSalOdrCount != target.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (this.SalesOrderUnit != target.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.StockAssessmentRate != target.StockAssessmentRate) resList.Add("StockAssessmentRate");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.DuplicationShelfNo1 != target.DuplicationShelfNo1) resList.Add("DuplicationShelfNo1");
            if (this.DuplicationShelfNo2 != target.DuplicationShelfNo2) resList.Add("DuplicationShelfNo2");
            if (this.PartsManagementDivide1 != target.PartsManagementDivide1) resList.Add("PartsManagementDivide1");
            if (this.PartsManagementDivide2 != target.PartsManagementDivide2) resList.Add("PartsManagementDivide2");
            if (this.StockNote1 != target.StockNote1) resList.Add("StockNote1");
            if (this.StockNote2 != target.StockNote2) resList.Add("StockNote2");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.ArrivalCnt != target.ArrivalCnt) resList.Add("ArrivalCnt");
            if (this.StockCreateDate != target.StockCreateDate) resList.Add("StockCreateDate");
            if (this.LargeGoodsGanreCode != target.LargeGoodsGanreCode) resList.Add("LargeGoodsGanreCode");
            if (this.LargeGoodsGanreName != target.LargeGoodsGanreName) resList.Add("LargeGoodsGanreName");
            if (this.MediumGoodsGanreCode != target.MediumGoodsGanreCode) resList.Add("MediumGoodsGanreCode");
            if (this.MediumGoodsGanreName != target.MediumGoodsGanreName) resList.Add("MediumGoodsGanreName");
            if (this.DetailGoodsGanreCode != target.DetailGoodsGanreCode) resList.Add("DetailGoodsGanreCode");
            if (this.DetailGoodsGanreName != target.DetailGoodsGanreName) resList.Add("DetailGoodsGanreName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.GoodsShortName != target.GoodsShortName) resList.Add("GoodsShortName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.Jan != target.Jan) resList.Add("Jan");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (this.PriceDivCd != target.PriceDivCd) resList.Add("PriceDivCd");
            if (this.NewPrice != target.NewPrice) resList.Add("NewPrice");
            if (this.NewPriceStartDate != target.NewPriceStartDate) resList.Add("NewPriceStartDate");
            if (this.OldPrice != target.OldPrice) resList.Add("OldPrice");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
            if (this.MonthOrderCount != target.MonthOrderCount) resList.Add("MonthOrderCount");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.StockSupplierCode != target.StockSupplierCode) resList.Add("StockSupplierCode");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.SupplierLot != target.SupplierLot) resList.Add("SupplierLot");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

            return resList;
        }

        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="stockExpansion1">��r����StockExpansion�N���X�̃C���X�^���X</param>
        /// <param name="stockExpansion2">��r����StockExpansion�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockExpansion�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockExpansion stockExpansion1, StockExpansion stockExpansion2)
        {
            ArrayList resList = new ArrayList();
            if (stockExpansion1.CreateDateTime != stockExpansion2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockExpansion1.UpdateDateTime != stockExpansion2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockExpansion1.EnterpriseCode != stockExpansion2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockExpansion1.FileHeaderGuid != stockExpansion2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockExpansion1.UpdEmployeeCode != stockExpansion2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockExpansion1.UpdAssemblyId1 != stockExpansion2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockExpansion1.UpdAssemblyId2 != stockExpansion2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockExpansion1.LogicalDeleteCode != stockExpansion2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockExpansion1.SectionCode != stockExpansion2.SectionCode) resList.Add("SectionCode");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            if (stockExpansion1.SectionGuideNm != stockExpansion2.SectionGuideNm) resList.Add("SectionGuideNm");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END
            if (stockExpansion1.GoodsMakerCd != stockExpansion2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockExpansion1.MakerName != stockExpansion2.MakerName) resList.Add("MakerName");
            if (stockExpansion1.GoodsNo != stockExpansion2.GoodsNo) resList.Add("GoodsNo");
            if (stockExpansion1.GoodsName != stockExpansion2.GoodsName) resList.Add("GoodsName");
            if (stockExpansion1.StockUnitPriceFl != stockExpansion2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stockExpansion1.SupplierStock != stockExpansion2.SupplierStock) resList.Add("SupplierStock");
            if (stockExpansion1.TrustCount != stockExpansion2.TrustCount) resList.Add("TrustCount");
            if (stockExpansion1.AcpOdrCount != stockExpansion2.AcpOdrCount) resList.Add("AcpOdrCount");
            if (stockExpansion1.SalesOrderCount != stockExpansion2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (stockExpansion1.EntrustCnt != stockExpansion2.EntrustCnt) resList.Add("EntrustCnt");
            if (stockExpansion1.SoldCnt != stockExpansion2.SoldCnt) resList.Add("SoldCnt");
            if (stockExpansion1.MovingSupliStock != stockExpansion2.MovingSupliStock) resList.Add("MovingSupliStock");
            if (stockExpansion1.MovingTrustStock != stockExpansion2.MovingTrustStock) resList.Add("MovingTrustStock");
            if (stockExpansion1.ShipmentPosCnt != stockExpansion2.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (stockExpansion1.StockTotalPrice != stockExpansion2.StockTotalPrice) resList.Add("StockTotalPrice");
            if (stockExpansion1.LastStockDate != stockExpansion2.LastStockDate) resList.Add("LastStockDate");
            if (stockExpansion1.LastSalesDate != stockExpansion2.LastSalesDate) resList.Add("LastSalesDate");
            if (stockExpansion1.LastInventoryUpdate != stockExpansion2.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (stockExpansion1.MinimumStockCnt != stockExpansion2.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (stockExpansion1.MaximumStockCnt != stockExpansion2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (stockExpansion1.NmlSalOdrCount != stockExpansion2.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (stockExpansion1.SalesOrderUnit != stockExpansion2.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (stockExpansion1.WarehouseCode != stockExpansion2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockExpansion1.WarehouseName != stockExpansion2.WarehouseName) resList.Add("WarehouseName");
            if (stockExpansion1.GoodsNoNoneHyphen != stockExpansion2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (stockExpansion1.StockAssessmentRate != stockExpansion2.StockAssessmentRate) resList.Add("StockAssessmentRate");
            if (stockExpansion1.WarehouseShelfNo != stockExpansion2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockExpansion1.DuplicationShelfNo1 != stockExpansion2.DuplicationShelfNo1) resList.Add("DuplicationShelfNo1");
            if (stockExpansion1.DuplicationShelfNo2 != stockExpansion2.DuplicationShelfNo2) resList.Add("DuplicationShelfNo2");
            if (stockExpansion1.PartsManagementDivide1 != stockExpansion2.PartsManagementDivide1) resList.Add("PartsManagementDivide1");
            if (stockExpansion1.PartsManagementDivide2 != stockExpansion2.PartsManagementDivide2) resList.Add("PartsManagementDivide2");
            if (stockExpansion1.StockNote1 != stockExpansion2.StockNote1) resList.Add("StockNote1");
            if (stockExpansion1.StockNote2 != stockExpansion2.StockNote2) resList.Add("StockNote2");
            if (stockExpansion1.ShipmentCnt != stockExpansion2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (stockExpansion1.ArrivalCnt != stockExpansion2.ArrivalCnt) resList.Add("ArrivalCnt");
            if (stockExpansion1.StockCreateDate != stockExpansion2.StockCreateDate) resList.Add("StockCreateDate");
            if (stockExpansion1.LargeGoodsGanreCode != stockExpansion2.LargeGoodsGanreCode) resList.Add("LargeGoodsGanreCode");
            if (stockExpansion1.LargeGoodsGanreName != stockExpansion2.LargeGoodsGanreName) resList.Add("LargeGoodsGanreName");
            if (stockExpansion1.MediumGoodsGanreCode != stockExpansion2.MediumGoodsGanreCode) resList.Add("MediumGoodsGanreCode");
            if (stockExpansion1.MediumGoodsGanreName != stockExpansion2.MediumGoodsGanreName) resList.Add("MediumGoodsGanreName");
            if (stockExpansion1.DetailGoodsGanreCode != stockExpansion2.DetailGoodsGanreCode) resList.Add("DetailGoodsGanreCode");
            if (stockExpansion1.DetailGoodsGanreName != stockExpansion2.DetailGoodsGanreName) resList.Add("DetailGoodsGanreName");
            if (stockExpansion1.BLGoodsCode != stockExpansion2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockExpansion1.BLGoodsFullName != stockExpansion2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (stockExpansion1.GoodsShortName != stockExpansion2.GoodsShortName) resList.Add("GoodsShortName");
            if (stockExpansion1.GoodsNameKana != stockExpansion2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (stockExpansion1.EnterpriseGanreCode != stockExpansion2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (stockExpansion1.EnterpriseGanreName != stockExpansion2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (stockExpansion1.Jan != stockExpansion2.Jan) resList.Add("Jan");
            if (stockExpansion1.EnterpriseName != stockExpansion2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockExpansion1.UpdEmployeeName != stockExpansion2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockExpansion1.BLGoodsName != stockExpansion2.BLGoodsName) resList.Add("BLGoodsName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (stockExpansion1.PriceDivCd != stockExpansion2.PriceDivCd) resList.Add("PriceDivCd");
            if (stockExpansion1.NewPrice != stockExpansion2.NewPrice) resList.Add("NewPrice");
            if (stockExpansion1.NewPriceStartDate != stockExpansion2.NewPriceStartDate) resList.Add("NewPriceStartDate");
            if (stockExpansion1.OldPrice != stockExpansion2.OldPrice) resList.Add("OldPrice");
            if (stockExpansion1.OpenPriceDiv != stockExpansion2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
            if (stockExpansion1.MonthOrderCount != stockExpansion2.MonthOrderCount) resList.Add("MonthOrderCount");
            if (stockExpansion1.StockDiv != stockExpansion2.StockDiv) resList.Add("StockDiv");
            if (stockExpansion1.StockSupplierCode != stockExpansion2.StockSupplierCode) resList.Add("StockSupplierCode");
            if (stockExpansion1.UpdateDate != stockExpansion2.UpdateDate) resList.Add("UpdateDate");
            if (stockExpansion1.SupplierLot != stockExpansion2.SupplierLot) resList.Add("SupplierLot");
            if (stockExpansion1.GoodsSpecialNote != stockExpansion2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (stockExpansion1.SupplierSnm != stockExpansion2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockExpansion1.SupplierCd != stockExpansion2.SupplierCd) resList.Add("SupplierCd");
            if (stockExpansion1.ListPrice != stockExpansion2.ListPrice) resList.Add("ListPrice");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

            return resList;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        /// <summary>
        /// StockExpantion�I�u�W�F�N�g��Stock�I�u�W�F�N�g�ɕϊ�
        /// </summary>
        /// <param name="stockEx"></param>
        /// <returns></returns>
        public static Stock ConvertToStock(StockExpansion stockEx)
        {
            return new Stock(stockEx.CreateDateTime,
                        stockEx.UpdateDateTime,
                        stockEx.EnterpriseCode,
                        stockEx.FileHeaderGuid,
                        stockEx.UpdEmployeeCode,
                        stockEx.UpdAssemblyId1,
                        stockEx.UpdAssemblyId2,
                        stockEx.LogicalDeleteCode,
                        stockEx.SectionCode,
                        stockEx.WarehouseCode,
                        stockEx.GoodsMakerCd,
                        stockEx.GoodsNo,
                        stockEx.StockUnitPriceFl,
                        stockEx.SupplierStock,
                        stockEx.AcpOdrCount,
                        stockEx.MonthOrderCount,
                        stockEx.SalesOrderCount,
                        stockEx.StockDiv,
                        stockEx.MovingSupliStock,
                        stockEx.ShipmentPosCnt,
                        stockEx.StockTotalPrice,
                        stockEx.LastStockDate,
                        stockEx.LastSalesDate,
                        stockEx.LastInventoryUpdate,
                        stockEx.MinimumStockCnt,
                        stockEx.MaximumStockCnt,
                        stockEx.NmlSalOdrCount,
                        stockEx.SalesOrderUnit,
                        stockEx.StockSupplierCode,
                        stockEx.GoodsNoNoneHyphen,
                        stockEx.WarehouseShelfNo,
                        stockEx.DuplicationShelfNo1,
                        stockEx.DuplicationShelfNo2,
                        stockEx.PartsManagementDivide1,
                        stockEx.PartsManagementDivide2,
                        stockEx.StockNote1,
                        stockEx.StockNote2,
                        stockEx.ShipmentCnt,
                        stockEx.ArrivalCnt,
                        stockEx.StockCreateDate,
                        stockEx.UpdateDateDT,
                        stockEx.EnterpriseName,
                        stockEx.UpdEmployeeName,
                        stockEx.WarehouseName,
                        stockEx.GoodsName,
                        stockEx.MakerName,
                        stockEx.GoodsSpecialNote,
                        stockEx.SupplierCd,
                        stockEx.SupplierLot,
                        stockEx.SupplierSnm
                        );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
        # endregion

    }
}
