//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価一括設定
// プログラム概要   : 売価一括設定
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Microsoft.Win32;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売価一括設定リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価一括設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SaleRateDB : RemoteDB, ISaleRateDB
    {
        /// <summary>
        /// 売価一括設定DBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.3.316</br>
        /// </remarks>
        public SaleRateDB()
            :
        base("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork", "RATERF")
        {
        }

        #region ■private member
        /// <summary>
        /// 掛率リモート
        /// </summary>
        private RateDB _rateDB = new RateDB();
        #endregion

        #region ■write
        /// <summary>
        /// 価格設定
        /// </summary>
        /// <param name="delparaObj">掛率マスタ</param>
        /// <param name="updparaObj">価格マスタ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public int Save(object delparaObj, object updparaObj ,ref string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList delRateList = delparaObj as ArrayList;
                ArrayList updRateList = updparaObj as ArrayList;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 掛率マスタ
                // 情報を削除する
                if (delRateList.Count > 0)
                {
                    status = _rateDB.DeleteSubSectionProc(delRateList, ref sqlConnection, ref sqlTransaction);
                }

                // 情報を登録する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && updRateList.Count > 0)
                {
                    status = _rateDB.WriteSubSectionProc(ref updRateList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "SaleRateDB.Save(object delparaObj,object updparaObj)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SaleRateDB.Save(object delparaObj,object updparaObj)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region ■[コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
