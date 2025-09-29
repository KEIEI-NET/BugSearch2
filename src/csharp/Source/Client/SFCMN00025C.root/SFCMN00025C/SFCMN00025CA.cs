using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �t���[�e�B���OWindow�N���X
	/// </summary>
	public class FloatingWindow
	{
		/// <summary>��ʃo�b�t�@</summary>
		private FloatingWindowF _floatingWindowF = null;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public FloatingWindow()
		{
		}

		/// <summary>
		/// �t���[�e�B���O��ʕ\��
		/// </summary>
		/// <param name="owner">�I�[�i�[���</param>
		public void Show(System.Windows.Forms.Form owner)
		{
			if (_floatingWindowF == null) _floatingWindowF = new FloatingWindowF();
			_floatingWindowF.Owner = owner;
			_floatingWindowF.Show();
			_floatingWindowF.Update();
		}

		/// <summary>
		/// �t���[�e�B���O��ʏI��
		/// </summary>
		public void Close()
		{
			if (_floatingWindowF != null)
			{
				_floatingWindowF.Close();
				_floatingWindowF.Dispose();
				_floatingWindowF = null;
			}
		}

	}
}
