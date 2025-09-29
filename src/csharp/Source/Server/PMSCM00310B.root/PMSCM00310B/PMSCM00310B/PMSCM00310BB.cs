//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����F�ؕ��i
// �v���O�����T�v   : �����F�ؕ��i
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11070136-00  �쐬�S�� : ���{ �G�I
// �� �� ��  2014/08/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

using System.Net;
using System.Web;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// OAtuh�F�؏��Ǘ��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: </br>
    /// <br>Programmer	: ���{ �G�I</br>
    /// <br>Date		: 2014/08/27</br>
    /// </remarks>
    public class MagellanAuthUtils
    {
        /// <summary>&amp;������</summary>
        private const char SEPARATOR = '&';

        private static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        private MagellanAuthUtils()
        {
        }
        #endregion

        /// <summary>
        /// �F�؏����Z�b�g���܂��B
        /// </summary>
        /// <param name="req"></param>
        /// <param name="oatuh_consumer_key"></param>
        /// <param name="oauth_consumer_secret"></param>
        /// <param name="clientVersion"></param>
        public static void AddOAuthInfo(HttpWebRequest req, string oatuh_consumer_key, string oauth_consumer_secret, string clientVersion)
        {
            AddOAuthInfoProc(req, oatuh_consumer_key, oauth_consumer_secret, clientVersion);
        }


        private static void AddOAuthInfoProc(HttpWebRequest req, string oatuh_consumer_key, string oauth_consumer_secret, string clientVersion)
        {
            #region OAUTH�p�����[�^
            string oauth_signature = "";
            string url = req.RequestUri.AbsoluteUri;
            Dictionary<string, string> oauthDict = new Dictionary<string, string>();
            oauthDict.Add("oauth_consumer_key", oatuh_consumer_key);
            oauthDict.Add("oauth_nonce", DateTime.Now.Ticks.ToString());
            oauthDict.Add("oauth_timestamp", GetUnixTime().ToString());
            oauthDict.Add("oauth_signature_method", "HMAC-SHA1");
            oauthDict.Add("oauth_version", "1.0");
            #endregion

            string query = req.RequestUri.Query;
            if (!string.IsNullOrEmpty(query) && query.StartsWith("?"))
            {
                url = url.Substring(0, url.Length - query.Length);
                query = query.Substring(1);
            }

            string[] queryToken = query.Split(new char[] { SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
            int eqIndex = -1;
            List<string> sortedKeys = new List<string>();
            foreach (string token in queryToken)
            {
                if ((eqIndex = token.IndexOf('=')) != -1)
                {
                    oauthDict.Add(token.Substring(0, eqIndex), token.Substring(eqIndex + 1));
                }
            }
            sortedKeys.AddRange(oauthDict.Keys);
            sortedKeys.Sort();

            #region signature�p�����[�^����
            StringBuilder signatureParam = new StringBuilder();
            foreach (string key in sortedKeys)
            {
                signatureParam.Append(key).Append('=').Append(oauthDict[key]).Append(SEPARATOR);
            }
            signatureParam.Remove(signatureParam.Length - 1, 1);
            #endregion


            #region �x�[�X�X�g�����O����
            StringBuilder oauthParam = new StringBuilder();
            oauthParam.Append(UrlEncode(req.Method));
            oauthParam.Append(SEPARATOR).Append(UrlEncode(url));
            oauthParam.Append(SEPARATOR).Append(UrlEncode(signatureParam.ToString()));
            #endregion

            #region HMACSHA1
            HMACSHA1 hmac = new HMACSHA1();
            hmac.Key = Encoding.UTF8.GetBytes(UrlEncode(oauth_consumer_secret) + SEPARATOR);
            byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(oauthParam.ToString()));
            oauth_signature = UrlEncode(Convert.ToBase64String(b));
            #endregion

            #region �w�b�_���ݒ�
            StringBuilder oauthHeader = new StringBuilder();
            oauthHeader.Append("OAuth").Append(" ");
            oauthHeader.Append("oauth_consumer_key=\"").Append(oauthDict["oauth_consumer_key"]).Append("\",");
            oauthHeader.Append("oauth_signature_method=\"").Append(oauthDict["oauth_signature_method"]).Append("\",");
            oauthHeader.Append("oauth_signature=\"").Append(oauth_signature).Append("\",");
            oauthHeader.Append("oauth_timestamp=\"").Append(oauthDict["oauth_timestamp"]).Append("\",");
            oauthHeader.Append("oauth_nonce=\"").Append(oauthDict["oauth_nonce"]).Append("\",");
            oauthHeader.Append("oauth_version=\"").Append(oauthDict["oauth_version"]).Append("\",");
            req.Headers.Add("Authorization", oauthHeader.ToString());
            req.Headers.Add("Client-Version", clientVersion);
            #endregion
        }

        /// <summary>
        /// UnixTime�擾
        /// </summary>
        /// <param name="targetTime"></param>
        /// <returns></returns>
        public static long GetUnixTime()
        {
            // �o�ߕb���ɕϊ�
            return (long)(DateTime.UtcNow - UNIX_EPOCH).TotalSeconds;
        }

        /// <summary>
        /// �n���ꂽ�������URL�G���R�[�h���܂��B
        /// C#�̃f�t�H���g��HttpUtility.UrlEncode�̓G�X�P�[�v�V�[�P���X��
        /// �������ƂȂ��Ă��܂��܂��B
        /// ���ꂾ�ƃn�b�V���l�����߂�ۂɃT�[�o�[�T�C�h�ƕs��������������̂ŁA
        /// �啶���ɕϊ����s���܂��B
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UrlEncode(string s)
        {
            string value = HttpUtility.UrlEncode(s);
            char[] chArray = value.ToCharArray();
            StringBuilder answer = new StringBuilder();
            for (int i = 0, j = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '%')
                {
                    j = 2;
                    answer.Append(chArray[i]);
                }
                else if (j > 0)
                {
                    j--;
                    answer.Append(Char.ToUpper(chArray[i]));
                }
                else
                {
                    answer.Append(chArray[i]);
                }
            }
            return answer.ToString();
        }
    }
}
