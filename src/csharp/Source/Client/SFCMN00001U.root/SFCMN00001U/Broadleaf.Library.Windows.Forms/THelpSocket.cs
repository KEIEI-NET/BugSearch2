using Broadleaf.Library.ComponentModel;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[DefaultEvent("HelpKeyDown"), ToolboxBitmap(typeof(THelpSocket), "THelpSocket.bmp")]
	public class THelpSocket : TbsBaseComponent
	{
		private Container components;
		private static int instanceCount;
		private TbsMessageFilter _messageFilter;
		private bool _customHelpControl;
		private bool _enabled = true;
		private string _specifiedHelpPGID = "";
        [Description("ヘルプ起動キーの押下時に発生するイベントです。CustomHelpControlプロパティがTrueの場合にのみ発生します。")]
        public event HandledEventHandler HelpKeyDown;
		[Category("Behavior"), DefaultValue(true), Description("コントロールが有効かどうかを示します。")]
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
			}
		}
		[Category("Behavior"), DefaultValue(false), Description("HelpKeyDownイベントを発生させて、個別にヘルプ表示制御を行うかどうかを取得、設定します。")]
		public bool CustomHelpControl
		{
			get
			{
				return this._customHelpControl;
			}
			set
			{
				this._customHelpControl = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description("監視対象フォームより自動判定せずにヘルプ表示を行う場合に、対応するPGIDを設定します。")]
		public string SpecifiedHelpPGID
		{
			get
			{
				return this._specifiedHelpPGID;
			}
			set
			{
				this._specifiedHelpPGID = value;
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
		static THelpSocket()
		{
			THelpSocket.instanceCount = 0;
		}
		public THelpSocket(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			THelpSocket.instanceCount++;
			this._messageFilter = TbsMessageFilter.Instance;
			this._messageFilter.HelpKeyDown += new KeyEventHandlerEx(this.Owner_KeyDown);
		}
		public THelpSocket()
		{
			this.InitializeComponent();
			THelpSocket.instanceCount++;
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
					this._messageFilter.HelpKeyDown -= new KeyEventHandlerEx(this.Owner_KeyDown);
				}
			}
			THelpSocket.instanceCount--;
			if (THelpSocket.instanceCount == 0)
			{
				THelpControl.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		public void ShowActiveFormHelp(Form activeForm, Control activeCtrl)
		{
			if (activeForm == null)
			{
				activeForm = Form.ActiveForm;
				if (activeForm == null)
				{
					activeForm = (Control.FromHandle(Process.GetCurrentProcess().MainWindowHandle) as Form);
				}
			}
			if (activeCtrl == null)
			{
				activeCtrl = activeForm.ActiveControl;
			}
			THelpCtrlParam tHelpCtrlParam = new THelpCtrlParam();
			tHelpCtrlParam.HelpMode = HelpModeTypes.Auto;
            tHelpCtrlParam.ExcutePgName = Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath);
			tHelpCtrlParam.ExcutePgTitle = Process.GetCurrentProcess().MainWindowTitle;
			tHelpCtrlParam.MainWindow = (Control.FromHandle(Process.GetCurrentProcess().MainWindowHandle) as Form);
			tHelpCtrlParam.MainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
			tHelpCtrlParam.ActiveForm = activeForm;
			tHelpCtrlParam.OwnerForm = activeForm;
			tHelpCtrlParam.SpecifiedHelpPGID = "";
			tHelpCtrlParam.Item = activeCtrl;
			tHelpCtrlParam.ItemHandle = ((activeCtrl != null) ? activeCtrl.Handle : IntPtr.Zero);
			THelpControl.ShowHelp(ref tHelpCtrlParam);
		}
		private void ShowHelpProc(object sender)
		{
			THelpCtrlParam tHelpCtrlParam = new THelpCtrlParam();
			Control control = sender as Control;
			tHelpCtrlParam.HelpMode = HelpModeTypes.Auto;
            tHelpCtrlParam.ExcutePgName = Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath);
			tHelpCtrlParam.ExcutePgTitle = Process.GetCurrentProcess().MainWindowTitle;
			tHelpCtrlParam.MainWindow = (Control.FromHandle(Process.GetCurrentProcess().MainWindowHandle) as Form);
			tHelpCtrlParam.MainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
			tHelpCtrlParam.ActiveForm = Form.ActiveForm;
			tHelpCtrlParam.OwnerForm = (base.OwnerForm as Control);
			tHelpCtrlParam.SpecifiedHelpPGID = this._specifiedHelpPGID;
			tHelpCtrlParam.Item = control;
			tHelpCtrlParam.ItemHandle = ((control != null) ? control.Handle : IntPtr.Zero);
			THelpControl.ShowHelp(ref tHelpCtrlParam);
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
			if (base.OwnerForm != null && base.OwnerForm is Control)
			{
				Control control = (Control)base.OwnerForm;
				control.ParentChanged += new EventHandler(this.Owner_ParentChanged);
			}
		}
		private bool CheckControl(Control iCtrl)
		{
			Control control = (Control)base.OwnerForm;
			return iCtrl.Equals(control) || this.CheckControlSub(iCtrl, control);
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
		}
		private void Owner_KeyDown(object sender, KeyEventArgs e, int mode)
		{
			if (!this._enabled)
			{
				return;
			}
			if (e.Handled)
			{
				return;
			}
			if (mode == 0 && this._customHelpControl)
			{
				return;
			}
			if (mode == 1 && !this._customHelpControl)
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
			if (!this._customHelpControl && !this.CheckControl(sender as Control))
			{
				return;
			}
			if (this._customHelpControl)
			{
				if (this.HelpKeyDown != null)
				{
					HandledEventArgs handledEventArgs = new HandledEventArgs(false);
					this.HelpKeyDown(sender, handledEventArgs);
					if (handledEventArgs.Handled)
					{
						e.Handled = true;
						return;
					}
				}
			}
			else
			{
				this.ShowHelpProc(sender);
				e.Handled = true;
			}
		}
	}
}
