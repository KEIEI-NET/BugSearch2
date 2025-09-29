using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AccRecDepoTotal
    /// <summary>
    ///                      売掛入金集計データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   売掛入金集計データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/23</br>
    /// <br>Genarated Date   :   2009/01/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AccRecDepoTotal
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 自社締を行なった日（自社締め基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>金種コード</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode;

        /// <summary>金種名称</summary>
        private string _moneyKindName = "";

        /// <summary>金種区分</summary>
        private Int32 _moneyKindDiv;

        /// <summary>入金金額</summary>
        /// <remarks>値引・手数料を除いた額</remarks>
        private Int64 _deposit;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";

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

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
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
        /// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
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
        /// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
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
        /// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
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
        /// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
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
        /// 売掛入金集計データコンストラクタ
        /// </summary>
        /// <returns>AccRecDepoTotalクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccRecDepoTotalクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AccRecDepoTotal()
        {
        }

        /// <summary>
        /// 売掛入金集計データコンストラクタ
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
        /// <param name="customerCode">得意先コード</param>
        /// <param name="addUpDate">計上年月日(YYYYMMDD 自社締を行なった日（自社締め基準）)</param>
        /// <param name="moneyKindCode">金種コード(1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金)</param>
        /// <param name="moneyKindName">金種名称</param>
        /// <param name="moneyKindDiv">金種区分</param>
        /// <param name="deposit">入金金額(値引・手数料を除いた額)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="moneyKindDivName">金種区分名称</param>
        /// <returns>AccRecDepoTotalクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccRecDepoTotalクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AccRecDepoTotal(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, Int32 customerCode, DateTime addUpDate, Int32 moneyKindCode, string moneyKindName, Int32 moneyKindDiv, Int64 deposit, string enterpriseName, string updEmployeeName, string addUpSecName, string moneyKindDivName)
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
            this._customerCode = customerCode;
            this.AddUpDate = addUpDate;
            this._moneyKindCode = moneyKindCode;
            this._moneyKindName = moneyKindName;
            this._moneyKindDiv = moneyKindDiv;
            this._deposit = deposit;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            this._moneyKindDivName = moneyKindDivName;

        }

        /// <summary>
        /// 売掛入金集計データ複製処理
        /// </summary>
        /// <returns>AccRecDepoTotalクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAccRecDepoTotalクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AccRecDepoTotal Clone()
        {
            return new AccRecDepoTotal(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._customerCode, this._addUpDate, this._moneyKindCode, this._moneyKindName, this._moneyKindDiv, this._deposit, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._moneyKindDivName);
        }

        /// <summary>
        /// 売掛入金集計データ比較処理
        /// </summary>
        /// <param name="target">比較対象のAccRecDepoTotalクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccRecDepoTotalクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AccRecDepoTotal target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.FileHeaderGuid == target.FileHeaderGuid )
                 && ( this.UpdEmployeeCode == target.UpdEmployeeCode )
                 && ( this.UpdAssemblyId1 == target.UpdAssemblyId1 )
                 && ( this.UpdAssemblyId2 == target.UpdAssemblyId2 )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.AddUpSecCode == target.AddUpSecCode )
                 && ( this.ClaimCode == target.ClaimCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.AddUpDate == target.AddUpDate )
                 && ( this.MoneyKindCode == target.MoneyKindCode )
                 && ( this.MoneyKindName == target.MoneyKindName )
                 && ( this.MoneyKindDiv == target.MoneyKindDiv )
                 && ( this.Deposit == target.Deposit )
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.UpdEmployeeName == target.UpdEmployeeName )
                 && ( this.AddUpSecName == target.AddUpSecName )
                 && ( this.MoneyKindDivName == target.MoneyKindDivName ) );
        }

        /// <summary>
        /// 売掛入金集計データ比較処理
        /// </summary>
        /// <param name="accRecDepoTotal1">
        ///                    比較するAccRecDepoTotalクラスのインスタンス
        /// </param>
        /// <param name="accRecDepoTotal2">比較するAccRecDepoTotalクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccRecDepoTotalクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AccRecDepoTotal accRecDepoTotal1, AccRecDepoTotal accRecDepoTotal2)
        {
            return ( ( accRecDepoTotal1.CreateDateTime == accRecDepoTotal2.CreateDateTime )
                 && ( accRecDepoTotal1.UpdateDateTime == accRecDepoTotal2.UpdateDateTime )
                 && ( accRecDepoTotal1.EnterpriseCode == accRecDepoTotal2.EnterpriseCode )
                 && ( accRecDepoTotal1.FileHeaderGuid == accRecDepoTotal2.FileHeaderGuid )
                 && ( accRecDepoTotal1.UpdEmployeeCode == accRecDepoTotal2.UpdEmployeeCode )
                 && ( accRecDepoTotal1.UpdAssemblyId1 == accRecDepoTotal2.UpdAssemblyId1 )
                 && ( accRecDepoTotal1.UpdAssemblyId2 == accRecDepoTotal2.UpdAssemblyId2 )
                 && ( accRecDepoTotal1.LogicalDeleteCode == accRecDepoTotal2.LogicalDeleteCode )
                 && ( accRecDepoTotal1.AddUpSecCode == accRecDepoTotal2.AddUpSecCode )
                 && ( accRecDepoTotal1.ClaimCode == accRecDepoTotal2.ClaimCode )
                 && ( accRecDepoTotal1.CustomerCode == accRecDepoTotal2.CustomerCode )
                 && ( accRecDepoTotal1.AddUpDate == accRecDepoTotal2.AddUpDate )
                 && ( accRecDepoTotal1.MoneyKindCode == accRecDepoTotal2.MoneyKindCode )
                 && ( accRecDepoTotal1.MoneyKindName == accRecDepoTotal2.MoneyKindName )
                 && ( accRecDepoTotal1.MoneyKindDiv == accRecDepoTotal2.MoneyKindDiv )
                 && ( accRecDepoTotal1.Deposit == accRecDepoTotal2.Deposit )
                 && ( accRecDepoTotal1.EnterpriseName == accRecDepoTotal2.EnterpriseName )
                 && ( accRecDepoTotal1.UpdEmployeeName == accRecDepoTotal2.UpdEmployeeName )
                 && ( accRecDepoTotal1.AddUpSecName == accRecDepoTotal2.AddUpSecName )
                 && ( accRecDepoTotal1.MoneyKindDivName == accRecDepoTotal2.MoneyKindDivName ) );
        }
        /// <summary>
        /// 売掛入金集計データ比較処理
        /// </summary>
        /// <param name="target">比較対象のAccRecDepoTotalクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccRecDepoTotalクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AccRecDepoTotal target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.MoneyKindCode != target.MoneyKindCode) resList.Add("MoneyKindCode");
            if (this.MoneyKindName != target.MoneyKindName) resList.Add("MoneyKindName");
            if (this.MoneyKindDiv != target.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.MoneyKindDivName != target.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }

        /// <summary>
        /// 売掛入金集計データ比較処理
        /// </summary>
        /// <param name="accRecDepoTotal1">比較するAccRecDepoTotalクラスのインスタンス</param>
        /// <param name="accRecDepoTotal2">比較するAccRecDepoTotalクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AccRecDepoTotalクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AccRecDepoTotal accRecDepoTotal1, AccRecDepoTotal accRecDepoTotal2)
        {
            ArrayList resList = new ArrayList();
            if (accRecDepoTotal1.CreateDateTime != accRecDepoTotal2.CreateDateTime) resList.Add("CreateDateTime");
            if (accRecDepoTotal1.UpdateDateTime != accRecDepoTotal2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (accRecDepoTotal1.EnterpriseCode != accRecDepoTotal2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (accRecDepoTotal1.FileHeaderGuid != accRecDepoTotal2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (accRecDepoTotal1.UpdEmployeeCode != accRecDepoTotal2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (accRecDepoTotal1.UpdAssemblyId1 != accRecDepoTotal2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (accRecDepoTotal1.UpdAssemblyId2 != accRecDepoTotal2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (accRecDepoTotal1.LogicalDeleteCode != accRecDepoTotal2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (accRecDepoTotal1.AddUpSecCode != accRecDepoTotal2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (accRecDepoTotal1.ClaimCode != accRecDepoTotal2.ClaimCode) resList.Add("ClaimCode");
            if (accRecDepoTotal1.CustomerCode != accRecDepoTotal2.CustomerCode) resList.Add("CustomerCode");
            if (accRecDepoTotal1.AddUpDate != accRecDepoTotal2.AddUpDate) resList.Add("AddUpDate");
            if (accRecDepoTotal1.MoneyKindCode != accRecDepoTotal2.MoneyKindCode) resList.Add("MoneyKindCode");
            if (accRecDepoTotal1.MoneyKindName != accRecDepoTotal2.MoneyKindName) resList.Add("MoneyKindName");
            if (accRecDepoTotal1.MoneyKindDiv != accRecDepoTotal2.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (accRecDepoTotal1.Deposit != accRecDepoTotal2.Deposit) resList.Add("Deposit");
            if (accRecDepoTotal1.EnterpriseName != accRecDepoTotal2.EnterpriseName) resList.Add("EnterpriseName");
            if (accRecDepoTotal1.UpdEmployeeName != accRecDepoTotal2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (accRecDepoTotal1.AddUpSecName != accRecDepoTotal2.AddUpSecName) resList.Add("AddUpSecName");
            if (accRecDepoTotal1.MoneyKindDivName != accRecDepoTotal2.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }
    }
}
