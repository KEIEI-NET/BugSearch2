using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
namespace Broadleaf.Library.ComponentModel
{
	public abstract class TbsBaseComponent : Component
	{
		private Container components;
		private ISynchronizeInvoke FOwnerForm;
		private bool bInitialized;
		[Category("Behavior"), Description("監視対象のフォームを指定します")]
		public virtual ISynchronizeInvoke OwnerForm
		{
			get
			{
				return this.FOwnerForm;
			}
			set
			{
				this.FOwnerForm = value;
			}
		}
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (base.DesignMode && !this.bInitialized && base.Site != null)
				{
					IDesignerHost designerHost = (IDesignerHost)base.Site.GetService(typeof(IDesignerHost));
					if (designerHost != null && designerHost.RootComponent != null)
					{
						if (designerHost.RootComponent is Form)
						{
							this.OwnerForm = (Form)designerHost.RootComponent;
							this.bInitialized = true;
							return;
						}
						if (designerHost.RootComponent is Control)
						{
							this.OwnerForm = (Control)designerHost.RootComponent;
							this.bInitialized = true;
						}
					}
				}
			}
		}
		public TbsBaseComponent(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
		}
		public TbsBaseComponent()
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
