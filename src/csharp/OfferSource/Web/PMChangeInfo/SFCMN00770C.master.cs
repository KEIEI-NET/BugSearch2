using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// Global.aspx アクセス用
using Globals = ASP.global_asax;

namespace Broadleaf.Web.UI
{
	/// <summary>
	/// 変更PG案内マスターWebページ
	/// </summary>
	/// <remarks>
	/// <br>Note       : 変更PG案内の各ページの枠組みとなるマスターページです。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.02.19</br>
	/// </remarks>
	public partial class SFCMN00770C : System.Web.UI.MasterPage
	{
		#region << Control Events >>

		#region ■Load イベント (SFCMN00770C)

		/// <summary>
		/// Load イベント (SFCMN00770C)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページがロードされるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		protected void Page_Load(object sender, EventArgs e)
		{
			// リターンキー押下の制御を行います。
			//this.form1.Attributes[ "onkeydown" ] = 
			//    "if( ( typeof( event.keyCode ) != 'undefined' ? event.keyCode : ( typeof( e.which ) != 'undefined' ? e.which : 0x00 ) ) == 0xd ) {" + 
			//    "return false; }";
		}

		#endregion

		#endregion
	}
}
