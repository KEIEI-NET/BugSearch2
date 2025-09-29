using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    #region ���������ϗp���[�U�[�ݒ�N���X
    /// <summary>
    /// �������ϗp���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �������ς̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpdateNote :</br>
    /// <br>2009.07.16 22018 ��� ���b MANTIS[0013802] �a�k�R�[�h�K�C�h�̏����\�����[�h��ݒ�\�ɕύX�B</br>
    /// </remarks>
	[Serializable]
	public class EstimateInputConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region ��Private Members
		private int _focusPositionValue = DEFAULT_FocusPosition_VALUE;
		private int _showEstimateInfoValue = DEFAULT_DefaultShowEstimateInfo;
		private int _dataInputCountValue = DEFAULT_DataInputCount_VALUE;
		private int _fontSizeValue = DEFAULT_FontSize_VALUE;
		private int _clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
		private int _dateClearAfterSave = DEFAULT_DateClearAfterSave_VALUE;
		private int _saveInfoStore = DEFAULT_SaveInfoStore_VALUE;
        private int _focusPositionAfterCarSearch = DEFAULT_SaveInfoStore_VALUE;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        private int _blGuideMode = DEFAULT_BLGuideMode_VALUE;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        private HeaderFocusConstructionList _headerFocusConstructionList = new HeaderFocusConstructionList();
		private List<EstmDtlPtnInfo> _estimateDetailPatternList = new List<EstmDtlPtnInfo>();

		
		private const int DEFAULT_FocusPosition_VALUE = 4;
		private const int DEFAULT_DefaultShowEstimateInfo = 1;
		private const int DEFAULT_DataInputCount_VALUE = 99;
		private const int DEFAULT_FontSize_VALUE = 11;
		private const int DEFAULT_ClearAfterSave_VALUE = 0;
		private const int DEFAULT_SaveInfoStore_VALUE = 0;
		private const int DEFAULT_DateClearAfterSave_VALUE = 1;
        private const int DEFAULT_FocusPositionAfterCarSearch_VALUE = 2;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        private const int DEFAULT_BLGuideMode_VALUE = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructors
		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������ϗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public EstimateInputConstruction()
		{
			this._focusPositionValue = DEFAULT_FocusPosition_VALUE;
			this._dataInputCountValue = DEFAULT_DataInputCount_VALUE;
			this._fontSizeValue = DEFAULT_FontSize_VALUE;
			this._clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
			this._saveInfoStore = DEFAULT_SaveInfoStore_VALUE;
			this._dateClearAfterSave = DEFAULT_DateClearAfterSave_VALUE;
			this._showEstimateInfoValue = DEFAULT_DefaultShowEstimateInfo;
            this._focusPositionAfterCarSearch = DEFAULT_FocusPositionAfterCarSearch_VALUE;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            this._blGuideMode = DEFAULT_BLGuideMode_VALUE;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

			this._headerFocusConstructionList = new HeaderFocusConstructionList();
			this._estimateDetailPatternList = new List<EstmDtlPtnInfo>();
		}

		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <param name="focusPositionValue">�����t�H�[�J�X�ʒu</param>
		/// <param name="dataInputCountValue">�f�[�^���͍s��</param>
		/// <param name="fontSizeValue">�t�H���g�T�C�Y</param>
		/// <param name="clearAfterSave">�ۑ��㏉��������</param>
		/// <param name="saveInfoStore">�ۑ����̕ێ�</param>
		/// <param name="functionMode">�t�@���N�V�������[�h</param>
		/// <param name="headerFocusConstructionList">�w�b�_�t�H�[�J�X�ݒ胊�X�g</param>
		/// <param name="supplierFormalAfterSave">�ۑ���̎d���`��</param>
		/// <param name="dateClearAfterSave">�ۑ���̓��t������</param>
        /// <param name="defaultShowEstimateInfoValue"></param>
        /// <param name="estimateDetailPatternList"></param>
        /// <param name="focusPositionAfterCarSearch"></param>
		/// <remarks>
        /// <br>Note       : �������ϗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
        //public EstimateInputConstruction(int focusPositionValue, int defaultShowEstimateInfoValue, int dataInputCountValue, int fontSizeValue, int clearAfterSave, int dateClearAfterSave, int saveInfoStore, int focusPositionAfterCarSearch, HeaderFocusConstructionList headerFocusConstructionList, List<EstmDtlPtnInfo> estimateDetailPatternList)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        public EstimateInputConstruction(int focusPositionValue, int defaultShowEstimateInfoValue, int dataInputCountValue, int fontSizeValue, int clearAfterSave, int dateClearAfterSave, int saveInfoStore, int focusPositionAfterCarSearch, HeaderFocusConstructionList headerFocusConstructionList, List<EstmDtlPtnInfo> estimateDetailPatternList, int blGuideMode)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        {
			this._focusPositionValue = focusPositionValue;
			this._showEstimateInfoValue = defaultShowEstimateInfoValue;
			this._dataInputCountValue = dataInputCountValue;
			this._fontSizeValue = fontSizeValue;
			this._clearAfterSave = clearAfterSave;
			this._dateClearAfterSave = dateClearAfterSave;
			this._saveInfoStore = saveInfoStore;
            this._focusPositionAfterCarSearch = focusPositionAfterCarSearch;
			this._headerFocusConstructionList = headerFocusConstructionList;
			this._estimateDetailPatternList = estimateDetailPatternList;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            this._blGuideMode = blGuideMode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
		}
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region ��Properties
		/// <summary>�����t�H�[�J�X�ʒu</summary>
		public int FocusPositionValue
		{
			get { return this._focusPositionValue; }
			set { this._focusPositionValue = value; }
		}

		/// <summary>���Ϗ��\��</summary>
		public int ShowEstimateInfoValue
		{
			get { return _showEstimateInfoValue; }
			set { this._showEstimateInfoValue = value; }
		}

		/// <summary>�f�[�^���͍s��</summary>
		public int DataInputCountValue
		{
			get { return this._dataInputCountValue; }
			set { this._dataInputCountValue = value; }
		}

		/// <summary>�t�H���g�T�C�Y</summary>
		public int FontSizeValue
		{
			get { return this._fontSizeValue; }
			set { this._fontSizeValue = value; }
		}

		/// <summary>�ۑ��㏉��������</summary>
		public int ClearAfterSave
		{
			get { return this._clearAfterSave; }
			set { this._clearAfterSave = value; }
		}

		/// <summary>�ۑ���̓��t������</summary>
		public int DateClearAfterSave
		{
			get { return this._dateClearAfterSave; }
			set { this._dateClearAfterSave = value; }
		}

		/// <summary>�ۑ����̋L��</summary>
		public int SaveInfoStoreValue
		{
			get { return this._saveInfoStore; }
			set { this._saveInfoStore = value; }
		}

        /// <summary>���q������̃t�H�[�J�X�ʒu</summary>
        public int FocusPositionAfterCarSearchValue
        {
            get { return this._focusPositionAfterCarSearch; }
            set { this._focusPositionAfterCarSearch = value; }
        }

		/// <summary>�w�b�_�t�H�[�J�X�ݒ胊�X�g</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionList
		{
			get { return this._headerFocusConstructionList; }
			set { this._headerFocusConstructionList = value; }
		}

		/// <summary>���׃t�H�[�J�X�ݒ胊�X�g</summary>
		public List<EstmDtlPtnInfo> EstimateDetailPatternList
		{
			get { return _estimateDetailPatternList; }
			set { this._estimateDetailPatternList = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        /// <summary>�a�k�R�[�h�K�C�h�����\�����[�h</summary>
        public int BLGuideMode
        {
            get { return _blGuideMode; }
            set { this._blGuideMode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region ��Public Methods
		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X��������
		/// </summary>
        /// <returns>�������ϗp���[�U�[�ݒ�N���X</returns>
		public EstimateInputConstruction Clone()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //return new EstimateInputConstruction(
            //    this._focusPositionValue,
            //    this._showEstimateInfoValue,
            //    this._dataInputCountValue,
            //    this._fontSizeValue,
            //    this._clearAfterSave,
            //    this._dateClearAfterSave,
            //    this._saveInfoStore,
            //    this._focusPositionAfterCarSearch,
            //    this._headerFocusConstructionList,
            //    this._estimateDetailPatternList
            //    );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            return new EstimateInputConstruction(
                this._focusPositionValue,
                this._showEstimateInfoValue,
                this._dataInputCountValue,
                this._fontSizeValue,
                this._clearAfterSave,
                this._dateClearAfterSave,
                this._saveInfoStore,
                this._focusPositionAfterCarSearch,
                this._headerFocusConstructionList,
                this._estimateDetailPatternList,
                this._blGuideMode
                );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
		}
		# endregion
	}
	#endregion

    #region ���������ϗp�ݒ�A�N�Z�X�N���X
    /// <summary>
    /// �������ϗp�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �������ς̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.07.10</br>
	/// <br></br>
	/// </remarks>
	public class EstimateInputConstructionAcs
	{
		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region ��Public Const
		/// <summary>�����t�H�[�J�X�ʒu�i���_�j</summary>
		public const int ForcusPosition_SectionCode = 0;
		/// <summary>�����t�H�[�J�X�ʒu�i�S���ҁj</summary>
		public const int ForcusPosition_SalesEmployeeCd = 1;
		/// <summary>�����t�H�[�J�X�ʒu�i���Ӑ�j</summary>
		public const int ForcusPosition_CustomerCode = 2;
		/// <summary>�����t�H�[�J�X�ʒu�i�`�[�ԍ��j</summary>
		public const int ForcusPosition_SalesSlipNum = 3;
		/// <summary>�����t�H�[�J�X�ʒu�i�ޕʁj</summary>
		public const int ForcusPosition_ModelDesignationNo = 4;
		/// <summary>�����t�H�[�J�X�ʒu�i�^���j</summary>
		public const int ForcusPosition_FullModel = 5;
		/// <summary>�����t�H�[�J�X�ʒu�i�G���W���^���j</summary>
		public const int ForcusPosition_EngineModelNm= 6;

		/// <summary>���Ϗ�񏉊��\���i���Ȃ��j</summary>
		public const int ShowEstimateInfo_OFF = 0;
		/// <summary>���Ϗ�񏉊��\���i����j</summary>
		public const int ShowEstimateInfo_ON = 1;

		/// <summary>�ۑ��㏉���������i���Ȃ��j</summary>
		public const int ClearAfterSave_OFF = 0;
		/// <summary>�ۑ��㏉���������i����j</summary>
		public const int ClearAfterSave_ON = 1;

		/// <summary>�ۑ���̓��t�������i���Ȃ��j</summary>
		public const int DateClearAfterSave_OFF = 1;
		/// <summary>�ۑ���̓��t�������i����j</summary>
		public const int DateClearAfterSave_ON = 0;

		/// <summary>�ۑ������̋L���i���Ȃ��j</summary>
		public const int SaveInfoStore_OFF = 0;
		/// <summary>�ۑ������̋L���i����j</summary>
		public const int SaveInfoStore_ON = 1;

        /// <summary>���q������̃t�H�[�J�X�ʒu�i���Ȃ��j</summary>
        public const int FocusPositionAfterCarSearch_Default = 0;
        /// <summary>���q������̃t�H�[�J�X�ʒu�i�N���j</summary>
        public const int FocusPositionAfterCarSearch_FirstEntryDate = 1;
        /// <summary>���q������̃t�H�[�J�X�ʒu�i�ԑ�ԍ��j</summary>
        public const int FocusPositionAfterCarSearch_ProduceFrameNo = 2;
        /// <summary>���q������̃t�H�[�J�X�ʒu�i���ׁj</summary>
        public const int FocusPositionAfterCarSearch_Detail = 3;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        /// <summary>�a�k�R�[�h�K�C�h�����\�����[�h</summary>
        public const int BLGuideMode_Default = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region ��Private Members

		private EstimateInputConstruction _estimateInputConstruction;
		private static EstimateInputConstructionAcs _estimateInputConstructionAcs;
		private const string XML_FILE_NAME = "PMMIT01112A_Construction.XML";
		private Dictionary<string, Control> _headerItemsDictionary;
		private SortedDictionary<int, EstmDtlPtnInfo> _estimateDetailInfoDictionary;
		private List<EstmDtlPtnInfo> _estimateDetailPatternInfoDefaultList;
		private List<ColDisplayBasicInfo> _colDisplayBasicInfoList;
		private Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>> _colDisplayAddInfoDictionary;

		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructors
		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private EstimateInputConstructionAcs()
		{
			this._estimateInputConstruction = new EstimateInputConstruction();
			this._headerItemsDictionary = new Dictionary<string, Control>();
			this._estimateDetailInfoDictionary = new SortedDictionary<int, EstmDtlPtnInfo>();

			this.Deserialize();
		}

		/// <summary>
        /// �������ϗp���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
        /// <returns>�������ϗp���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
		public static EstimateInputConstructionAcs GetInstance()
		{
			if (_estimateInputConstructionAcs == null)
			{
				_estimateInputConstructionAcs = new EstimateInputConstructionAcs();
			}

			return _estimateInputConstructionAcs;
		}
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region ��Delegate

		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region�� Event
		/// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
		public event EventHandler DataChanged;

		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region ��Properties
		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X
		/// </summary>
		public EstimateInputConstruction EstimateInputConstruction
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.Clone();
			}
		}

		/// <summary>�����t�H�[�J�X�ʒu</summary>
		public int FocusPositionValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.FocusPositionValue;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.FocusPositionValue = value;
			}
		}

		/// <summary>���Ϗ��\��</summary>
		public int ShowEstimateInfoValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.ShowEstimateInfoValue;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.ShowEstimateInfoValue = value;
			}
		}

		/// <summary>�f�[�^���͍s��</summary>
		public int DataInputCountValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.DataInputCountValue;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.DataInputCountValue = value;
			}
		}

		/// <summary>�t�H���g�T�C�Y</summary>
		public int FontSizeValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.FontSizeValue;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.FontSizeValue = value;
			}
		}

		/// <summary>�ۑ��㏉��������</summary>
		public int ClearAfterSaveValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.ClearAfterSave;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.ClearAfterSave = value;
			}
		}

		/// <summary>�ۑ���̓��t������</summary>
		public int DateClearAfterSaveValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.DateClearAfterSave;

			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.DateClearAfterSave = value;
			}
		}

		/// <summary>�ۑ������L��</summary>
		public int SaveInfoStoreValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.SaveInfoStoreValue;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.SaveInfoStoreValue = value;
			}
		}

        /// <summary>�ۑ���̓��t������</summary>
        public int FocusPositionAfterCarSearchValue
        {
            get
            {
                if (_estimateInputConstruction == null)
                {
                    _estimateInputConstruction = new EstimateInputConstruction();
                }
                return _estimateInputConstruction.FocusPositionAfterCarSearchValue;

            }
            set
            {
                if (_estimateInputConstruction == null)
                {
                    _estimateInputConstruction = new EstimateInputConstruction();
                }
                _estimateInputConstruction.FocusPositionAfterCarSearchValue = value;
            }
        }

		/// <summary>�w�b�_�t�H�[�J�X�ݒ胊�X�g</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionListValue
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				return _estimateInputConstruction.HeaderFocusConstructionList;
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				_estimateInputConstruction.HeaderFocusConstructionList = value;
			}
		}

		/// <summary>���ϖ��׃p�^�[�������ݒ胊�X�g</summary>
		public List<EstmDtlPtnInfo> EstimateDetailPatternInfoDetaultList
		{
			get { return this._estimateDetailPatternInfoDefaultList; }
			set { this._estimateDetailPatternInfoDefaultList = value; }
		}

		/// <summary>���ϖ��׃p�^�[���ݒ胊�X�g</summary>
		public List<EstmDtlPtnInfo> EstimateDetailPatternInfoList
		{
			get
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				if (( this._estimateInputConstruction.EstimateDetailPatternList == null ) ||
					( this._estimateInputConstruction.EstimateDetailPatternList.Count == 0 ))
				{
					return this._estimateDetailPatternInfoDefaultList;
				}
				else
				{

					return this._estimateInputConstruction.EstimateDetailPatternList;
				}
			}
			set
			{
				if (_estimateInputConstruction == null)
				{
					_estimateInputConstruction = new EstimateInputConstruction();
				}
				this._estimateInputConstruction.EstimateDetailPatternList = value;
			}
		}

		/// <summary>���׃p�^�[��Dictionary</summary>
		public SortedDictionary<int, EstmDtlPtnInfo> EstimateDetailPatternInfoDictionary
		{
			get { return this.CreateEstimateDetailInfoDictionary(); }
		}

		/// <summary>�w�b�_����Dictionary</summary>
		public Dictionary<string, Control> HeaderItemsDictionary
		{
			get { return this._headerItemsDictionary; }
			set { this._headerItemsDictionary = value; }
		}

		/// <summary>���ו\�����{��񃊃X�g</summary>
		public List<ColDisplayBasicInfo> ColDisplayBasicInfoList
		{
			get { return this._colDisplayBasicInfoList; }
			set { this._colDisplayBasicInfoList = value; }
		}

		/// <summary>���ו\�����ڒǉ���񃊃X�g</summary>
		public Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>> ColDisplayAddInfoDictionary
		{
			get { return this._colDisplayAddInfoDictionary; }
			set { this._colDisplayAddInfoDictionary = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        /// <summary>�a�k�R�[�h�K�C�h�����\�����[�h</summary>
        public int BLGuideModeValue
        {
            get
            {
                if ( _estimateInputConstruction == null )
                {
                    _estimateInputConstruction = new EstimateInputConstruction();
                }
                return _estimateInputConstruction.BLGuideMode;

            }
            set
            {
                if ( _estimateInputConstruction == null )
                {
                    _estimateInputConstruction = new EstimateInputConstruction();
                }
                _estimateInputConstruction.BLGuideMode = value;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region ��Public Methods

		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������ϗp���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void Serialize()
		{
			//UserSettingController.ByteSerializeUserSetting(_estimateInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			UserSettingController.SerializeUserSetting(_estimateInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// �f�[�^�ύX�㔭���C�x���g���s
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������ϗp���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
                try
                {
                    _estimateInputConstruction = UserSettingController.DeserializeUserSetting<EstimateInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
			}
		}

		/// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X�ݒ�t�@�C�����݃`�F�b�N
		/// </summary>
		/// <returns>True:���[�U�[�ݒ�t�@�C������</returns>
		public bool IsUserSettingExists()
		{
			bool ret = false;
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				ret = true;
			}
			return ret;
		}

		/// <summary>
		/// �w�肳�ꂽ���׃p�^�[�����擾���܂��B
		/// </summary>
		/// <param name="patternGuid">���׃p�^�[��Guid</param>
		/// <returns>���׃p�^�[��</returns>
		public EstmDtlPtnInfo GetEstmDtlPtnInfo( Guid patternGuid )
		{
			EstmDtlPtnInfo retEstmDtlPtnInfo = null;
			List<EstmDtlPtnInfo> estmDtlPtnInfoList = this.EstimateDetailPatternInfoList;
			foreach (EstmDtlPtnInfo estmDtlPtnInfo in estmDtlPtnInfoList)
			{
				if (estmDtlPtnInfo.PatternGuid == patternGuid)
				{
					retEstmDtlPtnInfo = estmDtlPtnInfo;
					break;
				}
			}
			return retEstmDtlPtnInfo;
		}

		/// <summary>
		/// �w�肳�ꂽ���׃p�^�[�����擾���܂��B
		/// </summary>
		/// <param name="patternOrder">���ו\������</param>
		/// <returns>���׃p�^�[��</returns>
		public EstmDtlPtnInfo GetEstmDtlPtnInfo( int patternOrder )	
		{
			EstmDtlPtnInfo retEstmDtlPtnInfo = null;
			List<EstmDtlPtnInfo> estmDtlPtnInfoList = this.EstimateDetailPatternInfoList;
			foreach (EstmDtlPtnInfo estmDtlPtnInfo in estmDtlPtnInfoList)
			{
				if (estmDtlPtnInfo.PatternOrder == patternOrder)
				{
					retEstmDtlPtnInfo = estmDtlPtnInfo;
					break;
				}
			}
			return retEstmDtlPtnInfo;
		}

		/// <summary>
		/// �w�肳�ꂽ�\�����ʂ̎��̖��׃p�^�[�����擾���܂��B
		/// </summary>
		/// <param name="patternOrder"></param>
		/// <returns></returns>
		public EstmDtlPtnInfo GetNextEstmDtlPtnInfo( int patternOrder )
		{
			EstmDtlPtnInfo retEstmDtlPtnInfo = null;
			EstmDtlPtnInfo firstOrderEstmDtlPtnInfo = null;
			SortedDictionary<int, EstmDtlPtnInfo> estmDtlPtnInfoDic = this.CreateEstimateDetailInfoDictionary();
			foreach (int key in estmDtlPtnInfoDic.Keys)
			{
				if (firstOrderEstmDtlPtnInfo == null)
				{
					firstOrderEstmDtlPtnInfo = estmDtlPtnInfoDic[key];
				}
				if (patternOrder < key)
				{
					retEstmDtlPtnInfo = estmDtlPtnInfoDic[key];
					break;
				}
			}
			return ( retEstmDtlPtnInfo != null ) ? retEstmDtlPtnInfo : firstOrderEstmDtlPtnInfo;
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		#region ��Private Methods

		/// <summary>
		/// ���׃p�^�[���f�B�N�V���i������
		/// </summary>
		/// <returns>���׃p�^�[���f�B�N�V���i��</returns>
		private SortedDictionary<int, EstmDtlPtnInfo> CreateEstimateDetailInfoDictionary()
		{
			SortedDictionary<int, EstmDtlPtnInfo> estimateDetailInfoDictionary = new SortedDictionary<int, EstmDtlPtnInfo>();

			List<EstmDtlPtnInfo> estimateDetailPatternInfoList = ( ( this._estimateInputConstruction.EstimateDetailPatternList != null ) && ( this._estimateInputConstruction.EstimateDetailPatternList.Count > 0 ) ) ? this._estimateInputConstruction.EstimateDetailPatternList : this._estimateDetailPatternInfoDefaultList;
			if (estimateDetailPatternInfoList != null)
			{
				foreach (EstmDtlPtnInfo estimateDetailPatternInfo in estimateDetailPatternInfoList)
				{
					estimateDetailInfoDictionary.Add(estimateDetailPatternInfo.PatternOrder, estimateDetailPatternInfo);
				}
			}
			return estimateDetailInfoDictionary;
		}
		#endregion
	}
	#endregion

}
