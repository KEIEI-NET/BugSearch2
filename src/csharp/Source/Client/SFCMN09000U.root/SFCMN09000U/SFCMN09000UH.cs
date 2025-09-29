using System;
using System.IO;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �}�X�^�����e�i���X�t���[���p�}�X�^�����e�i���X�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �e�}�X�^�����e�i���X�ŗL�̐ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class MasterMaintenanceConstruction
	{
		# region Private Members
		private ExtractionSetUpType _extractionSetUpType;
		private int _searchCount;
		private string _classID;

		private const int DEFAULT_SEARCH_COUNT = 0; 
		# endregion

		# region Constructors
		/// <summary>
		/// �}�X�^�����e�i���X�ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public MasterMaintenanceConstruction(string classID)
		{
			this._classID = classID;
			this._extractionSetUpType = ExtractionSetUpType.SearchAuto;
			this._searchCount = DEFAULT_SEARCH_COUNT;
		}

		/// <summary>
		/// �}�X�^�����e�i���X�ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public MasterMaintenanceConstruction()
		{
			this._classID = "";
			this._extractionSetUpType = ExtractionSetUpType.SearchAuto;
			this._searchCount = DEFAULT_SEARCH_COUNT;
		}
		# endregion

		# region Properties
		/// <summary>���o�ݒ�l�v���p�e�B</summary>
		/// <value>���o�ݒ�l���擾�܂��͐ݒ肵�܂��B</value>
		public ExtractionSetUpType ExSetUpType
		{
			get{ return this._extractionSetUpType; }
			set{ this._extractionSetUpType = value; }
		}

		/// <summary>���o�Ώی����v���p�e�B</summary>
		/// <value>���o�Ώی������擾�܂��͐ݒ肵�܂��B</value>
		public int SearchCount
		{
			get{ return this._searchCount; }
			set{ this._searchCount = value; }
		}

		/// <summary>�N���X�h�c�v���p�e�B</summary>
		/// <value>�N���X�h�c���擾�܂��͐ݒ肵�܂��B</value>
		public string ClassID
		{
			get{ return this._classID; }
			set{ this._classID = value; }
		}
		# endregion

		# region Public Methods
		/// <summary>
		/// ToString�̃I�[�o�[���C�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : �N���X�h�c��Ԃ��܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public override string ToString()
		{
			return this._classID;
		}
		# endregion
	}

	# region enum ExtractionSetUpType
	/// <summary>���o���@�ݒ�̗񋓌^�ł��B</summary>
	public enum ExtractionSetUpType
	{
		/// <summary>�S���������o</summary>
		SearchAuto = 0,

		/// <summary>�����w�蒊�o</summary>
		SearchSpecification = 1,
	}
	# endregion
}
