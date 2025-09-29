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
    /// 結合マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井　亮太</br>
    /// <br>Date       : 2009.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class JoinPartsDB : RemoteDB, IJoinPartsDB
    {
        /// <summary>
        /// 結合マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009.06.22</br>
        /// </remarks>
        public JoinPartsDB()
            :
            base("PMTKD01213D", "Broadleaf.Application.Remoting.ParamData.JoinPartsWork", "JOINPARTSRF")
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
        public int Search(out object joinPartsWork, object paraJoinPartsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            joinPartsWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchJoinPartsProc(out joinPartsWork, paraJoinPartsWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "JoinPartsDB.Search");
                joinPartsWork = new ArrayList();
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
        public int SearchJoinPartsProc(out object objJoinPartsWork, object paraJoinPartsWork, ref SqlConnection sqlConnection)
        {
            JoinPartsWork joinPartsWork = null;

            ArrayList paraJoinPartsWorkList = paraJoinPartsWork as ArrayList;
            ArrayList JoinPartsWorkList = null;
            if (paraJoinPartsWorkList == null)
            {
                joinPartsWork = new JoinPartsWork();
                paraJoinPartsWorkList = new ArrayList();
                paraJoinPartsWorkList.Add(joinPartsWork);
            }

            int status = SearchJoinPartsProc(out JoinPartsWorkList, paraJoinPartsWorkList, ref sqlConnection);
            objJoinPartsWork = JoinPartsWorkList;
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
        public int SearchJoinPartsProc(out ArrayList joinPartsWorkList, ArrayList paraJoinPartsWorkList, ref SqlConnection sqlConnection)
        {
            return SearchJoinPartsProcProc(out joinPartsWorkList, paraJoinPartsWorkList, ref sqlConnection);
        }

        private int SearchJoinPartsProcProc(out ArrayList joinPartsWorkList, ArrayList paraJoinPartsWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                foreach (JoinPartsWork joinPartsWork in paraJoinPartsWorkList)
                {
                    string sqlTxt = string.Empty;
                    string whereTxt = string.Empty;

                    sqlTxt += "SELECT OFFERDATERF " + Environment.NewLine;
                    sqlTxt += "        ,GOODSMGROUPRF " + Environment.NewLine;
                    sqlTxt += "        ,TBSPARTSCODERF " + Environment.NewLine;
                    sqlTxt += "        ,TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                    sqlTxt += "        ,PRMSETDTLNO1RF " + Environment.NewLine;
                    sqlTxt += "        ,PRMSETDTLNO2RF " + Environment.NewLine;
                    sqlTxt += "        ,JOINSOURCEMAKERCODERF " + Environment.NewLine;
                    sqlTxt += "        ,JOINSOURPARTSNOWITHHRF " + Environment.NewLine;
                    sqlTxt += "        ,JOINSOURPARTSNONONEHRF " + Environment.NewLine;
                    sqlTxt += "        ,JOINDESTMAKERCDRF " + Environment.NewLine;
                    sqlTxt += "        ,JOINDISPORDERRF " + Environment.NewLine;
                    sqlTxt += "        ,JOINDESTPARTSNORF " + Environment.NewLine;
                    sqlTxt += "        ,JOINQTYRF " + Environment.NewLine;
                    sqlTxt += "        ,SETPARTSFLGRF " + Environment.NewLine;
                    sqlTxt += "        ,JOINSPECIALNOTERF " + Environment.NewLine;
                    sqlTxt += " FROM JOINPARTSRF " + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    //結合元メーカーコード
                    if (joinPartsWork.JoinSourceMakerCode != 0)
                    {
                        whereTxt = " JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE" + Environment.NewLine;
                        SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsWork.JoinSourceMakerCode);
                    }
                    //結合元商品番号
                    if (joinPartsWork.JoinSourPartsNoWithH != "")
                    {
                        if (whereTxt != string.Empty) whereTxt += " AND ";
                        whereTxt += " JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH" + Environment.NewLine;
                        SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsWork.JoinSourPartsNoWithH);
                    }
                    // 結合先メーカーコード
                    if (joinPartsWork.JoinDestMakerCd != 0)
                    {
                        if (whereTxt != string.Empty) whereTxt += " AND ";
                        whereTxt += " JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsWork.JoinDestMakerCd);
                    }
                    // 結合先商品番号
                    if (joinPartsWork.JoinDestPartsNo != "")
                    {
                        if (whereTxt != string.Empty) whereTxt += " AND ";
                        whereTxt += " JOINDESTPARTSNORF=@JOINDESTPARTSNO" + Environment.NewLine;
                        SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsWork.JoinDestPartsNo);
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
                        al.Add(CopyToJoinPartsWorkFromReader(ref myReader));
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

            joinPartsWorkList = al;

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
        private JoinPartsWork CopyToJoinPartsWorkFromReader(ref SqlDataReader myReader)
        {
            JoinPartsWork wkJoinPartsWork = new JoinPartsWork();

            #region クラスへ格納
            wkJoinPartsWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
            wkJoinPartsWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
            wkJoinPartsWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));  // 翼部品コード
            wkJoinPartsWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));  // 翼部品コード枝番
            wkJoinPartsWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));  // 優良設定詳細コード１
            wkJoinPartsWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));  // 優良設定詳細コード２
            wkJoinPartsWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));  // 結合元メーカーコード
            wkJoinPartsWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));  // 結合元品番(－付き品番)
            wkJoinPartsWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));  // 結合元品番(－無し品番)
            wkJoinPartsWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));  // 結合先メーカーコード
            wkJoinPartsWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  // 結合表示順位
            wkJoinPartsWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));  // 結合先品番(－付き品番)
            wkJoinPartsWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));  // 結合QTY
            wkJoinPartsWork.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));  // セット品番フラグ
            wkJoinPartsWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));  // 結合規格・特記事項
            #endregion

            return wkJoinPartsWork;
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
