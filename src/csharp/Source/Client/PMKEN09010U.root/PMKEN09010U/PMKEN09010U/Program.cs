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
		/// <summary>�t���[�e�B���O�E�B���h�E(SFCMN00025C)</summary>
		//public static Broadleaf.Windows.Forms.FloatingWindow _floatingWindow = new FloatingWindow();  // DEL 2008/07/01
		/// <summary>�N���p�����[�^</summary>
		public static string[] _param = null;
		/// <summary>�N������t�H�[���N���X</summary>
		private static Form _form;
		/// <summary>�v���O����ID</summary>
		public const string PGID = "NSKEN90100";

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main(string[] Args)
		{
			try
			{
				// ���b�Z�[�W�{�b�N�X��XP�X�^�C����
				System.Windows.Forms.Application.EnableVisualStyles();

				// �N���p�t���[�e�B���O�E�B���h�E(Show)
				//_floatingWindow.Show(null);  // DEL 2008/07/01

				// ���O�C���`�F�b�N
				string msg = "";

				// �A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
				//int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_PM.ProductCode, new EventHandler(ApplicationReleased));
                int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

				_param = Args;

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
                        _form = new PMKEN09010UA();
                        System.Windows.Forms.Application.Run(_form);
                        /*
						if (((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput) > 0))
						{
							// �A�v���P�[�V�����J�n
							_form = new NSKEN90100UA();
							System.Windows.Forms.Application.Run(_form);
						}
						else
						{
							msg = "���_��\�t�g�E�F�A�ł��B";
							TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PGID, msg, 0, MessageBoxButtons.OK);
							return;
						}
                         * */
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
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PGID, ex.Message, 0, MessageBoxButtons.OK);
			}
			finally
			{
				// �N���p�t���[�e�B���O�E�B���h�E(Close)
				//_floatingWindow.Close();  // DEL 2008/07/01
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