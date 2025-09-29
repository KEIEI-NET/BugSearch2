//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Tablet�풓����
// �v���O�����T�v   : �G���g���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/08/07  �C�����e : �ċN���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM�|�b�v�A�b�v�A�v���P�[�V�����̃G���g���N���X
    /// </summary>
	internal static class Program
	{
        private static string[] _parameter;						// �N���p�����[�^
        //public static bool PM7Mode=false;// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή�

        /// <summary>
        /// �R�}���h���C�������̕ۊ�
        /// </summary>
        public static string[] argsSave;
        public const string RIGHTCLICK = "rightClick";

        // ADD �g�� 2013/08/07 �풓�����ċN���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        public const string RESTART = "RESTART";
        public const Int32 WM_COPYDATA = 0x4A;
        // ADD �g�� 2013/08/07 �풓�����ċN���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
        /// <param name="args">�R�}���h���C������</param>
		[STAThread]
		static void Main(string[] args)
        {
            argsSave = args;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            if (args[0] == "/B")
            {
                //PM7Mode = true;// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.6�̑Ή�
                // �|�b�v�A�b�v�̑��d�N���h�~
                if (SCMClientUtil.CanRun())
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                }

            }
            else
            {

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
                            if (args.Length <= 2 || args[2] != "/S")
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMTAB00100U",
                                    "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                            }
                        }
                        else
                        {

                            // �R�}���h���C�������̐��@2�F�Ɩ����j���[�@3����"rightClick"�F�^�X�N�̃p�g�����v�A�C�R���E�N���b�N���j���[��"�X�V"
                            if (args.Length == 2
                                || !(args.Length == 3 && args[2].Equals(RIGHTCLICK)))
                            {
                                // �|�b�v�A�b�v�̑��d�N���h�~
                                if (SCMClientUtil.CanRun())
                                {
                                    System.Windows.Forms.Application.EnableVisualStyles();
                                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                    System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                                }
                                else
                                {
                                    // ADD �g�� 2013/08/07 �풓�����ċN���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    // �N���ς݂̏풓�������I�����āA�V�K�ɏ풓�������N��
                                    if (Restart())
                                    {
                                        System.Windows.Forms.Application.EnableVisualStyles();
                                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                        System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                                    }
                                    // ADD �g�� 2013/08/07 �풓�����ċN���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                System.Windows.Forms.Application.EnableVisualStyles();
                                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                System.Windows.Forms.Application.Run(new TabletPopupForm(args));
                            }
                        }
                    }
                }
                finally
                {
                    ApplicationStartControl.EndApplication();
                }
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

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }


        // ADD �g�� 2013/08/07 �풓�����ċN���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        [System.Runtime.InteropServices .DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);

        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam,
          ref COPYDATASTRUCT lParam);

        //COPYDATASTRUCT�\���� 
        public struct COPYDATASTRUCT
        {
            public Int32 dwData;    //���M����32�r�b�g�l
            public Int32 cbData;    //lpData�̃o�C�g��
            public string lpData;   //���M����f�[�^�ւ̃|�C���^(0���\)
        }

        /// <summary>
        /// �ċN�������@���b�Z�[�W���M
        /// </summary>
        /// <returns></returns>
        private static bool Restart()
        {
            // TabletPopupForm��Text�v���p�e�B�Ɠ���Ƃ���K�v������
            string windowName = "�^�u���b�g������";

            Int32 result = 0;

            //����̃E�B���h�E�n���h�����擾���܂�
            Int32 hWnd = FindWindow(null, windowName);
            if (hWnd == 0)
            {
                //�n���h�����擾�ł��Ȃ�����
                MessageBox.Show("�N���ςݏ풓�����̃n���h�����擾�ł��܂���");
                return false;
            }

            //�����񃁃b�Z�[�W�𑗐M���܂�
            //���M�f�[�^��Byte�z��Ɋi�[
            byte[] bytearry = System.Text.Encoding.Default.GetBytes(RESTART);
            Int32 len = bytearry.Length;
            COPYDATASTRUCT cds;
            cds.dwData = 0;        //�g�p���Ȃ�
            cds.lpData = RESTART;  //�e�L�X�g�̃|�C���^�[���Z�b�g
            cds.cbData = len + 1;  //�������Z�b�g
            //������𑗂�
            result = SendMessage(hWnd, WM_COPYDATA, 0, ref cds);

            return result.Equals(0);
        }
        // ADD �g�� 2013/08/07 �풓�����ċN���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}