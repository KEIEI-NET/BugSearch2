using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	[Serializable]
	/// <summary>
	/// ヘッダー部フォーカス移動設定リストクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ヘッダー部のフォーカス移動を管理するリストクラスです。</br>
	/// <br>Programmer : 20056 對馬 大輔</br>
	/// <br>Date       : 2007.11.06</br>
	/// <br></br>
	/// </remarks>
	public class HeaderFocusConstructionList
	{
		public List<HeaderFocusConstruction> headerFocusConstruction = new List<HeaderFocusConstruction>();
	}

	/// <summary>
	/// ヘッダー部フォーカス移動設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ヘッダー部のフォーカス移動を管理するクラスです。</br>
	/// <br>Programmer : 20056 對馬 大輔</br>
	/// <br>Date       : 2007.11.06</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class HeaderFocusConstruction
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _key;
		private string _caption;
		private bool _enterStop;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ヘッダー部フォーカス移動設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : ヘッダー部フォーカス移動設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 20056 對馬 大輔</br>
		/// <br>Date       : 2007.11.06</br>
		/// </remarks>
		public HeaderFocusConstruction()
		{
			this._key = string.Empty;
			this._caption = string.Empty;
			this._enterStop = true;
		}
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>キー</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>項目表示名称</summary>
		public string Caption
		{
			get { return this._caption; }
			set { this._caption = value; }
		}
		/// <summary>移動有無</summary>
		public bool EnterStop
		{
			get { return this._enterStop; }
			set { this._enterStop = value; }
		}
		# endregion
	}
}
