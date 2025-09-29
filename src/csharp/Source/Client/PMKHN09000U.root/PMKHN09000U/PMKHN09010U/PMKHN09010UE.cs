using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 選択コード変更時イベントパラメータクラス
	/// </summary>
	public class CustomerSelectCodeChangeCtlEventArgs : EventArgs
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="code">コード（得意先コード）</param>
		/// <param name="updateDateTime">更新日</param>
		public CustomerSelectCodeChangeCtlEventArgs(int code, DateTime updateDateTime)
		{
			this._code = code;
			this._updateDateTime = updateDateTime;
		}

		private int _code;
		private DateTime _updateDateTime;

		/// <summary>
		/// コードプロパティ（得意先コード）
		/// </summary>
		public int Code
		{
			get
			{
				return this._code;
			}
			set
			{
				this._code = value;
			}
		}

		/// <summary>
		/// 更新日時
		/// </summary>
		public DateTime UpdateDateTime
		{
			get
			{
				return this._updateDateTime;
			}
			set
			{
				this._updateDateTime = value;
			}
		}
	}

}
