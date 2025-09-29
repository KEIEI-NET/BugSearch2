using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �I���R�[�h�ύX���C�x���g�p�����[�^�N���X
	/// </summary>
	public class CustomerSelectCodeChangeCtlEventArgs : EventArgs
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="code">�R�[�h�i���Ӑ�R�[�h�j</param>
		/// <param name="updateDateTime">�X�V��</param>
		public CustomerSelectCodeChangeCtlEventArgs(int code, DateTime updateDateTime)
		{
			this._code = code;
			this._updateDateTime = updateDateTime;
		}

		private int _code;
		private DateTime _updateDateTime;

		/// <summary>
		/// �R�[�h�v���p�e�B�i���Ӑ�R�[�h�j
		/// </summary>
		public int Code
		{
			get
			{
				return this._code;
			}
			set
			{
				this._code = value;
			}
		}

		/// <summary>
		/// �X�V����
		/// </summary>
		public DateTime UpdateDateTime
		{
			get
			{
				return this._updateDateTime;
			}
			set
			{
				this._updateDateTime = value;
			}
		}
	}

}
