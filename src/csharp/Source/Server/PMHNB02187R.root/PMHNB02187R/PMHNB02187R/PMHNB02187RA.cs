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
    /// 得意先別取引分布表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別取引分布表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中　啓次朗</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// <br>Update Note: 不具合対応</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.05</br>
    /// </remarks>
    [Serializable]
    public class CustSalesDistributionReportResultDB : RemoteDB, ICustSalesDistributionReportResultDB
    {
        /// <summary>
        /// 得意先別取引分布表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中　啓次朗</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public CustSalesDistributionReportResultDB()
            :
            base("PMHNB02189D", "Broadleaf.Application.Remoting.ParamData.CustSalesDistributionReportResultWork", "SALESHISTORYRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の得意先別取引分布表データを戻します
        /// </summary>
        /// <param name="salesRsltListResultWorkk">検索結果</param>
        /// <param name="salesRsltListParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別取引分布表データを戻します</br>
        /// <br>Programmer : 23012 畠中　啓次朗</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object custSalesDistributionReportResultWork, object salesRsltListParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custSalesDistributionReportResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out custSalesDistributionReportResultWork, salesRsltListParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesDistributionReportResultWorkDB.Search");
                custSalesDistributionReportResultWork = new ArrayList();
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
        /// 指定された条件の得意先別取引分布表データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別取引分布表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中　啓次朗</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        private int SearchSales12MonthsListData(out object objCustSalesDistributionReportResultWork, object objCustSalesDistributionReportParamWork, ref SqlConnection sqlConnection)
        {
            CustSalesDistributionReportParamWork ParamWork = null;

            ArrayList ParamWorkList = objCustSalesDistributionReportParamWork as ArrayList;

            if (ParamWorkList == null)
            {
                ParamWork = objCustSalesDistributionReportParamWork as CustSalesDistributionReportParamWork;
            }
            else
            {
                if (ParamWorkList.Count > 0)
                    ParamWork = ParamWorkList[0] as CustSalesDistributionReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            switch (ParamWork.PrintDiv)
            {
                case (int)TotalType.Customer:  //得意先別
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                case (int)TotalType.Agent:     //担当者別
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
                case (int)TotalType.Area:     //地区
                    mTtlSaSlip = new MTtlSaSlipArea();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 得意先別取引分布表データを取込む
            status = SearchSalesHistoryDataProc(out salesReportWorkList, ParamWork, ref sqlConnection);

            objCustSalesDistributionReportResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の得意先別取引分布表データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別取引分布表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中　啓次朗</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, CustSalesDistributionReportParamWork ParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, ParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, ParamWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.SearchSalesHistoryDataProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中　啓次朗</br>
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
