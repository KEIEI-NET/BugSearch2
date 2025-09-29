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
    /// 層別設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 層別設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 脇田　靖之</br>
    /// <br>Date       : 2013.02.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PartsLayerStPmDB : RemoteDB, IPartsLayerStPmDB
    {
        /// <summary>
        /// 層別設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        public PartsLayerStPmDB()
            :
            base("PMKHN09917D", "Broadleaf.Application.Remoting.ParamData.PartsLayerStPmWork", "PARTSLAYERSTPMRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の層別設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="PartsLayerStPmWork">検索結果</param>
        /// <param name="paraPartsLayerStPmWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の層別設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int Search(out object PartsLayerStPmWork, object paraPartsLayerStPmWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            PartsLayerStPmWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPartsLayerStPmProc(out PartsLayerStPmWork, paraPartsLayerStPmWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsLayerStPmDB.Search");
                PartsLayerStPmWork = new ArrayList();
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
        /// 指定された条件の層別設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objPartsLayerStPmWork">検索結果</param>
        /// <param name="paraPartsLayerStPmWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の層別設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int SearchPartsLayerStPmProc(out object objPartsLayerStPmWork, object paraPartsLayerStPmWork, ref SqlConnection sqlConnection)
        {
            PartsLayerStPmWork partsLayerStPmWork = null;

            ArrayList PartsLayerStPmWorkList = paraPartsLayerStPmWork as ArrayList;
            if (PartsLayerStPmWorkList == null)
            {
                partsLayerStPmWork = paraPartsLayerStPmWork as PartsLayerStPmWork;
            }
            else
            {
                if (PartsLayerStPmWorkList.Count > 0)
                    partsLayerStPmWork = PartsLayerStPmWorkList[0] as PartsLayerStPmWork;
            }

            int status = SearchPartsLayerStPmProc(out PartsLayerStPmWorkList, partsLayerStPmWork, ref sqlConnection);
            objPartsLayerStPmWork = PartsLayerStPmWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の層別設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="partsLayerStPmWorkList">検索結果</param>
        /// <param name="partsLayerStPmWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の層別設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// <br></br>
        public int SearchPartsLayerStPmProc(out ArrayList partsLayerStPmWorkList, PartsLayerStPmWork partsLayerStPmWork, ref SqlConnection sqlConnection)
        {
            return SearchPartsLayerStPmProcProc(out partsLayerStPmWorkList, partsLayerStPmWork, ref sqlConnection);
        }

        private int SearchPartsLayerStPmProcProc(out ArrayList partsLayerStPmWorkList, PartsLayerStPmWork partsLayerStPmWork, ref SqlConnection sqlConnection)
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
                sqlTxt += "  ,PARTSLAYERCDRF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,PARTSMAKERCODERF" + Environment.NewLine;
                sqlTxt += " FROM PARTSLAYERSTPMRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                // 層別コード
                if (partsLayerStPmWork.PartsLayerCd != string.Empty)
                {
                    whereTxt = " PARTSLAYERCDRF=@PARTSLAYERCDRF" + Environment.NewLine;
                    SqlParameter paraPartsLayerCd = sqlCommand.Parameters.Add("@FINDPARTSLAYERCD", SqlDbType.NChar);
                    paraPartsLayerCd.Value = SqlDataMediator.SqlSetString(partsLayerStPmWork.PartsLayerCd);
                }
                // BLコード
                if (partsLayerStPmWork.BLGoodsCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(partsLayerStPmWork.BLGoodsCode);
                }
                // 部品メーカーコード
                if (partsLayerStPmWork.PartsMakerCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " PARTSMAKERCODERF=@FINDPARTSMAKERCODE" + Environment.NewLine;
                    SqlParameter paraPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCODE", SqlDbType.Int);
                    paraPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(partsLayerStPmWork.PartsMakerCode);
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
                    al.Add(CopyToPartsLayerStPmWorkFromReader(ref myReader));
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

            partsLayerStPmWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の層別設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <param name="parabyte">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の層別設定マスタを戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int Read(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                PartsLayerStPmWork partsLayerStPmWork = new PartsLayerStPmWork();

                // XMLの読み込み
                partsLayerStPmWork = (PartsLayerStPmWork)XmlByteSerializer.Deserialize(parabyte, typeof(PartsLayerStPmWork));
                if (partsLayerStPmWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref partsLayerStPmWork, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(partsLayerStPmWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsLayerStPmDB.Read");
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
        /// 指定された条件の層別設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="parabyte">PartsLayerStPmWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の層別設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        public int ReadProc(ref PartsLayerStPmWork partsLayerStPmWork, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref partsLayerStPmWork, ref sqlConnection);
        }

        private int ReadProcProc(ref PartsLayerStPmWork partsLayerStPmWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,PARTSLAYERCDRF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCDDERIVEDNORF" + Environment.NewLine;
                sqlTxt += "  ,PARTSMAKERCODERF" + Environment.NewLine;
                sqlTxt += " FROM PARTSLAYERSTPMRF" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {
                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        partsLayerStPmWork = CopyToPartsLayerStPmWorkFromReader(ref myReader);
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
        /// クラス格納処理 Reader → PartsLayerStPmWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsLayerStPmWork</returns>
        /// <remarks>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        private PartsLayerStPmWork CopyToPartsLayerStPmWorkFromReader(ref SqlDataReader myReader)
        {
            PartsLayerStPmWork wkPartsLayerStPmWork = new PartsLayerStPmWork();

            #region クラスへ格納
            wkPartsLayerStPmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkPartsLayerStPmWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
            wkPartsLayerStPmWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkPartsLayerStPmWork.BLGoodsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDDERIVEDNORF"));
            wkPartsLayerStPmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));

            #endregion

            return wkPartsLayerStPmWork;
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
            PartsLayerStPmWork[] partsLayerStPmWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is PartsLayerStPmWork)
                    {
                        PartsLayerStPmWork wkPartsLayerStPmWork = paraobj as PartsLayerStPmWork;
                        if (wkPartsLayerStPmWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkPartsLayerStPmWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            partsLayerStPmWorkArray = (PartsLayerStPmWork[])XmlByteSerializer.Deserialize(byteArray, typeof(PartsLayerStPmWork[]));
                        }
                        catch (Exception) { }
                        if (partsLayerStPmWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(partsLayerStPmWorkArray);
                        }
                        else
                        {
                            try
                            {
                                PartsLayerStPmWork wkPartsLayerStPmWork = (PartsLayerStPmWork)XmlByteSerializer.Deserialize(byteArray, typeof(PartsLayerStPmWork));
                                if (wkPartsLayerStPmWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkPartsLayerStPmWork);
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
