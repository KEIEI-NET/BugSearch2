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
    /// 売上実績DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上実績の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.09.02</br>
    /// <br>Update Note: 2009.04.11 張莉莉</br>
    /// <br>           ・売上実績表（仕入先別）の追加</br>
    /// <br>Update Note: 2010/01/07 夏野 駿希</br>
    /// <br>           ・Mantis：14722,14830　倉庫別には倉庫コード0000（取寄）は印字しない様に修正</br>
    /// <br>Update Note: 2010/01/13 夏野 駿希</br>
    /// <br>           ・Mantis：14878　取寄指定時、出力結果に異常がある件の修正</br>
    ///                  BLGROUPCODERF，GOODSMGROUPRF，GOODSLGROUPRFがNULLの場合は0として扱う様に修正
    /// <br>Update Note: 2010/05/13 長内数馬</br>
    /// <br>            ・品名の取得方法を変更
    /// <br>Update Note: 2011/04/21 長内数馬</br>
    /// <br>            売上実績表（倉庫別）の修正
    /// <br>            ・使用する拠点を拠点コードから計上拠点コードに変更
    /// <br>            ・WHERE句の終了条件の追加判定に不具合があるため修正
    /// <br>            ・速度チューニング
    /// <br>Update Note: 2011/07/29 30517 夏野 駿希</br>
    /// <br>            イスコ対応・READUNCOMMITTED対応
    /// </remarks>
    [Serializable]
    public class SalesRsltListResultDB : RemoteDB, ISalesRsltListResultDB
    {
        /// <summary>
        /// 売上実績DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesRsltListResultDB()
            :
            base("DCTOK02126D", "Broadleaf.Application.Remoting.ParamData.SalesRsltListResultWork", "SALESRSLTLISTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// 指定された条件の売上実績データを戻します
        /// </summary>
        /// <param name="salesRsltListResultWorkk">検索結果</param>
        /// <param name="CndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上実績データを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object salesRsltListResultWork, object salesRsltListCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesRsltListResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchsalesDayMonthReportData(out salesRsltListResultWork, salesRsltListCndtnWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                salesRsltListResultWork = new ArrayList();
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
        /// 指定された条件の売上実績データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上実績データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        private int SearchsalesDayMonthReportData(out object objSalesRsltListResultWork, object objSalesRsltListCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesRsltListCndtnWork CndtnWork = null;

            ArrayList CndtnWorkList = objSalesRsltListCndtnWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objSalesRsltListCndtnWork as SalesRsltListCndtnWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as SalesRsltListCndtnWork;
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
                case (int)TotalType.Whouse:    //倉庫別
                    mTtlSaSlip = new MTtlSaSlipWhouse();
                    break;
                case (int)TotalType.Supplier:   //仕入先別   // ADD 2009/04/11
                    mTtlSaSlip = new MTtlSaSlipSupp();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 売上実績データを取込む
            status = SearchSalesHistoryDataProc(out salesReportWorkList, CndtnWork, ref sqlConnection);

            objSalesRsltListResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の売上実績データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上実績データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS対応</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesRsltListCndtnWork CndtnWork, ref SqlConnection sqlConnection)
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
