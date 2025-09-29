using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
	#region ◎検索見積明細パターン情報クラス
	/// <summary>
	///	検索見積明細パターン情報クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 検索見積用の明細表示パターンを設定するクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	[Serializable]
	public class EstmDtlPtnInfo
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■ Constructor

		/// <summary>
		/// デフォルトコンストラクタ
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
		/// コンストラクタ
		/// </summary>
		/// <param name="patternGuid">明細パターンGUID</param>
		/// <param name="patternName">明細パターン名称</param>
		/// <param name="patternOrder">パターン表示順序</param>
		/// <param name="partsSearchType">部品検索タイプ</param>
		/// <param name="estimateDetailColInfo">検索見積カラム情報リスト</param>
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
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private Guid _patternGuid;												// 明細パターンGUID
		private string _patternName;											// 明細パターン名称
		private int _patternOrder;												// パターン表示順序
		private SearchType _searchType;											// 部品検索タイプ
		private List<EstmDtlColInfo> _estimateDetailColInfoList;				// 検索見積カラム情報リスト
		private Dictionary<string, EstmDtlColInfo> _estmDtlColInfoDictionary;	// 検索見積カラム情報ディクショナリ

		#endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		#region ■Enum

		public enum SearchType : int
		{
			Pure = 1,
			Prime = 2,
			None = 3
		}

		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>明細パターンGUID</summary>
		public Guid PatternGuid
		{
			get { return _patternGuid; }
			set { _patternGuid = value; }
		}

		/// <summary>明細パターン名称</summary>
		public string PatternName
		{
			get { return _patternName; }
			set { _patternName = value; }
		}

		/// <summary>パターン表示順序</summary>
		public int PatternOrder
		{
			get { return _patternOrder; }
			set { _patternOrder = value; }
		}

		/// <summary>部品検索タイプ</summary>
		public SearchType PartsSearchType
		{
			get { return _searchType; }
			set { _searchType = value; }
		}

		/// <summary>検索見積カラム情報リスト</summary>
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
		// パブリックスタティックメソッド
		// ===================================================================================== //
		#region ■Public Static Methods

		/// <summary>
		/// 部品検索タイプの名称を取得します。
		/// </summary>
		/// <param name="partsSearchType">部品検索タイプ</param>
		/// <returns>部品検索タイプ名称</returns>
		public static string PartsSearchTypeName( SearchType partsSearchType )
		{
			string name = string.Empty;
			switch (partsSearchType)
			{
				case SearchType.Pure:
					name = "純正部品";
					break;
				case SearchType.Prime:
					name = "優良部品";
					break;
				case SearchType.None:
					name = "無し（表示のみ）";
					break;
			}
			return name;
		}

		/// <summary>
		/// 部品検索タイプのリストを取得します。
		/// </summary>
		/// <returns>部品検索タイプリスト</returns>
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
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods

		/// <summary>
		/// 検索見積カラム情報を取得します。
		/// </summary>
		/// <param name="colName">カラムキー</param>
		/// <returns>検索見積カラム情報</returns>
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
		/// 検索見積カラム情報が含まれるかチェックします。
		/// </summary>
		/// <param name="colName">カラムキー</param>
		/// <returns>True:存在する</returns>
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
		// プライベートメソッド
		// ===================================================================================== //
		#region ■Private Methods

		/// <summary>
		/// 検索見積カラム情報ディクショナリを生成します。
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

	#region ◎検索見積カラム情報クラス
	/// <summary>
	///	検索見積カラム情報クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 検索見積用のカラム情報を設定するクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	[Serializable]
	public class EstmDtlColInfo
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// デフォルトコンストラクタ
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
		/// コンストラクタ
		/// </summary>
		/// <param name="key">キープロパティ</param>
		/// <param name="visiblePosition">表示順序プロパティ</param>
		/// <param name="visible">表示有無プロパティ</param>
		/// <param name="fixedCol">表示固定列プロパティ</param>
		/// <param name="enterStop">移動有無プロパティ</param>
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
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private string _key;				// キー
		private int _visiblePosition;		// 表示順序
		private bool _fixedCol;				// 表示固定
		private bool _enterStop;			// 移動有無
		private bool _visible;				// 表示有無

		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>キープロパティ</summary>
		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}

		/// <summary>表示順序プロパティ</summary>
		public int VisiblePosition
		{
			get { return _visiblePosition; }
			set { _visiblePosition = value; }
		}

		/// <summary>表示有無プロパティ</summary>
		public bool Visible
		{
			get { return _visible; }
			set { _visible = value; }
		}

		/// <summary>表示固定列プロパティ</summary>
		public bool FixedCol
		{
			get { return _fixedCol; }
			set { _fixedCol = value; }
		}

		/// <summary>移動有無プロパティ</summary>
		public bool EnterStop
		{
			get { return _enterStop; }
			set { _enterStop = value; }
		}
		#endregion
	}
	#endregion

	#region ◎列表示追加情報クラス

	/// <summary>
	///	列表示情報追加クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 検索パターン毎のカラムの制御情報を設定する際に使用します。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	public class ColDisplayAddInfo
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ColDisplayAddInfo()
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="key">キープロパティ</param>
		/// <param name="visiblePosition">表示順序プロパティ</param>
		/// <param name="fixedcol">表示固定列プロパティ</param>
		/// <param name="visible">表示有無プロパティ</param>
		/// <param name="enterStop">移動有無プロパティ</param>
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
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Memers

		private string _key;				// キー
		private int _visiblePosition;		// 表示順序
		private bool _fixedCol;				// 表示固定
		private bool _visible;				// 表示有無
		private bool _enterStop;			// 移動有無

		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>キープロパティ</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>表示順序プロパティ</summary>
		public int VisiblePosition
		{
			get { return this._visiblePosition; }
			set { this._visiblePosition = value; }
		}
		/// <summary>表示固定列プロパティ</summary>
		public bool FixedCol
		{
			get { return this._fixedCol; }
			set { this._fixedCol = value; }
		}
		/// <summary>表示有無プロパティ</summary>
		public bool Visible
		{
			get { return this._visible; }
			set { this._visible = value; }
		}
		/// <summary>移動有無プロパティ</summary>
		public bool EnterStop
		{
			get { return this._enterStop; }
			set { this._enterStop = value; }
		}

		#endregion

	}

	#endregion

	#region ◎列表示基本情報クラス
	/// <summary>
	///	列表示基本情報クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 明細に表示可能なカラムの基本情報を設定する際に使用します。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.07.10</br>
	/// </remarks>
	public class ColDisplayBasicInfo
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ColDisplayBasicInfo()
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="key">キープロパティ</param>
		/// <param name="caption">キャプションプロパティ</param>
		/// <param name="readOnly">読取専用プロパティ</param>
        public ColDisplayBasicInfo(string key, string caption, bool readOnly, DataAttribute attr)
		{
			this._key = key;
			this._caption = caption;
			this._readOnly = readOnly;
            this._attr = attr;
		}
		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private string _key;			// キー
		private string _caption;		// キャプション
		private bool _readOnly;			// 読取専用
        private DataAttribute _attr;    // 属性

		#endregion

        // ===================================================================================== //
        // 列挙型
        // ===================================================================================== //
        #region ■Enums

        /// <summary>
        /// データ属性
        /// </summary>
        public enum DataAttribute : int
        {
            /// <summary>無し</summary>
            None = 0,
            /// <summary>純正部品</summary>
            PureParts = 1,
            /// <summary>優良部品</summary>
            PrimeParts = 2,
        }

        #endregion

        // ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties
		/// <summary>キープロパティ</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>キャプションプロパティ</summary>
		public string Caption
		{
			get { return this._caption; }
			set { this._caption = value; }
		}
		/// <summary>読取専用プロパティ</summary>
		public bool ReadOnly
		{
			get { return this._readOnly; }
			set { this._readOnly = value; }
		}

        /// <summary>データ属性</summary>
        public DataAttribute Attr
        {
            get { return this._attr; }
            set { this._attr = value; }
        }
		#endregion
	}
	#endregion

    #region 検索見積カラム比較用のクラス
    /// <summary>
    /// 検索見積カラム比較クラス(VisiblePosition順)
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
