using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
namespace Broadleaf.Library.Windows.Forms
{
	[Editor(typeof(TEditValueEditor), typeof(UITypeEditor)), TypeConverter(typeof(TExtCase.TExtCaseConverter))]
	public class TExtCase
	{
		internal class TExtCaseConverter : ExpandableObjectConverter
		{
			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo info, object value)
			{
				string text = (string)value;
				int num = text.IndexOf('[');
				int num2 = text.IndexOf(']');
				if (num != -1 && num2 != -1 && num < num2)
				{
					try
					{
						TExtCase tExtCase = new TExtCase();
						string text2 = text.Substring(num + 1, num2 - num - 1);
						while (text2.Length > 0)
						{
							int num3 = text2.IndexOf(',');
							string text3;
							if (num3 != -1)
							{
								text3 = text2;
							}
							else
							{
								text3 = text2.Substring(0, num3);
							}
							text3 = text3.Trim().ToUpper();
							string key;
							switch (key = text3)
							{
							case "DOWNKEY":
								tExtCase.DownKey = true;
								break;
							case "LEFTKEY":
								tExtCase.LeftKey = true;
								break;
							case "NECESSARY":
								tExtCase.Necessary = true;
								break;
							case "RETKEY":
								tExtCase.RetKey = true;
								break;
							case "RIGHTKEY":
								tExtCase.RightKey = true;
								break;
							case "SHIFTRETKEY":
								tExtCase.ShiftRetKey = true;
								break;
							case "SHIFTTABKEY":
								tExtCase.ShiftTabKey = true;
								break;
							case "TABKEY":
								tExtCase.TabKey = true;
								break;
							case "UPKEY":
								tExtCase.UpKey = true;
								break;
							}
							text2 = text2.Substring(num3 + 1, text2.Length - num3 - 1);
						}
						return tExtCase;
					}
					catch (Exception innerException)
					{
						throw new ArgumentException("Can not convert '" + (string)value + "'to type Person", innerException);
					}
				}
				return base.ConvertFrom(context, info, value);
			}
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
			}
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
			{
				if (destType == typeof(InstanceDescriptor) && value is TExtCase)
				{
					TExtCase tExtCase = (TExtCase)value;
					ConstructorInfo constructor = typeof(TExtCase).GetConstructor(new Type[]
					{
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(bool)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[]
						{
							tExtCase.DownKey,
							tExtCase.UpKey,
							tExtCase.LeftKey,
							tExtCase.RightKey,
							tExtCase.RetKey,
							tExtCase.ShiftRetKey,
							tExtCase.TabKey,
							tExtCase.ShiftTabKey,
							tExtCase.Necessary
						});
					}
				}
				else
				{
					if (destType == typeof(string) && value is TExtCase)
					{
						TExtCase tExtCase2 = (TExtCase)value;
						string text = "[";
						if (tExtCase2.DownKey)
						{
							text += "DownKey,";
						}
						if (tExtCase2.LeftKey)
						{
							text += "LeftKey,";
						}
						if (tExtCase2.Necessary)
						{
							text += "Nessary,";
						}
						if (tExtCase2.RetKey)
						{
							text += "RetKey,";
						}
						if (tExtCase2.RightKey)
						{
							text += "RightKey,";
						}
						if (tExtCase2.ShiftRetKey)
						{
							text += "ShiftRetKey,";
						}
						if (tExtCase2.ShiftTabKey)
						{
							text += "ShiftTabKey,";
						}
						if (tExtCase2.TabKey)
						{
							text += "TabKey,";
						}
						if (tExtCase2.UpKey)
						{
							text += "UpKey,";
						}
						if (text.Length > 1)
						{
							text = text.Substring(0, text.Length - 1);
						}
						return text + "]";
					}
				}
				return base.ConvertTo(context, culture, value, destType);
			}
		}
		private bool FDownKey = true;
		private bool FLeftKey = true;
		private bool FNecessary;
		private bool FRetKey = true;
		private bool FRightKey = true;
		private bool FShiftRetKey = true;
		private bool FShiftTabKey = true;
		private bool FTabKey = true;
		private bool FUpKey = true;
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool DownKey
		{
			get
			{
				return this.FDownKey;
			}
			set
			{
				this.FDownKey = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool LeftKey
		{
			get
			{
				return this.FLeftKey;
			}
			set
			{
				this.FLeftKey = value;
			}
		}
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Necessary
		{
			get
			{
				return this.FNecessary;
			}
			set
			{
				this.FNecessary = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool RetKey
		{
			get
			{
				return this.FRetKey;
			}
			set
			{
				this.FRetKey = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool RightKey
		{
			get
			{
				return this.FRightKey;
			}
			set
			{
				this.FRightKey = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool ShiftRetKey
		{
			get
			{
				return this.FShiftRetKey;
			}
			set
			{
				this.FShiftRetKey = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool ShiftTabKey
		{
			get
			{
				return this.FShiftTabKey;
			}
			set
			{
				this.FShiftTabKey = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool TabKey
		{
			get
			{
				return this.FTabKey;
			}
			set
			{
				this.FTabKey = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool UpKey
		{
			get
			{
				return this.FUpKey;
			}
			set
			{
				this.FUpKey = value;
			}
		}
		public TExtCase()
		{
		}
		public TExtCase(bool dkey, bool ukey, bool lkey, bool rkey, bool retkey, bool sretkey, bool tabkey, bool stabkey, bool nece)
		{
			this.FDownKey = dkey;
			this.FLeftKey = lkey;
			this.FNecessary = nece;
			this.FRetKey = retkey;
			this.FRightKey = rkey;
			this.FShiftRetKey = sretkey;
			this.FShiftTabKey = stabkey;
			this.FTabKey = tabkey;
			this.FUpKey = ukey;
		}
	}
}
