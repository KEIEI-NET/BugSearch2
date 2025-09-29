using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>�{�^���X�e�[�^�X�ύX�C�x���g�p�f���Q�[�g</summary>
	internal delegate void PanelChangeEventHandler(object sender, PanelChangeEventArgs e);

	/// <summary>�����`���[�N���C�x���g�p�f���Q�[�g</summary>
	internal delegate void LuncherStartEventHandler(object sender, LuncherStartEventArgs e);

	/// <summary>
	/// �p�l���ύX�C�x���g�p�����[�^�N���X
	/// </summary>
	internal class PanelChangeEventArgs : EventArgs
	{
		internal const int MODE_UPDATE = 0;
		internal const int MODE_NON_UPDATE = 1;

		int _recodeUpdateMode = 0;
		int _dispNo = 0;

		/// <summary>
		/// �p�l���ύX�C�x���g�p�����[�^�N���X �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PanelChangeEventArgs()
		{
			// 
		}

		/// <summary>
		/// �p�l���ύX�C�x���g�p�����[�^�N���X �R���X�g���N�^
		/// </summary>
		/// <param name="recodeUpdateMode">��ʑJ�ڗ����X�V���[�h</param>
		/// <param name="dispNo">�\����ʔԍ�</param>
		public PanelChangeEventArgs(int recodeUpdateMode, int dispNo) : this()
		{
			this._recodeUpdateMode = recodeUpdateMode;
			this._dispNo = dispNo;
		}

		/// <summary>
		/// ��ʑJ�ڗ����X�V���[�h�v���p�e�B
		/// </summary>
		public int RecodeUpdateMode
		{
			get
			{
				return this._recodeUpdateMode;
			}
			set
			{
				this._recodeUpdateMode = value;
			}
		}

		/// <summary>
		/// �\����ʔԍ��v���p�e�B
		/// </summary>
		public int DispNo
		{
			get
			{
				return this._dispNo;
			}
			set
			{
				this._dispNo = value;
			}
		}
	}

	/// <summary>
	/// �����`���[�N���C�x���g�p�����[�^�N���X
	/// </summary>
	internal class LuncherStartEventArgs : EventArgs
	{
		LuncherStartAssemblyInfo _luncherStartAssemblyInfo = new LuncherStartAssemblyInfo();
		int _dispNo = 0;

		/// <summary>
		/// �����`���[�N���C�x���g�p�����[�^�N���X �f�t�H���g�R���X�g���N�^
		/// </summary>
		public LuncherStartEventArgs()
		{
			// 
		}

		/// <summary>
		/// �����`���[�N���C�x���g�p�����[�^�N���X �R���X�g���N�^
		/// </summary>
		/// <param name="luncherStartAssemblyInfo">�����`���[�X�^�[�g�A�Z���u�����N���X</param>
		/// <param name="dispNo">�\����ʔԍ�</param>
		public LuncherStartEventArgs(LuncherStartAssemblyInfo luncherStartAssemblyInfo, int dispNo) : this()
		{
			this._luncherStartAssemblyInfo = luncherStartAssemblyInfo;
			this._dispNo = dispNo;
		}

		/// <summary>
		/// �����`���[�X�^�[�g�A�Z���u�����N���X�v���p�e�B
		/// </summary>
		public LuncherStartAssemblyInfo LuncherStartAssemblyInfoData
		{
			get
			{
				return this._luncherStartAssemblyInfo;
			}
			set
			{
				this._luncherStartAssemblyInfo = value;
			}
		}

		/// <summary>
		/// �\����ʔԍ��v���p�e�B
		/// </summary>
		public int DispNo
		{
			get
			{
				return this._dispNo;
			}
			set
			{
				this._dispNo = value;
			}
		}
	}
}
