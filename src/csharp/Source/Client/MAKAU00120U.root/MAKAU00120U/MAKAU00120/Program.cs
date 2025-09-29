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
		/// <summary>�N�����X�v���b�V���E�B���h�E(SFCMN00025C)</summary>
		public static Broadleaf.Windows.Forms.FloatingWindow SplashWindow = new FloatingWindow();
		/// <summary>�N���p�����[�^</summary>
		public static string[] Param = null;
		/// <summary>�N������t�H�[���N���X</summary>
		private static Form _form;
		/// <summary>�v���O����ID</summary>
        public const string PGID = "MAKAU00120U";

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main(string[] Args)
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				// ���O�C���`�F�b�N
				string msg = "";

				// �A�v���P�[�V�����J�n(�I���C�x���g�o�^�j
				int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

				Param = Args;

				if (status == 0)
				{
					if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
					{
						msg = "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PGID, msg, 0, MessageBoxButtons.OK);
					}
					else
					{
						// �A�v���P�[�V�����J�n
						_form = new MAKAU00120UA();
                        if (Param[0] == "1")
                        {
                            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
                            //_form.Text = "�����X�V����";
                            _form.Text = "��������X�V";
                            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
                        }
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					// �G���[�\��
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, msg, 0, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				// ��O�G���[�\��
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PGID, ex.Message, 0, ex, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, PGID, e.ToString(), 0, MessageBoxButtons.OK);
			else
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, e.ToString(), 0, MessageBoxButtons.OK);

			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}
	}
}