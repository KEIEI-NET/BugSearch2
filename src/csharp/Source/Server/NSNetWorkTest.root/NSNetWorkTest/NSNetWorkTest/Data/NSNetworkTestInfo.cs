using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkTest.Data
{
    /// <summary>
    /// �l�b�g���[�N�e�X�g���N���X
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	���@�k��</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    [Serializable]
    public class NSNetworkTestInfo
    {
        #region �񋓑�
        /// <summary>
        /// �e�X�g����
        /// </summary>
        public enum TestType
        {
            //�e�X�g���Ȃ�
            NONE_TEST = 0,
            //HTTP���N�G�X�g
            HTTPREQUEST =1,
            //�|�[�g�`�F�b�N
            PORTCONNECT =2,
            //�z�M
            BITS = 3,
        }

        /// <summary>
        /// �e�X�g�Ώۂ̃T�[�o�^�C�v
        /// </summary>
        public enum ServerType
        {
            //WEB�T�[�o
            WEB = 0,
            //AP�T�[�o
            AP = 1,
            //�z�M�T�[�o
            BITS =2,
            //�v���L�V�T�[�o
            PROXY =3
        }
        #endregion

        #region �R���X�g���N�^
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

        #region �v���C�x�[�g�����o

        /// <summary>
        /// �e�X�g����
        /// </summary>
        private bool _checkResult = false;
        
        /// <summary>
        /// �v���L�V�ݒ���
        /// </summary>
        private ProxyInfo _proxyInfo = null;

        /// <summary>
        /// �e�X�g����
        /// </summary>
        private string _nSNetworkTestName = string.Empty;

        /// <summary>
        /// �e�X�g�ΏۃT�[�o�^�C�v
        /// </summary>
        private ServerType _serverType = ServerType.WEB;
        

        /// <summary>
        /// �e�X�g����
        /// </summary>
        private TestType _testType = TestType.NONE_TEST;

        /// <summary>
        /// �ʐM�e�X�g�̍ۂɎw�肷��A�h���X���A�uhttp://localhost:8080/index.html�v�Ȃ�
        /// </summary>
        private Uri _nSNetworkTestTargetUri;
    
        /// <summary>
        /// �ʐM�e�X�g���ʂ�HTTP�X�e�[�^�X
        /// </summary>
        private int _webRequestStatusNo = 0;

        /// <summary>
        /// �ʐM�e�X�g���ʂ̕�����
        /// </summary>
        private string _webRequestResultStr = string.Empty;

        /// <summary>
        /// �ʐM�e�X�g���ʂ̃��b�Z�[�W�i�X�e�[�^�X200=����A���̑�=���b�Z�[�W�ڍׁj
        /// </summary>
        private string _webRequestStatusMessage = string.Empty;

        /// <summary>
        /// Exception
        /// </summary>
        private Exception _ex = null;
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// �e�X�g����
        /// </summary>
        public bool CheckResult
        {
            get { return _checkResult; }
            set { _checkResult = value; }
        }

        /// <summary>
        /// �v���L�V�ݒ���
        /// </summary>
        public ProxyInfo ProxyInfo
        {
            get { return _proxyInfo; }
            set { _proxyInfo = value; }
        }

        /// <summary>
        /// �e�X�g����
        /// </summary>
        public string NSNetworkTestName
        {
            get { return _nSNetworkTestName; }
            set { _nSNetworkTestName = value; }
        }
        /// <summary>
        /// �ʐM�e�X�g�̍ۂɎw�肷��URL�A�uhttp://localhost/index.html�v�Ȃ�
        /// </summary>
        public Uri NSNetworkTestTargetUri
        {
            get { return _nSNetworkTestTargetUri; }
            set { _nSNetworkTestTargetUri = value; }
        }

        /// <summary>
        /// �e�X�g�ΏۃT�[�o�^�C�v
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
        /// �ʐM�e�X�g���ʂ�HTTP�X�e�[�^�X
        /// </summary>
        public int WebRequestStatusNo
        {
            get { return _webRequestStatusNo; }
            set { _webRequestStatusNo = value; }
        }

        /// <summary>
        /// �ʐM�e�X�g���ʂ̕�����
        /// </summary>
        public string WebRequestResultStr
        {
            get { return _webRequestResultStr; }
            set { _webRequestResultStr = value; }
        }

        /// <summary>
        /// �ʐM�e�X�g���ʂ̃��b�Z�[�W�i�X�e�[�^�X200=����A���̑�=���b�Z�[�W�ڍׁj
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
