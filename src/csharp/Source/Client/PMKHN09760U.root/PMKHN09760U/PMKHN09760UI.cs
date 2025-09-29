using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �}�X�^�����e�i���X�t���[���p�v���O�������Ǘ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �}�X�^�����e�i���X�t���[���ɂċN������v���O���������Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2014/12/23</br>
	/// <br></br>
	/// </remarks>
	internal class ProgramItem
	{
		# region Private Members
		private string _key = "";
		private string _assemblyID = "";
		private string _classID = "";
		private string _name = "";
		private string _arguments = "";
		private ProgramPattern _pattern;
		private ProgramCondition _condition;
		private Type _classType;
		private Object _object;
		private Form _customForm;
		private Form _viewForm;
		private MasterMaintenanceConstruction _construction;
		# endregion

		# region Constructor
		/// <summary>
		/// �v���O�������Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <param name="key">�L�[</param>
		/// <param name="assemblyId">�A�Z���u���h�c</param>
		/// <param name="classId">�N���X�h�c</param>
		/// <param name="name">����</param>
		/// <param name="pattern">�^�C�v</param>
		/// <param name="arguments">����</param>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		public ProgramItem(string key, string assemblyId, string classId, string name, ProgramPattern pattern, string arguments)
		{
			_key = key;
			_assemblyID = assemblyId;
			_classID = classId;
			_name = name;
			_pattern = pattern;
			_arguments = arguments;
			_condition = ProgramCondition.UnChecked;
			_classType = null;
			_object = null;
			_customForm = null;
			_viewForm = null;
			_construction = null;
		}
		# endregion

		# region Properties
		/// <summary>�L�[�v���p�e�B</summary>
		/// <value>���̃N���X�̃L�[�ƂȂ���iUnique)���擾�܂��͐ݒ肵�܂��B</value>
		public string Key
		{
			get{ return _key; }
			set{ _key = value; }
		}

		/// <summary>�A�Z���u��ID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃A�Z���u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string AssemblyID
		{
			get{ return _assemblyID; }
			set{ _assemblyID = value; }
		}

		/// <summary>�N���XID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃N���X�������̂��擾�܂��͐ݒ肵�܂��B</value>
		public string ClassID
		{
			get{ return _classID; }
			set{ _classID = value; }
		}

		/// <summary>�v���O�������̃v���p�e�B</summary>
		/// <value>���̃v���O�����̖��̂��擾�܂��͐ݒ肵�܂��B</value>
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		/// <summary>�v���O�����p�^�[���v���p�e�B</summary>
		/// <value>���̃v���O�����̃p�^�[�����擾�܂��͐ݒ肵�܂��B</value>
		public ProgramPattern Pattern
		{
			get{ return _pattern; }
			set{ _pattern = value; }
		}

		/// <summary>�p�����[�^�v���p�e�B</summary>
		/// <value>���̃v���O�����̃R���X�g���N�^�̃p�����[�^���擾�܂��͐ݒ肵�܂��B</value>
		public string Arguments
		{
			get{ return _arguments; }
			set{ _arguments = value; }
		}

		/// <summary>�v���O������ԃv���p�e�B</summary>
		/// <value>���̃v���O�����̏�Ԃ��擾�܂��͐ݒ肵�܂��B</value>
		public ProgramCondition Condition
		{
			get{ return _condition; }
			set{ _condition = value; }
		}

		/// <summary>�N���X�^�C�v�v���p�e�B</summary>
		/// <value>�N���X�̌^�����擾�܂��͐ݒ肵�܂��B</value>
		public Type ClassType
		{
			get{ return _classType; }
			set{ _classType = value; }
		}

		/// <summary>�I�u�W�F�N�g�v���p�e�B</summary>
		/// <value>���t���N�V�����ŃC���X�^���X�������A�Z���u���̃I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
		public Object Object
		{
			get{ return _object; }
			set{ _object = value; }
		}

		/// <summary>�}�X�����ŗL�t�H�[���I�u�W�F�N�g�v���p�e�B</summary>
		/// <value>Form�^�ɃL���X�g�����ʃA�Z���u���̃t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
		public Form CustomForm
		{
			get{ return _customForm; }
			set{ _customForm = value; }
		}

		/// <summary>�r���[�p�t�H�[���I�u�W�F�N�g�v���p�e�B</summary>
		/// <value>Form�^�ɃL���X�g�����r���[�p�t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
		public Form ViewForm
		{
			get{ return _viewForm; }
			set{ _viewForm = value; }
		}

		/// <summary>�}�X�^�����e�i���X�ݒ�N���X�I�u�W�F�N�g�v���p�e�B</summary>
		/// <value>�}�X�^�����e�i���X�ŗL�̃}�X�^�����e�i���X�ݒ�N���X�I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
		public MasterMaintenanceConstruction Construction
		{
			get{ return _construction; }
			set{ _construction = value; }
		}
		# endregion
	}

	# region enum ProgramPattern
	/// <summary>�}�X�^�����e�i���X�̃p�^�[���̗񋓌^�ł��B</summary>
	internal enum ProgramPattern : int
	{
		/// <summary>�i�ʏ�͎g���܂���j</summary>
		None = 0,

		/// <summary>�}�X�^�����e�i���X�V���O���^�C�v</summary>
		Single = 1,

		/// <summary>�}�X�^�����e�i���X�}���`�^�C�v</summary>
		Multi = 2,

		/// <summary>�}�X�^�����e�i���X�z��^�C�v</summary>
		Array = 3,

		/// <summary>�}�X�^�����e�i���X�R�K�w�z��^�C�v</summary>
		ThreeArray = 4,

		/// <summary>�}�X�^�����e�i���X�S�K�w�z��^�C�v</summary>
		FourArray = 5,

		/// <summary>�}�X�^�����e�i���X���̑��^�C�v</summary>
		Other = 9
	}

	/// <summary>
	/// <summary>�}�X�^�����e�i���X�̏�Ԃ̗񋓌^�ł��B</summary>
	/// </summary>
	internal enum ProgramCondition : int
	{
		/// <summary>���ύX�̏�Ԃł��B�i�`�F�b�N�{�b�N�X���`�F�b�N�j</summary>
		UnChecked = 0,

		/// <summary>�ύX�ς݂̏�Ԃł��B�i�`�F�b�N�{�b�N�X�`�F�b�N�ς݁j</summary>
		Checked = 1,
	}
	# endregion

}
