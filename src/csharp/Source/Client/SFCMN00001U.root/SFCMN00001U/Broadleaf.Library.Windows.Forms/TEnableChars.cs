using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Broadleaf.Library.Windows.Forms
{
	[TypeConverter(typeof(TEnableChars.TEnableCharsConverter))]
	public class TEnableChars
	{
		internal class TEnableCharsConverter : ExpandableObjectConverter
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
						TEnableChars tEnableChars = new TEnableChars();
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
							case "WORD":
								tEnableChars.Word = true;
								break;
							case "SPACE":
								tEnableChars.Space = true;
								break;
							case "SIGN":
								tEnableChars.Sign = true;
								break;
							case "KANA":
								tEnableChars.Kana = true;
								break;
							case "ALPHA":
								tEnableChars.Alpha = true;
								break;
							case "NUMSIGN":
								tEnableChars.NumSign = true;
								break;
							case "NUM":
								tEnableChars.Num = true;
								break;
							}
							text2 = text2.Substring(num3 + 1, text2.Length - num3 - 1);
						}
						return tEnableChars;
					}
					catch (Exception innerException)
					{
						throw new ArgumentException("Can not convert '" + (string)value + "'to type HEnableChars", innerException);
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
				if (destType == typeof(InstanceDescriptor) && value is TEnableChars)
				{
					TEnableChars tEnableChars = (TEnableChars)value;
					ConstructorInfo constructor = typeof(TEnableChars).GetConstructor(new Type[]
					{
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
							tEnableChars.Word,
							tEnableChars.Space,
							tEnableChars.Sign,
							tEnableChars.Kana,
							tEnableChars.Alpha,
							tEnableChars.NumSign,
							tEnableChars.Num
						});
					}
				}
				else
				{
					if (destType == typeof(string) && value is TEnableChars)
					{
						TEnableChars tEnableChars2 = (TEnableChars)value;
						string text = "[";
						if (tEnableChars2.Word)
						{
							text += "Word,";
						}
						if (tEnableChars2.Space)
						{
							text += "Space,";
						}
						if (tEnableChars2.Sign)
						{
							text += "Sign,";
						}
						if (tEnableChars2.Kana)
						{
							text += "Kana,";
						}
						if (tEnableChars2.Alpha)
						{
							text += "Alpha,";
						}
						if (tEnableChars2.NumSign)
						{
							text += "NumSign,";
						}
						if (tEnableChars2.Num)
						{
							text += "Num,";
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
		private bool FWord;
		private bool FSpace;
		private bool FSign;
		private bool FKana;
		private bool FAlpha;
		private bool FNumSign;
		private bool FNum;
        public event EventHandler WordChanged;
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Word
		{
			get
			{
				return this.FWord;
			}
			set
			{
				if (this.FWord != value)
				{
					this.FWord = value;
					EventArgs e = new EventArgs();
					this.OnWordChanged(e);
				}
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Space
		{
			get
			{
				return this.FSpace;
			}
			set
			{
				this.FSpace = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Sign
		{
			get
			{
				return this.FSign;
			}
			set
			{
				this.FSign = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Kana
		{
			get
			{
				return this.FKana;
			}
			set
			{
				this.FKana = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Alpha
		{
			get
			{
				return this.FAlpha;
			}
			set
			{
				this.FAlpha = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool NumSign
		{
			get
			{
				return this.FNumSign;
			}
			set
			{
				this.FNumSign = value;
			}
		}
		[DefaultValue(true), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool Num
		{
			get
			{
				return this.FNum;
			}
			set
			{
				this.FNum = value;
			}
		}
		public TEnableChars() : this(true, true, true, true, true, true, true)
		{
		}
		public TEnableChars(bool wd, bool sp, bool si, bool ka, bool al, bool ns, bool nu)
		{
			this.FWord = wd;
			this.FSpace = sp;
			this.FSign = si;
			this.FKana = ka;
			this.FAlpha = al;
			this.FNumSign = ns;
			this.FNum = nu;
		}
		private void OnWordChanged(EventArgs e)
		{
			if (this.WordChanged != null)
			{
				this.WordChanged(this, e);
			}
		}
	}
}
