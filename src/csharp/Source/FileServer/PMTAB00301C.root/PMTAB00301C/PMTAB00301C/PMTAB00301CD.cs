/// <summary>
/// デジタルデータ検索　サムネイル画像取得設定情報
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;

namespace PMTAB00301C
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
    public class PMTAB00301CD
    {
        #region << Private Const >>

        /// <summary>認証ファイル名称</summary>
        private string certificateFileName = "";

        /// <summary>認証ファイルディレクトリ</summary>
        private string certificateFileDir = "";

        /// <summary>CloudStrageのバケット名称</summary>
        private string bucketName = "";

        /// <summary>バケットの下のサブフォルダ</summary>
        private string bucketSubFolder = "";

        /// <summary>サービスアカウント名</summary>
        private string serviceAccountEmail = "";

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

        /// <summary>オンプレマシンのテンポラリディレクトリ</summary>
        private string tempDir;

        /// <summary>ZIPファイル管理情報ファイル名称</summary>
        private string zipFileMngFileName;

        /// <summary>SMTPサーバー名称</summary>
        private string smtpServerName;

        /// <summary>SMTP送信先</summary>
        private string smtpSendTo;

        /// <summary>SMTP送信元</summary>
        private string smtpFromTo;

        /// <summary>SMTPポート番号</summary>
        private string smtpPortNo;

        /// <summary>タイムアウト値</summary>
        private string timeOutValue;

        #endregion

        /// public propaty name  :  CertificateFileName
        /// <summary>認証ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   認証ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CertificateFileName
        {
            get { return certificateFileName; }
            set { certificateFileName = value; }
        }

        /// public propaty name  :  CertificateFileDir
        /// <summary>認証ファイルディレクトリプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   認証ファイルディレクトリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CertificateFileDir
        {
            get { return certificateFileDir; }
            set { certificateFileDir = value; }
        }

        /// public propaty name  :  BucketName
        /// <summary>CloudStrageのバケット名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CloudStrageのバケット名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BucketName
        {
            get { return bucketName; }
            set { bucketName = value; }
        }

        /// public propaty name  :  BucketSubFolder
        /// <summary>バケットの下のサブフォルダプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バケットの下のサブフォルダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BucketSubFolder
        {
            get { return bucketSubFolder; }
            set { bucketSubFolder = value; }
        }

        /// public propaty name  :  ServiceAccountEmail
        /// <summary>サービスアカウント名</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  サービスアカウント名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ServiceAccountEmail
        {
            get { return serviceAccountEmail; }
            set { serviceAccountEmail = value; }
        }

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

        /// public propaty name  :  TempDir
        /// <summary>オンプレマシンのテンポラリディレクトリ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンプレマシンのテンポラリディレクトリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TempDir
        {
            get { return tempDir; }
            set { tempDir = value; }
        }

        /// public propaty name  :  ZipFileMngFileName
        /// <summary>ZIPファイル管理情報ファイル名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ZIPファイル管理情報ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ZipFileMngFileName
        {
            get { return zipFileMngFileName; }
            set { zipFileMngFileName = value; }
        }

        /// public propaty name  :  SmtpServerName
        /// <summary>SMTPサーバー名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTPサーバー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SmtpServerName
        {
            get { return smtpServerName; }
            set { smtpServerName = value; }
        }

        /// public propaty name  :  SmtpSendTo
        /// <summary>SMTP送信先</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP送信先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SmtpSendTo
        {
            get { return smtpSendTo; }
            set { smtpSendTo = value; }
        }

        /// public propaty name  :  SmtpFromTo
        /// <summary>SMTP送信元</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP送信元プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SmtpFromTo
        {
            get { return smtpFromTo; }
            set { smtpFromTo = value; }
        }

        /// public propaty name  :  SmtpPortNo
        /// <summary>SMTPポート番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTPポート番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SmtpPortNo
        {
            get { return smtpPortNo; }
            set { smtpPortNo = value; }
        }

        /// public propaty name  :  TimeOutValue
        /// <summary>タイムアウト値</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   タイムアウト値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TimeOutValue
        {
            get { return timeOutValue; }
            set { timeOutValue = value; }
        }

    }
}