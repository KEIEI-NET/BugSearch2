using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TComboEditor), "TComboEditor.bmp")]
	public class TComboEditor : UltraComboEditor
	{
		private const int ctMaxDropDownItemCount = 60;
		private Container components;
		private bool _OnFocused;
		private AppearanceHolder FActAppearanceHolder;
		private AppearanceBase FNorAppearance;
		private MouseWheelEventHandlerEx _mouseWheelEx;
		[Browsable(false)]
		public event MouseWheelEventHandlerEx MouseWheelEx
		{
			add
			{
				TbsMessageFilter.Instance.MouseWheel += new MouseEventHandlerEx(this.MessageFilter_MouseWheel);
				this._mouseWheelEx = (MouseWheelEventHandlerEx)Delegate.Combine(this._mouseWheelEx, value);
			}
			remove
			{
				TbsMessageFilter.Instance.MouseWheel -= new MouseEventHandlerEx(this.MessageFilter_MouseWheel);
				this._mouseWheelEx = (MouseWheelEventHandlerEx)Delegate.Remove(this._mouseWheelEx, value);
			}
		}
		[Category("Behavior"), Description("入力フォーカスがある際の外観を指定します。"), TypeConverter(typeof(Infragistics.Win.Appearance.AppearanceTypeConverter))]
		public AppearanceBase ActiveAppearance
		{
			get
			{
				if (this.FActAppearanceHolder == null)
				{
					this.FActAppearanceHolder = new AppearanceHolder();
				}
				return this.FActAppearanceHolder.Appearance;
			}
			set
			{
				if (this.FActAppearanceHolder == null || !this.FActAppearanceHolder.HasAppearance || value != this.FActAppearanceHolder.Appearance)
				{
					if (this.FActAppearanceHolder == null)
					{
						this.FActAppearanceHolder = new AppearanceHolder();
					}
					this.FActAppearanceHolder.Appearance = value;
				}
			}
		}
		[Category("Appearance"), Description("ドロップダウン リストの表示領域に表示される項目の数を取得または設定します。")]
		public new int MaxDropDownItems
		{
			get
			{
				return base.MaxDropDownItems;
			}
			set
			{
				if (value > 60)
				{
					base.MaxDropDownItems = 60;
					return;
				}
				base.MaxDropDownItems = value;
			}
		}
		public TComboEditor()
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
				TbsMessageFilter.Instance.MouseWheel -= new MouseEventHandlerEx(this.MessageFilter_MouseWheel);
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		protected override void OnEnter(EventArgs e)
		{
			if (!this._OnFocused)
			{
				this._OnFocused = true;
				this.FNorAppearance = (AppearanceBase)base.Appearance.Clone();
				base.Appearance = (AppearanceBase)this.FActAppearanceHolder.Appearance.Clone();
			}
			base.OnEnter(e);
		}
		protected override void OnLeave(EventArgs e)
		{
			if (this._OnFocused)
			{
				this._OnFocused = false;
				if (this.FNorAppearance != null)
				{
					base.Appearance = this.FNorAppearance;
				}
			}
			base.OnLeave(e);
		}
		protected override void OnAfterDropDown(EventArgs args)
		{
			if (Cursor.Current == null)
			{
				Cursor.Current = Cursors.Default;
			}
			base.OnAfterDropDown(args);
		}
		private void MessageFilter_MouseWheel(object sender, MouseEventArgsEx e)
		{
			if (this._mouseWheelEx != null)
			{
				Control control = sender as Control;
				if (control != null)
				{
					if (control is EmbeddableTextBoxWithUIPermissions)
					{
						control = control.Parent;
					}
					if (control.Equals(this))
					{
						MouseWheelEventArgsEx mouseWheelEventArgsEx = new MouseWheelEventArgsEx(e.Button, e.ShiftKey, e.CtrlKey, e.Clicks, e.X, e.Y, e.Delta);
						this._mouseWheelEx(this, mouseWheelEventArgsEx);
						if (mouseWheelEventArgsEx.Handled)
						{
							e.Handled = true;
						}
					}
				}
			}
		}
	}
}
