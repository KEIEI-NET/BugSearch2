using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;


namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// 列表示状態クラス拡張
	/// </summary>
	/// <remarks>
	/// <br>Note       : 列表示状態クラスの拡張クラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// </remarks>
	[Serializable]
	public class ColDisplayStatusExp : ColDisplayStatus
	{

		#region Private Members

		private bool _readOnly = true;
		private bool _visible = false;
		private bool _enterStop = false;

		#endregion

		#region Constructor
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ColDisplayStatusExp()
			: base()
		{

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="key"></param>
		/// <param name="visiblePosition"></param>
		/// <param name="headerFixed"></param>
		/// <param name="width"></param>
		/// <param name="readOnly"></param>
		/// <param name="visible"></param>
		/// <param name="enterStop"></param>
		public ColDisplayStatusExp( string key, Int32 visiblePosition, bool headerFixed, Int32 width, bool readOnly, bool visible, bool enterStop )
			: base(key, visiblePosition, headerFixed, width)
		{
			_visible = visible;
			_enterStop = enterStop;
			_readOnly = readOnly;
		}
		#endregion

		#region Property
		/// <summary>
		/// 列表示プロパティ
		/// </summary>
		public bool Visible
		{
			get { return _visible; }
			set { _visible = value; }
		}
		/// <summary>
		/// Enterキー移動プロパティ
		/// </summary>
		public bool EnterStop
		{
			get { return _enterStop; }
			set { _enterStop = value; }
		}
		/// <summary>
		/// 制御対象プロパティ
		/// </summary>
		public bool ReadOnly
		{
			get { return _readOnly; }
			set { _readOnly = value; }
		}
		#endregion

	}

}

