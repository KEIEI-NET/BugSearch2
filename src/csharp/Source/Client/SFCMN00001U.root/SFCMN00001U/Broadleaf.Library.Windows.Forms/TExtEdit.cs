using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Broadleaf.Library.Windows.Forms
{
	[Editor(typeof(TEditValueEditor), typeof(UITypeEditor)), TypeConverter(typeof(TExtEdit.TExtEditConverter))]
	public class TExtEdit
	{
		internal class TExtEditConverter : ExpandableObjectConverter
		{
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
			}
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (destinationType == typeof(InstanceDescriptor) && value is TExtEdit)
				{
					TExtEdit tExtEdit = (TExtEdit)value;
					ConstructorInfo constructor = typeof(TExtEdit).GetConstructor(new Type[]
					{
						typeof(emCursorPosition),
						typeof(bool),
						typeof(bool),
						typeof(int),
						typeof(TEnableChars)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[]
						{
							tExtEdit.CursorPos,
							tExtEdit.FreeCursor,
							tExtEdit.AutoWidth,
							tExtEdit.Column,
							tExtEdit.EnableChars
						});
					}
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}
		private emCursorPosition FCurPos;
		private TEnableChars FEchars = new TEnableChars();
		private bool FFreeCursor;
		private bool FAutoWidth;
		private int FColumn = 12;
        public event EventHandler AutoWidthChange;
        public event EventHandler ColumnChange;
        public event EventHandler EnableCharsChange;
		[DefaultValue(emCursorPosition.Prev), Description("フォーカスが入った時の、カーソル位置の取得、設定を行います。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public emCursorPosition CursorPos
		{
			get
			{
				return this.FCurPos;
			}
			set
			{
				this.FCurPos = value;
			}
		}
		[Description("入力可能文字種の取得、設定を行います。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All), TypeConverter(typeof(TEnableChars.TEnableCharsConverter))]
		public TEnableChars EnableChars
		{
			get
			{
				return this.FEchars;
			}
			set
			{
				this.FEchars = value;
				this.FEchars.WordChanged += new EventHandler(this.WordChanged);
				EventArgs e = new EventArgs();
				this.OnEnableCharsChange(e);
			}
		}
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool FreeCursor
		{
			get
			{
				return this.FFreeCursor;
			}
			set
			{
				this.FFreeCursor = value;
			}
		}
		[DefaultValue(false), Description("文字数により自動的に幅を調整します。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool AutoWidth
		{
			get
			{
				return this.FAutoWidth;
			}
			set
			{
				if (this.FAutoWidth != value)
				{
					this.FAutoWidth = value;
					EventArgs e = new EventArgs();
					this.OnAutoWidthChange(e);
				}
			}
		}
		[DefaultValue(12), Description("入力できる文字数を取得、設定します。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public int Column
		{
			get
			{
				return this.FColumn;
			}
			set
			{
				if (this.FColumn != value)
				{
					this.FColumn = value;
					if (this.ColumnChange != null)
					{
						EventArgs e = new EventArgs();
						this.OnColumnChange(e);
					}
				}
			}
		}
		public TExtEdit()
		{
		}
		public TExtEdit(emCursorPosition cpos, bool fcur, bool awidth, int clmn, TEnableChars echar)
		{
			this.FCurPos = cpos;
			this.FFreeCursor = fcur;
			this.FAutoWidth = awidth;
			this.FColumn = clmn;
			this.FEchars = echar;
			this.FEchars.WordChanged += new EventHandler(this.WordChanged);
		}
		protected virtual void OnAutoWidthChange(EventArgs e)
		{
			if (this.AutoWidthChange != null)
			{
				this.AutoWidthChange(this, e);
			}
		}
		protected virtual void OnColumnChange(EventArgs e)
		{
			if (this.ColumnChange != null)
			{
				this.ColumnChange(this, e);
			}
		}
		protected virtual void OnEnableCharsChange(EventArgs e)
		{
			if (this.EnableCharsChange != null)
			{
				this.EnableCharsChange(this, e);
			}
		}
		private void WordChanged(object sender, EventArgs e)
		{
			this.OnEnableCharsChange(e);
		}
	}
}
