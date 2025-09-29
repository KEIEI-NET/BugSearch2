using System;
namespace Broadleaf.Library.Windows.Forms
{
	public class BarcodeReadedEventArgs : EventArgs
	{
		private string _barcodeString;
		public string BarcodeString
		{
			get
			{
				return this._barcodeString;
			}
		}
		public BarcodeReadedEventArgs()
		{
			this._barcodeString = "";
		}
		public BarcodeReadedEventArgs(string barcodeString)
		{
			this._barcodeString = barcodeString;
		}
	}
}
