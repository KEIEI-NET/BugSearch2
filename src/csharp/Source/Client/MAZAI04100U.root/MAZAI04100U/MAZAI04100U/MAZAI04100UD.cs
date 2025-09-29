using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫移動入力画面用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫移動入力画面のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.12.05</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class StockMoveInputInputConstruction
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private int _functionMode;

        private const int DEFAULT_FUNCTIONMODE_VALUE = 0;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 在庫移動入力画面用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫移動入力画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public StockMoveInputInputConstruction()
		{
            this._functionMode = DEFAULT_FUNCTIONMODE_VALUE;
		}

		/// <summary>
		/// 在庫移動入力画面用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫移動入力画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public StockMoveInputInputConstruction(int functionMode)
		{
            this._functionMode = functionMode;
        }
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>ファンクションモードプロパティ</summary>
		public int FunctionMode
		{
            get { return this._functionMode; }
            set { this._functionMode = value; }
		}
		# endregion

		/// <summary>
		/// 在庫移動入力画面用ユーザー設定クラス複製処理
		/// </summary>
		/// <returns>在庫移動入力画面用ユーザー設定クラス</returns>
		public StockMoveInputInputConstruction Clone()
		{
            return new StockMoveInputInputConstruction( this._functionMode );
		}
	}

	/// <summary>
	/// 在庫移動入力画面用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫移動入力画面のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2004.04.19</br>
	/// <br></br>
	/// </remarks>
	public class StockMoveInputConstructionAcs
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private static StockMoveInputInputConstruction _customerInputConstruction;
		private const string XML_FILE_NAME = "MAZAI04100U_Construction.XML";
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 在庫移動入力画面用ユーザー設定クラスアクセスクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫移動入力画面用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public StockMoveInputConstructionAcs()
		{
			if (_customerInputConstruction == null)
			{
				_customerInputConstruction = new StockMoveInputInputConstruction();
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
        public int FunctionMode
		{
			get
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new StockMoveInputInputConstruction();
				}
				return _customerInputConstruction.FunctionMode;
			}
			set
			{
				if (_customerInputConstruction == null)
				{
					_customerInputConstruction = new StockMoveInputInputConstruction();
				}
                _customerInputConstruction.FunctionMode = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 在庫移動入力画面用ユーザー設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫移動入力画面用ユーザー設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 980079 鈴木 正臣</br>
		/// <br>Date       : 2007.12.05</br>
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
		/// 在庫移動入力画面用ユーザー設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫移動入力画面用ユーザー設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 980079 鈴木 正臣</br>
		/// <br>Date       : 2007.12.05</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				_customerInputConstruction = UserSettingController.DeserializeUserSetting<StockMoveInputInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
			}
		}
		# endregion
	}
}
