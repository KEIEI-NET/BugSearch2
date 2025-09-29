using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �ύXPG�ē��G���[��O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ύXPG�ē��̃y�[�W���ŃG���[�����������ꍇ�ɔ������܂��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2007.03.28</br>
	/// </remarks>
	public class NSChangeInfoErrorException : Exception
	{
		#region << Constructor >>

		/// <summary>
		/// �ύXPG�ē��G���[��O�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ύXPG�ē��G���[��O�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException() : this( -1, "", null )
		{
		}

		/// <summary>
		/// �ύXPG�ē��G���[��O�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="message">��O�̌������������G���[ ���b�Z�[�W�B</param>
		/// <remarks>
		/// <br>Note       : �ύXPG�ē��G���[��O�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( string message ) : this( -1, message, null )
		{
		}

		/// <summary>
		/// �ύXPG�ē��G���[��O�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="message">��O�̌������������G���[ ���b�Z�[�W�B</param>
		/// <remarks>
		/// <br>Note       : �ύXPG�ē��G���[��O�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( int status, string message ) : this( status, message, null )
		{
		}

		/// <summary>
		/// �ύXPG�ē��G���[��O�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="message">��O�̌������������G���[ ���b�Z�[�W�B</param>
		/// <param name="innerException">���݂̗�O�̌����ł����O�B������O���w�肳��Ă��Ȃ��ꍇ�� null �Q�ƁB</param>
		/// <remarks>
		/// <br>Note       : �ύXPG�ē��G���[��O�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( string message, Exception innerException ) : this( -1, message, innerException )
		{
		}

		/// <summary>
		/// �ύXPG�ē��G���[��O�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="message">��O�̌������������G���[ ���b�Z�[�W�B</param>
		/// <param name="innerException">���݂̗�O�̌����ł����O�B������O���w�肳��Ă��Ȃ��ꍇ�� null �Q�ƁB</param>
		/// <remarks>
		/// <br>Note       : �ύXPG�ē��G���[��O�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( int status, string message, Exception innerException ) : base( message, innerException )
		{
			this._status = status;
		}

		#endregion



		#region << Private Members >>

		/// <summary>�X�e�[�^�X</summary>
		private int _status = -1;

		#endregion



		#region << Public Properties >>

		/// <summary>
		/// �X�e�[�^�X
		/// </summary>
		public int Status
		{
			get {
				return this._status;
			}
		}

		#endregion

    }
}
