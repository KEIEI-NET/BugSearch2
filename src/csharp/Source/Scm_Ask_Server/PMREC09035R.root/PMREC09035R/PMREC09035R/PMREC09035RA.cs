//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品グループ設定マスタ
// プログラム概要   : お買い得商品グループ設定マスタDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 亘
// 作 成 日  2015/02/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 亘
// 作 成 日  2015/03/05  修正内容 : JOIN条件の変更、GROUPBY句の追加
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// お買い得商品グループ設定マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買い得商品グループ設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 佐々木 亘</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecBgnGrpDB : RemoteDB, IRecBgnGrpDB
    {

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public RecBgnGrpDB() : base("PMREC09037D", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork", "RECBGNGRPRF")
        {
        }

        #endregion

        #region [コネクション生成処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            // 接続文字列取得
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            // コネクション作成
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }

        #endregion

        #region [トランザクション生成処理]

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region IRecBgnGrpDB メンバ

        /// <summary>
        /// 検索処理（お買得商品グループマスタ全件検索）
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="cnectOtherEpCd">PM自社企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Search(out object retobj, string cnectOtherEpCd, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int substatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retobj = null;
            count = 0;
            ArrayList retAryList = new ArrayList();
            ArrayList retUsrAryList = new ArrayList();

            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // お買得商品グループマスタ（提供）全件取得
                status = SearchAllOfferProc(out retAryList, logicalMode, ref count, ref errMsg, ref sqlConnection);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    // お買得商品グループマスタ（ユーザ）全件取得
                    substatus = SearchAllProc(out retUsrAryList, cnectOtherEpCd, logicalMode, ref count, ref errMsg, ref sqlConnection);
                    if (substatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (retUsrAryList != null)
                        {
                            retAryList.AddRange(retUsrAryList);
                        }
                        // お買得商品グループマスタ（ユーザ）の状態を返す
                        status = substatus;
                    }
                    else if (substatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // お買得商品グループマスタ（提供）の状態を戻す
                    }
                    else
                    {
                        // お買得商品グループマスタ（ユーザ）の状態を返す
                        status = substatus;
                    }
                }
                retobj = retAryList;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, "RecBgnGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 検索処理（お買得商品グループマスタ検索）
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGrpSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Search(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int substatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retobj = null;
            count = 0;
            ArrayList retAryList = new ArrayList();
            ArrayList retUsrAryList = new ArrayList();

            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // お買得商品グループマスタ（提供）全件取得
                status = SearchAllOfferProc(out retAryList, logicalMode, ref count, ref errMsg, ref sqlConnection);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = paraobj as RecBgnGrpSearchParaWork;
                    // SF企業・拠点コードが指定されていない場合、ユーザは取得しない
                    if ((recBgnGrpSearchParaWork.InqOriginalEpCd.ToString() != string.Empty)
                    || (recBgnGrpSearchParaWork.InqOriginalSecCd.ToString() != string.Empty))
                    {
                        // お買得商品グループマスタ（ユーザ）取得
                        substatus = SearchProc(out retUsrAryList, paraobj, logicalMode, ref count, ref errMsg, ref sqlConnection);
                        if (substatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (retUsrAryList != null)
                            {
                                retAryList.AddRange(retUsrAryList);
                            }
                            // お買得商品グループマスタ（ユーザ）の状態を返す
                            status = substatus;
                        }
                        else if (substatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // お買得商品グループマスタ（提供）の状態を戻す
                        }
                        else
                        {
                            // お買得商品グループマスタ（ユーザ）の状態を返す
                            status = substatus;
                        }
                    }
                }
                retobj = retAryList;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, "RecBgnGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #endregion

        #region 内部処理

        /// <summary>
        /// 検索処理（お買得商品グループマスタ全件検索）
        /// </summary>
        /// <param name="retAryList">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="cnectOtherEpCd">PM自社企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchAllProc(out ArrayList retAryList, string cnectOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref int count, ref string errMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region 検索用クエリ作成

            string selectTxt = " SELECT " + Environment.NewLine
                             + " RBG.CREATEDATETIMERF, " + Environment.NewLine
                             + " RBG.UPDATEDATETIMERF, " + Environment.NewLine
                             + " RBG.LOGICALDELETECODERF, " + Environment.NewLine
                             + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                             + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCODERF, " + Environment.NewLine
                             + " RBG.DISPLAYORDERRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine
                             + " FROM RECBGNGRPRF RBG WITH (READUNCOMMITTED) " + Environment.NewLine
                             + " INNER JOIN SCMEPCNECTRF AS EPCNECT WITH(READUNCOMMITTED) " + Environment.NewLine
                             + " ON EPCNECT.LOGICALDELETECODERF = 0 " + Environment.NewLine
                             + " AND EPCNECT.DISCDIVCDRF = 0 " + Environment.NewLine
                             //--- UPD  2015/03/05 佐々木 ----->>>>>
                             //+ " AND EPCNECT.CNECTORIGINALEPCDRF = @CNECTOTHEREPCD " + Environment.NewLine
                             //+ " AND EPCNECT.CNECTOTHEREPCDRF = RBG.INQORIGINALEPCDRF " + Environment.NewLine
                             + " AND EPCNECT.CNECTORIGINALEPCDRF = RBG.INQORIGINALEPCDRF " + Environment.NewLine
                             + " AND EPCNECT.CNECTOTHEREPCDRF = @CNECTOTHEREPCD " + Environment.NewLine
                             //--- UPD  2015/03/05 佐々木 -----<<<<<
                             + " INNER JOIN SCMEPSCCNTRF AS EPSCCNT WITH(READUNCOMMITTED) " + Environment.NewLine
                             + " ON EPSCCNT.LOGICALDELETECODERF = 0 " + Environment.NewLine
                             + " AND EPSCCNT.DISCDIVCDRF = 0  " + Environment.NewLine
                             + " AND EPSCCNT.CNECTORIGINALEPCDRF = EPCNECT.CNECTORIGINALEPCDRF " + Environment.NewLine
                             + " AND EPSCCNT.CNECTOTHEREPCDRF = EPCNECT.CNECTOTHEREPCDRF " + Environment.NewLine
                             + " AND (EPSCCNT.PCCUOECOMMMETHODRF = 1 OR EPSCCNT.SCMCOMMMETHODRF = 1) " + Environment.NewLine
                             + " AND (RBG.INQORIGINALSECCDRF='00' OR EPSCCNT.CNECTORIGINALSECCDRF = RBG.INQORIGINALSECCDRF) " + Environment.NewLine
                             + " WHERE RBG.LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;

            //--- ADD  2015/03/05 佐々木 ----->>>>>
            string groupTxt = " GROUP BY " + Environment.NewLine
                            + " RBG.CREATEDATETIMERF, " + Environment.NewLine
                            + " RBG.UPDATEDATETIMERF, " + Environment.NewLine
                            + " RBG.LOGICALDELETECODERF, " + Environment.NewLine
                            + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                            + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCODERF, " + Environment.NewLine
                            + " RBG.DISPLAYORDERRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine;
            //--- ADD  2015/03/05 佐々木 -----<<<<<

            string orderTxt = " ORDER BY " + Environment.NewLine
                            + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                            + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCODERF " + Environment.NewLine;
            #endregion

            ArrayList al = new ArrayList();
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // SELECT作成
                    sqlTxt.Append(selectTxt.ToString());

                    #region WHERE句作成

                    // 連結先企業コード
                    SqlParameter findCnectOtherEpCdRF = sqlCommand.Parameters.Add("@CNECTOTHEREPCD", SqlDbType.NChar);
                    findCnectOtherEpCdRF.Value = SqlDataMediator.SqlSetString(cnectOtherEpCd);

                    // 論理削除区分
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    #endregion

                    //--- ADD  2015/03/05 佐々木 ----->>>>>
                    // GROUP句作成
                    sqlTxt.Append(groupTxt.ToString());
                    //--- ADD  2015/03/05 佐々木 -----<<<<<

                    // ORDER句作成
                    sqlTxt.Append(orderTxt.ToString());

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count + count >= 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retAryList = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGrpWork recBgnGrpWork = this.CopyToRecBgnGrpWorkFromReader(ref myReader);
                        al.Add(recBgnGrpWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                }  // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGrpDB.SearchAllProc", status);
                errMsg = ex.ToString();
            }
            retAryList = al;

            return status;
        }

        /// <summary>
        /// 検索処理（お買得商品グループマスタ検索）
        /// </summary>
        /// <param name="retAryList">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGrpSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProc(out ArrayList retAryList, object paraobj, ConstantManagement.LogicalMode logicalMode, ref int count, ref string errMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region 検索用クエリ作成

            string selectTxt = " SELECT " + Environment.NewLine
                             + " RBG.CREATEDATETIMERF, " + Environment.NewLine
                             + " RBG.UPDATEDATETIMERF, " + Environment.NewLine
                             + " RBG.LOGICALDELETECODERF, " + Environment.NewLine
                             + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                             + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCODERF, " + Environment.NewLine
                             + " RBG.DISPLAYORDERRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine
                             + " FROM RECBGNGRPRF RBG WITH (READUNCOMMITTED) " + Environment.NewLine
                             + " WHERE RBG.LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;

            string orderTxt = " ORDER BY " + Environment.NewLine
                            + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                            + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCODERF " + Environment.NewLine;
            #endregion

            ArrayList al = new ArrayList();

            try
            {
                RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = paraobj as RecBgnGrpSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // SELECT作成
                    sqlTxt.Append(selectTxt.ToString());

                    #region WHERE句作成

                    // 論理削除区分
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    // 問合せ元企業コード
                    if (recBgnGrpSearchParaWork.InqOriginalEpCd.ToString() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                        SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGrpSearchParaWork.InqOriginalEpCd);
                    }

                    // 問合せ元拠点コード
                    if (recBgnGrpSearchParaWork.InqOriginalSecCd.ToString() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                        SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGrpSearchParaWork.InqOriginalSecCd);
                    }

                    // お買得商品グループコード
                    if (recBgnGrpSearchParaWork.BrgnGoodsGrpCode != 0)
                    {
                        sqlTxt.Append(" AND RBG.BRGNGOODSGRPCODERF=@BRGNGOODSGRPCODE").Append(Environment.NewLine);
                        SqlParameter findBrgnGoodsGrpCode = sqlCommand.Parameters.Add("@BRGNGOODSGRPCODE", SqlDbType.SmallInt);
                        findBrgnGoodsGrpCode.Value = SqlDataMediator.SqlSetInt16(recBgnGrpSearchParaWork.BrgnGoodsGrpCode);
                    }

                    #endregion

                    // ORDER句作成
                    sqlTxt.Append(orderTxt.ToString());

                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    sqlCommand.CommandText = sqlTxt.ToString();

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count + count >= 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retAryList = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGrpWork recBgnGrpWork = this.CopyToRecBgnGrpWorkFromReader(ref myReader);
                        al.Add(recBgnGrpWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();


                }  // end using

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGrpDB.SearchProc", status);
                errMsg = ex.ToString();
            }
            retAryList = al;

            return status;
        }

        /// <summary>
        /// 検索処理（お買得商品グループマスタ（提供）検索）
        /// </summary>
        /// <param name="retAryList">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)※現在未使用</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchAllOfferProc(out ArrayList retAryList, ConstantManagement.LogicalMode logicalMode, ref int count, ref string errMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region 検索用クエリ作成

            string selectTxt = " SELECT " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPCODERF, " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine
                             + " FROM RECBGNGRPORF RBGO WITH (READUNCOMMITTED) " + Environment.NewLine
                             + " WHERE RBGO.BRGNGOODSGRPCODERF >= 9000 " + Environment.NewLine
                             + " AND RBGO.BRGNGOODSGRPCODERF <= 9999 " + Environment.NewLine;

            string orderTxt = " ORDER BY " + Environment.NewLine
                            + " RBGO.BRGNGOODSGRPCODERF " + Environment.NewLine;
            #endregion

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // SELECT作成
                    sqlTxt.Append(selectTxt.ToString());

                    // ORDER句作成
                    sqlTxt.Append(orderTxt.ToString());

                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    sqlCommand.CommandText = sqlTxt.ToString();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count + count >= 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retAryList = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGrpWork recBgnGrpWork = this.CopyToRecBgnGrpOWorkFromReader(ref myReader);
                        al.Add(recBgnGrpWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                }  //end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchAllOfferProc", status);
                errMsg = ex.ToString();
            }
            retAryList = al;

            return status;
        }

        /// <summary>
        /// お買得商品グループ設定マスタクラス格納処理 Reader → RecBgnGrpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGrpWork</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnGrpWork CopyToRecBgnGrpWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnGrpWork recBgnGrpWork = new RecBgnGrpWork();

            #region クラスへ格納
            recBgnGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            recBgnGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            recBgnGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            recBgnGrpWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
            recBgnGrpWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            recBgnGrpWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnGrpWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            recBgnGrpWork.BrgnGoodsGrpTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTITLERF"));
            recBgnGrpWork.BrgnGoodsGrpTag = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTAGRF"));
            recBgnGrpWork.BrgnGoodsGrpComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPCOMMENTRF"));
            #endregion

            return recBgnGrpWork;
        }

        /// <summary>
        /// お買得商品グループ設定マスタ（提供）クラス格納処理 Reader → RecBgnGrpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGrpWork</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnGrpWork CopyToRecBgnGrpOWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnGrpWork recBgnGrpWork = new RecBgnGrpWork();

            #region クラスへ格納
            recBgnGrpWork.CreateDateTime = DateTime.Now;
            recBgnGrpWork.UpdateDateTime = DateTime.Now;
            recBgnGrpWork.LogicalDeleteCode = 0;
            recBgnGrpWork.InqOriginalEpCd = "";
            recBgnGrpWork.InqOriginalSecCd = "";
            recBgnGrpWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnGrpWork.DisplayOrder = 0;
            recBgnGrpWork.BrgnGoodsGrpTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTITLERF"));
            recBgnGrpWork.BrgnGoodsGrpTag = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTAGRF"));
            recBgnGrpWork.BrgnGoodsGrpComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPCOMMENTRF"));
            #endregion

            return recBgnGrpWork;
        }

        #endregion

    }
}
