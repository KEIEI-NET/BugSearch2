using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchDepositAlw
    /// <summary>
    ///                      入金引当検索データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金引当検索データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/10/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/06/26 30414 忍 幸史 Partsman用に変更</br>
    /// </remarks>
    public class SearchDepositAlw
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

        /// <summary>入金入力拠点コード</summary>
        /// <remarks>入金入力した拠点コード</remarks>
        private string _inputDepositSecCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>消込み日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _reconcileDate;

        /// <summary>消込み計上日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _reconcileAddUpDate;

        /// <summary>入金伝票番号</summary>
        private Int32 _depositSlipNo;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>入金金種コード</summary>
        private Int32 _depositKindCode;

        /// <summary>入金金種名称</summary>
        private string _depositKindName = "";
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>入金引当額</summary>
        private Int64 _depositAllowance;

        /// <summary>入金担当者コード</summary>
        private string _depositAgentCode = "";

        /// <summary>入金担当者名称</summary>
        private string _depositAgentNm = "";

        /// <summary>請求先コード</summary>
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

        /// <summary>赤伝相殺区分</summary>
        /// <remarks>0:黒,1:赤,2:相殺済み黒</remarks>
        private Int32 _debitNoteOffSetCd;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>預り金区分</summary>
        /// <remarks>0:通常入金,1:預り金入金</remarks>
        private Int32 _depositCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  InputDepositSecCd
        /// <summary>入金入力拠点コードプロパティ</summary>
        /// <value>入金入力した拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDepositSecCd
        {
            get { return _inputDepositSecCd; }
            set { _inputDepositSecCd = value; }
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  ReconcileDate
        /// <summary>消込み日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ReconcileDate
        {
            get { return _reconcileDate; }
            set { _reconcileDate = value; }
        }

        /// public propaty name  :  ReconcileDateJpFormal
        /// <summary>消込み日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileDateJpInFormal
        /// <summary>消込み日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileDateAdFormal
        /// <summary>消込み日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileDateAdInFormal
        /// <summary>消込み日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDate
        /// <summary>消込み計上日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ReconcileAddUpDate
        {
            get { return _reconcileAddUpDate; }
            set { _reconcileAddUpDate = value; }
        }

        /// public propaty name  :  ReconcileAddUpDateJpFormal
        /// <summary>消込み計上日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み計上日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileAddUpDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDateJpInFormal
        /// <summary>消込み計上日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み計上日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileAddUpDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDateAdFormal
        /// <summary>消込み計上日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み計上日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileAddUpDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDateAdInFormal
        /// <summary>消込み計上日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込み計上日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReconcileAddUpDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  DepositSlipNo
        /// <summary>入金伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositSlipNo
        {
            get { return _depositSlipNo; }
            set { _depositSlipNo = value; }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DepositKindCode
        /// <summary>入金金種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositKindCode
        {
            get { return _depositKindCode; }
            set { _depositKindCode = value; }
        }

        /// public propaty name  :  DepositKindName
        /// <summary>入金金種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositKindName
        {
            get { return _depositKindName; }
            set { _depositKindName = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositAllowance
        /// <summary>入金引当額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositAllowance
        {
            get { return _depositAllowance; }
            set { _depositAllowance = value; }
        }

        /// public propaty name  :  DepositAgentCode
        /// <summary>入金担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositAgentCode
        {
            get { return _depositAgentCode; }
            set { _depositAgentCode = value; }
        }

        /// public propaty name  :  DepositAgentNm
        /// <summary>入金担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositAgentNm
        {
            get { return _depositAgentNm; }
            set { _depositAgentNm = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
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

        /// public propaty name  :  DebitNoteOffSetCd
        /// <summary>赤伝相殺区分プロパティ</summary>
        /// <value>0:黒,1:赤,2:相殺済み黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝相殺区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteOffSetCd
        {
            get { return _debitNoteOffSetCd; }
            set { _debitNoteOffSetCd = value; }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DepositCd
        /// <summary>預り金区分プロパティ</summary>
        /// <value>0:通常入金,1:預り金入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   預り金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositCd
        {
            get { return _depositCd; }
            set { _depositCd = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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
        /// 入金引当検索データコンストラクタ
        /// </summary>
        /// <returns>SearchDepositAlwクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepositAlwクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchDepositAlw()
        {
        }

        /// <summary>
        /// 入金引当検索データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inputDepositSecCd">入金入力拠点コード(入金入力した拠点コード)</param>
        /// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="reconcileDate">消込み日(YYYYMMDD)</param>
        /// <param name="reconcileAddUpDate">消込み計上日(YYYYMMDD)</param>
        /// <param name="depositSlipNo">入金伝票番号</param>
        /// <param name="depositAllowance">入金引当額</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名称</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="claimName">請求先名称</param>
        /// <param name="claimName2">請求先名称2</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="debitNoteOffSetCd">赤伝相殺区分(0:黒,1:赤,2:相殺済み黒)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <returns>SearchDepositAlwクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepositAlwクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        //public SearchDepositAlw(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inputDepositSecCd, string addUpSecCode, Int32 acptAnOdrStatus, string salesSlipNum, DateTime reconcileDate, DateTime reconcileAddUpDate, Int32 depositSlipNo, Int32 depositKindCode, string depositKindName, Int64 depositAllowance, string depositAgentCode, string depositAgentNm, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 debitNoteOffSetCd, Int32 depositCd, string enterpriseName, string updEmployeeName, string addUpSecName)
        public SearchDepositAlw(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inputDepositSecCd, string addUpSecCode, Int32 acptAnOdrStatus, string salesSlipNum, DateTime reconcileDate, DateTime reconcileAddUpDate, Int32 depositSlipNo, Int64 depositAllowance, string depositAgentCode, string depositAgentNm, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 debitNoteOffSetCd, string enterpriseName, string updEmployeeName, string addUpSecName)
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inputDepositSecCd = inputDepositSecCd;
            this._addUpSecCode = addUpSecCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this.ReconcileDate = reconcileDate;
            this.ReconcileAddUpDate = reconcileAddUpDate;
            this._depositSlipNo = depositSlipNo;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositKindCode = depositKindCode;
            this._depositKindName = depositKindName;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._depositAllowance = depositAllowance;
            this._depositAgentCode = depositAgentCode;
            this._depositAgentNm = depositAgentNm;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._debitNoteOffSetCd = debitNoteOffSetCd;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositCd = depositCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// 入金引当検索データ複製処理
        /// </summary>
        /// <returns>SearchDepositAlwクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSearchDepositAlwクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchDepositAlw Clone()
        {
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //return new SearchDepositAlw(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inputDepositSecCd, this._addUpSecCode, this._acptAnOdrStatus, this._salesSlipNum, this._reconcileDate, this._reconcileAddUpDate, this._depositSlipNo, this._depositKindCode, this._depositKindName, this._depositAllowance, this._depositAgentCode, this._depositAgentNm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._debitNoteOffSetCd, this._depositCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            return new SearchDepositAlw(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inputDepositSecCd, this._addUpSecCode, this._acptAnOdrStatus, this._salesSlipNum, this._reconcileDate, this._reconcileAddUpDate, this._depositSlipNo, this._depositAllowance, this._depositAgentCode, this._depositAgentNm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._debitNoteOffSetCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 入金引当検索データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchDepositAlwクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepositAlwクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SearchDepositAlw target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InputDepositSecCd == target.InputDepositSecCd)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.ReconcileDate == target.ReconcileDate)
                 && (this.ReconcileAddUpDate == target.ReconcileAddUpDate)
                 && (this.DepositSlipNo == target.DepositSlipNo)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.DepositKindCode == target.DepositKindCode)
                && (this.DepositKindName == target.DepositKindName)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                && (this.DepositAllowance == target.DepositAllowance)
                && (this.DepositAgentCode == target.DepositAgentCode)
                && (this.DepositAgentNm == target.DepositAgentNm)
                && (this.ClaimCode == target.ClaimCode)
                && (this.ClaimName == target.ClaimName)
                && (this.ClaimName2 == target.ClaimName2)
                && (this.ClaimSnm == target.ClaimSnm)
                && (this.CustomerCode == target.CustomerCode)
                && (this.CustomerName == target.CustomerName)
                && (this.CustomerName2 == target.CustomerName2)
                && (this.CustomerSnm == target.CustomerSnm)
                && (this.DebitNoteOffSetCd == target.DebitNoteOffSetCd)
               /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
               && (this.DepositCd == target.DepositCd)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// 入金引当検索データ比較処理
        /// </summary>
        /// <param name="searchDepositAlw1">
        ///                    比較するSearchDepositAlwクラスのインスタンス
        /// </param>
        /// <param name="searchDepositAlw2">比較するSearchDepositAlwクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepositAlwクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SearchDepositAlw searchDepositAlw1, SearchDepositAlw searchDepositAlw2)
        {
            return ((searchDepositAlw1.CreateDateTime == searchDepositAlw2.CreateDateTime)
                 && (searchDepositAlw1.UpdateDateTime == searchDepositAlw2.UpdateDateTime)
                 && (searchDepositAlw1.EnterpriseCode == searchDepositAlw2.EnterpriseCode)
                 && (searchDepositAlw1.FileHeaderGuid == searchDepositAlw2.FileHeaderGuid)
                 && (searchDepositAlw1.UpdEmployeeCode == searchDepositAlw2.UpdEmployeeCode)
                 && (searchDepositAlw1.UpdAssemblyId1 == searchDepositAlw2.UpdAssemblyId1)
                 && (searchDepositAlw1.UpdAssemblyId2 == searchDepositAlw2.UpdAssemblyId2)
                 && (searchDepositAlw1.LogicalDeleteCode == searchDepositAlw2.LogicalDeleteCode)
                 && (searchDepositAlw1.InputDepositSecCd == searchDepositAlw2.InputDepositSecCd)
                 && (searchDepositAlw1.AddUpSecCode == searchDepositAlw2.AddUpSecCode)
                 && (searchDepositAlw1.AcptAnOdrStatus == searchDepositAlw2.AcptAnOdrStatus)
                 && (searchDepositAlw1.SalesSlipNum == searchDepositAlw2.SalesSlipNum)
                 && (searchDepositAlw1.ReconcileDate == searchDepositAlw2.ReconcileDate)
                 && (searchDepositAlw1.ReconcileAddUpDate == searchDepositAlw2.ReconcileAddUpDate)
                 && (searchDepositAlw1.DepositSlipNo == searchDepositAlw2.DepositSlipNo)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchDepositAlw1.DepositKindCode == searchDepositAlw2.DepositKindCode)
                && (searchDepositAlw1.DepositKindName == searchDepositAlw2.DepositKindName)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                && (searchDepositAlw1.DepositAllowance == searchDepositAlw2.DepositAllowance)
                && (searchDepositAlw1.DepositAgentCode == searchDepositAlw2.DepositAgentCode)
                && (searchDepositAlw1.DepositAgentNm == searchDepositAlw2.DepositAgentNm)
                && (searchDepositAlw1.ClaimCode == searchDepositAlw2.ClaimCode)
                && (searchDepositAlw1.ClaimName == searchDepositAlw2.ClaimName)
                && (searchDepositAlw1.ClaimName2 == searchDepositAlw2.ClaimName2)
                && (searchDepositAlw1.ClaimSnm == searchDepositAlw2.ClaimSnm)
                && (searchDepositAlw1.CustomerCode == searchDepositAlw2.CustomerCode)
                && (searchDepositAlw1.CustomerName == searchDepositAlw2.CustomerName)
                && (searchDepositAlw1.CustomerName2 == searchDepositAlw2.CustomerName2)
                && (searchDepositAlw1.CustomerSnm == searchDepositAlw2.CustomerSnm)
                && (searchDepositAlw1.DebitNoteOffSetCd == searchDepositAlw2.DebitNoteOffSetCd)
               /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
               && (searchDepositAlw1.DepositCd == searchDepositAlw2.DepositCd)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchDepositAlw1.EnterpriseName == searchDepositAlw2.EnterpriseName)
                 && (searchDepositAlw1.UpdEmployeeName == searchDepositAlw2.UpdEmployeeName)
                 && (searchDepositAlw1.AddUpSecName == searchDepositAlw2.AddUpSecName));
        }
        /// <summary>
        /// 入金引当検索データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchDepositAlwクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepositAlwクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SearchDepositAlw target)
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
            if (this.InputDepositSecCd != target.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.ReconcileDate != target.ReconcileDate) resList.Add("ReconcileDate");
            if (this.ReconcileAddUpDate != target.ReconcileAddUpDate) resList.Add("ReconcileAddUpDate");
            if (this.DepositSlipNo != target.DepositSlipNo) resList.Add("DepositSlipNo");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositKindCode != target.DepositKindCode) resList.Add("DepositKindCode");
            if (this.DepositKindName != target.DepositKindName) resList.Add("DepositKindName");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DepositAllowance != target.DepositAllowance) resList.Add("DepositAllowance");
            if (this.DepositAgentCode != target.DepositAgentCode) resList.Add("DepositAgentCode");
            if (this.DepositAgentNm != target.DepositAgentNm) resList.Add("DepositAgentNm");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.DebitNoteOffSetCd != target.DebitNoteOffSetCd) resList.Add("DebitNoteOffSetCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositCd != target.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// 入金引当検索データ比較処理
        /// </summary>
        /// <param name="searchDepositAlw1">比較するSearchDepositAlwクラスのインスタンス</param>
        /// <param name="searchDepositAlw2">比較するSearchDepositAlwクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepositAlwクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SearchDepositAlw searchDepositAlw1, SearchDepositAlw searchDepositAlw2)
        {
            ArrayList resList = new ArrayList();
            if (searchDepositAlw1.CreateDateTime != searchDepositAlw2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchDepositAlw1.UpdateDateTime != searchDepositAlw2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchDepositAlw1.EnterpriseCode != searchDepositAlw2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchDepositAlw1.FileHeaderGuid != searchDepositAlw2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchDepositAlw1.UpdEmployeeCode != searchDepositAlw2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchDepositAlw1.UpdAssemblyId1 != searchDepositAlw2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchDepositAlw1.UpdAssemblyId2 != searchDepositAlw2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchDepositAlw1.LogicalDeleteCode != searchDepositAlw2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchDepositAlw1.InputDepositSecCd != searchDepositAlw2.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (searchDepositAlw1.AddUpSecCode != searchDepositAlw2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (searchDepositAlw1.AcptAnOdrStatus != searchDepositAlw2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (searchDepositAlw1.SalesSlipNum != searchDepositAlw2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (searchDepositAlw1.ReconcileDate != searchDepositAlw2.ReconcileDate) resList.Add("ReconcileDate");
            if (searchDepositAlw1.ReconcileAddUpDate != searchDepositAlw2.ReconcileAddUpDate) resList.Add("ReconcileAddUpDate");
            if (searchDepositAlw1.DepositSlipNo != searchDepositAlw2.DepositSlipNo) resList.Add("DepositSlipNo");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepositAlw1.DepositKindCode != searchDepositAlw2.DepositKindCode) resList.Add("DepositKindCode");
            if (searchDepositAlw1.DepositKindName != searchDepositAlw2.DepositKindName) resList.Add("DepositKindName");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepositAlw1.DepositAllowance != searchDepositAlw2.DepositAllowance) resList.Add("DepositAllowance");
            if (searchDepositAlw1.DepositAgentCode != searchDepositAlw2.DepositAgentCode) resList.Add("DepositAgentCode");
            if (searchDepositAlw1.DepositAgentNm != searchDepositAlw2.DepositAgentNm) resList.Add("DepositAgentNm");
            if (searchDepositAlw1.ClaimCode != searchDepositAlw2.ClaimCode) resList.Add("ClaimCode");
            if (searchDepositAlw1.ClaimName != searchDepositAlw2.ClaimName) resList.Add("ClaimName");
            if (searchDepositAlw1.ClaimName2 != searchDepositAlw2.ClaimName2) resList.Add("ClaimName2");
            if (searchDepositAlw1.ClaimSnm != searchDepositAlw2.ClaimSnm) resList.Add("ClaimSnm");
            if (searchDepositAlw1.CustomerCode != searchDepositAlw2.CustomerCode) resList.Add("CustomerCode");
            if (searchDepositAlw1.CustomerName != searchDepositAlw2.CustomerName) resList.Add("CustomerName");
            if (searchDepositAlw1.CustomerName2 != searchDepositAlw2.CustomerName2) resList.Add("CustomerName2");
            if (searchDepositAlw1.CustomerSnm != searchDepositAlw2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchDepositAlw1.DebitNoteOffSetCd != searchDepositAlw2.DebitNoteOffSetCd) resList.Add("DebitNoteOffSetCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepositAlw1.DepositCd != searchDepositAlw2.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepositAlw1.EnterpriseName != searchDepositAlw2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchDepositAlw1.UpdEmployeeName != searchDepositAlw2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchDepositAlw1.AddUpSecName != searchDepositAlw2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}