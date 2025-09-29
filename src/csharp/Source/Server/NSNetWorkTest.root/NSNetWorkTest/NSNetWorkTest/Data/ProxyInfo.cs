using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkTest.Data
{
    /// <summary>
    /// �v���L�V���N���X
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	���@�k��</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    [Serializable]
    public class ProxyInfo
    {
        #region �񋓑�
        /// <summary>
        /// �v���L�V�̓���
        /// </summary>
        public enum ProxyType
        {
            //�v���L�V���g�p���邩�͔C��(�ʂ��Ȃ��Ă�OK)
            FREE_USE = -1,
            //�v���L�V���g�p���Ȃ�
            NOT_USE =0,
            //�v���L�V���g�p����
            USE = 1
        }


        /// <summary>
        /// �v���L�V�ւ̔F�؎��
        /// </summary>
        public  enum AuthenticationType
        {   //�s��
            UNKNOWN = -1,
            //����
            NONE = 0,
            //BASIC��{�F��
            BASIC = 1,
            //WINDOWS�����F��
            WINDOWS = 2
        }
        #endregion

        #region �v���C�x�[�g�����o
        /// <summary>
        /// �v���L�V�𗘗��p�̗L��
        /// </summary>
        private ProxyType _isProxy = ProxyType.NOT_USE;
        /// <summary>
        /// �v���L�V�T�[�o�[�A�h���X
        /// </summary>
        private string _proxyUrl = string.Empty;
        /// <summary>
        /// �F�؎��
        /// </summary>
        private AuthenticationType _proxyAuthentication = AuthenticationType.UNKNOWN;

        /// <summary>
        /// �v���L�V�o�C�p�X���X�g
        /// </summary>
        private List<string> _proxyBypass = new List<string>();
        

        /// <summary>
        /// Exception
        /// </summary>
        private Exception _ex = null;
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// �v���L�V�𗘗��p�̗L��
        /// </summary>
        public ProxyType IsProxy
        {
            get { return _isProxy; }
            set { _isProxy = value; }
        }
        /// <summary>
        /// �v���L�V�T�[�o�[�A�h���X
        /// </summary>
        public string ProxyUrl
        {
            get { return _proxyUrl; }
            set { _proxyUrl = value; }
        }
        /// <summary>
        /// �F�؎��
        /// </summary>
        public AuthenticationType ProxyAuthentication
        {
            get { return _proxyAuthentication; }
            set { _proxyAuthentication = value; }
        }
        /// <summary>
        /// �v���L�V�o�C�p�X���X�g
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
