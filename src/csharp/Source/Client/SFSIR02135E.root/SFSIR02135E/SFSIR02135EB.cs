using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PaymentDtl
    /// <summary>
    ///                      支払明細データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払明細データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2008/09/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PaymentDtl
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

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>支払伝票番号</summary>
        private Int32 _paymentSlipNo;

        /// <summary>支払行番号</summary>
        private Int32 _paymentRowNo;

        /// <summary>金種コード</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode;

        /// <summary>金種名称</summary>
        private string _moneyKindName = "";

        /// <summary>金種区分</summary>
        private Int32 _moneyKindDiv;

        /// <summary>支払金額</summary>
        private Int64 _payment;

        /// <summary>有効期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>金種区分名称</summary>
        private string _moneyKindDivName = "";


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

        /// public propaty name  :  MoneyKindCode
        /// <summary>金種コードプロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }

        /// public propaty name  :  MoneyKindName
        /// <summary>金種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }

        /// public propaty name  :  MoneyKindDiv
        /// <summary>金種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
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

        /// public propaty name  :  ValidityTerm
        /// <summary>有効期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }

        /// public propaty name  :  ValidityTermJpFormal
        /// <summary>有効期限 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidityTermJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validityTerm); }
            set { }
        }

        /// public propaty name  :  ValidityTermJpInFormal
        /// <summary>有効期限 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidityTermJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validityTerm); }
            set { }
        }

        /// public propaty name  :  ValidityTermAdFormal
        /// <summary>有効期限 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidityTermAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validityTerm); }
            set { }
        }

        /// public propaty name  :  ValidityTermAdInFormal
        /// <summary>有効期限 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidityTermAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validityTerm); }
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

        /// public propaty name  :  MoneyKindDivName
        /// <summary>金種区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindDivName
        {
            get { return _moneyKindDivName; }
            set { _moneyKindDivName = value; }
        }


        /// <summary>
        /// 支払明細データコンストラクタ
        /// </summary>
        /// <returns>PaymentDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentDtl()
        {
        }

        /// <summary>
        /// 支払明細データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="paymentRowNo">支払行番号</param>
        /// <param name="moneyKindCode">金種コード(1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金)</param>
        /// <param name="moneyKindName">金種名称</param>
        /// <param name="moneyKindDiv">金種区分</param>
        /// <param name="payment">支払金額</param>
        /// <param name="validityTerm">有効期限(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="moneyKindDivName">金種区分名称</param>
        /// <returns>PaymentDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierFormal, Int32 paymentSlipNo, Int32 paymentRowNo, Int32 moneyKindCode, string moneyKindName, Int32 moneyKindDiv, Int64 payment, DateTime validityTerm, string enterpriseName, string updEmployeeName, string moneyKindDivName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierFormal = supplierFormal;
            this._paymentSlipNo = paymentSlipNo;
            this._paymentRowNo = paymentRowNo;
            this._moneyKindCode = moneyKindCode;
            this._moneyKindName = moneyKindName;
            this._moneyKindDiv = moneyKindDiv;
            this._payment = payment;
            this.ValidityTerm = validityTerm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._moneyKindDivName = moneyKindDivName;

        }

        /// <summary>
        /// 支払明細データ複製処理
        /// </summary>
        /// <returns>PaymentDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPaymentDtlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentDtl Clone()
        {
            return new PaymentDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierFormal, this._paymentSlipNo, this._paymentRowNo, this._moneyKindCode, this._moneyKindName, this._moneyKindDiv, this._payment, this._validityTerm, this._enterpriseName, this._updEmployeeName, this._moneyKindDivName);
        }

        /// <summary>
        /// 支払明細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のPaymentDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PaymentDtl target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.PaymentSlipNo == target.PaymentSlipNo)
                 && (this.PaymentRowNo == target.PaymentRowNo)
                 && (this.MoneyKindCode == target.MoneyKindCode)
                 && (this.MoneyKindName == target.MoneyKindName)
                 && (this.MoneyKindDiv == target.MoneyKindDiv)
                 && (this.Payment == target.Payment)
                 && (this.ValidityTerm == target.ValidityTerm)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.MoneyKindDivName == target.MoneyKindDivName));
        }

        /// <summary>
        /// 支払明細データ比較処理
        /// </summary>
        /// <param name="paymentDtl1">
        ///                    比較するPaymentDtlクラスのインスタンス
        /// </param>
        /// <param name="paymentDtl2">比較するPaymentDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PaymentDtl paymentDtl1, PaymentDtl paymentDtl2)
        {
            return ((paymentDtl1.CreateDateTime == paymentDtl2.CreateDateTime)
                 && (paymentDtl1.UpdateDateTime == paymentDtl2.UpdateDateTime)
                 && (paymentDtl1.EnterpriseCode == paymentDtl2.EnterpriseCode)
                 && (paymentDtl1.FileHeaderGuid == paymentDtl2.FileHeaderGuid)
                 && (paymentDtl1.UpdEmployeeCode == paymentDtl2.UpdEmployeeCode)
                 && (paymentDtl1.UpdAssemblyId1 == paymentDtl2.UpdAssemblyId1)
                 && (paymentDtl1.UpdAssemblyId2 == paymentDtl2.UpdAssemblyId2)
                 && (paymentDtl1.LogicalDeleteCode == paymentDtl2.LogicalDeleteCode)
                 && (paymentDtl1.SupplierFormal == paymentDtl2.SupplierFormal)
                 && (paymentDtl1.PaymentSlipNo == paymentDtl2.PaymentSlipNo)
                 && (paymentDtl1.PaymentRowNo == paymentDtl2.PaymentRowNo)
                 && (paymentDtl1.MoneyKindCode == paymentDtl2.MoneyKindCode)
                 && (paymentDtl1.MoneyKindName == paymentDtl2.MoneyKindName)
                 && (paymentDtl1.MoneyKindDiv == paymentDtl2.MoneyKindDiv)
                 && (paymentDtl1.Payment == paymentDtl2.Payment)
                 && (paymentDtl1.ValidityTerm == paymentDtl2.ValidityTerm)
                 && (paymentDtl1.EnterpriseName == paymentDtl2.EnterpriseName)
                 && (paymentDtl1.UpdEmployeeName == paymentDtl2.UpdEmployeeName)
                 && (paymentDtl1.MoneyKindDivName == paymentDtl2.MoneyKindDivName));
        }
        /// <summary>
        /// 支払明細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のPaymentDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PaymentDtl target)
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
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.PaymentSlipNo != target.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (this.PaymentRowNo != target.PaymentRowNo) resList.Add("PaymentRowNo");
            if (this.MoneyKindCode != target.MoneyKindCode) resList.Add("MoneyKindCode");
            if (this.MoneyKindName != target.MoneyKindName) resList.Add("MoneyKindName");
            if (this.MoneyKindDiv != target.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (this.Payment != target.Payment) resList.Add("Payment");
            if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.MoneyKindDivName != target.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }

        /// <summary>
        /// 支払明細データ比較処理
        /// </summary>
        /// <param name="paymentDtl1">比較するPaymentDtlクラスのインスタンス</param>
        /// <param name="paymentDtl2">比較するPaymentDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PaymentDtl paymentDtl1, PaymentDtl paymentDtl2)
        {
            ArrayList resList = new ArrayList();
            if (paymentDtl1.CreateDateTime != paymentDtl2.CreateDateTime) resList.Add("CreateDateTime");
            if (paymentDtl1.UpdateDateTime != paymentDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (paymentDtl1.EnterpriseCode != paymentDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (paymentDtl1.FileHeaderGuid != paymentDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (paymentDtl1.UpdEmployeeCode != paymentDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (paymentDtl1.UpdAssemblyId1 != paymentDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (paymentDtl1.UpdAssemblyId2 != paymentDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (paymentDtl1.LogicalDeleteCode != paymentDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (paymentDtl1.SupplierFormal != paymentDtl2.SupplierFormal) resList.Add("SupplierFormal");
            if (paymentDtl1.PaymentSlipNo != paymentDtl2.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (paymentDtl1.PaymentRowNo != paymentDtl2.PaymentRowNo) resList.Add("PaymentRowNo");
            if (paymentDtl1.MoneyKindCode != paymentDtl2.MoneyKindCode) resList.Add("MoneyKindCode");
            if (paymentDtl1.MoneyKindName != paymentDtl2.MoneyKindName) resList.Add("MoneyKindName");
            if (paymentDtl1.MoneyKindDiv != paymentDtl2.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (paymentDtl1.Payment != paymentDtl2.Payment) resList.Add("Payment");
            if (paymentDtl1.ValidityTerm != paymentDtl2.ValidityTerm) resList.Add("ValidityTerm");
            if (paymentDtl1.EnterpriseName != paymentDtl2.EnterpriseName) resList.Add("EnterpriseName");
            if (paymentDtl1.UpdEmployeeName != paymentDtl2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (paymentDtl1.MoneyKindDivName != paymentDtl2.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }
    }
}
