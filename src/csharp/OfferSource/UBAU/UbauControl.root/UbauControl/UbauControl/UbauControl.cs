using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using Microsoft.Win32;

//認証サービス
using CustomInstaller.www.broadleaf.co.jp;
//プロテクタ関係
using UBAU.Common;
using UBAU.Data;
using UBAU.Remoting;
using System.Collections;

namespace CustomInstaller
{
    /// <summary>
    /// インストール情報
    /// </summary>
    public class InstallationInfo
    {
        #region プライベートメンバ
        string   _serverName  = "";
        string   _serverType  = "";
        string   _serviceCode = "";
        string   _installMngr = "";
        string   _osAdminId   = "";
        string   _osAdminPwd  = "";
        string[] _dBTblNmLst  = null;
        string   _instDrive   = "";
        string   _instDir     = "";
        string   _saUserNm    = "";
        string   _saPassWd    = "";
        string _productCode = "";
        #endregion

        #region プロパティ

        /// <summary>サーバ名称</summary>
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        /// <summary>サーバタイプ</summary>
        public string ServerType
        {
            get { return _serverType; }
            set { _serverType = value; }
        }

        /// <summary>サーバコード</summary>
        public string ServiceCode
        {
            get { return _serviceCode; }
            set { _serviceCode = value; }
        }

        /// <summary>インストールユーザ実行者名</summary>
        public string InstallMngr
        {
            get { return _installMngr; }
            set { _installMngr = value; }
        }

        /// <summary>OS管理者アカウント名</summary>
        public string OsAdminId
        {
            get { return _osAdminId; }
            set { _osAdminId = value; }
        }

        /// <summary>OS管理者アカウントパスワード</summary>
        public string OsAdminPwd
        {
            get { return _osAdminPwd; }
            set { _osAdminPwd = value; }
        }

        /// <summary>対象テーブルリスト</summary>
        public string[] DBTblNmLst
        {
            get { return _dBTblNmLst; }
            set { _dBTblNmLst = value; }
        }

        /// <summary>インストール元ドライブ</summary>
        public string InstDrive
        {
            get { return _instDrive; }
            set { _instDrive = value; }
        }

        /// <summary>インストール先ディレクトリ</summary>
        public string InstDir
        {
            get { return _instDir; }
            set { _instDir = value; }
        }

        /// <summary>管理者(sa)ユーザID</summary>
        public string SaUserNm
        {
            get { return _saUserNm; }
            set { _saUserNm = value; }
        }

        /// <summary>管理者(sa)パスワード</summary>
        public string SaPassWd
        {
            get { return _saPassWd; }
            set { _saPassWd = value; }
        }

        /// <summary>プロダクトコード</summary>
        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }
        #endregion
    }

    /// <summary>
    /// 認証情報制御クラス
    /// </summary>
    public class UbauControl
    {
        # region プライベート変数

        // USB存在チェック時のエラーメッセージ
        private const string          MSG_NODEVICE         = "USBプロテクタを差してください。";
        private const string          MSG_TOOMANY          = "2つ以上のUSBプロテクタが差されています。\r\nひとつだけプロテクタを差してください。";
        private const string          MSG_INVALIDOS        = "規格外OSです。";
        private const string          MSG_UNAUTHROIZEDUSER = "管理者権限ユーザーでログインしてください";
        private const string          MSG_DEFAULT          = "不明";
        # endregion

        #region Enum

        /// <summary>対象システム</summary>
        public enum TargetSystem
        {
            PMC = 0,
            LSM = 1
        }

        #endregion

        #region データクラス

        /// <summary>データクラス</summary>
        public class DbMaintenanceInfo
        {
            # region プライベートメンバ

            private string enterpriseCode = "";
            private MyDbInfo _myDbInfo = new MyDbInfo();
            private List<DbSvrInfo> _relatedDBInfoList = new List<DbSvrInfo>();

            # endregion

            # region プロパティ

            /// <summary>企業コード</summary>
            public string EnterpriseCode
            {
                get { return enterpriseCode; }
                set { enterpriseCode = value; }
            }

            /// <summary>現在のDBサーバ情報</summary>
            public MyDbInfo MyDbInfo
            {
                get { return _myDbInfo; }
                set { _myDbInfo = value; }
            }

            /// <summary>導入済みDB情報リスト</summary>
            public List<DbSvrInfo> RelatedDBInfoList
            {
                get { return _relatedDBInfoList; }
                set { _relatedDBInfoList = value; }
            }

            # endregion
        }

        /// <summary>現在のDBサーバ情報</summary>
        public class MyDbInfo : DbSvrInfo
        {
            private List<DBEncryptionInfo> _dBEncryptionInfo = new List<DBEncryptionInfo>();

            public List<DBEncryptionInfo> DBEncryptionInfo
            {
                get { return _dBEncryptionInfo; }
                set { _dBEncryptionInfo = value; }
            }
        }

        /// <summary>DBサーバー情報</summary>
        public class DbSvrInfo
        {
            # region プライベートメンバ

            private string _serverCode = "";
            private string _accessId   = "";
            private string _accessPwd  = "";
            private string _adminId    = "";
            private string _adminPwd   = "";

            # endregion

            # region プロパティ

            /// <summary>サーバコード</summary>
            public string ServerCode
            {
                get { return _serverCode; }
                set { _serverCode = value; }
            }

            /// <summary>アクセスID</summary>
            public string AccessId
            {
                get { return _accessId; }
                set { _accessId = value; }
            }

            /// <summary>アクセスパスワード</summary>
            public string AccessPwd
            {
                get { return _accessPwd; }
                set { _accessPwd = value; }
            }

            /// <summary>管理者ID</summary>
            public string AdminId
            {
                get { return _adminId; }
                set { _adminId = value; }
            }

            /// <summary>管理者パスワード</summary>
            public string AdminPwd
            {
                get { return _adminPwd; }
                set { _adminPwd = value; }
            }

            # endregion
        }

        /// <summary>暗号化キー情報</summary>
        public struct DBEncryptionInfo
        {
            # region プライベートメンバ

            private string _tableName;
            private string _keyName;
            private string _keyPWD;
            private string _key;
            private string _identifier;

            # endregion

            # region プロパティ

            /// <summary>テーブル名</summary>
            public string TableName
            {
                get { return _tableName; }
                set { _tableName = value; }
            }

            /// <summary>キー名</summary>
            public string KeyName
            {
                get { return _keyName; }
                set { _keyName = value; }
            }

            /// <summary>キーパスワード</summary>
            public string KeyPWD
            {
                get { return _keyPWD; }
                set { _keyPWD = value; }
            }

            /// <summary>キー</summary>
            public string Key
            {
                get { return _key; }
                set { _key = value; }
            }

            /// <summary>識別</summary>
            public string Identifier
            {
                get { return _identifier; }
                set { _identifier = value; }
            }

            # endregion
        }

        /// <summary>ソフトウェア情報</summary>
        public class SoftwareInfo
        {
            #region プライベートメンバ
            private string _softwareCode;
            private string _softwareName;
            private int _purchaseStatus;
            private int _remainingDays;
            private bool _isUSBAccessPermitted;
            private string _softwareDescription;
            private int _softwareType;

            #endregion

            #region プロパティ
            public string SoftwareCode
            {
                get { return _softwareCode; }
                set { _softwareCode = value; }
            }

            public string SoftwareName
            {
                get { return _softwareName; }
                set { _softwareName = value; }
            }

            public int RemainingDays
            {
                get { return _remainingDays; }
                set { _remainingDays = value; }
            }
            public int PurchaseStatus
            {
                get { return _purchaseStatus; }
                set { _purchaseStatus = value; }
            }
            public int SoftwareType
            {
                get { return _softwareType; }
                set { _softwareType = value; }
            }
            public string SoftwareDescription
            {
                get { return _softwareDescription; }
                set { _softwareDescription = value; }
            }
            public bool IsUSBAccessPermitted
            {
                get { return _isUSBAccessPermitted; }
                set { _isUSBAccessPermitted = value; }
            }


            #endregion

            #region コンストラクタ
            public SoftwareInfo()
            {
                _softwareCode = string.Empty;
                _softwareName = string.Empty;
                _purchaseStatus = 0;
                _remainingDays = 0;
                _isUSBAccessPermitted = false;
                _softwareDescription = string.Empty;
                _softwareType = 0;
            }
            #endregion
        }

        /// <summary>USB内部情報</summary>
        private class UbauControlInfoPrivate
        {
            private string _uSBCode     = "";
            private string _tsubasaCode = "";

            /// <summary>翼コード</summary>
            public string TsubasaCode
            {
                get { return _tsubasaCode; }
                set { _tsubasaCode = value; }
            }
            /// <summary>USBコード</summary>
            public string USBCode
            {
                get { return _uSBCode; }
                set { _uSBCode = value; }
            }
        }

        #endregion

        #region パブリックメソッド

        /// <summary>データメンテナンス情報取得</summary>
        /// <param name="installationInfo">インストール情報</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : データメンテナンス情報を取得します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        public DbMaintenanceInfo GetDbInfo(InstallationInfo installationInfo)
        {
            return this.GetDbInfoProc(installationInfo, TargetSystem.PMC);
        }

        /// <summary>データメンテナンス情報取得</summary>
        /// <param name="installationInfo">インストール情報</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : データメンテナンス情報を取得します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        public DbMaintenanceInfo GetDbInfo(InstallationInfo installationInfo, TargetSystem targetSystem)
        {
            return this.GetDbInfoProc(installationInfo, targetSystem);
        }

        /// <summary>インストール完了</summary>
        /// <param name="installationInfo">インストール情報</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : インストールの情報を通知します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        public bool InstallationCompleted(InstallationInfo installationInfo)
        {
            return this.InstallationCompletedProc(installationInfo, TargetSystem.PMC);
        }

        /// <summary>インストール完了</summary>
        /// <param name="installationInfo">インストール情報</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : インストールの情報を通知します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        public bool InstallationCompleted(InstallationInfo installationInfo, TargetSystem targetSystem)
        {
            return this.InstallationCompletedProc(installationInfo, targetSystem);
        }

        /// <summary>USB存在チェック</summary>
        /// <returns></returns>
        /// <remarks>
        /// Note       : USBの存在チェックをします。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        public string IsUsbDevice()
        {
            return this.IsUsbDeviceProc();
        }

        /// <summary>ソフトウェア情報取得</summary>
        /// <param name="installationInfo"></param>
        /// <param name="targetSystem"></param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : プロダクトのソフトウェア情報を取得します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        public List<SoftwareInfo> GetSoftwareInfo(InstallationInfo installationInfo, TargetSystem targetSystem)
        {
            return GetSoftwareInfoProc(installationInfo, targetSystem);
        }

      
        #endregion

        #region プライベートメソッド

        /// <summary>データメンテナンス情報取得(実行部)</summary>
        /// <param name="installationInfo">インストール情報</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : データメンテナンス情報を取得します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        private DbMaintenanceInfo GetDbInfoProc(InstallationInfo installationInfo, TargetSystem checkSystem)
        {
            DbMaintenanceInfo dbMaintenanceInfo = new DbMaintenanceInfo();

            try
            {
                //●USB情報取得
                UbauControlInfoPrivate ubauControlInfoPrivate = this.GetUsbInfoProc();
                if (ubauControlInfoPrivate == null)
                {
                    return dbMaintenanceInfo;
                }

                //USB情報セット
                USBIdentity uSBIdentity = new USBIdentity();
                uSBIdentity.TsubasaCode = ubauControlInfoPrivate.TsubasaCode;
                uSBIdentity.USBCode     = ubauControlInfoPrivate.USBCode;

                //サーバ情報セット
                ServerIdentity serverIdentity = new ServerIdentity();
                serverIdentity.ServerName      = installationInfo.ServerName;
                serverIdentity.ServerType      = installationInfo.ServerType;
                serverIdentity.ServiceCode     = installationInfo.ServiceCode;
                serverIdentity.DBTableNameList = installationInfo.DBTblNmLst;
                serverIdentity.USBIdentity     = uSBIdentity;
                serverIdentity.ProductCode = installationInfo.ProductCode;

                //●認証サービスからメンテナンス情報取得
                UBAWebService uBAWebService = new UBAWebService();

                string uBAWebServiceUrl = string.Empty;
                //●指定されたシステムのConfigからURLを取得
                switch (checkSystem)
                {
                    case TargetSystem.PMC:
                        uBAWebServiceUrl = this.GetPMCUrl();
                        break;
                    case TargetSystem.LSM:
                        uBAWebServiceUrl = this.GetLSMUrl();
                        break;
                }

                if (string.IsNullOrEmpty(uBAWebServiceUrl))
                {
                    return null;
                }
                uBAWebService.Url = uBAWebServiceUrl;
                DBManageToken dBManageToken = uBAWebService.RequestDBManageToken(serverIdentity);
                
                if (dBManageToken == null)
                {
                    return null;
                }

                dbMaintenanceInfo.EnterpriseCode = dBManageToken.CompanyCode;           //企業コード
                dbMaintenanceInfo.MyDbInfo.AccessId  = dBManageToken.DBUserInfo.AccessID;   //DBアクセスユーザ
                dbMaintenanceInfo.MyDbInfo.AccessPwd = dBManageToken.DBUserInfo.AccessPWD;  //DBアクセスユーザパスワード
                dbMaintenanceInfo.MyDbInfo.AdminId   = dBManageToken.DBUserInfo.AdminID;    //DB管理者
                dbMaintenanceInfo.MyDbInfo.AdminPwd  = dBManageToken.DBUserInfo.AdminPWD;   //DB管理者パスワード

                //暗号化キー情報
                for (int ix = 0; ix < dBManageToken.DBEncryptionInfoList.Length; ix++)
                {
                    DBEncryptionInfo dBEncryptionInfo = new DBEncryptionInfo();
                    dBEncryptionInfo.TableName  = dBManageToken.DBEncryptionInfoList[ix].TableName;
                    dBEncryptionInfo.KeyName    = dBManageToken.DBEncryptionInfoList[ix].KeyName;
                    dBEncryptionInfo.KeyPWD     = dBManageToken.DBEncryptionInfoList[ix].KeyPWD;
                    dBEncryptionInfo.Key        = dBManageToken.DBEncryptionInfoList[ix].Key;
                    dBEncryptionInfo.Identifier = dBManageToken.DBEncryptionInfoList[ix].Identifier;

                    dbMaintenanceInfo.MyDbInfo.DBEncryptionInfo.Add(dBEncryptionInfo);
                }

                //この企業に登録されている他のDBサーバ情報
                for (int ix = 0; ix < dBManageToken.RelatedDBInfoList.Length; ix++)
                {
                    DbSvrInfo dbInfo = new DbSvrInfo();
                    dbInfo.ServerCode = dBManageToken.RelatedDBInfoList[ix].ServiceCode;
                    dbInfo.AdminId    = dBManageToken.RelatedDBInfoList[ix].DBUserInfo.AdminID;
                    dbInfo.AdminPwd   = dBManageToken.RelatedDBInfoList[ix].DBUserInfo.AdminPWD;
                    dbInfo.AccessId   = dBManageToken.RelatedDBInfoList[ix].DBUserInfo.AccessID;
                    dbInfo.AccessPwd  = dBManageToken.RelatedDBInfoList[ix].DBUserInfo.AccessPWD;

                    dbMaintenanceInfo.RelatedDBInfoList.Add(dbInfo);
                }
            }
            catch (Exception ex)
            {
                //エラー処理
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbMaintenanceInfo = null;
            }

            return dbMaintenanceInfo;
        }

        /// <summary>USB情報取得(実行部)</summary>
        /// <returns></returns>
        /// <remarks>
        /// Note       : USB情報を取得します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        private UbauControlInfoPrivate GetUsbInfoProc()
        {
            UbauControlInfoPrivate ubauControlInfoPrivate = new UbauControlInfoPrivate();
            USBStatus uSBStatus;

            try
            {
                //TODO:ツバサコードをどこにおく？
                USBProtector uSBProtector = this.NewUSBProtector();

                ubauControlInfoPrivate.TsubasaCode = uSBProtector.USBConstantID;                  //翼コード
                ubauControlInfoPrivate.USBCode     = uSBProtector.GetUniqueID(out uSBStatus);     //USBコード取得
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //エラー処理
                ubauControlInfoPrivate = null;
            }
            return ubauControlInfoPrivate;
        }

        /// <summary>インストール完了(実行部)</summary>
        /// <param name="installationInfo">インストール情報</param>
        /// <remarks>
        /// Note       : インストールの情報を通知します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        private bool InstallationCompletedProc(InstallationInfo installationInfo, TargetSystem checkSystem)
        {
            bool result = false;

            try
            {
                UBAWebService uBAWebService = new UBAWebService();

                //●製品管理クライアントのインストールディレクトリのconfigファイルからURLを取得し、変更する
                string uBAWebServiceUrl = string.Empty;

                //●指定されたシステムのConfigからURLを取得
                switch (checkSystem)
                {
                    case TargetSystem.PMC:
                        uBAWebServiceUrl = this.GetPMCUrl();
                        break;
                    case TargetSystem.LSM:
                        uBAWebServiceUrl = this.GetLSMUrl();
                        break;
                }

                uBAWebService.Url = uBAWebServiceUrl;

                //USB情報取得
                UbauControlInfoPrivate ubauControlInfoPrivate = this.GetUsbInfoProc();
                USBIdentity uSBIdentity = new USBIdentity();
                uSBIdentity.TsubasaCode = ubauControlInfoPrivate.TsubasaCode;
                uSBIdentity.USBCode     = ubauControlInfoPrivate.USBCode;

                //サーバ情報
                ServerIdentity serverIdentity = new ServerIdentity();
                serverIdentity.ServerName  = installationInfo.ServerName;
                serverIdentity.ServerType  = installationInfo.ServerType;
                serverIdentity.ServiceCode = installationInfo.ServiceCode;
                serverIdentity.USBIdentity = uSBIdentity;

                //インストール情報
                InstallationIdentity installationIdentity = new InstallationIdentity();
                installationIdentity.InstallationManager = installationInfo.InstallMngr;
                installationIdentity.OSAdminID           = installationInfo.OsAdminId;
                installationIdentity.OSAdminPWD          = installationInfo.OsAdminPwd;
                installationIdentity.ServerIdentity      = serverIdentity;

                //インストール情報通知
                result = uBAWebService.SetInstallationLog(installationIdentity);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

       
        /// <summary>USB存在チェック(実行部)</summary>
        /// <returns></returns>
        /// <remarks>
        /// Note       : USBの存在チェックをします。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />
        /// </remarks>
        private string IsUsbDeviceProc()
        {
            string result = "";
            USBStatus uSBStatus;
            try
            {
                //TODO:ツバサコードをどこにおく？
                USBProtector uSBProtector = this.NewUSBProtector();
                //USBコード取得
                uSBProtector.GetUniqueID(out uSBStatus);

                //USBが存在しているか
                if (uSBStatus == USBStatus.NoDevice)
                {
                    result = MSG_NODEVICE;
                }
                else if (uSBStatus == USBStatus.TooMany)
                {
                    result = MSG_TOOMANY;
                }
                else if (uSBStatus == USBStatus.InvalidOS)
                {
                    result = MSG_INVALIDOS;
                }
                else if (uSBStatus == USBStatus.UnauthroizedUser)
                {
                    result = MSG_UNAUTHROIZEDUSER;
                }
            }
            catch (Exception ex)
            {
                result = MSG_DEFAULT + "[" + ex + "]";
            }
            return result;
        }

        /// <summary>ソフトウェア情報取得</summary>
        /// <param name="installationInfo"></param>
        /// <param name="targetSystem"></param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : プロダクトのソフトウェア情報を取得します。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2009.02.16<br />
        /// <br />  
        /// </remarks>
        private List<SoftwareInfo> GetSoftwareInfoProc(InstallationInfo installationInfo, TargetSystem targetSystem)
        {
            List<SoftwareInfo> infoList = null;

            switch (targetSystem)
            {
                case TargetSystem.PMC:
                    break;
                case TargetSystem.LSM:
                    Hashtable hs = this.GetLsmDataByRemoting(installationInfo.ProductCode);

                    // データの取得に成功し、プロダクトが情報に含まれる場合
                    if (hs != null && hs.ContainsKey(installationInfo.ProductCode))
                    {
                        LocalAccessToken token = hs[installationInfo.ProductCode] as LocalAccessToken;

                        if (token != null && token.LoginFlag)
                        {
                            infoList = new List<SoftwareInfo>();
                            foreach (UBAU.Data.LocalSoftwareInfo localSoftwareInfo in token.Product.SoftwareInfoArray)
                            {
                                SoftwareInfo info = new SoftwareInfo();
                                info.SoftwareCode = localSoftwareInfo.SoftwareCode;
                                info.SoftwareName = localSoftwareInfo.SoftwareName;

                                info.IsUSBAccessPermitted = localSoftwareInfo.IsUSBAccessPermitted;
                                info.SoftwareDescription = localSoftwareInfo.SoftwareDescription;
                                info.PurchaseStatus= localSoftwareInfo.PurchaseStatus;
                                info.RemainingDays = localSoftwareInfo.RemainingDays;
                                info.SoftwareType= localSoftwareInfo.SoftwareType;
                                infoList.Add(info);
                            }
                        }
                    }

                    break;
            }

            return infoList;
        }

        /// <summary>
        /// リモーティングで LSM からデータを取得する
        /// </summary>
        /// <returns>LSM データ</returns>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 21024 佐々木 健</br>
        /// <br>Date        : 2009.02.25/22</br>
        /// <br>Update Note : </br>
        /// </remarks>
        private Hashtable GetLsmDataByRemoting(string productCode)
        {
            #region ポート番号を取得

            // LSMのデフォルトポート番号
            int port = -1;

            try
            {
                try
                {
                    // PMC\LSM（サービスの方）からポート取得
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Broadleaf\Service\PMC\LSM", false);

                    if (key == null)
                    {
                        MessageBox.Show("ローカル管理システムサービスがインストールされていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    // PortID
                    port = (Int32)key.GetValue("PortID");

                    key.Close();

                }
                catch (Exception)
                {
                }

                if (port == -1)
                {
                    MessageBox.Show("ローカル管理システムサービスの情報取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // リモーティングでデータ取得
                Hashtable table = new Hashtable();

                // param_not_used
                string[] param_not_used = new string[0];

                int st =
                ServiceFactory.GetInstance().GetRemoteService(port).GetLoginInfo(
                    productCode,
                    System.Diagnostics.Process.GetCurrentProcess().Id,
                    new string[] { "LocalAccessToken" },    // KeyStringは固定
                    out param_not_used,
                    out table
                    );
                return ( table );
            }
            catch (Exception err)
            {
                // Error
                MessageBox.Show(err.ToString());

                return null;
            }

            #endregion
        }


        /// <summary>
        /// 製品管理クライアントのURL取得
        /// </summary>
        /// <returns></returns>
        private string GetPMCUrl()
        {
            string instDir = "";
            string retUrl = "";

            // PMCのインストール確認とインストールディレクトリ取得
            try
            {
                try
                {
                    // インストールディレクトリ・キーのパスを指定してレジストリを開く
                    RegistryKey rKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\PMC");

                    // レジストリの値を取得
                    instDir = (string)rKey.GetValue("InstallDirectory");

                    // 開いたレジストリ・キーを閉じる
                    rKey.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("製品管理クライアントが正しくインストールされていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // 取得したレジストリの値をCheck
                if (instDir == null || instDir.Trim().Length == 0)
                {
                    return null;
                }

                //インストールディレクトリ存在チェック
                if (!Directory.Exists(instDir))
                {
                    return null;
                }

                // 製品管理クライアントのconfigファイルの存在チェック
                string configPath = Path.Combine(instDir, "PMCWinService.exe.config");
                if (!File.Exists(configPath))
                {
                    MessageBox.Show("製品管理クライアントが正しくインストールされていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                //対象構成ファイル変更(XML変更)
                XmlDocument myXmlDocument = new XmlDocument();
                //XML Load
                myXmlDocument.Load(configPath);

                //node分全てチェック
                foreach (XmlNode node1 in myXmlDocument.DocumentElement.ChildNodes)
                {
                    if (node1.Name == "applicationSettings")
                    {
                        foreach (XmlNode node2 in node1.ChildNodes)
                        {
                            if (node2.Name == "PMCUBAUManager.Properties.Settings")
                            {
                                foreach (XmlNode node3 in node2.ChildNodes)
                                {
                                    foreach (XmlNode node4 in node3.ChildNodes)
                                    {
                                        if (node4.Name == "value")
                                        {
                                            if (node4.InnerText.Contains("ubawebservice.asmx"))
                                            {
                                                retUrl = node4.InnerText;
                                                break;
                                            }
                                        }
                                    }
                                    if (retUrl.Length > 0)
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("製品管理クライアントの情報取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return retUrl;
        }


        /// <summary>
        /// ローカルシステム管理サービスのURL取得
        /// </summary>
        /// <returns></returns>
        private string GetLSMUrl()
        {
            string instDir = "";
            string retUrl = "";

            // PMCのインストール確認とインストールディレクトリ取得
            try
            {
                try
                {
                    // インストールディレクトリ・キーのパスを指定してレジストリを開く
                    RegistryKey rKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\PMC\LSM");

                    // レジストリの値を取得
                    instDir = (string)rKey.GetValue("InstallDirectory");

                    // 開いたレジストリ・キーを閉じる
                    rKey.Close();
                }
                catch(Exception)
                {
                }

                // 取得したレジストリの値をCheck
                if (instDir == null || instDir.Trim().Length == 0)
                {
                    return null;
                }

                //インストールディレクトリ存在チェック
                if (!Directory.Exists(instDir))
                {
                    return null;
                }

                // 製品管理クライアントのconfigファイルの存在チェック
                string configPath = Path.Combine(instDir, "LSMWinService.exe.config");
                if (!File.Exists(configPath))
                {
                    MessageBox.Show("ローカル管理システムサービスが正しくインストールされていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                //対象構成ファイル変更(XML変更)
                XmlDocument myXmlDocument = new XmlDocument();
                //XML Load
                myXmlDocument.Load(configPath);

                //node分全てチェック
                foreach (XmlNode node1 in myXmlDocument.DocumentElement.ChildNodes)
                {
                    if (node1.Name == "applicationSettings")
                    {
                        foreach (XmlNode node2 in node1.ChildNodes)
                        {
                            if (node2.Name == "UBAU.LSM.Service.Mgr.Properties.Settings")
                            {
                                foreach (XmlNode node3 in node2.ChildNodes)
                                {
                                    foreach (XmlNode node4 in node3.ChildNodes)
                                    {
                                        if (node4.Name == "value")
                                        {
                                            if (node4.InnerText.Contains("ubawebservice.asmx"))
                                            {
                                                retUrl = node4.InnerText;
                                                break;
                                            }
                                        }
                                    }
                                    if (retUrl.Length > 0)
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ローカル管理システムサービスの情報取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return retUrl;
        }

        private USBProtector NewUSBProtector()
        {
            return new USBProtector("S560007S10M0Y007");
        }
        #endregion
    }
}
