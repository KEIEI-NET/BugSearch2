using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����t�@�C���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// Note       : ����t�@�C���ɃA�N�Z�X���邽�߂̃N���X�ł��B<br />
	/// Programmer : 30182 R.Tachiya<br />
	/// Date       : 2012.06.18<br />
	/// Update Note: 2012.07.06 30182 ���J ���� R.Tachiya<br />
	///            :  �����N���풓���Ή��̒ǉ��C���A�]�ƈ����O�C���m�F�̎����B<br />
    /// Update Note: 2012/11/15 20073 �� �B T.Nishi<br />
    ///            : ���O�I�t���ɔ��`�̍ċN�����s�����Ƃ����Q�̏C��<br />
    /// Update Note: 2013/05/23 �{�{ ����<br />
    ///            : �@����`�[���͂ł̍ŐV���擾���Ƀo�b�N�O���E���h�̃v���Z�X���ċN������<br />
    /// </remarks>
	internal class ControlFileStream
	{
		#region // -- Private Members --

		/// <summary>
		/// ���b�N�I�u�W�F�N�g
		/// </summary>
		/// <remarks>�r�����b�N�I�u�W�F�N�g�B</remarks>
		private static object _filelock = new object();

		#endregion

		#region // -- Public Methods --

		/// <summary>
		/// �����ݏ���
		/// </summary>
		/// <param name="writeFileName">�t�@�C������</param>
		/// <param name="writeId">�v���Z�XID</param>
		/// <param name="controlText">���䕶����</param>
		/// <returns>0:����I���A810:TimeOut</returns>
		/// <remarks>
		/// Note       : ����t�@�C���ɏ����݂��s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static int Writer(string writeFileName, int writeId, ControlText controlText)
		{
			string strId = writeId.ToString();
			string fileName = writeFileName + "_";

			lock (ControlFileStream._filelock)
			{
				int outTime = 60 * 1000;//ms
				int sleepTime = 50;//ms
				int maxLoopCount = outTime / sleepTime;//��

				for (int count = 0; count < maxLoopCount; count++)
				{
					//�t�@�C��������
					StreamWriter sw = null;

					try
					{
						sw = new StreamWriter(
                            System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
							false,
							Encoding.GetEncoding("Shift_JIS")
						);

						sw.Write(controlText.ToString());

						//����I��
						return 0;
					}
					catch (IOException)
					{
						//�ʃX���b�h�ւ̃A�N�Z�X�����ŃG�N�Z�v�V����������
						//����̎��ԃX���[�v�����A������x�������݂���
						Thread.Sleep(sleepTime);
					}
					finally
					{
						if (sw != null)
							sw.Close();
					}
				}
			}

			//TimeOut
			return 810;
		}

		// -- Add Ed 2012.07.06 30182 R.Tachiya --
		/// <summary>
		/// �]�ƈ��R�[�h�t�@�C�������ݏ���
		/// </summary>
		/// <param name="writeFileName">�t�@�C������</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>0:����I���A810:TimeOut</returns>
		/// <remarks>
		/// Note       : �]�ƈ��R�[�h�t�@�C���ɏ����݂��s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.07.06<br />
		/// </remarks>
		public static int EmployeeWriter(string writeFileName, string employeeCode)
		{
			string strId = "0";//Id��0�̏ꍇ�͏]�ƈ��R�[�h�t�@�C���ƂȂ�
			string fileName = writeFileName + "_";

			lock (ControlFileStream._filelock)
			{
				int outTime = 60 * 1000;//ms
				int sleepTime = 50;//ms
				int maxLoopCount = outTime / sleepTime;//��

				for (int count = 0; count < maxLoopCount; count++)
				{
					//�t�@�C��������
					StreamWriter sw = null;

					try
					{
						sw = new StreamWriter(
							System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
							false,
							Encoding.GetEncoding("Shift_JIS")
						);

						sw.Write(employeeCode);

						//����I��
						return 0;
					}
					catch (IOException)
					{
						//�ʃX���b�h�ւ̃A�N�Z�X�����ŃG�N�Z�v�V����������
						//����̎��ԃX���[�v�����A������x�������݂���
						Thread.Sleep(sleepTime);
					}
					finally
					{
						if (sw != null)
							sw.Close();
					}
				}
			}

			//TimeOut
			return 810;
		}
		// -- Add Ed 2012.07.06 30182 R.Tachiya --

		/// <summary>
		/// �Ǎ��ݏ���
		/// </summary>
		/// <param name="readFileName">�t�@�C������</param>
		/// <param name="readId">�v���Z�XID</param>
		/// <param name="controlText">���䕶����</param>
		/// <returns>0:�ΏۓǍ�-�Ǎ���������A999:�ΏۓǍ�-�Ǎ������Ȃ��A4:�Ώۃt�@�C���Ȃ��A800:�ʃX���b�h�ւ̃A�N�Z�X����</returns>
		/// <remarks>
		/// Note       : ����t�@�C���ɓǍ��݂��s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static int Reader(string readFileName, int readId, ControlText controlText)
		{
			string strId = readId.ToString();
			string fileName = readFileName + "_";

			lock (ControlFileStream._filelock)
			{
				//�t�@�C���Ǎ�
				StreamReader sr = null;

				try
				{
					sr = new StreamReader(
                        System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
						Encoding.GetEncoding("Shift_JIS")
						);

					string text = sr.ReadToEnd();

					//�R���g���[���Ώۂ̏��������I��������Ƃ��m�F
					if (text.Contains(controlText.ToString()))
					{
						//�ΏۓǍ�-�Ǎ���������
						return 0;
					}
					else
					{
						//�ΏۓǍ�-�Ǎ������Ȃ�
						return 999;
					}
				}
				catch (FileNotFoundException)
				{
					//�Ώۃt�@�C���Ȃ�
					return 4;
				}
				catch (IOException)
				{
					//�ʃX���b�h�ւ̃A�N�Z�X����
					return 800;
				}
				finally
				{
					if (sr != null)
						sr.Close();
				}
			}
		}

		// -- Add St 2012.07.06 30182 R.Tachiya --
		/// <summary>
		/// �]�ƈ��R�[�h�t�@�C���Ǎ��ݏ���
		/// </summary>
		/// <param name="readFileName">�t�@�C������</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>0:�ΏۓǍ�-�Ǎ���������A999:�ΏۓǍ�-�Ǎ������Ȃ��A4:�Ώۃt�@�C���Ȃ��A800:�ʃX���b�h�ւ̃A�N�Z�X����</returns>
		/// <remarks>
		/// Note       : �]�ƈ��R�[�h�t�@�C���ɓǍ��݂��s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.07.06<br />
		/// </remarks>
		public static int EmployeeReader(string readFileName, out string employeeCode)
		{
			string strId = "0";//Id��0�̏ꍇ�͏]�ƈ��R�[�h�t�@�C���ƂȂ�
			string fileName = readFileName + "_";
			employeeCode = "";

			lock (ControlFileStream._filelock)
			{
				//�t�@�C���Ǎ�
				StreamReader sr = null;

				try
				{
					sr = new StreamReader(
						System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId,
						Encoding.GetEncoding("Shift_JIS")
						);

					//string Text = sr.ReadToEnd();
					employeeCode = sr.ReadToEnd();

					//�R���g���[���Ώۂ̏��������I��������Ƃ��m�F
					if (employeeCode.Trim() != "")
					{
						//�ΏۓǍ�-�Ǎ���������
						return 0;
					}
					else
					{
						//�ΏۓǍ�-�Ǎ������Ȃ�
						return 999;
					}
				}
				catch (FileNotFoundException)
				{
					//�Ώۃt�@�C���Ȃ�
					return 4;
				}
				catch (IOException)
				{
					//�ʃX���b�h�ւ̃A�N�Z�X����
					return 800;
				}
				finally
				{
					if (sr != null)
						sr.Close();
				}
			}
		}
		// -- Add Ed 2012.07.06 30182 R.Tachiya --

		/// <summary>
		/// �폜����
		/// </summary>
		/// <param name="deleteFileName">�t�@�C������</param>
		/// <param name="deleteId">�v���Z�XID ��0:�]�ƈ��R�[�h�t�@�C��</param>
		/// <returns>0:����I��</returns>
		/// <remarks>
		/// Note       : ����t�@�C���̍폜���s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static int Deleter(string deleteFileName, int deleteId)
		{
			string strId = deleteId.ToString();
			string fileName = deleteFileName + "_";

            lock (ControlFileStream._filelock)
			{
                File.Delete(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId);
			}

			return 0;
		}

		// -- Add St 2012.07.06 30182 R.Tachiya --
		/// <summary>
		/// �]�ƈ��R�[�h�t�@�C���폜����
		/// </summary>
		/// <param name="deleteFileName">�t�@�C������</param>
		/// <remarks>
		/// Note       : �]�ƈ��R�[�h�t�@�C���̍폜���s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.07.06<br />
		/// </remarks>
		public static void EmployeeDeleter(string deleteFileName)
		{
			//Id��0�̏ꍇ�͏]�ƈ��R�[�h�t�@�C���ƂȂ�
			ControlFileStream.Deleter(deleteFileName, 0);
			return;
		}
		// -- Add Ed 2012.07.06 30182 R.Tachiya --

		/// <summary>
		/// �m�F����
		/// </summary>
		/// <param name="checkFileName">�t�@�C������</param>
		/// <param name="checkId">�v���Z�XID</param>
		/// <returns>�t�@�C������:ture�A�t�@�C�������E�ُ�:false</returns>
		/// <remarks>
		/// Note       : ����t�@�C���̊m�F���s���܂��B<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static bool Checker(string checkFileName, int checkId)
		{
			string strId = checkId.ToString();
			string fileName = checkFileName + "_";

			lock (ControlFileStream._filelock)
			{
                if (File.Exists(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp) + "\\" + fileName + strId))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		#endregion

		#region // -- Public Enum --

		/// <summary>
		/// �t�@�C�����䕶����
		/// </summary>
		public enum ControlText
		{
			ProcessStart = 0,	//�v���Z�X�J�n
			InitializeEnd = 1,	//�������I��
			ReViewForm = 2,		//�����w��
			SettingEnd = 3,		//�i�����j�ݒ�I��
            // --- ADD 2012/11/15 T.Nishi ---------->>>>>
            ProcessEnd = 4,		//�i�����j�ݒ�I��
            // --- ADD 2012/11/15 T.Nishi ----------<<<<<
            // --- ADD 2013/05/23 �@ T.Miyamoto ---------->>>>>
            Reboot = 5,		    //�ċN��
            // --- ADD 2013/05/23 �@ T.Miyamoto ----------<<<<<
		}

		#endregion
	}
}
