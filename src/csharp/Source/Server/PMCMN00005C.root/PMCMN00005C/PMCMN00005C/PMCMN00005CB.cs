using System;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// アプリケーション リソースに対するロック機能を有した RemoteDB クラスです。
    /// </summary>
    /// <remarks>
    /// 本クラスはアプリケーション リソースロックを行う際にインスタンス化して該当メソッドを
    /// 実行しても構いませんし、RemoteDB の替わりに継承元として指定して該当メソッドを実行
    /// しても構いません。
    /// </remarks>
    public partial class RemoteWithAppLockDB : RemoteDB
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RemoteWithAppLockDB()
            : base()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="parmClassName"></param>
        /// <param name="BaseTableName"></param>
        public RemoteWithAppLockDB(string assemblyName, string parmClassName, string BaseTableName)
            : base(assemblyName, parmClassName, BaseTableName)
        {

        }

        # region [コネクション・トランザクション関係]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.12.09</br>
        /// </remarks>
        public SqlConnection CreateConnection(bool open)
        {
            // CreateTransaction に名前を併せただけ…
            return this.CreateSqlConnection(open);
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection">データベース接続情報</param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            return this.CreateTransaction(ref sqlconnection, ConstantManagement.DB_IsolationLevel.ctDB_Default);
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection">データベース接続情報</param>
        /// <param name="isolationLevel">トランザクション分離レベルを指定</param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public SqlTransaction CreateTransaction(ref SqlConnection sqlconnection, ConstantManagement.DB_IsolationLevel isolationLevel)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)isolationLevel);
            }

            return retSqlTransaction;
        }

        # endregion

        # region [システムロック関係]

        // デフォルトのタイムアウト時間を㍉秒で指定する
        private const int DEFAULT_TIMEOUT = 300000;  //  5分

        /// <summary>
        /// ロック リソース名を取得します。
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <returns>ロック リソース名</returns>
        public string GetResourceName(string enterprisecode)
        {
            return string.Format("{0}-{1}-{2}", enterprisecode,
                                                ConstantManagement_SF_PRO.ProductCode,
                                                this.GetType().FullName);
        }

        /// <summary>
        /// アプリケーション リソースにロックを設定します。
        /// </summary>
        /// <param name="resourcename">ロック リソース名を指定します。</param>
        /// <param name="connection">データベースの接続情報を指定します。</param>
        /// <param name="transaction">トランザクション情報を指定します。</param>
        /// <remarks>ロック タイムアウトはデフォルト タイムアウトに準拠します。</remarks>
        /// <returns>STATUS</returns>
        public int Lock(string resourcename, SqlConnection connection, SqlTransaction transaction)
        {
            return ExclusiveLockControl(LockControl.Locke, connection, transaction, resourcename, DEFAULT_TIMEOUT);
        }

        /// <summary>
        /// アプリケーション リソースにロックを設定します。
        /// </summary>
        /// <param name="resourcename">ロック リソース名を指定します。</param>
        /// <param name="timeout">ロック タイムアウト値をミリ秒単位で指定します。　ロックを待機しない場合は <b>0</b> を指定します。</param>
        /// <param name="connection">データベースの接続情報を指定します。</param>
        /// <param name="transaction">トランザクション情報を指定します。</param>
        /// <returns>STATUS</returns>
        public int Lock(string resourcename, int timeout, SqlConnection connection, SqlTransaction transaction)
        {
            return ExclusiveLockControl(LockControl.Locke, connection, transaction, resourcename, timeout);
        }

        /// <summary>
        /// アプリケーション リソースのロックを解放します。
        /// </summary>
        /// <param name="resourcename">ロック リソース名を指定します。</param>
        /// <param name="connection">データベースの接続情報を指定します。</param>
        /// <param name="transaction">トランザクション情報を指定します。</param>
        /// <returns>STATUS</returns>
        public int Release(string resourcename, SqlConnection connection, SqlTransaction transaction)
        {
            return ExclusiveLockControl(LockControl.Release, connection, transaction, resourcename, 0);
        }

        # endregion

        /// <summary>
        /// 排他制御を指定する列挙体です。
        /// </summary>
        public enum LockControl
        {
            /// <summary>ロックを指定します。</summary>
            Locke,
            /// <summary>ロック解除を指定します。</summary>
            Release
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="resourcename"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private int ExclusiveLockControl(LockControl mode, SqlConnection connection, SqlTransaction transaction, string resourcename, int timeout)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand command = null;

            try
            {
                command = new SqlCommand("", connection, transaction);
                command.CommandType = CommandType.StoredProcedure;                                                // コマンドタイプの設定(ストアドプロシージャ)

                // コマンドタイムアウトを指定ロックタイムアウト(秒変換)＋10秒に設定
                // ※コマンドタイムアウトの標準値が30秒の為、指定ロックタイムアウトが30秒以上に設定されると
                //   ロックタイムアウトよりも先にコマンドタイムアウトが発生してしまうのを回避する。
                command.CommandTimeout = (int)(timeout / 1000) + 10;

                // 戻り値を受け取るパラメータを指定
                command.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                // sp_getapplock, sp_releaseapplock 共通パラメータ
                command.Parameters.Add("@Resource", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString(resourcename);
                command.Parameters.Add("@LockOwner ", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString("Transaction");

                if (mode == LockControl.Locke)
                {
                    // ロックをかける
                    command.CommandText = "sp_getapplock";
                    command.Parameters.Add("@LockMode ", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString("Exclusive");
                    command.Parameters.Add("@LockTimeout ", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt(timeout);
                }
                else
                {
                    // ロックを開放する
                    command.CommandText = "sp_releaseapplock";
                }

                command.ExecuteNonQuery();

                int execRet = Convert.ToInt32(command.Parameters["ReturnValue"].Value);

                if (execRet == 0)
                {
                    // 戻り値が 0 の場合は Lock, Release 共に処理成功
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (mode == LockControl.Locke && execRet == 1)
                {
                    // 互換性の無い他のロックが解放されるのを待機してから、ロックが許可されました。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (mode == LockControl.Locke && execRet == -1)
                {
                    // ロックタイムアウト
                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                }
                else
                {
                    // その他のエラー
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, string.Format(" {0}.{1} ResourceName:{2} ", this.GetType().Name, mode.ToString(), resourcename), ex.Number);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, string.Format(" {0}.{1} ResourceName:{2} ", this.GetType().Name, mode.ToString(), resourcename), status);
            }
            finally
            {
                if (command != null)       
                {
                    command.Cancel();
                    command.Dispose();
                }
            }

            return status;
        }
    }
}
