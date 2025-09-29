using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConnectInfoWork
    /// <summary>
    ///                      接続先情報設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   接続先情報設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/6/26</br>
    /// <br>Genarated Date   :   2013/06/26  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConnectInfoWork : IFileHeader
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
        private Int32 _logicalDeleteCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>接続パスワード</summary>
        private string _connectPassword = "";

        /// <summary>接続ユーザID</summary>
        private string _connectUserId = "";

        /// <summary>発注手配区分（ダイハツ）</summary>
        private Int32 _daihatsuOrdreDiv;

        /// <summary>ログインタイムアウト</summary>
        private Int32 _loginTimeoutVal;

        /// <summary>発注URL</summary>
        private string _orderUrl = "";

        /// <summary>在庫確認URL</summary>
        private string _stockCheckUrl = "";

        /// <summary>接続プログラムタイプ</summary>
        private Int32 _cnectProgramType;

        /// <summary>接続ファイルID</summary>
        private string _cnectFileId = "";

        /// <summary>接続送信区分</summary>
        private Int32 _cnectSendDiv;

        /// <summary>接続対象区分</summary>
        private Int32 _cnectObjectDiv;

        /// <summary>リトライ回数</summary>
        private Int32 _retryCnt;

        /// <summary>自動送信区分</summary>
        private Int32 _autoSendDiv;

        /// <summary>起動時間</summary>
        private Int32 _bootTime;

        /// <summary>端末番号</summary>
        private Int32 _cashRegisterNo;

        /// <summary>送信端末(IPアドレス）</summary>
        private string _sendMachineIpAddr = "";

        /// <summary>送信端末(コンピューター名）</summary>
        private string _sendMachineName = "";

        /// <summary>S&E接続ユーザID</summary>
        private string _sandECnctUserId = "";

        /// <summary>S&E接続パスワード</summary>
        private string _sandECnctPass = "";

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

        /// public propaty name  :  ConnectPassword
        /// <summary>接続パスワードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続パスワードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ConnectPassword
        {
            get { return _connectPassword; }
            set { _connectPassword = value; }
        }

        /// public propaty name  :  ConnectUserId
        /// <summary>接続ユーザIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続ユーザIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ConnectUserId
        {
            get { return _connectUserId; }
            set { _connectUserId = value; }
        }

        /// public propaty name  :  DaihatsuOrdreDiv
        /// <summary>発注手配区分（ダイハツ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注手配区分（ダイハツ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DaihatsuOrdreDiv
        {
            get { return _daihatsuOrdreDiv; }
            set { _daihatsuOrdreDiv = value; }
        }

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>ログインタイムアウトプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインタイムアウトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LoginTimeoutVal
        {
            get { return _loginTimeoutVal; }
            set { _loginTimeoutVal = value; }
        }

        /// public propaty name  :  OrderUrl
        /// <summary>発注URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderUrl
        {
            get { return _orderUrl; }
            set { _orderUrl = value; }
        }

        /// public propaty name  :  StockCheckUrl
        /// <summary>在庫確認URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫確認URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockCheckUrl
        {
            get { return _stockCheckUrl; }
            set { _stockCheckUrl = value; }
        }

        /// public propaty name  :  CnectProgramType
        /// <summary>接続プログラムタイププロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続プログラムタイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CnectProgramType
        {
            get { return _cnectProgramType; }
            set { _cnectProgramType = value; }
        }

        /// public propaty name  :  CnectFileId
        /// <summary>接続ファイルIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続ファイルIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectFileId
        {
            get { return _cnectFileId; }
            set { _cnectFileId = value; }
        }

        /// public propaty name  :  CnectSendDiv
        /// <summary>接続送信区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CnectSendDiv
        {
            get { return _cnectSendDiv; }
            set { _cnectSendDiv = value; }
        }

        /// public propaty name  :  CnectObjectDiv
        /// <summary>接続対象区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   接続対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CnectObjectDiv
        {
            get { return _cnectObjectDiv; }
            set { _cnectObjectDiv = value; }
        }

        /// public propaty name  :  RetryCnt
        /// <summary>リトライ回数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リトライ回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetryCnt
        {
            get { return _retryCnt; }
            set { _retryCnt = value; }
        }

        /// public propaty name  :  AutoSendDiv
        /// <summary>自動送信区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoSendDiv
        {
            get { return _autoSendDiv; }
            set { _autoSendDiv = value; }
        }

        /// public propaty name  :  BootTime
        /// <summary>起動時間プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   起動時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BootTime
        {
            get { return _bootTime; }
            set { _bootTime = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>端末番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  SendMachineIpAddr
        /// <summary>送信端末(IPアドレス）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信端末(IPアドレス）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendMachineIpAddr
        {
            get { return _sendMachineIpAddr; }
            set { _sendMachineIpAddr = value; }
        }

        /// public propaty name  :  SendMachineName
        /// <summary>送信端末(コンピューター名）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信端末(コンピューター名）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendMachineName
        {
            get { return _sendMachineName; }
            set { _sendMachineName = value; }
        }

        /// public propaty name  :  SAndECnctUserId
        /// <summary>S&E接続ユーザIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   S&E接続ユーザIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SAndECnctUserId
        {
            get { return _sandECnctUserId; }
            set { _sandECnctUserId = value; }
        }

        /// public propaty name  :  SAndECnctPass
        /// <summaryS&E接続パスワードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   S&E接続パスワードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SAndECnctPass
        {
            get { return _sandECnctPass; }
            set { _sandECnctPass = value; }
        }

        /// <summary>
        /// 接続先情報設定ワークコンストラクタ
        /// </summary>
        /// <returns>ConnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConnectInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConnectInfoWork()
        {
        }

        /// <summary>
        /// 接続先情報設定ワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="connectPassword">接続パスワード</param>
        /// <param name="connectUserId">接続ユーザID</param>
        /// <param name="daihatsuOrdreDiv">発注手配区分（ダイハツ）</param>
        /// <param name="loginTimeoutVal">ログインタイムアウト</param>
        /// <param name="orderUrl">発注URL</param>
        /// <param name="stockCheckUrl">在庫確認URL</param>
        /// <param name="cnectProgramType">接続プログラムタイプ</param>
        /// <param name="cnectFileId">接続ファイルID</param>
        /// <param name="cnectSendDiv">接続送信区分</param>
        /// <param name="cnectObjectDiv">接続対象区分</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <param name="autoSendDiv">自動送信区分</param>
        /// <param name="bootTime">起動時間</param>
        /// <param name="sendMachineIpAddr">送信端末(IPアドレス）</param>
        /// <param name="sendMachineName">送信端末(コンピューター名）</param>
        /// <returns>ConnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConnectInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConnectInfoWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierCd, string connectPassword, string connectUserId, Int32 daihatsuOrdreDiv, Int32 loginTimeoutVal, string orderUrl, string stockCheckUrl, Int32 cnectProgramType, string cnectFileId, Int32 cnectSendDiv, Int32 cnectObjectDiv, Int32 retryCnt, Int32 autoSendDiv, Int32 bootTime, string sendMachineIpAddr, string sendMachineName, string sandECnctUserId, string sandECnctPass, int cashRegisterNo)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierCd = supplierCd;
            this._connectPassword = connectPassword;
            this._connectUserId = connectUserId;
            this._daihatsuOrdreDiv = daihatsuOrdreDiv;
            this._loginTimeoutVal = loginTimeoutVal;
            this._orderUrl = orderUrl;
            this._stockCheckUrl = stockCheckUrl;
            this._cnectProgramType = cnectProgramType;
            this._cnectFileId = cnectFileId;
            this._cnectSendDiv = cnectSendDiv;
            this._cnectObjectDiv = cnectObjectDiv;
            this._retryCnt = retryCnt;
            this._autoSendDiv = autoSendDiv;
            this._bootTime = bootTime;
            this._sendMachineIpAddr = sendMachineIpAddr;
            this._sendMachineName = sendMachineName;
            this._sandECnctUserId = sandECnctUserId;
            this._sandECnctPass = sandECnctPass;
            this._cashRegisterNo = cashRegisterNo;

        }

        /// <summary>
        /// 接続先情報設定ワーク複製処理
        /// </summary>
        /// <returns>ConnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいConnectInfoWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConnectInfoWork Clone()
        {
            return new ConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierCd, this._connectPassword, this._connectUserId, this._daihatsuOrdreDiv, this._loginTimeoutVal, this._orderUrl, this._stockCheckUrl, this._cnectProgramType, this._cnectFileId, this._cnectSendDiv, this._cnectObjectDiv, this._retryCnt, this._autoSendDiv, this._bootTime, this._sendMachineIpAddr, this._sendMachineName, this._sandECnctUserId, this._sandECnctPass, this._cashRegisterNo);
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ConnectInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ConnectInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ConnectInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConnectInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConnectInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConnectInfoWork || graph is ArrayList || graph is ConnectInfoWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ConnectInfoWork).FullName));

            if (graph != null && graph is ConnectInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConnectInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConnectInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConnectInfoWork[])graph).Length;
            }
            else if (graph is ConnectInfoWork)
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
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //接続パスワード
            serInfo.MemberInfo.Add(typeof(string)); //ConnectPassword
            //接続ユーザID
            serInfo.MemberInfo.Add(typeof(string)); //ConnectUserId
            //発注手配区分（ダイハツ）
            serInfo.MemberInfo.Add(typeof(Int32)); //DaihatsuOrdreDiv
            //ログインタイムアウト
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //発注URL
            serInfo.MemberInfo.Add(typeof(string)); //OrderUrl
            //在庫確認URL
            serInfo.MemberInfo.Add(typeof(string)); //StockCheckUrl
            //接続プログラムタイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectProgramType
            //接続ファイルID
            serInfo.MemberInfo.Add(typeof(string)); //CnectFileId
            //接続送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectSendDiv
            //接続対象区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectObjectDiv
            //リトライ回数
            serInfo.MemberInfo.Add(typeof(Int32)); //RetryCnt
            //自動送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoSendDiv
            //起動時間
            serInfo.MemberInfo.Add(typeof(Int32)); //BootTime
            //送信端末(IPアドレス）
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineIpAddr
            //送信端末(コンピューター名）
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineName
            //S&E接続ユーザID
            serInfo.MemberInfo.Add(typeof(string)); 
            //S&E接続パスワード
            serInfo.MemberInfo.Add(typeof(string));
            //端末番号
            serInfo.MemberInfo.Add(typeof(Int32)); 

            serInfo.Serialize(writer, serInfo);
            if (graph is ConnectInfoWork)
            {
                ConnectInfoWork temp = (ConnectInfoWork)graph;

                SetConnectInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConnectInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConnectInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConnectInfoWork temp in lst)
                {
                    SetConnectInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConnectInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 27; 

        /// <summary>
        ///  ConnectInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConnectInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetConnectInfoWork(System.IO.BinaryWriter writer, ConnectInfoWork temp)
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
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //接続パスワード
            writer.Write(temp.ConnectPassword);
            //接続ユーザID
            writer.Write(temp.ConnectUserId);
            //発注手配区分（ダイハツ）
            writer.Write(temp.DaihatsuOrdreDiv);
            //ログインタイムアウト
            writer.Write(temp.LoginTimeoutVal);
            //発注URL
            writer.Write(temp.OrderUrl);
            //在庫確認URL
            writer.Write(temp.StockCheckUrl);
            //接続プログラムタイプ
            writer.Write(temp.CnectProgramType);
            //接続ファイルID
            writer.Write(temp.CnectFileId);
            //接続送信区分
            writer.Write(temp.CnectSendDiv);
            //接続対象区分
            writer.Write(temp.CnectObjectDiv);
            //リトライ回数
            writer.Write(temp.RetryCnt);
            //自動送信区分
            writer.Write(temp.AutoSendDiv);
            //起動時間
            writer.Write(temp.BootTime);
            //送信端末(IPアドレス）
            writer.Write(temp.SendMachineIpAddr);
            //送信端末(コンピューター名）
            writer.Write(temp.SendMachineName);
            //S&E接続ユーザID
            writer.Write(temp.SAndECnctUserId);
            //S&E接続パスワード
            writer.Write(temp.SAndECnctPass);
            //端末番号
            writer.Write(temp.CashRegisterNo);
        }

        /// <summary>
        ///  ConnectInfoWorkインスタンス取得
        /// </summary>
        /// <returns>ConnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConnectInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ConnectInfoWork GetConnectInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ConnectInfoWork temp = new ConnectInfoWork();

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
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //接続パスワード
            temp.ConnectPassword = reader.ReadString();
            //接続ユーザID
            temp.ConnectUserId = reader.ReadString();
            //発注手配区分（ダイハツ）
            temp.DaihatsuOrdreDiv = reader.ReadInt32();
            //ログインタイムアウト
            temp.LoginTimeoutVal = reader.ReadInt32();
            //発注URL
            temp.OrderUrl = reader.ReadString();
            //在庫確認URL
            temp.StockCheckUrl = reader.ReadString();
            //接続プログラムタイプ
            temp.CnectProgramType = reader.ReadInt32();
            //接続ファイルID
            temp.CnectFileId = reader.ReadString();
            //接続送信区分
            temp.CnectSendDiv = reader.ReadInt32();
            //接続対象区分
            temp.CnectObjectDiv = reader.ReadInt32();
            //リトライ回数
            temp.RetryCnt = reader.ReadInt32();
            //自動送信区分
            temp.AutoSendDiv = reader.ReadInt32();
            //起動時間
            temp.BootTime = reader.ReadInt32();
            //送信端末(IPアドレス）
            temp.SendMachineIpAddr = reader.ReadString();
            //送信端末(コンピューター名）
            temp.SendMachineName = reader.ReadString();
            //S&E接続ユーザID
            temp.SAndECnctUserId = reader.ReadString();
            //S&E接続パスワード
            temp.SAndECnctPass = reader.ReadString();
            //端末番号
            temp.CashRegisterNo = reader.ReadInt32();

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
        /// <returns>ConnectInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConnectInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConnectInfoWork temp = GetConnectInfoWork(reader, serInfo);
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
                    retValue = (ConnectInfoWork[])lst.ToArray(typeof(ConnectInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

