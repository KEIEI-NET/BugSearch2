using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DepsitDataWork
    /// <summary>
    ///                      入金データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/12/15 tianjw</br>
    /// <br>                     Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DepsitDataWork : IFileHeader
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

        /// <summary>入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDay;

        /// <summary>入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        // ----- ADD 2011/12/15 ---------->>>>>
        /// <summary>前回入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _preDepositDate;
        // ----- ADD 2011/12/15 ----------<<<<<

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>入金計</summary>
        /// <remarks>入金金額＋手数料支払額＋値引支払額</remarks>
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

        /// <summary>入金行番号１</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo1;

        /// <summary>金種コード１</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode1;

        /// <summary>金種名称１</summary>
        private string _moneyKindName1 = "";

        /// <summary>金種区分１</summary>
        private Int32 _moneyKindDiv1;

        /// <summary>入金金額１</summary>
        private Int64 _deposit1;

        /// <summary>有効期限１</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm1;

        /// <summary>入金行番号２</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo2;

        /// <summary>金種コード２</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode2;

        /// <summary>金種名称２</summary>
        private string _moneyKindName2 = "";

        /// <summary>金種区分２</summary>
        private Int32 _moneyKindDiv2;

        /// <summary>入金金額２</summary>
        private Int64 _deposit2;

        /// <summary>有効期限２</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm2;

        /// <summary>入金行番号３</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo3;

        /// <summary>金種コード３</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode3;

        /// <summary>金種名称３</summary>
        private string _moneyKindName3 = "";

        /// <summary>金種区分３</summary>
        private Int32 _moneyKindDiv3;

        /// <summary>入金金額３</summary>
        private Int64 _deposit3;

        /// <summary>有効期限３</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm3;

        /// <summary>入金行番号４</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo4;

        /// <summary>金種コード４</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode4;

        /// <summary>金種名称４</summary>
        private string _moneyKindName4 = "";

        /// <summary>金種区分４</summary>
        private Int32 _moneyKindDiv4;

        /// <summary>入金金額４</summary>
        private Int64 _deposit4;

        /// <summary>有効期限４</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm4;

        /// <summary>入金行番号５</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo5;

        /// <summary>金種コード５</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode5;

        /// <summary>金種名称５</summary>
        private string _moneyKindName5 = "";

        /// <summary>金種区分５</summary>
        private Int32 _moneyKindDiv5;

        /// <summary>入金金額５</summary>
        private Int64 _deposit5;

        /// <summary>有効期限５</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm5;

        /// <summary>入金行番号６</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo6;

        /// <summary>金種コード６</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode6;

        /// <summary>金種名称６</summary>
        private string _moneyKindName6 = "";

        /// <summary>金種区分６</summary>
        private Int32 _moneyKindDiv6;

        /// <summary>入金金額６</summary>
        private Int64 _deposit6;

        /// <summary>有効期限６</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm6;

        /// <summary>入金行番号７</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo7;

        /// <summary>金種コード７</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode7;

        /// <summary>金種名称７</summary>
        private string _moneyKindName7 = "";

        /// <summary>金種区分７</summary>
        private Int32 _moneyKindDiv7;

        /// <summary>入金金額７</summary>
        private Int64 _deposit7;

        /// <summary>有効期限７</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm7;

        /// <summary>入金行番号８</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo8;

        /// <summary>金種コード８</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode8;

        /// <summary>金種名称８</summary>
        private string _moneyKindName8 = "";

        /// <summary>金種区分８</summary>
        private Int32 _moneyKindDiv8;

        /// <summary>入金金額８</summary>
        private Int64 _deposit8;

        /// <summary>有効期限８</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm8;

        /// <summary>入金行番号９</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo9;

        /// <summary>金種コード９</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode9;

        /// <summary>金種名称９</summary>
        private string _moneyKindName9 = "";

        /// <summary>金種区分９</summary>
        private Int32 _moneyKindDiv9;

        /// <summary>入金金額９</summary>
        private Int64 _deposit9;

        /// <summary>有効期限９</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm9;

        /// <summary>入金行番号１０</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo10;

        /// <summary>金種コード１０</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode10;

        /// <summary>金種名称１０</summary>
        private string _moneyKindName10 = "";

        /// <summary>金種区分１０</summary>
        private Int32 _moneyKindDiv10;

        /// <summary>入金金額１０</summary>
        private Int64 _deposit10;

        /// <summary>有効期限１０</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm10;


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

        /// public propaty name  :  InputDay
        /// <summary>入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

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

        // ----- ADD 2011/12/15 ------------------------------>>>>>
        /// public propaty name  :  PreDepositDate
        /// <summary>前回入金日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回入金日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PreDepositDate
        {
            get { return _preDepositDate; }
            set { _preDepositDate = value; }
        }
        // ----- ADD 2011/12/15 ------------------------------<<<<<

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

        /// public propaty name  :  DepositTotal
        /// <summary>入金計プロパティ</summary>
        /// <value>入金金額＋手数料支払額＋値引支払額</value>
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

        /// public propaty name  :  DepositRowNo1
        /// <summary>入金行番号１プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo1
        {
            get { return _depositRowNo1; }
            set { _depositRowNo1 = value; }
        }

        /// public propaty name  :  MoneyKindCode1
        /// <summary>金種コード１プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode1
        {
            get { return _moneyKindCode1; }
            set { _moneyKindCode1 = value; }
        }

        /// public propaty name  :  MoneyKindName1
        /// <summary>金種名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName1
        {
            get { return _moneyKindName1; }
            set { _moneyKindName1 = value; }
        }

        /// public propaty name  :  MoneyKindDiv1
        /// <summary>金種区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv1
        {
            get { return _moneyKindDiv1; }
            set { _moneyKindDiv1 = value; }
        }

        /// public propaty name  :  Deposit1
        /// <summary>入金金額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit1
        {
            get { return _deposit1; }
            set { _deposit1 = value; }
        }

        /// public propaty name  :  ValidityTerm1
        /// <summary>有効期限１プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm1
        {
            get { return _validityTerm1; }
            set { _validityTerm1 = value; }
        }

        /// public propaty name  :  DepositRowNo2
        /// <summary>入金行番号２プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo2
        {
            get { return _depositRowNo2; }
            set { _depositRowNo2 = value; }
        }

        /// public propaty name  :  MoneyKindCode2
        /// <summary>金種コード２プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode2
        {
            get { return _moneyKindCode2; }
            set { _moneyKindCode2 = value; }
        }

        /// public propaty name  :  MoneyKindName2
        /// <summary>金種名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName2
        {
            get { return _moneyKindName2; }
            set { _moneyKindName2 = value; }
        }

        /// public propaty name  :  MoneyKindDiv2
        /// <summary>金種区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv2
        {
            get { return _moneyKindDiv2; }
            set { _moneyKindDiv2 = value; }
        }

        /// public propaty name  :  Deposit2
        /// <summary>入金金額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit2
        {
            get { return _deposit2; }
            set { _deposit2 = value; }
        }

        /// public propaty name  :  ValidityTerm2
        /// <summary>有効期限２プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm2
        {
            get { return _validityTerm2; }
            set { _validityTerm2 = value; }
        }

        /// public propaty name  :  DepositRowNo3
        /// <summary>入金行番号３プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo3
        {
            get { return _depositRowNo3; }
            set { _depositRowNo3 = value; }
        }

        /// public propaty name  :  MoneyKindCode3
        /// <summary>金種コード３プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode3
        {
            get { return _moneyKindCode3; }
            set { _moneyKindCode3 = value; }
        }

        /// public propaty name  :  MoneyKindName3
        /// <summary>金種名称３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName3
        {
            get { return _moneyKindName3; }
            set { _moneyKindName3 = value; }
        }

        /// public propaty name  :  MoneyKindDiv3
        /// <summary>金種区分３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv3
        {
            get { return _moneyKindDiv3; }
            set { _moneyKindDiv3 = value; }
        }

        /// public propaty name  :  Deposit3
        /// <summary>入金金額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit3
        {
            get { return _deposit3; }
            set { _deposit3 = value; }
        }

        /// public propaty name  :  ValidityTerm3
        /// <summary>有効期限３プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm3
        {
            get { return _validityTerm3; }
            set { _validityTerm3 = value; }
        }

        /// public propaty name  :  DepositRowNo4
        /// <summary>入金行番号４プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo4
        {
            get { return _depositRowNo4; }
            set { _depositRowNo4 = value; }
        }

        /// public propaty name  :  MoneyKindCode4
        /// <summary>金種コード４プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode4
        {
            get { return _moneyKindCode4; }
            set { _moneyKindCode4 = value; }
        }

        /// public propaty name  :  MoneyKindName4
        /// <summary>金種名称４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName4
        {
            get { return _moneyKindName4; }
            set { _moneyKindName4 = value; }
        }

        /// public propaty name  :  MoneyKindDiv4
        /// <summary>金種区分４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv4
        {
            get { return _moneyKindDiv4; }
            set { _moneyKindDiv4 = value; }
        }

        /// public propaty name  :  Deposit4
        /// <summary>入金金額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit4
        {
            get { return _deposit4; }
            set { _deposit4 = value; }
        }

        /// public propaty name  :  ValidityTerm4
        /// <summary>有効期限４プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm4
        {
            get { return _validityTerm4; }
            set { _validityTerm4 = value; }
        }

        /// public propaty name  :  DepositRowNo5
        /// <summary>入金行番号５プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo5
        {
            get { return _depositRowNo5; }
            set { _depositRowNo5 = value; }
        }

        /// public propaty name  :  MoneyKindCode5
        /// <summary>金種コード５プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode5
        {
            get { return _moneyKindCode5; }
            set { _moneyKindCode5 = value; }
        }

        /// public propaty name  :  MoneyKindName5
        /// <summary>金種名称５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName5
        {
            get { return _moneyKindName5; }
            set { _moneyKindName5 = value; }
        }

        /// public propaty name  :  MoneyKindDiv5
        /// <summary>金種区分５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv5
        {
            get { return _moneyKindDiv5; }
            set { _moneyKindDiv5 = value; }
        }

        /// public propaty name  :  Deposit5
        /// <summary>入金金額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit5
        {
            get { return _deposit5; }
            set { _deposit5 = value; }
        }

        /// public propaty name  :  ValidityTerm5
        /// <summary>有効期限５プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm5
        {
            get { return _validityTerm5; }
            set { _validityTerm5 = value; }
        }

        /// public propaty name  :  DepositRowNo6
        /// <summary>入金行番号６プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo6
        {
            get { return _depositRowNo6; }
            set { _depositRowNo6 = value; }
        }

        /// public propaty name  :  MoneyKindCode6
        /// <summary>金種コード６プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode6
        {
            get { return _moneyKindCode6; }
            set { _moneyKindCode6 = value; }
        }

        /// public propaty name  :  MoneyKindName6
        /// <summary>金種名称６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName6
        {
            get { return _moneyKindName6; }
            set { _moneyKindName6 = value; }
        }

        /// public propaty name  :  MoneyKindDiv6
        /// <summary>金種区分６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv6
        {
            get { return _moneyKindDiv6; }
            set { _moneyKindDiv6 = value; }
        }

        /// public propaty name  :  Deposit6
        /// <summary>入金金額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit6
        {
            get { return _deposit6; }
            set { _deposit6 = value; }
        }

        /// public propaty name  :  ValidityTerm6
        /// <summary>有効期限６プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm6
        {
            get { return _validityTerm6; }
            set { _validityTerm6 = value; }
        }

        /// public propaty name  :  DepositRowNo7
        /// <summary>入金行番号７プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo7
        {
            get { return _depositRowNo7; }
            set { _depositRowNo7 = value; }
        }

        /// public propaty name  :  MoneyKindCode7
        /// <summary>金種コード７プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode7
        {
            get { return _moneyKindCode7; }
            set { _moneyKindCode7 = value; }
        }

        /// public propaty name  :  MoneyKindName7
        /// <summary>金種名称７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName7
        {
            get { return _moneyKindName7; }
            set { _moneyKindName7 = value; }
        }

        /// public propaty name  :  MoneyKindDiv7
        /// <summary>金種区分７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv7
        {
            get { return _moneyKindDiv7; }
            set { _moneyKindDiv7 = value; }
        }

        /// public propaty name  :  Deposit7
        /// <summary>入金金額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit7
        {
            get { return _deposit7; }
            set { _deposit7 = value; }
        }

        /// public propaty name  :  ValidityTerm7
        /// <summary>有効期限７プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm7
        {
            get { return _validityTerm7; }
            set { _validityTerm7 = value; }
        }

        /// public propaty name  :  DepositRowNo8
        /// <summary>入金行番号８プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo8
        {
            get { return _depositRowNo8; }
            set { _depositRowNo8 = value; }
        }

        /// public propaty name  :  MoneyKindCode8
        /// <summary>金種コード８プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode8
        {
            get { return _moneyKindCode8; }
            set { _moneyKindCode8 = value; }
        }

        /// public propaty name  :  MoneyKindName8
        /// <summary>金種名称８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName8
        {
            get { return _moneyKindName8; }
            set { _moneyKindName8 = value; }
        }

        /// public propaty name  :  MoneyKindDiv8
        /// <summary>金種区分８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv8
        {
            get { return _moneyKindDiv8; }
            set { _moneyKindDiv8 = value; }
        }

        /// public propaty name  :  Deposit8
        /// <summary>入金金額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit8
        {
            get { return _deposit8; }
            set { _deposit8 = value; }
        }

        /// public propaty name  :  ValidityTerm8
        /// <summary>有効期限８プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm8
        {
            get { return _validityTerm8; }
            set { _validityTerm8 = value; }
        }

        /// public propaty name  :  DepositRowNo9
        /// <summary>入金行番号９プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo9
        {
            get { return _depositRowNo9; }
            set { _depositRowNo9 = value; }
        }

        /// public propaty name  :  MoneyKindCode9
        /// <summary>金種コード９プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode9
        {
            get { return _moneyKindCode9; }
            set { _moneyKindCode9 = value; }
        }

        /// public propaty name  :  MoneyKindName9
        /// <summary>金種名称９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName9
        {
            get { return _moneyKindName9; }
            set { _moneyKindName9 = value; }
        }

        /// public propaty name  :  MoneyKindDiv9
        /// <summary>金種区分９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv9
        {
            get { return _moneyKindDiv9; }
            set { _moneyKindDiv9 = value; }
        }

        /// public propaty name  :  Deposit9
        /// <summary>入金金額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit9
        {
            get { return _deposit9; }
            set { _deposit9 = value; }
        }

        /// public propaty name  :  ValidityTerm9
        /// <summary>有効期限９プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm9
        {
            get { return _validityTerm9; }
            set { _validityTerm9 = value; }
        }

        /// public propaty name  :  DepositRowNo10
        /// <summary>入金行番号１０プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo10
        {
            get { return _depositRowNo10; }
            set { _depositRowNo10 = value; }
        }

        /// public propaty name  :  MoneyKindCode10
        /// <summary>金種コード１０プロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コード１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode10
        {
            get { return _moneyKindCode10; }
            set { _moneyKindCode10 = value; }
        }

        /// public propaty name  :  MoneyKindName10
        /// <summary>金種名称１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName10
        {
            get { return _moneyKindName10; }
            set { _moneyKindName10 = value; }
        }

        /// public propaty name  :  MoneyKindDiv10
        /// <summary>金種区分１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv10
        {
            get { return _moneyKindDiv10; }
            set { _moneyKindDiv10 = value; }
        }

        /// public propaty name  :  Deposit10
        /// <summary>入金金額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Deposit10
        {
            get { return _deposit10; }
            set { _deposit10 = value; }
        }

        /// public propaty name  :  ValidityTerm10
        /// <summary>有効期限１０プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm10
        {
            get { return _validityTerm10; }
            set { _validityTerm10 = value; }
        }


        /// <summary>
        /// 入金データワークコンストラクタ
        /// </summary>
        /// <returns>DepsitDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepsitDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DepsitDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DepsitDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DepsitDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DepsitDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DepsitDataWork || graph is ArrayList || graph is DepsitDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DepsitDataWork).FullName));

            if (graph != null && graph is DepsitDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DepsitDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DepsitDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DepsitDataWork[])graph).Length;
            }
            else if (graph is DepsitDataWork)
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
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //入金赤黒区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDebitNoteCd
            //入金伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipNo
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //入金入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InputDepositSecCd
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //入力日付
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //入金日付
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate
            //入金日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PreDepositDate // ADD 2011/12/15
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //入金計
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositTotal
            //入金金額
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
            //手数料入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //FeeDeposit
            //値引入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountDeposit
            //自動入金区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //手形振出日
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //手形種類
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKind
            //手形種類名称
            serInfo.MemberInfo.Add(typeof(string)); //DraftKindName
            //手形区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //手形区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DraftDivideName
            //手形番号
            serInfo.MemberInfo.Add(typeof(string)); //DraftNo
            //入金引当額
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAllowance
            //入金引当残高
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAlwcBlnce
            //赤黒入金連結番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkDepoNo
            //最終消し込み計上日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastReconcileAddUpDt
            //入金担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentCode
            //入金担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentNm
            //入金入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentCd
            //入金入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentNm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先名称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //請求先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //銀行コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //銀行名称
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //入金行番号１
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo1
            //金種コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode1
            //金種名称１
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName1
            //金種区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv1
            //入金金額１
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit1
            //有効期限１
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm1
            //入金行番号２
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo2
            //金種コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode2
            //金種名称２
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName2
            //金種区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv2
            //入金金額２
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit2
            //有効期限２
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm2
            //入金行番号３
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo3
            //金種コード３
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode3
            //金種名称３
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName3
            //金種区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv3
            //入金金額３
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit3
            //有効期限３
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm3
            //入金行番号４
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo4
            //金種コード４
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode4
            //金種名称４
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName4
            //金種区分４
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv4
            //入金金額４
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit4
            //有効期限４
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm4
            //入金行番号５
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo5
            //金種コード５
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode5
            //金種名称５
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName5
            //金種区分５
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv5
            //入金金額５
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit5
            //有効期限５
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm5
            //入金行番号６
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo6
            //金種コード６
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode6
            //金種名称６
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName6
            //金種区分６
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv6
            //入金金額６
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit6
            //有効期限６
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm6
            //入金行番号７
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo7
            //金種コード７
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode7
            //金種名称７
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName7
            //金種区分７
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv7
            //入金金額７
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit7
            //有効期限７
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm7
            //入金行番号８
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo8
            //金種コード８
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode8
            //金種名称８
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName8
            //金種区分８
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv8
            //入金金額８
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit8
            //有効期限８
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm8
            //入金行番号９
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo9
            //金種コード９
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode9
            //金種名称９
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName9
            //金種区分９
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv9
            //入金金額９
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit9
            //有効期限９
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm9
            //入金行番号１０
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo10
            //金種コード１０
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode10
            //金種名称１０
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName10
            //金種区分１０
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv10
            //入金金額１０
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit10
            //有効期限１０
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm10


            serInfo.Serialize(writer, serInfo);
            if (graph is DepsitDataWork)
            {
                DepsitDataWork temp = (DepsitDataWork)graph;

                SetDepsitDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DepsitDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DepsitDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DepsitDataWork temp in lst)
                {
                    SetDepsitDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DepsitDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 109; // DEL 2011/12/15
        private const int currentMemberCount = 110; // ADD 2011/12/15

        /// <summary>
        ///  DepsitDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetDepsitDataWork(System.IO.BinaryWriter writer, DepsitDataWork temp)
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
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //入金赤黒区分
            writer.Write(temp.DepositDebitNoteCd);
            //入金伝票番号
            writer.Write(temp.DepositSlipNo);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //入金入力拠点コード
            writer.Write(temp.InputDepositSecCd);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //入力日付
            writer.Write((Int64)temp.InputDay.Ticks);
            //入金日付
            writer.Write((Int64)temp.DepositDate.Ticks);
            //入金日付
            writer.Write((Int64)temp.PreDepositDate.Ticks); // ADD 2011/12/15
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //入金計
            writer.Write(temp.DepositTotal);
            //入金金額
            writer.Write(temp.Deposit);
            //手数料入金額
            writer.Write(temp.FeeDeposit);
            //値引入金額
            writer.Write(temp.DiscountDeposit);
            //自動入金区分
            writer.Write(temp.AutoDepositCd);
            //手形振出日
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //手形種類
            writer.Write(temp.DraftKind);
            //手形種類名称
            writer.Write(temp.DraftKindName);
            //手形区分
            writer.Write(temp.DraftDivide);
            //手形区分名称
            writer.Write(temp.DraftDivideName);
            //手形番号
            writer.Write(temp.DraftNo);
            //入金引当額
            writer.Write(temp.DepositAllowance);
            //入金引当残高
            writer.Write(temp.DepositAlwcBlnce);
            //赤黒入金連結番号
            writer.Write(temp.DebitNoteLinkDepoNo);
            //最終消し込み計上日
            writer.Write((Int64)temp.LastReconcileAddUpDt.Ticks);
            //入金担当者コード
            writer.Write(temp.DepositAgentCode);
            //入金担当者名称
            writer.Write(temp.DepositAgentNm);
            //入金入力者コード
            writer.Write(temp.DepositInputAgentCd);
            //入金入力者名称
            writer.Write(temp.DepositInputAgentNm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先名称
            writer.Write(temp.ClaimName);
            //請求先名称2
            writer.Write(temp.ClaimName2);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //伝票摘要
            writer.Write(temp.Outline);
            //銀行コード
            writer.Write(temp.BankCode);
            //銀行名称
            writer.Write(temp.BankName);
            //入金行番号１
            writer.Write(temp.DepositRowNo1);
            //金種コード１
            writer.Write(temp.MoneyKindCode1);
            //金種名称１
            writer.Write(temp.MoneyKindName1);
            //金種区分１
            writer.Write(temp.MoneyKindDiv1);
            //入金金額１
            writer.Write(temp.Deposit1);
            //有効期限１
            writer.Write((Int64)temp.ValidityTerm1.Ticks);
            //入金行番号２
            writer.Write(temp.DepositRowNo2);
            //金種コード２
            writer.Write(temp.MoneyKindCode2);
            //金種名称２
            writer.Write(temp.MoneyKindName2);
            //金種区分２
            writer.Write(temp.MoneyKindDiv2);
            //入金金額２
            writer.Write(temp.Deposit2);
            //有効期限２
            writer.Write((Int64)temp.ValidityTerm2.Ticks);
            //入金行番号３
            writer.Write(temp.DepositRowNo3);
            //金種コード３
            writer.Write(temp.MoneyKindCode3);
            //金種名称３
            writer.Write(temp.MoneyKindName3);
            //金種区分３
            writer.Write(temp.MoneyKindDiv3);
            //入金金額３
            writer.Write(temp.Deposit3);
            //有効期限３
            writer.Write((Int64)temp.ValidityTerm3.Ticks);
            //入金行番号４
            writer.Write(temp.DepositRowNo4);
            //金種コード４
            writer.Write(temp.MoneyKindCode4);
            //金種名称４
            writer.Write(temp.MoneyKindName4);
            //金種区分４
            writer.Write(temp.MoneyKindDiv4);
            //入金金額４
            writer.Write(temp.Deposit4);
            //有効期限４
            writer.Write((Int64)temp.ValidityTerm4.Ticks);
            //入金行番号５
            writer.Write(temp.DepositRowNo5);
            //金種コード５
            writer.Write(temp.MoneyKindCode5);
            //金種名称５
            writer.Write(temp.MoneyKindName5);
            //金種区分５
            writer.Write(temp.MoneyKindDiv5);
            //入金金額５
            writer.Write(temp.Deposit5);
            //有効期限５
            writer.Write((Int64)temp.ValidityTerm5.Ticks);
            //入金行番号６
            writer.Write(temp.DepositRowNo6);
            //金種コード６
            writer.Write(temp.MoneyKindCode6);
            //金種名称６
            writer.Write(temp.MoneyKindName6);
            //金種区分６
            writer.Write(temp.MoneyKindDiv6);
            //入金金額６
            writer.Write(temp.Deposit6);
            //有効期限６
            writer.Write((Int64)temp.ValidityTerm6.Ticks);
            //入金行番号７
            writer.Write(temp.DepositRowNo7);
            //金種コード７
            writer.Write(temp.MoneyKindCode7);
            //金種名称７
            writer.Write(temp.MoneyKindName7);
            //金種区分７
            writer.Write(temp.MoneyKindDiv7);
            //入金金額７
            writer.Write(temp.Deposit7);
            //有効期限７
            writer.Write((Int64)temp.ValidityTerm7.Ticks);
            //入金行番号８
            writer.Write(temp.DepositRowNo8);
            //金種コード８
            writer.Write(temp.MoneyKindCode8);
            //金種名称８
            writer.Write(temp.MoneyKindName8);
            //金種区分８
            writer.Write(temp.MoneyKindDiv8);
            //入金金額８
            writer.Write(temp.Deposit8);
            //有効期限８
            writer.Write((Int64)temp.ValidityTerm8.Ticks);
            //入金行番号９
            writer.Write(temp.DepositRowNo9);
            //金種コード９
            writer.Write(temp.MoneyKindCode9);
            //金種名称９
            writer.Write(temp.MoneyKindName9);
            //金種区分９
            writer.Write(temp.MoneyKindDiv9);
            //入金金額９
            writer.Write(temp.Deposit9);
            //有効期限９
            writer.Write((Int64)temp.ValidityTerm9.Ticks);
            //入金行番号１０
            writer.Write(temp.DepositRowNo10);
            //金種コード１０
            writer.Write(temp.MoneyKindCode10);
            //金種名称１０
            writer.Write(temp.MoneyKindName10);
            //金種区分１０
            writer.Write(temp.MoneyKindDiv10);
            //入金金額１０
            writer.Write(temp.Deposit10);
            //有効期限１０
            writer.Write((Int64)temp.ValidityTerm10.Ticks);

        }

        /// <summary>
        ///  DepsitDataWorkインスタンス取得
        /// </summary>
        /// <returns>DepsitDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DepsitDataWork GetDepsitDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DepsitDataWork temp = new DepsitDataWork();

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
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //入金赤黒区分
            temp.DepositDebitNoteCd = reader.ReadInt32();
            //入金伝票番号
            temp.DepositSlipNo = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //入金入力拠点コード
            temp.InputDepositSecCd = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //入力日付
            temp.InputDay = new DateTime(reader.ReadInt64());
            //入金日付
            temp.DepositDate = new DateTime(reader.ReadInt64());
            //入金日付
            temp.PreDepositDate = new DateTime(reader.ReadInt64()); // ADD 2011/12/15
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //入金計
            temp.DepositTotal = reader.ReadInt64();
            //入金金額
            temp.Deposit = reader.ReadInt64();
            //手数料入金額
            temp.FeeDeposit = reader.ReadInt64();
            //値引入金額
            temp.DiscountDeposit = reader.ReadInt64();
            //自動入金区分
            temp.AutoDepositCd = reader.ReadInt32();
            //手形振出日
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //手形種類
            temp.DraftKind = reader.ReadInt32();
            //手形種類名称
            temp.DraftKindName = reader.ReadString();
            //手形区分
            temp.DraftDivide = reader.ReadInt32();
            //手形区分名称
            temp.DraftDivideName = reader.ReadString();
            //手形番号
            temp.DraftNo = reader.ReadString();
            //入金引当額
            temp.DepositAllowance = reader.ReadInt64();
            //入金引当残高
            temp.DepositAlwcBlnce = reader.ReadInt64();
            //赤黒入金連結番号
            temp.DebitNoteLinkDepoNo = reader.ReadInt32();
            //最終消し込み計上日
            temp.LastReconcileAddUpDt = new DateTime(reader.ReadInt64());
            //入金担当者コード
            temp.DepositAgentCode = reader.ReadString();
            //入金担当者名称
            temp.DepositAgentNm = reader.ReadString();
            //入金入力者コード
            temp.DepositInputAgentCd = reader.ReadString();
            //入金入力者名称
            temp.DepositInputAgentNm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先名称
            temp.ClaimName = reader.ReadString();
            //請求先名称2
            temp.ClaimName2 = reader.ReadString();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //銀行コード
            temp.BankCode = reader.ReadInt32();
            //銀行名称
            temp.BankName = reader.ReadString();
            //入金行番号１
            temp.DepositRowNo1 = reader.ReadInt32();
            //金種コード１
            temp.MoneyKindCode1 = reader.ReadInt32();
            //金種名称１
            temp.MoneyKindName1 = reader.ReadString();
            //金種区分１
            temp.MoneyKindDiv1 = reader.ReadInt32();
            //入金金額１
            temp.Deposit1 = reader.ReadInt64();
            //有効期限１
            temp.ValidityTerm1 = new DateTime(reader.ReadInt64());
            //入金行番号２
            temp.DepositRowNo2 = reader.ReadInt32();
            //金種コード２
            temp.MoneyKindCode2 = reader.ReadInt32();
            //金種名称２
            temp.MoneyKindName2 = reader.ReadString();
            //金種区分２
            temp.MoneyKindDiv2 = reader.ReadInt32();
            //入金金額２
            temp.Deposit2 = reader.ReadInt64();
            //有効期限２
            temp.ValidityTerm2 = new DateTime(reader.ReadInt64());
            //入金行番号３
            temp.DepositRowNo3 = reader.ReadInt32();
            //金種コード３
            temp.MoneyKindCode3 = reader.ReadInt32();
            //金種名称３
            temp.MoneyKindName3 = reader.ReadString();
            //金種区分３
            temp.MoneyKindDiv3 = reader.ReadInt32();
            //入金金額３
            temp.Deposit3 = reader.ReadInt64();
            //有効期限３
            temp.ValidityTerm3 = new DateTime(reader.ReadInt64());
            //入金行番号４
            temp.DepositRowNo4 = reader.ReadInt32();
            //金種コード４
            temp.MoneyKindCode4 = reader.ReadInt32();
            //金種名称４
            temp.MoneyKindName4 = reader.ReadString();
            //金種区分４
            temp.MoneyKindDiv4 = reader.ReadInt32();
            //入金金額４
            temp.Deposit4 = reader.ReadInt64();
            //有効期限４
            temp.ValidityTerm4 = new DateTime(reader.ReadInt64());
            //入金行番号５
            temp.DepositRowNo5 = reader.ReadInt32();
            //金種コード５
            temp.MoneyKindCode5 = reader.ReadInt32();
            //金種名称５
            temp.MoneyKindName5 = reader.ReadString();
            //金種区分５
            temp.MoneyKindDiv5 = reader.ReadInt32();
            //入金金額５
            temp.Deposit5 = reader.ReadInt64();
            //有効期限５
            temp.ValidityTerm5 = new DateTime(reader.ReadInt64());
            //入金行番号６
            temp.DepositRowNo6 = reader.ReadInt32();
            //金種コード６
            temp.MoneyKindCode6 = reader.ReadInt32();
            //金種名称６
            temp.MoneyKindName6 = reader.ReadString();
            //金種区分６
            temp.MoneyKindDiv6 = reader.ReadInt32();
            //入金金額６
            temp.Deposit6 = reader.ReadInt64();
            //有効期限６
            temp.ValidityTerm6 = new DateTime(reader.ReadInt64());
            //入金行番号７
            temp.DepositRowNo7 = reader.ReadInt32();
            //金種コード７
            temp.MoneyKindCode7 = reader.ReadInt32();
            //金種名称７
            temp.MoneyKindName7 = reader.ReadString();
            //金種区分７
            temp.MoneyKindDiv7 = reader.ReadInt32();
            //入金金額７
            temp.Deposit7 = reader.ReadInt64();
            //有効期限７
            temp.ValidityTerm7 = new DateTime(reader.ReadInt64());
            //入金行番号８
            temp.DepositRowNo8 = reader.ReadInt32();
            //金種コード８
            temp.MoneyKindCode8 = reader.ReadInt32();
            //金種名称８
            temp.MoneyKindName8 = reader.ReadString();
            //金種区分８
            temp.MoneyKindDiv8 = reader.ReadInt32();
            //入金金額８
            temp.Deposit8 = reader.ReadInt64();
            //有効期限８
            temp.ValidityTerm8 = new DateTime(reader.ReadInt64());
            //入金行番号９
            temp.DepositRowNo9 = reader.ReadInt32();
            //金種コード９
            temp.MoneyKindCode9 = reader.ReadInt32();
            //金種名称９
            temp.MoneyKindName9 = reader.ReadString();
            //金種区分９
            temp.MoneyKindDiv9 = reader.ReadInt32();
            //入金金額９
            temp.Deposit9 = reader.ReadInt64();
            //有効期限９
            temp.ValidityTerm9 = new DateTime(reader.ReadInt64());
            //入金行番号１０
            temp.DepositRowNo10 = reader.ReadInt32();
            //金種コード１０
            temp.MoneyKindCode10 = reader.ReadInt32();
            //金種名称１０
            temp.MoneyKindName10 = reader.ReadString();
            //金種区分１０
            temp.MoneyKindDiv10 = reader.ReadInt32();
            //入金金額１０
            temp.Deposit10 = reader.ReadInt64();
            //有効期限１０
            temp.ValidityTerm10 = new DateTime(reader.ReadInt64());


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
        /// <returns>DepsitDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DepsitDataWork temp = GetDepsitDataWork(reader, serInfo);
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
                    retValue = (DepsitDataWork[])lst.ToArray(typeof(DepsitDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

    /// <summary>
    /// 入金データ
    /// </summary>
    public static class DepsitDataUtil
    {
        /// <summary>
        /// 入金マスタデータと入金明細データを合体します。
        /// </summary>
        /// <param name="depsitDataWrk">入金データワーク(合体)</param>
        /// <param name="depsitMainWrk">入金マスタデータ</param>
        /// <param name="depsitDtlWrkArray">入金明細データの配列</param>
        public static void Union(out DepsitDataWork depsitDataWrk, DepsitMainWork depsitMainWrk, DepsitDtlWork[] depsitDtlWrkArray)
        {
            depsitDataWrk = new DepsitDataWork();
            DepsitDataUtil.UnionRef(ref depsitDataWrk, depsitMainWrk, depsitDtlWrkArray);
        }

        /// <summary>
        /// 入金マスタデータと入金明細データを合体します。
        /// </summary>
        /// <param name="depsitDataWrk">入金データワーク(合体)</param>
        /// <param name="depsitMainWrk">入金マスタデータ</param>
        /// <param name="depsitDtlWrkArray">入金明細データの配列</param>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        public static void UnionRef(ref DepsitDataWork depsitDataWrk, DepsitMainWork depsitMainWrk, DepsitDtlWork[] depsitDtlWrkArray)
        {
            if (depsitDataWrk != null)
            {
                # region [DepsitDataWork ← DepsitMainWork]
                if (depsitMainWrk != null)
                {
                    depsitDataWrk.CreateDateTime = depsitMainWrk.CreateDateTime;              // 作成日時
                    depsitDataWrk.UpdateDateTime = depsitMainWrk.UpdateDateTime;              // 更新日時
                    depsitDataWrk.EnterpriseCode = depsitMainWrk.EnterpriseCode;              // 企業コード
                    depsitDataWrk.FileHeaderGuid = depsitMainWrk.FileHeaderGuid;              // GUID
                    depsitDataWrk.UpdEmployeeCode = depsitMainWrk.UpdEmployeeCode;            // 更新従業員コード
                    depsitDataWrk.UpdAssemblyId1 = depsitMainWrk.UpdAssemblyId1;              // 更新アセンブリID1
                    depsitDataWrk.UpdAssemblyId2 = depsitMainWrk.UpdAssemblyId2;              // 更新アセンブリID2
                    depsitDataWrk.LogicalDeleteCode = depsitMainWrk.LogicalDeleteCode;        // 論理削除区分
                    depsitDataWrk.AcptAnOdrStatus = depsitMainWrk.AcptAnOdrStatus;            // 受注ステータス
                    depsitDataWrk.DepositDebitNoteCd = depsitMainWrk.DepositDebitNoteCd;      // 入金赤黒区分
                    depsitDataWrk.DepositSlipNo = depsitMainWrk.DepositSlipNo;                // 入金伝票番号
                    depsitDataWrk.SalesSlipNum = depsitMainWrk.SalesSlipNum;                  // 売上伝票番号
                    depsitDataWrk.InputDepositSecCd = depsitMainWrk.InputDepositSecCd;        // 入金入力拠点コード
                    depsitDataWrk.AddUpSecCode = depsitMainWrk.AddUpSecCode;                  // 計上拠点コード
                    depsitDataWrk.UpdateSecCd = depsitMainWrk.UpdateSecCd;                    // 更新拠点コード
                    depsitDataWrk.SubSectionCode = depsitMainWrk.SubSectionCode;              // 部門コード
                    depsitDataWrk.InputDay = depsitMainWrk.InputDay;                          // 入力日付  //ADD 2009/03/25
                    depsitDataWrk.DepositDate = depsitMainWrk.DepositDate;                    // 入金日付
                    depsitDataWrk.PreDepositDate = depsitMainWrk.PreDepositDate;              // 入金日付 // ADD 2011/12/21
                    depsitDataWrk.AddUpADate = depsitMainWrk.AddUpADate;                      // 計上日付
                    depsitDataWrk.DepositTotal = depsitMainWrk.DepositTotal;                  // 入金計
                    depsitDataWrk.Deposit = depsitMainWrk.Deposit;                            // 入金金額
                    depsitDataWrk.FeeDeposit = depsitMainWrk.FeeDeposit;                      // 手数料入金額
                    depsitDataWrk.DiscountDeposit = depsitMainWrk.DiscountDeposit;            // 値引入金額
                    depsitDataWrk.AutoDepositCd = depsitMainWrk.AutoDepositCd;                // 自動入金区分
                    depsitDataWrk.DraftDrawingDate = depsitMainWrk.DraftDrawingDate;          // 手形振出日
                    depsitDataWrk.DraftKind = depsitMainWrk.DraftKind;                        // 手形種類
                    depsitDataWrk.DraftKindName = depsitMainWrk.DraftKindName;                // 手形種類名称
                    depsitDataWrk.DraftDivide = depsitMainWrk.DraftDivide;                    // 手形区分
                    depsitDataWrk.DraftDivideName = depsitMainWrk.DraftDivideName;            // 手形区分名称
                    depsitDataWrk.DraftNo = depsitMainWrk.DraftNo;                            // 手形番号
                    depsitDataWrk.DepositAllowance = depsitMainWrk.DepositAllowance;          // 入金引当額
                    depsitDataWrk.DepositAlwcBlnce = depsitMainWrk.DepositAlwcBlnce;          // 入金引当残高
                    depsitDataWrk.DebitNoteLinkDepoNo = depsitMainWrk.DebitNoteLinkDepoNo;    // 赤黒入金連結番号
                    depsitDataWrk.LastReconcileAddUpDt = depsitMainWrk.LastReconcileAddUpDt;  // 最終消し込み計上日
                    depsitDataWrk.DepositAgentCode = depsitMainWrk.DepositAgentCode;          // 入金担当者コード
                    depsitDataWrk.DepositAgentNm = depsitMainWrk.DepositAgentNm;              // 入金担当者名称
                    depsitDataWrk.DepositInputAgentCd = depsitMainWrk.DepositInputAgentCd;    // 入金入力者コード
                    depsitDataWrk.DepositInputAgentNm = depsitMainWrk.DepositInputAgentNm;    // 入金入力者名称
                    depsitDataWrk.CustomerCode = depsitMainWrk.CustomerCode;                  // 得意先コード
                    depsitDataWrk.CustomerName = depsitMainWrk.CustomerName;                  // 得意先名称
                    depsitDataWrk.CustomerName2 = depsitMainWrk.CustomerName2;                // 得意先名称2
                    depsitDataWrk.CustomerSnm = depsitMainWrk.CustomerSnm;                    // 得意先略称
                    depsitDataWrk.ClaimCode = depsitMainWrk.ClaimCode;                        // 請求先コード
                    depsitDataWrk.ClaimName = depsitMainWrk.ClaimName;                        // 請求先名称
                    depsitDataWrk.ClaimName2 = depsitMainWrk.ClaimName2;                      // 請求先名称2
                    depsitDataWrk.ClaimSnm = depsitMainWrk.ClaimSnm;                          // 請求先略称
                    depsitDataWrk.Outline = depsitMainWrk.Outline;                            // 伝票摘要
                    depsitDataWrk.BankCode = depsitMainWrk.BankCode;                          // 銀行コード
                    depsitDataWrk.BankName = depsitMainWrk.BankName;                          // 銀行名称
                }
                # endregion

                # region [DepsitDataWork ← DepsitDtlWork ]
                if (depsitDtlWrkArray != null)
                {
                    for (int idx = 0; idx < depsitDtlWrkArray.Length; idx++)
                    {
                        DepsitDtlWork depsitDtlWrk = depsitDtlWrkArray[idx];

                        switch (depsitDtlWrk.DepositRowNo)
                        {
                            case 1:
                                {
                                    depsitDataWrk.DepositRowNo1 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode1 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName1 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv1 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit1 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm1 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 2:
                                {
                                    depsitDataWrk.DepositRowNo2 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode2 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName2 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv2 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit2 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm2 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 3:
                                {
                                    depsitDataWrk.DepositRowNo3 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode3 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName3 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv3 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit3 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm3 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 4:
                                {
                                    depsitDataWrk.DepositRowNo4 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode4 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName4 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv4 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit4 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm4 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 5:
                                {
                                    depsitDataWrk.DepositRowNo5 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode5 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName5 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv5 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit5 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm5 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 6:
                                {
                                    depsitDataWrk.DepositRowNo6 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode6 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName6 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv6 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit6 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm6 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 7:
                                {
                                    depsitDataWrk.DepositRowNo7 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode7 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName7 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv7 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit7 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm7 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 8:
                                {
                                    depsitDataWrk.DepositRowNo8 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode8 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName8 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv8 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit8 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm8 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 9:
                                {
                                    depsitDataWrk.DepositRowNo9 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode9 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName9 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv9 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit9 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm9 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 10:
                                {
                                    depsitDataWrk.DepositRowNo10 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode10 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName10 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv10 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit10 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm10 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                        }
                    }
                }
                # endregion
            }
        }

        /// <summary>
        /// 入金データ(合体)を入金マスタデータと入金明細データに分割します。
        /// </summary>
        /// <param name="depsitDataWrk">入金データワーク(合体)</param>
        /// <param name="depsitMainWrk">入金マスタデータ</param>
        /// <param name="depsitDtlWrkArray">入金明細データの配列</param>
        public static void Division(DepsitDataWork depsitDataWrk, out DepsitMainWork depsitMainWrk, out DepsitDtlWork[] depsitDtlWrkArray)
        {
            depsitMainWrk = new DepsitMainWork();
            depsitDtlWrkArray = new DepsitDtlWork[0];
            DepsitDataUtil.DivisionRef(depsitDataWrk, ref depsitMainWrk, ref depsitDtlWrkArray);
        }

        /// <summary>
        /// 入金データ(合体)を入金マスタデータと入金明細データに分割します。
        /// </summary>
        /// <param name="depsitDataWrk">入金データワーク(合体)</param>
        /// <param name="depsitMainWrk">入金マスタデータ</param>
        /// <param name="depsitDtlWrkArray">入金明細データの配列</param>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
        public static void DivisionRef(DepsitDataWork depsitDataWrk, ref DepsitMainWork depsitMainWrk, ref DepsitDtlWork[] depsitDtlWrkArray)
        {
            if (depsitDataWrk != null && depsitMainWrk != null && depsitDtlWrkArray != null)
            {
                # region [DepsitMainWork ← DepsitDataWork]
                depsitMainWrk.CreateDateTime = depsitDataWrk.CreateDateTime;              // 作成日時
                depsitMainWrk.UpdateDateTime = depsitDataWrk.UpdateDateTime;              // 更新日時
                depsitMainWrk.EnterpriseCode = depsitDataWrk.EnterpriseCode;              // 企業コード
                depsitMainWrk.FileHeaderGuid = depsitDataWrk.FileHeaderGuid;              // GUID
                depsitMainWrk.UpdEmployeeCode = depsitDataWrk.UpdEmployeeCode;            // 更新従業員コード
                depsitMainWrk.UpdAssemblyId1 = depsitDataWrk.UpdAssemblyId1;              // 更新アセンブリID1
                depsitMainWrk.UpdAssemblyId2 = depsitDataWrk.UpdAssemblyId2;              // 更新アセンブリID2
                depsitMainWrk.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;        // 論理削除区分
                depsitMainWrk.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;            // 受注ステータス
                depsitMainWrk.DepositDebitNoteCd = depsitDataWrk.DepositDebitNoteCd;      // 入金赤黒区分
                depsitMainWrk.DepositSlipNo = depsitDataWrk.DepositSlipNo;                // 入金伝票番号
                depsitMainWrk.SalesSlipNum = depsitDataWrk.SalesSlipNum;                  // 売上伝票番号
                depsitMainWrk.InputDepositSecCd = depsitDataWrk.InputDepositSecCd;        // 入金入力拠点コード
                depsitMainWrk.AddUpSecCode = depsitDataWrk.AddUpSecCode;                  // 計上拠点コード
                depsitMainWrk.UpdateSecCd = depsitDataWrk.UpdateSecCd;                    // 更新拠点コード
                depsitMainWrk.SubSectionCode = depsitDataWrk.SubSectionCode;              // 部門コード
                depsitMainWrk.InputDay = depsitDataWrk.InputDay;                          // 入力日付  //ADD 2009/03/25
                depsitMainWrk.DepositDate = depsitDataWrk.DepositDate;                    // 入金日付
                depsitMainWrk.PreDepositDate = depsitDataWrk.PreDepositDate;              // 前回入金日付 // ADD 2011/12/15
                depsitMainWrk.AddUpADate = depsitDataWrk.AddUpADate;                      // 計上日付
                depsitMainWrk.DepositTotal = depsitDataWrk.DepositTotal;                  // 入金計
                depsitMainWrk.Deposit = depsitDataWrk.Deposit;                            // 入金金額
                depsitMainWrk.FeeDeposit = depsitDataWrk.FeeDeposit;                      // 手数料入金額
                depsitMainWrk.DiscountDeposit = depsitDataWrk.DiscountDeposit;            // 値引入金額
                depsitMainWrk.AutoDepositCd = depsitDataWrk.AutoDepositCd;                // 自動入金区分
                depsitMainWrk.DraftDrawingDate = depsitDataWrk.DraftDrawingDate;          // 手形振出日
                depsitMainWrk.DraftKind = depsitDataWrk.DraftKind;                        // 手形種類
                depsitMainWrk.DraftKindName = depsitDataWrk.DraftKindName;                // 手形種類名称
                depsitMainWrk.DraftDivide = depsitDataWrk.DraftDivide;                    // 手形区分
                depsitMainWrk.DraftDivideName = depsitDataWrk.DraftDivideName;            // 手形区分名称
                depsitMainWrk.DraftNo = depsitDataWrk.DraftNo;                            // 手形番号
                depsitMainWrk.DepositAllowance = depsitDataWrk.DepositAllowance;          // 入金引当額
                depsitMainWrk.DepositAlwcBlnce = depsitDataWrk.DepositAlwcBlnce;          // 入金引当残高
                depsitMainWrk.DebitNoteLinkDepoNo = depsitDataWrk.DebitNoteLinkDepoNo;    // 赤黒入金連結番号
                depsitMainWrk.LastReconcileAddUpDt = depsitDataWrk.LastReconcileAddUpDt;  // 最終消し込み計上日
                depsitMainWrk.DepositAgentCode = depsitDataWrk.DepositAgentCode;          // 入金担当者コード
                depsitMainWrk.DepositAgentNm = depsitDataWrk.DepositAgentNm;              // 入金担当者名称
                depsitMainWrk.DepositInputAgentCd = depsitDataWrk.DepositInputAgentCd;    // 入金入力者コード
                depsitMainWrk.DepositInputAgentNm = depsitDataWrk.DepositInputAgentNm;    // 入金入力者名称
                depsitMainWrk.CustomerCode = depsitDataWrk.CustomerCode;                  // 得意先コード
                depsitMainWrk.CustomerName = depsitDataWrk.CustomerName;                  // 得意先名称
                depsitMainWrk.CustomerName2 = depsitDataWrk.CustomerName2;                // 得意先名称2
                depsitMainWrk.CustomerSnm = depsitDataWrk.CustomerSnm;                    // 得意先略称
                depsitMainWrk.ClaimCode = depsitDataWrk.ClaimCode;                        // 請求先コード
                depsitMainWrk.ClaimName = depsitDataWrk.ClaimName;                        // 請求先名称
                depsitMainWrk.ClaimName2 = depsitDataWrk.ClaimName2;                      // 請求先名称2
                depsitMainWrk.ClaimSnm = depsitDataWrk.ClaimSnm;                          // 請求先略称
                depsitMainWrk.Outline = depsitDataWrk.Outline;                            // 伝票摘要
                depsitMainWrk.BankCode = depsitDataWrk.BankCode;                          // 銀行コード
                depsitMainWrk.BankName = depsitDataWrk.BankName;                          // 銀行名称
                # endregion

                # region [DepsitDtlWork[] ← DepsitDataWork]

                ArrayList depsitDtlWrkList = new ArrayList();
                
                if (depsitDataWrk.DepositRowNo1 > 0)
                {
                    DepsitDtlWork depsitDtlWrk1 = new DepsitDtlWork();
                    depsitDtlWrk1.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk1.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk1.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk1.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk1.DepositRowNo = depsitDataWrk.DepositRowNo1;
                    depsitDtlWrk1.MoneyKindCode = depsitDataWrk.MoneyKindCode1;
                    depsitDtlWrk1.MoneyKindName = depsitDataWrk.MoneyKindName1;
                    depsitDtlWrk1.MoneyKindDiv = depsitDataWrk.MoneyKindDiv1;
                    depsitDtlWrk1.Deposit = depsitDataWrk.Deposit1;
                    depsitDtlWrk1.ValidityTerm = depsitDataWrk.ValidityTerm1;
                    depsitDtlWrkList.Add(depsitDtlWrk1);
                }
                if (depsitDataWrk.DepositRowNo2 > 0)
                {
                    DepsitDtlWork depsitDtlWrk2 = new DepsitDtlWork();
                    depsitDtlWrk2.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk2.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk2.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk2.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk2.DepositRowNo = depsitDataWrk.DepositRowNo2;
                    depsitDtlWrk2.MoneyKindCode = depsitDataWrk.MoneyKindCode2;
                    depsitDtlWrk2.MoneyKindName = depsitDataWrk.MoneyKindName2;
                    depsitDtlWrk2.MoneyKindDiv = depsitDataWrk.MoneyKindDiv2;
                    depsitDtlWrk2.Deposit = depsitDataWrk.Deposit2;
                    depsitDtlWrk2.ValidityTerm = depsitDataWrk.ValidityTerm2;
                    depsitDtlWrkList.Add(depsitDtlWrk2);
                }
                if (depsitDataWrk.DepositRowNo3 > 0)
                {
                    DepsitDtlWork depsitDtlWrk3 = new DepsitDtlWork();
                    depsitDtlWrk3.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk3.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk3.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk3.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk3.DepositRowNo = depsitDataWrk.DepositRowNo3;
                    depsitDtlWrk3.MoneyKindCode = depsitDataWrk.MoneyKindCode3;
                    depsitDtlWrk3.MoneyKindName = depsitDataWrk.MoneyKindName3;
                    depsitDtlWrk3.MoneyKindDiv = depsitDataWrk.MoneyKindDiv3;
                    depsitDtlWrk3.Deposit = depsitDataWrk.Deposit3;
                    depsitDtlWrk3.ValidityTerm = depsitDataWrk.ValidityTerm3;
                    depsitDtlWrkList.Add(depsitDtlWrk3);
                }
                if (depsitDataWrk.DepositRowNo4 > 0)
                {
                    DepsitDtlWork depsitDtlWrk4 = new DepsitDtlWork();
                    depsitDtlWrk4.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk4.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk4.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk4.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk4.DepositRowNo = depsitDataWrk.DepositRowNo4;
                    depsitDtlWrk4.MoneyKindCode = depsitDataWrk.MoneyKindCode4;
                    depsitDtlWrk4.MoneyKindName = depsitDataWrk.MoneyKindName4;
                    depsitDtlWrk4.MoneyKindDiv = depsitDataWrk.MoneyKindDiv4;
                    depsitDtlWrk4.Deposit = depsitDataWrk.Deposit4;
                    depsitDtlWrk4.ValidityTerm = depsitDataWrk.ValidityTerm4;
                    depsitDtlWrkList.Add(depsitDtlWrk4);
                }
                if (depsitDataWrk.DepositRowNo5 > 0)
                {
                    DepsitDtlWork depsitDtlWrk5 = new DepsitDtlWork();
                    depsitDtlWrk5.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk5.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk5.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk5.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk5.DepositRowNo = depsitDataWrk.DepositRowNo5;
                    depsitDtlWrk5.MoneyKindCode = depsitDataWrk.MoneyKindCode5;
                    depsitDtlWrk5.MoneyKindName = depsitDataWrk.MoneyKindName5;
                    depsitDtlWrk5.MoneyKindDiv = depsitDataWrk.MoneyKindDiv5;
                    depsitDtlWrk5.Deposit = depsitDataWrk.Deposit5;
                    depsitDtlWrk5.ValidityTerm = depsitDataWrk.ValidityTerm5;
                    depsitDtlWrkList.Add(depsitDtlWrk5);
                }
                if (depsitDataWrk.DepositRowNo6 > 0)
                {
                    DepsitDtlWork depsitDtlWrk6 = new DepsitDtlWork();
                    depsitDtlWrk6.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk6.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk6.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk6.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk6.DepositRowNo = depsitDataWrk.DepositRowNo6;
                    depsitDtlWrk6.MoneyKindCode = depsitDataWrk.MoneyKindCode6;
                    depsitDtlWrk6.MoneyKindName = depsitDataWrk.MoneyKindName6;
                    depsitDtlWrk6.MoneyKindDiv = depsitDataWrk.MoneyKindDiv6;
                    depsitDtlWrk6.Deposit = depsitDataWrk.Deposit6;
                    depsitDtlWrk6.ValidityTerm = depsitDataWrk.ValidityTerm6;
                    depsitDtlWrkList.Add(depsitDtlWrk6);
                }
                if (depsitDataWrk.DepositRowNo7 > 0)
                {
                    DepsitDtlWork depsitDtlWrk7 = new DepsitDtlWork();
                    depsitDtlWrk7.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk7.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk7.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk7.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk7.DepositRowNo = depsitDataWrk.DepositRowNo7;
                    depsitDtlWrk7.MoneyKindCode = depsitDataWrk.MoneyKindCode7;
                    depsitDtlWrk7.MoneyKindName = depsitDataWrk.MoneyKindName7;
                    depsitDtlWrk7.MoneyKindDiv = depsitDataWrk.MoneyKindDiv7;
                    depsitDtlWrk7.Deposit = depsitDataWrk.Deposit7;
                    depsitDtlWrk7.ValidityTerm = depsitDataWrk.ValidityTerm7;
                    depsitDtlWrkList.Add(depsitDtlWrk7);
                }
                if (depsitDataWrk.DepositRowNo8 > 0)
                {
                    DepsitDtlWork depsitDtlWrk8 = new DepsitDtlWork();
                    depsitDtlWrk8.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk8.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk8.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk8.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk8.DepositRowNo = depsitDataWrk.DepositRowNo8;
                    depsitDtlWrk8.MoneyKindCode = depsitDataWrk.MoneyKindCode8;
                    depsitDtlWrk8.MoneyKindName = depsitDataWrk.MoneyKindName8;
                    depsitDtlWrk8.MoneyKindDiv = depsitDataWrk.MoneyKindDiv8;
                    depsitDtlWrk8.Deposit = depsitDataWrk.Deposit8;
                    depsitDtlWrk8.ValidityTerm = depsitDataWrk.ValidityTerm8;
                    depsitDtlWrkList.Add(depsitDtlWrk8);
                }
                if (depsitDataWrk.DepositRowNo9 > 0)
                {
                    DepsitDtlWork depsitDtlWrk9 = new DepsitDtlWork();
                    depsitDtlWrk9.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk9.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk9.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk9.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk9.DepositRowNo = depsitDataWrk.DepositRowNo9;
                    depsitDtlWrk9.MoneyKindCode = depsitDataWrk.MoneyKindCode9;
                    depsitDtlWrk9.MoneyKindName = depsitDataWrk.MoneyKindName9;
                    depsitDtlWrk9.MoneyKindDiv = depsitDataWrk.MoneyKindDiv9;
                    depsitDtlWrk9.Deposit = depsitDataWrk.Deposit9;
                    depsitDtlWrk9.ValidityTerm = depsitDataWrk.ValidityTerm9;
                    depsitDtlWrkList.Add(depsitDtlWrk9);
                }
                if (depsitDataWrk.DepositRowNo10 > 0)
                {
                    DepsitDtlWork depsitDtlWrk10 = new DepsitDtlWork();
                    depsitDtlWrk10.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk10.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk10.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk10.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk10.DepositRowNo = depsitDataWrk.DepositRowNo10;
                    depsitDtlWrk10.MoneyKindCode = depsitDataWrk.MoneyKindCode10;
                    depsitDtlWrk10.MoneyKindName = depsitDataWrk.MoneyKindName10;
                    depsitDtlWrk10.MoneyKindDiv = depsitDataWrk.MoneyKindDiv10;
                    depsitDtlWrk10.Deposit = depsitDataWrk.Deposit10;
                    depsitDtlWrk10.ValidityTerm = depsitDataWrk.ValidityTerm10;
                    depsitDtlWrkList.Add(depsitDtlWrk10);
                }

                if (depsitDtlWrkList != null && depsitDtlWrkList.Count > 0)
                {
                    depsitDtlWrkArray = (DepsitDtlWork[])depsitDtlWrkList.ToArray(typeof(DepsitDtlWork));
                }
                # endregion
            }
        }


    }
}
