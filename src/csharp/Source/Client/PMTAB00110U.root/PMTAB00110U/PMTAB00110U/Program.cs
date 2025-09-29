using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;
        private static TabSCMUpLoadAcs tabSCMUpLoadAcs = null;  //ADD  鄭慕鈞 2013/06/24 Redmine#37173 設定マスタアップロード(PM本体側)起動モードの追加
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // オンライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMTAB00110U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    // ----- ADD  鄭慕鈞 2013/06/24 Redmine#37173 設定マスタアップロード(PM本体側)起動モードの追加----->>>>>
                    else
                    {
                        if (_parameter.Length > 0)
                        {
                            if (_parameter[0].Equals("BATCH"))
                            {
                                if (tabSCMUpLoadAcs == null)
                                {
                                    tabSCMUpLoadAcs = new TabSCMUpLoadAcs();
                                }
                                tabSCMUpLoadAcs.UploadFromNStoSCMByBatch(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, 0);
                            }
                        }
                        else
                        {
                            _form = new PMTAB00110UA();

                            System.Windows.Forms.Application.Run(_form);
                        }
                    }
                    // ----- ADD  鄭慕鈞 2013/06/24 Redmine#37173 設定マスタアップロード(PM本体側)起動モードの追加-----<<<<<
                    // ----- DEL  鄭慕鈞 2013/06/24 Redmine#37173 設定マスタアップロード(PM本体側)起動モードの追加----->>>>>
                    //else
                    //{
                    //    _form = new PMTAB00110UA();

                    //    System.Windows.Forms.Application.Run(_form);
                    //}
                    // ----- DEL  鄭慕鈞 2013/06/24 Redmine#37173 設定マスタアップロード(PM本体側)起動モードの追加-----<<<<<
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMTAB00110U", msg, 0, MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMTAB00110U", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MAKON01100UA());
            */
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMTAB00110U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMTAB00110U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}
