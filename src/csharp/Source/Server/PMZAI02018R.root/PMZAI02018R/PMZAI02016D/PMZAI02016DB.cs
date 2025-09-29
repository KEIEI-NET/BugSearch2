using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMonthYearReportDataWork
    /// <summary>
    ///                      �݌Ɍ���N�񃊃��[�g���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɍ���N�񃊃��[�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMonthYearReportDataWork
    {
        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�݌ɔ�����R�[�h</summary>
        private Int32 _stockSupplierCode;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�I��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�O�����݌ɐ�</summary>
        private Double _lMonthStockCnt;

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>�ړ����א�</summary>
        private Double _moveArrivalCnt;

        /// <summary>�����א�</summary>
        private Double _totalArrivalCnt;

        /// <summary>���㐔</summary>
        private Double _salesCount;

        /// <summary>�ړ��o�א�</summary>
        private Double _moveShipmentCnt;

        /// <summary>���o�א�</summary>
        private Double _totalShipmentCnt;

        /// <summary>�ō��݌ɐ�</summary>
        private Double _maximumStockCnt;

        /// <summary>�Œ�݌ɐ�</summary>
        private Double _minimumStockCnt;

        /// <summary>����</summary>
        private Double _salesCost;

        /// <summary>�O�����݌Ɋz</summary>
        private Int64 _lMonthStockPrice;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�ړ����׊z</summary>
        private Int64 _moveArrivalPrice;

        /// <summary>�����׋��z</summary>
        private Int64 _totalArrivalPrice;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�ړ��o�׊z</summary>
        private Int64 _moveShipmentPrice;

        /// <summary>���o�׋��z</summary>
        private Int64 _totalShipmentPrice;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;

        /// <summary>�e����</summary>
        private Double _grossProfitRate;

        /// <summary>�݌ɑ���</summary>
        /// <remarks>�݌ɑ���=�d���݌ɐ�+�ϑ���+�����</remarks>
        private Double _stockTotal;

        /// <summary>�}�V���݌Ɋz</summary>
        private Int64 _stockMashinePrice;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        private string _partsManagementDivide1 = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        private string _partsManagementDivide2 = "";

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

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  LMonthStockCnt
        /// <summary>�O�����݌ɐ��v���p�e�B</summary>
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

        /// public propaty name  :  TotalArrivalCnt
        /// <summary>�����א��v���p�e�B</summary>
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

        /// public propaty name  :  TotalShipmentCnt
        /// <summary>���o�א��v���p�e�B</summary>
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

        /// public propaty name  :  SalesCost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesCost
        {
            get { return _salesCost; }
            set { _salesCost = value; }
        }

        /// public propaty name  :  LMonthStockPrice
        /// <summary>�O�����݌Ɋz�v���p�e�B</summary>
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

        /// public propaty name  :  TotalArrivalPrice
        /// <summary>�����׋��z�v���p�e�B</summary>
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

        /// public propaty name  :  TotalShipmentPrice
        /// <summary>���o�׋��z�v���p�e�B</summary>
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

        /// public propaty name  :  GrossProfitRate
        /// <summary>�e�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrossProfitRate
        {
            get { return _grossProfitRate; }
            set { _grossProfitRate = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>�݌ɑ���=�d���݌ɐ�+�ϑ���+�����</value>
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

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ށi�}�X�^�L�j</value>
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

        /// public propaty name  :  MakerShortName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// <summary>
        /// �݌Ɍ���N�񃊃��[�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMonthYearReportDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMonthYearReportDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMonthYearReportDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockMonthYearReportDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMonthYearReportDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMonthYearReportDataWork || graph is ArrayList || graph is StockMonthYearReportDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockMonthYearReportDataWork).FullName));

            if (graph != null && graph is StockMonthYearReportDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMonthYearReportDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMonthYearReportDataWork[])graph).Length;
            }
            else if (graph is StockMonthYearReportDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�݌ɔ�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�O�����݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthStockCnt
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�ړ����א�
            serInfo.MemberInfo.Add(typeof(Double)); //MoveArrivalCnt
            //�����א�
            serInfo.MemberInfo.Add(typeof(Double)); //TotalArrivalCnt
            //���㐔
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCount
            //�ړ��o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //MoveShipmentCnt
            //���o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //TotalShipmentCnt
            //�ō��݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //�Œ�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //����
            serInfo.MemberInfo.Add(typeof(Double)); //SalesCost
            //�O�����݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthStockPrice
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�ړ����׊z
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveArrivalPrice
            //�����׋��z
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalArrivalPrice
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�ړ��o�׊z
            serInfo.MemberInfo.Add(typeof(Int64)); //MoveShipmentPrice
            //���o�׋��z
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalShipmentPrice
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //�e����
            serInfo.MemberInfo.Add(typeof(Double)); //GrossProfitRate
            //�݌ɑ���
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //�}�V���݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMashinePrice
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���i�Ǘ��敪�P
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide1
            //���i�Ǘ��敪�Q
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide2

            serInfo.Serialize(writer, serInfo);
            if (graph is StockMonthYearReportDataWork)
            {
                StockMonthYearReportDataWork temp = (StockMonthYearReportDataWork)graph;

                SetStockMonthYearReportDataWork(writer, temp);
            }

            else
            {
                ArrayList lst = null;
                if (graph is StockMonthYearReportDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMonthYearReportDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMonthYearReportDataWork temp in lst)
                {
                    SetStockMonthYearReportDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMonthYearReportDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 37;

        /// <summary>
        ///  StockMonthYearReportDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockMonthYearReportDataWork(System.IO.BinaryWriter writer, StockMonthYearReportDataWork temp)
        {
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�݌ɔ�����R�[�h
            writer.Write(temp.StockSupplierCode);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�I��
            writer.Write(temp.WarehouseShelfNo);
            //�O�����݌ɐ�
            writer.Write(temp.LMonthStockCnt);
            //�d����
            writer.Write(temp.StockCount);
            //�ړ����א�
            writer.Write(temp.MoveArrivalCnt);
            //�����א�
            writer.Write(temp.TotalArrivalCnt);
            //���㐔
            writer.Write(temp.SalesCount);
            //�ړ��o�א�
            writer.Write(temp.MoveShipmentCnt);
            //���o�א�
            writer.Write(temp.TotalShipmentCnt);
            //�ō��݌ɐ�
            writer.Write(temp.MaximumStockCnt);
            //�Œ�݌ɐ�
            writer.Write(temp.MinimumStockCnt);
            //����
            writer.Write(temp.SalesCost);
            //�O�����݌Ɋz
            writer.Write(temp.LMonthStockPrice);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�ړ����׊z
            writer.Write(temp.MoveArrivalPrice);
            //�����׋��z
            writer.Write(temp.TotalArrivalPrice);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�ړ��o�׊z
            writer.Write(temp.MoveShipmentPrice);
            //���o�׋��z
            writer.Write(temp.TotalShipmentPrice);
            //�e�����z
            writer.Write(temp.GrossProfit);
            //�e����
            writer.Write(temp.GrossProfitRate);
            //�݌ɑ���
            writer.Write(temp.StockTotal);
            //�}�V���݌Ɋz
            writer.Write(temp.StockMashinePrice);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerShortName);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���i�Ǘ��敪�P
            writer.Write(temp.PartsManagementDivide1);
            //���i�Ǘ��敪�Q
            writer.Write(temp.PartsManagementDivide2);

        }

        /// <summary>
        ///  StockMonthYearReportDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMonthYearReportDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockMonthYearReportDataWork GetStockMonthYearReportDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockMonthYearReportDataWork temp = new StockMonthYearReportDataWork();

            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�݌ɔ�����R�[�h
            temp.StockSupplierCode = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�I��
            temp.WarehouseShelfNo = reader.ReadString();
            //�O�����݌ɐ�
            temp.LMonthStockCnt = reader.ReadDouble();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�ړ����א�
            temp.MoveArrivalCnt = reader.ReadDouble();
            //�����א�
            temp.TotalArrivalCnt = reader.ReadDouble();
            //���㐔
            temp.SalesCount = reader.ReadDouble();
            //�ړ��o�א�
            temp.MoveShipmentCnt = reader.ReadDouble();
            //���o�א�
            temp.TotalShipmentCnt = reader.ReadDouble();
            //�ō��݌ɐ�
            temp.MaximumStockCnt = reader.ReadDouble();
            //�Œ�݌ɐ�
            temp.MinimumStockCnt = reader.ReadDouble();
            //����
            temp.SalesCost = reader.ReadDouble();
            //�O�����݌Ɋz
            temp.LMonthStockPrice = reader.ReadInt64();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�ړ����׊z
            temp.MoveArrivalPrice = reader.ReadInt64();
            //�����׋��z
            temp.TotalArrivalPrice = reader.ReadInt64();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�ړ��o�׊z
            temp.MoveShipmentPrice = reader.ReadInt64();
            //���o�׋��z
            temp.TotalShipmentPrice = reader.ReadInt64();
            //�e�����z
            temp.GrossProfit = reader.ReadInt64();
            //�e����
            temp.GrossProfitRate = reader.ReadDouble();
            //�݌ɑ���
            temp.StockTotal = reader.ReadDouble();
            //�}�V���݌Ɋz
            temp.StockMashinePrice = reader.ReadInt64();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerShortName = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���i�Ǘ��敪�P
            temp.PartsManagementDivide1 = reader.ReadString();
            //���i�Ǘ��敪�Q
            temp.PartsManagementDivide2 = reader.ReadString();


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
        /// <returns>StockMonthYearReportDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMonthYearReportDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMonthYearReportDataWork temp = GetStockMonthYearReportDataWork(reader, serInfo);
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
                    retValue = (StockMonthYearReportDataWork[])lst.ToArray(typeof(StockMonthYearReportDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}