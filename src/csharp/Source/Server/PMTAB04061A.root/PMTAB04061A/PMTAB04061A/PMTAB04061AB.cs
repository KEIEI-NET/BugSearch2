/// <summary>
/// デジタルデータ検索　サムネイル画像取得設定情報
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;

namespace Broadleaf.Web
{
    /// public class name:   PmTopMenuMng
    /// <summary>
    ///                      サムネイル画像取得設定情報クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   サムネイル画像取得設定情報クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/10/20</br>
    /// <br>Genarated Date   :   2017/10/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class PMTAB04061AB
    {
        #region << Private Const >>

        /// <summary>共有ドライブパス</summary>
        private string sharedDrivePath = "";

        /// <summary>共有ドライブディレクトリ</summary>
        private string sharedDriveDir = "";

        /// <summary>共有ドライブ接続ユーザ名</summary>
        private string userName = "";

        /// <summary>共有ドライブ接続パスワード</summary>
        private string passWord = "";

        /// <summary>画像種別（サムネイル）</summary>
        private string picKindThumbnail = "";

        /// <summary>画像種別（詳細）</summary>
        private string picKindDetail = "";

        /// <summary>ログ出力モード</summary>
        private string logOutMode = "";

        /// <summary>サムネイル画像ファイルの拡張子</summary>
        private string thumbnailPicturePrefix;

        #endregion


        /// public propaty name  :  SharedDrivePath
        /// <summary>共有ドライブパスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共有ドライブパスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SharedDrivePath
        {
            get { return sharedDrivePath; }
            set { sharedDrivePath = value; }
        }

        /// public propaty name  :  SharedDriveDir
        /// <summary>共有ドライブディレクトリプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共有ドライブディレクトリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SharedDriveDir
        {
            get { return sharedDriveDir; }
            set { sharedDriveDir = value; }
        }

        /// public propaty name  :  UserName
        /// <summary>共有ドライブ接続ユーザ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共有ドライブ接続ユーザ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// public propaty name  :  PassWord
        /// <summary>共有ドライブ接続パスワードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共有ドライブ接続パスワードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        /// public propaty name  :  PicKindThumbnail
        /// <summary>画像種別（サムネイル）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像種別（サムネイル）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PicKindThumbnail
        {
            get { return picKindThumbnail; }
            set { picKindThumbnail = value; }
        }

        /// public propaty name  :  PicKindDetail
        /// <summary>画像種別（詳細）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像種別（詳細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PicKindDetail
        {
            get { return picKindDetail; }
            set { picKindDetail = value; }
        }

        /// public propaty name  :  LogOutMode
        /// <summary>ログ出力モードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログ出力モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LogOutMode
        {
            get { return logOutMode; }
            set { logOutMode = value; }
        }

        /// public propaty name  :  ThumbnailPicturePrefix
        /// <summary>サムネイル画像拡張子プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サムネイル画像拡張子プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ThumbnailPicturePrefix
        {
            get { return thumbnailPicturePrefix; }
            set { thumbnailPicturePrefix = value; }
        }

    }
}