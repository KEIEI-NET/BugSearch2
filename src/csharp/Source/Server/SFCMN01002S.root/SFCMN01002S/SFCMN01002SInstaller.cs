using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace Broadleaf.ServiceProcess
{
	/// <summary>
	/// ProjectInstaller の概要の説明です。
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller2;
		private System.ServiceProcess.ServiceInstaller serviceInstaller2;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// プロジェクトインストーラ
		/// </summary>
		public ProjectInstaller()
		{
			// この呼び出しはデザイナで必要です。
			InitializeComponent();

			// TODO: InitializeComponent 呼び出しの後に初期化処理を追加します。
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.serviceProcessInstaller2 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller2 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller2
            // 
            this.serviceProcessInstaller2.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller2.Password = null;
            this.serviceProcessInstaller2.Username = null;
            // 
            // serviceInstaller2
            // 
            this.serviceInstaller2.DisplayName = "Partsman.NS RemoteProxyServer002";
            this.serviceInstaller2.ServiceName = "PM002ServerService";
            this.serviceInstaller2.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller2,
            this.serviceInstaller2});

		}
		#endregion
	}
}
