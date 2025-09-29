/// <summary>
/// デジタルデータ検索　ZIP管理ファイル理情報制御処理
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PMTAB00301C
{
    /// <summary>
    /// ZIP管理ファイル理情報制御処理
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : ZIP管理ファイル理情報を制御します。</br>
    /// </remarks>
    class PMTAB00301CE
    {

        #region << Private Member >>

        /// <summary>ファイル名称</summary>
        private static string FileName;

        /// <summary>ロガー</summary>
        PMTAB00301CC logger;

        #endregion

        #region << コンストラクタ >>
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : デフォルトのコンストラクタです</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        public PMTAB00301CE(string filename)
        {
            FileName = filename;
            logger = PMTAB00301CC.getInstance();
        }

        #endregion

        #region << public Method >>

        #region << ZIPファイル管理情報読込処理 >>
        /// <summary>
        /// ZIPファイル管理情報読込処理
        /// </summary>
        /// <returns>ZIPファイル管理情報</returns>
        /// <remarks>
        /// <br>Note        : ZIPファイル管理情報読込処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        public Dictionary<string, string> Read()
        {
            Dictionary<string, string> zipFileMngInfo = new Dictionary<string,string>();
            StreamReader reader = null;

            try {
                // ファイルが存在しない場合は、初回として正常終了
                if (!System.IO.File.Exists(FileName))
                {
                    return zipFileMngInfo;
                }

                reader = new StreamReader(FileName,System.Text.Encoding.UTF8);
                       
                // ファイルが終了するまで読込ループ
                while (reader.Peek() > 0)
                {
                    // １行読込
                    string lineBufer = reader.ReadLine();
                    char[] separater = {','};
                    string[] array = lineBufer.Split(separater, 2);
                    // array[0]：メーカーコード
                    // array[1]：更新日付
                    zipFileMngInfo.Add(array[0], array[1]);
                }

            }
            catch(IOException exp)
            {
                logger.WriteLog("ZIPファイル管理情報ファイルの読込に失敗しました。" + exp.Message);
                // SMTPメール送信
                PMTAB00301CA.SendSmtpMail("ZIPファイル管理情報ファイルの読込に失敗しました。", exp.Message);
                zipFileMngInfo = null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return zipFileMngInfo;
        }

        #endregion

        #region << ZIPファイル管理情報書込処理 >>
        /// <summary>
        /// ZIPファイル管理情報書込処理
        /// </summary>
        /// <param name="zipFileMngInfo">IPファイル管理情報</param>
        /// <returns>true:正常終了、false:異常終了</returns>
        /// <remarks>
        /// <br>Note        : ZIPファイル管理情報書込処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        public bool Write(Dictionary<string, string> zipFileMngInfo)
        {
            bool retFlag = false;
            StreamWriter writer = null;

            try
            {
                // キーで昇順にソート
                var sortedZipFileMngInfo = zipFileMngInfo.OrderBy((x) => x.Key);

                // ディレクトリが存在しない場合は、作成する。
                string dirName = Path.GetDirectoryName(FileName);
                if (dirName != null && !Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                // ZIPファイル管理情報ファイルを上書きモードでStreamオープン
                writer = new StreamWriter(FileName, false, System.Text.Encoding.UTF8);

                foreach (var entry in sortedZipFileMngInfo)
                {
                    // ZIPファイル管理情報から、メーカーコードと更新日を１行に編集
                    StringBuilder bs = new StringBuilder();
                    bs.Append(entry.Key);
                    bs.Append(",");
                    bs.Append(entry.Value);

                    // １行書込み
                    writer.WriteLine(bs.ToString());
                }
                retFlag = true;
            }
            catch (IOException exp)
            {
                logger.WriteLog("ZIPファイル管理情報ファイルの書込みに失敗しました。" + exp.Message);

                // SMTPメール送信
                PMTAB00301CA.SendSmtpMail("ZIPファイル管理情報書込処理", exp.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }


            return retFlag;

        }

        #endregion

        #endregion

    }
}
