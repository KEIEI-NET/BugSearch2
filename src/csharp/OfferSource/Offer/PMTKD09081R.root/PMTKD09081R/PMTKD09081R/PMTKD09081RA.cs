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
    /// 部位マスタ（提供）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部位マスタ（マスタ提供）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PartsPosCodeDB : RemoteDB, IPartsPosCodeDB
    {
        #region [ コンストラクタ]
        /// <summary>
        /// 部位マスタ（提供）リモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public PartsPosCodeDB()
            :
            base("PMTKD09083D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeWork", "PARTSPOSCODERF")
        {
        }
        #endregion

        #region [Search]

        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="partsPosCodeList">検索結果</param>
        /// <param name="paraPartsPosCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(out object partsPosCodeList, object paraPartsPosCodeWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            partsPosCodeList = null;
            try
            {
                PartsPosCodeWork PartsPosCodeCondition = paraPartsPosCodeWork as PartsPosCodeWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out partsPosCodeList, PartsPosCodeCondition, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsPosCodeDB.Search");
                partsPosCodeList = new ArrayList();
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
        /// <param name="partsPosCodeList">検索結果</param>
        /// <param name="paraPartsPosCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        public int SearchProc(out object partsPosCodeList, PartsPosCodeWork paraPartsPosCodeWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchProcProc(out partsPosCodeList, paraPartsPosCodeWork, sqlConnection, sqlTransaction);
        }

        private int SearchProcProc(out object partsPosCodeList, PartsPosCodeWork paraPartsPosCodeWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            partsPosCodeList = null;
            ArrayList listPartsPos = new ArrayList();

            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.SEARCHPARTSTYPERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.BIGCAROFFERDIVRF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.SEARCHPARTSPOSCODERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.SEARCHPARTSPOSNAMERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.POSDISPORDERRF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.TBSPARTSCODERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += " FROM PARTSPOSCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                if (paraPartsPosCodeWork != null)
                {
                    if (paraPartsPosCodeWork.SearchPartsPosCode != 0)
                    {
                        whereTxt += "PARTSPOSCODERF.SEARCHPARTSPOSCODERF = @FINDSEARCHPOSCODE" + Environment.NewLine;
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDSEARCHPOSCODE", SqlDbType.Int)).Value =
                                SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.SearchPartsPosCode);
                    }
                    if (paraPartsPosCodeWork.SearchPartsType != 0)
                    {
                        if (whereTxt.Length > 0)
                        {
                            whereTxt += " AND ";
                        }
                        whereTxt += " PARTSPOSCODERF.SEARCHPARTSTYPERF = @FINDSEARCHPARTSTYPE" + Environment.NewLine;
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDSEARCHPARTSTYPE", SqlDbType.Int)).Value =
                                SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.SearchPartsType);
                    }
                    if (paraPartsPosCodeWork.BigCarOfferDiv != 0)
                    {
                        if (whereTxt.Length > 0)
                        {
                            whereTxt += " AND ";
                        }
                        whereTxt += " PARTSPOSCODERF.BIGCAROFFERDIVRF = @FINDBIGCAROFFERDIV" + Environment.NewLine;
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDBIGCAROFFERDIV", SqlDbType.Int)).Value =
                                SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.BigCarOfferDiv);
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
                    listPartsPos.Add(CopyToPartsPosCodeWorkFromReader(myReader));
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
            partsPosCodeList = listPartsPos;
            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="partsPosInfoList">検索結果</param>
        /// <param name="paraPartsPosCode">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(out object partsPosInfoList, object paraPartsPosCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            partsPosInfoList = null;
            try
            {
                PartsPosCodeWork PartsPosCodeCondition = paraPartsPosCode as PartsPosCodeWork;
                if (PartsPosCodeCondition == null)
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(out partsPosInfoList, PartsPosCodeCondition, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsPosCodeDB.Read");
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
        /// <param name="paraPartsPosCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc(out object partsPosInfoRet, PartsPosCodeWork paraPartsPosCodeWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return ReadProcProc(out partsPosInfoRet, paraPartsPosCodeWork, sqlConnection, sqlTransaction);
        }

        private int ReadProcProc(out object partsPosInfoRet, PartsPosCodeWork paraPartsPosCodeWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            partsPosInfoRet = null;
            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.SEARCHPARTSTYPERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.BIGCAROFFERDIVRF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.SEARCHPARTSPOSCODERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.SEARCHPARTSPOSNAMERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.POSDISPORDERRF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.TBSPARTSCODERF, " + Environment.NewLine;
                sqlTxt += " PARTSPOSCODERF.TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += " FROM PARTSPOSCODERF" + Environment.NewLine;
                sqlTxt += " WHERE PARTSPOSCODERF.SEARCHPARTSPOSCODERF = @FINDSEARCHPOSCODE" + Environment.NewLine;
                sqlTxt += " AND PARTSPOSCODERF.SEARCHPARTSTYPERF = @FINDSEARCHPARTSTYPE" + Environment.NewLine;
                sqlTxt += " AND PARTSPOSCODERF.BIGCAROFFERDIVRF = @FINDBIGCAROFFERDIV" + Environment.NewLine;
                sqlTxt += " AND PARTSPOSCODERF.TBSPARTSCODERF = @FINDTBSPARTSCODE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction))
                {
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDSEARCHPOSCODE", SqlDbType.Int)).Value =
                            SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.SearchPartsPosCode);
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDSEARCHPARTSTYPE", SqlDbType.Int)).Value =
                            SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.SearchPartsType);
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDBIGCAROFFERDIV", SqlDbType.Int)).Value =
                            SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.BigCarOfferDiv);
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int)).Value =
                            SqlDataMediator.SqlSetInt(paraPartsPosCodeWork.TbsPartsCode);

                    //Selectコマンドの生成

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        partsPosInfoRet = (object)CopyToPartsPosCodeWorkFromReader(myReader);
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
                base.WriteErrorLog(ex, "PartsPosCodeDB.ReadProcにてエラー発生 Msg=" + ex.Message, 0);
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
        /// クラス格納処理 Reader → PartsPosCodeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsPosCodeWork</returns>
        private PartsPosCodeWork CopyToPartsPosCodeWorkFromReader(SqlDataReader myReader)
        {
            PartsPosCodeWork partsPosCodeWk = new PartsPosCodeWork();

            #region クラスへ格納
            partsPosCodeWk.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            partsPosCodeWk.SearchPartsType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPARTSTYPERF"));
            partsPosCodeWk.BigCarOfferDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BIGCAROFFERDIVRF"));
            partsPosCodeWk.SearchPartsPosCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPARTSPOSCODERF"));
            partsPosCodeWk.SearchPartsPosName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSPOSNAMERF"));
            partsPosCodeWk.PosDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSDISPORDERRF"));
            partsPosCodeWk.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            partsPosCodeWk.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
            #endregion

            return partsPosCodeWk;
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
