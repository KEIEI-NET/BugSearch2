using System;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	public class MouseWheelEventArgsEx : MouseEventArgs
	{
		private bool _shiftKey;
		private bool _ctrlKey;
		private bool _handled;
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
		public MouseWheelEventArgsEx(MouseButtons button, bool shiftKey, bool ctrlKey, int clicks, int x, int y, int delta) : base(button, clicks, x, y, delta)
		{
			this._shiftKey = shiftKey;
			this._ctrlKey = ctrlKey;
			this._handled = false;
		}
	}
}
