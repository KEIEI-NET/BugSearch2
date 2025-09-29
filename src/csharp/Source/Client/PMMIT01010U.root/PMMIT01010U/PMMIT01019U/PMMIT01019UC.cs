using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
	#region ���������ϖ��׃p�^�[�����N���X
	/// <summary>
	///	�������ϖ��׃p�^�[�����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������ϗp�̖��ו\���p�^�[����ݒ肷��N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	[Serializable]
	public class EstmDtlPtnInfo
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region �� Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public EstmDtlPtnInfo()
		{
			this._patternGuid = Guid.Empty;
			this._patternName = string.Empty;
			this._patternOrder = 0;
			this._searchType = 0;
			this._estimateDetailColInfoList = new List<EstmDtlColInfo>();
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="patternGuid">���׃p�^�[��GUID</param>
		/// <param name="patternName">���׃p�^�[������</param>
		/// <param name="patternOrder">�p�^�[���\������</param>
		/// <param name="partsSearchType">���i�����^�C�v</param>
		/// <param name="estimateDetailColInfo">�������σJ������񃊃X�g</param>
		public EstmDtlPtnInfo( Guid patternGuid, string patternName, int patternOrder, SearchType partsSearchType, List<EstmDtlColInfo> estimateDetailColInfo )
		{
			this._patternGuid = patternGuid;
			this._patternName = patternName;
			this._patternOrder = patternOrder;
			this._searchType = partsSearchType;
			this._estimateDetailColInfoList = estimateDetailColInfo;
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private Guid _patternGuid;												// ���׃p�^�[��GUID
		private string _patternName;											// ���׃p�^�[������
		private int _patternOrder;												// �p�^�[���\������
		private SearchType _searchType;											// ���i�����^�C�v
		private List<EstmDtlColInfo> _estimateDetailColInfoList;				// �������σJ������񃊃X�g
		private Dictionary<string, EstmDtlColInfo> _estmDtlColInfoDictionary;	// �������σJ�������f�B�N�V���i��

		#endregion

		// ===================================================================================== //
		// �񋓑�
		// ===================================================================================== //
		#region ��Enum

		public enum SearchType : int
		{
			Pure = 1,
			Prime = 2,
			None = 3
		}

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>���׃p�^�[��GUID</summary>
		public Guid PatternGuid
		{
			get { return _patternGuid; }
			set { _patternGuid = value; }
		}

		/// <summary>���׃p�^�[������</summary>
		public string PatternName
		{
			get { return _patternName; }
			set { _patternName = value; }
		}

		/// <summary>�p�^�[���\������</summary>
		public int PatternOrder
		{
			get { return _patternOrder; }
			set { _patternOrder = value; }
		}

		/// <summary>���i�����^�C�v</summary>
		public SearchType PartsSearchType
		{
			get { return _searchType; }
			set { _searchType = value; }
		}

		/// <summary>�������σJ������񃊃X�g</summary>
		public List<EstmDtlColInfo> EstimateDetailColInfoList
		{
			get { return _estimateDetailColInfoList; }
			set
			{
				_estimateDetailColInfoList = value;
                _estimateDetailColInfoList.Sort(new EstmDtlColInfoComparer());
				CreateEstmDtlColInfoDictionary();
			}
		}

		#endregion

		// ===================================================================================== //
		// �p�u���b�N�X�^�e�B�b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Static Methods

		/// <summary>
		/// ���i�����^�C�v�̖��̂��擾���܂��B
		/// </summary>
		/// <param name="partsSearchType">���i�����^�C�v</param>
		/// <returns>���i�����^�C�v����</returns>
		public static string PartsSearchTypeName( SearchType partsSearchType )
		{
			string name = string.Empty;
			switch (partsSearchType)
			{
				case SearchType.Pure:
					name = "�������i";
					break;
				case SearchType.Prime:
					name = "�D�Ǖ��i";
					break;
				case SearchType.None:
					name = "�����i�\���̂݁j";
					break;
			}
			return name;
		}

		/// <summary>
		/// ���i�����^�C�v�̃��X�g���擾���܂��B
		/// </summary>
		/// <returns>���i�����^�C�v���X�g</returns>
		public static List<SearchType> GetSearchTypeList()
		{
			List<SearchType> partsSearchTypeList = new List<SearchType>();
			partsSearchTypeList.Add(SearchType.Pure);
			partsSearchTypeList.Add(SearchType.Prime);
			partsSearchTypeList.Add(SearchType.None);
			return partsSearchTypeList;
		}

		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Methods

		/// <summary>
		/// �������σJ���������擾���܂��B
		/// </summary>
		/// <param name="colName">�J�����L�[</param>
		/// <returns>�������σJ�������</returns>
		public EstmDtlColInfo GetEstmDtlColInfo( string colName )
		{
			if (this.ContainsEstmDtlColInfo(colName))
			{
				return this._estmDtlColInfoDictionary[colName];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// �������σJ������񂪊܂܂�邩�`�F�b�N���܂��B
		/// </summary>
		/// <param name="colName">�J�����L�[</param>
		/// <returns>True:���݂���</returns>
		public bool ContainsEstmDtlColInfo( string colName )
		{
			if (_estmDtlColInfoDictionary == null)
			{
				this.CreateEstmDtlColInfoDictionary();
			}
			return _estmDtlColInfoDictionary.ContainsKey(colName);
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		#region ��Private Methods

		/// <summary>
		/// �������σJ�������f�B�N�V���i���𐶐����܂��B
		/// </summary>
		private void CreateEstmDtlColInfoDictionary()
		{
			Dictionary<string, EstmDtlColInfo> estmDtlColInfoDictionary = new Dictionary<string, EstmDtlColInfo>();

			foreach(EstmDtlColInfo estmDtlColInfo in this._estimateDetailColInfoList)
			{
				estmDtlColInfoDictionary.Add(estmDtlColInfo.Key, estmDtlColInfo);
			}

			this._estmDtlColInfoDictionary = estmDtlColInfoDictionary;
		}
		#endregion
	}
	#endregion

	#region ���������σJ�������N���X
	/// <summary>
	///	�������σJ�������N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������ϗp�̃J��������ݒ肷��N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	[Serializable]
	public class EstmDtlColInfo
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public EstmDtlColInfo()
		{
			this._key = string.Empty;
			this._visible = true;
			this._visiblePosition = 0;
			this._fixedCol = false;
			this._enterStop = false;
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="key">�L�[�v���p�e�B</param>
		/// <param name="visiblePosition">�\�������v���p�e�B</param>
		/// <param name="visible">�\���L���v���p�e�B</param>
		/// <param name="fixedCol">�\���Œ��v���p�e�B</param>
		/// <param name="enterStop">�ړ��L���v���p�e�B</param>
		public EstmDtlColInfo( string key, int visiblePosition, bool visible, bool fixedCol, bool enterStop )
		{
			this._key = key;
			this._visiblePosition = visiblePosition;
			this._fixedCol = fixedCol;
			this._enterStop = enterStop;
			this._visible = visible;
		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private string _key;				// �L�[
		private int _visiblePosition;		// �\������
		private bool _fixedCol;				// �\���Œ�
		private bool _enterStop;			// �ړ��L��
		private bool _visible;				// �\���L��

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>�L�[�v���p�e�B</summary>
		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}

		/// <summary>�\�������v���p�e�B</summary>
		public int VisiblePosition
		{
			get { return _visiblePosition; }
			set { _visiblePosition = value; }
		}

		/// <summary>�\���L���v���p�e�B</summary>
		public bool Visible
		{
			get { return _visible; }
			set { _visible = value; }
		}

		/// <summary>�\���Œ��v���p�e�B</summary>
		public bool FixedCol
		{
			get { return _fixedCol; }
			set { _fixedCol = value; }
		}

		/// <summary>�ړ��L���v���p�e�B</summary>
		public bool EnterStop
		{
			get { return _enterStop; }
			set { _enterStop = value; }
		}
		#endregion
	}
	#endregion

	#region ����\���ǉ����N���X

	/// <summary>
	///	��\�����ǉ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����p�^�[�����̃J�����̐������ݒ肷��ۂɎg�p���܂��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	public class ColDisplayAddInfo
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ColDisplayAddInfo()
		{
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="key">�L�[�v���p�e�B</param>
		/// <param name="visiblePosition">�\�������v���p�e�B</param>
		/// <param name="fixedcol">�\���Œ��v���p�e�B</param>
		/// <param name="visible">�\���L���v���p�e�B</param>
		/// <param name="enterStop">�ړ��L���v���p�e�B</param>
		public ColDisplayAddInfo( string key, int visiblePosition, bool fixedcol, bool visible, bool enterStop )
		{
			this._key = key;
			this._visiblePosition = visiblePosition;
			this._fixedCol = fixedcol;
			this._visible = visible;
			this._enterStop = enterStop;
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Memers

		private string _key;				// �L�[
		private int _visiblePosition;		// �\������
		private bool _fixedCol;				// �\���Œ�
		private bool _visible;				// �\���L��
		private bool _enterStop;			// �ړ��L��

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>�L�[�v���p�e�B</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>�\�������v���p�e�B</summary>
		public int VisiblePosition
		{
			get { return this._visiblePosition; }
			set { this._visiblePosition = value; }
		}
		/// <summary>�\���Œ��v���p�e�B</summary>
		public bool FixedCol
		{
			get { return this._fixedCol; }
			set { this._fixedCol = value; }
		}
		/// <summary>�\���L���v���p�e�B</summary>
		public bool Visible
		{
			get { return this._visible; }
			set { this._visible = value; }
		}
		/// <summary>�ړ��L���v���p�e�B</summary>
		public bool EnterStop
		{
			get { return this._enterStop; }
			set { this._enterStop = value; }
		}

		#endregion

	}

	#endregion

	#region ����\����{���N���X
	/// <summary>
	///	��\����{���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���ׂɕ\���\�ȃJ�����̊�{����ݒ肷��ۂɎg�p���܂��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	public class ColDisplayBasicInfo
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ColDisplayBasicInfo()
		{
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="key">�L�[�v���p�e�B</param>
		/// <param name="caption">�L���v�V�����v���p�e�B</param>
		/// <param name="readOnly">�ǎ��p�v���p�e�B</param>
        public ColDisplayBasicInfo(string key, string caption, bool readOnly, DataAttribute attr)
		{
			this._key = key;
			this._caption = caption;
			this._readOnly = readOnly;
            this._attr = attr;
		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private string _key;			// �L�[
		private string _caption;		// �L���v�V����
		private bool _readOnly;			// �ǎ��p
        private DataAttribute _attr;    // ����

		#endregion

        // ===================================================================================== //
        // �񋓌^
        // ===================================================================================== //
        #region ��Enums

        /// <summary>
        /// �f�[�^����
        /// </summary>
        public enum DataAttribute : int
        {
            /// <summary>����</summary>
            None = 0,
            /// <summary>�������i</summary>
            PureParts = 1,
            /// <summary>�D�Ǖ��i</summary>
            PrimeParts = 2,
        }

        #endregion

        // ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties
		/// <summary>�L�[�v���p�e�B</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>�L���v�V�����v���p�e�B</summary>
		public string Caption
		{
			get { return this._caption; }
			set { this._caption = value; }
		}
		/// <summary>�ǎ��p�v���p�e�B</summary>
		public bool ReadOnly
		{
			get { return this._readOnly; }
			set { this._readOnly = value; }
		}

        /// <summary>�f�[�^����</summary>
        public DataAttribute Attr
        {
            get { return this._attr; }
            set { this._attr = value; }
        }
		#endregion
	}
	#endregion

    #region �������σJ������r�p�̃N���X
    /// <summary>
    /// �������σJ������r�N���X(VisiblePosition��)
    /// </summary>
    /// <remarks></remarks>
    public class EstmDtlColInfoComparer : Comparer<EstmDtlColInfo>
    {
        public override int Compare(EstmDtlColInfo x, EstmDtlColInfo y)
        {
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            return result;
        }
    }
    #endregion
}
