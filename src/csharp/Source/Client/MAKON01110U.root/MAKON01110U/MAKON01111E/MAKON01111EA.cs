using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockSlip
	/// <summary>
	///                      仕入データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Genarated Date   :   2011/11/30</br>
    /// <br>Update Note      :   Redmine#8383</br>
	/// </remarks>
	public class StockSlip
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
		/// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

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

		/// <summary>買掛区分</summary>
		/// <remarks>0:買掛なし,1:買掛</remarks>
		private Int32 _accPayDivCd;

		/// <summary>仕入拠点コード</summary>
		private string _stockSectionCd = "";

		/// <summary>仕入計上拠点コード</summary>
		/// <remarks>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</remarks>
		private string _stockAddUpSectionCd = "";

		/// <summary>仕入伝票更新区分</summary>
		/// <remarks>0:未更新,1:更新あり</remarks>
		private Int32 _stockSlipUpdateCd;

		/// <summary>入力日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private DateTime _inputDay;

		/// <summary>入荷日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _arrivalGoodsDay;

		/// <summary>仕入日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockDate;

        // ----- ADD 2011/12/15 ------------->>>>>
        /// <summary>前回仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _preStockDate;
        // ----- ADD 2011/12/15 -------------<<<<<

		/// <summary>仕入計上日付</summary>
		/// <remarks>仕入計上日</remarks>
		private DateTime _stockAddUpADate;

		/// <summary>来勘区分</summary>
		/// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
		private Int32 _delayPaymentDiv;

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

		/// <summary>業種コード</summary>
		private Int32 _businessTypeCode;

		/// <summary>業種名称</summary>
		private string _businessTypeName = "";

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _salesAreaCode;

		/// <summary>販売エリア名称</summary>
		private string _salesAreaName = "";

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

		/// <summary>仕入先総額表示方法区分</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _suppTtlAmntDspWayCd;

		/// <summary>総額表示掛率適用区分</summary>
		/// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
		private Int32 _ttlAmntDispRateApy;

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

		/// <summary>仕入正価金額</summary>
		/// <remarks>値引前の税抜仕入金額</remarks>
		private Int64 _stockNetPrice;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>仕入金額消費税額（外税）+仕入金額消費税額（内税）</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>仕入外税対象額合計</summary>
		/// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
		private Int64 _ttlItdedStcOutTax;

		/// <summary>仕入内税対象額合計</summary>
		/// <remarks>内税対象金額の集計（税抜、値引含まず） </remarks>
		private Int64 _ttlItdedStcInTax;

		/// <summary>仕入非課税対象額合計</summary>
		/// <remarks>非課税対象金額の集計（値引含まず）</remarks>
		private Int64 _ttlItdedStcTaxFree;

		/// <summary>仕入金額消費税額（外税）</summary>
		/// <remarks>値引前の外税商品の消費税</remarks>
		private Int64 _stockOutTax;

		/// <summary>仕入金額消費税額（内税）</summary>
		/// <remarks>値引前の内税商品の消費税</remarks>
		private Int64 _stckPrcConsTaxInclu;

		/// <summary>仕入値引金額計（税抜き）</summary>
		/// <remarks>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</remarks>
		private Int64 _stckDisTtlTaxExc;

		/// <summary>仕入値引外税対象額合計</summary>
		/// <remarks>外税商品値引の外税対象額（税抜）</remarks>
		private Int64 _itdedStockDisOutTax;

		/// <summary>仕入値引内税対象額合計</summary>
		/// <remarks>内税商品値引の内税対象額（税抜）</remarks>
		private Int64 _itdedStockDisInTax;

		/// <summary>仕入値引非課税対象額合計</summary>
		/// <remarks>非課税商品値引の非課税対象額</remarks>
		private Int64 _itdedStockDisTaxFre;

		/// <summary>仕入値引消費税額（外税）</summary>
		/// <remarks>外税商品値引の消費税額</remarks>
		private Int64 _stockDisOutTax;

		/// <summary>仕入値引消費税額（内税）</summary>
		/// <remarks>内税商品値引の消費税額</remarks>
		private Int64 _stckDisTtlTaxInclu;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>仕入先消費税転嫁方式コード</summary>
		/// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入先消費税税率</summary>
		private Double _supplierConsTaxRate;

		/// <summary>買掛消費税</summary>
		private Int64 _accPayConsTax;

		/// <summary>仕入端数処理区分</summary>
		/// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
		private Int32 _stockFractionProcCd;

		/// <summary>自動支払区分</summary>
		/// <remarks>0:通常支払,1:自動支払</remarks>
		private Int32 _autoPayment;

		/// <summary>自動支払伝票番号</summary>
		/// <remarks>自動支払時の支払伝票番号</remarks>
		private Int32 _autoPaySlipNum;

		/// <summary>返品理由コード</summary>
		private Int32 _retGoodsReasonDiv;

		/// <summary>返品理由</summary>
		private string _retGoodsReason = "";

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>仕入伝票備考1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>仕入伝票備考2</summary>
		private string _supplierSlipNote2 = "";

        // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
        /// <summary>仕入伝票備考番号1</summary>
        private Int32 _supplierSlipNoteNo1;

        /// <summary>仕入伝票備考番号2</summary>
        private Int32 _supplierSlipNoteNo2;
        // ADD 2011/11/30 gezh redmine#8383 --------<<<<<

		/// <summary>明細行数</summary>
		/// <remarks>伝票内の明細の行数（諸費用明細は除く）</remarks>
		private Int32 _detailRowCount;

		/// <summary>ＥＤＩ送信日</summary>
		/// <remarks>YYYYMMDD （ErectricDataInterface）</remarks>
		private DateTime _ediSendDate;

		/// <summary>ＥＤＩ取込日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ediTakeInDate;

		/// <summary>ＵＯＥリマーク１</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>ＵＯＥリマーク２</summary>
		private string _uoeRemark2 = "";

		/// <summary>伝票発行区分</summary>
		/// <remarks>0:しない 1:する</remarks>
		private Int32 _slipPrintDivCd;

		/// <summary>伝票発行済区分</summary>
		/// <remarks>0:未発行 1:発行済</remarks>
		private Int32 _slipPrintFinishCd;

		/// <summary>仕入伝票発行日</summary>
		/// <remarks>入荷では入荷伝票発行日（発注書発行日もここを使用）</remarks>
		private DateTime _stockSlipPrintDate;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>伝票住所区分</summary>
		/// <remarks>1:得意先,2:納入先</remarks>
		private Int32 _slipAddressDiv;

		/// <summary>納品先コード</summary>
		private Int32 _addresseeCode;

		/// <summary>納品先名称</summary>
		private string _addresseeName = "";

		/// <summary>納品先名称2</summary>
		/// <remarks>追加(登録漏れ) 塩原</remarks>
		private string _addresseeName2 = "";

		/// <summary>納品先郵便番号</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseePostNo = "";

		/// <summary>納品先住所1(都道府県市区郡・町村・字)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeAddr1 = "";

		/// <summary>納品先住所3(番地)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeAddr3 = "";

		/// <summary>納品先住所4(アパート名称)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeAddr4 = "";

		/// <summary>納品先電話番号</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeTelNo = "";

		/// <summary>納品先FAX番号</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeFaxNo = "";

		/// <summary>直送区分</summary>
		/// <remarks>0:直送なし,1:直送あり　（発注書の直送先印字制御）</remarks>
		private Int32 _directSendingCd;

		/// <summary>仕入伝票区分(画面表示用)</summary>
		private Int32 _supplierSlipDisplay;

		/// <summary>仕入先掛率グループコード</summary>
		private Int32 _suppRateGrpCode;

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>入力モード</summary>
		/// <remarks>10:掛仕入,20:掛返品,30:現金仕入,40:現金返品</remarks>
		private Int32 _inputMode;

		/// <summary>支払先名称</summary>
		private string _payeeName = "";

		/// <summary>支払先名称2</summary>
		private string _payeeName2 = "";

		/// <summary>次回勘定開始日</summary>
		/// <remarks>01～31まで（省略可能）</remarks>
		private Int32 _nTimeCalcStDate;

		/// <summary>支払締日</summary>
		private Int32 _paymentTotalDay;

		/// <summary>定価原価更新区分</summary>
		private Int32 _priceCostUpdtDiv;

		/// <summary>部門名称</summary>
		private string _subSectionName = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>仕入拠点名称</summary>
		private string _stockSectionNm = "";

		/// <summary>仕入計上拠点名称</summary>
		private string _stockAddUpSectionNm = "";

		/// <summary>仕入先消費税転嫁方式名称</summary>
		/// <remarks>伝票単位、明細単位、請求単位</remarks>
		private string _suppCTaxLayMethodNm = "";


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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  StockSlipUpdateCd
		/// <summary>仕入伝票更新区分プロパティ</summary>
		/// <value>0:未更新,1:更新あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票更新区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSlipUpdateCd
		{
			get{return _stockSlipUpdateCd;}
			set{_stockSlipUpdateCd = value;}
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

		/// public propaty name  :  InputDayJpFormal
		/// <summary>入力日 和暦プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayJpInFormal
		/// <summary>入力日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdFormal
		/// <summary>入力日 西暦プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdInFormal
		/// <summary>入力日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _inputDay);}
			set{}
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

		/// public propaty name  :  ArrivalGoodsDayJpFormal
		/// <summary>入荷日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ArrivalGoodsDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _arrivalGoodsDay);}
			set{}
		}

		/// public propaty name  :  ArrivalGoodsDayJpInFormal
		/// <summary>入荷日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ArrivalGoodsDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _arrivalGoodsDay);}
			set{}
		}

		/// public propaty name  :  ArrivalGoodsDayAdFormal
		/// <summary>入荷日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ArrivalGoodsDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _arrivalGoodsDay);}
			set{}
		}

		/// public propaty name  :  ArrivalGoodsDayAdInFormal
		/// <summary>入荷日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ArrivalGoodsDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _arrivalGoodsDay);}
			set{}
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

        // ----- ADD 2011/12/15 ------------------------->>>>>
        /// public propaty name  :  PreStockDate
        /// <summary>前回仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PreStockDate
        {
            get { return _preStockDate; }
            set { _preStockDate = value; }
        }
        // ----- ADD 2011/12/15 -------------------------<<<<<

		/// public propaty name  :  StockDateJpFormal
		/// <summary>仕入日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _stockDate);}
			set{}
		}

		/// public propaty name  :  StockDateJpInFormal
		/// <summary>仕入日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _stockDate);}
			set{}
		}

		/// public propaty name  :  StockDateAdFormal
		/// <summary>仕入日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _stockDate);}
			set{}
		}

		/// public propaty name  :  StockDateAdInFormal
		/// <summary>仕入日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _stockDate);}
			set{}
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

		/// public propaty name  :  StockAddUpADateJpFormal
		/// <summary>仕入計上日付 和暦プロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpADateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _stockAddUpADate);}
			set{}
		}

		/// public propaty name  :  StockAddUpADateJpInFormal
		/// <summary>仕入計上日付 和暦(略)プロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpADateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _stockAddUpADate);}
			set{}
		}

		/// public propaty name  :  StockAddUpADateAdFormal
		/// <summary>仕入計上日付 西暦プロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpADateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _stockAddUpADate);}
			set{}
		}

		/// public propaty name  :  StockAddUpADateAdInFormal
		/// <summary>仕入計上日付 西暦(略)プロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpADateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _stockAddUpADate);}
			set{}
		}

		/// public propaty name  :  DelayPaymentDiv
		/// <summary>来勘区分プロパティ</summary>
		/// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   来勘区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DelayPaymentDiv
		{
			get{return _delayPaymentDiv;}
			set{_delayPaymentDiv = value;}
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

		/// public propaty name  :  SalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesAreaCode
		{
			get{return _salesAreaCode;}
			set{_salesAreaCode = value;}
		}

		/// public propaty name  :  SalesAreaName
		/// <summary>販売エリア名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリア名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesAreaName
		{
			get{return _salesAreaName;}
			set{_salesAreaName = value;}
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

		/// public propaty name  :  TtlAmntDispRateApy
		/// <summary>総額表示掛率適用区分プロパティ</summary>
		/// <value>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示掛率適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlAmntDispRateApy
		{
			get{return _ttlAmntDispRateApy;}
			set{_ttlAmntDispRateApy = value;}
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

		/// public propaty name  :  StockNetPrice
		/// <summary>仕入正価金額プロパティ</summary>
		/// <value>値引前の税抜仕入金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入正価金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockNetPrice
		{
			get{return _stockNetPrice;}
			set{_stockNetPrice = value;}
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

		/// public propaty name  :  TtlItdedStcOutTax
		/// <summary>仕入外税対象額合計プロパティ</summary>
		/// <value>外税対象金額の集計（税抜、値引含まず）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStcOutTax
		{
			get{return _ttlItdedStcOutTax;}
			set{_ttlItdedStcOutTax = value;}
		}

		/// public propaty name  :  TtlItdedStcInTax
		/// <summary>仕入内税対象額合計プロパティ</summary>
		/// <value>内税対象金額の集計（税抜、値引含まず） </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStcInTax
		{
			get{return _ttlItdedStcInTax;}
			set{_ttlItdedStcInTax = value;}
		}

		/// public propaty name  :  TtlItdedStcTaxFree
		/// <summary>仕入非課税対象額合計プロパティ</summary>
		/// <value>非課税対象金額の集計（値引含まず）</value>
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

		/// public propaty name  :  StockOutTax
		/// <summary>仕入金額消費税額（外税）プロパティ</summary>
		/// <value>値引前の外税商品の消費税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額（外税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockOutTax
		{
			get{return _stockOutTax;}
			set{_stockOutTax = value;}
		}

		/// public propaty name  :  StckPrcConsTaxInclu
		/// <summary>仕入金額消費税額（内税）プロパティ</summary>
		/// <value>値引前の内税商品の消費税</value>
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

		/// public propaty name  :  ItdedStockDisOutTax
		/// <summary>仕入値引外税対象額合計プロパティ</summary>
		/// <value>外税商品値引の外税対象額（税抜）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedStockDisOutTax
		{
			get{return _itdedStockDisOutTax;}
			set{_itdedStockDisOutTax = value;}
		}

		/// public propaty name  :  ItdedStockDisInTax
		/// <summary>仕入値引内税対象額合計プロパティ</summary>
		/// <value>内税商品値引の内税対象額（税抜）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedStockDisInTax
		{
			get{return _itdedStockDisInTax;}
			set{_itdedStockDisInTax = value;}
		}

		/// public propaty name  :  ItdedStockDisTaxFre
		/// <summary>仕入値引非課税対象額合計プロパティ</summary>
		/// <value>非課税商品値引の非課税対象額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedStockDisTaxFre
		{
			get{return _itdedStockDisTaxFre;}
			set{_itdedStockDisTaxFre = value;}
		}

		/// public propaty name  :  StockDisOutTax
		/// <summary>仕入値引消費税額（外税）プロパティ</summary>
		/// <value>外税商品値引の消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引消費税額（外税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockDisOutTax
		{
			get{return _stockDisOutTax;}
			set{_stockDisOutTax = value;}
		}

		/// public propaty name  :  StckDisTtlTaxInclu
		/// <summary>仕入値引消費税額（内税）プロパティ</summary>
		/// <value>内税商品値引の消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引消費税額（内税）プロパティ</br>
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

		/// public propaty name  :  StockFractionProcCd
		/// <summary>仕入端数処理区分プロパティ</summary>
		/// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
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

		/// public propaty name  :  AutoPayment
		/// <summary>自動支払区分プロパティ</summary>
		/// <value>0:通常支払,1:自動支払</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動支払区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoPayment
		{
			get{return _autoPayment;}
			set{_autoPayment = value;}
		}

		/// public propaty name  :  AutoPaySlipNum
		/// <summary>自動支払伝票番号プロパティ</summary>
		/// <value>自動支払時の支払伝票番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動支払伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoPaySlipNum
		{
			get{return _autoPaySlipNum;}
			set{_autoPaySlipNum = value;}
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

        // ADD 2011/11/30 gezh redmine#8383 ------------------------->>>>>
        /// public propaty name  :  SupplierSlipNoteNo1
        /// <summary>仕入伝票備考番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoteNo1
        {
            get { return _supplierSlipNoteNo1; }
            set { _supplierSlipNoteNo1 = value; }
        }

        /// public propaty name  :  SupplierSlipNoteNo2
        /// <summary>仕入伝票備考番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoteNo2
        {
            get { return _supplierSlipNoteNo2; }
            set { _supplierSlipNoteNo2 = value; }
        }
        // ADD 2011/11/30 gezh redmine#8383 -----------------------<<<<<

		/// public propaty name  :  DetailRowCount
		/// <summary>明細行数プロパティ</summary>
		/// <value>伝票内の明細の行数（諸費用明細は除く）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細行数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DetailRowCount
		{
			get{return _detailRowCount;}
			set{_detailRowCount = value;}
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

		/// public propaty name  :  EdiSendDateJpFormal
		/// <summary>ＥＤＩ送信日 和暦プロパティ</summary>
		/// <value>YYYYMMDD （ErectricDataInterface）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ送信日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiSendDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate);}
			set{}
		}

		/// public propaty name  :  EdiSendDateJpInFormal
		/// <summary>ＥＤＩ送信日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD （ErectricDataInterface）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ送信日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiSendDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate);}
			set{}
		}

		/// public propaty name  :  EdiSendDateAdFormal
		/// <summary>ＥＤＩ送信日 西暦プロパティ</summary>
		/// <value>YYYYMMDD （ErectricDataInterface）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ送信日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiSendDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate);}
			set{}
		}

		/// public propaty name  :  EdiSendDateAdInFormal
		/// <summary>ＥＤＩ送信日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD （ErectricDataInterface）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ送信日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiSendDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate);}
			set{}
		}

		/// public propaty name  :  EdiTakeInDate
		/// <summary>ＥＤＩ取込日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ取込日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EdiTakeInDate
		{
			get{return _ediTakeInDate;}
			set{_ediTakeInDate = value;}
		}

		/// public propaty name  :  EdiTakeInDateJpFormal
		/// <summary>ＥＤＩ取込日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ取込日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiTakeInDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate);}
			set{}
		}

		/// public propaty name  :  EdiTakeInDateJpInFormal
		/// <summary>ＥＤＩ取込日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ取込日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiTakeInDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate);}
			set{}
		}

		/// public propaty name  :  EdiTakeInDateAdFormal
		/// <summary>ＥＤＩ取込日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ取込日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiTakeInDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate);}
			set{}
		}

		/// public propaty name  :  EdiTakeInDateAdInFormal
		/// <summary>ＥＤＩ取込日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＥＤＩ取込日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdiTakeInDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate);}
			set{}
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

		/// public propaty name  :  SlipPrintDivCd
		/// <summary>伝票発行区分プロパティ</summary>
		/// <value>0:しない 1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipPrintDivCd
		{
			get{return _slipPrintDivCd;}
			set{_slipPrintDivCd = value;}
		}

		/// public propaty name  :  SlipPrintFinishCd
		/// <summary>伝票発行済区分プロパティ</summary>
		/// <value>0:未発行 1:発行済</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票発行済区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipPrintFinishCd
		{
			get{return _slipPrintFinishCd;}
			set{_slipPrintFinishCd = value;}
		}

		/// public propaty name  :  StockSlipPrintDate
		/// <summary>仕入伝票発行日プロパティ</summary>
		/// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
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

		/// public propaty name  :  StockSlipPrintDateJpFormal
		/// <summary>仕入伝票発行日 和暦プロパティ</summary>
		/// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票発行日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSlipPrintDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _stockSlipPrintDate);}
			set{}
		}

		/// public propaty name  :  StockSlipPrintDateJpInFormal
		/// <summary>仕入伝票発行日 和暦(略)プロパティ</summary>
		/// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票発行日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSlipPrintDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _stockSlipPrintDate);}
			set{}
		}

		/// public propaty name  :  StockSlipPrintDateAdFormal
		/// <summary>仕入伝票発行日 西暦プロパティ</summary>
		/// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票発行日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSlipPrintDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _stockSlipPrintDate);}
			set{}
		}

		/// public propaty name  :  StockSlipPrintDateAdInFormal
		/// <summary>仕入伝票発行日 西暦(略)プロパティ</summary>
		/// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票発行日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSlipPrintDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _stockSlipPrintDate);}
			set{}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）</value>
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

		/// public propaty name  :  SlipAddressDiv
		/// <summary>伝票住所区分プロパティ</summary>
		/// <value>1:得意先,2:納入先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票住所区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipAddressDiv
		{
			get{return _slipAddressDiv;}
			set{_slipAddressDiv = value;}
		}

		/// public propaty name  :  AddresseeCode
		/// <summary>納品先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddresseeCode
		{
			get{return _addresseeCode;}
			set{_addresseeCode = value;}
		}

		/// public propaty name  :  AddresseeName
		/// <summary>納品先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeName
		{
			get{return _addresseeName;}
			set{_addresseeName = value;}
		}

		/// public propaty name  :  AddresseeName2
		/// <summary>納品先名称2プロパティ</summary>
		/// <value>追加(登録漏れ) 塩原</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeName2
		{
			get{return _addresseeName2;}
			set{_addresseeName2 = value;}
		}

		/// public propaty name  :  AddresseePostNo
		/// <summary>納品先郵便番号プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseePostNo
		{
			get{return _addresseePostNo;}
			set{_addresseePostNo = value;}
		}

		/// public propaty name  :  AddresseeAddr1
		/// <summary>納品先住所1(都道府県市区郡・町村・字)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所1(都道府県市区郡・町村・字)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeAddr1
		{
			get{return _addresseeAddr1;}
			set{_addresseeAddr1 = value;}
		}

		/// public propaty name  :  AddresseeAddr3
		/// <summary>納品先住所3(番地)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所3(番地)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeAddr3
		{
			get{return _addresseeAddr3;}
			set{_addresseeAddr3 = value;}
		}

		/// public propaty name  :  AddresseeAddr4
		/// <summary>納品先住所4(アパート名称)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所4(アパート名称)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeAddr4
		{
			get{return _addresseeAddr4;}
			set{_addresseeAddr4 = value;}
		}

		/// public propaty name  :  AddresseeTelNo
		/// <summary>納品先電話番号プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先電話番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeTelNo
		{
			get{return _addresseeTelNo;}
			set{_addresseeTelNo = value;}
		}

		/// public propaty name  :  AddresseeFaxNo
		/// <summary>納品先FAX番号プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先FAX番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeFaxNo
		{
			get{return _addresseeFaxNo;}
			set{_addresseeFaxNo = value;}
		}

		/// public propaty name  :  DirectSendingCd
		/// <summary>直送区分プロパティ</summary>
		/// <value>0:直送なし,1:直送あり　（発注書の直送先印字制御）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   直送区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DirectSendingCd
		{
			get{return _directSendingCd;}
			set{_directSendingCd = value;}
		}

		/// public propaty name  :  SupplierSlipDisplay
		/// <summary>仕入伝票区分(画面表示用)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票区分(画面表示用)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipDisplay
		{
			get{return _supplierSlipDisplay;}
			set{_supplierSlipDisplay = value;}
		}

		/// public propaty name  :  SuppRateGrpCode
		/// <summary>仕入先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppRateGrpCode
		{
			get{return _suppRateGrpCode;}
			set{_suppRateGrpCode = value;}
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

		/// public propaty name  :  InputMode
		/// <summary>入力モードプロパティ</summary>
		/// <value>10:掛仕入,20:掛返品,30:現金仕入,40:現金返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力モードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputMode
		{
			get{return _inputMode;}
			set{_inputMode = value;}
		}

		/// public propaty name  :  PayeeName
		/// <summary>支払先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName
		{
			get{return _payeeName;}
			set{_payeeName = value;}
		}

		/// public propaty name  :  PayeeName2
		/// <summary>支払先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName2
		{
			get{return _payeeName2;}
			set{_payeeName2 = value;}
		}

		/// public propaty name  :  NTimeCalcStDate
		/// <summary>次回勘定開始日プロパティ</summary>
		/// <value>01～31まで（省略可能）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   次回勘定開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NTimeCalcStDate
		{
			get{return _nTimeCalcStDate;}
			set{_nTimeCalcStDate = value;}
		}

		/// public propaty name  :  PaymentTotalDay
		/// <summary>支払締日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PaymentTotalDay
		{
			get{return _paymentTotalDay;}
			set{_paymentTotalDay = value;}
		}

		/// public propaty name  :  PriceCostUpdtDiv
		/// <summary>定価原価更新区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価原価更新区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCostUpdtDiv
		{
			get{return _priceCostUpdtDiv;}
			set{_priceCostUpdtDiv = value;}
		}

		/// public propaty name  :  SubSectionName
		/// <summary>部門名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部門名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubSectionName
		{
			get{return _subSectionName;}
			set{_subSectionName = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
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

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// public propaty name  :  StockSectionNm
		/// <summary>仕入拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSectionNm
		{
			get{return _stockSectionNm;}
			set{_stockSectionNm = value;}
		}

		/// public propaty name  :  StockAddUpSectionNm
		/// <summary>仕入計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAddUpSectionNm
		{
			get{return _stockAddUpSectionNm;}
			set{_stockAddUpSectionNm = value;}
		}

		/// public propaty name  :  SuppCTaxLayMethodNm
		/// <summary>仕入先消費税転嫁方式名称プロパティ</summary>
		/// <value>伝票単位、明細単位、請求単位</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先消費税転嫁方式名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SuppCTaxLayMethodNm
		{
			get{return _suppCTaxLayMethodNm;}
			set{_suppCTaxLayMethodNm = value;}
		}


		/// <summary>
		/// 仕入データコンストラクタ
		/// </summary>
		/// <returns>StockSlipクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSlip()
		{
		}

		/// <summary>
		/// 仕入データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
		/// <param name="supplierSlipNo">仕入伝票番号(仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
		/// <param name="debitNLnkSuppSlipNo">赤黒連結仕入伝票番号</param>
		/// <param name="supplierSlipCd">仕入伝票区分(10:仕入,20:返品)</param>
		/// <param name="stockGoodsCd">仕入商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動))</param>
		/// <param name="accPayDivCd">買掛区分(0:買掛なし,1:買掛)</param>
		/// <param name="stockSectionCd">仕入拠点コード</param>
		/// <param name="stockAddUpSectionCd">仕入計上拠点コード(文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと))</param>
		/// <param name="stockSlipUpdateCd">仕入伝票更新区分(0:未更新,1:更新あり)</param>
		/// <param name="inputDay">入力日(YYYYMMDD　（更新年月日）)</param>
		/// <param name="arrivalGoodsDay">入荷日(YYYYMMDD)</param>
		/// <param name="stockDate">仕入日(YYYYMMDD)</param>
		/// <param name="stockAddUpADate">仕入計上日付(仕入計上日)</param>
		/// <param name="delayPaymentDiv">来勘区分(0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後)</param>
		/// <param name="payeeCode">支払先コード(支払先(精算先)コード。支払締時は支払先単位で集計・計算。)</param>
		/// <param name="payeeSnm">支払先略称</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="supplierNm1">仕入先名1</param>
		/// <param name="supplierNm2">仕入先名2</param>
		/// <param name="supplierSnm">仕入先略称</param>
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="businessTypeName">業種名称</param>
		/// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
		/// <param name="salesAreaName">販売エリア名称</param>
		/// <param name="stockInputCode">仕入入力者コード</param>
		/// <param name="stockInputName">仕入入力者名称</param>
		/// <param name="stockAgentCode">仕入担当者コード(発注者をセット)</param>
		/// <param name="stockAgentName">仕入担当者名称(発注者をセット)</param>
		/// <param name="suppTtlAmntDspWayCd">仕入先総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
		/// <param name="ttlAmntDispRateApy">総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率)</param>
		/// <param name="stockTotalPrice">仕入金額合計(仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計)</param>
		/// <param name="stockSubttlPrice">仕入金額小計(仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計)</param>
		/// <param name="stockTtlPricTaxInc">仕入金額計（税込み）(外税時：税抜き＋消費税、内税時：内税価格（税込）の集計)</param>
		/// <param name="stockTtlPricTaxExc">仕入金額計（税抜き）(外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税)</param>
		/// <param name="stockNetPrice">仕入正価金額(値引前の税抜仕入金額)</param>
		/// <param name="stockPriceConsTax">仕入金額消費税額(仕入金額消費税額（外税）+仕入金額消費税額（内税）)</param>
		/// <param name="ttlItdedStcOutTax">仕入外税対象額合計(外税対象金額の集計（税抜、値引含まず）)</param>
		/// <param name="ttlItdedStcInTax">仕入内税対象額合計(内税対象金額の集計（税抜、値引含まず） )</param>
		/// <param name="ttlItdedStcTaxFree">仕入非課税対象額合計(非課税対象金額の集計（値引含まず）)</param>
		/// <param name="stockOutTax">仕入金額消費税額（外税）(値引前の外税商品の消費税)</param>
		/// <param name="stckPrcConsTaxInclu">仕入金額消費税額（内税）(値引前の内税商品の消費税)</param>
		/// <param name="stckDisTtlTaxExc">仕入値引金額計（税抜き）(仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計)</param>
		/// <param name="itdedStockDisOutTax">仕入値引外税対象額合計(外税商品値引の外税対象額（税抜）)</param>
		/// <param name="itdedStockDisInTax">仕入値引内税対象額合計(内税商品値引の内税対象額（税抜）)</param>
		/// <param name="itdedStockDisTaxFre">仕入値引非課税対象額合計(非課税商品値引の非課税対象額)</param>
		/// <param name="stockDisOutTax">仕入値引消費税額（外税）(外税商品値引の消費税額)</param>
		/// <param name="stckDisTtlTaxInclu">仕入値引消費税額（内税）(内税商品値引の消費税額)</param>
		/// <param name="taxAdjust">消費税調整額</param>
		/// <param name="balanceAdjust">残高調整額</param>
		/// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード(0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税)</param>
		/// <param name="supplierConsTaxRate">仕入先消費税税率</param>
		/// <param name="accPayConsTax">買掛消費税</param>
		/// <param name="stockFractionProcCd">仕入端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
		/// <param name="autoPayment">自動支払区分(0:通常支払,1:自動支払)</param>
		/// <param name="autoPaySlipNum">自動支払伝票番号(自動支払時の支払伝票番号)</param>
		/// <param name="retGoodsReasonDiv">返品理由コード</param>
		/// <param name="retGoodsReason">返品理由</param>
		/// <param name="partySaleSlipNum">相手先伝票番号(仕入先伝票番号に使用する)</param>
		/// <param name="supplierSlipNote1">仕入伝票備考1</param>
		/// <param name="supplierSlipNote2">仕入伝票備考2</param>
        /// <param name="supplierSlipNoteNo1">仕入伝票備考番号1</param>  // ADD 2011/11/30 gezh redmine#8383
        /// <param name="supplierSlipNoteNo2">仕入伝票備考番号2</param>  // ADD 2011/11/30 gezh redmine#8383
		/// <param name="detailRowCount">明細行数(伝票内の明細の行数（諸費用明細は除く）)</param>
		/// <param name="ediSendDate">ＥＤＩ送信日(YYYYMMDD （ErectricDataInterface）)</param>
		/// <param name="ediTakeInDate">ＥＤＩ取込日(YYYYMMDD)</param>
		/// <param name="uoeRemark1">ＵＯＥリマーク１(UserOrderEntory)</param>
		/// <param name="uoeRemark2">ＵＯＥリマーク２</param>
		/// <param name="slipPrintDivCd">伝票発行区分(0:しない 1:する)</param>
		/// <param name="slipPrintFinishCd">伝票発行済区分(0:未発行 1:発行済)</param>
		/// <param name="stockSlipPrintDate">仕入伝票発行日(入荷では入荷伝票発行日（発注書発行日もここを使用）)</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）)</param>
		/// <param name="slipAddressDiv">伝票住所区分(1:得意先,2:納入先)</param>
		/// <param name="addresseeCode">納品先コード</param>
		/// <param name="addresseeName">納品先名称</param>
		/// <param name="addresseeName2">納品先名称2(追加(登録漏れ) 塩原)</param>
		/// <param name="addresseePostNo">納品先郵便番号(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr1">納品先住所1(都道府県市区郡・町村・字)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr3">納品先住所3(番地)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr4">納品先住所4(アパート名称)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeTelNo">納品先電話番号(伝票住所区分に従う内容)</param>
		/// <param name="addresseeFaxNo">納品先FAX番号(伝票住所区分に従う内容)</param>
		/// <param name="directSendingCd">直送区分(0:直送なし,1:直送あり　（発注書の直送先印字制御）)</param>
		/// <param name="supplierSlipDisplay">仕入伝票区分(画面表示用)</param>
		/// <param name="suppRateGrpCode">仕入先掛率グループコード</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="inputMode">入力モード(10:掛仕入,20:掛返品,30:現金仕入,40:現金返品)</param>
		/// <param name="payeeName">支払先名称</param>
		/// <param name="payeeName2">支払先名称2</param>
		/// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
		/// <param name="paymentTotalDay">支払締日</param>
		/// <param name="priceCostUpdtDiv">定価原価更新区分</param>
		/// <param name="subSectionName">部門名称</param>
		/// <param name="sectionGuideNm">拠点ガイド名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="stockSectionNm">仕入拠点名称</param>
		/// <param name="stockAddUpSectionNm">仕入計上拠点名称</param>
		/// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
		/// <returns>StockSlipクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public StockSlip(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 supplierFormal,Int32 supplierSlipNo,string sectionCode,Int32 subSectionCode,Int32 debitNoteDiv,Int32 debitNLnkSuppSlipNo,Int32 supplierSlipCd,Int32 stockGoodsCd,Int32 accPayDivCd,string stockSectionCd,string stockAddUpSectionCd,Int32 stockSlipUpdateCd,DateTime inputDay,DateTime arrivalGoodsDay,DateTime stockDate,DateTime stockAddUpADate,Int32 delayPaymentDiv,Int32 payeeCode,string payeeSnm,Int32 supplierCd,string supplierNm1,string supplierNm2,string supplierSnm,Int32 businessTypeCode,string businessTypeName,Int32 salesAreaCode,string salesAreaName,string stockInputCode,string stockInputName,string stockAgentCode,string stockAgentName,Int32 suppTtlAmntDspWayCd,Int32 ttlAmntDispRateApy,Int64 stockTotalPrice,Int64 stockSubttlPrice,Int64 stockTtlPricTaxInc,Int64 stockTtlPricTaxExc,Int64 stockNetPrice,Int64 stockPriceConsTax,Int64 ttlItdedStcOutTax,Int64 ttlItdedStcInTax,Int64 ttlItdedStcTaxFree,Int64 stockOutTax,Int64 stckPrcConsTaxInclu,Int64 stckDisTtlTaxExc,Int64 itdedStockDisOutTax,Int64 itdedStockDisInTax,Int64 itdedStockDisTaxFre,Int64 stockDisOutTax,Int64 stckDisTtlTaxInclu,Int64 taxAdjust,Int64 balanceAdjust,Int32 suppCTaxLayCd,Double supplierConsTaxRate,Int64 accPayConsTax,Int32 stockFractionProcCd,Int32 autoPayment,Int32 autoPaySlipNum,Int32 retGoodsReasonDiv,string retGoodsReason,string partySaleSlipNum,string supplierSlipNote1,string supplierSlipNote2,Int32 detailRowCount,DateTime ediSendDate,DateTime ediTakeInDate,string uoeRemark1,string uoeRemark2,Int32 slipPrintDivCd,Int32 slipPrintFinishCd,DateTime stockSlipPrintDate,string slipPrtSetPaperId,Int32 slipAddressDiv,Int32 addresseeCode,string addresseeName,string addresseeName2,string addresseePostNo,string addresseeAddr1,string addresseeAddr3,string addresseeAddr4,string addresseeTelNo,string addresseeFaxNo,Int32 directSendingCd,Int32 supplierSlipDisplay,Int32 suppRateGrpCode,string warehouseCode,string warehouseName,Int32 inputMode,string payeeName,string payeeName2,Int32 nTimeCalcStDate,Int32 paymentTotalDay,Int32 priceCostUpdtDiv,string subSectionName,string sectionGuideNm,string enterpriseName,string updEmployeeName,string stockSectionNm,string stockAddUpSectionNm,string suppCTaxLayMethodNm)  // DEL 2011/11/30 gezh redmine#8383
        public StockSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierFormal, Int32 supplierSlipNo, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, Int32 debitNLnkSuppSlipNo, Int32 supplierSlipCd, Int32 stockGoodsCd, Int32 accPayDivCd, string stockSectionCd, string stockAddUpSectionCd, Int32 stockSlipUpdateCd, DateTime inputDay, DateTime arrivalGoodsDay, DateTime stockDate, DateTime preStockDate, DateTime stockAddUpADate, Int32 delayPaymentDiv, Int32 payeeCode, string payeeSnm, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 businessTypeCode, string businessTypeName, Int32 salesAreaCode, string salesAreaName, string stockInputCode, string stockInputName, string stockAgentCode, string stockAgentName, Int32 suppTtlAmntDspWayCd, Int32 ttlAmntDispRateApy, Int64 stockTotalPrice, Int64 stockSubttlPrice, Int64 stockTtlPricTaxInc, Int64 stockTtlPricTaxExc, Int64 stockNetPrice, Int64 stockPriceConsTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 stockOutTax, Int64 stckPrcConsTaxInclu, Int64 stckDisTtlTaxExc, Int64 itdedStockDisOutTax, Int64 itdedStockDisInTax, Int64 itdedStockDisTaxFre, Int64 stockDisOutTax, Int64 stckDisTtlTaxInclu, Int64 taxAdjust, Int64 balanceAdjust, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int64 accPayConsTax, Int32 stockFractionProcCd, Int32 autoPayment, Int32 autoPaySlipNum, Int32 retGoodsReasonDiv, string retGoodsReason, string partySaleSlipNum, string supplierSlipNote1, string supplierSlipNote2, Int32 supplierSlipNoteNo1, Int32 supplierSlipNoteNo2, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime stockSlipPrintDate, string slipPrtSetPaperId, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, Int32 directSendingCd, Int32 supplierSlipDisplay, Int32 suppRateGrpCode, string warehouseCode, string warehouseName, Int32 inputMode, string payeeName, string payeeName2, Int32 nTimeCalcStDate, Int32 paymentTotalDay, Int32 priceCostUpdtDiv, string subSectionName, string sectionGuideNm, string enterpriseName, string updEmployeeName, string stockSectionNm, string stockAddUpSectionNm, string suppCTaxLayMethodNm)  // ADD 2011/11/30 gezh redmine#8383
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._supplierFormal = supplierFormal;
			this._supplierSlipNo = supplierSlipNo;
			this._sectionCode = sectionCode;
			this._subSectionCode = subSectionCode;
			this._debitNoteDiv = debitNoteDiv;
			this._debitNLnkSuppSlipNo = debitNLnkSuppSlipNo;
			this._supplierSlipCd = supplierSlipCd;
			this._stockGoodsCd = stockGoodsCd;
			this._accPayDivCd = accPayDivCd;
			this._stockSectionCd = stockSectionCd;
			this._stockAddUpSectionCd = stockAddUpSectionCd;
			this._stockSlipUpdateCd = stockSlipUpdateCd;
			this.InputDay = inputDay;
			this.ArrivalGoodsDay = arrivalGoodsDay;
			this.StockDate = stockDate;
			this.PreStockDate = preStockDate; // ADD 2011/12/15
			this.StockAddUpADate = stockAddUpADate;
			this._delayPaymentDiv = delayPaymentDiv;
			this._payeeCode = payeeCode;
			this._payeeSnm = payeeSnm;
			this._supplierCd = supplierCd;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._supplierSnm = supplierSnm;
			this._businessTypeCode = businessTypeCode;
			this._businessTypeName = businessTypeName;
			this._salesAreaCode = salesAreaCode;
			this._salesAreaName = salesAreaName;
			this._stockInputCode = stockInputCode;
			this._stockInputName = stockInputName;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._suppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
			this._ttlAmntDispRateApy = ttlAmntDispRateApy;
			this._stockTotalPrice = stockTotalPrice;
			this._stockSubttlPrice = stockSubttlPrice;
			this._stockTtlPricTaxInc = stockTtlPricTaxInc;
			this._stockTtlPricTaxExc = stockTtlPricTaxExc;
			this._stockNetPrice = stockNetPrice;
			this._stockPriceConsTax = stockPriceConsTax;
			this._ttlItdedStcOutTax = ttlItdedStcOutTax;
			this._ttlItdedStcInTax = ttlItdedStcInTax;
			this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
			this._stockOutTax = stockOutTax;
			this._stckPrcConsTaxInclu = stckPrcConsTaxInclu;
			this._stckDisTtlTaxExc = stckDisTtlTaxExc;
			this._itdedStockDisOutTax = itdedStockDisOutTax;
			this._itdedStockDisInTax = itdedStockDisInTax;
			this._itdedStockDisTaxFre = itdedStockDisTaxFre;
			this._stockDisOutTax = stockDisOutTax;
			this._stckDisTtlTaxInclu = stckDisTtlTaxInclu;
			this._taxAdjust = taxAdjust;
			this._balanceAdjust = balanceAdjust;
			this._suppCTaxLayCd = suppCTaxLayCd;
			this._supplierConsTaxRate = supplierConsTaxRate;
			this._accPayConsTax = accPayConsTax;
			this._stockFractionProcCd = stockFractionProcCd;
			this._autoPayment = autoPayment;
			this._autoPaySlipNum = autoPaySlipNum;
			this._retGoodsReasonDiv = retGoodsReasonDiv;
			this._retGoodsReason = retGoodsReason;
			this._partySaleSlipNum = partySaleSlipNum;
			this._supplierSlipNote1 = supplierSlipNote1;
			this._supplierSlipNote2 = supplierSlipNote2;
            // ADD 2011/11/30 gezh redmine#8383 ----------->>>>>
            this._supplierSlipNoteNo1 = supplierSlipNoteNo1;
            this._supplierSlipNoteNo2 = supplierSlipNoteNo2;
            // ADD 2011/11/30 gezh redmine#8383 -----------<<<<<
			this._detailRowCount = detailRowCount;
			this.EdiSendDate = ediSendDate;
			this.EdiTakeInDate = ediTakeInDate;
			this._uoeRemark1 = uoeRemark1;
			this._uoeRemark2 = uoeRemark2;
			this._slipPrintDivCd = slipPrintDivCd;
			this._slipPrintFinishCd = slipPrintFinishCd;
			this.StockSlipPrintDate = stockSlipPrintDate;
			this._slipPrtSetPaperId = slipPrtSetPaperId;
			this._slipAddressDiv = slipAddressDiv;
			this._addresseeCode = addresseeCode;
			this._addresseeName = addresseeName;
			this._addresseeName2 = addresseeName2;
			this._addresseePostNo = addresseePostNo;
			this._addresseeAddr1 = addresseeAddr1;
			this._addresseeAddr3 = addresseeAddr3;
			this._addresseeAddr4 = addresseeAddr4;
			this._addresseeTelNo = addresseeTelNo;
			this._addresseeFaxNo = addresseeFaxNo;
			this._directSendingCd = directSendingCd;
			this._supplierSlipDisplay = supplierSlipDisplay;
			this._suppRateGrpCode = suppRateGrpCode;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._inputMode = inputMode;
			this._payeeName = payeeName;
			this._payeeName2 = payeeName2;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._paymentTotalDay = paymentTotalDay;
			this._priceCostUpdtDiv = priceCostUpdtDiv;
			this._subSectionName = subSectionName;
			this._sectionGuideNm = sectionGuideNm;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._stockSectionNm = stockSectionNm;
			this._stockAddUpSectionNm = stockAddUpSectionNm;
			this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;

		}

		/// <summary>
		/// 仕入データ複製処理
		/// </summary>
		/// <returns>StockSlipクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockSlipクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSlip Clone()
		{
			//return new StockSlip(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._supplierFormal,this._supplierSlipNo,this._sectionCode,this._subSectionCode,this._debitNoteDiv,this._debitNLnkSuppSlipNo,this._supplierSlipCd,this._stockGoodsCd,this._accPayDivCd,this._stockSectionCd,this._stockAddUpSectionCd,this._stockSlipUpdateCd,this._inputDay,this._arrivalGoodsDay,this._stockDate,this._stockAddUpADate,this._delayPaymentDiv,this._payeeCode,this._payeeSnm,this._supplierCd,this._supplierNm1,this._supplierNm2,this._supplierSnm,this._businessTypeCode,this._businessTypeName,this._salesAreaCode,this._salesAreaName,this._stockInputCode,this._stockInputName,this._stockAgentCode,this._stockAgentName,this._suppTtlAmntDspWayCd,this._ttlAmntDispRateApy,this._stockTotalPrice,this._stockSubttlPrice,this._stockTtlPricTaxInc,this._stockTtlPricTaxExc,this._stockNetPrice,this._stockPriceConsTax,this._ttlItdedStcOutTax,this._ttlItdedStcInTax,this._ttlItdedStcTaxFree,this._stockOutTax,this._stckPrcConsTaxInclu,this._stckDisTtlTaxExc,this._itdedStockDisOutTax,this._itdedStockDisInTax,this._itdedStockDisTaxFre,this._stockDisOutTax,this._stckDisTtlTaxInclu,this._taxAdjust,this._balanceAdjust,this._suppCTaxLayCd,this._supplierConsTaxRate,this._accPayConsTax,this._stockFractionProcCd,this._autoPayment,this._autoPaySlipNum,this._retGoodsReasonDiv,this._retGoodsReason,this._partySaleSlipNum,this._supplierSlipNote1,this._supplierSlipNote2,this._detailRowCount,this._ediSendDate,this._ediTakeInDate,this._uoeRemark1,this._uoeRemark2,this._slipPrintDivCd,this._slipPrintFinishCd,this._stockSlipPrintDate,this._slipPrtSetPaperId,this._slipAddressDiv,this._addresseeCode,this._addresseeName,this._addresseeName2,this._addresseePostNo,this._addresseeAddr1,this._addresseeAddr3,this._addresseeAddr4,this._addresseeTelNo,this._addresseeFaxNo,this._directSendingCd,this._supplierSlipDisplay,this._suppRateGrpCode,this._warehouseCode,this._warehouseName,this._inputMode,this._payeeName,this._payeeName2,this._nTimeCalcStDate,this._paymentTotalDay,this._priceCostUpdtDiv,this._subSectionName,this._sectionGuideNm,this._enterpriseName,this._updEmployeeName,this._stockSectionNm,this._stockAddUpSectionNm,this._suppCTaxLayMethodNm);  // DEL 2011/11/30 gezh redmine#8383
            //return new StockSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierFormal, this._supplierSlipNo, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSuppSlipNo, this._supplierSlipCd, this._stockGoodsCd, this._accPayDivCd, this._stockSectionCd, this._stockAddUpSectionCd, this._stockSlipUpdateCd, this._inputDay, this._arrivalGoodsDay, this._stockDate, this._stockAddUpADate, this._delayPaymentDiv, this._payeeCode, this._payeeSnm, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._businessTypeCode, this._businessTypeName, this._salesAreaCode, this._salesAreaName, this._stockInputCode, this._stockInputName, this._stockAgentCode, this._stockAgentName, this._suppTtlAmntDspWayCd, this._ttlAmntDispRateApy, this._stockTotalPrice, this._stockSubttlPrice, this._stockTtlPricTaxInc, this._stockTtlPricTaxExc, this._stockNetPrice, this._stockPriceConsTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._stockOutTax, this._stckPrcConsTaxInclu, this._stckDisTtlTaxExc, this._itdedStockDisOutTax, this._itdedStockDisInTax, this._itdedStockDisTaxFre, this._stockDisOutTax, this._stckDisTtlTaxInclu, this._taxAdjust, this._balanceAdjust, this._suppCTaxLayCd, this._supplierConsTaxRate, this._accPayConsTax, this._stockFractionProcCd, this._autoPayment, this._autoPaySlipNum, this._retGoodsReasonDiv, this._retGoodsReason, this._partySaleSlipNum, this._supplierSlipNote1, this._supplierSlipNote2, this._supplierSlipNoteNo1, this._supplierSlipNoteNo2, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._stockSlipPrintDate, this._slipPrtSetPaperId, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._directSendingCd, this._supplierSlipDisplay, this._suppRateGrpCode, this._warehouseCode, this._warehouseName, this._inputMode, this._payeeName, this._payeeName2, this._nTimeCalcStDate, this._paymentTotalDay, this._priceCostUpdtDiv, this._subSectionName, this._sectionGuideNm, this._enterpriseName, this._updEmployeeName, this._stockSectionNm, this._stockAddUpSectionNm, this._suppCTaxLayMethodNm);  // ADD 2011/11/30 gezh redmine#8383 // DEL 2011/12/15
            return new StockSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierFormal, this._supplierSlipNo, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSuppSlipNo, this._supplierSlipCd, this._stockGoodsCd, this._accPayDivCd, this._stockSectionCd, this._stockAddUpSectionCd, this._stockSlipUpdateCd, this._inputDay, this._arrivalGoodsDay, this._stockDate, this._preStockDate, this._stockAddUpADate, this._delayPaymentDiv, this._payeeCode, this._payeeSnm, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._businessTypeCode, this._businessTypeName, this._salesAreaCode, this._salesAreaName, this._stockInputCode, this._stockInputName, this._stockAgentCode, this._stockAgentName, this._suppTtlAmntDspWayCd, this._ttlAmntDispRateApy, this._stockTotalPrice, this._stockSubttlPrice, this._stockTtlPricTaxInc, this._stockTtlPricTaxExc, this._stockNetPrice, this._stockPriceConsTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._stockOutTax, this._stckPrcConsTaxInclu, this._stckDisTtlTaxExc, this._itdedStockDisOutTax, this._itdedStockDisInTax, this._itdedStockDisTaxFre, this._stockDisOutTax, this._stckDisTtlTaxInclu, this._taxAdjust, this._balanceAdjust, this._suppCTaxLayCd, this._supplierConsTaxRate, this._accPayConsTax, this._stockFractionProcCd, this._autoPayment, this._autoPaySlipNum, this._retGoodsReasonDiv, this._retGoodsReason, this._partySaleSlipNum, this._supplierSlipNote1, this._supplierSlipNote2, this._supplierSlipNoteNo1, this._supplierSlipNoteNo2, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._stockSlipPrintDate, this._slipPrtSetPaperId, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._directSendingCd, this._supplierSlipDisplay, this._suppRateGrpCode, this._warehouseCode, this._warehouseName, this._inputMode, this._payeeName, this._payeeName2, this._nTimeCalcStDate, this._paymentTotalDay, this._priceCostUpdtDiv, this._subSectionName, this._sectionGuideNm, this._enterpriseName, this._updEmployeeName, this._stockSectionNm, this._stockAddUpSectionNm, this._suppCTaxLayMethodNm);  // ADD 2011/12/15
		}

		/// <summary>
		/// 仕入データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockSlipクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockSlip target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SupplierFormal == target.SupplierFormal)
				 && (this.SupplierSlipNo == target.SupplierSlipNo)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.DebitNLnkSuppSlipNo == target.DebitNLnkSuppSlipNo)
				 && (this.SupplierSlipCd == target.SupplierSlipCd)
				 && (this.StockGoodsCd == target.StockGoodsCd)
				 && (this.AccPayDivCd == target.AccPayDivCd)
				 && (this.StockSectionCd == target.StockSectionCd)
				 && (this.StockAddUpSectionCd == target.StockAddUpSectionCd)
				 && (this.StockSlipUpdateCd == target.StockSlipUpdateCd)
				 && (this.InputDay == target.InputDay)
				 && (this.ArrivalGoodsDay == target.ArrivalGoodsDay)
				 && (this.StockDate == target.StockDate)
                 && (this.PreStockDate == target.PreStockDate) // ADD 2011/12/15
				 && (this.StockAddUpADate == target.StockAddUpADate)
				 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.PayeeSnm == target.PayeeSnm)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.BusinessTypeName == target.BusinessTypeName)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.SalesAreaName == target.SalesAreaName)
				 && (this.StockInputCode == target.StockInputCode)
				 && (this.StockInputName == target.StockInputName)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.SuppTtlAmntDspWayCd == target.SuppTtlAmntDspWayCd)
				 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
				 && (this.StockTotalPrice == target.StockTotalPrice)
				 && (this.StockSubttlPrice == target.StockSubttlPrice)
				 && (this.StockTtlPricTaxInc == target.StockTtlPricTaxInc)
				 && (this.StockTtlPricTaxExc == target.StockTtlPricTaxExc)
				 && (this.StockNetPrice == target.StockNetPrice)
				 && (this.StockPriceConsTax == target.StockPriceConsTax)
				 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
				 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
				 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
				 && (this.StockOutTax == target.StockOutTax)
				 && (this.StckPrcConsTaxInclu == target.StckPrcConsTaxInclu)
				 && (this.StckDisTtlTaxExc == target.StckDisTtlTaxExc)
				 && (this.ItdedStockDisOutTax == target.ItdedStockDisOutTax)
				 && (this.ItdedStockDisInTax == target.ItdedStockDisInTax)
				 && (this.ItdedStockDisTaxFre == target.ItdedStockDisTaxFre)
				 && (this.StockDisOutTax == target.StockDisOutTax)
				 && (this.StckDisTtlTaxInclu == target.StckDisTtlTaxInclu)
				 && (this.TaxAdjust == target.TaxAdjust)
				 && (this.BalanceAdjust == target.BalanceAdjust)
				 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
				 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
				 && (this.AccPayConsTax == target.AccPayConsTax)
				 && (this.StockFractionProcCd == target.StockFractionProcCd)
				 && (this.AutoPayment == target.AutoPayment)
				 && (this.AutoPaySlipNum == target.AutoPaySlipNum)
				 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
				 && (this.RetGoodsReason == target.RetGoodsReason)
				 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
				 && (this.SupplierSlipNote1 == target.SupplierSlipNote1)
				 && (this.SupplierSlipNote2 == target.SupplierSlipNote2)
                 // ADD 2011/11/30 gezh redmine#8383 ---------------->>>>>
                 && (this.SupplierSlipNoteNo1 == target.SupplierSlipNoteNo1)
                 && (this.SupplierSlipNoteNo2 == target.SupplierSlipNoteNo2)
                 // ADD 2011/11/30 gezh redmine#8383 ----------------<<<<<
				 && (this.DetailRowCount == target.DetailRowCount)
				 && (this.EdiSendDate == target.EdiSendDate)
				 && (this.EdiTakeInDate == target.EdiTakeInDate)
				 && (this.UoeRemark1 == target.UoeRemark1)
				 && (this.UoeRemark2 == target.UoeRemark2)
				 && (this.SlipPrintDivCd == target.SlipPrintDivCd)
				 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
				 && (this.StockSlipPrintDate == target.StockSlipPrintDate)
				 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
				 && (this.SlipAddressDiv == target.SlipAddressDiv)
				 && (this.AddresseeCode == target.AddresseeCode)
				 && (this.AddresseeName == target.AddresseeName)
				 && (this.AddresseeName2 == target.AddresseeName2)
				 && (this.AddresseePostNo == target.AddresseePostNo)
				 && (this.AddresseeAddr1 == target.AddresseeAddr1)
				 && (this.AddresseeAddr3 == target.AddresseeAddr3)
				 && (this.AddresseeAddr4 == target.AddresseeAddr4)
				 && (this.AddresseeTelNo == target.AddresseeTelNo)
				 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
				 && (this.DirectSendingCd == target.DirectSendingCd)
				 && (this.SupplierSlipDisplay == target.SupplierSlipDisplay)
				 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.InputMode == target.InputMode)
				 && (this.PayeeName == target.PayeeName)
				 && (this.PayeeName2 == target.PayeeName2)
				 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
				 && (this.PaymentTotalDay == target.PaymentTotalDay)
				 && (this.PriceCostUpdtDiv == target.PriceCostUpdtDiv)
				 && (this.SubSectionName == target.SubSectionName)
				 && (this.SectionGuideNm == target.SectionGuideNm)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.StockSectionNm == target.StockSectionNm)
				 && (this.StockAddUpSectionNm == target.StockAddUpSectionNm)
				 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm));
		}

		/// <summary>
		/// 仕入データ比較処理
		/// </summary>
		/// <param name="stockSlip1">
		///                    比較するStockSlipクラスのインスタンス
		/// </param>
		/// <param name="stockSlip2">比較するStockSlipクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockSlip stockSlip1, StockSlip stockSlip2)
		{
			return ((stockSlip1.CreateDateTime == stockSlip2.CreateDateTime)
				 && (stockSlip1.UpdateDateTime == stockSlip2.UpdateDateTime)
				 && (stockSlip1.EnterpriseCode == stockSlip2.EnterpriseCode)
				 && (stockSlip1.FileHeaderGuid == stockSlip2.FileHeaderGuid)
				 && (stockSlip1.UpdEmployeeCode == stockSlip2.UpdEmployeeCode)
				 && (stockSlip1.UpdAssemblyId1 == stockSlip2.UpdAssemblyId1)
				 && (stockSlip1.UpdAssemblyId2 == stockSlip2.UpdAssemblyId2)
				 && (stockSlip1.LogicalDeleteCode == stockSlip2.LogicalDeleteCode)
				 && (stockSlip1.SupplierFormal == stockSlip2.SupplierFormal)
				 && (stockSlip1.SupplierSlipNo == stockSlip2.SupplierSlipNo)
				 && (stockSlip1.SectionCode == stockSlip2.SectionCode)
				 && (stockSlip1.SubSectionCode == stockSlip2.SubSectionCode)
				 && (stockSlip1.DebitNoteDiv == stockSlip2.DebitNoteDiv)
				 && (stockSlip1.DebitNLnkSuppSlipNo == stockSlip2.DebitNLnkSuppSlipNo)
				 && (stockSlip1.SupplierSlipCd == stockSlip2.SupplierSlipCd)
				 && (stockSlip1.StockGoodsCd == stockSlip2.StockGoodsCd)
				 && (stockSlip1.AccPayDivCd == stockSlip2.AccPayDivCd)
				 && (stockSlip1.StockSectionCd == stockSlip2.StockSectionCd)
				 && (stockSlip1.StockAddUpSectionCd == stockSlip2.StockAddUpSectionCd)
				 && (stockSlip1.StockSlipUpdateCd == stockSlip2.StockSlipUpdateCd)
				 && (stockSlip1.InputDay == stockSlip2.InputDay)
				 && (stockSlip1.ArrivalGoodsDay == stockSlip2.ArrivalGoodsDay)
				 && (stockSlip1.StockDate == stockSlip2.StockDate)
                 && (stockSlip1.PreStockDate == stockSlip2.PreStockDate) // ADD 2011/12/15
				 && (stockSlip1.StockAddUpADate == stockSlip2.StockAddUpADate)
				 && (stockSlip1.DelayPaymentDiv == stockSlip2.DelayPaymentDiv)
				 && (stockSlip1.PayeeCode == stockSlip2.PayeeCode)
				 && (stockSlip1.PayeeSnm == stockSlip2.PayeeSnm)
				 && (stockSlip1.SupplierCd == stockSlip2.SupplierCd)
				 && (stockSlip1.SupplierNm1 == stockSlip2.SupplierNm1)
				 && (stockSlip1.SupplierNm2 == stockSlip2.SupplierNm2)
				 && (stockSlip1.SupplierSnm == stockSlip2.SupplierSnm)
				 && (stockSlip1.BusinessTypeCode == stockSlip2.BusinessTypeCode)
				 && (stockSlip1.BusinessTypeName == stockSlip2.BusinessTypeName)
				 && (stockSlip1.SalesAreaCode == stockSlip2.SalesAreaCode)
				 && (stockSlip1.SalesAreaName == stockSlip2.SalesAreaName)
				 && (stockSlip1.StockInputCode == stockSlip2.StockInputCode)
				 && (stockSlip1.StockInputName == stockSlip2.StockInputName)
				 && (stockSlip1.StockAgentCode == stockSlip2.StockAgentCode)
				 && (stockSlip1.StockAgentName == stockSlip2.StockAgentName)
				 && (stockSlip1.SuppTtlAmntDspWayCd == stockSlip2.SuppTtlAmntDspWayCd)
				 && (stockSlip1.TtlAmntDispRateApy == stockSlip2.TtlAmntDispRateApy)
				 && (stockSlip1.StockTotalPrice == stockSlip2.StockTotalPrice)
				 && (stockSlip1.StockSubttlPrice == stockSlip2.StockSubttlPrice)
				 && (stockSlip1.StockTtlPricTaxInc == stockSlip2.StockTtlPricTaxInc)
				 && (stockSlip1.StockTtlPricTaxExc == stockSlip2.StockTtlPricTaxExc)
				 && (stockSlip1.StockNetPrice == stockSlip2.StockNetPrice)
				 && (stockSlip1.StockPriceConsTax == stockSlip2.StockPriceConsTax)
				 && (stockSlip1.TtlItdedStcOutTax == stockSlip2.TtlItdedStcOutTax)
				 && (stockSlip1.TtlItdedStcInTax == stockSlip2.TtlItdedStcInTax)
				 && (stockSlip1.TtlItdedStcTaxFree == stockSlip2.TtlItdedStcTaxFree)
				 && (stockSlip1.StockOutTax == stockSlip2.StockOutTax)
				 && (stockSlip1.StckPrcConsTaxInclu == stockSlip2.StckPrcConsTaxInclu)
				 && (stockSlip1.StckDisTtlTaxExc == stockSlip2.StckDisTtlTaxExc)
				 && (stockSlip1.ItdedStockDisOutTax == stockSlip2.ItdedStockDisOutTax)
				 && (stockSlip1.ItdedStockDisInTax == stockSlip2.ItdedStockDisInTax)
				 && (stockSlip1.ItdedStockDisTaxFre == stockSlip2.ItdedStockDisTaxFre)
				 && (stockSlip1.StockDisOutTax == stockSlip2.StockDisOutTax)
				 && (stockSlip1.StckDisTtlTaxInclu == stockSlip2.StckDisTtlTaxInclu)
				 && (stockSlip1.TaxAdjust == stockSlip2.TaxAdjust)
				 && (stockSlip1.BalanceAdjust == stockSlip2.BalanceAdjust)
				 && (stockSlip1.SuppCTaxLayCd == stockSlip2.SuppCTaxLayCd)
				 && (stockSlip1.SupplierConsTaxRate == stockSlip2.SupplierConsTaxRate)
				 && (stockSlip1.AccPayConsTax == stockSlip2.AccPayConsTax)
				 && (stockSlip1.StockFractionProcCd == stockSlip2.StockFractionProcCd)
				 && (stockSlip1.AutoPayment == stockSlip2.AutoPayment)
				 && (stockSlip1.AutoPaySlipNum == stockSlip2.AutoPaySlipNum)
				 && (stockSlip1.RetGoodsReasonDiv == stockSlip2.RetGoodsReasonDiv)
				 && (stockSlip1.RetGoodsReason == stockSlip2.RetGoodsReason)
				 && (stockSlip1.PartySaleSlipNum == stockSlip2.PartySaleSlipNum)
				 && (stockSlip1.SupplierSlipNote1 == stockSlip2.SupplierSlipNote1)
				 && (stockSlip1.SupplierSlipNote2 == stockSlip2.SupplierSlipNote2)
                 // ADD 2011/11/30 gezh redmine#8383 ---------------->>>>>
                 && (stockSlip1.SupplierSlipNoteNo1 == stockSlip2.SupplierSlipNoteNo1)
                 && (stockSlip1.SupplierSlipNoteNo2 == stockSlip2.SupplierSlipNoteNo2)
                 // ADD 2011/11/30 gezh redmine#8383 ----------------<<<<<
				 && (stockSlip1.DetailRowCount == stockSlip2.DetailRowCount)
				 && (stockSlip1.EdiSendDate == stockSlip2.EdiSendDate)
				 && (stockSlip1.EdiTakeInDate == stockSlip2.EdiTakeInDate)
				 && (stockSlip1.UoeRemark1 == stockSlip2.UoeRemark1)
				 && (stockSlip1.UoeRemark2 == stockSlip2.UoeRemark2)
				 && (stockSlip1.SlipPrintDivCd == stockSlip2.SlipPrintDivCd)
				 && (stockSlip1.SlipPrintFinishCd == stockSlip2.SlipPrintFinishCd)
				 && (stockSlip1.StockSlipPrintDate == stockSlip2.StockSlipPrintDate)
				 && (stockSlip1.SlipPrtSetPaperId == stockSlip2.SlipPrtSetPaperId)
				 && (stockSlip1.SlipAddressDiv == stockSlip2.SlipAddressDiv)
				 && (stockSlip1.AddresseeCode == stockSlip2.AddresseeCode)
				 && (stockSlip1.AddresseeName == stockSlip2.AddresseeName)
				 && (stockSlip1.AddresseeName2 == stockSlip2.AddresseeName2)
				 && (stockSlip1.AddresseePostNo == stockSlip2.AddresseePostNo)
				 && (stockSlip1.AddresseeAddr1 == stockSlip2.AddresseeAddr1)
				 && (stockSlip1.AddresseeAddr3 == stockSlip2.AddresseeAddr3)
				 && (stockSlip1.AddresseeAddr4 == stockSlip2.AddresseeAddr4)
				 && (stockSlip1.AddresseeTelNo == stockSlip2.AddresseeTelNo)
				 && (stockSlip1.AddresseeFaxNo == stockSlip2.AddresseeFaxNo)
				 && (stockSlip1.DirectSendingCd == stockSlip2.DirectSendingCd)
				 && (stockSlip1.SupplierSlipDisplay == stockSlip2.SupplierSlipDisplay)
				 && (stockSlip1.SuppRateGrpCode == stockSlip2.SuppRateGrpCode)
				 && (stockSlip1.WarehouseCode == stockSlip2.WarehouseCode)
				 && (stockSlip1.WarehouseName == stockSlip2.WarehouseName)
				 && (stockSlip1.InputMode == stockSlip2.InputMode)
				 && (stockSlip1.PayeeName == stockSlip2.PayeeName)
				 && (stockSlip1.PayeeName2 == stockSlip2.PayeeName2)
				 && (stockSlip1.NTimeCalcStDate == stockSlip2.NTimeCalcStDate)
				 && (stockSlip1.PaymentTotalDay == stockSlip2.PaymentTotalDay)
				 && (stockSlip1.PriceCostUpdtDiv == stockSlip2.PriceCostUpdtDiv)
				 && (stockSlip1.SubSectionName == stockSlip2.SubSectionName)
				 && (stockSlip1.SectionGuideNm == stockSlip2.SectionGuideNm)
				 && (stockSlip1.EnterpriseName == stockSlip2.EnterpriseName)
				 && (stockSlip1.UpdEmployeeName == stockSlip2.UpdEmployeeName)
				 && (stockSlip1.StockSectionNm == stockSlip2.StockSectionNm)
				 && (stockSlip1.StockAddUpSectionNm == stockSlip2.StockAddUpSectionNm)
				 && (stockSlip1.SuppCTaxLayMethodNm == stockSlip2.SuppCTaxLayMethodNm));
		}
		/// <summary>
		/// 仕入データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockSlipクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockSlip target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SupplierFormal != target.SupplierFormal)resList.Add("SupplierFormal");
			if(this.SupplierSlipNo != target.SupplierSlipNo)resList.Add("SupplierSlipNo");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SubSectionCode != target.SubSectionCode)resList.Add("SubSectionCode");
			if(this.DebitNoteDiv != target.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(this.DebitNLnkSuppSlipNo != target.DebitNLnkSuppSlipNo)resList.Add("DebitNLnkSuppSlipNo");
			if(this.SupplierSlipCd != target.SupplierSlipCd)resList.Add("SupplierSlipCd");
			if(this.StockGoodsCd != target.StockGoodsCd)resList.Add("StockGoodsCd");
			if(this.AccPayDivCd != target.AccPayDivCd)resList.Add("AccPayDivCd");
			if(this.StockSectionCd != target.StockSectionCd)resList.Add("StockSectionCd");
			if(this.StockAddUpSectionCd != target.StockAddUpSectionCd)resList.Add("StockAddUpSectionCd");
			if(this.StockSlipUpdateCd != target.StockSlipUpdateCd)resList.Add("StockSlipUpdateCd");
			if(this.InputDay != target.InputDay)resList.Add("InputDay");
			if(this.ArrivalGoodsDay != target.ArrivalGoodsDay)resList.Add("ArrivalGoodsDay");
			if(this.StockDate != target.StockDate)resList.Add("StockDate");
            if (this.PreStockDate != target.PreStockDate) resList.Add("PreStockDate"); // ADD 2011/12/15
			if(this.StockAddUpADate != target.StockAddUpADate)resList.Add("StockAddUpADate");
			if(this.DelayPaymentDiv != target.DelayPaymentDiv)resList.Add("DelayPaymentDiv");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.PayeeSnm != target.PayeeSnm)resList.Add("PayeeSnm");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.BusinessTypeCode != target.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(this.BusinessTypeName != target.BusinessTypeName)resList.Add("BusinessTypeName");
			if(this.SalesAreaCode != target.SalesAreaCode)resList.Add("SalesAreaCode");
			if(this.SalesAreaName != target.SalesAreaName)resList.Add("SalesAreaName");
			if(this.StockInputCode != target.StockInputCode)resList.Add("StockInputCode");
			if(this.StockInputName != target.StockInputName)resList.Add("StockInputName");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.SuppTtlAmntDspWayCd != target.SuppTtlAmntDspWayCd)resList.Add("SuppTtlAmntDspWayCd");
			if(this.TtlAmntDispRateApy != target.TtlAmntDispRateApy)resList.Add("TtlAmntDispRateApy");
			if(this.StockTotalPrice != target.StockTotalPrice)resList.Add("StockTotalPrice");
			if(this.StockSubttlPrice != target.StockSubttlPrice)resList.Add("StockSubttlPrice");
			if(this.StockTtlPricTaxInc != target.StockTtlPricTaxInc)resList.Add("StockTtlPricTaxInc");
			if(this.StockTtlPricTaxExc != target.StockTtlPricTaxExc)resList.Add("StockTtlPricTaxExc");
			if(this.StockNetPrice != target.StockNetPrice)resList.Add("StockNetPrice");
			if(this.StockPriceConsTax != target.StockPriceConsTax)resList.Add("StockPriceConsTax");
			if(this.TtlItdedStcOutTax != target.TtlItdedStcOutTax)resList.Add("TtlItdedStcOutTax");
			if(this.TtlItdedStcInTax != target.TtlItdedStcInTax)resList.Add("TtlItdedStcInTax");
			if(this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree)resList.Add("TtlItdedStcTaxFree");
			if(this.StockOutTax != target.StockOutTax)resList.Add("StockOutTax");
			if(this.StckPrcConsTaxInclu != target.StckPrcConsTaxInclu)resList.Add("StckPrcConsTaxInclu");
			if(this.StckDisTtlTaxExc != target.StckDisTtlTaxExc)resList.Add("StckDisTtlTaxExc");
			if(this.ItdedStockDisOutTax != target.ItdedStockDisOutTax)resList.Add("ItdedStockDisOutTax");
			if(this.ItdedStockDisInTax != target.ItdedStockDisInTax)resList.Add("ItdedStockDisInTax");
			if(this.ItdedStockDisTaxFre != target.ItdedStockDisTaxFre)resList.Add("ItdedStockDisTaxFre");
			if(this.StockDisOutTax != target.StockDisOutTax)resList.Add("StockDisOutTax");
			if(this.StckDisTtlTaxInclu != target.StckDisTtlTaxInclu)resList.Add("StckDisTtlTaxInclu");
			if(this.TaxAdjust != target.TaxAdjust)resList.Add("TaxAdjust");
			if(this.BalanceAdjust != target.BalanceAdjust)resList.Add("BalanceAdjust");
			if(this.SuppCTaxLayCd != target.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(this.SupplierConsTaxRate != target.SupplierConsTaxRate)resList.Add("SupplierConsTaxRate");
			if(this.AccPayConsTax != target.AccPayConsTax)resList.Add("AccPayConsTax");
			if(this.StockFractionProcCd != target.StockFractionProcCd)resList.Add("StockFractionProcCd");
			if(this.AutoPayment != target.AutoPayment)resList.Add("AutoPayment");
			if(this.AutoPaySlipNum != target.AutoPaySlipNum)resList.Add("AutoPaySlipNum");
			if(this.RetGoodsReasonDiv != target.RetGoodsReasonDiv)resList.Add("RetGoodsReasonDiv");
			if(this.RetGoodsReason != target.RetGoodsReason)resList.Add("RetGoodsReason");
			if(this.PartySaleSlipNum != target.PartySaleSlipNum)resList.Add("PartySaleSlipNum");
			if(this.SupplierSlipNote1 != target.SupplierSlipNote1)resList.Add("SupplierSlipNote1");
			if(this.SupplierSlipNote2 != target.SupplierSlipNote2)resList.Add("SupplierSlipNote2");
            // ADD 2011/11/30 gezh redmine#8383 ---------------->>>>>
            if (this.SupplierSlipNoteNo1 != target.SupplierSlipNoteNo1) resList.Add("SupplierSlipNoteNo1");
            if (this.SupplierSlipNoteNo2 != target.SupplierSlipNoteNo2) resList.Add("SupplierSlipNoteNo2");
            // ADD 2011/11/30 gezh redmine#8383 ----------------<<<<<
			if(this.DetailRowCount != target.DetailRowCount)resList.Add("DetailRowCount");
			if(this.EdiSendDate != target.EdiSendDate)resList.Add("EdiSendDate");
			if(this.EdiTakeInDate != target.EdiTakeInDate)resList.Add("EdiTakeInDate");
			if(this.UoeRemark1 != target.UoeRemark1)resList.Add("UoeRemark1");
			if(this.UoeRemark2 != target.UoeRemark2)resList.Add("UoeRemark2");
			if(this.SlipPrintDivCd != target.SlipPrintDivCd)resList.Add("SlipPrintDivCd");
			if(this.SlipPrintFinishCd != target.SlipPrintFinishCd)resList.Add("SlipPrintFinishCd");
			if(this.StockSlipPrintDate != target.StockSlipPrintDate)resList.Add("StockSlipPrintDate");
			if(this.SlipPrtSetPaperId != target.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(this.SlipAddressDiv != target.SlipAddressDiv)resList.Add("SlipAddressDiv");
			if(this.AddresseeCode != target.AddresseeCode)resList.Add("AddresseeCode");
			if(this.AddresseeName != target.AddresseeName)resList.Add("AddresseeName");
			if(this.AddresseeName2 != target.AddresseeName2)resList.Add("AddresseeName2");
			if(this.AddresseePostNo != target.AddresseePostNo)resList.Add("AddresseePostNo");
			if(this.AddresseeAddr1 != target.AddresseeAddr1)resList.Add("AddresseeAddr1");
			if(this.AddresseeAddr3 != target.AddresseeAddr3)resList.Add("AddresseeAddr3");
			if(this.AddresseeAddr4 != target.AddresseeAddr4)resList.Add("AddresseeAddr4");
			if(this.AddresseeTelNo != target.AddresseeTelNo)resList.Add("AddresseeTelNo");
			if(this.AddresseeFaxNo != target.AddresseeFaxNo)resList.Add("AddresseeFaxNo");
			if(this.DirectSendingCd != target.DirectSendingCd)resList.Add("DirectSendingCd");
			if(this.SupplierSlipDisplay != target.SupplierSlipDisplay)resList.Add("SupplierSlipDisplay");
			if(this.SuppRateGrpCode != target.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.InputMode != target.InputMode)resList.Add("InputMode");
			if(this.PayeeName != target.PayeeName)resList.Add("PayeeName");
			if(this.PayeeName2 != target.PayeeName2)resList.Add("PayeeName2");
			if(this.NTimeCalcStDate != target.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(this.PaymentTotalDay != target.PaymentTotalDay)resList.Add("PaymentTotalDay");
			if(this.PriceCostUpdtDiv != target.PriceCostUpdtDiv)resList.Add("PriceCostUpdtDiv");
			if(this.SubSectionName != target.SubSectionName)resList.Add("SubSectionName");
			if(this.SectionGuideNm != target.SectionGuideNm)resList.Add("SectionGuideNm");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.StockSectionNm != target.StockSectionNm)resList.Add("StockSectionNm");
			if(this.StockAddUpSectionNm != target.StockAddUpSectionNm)resList.Add("StockAddUpSectionNm");
			if(this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
		}

		/// <summary>
		/// 仕入データ比較処理
		/// </summary>
		/// <param name="stockSlip1">比較するStockSlipクラスのインスタンス</param>
		/// <param name="stockSlip2">比較するStockSlipクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSlipクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockSlip stockSlip1, StockSlip stockSlip2)
		{
			ArrayList resList = new ArrayList();
			if(stockSlip1.CreateDateTime != stockSlip2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockSlip1.UpdateDateTime != stockSlip2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockSlip1.EnterpriseCode != stockSlip2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockSlip1.FileHeaderGuid != stockSlip2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockSlip1.UpdEmployeeCode != stockSlip2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockSlip1.UpdAssemblyId1 != stockSlip2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockSlip1.UpdAssemblyId2 != stockSlip2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockSlip1.LogicalDeleteCode != stockSlip2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockSlip1.SupplierFormal != stockSlip2.SupplierFormal)resList.Add("SupplierFormal");
			if(stockSlip1.SupplierSlipNo != stockSlip2.SupplierSlipNo)resList.Add("SupplierSlipNo");
			if(stockSlip1.SectionCode != stockSlip2.SectionCode)resList.Add("SectionCode");
			if(stockSlip1.SubSectionCode != stockSlip2.SubSectionCode)resList.Add("SubSectionCode");
			if(stockSlip1.DebitNoteDiv != stockSlip2.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(stockSlip1.DebitNLnkSuppSlipNo != stockSlip2.DebitNLnkSuppSlipNo)resList.Add("DebitNLnkSuppSlipNo");
			if(stockSlip1.SupplierSlipCd != stockSlip2.SupplierSlipCd)resList.Add("SupplierSlipCd");
			if(stockSlip1.StockGoodsCd != stockSlip2.StockGoodsCd)resList.Add("StockGoodsCd");
			if(stockSlip1.AccPayDivCd != stockSlip2.AccPayDivCd)resList.Add("AccPayDivCd");
			if(stockSlip1.StockSectionCd != stockSlip2.StockSectionCd)resList.Add("StockSectionCd");
			if(stockSlip1.StockAddUpSectionCd != stockSlip2.StockAddUpSectionCd)resList.Add("StockAddUpSectionCd");
			if(stockSlip1.StockSlipUpdateCd != stockSlip2.StockSlipUpdateCd)resList.Add("StockSlipUpdateCd");
			if(stockSlip1.InputDay != stockSlip2.InputDay)resList.Add("InputDay");
			if(stockSlip1.ArrivalGoodsDay != stockSlip2.ArrivalGoodsDay)resList.Add("ArrivalGoodsDay");
			if(stockSlip1.StockDate != stockSlip2.StockDate)resList.Add("StockDate");
            if (stockSlip1.PreStockDate != stockSlip2.PreStockDate) resList.Add("PreStockDate"); // ADD 2011/12/15
			if(stockSlip1.StockAddUpADate != stockSlip2.StockAddUpADate)resList.Add("StockAddUpADate");
			if(stockSlip1.DelayPaymentDiv != stockSlip2.DelayPaymentDiv)resList.Add("DelayPaymentDiv");
			if(stockSlip1.PayeeCode != stockSlip2.PayeeCode)resList.Add("PayeeCode");
			if(stockSlip1.PayeeSnm != stockSlip2.PayeeSnm)resList.Add("PayeeSnm");
			if(stockSlip1.SupplierCd != stockSlip2.SupplierCd)resList.Add("SupplierCd");
			if(stockSlip1.SupplierNm1 != stockSlip2.SupplierNm1)resList.Add("SupplierNm1");
			if(stockSlip1.SupplierNm2 != stockSlip2.SupplierNm2)resList.Add("SupplierNm2");
			if(stockSlip1.SupplierSnm != stockSlip2.SupplierSnm)resList.Add("SupplierSnm");
			if(stockSlip1.BusinessTypeCode != stockSlip2.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(stockSlip1.BusinessTypeName != stockSlip2.BusinessTypeName)resList.Add("BusinessTypeName");
			if(stockSlip1.SalesAreaCode != stockSlip2.SalesAreaCode)resList.Add("SalesAreaCode");
			if(stockSlip1.SalesAreaName != stockSlip2.SalesAreaName)resList.Add("SalesAreaName");
			if(stockSlip1.StockInputCode != stockSlip2.StockInputCode)resList.Add("StockInputCode");
			if(stockSlip1.StockInputName != stockSlip2.StockInputName)resList.Add("StockInputName");
			if(stockSlip1.StockAgentCode != stockSlip2.StockAgentCode)resList.Add("StockAgentCode");
			if(stockSlip1.StockAgentName != stockSlip2.StockAgentName)resList.Add("StockAgentName");
			if(stockSlip1.SuppTtlAmntDspWayCd != stockSlip2.SuppTtlAmntDspWayCd)resList.Add("SuppTtlAmntDspWayCd");
			if(stockSlip1.TtlAmntDispRateApy != stockSlip2.TtlAmntDispRateApy)resList.Add("TtlAmntDispRateApy");
			if(stockSlip1.StockTotalPrice != stockSlip2.StockTotalPrice)resList.Add("StockTotalPrice");
			if(stockSlip1.StockSubttlPrice != stockSlip2.StockSubttlPrice)resList.Add("StockSubttlPrice");
			if(stockSlip1.StockTtlPricTaxInc != stockSlip2.StockTtlPricTaxInc)resList.Add("StockTtlPricTaxInc");
			if(stockSlip1.StockTtlPricTaxExc != stockSlip2.StockTtlPricTaxExc)resList.Add("StockTtlPricTaxExc");
			if(stockSlip1.StockNetPrice != stockSlip2.StockNetPrice)resList.Add("StockNetPrice");
			if(stockSlip1.StockPriceConsTax != stockSlip2.StockPriceConsTax)resList.Add("StockPriceConsTax");
			if(stockSlip1.TtlItdedStcOutTax != stockSlip2.TtlItdedStcOutTax)resList.Add("TtlItdedStcOutTax");
			if(stockSlip1.TtlItdedStcInTax != stockSlip2.TtlItdedStcInTax)resList.Add("TtlItdedStcInTax");
			if(stockSlip1.TtlItdedStcTaxFree != stockSlip2.TtlItdedStcTaxFree)resList.Add("TtlItdedStcTaxFree");
			if(stockSlip1.StockOutTax != stockSlip2.StockOutTax)resList.Add("StockOutTax");
			if(stockSlip1.StckPrcConsTaxInclu != stockSlip2.StckPrcConsTaxInclu)resList.Add("StckPrcConsTaxInclu");
			if(stockSlip1.StckDisTtlTaxExc != stockSlip2.StckDisTtlTaxExc)resList.Add("StckDisTtlTaxExc");
			if(stockSlip1.ItdedStockDisOutTax != stockSlip2.ItdedStockDisOutTax)resList.Add("ItdedStockDisOutTax");
			if(stockSlip1.ItdedStockDisInTax != stockSlip2.ItdedStockDisInTax)resList.Add("ItdedStockDisInTax");
			if(stockSlip1.ItdedStockDisTaxFre != stockSlip2.ItdedStockDisTaxFre)resList.Add("ItdedStockDisTaxFre");
			if(stockSlip1.StockDisOutTax != stockSlip2.StockDisOutTax)resList.Add("StockDisOutTax");
			if(stockSlip1.StckDisTtlTaxInclu != stockSlip2.StckDisTtlTaxInclu)resList.Add("StckDisTtlTaxInclu");
			if(stockSlip1.TaxAdjust != stockSlip2.TaxAdjust)resList.Add("TaxAdjust");
			if(stockSlip1.BalanceAdjust != stockSlip2.BalanceAdjust)resList.Add("BalanceAdjust");
			if(stockSlip1.SuppCTaxLayCd != stockSlip2.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(stockSlip1.SupplierConsTaxRate != stockSlip2.SupplierConsTaxRate)resList.Add("SupplierConsTaxRate");
			if(stockSlip1.AccPayConsTax != stockSlip2.AccPayConsTax)resList.Add("AccPayConsTax");
			if(stockSlip1.StockFractionProcCd != stockSlip2.StockFractionProcCd)resList.Add("StockFractionProcCd");
			if(stockSlip1.AutoPayment != stockSlip2.AutoPayment)resList.Add("AutoPayment");
			if(stockSlip1.AutoPaySlipNum != stockSlip2.AutoPaySlipNum)resList.Add("AutoPaySlipNum");
			if(stockSlip1.RetGoodsReasonDiv != stockSlip2.RetGoodsReasonDiv)resList.Add("RetGoodsReasonDiv");
			if(stockSlip1.RetGoodsReason != stockSlip2.RetGoodsReason)resList.Add("RetGoodsReason");
			if(stockSlip1.PartySaleSlipNum != stockSlip2.PartySaleSlipNum)resList.Add("PartySaleSlipNum");
			if(stockSlip1.SupplierSlipNote1 != stockSlip2.SupplierSlipNote1)resList.Add("SupplierSlipNote1");
			if(stockSlip1.SupplierSlipNote2 != stockSlip2.SupplierSlipNote2)resList.Add("SupplierSlipNote2");
            // ADD 2011/11/30 gezh redmine#8383 ---------------->>>>>
            if (stockSlip1.SupplierSlipNoteNo1 != stockSlip2.SupplierSlipNoteNo1) resList.Add("SupplierSlipNoteNo1");
            if (stockSlip1.SupplierSlipNoteNo2 != stockSlip2.SupplierSlipNoteNo2) resList.Add("SupplierSlipNoteNo2");
            // ADD 2011/11/30 gezh redmine#8383 ----------------<<<<<
			if(stockSlip1.DetailRowCount != stockSlip2.DetailRowCount)resList.Add("DetailRowCount");
			if(stockSlip1.EdiSendDate != stockSlip2.EdiSendDate)resList.Add("EdiSendDate");
			if(stockSlip1.EdiTakeInDate != stockSlip2.EdiTakeInDate)resList.Add("EdiTakeInDate");
			if(stockSlip1.UoeRemark1 != stockSlip2.UoeRemark1)resList.Add("UoeRemark1");
			if(stockSlip1.UoeRemark2 != stockSlip2.UoeRemark2)resList.Add("UoeRemark2");
			if(stockSlip1.SlipPrintDivCd != stockSlip2.SlipPrintDivCd)resList.Add("SlipPrintDivCd");
			if(stockSlip1.SlipPrintFinishCd != stockSlip2.SlipPrintFinishCd)resList.Add("SlipPrintFinishCd");
			if(stockSlip1.StockSlipPrintDate != stockSlip2.StockSlipPrintDate)resList.Add("StockSlipPrintDate");
			if(stockSlip1.SlipPrtSetPaperId != stockSlip2.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(stockSlip1.SlipAddressDiv != stockSlip2.SlipAddressDiv)resList.Add("SlipAddressDiv");
			if(stockSlip1.AddresseeCode != stockSlip2.AddresseeCode)resList.Add("AddresseeCode");
			if(stockSlip1.AddresseeName != stockSlip2.AddresseeName)resList.Add("AddresseeName");
			if(stockSlip1.AddresseeName2 != stockSlip2.AddresseeName2)resList.Add("AddresseeName2");
			if(stockSlip1.AddresseePostNo != stockSlip2.AddresseePostNo)resList.Add("AddresseePostNo");
			if(stockSlip1.AddresseeAddr1 != stockSlip2.AddresseeAddr1)resList.Add("AddresseeAddr1");
			if(stockSlip1.AddresseeAddr3 != stockSlip2.AddresseeAddr3)resList.Add("AddresseeAddr3");
			if(stockSlip1.AddresseeAddr4 != stockSlip2.AddresseeAddr4)resList.Add("AddresseeAddr4");
			if(stockSlip1.AddresseeTelNo != stockSlip2.AddresseeTelNo)resList.Add("AddresseeTelNo");
			if(stockSlip1.AddresseeFaxNo != stockSlip2.AddresseeFaxNo)resList.Add("AddresseeFaxNo");
			if(stockSlip1.DirectSendingCd != stockSlip2.DirectSendingCd)resList.Add("DirectSendingCd");
			if(stockSlip1.SupplierSlipDisplay != stockSlip2.SupplierSlipDisplay)resList.Add("SupplierSlipDisplay");
			if(stockSlip1.SuppRateGrpCode != stockSlip2.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(stockSlip1.WarehouseCode != stockSlip2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockSlip1.WarehouseName != stockSlip2.WarehouseName)resList.Add("WarehouseName");
			if(stockSlip1.InputMode != stockSlip2.InputMode)resList.Add("InputMode");
			if(stockSlip1.PayeeName != stockSlip2.PayeeName)resList.Add("PayeeName");
			if(stockSlip1.PayeeName2 != stockSlip2.PayeeName2)resList.Add("PayeeName2");
			if(stockSlip1.NTimeCalcStDate != stockSlip2.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(stockSlip1.PaymentTotalDay != stockSlip2.PaymentTotalDay)resList.Add("PaymentTotalDay");
			if(stockSlip1.PriceCostUpdtDiv != stockSlip2.PriceCostUpdtDiv)resList.Add("PriceCostUpdtDiv");
			if(stockSlip1.SubSectionName != stockSlip2.SubSectionName)resList.Add("SubSectionName");
			if(stockSlip1.SectionGuideNm != stockSlip2.SectionGuideNm)resList.Add("SectionGuideNm");
			if(stockSlip1.EnterpriseName != stockSlip2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockSlip1.UpdEmployeeName != stockSlip2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockSlip1.StockSectionNm != stockSlip2.StockSectionNm)resList.Add("StockSectionNm");
			if(stockSlip1.StockAddUpSectionNm != stockSlip2.StockAddUpSectionNm)resList.Add("StockAddUpSectionNm");
			if(stockSlip1.SuppCTaxLayMethodNm != stockSlip2.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
		}
	}
}
