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
    public class ScmOdrDataAcs2 : ScmOdrDataAcs
    {
        private const string CT_ServiceName = "SFCMN02501AA.asmx"; 
        /// <summary>�R���t�B�O�t�@�C����</summary>
        private const string CONFIG_FILE_NAME = "PMSCM01030A.config";

        /// <summary>SCMWebURL�̋K��l</summary>
        private const string InitialSCMWebURL = "http://www41.superfrontman.net/SCMWebServices";
        //private const string InitialSCMWebURL = "http://10.20.100.74:80/SCMWebServices/";

        public ScmOdrDataAcs2()
        {
        }

        protected override SFCMN02501AServices GetSFCMN02501AServices()
        {
            //������������ ���̕����Őڑ�����w�� ������������
            string webpath =GetSCMWebServiceURLFromPMC();
            if (webpath == string.Empty)
            { 
                 webpath =GetSCMWebServiceURLFromConfig();
            }

            SFCMN02501AServices result = new SFCMN02501AServices(webpath + CT_ServiceName);
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
            SCMWebURLInformation info = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SCMWebURLInformation));

                string filePath = CONFIG_FILE_NAME;
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    info = (SCMWebURLInformation)serializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return InitialSCMWebURL;
            }

            if (info.SCMWebURL == null)
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return InitialSCMWebURL;
            }
            else
            {
                if (info.SCMWebURL != "") { return info.SCMWebURL; }
                else { return InitialSCMWebURL;}
            }
        }
        #endregion
    }

    //>>>2011/05/25
    public class ScmCnctSetAcs2 : ScmCnctSetAcs
    {
        private const string CT_ServiceName = "SFCMN02564AA.asmx";
        /// <summary>�R���t�B�O�t�@�C����</summary>
        private const string CONFIG_FILE_NAME = "PMSCM01030A.config";

        /// <summary>SCMWebURL�̋K��l</summary>
        private const string InitialSCMWebURL = "http://www41.superfrontman.net/SCMWebServices";
        //private const string InitialSCMWebURL = "http://10.20.100.74:80/SCMWebServices/";

        public ScmCnctSetAcs2()
        {
        }

        protected override SFCMN02564AServices GetSFCMN02564AServices()
        {
            //������������ ���̕����Őڑ�����w�� ������������
            string webpath = GetSCMWebServiceURLFromPMC();
            if (webpath == string.Empty)
            {
                webpath = GetSCMWebServiceURLFromConfig();
            }

            SFCMN02564AServices result = new SFCMN02564AServices(webpath + CT_ServiceName);
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
            SCMWebURLInformation info = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SCMWebURLInformation));

                string filePath = CONFIG_FILE_NAME;
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    info = (SCMWebURLInformation)serializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return InitialSCMWebURL;
            }

            if (info.SCMWebURL == null)
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                return InitialSCMWebURL;
            }
            else
            {
                if (info.SCMWebURL != "") { return info.SCMWebURL; }
                else { return InitialSCMWebURL; }
            }
        }
        #endregion
    }
    //<<<2011/05/25

    /// <summary>
    /// �ݒ���N���X
    /// </summary>
    [Serializable]
    public class SCMWebURLInformation
    {

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMWebURLInformation() { }

        #endregion // </Constructor>

        #region <���MWebURL>

        /// <summary>SCM���MWebURL</summary>
        public string SCMWebURL;

        #endregion // </���MWebURL>
 
    }

}
