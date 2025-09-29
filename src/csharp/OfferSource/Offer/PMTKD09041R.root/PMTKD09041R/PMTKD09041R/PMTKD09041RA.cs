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
    /// BL商品コードマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL商品コードマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// </remarks>
    [Serializable]
    public class BLGroupDB : RemoteDB, IBlGroupDB
    {
        #region [ コンストラクタ]
        /// <summary>
        /// BL商品コードマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        /// </remarks>
        public BLGroupDB()
            :
            base("PMTKD09043D", "Broadleaf.Application.Remoting.ParamData.BLGroupWork", "BLGROUPRF")
        {
        }
        #endregion

        #region [Search]

        /// <summary>
        /// 指定された条件のBLグループマスタ情報LISTを戻します
        /// </summary>
        /// <param name="bLGoodsCdWork">検索結果</param>
        /// <param name="paraBLGoodsCdWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLグループマスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int Search(out object bLGoodsCdWork, object paraBLGoodsCdWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            bLGoodsCdWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchBLGroupCdProc(out bLGoodsCdWork, paraBLGoodsCdWork, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGroupDB.Search");
                bLGoodsCdWork = new ArrayList();
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
        /// 指定された条件のBLグループマスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objBLGoodsCdWork">検索結果</param>
        /// <param name="paraBLGoodsCdWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLグループマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int SearchBLGroupCdProc(out object objBLGoodsCdWork, object paraBLGoodsCdWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchBLGroupCdProcProc(out objBLGoodsCdWork, paraBLGoodsCdWork, sqlConnection, sqlTransaction);
        }

        private int SearchBLGroupCdProcProc(out object objBLGoodsCdWork, object paraBLGoodsCdWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            objBLGoodsCdWork = null;
            ArrayList bLGroupWorkList = new ArrayList();

            BLGroupWork bLGroupWork = paraBLGoodsCdWork as BLGroupWork;

            try
            {
                string sqlTxt = string.Empty;
                string whereQuery = string.Empty;

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += "  BLGROUPRF.OFFERDATERF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.BLGROUPNAMERF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.BLGROUPKANANAMERF" + Environment.NewLine;
                sqlTxt += " FROM BLGROUPRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                //BLグループコード
                if (bLGroupWork != null)
                {
                    if (bLGroupWork.OfferDate != 0)
                    {
                        whereQuery = " BLGROUPRF.OFFERDATERF > @FINDOFFERDATE ";
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int)).Value
                            = SqlDataMediator.SqlSetInt(bLGroupWork.OfferDate);
                    }
                    if (bLGroupWork.BLGroupCode != 0)
                    {
                        if (whereQuery != string.Empty)
                            whereQuery += " AND ";
                        whereQuery += " BLGROUPRF.BLGROUPCODERF = @FINDBLGROUPCODE ";
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int)).Value
                            = SqlDataMediator.SqlSetInt(bLGroupWork.BLGroupCode);
                    }
                    if (whereQuery != string.Empty)
                    {
                        sqlTxt += "WHERE " + whereQuery;
                        sqlCommand.CommandText = sqlTxt;
                    }
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    bLGroupWorkList.Add(CopyToBLGoodsCdWorkFromReader(myReader));
                }
                if (bLGroupWorkList.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            objBLGoodsCdWork = bLGroupWorkList;
            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のBL商品コードマスタを戻します
        /// </summary>
        /// <param name="objBLGoodsCdWork">検索結果</param>
        /// <param name="paraBLGoodsCdWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBL商品コードマスタを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int Read(out object objBLGoodsCdWork, object paraBLGoodsCdWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            objBLGoodsCdWork = null;
            try
            {
                int bLGoodsCd;
                if (int.TryParse(paraBLGoodsCdWork.ToString(), out bLGoodsCd) == false)
                    return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(out objBLGoodsCdWork, bLGoodsCd, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGroupDB.Read");
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
        /// 指定された条件のBL商品コードマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objBLGoodsCdWork">検索結果</param>
        /// <param name="bLGroupCode">検索パラメータ</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBL商品コードマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int ReadProc(out object objBLGoodsCdWork, int bLGroupCode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return ReadProcProc(out objBLGoodsCdWork, bLGroupCode, sqlConnection, sqlTransaction);
        }

        private int ReadProcProc(out object objBLGoodsCdWork, int bLGroupCode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            BLGroupWork bLGroupData = new BLGroupWork();

            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += "  BLGROUPRF.OFFERDATERF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.BLGROUPNAMERF" + Environment.NewLine;
                sqlTxt += ", BLGROUPRF.BLGROUPKANANAMERF" + Environment.NewLine;
                sqlTxt += " FROM BLGROUPRF" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "   BLGROUPRF.BLGROUPCODERF = " + bLGroupCode.ToString() + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction))
                {
                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        bLGroupData = CopyToBLGoodsCdWorkFromReader(myReader);
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
                base.WriteErrorLog(ex, "BLGroupDB.ReadProcにてエラー発生 Msg=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            objBLGoodsCdWork = bLGroupData;
            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → BLGoodsCdWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdWork</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        /// </remarks>
        private BLGroupWork CopyToBLGoodsCdWorkFromReader(SqlDataReader myReader)
        {
            BLGroupWork wkBLGoodsCdWork = new BLGroupWork();

            #region クラスへ格納
            wkBLGoodsCdWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkBLGoodsCdWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkBLGoodsCdWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkBLGoodsCdWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            wkBLGoodsCdWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));

            #endregion

            return wkBLGoodsCdWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        /// </remarks>
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
