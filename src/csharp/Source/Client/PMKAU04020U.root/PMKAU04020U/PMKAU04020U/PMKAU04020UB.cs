using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �A�v���P�[�V�����ҋ@�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ��������A�ҋ@�ɂ��悤����鏈�����T�|�[�g���܂��B<br />
    /// <br>Programmer : 30182 R.Tachiya<br />
    /// <br>Date       : 2012.06.18<br />
    /// <br>Update Note: 2012/09/12 �� �B</br>
    /// <br>             �t�@�C���̑��݃`�F�b�N�ǉ�</br>
	/// </remarks>
	public class ApplicationWaiter
	{
		#region // -- Public Methods --

		/// <summary>
		/// �A�v���P�[�V�����ҋ@����
		/// </summary>
		/// <param name="targetProcessID">�^�[�Q�b�g�v���Z�XID</param>
		/// <remarks>
		/// Note       : �����w��������܂ŃA�v���P�[�V������ҋ@�����܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public void SleepUpToFormReView(int targetProcessID)
		{
			int sleepTime = 50;//ms
			int status = -1;

			#region //�R���g���[���t�@�C���m�F

			// �R���g���[���A�v���P�[�V�����ɂ�����̃t�@�C�����쐬�����d�l	//
			// �t�@�C�������݂��邩�m�F��										//
			// �t�@�C�������݂��Ȃ��ꍇ�풓�ҋ@�����Ȃ�							//

			//�R���g���[���A�v���P�[�V��������J�n���ꂽ���Ɗm�F
			status = ControlFileStream.Reader(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.ProcessStart);

			if (status == 4)
			{
				//�풓�ҋ@�������s�Ȃ킸�����I��
				//�t�@�C����������Ȃ��ꍇ�A���[�v�I��
				return;
			}
			else if (status == 0 || status == 999 || status == 800)
			{
				//�풓�ҋ@�������s���������s
				//�Ǎ������񂪌��������ꍇ�A���[�v�I���������s
				//�Ǎ������񂪌�����Ȃ��ꍇ�A���[�v�I���������s
				//�ʃX���b�h�ւ̃A�N�Z�X�����̏ꍇ�A���[�v�I���������s
			}
			else
			{
				//��O
				return;
			}

			#endregion

			#region //�R���g���[���t�@�C��������

            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            string filename = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\"
                             + ApplicationController.TARGET_PGID + "_" + targetProcessID;
            if (System.IO.File.Exists(filename))
            {
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
                // �R���g���[���A�v���P�[�V�����֏풓�ҋ@���ł��邱�Ƃ�ʒm	//
                status = ControlFileStream.Writer(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.InitializeEnd);
                if (status == 810) return;//�^�C���A�E�g�̏ꍇ�I��������
            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            }
            else
            {
                return;  //�t�@�C�������݂��Ȃ��ꍇ�I��
            }
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
            
			#endregion

			#region //�R���g���[���t�@�C���Ǎ�

			// �R���g���[���A�v���P�[�V�����ɂ�����̃t�@�C�����X�V�����d�l	//
			// ���Ԋu�Ńt�@�C���A�N�Z�X���s��									//
			// �t�@�C�����X�V����Ă���ꍇ�풓�ҋ@���甲����					//
			// �풓�ҋ@���甲����Ɖ�ʂ͕����\�������							//

			do
			{
				//�R���g���[���A�v���P�[�V�������畜���\���w���m�F
				status = ControlFileStream.Reader(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.ReViewForm);

				if (status == 0)
				{
					//�R���g���[���A�v���P�[�V�������畜���\���w��������
					//�Ǎ������񂪌��������ꍇ�A���[�v�I��
					break;
				}
				else if (status == 999 || status == 800)
				{
					//�Ǎ������񂪌�����Ȃ��ꍇ�A�X���[�v������
					//�ʃX���b�h�ւ̃A�N�Z�X�����̏ꍇ�A�X���[�v������
					Thread.Sleep(sleepTime);
				}
				else if (status == 4)
				{
					//�t�@�C����������Ȃ��ꍇ�A���[�v�I��
					return;
				}
				else
				{
					//��O
					return;
				}

				// ���[�v�������ɂ��C�x���g�𗬂�				//
				// ���O�I�t�����������悤�ɂ��邽�߂̑Ή�		//
				System.Windows.Forms.Application.DoEvents();

			} while (true);

			#endregion

			return;
		}

		/// <summary>
		/// �A�v���P�[�V�����ݒ�I���ʒm����
		/// </summary>
		/// <param name="targetProcessID">�^�[�Q�b�g�v���Z�XID</param>
		/// <remarks>
		/// Note       : �A�v���P�[�V�����������w����A�����ݒ肪�I���������Ƃ�ʒm���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public void ReViewForm(int targetProcessID)
		{
			#region //�R���g���[���t�@�C��������

            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            string filename = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" 
                             + ApplicationController.TARGET_PGID + "_" + targetProcessID;
            if (System.IO.File.Exists(filename))
            {
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
                // �R���g���[���A�v���P�[�V�����֕\�����������ł��邱�Ƃ�ʒm	//
                ControlFileStream.Writer(ApplicationController.TARGET_PGID, targetProcessID, ControlFileStream.ControlText.SettingEnd);
            // --- ADD 2012/09/12 T.Nishi ---------->>>>>
            }
            // --- ADD 2012/09/12 T.Nishi ----------<<<<<
            #endregion
		}

		#endregion
	}
}
