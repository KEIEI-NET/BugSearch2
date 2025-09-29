using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	public sealed class TbsMessageFilter : IMessageFilter
	{
		private const int WM_KEYDOWN = 256;
		private const int WM_KEYUP = 257;
		private const int WM_CHAR = 258;
		private const int WM_LBUTTONDOWN = 513;
		private const int WM_LBUTTONDBLCLK = 515;
		private const int WM_RBUTTONDOWN = 516;
		private const int WM_RBUTTONDBLCLK = 518;
		private const int WM_MOUSEWHEEL = 522;
		private const int VK_SHIFT = 16;
		private const int VK_CONTROL = 17;
		private const int VK_MENU = 18;
		private const int MK_LBUTTON = 1;
		private const int MK_RBUTTON = 2;
		private const int MK_SHIFT = 4;
		private const int MK_CONTROL = 8;
		private const int MK_MBUTTON = 16;
		private const int MK_XBUTTON1 = 32;
		private const int MK_XBUTTON2 = 64;
		private const int ctTimerTickSpan = 70;
		private static readonly TbsMessageFilter _instance;
		private KeyEventHandler _keyDown;
		private KeyPressEventHandler _keyPress;
		private KeyEventHandler _barcodeKeyDown;
		private KeyEventHandler _toolbarKeyDown;
		private KeyEventHandlerEx _helpKeyDown;
		private MouseEventHandlerEx _mouseDown;
		private MouseEventHandlerEx _mouseDoubleClick;
		private MouseEventHandlerEx _mouseWheel;
		private HandledEventHandler _barcodeNoticeTimeOut;
		private static object syncRoot;
		private static System.Threading.Timer _barcodeNoticeTimeOutTimer;
		internal event KeyEventHandler KeyDown
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._keyDown = (KeyEventHandler)Delegate.Combine(this._keyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._keyDown = (KeyEventHandler)Delegate.Remove(this._keyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event KeyPressEventHandler KeyPress
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._keyPress = (KeyPressEventHandler)Delegate.Combine(this._keyPress, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._keyPress = (KeyPressEventHandler)Delegate.Remove(this._keyPress, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event KeyEventHandler BarcodeKeyDown
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._barcodeKeyDown = (KeyEventHandler)Delegate.Combine(this._barcodeKeyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._barcodeKeyDown = (KeyEventHandler)Delegate.Remove(this._barcodeKeyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event KeyEventHandler ToolbarKeyDown
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._toolbarKeyDown = (KeyEventHandler)Delegate.Combine(this._toolbarKeyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._toolbarKeyDown = (KeyEventHandler)Delegate.Remove(this._toolbarKeyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event KeyEventHandlerEx HelpKeyDown
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._helpKeyDown = (KeyEventHandlerEx)Delegate.Combine(this._helpKeyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._helpKeyDown = (KeyEventHandlerEx)Delegate.Remove(this._helpKeyDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event MouseEventHandlerEx MouseDown
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._mouseDown = (MouseEventHandlerEx)Delegate.Combine(this._mouseDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._mouseDown = (MouseEventHandlerEx)Delegate.Remove(this._mouseDown, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event MouseEventHandlerEx MouseDoubleClick
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._mouseDoubleClick = (MouseEventHandlerEx)Delegate.Combine(this._mouseDoubleClick, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._mouseDoubleClick = (MouseEventHandlerEx)Delegate.Remove(this._mouseDoubleClick, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event MouseEventHandlerEx MouseWheel
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._mouseWheel = (MouseEventHandlerEx)Delegate.Combine(this._mouseWheel, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._mouseWheel = (MouseEventHandlerEx)Delegate.Remove(this._mouseWheel, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal event HandledEventHandler BarcodeNoticeTimeOut
		{
			add
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._barcodeNoticeTimeOut = (HandledEventHandler)Delegate.Combine(this._barcodeNoticeTimeOut, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			remove
			{
				object obj;
				Monitor.Enter(obj = TbsMessageFilter.syncRoot);
				try
				{
					this._barcodeNoticeTimeOut = (HandledEventHandler)Delegate.Remove(this._barcodeNoticeTimeOut, value);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
		}
		internal static TbsMessageFilter Instance
		{
			get
			{
				return TbsMessageFilter._instance;
			}
		}
		static TbsMessageFilter()
		{
			TbsMessageFilter.syncRoot = new object();
			TbsMessageFilter._instance = new TbsMessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(TbsMessageFilter._instance);
			TbsMessageFilter._barcodeNoticeTimeOutTimer = new System.Threading.Timer(new TimerCallback(TbsMessageFilter._barcodeNoticeTimeOutTimer_TimerCallback));
		}
		private TbsMessageFilter()
		{
		}
		public bool PreFilterMessage(ref Message m)
		{
			int msg = m.Msg;
			switch (msg)
			{
			case 256:
			{
				Keys keys;
				if (this._barcodeKeyDown != null)
				{
					keys = (Keys)m.WParam.ToInt32();
					if (SafeNativeMethods.GetKeyState(17) < 0)
					{
						keys |= Keys.Control;
					}
					if (SafeNativeMethods.GetKeyState(18) < 0)
					{
						keys |= Keys.Alt;
					}
					if (SafeNativeMethods.GetKeyState(16) < 0)
					{
						keys |= Keys.Shift;
					}
					Control control = Control.FromHandle(m.HWnd);
					KeyEventArgs keyEventArgs = new KeyEventArgs(keys);
					this._barcodeKeyDown(control, keyEventArgs);
					if (keyEventArgs.Handled)
					{
						return true;
					}
				}
				keys = (Keys)m.WParam.ToInt32();
				if (SafeNativeMethods.GetAsyncKeyState(17) != 0)
				{
					keys |= Keys.Control;
				}
				if (SafeNativeMethods.GetAsyncKeyState(18) != 0)
				{
					keys |= Keys.Alt;
				}
				if (SafeNativeMethods.GetAsyncKeyState(16) != 0)
				{
					keys |= Keys.Shift;
				}
				if (this._toolbarKeyDown != null)
				{
					Control control = Control.FromHandle(m.HWnd);
					KeyEventArgs keyEventArgs2 = new KeyEventArgs(keys);
					this._toolbarKeyDown(control, keyEventArgs2);
					if (keyEventArgs2.Handled)
					{
						return false;
					}
				}
				if (this._helpKeyDown != null && (keys & Keys.KeyCode) == Keys.F1 && (keys & Keys.Modifiers) == Keys.None)
				{
					Control control = Control.FromHandle(m.HWnd);
					if (control == null)
					{
						control = Control.FromChildHandle(m.HWnd);
					}
					if (control is EmbeddableTextBoxWithUIPermissions)
					{
						control = ((EmbeddableTextBoxWithUIPermissions)control).Parent;
					}
					KeyEventArgs keyEventArgs3 = new KeyEventArgs(keys);
					this._helpKeyDown(control, keyEventArgs3, 0);
					if (keyEventArgs3.Handled)
					{
						return true;
					}
					this._helpKeyDown(control, keyEventArgs3, 1);
					if (keyEventArgs3.Handled)
					{
						return true;
					}
				}
				if (this._keyDown != null)
				{
					Control control = Control.FromHandle(m.HWnd);
					if (control == null)
					{
						control = Control.FromChildHandle(m.HWnd);
					}
					if (control is EmbeddableTextBoxWithUIPermissions)
					{
						control = ((EmbeddableTextBoxWithUIPermissions)control).Parent;
					}
					KeyEventArgs keyEventArgs4 = new KeyEventArgs(keys);
					this._keyDown(control, keyEventArgs4);
					if (keyEventArgs4.Handled)
					{
						return true;
					}
				}
				break;
			}
			case 257:
				break;
			case 258:
				if (this._keyPress != null)
				{
					Control control = Control.FromHandle(m.HWnd);
					KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs((char)m.WParam.ToInt32());
					this._keyPress(control, keyPressEventArgs);
					if (keyPressEventArgs.Handled)
					{
						return true;
					}
				}
				break;
			default:
				switch (msg)
				{
				case 513:
					if (this._mouseDown != null)
					{
						Control control = Control.FromHandle(m.HWnd);
						int x = m.LParam.ToInt32() % 65536;
						int y = m.LParam.ToInt32() / 65536;
						MouseEventArgsEx mouseEventArgsEx = new MouseEventArgsEx(MouseButtons.Left, 1, x, y, 0);
						this._mouseDown(control, mouseEventArgsEx);
						if (mouseEventArgsEx.Handled)
						{
							return true;
						}
					}
					break;
				case 514:
				case 517:
					break;
				case 515:
					if (this._mouseDoubleClick != null)
					{
						Control control = Control.FromHandle(m.HWnd);
						int x = m.LParam.ToInt32() % 65536;
						int y = m.LParam.ToInt32() / 65536;
						MouseEventArgsEx mouseEventArgsEx = new MouseEventArgsEx(MouseButtons.Left, 2, x, y, 0);
						this._mouseDoubleClick(control, mouseEventArgsEx);
						if (mouseEventArgsEx.Handled)
						{
							return true;
						}
					}
					break;
				case 516:
					if (this._mouseDown != null)
					{
						Control control = Control.FromHandle(m.HWnd);
						int x = m.LParam.ToInt32() % 65536;
						int y = m.LParam.ToInt32() / 65536;
						MouseEventArgsEx mouseEventArgsEx = new MouseEventArgsEx(MouseButtons.Right, 1, x, y, 0);
						this._mouseDown(control, mouseEventArgsEx);
						if (mouseEventArgsEx.Handled)
						{
							return true;
						}
					}
					break;
				case 518:
					if (this._mouseDoubleClick != null)
					{
						Control control = Control.FromHandle(m.HWnd);
						int x = m.LParam.ToInt32() % 65536;
						int y = m.LParam.ToInt32() / 65536;
						MouseEventArgsEx mouseEventArgsEx = new MouseEventArgsEx(MouseButtons.Right, 2, x, y, 0);
						this._mouseDoubleClick(control, mouseEventArgsEx);
						if (mouseEventArgsEx.Handled)
						{
							return true;
						}
					}
					break;
				default:
					if (msg == 522)
					{
						if (this._mouseWheel != null)
						{
							int num = m.WParam.ToInt32();
							int num2 = m.LParam.ToInt32();
							int num3 = num & 65535;
							MouseButtons mouseButtons = MouseButtons.None;
							if ((num3 & 1) != 0)
							{
								mouseButtons |= MouseButtons.Left;
							}
							if ((num3 & 2) != 0)
							{
								mouseButtons |= MouseButtons.Right;
							}
							if ((num3 & 16) != 0)
							{
								mouseButtons |= MouseButtons.Middle;
							}
							if ((num3 & 32) != 0)
							{
								mouseButtons |= MouseButtons.XButton1;
							}
							if ((num3 & 64) != 0)
							{
								mouseButtons |= MouseButtons.XButton2;
							}
							Control control = Control.FromHandle(m.HWnd);
							MouseEventArgsEx mouseEventArgsEx = new MouseEventArgsEx(mouseButtons, 0, num2 & 65535, num2 >> 16, num >> 16);
							mouseEventArgsEx.ShiftKey = ((num3 & 4) != 0);
							mouseEventArgsEx.CtrlKey = ((num3 & 8) != 0);
							this._mouseWheel(control, mouseEventArgsEx);
							if (mouseEventArgsEx.Handled)
							{
								return true;
							}
						}
					}
					break;
				}
				break;
			}
			return false;
		}
		internal void BarcodeNoticeTimerOn()
		{
			TbsMessageFilter._barcodeNoticeTimeOutTimer.Change(70, -1);
		}
		internal void BarcodeNoticeTimerOff()
		{
			TbsMessageFilter._barcodeNoticeTimeOutTimer.Change(-1, -1);
		}
		private static void _barcodeNoticeTimeOutTimer_TimerCallback(object state)
		{
			TbsMessageFilter._barcodeNoticeTimeOutTimer.Change(-1, -1);
			if (TbsMessageFilter._instance._barcodeNoticeTimeOut != null)
			{
				HandledEventArgs handledEventArgs = new HandledEventArgs();
				TbsMessageFilter._instance._barcodeNoticeTimeOut(null, handledEventArgs);
				if (!handledEventArgs.Handled)
				{
					SafeNativeMethods.INPUT iNPUT = default(SafeNativeMethods.INPUT);
					iNPUT.type = 1;
					iNPUT.ki.wVk = 222;
					iNPUT.ki.wScan = 0;
					iNPUT.ki.dwFlags = 0u;
					iNPUT.ki.time = 0u;
					iNPUT.ki.dwExtraInfo = SafeNativeMethods.GetMessageExtraInfo();
					SafeNativeMethods.SendInput(1u, ref iNPUT, Marshal.SizeOf(typeof(SafeNativeMethods.INPUT)));
					iNPUT.ki.wVk = 222;
					iNPUT.ki.dwFlags = 2u;
					SafeNativeMethods.SendInput(1u, ref iNPUT, Marshal.SizeOf(typeof(SafeNativeMethods.INPUT)));
				}
			}
		}
	}
}
