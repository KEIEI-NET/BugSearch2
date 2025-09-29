using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockEachWarehouseWork
    /// <summary>
    ///                      ���i�݌Ɍ������ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�݌Ɍ������ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockEachWarehouseWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���_���ݒ�}�X�^</remarks>
        private string _sectionGuideNm = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�q�Ƀ}�X�^</remarks>
        private string _warehouseName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _goodsNo = "";

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d���݌ɐ�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _supplierStock;

        /// <summary>�󒍐�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _acpOdrCount;

        /// <summary>M/O������</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _monthOrderCount;

        /// <summary>������</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _salesOrderCount;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Int32 _stockDiv;

        /// <summary>�ړ����d���݌ɐ�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _movingSupliStock;

        /// <summary>�o�׉\��</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _shipmentPosCnt;

        /// <summary>�݌ɕۗL���z</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�ŏI�d���N����</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _lastStockDate;

        /// <summary>�ŏI�����</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _lastSalesDate;

        /// <summary>�ŏI�I���X�V��</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _lastInventoryUpdate;

        /// <summary>�Œ�݌ɐ�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _minimumStockCnt;

        /// <summary>�ō��݌ɐ�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _maximumStockCnt;

        /// <summary>�������</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _nmlSalOdrCount;

        /// <summary>�����P��</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>�݌ɔ�����R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _goodsNoNoneHyphen = "";

        /// <summary>�q�ɒI��</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _warehouseShelfNo = "";

        /// <summary>�d���I�ԂP</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _duplicationShelfNo1 = "";

        /// <summary>�d���I�ԂQ</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _duplicationShelfNo2 = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _partsManagementDivide1 = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _partsManagementDivide2 = "";

        /// <summary>�݌ɔ��l�P</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _stockNote1 = "";

        /// <summary>�݌ɔ��l�Q</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private string _stockNote2 = "";

        /// <summary>�o�א��i���v��j</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _shipmentCnt;

        /// <summary>���א��i���v��j</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private Double _arrivalCnt;

        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _stockCreateDate;

        /// <summary>�X�V�N����</summary>
        /// <remarks>�݌Ƀ}�X�^</remarks>
        private DateTime _updateDate;

        /// <summary>�i��</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _goodsName = "";

        /// <summary>BL�R�[�h</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>���i���̃J�i</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _goodsNameKana = "";

        /// <summary>���i�K�i�E���L����</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _goodsSpecialNote = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>JAN�R�[�h</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _Jan = "";

        /// <summary>�\������</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _DisplayOrder;

        /// <summary>���i�|�������N</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _GoodsRateRank = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _TaxationDivCd;

        /// <summary>�񋟓��t</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _OfferDate;

        /// <summary>���i����</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _GoodsKindCode;

        /// <summary>���i���l</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _GoodsNote1 = "";

        /// <summary>���i���l</summary>
        /// <remarks>���i�}�X�^</remarks>
        private string _GoodsNote2 = "";

        /// <summary>���Е��ރR�[�h</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _EnterpriseGanreCode;

        /// <summary>���i�J�n��</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _PriceStartDate;

        /// <summary>�艿�i�����j</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Double _ListPrice;

        /// <summary>�����P��</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Double _SalesUnitCost;

        /// <summary>�d����</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Double _StockRate;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>���i�}�X�^</remarks>
        private Int32 _OpenPriceDiv;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>���_���ݒ�}�X�^</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�q�Ƀ}�X�^</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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

        /// public propaty name  :  LastSalesDate
        /// <summary>�ŏI������v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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

        /// public propaty name  :  LastInventoryUpdate
        /// <summary>�ŏI�I���X�V���v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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

        /// public propaty name  :  MinimumStockCnt
        /// <summary>�Œ�݌ɐ��v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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
        /// <value>�݌Ƀ}�X�^</value>
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

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
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

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// public propaty name  :  Jan
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _Jan; }
            set { _Jan = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _GoodsRateRank; }
            set { _GoodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _TaxationDivCd; }
            set { _TaxationDivCd = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _OfferDate; }
            set { _OfferDate = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _GoodsKindCode; }
            set { _GoodsKindCode = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>���i���l1�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _GoodsNote1; }
            set { _GoodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>���i���l2�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _GoodsNote2; }
            set { _GoodsNote2 = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _EnterpriseGanreCode; }
            set { _EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _PriceStartDate; }
            set { _PriceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _ListPrice; }
            set { _ListPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _SalesUnitCost; }
            set { _SalesUnitCost = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _StockRate; }
            set { _StockRate = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>���i�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _OpenPriceDiv; }
            set { _OpenPriceDiv = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD


        /// <summary>
        /// ���i�݌Ɍ������ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockEachWarehouseWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockEachWarehouseWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockEachWarehouseWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockEachWarehouseWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockEachWarehouseWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockEachWarehouseWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockEachWarehouseWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockEachWarehouseWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockEachWarehouseWork || graph is ArrayList || graph is StockEachWarehouseWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockEachWarehouseWork).FullName));

            if (graph != null && graph is StockEachWarehouseWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockEachWarehouseWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockEachWarehouseWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockEachWarehouseWork[])graph).Length;
            }
            else if (graph is StockEachWarehouseWork)
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
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�d���P���i�Ŕ�,�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //�󒍐�
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //M/O������
            serInfo.MemberInfo.Add(typeof(Double)); //MonthOrderCount
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�ړ����d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //�݌ɕۗL���z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�ŏI�d���N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastStockDate
            //�ŏI�����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastSalesDate
            //�ŏI�I���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //LastInventoryUpdate
            //�Œ�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //�ō��݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //�������
            serInfo.MemberInfo.Add(typeof(Double)); //NmlSalOdrCount
            //�����P��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderUnit
            //�݌ɔ�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���I�ԂP
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //�d���I�ԂQ
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //���i�Ǘ��敪�P
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide1
            //���i�Ǘ��敪�Q
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide2
            //�݌ɔ��l�P
            serInfo.MemberInfo.Add(typeof(string)); //StockNote1
            //�݌ɔ��l�Q
            serInfo.MemberInfo.Add(typeof(string)); //StockNote2
            //�o�א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //���א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //�݌ɓo�^��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            //JAN�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //_Jan = "";
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32));   //_DisplayOrder;
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //_GoodsRateRank = "";
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32));   //_TaxationDivCd;
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32));   //_OfferDate;
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32));   //_GoodsKindCode;
            //���i���l1
            serInfo.MemberInfo.Add(typeof(string)); //_GoodsNote1 = "";
            //���i���l2
            serInfo.MemberInfo.Add(typeof(string)); //_GoodsNote2 = "";
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32));   //_EnterpriseGanreCode = "";
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32));   //_PriceStartDate;
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double));  //_ListPrice;
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double));  //_SalesUnitCost;
            //�d����
            serInfo.MemberInfo.Add(typeof(Double));  //_StockRate;
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32));   //_OpenPriceDiv;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD


            serInfo.Serialize(writer, serInfo);
            if (graph is StockEachWarehouseWork)
            {
                StockEachWarehouseWork temp = (StockEachWarehouseWork)graph;

                SetStockEachWarehouseWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockEachWarehouseWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockEachWarehouseWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockEachWarehouseWork temp in lst)
                {
                    SetStockEachWarehouseWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockEachWarehouseWork�����o��(public�v���p�e�B��)
        /// </summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 UPD
        //private const int currentMemberCount = 47;
        private const int currentMemberCount = 61;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 UPD

        /// <summary>
        ///  StockEachWarehouseWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockEachWarehouseWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockEachWarehouseWork(System.IO.BinaryWriter writer, StockEachWarehouseWork temp)
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
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�d���P���i�Ŕ�,�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���݌ɐ�
            writer.Write(temp.SupplierStock);
            //�󒍐�
            writer.Write(temp.AcpOdrCount);
            //M/O������
            writer.Write(temp.MonthOrderCount);
            //������
            writer.Write(temp.SalesOrderCount);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�ړ����d���݌ɐ�
            writer.Write(temp.MovingSupliStock);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //�݌ɕۗL���z
            writer.Write(temp.StockTotalPrice);
            //�ŏI�d���N����
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //�ŏI�����
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //�ŏI�I���X�V��
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //�Œ�݌ɐ�
            writer.Write(temp.MinimumStockCnt);
            //�ō��݌ɐ�
            writer.Write(temp.MaximumStockCnt);
            //�������
            writer.Write(temp.NmlSalOdrCount);
            //�����P��
            writer.Write(temp.SalesOrderUnit);
            //�݌ɔ�����R�[�h
            writer.Write(temp.StockSupplierCode);
            //�n�C�t�������i�ԍ�
            writer.Write(temp.GoodsNoNoneHyphen);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���I�ԂP
            writer.Write(temp.DuplicationShelfNo1);
            //�d���I�ԂQ
            writer.Write(temp.DuplicationShelfNo2);
            //���i�Ǘ��敪�P
            writer.Write(temp.PartsManagementDivide1);
            //���i�Ǘ��敪�Q
            writer.Write(temp.PartsManagementDivide2);
            //�݌ɔ��l�P
            writer.Write(temp.StockNote1);
            //�݌ɔ��l�Q
            writer.Write(temp.StockNote2);
            //�o�א��i���v��j
            writer.Write(temp.ShipmentCnt);
            //���א��i���v��j
            writer.Write(temp.ArrivalCnt);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�i��
            writer.Write(temp.GoodsName);
            //BL�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //���i�K�i�E���L����
            writer.Write(temp.GoodsSpecialNote);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            //JAN�R�[�h
            writer.Write(temp.Jan);
            //�\������
            writer.Write(temp.DisplayOrder);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���i���l1
            writer.Write(temp.GoodsNote1);
            //���i���l2
            writer.Write(temp.GoodsNote2);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���i�J�n��
            writer.Write(temp.PriceStartDate);
            //�艿�i�����j
            writer.Write(temp.ListPrice);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //�d����
            writer.Write(temp.StockRate);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        }

        /// <summary>
        ///  StockEachWarehouseWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockEachWarehouseWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockEachWarehouseWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockEachWarehouseWork GetStockEachWarehouseWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockEachWarehouseWork temp = new StockEachWarehouseWork();

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
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�d���P���i�Ŕ�,�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���݌ɐ�
            temp.SupplierStock = reader.ReadDouble();
            //�󒍐�
            temp.AcpOdrCount = reader.ReadDouble();
            //M/O������
            temp.MonthOrderCount = reader.ReadDouble();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�ړ����d���݌ɐ�
            temp.MovingSupliStock = reader.ReadDouble();
            //�o�׉\��
            temp.ShipmentPosCnt = reader.ReadDouble();
            //�݌ɕۗL���z
            temp.StockTotalPrice = reader.ReadInt64();
            //�ŏI�d���N����
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //�ŏI�����
            temp.LastSalesDate = new DateTime(reader.ReadInt64());
            //�ŏI�I���X�V��
            temp.LastInventoryUpdate = new DateTime(reader.ReadInt64());
            //�Œ�݌ɐ�
            temp.MinimumStockCnt = reader.ReadDouble();
            //�ō��݌ɐ�
            temp.MaximumStockCnt = reader.ReadDouble();
            //�������
            temp.NmlSalOdrCount = reader.ReadDouble();
            //�����P��
            temp.SalesOrderUnit = reader.ReadInt32();
            //�݌ɔ�����R�[�h
            temp.StockSupplierCode = reader.ReadInt32();
            //�n�C�t�������i�ԍ�
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���I�ԂP
            temp.DuplicationShelfNo1 = reader.ReadString();
            //�d���I�ԂQ
            temp.DuplicationShelfNo2 = reader.ReadString();
            //���i�Ǘ��敪�P
            temp.PartsManagementDivide1 = reader.ReadString();
            //���i�Ǘ��敪�Q
            temp.PartsManagementDivide2 = reader.ReadString();
            //�݌ɔ��l�P
            temp.StockNote1 = reader.ReadString();
            //�݌ɔ��l�Q
            temp.StockNote2 = reader.ReadString();
            //�o�א��i���v��j
            temp.ShipmentCnt = reader.ReadDouble();
            //���א��i���v��j
            temp.ArrivalCnt = reader.ReadDouble();
            //�݌ɓo�^��
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�i��
            temp.GoodsName = reader.ReadString();
            //BL�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //���i�K�i�E���L����
            temp.GoodsSpecialNote = reader.ReadString();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            //JAN�R�[�h
            temp.Jan = reader.ReadString();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i���l1
            temp.GoodsNote1 = reader.ReadString();
            //���i���l2
            temp.GoodsNote2 = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���i�J�n��
            temp.PriceStartDate = reader.ReadInt32();
            //�艿�i�����j
            temp.ListPrice = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //�d����
            temp.StockRate = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

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
        /// <returns>StockEachWarehouseWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockEachWarehouseWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockEachWarehouseWork temp = GetStockEachWarehouseWork(reader, serInfo);
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
                    retValue = (StockEachWarehouseWork[])lst.ToArray(typeof(StockEachWarehouseWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
