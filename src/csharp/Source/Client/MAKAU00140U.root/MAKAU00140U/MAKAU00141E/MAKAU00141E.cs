using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SuplierPay
    /// <summary>
    ///                      仕入先支払金額マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先支払金額マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SuplierPay
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

        /// <summary>支払先コード</summary>
        /// <remarks>支払先の親コード</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>得意先コード</summary>
        /// <remarks>支払先の子コード（親レコードの場合０セット）</remarks>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 支払締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>前回支払金額</summary>
        private Int64 _lastTimePayment;

        /// <summary>今回手数料額（通常支払）</summary>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>今回値引額（通常支払）</summary>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>今回支払金額（通常支払）</summary>
        /// <remarks>支払額の合計金額</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>今回繰越残高（支払計）</summary>
        /// <remarks>今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）</remarks>
        private Int64 _thisTimeTtlBlcPay;

        /// <summary>相殺後今回仕入金額</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>相殺後今回仕入消費税</summary>
        /// <remarks>相殺結果</remarks>
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

        /// <summary>今回仕入金額</summary>
        /// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入金額</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>今回仕入消費税</summary>
        /// <remarks>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</remarks>
        private Int64 _thisStcPrcTax;

        /// <summary>仕入外税対象額合計</summary>
        private Int64 _ttlItdedStcOutTax;

        /// <summary>仕入内税対象額合計</summary>
        private Int64 _ttlItdedStcInTax;

        /// <summary>仕入非課税対象額合計</summary>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>仕入外税額合計</summary>
        private Int64 _ttlStockOuterTax;

        /// <summary>仕入内税額合計</summary>
        private Int64 _ttlStockInnerTax;

        /// <summary>今回返品金額</summary>
        /// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>今回返品消費税</summary>
        /// <remarks>今回返品消費税＝返品外税額合計＋返品内税額合計</remarks>
        private Int64 _thisStcPrcTaxRgds;

        /// <summary>返品外税対象額合計</summary>
        private Int64 _ttlItdedRetOutTax;

        /// <summary>返品内税対象額合計</summary>
        private Int64 _ttlItdedRetInTax;

        /// <summary>返品非課税対象額合計</summary>
        private Int64 _ttlItdedRetTaxFree;

        /// <summary>返品外税額合計</summary>
        private Int64 _ttlRetOuterTax;

        /// <summary>返品内税額合計</summary>
        /// <remarks>掛仕入：内税商品返品の内税消費税額（値引含まず）</remarks>
        private Int64 _ttlRetInnerTax;

        /// <summary>今回値引金額</summary>
        /// <remarks>掛仕入：税抜きの仕入値引き金額</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>今回値引消費税</summary>
        /// <remarks>今回値引消費税＝値引外税額合計＋値引内税額合計</remarks>
        private Int64 _thisStcPrcTaxDis;

        /// <summary>値引外税対象額合計</summary>
        private Int64 _ttlItdedDisOutTax;

        /// <summary>値引内税対象額合計</summary>
        private Int64 _ttlItdedDisInTax;

        /// <summary>値引非課税対象額合計</summary>
        private Int64 _ttlItdedDisTaxFree;

        /// <summary>値引外税額合計</summary>
        private Int64 _ttlDisOuterTax;

        /// <summary>値引内税額合計</summary>
        /// <remarks>掛仕入：内税商品値引の内税消費税額</remarks>
        private Int64 _ttlDisInnerTax;

        /// <summary>今回受取金額</summary>
        /// <remarks>相殺用仕入合計</remarks>
        private Int64 _thisRecvOffset;

        /// <summary>今回受取相殺消費税</summary>
        /// <remarks>相殺用仕入消費税＝相殺用仕入伝票外税額＋相殺用仕入伝票内税額</remarks>
        private Int64 _thisRecvOffsetTax;

        /// <summary>今回受取外税対象額合計</summary>
        /// <remarks>相殺用仕入伝票の外税対象額</remarks>
        private Int64 _thisRecvOutTax;

        /// <summary>今回受取内税対象額合計</summary>
        /// <remarks>相殺用仕入伝票の内税対象額</remarks>
        private Int64 _thisRecvInTax;

        /// <summary>今回受取非課税対象額合計</summary>
        /// <remarks>相殺用仕入伝票の非課税対象額</remarks>
        private Int64 _thisRecvTaxFree;

        /// <summary>今回受取外税額合計</summary>
        /// <remarks>相殺用仕入伝票外税額</remarks>
        private Int64 _thisRecvOuterTax;

        /// <summary>今回受取内税額合計</summary>
        /// <remarks>相殺用仕入伝票内税額</remarks>
        private Int64 _thisRecvInnerTax;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>仕入合計残高（支払計）</summary>
        /// <remarks>今回分の支払金額今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>仕入2回前残高（支払計）</summary>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>仕入3回前残高（支払計）</summary>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>締次更新実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>前回締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>仕入伝票枚数</summary>
        private Int32 _stockSlipCount;

        /// <summary>支払予定日</summary>
        /// <remarks>今回請求分の支払（入金）予定日</remarks>
        private DateTime _paymentSchedule;

        /// <summary>支払条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _paymentCond;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入先消費税税率</summary>
        /// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
        private Double _supplierConsTaxRate;

        /// <summary>端数処理区分</summary>
        private Int32 _fractionProcCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>支払先の親コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
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
            get { return _payeeName; }
            set { _payeeName = value; }
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
            get { return _payeeName2; }
            set { _payeeName2 = value; }
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
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>支払先の子コード（親レコードの場合０セット）</value>
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
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
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

        /// public propaty name  :  AddUpDateJpFormal
        /// <summary>計上年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateJpInFormal
        /// <summary>計上年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdFormal
        /// <summary>計上年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdInFormal
        /// <summary>計上年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate); }
            set { }
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

        /// public propaty name  :  AddUpYearMonthJpFormal
        /// <summary>計上年月 和暦プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthJpInFormal
        /// <summary>計上年月 和暦(略)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthAdFormal
        /// <summary>計上年月 西暦プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthAdInFormal
        /// <summary>計上年月 西暦(略)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpYearMonthAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  LastTimePayment
        /// <summary>前回支払金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
        }

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>今回手数料額（通常支払）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回手数料額（通常支払）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>今回値引額（通常支払）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引額（通常支払）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>今回支払金額（通常支払）プロパティ</summary>
        /// <value>支払額の合計金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回支払金額（通常支払）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcPay
        /// <summary>今回繰越残高（支払計）プロパティ</summary>
        /// <value>今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcPay
        {
            get { return _thisTimeTtlBlcPay; }
            set { _thisTimeTtlBlcPay = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>相殺後今回仕入金額プロパティ</summary>
        /// <value>相殺結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>相殺後今回仕入消費税プロパティ</summary>
        /// <value>相殺結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回仕入消費税プロパティ</br>
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

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>今回仕入金額プロパティ</summary>
        /// <value>掛仕入：値引、返品を含まない 税抜きの仕入金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
        }

        /// public propaty name  :  ThisStcPrcTax
        /// <summary>今回仕入消費税プロパティ</summary>
        /// <value>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回仕入消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStcPrcTax
        {
            get { return _thisStcPrcTax; }
            set { _thisStcPrcTax = value; }
        }

        /// public propaty name  :  TtlItdedStcOutTax
        /// <summary>仕入外税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTax
        {
            get { return _ttlItdedStcOutTax; }
            set { _ttlItdedStcOutTax = value; }
        }

        /// public propaty name  :  TtlItdedStcInTax
        /// <summary>仕入内税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcInTax
        {
            get { return _ttlItdedStcInTax; }
            set { _ttlItdedStcInTax = value; }
        }

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>仕入非課税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcTaxFree
        {
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
        }

        /// public propaty name  :  TtlStockOuterTax
        /// <summary>仕入外税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlStockOuterTax
        {
            get { return _ttlStockOuterTax; }
            set { _ttlStockOuterTax = value; }
        }

        /// public propaty name  :  TtlStockInnerTax
        /// <summary>仕入内税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlStockInnerTax
        {
            get { return _ttlStockInnerTax; }
            set { _ttlStockInnerTax = value; }
        }

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>今回返品金額プロパティ</summary>
        /// <value>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricRgds
        {
            get { return _thisStckPricRgds; }
            set { _thisStckPricRgds = value; }
        }

        /// public propaty name  :  ThisStcPrcTaxRgds
        /// <summary>今回返品消費税プロパティ</summary>
        /// <value>今回返品消費税＝返品外税額合計＋返品内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回返品消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStcPrcTaxRgds
        {
            get { return _thisStcPrcTaxRgds; }
            set { _thisStcPrcTaxRgds = value; }
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
        /// <value>掛仕入：内税商品返品の内税消費税額（値引含まず）</value>
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

        /// public propaty name  :  ThisStckPricDis
        /// <summary>今回値引金額プロパティ</summary>
        /// <value>掛仕入：税抜きの仕入値引き金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricDis
        {
            get { return _thisStckPricDis; }
            set { _thisStckPricDis = value; }
        }

        /// public propaty name  :  ThisStcPrcTaxDis
        /// <summary>今回値引消費税プロパティ</summary>
        /// <value>今回値引消費税＝値引外税額合計＋値引内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStcPrcTaxDis
        {
            get { return _thisStcPrcTaxDis; }
            set { _thisStcPrcTaxDis = value; }
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
        /// <value>掛仕入：内税商品値引の内税消費税額</value>
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

        /// public propaty name  :  ThisRecvOffset
        /// <summary>今回受取金額プロパティ</summary>
        /// <value>相殺用仕入合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvOffset
        {
            get { return _thisRecvOffset; }
            set { _thisRecvOffset = value; }
        }

        /// public propaty name  :  ThisRecvOffsetTax
        /// <summary>今回受取相殺消費税プロパティ</summary>
        /// <value>相殺用仕入消費税＝相殺用仕入伝票外税額＋相殺用仕入伝票内税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取相殺消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvOffsetTax
        {
            get { return _thisRecvOffsetTax; }
            set { _thisRecvOffsetTax = value; }
        }

        /// public propaty name  :  ThisRecvOutTax
        /// <summary>今回受取外税対象額合計プロパティ</summary>
        /// <value>相殺用仕入伝票の外税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvOutTax
        {
            get { return _thisRecvOutTax; }
            set { _thisRecvOutTax = value; }
        }

        /// public propaty name  :  ThisRecvInTax
        /// <summary>今回受取内税対象額合計プロパティ</summary>
        /// <value>相殺用仕入伝票の内税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvInTax
        {
            get { return _thisRecvInTax; }
            set { _thisRecvInTax = value; }
        }

        /// public propaty name  :  ThisRecvTaxFree
        /// <summary>今回受取非課税対象額合計プロパティ</summary>
        /// <value>相殺用仕入伝票の非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvTaxFree
        {
            get { return _thisRecvTaxFree; }
            set { _thisRecvTaxFree = value; }
        }

        /// public propaty name  :  ThisRecvOuterTax
        /// <summary>今回受取外税額合計プロパティ</summary>
        /// <value>相殺用仕入伝票外税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取外税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvOuterTax
        {
            get { return _thisRecvOuterTax; }
            set { _thisRecvOuterTax = value; }
        }

        /// public propaty name  :  ThisRecvInnerTax
        /// <summary>今回受取内税額合計プロパティ</summary>
        /// <value>相殺用仕入伝票内税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回受取内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisRecvInnerTax
        {
            get { return _thisRecvInnerTax; }
            set { _thisRecvInnerTax = value; }
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

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>仕入合計残高（支払計）プロパティ</summary>
        /// <value>今回分の支払金額今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入合計残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
        }

        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>仕入2回前残高（支払計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入2回前残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  StockTtl3TmBfBlPay
        /// <summary>仕入3回前残高（支払計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入3回前残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl3TmBfBlPay
        {
            get { return _stockTtl3TmBfBlPay; }
            set { _stockTtl3TmBfBlPay = value; }
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

        /// public propaty name  :  CAddUpUpdExecDateJpFormal
        /// <summary>締次更新実行年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateJpInFormal
        /// <summary>締次更新実行年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateAdFormal
        /// <summary>締次更新実行年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateAdInFormal
        /// <summary>締次更新実行年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _cAddUpUpdExecDate); }
            set { }
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

        /// public propaty name  :  StartCAddUpUpdDateJpFormal
        /// <summary>締次更新開始年月日 和暦プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateJpInFormal
        /// <summary>締次更新開始年月日 和暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateAdFormal
        /// <summary>締次更新開始年月日 西暦プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateAdInFormal
        /// <summary>締次更新開始年月日 西暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _startCAddUpUpdDate); }
            set { }
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

        /// public propaty name  :  LastCAddUpUpdDateJpFormal
        /// <summary>前回締次更新年月日 和暦プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateJpInFormal
        /// <summary>前回締次更新年月日 和暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateAdFormal
        /// <summary>前回締次更新年月日 西暦プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateAdInFormal
        /// <summary>前回締次更新年月日 西暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>仕入伝票枚数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  PaymentSchedule
        /// <summary>支払予定日プロパティ</summary>
        /// <value>今回請求分の支払（入金）予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PaymentSchedule
        {
            get { return _paymentSchedule; }
            set { _paymentSchedule = value; }
        }

        /// public propaty name  :  PaymentScheduleJpFormal
        /// <summary>支払予定日 和暦プロパティ</summary>
        /// <value>今回請求分の支払（入金）予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払予定日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentScheduleJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentScheduleJpInFormal
        /// <summary>支払予定日 和暦(略)プロパティ</summary>
        /// <value>今回請求分の支払（入金）予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払予定日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentScheduleJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentScheduleAdFormal
        /// <summary>支払予定日 西暦プロパティ</summary>
        /// <value>今回請求分の支払（入金）予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払予定日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentScheduleAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentScheduleAdInFormal
        /// <summary>支払予定日 西暦(略)プロパティ</summary>
        /// <value>今回請求分の支払（入金）予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払予定日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentScheduleAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>支払条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
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
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>仕入先消費税税率プロパティ</summary>
        /// <value>請求転嫁消費税を算出する場合に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
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

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  AddUpSecName
        /// <summary>計上拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
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
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
        }


        /// <summary>
        /// 仕入先支払金額マスタコンストラクタ
        /// </summary>
        /// <returns>SuplierPayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuplierPay()
        {
        }

        /// <summary>
        /// 仕入先支払金額マスタコンストラクタ
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
        /// <param name="payeeCode">支払先コード(支払先の親コード)</param>
        /// <param name="payeeName">支払先名称</param>
        /// <param name="payeeName2">支払先名称2</param>
        /// <param name="payeeSnm">支払先略称</param>
        /// <param name="customerCode">得意先コード(支払先の子コード（親レコードの場合０セット）)</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="addUpDate">計上年月日(YYYYMMDD 支払締を行なった日（相手先基準）)</param>
        /// <param name="addUpYearMonth">計上年月(YYYYMM)</param>
        /// <param name="lastTimePayment">前回支払金額</param>
        /// <param name="thisTimeFeePayNrml">今回手数料額（通常支払）</param>
        /// <param name="thisTimeDisPayNrml">今回値引額（通常支払）</param>
        /// <param name="thisTimePayNrml">今回支払金額（通常支払）(支払額の合計金額)</param>
        /// <param name="thisTimeTtlBlcPay">今回繰越残高（支払計）(今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）)</param>
        /// <param name="ofsThisTimeSales">相殺後今回仕入金額(相殺結果)</param>
        /// <param name="ofsThisSalesTax">相殺後今回仕入消費税(相殺結果)</param>
        /// <param name="itdedOffsetOutTax">相殺後外税対象額(相殺用：外税額（税抜き）の集計)</param>
        /// <param name="itdedOffsetInTax">相殺後内税対象額(相殺用：内税額（税抜き）の集計)</param>
        /// <param name="itdedOffsetTaxFree">相殺後非課税対象額(相殺用：非課税額の集計)</param>
        /// <param name="offsetOutTax">相殺後外税消費税(相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）)</param>
        /// <param name="offsetInTax">相殺後内税消費税(相殺用：内税消費税の集計)</param>
        /// <param name="thisTimeStockPrice">今回仕入金額(掛仕入：値引、返品を含まない 税抜きの仕入金額)</param>
        /// <param name="thisStcPrcTax">今回仕入消費税(今回仕入消費税＝仕入外税額合計＋仕入内税額合計)</param>
        /// <param name="ttlItdedStcOutTax">仕入外税対象額合計</param>
        /// <param name="ttlItdedStcInTax">仕入内税対象額合計</param>
        /// <param name="ttlItdedStcTaxFree">仕入非課税対象額合計</param>
        /// <param name="ttlStockOuterTax">仕入外税額合計</param>
        /// <param name="ttlStockInnerTax">仕入内税額合計</param>
        /// <param name="thisStckPricRgds">今回返品金額(掛仕入：値引、返品を含まない 税抜きの仕入返品金額)</param>
        /// <param name="thisStcPrcTaxRgds">今回返品消費税(今回返品消費税＝返品外税額合計＋返品内税額合計)</param>
        /// <param name="ttlItdedRetOutTax">返品外税対象額合計</param>
        /// <param name="ttlItdedRetInTax">返品内税対象額合計</param>
        /// <param name="ttlItdedRetTaxFree">返品非課税対象額合計</param>
        /// <param name="ttlRetOuterTax">返品外税額合計</param>
        /// <param name="ttlRetInnerTax">返品内税額合計(掛仕入：内税商品返品の内税消費税額（値引含まず）)</param>
        /// <param name="thisStckPricDis">今回値引金額(掛仕入：税抜きの仕入値引き金額)</param>
        /// <param name="thisStcPrcTaxDis">今回値引消費税(今回値引消費税＝値引外税額合計＋値引内税額合計)</param>
        /// <param name="ttlItdedDisOutTax">値引外税対象額合計</param>
        /// <param name="ttlItdedDisInTax">値引内税対象額合計</param>
        /// <param name="ttlItdedDisTaxFree">値引非課税対象額合計</param>
        /// <param name="ttlDisOuterTax">値引外税額合計</param>
        /// <param name="ttlDisInnerTax">値引内税額合計(掛仕入：内税商品値引の内税消費税額)</param>
        /// <param name="thisRecvOffset">今回受取金額(相殺用仕入合計)</param>
        /// <param name="thisRecvOffsetTax">今回受取相殺消費税(相殺用仕入消費税＝相殺用仕入伝票外税額＋相殺用仕入伝票内税額)</param>
        /// <param name="thisRecvOutTax">今回受取外税対象額合計(相殺用仕入伝票の外税対象額)</param>
        /// <param name="thisRecvInTax">今回受取内税対象額合計(相殺用仕入伝票の内税対象額)</param>
        /// <param name="thisRecvTaxFree">今回受取非課税対象額合計(相殺用仕入伝票の非課税対象額)</param>
        /// <param name="thisRecvOuterTax">今回受取外税額合計(相殺用仕入伝票外税額)</param>
        /// <param name="thisRecvInnerTax">今回受取内税額合計(相殺用仕入伝票内税額)</param>
        /// <param name="taxAdjust">消費税調整額</param>
        /// <param name="balanceAdjust">残高調整額</param>
        /// <param name="stockTotalPayBalance">仕入合計残高（支払計）(今回分の支払金額今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額)</param>
        /// <param name="stockTtl2TmBfBlPay">仕入2回前残高（支払計）</param>
        /// <param name="stockTtl3TmBfBlPay">仕入3回前残高（支払計）</param>
        /// <param name="cAddUpUpdExecDate">締次更新実行年月日(YYYYMMDD)</param>
        /// <param name="startCAddUpUpdDate">締次更新開始年月日("YYYYMMDD"  締次更新対象となる開始年月日)</param>
        /// <param name="lastCAddUpUpdDate">前回締次更新年月日("YYYYMMDD"  前回締次更新対象となった年月日)</param>
        /// <param name="stockSlipCount">仕入伝票枚数</param>
        /// <param name="paymentSchedule">支払予定日(今回請求分の支払（入金）予定日)</param>
        /// <param name="paymentCond">支払条件(10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他)</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード(端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括)</param>
        /// <param name="supplierConsTaxRate">仕入先消費税税率(請求転嫁消費税を算出する場合に使用)</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
        /// <returns>SuplierPayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuplierPay(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimePayment, Int64 thisTimeFeePayNrml, Int64 thisTimeDisPayNrml, Int64 thisTimePayNrml, Int64 thisTimeTtlBlcPay, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeStockPrice, Int64 thisStcPrcTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 ttlStockOuterTax, Int64 ttlStockInnerTax, Int64 thisStckPricRgds, Int64 thisStcPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisStckPricDis, Int64 thisStcPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 thisRecvOffset, Int64 thisRecvOffsetTax, Int64 thisRecvOutTax, Int64 thisRecvInTax, Int64 thisRecvTaxFree, Int64 thisRecvOuterTax, Int64 thisRecvInnerTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 stockTotalPayBalance, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 stockSlipCount, DateTime paymentSchedule, Int32 paymentCond, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int32 fractionProcCd, string enterpriseName, string updEmployeeName, string addUpSecName, string suppCTaxLayMethodNm)
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
            this._payeeCode = payeeCode;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._payeeSnm = payeeSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimePayment = lastTimePayment;
            this._thisTimeFeePayNrml = thisTimeFeePayNrml;
            this._thisTimeDisPayNrml = thisTimeDisPayNrml;
            this._thisTimePayNrml = thisTimePayNrml;
            this._thisTimeTtlBlcPay = thisTimeTtlBlcPay;
            this._ofsThisTimeSales = ofsThisTimeSales;
            this._ofsThisSalesTax = ofsThisSalesTax;
            this._itdedOffsetOutTax = itdedOffsetOutTax;
            this._itdedOffsetInTax = itdedOffsetInTax;
            this._itdedOffsetTaxFree = itdedOffsetTaxFree;
            this._offsetOutTax = offsetOutTax;
            this._offsetInTax = offsetInTax;
            this._thisTimeStockPrice = thisTimeStockPrice;
            this._thisStcPrcTax = thisStcPrcTax;
            this._ttlItdedStcOutTax = ttlItdedStcOutTax;
            this._ttlItdedStcInTax = ttlItdedStcInTax;
            this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
            this._ttlStockOuterTax = ttlStockOuterTax;
            this._ttlStockInnerTax = ttlStockInnerTax;
            this._thisStckPricRgds = thisStckPricRgds;
            this._thisStcPrcTaxRgds = thisStcPrcTaxRgds;
            this._ttlItdedRetOutTax = ttlItdedRetOutTax;
            this._ttlItdedRetInTax = ttlItdedRetInTax;
            this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
            this._ttlRetOuterTax = ttlRetOuterTax;
            this._ttlRetInnerTax = ttlRetInnerTax;
            this._thisStckPricDis = thisStckPricDis;
            this._thisStcPrcTaxDis = thisStcPrcTaxDis;
            this._ttlItdedDisOutTax = ttlItdedDisOutTax;
            this._ttlItdedDisInTax = ttlItdedDisInTax;
            this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
            this._ttlDisOuterTax = ttlDisOuterTax;
            this._ttlDisInnerTax = ttlDisInnerTax;
            this._thisRecvOffset = thisRecvOffset;
            this._thisRecvOffsetTax = thisRecvOffsetTax;
            this._thisRecvOutTax = thisRecvOutTax;
            this._thisRecvInTax = thisRecvInTax;
            this._thisRecvTaxFree = thisRecvTaxFree;
            this._thisRecvOuterTax = thisRecvOuterTax;
            this._thisRecvInnerTax = thisRecvInnerTax;
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
            this._stockTotalPayBalance = stockTotalPayBalance;
            this._stockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
            this._stockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this._stockSlipCount = stockSlipCount;
            this.PaymentSchedule = paymentSchedule;
            this._paymentCond = paymentCond;
            this._suppCTaxLayCd = suppCTaxLayCd;
            this._supplierConsTaxRate = supplierConsTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;

        }

        /// <summary>
        /// 仕入先支払金額マスタ複製処理
        /// </summary>
        /// <returns>SuplierPayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSuplierPayクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuplierPay Clone()
        {
            return new SuplierPay(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimePayment, this._thisTimeFeePayNrml, this._thisTimeDisPayNrml, this._thisTimePayNrml, this._thisTimeTtlBlcPay, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeStockPrice, this._thisStcPrcTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._ttlStockOuterTax, this._ttlStockInnerTax, this._thisStckPricRgds, this._thisStcPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisStckPricDis, this._thisStcPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._thisRecvOffset, this._thisRecvOffsetTax, this._thisRecvOutTax, this._thisRecvInTax, this._thisRecvTaxFree, this._thisRecvOuterTax, this._thisRecvInnerTax, this._taxAdjust, this._balanceAdjust, this._stockTotalPayBalance, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._stockSlipCount, this._paymentSchedule, this._paymentCond, this._suppCTaxLayCd, this._supplierConsTaxRate, this._fractionProcCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._suppCTaxLayMethodNm);
        }

        /// <summary>
        /// 仕入先支払金額マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSuplierPayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SuplierPay target)
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
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.PayeeName == target.PayeeName)
                 && (this.PayeeName2 == target.PayeeName2)
                 && (this.PayeeSnm == target.PayeeSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimePayment == target.LastTimePayment)
                 && (this.ThisTimeFeePayNrml == target.ThisTimeFeePayNrml)
                 && (this.ThisTimeDisPayNrml == target.ThisTimeDisPayNrml)
                 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
                 && (this.ThisTimeTtlBlcPay == target.ThisTimeTtlBlcPay)
                 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
                 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
                 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
                 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
                 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
                 && (this.OffsetOutTax == target.OffsetOutTax)
                 && (this.OffsetInTax == target.OffsetInTax)
                 && (this.ThisTimeStockPrice == target.ThisTimeStockPrice)
                 && (this.ThisStcPrcTax == target.ThisStcPrcTax)
                 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
                 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
                 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
                 && (this.TtlStockOuterTax == target.TtlStockOuterTax)
                 && (this.TtlStockInnerTax == target.TtlStockInnerTax)
                 && (this.ThisStckPricRgds == target.ThisStckPricRgds)
                 && (this.ThisStcPrcTaxRgds == target.ThisStcPrcTaxRgds)
                 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
                 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
                 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
                 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
                 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
                 && (this.ThisStckPricDis == target.ThisStckPricDis)
                 && (this.ThisStcPrcTaxDis == target.ThisStcPrcTaxDis)
                 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
                 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
                 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
                 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
                 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
                 && (this.ThisRecvOffset == target.ThisRecvOffset)
                 && (this.ThisRecvOffsetTax == target.ThisRecvOffsetTax)
                 && (this.ThisRecvOutTax == target.ThisRecvOutTax)
                 && (this.ThisRecvInTax == target.ThisRecvInTax)
                 && (this.ThisRecvTaxFree == target.ThisRecvTaxFree)
                 && (this.ThisRecvOuterTax == target.ThisRecvOuterTax)
                 && (this.ThisRecvInnerTax == target.ThisRecvInnerTax)
                 && (this.TaxAdjust == target.TaxAdjust)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.StockTotalPayBalance == target.StockTotalPayBalance)
                 && (this.StockTtl2TmBfBlPay == target.StockTtl2TmBfBlPay)
                 && (this.StockTtl3TmBfBlPay == target.StockTtl3TmBfBlPay)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.StockSlipCount == target.StockSlipCount)
                 && (this.PaymentSchedule == target.PaymentSchedule)
                 && (this.PaymentCond == target.PaymentCond)
                 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm));
        }

        /// <summary>
        /// 仕入先支払金額マスタ比較処理
        /// </summary>
        /// <param name="suplierPay1">
        ///                    比較するSuplierPayクラスのインスタンス
        /// </param>
        /// <param name="suplierPay2">比較するSuplierPayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SuplierPay suplierPay1, SuplierPay suplierPay2)
        {
            return ((suplierPay1.CreateDateTime == suplierPay2.CreateDateTime)
                 && (suplierPay1.UpdateDateTime == suplierPay2.UpdateDateTime)
                 && (suplierPay1.EnterpriseCode == suplierPay2.EnterpriseCode)
                 && (suplierPay1.FileHeaderGuid == suplierPay2.FileHeaderGuid)
                 && (suplierPay1.UpdEmployeeCode == suplierPay2.UpdEmployeeCode)
                 && (suplierPay1.UpdAssemblyId1 == suplierPay2.UpdAssemblyId1)
                 && (suplierPay1.UpdAssemblyId2 == suplierPay2.UpdAssemblyId2)
                 && (suplierPay1.LogicalDeleteCode == suplierPay2.LogicalDeleteCode)
                 && (suplierPay1.AddUpSecCode == suplierPay2.AddUpSecCode)
                 && (suplierPay1.PayeeCode == suplierPay2.PayeeCode)
                 && (suplierPay1.PayeeName == suplierPay2.PayeeName)
                 && (suplierPay1.PayeeName2 == suplierPay2.PayeeName2)
                 && (suplierPay1.PayeeSnm == suplierPay2.PayeeSnm)
                 && (suplierPay1.CustomerCode == suplierPay2.CustomerCode)
                 && (suplierPay1.CustomerName == suplierPay2.CustomerName)
                 && (suplierPay1.CustomerName2 == suplierPay2.CustomerName2)
                 && (suplierPay1.CustomerSnm == suplierPay2.CustomerSnm)
                 && (suplierPay1.AddUpDate == suplierPay2.AddUpDate)
                 && (suplierPay1.AddUpYearMonth == suplierPay2.AddUpYearMonth)
                 && (suplierPay1.LastTimePayment == suplierPay2.LastTimePayment)
                 && (suplierPay1.ThisTimeFeePayNrml == suplierPay2.ThisTimeFeePayNrml)
                 && (suplierPay1.ThisTimeDisPayNrml == suplierPay2.ThisTimeDisPayNrml)
                 && (suplierPay1.ThisTimePayNrml == suplierPay2.ThisTimePayNrml)
                 && (suplierPay1.ThisTimeTtlBlcPay == suplierPay2.ThisTimeTtlBlcPay)
                 && (suplierPay1.OfsThisTimeSales == suplierPay2.OfsThisTimeSales)
                 && (suplierPay1.OfsThisSalesTax == suplierPay2.OfsThisSalesTax)
                 && (suplierPay1.ItdedOffsetOutTax == suplierPay2.ItdedOffsetOutTax)
                 && (suplierPay1.ItdedOffsetInTax == suplierPay2.ItdedOffsetInTax)
                 && (suplierPay1.ItdedOffsetTaxFree == suplierPay2.ItdedOffsetTaxFree)
                 && (suplierPay1.OffsetOutTax == suplierPay2.OffsetOutTax)
                 && (suplierPay1.OffsetInTax == suplierPay2.OffsetInTax)
                 && (suplierPay1.ThisTimeStockPrice == suplierPay2.ThisTimeStockPrice)
                 && (suplierPay1.ThisStcPrcTax == suplierPay2.ThisStcPrcTax)
                 && (suplierPay1.TtlItdedStcOutTax == suplierPay2.TtlItdedStcOutTax)
                 && (suplierPay1.TtlItdedStcInTax == suplierPay2.TtlItdedStcInTax)
                 && (suplierPay1.TtlItdedStcTaxFree == suplierPay2.TtlItdedStcTaxFree)
                 && (suplierPay1.TtlStockOuterTax == suplierPay2.TtlStockOuterTax)
                 && (suplierPay1.TtlStockInnerTax == suplierPay2.TtlStockInnerTax)
                 && (suplierPay1.ThisStckPricRgds == suplierPay2.ThisStckPricRgds)
                 && (suplierPay1.ThisStcPrcTaxRgds == suplierPay2.ThisStcPrcTaxRgds)
                 && (suplierPay1.TtlItdedRetOutTax == suplierPay2.TtlItdedRetOutTax)
                 && (suplierPay1.TtlItdedRetInTax == suplierPay2.TtlItdedRetInTax)
                 && (suplierPay1.TtlItdedRetTaxFree == suplierPay2.TtlItdedRetTaxFree)
                 && (suplierPay1.TtlRetOuterTax == suplierPay2.TtlRetOuterTax)
                 && (suplierPay1.TtlRetInnerTax == suplierPay2.TtlRetInnerTax)
                 && (suplierPay1.ThisStckPricDis == suplierPay2.ThisStckPricDis)
                 && (suplierPay1.ThisStcPrcTaxDis == suplierPay2.ThisStcPrcTaxDis)
                 && (suplierPay1.TtlItdedDisOutTax == suplierPay2.TtlItdedDisOutTax)
                 && (suplierPay1.TtlItdedDisInTax == suplierPay2.TtlItdedDisInTax)
                 && (suplierPay1.TtlItdedDisTaxFree == suplierPay2.TtlItdedDisTaxFree)
                 && (suplierPay1.TtlDisOuterTax == suplierPay2.TtlDisOuterTax)
                 && (suplierPay1.TtlDisInnerTax == suplierPay2.TtlDisInnerTax)
                 && (suplierPay1.ThisRecvOffset == suplierPay2.ThisRecvOffset)
                 && (suplierPay1.ThisRecvOffsetTax == suplierPay2.ThisRecvOffsetTax)
                 && (suplierPay1.ThisRecvOutTax == suplierPay2.ThisRecvOutTax)
                 && (suplierPay1.ThisRecvInTax == suplierPay2.ThisRecvInTax)
                 && (suplierPay1.ThisRecvTaxFree == suplierPay2.ThisRecvTaxFree)
                 && (suplierPay1.ThisRecvOuterTax == suplierPay2.ThisRecvOuterTax)
                 && (suplierPay1.ThisRecvInnerTax == suplierPay2.ThisRecvInnerTax)
                 && (suplierPay1.TaxAdjust == suplierPay2.TaxAdjust)
                 && (suplierPay1.BalanceAdjust == suplierPay2.BalanceAdjust)
                 && (suplierPay1.StockTotalPayBalance == suplierPay2.StockTotalPayBalance)
                 && (suplierPay1.StockTtl2TmBfBlPay == suplierPay2.StockTtl2TmBfBlPay)
                 && (suplierPay1.StockTtl3TmBfBlPay == suplierPay2.StockTtl3TmBfBlPay)
                 && (suplierPay1.CAddUpUpdExecDate == suplierPay2.CAddUpUpdExecDate)
                 && (suplierPay1.StartCAddUpUpdDate == suplierPay2.StartCAddUpUpdDate)
                 && (suplierPay1.LastCAddUpUpdDate == suplierPay2.LastCAddUpUpdDate)
                 && (suplierPay1.StockSlipCount == suplierPay2.StockSlipCount)
                 && (suplierPay1.PaymentSchedule == suplierPay2.PaymentSchedule)
                 && (suplierPay1.PaymentCond == suplierPay2.PaymentCond)
                 && (suplierPay1.SuppCTaxLayCd == suplierPay2.SuppCTaxLayCd)
                 && (suplierPay1.SupplierConsTaxRate == suplierPay2.SupplierConsTaxRate)
                 && (suplierPay1.FractionProcCd == suplierPay2.FractionProcCd)
                 && (suplierPay1.EnterpriseName == suplierPay2.EnterpriseName)
                 && (suplierPay1.UpdEmployeeName == suplierPay2.UpdEmployeeName)
                 && (suplierPay1.AddUpSecName == suplierPay2.AddUpSecName)
                 && (suplierPay1.SuppCTaxLayMethodNm == suplierPay2.SuppCTaxLayMethodNm));
        }
        /// <summary>
        /// 仕入先支払金額マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSuplierPayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SuplierPay target)
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
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimePayment != target.LastTimePayment) resList.Add("LastTimePayment");
            if (this.ThisTimeFeePayNrml != target.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (this.ThisTimeDisPayNrml != target.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            if (this.ThisTimePayNrml != target.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (this.ThisTimeTtlBlcPay != target.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (this.OfsThisTimeSales != target.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (this.OfsThisSalesTax != target.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (this.ItdedOffsetOutTax != target.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (this.ItdedOffsetInTax != target.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (this.OffsetOutTax != target.OffsetOutTax) resList.Add("OffsetOutTax");
            if (this.OffsetInTax != target.OffsetInTax) resList.Add("OffsetInTax");
            if (this.ThisTimeStockPrice != target.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (this.ThisStcPrcTax != target.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (this.TtlItdedStcOutTax != target.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (this.TtlItdedStcInTax != target.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (this.TtlStockOuterTax != target.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (this.TtlStockInnerTax != target.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (this.ThisStckPricRgds != target.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (this.ThisStcPrcTaxRgds != target.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (this.TtlItdedRetOutTax != target.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (this.TtlItdedRetInTax != target.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (this.TtlRetOuterTax != target.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (this.TtlRetInnerTax != target.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (this.ThisStckPricDis != target.ThisStckPricDis) resList.Add("ThisStckPricDis");
            if (this.ThisStcPrcTaxDis != target.ThisStcPrcTaxDis) resList.Add("ThisStcPrcTaxDis");
            if (this.TtlItdedDisOutTax != target.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (this.TtlItdedDisInTax != target.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (this.TtlDisOuterTax != target.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (this.TtlDisInnerTax != target.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (this.ThisRecvOffset != target.ThisRecvOffset) resList.Add("ThisRecvOffset");
            if (this.ThisRecvOffsetTax != target.ThisRecvOffsetTax) resList.Add("ThisRecvOffsetTax");
            if (this.ThisRecvOutTax != target.ThisRecvOutTax) resList.Add("ThisRecvOutTax");
            if (this.ThisRecvInTax != target.ThisRecvInTax) resList.Add("ThisRecvInTax");
            if (this.ThisRecvTaxFree != target.ThisRecvTaxFree) resList.Add("ThisRecvTaxFree");
            if (this.ThisRecvOuterTax != target.ThisRecvOuterTax) resList.Add("ThisRecvOuterTax");
            if (this.ThisRecvInnerTax != target.ThisRecvInnerTax) resList.Add("ThisRecvInnerTax");
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.StockTotalPayBalance != target.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (this.StockTtl2TmBfBlPay != target.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (this.StockTtl3TmBfBlPay != target.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.StockSlipCount != target.StockSlipCount) resList.Add("StockSlipCount");
            if (this.PaymentSchedule != target.PaymentSchedule) resList.Add("PaymentSchedule");
            if (this.PaymentCond != target.PaymentCond) resList.Add("PaymentCond");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (this.SupplierConsTaxRate != target.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");

            return resList;
        }

        /// <summary>
        /// 仕入先支払金額マスタ比較処理
        /// </summary>
        /// <param name="suplierPay1">比較するSuplierPayクラスのインスタンス</param>
        /// <param name="suplierPay2">比較するSuplierPayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SuplierPay suplierPay1, SuplierPay suplierPay2)
        {
            ArrayList resList = new ArrayList();
            if (suplierPay1.CreateDateTime != suplierPay2.CreateDateTime) resList.Add("CreateDateTime");
            if (suplierPay1.UpdateDateTime != suplierPay2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (suplierPay1.EnterpriseCode != suplierPay2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (suplierPay1.FileHeaderGuid != suplierPay2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (suplierPay1.UpdEmployeeCode != suplierPay2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (suplierPay1.UpdAssemblyId1 != suplierPay2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (suplierPay1.UpdAssemblyId2 != suplierPay2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (suplierPay1.LogicalDeleteCode != suplierPay2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (suplierPay1.AddUpSecCode != suplierPay2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (suplierPay1.PayeeCode != suplierPay2.PayeeCode) resList.Add("PayeeCode");
            if (suplierPay1.PayeeName != suplierPay2.PayeeName) resList.Add("PayeeName");
            if (suplierPay1.PayeeName2 != suplierPay2.PayeeName2) resList.Add("PayeeName2");
            if (suplierPay1.PayeeSnm != suplierPay2.PayeeSnm) resList.Add("PayeeSnm");
            if (suplierPay1.CustomerCode != suplierPay2.CustomerCode) resList.Add("CustomerCode");
            if (suplierPay1.CustomerName != suplierPay2.CustomerName) resList.Add("CustomerName");
            if (suplierPay1.CustomerName2 != suplierPay2.CustomerName2) resList.Add("CustomerName2");
            if (suplierPay1.CustomerSnm != suplierPay2.CustomerSnm) resList.Add("CustomerSnm");
            if (suplierPay1.AddUpDate != suplierPay2.AddUpDate) resList.Add("AddUpDate");
            if (suplierPay1.AddUpYearMonth != suplierPay2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (suplierPay1.LastTimePayment != suplierPay2.LastTimePayment) resList.Add("LastTimePayment");
            if (suplierPay1.ThisTimeFeePayNrml != suplierPay2.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (suplierPay1.ThisTimeDisPayNrml != suplierPay2.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            if (suplierPay1.ThisTimePayNrml != suplierPay2.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (suplierPay1.ThisTimeTtlBlcPay != suplierPay2.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (suplierPay1.OfsThisTimeSales != suplierPay2.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (suplierPay1.OfsThisSalesTax != suplierPay2.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (suplierPay1.ItdedOffsetOutTax != suplierPay2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (suplierPay1.ItdedOffsetInTax != suplierPay2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (suplierPay1.ItdedOffsetTaxFree != suplierPay2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (suplierPay1.OffsetOutTax != suplierPay2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (suplierPay1.OffsetInTax != suplierPay2.OffsetInTax) resList.Add("OffsetInTax");
            if (suplierPay1.ThisTimeStockPrice != suplierPay2.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (suplierPay1.ThisStcPrcTax != suplierPay2.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (suplierPay1.TtlItdedStcOutTax != suplierPay2.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (suplierPay1.TtlItdedStcInTax != suplierPay2.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (suplierPay1.TtlItdedStcTaxFree != suplierPay2.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (suplierPay1.TtlStockOuterTax != suplierPay2.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (suplierPay1.TtlStockInnerTax != suplierPay2.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (suplierPay1.ThisStckPricRgds != suplierPay2.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (suplierPay1.ThisStcPrcTaxRgds != suplierPay2.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (suplierPay1.TtlItdedRetOutTax != suplierPay2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (suplierPay1.TtlItdedRetInTax != suplierPay2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (suplierPay1.TtlItdedRetTaxFree != suplierPay2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (suplierPay1.TtlRetOuterTax != suplierPay2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (suplierPay1.TtlRetInnerTax != suplierPay2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (suplierPay1.ThisStckPricDis != suplierPay2.ThisStckPricDis) resList.Add("ThisStckPricDis");
            if (suplierPay1.ThisStcPrcTaxDis != suplierPay2.ThisStcPrcTaxDis) resList.Add("ThisStcPrcTaxDis");
            if (suplierPay1.TtlItdedDisOutTax != suplierPay2.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (suplierPay1.TtlItdedDisInTax != suplierPay2.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (suplierPay1.TtlItdedDisTaxFree != suplierPay2.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (suplierPay1.TtlDisOuterTax != suplierPay2.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (suplierPay1.TtlDisInnerTax != suplierPay2.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (suplierPay1.ThisRecvOffset != suplierPay2.ThisRecvOffset) resList.Add("ThisRecvOffset");
            if (suplierPay1.ThisRecvOffsetTax != suplierPay2.ThisRecvOffsetTax) resList.Add("ThisRecvOffsetTax");
            if (suplierPay1.ThisRecvOutTax != suplierPay2.ThisRecvOutTax) resList.Add("ThisRecvOutTax");
            if (suplierPay1.ThisRecvInTax != suplierPay2.ThisRecvInTax) resList.Add("ThisRecvInTax");
            if (suplierPay1.ThisRecvTaxFree != suplierPay2.ThisRecvTaxFree) resList.Add("ThisRecvTaxFree");
            if (suplierPay1.ThisRecvOuterTax != suplierPay2.ThisRecvOuterTax) resList.Add("ThisRecvOuterTax");
            if (suplierPay1.ThisRecvInnerTax != suplierPay2.ThisRecvInnerTax) resList.Add("ThisRecvInnerTax");
            if (suplierPay1.TaxAdjust != suplierPay2.TaxAdjust) resList.Add("TaxAdjust");
            if (suplierPay1.BalanceAdjust != suplierPay2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (suplierPay1.StockTotalPayBalance != suplierPay2.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (suplierPay1.StockTtl2TmBfBlPay != suplierPay2.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (suplierPay1.StockTtl3TmBfBlPay != suplierPay2.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (suplierPay1.CAddUpUpdExecDate != suplierPay2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (suplierPay1.StartCAddUpUpdDate != suplierPay2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (suplierPay1.LastCAddUpUpdDate != suplierPay2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (suplierPay1.StockSlipCount != suplierPay2.StockSlipCount) resList.Add("StockSlipCount");
            if (suplierPay1.PaymentSchedule != suplierPay2.PaymentSchedule) resList.Add("PaymentSchedule");
            if (suplierPay1.PaymentCond != suplierPay2.PaymentCond) resList.Add("PaymentCond");
            if (suplierPay1.SuppCTaxLayCd != suplierPay2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (suplierPay1.SupplierConsTaxRate != suplierPay2.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (suplierPay1.FractionProcCd != suplierPay2.FractionProcCd) resList.Add("FractionProcCd");
            if (suplierPay1.EnterpriseName != suplierPay2.EnterpriseName) resList.Add("EnterpriseName");
            if (suplierPay1.UpdEmployeeName != suplierPay2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (suplierPay1.AddUpSecName != suplierPay2.AddUpSecName) resList.Add("AddUpSecName");
            if (suplierPay1.SuppCTaxLayMethodNm != suplierPay2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");

            return resList;
        }
    }
}
