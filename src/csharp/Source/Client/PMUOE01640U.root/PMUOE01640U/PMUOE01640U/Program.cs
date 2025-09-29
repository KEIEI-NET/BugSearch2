//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 作 成 日  2011/05/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        // プログラムＩＤ
        public const string ctPGID = "PMUOE01640U";

        /// <summary>EXE起動パラメータ</summary>
        public static string[] _parameter;
        /// <summary>EXE起動フォーム</summary>
        public static Form _form = null;


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
                // 第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定
                // 出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        msg = "オフライン状態で本機能はご使用できません。";
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, msg, 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _form = new PMUOE01640UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0)
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctPGID, ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
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
            if (_form != null)
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
            else
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}