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
    /// 売上目標設定マスタ印刷DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上目標設定マスタ印刷の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// <br>Programmer :</br>
    /// <br>Date       :</br>
    /// </remarks>
    [Serializable]
    public class SalTrgtPrintResultDB : RemoteDB, ISalTrgtPrintResultDB
    {
        /// <summary>
        /// 売上目標設定マスタ印刷DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public SalTrgtPrintResultDB()
            :
            base("PMKHN08637D", "Broadleaf.Application.Remoting.ParamData.SalTrgtPrintResultWork", "EMPSALESTARGETRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の売上目標設定マスタ印刷データを戻します
        /// </summary>
        /// <param name="salesRsltListResultWorkk">検索結果</param>
        /// <param name="salTrgtPrintParamWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上目標設定マスタ印刷データを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object salTrgtPrintResultWork, object salTrgtPrintParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salTrgtPrintResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out salTrgtPrintResultWork, salTrgtPrintParamWork, ref sqlConnection, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalTrgtPrintResultWorkDB.Search");
                salTrgtPrintResultWork = new ArrayList();
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
        /// 指定された条件の売上目標設定マスタ印刷データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上目標設定マスタ印刷データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        private int SearchSales12MonthsListData(out object objSalTrgtPrintResultWork, object objSalTrgtPrintParamWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            SalTrgtPrintParamWork CndtnWork = null;

            ArrayList CndtnWorkList = objSalTrgtPrintParamWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objSalTrgtPrintParamWork as SalTrgtPrintParamWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as SalTrgtPrintParamWork;
            }

            ArrayList salesReportWorkList = null;

            //商品別
            if ((CndtnWork.PrintType == 44) || (CndtnWork.PrintType == 45))
            {
                mTtlSaSlip = new MTtlSaSlipGoods();
            }
            //得意先別
            else if (CndtnWork.PrintType >= 30 && CndtnWork.PrintType <= 32)
            {
                mTtlSaSlip = new MTtlSaSlipCust();
            }
            //担当者別
            else if ((CndtnWork.PrintType == 10) || (CndtnWork.PrintType == 20) || (CndtnWork.PrintType == 22))
            {
                mTtlSaSlip = new MTtlSaSlipEmp();
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 売上目標設定マスタ印刷データを取込む
            status = SearchSalesTargetDataProc(out salesReportWorkList, CndtnWork, ref sqlConnection,logicalMode);

            objSalTrgtPrintResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesTargetDataProc]
        /// <summary>
        /// 指定された条件の売上目標設定マスタ印刷データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上目標設定マスタ印刷データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        private int SearchSalesTargetDataProc(out ArrayList SalesTargetWorkList, SalTrgtPrintParamWork CndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, CndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, CndtnWork));

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
                base.WriteErrorLog(ex, "SalesRsltListResultDB.SearchSalesTargetDataProc");
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

            SalesTargetWorkList = al;

            return status;
        }
        #endregion  //SearchSalesTargetDataProc

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
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
