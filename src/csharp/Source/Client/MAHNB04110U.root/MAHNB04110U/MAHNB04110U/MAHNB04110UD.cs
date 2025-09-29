using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上伝票検索用設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上伝票検索のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2007.01.11</br>
	/// <br></br>
	/// </remarks>
	public class SalesSearchConstructionAcs
	{
		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region Public Const
		/// <summary>詳細条件表示（する）</summary>
		public const int DetailConditionOpen_ON = 0;

		/// <summary>詳細条件表示（しない）</summary>
		public const int DetailConditionOpen_OFF = 1;

		/// <summary>抽出条件変更時自動検索（する）</summary>
		public const int DataChangedAutoSearch_ON = 0;

		/// <summary>抽出条件変更時自動検索（しない）</summary>
		public const int DataChangedAutoSearch_OFF = 1;

		/// <summary>起動時自動検索（する）</summary>
		public const int ExecAutoSearch_ON = 0;

		/// <summary>起動時自動検索（しない）</summary>
		public const int ExecAutoSearch_OFF = 1;

		/// <summary>伝票日付範囲指定（なし）</summary>
		public const int SearchSlipDateStartRange_None = 0;

		/// <summary>伝票日付範囲指定（本日）</summary>
		public const int SearchSlipDateStartRange_Today = 1;

		/// <summary>伝票日付範囲指定（１週間）</summary>
		public const int SearchSlipDateStartRange_Week = 2;

		/// <summary>伝票日付範囲指定（１ヶ月）</summary>
		public const int SearchSlipDateStartRange_Month = 3;

		/// <summary>計上日範囲指定（なし）</summary>
		public const int AddUpADateStartRange_None = 0;

		/// <summary>計上日範囲指定（本日）</summary>
		public const int AddUpADateStartRange_Today = 1;

		/// <summary>計上日範囲指定（１週間）</summary>
		public const int AddUpADateStartRange_Week = 2;

		/// <summary>計上日範囲指定（１ヶ月）</summary>
		public const int AddUpADateStartRange_Month = 3;

		/// <summary>レジ処理日範囲指定（なし）</summary>
		public const int RegiProcDateStartRange_None = 0;

		/// <summary>レジ処理日範囲指定（本日）</summary>
		public const int RegiProcDateStartRange_Today = 1;

		/// <summary>レジ処理日範囲指定（１週間）</summary>
		public const int RegiProcDateStartRange_Week = 2;

		/// <summary>レジ処理日範囲指定（１ヶ月）</summary>
		public const int RegiProcDateStartRange_Month = 3;
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private SalesSearchConstruction _salesSearchConstruction;
		private static SalesSearchConstructionAcs _salesSearchConstructionAcs;
		private const string XML_FILE_NAME = "MAHNB04110U_Construction.XML";
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 売上伝票検索用ユーザー設定クラスアクセスクラス（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private SalesSearchConstructionAcs()
		{
			_salesSearchConstruction = new SalesSearchConstruction();
			this.Deserialize();
		}

		/// <summary>
		/// 売上伝票検索用ユーザー設定アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns>売上伝票検索用ユーザー設定アクセスクラス インスタンス</returns>
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
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>データ変更後発生イベント</summary>
		public event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// 売上伝票検索用ユーザー設定クラス
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

		/// <summary>伝票日付範囲指定</summary>
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

		/// <summary>計上日範囲指定</summary>
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

		/// <summary>レジ処理日範囲指定</summary>
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

		/// <summary>詳細条件表示</summary>
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

		/// <summary>抽出条件変更時自動検索</summary>
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

		/// <summary>付属情報入力自動起動</summary>
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
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 売上伝票検索用ユーザー設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上伝票検索用ユーザー設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2007.01.11</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_salesSearchConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// データ変更後発生イベント実行
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// 売上伝票検索用ユーザー設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上伝票検索用ユーザー設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
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
