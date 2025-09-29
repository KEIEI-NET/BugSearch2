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
    /// セットマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : セットマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井　亮太</br>
    /// <br>Date       : 2009.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SetPartsDB : RemoteDB, ISetPartsDB
    {
        /// <summary>
        /// 結合マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// </remarks>
        public SetPartsDB()
            :
            base("PMTKD01223D", "Broadleaf.Application.Remoting.ParamData.SetPartsWork", "SETPARTSRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の結合マスタ情報LISTを戻します
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        public int Search(out object setPartsWork, object paraSetPartsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            setPartsWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSetPartsProc(out setPartsWork, paraSetPartsWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SetPartsDB.Search");
                setPartsWork = new ArrayList();
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
        /// 指定された条件の結合マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objTbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の結合マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        public int SearchSetPartsProc(out object objSetPartsWork, object paraSetPartsWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SetPartsWork setPartsWork = null;

            ArrayList paraSetPartsWorkList = paraSetPartsWork as ArrayList;
            ArrayList setPartsWorkList = null;
            if (paraSetPartsWorkList == null)
            {
                setPartsWork = new SetPartsWork();
                paraSetPartsWorkList = new ArrayList();
                paraSetPartsWorkList.Add(setPartsWork);
            }

            status = SearchSetPartsProc(out setPartsWorkList, paraSetPartsWorkList, ref sqlConnection);

            objSetPartsWork = setPartsWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の結合マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">検索結果</param>
        /// <param name="tbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の結合マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// <br></br>
        public int SearchSetPartsProc(out ArrayList setPartsWorkList, ArrayList paraSetPartsWorkList, ref SqlConnection sqlConnection)
        {
            return SearchSetPartsProcProc(out setPartsWorkList, paraSetPartsWorkList, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の結合マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">検索結果</param>
        /// <param name="tbsPartsCodeWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の結合マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// <br></br>
        private int SearchSetPartsProcProc(out ArrayList setPartsWorkList, ArrayList paraSetPartsWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                foreach (SetPartsWork setPartsWork in paraSetPartsWorkList)
                {
                    string sqlTxt = string.Empty;
                    string whereTxt = string.Empty;

                    sqlTxt += " SELECT OFFERDATERF " + Environment.NewLine;
                    sqlTxt += "         ,GOODSMGROUPRF " + Environment.NewLine;
                    sqlTxt += "         ,TBSPARTSCODERF " + Environment.NewLine;
                    sqlTxt += "         ,TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                    sqlTxt += "         ,SETMAINMAKERCDRF " + Environment.NewLine;
                    sqlTxt += "         ,SETMAINPARTSNORF " + Environment.NewLine;
                    sqlTxt += "         ,SETSUBMAKERCDRF " + Environment.NewLine;
                    sqlTxt += "         ,SETSUBPARTSNORF " + Environment.NewLine;
                    sqlTxt += "         ,SETDISPORDERRF " + Environment.NewLine;
                    sqlTxt += "         ,SETQTYRF " + Environment.NewLine;
                    sqlTxt += "         ,SETNAMERF " + Environment.NewLine;
                    sqlTxt += "         ,SETSPECIALNOTERF " + Environment.NewLine;
                    sqlTxt += "         ,CATALOGSHAPENORF " + Environment.NewLine;
                    sqlTxt += "  FROM SETPARTSRF " + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    //セット親メーカーコード
                    if (setPartsWork.SetMainMakerCd != 0)
                    {
                        whereTxt += " SETMAINMAKERCDRF = @FINDSETMAINMAKERCD " + Environment.NewLine;
                        SqlParameter paraSetMainMakerCd = sqlCommand.Parameters.Add("@FINDSETMAINMAKERCD", SqlDbType.Int);
                        paraSetMainMakerCd.Value = SqlDataMediator.SqlSetInt32(setPartsWork.SetMainMakerCd);
                    }
                    //セット親商品番号
                    if (setPartsWork.SetMainPartsNo != "")
                    {
                        if (whereTxt != string.Empty) whereTxt += " AND ";
                        whereTxt += " SETMAINPARTSNORF = @FINDSETMAINPARTSNO " + Environment.NewLine;
                        SqlParameter paraSetMainPartsNo = sqlCommand.Parameters.Add("@FINDSETMAINPARTSNO", SqlDbType.NVarChar);
                        paraSetMainPartsNo.Value = SqlDataMediator.SqlSetString(setPartsWork.SetMainPartsNo);
                    }
                    // セット子メーカーコード
                    if (setPartsWork.SetSubMakerCd != 0)
                    {
                        if (whereTxt != string.Empty) whereTxt += " AND ";
                        whereTxt += " SETSUBMAKERCDRF = @FINDSETSUBMAKERCD " + Environment.NewLine;
                        SqlParameter paraSetSubMakerCd = sqlCommand.Parameters.Add("@FINDSETSUBMAKERCD", SqlDbType.Int);
                        paraSetSubMakerCd.Value = SqlDataMediator.SqlSetInt32(setPartsWork.SetSubMakerCd);
                    }
                    // セット子商品番号
                    if (setPartsWork.SetSubPartsNo != "")
                    {
                        if (whereTxt != string.Empty) whereTxt += " AND ";
                        whereTxt += " SETSUBPARTSNORF = @FINDSETSUBPARTSNO " + Environment.NewLine;
                        SqlParameter paraSetSubPartsNo = sqlCommand.Parameters.Add("@FINDSETSUBPARTSNO", SqlDbType.NVarChar);
                        paraSetSubPartsNo.Value = SqlDataMediator.SqlSetString(setPartsWork.SetSubPartsNo);
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
                        al.Add(CopyToSetPartsWorkFromReader(ref myReader));
                    }
                    if (al.Count > 0)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    else
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    if (sqlCommand != null) sqlCommand.Dispose();
                    if (myReader != null)
                        if (!myReader.IsClosed) myReader.Close();
                }
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

            setPartsWorkList = al;

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
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// </remarks>
        private SetPartsWork CopyToSetPartsWorkFromReader(ref SqlDataReader myReader)
        {
            SetPartsWork wkSetPartsWork = new SetPartsWork();

            #region クラスへ格納
            wkSetPartsWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
            wkSetPartsWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
            wkSetPartsWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));  // 翼部品コード
            wkSetPartsWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));  // 翼部品コード枝番
            wkSetPartsWork.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETMAINMAKERCDRF"));  // セット親メーカーコード
            wkSetPartsWork.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETMAINPARTSNORF"));  // セット親品番
            wkSetPartsWork.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETSUBMAKERCDRF"));  // セット子メーカーコード
            wkSetPartsWork.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSUBPARTSNORF"));  // セット子品番
            wkSetPartsWork.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETDISPORDERRF"));  // セット表示順位
            wkSetPartsWork.SetQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SETQTYRF"));  // セットQTY
            wkSetPartsWork.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF"));  // セット名称
            wkSetPartsWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));  // セット規格・特記事項
            wkSetPartsWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));  // カタログ図番
            #endregion

            return wkSetPartsWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
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
