using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   KingetCustDmdPrcWork
    /// <summary>
    ///                      KINGET用得意先請求金額クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   KINGET用得意先請求金額クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class KingetCustDmdPrcWork : IFileHeader
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

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先親コード</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

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

        //--- DEL 2008/04/25 M.Kubota --->>>
        //// <summary>今回支払相殺金額</summary>
        //// <remarks>相殺用伝票：相殺用売上伝票計（相殺対象額）</remarks>
        //private Int64 _thisPayOffset;

        //// <summary>今回支払相殺消費税</summary>
        //// <remarks>相殺用伝票：相殺用売上消費税合計</remarks>
        //private Int64 _thisPayOffsetTax;

        //// <summary>支払外税対象額</summary>
        //// <remarks>相殺用伝票：外税額（税抜き）の集計</remarks>
        //private Int64 _itdedPaymOutTax;

        //// <summary>支払内税対象額</summary>
        //// <remarks>相殺用伝票：内税額（税抜き）の集計</remarks>
        //private Int64 _itdedPaymInTax;

        //// <summary>支払非課税対象額</summary>
        //// <remarks>相殺用伝票：非課税額の集計</remarks>
        //private Int64 _itdedPaymTaxFree;

        //// <summary>支払外税消費税</summary>
        //// <remarks>相殺用伝票：外税消費税の集計</remarks>
        //private Int64 _paymentOutTax;

        //// <summary>支払内税消費税</summary>
        //// <remarks>相殺用伝票：内税消費税の集計</remarks>
        //private Int64 _paymentInTax;
        //--- DEL 2008/04/25 M.Kubota ---<<<

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

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>消費税率</summary>
        /// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
        private Double _consTaxRate;

        /// <summary>端数処理区分</summary>
        private Int32 _fractionProcCd;

        /// <summary>敬称</summary>
        private string _honorificTitle = "";

        /// <summary>カナ</summary>
        private string _kana = "";

        /// <summary>諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _outputNameCode;

        /// <summary>諸口名称</summary>
        private string _outputName = "";

        /// <summary>個人・法人区分</summary>
        /// <remarks>0:個人,1:法人,2:大口法人,3:業者,4:社員</remarks>
        private Int32 _corporateDivCode;

        /// <summary>郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _postNo = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address1 = "";

        //--- DEL 2008/04/25 M.Kubota --->>>
        ///// <summary>住所2（丁目）</summary>
        ///// <remarks>納入先の場合の使用可能項目</remarks>
        //private Int32 _address2;
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// <summary>住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address3 = "";

        /// <summary>住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address4 = "";

        /// <summary>電話番号（自宅）</summary>
        /// <remarks>ハイフンを含めた16桁の番号</remarks>
        private string _homeTelNo = "";

        /// <summary>電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _officeTelNo = "";

        /// <summary>電話番号（携帯）</summary>
        private string _portableTelNo = "";

        /// <summary>FAX番号（自宅）</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _officeFaxNo = "";

        /// <summary>電話番号（その他）</summary>
        private string _othersTelNo = "";

        /// <summary>主連絡先区分</summary>
        /// <remarks>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</remarks>
        private Int32 _mainContactCode;

        /// <summary>得意先分析コード1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード6</summary>
        private Int32 _custAnalysCode6;

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>集金月区分コード</summary>
        /// <remarks>0:当月,1:翌月,2:翌々月</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _collectMoneyName = "";

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = "";

        /// <summary>顧客担当従業員名称</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentNm = "";

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = "";

        /// <summary>集金担当従業員名称</summary>
        private string _billCollecterNm = "";

        /// <summary>旧顧客担当従業員コード</summary>
        private string _oldCustomerAgentCd = "";

        /// <summary>旧顧客担当従業員名称</summary>
        private string _oldCustomerAgentNm = "";

        /// <summary>顧客担当変更日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _custAgentChgDate;

        /// <summary>計上年月日範囲（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _startDateSpan;

        /// <summary>計上年月日範囲（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _endDateSpan;


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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先親コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
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
            get { return _claimName; }
            set { _claimName = value; }
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
            get { return _claimName2; }
            set { _claimName2 = value; }
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
            get { return _claimSnm; }
            set { _claimSnm = value; }
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
            get { return _customerCode; }
            set { _customerCode = value; }
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
            get { return _customerName; }
            set { _customerName = value; }
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
            get { return _customerName2; }
            set { _customerName2 = value; }
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
            get { return _customerSnm; }
            set { _customerSnm = value; }
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
            get { return _addUpDate; }
            set { _addUpDate = value; }
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
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
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
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
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
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
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
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
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
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
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
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
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
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
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
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
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
            get { return _itdedOffsetOutTax; }
            set { _itdedOffsetOutTax = value; }
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
            get { return _itdedOffsetInTax; }
            set { _itdedOffsetInTax = value; }
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
            get { return _itdedOffsetTaxFree; }
            set { _itdedOffsetTaxFree = value; }
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
            get { return _offsetOutTax; }
            set { _offsetOutTax = value; }
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
            get { return _offsetInTax; }
            set { _offsetInTax = value; }
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
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
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
            get { return _thisSalesTax; }
            set { _thisSalesTax = value; }
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
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
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
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
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
            get { return _itdedSalesTaxFree; }
            set { _itdedSalesTaxFree = value; }
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
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
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
            get { return _salesInTax; }
            set { _salesInTax = value; }
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
            get { return _thisSalesPricRgds; }
            set { _thisSalesPricRgds = value; }
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
            get { return _thisSalesPrcTaxRgds; }
            set { _thisSalesPrcTaxRgds = value; }
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
            get { return _ttlItdedRetOutTax; }
            set { _ttlItdedRetOutTax = value; }
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
            get { return _ttlItdedRetInTax; }
            set { _ttlItdedRetInTax = value; }
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
            get { return _ttlItdedRetTaxFree; }
            set { _ttlItdedRetTaxFree = value; }
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
            get { return _ttlRetOuterTax; }
            set { _ttlRetOuterTax = value; }
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
            get { return _ttlRetInnerTax; }
            set { _ttlRetInnerTax = value; }
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
            get { return _thisSalesPricDis; }
            set { _thisSalesPricDis = value; }
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
            get { return _thisSalesPrcTaxDis; }
            set { _thisSalesPrcTaxDis = value; }
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
            get { return _ttlItdedDisOutTax; }
            set { _ttlItdedDisOutTax = value; }
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
            get { return _ttlItdedDisInTax; }
            set { _ttlItdedDisInTax = value; }
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
            get { return _ttlItdedDisTaxFree; }
            set { _ttlItdedDisTaxFree = value; }
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
            get { return _ttlDisOuterTax; }
            set { _ttlDisOuterTax = value; }
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
            get { return _ttlDisInnerTax; }
            set { _ttlDisInnerTax = value; }
        }

        //--- DEL 2008/04/25 M.Kubota --->>>
        ///// public propaty name  :  ThisPayOffset
        ///// <summary>今回支払相殺金額プロパティ</summary>
        ///// <value>相殺用伝票：相殺用売上伝票計（相殺対象額）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   今回支払相殺金額プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 ThisPayOffset
        //{
        //    get { return _thisPayOffset; }
        //    set { _thisPayOffset = value; }
        //}

        ///// public propaty name  :  ThisPayOffsetTax
        ///// <summary>今回支払相殺消費税プロパティ</summary>
        ///// <value>相殺用伝票：相殺用売上消費税合計</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   今回支払相殺消費税プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 ThisPayOffsetTax
        //{
        //    get { return _thisPayOffsetTax; }
        //    set { _thisPayOffsetTax = value; }
        //}

        ///// public propaty name  :  ItdedPaymOutTax
        ///// <summary>支払外税対象額プロパティ</summary>
        ///// <value>相殺用伝票：外税額（税抜き）の集計</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   支払外税対象額プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 ItdedPaymOutTax
        //{
        //    get { return _itdedPaymOutTax; }
        //    set { _itdedPaymOutTax = value; }
        //}

        ///// public propaty name  :  ItdedPaymInTax
        ///// <summary>支払内税対象額プロパティ</summary>
        ///// <value>相殺用伝票：内税額（税抜き）の集計</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   支払内税対象額プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        ////public Int64 ItdedPaymInTax
        //{
        //    get { return _itdedPaymInTax; }
        //    set { _itdedPaymInTax = value; }
        //}

        ///// public propaty name  :  ItdedPaymTaxFree
        ///// <summary>支払非課税対象額プロパティ</summary>
        ///// <value>相殺用伝票：非課税額の集計</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   支払非課税対象額プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 ItdedPaymTaxFree
        //{
        //    get { return _itdedPaymTaxFree; }
        //    set { _itdedPaymTaxFree = value; }
        //}

        ///// public propaty name  :  PaymentOutTax
        ///// <summary>支払外税消費税プロパティ</summary>
        ///// <value>相殺用伝票：外税消費税の集計</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   支払外税消費税プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 PaymentOutTax
        //{
        //    get { return _paymentOutTax; }
        //    set { _paymentOutTax = value; }
        //}

        ///// public propaty name  :  PaymentInTax
        ///// <summary>支払内税消費税プロパティ</summary>
        ///// <value>相殺用伝票：内税消費税の集計</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   支払内税消費税プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 PaymentInTax
        //{
        //    get { return _paymentInTax; }
        //    set { _paymentInTax = value; }
        //}
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// public propaty name  :  TaxAdjust
        /// <summary>消費税調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
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
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
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
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
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
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
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
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
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
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
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
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
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
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
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
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
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
            get { return _billPrintDate; }
            set { _billPrintDate = value; }
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
            get { return _expectedDepositDate; }
            set { _expectedDepositDate = value; }
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
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
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
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
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
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  OutputNameCode
        /// <summary>諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>諸口名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CorporateDivCode
        /// <summary>個人・法人区分プロパティ</summary>
        /// <value>0:個人,1:法人,2:大口法人,3:業者,4:社員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   個人・法人区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CorporateDivCode
        {
            get { return _corporateDivCode; }
            set { _corporateDivCode = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        //--- DEL 2008/04/25 M.Kubota --->>>
        ///// public propaty name  :  Address2
        ///// <summary>住所2（丁目）プロパティ</summary>
        ///// <value>納入先の場合の使用可能項目</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   住所2（丁目）プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Address2
        //{
        //    get { return _address2; }
        //    set { _address2 = value; }
        //}
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// public propaty name  :  Address3
        /// <summary>住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>電話番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  OthersTelNo
        /// <summary>電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OthersTelNo
        {
            get { return _othersTelNo; }
            set { _othersTelNo = value; }
        }

        /// public propaty name  :  MainContactCode
        /// <summary>主連絡先区分プロパティ</summary>
        /// <value>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主連絡先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainContactCode
        {
            get { return _mainContactCode; }
            set { _mainContactCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>集金月区分コードプロパティ</summary>
        /// <value>0:当月,1:翌月,2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>集金担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  OldCustomerAgentCd
        /// <summary>旧顧客担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldCustomerAgentCd
        {
            get { return _oldCustomerAgentCd; }
            set { _oldCustomerAgentCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentNm
        /// <summary>旧顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldCustomerAgentNm
        {
            get { return _oldCustomerAgentNm; }
            set { _oldCustomerAgentNm = value; }
        }

        /// public propaty name  :  CustAgentChgDate
        /// <summary>顧客担当変更日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CustAgentChgDate
        {
            get { return _custAgentChgDate; }
            set { _custAgentChgDate = value; }
        }

        /// public propaty name  :  StartDateSpan
        /// <summary>計上年月日範囲（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日範囲（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartDateSpan
        {
            get { return _startDateSpan; }
            set { _startDateSpan = value; }
        }

        /// public propaty name  :  EndDateSpan
        /// <summary>計上年月日範囲（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日範囲（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndDateSpan
        {
            get { return _endDateSpan; }
            set { _endDateSpan = value; }
        }


        /// <summary>
        /// KINGET用得意先請求金額クラスワークコンストラクタ
        /// </summary>
        /// <returns>KingetCustDmdPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public KingetCustDmdPrcWork()
        {
        }

        /// <summary>
        /// KINGET用得意先請求金額クラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="claimCode">請求先コード(請求先親コード)</param>
        /// <param name="claimName">請求先名称</param>
        /// <param name="claimName2">請求先名称2</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="addUpDate">計上年月日(YYYYMMDD 請求締を行なった日（相手先基準）)</param>
        /// <param name="addUpYearMonth">計上年月(YYYYMM)</param>
        /// <param name="lastTimeDemand">前回請求金額</param>
        /// <param name="thisTimeFeeDmdNrml">今回手数料額（通常入金）</param>
        /// <param name="thisTimeDisDmdNrml">今回値引額（通常入金）</param>
        /// <param name="thisTimeDmdNrml">今回入金金額（通常入金）(入金額の合計金額)</param>
        /// <param name="thisTimeTtlBlcDmd">今回繰越残高（請求計）(今回繰越残高＝前回請求額－今回入金額合計（通常）)</param>
        /// <param name="ofsThisTimeSales">相殺後今回売上金額</param>
        /// <param name="ofsThisSalesTax">相殺後今回売上消費税</param>
        /// <param name="itdedOffsetOutTax">相殺後外税対象額(相殺用：外税額（税抜き）の集計)</param>
        /// <param name="itdedOffsetInTax">相殺後内税対象額(相殺用：内税額（税抜き）の集計)</param>
        /// <param name="itdedOffsetTaxFree">相殺後非課税対象額(相殺用：非課税額の集計)</param>
        /// <param name="offsetOutTax">相殺後外税消費税(相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）)</param>
        /// <param name="offsetInTax">相殺後内税消費税(相殺用：内税消費税の集計)</param>
        /// <param name="thisTimeSales">今回売上金額(掛売：値引、返品を含まない税抜きの売上金額)</param>
        /// <param name="thisSalesTax">今回売上消費税</param>
        /// <param name="itdedSalesOutTax">売上外税対象額(請求用：外税額（税抜き）の集計)</param>
        /// <param name="itdedSalesInTax">売上内税対象額(請求用：内税額（税抜き）の集計)</param>
        /// <param name="itdedSalesTaxFree">売上非課税対象額(請求用：非課税額の集計)</param>
        /// <param name="salesOutTax">売上外税額(請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）)</param>
        /// <param name="salesInTax">売上内税額(掛売：内税商品売上の内税消費税額（返品、値引含まず）)</param>
        /// <param name="thisSalesPricRgds">今回売上返品金額(掛売：値引を含まない税抜きの売上返品金額)</param>
        /// <param name="thisSalesPrcTaxRgds">今回売上返品消費税(今回売上返品消費税＝返品外税額合計＋返品内税額合計)</param>
        /// <param name="ttlItdedRetOutTax">返品外税対象額合計</param>
        /// <param name="ttlItdedRetInTax">返品内税対象額合計</param>
        /// <param name="ttlItdedRetTaxFree">返品非課税対象額合計</param>
        /// <param name="ttlRetOuterTax">返品外税額合計</param>
        /// <param name="ttlRetInnerTax">返品内税額合計(掛売：内税商品返品の内税消費税額（値引含まず）)</param>
        /// <param name="thisSalesPricDis">今回売上値引金額(掛売：税抜きの売上値引金額)</param>
        /// <param name="thisSalesPrcTaxDis">今回売上値引消費税(今回売上値引消費税＝値引外税額合計＋値引内税額合計)</param>
        /// <param name="ttlItdedDisOutTax">値引外税対象額合計</param>
        /// <param name="ttlItdedDisInTax">値引内税対象額合計</param>
        /// <param name="ttlItdedDisTaxFree">値引非課税対象額合計</param>
        /// <param name="ttlDisOuterTax">値引外税額合計</param>
        /// <param name="ttlDisInnerTax">値引内税額合計(掛売：内税商品返品の内税消費税額)</param>
        /// <param name="taxAdjust">消費税調整額</param>
        /// <param name="balanceAdjust">残高調整額</param>
        /// <param name="afCalDemandPrice">計算後請求金額(今回請求金額)</param>
        /// <param name="acpOdrTtl2TmBfBlDmd">受注2回前残高（請求計）</param>
        /// <param name="acpOdrTtl3TmBfBlDmd">受注3回前残高（請求計）</param>
        /// <param name="cAddUpUpdExecDate">締次更新実行年月日(YYYYMMDD)</param>
        /// <param name="startCAddUpUpdDate">締次更新開始年月日("YYYYMMDD"  締次更新対象となる開始年月日)</param>
        /// <param name="lastCAddUpUpdDate">前回締次更新年月日("YYYYMMDD"  前回締次更新対象となった年月日)</param>
        /// <param name="salesSlipCount">売上伝票枚数(掛売の伝票枚数)</param>
        /// <param name="billPrintDate">請求書発行日("YYYYMMDD"  請求書を発行した年月日)</param>
        /// <param name="expectedDepositDate">入金予定日</param>
        /// <param name="collectCond">回収条件(10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他)</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括)</param>
        /// <param name="consTaxRate">消費税率(請求転嫁消費税を算出する場合に使用)</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="kana">カナ</param>
        /// <param name="outputNameCode">諸口コード(0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称)</param>
        /// <param name="outputName">諸口名称</param>
        /// <param name="corporateDivCode">個人・法人区分(0:個人,1:法人,2:大口法人,3:業者,4:社員)</param>
        /// <param name="postNo">郵便番号(納入先の場合の使用可能項目)</param>
        /// <param name="address1">住所1（都道府県市区郡・町村・字）(納入先の場合の使用可能項目)</param>
        /// <param name="address3">住所3（番地）(納入先の場合の使用可能項目)</param>
        /// <param name="address4">住所4（アパート名称）(納入先の場合の使用可能項目)</param>
        /// <param name="homeTelNo">電話番号（自宅）(ハイフンを含めた16桁の番号)</param>
        /// <param name="officeTelNo">電話番号（勤務先）(納入先の場合の使用可能項目)</param>
        /// <param name="portableTelNo">電話番号（携帯）</param>
        /// <param name="homeFaxNo">FAX番号（自宅）</param>
        /// <param name="officeFaxNo">FAX番号（勤務先）(納入先の場合の使用可能項目)</param>
        /// <param name="othersTelNo">電話番号（その他）</param>
        /// <param name="mainContactCode">主連絡先区分(0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･)</param>
        /// <param name="custAnalysCode1">得意先分析コード1</param>
        /// <param name="custAnalysCode2">得意先分析コード2</param>
        /// <param name="custAnalysCode3">得意先分析コード3</param>
        /// <param name="custAnalysCode4">得意先分析コード4</param>
        /// <param name="custAnalysCode5">得意先分析コード5</param>
        /// <param name="custAnalysCode6">得意先分析コード6</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="collectMoneyCode">集金月区分コード(0:当月,1:翌月,2:翌々月)</param>
        /// <param name="collectMoneyName">集金月区分名称(当月,翌月,翌々月)</param>
        /// <param name="collectMoneyDay">集金日(DD)</param>
        /// <param name="customerAgentCd">顧客担当従業員コード(文字型)</param>
        /// <param name="customerAgentNm">顧客担当従業員名称(文字型)</param>
        /// <param name="billCollecterCd">集金担当従業員コード</param>
        /// <param name="billCollecterNm">集金担当従業員名称</param>
        /// <param name="oldCustomerAgentCd">旧顧客担当従業員コード</param>
        /// <param name="oldCustomerAgentNm">旧顧客担当従業員名称</param>
        /// <param name="custAgentChgDate">顧客担当変更日(YYYYMMDD)</param>
        /// <param name="startDateSpan">計上年月日範囲（開始）(YYYYMMDD)</param>
        /// <param name="endDateSpan">計上年月日範囲（終了）(YYYYMMDD)</param>
        /// <returns>KingetCustDmdPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public KingetCustDmdPrcWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeSales, Int64 thisSalesTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 thisPayOffset, Int64 thisPayOffsetTax, Int64 itdedPaymOutTax, Int64 itdedPaymInTax, Int64 itdedPaymTaxFree, Int64 paymentOutTax, Int64 paymentInTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 salesSlipCount, DateTime billPrintDate, DateTime expectedDepositDate, Int32 collectCond, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, string honorificTitle, string kana, Int32 outputNameCode, string outputName, Int32 corporateDivCode, string postNo, string address1, Int32 address2, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, string oldCustomerAgentCd, string oldCustomerAgentNm, DateTime custAgentChgDate, Int32 startDateSpan, Int32 endDateSpan)  //DEL 2008/04/25 M.Kubota
        public KingetCustDmdPrcWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeSales, Int64 thisSalesTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 salesSlipCount, DateTime billPrintDate, DateTime expectedDepositDate, Int32 collectCond, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, string honorificTitle, string kana, Int32 outputNameCode, string outputName, Int32 corporateDivCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, string oldCustomerAgentCd, string oldCustomerAgentNm, DateTime custAgentChgDate, Int32 startDateSpan, Int32 endDateSpan)                    //ADD 2008/04/25 M.Kubota
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._addUpSecCode = addUpSecCode;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimeDemand = lastTimeDemand;
            this._thisTimeFeeDmdNrml = thisTimeFeeDmdNrml;
            this._thisTimeDisDmdNrml = thisTimeDisDmdNrml;
            this._thisTimeDmdNrml = thisTimeDmdNrml;
            this._thisTimeTtlBlcDmd = thisTimeTtlBlcDmd;
            this._ofsThisTimeSales = ofsThisTimeSales;
            this._ofsThisSalesTax = ofsThisSalesTax;
            this._itdedOffsetOutTax = itdedOffsetOutTax;
            this._itdedOffsetInTax = itdedOffsetInTax;
            this._itdedOffsetTaxFree = itdedOffsetTaxFree;
            this._offsetOutTax = offsetOutTax;
            this._offsetInTax = offsetInTax;
            this._thisTimeSales = thisTimeSales;
            this._thisSalesTax = thisSalesTax;
            this._itdedSalesOutTax = itdedSalesOutTax;
            this._itdedSalesInTax = itdedSalesInTax;
            this._itdedSalesTaxFree = itdedSalesTaxFree;
            this._salesOutTax = salesOutTax;
            this._salesInTax = salesInTax;
            this._thisSalesPricRgds = thisSalesPricRgds;
            this._thisSalesPrcTaxRgds = thisSalesPrcTaxRgds;
            this._ttlItdedRetOutTax = ttlItdedRetOutTax;
            this._ttlItdedRetInTax = ttlItdedRetInTax;
            this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
            this._ttlRetOuterTax = ttlRetOuterTax;
            this._ttlRetInnerTax = ttlRetInnerTax;
            this._thisSalesPricDis = thisSalesPricDis;
            this._thisSalesPrcTaxDis = thisSalesPrcTaxDis;
            this._ttlItdedDisOutTax = ttlItdedDisOutTax;
            this._ttlItdedDisInTax = ttlItdedDisInTax;
            this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
            this._ttlDisOuterTax = ttlDisOuterTax;
            this._ttlDisInnerTax = ttlDisInnerTax;
            //--- DEL 2008/04/25 M.Kubota --->>>
            //this._thisPayOffset = thisPayOffset;
            //this._thisPayOffsetTax = thisPayOffsetTax;
            //this._itdedPaymOutTax = itdedPaymOutTax;
            //this._itdedPaymInTax = itdedPaymInTax;
            //this._itdedPaymTaxFree = itdedPaymTaxFree;
            //this._paymentOutTax = paymentOutTax;
            //this._paymentInTax = paymentInTax;
            //--- DEL 2008/04/25 M.Kubota ---<<<
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
            this._afCalDemandPrice = afCalDemandPrice;
            this._acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd;
            this._acpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this._salesSlipCount = salesSlipCount;
            this.BillPrintDate = billPrintDate;
            this.ExpectedDepositDate = expectedDepositDate;
            this._collectCond = collectCond;
            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._corporateDivCode = corporateDivCode;
            this._postNo = postNo;
            this._address1 = address1;
            //this._address2 = address2;  //DEL 2008/04/25 M.Kubota
            this._address3 = address3;
            this._address4 = address4;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._othersTelNo = othersTelNo;
            this._mainContactCode = mainContactCode;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._totalDay = totalDay;
            this._collectMoneyCode = collectMoneyCode;
            this._collectMoneyName = collectMoneyName;
            this._collectMoneyDay = collectMoneyDay;
            this._customerAgentCd = customerAgentCd;
            this._customerAgentNm = customerAgentNm;
            this._billCollecterCd = billCollecterCd;
            this._billCollecterNm = billCollecterNm;
            this._oldCustomerAgentCd = oldCustomerAgentCd;
            this._oldCustomerAgentNm = oldCustomerAgentNm;
            this.CustAgentChgDate = custAgentChgDate;
            this._startDateSpan = startDateSpan;
            this._endDateSpan = endDateSpan;

        }

        /// <summary>
        /// KINGET用得意先請求金額クラス複製処理
        /// </summary>
        /// <returns>KingetCustDmdPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいKingetCustDmdPrcWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public KingetCustDmdPrcWork Clone()
        {
            //return new KingetCustDmdPrcWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeDmdNrml, this._thisTimeTtlBlcDmd, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeSales, this._thisSalesTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._thisPayOffset, this._thisPayOffsetTax, this._itdedPaymOutTax, this._itdedPaymInTax, this._itdedPaymTaxFree, this._paymentOutTax, this._paymentInTax, this._taxAdjust, this._balanceAdjust, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._salesSlipCount, this._billPrintDate, this._expectedDepositDate, this._collectCond, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._honorificTitle, this._kana, this._outputNameCode, this._outputName, this._corporateDivCode, this._postNo, this._address1, this._address2, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._oldCustomerAgentCd, this._oldCustomerAgentNm, this._custAgentChgDate, this._startDateSpan, this._endDateSpan);  //DEL 2008/04/25 M.Kubota
            return new KingetCustDmdPrcWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeDmdNrml, this._thisTimeTtlBlcDmd, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeSales, this._thisSalesTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._taxAdjust, this._balanceAdjust, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._salesSlipCount, this._billPrintDate, this._expectedDepositDate, this._collectCond, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._honorificTitle, this._kana, this._outputNameCode, this._outputName, this._corporateDivCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._oldCustomerAgentCd, this._oldCustomerAgentNm, this._custAgentChgDate, this._startDateSpan, this._endDateSpan);                    //ADD 2008/04/25 M.Kubota
        }

        /// <summary>
        /// KINGET用得意先請求金額クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のKingetCustDmdPrcWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(KingetCustDmdPrcWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimeDemand == target.LastTimeDemand)
                 && (this.ThisTimeFeeDmdNrml == target.ThisTimeFeeDmdNrml)
                 && (this.ThisTimeDisDmdNrml == target.ThisTimeDisDmdNrml)
                 && (this.ThisTimeDmdNrml == target.ThisTimeDmdNrml)
                 && (this.ThisTimeTtlBlcDmd == target.ThisTimeTtlBlcDmd)
                 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
                 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
                 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
                 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
                 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
                 && (this.OffsetOutTax == target.OffsetOutTax)
                 && (this.OffsetInTax == target.OffsetInTax)
                 && (this.ThisTimeSales == target.ThisTimeSales)
                 && (this.ThisSalesTax == target.ThisSalesTax)
                 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
                 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
                 && (this.ItdedSalesTaxFree == target.ItdedSalesTaxFree)
                 && (this.SalesOutTax == target.SalesOutTax)
                 && (this.SalesInTax == target.SalesInTax)
                 && (this.ThisSalesPricRgds == target.ThisSalesPricRgds)
                 && (this.ThisSalesPrcTaxRgds == target.ThisSalesPrcTaxRgds)
                 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
                 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
                 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
                 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
                 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
                 && (this.ThisSalesPricDis == target.ThisSalesPricDis)
                 && (this.ThisSalesPrcTaxDis == target.ThisSalesPrcTaxDis)
                 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
                 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
                 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
                 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
                 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
                 //--- DEL 2008/04/25 M.Kubota --->>>
                 //&& (this.ThisPayOffset == target.ThisPayOffset)
                 //&& (this.ThisPayOffsetTax == target.ThisPayOffsetTax)
                 //&& (this.ItdedPaymOutTax == target.ItdedPaymOutTax)
                 //&& (this.ItdedPaymInTax == target.ItdedPaymInTax)
                 //&& (this.ItdedPaymTaxFree == target.ItdedPaymTaxFree)
                 //&& (this.PaymentOutTax == target.PaymentOutTax)
                 //&& (this.PaymentInTax == target.PaymentInTax)
                 //--- DEL 2008/04/25 M.Kubota ---<<<
                 && (this.TaxAdjust == target.TaxAdjust)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.AfCalDemandPrice == target.AfCalDemandPrice)
                 && (this.AcpOdrTtl2TmBfBlDmd == target.AcpOdrTtl2TmBfBlDmd)
                 && (this.AcpOdrTtl3TmBfBlDmd == target.AcpOdrTtl3TmBfBlDmd)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.SalesSlipCount == target.SalesSlipCount)
                 && (this.BillPrintDate == target.BillPrintDate)
                 && (this.ExpectedDepositDate == target.ExpectedDepositDate)
                 && (this.CollectCond == target.CollectCond)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.OutputName == target.OutputName)
                 && (this.CorporateDivCode == target.CorporateDivCode)
                 && (this.PostNo == target.PostNo)
                 && (this.Address1 == target.Address1)
                 //&& (this.Address2 == target.Address2)  //DEL 2008/04/25 M.Kubota
                 && (this.Address3 == target.Address3)
                 && (this.Address4 == target.Address4)
                 && (this.HomeTelNo == target.HomeTelNo)
                 && (this.OfficeTelNo == target.OfficeTelNo)
                 && (this.PortableTelNo == target.PortableTelNo)
                 && (this.HomeFaxNo == target.HomeFaxNo)
                 && (this.OfficeFaxNo == target.OfficeFaxNo)
                 && (this.OthersTelNo == target.OthersTelNo)
                 && (this.MainContactCode == target.MainContactCode)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.TotalDay == target.TotalDay)
                 && (this.CollectMoneyCode == target.CollectMoneyCode)
                 && (this.CollectMoneyName == target.CollectMoneyName)
                 && (this.CollectMoneyDay == target.CollectMoneyDay)
                 && (this.CustomerAgentCd == target.CustomerAgentCd)
                 && (this.CustomerAgentNm == target.CustomerAgentNm)
                 && (this.BillCollecterCd == target.BillCollecterCd)
                 && (this.BillCollecterNm == target.BillCollecterNm)
                 && (this.OldCustomerAgentCd == target.OldCustomerAgentCd)
                 && (this.OldCustomerAgentNm == target.OldCustomerAgentNm)
                 && (this.CustAgentChgDate == target.CustAgentChgDate)
                 && (this.StartDateSpan == target.StartDateSpan)
                 && (this.EndDateSpan == target.EndDateSpan));
        }

        /// <summary>
        /// KINGET用得意先請求金額クラス比較処理
        /// </summary>
        /// <param name="kingetCustDmdPrc1">
        ///                    比較するKingetCustDmdPrcWorkクラスのインスタンス
        /// </param>
        /// <param name="kingetCustDmdPrc2">比較するKingetCustDmdPrcWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(KingetCustDmdPrcWork kingetCustDmdPrc1, KingetCustDmdPrcWork kingetCustDmdPrc2)
        {
            return ((kingetCustDmdPrc1.CreateDateTime == kingetCustDmdPrc2.CreateDateTime)
                 && (kingetCustDmdPrc1.UpdateDateTime == kingetCustDmdPrc2.UpdateDateTime)
                 && (kingetCustDmdPrc1.EnterpriseCode == kingetCustDmdPrc2.EnterpriseCode)
                 && (kingetCustDmdPrc1.FileHeaderGuid == kingetCustDmdPrc2.FileHeaderGuid)
                 && (kingetCustDmdPrc1.UpdEmployeeCode == kingetCustDmdPrc2.UpdEmployeeCode)
                 && (kingetCustDmdPrc1.UpdAssemblyId1 == kingetCustDmdPrc2.UpdAssemblyId1)
                 && (kingetCustDmdPrc1.UpdAssemblyId2 == kingetCustDmdPrc2.UpdAssemblyId2)
                 && (kingetCustDmdPrc1.LogicalDeleteCode == kingetCustDmdPrc2.LogicalDeleteCode)
                 && (kingetCustDmdPrc1.AddUpSecCode == kingetCustDmdPrc2.AddUpSecCode)
                 && (kingetCustDmdPrc1.ClaimCode == kingetCustDmdPrc2.ClaimCode)
                 && (kingetCustDmdPrc1.ClaimName == kingetCustDmdPrc2.ClaimName)
                 && (kingetCustDmdPrc1.ClaimName2 == kingetCustDmdPrc2.ClaimName2)
                 && (kingetCustDmdPrc1.ClaimSnm == kingetCustDmdPrc2.ClaimSnm)
                 && (kingetCustDmdPrc1.CustomerCode == kingetCustDmdPrc2.CustomerCode)
                 && (kingetCustDmdPrc1.CustomerName == kingetCustDmdPrc2.CustomerName)
                 && (kingetCustDmdPrc1.CustomerName2 == kingetCustDmdPrc2.CustomerName2)
                 && (kingetCustDmdPrc1.CustomerSnm == kingetCustDmdPrc2.CustomerSnm)
                 && (kingetCustDmdPrc1.AddUpDate == kingetCustDmdPrc2.AddUpDate)
                 && (kingetCustDmdPrc1.AddUpYearMonth == kingetCustDmdPrc2.AddUpYearMonth)
                 && (kingetCustDmdPrc1.LastTimeDemand == kingetCustDmdPrc2.LastTimeDemand)
                 && (kingetCustDmdPrc1.ThisTimeFeeDmdNrml == kingetCustDmdPrc2.ThisTimeFeeDmdNrml)
                 && (kingetCustDmdPrc1.ThisTimeDisDmdNrml == kingetCustDmdPrc2.ThisTimeDisDmdNrml)
                 && (kingetCustDmdPrc1.ThisTimeDmdNrml == kingetCustDmdPrc2.ThisTimeDmdNrml)
                 && (kingetCustDmdPrc1.ThisTimeTtlBlcDmd == kingetCustDmdPrc2.ThisTimeTtlBlcDmd)
                 && (kingetCustDmdPrc1.OfsThisTimeSales == kingetCustDmdPrc2.OfsThisTimeSales)
                 && (kingetCustDmdPrc1.OfsThisSalesTax == kingetCustDmdPrc2.OfsThisSalesTax)
                 && (kingetCustDmdPrc1.ItdedOffsetOutTax == kingetCustDmdPrc2.ItdedOffsetOutTax)
                 && (kingetCustDmdPrc1.ItdedOffsetInTax == kingetCustDmdPrc2.ItdedOffsetInTax)
                 && (kingetCustDmdPrc1.ItdedOffsetTaxFree == kingetCustDmdPrc2.ItdedOffsetTaxFree)
                 && (kingetCustDmdPrc1.OffsetOutTax == kingetCustDmdPrc2.OffsetOutTax)
                 && (kingetCustDmdPrc1.OffsetInTax == kingetCustDmdPrc2.OffsetInTax)
                 && (kingetCustDmdPrc1.ThisTimeSales == kingetCustDmdPrc2.ThisTimeSales)
                 && (kingetCustDmdPrc1.ThisSalesTax == kingetCustDmdPrc2.ThisSalesTax)
                 && (kingetCustDmdPrc1.ItdedSalesOutTax == kingetCustDmdPrc2.ItdedSalesOutTax)
                 && (kingetCustDmdPrc1.ItdedSalesInTax == kingetCustDmdPrc2.ItdedSalesInTax)
                 && (kingetCustDmdPrc1.ItdedSalesTaxFree == kingetCustDmdPrc2.ItdedSalesTaxFree)
                 && (kingetCustDmdPrc1.SalesOutTax == kingetCustDmdPrc2.SalesOutTax)
                 && (kingetCustDmdPrc1.SalesInTax == kingetCustDmdPrc2.SalesInTax)
                 && (kingetCustDmdPrc1.ThisSalesPricRgds == kingetCustDmdPrc2.ThisSalesPricRgds)
                 && (kingetCustDmdPrc1.ThisSalesPrcTaxRgds == kingetCustDmdPrc2.ThisSalesPrcTaxRgds)
                 && (kingetCustDmdPrc1.TtlItdedRetOutTax == kingetCustDmdPrc2.TtlItdedRetOutTax)
                 && (kingetCustDmdPrc1.TtlItdedRetInTax == kingetCustDmdPrc2.TtlItdedRetInTax)
                 && (kingetCustDmdPrc1.TtlItdedRetTaxFree == kingetCustDmdPrc2.TtlItdedRetTaxFree)
                 && (kingetCustDmdPrc1.TtlRetOuterTax == kingetCustDmdPrc2.TtlRetOuterTax)
                 && (kingetCustDmdPrc1.TtlRetInnerTax == kingetCustDmdPrc2.TtlRetInnerTax)
                 && (kingetCustDmdPrc1.ThisSalesPricDis == kingetCustDmdPrc2.ThisSalesPricDis)
                 && (kingetCustDmdPrc1.ThisSalesPrcTaxDis == kingetCustDmdPrc2.ThisSalesPrcTaxDis)
                 && (kingetCustDmdPrc1.TtlItdedDisOutTax == kingetCustDmdPrc2.TtlItdedDisOutTax)
                 && (kingetCustDmdPrc1.TtlItdedDisInTax == kingetCustDmdPrc2.TtlItdedDisInTax)
                 && (kingetCustDmdPrc1.TtlItdedDisTaxFree == kingetCustDmdPrc2.TtlItdedDisTaxFree)
                 && (kingetCustDmdPrc1.TtlDisOuterTax == kingetCustDmdPrc2.TtlDisOuterTax)
                 && (kingetCustDmdPrc1.TtlDisInnerTax == kingetCustDmdPrc2.TtlDisInnerTax)
                 //--- DEL 2008/04/25 M.Kubota --->>>
                 //&& (kingetCustDmdPrc1.ThisPayOffset == kingetCustDmdPrc2.ThisPayOffset)
                 //&& (kingetCustDmdPrc1.ThisPayOffsetTax == kingetCustDmdPrc2.ThisPayOffsetTax)
                 //&& (kingetCustDmdPrc1.ItdedPaymOutTax == kingetCustDmdPrc2.ItdedPaymOutTax)
                 //&& (kingetCustDmdPrc1.ItdedPaymInTax == kingetCustDmdPrc2.ItdedPaymInTax)
                 //&& (kingetCustDmdPrc1.ItdedPaymTaxFree == kingetCustDmdPrc2.ItdedPaymTaxFree)
                 //&& (kingetCustDmdPrc1.PaymentOutTax == kingetCustDmdPrc2.PaymentOutTax)
                 //&& (kingetCustDmdPrc1.PaymentInTax == kingetCustDmdPrc2.PaymentInTax)
                 //--- DEL 2008/04/25 M.Kubota ---<<<
                 && (kingetCustDmdPrc1.TaxAdjust == kingetCustDmdPrc2.TaxAdjust)
                 && (kingetCustDmdPrc1.BalanceAdjust == kingetCustDmdPrc2.BalanceAdjust)
                 && (kingetCustDmdPrc1.AfCalDemandPrice == kingetCustDmdPrc2.AfCalDemandPrice)
                 && (kingetCustDmdPrc1.AcpOdrTtl2TmBfBlDmd == kingetCustDmdPrc2.AcpOdrTtl2TmBfBlDmd)
                 && (kingetCustDmdPrc1.AcpOdrTtl3TmBfBlDmd == kingetCustDmdPrc2.AcpOdrTtl3TmBfBlDmd)
                 && (kingetCustDmdPrc1.CAddUpUpdExecDate == kingetCustDmdPrc2.CAddUpUpdExecDate)
                 && (kingetCustDmdPrc1.StartCAddUpUpdDate == kingetCustDmdPrc2.StartCAddUpUpdDate)
                 && (kingetCustDmdPrc1.LastCAddUpUpdDate == kingetCustDmdPrc2.LastCAddUpUpdDate)
                 && (kingetCustDmdPrc1.SalesSlipCount == kingetCustDmdPrc2.SalesSlipCount)
                 && (kingetCustDmdPrc1.BillPrintDate == kingetCustDmdPrc2.BillPrintDate)
                 && (kingetCustDmdPrc1.ExpectedDepositDate == kingetCustDmdPrc2.ExpectedDepositDate)
                 && (kingetCustDmdPrc1.CollectCond == kingetCustDmdPrc2.CollectCond)
                 && (kingetCustDmdPrc1.ConsTaxLayMethod == kingetCustDmdPrc2.ConsTaxLayMethod)
                 && (kingetCustDmdPrc1.ConsTaxRate == kingetCustDmdPrc2.ConsTaxRate)
                 && (kingetCustDmdPrc1.FractionProcCd == kingetCustDmdPrc2.FractionProcCd)
                 && (kingetCustDmdPrc1.HonorificTitle == kingetCustDmdPrc2.HonorificTitle)
                 && (kingetCustDmdPrc1.Kana == kingetCustDmdPrc2.Kana)
                 && (kingetCustDmdPrc1.OutputNameCode == kingetCustDmdPrc2.OutputNameCode)
                 && (kingetCustDmdPrc1.OutputName == kingetCustDmdPrc2.OutputName)
                 && (kingetCustDmdPrc1.CorporateDivCode == kingetCustDmdPrc2.CorporateDivCode)
                 && (kingetCustDmdPrc1.PostNo == kingetCustDmdPrc2.PostNo)
                 && (kingetCustDmdPrc1.Address1 == kingetCustDmdPrc2.Address1)
                 //&& (kingetCustDmdPrc1.Address2 == kingetCustDmdPrc2.Address2)  //DEL 2008/04/25 M.Kubota
                 && (kingetCustDmdPrc1.Address3 == kingetCustDmdPrc2.Address3)
                 && (kingetCustDmdPrc1.Address4 == kingetCustDmdPrc2.Address4)
                 && (kingetCustDmdPrc1.HomeTelNo == kingetCustDmdPrc2.HomeTelNo)
                 && (kingetCustDmdPrc1.OfficeTelNo == kingetCustDmdPrc2.OfficeTelNo)
                 && (kingetCustDmdPrc1.PortableTelNo == kingetCustDmdPrc2.PortableTelNo)
                 && (kingetCustDmdPrc1.HomeFaxNo == kingetCustDmdPrc2.HomeFaxNo)
                 && (kingetCustDmdPrc1.OfficeFaxNo == kingetCustDmdPrc2.OfficeFaxNo)
                 && (kingetCustDmdPrc1.OthersTelNo == kingetCustDmdPrc2.OthersTelNo)
                 && (kingetCustDmdPrc1.MainContactCode == kingetCustDmdPrc2.MainContactCode)
                 && (kingetCustDmdPrc1.CustAnalysCode1 == kingetCustDmdPrc2.CustAnalysCode1)
                 && (kingetCustDmdPrc1.CustAnalysCode2 == kingetCustDmdPrc2.CustAnalysCode2)
                 && (kingetCustDmdPrc1.CustAnalysCode3 == kingetCustDmdPrc2.CustAnalysCode3)
                 && (kingetCustDmdPrc1.CustAnalysCode4 == kingetCustDmdPrc2.CustAnalysCode4)
                 && (kingetCustDmdPrc1.CustAnalysCode5 == kingetCustDmdPrc2.CustAnalysCode5)
                 && (kingetCustDmdPrc1.CustAnalysCode6 == kingetCustDmdPrc2.CustAnalysCode6)
                 && (kingetCustDmdPrc1.TotalDay == kingetCustDmdPrc2.TotalDay)
                 && (kingetCustDmdPrc1.CollectMoneyCode == kingetCustDmdPrc2.CollectMoneyCode)
                 && (kingetCustDmdPrc1.CollectMoneyName == kingetCustDmdPrc2.CollectMoneyName)
                 && (kingetCustDmdPrc1.CollectMoneyDay == kingetCustDmdPrc2.CollectMoneyDay)
                 && (kingetCustDmdPrc1.CustomerAgentCd == kingetCustDmdPrc2.CustomerAgentCd)
                 && (kingetCustDmdPrc1.CustomerAgentNm == kingetCustDmdPrc2.CustomerAgentNm)
                 && (kingetCustDmdPrc1.BillCollecterCd == kingetCustDmdPrc2.BillCollecterCd)
                 && (kingetCustDmdPrc1.BillCollecterNm == kingetCustDmdPrc2.BillCollecterNm)
                 && (kingetCustDmdPrc1.OldCustomerAgentCd == kingetCustDmdPrc2.OldCustomerAgentCd)
                 && (kingetCustDmdPrc1.OldCustomerAgentNm == kingetCustDmdPrc2.OldCustomerAgentNm)
                 && (kingetCustDmdPrc1.CustAgentChgDate == kingetCustDmdPrc2.CustAgentChgDate)
                 && (kingetCustDmdPrc1.StartDateSpan == kingetCustDmdPrc2.StartDateSpan)
                 && (kingetCustDmdPrc1.EndDateSpan == kingetCustDmdPrc2.EndDateSpan));
        }
        /// <summary>
        /// KINGET用得意先請求金額クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のKingetCustDmdPrcWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(KingetCustDmdPrcWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimeDemand != target.LastTimeDemand) resList.Add("LastTimeDemand");
            if (this.ThisTimeFeeDmdNrml != target.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (this.ThisTimeDisDmdNrml != target.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (this.ThisTimeDmdNrml != target.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (this.ThisTimeTtlBlcDmd != target.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (this.OfsThisTimeSales != target.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (this.OfsThisSalesTax != target.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (this.ItdedOffsetOutTax != target.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (this.ItdedOffsetInTax != target.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (this.OffsetOutTax != target.OffsetOutTax) resList.Add("OffsetOutTax");
            if (this.OffsetInTax != target.OffsetInTax) resList.Add("OffsetInTax");
            if (this.ThisTimeSales != target.ThisTimeSales) resList.Add("ThisTimeSales");
            if (this.ThisSalesTax != target.ThisSalesTax) resList.Add("ThisSalesTax");
            if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (this.ItdedSalesTaxFree != target.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
            if (this.SalesInTax != target.SalesInTax) resList.Add("SalesInTax");
            if (this.ThisSalesPricRgds != target.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (this.ThisSalesPrcTaxRgds != target.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (this.TtlItdedRetOutTax != target.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (this.TtlItdedRetInTax != target.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (this.TtlRetOuterTax != target.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (this.TtlRetInnerTax != target.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (this.ThisSalesPricDis != target.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (this.ThisSalesPrcTaxDis != target.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (this.TtlItdedDisOutTax != target.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (this.TtlItdedDisInTax != target.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (this.TtlDisOuterTax != target.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (this.TtlDisInnerTax != target.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            //--- DEL 2008/04/25 M.Kubota --->>>
            //if (this.ThisPayOffset != target.ThisPayOffset) resList.Add("ThisPayOffset");
            //if (this.ThisPayOffsetTax != target.ThisPayOffsetTax) resList.Add("ThisPayOffsetTax");
            //if (this.ItdedPaymOutTax != target.ItdedPaymOutTax) resList.Add("ItdedPaymOutTax");
            //if (this.ItdedPaymInTax != target.ItdedPaymInTax) resList.Add("ItdedPaymInTax");
            //if (this.ItdedPaymTaxFree != target.ItdedPaymTaxFree) resList.Add("ItdedPaymTaxFree");
            //if (this.PaymentOutTax != target.PaymentOutTax) resList.Add("PaymentOutTax");
            //if (this.PaymentInTax != target.PaymentInTax) resList.Add("PaymentInTax");
            //--- DEL 2008/04/25 M.Kubota ---<<<
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.AfCalDemandPrice != target.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (this.AcpOdrTtl2TmBfBlDmd != target.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (this.AcpOdrTtl3TmBfBlDmd != target.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.SalesSlipCount != target.SalesSlipCount) resList.Add("SalesSlipCount");
            if (this.BillPrintDate != target.BillPrintDate) resList.Add("BillPrintDate");
            if (this.ExpectedDepositDate != target.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (this.CollectCond != target.CollectCond) resList.Add("CollectCond");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.Kana != target.Kana) resList.Add("Kana");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
            if (this.CorporateDivCode != target.CorporateDivCode) resList.Add("CorporateDivCode");
            if (this.PostNo != target.PostNo) resList.Add("PostNo");
            if (this.Address1 != target.Address1) resList.Add("Address1");
            //if (this.Address2 != target.Address2) resList.Add("Address2");  //DEL 2008/04/25 M.Kubota
            if (this.Address3 != target.Address3) resList.Add("Address3");
            if (this.Address4 != target.Address4) resList.Add("Address4");
            if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
            if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
            if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (this.OthersTelNo != target.OthersTelNo) resList.Add("OthersTelNo");
            if (this.MainContactCode != target.MainContactCode) resList.Add("MainContactCode");
            if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.CollectMoneyCode != target.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (this.CollectMoneyName != target.CollectMoneyName) resList.Add("CollectMoneyName");
            if (this.CollectMoneyDay != target.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (this.BillCollecterCd != target.BillCollecterCd) resList.Add("BillCollecterCd");
            if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
            if (this.OldCustomerAgentCd != target.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (this.OldCustomerAgentNm != target.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (this.CustAgentChgDate != target.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (this.StartDateSpan != target.StartDateSpan) resList.Add("StartDateSpan");
            if (this.EndDateSpan != target.EndDateSpan) resList.Add("EndDateSpan");

            return resList;
        }

        /// <summary>
        /// KINGET用得意先請求金額クラス比較処理
        /// </summary>
        /// <param name="kingetCustDmdPrc1">比較するKingetCustDmdPrcWorkクラスのインスタンス</param>
        /// <param name="kingetCustDmdPrc2">比較するKingetCustDmdPrcWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(KingetCustDmdPrcWork kingetCustDmdPrc1, KingetCustDmdPrcWork kingetCustDmdPrc2)
        {
            ArrayList resList = new ArrayList();
            if (kingetCustDmdPrc1.CreateDateTime != kingetCustDmdPrc2.CreateDateTime) resList.Add("CreateDateTime");
            if (kingetCustDmdPrc1.UpdateDateTime != kingetCustDmdPrc2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (kingetCustDmdPrc1.EnterpriseCode != kingetCustDmdPrc2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (kingetCustDmdPrc1.FileHeaderGuid != kingetCustDmdPrc2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (kingetCustDmdPrc1.UpdEmployeeCode != kingetCustDmdPrc2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (kingetCustDmdPrc1.UpdAssemblyId1 != kingetCustDmdPrc2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (kingetCustDmdPrc1.UpdAssemblyId2 != kingetCustDmdPrc2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (kingetCustDmdPrc1.LogicalDeleteCode != kingetCustDmdPrc2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (kingetCustDmdPrc1.AddUpSecCode != kingetCustDmdPrc2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (kingetCustDmdPrc1.ClaimCode != kingetCustDmdPrc2.ClaimCode) resList.Add("ClaimCode");
            if (kingetCustDmdPrc1.ClaimName != kingetCustDmdPrc2.ClaimName) resList.Add("ClaimName");
            if (kingetCustDmdPrc1.ClaimName2 != kingetCustDmdPrc2.ClaimName2) resList.Add("ClaimName2");
            if (kingetCustDmdPrc1.ClaimSnm != kingetCustDmdPrc2.ClaimSnm) resList.Add("ClaimSnm");
            if (kingetCustDmdPrc1.CustomerCode != kingetCustDmdPrc2.CustomerCode) resList.Add("CustomerCode");
            if (kingetCustDmdPrc1.CustomerName != kingetCustDmdPrc2.CustomerName) resList.Add("CustomerName");
            if (kingetCustDmdPrc1.CustomerName2 != kingetCustDmdPrc2.CustomerName2) resList.Add("CustomerName2");
            if (kingetCustDmdPrc1.CustomerSnm != kingetCustDmdPrc2.CustomerSnm) resList.Add("CustomerSnm");
            if (kingetCustDmdPrc1.AddUpDate != kingetCustDmdPrc2.AddUpDate) resList.Add("AddUpDate");
            if (kingetCustDmdPrc1.AddUpYearMonth != kingetCustDmdPrc2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (kingetCustDmdPrc1.LastTimeDemand != kingetCustDmdPrc2.LastTimeDemand) resList.Add("LastTimeDemand");
            if (kingetCustDmdPrc1.ThisTimeFeeDmdNrml != kingetCustDmdPrc2.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (kingetCustDmdPrc1.ThisTimeDisDmdNrml != kingetCustDmdPrc2.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (kingetCustDmdPrc1.ThisTimeDmdNrml != kingetCustDmdPrc2.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (kingetCustDmdPrc1.ThisTimeTtlBlcDmd != kingetCustDmdPrc2.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (kingetCustDmdPrc1.OfsThisTimeSales != kingetCustDmdPrc2.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (kingetCustDmdPrc1.OfsThisSalesTax != kingetCustDmdPrc2.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (kingetCustDmdPrc1.ItdedOffsetOutTax != kingetCustDmdPrc2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (kingetCustDmdPrc1.ItdedOffsetInTax != kingetCustDmdPrc2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (kingetCustDmdPrc1.ItdedOffsetTaxFree != kingetCustDmdPrc2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (kingetCustDmdPrc1.OffsetOutTax != kingetCustDmdPrc2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (kingetCustDmdPrc1.OffsetInTax != kingetCustDmdPrc2.OffsetInTax) resList.Add("OffsetInTax");
            if (kingetCustDmdPrc1.ThisTimeSales != kingetCustDmdPrc2.ThisTimeSales) resList.Add("ThisTimeSales");
            if (kingetCustDmdPrc1.ThisSalesTax != kingetCustDmdPrc2.ThisSalesTax) resList.Add("ThisSalesTax");
            if (kingetCustDmdPrc1.ItdedSalesOutTax != kingetCustDmdPrc2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (kingetCustDmdPrc1.ItdedSalesInTax != kingetCustDmdPrc2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (kingetCustDmdPrc1.ItdedSalesTaxFree != kingetCustDmdPrc2.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (kingetCustDmdPrc1.SalesOutTax != kingetCustDmdPrc2.SalesOutTax) resList.Add("SalesOutTax");
            if (kingetCustDmdPrc1.SalesInTax != kingetCustDmdPrc2.SalesInTax) resList.Add("SalesInTax");
            if (kingetCustDmdPrc1.ThisSalesPricRgds != kingetCustDmdPrc2.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (kingetCustDmdPrc1.ThisSalesPrcTaxRgds != kingetCustDmdPrc2.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (kingetCustDmdPrc1.TtlItdedRetOutTax != kingetCustDmdPrc2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (kingetCustDmdPrc1.TtlItdedRetInTax != kingetCustDmdPrc2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (kingetCustDmdPrc1.TtlItdedRetTaxFree != kingetCustDmdPrc2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (kingetCustDmdPrc1.TtlRetOuterTax != kingetCustDmdPrc2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (kingetCustDmdPrc1.TtlRetInnerTax != kingetCustDmdPrc2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (kingetCustDmdPrc1.ThisSalesPricDis != kingetCustDmdPrc2.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (kingetCustDmdPrc1.ThisSalesPrcTaxDis != kingetCustDmdPrc2.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (kingetCustDmdPrc1.TtlItdedDisOutTax != kingetCustDmdPrc2.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (kingetCustDmdPrc1.TtlItdedDisInTax != kingetCustDmdPrc2.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (kingetCustDmdPrc1.TtlItdedDisTaxFree != kingetCustDmdPrc2.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (kingetCustDmdPrc1.TtlDisOuterTax != kingetCustDmdPrc2.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (kingetCustDmdPrc1.TtlDisInnerTax != kingetCustDmdPrc2.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            //--- DEL 2008/04/25 M.Kubota --->>>
            //if (kingetCustDmdPrc1.ThisPayOffset != kingetCustDmdPrc2.ThisPayOffset) resList.Add("ThisPayOffset");
            //if (kingetCustDmdPrc1.ThisPayOffsetTax != kingetCustDmdPrc2.ThisPayOffsetTax) resList.Add("ThisPayOffsetTax");
            //if (kingetCustDmdPrc1.ItdedPaymOutTax != kingetCustDmdPrc2.ItdedPaymOutTax) resList.Add("ItdedPaymOutTax");
            //if (kingetCustDmdPrc1.ItdedPaymInTax != kingetCustDmdPrc2.ItdedPaymInTax) resList.Add("ItdedPaymInTax");
            //if (kingetCustDmdPrc1.ItdedPaymTaxFree != kingetCustDmdPrc2.ItdedPaymTaxFree) resList.Add("ItdedPaymTaxFree");
            //if (kingetCustDmdPrc1.PaymentOutTax != kingetCustDmdPrc2.PaymentOutTax) resList.Add("PaymentOutTax");
            //if (kingetCustDmdPrc1.PaymentInTax != kingetCustDmdPrc2.PaymentInTax) resList.Add("PaymentInTax");
            //--- DEL 2008/04/25 M.Kubota ---<<<
            if (kingetCustDmdPrc1.TaxAdjust != kingetCustDmdPrc2.TaxAdjust) resList.Add("TaxAdjust");
            if (kingetCustDmdPrc1.BalanceAdjust != kingetCustDmdPrc2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (kingetCustDmdPrc1.AfCalDemandPrice != kingetCustDmdPrc2.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (kingetCustDmdPrc1.AcpOdrTtl2TmBfBlDmd != kingetCustDmdPrc2.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (kingetCustDmdPrc1.AcpOdrTtl3TmBfBlDmd != kingetCustDmdPrc2.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (kingetCustDmdPrc1.CAddUpUpdExecDate != kingetCustDmdPrc2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (kingetCustDmdPrc1.StartCAddUpUpdDate != kingetCustDmdPrc2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (kingetCustDmdPrc1.LastCAddUpUpdDate != kingetCustDmdPrc2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (kingetCustDmdPrc1.SalesSlipCount != kingetCustDmdPrc2.SalesSlipCount) resList.Add("SalesSlipCount");
            if (kingetCustDmdPrc1.BillPrintDate != kingetCustDmdPrc2.BillPrintDate) resList.Add("BillPrintDate");
            if (kingetCustDmdPrc1.ExpectedDepositDate != kingetCustDmdPrc2.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (kingetCustDmdPrc1.CollectCond != kingetCustDmdPrc2.CollectCond) resList.Add("CollectCond");
            if (kingetCustDmdPrc1.ConsTaxLayMethod != kingetCustDmdPrc2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (kingetCustDmdPrc1.ConsTaxRate != kingetCustDmdPrc2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (kingetCustDmdPrc1.FractionProcCd != kingetCustDmdPrc2.FractionProcCd) resList.Add("FractionProcCd");
            if (kingetCustDmdPrc1.HonorificTitle != kingetCustDmdPrc2.HonorificTitle) resList.Add("HonorificTitle");
            if (kingetCustDmdPrc1.Kana != kingetCustDmdPrc2.Kana) resList.Add("Kana");
            if (kingetCustDmdPrc1.OutputNameCode != kingetCustDmdPrc2.OutputNameCode) resList.Add("OutputNameCode");
            if (kingetCustDmdPrc1.OutputName != kingetCustDmdPrc2.OutputName) resList.Add("OutputName");
            if (kingetCustDmdPrc1.CorporateDivCode != kingetCustDmdPrc2.CorporateDivCode) resList.Add("CorporateDivCode");
            if (kingetCustDmdPrc1.PostNo != kingetCustDmdPrc2.PostNo) resList.Add("PostNo");
            if (kingetCustDmdPrc1.Address1 != kingetCustDmdPrc2.Address1) resList.Add("Address1");
            //if (kingetCustDmdPrc1.Address2 != kingetCustDmdPrc2.Address2) resList.Add("Address2");  //DEL 2008/04/25 M.Kubota
            if (kingetCustDmdPrc1.Address3 != kingetCustDmdPrc2.Address3) resList.Add("Address3");
            if (kingetCustDmdPrc1.Address4 != kingetCustDmdPrc2.Address4) resList.Add("Address4");
            if (kingetCustDmdPrc1.HomeTelNo != kingetCustDmdPrc2.HomeTelNo) resList.Add("HomeTelNo");
            if (kingetCustDmdPrc1.OfficeTelNo != kingetCustDmdPrc2.OfficeTelNo) resList.Add("OfficeTelNo");
            if (kingetCustDmdPrc1.PortableTelNo != kingetCustDmdPrc2.PortableTelNo) resList.Add("PortableTelNo");
            if (kingetCustDmdPrc1.HomeFaxNo != kingetCustDmdPrc2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (kingetCustDmdPrc1.OfficeFaxNo != kingetCustDmdPrc2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (kingetCustDmdPrc1.OthersTelNo != kingetCustDmdPrc2.OthersTelNo) resList.Add("OthersTelNo");
            if (kingetCustDmdPrc1.MainContactCode != kingetCustDmdPrc2.MainContactCode) resList.Add("MainContactCode");
            if (kingetCustDmdPrc1.CustAnalysCode1 != kingetCustDmdPrc2.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (kingetCustDmdPrc1.CustAnalysCode2 != kingetCustDmdPrc2.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (kingetCustDmdPrc1.CustAnalysCode3 != kingetCustDmdPrc2.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (kingetCustDmdPrc1.CustAnalysCode4 != kingetCustDmdPrc2.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (kingetCustDmdPrc1.CustAnalysCode5 != kingetCustDmdPrc2.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (kingetCustDmdPrc1.CustAnalysCode6 != kingetCustDmdPrc2.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (kingetCustDmdPrc1.TotalDay != kingetCustDmdPrc2.TotalDay) resList.Add("TotalDay");
            if (kingetCustDmdPrc1.CollectMoneyCode != kingetCustDmdPrc2.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (kingetCustDmdPrc1.CollectMoneyName != kingetCustDmdPrc2.CollectMoneyName) resList.Add("CollectMoneyName");
            if (kingetCustDmdPrc1.CollectMoneyDay != kingetCustDmdPrc2.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (kingetCustDmdPrc1.CustomerAgentCd != kingetCustDmdPrc2.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (kingetCustDmdPrc1.CustomerAgentNm != kingetCustDmdPrc2.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (kingetCustDmdPrc1.BillCollecterCd != kingetCustDmdPrc2.BillCollecterCd) resList.Add("BillCollecterCd");
            if (kingetCustDmdPrc1.BillCollecterNm != kingetCustDmdPrc2.BillCollecterNm) resList.Add("BillCollecterNm");
            if (kingetCustDmdPrc1.OldCustomerAgentCd != kingetCustDmdPrc2.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (kingetCustDmdPrc1.OldCustomerAgentNm != kingetCustDmdPrc2.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (kingetCustDmdPrc1.CustAgentChgDate != kingetCustDmdPrc2.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (kingetCustDmdPrc1.StartDateSpan != kingetCustDmdPrc2.StartDateSpan) resList.Add("StartDateSpan");
            if (kingetCustDmdPrc1.EndDateSpan != kingetCustDmdPrc2.EndDateSpan) resList.Add("EndDateSpan");

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>KingetCustDmdPrcWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class KingetCustDmdPrcWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  KingetCustDmdPrcWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is KingetCustDmdPrcWork || graph is ArrayList || graph is KingetCustDmdPrcWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(KingetCustDmdPrcWork).FullName));

            if (graph != null && graph is KingetCustDmdPrcWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is KingetCustDmdPrcWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((KingetCustDmdPrcWork[])graph).Length;
            }
            else if (graph is KingetCustDmdPrcWork)
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
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先名称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //請求先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //前回請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //今回手数料額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //今回値引額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //今回繰越残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcDmd
            //相殺後今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //相殺後外税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetOutTax
            //相殺後内税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetInTax
            //相殺後非課税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetTaxFree
            //相殺後外税消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetOutTax
            //相殺後内税消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetInTax
            //今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //売上外税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesOutTax
            //売上内税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesInTax
            //売上非課税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesTaxFree
            //売上外税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesOutTax
            //売上内税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesInTax
            //今回売上返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //今回売上返品消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxRgds
            //返品外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetOutTax
            //返品内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetInTax
            //返品非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetTaxFree
            //返品外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetOuterTax
            //返品内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetInnerTax
            //今回売上値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //今回売上値引消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxDis
            //値引外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisOutTax
            //値引内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisInTax
            //値引非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisTaxFree
            //値引外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisOuterTax
            //値引内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisInnerTax
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            //今回支払相殺金額
            //serInfo.MemberInfo.Add(typeof(Int64)); //ThisPayOffset
            //今回支払相殺消費税
            //serInfo.MemberInfo.Add(typeof(Int64)); //ThisPayOffsetTax
            //支払外税対象額
            //serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPaymOutTax
            //支払内税対象額
            //serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPaymInTax
            //支払非課税対象額
            //serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPaymTaxFree
            //支払外税消費税
            //serInfo.MemberInfo.Add(typeof(Int64)); //PaymentOutTax
            //支払内税消費税
            //serInfo.MemberInfo.Add(typeof(Int64)); //PaymentInTax
            //--- DEL 2008/04/25 M.Kubota ---<<<

            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //計算後請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //締次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //締次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //前回締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //売上伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //請求書発行日
            serInfo.MemberInfo.Add(typeof(Int32)); //BillPrintDate
            //入金予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectedDepositDate
            //回収条件
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //消費税率
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            //敬称
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //カナ
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //諸口コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputNameCode
            //諸口名称
            serInfo.MemberInfo.Add(typeof(string)); //OutputName
            //個人・法人区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CorporateDivCode
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //住所2（丁目）
            //serInfo.MemberInfo.Add(typeof(Int32)); //Address2  //DEL 2008/04/25 M.Kubota
            //住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //電話番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //電話番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //電話番号（携帯）
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //FAX番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNo
            //FAX番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            //電話番号（その他）
            serInfo.MemberInfo.Add(typeof(string)); //OthersTelNo
            //主連絡先区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MainContactCode
            //得意先分析コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode1
            //得意先分析コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode2
            //得意先分析コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode3
            //得意先分析コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode4
            //得意先分析コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode5
            //得意先分析コード6
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode6
            //締日
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //集金月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyCode
            //集金月区分名称
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //集金日
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //顧客担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
            //集金担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //集金担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm
            //旧顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //OldCustomerAgentCd
            //旧顧客担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //OldCustomerAgentNm
            //顧客担当変更日
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAgentChgDate
            //計上年月日範囲（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //StartDateSpan
            //計上年月日範囲（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //EndDateSpan


            serInfo.Serialize(writer, serInfo);
            if (graph is KingetCustDmdPrcWork)
            {
                KingetCustDmdPrcWork temp = (KingetCustDmdPrcWork)graph;

                SetKingetCustDmdPrcWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is KingetCustDmdPrcWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((KingetCustDmdPrcWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (KingetCustDmdPrcWork temp in lst)
                {
                    SetKingetCustDmdPrcWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// KingetCustDmdPrcWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 110;  //DEL 2008/04/25 M.Kubota
        private const int currentMemberCount = 102;    //ADD 2008/04/25 M.Kubota

        /// <summary>
        ///  KingetCustDmdPrcWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetKingetCustDmdPrcWork(System.IO.BinaryWriter writer, KingetCustDmdPrcWork temp)
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
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先名称
            writer.Write(temp.ClaimName);
            //請求先名称2
            writer.Write(temp.ClaimName2);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //前回請求金額
            writer.Write(temp.LastTimeDemand);
            //今回手数料額（通常入金）
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //今回値引額（通常入金）
            writer.Write(temp.ThisTimeDisDmdNrml);
            //今回入金金額（通常入金）
            writer.Write(temp.ThisTimeDmdNrml);
            //今回繰越残高（請求計）
            writer.Write(temp.ThisTimeTtlBlcDmd);
            //相殺後今回売上金額
            writer.Write(temp.OfsThisTimeSales);
            //相殺後今回売上消費税
            writer.Write(temp.OfsThisSalesTax);
            //相殺後外税対象額
            writer.Write(temp.ItdedOffsetOutTax);
            //相殺後内税対象額
            writer.Write(temp.ItdedOffsetInTax);
            //相殺後非課税対象額
            writer.Write(temp.ItdedOffsetTaxFree);
            //相殺後外税消費税
            writer.Write(temp.OffsetOutTax);
            //相殺後内税消費税
            writer.Write(temp.OffsetInTax);
            //今回売上金額
            writer.Write(temp.ThisTimeSales);
            //今回売上消費税
            writer.Write(temp.ThisSalesTax);
            //売上外税対象額
            writer.Write(temp.ItdedSalesOutTax);
            //売上内税対象額
            writer.Write(temp.ItdedSalesInTax);
            //売上非課税対象額
            writer.Write(temp.ItdedSalesTaxFree);
            //売上外税額
            writer.Write(temp.SalesOutTax);
            //売上内税額
            writer.Write(temp.SalesInTax);
            //今回売上返品金額
            writer.Write(temp.ThisSalesPricRgds);
            //今回売上返品消費税
            writer.Write(temp.ThisSalesPrcTaxRgds);
            //返品外税対象額合計
            writer.Write(temp.TtlItdedRetOutTax);
            //返品内税対象額合計
            writer.Write(temp.TtlItdedRetInTax);
            //返品非課税対象額合計
            writer.Write(temp.TtlItdedRetTaxFree);
            //返品外税額合計
            writer.Write(temp.TtlRetOuterTax);
            //返品内税額合計
            writer.Write(temp.TtlRetInnerTax);
            //今回売上値引金額
            writer.Write(temp.ThisSalesPricDis);
            //今回売上値引消費税
            writer.Write(temp.ThisSalesPrcTaxDis);
            //値引外税対象額合計
            writer.Write(temp.TtlItdedDisOutTax);
            //値引内税対象額合計
            writer.Write(temp.TtlItdedDisInTax);
            //値引非課税対象額合計
            writer.Write(temp.TtlItdedDisTaxFree);
            //値引外税額合計
            writer.Write(temp.TtlDisOuterTax);
            //値引内税額合計
            writer.Write(temp.TtlDisInnerTax);
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            //今回支払相殺金額
            //writer.Write(temp.ThisPayOffset);
            //今回支払相殺消費税
            //writer.Write(temp.ThisPayOffsetTax);
            //支払外税対象額
            //writer.Write(temp.ItdedPaymOutTax);
            //支払内税対象額
            //writer.Write(temp.ItdedPaymInTax);
            //支払非課税対象額
            //writer.Write(temp.ItdedPaymTaxFree);
            //支払外税消費税
            //writer.Write(temp.PaymentOutTax);
            //支払内税消費税
            //writer.Write(temp.PaymentInTax);
            //--- DEL 2008/04/25 M.Kubota ---<<<

            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //計算後請求金額
            writer.Write(temp.AfCalDemandPrice);
            //受注2回前残高（請求計）
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //受注3回前残高（請求計）
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //締次更新実行年月日
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //締次更新開始年月日
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //前回締次更新年月日
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //売上伝票枚数
            writer.Write(temp.SalesSlipCount);
            //請求書発行日
            writer.Write((Int64)temp.BillPrintDate.Ticks);
            //入金予定日
            writer.Write((Int64)temp.ExpectedDepositDate.Ticks);
            //回収条件
            writer.Write(temp.CollectCond);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //消費税率
            writer.Write(temp.ConsTaxRate);
            //端数処理区分
            writer.Write(temp.FractionProcCd);
            //敬称
            writer.Write(temp.HonorificTitle);
            //カナ
            writer.Write(temp.Kana);
            //諸口コード
            writer.Write(temp.OutputNameCode);
            //諸口名称
            writer.Write(temp.OutputName);
            //個人・法人区分
            writer.Write(temp.CorporateDivCode);
            //郵便番号
            writer.Write(temp.PostNo);
            //住所1（都道府県市区郡・町村・字）
            writer.Write(temp.Address1);
            //住所2（丁目）
            //writer.Write(temp.Address2);  //DEL 2008/04/25 M.Kubota
            //住所3（番地）
            writer.Write(temp.Address3);
            //住所4（アパート名称）
            writer.Write(temp.Address4);
            //電話番号（自宅）
            writer.Write(temp.HomeTelNo);
            //電話番号（勤務先）
            writer.Write(temp.OfficeTelNo);
            //電話番号（携帯）
            writer.Write(temp.PortableTelNo);
            //FAX番号（自宅）
            writer.Write(temp.HomeFaxNo);
            //FAX番号（勤務先）
            writer.Write(temp.OfficeFaxNo);
            //電話番号（その他）
            writer.Write(temp.OthersTelNo);
            //主連絡先区分
            writer.Write(temp.MainContactCode);
            //得意先分析コード1
            writer.Write(temp.CustAnalysCode1);
            //得意先分析コード2
            writer.Write(temp.CustAnalysCode2);
            //得意先分析コード3
            writer.Write(temp.CustAnalysCode3);
            //得意先分析コード4
            writer.Write(temp.CustAnalysCode4);
            //得意先分析コード5
            writer.Write(temp.CustAnalysCode5);
            //得意先分析コード6
            writer.Write(temp.CustAnalysCode6);
            //締日
            writer.Write(temp.TotalDay);
            //集金月区分コード
            writer.Write(temp.CollectMoneyCode);
            //集金月区分名称
            writer.Write(temp.CollectMoneyName);
            //集金日
            writer.Write(temp.CollectMoneyDay);
            //顧客担当従業員コード
            writer.Write(temp.CustomerAgentCd);
            //顧客担当従業員名称
            writer.Write(temp.CustomerAgentNm);
            //集金担当従業員コード
            writer.Write(temp.BillCollecterCd);
            //集金担当従業員名称
            writer.Write(temp.BillCollecterNm);
            //旧顧客担当従業員コード
            writer.Write(temp.OldCustomerAgentCd);
            //旧顧客担当従業員名称
            writer.Write(temp.OldCustomerAgentNm);
            //顧客担当変更日
            writer.Write((Int64)temp.CustAgentChgDate.Ticks);
            //計上年月日範囲（開始）
            writer.Write(temp.StartDateSpan);
            //計上年月日範囲（終了）
            writer.Write(temp.EndDateSpan);

        }

        /// <summary>
        ///  KingetCustDmdPrcWorkインスタンス取得
        /// </summary>
        /// <returns>KingetCustDmdPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private KingetCustDmdPrcWork GetKingetCustDmdPrcWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            KingetCustDmdPrcWork temp = new KingetCustDmdPrcWork();

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
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先名称
            temp.ClaimName = reader.ReadString();
            //請求先名称2
            temp.ClaimName2 = reader.ReadString();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
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
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            //今回支払相殺金額
            //temp.ThisPayOffset = reader.ReadInt64();
            //今回支払相殺消費税
            //temp.ThisPayOffsetTax = reader.ReadInt64();
            //支払外税対象額
            //temp.ItdedPaymOutTax = reader.ReadInt64();
            //支払内税対象額
            //temp.ItdedPaymInTax = reader.ReadInt64();
            //支払非課税対象額
            //temp.ItdedPaymTaxFree = reader.ReadInt64();
            //支払外税消費税
            //temp.PaymentOutTax = reader.ReadInt64();
            //支払内税消費税
            //temp.PaymentInTax = reader.ReadInt64();
            //--- DEL 2008/04/25 M.Kubota ---<<<

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
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //消費税率
            temp.ConsTaxRate = reader.ReadDouble();
            //端数処理区分
            temp.FractionProcCd = reader.ReadInt32();
            //敬称
            temp.HonorificTitle = reader.ReadString();
            //カナ
            temp.Kana = reader.ReadString();
            //諸口コード
            temp.OutputNameCode = reader.ReadInt32();
            //諸口名称
            temp.OutputName = reader.ReadString();
            //個人・法人区分
            temp.CorporateDivCode = reader.ReadInt32();
            //郵便番号
            temp.PostNo = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.Address1 = reader.ReadString();
            //住所2（丁目）
            //temp.Address2 = reader.ReadInt32();  //DEL 2008/04/25 M.Kubota
            //住所3（番地）
            temp.Address3 = reader.ReadString();
            //住所4（アパート名称）
            temp.Address4 = reader.ReadString();
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
            //得意先分析コード1
            temp.CustAnalysCode1 = reader.ReadInt32();
            //得意先分析コード2
            temp.CustAnalysCode2 = reader.ReadInt32();
            //得意先分析コード3
            temp.CustAnalysCode3 = reader.ReadInt32();
            //得意先分析コード4
            temp.CustAnalysCode4 = reader.ReadInt32();
            //得意先分析コード5
            temp.CustAnalysCode5 = reader.ReadInt32();
            //得意先分析コード6
            temp.CustAnalysCode6 = reader.ReadInt32();
            //締日
            temp.TotalDay = reader.ReadInt32();
            //集金月区分コード
            temp.CollectMoneyCode = reader.ReadInt32();
            //集金月区分名称
            temp.CollectMoneyName = reader.ReadString();
            //集金日
            temp.CollectMoneyDay = reader.ReadInt32();
            //顧客担当従業員コード
            temp.CustomerAgentCd = reader.ReadString();
            //顧客担当従業員名称
            temp.CustomerAgentNm = reader.ReadString();
            //集金担当従業員コード
            temp.BillCollecterCd = reader.ReadString();
            //集金担当従業員名称
            temp.BillCollecterNm = reader.ReadString();
            //旧顧客担当従業員コード
            temp.OldCustomerAgentCd = reader.ReadString();
            //旧顧客担当従業員名称
            temp.OldCustomerAgentNm = reader.ReadString();
            //顧客担当変更日
            temp.CustAgentChgDate = new DateTime(reader.ReadInt64());
            //計上年月日範囲（開始）
            temp.StartDateSpan = reader.ReadInt32();
            //計上年月日範囲（終了）
            temp.EndDateSpan = reader.ReadInt32();


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
        /// <returns>KingetCustDmdPrcWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   KingetCustDmdPrcWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                KingetCustDmdPrcWork temp = GetKingetCustDmdPrcWork(reader, serInfo);
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
                    retValue = (KingetCustDmdPrcWork[])lst.ToArray(typeof(KingetCustDmdPrcWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
