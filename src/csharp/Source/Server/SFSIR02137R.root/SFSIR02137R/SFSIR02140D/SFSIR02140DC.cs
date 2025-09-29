using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentDataWork
    /// <summary>
    ///                      支払データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentDataWork : IFileHeader
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

        /// <summary>入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDay;

        /// <summary>支払日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

        // ----- ADD 2011/12/15 ------->>>>>
        /// <summary>前回支払日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _prePaymentDate;
        // ----- ADD 2011/12/15 -------<<<<<

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

        /// <summary>支払行番号１</summary>
        private Int32 _paymentRowNo1;

        /// <summary>金種コード１</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode1;

        /// <summary>金種名称１</summary>
        private string _moneyKindName1 = "";

        /// <summary>金種区分１</summary>
        private Int32 _moneyKindDiv1;

        /// <summary>支払金額１</summary>
        private Int64 _payment1;

        /// <summary>有効期限１</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm1;

        /// <summary>支払行番号２</summary>
        private Int32 _paymentRowNo2;

        /// <summary>金種コード２</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode2;

        /// <summary>金種名称２</summary>
        private string _moneyKindName2 = "";

        /// <summary>金種区分２</summary>
        private Int32 _moneyKindDiv2;

        /// <summary>支払金額２</summary>
        private Int64 _payment2;

        /// <summary>有効期限２</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm2;

        /// <summary>支払行番号３</summary>
        private Int32 _paymentRowNo3;

        /// <summary>金種コード３</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode3;

        /// <summary>金種名称３</summary>
        private string _moneyKindName3 = "";

        /// <summary>金種区分３</summary>
        private Int32 _moneyKindDiv3;

        /// <summary>支払金額３</summary>
        private Int64 _payment3;

        /// <summary>有効期限３</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm3;

        /// <summary>支払行番号４</summary>
        private Int32 _paymentRowNo4;

        /// <summary>金種コード４</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode4;

        /// <summary>金種名称４</summary>
        private string _moneyKindName4 = "";

        /// <summary>金種区分４</summary>
        private Int32 _moneyKindDiv4;

        /// <summary>支払金額４</summary>
        private Int64 _payment4;

        /// <summary>有効期限４</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm4;

        /// <summary>支払行番号５</summary>
        private Int32 _paymentRowNo5;

        /// <summary>金種コード５</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode5;

        /// <summary>金種名称５</summary>
        private string _moneyKindName5 = "";

        /// <summary>金種区分５</summary>
        private Int32 _moneyKindDiv5;

        /// <summary>支払金額５</summary>
        private Int64 _payment5;

        /// <summary>有効期限５</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm5;

        /// <summary>支払行番号６</summary>
        private Int32 _paymentRowNo6;

        /// <summary>金種コード６</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode6;

        /// <summary>金種名称６</summary>
        private string _moneyKindName6 = "";

        /// <summary>金種区分６</summary>
        private Int32 _moneyKindDiv6;

        /// <summary>支払金額６</summary>
        private Int64 _payment6;

        /// <summary>有効期限６</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm6;

        /// <summary>支払行番号７</summary>
        private Int32 _paymentRowNo7;

        /// <summary>金種コード７</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode7;

        /// <summary>金種名称７</summary>
        private string _moneyKindName7 = "";

        /// <summary>金種区分７</summary>
        private Int32 _moneyKindDiv7;

        /// <summary>支払金額７</summary>
        private Int64 _payment7;

        /// <summary>有効期限７</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm7;

        /// <summary>支払行番号８</summary>
        private Int32 _paymentRowNo8;

        /// <summary>金種コード８</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode8;

        /// <summary>金種名称８</summary>
        private string _moneyKindName8 = "";

        /// <summary>金種区分８</summary>
        private Int32 _moneyKindDiv8;

        /// <summary>支払金額８</summary>
        private Int64 _payment8;

        /// <summary>有効期限８</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm8;

        /// <summary>支払行番号９</summary>
        private Int32 _paymentRowNo9;

        /// <summary>金種コード９</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode9;

        /// <summary>金種名称９</summary>
        private string _moneyKindName9 = "";

        /// <summary>金種区分９</summary>
        private Int32 _moneyKindDiv9;

        /// <summary>支払金額９</summary>
        private Int64 _payment9;

        /// <summary>有効期限９</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm9;

        /// <summary>支払行番号１０</summary>
        private Int32 _paymentRowNo10;

        /// <summary>金種コード１０</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode10;

        /// <summary>金種名称１０</summary>
        private string _moneyKindName10 = "";

        /// <summary>金種区分１０</summary>
        private Int32 _moneyKindDiv10;

        /// <summary>支払金額１０</summary>
        private Int64 _payment10;

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

        // ----- ADD 2011/12/15 ------------------------------------->>>>>
        /// public propaty name  :  PrePaymentDate
        /// <summary>前回支払日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回支払日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PrePaymentDate
        {
            get { return _prePaymentDate; }
            set { _prePaymentDate = value; }
        }
        // ----- ADD 2011/12/15 -------------------------------------<<<<<

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

        /// public propaty name  :  PaymentRowNo1
        /// <summary>支払行番号１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo1
        {
            get { return _paymentRowNo1; }
            set { _paymentRowNo1 = value; }
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

        /// public propaty name  :  Payment1
        /// <summary>支払金額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment1
        {
            get { return _payment1; }
            set { _payment1 = value; }
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

        /// public propaty name  :  PaymentRowNo2
        /// <summary>支払行番号２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo2
        {
            get { return _paymentRowNo2; }
            set { _paymentRowNo2 = value; }
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

        /// public propaty name  :  Payment2
        /// <summary>支払金額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment2
        {
            get { return _payment2; }
            set { _payment2 = value; }
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

        /// public propaty name  :  PaymentRowNo3
        /// <summary>支払行番号３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo3
        {
            get { return _paymentRowNo3; }
            set { _paymentRowNo3 = value; }
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

        /// public propaty name  :  Payment3
        /// <summary>支払金額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment3
        {
            get { return _payment3; }
            set { _payment3 = value; }
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

        /// public propaty name  :  PaymentRowNo4
        /// <summary>支払行番号４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo4
        {
            get { return _paymentRowNo4; }
            set { _paymentRowNo4 = value; }
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

        /// public propaty name  :  Payment4
        /// <summary>支払金額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment4
        {
            get { return _payment4; }
            set { _payment4 = value; }
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

        /// public propaty name  :  PaymentRowNo5
        /// <summary>支払行番号５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo5
        {
            get { return _paymentRowNo5; }
            set { _paymentRowNo5 = value; }
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

        /// public propaty name  :  Payment5
        /// <summary>支払金額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment5
        {
            get { return _payment5; }
            set { _payment5 = value; }
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

        /// public propaty name  :  PaymentRowNo6
        /// <summary>支払行番号６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo6
        {
            get { return _paymentRowNo6; }
            set { _paymentRowNo6 = value; }
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

        /// public propaty name  :  Payment6
        /// <summary>支払金額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment6
        {
            get { return _payment6; }
            set { _payment6 = value; }
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

        /// public propaty name  :  PaymentRowNo7
        /// <summary>支払行番号７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo7
        {
            get { return _paymentRowNo7; }
            set { _paymentRowNo7 = value; }
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

        /// public propaty name  :  Payment7
        /// <summary>支払金額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment7
        {
            get { return _payment7; }
            set { _payment7 = value; }
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

        /// public propaty name  :  PaymentRowNo8
        /// <summary>支払行番号８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo8
        {
            get { return _paymentRowNo8; }
            set { _paymentRowNo8 = value; }
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

        /// public propaty name  :  Payment8
        /// <summary>支払金額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment8
        {
            get { return _payment8; }
            set { _payment8 = value; }
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

        /// public propaty name  :  PaymentRowNo9
        /// <summary>支払行番号９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo9
        {
            get { return _paymentRowNo9; }
            set { _paymentRowNo9 = value; }
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

        /// public propaty name  :  Payment9
        /// <summary>支払金額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment9
        {
            get { return _payment9; }
            set { _payment9 = value; }
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

        /// public propaty name  :  PaymentRowNo10
        /// <summary>支払行番号１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo10
        {
            get { return _paymentRowNo10; }
            set { _paymentRowNo10 = value; }
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

        /// public propaty name  :  Payment10
        /// <summary>支払金額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment10
        {
            get { return _payment10; }
            set { _payment10 = value; }
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
        /// 支払データワークコンストラクタ
        /// </summary>
        /// <returns>PaymentDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PaymentDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PaymentDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PaymentDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PaymentDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PaymentDataWork || graph is ArrayList || graph is PaymentDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PaymentDataWork).FullName));

            if (graph != null && graph is PaymentDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PaymentDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PaymentDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PaymentDataWork[])graph).Length;
            }
            else if (graph is PaymentDataWork)
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
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //支払伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //支払入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //入力日付
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //支払日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //支払日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PrePaymentDate // ADD 2011/12/15
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //支払計
            serInfo.MemberInfo.Add(typeof(Int64)); //PaymentTotal
            //支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //手数料支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //値引支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            //自動支払区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
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
            //赤黒支払連結番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkPayNo
            //支払担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //支払担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //支払入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //支払入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //銀行コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //銀行名称
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //支払行番号１
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo1
            //金種コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode1
            //金種名称１
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName1
            //金種区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv1
            //支払金額１
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment1
            //有効期限１
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm1
            //支払行番号２
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo2
            //金種コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode2
            //金種名称２
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName2
            //金種区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv2
            //支払金額２
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment2
            //有効期限２
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm2
            //支払行番号３
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo3
            //金種コード３
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode3
            //金種名称３
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName3
            //金種区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv3
            //支払金額３
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment3
            //有効期限３
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm3
            //支払行番号４
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo4
            //金種コード４
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode4
            //金種名称４
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName4
            //金種区分４
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv4
            //支払金額４
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment4
            //有効期限４
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm4
            //支払行番号５
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo5
            //金種コード５
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode5
            //金種名称５
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName5
            //金種区分５
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv5
            //支払金額５
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment5
            //有効期限５
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm5
            //支払行番号６
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo6
            //金種コード６
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode6
            //金種名称６
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName6
            //金種区分６
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv6
            //支払金額６
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment6
            //有効期限６
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm6
            //支払行番号７
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo7
            //金種コード７
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode7
            //金種名称７
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName7
            //金種区分７
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv7
            //支払金額７
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment7
            //有効期限７
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm7
            //支払行番号８
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo8
            //金種コード８
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode8
            //金種名称８
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName8
            //金種区分８
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv8
            //支払金額８
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment8
            //有効期限８
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm8
            //支払行番号９
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo9
            //金種コード９
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode9
            //金種名称９
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName9
            //金種区分９
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv9
            //支払金額９
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment9
            //有効期限９
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm9
            //支払行番号１０
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo10
            //金種コード１０
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode10
            //金種名称１０
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName10
            //金種区分１０
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv10
            //支払金額１０
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment10
            //有効期限１０
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm10


            serInfo.Serialize(writer, serInfo);
            if (graph is PaymentDataWork)
            {
                PaymentDataWork temp = (PaymentDataWork)graph;

                SetPaymentDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PaymentDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PaymentDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PaymentDataWork temp in lst)
                {
                    SetPaymentDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PaymentDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 106; // DEL 2011/12/15
        private const int currentMemberCount = 107; // ADD 2011/12/15

        /// <summary>
        ///  PaymentDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPaymentDataWork(System.IO.BinaryWriter writer, PaymentDataWork temp)
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
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //支払伝票番号
            writer.Write(temp.PaymentSlipNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //支払入力拠点コード
            writer.Write(temp.PaymentInpSectionCd);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //入力日付
            writer.Write((Int64)temp.InputDay.Ticks);
            //支払日付
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //支払日付
            writer.Write((Int64)temp.PrePaymentDate.Ticks); // ADD 2011/12/15
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //支払計
            writer.Write(temp.PaymentTotal);
            //支払金額
            writer.Write(temp.Payment);
            //手数料支払額
            writer.Write(temp.FeePayment);
            //値引支払額
            writer.Write(temp.DiscountPayment);
            //自動支払区分
            writer.Write(temp.AutoPayment);
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
            //赤黒支払連結番号
            writer.Write(temp.DebitNoteLinkPayNo);
            //支払担当者コード
            writer.Write(temp.PaymentAgentCode);
            //支払担当者名称
            writer.Write(temp.PaymentAgentName);
            //支払入力者コード
            writer.Write(temp.PaymentInputAgentCd);
            //支払入力者名称
            writer.Write(temp.PaymentInputAgentNm);
            //伝票摘要
            writer.Write(temp.Outline);
            //銀行コード
            writer.Write(temp.BankCode);
            //銀行名称
            writer.Write(temp.BankName);
            //支払行番号１
            writer.Write(temp.PaymentRowNo1);
            //金種コード１
            writer.Write(temp.MoneyKindCode1);
            //金種名称１
            writer.Write(temp.MoneyKindName1);
            //金種区分１
            writer.Write(temp.MoneyKindDiv1);
            //支払金額１
            writer.Write(temp.Payment1);
            //有効期限１
            writer.Write(temp.ValidityTerm1.Ticks);
            //支払行番号２
            writer.Write(temp.PaymentRowNo2);
            //金種コード２
            writer.Write(temp.MoneyKindCode2);
            //金種名称２
            writer.Write(temp.MoneyKindName2);
            //金種区分２
            writer.Write(temp.MoneyKindDiv2);
            //支払金額２
            writer.Write(temp.Payment2);
            //有効期限２
            writer.Write(temp.ValidityTerm2.Ticks);
            //支払行番号３
            writer.Write(temp.PaymentRowNo3);
            //金種コード３
            writer.Write(temp.MoneyKindCode3);
            //金種名称３
            writer.Write(temp.MoneyKindName3);
            //金種区分３
            writer.Write(temp.MoneyKindDiv3);
            //支払金額３
            writer.Write(temp.Payment3);
            //有効期限３
            writer.Write(temp.ValidityTerm3.Ticks);
            //支払行番号４
            writer.Write(temp.PaymentRowNo4);
            //金種コード４
            writer.Write(temp.MoneyKindCode4);
            //金種名称４
            writer.Write(temp.MoneyKindName4);
            //金種区分４
            writer.Write(temp.MoneyKindDiv4);
            //支払金額４
            writer.Write(temp.Payment4);
            //有効期限４
            writer.Write(temp.ValidityTerm4.Ticks);
            //支払行番号５
            writer.Write(temp.PaymentRowNo5);
            //金種コード５
            writer.Write(temp.MoneyKindCode5);
            //金種名称５
            writer.Write(temp.MoneyKindName5);
            //金種区分５
            writer.Write(temp.MoneyKindDiv5);
            //支払金額５
            writer.Write(temp.Payment5);
            //有効期限５
            writer.Write(temp.ValidityTerm5.Ticks);
            //支払行番号６
            writer.Write(temp.PaymentRowNo6);
            //金種コード６
            writer.Write(temp.MoneyKindCode6);
            //金種名称６
            writer.Write(temp.MoneyKindName6);
            //金種区分６
            writer.Write(temp.MoneyKindDiv6);
            //支払金額６
            writer.Write(temp.Payment6);
            //有効期限６
            writer.Write(temp.ValidityTerm6.Ticks);
            //支払行番号７
            writer.Write(temp.PaymentRowNo7);
            //金種コード７
            writer.Write(temp.MoneyKindCode7);
            //金種名称７
            writer.Write(temp.MoneyKindName7);
            //金種区分７
            writer.Write(temp.MoneyKindDiv7);
            //支払金額７
            writer.Write(temp.Payment7);
            //有効期限７
            writer.Write(temp.ValidityTerm7.Ticks);
            //支払行番号８
            writer.Write(temp.PaymentRowNo8);
            //金種コード８
            writer.Write(temp.MoneyKindCode8);
            //金種名称８
            writer.Write(temp.MoneyKindName8);
            //金種区分８
            writer.Write(temp.MoneyKindDiv8);
            //支払金額８
            writer.Write(temp.Payment8);
            //有効期限８
            writer.Write(temp.ValidityTerm8.Ticks);
            //支払行番号９
            writer.Write(temp.PaymentRowNo9);
            //金種コード９
            writer.Write(temp.MoneyKindCode9);
            //金種名称９
            writer.Write(temp.MoneyKindName9);
            //金種区分９
            writer.Write(temp.MoneyKindDiv9);
            //支払金額９
            writer.Write(temp.Payment9);
            //有効期限９
            writer.Write(temp.ValidityTerm9.Ticks);
            //支払行番号１０
            writer.Write(temp.PaymentRowNo10);
            //金種コード１０
            writer.Write(temp.MoneyKindCode10);
            //金種名称１０
            writer.Write(temp.MoneyKindName10);
            //金種区分１０
            writer.Write(temp.MoneyKindDiv10);
            //支払金額１０
            writer.Write(temp.Payment10);
            //有効期限１０
            writer.Write(temp.ValidityTerm10.Ticks);

        }

        /// <summary>
        ///  PaymentDataWorkインスタンス取得
        /// </summary>
        /// <returns>PaymentDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PaymentDataWork GetPaymentDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PaymentDataWork temp = new PaymentDataWork();

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
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //支払伝票番号
            temp.PaymentSlipNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //支払入力拠点コード
            temp.PaymentInpSectionCd = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //入力日付
            temp.InputDay = new DateTime(reader.ReadInt64());
            //支払日付
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //支払日付
            temp.PrePaymentDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //支払計
            temp.PaymentTotal = reader.ReadInt64();
            //支払金額
            temp.Payment = reader.ReadInt64();
            //手数料支払額
            temp.FeePayment = reader.ReadInt64();
            //値引支払額
            temp.DiscountPayment = reader.ReadInt64();
            //自動支払区分
            temp.AutoPayment = reader.ReadInt32();
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
            //赤黒支払連結番号
            temp.DebitNoteLinkPayNo = reader.ReadInt32();
            //支払担当者コード
            temp.PaymentAgentCode = reader.ReadString();
            //支払担当者名称
            temp.PaymentAgentName = reader.ReadString();
            //支払入力者コード
            temp.PaymentInputAgentCd = reader.ReadString();
            //支払入力者名称
            temp.PaymentInputAgentNm = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //銀行コード
            temp.BankCode = reader.ReadInt32();
            //銀行名称
            temp.BankName = reader.ReadString();
            //支払行番号１
            temp.PaymentRowNo1 = reader.ReadInt32();
            //金種コード１
            temp.MoneyKindCode1 = reader.ReadInt32();
            //金種名称１
            temp.MoneyKindName1 = reader.ReadString();
            //金種区分１
            temp.MoneyKindDiv1 = reader.ReadInt32();
            //支払金額１
            temp.Payment1 = reader.ReadInt64();
            //有効期限１
            temp.ValidityTerm1 = new DateTime(reader.ReadInt64());
            //支払行番号２
            temp.PaymentRowNo2 = reader.ReadInt32();
            //金種コード２
            temp.MoneyKindCode2 = reader.ReadInt32();
            //金種名称２
            temp.MoneyKindName2 = reader.ReadString();
            //金種区分２
            temp.MoneyKindDiv2 = reader.ReadInt32();
            //支払金額２
            temp.Payment2 = reader.ReadInt64();
            //有効期限２
            temp.ValidityTerm2 = new DateTime(reader.ReadInt64());
            //支払行番号３
            temp.PaymentRowNo3 = reader.ReadInt32();
            //金種コード３
            temp.MoneyKindCode3 = reader.ReadInt32();
            //金種名称３
            temp.MoneyKindName3 = reader.ReadString();
            //金種区分３
            temp.MoneyKindDiv3 = reader.ReadInt32();
            //支払金額３
            temp.Payment3 = reader.ReadInt64();
            //有効期限３
            temp.ValidityTerm3 = new DateTime(reader.ReadInt64());
            //支払行番号４
            temp.PaymentRowNo4 = reader.ReadInt32();
            //金種コード４
            temp.MoneyKindCode4 = reader.ReadInt32();
            //金種名称４
            temp.MoneyKindName4 = reader.ReadString();
            //金種区分４
            temp.MoneyKindDiv4 = reader.ReadInt32();
            //支払金額４
            temp.Payment4 = reader.ReadInt64();
            //有効期限４
            temp.ValidityTerm4 = new DateTime(reader.ReadInt64());
            //支払行番号５
            temp.PaymentRowNo5 = reader.ReadInt32();
            //金種コード５
            temp.MoneyKindCode5 = reader.ReadInt32();
            //金種名称５
            temp.MoneyKindName5 = reader.ReadString();
            //金種区分５
            temp.MoneyKindDiv5 = reader.ReadInt32();
            //支払金額５
            temp.Payment5 = reader.ReadInt64();
            //有効期限５
            temp.ValidityTerm5 = new DateTime(reader.ReadInt64());
            //支払行番号６
            temp.PaymentRowNo6 = reader.ReadInt32();
            //金種コード６
            temp.MoneyKindCode6 = reader.ReadInt32();
            //金種名称６
            temp.MoneyKindName6 = reader.ReadString();
            //金種区分６
            temp.MoneyKindDiv6 = reader.ReadInt32();
            //支払金額６
            temp.Payment6 = reader.ReadInt64();
            //有効期限６
            temp.ValidityTerm6 = new DateTime(reader.ReadInt64());
            //支払行番号７
            temp.PaymentRowNo7 = reader.ReadInt32();
            //金種コード７
            temp.MoneyKindCode7 = reader.ReadInt32();
            //金種名称７
            temp.MoneyKindName7 = reader.ReadString();
            //金種区分７
            temp.MoneyKindDiv7 = reader.ReadInt32();
            //支払金額７
            temp.Payment7 = reader.ReadInt64();
            //有効期限７
            temp.ValidityTerm7 = new DateTime(reader.ReadInt64());
            //支払行番号８
            temp.PaymentRowNo8 = reader.ReadInt32();
            //金種コード８
            temp.MoneyKindCode8 = reader.ReadInt32();
            //金種名称８
            temp.MoneyKindName8 = reader.ReadString();
            //金種区分８
            temp.MoneyKindDiv8 = reader.ReadInt32();
            //支払金額８
            temp.Payment8 = reader.ReadInt64();
            //有効期限８
            temp.ValidityTerm8 = new DateTime(reader.ReadInt64());
            //支払行番号９
            temp.PaymentRowNo9 = reader.ReadInt32();
            //金種コード９
            temp.MoneyKindCode9 = reader.ReadInt32();
            //金種名称９
            temp.MoneyKindName9 = reader.ReadString();
            //金種区分９
            temp.MoneyKindDiv9 = reader.ReadInt32();
            //支払金額９
            temp.Payment9 = reader.ReadInt64();
            //有効期限９
            temp.ValidityTerm9 = new DateTime(reader.ReadInt64());
            //支払行番号１０
            temp.PaymentRowNo10 = reader.ReadInt32();
            //金種コード１０
            temp.MoneyKindCode10 = reader.ReadInt32();
            //金種名称１０
            temp.MoneyKindName10 = reader.ReadString();
            //金種区分１０
            temp.MoneyKindDiv10 = reader.ReadInt32();
            //支払金額１０
            temp.Payment10 = reader.ReadInt64();
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
        /// <returns>PaymentDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PaymentDataWork temp = GetPaymentDataWork(reader, serInfo);
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
                    retValue = (PaymentDataWork[])lst.ToArray(typeof(PaymentDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
