/// <summary>
/// デジタルデータ検索　夜間バッチ
/// </summary>
/// <remarks>
/// <br>Programmer : moriyama</br>
/// <br>Date       : 2017.10.16</br>
/// <br>Note       : /br>
/// </remarks>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml;
using Google.Api.Gax;
using Google.Api.Gax.Rest;
using Google.Apis;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Storage.v1;
using Google.Apis.Services;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2.Flows;

namespace PMTAB00301C
{
    /// <summary>
    /// 夜間バッチ処理
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : moriyama</br>
    /// <br>Date        : 2017.10.16</br>
    /// <br>Note        : 夜間バッチ処理を制御します。</br>
    /// </remarks>
    class PMTAB00301CA
    {

        #region << Private Const >>

        /// <summary>設定XMLファイル名</summary>
        private const string ctXmlFileName = "PMTAB00301CUserSetting.xml";
        /// <summary>サムネイル画像の画像種別のデフォルト値（"S"）</summary>
        private const string ctThumbnailPictKindDefaultValue = "S";
        /// <summary>詳細画像の画像種別のデフォルト値（"L"）</summary>
        private const string ctDetailPictKindDefaultValue = "L";
        /// <summary>ログ出力モードの拡張子のデフォルト値（"jpg"）</summary>
        private const string ctLogOutModeDefaultValue = "false";
        /// <summary>サムネイル画像の拡張子のデフォルト値（"jpg"）</summary>
        private const string ctThumbnailPrefixDefaultValue = "jpg";
        /// <summary>ZIPファイルの拡張子（"zip"）</summary>
        private const string ctZipFileExtention = "zip";
        /// <summary>ZIPファイル管理情報ファイル名称のデフォルト値</summary>
        private const string ctZipFileMngFNameDefaultValue = "ZipFileMng.txt";
        /// <summary>パス接続用\\コード</summary>
        private const string ctWEne = "\\\\";
        /// <summary>パス接続用\コード</summary>
        private const string ctEne = "\\";
        /// <summary>スラッシュ</summary>
        private const string ctSlash = "/";
        /// <summary>アンダーバー</summary>
        private const string UnderBar = "_";
        private const char CharUnderBar = '_';
        /// <summary>プログラム名称</summary>
        private const string ApplicationName = "PMTAB00301C";
        /// <summary>日付時刻書式</summary>
        private const string DateTimeFormat = "yyyyMMddHHmmss";

        #endregion

        #region << Private Member >>

        /// <summary>ロガー</summary>
        PMTAB00301CC logger;
        /// <summary>カレントディレクトリ</summary>
        private string CurrentDir;

        /// <summary>タイマー</summary>
        private static System.Threading.Timer timer;
        /// <summary>タイマー動作用カウンタ（必ず一回はタイムアウトするので2回目にタイムアウト判定するため）</summary>
        private static int timeoutCount = 0;
        /// <summary>タイムアウトフラグ</summary>
        private static bool timeoutFlag = false;
        /// <summary>タイマー監視用処理名称</summary>
        private static string processName = "Start";
        /// <summary>タイマー監視用カウンタ</summary>
        private static int processCount = 0;

        /// <summary>XML設定ファイル情報</summary>
        private static PMTAB00301CD info = null;

        // ファイル名誤りメーカーコードリスト
        private static ArrayList errMakeCodeList = null;


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
        public PMTAB00301CA()
        {
            logger = PMTAB00301CC.getInstance();

            // カレントディレクトリを取得
            CurrentDir = System.IO.Directory.GetCurrentDirectory();
        }

        #endregion

        #region << public Method >>

        #region << 夜間バッチメイン処理 >>
        /// <summary>
        /// 夜間バッチメイン処理
        /// </summary>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : 夜間バッチメイン処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        public void BatchMain()
        {
            try
            {

                // 設定ファイルを読込
                info = GetPmTab00301CSettingInfo();
                if (info == null)
                {
                    return;
                }
                // ログ出力モード設定
                logger.SetLogOutMode(info.LogOutMode);

                // ログファイル削除処理
                logger.DeleteLogFile();

                // タイマーの生成
                timer = new Timer(new TimerCallback(TimeOutProcess));
                timer.Change(0L, long.Parse(info.TimeOutValue));

                PMTAB00301CE zipFileMng = new PMTAB00301CE(info.ZipFileMngFileName);

                // ZIPファイル管理情報ファイル読込
                Dictionary<string, string> zipFileMngInfo = zipFileMng.Read();
                if (zipFileMngInfo == null)
                {
                    return;
                }

                // テンポラリフォルダを作成
                Directory.CreateDirectory(info.TempDir);

                // CloudStrageから、ZIPファイルをダウンロードする。
                ArrayList zipFileList = DownLoadCloudStrage(info, zipFileMngInfo);
                // ZIPファイルがなければ処理終了
                if (zipFileList == null || zipFileList.Count == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    return;
                }

                // ZIPファイルを展開する。
                ArrayList makerCodeList = UnCompressAndMove(info, zipFileList);
                // ZIPファイル展開エラーで処理終了
                if (makerCodeList == null)
                {
                    System.Threading.Thread.Sleep(1000);
                    return;
                }

                // 共有ドライブのパスが設定されている場合、共有ドライブにコピーする。
                // 共有ドライブのパスがm未設定の場合は、テンポラリディレクトリ＝オンプレマシンの画像フォルダ
                if (!String.IsNullOrEmpty(info.SharedDrivePath))
                {
                    // サムネイル画像ファイルをNASへコピーする
                    bool ret = FileCopyToNAS(info, makerCodeList);
                    // コピー成功の場合
                    if (ret) {
                        // テンポラリフォルダを全削除
                        DeleteTempFile(info, makerCodeList, true);
                    }
                    else
                    {
                        // ZIPファイルのみ削除
                        DeleteTempFile(info, makerCodeList, false);
                        return;
                    }
                }
                else
                {
                    // ZIPファイルのみ削除
                    DeleteTempFile(info, makerCodeList, false);
                }
                // ZIPファイル管理情報ファイル書込み
                zipFileMng.Write(zipFileMngInfo);



            }
            catch(Exception exp)
            {
                string msg1 = "夜間バッチメイン処理でエラーが発生しました。";
                string errMsg = msg1 + exp.Message;
                logger.WriteLog(errMsg);

                // SMTPメール送信
                SendSmtpMail(msg1, exp.Message);
                System.Threading.Thread.Sleep(1000);
            }

        }

        #endregion

        #endregion

        #region << private Method >>

        #region << ZIPファイルダウンロード処理 >>
        /// <summary>
        /// ZIPファイルダウンロード処理
        /// </summary>
        /// <param name="settingInfo">設定ファイル情報</param>
        /// <param name="zipFileMngInfo">ZIPファイル管理情報</param>
        /// <returns>ZIPファイル名リスト</returns>
        /// <remarks>
        /// <br>Note        : ZIPファイルをダウンロードする処理を行います。</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private ArrayList DownLoadCloudStrage(PMTAB00301CD settingInfo, Dictionary<string, string> zipFileMngInfo)
        {

            StorageService downlodService = null;

            // タイムアウト監視用変数初期化
            processName = "ZIPファイルダウンロード処理";
            processCount = 0;

            // ZIPファイルリスト
            ArrayList zipFileList = null;

            // ダウンロードファイル名
            string fileName = "";

            try
            {
                // 認証開始
                GoogleCredential credential;
                using (var stream = new FileStream(settingInfo.CertificateFileName, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(StorageService.Scope.DevstorageFullControl);
                }

                // ダウンロードサービスを取得
                downlodService = new StorageService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });

                // ダウンローダーを取得
                var downloader = new MediaDownloader(downlodService);

                // ファイルリストサービスを取得
                StorageClient storageClient = StorageClient.Create(credential);

                // バケット名、サブフォルダ以下のオブジェクトリストを取得
                var cloudFileList = storageClient.ListObjects(settingInfo.BucketName, settingInfo.BucketSubFolder).ToList();

                zipFileList = new ArrayList();

                // ファイルリスト分ループする
                foreach (var cloudFileInfo in cloudFileList)
                {
                    // CloudStrage上のファイル名
                    fileName = Path.GetFileName(cloudFileInfo.Name);

                    string fName = Path.GetFileNameWithoutExtension(cloudFileInfo.Name);
                    string[] array = fName.Split(CharUnderBar);
                    string makerCode = array[0];

                    // 拡張子
                    string suffix = Path.GetExtension(cloudFileInfo.Name);

                    // ディレクトリの場合次のリストを処理
                    if (suffix == null || suffix.Length == 0)
                    {
                        continue;
                    }

                    // ファイル名チェック開始
                    // 画像種別のチェック（"S"又は"s"）
                    if (array.Length != 2 || array[1].ToLower() != info.PicKindThumbnail.ToLower())
                    {
                        logger.WriteLog("ZIPファイル名に誤りがあります。（" + fileName + "）");
                        continue;
                    }

                    // 拡張子チェック（.zip）
                    if (suffix.Replace(".", "") != ctZipFileExtention)
                    {
                        logger.WriteLog("ZIPファイル名に誤りがあります。（" + fileName + "）");
                        continue;
                    }
                    // メーカーコードチェックチェック（数値、4桁）
                    if (makerCode.Length != 4 ||
                        !System.Text.RegularExpressions.Regex.IsMatch(makerCode, @"[0-9]{4}"))
                    {
                        logger.WriteLog("ZIPファイル名に誤りがあります。（" + fileName + "）");
                        continue;
                    }

                    // 更新日付
                    DateTime cloudFileCreateDate = (DateTime)cloudFileInfo.TimeCreated;
                    // ミリ秒をクリアする
                    string dateTime = cloudFileCreateDate.ToString(DateTimeFormat);
                    cloudFileCreateDate = DateTime.ParseExact(dateTime, DateTimeFormat, null);

                    // ZIPファイル管理情報から、更新日付を取得
                    // ZIPファイル管理情報に情報が存在しない場合は、ダウンロードを実行
                    if (zipFileMngInfo.ContainsKey(makerCode))
                    {
                        // Cloudにあるファイルの作成日付がZIPファイル管理情報の更新日付より大きい場合、ダウンロードする
                        DateTime dlFileDateTime = DateTime.ParseExact(zipFileMngInfo[makerCode], DateTimeFormat, null);
                        if (dlFileDateTime >= cloudFileCreateDate)
                        {
                            continue;
                        }
                    }

                    // ダウンロード要求を作成
                    var req = downlodService.Objects.Get(settingInfo.BucketName, cloudFileInfo.Name);

                    // ダウンロード要求を実行
                    Google.Apis.Storage.v1.Data.Object readobj = req.Execute();

                    // ダウンロード先のフルパスを作成
                    var tempFileName = Path.Combine(settingInfo.TempDir, fileName);

                    // ダウンロード先のファイルをStreamオープン
                    using (var filestream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write))
                    {
                        // ダウンロード実行
                        downloader.Download(readobj.MediaLink, filestream);

                        zipFileList.Add(tempFileName);

                    }

                    // ZIPファイル管理情報の更新日付を更新
                    if (zipFileMngInfo.ContainsKey(makerCode))
                    {
                        // メーカーコードがZIPファイル管理情報に存在する場合、
                        // 該当メーカーコードの値を更新する
                        zipFileMngInfo[makerCode] = cloudFileCreateDate.ToString(DateTimeFormat);
                    }
                    else
                    {
                        // メーカーコードがZIPファイル管理情報に存在しない場合、
                        // メーカーコード及び作成日付値をZIPファイル管理情報に追加する
                        zipFileMngInfo.Add(makerCode, cloudFileCreateDate.ToString(DateTimeFormat));
                    }
                    // タイムアウト監視用件数を＋1
                    processCount++;

                    // タイムアウトチェック
                    if (timeoutFlag)
                    {
                        zipFileList.Sort();
                        fileListLogOut("ダウンロードタイムアウト", processCount, zipFileList);
                        return null;
                    }
                }
                zipFileList.Sort();

                return zipFileList;
            }
            catch (Exception exp)
            {
                if (zipFileList != null)
                {
                    zipFileList.Sort();
                }
                fileListLogOut("ZIPファイルのダウンロードに失敗しました。（" + fileName + "）" + exp.Message,
                                processCount, zipFileList);

                // SMTPメール送信
                SendSmtpMail("ZIPファイルダウンロード処理でエラーが発生しました。", exp.Message);
            }
            return null;
        }

        #endregion

        #region << ZIPファイル展開処理 >>
        /// <summary>
        /// ZIPファイル展開処理
        /// </summary>
        /// <param name="info">設定ファイル情報</param>
        /// <param name="zipFileList">ZIPファイルリスト</param>
        /// <returns>メーカーコードリスト</returns>
        /// <remarks>
        /// <br>Note        : ZIPファイルを展開する処理を行います。</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private ArrayList UnCompressAndMove(PMTAB00301CD info, ArrayList zipFileList)
        {

            // メーカーコードリスト
            ArrayList makerCodeList = new ArrayList();

            // タイムアウト監視用変数初期化
            processName = "ZIPファイル展開処理";
            processCount = 0;

            // 展開済みファイルリスト
            ArrayList fileList = null;

            // 展開済みZIPファイルリスト
            ArrayList processZipFileList = new ArrayList();

            // ZIPファイルリストでループ
            foreach (String zipFilName in zipFileList)
            {
                // 処理済みファイルリスト
                fileList = new ArrayList();
                try
                {
                    // メーカーコードを取得
                    string makerCode = Path.GetFileNameWithoutExtension(zipFilName).Split(CharUnderBar)[0];

                    // メーカーコードのフォルダを作成
                    string makeCdDirName = Path.Combine(info.TempDir, makerCode);
                    Directory.CreateDirectory(makeCdDirName);

                    // ZIPファイルを開いてZipArchiveオブジェクトを作る
                    using (ZipArchive archive = ZipFile.OpenRead(zipFilName))
                    {
                        // 展開するファイルを選択する
                        ZipArchiveEntry[] allTextFiles = archive.Entries.OrderBy(e => e.FullName).ToArray();

                        // メーカーコード内で展開したファイル数

                        // 選択したファイルを指定したフォルダーに書き出す
                        foreach (ZipArchiveEntry entry in allTextFiles)
                        {

                            string fullName = entry.FullName;
                            // フォルダの場合、
                            if (fullName.EndsWith(ctSlash))
                            {
                                continue;
                            }
                            // エントリからファイル名を取得
                            string fileName = Path.GetFileName(entry.FullName);

                            // ファイル名のチェック
                            bool result = CheckThumbnailFileName(info, fileName);
                            if (!result)
                            {
                                // ファイル名エラー発生時、メーカーコードがリストになければ、メーカーコードをリストに追加
                                if (errMakeCodeList == null)
                                {
                                    errMakeCodeList = new ArrayList();
                                }
                                if (!errMakeCodeList.Contains(makerCode))
                                {
                                    errMakeCodeList.Add(makerCode);
                                }

                                logger.WriteLog("圧縮されたファイル名に誤りがあります。（メーカーコード:" + makerCode + "　ファイル名：" + fileName + "）");
                                continue;
                            }

                            // 品番を取得
                            int stPno = fileName.IndexOf(UnderBar) + 1;
                            int endPno = fileName.IndexOf(UnderBar, stPno);
                            string productNo = fileName.Substring(stPno, endPno - stPno);

                            try
                            {
                                // 品番のフォルダを作成
                                string productNoDir = Path.Combine(info.TempDir, makerCode, productNo);
                                Directory.CreateDirectory(productNoDir);

                                // 上書きフラグ
                                bool overWriteFlag = true;
                                // ZipArchiveEntryオブジェクトのExtractToFileメソッドにフルパスを渡す
                                entry.ExtractToFile(Path.Combine(info.TempDir, makerCode, productNo, fileName), overWriteFlag);

                                fileList.Add(fileName);

                                // タイムアウト監視用件数を＋1
                                processCount++;

                                // タイムアウトチェック
                                if (timeoutFlag)
                                {
                                    fileListLogOut("ZIPファイル展開処理でタイムアウト発生", processCount, fileList, processZipFileList);
                                    return null;
                                }
                            }
                            catch (IOException exp)
                            {
                                logger.WriteLog("ZIPファイル解凍エラー：" + exp.Message);
                                // エラー発生時、メーカーコードがリストになければ、メーカーコードをリストに追加
                                if (errMakeCodeList == null)
                                {
                                    errMakeCodeList = new ArrayList();
                                }
                                if (!errMakeCodeList.Contains(makerCode))
                                {
                                    errMakeCodeList.Add(makerCode);
                                }
                            }
                        }
                    }
                    makerCodeList.Add(makerCode);

                    // 正常終了したら、ZIPファイルを削除する
                    if (errMakeCodeList == null ||
                        !errMakeCodeList.Contains(makerCode))
                    {

                        ArrayList mCodeList = new ArrayList();
                        mCodeList.Add(makerCode);
                        DeleteTempFile(info, mCodeList, false);

                        // 処理したZIPファイルのリストに追加
                        processZipFileList.Add(zipFilName);
                    }
                }
                catch (Exception exp)
                {
                    fileListLogOut("ZIPファイルの展開に失敗しました。（" + zipFilName + "）" + exp.Message, processCount, fileList, processZipFileList);

                    // SMTPメール送信
                    SendSmtpMail("ZIPファイル展開処理でエラーが発生しました。", exp.Message);
                    return null;
                }
            }

            if (errMakeCodeList != null)
            {
                // SMTPメール送信
                SendSmtpMail("ZIPファイル展開処理でエラーが発生しました。", "ファイル名誤り");
            }

            return makerCodeList;

        }

        #endregion

        #region << ファイルコピー処理 >>
        /// <summary>
        /// ファイルコピー処理
        /// </summary>
        /// <param name="info">設定ファイル情報</param>
        /// <param name="makerCodeList">メーカーコードリスト</param>
        /// <returns>正常終了：true、異常終了：false</returns>
        /// <remarks>
        /// <br>Note        : サムネイル画像ファイルをコピーする処理を行います。</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private bool FileCopyToNAS(PMTAB00301CD info, ArrayList makerCodeList)
        {
            // 戻り値
            bool retValue = false;

            // タイムアウト監視用変数初期化
            processName = "ファイルコピー処理";
            processCount = 0;

            // 共有ドライブに接続する。
            PMTAB00301CB sharedFolder = new PMTAB00301CB(ctWEne + info.SharedDrivePath, info.UserName, info.PassWord);
            int ret = sharedFolder.Connect();
            if (ret != 0)
            {
                return retValue;
            }

            // コピー先ディレクトリ名
            string destDirName = ctWEne + info.SharedDrivePath + ctEne + info.SharedDriveDir;

            foreach (String makerCode in makerCodeList)
            {
                // コピー元メーカーコードディレクトリ
                string srcMakerCodeDirName = Path.Combine(info.TempDir, makerCode);
                try
                {
                    // メーカーコードディレクトリ（src）
                    DirectoryInfo makerCodeDirInfo = new DirectoryInfo(srcMakerCodeDirName);

                    // コピー先にメーカーコードディレクトリがなければ作成する
                    string distMakerCodeDirName = Path.Combine(destDirName, makerCode);
                    if (!Directory.Exists(distMakerCodeDirName))
                    {
                        Directory.CreateDirectory(distMakerCodeDirName);
                    }

                    // 品番のディレクトリでループ
                    foreach (DirectoryInfo productNoDirInfo in makerCodeDirInfo.GetDirectories())
                    {
                        // タイムアウトチェック
                        if (timeoutFlag)
                        {
                            return retValue;
                        }

                        // コピー先に品番ディレクトリがなければ作成する
                        string destProductNoDirName = Path.Combine(destDirName, makerCode, productNoDirInfo.Name);

                        if (!Directory.Exists(destProductNoDirName))
                        {
                            Directory.CreateDirectory(destProductNoDirName);
                        }

                        // ファイルでループ
                        foreach (FileInfo file in productNoDirInfo.GetFiles())
                        {
                            string destFileName = Path.Combine(destProductNoDirName, file.Name);
                            File.Copy(file.FullName, destFileName, true);

                            // タイムアウト監視用件数を＋1
                            processCount++;
                        }
                    }
                    retValue = true;

                }
                catch (IOException exp)
                {
                    fileListLogOut("ファイルのコピーに失敗しました。" + exp.Message, processCount, null);

                    // SMTPメール送信
                    SendSmtpMail("ファイルコピー処理でエラーが発生しました。", exp.Message);
                }
            }

            // 共有先切断
            sharedFolder.DisConnect();
            sharedFolder.Dispose();

            return retValue;
        }

        #endregion

        #region << テンポラリファイル削除処理 >>
        /// <summary>
        /// テンポラリファイル削除処理
        /// </summary>
        /// <param name="info">設定ファイル情報</param>
        /// <param name="makerCodeList">メーカーコードリスト</param>
        /// <param name="allDelFlag">全削除フラグ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : テンポラリファイル削除する処理を行います。</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private void DeleteTempFile(PMTAB00301CD info, ArrayList makerCodeList, bool allDelFlag)
        {

            // 展開時、ファイル名誤りがあった場合、そのメーカーコードのZIPファイルは削除しない
            if (errMakeCodeList != null)
            {
                foreach (string makerCode in errMakeCodeList)
                {
                    if (makerCodeList.Contains(makerCode))
                    {
                        makerCodeList.Remove(makerCode);
                    }
                }
            }
            
            foreach (String makerCode in makerCodeList)
            {
                string srcMakerCodeDirName = Path.Combine(info.TempDir, makerCode);

                // 全削除フラグが真の場合、メーカーコードディレクトリを削除
                if (allDelFlag)
                {
                    // メーカーコードディレクトリ削除
                    DirectoryInfo makerCodeDirInfo = new DirectoryInfo(srcMakerCodeDirName);
                    Directory.Delete(srcMakerCodeDirName, true);
                }

                string allZipFile = Path.Combine(info.TempDir, makerCode + UnderBar + info.PicKindThumbnail +"." + ctZipFileExtention);
                System.IO.File.Delete(allZipFile);
            }

        }

        #endregion

        #region << XML設定情報取得処理 >>
        /// <summary>
        /// XML設定情報取得処理
        /// </summary>
        /// <returns>XML設定情報(エラーの場合nullを返却します)</returns>
        /// <remarks>
        /// <br>Note        : XML設定情報を取得する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private PMTAB00301CD GetPmTab00301CSettingInfo()
        {

            /// <summary>サムネイル画像取得XML設定情報</summary
            /// <summary>XMLドキュメント</summary
            XmlDocument xmlDoc = null;

            // XMLファイルフルパスを作成
            string pmXmlPath = Path.Combine(CurrentDir, ctXmlFileName);

            string errMsg = string.Empty;

            try
            {
                // XMLファイル読み込み
                xmlDoc = new XmlDocument();
                xmlDoc.Load(pmXmlPath);
                XmlNodeList infoList = xmlDoc.SelectNodes("UserSettingInfo");

                // nodeが存在しない場合、エラー（null）を返す
                if (infoList == null || infoList.Count <= 0)
                {
                    logger.WriteLog("XMLファイル読込エラー(" + pmXmlPath + ")");
                    return null;
                }

                info = new PMTAB00301CD();

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

                            case "CertificateFileName":         // 認証ファイル名称
                                {
                                    info.CertificateFileName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "BucketName":                  // CloudStrageのバケット名称
                                {
                                    info.BucketName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "BucketSubFolder":             // バケットの下のサブフォルダ
                                {
                                    info.BucketSubFolder = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "ServiceAccountEmail":         // サービスアカウント名
                                {
                                    info.ServiceAccountEmail = childNode.InnerText ?? string.Empty;
                                    break;
                                }
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
                            case "TempDir":                     // ダウンロード・展開用テンポラリディレクトリ
                                {
                                    info.TempDir = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "ZipFileMngFileName":          // ZIPファイル管理情報ファイル名（フルパス）
                                {
                                    info.ZipFileMngFileName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "SmtpServerName":              // SMTPサーバー名称
                                {
                                    info.SmtpServerName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "SmtpSendTo":                  // SMTP送信先
                                {
                                    info.SmtpSendTo = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "SmtpFromTo":                  // SMTP送信元
                                {
                                    info.SmtpFromTo = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "SmtpPortNo":                  // SMTPポート番号
                                {
                                    info.SmtpPortNo = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case "TimeOutValue":                // タイムアウト値
                                {
                                    info.TimeOutValue = childNode.InnerText ?? string.Empty;
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
                // ZIPファイル管理情報ファイル名称
                if (String.IsNullOrEmpty(info.ZipFileMngFileName))
                {
                    info.ZipFileMngFileName = Path.Combine(CurrentDir , ctZipFileMngFNameDefaultValue);
                }

                // 必須項目が未設定の場合、エラーを返す。
                if (String.IsNullOrEmpty(info.CertificateFileName) ||   // 認証ファイル名称
                    String.IsNullOrEmpty(info.BucketName) ||            // CloudStrageのバケット名称
                    String.IsNullOrEmpty(info.BucketSubFolder) ||       // バケットの下のサブフォルダ
                    String.IsNullOrEmpty(info.ServiceAccountEmail) ||   // サービスアカウント名
                    String.IsNullOrEmpty(info.TempDir)                  // テンポラリディレクトリ
                    )
                {
                    StringBuilder msg = new StringBuilder();
                    msg.Append("設定ファイルに必須項目が存在しません。（");
                    msg.Append(String.IsNullOrEmpty(info.CertificateFileName) ? "CertificateFileName" : "");
                    msg.Append(String.IsNullOrEmpty(info.BucketName) ? " BucketName" : "");
                    msg.Append(String.IsNullOrEmpty(info.BucketSubFolder) ? " BucketSubFolder" : "");
                    msg.Append(String.IsNullOrEmpty(info.ServiceAccountEmail) ? " ServiceAccountEmail" : "");
                    msg.Append(String.IsNullOrEmpty(info.TempDir) ? " TempDir " : "");
                    msg.Append("）");
                    logger.WriteLog(msg.ToString(), true);
                    // SMTPメール送信
                    SendSmtpMail("XMLファイル読込処理でエラーが発生しました。", msg.ToString());
                    info = null;
                    return null;
                }
                
            }
            catch (Exception exp)
            {
                errMsg = "XMLファイル読込エラー(" + pmXmlPath + ")" + exp.Message;
                logger.WriteLog(errMsg, true);

                // SMTPメール送信
                SendSmtpMail("XMLファイル読込処理でエラーが発生しました。", exp.Message);

                return null;
            }
            finally
            {
                if (xmlDoc != null)
                {
                    xmlDoc = null;
                }
            }

            return info;
        }

        #endregion

        #region << サムネイルファイル名チェック処理 >>
        /// <summary>
        /// サムネイルファイル名チェック処理
        /// </summary>
        /// <param name="info">設定ファイル情報</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns>サムネイルファイル名をチェックします)</returns>
        /// <remarks>
        /// <br>Note        : サムネイルファイル名をチェックする処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private bool CheckThumbnailFileName(PMTAB00301CD info, string fileName)
        {
            string[] array = fileName.Split('_');
            if (array.Length != 4)
            {
                return false;
            }
            // メーカーコードは数値4桁
            if (array[0].Length != 4 ||
                !System.Text.RegularExpressions.Regex.IsMatch(array[0], @"[0-9]{4}$"))
            {
                return false;
            }
            // 品番は半角英数又は"-"
            if (!System.Text.RegularExpressions.Regex.IsMatch(array[1], @"[a-zA-Z0-9\-]+$"))
            {
                return false;
            }
            // 画像IDは数字（1～9）
            if (array[2].Length != 1 ||
                !System.Text.RegularExpressions.Regex.IsMatch(array[2], @"[1-9]"))
            {
                return false;
            }

            // 残りは、固定でS.jpg
            string[] array2 = array[3].Split('.');
            if (array2.Length != 2)
            {
                return false;
            }
            // 画像種別（S：サムネイル）固定
            if (array2[0].ToLower() != info.PicKindThumbnail.ToLower())
            {
                return false;
            }
            // 拡張子は"jpg"（大文字小文字）固定
            if (array2[1].ToLower() != info.ThumbnailPicturePrefix.ToLower())
            {
                return false;
            }

            return true;
        }

        #endregion


        #region << SMTPメール送信処理 >>
        /// <summary>
        /// SMTPメール送信処理
        /// </summary>
        /// <param name="errMessage1">エラーメッセージ1</param>
        /// <param name="errMessage2">エラーメッセージ2</param>
        /// <param name="timeOutFlag">タイムアウトフラグ（省略時：false）</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : SMTPメールを送信する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        public static void SendSmtpMail(string errMessage1, string errMessage2, bool timeOutFlag = false)
        {
            // 設定ファイルが読み込めない場合、SMTP送信送信不可
            if (info == null)
            {
                return;
            }
            if (String.IsNullOrEmpty(info.SmtpServerName))
            {
                return;
            }

            try
            {
                // SmtpClientオブジェクトを作成する
                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();

                //SMTPサーバーを指定する
                sc.Host = info.SmtpServerName;

                //ポート番号を指定する（既定値は25）
                sc.Port = int.Parse(info.SmtpPortNo);
            
                //SMTPサーバーに送信する設定にする（既定はNetwork）
                sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                //ユーザー名とパスワードを設定する
                sc.Credentials = new System.Net.NetworkCredential("", "");
            
                // 件名及び本文を作成
                string subject = "デジタルデータ夜間処理　エラー監視";
                string body;

                // タイムアウトフラグチェック
                if (timeOutFlag)
                {
                    body = "デジタルデータ夜間処理でタイムアウトが発生しました。";
                    body += Environment.NewLine;
                    body += errMessage1;
                    body += "（";
                    if (errMessage2 != null)
                    {
                        body += errMessage2;
                    }
                    body += "）";
                }
                else
                {
                    body = errMessage1;
                    body += Environment.NewLine;
                    body += "エラーメッセージ：";
                    if (errMessage2 != null)
                    {
                        body += errMessage2;
                    }
                    body += Environment.NewLine;
                }

                if (errMakeCodeList != null)
                {
                    foreach (string makerCode in errMakeCodeList)
                    {
                        body += "ファイル名誤り（メーカーコード：";
                        body += makerCode;
                        body += "）";
                        body += Environment.NewLine;
                    }
                }

                //メールを送信する
                sc.Send(info.SmtpFromTo, info.SmtpSendTo, subject, body);
                // メール送信完了まで待つ
                System.Threading.Thread.Sleep(1000);
                //後始末（.NET Framework 4.0以降）
                sc.Dispose();
            }
            catch (Exception exp)
            {
                // エラー発生後の例外は何もしない
            }
        }

        #endregion

        #region << タイムアウト監視処理（CallBack） >>
        /// <summary>
        /// タイムアウト監視処理（CallBack）
        /// </summary>
        /// <param name="info">設定ファイル情報</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : タイムアウトを監視する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        static void TimeOutProcess(object args)
        {
            if (timeoutCount > 0)
            {
                timeoutFlag = true;

                // タイマー停止
                timer.Dispose();

                // SMTPメール送信
                SendSmtpMail(processName, "処理件数：" + processCount + "件", true);
            }
            timeoutCount++;
        }

        #endregion


        #region << ファイルリストログ出力処理 >>
        /// <summary>
        /// タイムアウトログ出力処理（CallBack）
        /// </summary>
        /// <param name="msg">タイトルメッセージ</param>
        /// <param name="fileCnt">ファイル数</param>
        /// <param name="fileList">ファイル名リスト</param>
        /// <param name="zipFileList">ZIPファイル名リスト</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note        : タイムアウトを監視する処理を行います</br>
        /// <br>Programmer	: 森山　浩</br>
        /// <br>Date        : 2017.10.17</br>
        ///</remarks>
        private void fileListLogOut(string msg, long fileCnt, ArrayList fileList, ArrayList zipFileList = null)
        {
            logger.WriteLog(msg + "（ファイル数：" + fileCnt + "）");

            // 展開済みファイルがない場合
            if (fileList == null)
            {
                logger.WriteLog("処理したファイル:なし");
                return;
            }

            // ZIPファイル名リストがあれば、ZIPファイル名リストを表示する
            if (zipFileList != null)
            {
                foreach (String zipFileName in zipFileList)
                {
                    logger.WriteLog("処理したZIPファイル:" + zipFileName);
                }
            }
            
            // 展開済みファイルリストでループ
            foreach (String fName in fileList)
            {
                logger.WriteLog("展開済みファイル:" + fName);
            }
        }

        #endregion

        #endregion

    }
}
