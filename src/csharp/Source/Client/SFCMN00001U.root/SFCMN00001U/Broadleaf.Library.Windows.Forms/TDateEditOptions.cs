using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
namespace Broadleaf.Library.Windows.Forms
{
	[TypeConverter(typeof(TDateEditOptions.TDateEditOptionsConverter))]
	public class TDateEditOptions
	{
		internal class TDateEditOptionsConverter : ExpandableObjectConverter
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
							TDateEditOptions tDateEditOptions = new TDateEditOptions(false, false, false, false, false, false);
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
								if (text4.CompareTo("DEOZEROSUPPY") == 0)
								{
									tDateEditOptions.deoZeroSuppY = true;
								}
								if (text4.CompareTo("DEOZEROSUPPM") == 0)
								{
									tDateEditOptions.deoZeroSuppM = true;
								}
								if (text4.CompareTo("DEOZEROSUPPD") == 0)
								{
									tDateEditOptions.deoZeroSuppD = true;
								}
								if (text4.CompareTo("DEOYEARNAMELIST") == 0)
								{
									tDateEditOptions.deoYearNameList = true;
								}
								if (text4.CompareTo("DEOINPUTCHECK") == 0)
								{
									tDateEditOptions.deoInputCheck = true;
								}
								if (text4.CompareTo("DEOSEPARATE") == 0)
								{
									tDateEditOptions.deoSeparate = true;
								}
							}
							return tDateEditOptions;
						}
						catch (Exception innerException)
						{
							throw new ArgumentException("Can not convert '" + (string)value + "' to type TDateEditOptions", innerException);
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
				if (value is TDateEditOptions)
				{
					if (destinationType == typeof(InstanceDescriptor))
					{
						TDateEditOptions tDateEditOptions = (TDateEditOptions)value;
						ConstructorInfo constructor = typeof(TDateEditOptions).GetConstructor(new Type[]
						{
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
								tDateEditOptions.deoZeroSuppY,
								tDateEditOptions.deoZeroSuppM,
								tDateEditOptions.deoZeroSuppD,
								tDateEditOptions.deoYearNameList,
								tDateEditOptions.deoInputCheck,
								tDateEditOptions.deoSeparate
							});
						}
					}
					else
					{
						if (destinationType == typeof(string))
						{
							TDateEditOptions tDateEditOptions2 = (TDateEditOptions)value;
							string text = "";
							if (tDateEditOptions2.deoZeroSuppY)
							{
								text += "deoZeroSuppY,";
							}
							if (tDateEditOptions2.deoZeroSuppM)
							{
								text += "deoZeroSuppM,";
							}
							if (tDateEditOptions2.deoZeroSuppD)
							{
								text += "deoZeroSuppD,";
							}
							if (tDateEditOptions2.deoYearNameList)
							{
								text += "deoYearNameList,";
							}
							if (tDateEditOptions2.deoInputCheck)
							{
								text += "deoInputCheck,";
							}
							if (tDateEditOptions2.deoSeparate)
							{
								text += "deoSeparate,";
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
		private bool FZeroSuppYear;
		private bool FZeroSuppMonth;
		private bool FZeroSuppDay;
		private bool FYearNameList;
		private bool FInputCheck;
		private bool FSeparate;
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deoZeroSuppY
		{
			get
			{
				return this.FZeroSuppYear;
			}
			set
			{
				this.FZeroSuppYear = value;
			}
		}
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deoZeroSuppM
		{
			get
			{
				return this.FZeroSuppMonth;
			}
			set
			{
				this.FZeroSuppMonth = value;
			}
		}
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deoZeroSuppD
		{
			get
			{
				return this.FZeroSuppDay;
			}
			set
			{
				this.FZeroSuppDay = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deoYearNameList
		{
			get
			{
				return this.FYearNameList;
			}
			set
			{
				this.FYearNameList = value;
			}
		}
		[DefaultValue(false), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deoInputCheck
		{
			get
			{
				return this.FInputCheck;
			}
			set
			{
				this.FInputCheck = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool deoSeparate
		{
			get
			{
				return this.FSeparate;
			}
			set
			{
				this.FSeparate = value;
			}
		}
		public TDateEditOptions() : this(false, false, false, true, false, true)
		{
		}
		public TDateEditOptions(bool zsYear, bool zsMonth, bool zsDay, bool ynList, bool inChk, bool sep)
		{
			this.FZeroSuppYear = zsYear;
			this.FZeroSuppMonth = zsMonth;
			this.FZeroSuppDay = zsDay;
			this.FYearNameList = ynList;
			this.FInputCheck = inChk;
			this.FSeparate = sep;
		}
	}
}
