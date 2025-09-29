/// <summary>
/// デジタルデータ検索　サムネイル画像取得ログ出力
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;
using System.IO;
using System.Text;

namespace PMTAB00301C
{
    /// <summary>
    /// PMTABサムネイル画像取得ログ出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : PMTABサムネイル画像取得ログ出力処理を制御します。</br>
    /// </remarks>
    public class PMTAB00301CC
    {

        #region << Private Const >>

        ///<summary>ログ出力ディレクトリ名</summary>
        private const string PathLog = "log";
        ///<summary>ログ出力年月日書式</summary>
        private const string DefaultTimeFormat = "yyyyMMdd";
        ///<summary>ログ出力ファイル拡張子</summary>
        private const string DefaultLogFilePrefix = ".log";
        ///<summary>ログ出力ファイルデフォルトエンコード</summary>
        private const string DefaultEncode = "UTF-8";
        ///<summary>ログ出力ファイル書式</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2}";     // yyyy/MM/dd hh:mm:ss
        ///<summary>ログ出力モード（ログ出力する；true）（"false"）</summary>
        private const string LogOutPut = "true";
        ///<summary>プログラム名称（ログ出力用）</summary>
        private const string ProgramName = "PMTAB00301C"; 

        #endregion

        #region << Private Member >>

        ///<summary>インスタンス</summary>
        private static PMTAB00301CC logger = null;

        ///<summary>ログ出力モード</summary>
        private bool logOutMode = false;

        #endregion

        #region << Public Method >>

        #region << インスタンス取得処理 >>
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>PMTABサムネイル画像取得ログ出力クラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note        : ログ出力クラスのインスタンスを返す処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public static PMTAB00301CC getInstance()
        {
            if (logger == null)
            {
                logger = new PMTAB00301CC();
            }
            return logger;
        }

        #endregion

        #region << ログ出力モード設定処理 >>
        /// <summary>
        /// ログ出力モード設定処理
        /// </summary>
        /// <param name="mode">ログ出力モード</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : ログ出力クラスのログ出力モードを設定する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public void SetLogOutMode(String mode)
        {
            if (mode.ToLower() == LogOutPut)
            {
                this.logOutMode = true;
            }
            else
            {
                this.logOutMode = false;
            }
        }

        #endregion

        #region << ログ書き込み処理 >>
        /// <summary>
        /// ログ書き込み処理
        /// </summary>
        /// <param name="msg">ログメッセージ</param>
        /// <param name="forceFlag">強制出力フラグジ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : ログ出力クラスのログ出力する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public void WriteLog(string msg, bool forceFlag = false)
        {

            // ログ出力モードがtrue以外の場合、ログを出力しない
            // 強制出力フラグがtrueの場合は、ログを強制的に出力する
            if (!forceFlag && !this.logOutMode)
            {
                return;
            }

            // ログ出力先ディレクトリ
            string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), PathLog);

            try
            {
                // ログ出力フォルダが存在しない場合、フォルダを作成する
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path,
                    ProgramName + "_" + DateTime.Now.ToString(DefaultTimeFormat) + DefaultLogFilePrefix),
                    FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, msg));

                // ファイルストリームがnullではない場合、
                if (writer != null)
                {
                    writer.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            } catch(Exception ex) {
                throw new Exception("ログ書き込み処理でエラーが発生しました。", ex);
            }
        }

        #endregion

        #region << ログファイル削除処理 >>
        /// <summary>
        /// ログファイル削除処理
        /// </summary>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : ログファイルを削除する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public void DeleteLogFile()
        {
            string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), PathLog);

            // ログ出力ディレクトリが存在しない場合は、処理終了
            if (!Directory.Exists(path))
            {
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path); 

            // ディレクトリ内に存在するファイル数文ループ
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                // 拡張子が".log"かチェック
                if (!fileInfo.FullName.EndsWith(DefaultLogFilePrefix)) {
                    continue;
                }

                // １ヶ月経過しているかチェック
                DateTime lastMonthDateTime = DateTime.Now.AddMonths(-1);
                DateTime fileTimeStamp = fileInfo.LastWriteTime;
                if (fileTimeStamp.CompareTo(lastMonthDateTime) > 0)
                {
                    continue;
                }
                // １ヶ月経過しているログファイルを削除
                File.Delete(fileInfo.FullName);
            }
        }

        #endregion

        #endregion

        #region << Private Method >>



        #endregion

    }
}