using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	///	列表示情報クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : フォーカス制御設定グリッド用のリスト、テーブルクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// </remarks>
	public class ColDisplayInfo
	{
		#region ■Private Members
		private string _key;
		private int _visiblePosition;
		private bool _fixedCol;
		private string _caption;
		private bool _visible;
		private bool _visibleControl;
		private bool _enterStop;
		private bool _enterStopControl;
		#endregion

		#region ■Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ColDisplayInfo()
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="key"></param>
		/// <param name="caption"></param>
		/// <param name="visiblePosition"></param>
		/// <param name="fixedcol"></param>
		/// <param name="visible"></param>
		/// <param name="visibleControl"></param>
		/// <param name="enterStop"></param>
		public ColDisplayInfo( string key, string caption, int visiblePosition, bool fixedcol, bool visible, bool visibleControl, bool enterStop, bool enterStopControl )
		{
			this._key = key;
			this._caption = caption;
			this._visiblePosition = visiblePosition;
			this._fixedCol = fixedcol;
			this._visible = visible;
			this._visibleControl = visibleControl;
			this._enterStop = enterStop;
			this._enterStopControl = enterStopControl;
		}
		#endregion

		#region ■Properties
		/// <summary>キー</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>キャプション</summary>
		public string Caption
		{
			get { return this._caption; }
			set { this._caption = value; }
		}
		/// <summary>表示位置</summary>
		public int VisiblePosition
		{
			get { return this._visiblePosition; }
			set { this._visiblePosition = value; }
		}
		/// <summary>固定列（順序入れ替え、移動、表示の不可)</summary>
		public bool FixedCol
		{
			get { return this._fixedCol; }
			set { this._fixedCol = value; }
		}
		/// <summary>表示有無</summary>
		public bool Visible
		{
			get { return this._visible; }
			set { this._visible = value; }
		}
		/// <summary>移動有無</summary>
		public bool EnterStop
		{
			get { return this._enterStop; }
			set { this._enterStop = value; }
		}
		/// <summary>移動変更可否</summary>
		public bool EnterStopControl
		{
			get { return this._enterStopControl; }
			set { this._enterStopControl = value; }
		}

		/// <summary>表示変更可否</summary>
		public bool VisibleControl
		{
			get { return this._visibleControl; }
			set { this._visibleControl = value; }
		}
		#endregion
		
	}
}
