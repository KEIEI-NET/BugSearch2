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

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象バックアップDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バックアップの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
    /// <br>Programmer : 続木</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjSingleBkDB : RemoteWithAppLockDB, IConvObjSingleBkDB
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

        #region プライベートフィールド

        /// <summary>
        /// パラメータ
        /// </summary>
        private ConvObjSingleBkDBParam cosbdbp = null;

        /// <summary>
        /// 操作ログ登録リモート
        /// </summary>
        private OprtnHisLogDB operationLoggingDB = null;

        /// <summary>
        /// 価格マスタバックアップ
        /// </summary>
        private ConvObjBkCreateDB cobdb = null;

        /// <summary>
        /// WebRequest Access Check
        /// </summary>
        private ConvObjSingleBkDBWebRequest codbwr = null;

        /// <summary>
        /// CLCログ出力
        /// </summary>
        private ConvObjSingleBkCLCLogDB coclcldb = null;

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
        public ConvObjSingleBkDB()
            : base("PMCMN00165D", "Broadleaf.Application.Remoting.ParamData.ConvObjSingleBkWork", "CONVOBJBKRF")
        {
            try
            {
                // パラメータ
                cosbdbp = new ConvObjSingleBkDBParam();

                // CLCログ出力
                coclcldb = new ConvObjSingleBkCLCLogDB();

            }
            catch (Exception)
            {
            }
        }
        #endregion //コンストラクタ

        #region IConvObjSingleBkDB メンバ

        #region コンバート対象バックアップ
        /// <summary>
        /// コンバート対象バックアップします。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップします。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjSingleBackupExec(ref ConvObjSingleBkWork convObjSingleBkWork)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.BkStart;
            int stAWS = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int stBkDel = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int stExDel = (int)ConvObjSingleBkDBParam.StatusCode.Error;

            try
            {
                // ログ出力用企業コード設定
                coclcldb.EnterpriseCode = convObjSingleBkWork.EnterpriseCode;

                // コンバート対象バックアップ実行
                status = ConvObjSingleBackupProc(ref convObjSingleBkWork);

                ConvObjSingleBkFileMngDB cosbfmdb = new ConvObjSingleBkFileMngDB();

                // 不正ファイル削除
                stExDel = cosbfmdb.LocalExDelete();

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // AWSアップロード
                    // 後続処理に影響しないため、アップロード失敗時リトライ対象外
                    stAWS = cosbfmdb.AWSUpload(convObjSingleBkWork.BkFileName);
                }
                else if (status == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                    // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                    //ClcLogOutputProc(string.Format("{0},status:{1}", "INFO PMCMN00163RA ConvObjSingleBackupExec NormalNotFound", status));
                    // ------ DEL 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                }
                else
                {
                    ClcLogOutputProc(string.Format("{0},status:{1}", "ERR PMCMN00163RA ConvObjSingleBackupExec Error", status));
                }

                // 旧バックアップ削除
                // 後続処理に影響しないため、削除失敗時リトライ対象外
                stBkDel = cosbfmdb.OldBkDelete(convObjSingleBkWork);

            }
            catch (Exception ex)
            {
                // ログ出力
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.ConvObjSingleBackupExec", status);

                // エラーログ出力
                ClcLogOutputProc(string.Format("{0}:{1}", "ERR PMCMN00163RA ConvObjSingleBackupExec Exception", ex.Message));
            }
            finally
            {
                // WebRequest Access Check Pt1
                ConvObjSingleBkDBWebRequestProc((int)ConvObjSingleBkDBWebRequest.WebReqChkPrm.UnauthorizedAccessPt1);

            }

            return status;
        }

        /// <summary>
        /// コンバート対象バックアップします。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップします。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjSingleBackupProc(ref ConvObjSingleBkWork convObjSingleBkWork)
        {

            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;       // 本メソッドの戻り値
            int stConnect = (int)ConvObjSingleBkDBParam.StatusCode.Error;    // DB接続用ステータス保持
            int stTrans = (int)ConvObjSingleBkDBParam.StatusCode.Error;      // DBトランザクション用ステータス保持
            int stLock = (int)ConvObjSingleBkDBParam.StatusCode.Error;       // DBアプリケーションロック用ステータス保持
            int stBackup = (int)ConvObjSingleBkDBParam.StatusCode.Error;     // DBバックアップ用ステータス保持
            int stBkMst = (int)ConvObjSingleBkDBParam.StatusCode.Error;      // バックアップ処理用ステータス保持
            int stBkInfo = (int)ConvObjSingleBkDBParam.StatusCode.Error;      // バックアップ情報更新用ステータス保持

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            string resNm = string.Empty;           // ロックリソース名

            try
            {
                // データベース接続文字列取得
                stConnect = GetDataBaseConnect(ref sqlConnection);
                if (stConnect != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3001;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stConnect:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetDataBaseConnect", stConnect.ToString(), status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }

                // トランザクション開始
                stTrans = GetDataBaseTransaction(ref sqlConnection, ref sqlTransaction);
                if (stTrans != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3002; 
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stTrans:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetDataBaseTransaction", stTrans.ToString(), status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }

                // 企業コード
                string enterpriseCode = convObjSingleBkWork.EnterpriseCode;

                // アプリケーションロック　リソース名取得
                resNm = GetApplicationLockResourceName(ref enterpriseCode);
                if (string.IsNullOrEmpty(resNm) || string.IsNullOrEmpty(enterpriseCode))
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3003;
                    // リトライ後リソース名、企業コード取得できない場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},resNm:{1},enterpriseCode:{2},status:{3}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetApplicationLockResourceName", resNm, enterpriseCode, status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }
                
                // アプリケーションロック
                stLock = GetApplicationLock(resNm, cosbdbp.DbApplicationLockTimeout, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3004;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetApplicationLock", stLock.ToString(), status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }

                // システム日付取得
                string nowDate = DateTime.Now.Year.ToString("0000") +
                    DateTime.Now.Month.ToString("00") +
                    DateTime.Now.Day.ToString("00");

                // バックアップ作成日設定
                convObjSingleBkWork.BkCreateDate = int.Parse(nowDate);

                // バックアップ取得情報チェック
                stBackup = EnvBackupInfSearchCheck(convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);
                if (stBackup == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                }
                else if (stBackup == (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupExists)
                {
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},status:{1}", "INFO PMCMN00163RA ConvObjSingleBackupProc BackupExists", stBackup.ToString()));

                    status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;

                    // 呼び先でログ出力している
                    
                    // バックアップ取得済みの場合後続処理を行わない。
                    return status;
                }
                else
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3005;

                    // 呼び先でログ出力している
                    
                    // 後続処理を行わない
                    return status;
                }

                // バックアップ最新世代取得
                stBackup = EnvBackupInfSearchProc(ref convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);
                if (stBackup == (int)ConvObjSingleBkDBParam.StatusCode.Normal || stBackup == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                }
                else
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3006;
                    
                    // 呼び先でログ出力している

                    // 後続処理を行わない
                    return status;
                }

                // マスタバックアップ実行
                stBkMst = VerObjMstBkProc(ref convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);

                // バックアップ作成した場合
                if (stBkMst == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    #region バックアップ情報登録

                    status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEnt;

                    // 企業コード　設定済み

                    // バックアップ世代　最新バックアップ世代＋１
                    convObjSingleBkWork.BkCreGeneration += 1;

                    // バックアップ開始日、バックアップファイル名 設定済み

                    // バックアップ削除区分
                    convObjSingleBkWork.BkDelCode = (int)BkDelCode.Enable;

                    // コンバート対象バックアップ管理マスタ登録
                    stBkInfo = BackupInfoEnt(convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);

                    #endregion // バックアップ情報登録
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkDB.ConvObjSingleBackupProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.ConvObjSingleBackupProc Exception", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc Exception", status.ToString(), ex.Message));
            }
            finally
            {
                // アプリケーションロックリリース
                stLock = GetApplicationLockRelease(resNm, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3008;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetApplicationLockRelease", stLock.ToString(), status.ToString()));
                }

                // トランザクション終了
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if ((stBkMst == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound || stBkInfo == (int)ConvObjSingleBkDBParam.StatusCode.Normal) && stLock == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                        {
                            // コミット
                            sqlTransaction.Commit();
                            //sqlTransaction.Rollback();

                            // 成功
                            status = stBkMst;
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }
                    sqlTransaction.Dispose();
                }

                // データベース接続解除
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion // コンバート対象バックアップ

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
            int status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseConnectError;

            sqlConnection = null;
                
            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionError;
                }

                try
                {
                    // コネクション生成
                    // 複数の結果セットを使用するため、接続文字列にMultipleActiveResultSets = true;を追加
                    // トランザクション開始時に接続される
                    sqlConnection = this.CreateConnection(false);
                    sqlConnection.ConnectionString += ";MultipleActiveResultSets = true";

                    if (sqlConnection != null)
                    {
                        // 成功
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // 例外エラー
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseConnectExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA GetDataBaseConnect Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // 初期化
                }
                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //データベース接続

        #region トランザクション開始

        /// <summary>
        /// トランザクション開始
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : トランザクション開始</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseTransaction(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionError;

            sqlTransaction = null;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionError;
                }

                try
                {
                    // トランザクション開始
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);
                    if ((sqlConnection != null) && (sqlTransaction != null))
                    {
                        // 成功
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // 例外エラー
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA GetDataBaseTransaction Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //データベース接続

        #region アプリケーションロック　リソース名取得

        /// <summary>
        /// アプリケーションロック　リソース名取得
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : アプリケーションロック　リソース名取得</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private string GetApplicationLockResourceName(ref string enterpriseCode)
        {
            string tmpenterpriseCode = string.Empty;
            string strResourceName = string.Empty;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    tmpenterpriseCode = string.Empty;
                    strResourceName = string.Empty;
                }

                try
                {
                    tmpenterpriseCode = enterpriseCode;
                    if (string.IsNullOrEmpty(tmpenterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            tmpenterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;
                        }
                        catch (Exception ex)
                        {
                            // リソース名取得不正で空欄を返却
                            strResourceName = string.Empty;
                            // 企業コード取得できないのでログ出力後にリトライ
                            ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00163RA GetApplicationLockResourceName serverLoginInfoAcquisition Exception", retryCnt.ToString(), ex.Message));
                        }
                    }

                    if (!string.IsNullOrEmpty(tmpenterpriseCode))
                    {
                        enterpriseCode = tmpenterpriseCode;
                        strResourceName = this.GetResourceName(tmpenterpriseCode);
                    }
                }
                catch (Exception ex)
                {
                    // リソース名取得不正で空欄を返却
                    strResourceName = string.Empty;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00163RA GetApplicationLockResourceName Exception", retryCnt.ToString(), ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (!string.IsNullOrEmpty(strResourceName))
                {
                    // 正常終了のためリトライしない
                    break;
                }

                retryCnt += 1;
            }

            return strResourceName;
        }

        #endregion //アプリケーションロック　リソース名取得

        #region アプリケーションロック

        /// <summary>
        /// アプリケーションロック
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : アプリケーションロック</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLock(string resNm, int timeout, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockError;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockError;
                }

                try
                {
                    // アプリケーションロック
                    status = this.Lock(resNm, timeout, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ロック成功
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // タイムアウト
                        status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockTimeout;
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLock Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLock Error", retryCnt.ToString(), status.ToString(), resNm));
                    }

                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00163RA GetApplicationLock Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //アプリケーションロック

        #region アプリケーションロックリリース

        /// <summary>
        /// アプリケーションロックリリース
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : アプリケーションロックリリース</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLockRelease(string resNm, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Error;
                }

                try
                {
                    // アプリケーションロックリリース
                    status = this.Release(resNm, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // リリース成功
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLockRelease Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLockRelease Error", retryCnt.ToString(), status.ToString(), resNm));
                    }
                }
                catch (Exception ex)
                {
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00163RA GetApplicationLockRelease Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //アプリケーションロックリリース


        #region バックアップ取得情報チェック

        /// <summary>
        /// バックアップ取得情報チェック
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : バックアップ取得情報チェック</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int EnvBackupInfSearchCheck(ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfError;

            int retryCnt = 0;

            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfError;
                    sqlText = null;
                    sqlCommand = null;
                    myReader = null;
                }

                try
                {
                    sqlText = new StringBuilder();
                    sqlText.Append("SELECT BKCREGENERATIONRF " + Environment.NewLine);
                    sqlText.Append(" FROM CONVOBJBKMNGRF " + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine);
                    sqlText.Append(" AND LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine);
                    sqlText.Append(" AND BKCREATEDATERF = @BKCREATEDATERF " + Environment.NewLine);
                    sqlText.Append(" AND BKDELCODERF = @BKDELCODE " + Environment.NewLine);
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaBkCreateDate = sqlCommand.Parameters.Add("@BKCREATEDATERF", SqlDbType.Int);
                    SqlParameter findParaBkDelCls = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    findParaEnterPriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findParaBkCreateDate.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreateDate);
                    findParaBkDelCls.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable); // 0:有効

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 検索結果あり　・・・　バックアップ取得済みを返却
                        status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupExists;
                    }
                    else
                    {
                        // 検索結果なし　・・・　処理続行
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                }
                catch (SqlException sqlex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfSqlExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchCheck SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchCheck Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }

                if ((status == (int)ConvObjSingleBkDBParam.StatusCode.Normal) || (status == (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupExists))
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion // バックアップ取得情報チェック

        #region 価格マスタバックアップ
        /// <summary>
        /// 価格マスタバックアップ
        /// </summary>
        /// <param name="convObjSingleBkWork">コンバート対象バックアップ管理パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 価格マスタバックアップ</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int VerObjMstBkProc(ref ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.VerObjMstBkProcError;
            int stBackup = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupExError;

            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            DataTable dt = null;
            DataRow dr = null;
            SqlDataReader sdr = null;
            ConvertDoubleRelease convertDoubleRelease = null;

            try
            {
                #region 価格マスタ取得

                status = (int)ConvObjSingleBkDBParam.StatusCode.MstGet;

                try
                {

                    sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                    // 価格マスタ取得

                    # region [SELECT文]
                    sqlText.Append("SELECT " + Environment.NewLine);
                    sqlText.Append(" * " + Environment.NewLine);
                    sqlText.Append(" FROM GOODSPRICEURF " + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = convObjSingleBkWork.EnterpriseCode;

                    sdr = sqlCommand.ExecuteReader();
                }
                catch (SqlException sqlex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.MstGetSqlExError;
                    ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA MstGet SqlException", status.ToString(), sqlex.Message));
                    // 例外スロー
                    throw;
                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.MstGetExError;
                    ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA MstGet Exception", status.ToString(), ex.Message));
                    // 例外スロー
                    throw;
                }

                # endregion  // 価格マスタ取得

                // 更新対象が1件以上の場合
                if (sdr.HasRows)
                {
                    // コンバート対象バージョン管理共通部品　情報初期化　呼び出し
                    // 変換情報呼び出し
                    convertDoubleRelease = new ConvertDoubleRelease();

                    // 企業コード設定
                    convertDoubleRelease.EnterpriseCode = convObjSingleBkWork.EnterpriseCode;

                    // 変換情報初期化
                    convertDoubleRelease.ReleaseInitLib();

                    #region DataTable作成
                    status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableCreate;

                    sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);
                    dt = CreateSchemaDataTable(sqlCommand);

                    #endregion // DataTable作成

                    #region 価格マスタバックアップ作成インスタンス生成

                    status = (int)ConvObjSingleBkDBParam.StatusCode.ConvObjBackupCreate;

                    // バックアップファイル名設定
                    // 「ConvObjBackup_作成年月日_企業コード_端末名_GUID」
                    convObjSingleBkWork.BkFileName = string.Format("ConvObjBackup_{0}_{1}_{2}_{3}.zip", convObjSingleBkWork.BkCreateDate, convObjSingleBkWork.EnterpriseCode, Environment.MachineName, Guid.NewGuid().ToString());

                    cobdb = new ConvObjBkCreateDB(convObjSingleBkWork.BkFileName);

                    #endregion // 価格マスタバックアップ作成インスタンス生成

                    while (sdr.Read())
                    {
                        #region 価格マスタ展開

                        status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableDeploy;

                        try
                        {
                            dr = DeployDataTable(sdr, dt);
                        }
                        catch
                        {
                            // 呼び先で例外ログ出力している
                            throw;
                        }
                        finally
                        {
                        }

                        #endregion // 価格マスタ展開

                        #region バックアップ作成

                        status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackup;

                        try
                        {
                            // 取得した価格マスタを単一バックアップ
                            if (cobdb != null)
                            {
                                if (convertDoubleRelease.ConvertInfParam.ConvertVersionMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                                {
                                    // コンバート済みの場合、解除してバックアップする
                                    convertDoubleRelease.EnterpriseCode = Convert.ToString(dr["ENTERPRISECODERF"]);
                                    convertDoubleRelease.GoodsMakerCd = Convert.ToInt32(dr["GOODSMAKERCDRF"]);
                                    convertDoubleRelease.GoodsNo = Convert.ToString(dr["GOODSNORF"]);
                                    convertDoubleRelease.ConvertSetParam = Convert.ToDouble(dr["LISTPRICERF"]);

                                    convertDoubleRelease.ReleaseProc();

                                    dr["LISTPRICERF"] = convertDoubleRelease.ConvertInfParam.ConvertGetParam;

                                }

                                stBackup = cobdb.ConvObjBackup(dr);

                                // 使用済みのDataRowを解放
                                if (dr != null)
                                {
                                    dr.Table.Clear();
                                    dr.Table.Dispose();
                                    dr = null;
                                }

                                if (stBackup != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    // バックアップ作成時にエラー発生
                                    status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupError2027;
                                    // ログ出力
                                    ClcLogOutputProc(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error", status.ToString(), stBackup.ToString()));
                                    throw new Exception(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error", status.ToString(), stBackup.ToString()));
                                }
                            }
                            else
                            {
                                // バックアップ作成時にエラー発生
                                status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupError2028;
                                // ログ出力
                                ClcLogOutputProc(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error null", status.ToString(), stBackup.ToString()));
                                throw new Exception(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error null", status.ToString(), stBackup.ToString()));
                            }
                        }
                        catch (Exception ex)
                        {
                            // 単一バックアップ時にエラー発生
                            status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupExError;
                            ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA DataTableBackup Exception", status.ToString(), ex.Message));
                            // 例外スロー
                            throw;
                        }

                        #endregion // バックアップ作成

                        // 処理行数をインクリメント
                        coclcldb.BkMstCnt++;
                    }

                    #region バックアップファイル圧縮
                    try
                    {
                        status = (int)ConvObjSingleBkDBParam.StatusCode.ConvObjBackupZipEntry;
                        cobdb.BackupZipCreate(convObjSingleBkWork.BkFileName);
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjSingleBkDBParam.StatusCode.ConvObjBackupZipEntryExError;
                        ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA ConvObjBackupZipEntry Exception", status.ToString(), ex.Message));
                        throw;
                    }
                    finally
                    {
                    }

                    #endregion // バックアップファイル圧縮

                    // 正常
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }
                else
                {
                    // バックアップ対象なし
                    status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkDB.VerObjMstBkProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA VerObjMstBkProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.VerObjMstBkProc ex", status);
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA VerObjMstBkProc Exception", status.ToString(), ex.Message));
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }

                if (dt != null)
                {
                    dt.Clear();
                    dt.Dispose();
                    dt = null;
                }

                if (sdr != null && !sdr.IsClosed)
                {
                    sdr.Close();
                    sdr.Dispose();
                }

                if (cobdb != null)
                {
                    cobdb.Dispose();
                    cobdb = null;
                }

                if (convertDoubleRelease != null)
                {
                    convertDoubleRelease.Dispose();
                    convertDoubleRelease = null;
                }
            }

            return status;
        }
        #endregion  //価格マスタコンバート

        #region 最新バックアップ世代取得

        /// <summary>
        /// 最新バックアップ世代取得
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 最新バックアップ世代取得</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int EnvBackupInfSearchProc(ref ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetError;
            object a = ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT;
            int retryCnt = 0;

            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetError;
                    sqlText = null;
                    sqlCommand = null;
                    myReader = null;
                }

                try
                {
                    sqlText = new StringBuilder();
                    sqlText.Append("SELECT MAX(BKCREGENERATIONRF) AS BKCREGENERATIONRF_MAX " + Environment.NewLine);
                    sqlText.Append(" FROM CONVOBJBKMNGRF " + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine);
                    sqlText.Append(" AND LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine);
                    sqlText.Append(" AND BKDELCODERF = @BKDELCODE " + Environment.NewLine);
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                    sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaBkDelCls = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    findParaEnterPriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findParaBkDelCls.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable); // 0:有効

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 検索結果あり　・・・　最新世代を返却
                        convObjSingleBkWork.BkCreGeneration = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BKCREGENERATIONRF_MAX"));
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                    else
                    {
                        // 検索結果なし　・・・　初期値のまま（0）
                        status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;
                    }
                }
                catch (SqlException sqlex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetSqlExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchProc SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal || status == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //最新バックアップ世代取得

        #region バックアップ開始情報を登録

        /// <summary>
        /// バックアップ開始情報を登録
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : バックアップ開始情報を登録</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int BackupInfoEnt(ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntError;

            SqlCommand sqlCommand = null;

            try
            {
                if (convObjSingleBkWork != null)
                {
                    # region [INSERT文]
                    StringBuilder sqlText_INSERT = new StringBuilder();
                    sqlText_INSERT.Append("INSERT INTO CONVOBJBKMNGRF " + Environment.NewLine);
                    sqlText_INSERT.Append(" (CREATEDATETIMERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDATEDATETIMERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,ENTERPRISECODERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,FILEHEADERGUIDRF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDEMPLOYEECODERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDASSEMBLYID1RF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDASSEMBLYID2RF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,LOGICALDELETECODERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKCREGENERATIONRF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKCREATEDATERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKFILENAMERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKDELCODERF " + Environment.NewLine);
                    sqlText_INSERT.Append("  ) VALUES ( " + Environment.NewLine);
                    sqlText_INSERT.Append("   @CREATEDATETIME " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDATEDATETIME " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@ENTERPRISECODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@FILEHEADERGUID " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDEMPLOYEECODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDASSEMBLYID1 " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDASSEMBLYID2 " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@LOGICALDELETECODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKCREGENERATION " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKCREATEDATE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKFILENAME " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKDELCODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  )" + Environment.NewLine);
                    # endregion

                    sqlCommand = new SqlCommand(sqlText_INSERT.ToString(), sqlConnection, sqlTransaction);

                    sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                    // 登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)convObjSingleBkWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraBkCreGeneration = sqlCommand.Parameters.Add("@BKCREGENERATION", SqlDbType.Int);
                    SqlParameter paraBkCreateDate = sqlCommand.Parameters.Add("@BKCREATEDATE", SqlDbType.Int);
                    SqlParameter paraBkFileName = sqlCommand.Parameters.Add("@BKFILENAME", SqlDbType.NVarChar);
                    SqlParameter paraDelCode = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjSingleBkWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjSingleBkWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(convObjSingleBkWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.LogicalDeleteCode);
                    paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreGeneration);
                    paraBkCreateDate.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreateDate);
                    paraBkFileName.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.BkFileName);
                    paraDelCode.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkDelCode);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }
                else
                {
                    // パラメータエラー
                    status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntParamError;
                    base.WriteErrorLog("ConvObjSingleBkDB.BackupStartEnt SqlException", status);
                    ClcLogOutputProc(string.Format("{0},status:{1}", "ERR PMCMN00163RA BackupStartEnt ParamError", status.ToString()));
                }

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntSqlExError;
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkDB.BackupStartEnt SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},BkFileName:{2},sqlex:{3}", "ERR PMCMN00163RA BackupStartEnt SqlException", status.ToString(), convObjSingleBkWork.BkFileName, sqlex.ToString()));
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.BackupStartEnt Exception", status);
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA BackupStartEnt Exception", status.ToString(), ex.ToString()));
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion //最新バックアップ世代取得

        #region DataTable作成
        /// <summary>
        /// 価格マスタ構造のDataTableを作成します。
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <returns>DataTableオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : DataTable作成</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private DataTable CreateSchemaDataTable(SqlCommand sqlCommand)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();

                # region [SELECT文]
                sqlText.Append("SELECT " + Environment.NewLine);
                sqlText.Append(" * " + Environment.NewLine);
                sqlText.Append(" FROM GOODSPRICEURF " + Environment.NewLine);
                sqlText.Append(" WHERE 1 = 0 " + Environment.NewLine);
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                // 価格マスタテーブル情報取得
                sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCommand;
                sda.FillSchema(dt, SchemaType.Source);
                
                // 大文字小文字を区別する
                dt.CaseSensitive = true;
            }
            catch (SqlException sqlex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RA CreateSchemaDataTable SqlException", sqlex.Message));
                throw;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RA CreateSchemaDataTable Exception", ex.Message));
                throw;
            }
            finally
            {
                if (sda != null)
                {
                    sda.Dispose();
                    sda = null;
                }
            }

            return dt;
        }
        #endregion // DataTable作成

        #region 価格マスタ展開
        /// <summary>
        /// 価格マスタのDataRowを展開します。
        /// </summary>
        /// <param name="reader">処理中のDataReader</param>
        /// <param name="dt">処理中のDatatable</param>
        /// <returns>DataTableオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : DataTable作成</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private DataRow DeployDataTable(SqlDataReader reader, DataTable dt)
        {
            DataRow dr = null;

            try
            {
                // DataRow作成
                dr = dt.NewRow();

                // 現在のDataReaderをDataRowに設定
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dr[i] = reader.GetValue(i);
                }
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RA DeployDataTable Exception", ex.ToString()));
                throw;
            }
            finally
            {
            }

            return dr;
        }
        #endregion // DataTable作成

        #region コンバート対象バックアップWebRequest
        /// <summary>
        /// コンバート対象バックアップWebRequest
        /// </summary>
        /// <param name="checkParam">チェックパラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップWebRequest</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjSingleBkDBWebRequestProc(int checkParam)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            try
            {
                if (cosbdbp.WebAccessCheckControl == (int)ConvObjSingleBkDBParam.CheckObjCode.ON)
                {
                    // WebRequest Access Check
                    if (codbwr == null)
                    {
                        codbwr = new ConvObjSingleBkDBWebRequest();
                    }
                    codbwr.ConvObjSingleBkDBWebReqRes(checkParam);
                }
            }
            catch
            {
            }
            finally
            {
            }

            return status;
        }
        #endregion  //コンバート対象バージョン管理マスタ情報を追加・更新

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
            if (cosbdbp.ClcLogOutputInfo == (int)ConvObjSingleBkDBParam.OutputCode.ON)
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

        #region 操作ログ出力
        /// <summary>
        /// 操作ログ出力
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int WriteOprtnHisLog(OprtnHisLogWork writeParam)
        {
            return this.WriteOprtnHisLogProc(writeParam);
        }

        /// <summary>
        /// 操作ログ出力実体
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int WriteOprtnHisLogProc(OprtnHisLogWork writeParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (this.operationLoggingDB == null)
                    this.operationLoggingDB = new OprtnHisLogDB();

                object param = (object)writeParam;
                status = this.operationLoggingDB.Write(ref param);
            }
            catch (SqlException sqlex)
            {
                status = base.WriteSQLErrorLog(sqlex);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA WriteOprtnHisLogProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA WriteOprtnHisLogProc Exception", status.ToString(), ex.Message));
            }

            return (int)status;
        }
        #endregion  //操作ログ出力

        #endregion // IConvObjSingleBkDB メンバ

    }


}
