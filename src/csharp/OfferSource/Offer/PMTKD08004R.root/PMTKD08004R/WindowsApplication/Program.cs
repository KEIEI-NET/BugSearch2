using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace WindowsApplication
{
	static class Program
	{
		private static string[] _parameter;
		private static Form _form = null;

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

				// �A�v���P�[�V�����J�n��������
				// ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͎w��
				// �ł��Ȃ��ꍇ�̓v���_�N�g�R�[�h
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();

					Application.Run(_form);
				}
				if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Sample", msg, 0, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "Sample", ex.Message, 0, MessageBoxButtons.OK);
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
			if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Sample", e.ToString(), 0, MessageBoxButtons.OK);
			else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Sample", e.ToString(), 0, MessageBoxButtons.OK);
			//�A�v���P�[�V�����I��
			Application.Exit();
		}
	}
}