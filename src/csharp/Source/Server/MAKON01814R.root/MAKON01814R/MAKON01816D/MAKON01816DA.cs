using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    //--- DEL 2008/06/03 M.Kubota --->>>
    #region [DC.NSの段階で使われていないので削除]
#if false
    /// public class name:   IOWriteMASIRNewEntryWork
	/// <summary>
	///                      仕入データ(IOWriteMASIRNewEntry)ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入データ(IOWriteMASIRNewEntry)ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRNewEntryWork : IFileHeader
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

		/// <summary>仕入形式</summary>
		/// <remarks>0:発注,1:仕入,2:入荷　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		/// <remarks>発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

		/// <summary>課コード</summary>
		private Int32 _minSectionCode;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>赤黒連結仕入伝票番号</summary>
		private Int32 _debitNLnkSuppSlipNo;

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>買掛区分</summary>
		/// <remarks>0:買掛なし,1:買掛</remarks>
		private Int32 _accPayDivCd;

		/// <summary>受託計上仕入区分</summary>
		/// <remarks>0:通常仕入,1:受託計上仕入,2:売上時自動受託計上仕入</remarks>
		private Int32 _trustAddUpSpCd;

		/// <summary>仕入拠点コード</summary>
		private string _stockSectionCd = "";

		/// <summary>仕入計上拠点コード</summary>
		/// <remarks>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</remarks>
		private string _stockAddUpSectionCd = "";

		/// <summary>更新年月日</summary>
		private DateTime _updateDate;

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

		/// <summary>仕入入力者コード</summary>
		private string _stockInputCode = "";

		/// <summary>仕入入力者名称</summary>
		private string _stockInputName = "";

		/// <summary>入荷者コード</summary>
		private string _arrivalGoodsAgentCd = "";

		/// <summary>入荷者名称</summary>
		private string _arrivalGoodsAgentNm = "";

		/// <summary>仕入担当者コード</summary>
		private string _stockAgentCode = "";

		/// <summary>仕入担当者名称</summary>
		private string _stockAgentName = "";

		/// <summary>仕入先総額表示方法区分</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _suppTtlAmntDspWayCd;

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
		private Int64 _ttlItdedStcTaxFree;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>内税の場合:税込み/105*5,外税の場合:税抜き*5/100</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>仕入金額消費税額（内税）</summary>
		private Int64 _stckPrcConsTaxInclu;

		/// <summary>仕入値引金額計（税抜き）</summary>
		private Int64 _stckDisTtlTaxExc;

		/// <summary>仕入値引金額計（内税）</summary>
		private Int64 _stckDisTtlTaxInclu;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>返品理由コード</summary>
		private Int32 _retGoodsReasonDiv;

		/// <summary>返品理由</summary>
		private string _retGoodsReason = "";

		/// <summary>仕入先消費税転嫁方式コード</summary>
		/// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入先消費税税率</summary>
		private Double _supplierConsTaxRate;

		/// <summary>端数処理区分</summary>
		/// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
		private Int32 _fractionProcCd;

		/// <summary>買掛消費税</summary>
		private Int64 _accPayConsTax;

		/// <summary>支払先コード</summary>
		/// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
		private Int32 _payeeCode;

		/// <summary>支払先名称1</summary>
		/// <remarks>支払対象となる得意先の得意先コード</remarks>
		private string _payeeName1 = "";

		/// <summary>支払先名称2</summary>
		private string _payeename2 = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>諸口コード</summary>
		/// <remarks>0:正式仕入先,1:諸口仕入先</remarks>
		private Int32 _outputNameCode;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入伝票備考1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>仕入伝票備考2</summary>
		private string _supplierSlipNote2 = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>ＥＤＩ送信日</summary>
		/// <remarks>YYYYMMDD （ErectricDataInterface）</remarks>
		private DateTime _ediSendDate;

		/// <summary>ＥＤＩ取込日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ediTakeInDate;

		/// <summary>テキスト抽出日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _textExtraDate;

		/// <summary>財務連動抽出日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _linkExtraDate;

		/// <summary>ＵＯＥリマーク１</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>ＵＯＥリマーク２</summary>
		private string _uoeRemark2 = "";

		/// <summary>仕入伝票発行日</summary>
		/// <remarks>仮仕入では仮仕入伝票発行日</remarks>
		private DateTime _stockSlipPrintDate;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>仕入形式とセットで伝票タイプ管理マスタを参照　（仮仕入用）</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>業種コード</summary>
		private Int32 _businessTypeCode;

		/// <summary>業種名称</summary>
		private string _businessTypeName = "";

		/// <summary>消込フラグ</summary>
		/// <remarks>0:残あり 9:残無し　（発注、仮仕入にて使用）</remarks>
		private Int32 _reconcileFlag;

		/// <summary>仕入端数処理区分</summary>
		/// <remarks>0:処理しない･･･つづきあり（※）仕入明細</remarks>
		private Int32 _stockFractionProcCd;


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

		/// public propaty name  :  SupplierFormal
		/// <summary>仕入形式プロパティ</summary>
		/// <value>0:発注,1:仕入,2:入荷　（受注ステータス）</value>
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
		/// <value>発注伝票番号、仕入伝票番号、仮仕入伝票番号を兼ねる</value>
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

		/// public propaty name  :  SubSectionCode
		/// <summary>部門コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部門コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubSectionCode
		{
			get{return _subSectionCode;}
			set{_subSectionCode = value;}
		}

		/// public propaty name  :  MinSectionCode
		/// <summary>課コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MinSectionCode
		{
			get{return _minSectionCode;}
			set{_minSectionCode = value;}
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
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</value>
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

		/// public propaty name  :  UpdateDate
		/// <summary>更新年月日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
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

		/// public propaty name  :  ArrivalGoodsAgentCd
		/// <summary>入荷者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ArrivalGoodsAgentCd
		{
			get{return _arrivalGoodsAgentCd;}
			set{_arrivalGoodsAgentCd = value;}
		}

		/// public propaty name  :  ArrivalGoodsAgentNm
		/// <summary>入荷者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ArrivalGoodsAgentNm
		{
			get{return _arrivalGoodsAgentNm;}
			set{_arrivalGoodsAgentNm = value;}
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

		/// public propaty name  :  TtlItdedStcTaxFree
		/// <summary>仕入非課税対象額合計プロパティ</summary>
		/// <value>非課税対象金額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStcTaxFree
		{
			get{return _ttlItdedStcTaxFree;}
			set{_ttlItdedStcTaxFree = value;}
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

		/// public propaty name  :  StckPrcConsTaxInclu
		/// <summary>仕入金額消費税額（内税）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額（内税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StckPrcConsTaxInclu
		{
			get{return _stckPrcConsTaxInclu;}
			set{_stckPrcConsTaxInclu = value;}
		}

		/// public propaty name  :  StckDisTtlTaxExc
		/// <summary>仕入値引金額計（税抜き）プロパティ</summary>
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

		/// public propaty name  :  StckDisTtlTaxInclu
		/// <summary>仕入値引金額計（内税）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引金額計（内税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StckDisTtlTaxInclu
		{
			get{return _stckDisTtlTaxInclu;}
			set{_stckDisTtlTaxInclu = value;}
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

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
		/// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
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

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
		/// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}

		/// public propaty name  :  AccPayConsTax
		/// <summary>買掛消費税プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   買掛消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AccPayConsTax
		{
			get{return _accPayConsTax;}
			set{_accPayConsTax = value;}
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

		/// public propaty name  :  OutputNameCode
		/// <summary>諸口コードプロパティ</summary>
		/// <value>0:正式仕入先,1:諸口仕入先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   諸口コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutputNameCode
		{
			get{return _outputNameCode;}
			set{_outputNameCode = value;}
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

		/// public propaty name  :  EdiSendDate
		/// <summary>ＥＤＩ送信日プロパティ</summary>
		/// <value>YYYYMMDD （ErectricDataInterface）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ送信日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EdiSendDate
		{
			get{return _ediSendDate;}
			set{_ediSendDate = value;}
		}

		/// public propaty name  :  EdiTakeInDate
		/// <summary>ＥＤＩ取込日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ取込日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdiTakeInDate
		{
			get{return _ediTakeInDate;}
			set{_ediTakeInDate = value;}
		}

		/// public propaty name  :  TextExtraDate
		/// <summary>テキスト抽出日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   テキスト抽出日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TextExtraDate
		{
			get{return _textExtraDate;}
			set{_textExtraDate = value;}
		}

		/// public propaty name  :  LinkExtraDate
		/// <summary>財務連動抽出日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   財務連動抽出日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LinkExtraDate
		{
			get{return _linkExtraDate;}
			set{_linkExtraDate = value;}
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

		/// public propaty name  :  StockSlipPrintDate
		/// <summary>仕入伝票発行日プロパティ</summary>
		/// <value>仮仕入では仮仕入伝票発行日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票発行日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StockSlipPrintDate
		{
			get{return _stockSlipPrintDate;}
			set{_stockSlipPrintDate = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>仕入形式とセットで伝票タイプ管理マスタを参照　（仮仕入用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipPrtSetPaperId
		{
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
		}

		/// public propaty name  :  BusinessTypeCode
		/// <summary>業種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BusinessTypeCode
		{
			get{return _businessTypeCode;}
			set{_businessTypeCode = value;}
		}

		/// public propaty name  :  BusinessTypeName
		/// <summary>業種名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BusinessTypeName
		{
			get{return _businessTypeName;}
			set{_businessTypeName = value;}
		}

		/// public propaty name  :  ReconcileFlag
		/// <summary>消込フラグプロパティ</summary>
		/// <value>0:残あり 9:残無し　（発注、仮仕入にて使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消込フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ReconcileFlag
		{
			get{return _reconcileFlag;}
			set{_reconcileFlag = value;}
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


		/// <summary>
		/// 仕入データ(IOWriteMASIRNewEntry)ワークコンストラクタ
		/// </summary>
		/// <returns>IOWriteMASIRNewEntryWorkWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   IOWriteMASIRNewEntryWorkWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public IOWriteMASIRNewEntryWork()
		{
		}

	}

/// <summary>
///  Ver5.10.1.0用のカスタムシライアライザです。
/// </summary>
/// <returns>IOWriteMASIRNewEntryWorkWorkクラスのインスタンス(object)</returns>
/// <remarks>
/// <br>Note　　　　　　 :   IOWriteMASIRNewEntryWorkWorkクラスのカスタムシリアライザを定義します</br>
/// <br>Programer        :   自動生成</br>
/// </remarks>
public class IOWriteMASIRNewEntryWorkWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
	#region ICustomSerializationSurrogate メンバ
	
	/// <summary>
	///  Ver5.10.1.0用のカスタムシリアライザです
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   IOWriteMASIRNewEntryWorkWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  IOWriteMASIRNewEntryWorkWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is IOWriteMASIRNewEntryWork || graph is ArrayList || graph is IOWriteMASIRNewEntryWork[]) )
			throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(IOWriteMASIRNewEntryWork).FullName ) );

		if( graph != null && graph is IOWriteMASIRNewEntryWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRNewEntryWork" );

		//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		int occurrence = 0;     //一般にゼロの場合もありえます
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is IOWriteMASIRNewEntryWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((IOWriteMASIRNewEntryWork[])graph).Length;
		}
		else if( graph is IOWriteMASIRNewEntryWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //繰り返し数	

		//作成日時
		serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
		//更新日時
		serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
		//企業コード
		serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		//GUID
		serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
		//更新従業員コード
		serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
		//更新アセンブリID1
		serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
		//更新アセンブリID2
		serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
		//論理削除区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
		//仕入形式
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierFormal
		//仕入伝票番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierSlipNo
		//拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
		//部門コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //SubSectionCode
		//課コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //MinSectionCode
		//赤伝区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //DebitNoteDiv
		//赤黒連結仕入伝票番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //DebitNLnkSuppSlipNo
		//仕入伝票区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierSlipCd
		//仕入商品区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockGoodsCd
		//買掛区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //AccPayDivCd
		//受託計上仕入区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //TrustAddUpSpCd
		//仕入拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //StockSectionCd
		//仕入計上拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //StockAddUpSectionCd
		//更新年月日
		serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateDate
		//支払日付
		serInfo.MemberInfo.Add( typeof(Int32) ); //PaymentDate
		//入力日
		serInfo.MemberInfo.Add( typeof(Int32) ); //InputDay
		//入荷日
		serInfo.MemberInfo.Add( typeof(Int32) ); //ArrivalGoodsDay
		//仕入日
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockDate
		//仕入計上日付
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockAddUpADate
		//仕入入力者コード
		serInfo.MemberInfo.Add( typeof(string) ); //StockInputCode
		//仕入入力者名称
		serInfo.MemberInfo.Add( typeof(string) ); //StockInputName
		//入荷者コード
		serInfo.MemberInfo.Add( typeof(string) ); //ArrivalGoodsAgentCd
		//入荷者名称
		serInfo.MemberInfo.Add( typeof(string) ); //ArrivalGoodsAgentNm
		//仕入担当者コード
		serInfo.MemberInfo.Add( typeof(string) ); //StockAgentCode
		//仕入担当者名称
		serInfo.MemberInfo.Add( typeof(string) ); //StockAgentName
		//仕入先総額表示方法区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //SuppTtlAmntDspWayCd
		//仕入金額合計
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTotalPrice
		//仕入金額小計
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockSubttlPrice
		//仕入金額計（税込み）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtlPricTaxInc
		//仕入金額計（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtlPricTaxExc
		//仕入非課税対象額合計
		serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedStcTaxFree
		//仕入金額消費税額
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockPriceConsTax
		//仕入金額消費税額（内税）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StckPrcConsTaxInclu
		//仕入値引金額計（税抜き）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StckDisTtlTaxExc
		//仕入値引金額計（内税）
		serInfo.MemberInfo.Add( typeof(Int64) ); //StckDisTtlTaxInclu
		//消費税調整額
		serInfo.MemberInfo.Add( typeof(Int64) ); //TaxAdjust
		//残高調整額
		serInfo.MemberInfo.Add( typeof(Int64) ); //BalanceAdjust
		//返品理由コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //RetGoodsReasonDiv
		//返品理由
		serInfo.MemberInfo.Add( typeof(string) ); //RetGoodsReason
		//仕入先消費税転嫁方式コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //SuppCTaxLayCd
		//仕入先消費税税率
		serInfo.MemberInfo.Add( typeof(Double) ); //SupplierConsTaxRate
		//端数処理区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //FractionProcCd
		//買掛消費税
		serInfo.MemberInfo.Add( typeof(Int64) ); //AccPayConsTax
		//支払先コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //PayeeCode
		//支払先名称1
		serInfo.MemberInfo.Add( typeof(string) ); //PayeeName1
		//支払先名称2
		serInfo.MemberInfo.Add( typeof(string) ); //Payeename2
		//得意先コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		//得意先名称
		serInfo.MemberInfo.Add( typeof(string) ); //CustomerName
		//得意先名称2
		serInfo.MemberInfo.Add( typeof(string) ); //CustomerName2
		//諸口コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //OutputNameCode
		//相手先伝票番号
		serInfo.MemberInfo.Add( typeof(string) ); //PartySaleSlipNum
		//仕入伝票備考1
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierSlipNote1
		//仕入伝票備考2
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierSlipNote2
		//倉庫コード
		serInfo.MemberInfo.Add( typeof(string) ); //WarehouseCode
		//倉庫名称
		serInfo.MemberInfo.Add( typeof(string) ); //WarehouseName
		//ＥＤＩ送信日
		serInfo.MemberInfo.Add( typeof(Int32) ); //EdiSendDate
		//ＥＤＩ取込日
		serInfo.MemberInfo.Add( typeof(Int32) ); //EdiTakeInDate
		//テキスト抽出日
		serInfo.MemberInfo.Add( typeof(Int32) ); //TextExtraDate
		//財務連動抽出日
		serInfo.MemberInfo.Add( typeof(Int32) ); //LinkExtraDate
		//ＵＯＥリマーク１
		serInfo.MemberInfo.Add( typeof(string) ); //UoeRemark1
		//ＵＯＥリマーク２
		serInfo.MemberInfo.Add( typeof(string) ); //UoeRemark2
		//仕入伝票発行日
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockSlipPrintDate
		//伝票印刷設定用帳票ID
		serInfo.MemberInfo.Add( typeof(string) ); //SlipPrtSetPaperId
		//業種コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //BusinessTypeCode
		//業種名称
		serInfo.MemberInfo.Add( typeof(string) ); //BusinessTypeName
		//消込フラグ
		serInfo.MemberInfo.Add( typeof(Int32) ); //ReconcileFlag
		//仕入端数処理区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockFractionProcCd

			
		serInfo.Serialize( writer, serInfo );
		if( graph is IOWriteMASIRNewEntryWork )
		{
			IOWriteMASIRNewEntryWork temp = (IOWriteMASIRNewEntryWork)graph;

			SetIOWriteMASIRNewEntryWorkWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is IOWriteMASIRNewEntryWork[])
			{
				lst = new ArrayList();
				lst.AddRange((IOWriteMASIRNewEntryWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(IOWriteMASIRNewEntryWork temp in lst)
			{
				SetIOWriteMASIRNewEntryWorkWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// IOWriteMASIRNewEntryWorkWorkメンバ数(publicプロパティ数)
	/// </summary>
	private const int currentMemberCount = 75;
		
	/// <summary>
	///  IOWriteMASIRNewEntryWorkWorkインスタンス書き込み
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   IOWriteMASIRNewEntryWorkWorkのインスタンスを書き込み</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	private void SetIOWriteMASIRNewEntryWorkWork( System.IO.BinaryWriter writer, IOWriteMASIRNewEntryWork temp )
	{
		//作成日時
		writer.Write( (Int64)temp.CreateDateTime.Ticks );
		//更新日時
		writer.Write( (Int64)temp.UpdateDateTime.Ticks );
		//企業コード
		writer.Write( temp.EnterpriseCode );
		//GUID
		byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
		writer.Write( fileHeaderGuidArray.Length );
		writer.Write( temp.FileHeaderGuid.ToByteArray() );
		//更新従業員コード
		writer.Write( temp.UpdEmployeeCode );
		//更新アセンブリID1
		writer.Write( temp.UpdAssemblyId1 );
		//更新アセンブリID2
		writer.Write( temp.UpdAssemblyId2 );
		//論理削除区分
		writer.Write( temp.LogicalDeleteCode );
		//仕入形式
		writer.Write( temp.SupplierFormal );
		//仕入伝票番号
		writer.Write( temp.SupplierSlipNo );
		//拠点コード
		writer.Write( temp.SectionCode );
		//部門コード
		writer.Write( temp.SubSectionCode );
		//課コード
		writer.Write( temp.MinSectionCode );
		//赤伝区分
		writer.Write( temp.DebitNoteDiv );
		//赤黒連結仕入伝票番号
		writer.Write( temp.DebitNLnkSuppSlipNo );
		//仕入伝票区分
		writer.Write( temp.SupplierSlipCd );
		//仕入商品区分
		writer.Write( temp.StockGoodsCd );
		//買掛区分
		writer.Write( temp.AccPayDivCd );
		//受託計上仕入区分
		writer.Write( temp.TrustAddUpSpCd );
		//仕入拠点コード
		writer.Write( temp.StockSectionCd );
		//仕入計上拠点コード
		writer.Write( temp.StockAddUpSectionCd );
		//更新年月日
		writer.Write( (Int64)temp.UpdateDate.Ticks );
		//支払日付
		writer.Write( (Int64)temp.PaymentDate.Ticks );
		//入力日
		writer.Write( (Int64)temp.InputDay.Ticks );
		//入荷日
		writer.Write( (Int64)temp.ArrivalGoodsDay.Ticks );
		//仕入日
		writer.Write( (Int64)temp.StockDate.Ticks );
		//仕入計上日付
		writer.Write( (Int64)temp.StockAddUpADate.Ticks );
		//仕入入力者コード
		writer.Write( temp.StockInputCode );
		//仕入入力者名称
		writer.Write( temp.StockInputName );
		//入荷者コード
		writer.Write( temp.ArrivalGoodsAgentCd );
		//入荷者名称
		writer.Write( temp.ArrivalGoodsAgentNm );
		//仕入担当者コード
		writer.Write( temp.StockAgentCode );
		//仕入担当者名称
		writer.Write( temp.StockAgentName );
		//仕入先総額表示方法区分
		writer.Write( temp.SuppTtlAmntDspWayCd );
		//仕入金額合計
		writer.Write( temp.StockTotalPrice );
		//仕入金額小計
		writer.Write( temp.StockSubttlPrice );
		//仕入金額計（税込み）
		writer.Write( temp.StockTtlPricTaxInc );
		//仕入金額計（税抜き）
		writer.Write( temp.StockTtlPricTaxExc );
		//仕入非課税対象額合計
		writer.Write( temp.TtlItdedStcTaxFree );
		//仕入金額消費税額
		writer.Write( temp.StockPriceConsTax );
		//仕入金額消費税額（内税）
		writer.Write( temp.StckPrcConsTaxInclu );
		//仕入値引金額計（税抜き）
		writer.Write( temp.StckDisTtlTaxExc );
		//仕入値引金額計（内税）
		writer.Write( temp.StckDisTtlTaxInclu );
		//消費税調整額
		writer.Write( temp.TaxAdjust );
		//残高調整額
		writer.Write( temp.BalanceAdjust );
		//返品理由コード
		writer.Write( temp.RetGoodsReasonDiv );
		//返品理由
		writer.Write( temp.RetGoodsReason );
		//仕入先消費税転嫁方式コード
		writer.Write( temp.SuppCTaxLayCd );
		//仕入先消費税税率
		writer.Write( temp.SupplierConsTaxRate );
		//端数処理区分
		writer.Write( temp.FractionProcCd );
		//買掛消費税
		writer.Write( temp.AccPayConsTax );
		//支払先コード
		writer.Write( temp.PayeeCode );
		//支払先名称1
		writer.Write( temp.PayeeName1 );
		//支払先名称2
		writer.Write( temp.Payeename2 );
		//得意先コード
		writer.Write( temp.CustomerCode );
		//得意先名称
		writer.Write( temp.CustomerName );
		//得意先名称2
		writer.Write( temp.CustomerName2 );
		//諸口コード
		writer.Write( temp.OutputNameCode );
		//相手先伝票番号
		writer.Write( temp.PartySaleSlipNum );
		//仕入伝票備考1
		writer.Write( temp.SupplierSlipNote1 );
		//仕入伝票備考2
		writer.Write( temp.SupplierSlipNote2 );
		//倉庫コード
		writer.Write( temp.WarehouseCode );
		//倉庫名称
		writer.Write( temp.WarehouseName );
		//ＥＤＩ送信日
		writer.Write( (Int64)temp.EdiSendDate.Ticks );
		//ＥＤＩ取込日
		writer.Write( temp.EdiTakeInDate );
		//テキスト抽出日
		writer.Write( (Int64)temp.TextExtraDate.Ticks );
		//財務連動抽出日
		writer.Write( temp.LinkExtraDate );
		//ＵＯＥリマーク１
		writer.Write( temp.UoeRemark1 );
		//ＵＯＥリマーク２
		writer.Write( temp.UoeRemark2 );
		//仕入伝票発行日
		writer.Write( (Int64)temp.StockSlipPrintDate.Ticks );
		//伝票印刷設定用帳票ID
		writer.Write( temp.SlipPrtSetPaperId );
		//業種コード
		writer.Write( temp.BusinessTypeCode );
		//業種名称
		writer.Write( temp.BusinessTypeName );
		//消込フラグ
		writer.Write( temp.ReconcileFlag );
		//仕入端数処理区分
		writer.Write( temp.StockFractionProcCd );

	}

	/// <summary>
	///  IOWriteMASIRNewEntryWorkWorkインスタンス取得
	/// </summary>
	/// <returns>IOWriteMASIRNewEntryWorkWorkクラスのインスタンス</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   IOWriteMASIRNewEntryWorkWorkのインスタンスを取得します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	private IOWriteMASIRNewEntryWork GetIOWriteMASIRNewEntryWorkWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0なので不要ですが、V5.1.0.1以降では
		// serInfo.MemberInfo.Count < currentMemberCount
		// のケースについての配慮が必要になります。

		IOWriteMASIRNewEntryWork temp = new IOWriteMASIRNewEntryWork();

		//作成日時
		temp.CreateDateTime = new DateTime(reader.ReadInt64());
		//更新日時
		temp.UpdateDateTime = new DateTime(reader.ReadInt64());
		//企業コード
		temp.EnterpriseCode = reader.ReadString();
		//GUID
		int lenOfFileHeaderGuidArray = reader.ReadInt32();
		byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
		temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
		//更新従業員コード
		temp.UpdEmployeeCode = reader.ReadString();
		//更新アセンブリID1
		temp.UpdAssemblyId1 = reader.ReadString();
		//更新アセンブリID2
		temp.UpdAssemblyId2 = reader.ReadString();
		//論理削除区分
		temp.LogicalDeleteCode = reader.ReadInt32();
		//仕入形式
		temp.SupplierFormal = reader.ReadInt32();
		//仕入伝票番号
		temp.SupplierSlipNo = reader.ReadInt32();
		//拠点コード
		temp.SectionCode = reader.ReadString();
		//部門コード
		temp.SubSectionCode = reader.ReadInt32();
		//課コード
		temp.MinSectionCode = reader.ReadInt32();
		//赤伝区分
		temp.DebitNoteDiv = reader.ReadInt32();
		//赤黒連結仕入伝票番号
		temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
		//仕入伝票区分
		temp.SupplierSlipCd = reader.ReadInt32();
		//仕入商品区分
		temp.StockGoodsCd = reader.ReadInt32();
		//買掛区分
		temp.AccPayDivCd = reader.ReadInt32();
		//受託計上仕入区分
		temp.TrustAddUpSpCd = reader.ReadInt32();
		//仕入拠点コード
		temp.StockSectionCd = reader.ReadString();
		//仕入計上拠点コード
		temp.StockAddUpSectionCd = reader.ReadString();
		//更新年月日
		temp.UpdateDate = new DateTime(reader.ReadInt64());
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
		//仕入入力者コード
		temp.StockInputCode = reader.ReadString();
		//仕入入力者名称
		temp.StockInputName = reader.ReadString();
		//入荷者コード
		temp.ArrivalGoodsAgentCd = reader.ReadString();
		//入荷者名称
		temp.ArrivalGoodsAgentNm = reader.ReadString();
		//仕入担当者コード
		temp.StockAgentCode = reader.ReadString();
		//仕入担当者名称
		temp.StockAgentName = reader.ReadString();
		//仕入先総額表示方法区分
		temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
		//仕入金額合計
		temp.StockTotalPrice = reader.ReadInt64();
		//仕入金額小計
		temp.StockSubttlPrice = reader.ReadInt64();
		//仕入金額計（税込み）
		temp.StockTtlPricTaxInc = reader.ReadInt64();
		//仕入金額計（税抜き）
		temp.StockTtlPricTaxExc = reader.ReadInt64();
		//仕入非課税対象額合計
		temp.TtlItdedStcTaxFree = reader.ReadInt64();
		//仕入金額消費税額
		temp.StockPriceConsTax = reader.ReadInt64();
		//仕入金額消費税額（内税）
		temp.StckPrcConsTaxInclu = reader.ReadInt64();
		//仕入値引金額計（税抜き）
		temp.StckDisTtlTaxExc = reader.ReadInt64();
		//仕入値引金額計（内税）
		temp.StckDisTtlTaxInclu = reader.ReadInt64();
		//消費税調整額
		temp.TaxAdjust = reader.ReadInt64();
		//残高調整額
		temp.BalanceAdjust = reader.ReadInt64();
		//返品理由コード
		temp.RetGoodsReasonDiv = reader.ReadInt32();
		//返品理由
		temp.RetGoodsReason = reader.ReadString();
		//仕入先消費税転嫁方式コード
		temp.SuppCTaxLayCd = reader.ReadInt32();
		//仕入先消費税税率
		temp.SupplierConsTaxRate = reader.ReadDouble();
		//端数処理区分
		temp.FractionProcCd = reader.ReadInt32();
		//買掛消費税
		temp.AccPayConsTax = reader.ReadInt64();
		//支払先コード
		temp.PayeeCode = reader.ReadInt32();
		//支払先名称1
		temp.PayeeName1 = reader.ReadString();
		//支払先名称2
		temp.Payeename2 = reader.ReadString();
		//得意先コード
		temp.CustomerCode = reader.ReadInt32();
		//得意先名称
		temp.CustomerName = reader.ReadString();
		//得意先名称2
		temp.CustomerName2 = reader.ReadString();
		//諸口コード
		temp.OutputNameCode = reader.ReadInt32();
		//相手先伝票番号
		temp.PartySaleSlipNum = reader.ReadString();
		//仕入伝票備考1
		temp.SupplierSlipNote1 = reader.ReadString();
		//仕入伝票備考2
		temp.SupplierSlipNote2 = reader.ReadString();
		//倉庫コード
		temp.WarehouseCode = reader.ReadString();
		//倉庫名称
		temp.WarehouseName = reader.ReadString();
		//ＥＤＩ送信日
		temp.EdiSendDate = new DateTime(reader.ReadInt64());
		//ＥＤＩ取込日
		temp.EdiTakeInDate = reader.ReadInt32();
		//テキスト抽出日
		temp.TextExtraDate = new DateTime(reader.ReadInt64());
		//財務連動抽出日
		temp.LinkExtraDate = reader.ReadInt32();
		//ＵＯＥリマーク１
		temp.UoeRemark1 = reader.ReadString();
		//ＵＯＥリマーク２
		temp.UoeRemark2 = reader.ReadString();
		//仕入伝票発行日
		temp.StockSlipPrintDate = new DateTime(reader.ReadInt64());
		//伝票印刷設定用帳票ID
		temp.SlipPrtSetPaperId = reader.ReadString();
		//業種コード
		temp.BusinessTypeCode = reader.ReadInt32();
		//業種名称
		temp.BusinessTypeName = reader.ReadString();
		//消込フラグ
		temp.ReconcileFlag = reader.ReadInt32();
		//仕入端数処理区分
		temp.StockFractionProcCd = reader.ReadInt32();

			
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
	/// <returns>IOWriteMASIRNewEntryWorkWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   IOWriteMASIRNewEntryWorkWorkクラスのカスタムデシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			IOWriteMASIRNewEntryWork temp = GetIOWriteMASIRNewEntryWorkWork( reader, serInfo );
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
				retValue = (IOWriteMASIRNewEntryWork[])lst.ToArray(typeof(IOWriteMASIRNewEntryWork));
				break;
		}
		return retValue;
	}

	#endregion
}
#endif
    #endregion
    //--- DEL 2008/06/03 M.Kubota ---<<<
}
