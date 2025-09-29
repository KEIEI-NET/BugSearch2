#define DISP_ERRDIALOG		// エラーダイアログ表示を行う

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;      // 2009.05.12 Add

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 変更案内通知画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 変更案内通知を行う画面です。</br>
	/// <br>Programmer : 21027  須川  程志郎</br>
	/// <br>Date       : 2007.03.15</br>
	/// <br>Update Note: 2007.09.19  21027 須川  程志郎</br>
	/// <br>           :   1.「今回通知分に関して今後表示しない」チェックボックスをデフォルトOFFにするように仕様変更</br>
	/// <br>           : 2008.01.07  90027 Kouguchi</br>
	/// <br>           :   1.新レイアウト対応</br>
    /// <br></br>
    /// <br>           : 2008.11.20  21024　佐々木 健</br>
    /// <br>           :   PM.NS用に変更</br>
    /// <br></br>
    /// <br>           : 2009.05.12  21024　佐々木 健</br>
    /// <br>           :   レジストリでON・OFFを切り替えれるように修正</br>
    /// </remarks>
	public partial class PMCMN00783UA : Form
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PMCMN00783UA()
		{
			InitializeComponent();

			// 背景設定処理(難読化対応の為別処理)
			System.Reflection.Assembly myAssem = System.Reflection.Assembly.GetExecutingAssembly();
			this.pnl_Top.BackgroundImage =
				new Bitmap(myAssem.GetManifestResourceStream("Broadleaf.Windows.Forms.Images.NotifyPopupBackground_top.png"));
			this.pnl_Body.BackgroundImage =
				new Bitmap(myAssem.GetManifestResourceStream("Broadleaf.Windows.Forms.Images.NotifyPopupBackground_body.png"));
			this.pnl_Bottom.BackgroundImage =
				new Bitmap(myAssem.GetManifestResourceStream("Broadleaf.Windows.Forms.Images.NotifyPopupBackground_bottom.png"));

			IsWindowless = false;
        }


        #region Static Fields
		/// <summary>処理成功フラグ</summary>
		internal static bool IsSuccess;
		/// <summary>ウィンドウ起動有無</summary>
		internal static bool IsWindowless;
		/// <summary>プロセス終了用同期イベント</summary>
		internal static ManualResetEvent ExitSyncEvent = new ManualResetEvent(false);

		/// <summary>PMCプロセス</summary>
		private static Process PmcProcess;
		/// <summary>企業認証情報</summary>
		private static CompanyAuthInfoWork CompanyAuthInfo;
		/// <summary>アプリケーション構成保持クラス</summary>
		private static ChangeInfoCheckAppConfig AppConfig;
		/// <summary>前回データ保持クラス</summary>
		private static LatestChangeInfoData[] LatestDataArray;

        //Del  ↓↓↓  2008.01.07 Kouguchi
        ///// <summary>更新PG配信情報</summary>
        //private static PgMulcasGdWork PgMulcasInf;
        ///// <summary>更新PG配信情報</summary>
        //private static SvrMntInfoWork SvrMntInfNml;
        ///// <summary>更新PG配信情報</summary>
        //private static SvrMntInfoWork SvrMntInfEmg;
        //Del  ↑↑↑  2008.01.07 Kouguchi

        //Add  ↓↓↓  2008.01.07 Kouguchi
        /// <summary>変更案内情報(更新 PG配信情報)</summary>
        private static ChangGidncWork ChangGidncInf1;
        /// <summary>変更案内情報(更新 定期メンテ情報)</summary>
        private static ChangGidncWork ChangGidncInf2;
        /// <summary>変更案内情報(更新 データメンテ情報)</summary>
        private static ChangGidncWork ChangGidncInf3;
        /// <summary>変更案内情報(更新 緊急メンテ情報)</summary>
        private static ChangGidncWork ChangGidncInf4;
        /// <summary>変更案内情報(更新印字位置リリース情報)</summary>
        private static ChangGidncWork ChangGidncInf5;
        //Add  ↑↑↑  2008.01.07 Kouguchi


		/// <summary>アプリケーション構成クラス用シリアライズキー</summary>
		private static readonly string[] AppConfigKey = new string[] { typeof(PMCMN00783UA).Name, "AppConfigKey" };
		/// <summary>アプリケーション設定ファイル名</summary>
		private static readonly string AppConfigFileName = "PMCMN00783U_Config.dat";
		/// <summary>前回データクラス用シリアライズキー</summary>
		private static readonly string[] LatestDataKey = new string[] { typeof(PMCMN00783UA).Name, "LatestDataKey" };
		/// <summary>前回データファイル名</summary>
        private static readonly string LatestDataFileName = Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData, "PMCMN00783U_Data.dat");

		/// <summary>案内チェック間隔(sec)</summary>
		private static int CheckTimeSpan = 3600;
		/// <summary>更新チェックWebサービスURL</summary>
		private static string WebServiceURL = String.Empty;
		/// <summary>変更案内通知トップページURL</summary>
		private static string WebTopPageURL = String.Empty;


        private static string WebTopPageURL2 = "";  //Add 2007.01.07 Kouguchi
        private static int SW_ChangGidncInf2 = 0;  //Add 2008.03.27 Kouguchi
        private static int SW_ChangGidncInf3 = 0;  //Add 2008.03.27 Kouguchi
        #endregion


        #region Fields
		/// <summary>スクリーン横幅</summary>
		private int screenWidth;
		/// <summary>スクリーン高さ</summary>
		private int screenHeight;
		/// <summary>終了許可フラグ</summary>
		private bool canCloseFlg = false;
        #endregion


        #region Constants
		/// <summary>PMCプロセス名称</summary>
		private const string ctKEY_PMCProcessName = "ProductManageClient";
		/// <summary>PGID</summary>
		internal const string ctPGID = "PMCMN00783U";
        #endregion


        #region Properties
		/// <summary>
		/// ウィンドウが表示されたときにそのウィンドウをアクティブにするかどうかを示す値を取得します。
		/// </summary>
		/// <value>
		/// ウィンドウが表示されたときにそのウィンドウをアクティブにしない場合は True。それ以外の場合は false。既定値は false です。
		/// </value>
		protected override bool ShowWithoutActivation
		{
			get { return true; }
        }
        #endregion


        #region Static Methods

        #region アプリケーション初期設定処理
        /// <summary>
		/// アプリケーション初期設定処理
		/// </summary>
		public static void InitializeApplication()
		{
			IsSuccess = true;
			IsWindowless = true;
			if (IsSuccess) SetProcessWatcher(ctKEY_PMCProcessName);  //製品管理クライアントプロセス監視処理
            if (IsSuccess) GetApplicationConfig();                   //アプリケーション構成情報取得処理
            if (IsSuccess) SetCompanyAuthInfo();                     //認証情報取得処理
            if (IsSuccess) CheckChangeInfoWaitRoop(false);           //変更案内更新チェック待機ループ処理

#if DISP_ERRDIALOG
			if (!IsSuccess)
			{
				MessageBox.Show(
					"PM.NS 変更案内通知クライアントの起動に失敗しました。",
                    "PM.NS 変更案内通知",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
#endif
		}
        #endregion

        #region 製品管理クライアントプロセス監視処理
        /// <summary>
		/// 製品管理クライアントプロセス監視処理
		/// </summary>
		/// <param name="processName">プロセス名称</param>
		private static void SetProcessWatcher(string processName)
		{
			try
			{
				// 名称よりプロセス取得
				Process[] getByNameAry = Process.GetProcessesByName(processName);

				if ((getByNameAry != null) && (getByNameAry.Length > 0))
				{
					// PMCは1つしか立ち上がっていないはず(暫定)
					PmcProcess = getByNameAry[0];
				}
				PmcProcess.EnableRaisingEvents = true;
				PmcProcess.Exited += new EventHandler(pmcProcess_Exited);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"製品管理クライアントプロセスの取得に失敗しました。",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				IsSuccess = false;
			}
        }
        #endregion

        #region 製品管理クライアント終了イベントハンドラ
        /// <summary>
		/// 製品管理クライアント終了イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private static void pmcProcess_Exited(object sender, EventArgs e)
		{
			// Webサービス交信中は終了処理待機
			ExitSyncEvent.WaitOne();

			// 監視プロセス終了
			EndProcess();
        }
        #endregion

        #region 監視プロセス終了処理
        /// <summary>
		/// 監視プロセス終了処理
		/// </summary>
		private static void EndProcess()
		{
			// ApplicationRun実行前
			if (IsWindowless)
			{
                //Processの終了
				Environment.Exit(0);
			}
			// ApplicationRun実行後
			else
			{
                //Applicationの終了
				System.Windows.Forms.Application.Exit();
                //Processの終了
				Environment.Exit(0);
			}
        }
        #endregion

        #region アプリケーション構成情報取得処理
        /// <summary>
		/// アプリケーション構成情報取得処理
		/// </summary>
		private static void GetApplicationConfig()
		{
			try
			{
				// アプリケーション構成情報取得
				if (UserSettingController.ExistUserSetting(AppConfigFileName))
				{
					AppConfig = UserSettingController.DecryptionDeserializeUserSetting<ChangeInfoCheckAppConfig>(AppConfigFileName, AppConfigKey);
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"アプリケーション構成情報の取得に失敗しました。",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}

			if (AppConfig == null)
			{
				IsSuccess = false;

				MessageBox.Show(
					"アプリケーション構成情報の取得に失敗しました。",
                    "PM.NS 変更案内通知",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
			else
			{
				WebServiceURL = AppConfig.WebServiceURL;	// 更新チェックWebサービスURL
                // 2008.11.20 Add >>>
                if (WebServiceURL.Contains("%Infomation%"))
                {
                    WebServiceURL = WebServiceURL.Replace("%Infomation%", GetWebTopPageURLFromPMC());
                }
                // 2008.11.20 Add <<<

				CheckTimeSpan = AppConfig.CheckTimeSpan;	// 更新チェック間隔(sec)
				WebTopPageURL = AppConfig.WebTopPageURL;	// 変更案内トップページ
                // 2008.11.20 Add >>>
                if (WebTopPageURL.Contains("%Infomation%"))
                {
                    WebTopPageURL = WebTopPageURL.Replace("%Infomation%", GetWebTopPageURLFromPMC());
                }
                // 2008.11.20 Add <<<
            }
        }
        #endregion

        #region 前回通知データ読込み処理
        /// <summary>
		/// 前回通知データ読込み処理
		/// </summary>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>true:読込み成功</description></item>
		/// <item><description>false:読込み失敗/前回データ無し</description></item>
		/// </list>
		/// </returns>
		private static bool ReadLatestChangeInfoData()
		{
			bool retBool = false;

			try
			{
				// アプリケーション構成情報取得
				if (UserSettingController.ExistUserSetting(LatestDataFileName))
				{
					LatestDataArray = UserSettingController.DecryptionDeserializeUserSetting<LatestChangeInfoData[]>(LatestDataFileName, LatestDataKey);
				}
			}
			catch (Exception) 
            { 
            }

			if ((LatestDataArray != null) && (LatestDataArray.Length > 0))
			{
				retBool = true;
			}

			return retBool;
        }
        #endregion

        #region 前回通知データ書込み処理
        /// <summary>
		/// 前回通知データ書込み処理
		/// </summary>
		/// <param name="updateLatestData">保存データ更新有無フラグ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>true:書込み成功</description></item>
		/// <item><description>false:書込み失敗/書込み対象データ無し</description></item>
		/// </list>
		/// </returns>
		private static bool WriteLatestChangeInfoData(bool updateLatestData)
		{
			if (updateLatestData)
			{
				if ((LatestDataArray == null) || (LatestDataArray.Length == 0))
				{
					LatestDataArray = new LatestChangeInfoData[1];
					LatestDataArray[0] = new LatestChangeInfoData();
					LatestDataArray[0].ProductCode = CompanyAuthInfo.ProductInfoWork.ProductCode;
				}

                //Del ↓↓↓ 2008.01.07 Kouguchi
                ////更新PG配信情報がある場合
                //if (PgMulcasInf != null)   LatestDataArray[0].MulticastVersion = PgMulcasInf.MulticastVersion;
                ////更新定期メンテ情報がある場合
                //if (SvrMntInfEmg != null)  LatestDataArray[0].EmgServerMainteConsNo = SvrMntInfEmg.ServerMainteConsNo;
                ////更新PG配信情報がある場合
                //if (SvrMntInfNml != null)  LatestDataArray[0].NmlServerMainteConsNo = SvrMntInfNml.ServerMainteConsNo;
                //Del ↑↑↑ 2008.01.07 Kouguchi

                //Add ↓↓↓ 2008.01.07 Kouguchi
                //変更案内情報(更新 PG配信情報)がある場合
                if (ChangGidncInf1 != null)  LatestDataArray[0].MulticastVersion      = ChangGidncInf1.McastGidncVersionCd;
                //変更案内情報(更新 定期メンテ情報)がある場合
                if (ChangGidncInf2 != null)  LatestDataArray[0].NmlServerMainteConsNo = ChangGidncInf2.MulticastConsNo;
                //変更案内情報(更新 データメンテ情報)がある場合
                if (ChangGidncInf3 != null)  LatestDataArray[0].DatServerMainteConsNo = ChangGidncInf3.MulticastConsNo;
                //変更案内情報(更新 緊急メンテ情報)がある場合
                if (ChangGidncInf4 != null)  LatestDataArray[0].EmgServerMainteConsNo = ChangGidncInf4.MulticastConsNo;
                //変更案内情報(更新 印字位置リリース情報)がある場合
                if (ChangGidncInf5 != null)  LatestDataArray[0].PrintPositionConsNo   = ChangGidncInf5.MulticastConsNo;
                //Add ↑↑↑ 2008.01.07 Kouguchi

			}
			else
			{
				if ((LatestDataArray == null) || (LatestDataArray.Length == 0)) return false;
			}

			try
			{
				UserSettingController.EncryptionSerializeUserSetting(LatestDataArray, LatestDataFileName, LatestDataKey);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"前回通知データの保存に失敗しました。",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return false;
			}

			return true;
        }
        #endregion

        #region 認証情報取得処理
        /// <summary>
		/// 認証情報取得処理
		/// </summary>
		private static void SetCompanyAuthInfo()
		{
			try
			{
				// 企業認証情報を取得
				CompanyAuthInfo = LoginInfoAcquisition.ToObject(typeof(CompanyAuthInfoWork)) as CompanyAuthInfoWork;

				if (CompanyAuthInfo == null)
				{
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_NODISP,
						ctPGID,
						"認証情報の取得に失敗しました。",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					IsSuccess = false;
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"認証情報の取得にてエラーが発生しました。",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				IsSuccess = false;
			}
        }
        #endregion

        #region 変更案内更新チェック待機ループ処理
        /// <summary>
		/// 変更案内更新チェック待機ループ処理
		/// </summary>
		/// <param name="firstWait">初回待機有無フラグ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:更新情報有りで待機ループ脱出</description></item>
		/// <item><description>-99:エラー発生にて待機ループ脱出</description></item>
		/// </list>
		/// </returns>
		private static int CheckChangeInfoWaitRoop(bool firstWait)
		{
			int status = 0;

			try
			{
				// 指定時間待機
				if (firstWait)
				{
					Thread.Sleep(CheckTimeSpan * 1000);
				}

				while (true)
				{
                    // 2009.05.12 Add >>>
                    if (!CheckContinueProcess())
                    {
                        // 指定時間待機
                        Thread.Sleep(CheckTimeSpan * 1000);
                        continue;
                    }
                    // 2009.05.12 Add <<<

					// 変更案内の有無を確認
					status = CheckChangeInfo();

					if (status == 0)			// 更新情報有り
					{
						break;
					}
					else if (status == 4)		// 更新情報無し
					{
					}
					else						// エラー
					{
						IsSuccess = false;
						status = -99;
						break;
					}

					// 指定時間待機
					Thread.Sleep(CheckTimeSpan * 1000);
				}
			}
			catch (Exception)
			{
				IsSuccess = false;
				status = -99;
			}

			return status;
        }
        #endregion

        #region 変更案内有無チェック処理
        /// <summary>
		/// 変更案内有無チェック処理
		/// </summary>
		/// <returns>
		/// チェックステータス
		/// <list type="bullet">
		/// <item><description>0:更新データ有り</description></item>
		/// <item><description>4:更新データ無し</description></item>
		/// <item><description>9:チェックエラー</description></item>
		/// <item><description>-99:異常終了</description></item>
		/// </list>
		/// </returns>
		private static int CheckChangeInfo()
		{
			SFCMN00782AServices webService = new SFCMN00782AServices(WebServiceURL);
            
            webService.Timeout = 60000;		// TimeOut:1分

			//PgMulcasGdParaWork checkParam = new PgMulcasGdParaWork();  //Del 2008.01.07 Kouguchi
            ChangGidncParaWork changGidncParaWork = new ChangGidncParaWork();  //Add 2008.01.07 Kouguchi

            //Del ↓↓↓ 2008.01.07 Kouguchi
            //checkParam.ProductCode = CompanyAuthInfo.ProductInfoWork.ProductCode;
            //checkParam.McastOfferDivCd = 0;
            //checkParam.UpdateGroupCode = new string[0];
            //checkParam.EnterpriseCode = String.Empty;
            //checkParam.MulticastSystemDivCd = -1;
            //checkParam.StdDate = Int64.Parse(String.Format("{0:yyyyMMddHHmm}", DateTime.Now));
            //checkParam.OpenDtTmDiv = IsBroadleaf(CompanyAuthInfo.EnterpriseInfoWork.EnterpriseCode) ? 1 : 2;
            //Del ↑↑↑ 2008.01.07 Kouguchi

            //Add ↓↓↓ 2008.01.07 Kouguchi
            changGidncParaWork.ProductCode = CompanyAuthInfo.ProductInfoWork.ProductCode;                 //パッケージ区分
			changGidncParaWork.McastOfferDivCd = 0;                                                       //配信提供区分
			changGidncParaWork.UpdateGroupCode = new string[0];                                           //更新グループコード
			changGidncParaWork.EnterpriseCode = String.Empty;                                             //企業コード
			changGidncParaWork.MulticastSystemDivCd = -1;                                                 //配信システム区分
			changGidncParaWork.StdDate = Int64.Parse(String.Format("{0:yyyyMMddHHmm}", DateTime.Now));    //基準日
			changGidncParaWork.OpenDtTmDiv = IsBroadleaf(CompanyAuthInfo.EnterpriseInfoWork.EnterpriseCode) ? 1 : 2;   //公開日時区分

			changGidncParaWork.McastGidncCntntsCd = 0;                                                    //案内区分
            //Add ↑↑↑ 2008.01.07 Kouguchi


			int status = 0;

			ExitSyncEvent.Reset();		// Webサービス中はプロセスの終了を行わない
			try
			{
//TEST用
//System.Windows.Forms.MessageBox.Show("TEST");
//TEST用

                //status = webService.SearchNewInfo(checkParam, out PgMulcasInf, out SvrMntInfNml, out SvrMntInfEmg);  //Del 2008.01.07 Kouguchi
				status = webService.SearchNewInfo(changGidncParaWork, out ChangGidncInf1, out ChangGidncInf2, out ChangGidncInf3, out ChangGidncInf4, out ChangGidncInf5);  //Add 2008.01.07 Kouguchi  ←確認

//TEST用
//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//{
//    if (ChangGidncInf1 != null) System.Windows.Forms.MessageBox.Show("CG1=" + ChangGidncInf1.McastGidncCntntsCd.ToString() + " " + ChangGidncInf1.MulticastConsNo.ToString());
//    if (ChangGidncInf2 != null) System.Windows.Forms.MessageBox.Show("CG2=" + ChangGidncInf2.McastGidncCntntsCd.ToString() + " " + ChangGidncInf2.MulticastConsNo.ToString());
//    if (ChangGidncInf3 != null) System.Windows.Forms.MessageBox.Show("CG3=" + ChangGidncInf3.McastGidncCntntsCd.ToString() + " " + ChangGidncInf3.MulticastConsNo.ToString());
//    if (ChangGidncInf4 != null) System.Windows.Forms.MessageBox.Show("CG4=" + ChangGidncInf4.McastGidncCntntsCd.ToString() + " " + ChangGidncInf4.MulticastConsNo.ToString());
//    if (ChangGidncInf5 != null) System.Windows.Forms.MessageBox.Show("CG5=" + ChangGidncInf5.McastGidncCntntsCd.ToString() + " " + ChangGidncInf5.MulticastConsNo.ToString());
//}
//TEST用

                //Add ↓↓↓ 2008.01.07 Kouguchi
                string ChgWork = "0000";  //変更有無フラグ(0:変更なし,1:変更あり   ※左から 1番目:ﾌﾟﾛｸﾞﾗﾑ配信,2番目:定期ﾒﾝﾃorﾃﾞｰﾀﾒﾝﾃ,3番目:緊急ﾒﾝﾃ,4番目:印字位置ﾘﾘｰｽ)

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (ChangGidncInf1 != null) ChgWork = "1" + ChgWork.Substring(1, 3);
                    if (ChangGidncInf2 != null) ChgWork = ChgWork.Substring(0, 1) + "1" + ChgWork.Substring(2, 2);
                    if (ChangGidncInf3 != null) ChgWork = ChgWork.Substring(0, 1) + "1" + ChgWork.Substring(2, 2);
                    if (ChangGidncInf4 != null) ChgWork = ChgWork.Substring(0, 2) + "1" + ChgWork.Substring(3, 1);
                    if (ChangGidncInf5 != null) ChgWork = ChgWork.Substring(0, 3) + "1";
                }


                WebTopPageURL2 = "&CHG=" + ChgWork;
                //WebTopPageURL2 = "?CHG=" + ChgWork;
                //Add ↑↑↑ 2008.01.07 Kouguchi


				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// 最終通知情報取得
						if (ReadLatestChangeInfoData())
						{
                            for (int i = 0; i < LatestDataArray.Length; i++)
							{
								if (LatestDataArray[i].ProductCode == CompanyAuthInfo.ProductInfoWork.ProductCode)
								{
									// 最終通知情報と比較する
									status = CompareToLatestData(i);
									break;
								}
							}

                            //Add ↓↓↓ 2008.03.27 Kouguchi
                            if ((SW_ChangGidncInf2 == 1) && (SW_ChangGidncInf3 == 1))
                            {
                                WebTopPageURL2 = WebTopPageURL2.Substring(0,6) + "0" + WebTopPageURL2.Substring(7,2);
                            }
                            //Add ↑↑↑ 2008.02.27 Kouguchi

						}
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						status = 4;
						break;
					default:
						TMsgDisp.Show(
							emErrorLevel.ERR_LEVEL_NODISP,
							ctPGID,
							"変更案内更新情報の取得[Webサービス]に失敗しました。",
							status,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
						status = 9;
						break;
				}
			}
			catch (System.Net.WebException ex)
			{
				if ( ex.Message.Contains("タイムアウト") || ex.Message.Contains("接続が予期せずに閉じられました") )
				{
					// タイムアウト/接続エラーは更新データ無しとして処理
					status = 4;
				}
				else
				{
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_NODISP,
						ctPGID,
						"変更案内更新情報取得中[Webサービス]にてエラーが発生しました。",
						-99,
						ex,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					status = -99;
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"変更案内更新情報取得中[Webサービス]にてエラーが発生しました。",
					-99,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				status = -99;
			}
			finally
			{
				ExitSyncEvent.Set();
			}

			return status;
        }
        #endregion

        #region サポート企業コード判定処理
        /// <summary>
		/// サポート企業コード判定処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>T:サポート企業コード, F:ユーザー企業コード</returns>
		private static bool IsBroadleaf(string enterpriseCode)
		{
			return enterpriseCode.StartsWith("0140150842030");
        }
        #endregion

        #region 前回データ比較処理
        /// <summary>
		/// 前回データ比較処理
		/// </summary>
		/// <param name="latestDataIndex"></param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:更新データ有り</description></item>
		/// <item><description>4:更新データ無し</description></item>
		/// </list>
		/// </returns>
		private static int CompareToLatestData(int latestDataIndex)
		{
			int status = 4;


			// 配信情報
			//if (PgMulcasInf != null)  //Del 2008.01.07 Kouguchi
			if (ChangGidncInf1 != null)  //Add 2008.01.07 Kouguchi
			{
				// バージョンが同じor古い場合は無効にする
				//if (LatestDataArray[latestDataIndex].MulticastVersion.CompareTo(PgMulcasInf.MulticastVersion) >= 0)  //Del 2008.01.07 Kouguchi
				if (LatestDataArray[latestDataIndex].MulticastVersion.CompareTo(ChangGidncInf1.McastGidncVersionCd) >= 0)  //Add 2008.01.07 Kouguchi
				{
					//PgMulcasInf = null;  //Del 2008.01.07 Kouguchi
					ChangGidncInf1 = null;  //Add 2008.01.07 Kouguchi

                    WebTopPageURL2 = WebTopPageURL2.Substring(0,5) + "0" + WebTopPageURL2.Substring(6,3);  //Add 2008.01.07 Kouguchi
                }
				else
				{
					status = 0;
				}
			}

			// 定期メンテ情報
			//if (SvrMntInfNml != null)  //Del 2008.01.07 Kouguchi
			if (ChangGidncInf2 != null)
			{
				// 連番が同じor古い場合は無効にする
				//if (LatestDataArray[latestDataIndex].NmlServerMainteConsNo >= SvrMntInfNml.ServerMainteConsNo)  //Del 2008.01.07 Kouguchi
				if (LatestDataArray[latestDataIndex].NmlServerMainteConsNo >= ChangGidncInf2.MulticastConsNo)  //Add 2008.01.07 Kouguchi
				{
					//SvrMntInfNml = null;  //Del 2008.01.07 Kouguchi
					ChangGidncInf2 = null;  //Add 2008.01.07 Kouguchi

                    //WebTopPageURL2 = WebTopPageURL2.Substring(0,6) + "0" + WebTopPageURL2.Substring(7,2);  //Add 2008.01.07 Kouguchi  //Del 2008.03.27 Kouguchi
                    SW_ChangGidncInf2 = 1;  //Add 2008.03.27 Kouguchi
                }
				else
				{
					status = 0;
				}
			}

            //Add ↓↓↓ 2008.01.07 Kouguchi
			// データメンテ情報
			if (ChangGidncInf3 != null)
			{
				// 連番が同じor古い場合は無効にする
				if (LatestDataArray[latestDataIndex].DatServerMainteConsNo >= ChangGidncInf3.MulticastConsNo) 
				{
					ChangGidncInf3 = null;

                    //WebTopPageURL2 = WebTopPageURL2.Substring(0,6) + "0" + WebTopPageURL2.Substring(7,2);  //Add 2008.01.07 Kouguchi  //Del 2008.03.27 Kouguchi
                    SW_ChangGidncInf3 = 1;  //Add 2008.03.27 Kouguchi
                }
				else
				{
					status = 0;
				}
			}
            //Add ↑↑↑ 2008.01.07 Kouguchi

            // 緊急メンテ情報
			//if (SvrMntInfEmg != null)  //Del 2008.01.07 Kouguhci
            if (ChangGidncInf4 != null)  //Add 2008.01.07 Kouguchi
            {
                // 連番が同じor古い場合は無効にする
                //if (LatestDataArray[latestDataIndex].EmgServerMainteConsNo >= SvrMntInfEmg.ServerMainteConsNo)  //Del 2008.01.07 Kouguchi
                if (LatestDataArray[latestDataIndex].EmgServerMainteConsNo >= ChangGidncInf4.MulticastConsNo)  //Add 2008.01.07 Kouguchi
                {
                    //SvrMntInfEmg = null;  //Del 2008.01.07 Kouguhci
                    ChangGidncInf4 = null;  //Add 2008.01.07 Kouguchi

                    WebTopPageURL2 = WebTopPageURL2.Substring(0,7) + "0" + WebTopPageURL2.Substring(8,1);  //Add 2008.01.07 Kouguchi
                }
                else
                {
                    status = 0;
                }
            }

            //Add ↓↓↓ 2008.01.07 Kouguchi
			// 印字位置リリース情報
			if (ChangGidncInf5 != null)
			{
				// 連番が同じor古い場合は無効にする
				if (LatestDataArray[latestDataIndex].PrintPositionConsNo >= ChangGidncInf5.MulticastConsNo)
				{
					ChangGidncInf5 = null;

                    WebTopPageURL2 = WebTopPageURL2.Substring(0,8) + "0";  //Add 2008.01.07 Kouguchi
				}
				else
				{
					status = 0;
				}
			}
            //Add ↑↑↑ 2008.01.07 Kouguchi

			return status;
        }
        #endregion

        #region 各業務アプリ起動
        /// <summary>
		/// 各業務アプリを起動します
		/// </summary>
		/// <param name="appFullPath">業務アプリのフルパス</param>
		/// <param name="param">起動パラメータ</param>
		private static void StartChildApplication(string appFullPath, string param)
		{
			// 起動プログラム存在チェック
			if (System.IO.File.Exists(appFullPath) == false)
			{
				return;
			}

			// 業務アプリに渡すパラメータ 
			string paramata = string.Format("{0} {1} {2}", Program.MainArgs[0], Program.MainArgs[1], param);

			// 0:AccessTicket, 1:ポート番号
			System.Diagnostics.Process process = System.Diagnostics.Process.Start(appFullPath, paramata);
        }
        #endregion

        #endregion


        #region Private Methods (Control's EventHandler)

        #region フォーム表示前イベントハンドラ
        /// <summary>
		/// フォーム表示前イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void SFCMN00783UA_Load(object sender, EventArgs e)
		{
            // 通知ラベル設定
			this.SetInfoLabel();
            // 初期表示位置設定
			this.SetFormLocation();
        }
        #endregion

        #region フォーム表示後イベントハンドラ
        /// <summary>
		/// フォーム表示後イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void SFCMN00783UA_Shown(object sender, EventArgs e)
		{
			// タイマーによるフェードイン表示処理開始
			this.timr_OpenClose.Tag = "Open";
			this.timr_OpenClose.Enabled = true;
        }
        #endregion 

        #region オープン/クローズ制御タイマーイベントハンドラ
        /// <summary>
		/// オープン/クローズ制御タイマーイベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void timr_OpenClose_Tick(object sender, EventArgs e)
		{
			switch ((string)this.timr_OpenClose.Tag)
			{
				case "Open":
					// フェードイン表示処理
					if (this.Location.Y <= this.screenHeight - this.Size.Height)
					{
						this.TopMost = true;
						this.timr_OpenClose.Tag = "End";
					}
					else
					{
						this.Location = new Point(this.screenWidth - this.Size.Width, this.Location.Y - 3);
					}
					break;
				case "Close":
					// フェードアウト表示処理
					if (this.Opacity <= 0)
					{
						this.timr_OpenClose.Enabled = false;
						this.timr_OpenClose.Tag = "WaitRoop";
						this.Hide();

						if (this.chk_ThisTimeOnly.Checked)
						{
							// 今回の情報を保存
							WriteLatestChangeInfoData(true);
						}
						this.timr_OpenClose.Enabled = true;
					}
					else
					{
						this.Opacity = this.Opacity - 0.02;
					}
					break;
				case "WaitRoop":
					this.timr_OpenClose.Enabled = false;

					// 更新チェック待機処理
					if (CheckChangeInfoWaitRoop(true) == 0)
					{
						this.DisplayForm();
					}
					else
					{
#if DISP_ERRDIALOG
						MessageBox.Show(
                            "PM.NS 変更案内通知クライアントにてエラーが発生しました。",
                            "PM.NS 変更案内通知",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1);
#endif
						this.canCloseFlg = true;

						// 監視プロセス終了
						EndProcess();
					}
					break;
				case "End":
				default:
					this.TopMost = false;
					// タイマー終了処理
					this.timr_OpenClose.Enabled = false;
					this.timr_OpenClose.Tag = null;
					break;
			}
        }
        #endregion

        #region フォーム終了前イベントハンドラ
        /// <summary>
		/// フォーム終了前イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void SFCMN00783UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.canCloseFlg)
			{
				if (e.CloseReason == CloseReason.UserClosing)
				{
					e.Cancel = true;
				}

				this.timr_OpenClose.Tag = "Close";
				this.timr_OpenClose.Enabled = true;
			}
        }
        #endregion

        #region 変更内容通知ラベルクリックイベントハンドラ
        /// <summary>
		/// 変更内容通知ラベルクリックイベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void lbl_Info_Click(object sender, EventArgs e)
		{
			//StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL));  //Del 2008.01.07 Kouguchi

            // 2008.11.20 Update >>>
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL + "SFCMN00771W.aspx?TICKET=" + CompanyAuthInfo.AccessTicket.ToString() + WebTopPageURL2.ToString()));  //Add 2008.01.07 Kouguchi
            StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:1 /Lmt:2 /Mhf:1 /BrwsTyp:1 /Prdct:2 {0}", WebTopPageURL + "SFCMN00771W.aspx?TICKET=" + CompanyAuthInfo.AccessTicket.ToString() + WebTopPageURL2.ToString())); 
            // 2008.11.20 Update <<<

            //Test用 (NsBrowser のアドレスを表示する)
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:0 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL + "SFCMN00771W.aspx?TICKET=" + CompanyAuthInfo.AccessTicket.ToString() + WebTopPageURL2.ToString()));

            ////StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL + WebTopPageURL2.ToString()));  //Add 2008.01.07 Kouguchi
        }
        #endregion

        #endregion


        #region Private Methods

        #region フォームを表示するメソッド
        /// <summary>
		/// フォームを表示するメソッド
		/// </summary>
		private void DisplayForm()
		{
			// 画面を表示
			this.Show();

			// 通知ラベル設定
			this.SetInfoLabel();

			// フォーム位置設定
			this.SetFormLocation();

			// 透明度復帰
			this.Opacity = 1.0f;

			// 2007.09.19 Chg T.Sugawa @チェックボックスはデフォルトOFFに仕様変更
			//// チェックボックスON
			//this.chk_ThisTimeOnly.Checked = true;
			// チェックボックスOFF
			this.chk_ThisTimeOnly.Checked = false;

			this.timr_OpenClose.Tag = "Open";
			this.timr_OpenClose.Enabled = true;
        }
        #endregion 

        #region フォーム初期位置設定処理
        /// <summary>
		/// フォーム初期位置設定処理
		/// </summary>
		private void SetFormLocation()
		{
			//フォームの位置決定
			this.screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
			this.screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

			this.Location = new Point(this.screenWidth, this.screenHeight);
        }
        #endregion

        #region 通知ラベル設定処理
        /// <summary>
		/// 通知ラベル設定処理
		/// </summary>
		private void SetInfoLabel()
		{
			List<Label> infoLabels = new List<Label>();

			// 緊急メンテ情報
			//if (SvrMntInfEmg != null)  //Del 2008.01.07 Kouguchi
			if (ChangGidncInf4 != null)  //Add 2008.01.07 Kouguchi
			{
				this.lbl_Info01.Visible = true;
				infoLabels.Add(this.lbl_Info01);
			}
			else
			{
				this.lbl_Info01.Visible = false;
			}

            //Del ↓↓↓ 2008.01.07 Kouguchi
            //// 配信情報
            //if (PgMulcasInf != null)
            //{
            //    this.lbl_Info02.Visible = true;
            //    infoLabels.Add(this.lbl_Info02);
            //}
            //else
            //{
            //    this.lbl_Info02.Visible = false;
            //}
            //// 定期メンテ情報
            //if (SvrMntInfNml != null)
            //{
            //    this.lbl_Info03.Visible = true;
            //    infoLabels.Add(this.lbl_Info03);
            //}
            //else
            //{
            //    this.lbl_Info03.Visible = false;
            //}
            //Del ↑↑↑ 2008.01.07 Kouguchi

            //Add ↓↓↓ 2008.01.07 Kouguchi
            // 配信情報・定期メンテ情報・サーバーメンテ情報・印字位置リリース情報
			if ( (ChangGidncInf1 != null) || (ChangGidncInf2 != null) || (ChangGidncInf3 != null)  || (ChangGidncInf5 != null))
			{
				this.lbl_Info02.Visible = true;
				infoLabels.Add(this.lbl_Info02);
			}
			else
			{
				this.lbl_Info02.Visible = false;
			}

    		this.lbl_Info03.Visible = false;
            //Add ↑↑↑ 2008.01.07 Kouguchi


			// ラベル位置/フォームサイズ設定
			switch (infoLabels.Count)
			{
				case 1:
					this.Height = 140;
					infoLabels[0].Location = new Point(40, 20);
					break;
				case 2:
					this.Height = 140;
					infoLabels[0].Location = new Point(40, 10);
					infoLabels[1].Location = new Point(40, 35);
					break;
				case 3:
					this.Height = 170;
					infoLabels[0].Location = new Point(40, 10);
					infoLabels[1].Location = new Point(40, 35);
					infoLabels[2].Location = new Point(40, 60);
					break;
			}
        }
        #endregion

        // 2008.11.20 Add >>>
        #region 認証情報よりInfomationのURL取得
        /// <summary>
        /// 認証情報よりInfomationのURL取得
        /// </summary>
        /// <returns></returns>
        private static string GetWebTopPageURLFromPMC()
        {
            string webTopPageURL = string.Empty;
            webTopPageURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.IndexCode_Infomation);	// 更新チェックWebサービスURL
            webTopPageURL += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Infomation, ConstantManagement_SF_PRO.IndexCode_Infomation);

            return webTopPageURL;
        }
        #endregion
        // 2008.11.20 Add <<<

        // 2009.05.12 Add >>>
        #region レジストリでの処理続行チェック
        /// <summary>
        /// 処理を続行するかチェック
        /// </summary>
        /// <returns>True:処理続行、False:処理終了</returns>
        private static bool CheckContinueProcess()
        {
            bool ret = false;
            RegistryKey key = null;
            try
            {
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman", false);

                if (key == null)
                {
                    return false;
                }

                object objValue = key.GetValue("Information", null);

                if (objValue != null && objValue is Int32)
                {
                    if ((Int32)objValue == 1)
                    {
                        ret = true;
                    }
                }
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
            return ret;
        }
        #endregion
        // 2009.05.12 Add <<<

        #endregion


    }

}

