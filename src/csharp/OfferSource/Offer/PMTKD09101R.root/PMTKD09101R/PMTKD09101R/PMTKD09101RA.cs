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
    /// BLコード変換マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TbsPartsCodeChgDB : RemoteDB, ITbsPartsCdChgDB
    {
        /// <summary>
        /// BLコードマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        public TbsPartsCodeChgDB()
            :
            base("PMTKD09103D", "Broadleaf.Application.Remoting.ParamData.TbsPartsCdChgWork", "TBSPARTSCODECHGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件のBLコード変換マスタ情報LISTを戻します
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコード変換マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        public int Search(out object tbsPartsCdChgWork, object paraTbsPartsCdChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            tbsPartsCdChgWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchTbsPartsCodeProc(out tbsPartsCdChgWork, paraTbsPartsCdChgWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TbsPartsCdChgDB.Search");
                tbsPartsCdChgWork = new ArrayList();
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
        /// 指定された条件のBLコード変換マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objTbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコード変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        public int SearchTbsPartsCodeProc(out object objTbsPartsCdChgWork, object paraTbsPartsCdChgWork, ref SqlConnection sqlConnection)
        {
            TbsPartsCdChgWork tbsPartsCodeChgWork = null;

            ArrayList TbsPartsCodeChgWorkList = paraTbsPartsCdChgWork as ArrayList;
            if (TbsPartsCodeChgWorkList == null)
            {
                tbsPartsCodeChgWork = paraTbsPartsCdChgWork as TbsPartsCdChgWork;
            }
            else
            {
                if (TbsPartsCodeChgWorkList.Count > 0)
                    tbsPartsCodeChgWork = TbsPartsCodeChgWorkList[0] as TbsPartsCdChgWork;
            }

            int status = SearchTbsPartsCodeProc(out TbsPartsCodeChgWorkList, tbsPartsCodeChgWork, ref sqlConnection);
            objTbsPartsCdChgWork = TbsPartsCodeChgWorkList;
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        /// <br></br>
        public int SearchTbsPartsCodeProc(out ArrayList tbsPartsCodeChgWorkList, TbsPartsCdChgWork tbsPartsCodeChgWork, ref SqlConnection sqlConnection)
        {
            return SearchTbsPartsCodeProcProc(out tbsPartsCodeChgWorkList, tbsPartsCodeChgWork, ref sqlConnection);
        }

        private int SearchTbsPartsCodeProcProc(out ArrayList tbsPartsCodeChgWorkList, TbsPartsCdChgWork tbsPartsCodeChgWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += " SELECT OFFERDATERF " + Environment.NewLine;
                sqlTxt += "         ,SFVERSIONRF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSCODERF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += "         ,CHGTBSPARTSCODERF " + Environment.NewLine;
                sqlTxt += "         ,CHGTBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSFULLNAMERF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSHALFNAMERF " + Environment.NewLine;
                sqlTxt += "  FROM TBSPARTSCDCHGRF " + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //SFバージョン
                if (tbsPartsCodeChgWork.SfVersion != "")
                {
                    whereTxt += " SFVERSIONRF = @FINDSFVERSION " + Environment.NewLine;
                    SqlParameter findSfVersion = sqlCommand.Parameters.Add("@FINDSFVERSION", SqlDbType.NVarChar);  // SFバージョン
                    findSfVersion.Value = SqlDataMediator.SqlSetString(tbsPartsCodeChgWork.SfVersion);  // SFバージョン
                }

                //BLコード
                if (tbsPartsCodeChgWork.TbsPartsCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                    SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                    paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeChgWork.TbsPartsCode);
                }
                //BLコード枝番
                if (tbsPartsCodeChgWork.TbsPartsCdDerivedNo != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " TBSPARTSCDDERIVEDNORF = @FINDTBSPARTSCDDERIVEDNO " + Environment.NewLine;
                    SqlParameter findTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDTBSPARTSCDDERIVEDNO", SqlDbType.Int);  // 翼部品コード枝番
                    findTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeChgWork.TbsPartsCdDerivedNo);  // 翼部品コード枝番
                }
                //変換後BLコード 
                if (tbsPartsCodeChgWork.ChgTbsPartsCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " CHGTBSPARTSCODERF = @FINDCHGTBSPARTSCODE " + Environment.NewLine;
                    SqlParameter findChgTbsPartsCode = sqlCommand.Parameters.Add("@FINDCHGTBSPARTSCODE", SqlDbType.Int);  // 変換後BLコード
                    findChgTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeChgWork.ChgTbsPartsCode);  // 変換後BLコード
                }
                //変換後BLコード枝番
                if(tbsPartsCodeChgWork.ChgTbsPartsCdDerivedNo != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " CHGTBSPARTSCDDERIVEDNORF = @FINDCHGTBSPARTSCDDERIVEDNO " + Environment.NewLine;
                    SqlParameter findChgTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDCHGTBSPARTSCDDERIVEDNO", SqlDbType.Int);  // 変換後BLコード枝番
                    findChgTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeChgWork.ChgTbsPartsCdDerivedNo);  // 変換後BLコード枝番
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

            tbsPartsCodeChgWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のBLコード変換マスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <param name="parabyte">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコード変換マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        public int Read(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                TbsPartsCdChgWork tbsPartsCdChgWork = new TbsPartsCdChgWork();

                // XMLの読み込み
                tbsPartsCdChgWork = (TbsPartsCdChgWork)XmlByteSerializer.Deserialize(parabyte, typeof(TbsPartsCdChgWork));
                if (tbsPartsCdChgWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref tbsPartsCdChgWork, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(tbsPartsCdChgWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TbsPartsCdChgDB.Read");
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        public int ReadProc(ref TbsPartsCdChgWork tbsPartsCdChgWork, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref tbsPartsCdChgWork, ref sqlConnection);
        }

        private int ReadProcProc(ref TbsPartsCdChgWork tbsPartsCdChgWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";

                sqlTxt += " SELECT OFFERDATERF " + Environment.NewLine;
                sqlTxt += "         ,SFVERSIONRF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSCODERF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += "         ,CHGTBSPARTSCODERF " + Environment.NewLine;
                sqlTxt += "         ,CHGTBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSFULLNAMERF " + Environment.NewLine;
                sqlTxt += "         ,TBSPARTSHALFNAMERF " + Environment.NewLine;
                sqlTxt += "  FROM TBSPARTSCDCHGRF " + Environment.NewLine;
                sqlTxt += "  WHERE SFVERSIONRF = @FINDSFVERSION " + Environment.NewLine;
                sqlTxt += "         AND TBSPARTSCODERF = @FINDTBSPARTSCODE " + Environment.NewLine;
                sqlTxt += "         AND TBSPARTSCDDERIVEDNORF = @FINDTBSPARTSCDDERIVEDNO " + Environment.NewLine;
                sqlTxt += "         AND CHGTBSPARTSCODERF = @FINDCHGTBSPARTSCODE " + Environment.NewLine;
                sqlTxt += "         AND CHGTBSPARTSCDDERIVEDNORF = @FINDCHGTBSPARTSCDDERIVEDNO " + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findSfVersion = sqlCommand.Parameters.Add("@FINDSFVERSION", SqlDbType.NVarChar);  // SFバージョン
                    SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);  // 翼部品コード
                    SqlParameter findTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDTBSPARTSCDDERIVEDNO", SqlDbType.Int);  // 翼部品コード枝番
                    SqlParameter findChgTbsPartsCode = sqlCommand.Parameters.Add("@FINDCHGTBSPARTSCODE", SqlDbType.Int);  // 変換後BLコード
                    SqlParameter findChgTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDCHGTBSPARTSCDDERIVEDNO", SqlDbType.Int);  // 変換後BLコード枝番

                    //Parameterオブジェクトへ値設定
                    findSfVersion.Value = SqlDataMediator.SqlSetString(tbsPartsCdChgWork.SfVersion);  // SFバージョン
                    findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCdChgWork.TbsPartsCode);  // 翼部品コード
                    findTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(tbsPartsCdChgWork.TbsPartsCdDerivedNo);  // 翼部品コード枝番
                    findChgTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCdChgWork.ChgTbsPartsCode);  // 変換後BLコード
                    findChgTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(tbsPartsCdChgWork.ChgTbsPartsCdDerivedNo);  // 変換後BLコード枝番

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        tbsPartsCdChgWork = CopyToTbsPartsCodeWorkFromReader(ref myReader);
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private TbsPartsCdChgWork CopyToTbsPartsCodeWorkFromReader(ref SqlDataReader myReader)
        {
            TbsPartsCdChgWork wkTbsPartsCdChgWork = new TbsPartsCdChgWork();

            #region クラスへ格納
            wkTbsPartsCdChgWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
            wkTbsPartsCdChgWork.SfVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SFVERSIONRF"));  // SFバージョン
            wkTbsPartsCdChgWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));  // 翼部品コード
            wkTbsPartsCdChgWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));  // 翼部品コード枝番
            wkTbsPartsCdChgWork.ChgTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGTBSPARTSCODERF"));  // 変換後BLコード
            wkTbsPartsCdChgWork.ChgTbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGTBSPARTSCDDERIVEDNORF"));  // 変換後BLコード枝番
            wkTbsPartsCdChgWork.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));  // BLコード名称（全角）
            wkTbsPartsCdChgWork.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));  // BLコード名称（半角）
            #endregion

            return wkTbsPartsCdChgWork;
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
            TbsPartsCdChgWork[] tbsPartsCdChgWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is TbsPartsCdChgWork)
                    {
                        TbsPartsCdChgWork wkTbsPartsCdChgWork = paraobj as TbsPartsCdChgWork;
                        if (wkTbsPartsCdChgWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkTbsPartsCdChgWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            tbsPartsCdChgWorkArray = (TbsPartsCdChgWork[])XmlByteSerializer.Deserialize(byteArray, typeof(TbsPartsCdChgWork[]));
                        }
                        catch (Exception) { }
                        if (tbsPartsCdChgWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(tbsPartsCdChgWorkArray);
                        }
                        else
                        {
                            try
                            {
                                TbsPartsCdChgWork wkTbsPartsCdChgWork = (TbsPartsCdChgWork)XmlByteSerializer.Deserialize(byteArray, typeof(TbsPartsCdChgWork));
                                if (wkTbsPartsCdChgWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkTbsPartsCdChgWork);
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
