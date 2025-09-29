using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        //================================================================================
        //  �ÓI�����o
        //================================================================================
        #region Private Static Members
        internal static string[] _parameter;									// �N���p�����[�^
        internal static System.Windows.Forms.Form _form = null;					// �N���t�H�[��
        #endregion

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

                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // �I�����C����Ԕ���
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        // �I�t���C�����
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAZAI04100",
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        // �N���\������
                        if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry("MAZAI04100U", true))
                        {
                            return;
                        }

                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new MAZAI04100UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAZAI04100", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "MAZAI04100", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        //================================================================================
        //  �C�x���g
        //================================================================================
        #region Event
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "MAZAI04100", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAZAI04100", e.ToString(), 0, MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
        #endregion

    }
}