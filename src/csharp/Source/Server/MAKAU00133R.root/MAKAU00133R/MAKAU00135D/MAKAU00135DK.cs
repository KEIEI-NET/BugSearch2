using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryWork
    /// <summary>
    ///                      �݌ɗ����f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɗ����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/07/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryWork : IFileHeader
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

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>�O�����݌ɐ�</summary>
        /// <remarks>�O���́u�݌ɑ����v</remarks>
        private Double _lMonthStockCnt;

        /// <summary>�O�����݌Ɋz</summary>
        /// <remarks>�O���́u�}�V���݌ɋ��z�v</remarks>
        private Int64 _lMonthStockPrice;

        /// <summary>�O�������Ѝ݌ɐ�</summary>
        private Double _lMonthPptyStockCnt;

        /// <summary>�O�������Ѝ݌ɋ��z</summary>
        private Int64 _lMonthPptyStockPrice;

        /// <summary>�����</summary>
        private Int32 _salesTimes;

        /// <summary>���㐔</summary>
        private Double _salesCount;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>����ԕi��</summary>
        private Int32 _salesRetGoodsTimes;

        /// <summary>����ԕi��</summary>
        private Double _salesRetGoodsCnt;

        /// <summary>����ԕi�z</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;

        /// <summary>�d����</summary>
        private Int32 _stockTimes;

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d���ԕi��</summary>
        private Int32 _stockRetGoodsTimes;

        /// <summary>�d���ԕi��</summary>
        private Double _stockRetGoodsCnt;

        /// <summary>�d���ԕi�z</summary>
        private Int64 _stockRetGoodsPrice;

        /// <summary>�ړ����א�</summary>
        private Double _moveArrivalCnt;

        /// <summary>�ړ����׊z</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>�ړ��o�א�</summary>
        private Double _moveShipmentCnt;

        /// <summary>�ړ��o�׊z</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>������</summary>
        private Double _adjustCount;

        /// <summary>�������z</summary>
        private Int64 _adjustPrice;

        /// <summary>���א�</summary>
        /// <remarks>���o�ד��������̎d���i���ׁj�̐���</remarks>
        private Double _arrivalCnt;

        /// <summary>���׋��z</summary>
        /// <remarks>��L���z</remarks>
        private Int64 _arrivalPrice;

        /// <summary>�o�א�</summary>
        /// <remarks>���o�ד��������̔���i�o�ׁj�̐���</remarks>
        private Double _shipmentCnt;

        /// <summary>�o�׋��z</summary>
        /// <remarks>��L���z</remarks>
        private Int64 _shipmentPrice;

        /// <summary>�����א�</summary>
        /// <remarks>���o�ד��������̓��ׂ��������i���ׁA�d���A�ړ����ׁA�����A�I���j</remarks>
        private Double _totalArrivalCnt;

        /// <summary>�����׋��z</summary>
        /// <remarks>��L���z</remarks>
        private Int64 _totalArrivalPrice;

        /// <summary>���o�א�</summary>
        /// <remarks>���o�ד��������̏o�ׂ��������i�o�ׁA����A�ړ��o�ׁj</remarks>
        private Double _totalShipmentCnt;

        /// <summary>���o�׋��z</summary>
        /// <remarks>��L���z</remarks>
        private Int64 _totalShipmentPrice;

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�I���]���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�݌ɑ���</summary>
        /// <remarks>���ׁA�o�ׂ��܂ލ݌ɐ��i���o�ד��x�[�X�j</remarks>
        private Double _stockTotal;

        /// <summary>�}�V���݌Ɋz</summary>
        /// <remarks>���ׁA�o�ׂ��܂ލ݌ɋ��z</remarks>
        private Int64 _stockMashinePrice;

        /// <summary>���Ѝ݌ɐ�</summary>
        /// <remarks>���Ђ̎��Y�̍݌ɐ��i�v����x�[�X�j</remarks>
        private Double _propertyStockCnt;

        /// <summary>���Ѝ݌ɋ��z</summary>
        /// <remarks>���Ђ̎��Y�̍݌ɋ��z</remarks>
        private Int64 _propertyStockPrice;

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        // -------ADD 2010/09/21--------->>>>>
        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        /// <remarks>BL���i�R�[�h���́i���p�j</remarks>
        private string _bLGoodsHalfName;
        // -------ADD 2010/09/21---------<<<<<

        // -------ADD 2010/09/28--------->>>>>
        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _wareHouseCd;
        // -------ADD 2010/09/28---------<<<<<

        /// <summary>�I��</summary>
        /// <remarks>�I��</remarks>
        private String _warehouseShelfno;

        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>�݌ɓo�^��</remarks>
        private DateTime _stockCreateDate;

        /// <summary>�ŏI�����</summary>
        /// <remarks>�ŏI�����</remarks>
        private DateTime _lastSalesDate;

        /// <summary>�ŏI�d����</summary>
        /// <remarks>�ŏI�d����</remarks>
        private DateTime _lastStockDate;

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

        /// public propaty name  :  SalesDate
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

        /// public propaty name  :  LMonthStockCnt
        /// <summary>�O�����݌ɐ��v���p�e�B</summary>
        /// <value>�O���́u�݌ɑ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�����݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double LMonthStockCnt
        {
            get { return _lMonthStockCnt; }
            set { _lMonthStockCnt = value; }
        }

        /// public propaty name  :  LMonthStockPrice
        /// <summary>�O�����݌Ɋz�v���p�e�B</summary>
        /// <value>�O���́u�}�V���݌ɋ��z�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�����݌Ɋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LMonthStockPrice
        {
            get { return _lMonthStockPrice; }
            set { _lMonthStockPrice = value; }
        }

        /// public propaty name  :  LMonthPptyStockCnt
        /// <summary>�O�������Ѝ݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�������Ѝ݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double LMonthPptyStockCnt
        {
            get { return _lMonthPptyStockCnt; }
            set { _lMonthPptyStockCnt = value; }
        }

        /// public propaty name  :  LMonthPptyStockPrice
        /// <summary>�O�������Ѝ݌ɋ��z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�������Ѝ݌ɋ��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LMonthPptyStockPrice
        {
            get { return _lMonthPptyStockPrice; }
            set { _lMonthPptyStockPrice = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>����񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  SalesCount
        /// <summary>���㐔�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesCount
        {
            get { return _salesCount; }
            set { _salesCount = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesRetGoodsTimes
        /// <summary>����ԕi�񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRetGoodsTimes
        {
            get { return _salesRetGoodsTimes; }
            set { _salesRetGoodsTimes = value; }
        }

        /// public propaty name  :  SalesRetGoodsCnt
        /// <summary>����ԕi���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRetGoodsCnt
        {
            get { return _salesRetGoodsCnt; }
            set { _salesRetGoodsCnt = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>����ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  StockTimes
        /// <summary>�d���񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockTimes
        {
            get { return _stockTimes; }
            set { _stockTimes = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
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

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
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

        /// public propaty name  :  StockRetGoodsTimes
        /// <summary>�d���ԕi�񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRetGoodsTimes
        {
            get { return _stockRetGoodsTimes; }
            set { _stockRetGoodsTimes = value; }
        }

        /// public propaty name  :  StockRetGoodsCnt
        /// <summary>�d���ԕi���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRetGoodsCnt
        {
            get { return _stockRetGoodsCnt; }
            set { _stockRetGoodsCnt = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice
        /// <summary>�d���ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice
        {
            get { return _stockRetGoodsPrice; }
            set { _stockRetGoodsPrice = value; }
        }

        /// public propaty name  :  MoveArrivalCnt
        /// <summary>�ړ����א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveArrivalCnt
        {
            get { return _moveArrivalCnt; }
            set { _moveArrivalCnt = value; }
        }

        /// public propaty name  :  MoveArrivalPrice
        /// <summary>�ړ����׊z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����׊z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MoveArrivalPrice
        {
            get { return _moveArrivalPrice; }
            set { _moveArrivalPrice = value; }
        }

        /// public propaty name  :  MoveShipmentCnt
        /// <summary>�ړ��o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveShipmentCnt
        {
            get { return _moveShipmentCnt; }
            set { _moveShipmentCnt = value; }
        }

        /// public propaty name  :  MoveShipmentPrice
        /// <summary>�ړ��o�׊z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��o�׊z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MoveShipmentPrice
        {
            get { return _moveShipmentPrice; }
            set { _moveShipmentPrice = value; }
        }

        /// public propaty name  :  AdjustCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AdjustCount
        {
            get { return _adjustCount; }
            set { _adjustCount = value; }
        }

        /// public propaty name  :  AdjustPrice
        /// <summary>�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AdjustPrice
        {
            get { return _adjustPrice; }
            set { _adjustPrice = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��v���p�e�B</summary>
        /// <value>���o�ד��������̎d���i���ׁj�̐���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ArrivalPrice
        /// <summary>���׋��z�v���p�e�B</summary>
        /// <value>��L���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׋��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ArrivalPrice
        {
            get { return _arrivalPrice; }
            set { _arrivalPrice = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>���o�ד��������̔���i�o�ׁj�̐���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ShipmentPrice
        /// <summary>�o�׋��z�v���p�e�B</summary>
        /// <value>��L���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׋��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ShipmentPrice
        {
            get { return _shipmentPrice; }
            set { _shipmentPrice = value; }
        }

        /// public propaty name  :  TotalArrivalCnt
        /// <summary>�����א��v���p�e�B</summary>
        /// <value>���o�ד��������̓��ׂ��������i���ׁA�d���A�ړ����ׁA�����A�I���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalArrivalCnt
        {
            get { return _totalArrivalCnt; }
            set { _totalArrivalCnt = value; }
        }

        /// public propaty name  :  TotalArrivalPrice
        /// <summary>�����׋��z�v���p�e�B</summary>
        /// <value>��L���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����׋��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalArrivalPrice
        {
            get { return _totalArrivalPrice; }
            set { _totalArrivalPrice = value; }
        }

        /// public propaty name  :  TotalShipmentCnt
        /// <summary>���o�א��v���p�e�B</summary>
        /// <value>���o�ד��������̏o�ׂ��������i�o�ׁA����A�ړ��o�ׁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalShipmentCnt
        {
            get { return _totalShipmentCnt; }
            set { _totalShipmentCnt = value; }
        }

        /// public propaty name  :  TotalShipmentPrice
        /// <summary>���o�׋��z�v���p�e�B</summary>
        /// <value>��L���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�׋��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalShipmentPrice
        {
            get { return _totalShipmentPrice; }
            set { _totalShipmentPrice = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�I���]���P��</value>
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

        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>���ׁA�o�ׂ��܂ލ݌ɐ��i���o�ד��x�[�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  StockMashinePrice
        /// <summary>�}�V���݌Ɋz�v���p�e�B</summary>
        /// <value>���ׁA�o�ׂ��܂ލ݌ɋ��z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�V���݌Ɋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMashinePrice
        {
            get { return _stockMashinePrice; }
            set { _stockMashinePrice = value; }
        }

        /// public propaty name  :  PropertyStockCnt
        /// <summary>���Ѝ݌ɐ��v���p�e�B</summary>
        /// <value>���Ђ̎��Y�̍݌ɐ��i�v����x�[�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ѝ݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PropertyStockCnt
        {
            get { return _propertyStockCnt; }
            set { _propertyStockCnt = value; }
        }

        /// public propaty name  :  PropertyStockPrice
        /// <summary>���Ѝ݌ɋ��z�v���p�e�B</summary>
        /// <value>���Ђ̎��Y�̍݌ɋ��z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ѝ݌ɋ��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PropertyStockPrice
        {
            get { return _propertyStockPrice; }
            set { _propertyStockPrice = value; }
        }

        /// public propaty name  :  WarehouseShelfno
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        // -------ADD 2010/09/21--------->>>>>
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
        // -------ADD 2010/09/21---------<<<<<

        // -------ADD 2010/09/28--------->>>>>
        public string WareHouseCd
        {
            get { return _wareHouseCd; }
            set { _wareHouseCd = value; }
        }
        // -------ADD 2010/09/28---------<<<<<

        /// public propaty name  :  WarehouseShelfno
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String WarehouseShelfNo
        {
            get { return _warehouseShelfno; }
            set { _warehouseShelfno = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
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

        /// public propaty name  :  LastSalesDate
        /// <summary>�ŏI������v���p�e�B</summary>
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

        /// public propaty name  :  LastStockDate
        /// <summary>�ŏI�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastStockDate
        {
            get { return _lastStockDate; }
            set { _lastStockDate = value; }
        }


        /// <summary>
        /// �݌ɗ����f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockHistoryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockHistoryWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockHistoryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockHistoryWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockHistoryWork || graph is ArrayList || graph is StockHistoryWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockHistoryWork).FullName));

            if (graph != null && graph is StockHistoryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockHistoryWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockHistoryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockHistoryWork[])graph).Length;
            }
            else if (graph is StockHistoryWork)
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
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //�O�����݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthStockCnt
            //�O�����݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthStockPrice
            //�O�������Ѝ݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthPptyStockCnt
            //�O�������Ѝ݌ɋ��z
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthPptyStockPrice
            //�����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //���㐔
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCount
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //����ԕi��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRetGoodsTimes
            //����ԕi��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRetGoodsCnt
            //����ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockTimes
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d���ԕi��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRetGoodsTimes
            //�d���ԕi��
            serInfo.MemberInfo.Add(typeof(Double)); //StockRetGoodsCnt
            //�d���ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice
            //�ړ����א�
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //�ړ����׊z
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //�ړ��o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //�ړ��o�׊z
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //AdjustPrice
            //���א�
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //���׋��z
            serInfo.MemberInfo.Add(typeof(Int64)); //ArrivalPrice
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�o�׋��z
            serInfo.MemberInfo.Add(typeof(Int64)); //ShipmentPrice
            //�����א�
            serInfo.MemberInfo.Add(typeof(Double)); //TotalArrivalCnt
            //�����׋��z
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalArrivalPrice
            //���o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //TotalShipmentCnt
            //���o�׋��z
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalShipmentPrice
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�݌ɑ���
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //�}�V���݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMashinePrice
            //���Ѝ݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //PropertyStockCnt
            //���Ѝ݌ɋ��z
            serInfo.MemberInfo.Add(typeof(Int64)); //PropertyStockPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is StockHistoryWork)
            {
                StockHistoryWork temp = (StockHistoryWork)graph;

                SetStockHistoryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockHistoryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockHistoryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockHistoryWork temp in lst)
                {
                    SetStockHistoryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockHistoryWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 52;
        private const int currentMemberCount = 56;

        /// <summary>
        ///  StockHistoryWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockHistoryWork(System.IO.BinaryWriter writer, StockHistoryWork temp)
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
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //�O�����݌ɐ�
            writer.Write(temp.LMonthStockCnt);
            //�O�����݌Ɋz
            writer.Write(temp.LMonthStockPrice);
            //�O�������Ѝ݌ɐ�
            writer.Write(temp.LMonthPptyStockCnt);
            //�O�������Ѝ݌ɋ��z
            writer.Write(temp.LMonthPptyStockPrice);
            //�����
            writer.Write(temp.SalesTimes);
            //���㐔
            writer.Write(temp.SalesCount);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //����ԕi��
            writer.Write(temp.SalesRetGoodsTimes);
            //����ԕi��
            writer.Write(temp.SalesRetGoodsCnt);
            //����ԕi�z
            writer.Write(temp.SalesRetGoodsPrice);
            //�e�����z
            writer.Write(temp.GrossProfit);
            //�d����
            writer.Write(temp.StockTimes);
            //�d����
            writer.Write(temp.StockCount);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d���ԕi��
            writer.Write(temp.StockRetGoodsTimes);
            //�d���ԕi��
            writer.Write(temp.StockRetGoodsCnt);
            //�d���ԕi�z
            writer.Write(temp.StockRetGoodsPrice);
            //�ړ����א�
            writer.Write(temp.MoveArrivalCnt);
            //�ړ����׊z
            writer.Write(temp.MoveArrivalPrice);
            //�ړ��o�א�
            writer.Write(temp.MoveShipmentCnt);
            //�ړ��o�׊z
            writer.Write(temp.MoveShipmentPrice);
            //������
            writer.Write(temp.AdjustCount);
            //�������z
            writer.Write(temp.AdjustPrice);
            //���א�
            writer.Write(temp.ArrivalCnt);
            //���׋��z
            writer.Write(temp.ArrivalPrice);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�o�׋��z
            writer.Write(temp.ShipmentPrice);
            //�����א�
            writer.Write(temp.TotalArrivalCnt);
            //�����׋��z
            writer.Write(temp.TotalArrivalPrice);
            //���o�א�
            writer.Write(temp.TotalShipmentCnt);
            //���o�׋��z
            writer.Write(temp.TotalShipmentPrice);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�݌ɑ���
            writer.Write(temp.StockTotal);
            //�}�V���݌Ɋz
            writer.Write(temp.StockMashinePrice);
            //���Ѝ݌ɐ�
            writer.Write(temp.PropertyStockCnt);
            //���Ѝ݌ɋ��z
            writer.Write(temp.PropertyStockPrice);

        }

        /// <summary>
        ///  StockHistoryWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockHistoryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockHistoryWork GetStockHistoryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockHistoryWork temp = new StockHistoryWork();

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
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //�O�����݌ɐ�
            temp.LMonthStockCnt = reader.ReadDouble();
            //�O�����݌Ɋz
            temp.LMonthStockPrice = reader.ReadInt64();
            //�O�������Ѝ݌ɐ�
            temp.LMonthPptyStockCnt = reader.ReadDouble();
            //�O�������Ѝ݌ɋ��z
            temp.LMonthPptyStockPrice = reader.ReadInt64();
            //�����
            temp.SalesTimes = reader.ReadInt32();
            //���㐔
            temp.SalesCount = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //����ԕi��
            temp.SalesRetGoodsTimes = reader.ReadInt32();
            //����ԕi��
            temp.SalesRetGoodsCnt = reader.ReadDouble();
            //����ԕi�z
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //�e�����z
            temp.GrossProfit = reader.ReadInt64();
            //�d����
            temp.StockTimes = reader.ReadInt32();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d���ԕi��
            temp.StockRetGoodsTimes = reader.ReadInt32();
            //�d���ԕi��
            temp.StockRetGoodsCnt = reader.ReadDouble();
            //�d���ԕi�z
            temp.StockRetGoodsPrice = reader.ReadInt64();
            //�ړ����א�
            temp.MoveArrivalCnt = reader.ReadDouble();
            //�ړ����׊z
            temp.MoveArrivalPrice = reader.ReadInt64();
            //�ړ��o�א�
            temp.MoveShipmentCnt = reader.ReadDouble();
            //�ړ��o�׊z
            temp.MoveShipmentPrice = reader.ReadInt64();
            //������
            temp.AdjustCount = reader.ReadDouble();
            //�������z
            temp.AdjustPrice = reader.ReadInt64();
            //���א�
            temp.ArrivalCnt = reader.ReadDouble();
            //���׋��z
            temp.ArrivalPrice = reader.ReadInt64();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�o�׋��z
            temp.ShipmentPrice = reader.ReadInt64();
            //�����א�
            temp.TotalArrivalCnt = reader.ReadDouble();
            //�����׋��z
            temp.TotalArrivalPrice = reader.ReadInt64();
            //���o�א�
            temp.TotalShipmentCnt = reader.ReadDouble();
            //���o�׋��z
            temp.TotalShipmentPrice = reader.ReadInt64();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�݌ɑ���
            temp.StockTotal = reader.ReadDouble();
            //�}�V���݌Ɋz
            temp.StockMashinePrice = reader.ReadInt64();
            //���Ѝ݌ɐ�
            temp.PropertyStockCnt = reader.ReadDouble();
            //���Ѝ݌ɋ��z
            temp.PropertyStockPrice = reader.ReadInt64();


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
        /// <returns>StockHistoryWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockHistoryWork temp = GetStockHistoryWork(reader, serInfo);
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
                    retValue = (StockHistoryWork[])lst.ToArray(typeof(StockHistoryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
