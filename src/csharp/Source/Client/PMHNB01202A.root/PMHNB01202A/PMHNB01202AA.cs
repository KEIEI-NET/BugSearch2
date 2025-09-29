using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;


using Broadleaf.Web.Services;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    public class MblOdrDataAcs2 : MblOdrDataAcs
    {
        private const string CT_ServiceName = "SFMIT02861AA.asmx"; 
        /// <summary>�R���t�B�O�t�@�C����</summary>
        private const string CONFIG_FILE_NAME = "PMHNB01202A.config";

        /// <summary>SCMWebURL�̋K��l</summary>
        private const string InitialSCMWebURL = "http://www41.superfrontman.net/SCMWebServices";
        //private const string InitialSCMWebURL = "http://10.20.100.74:80/SCMWebServices/";

        public MblOdrDataAcs2()
        {
        }

        protected override SFMIT02861AServices GetSFMIT02861AServices()
        {
            //������������ ���̕����Őڑ�����w�� ������������
            string webpath =GetSCMWebServiceURLFromPMC();
            if (webpath == string.Empty)
            { 
                 webpath =GetSCMWebServiceURLFromConfig();
            }

            SFMIT02861AServices result = new SFMIT02861AServices( webpath + CT_ServiceName );
            result.Timeout = 600000;
            return result;
        }

        #region �F�؏����SCM_Service��URL�擾
        /// <summary>
        /// �F�؏����SCM_Service��URL�擾
        /// </summary>
        /// <returns></returns>
        private static string GetSCMWebServiceURLFromPMC()
        {
            string SCMWebServiceURL = string.Empty;
            try
            {

                SCMWebServiceURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);	// SCMWeb�T�[�r�X�T�[�o�[
                SCMWebServiceURL += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

                return SCMWebServiceURL;
            }
            catch (Exception e)
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return string.Empty;
            }

        }
        #endregion

        #region URL�����R���t�B�O�t�@�C������ǂݍ��݂܂�
        /// <summary>
        /// URL�����R���t�B�O�t�@�C������ǂݍ��݂܂��B
        /// </summary>
        /// <returns></returns>
        private static string GetSCMWebServiceURLFromConfig()
        {
            SCMWebURLInformation_PMHNB01202A info = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer( typeof( SCMWebURLInformation_PMHNB01202A ) );

                string filePath = CONFIG_FILE_NAME;
                using ( FileStream stream = new FileStream( filePath, FileMode.Open ) )
                {
                    info = (SCMWebURLInformation_PMHNB01202A)serializer.Deserialize( stream );
                }
            }
            catch ( Exception e )
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return InitialSCMWebURL;
            }

            if ( info.SCMWebURL == null )
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return InitialSCMWebURL;
            }
            else
            {
                if ( info.SCMWebURL != "" ) { return info.SCMWebURL; }
                else { return InitialSCMWebURL; }
            }
        }
        #endregion
    }

    /// <summary>
    /// �ݒ���N���X
    /// </summary>
    [Serializable]
    public class SCMWebURLInformation_PMHNB01202A
    {

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMWebURLInformation_PMHNB01202A() { }

        #endregion // </Constructor>

        #region <���MWebURL>

        /// <summary>SCM���MWebURL</summary>
        public string SCMWebURL;

        #endregion // </���MWebURL>
 
    }

}
