using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Stock
    /// <summary>
    ///                      �݌Ƀ}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ƀ}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2008/07/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/8  ����</br>
    /// <br>                 :   �o�׉\���̕⑫�C��</br>
    /// </remarks>
    public class Stock
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

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        // �����[�g�N���X����擾�͂��Ȃ����\���̂��߂ɕێ����鍀��

        /// <summary>�K�i�E���L����</summary>
        private string _goodsSpecialNote = "";

        /// <summary>�������b�g</summary>
        private Double _supplierLot;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm;



        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>���݌ɕ]���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���݌ɐ�</summary>
        /// <remarks>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
        private Double _supplierStock;

        /// <summary>�󒍐�</summary>
        private Double _acpOdrCount;

        /// <summary>M/O������</summary>
        private Double _monthOrderCount;

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:����,1:���</remarks>
        private Int32 _stockDiv;

        /// <summary>�ړ����d���݌ɐ�</summary>
        /// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
        private Double _movingSupliStock;

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
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

        /// <summary>�݌ɔ�����R�[�h</summary>
        /// <remarks>�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

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

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

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

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
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

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:����,1:���</value>
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

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
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

        /// public propaty name  :  StockSupplierCode
        /// <summary>�݌ɔ�����R�[�h�v���p�e�B</summary>
        /// <value>�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j</value>
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

        /// public propaty name  :  StockCreateDateJpFormal
        /// <summary>�݌ɓo�^�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockCreateDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  StockCreateDateJpInFormal
        /// <summary>�݌ɓo�^�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockCreateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  StockCreateDateAdFormal
        /// <summary>�݌ɓo�^�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockCreateDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  StockCreateDateAdInFormal
        /// <summary>�݌ɓo�^�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockCreateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockCreateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateDateJpFormal
        /// <summary>�X�V�N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDateJpInFormal
        /// <summary>�X�V�N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdFormal
        /// <summary>�X�V�N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdInFormal
        /// <summary>�X�V�N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
            set { }
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

        /// public property name  :  GoodsName
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

        /// public property name  :  MakerName
        /// <summary>���i���̃v���p�e�B</summary>
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

        /// <summary>
        /// �݌Ƀ}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>Stock�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Stock()
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
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="stockUnitPriceFl">�d���P���i�Ŕ�,�����j(���݌ɕ]���P��)</param>
        /// <param name="supplierStock">�d���݌ɐ�(��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj)</param>
        /// <param name="acpOdrCount">�󒍐�</param>
        /// <param name="monthOrderCount">M/O������</param>
        /// <param name="salesOrderCount">������</param>
        /// <param name="stockDiv">�݌ɋ敪(0:����,1:���)</param>
        /// <param name="movingSupliStock">�ړ����d���݌ɐ�(�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B)</param>
        /// <param name="shipmentPosCnt">�o�׉\��(�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�)</param>
        /// <param name="stockTotalPrice">�݌ɕۗL���z(�l���܂�)</param>
        /// <param name="lastStockDate">�ŏI�d���N����(YYYYMMDD)</param>
        /// <param name="lastSalesDate">�ŏI�����(YYYYMMDD)</param>
        /// <param name="lastInventoryUpdate">�ŏI�I���X�V��(YYYYMMDD)</param>
        /// <param name="minimumStockCnt">�Œ�݌ɐ�</param>
        /// <param name="maximumStockCnt">�ō��݌ɐ�</param>
        /// <param name="nmlSalOdrCount">�������</param>
        /// <param name="salesOrderUnit">�����P��(��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j)</param>
        /// <param name="stockSupplierCode">�݌ɔ�����R�[�h(�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j)</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
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
        /// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <returns>Stock�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Stock(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string warehouseCode, Int32 goodsMakerCd, string goodsNo, Double stockUnitPriceFl, Double supplierStock, Double acpOdrCount, Double monthOrderCount, Double salesOrderCount, Int32 stockDiv, Double movingSupliStock, Double shipmentPosCnt, Int64 stockTotalPrice, DateTime lastStockDate, DateTime lastSalesDate, DateTime lastInventoryUpdate, Double minimumStockCnt, Double maximumStockCnt, Double nmlSalOdrCount, Int32 salesOrderUnit, Int32 stockSupplierCode, string goodsNoNoneHyphen, string warehouseShelfNo, string duplicationShelfNo1, string duplicationShelfNo2, string partsManagementDivide1, string partsManagementDivide2, string stockNote1, string stockNote2, Double shipmentCnt, Double arrivalCnt, DateTime stockCreateDate, DateTime updateDate, string enterpriseName, string updEmployeeName, string warehouseName, string goodsName, string makerName, string goodsSpecialNote, int supplierCd, Double supplierLot, string supplierSnm)
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
            this._warehouseCode = warehouseCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._supplierStock = supplierStock;
            this._acpOdrCount = acpOdrCount;
            this._monthOrderCount = monthOrderCount;
            this._salesOrderCount = salesOrderCount;
            this._stockDiv = stockDiv;
            this._movingSupliStock = movingSupliStock;
            this._shipmentPosCnt = shipmentPosCnt;
            this._stockTotalPrice = stockTotalPrice;
            this.LastStockDate = lastStockDate;
            this.LastSalesDate = lastSalesDate;
            this.LastInventoryUpdate = lastInventoryUpdate;
            this._minimumStockCnt = minimumStockCnt;
            this._maximumStockCnt = maximumStockCnt;
            this._nmlSalOdrCount = nmlSalOdrCount;
            this._salesOrderUnit = salesOrderUnit;
            this._stockSupplierCode = stockSupplierCode;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._warehouseShelfNo = warehouseShelfNo;
            this._duplicationShelfNo1 = duplicationShelfNo1;
            this._duplicationShelfNo2 = duplicationShelfNo2;
            this._partsManagementDivide1 = partsManagementDivide1;
            this._partsManagementDivide2 = partsManagementDivide2;
            this._stockNote1 = stockNote1;
            this._stockNote2 = stockNote2;
            this._shipmentCnt = shipmentCnt;
            this._arrivalCnt = arrivalCnt;
            this.StockCreateDate = stockCreateDate;
            this.UpdateDate = updateDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._warehouseName = warehouseName;
            this._goodsName = goodsName;
            this._makerName = makerName;
            this._goodsSpecialNote = goodsSpecialNote;
            this._supplierCd = supplierCd;
            this._supplierLot = supplierLot;
            this._supplierSnm = supplierSnm;
        }

        /// <summary>
        /// �݌Ƀ}�X�^��������
        /// </summary>
        /// <returns>Stock�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Stock�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Stock Clone()
        {
            return new Stock(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._warehouseCode, this._goodsMakerCd, this._goodsNo, this._stockUnitPriceFl, this._supplierStock, this._acpOdrCount, this._monthOrderCount, this._salesOrderCount, this._stockDiv, this._movingSupliStock, this._shipmentPosCnt, this._stockTotalPrice, this._lastStockDate, this._lastSalesDate, this._lastInventoryUpdate, this._minimumStockCnt, this._maximumStockCnt, this._nmlSalOdrCount, this._salesOrderUnit, this._stockSupplierCode, this._goodsNoNoneHyphen, this._warehouseShelfNo, this._duplicationShelfNo1, this._duplicationShelfNo2, this._partsManagementDivide1, this._partsManagementDivide2, this._stockNote1, this._stockNote2, this._shipmentCnt, this._arrivalCnt, this._stockCreateDate, this._updateDate, this._enterpriseName, this._updEmployeeName, this._warehouseName, this._goodsName, this._makerName, this._goodsSpecialNote, this.SupplierCd, this.SupplierLot, this.SupplierSnm);
        }

        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Stock�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(Stock target)
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
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.SupplierStock == target.SupplierStock)
                 && (this.AcpOdrCount == target.AcpOdrCount)
                 && (this.MonthOrderCount == target.MonthOrderCount)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.StockDiv == target.StockDiv)
                 && (this.MovingSupliStock == target.MovingSupliStock)
                 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
                 && (this.StockTotalPrice == target.StockTotalPrice)
                 && (this.LastStockDate == target.LastStockDate)
                 && (this.LastSalesDate == target.LastSalesDate)
                 && (this.LastInventoryUpdate == target.LastInventoryUpdate)
                 && (this.MinimumStockCnt == target.MinimumStockCnt)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.NmlSalOdrCount == target.NmlSalOdrCount)
                 && (this.SalesOrderUnit == target.SalesOrderUnit)
                 && (this.StockSupplierCode == target.StockSupplierCode)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
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
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.GoodsName == target.GoodsName)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierLot == target.SupplierLot)
                 && (this.SupplierSnm == target.SupplierSnm));
            
        }

        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="stock1">
        ///                    ��r����Stock�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stock2">��r����Stock�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(Stock stock1, Stock stock2)
        {
            return ((stock1.CreateDateTime == stock2.CreateDateTime)
                 && (stock1.UpdateDateTime == stock2.UpdateDateTime)
                 && (stock1.EnterpriseCode == stock2.EnterpriseCode)
                 && (stock1.FileHeaderGuid == stock2.FileHeaderGuid)
                 && (stock1.UpdEmployeeCode == stock2.UpdEmployeeCode)
                 && (stock1.UpdAssemblyId1 == stock2.UpdAssemblyId1)
                 && (stock1.UpdAssemblyId2 == stock2.UpdAssemblyId2)
                 && (stock1.LogicalDeleteCode == stock2.LogicalDeleteCode)
                 && (stock1.SectionCode == stock2.SectionCode)
                 && (stock1.WarehouseCode == stock2.WarehouseCode)
                 && (stock1.GoodsMakerCd == stock2.GoodsMakerCd)
                 && (stock1.GoodsNo == stock2.GoodsNo)
                 && (stock1.StockUnitPriceFl == stock2.StockUnitPriceFl)
                 && (stock1.SupplierStock == stock2.SupplierStock)
                 && (stock1.AcpOdrCount == stock2.AcpOdrCount)
                 && (stock1.MonthOrderCount == stock2.MonthOrderCount)
                 && (stock1.SalesOrderCount == stock2.SalesOrderCount)
                 && (stock1.StockDiv == stock2.StockDiv)
                 && (stock1.MovingSupliStock == stock2.MovingSupliStock)
                 && (stock1.ShipmentPosCnt == stock2.ShipmentPosCnt)
                 && (stock1.StockTotalPrice == stock2.StockTotalPrice)
                 && (stock1.LastStockDate == stock2.LastStockDate)
                 && (stock1.LastSalesDate == stock2.LastSalesDate)
                 && (stock1.LastInventoryUpdate == stock2.LastInventoryUpdate)
                 && (stock1.MinimumStockCnt == stock2.MinimumStockCnt)
                 && (stock1.MaximumStockCnt == stock2.MaximumStockCnt)
                 && (stock1.NmlSalOdrCount == stock2.NmlSalOdrCount)
                 && (stock1.SalesOrderUnit == stock2.SalesOrderUnit)
                 && (stock1.StockSupplierCode == stock2.StockSupplierCode)
                 && (stock1.GoodsNoNoneHyphen == stock2.GoodsNoNoneHyphen)
                 && (stock1.WarehouseShelfNo == stock2.WarehouseShelfNo)
                 && (stock1.DuplicationShelfNo1 == stock2.DuplicationShelfNo1)
                 && (stock1.DuplicationShelfNo2 == stock2.DuplicationShelfNo2)
                 && (stock1.PartsManagementDivide1 == stock2.PartsManagementDivide1)
                 && (stock1.PartsManagementDivide2 == stock2.PartsManagementDivide2)
                 && (stock1.StockNote1 == stock2.StockNote1)
                 && (stock1.StockNote2 == stock2.StockNote2)
                 && (stock1.ShipmentCnt == stock2.ShipmentCnt)
                 && (stock1.ArrivalCnt == stock2.ArrivalCnt)
                 && (stock1.StockCreateDate == stock2.StockCreateDate)
                 && (stock1.UpdateDate == stock2.UpdateDate)
                 && (stock1.EnterpriseName == stock2.EnterpriseName)
                 && (stock1.UpdEmployeeName == stock2.UpdEmployeeName)
                 && (stock1.WarehouseName == stock2.WarehouseName)
                 && (stock1.GoodsName == stock2.GoodsName)
                 && (stock1.MakerName == stock2.MakerName)
                 && (stock1.GoodsSpecialNote == stock2.GoodsSpecialNote)
                 && (stock1.SupplierCd == stock2.SupplierCd)
                 && (stock1.SupplierLot == stock2.SupplierLot)
                 && (stock1.SupplierSnm == stock2.SupplierSnm)
                 );
        }
        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Stock�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(Stock target)
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
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.SupplierStock != target.SupplierStock) resList.Add("SupplierStock");
            if (this.AcpOdrCount != target.AcpOdrCount) resList.Add("AcpOdrCount");
            if (this.MonthOrderCount != target.MonthOrderCount) resList.Add("MonthOrderCount");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.MovingSupliStock != target.MovingSupliStock) resList.Add("MovingSupliStock");
            if (this.ShipmentPosCnt != target.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (this.StockTotalPrice != target.StockTotalPrice) resList.Add("StockTotalPrice");
            if (this.LastStockDate != target.LastStockDate) resList.Add("LastStockDate");
            if (this.LastSalesDate != target.LastSalesDate) resList.Add("LastSalesDate");
            if (this.LastInventoryUpdate != target.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (this.MinimumStockCnt != target.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.NmlSalOdrCount != target.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (this.SalesOrderUnit != target.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (this.StockSupplierCode != target.StockSupplierCode) resList.Add("StockSupplierCode");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
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
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierLot != target.SupplierLot) resList.Add("SupplierLot");

            return resList;
        }

        /// <summary>
        /// �݌Ƀ}�X�^��r����
        /// </summary>
        /// <param name="stock1">��r����Stock�N���X�̃C���X�^���X</param>
        /// <param name="stock2">��r����Stock�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(Stock stock1, Stock stock2)
        {
            ArrayList resList = new ArrayList();
            if (stock1.CreateDateTime != stock2.CreateDateTime) resList.Add("CreateDateTime");
            if (stock1.UpdateDateTime != stock2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stock1.EnterpriseCode != stock2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stock1.FileHeaderGuid != stock2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stock1.UpdEmployeeCode != stock2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stock1.UpdAssemblyId1 != stock2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stock1.UpdAssemblyId2 != stock2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stock1.LogicalDeleteCode != stock2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stock1.SectionCode != stock2.SectionCode) resList.Add("SectionCode");
            if (stock1.WarehouseCode != stock2.WarehouseCode) resList.Add("WarehouseCode");
            if (stock1.GoodsMakerCd != stock2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stock1.GoodsNo != stock2.GoodsNo) resList.Add("GoodsNo");
            if (stock1.StockUnitPriceFl != stock2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stock1.SupplierStock != stock2.SupplierStock) resList.Add("SupplierStock");
            if (stock1.AcpOdrCount != stock2.AcpOdrCount) resList.Add("AcpOdrCount");
            if (stock1.MonthOrderCount != stock2.MonthOrderCount) resList.Add("MonthOrderCount");
            if (stock1.SalesOrderCount != stock2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (stock1.StockDiv != stock2.StockDiv) resList.Add("StockDiv");
            if (stock1.MovingSupliStock != stock2.MovingSupliStock) resList.Add("MovingSupliStock");
            if (stock1.ShipmentPosCnt != stock2.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (stock1.StockTotalPrice != stock2.StockTotalPrice) resList.Add("StockTotalPrice");
            if (stock1.LastStockDate != stock2.LastStockDate) resList.Add("LastStockDate");
            if (stock1.LastSalesDate != stock2.LastSalesDate) resList.Add("LastSalesDate");
            if (stock1.LastInventoryUpdate != stock2.LastInventoryUpdate) resList.Add("LastInventoryUpdate");
            if (stock1.MinimumStockCnt != stock2.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (stock1.MaximumStockCnt != stock2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (stock1.NmlSalOdrCount != stock2.NmlSalOdrCount) resList.Add("NmlSalOdrCount");
            if (stock1.SalesOrderUnit != stock2.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (stock1.StockSupplierCode != stock2.StockSupplierCode) resList.Add("StockSupplierCode");
            if (stock1.GoodsNoNoneHyphen != stock2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (stock1.WarehouseShelfNo != stock2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stock1.DuplicationShelfNo1 != stock2.DuplicationShelfNo1) resList.Add("DuplicationShelfNo1");
            if (stock1.DuplicationShelfNo2 != stock2.DuplicationShelfNo2) resList.Add("DuplicationShelfNo2");
            if (stock1.PartsManagementDivide1 != stock2.PartsManagementDivide1) resList.Add("PartsManagementDivide1");
            if (stock1.PartsManagementDivide2 != stock2.PartsManagementDivide2) resList.Add("PartsManagementDivide2");
            if (stock1.StockNote1 != stock2.StockNote1) resList.Add("StockNote1");
            if (stock1.StockNote2 != stock2.StockNote2) resList.Add("StockNote2");
            if (stock1.ShipmentCnt != stock2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (stock1.ArrivalCnt != stock2.ArrivalCnt) resList.Add("ArrivalCnt");
            if (stock1.StockCreateDate != stock2.StockCreateDate) resList.Add("StockCreateDate");
            if (stock1.UpdateDate != stock2.UpdateDate) resList.Add("UpdateDate");
            if (stock1.EnterpriseName != stock2.EnterpriseName) resList.Add("EnterpriseName");
            if (stock1.UpdEmployeeName != stock2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stock1.WarehouseName != stock2.WarehouseName) resList.Add("WarehouseName");
            if (stock1.GoodsName != stock2.GoodsName) resList.Add("GoodsName");
            if (stock1.MakerName != stock2.MakerName) resList.Add("MakerName");
            if (stock1.GoodsSpecialNote != stock2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (stock1.SupplierCd != stock2.SupplierCd) resList.Add("SupplierCd");
            if (stock1.SupplierSnm != stock2.SupplierSnm) resList.Add("SupplierSnm");
            if (stock1.SupplierLot != stock2.SupplierLot) resList.Add("SupplierLot");

            return resList;
        }
    }
}
