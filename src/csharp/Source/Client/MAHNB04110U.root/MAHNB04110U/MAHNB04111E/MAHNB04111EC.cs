using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 売上伝票検索用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上伝票検索のユーザー設定情報を管理するクラスです。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2007.06.18</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class SalesSearchConstruction
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private int _searchSlipDateStartRangeValue = DEFAULT_SearchSlipDateStartRange_VALUE;
		private int _addUpADateStartRangeValue = DEFAULT_AddUpADateStartRange_VALUE;
		private int _regiProcDateStartRangeValue = DEFAULT_RegiProcDateStartRange_VALUE;
		private int _detailConditionOpenValue = DEFAULT_DetailConditionOpen_VALUE;
		private int _dataChangedAutoSearchValue = DEFAULT_DataChangedAutoSearch_VALUE;
		private int _execAutoSearchValue = DEFAULT_ExecAutoSearch_VALUE;

		private const int DEFAULT_SearchSlipDateStartRange_VALUE = 2;
		private const int DEFAULT_AddUpADateStartRange_VALUE = 0;
		private const int DEFAULT_RegiProcDateStartRange_VALUE = 0;
		private const int DEFAULT_DetailConditionOpen_VALUE = 1;
		private const int DEFAULT_DataChangedAutoSearch_VALUE = 1;
		private const int DEFAULT_ExecAutoSearch_VALUE = 1;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 売上伝票検索用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上伝票検索用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2007.01.11</br>
		/// </remarks>
		public SalesSearchConstruction()
		{
			this._searchSlipDateStartRangeValue = DEFAULT_SearchSlipDateStartRange_VALUE;
			this._addUpADateStartRangeValue = DEFAULT_AddUpADateStartRange_VALUE;
			this._regiProcDateStartRangeValue = DEFAULT_RegiProcDateStartRange_VALUE;
			this._detailConditionOpenValue = DEFAULT_DetailConditionOpen_VALUE;
			this._dataChangedAutoSearchValue = DEFAULT_DataChangedAutoSearch_VALUE;
			this._execAutoSearchValue = DEFAULT_ExecAutoSearch_VALUE;
		}

		/// <summary>
		/// 売上伝票検索用ユーザー設定クラス
		/// </summary>
		/// <param name="searchSlipDateStartRangeValue">伝票日付範囲指定</param>
		/// <param name="addUpADateStartRangetValue">計上日範囲指定</param>
		/// <param name="regiProcDateStartRangeValue">レジ処理日範囲指定</param>
		/// <param name="detailConditionOpenValue">詳細条件表示</param>
		/// <param name="dataChangedAutoSearchValue">抽出条件変更時自動検索</param>
		/// <param name="execAutoSearchValue">起動時自動検索</param>
		/// <remarks>
		/// <br>Note       : 売上伝票検索用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2007.01.11</br>
		/// </remarks>
		public SalesSearchConstruction(int searchSlipDateStartRangeValue, int addUpADateStartRangetValue, int regiProcDateStartRangeValue, int detailConditionOpenValue, int dataChangedAutoSearchValue, int execAutoSearchValue)
		{
			this._searchSlipDateStartRangeValue = searchSlipDateStartRangeValue;
			this._addUpADateStartRangeValue = addUpADateStartRangetValue;
			this._regiProcDateStartRangeValue = regiProcDateStartRangeValue;
			this._detailConditionOpenValue = detailConditionOpenValue;
			this._dataChangedAutoSearchValue = dataChangedAutoSearchValue;
			this._execAutoSearchValue = execAutoSearchValue;
		}
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>伝票日付範囲指定</summary>
		public int SearchSlipDateStartRange
		{
			get { return this._searchSlipDateStartRangeValue; }
			set { this._searchSlipDateStartRangeValue = value; }
		}

		/// <summary>計上日範囲指定</summary>
		public int AddUpADateStartRangeValue
		{
			get { return this._addUpADateStartRangeValue; }
			set { this._addUpADateStartRangeValue = value; }
		}

		/// <summary>レジ処理日範囲指定</summary>
		public int RegiProcDateStartRangeValue
		{
			get { return this._regiProcDateStartRangeValue; }
			set { this._regiProcDateStartRangeValue = value; }
		}

		/// <summary>詳細条件表示</summary>
		public int DetailConditionOpenValue
		{
			get { return this._detailConditionOpenValue; }
			set { this._detailConditionOpenValue = value; }
		}

		/// <summary>抽出条件変更時自動検索</summary>
		public int DataChangedAutoSearchValue
		{
			get { return this._dataChangedAutoSearchValue; }
			set { this._dataChangedAutoSearchValue = value; }
		}

		/// <summary>起動時自動検索</summary>
		public int ExecAutoSearchValue
		{
			get { return this._execAutoSearchValue; }
			set { this._execAutoSearchValue = value; }
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 売上伝票検索用ユーザー設定クラス複製処理
		/// </summary>
		/// <returns>売上伝票検索用ユーザー設定クラス</returns>
		public SalesSearchConstruction Clone()
		{
			return new SalesSearchConstruction(
				this._searchSlipDateStartRangeValue,
				this._addUpADateStartRangeValue,
				this._regiProcDateStartRangeValue,
				this._detailConditionOpenValue,
				this._dataChangedAutoSearchValue,
				this._execAutoSearchValue);
		}
		# endregion
	}
}
