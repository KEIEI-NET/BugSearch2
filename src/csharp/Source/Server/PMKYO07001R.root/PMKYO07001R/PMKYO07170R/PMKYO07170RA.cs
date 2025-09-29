//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//                                : 仕入月次集計データの削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入月次集計データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APMTtlStockSlipDB : RemoteDB
    {
        /// <summary>
        /// 仕入月次集計データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APMTtlStockSlipDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        /*　
// DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）---------->>>>>>>
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="mTtlStockSlipArrList">仕入月次集計データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入月次集計データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchMTtlStockSlip(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList mTtlStockSlipArrList, out string retMessage)
        {
            return SearchMTtlStockSlipProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  mTtlStockSlipArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="mTtlStockSlipArrList">仕入月次集計データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入月次集計データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchMTtlStockSlipProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList mTtlStockSlipArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            mTtlStockSlipArrList = new ArrayList();
            APMTtlStockSlipWork mTtlStockSlipWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKSECTIONCDRF, STOCKDATEYMRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, SUPPLIERCDRF, STOCKTOTALPRICERF, TOTALSTOCKCOUNTRF, STOCKRETGOODSPRICERF, STOCKTOTALDISCOUNTRF FROM MTTLSTOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 仕入月次集計データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    mTtlStockSlipWork = new APMTtlStockSlipWork();

                    mTtlStockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    mTtlStockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    mTtlStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    mTtlStockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    mTtlStockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    mTtlStockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    mTtlStockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    mTtlStockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    mTtlStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    mTtlStockSlipWork.StockDateYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDATEYMRF"));
                    mTtlStockSlipWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));
                    mTtlStockSlipWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    mTtlStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    mTtlStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    mTtlStockSlipWork.TotalStockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSTOCKCOUNTRF"));
                    mTtlStockSlipWork.StockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKRETGOODSPRICERF"));
                    mTtlStockSlipWork.StockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALDISCOUNTRF"));


                    mTtlStockSlipArrList.Add(mTtlStockSlipWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateMTtlStockSlip(string enterPriseCode, ArrayList mTtlStockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateMTtlStockSlipProc(enterPriseCode, mTtlStockSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateMTtlStockSlipProc(string enterPriseCode, ArrayList mTtlStockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteMTtlStockSlip(enterPriseCode, mTtlStockSlipList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertMTtlStockSlip(enterPriseCode, mTtlStockSlipList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteMTtlStockSlip(string enterPriseCode, ArrayList mTtlStockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteMTtlStockSlipProc(enterPriseCode, mTtlStockSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteMTtlStockSlipProc(string enterPriseCode, ArrayList mTtlStockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APMTtlStockSlipWork mTtlStockSlipWork in mTtlStockSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM MTTLSTOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKSECTIONCDRF=@FINDSTOCKSECTIONCD AND STOCKDATEYMRF=@FINDSTOCKDATEYM AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockSectionCd = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter findParaStockDateYm = sqlCommand.Parameters.Add("@FINDSTOCKDATEYM", SqlDbType.Int);
                SqlParameter findParaRsltTtlDivCd = sqlCommand.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaStockSectionCd.Value = mTtlStockSlipWork.StockSectionCd;
                findParaStockDateYm.Value = mTtlStockSlipWork.StockDateYm;
                findParaRsltTtlDivCd.Value = mTtlStockSlipWork.RsltTtlDivCd;
                findParaEmployeeCode.Value = mTtlStockSlipWork.EmployeeCode;
                findParaSupplierCd.Value = mTtlStockSlipWork.SupplierCd;

				sqlCommand.CommandText = sqlText;

                // 実行
                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertMTtlStockSlip(string enterPriseCode, ArrayList mTtlStockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertMTtlStockSlipProc(enterPriseCode, mTtlStockSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertMTtlStockSlipProc(string enterPriseCode, ArrayList mTtlStockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APMTtlStockSlipWork mTtlStockSlipWork in mTtlStockSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO MTTLSTOCKSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKSECTIONCDRF, STOCKDATEYMRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, SUPPLIERCDRF, STOCKTOTALPRICERF, TOTALSTOCKCOUNTRF, STOCKRETGOODSPRICERF, STOCKTOTALDISCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @STOCKSECTIONCD, @STOCKDATEYM, @RSLTTTLDIVCD, @EMPLOYEECODE, @SUPPLIERCD, @STOCKTOTALPRICE, @TOTALSTOCKCOUNT, @STOCKRETGOODSPRICE, @STOCKTOTALDISCOUNT)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockDateYm = sqlCommand.Parameters.Add("@STOCKDATEYM", SqlDbType.Int);
                SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                SqlParameter paraTotalStockCount = sqlCommand.Parameters.Add("@TOTALSTOCKCOUNT", SqlDbType.Float);
                SqlParameter paraStockRetGoodsPrice = sqlCommand.Parameters.Add("@STOCKRETGOODSPRICE", SqlDbType.BigInt);
                SqlParameter paraStockTotalDiscount = sqlCommand.Parameters.Add("@STOCKTOTALDISCOUNT", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mTtlStockSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mTtlStockSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(mTtlStockSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mTtlStockSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mTtlStockSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mTtlStockSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mTtlStockSlipWork.LogicalDeleteCode);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(mTtlStockSlipWork.StockSectionCd);
                paraStockDateYm.Value = SqlDataMediator.SqlSetInt32(mTtlStockSlipWork.StockDateYm);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(mTtlStockSlipWork.RsltTtlDivCd);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(mTtlStockSlipWork.EmployeeCode);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(mTtlStockSlipWork.SupplierCd);
                paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(mTtlStockSlipWork.StockTotalPrice);
                paraTotalStockCount.Value = SqlDataMediator.SqlSetDouble(mTtlStockSlipWork.TotalStockCount);
                paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(mTtlStockSlipWork.StockRetGoodsPrice);
                paraStockTotalDiscount.Value = SqlDataMediator.SqlSetInt64(mTtlStockSlipWork.StockTotalDiscount);

				sqlCommand.CommandText = sqlText;

                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }

// DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----------<<<<<<<
*/
        #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
    }
}
