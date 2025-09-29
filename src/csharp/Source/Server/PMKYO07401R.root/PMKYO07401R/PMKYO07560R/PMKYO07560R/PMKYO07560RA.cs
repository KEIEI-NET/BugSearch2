//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   DC抽出・更新DB仲介クラス
//                  :   PMKYO07560R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   劉洋
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品別売上月次集計データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品別売上月次集計データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCGoodsMTtlSaSlipDB : RemoteDB
    {
        /// <summary>
        /// 商品別売上月次集計データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCGoodsMTtlSaSlipDB()
            : base("PMKYO07561D", "Broadleaf.Application.Remoting.ParamData.DCGoodsMTtlSaSlipWork", "GOODSMTTLSASLIPRF")
        {

        }
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        # region [Read]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 商品別売上月次集計データ取得
        /// </summary>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList goodsMTtlSaSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  goodsMTtlSaSlipList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データ取得
        /// </summary>
        /// <param name="goodsMTtlSaSlipList">商品別売上月次集計データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList goodsMTtlSaSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            goodsMTtlSaSlipList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SUPPLIERCDRF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF FROM GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL文
			sqlCommand.CommandText = sqlText;
            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                goodsMTtlSaSlipList.Add(this.CopyToGoodsMTtlSaSlipWorkFromReader(ref myReader));
            }

            if (goodsMTtlSaSlipList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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


        /// <summary>
        /// クラス格納処理 Reader → goodsMTtlSaSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCGoodsMTtlSaSlipWork CopyToGoodsMTtlSaSlipWorkFromReader(ref SqlDataReader myReader)
        {
            DCGoodsMTtlSaSlipWork goodsMTtlSaSlipWork = new DCGoodsMTtlSaSlipWork();

            this.CopyToGoodsMTtlSaSlipWorkFromReader(ref myReader, ref goodsMTtlSaSlipWork);

            return goodsMTtlSaSlipWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → goodsMTtlSaSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsMTtlSaSlipWork">goodsMTtlSaSlipWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToGoodsMTtlSaSlipWorkFromReader(ref SqlDataReader myReader, ref DCGoodsMTtlSaSlipWork goodsMTtlSaSlipWork)
        {
            if (myReader != null && goodsMTtlSaSlipWork != null)
            {
                # region クラスへ格納
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
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 商品別売上月次集計データ削除
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcGoodsMTtlSaSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データ削除
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork in dcGoodsMTtlSaSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM GOODSMTTLSASLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND SUPPLIERCDRF=@FINDSUPPLIERCD";
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
                findParaEnterpriseCode.Value = dcGoodsMTtlSaSlipWork.EnterpriseCode;
                findParaAddUpSecCode.Value = dcGoodsMTtlSaSlipWork.AddUpSecCode;
                findParaAddUpYearMonth.Value = dcGoodsMTtlSaSlipWork.AddUpYearMonth;
                findParaRsltTtlDivCd.Value = dcGoodsMTtlSaSlipWork.RsltTtlDivCd;
                findParaEmployeeCode.Value = dcGoodsMTtlSaSlipWork.EmployeeCode;
                findParaCustomerCode.Value = dcGoodsMTtlSaSlipWork.CustomerCode;
                findParaBLGoodsCode.Value = dcGoodsMTtlSaSlipWork.BLGoodsCode;
                findParaGoodsMakerCd.Value = dcGoodsMTtlSaSlipWork.GoodsMakerCd;
                findParaGoodsNo.Value = dcGoodsMTtlSaSlipWork.GoodsNo;
                findParaSupplierCd.Value = dcGoodsMTtlSaSlipWork.SupplierCd;

                // 商品別売上月次集計データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 商品別売上月次集計データ登録
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcGoodsMTtlSaSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 商品別売上月次集計データ登録
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWorkList">商品別売上月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcGoodsMTtlSaSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork in dcGoodsMTtlSaSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO GOODSMTTLSASLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, ADDUPYEARMONTHRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, CUSTOMERCODERF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SUPPLIERCDRF, SALESTIMESRF, TOTALSALESCOUNTRF, SALESMONEYRF, SALESRETGOODSPRICERF, DISCOUNTPRICERF, GROSSPROFITRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @ADDUPYEARMONTH, @RSLTTTLDIVCD, @EMPLOYEECODE, @CUSTOMERCODE, @BLGOODSCODE, @GOODSMAKERCD, @GOODSNO, @SUPPLIERCD, @SALESTIMES, @TOTALSALESCOUNT, @SALESMONEY, @SALESRETGOODSPRICE, @DISCOUNTPRICE, @GROSSPROFIT)";
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcGoodsMTtlSaSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcGoodsMTtlSaSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcGoodsMTtlSaSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.LogicalDeleteCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.AddUpSecCode);
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.AddUpYearMonth);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.RsltTtlDivCd);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.EmployeeCode);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.CustomerCode);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.BLGoodsCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcGoodsMTtlSaSlipWork.GoodsNo);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.SupplierCd);
                paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(dcGoodsMTtlSaSlipWork.SalesTimes);
                paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(dcGoodsMTtlSaSlipWork.TotalSalesCount);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.SalesMoney);
                paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.SalesRetGoodsPrice);
                paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.DiscountPrice);
                paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(dcGoodsMTtlSaSlipWork.GrossProfit);

                // 商品別売上月次集計データを登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

*/
// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
    }
}
