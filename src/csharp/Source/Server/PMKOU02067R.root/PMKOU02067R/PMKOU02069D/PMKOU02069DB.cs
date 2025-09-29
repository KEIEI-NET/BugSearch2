using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

/// public class name:   StockSalesResultInfoWork
	/// <summary>
	///                      仕入売上実績表ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入売上実績表ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2009/06/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSalesResultInfoWork 
	{
		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>入力日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private Int32 _inputDay;

		/// <summary>仕入日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _stockDate;

		/// <summary>拠点ガイド名称</summary>
		/// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
		private string _sectionGuideNm = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>売上日付</summary>
		/// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
		private Int32 _salesDate;

		/// <summary>売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _salesSlipNum = "";

		/// <summary>仕入担当者名称</summary>
		/// <remarks>発注者をセット</remarks>
		private string _stockAgentName = "";

		/// <summary>受付従業員名称</summary>
		private string _frontEmployeeNm = "";

		/// <summary>売上入力者名称</summary>
		private string _salesInputName = "";

		/// <summary>ＵＯＥリマーク１</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>ＵＯＥリマーク２</summary>
		private string _uoeRemark2 = "";

		/// <summary>伝票備考</summary>
		private string _slipNote = "";

		/// <summary>伝票備考２</summary>
		private string _slipNote2 = "";

		/// <summary>伝票備考３</summary>
		private string _slipNote3 = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>仕入在庫取寄せ区分</summary>
		/// <remarks>0:取寄せ,1:在庫</remarks>
		private Int32 _stockOrderDivCd;

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>定価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>仕入数</summary>
		private Double _stockCount;

		/// <summary>売上単価（税抜，浮動）</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>売上金額（税抜き）</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>仕入金額（税抜き）</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>仕入単価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入伝票区分（明細）</summary>
		/// <remarks>0:仕入,1:返品,2:値引</remarks>
		private Int32 _stockSlipCdDtl;

		/// <summary>売上伝票区分（明細）</summary>
		/// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>仕入伝票備考1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>仕入伝票番号</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>売上伝票区分</summary>
		/// <remarks>0:売上,1:返品</remarks>
		private Int32 _salesSlipCd;

		/// <summary>売上伝票合計（税抜き）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
		private Int64 _salesTotalTaxExc;

		/// <summary>売上値引金額計（税抜き）</summary>
		/// <remarks>売上値引外税対象額合計+売上値引内税対象額合計</remarks>
		private Int64 _salesDisTtlTaxExc;

		/// <summary>売上伝票合計（税込み）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>売上値引消費税額（外税）</summary>
		/// <remarks>外税商品値引の消費税額</remarks>
		private Int64 _salesDisOutTax;

		/// <summary>仕入金額小計</summary>
		/// <remarks>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>仕入金額計（税込み）</summary>
		/// <remarks>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>仕入金額計（税抜き）</summary>
		/// <remarks>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>仕入値引金額計（税抜き）</summary>
		/// <remarks>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</remarks>
		private Int64 _stckDisTtlTaxExc;

		/// <summary>出荷数</summary>
		private Double _shipmentCnt;

		/// <summary>仕入行番号</summary>
		private Int32 _stockRowNo;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動)</remarks>
		private Int32 _stockGoodsCd;


		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>仕入日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 StockDate
		{
			get{return _stockDate;}
			set{_stockDate = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
		/// <value>ＵＩ用（既存のコンボボックス等）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerName
		/// <summary>得意先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  SalesDate
		/// <summary>売上日付プロパティ</summary>
		/// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesDate
		{
			get{return _salesDate;}
			set{_salesDate = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>仕入担当者名称プロパティ</summary>
		/// <value>発注者をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  FrontEmployeeNm
		/// <summary>受付従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeNm
		{
			get{return _frontEmployeeNm;}
			set{_frontEmployeeNm = value;}
		}

		/// public propaty name  :  SalesInputName
		/// <summary>売上入力者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上入力者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputName
		{
			get{return _salesInputName;}
			set{_salesInputName = value;}
		}

		/// public propaty name  :  UoeRemark1
		/// <summary>ＵＯＥリマーク１プロパティ</summary>
		/// <value>UserOrderEntory</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＵＯＥリマーク１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UoeRemark1
		{
			get{return _uoeRemark1;}
			set{_uoeRemark1 = value;}
		}

		/// public propaty name  :  UoeRemark2
		/// <summary>ＵＯＥリマーク２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＵＯＥリマーク２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UoeRemark2
		{
			get{return _uoeRemark2;}
			set{_uoeRemark2 = value;}
		}

		/// public propaty name  :  SlipNote
		/// <summary>伝票備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
		}

		/// public propaty name  :  SlipNote2
		/// <summary>伝票備考２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote2
		{
			get{return _slipNote2;}
			set{_slipNote2 = value;}
		}

		/// public propaty name  :  SlipNote3
		/// <summary>伝票備考３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote3
		{
			get{return _slipNote3;}
			set{_slipNote3 = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  StockOrderDivCd
		/// <summary>仕入在庫取寄せ区分プロパティ</summary>
		/// <value>0:取寄せ,1:在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockOrderDivCd
		{
			get{return _stockOrderDivCd;}
			set{_stockOrderDivCd = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>定価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  StockCount
		/// <summary>仕入数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockCount
		{
			get{return _stockCount;}
			set{_stockCount = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxExcFl
		/// <summary>売上単価（税抜，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnPrcTaxExcFl
		{
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
		}

		/// public propaty name  :  SalesMoneyTaxExc
		/// <summary>売上金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesMoneyTaxExc
		{
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>仕入金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>仕入単価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  PartySaleSlipNum
		/// <summary>相手先伝票番号プロパティ</summary>
		/// <value>仕入先伝票番号に使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySaleSlipNum
		{
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
		}

		/// public propaty name  :  StockSlipCdDtl
		/// <summary>仕入伝票区分（明細）プロパティ</summary>
		/// <value>0:仕入,1:返品,2:値引</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票区分（明細）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSlipCdDtl
		{
			get{return _stockSlipCdDtl;}
			set{_stockSlipCdDtl = value;}
		}

		/// public propaty name  :  SalesSlipCdDtl
		/// <summary>売上伝票区分（明細）プロパティ</summary>
		/// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分（明細）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCdDtl
		{
			get{return _salesSlipCdDtl;}
			set{_salesSlipCdDtl = value;}
		}

		/// public propaty name  :  SupplierSlipNote1
		/// <summary>仕入伝票備考1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票備考1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSlipNote1
		{
			get{return _supplierSlipNote1;}
			set{_supplierSlipNote1 = value;}
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>仕入伝票番号プロパティ</summary>
		/// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get{return _supplierSlipNo;}
			set{_supplierSlipNo = value;}
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>仕入伝票区分プロパティ</summary>
		/// <value>10:仕入,20:返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
		}

		/// public propaty name  :  SalesSlipCd
		/// <summary>売上伝票区分プロパティ</summary>
		/// <value>0:売上,1:返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
		}

		/// public propaty name  :  SalesTotalTaxExc
		/// <summary>売上伝票合計（税抜き）プロパティ</summary>
		/// <value>売上正価金額＋売上値引金額計（税抜き）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTotalTaxExc
		{
			get{return _salesTotalTaxExc;}
			set{_salesTotalTaxExc = value;}
		}

		/// public propaty name  :  SalesDisTtlTaxExc
		/// <summary>売上値引金額計（税抜き）プロパティ</summary>
		/// <value>売上値引外税対象額合計+売上値引内税対象額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上値引金額計（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesDisTtlTaxExc
		{
			get{return _salesDisTtlTaxExc;}
			set{_salesDisTtlTaxExc = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>売上伝票合計（税込み）プロパティ</summary>
		/// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票合計（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  SalesDisOutTax
		/// <summary>売上値引消費税額（外税）プロパティ</summary>
		/// <value>外税商品値引の消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上値引消費税額（外税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesDisOutTax
		{
			get{return _salesDisOutTax;}
			set{_salesDisOutTax = value;}
		}

		/// public propaty name  :  StockSubttlPrice
		/// <summary>仕入金額小計プロパティ</summary>
		/// <value>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額小計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSubttlPrice
		{
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
		}

		/// public propaty name  :  StockTtlPricTaxInc
		/// <summary>仕入金額計（税込み）プロパティ</summary>
		/// <value>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額計（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtlPricTaxInc
		{
			get{return _stockTtlPricTaxInc;}
			set{_stockTtlPricTaxInc = value;}
		}

		/// public propaty name  :  StockTtlPricTaxExc
		/// <summary>仕入金額計（税抜き）プロパティ</summary>
		/// <value>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額計（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtlPricTaxExc
		{
			get{return _stockTtlPricTaxExc;}
			set{_stockTtlPricTaxExc = value;}
		}

		/// public propaty name  :  StckDisTtlTaxExc
		/// <summary>仕入値引金額計（税抜き）プロパティ</summary>
		/// <value>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引金額計（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StckDisTtlTaxExc
		{
			get{return _stckDisTtlTaxExc;}
			set{_stckDisTtlTaxExc = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>出荷数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  StockRowNo
		/// <summary>仕入行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockRowNo
		{
			get{return _stockRowNo;}
			set{_stockRowNo = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>仕入商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockGoodsCd
		{
			get{return _stockGoodsCd;}
			set{_stockGoodsCd = value;}
		}


		/// <summary>
		/// 仕入売上実績表ワークコンストラクタ
		/// </summary>
		/// <returns>StockSalesResultInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSalesResultInfoWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSalesResultInfoWork()
		{
		}

	}

    /// <summary>
///  Ver5.10.1.0用のカスタムシライアライザです。
/// </summary>
/// <returns>StockSalesResultInfoWorkクラスのインスタンス(object)</returns>
/// <remarks>
/// <br>Note　　　　　　 :   StockSalesResultInfoWorkクラスのカスタムシリアライザを定義します</br>
/// <br>Programer        :   自動生成</br>
/// </remarks>
public class StockSalesResultInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
	#region ICustomSerializationSurrogate メンバ
	
	/// <summary>
	///  Ver5.10.1.0用のカスタムシリアライザです
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   StockSalesResultInfoWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  StockSalesResultInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is StockSalesResultInfoWork || graph is ArrayList || graph is StockSalesResultInfoWork[]) )
			throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(StockSalesResultInfoWork).FullName ) );

		if( graph != null && graph is StockSalesResultInfoWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSalesResultInfoWork" );

		//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		int occurrence = 0;     //一般にゼロの場合もありえます
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is StockSalesResultInfoWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((StockSalesResultInfoWork[])graph).Length;
		}
		else if( graph is StockSalesResultInfoWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //繰り返し数	

		//拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
		//入力日
		serInfo.MemberInfo.Add( typeof(Int32) ); //InputDay
		//仕入日
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockDate
		//拠点ガイド名称
		serInfo.MemberInfo.Add( typeof(string) ); //SectionGuideNm
		//得意先コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		//得意先名称
		serInfo.MemberInfo.Add( typeof(string) ); //CustomerName
		//売上日付
		serInfo.MemberInfo.Add( typeof(Int32) ); //SalesDate
		//売上伝票番号
		serInfo.MemberInfo.Add( typeof(string) ); //SalesSlipNum
		//仕入担当者名称
		serInfo.MemberInfo.Add( typeof(string) ); //StockAgentName
		//受付従業員名称
		serInfo.MemberInfo.Add( typeof(string) ); //FrontEmployeeNm
		//売上入力者名称
		serInfo.MemberInfo.Add( typeof(string) ); //SalesInputName
		//ＵＯＥリマーク１
		serInfo.MemberInfo.Add( typeof(string) ); //UoeRemark1
		//ＵＯＥリマーク２
		serInfo.MemberInfo.Add( typeof(string) ); //UoeRemark2
		//伝票備考
		serInfo.MemberInfo.Add( typeof(string) ); //SlipNote
		//伝票備考２
		serInfo.MemberInfo.Add( typeof(string) ); //SlipNote2
		//伝票備考３
		serInfo.MemberInfo.Add( typeof(string) ); //SlipNote3
		//商品番号
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsNo
		//仕入在庫取寄せ区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockOrderDivCd
		//商品名称
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsName
		//定価（税抜，浮動）
		serInfo.MemberInfo.Add( typeof(Double) ); //ListPriceTaxExcFl
		//仕入数
		serInfo.MemberInfo.Add( typeof(Double) ); //StockCount
		//売上単価（税抜，浮動）
		serInfo.MemberInfo.Add( typeof(Double) ); //SalesUnPrcTaxExcFl
		//売上金額（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesMoneyTaxExc
		//仕入金額（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockPriceTaxExc
		//仕入単価（税抜，浮動）
		serInfo.MemberInfo.Add( typeof(Double) ); //StockUnitPriceFl
		//仕入先コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierCd
		//相手先伝票番号
		serInfo.MemberInfo.Add( typeof(string) ); //PartySaleSlipNum
		//仕入伝票区分（明細）
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockSlipCdDtl
		//売上伝票区分（明細）
		serInfo.MemberInfo.Add( typeof(Int32) ); //SalesSlipCdDtl
		//仕入伝票備考1
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierSlipNote1
		//仕入伝票番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierSlipNo
		//仕入伝票区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierSlipCd
		//売上伝票区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //SalesSlipCd
		//売上伝票合計（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesTotalTaxExc
		//売上値引金額計（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesDisTtlTaxExc
		//売上伝票合計（税込み）
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesTotalTaxInc
		//売上値引消費税額（外税）
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesDisOutTax
		//仕入金額小計
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockSubttlPrice
		//仕入金額計（税込み）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtlPricTaxInc
		//仕入金額計（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtlPricTaxExc
		//仕入値引金額計（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StckDisTtlTaxExc
		//出荷数
		serInfo.MemberInfo.Add( typeof(Double) ); //ShipmentCnt
		//仕入行番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockRowNo
		//仕入商品区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockGoodsCd

			
		serInfo.Serialize( writer, serInfo );
		if( graph is StockSalesResultInfoWork )
		{
			StockSalesResultInfoWork temp = (StockSalesResultInfoWork)graph;

			SetStockSalesResultInfoWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is StockSalesResultInfoWork[])
			{
				lst = new ArrayList();
				lst.AddRange((StockSalesResultInfoWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(StockSalesResultInfoWork temp in lst)
			{
				SetStockSalesResultInfoWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// StockSalesResultInfoWorkメンバ数(publicプロパティ数)
	/// </summary>
	private const int currentMemberCount = 44;
		
	/// <summary>
	///  StockSalesResultInfoWorkインスタンス書き込み
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   StockSalesResultInfoWorkのインスタンスを書き込み</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	private void SetStockSalesResultInfoWork( System.IO.BinaryWriter writer, StockSalesResultInfoWork temp )
	{
		//拠点コード
		writer.Write( temp.SectionCode );
		//入力日
		writer.Write( temp.InputDay );
		//仕入日
		writer.Write( temp.StockDate);
		//拠点ガイド名称
		writer.Write( temp.SectionGuideNm );
		//得意先コード
		writer.Write( temp.CustomerCode );
		//得意先名称
		writer.Write( temp.CustomerName );
		//売上日付
		writer.Write( temp.SalesDate );
		//売上伝票番号
		writer.Write( temp.SalesSlipNum );
		//仕入担当者名称
		writer.Write( temp.StockAgentName );
		//受付従業員名称
		writer.Write( temp.FrontEmployeeNm );
		//売上入力者名称
		writer.Write( temp.SalesInputName );
		//ＵＯＥリマーク１
		writer.Write( temp.UoeRemark1 );
		//ＵＯＥリマーク２
		writer.Write( temp.UoeRemark2 );
		//伝票備考
		writer.Write( temp.SlipNote );
		//伝票備考２
		writer.Write( temp.SlipNote2 );
		//伝票備考３
		writer.Write( temp.SlipNote3 );
		//商品番号
		writer.Write( temp.GoodsNo );
		//仕入在庫取寄せ区分
		writer.Write( temp.StockOrderDivCd );
		//商品名称
		writer.Write( temp.GoodsName );
		//定価（税抜，浮動）
		writer.Write( temp.ListPriceTaxExcFl );
		//仕入数
		writer.Write( temp.StockCount );
		//売上単価（税抜，浮動）
		writer.Write( temp.SalesUnPrcTaxExcFl );
		//売上金額（税抜き）
		writer.Write( temp.SalesMoneyTaxExc );
		//仕入金額（税抜き）
		writer.Write( temp.StockPriceTaxExc );
		//仕入単価（税抜，浮動）
		writer.Write( temp.StockUnitPriceFl );
		//仕入先コード
		writer.Write( temp.SupplierCd );
		//相手先伝票番号
		writer.Write( temp.PartySaleSlipNum );
		//仕入伝票区分（明細）
		writer.Write( temp.StockSlipCdDtl );
		//売上伝票区分（明細）
		writer.Write( temp.SalesSlipCdDtl );
		//仕入伝票備考1
		writer.Write( temp.SupplierSlipNote1 );
		//仕入伝票番号
		writer.Write( temp.SupplierSlipNo );
		//仕入伝票区分
		writer.Write( temp.SupplierSlipCd );
		//売上伝票区分
		writer.Write( temp.SalesSlipCd );
		//売上伝票合計（税抜き）
		writer.Write( temp.SalesTotalTaxExc );
		//売上値引金額計（税抜き）
		writer.Write( temp.SalesDisTtlTaxExc );
		//売上伝票合計（税込み）
		writer.Write( temp.SalesTotalTaxInc );
		//売上値引消費税額（外税）
		writer.Write( temp.SalesDisOutTax );
		//仕入金額小計
		writer.Write( temp.StockSubttlPrice );
		//仕入金額計（税込み）
		writer.Write( temp.StockTtlPricTaxInc );
		//仕入金額計（税抜き）
		writer.Write( temp.StockTtlPricTaxExc );
		//仕入値引金額計（税抜き）
		writer.Write( temp.StckDisTtlTaxExc );
		//出荷数
		writer.Write( temp.ShipmentCnt );
		//仕入行番号
		writer.Write( temp.StockRowNo );
		//仕入商品区分
		writer.Write( temp.StockGoodsCd );

	}

	/// <summary>
	///  StockSalesResultInfoWorkインスタンス取得
	/// </summary>
	/// <returns>StockSalesResultInfoWorkクラスのインスタンス</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   StockSalesResultInfoWorkのインスタンスを取得します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	private StockSalesResultInfoWork GetStockSalesResultInfoWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0なので不要ですが、V5.1.0.1以降では
		// serInfo.MemberInfo.Count < currentMemberCount
		// のケースについての配慮が必要になります。

		StockSalesResultInfoWork temp = new StockSalesResultInfoWork();

		//拠点コード
		temp.SectionCode = reader.ReadString();
		//入力日
		temp.InputDay = reader.ReadInt32();
		//仕入日
		temp.StockDate = reader.ReadInt32();
		//拠点ガイド名称
		temp.SectionGuideNm = reader.ReadString();
		//得意先コード
		temp.CustomerCode = reader.ReadInt32();
		//得意先名称
		temp.CustomerName = reader.ReadString();
		//売上日付
		temp.SalesDate = reader.ReadInt32();
		//売上伝票番号
		temp.SalesSlipNum = reader.ReadString();
		//仕入担当者名称
		temp.StockAgentName = reader.ReadString();
		//受付従業員名称
		temp.FrontEmployeeNm = reader.ReadString();
		//売上入力者名称
		temp.SalesInputName = reader.ReadString();
		//ＵＯＥリマーク１
		temp.UoeRemark1 = reader.ReadString();
		//ＵＯＥリマーク２
		temp.UoeRemark2 = reader.ReadString();
		//伝票備考
		temp.SlipNote = reader.ReadString();
		//伝票備考２
		temp.SlipNote2 = reader.ReadString();
		//伝票備考３
		temp.SlipNote3 = reader.ReadString();
		//商品番号
		temp.GoodsNo = reader.ReadString();
		//仕入在庫取寄せ区分
		temp.StockOrderDivCd = reader.ReadInt32();
		//商品名称
		temp.GoodsName = reader.ReadString();
		//定価（税抜，浮動）
		temp.ListPriceTaxExcFl = reader.ReadDouble();
		//仕入数
		temp.StockCount = reader.ReadDouble();
		//売上単価（税抜，浮動）
		temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
		//売上金額（税抜き）
		temp.SalesMoneyTaxExc = reader.ReadInt64();
		//仕入金額（税抜き）
		temp.StockPriceTaxExc = reader.ReadInt64();
		//仕入単価（税抜，浮動）
		temp.StockUnitPriceFl = reader.ReadDouble();
		//仕入先コード
		temp.SupplierCd = reader.ReadInt32();
		//相手先伝票番号
		temp.PartySaleSlipNum = reader.ReadString();
		//仕入伝票区分（明細）
		temp.StockSlipCdDtl = reader.ReadInt32();
		//売上伝票区分（明細）
		temp.SalesSlipCdDtl = reader.ReadInt32();
		//仕入伝票備考1
		temp.SupplierSlipNote1 = reader.ReadString();
		//仕入伝票番号
		temp.SupplierSlipNo = reader.ReadInt32();
		//仕入伝票区分
		temp.SupplierSlipCd = reader.ReadInt32();
		//売上伝票区分
		temp.SalesSlipCd = reader.ReadInt32();
		//売上伝票合計（税抜き）
		temp.SalesTotalTaxExc = reader.ReadInt64();
		//売上値引金額計（税抜き）
		temp.SalesDisTtlTaxExc = reader.ReadInt64();
		//売上伝票合計（税込み）
		temp.SalesTotalTaxInc = reader.ReadInt64();
		//売上値引消費税額（外税）
		temp.SalesDisOutTax = reader.ReadInt64();
		//仕入金額小計
		temp.StockSubttlPrice = reader.ReadInt64();
		//仕入金額計（税込み）
		temp.StockTtlPricTaxInc = reader.ReadInt64();
		//仕入金額計（税抜き）
		temp.StockTtlPricTaxExc = reader.ReadInt64();
		//仕入値引金額計（税抜き）
		temp.StckDisTtlTaxExc = reader.ReadInt64();
		//出荷数
		temp.ShipmentCnt = reader.ReadDouble();
		//仕入行番号
		temp.StockRowNo = reader.ReadInt32();
		//仕入商品区分
		temp.StockGoodsCd = reader.ReadInt32();

			
		//以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
		//データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
		//型情報にしたがって、ストリームから情報を読み出します...といっても
		//読み出して捨てることになります。
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]をデシリアライズする直前に、そのlengthが
			//デシリアライズされているケースがある、byte[],char[]の
			//デシリアライズにはlengthが必要なのでint型のデータをデ
			//シリアライズした場合は、この値をこの変数に退避します。
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
			{
				Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				object userData = formatter.Deserialize( reader );  //読み飛ばし
			}
		}
		return temp;
	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムデシリアライザです
	/// </summary>
	/// <returns>StockSalesResultInfoWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   StockSalesResultInfoWorkクラスのカスタムデシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			StockSalesResultInfoWork temp = GetStockSalesResultInfoWork( reader, serInfo );
			lst.Add( temp );
		}
		switch(serInfo.RetTypeInfo)
		{
			case 0:
				retValue = lst;
				break;
			case 1:
				retValue = lst[0];
				break;
			case 2:
				retValue = (StockSalesResultInfoWork[])lst.ToArray(typeof(StockSalesResultInfoWork));
				break;
		}
		return retValue;
	}

	#endregion
}




}
