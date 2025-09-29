using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkTest.Data
{
    /// <summary>
    /// ネットワークテスト情報クラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    [Serializable]
    public class NSNetworkTestInfo
    {
        #region 列挙体
        /// <summary>
        /// テスト項目
        /// </summary>
        public enum TestType
        {
            //テストしない
            NONE_TEST = 0,
            //HTTPリクエスト
            HTTPREQUEST =1,
            //ポートチェック
            PORTCONNECT =2,
            //配信
            BITS = 3,
        }

        /// <summary>
        /// テスト対象のサーバタイプ
        /// </summary>
        public enum ServerType
        {
            //WEBサーバ
            WEB = 0,
            //APサーバ
            AP = 1,
            //配信サーバ
            BITS =2,
            //プロキシサーバ
            PROXY =3
        }
        #endregion

        #region コンストラクタ
        public NSNetworkTestInfo()
        {
        }
        

        //public NSNetworkTestInfo(string nSNetworkTestName, string nSNetworkTestTargetUrl, string proxyUrl, int proxyPort, string proxyAuthId, string proxyAuthPwd)
        public NSNetworkTestInfo(ServerType serverType, TestType testType, string nSNetworkTestName, Uri nSNetworkTestTargetUri)
        {
            _serverType = serverType;
            _testType = testType;
            _nSNetworkTestName = nSNetworkTestName;
            _nSNetworkTestTargetUri = nSNetworkTestTargetUri;
            
            //_proxyUrl = proxyUrl;
            //_proxyPort = proxyPort;
            //_proxyAuthId = proxyAuthId;
            //_proxyAuthPwd = proxyAuthPwd;
        }
        #endregion

        #region プライベートメンバ

        /// <summary>
        /// テスト結果
        /// </summary>
        private bool _checkResult = false;
        
        /// <summary>
        /// プロキシ設定情報
        /// </summary>
        private ProxyInfo _proxyInfo = null;

        /// <summary>
        /// テスト名称
        /// </summary>
        private string _nSNetworkTestName = string.Empty;

        /// <summary>
        /// テスト対象サーバタイプ
        /// </summary>
        private ServerType _serverType = ServerType.WEB;
        

        /// <summary>
        /// テスト項目
        /// </summary>
        private TestType _testType = TestType.NONE_TEST;

        /// <summary>
        /// 通信テストの際に指定するアドレス情報、「http://localhost:8080/index.html」など
        /// </summary>
        private Uri _nSNetworkTestTargetUri;
    
        /// <summary>
        /// 通信テスト結果のHTTPステータス
        /// </summary>
        private int _webRequestStatusNo = 0;

        /// <summary>
        /// 通信テスト結果の文字列
        /// </summary>
        private string _webRequestResultStr = string.Empty;

        /// <summary>
        /// 通信テスト結果のメッセージ（ステータス200=正常、その他=メッセージ詳細）
        /// </summary>
        private string _webRequestStatusMessage = string.Empty;

        /// <summary>
        /// Exception
        /// </summary>
        private Exception _ex = null;
        #endregion

        #region プロパティ
        /// <summary>
        /// テスト結果
        /// </summary>
        public bool CheckResult
        {
            get { return _checkResult; }
            set { _checkResult = value; }
        }

        /// <summary>
        /// プロキシ設定情報
        /// </summary>
        public ProxyInfo ProxyInfo
        {
            get { return _proxyInfo; }
            set { _proxyInfo = value; }
        }

        /// <summary>
        /// テスト名称
        /// </summary>
        public string NSNetworkTestName
        {
            get { return _nSNetworkTestName; }
            set { _nSNetworkTestName = value; }
        }
        /// <summary>
        /// 通信テストの際に指定するURL、「http://localhost/index.html」など
        /// </summary>
        public Uri NSNetworkTestTargetUri
        {
            get { return _nSNetworkTestTargetUri; }
            set { _nSNetworkTestTargetUri = value; }
        }

        /// <summary>
        /// テスト対象サーバタイプ
        /// </summary>
        public ServerType NSNetworkServerType
        {
            get { return _serverType; }
            set { _serverType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TestType NSNetworkTestType
        {
            get { return _testType; }
            set { _testType = value; }
        }

        /// <summary>
        /// 通信テスト結果のHTTPステータス
        /// </summary>
        public int WebRequestStatusNo
        {
            get { return _webRequestStatusNo; }
            set { _webRequestStatusNo = value; }
        }

        /// <summary>
        /// 通信テスト結果の文字列
        /// </summary>
        public string WebRequestResultStr
        {
            get { return _webRequestResultStr; }
            set { _webRequestResultStr = value; }
        }

        /// <summary>
        /// 通信テスト結果のメッセージ（ステータス200=正常、その他=メッセージ詳細）
        /// </summary>
        public string WebRequestStatusMessage
        {
            get { return _webRequestStatusMessage; }
            set { _webRequestStatusMessage = value; }
        }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Ex
        {
            get { return _ex; }
            set { _ex = value; }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverType"></param>
        public static string GetServerTypeName(ServerType serverType)
        {
            if( serverType == ServerType.PROXY )
            {
                return NSNetworkTestMsgConst.TEST_PROXY_SERVER;
            }
            else if( serverType == ServerType.AP )
            {
                return NSNetworkTestMsgConst.TEST_AP_SERVER;
            }
            else if( serverType == ServerType.BITS )
            {
                return NSNetworkTestMsgConst.TEST_DELIVERY_SERVER;
            }
            else if( serverType == ServerType.WEB )
            {
                return NSNetworkTestMsgConst.TEST_WEB_SERVER;
            }
            else
            {
                return "";
            }
        }

        public override string ToString()
        {
            return this._nSNetworkTestName;
        }

      }
}
