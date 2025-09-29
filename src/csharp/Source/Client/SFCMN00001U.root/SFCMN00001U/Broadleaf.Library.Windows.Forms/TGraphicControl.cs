using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	public abstract class TGraphicControl : Control, ISupportInitialize
	{
		private Container components;
		private int _thick;
		private emLineStyle _lineStyle;
		private int _pattern;
		[Browsable(false), DefaultValue(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}
		[Browsable(false)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}
		[Category("Appearance"), DefaultValue(1), Description("ラインの太さの取得、設定を行います。")]
		public int Thick
		{
			get
			{
				return this._thick;
			}
			set
			{
				if (this._thick != value)
				{
					this._thick = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(emLineStyle.lsSolid), Description("ライン種類(実線、破線・・・)の取得、設定を行います。")]
		public emLineStyle LineStyle
		{
			get
			{
				return this._lineStyle;
			}
			set
			{
				if (this._lineStyle != value)
				{
					this._lineStyle = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(0), Description("ラインパターンの取得設定を行います。LineStyleプロパティがlsPatternの場合に使用します。")]
		public int Pattern
		{
			get
			{
				return this._pattern;
			}
			set
			{
				if (this._pattern != value)
				{
					this._pattern = value;
					base.Invalidate();
				}
			}
		}
		public TGraphicControl()
		{
			this.InitializeComponent();
			this._lineStyle = emLineStyle.lsSolid;
			this._thick = 1;
			this._pattern = 0;
			this.TabStop = false;
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		protected Pen GetCustomPen()
		{
			Pen pen = new Pen(this.ForeColor, (float)this._thick);
			if (this._lineStyle != emLineStyle.lsPattern)
			{
				switch (this._lineStyle)
				{
				case emLineStyle.lsSolid:
					pen.DashStyle = DashStyle.Solid;
					break;
				case emLineStyle.lsDot:
					pen.DashStyle = DashStyle.Dot;
					break;
				case emLineStyle.lsCsDot:
					pen.DashStyle = DashStyle.DashDot;
					break;
				case emLineStyle.lsDash:
					pen.DashStyle = DashStyle.Dash;
					break;
				case emLineStyle.lsCsDash:
					pen.DashStyle = DashStyle.DashDotDot;
					break;
				}
			}
			else
			{
				if (this._pattern == 0)
				{
					pen.DashStyle = DashStyle.Solid;
				}
				else
				{
					pen.DashStyle = DashStyle.Custom;
					int num = 0;
					int num2 = 32768;
					bool flag = false;
					int num3 = 0;
					for (int i = 0; i < 16; i++)
					{
						if ((num2 & this._pattern) != 0 != flag)
						{
							if (num3 > 0)
							{
								num++;
							}
							num3 = 1;
							flag = ((num2 & this._pattern) != 0);
						}
						else
						{
							num3++;
						}
						num2 >>= 1;
					}
					if (num3 > 0)
					{
						num++;
					}
					float[] array = new float[num];
					num2 = 32768;
					flag = false;
					num = 0;
					num3 = 0;
					for (int j = 0; j < 16; j++)
					{
						if ((num2 & this._pattern) != 0 != flag)
						{
							if (num3 > 0)
							{
								array[num] = (float)num3;
								num++;
							}
							num3 = 1;
							flag = ((num2 & this._pattern) != 0);
						}
						else
						{
							num3++;
						}
						num2 >>= 1;
					}
					if (num3 > 0)
					{
						array[num] = (float)num3;
					}
					pen.DashPattern = array;
				}
			}
			return pen;
		}
		public void BeginInit()
		{
		}
		public void EndInit()
		{
		}
	}
}
