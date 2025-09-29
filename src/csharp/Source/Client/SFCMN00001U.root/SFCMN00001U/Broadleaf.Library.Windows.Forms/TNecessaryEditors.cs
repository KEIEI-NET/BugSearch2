using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
namespace Broadleaf.Library.Windows.Forms
{
	[TypeConverter(typeof(TNecessaryEditors.TNecessaryEditorsConverter))]
	public class TNecessaryEditors
	{
		internal class TNecessaryEditorsConverter : ExpandableObjectConverter
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
							TNecessaryEditors tNecessaryEditors = new TNecessaryEditors(false, false, false, false);
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
								if (text4.CompareTo("DNEJPN") == 0)
								{
									tNecessaryEditors.dneJpn = true;
								}
								if (text4.CompareTo("DNEYEAR") == 0)
								{
									tNecessaryEditors.dneYear = true;
								}
								if (text4.CompareTo("DNEMONTH") == 0)
								{
									tNecessaryEditors.dneMonth = true;
								}
								if (text4.CompareTo("DNEDAY") == 0)
								{
									tNecessaryEditors.dneDay = true;
								}
							}
							return tNecessaryEditors;
						}
						catch (Exception innerException)
						{
							throw new ArgumentException("Can not convert '" + (string)value + "' to type TNecessaryEditors", innerException);
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
				if (value is TNecessaryEditors)
				{
					if (destinationType == typeof(InstanceDescriptor))
					{
						TNecessaryEditors tNecessaryEditors = (TNecessaryEditors)value;
						ConstructorInfo constructor = typeof(TNecessaryEditors).GetConstructor(new Type[]
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
								tNecessaryEditors.dneJpn,
								tNecessaryEditors.dneYear,
								tNecessaryEditors.dneMonth,
								tNecessaryEditors.dneDay
							});
						}
					}
					else
					{
						if (destinationType == typeof(string))
						{
							TNecessaryEditors tNecessaryEditors2 = (TNecessaryEditors)value;
							string text = "";
							if (tNecessaryEditors2.dneJpn)
							{
								text += "dneJpn,";
							}
							if (tNecessaryEditors2.dneYear)
							{
								text += "dneYear,";
							}
							if (tNecessaryEditors2.dneMonth)
							{
								text += "dneMonth,";
							}
							if (tNecessaryEditors2.dneDay)
							{
								text += "dneDay,";
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
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool dneJpn
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
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool dneYear
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
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool dneMonth
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
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool dneDay
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
		public TNecessaryEditors() : this(false, false, false, false)
		{
		}
		public TNecessaryEditors(bool Japan, bool Year, bool Month, bool Day)
		{
			this.FJapan = Japan;
			this.FYear = Year;
			this.FMonth = Month;
			this.FDay = Day;
		}
	}
}
