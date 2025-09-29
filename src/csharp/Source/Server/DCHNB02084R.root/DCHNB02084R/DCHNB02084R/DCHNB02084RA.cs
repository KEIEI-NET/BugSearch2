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
    /// 売上月報年報DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月報年報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応</br>
    /// <br>           : 23015 森本 大輝</br>
    /// <br>           : 2008.08.06</br>
    /// </remarks>
    [Serializable]
    public class SalesMonthYearReportResultDB : RemoteDB, ISalesMonthYearReportResultDB
    {
        /// <summary>
        /// 売上月報年報DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.06</br>
        /// <br></br>
        /// <br>Update Note: 不具合対応</br>
        /// <br>           : 23012 畠中 啓次朗</br>
        /// <br>           : 2008.12.08</br>
        /// <br></br>
        /// <br>Update Note: イスコ対応・READUNCOMMITTED対応</br>
        /// <br>           : 30517 夏野 駿希</br>
        /// <br>           : 2011/07/29</br>
        /// </remarks>
        public SalesMonthYearReportResultDB()
            :
            base("DCHNB02086D", "Broadleaf.Application.Remoting.ParamData.SalesMonthYearReportResultWork", "SALESMONTHYEARREPORTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の売上月報年報データを戻します
        /// </summary>
        /// <param name="salesRsltListResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上月報年報データを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.06</br>
        public int Search(out object salesRsltListResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesRsltListResultWork = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                #region [暗号化キー 一時コメント 2008.08.06]
                /*
                // 2008.04.02 Add >>>>>>>>
                // 暗号化部品準備処理
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                // 暗号化キーOPEN
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                // 2008.04.02 Add <<<<<<<<
                 */
                #endregion

                return SearchsalesDayMonthReportData(out salesRsltListResultWork, paramWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                salesRsltListResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                #region [暗号化キー 一時コメント 2008.08.06]
                /*
                // 2008.04.02 Add >>>>>>>>
                // 暗号化キー破棄
                if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                {
                    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }
                // 2008.04.02 Add <<<<<<<<
                 */
                #endregion

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の売上月報年報データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上月報年報データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.06</br>
        private int SearchsalesDayMonthReportData(out object objSalesRsltListResultWork, object objSalesMonthYearReportParamWork, ref SqlConnection sqlConnection)
        {
            SalesMonthYearReportParamWork paramWork = null;

            //パラメータのキャスト
            ArrayList paramWorkList = objSalesMonthYearReportParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesMonthYearReportParamWork as SalesMonthYearReportParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesMonthYearReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            //検索タイプ判定
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Agent:             //Agent    = 1 -> 担当者別
                case (int)TotalType.AcpOdr:            //AcpOdr   = 2 -> 受注者別
                case (int)TotalType.Pblsher:           //Pblsher  = 3 -> 発行者別
                    mTtlSaSlip = new MTtlSaSlip_Emp();
                    break;
                case (int)TotalType.Customer:          //Customer = 0 -> 得意先別
                case (int)TotalType.Area:              //Area     = 4 -> 地区別
                case (int)TotalType.BzType:            //BzType   = 5 -> 業種別
                    mTtlSaSlip = new MTtlSaSlip_Cust();
                    break;
                case (int)TotalType.SaleCd:            //SaleCd   = 6 -> 販売区分別
                    mTtlSaSlip = new MTtlSaSlip_Gcd();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            // 売上月報年報データを取込む
            status = SearchSalesHistoryDataProc(out salesReportWorkList, paramWork, ref sqlConnection);

            //実行結果取得
            objSalesRsltListResultWork = salesReportWorkList;
            return status;
        }
        #endregion  //[Search]

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の売上月報年報データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上月報年報データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.06</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesMonthYearReportParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SalesMonthYearReportResultWork ResultWork = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //抽出結果取得
                    ResultWork = mTtlSaSlip.CopyToResultWorkFromReader(ref myReader, paramWork);
                    //取得結果セット
                    al.Add(ResultWork);

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

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //[SearchSalesHistoryDataProc]

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>           : 23015 森本 大輝</br>
        /// <br>           : 2008.08.06</br>
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
