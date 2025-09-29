using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɉړ����͉�ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2007.12.05</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class StockMoveInputInputConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private int _functionMode;

        private const int DEFAULT_FUNCTIONMODE_VALUE = 0;
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public StockMoveInputInputConstruction()
		{
            this._functionMode = DEFAULT_FUNCTIONMODE_VALUE;
		}

		/// <summary>
		/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public StockMoveInputInputConstruction(int functionMode)
		{
            this._functionMode = functionMode;
        }
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>�t�@���N�V�������[�h�v���p�e�B</summary>
		public int FunctionMode
		{
            get { return this._functionMode; }
            set { this._functionMode = value; }
		}
		# endregion

		/// <summary>
		/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X��������
		/// </summary>
		/// <returns>�݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X</returns>
		public StockMoveInputInputConstruction Clone()
		{
            return new StockMoveInputInputConstruction( this._functionMode );
		}
	}

	/// <summary>
	/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɉړ����͉�ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2004.04.19</br>
	/// <br></br>
	/// </remarks>
	public class StockMoveInputConstructionAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private static StockMoveInputInputConstruction _customerInputConstruction;
		private const string XML_FILE_NAME = "MAZAI04100U_Construction.XML";
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public StockMoveInputConstructionAcs()
		{
			if (_customerInputConstruction == null)
			{
				_customerInputConstruction = new StockMoveInputInputConstruction();
			}
			this.Deserialize();
		}
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		/// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
		public static event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>���͕��@�ݒ�l�v���p�e�B</summary>
        public int FunctionMode
		{
			get
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new StockMoveInputInputConstruction();
				}
				return _customerInputConstruction.FunctionMode;
			}
			set
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new StockMoveInputInputConstruction();
				}
                _customerInputConstruction.FunctionMode = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 980079 ��� ���b</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_customerInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// �f�[�^�ύX�㔭���C�x���g���s
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɉړ����͉�ʗp���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980079 ��� ���b</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				_customerInputConstruction = UserSettingController.DeserializeUserSetting<StockMoveInputInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
			}
		}
		# endregion
	}
}
