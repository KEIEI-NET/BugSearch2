using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        private static string[] _parameter;						// �N���p�����[�^
        private static Form _form = null;
        private static TabSCMUpLoadAcs tabSCMUpLoadAcs = null;  //ADD  �A���� 2013/06/24 Redmine#37173 �ݒ�}�X�^�A�b�v���[�h(PM�{�̑�)�N�����[�h�̒ǉ�
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                // �A�v���P�[�V�����J�n��������
                // ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // �I�����C����Ԕ��f
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMTAB00110U",
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    // ----- ADD  �A���� 2013/06/24 Redmine#37173 �ݒ�}�X�^�A�b�v���[�h(PM�{�̑�)�N�����[�h�̒ǉ�----->>>>>
                    else
                    {
                        if (_parameter.Length > 0)
                        {
                            if (_parameter[0].Equals("BATCH"))
                            {
                                if (tabSCMUpLoadAcs == null)
                                {
                                    tabSCMUpLoadAcs = new TabSCMUpLoadAcs();
                                }
                                tabSCMUpLoadAcs.UploadFromNStoSCMByBatch(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, 0);
                            }
                        }
                        else
                        {
                            _form = new PMTAB00110UA();

                            System.Windows.Forms.Application.Run(_form);
                        }
                    }
                    // ----- ADD  �A���� 2013/06/24 Redmine#37173 �ݒ�}�X�^�A�b�v���[�h(PM�{�̑�)�N�����[�h�̒ǉ�-----<<<<<
                    // ----- DEL  �A���� 2013/06/24 Redmine#37173 �ݒ�}�X�^�A�b�v���[�h(PM�{�̑�)�N�����[�h�̒ǉ�----->>>>>
                    //else
                    //{
                    //    _form = new PMTAB00110UA();

                    //    System.Windows.Forms.Application.Run(_form);
                    //}
                    // ----- DEL  �A���� 2013/06/24 Redmine#37173 �ݒ�}�X�^�A�b�v���[�h(PM�{�̑�)�N�����[�h�̒ǉ�-----<<<<<
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMTAB00110U", msg, 0, MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMTAB00110U", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MAKON01100UA());
            */
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

            // �]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMTAB00110U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMTAB00110U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}
