/// <summary>
/// デジタルデータ検索　サムネイル画像取得HTTPハンドラ
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;
using System.IO;
using System.Drawing;
using System.Text;


namespace Broadleaf.Web
{
    /// <summary>
    /// PMTABサムネイル画像取得処理
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : PMTABサムネイル画像取得処理を制御します。</br>
    /// </remarks>
    public class PMTAB04061AA
    {
        #region << Private Const >>

        /// <summary>共有ドライブ接続失敗</summary>
        private static string ErrMsgSharedDriveConnect = "共有ドライブの接続に失敗しました。";

        /// <summary>アンダーバー</summary>
        private const string ctUnderBar = "_";
        /// <summary>ドット</summary>
        private const string ctDot = ".";
        /// <summary>パス接続用\\コード</summary>
        private const string ctWEne = "\\\\";
        /// <summary>パス接続用\コード</summary>
        private const string ctEne = "\\";

        /// <summary>サムネイル画像</summary>
        private const string ctJSPara_ThumbnailPicture = "ThumbnailPicture";

        #endregion

        #region << Private Member >>

        // ロガー 
        private PMTAB04061AC logger = PMTAB04061AC.getInstance();

        #endregion

        #region << public Method >>

        #region << サムネイル画像取得処理 >>
        /// <summary>
        /// サムネイル画像取得処理
        /// </summary>
        /// <param name="parameterValue">検索用パラメータ</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="productNo">品番</param>
        /// <param name="productId">画像ID</param>
        /// <returns>画像データ（base64Encoded）</returns>
        /// <remarks>
        /// <br>Note        : 要求されたHTTPリクエストに対する処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        public Bitmap GetThumbnailPicture(string makerCode, string productNo, string pictureId, PMTAB04061AB info)
        {
            logger.WriteLog("GetThumbnailPicture start");

            // ファイル名
            string fileName = string.Empty;

            // 共有先に接続
            PMTAB04061AD sharedFolder = new PMTAB04061AD(
                ctWEne + info.SharedDrivePath, info.UserName, info.PassWord);

            int ret = sharedFolder.Connect();
            if (ret < 0)
            {
                // 共有ドライブ接続エラー
                logger.WriteLog(ErrMsgSharedDriveConnect);
                return null;
            }

            // 共有ドライブの完全ファイルパスを作成
            String filename = CreateFileName(info.SharedDrivePath,
                info.SharedDriveDir,
                makerCode,
                productNo,
                pictureId,
                info.PicKindThumbnail,
                info.ThumbnailPicturePrefix);

            Bitmap newImg;

            // 画像ファイルからイメージを取得
            try
            {
                using (FileStream fs = new System.IO.FileStream(
                                    filename,
                                    System.IO.FileMode.Open,
                                    System.IO.FileAccess.Read))
                {
                    using (System.Drawing.Image imgTmp = System.Drawing.Bitmap.FromStream(fs))
                    {
                        newImg = new Bitmap(imgTmp);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ネットワークパスが見つかりません。" ||
                    ex.Message.EndsWith("の一部が見つかりませんでした。") ||
                    ex.Message.EndsWith("が見つかりませんでした。"))
                {
                    // ファイルなし：正常終了
                    logger.WriteLog("画像ファイルなし（" + filename + ")" + ex.Message);
                    return null;
                }
                logger.WriteLog("画像ファイル取得失敗（" + filename + ")" + ex.Message);
                return null;
            }

            // 共有ドライブ切断
            sharedFolder.DisConnect();

            sharedFolder = null;

            logger.WriteLog("GetThumbnailPictureHTTPHandler end");
            return (Bitmap)newImg;
        }

        #endregion

        #region << ファイル名作成処理 >>
        /// <summary>
        /// ファイル名作成処理
        /// </summary>
        /// <param name="connectPath">パス</param>
        /// <param name="dir">ディレクトリ</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="productNo">品番</param>
        /// <param name="pictureId">画像ID</param>
        /// <param name="number">番号</param>
        /// <param name="pictKind">画像種別</param>
        /// <param name="prefix">拡張子</param>
        /// <returns>ファイル名</returns>
        /// <remarks>
        /// <br>Note        : 要求されたHTTPリクエストに対する処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private string CreateFileName(string path, string dir, string makerCode, string productNo, string pictureId, string pictKind, string prefix)
        {
            StringBuilder fileNamePath = new StringBuilder();
            
            fileNamePath.Append(ctWEne);        // "\\"
            fileNamePath.Append(path);          // IPアドレス・サーバー名
            fileNamePath.Append(ctEne);         // "\"
            fileNamePath.Append(dir);           // ルートからのディレクトリ
            fileNamePath.Append(ctEne);         // "\"
            fileNamePath.Append(makerCode);     // メーカーコード（ディレクトリ）
            fileNamePath.Append(ctEne);         // "\"
            fileNamePath.Append(productNo);     // 品番（ディレクトリ）
            fileNamePath.Append(ctEne);         // "\"
            fileNamePath.Append(makerCode);     // メーカーコード
            fileNamePath.Append(ctUnderBar);    // "_"
            fileNamePath.Append(productNo);     // 品番
            fileNamePath.Append(ctUnderBar);    // "_"
            fileNamePath.Append(pictureId);     // 画像ID
            fileNamePath.Append(ctUnderBar);    // "_"
            fileNamePath.Append(pictKind);      // 画像種別
            fileNamePath.Append(ctDot);         // "."
            fileNamePath.Append(prefix);        // 拡張子

            string fileName = fileNamePath.ToString();
            fileNamePath = null;
            return fileName;
        }

        #endregion

        #endregion
    }

}