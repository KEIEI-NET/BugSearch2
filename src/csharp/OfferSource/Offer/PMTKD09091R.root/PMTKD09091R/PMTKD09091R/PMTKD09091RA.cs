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
    /// 仕入先マスタ(提供)リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ(提供)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.10.29</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class OfrSupplierDB : RemoteDB, IOfrSupplierDB
    {
        #region [ コンストラクタ]
        /// <summary>
        /// 仕入先マスタ(提供)リモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        /// </remarks>
        public OfrSupplierDB()
            :
            base("PMTKD09093D", "Broadleaf.Application.Remoting.ParamData.OfrSupplierWork", "OFRSUPPLIERRF")
        {
        }
        #endregion

        #region [Search]

        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="partsOfrSupplierList">検索結果</param>
        /// <param name="paraOfrSupplierWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        public int Search(out object partsOfrSupplierList, object paraOfrSupplierWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            partsOfrSupplierList = null;
            try
            {
                OfrSupplierWork PartsPosCodeCondition = paraOfrSupplierWork as OfrSupplierWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out partsOfrSupplierList, PartsPosCodeCondition, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfrSupplierDB.Search");
                partsOfrSupplierList = new ArrayList();
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
        /// <param name="partsOfrSupplierList">検索結果</param>
        /// <param name="paraOfrSupplierWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        public int SearchProc(out object partsOfrSupplierList, OfrSupplierWork paraOfrSupplierWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchProcProc(out partsOfrSupplierList, paraOfrSupplierWork, sqlConnection, sqlTransaction);
        }

        private int SearchProcProc(out object partsOfrSupplierList, OfrSupplierWork paraOfrSupplierWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            partsOfrSupplierList = null;
            ArrayList listPartsPos = new ArrayList();

            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERCDRF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERNM1RF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERKANARF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERSNMRF " + Environment.NewLine;
                sqlTxt += " FROM OFRSUPPLIERRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                if (paraOfrSupplierWork != null)
                {
                    if (paraOfrSupplierWork.SupplierCd != 0)
                    {
                        whereTxt += "OFRSUPPLIERRF.SUPPLIERCDRF = @FINDSUPPLIERCDRF" + Environment.NewLine;
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int)).Value =
                                SqlDataMediator.SqlSetInt(paraOfrSupplierWork.SupplierCd);
                    }                    
                    if (whereTxt.Length > 0)
                    {
                        sqlTxt = sqlTxt + " WHERE " + whereTxt;
                    }
                }

                sqlCommand.CommandText = sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listPartsPos.Add(CopyToOfrSupplierWorkFromReader(myReader));
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
            partsOfrSupplierList = listPartsPos;
            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="partsOfrSupplierList">検索結果</param>
        /// <param name="paraOfrSupplierWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        public int Read(out object partsOfrSupplierList, object paraOfrSupplierWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            partsOfrSupplierList = null;
            try
            {
                OfrSupplierWork PartsPosCodeCondition = paraOfrSupplierWork as OfrSupplierWork;
                if (PartsPosCodeCondition == null)
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(out partsOfrSupplierList, PartsPosCodeCondition, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfrSupplierDB.Read");
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
        /// <param name="partsPosInfoRet">検索結果</param>
        /// <param name="paraOfrSupplierWork">検索パラメータ</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc(out object partsPosInfoRet, OfrSupplierWork paraOfrSupplierWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return ReadProcProc(out partsPosInfoRet, paraOfrSupplierWork, sqlConnection, sqlTransaction);
        }

        private int ReadProcProc(out object partsPosInfoRet, OfrSupplierWork paraOfrSupplierWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            partsPosInfoRet = null;
            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERCDRF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERNM1RF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERKANARF, " + Environment.NewLine;
                sqlTxt += " OFRSUPPLIERRF.SUPPLIERSNMRF " + Environment.NewLine;                
                sqlTxt += " FROM OFRSUPPLIERRF" + Environment.NewLine;
                sqlTxt += " WHERE OFRSUPPLIERRF.SUPPLIERCDRF = @FINDSUPPLIERCDRF" + Environment.NewLine;
                
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction))
                {
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int)).Value =
                            SqlDataMediator.SqlSetInt(paraOfrSupplierWork.SupplierCd);                    

                    //Selectコマンドの生成

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        partsPosInfoRet = (object)CopyToOfrSupplierWorkFromReader(myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfrSupplierDB.ReadProcにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → OfrSupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OfrSupplierWork</returns>
        private OfrSupplierWork CopyToOfrSupplierWorkFromReader(SqlDataReader myReader)
        {
            OfrSupplierWork partsOfrSupplier = new OfrSupplierWork();

            #region クラスへ格納
            partsOfrSupplier.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            partsOfrSupplier.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            partsOfrSupplier.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            partsOfrSupplier.SupplierKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
            partsOfrSupplier.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            #endregion

            return partsOfrSupplier;
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
