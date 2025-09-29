using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalCprtConnectInfoWork
    /// <summary>
    ///                      接続先情報設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   接続先情報設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2019/12/03</br>
    /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
    /// <br>管理番号         :   11570219-00</br>
    /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalCprtConnectInfoWork : IFileHeader
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

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>プロトコル</summary>
        private Int32 _protocol;

        /// <summary>ログインタイムアウト</summary>
        /// <remarks>秒</remarks>
        private Int32 _loginTimeoutVal;

        /// <summary>連携先ドメイン</summary>
        private string _cprtDomain = "";

        /// <summary>連携先URL</summary>
        private string _cprtUrl = "";

        /// <summary>接続プログラムタイプ</summary>
        private Int32 _cnectProgramType;

        /// <summary>接続ファイルID</summary>
        private string _cnectFileId = "";

        /// <summary>接続送信区分</summary>
        /// <remarks>0:未送信,1:全て</remarks>
        private Int32 _cnectSendDiv;

        /// <summary>接続対象区分</summary>
        /// <remarks>0:前日,1:当日</remarks>
        private Int32 _cnectObjectDiv;

        /// <summary>リトライ回数</summary>
        private Int32 _retryCnt;

        /// <summary>自動送信区分</summary>
        private Int32 _autoSendDiv;

        /// <summary>起動時間</summary>
        private Int32 _bootTime;

        /// <summary>終了時間</summary>
        private Int32 _endTime;

        /// <summary>実行間隔</summary>
        private Int32 _execInterval;

        /// <summary>送信端末(IPアドレス）</summary>
        private string _sendMachineIpAddr = "";

        /// <summary>送信端末(コンピューター名）</summary>
        private string _sendMachineName = "";

        /// <summary>送信接続パスワード</summary>
        private string _sendCcnctPass = "";

        /// <summary>送信接続ユーザーコード</summary>
        private string _sendCcnctUserid = "";

        /// <summary>レジ番号</summary>
        /// <remarks>マシン番号</remarks>
        private Int32 _cashregiSterno;

        /// <summary>前回自動送信日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _ltAtSadDateTime;

        /// <summary>初回送信基準日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _frstSendDate;

        //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
        /// <summary>備考１設定区分</summary>
        /// <remarks>0:備考１,1:指示書番号,2:送信しない</remarks>
        private Int32 _note1SetDiv;

        /// <summary>備考２設定区分</summary>
        /// <remarks>0:備考２,1:指示書番号,2:送信しない</remarks>
        private Int32 _note2SetDiv;

        /// <summary>備考３設定区分</summary>
        /// <remarks>0:備考３,1:指示書番号,2:送信しない</remarks>
        private Int32 _note3SetDiv;
        //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
        /// <br>管理番号         :   11570219-00</br>
        /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
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

        /// public propaty name  :  Protocol
        /// <summary>プロトコルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プロトコルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>ログインタイムアウトプロパティ</summary>
        /// <value>秒</value>
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

        /// public propaty name  :  CprtDomain
        /// <summary>連携先ドメインプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携先ドメインプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CprtDomain
        {
            get { return _cprtDomain; }
            set { _cprtDomain = value; }
        }

        /// public propaty name  :  CprtUrl
        /// <summary>連携先URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携先URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CprtUrl
        {
            get { return _cprtUrl; }
            set { _cprtUrl = value; }
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
        /// <value>0:未送信,1:全て</value>
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
        /// <value>0:前日,1:当日</value>
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

        /// public propaty name  :  EndTime
        /// <summary>終了時間プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        /// public propaty name  :  ExecInterval
        /// <summary>実行間隔プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実行間隔プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExecInterval
        {
            get { return _execInterval; }
            set { _execInterval = value; }
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

        /// public propaty name  :  SendCcnctPass
        /// <summary>送信接続パスワードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信接続パスワードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendCcnctPass
        {
            get { return _sendCcnctPass; }
            set { _sendCcnctPass = value; }
        }

        /// public propaty name  :  SendCcnctUserid
        /// <summary>送信接続ユーザーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信接続ユーザーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendCcnctUserid
        {
            get { return _sendCcnctUserid; }
            set { _sendCcnctUserid = value; }
        }

        /// public propaty name  :  CashregiSterno
        /// <summary>レジ番号プロパティ</summary>
        /// <value>マシン番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashregiSterno
        {
            get { return _cashregiSterno; }
            set { _cashregiSterno = value; }
        }

        /// public propaty name  :  LtAtSadDateTime
        /// <summary>前回自動送信日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回自動送信日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LtAtSadDateTime
        {
            get { return _ltAtSadDateTime; }
            set { _ltAtSadDateTime = value; }
        }

        /// public propaty name  :  FrstSendDate
        /// <summary>初回送信基準日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初回送信基準日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FrstSendDate
        {
            get { return _frstSendDate; }
            set { _frstSendDate = value; }
        }

        //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
        /// public propaty name  :  Note1SetDiv
        /// <summary>備考１設定区分プロパティ</summary>
        /// <value>0:備考１,1:指示書番号,2:送信しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考１設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Note1SetDiv
        {
            get { return _note1SetDiv; }
            set { _note1SetDiv = value; }
        }

        /// public propaty name  :  Note2SetDiv
        /// <summary>備考２設定区分プロパティ</summary>
        /// <value>0:備考２,1:指示書番号,2:送信しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考２設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Note2SetDiv
        {
            get { return _note2SetDiv; }
            set { _note2SetDiv = value; }
        }

        /// public propaty name  :  Note3SetDiv
        /// <summary>備考３設定区分プロパティ</summary>
        /// <value>0:備考３,1:指示書番号,2:送信しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考３設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Note3SetDiv
        {
            get { return _note3SetDiv; }
            set { _note3SetDiv = value; }
        }
        //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2

        /// <summary>
        /// 売上連携接続情報ワークコンストラクタ
        /// </summary>
        /// <returns>SalCprtConnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalCprtConnectInfoWork()
        {
        }

        /// <summary>
        /// 売上連携接続情報ワークコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="protocol">プロトコル</param>
		/// <param name="loginTimeoutVal">ログインタイムアウト(秒)</param>
		/// <param name="cprtDomain">連携先ドメイン</param>
		/// <param name="cprtUrl">連携先URL</param>
		/// <param name="cnectProgramType">接続プログラムタイプ</param>
		/// <param name="cnectFileId">接続ファイルID</param>
		/// <param name="cnectSendDiv">接続送信区分(0:未送信,1:全て)</param>
		/// <param name="cnectObjectDiv">接続対象区分(0:前日,1:当日)</param>
		/// <param name="retryCnt">リトライ回数</param>
		/// <param name="autoSendDiv">自動送信区分</param>
		/// <param name="bootTime">起動時間</param>
		/// <param name="endTime">終了時間</param>
		/// <param name="execInterval">実行間隔</param>
		/// <param name="sendMachineIpAddr">送信端末(IPアドレス）</param>
		/// <param name="sendMachineName">送信端末(コンピューター名）</param>
		/// <param name="sendCcnctPass">送信接続パスワード</param>
		/// <param name="sendCcnctUserid">送信接続ユーザーコード</param>
		/// <param name="cashregiSterno">レジ番号(マシン番号)</param>
		/// <param name="ltAtSadDateTime">前回自動送信日時(DateTime:精度は100ナノ秒)</param>
		/// <param name="frstSendDate">初回送信基準日(YYYYMMDD)</param>
        /// <param name="note1SetDiv">備考１設定区分(0:備考１,1:指示書番号,2:送信しない)</param>
        /// <param name="note2SetDiv">備考２設定区分(0:備考１,1:指示書番号,2:送信しない)</param>
        /// <param name="note3SetDiv">備考３設定区分(0:備考１,1:指示書番号,2:送信しない)</param>
        /// <returns>SalCprtConnectInfoクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
        /// <br>管理番号         :   11570219-00</br>
        /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public SalCprtConnectInfoWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierCd, string sectionCode, Int32 customerCode, Int32 protocol, Int32 loginTimeoutVal, string cprtDomain, string cprtUrl, Int32 cnectProgramType, string cnectFileId, Int32 cnectSendDiv, Int32 cnectObjectDiv, Int32 retryCnt, Int32 autoSendDiv, Int32 bootTime, Int32 endTime, Int32 execInterval, string sendMachineIpAddr, string sendMachineName, string sendCcnctPass, string sendCcnctUserid, Int32 cashregiSterno, DateTime ltAtSadDateTime, Int32 frstSendDate, Int32 note1SetDiv, Int32 note2SetDiv, Int32 note3SetDiv)
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
			this._sectionCode = sectionCode;
			this._customerCode = customerCode;
			this._protocol = protocol;
			this._loginTimeoutVal = loginTimeoutVal;
			this._cprtDomain = cprtDomain;
			this._cprtUrl = cprtUrl;
			this._cnectProgramType = cnectProgramType;
			this._cnectFileId = cnectFileId;
			this._cnectSendDiv = cnectSendDiv;
			this._cnectObjectDiv = cnectObjectDiv;
			this._retryCnt = retryCnt;
			this._autoSendDiv = autoSendDiv;
			this._bootTime = bootTime;
			this._endTime = endTime;
			this._execInterval = execInterval;
			this._sendMachineIpAddr = sendMachineIpAddr;
			this._sendMachineName = sendMachineName;
			this._sendCcnctPass = sendCcnctPass;
			this._sendCcnctUserid = sendCcnctUserid;
			this._cashregiSterno = cashregiSterno;
			this._ltAtSadDateTime = ltAtSadDateTime;
			this._frstSendDate = frstSendDate;
            //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
            this._note1SetDiv = note1SetDiv;
            this._note2SetDiv = note2SetDiv;
            this._note3SetDiv = note3SetDiv;
            //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
		}
        /// <summary>
        /// 売上連携接続情報マスタ複製処理
        /// </summary>
        /// <returns>SalCprtConnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalCprtConnectInfoクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
        /// <br>管理番号         :   11570219-00</br>
        /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public SalCprtConnectInfoWork Clone()
        {
            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
            //return new SalCprtConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierCd, this._sectionCode, this._customerCode, this._protocol, this._loginTimeoutVal, this._cprtDomain, this._cprtUrl, this._cnectProgramType, this._cnectFileId, this._cnectSendDiv, this._cnectObjectDiv, this._retryCnt, this._autoSendDiv, this._bootTime, this._endTime, this._execInterval, this._sendMachineIpAddr, this._sendMachineName, this._sendCcnctPass, this._sendCcnctUserid, this._cashregiSterno, this._ltAtSadDateTime, this._frstSendDate);
            return new SalCprtConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierCd, this._sectionCode, this._customerCode, this._protocol, this._loginTimeoutVal, this._cprtDomain, this._cprtUrl, this._cnectProgramType, this._cnectFileId, this._cnectSendDiv, this._cnectObjectDiv, this._retryCnt, this._autoSendDiv, this._bootTime, this._endTime, this._execInterval, this._sendMachineIpAddr, this._sendMachineName, this._sendCcnctPass, this._sendCcnctUserid, this._cashregiSterno, this._ltAtSadDateTime, this._frstSendDate, this._note1SetDiv, this._note2SetDiv, this._note3SetDiv);
            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalCprtConnectInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalCprtConnectInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
        /// <br>管理番号         :   11570219-00</br>
        /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalCprtConnectInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalCprtConnectInfoWork || graph is ArrayList || graph is SalCprtConnectInfoWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalCprtConnectInfoWork).FullName));

            if (graph != null && graph is SalCprtConnectInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalCprtConnectInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalCprtConnectInfoWork[])graph).Length;
            }
            else if (graph is SalCprtConnectInfoWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //プロトコル
            serInfo.MemberInfo.Add(typeof(Int32)); //Protocol
            //ログインタイムアウト
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //連携先ドメイン
            serInfo.MemberInfo.Add(typeof(string)); //CprtDomain
            //連携先URL
            serInfo.MemberInfo.Add(typeof(string)); //CprtUrl
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
            //終了時間
            serInfo.MemberInfo.Add(typeof(Int32)); //EndTime
            //実行間隔
            serInfo.MemberInfo.Add(typeof(Int32)); //ExecInterval
            //送信端末(IPアドレス）
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineIpAddr
            //送信端末(コンピューター名）
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineName
            //送信接続パスワード
            serInfo.MemberInfo.Add(typeof(string)); //SendCcnctPass
            //送信接続ユーザーコード
            serInfo.MemberInfo.Add(typeof(string)); //SendCcnctUserid
            //レジ番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CashregiSterno
            //前回自動送信日時
            serInfo.MemberInfo.Add(typeof(Int64)); //LtAtSadDateTime
            //初回送信基準日
            serInfo.MemberInfo.Add(typeof(Int32)); //FrstSendDate
            //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
            //備考１設定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //Note1SetDiv
            //備考２設定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //Note2SetDiv
            //備考３設定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //Note3SetDiv
            //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2

            serInfo.Serialize(writer, serInfo);
            if (graph is SalCprtConnectInfoWork)
            {
                SalCprtConnectInfoWork temp = (SalCprtConnectInfoWork)graph;

                SetSalCprtConnectInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalCprtConnectInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalCprtConnectInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalCprtConnectInfoWork temp in lst)
                {
                    SetSalCprtConnectInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalCprtConnectInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
        //private const int currentMemberCount = 31;
        private const int currentMemberCount = 34;
        //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

        /// <summary>
        ///  SalCprtConnectInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
        /// <br>管理番号         :   11570219-00</br>
        /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void SetSalCprtConnectInfoWork(System.IO.BinaryWriter writer, SalCprtConnectInfoWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //プロトコル
            writer.Write(temp.Protocol);
            //ログインタイムアウト
            writer.Write(temp.LoginTimeoutVal);
            //連携先ドメイン
            writer.Write(temp.CprtDomain);
            //連携先URL
            writer.Write(temp.CprtUrl);
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
            //終了時間
            writer.Write(temp.EndTime);
            //実行間隔
            writer.Write(temp.ExecInterval);
            //送信端末(IPアドレス）
            writer.Write(temp.SendMachineIpAddr);
            //送信端末(コンピューター名）
            writer.Write(temp.SendMachineName);
            //送信接続パスワード
            writer.Write(temp.SendCcnctPass);
            //送信接続ユーザーコード
            writer.Write(temp.SendCcnctUserid);
            //レジ番号
            writer.Write(temp.CashregiSterno);
            //前回自動送信日時
            writer.Write((Int64)temp.LtAtSadDateTime.Ticks);
            //初回送信基準日
            writer.Write(temp.FrstSendDate);
            //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
            //備考１設定区分
            writer.Write(temp.Note1SetDiv);
            //備考２設定区分
            writer.Write(temp.Note2SetDiv);
            //備考３設定区分
            writer.Write(temp.Note3SetDiv);
            //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
        }

        /// <summary>
        ///  SalCprtConnectInfoWorkインスタンス取得
        /// </summary>
        /// <returns>SalCprtConnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2020/02/04 寺田 義啓</br>
        /// <br>管理番号         :   11570219-00</br>
        /// <br>                 : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private SalCprtConnectInfoWork GetSalCprtConnectInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalCprtConnectInfoWork temp = new SalCprtConnectInfoWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //プロトコル
            temp.Protocol = reader.ReadInt32();
            //ログインタイムアウト
            temp.LoginTimeoutVal = reader.ReadInt32();
            //連携先ドメイン
            temp.CprtDomain = reader.ReadString();
            //連携先URL
            temp.CprtUrl = reader.ReadString();
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
            //終了時間
            temp.EndTime = reader.ReadInt32();
            //実行間隔
            temp.ExecInterval = reader.ReadInt32();
            //送信端末(IPアドレス）
            temp.SendMachineIpAddr = reader.ReadString();
            //送信端末(コンピューター名）
            temp.SendMachineName = reader.ReadString();
            //送信接続パスワード
            temp.SendCcnctPass = reader.ReadString();
            //送信接続ユーザーコード
            temp.SendCcnctUserid = reader.ReadString();
            //レジ番号
            temp.CashregiSterno = reader.ReadInt32();
            //前回自動送信日時
            temp.LtAtSadDateTime = new DateTime(reader.ReadInt64());
            //初回送信基準日
            temp.FrstSendDate = reader.ReadInt32();
            //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
            //備考１設定区分
            temp.Note1SetDiv = reader.ReadInt32();
            //備考２設定区分
            temp.Note2SetDiv = reader.ReadInt32();
            //備考３設定区分
            temp.Note3SetDiv = reader.ReadInt32();
            //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2

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
        /// <returns>SalCprtConnectInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtConnectInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalCprtConnectInfoWork temp = GetSalCprtConnectInfoWork(reader, serInfo);
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
                    retValue = (SalCprtConnectInfoWork[])lst.ToArray(typeof(SalCprtConnectInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

