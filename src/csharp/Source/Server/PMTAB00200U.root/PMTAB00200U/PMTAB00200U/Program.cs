//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : PMTABセッション管理データ削除処理 フォームクラス        //
// プログラム概要   : PMTABセッション管理データテーブルに対して削除処理を行う //
//                    を新規作成する。                                        //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11300141-00 作成担当 : 譚洪                                      //
// 作 成 日  2017/04/06 修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMTABセッション管理データ削除処理 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTABセッション管理データテーブルに対して削除処理のフォームクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/04/06</br>
    /// </remarks>
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルに対して削除処理クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            
            string msg = "";
            _parameter = args;
            string workDir = null;
            string dateTime_yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");

            StreamWriter writer = null;                          // テキストログ用

            try
            {
                
                // ﾚｼﾞｽﾄﾘｷｰ取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // カレントフォルダの設定
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                System.IO.Directory.SetCurrentDirectory(workDir);

                Directory.CreateDirectory(@"" + workDir + @"\Log\PMTAB00200U");

                // ﾃｷｽﾄﾛｸﾞ書込み (Main())
                writer = new StreamWriter(@"" + workDir + @"\Log\PMTAB00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " PMTAB00200U.exe　処理開始 " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();


                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                if (status == 0)
                {
                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMTAB00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " ログイン情報取得成功 " + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();

                    _form = new PMTAB00200UA(workDir);
                    string errMsg = string.Empty;
                    ((PMTAB00200UA)_form).DeleteData();
                }
                else
                {
                    string parmMsg = "";
                    foreach (string param in _parameter)
                    {
                        parmMsg = param;
                    }


                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMTAB00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now
                        + " ログイン情報取得失敗 " + "\r\n" + "エラーメッセージ " + msg + "\r\n"
                        + " パラメーター " + parmMsg + "\r\n"
                        + " プロダクトコード " + ConstantManagement_SF_PRO.ProductCode + "\r\n"
                        + " ステータス" + status + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();
                }
            }
            catch (Exception ex)
            {
                writer = new StreamWriter(@"" + workDir + @"\Log\PMTAB00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now
                    + " catch() "
                    + " ログイン情報取得失敗 " + "\r\n" + "エラーメッセージ " + ex + "\r\n"
                    + " パラメーター " + _parameter + "\r\n"
                    + " プロダクトコード " + ConstantManagement_SF_PRO.ProductCode + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
            finally
            {
                // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動終了)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMTAB00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " PMTAB00200U.exe　処理終了 " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                ApplicationStartControl.EndApplication();
            }
        }
       
    }
}