using System;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	internal class TImeMessageFilter : IMessageFilter
	{
		public delegate void ImeMessage(Message msg);
		private const int WM_IME_COMPOSITION = 271;
		private const int WM_IME_CHAR = 10351;
		private const int WM_CHAR = 4143;
		public TImeMessageFilter.ImeMessage ImeComposition;
		public bool PreFilterMessage(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 271)
			{
				this.ImeComposition(m);
			}
			return false;
		}
	}
}
