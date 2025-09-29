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
// 管理番号  11601223-00 作成担当 : 続木
// 修 正 日  2021/09/09  修正内容 : ローカルファイル削除漏れ、不要な例外出力抑止対応
//----------------------------------------------------------------------------//
// 管理番号  11970089-00 作成担当 : 田村顕成
// 修 正 日  2023/05/29  修正内容 : AWS TLS1.2対応
//----------------------------------------------------------------------------//
using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Xml;
using Broadleaf.Application.Common;
using System.Security.Cryptography;
using Broadleaf.Application.Remoting;
using Amazon.S3;
using Amazon;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;

// ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 -------->>>>>
using Broadleaf.Application.Resources;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
// ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 --------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンバート対象バックアップファイル操作
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バックアップファイル操作</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
    /// <br>Programmer : 続木</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjSingleBkFileMngDB : RemoteWithAppLockDB
    {
        #region 列挙体

        /// <summary>
        /// バックアップ削除コード
        /// </summary>
        public enum BkDelCode
        {
            /// <summary>有効</summary>
            Enable = 0
          , /// <summary>無効</summary>
            Disable = 1
        };

        #endregion // 列挙体

        #region 定数

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00163R_SendSetting.xml";

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

        #endregion // 定数

        #region プライベートフィールド

        /// <summary>
        /// バケット名
        /// </summary>
        private string _bucketName;

        /// <summary>
        /// アクセスキーID
        /// </summary>
        private string _accessKeyID;

        /// <summary>
        /// シークレットアクセスキー
        /// </summary>
        private string _secretAccessKey;

        /// <summary>
        /// 作業ディレクトリ
        /// </summary>
        private string _fileDirectory;

        /// <summary>
        /// コンバート対象バックアップパラメータ
        /// </summary>
        ConvObjSingleBkDBParam _cosbdbp = null;

        /// <summary>
        /// CLCログ出力
        /// </summary>
        private ConvObjSingleBkCLCLogDB _coclcldb = null;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象バックアップAWS操作
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjSingleBkFileMngDB()
        {
            _bucketName = string.Empty;
            _accessKeyID = string.Empty;
            _secretAccessKey = string.Empty;

            try
            {
                _cosbdbp = new ConvObjSingleBkDBParam();
                _coclcldb = new ConvObjSingleBkCLCLogDB();
                
                #region 設定ファイル取得

                string fileName = this.InitializeXmlSettings();

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("BucketName")) _bucketName = DecryptionEntry(reader.ReadElementContentAsString()).Trim('\0');
                            if (reader.IsStartElement("AccessKeyID")) _accessKeyID = DecryptionEntry(reader.ReadElementContentAsString()).Trim('\0');
                            if (reader.IsStartElement("SecretAccessKey")) _secretAccessKey = DecryptionEntry(reader.ReadElementContentAsString()).Trim('\0');
                        }
                    }
                }
                else
                {
                    // 設定ファイルがない場合エラーログ出力
                    base.WriteErrorLog("ConvObjSingleBkFileMngDB XmlNotFound");
                }
                #endregion // 設定ファイル取得

                #region 作業ディレクトリ取得

                // レジストリキー取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(RegistryKeyUSER_APMain);

                string workDir = string.Empty;

                // 作業ディレクトリ取得
                if (key == null) // あってはいけないケース
                {
                    workDir = WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    workDir = key.GetValue(RegistryKeyUSER_APInstallDirectory, WorkingDirDefault).ToString();
                }

                // ファイル格納元パス定義
                _fileDirectory = Path.Combine(workDir.TrimEnd('\\'), BACKUP_PATH);

                #endregion // 作業ディレクトリ取得


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB Exception");
            }
        }

        #endregion //コンストラクタ

        #region AWSアップロード

        /// <summary>
        /// AWSアップロード
        /// </summary>
        /// <param name="bkFileName"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWSアップロードします。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: AWS TLS1.2対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/05/29</br>
        /// <br>管理番号   : 11970089-00</br>
        /// <br></br>
        /// </remarks>
        public int AWSUpload(string bkFileName)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;

            if (string.IsNullOrEmpty(_bucketName) || string.IsNullOrEmpty(_accessKeyID) || string.IsNullOrEmpty(_secretAccessKey))
            {
                // 設定ファイル情報がない場合終了
                // リトライしても結果が変わらないため正常で戻す
                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                return status;
            }

            if (string.IsNullOrEmpty(bkFileName))
            {
                // バックアップファイルがない場合異常終了
                return status;
            }

            try
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.AWSUpload;
                
	            // ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 -------->>>>>
                string strSslPolErrMsg;
	            // Partsman Product定数定義クラス(PMCMN00500C.dll)からセキュリティプロトコルを取得する。
	            ServicePointManager.SecurityProtocol = ConstantManagement_PM_PRO.ScrtyPrtcl;
	
	            // 証明書の検証確認追加
	            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(
	                Object certsender,
	                X509Certificate certificate,
	                X509Chain chain,
	                SslPolicyErrors sslPolicyErrors)
	            {
	                return AddServerCertificateValidation(certsender, certificate, chain, sslPolicyErrors, out strSslPolErrMsg);
	            });
                // ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 --------<<<<<
                
                AmazonS3Config clientConfig = new AmazonS3Config();

                // The Asia Pacific (Tokyo) endpoint.
                clientConfig.RegionEndpoint = RegionEndpoint.APNortheast1;
                using (AmazonS3Client s3 = new AmazonS3Client(_accessKeyID, _secretAccessKey, clientConfig))
                {
                    using (TransferUtility tranUtility = new TransferUtility(s3))
                    {
                        // 読込ファイルストリーム生成
                        string filePath = Path.Combine(_fileDirectory, bkFileName);
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            // AWSへアップロード
                            tranUtility.Upload(fs, _bucketName, bkFileName);
                        }
                    }
                }

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.AWSUploadExError;
                ClcLogOutputProc(string.Format("{0},status:{1},_bucketName:{2},_accessKeyID:{3},_secretAccessKey:{4},ex:{5}", "ERR PMCMN00163RF AWSUpload Exception", status.ToString(), _bucketName, _accessKeyID, _secretAccessKey, ex.ToString()));
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.AWSUpload Exception", status);
            }

            return status;
        }

        // ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 -------->>>>>
        /// <summary>
        /// サーバ証明書有効性チェック
        /// </summary>
        /// <param name="certsender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <param name="strSslPolErrMsg"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWS TLS1.2対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/05/29</br>
        /// <br>管理番号   : 11970089-00</br>
        /// <br></br>
        /// </remarks>
        private bool AddServerCertificateValidation(Object certsender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors, out string strSslPolErrMsg)
        {
            strSslPolErrMsg = string.Empty;
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                strSslPolErrMsg = "サーバー証明書の検証に成功しました。";
                return true;
            }
            else
            {
                strSslPolErrMsg = "サーバー証明書の検証に失敗しました。";

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) ==
                    SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    strSslPolErrMsg += "ChainStatusが、空でない配列を返しました。";
                    strSslPolErrMsg += "[";
                    foreach (X509ChainStatus C509CS in chain.ChainStatus)
                    {
                        strSslPolErrMsg += string.Format("{0}:{1} ", C509CS.Status, C509CS.StatusInformation);
                    }
                    strSslPolErrMsg += "]";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) ==
                    SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    strSslPolErrMsg += "証明書名が不一致です。";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) ==
                    SslPolicyErrors.RemoteCertificateNotAvailable)
                {
                    strSslPolErrMsg += "証明書が利用できません。";
                }
                return false;
            }
        }
        // ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 --------<<<<<<

        #endregion // AWSアップロード

        #region 旧バックアップ削除

        /// <summary>
        /// 旧バックアップ削除
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 旧バックアップ削除します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public int OldBkDelete(ConvObjSingleBkWork convObjSingleBkWork)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int statusProc = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int statusAWS = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int statusLocal = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            SqlConnection sqlConnection = null;
            DataTable dt = null;
            // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
            string[] localFiles = new string[0];
            // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

            try
            {
                // データベース接続
                statusProc = GetDataBaseConnect(ref sqlConnection);

                if (statusProc != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    base.WriteErrorLog("ConvObjSingleBkFileMngDB.AWSDelete GetDataBaseConnectError", statusProc);
                    // データベース接続失敗の場合中断する
                    return status;
                }

                // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                // 現在格納されている全ローカルバックファイルパス取得
                localFiles = GetLocalFiles();
                // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

                // コンバート対象バックアップ管理マスタ取得
                statusProc = GetConvObjBkMng(convObjSingleBkWork, sqlConnection, ref dt);

                if (statusProc == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // 処理続行
                }
                else if (statusProc == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                    // 削除対象ファイルがないため正常終了
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    return status;
                }
                else
                {
                    base.WriteErrorLog("ConvObjSingleBkFileMngDB.AWSDelete GetDataBaseConnectError", statusProc);
                    // マスタ取得に失敗した場合中断する
                    return status;
                }

                if (!string.IsNullOrEmpty(_bucketName) && !string.IsNullOrEmpty(_accessKeyID) && !string.IsNullOrEmpty(_secretAccessKey))
                {
                    // 設定ファイル情報がある場合のみ実行
                    // AWSファイル削除
                    // ファイル削除失敗は後続処理に影響しないため、リトライ対象しない
                    statusAWS = AWSDelete(dt);

                }
                else
                {
                    // 設定ファイルがない場合ローカルのみ操作するため正常
                    statusAWS = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }

                // ローカルファイル削除
                // ファイル削除失敗は後続処理に影響しないため、リトライ対象しない
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //statusLocal = LocalDelete(dt);
                statusLocal = LocalDelete(dt, localFiles);
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

                if (statusAWS == (int)ConvObjSingleBkDBParam.StatusCode.Normal && statusLocal == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // ファイル削除が成功した場合コンバート対象バックアップ管理マスタ更新
                    statusProc = UpdConvObjBkMng(convObjSingleBkWork, sqlConnection, dt);
                }

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.AWSDelete Exception", status);
            }
            finally
            {
                // データテーブル解放
                if (dt != null)
                {
                    dt.Clear();
                    dt.Dispose();
                    dt = null;
                }

                // データベース接続解除
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }

        #endregion // 旧バックアップ削除

        #region ローカル不正ファイル削除

        /// <summary>
        /// ローカルファイル削除
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ローカルファイル削除します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public int LocalExDelete()
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteError;

            try
            {
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //string[] txtFileList = Directory.GetFiles(_fileDirectory, "*.txt");
                //foreach (string txtFile in txtFileList)
                //{
                //    base.WriteErrorLog(txtFile);
                //    File.Delete(txtFile);
                //}
                if (Directory.Exists(_fileDirectory))
                {
                    string[] txtFileList = Directory.GetFiles(_fileDirectory, "*.txt");
                    foreach (string txtFile in txtFileList)
                    {
                        base.WriteErrorLog(txtFile);
                        File.Delete(txtFile);
                    }
                }
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteExError;
                // ログ出力
                base.WriteErrorLog(ex, "LocalExDelete Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // ローカルファイル削除


        #region ■ Private Methods

        #region コンバート対象バックアップ管理マスタ更新

        /// <summary>
        /// コンバート対象バックアップ管理マスタ更新
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップ管理マスタ更新します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        private int UpdConvObjBkMng(ConvObjSingleBkWork convObjSingleBkWork, SqlConnection sqlConnection, DataTable dt)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteUpdConvObjBkMngError;
            // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>        
            //int statusProc = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
            StringBuilder sqlText;
            int iRowCnt = 0;

            try
            {
                // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //foreach (DataRow dr in dt.Rows)
                //{
                // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                sqlText = new StringBuilder();
                sqlText.AppendLine("UPDATE ");
                sqlText.AppendLine(" CONVOBJBKMNGRF ");
                sqlText.AppendLine("SET ");
                sqlText.AppendLine(" BKDELCODERF = @BKDELCODE ");
                sqlText.AppendLine("WHERE ");
                sqlText.AppendLine("     ENTERPRISECODERF = @ENTERPRISECODE ");
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //sqlText.AppendLine(" AND BKCREGENERATIONRF = @BKCREGENERATION ");
                sqlText.AppendLine(" AND BKDELCODERF = @BKDELCODE_CND ");
                sqlText.AppendLine(" AND BKCREGENERATIONRF <= @BKCREGENERATION ");
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

                using (SqlCommand sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection))
                {
                    sqlCommand.CommandTimeout = _cosbdbp.DbCommandTimeout;

                    //Prameterオブジェクトの作成
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                    SqlParameter paraDelCodeCnd = sqlCommand.Parameters.Add("@BKDELCODE_CND", SqlDbType.Int);
                    // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                    SqlParameter paraBkCreGeneration = sqlCommand.Parameters.Add("@BKCREGENERATION", SqlDbType.Int);
                    SqlParameter paraDelCode = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                    //paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32((int)dr["BKCREGENERATIONRF"]);
                    paraDelCodeCnd.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable);
                    paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreGeneration - _cosbdbp.BkGeneration);
                    // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                    paraDelCode.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Disable);

                    iRowCnt = sqlCommand.ExecuteNonQuery();

                    // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                    //if (iRowCnt == 0)
                    //{
                    //    statusProc = (int)ConvObjSingleBkDBParam.StatusCode.Error;
                    //    base.WriteErrorLog(string.Format("{0},BKCREGENERATIONRF:{1}", "ConvObjSingleBkFileMngDB.UpdConvObjBkMng UpdNotFound", dr["BKCREGENERATIONRF"].ToString()), statusProc);
                    //}
                    // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                }
                // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //}
                // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteUpdConvObjBkMngSqlExError;
                base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkFileMngDB.UpdConvObjBkMng SqlException", status);
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteUpdConvObjBkMngExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.UpdConvObjBkMng Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // コンバート対象バックアップ管理マスタ更新

        #region AWSファイル削除

        /// <summary>
        /// AWSファイル削除
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWSファイル削除します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: AWS TLS1.2対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/05/29</br>
        /// <br>管理番号   : 11970089-00</br>
        /// <br></br>
        /// </remarks>
        private int AWSDelete(DataTable dt)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteAWSDeleteError;

            try
            {
	            // ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 -------->>>>>
                string strSslPolErrMsg;
	            // Partsman Product定数定義クラス(PMCMN00500C.dll)からセキュリティプロトコルを取得する。
	            ServicePointManager.SecurityProtocol = ConstantManagement_PM_PRO.ScrtyPrtcl;
	
	            // 証明書の検証確認追加
	            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(
	                Object certsender,
	                X509Certificate certificate,
	                X509Chain chain,
	                SslPolicyErrors sslPolicyErrors)
	            {
	                return AddServerCertificateValidation(certsender, certificate, chain, sslPolicyErrors, out strSslPolErrMsg);
	            });
	            // ------ ADD 2023/05/29 田村顕成 AWS TLS1.2対応 --------<<<<<

                AmazonS3Config clientConfig = new AmazonS3Config();

                // The Asia Pacific (Tokyo) endpoint.
                clientConfig.RegionEndpoint = RegionEndpoint.APNortheast1;

                DeleteObjectsRequest deleteOBjectsRequest = new DeleteObjectsRequest();

                // バケット名設定
                deleteOBjectsRequest.BucketName = _bucketName;

                // 削除対象ファイルをキーリストに追加
                foreach (DataRow dr in dt.Rows)
                {
                    deleteOBjectsRequest.AddKey(dr["BKFILENAMERF"].ToString());
                }

                using (AmazonS3Client s3 = new AmazonS3Client(_accessKeyID, _secretAccessKey, clientConfig))
                {
                    // ファイル削除
                    s3.DeleteObjects(deleteOBjectsRequest);
                }

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteAWSDeleteExError;
                // ログ出力
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.AWSDelete Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // AWSファイル削除

        #region ローカルファイル削除

        /// <summary>
        /// ローカルファイル削除
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ローカルファイル削除します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
        //private int LocalDelete(DataTable dt)
        private int LocalDelete(DataTable dt, string[] localFiles)
        // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteError;

            // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
            bool delExec = true;
            string filePath = string.Empty;
            // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

            try
            {
                // ローカルファイル削除
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //foreach (DataRow dr in dt.Rows)
                //{
                //    string filePath = Path.Combine(_fileDirectory, dr["BKFILENAMERF"].ToString());
                //    if (File.Exists(filePath))
                //    {
                //        File.Delete(filePath);
                //    }
                //}
                // 現在格納されているローカルバックアップファイルをループ
                foreach (string localFile in localFiles)
                {
                    delExec = true;

                    foreach (DataRow dr in dt.Rows)
                    {
                        filePath = Path.Combine(_fileDirectory, dr["BKFILENAMERF"].ToString());

                        // ローカルファイルが有効なファイルか確認
                        if (filePath == localFile)
                        {
                            // 保持世代内の有効なファイルの場合削除対象外
                            delExec = false;
                        }
                    }

                    // 有効なファイルにヒットしない場合削除
                    if (delExec)
                    {
                        // 念のためファイルの存在チェックし削除
                        if (File.Exists(localFile))
                        {
                            File.Delete(localFile);
                        }
                    }
                }
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteExError;
                // ログ出力
                base.WriteErrorLog(ex, "LocalDelete.AWSDelete Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // ローカルファイル削除

        // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
        #region ローカルバックアップファイルパス取得
        /// <summary>
        /// ローカルバックアップファイルパス取得
        /// </summary>
        /// <returns>ローカルバックアップファイルパス</returns>
        /// <remarks>
        /// <br>Note       : ローカルバックアップファイルパス取得します。</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public string[] GetLocalFiles()
        {
            string[] files = new string[0];
            try
            {
                if (Directory.Exists(_fileDirectory))
                {
                    files = Directory.GetFiles(_fileDirectory, "*.zip");
                }
            }
            catch (Exception ex)
            {
                // ログ出力
                base.WriteErrorLog(ex, "GetLocalFiles Exception", (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetLocalFilesExError);
            }
            finally
            {
            }

            return files;
        }
        #endregion
        // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

        #region データベース接続

        /// <summary>
        /// データベース接続
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : データベース接続</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseConnect(ref SqlConnection sqlConnection)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.AWSGetDataBaseConnectError;

            sqlConnection = null;
                
            try
            {
                // コネクション生成
                sqlConnection = this.CreateConnection(true);

                if (sqlConnection != null)
                {
                    // 成功
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }
            }
            catch (Exception ex)
            {
                // 例外エラー
                status = (int)ConvObjSingleBkDBParam.StatusCode.AWSGetDataBaseConnectExError;
                // ログ出力
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.GetDataBaseConnect Exception", status);
            }
            finally
            {
                // 初期化
            }

            return status;
        }

        #endregion //データベース接続

        #region コンバート対象バックアップ管理マスタ取得

        /// <summary>
        /// コンバート対象バックアップ管理マスタ取得
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップ管理マスタ取得します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        private int GetConvObjBkMng(ConvObjSingleBkWork convObjSingleBkWork, SqlConnection sqlConnection, ref DataTable dt)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetConvObjBkMngError;

            StringBuilder sqlText = new StringBuilder();
            int iRowCnt = 0;

            try
            {
                sqlText.AppendLine("SELECT ");
                sqlText.AppendLine(" BKCREGENERATIONRF, ");
                sqlText.AppendLine(" BKFILENAMERF ");
                sqlText.AppendLine("FROM ");
                sqlText.AppendLine(" CONVOBJBKMNGRF ");
                sqlText.AppendLine("WHERE ");
                sqlText.AppendLine("     ENTERPRISECODERF = @ENTERPRISECODE ");
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                //sqlText.AppendLine(" AND BKCREGENERATIONRF <= @BKCREGENERATION ");
                // 有効なファイルのみ取得する
                sqlText.AppendLine(" AND BKCREGENERATIONRF > @BKCREGENERATION ");
                // ------ UPD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                sqlText.AppendLine(" AND LOGICALDELETECODERF = @LOGICALDELETECODE ");
                sqlText.AppendLine(" AND BKDELCODERF = @BKDELCODE ");

                using (SqlCommand sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection))
                {
                    sqlCommand.CommandTimeout = _cosbdbp.DbCommandTimeout;

                    //Prameterオブジェクトの作成
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraBkCreGeneration = sqlCommand.Parameters.Add("@BKCREGENERATION", SqlDbType.Int);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDelCode = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    // 保持世代以前のファイルを削除対象とする
                    int bkCreGeneration = convObjSingleBkWork.BkCreGeneration - _cosbdbp.BkGeneration;

                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32(bkCreGeneration);
                    paraDelCode.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = sqlCommand;

                        dt = new DataTable();
                        iRowCnt = sda.Fill(dt);
                    }
                }

                if (iRowCnt == 0)
                {
                    // 削除対象ファイルなし
                    status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;
                }
                else
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetConvObjBkMngSqlError;
                base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkFileMngDB.GetConvObjBkMng SqlException", status);
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetConvObjBkMngExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.GetConvObjBkMng Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // コンバート対象バックアップ管理マスタ取得

        #region XMLファイル操作

        /// <summary>
        /// XMLファイル設定情報取得処理
        /// ファイルが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch
            {
                //ログ出力
            }

            return path;
        }
        #endregion  //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダのパス取得
        /// フォルダが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ
                        // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch
            {
                //ログ出力
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // カレントフォルダ

        #region DecryptionEntry

        /// <summary>
        /// データ複合化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 文字列の複合化を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private string DecryptionEntry(string source)
        {
            string decrypted = string.Empty;
            byte[] decByte;

            try
            {
                // AES暗号化オブジェクトを生成します
                using (RijndaelManaged rijndael = new RijndaelManaged())
                {
                    // 初期化ベクトル、暗号化鍵定義
                    rijndael.IV = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_IV);
                    rijndael.Key = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_Key);
                    rijndael.Padding = PaddingMode.Zeros;

                    // 暗号化オブジェクト生成
                    ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                    // 暗号化文字列をbyte配列に変換
                    decByte = Convert.FromBase64String(source);

                    // Stream操作で文字列から暗号化後のByte配列を生成
                    using (MemoryStream msDecrypt = new MemoryStream(decByte))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // CryptoStream用のStreamreaderで複合化文字列読込
                                decrypted = srDecrypt.ReadToEnd();
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.DecryptionEntry Exception");
                throw;
            }

            return decrypted;
        }

        #endregion // データ複合化

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

        #endregion // ■ Private Methods


    }
}
