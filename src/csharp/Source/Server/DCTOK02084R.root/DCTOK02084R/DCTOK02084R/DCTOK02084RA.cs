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
    /// 仕入推移表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入推移表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 山田 明友</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class StockTransListResultDB : RemoteDB, IStockTransListResultDB
    {
        /// <summary>
        /// 仕入推移表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        /// </remarks>
        public StockTransListResultDB()
            :
            base("DCTOK02086D", "Broadleaf.Application.Remoting.ParamData.StockTransListResultWork", "STOCKTRANSLISTRESULTRF")
        {
        }

        IMTtlStSlip mTtlStSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入推移表データを戻します
        /// </summary>
        /// <param name="stockTransListResultWork">検索結果</param>
        /// <param name="stockRsltListCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入推移表データを戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        public int Search(out object stockTransListResultWork, object stockRsltListCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockTransListResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStock12MonthsListData(out stockTransListResultWork, stockRsltListCndtnWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockTransListResultWorkDB.Search");
                stockTransListResultWork = new ArrayList();
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
        /// 指定された条件の仕入推移表データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objStockTransListResultWork">検索結果</param>
        /// <param name="objStockTransListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入推移表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        private int SearchStock12MonthsListData(out object objStockTransListResultWork, object objStockTransListCndtnWork, ref SqlConnection sqlConnection)
        {
            StockTransListCndtnWork CndtnWork = null;

            ArrayList CndtnWorkList = objStockTransListCndtnWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objStockTransListCndtnWork as StockTransListCndtnWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as StockTransListCndtnWork;
            }

            ArrayList stockReportWorkList = null;

            switch (CndtnWork.PrintSelectDiv)
            {
                case 0:     //商品別
                    mTtlStSlip = new MTtlStSlipGoods();
                    break;
                case 1:     //仕入先別
                    mTtlStSlip = new MTtlStSlipSupl();
                    break;
                case 2:     //担当者別
                    mTtlStSlip = new MTtlStSlipEmp();
                    break;
                default:
                    mTtlStSlip = new MTtlStSlipGoods();
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 仕入推移表データを取込む
            status = SearchStockHistoryDataProc(out stockReportWorkList, CndtnWork, ref sqlConnection);

            objStockTransListResultWork = stockReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchStockHistoryDataProc]
        /// <summary>
        /// 指定された条件の仕入推移表データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockHistoryWorkList">検索結果</param>
        /// <param name="cndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入推移表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        private int SearchStockHistoryDataProc(out ArrayList stockHistoryWorkList, StockTransListCndtnWork cndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlStSlip.MakeSelectString(ref sqlCommand, cndtnWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlStSlip.CopyToStockRsltListResultWorkFromReader(ref myReader, cndtnWork));

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

            stockHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchStockHistoryDataProc


        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
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
