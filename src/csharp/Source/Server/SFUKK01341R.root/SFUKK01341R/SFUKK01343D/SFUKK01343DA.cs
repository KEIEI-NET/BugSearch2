using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region --- DEL 2008/06/26 M.Kubota ---
#if false
    /// public class name:   DepsitMainWork
    /// <summary>
    ///                      入金ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DepsitMainWork : IFileHeader
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

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;

        /// <summary>入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>入金金種コード</summary>
        private Int32 _depositKindCode;

        /// <summary>入金金種名称</summary>
        private string _depositKindName = "";

        /// <summary>入金金種区分</summary>
        private Int32 _depositKindDivCd;

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

        /// <summary>預り金区分</summary>
        /// <remarks>0:通常入金,1:預り金入金</remarks>
        private Int32 _depositCd;

        /// <summary>手形振出日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>手形支払期日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftPayTimeLimit;

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

        /// <summary>ＥＤＩ送信日</summary>
        private DateTime _ediSendDate;

        /// <summary>ＥＤＩ取込日</summary>
        private DateTime _ediTakeInDate;


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

        /// public propaty name  :  EdiSendDate
        /// <summary>ＥＤＩ送信日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdiSendDate
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
        public DateTime EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }


        /// <summary>
        /// 入金ワークコンストラクタ
        /// </summary>
        /// <returns>DepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepsitMainWork()
        {
        }
        /// <summary>
        /// 入金マスタコンストラクタ
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
        /// <param name="minSectionCode">課コード</param>
        /// <param name="depositDate">入金日付(YYYYMMDD)</param>
        /// <param name="addUpADate">計上日付(YYYYMMDD)</param>
        /// <param name="depositKindCode">入金金種コード</param>
        /// <param name="depositKindName">入金金種名称</param>
        /// <param name="depositKindDivCd">入金金種区分</param>
        /// <param name="depositTotal">入金計</param>
        /// <param name="deposit">入金金額(値引・手数料を除いた額)</param>
        /// <param name="feeDeposit">手数料入金額</param>
        /// <param name="discountDeposit">値引入金額</param>
        /// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
        /// <param name="depositCd">預り金区分(0:通常入金,1:預り金入金)</param>
        /// <param name="draftDrawingDate">手形振出日(YYYYMMDD)</param>
        /// <param name="draftPayTimeLimit">手形支払期日(YYYYMMDD)</param>
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
        /// <param name="ediSendDate">ＥＤＩ送信日</param>
        /// <param name="ediTakeInDate">ＥＤＩ取込日</param>
        /// <returns>DepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepsitMainWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, Int32 depositDebitNoteCd, Int32 depositSlipNo, string salesSlipNum, string inputDepositSecCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, Int32 minSectionCode, DateTime depositDate, DateTime addUpADate, Int32 depositKindCode, string depositKindName, Int32 depositKindDivCd, Int64 depositTotal, Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, Int32 autoDepositCd, Int32 depositCd, DateTime draftDrawingDate, DateTime draftPayTimeLimit, Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, string draftNo, Int64 depositAllowance, Int64 depositAlwcBlnce, Int32 debitNoteLinkDepoNo, DateTime lastReconcileAddUpDt, string depositAgentCode, string depositAgentNm, string depositInputAgentCd, string depositInputAgentNm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 claimCode, string claimName, string claimName2, string claimSnm, string outline, Int32 bankCode, string bankName, DateTime ediSendDate, DateTime ediTakeInDate)
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
            this._minSectionCode = minSectionCode;
            this.DepositDate = depositDate;
            this.AddUpADate = addUpADate;
            this._depositKindCode = depositKindCode;
            this._depositKindName = depositKindName;
            this._depositKindDivCd = depositKindDivCd;
            this._depositTotal = depositTotal;
            this._deposit = deposit;
            this._feeDeposit = feeDeposit;
            this._discountDeposit = discountDeposit;
            this._autoDepositCd = autoDepositCd;
            this._depositCd = depositCd;
            this.DraftDrawingDate = draftDrawingDate;
            this.DraftPayTimeLimit = draftPayTimeLimit;
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
            this.EdiSendDate = ediSendDate;
            this._ediTakeInDate = ediTakeInDate;

        }

        /// <summary>
        /// 入金マスタ複製処理
        /// </summary>
        /// <returns>DepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいDepsitMainWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepsitMainWork Clone()
        {
            return new DepsitMainWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._depositDebitNoteCd, this._depositSlipNo, this._salesSlipNum, this._inputDepositSecCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._minSectionCode, this._depositDate, this._addUpADate, this._depositKindCode, this._depositKindName, this._depositKindDivCd, this._depositTotal, this._deposit, this._feeDeposit, this._discountDeposit, this._autoDepositCd, this._depositCd, this._draftDrawingDate, this._draftPayTimeLimit, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._depositAllowance, this._depositAlwcBlnce, this._debitNoteLinkDepoNo, this._lastReconcileAddUpDt, this._depositAgentCode, this._depositAgentNm, this._depositInputAgentCd, this._depositInputAgentNm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._outline, this._bankCode, this._bankName, this._ediSendDate, this._ediTakeInDate);
        }

        /// <summary>
        /// 入金マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のDepsitMainWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(DepsitMainWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.DepositDebitNoteCd == target.DepositDebitNoteCd)
                 && (this.DepositSlipNo == target.DepositSlipNo)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.InputDepositSecCd == target.InputDepositSecCd)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.MinSectionCode == target.MinSectionCode)
                 && (this.DepositDate == target.DepositDate)
                 && (this.AddUpADate == target.AddUpADate)
                 && (this.DepositKindCode == target.DepositKindCode)
                 && (this.DepositKindName == target.DepositKindName)
                 && (this.DepositKindDivCd == target.DepositKindDivCd)
                 && (this.DepositTotal == target.DepositTotal)
                 && (this.Deposit == target.Deposit)
                 && (this.FeeDeposit == target.FeeDeposit)
                 && (this.DiscountDeposit == target.DiscountDeposit)
                 && (this.AutoDepositCd == target.AutoDepositCd)
                 && (this.DepositCd == target.DepositCd)
                 && (this.DraftDrawingDate == target.DraftDrawingDate)
                 && (this.DraftPayTimeLimit == target.DraftPayTimeLimit)
                 && (this.DraftKind == target.DraftKind)
                 && (this.DraftKindName == target.DraftKindName)
                 && (this.DraftDivide == target.DraftDivide)
                 && (this.DraftDivideName == target.DraftDivideName)
                 && (this.DraftNo == target.DraftNo)
                 && (this.DepositAllowance == target.DepositAllowance)
                 && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
                 && (this.DebitNoteLinkDepoNo == target.DebitNoteLinkDepoNo)
                 && (this.LastReconcileAddUpDt == target.LastReconcileAddUpDt)
                 && (this.DepositAgentCode == target.DepositAgentCode)
                 && (this.DepositAgentNm == target.DepositAgentNm)
                 && (this.DepositInputAgentCd == target.DepositInputAgentCd)
                 && (this.DepositInputAgentNm == target.DepositInputAgentNm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.Outline == target.Outline)
                 && (this.BankCode == target.BankCode)
                 && (this.BankName == target.BankName)
                 && (this.EdiSendDate == target.EdiSendDate)
                 && (this.EdiTakeInDate == target.EdiTakeInDate));
        }

        /// <summary>
        /// 入金マスタ比較処理
        /// </summary>
        /// <param name="depsitMain1">
        ///                    比較するDepsitMainWorkクラスのインスタンス
        /// </param>
        /// <param name="depsitMain2">比較するDepsitMainWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(DepsitMainWork depsitMain1, DepsitMainWork depsitMain2)
		{
			return ((depsitMain1.CreateDateTime == depsitMain2.CreateDateTime)
				 && (depsitMain1.UpdateDateTime == depsitMain2.UpdateDateTime)
				 && (depsitMain1.EnterpriseCode == depsitMain2.EnterpriseCode)
				 && (depsitMain1.FileHeaderGuid == depsitMain2.FileHeaderGuid)
				 && (depsitMain1.UpdEmployeeCode == depsitMain2.UpdEmployeeCode)
				 && (depsitMain1.UpdAssemblyId1 == depsitMain2.UpdAssemblyId1)
				 && (depsitMain1.UpdAssemblyId2 == depsitMain2.UpdAssemblyId2)
				 && (depsitMain1.LogicalDeleteCode == depsitMain2.LogicalDeleteCode)
				 && (depsitMain1.AcptAnOdrStatus == depsitMain2.AcptAnOdrStatus)
				 && (depsitMain1.DepositDebitNoteCd == depsitMain2.DepositDebitNoteCd)
				 && (depsitMain1.DepositSlipNo == depsitMain2.DepositSlipNo)
				 && (depsitMain1.SalesSlipNum == depsitMain2.SalesSlipNum)
				 && (depsitMain1.InputDepositSecCd == depsitMain2.InputDepositSecCd)
				 && (depsitMain1.AddUpSecCode == depsitMain2.AddUpSecCode)
				 && (depsitMain1.UpdateSecCd == depsitMain2.UpdateSecCd)
				 && (depsitMain1.SubSectionCode == depsitMain2.SubSectionCode)
				 && (depsitMain1.MinSectionCode == depsitMain2.MinSectionCode)
				 && (depsitMain1.DepositDate == depsitMain2.DepositDate)
				 && (depsitMain1.AddUpADate == depsitMain2.AddUpADate)
				 && (depsitMain1.DepositKindCode == depsitMain2.DepositKindCode)
				 && (depsitMain1.DepositKindName == depsitMain2.DepositKindName)
				 && (depsitMain1.DepositKindDivCd == depsitMain2.DepositKindDivCd)
				 && (depsitMain1.DepositTotal == depsitMain2.DepositTotal)
				 && (depsitMain1.Deposit == depsitMain2.Deposit)
				 && (depsitMain1.FeeDeposit == depsitMain2.FeeDeposit)
				 && (depsitMain1.DiscountDeposit == depsitMain2.DiscountDeposit)
				 && (depsitMain1.AutoDepositCd == depsitMain2.AutoDepositCd)
				 && (depsitMain1.DepositCd == depsitMain2.DepositCd)
				 && (depsitMain1.DraftDrawingDate == depsitMain2.DraftDrawingDate)
				 && (depsitMain1.DraftPayTimeLimit == depsitMain2.DraftPayTimeLimit)
				 && (depsitMain1.DraftKind == depsitMain2.DraftKind)
				 && (depsitMain1.DraftKindName == depsitMain2.DraftKindName)
				 && (depsitMain1.DraftDivide == depsitMain2.DraftDivide)
				 && (depsitMain1.DraftDivideName == depsitMain2.DraftDivideName)
				 && (depsitMain1.DraftNo == depsitMain2.DraftNo)
				 && (depsitMain1.DepositAllowance == depsitMain2.DepositAllowance)
				 && (depsitMain1.DepositAlwcBlnce == depsitMain2.DepositAlwcBlnce)
				 && (depsitMain1.DebitNoteLinkDepoNo == depsitMain2.DebitNoteLinkDepoNo)
				 && (depsitMain1.LastReconcileAddUpDt == depsitMain2.LastReconcileAddUpDt)
				 && (depsitMain1.DepositAgentCode == depsitMain2.DepositAgentCode)
				 && (depsitMain1.DepositAgentNm == depsitMain2.DepositAgentNm)
				 && (depsitMain1.DepositInputAgentCd == depsitMain2.DepositInputAgentCd)
				 && (depsitMain1.DepositInputAgentNm == depsitMain2.DepositInputAgentNm)
				 && (depsitMain1.CustomerCode == depsitMain2.CustomerCode)
				 && (depsitMain1.CustomerName == depsitMain2.CustomerName)
				 && (depsitMain1.CustomerName2 == depsitMain2.CustomerName2)
				 && (depsitMain1.CustomerSnm == depsitMain2.CustomerSnm)
				 && (depsitMain1.ClaimCode == depsitMain2.ClaimCode)
				 && (depsitMain1.ClaimName == depsitMain2.ClaimName)
				 && (depsitMain1.ClaimName2 == depsitMain2.ClaimName2)
				 && (depsitMain1.ClaimSnm == depsitMain2.ClaimSnm)
				 && (depsitMain1.Outline == depsitMain2.Outline)
				 && (depsitMain1.BankCode == depsitMain2.BankCode)
				 && (depsitMain1.BankName == depsitMain2.BankName)
				 && (depsitMain1.EdiSendDate == depsitMain2.EdiSendDate)
				 && (depsitMain1.EdiTakeInDate == depsitMain2.EdiTakeInDate));
		}
        /// <summary>
        /// 入金マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のDepsitMainWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(DepsitMainWork target)
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
            if (this.MinSectionCode != target.MinSectionCode) resList.Add("MinSectionCode");
            if (this.DepositDate != target.DepositDate) resList.Add("DepositDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.DepositKindCode != target.DepositKindCode) resList.Add("DepositKindCode");
            if (this.DepositKindName != target.DepositKindName) resList.Add("DepositKindName");
            if (this.DepositKindDivCd != target.DepositKindDivCd) resList.Add("DepositKindDivCd");
            if (this.DepositTotal != target.DepositTotal) resList.Add("DepositTotal");
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.FeeDeposit != target.FeeDeposit) resList.Add("FeeDeposit");
            if (this.DiscountDeposit != target.DiscountDeposit) resList.Add("DiscountDeposit");
            if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
            if (this.DepositCd != target.DepositCd) resList.Add("DepositCd");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.DraftPayTimeLimit != target.DraftPayTimeLimit) resList.Add("DraftPayTimeLimit");
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
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");

            return resList;
        }

        /// <summary>
        /// 入金マスタ比較処理
        /// </summary>
        /// <param name="depsitMain1">比較するDepsitMainWorkクラスのインスタンス</param>
        /// <param name="depsitMain2">比較するDepsitMainWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(DepsitMainWork depsitMain1, DepsitMainWork depsitMain2)
        {
            ArrayList resList = new ArrayList();
            if (depsitMain1.CreateDateTime != depsitMain2.CreateDateTime) resList.Add("CreateDateTime");
            if (depsitMain1.UpdateDateTime != depsitMain2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (depsitMain1.EnterpriseCode != depsitMain2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (depsitMain1.FileHeaderGuid != depsitMain2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (depsitMain1.UpdEmployeeCode != depsitMain2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (depsitMain1.UpdAssemblyId1 != depsitMain2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (depsitMain1.UpdAssemblyId2 != depsitMain2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (depsitMain1.LogicalDeleteCode != depsitMain2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (depsitMain1.AcptAnOdrStatus != depsitMain2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (depsitMain1.DepositDebitNoteCd != depsitMain2.DepositDebitNoteCd) resList.Add("DepositDebitNoteCd");
            if (depsitMain1.DepositSlipNo != depsitMain2.DepositSlipNo) resList.Add("DepositSlipNo");
            if (depsitMain1.SalesSlipNum != depsitMain2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (depsitMain1.InputDepositSecCd != depsitMain2.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (depsitMain1.AddUpSecCode != depsitMain2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (depsitMain1.UpdateSecCd != depsitMain2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (depsitMain1.SubSectionCode != depsitMain2.SubSectionCode) resList.Add("SubSectionCode");
            if (depsitMain1.MinSectionCode != depsitMain2.MinSectionCode) resList.Add("MinSectionCode");
            if (depsitMain1.DepositDate != depsitMain2.DepositDate) resList.Add("DepositDate");
            if (depsitMain1.AddUpADate != depsitMain2.AddUpADate) resList.Add("AddUpADate");
            if (depsitMain1.DepositKindCode != depsitMain2.DepositKindCode) resList.Add("DepositKindCode");
            if (depsitMain1.DepositKindName != depsitMain2.DepositKindName) resList.Add("DepositKindName");
            if (depsitMain1.DepositKindDivCd != depsitMain2.DepositKindDivCd) resList.Add("DepositKindDivCd");
            if (depsitMain1.DepositTotal != depsitMain2.DepositTotal) resList.Add("DepositTotal");
            if (depsitMain1.Deposit != depsitMain2.Deposit) resList.Add("Deposit");
            if (depsitMain1.FeeDeposit != depsitMain2.FeeDeposit) resList.Add("FeeDeposit");
            if (depsitMain1.DiscountDeposit != depsitMain2.DiscountDeposit) resList.Add("DiscountDeposit");
            if (depsitMain1.AutoDepositCd != depsitMain2.AutoDepositCd) resList.Add("AutoDepositCd");
            if (depsitMain1.DepositCd != depsitMain2.DepositCd) resList.Add("DepositCd");
            if (depsitMain1.DraftDrawingDate != depsitMain2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (depsitMain1.DraftPayTimeLimit != depsitMain2.DraftPayTimeLimit) resList.Add("DraftPayTimeLimit");
            if (depsitMain1.DraftKind != depsitMain2.DraftKind) resList.Add("DraftKind");
            if (depsitMain1.DraftKindName != depsitMain2.DraftKindName) resList.Add("DraftKindName");
            if (depsitMain1.DraftDivide != depsitMain2.DraftDivide) resList.Add("DraftDivide");
            if (depsitMain1.DraftDivideName != depsitMain2.DraftDivideName) resList.Add("DraftDivideName");
            if (depsitMain1.DraftNo != depsitMain2.DraftNo) resList.Add("DraftNo");
            if (depsitMain1.DepositAllowance != depsitMain2.DepositAllowance) resList.Add("DepositAllowance");
            if (depsitMain1.DepositAlwcBlnce != depsitMain2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (depsitMain1.DebitNoteLinkDepoNo != depsitMain2.DebitNoteLinkDepoNo) resList.Add("DebitNoteLinkDepoNo");
            if (depsitMain1.LastReconcileAddUpDt != depsitMain2.LastReconcileAddUpDt) resList.Add("LastReconcileAddUpDt");
            if (depsitMain1.DepositAgentCode != depsitMain2.DepositAgentCode) resList.Add("DepositAgentCode");
            if (depsitMain1.DepositAgentNm != depsitMain2.DepositAgentNm) resList.Add("DepositAgentNm");
            if (depsitMain1.DepositInputAgentCd != depsitMain2.DepositInputAgentCd) resList.Add("DepositInputAgentCd");
            if (depsitMain1.DepositInputAgentNm != depsitMain2.DepositInputAgentNm) resList.Add("DepositInputAgentNm");
            if (depsitMain1.CustomerCode != depsitMain2.CustomerCode) resList.Add("CustomerCode");
            if (depsitMain1.CustomerName != depsitMain2.CustomerName) resList.Add("CustomerName");
            if (depsitMain1.CustomerName2 != depsitMain2.CustomerName2) resList.Add("CustomerName2");
            if (depsitMain1.CustomerSnm != depsitMain2.CustomerSnm) resList.Add("CustomerSnm");
            if (depsitMain1.ClaimCode != depsitMain2.ClaimCode) resList.Add("ClaimCode");
            if (depsitMain1.ClaimName != depsitMain2.ClaimName) resList.Add("ClaimName");
            if (depsitMain1.ClaimName2 != depsitMain2.ClaimName2) resList.Add("ClaimName2");
            if (depsitMain1.ClaimSnm != depsitMain2.ClaimSnm) resList.Add("ClaimSnm");
            if (depsitMain1.Outline != depsitMain2.Outline) resList.Add("Outline");
            if (depsitMain1.BankCode != depsitMain2.BankCode) resList.Add("BankCode");
            if (depsitMain1.BankName != depsitMain2.BankName) resList.Add("BankName");
            if (depsitMain1.EdiSendDate != depsitMain2.EdiSendDate) resList.Add("EdiSendDate");
            if (depsitMain1.EdiTakeInDate != depsitMain2.EdiTakeInDate) resList.Add("EdiTakeInDate");

            return resList;
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DepsitMainWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DepsitMainWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DepsitMainWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DepsitMainWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DepsitMainWork || graph is ArrayList || graph is DepsitMainWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DepsitMainWork).FullName));

            if (graph != null && graph is DepsitMainWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DepsitMainWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DepsitMainWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DepsitMainWork[])graph).Length;
            }
            else if (graph is DepsitMainWork)
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
            //課コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //入金日付
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //入金金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositKindCode
            //入金金種名称
            serInfo.MemberInfo.Add(typeof(string)); //DepositKindName
            //入金金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositKindDivCd
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
            //預り金区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositCd
            //手形振出日
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //手形支払期日
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftPayTimeLimit
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
            //ＥＤＩ送信日
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiSendDate
            //ＥＤＩ取込日
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiTakeInDate


            serInfo.Serialize(writer, serInfo);
            if (graph is DepsitMainWork)
            {
                DepsitMainWork temp = (DepsitMainWork)graph;

                SetDepsitMainWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DepsitMainWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DepsitMainWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DepsitMainWork temp in lst)
                {
                    SetDepsitMainWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DepsitMainWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 56;

        /// <summary>
        ///  DepsitMainWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetDepsitMainWork(System.IO.BinaryWriter writer, DepsitMainWork temp)
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
            //課コード
            writer.Write(temp.MinSectionCode);
            //入金日付
            writer.Write((Int64)temp.DepositDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //入金金種コード
            writer.Write(temp.DepositKindCode);
            //入金金種名称
            writer.Write(temp.DepositKindName);
            //入金金種区分
            writer.Write(temp.DepositKindDivCd);
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
            //預り金区分
            writer.Write(temp.DepositCd);
            //手形振出日
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //手形支払期日
            writer.Write((Int64)temp.DraftPayTimeLimit.Ticks);
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
            //ＥＤＩ送信日
            writer.Write((Int64)temp.EdiSendDate.Ticks);
            //ＥＤＩ取込日
            writer.Write((Int64)temp.EdiTakeInDate.Ticks);

        }

        /// <summary>
        ///  DepsitMainWorkインスタンス取得
        /// </summary>
        /// <returns>DepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DepsitMainWork GetDepsitMainWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DepsitMainWork temp = new DepsitMainWork();

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
            //課コード
            temp.MinSectionCode = reader.ReadInt32();
            //入金日付
            temp.DepositDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //入金金種コード
            temp.DepositKindCode = reader.ReadInt32();
            //入金金種名称
            temp.DepositKindName = reader.ReadString();
            //入金金種区分
            temp.DepositKindDivCd = reader.ReadInt32();
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
            //預り金区分
            temp.DepositCd = reader.ReadInt32();
            //手形振出日
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //手形支払期日
            temp.DraftPayTimeLimit = new DateTime(reader.ReadInt64());
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
            //ＥＤＩ送信日
            temp.EdiSendDate = new DateTime(reader.ReadInt64());
            //ＥＤＩ取込日
            temp.EdiTakeInDate = new DateTime(reader.ReadInt64());


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
        /// <returns>DepsitMainWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DepsitMainWork temp = GetDepsitMainWork(reader, serInfo);
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
                    retValue = (DepsitMainWork[])lst.ToArray(typeof(DepsitMainWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
# endif
    # endregion

    /// public class name:   DepsitMainWork
    /// <summary>
    ///                      入金ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/30  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   入金計を復活（誤削除）</br>
    /// <br>Update Note      :   2008/7/2  長内</br>
    /// <br>                 :   ○項目追加（誤削除）</br>
    /// <br>                 :   入金引当額、入金引当残高</br>
    /// <br>Update Note      :   2008/7/9  長内</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   預り金区分</br>
    /// <br>Update Note      :   2011/12/15 tianjw</br>
    /// <br>                     Redmine#27390 拠点管理/売上日のチェック</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DepsitMainWork : IFileHeader
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

        // ----- ADD 2011/12/15 ------->>>>>
        /// <summary>前回入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _preDepositDate;
        // ----- ADD 2011/12/15 -------<<<<<

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

        // ----- ADD 2011/12/15 ---------------------------------->>>>>
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
        // ----- ADD 2011/12/15 ----------------------------------<<<<<

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


        /// <summary>
        /// 入金ワークコンストラクタ
        /// </summary>
        /// <returns>DepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepsitMainWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DepsitMainWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DepsitMainWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DepsitMainWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DepsitMainWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DepsitMainWork || graph is ArrayList || graph is DepsitMainWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DepsitMainWork).FullName));

            if (graph != null && graph is DepsitMainWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DepsitMainWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DepsitMainWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DepsitMainWork[])graph).Length;
            }
            else if (graph is DepsitMainWork)
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
            serInfo.MemberInfo.Add(typeof(Int32)); //PreDepositDate
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


            serInfo.Serialize(writer, serInfo);
            if (graph is DepsitMainWork)
            {
                DepsitMainWork temp = (DepsitMainWork)graph;

                SetDepsitMainWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DepsitMainWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DepsitMainWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DepsitMainWork temp in lst)
                {
                    SetDepsitMainWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DepsitMainWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 49; // DEL 2011/12/15
        private const int currentMemberCount = 50; // ADD 2011/12/15

        /// <summary>
        ///  DepsitMainWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetDepsitMainWork(System.IO.BinaryWriter writer, DepsitMainWork temp)
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

        }

        /// <summary>
        ///  DepsitMainWorkインスタンス取得
        /// </summary>
        /// <returns>DepsitMainWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DepsitMainWork GetDepsitMainWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DepsitMainWork temp = new DepsitMainWork();

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
        /// <returns>DepsitMainWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DepsitMainWork temp = GetDepsitMainWork(reader, serInfo);
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
                    retValue = (DepsitMainWork[])lst.ToArray(typeof(DepsitMainWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
