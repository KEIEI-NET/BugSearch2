/// <sum
/// ry>
/// デジタルデータ検索　サムネイル画像取得Webアクセス
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
using System.Xml;
using Broadleaf.Application.Common;


namespace Broadleaf.Web
{
    /// <summary>
    /// PMTABサムネイル画像取得Webアクセス
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : PMTABサムネイル画像取得処理を行います。</br>
    /// </remarks>
    public partial class PMTAB04061A : System.Web.UI.Page
    {

        #region << Private Const >>

        // エラーメッセージ
        /// <summary>パラメータエラー（メーカーコード：null）</summary>
        private static string ErrMsgMakerCodeNull = "Error URLパラメータ（メーカーコード=null）";
        /// <summary>パラメータエラー（品番：null）</summary>
        private static string ErrMsgProductNoNull = "Error URLパラメータ（品番=null）";
        /// <summary>パラメータエラー（画像ID：null）</summary>
        private static string ErrMsgPictureIdNull = "Error URLパラメータ（画像ID=null）";
        /// <summary>設定XMLファイル名</summary>
        private const string ctXmlFileName = "PMTAB04061AUserSetting.XML";
        /// <summary>サムネイル画像の画像種別のデフォルト値（"S"）</summary>
        private const string ctThumbnailPictKindDefaultValue = "S";
        /// <summary>詳細画像の画像種別のデフォルト値（"L"）</summary>
        private const string ctDetailPictKindDefaultValue = "L";
        /// <summary>サムネイル画像の拡張子のデフォルト値（"jpg"）</summary>
        private const string ctThumbnailPrefixDefaultValue = "jpg";
        /// <summary>ログ出力モードの拡張子のデフォルト値（"jpg"）</summary>
        private const string ctLogOutModeDefaultValue = "false";
        /// <summary>アンダーバー</summary>
        private const string ctUnderBar = "_";
        /// <summary>ドット</summary>
        private const string ctDot = ".";
        /// <summary>パス接続用\\コード</summary>
        private const string ctWEne = "\\\\";
        /// <summary>パス接続用\コード</summary>
        private const string ctEne = "\\";

        #endregion

        #region << Private Member >>

        private PMTAB04061AC logger;
        
        #endregion

        #region << public Method >>

        #region << デフォルトコンストラクタ >>
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public PMTAB04061A()
        {
            logger = PMTAB04061AC.getInstance();
        }

        #endregion

        #region << Page_Loadイベント >>
        /// <summary>
        /// Page_Loadイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : Page_Loadイベント処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        protected void Page_Load(object sender, EventArgs e)
        {

            // 設定用XMLファイルから情報を取得
            PMTAB04061AB info = GetPmTab04061ASettingInfo();
            if (info == null)
            {
                return;
            }

            // ログ出力モード設定
            logger.SetLogOutMode(info.LogOutMode);

            // ファイル名
            string fileName = string.Empty;
            // メーカーコード
            string makerCode = string.Empty;
            // 品番
            string productNo = string.Empty;
            // 画像ID
            string pictureId = string.Empty;

            // URLパラメータチェック
            // メーカーコード
            if (String.IsNullOrEmpty(Request.QueryString["makerCode"]))
            {
                // パラメータエラー
                logger.WriteLog(ErrMsgMakerCodeNull);
                return;
            }
            makerCode = Request.QueryString["makerCode"];

            // 品番
            if (String.IsNullOrEmpty(Request.QueryString["productNo"]))
            {
                // パラメータエラー
                logger.WriteLog(ErrMsgProductNoNull);
                return;
            }
            productNo = Request.QueryString["productNo"];

            // 画像ID
            if (String.IsNullOrEmpty(Request.QueryString["pictureId"]))
            {
                // パラメータエラー
                logger.WriteLog(ErrMsgPictureIdNull);
                return;
            }
            pictureId = Request.QueryString["pictureId"];

            // サムネイル画像取得
            PMTAB04061AA pmtab04061aa = new PMTAB04061AA();
            System.Drawing.Image img = pmtab04061aa.GetThumbnailPicture(makerCode, productNo, pictureId, info);
            pmtab04061aa = null;
            if (img != null)
            {
                Response.ContentType = "image/jpeg";

                img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                Response.Flush();
            }

        }

        #endregion

        #endregion

        #region << private Method >>

        #region << XML設定情報取得処理 >>
        /// <summary>
        /// XML設定情報取得処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>XML設定情報(エラーの場合nullを返却します)</returns>
        /// <remarks>
        /// <br>Note        : 要求されたHTTPリクエストに対する処理を行います</br>
        /// <br>Programmer	: moriyama</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private PMTAB04061AB GetPmTab04061ASettingInfo()
        {

            /// <summary>サムネイル画像取得XML設定情報</summary
            PMTAB04061AB info = null;
            /// <summary>XMLドキュメント</summary
            XmlDocument xmlDoc = null;

            // XMLファイルフルパスを作成
            string pmXmlPath = Path.Combine(NSTabletWebEnv.GetPhysicalPath(NSTabletWebEnv.ClientWebServerFolder.AppData), ctXmlFileName);

            string errMsg = string.Empty;
            XmlNodeList infoList;

            try
            {
                // XMLファイル読み込み
                xmlDoc = new XmlDocument();
                xmlDoc.Load(pmXmlPath);
                infoList = xmlDoc.SelectNodes("UserSettingInfo");

                // nodeが存在しない場合、エラー（null）を返す
                if (infoList == null || infoList.Count <= 0)
                {
                    logger.WriteLog("XMLファイル読込エラー(" + pmXmlPath + ")");
                    return null;
                }

                info = new PMTAB04061AB();

                // ノード（UserSettingInfo）の数分ループ
                foreach (XmlNode infoNode in infoList)
                {
                    XmlNodeList childNodeList = infoNode.ChildNodes;

                    // UserSettingInfoの子ノードの数分ループ
                    foreach (XmlNode childNode in childNodeList)
                    {
                        // UserSettingInfoの子ノードのタグ名が空の場合、次ノードを処理する
                        if (string.IsNullOrEmpty(childNode.Name))
                        {
                            continue;
                        }
                        switch (childNode.Name)
                        {
                            case "SharedDrivePath":             // 共有ドライブのIPアドレス/サーバー名
                                {
                                    info.SharedDrivePath = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "SharedDriveDir":              // 共有ドライブのルートからのディレクトリ
                                {
                                    info.SharedDriveDir = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "UserName":                    // 共有ドライブのユーザID
                                {
                                    info.UserName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "PassWord":                    // 共有ドライブのパスワード
                                {
                                    info.PassWord = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "PicKindDertail":              // 詳細画像の画像種別
                                {
                                    info.PicKindDetail = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "PicKindThumbnail":            // サムネイル画像の画像種別
                                {
                                    info.PicKindThumbnail = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "LogOutMode":                  // ログ出力モード
                                {
                                    info.LogOutMode = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "ThumbnailPicturePrefix":      // サムネイル画像ファイルの拡張子
                                {
                                    info.ThumbnailPicturePrefix = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    break;
                }

                // 必須項目が未設定の場合、エラーを返す。
                if (String.IsNullOrEmpty(info.SharedDrivePath) ||
                    String.IsNullOrEmpty(info.SharedDriveDir) ||
                    String.IsNullOrEmpty(info.UserName) ||
                    String.IsNullOrEmpty(info.PassWord))
                {
                    StringBuilder msg = new StringBuilder();
                    msg.Append("設定ファイルに必須項目が存在しません。（");
                    msg.Append(String.IsNullOrEmpty(info.SharedDrivePath) ? " SharedDrivePath" : "");
                    msg.Append(String.IsNullOrEmpty(info.SharedDriveDir) ? " SharedDriveDir" : "");
                    msg.Append(String.IsNullOrEmpty(info.UserName) ? " UserName" : "");
                    msg.Append(String.IsNullOrEmpty(info.PassWord) ? " PassWord" : "");
                    msg.Append("）");
                    logger.WriteLog(msg.ToString());

                    return null;
                }

                // 未設定の場合、デフォルト値を設定する
                //  ログ出力モード
                if (String.IsNullOrEmpty(info.LogOutMode))
                {
                    info.LogOutMode = ctLogOutModeDefaultValue;
                }
                // サムネイル画像ファイルの画像種別
                if (String.IsNullOrEmpty(info.PicKindThumbnail))
                {
                    info.PicKindThumbnail = ctThumbnailPictKindDefaultValue;
                }
                // 詳細画像ファイルの画像種別
                if (String.IsNullOrEmpty(info.PicKindDetail))
                {
                    info.PicKindDetail = ctDetailPictKindDefaultValue;
                }
                // サムネイル画像の拡張子のデフォルト値
                if (String.IsNullOrEmpty(info.ThumbnailPicturePrefix))
                {
                    info.ThumbnailPicturePrefix = ctThumbnailPrefixDefaultValue;
                }

            }
            catch (Exception ex)
            {
                errMsg = "XMLファイル読込エラー(" + pmXmlPath + ")" + ex.Message;
                logger.WriteLog(errMsg);
                return null;
            }
            finally
            {
                if (xmlDoc != null)
                {
                    xmlDoc = null;
                }
            }

            infoList = null;
            xmlDoc = null;

            return info;
        }

        #endregion

        #endregion
    }
}