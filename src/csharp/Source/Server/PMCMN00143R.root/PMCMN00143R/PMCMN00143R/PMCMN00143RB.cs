//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新メンテナンス
// プログラム概要   : コンバート対象自動更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 小原
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.Security.Cryptography;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象自動更新前バックアップ
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新前のバックアップを行うクラスです。</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjBackupDB
    {

        #region 列挙体

        /// <summary>
        /// コンバート対象自動更新の結果ステータス列挙体
        /// </summary>
        private enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>成功（コンバートなし）</summary>
            NormalNotFound = 4
          , /// <summary>価格マスタ取得</summary>
            MstGet = 2000
          , /// <summary>DataTable展開</summary>
            DataTableDeploy = 2010
          , /// <summary>DataTable変換</summary>
            DataTableConv = 2020
          , /// <summary>一時テーブル作成</summary>
            TempTableCreate = 2030
          , /// <summary>一時テーブル登録</summary>
            TempTableIns = 2040
          , /// <summary>マスタ更新</summary>
            MstUpd = 2050
          , /// <summary>バージョン管理マスタ更新</summary>
            VerObjMstUpd = 2100
          , /// <summary>例外エラー(3000)</summary>
            Error3000 = 3000
          , /// <summary>例外エラー(3001)</summary>
            Error3001 = 3001
          , /// <summary>例外エラー(3002)</summary>
            Error3002 = 3002
          , /// <summary>例外エラー(3003)</summary>
            Error3003 = 3003
          , /// <summary>例外エラー(3004)</summary>
            Error3004 = 3004
        };

        #endregion //列挙体

        #region 定数

        /// <summary>
        /// コンバート対象自動更新処理で例外が発生しました。
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "コンバート対象自動更新処理で例外が発生しました。";

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_Setting.xml";

        /// <summary>
        /// タイムアウト初期値（秒）
        /// </summary>
        private const int TIMEOUT_DEFAULT_TIME = 1800;

        /// <summary>
        /// バックアップフォルダパス
        /// </summary>
        private const string BACKUP_PATH = @"Log\BACKUP";

        /// <summary>
        /// バックアップファイル名
        /// </summary>
        private const string ZIP_FILE_NAME = "ConvObjBackup";

        /// <summary>
        /// USER_APレジストリキー　ルート
        /// </summary>
        private const string RegistryKeyUSER_APMain = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// USER_APレジストリキー　作業パス
        /// </summary>
        private const string RegistryKeyUSER_APInstallDirectory = "InstallDirectory";

        /// <summary>
        /// 作業パスデフォルト
        /// </summary>
        private const string WorkingDirDefault = @"C:\Program Files\Partsman\USER_AP";

        #endregion //定数

        #region プライベートフィールド

        /// <summary>
        /// パラメータ
        /// </summary>
        private ConvObjDBParam codbp = null;

        /// <summary>
        /// CLCログ出力
        /// </summary>
        private ConvObjCLCLogDB coclcldb = null;

        /// <summary>
        /// ファイル名用現在日時
        /// </summary>
        private string nowDateTime;

        /// <summary>
        /// 作業ディレクトリ
        /// </summary>
        private string workDir;

        /// <summary>
        /// バックアップファイル作成用Stream
        /// </summary>
        StreamWriter fs = null;

        /// <summary>
        /// 処理行数
        /// </summary>
        int procRowCnt;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象自動更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjBackupDB()
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;
            try
            {
                // パラメータ
                codbp = new ConvObjDBParam();

                // CLCログ出力
                coclcldb = new ConvObjCLCLogDB();

                // 処理行数
                procRowCnt = 0;

                // ファイル名用現在時刻設定
                nowDateTime = DateTime.Now.Year.ToString("0000") +
                    DateTime.Now.Month.ToString("00") +
                    DateTime.Now.Day.ToString("00") +
                    DateTime.Now.Hour.ToString("00") +
                    DateTime.Now.Minute.ToString("00") +
                    DateTime.Now.Second.ToString("00");

                #region 作業ディレクトリ取得

                status = (int)ConvObjDBParam.StatusCode.BkGetDirectory;

                // レジストリキー取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(RegistryKeyUSER_APMain);

                // 作業ディレクトリ取得
                if (key == null) // あってはいけないケース
                {
                    workDir = WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    workDir = key.GetValue(RegistryKeyUSER_APInstallDirectory, WorkingDirDefault).ToString();
                }

                #endregion // 作業ディレクトリ取得

                #region バックアップファイル初期化
                // ファイル格納パス定義
                string fileDirectory = Path.Combine(workDir.TrimEnd('\\'), BACKUP_PATH);

                // フォルダが存在しない場合作成する
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                string filePath = Path.Combine(fileDirectory, ZIP_FILE_NAME + "_" + nowDateTime);

                status = (int)ConvObjDBParam.StatusCode.BkStream;

                // 書き込み型でStream生成
                fs = new StreamWriter(filePath, false);

                #endregion // バックアップファイル初期化

            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00143RB ConvObjBackupDB Exception", status.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
            }
        }
        #endregion //コンストラクタ

        #region ConvObjBackup
        /// <summary>
        /// コンバート対象自動更新前のバックアップを行います。
        /// </summary>
        /// <param name="mstData">バックアップデータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新前のバックアップを行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjBackup(DataRow mstData)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int procStatus = (int)ConvObjDBParam.StatusCode.Normal;
            int colCnt = 0;
            StringBuilder txtData = new StringBuilder();
            string encryptData = string.Empty;

            try
            {
                #region バックアップデータ文字列変換

                // バックアップデータをタブ区切りの文字列に変換

                procStatus = (int)ConvObjDBParam.StatusCode.BkConvStr;

                // バックアップデータをタブ区切りの文字列に変換
                colCnt = 0;

                foreach (object col in mstData.ItemArray)
                {
                    if (colCnt != 0)
                    {
                        // 2列目以降はタブ区切りで設定
                        txtData.Append('\t');
                    }

                    txtData.Append("\"");
                    txtData.Append(col.ToString());
                    txtData.Append("\"");

                    colCnt++;
                }
                procRowCnt++;

                #endregion // バックアップデータ文字列変換

                // テキストデータ暗号化
                procStatus = (int)ConvObjDBParam.StatusCode.BkEncrypt;

                encryptData = EncryptionEntry(txtData.ToString());

                // メモリ確保のため変数初期化
                txtData = null;

                #region 書き込み処理

                // zipファイル書き込み
                procStatus = (int)ConvObjDBParam.StatusCode.BkWrite;
                fs.WriteLine(encryptData);

                // メモリ確保のため変数初期化
                encryptData = null;

                #endregion // 書き込み処理

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch(Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},procStatus:{1},procRowCnt:{2},ex:{3}", "ERR PMCMN00143RB ConvObjBackup Exception", procStatus.ToString(), procRowCnt.ToString(), ex.Message));
                throw ex;
            }

            return status;
        }

        #endregion // ConvObjBackup

        #region private メソッド

        #region データ暗号化

        /// <summary>
        /// データ暗号化
        /// </summary>
        /// <param name="source">暗号化対象データ</param>
        /// <remarks>
        /// <br>Note       : 文字列の暗号化を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private string EncryptionEntry(string source)
        {
            byte[] encrypted = null;
            string retStr = string.Empty;

            try
            {

                // AES暗号化オブジェクトを生成します
                using (RijndaelManaged rijndael = new RijndaelManaged())
                {
                    // 初期化ベクトル、暗号化鍵定義

                    rijndael.IV = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_IV);
                    rijndael.Key = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_Key);

                    // 暗号化オブジェクト生成
                    ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                    // Stream操作で文字列から暗号化後のByte配列を生成
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                // CryptoStream用のStreamWriterでStreamに書き込み
                                swEncrypt.Write(source);
                            }

                            // string文字列が書き込まれたStreamからMemoryStreamによるByte配列を生成
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                
                retStr = Convert.ToBase64String(encrypted);
            }
            catch(Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RB EncryptionEntry Exception", ex.Message));
                throw ex;
            }

            return retStr;
        }

        #endregion // データ暗号化

        #region CLCログ出力
        /// <summary>
        /// CLCログ出力実体
        /// </summary>
        /// <param name="message">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            if (codbp.ClcLogOutputInfo == (int)ConvObjDBParam.OutputCode.ON)
            {
                try
                {
                    // CLCログ出力
                    coclcldb.ClcLogOutput(message);
                }
                catch
                {
                }
                finally
                {
                }
            }
        }
        #endregion  // CLCログ出力

        #endregion // privateメソッド

        #region Dispose
        /// <summary>
        /// 解放処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 解放処理</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public void Dispose()
        {
            try
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RB Dispose Exception", ex.Message));
                throw ex;
            }
            finally
            {
            }
        }
        #endregion // Dispose
    }


}
