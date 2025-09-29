//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新メンテナンス
// プログラム概要   : コンバート対象自動更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象自動更新DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjDB : RemoteWithAppLockDB, IConvObjDB
    {

        #region 定数

        #endregion // 定数

        #region プライベートフィールド

        /// <summary>
        /// パラメータ
        /// </summary>
        private ConvObjDBParam codbp = null;

        /// <summary>
        /// 操作ログ登録リモート
        /// </summary>
        private OprtnHisLogDB OperationLoggingDB = null;

        /// <summary>
        /// 価格マスタバックアップ
        /// </summary>
        private ConvObjBackupDB cobdb = null;

        /// <summary>
        /// WebRequest Access Check
        /// </summary>
        private ConvObjDBWebRequest codbwr = null;

        /// <summary>
        /// CLCログ出力
        /// </summary>
        private ConvObjCLCLogDB coclcldb = null;

        /// <summary>
        /// ログイン情報
        /// </summary>
        private ServerLoginInfoAcquisition slia = null;

        /// <summary>
        /// コンバート対象外企業パラメータ
        /// </summary>
        private ConvObjEnterpriseParamDB coepdb = null;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象自動更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjDB()
            : base("PMCMN00145D", "Broadleaf.Application.Remoting.ParamData.ConvObjWork", "CONVOBJRF")
        {
            try
            {
                // パラメータ
                codbp = new ConvObjDBParam();

                // CLCログ出力
                coclcldb = new ConvObjCLCLogDB();

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
            }
        }
        #endregion //コンストラクタ

        #region IConvObjDB メンバ

        #region コンバート対象自動更新
        /// <summary>
        /// コンバート対象自動更新します。
        /// </summary>
        /// <param name="convObjWorkbyte">自動更新情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjAutoUpdate(ref ConvObjWork convObjWorkbyte)
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;


            try
            {
                // コンバート対象外企業パラメータ
                coepdb = new ConvObjEnterpriseParamDB();
            }
            catch (Exception ex)
            {
                // ログ出力
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjDB Exception");

                // エラーログ出力
                ClcLogOutputProc(string.Format("{0}:{1}", "ERR PMCMN00143RA ConvObjDB.ConvObjDB Exception", ex.Message));

                // 設定ファイルが存在しないまたは破損している場合中断
                throw;
            }

            try
            {
                // WebRequest Access Check Pt0
                ConvObjDBWebRequestProc((int)ConvObjDBWebRequest.WebReqChkPrm.UnauthorizedAccessPt0);

                // パラメータのキャスト
                ConvObjWork convObjWork = convObjWorkbyte as ConvObjWork;

                // ログ出力用企業コード設定
                coclcldb.EnterpriseCode = convObjWork.EnterpriseCode;

                // コンバート対象自動更新実行
                status = ConvObjAutoUpdateProc(ref convObjWork);
            }
            catch (Exception ex)
            {
                // ログ出力
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjAutoUpdate", status);

                // エラーログ出力
                ClcLogOutputProc(string.Format("{0}:{1}", "ERR PMCMN00143RA ConvObjAutoUpdate Exception", ex.Message));
            }
            finally
            {
                // WebRequest Access Check Pt1
                ConvObjDBWebRequestProc((int)ConvObjDBWebRequest.WebReqChkPrm.UnauthorizedAccessPt1);

                // ログ出力
            }

            return status;
        }

        /// <summary>
        /// コンバート対象自動更新します。
        /// </summary>
        /// <param name="convObjWorkbyte">自動更新情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjAutoUpdateProc(ref ConvObjWork convObjWorkbyte)
        {

            int status = (int)ConvObjDBParam.StatusCode.Error;       // 本メソッドの戻り値
            int stConnect = (int)ConvObjDBParam.StatusCode.Error;    // DB接続用ステータス保持
            int stTrans = (int)ConvObjDBParam.StatusCode.Error;      // DBトランザクション用ステータス保持
            int stLock = (int)ConvObjDBParam.StatusCode.Error;       // DBアプリケーションロック用ステータス保持
            int stBackup = (int)ConvObjDBParam.StatusCode.Error;     // DBバックアップ用ステータス保持
            int stConvMst = (int)ConvObjDBParam.StatusCode.Error;    // コンバート処理用ステータス保持
            int stConvObj = (int)ConvObjDBParam.StatusCode.Error;    // コンバート対象バージョン管理マスタ更新用ステータス保持

            // パラメータのキャスト
            ConvObjWork convObjWork = convObjWorkbyte as ConvObjWork;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ConvertDoubleRelease convertDoubleRelease = null;

            string enterpriseCode = string.Empty;  // 企業コード
            string resNm = string.Empty;           // ロックリソース名

            try
            {
                // データベース接続文字列取得
                stConnect = GetDataBaseConnect(ref sqlConnection);
                if (stConnect != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3001;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stConnect:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetDataBaseConnect", stConnect.ToString(), status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }

                // トランザクション開始
                stTrans = GetDataBaseTransaction(ref sqlConnection, ref sqlTransaction);
                if (stTrans != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3002; 
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stTrans:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetDataBaseTransaction", stTrans.ToString(), status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }

                // 企業コード
                enterpriseCode = convObjWork.EnterpriseCode;

                // アプリケーションロック　リソース名取得
                resNm = GetApplicationLockResourceName(ref enterpriseCode);
                if (string.IsNullOrEmpty(resNm) || string.IsNullOrEmpty(enterpriseCode))
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3003;
                    // リトライ後リソース名、企業コード取得できない場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},resNm:{1},enterpriseCode:{2},status:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetApplicationLockResourceName", resNm, enterpriseCode, status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }
                
                // アプリケーションロック
                stLock = GetApplicationLock(resNm, codbp.DbApplicationLockTimeout, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3004;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetApplicationLock", stLock.ToString(), status.ToString()));
                    // 後続処理を行わない。
                    return status;
                }

                // コンバート対象バージョン管理共通部品　情報初期化　呼び出し
                // 変換情報呼び出し
                convertDoubleRelease = new ConvertDoubleRelease();

                // 企業コード設定
                convertDoubleRelease.EnterpriseCode = enterpriseCode;

                // 変換情報初期化
                convertDoubleRelease.ReleaseInitLib();

                // コンバート対象判断
                if (ConvertObjEval(ref convertDoubleRelease) == ConvObjDBParam.CONVOBJ_OFF)
                {
                    // コンバート対象外
                    status = (int)ConvObjDBParam.StatusCode.NormalNotFound;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},CVM:{1},CVA:{2},status:{3},msg:{4}", "PMCMN00143RA ConvObjAutoUpdateProc ConvertObjEval", convertDoubleRelease.ConvertInfParam.ConvertVersionMst.ToString(), convertDoubleRelease.ConvertInfParam.ConvertVersionAsm.ToString(), status.ToString(), "コンバート対象外"));
                    // 後続処理を行わない。
                    return status;
                }

                // USER_DB 全体バックアップ情報取得
                stBackup = EnvFullBackupInfSearchProc(ref sqlConnection, ref sqlTransaction);
                if (stBackup == (int)ConvObjDBParam.StatusCode.Normal)
                {
                }
                else if (stBackup == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange)
                {
                    // 全体バックアップ範囲外（古い）
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3005;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},stBackup:{1},status:{2},msg:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc EnvFullBackupInfSearchProc", stBackup.ToString(), status.ToString(), "全体バックアップ範囲外"));
                    // 後続処理を行わない。
                    return status;
                }
                else if (stBackup == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfInterruption)
                {
                    // 全体バックアップされていない
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3006;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},stBackup:{1},status:{2},msg:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc EnvFullBackupInfSearchProc", stBackup.ToString(), status.ToString(), "全体バックアップ存在しない"));
                    // 後続処理を行わない
                    return status;
                }
                else
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3007;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stBackup:{1},status:{2},msg:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc EnvFullBackupInfSearchProc", stBackup.ToString(), status.ToString(), "全体バックアップ情報取得エラー"));
                    // 後続処理を行わない
                    return status;
                }

                // マスタ変換実行
                stConvMst = VerObjMstUpdProc(enterpriseCode, convertDoubleRelease, ref sqlConnection, ref sqlTransaction);
                if ((stConvMst == (int)ConvObjDBParam.StatusCode.Normal) || (stConvMst == (int)ConvObjDBParam.StatusCode.NormalNotFound))
                {
                    // バージョン情報更新
                    ConvObjVerMngWork convObjVerMngWork = new ConvObjVerMngWork();

                    // 企業コード
                    convObjVerMngWork.EnterpriseCode = enterpriseCode;

                    // コンバート対象バージョン
                    convObjVerMngWork.ConvertObjVer = convertDoubleRelease.ConvertInfParam.ConvertVersionAsm.ToString();

                    // コンバート対象バージョン管理マスタ更新
                    stConvObj = ConvObjVerMngWriteProc(ref convObjVerMngWork, convertDoubleRelease, ref sqlConnection, ref sqlTransaction);

                    // 戻り値セット
                    convObjWorkbyte = convObjWork;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ConvObjDB.ConvObjAutoUpdateProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjAutoUpdateProc Exception", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc Exception", status.ToString(), ex.Message));
            }
            finally
            {
                // アプリケーションロックリリース
                stLock = GetApplicationLockRelease(resNm, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3008;
                    // リトライ後エラーの場合、ログ出力
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetApplicationLockRelease", stLock.ToString(), status.ToString()));
                }

                // トランザクション終了
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (stConvObj == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                            //sqlTransaction.Rollback();

                            // 成功
                            status = (int)ConvObjDBParam.StatusCode.Normal;
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

                // 変換情報解放
                if (convertDoubleRelease != null)
                {
                    convertDoubleRelease.Dispose();
                }
            }

            return status;
        }
        #endregion // コンバート対象自動更新

        #region データベース接続

        /// <summary>
        /// データベース接続
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : データベース接続</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseConnect(ref SqlConnection sqlConnection)
        {
            int status = (int)ConvObjDBParam.StatusCode.GetDataBaseConnectError;

            sqlConnection = null;
                
            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseConnectError;
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
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // 例外エラー
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseConnectExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA GetDataBaseConnect Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
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
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseTransaction(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.GetDataBaseTransactionError;

            sqlTransaction = null;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseTransactionError;
                }

                try
                {
                    // トランザクション開始
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);
                    if ((sqlConnection != null) && (sqlTransaction != null))
                    {
                        // 成功
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // 例外エラー
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseTransactionExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA GetDataBaseTransaction Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
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
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private string GetApplicationLockResourceName(ref string enterpriseCode)
        {
            string tmpenterpriseCode = string.Empty;
            string strResourceName = string.Empty;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

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
                            if (slia == null)
                            {
                                slia = new ServerLoginInfoAcquisition();
                            }
                            tmpenterpriseCode = slia.EnterpriseCode;
                        }
                        catch (Exception ex)
                        {
                            // リソース名取得不正で空欄を返却
                            strResourceName = string.Empty;
                            // 企業コード取得できないのでログ出力後にリトライ
                            ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00143RA GetApplicationLockResourceName serverLoginInfoAcquisition Exception", retryCnt.ToString(), ex.Message));
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
                    ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00143RA GetApplicationLockResourceName Exception", retryCnt.ToString(), ex.Message));
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
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLock(string resNm, int timeout, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.GetApplicationLockError;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjDBParam.StatusCode.GetApplicationLockError;
                }

                try
                {
                    // アプリケーションロック
                    status = this.Lock(resNm, timeout, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ロック成功
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // タイムアウト
                        status = (int)ConvObjDBParam.StatusCode.GetApplicationLockTimeout;
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLock Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLock Error", retryCnt.ToString(), status.ToString(), resNm));
                    }

                }
                catch (Exception ex)
                {
                    status = (int)ConvObjDBParam.StatusCode.GetApplicationLockExError;
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00143RA GetApplicationLock Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
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
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLockRelease(string resNm, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.Error;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjDBParam.StatusCode.Error;
                }

                try
                {
                    // アプリケーションロックリリース
                    status = this.Release(resNm, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // リリース成功
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLockRelease Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // リトライ対象
                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLockRelease Error", retryCnt.ToString(), status.ToString(), resNm));
                    }
                }
                catch (Exception ex)
                {
                    // ログ出力
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00143RA GetApplicationLockRelease Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // 初期化
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //アプリケーションロックリリース

        #region コンバート対象判定

        /// <summary>
        /// コンバート対象判定
        /// </summary>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象判定</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private bool ConvertObjEval(ref ConvertDoubleRelease convertDoubleRelease)
        {

            // コンバート対象判定
            bool convStart = ConvObjDBParam.CONVOBJ_OFF;

            // マスタバージョン
            int paramConvVerMst = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;

            // アセンブリバージョン
            int paramConvVerAsm = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;

            // コンバート対象外企業判定
            bool isConvertOffEnterprise = false;

            try
            {
                // コンバート対象外企業の場合、無条件でコンバート対象外とする
                if (coepdb.ConvertOffEnterpriseCodeList != null)
                {
                    foreach (string convertOffEnterpriseCode in coepdb.ConvertOffEnterpriseCodeList)
                    {
                        if (convertOffEnterpriseCode == convertDoubleRelease.EnterpriseCode)
                        {
                            isConvertOffEnterprise = true;
                            //ログ出力
                            ClcLogOutputProc(string.Format("{0}", "INFO PMCMN00143RA ConvertObjEval コンバート対象外企業"));
                        }
                    }
                }

                if (!isConvertOffEnterprise)
                {
                    if (codbp.ConversionTargetControl == (int)ConvObjDBParam.ConvObjCode.Decide)
                    {
                        // 判断する
                        // マスタバージョン
                        paramConvVerMst = convertDoubleRelease.ConvertInfParam.ConvertVersionMst;

                        // アセンブリバージョン
                        paramConvVerAsm = convertDoubleRelease.ConvertInfParam.ConvertVersionAsm;

                        // マスタとアセンブリバージョンが異なる
                        if (paramConvVerMst != paramConvVerAsm)
                        {
                            // コンバート対象
                            convStart = ConvObjDBParam.CONVOBJ_ON;
                        }
                        // マスタバージョンなし
                        else if (paramConvVerMst == (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                        {
                            // アセンブリバージョンあり 
                            if (paramConvVerAsm != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                            {
                                // コンバート対象
                                convStart = ConvObjDBParam.CONVOBJ_ON;
                            }
                        }
                        // マスタバージョンあり
                        else if (paramConvVerMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                        {
                            // アセンブリバージョンなし
                            if (paramConvVerAsm == (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                            {
                                // コンバート対象
                                convStart = ConvObjDBParam.CONVOBJ_ON;
                            }
                        }
                    }
                    else if (codbp.ConversionTargetControl == (int)ConvObjDBParam.ConvObjCode.ForceSetting)
                    {
                        // 強制的に設定する
                        // コンバート対象
                        convStart = ConvObjDBParam.CONVOBJ_ON;
                    }
                    else if (codbp.ConversionTargetControl == (int)ConvObjDBParam.ConvObjCode.ForceCancel)
                    {
                        // 強制的に解除する
                        if (convertDoubleRelease.ConvertInfParam.ConvertVersionAsm != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                        {
                            convertDoubleRelease.ConvertInfParam.ConvertVersionAsm = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;
                        }

                        // コンバート対象
                        convStart = ConvObjDBParam.CONVOBJ_ON;
                    }
                    else
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                //ログ出力
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA ConvertObjEval Exception", ex.Message));

                // 例外スロー
                throw ex;
            }
            finally
            {
            } 
            
            return convStart;

        }

        #endregion //コンバート対象判定

        #region USER_DB　全体バックアップ情報取得

        /// <summary>
        /// USER_DB　全体バックアップ情報取得
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : USER_DB　全体バックアップ情報取得</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int EnvFullBackupInfSearchProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfError;
            int retryCnt = 0;

            if (codbp.DbFullBackupCheckControl == (int)ConvObjDBParam.CheckObjCode.OFF)
            {
                // 設定ファイルによりチェックしない
                status = (int)ConvObjDBParam.StatusCode.Normal;
            }
            else
            {
                // 検索タイプ確認
                int statusPurchase = PurchaseInfSearchProc();
                if (statusPurchase == (int)ConvObjDBParam.CheckObjCode.OFF)
                {
                    // チェックしない
                    status = (int)ConvObjDBParam.StatusCode.Normal;
                }
                else if (statusPurchase == (int)ConvObjDBParam.CheckObjCode.ON)
                {
                    // 設定ファイルによりチェックする

                    StringBuilder sqlText = null;
                    SqlCommand sqlCommand = null;
                    SqlDataReader myReader = null;

                    DateTime backupFinishDate = DateTime.MinValue;
                    DateTime nowDt = DateTime.MinValue;

                    string strDBName = string.Empty;

                    // 正常終了するまでリトライ回数分リトライする
                    while (retryCnt < codbp.RetryCount)
                    {
                        // リトライ時waitする
                        if (retryCnt > 0)
                        {
                            Thread.Sleep(codbp.RetryInterval);

                            //初期化
                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfError;
                            sqlText = null;
                            sqlCommand = null;
                            myReader = null;
                            backupFinishDate = DateTime.MinValue;
                            nowDt = DateTime.MinValue;
                            strDBName = string.Empty;
                        }

                        try
                        {
                            sqlText = new StringBuilder();
                            sqlText.Append("SELECT bs.backup_finish_date AS BS_BACKUP_FINISH_DATE " + Environment.NewLine);
                            sqlText.Append(" FROM msdb.dbo.backupset bs " + Environment.NewLine);
                            sqlText.Append(" WHERE bs.database_name = @FINDDATABESENAME " + Environment.NewLine);
                            sqlText.Append(" AND bs.backup_finish_date <= GETDATE() " + Environment.NewLine);
                            sqlText.Append(" AND bs.type = @FINDTYPE " + Environment.NewLine);
                            sqlText.Append(" ORDER BY bs.backup_finish_date DESC " + Environment.NewLine);
                            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                            //Prameterオブジェクトの作成
                            SqlParameter findParaDatabaseName = sqlCommand.Parameters.Add("@FINDDATABESENAME", SqlDbType.NChar);
                            SqlParameter findParaType = sqlCommand.Parameters.Add("@FINDTYPE", SqlDbType.Char);

                            if (string.IsNullOrEmpty(sqlConnection.Database))
                            {
                                strDBName = ConvObjDBParam.PMUSERDBName;
                            }
                            else
                            {
                                strDBName = sqlConnection.Database;
                            }
                            findParaDatabaseName.Value = SqlDataMediator.SqlSetString(strDBName);


                            findParaType.Value = SqlDataMediator.SqlSetString(ConvObjDBParam.PMUSERDBType);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                // 検索結果あり
                                backupFinishDate = SqlDataMediator.SqlGetDateTime(myReader, myReader.GetOrdinal("BS_BACKUP_FINISH_DATE"));
                                nowDt = DateTime.Now;

                                // 設定ファイルのバックアップチェック範囲
                                if (codbp.DbFullBackupCheckRangeControl == (int)ConvObjDBParam.CheckObjCode.ON)
                                {
                                    // 制限あり
                                    if (codbp.DbFullBackupCheckRangeTime == 0)
                                    {
                                        // 実行時間を起点に48時間以内
                                        if (DateTime.Compare(backupFinishDate, nowDt.AddHours(-48)) >= 0)
                                        {
                                            // チェック範囲内
                                            status = (int)ConvObjDBParam.StatusCode.Normal;
                                        }
                                        else
                                        {
                                            // チェック範囲外
                                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange;
                                        }
                                    }
                                    else
                                    {
                                        // 実行時間を起点に指定時間以内
                                        if (DateTime.Compare(backupFinishDate, nowDt.AddHours(-1 * codbp.DbFullBackupCheckRangeTime)) >= 0)
                                        {
                                            // チェック範囲内
                                            status = (int)ConvObjDBParam.StatusCode.Normal;
                                        }
                                        else
                                        {
                                            // チェック範囲外
                                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange;
                                        }
                                    }
                                }
                                else
                                {
                                    // 本処理続行　・・・　エラーにしない
                                    status = (int)ConvObjDBParam.StatusCode.Normal;
                                }
                            }
                            else
                            {
                                // 検索結果なし
                                // DB全体バックアップされていない場合、処理を中断するか制御（0：中断する、1：中断しない）
                                if (codbp.DbFullBackupSuspensionControl == (int)ConvObjDBParam.CheckObjCode.ON)
                                {
                                    // チェック範囲外
                                    status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfInterruption;
                                }
                                else
                                {
                                    // チェック範囲内
                                    status = (int)ConvObjDBParam.StatusCode.Normal;
                                }
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfSqlExError;
                            // ログ出力
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA EnvFullBackupInfSearchProc SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        }
                        catch (Exception ex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfExError;
                            // ログ出力
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA EnvFullBackupInfSearchProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
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

                        if ((status == (int)ConvObjDBParam.StatusCode.Normal) || (status == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange) || (status == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfInterruption))
                        {
                            // 正常終了のためリトライしない
                            break;
                        }
                        retryCnt += 1;
                    }
                }
                else
                {
                    // 検索タイプのUSBオプション取得エラー
                    status = statusPurchase;
                }
            }

            return status;
        }

        #endregion //USER_DB　全体バックアップ情報取得

        #region 検索タイプのUSBオプション取得

        /// <summary>
        /// 検索タイプのUSBオプション取得
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索タイプのUSBオプション取得</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int PurchaseInfSearchProc()
        {
            int status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfPurchaseError;
            int retryCnt = 0;

            if (codbp.SearchTypeOptionCheckControl == (int)ConvObjDBParam.CheckObjCode.OFF)
            {
                // 設定ファイルによりチェックしない
                status = (int)ConvObjDBParam.CheckObjCode.ON;
            }
            else
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= codbp.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(codbp.RetryInterval);
                    }

                    try
                    {
                        if (slia == null)
                        {
                            slia = new ServerLoginInfoAcquisition();
                        }

                        // 検索タイプ取得
                        PurchaseStatus psK = slia.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_SUB_K_Type);
                        PurchaseStatus psJ = slia.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_SUB_J_Type);
                        PurchaseStatus psM = slia.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_SUB_M_Type);

                        if ((psK == PurchaseStatus.Contract) && (psJ != PurchaseStatus.Contract) && (psM != PurchaseStatus.Contract))
                        {
                            // 検索タイプ（Kタイプ：ON、Jタイプ：OFF、Mタイプ：OFF）の場合、チェックしない
                            status = (int)ConvObjDBParam.CheckObjCode.OFF;
                        }
                        else
                        {
                            status = (int)ConvObjDBParam.CheckObjCode.ON;
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfPurchaseExError;

                        // ログ出力
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "PMCMN00143RA PurchaseInfSearchProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                    }

                    if ((status == (int)ConvObjDBParam.CheckObjCode.ON) || (status == (int)ConvObjDBParam.CheckObjCode.OFF))
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            return status;
        }

        #endregion //検索タイプのUSBオプション取得


        #region 価格マスタコンバート
        /// <summary>
        /// 価格マスタコンバート
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 価格マスタコンバート</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int VerObjMstUpdProc(string enterpriseCode, ConvertDoubleRelease convertDoubleRelease, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.VerObjMstUpdProcError;
            int stMstConv = (int)ConvObjDBParam.StatusCode.MstUpdExError;
            int stBackup = (int)ConvObjDBParam.StatusCode.DataTableBackupExError;


            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            SqlDataAdapter sda = null;
            DataTable dt = null;
            DataRow dr = null;
            SqlBulkCopy sbc = null;
            int iRowCnt = 0;
            SqlDataReader sdr = null;
            int mstUpdateCnt = 0; // 更新用マスタ取得件数

            string tmpTable = string.Empty;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //初期化
                    status = (int)ConvObjDBParam.StatusCode.VerObjMstUpdProcError;
                    stMstConv = (int)ConvObjDBParam.StatusCode.MstUpdExError;
                    stBackup = (int)ConvObjDBParam.StatusCode.DataTableBackupExError;
                    sqlText = null;
                    sqlCommand = null;
                    sda = null;
                    dt = null;
                    dr = null;
                    sbc = null;
                    iRowCnt = 0;
                    sdr = null;
                    mstUpdateCnt = 0; // 更新用マスタ取得件数
                    tmpTable = string.Empty;
                }

                try
                {
                    // 一時テーブル名作成
                    tmpTable = "#CONVOBJTMPTBL" + Guid.NewGuid().ToString().Replace("-", string.Empty);

                    #region XACT_ABORT ON
                    
                    status = (int)ConvObjDBParam.StatusCode.XactAbortOn;

                    try
                    {
                        sqlText = new StringBuilder();
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                        // 例外の対応のためオプションをONにしている
                        // 例外メッセージ：「処理の結果セットを含む一括挿入は、XACT_ABORT をオンにして実行する必要があります。」
                        // 例外個所：DataReaderループ内のsbc.WriteToServer(dt);
                        // OutOfMemory対応で1行ずつの処理にしたため発生するようになった
                        # region [SELECT文]
                        sqlText.Append("SET XACT_ABORT ON " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException sqlex)
                    {
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA XactAbortOn SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        // 例外スロー
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA XactAbortOn Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                        // 例外スロー
                        throw ex;
                    }
                    finally
                    {
                    }

                    #endregion XACT_ABORT ON

                    #region 価格マスタ件数取得

                    status = (int)ConvObjDBParam.StatusCode.MstCntGet;

                    try
                    {

                        sqlText = new StringBuilder();
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                        // 価格マスタ全件取得

                        # region [SELECT文]
                        sqlText.Append("SELECT " + Environment.NewLine);
                        sqlText.Append(" COUNT(*) AS MSTALLCOUNT" + Environment.NewLine);
                        sqlText.Append(" FROM GOODSPRICEURF " + Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = enterpriseCode;

                        sdr = sqlCommand.ExecuteReader();


                        if (sdr.Read())
                        {
                            coclcldb.MstCnt = SqlDataMediator.SqlGetInt32(sdr, sdr.GetOrdinal("MSTALLCOUNT"));
                        }
                        else
                        {
                            coclcldb.MstCnt = 0;
                        }

                        // DataReaderクリア
                        if (sdr != null && !sdr.IsClosed)
                        {
                            sdr.Close();
                        }

                    }
                    catch (SqlException sqlex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstCntGetSqlExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA MstCntGet SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        // 例外スロー
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstCntGetExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA MstCntGet Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                        // 例外スロー
                        throw ex;
                    }

                    #endregion // 価格マスタ件数取得

                    # region 価格マスタ取得

                    status = (int)ConvObjDBParam.StatusCode.MstGet;

                    try
                    {

                        sqlText = new StringBuilder();
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

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
                        findParaEnterpriseCode.Value = enterpriseCode;

                        sdr = sqlCommand.ExecuteReader();
                    }
                    catch (SqlException sqlex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstGetSqlExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA MstGet SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        // 例外スロー
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstGetExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA MstGet Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                        // 例外スロー
                        throw ex;
                    }

                    # endregion  // 価格マスタ取得

                    // 更新対象が1件以上の場合
                    if (sdr.HasRows)
                    {
                        #region DataTable作成
                        status = (int)ConvObjDBParam.StatusCode.DataTableCreate;

                        try
                        {
                            sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);
                            dt = CreateSchemaDataTable(sqlCommand);
                        }
                        catch (Exception ex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA DataTableCreate Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            throw ex;
                        }
                        finally
                        {
                        }
                        #endregion // DataTable作成

                        #region 一時テーブル作成

                        status = (int)ConvObjDBParam.StatusCode.TempTableCreate;

                        try
                        {
                            sqlText = new StringBuilder();
                            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                            sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                            sqlText.Append("SELECT " + Environment.NewLine);
                            sqlText.Append(" * " + Environment.NewLine);
                            sqlText.Append(" INTO " + Environment.NewLine);
                            sqlText.Append(tmpTable + Environment.NewLine);
                            sqlText.Append(" FROM " + Environment.NewLine);
                            sqlText.Append("  GOODSPRICEURF " + Environment.NewLine);
                            sqlText.Append(" WHERE " + Environment.NewLine);
                            sqlText.Append("  1 = 0 " + Environment.NewLine);

                            sqlCommand.CommandText = sqlText.ToString();

                            iRowCnt = sqlCommand.ExecuteNonQuery();

                        }
                        catch (SqlException sqlex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.TempTableCreateSqlExError;
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA TempTableCreate SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                            // 例外スロー
                            throw sqlex;
                        }
                        catch (Exception ex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA TempTableCreate Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            // 例外スロー
                            throw ex;
                        }

                        #endregion // 一時テーブル作成

                        #region 価格マスタ単一バックアップインスタンス生成
                        status = (int)ConvObjDBParam.StatusCode.ConvObjBackupCreate;
                        try
                        {
                            cobdb = new ConvObjBackupDB();
                        }
                        catch (Exception ex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.ConvObjBackupCreateExError;
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA new ConvObjBackupDB Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            // 例外スロー
                            throw ex;
                        }
                        finally
                        {
                        }
                        #endregion // 価格マスタ単一バックアップインスタンス生成

                        while (sdr.Read())
                        {
                            mstUpdateCnt++;

                            #region 価格マスタ展開

                            status = (int)ConvObjDBParam.StatusCode.DataTableDeploy;

                            try
                            {
                                dr = DeployDataTable(sdr, dt);
                            }
                            catch (Exception ex)
                            {
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA DataTableDeploy Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            }
                            finally
                            {
                            }

                            #endregion // 価格マスタ展開

                            #region 価格マスタを単一バックアップ

                            status = (int)ConvObjDBParam.StatusCode.DataTableBackup;

                            try
                            {
                                if (codbp.MstBackupControl == (int)ConvObjDBParam.CheckObjCode.ON)
                                {
                                    // 取得した価格マスタを単一バックアップ
                                    if (cobdb != null)
                                    {
                                        if (convertDoubleRelease.ConvertInfParam.ConvertVersionMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                                        {
                                            DataRow drBk = dt.NewRow();
                                            drBk.ItemArray = dr.ItemArray;
                                            // コンバート済みの場合、解除してバックアップする
                                            convertDoubleRelease.EnterpriseCode = Convert.ToString(drBk["ENTERPRISECODERF"]);
                                            convertDoubleRelease.GoodsMakerCd = Convert.ToInt32(drBk["GOODSMAKERCDRF"]);
                                            convertDoubleRelease.GoodsNo = Convert.ToString(drBk["GOODSNORF"]);
                                            convertDoubleRelease.ConvertSetParam = Convert.ToDouble(drBk["LISTPRICERF"]);

                                            convertDoubleRelease.ReleaseProc();

                                            drBk["LISTPRICERF"] = convertDoubleRelease.ConvertInfParam.ConvertGetParam;

                                            stBackup = cobdb.ConvObjBackup(drBk);

                                        }
                                        else
                                        {
                                            stBackup = cobdb.ConvObjBackup(dr);
                                        }

                                        if (stBackup != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                            // 単一バックアップ時にエラー発生
                                            status = (int)ConvObjDBParam.StatusCode.DataTableBackupError2027;
                                            // ログ出力
                                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},stBackup:{3}", "ERR PMCMN00143RA ConvObjBackupDB Error", retryCnt.ToString(), status.ToString(), stBackup.ToString()));
                                        }
                                    }
                                    else
                                    {
                                        // 単一バックアップ時にエラー発生
                                        status = (int)ConvObjDBParam.StatusCode.DataTableBackupError2028;
                                        // ログ出力
                                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},stBackup:{3}", "ERR PMCMN00143RA ConvObjBackupDB Error null", retryCnt.ToString(), status.ToString(), stBackup.ToString()));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // 単一バックアップ時にエラー発生
                                status = (int)ConvObjDBParam.StatusCode.DataTableBackupExError;
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA ConvObjBackupDB Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                // 例外スロー
                                throw ex;
                            }

                            #endregion // 価格マスタを単一バックアップ

                            if (stBackup == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                #region 変換

                                status = (int)ConvObjDBParam.StatusCode.DataTableConv;

                                try
                                {
                                    convertDoubleRelease.EnterpriseCode = Convert.ToString(dr["ENTERPRISECODERF"]);
                                    convertDoubleRelease.GoodsMakerCd = Convert.ToInt32(dr["GOODSMAKERCDRF"]);
                                    convertDoubleRelease.GoodsNo = Convert.ToString(dr["GOODSNORF"]);
                                    convertDoubleRelease.ConvertSetParam = Convert.ToDouble(dr["LISTPRICERF"]);

                                    convertDoubleRelease.ReleaseConvertProc();

                                    dr["LISTPRICERF"] = convertDoubleRelease.ConvertInfParam.ConvertGetParam;

                                    // 変換後DataTableに追加
                                    dt.Rows.Add(dr);

                                }
                                catch (Exception ex)
                                {
                                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA DataTableConv Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                    // 例外スロー
                                    throw ex;
                                }

                                #endregion // 変換

                                #region 変換後DataTableを一時テーブルにBulkInsert

                                if (mstUpdateCnt >= codbp.MstUpdateBreakCount)
                                {
                                    status = (int)ConvObjDBParam.StatusCode.TempTableIns;

                                    try
                                    {
                                        using (sbc = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
                                        {
                                            sbc.DestinationTableName = tmpTable;
                                            sbc.BulkCopyTimeout = codbp.DbCommandTimeout;
                                            sbc.WriteToServer(dt);
                                            sbc.Close();
                                        }
                                    }
                                    catch (SqlException sqlex)
                                    {
                                        status = (int)ConvObjDBParam.StatusCode.TempTableInsSqlExError;
                                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA BulkInsert SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                                        // 例外スロー
                                        throw sqlex;
                                    }
                                    catch (Exception ex)
                                    {
                                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA BulkInsert Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                        // 例外スロー
                                        throw ex;
                                    }

                                    // DataTableをクリアする
                                    if (dt != null)
                                    {
                                        dt.Clear();
                                    }

                                    mstUpdateCnt = 0;
                                }
                                #endregion // 変換後DataTableを一時テーブルにBulkInsert

                            }

                            // 処理行数をインクリメント
                            coclcldb.UpdateMstCnt++;
                        }

                        if (stBackup == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ループ後処理

                            #region バックアップstream解放
                            status = (int)ConvObjDBParam.StatusCode.ConvObjBackupDispose;
                            try
                            {
                                cobdb.Dispose();
                                cobdb = null;
                            }
                            catch (Exception ex)
                            {
                                status = (int)ConvObjDBParam.StatusCode.ConvObjBackupDisposeExError;
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA ConvObjBackupDispose Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            }
                            finally
                            {
                            }
                            #endregion // バックアップstream解放

                            #region 変換後DataTableを一時テーブルにBulkInsert

                            if (dt.Rows.Count > 0)
                            {
                                status = (int)ConvObjDBParam.StatusCode.TempTableLastIns;

                                try
                                {
                                    using (sbc = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
                                    {
                                        sbc.DestinationTableName = tmpTable;
                                        sbc.BulkCopyTimeout = codbp.DbCommandTimeout;
                                        sbc.WriteToServer(dt);
                                        sbc.Close();
                                    }
                                }
                                catch (SqlException sqlex)
                                {
                                    status = (int)ConvObjDBParam.StatusCode.TempTableLastInsSqlExError;
                                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA LastBulkInsert SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                                    // 例外スロー
                                    throw sqlex;
                                }
                                catch (Exception ex)
                                {
                                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA LastBulkInsert Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                    // 例外スロー
                                    throw ex;
                                }

                                // 不要になったDataTableをクリアする
                                if (dt != null)
                                {
                                    dt.Clear();
                                    dt.Dispose();
                                    dt = null;
                                }
                            }

                            #endregion // 変換後DataTableを一時テーブルにBulkInsert

                            #region 価格マスタ更新

                            status = (int)ConvObjDBParam.StatusCode.MstUpd;

                            try
                            {
                                sqlText = new StringBuilder();
                                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                                sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                                sqlText.Append("UPDATE GPU " + Environment.NewLine);
                                sqlText.Append(" SET " + Environment.NewLine);
                                sqlText.Append(" GPU.LISTPRICERF = UT.LISTPRICERF " + Environment.NewLine);
                                sqlText.Append(" FROM " + Environment.NewLine);
                                sqlText.Append(" GOODSPRICEURF GPU " + Environment.NewLine);
                                sqlText.Append(" JOIN " + tmpTable + " UT " + Environment.NewLine);
                                sqlText.Append(" ON  GPU.ENTERPRISECODERF = UT.ENTERPRISECODERF " + Environment.NewLine);
                                sqlText.Append(" AND GPU.GOODSMAKERCDRF = UT.GOODSMAKERCDRF " + Environment.NewLine);
                                sqlText.Append(" AND GPU.GOODSNORF = UT.GOODSNORF " + Environment.NewLine);
                                sqlText.Append(" AND GPU.PRICESTARTDATERF = UT.PRICESTARTDATERF " + Environment.NewLine);

                                sqlCommand.CommandText = sqlText.ToString();

                                iRowCnt = sqlCommand.ExecuteNonQuery();

                                if (iRowCnt > 0)
                                {
                                    stMstConv = (int)ConvObjDBParam.StatusCode.Normal;
                                }
                                else
                                {
                                    // 更新対象なし
                                    stMstConv = (int)ConvObjDBParam.StatusCode.NormalNotFound;
                                }

                            }
                            catch (SqlException sqlex)
                            {
                                status = (int)ConvObjDBParam.StatusCode.MstUpdSqlExError;
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA MstUpd SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                                // 例外スロー
                                throw sqlex;
                            }
                            catch (Exception ex)
                            {
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA MstUpd Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                // 例外スロー
                                throw ex;
                            }
                            #endregion // 価格マスタ更新
                        }

                        #region 一時テーブル削除

                        status = (int)ConvObjDBParam.StatusCode.TempTableDelete;

                        try
                        {
                            sqlText = new StringBuilder();
                            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                            sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                            sqlText.Append("DROP TABLE " + tmpTable + " " + Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();

                            sqlCommand.ExecuteNonQuery();

                            status = (int)ConvObjDBParam.StatusCode.Normal;
                            if (stMstConv == (int)ConvObjDBParam.StatusCode.NormalNotFound)
                            {
                                status = stMstConv;
                            }

                        }
                        catch (SqlException sqlex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA TempTableDelete SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                            status = (int)ConvObjDBParam.StatusCode.TempTableDeleteSqlExError;
                            // 例外スロー
                            throw sqlex;
                        }
                        catch (Exception ex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA TempTableDelete Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            // 例外スロー
                            throw ex;
                        }
                        #endregion // 一時テーブル削除
                    }
                    else
                    {
                        // 更新対象なし
                        status = (int)ConvObjDBParam.StatusCode.NormalNotFound;
                    }
                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex, "ConvObjDB.VerObjMstUpdProc SqlException", status);
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA VerObjMstUpdProc SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "ConvObjDB.VerObjMstUpdProc ex", status);
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA VerObjMstUpdProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }

                    if (sda != null)
                    {
                        sda.Dispose();
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
                }

                if ((status == (int)ConvObjDBParam.StatusCode.Normal) || (status == (int)ConvObjDBParam.StatusCode.NormalNotFound))
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }
        #endregion  //価格マスタコンバート

        #region コンバート対象バージョン管理マスタ情報を追加・更新
        /// <summary>
        /// コンバート対象バージョン管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="convObjVerMngWork">追加・更新するコンバート対象バージョン管理マスタ情報</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バージョン管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjVerMngWriteProc(ref ConvObjVerMngWork convObjVerMngWork, ConvertDoubleRelease convertDoubleRelease, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.VerObjVerMstUpd;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ConvObjVerMngWork al = new ConvObjVerMngWork();

            try
            {
                if (convObjVerMngWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                    # region [SELECT文]
                    sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append("    ,CONVERTOBJVERRF" + Environment.NewLine);
                    sqlText.Append(" FROM CONVOBJVERMNGRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = convObjVerMngWork.EnterpriseCode;

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        # region [UPDATE文]
                        StringBuilder sqlText_UPDATE = new StringBuilder();
                        sqlText_UPDATE.Append("UPDATE CONVOBJVERMNGRF SET" + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONVERTOBJVERRF=@CONVERTOBJVER" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)convObjVerMngWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {

                        # region [INSERT文]
                        StringBuilder sqlText_INSERT = new StringBuilder();
                        sqlText_INSERT.Append("INSERT INTO CONVOBJVERMNGRF " + Environment.NewLine);
                        sqlText_INSERT.Append(" (CREATEDATETIMERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDATEDATETIMERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,ENTERPRISECODERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,FILEHEADERGUIDRF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDEMPLOYEECODERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDASSEMBLYID1RF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDASSEMBLYID2RF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,LOGICALDELETECODERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,CONVERTOBJVERRF " + Environment.NewLine);
                        sqlText_INSERT.Append("  ) VALUES ( " + Environment.NewLine);
                        sqlText_INSERT.Append("   @CREATEDATETIME " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDATEDATETIME " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@FILEHEADERGUID " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDEMPLOYEECODE " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDASSEMBLYID1 " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDASSEMBLYID2 " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@LOGICALDELETECODE " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@CONVERTOBJVER " + Environment.NewLine);
                        sqlText_INSERT.Append("  )" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_INSERT.ToString();
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)convObjVerMngWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraConvertObjVer = sqlCommand.Parameters.Add("@CONVERTOBJVER", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjVerMngWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjVerMngWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(convObjVerMngWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(convObjVerMngWork.LogicalDeleteCode);
                    paraConvertObjVer.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.ConvertObjVer);

                    sqlCommand.ExecuteNonQuery();
                    al = convObjVerMngWork;

                }

                status = (int)ConvObjDBParam.StatusCode.Normal;

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjDBParam.StatusCode.VerObjVerMstUpdSqlExError;
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ConvObjDB.ConvObjVerMngWriteProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA ConvObjVerMngWriteProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjVerMngWriteProc", status);
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00143RA ConvObjVerMngWriteProc Exception", status.ToString(), ex.Message));
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

            convObjVerMngWork = al;

            return status;
        }
        #endregion  //コンバート対象バージョン管理マスタ情報を追加・更新

        #region DataTable作成
        /// <summary>
        /// 価格マスタ構造のDataTableを作成します。
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <returns>DataTableオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : DataTable作成</br>
        /// <br>Programmer : 佐々木亘</br>
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

                sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                // 価格マスタテーブル情報取得
                sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCommand;
                sda.FillSchema(dt, SchemaType.Source);
                
                // 大文字小文字を区別する
                dt.CaseSensitive = true;
            }
            catch (SqlException sqlex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA CreateSchemaDataTable SqlException", sqlex.Message));
                throw sqlex;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA CreateSchemaDataTable Exception", ex.Message));
                throw ex;
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
        /// <br>Programmer : 佐々木亘</br>
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
            catch (SqlException sqlex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA DeployDataTable SqlException", sqlex.Message));
                throw sqlex;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA DeployDataTable Exception", ex.Message));
                throw ex;
            }
            finally
            {
            }

            return dr;
        }
        #endregion // DataTable作成

        #region コンバート対象自動更新WebRequest
        /// <summary>
        /// コンバート対象自動更新WebRequest
        /// </summary>
        /// <param name="checkParam">チェックパラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新WebRequest</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjDBWebRequestProc(int checkParam)
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;
            try
            {
                if (codbp.WebAccessCheckControl == (int)ConvObjDBParam.CheckObjCode.ON)
                {
                    // WebRequest Access Check
                    if (codbwr == null)
                    {
                        codbwr = new ConvObjDBWebRequest();
                    }
                    codbwr.ConvObjDBWebReqRes(checkParam);
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

        #region 操作ログ出力
        /// <summary>
        /// 操作ログ出力
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
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
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int WriteOprtnHisLogProc(OprtnHisLogWork writeParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (this.OperationLoggingDB == null)
                    this.OperationLoggingDB = new OprtnHisLogDB();

                object param = (object)writeParam;
                status = this.OperationLoggingDB.Write(ref param);
            }
            catch (SqlException sqlex)
            {
                status = base.WriteSQLErrorLog(sqlex);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA WriteOprtnHisLogProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00143RA WriteOprtnHisLogProc Exception", status.ToString(), ex.Message));
            }

            return (int)status;
        }
        #endregion  //操作ログ出力

        #endregion // IConvObjDB メンバ

    }


}
