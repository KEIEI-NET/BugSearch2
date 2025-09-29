using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先検索用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先検索用のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2006.08.24</br>
	/// <br></br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
    /// <br>             MANTIS:14678 自動検索，複数選択の初期値設定を可能とする</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	[Serializable]
	public class CustomerSearchConstruction
	{
		// ===================================================================================== //
		// プライベート変数
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
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 得意先検索用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先検索用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
		/// 得意先検索用ユーザー設定クラス
		/// </summary>
		/// <param name="stringSearchInitialTypeValue">詳細表示初期設定値</param>
        /// <param name="firstDisplayDetailsValue">文字列検索方法初期値</param>
        /// <param name="autoSearchValue">自動検索初期値</param>
        /// <param name="multiSelectValue">複数選択方法初期値</param>
        /// <remarks>
		/// <br>Note       : 得意先検索用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>詳細表示初期設定プロパティ</summary>
		public int FirstDisplayDetailsValue
		{
			get { return this._firstDisplayDetailsValue; }
			set { this._firstDisplayDetailsValue = value; }
		}

		/// <summary>文字列検索方法初期値プロパティ</summary>
		public int stringSearchInitialTypeValue
		{
			get { return this._stringSearchInitialTypeValue; }
			set { this._stringSearchInitialTypeValue = value; }
		}

        // 2009/12/02 Add >>>
        /// <summary>自動検索初期値プロパティ</summary>
        public int autoSearchValue
        {
            get { return this._autoSearchValue; }
            set { this._autoSearchValue = value; }
        }

        /// <summary>複数選択初期値プロパティ</summary>
        public int multiSelectValue
        {
            get { return this._multiSelectValue; }
            set { this._multiSelectValue = value; }
        }
        // 2009/12/02 Add <<<

		/// <summary>
		/// 得意先検索用ユーザー設定クラス複製処理
		/// </summary>
		/// <returns>得意先検索用ユーザー設定クラス</returns>
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
	/// 得意先検索用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先検索のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2006.08.24</br>
	/// <br>Update Note: </br>
	/// <br>2006.11.27 men コンストラクタにてXMLのパスを取得するように改良（在庫部品対応）</br>
	/// </remarks>
	public class CustomerSearchConstructionAcs
	{
		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region Public Const
		/// <summary>詳細表示初期設定（抽出結果ウィンドウ内で表示する）</summary>
		public static readonly int FIRST_DISPLAY_DETAILS_0 = 0;

		/// <summary>詳細表示初期設定（別ウィンドウで表示する定）</summary>
		public static readonly int FIRST_DISPLAY_DETAILS_1 = 1;

		/// <summary>詳細表示初期設定（表示しない）</summary>
		public static readonly int FIRST_DISPLAY_DETAILS_2 = 2;

		/// <summary>文字列検索方法初期値（先頭一致検索）</summary>
		public static readonly int STRING_SEARCH_INITIAL_TYPE_0 = 0;

		/// <summary>文字列検索方法初期値（曖昧検索）</summary>
		public static readonly int STRING_SEARCH_INITIAL_TYPE_1 = 1;

        // 2009/12/02 Add >>>
        /// <summary>自動検索初期値（有り）</summary>
        public static readonly int AUTO_SEARCH_0 = 0;

        /// <summary>自動検索初期値（無し）</summary>
        public static readonly int AUTO_SEARCH_1 = 1;

        /// <summary>複数選択初期値（有り）</summary>
        public static readonly int MULTI_SEARCH_0 = 0;

        /// <summary>複数選択初期値（無し）</summary>
        public static readonly int MULTI_SEARCH_1 = 1;
        // 2009/12/02 Add <<<
        # endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private static CustomerSearchConstruction _customerSearchConstruction;
		private const string XML_FILE_NAME = "PMKHN04001U_Construction.XML";
		private string _xmlFileName = "";
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 得意先検索用ユーザー設定クラスアクセスクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先検索用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
		/// 得意先検索用ユーザー設定クラスアクセスクラス
		/// </summary>
		/// <param name="xmlFileName">XMLファイル名</param>
		/// <remarks>
		/// <br>Note       : 得意先検索用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>データ変更後発生イベント</summary>
		public static event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>詳細表示初期設定値プロパティ</summary>
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

		/// <summary>文字列検索方法初期値プロパティ</summary>
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
        /// <summary>自動検索初期値プロパティ</summary>
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

        /// <summary>複数選択初期値プロパティ</summary>
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
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 得意先検索用ユーザー設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先検索用ユーザー設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
		/// <br>Date       : 2006.08.24</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_customerSearchConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

			if (DataChanged != null)
			{
				// データ変更後発生イベント実行
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// 得意先検索用ユーザー設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先検索用ユーザー設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
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
