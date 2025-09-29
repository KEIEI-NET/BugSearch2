using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RsltInfo_EBooksDemandTotalWork
	/// <summary>
	///                      請求書(鑑部)抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書(鑑部)抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer       :   3H 仰亮亮</br>
    /// <br>Date             :   2022/10/27</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RsltInfo_EBooksDemandTotalWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>計上拠点名称</summary>
		/// <remarks>拠点情報設定マスタから取得</remarks>
		private string _addUpSecName = "";

		/// <summary>請求先コード</summary>
		/// <remarks>請求先の親コード</remarks>
		private Int32 _claimCode;

		/// <summary>請求先名称</summary>
		private string _claimName = "";

		/// <summary>請求先名称2</summary>
		private string _claimName2 = "";

		/// <summary>請求先略称</summary>
		private string _claimSnm = "";

		/// <summary>請求先名称カナ</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _claimNameKana = "";

		/// <summary>郵便番号</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _postNo = "";

		/// <summary>住所1（都道府県市区郡・町村・字）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _address1 = "";

		/// <summary>住所2（丁目）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private Int32 _address2;

		/// <summary>住所3（番地）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _address3 = "";

		/// <summary>住所4（アパート名称）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _address4 = "";

		/// <summary>集金月区分コード</summary>
		/// <remarks>得意先マスタから取得 0:当月,1:翌月,2:翌々月</remarks>
		private Int32 _collectMoneyCode;

		/// <summary>集金月区分名称</summary>
		/// <remarks>得意先マスタから取得 当月,翌月,翌々月</remarks>
		private string _collectMoneyName = "";

		/// <summary>集金日</summary>
		/// <remarks>得意先マスタから取得 DD</remarks>
		private Int32 _collectMoneyDay;

		/// <summary>敬称</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _honorificTitle = "";

		/// <summary>電話番号（自宅）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _homeTelNo = "";

		/// <summary>電話番号（勤務先）</summary>
		/// <remarks>得意先マスタから取得 納入先の場合の使用可能項目</remarks>
		private string _officeTelNo = "";

		/// <summary>電話番号（携帯）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _portableTelNo = "";

		/// <summary>FAX番号（自宅）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _homeFaxNo = "";

		/// <summary>FAX番号（勤務先）</summary>
		/// <remarks>得意先マスタから取得 納入先の場合の使用可能項目</remarks>
		private string _officeFaxNo = "";

		/// <summary>電話番号（その他）</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _othersTelNo = "";

		/// <summary>主連絡先区分</summary>
		/// <remarks>得意先マスタから取得 0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</remarks>
		private Int32 _mainContactCode;

		/// <summary>締日</summary>
		/// <remarks>得意先マスタから取得 DD</remarks>
		private Int32 _totalDay;

		/// <summary>顧客担当従業員コード</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _customerAgentCd = "";

		/// <summary>顧客担当従業員名称</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _customerAgentNm = "";

		/// <summary>集金担当従業員コード</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _billCollecterCd = "";

		/// <summary>集金担当従業員名称</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _billCollecterNm = "";

		/// <summary>消費税転嫁方式</summary>
		/// <remarks>得意先マスタから取得 0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>総額表示方法区分</summary>
		/// <remarks>得意先マスタから取得 0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>総額表示方法参照区分</summary>
		/// <remarks>得意先マスタから取得 0:全体設定参照 1:得意先参照</remarks>
		private Int32 _totalAmntDspWayRef;

		/// <summary>売上消費税端数処理コード</summary>
		/// <remarks>得意先マスタから取得 0の場合は 標準設定とする。</remarks>
		private Int32 _salesCnsTaxFrcProcCd;

		/// <summary>銀行口座1</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _accountNoInfo1 = "";

		/// <summary>銀行口座2</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _accountNoInfo2 = "";

		/// <summary>銀行口座3</summary>
		/// <remarks>得意先マスタから取得</remarks>
		private string _accountNoInfo3 = "";

		/// <summary>個人・法人区分</summary>
		/// <remarks>得意先マスタから取得 0:個人,1:法人,2:大口法人,3:業者,4:社員</remarks>
		private Int32 _corporateDivCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
		private DateTime _addUpDate;

		/// <summary>計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>前回請求金額</summary>
		private Int64 _lastTimeDemand;

		/// <summary>今回手数料額（通常入金）</summary>
		private Int64 _thisTimeFeeDmdNrml;

		/// <summary>今回値引額（通常入金）</summary>
		private Int64 _thisTimeDisDmdNrml;

		/// <summary>今回入金金額（通常入金）</summary>
		/// <remarks>入金額の合計金額</remarks>
		private Int64 _thisTimeDmdNrml;

		/// <summary>今回繰越残高（請求計）</summary>
		/// <remarks>今回繰越残高＝前回請求額－今回入金額合計（通常）</remarks>
		private Int64 _thisTimeTtlBlcDmd;

		/// <summary>相殺後今回売上金額</summary>
		private Int64 _ofsThisTimeSales;

		/// <summary>相殺後今回売上消費税</summary>
		private Int64 _ofsThisSalesTax;

		/// <summary>相殺後外税対象額</summary>
		/// <remarks>相殺用：外税額（税抜き）の集計</remarks>
		private Int64 _itdedOffsetOutTax;

		/// <summary>相殺後内税対象額</summary>
		/// <remarks>相殺用：内税額（税抜き）の集計</remarks>
		private Int64 _itdedOffsetInTax;

		/// <summary>相殺後非課税対象額</summary>
		/// <remarks>相殺用：非課税額の集計</remarks>
		private Int64 _itdedOffsetTaxFree;

		/// <summary>相殺後外税消費税</summary>
		/// <remarks>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
		private Int64 _offsetOutTax;

		/// <summary>相殺後内税消費税</summary>
		/// <remarks>相殺用：内税消費税の集計</remarks>
		private Int64 _offsetInTax;

		/// <summary>今回売上金額</summary>
		/// <remarks>掛売：値引、返品を含まない税抜きの売上金額</remarks>
		private Int64 _thisTimeSales;

		/// <summary>今回売上消費税</summary>
		private Int64 _thisSalesTax;

		/// <summary>売上外税対象額</summary>
		/// <remarks>請求用：外税額（税抜き）の集計</remarks>
		private Int64 _itdedSalesOutTax;

		/// <summary>売上内税対象額</summary>
		/// <remarks>請求用：内税額（税抜き）の集計</remarks>
		private Int64 _itdedSalesInTax;

		/// <summary>売上非課税対象額</summary>
		/// <remarks>請求用：非課税額の集計</remarks>
		private Int64 _itdedSalesTaxFree;

		/// <summary>売上外税額</summary>
		/// <remarks>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
		private Int64 _salesOutTax;

		/// <summary>売上内税額</summary>
		/// <remarks>掛売：内税商品売上の内税消費税額（返品、値引含まず）</remarks>
		private Int64 _salesInTax;

		/// <summary>今回売上返品金額</summary>
		/// <remarks>掛売：値引を含まない税抜きの売上返品金額</remarks>
		private Int64 _thisSalesPricRgds;

		/// <summary>今回売上返品消費税</summary>
		/// <remarks>今回売上返品消費税＝返品外税額合計＋返品内税額合計</remarks>
		private Int64 _thisSalesPrcTaxRgds;

		/// <summary>返品外税対象額合計</summary>
		private Int64 _ttlItdedRetOutTax;

		/// <summary>返品内税対象額合計</summary>
		private Int64 _ttlItdedRetInTax;

		/// <summary>返品非課税対象額合計</summary>
		private Int64 _ttlItdedRetTaxFree;

		/// <summary>返品外税額合計</summary>
		private Int64 _ttlRetOuterTax;

		/// <summary>返品内税額合計</summary>
		/// <remarks>掛売：内税商品返品の内税消費税額（値引含まず）</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>今回売上値引金額</summary>
		/// <remarks>掛売：税抜きの売上値引金額</remarks>
		private Int64 _thisSalesPricDis;

		/// <summary>今回売上値引消費税</summary>
		/// <remarks>今回売上値引消費税＝値引外税額合計＋値引内税額合計</remarks>
		private Int64 _thisSalesPrcTaxDis;

		/// <summary>値引外税対象額合計</summary>
		private Int64 _ttlItdedDisOutTax;

		/// <summary>値引内税対象額合計</summary>
		private Int64 _ttlItdedDisInTax;

		/// <summary>値引非課税対象額合計</summary>
		private Int64 _ttlItdedDisTaxFree;

		/// <summary>値引外税額合計</summary>
		private Int64 _ttlDisOuterTax;

		/// <summary>値引内税額合計</summary>
		/// <remarks>掛売：内税商品返品の内税消費税額</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>今回支払相殺金額</summary>
		/// <remarks>相殺用伝票：相殺用売上伝票計（相殺対象額）</remarks>
		private Int64 _thisPayOffset;

		/// <summary>今回支払相殺消費税</summary>
		/// <remarks>相殺用伝票：相殺用売上消費税合計</remarks>
		private Int64 _thisPayOffsetTax;

		/// <summary>支払外税対象額</summary>
		/// <remarks>相殺用伝票：外税額（税抜き）の集計</remarks>
		private Int64 _itdedPaymOutTax;

		/// <summary>支払内税対象額</summary>
		/// <remarks>相殺用伝票：内税額（税抜き）の集計</remarks>
		private Int64 _itdedPaymInTax;

		/// <summary>支払非課税対象額</summary>
		/// <remarks>相殺用伝票：非課税額の集計</remarks>
		private Int64 _itdedPaymTaxFree;

		/// <summary>支払外税消費税</summary>
		/// <remarks>相殺用伝票：外税消費税の集計</remarks>
		private Int64 _paymentOutTax;

		/// <summary>支払内税消費税</summary>
		/// <remarks>相殺用伝票：内税消費税の集計</remarks>
		private Int64 _paymentInTax;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>計算後請求金額</summary>
		/// <remarks>今回請求金額</remarks>
		private Int64 _afCalDemandPrice;

		/// <summary>受注2回前残高（請求計）</summary>
		private Int64 _acpOdrTtl2TmBfBlDmd;

		/// <summary>受注3回前残高（請求計）</summary>
		private Int64 _acpOdrTtl3TmBfBlDmd;

		/// <summary>締次更新実行年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>締次更新開始年月日</summary>
		/// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
		private DateTime _startCAddUpUpdDate;

		/// <summary>前回締次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>売上伝票枚数</summary>
		/// <remarks>掛売の伝票枚数</remarks>
		private Int32 _salesSlipCount;

		/// <summary>請求書発行日</summary>
		/// <remarks>"YYYYMMDD"  請求書を発行した年月日</remarks>
		private DateTime _billPrintDate;

		/// <summary>入金予定日</summary>
		private DateTime _expectedDepositDate;

		/// <summary>回収条件</summary>
		/// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
		private Int32 _collectCond;

		/// <summary>消費税率</summary>
		/// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
		private Double _consTaxRate;

		/// <summary>端数処理区分</summary>
		private Int32 _fractionProcCd;

		/// <summary>金種コードリスト</summary>
		/// <remarks>(金種コード、金種名称、金種区分、入金金額）</remarks>
		private ArrayList _moneyKindList;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>伝票印刷設定用</remarks>
		private string _slipPrtSetPaperId = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        /// <remarks>ガイドマスタから取得</remarks>
        private string _salesAreaName = "";

        /// <summary>請求拠点コード</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private string _claimSectionCode = "";

        /// <summary>実績拠点コード</summary>
        /// <remarks>実績集計の対象となっている拠点コード</remarks>
        private string _resultsSectCd = "";

        /// <summary>請求書出力区分コード</summary>
        /// <remarks>0:請求書発行する,1:しない</remarks>
        private Int32 _billOutputCode;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>領収書出力区分コード</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _receiptOutputCode;

        /// <summary>合計請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>明細請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>伝票合計請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _slipTtlBillOutputDiv;

        /// <summary>税率1タイトル</summary>
        /// <remarks>税率1タイトル</remarks>
        private string _titleTaxRate1 = string.Empty;

        /// <summary>税率2タイトル</summary>
        /// <remarks>税率2タイトル</remarks>
        private string _titleTaxRate2 = string.Empty;

        /// <summary>売上額(計税率1)</summary>
        /// <remarks>売上額(計税率1)</remarks>
        private Int64 _totalThisTimeSalesTaxRate1;

        /// <summary>売上額(計税率2)</summary>
        /// <remarks>売上額(計税率2)</remarks>
        private Int64 _totalThisTimeSalesTaxRate2;

        /// <summary>売上額(計その他)</summary>
        /// <remarks>売上額(計その他)</remarks>
        private Int64 _totalThisTimeSalesOther;

        /// <summary>返品値引(計税率1)</summary>
        /// <remarks>返品値引(計税率1)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate1;

        /// <summary>返品値引(計税率2)</summary>
        /// <remarks>返品値引(計税率2)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate2;

        /// <summary>返品値引(計その他)</summary>
        /// <remarks>返品値引(計その他)</remarks>
        private Int64 _totalThisRgdsDisPricOther;

        /// <summary>純売上額(計税率1)</summary>
        /// <remarks>純売上額(計税率1)</remarks>
        private Int64 _totalPureSalesTaxRate1;

        /// <summary>純売上額(計税率2)</summary>
        /// <remarks>純売上額(計税率2)</remarks>
        private Int64 _totalPureSalesTaxRate2;

        /// <summary>純売上額(計その他)</summary>
        /// <remarks>純売上額(計その他)</remarks>
        private Int64 _totalPureSalesOther;

        /// <summary>消費税(計税率1)</summary>
        /// <remarks>消費税(計税率1)</remarks>
        private Int64 _totalSalesPricTaxTaxRate1;

        /// <summary>消費税(計税率2)</summary>
        /// <remarks>消費税(計税率2)</remarks>
        private Int64 _totalSalesPricTaxTaxRate2;

        /// <summary>消費税(計その他)</summary>
        /// <remarks>消費税(計その他)</remarks>
        private Int64 _totalSalesPricTaxOther;

        /// <summary>今回合計(計税率1)</summary>
        /// <remarks>今回合計(計税率1)</remarks>
        private Int64 _totalThisSalesSumTaxRate1;

        /// <summary>今回合計(計税率2)</summary>
        /// <remarks>今回合計(計税率2)</remarks>
        private Int64 _totalThisSalesSumTaxRate2;

        /// <summary>今回合計(計その他)</summary>
        /// <remarks>今回合計(計その他)</remarks>
        private Int64 _totalThisSalesSumTaxOther;

        /// <summary>枚数(計税率1)</summary>
        /// <remarks>枚数(計税率1)</remarks>
        private Int32 _totalSalesSlipCountTaxRate1;

        /// <summary>枚数(計税率2)</summary>
        /// <remarks>枚数(計税率2)</remarks>
        private Int32 _totalSalesSlipCountTaxRate2;

        /// <summary>枚数(計その他)</summary>
        /// <remarks>枚数(計その他)</remarks>
        private Int32 _totalSalesSlipCountOther;

        // --- ADD START 3H 仰亮亮 2022/10/27 ----->>>>>
        /// <summary>売上額(非課税)</summary>
        /// <remarks>売上額(非課税)</remarks>
        private Int64 _totalThisTimeSalesTaxFree;

        /// <summary>返品値引(非課税)</summary>
        /// <remarks>返品値引(非課税)</remarks>
        private Int64 _totalThisRgdsDisPricTaxFree;

        /// <summary>純売上額(非課税)</summary>
        /// <remarks>純売上額(非課税)</remarks>
        private Int64 _totalPureSalesTaxFree;

        /// <summary>消費税(非課税)</summary>
        /// <remarks>消費税(非課税)</remarks>
        private Int64 _totalSalesPricTaxTaxFree;

        /// <summary>今回合計(非課税)</summary>
        /// <remarks>今回合計(非課税)</remarks>
        private Int64 _totalThisSalesSumTaxFree;

        /// <summary>枚数(非課税)</summary>
        /// <remarks>枚数(非課税)</remarks>
        private Int32 _totalSalesSlipCountTaxFree;
        // --- ADD END 3H 仰亮亮 2022/10/27 -----<<<<<

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

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>計上拠点名称プロパティ</summary>
		/// <value>拠点情報設定マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>請求先コードプロパティ</summary>
		/// <value>請求先の親コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  ClaimName
		/// <summary>請求先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimName
		{
			get{return _claimName;}
			set{_claimName = value;}
		}

		/// public propaty name  :  ClaimName2
		/// <summary>請求先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimName2
		{
			get{return _claimName2;}
			set{_claimName2 = value;}
		}

		/// public propaty name  :  ClaimSnm
		/// <summary>請求先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimSnm
		{
			get{return _claimSnm;}
			set{_claimSnm = value;}
		}

		/// public propaty name  :  ClaimNameKana
		/// <summary>請求先名称カナプロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimNameKana
		{
			get{return _claimNameKana;}
			set{_claimNameKana = value;}
		}

		/// public propaty name  :  PostNo
		/// <summary>郵便番号プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PostNo
		{
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  Address1
		/// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address1
		{
			get{return _address1;}
			set{_address1 = value;}
		}

		/// public propaty name  :  Address2
		/// <summary>住所2（丁目）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所2（丁目）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Address2
		{
			get{return _address2;}
			set{_address2 = value;}
		}

		/// public propaty name  :  Address3
		/// <summary>住所3（番地）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所3（番地）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address3
		{
			get{return _address3;}
			set{_address3 = value;}
		}

		/// public propaty name  :  Address4
		/// <summary>住所4（アパート名称）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所4（アパート名称）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address4
		{
			get{return _address4;}
			set{_address4 = value;}
		}

		/// public propaty name  :  CollectMoneyCode
		/// <summary>集金月区分コードプロパティ</summary>
		/// <value>得意先マスタから取得 0:当月,1:翌月,2:翌々月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金月区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CollectMoneyCode
		{
			get{return _collectMoneyCode;}
			set{_collectMoneyCode = value;}
		}

		/// public propaty name  :  CollectMoneyName
		/// <summary>集金月区分名称プロパティ</summary>
		/// <value>得意先マスタから取得 当月,翌月,翌々月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金月区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CollectMoneyName
		{
			get{return _collectMoneyName;}
			set{_collectMoneyName = value;}
		}

		/// public propaty name  :  CollectMoneyDay
		/// <summary>集金日プロパティ</summary>
		/// <value>得意先マスタから取得 DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CollectMoneyDay
		{
			get{return _collectMoneyDay;}
			set{_collectMoneyDay = value;}
		}

		/// public propaty name  :  HonorificTitle
		/// <summary>敬称プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   敬称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HonorificTitle
		{
			get{return _honorificTitle;}
			set{_honorificTitle = value;}
		}

		/// public propaty name  :  HomeTelNo
		/// <summary>電話番号（自宅）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（自宅）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeTelNo
		{
			get{return _homeTelNo;}
			set{_homeTelNo = value;}
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>電話番号（勤務先）プロパティ</summary>
		/// <value>得意先マスタから取得 納入先の場合の使用可能項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get{return _officeTelNo;}
			set{_officeTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>電話番号（携帯）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（携帯）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  HomeFaxNo
		/// <summary>FAX番号（自宅）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX番号（自宅）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeFaxNo
		{
			get{return _homeFaxNo;}
			set{_homeFaxNo = value;}
		}

		/// public propaty name  :  OfficeFaxNo
		/// <summary>FAX番号（勤務先）プロパティ</summary>
		/// <value>得意先マスタから取得 納入先の場合の使用可能項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeFaxNo
		{
			get{return _officeFaxNo;}
			set{_officeFaxNo = value;}
		}

		/// public propaty name  :  OthersTelNo
		/// <summary>電話番号（その他）プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（その他）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OthersTelNo
		{
			get{return _othersTelNo;}
			set{_othersTelNo = value;}
		}

		/// public propaty name  :  MainContactCode
		/// <summary>主連絡先区分プロパティ</summary>
		/// <value>得意先マスタから取得 0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   主連絡先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MainContactCode
		{
			get{return _mainContactCode;}
			set{_mainContactCode = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>得意先マスタから取得 DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  CustomerAgentCd
		/// <summary>顧客担当従業員コードプロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgentCd
		{
			get{return _customerAgentCd;}
			set{_customerAgentCd = value;}
		}

		/// public propaty name  :  CustomerAgentNm
		/// <summary>顧客担当従業員名称プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgentNm
		{
			get{return _customerAgentNm;}
			set{_customerAgentNm = value;}
		}

		/// public propaty name  :  BillCollecterCd
		/// <summary>集金担当従業員コードプロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金担当従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BillCollecterCd
		{
			get{return _billCollecterCd;}
			set{_billCollecterCd = value;}
		}

		/// public propaty name  :  BillCollecterNm
		/// <summary>集金担当従業員名称プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金担当従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BillCollecterNm
		{
			get{return _billCollecterNm;}
			set{_billCollecterNm = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>消費税転嫁方式プロパティ</summary>
		/// <value>得意先マスタから取得 0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税転嫁方式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get{return _consTaxLayMethod;}
			set{_consTaxLayMethod = value;}
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>総額表示方法区分プロパティ</summary>
		/// <value>得意先マスタから取得 0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示方法区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalAmountDispWayCd
		{
			get{return _totalAmountDispWayCd;}
			set{_totalAmountDispWayCd = value;}
		}

		/// public propaty name  :  TotalAmntDspWayRef
		/// <summary>総額表示方法参照区分プロパティ</summary>
		/// <value>得意先マスタから取得 0:全体設定参照 1:得意先参照</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示方法参照区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalAmntDspWayRef
		{
			get{return _totalAmntDspWayRef;}
			set{_totalAmntDspWayRef = value;}
		}

		/// public propaty name  :  SalesCnsTaxFrcProcCd
		/// <summary>売上消費税端数処理コードプロパティ</summary>
		/// <value>得意先マスタから取得 0の場合は 標準設定とする。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上消費税端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCnsTaxFrcProcCd
		{
			get{return _salesCnsTaxFrcProcCd;}
			set{_salesCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  AccountNoInfo1
		/// <summary>銀行口座1プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行口座1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccountNoInfo1
		{
			get{return _accountNoInfo1;}
			set{_accountNoInfo1 = value;}
		}

		/// public propaty name  :  AccountNoInfo2
		/// <summary>銀行口座2プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行口座2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccountNoInfo2
		{
			get{return _accountNoInfo2;}
			set{_accountNoInfo2 = value;}
		}

		/// public propaty name  :  AccountNoInfo3
		/// <summary>銀行口座3プロパティ</summary>
		/// <value>得意先マスタから取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行口座3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccountNoInfo3
		{
			get{return _accountNoInfo3;}
			set{_accountNoInfo3 = value;}
		}

		/// public propaty name  :  CorporateDivCode
		/// <summary>個人・法人区分プロパティ</summary>
		/// <value>得意先マスタから取得 0:個人,1:法人,2:大口法人,3:業者,4:社員</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   個人・法人区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CorporateDivCode
		{
			get{return _corporateDivCode;}
			set{_corporateDivCode = value;}
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

		/// public propaty name  :  CustomerSnm
		/// <summary>得意先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  LastTimeDemand
		/// <summary>前回請求金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回請求金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LastTimeDemand
		{
			get{return _lastTimeDemand;}
			set{_lastTimeDemand = value;}
		}

		/// public propaty name  :  ThisTimeFeeDmdNrml
		/// <summary>今回手数料額（通常入金）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回手数料額（通常入金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeFeeDmdNrml
		{
			get{return _thisTimeFeeDmdNrml;}
			set{_thisTimeFeeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDisDmdNrml
		/// <summary>今回値引額（通常入金）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引額（通常入金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeDisDmdNrml
		{
			get{return _thisTimeDisDmdNrml;}
			set{_thisTimeDisDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDmdNrml
		/// <summary>今回入金金額（通常入金）プロパティ</summary>
		/// <value>入金額の合計金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回入金金額（通常入金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeDmdNrml
		{
			get{return _thisTimeDmdNrml;}
			set{_thisTimeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcDmd
		/// <summary>今回繰越残高（請求計）プロパティ</summary>
		/// <value>今回繰越残高＝前回請求額－今回入金額合計（通常）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回繰越残高（請求計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcDmd
		{
			get{return _thisTimeTtlBlcDmd;}
			set{_thisTimeTtlBlcDmd = value;}
		}

		/// public propaty name  :  OfsThisTimeSales
		/// <summary>相殺後今回売上金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回売上金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisTimeSales
		{
			get{return _ofsThisTimeSales;}
			set{_ofsThisTimeSales = value;}
		}

		/// public propaty name  :  OfsThisSalesTax
		/// <summary>相殺後今回売上消費税プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回売上消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisSalesTax
		{
			get{return _ofsThisSalesTax;}
			set{_ofsThisSalesTax = value;}
		}

		/// public propaty name  :  ItdedOffsetOutTax
		/// <summary>相殺後外税対象額プロパティ</summary>
		/// <value>相殺用：外税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後外税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedOffsetOutTax
		{
			get{return _itdedOffsetOutTax;}
			set{_itdedOffsetOutTax = value;}
		}

		/// public propaty name  :  ItdedOffsetInTax
		/// <summary>相殺後内税対象額プロパティ</summary>
		/// <value>相殺用：内税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後内税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedOffsetInTax
		{
			get{return _itdedOffsetInTax;}
			set{_itdedOffsetInTax = value;}
		}

		/// public propaty name  :  ItdedOffsetTaxFree
		/// <summary>相殺後非課税対象額プロパティ</summary>
		/// <value>相殺用：非課税額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後非課税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedOffsetTaxFree
		{
			get{return _itdedOffsetTaxFree;}
			set{_itdedOffsetTaxFree = value;}
		}

		/// public propaty name  :  OffsetOutTax
		/// <summary>相殺後外税消費税プロパティ</summary>
		/// <value>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後外税消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OffsetOutTax
		{
			get{return _offsetOutTax;}
			set{_offsetOutTax = value;}
		}

		/// public propaty name  :  OffsetInTax
		/// <summary>相殺後内税消費税プロパティ</summary>
		/// <value>相殺用：内税消費税の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後内税消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OffsetInTax
		{
			get{return _offsetInTax;}
			set{_offsetInTax = value;}
		}

		/// public propaty name  :  ThisTimeSales
		/// <summary>今回売上金額プロパティ</summary>
		/// <value>掛売：値引、返品を含まない税抜きの売上金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeSales
		{
			get{return _thisTimeSales;}
			set{_thisTimeSales = value;}
		}

		/// public propaty name  :  ThisSalesTax
		/// <summary>今回売上消費税プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesTax
		{
			get{return _thisSalesTax;}
			set{_thisSalesTax = value;}
		}

		/// public propaty name  :  ItdedSalesOutTax
		/// <summary>売上外税対象額プロパティ</summary>
		/// <value>請求用：外税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上外税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedSalesOutTax
		{
			get{return _itdedSalesOutTax;}
			set{_itdedSalesOutTax = value;}
		}

		/// public propaty name  :  ItdedSalesInTax
		/// <summary>売上内税対象額プロパティ</summary>
		/// <value>請求用：内税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上内税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedSalesInTax
		{
			get{return _itdedSalesInTax;}
			set{_itdedSalesInTax = value;}
		}

		/// public propaty name  :  ItdedSalesTaxFree
		/// <summary>売上非課税対象額プロパティ</summary>
		/// <value>請求用：非課税額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上非課税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedSalesTaxFree
		{
			get{return _itdedSalesTaxFree;}
			set{_itdedSalesTaxFree = value;}
		}

		/// public propaty name  :  SalesOutTax
		/// <summary>売上外税額プロパティ</summary>
		/// <value>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上外税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesOutTax
		{
			get{return _salesOutTax;}
			set{_salesOutTax = value;}
		}

		/// public propaty name  :  SalesInTax
		/// <summary>売上内税額プロパティ</summary>
		/// <value>掛売：内税商品売上の内税消費税額（返品、値引含まず）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上内税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesInTax
		{
			get{return _salesInTax;}
			set{_salesInTax = value;}
		}

		/// public propaty name  :  ThisSalesPricRgds
		/// <summary>今回売上返品金額プロパティ</summary>
		/// <value>掛売：値引を含まない税抜きの売上返品金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上返品金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPricRgds
		{
			get{return _thisSalesPricRgds;}
			set{_thisSalesPricRgds = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxRgds
		/// <summary>今回売上返品消費税プロパティ</summary>
		/// <value>今回売上返品消費税＝返品外税額合計＋返品内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上返品消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxRgds
		{
			get{return _thisSalesPrcTaxRgds;}
			set{_thisSalesPrcTaxRgds = value;}
		}

		/// public propaty name  :  TtlItdedRetOutTax
		/// <summary>返品外税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedRetOutTax
		{
			get{return _ttlItdedRetOutTax;}
			set{_ttlItdedRetOutTax = value;}
		}

		/// public propaty name  :  TtlItdedRetInTax
		/// <summary>返品内税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedRetInTax
		{
			get{return _ttlItdedRetInTax;}
			set{_ttlItdedRetInTax = value;}
		}

		/// public propaty name  :  TtlItdedRetTaxFree
		/// <summary>返品非課税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedRetTaxFree
		{
			get{return _ttlItdedRetTaxFree;}
			set{_ttlItdedRetTaxFree = value;}
		}

		/// public propaty name  :  TtlRetOuterTax
		/// <summary>返品外税額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品外税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlRetOuterTax
		{
			get{return _ttlRetOuterTax;}
			set{_ttlRetOuterTax = value;}
		}

		/// public propaty name  :  TtlRetInnerTax
		/// <summary>返品内税額合計プロパティ</summary>
		/// <value>掛売：内税商品返品の内税消費税額（値引含まず）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品内税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlRetInnerTax
		{
			get{return _ttlRetInnerTax;}
			set{_ttlRetInnerTax = value;}
		}

		/// public propaty name  :  ThisSalesPricDis
		/// <summary>今回売上値引金額プロパティ</summary>
		/// <value>掛売：税抜きの売上値引金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上値引金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPricDis
		{
			get{return _thisSalesPricDis;}
			set{_thisSalesPricDis = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxDis
		/// <summary>今回売上値引消費税プロパティ</summary>
		/// <value>今回売上値引消費税＝値引外税額合計＋値引内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上値引消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxDis
		{
			get{return _thisSalesPrcTaxDis;}
			set{_thisSalesPrcTaxDis = value;}
		}

		/// public propaty name  :  TtlItdedDisOutTax
		/// <summary>値引外税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedDisOutTax
		{
			get{return _ttlItdedDisOutTax;}
			set{_ttlItdedDisOutTax = value;}
		}

		/// public propaty name  :  TtlItdedDisInTax
		/// <summary>値引内税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedDisInTax
		{
			get{return _ttlItdedDisInTax;}
			set{_ttlItdedDisInTax = value;}
		}

		/// public propaty name  :  TtlItdedDisTaxFree
		/// <summary>値引非課税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedDisTaxFree
		{
			get{return _ttlItdedDisTaxFree;}
			set{_ttlItdedDisTaxFree = value;}
		}

		/// public propaty name  :  TtlDisOuterTax
		/// <summary>値引外税額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引外税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlDisOuterTax
		{
			get{return _ttlDisOuterTax;}
			set{_ttlDisOuterTax = value;}
		}

		/// public propaty name  :  TtlDisInnerTax
		/// <summary>値引内税額合計プロパティ</summary>
		/// <value>掛売：内税商品返品の内税消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引内税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlDisInnerTax
		{
			get{return _ttlDisInnerTax;}
			set{_ttlDisInnerTax = value;}
		}

		/// public propaty name  :  ThisPayOffset
		/// <summary>今回支払相殺金額プロパティ</summary>
		/// <value>相殺用伝票：相殺用売上伝票計（相殺対象額）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回支払相殺金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisPayOffset
		{
			get{return _thisPayOffset;}
			set{_thisPayOffset = value;}
		}

		/// public propaty name  :  ThisPayOffsetTax
		/// <summary>今回支払相殺消費税プロパティ</summary>
		/// <value>相殺用伝票：相殺用売上消費税合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回支払相殺消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisPayOffsetTax
		{
			get{return _thisPayOffsetTax;}
			set{_thisPayOffsetTax = value;}
		}

		/// public propaty name  :  ItdedPaymOutTax
		/// <summary>支払外税対象額プロパティ</summary>
		/// <value>相殺用伝票：外税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払外税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedPaymOutTax
		{
			get{return _itdedPaymOutTax;}
			set{_itdedPaymOutTax = value;}
		}

		/// public propaty name  :  ItdedPaymInTax
		/// <summary>支払内税対象額プロパティ</summary>
		/// <value>相殺用伝票：内税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払内税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedPaymInTax
		{
			get{return _itdedPaymInTax;}
			set{_itdedPaymInTax = value;}
		}

		/// public propaty name  :  ItdedPaymTaxFree
		/// <summary>支払非課税対象額プロパティ</summary>
		/// <value>相殺用伝票：非課税額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払非課税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedPaymTaxFree
		{
			get{return _itdedPaymTaxFree;}
			set{_itdedPaymTaxFree = value;}
		}

		/// public propaty name  :  PaymentOutTax
		/// <summary>支払外税消費税プロパティ</summary>
		/// <value>相殺用伝票：外税消費税の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払外税消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 PaymentOutTax
		{
			get{return _paymentOutTax;}
			set{_paymentOutTax = value;}
		}

		/// public propaty name  :  PaymentInTax
		/// <summary>支払内税消費税プロパティ</summary>
		/// <value>相殺用伝票：内税消費税の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払内税消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 PaymentInTax
		{
			get{return _paymentInTax;}
			set{_paymentInTax = value;}
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

		/// public propaty name  :  AfCalDemandPrice
		/// <summary>計算後請求金額プロパティ</summary>
		/// <value>今回請求金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計算後請求金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AfCalDemandPrice
		{
			get{return _afCalDemandPrice;}
			set{_afCalDemandPrice = value;}
		}

		/// public propaty name  :  AcpOdrTtl2TmBfBlDmd
		/// <summary>受注2回前残高（請求計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注2回前残高（請求計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AcpOdrTtl2TmBfBlDmd
		{
			get{return _acpOdrTtl2TmBfBlDmd;}
			set{_acpOdrTtl2TmBfBlDmd = value;}
		}

		/// public propaty name  :  AcpOdrTtl3TmBfBlDmd
		/// <summary>受注3回前残高（請求計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注3回前残高（請求計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AcpOdrTtl3TmBfBlDmd
		{
			get{return _acpOdrTtl3TmBfBlDmd;}
			set{_acpOdrTtl3TmBfBlDmd = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>締次更新実行年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  StartCAddUpUpdDate
		/// <summary>締次更新開始年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StartCAddUpUpdDate
		{
			get{return _startCAddUpUpdDate;}
			set{_startCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>前回締次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get{return _lastCAddUpUpdDate;}
			set{_lastCAddUpUpdDate = value;}
		}

		/// public propaty name  :  SalesSlipCount
		/// <summary>売上伝票枚数プロパティ</summary>
		/// <value>掛売の伝票枚数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票枚数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCount
		{
			get{return _salesSlipCount;}
			set{_salesSlipCount = value;}
		}

		/// public propaty name  :  BillPrintDate
		/// <summary>請求書発行日プロパティ</summary>
		/// <value>"YYYYMMDD"  請求書を発行した年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書発行日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime BillPrintDate
		{
			get{return _billPrintDate;}
			set{_billPrintDate = value;}
		}

		/// public propaty name  :  ExpectedDepositDate
		/// <summary>入金予定日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime ExpectedDepositDate
		{
			get{return _expectedDepositDate;}
			set{_expectedDepositDate = value;}
		}

		/// public propaty name  :  CollectCond
		/// <summary>回収条件プロパティ</summary>
		/// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回収条件プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CollectCond
		{
			get{return _collectCond;}
			set{_collectCond = value;}
		}

		/// public propaty name  :  ConsTaxRate
		/// <summary>消費税率プロパティ</summary>
		/// <value>請求転嫁消費税を算出する場合に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ConsTaxRate
		{
			get{return _consTaxRate;}
			set{_consTaxRate = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
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

		/// public propaty name  :  MoneyKindList
		/// <summary>金種コードリストプロパティ</summary>
		/// <value>(金種コード、金種名称、入金金額）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   金種コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList MoneyKindList
		{
			get{return _moneyKindList;}
			set{_moneyKindList = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>伝票印刷設定用</value>
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
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
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>請求拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  ResultsSectCd
        /// <summary>実績拠点コードプロパティ</summary>
        /// <value>実績集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsSectCd
        {
            get { return _resultsSectCd; }
            set { _resultsSectCd = value; }
        }

        /// public propaty name  :  BillOutputCode
        /// <summary>請求書出力区分コードプロパティ</summary>
        /// <value>0:請求書発行する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillOutputCode
        {
            get { return _billOutputCode; }
            set { _billOutputCode = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>領収書出力区分コードプロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書出力区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceiptOutputCode
        {
            get { return _receiptOutputCode; }
            set { _receiptOutputCode = value; }
        }

        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>合計請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>明細請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>伝票合計請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }

        /// public propaty name  :  TitleTaxRate1
        /// <summary>税率1タイトル</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1タイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TitleTaxRate1
        {
            get { return _titleTaxRate1; }
            set { _titleTaxRate1 = value; }
        }

        /// public propaty name  :  TitleTaxRate2
        /// <summary>税率2タイトル</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2タイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TitleTaxRate2
        {
            get { return _titleTaxRate2; }
            set { _titleTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxRate1
        /// <summary>売上額(計税率1) </summary>
        /// <value>売上額(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate1
        {
            get { return _totalThisTimeSalesTaxRate1; }
            set { _totalThisTimeSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxRate2
        /// <summary>売上額(計税率2) </summary>
        /// <value>売上額(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate2
        {
            get { return _totalThisTimeSalesTaxRate2; }
            set { _totalThisTimeSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesOther
        /// <summary>売上額(計その他) </summary>
        /// <value>売上額(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesOther
        {
            get { return _totalThisTimeSalesOther; }
            set { _totalThisTimeSalesOther = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate1
        /// <summary>返品値引(計税率1) </summary>
        /// <value>返品値引(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate1
        {
            get { return _totalThisRgdsDisPricTaxRate1; }
            set { _totalThisRgdsDisPricTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate2
        /// <summary>返品値引(計税率2) </summary>
        /// <value>返品値引(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate2
        {
            get { return _totalThisRgdsDisPricTaxRate2; }
            set { _totalThisRgdsDisPricTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricOther
        /// <summary>返品値引(計その他) </summary>
        /// <value>返品値引(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricOther
        {
            get { return _totalThisRgdsDisPricOther; }
            set { _totalThisRgdsDisPricOther = value; }
        }

        /// public propaty name  :  TotalPureSalesTaxRate1
        /// <summary>純売上額(計税率1) </summary>
        /// <value>純売上額(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate1
        {
            get { return _totalPureSalesTaxRate1; }
            set { _totalPureSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalPureSalesTaxRate2
        /// <summary>純売上額(計税率2) </summary>
        /// <value>純売上額(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate2
        {
            get { return _totalPureSalesTaxRate2; }
            set { _totalPureSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalPureSalesOther
        /// <summary>純売上額(計その他) </summary>
        /// <value>純売上額(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純売上額(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesOther
        {
            get { return _totalPureSalesOther; }
            set { _totalPureSalesOther = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate1
        /// <summary>消費税(計税率1) </summary>
        /// <value>消費税(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate1
        {
            get { return _totalSalesPricTaxTaxRate1; }
            set { _totalSalesPricTaxTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate2
        /// <summary>消費税(計税率2) </summary>
        /// <value>消費税(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate2
        {
            get { return _totalSalesPricTaxTaxRate2; }
            set { _totalSalesPricTaxTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxOther
        /// <summary>消費税(計その他) </summary>
        /// <value>消費税(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxOther
        {
            get { return _totalSalesPricTaxOther; }
            set { _totalSalesPricTaxOther = value; }
        }

        /// public propaty name  :  TotalThisSalesSumTaxRate1
        /// <summary>当月合計(計税率1) </summary>
        /// <value>当月合計(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxRate1
        {
            get { return _totalThisSalesSumTaxRate1; }
            set { _totalThisSalesSumTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisSalesSumTaxRate2
        /// <summary>当月合計(計税率2) </summary>
        /// <value>当月合計(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxRate2
        {
            get { return _totalThisSalesSumTaxRate2; }
            set { _totalThisSalesSumTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisSalesSumTaxOther
        /// <summary>当月合計(計その他) </summary>
        /// <value>当月合計(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当月合計(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxOther
        {
            get { return _totalThisSalesSumTaxOther; }
            set { _totalThisSalesSumTaxOther = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate1
        /// <summary>枚数(計税率1) </summary>
        /// <value>枚数(計税率1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計税率1) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate1
        {
            get { return _totalSalesSlipCountTaxRate1; }
            set { _totalSalesSlipCountTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate2
        /// <summary>枚数(計税率2) </summary>
        /// <value>枚数(計税率2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計税率2) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate2
        {
            get { return _totalSalesSlipCountTaxRate2; }
            set { _totalSalesSlipCountTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountOther
        /// <summary>枚数(計その他) </summary>
        /// <value>枚数(計その他) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   枚数(計その他) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountOther
        {
            get { return _totalSalesSlipCountOther; }
            set { _totalSalesSlipCountOther = value; }
        }

        // --- ADD START 3H 仰亮亮 2022/10/27 ----->>>>>
        /// public propaty name  :  TotalThisTimeSalesTaxFree
        /// <summary>売上額(非課税)プロパティ</summary>
        /// <value>売上額(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上額(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxFree
        {
            get { return _totalThisTimeSalesTaxFree; }
            set { _totalThisTimeSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalThisRgdsDisPricTaxFree
        /// <summary>返品値引(非課税)プロパティ</summary>
        /// <value>返品値引(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxFree
        {
            get { return _totalThisRgdsDisPricTaxFree; }
            set { _totalThisRgdsDisPricTaxFree = value; }
        }
        /// public propaty name  :  TotalPureSalesTaxFree
        /// <summary>純売上額(非課税)プロパティ</summary>
        /// <value>純売上額(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  純売上額(非課税)プロパティ</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxFree
        {
            get { return _totalPureSalesTaxFree; }
            set { _totalPureSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalSalesPricTaxTaxFree
        /// <summary>消費税(非課税)プロパティ</summary>
        /// <value>消費税(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  消費税(非課税)プロパティ</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxFree
        {
            get { return _totalSalesPricTaxTaxFree; }
            set { _totalSalesPricTaxTaxFree = value; }
        }

        /// public propaty name  :  TtotalThisSalesSumTaxFree
        /// <summary>今回合計(非課税)プロパティ</summary>
        /// <value>今回合計(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  今回合計(非課税)プロパティ</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public Int64 TotalThisSalesSumTaxFree
        {
            get { return _totalThisSalesSumTaxFree; }
            set { _totalThisSalesSumTaxFree = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxFree
        /// <summary>枚数(非課税)プロパティ</summary>
        /// <value>枚数(非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  枚数(非課税)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxFree
        {
            get { return _totalSalesSlipCountTaxFree; }
            set { _totalSalesSlipCountTaxFree = value; }
        }
        // --- ADD END 3H 仰亮亮 2022/10/27 -----<<<<<

		/// <summary>
		/// 請求書(鑑部)抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>RsltInfo_EBooksDemandTotalWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RsltInfo_EBooksDemandTotalWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RsltInfo_EBooksDemandTotalWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_EBooksDemandTotalWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_EBooksDemandTotalWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer       :   3H 仰亮亮</br>
    /// <br>Date             :   2022/10/27</br>
    /// </remarks>
    public class RsltInfo_EBooksDemandTotalWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate メンバ
    	
	    /// <summary>
	    ///  Ver5.10.1.0用のカスタムシリアライザです
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   RsltInfo_EBooksDemandTotalWorkクラスのカスタムシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer       :   3H 仰亮亮</br>
        /// <br>Date             :   2022/10/27</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  RsltInfo_EBooksDemandTotalWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is RsltInfo_EBooksDemandTotalWork || graph is ArrayList || graph is RsltInfo_EBooksDemandTotalWork[]) )
			    throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(RsltInfo_EBooksDemandTotalWork).FullName ) );

		    if( graph != null && graph is RsltInfo_EBooksDemandTotalWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_EBooksDemandTotalWork" );

		    //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		    int occurrence = 0;     //一般にゼロの場合もありえます
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is RsltInfo_EBooksDemandTotalWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((RsltInfo_EBooksDemandTotalWork[])graph).Length;
		    }
		    else if( graph is RsltInfo_EBooksDemandTotalWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //繰り返し数	

		    //企業コード
		    serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		    //計上拠点コード
		    serInfo.MemberInfo.Add( typeof(string) ); //AddUpSecCode
		    //計上拠点名称
		    serInfo.MemberInfo.Add( typeof(string) ); //AddUpSecName
		    //請求先コード
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ClaimCode
		    //請求先名称
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimName
		    //請求先名称2
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimName2
		    //請求先略称
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimSnm
		    //請求先名称カナ
		    serInfo.MemberInfo.Add( typeof(string) ); //ClaimNameKana
		    //郵便番号
		    serInfo.MemberInfo.Add( typeof(string) ); //PostNo
		    //住所1（都道府県市区郡・町村・字）
		    serInfo.MemberInfo.Add( typeof(string) ); //Address1
		    //住所2（丁目）
		    serInfo.MemberInfo.Add( typeof(Int32) ); //Address2
		    //住所3（番地）
		    serInfo.MemberInfo.Add( typeof(string) ); //Address3
		    //住所4（アパート名称）
		    serInfo.MemberInfo.Add( typeof(string) ); //Address4
		    //集金月区分コード
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CollectMoneyCode
		    //集金月区分名称
		    serInfo.MemberInfo.Add( typeof(string) ); //CollectMoneyName
		    //集金日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CollectMoneyDay
		    //敬称
		    serInfo.MemberInfo.Add( typeof(string) ); //HonorificTitle
		    //電話番号（自宅）
		    serInfo.MemberInfo.Add( typeof(string) ); //HomeTelNo
		    //電話番号（勤務先）
		    serInfo.MemberInfo.Add( typeof(string) ); //OfficeTelNo
		    //電話番号（携帯）
		    serInfo.MemberInfo.Add( typeof(string) ); //PortableTelNo
		    //FAX番号（自宅）
		    serInfo.MemberInfo.Add( typeof(string) ); //HomeFaxNo
		    //FAX番号（勤務先）
		    serInfo.MemberInfo.Add( typeof(string) ); //OfficeFaxNo
		    //電話番号（その他）
		    serInfo.MemberInfo.Add( typeof(string) ); //OthersTelNo
		    //主連絡先区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //MainContactCode
		    //締日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //TotalDay
		    //顧客担当従業員コード
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerAgentCd
		    //顧客担当従業員名称
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerAgentNm
		    //集金担当従業員コード
		    serInfo.MemberInfo.Add( typeof(string) ); //BillCollecterCd
		    //集金担当従業員名称
		    serInfo.MemberInfo.Add( typeof(string) ); //BillCollecterNm
		    //消費税転嫁方式
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ConsTaxLayMethod
		    //総額表示方法区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //TotalAmountDispWayCd
		    //総額表示方法参照区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //TotalAmntDspWayRef
		    //売上消費税端数処理コード
		    serInfo.MemberInfo.Add( typeof(Int32) ); //SalesCnsTaxFrcProcCd
		    //銀行口座1
		    serInfo.MemberInfo.Add( typeof(string) ); //AccountNoInfo1
		    //銀行口座2
		    serInfo.MemberInfo.Add( typeof(string) ); //AccountNoInfo2
		    //銀行口座3
		    serInfo.MemberInfo.Add( typeof(string) ); //AccountNoInfo3
		    //個人・法人区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CorporateDivCode
		    //得意先コード
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		    //得意先名称
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerName
		    //得意先名称2
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerName2
		    //得意先略称
		    serInfo.MemberInfo.Add( typeof(string) ); //CustomerSnm
		    //計上年月日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AddUpDate
		    //計上年月
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AddUpYearMonth
		    //前回請求金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //LastTimeDemand
		    //今回手数料額（通常入金）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeFeeDmdNrml
		    //今回値引額（通常入金）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeDisDmdNrml
		    //今回入金金額（通常入金）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeDmdNrml
		    //今回繰越残高（請求計）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeTtlBlcDmd
		    //相殺後今回売上金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OfsThisTimeSales
		    //相殺後今回売上消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OfsThisSalesTax
		    //相殺後外税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedOffsetOutTax
		    //相殺後内税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedOffsetInTax
		    //相殺後非課税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedOffsetTaxFree
		    //相殺後外税消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OffsetOutTax
		    //相殺後内税消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //OffsetInTax
		    //今回売上金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisTimeSales
		    //今回売上消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesTax
		    //売上外税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedSalesOutTax
		    //売上内税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedSalesInTax
		    //売上非課税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedSalesTaxFree
		    //売上外税額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesOutTax
		    //売上内税額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesInTax
		    //今回売上返品金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPricRgds
		    //今回売上返品消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPrcTaxRgds
		    //返品外税対象額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedRetOutTax
		    //返品内税対象額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedRetInTax
		    //返品非課税対象額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedRetTaxFree
		    //返品外税額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlRetOuterTax
		    //返品内税額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlRetInnerTax
		    //今回売上値引金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPricDis
		    //今回売上値引消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisSalesPrcTaxDis
		    //値引外税対象額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedDisOutTax
		    //値引内税対象額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedDisInTax
		    //値引非課税対象額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlItdedDisTaxFree
		    //値引外税額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlDisOuterTax
		    //値引内税額合計
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TtlDisInnerTax
		    //今回支払相殺金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisPayOffset
		    //今回支払相殺消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ThisPayOffsetTax
		    //支払外税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedPaymOutTax
		    //支払内税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedPaymInTax
		    //支払非課税対象額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //ItdedPaymTaxFree
		    //支払外税消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //PaymentOutTax
		    //支払内税消費税
		    serInfo.MemberInfo.Add( typeof(Int64) ); //PaymentInTax
		    //消費税調整額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //TaxAdjust
		    //残高調整額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //BalanceAdjust
		    //計算後請求金額
		    serInfo.MemberInfo.Add( typeof(Int64) ); //AfCalDemandPrice
		    //受注2回前残高（請求計）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //AcpOdrTtl2TmBfBlDmd
		    //受注3回前残高（請求計）
		    serInfo.MemberInfo.Add( typeof(Int64) ); //AcpOdrTtl3TmBfBlDmd
		    //締次更新実行年月日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CAddUpUpdExecDate
		    //締次更新開始年月日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //StartCAddUpUpdDate
		    //前回締次更新年月日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //LastCAddUpUpdDate
		    //売上伝票枚数
		    serInfo.MemberInfo.Add( typeof(Int32) ); //SalesSlipCount
		    //請求書発行日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //BillPrintDate
		    //入金予定日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ExpectedDepositDate
		    //回収条件
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CollectCond
		    //消費税率
		    serInfo.MemberInfo.Add( typeof(Double) ); //ConsTaxRate
		    //端数処理区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //FractionProcCd            
		    //金種コードリスト
		    serInfo.MemberInfo.Add( typeof(ArrayList) ); //MoneyKindList
		    //伝票印刷設定用帳票ID
		    serInfo.MemberInfo.Add( typeof(string) ); //SlipPrtSetPaperId
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //請求拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSectionCode
            //実績拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
            //請求書出力区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BillOutputCode
            //売掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //領収書出力区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiptOutputCode
            //合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalBillOutputDiv
            //明細請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailBillOutputCode
            //伝票合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlBillOutputDiv
            // 売上額(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate1
            // 売上額(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate2
            // 売上額(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesOther
            // 返品値引(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate1
            // 返品値引(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate2
            // 返品値引(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricOther
            // 純売上額(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate1
            // 純売上額(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate2
            // 純売上額(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesOther
            // 消費税(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate1
            // 消費税(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate2
            // 消費税(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTax_Other
            // 当月合計(計税率1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxRate1
            // 当月合計(計税率2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxRate2
            // 当月合計(計その他)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxOther
            // 枚数(計税率1)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate1
            // 枚数(計税率2)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate2
            // 枚数(計その他)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountOther
            // 税率1タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // 税率2タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // --- ADD START 3H 仰亮亮 2022/10/27 ----->>>>>
            // 売上額(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxFree
            // 返品値引(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxFree
            // 純売上額(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxFree
            // 消費税(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxFree
            // 今回合計(計非課税)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisSalesSumTaxFree
            // 枚数(計非課税)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxFree
            // --- ADD END 3H 仰亮亮 2022/10/27 -----<<<<<

		    serInfo.Serialize( writer, serInfo );
		    if( graph is RsltInfo_EBooksDemandTotalWork )
		    {
			    RsltInfo_EBooksDemandTotalWork temp = (RsltInfo_EBooksDemandTotalWork)graph;

			    SetRsltInfo_EBooksDemandTotalWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is RsltInfo_EBooksDemandTotalWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((RsltInfo_EBooksDemandTotalWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(RsltInfo_EBooksDemandTotalWork temp in lst)
			    {
				    SetRsltInfo_EBooksDemandTotalWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// RsltInfo_EBooksDemandTotalWorkメンバ数(publicプロパティ数)
	    /// </summary>
        //private const int currentMemberCount = 129; // DEL 3H 仰亮亮 2022/10/27
        private const int currentMemberCount = 135; // ADD 3H 仰亮亮 2022/10/27

	    /// <summary>
	    ///  RsltInfo_EBooksDemandTotalWorkインスタンス書き込み
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   RsltInfo_EBooksDemandTotalWorkのインスタンスを書き込み</br>
	    /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer       :   3H 仰亮亮</br>
        /// <br>Date             :   2022/10/27</br>
	    /// </remarks>
	    private void SetRsltInfo_EBooksDemandTotalWork( System.IO.BinaryWriter writer, RsltInfo_EBooksDemandTotalWork temp )
	    {
		    //企業コード
		    writer.Write( temp.EnterpriseCode );
		    //計上拠点コード
		    writer.Write( temp.AddUpSecCode );
		    //計上拠点名称
		    writer.Write( temp.AddUpSecName );
		    //請求先コード
		    writer.Write( temp.ClaimCode );
		    //請求先名称
		    writer.Write( temp.ClaimName );
		    //請求先名称2
		    writer.Write( temp.ClaimName2 );
		    //請求先略称
		    writer.Write( temp.ClaimSnm );
		    //請求先名称カナ
		    writer.Write( temp.ClaimNameKana );
		    //郵便番号
		    writer.Write( temp.PostNo );
		    //住所1（都道府県市区郡・町村・字）
		    writer.Write( temp.Address1 );
		    //住所2（丁目）
		    writer.Write( temp.Address2 );
		    //住所3（番地）
		    writer.Write( temp.Address3 );
		    //住所4（アパート名称）
		    writer.Write( temp.Address4 );
		    //集金月区分コード
		    writer.Write( temp.CollectMoneyCode );
		    //集金月区分名称
		    writer.Write( temp.CollectMoneyName );
		    //集金日
		    writer.Write( temp.CollectMoneyDay );
		    //敬称
		    writer.Write( temp.HonorificTitle );
		    //電話番号（自宅）
		    writer.Write( temp.HomeTelNo );
		    //電話番号（勤務先）
		    writer.Write( temp.OfficeTelNo );
		    //電話番号（携帯）
		    writer.Write( temp.PortableTelNo );
		    //FAX番号（自宅）
		    writer.Write( temp.HomeFaxNo );
		    //FAX番号（勤務先）
		    writer.Write( temp.OfficeFaxNo );
		    //電話番号（その他）
		    writer.Write( temp.OthersTelNo );
		    //主連絡先区分
		    writer.Write( temp.MainContactCode );
		    //締日
		    writer.Write( temp.TotalDay );
		    //顧客担当従業員コード
		    writer.Write( temp.CustomerAgentCd );
		    //顧客担当従業員名称
		    writer.Write( temp.CustomerAgentNm );
		    //集金担当従業員コード
		    writer.Write( temp.BillCollecterCd );
		    //集金担当従業員名称
		    writer.Write( temp.BillCollecterNm );
		    //消費税転嫁方式
		    writer.Write( temp.ConsTaxLayMethod );
		    //総額表示方法区分
		    writer.Write( temp.TotalAmountDispWayCd );
		    //総額表示方法参照区分
		    writer.Write( temp.TotalAmntDspWayRef );
		    //売上消費税端数処理コード
		    writer.Write( temp.SalesCnsTaxFrcProcCd );
		    //銀行口座1
		    writer.Write( temp.AccountNoInfo1 );
		    //銀行口座2
		    writer.Write( temp.AccountNoInfo2 );
		    //銀行口座3
		    writer.Write( temp.AccountNoInfo3 );
		    //個人・法人区分
		    writer.Write( temp.CorporateDivCode );
		    //得意先コード
		    writer.Write( temp.CustomerCode );
		    //得意先名称
		    writer.Write( temp.CustomerName );
		    //得意先名称2
		    writer.Write( temp.CustomerName2 );
		    //得意先略称
		    writer.Write( temp.CustomerSnm );
		    //計上年月日
		    writer.Write( (Int64)temp.AddUpDate.Ticks );
		    //計上年月
		    writer.Write( (Int64)temp.AddUpYearMonth.Ticks );
		    //前回請求金額
		    writer.Write( temp.LastTimeDemand );
		    //今回手数料額（通常入金）
		    writer.Write( temp.ThisTimeFeeDmdNrml );
		    //今回値引額（通常入金）
		    writer.Write( temp.ThisTimeDisDmdNrml );
		    //今回入金金額（通常入金）
		    writer.Write( temp.ThisTimeDmdNrml );
		    //今回繰越残高（請求計）
		    writer.Write( temp.ThisTimeTtlBlcDmd );
		    //相殺後今回売上金額
		    writer.Write( temp.OfsThisTimeSales );
		    //相殺後今回売上消費税
		    writer.Write( temp.OfsThisSalesTax );
		    //相殺後外税対象額
		    writer.Write( temp.ItdedOffsetOutTax );
		    //相殺後内税対象額
		    writer.Write( temp.ItdedOffsetInTax );
		    //相殺後非課税対象額
		    writer.Write( temp.ItdedOffsetTaxFree );
		    //相殺後外税消費税
		    writer.Write( temp.OffsetOutTax );
		    //相殺後内税消費税
		    writer.Write( temp.OffsetInTax );
		    //今回売上金額
		    writer.Write( temp.ThisTimeSales );
		    //今回売上消費税
		    writer.Write( temp.ThisSalesTax );
		    //売上外税対象額
		    writer.Write( temp.ItdedSalesOutTax );
		    //売上内税対象額
		    writer.Write( temp.ItdedSalesInTax );
		    //売上非課税対象額
		    writer.Write( temp.ItdedSalesTaxFree );
		    //売上外税額
		    writer.Write( temp.SalesOutTax );
		    //売上内税額
		    writer.Write( temp.SalesInTax );
		    //今回売上返品金額
		    writer.Write( temp.ThisSalesPricRgds );
		    //今回売上返品消費税
		    writer.Write( temp.ThisSalesPrcTaxRgds );
		    //返品外税対象額合計
		    writer.Write( temp.TtlItdedRetOutTax );
		    //返品内税対象額合計
		    writer.Write( temp.TtlItdedRetInTax );
		    //返品非課税対象額合計
		    writer.Write( temp.TtlItdedRetTaxFree );
		    //返品外税額合計
		    writer.Write( temp.TtlRetOuterTax );
		    //返品内税額合計
		    writer.Write( temp.TtlRetInnerTax );
		    //今回売上値引金額
		    writer.Write( temp.ThisSalesPricDis );
		    //今回売上値引消費税
		    writer.Write( temp.ThisSalesPrcTaxDis );
		    //値引外税対象額合計
		    writer.Write( temp.TtlItdedDisOutTax );
		    //値引内税対象額合計
		    writer.Write( temp.TtlItdedDisInTax );
		    //値引非課税対象額合計
		    writer.Write( temp.TtlItdedDisTaxFree );
		    //値引外税額合計
		    writer.Write( temp.TtlDisOuterTax );
		    //値引内税額合計
		    writer.Write( temp.TtlDisInnerTax );
		    //今回支払相殺金額
		    writer.Write( temp.ThisPayOffset );
		    //今回支払相殺消費税
		    writer.Write( temp.ThisPayOffsetTax );
		    //支払外税対象額
		    writer.Write( temp.ItdedPaymOutTax );
		    //支払内税対象額
		    writer.Write( temp.ItdedPaymInTax );
		    //支払非課税対象額
		    writer.Write( temp.ItdedPaymTaxFree );
		    //支払外税消費税
		    writer.Write( temp.PaymentOutTax );
		    //支払内税消費税
		    writer.Write( temp.PaymentInTax );
		    //消費税調整額
		    writer.Write( temp.TaxAdjust );
		    //残高調整額
		    writer.Write( temp.BalanceAdjust );
		    //計算後請求金額
		    writer.Write( temp.AfCalDemandPrice );
		    //受注2回前残高（請求計）
		    writer.Write( temp.AcpOdrTtl2TmBfBlDmd );
		    //受注3回前残高（請求計）
		    writer.Write( temp.AcpOdrTtl3TmBfBlDmd );
		    //締次更新実行年月日
		    writer.Write( (Int64)temp.CAddUpUpdExecDate.Ticks );
		    //締次更新開始年月日
		    writer.Write( (Int64)temp.StartCAddUpUpdDate.Ticks );
		    //前回締次更新年月日
		    writer.Write( (Int64)temp.LastCAddUpUpdDate.Ticks );
		    //売上伝票枚数
		    writer.Write( temp.SalesSlipCount );
		    //請求書発行日
		    writer.Write( (Int64)temp.BillPrintDate.Ticks );
		    //入金予定日
		    writer.Write( (Int64)temp.ExpectedDepositDate.Ticks );
		    //回収条件
		    writer.Write( temp.CollectCond );
		    //消費税率
		    writer.Write( temp.ConsTaxRate );
		    //端数処理区分
		    writer.Write( temp.FractionProcCd ); 

            writer.Write(temp.MoneyKindList.Count);
            for (int cnt = 0; cnt < temp.MoneyKindList.Count; cnt++)
            {
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).MoneyKindCode);
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).MoneyKindName);
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).MoneyKindDiv);
                writer.Write(((RsltInfo_EBooksDepsitTotalWork)temp.MoneyKindList[cnt]).Deposit);
            }
            
           
            //伝票印刷設定用帳票ID
		    writer.Write( temp.SlipPrtSetPaperId );
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //請求拠点コード
            writer.Write(temp.ClaimSectionCode);
            //実績拠点コード
            writer.Write(temp.ResultsSectCd);
            //請求書出力区分コード
            writer.Write(temp.BillOutputCode);
            //売掛区分
            writer.Write(temp.AccRecDivCd);

            //領収書出力区分コード
            writer.Write(temp.ReceiptOutputCode);
            //合計請求書出力区分
            writer.Write(temp.TotalBillOutputDiv);
            //明細請求書出力区分
            writer.Write(temp.DetailBillOutputCode);
            //伝票合計請求書出力区分
            writer.Write(temp.SlipTtlBillOutputDiv);

            //売上額(計税率1)
            writer.Write(temp.TotalThisTimeSalesTaxRate1);
            //売上額(計税率2)
            writer.Write(temp.TotalThisTimeSalesTaxRate2);
            //売上額(計その他)
            writer.Write(temp.TotalThisTimeSalesOther);
            //返品値引(計税率1)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate1);
            //返品値引(計税率2)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate2);
            //返品値引(計その他)
            writer.Write(temp.TotalThisRgdsDisPricOther);
            //純売上額(計税率1)
            writer.Write(temp.TotalPureSalesTaxRate1);
            //純売上額(計税率2)
            writer.Write(temp.TotalPureSalesTaxRate2);
            //純売上額(計その他)
            writer.Write(temp.TotalPureSalesOther);
            //消費税(計税率1)
            writer.Write(temp.TotalSalesPricTaxTaxRate1);
            //消費税(計税率2)
            writer.Write(temp.TotalSalesPricTaxTaxRate2);
            //消費税(計その他)
            writer.Write(temp.TotalSalesPricTaxOther);
            //当月合計(計税率1)
            writer.Write(temp.TotalThisSalesSumTaxRate1);
            //当月合計(計税率2)
            writer.Write(temp.TotalThisSalesSumTaxRate2);
            //当月合計(計その他)
            writer.Write(temp.TotalThisSalesSumTaxOther);
            //枚数(計税率1)
            writer.Write(temp.TotalSalesSlipCountTaxRate1);
            //枚数(計税率2)
            writer.Write(temp.TotalSalesSlipCountTaxRate2);
            //枚数(計その他)
            writer.Write(temp.TotalSalesSlipCountOther);
            //税率1タイトル
            writer.Write(temp.TitleTaxRate1);
            //税率2タイトル
            writer.Write(temp.TitleTaxRate2);
            // --- ADD START 3H 仰亮亮 2022/10/27 ----->>>>>
            // 売上額(計非課税)
            writer.Write(temp.TotalThisTimeSalesTaxFree);
            // 返品値引(計非課税)
            writer.Write(temp.TotalThisRgdsDisPricTaxFree);
            // 純仕入額(計非課税)
            writer.Write(temp.TotalPureSalesTaxFree);
            // 消費税(計非課税)
            writer.Write(temp.TotalSalesPricTaxTaxFree);
            // 今回合計(計非課税)
            writer.Write(temp.TotalThisSalesSumTaxFree);
            // 枚数(計非課税)
            writer.Write(temp.TotalSalesSlipCountTaxFree);
            // --- ADD END 3H 仰亮亮 2022/10/27 -----<<<<<
	    }

	    /// <summary>
	    ///  RsltInfo_EBooksDemandTotalWorkインスタンス取得
	    /// </summary>
	    /// <returns>RsltInfo_EBooksDemandTotalWorkクラスのインスタンス</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   RsltInfo_EBooksDemandTotalWorkのインスタンスを取得します</br>
	    /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer       :   3H 仰亮亮</br>
        /// <br>Date             :   2022/10/27</br>
	    /// </remarks>
	    private RsltInfo_EBooksDemandTotalWork GetRsltInfo_EBooksDemandTotalWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0なので不要ですが、V5.1.0.1以降では
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // のケースについての配慮が必要になります。

		    RsltInfo_EBooksDemandTotalWork temp = new RsltInfo_EBooksDemandTotalWork();

		    //企業コード
		    temp.EnterpriseCode = reader.ReadString();
		    //計上拠点コード
		    temp.AddUpSecCode = reader.ReadString();
		    //計上拠点名称
		    temp.AddUpSecName = reader.ReadString();
		    //請求先コード
		    temp.ClaimCode = reader.ReadInt32();
		    //請求先名称
		    temp.ClaimName = reader.ReadString();
		    //請求先名称2
		    temp.ClaimName2 = reader.ReadString();
		    //請求先略称
		    temp.ClaimSnm = reader.ReadString();
		    //請求先名称カナ
		    temp.ClaimNameKana = reader.ReadString();
		    //郵便番号
		    temp.PostNo = reader.ReadString();
		    //住所1（都道府県市区郡・町村・字）
		    temp.Address1 = reader.ReadString();
		    //住所2（丁目）
		    temp.Address2 = reader.ReadInt32();
		    //住所3（番地）
		    temp.Address3 = reader.ReadString();
		    //住所4（アパート名称）
		    temp.Address4 = reader.ReadString();
		    //集金月区分コード
		    temp.CollectMoneyCode = reader.ReadInt32();
		    //集金月区分名称
		    temp.CollectMoneyName = reader.ReadString();
		    //集金日
		    temp.CollectMoneyDay = reader.ReadInt32();
		    //敬称
		    temp.HonorificTitle = reader.ReadString();
		    //電話番号（自宅）
		    temp.HomeTelNo = reader.ReadString();
		    //電話番号（勤務先）
		    temp.OfficeTelNo = reader.ReadString();
		    //電話番号（携帯）
		    temp.PortableTelNo = reader.ReadString();
		    //FAX番号（自宅）
		    temp.HomeFaxNo = reader.ReadString();
		    //FAX番号（勤務先）
		    temp.OfficeFaxNo = reader.ReadString();
		    //電話番号（その他）
		    temp.OthersTelNo = reader.ReadString();
		    //主連絡先区分
		    temp.MainContactCode = reader.ReadInt32();
		    //締日
		    temp.TotalDay = reader.ReadInt32();
		    //顧客担当従業員コード
		    temp.CustomerAgentCd = reader.ReadString();
		    //顧客担当従業員名称
		    temp.CustomerAgentNm = reader.ReadString();
		    //集金担当従業員コード
		    temp.BillCollecterCd = reader.ReadString();
		    //集金担当従業員名称
		    temp.BillCollecterNm = reader.ReadString();
		    //消費税転嫁方式
		    temp.ConsTaxLayMethod = reader.ReadInt32();
		    //総額表示方法区分
		    temp.TotalAmountDispWayCd = reader.ReadInt32();
		    //総額表示方法参照区分
		    temp.TotalAmntDspWayRef = reader.ReadInt32();
		    //売上消費税端数処理コード
		    temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
		    //銀行口座1
		    temp.AccountNoInfo1 = reader.ReadString();
		    //銀行口座2
		    temp.AccountNoInfo2 = reader.ReadString();
		    //銀行口座3
		    temp.AccountNoInfo3 = reader.ReadString();
		    //個人・法人区分
		    temp.CorporateDivCode = reader.ReadInt32();
		    //得意先コード
		    temp.CustomerCode = reader.ReadInt32();
		    //得意先名称
		    temp.CustomerName = reader.ReadString();
		    //得意先名称2
		    temp.CustomerName2 = reader.ReadString();
		    //得意先略称
		    temp.CustomerSnm = reader.ReadString();
		    //計上年月日
		    temp.AddUpDate = new DateTime(reader.ReadInt64());
		    //計上年月
		    temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
		    //前回請求金額
		    temp.LastTimeDemand = reader.ReadInt64();
		    //今回手数料額（通常入金）
		    temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
		    //今回値引額（通常入金）
		    temp.ThisTimeDisDmdNrml = reader.ReadInt64();
		    //今回入金金額（通常入金）
		    temp.ThisTimeDmdNrml = reader.ReadInt64();
		    //今回繰越残高（請求計）
		    temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
		    //相殺後今回売上金額
		    temp.OfsThisTimeSales = reader.ReadInt64();
		    //相殺後今回売上消費税
		    temp.OfsThisSalesTax = reader.ReadInt64();
		    //相殺後外税対象額
		    temp.ItdedOffsetOutTax = reader.ReadInt64();
		    //相殺後内税対象額
		    temp.ItdedOffsetInTax = reader.ReadInt64();
		    //相殺後非課税対象額
		    temp.ItdedOffsetTaxFree = reader.ReadInt64();
		    //相殺後外税消費税
		    temp.OffsetOutTax = reader.ReadInt64();
		    //相殺後内税消費税
		    temp.OffsetInTax = reader.ReadInt64();
		    //今回売上金額
		    temp.ThisTimeSales = reader.ReadInt64();
		    //今回売上消費税
		    temp.ThisSalesTax = reader.ReadInt64();
		    //売上外税対象額
		    temp.ItdedSalesOutTax = reader.ReadInt64();
		    //売上内税対象額
		    temp.ItdedSalesInTax = reader.ReadInt64();
		    //売上非課税対象額
		    temp.ItdedSalesTaxFree = reader.ReadInt64();
		    //売上外税額
		    temp.SalesOutTax = reader.ReadInt64();
		    //売上内税額
		    temp.SalesInTax = reader.ReadInt64();
		    //今回売上返品金額
		    temp.ThisSalesPricRgds = reader.ReadInt64();
		    //今回売上返品消費税
		    temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
		    //返品外税対象額合計
		    temp.TtlItdedRetOutTax = reader.ReadInt64();
		    //返品内税対象額合計
		    temp.TtlItdedRetInTax = reader.ReadInt64();
		    //返品非課税対象額合計
		    temp.TtlItdedRetTaxFree = reader.ReadInt64();
		    //返品外税額合計
		    temp.TtlRetOuterTax = reader.ReadInt64();
		    //返品内税額合計
		    temp.TtlRetInnerTax = reader.ReadInt64();
		    //今回売上値引金額
		    temp.ThisSalesPricDis = reader.ReadInt64();
		    //今回売上値引消費税
		    temp.ThisSalesPrcTaxDis = reader.ReadInt64();
		    //値引外税対象額合計
		    temp.TtlItdedDisOutTax = reader.ReadInt64();
		    //値引内税対象額合計
		    temp.TtlItdedDisInTax = reader.ReadInt64();
		    //値引非課税対象額合計
		    temp.TtlItdedDisTaxFree = reader.ReadInt64();
		    //値引外税額合計
		    temp.TtlDisOuterTax = reader.ReadInt64();
		    //値引内税額合計
		    temp.TtlDisInnerTax = reader.ReadInt64();
		    //今回支払相殺金額
		    temp.ThisPayOffset = reader.ReadInt64();
		    //今回支払相殺消費税
		    temp.ThisPayOffsetTax = reader.ReadInt64();
		    //支払外税対象額
		    temp.ItdedPaymOutTax = reader.ReadInt64();
		    //支払内税対象額
		    temp.ItdedPaymInTax = reader.ReadInt64();
		    //支払非課税対象額
		    temp.ItdedPaymTaxFree = reader.ReadInt64();
		    //支払外税消費税
		    temp.PaymentOutTax = reader.ReadInt64();
		    //支払内税消費税
		    temp.PaymentInTax = reader.ReadInt64();
		    //消費税調整額
		    temp.TaxAdjust = reader.ReadInt64();
		    //残高調整額
		    temp.BalanceAdjust = reader.ReadInt64();
		    //計算後請求金額
		    temp.AfCalDemandPrice = reader.ReadInt64();
		    //受注2回前残高（請求計）
		    temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
		    //受注3回前残高（請求計）
		    temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
		    //締次更新実行年月日
		    temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
		    //締次更新開始年月日
		    temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
		    //前回締次更新年月日
		    temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
		    //売上伝票枚数
		    temp.SalesSlipCount = reader.ReadInt32();
		    //請求書発行日
		    temp.BillPrintDate = new DateTime(reader.ReadInt64());
		    //入金予定日
		    temp.ExpectedDepositDate = new DateTime(reader.ReadInt64());
		    //回収条件
		    temp.CollectCond = reader.ReadInt32();
		    //消費税率
		    temp.ConsTaxRate = reader.ReadDouble();
		    //端数処理区分
		    temp.FractionProcCd = reader.ReadInt32();            
		    //金種コードリスト
            int ReadCnt = reader.ReadInt32();
            temp.MoneyKindList = new ArrayList();
            for (int cnt = 0; cnt < ReadCnt; cnt++)
            {
                RsltInfo_EBooksDepsitTotalWork rsltInfo_DepsitTotalWork = new RsltInfo_EBooksDepsitTotalWork();
                rsltInfo_DepsitTotalWork.MoneyKindCode = reader.ReadInt32();
                rsltInfo_DepsitTotalWork.MoneyKindName = reader.ReadString();
                rsltInfo_DepsitTotalWork.MoneyKindDiv = reader.ReadInt32();
                rsltInfo_DepsitTotalWork.Deposit = reader.ReadInt64();
                temp.MoneyKindList.Add(rsltInfo_DepsitTotalWork);
            }
            //伝票印刷設定用帳票ID
		    temp.SlipPrtSetPaperId = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //請求拠点コード	
            temp.ClaimSectionCode = reader.ReadString();
            //実績拠点コード
            temp.ResultsSectCd = reader.ReadString();
            //請求書出力区分コード
            temp.BillOutputCode = reader.ReadInt32();
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //領収書出力区分コード
            temp.ReceiptOutputCode = reader.ReadInt32();
            //合計請求書出力区分
            temp.TotalBillOutputDiv = reader.ReadInt32();
            //明細請求書出力区分
            temp.DetailBillOutputCode = reader.ReadInt32();
            //伝票合計請求書出力区分
            temp.SlipTtlBillOutputDiv = reader.ReadInt32();
            //売上額(計税率1)
            temp.TotalThisTimeSalesTaxRate1 = reader.ReadInt64();
            //売上額(計税率2)
            temp.TotalThisTimeSalesTaxRate2 = reader.ReadInt64();
            //売上額(計その他)
            temp.TotalThisTimeSalesOther = reader.ReadInt64();
            //返品値引(計税率1)
            temp.TotalThisRgdsDisPricTaxRate1 = reader.ReadInt64();
            //返品値引(計税率2)
            temp.TotalThisRgdsDisPricTaxRate2 = reader.ReadInt64();
            //返品値引(計その他)
            temp.TotalThisRgdsDisPricOther = reader.ReadInt64();
            //純売上額(計税率1)
            temp.TotalPureSalesTaxRate1 = reader.ReadInt64();
            //純売上額(計税率2)
            temp.TotalPureSalesTaxRate2 = reader.ReadInt64();
            //純売上額(計その他)
            temp.TotalPureSalesOther = reader.ReadInt64();
            //消費税(計税率1)
            temp.TotalSalesPricTaxTaxRate1 = reader.ReadInt64();
            //消費税(計税率2)
            temp.TotalSalesPricTaxTaxRate2 = reader.ReadInt64();
            //消費税(計その他)
            temp.TotalSalesPricTaxOther = reader.ReadInt64();
            //当月合計(計税率1)
            temp.TotalThisSalesSumTaxRate1 = reader.ReadInt64();
            //当月合計(計税率2)
            temp.TotalThisSalesSumTaxRate2 = reader.ReadInt64();
            //当月合計(計その他)
            temp.TotalThisSalesSumTaxOther = reader.ReadInt64();
            //枚数(計税率1)
            temp.TotalSalesSlipCountTaxRate1 = reader.ReadInt32();
            //枚数(計税率2)
            temp.TotalSalesSlipCountTaxRate2 = reader.ReadInt32();
            //枚数(計その他)
            temp.TotalSalesSlipCountOther = reader.ReadInt32();
            //税率1タイトル
            temp.TitleTaxRate1 = reader.ReadString();
            //税率2タイトル
            temp.TitleTaxRate2 = reader.ReadString();
            // --- ADD START 3H 仰亮亮 2022/10/27 ----->>>>>
            // 売上額(計非課税)
            temp.TotalThisTimeSalesTaxFree = reader.ReadInt64();
            // 返品値引(計非課税)
            temp.TotalThisRgdsDisPricTaxFree = reader.ReadInt64();
            // 純仕入額(計非課税)
            temp.TotalPureSalesTaxFree = reader.ReadInt64();
            // 消費税(計非課税)
            temp.TotalSalesPricTaxTaxFree = reader.ReadInt64();
            // 今回合計(計非課税)
            temp.TotalThisSalesSumTaxFree = reader.ReadInt64();
            // 枚数(計非課税)
            temp.TotalSalesSlipCountTaxFree = reader.ReadInt32();
            // --- ADD END 3H 仰亮亮 2022/10/27 -----<<<<<

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
	    /// <returns>RsltInfo_EBooksDemandTotalWorkクラスのインスタンス(object)</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   RsltInfo_EBooksDemandTotalWorkクラスのカスタムデシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    RsltInfo_EBooksDemandTotalWork temp = GetRsltInfo_EBooksDemandTotalWork( reader, serInfo );
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
				    retValue = (RsltInfo_EBooksDemandTotalWork[])lst.ToArray(typeof(RsltInfo_EBooksDemandTotalWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }
}
