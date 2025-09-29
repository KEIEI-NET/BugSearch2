<%@ Application Language="C#" %>

<%@ Import Namespace="Broadleaf.Application.Common" %>

<script runat="server">
	
	/// <summary>アクセスチケット</summary>
	private static QueryStringController _queryStringController = null;
	
	/// <summary>
	/// アクセスチケットを取得します。
	/// </summary>
	public static QueryStringController QueryStringController
	{
		get {
			return _queryStringController;
		}
	}

	void Application_OnBeginRequest( object sender, EventArgs e )
	{
		if( _queryStringController == null ) {
			_queryStringController = new QueryStringController( this.Request );
		}
		else {
			_queryStringController.SetQueryString( this.Request );
		}
	}

	void Application_Error( object sender, EventArgs e )
	{
		try {
			Exception ex = this.Server.GetLastError().GetBaseException();
			
			// ログを出力
			ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();
			changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
			
			if( ex is NSChangeInfoErrorException ) {
			    NSChangeInfoErrorException nsEx = ex as NSChangeInfoErrorException;
				
			    // 認証エラー
			    if( nsEx.Status == -99 ) {
			        // HttpCode : 900 で HttpException をスロー
			        Response.Redirect( "~/ErrorPage/reject.htm" );
			    }
			    // その他のエラー
			    else {
			        // HttpCode : 950 で HttpException をスロー
			        Response.Redirect( "~/ErrorPage/error.htm" );
			    }
			}
			else if( ex is HttpException ) {
			    // そのまま飛ばす
			}
			else {
			    // HttpCode : 950 で HttpException をスロー
			    Response.Redirect( "~/ErrorPage/error.htm" );
			}
		}
		finally {
			this.Server.ClearError();
		}
	}
	
</script>
