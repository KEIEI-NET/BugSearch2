using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
namespace Broadleaf.Library.Windows.Forms
{
	[Editor(typeof(TNumEditValueEditor), typeof(UITypeEditor)), TypeConverter(typeof(TNumEdit.TNumEditConverter))]
	public class TNumEdit
	{
		internal class TNumEditConverter : ExpandableObjectConverter
		{
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
			}
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (destinationType == typeof(InstanceDescriptor) && value is TNumEdit)
				{
					TNumEdit tNumEdit = (TNumEdit)value;
					ConstructorInfo constructor = typeof(TNumEdit).GetConstructor(new Type[]
					{
						typeof(bool),
						typeof(int),
						typeof(bool),
						typeof(bool),
						typeof(bool),
						typeof(emZeroSupp)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[]
						{
							tNumEdit.CalcInput,
							tNumEdit.DecLen,
							tNumEdit.CommaEdit,
							tNumEdit.MinusSupp,
							tNumEdit.ZeroDisp,
							tNumEdit.ZeroSupp
						});
					}
				}
				else
				{
					if (destinationType == typeof(string) && value is TNumEdit)
					{
						return "(TNumEdit)";
					}
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}
		private bool FCalcInput;
		private int FDecLen;
		private bool FCommaEdit;
		private bool FMinusSupp;
		private bool FZeroDisp;
		private emZeroSupp FZeroSupp = emZeroSupp.zsOFF;
		[DefaultValue(false), Description("入力方法を電卓形式で行うかを取得、設定できます。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool CalcInput
		{
			get
			{
				return this.FCalcInput;
			}
			set
			{
				this.FCalcInput = value;
			}
		}
		[DefaultValue(0), Description("小数の桁数を設定します"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public int DecLen
		{
			get
			{
				return this.FDecLen;
			}
			set
			{
				this.FDecLen = value;
			}
		}
		[DefaultValue(false), Description("カンマ編集を行うかを取得、設定できます。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool CommaEdit
		{
			get
			{
				return this.FCommaEdit;
			}
			set
			{
				this.FCommaEdit = value;
			}
		}
		[DefaultValue(false), Description("マイナス入力を抑制するかを取得、設定できます。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool MinusSupp
		{
			get
			{
				return this.FMinusSupp;
			}
			set
			{
				this.FMinusSupp = value;
			}
		}
		[DefaultValue(false), Description("ゼロを表示するかを取得、設定できます。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public bool ZeroDisp
		{
			get
			{
				return this.FZeroDisp;
			}
			set
			{
				this.FZeroDisp = value;
			}
		}
		[DefaultValue(emZeroSupp.zsOFF), Description("ゼロ抑制の形式を取得、設定できます。"), NotifyParentProperty(true), RefreshProperties(RefreshProperties.All)]
		public emZeroSupp ZeroSupp
		{
			get
			{
				return this.FZeroSupp;
			}
			set
			{
				this.FZeroSupp = value;
			}
		}
		public TNumEdit()
		{
		}
		public TNumEdit(bool iCaclInput, int iDecLen, bool iCommaEdit, bool iMinusSupp, bool iZeroDisp, emZeroSupp iZeroSupp)
		{
			this.FCalcInput = iCaclInput;
			this.FDecLen = iDecLen;
			this.FCommaEdit = iCommaEdit;
			this.FMinusSupp = iMinusSupp;
			this.FZeroDisp = iZeroDisp;
			this.FZeroSupp = iZeroSupp;
		}
	}
}
