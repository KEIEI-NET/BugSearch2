using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
namespace Broadleaf.Library.Windows.Forms
{
	[TypeConverter(typeof(TEnableEditors.TEnableEditorsConverter))]
	public class TEnableEditors
	{
		internal class TEnableEditorsConverter : ExpandableObjectConverter
		{
			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
			{
				if (value is string)
				{
					string text = (string)value;
					int num = text.IndexOf('[');
					int num2 = text.IndexOf(']');
					if (num != -1 && num2 != -1 && num < num2)
					{
						try
						{
							TEnableEditors tEnableEditors = new TEnableEditors(false, false, false, false);
							string text2 = text.Substring(num + 1, num2 - num - 1);
							string[] array = text2.Split(new char[]
							{
								','
							});
							string[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								string text3 = array2[i];
								string text4 = text3.Trim().ToUpper();
								if (text4.CompareTo("DEEJPN") == 0)
								{
									tEnableEditors.deeJpn = true;
								}
								if (text4.CompareTo("DEEYEAR") == 0)
								{
									tEnableEditors.deeYear = true;
								}
								if (text4.CompareTo("DEEMONTH") == 0)
								{
									tEnableEditors.deeMonth = true;
								}
								if (text4.CompareTo("DEEDAY") == 0)
								{
									tEnableEditors.deeDay = true;
								}
							}
							return tEnableEditors;
						}
						catch (Exception innerException)
						{
							throw new ArgumentException("Can not convert '" + (string)value + "' to type TEnableEditors", innerException);
						}
					}
				}
				return base.ConvertFrom(context, culture, value);
			}
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
			}
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (value is TEnableEditors)
				{
					if (destinationType == typeof(InstanceDescriptor))
					{
						TEnableEditors tEnableEditors = (TEnableEditors)value;
						ConstructorInfo constructor = typeof(TEnableEditors).GetConstructor(new Type[]
						{
							typeof(bool),
							typeof(bool),
							typeof(bool),
							typeof(bool)
						});
						if (constructor != null)
						{
							return new InstanceDescriptor(constructor, new object[]
							{
								tEnableEditors.deeJpn,
								tEnableEditors.deeYear,
								tEnableEditors.deeMonth,
								tEnableEditors.deeDay
							});
						}
					}
					else
					{
						if (destinationType == typeof(string))
						{
							TEnableEditors tEnableEditors2 = (TEnableEditors)value;
							string text = "";
							if (tEnableEditors2.deeJpn)
							{
								text += "deeJpn,";
							}
							if (tEnableEditors2.deeYear)
							{
								text += "deeYear,";
							}
							if (tEnableEditors2.deeMonth)
							{
								text += "deeMonth,";
							}
							if (tEnableEditors2.deeDay)
							{
								text += "deeDay,";
							}
							if (text.Length != 0)
							{
								text = text.Remove(text.Length - 1, 1);
							}
							return "[" + text + "]";
						}
					}
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}
		private bool FJapan;
		private bool FYear;
		private bool FMonth;
		private bool FDay;
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deeJpn
		{
			get
			{
				return this.FJapan;
			}
			set
			{
				this.FJapan = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deeYear
		{
			get
			{
				return this.FYear;
			}
			set
			{
				this.FYear = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deeMonth
		{
			get
			{
				return this.FMonth;
			}
			set
			{
				this.FMonth = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deeDay
		{
			get
			{
				return this.FDay;
			}
			set
			{
				this.FDay = value;
			}
		}
		public TEnableEditors() : this(true, true, true, true)
		{
		}
		public TEnableEditors(bool Japan, bool Year, bool Month, bool Day)
		{
			this.FJapan = Japan;
			this.FYear = Year;
			this.FMonth = Month;
			this.FDay = Day;
		}
	}
}
