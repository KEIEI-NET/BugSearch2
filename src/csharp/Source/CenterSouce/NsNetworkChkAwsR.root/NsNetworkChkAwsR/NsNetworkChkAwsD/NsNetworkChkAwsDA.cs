using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AWSComRsltWork
    /// <summary>
    ///                      AWS通信テスト結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   AWS通信テスト結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2018/12/27</br>
    /// <br>Genarated Date   :   2019/02/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2019/2/6  前田　崇</br>
    /// <br>                 :   Windowsバージョンの項目追加</br>
    /// <br>                 :   WindowsOS名の項目追加</br>
    /// <br>                 :   予備項目１の項目追加</br>
    /// <br>                 :   予備項目２の項目追加</br>
    /// <br>                 :   予備項目３の項目追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AWSComRsltWork : IFileHeader
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

        /// <summary>拠点コード</summary>
        /// <remarks>ログインの拠点</remarks>
        private string _sectionCode = "";

        /// <summary>ユーザー設定識別ID</summary>
        /// <remarks>各ユーザー端末単位で一意となるID</remarks>
        private string _userSetDiscId = "";

        /// <summary>チェック日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _checkDate;

        /// <summary>チェック時間</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _checkTime;

        /// <summary>コンピュータ名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _computerName = "";

        /// <summary>テスト名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _testName = "";

        /// <summary>サーバータイプ</summary>
        /// <remarks>0:WEB,1:AP,2:配信,3:プロキシ</remarks>
        private Int16 _serverType;

        /// <summary>テストタイプ</summary>
        /// <remarks>0:テストしない,1:HTTPリクエスト,2:ポートチェック,3:配信</remarks>
        private Int16 _testType;

        /// <summary>テスト対象アドレス</summary>
        /// <remarks>(半角全角混在) 暗号化</remarks>
        private string _testObjAddr = "";

        /// <summary>チェック結果</summary>
        /// <remarks>0:通信成功,1:通信失敗</remarks>
        private Int16 _checkRslt;

        /// <summary>リクエストステータスNo</summary>
        /// <remarks>(例)200:リクエスト成功,404:リモートサーバーが見つかりません</remarks>
        private Int32 _requestStatusNo;

        /// <summary>リクエストメッセージ</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _requestMessage = "";

        /// <summary>Windowsバージョン</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _windowsVersion = "";

        /// <summary>WindowsOS名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _windowsOSName = "";

        /// <summary>予備項目１</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _awsReserved1 = "";

        /// <summary>予備項目２</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _awsReserved2 = "";

        /// <summary>予備項目３</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _awsReserved3 = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>ログインの拠点</value>
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

        /// public propaty name  :  UserSetDiscId
        /// <summary>ユーザー設定識別IDプロパティ</summary>
        /// <value>各ユーザー端末単位で一意となるID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー設定識別IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UserSetDiscId
        {
            get { return _userSetDiscId; }
            set { _userSetDiscId = value; }
        }

        /// public propaty name  :  CheckDate
        /// <summary>チェック日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckDate
        {
            get { return _checkDate; }
            set { _checkDate = value; }
        }

        /// public propaty name  :  CheckTime
        /// <summary>チェック時間プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckTime
        {
            get { return _checkTime; }
            set { _checkTime = value; }
        }

        /// public propaty name  :  ComputerName
        /// <summary>コンピュータ名称プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンピュータ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ComputerName
        {
            get { return _computerName; }
            set { _computerName = value; }
        }

        /// public propaty name  :  TestName
        /// <summary>テスト名称プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テスト名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        /// public propaty name  :  ServerType
        /// <summary>サーバータイププロパティ</summary>
        /// <value>0:WEB,1:AP,2:配信,3:プロキシ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバータイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ServerType
        {
            get { return _serverType; }
            set { _serverType = value; }
        }

        /// public propaty name  :  TestType
        /// <summary>テストタイププロパティ</summary>
        /// <value>0:テストしない,1:HTTPリクエスト,2:ポートチェック,3:配信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テストタイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 TestType
        {
            get { return _testType; }
            set { _testType = value; }
        }

        /// public propaty name  :  TestObjAddr
        /// <summary>テスト対象アドレスプロパティ</summary>
        /// <value>(半角全角混在) 暗号化</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テスト対象アドレスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TestObjAddr
        {
            get { return _testObjAddr; }
            set { _testObjAddr = value; }
        }

        /// public propaty name  :  CheckRslt
        /// <summary>チェック結果プロパティ</summary>
        /// <value>0:通信成功,1:通信失敗</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック結果プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CheckRslt
        {
            get { return _checkRslt; }
            set { _checkRslt = value; }
        }

        /// public propaty name  :  RequestStatusNo
        /// <summary>リクエストステータスNoプロパティ</summary>
        /// <value>(例)200:リクエスト成功,404:リモートサーバーが見つかりません</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リクエストステータスNoプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RequestStatusNo
        {
            get { return _requestStatusNo; }
            set { _requestStatusNo = value; }
        }

        /// public propaty name  :  RequestMessage
        /// <summary>リクエストメッセージプロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リクエストメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RequestMessage
        {
            get { return _requestMessage; }
            set { _requestMessage = value; }
        }

        /// public propaty name  :  WindowsVersion
        /// <summary>Windowsバージョンプロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Windowsバージョンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WindowsVersion
        {
            get { return _windowsVersion; }
            set { _windowsVersion = value; }
        }

        /// public propaty name  :  WindowsOSName
        /// <summary>WindowsOS名プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WindowsOS名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WindowsOSName
        {
            get { return _windowsOSName; }
            set { _windowsOSName = value; }
        }

        /// public propaty name  :  AwsReserved1
        /// <summary>予備項目１プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   予備項目１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AwsReserved1
        {
            get { return _awsReserved1; }
            set { _awsReserved1 = value; }
        }

        /// public propaty name  :  AwsReserved2
        /// <summary>予備項目２プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   予備項目２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AwsReserved2
        {
            get { return _awsReserved2; }
            set { _awsReserved2 = value; }
        }

        /// public propaty name  :  AwsReserved3
        /// <summary>予備項目３プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   予備項目３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AwsReserved3
        {
            get { return _awsReserved3; }
            set { _awsReserved3 = value; }
        }


        /// <summary>
        /// AWS通信テスト結果ワークコンストラクタ
        /// </summary>
        /// <returns>AWSComRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AWSComRsltWork()
        {
        }

        /// <summary>
        /// AWS通信テスト結果ワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(ログインの拠点)</param>
        /// <param name="userSetDiscId">ユーザー設定識別ID(各ユーザー端末単位で一意となるID)</param>
        /// <param name="checkDate">チェック日付(YYYYMMDD)</param>
        /// <param name="checkTime">チェック時間(HHMMSS)</param>
        /// <param name="computerName">コンピュータ名称((半角全角混在))</param>
        /// <param name="testName">テスト名称((半角全角混在))</param>
        /// <param name="serverType">サーバータイプ(0:WEB,1:AP,2:配信,3:プロキシ)</param>
        /// <param name="testType">テストタイプ(0:テストしない,1:HTTPリクエスト,2:ポートチェック,3:配信)</param>
        /// <param name="testObjAddr">テスト対象アドレス((半角全角混在) 暗号化)</param>
        /// <param name="checkRslt">チェック結果(0:通信成功,1:通信失敗)</param>
        /// <param name="requestStatusNo">リクエストステータスNo((例)200:リクエスト成功,404:リモートサーバーが見つかりません)</param>
        /// <param name="requestMessage">リクエストメッセージ((半角全角混在))</param>
        /// <param name="windowsVersion">Windowsバージョン((半角全角混在))</param>
        /// <param name="windowsOSName">WindowsOS名((半角全角混在))</param>
        /// <param name="awsReserved1">予備項目１((半角全角混在))</param>
        /// <param name="awsReserved2">予備項目２((半角全角混在))</param>
        /// <param name="awsReserved3">予備項目３((半角全角混在))</param>
        /// <returns>AWSComRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AWSComRsltWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string userSetDiscId, Int32 checkDate, Int32 checkTime, string computerName, string testName, Int16 serverType, Int16 testType, string testObjAddr, Int16 checkRslt, Int32 requestStatusNo, string requestMessage, string windowsVersion, string windowsOSName, string awsReserved1, string awsReserved2, string awsReserved3)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._userSetDiscId = userSetDiscId;
            this._checkDate = checkDate;
            this._checkTime = checkTime;
            this._computerName = computerName;
            this._testName = testName;
            this._serverType = serverType;
            this._testType = testType;
            this._testObjAddr = testObjAddr;
            this._checkRslt = checkRslt;
            this._requestStatusNo = requestStatusNo;
            this._requestMessage = requestMessage;
            this._windowsVersion = windowsVersion;
            this._windowsOSName = windowsOSName;
            this._awsReserved1 = awsReserved1;
            this._awsReserved2 = awsReserved2;
            this._awsReserved3 = awsReserved3;

        }

        /// <summary>
        /// AWS通信テスト結果ワーク複製処理
        /// </summary>
        /// <returns>AWSComRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAWSComRsltWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AWSComRsltWork Clone()
        {
            return new AWSComRsltWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._userSetDiscId, this._checkDate, this._checkTime, this._computerName, this._testName, this._serverType, this._testType, this._testObjAddr, this._checkRslt, this._requestStatusNo, this._requestMessage, this._windowsVersion, this._windowsOSName, this._awsReserved1, this._awsReserved2, this._awsReserved3);
        }

        /// <summary>
        /// AWS通信テスト結果ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のAWSComRsltWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AWSComRsltWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UserSetDiscId == target.UserSetDiscId)
                 && (this.CheckDate == target.CheckDate)
                 && (this.CheckTime == target.CheckTime)
                 && (this.ComputerName == target.ComputerName)
                 && (this.TestName == target.TestName)
                 && (this.ServerType == target.ServerType)
                 && (this.TestType == target.TestType)
                 && (this.TestObjAddr == target.TestObjAddr)
                 && (this.CheckRslt == target.CheckRslt)
                 && (this.RequestStatusNo == target.RequestStatusNo)
                 && (this.RequestMessage == target.RequestMessage)
                 && (this.WindowsVersion == target.WindowsVersion)
                 && (this.WindowsOSName == target.WindowsOSName)
                 && (this.AwsReserved1 == target.AwsReserved1)
                 && (this.AwsReserved2 == target.AwsReserved2)
                 && (this.AwsReserved3 == target.AwsReserved3));
        }

        /// <summary>
        /// AWS通信テスト結果ワーク比較処理
        /// </summary>
        /// <param name="aWSComRslt1">
        ///                    比較するAWSComRsltWorkクラスのインスタンス
        /// </param>
        /// <param name="aWSComRslt2">比較するAWSComRsltWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AWSComRsltWork aWSComRslt1, AWSComRsltWork aWSComRslt2)
        {
            return ((aWSComRslt1.CreateDateTime == aWSComRslt2.CreateDateTime)
                 && (aWSComRslt1.UpdateDateTime == aWSComRslt2.UpdateDateTime)
                 && (aWSComRslt1.EnterpriseCode == aWSComRslt2.EnterpriseCode)
                 && (aWSComRslt1.FileHeaderGuid == aWSComRslt2.FileHeaderGuid)
                 && (aWSComRslt1.UpdEmployeeCode == aWSComRslt2.UpdEmployeeCode)
                 && (aWSComRslt1.UpdAssemblyId1 == aWSComRslt2.UpdAssemblyId1)
                 && (aWSComRslt1.UpdAssemblyId2 == aWSComRslt2.UpdAssemblyId2)
                 && (aWSComRslt1.LogicalDeleteCode == aWSComRslt2.LogicalDeleteCode)
                 && (aWSComRslt1.SectionCode == aWSComRslt2.SectionCode)
                 && (aWSComRslt1.UserSetDiscId == aWSComRslt2.UserSetDiscId)
                 && (aWSComRslt1.CheckDate == aWSComRslt2.CheckDate)
                 && (aWSComRslt1.CheckTime == aWSComRslt2.CheckTime)
                 && (aWSComRslt1.ComputerName == aWSComRslt2.ComputerName)
                 && (aWSComRslt1.TestName == aWSComRslt2.TestName)
                 && (aWSComRslt1.ServerType == aWSComRslt2.ServerType)
                 && (aWSComRslt1.TestType == aWSComRslt2.TestType)
                 && (aWSComRslt1.TestObjAddr == aWSComRslt2.TestObjAddr)
                 && (aWSComRslt1.CheckRslt == aWSComRslt2.CheckRslt)
                 && (aWSComRslt1.RequestStatusNo == aWSComRslt2.RequestStatusNo)
                 && (aWSComRslt1.RequestMessage == aWSComRslt2.RequestMessage)
                 && (aWSComRslt1.WindowsVersion == aWSComRslt2.WindowsVersion)
                 && (aWSComRslt1.WindowsOSName == aWSComRslt2.WindowsOSName)
                 && (aWSComRslt1.AwsReserved1 == aWSComRslt2.AwsReserved1)
                 && (aWSComRslt1.AwsReserved2 == aWSComRslt2.AwsReserved2)
                 && (aWSComRslt1.AwsReserved3 == aWSComRslt2.AwsReserved3));
        }
        /// <summary>
        /// AWS通信テスト結果ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のAWSComRsltWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AWSComRsltWork target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UserSetDiscId != target.UserSetDiscId) resList.Add("UserSetDiscId");
            if (this.CheckDate != target.CheckDate) resList.Add("CheckDate");
            if (this.CheckTime != target.CheckTime) resList.Add("CheckTime");
            if (this.ComputerName != target.ComputerName) resList.Add("ComputerName");
            if (this.TestName != target.TestName) resList.Add("TestName");
            if (this.ServerType != target.ServerType) resList.Add("ServerType");
            if (this.TestType != target.TestType) resList.Add("TestType");
            if (this.TestObjAddr != target.TestObjAddr) resList.Add("TestObjAddr");
            if (this.CheckRslt != target.CheckRslt) resList.Add("CheckRslt");
            if (this.RequestStatusNo != target.RequestStatusNo) resList.Add("RequestStatusNo");
            if (this.RequestMessage != target.RequestMessage) resList.Add("RequestMessage");
            if (this.WindowsVersion != target.WindowsVersion) resList.Add("WindowsVersion");
            if (this.WindowsOSName != target.WindowsOSName) resList.Add("WindowsOSName");
            if (this.AwsReserved1 != target.AwsReserved1) resList.Add("AwsReserved1");
            if (this.AwsReserved2 != target.AwsReserved2) resList.Add("AwsReserved2");
            if (this.AwsReserved3 != target.AwsReserved3) resList.Add("AwsReserved3");

            return resList;
        }

        /// <summary>
        /// AWS通信テスト結果ワーク比較処理
        /// </summary>
        /// <param name="aWSComRslt1">比較するAWSComRsltWorkクラスのインスタンス</param>
        /// <param name="aWSComRslt2">比較するAWSComRsltWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AWSComRsltWork aWSComRslt1, AWSComRsltWork aWSComRslt2)
        {
            ArrayList resList = new ArrayList();
            if (aWSComRslt1.CreateDateTime != aWSComRslt2.CreateDateTime) resList.Add("CreateDateTime");
            if (aWSComRslt1.UpdateDateTime != aWSComRslt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (aWSComRslt1.EnterpriseCode != aWSComRslt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (aWSComRslt1.FileHeaderGuid != aWSComRslt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (aWSComRslt1.UpdEmployeeCode != aWSComRslt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (aWSComRslt1.UpdAssemblyId1 != aWSComRslt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (aWSComRslt1.UpdAssemblyId2 != aWSComRslt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (aWSComRslt1.LogicalDeleteCode != aWSComRslt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (aWSComRslt1.SectionCode != aWSComRslt2.SectionCode) resList.Add("SectionCode");
            if (aWSComRslt1.UserSetDiscId != aWSComRslt2.UserSetDiscId) resList.Add("UserSetDiscId");
            if (aWSComRslt1.CheckDate != aWSComRslt2.CheckDate) resList.Add("CheckDate");
            if (aWSComRslt1.CheckTime != aWSComRslt2.CheckTime) resList.Add("CheckTime");
            if (aWSComRslt1.ComputerName != aWSComRslt2.ComputerName) resList.Add("ComputerName");
            if (aWSComRslt1.TestName != aWSComRslt2.TestName) resList.Add("TestName");
            if (aWSComRslt1.ServerType != aWSComRslt2.ServerType) resList.Add("ServerType");
            if (aWSComRslt1.TestType != aWSComRslt2.TestType) resList.Add("TestType");
            if (aWSComRslt1.TestObjAddr != aWSComRslt2.TestObjAddr) resList.Add("TestObjAddr");
            if (aWSComRslt1.CheckRslt != aWSComRslt2.CheckRslt) resList.Add("CheckRslt");
            if (aWSComRslt1.RequestStatusNo != aWSComRslt2.RequestStatusNo) resList.Add("RequestStatusNo");
            if (aWSComRslt1.RequestMessage != aWSComRslt2.RequestMessage) resList.Add("RequestMessage");
            if (aWSComRslt1.WindowsVersion != aWSComRslt2.WindowsVersion) resList.Add("WindowsVersion");
            if (aWSComRslt1.WindowsOSName != aWSComRslt2.WindowsOSName) resList.Add("WindowsOSName");
            if (aWSComRslt1.AwsReserved1 != aWSComRslt2.AwsReserved1) resList.Add("AwsReserved1");
            if (aWSComRslt1.AwsReserved2 != aWSComRslt2.AwsReserved2) resList.Add("AwsReserved2");
            if (aWSComRslt1.AwsReserved3 != aWSComRslt2.AwsReserved3) resList.Add("AwsReserved3");

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AWSComRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AWSComRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AWSComRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AWSComRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AWSComRsltWork || graph is ArrayList || graph is AWSComRsltWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AWSComRsltWork).FullName));

            if (graph != null && graph is AWSComRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AWSComRsltWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AWSComRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AWSComRsltWork[])graph).Length;
            }
            else if (graph is AWSComRsltWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //ユーザー設定識別ID
            serInfo.MemberInfo.Add(typeof(string)); //UserSetDiscId
            //チェック日付
            serInfo.MemberInfo.Add(typeof(Int32)); //CheckDate
            //チェック時間
            serInfo.MemberInfo.Add(typeof(Int32)); //CheckTime
            //コンピュータ名称
            serInfo.MemberInfo.Add(typeof(string)); //ComputerName
            //テスト名称
            serInfo.MemberInfo.Add(typeof(string)); //TestName
            //サーバータイプ
            serInfo.MemberInfo.Add(typeof(Int16)); //ServerType
            //テストタイプ
            serInfo.MemberInfo.Add(typeof(Int16)); //TestType
            //テスト対象アドレス
            serInfo.MemberInfo.Add(typeof(string)); //TestObjAddr
            //チェック結果
            serInfo.MemberInfo.Add(typeof(Int16)); //CheckRslt
            //リクエストステータスNo
            serInfo.MemberInfo.Add(typeof(Int32)); //RequestStatusNo
            //リクエストメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //RequestMessage
            //Windowsバージョン
            serInfo.MemberInfo.Add(typeof(string)); //WindowsVersion
            //WindowsOS名
            serInfo.MemberInfo.Add(typeof(string)); //WindowsOSName
            //予備項目１
            serInfo.MemberInfo.Add(typeof(string)); //AwsReserved1
            //予備項目２
            serInfo.MemberInfo.Add(typeof(string)); //AwsReserved2
            //予備項目３
            serInfo.MemberInfo.Add(typeof(string)); //AwsReserved3


            serInfo.Serialize(writer, serInfo);
            if (graph is AWSComRsltWork)
            {
                AWSComRsltWork temp = (AWSComRsltWork)graph;

                SetAWSComRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AWSComRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AWSComRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AWSComRsltWork temp in lst)
                {
                    SetAWSComRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AWSComRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  AWSComRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAWSComRsltWork(System.IO.BinaryWriter writer, AWSComRsltWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //ユーザー設定識別ID
            writer.Write(temp.UserSetDiscId);
            //チェック日付
            writer.Write(temp.CheckDate);
            //チェック時間
            writer.Write(temp.CheckTime);
            //コンピュータ名称
            writer.Write(temp.ComputerName);
            //テスト名称
            writer.Write(temp.TestName);
            //サーバータイプ
            writer.Write(temp.ServerType);
            //テストタイプ
            writer.Write(temp.TestType);
            //テスト対象アドレス
            writer.Write(temp.TestObjAddr);
            //チェック結果
            writer.Write(temp.CheckRslt);
            //リクエストステータスNo
            writer.Write(temp.RequestStatusNo);
            //リクエストメッセージ
            writer.Write(temp.RequestMessage);
            //Windowsバージョン
            writer.Write(temp.WindowsVersion);
            //WindowsOS名
            writer.Write(temp.WindowsOSName);
            //予備項目１
            writer.Write(temp.AwsReserved1);
            //予備項目２
            writer.Write(temp.AwsReserved2);
            //予備項目３
            writer.Write(temp.AwsReserved3);

        }

        /// <summary>
        ///  AWSComRsltWorkインスタンス取得
        /// </summary>
        /// <returns>AWSComRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AWSComRsltWork GetAWSComRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AWSComRsltWork temp = new AWSComRsltWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //ユーザー設定識別ID
            temp.UserSetDiscId = reader.ReadString();
            //チェック日付
            temp.CheckDate = reader.ReadInt32();
            //チェック時間
            temp.CheckTime = reader.ReadInt32();
            //コンピュータ名称
            temp.ComputerName = reader.ReadString();
            //テスト名称
            temp.TestName = reader.ReadString();
            //サーバータイプ
            temp.ServerType = reader.ReadInt16();
            //テストタイプ
            temp.TestType = reader.ReadInt16();
            //テスト対象アドレス
            temp.TestObjAddr = reader.ReadString();
            //チェック結果
            temp.CheckRslt = reader.ReadInt16();
            //リクエストステータスNo
            temp.RequestStatusNo = reader.ReadInt32();
            //リクエストメッセージ
            temp.RequestMessage = reader.ReadString();
            //Windowsバージョン
            temp.WindowsVersion = reader.ReadString();
            //WindowsOS名
            temp.WindowsOSName = reader.ReadString();
            //予備項目１
            temp.AwsReserved1 = reader.ReadString();
            //予備項目２
            temp.AwsReserved2 = reader.ReadString();
            //予備項目３
            temp.AwsReserved3 = reader.ReadString();


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
        /// <returns>AWSComRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AWSComRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AWSComRsltWork temp = GetAWSComRsltWork(reader, serInfo);
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
                    retValue = (AWSComRsltWork[])lst.ToArray(typeof(AWSComRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
