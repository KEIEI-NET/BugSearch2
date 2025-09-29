using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	static class Program
	{
		#region PrivateStaticMember
		// ���C���t���[���t�H�[��
		private static Form _form = null;
		// �N���p�����[�^
		internal static string[] _param = null;
		// �v���O����ID
		private static string ctPGID = "MAMOK01100U";
		// �t���[�e�B���O�E�E�B���h�E��`
        //internal static FloatingWindow _floatingWindow = new FloatingWindow();
		#endregion

		#region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// �N���p�t���[�e�B���O�E�B���h�E(Show)
                //_floatingWindow.Show(null);

				// ���O�C���`�F�b�N
				string msg = "";
				_param = args;

				// �A�v���P�[�V�����J�n(�I���C�x���g�o�^�j
				int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					// �I�����C����Ԕ��f
					if (!LoginInfoAcquisition.OnlineFlag)
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID,
							"�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���", 0, MessageBoxButtons.OK);
					}
					else
					{
						_form = new MAMOK01100UA();

						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, msg, 0, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\b" + ex.StackTrace);
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctPGID, ex.Message, 0, MessageBoxButtons.OK);
			}
			finally
			{
				// �N���p�t���[�e�B���O�E�B���h�E(Close)
                //_floatingWindow.Close();
				ApplicationStartControl.EndApplication();
			}
		}
		#endregion

		#region StaticEvent
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
			{
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
			}
			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}
		#endregion
	}
}