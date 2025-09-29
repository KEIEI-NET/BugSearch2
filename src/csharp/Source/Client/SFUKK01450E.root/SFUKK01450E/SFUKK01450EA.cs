using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SearchDepsitMain
	/// <summary>
	///                      入金検索データクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   入金検索データクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   木村 武正</br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007.10.05 20081 疋田 勇人 入金マスタのレイアウト変更による修正 DC.NS用に変更</br>
    /// <br>Update Note      :   2008/06/26 30414 忍 幸史 入金マスタのレイアウト変更による修正 Partsman用に変更</br>
	/// </remarks>
    public class SearchDepsitMain
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

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>入金赤黒区分</summary>
        /// <remarks>0:黒,1:赤,2:相殺済み黒</remarks>
        private Int32 _depositDebitNoteCd;

        /// <summary>入金伝票番号</summary>
        private Int32 _depositSlipNo;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>入金入力拠点コード</summary>
        /// <remarks>入金入力した拠点コード</remarks>
        private string _inputDepositSecCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>文字型 データの登録更新拠点</remarks>
        private string _updateSecCd = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>課コード</summary>
        private Int32 _minSectionCode;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>入金金種コード</summary>
        private Int32 _depositKindCode;

        /// <summary>入金金種名称</summary>
        private string _depositKindName = "";

        /// <summary>入金金種区分</summary>
        private Int32 _depositKindDivCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>入金計</summary>
        private Int64 _depositTotal;

        /// <summary>入金金額</summary>
        /// <remarks>値引・手数料を除いた額</remarks>
        private Int64 _deposit;

        /// <summary>手数料入金額</summary>
        private Int64 _feeDeposit;

        /// <summary>値引入金額</summary>
        private Int64 _discountDeposit;

        /// <summary>自動入金区分</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _autoDepositCd;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>預り金区分</summary>
        /// <remarks>0:通常入金,1:預り金入金</remarks>
        private Int32 _depositCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>手形振出日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>手形支払期日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftPayTimeLimit;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// <summary>入金引当額</summary>
        private Int64 _depositAllowance;

        /// <summary>入金引当残高</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>赤黒入金連結番号</summary>
        private Int32 _debitNoteLinkDepoNo;

        /// <summary>最終消し込み計上日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastReconcileAddUpDt;

        /// <summary>入金担当者コード</summary>
        private string _depositAgentCode = "";

        /// <summary>入金担当者名称</summary>
        private string _depositAgentNm = "";

        /// <summary>入金入力者コード</summary>
        private string _depositInputAgentCd = "";

        /// <summary>入金入力者名称</summary>
        private string _depositInputAgentNm = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        /// <remarks>請求得意先名称</remarks>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        /// <remarks>請求得意先名称２</remarks>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
        private string _outline = "";

        /// <summary>銀行コード</summary>
        /// <remarks>郵便局：9900</remarks>
        private Int32 _bankCode;

        /// <summary>銀行名称</summary>
        private string _bankName = "";

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>ＥＤＩ送信日</summary>
        private Int32 _ediSendDate;

        /// <summary>ＥＤＩ取込日</summary>
        private Int32 _ediTakeInDate;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>預り金区分名称</summary>
        /// <remarks>レイアウトに手動で追加</remarks>
        private string _depositNm = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>入金行番号(1～10)</summary>
        private Int32[] _depositRowNo = new Int32[10];
        /// <summary>金種コード(1～10)</summary>
        private Int32[] _moneyKindCode = new Int32[10];
        /// <summary>金種名称(1～10)</summary>
        private String[] _moneyKindName = new String[10];
        /// <summary>金種区分(1～10)</summary>
        private Int32[] _moneyKindDiv = new Int32[10];
        /// <summary>入金金額(1～10)</summary>
        private Int64[] _depositDtl = new Int64[10];
        /// <summary>有効期限(1～10)</summary>
        private DateTime[] _validityTerm = new DateTime[10];
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  DepositDebitNoteCd
        /// <summary>入金赤黒区分プロパティ</summary>
        /// <value>0:黒,1:赤,2:相殺済み黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金赤黒区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositDebitNoteCd
        {
            get { return _depositDebitNoteCd; }
            set { _depositDebitNoteCd = value; }
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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositDate
        /// <summary>入金日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }

        /// public propaty name  :  DepositDateJpFormal
        /// <summary>入金日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateJpInFormal
        /// <summary>入金日付 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateAdFormal
        /// <summary>入金日付 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateAdInFormal
        /// <summary>入金日付 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _depositDate); }
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

        /// public propaty name  :  DepositKindDivCd
        /// <summary>入金金種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositKindDivCd
        {
            get { return _depositKindDivCd; }
            set { _depositKindDivCd = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositTotal
        /// <summary>入金計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositTotal
        {
            get { return _depositTotal; }
            set { _depositTotal = value; }
        }

        /// public propaty name  :  Deposit
        /// <summary>入金金額プロパティ</summary>
        /// <value>値引・手数料を除いた額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        /// public propaty name  :  FeeDeposit
        /// <summary>手数料入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>値引入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>自動入金区分プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DraftPayTimeLimit
        /// <summary>手形支払期日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DraftPayTimeLimit
        {
            get { return _draftPayTimeLimit; }
            set { _draftPayTimeLimit = value; }
        }

        /// public propaty name  :  DraftPayTimeLimitJpFormal
        /// <summary>手形支払期日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftPayTimeLimitJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _draftPayTimeLimit); }
            set { }
        }

        /// public propaty name  :  DraftPayTimeLimitJpInFormal
        /// <summary>手形支払期日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftPayTimeLimitJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _draftPayTimeLimit); }
            set { }
        }

        /// public propaty name  :  DraftPayTimeLimitAdFormal
        /// <summary>手形支払期日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftPayTimeLimitAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _draftPayTimeLimit); }
            set { }
        }

        /// public propaty name  :  DraftPayTimeLimitAdInFormal
        /// <summary>手形支払期日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DraftPayTimeLimitAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _draftPayTimeLimit); }
            set { }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>入金引当残高プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
        }

        /// public propaty name  :  DebitNoteLinkDepoNo
        /// <summary>赤黒入金連結番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒入金連結番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteLinkDepoNo
        {
            get { return _debitNoteLinkDepoNo; }
            set { _debitNoteLinkDepoNo = value; }
        }

        /// public propaty name  :  LastReconcileAddUpDt
        /// <summary>最終消し込み計上日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終消し込み計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastReconcileAddUpDt
        {
            get { return _lastReconcileAddUpDt; }
            set { _lastReconcileAddUpDt = value; }
        }

        /// public propaty name  :  LastReconcileAddUpDtJpFormal
        /// <summary>最終消し込み計上日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終消し込み計上日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastReconcileAddUpDtJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  LastReconcileAddUpDtJpInFormal
        /// <summary>最終消し込み計上日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終消し込み計上日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastReconcileAddUpDtJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  LastReconcileAddUpDtAdFormal
        /// <summary>最終消し込み計上日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終消し込み計上日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastReconcileAddUpDtAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  LastReconcileAddUpDtAdInFormal
        /// <summary>最終消し込み計上日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終消し込み計上日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastReconcileAddUpDtAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastReconcileAddUpDt); }
            set { }
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

        /// public propaty name  :  DepositInputAgentCd
        /// <summary>入金入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositInputAgentCd
        {
            get { return _depositInputAgentCd; }
            set { _depositInputAgentCd = value; }
        }

        /// public propaty name  :  DepositInputAgentNm
        /// <summary>入金入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositInputAgentNm
        {
            get { return _depositInputAgentNm; }
            set { _depositInputAgentNm = value; }
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

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先得意先</value>
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
        /// <value>請求得意先名称</value>
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
        /// <value>請求得意先名称２</value>
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

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  EdiSendDate
        /// <summary>ＥＤＩ送信日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdiSendDate
        {
            get { return _ediSendDate; }
            set { _ediSendDate = value; }
        }

        /// public propaty name  :  EdiTakeInDate
        /// <summary>ＥＤＩ取込日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositNm
        /// <summary>預り金区分名称プロパティ</summary>
        /// <value>レイアウトに手動で追加</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   預り金区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositNm
        {
            get { return _depositNm; }
            set { _depositNm = value; }
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

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public property name  :  DepositRowNo
        /// <summary>入金行番号(1～10)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号(1～10)プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int32[] DepositRowNo
        {
            get { return _depositRowNo; }
            set { _depositRowNo = value; }
        }
        /// public property name  :  MoneyKindCode
        /// <summary>金種コード(1～10)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード(1～10)プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int32[] MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }
        /// public property name  :  MoneyKindName
        /// <summary>金種名称(1～10)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称(1～10)プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public String[] MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }
        /// public property name  :  MoneyKindDiv
        /// <summary>金種区分(1～10)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分(1～10)プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int32[] MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
        }
        /// public property name  :  DepositDtl
        /// <summary>入金金額(1～10)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額(1～10)プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int64[] DepositDtl
        {
            get { return _depositDtl; }
            set { _depositDtl = value; }
        }
        /// public property name  :  ValidityTerm
        /// <summary>有効期限(1～10)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限(1～10)プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public DateTime[] ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

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
        /// 入金検索データクラスコンストラクタ
        /// </summary>
        /// <returns>SearchDepsitMainクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepsitMainクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchDepsitMain()
        {
        }

        /// <summary>
        /// 入金検索データクラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="depositDebitNoteCd">入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</param>
        /// <param name="depositSlipNo">入金伝票番号</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="inputDepositSecCd">入金入力拠点コード(入金入力した拠点コード)</param>
        /// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="depositDate">入金日付(YYYYMMDD)</param>
        /// <param name="addUpADate">計上日付(YYYYMMDD)</param>
        /// <param name="depositTotal">入金計</param>
        /// <param name="deposit">入金金額(値引・手数料を除いた額)</param>
        /// <param name="feeDeposit">手数料入金額</param>
        /// <param name="discountDeposit">値引入金額</param>
        /// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
        /// <param name="draftDrawingDate">手形振出日(YYYYMMDD)</param>
        /// <param name="draftKind">手形種類</param>
        /// <param name="draftKindName">手形種類名称(約束、為替、小切手)</param>
        /// <param name="draftDivide">手形区分</param>
        /// <param name="draftDivideName">手形区分名称(自振、廻し)</param>
        /// <param name="draftNo">手形番号</param>
        /// <param name="depositAllowance">入金引当額</param>
        /// <param name="depositAlwcBlnce">入金引当残高</param>
        /// <param name="debitNoteLinkDepoNo">赤黒入金連結番号</param>
        /// <param name="lastReconcileAddUpDt">最終消し込み計上日(YYYYMMDD)</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名称</param>
        /// <param name="depositInputAgentCd">入金入力者コード</param>
        /// <param name="depositInputAgentNm">入金入力者名称</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="claimCode">請求先コード(請求先得意先)</param>
        /// <param name="claimName">請求先名称(請求得意先名称)</param>
        /// <param name="claimName2">請求先名称2(請求得意先名称２)</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="outline">伝票摘要(車販の場合、摘要+注文書№+管理番号を格納)</param>
        /// <param name="bankCode">銀行コード(郵便局：9900)</param>
        /// <param name="bankName">銀行名称</param>
        /// <param name="depositNm">預り金区分名称(レイアウトに手動で追加)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="depositRowNo">入金行番号(1～10)</param>
        /// <param name="moneyKindCode">金種コード(1～10)</param>
        /// <param name="moneyKindName">金種名称(1～10)</param>
        /// <param name="moneyKindDiv">金種区分(1～10)</param>
        /// <param name="depositDtl">入金金額(1～10)</param>
        /// <param name="validityTerm">有効期限(1～10)</param>
        /// <param name="inputDay">入力日</param>
        /// <returns>SearchDepsitMainクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepsitMainクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        //public SearchDepsitMain(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, Int32 depositDebitNoteCd, Int32 depositSlipNo, string salesSlipNum, string inputDepositSecCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, Int32 minSectionCode, DateTime depositDate, DateTime addUpADate, Int32 depositKindCode, string depositKindName, Int32 depositKindDivCd, Int64 depositTotal, Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, Int32 autoDepositCd, Int32 depositCd, DateTime draftDrawingDate, DateTime draftPayTimeLimit, Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, string draftNo, Int64 depositAllowance, Int64 depositAlwcBlnce, Int32 debitNoteLinkDepoNo, DateTime lastReconcileAddUpDt, string depositAgentCode, string depositAgentNm, string depositInputAgentCd, string depositInputAgentNm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 claimCode, string claimName, string claimName2, string claimSnm, string outline, Int32 bankCode, string bankName, Int32 ediSendDate, Int32 ediTakeInDate, string depositNm, string enterpriseName, string updEmployeeName, string addUpSecName)
        public SearchDepsitMain(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, 
                                string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, 
                                Int32 acptAnOdrStatus, Int32 depositDebitNoteCd, Int32 depositSlipNo, string salesSlipNum, 
                                string inputDepositSecCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, 
                                DateTime depositDate, DateTime addUpADate, Int64 depositTotal, Int64 deposit, Int64 feeDeposit, 
                                Int64 discountDeposit, Int32 autoDepositCd, DateTime draftDrawingDate, 
                                Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, 
                                string draftNo, Int64 depositAllowance, Int64 depositAlwcBlnce, Int32 debitNoteLinkDepoNo, 
                                DateTime lastReconcileAddUpDt, string depositAgentCode, string depositAgentNm, 
                                string depositInputAgentCd, string depositInputAgentNm, Int32 customerCode, string customerName, 
                                string customerName2, string customerSnm, Int32 claimCode, string claimName, string claimName2, 
                                string claimSnm, string outline, Int32 bankCode, string bankName, string depositNm, 
                                string enterpriseName, string updEmployeeName, string addUpSecName, Int32[] depositRowNo, 
                                Int32[] moneyKindCode, string[] moneyKindName, Int32[] moneyKindDiv, Int64[] depositDtl, 
                                DateTime[] validityTerm, DateTime inputDay)
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
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._depositDebitNoteCd = depositDebitNoteCd;
            this._depositSlipNo = depositSlipNo;
            this._salesSlipNum = salesSlipNum;
            this._inputDepositSecCd = inputDepositSecCd;
            this._addUpSecCode = addUpSecCode;
            this._updateSecCd = updateSecCd;
            this._subSectionCode = subSectionCode;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._minSectionCode = minSectionCode;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this.DepositDate = depositDate;
            this.AddUpADate = addUpADate;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositKindCode = depositKindCode;
            this._depositKindName = depositKindName;
            this._depositKindDivCd = depositKindDivCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._depositTotal = depositTotal;
            this._deposit = deposit;
            this._feeDeposit = feeDeposit;
            this._discountDeposit = discountDeposit;
            this._autoDepositCd = autoDepositCd;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositCd = depositCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this.DraftDrawingDate = draftDrawingDate;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this.DraftPayTimeLimit = draftPayTimeLimit;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._draftKind = draftKind;
            this._draftKindName = draftKindName;
            this._draftDivide = draftDivide;
            this._draftDivideName = draftDivideName;
            this._draftNo = draftNo;
            this._depositAllowance = depositAllowance;
            this._depositAlwcBlnce = depositAlwcBlnce;
            this._debitNoteLinkDepoNo = debitNoteLinkDepoNo;
            this.LastReconcileAddUpDt = lastReconcileAddUpDt;
            this._depositAgentCode = depositAgentCode;
            this._depositAgentNm = depositAgentNm;
            this._depositInputAgentCd = depositInputAgentCd;
            this._depositInputAgentNm = depositInputAgentNm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._outline = outline;
            this._bankCode = bankCode;
            this._bankName = bankName;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._ediSendDate = ediSendDate;
            this._ediTakeInDate = ediTakeInDate;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._depositNm = depositNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                this._depositRowNo[index] = depositRowNo[index];
                this._moneyKindCode[index] = moneyKindCode[index];
                this._moneyKindName[index] = moneyKindName[index];
                this._moneyKindDiv[index] = moneyKindDiv[index];
                this._depositDtl[index] = depositDtl[index];
                this._validityTerm[index] = validityTerm[index];
            }
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            this._inputDay = inputDay;
        }

        /// <summary>
        /// 入金検索データクラス複製処理
        /// </summary>
        /// <returns>SearchDepsitMainクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSearchDepsitMainクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchDepsitMain Clone()
        {
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //return new SearchDepsitMain(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._depositDebitNoteCd, this._depositSlipNo, this._salesSlipNum, this._inputDepositSecCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._minSectionCode, this._depositDate, this._addUpADate, this._depositKindCode, this._depositKindName, this._depositKindDivCd, this._depositTotal, this._deposit, this._feeDeposit, this._discountDeposit, this._autoDepositCd, this._depositCd, this._draftDrawingDate, this._draftPayTimeLimit, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._depositAllowance, this._depositAlwcBlnce, this._debitNoteLinkDepoNo, this._lastReconcileAddUpDt, this._depositAgentCode, this._depositAgentNm, this._depositInputAgentCd, this._depositInputAgentNm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._outline, this._bankCode, this._bankName, this._ediSendDate, this._ediTakeInDate, this._depositNm, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            return new SearchDepsitMain(this._createDateTime, this._updateDateTime, this._enterpriseCode, 
                                        this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, 
                                        this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, 
                                        this._depositDebitNoteCd, this._depositSlipNo, this._salesSlipNum, 
                                        this._inputDepositSecCd, this._addUpSecCode, this._updateSecCd, 
                                        this._subSectionCode, this._depositDate, this._addUpADate, this._depositTotal,
                                        this._deposit, this._feeDeposit, this._discountDeposit, 
                                        this._autoDepositCd, this._draftDrawingDate, 
                                        this._draftKind, this._draftKindName, this._draftDivide, 
                                        this._draftDivideName, this._draftNo, this._depositAllowance, 
                                        this._depositAlwcBlnce, this._debitNoteLinkDepoNo, this._lastReconcileAddUpDt, 
                                        this._depositAgentCode, this._depositAgentNm, this._depositInputAgentCd, 
                                        this._depositInputAgentNm, this._customerCode, this._customerName, 
                                        this._customerName2, this._customerSnm, this._claimCode, 
                                        this._claimName, this._claimName2, this._claimSnm, 
                                        this._outline, this._bankCode, this._bankName, 
                                        this._depositNm, this._enterpriseName, this._updEmployeeName, 
                                        this._addUpSecName, this._depositRowNo, this._moneyKindCode, 
                                        this._moneyKindName, this._moneyKindDiv, this._depositDtl, 
                                        this._validityTerm, this._inputDay);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 入金検索データクラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchDepsitMainクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepsitMainクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SearchDepsitMain target)
        {
            //return ((this.CreateDateTime == target.CreateDateTime)
            //     && (this.UpdateDateTime == target.UpdateDateTime)
            //     && (this.EnterpriseCode == target.EnterpriseCode)
            //     && (this.FileHeaderGuid == target.FileHeaderGuid)
            //     && (this.UpdEmployeeCode == target.UpdEmployeeCode)
            //     && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
            //     && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
            //     && (this.LogicalDeleteCode == target.LogicalDeleteCode)
            //     && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
            //     && (this.DepositDebitNoteCd == target.DepositDebitNoteCd)
            //     && (this.DepositSlipNo == target.DepositSlipNo)
            //     && (this.SalesSlipNum == target.SalesSlipNum)
            //     && (this.InputDepositSecCd == target.InputDepositSecCd)
            //     && (this.AddUpSecCode == target.AddUpSecCode)
            //     && (this.UpdateSecCd == target.UpdateSecCd)
            //     && (this.SubSectionCode == target.SubSectionCode)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.MinSectionCode == target.MinSectionCode)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //     && (this.DepositDate == target.DepositDate)
            //     && (this.AddUpADate == target.AddUpADate)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.DepositKindCode == target.DepositKindCode)
            //    && (this.DepositKindName == target.DepositKindName)
            //    && (this.DepositKindDivCd == target.DepositKindDivCd)
            //    && (this.DepositTotal == target.DepositTotal)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //     && (this.Deposit == target.Deposit)
            //     && (this.FeeDeposit == target.FeeDeposit)
            //     && (this.DiscountDeposit == target.DiscountDeposit)
            //     && (this.AutoDepositCd == target.AutoDepositCd)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.DepositCd == target.DepositCd)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //    && (this.DraftDrawingDate == target.DraftDrawingDate)
            //   /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //   && (this.DraftPayTimeLimit == target.DraftPayTimeLimit)
            //      --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //     && (this.DraftKind == target.DraftKind)
            //     && (this.DraftKindName == target.DraftKindName)
            //     && (this.DraftDivide == target.DraftDivide)
            //     && (this.DraftDivideName == target.DraftDivideName)
            //     && (this.DraftNo == target.DraftNo)
            //     && (this.DepositAllowance == target.DepositAllowance)
            //     && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
            //     && (this.DebitNoteLinkDepoNo == target.DebitNoteLinkDepoNo)
            //     && (this.LastReconcileAddUpDt == target.LastReconcileAddUpDt)
            //     && (this.DepositAgentCode == target.DepositAgentCode)
            //     && (this.DepositAgentNm == target.DepositAgentNm)
            //     && (this.DepositInputAgentCd == target.DepositInputAgentCd)
            //     && (this.DepositInputAgentNm == target.DepositInputAgentNm)
            //     && (this.CustomerCode == target.CustomerCode)
            //     && (this.CustomerName == target.CustomerName)
            //     && (this.CustomerName2 == target.CustomerName2)
            //     && (this.CustomerSnm == target.CustomerSnm)
            //     && (this.ClaimCode == target.ClaimCode)
            //     && (this.ClaimName == target.ClaimName)
            //     && (this.ClaimName2 == target.ClaimName2)
            //     && (this.ClaimSnm == target.ClaimSnm)
            //     && (this.Outline == target.Outline)
            //     && (this.BankCode == target.BankCode)
            //     && (this.BankName == target.BankName)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.EdiSendDate == target.EdiSendDate)
            //    && (this.EdiTakeInDate == target.EdiTakeInDate)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //    && (this.DepositNm == target.DepositNm)
            //    && (this.EnterpriseName == target.EnterpriseName)
            //    && (this.UpdEmployeeName == target.UpdEmployeeName)
            //    && (this.AddUpSecName == target.AddUpSecName)
            //    // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.DepositRowNo == target.DepositRowNo)
            //    && (this.MoneyKindCode == target.MoneyKindCode)
            //    && (this.MoneyKindName == target.MoneyKindName)
            //    && (this.MoneyKindDiv == target.MoneyKindDiv)
            //    && (this.DepositDtl == target.DepositDtl)
            //    && (this.ValidityTerm == target.ValidityTerm)
            //    // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            //    );
            if (this.CreateDateTime != target.CreateDateTime) { return (false); }
            if (this.UpdateDateTime != target.UpdateDateTime) { return (false); }
            if (this.EnterpriseCode != target.EnterpriseCode) { return (false); }
            if (this.FileHeaderGuid != target.FileHeaderGuid) { return (false); }
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) { return (false); }
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) { return (false); }
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) { return (false); }
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) { return (false); }
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) { return (false); }
            if (this.DepositDebitNoteCd != target.DepositDebitNoteCd) { return (false); }
            if (this.DepositSlipNo != target.DepositSlipNo) { return (false); }
            if (this.SalesSlipNum != target.SalesSlipNum) { return (false); }
            if (this.InputDepositSecCd != target.InputDepositSecCd) { return (false); }
            if (this.AddUpSecCode != target.AddUpSecCode) { return (false); }
            if (this.UpdateSecCd != target.UpdateSecCd) { return (false); }
            if (this.SubSectionCode != target.SubSectionCode) { return (false); }
            if (this.DepositDate != target.DepositDate) { return (false); }
            if (this.AddUpADate != target.AddUpADate) { return (false); }
            if (this.Deposit != target.Deposit) { return (false); }
            if (this.FeeDeposit != target.FeeDeposit) { return (false); }
            if (this.DiscountDeposit != target.DiscountDeposit) { return (false); }
            if (this.AutoDepositCd != target.AutoDepositCd) { return (false); }
            if (this.DraftDrawingDate != target.DraftDrawingDate) { return (false); }
            if (this.DraftKind != target.DraftKind) { return (false); }
            if (this.DraftKindName != target.DraftKindName) { return (false); }
            if (this.DraftDivide != target.DraftDivide) { return (false); }
            if (this.DraftDivideName != target.DraftDivideName) { return (false); }
            if (this.DraftNo != target.DraftNo) { return (false); }
            if (this.DepositAllowance != target.DepositAllowance) { return (false); }
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) { return (false); }
            if (this.DebitNoteLinkDepoNo != target.DebitNoteLinkDepoNo) { return (false); }
            if (this.LastReconcileAddUpDt != target.LastReconcileAddUpDt) { return (false); }
            if (this.DepositAgentCode != target.DepositAgentCode) { return (false); }
            if (this.DepositAgentNm != target.DepositAgentNm) { return (false); }
            if (this.DepositInputAgentCd != target.DepositInputAgentCd) { return (false); }
            if (this.DepositInputAgentNm != target.DepositInputAgentNm) { return (false); }
            if (this.CustomerCode != target.CustomerCode) { return (false); }
            if (this.CustomerName != target.CustomerName) { return (false); }
            if (this.CustomerName2 != target.CustomerName2) { return (false); }
            if (this.CustomerSnm != target.CustomerSnm) { return (false); }
            if (this.ClaimCode != target.ClaimCode) { return (false); }
            if (this.ClaimName != target.ClaimName) { return (false); }
            if (this.ClaimName2 != target.ClaimName2) { return (false); }
            if (this.ClaimSnm != target.ClaimSnm) { return (false); }
            if (this.Outline != target.Outline) { return (false); }
            if (this.BankCode != target.BankCode) { return (false); }
            if (this.BankName != target.BankName) { return (false); }
            if (this.DepositNm != target.DepositNm) { return (false); }
            if (this.EnterpriseName != target.EnterpriseName) { return (false); }
            if (this.UpdEmployeeName != target.UpdEmployeeName) { return (false); }
            if (this.AddUpSecName != target.AddUpSecName) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (this.DepositRowNo != target.DepositRowNo) { return (false); }
                if (this.MoneyKindCode != target.MoneyKindCode) { return (false); }
                if (this.MoneyKindName != target.MoneyKindName) { return (false); }
                if (this.MoneyKindDiv != target.MoneyKindDiv) { return (false); }
                if (this.DepositDtl != target.DepositDtl) { return (false); }
                if (this.ValidityTerm != target.ValidityTerm) { return (false); }
            }
            if (this.InputDay != target.InputDay) { return (false); }

            return (true);
       }

        /// <summary>
        /// 入金検索データクラス比較処理
        /// </summary>
        /// <param name="searchDepsitMain1">
        ///                    比較するSearchDepsitMainクラスのインスタンス
        /// </param>
        /// <param name="searchDepsitMain2">比較するSearchDepsitMainクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepsitMainクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SearchDepsitMain searchDepsitMain1, SearchDepsitMain searchDepsitMain2)
       {
           //return ((searchDepsitMain1.CreateDateTime == searchDepsitMain2.CreateDateTime)
           //     && (searchDepsitMain1.UpdateDateTime == searchDepsitMain2.UpdateDateTime)
           //     && (searchDepsitMain1.EnterpriseCode == searchDepsitMain2.EnterpriseCode)
           //     && (searchDepsitMain1.FileHeaderGuid == searchDepsitMain2.FileHeaderGuid)
           //     && (searchDepsitMain1.UpdEmployeeCode == searchDepsitMain2.UpdEmployeeCode)
           //     && (searchDepsitMain1.UpdAssemblyId1 == searchDepsitMain2.UpdAssemblyId1)
           //     && (searchDepsitMain1.UpdAssemblyId2 == searchDepsitMain2.UpdAssemblyId2)
           //     && (searchDepsitMain1.LogicalDeleteCode == searchDepsitMain2.LogicalDeleteCode)
           //     && (searchDepsitMain1.AcptAnOdrStatus == searchDepsitMain2.AcptAnOdrStatus)
           //     && (searchDepsitMain1.DepositDebitNoteCd == searchDepsitMain2.DepositDebitNoteCd)
           //     && (searchDepsitMain1.DepositSlipNo == searchDepsitMain2.DepositSlipNo)
           //     && (searchDepsitMain1.SalesSlipNum == searchDepsitMain2.SalesSlipNum)
           //     && (searchDepsitMain1.InputDepositSecCd == searchDepsitMain2.InputDepositSecCd)
           //     && (searchDepsitMain1.AddUpSecCode == searchDepsitMain2.AddUpSecCode)
           //     && (searchDepsitMain1.UpdateSecCd == searchDepsitMain2.UpdateSecCd)
           //     && (searchDepsitMain1.SubSectionCode == searchDepsitMain2.SubSectionCode)
           //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //    && (searchDepsitMain1.MinSectionCode == searchDepsitMain2.MinSectionCode)
           //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.DepositDate == searchDepsitMain2.DepositDate)
           //      && (searchDepsitMain1.AddUpADate == searchDepsitMain2.AddUpADate)
           //     /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //     && (searchDepsitMain1.DepositKindCode == searchDepsitMain2.DepositKindCode)
           //     && (searchDepsitMain1.DepositKindName == searchDepsitMain2.DepositKindName)
           //     && (searchDepsitMain1.DepositKindDivCd == searchDepsitMain2.DepositKindDivCd)
           //     && (searchDepsitMain1.DepositTotal == searchDepsitMain2.DepositTotal)
           //        --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.Deposit == searchDepsitMain2.Deposit)
           //      && (searchDepsitMain1.FeeDeposit == searchDepsitMain2.FeeDeposit)
           //      && (searchDepsitMain1.DiscountDeposit == searchDepsitMain2.DiscountDeposit)
           //      && (searchDepsitMain1.AutoDepositCd == searchDepsitMain2.AutoDepositCd)
           //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //    && (searchDepsitMain1.DepositCd == searchDepsitMain2.DepositCd)
           //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //    && (searchDepsitMain1.DraftDrawingDate == searchDepsitMain2.DraftDrawingDate)
           //   /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //   && (searchDepsitMain1.DraftPayTimeLimit == searchDepsitMain2.DraftPayTimeLimit)
           //      --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.DraftKind == searchDepsitMain2.DraftKind)
           //      && (searchDepsitMain1.DraftKindName == searchDepsitMain2.DraftKindName)
           //      && (searchDepsitMain1.DraftDivide == searchDepsitMain2.DraftDivide)
           //      && (searchDepsitMain1.DraftDivideName == searchDepsitMain2.DraftDivideName)
           //      && (searchDepsitMain1.DraftNo == searchDepsitMain2.DraftNo)
           //      && (searchDepsitMain1.DepositAllowance == searchDepsitMain2.DepositAllowance)
           //      && (searchDepsitMain1.DepositAlwcBlnce == searchDepsitMain2.DepositAlwcBlnce)
           //      && (searchDepsitMain1.DebitNoteLinkDepoNo == searchDepsitMain2.DebitNoteLinkDepoNo)
           //      && (searchDepsitMain1.LastReconcileAddUpDt == searchDepsitMain2.LastReconcileAddUpDt)
           //      && (searchDepsitMain1.DepositAgentCode == searchDepsitMain2.DepositAgentCode)
           //      && (searchDepsitMain1.DepositAgentNm == searchDepsitMain2.DepositAgentNm)
           //      && (searchDepsitMain1.DepositInputAgentCd == searchDepsitMain2.DepositInputAgentCd)
           //      && (searchDepsitMain1.DepositInputAgentNm == searchDepsitMain2.DepositInputAgentNm)
           //      && (searchDepsitMain1.CustomerCode == searchDepsitMain2.CustomerCode)
           //      && (searchDepsitMain1.CustomerName == searchDepsitMain2.CustomerName)
           //      && (searchDepsitMain1.CustomerName2 == searchDepsitMain2.CustomerName2)
           //      && (searchDepsitMain1.CustomerSnm == searchDepsitMain2.CustomerSnm)
           //      && (searchDepsitMain1.ClaimCode == searchDepsitMain2.ClaimCode)
           //      && (searchDepsitMain1.ClaimName == searchDepsitMain2.ClaimName)
           //      && (searchDepsitMain1.ClaimName2 == searchDepsitMain2.ClaimName2)
           //      && (searchDepsitMain1.ClaimSnm == searchDepsitMain2.ClaimSnm)
           //      && (searchDepsitMain1.Outline == searchDepsitMain2.Outline)
           //      && (searchDepsitMain1.BankCode == searchDepsitMain2.BankCode)
           //      && (searchDepsitMain1.BankName == searchDepsitMain2.BankName)
           //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //    && (searchDepsitMain1.EdiSendDate == searchDepsitMain2.EdiSendDate)
           //    && (searchDepsitMain1.EdiTakeInDate == searchDepsitMain2.EdiTakeInDate)
           //      --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.DepositNm == searchDepsitMain2.DepositNm)
           //      && (searchDepsitMain1.EnterpriseName == searchDepsitMain2.EnterpriseName)
           //      && (searchDepsitMain1.UpdEmployeeName == searchDepsitMain2.UpdEmployeeName)
           //      && (searchDepsitMain1.AddUpSecName == searchDepsitMain2.AddUpSecName)
           //      // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
           //      && (searchDepsitMain1.DepositRowNo == searchDepsitMain2.DepositRowNo)
           //      && (searchDepsitMain1.MoneyKindCode == searchDepsitMain2.MoneyKindCode)
           //      && (searchDepsitMain1.MoneyKindName == searchDepsitMain2.MoneyKindName)
           //      && (searchDepsitMain1.MoneyKindDiv == searchDepsitMain2.MoneyKindDiv)
           //      && (searchDepsitMain1.DepositDtl == searchDepsitMain2.DepositDtl)
           //      && (searchDepsitMain1.ValidityTerm == searchDepsitMain2.ValidityTerm)
           //      // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
           //      );
            if (searchDepsitMain1.CreateDateTime != searchDepsitMain2.CreateDateTime) { return (false); }
            if (searchDepsitMain1.UpdateDateTime != searchDepsitMain2.UpdateDateTime) { return (false); }
            if (searchDepsitMain1.EnterpriseCode != searchDepsitMain2.EnterpriseCode) { return (false); }
            if (searchDepsitMain1.FileHeaderGuid != searchDepsitMain2.FileHeaderGuid) { return (false); }
            if (searchDepsitMain1.UpdEmployeeCode != searchDepsitMain2.UpdEmployeeCode) { return (false); }
            if (searchDepsitMain1.UpdAssemblyId1 != searchDepsitMain2.UpdAssemblyId1) { return (false); }
            if (searchDepsitMain1.UpdAssemblyId2 != searchDepsitMain2.UpdAssemblyId2) { return (false); }
            if (searchDepsitMain1.LogicalDeleteCode != searchDepsitMain2.LogicalDeleteCode) { return (false); }
            if (searchDepsitMain1.AcptAnOdrStatus != searchDepsitMain2.AcptAnOdrStatus) { return (false); }
            if (searchDepsitMain1.DepositDebitNoteCd != searchDepsitMain2.DepositDebitNoteCd) { return (false); }
            if (searchDepsitMain1.DepositSlipNo != searchDepsitMain2.DepositSlipNo) { return (false); }
            if (searchDepsitMain1.SalesSlipNum != searchDepsitMain2.SalesSlipNum) { return (false); }
            if (searchDepsitMain1.InputDepositSecCd != searchDepsitMain2.InputDepositSecCd) { return (false); }
            if (searchDepsitMain1.AddUpSecCode != searchDepsitMain2.AddUpSecCode) { return (false); }
            if (searchDepsitMain1.UpdateSecCd != searchDepsitMain2.UpdateSecCd) { return (false); }
            if (searchDepsitMain1.SubSectionCode != searchDepsitMain2.SubSectionCode) { return (false); }
            if (searchDepsitMain1.DepositDate != searchDepsitMain2.DepositDate) { return (false); }
            if (searchDepsitMain1.AddUpADate != searchDepsitMain2.AddUpADate) { return (false); }
            if (searchDepsitMain1.Deposit != searchDepsitMain2.Deposit) { return (false); }
            if (searchDepsitMain1.FeeDeposit != searchDepsitMain2.FeeDeposit) { return (false); }
            if (searchDepsitMain1.DiscountDeposit != searchDepsitMain2.DiscountDeposit) { return (false); }
            if (searchDepsitMain1.AutoDepositCd != searchDepsitMain2.AutoDepositCd) { return (false); }
            if (searchDepsitMain1.DraftDrawingDate != searchDepsitMain2.DraftDrawingDate) { return (false); }
            if (searchDepsitMain1.DraftKind != searchDepsitMain2.DraftKind) { return (false); }
            if (searchDepsitMain1.DraftKindName != searchDepsitMain2.DraftKindName) { return (false); }
            if (searchDepsitMain1.DraftDivide != searchDepsitMain2.DraftDivide) { return (false); }
            if (searchDepsitMain1.DraftDivideName != searchDepsitMain2.DraftDivideName) { return (false); }
            if (searchDepsitMain1.DraftNo != searchDepsitMain2.DraftNo) { return (false); }
            if (searchDepsitMain1.DepositAllowance != searchDepsitMain2.DepositAllowance) { return (false); }
            if (searchDepsitMain1.DepositAlwcBlnce != searchDepsitMain2.DepositAlwcBlnce) { return (false); }
            if (searchDepsitMain1.DebitNoteLinkDepoNo != searchDepsitMain2.DebitNoteLinkDepoNo) { return (false); }
            if (searchDepsitMain1.LastReconcileAddUpDt != searchDepsitMain2.LastReconcileAddUpDt) { return (false); }
            if (searchDepsitMain1.DepositAgentCode != searchDepsitMain2.DepositAgentCode) { return (false); }
            if (searchDepsitMain1.DepositAgentNm != searchDepsitMain2.DepositAgentNm) { return (false); }
            if (searchDepsitMain1.DepositInputAgentCd != searchDepsitMain2.DepositInputAgentCd) { return (false); }
            if (searchDepsitMain1.DepositInputAgentNm != searchDepsitMain2.DepositInputAgentNm) { return (false); }
            if (searchDepsitMain1.CustomerCode != searchDepsitMain2.CustomerCode) { return (false); }
            if (searchDepsitMain1.CustomerName != searchDepsitMain2.CustomerName) { return (false); }
            if (searchDepsitMain1.CustomerName2 != searchDepsitMain2.CustomerName2) { return (false); }
            if (searchDepsitMain1.CustomerSnm != searchDepsitMain2.CustomerSnm) { return (false); }
            if (searchDepsitMain1.ClaimCode != searchDepsitMain2.ClaimCode) { return (false); }
            if (searchDepsitMain1.ClaimName != searchDepsitMain2.ClaimName) { return (false); }
            if (searchDepsitMain1.ClaimName2 != searchDepsitMain2.ClaimName2) { return (false); }
            if (searchDepsitMain1.ClaimSnm != searchDepsitMain2.ClaimSnm) { return (false); }
            if (searchDepsitMain1.Outline != searchDepsitMain2.Outline) { return (false); }
            if (searchDepsitMain1.BankCode != searchDepsitMain2.BankCode) { return (false); }
            if (searchDepsitMain1.BankName != searchDepsitMain2.BankName) { return (false); }
            if (searchDepsitMain1.DepositNm != searchDepsitMain2.DepositNm) { return (false); }
            if (searchDepsitMain1.EnterpriseName != searchDepsitMain2.EnterpriseName) { return (false); }
            if (searchDepsitMain1.UpdEmployeeName != searchDepsitMain2.UpdEmployeeName) { return (false); }
            if (searchDepsitMain1.AddUpSecName != searchDepsitMain2.AddUpSecName) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (searchDepsitMain1.DepositRowNo != searchDepsitMain2.DepositRowNo) { return (false); }
                if (searchDepsitMain1.MoneyKindCode != searchDepsitMain2.MoneyKindCode) { return (false); }
                if (searchDepsitMain1.MoneyKindName != searchDepsitMain2.MoneyKindName) { return (false); }
                if (searchDepsitMain1.MoneyKindDiv != searchDepsitMain2.MoneyKindDiv) { return (false); }
                if (searchDepsitMain1.DepositDtl != searchDepsitMain2.DepositDtl) { return (false); }
                if (searchDepsitMain1.ValidityTerm != searchDepsitMain2.ValidityTerm) { return (false); }
            }
            if (searchDepsitMain1.InputDay != searchDepsitMain2.InputDay) { return (false); }

            return (true);
        }
        /// <summary>
        /// 入金検索データクラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchDepsitMainクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepsitMainクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SearchDepsitMain target)
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
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.DepositDebitNoteCd != target.DepositDebitNoteCd) resList.Add("DepositDebitNoteCd");
            if (this.DepositSlipNo != target.DepositSlipNo) resList.Add("DepositSlipNo");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.InputDepositSecCd != target.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.MinSectionCode != target.MinSectionCode) resList.Add("MinSectionCode");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DepositDate != target.DepositDate) resList.Add("DepositDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositKindCode != target.DepositKindCode) resList.Add("DepositKindCode");
            if (this.DepositKindName != target.DepositKindName) resList.Add("DepositKindName");
            if (this.DepositKindDivCd != target.DepositKindDivCd) resList.Add("DepositKindDivCd");
            if (this.DepositTotal != target.DepositTotal) resList.Add("DepositTotal");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.FeeDeposit != target.FeeDeposit) resList.Add("FeeDeposit");
            if (this.DiscountDeposit != target.DiscountDeposit) resList.Add("DiscountDeposit");
            if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositCd != target.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DraftPayTimeLimit != target.DraftPayTimeLimit) resList.Add("DraftPayTimeLimit");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DraftKind != target.DraftKind) resList.Add("DraftKind");
            if (this.DraftKindName != target.DraftKindName) resList.Add("DraftKindName");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.DraftDivideName != target.DraftDivideName) resList.Add("DraftDivideName");
            if (this.DraftNo != target.DraftNo) resList.Add("DraftNo");
            if (this.DepositAllowance != target.DepositAllowance) resList.Add("DepositAllowance");
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (this.DebitNoteLinkDepoNo != target.DebitNoteLinkDepoNo) resList.Add("DebitNoteLinkDepoNo");
            if (this.LastReconcileAddUpDt != target.LastReconcileAddUpDt) resList.Add("LastReconcileAddUpDt");
            if (this.DepositAgentCode != target.DepositAgentCode) resList.Add("DepositAgentCode");
            if (this.DepositAgentNm != target.DepositAgentNm) resList.Add("DepositAgentNm");
            if (this.DepositInputAgentCd != target.DepositInputAgentCd) resList.Add("DepositInputAgentCd");
            if (this.DepositInputAgentNm != target.DepositInputAgentNm) resList.Add("DepositInputAgentNm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.Outline != target.Outline) resList.Add("Outline");
            if (this.BankCode != target.BankCode) resList.Add("BankCode");
            if (this.BankName != target.BankName) resList.Add("BankName");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DepositNm != target.DepositNm) resList.Add("DepositNm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (this.DepositRowNo[index] != target.DepositRowNo[index]) resList.Add("DepositRowNo");
                if (this.MoneyKindCode[index] != target.MoneyKindCode[index]) resList.Add("MoneyKindCode");
                if (this.MoneyKindName[index] != target.MoneyKindName[index]) resList.Add("MoneyKindName");
                if (this.MoneyKindDiv[index] != target.MoneyKindDiv[index]) resList.Add("MoneyKindDiv");
                if (this.DepositDtl[index] != target.DepositDtl[index]) resList.Add("DepositDtl");
                if (this.ValidityTerm[index] != target.ValidityTerm[index]) resList.Add("ValidityTerm");
            }
            //if (this.DepositRowNo != target.DepositRowNo) resList.Add("DepositRowNo");
            //if (this.MoneyKindCode != target.MoneyKindCode) resList.Add("MoneyKindCode");
            //if (this.MoneyKindName != target.MoneyKindName) resList.Add("MoneyKindName");
            //if (this.MoneyKindDiv != target.MoneyKindDiv) resList.Add("MoneyKindDiv");
            //if (this.DepositDtl != target.DepositDtl) resList.Add("DepositDtl");
            //if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            if (this.InputDay != target.InputDay) resList.Add("InputDay");

            return resList;
        }

        /// <summary>
        /// 入金検索データクラス比較処理
        /// </summary>
        /// <param name="searchDepsitMain1">比較するSearchDepsitMainクラスのインスタンス</param>
        /// <param name="searchDepsitMain2">比較するSearchDepsitMainクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchDepsitMainクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SearchDepsitMain searchDepsitMain1, SearchDepsitMain searchDepsitMain2)
        {
            ArrayList resList = new ArrayList();
            if (searchDepsitMain1.CreateDateTime != searchDepsitMain2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchDepsitMain1.UpdateDateTime != searchDepsitMain2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchDepsitMain1.EnterpriseCode != searchDepsitMain2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchDepsitMain1.FileHeaderGuid != searchDepsitMain2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchDepsitMain1.UpdEmployeeCode != searchDepsitMain2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchDepsitMain1.UpdAssemblyId1 != searchDepsitMain2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchDepsitMain1.UpdAssemblyId2 != searchDepsitMain2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchDepsitMain1.LogicalDeleteCode != searchDepsitMain2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchDepsitMain1.AcptAnOdrStatus != searchDepsitMain2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (searchDepsitMain1.DepositDebitNoteCd != searchDepsitMain2.DepositDebitNoteCd) resList.Add("DepositDebitNoteCd");
            if (searchDepsitMain1.DepositSlipNo != searchDepsitMain2.DepositSlipNo) resList.Add("DepositSlipNo");
            if (searchDepsitMain1.SalesSlipNum != searchDepsitMain2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (searchDepsitMain1.InputDepositSecCd != searchDepsitMain2.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (searchDepsitMain1.AddUpSecCode != searchDepsitMain2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (searchDepsitMain1.UpdateSecCd != searchDepsitMain2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (searchDepsitMain1.SubSectionCode != searchDepsitMain2.SubSectionCode) resList.Add("SubSectionCode");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.MinSectionCode != searchDepsitMain2.MinSectionCode) resList.Add("MinSectionCode");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DepositDate != searchDepsitMain2.DepositDate) resList.Add("DepositDate");
            if (searchDepsitMain1.AddUpADate != searchDepsitMain2.AddUpADate) resList.Add("AddUpADate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.DepositKindCode != searchDepsitMain2.DepositKindCode) resList.Add("DepositKindCode");
            if (searchDepsitMain1.DepositKindName != searchDepsitMain2.DepositKindName) resList.Add("DepositKindName");
            if (searchDepsitMain1.DepositKindDivCd != searchDepsitMain2.DepositKindDivCd) resList.Add("DepositKindDivCd");
            if (searchDepsitMain1.DepositTotal != searchDepsitMain2.DepositTotal) resList.Add("DepositTotal");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.Deposit != searchDepsitMain2.Deposit) resList.Add("Deposit");
            if (searchDepsitMain1.FeeDeposit != searchDepsitMain2.FeeDeposit) resList.Add("FeeDeposit");
            if (searchDepsitMain1.DiscountDeposit != searchDepsitMain2.DiscountDeposit) resList.Add("DiscountDeposit");
            if (searchDepsitMain1.AutoDepositCd != searchDepsitMain2.AutoDepositCd) resList.Add("AutoDepositCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.DepositCd != searchDepsitMain2.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DraftDrawingDate != searchDepsitMain2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.DraftPayTimeLimit != searchDepsitMain2.DraftPayTimeLimit) resList.Add("DraftPayTimeLimit");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DraftKind != searchDepsitMain2.DraftKind) resList.Add("DraftKind");
            if (searchDepsitMain1.DraftKindName != searchDepsitMain2.DraftKindName) resList.Add("DraftKindName");
            if (searchDepsitMain1.DraftDivide != searchDepsitMain2.DraftDivide) resList.Add("DraftDivide");
            if (searchDepsitMain1.DraftDivideName != searchDepsitMain2.DraftDivideName) resList.Add("DraftDivideName");
            if (searchDepsitMain1.DraftNo != searchDepsitMain2.DraftNo) resList.Add("DraftNo");
            if (searchDepsitMain1.DepositAllowance != searchDepsitMain2.DepositAllowance) resList.Add("DepositAllowance");
            if (searchDepsitMain1.DepositAlwcBlnce != searchDepsitMain2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (searchDepsitMain1.DebitNoteLinkDepoNo != searchDepsitMain2.DebitNoteLinkDepoNo) resList.Add("DebitNoteLinkDepoNo");
            if (searchDepsitMain1.LastReconcileAddUpDt != searchDepsitMain2.LastReconcileAddUpDt) resList.Add("LastReconcileAddUpDt");
            if (searchDepsitMain1.DepositAgentCode != searchDepsitMain2.DepositAgentCode) resList.Add("DepositAgentCode");
            if (searchDepsitMain1.DepositAgentNm != searchDepsitMain2.DepositAgentNm) resList.Add("DepositAgentNm");
            if (searchDepsitMain1.DepositInputAgentCd != searchDepsitMain2.DepositInputAgentCd) resList.Add("DepositInputAgentCd");
            if (searchDepsitMain1.DepositInputAgentNm != searchDepsitMain2.DepositInputAgentNm) resList.Add("DepositInputAgentNm");
            if (searchDepsitMain1.CustomerCode != searchDepsitMain2.CustomerCode) resList.Add("CustomerCode");
            if (searchDepsitMain1.CustomerName != searchDepsitMain2.CustomerName) resList.Add("CustomerName");
            if (searchDepsitMain1.CustomerName2 != searchDepsitMain2.CustomerName2) resList.Add("CustomerName2");
            if (searchDepsitMain1.CustomerSnm != searchDepsitMain2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchDepsitMain1.ClaimCode != searchDepsitMain2.ClaimCode) resList.Add("ClaimCode");
            if (searchDepsitMain1.ClaimName != searchDepsitMain2.ClaimName) resList.Add("ClaimName");
            if (searchDepsitMain1.ClaimName2 != searchDepsitMain2.ClaimName2) resList.Add("ClaimName2");
            if (searchDepsitMain1.ClaimSnm != searchDepsitMain2.ClaimSnm) resList.Add("ClaimSnm");
            if (searchDepsitMain1.Outline != searchDepsitMain2.Outline) resList.Add("Outline");
            if (searchDepsitMain1.BankCode != searchDepsitMain2.BankCode) resList.Add("BankCode");
            if (searchDepsitMain1.BankName != searchDepsitMain2.BankName) resList.Add("BankName");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.EdiSendDate != searchDepsitMain2.EdiSendDate) resList.Add("EdiSendDate");
            if (searchDepsitMain1.EdiTakeInDate != searchDepsitMain2.EdiTakeInDate) resList.Add("EdiTakeInDate");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DepositNm != searchDepsitMain2.DepositNm) resList.Add("DepositNm");
            if (searchDepsitMain1.EnterpriseName != searchDepsitMain2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchDepsitMain1.UpdEmployeeName != searchDepsitMain2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchDepsitMain1.AddUpSecName != searchDepsitMain2.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (searchDepsitMain1.DepositRowNo[index] != searchDepsitMain2.DepositRowNo[index]) resList.Add("DepositRowNo");
                if (searchDepsitMain1.MoneyKindCode[index] != searchDepsitMain2.MoneyKindCode[index]) resList.Add("MoneyKindCode");
                if (searchDepsitMain1.MoneyKindName[index] != searchDepsitMain2.MoneyKindName[index]) resList.Add("MoneyKindName");
                if (searchDepsitMain1.MoneyKindDiv[index] != searchDepsitMain2.MoneyKindDiv[index]) resList.Add("MoneyKindDiv");
                if (searchDepsitMain1.DepositDtl[index] != searchDepsitMain2.DepositDtl[index]) resList.Add("DepositDtl");
                if (searchDepsitMain1.ValidityTerm[index] != searchDepsitMain2.ValidityTerm[index]) resList.Add("ValidityTerm");
            }
            //if (searchDepsitMain1.DepositRowNo != searchDepsitMain2.DepositRowNo) resList.Add("DepositRowNo");
            //if (searchDepsitMain1.MoneyKindCode != searchDepsitMain2.MoneyKindCode) resList.Add("MoneyKindCode");
            //if (searchDepsitMain1.MoneyKindName != searchDepsitMain2.MoneyKindName) resList.Add("MoneyKindName");
            //if (searchDepsitMain1.MoneyKindDiv != searchDepsitMain2.MoneyKindDiv) resList.Add("MoneyKindDiv");
            //if (searchDepsitMain1.DepositDtl != searchDepsitMain2.DepositDtl) resList.Add("DepositDtl");
            //if (searchDepsitMain1.ValidityTerm != searchDepsitMain2.ValidityTerm) resList.Add("ValidityTerm");
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            if (searchDepsitMain1.InputDay != searchDepsitMain2.InputDay) resList.Add("InputDay");

            return resList;
        }
    }
}
