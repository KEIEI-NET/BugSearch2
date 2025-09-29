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
// 管理番号              作成担当 : 22008 長内数馬
// 修 正 日  2010/05/20  修正内容 : エラー対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//                                : 売上月次集計データの削除
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
    /// 売上月次集計データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APMTtlSalesSlipDB : RemoteDB
    {
        /// <summary>
        /// 売上月次集計データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APMTtlSalesSlipDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        /*　
// DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）---------->>>>>>>
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上月次集計データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="mTtlSalesSlipArrList">売上月次集計データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上月次集計データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchMTtlSalesSlip(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList mTtlSalesSlipArrList, out string retMessage)
        {
            return SearchMTtlSalesSlipProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  mTtlSalesSlipArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上月次集計データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="mTtlSalesSlipArrList">売上月次集計データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上月次集計データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchMTtlSalesSlipProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList mTtlSalesSlipArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            mTtlSalesSlipArrList = new ArrayList();
            APMTtlSalesSlipWork mTtlSalesSlipWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEEDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, SUPPLIERCDRF, SALESCODERF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF FROM MTTLSALESSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 売上月次集計データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    mTtlSalesSlipWork = new APMTtlSalesSlipWork();

                    mTtlSalesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    mTtlSalesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    mTtlSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    mTtlSalesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    mTtlSalesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    mTtlSalesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    mTtlSalesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    mTtlSalesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    mTtlSalesSlipWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    mTtlSalesSlipWork.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    mTtlSalesSlipWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));
                    mTtlSalesSlipWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
                    mTtlSalesSlipWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    mTtlSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    mTtlSalesSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    mTtlSalesSlipWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    mTtlSalesSlipWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                    mTtlSalesSlipWork.TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNTRF"));
                    mTtlSalesSlipWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
                    mTtlSalesSlipWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                    mTtlSalesSlipWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                    mTtlSalesSlipWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));


                    mTtlSalesSlipArrList.Add(mTtlSalesSlipWork);
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
        /// 売上月次集計データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlSalesSlipList">売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateMTtlSalesSlip(string enterPriseCode, ArrayList mTtlSalesSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateMTtlSalesSlipProc(enterPriseCode, mTtlSalesSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上月次集計データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlSalesSlipList">売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateMTtlSalesSlipProc(string enterPriseCode, ArrayList mTtlSalesSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteMTtlSalesSlip(enterPriseCode, mTtlSalesSlipList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertMTtlSalesSlip(enterPriseCode, mTtlSalesSlipList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上月次集計データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlSalesSlipList">売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteMTtlSalesSlip(string enterPriseCode, ArrayList mTtlSalesSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteMTtlSalesSlipProc(enterPriseCode, mTtlSalesSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上月次集計データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlSalesSlipList">売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteMTtlSalesSlipProc(string enterPriseCode, ArrayList mTtlSalesSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APMTtlSalesSlipWork mTtlSalesSlipWork in mTtlSalesSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM MTTLSALESSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND SALESCODERF=@FINDSALESCODE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter findParaRsltTtlDivCd = sqlCommand.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaAddUpSecCode.Value = mTtlSalesSlipWork.AddUpSecCode;
                findParaAddUpYearMonth.Value = mTtlSalesSlipWork.AddUpYearMonth;
                findParaRsltTtlDivCd.Value = mTtlSalesSlipWork.RsltTtlDivCd;
                findParaEmployeeDivCd.Value = mTtlSalesSlipWork.EmployeeDivCd;
                findParaEmployeeCode.Value = mTtlSalesSlipWork.EmployeeCode;
                findParaCustomerCode.Value = mTtlSalesSlipWork.CustomerCode;
                findParaSupplierCd.Value = mTtlSalesSlipWork.SupplierCd;
                findParaSalesCode.Value = mTtlSalesSlipWork.SalesCode;

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
        /// 売上月次集計データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlSalesSlipList">売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertMTtlSalesSlip(string enterPriseCode, ArrayList mTtlSalesSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertMTtlSalesSlipProc(enterPriseCode, mTtlSalesSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上月次集計データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="mTtlSalesSlipList">売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertMTtlSalesSlipProc(string enterPriseCode, ArrayList mTtlSalesSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APMTtlSalesSlipWork mTtlSalesSlipWork in mTtlSalesSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO MTTLSALESSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEEDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, SUPPLIERCDRF, SALESCODERF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @ADDUPYEARMONTH, @RSLTTTLDIVCD, @EMPLOYEEDIVCD, @EMPLOYEECODE, @CUSTOMERCODE, @SUPPLIERCD, @SALESCODE, @SALESTIMES, @TOTALSALESCOUNT, @SALESMONEY, @SALESRETGOODSPRICE, @DISCOUNTPRICE, @GROSSPROFIT)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                SqlParameter paraTotalSalesCount = sqlCommand.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                SqlParameter paraDiscountPrice = sqlCommand.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mTtlSalesSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mTtlSalesSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(mTtlSalesSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mTtlSalesSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mTtlSalesSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mTtlSalesSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.LogicalDeleteCode);
                // -- UPD 2010/05/20 ---------------------------------------------->>>
                //paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(mTtlSalesSlipWork.AddUpSecCode);
                paraAddUpSecCode.Value = mTtlSalesSlipWork.AddUpSecCode;
                // -- UPD 2010/05/20 ----------------------------------------------<<<
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.AddUpYearMonth);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.RsltTtlDivCd);
                paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.EmployeeDivCd);
                // -- UPD 2010/05/20 ---------------------------------------------->>>
                //paraEmployeeCode.Value = SqlDataMediator.SqlSetString(mTtlSalesSlipWork.EmployeeCode);
                paraEmployeeCode.Value = mTtlSalesSlipWork.EmployeeCode;
                // -- UPD 2010/05/20 ----------------------------------------------<<<
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.CustomerCode);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.SupplierCd);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.SalesCode);
                paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(mTtlSalesSlipWork.SalesTimes);
                paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(mTtlSalesSlipWork.TotalSalesCount);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(mTtlSalesSlipWork.SalesMoney);
                paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(mTtlSalesSlipWork.SalesRetGoodsPrice);
                paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(mTtlSalesSlipWork.DiscountPrice);
                paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(mTtlSalesSlipWork.GrossProfit);

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