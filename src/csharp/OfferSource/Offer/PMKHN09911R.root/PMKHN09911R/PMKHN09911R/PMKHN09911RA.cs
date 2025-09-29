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
    /// 純正設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 純正設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 脇田　靖之</br>
    /// <br>Date       : 2013.02.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PureSettingPmDB : RemoteDB, IPureSettingPmDB
    {
        /// <summary>
        /// 純正設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        public PureSettingPmDB()
            :
            base("PMKHN09913D", "Broadleaf.Application.Remoting.ParamData.PureSettingPmWork", "PURESETTINGPMRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の純正設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="PureSettingPmWork">検索結果</param>
        /// <param name="paraPureSettingPmWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の純正設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int Search(out object PureSettingPmWork, object paraPureSettingPmWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            PureSettingPmWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPureSettingPmProc(out PureSettingPmWork, paraPureSettingPmWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PureSettingPmDB.Search");
                PureSettingPmWork = new ArrayList();
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
        /// 指定された条件の純正設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objPureSettingPmWork">検索結果</param>
        /// <param name="paraPureSettingPmWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の純正設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int SearchPureSettingPmProc(out object objPureSettingPmWork, object paraPureSettingPmWork, ref SqlConnection sqlConnection)
        {
            PureSettingPmWork PureSettingPmWork = null;

            ArrayList PureSettingPmWorkList = paraPureSettingPmWork as ArrayList;
            if (PureSettingPmWorkList == null)
            {
                PureSettingPmWork = paraPureSettingPmWork as PureSettingPmWork;
            }
            else
            {
                if (PureSettingPmWorkList.Count > 0)
                    PureSettingPmWork = PureSettingPmWorkList[0] as PureSettingPmWork;
            }

            int status = SearchPureSettingPmProc(out PureSettingPmWorkList, PureSettingPmWork, ref sqlConnection);
            objPureSettingPmWork = PureSettingPmWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の純正設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="PureSettingPmWorkList">検索結果</param>
        /// <param name="PureSettingPmWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の純正設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// <br></br>
        public int SearchPureSettingPmProc(out ArrayList PureSettingPmWorkList, PureSettingPmWork PureSettingPmWork, ref SqlConnection sqlConnection)
        {
            return SearchPureSettingPmProcProc(out PureSettingPmWorkList, PureSettingPmWork, ref sqlConnection);
        }

        private int SearchPureSettingPmProcProc(out ArrayList PureSettingPmWorkList, PureSettingPmWork PureSettingPmWork, ref SqlConnection sqlConnection)
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
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,PARTSMAKERCODERF" + Environment.NewLine;
                sqlTxt += " FROM PURESETTINGPMRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //商品中分類コード
                if (PureSettingPmWork.GoodsMGroup != 0)
                {
                    whereTxt = " GOODSMGROUPRF=@FINDGOODSMGROUPRF" + Environment.NewLine;
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUPRF", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(PureSettingPmWork.GoodsMGroup);
                }
                //BLコード
                if (PureSettingPmWork.BLGoodsCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraPureSettingPm = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraPureSettingPm.Value = SqlDataMediator.SqlSetInt32(PureSettingPmWork.BLGoodsCode);
                }
                //部品メーカーコード
                if (PureSettingPmWork.PartsMakerCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " PARTSMAKERCODERF=@FINDPARTSMAKERCODE" + Environment.NewLine;
                    SqlParameter paraPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCODE", SqlDbType.Int);
                    paraPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(PureSettingPmWork.PartsMakerCode);
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
                    al.Add(CopyToPureSettingPmWorkFromReader(ref myReader));
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

            PureSettingPmWorkList = al;

            return status;
        }
        #endregion


        #region [Read]
        /// <summary>
        /// 指定された条件の純正設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <param name="parabyte">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の純正設定マスタを戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int Read(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                PureSettingPmWork PureSettingPmWork = new PureSettingPmWork();

                // XMLの読み込み
                PureSettingPmWork = (PureSettingPmWork)XmlByteSerializer.Deserialize(parabyte, typeof(PureSettingPmWork));
                if (PureSettingPmWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref PureSettingPmWork, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(PureSettingPmWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PureSettingPmDB.Read");
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
        /// 指定された条件の純正設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="parabyte">PureSettingPmWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の純正設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int ReadProc(ref PureSettingPmWork PureSettingPmWork, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref PureSettingPmWork, ref sqlConnection);
        }

        private int ReadProcProc(ref PureSettingPmWork PureSettingPmWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,PARTSMAKERCODERF" + Environment.NewLine;
                sqlTxt += " FROM PURESETTINGPMRF" + Environment.NewLine;
                sqlTxt += " WHERE" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {
                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        PureSettingPmWork = CopyToPureSettingPmWorkFromReader(ref myReader);
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
        /// クラス格納処理 Reader → PureSettingPmWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PureSettingPmWork</returns>
        /// <remarks>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        private PureSettingPmWork CopyToPureSettingPmWorkFromReader(ref SqlDataReader myReader)
        {
            PureSettingPmWork wkPureSettingPmWork = new PureSettingPmWork();

            #region クラスへ格納
            wkPureSettingPmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkPureSettingPmWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkPureSettingPmWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkPureSettingPmWork.BLGoodsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDDERIVEDNORF"));
            wkPureSettingPmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));

            #endregion

            return wkPureSettingPmWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            PureSettingPmWork[] PureSettingPmWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is PureSettingPmWork)
                    {
                        PureSettingPmWork wkPureSettingPmWork = paraobj as PureSettingPmWork;
                        if (wkPureSettingPmWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkPureSettingPmWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            PureSettingPmWorkArray = (PureSettingPmWork[])XmlByteSerializer.Deserialize(byteArray, typeof(PureSettingPmWork[]));
                        }
                        catch (Exception) { }
                        if (PureSettingPmWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(PureSettingPmWorkArray);
                        }
                        else
                        {
                            try
                            {
                                PureSettingPmWork wkPureSettingPmWork = (PureSettingPmWork)XmlByteSerializer.Deserialize(byteArray, typeof(PureSettingPmWork));
                                if (wkPureSettingPmWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkPureSettingPmWork);
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
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
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
