using Broadleaf.Library.ComponentModel;
using System;
using System.ComponentModel;
using System.Drawing;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TAttack25), "TAttack25.bmp")]
	public class TAttack25 : TbsBaseComponent
	{
		private Container components;
		public TAttack25(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
		}
		public TAttack25()
		{
			this.InitializeComponent();
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
	}
}
