using System;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����f�[�^���o�����|�b�v�A�b�v�A�v���P�[�V�����̃G���g���N���X
    /// </summary>
    internal static class Program
    {
        private static string[] _parameter;						// �N���p�����[�^
        private static Form _form = null;
        public static bool PM7Mode = false;
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <param name="args">�R�}���h���C������</param>
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                // �A�v���P�[�V�����J�n��������
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // �I�����C����Ԕ��f
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSCM01210U",
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        System.Windows.Forms.Application.Run(new PMSCM01210UA());
                    }
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
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

             //�]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null)
            {
            TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMSCM01210U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM01210U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}