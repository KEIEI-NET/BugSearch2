//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先実績修正
// プログラム概要   ：得意先実績修正の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：21024 佐々木 健
// 修正日    2009/01/06     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/23     修正内容：Mantis【13484】請求書Noを追加
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustDmdPrc
    /// <summary>
    ///                      得意先請求金額マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先請求金額マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/06/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustDmdPrc
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

        /// <summary>実績拠点コード</summary>
        /// <remarks>実績集計の対象となっている拠点コード</remarks>
        private string _resultsSectCd = "";

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
        /// <remarks>相殺結果　「相殺後：***」の値が請求金額となる</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>相殺後今回売上消費税</summary>
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

        // ADD 2009/06/23 ------>>>
        /// <summary>請求書No</summary>
        private Int32 _billNo;
        // ADD 2009/06/23 ------<<<
        
        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  AddUpDateJpFormal
        /// <summary>計上年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
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
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
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
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
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
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
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
        /// <value>相殺結果　「相殺後：***」の値が請求金額となる</value>
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
        /// <value>相殺結果</value>
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

        /// public propaty name  :  BillPrintDateJpFormal
        /// <summary>請求書発行日 和暦プロパティ</summary>
        /// <value>"YYYYMMDD"  請求書を発行した年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillPrintDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _billPrintDate); }
            set { }
        }

        /// public propaty name  :  BillPrintDateJpInFormal
        /// <summary>請求書発行日 和暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  請求書を発行した年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillPrintDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _billPrintDate); }
            set { }
        }

        /// public propaty name  :  BillPrintDateAdFormal
        /// <summary>請求書発行日 西暦プロパティ</summary>
        /// <value>"YYYYMMDD"  請求書を発行した年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillPrintDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _billPrintDate); }
            set { }
        }

        /// public propaty name  :  BillPrintDateAdInFormal
        /// <summary>請求書発行日 西暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  請求書を発行した年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillPrintDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _billPrintDate); }
            set { }
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

        /// public propaty name  :  ExpectedDepositDateJpFormal
        /// <summary>入金予定日 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectedDepositDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDateJpInFormal
        /// <summary>入金予定日 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectedDepositDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDateAdFormal
        /// <summary>入金予定日 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectedDepositDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDateAdInFormal
        /// <summary>入金予定日 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectedDepositDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _expectedDepositDate); }
            set { }
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

        // ADD 2009/06/23 ------>>>
        /// public propaty name  :  BillNo
        /// <summary>請求書Noプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillNo
        {
            get { return _billNo; }
            set { _billNo = value; }
        }
        // ADD 2009/06/23 ------<<<
        
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


        /// <summary>
        /// 得意先請求金額マスタコンストラクタ
        /// </summary>
        /// <returns>CustDmdPrcクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrc()
        {
        }

        /// <summary>
        /// 得意先請求金額マスタコンストラクタ
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
        /// <param name="resultsSectCd">実績拠点コード(実績集計の対象となっている拠点コード)</param>
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
        /// <param name="ofsThisTimeSales">相殺後今回売上金額(相殺結果　「相殺後：***」の値が請求金額となる)</param>
        /// <param name="ofsThisSalesTax">相殺後今回売上消費税(相殺結果)</param>
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
        /// <param name="billNo">請求書No</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <returns>CustDmdPrcクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public CustDmdPrc(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, string resultsSectCd, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeSales, Int64 thisSalesTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 salesSlipCount, DateTime billPrintDate, DateTime expectedDepositDate, Int32 collectCond, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, string enterpriseName, string updEmployeeName, string addUpSecName)   // DEL 2009/06/23
        public CustDmdPrc(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, string resultsSectCd, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeSales, Int64 thisSalesTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 salesSlipCount, DateTime billPrintDate, DateTime expectedDepositDate, Int32 collectCond, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int32 billNo, string enterpriseName, string updEmployeeName, string addUpSecName)   // ADD 2009/06/23
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
            this._resultsSectCd = resultsSectCd;
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
            this._billNo = billNo;  // ADD 2009/06/23
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// 得意先請求金額マスタ複製処理
        /// </summary>
        /// <returns>CustDmdPrcクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustDmdPrcクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrc Clone()
        {
            //return new CustDmdPrc(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._resultsSectCd, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeDmdNrml, this._thisTimeTtlBlcDmd, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeSales, this._thisSalesTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._taxAdjust, this._balanceAdjust, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._salesSlipCount, this._billPrintDate, this._expectedDepositDate, this._collectCond, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName);    // DEL 2009/06/23
            return new CustDmdPrc(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._resultsSectCd, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeDmdNrml, this._thisTimeTtlBlcDmd, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeSales, this._thisSalesTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._taxAdjust, this._balanceAdjust, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._salesSlipCount, this._billPrintDate, this._expectedDepositDate, this._collectCond, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._billNo, this._enterpriseName, this._updEmployeeName, this._addUpSecName);    // ADD 2009/06/23
        }

        /// <summary>
        /// 得意先請求金額マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCustDmdPrcクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustDmdPrc target)
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
                 && (this.ResultsSectCd == target.ResultsSectCd)
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
                 && (this.BillNo == target.BillNo)  // ADD 2009/06/23
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// 得意先請求金額マスタ比較処理
        /// </summary>
        /// <param name="custDmdPrc1">
        ///                    比較するCustDmdPrcクラスのインスタンス
        /// </param>
        /// <param name="custDmdPrc2">比較するCustDmdPrcクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustDmdPrc custDmdPrc1, CustDmdPrc custDmdPrc2)
        {
            return ((custDmdPrc1.CreateDateTime == custDmdPrc2.CreateDateTime)
                 && (custDmdPrc1.UpdateDateTime == custDmdPrc2.UpdateDateTime)
                 && (custDmdPrc1.EnterpriseCode == custDmdPrc2.EnterpriseCode)
                 && (custDmdPrc1.FileHeaderGuid == custDmdPrc2.FileHeaderGuid)
                 && (custDmdPrc1.UpdEmployeeCode == custDmdPrc2.UpdEmployeeCode)
                 && (custDmdPrc1.UpdAssemblyId1 == custDmdPrc2.UpdAssemblyId1)
                 && (custDmdPrc1.UpdAssemblyId2 == custDmdPrc2.UpdAssemblyId2)
                 && (custDmdPrc1.LogicalDeleteCode == custDmdPrc2.LogicalDeleteCode)
                 && (custDmdPrc1.AddUpSecCode == custDmdPrc2.AddUpSecCode)
                 && (custDmdPrc1.ClaimCode == custDmdPrc2.ClaimCode)
                 && (custDmdPrc1.ClaimName == custDmdPrc2.ClaimName)
                 && (custDmdPrc1.ClaimName2 == custDmdPrc2.ClaimName2)
                 && (custDmdPrc1.ClaimSnm == custDmdPrc2.ClaimSnm)
                 && (custDmdPrc1.ResultsSectCd == custDmdPrc2.ResultsSectCd)
                 && (custDmdPrc1.CustomerCode == custDmdPrc2.CustomerCode)
                 && (custDmdPrc1.CustomerName == custDmdPrc2.CustomerName)
                 && (custDmdPrc1.CustomerName2 == custDmdPrc2.CustomerName2)
                 && (custDmdPrc1.CustomerSnm == custDmdPrc2.CustomerSnm)
                 && (custDmdPrc1.AddUpDate == custDmdPrc2.AddUpDate)
                 && (custDmdPrc1.AddUpYearMonth == custDmdPrc2.AddUpYearMonth)
                 && (custDmdPrc1.LastTimeDemand == custDmdPrc2.LastTimeDemand)
                 && (custDmdPrc1.ThisTimeFeeDmdNrml == custDmdPrc2.ThisTimeFeeDmdNrml)
                 && (custDmdPrc1.ThisTimeDisDmdNrml == custDmdPrc2.ThisTimeDisDmdNrml)
                 && (custDmdPrc1.ThisTimeDmdNrml == custDmdPrc2.ThisTimeDmdNrml)
                 && (custDmdPrc1.ThisTimeTtlBlcDmd == custDmdPrc2.ThisTimeTtlBlcDmd)
                 && (custDmdPrc1.OfsThisTimeSales == custDmdPrc2.OfsThisTimeSales)
                 && (custDmdPrc1.OfsThisSalesTax == custDmdPrc2.OfsThisSalesTax)
                 && (custDmdPrc1.ItdedOffsetOutTax == custDmdPrc2.ItdedOffsetOutTax)
                 && (custDmdPrc1.ItdedOffsetInTax == custDmdPrc2.ItdedOffsetInTax)
                 && (custDmdPrc1.ItdedOffsetTaxFree == custDmdPrc2.ItdedOffsetTaxFree)
                 && (custDmdPrc1.OffsetOutTax == custDmdPrc2.OffsetOutTax)
                 && (custDmdPrc1.OffsetInTax == custDmdPrc2.OffsetInTax)
                 && (custDmdPrc1.ThisTimeSales == custDmdPrc2.ThisTimeSales)
                 && (custDmdPrc1.ThisSalesTax == custDmdPrc2.ThisSalesTax)
                 && (custDmdPrc1.ItdedSalesOutTax == custDmdPrc2.ItdedSalesOutTax)
                 && (custDmdPrc1.ItdedSalesInTax == custDmdPrc2.ItdedSalesInTax)
                 && (custDmdPrc1.ItdedSalesTaxFree == custDmdPrc2.ItdedSalesTaxFree)
                 && (custDmdPrc1.SalesOutTax == custDmdPrc2.SalesOutTax)
                 && (custDmdPrc1.SalesInTax == custDmdPrc2.SalesInTax)
                 && (custDmdPrc1.ThisSalesPricRgds == custDmdPrc2.ThisSalesPricRgds)
                 && (custDmdPrc1.ThisSalesPrcTaxRgds == custDmdPrc2.ThisSalesPrcTaxRgds)
                 && (custDmdPrc1.TtlItdedRetOutTax == custDmdPrc2.TtlItdedRetOutTax)
                 && (custDmdPrc1.TtlItdedRetInTax == custDmdPrc2.TtlItdedRetInTax)
                 && (custDmdPrc1.TtlItdedRetTaxFree == custDmdPrc2.TtlItdedRetTaxFree)
                 && (custDmdPrc1.TtlRetOuterTax == custDmdPrc2.TtlRetOuterTax)
                 && (custDmdPrc1.TtlRetInnerTax == custDmdPrc2.TtlRetInnerTax)
                 && (custDmdPrc1.ThisSalesPricDis == custDmdPrc2.ThisSalesPricDis)
                 && (custDmdPrc1.ThisSalesPrcTaxDis == custDmdPrc2.ThisSalesPrcTaxDis)
                 && (custDmdPrc1.TtlItdedDisOutTax == custDmdPrc2.TtlItdedDisOutTax)
                 && (custDmdPrc1.TtlItdedDisInTax == custDmdPrc2.TtlItdedDisInTax)
                 && (custDmdPrc1.TtlItdedDisTaxFree == custDmdPrc2.TtlItdedDisTaxFree)
                 && (custDmdPrc1.TtlDisOuterTax == custDmdPrc2.TtlDisOuterTax)
                 && (custDmdPrc1.TtlDisInnerTax == custDmdPrc2.TtlDisInnerTax)
                 && (custDmdPrc1.TaxAdjust == custDmdPrc2.TaxAdjust)
                 && (custDmdPrc1.BalanceAdjust == custDmdPrc2.BalanceAdjust)
                 && (custDmdPrc1.AfCalDemandPrice == custDmdPrc2.AfCalDemandPrice)
                 && (custDmdPrc1.AcpOdrTtl2TmBfBlDmd == custDmdPrc2.AcpOdrTtl2TmBfBlDmd)
                 && (custDmdPrc1.AcpOdrTtl3TmBfBlDmd == custDmdPrc2.AcpOdrTtl3TmBfBlDmd)
                 && (custDmdPrc1.CAddUpUpdExecDate == custDmdPrc2.CAddUpUpdExecDate)
                 && (custDmdPrc1.StartCAddUpUpdDate == custDmdPrc2.StartCAddUpUpdDate)
                 && (custDmdPrc1.LastCAddUpUpdDate == custDmdPrc2.LastCAddUpUpdDate)
                 && (custDmdPrc1.SalesSlipCount == custDmdPrc2.SalesSlipCount)
                 && (custDmdPrc1.BillPrintDate == custDmdPrc2.BillPrintDate)
                 && (custDmdPrc1.ExpectedDepositDate == custDmdPrc2.ExpectedDepositDate)
                 && (custDmdPrc1.CollectCond == custDmdPrc2.CollectCond)
                 && (custDmdPrc1.ConsTaxLayMethod == custDmdPrc2.ConsTaxLayMethod)
                 && (custDmdPrc1.ConsTaxRate == custDmdPrc2.ConsTaxRate)
                 && (custDmdPrc1.FractionProcCd == custDmdPrc2.FractionProcCd)
                 && (custDmdPrc1.BillNo == custDmdPrc2.BillNo)  // ADD 2009/06/23
                 && (custDmdPrc1.EnterpriseName == custDmdPrc2.EnterpriseName)
                 && (custDmdPrc1.UpdEmployeeName == custDmdPrc2.UpdEmployeeName)
                 && (custDmdPrc1.AddUpSecName == custDmdPrc2.AddUpSecName));
        }
        /// <summary>
        /// 得意先請求金額マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCustDmdPrcクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustDmdPrc target)
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
            if (this.ResultsSectCd != target.ResultsSectCd) resList.Add("ResultsSectCd");
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
            if (this.BillNo != target.BillNo) resList.Add("BillNo");    // ADD 2009/06/23
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// 得意先請求金額マスタ比較処理
        /// </summary>
        /// <param name="custDmdPrc1">比較するCustDmdPrcクラスのインスタンス</param>
        /// <param name="custDmdPrc2">比較するCustDmdPrcクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustDmdPrc custDmdPrc1, CustDmdPrc custDmdPrc2)
        {
            ArrayList resList = new ArrayList();
            if (custDmdPrc1.CreateDateTime != custDmdPrc2.CreateDateTime) resList.Add("CreateDateTime");
            if (custDmdPrc1.UpdateDateTime != custDmdPrc2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (custDmdPrc1.EnterpriseCode != custDmdPrc2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custDmdPrc1.FileHeaderGuid != custDmdPrc2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (custDmdPrc1.UpdEmployeeCode != custDmdPrc2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (custDmdPrc1.UpdAssemblyId1 != custDmdPrc2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (custDmdPrc1.UpdAssemblyId2 != custDmdPrc2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (custDmdPrc1.LogicalDeleteCode != custDmdPrc2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (custDmdPrc1.AddUpSecCode != custDmdPrc2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (custDmdPrc1.ClaimCode != custDmdPrc2.ClaimCode) resList.Add("ClaimCode");
            if (custDmdPrc1.ClaimName != custDmdPrc2.ClaimName) resList.Add("ClaimName");
            if (custDmdPrc1.ClaimName2 != custDmdPrc2.ClaimName2) resList.Add("ClaimName2");
            if (custDmdPrc1.ClaimSnm != custDmdPrc2.ClaimSnm) resList.Add("ClaimSnm");
            if (custDmdPrc1.ResultsSectCd != custDmdPrc2.ResultsSectCd) resList.Add("ResultsSectCd");
            if (custDmdPrc1.CustomerCode != custDmdPrc2.CustomerCode) resList.Add("CustomerCode");
            if (custDmdPrc1.CustomerName != custDmdPrc2.CustomerName) resList.Add("CustomerName");
            if (custDmdPrc1.CustomerName2 != custDmdPrc2.CustomerName2) resList.Add("CustomerName2");
            if (custDmdPrc1.CustomerSnm != custDmdPrc2.CustomerSnm) resList.Add("CustomerSnm");
            if (custDmdPrc1.AddUpDate != custDmdPrc2.AddUpDate) resList.Add("AddUpDate");
            if (custDmdPrc1.AddUpYearMonth != custDmdPrc2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (custDmdPrc1.LastTimeDemand != custDmdPrc2.LastTimeDemand) resList.Add("LastTimeDemand");
            if (custDmdPrc1.ThisTimeFeeDmdNrml != custDmdPrc2.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (custDmdPrc1.ThisTimeDisDmdNrml != custDmdPrc2.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (custDmdPrc1.ThisTimeDmdNrml != custDmdPrc2.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (custDmdPrc1.ThisTimeTtlBlcDmd != custDmdPrc2.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (custDmdPrc1.OfsThisTimeSales != custDmdPrc2.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (custDmdPrc1.OfsThisSalesTax != custDmdPrc2.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (custDmdPrc1.ItdedOffsetOutTax != custDmdPrc2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (custDmdPrc1.ItdedOffsetInTax != custDmdPrc2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (custDmdPrc1.ItdedOffsetTaxFree != custDmdPrc2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (custDmdPrc1.OffsetOutTax != custDmdPrc2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (custDmdPrc1.OffsetInTax != custDmdPrc2.OffsetInTax) resList.Add("OffsetInTax");
            if (custDmdPrc1.ThisTimeSales != custDmdPrc2.ThisTimeSales) resList.Add("ThisTimeSales");
            if (custDmdPrc1.ThisSalesTax != custDmdPrc2.ThisSalesTax) resList.Add("ThisSalesTax");
            if (custDmdPrc1.ItdedSalesOutTax != custDmdPrc2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (custDmdPrc1.ItdedSalesInTax != custDmdPrc2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (custDmdPrc1.ItdedSalesTaxFree != custDmdPrc2.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (custDmdPrc1.SalesOutTax != custDmdPrc2.SalesOutTax) resList.Add("SalesOutTax");
            if (custDmdPrc1.SalesInTax != custDmdPrc2.SalesInTax) resList.Add("SalesInTax");
            if (custDmdPrc1.ThisSalesPricRgds != custDmdPrc2.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (custDmdPrc1.ThisSalesPrcTaxRgds != custDmdPrc2.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (custDmdPrc1.TtlItdedRetOutTax != custDmdPrc2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (custDmdPrc1.TtlItdedRetInTax != custDmdPrc2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (custDmdPrc1.TtlItdedRetTaxFree != custDmdPrc2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (custDmdPrc1.TtlRetOuterTax != custDmdPrc2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (custDmdPrc1.TtlRetInnerTax != custDmdPrc2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (custDmdPrc1.ThisSalesPricDis != custDmdPrc2.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (custDmdPrc1.ThisSalesPrcTaxDis != custDmdPrc2.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (custDmdPrc1.TtlItdedDisOutTax != custDmdPrc2.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (custDmdPrc1.TtlItdedDisInTax != custDmdPrc2.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (custDmdPrc1.TtlItdedDisTaxFree != custDmdPrc2.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (custDmdPrc1.TtlDisOuterTax != custDmdPrc2.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (custDmdPrc1.TtlDisInnerTax != custDmdPrc2.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (custDmdPrc1.TaxAdjust != custDmdPrc2.TaxAdjust) resList.Add("TaxAdjust");
            if (custDmdPrc1.BalanceAdjust != custDmdPrc2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (custDmdPrc1.AfCalDemandPrice != custDmdPrc2.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (custDmdPrc1.AcpOdrTtl2TmBfBlDmd != custDmdPrc2.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (custDmdPrc1.AcpOdrTtl3TmBfBlDmd != custDmdPrc2.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (custDmdPrc1.CAddUpUpdExecDate != custDmdPrc2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (custDmdPrc1.StartCAddUpUpdDate != custDmdPrc2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (custDmdPrc1.LastCAddUpUpdDate != custDmdPrc2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (custDmdPrc1.SalesSlipCount != custDmdPrc2.SalesSlipCount) resList.Add("SalesSlipCount");
            if (custDmdPrc1.BillPrintDate != custDmdPrc2.BillPrintDate) resList.Add("BillPrintDate");
            if (custDmdPrc1.ExpectedDepositDate != custDmdPrc2.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (custDmdPrc1.CollectCond != custDmdPrc2.CollectCond) resList.Add("CollectCond");
            if (custDmdPrc1.ConsTaxLayMethod != custDmdPrc2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (custDmdPrc1.ConsTaxRate != custDmdPrc2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (custDmdPrc1.FractionProcCd != custDmdPrc2.FractionProcCd) resList.Add("FractionProcCd");
            if (custDmdPrc1.BillNo != custDmdPrc2.BillNo) resList.Add("BillNo");    // ADD 2009/06/23
            if (custDmdPrc1.EnterpriseName != custDmdPrc2.EnterpriseName) resList.Add("EnterpriseName");
            if (custDmdPrc1.UpdEmployeeName != custDmdPrc2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (custDmdPrc1.AddUpSecName != custDmdPrc2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
