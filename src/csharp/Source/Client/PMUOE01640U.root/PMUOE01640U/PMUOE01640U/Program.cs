//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        // �v���O�����h�c
        public const string ctPGID = "PMUOE01640U";

        /// <summary>EXE�N���p�����[�^</summary>
        public static string[] _parameter;
        /// <summary>EXE�N���t�H�[��</summary>
        public static Form _form = null;


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
                // ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��
                // �o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        msg = "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B";
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, msg, 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _form = new PMUOE01640UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0)
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctPGID, ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null)
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
            else
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}