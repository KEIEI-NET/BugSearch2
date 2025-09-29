using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Broadleaf.NSNetworkTest.Data;

namespace Broadleaf.NSNetworkTest.Net
{
    /// <summary>
    /// �l�b�g���[�N�ʐM�����N���X
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	���@�k��</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public class NSNetworkTestAccess
    {
        #region �p�u���b�N���\�b�h
        /// <summary>
        /// HTTP���N�G�X�g
        /// </summary>
        /// <param name="nSNetworkTestInfo"></param>
        /// <returns></returns>
        public static bool HttpRequest(NSNetworkTestInfo nSNetworkTestInfo)
        {
            return HttpRequestProc(nSNetworkTestInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="portNo"></param>
        /// <returns></returns>
        public static bool CheckPort(NSNetworkTestInfo nSNetworkTestInfo)
        {
            bool result = false;
            try
            {
                //���ڎw��A�h���X�֐ڑ��m�F����B
                using( TcpClient tcpClient = new TcpClient(nSNetworkTestInfo.NSNetworkTestTargetUri.Host, nSNetworkTestInfo.NSNetworkTestTargetUri.Port) )
                {
                    result = tcpClient.Connected;
                }
            }
            catch( Exception ex )
            {
                result = false;
                //�X�e�[�^�X�R�[�h�̕�����Ȃ���O�͑S�āu-1�v�Ƃ���B
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                nSNetworkTestInfo.Ex = ex;
            }

            return result;
        }

        /// <summary>
        /// �v���L�V�T�[�o�[�̎�ʃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo CheckProxy()
        {
            Uri target = new Uri("http://www.broadleaf.co.jp");
            return CheckProxyProc(target);
        }

        /// <summary>
        /// �v���L�V�T�[�o�[�̎�ʃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo CheckProxy(Uri target)
        {
            return CheckProxyProc(target);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo GetBitsProxyIngo()
        {
            ProxyInfo proxyInfo = new ProxyInfo();
            WinHttpAPI.WINHTTP_PROXY_INFO winHTTP_PROXY_INFO = new WinHttpAPI.WINHTTP_PROXY_INFO();

            try
            {
                WinHttpAPI.WinHttpGetDefaultProxyConfiguration(ref winHTTP_PROXY_INFO);
                if( winHTTP_PROXY_INFO.lpszProxy == null || winHTTP_PROXY_INFO.lpszProxy == "" )
                {
                    proxyInfo.IsProxy =  ProxyInfo.ProxyType.NOT_USE;
                }
                else
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.USE;
                    proxyInfo.ProxyUrl = winHTTP_PROXY_INFO.lpszProxy;
                }
            }
            catch(Exception ex)
            {
                proxyInfo.Ex = ex;
            }

            return proxyInfo;
        }

        #endregion

        #region �v���C�x�[�g���\�b�h
        /// <summary>
        /// HTTP���N�G�X�g
        /// </summary>
        /// <param name="nSNetworkTestInfo"></param>
        /// <returns></returns>
        private static bool HttpRequestProc(NSNetworkTestInfo nSNetworkTestInfo)
        {
            
            bool result = false;
            string responseMessage;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(nSNetworkTestInfo.NSNetworkTestTargetUri);

                //�v���L�V�o�R�Őڑ�����K�v���L��ꍇ
                if( nSNetworkTestInfo.ProxyInfo != null && nSNetworkTestInfo.ProxyInfo.IsProxy != ProxyInfo.ProxyType.NOT_USE )
                {
                    httpWebRequest.Proxy = new WebProxy(nSNetworkTestInfo.ProxyInfo.ProxyUrl);
                    if( nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.NONE )
                    {
                        //�F�ؖ�
                    }
                    else if( nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.BASIC )
                    {
                        httpWebRequest.Proxy.Credentials = new NetworkCredential("id", "pwd");
                    }
                    else if( nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.WINDOWS )
                    {
                        httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    }
                }

                //�T�[�o�[����̉�������M���邽�߂�WebResponse���擾
                nSNetworkTestInfo.WebRequestStatusNo = GetResponseStream(out responseMessage, httpWebRequest);
                //HTTP���N�G�X�g���ʂ��Z�b�g
                nSNetworkTestInfo.WebRequestStatusMessage = responseMessage;

                if( nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.OK )
                {
                    //�ʐMOK
                    result = true;
                }
                else
                {
                    if( nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP )
                    {
                        if( nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError )
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }

            }
            catch( WebException webex )
            {
                if( webex.Response == null )
                {
                    //�X�e�[�^�X�R�[�h��������Ȃ���O�͑S�āu-1�v�Ƃ���B
                    nSNetworkTestInfo.WebRequestStatusNo = -1;
                }
                else 
                {
                    //HTTP���N�G�X�g�̃X�e�[�^�X���Z�b�g
                    nSNetworkTestInfo.WebRequestStatusNo = (int)( (HttpWebResponse)webex.Response ).StatusCode;

                    //AP�T�[�o�[�����N�G�X�g�X�e�[�^�X��500�̂��̂̓R�l�N�V�����m�����o�����̂Ő���Ƃ݂Ȃ��B
                    if( nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP )
                    {
                        if( nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError )
                        {
                            result = true;
                        }
                    }
                }

                //��O�N���X���Z�b�g
                nSNetworkTestInfo.Ex = webex;
                //HTTP���N�G�X�g�̃G���[�̏ڍׂ��Z�b�g
                nSNetworkTestInfo.WebRequestStatusMessage = webex.Message;
            }
            catch( Exception ex )
            {
                //�X�e�[�^�X�R�[�h��������Ȃ���O�͑S�āu-1�v�Ƃ���B
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                //��O�N���X���Z�b�g
                nSNetworkTestInfo.Ex = ex;
                //HTTP���N�G�X�g�̃G���[�̏ڍׂ��Z�b�g
                nSNetworkTestInfo.WebRequestStatusMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// HTTP���X�|���X�擾
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        private static int GetResponseStream(out string responseMessage, HttpWebRequest httpWebRequest)
        {
            int status = -1;

            //�T�[�o�[����̉�������M���邽�߂�WebResponse���擾
            using( HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse() )
            {
                //HTTP���N�G�X�g�̃X�e�[�^�X���Z�b�g
                status = (int)httpWebResponse.StatusCode;

                //�����f�[�^����M���邽�߂�Stream���擾
                using( System.IO.Stream stream = httpWebResponse.GetResponseStream() )
                {
                    using( System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.Default) )
                    {
                        responseMessage = streamReader.ReadToEnd();  //��M
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �v���L�V�T�[�o�[�̎�ʃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        private static ProxyInfo CheckProxyProc(Uri target)
        {
            int status = -1;
            string responseMessage;
            ProxyInfo proxyInfo = new ProxyInfo();

            //�f�t�H���g�v���L�V�ݒ�̎擾�i��{�I��IE�Őݒ肳��Ă���������j
            Uri testUri = target;
            Uri proxyUri = target;
            //Uri testUri = new Uri("http://www.broadleaf.co.jp");
            //Uri proxyUri = new Uri("http://www.broadleaf.co.jp");

            try
            {
                proxyUri = WebRequest.DefaultWebProxy.GetProxy(testUri);
                if( proxyUri == testUri )
                {
                    //�v���L�V����
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.NOT_USE;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
            {
                //�����ł̗�O�͖�������B
                proxyInfo.Ex = wex;
            }

            //�v���L�V�L��
            proxyInfo.IsProxy = ProxyInfo.ProxyType.USE;
            proxyInfo.ProxyUrl = proxyUri.ToString();

            try
            {
                //�v���L�V�̃o�C�p�X���X�g���擾����@���������A�񐄏����\�b�h����擾����̂Ŋm�����͒ቺ����Ǝv����
                WebProxy workProxy = WebProxy.GetDefaultProxy();
                if(workProxy.Address != null && workProxy.Address.ToString() == proxyUri.ToString())
                {
                    proxyInfo.ProxyBypass.AddRange(workProxy.BypassList);
                }
            }
            catch(Exception ex)
            {
            }

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���f�t�H���g�ݒ�ŒʐM���\���`�F�b�N
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.NONE;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
            {
                //�����ł̗�O�͖�������B
                proxyInfo.Ex = wex;
            }


            //�v���L�V�ݒ�
            IWebProxy proxyObject = new WebProxy(proxyUri);

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���v���L�V�ւ�NTLM�F�؁iWindows�����j���Z�b�g����
                proxyObject.Credentials = CredentialCache.DefaultCredentials;
                httpWebRequest.Proxy = proxyObject;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.WINDOWS;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
            {
                //�����ł̗�O�͖�������B
                proxyInfo.Ex = wex;
            }

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���v���L�V�ւ�BASIC�F�؏����Z�b�g����
                proxyObject.Credentials = new NetworkCredential("ID", "PWD");
                httpWebRequest.Proxy = proxyObject;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.BASIC;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
            {
                //�ŏI�I��WEB��O���Z�b�g����B
                proxyInfo.Ex = wex;
            }
            catch
            {
                //�����ł̗�O�͖�������B
            }


            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���v���L�V���g�p���Ȃ��Œ��ڐڑ�����
                httpWebRequest.Proxy = null;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.FREE_USE;
                }
            }
            catch
            {
                //�����ł̗�O�͖�������B
            }

            //�v���L�V�ւ̔F�؂̎�ނ����ʂł��Ȃ������B
            proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.UNKNOWN;
            return proxyInfo;
        }


        
        #endregion
    }
}
