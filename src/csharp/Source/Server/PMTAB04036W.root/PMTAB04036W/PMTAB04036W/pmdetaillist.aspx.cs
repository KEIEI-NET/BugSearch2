using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using Broadleaf.Application.Common;
using Broadleaf.Configuration;
using Broadleaf.Web.Common;
using Broadleaf.Application.Resources;  // ADD 2013.08.27 kubo @ �Q�Ɛݒ��SFCMN00615C��ǉ�

namespace Broadleaf.Web.UI
{
    /// <summary>
    /// �^�u���b�gPM�W�����i�I���y�[�W
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : LDNS</br>
    /// <br>Date        : 2013.06.03</br>
    /// <br>Note        : �^�u���b�gPM�W�����i�I���y�[�W�̓��e���\�z���܂��B</br>
    /// <br>-------------------------------------------------</br>
    /// <br>UpdateDate : 2013.08.27</br>
    /// <br>           : 22013 kubo</br>
    /// <br>           : WebSync�̃p�X��F�ؕ��i����擾����悤�ɕύX</br>
    /// </remarks>
    public partial class PMTAB04036W : System.Web.UI.Page
    {
        /// <summary>
        /// ���O�C�����[�U����
        /// </summary>
        public string employeeAuth;

        /// <summary>
        /// ���O�C��URL
        /// </summary>
        public string loginUrl;

        /// <summary>
        /// ���O�A�E�gURL
        /// </summary>
        public string logoutUrl;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string enterpriseCode;

        /// <summary>
        /// �E�F�u�V�b�N�̃p�X
        /// </summary>
        public string websyncAp;

        /// <summary>
        /// �y�[�W���[�h�C�x���g�����B
        /// </summary>
        /// <param name="sender">�������I�u�W�F�N�g�B</param>
        /// <param name="e">�C�x���g�f�[�^�B</param>
        /// <remarks>
        /// <br>Programmer  : LDNS</br>
        /// <br>Date        : 2013.06.03</br>
        /// <br>Note        : �y�[�W���[�h�̃C�x���g�������s���܂��B</br>
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AspLoginInfoAcquisition acquisition = new AspLoginInfoAcquisition();
                this.employeeAuth = acquisition.Employee.Name;
                NSHttpApplicationConfigSectionHandler section = WebConfigurationManager.GetSection("nsHttpAppSettings") as NSHttpApplicationConfigSectionHandler;
                this.loginUrl = section.LoginControl.LoginUrl;
                this.logoutUrl = section.LoginControl.LogoutUrl;
                this.enterpriseCode = acquisition.EnterpriseCode;

                // DEL 2013.08.27 kubo @ WebSync�ڑ���擾���@�ύX
                //this.websyncAp = acquisition.GetAPServiceTargetDomain("WEBSYNC_AP");
                // ADD 2013.08.27 kubo @ WebSync�ڑ���擾���@�ύX *-------------------->>>
                this.websyncAp =
                    string.Format("{0}{1}",
                        acquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP),
                        acquisition.GetConnectionInfo(
                            ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP,
                            ConstantManagement_SF_PRO.IndexCode_WebSync_Client_WebPath)
                    );
                // ADD 2013.08.27 kubo @ WebSync�ڑ���擾���@�ύX <<<--------------------*

                new UrlQueryString(base.Request.QueryString);

                // �e�[�}����p��CSS�t�@�C���̃��[�h����
                this.LoadThemeCss();
            }
            catch (ThreadAbortException)
            {
            }
            catch (MobileWebException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw new MobileWebException("PMTAB04036W", "Page_Load", "�^�u���b�gPM�W�����i�I���y�[�W�ŃG���[���������܂����B" + Environment.NewLine + exception2.Message, -1, exception2);
            }

        }

        /// <summary>
        /// �e�[�}����p��CSS�t�@�C���̃��[�h����
        /// </summary>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer   :   LDNS</br>
        /// <br>Date         :   2013.06.03</br>
        /// <br>Note         :   �e�[�}����p��CSS�t�@�C���̐ؑւ��s���B</br>
        /// <br></br>
        ///</remarks>
        private void LoadThemeCss()
        {
            // TODO
            this.theme.Href = "css/common/pm_normal.css?ver=" + ExtFileVersion.Ver();
        }
    }
}