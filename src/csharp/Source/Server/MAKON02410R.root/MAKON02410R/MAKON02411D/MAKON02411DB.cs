using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   LedgerStockDetailWork
	/// <summary>
	///                      仕入先元帳（仕入明細）抽出結果ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先元帳（仕入明細）抽出結果ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/07  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class LedgerStockDetailWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>仕入形式</summary>
		/// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>赤黒連結仕入伝票番号</summary>
		private Int32 _debitNLnkSuppSlipNo;

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>仕入拠点コード</summary>
		/// <remarks>文字型 売上を入力した拠点コード</remarks>
		private string _stockSectionCd = "";

		/// <summary>仕入計上拠点コード</summary>
		/// <remarks>文字型</remarks>
		private string _stockAddUpSectionCd = "";

		/// <summary>入力日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private DateTime _inputDay;

		/// <summary>入荷日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _arrivalGoodsDay;

		/// <summary>仕入日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockDate;

		/// <summary>仕入計上日付</summary>
		/// <remarks>仕入計上日</remarks>
		private DateTime _stockAddUpADate;

		/// <summary>仕入入力者コード</summary>
		private string _stockInputCode = "";

		/// <summary>仕入入力者名称</summary>
		private string _stockInputName = "";

		/// <summary>仕入担当者コード</summary>
		/// <remarks>発注者をセット</remarks>
		private string _stockAgentCode = "";

		/// <summary>仕入担当者名称</summary>
		/// <remarks>発注者をセット</remarks>
		private string _stockAgentName = "";

		/// <summary>支払先コード</summary>
		/// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
		private Int32 _payeeCode;

		/// <summary>支払先略称</summary>
		private string _payeeSnm = "";

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先名1</summary>
		private string _supplierNm1 = "";

		/// <summary>仕入先名2</summary>
		private string _supplierNm2 = "";

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>仕入金額合計</summary>
		/// <remarks>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>仕入金額小計</summary>
		/// <remarks>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>仕入金額消費税額（外税）+仕入金額消費税額（内税）</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入伝票備考1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>仕入伝票備考2</summary>
		private string _supplierSlipNote2 = "";

		/// <summary>ＵＯＥリマーク１</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>ＵＯＥリマーク２</summary>
		private string _uoeRemark2 = "";

		/// <summary>仕入行番号</summary>
		private Int32 _stockRowNo;

		/// <summary>共通通番</summary>
		private Int64 _commonSeqNo;

		/// <summary>仕入明細通番</summary>
		private Int64 _stockSlipDtlNum;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品名称カナ</summary>
		private string _goodsNameKana = "";

		/// <summary>販売先コード</summary>
		private Int32 _salesCustomerCode;

		/// <summary>販売先略称</summary>
		private string _salesCustomerSnm = "";

		/// <summary>仕入数</summary>
		private Double _stockCount;

		/// <summary>仕入単価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>仕入金額（税抜き）</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>伝票情報と重複する為、ＤＤ名変更</remarks>
		private Int64 _dtl_StockPriceConsTax;


		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SupplierFormal
		/// <summary>仕入形式プロパティ</summary>
		/// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入形式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierFormal
		{
			get{return _supplierFormal;}
			set{_supplierFormal = value;}
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

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  DebitNLnkSuppSlipNo
		/// <summary>赤黒連結仕入伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤黒連結仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNLnkSuppSlipNo
		{
			get{return _debitNLnkSuppSlipNo;}
			set{_debitNLnkSuppSlipNo = value;}
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

		/// public propaty name  :  StockGoodsCd
		/// <summary>仕入商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</value>
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

		/// public propaty name  :  StockSectionCd
		/// <summary>仕入拠点コードプロパティ</summary>
		/// <value>文字型 売上を入力した拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSectionCd
		{
			get{return _stockSectionCd;}
			set{_stockSectionCd = value;}
		}

		/// public propaty name  :  StockAddUpSectionCd
		/// <summary>仕入計上拠点コードプロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpSectionCd
		{
			get{return _stockAddUpSectionCd;}
			set{_stockAddUpSectionCd = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  ArrivalGoodsDay
		/// <summary>入荷日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime ArrivalGoodsDay
		{
			get{return _arrivalGoodsDay;}
			set{_arrivalGoodsDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>仕入日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StockDate
		{
			get{return _stockDate;}
			set{_stockDate = value;}
		}

		/// public propaty name  :  StockAddUpADate
		/// <summary>仕入計上日付プロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StockAddUpADate
		{
			get{return _stockAddUpADate;}
			set{_stockAddUpADate = value;}
		}

		/// public propaty name  :  StockInputCode
		/// <summary>仕入入力者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  StockInputName
		/// <summary>仕入入力者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputName
		{
			get{return _stockInputName;}
			set{_stockInputName = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>仕入担当者コードプロパティ</summary>
		/// <value>発注者をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
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

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  PayeeSnm
		/// <summary>支払先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeSnm
		{
			get{return _payeeSnm;}
			set{_payeeSnm = value;}
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

		/// public propaty name  :  SupplierNm1
		/// <summary>仕入先名1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
		}

		/// public propaty name  :  SupplierNm2
		/// <summary>仕入先名2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm2
		{
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
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

		/// public propaty name  :  StockTotalPrice
		/// <summary>仕入金額合計プロパティ</summary>
		/// <value>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTotalPrice
		{
			get{return _stockTotalPrice;}
			set{_stockTotalPrice = value;}
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

		/// public propaty name  :  StockPriceConsTax
		/// <summary>仕入金額消費税額プロパティ</summary>
		/// <value>仕入金額消費税額（外税）+仕入金額消費税額（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
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

		/// public propaty name  :  SupplierSlipNote2
		/// <summary>仕入伝票備考2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票備考2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSlipNote2
		{
			get{return _supplierSlipNote2;}
			set{_supplierSlipNote2 = value;}
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

		/// public propaty name  :  CommonSeqNo
		/// <summary>共通通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   共通通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 CommonSeqNo
		{
			get{return _commonSeqNo;}
			set{_commonSeqNo = value;}
		}

		/// public propaty name  :  StockSlipDtlNum
		/// <summary>仕入明細通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSlipDtlNum
		{
			get{return _stockSlipDtlNum;}
			set{_stockSlipDtlNum = value;}
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

		/// public propaty name  :  GoodsNameKana
		/// <summary>商品名称カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  SalesCustomerCode
		/// <summary>販売先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCustomerCode
		{
			get{return _salesCustomerCode;}
			set{_salesCustomerCode = value;}
		}

		/// public propaty name  :  SalesCustomerSnm
		/// <summary>販売先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesCustomerSnm
		{
			get{return _salesCustomerSnm;}
			set{_salesCustomerSnm = value;}
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

		/// public propaty name  :  Dtl_StockPriceConsTax
		/// <summary>仕入金額消費税額プロパティ</summary>
		/// <value>伝票情報と重複する為、ＤＤ名変更</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Dtl_StockPriceConsTax
		{
			get{return _dtl_StockPriceConsTax;}
			set{_dtl_StockPriceConsTax = value;}
		}


		/// <summary>
		/// 仕入先元帳（仕入明細）抽出結果ワークワークコンストラクタ
		/// </summary>
		/// <returns>LedgerStockDetailWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   LedgerStockDetailWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public LedgerStockDetailWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>LedgerStockDetailWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   LedgerStockDetailWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class LedgerStockDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerStockDetailWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  LedgerStockDetailWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is LedgerStockDetailWork || graph is ArrayList || graph is LedgerStockDetailWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(LedgerStockDetailWork).FullName));

            if (graph != null && graph is LedgerStockDetailWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.LedgerStockDetailWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is LedgerStockDetailWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((LedgerStockDetailWork[])graph).Length;
            }
            else if (graph is LedgerStockDetailWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //赤黒連結仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkSuppSlipNo
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //仕入計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //仕入入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //仕入入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額小計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //仕入伝票備考1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //仕入伝票備考2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //仕入行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //販売先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //販売先略称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //Dtl_StockPriceConsTax


            serInfo.Serialize(writer, serInfo);
            if (graph is LedgerStockDetailWork)
            {
                LedgerStockDetailWork temp = (LedgerStockDetailWork)graph;

                SetLedgerStockDetailWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is LedgerStockDetailWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((LedgerStockDetailWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (LedgerStockDetailWork temp in lst)
                {
                    SetLedgerStockDetailWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// LedgerStockDetailWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  LedgerStockDetailWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerStockDetailWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetLedgerStockDetailWork(System.IO.BinaryWriter writer, LedgerStockDetailWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //赤黒連結仕入伝票番号
            writer.Write(temp.DebitNLnkSuppSlipNo);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //仕入計上拠点コード
            writer.Write(temp.StockAddUpSectionCd);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //入荷日
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入計上日付
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //仕入入力者コード
            writer.Write(temp.StockInputCode);
            //仕入入力者名称
            writer.Write(temp.StockInputName);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入金額小計
            writer.Write(temp.StockSubttlPrice);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //仕入伝票備考1
            writer.Write(temp.SupplierSlipNote1);
            //仕入伝票備考2
            writer.Write(temp.SupplierSlipNote2);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //仕入行番号
            writer.Write(temp.StockRowNo);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //販売先コード
            writer.Write(temp.SalesCustomerCode);
            //販売先略称
            writer.Write(temp.SalesCustomerSnm);
            //仕入数
            writer.Write(temp.StockCount);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額消費税額
            writer.Write(temp.Dtl_StockPriceConsTax);

        }

        /// <summary>
        ///  LedgerStockDetailWorkインスタンス取得
        /// </summary>
        /// <returns>LedgerStockDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerStockDetailWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private LedgerStockDetailWork GetLedgerStockDetailWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            LedgerStockDetailWork temp = new LedgerStockDetailWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //赤黒連結仕入伝票番号
            temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //仕入計上拠点コード
            temp.StockAddUpSectionCd = reader.ReadString();
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //入荷日
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入計上日付
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //仕入入力者コード
            temp.StockInputCode = reader.ReadString();
            //仕入入力者名称
            temp.StockInputName = reader.ReadString();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //仕入伝票備考1
            temp.SupplierSlipNote1 = reader.ReadString();
            //仕入伝票備考2
            temp.SupplierSlipNote2 = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //仕入行番号
            temp.StockRowNo = reader.ReadInt32();
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //販売先コード
            temp.SalesCustomerCode = reader.ReadInt32();
            //販売先略称
            temp.SalesCustomerSnm = reader.ReadString();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額消費税額
            temp.Dtl_StockPriceConsTax = reader.ReadInt64();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
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
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>LedgerStockDetailWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerStockDetailWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                LedgerStockDetailWork temp = GetLedgerStockDetailWork(reader, serInfo);
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
                    retValue = (LedgerStockDetailWork[])lst.ToArray(typeof(LedgerStockDetailWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
