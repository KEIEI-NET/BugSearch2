using System;
using System.Windows.Forms;
using System.Diagnostics;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 部品MAXサイト起動フレームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 部品MAXサイト起動フレームクラスを起動します。</br>
	/// <br>Programmer : 宮本 利明</br>
	/// <br>Date       : 2015/10/14</br>
	/// </remarks>
    public class ApplicationController
	{
		private static ApplicationContext _apli = null;
        public static string[] _parameter = null;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string msg = "";
            try
            {
                _parameter = args;

                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // オンライン状態判断
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHST00010U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        // 起動可能か判定
                        if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry("PMHST00010U", true))
                        {
                            return;
                        }
                        ApplicationController.ProcessStart();
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHST00010U", msg, 0, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                msg = "認証中にエラーが発生しました。USBプロテクタが刺さっている事を確認してください。[" + ex.Message + "]";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMHST00010U", msg, -1, MessageBoxButtons.OK);
            }
            finally
            {
                // 開放
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
		
		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();

			//従業員ログオフのメッセージを表示
			TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHST00010U", e.ToString(), 0, MessageBoxButtons.OK);

			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}

        /// <summary>
        /// URL置換
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL置換を行います。</br>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 2015/10/14</br>
        /// </remarks>
        protected static string UrlReplace(string domain, string path)
        {
            string wkStr = domain + path;
            // 置換
            wkStr = wkStr.Replace("$enterpriseCode", LoginInfoAcquisition.EnterpriseCode);
            wkStr = wkStr.Replace("$assemblyVersion", "1.0.0");

            return wkStr;
        }

        /// <summary>
        /// URL構築
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL構築を行います。</br>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 2015/10/14</br>
        /// </remarks>
        protected static int CreateUrl(out string url)
        {
            string wkStr = "";
            string msg = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                string domain = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_PARTSMAX);
                string path = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_PARTSMAX, ConstantManagement_SF_PRO.IndexCode_PARTSMAX_WebPath);

                // 置換
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                msg = "接続先取得中にエラーが発生しました。[" + ex.Message + "]";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMHST00010U", msg, -1, MessageBoxButtons.OK);
                return -1;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// URL起動
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL起動を行います。</br>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 2015/10/14</br>
        /// </remarks>
        protected static int ProcessStart()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string msg = "";
            string url = "";
            try
            {
                // 連携URL(部品MAX)を作成します。
                status = ApplicationController.CreateUrl(out url);
                if (status == 0)
                {
                    // プロセス起動
                    Process.Start(url);
                }
            }
            catch (Exception ex)
            {
                msg = "ブラウザ起動中にエラーが発生しました。[" + ex.Message  + "]\r\nセキュリティ対策ソフトでPartsmanインストールフォルダが除外設定になっているかご確認お願いします。";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMHST00010U", msg, -1, MessageBoxButtons.OK);
                return -1;
            }
            return status;
        }
    }
}
