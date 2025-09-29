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
    /// 出荷商品順位表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品順位表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.12.03</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応</br>
    /// <br>           : 23015 森本 大輝</br>
    /// <br>           : 2008.08.25</br>
    /// <br></br>
    /// <br>Update Note: 不具合対応</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br>           : 2008.11.04</br>
    /// <br></br>
    /// <br>Update Note: Mantis:14823 取寄のみ印刷した場合、正常に印刷されない件の修正</br>
    /// <br>           : 30517 夏野 駿希</br>
    /// <br>           : 2010/01/07</br>
    /// <br></br>
    /// <br>Update Note: イスコ対応・READUNCOMMITTED対応</br>
    /// <br>           : 30517 夏野 駿希</br>
    /// <br>           : 2011/08/01</br>
    /// </remarks>
    [Serializable]
    public class ShipmGoodsOdrReportResultDB : RemoteDB, IShipmGoodsOdrReportResultDB
    {
        /// <summary>
        /// 出荷商品順位表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        public ShipmGoodsOdrReportResultDB()
            :
            base("DCHNB02066D", "Broadleaf.Application.Remoting.ParamData.ShipmGoodsOdrReportResultWork", "SHIPMGOODSODRREPORTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の出荷商品順位表データを戻します
        /// </summary>
        /// <param name="salesRsltListResultWorkk">検索結果</param>
        /// <param name="shipmGoodsOdrReportParam">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷商品順位表データを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.03</br>
        public int Search(out object shipmGoodsOdrReportResultWork, object shipmGoodsOdrReportParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            shipmGoodsOdrReportResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out shipmGoodsOdrReportResultWork, shipmGoodsOdrReportParam, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmGoodsOdrReportResultWorkDB.Search");
                shipmGoodsOdrReportResultWork = new ArrayList();
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
        /// 指定された条件の出荷商品順位表データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷商品順位表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.03</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.25</br>
        private int SearchSales12MonthsListData(out object objShipmGoodsOdrReportResultWork, object objShipmGoodsOdrReportParamWork, ref SqlConnection sqlConnection)
        {
            ShipmGoodsOdrReportParamWork CndtnWork = null;

            ArrayList CndtnWorkList = objShipmGoodsOdrReportParamWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objShipmGoodsOdrReportParamWork as ShipmGoodsOdrReportParamWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as ShipmGoodsOdrReportParamWork;
            }

            switch (CndtnWork.TotalType)
            {
                case (int)TotalType.Goods:     //商品別
                    mTtlSaSlip = new MTtlSaSlipGoods();
                    break;
                case (int)TotalType.BLCode:    //BLコード別
                    mTtlSaSlip = new MTtlSaSlipBLCd();
                    break;
                case (int)TotalType.Customer:  //得意先別
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                case (int)TotalType.Agent:     //担当者別
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
            }

            ArrayList salesReportWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //Search実行
            status = SearchSalesHistoryDataProc(ref salesReportWorkList, CndtnWork, ref sqlConnection);

            objShipmGoodsOdrReportResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の出荷商品順位表データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷商品順位表データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.03</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.25</br>
        private int SearchSalesHistoryDataProc(ref ArrayList salesHistoryWorkList, ShipmGoodsOdrReportParamWork CndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, CndtnWork);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //結果取得
                    salesHistoryWorkList.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, CndtnWork));

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
                base.WriteErrorLog(ex, "ShipmGoodsOdrReportResultDB.SearchSalesHistoryDataProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

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
        /// <br>Date       : 2007.12.03</br>
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
