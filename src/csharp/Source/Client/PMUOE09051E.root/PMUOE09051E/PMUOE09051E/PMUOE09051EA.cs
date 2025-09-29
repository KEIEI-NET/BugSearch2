using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEConnectInfo
    /// <summary>
    ///                      UOE接続先情報マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE接続先情報マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/05/14</br>
    /// <br>Genarated Date   :   2010/07/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEConnectInfo
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

        /// <summary>通信アセンブリID</summary>
        private string _commAssemblyId = "";

        /// <summary>レジ番号</summary>
        private Int32 _cashRegisterNo;

        /// <summary>ソケット通信ポート番号</summary>
        private Int32 _socketCommPort;

        /// <summary>受信コンピューター名</summary>
        private string _receiveComputerNm = "";

        /// <summary>クライアントタイムアウト</summary>
        private Int32 _clientTimeOut;

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

        /// public propaty name  :  CommAssemblyId
        /// <summary>通信アセンブリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信アセンブリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  SocketCommPort
        /// <summary>ソケット通信ポート番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ソケット通信ポート番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SocketCommPort
        {
            get { return _socketCommPort; }
            set { _socketCommPort = value; }
        }

        /// public propaty name  :  ReceiveComputerNm
        /// <summary>受信コンピューター名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信コンピューター名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveComputerNm
        {
            get { return _receiveComputerNm; }
            set { _receiveComputerNm = value; }
        }

        /// public propaty name  :  ClientTimeOut
        /// <summary>クライアントタイムアウトプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クライアントタイムアウトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClientTimeOut
        {
            get { return _clientTimeOut; }
            set { _clientTimeOut = value; }
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


        /// <summary>
        /// UOE接続先情報マスタコンストラクタ
        /// </summary>
        /// <returns>UOEConnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEConnectInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEConnectInfo()
        {
        }

        /// <summary>
        /// UOE接続先情報マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="socketCommPort">ソケット通信ポート番号</param>
        /// <param name="receiveComputerNm">受信コンピューター名</param>
        /// <param name="clientTimeOut">クライアントタイムアウト</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>UOEConnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEConnectInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEConnectInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string commAssemblyId, Int32 cashRegisterNo, Int32 socketCommPort, string receiveComputerNm, Int32 clientTimeOut, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._commAssemblyId = commAssemblyId;
            this._cashRegisterNo = cashRegisterNo;
            this._socketCommPort = socketCommPort;
            this._receiveComputerNm = receiveComputerNm;
            this._clientTimeOut = clientTimeOut;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// UOE接続先情報マスタ複製処理
        /// </summary>
        /// <returns>UOEConnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOEConnectInfoクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEConnectInfo Clone()
        {
            return new UOEConnectInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._commAssemblyId, this._cashRegisterNo, this._socketCommPort, this._receiveComputerNm, this._clientTimeOut, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// UOE接続先情報マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEConnectInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEConnectInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOEConnectInfo target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CommAssemblyId == target.CommAssemblyId)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.SocketCommPort == target.SocketCommPort)
                 && (this.ReceiveComputerNm == target.ReceiveComputerNm)
                 && (this.ClientTimeOut == target.ClientTimeOut)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// UOE接続先情報マスタ比較処理
        /// </summary>
        /// <param name="uOEConnectInfo1">
        ///                    比較するUOEConnectInfoクラスのインスタンス
        /// </param>
        /// <param name="uOEConnectInfo2">比較するUOEConnectInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEConnectInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOEConnectInfo uOEConnectInfo1, UOEConnectInfo uOEConnectInfo2)
        {
            return ((uOEConnectInfo1.CreateDateTime == uOEConnectInfo2.CreateDateTime)
                 && (uOEConnectInfo1.UpdateDateTime == uOEConnectInfo2.UpdateDateTime)
                 && (uOEConnectInfo1.EnterpriseCode == uOEConnectInfo2.EnterpriseCode)
                 && (uOEConnectInfo1.FileHeaderGuid == uOEConnectInfo2.FileHeaderGuid)
                 && (uOEConnectInfo1.UpdEmployeeCode == uOEConnectInfo2.UpdEmployeeCode)
                 && (uOEConnectInfo1.UpdAssemblyId1 == uOEConnectInfo2.UpdAssemblyId1)
                 && (uOEConnectInfo1.UpdAssemblyId2 == uOEConnectInfo2.UpdAssemblyId2)
                 && (uOEConnectInfo1.LogicalDeleteCode == uOEConnectInfo2.LogicalDeleteCode)
                 && (uOEConnectInfo1.CommAssemblyId == uOEConnectInfo2.CommAssemblyId)
                 && (uOEConnectInfo1.CashRegisterNo == uOEConnectInfo2.CashRegisterNo)
                 && (uOEConnectInfo1.SocketCommPort == uOEConnectInfo2.SocketCommPort)
                 && (uOEConnectInfo1.ReceiveComputerNm == uOEConnectInfo2.ReceiveComputerNm)
                 && (uOEConnectInfo1.ClientTimeOut == uOEConnectInfo2.ClientTimeOut)
                 && (uOEConnectInfo1.EnterpriseName == uOEConnectInfo2.EnterpriseName)
                 && (uOEConnectInfo1.UpdEmployeeName == uOEConnectInfo2.UpdEmployeeName));
        }
        /// <summary>
        /// UOE接続先情報マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEConnectInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEConnectInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOEConnectInfo target)
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
            if (this.CommAssemblyId != target.CommAssemblyId) resList.Add("CommAssemblyId");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.SocketCommPort != target.SocketCommPort) resList.Add("SocketCommPort");
            if (this.ReceiveComputerNm != target.ReceiveComputerNm) resList.Add("ReceiveComputerNm");
            if (this.ClientTimeOut != target.ClientTimeOut) resList.Add("ClientTimeOut");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// UOE接続先情報マスタ比較処理
        /// </summary>
        /// <param name="uOEConnectInfo1">比較するUOEConnectInfoクラスのインスタンス</param>
        /// <param name="uOEConnectInfo2">比較するUOEConnectInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEConnectInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOEConnectInfo uOEConnectInfo1, UOEConnectInfo uOEConnectInfo2)
        {
            ArrayList resList = new ArrayList();
            if (uOEConnectInfo1.CreateDateTime != uOEConnectInfo2.CreateDateTime) resList.Add("CreateDateTime");
            if (uOEConnectInfo1.UpdateDateTime != uOEConnectInfo2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (uOEConnectInfo1.EnterpriseCode != uOEConnectInfo2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEConnectInfo1.FileHeaderGuid != uOEConnectInfo2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (uOEConnectInfo1.UpdEmployeeCode != uOEConnectInfo2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (uOEConnectInfo1.UpdAssemblyId1 != uOEConnectInfo2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (uOEConnectInfo1.UpdAssemblyId2 != uOEConnectInfo2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (uOEConnectInfo1.LogicalDeleteCode != uOEConnectInfo2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (uOEConnectInfo1.CommAssemblyId != uOEConnectInfo2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (uOEConnectInfo1.CashRegisterNo != uOEConnectInfo2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (uOEConnectInfo1.SocketCommPort != uOEConnectInfo2.SocketCommPort) resList.Add("SocketCommPort");
            if (uOEConnectInfo1.ReceiveComputerNm != uOEConnectInfo2.ReceiveComputerNm) resList.Add("ReceiveComputerNm");
            if (uOEConnectInfo1.ClientTimeOut != uOEConnectInfo2.ClientTimeOut) resList.Add("ClientTimeOut");
            if (uOEConnectInfo1.EnterpriseName != uOEConnectInfo2.EnterpriseName) resList.Add("EnterpriseName");
            if (uOEConnectInfo1.UpdEmployeeName != uOEConnectInfo2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
