using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����`�[�����p�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����`�[�����̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2007.01.11</br>
	/// <br></br>
	/// </remarks>
	public class SalesSearchConstructionAcs
	{
		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region Public Const
		/// <summary>�ڍ׏����\���i����j</summary>
		public const int DetailConditionOpen_ON = 0;

		/// <summary>�ڍ׏����\���i���Ȃ��j</summary>
		public const int DetailConditionOpen_OFF = 1;

		/// <summary>���o�����ύX�����������i����j</summary>
		public const int DataChangedAutoSearch_ON = 0;

		/// <summary>���o�����ύX�����������i���Ȃ��j</summary>
		public const int DataChangedAutoSearch_OFF = 1;

		/// <summary>�N�������������i����j</summary>
		public const int ExecAutoSearch_ON = 0;

		/// <summary>�N�������������i���Ȃ��j</summary>
		public const int ExecAutoSearch_OFF = 1;

		/// <summary>�`�[���t�͈͎w��i�Ȃ��j</summary>
		public const int SearchSlipDateStartRange_None = 0;

		/// <summary>�`�[���t�͈͎w��i�{���j</summary>
		public const int SearchSlipDateStartRange_Today = 1;

		/// <summary>�`�[���t�͈͎w��i�P�T�ԁj</summary>
		public const int SearchSlipDateStartRange_Week = 2;

		/// <summary>�`�[���t�͈͎w��i�P�����j</summary>
		public const int SearchSlipDateStartRange_Month = 3;

		/// <summary>�v����͈͎w��i�Ȃ��j</summary>
		public const int AddUpADateStartRange_None = 0;

		/// <summary>�v����͈͎w��i�{���j</summary>
		public const int AddUpADateStartRange_Today = 1;

		/// <summary>�v����͈͎w��i�P�T�ԁj</summary>
		public const int AddUpADateStartRange_Week = 2;

		/// <summary>�v����͈͎w��i�P�����j</summary>
		public const int AddUpADateStartRange_Month = 3;

		/// <summary>���W�������͈͎w��i�Ȃ��j</summary>
		public const int RegiProcDateStartRange_None = 0;

		/// <summary>���W�������͈͎w��i�{���j</summary>
		public const int RegiProcDateStartRange_Today = 1;

		/// <summary>���W�������͈͎w��i�P�T�ԁj</summary>
		public const int RegiProcDateStartRange_Week = 2;

		/// <summary>���W�������͈͎w��i�P�����j</summary>
		public const int RegiProcDateStartRange_Month = 3;
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private SalesSearchConstruction _salesSearchConstruction;
		private static SalesSearchConstructionAcs _salesSearchConstructionAcs;
		private const string XML_FILE_NAME = "MAHNB04110U_Construction.XML";
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private SalesSearchConstructionAcs()
		{
			_salesSearchConstruction = new SalesSearchConstruction();
			this.Deserialize();
		}

		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns>����`�[�����p���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
		public static SalesSearchConstructionAcs GetInstance()
		{
			if (_salesSearchConstructionAcs == null)
			{
				_salesSearchConstructionAcs = new SalesSearchConstructionAcs();
			}

			return _salesSearchConstructionAcs;
		}
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		/// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
		public event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X
		/// </summary>
		public SalesSearchConstruction StockInputConstruction
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.Clone();
			}
		}

		/// <summary>�`�[���t�͈͎w��</summary>
		public int SearchSlipDateStartRangeValue
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.SearchSlipDateStartRange;
			}
			set
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				_salesSearchConstruction.SearchSlipDateStartRange = value;
			}
		}

		/// <summary>�v����͈͎w��</summary>
		public int AddUpADateStartRangeValue
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.AddUpADateStartRangeValue;
			}
			set
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				_salesSearchConstruction.AddUpADateStartRangeValue = value;
			}
		}

		/// <summary>���W�������͈͎w��</summary>
		public int RegiProcDateStartRangeValue
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.RegiProcDateStartRangeValue;
			}
			set
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				_salesSearchConstruction.RegiProcDateStartRangeValue = value;
			}
		}

		/// <summary>�ڍ׏����\��</summary>
		public int DetailConditionOpenValue
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.DetailConditionOpenValue;
			}
			set
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				_salesSearchConstruction.DetailConditionOpenValue = value;
			}
		}

		/// <summary>���o�����ύX����������</summary>
		public int DataChangedAutoSearchValue
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.DataChangedAutoSearchValue;
			}
			set
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				_salesSearchConstruction.DataChangedAutoSearchValue = value;
			}
		}

		/// <summary>�t�������͎����N��</summary>
		public int ExecAutoSearchValue
		{
			get
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				return _salesSearchConstruction.ExecAutoSearchValue;
			}
			set
			{
				if (_salesSearchConstruction == null)
				{
					_salesSearchConstruction = new SalesSearchConstruction();
				}
				_salesSearchConstruction.ExecAutoSearchValue = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����`�[�����p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2007.01.11</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_salesSearchConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// �f�[�^�ύX�㔭���C�x���g���s
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����`�[�����p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				_salesSearchConstruction = UserSettingController.DeserializeUserSetting<SalesSearchConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
			}
		}
		# endregion
	}
}
