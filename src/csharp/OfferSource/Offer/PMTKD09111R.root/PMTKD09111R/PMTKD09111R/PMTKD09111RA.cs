using System;
using System.Collections;
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 検索品目制御 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索品目制御の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SearchPrtCtlDB : RemoteDB, ISearchPrtCtlDB
    {
        #region [ コンストラクタ]
        /// <summary>
        /// 検索品目制御 リモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public SearchPrtCtlDB()
            :
            base("PMTKD09113D", "Broadleaf.Application.Remoting.ParamData.SearchPrtCtlWork", "SEARCHPRTCTLRF")
        {
        }
        #endregion

        #region [Search]

        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="searchPrtCtlList">検索結果</param>
        /// <param name="paraSearchPrtCtlWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.11.11</br>
        public int Search(out object searchPrtCtlList, object paraSearchPrtCtlWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            searchPrtCtlList = null;
            try
            {
                SearchPrtCtlWork PartsPosCodeCondition = paraSearchPrtCtlWork as SearchPrtCtlWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out searchPrtCtlList, PartsPosCodeCondition, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchPrtCtlDB.Search");
                searchPrtCtlList = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="searchPrtCtlList">検索結果</param>
        /// <param name="paraSearchPrtCtlWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.11.11</br>
        public int SearchProc(out object searchPrtCtlList, SearchPrtCtlWork paraSearchPrtCtlWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchProcProc(out searchPrtCtlList, paraSearchPrtCtlWork, sqlConnection, sqlTransaction);
        }

        private int SearchProcProc(out object searchPrtCtlList, SearchPrtCtlWork paraSearchPrtCtlWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            searchPrtCtlList = null;
            ArrayList listSearchPrtCtl = new ArrayList();

            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " SEARCHPRTCTLRF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " SEARCHPRTCTLRF.SEARCHPRTTYPERF, " + Environment.NewLine;
                sqlTxt += " SEARCHPRTCTLRF.BIGCAROFFERDIVRF, " + Environment.NewLine;
                sqlTxt += " SEARCHPRTCTLRF.TBSPARTSCODERF " + Environment.NewLine;
                sqlTxt += " FROM SEARCHPRTCTLRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);                

                sqlCommand.CommandText = sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listSearchPrtCtl.Add(CopyToSearchPrtCtlWorkFromReader(myReader));
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            searchPrtCtlList = listSearchPrtCtl;
            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SearchPrtCtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SearchPrtCtlWork</returns>
        private SearchPrtCtlWork CopyToSearchPrtCtlWorkFromReader(SqlDataReader myReader)
        {
            SearchPrtCtlWork searchPrtCtlWork = new SearchPrtCtlWork();

            #region クラスへ格納
            searchPrtCtlWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            searchPrtCtlWork.SearchPrtType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPRTTYPERF"));
            searchPrtCtlWork.BigCarOfferDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BIGCAROFFERDIVRF"));            
            searchPrtCtlWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));            
            #endregion

            return searchPrtCtlWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
