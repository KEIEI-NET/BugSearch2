using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ��ʗp���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2008.04.30</br>
    /// <br>UpdateNote : 2011/08/04 caohh</br>
    /// <br>             NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
	/// </remarks>
	[Serializable]
	public class CustomerInputConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private int _inputTypeValue;
		private int _firstDisplayTabValue;
        private int _keepOnInfoSettingValue;  // ADD caohh 2011/08/04

		private const int DEFAULT_INPUTTYPE_VALUE = 0;
		private const int DEFAULT_FIRSTDISPLAYTAB_VALUE = 0;
        private const int DEFAULT_KEEPONINFOSETTING_VALUE = 0;// ADD caohh 2011/08/04
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ���Ӑ��ʗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
		public CustomerInputConstruction()
		{
			this._inputTypeValue = DEFAULT_INPUTTYPE_VALUE;
			this._firstDisplayTabValue = DEFAULT_FIRSTDISPLAYTAB_VALUE;
            this._keepOnInfoSettingValue = DEFAULT_KEEPONINFOSETTING_VALUE;   // ADD caohh 2011/08/04
		}

		/// <summary>
		/// ���Ӑ��ʗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
        //public CustomerInputConstruction(int inputTypeValue, int firstDisplayTabValue)// DEL caohh 2011/08/04
        public CustomerInputConstruction(int inputTypeValue, int firstDisplayTabValue, int keepOnInfoSettingValue)  // ADD caohh 2011/08/04
		{
			this._inputTypeValue = inputTypeValue;
			this._firstDisplayTabValue = firstDisplayTabValue;
            this._keepOnInfoSettingValue = keepOnInfoSettingValue; // ADD caohh 2011/08/04
		}
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>���͕��@�ݒ�l�v���p�e�B</summary>
		public int InputTypeValue
		{
			get{ return this._inputTypeValue; }
			set{ this._inputTypeValue = value; }
		}

		/// <summary>�����\���^�u�v���p�e�B</summary>
		public int FirstDisplayTabValue
		{
			get { return this._firstDisplayTabValue; }
			set { this._firstDisplayTabValue = value; }
		}

        // --- ADD caohh 2011/08/02 ------------------------------------------------------>>>>>
        /// <summary>�O����ێ��ݒ�v���p�e�B</summary>
        public int KeepOnInfoSettingValue
        {
            get { return this._keepOnInfoSettingValue; }
            set { this._keepOnInfoSettingValue = value; }
        }
        // --- ADD caohh 2011/08/02 ------------------------------------------------------<<<<<
		# endregion

		/// <summary>
		/// ���Ӑ��ʗp���[�U�[�ݒ�N���X��������
		/// </summary>
		/// <returns>���Ӑ��ʗp���[�U�[�ݒ�N���X</returns>
		public CustomerInputConstruction Clone()
		{
            //return new CustomerInputConstruction(this._inputTypeValue, this._firstDisplayTabValue);// DEL caohh 2011/08/04
            return new CustomerInputConstruction(this._inputTypeValue, this._firstDisplayTabValue, this._keepOnInfoSettingValue);// ADD caohh 2011/08/04
		}
	}

	/// <summary>
	/// ���Ӑ��ʗp���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2008.04.30</br>
    /// <br>UpdateNote : 2011/08/04 caohh</br>
    /// <br>             NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
	/// </remarks>
	public class CustomerInputConstructionAcs
	{
		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region Public Const
		/// <summary>���̓^�C�v�i�����j</summary>
		public const int INPUT_TYPE_AUTO   = 0;

		/// <summary>���̓^�C�v�i�^�u�Œ�j</summary>
		public const int INPUT_TYPE_TAB    = 1;

		/// <summary>���̓^�C�v�i�X�N���[���Œ�j</summary>
		public const int INPUT_TYPE_SCROLL = 2;

        /// <summary>�����\���^�u�E�f�t�H���g�i0:�A����j</summary>
        public const int FIRST_DISPLAY_TAB_DEFAULT = 0;

        // --- ADD caohh 2011/08/02 ------------------------------------------------------>>>>>
        /// <summary>�O����ێ��ݒ�E�f�t�H���g�i0:���Ӑ�R�[�h�ȊO��ێ��j</summary>
        public const int KEEPONINFOSETTING_DEFAULT = 0;
        // --- ADD caohh 2011/08/02 ------------------------------------------------------<<<<<
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private static CustomerInputConstruction _customerInputConstruction;
		private const string XML_FILE_NAME = "PMKHN09000U_Construction.XML";
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ���Ӑ��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
		public CustomerInputConstructionAcs()
		{
			if (_customerInputConstruction == null)
			{
				_customerInputConstruction = new CustomerInputConstruction();
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
		public int InputType
		{
			get
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new CustomerInputConstruction();
				}
				return _customerInputConstruction.InputTypeValue;
			}
			set
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new CustomerInputConstruction();
				}
				_customerInputConstruction.InputTypeValue = value;
			}
		}

		/// <summary>�����\���^�u�ݒ�l�v���p�e�B</summary>
		public int FirstDisplayTab
		{
			get
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new CustomerInputConstruction();
				}
				return _customerInputConstruction.FirstDisplayTabValue;
			}
			set
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new CustomerInputConstruction();
				}
				_customerInputConstruction.FirstDisplayTabValue = value;
			}
		}

        // --- ADD caohh 2011/08/02 ------------------------------------------------------>>>>>
        /// <summary>�O����ێ��ݒ�v���p�e�B</summary>
        public int KeepOnInfoSetting
        {
            get
            {
                if (_customerInputConstruction == null)
                {
                    _customerInputConstruction = new CustomerInputConstruction();
                }
                return _customerInputConstruction.KeepOnInfoSettingValue;
            }
            set
            {
                if (_customerInputConstruction == null)
                {
                    _customerInputConstruction = new CustomerInputConstruction();
                }
                _customerInputConstruction.KeepOnInfoSettingValue = value;
            }
        }
        // --- ADD caohh 2011/08/02 ------------------------------------------------------<<<<<
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// ���Ӑ��ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ��ʗp���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
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
		/// ���Ӑ��ʗp���[�U�[�ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ��ʗp���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				_customerInputConstruction = UserSettingController.DeserializeUserSetting<CustomerInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
			}
		}
		# endregion
	}
}
