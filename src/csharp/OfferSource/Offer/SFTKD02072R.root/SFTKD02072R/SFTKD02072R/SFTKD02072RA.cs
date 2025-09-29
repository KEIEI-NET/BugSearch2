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
    /// 部品メーカー名称設定（提供）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品メーカー名称設定（提供）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22027　橋本　将樹</br>
    /// <br>Date       : 2006.06.08</br>
    /// <br></br>
    /// <br>Update Note: 30290 2008/06/03</br>
    /// <br>             テーブルレイアウト変更による修正</br>
    /// </remarks>
    [Serializable]
    public class PMakerNmDB : RemoteDB, IPMakerNmDB
    {
        #region constructor
        /// <summary>
        /// 部品メーカー名称設定（提供）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2006.06.08</br>
        /// </remarks>
        public PMakerNmDB()
            :
            base("SFTKD02074D", "Broadleaf.Application.Remoting.ParamData.PMakerNmWork", "PMAKERNMRF")
        {
        }
        #endregion

        #region Search(out object retobj, int readMode)

        /// <summary>
        /// 指定された企業コードの部品メーカー名称設定（提供）LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの部品メーカー名称設定（提供）LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2006.06.08</br>
        public int Search(out object retobj, int readMode)
        {
            try
            {
                return SearchProc(out retobj, readMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMakerNmDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 指定された企業コードの部品メーカー名称設定（提供）LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="readMode">検索区分[代わりに検索する提供日付を指定してもらう]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの部品メーカー名称設定（提供）LISTを全て戻します</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2006.06.08</br>
        private int SearchProc(out object retobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            PMakerNmWork wkPMakerNmWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return 99;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;

                //データ読込
                string query = "SELECT * FROM PMAKERNMRF ";
                sqlCommand = new SqlCommand(query, sqlConnection);
                if (readMode != 0)
                {
                    query += " WHERE OFFERDATERF = @FINDOFFERDATE";
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int)).Value
                            = SqlDataMediator.SqlSetInt(readMode);
                }
                query += " ORDER BY PARTSMAKERCODERF";
                sqlCommand.CommandText = query;

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    wkPMakerNmWork = new PMakerNmWork();
                    #region 値のセット
                    wkPMakerNmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPMakerNmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    wkPMakerNmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                    wkPMakerNmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                    #endregion
                    al.Add(wkPMakerNmWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (readMode != 0 && al.Count == 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            retobj = al;
            return status;
        }

        #endregion

        #region Search(out ArrayList retArray, int readMode, SqlConnection sqlConnection)

        /// <summary>
        /// 指定された企業コードの部品メーカー名称設定（提供）LISTを全て戻します
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="readMode">検索区分[代わりに検索する提供日付を指定してもらう]</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの部品メーカー名称設定（提供）LISTを全て戻します</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2006.06.08</br>
        public int Search(out ArrayList retArray, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                SqlDataReader myReader = null;
                PMakerNmWork wkPMakerNmWork = null;
                retArray = null;

                ArrayList al = new ArrayList();
                try
                {

                    SqlCommand sqlCommand;

                    string query = "SELECT * FROM PMAKERNMRF ";

                    //データ読込
                    sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
                    if (readMode != 0)
                    {
                        query += " WHERE OFFERDATERF > @FINDOFFERDATE";
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int)).Value
                                = SqlDataMediator.SqlSetInt(readMode);
                    }
                    query += " ORDER BY PARTSMAKERCODERF";
                    sqlCommand.CommandText = query;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkPMakerNmWork = new PMakerNmWork();
                        #region 値のセット
                        wkPMakerNmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        wkPMakerNmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                        wkPMakerNmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                        wkPMakerNmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                        #endregion
                        al.Add(wkPMakerNmWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (readMode != 0 && al.Count == 0)
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (!myReader.IsClosed) myReader.Close();
                }

                retArray = al;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMakerNmDB.Search(out ArrayList retArray,PMakerNmWork pmakernmWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)");
                retArray = new ArrayList();
            }

            return status;
        }
        #endregion

        #region Read

        /// <summary>
        /// 指定された企業コードの部品メーカー名称設定（提供）を戻します
        /// </summary>
        /// <param name="parabyte">PMakerNmWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの部品メーカー名称設定（提供）を戻します</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2006.06.08</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;

                PMakerNmWork pmakernmWork = new PMakerNmWork();

                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XMLの読み込み
                    pmakernmWork = (PMakerNmWork)XmlByteSerializer.Deserialize(parabyte, typeof(PMakerNmWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Selectコマンドの生成
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PMAKERNMRF WHERE PARTSMAKERCODERF=@FINDPARTSMAKERCODE ", sqlConnection))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(pmakernmWork.PartsMakerCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            #region 値のセット
                            pmakernmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                            pmakernmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                            pmakernmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                            pmakernmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                            #endregion
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(pmakernmWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMakerNmDB.Read");
            }
            return status;
        }

        #endregion
    }
}
