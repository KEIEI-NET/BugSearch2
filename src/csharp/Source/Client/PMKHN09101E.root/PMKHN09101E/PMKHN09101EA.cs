using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustSlipNoSet
    /// <summary>
    ///                      得意先マスタ（伝票番号）
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先マスタ（伝票番号）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/6/13</br>
    /// <br>Genarated Date   :   2008/06/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2008.09.22 30452 上野 俊治</br>
    /// <br>                   PM.NS対応</br>
    /// <br>                   ・得意先伝票番号ヘッダ、得意先伝票番号フッタを削除</br>
    /// </remarks>
    public class CustSlipNoSet
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>現在得意先伝票番号</summary>
        private Int64 _presentCustSlipNo;

        /// <summary>開始得意先伝票番号</summary>
        private Int64 _startCustSlipNo;

        /// <summary>終了得意先伝票番号</summary>
        private Int64 _endCustSlipNo;

        // --- DEL 2008/09/22 -------------------------------->>>>>
        ///// <summary>得意先伝票番号ヘッダ</summary>
        //private string _custSlipNoHeader = "";

        ///// <summary>得意先伝票番号フッタ</summary>
        //private string _custSlipNoFooter = "";
        // --- DEL 2008/09/22 --------------------------------<<<<<

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  PresentCustSlipNo
        /// <summary>現在得意先伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在得意先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PresentCustSlipNo
        {
            get { return _presentCustSlipNo; }
            set { _presentCustSlipNo = value; }
        }

        /// public propaty name  :  StartCustSlipNo
        /// <summary>開始得意先伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StartCustSlipNo
        {
            get { return _startCustSlipNo; }
            set { _startCustSlipNo = value; }
        }

        /// public propaty name  :  EndCustSlipNo
        /// <summary>終了得意先伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 EndCustSlipNo
        {
            get { return _endCustSlipNo; }
            set { _endCustSlipNo = value; }
        }

        // --- DEL 2008/09/22 -------------------------------->>>>>
        ///// public propaty name  :  CustSlipNoHeader
        ///// <summary>得意先伝票番号ヘッダプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先伝票番号ヘッダプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustSlipNoHeader
        //{
        //    get { return _custSlipNoHeader; }
        //    set { _custSlipNoHeader = value; }
        //}

        ///// public propaty name  :  CustSlipNoFooter
        ///// <summary>得意先伝票番号フッタプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先伝票番号フッタプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustSlipNoFooter
        //{
        //    get { return _custSlipNoFooter; }
        //    set { _custSlipNoFooter = value; }
        //}
        // --- DEL 2008/09/22 --------------------------------<<<<<

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


        /// <summary>
        /// 得意先マスタ（伝票番号）コンストラクタ
        /// </summary>
        /// <returns>CustSlipNoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSlipNoSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustSlipNoSet()
        {
        }

        /// <summary>
        /// 得意先マスタ（伝票番号）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="addUpYearMonth">計上年月(YYYYMM)</param>
        /// <param name="presentCustSlipNo">現在得意先伝票番号</param>
        /// <param name="startCustSlipNo">開始得意先伝票番号</param>
        /// <param name="endCustSlipNo">終了得意先伝票番号</param>
        /// <param name="custSlipNoHeader">得意先伝票番号ヘッダ</param>
        /// <param name="custSlipNoFooter">得意先伝票番号フッタ</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>CustSlipNoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSlipNoSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustSlipNoSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int32 addUpYearMonth, Int64 presentCustSlipNo, Int64 startCustSlipNo, Int64 endCustSlipNo, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this.AddUpYearMonth = addUpYearMonth;
            this._presentCustSlipNo = presentCustSlipNo;
            this._startCustSlipNo = startCustSlipNo;
            this._endCustSlipNo = endCustSlipNo;
            //this._custSlipNoHeader = custSlipNoHeader; //DEL 2008/09/22
            //this._custSlipNoFooter = custSlipNoFooter; //DEL 2008/09/22
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 得意先マスタ（伝票番号）複製処理
        /// </summary>
        /// <returns>CustSlipNoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustSlipNoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustSlipNoSet Clone()
        {
            //return new CustSlipNoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._addUpYearMonth, this._presentCustSlipNo, this._startCustSlipNo, this._endCustSlipNo, this._custSlipNoHeader, this._custSlipNoFooter, this._enterpriseName, this._updEmployeeName); //DEL 2008/09/22
            return new CustSlipNoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._addUpYearMonth, this._presentCustSlipNo, this._startCustSlipNo, this._endCustSlipNo, this._enterpriseName, this._updEmployeeName); //ADD 2008/09/22
        }

        /// <summary>
        /// 得意先マスタ（伝票番号）比較処理
        /// </summary>
        /// <param name="target">比較対象のCustSlipNoSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSlipNoSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustSlipNoSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.PresentCustSlipNo == target.PresentCustSlipNo)
                 && (this.StartCustSlipNo == target.StartCustSlipNo)
                 && (this.EndCustSlipNo == target.EndCustSlipNo)
                 //&& (this.CustSlipNoHeader == target.CustSlipNoHeader) //DEL 2008/09/22
                 //&& (this.CustSlipNoFooter == target.CustSlipNoFooter) //DEL 2008/09/22
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 得意先マスタ（伝票番号）比較処理
        /// </summary>
        /// <param name="custSlipNoSet1">
        ///                    比較するCustSlipNoSetクラスのインスタンス
        /// </param>
        /// <param name="custSlipNoSet2">比較するCustSlipNoSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSlipNoSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustSlipNoSet custSlipNoSet1, CustSlipNoSet custSlipNoSet2)
        {
            return ((custSlipNoSet1.CreateDateTime == custSlipNoSet2.CreateDateTime)
                 && (custSlipNoSet1.UpdateDateTime == custSlipNoSet2.UpdateDateTime)
                 && (custSlipNoSet1.EnterpriseCode == custSlipNoSet2.EnterpriseCode)
                 && (custSlipNoSet1.FileHeaderGuid == custSlipNoSet2.FileHeaderGuid)
                 && (custSlipNoSet1.UpdEmployeeCode == custSlipNoSet2.UpdEmployeeCode)
                 && (custSlipNoSet1.UpdAssemblyId1 == custSlipNoSet2.UpdAssemblyId1)
                 && (custSlipNoSet1.UpdAssemblyId2 == custSlipNoSet2.UpdAssemblyId2)
                 && (custSlipNoSet1.LogicalDeleteCode == custSlipNoSet2.LogicalDeleteCode)
                 && (custSlipNoSet1.CustomerCode == custSlipNoSet2.CustomerCode)
                 && (custSlipNoSet1.AddUpYearMonth == custSlipNoSet2.AddUpYearMonth)
                 && (custSlipNoSet1.PresentCustSlipNo == custSlipNoSet2.PresentCustSlipNo)
                 && (custSlipNoSet1.StartCustSlipNo == custSlipNoSet2.StartCustSlipNo)
                 && (custSlipNoSet1.EndCustSlipNo == custSlipNoSet2.EndCustSlipNo)
                 //&& (custSlipNoSet1.CustSlipNoHeader == custSlipNoSet2.CustSlipNoHeader) //DEL 2008/09/22
                 //&& (custSlipNoSet1.CustSlipNoFooter == custSlipNoSet2.CustSlipNoFooter) //DEL 2008/09/22
                 && (custSlipNoSet1.EnterpriseName == custSlipNoSet2.EnterpriseName)
                 && (custSlipNoSet1.UpdEmployeeName == custSlipNoSet2.UpdEmployeeName));
        }
        /// <summary>
        /// 得意先マスタ（伝票番号）比較処理
        /// </summary>
        /// <param name="target">比較対象のCustSlipNoSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSlipNoSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustSlipNoSet target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.PresentCustSlipNo != target.PresentCustSlipNo) resList.Add("PresentCustSlipNo");
            if (this.StartCustSlipNo != target.StartCustSlipNo) resList.Add("StartCustSlipNo");
            if (this.EndCustSlipNo != target.EndCustSlipNo) resList.Add("EndCustSlipNo");
            //if (this.CustSlipNoHeader != target.CustSlipNoHeader) resList.Add("CustSlipNoHeader"); //DEL 2008/09/22
            //if (this.CustSlipNoFooter != target.CustSlipNoFooter) resList.Add("CustSlipNoFooter"); //DEL 2008/09/22
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 得意先マスタ（伝票番号）比較処理
        /// </summary>
        /// <param name="custSlipNoSet1">比較するCustSlipNoSetクラスのインスタンス</param>
        /// <param name="custSlipNoSet2">比較するCustSlipNoSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustSlipNoSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustSlipNoSet custSlipNoSet1, CustSlipNoSet custSlipNoSet2)
        {
            ArrayList resList = new ArrayList();
            if (custSlipNoSet1.CreateDateTime != custSlipNoSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (custSlipNoSet1.UpdateDateTime != custSlipNoSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (custSlipNoSet1.EnterpriseCode != custSlipNoSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custSlipNoSet1.FileHeaderGuid != custSlipNoSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (custSlipNoSet1.UpdEmployeeCode != custSlipNoSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (custSlipNoSet1.UpdAssemblyId1 != custSlipNoSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (custSlipNoSet1.UpdAssemblyId2 != custSlipNoSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (custSlipNoSet1.LogicalDeleteCode != custSlipNoSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (custSlipNoSet1.CustomerCode != custSlipNoSet2.CustomerCode) resList.Add("CustomerCode");
            if (custSlipNoSet1.AddUpYearMonth != custSlipNoSet2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (custSlipNoSet1.PresentCustSlipNo != custSlipNoSet2.PresentCustSlipNo) resList.Add("PresentCustSlipNo");
            if (custSlipNoSet1.StartCustSlipNo != custSlipNoSet2.StartCustSlipNo) resList.Add("StartCustSlipNo");
            if (custSlipNoSet1.EndCustSlipNo != custSlipNoSet2.EndCustSlipNo) resList.Add("EndCustSlipNo");
            //if (custSlipNoSet1.CustSlipNoHeader != custSlipNoSet2.CustSlipNoHeader) resList.Add("CustSlipNoHeader"); //DEL 2008/09/22
            //if (custSlipNoSet1.CustSlipNoFooter != custSlipNoSet2.CustSlipNoFooter) resList.Add("CustSlipNoFooter"); //DEL 2008/09/22
            if (custSlipNoSet1.EnterpriseName != custSlipNoSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (custSlipNoSet1.UpdEmployeeName != custSlipNoSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
