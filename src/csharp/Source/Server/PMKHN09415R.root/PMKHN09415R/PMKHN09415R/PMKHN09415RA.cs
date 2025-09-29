//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ引用登録
// プログラム概要   : 掛率マスタ引用登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率マスタ引用登録リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ引用登録の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.5.13</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RateQuoteDB : RemoteDB, IRateQuoteDB
    {
        #region ■private member
        /// <summary>
        /// 価格リモート
        /// </summary>
        private RateDB _rateDB = new RateDB();
        #endregion

        #region ・追加
        /// <summary>
        /// データ追加処理
        /// </summary>
        /// <param name="rateInsertList">追加リスト</param>
        /// <param name="rateDeleteList">削除リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Write(ref object rateInsertList, ref object rateDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraRateInsertList = rateInsertList as ArrayList;
                ArrayList paraRateDeleteList = rateDeleteList as ArrayList;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 掛率マスタ登録
                if (paraRateInsertList != null && paraRateInsertList.Count != 0)
                {
                    // 更新日時
                    foreach (RateWork rateWork in paraRateInsertList)
                    {
                        rateWork.UpdateDateTime = DateTime.MinValue;
                    }
                    status = _rateDB.WriteSubSectionProc(ref paraRateInsertList, ref sqlConnection, ref sqlTransaction);
                }

                // 2009/06/09　対応した　追加の場合、論理削除区分データ更新しない
                // 掛率マスタ登録
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    if (paraRateDeleteList != null && paraRateDeleteList.Count != 0)
                //    {
                //        // 情報を削除する
                //        status = _rateDB.DeleteSubSectionProc(paraRateDeleteList, ref sqlConnection, ref sqlTransaction);
                //        // 情報を登録する
                //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            // 更新日時
                //            foreach (RateWork rateWork in paraRateDeleteList)
                //            {
                //                rateWork.UpdateDateTime = DateTime.MinValue;
                //            }
                //            status = _rateDB.WriteSubSectionProc(ref paraRateDeleteList, ref sqlConnection, ref sqlTransaction);
                //        }
                //    }
                //}

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
                base.WriteErrorLog(e, "RateQuoteDB.Write(ref object GoodsPriceUWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateQuoteDB.Write(ref object GoodsPriceUWork)");
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

        #region ・更新
        /// <summary>
        /// データ追加・更新処理
        /// </summary>
        /// <param name="rateInsertList">追加リスト</param>
        /// <param name="rateUpdateList">更新リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Update(ref object rateInsertList, ref object rateUpdateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraRateInsertList = rateInsertList as ArrayList;
                ArrayList paraRateUpdateList = rateUpdateList as ArrayList;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ↓ 2009.06.18 劉洋 add ロット数修正
                ArrayList paraRateSearchList = new ArrayList();
                ArrayList searchResultList = new ArrayList();
                if (paraRateUpdateList != null && paraRateUpdateList.Count != 0)
                {
                    // 更新リスト
                    foreach (RateWork rateUpdate in paraRateUpdateList)
                    {
                        bool isExistFlg = false;

                        // 存在判断
                        foreach (RateWork rateSearch in paraRateSearchList)
                        {
                            if (rateSearch.EnterpriseCode.Equals(rateUpdate.EnterpriseCode)
                                && rateSearch.SectionCode.Equals(rateUpdate.SectionCode)
                                && rateSearch.UnitRateSetDivCd.Equals(rateUpdate.UnitRateSetDivCd)
                                && rateSearch.GoodsMakerCd == rateUpdate.GoodsMakerCd
                                && rateSearch.GoodsNo.Equals(rateUpdate.GoodsNo)
                                && rateSearch.GoodsRateRank.Equals(rateUpdate.GoodsRateRank)
                                && rateSearch.GoodsRateGrpCode == rateUpdate.GoodsRateGrpCode
                                && rateSearch.BLGroupCode == rateUpdate.BLGroupCode
                                && rateSearch.BLGoodsCode == rateUpdate.BLGoodsCode
                                && rateSearch.CustomerCode == rateUpdate.CustomerCode
                                && rateSearch.CustRateGrpCode == rateUpdate.CustRateGrpCode
                                && rateSearch.SupplierCd == rateUpdate.SupplierCd)
                            {
                                isExistFlg = true;
                                break;
                            }
                        }

                        if (!isExistFlg)
                        {
                            paraRateSearchList.Add(rateUpdate);

                            // 検索
                            double logCount = rateUpdate.LotCount;
                            // ロット数
                            rateUpdate.LotCount = -1;
                            ArrayList searchRes = null;
                            status = _rateDB.SearchSubSectionProc(out searchRes, rateUpdate, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection);

                            rateUpdate.LotCount = logCount;

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                searchResultList.AddRange(searchRes);
                            }
                        }
                    }
                }
                // ↑ 2009.06.18 劉洋 add

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 掛率マスタ登録
                if (paraRateInsertList != null && paraRateInsertList.Count != 0)
                {
                    // 更新日時
                    foreach (RateWork rateWork in paraRateInsertList)
                    {
                        rateWork.UpdateDateTime = DateTime.MinValue;
                    }
                    status = _rateDB.WriteSubSectionProc(ref paraRateInsertList, ref sqlConnection, ref sqlTransaction);
                }
                // 掛率マスタ登録
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    if (paraRateUpdateList != null && paraRateUpdateList.Count != 0)
                    {
                        // 情報を削除する
                        status = _rateDB.DeleteSubSectionProc(searchResultList, ref sqlConnection, ref sqlTransaction);
                        // 情報を登録する
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 更新日時
                            foreach (RateWork rateWork in paraRateUpdateList)
                            {
                                rateWork.UpdateDateTime = DateTime.MinValue;
                            }
                            status = _rateDB.WriteSubSectionProc(ref paraRateUpdateList, ref sqlConnection, ref sqlTransaction);
                        }
                    }
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
                base.WriteErrorLog(e, "RateQuoteDB.Update(ref object GoodsPriceUWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateQuoteDB.Update(ref object GoodsPriceUWork)");
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
        /// <br>Programmer : 劉洋</br>
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
