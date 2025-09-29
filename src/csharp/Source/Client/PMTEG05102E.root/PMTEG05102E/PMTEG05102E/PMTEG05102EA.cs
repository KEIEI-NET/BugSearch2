//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受取手形データ
// プログラム概要   : 受取手形データを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RcvDraftData
    /// <summary>
    ///                      受取手形データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   受取手形データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2010/04/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/10  杉村</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   カラーコード</br>
    /// <br>                 :   カラー名称1</br>
    /// <br>                 :   トリムコード</br>
    /// <br>                 :   トリム名称</br>
    /// <br>Update Note      :   2008/6/30  長内</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   装備オブジェクト配列</br>
    /// <br>Update Note      :   2008/7/8  杉村</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   原動機型式（エンジン）</br>
    /// <br>Update Note      :   2008/9/19  長内</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   メーカー半角名称</br>
    /// <br>                 :   車種半角名称</br>
    /// <br>Update Note      :   2008/12/17  杉村</br>
    /// <br>                 :   項目修正（ＮＵＬＬ許可に変更）</br>
    /// <br>                 :   型式（類別記号）、型式（フル型）</br>
    /// <br>Update Note      :   2009/9/1  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   　車輌追加情報１</br>
    /// <br>                 :   　車輌追加情報２</br>
    /// <br>                 :   　車輌備考</br>
    /// </remarks>
    public class RcvDraftData
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

        /// <summary>受取手形番号</summary>
        private string _rcvDraftNo = "";

        /// <summary>手形種別</summary>
        /// <remarks>0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済</remarks>
        private Int32 _draftKindCd;

        /// <summary>手形区分</summary>
        /// <remarks>0:自振 1:他振　※旧自他振区分</remarks>
        private Int32 _draftDivide;

        /// <summary>入金金額</summary>
        /// <remarks>値引・手数料を除いた額</remarks>
        private Int64 _deposit;

        /// <summary>銀行・支店コード</summary>
        /// <remarks>頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ</remarks>
        private Int32 _bankAndBranchCd;

        /// <summary>銀行・支店名称</summary>
        private string _bankAndBranchNm = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>※子でも手形ﾃﾞｰﾀが作成可なので必要</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>処理日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _procDate;

        /// <summary>手形振出日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>有効期限</summary>
        /// <remarks>YYYYMMDD　※期日、満期日として使用</remarks>
        private Int32 _validityTerm;

        /// <summary>手形決済日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _draftStmntDate;

        /// <summary>伝票摘要1</summary>
        private string _outline1 = "";

        /// <summary>伝票摘要2</summary>
        private string _outline2 = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>入金伝票番号</summary>
        private Int32 _depositSlipNo;

        /// <summary>入金行番号</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _depositRowNo;

        /// <summary>入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

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

        /// public propaty name  :  RcvDraftNo
        /// <summary>受取手形番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受取手形番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RcvDraftNo
        {
            get { return _rcvDraftNo; }
            set { _rcvDraftNo = value; }
        }

        /// public propaty name  :  DraftKindCd
        /// <summary>手形種別プロパティ</summary>
        /// <value>0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftKindCd
        {
            get { return _draftKindCd; }
            set { _draftKindCd = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>手形区分プロパティ</summary>
        /// <value>0:自振 1:他振　※旧自他振区分</value>
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

        /// public propaty name  :  BankAndBranchCd
        /// <summary>銀行・支店コードプロパティ</summary>
        /// <value>頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行・支店コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BankAndBranchCd
        {
            get { return _bankAndBranchCd; }
            set { _bankAndBranchCd = value; }
        }

        /// public propaty name  :  BankAndBranchNm
        /// <summary>銀行・支店名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行・支店名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BankAndBranchNm
        {
            get { return _bankAndBranchNm; }
            set { _bankAndBranchNm = value; }
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
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>※子でも手形ﾃﾞｰﾀが作成可なので必要</value>
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

        /// public propaty name  :  ProcDate
        /// <summary>処理日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDate
        {
            get { return _procDate; }
            set { _procDate = value; }
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

        /// public propaty name  :  ValidityTerm
        /// <summary>有効期限プロパティ</summary>
        /// <value>YYYYMMDD　※期日、満期日として使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }

        /// public propaty name  :  DraftStmntDate
        /// <summary>手形決済日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形決済日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftStmntDate
        {
            get { return _draftStmntDate; }
            set { _draftStmntDate = value; }
        }

        /// public propaty name  :  Outline1
        /// <summary>伝票摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline1
        {
            get { return _outline1; }
            set { _outline1 = value; }
        }

        /// public propaty name  :  Outline2
        /// <summary>伝票摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline2
        {
            get { return _outline2; }
            set { _outline2 = value; }
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

        /// public propaty name  :  DepositRowNo
        /// <summary>入金行番号プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositRowNo
        {
            get { return _depositRowNo; }
            set { _depositRowNo = value; }
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
        /// 受取手形データコンストラクタ
        /// </summary>
        /// <returns>RcvDraftDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RcvDraftDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RcvDraftData()
        {
        }

        /// <summary>
        /// 受取手形データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="rcvDraftNo">受取手形番号</param>
        /// <param name="draftKindCd">手形種別(0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済)</param>
        /// <param name="draftDivide">手形区分(0:自振 1:他振　※旧自他振区分)</param>
        /// <param name="deposit">入金金額(値引・手数料を除いた額)</param>
        /// <param name="bankAndBranchCd">銀行・支店コード(頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ)</param>
        /// <param name="bankAndBranchNm">銀行・支店名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addUpSecCode">計上拠点コード(※子でも手形ﾃﾞｰﾀが作成可なので必要)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <param name="customerName2">得意先名称2</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="procDate">処理日(YYYYMMDD)</param>
        /// <param name="draftDrawingDate">手形振出日(YYYYMMDD)</param>
        /// <param name="validityTerm">有効期限(YYYYMMDD　※期日、満期日として使用)</param>
        /// <param name="draftStmntDate">手形決済日(YYYYMMDD)</param>
        /// <param name="outline1">伝票摘要1</param>
        /// <param name="outline2">伝票摘要2</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="depositSlipNo">入金伝票番号</param>
        /// <param name="depositRowNo">入金行番号(※入金設定金種コードの設定番号をセット)</param>
        /// <param name="depositDate">入金日付(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <returns>RcvDraftDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RcvDraftDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RcvDraftData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string rcvDraftNo, Int32 draftKindCd, Int32 draftDivide, Int64 deposit, Int32 bankAndBranchCd, string bankAndBranchNm, string sectionCode, string addUpSecCode, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 procDate, DateTime draftDrawingDate, Int32 validityTerm, Int32 draftStmntDate, string outline1, string outline2, Int32 acptAnOdrStatus, Int32 depositSlipNo, Int32 depositRowNo, DateTime depositDate, string enterpriseName, string updEmployeeName, string addUpSecName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._rcvDraftNo = rcvDraftNo;
            this._draftKindCd = draftKindCd;
            this._draftDivide = draftDivide;
            this._deposit = deposit;
            this._bankAndBranchCd = bankAndBranchCd;
            this._bankAndBranchNm = bankAndBranchNm;
            this._sectionCode = sectionCode;
            this._addUpSecCode = addUpSecCode;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._procDate = procDate;
            this.DraftDrawingDate = draftDrawingDate;
            this._validityTerm = validityTerm;
            this._draftStmntDate = draftStmntDate;
            this._outline1 = outline1;
            this._outline2 = outline2;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._depositSlipNo = depositSlipNo;
            this._depositRowNo = depositRowNo;
            this.DepositDate = depositDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// 受取手形データ複製処理
        /// </summary>
        /// <returns>RcvDraftDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRcvDraftDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RcvDraftData Clone()
        {
            return new RcvDraftData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._rcvDraftNo, this._draftKindCd, this._draftDivide, this._deposit, this._bankAndBranchCd, this._bankAndBranchNm, this._sectionCode, this._addUpSecCode, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._procDate, this._draftDrawingDate, this._validityTerm, this._draftStmntDate, this._outline1, this._outline2, this._acptAnOdrStatus, this._depositSlipNo, this._depositRowNo, this._depositDate, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
        }

        /// <summary>
        /// 受取手形データ比較処理
        /// </summary>
        /// <param name="target">比較対象のRcvDraftDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RcvDraftDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RcvDraftData target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.RcvDraftNo == target.RcvDraftNo)
                 && (this.DraftKindCd == target.DraftKindCd)
                 && (this.DraftDivide == target.DraftDivide)
                 && (this.Deposit == target.Deposit)
                 && (this.BankAndBranchCd == target.BankAndBranchCd)
                 && (this.BankAndBranchNm == target.BankAndBranchNm)
                 && (this.SectionCode == target.SectionCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.ProcDate == target.ProcDate)
                 && (this.DraftDrawingDate == target.DraftDrawingDate)
                 && (this.ValidityTerm == target.ValidityTerm)
                 && (this.DraftStmntDate == target.DraftStmntDate)
                 && (this.Outline1 == target.Outline1)
                 && (this.Outline2 == target.Outline2)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.DepositSlipNo == target.DepositSlipNo)
                 && (this.DepositRowNo == target.DepositRowNo)
                 && (this.DepositDate == target.DepositDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// 受取手形データ比較処理
        /// </summary>
        /// <param name="rcvDraftData1">
        ///                    比較するRcvDraftDataクラスのインスタンス
        /// </param>
        /// <param name="rcvDraftData2">比較するRcvDraftDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RcvDraftDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RcvDraftData rcvDraftData1, RcvDraftData rcvDraftData2)
        {
            return ((rcvDraftData1.CreateDateTime == rcvDraftData2.CreateDateTime)
                 && (rcvDraftData1.UpdateDateTime == rcvDraftData2.UpdateDateTime)
                 && (rcvDraftData1.EnterpriseCode == rcvDraftData2.EnterpriseCode)
                 && (rcvDraftData1.FileHeaderGuid == rcvDraftData2.FileHeaderGuid)
                 && (rcvDraftData1.UpdEmployeeCode == rcvDraftData2.UpdEmployeeCode)
                 && (rcvDraftData1.UpdAssemblyId1 == rcvDraftData2.UpdAssemblyId1)
                 && (rcvDraftData1.UpdAssemblyId2 == rcvDraftData2.UpdAssemblyId2)
                 && (rcvDraftData1.LogicalDeleteCode == rcvDraftData2.LogicalDeleteCode)
                 && (rcvDraftData1.RcvDraftNo == rcvDraftData2.RcvDraftNo)
                 && (rcvDraftData1.DraftKindCd == rcvDraftData2.DraftKindCd)
                 && (rcvDraftData1.DraftDivide == rcvDraftData2.DraftDivide)
                 && (rcvDraftData1.Deposit == rcvDraftData2.Deposit)
                 && (rcvDraftData1.BankAndBranchCd == rcvDraftData2.BankAndBranchCd)
                 && (rcvDraftData1.BankAndBranchNm == rcvDraftData2.BankAndBranchNm)
                 && (rcvDraftData1.SectionCode == rcvDraftData2.SectionCode)
                 && (rcvDraftData1.AddUpSecCode == rcvDraftData2.AddUpSecCode)
                 && (rcvDraftData1.CustomerCode == rcvDraftData2.CustomerCode)
                 && (rcvDraftData1.CustomerName == rcvDraftData2.CustomerName)
                 && (rcvDraftData1.CustomerName2 == rcvDraftData2.CustomerName2)
                 && (rcvDraftData1.CustomerSnm == rcvDraftData2.CustomerSnm)
                 && (rcvDraftData1.ProcDate == rcvDraftData2.ProcDate)
                 && (rcvDraftData1.DraftDrawingDate == rcvDraftData2.DraftDrawingDate)
                 && (rcvDraftData1.ValidityTerm == rcvDraftData2.ValidityTerm)
                 && (rcvDraftData1.DraftStmntDate == rcvDraftData2.DraftStmntDate)
                 && (rcvDraftData1.Outline1 == rcvDraftData2.Outline1)
                 && (rcvDraftData1.Outline2 == rcvDraftData2.Outline2)
                 && (rcvDraftData1.AcptAnOdrStatus == rcvDraftData2.AcptAnOdrStatus)
                 && (rcvDraftData1.DepositSlipNo == rcvDraftData2.DepositSlipNo)
                 && (rcvDraftData1.DepositRowNo == rcvDraftData2.DepositRowNo)
                 && (rcvDraftData1.DepositDate == rcvDraftData2.DepositDate)
                 && (rcvDraftData1.EnterpriseName == rcvDraftData2.EnterpriseName)
                 && (rcvDraftData1.UpdEmployeeName == rcvDraftData2.UpdEmployeeName)
                 && (rcvDraftData1.AddUpSecName == rcvDraftData2.AddUpSecName));
        }
        /// <summary>
        /// 受取手形データ比較処理
        /// </summary>
        /// <param name="target">比較対象のRcvDraftDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RcvDraftDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RcvDraftData target)
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
            if (this.RcvDraftNo != target.RcvDraftNo) resList.Add("RcvDraftNo");
            if (this.DraftKindCd != target.DraftKindCd) resList.Add("DraftKindCd");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.BankAndBranchCd != target.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (this.BankAndBranchNm != target.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.ProcDate != target.ProcDate) resList.Add("ProcDate");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            if (this.DraftStmntDate != target.DraftStmntDate) resList.Add("DraftStmntDate");
            if (this.Outline1 != target.Outline1) resList.Add("Outline1");
            if (this.Outline2 != target.Outline2) resList.Add("Outline2");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.DepositSlipNo != target.DepositSlipNo) resList.Add("DepositSlipNo");
            if (this.DepositRowNo != target.DepositRowNo) resList.Add("DepositRowNo");
            if (this.DepositDate != target.DepositDate) resList.Add("DepositDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// 受取手形データ比較処理
        /// </summary>
        /// <param name="rcvDraftData1">比較するRcvDraftDataクラスのインスタンス</param>
        /// <param name="rcvDraftData2">比較するRcvDraftDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RcvDraftDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RcvDraftData rcvDraftData1, RcvDraftData rcvDraftData2)
        {
            ArrayList resList = new ArrayList();
            if (rcvDraftData1.CreateDateTime != rcvDraftData2.CreateDateTime) resList.Add("CreateDateTime");
            if (rcvDraftData1.UpdateDateTime != rcvDraftData2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rcvDraftData1.EnterpriseCode != rcvDraftData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rcvDraftData1.FileHeaderGuid != rcvDraftData2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (rcvDraftData1.UpdEmployeeCode != rcvDraftData2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (rcvDraftData1.UpdAssemblyId1 != rcvDraftData2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (rcvDraftData1.UpdAssemblyId2 != rcvDraftData2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (rcvDraftData1.LogicalDeleteCode != rcvDraftData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rcvDraftData1.RcvDraftNo != rcvDraftData2.RcvDraftNo) resList.Add("RcvDraftNo");
            if (rcvDraftData1.DraftKindCd != rcvDraftData2.DraftKindCd) resList.Add("DraftKindCd");
            if (rcvDraftData1.DraftDivide != rcvDraftData2.DraftDivide) resList.Add("DraftDivide");
            if (rcvDraftData1.Deposit != rcvDraftData2.Deposit) resList.Add("Deposit");
            if (rcvDraftData1.BankAndBranchCd != rcvDraftData2.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (rcvDraftData1.BankAndBranchNm != rcvDraftData2.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (rcvDraftData1.SectionCode != rcvDraftData2.SectionCode) resList.Add("SectionCode");
            if (rcvDraftData1.AddUpSecCode != rcvDraftData2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (rcvDraftData1.CustomerCode != rcvDraftData2.CustomerCode) resList.Add("CustomerCode");
            if (rcvDraftData1.CustomerName != rcvDraftData2.CustomerName) resList.Add("CustomerName");
            if (rcvDraftData1.CustomerName2 != rcvDraftData2.CustomerName2) resList.Add("CustomerName2");
            if (rcvDraftData1.CustomerSnm != rcvDraftData2.CustomerSnm) resList.Add("CustomerSnm");
            if (rcvDraftData1.ProcDate != rcvDraftData2.ProcDate) resList.Add("ProcDate");
            if (rcvDraftData1.DraftDrawingDate != rcvDraftData2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (rcvDraftData1.ValidityTerm != rcvDraftData2.ValidityTerm) resList.Add("ValidityTerm");
            if (rcvDraftData1.DraftStmntDate != rcvDraftData2.DraftStmntDate) resList.Add("DraftStmntDate");
            if (rcvDraftData1.Outline1 != rcvDraftData2.Outline1) resList.Add("Outline1");
            if (rcvDraftData1.Outline2 != rcvDraftData2.Outline2) resList.Add("Outline2");
            if (rcvDraftData1.AcptAnOdrStatus != rcvDraftData2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (rcvDraftData1.DepositSlipNo != rcvDraftData2.DepositSlipNo) resList.Add("DepositSlipNo");
            if (rcvDraftData1.DepositRowNo != rcvDraftData2.DepositRowNo) resList.Add("DepositRowNo");
            if (rcvDraftData1.DepositDate != rcvDraftData2.DepositDate) resList.Add("DepositDate");
            if (rcvDraftData1.EnterpriseName != rcvDraftData2.EnterpriseName) resList.Add("EnterpriseName");
            if (rcvDraftData1.UpdEmployeeName != rcvDraftData2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (rcvDraftData1.AddUpSecName != rcvDraftData2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
