using System;
using System.Windows.Forms;
using System.Diagnostics;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// ���iMAX�T�C�g�N���t���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���iMAX�T�C�g�N���t���[���N���X���N�����܂��B</br>
	/// <br>Programmer : �{�{ ����</br>
	/// <br>Date       : 2015/10/14</br>
	/// </remarks>
    public class ApplicationController
	{
		private static ApplicationContext _apli = null;
        public static string[] _parameter = null;

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string msg = "";
            try
            {
                _parameter = args;

                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // �I�����C����Ԕ��f
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHST00010U",
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        // �N���\������
                        if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry("PMHST00010U", true))
                        {
                            return;
                        }
                        ApplicationController.ProcessStart();
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHST00010U", msg, 0, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                msg = "�F�ؒ��ɃG���[���������܂����BUSB�v���e�N�^���h�����Ă��鎖���m�F���Ă��������B[" + ex.Message + "]";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMHST00010U", msg, -1, MessageBoxButtons.OK);
            }
            finally
            {
                // �J��
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
		
		/// <summary>
		/// �A�v���P�[�V�����I���C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">���b�Z�[�W</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//���b�Z�[�W���o���O�ɑS�ĊJ��
			ApplicationStartControl.EndApplication();

			//�]�ƈ����O�I�t�̃��b�Z�[�W��\��
			TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHST00010U", e.ToString(), 0, MessageBoxButtons.OK);

			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}

        /// <summary>
        /// URL�u��
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL�u�����s���܂��B</br>
        /// <br>Programmer : �{�{ ����</br>
        /// <br>Date       : 2015/10/14</br>
        /// </remarks>
        protected static string UrlReplace(string domain, string path)
        {
            string wkStr = domain + path;
            // �u��
            wkStr = wkStr.Replace("$enterpriseCode", LoginInfoAcquisition.EnterpriseCode);
            wkStr = wkStr.Replace("$assemblyVersion", "1.0.0");

            return wkStr;
        }

        /// <summary>
        /// URL�\�z
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL�\�z���s���܂��B</br>
        /// <br>Programmer : �{�{ ����</br>
        /// <br>Date       : 2015/10/14</br>
        /// </remarks>
        protected static int CreateUrl(out string url)
        {
            string wkStr = "";
            string msg = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                string domain = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_PARTSMAX);
                string path = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_PARTSMAX, ConstantManagement_SF_PRO.IndexCode_PARTSMAX_WebPath);

                // �u��
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                msg = "�ڑ���擾���ɃG���[���������܂����B[" + ex.Message + "]";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMHST00010U", msg, -1, MessageBoxButtons.OK);
                return -1;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// URL�N��
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL�N�����s���܂��B</br>
        /// <br>Programmer : �{�{ ����</br>
        /// <br>Date       : 2015/10/14</br>
        /// </remarks>
        protected static int ProcessStart()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string msg = "";
            string url = "";
            try
            {
                // �A�gURL(���iMAX)���쐬���܂��B
                status = ApplicationController.CreateUrl(out url);
                if (status == 0)
                {
                    // �v���Z�X�N��
                    Process.Start(url);
                }
            }
            catch (Exception ex)
            {
                msg = "�u���E�U�N�����ɃG���[���������܂����B[" + ex.Message  + "]\r\n�Z�L�����e�B�΍�\�t�g��Partsman�C���X�g�[���t�H���_�����O�ݒ�ɂȂ��Ă��邩���m�F���肢���܂��B";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMHST00010U", msg, -1, MessageBoxButtons.OK);
                return -1;
            }
            return status;
        }
    }
}
