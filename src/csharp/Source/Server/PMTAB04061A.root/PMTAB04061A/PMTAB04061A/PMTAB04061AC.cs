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
using Broadleaf.Application.Common;

namespace Broadleaf.Web
{
    /// <summary>
    /// PMTABサムネイル画像取得ログ出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : PMTABサムネイル画像取得ログ出力処理を制御します。</br>
    /// </remarks>
    public class PMTAB04061AC
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
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        ///<summary>ログ出力モード（ログ出力する；true）（"false"）</summary>
        private const string LogOutPut = "true";
        ///<summary>プログラム名称（ログ出力用）</summary>
        private const string ProgramName = "PMTAB04061A"; 

        #endregion

        #region << Private Member >>

        ///<summary>インスタンス</summary>
        private static PMTAB04061AC logger = null;

        ///<summary>ログ出力モード</summary>
        private bool logOutMode = false;

        #endregion

        #region << Public Method >>

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>PMTABサムネイル画像取得ログ出力クラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note        : ログ出力クラスのインスタンスを返す処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public static PMTAB04061AC getInstance()
        {
            if (logger == null)
            {
                logger = new PMTAB04061AC();
            }
            return logger;
        }

        /// <summary>
        /// ログ出力モード設定処理
        /// </summary>
        /// <param name="mode">ログ出力モード</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : ログ出力クラスのログ出力モードを設定する処理を行います</br>
        /// <br>Programmer	: moriyama</br>
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

        /// <summary>
        /// ログ書き込み処理
        /// </summary>
        /// <param name="msg">ログメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : ログ出力クラスのログ出力する処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.16</br>
        ///</remarks>
        public void WriteLog(string msg)
        {

            // ログ出力モードがtrue以外の場合、ログを出力しない
            if (!this.logOutMode)
            {
                return;
            }
            string path = Path.Combine(NSTabletWebEnv.GetPhysicalPath(NSTabletWebEnv.ClientWebServerFolder.AppData), PathLog);

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
                    writer.Dispose();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
                writer = null;
                fileStream = null;

            } catch(Exception ex) {
                throw new Exception("ログ書き込み処理でエラーが発生しました。", ex);
            }
        }

        #endregion

        #region << Private Method >>

        #endregion

    }
}