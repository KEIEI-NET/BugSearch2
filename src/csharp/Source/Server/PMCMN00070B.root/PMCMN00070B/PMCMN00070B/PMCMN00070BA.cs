using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;

namespace Broadleaf.Library.Diagnostics
{
    /// <summary>
    /// CLCログ出力部品クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : CLCログ収集ツールで収集可能な場所にログをテキスト出力するクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2015.05.25</br>
    /// <br></br>
    /// </remarks>
    public class CLCLogTextOut
    {
        /// <summary>ステータス(正常終了)</summary>
        public const int ST_NOMAL = 0;

        /// <summary>ステータス(コピー元ファイル無しエラー)</summary>
        public const int ST_COPYFILENOTFOUND = 4;

        /// <summary>ステータス(書込権限エラー)</summary>
        public const int ST_COPYFAIL = 9;

        /// <summary>ステータス(例外エラー)</summary>
        public const int ST_COPYEXCEPTION = -1;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CLCLogTextOut()
        {
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="pgId">PGID</param>
        /// <param name="productId">プロダクトID</param>
        /// <param name="message">LOG出力メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="exPara">例外エラー内容</param>
        /// <returns>CLCログ出力ファイル名称</returns>
        public string OutputClcLog(string pgId, string productId, string message, Int32 status, Exception exPara)
        {
            const string CT_SERVICECODE = "CLCLogTextOut"; // サービスコード（CLCログファイル出力部品使用時に使用）
            string logFileName = string.Empty;             // 出力ログファイル名称（CLCログファイル出力部品使用時に使用）
            string outputMessage = string.Empty;           // 出力ログ内容（CLCログファイル出力部品使用時に使用）

            // PGIDチェック
            // PGIDが存在しない場合は処理を中止する
            if (pgId == null || pgId.Trim().Length == 0) return logFileName;

            //プロダクトIDチェック
            if (productId == null) productId = "Partsman";

            // ログファイル名称作成
            // "Client"+DateTimeのTicks+Guid文字列（各Clientにて生成したLogファイルのバッティング防止）
            logFileName = string.Format("Client{0}{1}.log", DateTime.Now.Ticks.ToString(), Guid.NewGuid().ToString());


            // 出力メッセージ作成
            outputMessage = message + " status=" + status.ToString();

            // 例外情報が存在する場合はメッセージに結合する
            if (exPara != null)
                outputMessage += "\r\n" + exPara.Message;

            // ログファイル出力処理
            // KICLC0001Cを使用して出力
            KICLC00001C.LogHeader logHeader = new KICLC00001C.LogHeader();

            int st = logHeader.WriteServiceLogHeader(
                productId,                       // 呼び元から渡されたプロダクトID（空白の場合はPartsmanを渡す）
                CT_SERVICECODE,                  // 本メソッドにて作成したサービスコードを渡す
                logFileName,                     // 本メソッドにて作成したログファイル名称を渡す（"Client"+DateTimeのTicks+Guid文字列）
                String.Format("[{0}] {1}",
                  pgId,                          // 呼び元から渡されたPGID
                  outputMessage                  // 呼び元から渡された出力メッセージ(Exception内容が存在する場合は、Exception内容も出力)
                ));

            // 正常に出力できた場合のみログファイル名称を返す
            if (st == ST_NOMAL)
                return logFileName;
            else
                return string.Empty;
        }

        /// <summary>
        /// ファイル保存処理
        /// </summary>
        /// <param name="fileFullPath">コピー元ファイルのフルパス</param>
        /// <returns>ステータス([0:成功, 4:コピー元ファイルが存在しない, 9:コピー失敗, -1:例外エラー)</returns>
        public int CopyClcLogFile(string fileFullPath)
        {
            // CLCログ出力フォルダ(最後のフォルダはサービス名とする)
            const string OUTPUT_CLCLOGFOLDER = "Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string ClcServerLogOutPutFolder = null;

            try
            {
                // CLCログ出力フォルダ設定
                ClcServerLogOutPutFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), // %ALLUSERSPROFILE%の下に作成
                    OUTPUT_CLCLOGFOLDER                                                         // CLCログ出力用ディレクトリ
                    );
            }
            catch (ArgumentException)
            {
                // 例外エラー時
                return ST_COPYEXCEPTION;
            }
            catch (PlatformNotSupportedException)
            {
                // 例外エラー時
                return ST_COPYEXCEPTION;
            }

            string outPutLogFileName = string.Empty;   // 出力ログファイル名称（CLCログファイル出力部品使用時に使用）

            // コピー元ファイルの存在チェック
            // コピー元未指定は処理終了、コピー元ファイルが存在しない場合はエラーとする
            if (fileFullPath == null)
                return ST_NOMAL;
            else if (!File.Exists(fileFullPath))
                return ST_COPYFILENOTFOUND;

            // コピー先ファイルフルパス作成
            outPutLogFileName = Path.Combine(
                ClcServerLogOutPutFolder,          // 本メソッドにて作成したCLCServer用ディレクトリ
                Path.GetFileName(fileFullPath)     // 呼び元から渡されたコピー元ファイル名（フルパスからファイル名のみ取得）
                );

            try
            {
                // コピー先ディレクトリの存在チェック
                if (!Directory.Exists(ClcServerLogOutPutFolder))
                    Directory.CreateDirectory(ClcServerLogOutPutFolder);

                // コピー処理実行
                File.Copy(
                    fileFullPath,       // 呼び元から渡されたコピー元ファイル名（フルパスからファイル名のみ取得）
                    outPutLogFileName,  // 本メソッドにて作成したCLCLOG出力用パス
                    true
                    );
            }
            catch (UnauthorizedAccessException)
            {
                // 書込みエラー時
                return ST_COPYFAIL;
            }
            catch (Exception)
            {
                // 例外エラー時
                return ST_COPYEXCEPTION;
            }

            return ST_NOMAL;
        }
    }
}
