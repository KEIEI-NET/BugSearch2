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
//                                : 商品別売上月次集計データの削除
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
    /// 商品別売上月次集計データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APGoodsMTtlSaSlipDB : RemoteDB
    {
        /// <summary>
        /// 商品別売上月次集計データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APGoodsMTtlSaSlipDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        /*　
// DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）---------->>>>>>>
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 商品別売上月次集計データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="goodsMTtlSaSlipArrList">商品別売上月次集計データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上月次集計データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchGoodsMTtlSaSlip(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsMTtlSaSlipArrList, out string retMessage)
        {
            return SearchGoodsMTtlSaSlipProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  goodsMTtlSaSlipArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="goodsMTtlSaSlipArrList">商品別売上月次集計データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上月次集計データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchGoodsMTtlSaSlipProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsMTtlSaSlipArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsMTtlSaSlipArrList = new ArrayList();
            APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SUPPLIERCDRF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF FROM GOODSMTTLSASLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 商品別売上月次集計データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsMTtlSaSlipWork = new APGoodsMTtlSaSlipWork();

                    goodsMTtlSaSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsMTtlSaSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsMTtlSaSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsMTtlSaSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsMTtlSaSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsMTtlSaSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsMTtlSaSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsMTtlSaSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsMTtlSaSlipWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    goodsMTtlSaSlipWork.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    goodsMTtlSaSlipWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));
                    goodsMTtlSaSlipWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    goodsMTtlSaSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    goodsMTtlSaSlipWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsMTtlSaSlipWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsMTtlSaSlipWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsMTtlSaSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    goodsMTtlSaSlipWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                    goodsMTtlSaSlipWork.TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNTRF"));
                    goodsMTtlSaSlipWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
                    goodsMTtlSaSlipWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                    goodsMTtlSaSlipWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                    goodsMTtlSaSlipWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));


                    goodsMTtlSaSlipArrList.Add(goodsMTtlSaSlipWork);
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
        /// 商品別売上月次集計データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateGoodsMTtlSaSlip(string enterPriseCode, ArrayList goodsMTtlSaSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateGoodsMTtlSaSlipProc(enterPriseCode, goodsMTtlSaSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateGoodsMTtlSaSlipProc(string enterPriseCode, ArrayList goodsMTtlSaSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteGoodsMTtlSaSlip(enterPriseCode, goodsMTtlSaSlipList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertGoodsMTtlSaSlip(enterPriseCode, goodsMTtlSaSlipList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 商品別売上月次集計データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteGoodsMTtlSaSlip(string enterPriseCode, ArrayList goodsMTtlSaSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteGoodsMTtlSaSlipProc(enterPriseCode, goodsMTtlSaSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteGoodsMTtlSaSlipProc(string enterPriseCode, ArrayList goodsMTtlSaSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork in goodsMTtlSaSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM GOODSMTTLSASLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND SUPPLIERCDRF=@FINDSUPPLIERCD";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter findParaRsltTtlDivCd = sqlCommand.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaAddUpSecCode.Value = goodsMTtlSaSlipWork.AddUpSecCode;
                findParaAddUpYearMonth.Value = goodsMTtlSaSlipWork.AddUpYearMonth;
                findParaRsltTtlDivCd.Value = goodsMTtlSaSlipWork.RsltTtlDivCd;
                findParaEmployeeCode.Value = goodsMTtlSaSlipWork.EmployeeCode;
                findParaCustomerCode.Value = goodsMTtlSaSlipWork.CustomerCode;
                findParaBLGoodsCode.Value = goodsMTtlSaSlipWork.BLGoodsCode;
                findParaGoodsMakerCd.Value = goodsMTtlSaSlipWork.GoodsMakerCd;
                findParaGoodsNo.Value = goodsMTtlSaSlipWork.GoodsNo;
                findParaSupplierCd.Value = goodsMTtlSaSlipWork.SupplierCd;

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
        /// 商品別売上月次集計データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertGoodsMTtlSaSlip(string enterPriseCode, ArrayList goodsMTtlSaSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertGoodsMTtlSaSlipProc(enterPriseCode, goodsMTtlSaSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertGoodsMTtlSaSlipProc(string enterPriseCode, ArrayList goodsMTtlSaSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork in goodsMTtlSaSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO GOODSMTTLSASLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SUPPLIERCDRF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @ADDUPYEARMONTH, @RSLTTTLDIVCD, @EMPLOYEECODE, @CUSTOMERCODE, @BLGOODSCODE, @GOODSMAKERCD, @GOODSNO, @SUPPLIERCD, @SALESTIMES, @TOTALSALESCOUNT, @SALESMONEY, @SALESRETGOODSPRICE, @DISCOUNTPRICE, @GROSSPROFIT)";

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
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                SqlParameter paraTotalSalesCount = sqlCommand.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                SqlParameter paraDiscountPrice = sqlCommand.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsMTtlSaSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsMTtlSaSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsMTtlSaSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsMTtlSaSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsMTtlSaSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsMTtlSaSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.LogicalDeleteCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(goodsMTtlSaSlipWork.AddUpSecCode);
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.AddUpYearMonth);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.RsltTtlDivCd);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsMTtlSaSlipWork.EmployeeCode);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.CustomerCode);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.BLGoodsCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMTtlSaSlipWork.GoodsNo);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.SupplierCd);
                paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(goodsMTtlSaSlipWork.SalesTimes);
                paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(goodsMTtlSaSlipWork.TotalSalesCount);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(goodsMTtlSaSlipWork.SalesMoney);
                paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(goodsMTtlSaSlipWork.SalesRetGoodsPrice);
                paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(goodsMTtlSaSlipWork.DiscountPrice);
                paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(goodsMTtlSaSlipWork.GrossProfit);

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
