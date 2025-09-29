using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkTest.Data
{
    /// <summary>
    /// プロキシ情報クラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    [Serializable]
    public class ProxyInfo
    {
        #region 列挙体
        /// <summary>
        /// プロキシの特徴
        /// </summary>
        public enum ProxyType
        {
            //プロキシを使用するかは任意(通さなくてもOK)
            FREE_USE = -1,
            //プロキシを使用しない
            NOT_USE =0,
            //プロキシを使用する
            USE = 1
        }


        /// <summary>
        /// プロキシへの認証種別
        /// </summary>
        public  enum AuthenticationType
        {   //不明
            UNKNOWN = -1,
            //無し
            NONE = 0,
            //BASIC基本認証
            BASIC = 1,
            //WINDOWS統合認証
            WINDOWS = 2
        }
        #endregion

        #region プライベートメンバ
        /// <summary>
        /// プロキシを利利用の有無
        /// </summary>
        private ProxyType _isProxy = ProxyType.NOT_USE;
        /// <summary>
        /// プロキシサーバーアドレス
        /// </summary>
        private string _proxyUrl = string.Empty;
        /// <summary>
        /// 認証種別
        /// </summary>
        private AuthenticationType _proxyAuthentication = AuthenticationType.UNKNOWN;

        /// <summary>
        /// プロキシバイパスリスト
        /// </summary>
        private List<string> _proxyBypass = new List<string>();
        

        /// <summary>
        /// Exception
        /// </summary>
        private Exception _ex = null;
        #endregion

        #region プロパティ
        /// <summary>
        /// プロキシを利利用の有無
        /// </summary>
        public ProxyType IsProxy
        {
            get { return _isProxy; }
            set { _isProxy = value; }
        }
        /// <summary>
        /// プロキシサーバーアドレス
        /// </summary>
        public string ProxyUrl
        {
            get { return _proxyUrl; }
            set { _proxyUrl = value; }
        }
        /// <summary>
        /// 認証種別
        /// </summary>
        public AuthenticationType ProxyAuthentication
        {
            get { return _proxyAuthentication; }
            set { _proxyAuthentication = value; }
        }
        /// <summary>
        /// プロキシバイパスリスト
        /// </summary>
        public List<string> ProxyBypass
        {
            get { return _proxyBypass; }
            set { _proxyBypass = value; }
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
    }
}
