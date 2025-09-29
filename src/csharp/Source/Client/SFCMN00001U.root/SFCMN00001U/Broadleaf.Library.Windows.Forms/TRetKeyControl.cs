using Broadleaf.Library.ComponentModel;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[DefaultEvent("ChangeFocus"), ToolboxBitmap(typeof(TRetKeyControl), "TRetKeyControl.bmp")]
	public class TRetKeyControl : TbsBaseComponent
	{
		private Container components;
		private bool FAlwaysEvent;
		private bool FCatchMouse;
		private bool FCirculate = true;
		private bool FInitFocus = true;
		private emFocusStyle FStyle;
		private bool FTabEnable = true;
		private bool FInitActive;
		private TbsMessageFilter FMessageFilter;
        [Description("Enterキーによりフォーカスが遷移する際のイベント")]
        public event ChangeFocusEventHandler ChangeFocus;
		[Category("Behavior"), DefaultValue(false), Description("移動先がない場合でもChangeFocusイベントを発生させるかを指定します")]
		public bool AlwaysEvent
		{
			get
			{
				return this.FAlwaysEvent;
			}
			set
			{
				this.FAlwaysEvent = value;
			}
		}
		[Category("Behavior"), DefaultValue(false), Description("マウス左クリック、及び左ダブルクリックによるフォーカス移動時にChangeFocusイベントを発生させるかを取得、設定します。")]
		public bool CatchMouse
		{
			get
			{
				return this.FCatchMouse;
			}
			set
			{
				this.FCatchMouse = value;
			}
		}
		[Category("Behavior"), DefaultValue(true), Description("フォーム末端まで移動した際に、Enterキーにより、先頭のフィールドにフォーカスを移動するかを取得、設定します。")]
		public bool Circulate
		{
			get
			{
				return this.FCirculate;
			}
			set
			{
				this.FCirculate = value;
			}
		}
		[Category("Behavior"), DefaultValue(true), Description("画面起動時にChangeFocusイベントを発生させるかを指定します。")]
		public bool InitFocus
		{
			get
			{
				return this.FInitFocus;
			}
			set
			{
				this.FInitFocus = value;
			}
		}
		[Category("Behavior"), DefaultValue(emFocusStyle.ByPosX), Description("移動方向の指定を取得、設定できます。")]
		public emFocusStyle Style
		{
			get
			{
				return this.FStyle;
			}
			set
			{
				this.FStyle = value;
			}
		}
		[Category("Behavior"), DefaultValue(true), Description("TABキーでの動きをEnterキーでの動きと同じにします。")]
		public bool TabEnable
		{
			get
			{
				return this.FTabEnable;
			}
			set
			{
				this.FTabEnable = value;
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
		public TRetKeyControl(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			this.FMessageFilter = TbsMessageFilter.Instance;
			this.FMessageFilter.KeyDown += new KeyEventHandler(this.Owner_KeyDown);
			this.FMessageFilter.MouseDown += new MouseEventHandlerEx(this.Owner_MouseDownEx);
		}
		public TRetKeyControl()
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
				if (this.FMessageFilter != null)
				{
					this.FMessageFilter.KeyDown -= new KeyEventHandler(this.Owner_KeyDown);
					this.FMessageFilter.MouseDown -= new MouseEventHandlerEx(this.Owner_MouseDownEx);
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
			if (base.OwnerForm != null)
			{
				if (base.OwnerForm is Form)
				{
					Form form = (Form)base.OwnerForm;
					form.VisibleChanged -= new EventHandler(this.Owner_VisibleChanged);
					form.Activated -= new EventHandler(this.Owner_Activated);
					return;
				}
				if (base.OwnerForm is Control)
				{
					Control control = (Control)base.OwnerForm;
					control.ParentChanged -= new EventHandler(this.Owner_ParentChanged);
				}
			}
		}
		private void AddedHockControl()
		{
			if (base.OwnerForm != null)
			{
				if (base.OwnerForm is Form)
				{
					Form form = (Form)base.OwnerForm;
					form.VisibleChanged += new EventHandler(this.Owner_VisibleChanged);
					form.Activated += new EventHandler(this.Owner_Activated);
					return;
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
			Control iParent = (Control)base.OwnerForm;
			return this.CheckControlSub(iCtrl, iParent);
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
		private bool CanExit(Control iCtrl, KeyEventArgs e, out bool iKeyCancel)
		{
			iKeyCancel = false;
			stSHIFTSTAT shiftstat;
			shiftstat.bAlt = e.Alt;
			shiftstat.bCtrl = e.Control;
			shiftstat.bShift = e.Shift;
			if (iCtrl == null)
			{
				return true;
			}
			if (iCtrl.Parent is TDateEdit)
			{
				if (e.KeyCode != Keys.Tab)
				{
					return ((TDateEdit)iCtrl.Parent).CanExit(e.KeyCode, shiftstat);
				}
				if (this.FTabEnable)
				{
					return ((TDateEdit)iCtrl.Parent).CanExit(e.KeyCode, shiftstat);
				}
				iKeyCancel = true;
				return false;
			}
			else
			{
				if (iCtrl is TNedit)
				{
					if (e.KeyCode != Keys.Tab)
					{
						return ((TNedit)iCtrl).CanExit(e.KeyCode, shiftstat);
					}
					if (!this.FTabEnable)
					{
						iKeyCancel = true;
						return false;
					}
					if (((TNedit)iCtrl).CanExit(e.KeyCode, shiftstat))
					{
						return true;
					}
					iKeyCancel = true;
					return false;
				}
				else
				{
					if (iCtrl is TEdit)
					{
						if (e.KeyCode != Keys.Tab)
						{
							return ((TEdit)iCtrl).CanExit(e.KeyCode, shiftstat);
						}
						if (!this.FTabEnable)
						{
							iKeyCancel = true;
							return false;
						}
						if (((TEdit)iCtrl).CanExit(e.KeyCode, shiftstat))
						{
							return true;
						}
						iKeyCancel = true;
						return false;
					}
					else
					{
						if (iCtrl is TextBox)
						{
							if (e.KeyCode == Keys.Return || (e.KeyCode == Keys.Tab && this.FTabEnable) || e.KeyCode == Keys.None || e.KeyCode == Keys.LButton || e.KeyCode == Keys.RButton)
							{
								return true;
							}
							if (e.KeyCode == Keys.Tab)
							{
								iKeyCancel = true;
							}
							return false;
						}
						else
						{
							if (iCtrl is UltraGrid)
							{
								return true;
							}
							if (e.KeyCode == Keys.None || e.KeyCode == Keys.LButton || e.KeyCode == Keys.RButton)
							{
								return true;
							}
							if (e.KeyCode == Keys.Return || (e.KeyCode == Keys.Tab && this.FTabEnable))
							{
								return true;
							}
							if (e.KeyCode == Keys.Tab)
							{
								iKeyCancel = true;
							}
							return false;
						}
					}
				}
			}
		}
		private void Owner_ParentChanged(object sender, EventArgs e)
		{
		}
		private void Owner_VisibleChanged(object sender, EventArgs e)
		{
			if (sender is Form && sender == base.OwnerForm)
			{
				Form form = (Form)sender;
				if (form.Visible)
				{
					this.FInitActive = true;
				}
			}
		}
		private void Owner_Activated(object sender, EventArgs e)
		{
			if (sender is Form && sender == base.OwnerForm && this.FInitActive)
			{
				this.FInitActive = false;
				Form iParent = (Form)sender;
				if (this.FInitFocus)
				{
					Control control = null;
					TLib.GetTopCtrl(ref control, iParent, this.FStyle);
					if (control != null)
					{
						control = TLib.GetBaseControl(control);
					}
					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.None, null, control);
					this.OnChangeFocus(changeFocusEventArgs);
					if (changeFocusEventArgs.NextCtrl != null)
					{
						changeFocusEventArgs.NextCtrl.Focus();
					}
				}
			}
		}
		private void Owner_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Handled)
			{
				return;
			}
			if (sender == null)
			{
				if (!(base.OwnerForm is Form))
				{
					return;
				}
				Form form = (Form)base.OwnerForm;
				if (form.ActiveControl == null)
				{
					return;
				}
				sender = form.ActiveControl;
			}
			if (this.CheckControl((Control)sender) && (e.KeyCode == Keys.Return || (e.KeyCode == Keys.Tab && this.FTabEnable)))
			{
				if (base.OwnerForm == null)
				{
					return;
				}
				Form form2;
				if (base.OwnerForm is Form)
				{
					form2 = (Form)base.OwnerForm;
				}
				else
				{
					form2 = ((Control)base.OwnerForm).FindForm();
				}
				Control control = (Control)sender;
				if (control is TDateEdit)
				{
					for (int i = 0; i < control.Controls.Count; i++)
					{
						if (control.Controls[i].Focused)
						{
							control = control.Controls[i];
							break;
						}
					}
				}
				bool handled = false;
				if (!this.CanExit(control, e, out handled))
				{
					e.Handled = handled;
					return;
				}
				Control control2 = null;
				if (e.Shift)
				{
					if (control2 == null && form2 != null)
					{
						TLib.GetPrevCtrl(ref control2, control, form2, this.FStyle);
					}
					if (control2 == null && this.FCirculate && form2 != null)
					{
						TLib.GetBtmCtrl(ref control2, form2, this.FStyle);
					}
				}
				else
				{
					if (control2 == null && form2 != null)
					{
						TLib.GetNextCtrl(ref control2, control, form2, this.FStyle);
					}
					if (control2 == null && this.FCirculate && form2 != null)
					{
						TLib.GetTopCtrl(ref control2, form2, this.FStyle);
					}
				}
				if (control2 != null && control2.Parent is TDateEdit)
				{
					control2 = control2.Parent;
				}
				if (this.FAlwaysEvent || control2 != null)
				{
					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(e.Shift, e.Alt, e.Control, e.KeyCode, control, control2);
					this.OnChangeFocus(changeFocusEventArgs);
					if (changeFocusEventArgs.NextCtrl != null && changeFocusEventArgs.NextCtrl.Visible && !changeFocusEventArgs.NextCtrl.Focused)
					{
						changeFocusEventArgs.NextCtrl.Focus();
					}
					e.Handled = true;
				}
			}
		}
		private void Owner_MouseDownEx(object sender, MouseEventArgsEx e)
		{
			if (e.Handled)
			{
				return;
			}
			if (this.CheckControl((Control)sender) && this.FCatchMouse && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
			{
				if (base.OwnerForm == null)
				{
					return;
				}
				Form form;
				if (base.OwnerForm is Form)
				{
					form = (Form)base.OwnerForm;
				}
				else
				{
					form = ((Control)base.OwnerForm).FindForm();
				}
				Control control = (Control)sender;
				if (TLib.IsMouseFocusControl(control) && (TLib.GetBaseControl(control) != TLib.GetBaseControl(form.ActiveControl) || TLib.GetBaseControl(control) is TDateEdit))
				{
					if (TLib.IsReadOnly(control) || !control.CanFocus)
					{
						e.Handled = true;
						return;
					}
					bool flag = false;
					KeyEventArgs keyEventArgs;
					if (e.Button == MouseButtons.Left)
					{
						keyEventArgs = new KeyEventArgs(Keys.LButton);
					}
					else
					{
						keyEventArgs = new KeyEventArgs(Keys.RButton);
					}
					if (!this.CanExit(form.ActiveControl, keyEventArgs, out flag))
					{
						e.Handled = true;
						return;
					}
					Control control2 = form.ActiveControl;
					if (control2 is EmbeddableTextBoxWithUIPermissions && TLib.GetBaseControl(control2).Parent is TDateEdit)
					{
						control2 = TLib.GetBaseControl(control2);
					}
					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, keyEventArgs.KeyCode, control2, control);
					this.OnChangeFocus(changeFocusEventArgs);
					if (changeFocusEventArgs.NextCtrl == null)
					{
						if (!control.Focused)
						{
							control.Focus();
						}
						e.Handled = true;
						return;
					}
					if (!changeFocusEventArgs.NextCtrl.Visible)
					{
						e.Handled = true;
						return;
					}
					if (changeFocusEventArgs.NextCtrl != null && control != changeFocusEventArgs.NextCtrl)
					{
						changeFocusEventArgs.NextCtrl.Focus();
						e.Handled = true;
					}
				}
			}
		}
		private void Owner_MouseDoubleClickEx(object sender, MouseEventArgsEx e)
		{
			if (e.Handled)
			{
				return;
			}
			if (this.CheckControl((Control)sender) && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
			{
				Control baseControl = TLib.GetBaseControl((Control)sender);
				if (TLib.IsReadOnly(baseControl))
				{
					e.Handled = true;
				}
			}
		}
		protected virtual void OnChangeFocus(ChangeFocusEventArgs e)
		{
			Control control = null;
			Control control2 = null;
			if (e.PrevCtrl != null)
			{
				control = TLib.GetBaseControl(e.PrevCtrl);
			}
			if (e.NextCtrl != null)
			{
				control2 = TLib.GetBaseControl(e.NextCtrl);
			}
			if (control != control2)
			{
				if (control is TDateEdit)
				{
					Control control3 = ((TDateEdit)control).CheckInputDataForKeyCtrl();
					if (control3 != null)
					{
						e.NextCtrl = control3;
						return;
					}
				}
				if (!this.FAlwaysEvent && control2 == null)
				{
					e.NextCtrl = null;
					return;
				}
				if (this.ChangeFocus != null)
				{
					IntPtr intPtr = IntPtr.Zero;
					bool flag = false;
					if (control != null)
					{
						intPtr = SafeNativeMethods.ImmGetContext(control.Handle);
						try
						{
							if (intPtr != IntPtr.Zero)
							{
								flag = SafeNativeMethods.ImmGetOpenStatus(intPtr);
							}
						}
						finally
						{
							SafeNativeMethods.ImmReleaseContext(control.Handle, intPtr);
						}
					}
					if (control2 != null)
					{
						Control control4 = control2;
						ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(e.ShiftKey, e.AltKey, e.ControlKey, e.Key, control, control2);
						this.ChangeFocus(this, changeFocusEventArgs);
						if (changeFocusEventArgs.NextCtrl != control4)
						{
							e.NextCtrl = changeFocusEventArgs.NextCtrl;
						}
						if (e.PrevCtrl != null && e.NextCtrl == e.PrevCtrl && flag)
						{
							intPtr = SafeNativeMethods.ImmGetContext(e.PrevCtrl.Handle);
							try
							{
								if (intPtr != IntPtr.Zero)
								{
									SafeNativeMethods.ImmSetOpenStatus(intPtr, true);
								}
							}
							finally
							{
								SafeNativeMethods.ImmReleaseContext(control.Handle, intPtr);
							}
						}
					}
				}
			}
		}
	}
}
