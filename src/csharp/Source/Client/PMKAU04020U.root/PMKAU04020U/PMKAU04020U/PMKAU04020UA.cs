using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;// -- Add 2012.07.06 30182 R.Tachiya --
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Lifetime;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;// -- Add 2012.07.06 30182 R.Tachiya --
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// アプリケーションコントロールクラス
	/// </summary>
	/// <remarks>
	/// Note       : 定義されたアプリケーションをコントロールし、高速起動をサポートします。<br />
	/// Programmer : 30182 R.Tachiya<br />
	/// Date       : 2012.05.14<br />
	/// Update Note: 2012.07.06 30182 立谷 亮介 R.Tachiya<br />
	///            :  高速起動常駐化対応の追加修正、従業員ログイン確認の実装。<br />
    /// Update Note: 2013/05/23 宮本 利明<br />
    ///            : ログオフ時にtempフォルダのファイルを削除する<br />
    /// </remarks>
	public class ApplicationController
	{
		#region // -- Const Members --

		/// <summary>
		/// メインプログラムID
		/// </summary>
		private const string PG_ID = "PMKAU04020U";

		/// <summary>
		/// 初期化起動引数名称
		/// </summary>
		/// <remarks>外部から指定される起動引数の名称。初期化モード:引数あり、復活起動モード:引数なし。</remarks>
		private const string INITIAL_ARGNAME = "Initial";

		/// <summary>
		/// クライアント初期化引数名称
		/// </summary>
		/// <remarks>PG内部で使用している、クライアント初期化の判別用起動引数名称。</remarks>
		private const string CLIENTINITIAL_ARGNAME = "ClientInit";

		/// <summary>
		/// リモーティングオブジェクト-URI
		/// </summary>
		private const string OBJECT_URI = "ApplicationControlObject";

		/// <summary>
		/// リモーティングオブジェクト-PortName
		/// </summary>
		private const string PORT_NAME = "IPC_RemotePort_" + ApplicationController.PG_ID;

		/// <summary>
		/// リモーティングオブジェクト-URL
		/// </summary>
		private const string OBJECT_URL = "ipc://" + ApplicationController.PORT_NAME + "/" + ApplicationController.OBJECT_URI;

		/// <summary>
		/// コントロール対象プログラムID
		/// </summary>
		/// <remarks>起動をコントロールするプログラムのID。</remarks>
		internal const string TARGET_PGID = "PMKAU04000U";

		/// <summary>
		/// PM.NSインストールディレクトリ
		/// </summary>
		/// <remarks>プログラム起動時に再取得されます。</remarks>
		private static string PROCESS_DIREDTORYNAME = "";//@"R:\SFNETASM\";

		/// <summary>
		/// コントロール対象画面最大起動数
		/// </summary>
		/// <remarks>コントロール対象が、バックグラウンドでいくつ動作するかの設定値。</remarks>
		/// <remarks>プログラム起動時に再取得されます。</remarks>
		private static int MAX_TARGETCOUNT = 0;

		#endregion

		#region // -- Public Methods --

		/// <summary>
		/// メインエントリ
		/// </summary>
		/// <param name="args">起動引数</param>
		/// <remarks>
		/// Note       : アプリケーションコントローラーのメインエントリです。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		public static void Main(string[] args)
		{
			try
			{
				//開始準備処理
				string msg = "";
				int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status != 0) return;

				//初期化起動引数により動作制御
				bool initial = false;
				foreach (string arg in args)
				{
					//引数に初期化引数を含む場合
					if (arg.Contains(ApplicationController.INITIAL_ARGNAME))
					{
						initial = true;
					}
				}

				//初期化モード
				if (initial)
				{
					// -- Add St 2012.07.06 30182 R.Tachiya --
					#region //コントロールディレクトリ存在確認

					if (!Directory.Exists(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp)))
					{
						//無ければ作成
						Directory.CreateDirectory(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp));
					}

					#endregion

					#region //従業員コードファイル生成

					ControlFileStream.EmployeeDeleter(ApplicationController.PG_ID);
					ControlFileStream.EmployeeWriter(ApplicationController.PG_ID, LoginInfoAcquisition.Employee.EmployeeCode);
					
					#endregion
					// -- Add Ed 2012.07.06 30182 R.Tachiya --

					//初回起動-常駐待機処理//

					#region //サーバーチャンネル生成

					// IPC Channel 作成
					IpcServerChannel serverChannel = new IpcServerChannel(ApplicationController.PORT_NAME);

					// リモートオブジェクトを登録
					ChannelServices.RegisterChannel(serverChannel, true);

					// Type を登録
					RemotingConfiguration.RegisterWellKnownServiceType(typeof(ApplicationControlObject), ApplicationController.OBJECT_URI, WellKnownObjectMode.Singleton);

					//// ChannelのURIを表示
					//Console.WriteLine("Listening on {0}", serverChannel.GetChannelUri());

					#endregion

					#region //staticメンバ設定

					//インストールディレクトリを設定
					ApplicationController.PROCESS_DIREDTORYNAME = ConstantManagement_ClientDirectory.NSCurrentDirectory;

					//画面起動枚数を設定
					EmployeeAcs employeeAcs = new EmployeeAcs();
					Employee employee = new Employee();
					employeeAcs.Read(out employee, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
					ApplicationController.MAX_TARGETCOUNT = employee.CustLedgerBootCnt;

					#endregion

					//クライアント初期化プロセスを起動
					ApplicationController.StartClientInitialProcess();

					//終了せずに待つ
					while (true)
					{
						Thread.Sleep(60 * 1000);
					}
				}
				//復活起動モード
				else
				{
					// -- Add St 2012.07.06 30182 R.Tachiya --
					#region //従業員コード制御

					// 従業員が変更されたが、前従業員の起動した画面が閉じられていない場合の処理//
					string employeeCode = "";
					ControlFileStream.EmployeeReader(ApplicationController.PG_ID, out employeeCode);
					if (int.Parse(LoginInfoAcquisition.Employee.EmployeeCode.Trim()) != int.Parse(employeeCode.Trim()))
					{
						DialogResult dResult = TMsgDisp.Show(
							emErrorLevel.ERR_LEVEL_INFO,
							ApplicationController.PG_ID,
							"従業員ログオフメッセージを閉じてログインし直して下さい。",
							0,
							MessageBoxButtons.OK);

						return;
					}

					#endregion
					// -- Add Ed 2012.07.06 30182 R.Tachiya --

                    //2回目以降起動-初期化・ターゲット画面復帰処理//

					#region //クライアントチャンネル生成

					// IPC Channel 作成
					IpcClientChannel clientChannel = new IpcClientChannel();

					// リモートオブジェクトを登録
					ChannelServices.RegisterChannel(clientChannel, true);

					// Type を登録
					RemotingConfiguration.RegisterWellKnownClientType(typeof(ApplicationControlObject), ApplicationController.OBJECT_URL);

					#endregion

					#region //ターゲット画面の復帰処理

					//コントロールオブジェクト作成
					ApplicationControlObject appControlObj = new ApplicationControlObject();

					//クライアント初期化引数により動作制御
					bool clientInitial = false;
					foreach (string arg in args)
					{
						//引数にクライアント初期化引数を含む場合
						if (arg.Contains(ApplicationController.CLIENTINITIAL_ARGNAME))
						{
							clientInitial = true;
						}
					}
					if (clientInitial)
					{
						//初期化のみ
						appControlObj.InitialForm();
					}
					else
					{
						//再表示（復帰）
						appControlObj.ReViewForm();
					}

					#endregion
				}
			}
			catch (Exception e)
			{
				//ログ出力
				ClientLogTextOut clientLogTextOut = new ClientLogTextOut();
				clientLogTextOut.Output(ApplicationController.PG_ID, e.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR, e);
			}
			finally
			{
				//開放
				ApplicationStartControl.EndApplication();
			}
		}

		#endregion

		#region // -- Private Methods --

		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// Note       : 処理が終了した場合に行われる処理です。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
            // --- ADD 2013/05/23 T.Miyamoto ---------->>>>>
            //得意先元帳常駐コントロールファイル削除
            DirectoryInfo directoryInfo = new DirectoryInfo(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp));
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach (FileInfo fiTemp in fileInfo)
            {
                if (fiTemp.Name.Contains(ApplicationController.TARGET_PGID))
                {
                    string delProcessStrId = fiTemp.Name;
                    delProcessStrId = delProcessStrId.Replace(ApplicationController.TARGET_PGID + "_", "");
                    int delProcessId = Convert.ToInt32(delProcessStrId);
                    ControlFileStream.Deleter(ApplicationController.TARGET_PGID, delProcessId);
                }
            }
            //従業員コードファイル削除
            ControlFileStream.EmployeeDeleter(ApplicationController.PG_ID);
            // --- ADD 2013/05/23 T.Miyamoto ----------<<<<<
            
            //開放
			ApplicationStartControl.EndApplication();

			//制御対象プロセス終了
			Process[] processList = Process.GetProcessesByName(ApplicationController.TARGET_PGID);
			foreach (Process process in processList)
			{
				// 画面表示が行われていない（MainWindowHandleが取得できない）	//
				// プロセスが終了されていない（HasExitedがfalse）				//
				// 上記の場合、その制御対象プロセスを終了させる					//
				if (process.MainWindowHandle == IntPtr.Zero && !process.HasExited)
				{
					process.Kill();
				}
			}
						
			//メインプロセス終了
			ApplicationController.KillProcessList(ApplicationController.PG_ID);
		}

		/// <summary>
		/// クライアント初期化プロセス開始処理（非表示起動）
		/// </summary>
		/// <returns>開始プロセス</returns>
		/// <remarks>
		/// Note       : クライアント初期化プロセスを新しく開始します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static Process StartClientInitialProcess()
		{
			//クライアント初期化プロセスを開始
			return ApplicationController.StartProcessProc(ApplicationController.PG_ID, true, 0, 0);
		}

		/// <summary>
		/// プロセス開始処理（初期化待機）
		/// </summary>
		/// <param name="processFileName">開始するプロセスのPGID</param>
		/// <returns>開始プロセス</returns>
		/// <remarks>
		/// Note       : 指定した引数のプロセスを新しく開始します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static Process StartProcessForFormSleep(string processFileName)
		{
			//初期化待機で開始
			return ApplicationController.StartProcessProc(processFileName, true, 1, 2);
		}

		/// <summary>
		/// プロセス開始処理（通常起動）
		/// </summary>
		/// <param name="processFileName">開始するプロセスのPGID</param>
		/// <returns>開始プロセス</returns>
		/// <remarks>
		/// Note       : 指定した引数のプロセスを新しく開始します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static Process StartProcessForFormExecute(string processFileName)
		{
			//通常で開始
			return ApplicationController.StartProcessProc(processFileName, false, 1, 1);
		}

		/// <summary>
		/// アプリケーション最前面化プロセス開始処理
		/// </summary>
		/// <param name="targetProcessId">対象のプロセスID</param>
		/// <returns>開始プロセス</returns>
		/// <remarks>
		/// Note       : アプリケーション最前面化プロセスを新しく開始します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		private static Process StartProcessForApplicationWakeuper(int targetProcessId)
		{
			//プロセス開始情報設定
			ProcessStartInfo processStartInfo = ApplicationController.GetDefaultProcessStartInfo();
			processStartInfo.FileName = ApplicationWakeuper.PG_ID;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;

			processStartInfo.Arguments = ApplicationWakeuper.WAKEUPID_ARGNAME + targetProcessId.ToString();

			//プロセス開始
			return Process.Start(processStartInfo);
		}

		/// <summary>
		/// プロセス開始処理
		/// </summary>
		/// <param name="processFileName">開始するプロセスのPGID</param>
		/// <param name="createNoWindow">CreateNoWindow設定値</param>
		/// <param name="argsSetMode">起動引数設定モード 0:クライアント初期化モード、1:通常モード</param>
		/// <param name="formState">画面の初期起動状態 0:該当なし、1:通常起動、2:初期化待機</param>
		/// <returns>開始プロセス</returns>
		/// <remarks>
		/// Note       : 指定した引数のプロセスを新しく開始します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static Process StartProcessProc(string processFileName, bool createNoWindow, int argsSetMode, int formState)
		{
			//プロセス開始情報設定
			ProcessStartInfo processStartInfo = ApplicationController.GetDefaultProcessStartInfo();
			processStartInfo.FileName = processFileName;
			processStartInfo.CreateNoWindow = createNoWindow;

			#region //引数設定

			string[] args = Environment.GetCommandLineArgs();
			string arguments = "";
			for (int index = 1; index < args.Length; index++)
			{
				//引数設定モードにより引数を設定
				switch (argsSetMode)
				{
					case 0://クライアント初期化モード
						//初期化起動引数をクライアント初期化起動引数に変更する
						if (args[index].Contains(ApplicationController.INITIAL_ARGNAME))
						{
							args[index] = ApplicationController.CLIENTINITIAL_ARGNAME;
						}
						break;
					case 1://通常モード
						//余計な引数を追加しない
						if (args[index].Contains(ApplicationController.INITIAL_ARGNAME))
						{
							continue;
						}
						break;
					default://その他
						//操作なし
						break;
				}

				//引数生成
				arguments += args[index] + " ";
			}
			processStartInfo.Arguments = arguments;

			#endregion

			//プロセス開始
			Process process = Process.Start(processStartInfo);
			process.WaitForInputIdle();

			#region //コントロールファイル生成

			// processFileNameがコントロール対象PGの場合に出力								//
			// formStateが初期化待機(2)の場合に出力											//

			if (processFileName == ApplicationController.TARGET_PGID && formState == 2)
			{
				ControlFileStream.Writer(ApplicationController.TARGET_PGID, process.Id, ControlFileStream.ControlText.ProcessStart);
			}
			else
			{
				//それ以外出力なし
			}

			#endregion

			return process;
		}

		/// <summary>
		/// ProcessStartInfo取得処理
		/// </summary>
		/// <returns>ProcessStartInfo初期値</returns>
		/// <remarks>
		/// Note       : ProcessStartInfoの初期値を新しく取得します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		private static ProcessStartInfo GetDefaultProcessStartInfo()
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "";
			processStartInfo.UseShellExecute = true;
			processStartInfo.WorkingDirectory = ApplicationController.PROCESS_DIREDTORYNAME;
			processStartInfo.CreateNoWindow = false;
			processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
			processStartInfo.UserName = null;
			processStartInfo.Password = null;

			return processStartInfo;
		}

		/// <summary>
		/// プロセス停止処理
		/// </summary>
		/// <param name="processFileName">停止するプロセスのPGID</param>
		/// <remarks>
		/// Note       : 指定した引数のプロセスを全て停止します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static void KillProcessList(string processFileName)
		{
			Process[] processList = Process.GetProcessesByName(processFileName);
			if (processList == null) return;

			foreach (Process process in processList)
			{
				process.Kill();
			}
		}

		#endregion

		#region // -- Internal Class --

		/// <summary>
		/// アプリケーションコントロールオブジェクトクラス
		/// </summary>
		/// <remarks>
		/// Note       : アプリケーションをコントロールする為のメインオブジェクトクラスです。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		internal class ApplicationControlObject : MarshalByRefObject
		{
			#region // -- Private Members --

			/// <summary>
			/// 制御対象プロセスIDリスト
			/// </summary>
			/// <remarks>制御を行っているプロセスIDのリスト。</remarks>
			private List<int> _idList = new List<int>();

			/// <summary>
			/// 表示対象プロセスIDリスト
			/// </summary>
			/// <remarks>表示を行っているプロセスIDのリスト。</remarks>
			private List<int> _viewList = new List<int>();

			/// <summary>
			/// リストロックオブジェクト
			/// </summary>
			/// <remarks>リスト制御時の排他ロックオブジェクト。</remarks>
			private object _listLock = new object();

			#endregion

			#region // -- Public Methods --

			/// <summary>
			/// InitializeLifetimeService処理（オーバーライド）
			/// </summary>
			/// <remarks>
			/// Note       : InitializeLifetimeService処理を実装します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			public override Object InitializeLifetimeService()
			{
				ILease lease = (ILease)base.InitializeLifetimeService();
				if (lease.CurrentState == LeaseState.Initial)
				{
					//リース時間を0に設定すると有効期間が無限				
					lease.InitialLeaseTime = TimeSpan.Zero;						//リースマネージャがオブジェクトの削除処理を開始する前に、そのオブジェクトがメモリ内に存続する期間の初期値
					//lease.CurrentLeaseTime = ;								//リースが期限切れになるまでの期間
					//lease.RenewOnCallTime = TimeSpan.FromMinutes(2);			//オブジェクトに対する各リモート呼び出しの後にCurrentLeaseTimeが設定される最長の期間
					//lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);		//リースの期限が切れたことが通知された後、リースマネージャがスポンサーの応答を待機する時間
					//lease.LeaseManagerPollTime = TimeSpan.FromSeconds(10);	//期限切れになったリースがあるかどうかを確認した後、リースマネージャがスリープする時間
				}
				return lease;
			}

			/// <summary>
			/// コントロールフォーム初期化処理
			/// </summary>
			/// <remarks>
			/// Note       : バックグラウンドのコントロールフォームを初期化します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			public void InitialForm()
			{
				#region //コントロールディレクトリ存在確認 // -- Del 2012.07.06 30182 R.Tachiya --

				//if (!Directory.Exists(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp)))
				//{
				//    //無ければ作成
				//    Directory.CreateDirectory(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp));
				//}

				#endregion

				#region //ゴミプロセス削除処理

				ApplicationController.KillProcessList(ApplicationController.TARGET_PGID);

				#endregion

				#region //ゴミファイル削除処理

                DirectoryInfo directoryInfo = new DirectoryInfo(System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.Temp));
				FileInfo[] fileInfo = directoryInfo.GetFiles();

				foreach (FileInfo fiTemp in fileInfo)
				{
					if (fiTemp.Name.Contains(ApplicationController.TARGET_PGID))
					{
						string delProcessStrId = fiTemp.Name;
						delProcessStrId = delProcessStrId.Replace(ApplicationController.TARGET_PGID + "_", "");
						int delProcessId = Convert.ToInt32(delProcessStrId);
						this.DeleteControlFile(delProcessId);
					}
				}

				#endregion

				//バックグラウンドプロセス起動処理
				for (int count = 0; count < MAX_TARGETCOUNT; count++)
				{
					//プロセス起動
					this.StartBackgroundProcess();

					Thread.Sleep(500);//多少間を置く
				}
			}

			/// <summary>
			/// コントロールフォーム再表示処理
			/// </summary>
			/// <remarks>
			/// Note       : バックグラウンドのコントロールフォームを再表示します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			public void ReViewForm()
			{
				#region //ターゲットのプロセスIDを取得
				int targetId = 0;
				lock (this._listLock)//リストロック制御
				{
					foreach (int id in this._idList)
					{
						if (!this._viewList.Contains(id))
						{
							this._viewList.Add(id);
							targetId = id;
							break;
						}
					}
				}
				if (targetId == 0)
				{
					// 制御対象プロセスIDリスト中に、表示対象プロセスIDが見つからない場合	//
					// これは通常、コントロール対象画面最大起動数を超えている為に発生する	//

					//Console.WriteLine("Form cannot be displayed any more.");

					//ターゲットプロセスを通常に開始
					ApplicationController.StartProcessForFormExecute(ApplicationController.TARGET_PGID);

					return;
				}
				#endregion

				//ターゲットのプロセスを取得
				Process process = Process.GetProcessById(targetId);

				//画面初期化終了までスリープ
				this.SleepUpToInitializeEnd(process.Id);

				// コントロール対象へ復活表示指示	//
				ControlFileStream.Writer(ApplicationController.TARGET_PGID, targetId, ControlFileStream.ControlText.ReViewForm);

				//画面（復活）設定終了までスリープ
				this.SleepUpToSettingEnd(process.Id);

				// 最前面化を行うアプリケーションがWindowsアプリの場合上手く行かない為	//
				// コンソールアプリを起動し最前面化を行う								//

				//ターゲットの画面を最前面に表示する
				ApplicationController.StartProcessForApplicationWakeuper(targetId);
			}

			#endregion

			#region // -- Private Methods --

			/// <summary>
			/// Exitedイベント
			/// </summary>
			/// <param name="sender">終了プロセス情報</param>
			/// <param name="e"></param>
			/// <remarks>
			/// Note       : コントロール対象のプロセスが終了した場合の処理を実装します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			private void ApplicationControlObject_Exited(object sender, EventArgs e)
			{
				//引数からプロセスを取得
				Process process = (Process)sender;

				//削除
				lock (this._listLock)//リストロック制御
				{
					this._viewList.Remove(process.Id);
					this._idList.Remove(process.Id);
					this.DeleteControlFile(process.Id);
				}

                //プロセス起動
				this.StartBackgroundProcess();
			}


			/// <summary>
			/// バックグラウンドプロセス開始処理
			/// </summary>
			/// <remarks>
			/// Note       : バックグランドでコントロール対象のプロセスを開始します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			private void StartBackgroundProcess()
			{
				//ターゲットプロセス開始
				Process process = ApplicationController.StartProcessForFormSleep(ApplicationController.TARGET_PGID);
				process.EnableRaisingEvents = true;
				process.Exited += new EventHandler(this.ApplicationControlObject_Exited);
				lock (this._listLock)//リストロック制御
				{
					this._idList.Add(process.Id);
				}
			}

			/// <summary>
			/// 初期化終了待機処理
			/// </summary>
			/// <param name="targetProcessID">対象プロセスID</param>
			/// <remarks>
			/// Note       : コントロール対象のプロセスが初期化完了するまで待機します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.06.18<br />
			/// </remarks>
			private void SleepUpToInitializeEnd(int targetProcessID)
			{
				this.SleepUpToProc(targetProcessID, ControlFileStream.ControlText.InitializeEnd);
			}

			/// <summary>
			/// 設定終了待機処理
			/// </summary>
			/// <param name="targetProcessID">対象プロセスID</param>
			/// <remarks>
			/// Note       : コントロール対象のプロセスが設定終了するまで待機します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.06.18<br />
			/// </remarks>
			private void SleepUpToSettingEnd(int targetProcessID)
			{
				this.SleepUpToProc(targetProcessID, ControlFileStream.ControlText.SettingEnd);
			}

			/// <summary>
			/// 共通終了待機処理
			/// </summary>
			/// <param name="targetProcessID">対象プロセスID</param>
			/// <param name="controlText">制御文字列</param>
			/// <remarks>
			/// Note       : コントロール対象のプロセスが制御終了するまで待機します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			private void SleepUpToProc(int targetProcessID, ControlFileStream.ControlText controlText)
			{
				// コントロール対象により特定のファイルが更新される仕様	//
				// 一定間隔でファイルアクセスを行い						//
				// ファイルが更新されている場合終了する					//

				int outTime = 60 * 1000;//ms
				int sleepTime = 50;//ms
				int maxLoopCount = outTime / sleepTime;//回

				for (int count = 0; count < maxLoopCount; count++)
				{
					//コントロール対象の初期化が終わったことを確認
					int status = ControlFileStream.Reader(ApplicationController.TARGET_PGID, targetProcessID, controlText);

					if (status == 0)
					{
						//読込文字列が見つかった場合、ループ終了
						break;
					}
					else
					{
						//読込文字列が見つからない場合、スリープさせる
						//ファイルが見つからない場合、スリープさせる
						//別スレッドへのアクセス制限の場合、スリープさせる
						Thread.Sleep(sleepTime);
					}
				}

				return;
			}

			/// <summary>
			/// コントロールファイル削除処理
			/// </summary>
			/// <param name="targetProcessID"></param>
			/// <remarks>
			/// Note       : 制御に使用するTEMPファイルを削除します。<br />
			/// Programmer : 30182 R.Tachiya<br />
			/// Date       : 2012.05.14<br />
			/// </remarks>
			private void DeleteControlFile(int targetProcessID)
			{
				//ファイル削除
				ControlFileStream.Deleter(ApplicationController.TARGET_PGID, targetProcessID);
				return;
			}

            #endregion
		}

		#endregion
	}
}
