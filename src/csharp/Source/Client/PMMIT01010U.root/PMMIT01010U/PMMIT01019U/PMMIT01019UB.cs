using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    #region ◎検索見積用ユーザー設定クラス
    /// <summary>
    /// 検索見積用ユーザー設定クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpdateNote :</br>
    /// <br>2009.07.16 22018 鈴木 正臣 MANTIS[0013802] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// </remarks>
	[Serializable]
	public class EstimateInputConstruction
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region ■Private Members
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
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructors
		/// <summary>
        /// 検索見積用ユーザー設定クラス
		/// </summary>
		/// <remarks>
        /// <br>Note       : 検索見積用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
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
        /// 検索見積用ユーザー設定クラス
		/// </summary>
		/// <param name="focusPositionValue">初期フォーカス位置</param>
		/// <param name="dataInputCountValue">データ入力行数</param>
		/// <param name="fontSizeValue">フォントサイズ</param>
		/// <param name="clearAfterSave">保存後初期化処理</param>
		/// <param name="saveInfoStore">保存情報の保持</param>
		/// <param name="functionMode">ファンクションモード</param>
		/// <param name="headerFocusConstructionList">ヘッダフォーカス設定リスト</param>
		/// <param name="supplierFormalAfterSave">保存後の仕入形式</param>
		/// <param name="dateClearAfterSave">保存後の日付初期化</param>
        /// <param name="defaultShowEstimateInfoValue"></param>
        /// <param name="estimateDetailPatternList"></param>
        /// <param name="focusPositionAfterCarSearch"></param>
		/// <remarks>
        /// <br>Note       : 検索見積用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
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
		// プロパティ
		// ===================================================================================== //
		# region ■Properties
		/// <summary>初期フォーカス位置</summary>
		public int FocusPositionValue
		{
			get { return this._focusPositionValue; }
			set { this._focusPositionValue = value; }
		}

		/// <summary>見積情報表示</summary>
		public int ShowEstimateInfoValue
		{
			get { return _showEstimateInfoValue; }
			set { this._showEstimateInfoValue = value; }
		}

		/// <summary>データ入力行数</summary>
		public int DataInputCountValue
		{
			get { return this._dataInputCountValue; }
			set { this._dataInputCountValue = value; }
		}

		/// <summary>フォントサイズ</summary>
		public int FontSizeValue
		{
			get { return this._fontSizeValue; }
			set { this._fontSizeValue = value; }
		}

		/// <summary>保存後初期化処理</summary>
		public int ClearAfterSave
		{
			get { return this._clearAfterSave; }
			set { this._clearAfterSave = value; }
		}

		/// <summary>保存後の日付初期化</summary>
		public int DateClearAfterSave
		{
			get { return this._dateClearAfterSave; }
			set { this._dateClearAfterSave = value; }
		}

		/// <summary>保存情報の記憶</summary>
		public int SaveInfoStoreValue
		{
			get { return this._saveInfoStore; }
			set { this._saveInfoStore = value; }
		}

        /// <summary>車輌検索後のフォーカス位置</summary>
        public int FocusPositionAfterCarSearchValue
        {
            get { return this._focusPositionAfterCarSearch; }
            set { this._focusPositionAfterCarSearch = value; }
        }

		/// <summary>ヘッダフォーカス設定リスト</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionList
		{
			get { return this._headerFocusConstructionList; }
			set { this._headerFocusConstructionList = value; }
		}

		/// <summary>明細フォーカス設定リスト</summary>
		public List<EstmDtlPtnInfo> EstimateDetailPatternList
		{
			get { return _estimateDetailPatternList; }
			set { this._estimateDetailPatternList = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        /// <summary>ＢＬコードガイド初期表示モード</summary>
        public int BLGuideMode
        {
            get { return _blGuideMode; }
            set { this._blGuideMode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region ■Public Methods
		/// <summary>
        /// 検索見積用ユーザー設定クラス複製処理
		/// </summary>
        /// <returns>検索見積用ユーザー設定クラス</returns>
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

    #region ◎検索見積用設定アクセスクラス
    /// <summary>
    /// 検索見積用設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.07.10</br>
	/// <br></br>
	/// </remarks>
	public class EstimateInputConstructionAcs
	{
		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region ■Public Const
		/// <summary>初期フォーカス位置（拠点）</summary>
		public const int ForcusPosition_SectionCode = 0;
		/// <summary>初期フォーカス位置（担当者）</summary>
		public const int ForcusPosition_SalesEmployeeCd = 1;
		/// <summary>初期フォーカス位置（得意先）</summary>
		public const int ForcusPosition_CustomerCode = 2;
		/// <summary>初期フォーカス位置（伝票番号）</summary>
		public const int ForcusPosition_SalesSlipNum = 3;
		/// <summary>初期フォーカス位置（類別）</summary>
		public const int ForcusPosition_ModelDesignationNo = 4;
		/// <summary>初期フォーカス位置（型式）</summary>
		public const int ForcusPosition_FullModel = 5;
		/// <summary>初期フォーカス位置（エンジン型式）</summary>
		public const int ForcusPosition_EngineModelNm= 6;

		/// <summary>見積情報初期表示（しない）</summary>
		public const int ShowEstimateInfo_OFF = 0;
		/// <summary>見積情報初期表示（する）</summary>
		public const int ShowEstimateInfo_ON = 1;

		/// <summary>保存後初期化処理（しない）</summary>
		public const int ClearAfterSave_OFF = 0;
		/// <summary>保存後初期化処理（する）</summary>
		public const int ClearAfterSave_ON = 1;

		/// <summary>保存後の日付初期化（しない）</summary>
		public const int DateClearAfterSave_OFF = 1;
		/// <summary>保存後の日付初期化（する）</summary>
		public const int DateClearAfterSave_ON = 0;

		/// <summary>保存時情報の記憶（しない）</summary>
		public const int SaveInfoStore_OFF = 0;
		/// <summary>保存時情報の記憶（する）</summary>
		public const int SaveInfoStore_ON = 1;

        /// <summary>車輌検索後のフォーカス位置（しない）</summary>
        public const int FocusPositionAfterCarSearch_Default = 0;
        /// <summary>車輌検索後のフォーカス位置（年式）</summary>
        public const int FocusPositionAfterCarSearch_FirstEntryDate = 1;
        /// <summary>車輌検索後のフォーカス位置（車台番号）</summary>
        public const int FocusPositionAfterCarSearch_ProduceFrameNo = 2;
        /// <summary>車輌検索後のフォーカス位置（明細）</summary>
        public const int FocusPositionAfterCarSearch_Detail = 3;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        /// <summary>ＢＬコードガイド初期表示モード</summary>
        public const int BLGuideMode_Default = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region ■Private Members

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
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructors
		/// <summary>
        /// 検索見積用ユーザー設定クラスアクセスクラス（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private EstimateInputConstructionAcs()
		{
			this._estimateInputConstruction = new EstimateInputConstruction();
			this._headerItemsDictionary = new Dictionary<string, Control>();
			this._estimateDetailInfoDictionary = new SortedDictionary<int, EstmDtlPtnInfo>();

			this.Deserialize();
		}

		/// <summary>
        /// 検索見積用ユーザー設定アクセスクラス インスタンス取得処理
		/// </summary>
        /// <returns>検索見積用ユーザー設定アクセスクラス インスタンス</returns>
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
		// デリゲート
		// ===================================================================================== //
		# region ■Delegate

		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region■ Event
		/// <summary>データ変更後発生イベント</summary>
		public event EventHandler DataChanged;

		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region ■Properties
		/// <summary>
        /// 検索見積用ユーザー設定クラス
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

		/// <summary>初期フォーカス位置</summary>
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

		/// <summary>見積情報表示</summary>
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

		/// <summary>データ入力行数</summary>
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

		/// <summary>フォントサイズ</summary>
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

		/// <summary>保存後初期化処理</summary>
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

		/// <summary>保存後の日付初期化</summary>
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

		/// <summary>保存時情報記憶</summary>
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

        /// <summary>保存後の日付初期化</summary>
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

		/// <summary>ヘッダフォーカス設定リスト</summary>
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

		/// <summary>見積明細パターン初期設定リスト</summary>
		public List<EstmDtlPtnInfo> EstimateDetailPatternInfoDetaultList
		{
			get { return this._estimateDetailPatternInfoDefaultList; }
			set { this._estimateDetailPatternInfoDefaultList = value; }
		}

		/// <summary>見積明細パターン設定リスト</summary>
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

		/// <summary>明細パターンDictionary</summary>
		public SortedDictionary<int, EstmDtlPtnInfo> EstimateDetailPatternInfoDictionary
		{
			get { return this.CreateEstimateDetailInfoDictionary(); }
		}

		/// <summary>ヘッダ項目Dictionary</summary>
		public Dictionary<string, Control> HeaderItemsDictionary
		{
			get { return this._headerItemsDictionary; }
			set { this._headerItemsDictionary = value; }
		}

		/// <summary>明細表示列基本情報リスト</summary>
		public List<ColDisplayBasicInfo> ColDisplayBasicInfoList
		{
			get { return this._colDisplayBasicInfoList; }
			set { this._colDisplayBasicInfoList = value; }
		}

		/// <summary>明細表示項目追加情報リスト</summary>
		public Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>> ColDisplayAddInfoDictionary
		{
			get { return this._colDisplayAddInfoDictionary; }
			set { this._colDisplayAddInfoDictionary = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        /// <summary>ＢＬコードガイド初期表示モード</summary>
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
		// パブリックメソッド
		// ===================================================================================== //
		# region ■Public Methods

		/// <summary>
        /// 検索見積用ユーザー設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 検索見積用ユーザー設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void Serialize()
		{
			//UserSettingController.ByteSerializeUserSetting(_estimateInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			UserSettingController.SerializeUserSetting(_estimateInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// データ変更後発生イベント実行
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
        /// 検索見積用ユーザー設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 検索見積用ユーザー設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
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
        /// 検索見積用ユーザー設定クラス設定ファイル存在チェック
		/// </summary>
		/// <returns>True:ユーザー設定ファイル無し</returns>
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
		/// 指定された明細パターンを取得します。
		/// </summary>
		/// <param name="patternGuid">明細パターンGuid</param>
		/// <returns>明細パターン</returns>
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
		/// 指定された明細パターンを取得します。
		/// </summary>
		/// <param name="patternOrder">明細表示順序</param>
		/// <returns>明細パターン</returns>
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
		/// 指定された表示順位の次の明細パターンを取得します。
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
		// プライベートメソッド
		// ===================================================================================== //
		#region ■Private Methods

		/// <summary>
		/// 明細パターンディクショナリ生成
		/// </summary>
		/// <returns>明細パターンディクショナリ</returns>
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
