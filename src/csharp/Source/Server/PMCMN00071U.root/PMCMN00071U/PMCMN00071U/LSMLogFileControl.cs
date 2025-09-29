using System;
using System.IO;
using System.Reflection;
using System.Text;

using Microsoft.Win32;

using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Batch
{
    /// <summary>
    /// LSMログファイル操作クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : LSMログファイルを変換しCLCログディレクトリに保存します。</br>
    /// <br>Programmer : 佐々木 亘</br>
    /// <br>Date       : 2015/05/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class LSMLogFileControl
    {

        /// <summary>
        /// イベントログ出力時に使用するクラス名
        /// </summary>
        const string cClassName = "PMCMN00071U";

        /// <summary>
        /// LSMインストールディレクトリ取得時に使用するレジストリキー名
        /// </summary>
        /// <remarks>
        /// レジストリキー：HKEY_LOCAL_MACHINE\SOFTWARE\Broadleaf\Service\PMC\LSM
        /// </remarks>
        const string cKeyName = @"SOFTWARE\Broadleaf\Service\PMC\LSM";

        /// <summary>
        /// LSMインストールディレクトリ取得時に使用するレジストリ文字列
        /// </summary>
        /// <remarks>
        /// レジストリ文字列：InstallDirectory
        /// <br>値：C:\Program Files\LSM\</br>
        /// </remarks>
        const string cValueName = "InstallDirectory";

        /// <summary>
        /// LSMログファイル取得時に使用するLOGフォルダ名
        /// </summary>
        /// <remarks>
        /// LOGフォルダ名：Log\
        /// <br>CLC用LSMログファイル作成時にも使用</br>
        /// </remarks>
        const string cLogDir = @"Log\";

        /// <summary>
        /// CLC用LSMログファイル作成時に使用するCLC用LSMログファイルの拡張子
        /// </summary>
        /// <remarks>
        /// 拡張子：clc
        /// </remarks>
        const string cCLCLogFileExt = "clc";

        /// <summary>
        /// LSMログファイル内の日付時刻フォーマット定義
        /// </summary>
        /// <remarks>
        /// CLC用LSMログファイル作成時に日付時刻分の長さを判定する為に使用
        /// <br>フォーマット定義：yyyy/MM/dd HH:mm:ss.fff</br>
        /// </remarks>
        const string cLsmLogDateTimeFmt = "yyyy/MM/dd HH:mm:ss.fff";

        /// <summary>
        /// CLC用LSMログファイルの日付時刻フォーマット定義
        /// </summary>
        /// <remarks>
        /// CLC用LSMログファイル作成時に日付時刻フォーマットに変換する為に使用
        /// <br>フォーマット定義：MM/dd HH:mm:ss</br>
        /// </remarks>
        const string cLsmToCLCLogDateTimeFmt = "MM/dd HH:mm:ss";

        /// <summary>
        /// CLC用LSMログファイル作成対象のファイル名リスト
        /// </summary>
        /// <remarks>
        /// CLC用にLSMログファイルを追加で作成する際はこのリストに追加する
        /// <br>BAUClient_Log.txt</br>
        /// <br>LSMService_Log.txt</br>
        /// </remarks>
        static readonly string[] cLSMLogFile = { "BAUClient_Log.txt", 
                                                 "LSMService_Log.txt" };

        /// <summary>
        /// CLC用LSMログファイルの文字数
        /// </summary>
        /// <remarks>
        /// CLC-Tbl_LogHeader ErrorMessageに格納できる文字数：4000文字
        /// </remarks>
        const int cCLCLogFileWordCount = 4000;

        /// <summary>
        /// CLC用LSMログファイルコピーメイン処理
        /// </summary>
        public void CopyLSMToCLCLogFileMain()
        {
            string lsmLogDir = string.Empty;   // LSMログディレクトリ格納
            string lsmLogFile = string.Empty;  // CLC登録用ファイル名格納

            // LSMログディレクトリ取得
            int status = GetLSMLogDir(out lsmLogDir);
            if (status == 0)
            {
                for (int i = 0; i < cLSMLogFile.Length; i++)
                {
                    lsmLogFile = Path.Combine(lsmLogDir, cLSMLogFile[i]);
                    // CLC用LSMログファイルの作成
                    status = GetLSMToCLCLogFile(lsmLogFile);
                    if (status == 0)
                    {
                        // CLCサーバーアップロードディレクトリへコピー
                        CopyLSMToCLCLogFile(lsmLogFile);
                    }
                }
            }
        }

        /// <summary>
        /// LSMログディレクトリ取得
        /// </summary>
        /// <param name="lsmLogDir">LSMログディレクトリ</param>
        /// <returns>結果ステータス（0:正常、以外：エラー</returns>
        protected int GetLSMLogDir(out string lsmLogDir)
        {
            int status = -1;  // エラー

            // 初期化
            lsmLogDir = string.Empty;

            // レジストリよりLSMインストールディレクトリ取得
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(cKeyName);

                if (regKey != null)
                {
                    // レジストリの値を取得
                    string regValue = (string)regKey.GetValue(cValueName, "").ToString().Trim();

                    if (regValue != "")
                    {
                        // ディレクトリ存在チェック
                        if (Directory.Exists(regValue))
                        {
                            // LSMログディレクトリとして保持する
                            lsmLogDir = Path.Combine(regValue, cLogDir);
                            status = 0;  // 正常
                        }
                        else
                        {
                            // フォルダが存在しない場合、イベントログに出力
                            EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("インストールディレクトリが存在しません。"));
                        }
                    }
                    else
                    {
                        // レジストリにディレクトリが設定されていない場合、イベントログ出力
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("ディレクトリが設定されていません。"));
                    }
                }
                else
                {
                    // レジストリが存在しない場合、イベントログ出力
                    EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("レジストリが取得できません。"));
                }
            }
            catch (NullReferenceException)
            {
                // 文字列が存在しない場合、イベントログ出力
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("レジストリ情報が不足しています。"));
            }
            catch (Exception ex)
            {
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("ログのコピーに失敗しました。 Exception:[{0}]", ex.Message));
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// CLC登録用LSMログファイル作成
        /// </summary>
        /// <param name="lsmLogFile">LSMログファイル</param>
        /// <returns>結果ステータス（0:正常、以外：エラー</returns>
        protected int GetLSMToCLCLogFile(string lsmLogFile)
        {
            int status = 0;  // 正常

            // LSMログファイルが存在しない場合
            if (File.Exists(lsmLogFile) == false)
            {
                return status;
            }

            try
            {
                StringBuilder buffer = new StringBuilder(1024 * 4 * 4);         // CLC登録用LSMログファイルの文字格納（4000文字 1文字 4バイト長）
                FileStream fs = null;                                           // filestream
                StreamReader reader = null;                                     // streamreader
                string line = string.Empty;                                     // LSMログファイル　行単位で格納
                int charLength = -1;                                            // CLC登録用LSMログファイル文字数格納
                int dateTimeLength = string.Format(cLsmLogDateTimeFmt).Length;  // 変換前の日付時刻フォーマットの文字数取得
                try
                {
                    fs = new FileStream(lsmLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);  // ファイルオープン
                    reader = new StreamReader(fs, Encoding.UTF8);
                    while ((line = reader.ReadLine()) != null)
                    {
                        // 日付時刻フォーマット変更
                        if (line.Length >= dateTimeLength)                  // 文字数以上存在した場合のみ変換可能
                        {
                            DateTime dt;
                            string lsmLogDateTime = line.Substring(0, dateTimeLength);
                            if (DateTime.TryParse(lsmLogDateTime, out dt))       // 日付日時に変換可能な場合のみ対象
                            {
                                // 変換後の日付時刻に置き換え格納する
                                buffer.Append(dt.ToString(cLsmToCLCLogDateTimeFmt)).AppendLine(line.Substring(dateTimeLength));
                            }
                            else
                            {
                                // 変換せずにそのまま格納
                                buffer.AppendLine(line);
                            }
                        }
                        else
                        {
                            // 空の行は含めない
                            if (line.Length != 0)
                            {
                                // 変換せずにそのまま格納
                                buffer.AppendLine(line);
                            }
                        }

                        // 4000文字を超えた場合、先頭行から行削除する
                        // 文字数を確認
                        charLength = buffer.Length;
                        while (charLength > cCLCLogFileWordCount)
                        {
                            // 先頭文字列から改行までの文字数
                            int endPos = buffer.ToString().IndexOf(Environment.NewLine) + Environment.NewLine.Length;

                            // 改行が無い または　4000文字以上をカットする場合はオーバーした文字数分削除する。
                            endPos = ((endPos <= 0) | (endPos >= cCLCLogFileWordCount)) ? (charLength - cCLCLogFileWordCount) : endPos;

                            // 先頭文字から改行まで削除
                            buffer.Remove(0, endPos);
                            // 文字数を確認
                            charLength = buffer.Length;
                        }
                    }
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }

                // 書き込み可能な文字が存在する場合
                if (buffer.Length != 0)
                {
                    // LSMログフォルダにCLCログファイルを作成
                    // 拡張子をCLCに変更
                    string clcLogFileName = Path.ChangeExtension(lsmLogFile, cCLCLogFileExt);
                    StreamWriter writer = null;
                    try
                    {
                        writer = new StreamWriter(clcLogFileName, false, Encoding.UTF8);
                        writer.Write(buffer);
                    }
                    finally
                    {
                        if (writer != null)
                        {
                            writer.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("ログのコピーに失敗しました。 Exception:[{0}]", ex.Message));
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// CLCサーバーアップロードディレクトリコピー処理
        /// </summary>
        /// <param name="sFile">LSMログファイル</param>
        protected void CopyLSMToCLCLogFile(string lsmLogFile)
        {
            try
            {
                string clcLogFileName = Path.ChangeExtension(lsmLogFile, cCLCLogFileExt);

                // CLC用LSMログファイルが存在しない場合
                if (File.Exists(clcLogFileName) == false)
                {
                    return;
                }

                // CLCログファイルをCLCアップロードディレクトリに保存
                CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
                int status = clcLogTextOut.CopyClcLogFile(clcLogFileName);
                switch (status)
                {
                    case 0:  // 正常終了
                        break;
                    case 4:
                        // コピー元ファイルが存在しない場合、イベントログ出力
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC用LSMログファイルが存在しません。ST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                    case 9:
                        // コピー失敗した（対象フォルダ、ファイルに出力権限が存在しない）場合、イベントログ出力
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC用LSMログファイルのコピーに失敗しました。ST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                    case -1:
                        // 例外エラーの場合、イベントログ出力
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC用LSMログファイルのコピーで例外エラーが発生しました。ST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                    default:
                        // その他のエラーの場合、イベントログ出力
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC用LSMログファイルのコピーでエラーが発生しました。ST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                }
            }
            catch (Exception ex)
            {
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("ログのコピーに失敗しました。 Exception:[{0}]", ex.Message));
            }
        }
    }
}
