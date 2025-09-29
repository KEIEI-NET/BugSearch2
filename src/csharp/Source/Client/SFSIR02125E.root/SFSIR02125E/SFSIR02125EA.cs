using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchPaymentSlp
    /// <summary>
    ///                      支払伝票検索クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払伝票検索クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/07/08 30414 忍 幸史 Partsman用に変更</br>
    /// <br>                     ※ 支払伝票マスタ(SFSIR02135E)と同様の内容の為、</br>
    /// <br>                        変更があった場合は、支払伝票マスタの方も</br>
    /// <br>                        変更内容を確認すること！</br>
    /// </remarks>
    public class SearchPaymentSlp
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

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>支払伝票番号</summary>
        private Int32 _paymentSlipNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>支払先コード</summary>
        /// <remarks>支払先の親コード</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>支払入力拠点コード</summary>
        /// <remarks>文字型 支払入力した拠点コード</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>文字型 データの登録更新拠点</remarks>
        private string _updateSecCd = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>支払日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>支払計</summary>
        /// <remarks>支払金額＋手数料支払額＋値引支払額</remarks>
        private Int64 _paymentTotal;

        /// <summary>支払金額</summary>
        private Int64 _payment;

        /// <summary>手数料支払額</summary>
        private Int64 _feePayment;

        /// <summary>値引支払額</summary>
        private Int64 _discountPayment;

        /// <summary>自動支払区分</summary>
        /// <remarks>0:通常支払,　1:自動支払</remarks>
        private Int32 _autoPayment;

        /// <summary>手形振出日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>手形種類</summary>
        private Int32 _draftKind;

        /// <summary>手形種類名称</summary>
        /// <remarks>約束、為替、小切手</remarks>
        private string _draftKindName = "";

        /// <summary>手形区分</summary>
        private Int32 _draftDivide;

        /// <summary>手形区分名称</summary>
        /// <remarks>自振、廻し</remarks>
        private string _draftDivideName = "";

        /// <summary>手形番号</summary>
        private string _draftNo = "";

        /// <summary>赤黒支払連結番号</summary>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>支払担当者コード</summary>
        private string _paymentAgentCode = "";

        /// <summary>支払担当者名称</summary>
        private string _paymentAgentName = "";

        /// <summary>支払入力者コード</summary>
        private string _paymentInputAgentCd = "";

        /// <summary>支払入力者名称</summary>
        private string _paymentInputAgentNm = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
        private string _outline = "";

        /// <summary>銀行コード</summary>
        /// <remarks>郵便局：9900</remarks>
        private Int32 _bankCode;

        /// <summary>銀行名称</summary>
        private string _bankName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>支払行番号</summary>
        private Int32[] _paymentRowNoDtl = new Int32[10];

        /// <summary>金種コード</summary>
        private Int32[] _moneyKindCodeDtl = new Int32[10];

        /// <summary>金種名称</summary>
        private String[] _moneyKindNameDtl = new String[10];

        /// <summary>金種区分</summary>
        private Int32[] _moneyKindDivDtl = new Int32[10];

        /// <summary>支払金額</summary>
        private Int64[] _paymentDtl = new Int64[10];

        /// <summary>有効期限</summary>
        private DateTime[] _validityTermDtl = new DateTime[10];

        /// <summary>最終計上締日</summary>
        private Int32 _cAddUpUpdDate;
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        private DateTime _inputDay;

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
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>支払伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
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
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
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
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
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
            get { return _supplierCd; }
            set { _supplierCd = value; }
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
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
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
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
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
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
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

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>支払入力拠点コードプロパティ</summary>
        /// <value>文字型 支払入力した拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
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

        /// public propaty name  :  UpdateSecCd
        /// <summary>更新拠点コードプロパティ</summary>
        /// <value>文字型 データの登録更新拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
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
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
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
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        /// public propaty name  :  PaymentDateJpFormal
        /// <summary>支払日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  PaymentDateJpInFormal
        /// <summary>支払日付 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  PaymentDateAdFormal
        /// <summary>支払日付 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  PaymentDateAdInFormal
        /// <summary>支払日付 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  AddUpADateJpFormal
        /// <summary>計上日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateJpInFormal
        /// <summary>計上日付 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdFormal
        /// <summary>計上日付 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdInFormal
        /// <summary>計上日付 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  PaymentTotal
        /// <summary>支払計プロパティ</summary>
        /// <value>支払金額＋手数料支払額＋値引支払額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PaymentTotal
        {
            get { return _paymentTotal; }
            set { _paymentTotal = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>支払金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>手数料支払額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>値引支払額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>0:通常支払,　1:自動支払</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>手形振出日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DraftDrawingDate
        {
            get { return _draftDrawingDate; }
            set { _draftDrawingDate = value; }
        }

        /// public propaty name  :  DraftDrawingDateJpFormal
        /// <summary>手形振出日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDrawingDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateJpInFormal
        /// <summary>手形振出日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDrawingDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateAdFormal
        /// <summary>手形振出日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDrawingDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateAdInFormal
        /// <summary>手形振出日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDrawingDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftKind
        /// <summary>手形種類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftKind
        {
            get { return _draftKind; }
            set { _draftKind = value; }
        }

        /// public propaty name  :  DraftKindName
        /// <summary>手形種類名称プロパティ</summary>
        /// <value>約束、為替、小切手</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftKindName
        {
            get { return _draftKindName; }
            set { _draftKindName = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>手形区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  DraftDivideName
        /// <summary>手形区分名称プロパティ</summary>
        /// <value>自振、廻し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftDivideName
        {
            get { return _draftDivideName; }
            set { _draftDivideName = value; }
        }

        /// public propaty name  :  DraftNo
        /// <summary>手形番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftNo
        {
            get { return _draftNo; }
            set { _draftNo = value; }
        }

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>赤黒支払連結番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒支払連結番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteLinkPayNo
        {
            get { return _debitNoteLinkPayNo; }
            set { _debitNoteLinkPayNo = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>支払担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>支払担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>支払入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>支払入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>車販の場合、摘要+注文書№+管理番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  BankCode
        /// <summary>銀行コードプロパティ</summary>
        /// <value>郵便局：9900</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BankCode
        {
            get { return _bankCode; }
            set { _bankCode = value; }
        }

        /// public propaty name  :  BankName
        /// <summary>銀行名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
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

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// public property name  :  PaymentRowNoDtl
        /// <summary>支払行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] PaymentRowNoDtl
        {
            get { return _paymentRowNoDtl; }
            set { _paymentRowNoDtl = value; }
        }

        /// public property name  :  MoneyKindCodeDtl
        /// <summary>金種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] MoneyKindCodeDtl
        {
            get { return _moneyKindCodeDtl; }
            set { _moneyKindCodeDtl = value; }
        }

        /// public property name  :  MoneyKindNameDtl
        /// <summary>金種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] MoneyKindNameDtl
        {
            get { return _moneyKindNameDtl; }
            set { _moneyKindNameDtl = value; }
        }

        /// public property name  :  MoneyKindDivDtl
        /// <summary>金種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] MoneyKindDivDtl
        {
            get { return _moneyKindDivDtl; }
            set { _moneyKindDivDtl = value; }
        }

        /// public property name  :  PaymentDtl
        /// <summary>支払金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64[] PaymentDtl
        {
            get { return _paymentDtl; }
            set { _paymentDtl = value; }
        }

        /// public property name  :  ValidityTermDtl
        /// <summary>有効期限プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime[] ValidityTermDtl
        {
            get { return _validityTermDtl; }
            set { _validityTermDtl = value; }
        }
        /// public property name  :  CAddUpUpdDate
        /// <summary>有効期限プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CAddUpUpdDate
        {
            get { return _cAddUpUpdDate; }
            set { _cAddUpUpdDate = value; }
        }

        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// public propaty name  :  InputDay
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }


        /// <summary>
        /// 支払伝票マスタコンストラクタ
        /// </summary>
        /// <returns>SearchPaymentSlpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPaymentSlpクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchPaymentSlp()
        {
            for (int index = 0; index < this._moneyKindNameDtl.Length; index++)
            {
                this._moneyKindNameDtl[index] = "";
            }
        }

        /// <summary>
        /// 支払伝票マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierNm1">仕入先名1</param>
        /// <param name="supplierNm2">仕入先名2</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="payeeCode">支払先コード(支払先の親コード)</param>
        /// <param name="payeeName">支払先名称</param>
        /// <param name="payeeName2">支払先名称2</param>
        /// <param name="payeeSnm">支払先略称</param>
        /// <param name="paymentInpSectionCd">支払入力拠点コード(文字型 支払入力した拠点コード)</param>
        /// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="paymentDate">支払日付(YYYYMMDD)</param>
        /// <param name="addUpADate">計上日付(YYYYMMDD)</param>
        /// <param name="paymentTotal">支払計(支払金額＋手数料支払額＋値引支払額)</param>
        /// <param name="payment">支払金額</param>
        /// <param name="feePayment">手数料支払額</param>
        /// <param name="discountPayment">値引支払額</param>
        /// <param name="autoPayment">自動支払区分(0:通常支払,　1:自動支払)</param>
        /// <param name="draftDrawingDate">手形振出日(YYYYMMDD)</param>
        /// <param name="draftKind">手形種類</param>
        /// <param name="draftKindName">手形種類名称(約束、為替、小切手)</param>
        /// <param name="draftDivide">手形区分</param>
        /// <param name="draftDivideName">手形区分名称(自振、廻し)</param>
        /// <param name="draftNo">手形番号</param>
        /// <param name="debitNoteLinkPayNo">赤黒支払連結番号</param>
        /// <param name="paymentAgentCode">支払担当者コード</param>
        /// <param name="paymentAgentName">支払担当者名称</param>
        /// <param name="paymentInputAgentCd">支払入力者コード</param>
        /// <param name="paymentInputAgentNm">支払入力者名称</param>
        /// <param name="outline">伝票摘要(車販の場合、摘要+注文書№+管理番号を格納)</param>
        /// <param name="bankCode">銀行コード(郵便局：9900)</param>
        /// <param name="bankName">銀行名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="paymentRowNoDtl">支払行番号</param>
        /// <param name="moneyKindCodeDtl">金種コード</param>
        /// <param name="moneyKindNameDtl">金種名称</param>
        /// <param name="moneyKindDivDtl">金種区分</param>
        /// <param name="paymentDtl">支払金額</param>
        /// <param name="validityTermDtl">有効金額</param>
        /// <param name="cAddUpUpdDate">最終計上締日</param>
        /// <param name="inputDay">入力日</param>
        /// <returns>SearchPaymentSlpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPaymentSlpクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchPaymentSlp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 debitNoteDiv, Int32 paymentSlipNo, Int32 supplierFormal, Int32 supplierSlipNo, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, string paymentInpSectionCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, DateTime paymentDate, DateTime addUpADate, Int64 paymentTotal, Int64 payment, Int64 feePayment, Int64 discountPayment, Int32 autoPayment, DateTime draftDrawingDate, Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, string draftNo, Int32 debitNoteLinkPayNo, string paymentAgentCode, string paymentAgentName, string paymentInputAgentCd, string paymentInputAgentNm, string outline, Int32 bankCode, string bankName, string enterpriseName, string updEmployeeName, string addUpSecName, Int32[] paymentRowNoDtl, Int32[] moneyKindCodeDtl, String[] moneyKindNameDtl, Int32[] moneyKindDivDtl, Int64[] paymentDtl, DateTime[] validityTermDtl, int cAddUpUpdDate, DateTime inputDay)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._debitNoteDiv = debitNoteDiv;
            this._paymentSlipNo = paymentSlipNo;
            this._supplierFormal = supplierFormal;
            this._supplierSlipNo = supplierSlipNo;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._supplierSnm = supplierSnm;
            this._payeeCode = payeeCode;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._payeeSnm = payeeSnm;
            this._paymentInpSectionCd = paymentInpSectionCd;
            this._addUpSecCode = addUpSecCode;
            this._updateSecCd = updateSecCd;
            this._subSectionCode = subSectionCode;
            this.PaymentDate = paymentDate;
            this.AddUpADate = addUpADate;
            this._paymentTotal = paymentTotal;
            this._payment = payment;
            this._feePayment = feePayment;
            this._discountPayment = discountPayment;
            this._autoPayment = autoPayment;
            this.DraftDrawingDate = draftDrawingDate;
            this._draftKind = draftKind;
            this._draftKindName = draftKindName;
            this._draftDivide = draftDivide;
            this._draftDivideName = draftDivideName;
            this._draftNo = draftNo;
            this._debitNoteLinkPayNo = debitNoteLinkPayNo;
            this._paymentAgentCode = paymentAgentCode;
            this._paymentAgentName = paymentAgentName;
            this._paymentInputAgentCd = paymentInputAgentCd;
            this._paymentInputAgentNm = paymentInputAgentNm;
            this._outline = outline;
            this._bankCode = bankCode;
            this._bankName = bankName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                this._paymentRowNoDtl[index] = paymentRowNoDtl[index];
                this._moneyKindCodeDtl[index] = moneyKindCodeDtl[index];
                this._moneyKindNameDtl[index] = moneyKindNameDtl[index];
                this._moneyKindDivDtl[index] = moneyKindDivDtl[index];
                this._paymentDtl[index] = paymentDtl[index];
                this._validityTermDtl[index] = validityTermDtl[index];
            }
            this._cAddUpUpdDate = cAddUpUpdDate;
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
            this._inputDay = inputDay;
        }

        /// <summary>
        /// 支払伝票マスタ複製処理
        /// </summary>
        /// <returns>SearchPaymentSlpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSearchPaymentSlpクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchPaymentSlp Clone()
        {
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //return new SearchPaymentSlp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._debitNoteDiv, this._paymentSlipNo, this._supplierFormal, this._supplierSlipNo, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._paymentInpSectionCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._paymentDate, this._addUpADate, this._paymentTotal, this._payment, this._feePayment, this._discountPayment, this._autoPayment, this._draftDrawingDate, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._debitNoteLinkPayNo, this._paymentAgentCode, this._paymentAgentName, this._paymentInputAgentCd, this._paymentInputAgentNm, this._outline, this._bankCode, this._bankName, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            return new SearchPaymentSlp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._debitNoteDiv, this._paymentSlipNo, this._supplierFormal, this._supplierSlipNo, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._paymentInpSectionCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._paymentDate, this._addUpADate, this._paymentTotal, this._payment, this._feePayment, this._discountPayment, this._autoPayment, this._draftDrawingDate, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._debitNoteLinkPayNo, this._paymentAgentCode, this._paymentAgentName, this._paymentInputAgentCd, this._paymentInputAgentNm, this._outline, this._bankCode, this._bankName, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._paymentRowNoDtl, this._moneyKindCodeDtl, this._moneyKindNameDtl, this._moneyKindDivDtl, this._paymentDtl, this._validityTermDtl, this._cAddUpUpdDate, this._inputDay);
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        }

        /// <summary>
        /// 支払伝票マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchPaymentSlpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPaymentSlpクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SearchPaymentSlp target)
        {
            if (this.CreateDateTime != target.CreateDateTime) { return (false); }
            if (this.UpdateDateTime != target.UpdateDateTime) { return (false); }
            if (this.EnterpriseCode.Trim() != target.EnterpriseCode.Trim()) { return (false); }
            if (this.FileHeaderGuid != target.FileHeaderGuid) { return (false); }
            if (this.UpdEmployeeCode.Trim() != target.UpdEmployeeCode.Trim()) { return (false); }
            if (this.UpdAssemblyId1.Trim() != target.UpdAssemblyId1.Trim()) { return (false); }
            if (this.UpdAssemblyId2.Trim() != target.UpdAssemblyId2.Trim()) { return (false); }
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) { return (false); }
            if (this.DebitNoteDiv != target.DebitNoteDiv) { return (false); }
            if (this.PaymentSlipNo != target.PaymentSlipNo) { return (false); }
            if (this.SupplierFormal != target.SupplierFormal) { return (false); }
            if (this.SupplierSlipNo != target.SupplierSlipNo) { return (false); }
            if (this.SupplierCd != target.SupplierCd) { return (false); }
            if (this.SupplierNm1.Trim() != target.SupplierNm1.Trim()) { return (false); }
            if (this.SupplierNm2.Trim() != target.SupplierNm2.Trim()) { return (false); }
            if (this.SupplierSnm.Trim() != target.SupplierSnm.Trim()) { return (false); }
            if (this.PayeeCode != target.PayeeCode) { return (false); }
            if (this.PayeeName.Trim() != target.PayeeName.Trim()) { return (false); }
            if (this.PayeeName2.Trim() != target.PayeeName2.Trim()) { return (false); }
            if (this.PayeeSnm.Trim() != target.PayeeSnm.Trim()) { return (false); }
            if (this.PaymentInpSectionCd.Trim() != target.PaymentInpSectionCd.Trim()) { return (false); }
            if (this.AddUpSecCode.Trim() != target.AddUpSecCode.Trim()) { return (false); }
            if (this.UpdateSecCd.Trim() != target.UpdateSecCd.Trim()) { return (false); }
            if (this.SubSectionCode != target.SubSectionCode) { return (false); }
            if (this.PaymentDate != target.PaymentDate) { return (false); }
            if (this.AddUpADate != target.AddUpADate) { return (false); }
            if (this.PaymentTotal != target.PaymentTotal) { return (false); }
            if (this.Payment != target.Payment) { return (false); }
            if (this.FeePayment != target.FeePayment) { return (false); }
            if (this.DiscountPayment != target.DiscountPayment) { return (false); }
            if (this.AutoPayment != target.AutoPayment) { return (false); }
            if (this.DraftDrawingDate != target.DraftDrawingDate) { return (false); }
            if (this.DraftKind != target.DraftKind) { return (false); }
            if (this.DraftKindName.Trim() != target.DraftKindName.Trim()) { return (false); }
            if (this.DraftDivide != target.DraftDivide) { return (false); }
            if (this.DraftDivideName.Trim() != target.DraftDivideName.Trim()) { return (false); }
            if (this.DraftNo.Trim() != target.DraftNo.Trim()) { return (false); }
            if (this.DebitNoteLinkPayNo != target.DebitNoteLinkPayNo) { return (false); }
            if (this.PaymentAgentCode.Trim() != target.PaymentAgentCode.Trim()) { return (false); }
            if (this.PaymentAgentName.Trim() != target.PaymentAgentName.Trim()) { return (false); }
            if (this.PaymentInputAgentCd.Trim() != target.PaymentInputAgentCd.Trim()) { return (false); }
            if (this.PaymentInputAgentNm.Trim() != target.PaymentInputAgentNm.Trim()) { return (false); }
            if (this.Outline.Trim() != target.Outline.Trim()) { return (false); }
            if (this.BankCode != target.BankCode) { return (false); }
            if (this.BankName.Trim() != target.BankName.Trim()) { return (false); }
            if (this.EnterpriseName.Trim() != target.EnterpriseName.Trim()) { return (false); }
            if (this.UpdEmployeeName.Trim() != target.UpdEmployeeName.Trim()) { return (false); }
            if (this.AddUpSecName.Trim() != target.AddUpSecName.Trim()) { return (false); }
            if (this.CAddUpUpdDate != target.CAddUpUpdDate) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (this.PaymentRowNoDtl[index] != target.PaymentRowNoDtl[index]) { return (false); }
                if (this.MoneyKindCodeDtl[index] != target.MoneyKindCodeDtl[index]) { return (false); }
                if (this.MoneyKindNameDtl[index].Trim() != target.MoneyKindNameDtl[index].Trim()) { return (false); }
                if (this.MoneyKindDivDtl[index] != target.MoneyKindDivDtl[index]) { return (false); }
                if (this.PaymentDtl[index] != target.PaymentDtl[index]) { return (false); }
                if (this.ValidityTermDtl[index] != target.ValidityTermDtl[index]) { return (false); }
            }
            if (this.InputDay != target.InputDay) { return (false); }

            return (true);
        }

        /// <summary>
        /// 支払伝票マスタ比較処理
        /// </summary>
        /// <param name="SearchPaymentSlp1">
        ///                    比較するSearchPaymentSlpクラスのインスタンス
        /// </param>
        /// <param name="SearchPaymentSlp2">比較するSearchPaymentSlpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPaymentSlpクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SearchPaymentSlp searchPaymentSlp1, SearchPaymentSlp searchPaymentSlp2)
        {
            if (searchPaymentSlp1.CreateDateTime != searchPaymentSlp2.CreateDateTime) { return (false); }
            if (searchPaymentSlp1.UpdateDateTime != searchPaymentSlp2.UpdateDateTime) { return (false); }
            if (searchPaymentSlp1.EnterpriseCode.Trim() != searchPaymentSlp2.EnterpriseCode.Trim()) { return (false); }
            if (searchPaymentSlp1.FileHeaderGuid != searchPaymentSlp2.FileHeaderGuid) { return (false); }
            if (searchPaymentSlp1.UpdEmployeeCode.Trim() != searchPaymentSlp2.UpdEmployeeCode.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdAssemblyId1.Trim() != searchPaymentSlp2.UpdAssemblyId1.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdAssemblyId2.Trim() != searchPaymentSlp2.UpdAssemblyId2.Trim()) { return (false); }
            if (searchPaymentSlp1.LogicalDeleteCode != searchPaymentSlp2.LogicalDeleteCode) { return (false); }
            if (searchPaymentSlp1.DebitNoteDiv != searchPaymentSlp2.DebitNoteDiv) { return (false); }
            if (searchPaymentSlp1.PaymentSlipNo != searchPaymentSlp2.PaymentSlipNo) { return (false); }
            if (searchPaymentSlp1.SupplierFormal != searchPaymentSlp2.SupplierFormal) { return (false); }
            if (searchPaymentSlp1.SupplierSlipNo != searchPaymentSlp2.SupplierSlipNo) { return (false); }
            if (searchPaymentSlp1.SupplierCd != searchPaymentSlp2.SupplierCd) { return (false); }
            if (searchPaymentSlp1.SupplierNm1.Trim() != searchPaymentSlp2.SupplierNm1.Trim()) { return (false); }
            if (searchPaymentSlp1.SupplierNm2.Trim() != searchPaymentSlp2.SupplierNm2.Trim()) { return (false); }
            if (searchPaymentSlp1.SupplierSnm.Trim() != searchPaymentSlp2.SupplierSnm.Trim()) { return (false); }
            if (searchPaymentSlp1.PayeeCode != searchPaymentSlp2.PayeeCode) { return (false); }
            if (searchPaymentSlp1.PayeeName.Trim() != searchPaymentSlp2.PayeeName.Trim()) { return (false); }
            if (searchPaymentSlp1.PayeeName2.Trim() != searchPaymentSlp2.PayeeName2.Trim()) { return (false); }
            if (searchPaymentSlp1.PayeeSnm.Trim() != searchPaymentSlp2.PayeeSnm.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentInpSectionCd.Trim() != searchPaymentSlp2.PaymentInpSectionCd.Trim()) { return (false); }
            if (searchPaymentSlp1.AddUpSecCode.Trim() != searchPaymentSlp2.AddUpSecCode.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdateSecCd.Trim() != searchPaymentSlp2.UpdateSecCd.Trim()) { return (false); }
            if (searchPaymentSlp1.SubSectionCode != searchPaymentSlp2.SubSectionCode) { return (false); }
            if (searchPaymentSlp1.PaymentDate != searchPaymentSlp2.PaymentDate) { return (false); }
            if (searchPaymentSlp1.AddUpADate != searchPaymentSlp2.AddUpADate) { return (false); }
            if (searchPaymentSlp1.PaymentTotal != searchPaymentSlp2.PaymentTotal) { return (false); }
            if (searchPaymentSlp1.Payment != searchPaymentSlp2.Payment) { return (false); }
            if (searchPaymentSlp1.FeePayment != searchPaymentSlp2.FeePayment) { return (false); }
            if (searchPaymentSlp1.DiscountPayment != searchPaymentSlp2.DiscountPayment) { return (false); }
            if (searchPaymentSlp1.AutoPayment != searchPaymentSlp2.AutoPayment) { return (false); }
            if (searchPaymentSlp1.DraftDrawingDate != searchPaymentSlp2.DraftDrawingDate) { return (false); }
            if (searchPaymentSlp1.DraftKind != searchPaymentSlp2.DraftKind) { return (false); }
            if (searchPaymentSlp1.DraftKindName.Trim() != searchPaymentSlp2.DraftKindName.Trim()) { return (false); }
            if (searchPaymentSlp1.DraftDivide != searchPaymentSlp2.DraftDivide) { return (false); }
            if (searchPaymentSlp1.DraftDivideName.Trim() != searchPaymentSlp2.DraftDivideName.Trim()) { return (false); }
            if (searchPaymentSlp1.DraftNo.Trim() != searchPaymentSlp2.DraftNo.Trim()) { return (false); }
            if (searchPaymentSlp1.DebitNoteLinkPayNo != searchPaymentSlp2.DebitNoteLinkPayNo) { return (false); }
            if (searchPaymentSlp1.PaymentAgentCode.Trim() != searchPaymentSlp2.PaymentAgentCode.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentAgentName.Trim() != searchPaymentSlp2.PaymentAgentName.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentInputAgentCd.Trim() != searchPaymentSlp2.PaymentInputAgentCd.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentInputAgentNm.Trim() != searchPaymentSlp2.PaymentInputAgentNm.Trim()) { return (false); }
            if (searchPaymentSlp1.Outline.Trim() != searchPaymentSlp2.Outline.Trim()) { return (false); }
            if (searchPaymentSlp1.BankCode != searchPaymentSlp2.BankCode) { return (false); }
            if (searchPaymentSlp1.BankName.Trim() != searchPaymentSlp2.BankName.Trim()) { return (false); }
            if (searchPaymentSlp1.EnterpriseName.Trim() != searchPaymentSlp2.EnterpriseName.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdEmployeeName.Trim() != searchPaymentSlp2.UpdEmployeeName.Trim()) { return (false); }
            if (searchPaymentSlp1.AddUpSecName.Trim() != searchPaymentSlp2.AddUpSecName.Trim()) { return (false); }
            if (searchPaymentSlp1.CAddUpUpdDate != searchPaymentSlp2.CAddUpUpdDate) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (searchPaymentSlp1.PaymentRowNoDtl[index] != searchPaymentSlp2.PaymentRowNoDtl[index]) { return (false); }
                if (searchPaymentSlp1.MoneyKindCodeDtl[index] != searchPaymentSlp2.MoneyKindCodeDtl[index]) { return (false); }
                if (searchPaymentSlp1.MoneyKindNameDtl[index].Trim() != searchPaymentSlp2.MoneyKindNameDtl[index].Trim()) { return (false); }
                if (searchPaymentSlp1.MoneyKindDivDtl[index] != searchPaymentSlp2.MoneyKindDivDtl[index]) { return (false); }
                if (searchPaymentSlp1.PaymentDtl[index] != searchPaymentSlp2.PaymentDtl[index]) { return (false); }
                if (searchPaymentSlp1.ValidityTermDtl[index] != searchPaymentSlp2.ValidityTermDtl[index]) { return (false); }
            }
            if (searchPaymentSlp1.InputDay != searchPaymentSlp2.InputDay) { return (false); }

            return (true);
        }
        /// <summary>
        /// 支払伝票マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchPaymentSlpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPaymentSlpクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SearchPaymentSlp target)
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
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.PaymentSlipNo != target.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.PaymentInpSectionCd != target.PaymentInpSectionCd) resList.Add("PaymentInpSectionCd");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.PaymentDate != target.PaymentDate) resList.Add("PaymentDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.PaymentTotal != target.PaymentTotal) resList.Add("PaymentTotal");
            if (this.Payment != target.Payment) resList.Add("Payment");
            if (this.FeePayment != target.FeePayment) resList.Add("FeePayment");
            if (this.DiscountPayment != target.DiscountPayment) resList.Add("DiscountPayment");
            if (this.AutoPayment != target.AutoPayment) resList.Add("AutoPayment");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.DraftKind != target.DraftKind) resList.Add("DraftKind");
            if (this.DraftKindName != target.DraftKindName) resList.Add("DraftKindName");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.DraftDivideName != target.DraftDivideName) resList.Add("DraftDivideName");
            if (this.DraftNo != target.DraftNo) resList.Add("DraftNo");
            if (this.DebitNoteLinkPayNo != target.DebitNoteLinkPayNo) resList.Add("DebitNoteLinkPayNo");
            if (this.PaymentAgentCode != target.PaymentAgentCode) resList.Add("PaymentAgentCode");
            if (this.PaymentAgentName != target.PaymentAgentName) resList.Add("PaymentAgentName");
            if (this.PaymentInputAgentCd != target.PaymentInputAgentCd) resList.Add("PaymentInputAgentCd");
            if (this.PaymentInputAgentNm != target.PaymentInputAgentNm) resList.Add("PaymentInputAgentNm");
            if (this.Outline != target.Outline) resList.Add("Outline");
            if (this.BankCode != target.BankCode) resList.Add("BankCode");
            if (this.BankName != target.BankName) resList.Add("BankName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (this.PaymentRowNoDtl[index] != target.PaymentRowNoDtl[index]) resList.Add("PaymentRowNoDtl");
                if (this.MoneyKindCodeDtl[index] != target.MoneyKindCodeDtl[index]) resList.Add("MoneyKindCodeDtl");
                if (this.MoneyKindNameDtl[index].Trim() != target.MoneyKindNameDtl[index].Trim()) resList.Add("MoneyKindNameDtl");
                if (this.MoneyKindDivDtl[index] != target.MoneyKindDivDtl[index]) resList.Add("MoneyKindDivDtl");
                if (this.PaymentDtl[index] != target.PaymentDtl[index]) resList.Add("PaymentDtl");
                if (this.ValidityTermDtl[index] != target.ValidityTermDtl[index]) resList.Add("ValidityTermDtl");
            }
            if (this.CAddUpUpdDate != target.CAddUpUpdDate) resList.Add("CAddUpUpdDate");
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (this.InputDay != target.InputDay) resList.Add("InputDay");

            return resList;
        }

        /// <summary>
        /// 支払伝票マスタ比較処理
        /// </summary>
        /// <param name="searchPaymentSlp1">比較するSearchPaymentSlpクラスのインスタンス</param>
        /// <param name="searchPaymentSlp2">比較するSearchPaymentSlpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPaymentSlpクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SearchPaymentSlp searchPaymentSlp1, SearchPaymentSlp searchPaymentSlp2)
        {
            ArrayList resList = new ArrayList();
            if (searchPaymentSlp1.CreateDateTime != searchPaymentSlp2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchPaymentSlp1.UpdateDateTime != searchPaymentSlp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchPaymentSlp1.EnterpriseCode != searchPaymentSlp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchPaymentSlp1.FileHeaderGuid != searchPaymentSlp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchPaymentSlp1.UpdEmployeeCode != searchPaymentSlp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchPaymentSlp1.UpdAssemblyId1 != searchPaymentSlp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchPaymentSlp1.UpdAssemblyId2 != searchPaymentSlp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchPaymentSlp1.LogicalDeleteCode != searchPaymentSlp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchPaymentSlp1.DebitNoteDiv != searchPaymentSlp2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (searchPaymentSlp1.PaymentSlipNo != searchPaymentSlp2.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (searchPaymentSlp1.SupplierFormal != searchPaymentSlp2.SupplierFormal) resList.Add("SupplierFormal");
            if (searchPaymentSlp1.SupplierSlipNo != searchPaymentSlp2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (searchPaymentSlp1.SupplierCd != searchPaymentSlp2.SupplierCd) resList.Add("SupplierCd");
            if (searchPaymentSlp1.SupplierNm1 != searchPaymentSlp2.SupplierNm1) resList.Add("SupplierNm1");
            if (searchPaymentSlp1.SupplierNm2 != searchPaymentSlp2.SupplierNm2) resList.Add("SupplierNm2");
            if (searchPaymentSlp1.SupplierSnm != searchPaymentSlp2.SupplierSnm) resList.Add("SupplierSnm");
            if (searchPaymentSlp1.PayeeCode != searchPaymentSlp2.PayeeCode) resList.Add("PayeeCode");
            if (searchPaymentSlp1.PayeeName != searchPaymentSlp2.PayeeName) resList.Add("PayeeName");
            if (searchPaymentSlp1.PayeeName2 != searchPaymentSlp2.PayeeName2) resList.Add("PayeeName2");
            if (searchPaymentSlp1.PayeeSnm != searchPaymentSlp2.PayeeSnm) resList.Add("PayeeSnm");
            if (searchPaymentSlp1.PaymentInpSectionCd != searchPaymentSlp2.PaymentInpSectionCd) resList.Add("PaymentInpSectionCd");
            if (searchPaymentSlp1.AddUpSecCode != searchPaymentSlp2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (searchPaymentSlp1.UpdateSecCd != searchPaymentSlp2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (searchPaymentSlp1.SubSectionCode != searchPaymentSlp2.SubSectionCode) resList.Add("SubSectionCode");
            if (searchPaymentSlp1.PaymentDate != searchPaymentSlp2.PaymentDate) resList.Add("PaymentDate");
            if (searchPaymentSlp1.AddUpADate != searchPaymentSlp2.AddUpADate) resList.Add("AddUpADate");
            if (searchPaymentSlp1.PaymentTotal != searchPaymentSlp2.PaymentTotal) resList.Add("PaymentTotal");
            if (searchPaymentSlp1.Payment != searchPaymentSlp2.Payment) resList.Add("Payment");
            if (searchPaymentSlp1.FeePayment != searchPaymentSlp2.FeePayment) resList.Add("FeePayment");
            if (searchPaymentSlp1.DiscountPayment != searchPaymentSlp2.DiscountPayment) resList.Add("DiscountPayment");
            if (searchPaymentSlp1.AutoPayment != searchPaymentSlp2.AutoPayment) resList.Add("AutoPayment");
            if (searchPaymentSlp1.DraftDrawingDate != searchPaymentSlp2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (searchPaymentSlp1.DraftKind != searchPaymentSlp2.DraftKind) resList.Add("DraftKind");
            if (searchPaymentSlp1.DraftKindName != searchPaymentSlp2.DraftKindName) resList.Add("DraftKindName");
            if (searchPaymentSlp1.DraftDivide != searchPaymentSlp2.DraftDivide) resList.Add("DraftDivide");
            if (searchPaymentSlp1.DraftDivideName != searchPaymentSlp2.DraftDivideName) resList.Add("DraftDivideName");
            if (searchPaymentSlp1.DraftNo != searchPaymentSlp2.DraftNo) resList.Add("DraftNo");
            if (searchPaymentSlp1.DebitNoteLinkPayNo != searchPaymentSlp2.DebitNoteLinkPayNo) resList.Add("DebitNoteLinkPayNo");
            if (searchPaymentSlp1.PaymentAgentCode != searchPaymentSlp2.PaymentAgentCode) resList.Add("PaymentAgentCode");
            if (searchPaymentSlp1.PaymentAgentName != searchPaymentSlp2.PaymentAgentName) resList.Add("PaymentAgentName");
            if (searchPaymentSlp1.PaymentInputAgentCd != searchPaymentSlp2.PaymentInputAgentCd) resList.Add("PaymentInputAgentCd");
            if (searchPaymentSlp1.PaymentInputAgentNm != searchPaymentSlp2.PaymentInputAgentNm) resList.Add("PaymentInputAgentNm");
            if (searchPaymentSlp1.Outline != searchPaymentSlp2.Outline) resList.Add("Outline");
            if (searchPaymentSlp1.BankCode != searchPaymentSlp2.BankCode) resList.Add("BankCode");
            if (searchPaymentSlp1.BankName != searchPaymentSlp2.BankName) resList.Add("BankName");
            if (searchPaymentSlp1.EnterpriseName != searchPaymentSlp2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchPaymentSlp1.UpdEmployeeName != searchPaymentSlp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchPaymentSlp1.AddUpSecName != searchPaymentSlp2.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (searchPaymentSlp1.PaymentRowNoDtl[index] != searchPaymentSlp2.PaymentRowNoDtl[index]) resList.Add("PaymentRowNoDtl");
                if (searchPaymentSlp1.MoneyKindCodeDtl[index] != searchPaymentSlp2.MoneyKindCodeDtl[index]) resList.Add("MoneyKindCodeDtl");
                if (searchPaymentSlp1.MoneyKindNameDtl[index].Trim() != searchPaymentSlp2.MoneyKindNameDtl[index].Trim()) resList.Add("MoneyKindNameDtl");
                if (searchPaymentSlp1.MoneyKindDivDtl[index] != searchPaymentSlp2.MoneyKindDivDtl[index]) resList.Add("MoneyKindDivDtl");
                if (searchPaymentSlp1.PaymentDtl[index] != searchPaymentSlp2.PaymentDtl[index]) resList.Add("PaymentDtl");
                if (searchPaymentSlp1.ValidityTermDtl[index] != searchPaymentSlp2.ValidityTermDtl[index]) resList.Add("ValidityTermDtl");
            }
            if (searchPaymentSlp1.CAddUpUpdDate != searchPaymentSlp2.CAddUpUpdDate) resList.Add("CAddUpUpdDate");
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (searchPaymentSlp1.InputDay != searchPaymentSlp2.InputDay) resList.Add("InputDay");

            return resList;
        }
    }
}
