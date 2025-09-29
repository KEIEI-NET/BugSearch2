//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�p�^�[�����������Ɖ�
// �v���O�����T�v   : ���[�J�[�p�^�[�����������Ɖ�̌������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ���O
// �� �� ��  2020/03/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�J�[�p�^�[�����������Ɖ�A�v���P�[�V�������C���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ�A�v���P�[�V�������C���̒�`�Ǝ������s���N���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
	static class Program
	{
        private static Form PMKHN09783Form = null;

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
        /// <param name="args">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ���N�����郁�C���֐����s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
		[STAThread]
		static void Main(String[] args)
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
             
			try
			{
				string msg = "";
				// �A�v���P�[�V�����J�n��������
				// ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
				int status = ApplicationStartControl.StartApplication(
                    out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

				if (status == 0)
				{
					// �I�����C����Ԕ��f
					if (!LoginInfoAcquisition.OnlineFlag)
					{
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09783U",
							"�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
					}
					else
					{
                        PMKHN09783Form = new PMKHN09783UB();
                        System.Windows.Forms.Application.Run(PMKHN09783Form);
					}
				}
				else
				{
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09783U", msg, 0, MessageBoxButtons.OK);
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
        /// <remarks>
        /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ�I����������ۂɌĂяo�����C�x���g�n���h�����s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			// ���b�Z�[�W���o���O�ɑS�ĊJ��
			ApplicationStartControl.EndApplication();

			// �]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (PMKHN09783Form != null)
			{
                TMsgDisp.Show(PMKHN09783Form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKHN09783U", e.ToString(), 0, MessageBoxButtons.OK);
			}
			else
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09783U", e.ToString(), 0, MessageBoxButtons.OK);
			}

			// �A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}
	}
}