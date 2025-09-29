using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入月報年報DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入月報年報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class StockMonthYearReportResultDB : RemoteDB, IStockMonthYearReportResultDB
    {
        /// <summary>
        /// 仕入月報年報DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public StockMonthYearReportResultDB()
            :
            base("DCMIT02136D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportResultWork", "STOCKMONTHYEARREPORTRESULTRF")
        {
        }

        IMTtlStSlip mTtlStSlip = null;

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入月報年報データを戻します
        /// </summary>
        /// <param name="stockMonthYearReportResultWork">検索結果</param>
        /// <param name="stockMonthYearReportParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入月報年報データを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object stockMonthYearReportResultWork, object stockMonthYearReportParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockMonthYearReportResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMonthYearReportData(out stockMonthYearReportResultWork, stockMonthYearReportParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                stockMonthYearReportResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の仕入月報年報データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objStockMonthYearReportResultWork">検索結果</param>
        /// <param name="objStockMonthYearReportParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入月報年報データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchStockMonthYearReportData(out object objStockMonthYearReportResultWork, object objStockMonthYearReportParamWork, ref SqlConnection sqlConnection)
        {
            StockMonthYearReportParamWork stockMonthYearReportParamWork = null;

            ArrayList stockMonthYearReportParamWorkList = objStockMonthYearReportParamWork as ArrayList;

            if (stockMonthYearReportParamWorkList == null)
            {
                stockMonthYearReportParamWork = objStockMonthYearReportParamWork as StockMonthYearReportParamWork;
            }
            else
            {
                if (stockMonthYearReportParamWorkList.Count > 0)
                    stockMonthYearReportParamWork = stockMonthYearReportParamWorkList[0] as StockMonthYearReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            switch (stockMonthYearReportParamWork.TotalType)
            {
                case 0:     //拠点別
                case 4:     //メーカー別
                    mTtlStSlip = new MTtlStSlipBL();
                    break;
                case 1:     //仕入先別
                case 5:     //仕入先別メーカー別
                    mTtlStSlip = new MTtlStSlipSupl();
                    break;
                case 2:     //担当者別
                case 3:     //部署別
                    mTtlStSlip = new MTtlStSlipEmp();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 仕入月報年報データを取込む
            status = SearchSalesHistoryDataProc(out salesReportWorkList, stockMonthYearReportParamWork, ref sqlConnection);

            objStockMonthYearReportResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の仕入月報年報データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockReportWorkList">検索結果</param>
        /// <param name="stockMonthYearReportParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入月報年報績データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchSalesHistoryDataProc(out ArrayList stockReportWorkList, StockMonthYearReportParamWork stockMonthYearReportParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlStSlip.MakeSelectString(ref sqlCommand, stockMonthYearReportParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlStSlip.CopyToResultWorkFromReader(ref myReader, stockMonthYearReportParamWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockReportWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc


        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
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
        #endregion  //コネクション生成処理
    }

}
