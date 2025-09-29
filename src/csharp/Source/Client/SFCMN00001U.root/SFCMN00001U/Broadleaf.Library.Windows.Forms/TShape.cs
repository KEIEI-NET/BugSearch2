using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TShape), "TShape.bmp")]
	public class TShape : TGraphicControl
	{
		private Container components;
		private bool _fillMode;
		private HatchStyle _hatchStyle;
		private Color _styleForecolor;
		private Color _styleBackcolor;
		private emShapeStyle _shapeStyle;
		private emShapeRotation _shapeRotation;
		private int _roundrectsize;
		[Category("Appearance"), DefaultValue(10), Description("ShapeStyle=ssRoundrectの場合の角丸部分の直径を設定、取得します。")]
		public int RoundSize
		{
			get
			{
				return this._roundrectsize;
			}
			set
			{
				if (value == 0)
				{
					return;
				}
				if (this._roundrectsize != value)
				{
					this._roundrectsize = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("図形内を塗りつぶすかを設定、取得します。")]
		public bool FillMode
		{
			get
			{
				return this._fillMode;
			}
			set
			{
				if (this._fillMode != value)
				{
					this._fillMode = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(HatchStyle.Cross), Description("図形内の網掛けパターンを設定、取得します。")]
		public HatchStyle HatchStyle
		{
			get
			{
				return this._hatchStyle;
			}
			set
			{
				if (this._hatchStyle != value)
				{
					this._hatchStyle = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), Description("網掛け描画を行う場合の網掛け部分の前景色")]
		public Color HatchForeColor
		{
			get
			{
				return this._styleForecolor;
			}
			set
			{
				if (this._styleForecolor != value)
				{
					this._styleForecolor = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), Description("網掛け描画を行う場合の網掛け部分の背景色")]
		public Color HatchBackColor
		{
			get
			{
				return this._styleBackcolor;
			}
			set
			{
				if (this._styleBackcolor != value)
				{
					this._styleBackcolor = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(emShapeStyle.ssEllipse), Description("描画する図形を指定、取得します。")]
		public emShapeStyle ShapeStyle
		{
			get
			{
				return this._shapeStyle;
			}
			set
			{
				if (this._shapeStyle != value)
				{
					this._shapeStyle = value;
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(emShapeRotation.sr000), Description("描画する図形の回転角度を90°単位に指定します。")]
		public emShapeRotation Rotation
		{
			get
			{
				return this._shapeRotation;
			}
			set
			{
				if (this._shapeRotation != value)
				{
					this._shapeRotation = value;
					base.Invalidate();
				}
			}
		}
		public TShape()
		{
			this.InitializeComponent();
			this._roundrectsize = 10;
			this._fillMode = false;
			this._hatchStyle = HatchStyle.Cross;
			this._shapeStyle = emShapeStyle.ssEllipse;
			this._shapeRotation = emShapeRotation.sr000;
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
		protected override void OnPaint(PaintEventArgs e)
		{
			this.CreateRegion();
			GraphicsPath path = this.MakeShape();
			Brush brush;
			if (this._fillMode)
			{
				brush = new SolidBrush(this._styleForecolor);
			}
			else
			{
				brush = new HatchBrush(this._hatchStyle, this._styleForecolor, this._styleBackcolor);
			}
			e.Graphics.FillPath(brush, path);
			Pen pen;
			if (base.LineStyle != emLineStyle.lsSolid && this.BackColor != Color.Transparent)
			{
				pen = new Pen(this.BackColor, (float)base.Thick);
				pen.DashStyle = DashStyle.Solid;
				e.Graphics.DrawPath(pen, path);
			}
			pen = base.GetCustomPen();
			e.Graphics.DrawPath(pen, path);
		}
		private GraphicsPath MakeShape()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			float num = (float)(base.Thick / 2);
			float num2 = (float)(base.Thick / 2);
			float num3 = (float)(base.Size.Width - base.Thick / 2) - 1f;
			float num4 = (float)(base.Size.Height - base.Thick / 2) - 1f;
			PointF[] array = new PointF[3];
			switch (this._shapeStyle)
			{
			case emShapeStyle.ssEllipse:
				graphicsPath.AddEllipse(num + 0.5f, num2 + 0.5f, num3 - num, num4 - num2);
				break;
			case emShapeStyle.ssRectangle:
				graphicsPath.AddRectangle(new RectangleF(num, num2, num3 - num, num4 - num2));
				break;
			case emShapeStyle.ssRoundrect:
			{
				float x = num3 - (float)(this._roundrectsize * 2);
				float y = num4 - (float)(this._roundrectsize * 2);
				float width = (float)(this._roundrectsize * 2);
				float height = (float)(this._roundrectsize * 2);
				graphicsPath.AddArc(x, num2 + 0.5f, width, height, -90f, 90f);
				graphicsPath.AddArc(x, y, width, height, 0f, 90f);
				graphicsPath.AddArc(num + 0.5f, y, width, height, 90f, 90f);
				graphicsPath.AddArc(num + 0.5f, num2 + 0.5f, width, height, 180f, 90f);
				break;
			}
			case emShapeStyle.ssTriangle:
				switch (this._shapeRotation)
				{
				case emShapeRotation.sr090:
					array[0] = new PointF(num, num2 + 0.5f);
					array[1] = new PointF(num3 - 1f, (float)(base.Size.Height / 2));
					array[2] = new PointF(num, num4 - 0.5f);
					break;
				case emShapeRotation.sr180:
					array[0] = new PointF(num + 0.5f, num2);
					array[1] = new PointF(num3 - 0.5f, num2);
					array[2] = new PointF((float)(base.Size.Width / 2), num4 - 0.5f);
					break;
				case emShapeRotation.sr270:
					array[0] = new PointF(num + 0.5f, (float)(base.Size.Height / 2));
					array[1] = new PointF(num3, num2 + 0.5f);
					array[2] = new PointF(num3, num4 - 0.5f);
					break;
				default:
					array[0] = new PointF((float)(base.Size.Width / 2), num2 + 1f);
					array[1] = new PointF(num3 - 0.5f, num4);
					array[2] = new PointF(num + 0.5f, num4);
					break;
				}
				graphicsPath.AddPolygon(array);
				break;
			case emShapeStyle.ssTriangle90L:
				switch (this._shapeRotation)
				{
				case emShapeRotation.sr090:
					array[0] = new PointF(num, num2);
					array[1] = new PointF(num3 - 1f, num2);
					array[2] = new PointF(num, num4 - 1f);
					break;
				case emShapeRotation.sr180:
					array[0] = new PointF(num + 1f, num2);
					array[1] = new PointF(num3, num2);
					array[2] = new PointF(num3, num4 - 1f);
					break;
				case emShapeRotation.sr270:
					array[0] = new PointF(num + 1f, num4);
					array[1] = new PointF(num3, num2 + 1f);
					array[2] = new PointF(num3, num4);
					break;
				default:
					array[0] = new PointF(num, num2 + 1f);
					array[1] = new PointF(num3 - 1f, num4);
					array[2] = new PointF(num, num4);
					break;
				}
				graphicsPath.AddPolygon(array);
				break;
			case emShapeStyle.ssTriangle90R:
				switch (this._shapeRotation)
				{
				case emShapeRotation.sr090:
					array[0] = new PointF(num, num2 + 1f);
					array[1] = new PointF(num3 - 1f, num4);
					array[2] = new PointF(num, num4);
					break;
				case emShapeRotation.sr180:
					array[0] = new PointF(num, num2);
					array[1] = new PointF(num3 - 1f, num2);
					array[2] = new PointF(num, num4 - 1f);
					break;
				case emShapeRotation.sr270:
					array[0] = new PointF(num + 1f, num2);
					array[1] = new PointF(num3, num2);
					array[2] = new PointF(num3, num4 - 1f);
					break;
				default:
					array[0] = new PointF(num + 1f, num4);
					array[1] = new PointF(num3, num2 + 1f);
					array[2] = new PointF(num3, num4);
					break;
				}
				graphicsPath.AddPolygon(array);
				break;
			}
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		private void CreateRegion()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			float num = 0f;
			float num2 = 0f;
			float num3 = (float)base.Size.Width;
			float num4 = (float)base.Size.Height;
			switch (this._shapeStyle)
			{
			case emShapeStyle.ssEllipse:
				graphicsPath.AddEllipse(0f, 0f, num3 - num, num4 - num2);
				break;
			case emShapeStyle.ssRectangle:
				graphicsPath.AddRectangle(new RectangleF(num, num2, num3 - num, num4 - num2));
				break;
			case emShapeStyle.ssRoundrect:
			{
				float num5 = num + (float)this._roundrectsize;
				float num6 = num3 - (float)this._roundrectsize;
				float x = num3 - (float)(this._roundrectsize * 2);
				float num7 = num2 + (float)this._roundrectsize;
				float num8 = num4 - (float)this._roundrectsize;
				float y = num4 - (float)(this._roundrectsize * 2);
				float width = (float)(this._roundrectsize * 2);
				float height = (float)(this._roundrectsize * 2);
				graphicsPath.AddLine(num5, num2, num6, num2);
				graphicsPath.AddArc(x, num2, width, height, -90f, 90f);
				graphicsPath.AddLine(num3, num7, num3, num8);
				graphicsPath.AddArc(x, y, width, height, 0f, 90f);
				graphicsPath.AddLine(num6, num4, num5, num4);
				graphicsPath.AddArc(num, y, width, height, 90f, 90f);
				graphicsPath.AddLine(num, num8, num, num7);
				graphicsPath.AddArc(num, num2, width, height, 180f, 90f);
				break;
			}
			case emShapeStyle.ssTriangle:
				switch (this._shapeRotation)
				{
				case emShapeRotation.sr090:
					graphicsPath.AddLine(num, num2, num3, (float)(base.Size.Height / 2));
					graphicsPath.AddLine(num3, (float)(base.Size.Height / 2), num, num4);
					graphicsPath.AddLine(num, num4, num, num2);
					break;
				case emShapeRotation.sr180:
					graphicsPath.AddLine(num, num2, num3, num2);
					graphicsPath.AddLine(num3, num2, (float)(base.Size.Width / 2), num4);
					graphicsPath.AddLine((float)(base.Size.Width / 2), num4, num, num2);
					break;
				case emShapeRotation.sr270:
					graphicsPath.AddLine(num, (float)(base.Size.Height / 2), num3, num2);
					graphicsPath.AddLine(num3, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, (float)(base.Size.Height / 2));
					break;
				default:
					graphicsPath.AddLine((float)(base.Size.Width / 2), num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num4);
					graphicsPath.AddLine(num, num4, (float)(base.Size.Width / 2), num2);
					break;
				}
				break;
			case emShapeStyle.ssTriangle90L:
				switch (this._shapeRotation)
				{
				case emShapeRotation.sr090:
					graphicsPath.AddLine(num, num2, num3, num2);
					graphicsPath.AddLine(num3, num2, num, num4);
					graphicsPath.AddLine(num, num4, num, num2);
					break;
				case emShapeRotation.sr180:
					graphicsPath.AddLine(num, num2, num3, num2);
					graphicsPath.AddLine(num3, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num2);
					break;
				case emShapeRotation.sr270:
					graphicsPath.AddLine(num, num4, num3, num2);
					graphicsPath.AddLine(num3, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num4);
					break;
				default:
					graphicsPath.AddLine(num, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num4);
					graphicsPath.AddLine(num, num4, num, num2);
					break;
				}
				break;
			case emShapeStyle.ssTriangle90R:
				switch (this._shapeRotation)
				{
				case emShapeRotation.sr090:
					graphicsPath.AddLine(num, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num4);
					graphicsPath.AddLine(num, num4, num, num2);
					break;
				case emShapeRotation.sr180:
					graphicsPath.AddLine(num, num2, num3, num2);
					graphicsPath.AddLine(num3, num2, num, num4);
					graphicsPath.AddLine(num, num4, num, num2);
					break;
				case emShapeRotation.sr270:
					graphicsPath.AddLine(num, num2, num3, num2);
					graphicsPath.AddLine(num3, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num2);
					break;
				default:
					graphicsPath.AddLine(num, num4, num3, num2);
					graphicsPath.AddLine(num3, num2, num3, num4);
					graphicsPath.AddLine(num3, num4, num, num4);
					break;
				}
				break;
			}
			graphicsPath.CloseFigure();
			base.Region = new Region(graphicsPath);
		}
	}
}
