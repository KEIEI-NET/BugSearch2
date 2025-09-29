using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Broadleaf.Application.Common;

// Global.aspx アクセス用
using Globals = ASP.global_asax;

namespace Broadleaf.Web.UI
{
	public partial class _Default : System.Web.UI.Page 
	{
		
		protected void Page_Load(object sender, EventArgs e)
		{
			QueryStringController query = new QueryStringController();
			query.AccessTicket  = Globals.QueryStringController.AccessTicket;
			this.Response.Redirect( "SFCMN00771W.aspx" + query.ToString(), true );
		}
	}
}
