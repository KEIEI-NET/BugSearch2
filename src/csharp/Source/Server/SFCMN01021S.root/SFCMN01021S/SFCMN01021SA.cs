using System;
using System.Data;
using System.ServiceProcess;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.ServiceProcess
{

	/// <summary>
	/// ユーザーAPリモートプロキシサーバークラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはリモートオブジェクトのプロキシクラスです。</br>
	/// <br>Programmer : 20402　杉村 利彦</br>
	/// <br>Date       : 2009.04.02</br>
	/// </remarks>
	public class Tbs021ServerService : System.ServiceProcess.ServiceBase
	{

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Tbs021ServerService()
		{
			// この呼び出しは、Windows.Forms コンポーネント デザイナで必要です。
			InitializeComponent();

			// TODO: InitComponent 呼び出しの後に初期化処理を追加してください。
		}

		// 処理のメイン エントリ ポイントです。
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// 2 つ以上の NT サービスを同じ処理内で実行できます。別のサービスを
			// この処理に追加するには、以下の行を変更して
			// 2 番目のサービス オブジェクトを作成してください。例 :
			//
			//   ServicesToRun = New System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Tbs021ServerService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Tbs001ServerService
			// 
			this.ServiceName = "Tbs021ServerService";

		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// 動作が滞りなく行われ、サービスの実行が妨げられないように設定します。
		/// </summary>
		protected override void OnStart(string[] args)
		{
			try
			{
                //サービススタート
                int status = ServerServiceStartControl.StartServerService(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_Center_UserAP, Tbs021ServerServiceResource.GetRemoteResource());
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    WriteErrorLog(this.ServiceName, "OnStart", string.Format("StartServerServiceにてERROR発生。サーバー環境を見直してください"), null, status);
                }
			}
			catch(Exception ex)
			{
				WriteErrorLog(this.ServiceName,"OnStart",ex.Message,ex,-1);
			}
		}

		/// <summary>
		/// エラーLog生成
		/// </summary>
		/// <param name="pgId"></param>
		/// <param name="method"></param>
		/// <param name="Msg"></param>
		/// <param name="ex"></param>
		/// <param name="status"></param>
		private void WriteErrorLog(string pgId,string method,string Msg,Exception ex,int status)
		{
			string exceptionMsg = "無し";
			if (ex != null) exceptionMsg = ex.Message;
			string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}",method,Msg,exceptionMsg);
			LogTextOut logTextOut = new LogTextOut();
			logTextOut.Output(pgId,msg,status);
            this.Stop();    //2006.07.11 add 久保田
		}
 
		/// <summary>
		/// このサービスを停止します。
		/// </summary>
		protected override void OnStop()
		{
			// TODO: サービスを停止するのに必要な終了処理を実行するコードをここに追加します。
		}

	}


}
