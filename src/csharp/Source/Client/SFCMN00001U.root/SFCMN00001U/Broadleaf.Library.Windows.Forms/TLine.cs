using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TLine), "TLine.bmp")]
	public class TLine : TGraphicControl
	{
		private Container components;
		private emLineType _lineType;
		[Category("Appearance"), DefaultValue(emLineType.ltHorizontal), Description("ラインの描画方向の取得、設定を行います。")]
		public emLineType LineType
		{
			get
			{
				return this._lineType;
			}
			set
			{
				if (this._lineType != value)
				{
					this._lineType = value;
					base.Invalidate();
				}
			}
		}
		public TLine()
		{
			this.InitializeComponent();
			this._lineType = emLineType.ltHorizontal;
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
		private void DrawRectangle(PaintEventArgs e, PointF p1, PointF p2)
		{
			Pen pen = new Pen(base.ForeColor, (float)base.Thick);
			new SolidBrush(base.BackColor);
			Graphics graphics = e.Graphics;
			if (base.LineStyle != emLineStyle.lsSolid && base.BackColor != Color.Transparent)
			{
				pen.Color = base.BackColor;
				pen.DashStyle = DashStyle.Solid;
				graphics.DrawRectangle(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
				pen.Color = base.ForeColor;
			}
			pen = base.GetCustomPen();
			graphics.DrawRectangle(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
		}
		private void DrawLine(PaintEventArgs e, PointF p1, PointF p2)
		{
			Pen pen = new Pen(base.ForeColor, (float)base.Thick);
			new SolidBrush(base.BackColor);
			Graphics graphics = e.Graphics;
			if (base.LineStyle != emLineStyle.lsSolid && base.BackColor != Color.Transparent)
			{
				pen.Color = base.BackColor;
				pen.DashStyle = DashStyle.Solid;
				graphics.DrawLine(pen, p1, p2);
				pen.Color = base.ForeColor;
			}
			pen = base.GetCustomPen();
			graphics.DrawLine(pen, p1, p2);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			this.CreateRegion();
			PointF p;
			PointF p2;
			switch (this._lineType)
			{
			case emLineType.ltHorizontal:
				p = new PointF(0f, (float)(base.Thick / 2));
				p2 = new PointF((float)(base.Size.Width - 1), (float)(base.Thick / 2));
				break;
			case emLineType.ltVertical:
				p = new PointF((float)(base.Thick / 2), 0f);
				p2 = new PointF((float)(base.Thick / 2), (float)(base.Size.Height - 1));
				break;
			case emLineType.ltDiagonal:
				p = new PointF(0f, 0f);
				p2 = new PointF((float)(base.Size.Width - 1), (float)(base.Size.Height - 1));
				break;
			case emLineType.ltBackDiagonal:
				p = new PointF(0f, (float)(base.Size.Height - 1));
				p2 = new PointF((float)(base.Size.Width - 1), 0f);
				break;
			case emLineType.ltBox:
				p = new PointF((float)(base.Thick / 2), (float)(base.Thick / 2));
				p2 = new PointF((float)(base.Size.Width - base.Thick), (float)(base.Size.Height - base.Thick));
				this.DrawRectangle(e, p, p2);
				return;
			default:
				return;
			}
			this.DrawLine(e, p, p2);
		}
		private void CreateRegion()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			float num = (float)((base.Thick < 2) ? 1 : (base.Thick / 2));
			switch (this._lineType)
			{
			case emLineType.ltHorizontal:
				graphicsPath.AddRectangle(new Rectangle(0, 0, base.Size.Width, base.Thick));
				break;
			case emLineType.ltVertical:
				graphicsPath.AddRectangle(new Rectangle(0, 0, base.Thick, base.Height));
				break;
			case emLineType.ltDiagonal:
				graphicsPath.AddLine(0f, 0f, num, 0f);
				graphicsPath.AddLine(num, 0f, (float)base.Size.Width, (float)base.Height - num);
				graphicsPath.AddLine((float)base.Size.Width, (float)base.Height - num, (float)base.Size.Width, (float)base.Size.Height);
				graphicsPath.AddLine((float)base.Size.Width, (float)base.Size.Height, (float)base.Size.Width - num, (float)base.Size.Height);
				graphicsPath.AddLine((float)base.Size.Width - num, (float)base.Size.Height, 0f, num);
				graphicsPath.AddLine(0f, num, 0f, 0f);
				graphicsPath.CloseFigure();
				break;
			case emLineType.ltBackDiagonal:
				graphicsPath.AddLine((float)base.Size.Width, 0f, (float)base.Size.Width, num);
				graphicsPath.AddLine((float)base.Size.Width, num, num, (float)base.Size.Height);
				graphicsPath.AddLine(num, (float)base.Size.Height, 0f, (float)base.Size.Height);
				graphicsPath.AddLine(0f, (float)base.Size.Height, 0f, (float)base.Size.Height - num);
				graphicsPath.AddLine(0f, (float)base.Size.Height - num, (float)base.Size.Width - num, 0f);
				graphicsPath.AddLine((float)base.Size.Width - num, 0f, (float)base.Size.Width, 0f);
				graphicsPath.CloseFigure();
				break;
			case emLineType.ltBox:
				graphicsPath.AddRectangle(new Rectangle(0, 0, base.Size.Width, base.Size.Height));
				graphicsPath.AddRectangle(new Rectangle(base.Thick, base.Thick, base.Size.Width - base.Thick * 2, base.Size.Height - base.Thick * 2));
				break;
			}
			base.Region = new Region(graphicsPath);
		}
	}
}
