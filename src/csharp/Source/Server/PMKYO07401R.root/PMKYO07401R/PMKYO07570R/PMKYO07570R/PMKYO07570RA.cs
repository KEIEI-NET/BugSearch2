//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
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
    /// 仕入月次集計データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入月次集計データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCMTtlStockSlipDB : RemoteDB
    {
        /// <summary>
        /// 仕入月次集計データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCMTtlStockSlipDB()
            : base("PMKYO07571D", "Broadleaf.Application.Remoting.ParamData.DCMTtlStockSlipWork", "MTTLSTOCKSLIPRF")
        {

        }
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*

        # region [Read]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データ取得
        /// </summary>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList mTtlStockSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  mTtlStockSlipList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データ取得
        /// </summary>
        /// <param name="mTtlStockSlipList">仕入月次集計データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList mTtlStockSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            mTtlStockSlipList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKSECTIONCDRF, STOCKDATEYMRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, SUPPLIERCDRF, STOCKTOTALPRICERF, TOTALSTOCKCOUNTRF, STOCKRETGOODSPRICERF, STOCKTOTALDISCOUNTRF FROM MTTLSTOCKSLIPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                mTtlStockSlipList.Add(this.CopyToMTtlStockSlipWorkFromReader(ref myReader));
            }

            if (mTtlStockSlipList.Count > 0)
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
        /// クラス格納処理 Reader → mTtlStockSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCMTtlStockSlipWork CopyToMTtlStockSlipWorkFromReader(ref SqlDataReader myReader)
        {
            DCMTtlStockSlipWork mTtlStockSlipWork = new DCMTtlStockSlipWork();

            this.CopyToMTtlStockSlipWorkFromReader(ref myReader, ref mTtlStockSlipWork);

            return mTtlStockSlipWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → mTtlStockSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mTtlStockSlipWork">mTtlStockSlipWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToMTtlStockSlipWorkFromReader(ref SqlDataReader myReader, ref DCMTtlStockSlipWork mTtlStockSlipWork)
        {
            if (myReader != null && mTtlStockSlipWork != null)
            {
                # region クラスへ格納
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
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データ削除
        /// </summary>
        /// <param name="dcMTtlStockSlipWorkList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcMTtlStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcMTtlStockSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データ削除
        /// </summary>
        /// <param name="dcMTtlStockSlipWorkList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcMTtlStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCMTtlStockSlipWork dcMTtlStockSlipWork in dcMTtlStockSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM MTTLSTOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKSECTIONCDRF=@FINDSTOCKSECTIONCD AND STOCKDATEYMRF=@FINDSTOCKDATEYM AND RSLTTTLDIVCDRF=@FINDRSLTTTLDIVCD AND EMPLOYEECODERF=@FINDEMPLOYEECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD";
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockSectionCd = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter findParaStockDateYm = sqlCommand.Parameters.Add("@FINDSTOCKDATEYM", SqlDbType.Int);
                SqlParameter findParaRsltTtlDivCd = sqlCommand.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcMTtlStockSlipWork.EnterpriseCode;
                findParaStockSectionCd.Value = dcMTtlStockSlipWork.StockSectionCd;
                findParaStockDateYm.Value = dcMTtlStockSlipWork.StockDateYm;
                findParaRsltTtlDivCd.Value = dcMTtlStockSlipWork.RsltTtlDivCd;
                findParaEmployeeCode.Value = dcMTtlStockSlipWork.EmployeeCode;
                findParaSupplierCd.Value = dcMTtlStockSlipWork.SupplierCd;

                // 仕入月次集計データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入月次集計データ登録
        /// </summary>
        /// <param name="dcMTtlStockSlipWorkList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcMTtlStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcMTtlStockSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入月次集計データ登録
        /// </summary>
        /// <param name="dcMTtlStockSlipWorkList">仕入月次集計データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcMTtlStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCMTtlStockSlipWork dcMTtlStockSlipWork in dcMTtlStockSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO MTTLSTOCKSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKSECTIONCDRF, STOCKDATEYMRF, RSLTTTLDIVCDRF, EMPLOYEECODERF, SUPPLIERCDRF, STOCKTOTALPRICERF, TOTALSTOCKCOUNTRF, STOCKRETGOODSPRICERF, STOCKTOTALDISCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @STOCKSECTIONCD, @STOCKDATEYM, @RSLTTTLDIVCD, @EMPLOYEECODE, @SUPPLIERCD, @STOCKTOTALPRICE, @TOTALSTOCKCOUNT, @STOCKRETGOODSPRICE, @STOCKTOTALDISCOUNT)";
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcMTtlStockSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcMTtlStockSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcMTtlStockSlipWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcMTtlStockSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcMTtlStockSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcMTtlStockSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcMTtlStockSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcMTtlStockSlipWork.LogicalDeleteCode);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(dcMTtlStockSlipWork.StockSectionCd);
                paraStockDateYm.Value = SqlDataMediator.SqlSetInt32(dcMTtlStockSlipWork.StockDateYm);
                paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(dcMTtlStockSlipWork.RsltTtlDivCd);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(dcMTtlStockSlipWork.EmployeeCode);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcMTtlStockSlipWork.SupplierCd);
                paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(dcMTtlStockSlipWork.StockTotalPrice);
                paraTotalStockCount.Value = SqlDataMediator.SqlSetDouble(dcMTtlStockSlipWork.TotalStockCount);
                paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(dcMTtlStockSlipWork.StockRetGoodsPrice);
                paraStockTotalDiscount.Value = SqlDataMediator.SqlSetInt64(dcMTtlStockSlipWork.StockTotalDiscount);

                // 仕入月次集計データを登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

*/
// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
    }
}
