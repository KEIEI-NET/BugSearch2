using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockManagementListWork
    /// <summary>
    ///                      �݌ɊǗ��\�����[�g���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɊǗ��\�����[�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockManagementListWork
    {
        /// <summary>�d����R�[�h</summary>
        /// <remarks>���i�Ǘ����}�X�^���擾</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���於��</summary>
        /// <remarks>���i�Ǘ����}�X�^���擾</remarks>
        private string _supplierName = "";

        /// <summary>�d���於��2</summary>
        /// <remarks>���i�Ǘ����}�X�^���擾</remarks>
        private string _supplierName2 = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private string _sectionCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private string _makerName = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private string _warehouseName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private string _goodsName = "";

        /// <summary>���i�敪�O���[�v�R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^���擾</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>���i�敪�O���[�v����</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>���i�敪�R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^���擾</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>���i�敪����</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>���i�敪�ڍ׃R�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^���擾</remarks>
        private string _detailGoodsGanreCode = "";

        /// <summary>���i�敪�ڍז���</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _detailGoodsGanreName = "";

        /// <summary>�O�����݌ɐ�</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _lMonthStockCnt;

        /// <summary>�O�����݌Ɋz</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Int64 _lMonthStockPrice;

        /// <summary>���d����</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _netStockCnt;

        /// <summary>���d���z</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Int64 _netStockPrice;

        /// <summary>�����㐔</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _netSalesCnt;

        /// <summary>������z</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Int64 _netSalesPrice;

        /// <summary>�e�����z</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Int64 _grossProfit;

        /// <summary>������</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _adjustCount;

        /// <summary>�������z</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Int64 _adjustPrice;

        /// <summary>�݌ɑ���</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _stockTotal;

        /// <summary>�������]���P��</summary>
        private Double _stockUnitPriceFl;

        /// <summary>���ύ݌�</summary>
        private Double _stockAverage;

        /// <summary>��]��</summary>
        private Double _turnRate;

        /// <summary>���v���d����</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Double _netStockCntTotal;

        /// <summary>���v���d���z</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Int64 _netStockPriceTotal;

        /// <summary>���v�����㐔</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Double _netSalesCntTotal;

        /// <summary>���v������z</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Int64 _netSalesPriceTotal;

        /// <summary>���v�e�����z</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Int64 _grossProfitTotal;

        /// <summary>���v������</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Double _adjustCountTotal;

        /// <summary>���v�������z</summary>
        /// <remarks>���񌎂���W�v</remarks>
        private Int64 _adjustPriceTotal;


        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>���i�Ǘ����}�X�^���擾</value>
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

        /// public propaty name  :  SupplierName
        /// <summary>�d���於�̃v���p�e�B</summary>
        /// <value>���i�Ǘ����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        /// public propaty name  :  SupplierName2
        /// <summary>�d���於��2�v���p�e�B</summary>
        /// <value>���i�Ǘ����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierName2
        {
            get { return _supplierName2; }
            set { _supplierName2 = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^���擾</value>
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
        /// <value>���i�}�X�^���擾</value>
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
        /// <value>�݌Ƀ}�X�^���擾</value>
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
        /// <value>���i�}�X�^���擾</value>
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
        /// <value>�݌Ƀ}�X�^���擾</value>
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
        /// <value>���i�}�X�^���擾</value>
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

        /// public propaty name  :  LMonthStockCnt
        /// <summary>�O�����݌ɐ��v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  NetStockCnt
        /// <summary>���d�����v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NetStockCnt
        {
            get { return _netStockCnt; }
            set { _netStockCnt = value; }
        }

        /// public propaty name  :  NetStockPrice
        /// <summary>���d���z�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 NetStockPrice
        {
            get { return _netStockPrice; }
            set { _netStockPrice = value; }
        }

        /// public propaty name  :  NetSalesCnt
        /// <summary>�����㐔�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����㐔�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NetSalesCnt
        {
            get { return _netSalesCnt; }
            set { _netSalesCnt = value; }
        }

        /// public propaty name  :  NetSalesPrice
        /// <summary>������z�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 NetSalesPrice
        {
            get { return _netSalesPrice; }
            set { _netSalesPrice = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e�����z�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  AdjustCount
        /// <summary>�������v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�������]���P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������]���P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockAverage
        /// <summary>���ύ݌Ƀv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ύ݌Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockAverage
        {
            get { return _stockAverage; }
            set { _stockAverage = value; }
        }

        /// public propaty name  :  TurnRate
        /// <summary>��]���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TurnRate
        {
            get { return _turnRate; }
            set { _turnRate = value; }
        }

        /// public propaty name  :  NetStockCntTotal
        /// <summary>���v���d�����v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NetStockCntTotal
        {
            get { return _netStockCntTotal; }
            set { _netStockCntTotal = value; }
        }

        /// public propaty name  :  NetStockPriceTotal
        /// <summary>���v���d���z�v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���d���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 NetStockPriceTotal
        {
            get { return _netStockPriceTotal; }
            set { _netStockPriceTotal = value; }
        }

        /// public propaty name  :  NetSalesCntTotal
        /// <summary>���v�����㐔�v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�����㐔�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NetSalesCntTotal
        {
            get { return _netSalesCntTotal; }
            set { _netSalesCntTotal = value; }
        }

        /// public propaty name  :  NetSalesPriceTotal
        /// <summary>���v������z�v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 NetSalesPriceTotal
        {
            get { return _netSalesPriceTotal; }
            set { _netSalesPriceTotal = value; }
        }

        /// public propaty name  :  GrossProfitTotal
        /// <summary>���v�e�����z�v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfitTotal
        {
            get { return _grossProfitTotal; }
            set { _grossProfitTotal = value; }
        }

        /// public propaty name  :  AdjustCountTotal
        /// <summary>���v�������v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AdjustCountTotal
        {
            get { return _adjustCountTotal; }
            set { _adjustCountTotal = value; }
        }

        /// public propaty name  :  AdjustPriceTotal
        /// <summary>���v�������z�v���p�e�B</summary>
        /// <value>���񌎂���W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AdjustPriceTotal
        {
            get { return _adjustPriceTotal; }
            set { _adjustPriceTotal = value; }
        }


        /// <summary>
        /// �݌ɊǗ��\�����[�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockManagementListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockManagementListWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockManagementListWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockManagementListWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockManagementListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockManagementListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockManagementListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockManagementListWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockManagementListWork || graph is ArrayList || graph is StockManagementListWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockManagementListWork).FullName));

            if (graph != null && graph is StockManagementListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockManagementListWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockManagementListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockManagementListWork[])graph).Length;
            }
            else if (graph is StockManagementListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierName
            //�d���於��2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierName2
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i�敪�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
            //���i�敪�O���[�v����
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
            //���i�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
            //���i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
            //���i�敪�ڍ׃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
            //���i�敪�ڍז���
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
            //�O�����݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //LMonthStockCnt
            //�O�����݌Ɋz
            serInfo.MemberInfo.Add(typeof(Int64)); //LMonthStockPrice
            //���d����
            serInfo.MemberInfo.Add(typeof(Double)); //NetStockCnt
            //���d���z
            serInfo.MemberInfo.Add(typeof(Int64)); //NetStockPrice
            //�����㐔
            serInfo.MemberInfo.Add(typeof(Double)); //NetSalesCnt
            //������z
            serInfo.MemberInfo.Add(typeof(Int64)); //NetSalesPrice
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //AdjustPrice
            //�݌ɑ���
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //�������]���P��
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //���ύ݌�
            serInfo.MemberInfo.Add(typeof(Double)); //StockAverage
            //��]��
            serInfo.MemberInfo.Add(typeof(Double)); //TurnRate
            //���v���d����
            serInfo.MemberInfo.Add(typeof(Double)); //NetStockCntTotal
            //���v���d���z
            serInfo.MemberInfo.Add(typeof(Int64)); //NetStockPriceTotal
            //���v�����㐔
            serInfo.MemberInfo.Add(typeof(Double)); //NetSalesCntTotal
            //���v������z
            serInfo.MemberInfo.Add(typeof(Int64)); //NetSalesPriceTotal
            //���v�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfitTotal
            //���v������
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCountTotal
            //���v�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //AdjustPriceTotal


            serInfo.Serialize(writer, serInfo);
            if (graph is StockManagementListWork)
            {
                StockManagementListWork temp = (StockManagementListWork)graph;

                SetStockManagementListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockManagementListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockManagementListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockManagementListWork temp in lst)
                {
                    SetStockManagementListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockManagementListWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 36;

        /// <summary>
        ///  StockManagementListWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockManagementListWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockManagementListWork(System.IO.BinaryWriter writer, StockManagementListWork temp)
        {
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於��
            writer.Write(temp.SupplierName);
            //�d���於��2
            writer.Write(temp.SupplierName2);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i�敪�O���[�v�R�[�h
            writer.Write(temp.LargeGoodsGanreCode);
            //���i�敪�O���[�v����
            writer.Write(temp.LargeGoodsGanreName);
            //���i�敪�R�[�h
            writer.Write(temp.MediumGoodsGanreCode);
            //���i�敪����
            writer.Write(temp.MediumGoodsGanreName);
            //���i�敪�ڍ׃R�[�h
            writer.Write(temp.DetailGoodsGanreCode);
            //���i�敪�ڍז���
            writer.Write(temp.DetailGoodsGanreName);
            //�O�����݌ɐ�
            writer.Write(temp.LMonthStockCnt);
            //�O�����݌Ɋz
            writer.Write(temp.LMonthStockPrice);
            //���d����
            writer.Write(temp.NetStockCnt);
            //���d���z
            writer.Write(temp.NetStockPrice);
            //�����㐔
            writer.Write(temp.NetSalesCnt);
            //������z
            writer.Write(temp.NetSalesPrice);
            //�e�����z
            writer.Write(temp.GrossProfit);
            //������
            writer.Write(temp.AdjustCount);
            //�������z
            writer.Write(temp.AdjustPrice);
            //�݌ɑ���
            writer.Write(temp.StockTotal);
            //�������]���P��
            writer.Write(temp.StockUnitPriceFl);
            //���ύ݌�
            writer.Write(temp.StockAverage);
            //��]��
            writer.Write(temp.TurnRate);
            //���v���d����
            writer.Write(temp.NetStockCntTotal);
            //���v���d���z
            writer.Write(temp.NetStockPriceTotal);
            //���v�����㐔
            writer.Write(temp.NetSalesCntTotal);
            //���v������z
            writer.Write(temp.NetSalesPriceTotal);
            //���v�e�����z
            writer.Write(temp.GrossProfitTotal);
            //���v������
            writer.Write(temp.AdjustCountTotal);
            //���v�������z
            writer.Write(temp.AdjustPriceTotal);

        }

        /// <summary>
        ///  StockManagementListWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockManagementListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockManagementListWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockManagementListWork GetStockManagementListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockManagementListWork temp = new StockManagementListWork();

            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於��
            temp.SupplierName = reader.ReadString();
            //�d���於��2
            temp.SupplierName2 = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i�敪�O���[�v�R�[�h
            temp.LargeGoodsGanreCode = reader.ReadString();
            //���i�敪�O���[�v����
            temp.LargeGoodsGanreName = reader.ReadString();
            //���i�敪�R�[�h
            temp.MediumGoodsGanreCode = reader.ReadString();
            //���i�敪����
            temp.MediumGoodsGanreName = reader.ReadString();
            //���i�敪�ڍ׃R�[�h
            temp.DetailGoodsGanreCode = reader.ReadString();
            //���i�敪�ڍז���
            temp.DetailGoodsGanreName = reader.ReadString();
            //�O�����݌ɐ�
            temp.LMonthStockCnt = reader.ReadDouble();
            //�O�����݌Ɋz
            temp.LMonthStockPrice = reader.ReadInt64();
            //���d����
            temp.NetStockCnt = reader.ReadDouble();
            //���d���z
            temp.NetStockPrice = reader.ReadInt64();
            //�����㐔
            temp.NetSalesCnt = reader.ReadDouble();
            //������z
            temp.NetSalesPrice = reader.ReadInt64();
            //�e�����z
            temp.GrossProfit = reader.ReadInt64();
            //������
            temp.AdjustCount = reader.ReadDouble();
            //�������z
            temp.AdjustPrice = reader.ReadInt64();
            //�݌ɑ���
            temp.StockTotal = reader.ReadDouble();
            //�������]���P��
            temp.StockUnitPriceFl = reader.ReadDouble();
            //���ύ݌�
            temp.StockAverage = reader.ReadDouble();
            //��]��
            temp.TurnRate = reader.ReadDouble();
            //���v���d����
            temp.NetStockCntTotal = reader.ReadDouble();
            //���v���d���z
            temp.NetStockPriceTotal = reader.ReadInt64();
            //���v�����㐔
            temp.NetSalesCntTotal = reader.ReadDouble();
            //���v������z
            temp.NetSalesPriceTotal = reader.ReadInt64();
            //���v�e�����z
            temp.GrossProfitTotal = reader.ReadInt64();
            //���v������
            temp.AdjustCountTotal = reader.ReadDouble();
            //���v�������z
            temp.AdjustPriceTotal = reader.ReadInt64();


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
        /// <returns>StockManagementListWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockManagementListWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockManagementListWork temp = GetStockManagementListWork(reader, serInfo);
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
                    retValue = (StockManagementListWork[])lst.ToArray(typeof(StockManagementListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
