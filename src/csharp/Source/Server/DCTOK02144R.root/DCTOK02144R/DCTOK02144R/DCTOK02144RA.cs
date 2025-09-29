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
    /// 売上推移表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上推移表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br>Update Note: 不具合対応</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.05</br>
    /// <br>Update Note: 2009/04/15 張莉莉</br>
    /// <br>            ・売上推移表（仕入先別）の追加</br>
    /// <br>Update Note: 2010/01/13 夏野 駿希</br>
    /// <br>            ・Mantis:14877　取寄指定時、抽出結果に異常がある件の修正</br>
    /// <br>Update Note: 2010/05/13 長内数馬</br>
    /// <br>            ・品名の取得方法を変更
    /// <br>Update Note: 2011/08/01 夏野 駿希</br>
    /// <br>            ・イスコ対応・READUNCOMMITTED対応</br>
    /// </remarks>
    [Serializable]
    public class SalesTransListResultDB : RemoteDB, ISalesTransListResultDB
    {
        /// <summary>
        /// 売上推移表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesTransListResultDB()
            :
            base("DCTOK02146D", "Broadleaf.Application.Remoting.ParamData.SalesTransListResultWork", "SALESTRANSLISTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の売上推移表データを戻します
        /// </summary>
        /// <param name="salesRsltListResultWorkk">検索結果</param>
        /// <param name="salesRsltListCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上推移表データを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object salesTransListResultWork, object salesRsltListCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesTransListResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out salesTransListResultWork, salesRsltListCndtnWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesTransListResultWorkDB.Search");
                salesTransListResultWork = new ArrayList();
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
        /// 指定された条件の売上推移表データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上推移表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.08</br>
        private int SearchSales12MonthsListData(out object objSalesTransListResultWork, object objSalesTransListCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesTransListCndtnWork CndtnWork = null;

            ArrayList CndtnWorkList = objSalesTransListCndtnWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objSalesTransListCndtnWork as SalesTransListCndtnWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as SalesTransListCndtnWork;
            }

            ArrayList salesReportWorkList = null;

            switch (CndtnWork.TotalType)
            {
                case (int)TotalType.Goods:     //商品別
                    mTtlSaSlip = new MTtlSaSlipGoods();
                    break;
                case (int)TotalType.Customer:  //得意先別
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                case (int)TotalType.Agent:     //担当者別
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
                case (int)TotalType.Supplier:  //仕入先別　　// ADD 2009/04/15
                    mTtlSaSlip = new MTtlSaSlipSupp();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 売上推移表データを取込む
            status = SearchSalesHistoryDataProc(out salesReportWorkList, CndtnWork, ref sqlConnection);

            objSalesTransListResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の売上推移表データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上推移表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.08</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesTransListCndtnWork CndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, CndtnWork);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 3600;

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
