using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// グリッド列外観設定クラス
	/// </summary>
	public class GridColAppearance
	{
		#region << Constructor >>

		/// <summary>
		/// グリッド列外観設定クラスコンストラクタ
		/// </summary>
		public GridColAppearance()
		{
		}

		/// <summary>
		/// グリッド列外観設定クラスコンストラクタ
		/// </summary>
		/// <param name="displayIndex">表示インデックス</param>
		/// <param name="caption">キャプション</param>
		/// <param name="alignment">セルの内容の表示位置</param>
		/// <param name="format">セルに適用する書式指定文字列</param>
		/// <param name="foreColor">セルの前景色</param>
		/// <param name="selectionForeColor">選択時のセルの前景色</param>
		public GridColAppearance( int displayIndex, string caption, DataGridViewContentAlignment alignment, string format, Color foreColor, Color selectionForeColor )
		{
			this._displayIndex       = displayIndex;
			this._caption            = caption;
			this._alignment          = alignment;
			this._format             = format;
			this._foreColor          = foreColor;
			this._selectionForeColor = selectionForeColor;
		}

		#endregion

		#region << Private Members >>

		/// <summary>表示インデックス</summary>
		private int                          _displayIndex       = 0;

		/// <summary>キャプション</summary>
		private string                       _caption            = String.Empty;

		/// <summary>セルの内容の表示位置</summary>
		private DataGridViewContentAlignment _alignment          = DataGridViewContentAlignment.NotSet;

		/// <summary>セルに適用する書式指定文字列</summary>
		private string                       _format             = String.Empty;

		/// <summary>セルの前景色</summary>
		private Color                        _foreColor          = Color.Empty;

		/// <summary>選択時のセルの前景色</summary>
		private Color                        _selectionForeColor = Color.Empty;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// 表示インデックス
		/// </summary>
		public int DisplayIndex
		{
			get {
				return this._displayIndex;
			}
			set {
				this._displayIndex = value;
			}
		}

		/// <summary>
		/// キャプション
		/// </summary>
		public string Caption
		{
			get {
				return this._caption;
			}
			set {
				this._caption = value;
			}
		}

		/// <summary>
		/// セルの内容の表示位置プロパティ
		/// </summary>
		public DataGridViewContentAlignment Alignment
		{
			get {
				return this._alignment;
			}
			set {
				this._alignment = value;
			}
		}

		/// <summary>
		/// セルに適用する書式指定文字列プロパティ
		/// </summary>
		public string Format
		{
			get {
				return this._format;
			}
			set {
				this._format = value;
			}
		}

		/// <summary>
		/// セルの前景色プロパティ
		/// </summary>
		public Color ForeColor
		{
			get {
				return this._foreColor;
			}
			set {
				this._foreColor = value;
			}
		}

		/// <summary>
		/// 選択時のセルの前景色プロパティ
		/// </summary>
		public Color SelectionForeColor
		{
			get {
				return this._selectionForeColor;
			}
			set {
				this._selectionForeColor = value;
			}
		}

		#endregion
	}
}
