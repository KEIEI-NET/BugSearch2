using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MailDefaultDetail
	/// <summary>
	///                      メール初期値明細データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   メール初期値明細データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2010/5/18</br>
	/// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class MailDefaultDetail
	{
		/// <summary>売上行番号</summary>
		private Int32 _salesRowNo;

		/// <summary>売上行番号枝番</summary>
		/// <remarks>検索見積の対比で使用する</remarks>
		private Int32 _salesRowDerivNo;

		/// <summary>納品完了予定日</summary>
		/// <remarks>客先納期(YYYYMMDD)</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>商品属性</summary>
		/// <remarks>0:純正 1:優良</remarks>
		private Int32 _goodsKindCode;

		/// <summary>商品メーカーコード</summary>
		/// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>自社分類コード</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>自社分類名称</summary>
		private string _enterpriseGanreName = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

		/// <summary>売上在庫取寄せ区分</summary>
		/// <remarks>0:取寄せ，1:在庫</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>オープン価格区分</summary>
		/// <remarks>0:通常／1:オープン価格</remarks>
		private Int32 _openPriceDiv;

		/// <summary>定価率</summary>
		private Double _listPriceRate;

		/// <summary>定価（税込，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _listPriceTaxIncFl;

		/// <summary>定価（税抜，浮動）</summary>
		/// <remarks>税込み</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>売価率</summary>
		private Double _salesRate;

		/// <summary>売上単価（税込，浮動）</summary>
		private Double _salesUnPrcTaxIncFl;

		/// <summary>売上単価（税抜，浮動）</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>原価単価</summary>
		private Double _salesUnitCost;

		/// <summary>BL商品コード（印刷）</summary>
		/// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
		private Int32 _prtBLGoodsCode;

		/// <summary>BL商品コード名称（印刷）</summary>
		/// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
		private string _prtBLGoodsName = "";

		/// <summary>販売区分コード</summary>
		private Int32 _salesCode;

		/// <summary>販売区分名称</summary>
		private string _salesCdNm = "";

		/// <summary>作業工数</summary>
		private Double _workManHour;

		/// <summary>出荷数</summary>
		private Double _shipmentCnt;

		/// <summary>売上金額（税込み）</summary>
		private Int64 _salesMoneyTaxInc;

		/// <summary>売上金額（税抜き）</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>原価</summary>
		private Int64 _cost;

		/// <summary>売上商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
		private Int32 _salesGoodsCd;

		/// <summary>売上金額消費税額</summary>
		/// <remarks>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</remarks>
		private Int64 _salesPriceConsTax;

		/// <summary>課税区分</summary>
		/// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
		private Int32 _taxationDivCd;

		/// <summary>相手先伝票番号（明細）</summary>
		/// <remarks>得意先注文番号（仮伝No）</remarks>
		private string _partySlipNumDtl = "";

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>発注番号</summary>
		private string _orderNumber = "";

		/// <summary>注文方法</summary>
		/// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
		private Int32 _wayToOrder;

		/// <summary>印刷用品番</summary>
		private string _prtGoodsNo = "";

		/// <summary>印刷用メーカーコード</summary>
		private Int32 _prtMakerCode;

		/// <summary>印刷用メーカー名称</summary>
		private string _prtMakerName = "";

		/// <summary>キャンペーンコード</summary>
		/// <remarks>拠点と連結でキーとなるので注意（管理拠点コード）</remarks>
		private Int32 _campaignCode;

		/// <summary>キャンペーン名称</summary>
		private string _campaignName = "";

		/// <summary>商品種別</summary>
		/// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
		private Int32 _goodsDivCd;

		/// <summary>回答納期</summary>
		private string _answerDelivDate = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";


		/// public propaty name  :  SalesRowNo
		/// <summary>売上行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesRowNo
		{
			get{return _salesRowNo;}
			set{_salesRowNo = value;}
		}

		/// public propaty name  :  SalesRowDerivNo
		/// <summary>売上行番号枝番プロパティ</summary>
		/// <value>検索見積の対比で使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上行番号枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesRowDerivNo
		{
			get{return _salesRowDerivNo;}
			set{_salesRowDerivNo = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>納品完了予定日プロパティ</summary>
		/// <value>客先納期(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>納品完了予定日 和暦プロパティ</summary>
		/// <value>客先納期(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>納品完了予定日 和暦(略)プロパティ</summary>
		/// <value>客先納期(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>納品完了予定日 西暦プロパティ</summary>
		/// <value>客先納期(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>納品完了予定日 西暦(略)プロパティ</summary>
		/// <value>客先納期(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>商品属性プロパティ</summary>
		/// <value>0:純正 1:優良</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品属性プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
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

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL商品コード名称（全角）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（全角）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreName
		/// <summary>自社分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseGanreName
		{
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  SalesOrderDivCd
		/// <summary>売上在庫取寄せ区分プロパティ</summary>
		/// <value>0:取寄せ，1:在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesOrderDivCd
		{
			get{return _salesOrderDivCd;}
			set{_salesOrderDivCd = value;}
		}

		/// public propaty name  :  OpenPriceDiv
		/// <summary>オープン価格区分プロパティ</summary>
		/// <value>0:通常／1:オープン価格</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv
		{
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  ListPriceRate
		/// <summary>定価率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceRate
		{
			get{return _listPriceRate;}
			set{_listPriceRate = value;}
		}

		/// public propaty name  :  ListPriceTaxIncFl
		/// <summary>定価（税込，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxIncFl
		{
			get{return _listPriceTaxIncFl;}
			set{_listPriceTaxIncFl = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>定価（税抜，浮動）プロパティ</summary>
		/// <value>税込み</value>
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

		/// public propaty name  :  SalesRate
		/// <summary>売価率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売価率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesRate
		{
			get{return _salesRate;}
			set{_salesRate = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxIncFl
		/// <summary>売上単価（税込，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnPrcTaxIncFl
		{
			get{return _salesUnPrcTaxIncFl;}
			set{_salesUnPrcTaxIncFl = value;}
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

		/// public propaty name  :  SalesUnitCost
		/// <summary>原価単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnitCost
		{
			get{return _salesUnitCost;}
			set{_salesUnitCost = value;}
		}

		/// public propaty name  :  PrtBLGoodsCode
		/// <summary>BL商品コード（印刷）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード（印刷）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtBLGoodsCode
		{
			get{return _prtBLGoodsCode;}
			set{_prtBLGoodsCode = value;}
		}

		/// public propaty name  :  PrtBLGoodsName
		/// <summary>BL商品コード名称（印刷）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（印刷）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtBLGoodsName
		{
			get{return _prtBLGoodsName;}
			set{_prtBLGoodsName = value;}
		}

		/// public propaty name  :  SalesCode
		/// <summary>販売区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCode
		{
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCdNm
		/// <summary>販売区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesCdNm
		{
			get{return _salesCdNm;}
			set{_salesCdNm = value;}
		}

		/// public propaty name  :  WorkManHour
		/// <summary>作業工数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作業工数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double WorkManHour
		{
			get{return _workManHour;}
			set{_workManHour = value;}
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

		/// public propaty name  :  SalesMoneyTaxInc
		/// <summary>売上金額（税込み）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesMoneyTaxInc
		{
			get{return _salesMoneyTaxInc;}
			set{_salesMoneyTaxInc = value;}
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

		/// public propaty name  :  Cost
		/// <summary>原価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Cost
		{
			get{return _cost;}
			set{_cost = value;}
		}

		/// public propaty name  :  SalesGoodsCd
		/// <summary>売上商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesGoodsCd
		{
			get{return _salesGoodsCd;}
			set{_salesGoodsCd = value;}
		}

		/// public propaty name  :  SalesPriceConsTax
		/// <summary>売上金額消費税額プロパティ</summary>
		/// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesPriceConsTax
		{
			get{return _salesPriceConsTax;}
			set{_salesPriceConsTax = value;}
		}

		/// public propaty name  :  TaxationDivCd
		/// <summary>課税区分プロパティ</summary>
		/// <value>0:課税,1:非課税,2:課税（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  PartySlipNumDtl
		/// <summary>相手先伝票番号（明細）プロパティ</summary>
		/// <value>得意先注文番号（仮伝No）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号（明細）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySlipNumDtl
		{
			get{return _partySlipNumDtl;}
			set{_partySlipNumDtl = value;}
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

		/// public propaty name  :  SupplierSnm
		/// <summary>仕入先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>発注番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  WayToOrder
		/// <summary>注文方法プロパティ</summary>
		/// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
		}

		/// public propaty name  :  PrtGoodsNo
		/// <summary>印刷用品番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtGoodsNo
		{
			get{return _prtGoodsNo;}
			set{_prtGoodsNo = value;}
		}

		/// public propaty name  :  PrtMakerCode
		/// <summary>印刷用メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtMakerCode
		{
			get{return _prtMakerCode;}
			set{_prtMakerCode = value;}
		}

		/// public propaty name  :  PrtMakerName
		/// <summary>印刷用メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtMakerName
		{
			get{return _prtMakerName;}
			set{_prtMakerName = value;}
		}

		/// public propaty name  :  CampaignCode
		/// <summary>キャンペーンコードプロパティ</summary>
		/// <value>拠点と連結でキーとなるので注意（管理拠点コード）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャンペーンコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  CampaignName
		/// <summary>キャンペーン名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャンペーン名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CampaignName
		{
			get{return _campaignName;}
			set{_campaignName = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>商品種別プロパティ</summary>
		/// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  AnswerDelivDate
		/// <summary>回答納期プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答納期プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnswerDelivDate
		{
			get{return _answerDelivDate;}
			set{_answerDelivDate = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL商品コード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}


		/// <summary>
		/// メール初期値明細データコンストラクタ
		/// </summary>
		/// <returns>MailDefaultDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailDefaultDetailクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailDefaultDetail()
		{
		}

		/// <summary>
		/// メール初期値明細データコンストラクタ
		/// </summary>
		/// <param name="salesRowNo">売上行番号</param>
		/// <param name="salesRowDerivNo">売上行番号枝番(検索見積の対比で使用する)</param>
		/// <param name="deliGdsCmpltDueDate">納品完了予定日(客先納期(YYYYMMDD))</param>
		/// <param name="goodsKindCode">商品属性(0:純正 1:優良)</param>
		/// <param name="goodsMakerCd">商品メーカーコード(ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる)</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="enterpriseGanreCode">自社分類コード</param>
		/// <param name="enterpriseGanreName">自社分類名称</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="warehouseShelfNo">倉庫棚番</param>
		/// <param name="salesOrderDivCd">売上在庫取寄せ区分(0:取寄せ，1:在庫)</param>
		/// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
		/// <param name="listPriceRate">定価率</param>
		/// <param name="listPriceTaxIncFl">定価（税込，浮動）(税抜き)</param>
		/// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税込み)</param>
		/// <param name="salesRate">売価率</param>
		/// <param name="salesUnPrcTaxIncFl">売上単価（税込，浮動）</param>
		/// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）</param>
		/// <param name="salesUnitCost">原価単価</param>
		/// <param name="prtBLGoodsCode">BL商品コード（印刷）(掛率算出時に使用したBLコード（商品検索結果）)</param>
		/// <param name="prtBLGoodsName">BL商品コード名称（印刷）(掛率算出時に使用したBLコード名称（商品検索結果）)</param>
		/// <param name="salesCode">販売区分コード</param>
		/// <param name="salesCdNm">販売区分名称</param>
		/// <param name="workManHour">作業工数</param>
		/// <param name="shipmentCnt">出荷数</param>
		/// <param name="salesMoneyTaxInc">売上金額（税込み）</param>
		/// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
		/// <param name="cost">原価</param>
		/// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動))</param>
		/// <param name="salesPriceConsTax">売上金額消費税額(売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる)</param>
		/// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
		/// <param name="partySlipNumDtl">相手先伝票番号（明細）(得意先注文番号（仮伝No）)</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="supplierSnm">仕入先略称</param>
		/// <param name="orderNumber">発注番号</param>
		/// <param name="wayToOrder">注文方法(0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録)</param>
		/// <param name="prtGoodsNo">印刷用品番</param>
		/// <param name="prtMakerCode">印刷用メーカーコード</param>
		/// <param name="prtMakerName">印刷用メーカー名称</param>
		/// <param name="campaignCode">キャンペーンコード(拠点と連結でキーとなるので注意（管理拠点コード）)</param>
		/// <param name="campaignName">キャンペーン名称</param>
		/// <param name="goodsDivCd">商品種別(0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場)</param>
		/// <param name="answerDelivDate">回答納期</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <returns>MailDefaultDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailDefaultDetailクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailDefaultDetail(Int32 salesRowNo,Int32 salesRowDerivNo,DateTime deliGdsCmpltDueDate,Int32 goodsKindCode,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,Int32 bLGoodsCode,string bLGoodsFullName,Int32 enterpriseGanreCode,string enterpriseGanreName,string warehouseCode,string warehouseName,string warehouseShelfNo,Int32 salesOrderDivCd,Int32 openPriceDiv,Double listPriceRate,Double listPriceTaxIncFl,Double listPriceTaxExcFl,Double salesRate,Double salesUnPrcTaxIncFl,Double salesUnPrcTaxExcFl,Double salesUnitCost,Int32 prtBLGoodsCode,string prtBLGoodsName,Int32 salesCode,string salesCdNm,Double workManHour,Double shipmentCnt,Int64 salesMoneyTaxInc,Int64 salesMoneyTaxExc,Int64 cost,Int32 salesGoodsCd,Int64 salesPriceConsTax,Int32 taxationDivCd,string partySlipNumDtl,Int32 supplierCd,string supplierSnm,string orderNumber,Int32 wayToOrder,string prtGoodsNo,Int32 prtMakerCode,string prtMakerName,Int32 campaignCode,string campaignName,Int32 goodsDivCd,string answerDelivDate,string bLGoodsName)
		{
			this._salesRowNo = salesRowNo;
			this._salesRowDerivNo = salesRowDerivNo;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._goodsKindCode = goodsKindCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._salesOrderDivCd = salesOrderDivCd;
			this._openPriceDiv = openPriceDiv;
			this._listPriceRate = listPriceRate;
			this._listPriceTaxIncFl = listPriceTaxIncFl;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._salesRate = salesRate;
			this._salesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
			this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			this._salesUnitCost = salesUnitCost;
			this._prtBLGoodsCode = prtBLGoodsCode;
			this._prtBLGoodsName = prtBLGoodsName;
			this._salesCode = salesCode;
			this._salesCdNm = salesCdNm;
			this._workManHour = workManHour;
			this._shipmentCnt = shipmentCnt;
			this._salesMoneyTaxInc = salesMoneyTaxInc;
			this._salesMoneyTaxExc = salesMoneyTaxExc;
			this._cost = cost;
			this._salesGoodsCd = salesGoodsCd;
			this._salesPriceConsTax = salesPriceConsTax;
			this._taxationDivCd = taxationDivCd;
			this._partySlipNumDtl = partySlipNumDtl;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._orderNumber = orderNumber;
			this._wayToOrder = wayToOrder;
			this._prtGoodsNo = prtGoodsNo;
			this._prtMakerCode = prtMakerCode;
			this._prtMakerName = prtMakerName;
			this._campaignCode = campaignCode;
			this._campaignName = campaignName;
			this._goodsDivCd = goodsDivCd;
			this._answerDelivDate = answerDelivDate;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// メール初期値明細データ複製処理
		/// </summary>
		/// <returns>MailDefaultDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいMailDefaultDetailクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailDefaultDetail Clone()
		{
			return new MailDefaultDetail(this._salesRowNo,this._salesRowDerivNo,this._deliGdsCmpltDueDate,this._goodsKindCode,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._bLGoodsCode,this._bLGoodsFullName,this._enterpriseGanreCode,this._enterpriseGanreName,this._warehouseCode,this._warehouseName,this._warehouseShelfNo,this._salesOrderDivCd,this._openPriceDiv,this._listPriceRate,this._listPriceTaxIncFl,this._listPriceTaxExcFl,this._salesRate,this._salesUnPrcTaxIncFl,this._salesUnPrcTaxExcFl,this._salesUnitCost,this._prtBLGoodsCode,this._prtBLGoodsName,this._salesCode,this._salesCdNm,this._workManHour,this._shipmentCnt,this._salesMoneyTaxInc,this._salesMoneyTaxExc,this._cost,this._salesGoodsCd,this._salesPriceConsTax,this._taxationDivCd,this._partySlipNumDtl,this._supplierCd,this._supplierSnm,this._orderNumber,this._wayToOrder,this._prtGoodsNo,this._prtMakerCode,this._prtMakerName,this._campaignCode,this._campaignName,this._goodsDivCd,this._answerDelivDate,this._bLGoodsName);
		}

		/// <summary>
		/// メール初期値明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のMailDefaultDetailクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailDefaultDetailクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(MailDefaultDetail target)
		{
			return ((this.SalesRowNo == target.SalesRowNo)
				 && (this.SalesRowDerivNo == target.SalesRowDerivNo)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.ListPriceRate == target.ListPriceRate)
				 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.SalesRate == target.SalesRate)
				 && (this.SalesUnPrcTaxIncFl == target.SalesUnPrcTaxIncFl)
				 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
				 && (this.SalesUnitCost == target.SalesUnitCost)
				 && (this.PrtBLGoodsCode == target.PrtBLGoodsCode)
				 && (this.PrtBLGoodsName == target.PrtBLGoodsName)
				 && (this.SalesCode == target.SalesCode)
				 && (this.SalesCdNm == target.SalesCdNm)
				 && (this.WorkManHour == target.WorkManHour)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.SalesMoneyTaxInc == target.SalesMoneyTaxInc)
				 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
				 && (this.Cost == target.Cost)
				 && (this.SalesGoodsCd == target.SalesGoodsCd)
				 && (this.SalesPriceConsTax == target.SalesPriceConsTax)
				 && (this.TaxationDivCd == target.TaxationDivCd)
				 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.OrderNumber == target.OrderNumber)
				 && (this.WayToOrder == target.WayToOrder)
				 && (this.PrtGoodsNo == target.PrtGoodsNo)
				 && (this.PrtMakerCode == target.PrtMakerCode)
				 && (this.PrtMakerName == target.PrtMakerName)
				 && (this.CampaignCode == target.CampaignCode)
				 && (this.CampaignName == target.CampaignName)
				 && (this.GoodsDivCd == target.GoodsDivCd)
				 && (this.AnswerDelivDate == target.AnswerDelivDate)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// メール初期値明細データ比較処理
		/// </summary>
		/// <param name="mailDefaultDetail1">
		///                    比較するMailDefaultDetailクラスのインスタンス
		/// </param>
		/// <param name="mailDefaultDetail2">比較するMailDefaultDetailクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailDefaultDetailクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(MailDefaultDetail mailDefaultDetail1, MailDefaultDetail mailDefaultDetail2)
		{
			return ((mailDefaultDetail1.SalesRowNo == mailDefaultDetail2.SalesRowNo)
				 && (mailDefaultDetail1.SalesRowDerivNo == mailDefaultDetail2.SalesRowDerivNo)
				 && (mailDefaultDetail1.DeliGdsCmpltDueDate == mailDefaultDetail2.DeliGdsCmpltDueDate)
				 && (mailDefaultDetail1.GoodsKindCode == mailDefaultDetail2.GoodsKindCode)
				 && (mailDefaultDetail1.GoodsMakerCd == mailDefaultDetail2.GoodsMakerCd)
				 && (mailDefaultDetail1.MakerName == mailDefaultDetail2.MakerName)
				 && (mailDefaultDetail1.GoodsNo == mailDefaultDetail2.GoodsNo)
				 && (mailDefaultDetail1.GoodsName == mailDefaultDetail2.GoodsName)
				 && (mailDefaultDetail1.BLGoodsCode == mailDefaultDetail2.BLGoodsCode)
				 && (mailDefaultDetail1.BLGoodsFullName == mailDefaultDetail2.BLGoodsFullName)
				 && (mailDefaultDetail1.EnterpriseGanreCode == mailDefaultDetail2.EnterpriseGanreCode)
				 && (mailDefaultDetail1.EnterpriseGanreName == mailDefaultDetail2.EnterpriseGanreName)
				 && (mailDefaultDetail1.WarehouseCode == mailDefaultDetail2.WarehouseCode)
				 && (mailDefaultDetail1.WarehouseName == mailDefaultDetail2.WarehouseName)
				 && (mailDefaultDetail1.WarehouseShelfNo == mailDefaultDetail2.WarehouseShelfNo)
				 && (mailDefaultDetail1.SalesOrderDivCd == mailDefaultDetail2.SalesOrderDivCd)
				 && (mailDefaultDetail1.OpenPriceDiv == mailDefaultDetail2.OpenPriceDiv)
				 && (mailDefaultDetail1.ListPriceRate == mailDefaultDetail2.ListPriceRate)
				 && (mailDefaultDetail1.ListPriceTaxIncFl == mailDefaultDetail2.ListPriceTaxIncFl)
				 && (mailDefaultDetail1.ListPriceTaxExcFl == mailDefaultDetail2.ListPriceTaxExcFl)
				 && (mailDefaultDetail1.SalesRate == mailDefaultDetail2.SalesRate)
				 && (mailDefaultDetail1.SalesUnPrcTaxIncFl == mailDefaultDetail2.SalesUnPrcTaxIncFl)
				 && (mailDefaultDetail1.SalesUnPrcTaxExcFl == mailDefaultDetail2.SalesUnPrcTaxExcFl)
				 && (mailDefaultDetail1.SalesUnitCost == mailDefaultDetail2.SalesUnitCost)
				 && (mailDefaultDetail1.PrtBLGoodsCode == mailDefaultDetail2.PrtBLGoodsCode)
				 && (mailDefaultDetail1.PrtBLGoodsName == mailDefaultDetail2.PrtBLGoodsName)
				 && (mailDefaultDetail1.SalesCode == mailDefaultDetail2.SalesCode)
				 && (mailDefaultDetail1.SalesCdNm == mailDefaultDetail2.SalesCdNm)
				 && (mailDefaultDetail1.WorkManHour == mailDefaultDetail2.WorkManHour)
				 && (mailDefaultDetail1.ShipmentCnt == mailDefaultDetail2.ShipmentCnt)
				 && (mailDefaultDetail1.SalesMoneyTaxInc == mailDefaultDetail2.SalesMoneyTaxInc)
				 && (mailDefaultDetail1.SalesMoneyTaxExc == mailDefaultDetail2.SalesMoneyTaxExc)
				 && (mailDefaultDetail1.Cost == mailDefaultDetail2.Cost)
				 && (mailDefaultDetail1.SalesGoodsCd == mailDefaultDetail2.SalesGoodsCd)
				 && (mailDefaultDetail1.SalesPriceConsTax == mailDefaultDetail2.SalesPriceConsTax)
				 && (mailDefaultDetail1.TaxationDivCd == mailDefaultDetail2.TaxationDivCd)
				 && (mailDefaultDetail1.PartySlipNumDtl == mailDefaultDetail2.PartySlipNumDtl)
				 && (mailDefaultDetail1.SupplierCd == mailDefaultDetail2.SupplierCd)
				 && (mailDefaultDetail1.SupplierSnm == mailDefaultDetail2.SupplierSnm)
				 && (mailDefaultDetail1.OrderNumber == mailDefaultDetail2.OrderNumber)
				 && (mailDefaultDetail1.WayToOrder == mailDefaultDetail2.WayToOrder)
				 && (mailDefaultDetail1.PrtGoodsNo == mailDefaultDetail2.PrtGoodsNo)
				 && (mailDefaultDetail1.PrtMakerCode == mailDefaultDetail2.PrtMakerCode)
				 && (mailDefaultDetail1.PrtMakerName == mailDefaultDetail2.PrtMakerName)
				 && (mailDefaultDetail1.CampaignCode == mailDefaultDetail2.CampaignCode)
				 && (mailDefaultDetail1.CampaignName == mailDefaultDetail2.CampaignName)
				 && (mailDefaultDetail1.GoodsDivCd == mailDefaultDetail2.GoodsDivCd)
				 && (mailDefaultDetail1.AnswerDelivDate == mailDefaultDetail2.AnswerDelivDate)
				 && (mailDefaultDetail1.BLGoodsName == mailDefaultDetail2.BLGoodsName));
		}
		/// <summary>
		/// メール初期値明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のMailDefaultDetailクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailDefaultDetailクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(MailDefaultDetail target)
		{
			ArrayList resList = new ArrayList();
			if(this.SalesRowNo != target.SalesRowNo)resList.Add("SalesRowNo");
			if(this.SalesRowDerivNo != target.SalesRowDerivNo)resList.Add("SalesRowDerivNo");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.SalesOrderDivCd != target.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.ListPriceRate != target.ListPriceRate)resList.Add("ListPriceRate");
			if(this.ListPriceTaxIncFl != target.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.SalesRate != target.SalesRate)resList.Add("SalesRate");
			if(this.SalesUnPrcTaxIncFl != target.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(this.SalesUnitCost != target.SalesUnitCost)resList.Add("SalesUnitCost");
			if(this.PrtBLGoodsCode != target.PrtBLGoodsCode)resList.Add("PrtBLGoodsCode");
			if(this.PrtBLGoodsName != target.PrtBLGoodsName)resList.Add("PrtBLGoodsName");
			if(this.SalesCode != target.SalesCode)resList.Add("SalesCode");
			if(this.SalesCdNm != target.SalesCdNm)resList.Add("SalesCdNm");
			if(this.WorkManHour != target.WorkManHour)resList.Add("WorkManHour");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.SalesMoneyTaxInc != target.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(this.SalesMoneyTaxExc != target.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(this.Cost != target.Cost)resList.Add("Cost");
			if(this.SalesGoodsCd != target.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(this.SalesPriceConsTax != target.SalesPriceConsTax)resList.Add("SalesPriceConsTax");
			if(this.TaxationDivCd != target.TaxationDivCd)resList.Add("TaxationDivCd");
			if(this.PartySlipNumDtl != target.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.OrderNumber != target.OrderNumber)resList.Add("OrderNumber");
			if(this.WayToOrder != target.WayToOrder)resList.Add("WayToOrder");
			if(this.PrtGoodsNo != target.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(this.PrtMakerCode != target.PrtMakerCode)resList.Add("PrtMakerCode");
			if(this.PrtMakerName != target.PrtMakerName)resList.Add("PrtMakerName");
			if(this.CampaignCode != target.CampaignCode)resList.Add("CampaignCode");
			if(this.CampaignName != target.CampaignName)resList.Add("CampaignName");
			if(this.GoodsDivCd != target.GoodsDivCd)resList.Add("GoodsDivCd");
			if(this.AnswerDelivDate != target.AnswerDelivDate)resList.Add("AnswerDelivDate");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// メール初期値明細データ比較処理
		/// </summary>
		/// <param name="mailDefaultDetail1">比較するMailDefaultDetailクラスのインスタンス</param>
		/// <param name="mailDefaultDetail2">比較するMailDefaultDetailクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailDefaultDetailクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(MailDefaultDetail mailDefaultDetail1, MailDefaultDetail mailDefaultDetail2)
		{
			ArrayList resList = new ArrayList();
			if(mailDefaultDetail1.SalesRowNo != mailDefaultDetail2.SalesRowNo)resList.Add("SalesRowNo");
			if(mailDefaultDetail1.SalesRowDerivNo != mailDefaultDetail2.SalesRowDerivNo)resList.Add("SalesRowDerivNo");
			if(mailDefaultDetail1.DeliGdsCmpltDueDate != mailDefaultDetail2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(mailDefaultDetail1.GoodsKindCode != mailDefaultDetail2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(mailDefaultDetail1.GoodsMakerCd != mailDefaultDetail2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(mailDefaultDetail1.MakerName != mailDefaultDetail2.MakerName)resList.Add("MakerName");
			if(mailDefaultDetail1.GoodsNo != mailDefaultDetail2.GoodsNo)resList.Add("GoodsNo");
			if(mailDefaultDetail1.GoodsName != mailDefaultDetail2.GoodsName)resList.Add("GoodsName");
			if(mailDefaultDetail1.BLGoodsCode != mailDefaultDetail2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(mailDefaultDetail1.BLGoodsFullName != mailDefaultDetail2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(mailDefaultDetail1.EnterpriseGanreCode != mailDefaultDetail2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(mailDefaultDetail1.EnterpriseGanreName != mailDefaultDetail2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(mailDefaultDetail1.WarehouseCode != mailDefaultDetail2.WarehouseCode)resList.Add("WarehouseCode");
			if(mailDefaultDetail1.WarehouseName != mailDefaultDetail2.WarehouseName)resList.Add("WarehouseName");
			if(mailDefaultDetail1.WarehouseShelfNo != mailDefaultDetail2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(mailDefaultDetail1.SalesOrderDivCd != mailDefaultDetail2.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(mailDefaultDetail1.OpenPriceDiv != mailDefaultDetail2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(mailDefaultDetail1.ListPriceRate != mailDefaultDetail2.ListPriceRate)resList.Add("ListPriceRate");
			if(mailDefaultDetail1.ListPriceTaxIncFl != mailDefaultDetail2.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(mailDefaultDetail1.ListPriceTaxExcFl != mailDefaultDetail2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(mailDefaultDetail1.SalesRate != mailDefaultDetail2.SalesRate)resList.Add("SalesRate");
			if(mailDefaultDetail1.SalesUnPrcTaxIncFl != mailDefaultDetail2.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(mailDefaultDetail1.SalesUnPrcTaxExcFl != mailDefaultDetail2.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(mailDefaultDetail1.SalesUnitCost != mailDefaultDetail2.SalesUnitCost)resList.Add("SalesUnitCost");
			if(mailDefaultDetail1.PrtBLGoodsCode != mailDefaultDetail2.PrtBLGoodsCode)resList.Add("PrtBLGoodsCode");
			if(mailDefaultDetail1.PrtBLGoodsName != mailDefaultDetail2.PrtBLGoodsName)resList.Add("PrtBLGoodsName");
			if(mailDefaultDetail1.SalesCode != mailDefaultDetail2.SalesCode)resList.Add("SalesCode");
			if(mailDefaultDetail1.SalesCdNm != mailDefaultDetail2.SalesCdNm)resList.Add("SalesCdNm");
			if(mailDefaultDetail1.WorkManHour != mailDefaultDetail2.WorkManHour)resList.Add("WorkManHour");
			if(mailDefaultDetail1.ShipmentCnt != mailDefaultDetail2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(mailDefaultDetail1.SalesMoneyTaxInc != mailDefaultDetail2.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(mailDefaultDetail1.SalesMoneyTaxExc != mailDefaultDetail2.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(mailDefaultDetail1.Cost != mailDefaultDetail2.Cost)resList.Add("Cost");
			if(mailDefaultDetail1.SalesGoodsCd != mailDefaultDetail2.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(mailDefaultDetail1.SalesPriceConsTax != mailDefaultDetail2.SalesPriceConsTax)resList.Add("SalesPriceConsTax");
			if(mailDefaultDetail1.TaxationDivCd != mailDefaultDetail2.TaxationDivCd)resList.Add("TaxationDivCd");
			if(mailDefaultDetail1.PartySlipNumDtl != mailDefaultDetail2.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(mailDefaultDetail1.SupplierCd != mailDefaultDetail2.SupplierCd)resList.Add("SupplierCd");
			if(mailDefaultDetail1.SupplierSnm != mailDefaultDetail2.SupplierSnm)resList.Add("SupplierSnm");
			if(mailDefaultDetail1.OrderNumber != mailDefaultDetail2.OrderNumber)resList.Add("OrderNumber");
			if(mailDefaultDetail1.WayToOrder != mailDefaultDetail2.WayToOrder)resList.Add("WayToOrder");
			if(mailDefaultDetail1.PrtGoodsNo != mailDefaultDetail2.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(mailDefaultDetail1.PrtMakerCode != mailDefaultDetail2.PrtMakerCode)resList.Add("PrtMakerCode");
			if(mailDefaultDetail1.PrtMakerName != mailDefaultDetail2.PrtMakerName)resList.Add("PrtMakerName");
			if(mailDefaultDetail1.CampaignCode != mailDefaultDetail2.CampaignCode)resList.Add("CampaignCode");
			if(mailDefaultDetail1.CampaignName != mailDefaultDetail2.CampaignName)resList.Add("CampaignName");
			if(mailDefaultDetail1.GoodsDivCd != mailDefaultDetail2.GoodsDivCd)resList.Add("GoodsDivCd");
			if(mailDefaultDetail1.AnswerDelivDate != mailDefaultDetail2.AnswerDelivDate)resList.Add("AnswerDelivDate");
			if(mailDefaultDetail1.BLGoodsName != mailDefaultDetail2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}
	}
}
