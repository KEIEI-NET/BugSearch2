using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TToolbarsManager), "TToolbarsManager.bmp")]
	public class TToolbarsManager : UltraToolbarsManager
	{
		private Container components;
		private UIElement _activeEl;
		private bool _isDropDown;
		private TbsMessageFilter _messageFilter;
		public TToolbarsManager(IContainer container) : base(container)
		{
			container.Add(this);
			this.InitializeComponent();
			this._messageFilter = TbsMessageFilter.Instance;
			this._messageFilter.ToolbarKeyDown += new KeyEventHandler(this.Owner_KeyDown);
			this._messageFilter.MouseDown += new MouseEventHandlerEx(this.Owner_MouseDown);
		}
		public TToolbarsManager()
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
					this._messageFilter.ToolbarKeyDown -= new KeyEventHandler(this.Owner_KeyDown);
					this._messageFilter.MouseDown -= new MouseEventHandlerEx(this.Owner_MouseDown);
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		private void Owner_KeyDown(object sender, KeyEventArgs e)
		{
			if (this._isDropDown)
			{
				e.Handled = true;
				return;
			}
			if (base.ActiveTool != null && base.Equals(base.ActiveTool.ToolbarsManager))
			{
				if (sender is Control)
				{
					if (base.DockWithinContainer == null)
					{
						return;
					}
					if (base.DockWithinContainer is Form)
					{
						if (base.DockWithinContainer != Form.ActiveForm)
						{
							return;
						}
					}
					else
					{
						if (base.DockWithinContainer.FindForm() != Form.ActiveForm)
						{
							return;
						}
					}
				}
				if (base.ActiveTool.OwnerIsToolbar && base.UIElementFromPoint(Cursor.Position) == this._activeEl)
				{
					return;
				}
				e.Handled = true;
			}
		}
		private void Owner_MouseDown(object sender, MouseEventArgsEx e)
		{
			if (base.ActiveTool != null && !this._isDropDown && !this.HasToolbarUIElement(base.UIElementFromPoint(Cursor.Position)) && base.ActiveTool != null && base.Equals(base.ActiveTool.ToolbarsManager))
			{
				base.ActiveTool = null;
			}
		}
		private bool HasToolbarUIElement(UIElement srcElment)
		{
			return srcElment != null && (srcElment is ToolbarUIElement || this.HasToolbarUIElement(srcElment.Parent));
		}
		protected override void OnMouseEnterElement(UIElementEventArgs e)
		{
			this._activeEl = e.Element;
			base.OnMouseEnterElement(e);
		}
		protected override void OnAfterToolDropdown(ToolDropdownEventArgs e)
		{
			this._isDropDown = true;
			base.OnAfterToolDropdown(e);
		}
		protected override void OnAfterToolCloseup(ToolDropdownEventArgs e)
		{
			this._isDropDown = false;
			base.OnAfterToolCloseup(e);
		}
	}
}
