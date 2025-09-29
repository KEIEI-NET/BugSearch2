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
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// BLコードマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内　数馬</br>
    /// <br>Date       : 2008.06.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TbsPartsCodeDB : RemoteDB, ITbsPartsCodeDB
    {
        /// <summary>
        /// BLコードマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        public TbsPartsCodeDB()
            :
            base("PMTKD09033D", "Broadleaf.Application.Remoting.ParamData.TbsPartsCodeWork", "TBSPARTSCODERF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件のBLコードマスタ情報LISTを戻します
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        public int Search(out object TbsPartsCodeWork, object paraTbsPartsCodeWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TbsPartsCodeWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchTbsPartsCodeProc(out TbsPartsCodeWork, paraTbsPartsCodeWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TbsPartsCodeDB.Search");
                TbsPartsCodeWork = new ArrayList();
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
        /// 指定された条件のBLコードマスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objTbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        public int SearchTbsPartsCodeProc(out object objTbsPartsCodeWork, object paraTbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            TbsPartsCodeWork tbsPartsCodeWork = null;

            ArrayList TbsPartsCodeWorkList = paraTbsPartsCodeWork as ArrayList;
            if (TbsPartsCodeWorkList == null)
            {
                tbsPartsCodeWork = paraTbsPartsCodeWork as TbsPartsCodeWork;
            }
            else
            {
                if (TbsPartsCodeWorkList.Count > 0)
                    tbsPartsCodeWork = TbsPartsCodeWorkList[0] as TbsPartsCodeWork;
            }

            int status = SearchTbsPartsCodeProc(out TbsPartsCodeWorkList, tbsPartsCodeWork, ref sqlConnection);
            objTbsPartsCodeWork = TbsPartsCodeWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のBLコードマスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">検索結果</param>
        /// <param name="tbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// <br></br>
        public int SearchTbsPartsCodeProc(out ArrayList tbsPartsCodeWorkList, TbsPartsCodeWork tbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            return SearchTbsPartsCodeProcProc(out tbsPartsCodeWorkList, tbsPartsCodeWork, ref sqlConnection);
        }

        private int SearchTbsPartsCodeProcProc(out ArrayList tbsPartsCodeWorkList, TbsPartsCodeWork tbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSHALFNAMERF" + Environment.NewLine;
                sqlTxt += "  ,EQUIPGENRERF" + Environment.NewLine;
                sqlTxt += "  ,PRIMESEARCHFLGRF" + Environment.NewLine;
                sqlTxt += " FROM TBSPARTSCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //BLコード
                if (tbsPartsCodeWork.TbsPartsCode != 0)
                {
                    //sqlTxt = "WHERE" + Environment.NewLine;
                    whereTxt = " TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                    SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                    paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeWork.TbsPartsCode);
                }
                //提供日付
                if (tbsPartsCodeWork.OfferDate != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " OFFERDATERF>@FINDOFFERDATE" + Environment.NewLine; // 最新提供データ検索のため。20081031
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                    paraOfferDate.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeWork.OfferDate);
                }
                // BLコード枝番なし
                if (whereTxt != string.Empty) whereTxt += " AND ";
                whereTxt += " (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)" + Environment.NewLine;

                if (whereTxt != string.Empty)
                {
                    sqlTxt += " WHERE " + Environment.NewLine;
                    sqlTxt += whereTxt + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToTbsPartsCodeWorkFromReader(ref myReader));
                }
                if (al.Count > 0)
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            tbsPartsCodeWorkList = al;

            return status;
        }
        #endregion

        #region [SearchDerived]
        /// <summary>
        /// 指定された条件のBLコードマスタ(枝番あり)情報LISTを戻します
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.01</br>
        public int SearchDerived(out object TbsPartsCodeWork, object paraTbsPartsCodeWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TbsPartsCodeWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchDerivedProc(out TbsPartsCodeWork, paraTbsPartsCodeWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TbsPartsCodeDB.Search");
                TbsPartsCodeWork = new ArrayList();
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
        /// 指定された条件のBLコードマスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objTbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        public int SearchDerivedProc(out object objTbsPartsCodeWork, object paraTbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            TbsPartsCodeWork tbsPartsCodeWork = null;

            ArrayList TbsPartsCodeWorkList = paraTbsPartsCodeWork as ArrayList;
            if (TbsPartsCodeWorkList == null)
            {
                tbsPartsCodeWork = paraTbsPartsCodeWork as TbsPartsCodeWork;
            }
            else
            {
                if (TbsPartsCodeWorkList.Count > 0)
                    tbsPartsCodeWork = TbsPartsCodeWorkList[0] as TbsPartsCodeWork;
            }

            int status = SearchDerivedProc(out TbsPartsCodeWorkList, tbsPartsCodeWork, ref sqlConnection);
            objTbsPartsCodeWork = TbsPartsCodeWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のBLコードマスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">検索結果</param>
        /// <param name="tbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// <br></br>
        public int SearchDerivedProc(out ArrayList tbsPartsCodeWorkList, TbsPartsCodeWork tbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            return SearchDerivedProcProc(out tbsPartsCodeWorkList, tbsPartsCodeWork, ref sqlConnection);
        }

        private int SearchDerivedProcProc(out ArrayList tbsPartsCodeWorkList, TbsPartsCodeWork tbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSHALFNAMERF" + Environment.NewLine;
                sqlTxt += "  ,EQUIPGENRERF" + Environment.NewLine;
                sqlTxt += "  ,PRIMESEARCHFLGRF" + Environment.NewLine;
                sqlTxt += " FROM TBSPARTSCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //BLコード
                if (tbsPartsCodeWork.TbsPartsCode != 0)
                {
                    //sqlTxt = "WHERE" + Environment.NewLine;
                    whereTxt = " TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                    SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                    paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeWork.TbsPartsCode);
                }
                //提供日付
                if (tbsPartsCodeWork.OfferDate != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " OFFERDATERF>@FINDOFFERDATE" + Environment.NewLine; // 最新提供データ検索のため。20081031
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                    paraOfferDate.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeWork.OfferDate);
                }
                if (whereTxt != string.Empty)
                {
                    sqlTxt += " WHERE " + Environment.NewLine;
                    sqlTxt += whereTxt + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToTbsPartsCodeWorkFromReader(ref myReader));
                }
                if (al.Count > 0)
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            tbsPartsCodeWorkList = al;

            return status;
        }
        #endregion



        #region [Read]
        /// <summary>
        /// 指定された条件のBLコードマスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <param name="parabyte">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタを戻します</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        public int Read(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();

                // XMLの読み込み
                tbsPartsCodeWork = (TbsPartsCodeWork)XmlByteSerializer.Deserialize(parabyte, typeof(TbsPartsCodeWork));
                if (tbsPartsCodeWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref tbsPartsCodeWork, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(tbsPartsCodeWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TbsPartsCodeDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件のBLコードマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="parabyte">TbsPartsCodeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        public int ReadProc(ref TbsPartsCodeWork tbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref tbsPartsCodeWork, ref sqlConnection);
        }

        private int ReadProcProc(ref TbsPartsCodeWork tbsPartsCodeWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,TBSPARTSHALFNAMERF" + Environment.NewLine;
                sqlTxt += "  ,EQUIPGENRERF" + Environment.NewLine;
                sqlTxt += "  ,PRIMESEARCHFLGRF" + Environment.NewLine;
                sqlTxt += " FROM TBSPARTSCODERF" + Environment.NewLine;
                sqlTxt += " WHERE" + Environment.NewLine;
                sqlTxt += "     TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeWork.TbsPartsCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        tbsPartsCodeWork = CopyToTbsPartsCodeWorkFromReader(ref myReader);
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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → TbsPartsCodeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TbsPartsCodeWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private TbsPartsCodeWork CopyToTbsPartsCodeWorkFromReader(ref SqlDataReader myReader)
        {
            TbsPartsCodeWork wkTbsPartsCodeWork = new TbsPartsCodeWork();

            #region クラスへ格納
            wkTbsPartsCodeWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkTbsPartsCodeWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkTbsPartsCodeWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkTbsPartsCodeWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            wkTbsPartsCodeWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
            wkTbsPartsCodeWork.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
            wkTbsPartsCodeWork.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
            wkTbsPartsCodeWork.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
            wkTbsPartsCodeWork.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

            #endregion

            return wkTbsPartsCodeWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            TbsPartsCodeWork[] tbsPartsCodeWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is TbsPartsCodeWork)
                    {
                        TbsPartsCodeWork wkTbsPartsCodeWork = paraobj as TbsPartsCodeWork;
                        if (wkTbsPartsCodeWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkTbsPartsCodeWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            tbsPartsCodeWorkArray = (TbsPartsCodeWork[])XmlByteSerializer.Deserialize(byteArray, typeof(TbsPartsCodeWork[]));
                        }
                        catch (Exception) { }
                        if (tbsPartsCodeWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(tbsPartsCodeWorkArray);
                        }
                        else
                        {
                            try
                            {
                                TbsPartsCodeWork wkTbsPartsCodeWork = (TbsPartsCodeWork)XmlByteSerializer.Deserialize(byteArray, typeof(TbsPartsCodeWork));
                                if (wkTbsPartsCodeWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkTbsPartsCodeWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
