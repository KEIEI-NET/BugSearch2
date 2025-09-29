using System;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	public class ChangeFocusEventArgs : EventArgs
	{
		private bool FShiftKey;
		private bool FAltKey;
		private bool FControlKey;
		private Keys FKey;
		private Control FPrevCtrl;
		private Control FNextCtrl;
		public bool ShiftKey
		{
			get
			{
				return this.FShiftKey;
			}
		}
		public bool AltKey
		{
			get
			{
				return this.FAltKey;
			}
		}
		public bool ControlKey
		{
			get
			{
				return this.FControlKey;
			}
		}
		public Keys Key
		{
			get
			{
				return this.FKey;
			}
		}
		public Control PrevCtrl
		{
			get
			{
				return this.FPrevCtrl;
			}
		}
		public Control NextCtrl
		{
			get
			{
				return this.FNextCtrl;
			}
			set
			{
				this.FNextCtrl = value;
			}
		}
		public ChangeFocusEventArgs(bool iShiftKey, bool iAltKey, bool iControlKey, Keys iKeyCode, Control iPrevCtrl, Control iNextCtrl)
		{
			this.FShiftKey = iShiftKey;
			this.FAltKey = iAltKey;
			this.FControlKey = iControlKey;
			this.FKey = iKeyCode;
			this.FPrevCtrl = iPrevCtrl;
			this.FNextCtrl = iNextCtrl;
		}
	}
}
