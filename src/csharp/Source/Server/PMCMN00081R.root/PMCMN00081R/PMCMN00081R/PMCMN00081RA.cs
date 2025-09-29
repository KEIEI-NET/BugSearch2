using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

using Microsoft.Win32;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// LSMログチェックモジュールDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : LSMログのチェックを行うクラスです。</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/09/24</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public partial class LSMLogCheckDB : RemoteDB, ILSMLogCheckDB
    {
        /// <summary>
        /// LSMログチェックモジュールDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/09/24</br>
        /// </remarks>
        public LSMLogCheckDB()
        {
        }

        /// <summary>
        /// LSMログチェック
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : LSMログをチェックします。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/09/24</br>
        /// </remarks>
        public int CheckLSMLog(out object retWorkList, out string machineName, object lsmChkWordWorkList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            machineName = Environment.MachineName;
            retWorkList = null;

            try
            {
                status = CheckLSMLogProc(out retWorkList, lsmChkWordWorkList);
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog(ex, "LSMLogCheckDB.CheckLSMLog Exception=" + ex.Message);
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// LSMログチェック
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int CheckLSMLogProc(out object retWorkList, object lsmChkWordWorkList)
        {
            string lsmLogDir = string.Empty;   // LSMログディレクトリ格納
            string lsmLogFile = string.Empty;  // ファイル名格納
            string lsmLogFileName = "LSMService_Log.txt";

            ArrayList msgList = new ArrayList();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  // 抽出結果(全て)

            try
            {

                // LSMログディレクトリ取得
                status = GetLSMLogDir(out lsmLogDir, out msgList);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    lsmLogFile = Path.Combine(lsmLogDir, lsmLogFileName);

                    // LSMログファイルのチェック処理
                    status = CheckLSMLogFile(lsmLogFile, out msgList, lsmChkWordWorkList);
                }

                retWorkList = msgList;
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog(ex, "LSMLogCheckDB.CheckLSMLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// LSMログディレクトリ取得
        /// </summary>
        /// <param name="lsmLogDir">LSMログディレクトリ</param>
        /// <param name="msgList">メッセージリスト</param>
        /// <returns>結果ステータス（0:正常、以外：エラー</returns>
        private int GetLSMLogDir(out string lsmLogDir, out ArrayList msgList)
        {
            // LSMインストールディレクトリ取得時に使用するレジストリキー名
            string keyName = @"SOFTWARE\Broadleaf\Service\PMC\LSM";
            // LSMインストールディレクトリ取得時に使用するレジストリ文字列
            string valueName = "InstallDirectory";
            // LSMログファイル取得時に使用するLOGフォルダ名
            string logDir = @"Log\";
            string lsmLogDateTimeFmt = "yyyy/MM/dd HH:mm:ss.fff";

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string _now = DateTime.Now.ToString(lsmLogDateTimeFmt);

            // 初期化
            lsmLogDir = string.Empty;
            msgList = new ArrayList();

            // レジストリよりLSMインストールディレクトリ取得
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(keyName);

                if (regKey != null)
                {
                    // レジストリの値を取得
                    string regValue = (string)regKey.GetValue(valueName, "").ToString().Trim();

                    if (regValue != "")
                    {
                        // ディレクトリ存在チェック
                        if (Directory.Exists(regValue))
                        {
                            // LSMログディレクトリとして保持する
                            lsmLogDir = Path.Combine(regValue, logDir);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;  // 正常
                        }
                        else
                        {
                            // フォルダが存在しない場合
                            msgList.Add(_now + " LSMのインストールディレクトリが存在しません。");
                        }
                    }
                    else
                    {
                        // レジストリにディレクトリが設定されていない場合
                        msgList.Add(_now + " LSMのディレクトリが設定されていません。");
                    }
                }
                else
                {
                    // レジストリが存在しない場合
                    msgList.Add(_now + " LSMのレジストリが取得できません。");
                }
            }
            catch (NullReferenceException)
            {
                // 文字列が存在しない場合、イベントログ出力
                msgList.Add(_now + " LSMのレジストリ情報が不足しています。");
            }
            catch (Exception ex)
            {
                // 例外
                msgList.Add(_now + " " + ex.Message);
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
        /// LSMログファイルチェック処理
        /// </summary>
        /// <param name="lsmLogFile">LSMログファイル</param>
        /// <returns>結果ステータス（0:正常、以外：エラー</returns>
        private int CheckLSMLogFile(string lsmLogFile, out ArrayList msgList, object lsmChkWordWorkList)
        {
            string lsmLogDateTimeFmt = "yyyy/MM/dd HH:mm:ss.fff";
            DateTime checkTimeTo = DateTime.Now;
            DateTime checkTimeFm = checkTimeTo.AddHours(-1);
            string _now = DateTime.Now.ToString(lsmLogDateTimeFmt);
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 初期化
            msgList = new ArrayList();

            // LSMログファイルが存在しない場合
            if (File.Exists(lsmLogFile) == false)
            {
                // フォルダが存在しない場合
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                msgList.Add(_now + " LSMログファイル(LSMService_Log.txt)が存在しません。");
                return status;
            }

            try
            {
                FileStream fs = null;                                           // filestream
                StreamReader reader = null;                                     // streamreader
                string line = string.Empty;                                     // LSMログファイル　行単位で格納
                int dateTimeLength = string.Format(lsmLogDateTimeFmt).Length;   // 変換前の日付時刻フォーマットの文字数取得
                bool cheackFlg = false;     // True:対象データ有り　False:対象データ無し

                try
                {
                    fs = new FileStream(lsmLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);  // ファイルオープン
                    reader = new StreamReader(fs, Encoding.UTF8);

                    while ((line = reader.ReadLine()) != null)
                    {
                        // 日付時刻フォーマット変更
                        if (line.Length >= dateTimeLength)  // 文字数以上存在した場合のみ変換可能
                        {
                            DateTime dtLog;
                            string lsmLogDateTime = line.Substring(0, dateTimeLength);
                            if (DateTime.TryParse(lsmLogDateTime, out dtLog))   // 日付日時に変換可能な場合のみ対象
                            {
                                if ((dtLog >= checkTimeFm) && (dtLog <= checkTimeTo))   // 範囲内のみ対象
                                {
                                    cheackFlg = true;   // 対象データ有り

                                    // チェック
                                    ArrayList _lsmChkWordWorkList = new ArrayList();
                                    _lsmChkWordWorkList = (ArrayList)lsmChkWordWorkList;
                                    foreach (LsmChkWordWork newDtlWork in _lsmChkWordWorkList)
                                    {
                                        if (0 <= line.IndexOf(newDtlWork.Massage))
                                        {
                                            msgList.Add(line);
                                            status = newDtlWork.Status;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (cheackFlg == true)
                    {
                       // 対象データ有り
                       if (msgList.Count == 0)
                       {
                           // 対象メッセージ無し
                           msgList.Add(_now + " LSMサービスにてアップデート処理が行われている可能性があります。\r\nしばらく時間をおいてから再度実行してください。");
                           status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                           return status;
                       }
                    }
                    else
                    {
                       // 対象データ無し
                       msgList.Add(_now + " LSMサービスに異常が発生している可能性があります。");
                       status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                       return status;
                    }
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                msgList.Add(_now + " CheckLSMLogFile:" + ex.Message);
                status = -1;
            }
            return status;
        }
    }
}
