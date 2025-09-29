using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ロックエスカレーション防止部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : インテント排他ロックをかけてロックエスカレーションを起こさないようにします。</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2011.08.22</br>
    /// </remarks>
    public class IntentExclusiveLockComponent : RemoteDB
    {
        #region Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IntentExclusiveLockComponent()
        {
        }

        #endregion

        #region PrivateMember

        private SqlConnection _sqlConnection   = null;
        private SqlTransaction _sqlTransaction = null;

        #endregion

        #region IntentLock

        /// <summary>
        /// インテント排他ロック
        /// </summary>
        /// <param name="targetTables">対象のテーブル</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : テーブルにインテント排他ロックをかけてロックエスカレーションを防ぎます</br>
        /// <br>Programmer : qijh</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int IntentLock(string[] targetTables)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // コネクション文字列取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // コネクションクラスインスタンス
                this._sqlConnection = new SqlConnection(connectionText);
                // コネクションオープン
                this._sqlConnection.Open();
                // トランザクション開始
                this._sqlTransaction = this._sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                // SQLコマンドクラスインスタンス
                SqlCommand sqlCommand = new SqlCommand();
                // コネクション、トランザクションをプロパティにセット
                sqlCommand.Connection  = this._sqlConnection;
                sqlCommand.Transaction = this._sqlTransaction;
                foreach( string item in targetTables )
                {
                    // インテント排他ロックをかける
                    sqlCommand.CommandText = "SELECT * FROM " + item + " WITH(UPDLOCK,HOLDLOCK) WHERE 1 = 0 ";
                    //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                    sqlCommand.CommandTimeout = 600;
                    //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                    // コマンド実行
                    sqlCommand.ExecuteNonQuery();
                    // ノーマルステータスをセット
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch( SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex , "IntentExclusiveLockComponent.IntentLock",status);
                FinalProc();
            }
            catch( Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex , "IntentExclusiveLockComponent.IntentLock",status);
                FinalProc();
            }
            finally
            {
            }

            return status;
        }

        #endregion

        #region UnLock

        /// <summary>
        /// ロック解除
        /// </summary>
        /// <returns>status</returns>
        public int UnLock()
        {
            FinalProc();
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion

        #region FinalProc

        /// <summary>
        /// 終了処理
        /// </summary>
        private void FinalProc()
        {
            if (this._sqlConnection != null)
            {
                if (this._sqlTransaction != null)
                {
                    this._sqlTransaction.Rollback();
                    this._sqlTransaction.Dispose();
                }
                this._sqlConnection.Close();
                this._sqlConnection.Dispose();
                this._sqlConnection = null;
            }
        }

        #endregion
    }
}
