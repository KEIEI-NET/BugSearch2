//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : HTプログラム導入処理
// プログラム概要   : HTプログラム導入処理エントリポイント実装クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 森山　浩
// 作 成 日  2017/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HTプログラム導入処理エントリポイント実装クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : HTプログラム導入処理エントリポイントを実装するクラスの定義と実装</br>
    /// <br>Programmer : 森山　浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    static class PMHND00800U
    {
        #region コンスト　フィールド
        /// <summary>起動パラメータ：通常メニュー</summary>
        private static string NormalMenu = "9000";

        /// <summary>起動パラメータ：サポートメニュー</summary>
        private static string SupportMenu = "9001";

        /// <summary>起動パラメータ：バージョンチェック</summary>
        private static string VersionCheck = "9002";

        #endregion


        #region メンバーフィールド

        /// <summary>
        /// 起動パラメータ
        /// </summary>
        internal static string[] ExecParameter;

        /// <summary>
        ///  HTプログラム導入処理メインUI
        /// </summary>
        private static Form MainForm = null;

        #endregion //メンバーフィールド

        /// <summary>
        /// HTプログラム導入処理メイン エントリ ポイント
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : HTプログラム導入処理の起動時に実行されるメイン エントリ ポイント</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                ExecParameter = args;

                // パラメータチェック
                int mode = CheckParmter(args);
                if (mode == PMHND00802AC.ParamCheckError)
                {
                    MessageBox.Show("パラメータチェックエラー");
                    return;
                }
                MainForm = new PMHND008000UA(mode);
                System.Windows.Forms.Application.Run(MainForm);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
        /// <remarks>
        /// <br>Note       : アプリケーション終了イベント</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 起動パラメターチェック
        /// </summary>
        /// <param name="args">起動パラメター<param>
        /// <remarks>
        /// <br>Note       : 起動パラメターチェック</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private static int CheckParmter(string[] args)
        {
            if (args.Length != 3)
            {
                return PMHND00802AC.ParamCheckError;
            }
            if (args[2] == NormalMenu)
            {
                return PMHND00802AC.NormalMenuMode;
            }
            else if (args[2] == SupportMenu)
            {
                return PMHND00802AC.SupportMenuMode;
            }
            else if (args[2] == VersionCheck)
            {
                return PMHND00802AC.VersionCheckMode;
            }
            return PMHND00802AC.ParamCheckError;

        }

    }
}