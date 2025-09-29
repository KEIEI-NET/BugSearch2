using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        internal static string[] _parameter;						// �N���p�����[�^
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;

                // �� 2009/06/25 ���m add PVCS.283
                string workDir = null;
                // ڼ޽�ط��擾
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else
                {
                    // �J�����g�t�H���_�̐ݒ�
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
                System.IO.Directory.SetCurrentDirectory(workDir);
                // �� 2009/06/25 ���m add


                //�A�v���P�[�V�����J�n��������
                //���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                //int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    ////�I�����C����Ԕ��f
                    //if (!LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09210U",
                    //        "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    //}
                    //else
                    //{
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    _form = new PMKYO01150UA();
                    //if (_parameter.Length > 0) // ����������ꍇ�͉�ʕ\�������I�����邽�߁A���L�������s��Ȃ��B
                    //{
                        ((PMKYO01150UA)_form).MergeOfferToUser(); // �����N��������
                    //}
                    //else // �T�[�r�X�ݒ��ʕ\��
                    //{
                    //    System.Windows.Forms.Application.Run(_form);
                    //}
                    //}
                }
                else
                {
                    MessageBox.Show(msg, "PMKYO01150U", MessageBoxButtons.OK);
                }
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }

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
            MessageBox.Show(e.ToString(), "PMKYO01150U", MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}