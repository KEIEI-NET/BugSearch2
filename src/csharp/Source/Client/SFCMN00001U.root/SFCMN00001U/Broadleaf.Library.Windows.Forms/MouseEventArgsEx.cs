using System;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	internal class MouseEventArgsEx : MouseEventArgs
	{
		private bool _handled;
		private bool _shiftKey;
		private bool _ctrlKey;
		public bool ShiftKey
		{
			get
			{
				return this._shiftKey;
			}
			set
			{
				this._shiftKey = value;
			}
		}
		public bool CtrlKey
		{
			get
			{
				return this._ctrlKey;
			}
			set
			{
				this._ctrlKey = value;
			}
		}
		public bool Handled
		{
			get
			{
				return this._handled;
			}
			set
			{
				this._handled = value;
			}
		}
		public MouseEventArgsEx(MouseButtons button, int clicks, int x, int y, int delta) : base(button, clicks, x, y, delta)
		{
			this._handled = false;
			this._shiftKey = false;
			this._ctrlKey = false;
		}
	}
}
