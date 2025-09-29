//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : HTプログラム導入処理
// プログラム概要   : HTプログラム導入処理ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 森山　浩
// 作 成 日  2017/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HTプログラム導入処理ログ出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : 森山　浩</br>
    /// <br>Date        : 2017/12/22</br>
    /// <br>Note        : HTプログラム導入処理ログ出力処理を制御します。</br>
    /// </remarks>
    public class PMHND00804AE
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
        private const string ProgramName = "PMHND00800U"; 

        #endregion

        #region << Private Member >>

        ///<summary>インスタンス</summary>
        private static PMHND00804AE logger = null;

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
        /// <br>Date        : 2017/12/22</br>
        ///</remarks>
        public static PMHND00804AE getInstance()
        {
            if (logger == null)
            {
                logger = new PMHND00804AE();
            }
            return logger;
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
        /// <br>Date        : 2017/12/22</br>
        ///</remarks>
        public void WriteLog(string msg)
        {
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

        #endregion

        #region << Private Method >>

        #endregion

    }
}