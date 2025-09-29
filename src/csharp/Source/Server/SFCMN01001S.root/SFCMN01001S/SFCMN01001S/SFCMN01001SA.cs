using System;
using System.Data;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;// --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応
using System.Collections.Generic;// --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応
using System.Configuration;// --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応

using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
//--- ADD 2015.05.22 30809 佐々木 ----->>>>>
using Microsoft.Win32;
using System.Threading;
//--- ADD 2015.05.22 30809 佐々木 -----<<<<<
// --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
using System.Xml;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
// --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<

namespace Broadleaf.ServiceProcess
{

	/// <summary>
	/// ユーザーAPリモートプロキシサーバークラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはリモートオブジェクトのプロキシクラスです。</br>
	/// <br>Programmer : 20402　杉村 利彦</br>
	/// <br>Date       : 2007.08.08</br>
    /// <br></br>
    /// <br>Update     : 2015.05.22 30809 佐々木 11101069-00 LSM配信改良 </br>
    /// <br>           : ・PMﾀｽｸｽｹｼﾞｭｰﾗｰ起動停止制御を追加</br>
    /// <br>           : ・ログ出力部品をCLCログ出力部品呼出に変更</br>
    /// <br>Update     : 2015/09/25 11170140-00 LSMサーバー配信改良 </br>
    /// <br>           : ・定期起動処理、動作状況監視処理を追加</br>
    /// <br>Update     : 2015/12/21 11170XXX-00 松本 ユーザーAP起動不具合対応 </br>
    /// <br>           : ・ユーザーAP起動時ログ出力、及び再試行するように修正</br>
    /// <br>Update     : 2020/06/05 11670219-00 小原 ＥＢＥ対策 </br>
    /// <br>           : ・ユーザーAP起動時及び定時でバックアップ処理を実行する</br>
    /// </remarks>
	public class Tbs001ServerService : System.ServiceProcess.ServiceBase
	{

        //--- ADD 2015.05.22 30809 佐々木 ----->>>>>
        /// <summary>
        /// PMタスクスケジューラーのサービス起動と停止処理で使用するサービス名
        /// </summary>
        /// <remarks>
        /// サービス名：Partsman.NS Task Scheduler
        /// </remarks>
        const string cServiceName = @"Partsman.NS Task Scheduler";       

        /// <summary>
        /// PMタスクスケジューラーのサービス スタートアップの状態確認用レジストリキー名
        /// </summary>
        /// <remarks>
        /// レジストリキー：HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\Partsman.NS Task Scheduler
        /// <br>「Partsman.NS Task Scheduler」の文字列はcServiceNameを使用する</br>
        /// </remarks>
        const string cKeyName = @"SYSTEM\CurrentControlSet\Services\";

        /// <summary>
        /// PMタスクスケジューラーのサービス スタートアップの状態確認用レジストリ文字列
        /// </summary>
        /// <remarks>
        /// レジストリ文字列：Start
        /// <br>2：自動、3：手動、4：無効</br>
        /// </remarks>
        const string cValueName = "Start";      

        /// <summary>
        /// PMタスクスケジューラーのサービス スタートアップの「無効」状態用判断値
        /// </summary>
        /// <remarks>
        /// <br>4：無効</br>
        /// </remarks>
        const int cSERVICE_DISABLED = 4;           
        //--- ADD 2015.05.22 30809 佐々木 -----<<<<<

        // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
        // LSMサービス名・ID
        const string cLsmServiceName = "LSMWinService";
        const string cLsmServiceID = "LSMWinService.exe";

        // LSMサービス監視設定
        private const string ct_LsmCheckInfoFile = "SFCMN01001S_LsmCheckInfo.XML"; // 設定ファイル
        private const int ct_LsmCheckInterval = 60000;      // LSMサービス監視間隔(デフォルト：1分)
        private string _lsmStartTime;
        private int _lsmCheckInterval;
        private int _lsmCheckIntervalCounter;

        // LSMサービス監視タイマー
        private System.Timers.Timer LsmCheckTimer = null;

        private long _startDay = 0;
        // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<

        // --- ADD 2020/06/15 小原  -------------------->>>>>
        private ConvObjBkExec convObjBkExec;
        // --- ADD 2020/06/15 小原  --------------------<<<<<

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Tbs001ServerService()
		{
			// この呼び出しは、Windows.Forms コンポーネント デザイナで必要です。
			InitializeComponent();

			// TODO: InitComponent 呼び出しの後に初期化処理を追加してください。
            // --- ADD 2020/06/15 小原  -------------------->>>>>
             convObjBkExec = new ConvObjBkExec();
            // --- ADD 2020/06/15 小原  --------------------<<<<<
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
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Tbs001ServerService() };

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
			this.ServiceName = "Tbs001ServerService";

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
            // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
            LsmCheckTimer = new System.Timers.Timer();
            LsmCheckTimer.Enabled = false;
            LsmCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(LsmCheckTimer_Elapsed);
            LsmCheckTimer.Interval = ct_LsmCheckInterval;
            // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<
            try
			{
                //サービススタート
                //int status = ServerServiceStartControl.StartServerService(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP, Tbs001ServerServiceResource.GetRemoteResource()); // --- DEL 2015/12/21 松本 ユーザーAP起動不具合対応
                // --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応 -------------------->>>>>
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                List<RemoteAssemblyInfo> remoteAssemblyInfoList = Tbs001ServerServiceResource.GetRemoteResource();
                for (int retryCount = 0, maxRetryCount = 5; retryCount <= maxRetryCount; retryCount++)
                {
                    try
                    {
                       status = ServerServiceStartControl.StartServerService(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP, remoteAssemblyInfoList);
                        break;//予期しているエラーであるならば、それはそのまま処理を継続させる
                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        #region 2A.1.1.再試行判断
                        if ((retryCount + 1) <= maxRetryCount)
                        {
                            this.WriteErrorLogStop(this.ServiceName, "OnStart", "起動処理を再試行します[" + ex.Message + "]", ex, -1);
                            this.OnStartRetryLogic(retryCount, maxRetryCount);
                        }
                        else
                        {
                            throw;
                        }
                        #endregion
                    }
                }
                // --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応 --------------------<<<<<
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    WriteErrorLog(this.ServiceName, "OnStart", string.Format("StartServerServiceにてERROR発生。サーバー環境を見直してください"), null, status);
                }
                //--- ADD 2015.05.22 30809 佐々木 ----->>>>>
                else
                {
                    // 別スレッドでPMタスクスケジューラサービスを起動する
                    Thread startServicePMTaskSchedulerThread = new Thread(new ThreadStart(StartServicePMTaskScheduler));
                    startServicePMTaskSchedulerThread.Start();
                    
                    // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
                    if (SetLsmCheckTimer() == 0)
                    {
                        LsmCheckTimer.Enabled = true; // LSM監視タイマー起動
                    }
                    // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<

                    // --- ADD 2020/06/15 小原  -------------------->>>>>
                    // バックアップ開始
                    // サービス起動時、定時起動
                    // 別スレッドで実行
                    convObjBkExec.ConvertObjBkStart();
                    // --- ADD 2020/06/15 小原  --------------------<<<<<

                }
                //--- ADD 2015.05.22 30809 佐々木 -----<<<<<
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
            //--- ADD 2015.05.22 30809 佐々木 ----->>>>>
            // CLCログ出力部品呼出追加
            CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
			clcLogTextOut.OutputClcLog(pgId,null,msg,status,ex);
            //--- ADD 2015.05.22 30809 佐々木 -----<<<<<
            this.Stop();    //2006.07.11 add 久保田
        }

        //--- ADD 2015.05.22 30809 佐々木 ----->>>>>
        /// <summary>
        /// エラーLog生成(Stop無し)
        /// </summary>
        /// <param name="pgId"></param>
        /// <param name="method"></param>
        /// <param name="Msg"></param>
        /// <param name="ex"></param>
        /// <param name="status"></param>
        protected void WriteErrorLogStop(string pgId, string method, string Msg, Exception ex, int status)
        {
            string exceptionMsg = "無し";
            if (ex != null) exceptionMsg = ex.Message;
            string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}", method, Msg, exceptionMsg);
            LogTextOut logTextOut = new LogTextOut();
            logTextOut.Output(pgId, msg, status);
            // CLCログ出力部品に変更
            CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
            clcLogTextOut.OutputClcLog(pgId, null, msg, status, ex);
        }
        //--- ADD 2015.05.22 30809 佐々木 -----<<<<<


		/// <summary>
		/// このサービスを停止します。
		/// </summary>
		protected override void OnStop()
		{
            //--- ADD 2015.05.22 30809 佐々木 ----->>>>>
			try
			{
                // 別スレッドでPMタスクスケジューラサービスを停止する
                //Thread stopServicePMTaskSchedulerThread = new Thread(new ThreadStart(StopServicePMTaskScheduler)); //--- DEL 2015.06.05 22035 三橋
                //stopServicePMTaskSchedulerThread.Start(); //--- DEL 2015.06.05 22035 三橋

                this.StopServicePMTaskScheduler(); // 終了処理ではスレッド化しない  //--- ADD 2015.06.05 22035 三橋
            }
            catch (Exception ex)
            {
                WriteErrorLogStop(this.ServiceName, "OnStop", "PMﾀｽｸｽｹｼﾞｭｰﾗｰｻｰﾋﾞｽ停止 例外 " + ex.Message, ex, -1);
            }
            //--- ADD 2015.05.22 30809 佐々木 -----<<<<<
            // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
            if (LsmCheckTimer.Enabled)
            {
                LsmCheckTimer.Enabled = false; // LSM監視タイマー停止
            }
            // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<

            // --- ADD 2020/06/15 小原  -------------------->>>>>
            // バックアップ停止
            convObjBkExec.ConvertObjBkStop();
            // --- ADD 2020/06/15 小原  --------------------<<<<<

		}

        //--- ADD 2015.05.22 30809 佐々木 ----->>>>>
        /// <summary>
        /// PMタスクマネージャーサービス 起動メイン処理
        /// </summary>
        protected void StartServicePMTaskScheduler()
        {
            // サービス一覧取得
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // 指定したサービス名がサービス一覧に存在している場合
                if (sc.ServiceName == cServiceName)
                {
                    // サービスが停止している場合
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        // サービス スタートアップの状態確認
                        if (ChkServiceStartMode(cServiceName) == true)
                        {
                            try
                            {
                                sc.Start();  // サービス起動
                            }
                            catch
                            {
                                // サービス起動中にエラーが発生した可能性がある
                                WriteErrorLog(this.ServiceName, "OnStart", string.Format("Partsman.NS Task Schedulerサービス起動にてERROR発生"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// PMタスクマネージャーサービス 停止メイン処理
        /// </summary>
        protected void StopServicePMTaskScheduler()
        {
            // サービス一覧取得
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // 指定したサービス名がサービス一覧に存在している場合
                if (sc.ServiceName == cServiceName)
                {
                    // サービスが起動している場合
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        // サービス スタートアップの状態確認
                        if (ChkServiceStartMode(cServiceName) == true)
                        {
                            try
                            {
                                sc.Stop();  // サービス停止
                                // --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応 --------- >>>>>
                                if (sc.Status != ServiceControllerStatus.Stopped)
                                {
                                    sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 1, 30));
                                }
                                // --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応 --------- <<<<<
                            }
                            catch
                            {
                                // サービス停止中にエラーが発生した可能性がある
                                WriteErrorLogStop(this.ServiceName, "OnStop", string.Format("Partsman.NS Task Schedulerサービス停止にてERROR発生"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// サービス スタートアップ種類の確認
        /// </summary>
        /// <param name="sServiceName"></param>
        /// <returns>結果ステータス（true:起動・停止可能、false:起動・停止不可）</returns>
        protected Boolean ChkServiceStartMode(string sServiceName)
        {
            // サービスのスタートアップ種類が [無効] の場合のみサービス起動および停止を行わない

            Boolean status = true;  // 起動・停止可能

            // レジストリ・キーのパスを指定してレジストリを開く
            RegistryKey rKey = null;

            try
            {
                rKey = Registry.LocalMachine.OpenSubKey(cKeyName + sServiceName);

                if (rKey != null)
                {
                    // レジストリの値を取得
                    int iValue = (int)rKey.GetValue(cValueName, 0);

                    if (iValue == cSERVICE_DISABLED)         // 無効
                    {
                        status = false;  // 起動・停止不可
                    }
                }
            }
            catch (NullReferenceException)
            {
                // キーが存在しない場合、エラーとしない
            }
            catch
            {
                // 例外エラー
            }
            finally
            {
                if (rKey != null)
                {
                    // 開いたキーを閉じる
                    rKey.Close();
                }
            }

            return status;
        }

        //--- ADD 2015.05.22 30809 佐々木 -----<<<<<

        // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
        /// <summary>
        /// LSMサービス監視タイマー設定
        /// </summary>
        private int SetLsmCheckTimer()
        {
            // LSMサービス監視タイマー設定ファイル読込
            LsmServiceCheckInfo lsmServiceCheckInfo = new LsmServiceCheckInfo();
            int status = ReadLsmCheckFile(ref lsmServiceCheckInfo);
            
            if (status == 0)
            {
                // 監視間隔チェック
                if (lsmServiceCheckInfo.LsmCheckInterval == 0)
                {
                    return -1;
                }

                // XML内容を設定
                this._lsmCheckInterval = lsmServiceCheckInfo.LsmCheckInterval;  // XMLの監視間隔を退避
                this._lsmCheckIntervalCounter = this._lsmCheckInterval - 1;     // XMLの監視間隔

                try
                {
                    // 定期起動時刻
                    string lsmStartTime = lsmServiceCheckInfo.LsmStartTime_HH.ToString("00") + lsmServiceCheckInfo.LsmStartTime_mm.ToString("00");
                    DateTime dt = DateTime.ParseExact(lsmStartTime, "HHmm", null);

                    // XML内容を設定
                    this._lsmStartTime = lsmStartTime;


                    long now = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                    long day = long.Parse(DateTime.Now.ToString("yyyyMMdd"));       // 起動日付

                    if (long.Parse(day.ToString() + this._lsmStartTime) <= now)
                    {
                        this._startDay = day;
                    }
                }
                catch
                {
                    status = -1;
                }
            }

            return status;
        }

        /// <summary>
        /// LSMサービス監視タイマー設定ファイル読込
        /// </summary>
        protected int ReadLsmCheckFile(ref LsmServiceCheckInfo lsmServiceCheckInfo)
        {
            int status = 0;

            FileStream fs = null;
            try
            {
                // 設定ファイル読み込み(ユーザーAPサービスと同一フォルダに存在)
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(fileDir, ct_LsmCheckInfoFile);

                lsmServiceCheckInfo = UserSettingController.DeserializeUserSetting<LsmServiceCheckInfo>(filePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                // ファイルが存在しない場合はエラーとする
                status = -1;
            }
            catch (Exception ex)
            {
                status = -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// LSM監視タイマー処理
        /// </summary>
        void LsmCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            long now = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
            long day = long.Parse(DateTime.Now.ToString("yyyyMMdd"));       // 起動日付

            bool startFlg = false;
            //----------------------------------------
            // LSMサービス定期起動
            //----------------------------------------
            if (this._startDay != day)
            {   // 前回起動日付と現在日付が異なる場合

                if (long.Parse(day.ToString() + this._lsmStartTime) <= now)
                {   // 設定時刻より現在時刻の方が大きい場合
                    startFlg = true;

                    // LSMサービス停止
                    StopService(cLsmServiceName);

                    // カウンターリセット
                    this._lsmCheckIntervalCounter = 0;

                    // 起動日付再設定
                    this._startDay = day;
                }
            }

            //----------------------------------------
            // LSMサービス監視（停止中の場合に起動）
            //----------------------------------------
            if (this._lsmCheckIntervalCounter <= 0)
            {
                // LSMサービス開始
                StartService(cLsmServiceName, startFlg);

                // カウンター再設定
                this._lsmCheckIntervalCounter = this._lsmCheckInterval; // XMLの監視間隔
            }
            // カウンター更新
            this._lsmCheckIntervalCounter -= 1;
        }

        /// <summary>
        /// サービス 起動処理
        /// </summary>
        protected void StartService(string targetServiceName, bool startFlg)
        {
            string sMsg = "Partsman.NS LSMサービスが停止していた為、起動しました。";
            if (startFlg)
            {
                sMsg = "定期起動処理にてPartsman.NS LSMサービスが起動しました。";
            }

            // サービス一覧取得
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // 指定したサービス名がサービス一覧に存在している場合
                if (sc.ServiceName == (string)targetServiceName)
                {
                    // サービスが停止している場合
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        // サービス スタートアップの状態確認
                        if (ChkServiceStartMode((string)targetServiceName) == true)
                        {
                            try
                            {
                                sc.Start();  // サービス起動
                                WriteErrorLogStop(this.ServiceName, "StartService", sMsg, null, -1);
                            }
                            catch
                            {
                                // サービス起動中にエラーが発生した可能性がある
                                WriteErrorLog(this.ServiceName, "StartService", string.Format("Partsman.NS LSMサービス起動にてERROR発生"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// サービス 停止処理
        /// </summary>
        protected void StopService(object targetServiceName)
        {
            // サービス一覧取得
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // 指定したサービス名がサービス一覧に存在している場合
                if (sc.ServiceName == (string)targetServiceName)
                {
                    // サービスが起動している場合
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        // サービス スタートアップの状態確認
                        if (ChkServiceStartMode((string)targetServiceName) == true)
                        {
                            try
                            {
                                sc.Stop();  // サービス停止
                                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                                WriteErrorLogStop(this.ServiceName, "StopService", string.Format("定期起動処理にてPartsman.NS LSMサービスが停止しました。"), null, -1);
                            }
                            catch
                            {
                                // サービス停止中にエラーが発生した可能性がある
                                WriteErrorLogStop(this.ServiceName, "StopService", string.Format("Partsman.NS LSMサービス停止にてERROR発生"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }
        // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<

        // --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応 -------------------->>>>>
        /// <summary>
        /// リモートサービスの再試行時の事前処理実行を行います。
        /// アプリケーション構成ファイルに設定された下記情報を利用し事前処理を行います。
        /// 原則指定秒数待機するだけとなりますが、下記設定情報により動作が変わります。
        /// 　・ServiceOnStartRetryLogicType = kill
        /// 　　→同一プロセス名の他のプロセスを強制終了します。
        /// 
        /// 　・ServiceOnStartRetryIntervalSeconds
        /// 　　→待機秒数を設定値に変更します。(1～59のみ有効)
        /// </summary>
        /// <param name="retryCount">再試行回数</param>
        /// <param name="retryMaxCount">再試行最大回数</param>
        protected void OnStartRetryLogic(int retryCount,int retryMaxCount)
        {
            //2B.1.1.再試行処理判断
            string retryLogicType = ConfigurationManager.AppSettings["ServiceOnStartRetryLogicType"];
            if (!string.IsNullOrEmpty(retryLogicType) && "kill".Equals(retryLogicType) || (retryCount + 1) == retryMaxCount)
            {
                #region 2D.他プロセス強制終了
                Process currentProcess = Process.GetCurrentProcess();
                Process[] processArray = Process.GetProcessesByName(currentProcess.ProcessName);
                foreach (Process p in processArray)
                {
                    if (p.Id == currentProcess.Id)
                    {
                        continue;
                    }
                    try
                    {
                        this.WriteErrorLogStop(this.ServiceName, "OnStartRetryLogic", "他プロセスを発見しました。強制終了します:"+p.Id+","+p.ProcessName, null, 0);
                        p.Kill();
                    }
                    catch (Exception ex)
                    {
                        this.WriteErrorLogStop(this.ServiceName, "OnStartRetryLogic", "強制終了中にエラーが発生しました。[" + ex.Message + "]", ex, -1);
                    }
                }
                #endregion
            }

            #region 2C.1.1.指定秒数待機
            string retryIntervalSecondsSettings = ConfigurationManager.AppSettings["ServiceOnStartRetryIntervalSeconds"];
            int retryIntervalSeconds = 10;
            if (!string.IsNullOrEmpty(retryIntervalSecondsSettings) && Int32.TryParse(retryIntervalSecondsSettings, out retryIntervalSeconds))
            {
                if (retryIntervalSeconds <= 0 || retryIntervalSeconds >= 60)
                {
                    retryIntervalSeconds = 10;
                }
            }
            else
            {
                retryIntervalSeconds = 10;
            }
            Thread.Sleep(retryIntervalSeconds * 1000);
            #endregion
        }
        // --- ADD 2015/12/21 松本 ユーザーAP起動不具合対応 --------------------<<<<<

	}

    // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 -------------------->>>>>
    /// <summary>
    /// LSMサービス監視設定ファイル情報
    /// </summary>
    public class LsmServiceCheckInfo
    {
        /// <summary>監視間隔</summary>
        private int _lsmCheckInterval;
        /// <summary>定期起動時刻(時)</summary>
        private int _lsmStartTime_HH;
        /// <summary>定期起動時刻(分)</summary>
        private int _lsmStartTime_mm;

        /// <summary>
        /// 監視間隔
        /// </summary>
        public int LsmCheckInterval
        {
            get
            {
                return _lsmCheckInterval;
            }
            set
            {
                _lsmCheckInterval = value;
            }
        }

        /// <summary>
        /// 定期起動時刻
        /// </summary>
        public int LsmStartTime_HH
        {
            get
            {
                return _lsmStartTime_HH;
            }
            set
            {
                _lsmStartTime_HH = value;
            }
        }
        /// <summary>
        /// 定期起動時刻
        /// </summary>
        public int LsmStartTime_mm
        {
            get
            {
                return _lsmStartTime_mm;
            }
            set
            {
                _lsmStartTime_mm = value;
            }
        }

    }
    // --- ADD 2015/09/25 T.Miyamoto LSMサーバー配信改良 --------------------<<<<<
}
