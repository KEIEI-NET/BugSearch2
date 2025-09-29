using Broadleaf.Library.ComponentModel;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[DefaultEvent("BarcodeReaded"), ToolboxBitmap(typeof(TBarcodeReader), "TBarcodeReader.bmp")]
	public class TBarcodeReader : TbsBaseComponent
	{
		private const int ctImeChangeSleepTime = 600;
		private Container components;
		private TbsMessageFilter _messageFilter;
		private bool _imeOpenStatusBuf;
		private IntPtr _hImc = new IntPtr(0);
		private bool _timeOutFlg_KeyDown;
		private bool _timeOutFlg_KeyPress;
		private bool _isPreReading;
		private bool _catchAllEvents;
		private bool _isReading;
		private bool _monitoring = true;
		private StringBuilder _barcodeString;
        public event EventHandler GetBarcodeNotice;
        public event BarcodeReadedEventHandler BarcodeReaded;
		[Category("Behavior"), DefaultValue(false), Description("監視対象のフォーム以外のバーコード入力でもイベント発生するかどうかを取得、設定します。")]
		public bool CatchAllEvents
		{
			get
			{
				return this._catchAllEvents;
			}
			set
			{
				this._catchAllEvents = value;
			}
		}
		[Browsable(false), Description("バーコード情報の読み込み処理中かどうかを取得します。")]
		public bool IsReading
		{
			get
			{
				return this._isReading;
			}
		}
		[Category("Behavior"), DefaultValue(true), Description("バーコード入力を監視するかどうかを設定、取得します。")]
		public bool Monitoring
		{
			get
			{
				return this._monitoring;
			}
			set
			{
				this._monitoring = value;
			}
		}
		[Browsable(false), Description("読み取りバーコード文字列を取得します。読み取り処理中はnullを返します。")]
		public string BarcodeString
		{
			get
			{
				if (this._isReading)
				{
					return null;
				}
				if (this._barcodeString != null && this._barcodeString.Length > 0)
				{
					return this._barcodeString.ToString();
				}
				return "";
			}
		}
		public override ISynchronizeInvoke OwnerForm
		{
			get
			{
				return base.OwnerForm;
			}
			set
			{
				if (!base.DesignMode)
				{
					if (value == null || value is Form || value is Control)
					{
						this.RemovedHockControl();
						base.OwnerForm = value;
						this.AddedHockControl();
						return;
					}
				}
				else
				{
					base.OwnerForm = value;
				}
			}
		}
		public TBarcodeReader(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			this._messageFilter = TbsMessageFilter.Instance;
			this._messageFilter.KeyPress += new KeyPressEventHandler(this.Owner_KeyPress);
			this._messageFilter.BarcodeKeyDown += new KeyEventHandler(this.Owner_KeyDown);
			this._messageFilter.BarcodeNoticeTimeOut += new HandledEventHandler(this.barcodeNoticeTimeOut);
			this._barcodeString = new StringBuilder();
		}
		public TBarcodeReader()
		{
			this.InitializeComponent();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
				if (this._messageFilter != null)
				{
					this._messageFilter.KeyPress -= new KeyPressEventHandler(this.Owner_KeyPress);
					this._messageFilter.BarcodeKeyDown -= new KeyEventHandler(this.Owner_KeyDown);
					this._messageFilter.BarcodeNoticeTimeOut -= new HandledEventHandler(this.barcodeNoticeTimeOut);
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		private void RemovedHockControl()
		{
			if (base.OwnerForm != null && base.OwnerForm is Control)
			{
				Control control = (Control)base.OwnerForm;
				control.ParentChanged -= new EventHandler(this.Owner_ParentChanged);
			}
		}
		private void AddedHockControl()
		{
			if (base.OwnerForm != null)
			{
				if (base.OwnerForm is Control && !(base.OwnerForm is Form))
				{
					Form form = ((Control)base.OwnerForm).FindForm();
					if (form != null)
					{
						this.OwnerForm = form;
						return;
					}
				}
				if (base.OwnerForm is Control)
				{
					Control control = (Control)base.OwnerForm;
					control.ParentChanged += new EventHandler(this.Owner_ParentChanged);
				}
			}
		}
		private bool CheckControl(Control iCtrl)
		{
			Form form = (Form)base.OwnerForm;
			return iCtrl.Equals(form) || this.CheckControlSub(iCtrl, form);
		}
		private bool CheckControlSub(Control iCtrl, Control iParent)
		{
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				if (iCtrl == iParent.Controls[i])
				{
					return true;
				}
				if (!(iParent.Controls[i] is Form) && this.CheckControlSub(iCtrl, iParent.Controls[i]))
				{
					return true;
				}
			}
			return false;
		}
		private void Owner_ParentChanged(object sender, EventArgs e)
		{
			this.OwnerForm = ((Control)sender).FindForm();
		}
		private void barcodeNoticeTimeOut(object sender, HandledEventArgs e)
		{
			if (this._isReading)
			{
				e.Handled = true;
				return;
			}
			this._timeOutFlg_KeyDown = true;
			this._timeOutFlg_KeyPress = true;
		}
		private void Owner_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!this._monitoring)
			{
				return;
			}
			if (sender == null)
			{
				Form form = base.OwnerForm as Form;
				if (form == null || form.ActiveControl == null)
				{
					return;
				}
				sender = form.ActiveControl;
			}
			if (!this._catchAllEvents && !this.CheckControl((Control)sender))
			{
				return;
			}
			if (this._isReading)
			{
				if (this.CheckEndKeyChar(e.KeyChar))
				{
					this.EndReading(sender);
				}
				else
				{
					if (e.KeyChar != '\0')
					{
						this._barcodeString.Append(e.KeyChar);
					}
				}
				e.Handled = true;
			}
			if (this._timeOutFlg_KeyPress)
			{
				this._isReading = false;
				this._isPreReading = false;
				this._timeOutFlg_KeyPress = false;
				return;
			}
			if (this.CheckNoticeKeyChar(e.KeyChar))
			{
				if (!this._timeOutFlg_KeyDown)
				{
					this._isPreReading = true;
					this._timeOutFlg_KeyPress = false;
					this._messageFilter.BarcodeNoticeTimerOn();
				}
				e.Handled = true;
				return;
			}
			if (this._isPreReading)
			{
				this._isPreReading = false;
				if (e.KeyChar == '0')
				{
					this._messageFilter.BarcodeNoticeTimerOff();
					this.StartReading(sender);
					this._barcodeString.Append(e.KeyChar);
					e.Handled = true;
				}
			}
		}
		private bool CheckNoticeKeyChar(char KeyChar)
		{
			return KeyChar == '^';
		}
		private bool CheckEndKeyChar(char KeyChar)
		{
			return KeyChar == '\r';
		}
		private void Owner_KeyDown(object sender, KeyEventArgs e)
		{
			if (!this._monitoring)
			{
				return;
			}
			if (sender == null)
			{
				Form form = base.OwnerForm as Form;
				if (form == null || form.ActiveControl == null)
				{
					return;
				}
				sender = form.ActiveControl;
			}
			if (!this._catchAllEvents && !this.CheckControl((Control)sender))
			{
				return;
			}
			if (this._isReading && this.CheckEndKey(e.KeyData))
			{
				this.EndReading(sender);
				e.Handled = true;
			}
			if (this._timeOutFlg_KeyDown)
			{
				this._isReading = false;
				this._isPreReading = false;
				this._timeOutFlg_KeyDown = false;
				return;
			}
			if (this.CheckNoticeKey(sender, e.KeyData))
			{
				this._isPreReading = true;
				this._timeOutFlg_KeyDown = false;
				this._messageFilter.BarcodeNoticeTimerOn();
				e.Handled = true;
				return;
			}
			if (this._isPreReading)
			{
				this._isPreReading = false;
				if (e.KeyData == Keys.D0 || e.KeyData == Keys.NumPad0)
				{
					this._messageFilter.BarcodeNoticeTimerOff();
					this.StartReading(sender);
					return;
				}
				if (e.KeyData == Keys.ProcessKey && (SafeNativeMethods.ImmGetVirtualKey(((Control)sender).Handle) == 48 || SafeNativeMethods.ImmGetVirtualKey(((Control)sender).Handle) == 96))
				{
					this._messageFilter.BarcodeNoticeTimerOff();
					this.StartReading(sender);
					this._barcodeString.Append('0');
				}
			}
		}
		private bool CheckNoticeKey(object sender, Keys keyData)
		{
			return keyData == Keys.OemQuotes || (keyData == Keys.ProcessKey && SafeNativeMethods.ImmGetVirtualKey(((Control)sender).Handle) == 222);
		}
		private bool CheckEndKey(Keys keyData)
		{
			return (keyData & Keys.KeyCode) == Keys.Return;
		}
		private void StartReading(object sender)
		{
			if (this._isReading)
			{
				this._barcodeString.Remove(0, this._barcodeString.Length);
				return;
			}
			this._isReading = true;
			this._barcodeString.Remove(0, this._barcodeString.Length);
			if (sender is Control)
			{
				this._hImc = SafeNativeMethods.ImmGetContext(((Control)sender).Handle);
				try
				{
					if (this._hImc != IntPtr.Zero)
					{
						this._imeOpenStatusBuf = SafeNativeMethods.ImmGetOpenStatus(this._hImc);
						if (this._imeOpenStatusBuf)
						{
							SafeNativeMethods.ImmNotifyIME(this._hImc, 21u, 4u, 0u);
							SafeNativeMethods.ImmSetOpenStatus(this._hImc, false);
							Thread.Sleep(600);
						}
					}
				}
				finally
				{
					SafeNativeMethods.ImmReleaseContext(((Control)sender).Handle, this._hImc);
				}
			}
			if (this.GetBarcodeNotice != null)
			{
				this.GetBarcodeNotice(sender, new EventArgs());
			}
		}
		private void EndReading(object sender)
		{
			this._isReading = false;
			if (sender is Control)
			{
				this._hImc = SafeNativeMethods.ImmGetContext(((Control)sender).Handle);
				try
				{
					if (this._hImc != IntPtr.Zero && this._imeOpenStatusBuf)
					{
						SafeNativeMethods.ImmSetOpenStatus(this._hImc, true);
					}
				}
				finally
				{
					SafeNativeMethods.ImmReleaseContext(((Control)sender).Handle, this._hImc);
				}
			}
			if (this.BarcodeReaded != null)
			{
				this.BarcodeReaded(sender, new BarcodeReadedEventArgs(this._barcodeString.ToString()));
			}
		}
	}
}
