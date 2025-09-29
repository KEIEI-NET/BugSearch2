using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <br>Update Note : 2010/01/05　21024 佐々木 健</br>
    /// <br>              メニューや起動ダイアログの残像が残ることがある件の対応(MANTIS[0014851])</br>
    /// <br>Update Note: 2011/02/18 21024 佐々木 健</br>
    /// <br>             SCM対応</br>
    /// <br>              1)キャンセル区分の対応</br>
    /// </remarks>	
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;

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
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAHNB01000U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        int mutexNo = 0;
                        System.Threading.Mutex mt = null;
                        bool createdNew = false;
                        for (int i = 1; i < 999; i++)
                        {
                            mt = new System.Threading.Mutex(true, string.Format("Partsman_MAHNB01000U_{0}", i), out createdNew);
                            if (createdNew)
                            {
                                mutexNo = i;
                                break;
                            }

                        }
                        if (createdNew = false) mt = null;

                        try
                        {
                            // メニューによる起動チェックを行う為、削除。
                            //// 起動可能か判定
                            //if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry("MAHNB01100", true))
                            //{
                            //    return;
                            //}

                            //>>>2010/02/26
                            if (args.Length == 4)
                            {
                                string tempargs = args[3].ToString().Trim();
                                string[] strargs = tempargs.Split(',');

                                if (strargs.Length == 1)
                                {
                                    int customerCode = int.Parse(strargs[0].ToString()); // 得意先コード
                                    _form = new MAHNB01000UA(mutexNo, args[0] + " " + args[1], customerCode);
                                }
                                else
                                {
                                    long inquiryNumber = long.Parse(strargs[0].ToString()); // 問合せ番号
                                    int acptAnOdrStatus = int.Parse(strargs[1].ToString()); // 受注ステータス
                                    string salesSlipNum = strargs[2].ToString().Trim(); // 売上伝票番号
                                    string inqOriginalEpCd = strargs[3].ToString().Trim(); // 問合元企業コード
                                    string inqOriginalSecCd = strargs[4].ToString().Trim(); // 問合元拠点コード
                                    int inqOrdDivCd = 0;
                                    //>>>2010/03/30
                                    //if (strargs.Length >= 6) inqOrdDivCd = int.Parse(strargs[5].ToString()); // 問合せ・発注種別
                                    if (strargs.Length >= 6) inqOrdDivCd = int.Parse(strargs[5].ToString()); // 問合せ・発注種別
                                    //<<<2010/03/30
                                    // 2011/02/18 >>>
                                    ////>>>2010/03/30
                                    //int answerDivCd = 0;
                                    //if (strargs.Length >= 7) answerDivCd = int.Parse(strargs[6].ToString()); // 回答区分
                                    ////<<<2010/03/30

                                    short cancelDiv = 0;
                                    if (strargs.Length >= 7) cancelDiv = short.Parse(strargs[6].ToString()); // 回答区分
                                    // 2011/02/18 <<<

                                    //>>>2010/03/30
                                    //_form = new MAHNB01000UA(mutexNo, args[0] + " " + args[1], inquiryNumber, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd, inqOriginalSecCd, inqOrdDivCd);
                                    // 2011/02/18 >>>
                                    //_form = new MAHNB01000UA(mutexNo, args[0] + " " + args[1], inquiryNumber, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd, inqOriginalSecCd, inqOrdDivCd, answerDivCd);
                                    _form = new MAHNB01000UA(mutexNo, args[0] + " " + args[1], inquiryNumber, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOrdDivCd, cancelDiv);//@@@@20230303
                                    // 2011/02/18 <<<
                                    //<<<2010/03/30
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------------------------------
                                // 通常起動
                                //-----------------------------------------------------------------------------
                                _form = new MAHNB01000UA(mutexNo, args[0] + " " + args[1]);
                            }
                            //<<<2010/02/26
                            SplashWindow.ShowSplash(_form);     // 2010/01/05 Add
                            System.Windows.Forms.Application.Run(_form);
                        }
                        finally
                        {
                            if (mt != null) mt.ReleaseMutex();
                        }
                    }

                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAHNB01000U", msg, 0, MessageBoxButtons.OK);
                }
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
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "MAHNB01000U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAHNB01000U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}