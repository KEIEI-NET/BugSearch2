//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象バックアップメンテナンス
// プログラム概要   : コンバート対象バックアップを行う
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
    /// コンバート対象バックアップ前バックアップ
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バックアップ前のバックアップを行うクラスです。</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjBkCreateDB
    {

        #region 列挙体

        /// <summary>
        /// コンバート対象バックアップの結果ステータス列挙体
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
            MstBk = 2050
          , /// <summary>バージョン管理マスタ更新</summary>
            VerObjMstBk = 2100
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
        /// バックアップフォルダパス
        /// </summary>
        private const string BACKUP_PATH = @"Log\BACKUP";

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
        private ConvObjSingleBkDBParam _cosbdbp = null;

        /// <summary>
        /// CLCログ出力
        /// </summary>
        private ConvObjSingleBkCLCLogDB _coclcldb = null;

        /// <summary>
        /// 作業ディレクトリ
        /// </summary>
        private string _fileDirectory;

        /// <summary>
        /// バックアップファイル作成用Stream
        /// </summary>
        StreamWriter _fs = null;

        /// <summary>
        /// 処理行数
        /// </summary>
        int _procRowCnt;

        /// <summary>
        /// txtファイルパス
        /// </summary>
        string _txtFilePath;

        /// <summary>
        /// txtファイル名
        /// </summary>
        string _txtFileName;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象バックアップリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjBkCreateDB()
        {
        }

        /// <summary>
        /// コンバート対象バックアップリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="bkFileName">バックアップファイル名</param>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjBkCreateDB(string bkFileName)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            string workDir = string.Empty;
            try
            {
                // パラメータ
                _cosbdbp = new ConvObjSingleBkDBParam();

                // CLCログ出力
                _coclcldb = new ConvObjSingleBkCLCLogDB();

                // 処理行数
                _procRowCnt = 0;

                #region 作業ディレクトリ取得

                status = (int)ConvObjSingleBkDBParam.StatusCode.BkGetDirectory;

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
                _fileDirectory = Path.Combine(workDir.TrimEnd('\\'), BACKUP_PATH);

                // フォルダが存在しない場合作成する
                if (!Directory.Exists(_fileDirectory))
                {
                    Directory.CreateDirectory(_fileDirectory);
                }

                // 拡張子.txtのファイル名取得
                _txtFileName = bkFileName.Replace(@".zip", @".txt");
                _txtFilePath = Path.Combine(_fileDirectory, _txtFileName);

                status = (int)ConvObjSingleBkDBParam.StatusCode.BkStream;

                // 書き込み型でStream生成
                _fs = new StreamWriter(_txtFilePath, false);

                #endregion // バックアップファイル初期化

            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RB ConvObjBkCreateDB Exception", status.ToString(), ex.Message));
                throw;
            }
            finally
            {
            }
        }
        #endregion //コンストラクタ

        #region ConvObjBackup
        /// <summary>
        /// コンバート対象バックアップ前のバックアップを行います。
        /// </summary>
        /// <param name="mstData">バックアップデータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップ前のバックアップを行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjBackup(DataRow mstData)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int procStatus = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            int colCnt = 0;
            StringBuilder txtData = new StringBuilder();
            string encryptData = string.Empty;

            try
            {
                #region バックアップデータ文字列変換

                // バックアップデータをタブ区切りの文字列に変換

                procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkConvStr;

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
                _procRowCnt++;

                #endregion // バックアップデータ文字列変換

                // テキストデータ暗号化
                procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkEncrypt;

                encryptData = EncryptionEntry(txtData.ToString());

                // メモリ確保のため変数初期化
                txtData = null;

                #region 書き込み処理

                // zipファイル書き込み
                procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkWrite;
                _fs.WriteLine(encryptData);

                // メモリ確保のため変数初期化
                encryptData = null;

                #endregion // 書き込み処理

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch(Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},procStatus:{1},procRowCnt:{2},ex:{3}", "ERR PMCMN00163RB ConvObjBackup Exception", procStatus.ToString(), _procRowCnt.ToString(), ex.Message));
                throw ex;
            }

            return status;
        }

        #endregion // ConvObjBackup

        #region バックアップファイル圧縮
        /// <summary>
        /// バックアップファイル圧縮を行います。
        /// </summary>
        /// <param name="bkFileName">バックアップファイル名</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : バックアップファイル圧縮を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int BackupZipCreate(string bkFileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int procStatus = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            string zipFilePath = string.Empty;

            try
            {
                // 作成終了したファイル解放
                if (_fs != null)
                {
                    _fs.Close();
                    _fs.Dispose();
                    _fs = null;
                }

                // zipファイルパス設定
                zipFilePath = Path.Combine(_fileDirectory, bkFileName);

                // zip書庫のStream
                using (FileStream zfs = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write))
                {
                    // ZipOutputStreamを作成
                    using (ZipOutputStream zos = new ZipOutputStream(zfs))
                    {
                        // 圧縮レベルを最高圧縮に設定
                        zos.SetLevel(9);

                        // パスワード設定
                        zos.Password = AESEncryptInfo.ZIP_PASSWORD;

                        // ZipEntryを作成
                        ZipEntry ze = new ZipEntry(_txtFileName);

                        procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkEntryPut;

                        // 新しいエントリの追加を開始
                        zos.PutNextEntry(ze);

                        // 圧縮するファイルを読み込む
                        using (FileStream tfs = new FileStream(_txtFilePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[208];
                            int len;
                            while ((len = tfs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                // 書庫に書き込む
                                zos.Write(buffer, 0, len);
                            }

                            tfs.Close();
                        }
                        zos.Finish();
                        zos.Close();
                    }
                    zfs.Close();
                }

                // 圧縮元ファイル削除
                status = BackupDelete();

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},procStatus:{1},ex:{2}", "ERR PMCMN00163RB BackupZipCreate Exception", procStatus.ToString(), ex.Message));
                throw ex;
            }

            return status;
        }

        #endregion // バックアップファイル圧縮

        #region バックアップファイル削除
        /// <summary>
        /// バックアップファイル削除を行います。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : バックアップファイル圧縮を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int BackupDelete()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // テキストファイルが残っている場合は削除する
                if (File.Exists(_txtFilePath))
                {
                    File.Delete(_txtFilePath);
                }

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RB BackupDelete Exception", ex.Message));
                throw;
            }

            return status;
        }

        #endregion // バックアップファイル削除

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
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RB EncryptionEntry Exception", ex.Message));
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
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            if (_cosbdbp.ClcLogOutputInfo == (int)ConvObjSingleBkDBParam.OutputCode.ON)
            {
                try
                {
                    // CLCログ出力
                    _coclcldb.ClcLogOutput(message);
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
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public void Dispose()
        {
            try
            {
                if (_fs != null)
                {
                    _fs.Close();
                    _fs.Dispose();
                    _fs = null;
                }

                BackupDelete();

            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RB Dispose Exception", ex.Message));
                throw ex;
            }
            finally
            {
            }
        }
        #endregion // Dispose
    }


}
