//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 検品データ削除処理 フォームクラス                       //
// プログラム概要   : 検品データテーブルに対して削除処理を行う                //
//                    を新規作成する。                                        //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊                                 //
// 作 成 日  2017/05/22  修正内容 : 新規作成                                  //
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
    /// 検品データ削除処理 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品データテーブルに対して削除処理のフォームクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/05/22</br>
    /// </remarks>
    static class PMHND00200UB
    {
        private static string[] _parameter;						// 起動パラメータ
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : 検品データテーブルに対して削除処理クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            
            string msg = "";
            _parameter = args;
            string workDir = null;
            string dateTime_yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");

            StreamWriter writer = null; // テキストログ用

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

                Directory.CreateDirectory(@"" + workDir + @"\Log\PMHND00200U");

                // ﾃｷｽﾄﾛｸﾞ書込み (Main())
                writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " PMHND00200U.exe　処理開始 " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();


                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                if (status == 0)
                {
                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " ログイン情報取得成功 " + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();

                    _form = new PMHND00200UA(workDir);
                    string errMsg = string.Empty;
                    ((PMHND00200UA)_form).DeleteData();
                }
                else
                {
                    string parmMsg = "";
                    foreach (string param in _parameter)
                    {
                        parmMsg = param;
                    }


                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
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
                writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
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
                writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " PMHND00200U.exe　処理終了 " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                ApplicationStartControl.EndApplication();
            }
        }
       
    }
}