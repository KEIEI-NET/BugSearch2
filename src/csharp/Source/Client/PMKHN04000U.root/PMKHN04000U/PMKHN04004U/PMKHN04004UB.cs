using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ挟���p���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挟���p�̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2006.08.24</br>
	/// <br></br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
    /// <br>             MANTIS:14678 ���������C�����I���̏����l�ݒ���\�Ƃ���</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	[Serializable]
	public class CustomerSearchConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private int _firstDisplayDetailsValue;
		private int _stringSearchInitialTypeValue;

        // 2009/12/02 Add >>>
        private int _autoSearchValue;
        private int _multiSelectValue;
        // 2009/12/02 Add <<<

		private const int DEFAULT_FIRSTDISPLAYDETAILS_VALUE = 2;
		private const int DEFAULT_STRINGSEARCHINITIALTYPE_VALUE = 0;

        // 2009/12/02 Add >>>
        private const int DEFAULT_AUTOSEARCH_VALUE = 0;
        private const int DEFAULT_MULTISELECT_VALUE = 1;
        // 2009/12/02 Add <<<
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
		public CustomerSearchConstruction()
		{
			this._firstDisplayDetailsValue = DEFAULT_FIRSTDISPLAYDETAILS_VALUE;
			this._stringSearchInitialTypeValue = DEFAULT_STRINGSEARCHINITIALTYPE_VALUE;
            // 2009/12/02 Add >>>
            this._autoSearchValue = DEFAULT_AUTOSEARCH_VALUE;
            this._multiSelectValue = DEFAULT_MULTISELECT_VALUE;
            // 2009/12/02 Add <<<
        }

		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X
		/// </summary>
		/// <param name="stringSearchInitialTypeValue">�ڍו\�������ݒ�l</param>
        /// <param name="firstDisplayDetailsValue">�����񌟍����@�����l</param>
        /// <param name="autoSearchValue">�������������l</param>
        /// <param name="multiSelectValue">�����I����@�����l</param>
        /// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
        // 2009/12/02 >>>
        //public CustomerSearchConstruction(int firstDisplayDetailsValue, int stringSearchInitialTypeValue)
        public CustomerSearchConstruction(int firstDisplayDetailsValue, int stringSearchInitialTypeValue, int autoSearchValue, int multiSelectValue)
        // 2009/12/02 <<<
        {
			this._firstDisplayDetailsValue = firstDisplayDetailsValue;
			this._stringSearchInitialTypeValue = stringSearchInitialTypeValue;

            // 2009/12/02 Add >>>
            this._autoSearchValue = autoSearchValue;
            this._multiSelectValue = multiSelectValue;
            // 2009/12/02 Add <<<
		}
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>�ڍו\�������ݒ�v���p�e�B</summary>
		public int FirstDisplayDetailsValue
		{
			get { return this._firstDisplayDetailsValue; }
			set { this._firstDisplayDetailsValue = value; }
		}

		/// <summary>�����񌟍����@�����l�v���p�e�B</summary>
		public int stringSearchInitialTypeValue
		{
			get { return this._stringSearchInitialTypeValue; }
			set { this._stringSearchInitialTypeValue = value; }
		}

        // 2009/12/02 Add >>>
        /// <summary>�������������l�v���p�e�B</summary>
        public int autoSearchValue
        {
            get { return this._autoSearchValue; }
            set { this._autoSearchValue = value; }
        }

        /// <summary>�����I�������l�v���p�e�B</summary>
        public int multiSelectValue
        {
            get { return this._multiSelectValue; }
            set { this._multiSelectValue = value; }
        }
        // 2009/12/02 Add <<<

		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X��������
		/// </summary>
		/// <returns>���Ӑ挟���p���[�U�[�ݒ�N���X</returns>
		public CustomerSearchConstruction Clone()
		{
            // 2009/12/02 >>>
            //return new CustomerSearchConstruction(this._firstDisplayDetailsValue, this._stringSearchInitialTypeValue);
            return new CustomerSearchConstruction(this._firstDisplayDetailsValue, this._stringSearchInitialTypeValue, this._autoSearchValue, this._multiSelectValue);
            // 2009/12/02 <<<
        }

		# endregion
	}

	/// <summary>
	/// ���Ӑ挟���p���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挟���̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2006.08.24</br>
	/// <br>Update Note: </br>
	/// <br>2006.11.27 men �R���X�g���N�^�ɂ�XML�̃p�X���擾����悤�ɉ��ǁi�݌ɕ��i�Ή��j</br>
	/// </remarks>
	public class CustomerSearchConstructionAcs
	{
		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region Public Const
		/// <summary>�ڍו\�������ݒ�i���o���ʃE�B���h�E���ŕ\������j</summary>
		public static readonly int FIRST_DISPLAY_DETAILS_0 = 0;

		/// <summary>�ڍו\�������ݒ�i�ʃE�B���h�E�ŕ\�������j</summary>
		public static readonly int FIRST_DISPLAY_DETAILS_1 = 1;

		/// <summary>�ڍו\�������ݒ�i�\�����Ȃ��j</summary>
		public static readonly int FIRST_DISPLAY_DETAILS_2 = 2;

		/// <summary>�����񌟍����@�����l�i�擪��v�����j</summary>
		public static readonly int STRING_SEARCH_INITIAL_TYPE_0 = 0;

		/// <summary>�����񌟍����@�����l�i�B�������j</summary>
		public static readonly int STRING_SEARCH_INITIAL_TYPE_1 = 1;

        // 2009/12/02 Add >>>
        /// <summary>�������������l�i�L��j</summary>
        public static readonly int AUTO_SEARCH_0 = 0;

        /// <summary>�������������l�i�����j</summary>
        public static readonly int AUTO_SEARCH_1 = 1;

        /// <summary>�����I�������l�i�L��j</summary>
        public static readonly int MULTI_SEARCH_0 = 0;

        /// <summary>�����I�������l�i�����j</summary>
        public static readonly int MULTI_SEARCH_1 = 1;
        // 2009/12/02 Add <<<
        # endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private static CustomerSearchConstruction _customerSearchConstruction;
		private const string XML_FILE_NAME = "PMKHN04001U_Construction.XML";
		private string _xmlFileName = "";
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
		public CustomerSearchConstructionAcs()
		{
			this._xmlFileName = XML_FILE_NAME;
			if (_customerSearchConstruction == null)
			{
				_customerSearchConstruction = new CustomerSearchConstruction();
			}
			this.Deserialize();
		}

		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
		/// </summary>
		/// <param name="xmlFileName">XML�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
		public CustomerSearchConstructionAcs(string xmlFileName)
		{
			this._xmlFileName = xmlFileName;
			if (_customerSearchConstruction == null)
			{
				_customerSearchConstruction = new CustomerSearchConstruction();
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
		/// <summary>�ڍו\�������ݒ�l�v���p�e�B</summary>
		public int FirstDisplayDetails
		{
			get
			{
				if (_customerSearchConstruction == null)
				{
					_customerSearchConstruction = new CustomerSearchConstruction();
				}
				return _customerSearchConstruction.FirstDisplayDetailsValue;
			}
			set
			{
				if (_customerSearchConstruction == null)
				{
					_customerSearchConstruction = new CustomerSearchConstruction();
				}
				_customerSearchConstruction.FirstDisplayDetailsValue = value;
			}
		}

		/// <summary>�����񌟍����@�����l�v���p�e�B</summary>
		public int StringSearchInitialType
		{
			get
			{
				if (_customerSearchConstruction == null)
				{
					_customerSearchConstruction = new CustomerSearchConstruction();
				}
				return _customerSearchConstruction.stringSearchInitialTypeValue;
			}
			set
			{
				if (_customerSearchConstruction == null)
				{
					_customerSearchConstruction = new CustomerSearchConstruction();
				}
				_customerSearchConstruction.stringSearchInitialTypeValue = value;
			}
		}

        // 2009/12/02 Add >>>
        /// <summary>�������������l�v���p�e�B</summary>
        public int AutoSearch
        {
            get
            {
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerSearchConstruction();
                }
                return _customerSearchConstruction.autoSearchValue;
            }
            set
            {
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerSearchConstruction();
                }
                _customerSearchConstruction.autoSearchValue = value;
            }
        }

        /// <summary>�����I�������l�v���p�e�B</summary>
        public int MultiSelect
        {
            get
            {
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerSearchConstruction();
                }
                return _customerSearchConstruction.multiSelectValue;
            }
            set
            {
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerSearchConstruction();
                }
                _customerSearchConstruction.multiSelectValue = value;
            }
        }

        // 2009/12/02 Add <<<
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_customerSearchConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

			if (DataChanged != null)
			{
				// �f�[�^�ύX�㔭���C�x���g���s
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980079 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
			{
				_customerSearchConstruction = UserSettingController.DeserializeUserSetting<CustomerSearchConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
			}
		}
		# endregion
	}
}
