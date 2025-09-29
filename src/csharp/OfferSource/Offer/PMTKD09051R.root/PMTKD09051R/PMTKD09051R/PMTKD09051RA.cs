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
    /// 商品中分類マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品中分類マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class GoodsMGroupDB : RemoteDB, IGoodsMGroupDB
    {
        #region [ コンストラクタ]
        /// <summary>
        /// 商品中分類マスタリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public GoodsMGroupDB()
            :
            base("PMTKD09053D", "Broadleaf.Application.Remoting.ParamData.GoodsMGroupWork", "GOODSMGROUPRF")
        {
        }
        #endregion

        #region [Search]

        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsMGroupList">検索結果</param>
        /// <param name="paraGoodsMGroupWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(out object goodsMGroupList, object paraGoodsMGroupWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsMGroupList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchGoodsMGroupProc(out goodsMGroupList, paraGoodsMGroupWork, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMGroupDB.Search");
                goodsMGroupList = new ArrayList();
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
        /// <param name="goodsMGroupList">検索結果</param>
        /// <param name="paraGoodsMGroupWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        public int SearchGoodsMGroupProc(out object goodsMGroupList, object paraGoodsMGroupWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchGoodsMGroupProcProc(out goodsMGroupList, paraGoodsMGroupWork, sqlConnection, sqlTransaction);
        }

        private int SearchGoodsMGroupProcProc(out object goodsMGroupList, object paraGoodsMGroupWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            goodsMGroupList = null;
            ArrayList listGoodsMGroup = new ArrayList();

            GoodsMGroupWork goodsMGroupCondition = paraGoodsMGroupWork as GoodsMGroupWork;

            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.GOODSMGROUPRF, " + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.GOODSMGROUPNAMERF " + Environment.NewLine;
                sqlTxt += " FROM GOODSMGROUPRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                if (goodsMGroupCondition != null)
                {
                    //提供日付
                    if (goodsMGroupCondition.OfferDate != 0)
                    {
                        whereTxt = " GOODSMGROUPRF.OFFERDATERF > @FINDOFFERDATE ";
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int)).Value
                            = SqlDataMediator.SqlSetInt(goodsMGroupCondition.OfferDate);
                    }
                    //商品中分類コード
                    if (goodsMGroupCondition.GoodsMGroup != 0)
                    {
                        if (whereTxt != string.Empty)
                            whereTxt += " AND ";
                        whereTxt += " GOODSMGROUPRF.GOODSMGROUPRF = @FINDGOODSMGROUP ";
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int)).Value
                            = SqlDataMediator.SqlSetInt(goodsMGroupCondition.GoodsMGroup);
                    }
                    if (whereTxt != string.Empty)
                    {
                        sqlTxt += "WHERE " + whereTxt;
                        sqlCommand.CommandText = sqlTxt;
                    }
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listGoodsMGroup.Add(CopyToBLGoodsCdWorkFromReader(myReader));
                }
                if (listGoodsMGroup.Count > 0)
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
            goodsMGroupList = listGoodsMGroup;
            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品中分類マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsMGroupList">検索結果</param>
        /// <param name="paraGoodsMGroupWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(out object goodsMGroupList, object paraGoodsMGroupWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            goodsMGroupList = null;
            try
            {
                int goodsMGroup;
                if (int.TryParse(paraGoodsMGroupWork.ToString(), out goodsMGroup) == false)
                    return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(out goodsMGroupList, goodsMGroup, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsMGroupDB.Read");
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
        /// <param name="goodsMGroupRet">検索結果</param>
        /// <param name="goodsMGroupCondition">検索パラメータ</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品中分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc(out object goodsMGroupRet, int goodsMGroupCondition, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return ReadProcProc(out goodsMGroupRet, goodsMGroupCondition, sqlConnection, sqlTransaction);
        }

        private int ReadProcProc(out object goodsMGroupRet, int goodsMGroupCondition, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            goodsMGroupRet = null;
            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.OFFERDATERF, " + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.GOODSMGROUPRF, " + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.GOODSMGROUPNAMERF " + Environment.NewLine;
                sqlTxt += " FROM GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += " WHERE" + Environment.NewLine;
                sqlTxt += " GOODSMGROUPRF.GOODSMGROUPRF = " + goodsMGroupCondition.ToString();

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction))
                {
                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        goodsMGroupRet = (object)CopyToBLGoodsCdWorkFromReader(myReader);
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
                base.WriteErrorLog(ex, "GoodsMGroupDB.ReadProcにてエラー発生 Msg=" + ex.Message, 0);
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
        /// クラス格納処理 Reader → BLGoodsCdWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdWork</returns>
        private GoodsMGroupWork CopyToBLGoodsCdWorkFromReader(SqlDataReader myReader)
        {
            GoodsMGroupWork wkBLGoodsCdWork = new GoodsMGroupWork();

            #region クラスへ格納
            wkBLGoodsCdWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkBLGoodsCdWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkBLGoodsCdWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));

            #endregion

            return wkBLGoodsCdWork;
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
