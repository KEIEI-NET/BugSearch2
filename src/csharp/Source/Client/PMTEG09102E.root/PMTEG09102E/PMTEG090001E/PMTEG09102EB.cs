using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PayDraftData
    /// <summary>
    ///                      支払手形データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払手形データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2010/04/26  (CSharp File Generated Date)</br>
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
    public class PayDraftData
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

        /// <summary>支払手形番号</summary>
        private string _payDraftNo = "";

        /// <summary>手形種別</summary>
        /// <remarks>0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済</remarks>
        private Int32 _draftKindCd;

        /// <summary>手形区分</summary>
        /// <remarks>0:自振 1:他振　※旧自他振区分</remarks>
        private Int32 _draftDivide;

        /// <summary>支払金額</summary>
        private Int64 _payment;

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

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

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

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>支払伝票番号</summary>
        private Int32 _paymentSlipNo;

        /// <summary>支払行番号</summary>
        /// <remarks>※支払設定金種ｺｰﾄﾞ｢手形｣の設定番号をｾｯﾄ</remarks>
        private Int32 _paymentRowNo;

        /// <summary>支払日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

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

        /// public propaty name  :  PayDraftNo
        /// <summary>支払手形番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払手形番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayDraftNo
        {
            get { return _payDraftNo; }
            set { _payDraftNo = value; }
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

        /// public propaty name  :  PaymentRowNo
        /// <summary>支払行番号プロパティ</summary>
        /// <value>※支払設定金種ｺｰﾄﾞ｢手形｣の設定番号をｾｯﾄ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo
        {
            get { return _paymentRowNo; }
            set { _paymentRowNo = value; }
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
        /// 支払手形データコンストラクタ
        /// </summary>
        /// <returns>PayDraftDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PayDraftDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PayDraftData()
        {
        }

        /// <summary>
        /// 支払手形データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="payDraftNo">支払手形番号</param>
        /// <param name="draftKindCd">手形種別(0:手持 1:取立 2:割引 3:譲渡 4:担保 5:不渡 6:支払 7:先付 9:決済)</param>
        /// <param name="draftDivide">手形区分(0:自振 1:他振　※旧自他振区分)</param>
        /// <param name="payment">支払金額</param>
        /// <param name="bankAndBranchCd">銀行・支店コード(頭4桁銀行ｺｰﾄﾞ､下3桁支店ｺｰﾄﾞ)</param>
        /// <param name="bankAndBranchNm">銀行・支店名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addUpSecCode">計上拠点コード(※子でも手形ﾃﾞｰﾀが作成可なので必要)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierNm1">仕入先名1</param>
        /// <param name="supplierNm2">仕入先名2</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="procDate">処理日(YYYYMMDD)</param>
        /// <param name="draftDrawingDate">手形振出日(YYYYMMDD)</param>
        /// <param name="validityTerm">有効期限(YYYYMMDD　※期日、満期日として使用)</param>
        /// <param name="draftStmntDate">手形決済日(YYYYMMDD)</param>
        /// <param name="outline1">伝票摘要1</param>
        /// <param name="outline2">伝票摘要2</param>
        /// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="paymentRowNo">支払行番号(※支払設定金種ｺｰﾄﾞ｢手形｣の設定番号をｾｯﾄ)</param>
        /// <param name="paymentDate">支払日付(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <returns>PayDraftDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PayDraftDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PayDraftData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string payDraftNo, Int32 draftKindCd, Int32 draftDivide, Int64 payment, Int32 bankAndBranchCd, string bankAndBranchNm, string sectionCode, string addUpSecCode, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 procDate, DateTime draftDrawingDate, Int32 validityTerm, Int32 draftStmntDate, string outline1, string outline2, Int32 supplierFormal, Int32 paymentSlipNo, Int32 paymentRowNo, DateTime paymentDate, string enterpriseName, string updEmployeeName, string addUpSecName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._payDraftNo = payDraftNo;
            this._draftKindCd = draftKindCd;
            this._draftDivide = draftDivide;
            this._payment = payment;
            this._bankAndBranchCd = bankAndBranchCd;
            this._bankAndBranchNm = bankAndBranchNm;
            this._sectionCode = sectionCode;
            this._addUpSecCode = addUpSecCode;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._supplierSnm = supplierSnm;
            this._procDate = procDate;
            this.DraftDrawingDate = draftDrawingDate;
            this._validityTerm = validityTerm;
            this._draftStmntDate = draftStmntDate;
            this._outline1 = outline1;
            this._outline2 = outline2;
            this._supplierFormal = supplierFormal;
            this._paymentSlipNo = paymentSlipNo;
            this._paymentRowNo = paymentRowNo;
            this.PaymentDate = paymentDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// 支払手形データ複製処理
        /// </summary>
        /// <returns>PayDraftDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPayDraftDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PayDraftData Clone()
        {
            return new PayDraftData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._payDraftNo, this._draftKindCd, this._draftDivide, this._payment, this._bankAndBranchCd, this._bankAndBranchNm, this._sectionCode, this._addUpSecCode, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._procDate, this._draftDrawingDate, this._validityTerm, this._draftStmntDate, this._outline1, this._outline2, this._supplierFormal, this._paymentSlipNo, this._paymentRowNo, this._paymentDate, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
        }

        /// <summary>
        /// 支払手形データ比較処理
        /// </summary>
        /// <param name="target">比較対象のPayDraftDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PayDraftDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PayDraftData target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PayDraftNo == target.PayDraftNo)
                 && (this.DraftKindCd == target.DraftKindCd)
                 && (this.DraftDivide == target.DraftDivide)
                 && (this.Payment == target.Payment)
                 && (this.BankAndBranchCd == target.BankAndBranchCd)
                 && (this.BankAndBranchNm == target.BankAndBranchNm)
                 && (this.SectionCode == target.SectionCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierNm2 == target.SupplierNm2)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.ProcDate == target.ProcDate)
                 && (this.DraftDrawingDate == target.DraftDrawingDate)
                 && (this.ValidityTerm == target.ValidityTerm)
                 && (this.DraftStmntDate == target.DraftStmntDate)
                 && (this.Outline1 == target.Outline1)
                 && (this.Outline2 == target.Outline2)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.PaymentSlipNo == target.PaymentSlipNo)
                 && (this.PaymentRowNo == target.PaymentRowNo)
                 && (this.PaymentDate == target.PaymentDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// 支払手形データ比較処理
        /// </summary>
        /// <param name="payDraftData1">
        ///                    比較するPayDraftDataクラスのインスタンス
        /// </param>
        /// <param name="payDraftData2">比較するPayDraftDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PayDraftDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PayDraftData payDraftData1, PayDraftData payDraftData2)
        {
            return ((payDraftData1.CreateDateTime == payDraftData2.CreateDateTime)
                 && (payDraftData1.UpdateDateTime == payDraftData2.UpdateDateTime)
                 && (payDraftData1.EnterpriseCode == payDraftData2.EnterpriseCode)
                 && (payDraftData1.FileHeaderGuid == payDraftData2.FileHeaderGuid)
                 && (payDraftData1.UpdEmployeeCode == payDraftData2.UpdEmployeeCode)
                 && (payDraftData1.UpdAssemblyId1 == payDraftData2.UpdAssemblyId1)
                 && (payDraftData1.UpdAssemblyId2 == payDraftData2.UpdAssemblyId2)
                 && (payDraftData1.LogicalDeleteCode == payDraftData2.LogicalDeleteCode)
                 && (payDraftData1.PayDraftNo == payDraftData2.PayDraftNo)
                 && (payDraftData1.DraftKindCd == payDraftData2.DraftKindCd)
                 && (payDraftData1.DraftDivide == payDraftData2.DraftDivide)
                 && (payDraftData1.Payment == payDraftData2.Payment)
                 && (payDraftData1.BankAndBranchCd == payDraftData2.BankAndBranchCd)
                 && (payDraftData1.BankAndBranchNm == payDraftData2.BankAndBranchNm)
                 && (payDraftData1.SectionCode == payDraftData2.SectionCode)
                 && (payDraftData1.AddUpSecCode == payDraftData2.AddUpSecCode)
                 && (payDraftData1.SupplierCd == payDraftData2.SupplierCd)
                 && (payDraftData1.SupplierNm1 == payDraftData2.SupplierNm1)
                 && (payDraftData1.SupplierNm2 == payDraftData2.SupplierNm2)
                 && (payDraftData1.SupplierSnm == payDraftData2.SupplierSnm)
                 && (payDraftData1.ProcDate == payDraftData2.ProcDate)
                 && (payDraftData1.DraftDrawingDate == payDraftData2.DraftDrawingDate)
                 && (payDraftData1.ValidityTerm == payDraftData2.ValidityTerm)
                 && (payDraftData1.DraftStmntDate == payDraftData2.DraftStmntDate)
                 && (payDraftData1.Outline1 == payDraftData2.Outline1)
                 && (payDraftData1.Outline2 == payDraftData2.Outline2)
                 && (payDraftData1.SupplierFormal == payDraftData2.SupplierFormal)
                 && (payDraftData1.PaymentSlipNo == payDraftData2.PaymentSlipNo)
                 && (payDraftData1.PaymentRowNo == payDraftData2.PaymentRowNo)
                 && (payDraftData1.PaymentDate == payDraftData2.PaymentDate)
                 && (payDraftData1.EnterpriseName == payDraftData2.EnterpriseName)
                 && (payDraftData1.UpdEmployeeName == payDraftData2.UpdEmployeeName)
                 && (payDraftData1.AddUpSecName == payDraftData2.AddUpSecName));
        }
        /// <summary>
        /// 支払手形データ比較処理
        /// </summary>
        /// <param name="target">比較対象のPayDraftDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PayDraftDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PayDraftData target)
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
            if (this.PayDraftNo != target.PayDraftNo) resList.Add("PayDraftNo");
            if (this.DraftKindCd != target.DraftKindCd) resList.Add("DraftKindCd");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.Payment != target.Payment) resList.Add("Payment");
            if (this.BankAndBranchCd != target.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (this.BankAndBranchNm != target.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.ProcDate != target.ProcDate) resList.Add("ProcDate");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            if (this.DraftStmntDate != target.DraftStmntDate) resList.Add("DraftStmntDate");
            if (this.Outline1 != target.Outline1) resList.Add("Outline1");
            if (this.Outline2 != target.Outline2) resList.Add("Outline2");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.PaymentSlipNo != target.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (this.PaymentRowNo != target.PaymentRowNo) resList.Add("PaymentRowNo");
            if (this.PaymentDate != target.PaymentDate) resList.Add("PaymentDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// 支払手形データ比較処理
        /// </summary>
        /// <param name="payDraftData1">比較するPayDraftDataクラスのインスタンス</param>
        /// <param name="payDraftData2">比較するPayDraftDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PayDraftDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PayDraftData payDraftData1, PayDraftData payDraftData2)
        {
            ArrayList resList = new ArrayList();
            if (payDraftData1.CreateDateTime != payDraftData2.CreateDateTime) resList.Add("CreateDateTime");
            if (payDraftData1.UpdateDateTime != payDraftData2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (payDraftData1.EnterpriseCode != payDraftData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (payDraftData1.FileHeaderGuid != payDraftData2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (payDraftData1.UpdEmployeeCode != payDraftData2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (payDraftData1.UpdAssemblyId1 != payDraftData2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (payDraftData1.UpdAssemblyId2 != payDraftData2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (payDraftData1.LogicalDeleteCode != payDraftData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (payDraftData1.PayDraftNo != payDraftData2.PayDraftNo) resList.Add("PayDraftNo");
            if (payDraftData1.DraftKindCd != payDraftData2.DraftKindCd) resList.Add("DraftKindCd");
            if (payDraftData1.DraftDivide != payDraftData2.DraftDivide) resList.Add("DraftDivide");
            if (payDraftData1.Payment != payDraftData2.Payment) resList.Add("Payment");
            if (payDraftData1.BankAndBranchCd != payDraftData2.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (payDraftData1.BankAndBranchNm != payDraftData2.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (payDraftData1.SectionCode != payDraftData2.SectionCode) resList.Add("SectionCode");
            if (payDraftData1.AddUpSecCode != payDraftData2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (payDraftData1.SupplierCd != payDraftData2.SupplierCd) resList.Add("SupplierCd");
            if (payDraftData1.SupplierNm1 != payDraftData2.SupplierNm1) resList.Add("SupplierNm1");
            if (payDraftData1.SupplierNm2 != payDraftData2.SupplierNm2) resList.Add("SupplierNm2");
            if (payDraftData1.SupplierSnm != payDraftData2.SupplierSnm) resList.Add("SupplierSnm");
            if (payDraftData1.ProcDate != payDraftData2.ProcDate) resList.Add("ProcDate");
            if (payDraftData1.DraftDrawingDate != payDraftData2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (payDraftData1.ValidityTerm != payDraftData2.ValidityTerm) resList.Add("ValidityTerm");
            if (payDraftData1.DraftStmntDate != payDraftData2.DraftStmntDate) resList.Add("DraftStmntDate");
            if (payDraftData1.Outline1 != payDraftData2.Outline1) resList.Add("Outline1");
            if (payDraftData1.Outline2 != payDraftData2.Outline2) resList.Add("Outline2");
            if (payDraftData1.SupplierFormal != payDraftData2.SupplierFormal) resList.Add("SupplierFormal");
            if (payDraftData1.PaymentSlipNo != payDraftData2.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (payDraftData1.PaymentRowNo != payDraftData2.PaymentRowNo) resList.Add("PaymentRowNo");
            if (payDraftData1.PaymentDate != payDraftData2.PaymentDate) resList.Add("PaymentDate");
            if (payDraftData1.EnterpriseName != payDraftData2.EnterpriseName) resList.Add("EnterpriseName");
            if (payDraftData1.UpdEmployeeName != payDraftData2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (payDraftData1.AddUpSecName != payDraftData2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
