using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockHistoryDspSearchResultWork
	/// <summary>
	///                      �݌Ɏ��яƉ�o���ʃ��[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɏ��яƉ�o���ʃ��[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 ������ �e�L�X�g�o�͑Ή�</br>
	/// </remarks>
	[Serializable]
	public class StockHistoryDspSearchResult
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

        /// <summary>�v��N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>�I��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>BL�R�[�h</summary>
        private Int32 _blGoodsCode;
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

		/// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>���i����</summary>
        private string _goodsName = "";
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>�����</summary>
		private Int32 _salesTimes;

		/// <summary>���㐔</summary>
		private Double _salesCount;

		/// <summary>������z�i�Ŕ����j</summary>
		private Int64 _salesMoneyTaxExc;

        /// <summary>���㕽��</summary>
		private Double _salesMoneyAvg;

		/// <summary>�d����</summary>
		private Int32 _stockTimes;

		/// <summary>�d����</summary>
		private Double _stockCount;

		/// <summary>�d�����z�i�Ŕ����j</summary>
		private Int64 _stockPriceTaxExc;

        /// <summary>�d�����ρi�Ŕ����j</summary>
		private Double _stockPriceAvg;

		/// <summary>�e�����z</summary>
		private Int64 _grossProfit;

		/// <summary>�ړ����א�</summary>
		private Double _moveArrivalCnt;

		/// <summary>�ړ����׊z</summary>
		private Int64 _moveArrivalPrice;

		/// <summary>�ړ��o�א�</summary>
		private Double _moveShipmentCnt;

		/// <summary>�ړ��o�׊z</summary>
		private Int64 _moveShipmentPrice;

		/// <summary>�݌ɔ�����R�[�h</summary>
		private Int32 _stockSupplierCode;

		/// <summary>�݌ɓo�^��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>�ŏI�����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>�ŏI�d���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

        /// <summary>�����敪</summary>
        private Int32 _searchDiv;

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}


		/// public propaty name  :  AddUpYearMonth
		/// <summary>�v��N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
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
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
        }

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// public propaty name  :  WarehouseShelfCode
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

        /// public propaty name  :  BlGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
        }

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
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
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
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
			get{return _salesTimes;}
			set{_salesTimes = value;}
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
			get{return _salesCount;}
			set{_salesCount = value;}
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
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
		}

        /// public propaty name  :  SalesMoneyAvg
		/// <summary>���㕽�σv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㕽�σv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesMoneyAvg
		{
			get{return _salesMoneyAvg;}
			set{_salesMoneyAvg = value;}
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
			get{return _stockTimes;}
			set{_stockTimes = value;}
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
			get{return _stockCount;}
			set{_stockCount = value;}
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
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
		}

        /// public propaty name  :  StockPriceTaxExc
		/// <summary>�d�����σv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����σv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockPriceAvg
		{
			get{return _stockPriceAvg;}
			set{_stockPriceAvg = value;}
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
			get{return _grossProfit;}
			set{_grossProfit = value;}
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
			get{return _moveArrivalCnt;}
			set{_moveArrivalCnt = value;}
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
			get{return _moveArrivalPrice;}
			set{_moveArrivalPrice = value;}
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
			get{return _moveShipmentCnt;}
			set{_moveShipmentCnt = value;}
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
			get{return _moveShipmentPrice;}
			set{_moveShipmentPrice = value;}
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
			get{return _stockSupplierCode;}
			set{_stockSupplierCode = value;}
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
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
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
			get{return _lastSalesDate;}
			set{_lastSalesDate = value;}
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
			get{return _lastStockDate;}
			set{_lastStockDate = value;}
		}

        /// public propaty name  :  SearchDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }


		/// <summary>
		/// �݌Ɏ��яƉ�o���ʃ��[�N�R���X�g���N�^
		/// </summary>
        /// <returns>StockHistoryDspSearchResult�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockHistoryDspSearchResult()
		{
		}

	

        /// <summary>
        /// �݌Ɏ��яƉ�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="rsltTtlDivCd">���яW�v�敪(0:���i���v 1:�݌� 2:���� 3:���)</param>
        /// <param name="salesTimes">�����(�o�׉�(���㎞�̂݁j)</param>
        /// <param name="salesMoney">������z(�Ŕ����i�l��,�ԕi�܂܂��j)</param>
        /// <param name="grossProfit">�e�����z</param>
        /// <returns>StockHistoryDspSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryDspSearchResult(string enterpriseCode, DateTime addUpYearMonth, string warehouseCode, string warehouseShelfNo, Int32 blGoodsCode, string goodsNo, string goodsName, Int32 goodsMakerCd,
            Int32 salesTimes, Double salesCount, Int64 salesMoneyTaxExc, Double salesMoneyAvg, Int32 stockTimes, Double stockCount, Int64 stockPriceTaxExc,
            Double stockPriceAvg, Int64 grossProfit, Double moveArrivalCnt,Int64 moveArrivalPrice, Double moveShipmentCnt, Int64 moveShipmentPrice,
            Int32 stockSupplierCode, DateTime stockCreateDate, DateTime lastSalesDate, DateTime lastStockDate, Int32 searchDiv)
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpYearMonth = addUpYearMonth;
            this._warehouseCode = warehouseCode;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            this._warehouseShelfNo = warehouseShelfNo;
            this._blGoodsCode = blGoodsCode;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            this._goodsNo = goodsNo;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            this._goodsName = GoodsName;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            this._goodsMakerCd = goodsMakerCd;
            this._salesTimes = salesTimes;
            this._salesCount = salesCount;
            this._salesMoneyTaxExc = salesMoneyTaxExc;
            this._salesMoneyAvg = salesMoneyAvg;
            this._stockTimes = stockTimes;
            this._stockCount = stockCount;
            this._stockPriceTaxExc = stockPriceTaxExc;
            this._stockPriceAvg = stockPriceAvg;
            this._grossProfit = grossProfit;
            this._moveArrivalCnt = moveArrivalCnt;
            this._moveArrivalPrice = moveArrivalPrice;
            this._moveShipmentCnt = moveShipmentCnt;
            this._moveShipmentPrice = moveShipmentPrice;
            this._stockSupplierCode = stockSupplierCode;
            this._stockCreateDate = stockCreateDate;
            this._lastSalesDate = lastSalesDate;
            this._lastStockDate = lastStockDate;
            this._searchDiv = SearchDiv;
        }

        /// <summary>
        /// �݌Ɏ��яƉ�f�[�^��������
        /// </summary>
        /// <returns>StockHistoryDspSearchResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockHistoryDspSearchResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryDspSearchResult Clone()
        {
            return new StockHistoryDspSearchResult(this._enterpriseCode, this._addUpYearMonth, this._warehouseCode, 
                            this._warehouseShelfNo, this._blGoodsCode, this._goodsNo, this._goodsName,
                            this._goodsMakerCd, this._salesTimes, this._salesCount, this._salesMoneyTaxExc, this._salesMoneyAvg,
                            this._stockTimes, this._stockCount, this._stockPriceTaxExc, this._stockPriceAvg, this._grossProfit, 
                            this._moveArrivalCnt, this._moveArrivalPrice, this._moveShipmentCnt, this._moveShipmentPrice, 
                            this._stockSupplierCode, this._stockCreateDate, this._lastSalesDate, this._lastStockDate, this._searchDiv);
        }

        /// <summary>
        /// �݌Ɏ��яƉ�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockHistoryDspSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockHistoryDspSearchResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.WarehouseCode == target.WarehouseCode)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.BlGoodsCode == target.BlGoodsCode)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
                 && (this.GoodsNo == target.GoodsNo)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
                 && (this.GoodsName == target.GoodsName)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.SalesTimes == target.SalesTimes)
                 && (this.SalesCount == target.SalesCount)
                 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
                 && (this.SalesMoneyAvg == target.SalesMoneyAvg)
                 && (this.StockTimes == target.StockTimes)
                 && (this.StockCount == target.StockCount)
                 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
                 && (this.StockPriceAvg == target.StockPriceAvg)
                 && (this.GrossProfit == target.GrossProfit)
                 && (this.MoveArrivalCnt == target.MoveArrivalCnt)
                 && (this.MoveArrivalPrice == target.MoveArrivalPrice)
                 && (this.MoveShipmentCnt == target.MoveShipmentPrice)
                 && (this.StockSupplierCode == target.StockSupplierCode)
                 && (this.StockCreateDate == target.StockCreateDate)
                 && (this.LastSalesDate == target.LastSalesDate)
                 && (this.LastStockDate == target.LastStockDate)
                 && (this.SearchDiv == target.SearchDiv));
        }

        /// <summary>
        /// �݌Ɏ��яƉ�W�v�f�[�^��r����
        /// </summary>
        /// <param name="ShipmentPartsDspResult">
        ///                    ��r����StockHistoryDspSearchResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="mTtlSalesSlip2">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockHistoryDspSearchResult mTtlStockhist1, StockHistoryDspSearchResult mTtlStockhist2)
        {
            return ((mTtlStockhist1.EnterpriseCode == mTtlStockhist2.EnterpriseCode)
                 && (mTtlStockhist1.AddUpYearMonth == mTtlStockhist2.AddUpYearMonth)
                 && (mTtlStockhist1.WarehouseCode == mTtlStockhist2.WarehouseCode)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
                 && (mTtlStockhist1.WarehouseShelfNo == mTtlStockhist2.WarehouseShelfNo)
                 && (mTtlStockhist1.BlGoodsCode == mTtlStockhist2.BlGoodsCode)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
                 && (mTtlStockhist1.GoodsNo == mTtlStockhist2.GoodsNo)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
                 && (mTtlStockhist1.GoodsName == mTtlStockhist2.GoodsName)
                 // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
                 && (mTtlStockhist1.GoodsMakerCd == mTtlStockhist2.GoodsMakerCd)
                 && (mTtlStockhist1.SalesTimes == mTtlStockhist2.SalesTimes)
                 && (mTtlStockhist1.SalesCount == mTtlStockhist2.SalesCount)
                 && (mTtlStockhist1.SalesMoneyTaxExc == mTtlStockhist2.SalesMoneyTaxExc)
                 && (mTtlStockhist1.SalesMoneyAvg == mTtlStockhist2.SalesMoneyAvg)
                 && (mTtlStockhist1.StockTimes == mTtlStockhist2.StockTimes)
                 && (mTtlStockhist1.StockCount == mTtlStockhist2.StockCount)
                 && (mTtlStockhist1.StockPriceTaxExc == mTtlStockhist2.StockPriceTaxExc)
                 && (mTtlStockhist1.StockPriceAvg == mTtlStockhist2.StockPriceAvg)
                 && (mTtlStockhist1.GrossProfit == mTtlStockhist2.GrossProfit)
                 && (mTtlStockhist1.MoveArrivalCnt == mTtlStockhist2.MoveArrivalCnt)
                 && (mTtlStockhist1.MoveArrivalPrice == mTtlStockhist2.MoveArrivalPrice)
                 && (mTtlStockhist1.MoveShipmentCnt == mTtlStockhist2.MoveShipmentCnt)
                 && (mTtlStockhist1.MoveShipmentPrice == mTtlStockhist2.MoveShipmentPrice) 
                 && (mTtlStockhist1.StockSupplierCode == mTtlStockhist2.StockSupplierCode)
                 && (mTtlStockhist1.StockCreateDate == mTtlStockhist2.StockCreateDate)
                 && (mTtlStockhist1.LastSalesDate == mTtlStockhist2.LastSalesDate)
                 && (mTtlStockhist1.LastStockDate == mTtlStockhist2.LastStockDate)
                 && (mTtlStockhist1.SearchDiv == mTtlStockhist2.SearchDiv));
        }
        /// <summary>
        /// �݌Ɏ��яƉ�W�v�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockHistoryDspSearchResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockHistoryDspSearchResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.BlGoodsCode != target.BlGoodsCode) resList.Add("BlGoodsCode");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.SalesTimes != target.SalesTimes) resList.Add("SalesTimes");
            if (this.SalesCount != target.SalesCount) resList.Add("SalesCount");
            if (this.SalesMoneyTaxExc != target.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (this.SalesMoneyAvg != target.SalesMoneyAvg) resList.Add("SalesMoneyAvg");
            if (this.StockTimes != target.StockTimes) resList.Add("StockTimes");
            if (this.StockCount != target.StockCount) resList.Add("StockCount");
            if (this.StockPriceTaxExc != target.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (this.StockPriceAvg != target.StockPriceAvg) resList.Add("StockPriceAvg");
            if (this.GrossProfit != target.GrossProfit) resList.Add("GrossProfit");
            if (this.MoveArrivalCnt != target.MoveArrivalCnt) resList.Add("MoveArrivalCnt");
            if (this.MoveArrivalPrice != target.MoveArrivalPrice) resList.Add("MoveArrivalPrice");
            if (this.MoveShipmentCnt != target.MoveShipmentCnt) resList.Add("MoveShipmentCnt");
            if (this.MoveShipmentPrice != target.MoveShipmentPrice) resList.Add("MoveShipmentPrice");
            if (this.StockSupplierCode != target.StockSupplierCode) resList.Add("StockSupplierCode");
            if (this.StockCreateDate != target.StockCreateDate) resList.Add("StockCreateDate");
            if (this.LastSalesDate != target.LastSalesDate) resList.Add("LastSalesDate");
            if (this.LastStockDate != target.LastStockDate) resList.Add("LastStockDate");
            if (this.SearchDiv != target.SearchDiv) resList.Add("SearchDiv");

            return resList;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^��r����
        /// </summary>
        /// <param name="shipmentPartsDspResult1">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <param name="shipmentPartsDspResult2">��r����ShipmentPartsDspResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesSlip�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockHistoryDspSearchResult shipmentPartsDspResult1, StockHistoryDspSearchResult shipmentPartsDspResult2)
        {
            ArrayList resList = new ArrayList();
            if (shipmentPartsDspResult1.EnterpriseCode != shipmentPartsDspResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (shipmentPartsDspResult1.AddUpYearMonth != shipmentPartsDspResult2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (shipmentPartsDspResult1.WarehouseCode != shipmentPartsDspResult2.WarehouseCode) resList.Add("WarehouseCode");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            if (shipmentPartsDspResult1.WarehouseShelfNo != shipmentPartsDspResult2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (shipmentPartsDspResult1.BlGoodsCode != shipmentPartsDspResult2.BlGoodsCode) resList.Add("BlGoodsCode");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            if (shipmentPartsDspResult1.GoodsNo != shipmentPartsDspResult2.GoodsNo) resList.Add("GoodsNo");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            if (shipmentPartsDspResult1.GoodsName != shipmentPartsDspResult2.GoodsName) resList.Add("GoodsName");
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            if (shipmentPartsDspResult1.GoodsMakerCd != shipmentPartsDspResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (shipmentPartsDspResult1.SalesTimes != shipmentPartsDspResult2.SalesTimes) resList.Add("SalesTimes");
            if (shipmentPartsDspResult1.SalesCount != shipmentPartsDspResult2.SalesCount) resList.Add("SalesCount");
            if (shipmentPartsDspResult1.SalesMoneyTaxExc != shipmentPartsDspResult2.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (shipmentPartsDspResult1.SalesMoneyAvg != shipmentPartsDspResult2.SalesMoneyAvg) resList.Add("SalesMoneyAvg");
            if (shipmentPartsDspResult1.StockTimes != shipmentPartsDspResult2.StockTimes) resList.Add("StockTimes");
            if (shipmentPartsDspResult1.StockCount != shipmentPartsDspResult2.StockCount) resList.Add("StockCount");
            if (shipmentPartsDspResult1.StockPriceTaxExc != shipmentPartsDspResult2.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (shipmentPartsDspResult1.StockPriceAvg != shipmentPartsDspResult2.StockPriceAvg) resList.Add("StockPriceAvg");
            if (shipmentPartsDspResult1.GrossProfit != shipmentPartsDspResult2.GrossProfit) resList.Add("GrossProfit");
            if (shipmentPartsDspResult1.MoveArrivalCnt != shipmentPartsDspResult2.MoveArrivalCnt) resList.Add("MoveArrivalCnt");
            if (shipmentPartsDspResult1.MoveArrivalPrice != shipmentPartsDspResult2.MoveArrivalPrice) resList.Add("MoveArrivalPrice");
            if (shipmentPartsDspResult1.MoveShipmentCnt != shipmentPartsDspResult2.MoveShipmentCnt) resList.Add("MoveShipmentCnt");
            if (shipmentPartsDspResult1.MoveShipmentPrice != shipmentPartsDspResult2.MoveShipmentPrice) resList.Add("MoveShipmentPrice");
            if (shipmentPartsDspResult1.StockSupplierCode != shipmentPartsDspResult2.StockSupplierCode) resList.Add("StockSupplierCode");
            if (shipmentPartsDspResult1.StockCreateDate != shipmentPartsDspResult2.StockCreateDate) resList.Add("StockCreateDate");
            if (shipmentPartsDspResult1.LastSalesDate != shipmentPartsDspResult2.LastSalesDate) resList.Add("LastSalesDate");
            if (shipmentPartsDspResult1.LastStockDate != shipmentPartsDspResult2.LastStockDate) resList.Add("LastStockDate");
            if (shipmentPartsDspResult1.SearchDiv != shipmentPartsDspResult2.SearchDiv) resList.Add("SearchDiv");

            return resList;
        }
    }
}
