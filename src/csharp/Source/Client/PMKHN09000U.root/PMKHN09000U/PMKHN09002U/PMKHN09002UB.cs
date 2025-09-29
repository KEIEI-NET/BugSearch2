using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先画面用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先画面のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2008.04.30</br>
    /// <br>UpdateNote : 2011/08/04 caohh</br>
    /// <br>             NSユーザー改良要望一覧連番265の対応</br>
	/// </remarks>
	[Serializable]
	public class CustomerInputConstruction
	{
		// ===================================================================================== //
		// プライベート変数
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
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 得意先画面用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
		public CustomerInputConstruction()
		{
			this._inputTypeValue = DEFAULT_INPUTTYPE_VALUE;
			this._firstDisplayTabValue = DEFAULT_FIRSTDISPLAYTAB_VALUE;
            this._keepOnInfoSettingValue = DEFAULT_KEEPONINFOSETTING_VALUE;   // ADD caohh 2011/08/04
		}

		/// <summary>
		/// 得意先画面用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>入力方法設定値プロパティ</summary>
		public int InputTypeValue
		{
			get{ return this._inputTypeValue; }
			set{ this._inputTypeValue = value; }
		}

		/// <summary>初期表示タブプロパティ</summary>
		public int FirstDisplayTabValue
		{
			get { return this._firstDisplayTabValue; }
			set { this._firstDisplayTabValue = value; }
		}

        // --- ADD caohh 2011/08/02 ------------------------------------------------------>>>>>
        /// <summary>前回情報保持設定プロパティ</summary>
        public int KeepOnInfoSettingValue
        {
            get { return this._keepOnInfoSettingValue; }
            set { this._keepOnInfoSettingValue = value; }
        }
        // --- ADD caohh 2011/08/02 ------------------------------------------------------<<<<<
		# endregion

		/// <summary>
		/// 得意先画面用ユーザー設定クラス複製処理
		/// </summary>
		/// <returns>得意先画面用ユーザー設定クラス</returns>
		public CustomerInputConstruction Clone()
		{
            //return new CustomerInputConstruction(this._inputTypeValue, this._firstDisplayTabValue);// DEL caohh 2011/08/04
            return new CustomerInputConstruction(this._inputTypeValue, this._firstDisplayTabValue, this._keepOnInfoSettingValue);// ADD caohh 2011/08/04
		}
	}

	/// <summary>
	/// 得意先画面用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先画面のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2008.04.30</br>
    /// <br>UpdateNote : 2011/08/04 caohh</br>
    /// <br>             NSユーザー改良要望一覧連番265の対応</br>
	/// </remarks>
	public class CustomerInputConstructionAcs
	{
		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region Public Const
		/// <summary>入力タイプ（自動）</summary>
		public const int INPUT_TYPE_AUTO   = 0;

		/// <summary>入力タイプ（タブ固定）</summary>
		public const int INPUT_TYPE_TAB    = 1;

		/// <summary>入力タイプ（スクロール固定）</summary>
		public const int INPUT_TYPE_SCROLL = 2;

        /// <summary>初期表示タブ・デフォルト（0:連絡先）</summary>
        public const int FIRST_DISPLAY_TAB_DEFAULT = 0;

        // --- ADD caohh 2011/08/02 ------------------------------------------------------>>>>>
        /// <summary>前回情報保持設定・デフォルト（0:得意先コード以外を保持）</summary>
        public const int KEEPONINFOSETTING_DEFAULT = 0;
        // --- ADD caohh 2011/08/02 ------------------------------------------------------<<<<<
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private static CustomerInputConstruction _customerInputConstruction;
		private const string XML_FILE_NAME = "PMKHN09000U_Construction.XML";
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 得意先画面用ユーザー設定クラスアクセスクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先画面用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
		/// <summary>入力方法設定値プロパティ</summary>
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

		/// <summary>初期表示タブ設定値プロパティ</summary>
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
        /// <summary>前回情報保持設定プロパティ</summary>
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
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 得意先画面用ユーザー設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先画面用ユーザー設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_customerInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// データ変更後発生イベント実行
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// 得意先画面用ユーザー設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先画面用ユーザー設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
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
