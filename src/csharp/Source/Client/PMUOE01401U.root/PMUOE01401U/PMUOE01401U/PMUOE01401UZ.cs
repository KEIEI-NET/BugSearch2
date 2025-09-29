//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ復旧処理データテーブル列表示コントロールクラス
// プログラム概要   : ＵＯＥ復旧処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// データテーブル列表示コントロールクラス
	/// </summary>
	internal class ProductStockRowVisibleControl
	{
		private Dictionary<StockDetailColStatusKey, bool> _statusDictionary = new Dictionary<StockDetailColStatusKey, bool>();

		/// <summary>
		/// 列表示非表示設定値追加処理
		/// </summary>
		/// <param name="colName">列名称</param>
		/// <param name="statusType">ステータスタイプ</param>
		/// <param name="value">値</param>
		/// <param name="hidden">表示非表示設定値</param>
		internal void Add(string colName, StatusType statusType, int value, bool hidden)
		{
			StockDetailColStatusKey key = new StockDetailColStatusKey(colName, statusType, value);

			if (this._statusDictionary.ContainsKey(key))
			{
				this._statusDictionary[key] = hidden;
			}
			else
			{
				this._statusDictionary.Add(key, hidden);
			}
		}

		/// <summary>
		/// 列表示非表示設定値取得処理
		/// </summary>
		/// <param name="colName">列名称</param>
		/// <param name="statusType">ステータスタイプ</param>
		/// <param name="value">値</param>
		/// <param name="visible">表示非表示設定値</param>
		/// <returns>0:取得可能 0以外:取得失敗</returns>
		internal int GetHidden(string colName, StatusType statusType, int value, out bool hidden)
		{
			StockDetailColStatusKey key = new StockDetailColStatusKey(colName, statusType, value);

			if (this._statusDictionary.ContainsKey(key))
			{
				hidden = this._statusDictionary[key];
				return 0;
			}
			else
			{
				hidden = true;
				return -1;
			}
		}
	}

	/// <summary>
	/// データテーブル列ステータスキー構造体
	/// </summary>
	internal struct StockDetailColStatusKey
	{
		string _colName;
		StatusType _statusType;
		int _value;

		/// <summary>
		/// 仕入明細データテーブル列ステータスキー構造体コンストラクタ
		/// </summary>
		/// <param name="colName">列名称</param>
		/// <param name="statusType">ステータスタイプ</param>
		/// <param name="value">値</param>
		internal StockDetailColStatusKey(string colName, StatusType statusType, int value)
		{
			this._colName = colName;
			this._statusType = statusType;
			this._value = value;
		}

		/// <summary>列名称プロパティ</summary>
		internal string ColName
		{
			get { return _colName; }
			set { _colName = value; }
		}

		/// <summary>ステータスタイププロパティ</summary>
		internal StatusType StatusType
		{
			get { return _statusType; }
			set { _statusType = value; }
		}

		/// <summary>値プロパティ</summary>
		internal int Value
		{
			get { return _value; }
			set { _value = value; }
		}
	}

	/// <summary>
	/// コンボエディタデータ取得タイプ
	/// </summary>
	internal enum StatusType : int
	{
		Default = 0,
		StockGoodsCd = 1,
		ProductNumberInput = 2,
		SupplierFormal = 3,
        StockDate = 4,
        StoockDiv = 5

	}
}
