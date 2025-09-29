//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 環境調査
// プログラム概要   : 環境調査エントリポイント実装クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 佐々木亘
// 作 成 日  2020/06/15   修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 環境調査メイン エントリ ポイント実装クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 環境調査のメイン エントリ ポイントを実装するクラスの定義と実装</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    static class PMCMN00150U
    {
        #region 定数定義

        /// <summary>
        /// 起動パラメータ：スケジューラ
        /// </summary>
        private const string ARGS_Scheduler = "Scheduler";

        /// <summary>
        /// 起動パラメータ：配信
        /// </summary>
        private const string ARGS_Delivery = "Delivery";

        /// <summary>
        /// 起動モード：パラメータなし
        /// </summary>
        private const int MODE_None = 0;

        /// <summary>
        /// 起動モード：スケジューラ
        /// </summary>
        private const int MODE_Scheduler = 1;

        /// <summary>
        /// 起動モード：配信
        /// </summary>
        private const int MODE_Delivery = 2;

        /// <summary>
        /// USER_APレジストリキー　ルート
        /// </summary>
        private const string RegistryKeyUSER_APMain = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// USER_APレジストリキー　作業パス
        /// </summary>
        private const string RegistryKeyUSER_APInstallDirectory = "InstallDirectory";

        /// <summary>
        /// 作業パスデフォルト
        /// </summary>
        private const string WorkingDirDefault = @"C:\Program Files\Partsman\USER_AP";

        #endregion //定数定義

        #region プライベートフィールド

        #endregion //プライベートフィールド

        #region メンバーフィールド
        /// <summary>
        /// 起動パラメータ一時保持領域
        /// </summary>
        private static string[] ExecParameter;
        #endregion //メンバーフィールド

        /// <summary>
        /// 環境調査メイン エントリ ポイント
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : 環境調査の起動時に実行されるメイン エントリ ポイント</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            // ２重起動チェック
            if (Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                return;
            }

            int statusMethodColl = (int)EnvSurvAcsParam.StatusCode.Error;
            string msg = string.Empty;
            string workDir = null;
            int execMode = MODE_None;

            PMCMN00150U.ExecParameter = args;

            // 起動モード
            if (PMCMN00150U.ExecParameter.Length > 0)
            {
                switch (PMCMN00150U.ExecParameter[0])
                {
                    case ARGS_Scheduler:  // スケジューラ
                        execMode = MODE_Scheduler;
                        break;
                    case ARGS_Delivery:  // 配信
                        execMode = MODE_Delivery;
                        break;
                    default:
                        break;
                }
            }
            else
            {
#if DEBUG
                execMode = MODE_Scheduler;
#endif
            }

            // レジストリキー取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(PMCMN00150U.RegistryKeyUSER_APMain);

            // 作業ディレクトリ取得
            if (key == null) // あってはいけないケース
            {
                workDir = PMCMN00150U.WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue(PMCMN00150U.RegistryKeyUSER_APInstallDirectory, PMCMN00150U.WorkingDirDefault).ToString();
            }

            try
            {
                System.IO.Directory.SetCurrentDirectory(workDir);
                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                statusMethodColl = ServerApplicationMethodCallControl.StartApplication(out msg, ref ExecParameter, ConstantManagement_SF_PRO.ProductCode);

                if (statusMethodColl != (int)EnvSurvAcsParam.StatusCode.Normal)
                {
                    // ログ出力
                }

            }
            catch
            {
                statusMethodColl = (int)EnvSurvAcsParam.StatusCode.Error1001;
                // ログ出力
            }

            if (statusMethodColl == (int)EnvSurvAcsParam.StatusCode.Normal)
            {
                // 起動パラメータチェック
                if (execMode == MODE_None)
                {
                    statusMethodColl = (int)EnvSurvAcsParam.StatusCode.ParamErr;
                    // ログ出力
                }
            }

            EnvSurvAcs esa = null;
            try
            {
                if (statusMethodColl == (int)EnvSurvAcsParam.StatusCode.Normal)
                {
                    esa = new EnvSurvAcs();
                    // 環境調査共通部品呼び出し
                    statusMethodColl = esa.GetEnvSurvInfoLogOutput();
                    if (statusMethodColl != (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ログ出力
                    }
                }
            }
            catch
            {
                // ログ出力
            }
        }
    }
}