//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 一括リアル更新
// プログラム概要   : 一括リアル更新DBリモートオブジェクト。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 一括リアル更新READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 一括リアル更新READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    [Serializable]
    public class AllRealUpdToolDB : RemoteWithAppLockDB, IAllRealUpdToolDB
    {
        # region ■ Constructor ■
        /// <summary>
        /// 一括リアル更新処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括リアル更新処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public AllRealUpdToolDB()
        {
            this._monthlyTtlSalesUpdDB = new MonthlyTtlSalesUpdDB();
            this._monthlyTtlStockUpdDB = new MonthlyTtlStockUpdDB();
        }
        #endregion

        # region ■ Private Members ■
        // 売上月次集計データ更新DBリモートオブジェクト
        MonthlyTtlSalesUpdDB _monthlyTtlSalesUpdDB = null;
        // 仕入月次集計データ更新リモートオブジェクト
        MonthlyTtlStockUpdDB _monthlyTtlStockUpdDB = null;
        #endregion

        #region ■ 一括リアル更新処理 ■
        /// <summary>
        /// 一括リアル更新処理
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">売上月次集計リモート用のパラメータクラス</param>
        /// <param name="mTtlStockUpdParaWork">仕入月次集計リモート用のパラメータクラス</param>
        /// <param name="procDiv">処理区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  一括リアル更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.12.24</br>
        /// </remarks>
        public int AllRealUpdProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, MTtlStockUpdParaWork mTtlStockUpdParaWork, int procDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int statusBak = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ShareCheckInfo info = new ShareCheckInfo();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();
                //●トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                #region 排他制御
                //システムロック(企業)
                info.Keys.Add(mTtlSalesUpdParaWork.EnterpriseCode, ShareCheckType.Enterprise, "", "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
                    return status;
                }
                #endregion

                // 処理区分は売上の場合、
                if (procDiv == 0)
                {
                    // 売上月次集計データ更新処理
                    status = _monthlyTtlSalesUpdDB.ReCountProc(mTtlSalesUpdParaWork, ref sqlConnection, ref sqlTransaction);
                }
                // 処理区分は仕入の場合、
                else if (procDiv == 1)
                {
                    // 仕入月次集計データ更新処理
                    status = _monthlyTtlStockUpdDB.ReCountProc(mTtlStockUpdParaWork, ref sqlConnection, ref sqlTransaction);
                }
                // 処理区分は売上、仕入の場合、
                else if (procDiv == 2)
                {
                    // 売上月次集計データ更新処理
                    status = _monthlyTtlSalesUpdDB.ReCountProc(mTtlSalesUpdParaWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            statusBak = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // 仕入月次集計データ更新処理
                        status = _monthlyTtlStockUpdDB.ReCountProc(mTtlStockUpdParaWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_EOF && statusBak == (int)ConstantManagement.DB_Status.ctDB_EOF)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                }
                else
                {
                    // 処理区分不正
                }

            }
            catch (Exception ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "AllRealUpdToolDB.AllRealUpdProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = st;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

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
    }
}
