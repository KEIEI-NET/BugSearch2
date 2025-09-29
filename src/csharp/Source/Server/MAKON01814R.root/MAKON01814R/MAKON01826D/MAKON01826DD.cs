using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockSlipNewEntryWork
	/// <summary>
	///                      仕入データ初期読込パラメータワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入データ初期読込パラメータワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSlipNewEntryWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>仕入形式</summary>
		/// <remarks>0:買取(仕入),1:受託</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		private Int32 _supplierSlipNo;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入拠点コード</summary>
		private string _stockSectionCd = "";

		/// <summary>仕入計上拠点コード</summary>
		/// <remarks>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</remarks>
		private string _stockAddUpSectionCd = "";

		/// <summary>仕入担当者コード</summary>
		private string _stockAgentCode = "";

		/// <summary>仕入担当者名称</summary>
		private string _stockAgentName = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>支払先コード</summary>
		/// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
		private Int32 _payeeCode;

		/// <summary>支払先名称1</summary>
		/// <remarks>支払対象となる得意先の得意先コード</remarks>
		private string _payeeName1 = "";

		/// <summary>支払先名称2</summary>
		private string _payeename2 = "";

		/// <summary>支払日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _paymentDate;

		/// <summary>入力日</summary>
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

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>買掛区分</summary>
		/// <remarks>0:買掛なし,1:買掛</remarks>
		private Int32 _accPayDivCd;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>赤黒連結仕入伝票番号</summary>
		private Int32 _debitNLnkSuppSlipNo;

		/// <summary>仕入金額合計</summary>
		/// <remarks>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>仕入金額小計</summary>
		/// <remarks>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>仕入金額計（税込み）</summary>
		/// <remarks>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>仕入金額計（税抜き）</summary>
		/// <remarks>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>仕入非課税対象額合計</summary>
		/// <remarks>非課税対象金額の集計</remarks>
		private Int64 _ttlItdedStockTaxFree;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>内税の場合:税込み/105*5,外税の場合:税抜き*5/100</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>仕入先消費税転嫁方式コード</summary>
		/// <remarks>端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入先消費税税率</summary>
		private Double _supplierConsTaxRate;

		/// <summary>仕入端数処理区分</summary>
		/// <remarks>0:処理しない･･･つづきあり（※）仕入明細</remarks>
		private Int32 _stockFractionProcCd;

		/// <summary>仕入先総額表示方法区分</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _suppTtlAmntDspWayCd;

		/// <summary>仕入伝票備考1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>仕入伝票備考2</summary>
		private string _supplierSlipNote2 = "";

		/// <summary>事業者コード</summary>
		/// <remarks>1～8999:提供分,9000～:ユーザー登録</remarks>
		private Int32 _carrierEpCode;

		/// <summary>事業者名称</summary>
		private string _carrierEpName = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整4:買掛用消費税調整,5:買掛用残高調整</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>受託計上仕入区分</summary>
		/// <remarks>0:通常仕入,1:受託計上仕入,2:売上時自動受託計上仕入</remarks>
		private Int32 _trustAddUpSpCd;

		/// <summary>返品理由コード</summary>
		private Int32 _retGoodsReasonDiv;

		/// <summary>返品理由</summary>
		private string _retGoodsReason = "";

		/// <summary>受注番号</summary>
		/// <remarks>売上・仕入同時作成時に格納される受注番号</remarks>
		private Int32 _acceptAnOrderNo;

		/// <summary>売上行番号</summary>
		/// <remarks>売上・仕入同時作成時に格納される売上行番号</remarks>
		private Int32 _salesRowNo;


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
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

		/// public propaty name  :  SupplierFormal
		/// <summary>仕入形式プロパティ</summary>
		/// <value>0:買取(仕入),1:受託</value>
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

		/// public propaty name  :  StockSectionCd
		/// <summary>仕入拠点コードプロパティ</summary>
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
		/// <value>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</value>
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

		/// public propaty name  :  StockAgentCode
		/// <summary>仕入担当者コードプロパティ</summary>
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

		/// public propaty name  :  CustomerName2
		/// <summary>得意先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName2
		{
			get{return _customerName2;}
			set{_customerName2 = value;}
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

		/// public propaty name  :  PayeeName1
		/// <summary>支払先名称1プロパティ</summary>
		/// <value>支払対象となる得意先の得意先コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName1
		{
			get{return _payeeName1;}
			set{_payeeName1 = value;}
		}

		/// public propaty name  :  Payeename2
		/// <summary>支払先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Payeename2
		{
			get{return _payeename2;}
			set{_payeename2 = value;}
		}

		/// public propaty name  :  PaymentDate
		/// <summary>支払日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PaymentDate
		{
			get{return _paymentDate;}
			set{_paymentDate = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日プロパティ</summary>
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

		/// public propaty name  :  AccPayDivCd
		/// <summary>買掛区分プロパティ</summary>
		/// <value>0:買掛なし,1:買掛</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   買掛区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AccPayDivCd
		{
			get{return _accPayDivCd;}
			set{_accPayDivCd = value;}
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

		/// public propaty name  :  TtlItdedStockTaxFree
		/// <summary>仕入非課税対象額合計プロパティ</summary>
		/// <value>非課税対象金額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStockTaxFree
		{
			get{return _ttlItdedStockTaxFree;}
			set{_ttlItdedStockTaxFree = value;}
		}

		/// public propaty name  :  StockPriceConsTax
		/// <summary>仕入金額消費税額プロパティ</summary>
		/// <value>内税の場合:税込み/105*5,外税の場合:税抜き*5/100</value>
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

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
		/// <value>端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppCTaxLayCd
		{
			get{return _suppCTaxLayCd;}
			set{_suppCTaxLayCd = value;}
		}

		/// public propaty name  :  SupplierConsTaxRate
		/// <summary>仕入先消費税税率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先消費税税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SupplierConsTaxRate
		{
			get{return _supplierConsTaxRate;}
			set{_supplierConsTaxRate = value;}
		}

		/// public propaty name  :  StockFractionProcCd
		/// <summary>仕入端数処理区分プロパティ</summary>
		/// <value>0:処理しない･･･つづきあり（※）仕入明細</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockFractionProcCd
		{
			get{return _stockFractionProcCd;}
			set{_stockFractionProcCd = value;}
		}

		/// public propaty name  :  SuppTtlAmntDspWayCd
		/// <summary>仕入先総額表示方法区分プロパティ</summary>
		/// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先総額表示方法区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppTtlAmntDspWayCd
		{
			get{return _suppTtlAmntDspWayCd;}
			set{_suppTtlAmntDspWayCd = value;}
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

		/// public propaty name  :  CarrierEpCode
		/// <summary>事業者コードプロパティ</summary>
		/// <value>1～8999:提供分,9000～:ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   事業者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarrierEpCode
		{
			get{return _carrierEpCode;}
			set{_carrierEpCode = value;}
		}

		/// public propaty name  :  CarrierEpName
		/// <summary>事業者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   事業者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarrierEpName
		{
			get{return _carrierEpName;}
			set{_carrierEpName = value;}
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

		/// public propaty name  :  StockGoodsCd
		/// <summary>仕入商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整4:買掛用消費税調整,5:買掛用残高調整</value>
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

		/// public propaty name  :  TaxAdjust
		/// <summary>消費税調整額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税調整額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TaxAdjust
		{
			get{return _taxAdjust;}
			set{_taxAdjust = value;}
		}

		/// public propaty name  :  BalanceAdjust
		/// <summary>残高調整額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残高調整額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 BalanceAdjust
		{
			get{return _balanceAdjust;}
			set{_balanceAdjust = value;}
		}

		/// public propaty name  :  TrustAddUpSpCd
		/// <summary>受託計上仕入区分プロパティ</summary>
		/// <value>0:通常仕入,1:受託計上仕入,2:売上時自動受託計上仕入</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受託計上仕入区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TrustAddUpSpCd
		{
			get{return _trustAddUpSpCd;}
			set{_trustAddUpSpCd = value;}
		}

		/// public propaty name  :  RetGoodsReasonDiv
		/// <summary>返品理由コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品理由コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RetGoodsReasonDiv
		{
			get{return _retGoodsReasonDiv;}
			set{_retGoodsReasonDiv = value;}
		}

		/// public propaty name  :  RetGoodsReason
		/// <summary>返品理由プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品理由プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RetGoodsReason
		{
			get{return _retGoodsReason;}
			set{_retGoodsReason = value;}
		}

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>受注番号プロパティ</summary>
		/// <value>売上・仕入同時作成時に格納される受注番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcceptAnOrderNo
		{
			get{return _acceptAnOrderNo;}
			set{_acceptAnOrderNo = value;}
		}

		/// public propaty name  :  SalesRowNo
		/// <summary>売上行番号プロパティ</summary>
		/// <value>売上・仕入同時作成時に格納される売上行番号</value>
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


		/// <summary>
		/// 仕入データ初期読込パラメータワークコンストラクタ
		/// </summary>
		/// <returns>StockSlipNewEntryWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipNewEntryWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSlipNewEntryWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockSlipNewEntryWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockSlipNewEntryWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockSlipNewEntryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipNewEntryWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockSlipNewEntryWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockSlipNewEntryWork || graph is ArrayList || graph is StockSlipNewEntryWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockSlipNewEntryWork).FullName));

            if (graph != null && graph is StockSlipNewEntryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSlipNewEntryWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockSlipNewEntryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockSlipNewEntryWork[])graph).Length;
            }
            else if (graph is StockSlipNewEntryWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //仕入計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称1
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName1
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //Payeename2
            //支払日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //買掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //赤黒連結仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkSuppSlipNo
            //仕入金額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //仕入金額小計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //仕入金額計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //仕入金額計（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //仕入非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStockTaxFree
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入先消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //仕入端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockFractionProcCd
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //仕入伝票備考1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //仕入伝票備考2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //事業者コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CarrierEpCode
            //事業者名称
            serInfo.MemberInfo.Add(typeof(string)); //CarrierEpName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //受託計上仕入区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TrustAddUpSpCd
            //返品理由コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //返品理由
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo


            serInfo.Serialize(writer, serInfo);
            if (graph is StockSlipNewEntryWork)
            {
                StockSlipNewEntryWork temp = (StockSlipNewEntryWork)graph;

                SetStockSlipNewEntryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockSlipNewEntryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockSlipNewEntryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockSlipNewEntryWork temp in lst)
                {
                    SetStockSlipNewEntryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockSlipNewEntryWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 55;

        /// <summary>
        ///  StockSlipNewEntryWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipNewEntryWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockSlipNewEntryWork(System.IO.BinaryWriter writer, StockSlipNewEntryWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //仕入計上拠点コード
            writer.Write(temp.StockAddUpSectionCd);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称1
            writer.Write(temp.PayeeName1);
            //支払先名称2
            writer.Write(temp.Payeename2);
            //支払日付
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //入荷日
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入計上日付
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //買掛区分
            writer.Write(temp.AccPayDivCd);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //赤黒連結仕入伝票番号
            writer.Write(temp.DebitNLnkSuppSlipNo);
            //仕入金額合計
            writer.Write(temp.StockTotalPrice);
            //仕入金額小計
            writer.Write(temp.StockSubttlPrice);
            //仕入金額計（税込み）
            writer.Write(temp.StockTtlPricTaxInc);
            //仕入金額計（税抜き）
            writer.Write(temp.StockTtlPricTaxExc);
            //仕入非課税対象額合計
            writer.Write(temp.TtlItdedStockTaxFree);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入先消費税税率
            writer.Write(temp.SupplierConsTaxRate);
            //仕入端数処理区分
            writer.Write(temp.StockFractionProcCd);
            //仕入先総額表示方法区分
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //仕入伝票備考1
            writer.Write(temp.SupplierSlipNote1);
            //仕入伝票備考2
            writer.Write(temp.SupplierSlipNote2);
            //事業者コード
            writer.Write(temp.CarrierEpCode);
            //事業者名称
            writer.Write(temp.CarrierEpName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //受託計上仕入区分
            writer.Write(temp.TrustAddUpSpCd);
            //返品理由コード
            writer.Write(temp.RetGoodsReasonDiv);
            //返品理由
            writer.Write(temp.RetGoodsReason);
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //売上行番号
            writer.Write(temp.SalesRowNo);

        }

        /// <summary>
        ///  StockSlipNewEntryWorkインスタンス取得
        /// </summary>
        /// <returns>StockSlipNewEntryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipNewEntryWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockSlipNewEntryWork GetStockSlipNewEntryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockSlipNewEntryWork temp = new StockSlipNewEntryWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //仕入計上拠点コード
            temp.StockAddUpSectionCd = reader.ReadString();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称1
            temp.PayeeName1 = reader.ReadString();
            //支払先名称2
            temp.Payeename2 = reader.ReadString();
            //支払日付
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //入荷日
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入計上日付
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //買掛区分
            temp.AccPayDivCd = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //赤黒連結仕入伝票番号
            temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
            //仕入金額合計
            temp.StockTotalPrice = reader.ReadInt64();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            //仕入金額計（税込み）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //仕入金額計（税抜き）
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //仕入非課税対象額合計
            temp.TtlItdedStockTaxFree = reader.ReadInt64();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入先消費税税率
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //仕入端数処理区分
            temp.StockFractionProcCd = reader.ReadInt32();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //仕入伝票備考1
            temp.SupplierSlipNote1 = reader.ReadString();
            //仕入伝票備考2
            temp.SupplierSlipNote2 = reader.ReadString();
            //事業者コード
            temp.CarrierEpCode = reader.ReadInt32();
            //事業者名称
            temp.CarrierEpName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //受託計上仕入区分
            temp.TrustAddUpSpCd = reader.ReadInt32();
            //返品理由コード
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //返品理由
            temp.RetGoodsReason = reader.ReadString();
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();


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
        /// <returns>StockSlipNewEntryWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSlipNewEntryWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockSlipNewEntryWork temp = GetStockSlipNewEntryWork(reader, serInfo);
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
                    retValue = (StockSlipNewEntryWork[])lst.ToArray(typeof(StockSlipNewEntryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
