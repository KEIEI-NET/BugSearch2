using System;
using System.Diagnostics;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

using Microsoft.Win32;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    internal static class Program
    {
        /// <summary>�v���O����ID</summary>
        private const string PROGRAM_ID = "PMSCM01300U";

        /// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
        /// <param name="args">�R�}���h���C������</param>
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null || args.Length.Equals(0)) return;
            try
            {
                // ���b�Z�[�W�{�b�N�X��XP�X�^�C��
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                // �N������
                string msg = string.Empty;

                // �A�v���P�[�V�����J�n��������
                int status = ApplicationStartControl.StartApplication(
                    out msg,
                    ref args,
                    ConstantManagement_SF_PRO.ProductCode,  // �A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��i�ł��Ȃ��ꍇ�̓v���_�N�g�R�[�h�j
                    new EventHandler(ReleasedApplicationEventHandler)
                );

                // "/A":�|�b�v�A�b�v����Ă΂ꂽ�i�o�b�`�����j
                bool modeBatch = (args.Length > 0 && args[0] == "/A");

                if (status.Equals(0))
                {
                    if (HasSecurityError(out msg))
                    {
                        ShowDefaultAlert(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, status, modeBatch);
                        return;
                    }
                    // �ڍs�����J�n
                    if (!modeBatch)
                    {
                        msg = "�q�Ɉڍs�������J�n���Ă�낵���ł����H";
                        if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PROGRAM_ID, msg, status, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    Iko _iko = new Iko();
                    status = _iko.Iko_Main(modeBatch);

                    msg = "�q�Ɉڍs�������I�����܂����Bstatus:" + status;
                    ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, msg, status, modeBatch);
                }
                else
                {
                    ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, msg, status, modeBatch);
                    return;
                }
            }
            catch (Exception e)
            {
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, -1, true);
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
        private static void ReleasedApplicationEventHandler(object sender, EventArgs e)
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// �Z�L�����e�B�G���[�����邩���肵�܂��B
        /// </summary>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :�Z�L�����e�B�G���[����<br/>
        /// <c>false</c>:�Z�L�����e�B�G���[�Ȃ�
        /// </returns>
        private static bool HasSecurityError(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                errorMessage = "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B"; 
                return true;
            }

            return false;
        }

        /// <summary>
        /// �f�t�H���g�̃A���[�g��\�����܂��B
        /// </summary>
        /// <param name="errorLevel">�G���[���x��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="status">��������</param>
        /// <param name="batch">�o�b�`����</param>
        public static void ShowDefaultAlert(
            emErrorLevel errorLevel,
            string message,
            int status,
            bool batch
        )
        {
            if (!batch) TMsgDisp.Show(errorLevel, PROGRAM_ID, message, status, MessageBoxButtons.OK);
        }

    }
}
