using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {

        #region コンスタント
        public const string pgId = "SFNETMENU";
        #endregion

        #region staticメンバ
        public static System.Windows.Forms.Form _form = null;			    //自分自身のオブジェクト(企業認証強制終了時のメッセージOwner用)
        public static SfNetMenuServerInfo _sfNetMenuServerInfo = null;	    //メニューサーバー・ログイン情報
        private static int _myProcessID = 0;							    //起動アプリのプロセスID
        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                System.Windows.Forms.Application.EnableVisualStyles();

                //●チャネルレジスト
                ApplicationStartControl.RegisterChannel();

                //●パラメータ取得
                if (GetParameter(args))
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    _form = new SFNETMENUF(args);
                    System.Windows.Forms.Application.Run(_form);
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, pgId, ex.Message, 0, ex, MessageBoxButtons.OK, 0);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 起動アプリからのパラメータをローカルに保持します。
        /// 不正データや業務メインアプリが直接起動された場合はfalseを返します。
        /// </summary>
        /// <param rKeyName="arguments">起動アプリからのパラメータ</param>
        /// <returns>成否</returns>
        private static bool GetParameter(string[] arguments)
        {
            try
            {
                //●自分（業務メイン）のプロセスIDを取得
                System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
                _myProcessID = myProcess.Id;

                _sfNetMenuServerInfo = new SfNetMenuServerInfo();
                string retMsg;
                int status = _sfNetMenuServerInfo.CompanyLoginInitial(_myProcessID, out retMsg, new EventHandler(MainMenuReleased));
                //企業認証のみもしくは企業従業員認証していればOK
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return true;
                }
                else
                {
                    if (retMsg != "") TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, pgId, retMsg, 0, MessageBoxButtons.OK);
                    return false;
                }

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, pgId, ex.Message, 0, MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// メインメニュー終了イベント
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private static void MainMenuReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //企業ログオフのメッセージを表示
            if (_form != null)
                TMsgDisp.Show(_form, emErrorLevel.ERR_LEVEL_EXCLAMATION, pgId, "企業認証ログオフされた為、メインメニューを終了します", 0, MessageBoxButtons.OK);
            else
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, pgId, "企業認証ログオフされた為、メインメニューを終了します", 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}