//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC自社設定マスタメンテ
// プログラム概要   : PCC自社設定マスタメンテDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子 
// 修 正 日  2013.02.12  修正内容 : SCM障害№10342,10343対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子 
// 修 正 日  2013/09/13  修正内容 : SCM仕掛一覧№10571対応 参照倉庫コード追加
//----------------------------------------------------------------------------//
// 管理番号  11070147-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/07/23  修正内容 : SCM仕掛一覧№10659の1現在庫数表示区分の追加     
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 修 正 日  2014/09/04  修正内容 : SCM仕掛一覧№10678対応　回答納期表示区分追加
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
    /// PCC自社設定マスタメンテリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC自社設定マスタメンテの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.04</br>
    /// <br></br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2014/07/23</br>
    /// <br>Update Note: Redmine#43080の1現在庫数表示区分の追加</br>
    /// </remarks>
    [Serializable]
    public class PccCmpnyStDB : RemoteDB, IPccCmpnyStDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public PccCmpnyStDB() : base("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork", "PCCCMPNYSTRF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

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
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region IPccCmpnyStDB メンバ

        /// <summary>
        /// PCC自社設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Write(ref object pccCmpnyStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);
                // write実行
                status = WriteProc(ref pccCmpnyStWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int WriteProc(ref object pccCmpnyStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;

            ArrayList pccCmpnyStWorkArrList = null;
            ArrayList pccCmpnyStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCmpnyStWorkList != null)
                {
                    pccCmpnyStWorkArrList = pccCmpnyStWorkList as ArrayList;

                }
                if (pccCmpnyStWorkArrList == null || pccCmpnyStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCmpnyStWorkArrListNew = new ArrayList();
                for (int i = 0; i < pccCmpnyStWorkArrList.Count; i++)
                {
                    PccCmpnyStWork pccCmpnyStWorkEach = pccCmpnyStWorkArrList[i] as PccCmpnyStWork;
                    status = this.WriteCmpnyStProcEach(ref pccCmpnyStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    pccCmpnyStWorkArrListNew.Add(pccCmpnyStWorkEach);
                }

                pccCmpnyStWorkList = pccCmpnyStWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCmpnyStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkEach">PCC自社設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteCmpnyStProcEach(ref PccCmpnyStWork pccCmpnyStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCMPNYSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            //Redmind #24310
            findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCmpnyStWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (pccCmpnyStWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //既存データで更新日時違いの場合には排他
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("     UPDATE PCCCMPNYSTRF SET CREATEDATETIMERF=@CREATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       UPDATEDATETIMERF=@UPDATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LOGICALDELETECODERF=@LOGICALDELETECODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALEPCDRF=@INQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALSECCDRF=@INQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHEREPCDRF=@INQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHERSECCDRF=@INQOTHERSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCCOMPANYCODERF=@PCCCOMPANYCODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCWAREHOUSECDRF=@PCCWAREHOUSECD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD1RF=@PCCPRIWAREHOUSECD1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD2RF=@PCCPRIWAREHOUSECD2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD3RF=@PCCPRIWAREHOUSECD3 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       GOODSNODSPDIVRF=@GOODSNODSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LISTPRCDSPDIVRF=@LISTPRCDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COSTDSPDIVRF=@COSTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SHELFDSPDIVRF=@SHELFDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COMMENTDSPDIVRF=@COMMENTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SPMTCNTDSPDIVRF=@SPMTCNTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       ACPTCNTDSPDIVRF=@ACPTCNTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELGDNODSPDIVRF=@PRTSELGDNODSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELLSPRDSPDIVRF=@PRTSELLSPRDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELSELFDSPDIVRF=@PRTSELSELFDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLNAME1RF=@PCCSUPLNAME1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLNAME2RF=@PCCSUPLNAME2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLKANARF=@PCCSUPLKANA ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLSNMRF=@PCCSUPLSNM ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLPOSTNORF=@PCCSUPLPOSTNO ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLADDR1RF=@PCCSUPLADDR1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLADDR2RF=@PCCSUPLADDR2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLADDR3RF=@PCCSUPLADDR3 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLTELNO1RF=@PCCSUPLTELNO1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLTELNO2RF=@PCCSUPLTELNO2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLFAXNORF=@PCCSUPLFAXNO ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSLIPPRTDIVRF=@PCCSLIPPRTDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STCKSTCOMMENT1RF=@STCKSTCOMMENT1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STCKSTCOMMENT2RF=@STCKSTCOMMENT2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STCKSTCOMMENT3RF=@STCKSTCOMMENT3 ").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                sqlTxt.Append(" ,       WAREHOUSEDSPDIVRF=@WAREHOUSEDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       CANCELDSPDIVRF=@CANCELDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       GOODSNODSPDIVODRF=@GOODSNODSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LISTPRCDSPDIVODRF=@LISTPRCDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COSTDSPDIVODRF=@COSTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SHELFDSPDIVODRF=@SHELFDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STOCKDSPDIVODRF=@STOCKDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COMMENTDSPDIVODRF=@COMMENTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SPMTCNTDSPDIVODRF=@SPMTCNTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       ACPTCNTDSPDIVODRF=@ACPTCNTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELGDNODSPDIVODRF=@PRTSELGDNODSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELLSPRDSPDIVODRF=@PRTSELLSPRDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELSELFDSPDIVODRF=@PRTSELSELFDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELSTCKDSPDIVODRF=@PRTSELSTCKDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       WAREHOUSEDSPDIVODRF=@WAREHOUSEDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       CANCELDSPDIVODRF=@CANCELDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQODRDSPDIVSETRF=@INQODRDSPDIVSET ").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD4RF=@PCCPRIWAREHOUSECD4 ").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                sqlTxt.Append(" ,       PRSNTSTKCTDSPDIVODRF=@PRSNTSTKCTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRSNTSTKCTDSPDIVRF=@PRSNTSTKCTDSPDIV ").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                sqlTxt.Append(" ,       ANSDELIDTDSPDIVRF=@ANSDELIDTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       ANSDELIDTDSPDIVODRF=@ANSDELIDTDSPDIVOD ").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();
                //KEYコマンドを再設定
                ////Redmind #24310
                findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);

                //コネクション文字列取得対応↓↓↓↓↓
                //更新ヘッダ情報を設定
                pccCmpnyStWorkEach.UpdateDateTime = DateTime.Now;

            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (pccCmpnyStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("     INSERT INTO PCCCMPNYSTRF").Append(Environment.NewLine);
                sqlTxt.Append("      (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCWAREHOUSECDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLKANARF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLSNMRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLPOSTNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLFAXNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT3RF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                sqlTxt.Append("     , WAREHOUSEDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STOCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSTCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , WAREHOUSEDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQODRDSPDIVSETRF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                sqlTxt.Append("     , PCCPRIWAREHOUSECD4RF").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                sqlTxt.Append("     , ANSDELIDTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ANSDELIDTDSPDIVODRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                sqlTxt.Append("    ) VALUES (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCWAREHOUSECD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD3").Append(Environment.NewLine);
                sqlTxt.Append("     , @GOODSNODSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @LISTPRCDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @COSTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @SHELFDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @COMMENTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @SPMTCNTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @ACPTCNTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELGDNODSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELLSPRDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELSELFDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLNAME1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLNAME2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLKANA").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLSNM").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLPOSTNO").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLADDR1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLADDR2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLADDR3").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLTELNO1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLTELNO2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLFAXNO").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSLIPPRTDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @STCKSTCOMMENT1").Append(Environment.NewLine);
                sqlTxt.Append("     , @STCKSTCOMMENT2").Append(Environment.NewLine);
                sqlTxt.Append("     , @STCKSTCOMMENT3").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                sqlTxt.Append("     , @WAREHOUSEDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @CANCELDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @GOODSNODSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @LISTPRCDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @COSTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @SHELFDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @STOCKDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @COMMENTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @SPMTCNTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @ACPTCNTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELGDNODSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELLSPRDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELSELFDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELSTCKDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @WAREHOUSEDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @CANCELDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQODRDSPDIVSET").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD4").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                sqlTxt.Append("     , @PRSNTSTKCTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRSNTSTKCTDSPDIV").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                sqlTxt.Append("     , @ANSDELIDTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @ANSDELIDTDSPDIVOD").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                sqlTxt.Append("     )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //登録ヘッダ情報を設定
                pccCmpnyStWorkEach.UpdateDateTime = DateTime.Now;
                pccCmpnyStWorkEach.CreateDateTime = DateTime.Now;
                pccCmpnyStWorkEach.LogicalDeleteCode = 0;
            }
            if (!myReader.IsClosed) myReader.Close();
            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraPccCompanyCode = sqlCommand.Parameters.Add("@PCCCOMPANYCODE", SqlDbType.Int);
            SqlParameter paraPccWarehouseCd = sqlCommand.Parameters.Add("@PCCWAREHOUSECD", SqlDbType.NChar);
            SqlParameter paraPccPriWarehouseCd1 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD1", SqlDbType.NChar);
            SqlParameter paraPccPriWarehouseCd2 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD2", SqlDbType.NChar);
            SqlParameter paraPccPriWarehouseCd3 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD3", SqlDbType.NChar);
            SqlParameter paraGoodsNoDspDiv = sqlCommand.Parameters.Add("@GOODSNODSPDIV", SqlDbType.Int);
            SqlParameter paraListPrcDspDiv = sqlCommand.Parameters.Add("@LISTPRCDSPDIV", SqlDbType.Int);
            SqlParameter paraCostDspDiv = sqlCommand.Parameters.Add("@COSTDSPDIV", SqlDbType.Int);
            SqlParameter paraShelfDspDiv = sqlCommand.Parameters.Add("@SHELFDSPDIV", SqlDbType.Int);
            SqlParameter paraCommentDspDiv = sqlCommand.Parameters.Add("@COMMENTDSPDIV", SqlDbType.Int);
            SqlParameter paraSpmtCntDspDiv = sqlCommand.Parameters.Add("@SPMTCNTDSPDIV", SqlDbType.Int);
            SqlParameter paraAcptCntDspDiv = sqlCommand.Parameters.Add("@ACPTCNTDSPDIV", SqlDbType.Int);
            SqlParameter paraPrtSelGdNoDspDiv = sqlCommand.Parameters.Add("@PRTSELGDNODSPDIV", SqlDbType.Int);
            SqlParameter paraPrtSelLsPrDspDiv = sqlCommand.Parameters.Add("@PRTSELLSPRDSPDIV", SqlDbType.Int);
            SqlParameter paraPrtSelSelfDspDiv = sqlCommand.Parameters.Add("@PRTSELSELFDSPDIV", SqlDbType.Int);
            SqlParameter paraPccSuplName1 = sqlCommand.Parameters.Add("@PCCSUPLNAME1", SqlDbType.NVarChar);
            SqlParameter paraPccSuplName2 = sqlCommand.Parameters.Add("@PCCSUPLNAME2", SqlDbType.NVarChar);
            SqlParameter paraPccSuplKana = sqlCommand.Parameters.Add("@PCCSUPLKANA", SqlDbType.NVarChar);
            SqlParameter paraPccSuplSnm = sqlCommand.Parameters.Add("@PCCSUPLSNM", SqlDbType.NVarChar);
            SqlParameter paraPccSuplPostNo = sqlCommand.Parameters.Add("@PCCSUPLPOSTNO", SqlDbType.NVarChar);
            SqlParameter paraPccSuplAddr1 = sqlCommand.Parameters.Add("@PCCSUPLADDR1", SqlDbType.NVarChar);
            SqlParameter paraPccSuplAddr2 = sqlCommand.Parameters.Add("@PCCSUPLADDR2", SqlDbType.NVarChar);
            SqlParameter paraPccSuplAddr3 = sqlCommand.Parameters.Add("@PCCSUPLADDR3", SqlDbType.NVarChar);
            SqlParameter paraPccSuplTelNo1 = sqlCommand.Parameters.Add("@PCCSUPLTELNO1", SqlDbType.NVarChar);
            SqlParameter paraPccSuplTelNo2 = sqlCommand.Parameters.Add("@PCCSUPLTELNO2", SqlDbType.NVarChar);
            SqlParameter paraPccSuplFaxNo = sqlCommand.Parameters.Add("@PCCSUPLFAXNO", SqlDbType.NVarChar);
            SqlParameter paraPccSlipPrtDiv = sqlCommand.Parameters.Add("@PCCSLIPPRTDIV", SqlDbType.Int);
            SqlParameter paraStckComment1 = sqlCommand.Parameters.Add("@STCKSTCOMMENT1", SqlDbType.NVarChar);
            SqlParameter paraStckComment2 = sqlCommand.Parameters.Add("@STCKSTCOMMENT2", SqlDbType.NVarChar);
            SqlParameter paraStckComment3 = sqlCommand.Parameters.Add("@STCKSTCOMMENT3", SqlDbType.NVarChar);
            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            SqlParameter paraWarehouseDspDiv = sqlCommand.Parameters.Add("@WAREHOUSEDSPDIV", SqlDbType.Int);
            SqlParameter paraCancelDspDiv = sqlCommand.Parameters.Add("@CANCELDSPDIV", SqlDbType.Int);
            SqlParameter paraGoodsNoDspDivOd = sqlCommand.Parameters.Add("@GOODSNODSPDIVOD", SqlDbType.Int);
            SqlParameter paraListPrcDspDivOd = sqlCommand.Parameters.Add("@LISTPRCDSPDIVOD", SqlDbType.Int);
            SqlParameter paraCostDspDivOd = sqlCommand.Parameters.Add("@COSTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraShelfDspDivOd = sqlCommand.Parameters.Add("@SHELFDSPDIVOD", SqlDbType.Int);
            SqlParameter paraStockDspDivOd = sqlCommand.Parameters.Add("@STOCKDSPDIVOD", SqlDbType.Int);
            SqlParameter paraCommentDspDivOd = sqlCommand.Parameters.Add("@COMMENTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraSpmtCntDspDivOd = sqlCommand.Parameters.Add("@SPMTCNTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraAcptCntDspDivOd = sqlCommand.Parameters.Add("@ACPTCNTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelGdNoDspDivOd = sqlCommand.Parameters.Add("@PRTSELGDNODSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelLsPrDspDivOd = sqlCommand.Parameters.Add("@PRTSELLSPRDSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelSelfDspDivOd = sqlCommand.Parameters.Add("@PRTSELSELFDSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelStckDspDivOd = sqlCommand.Parameters.Add("@PRTSELSTCKDSPDIVOD", SqlDbType.Int);
            SqlParameter paraWarehouseDspDivOd = sqlCommand.Parameters.Add("@WAREHOUSEDSPDIVOD", SqlDbType.Int);
            SqlParameter paraCancelDspDivOd = sqlCommand.Parameters.Add("@CANCELDSPDIVOD", SqlDbType.Int);
            SqlParameter paraInqOdrDspDivSet = sqlCommand.Parameters.Add("@INQODRDSPDIVSET", SqlDbType.Int);
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            SqlParameter paraPccPriWarehouseCd4 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD4", SqlDbType.NChar);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            SqlParameter paraPrsntStkCtDspDivOd = sqlCommand.Parameters.Add("@PRSNTSTKCTDSPDIVOD", SqlDbType.SmallInt);
            SqlParameter paraPrsntStkCtDspDiv = sqlCommand.Parameters.Add("@PRSNTSTKCTDSPDIV", SqlDbType.SmallInt);
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            SqlParameter paraAnsDeliDtDspDiv = sqlCommand.Parameters.Add("@ANSDELIDTDSPDIV", SqlDbType.SmallInt);
            SqlParameter paraAnsDeliDtDspDivOd = sqlCommand.Parameters.Add("@ANSDELIDTDSPDIVOD", SqlDbType.SmallInt);
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

            //Prameterオブジェクトの作成
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCmpnyStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCmpnyStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.LogicalDeleteCode);
            //Redmind #24310
            paraInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            paraInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PccCompanyCode);
            paraPccWarehouseCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccWarehouseCd);
            paraPccPriWarehouseCd1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd1);
            paraPccPriWarehouseCd2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd2);
            paraPccPriWarehouseCd3.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd3);
            paraGoodsNoDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.GoodsNoDspDiv);
            paraListPrcDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ListPrcDspDiv);
            paraCostDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CostDspDiv);
            paraShelfDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ShelfDspDiv);
            paraCommentDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CommentDspDiv);
            paraSpmtCntDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.SpmtCntDspDiv);
            paraAcptCntDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.AcptCntDspDiv);
            paraPrtSelGdNoDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelGdNoDspDiv);
            paraPrtSelLsPrDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelLsPrDspDiv);
            paraPrtSelSelfDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelSelfDspDiv);
            paraPccSuplName1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplName1);
            paraPccSuplName2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplName2);
            paraPccSuplKana.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplKana);
            paraPccSuplSnm.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplSnm);
            paraPccSuplPostNo.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplPostNo);
            paraPccSuplAddr1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplAddr1);
            paraPccSuplAddr2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplAddr2);
            paraPccSuplAddr3.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplAddr3);
            paraPccSuplTelNo1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplTelNo1);
            paraPccSuplTelNo2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplTelNo2);
            paraPccSuplFaxNo.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplFaxNo);
            paraPccSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PccSlipPrtDiv);
            paraStckComment1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.StckStComment1);
            paraStckComment2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.StckStComment2);
            paraStckComment3.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.StckStComment3);
            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            paraWarehouseDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.WarehouseDspDiv);
            paraCancelDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CancelDspDiv);
            paraGoodsNoDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.GoodsNoDspDivOd);
            paraListPrcDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ListPrcDspDivOd);
            paraCostDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CostDspDivOd);
            paraShelfDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ShelfDspDivOd);
            paraStockDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.StockDspDivOd);
            paraCommentDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CommentDspDivOd);
            paraSpmtCntDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.SpmtCntDspDivOd);
            paraAcptCntDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.AcptCntDspDivOd);
            paraPrtSelGdNoDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelGdNoDspDivOd);
            paraPrtSelLsPrDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelLsPrDspDivOd);
            paraPrtSelSelfDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelSelfDspDivOd);
            paraPrtSelStckDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelStckDspDivOd);
            paraWarehouseDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.WarehouseDspDivOd);
            paraCancelDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CancelDspDivOd);
            paraInqOdrDspDivSet.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.InqOdrDspDivSet);
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            paraPccPriWarehouseCd4.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd4);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            paraPrsntStkCtDspDivOd.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.PrsntStkCtDspDivOd);
            paraPrsntStkCtDspDiv.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.PrsntStkCtDspDiv);
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            paraAnsDeliDtDspDiv.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.AnsDeliDtDspDiv);
            paraAnsDeliDtDspDivOd.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.AnsDeliDtDspDivOd);
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="parsePccCmpnyStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Search(out object pccCmpnyStWorkList, PccCmpnyStWork parsePccCmpnyStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            pccCmpnyStWorkList = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out pccCmpnyStWorkList, parsePccCmpnyStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Search");
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
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="parsePccCmpnyStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int SearchProc(out object pccCmpnyStWorkList, PccCmpnyStWork parsePccCmpnyStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCmpnyStWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCWAREHOUSECDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLKANARF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLSNMRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLPOSTNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLFAXNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT3RF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                sqlTxt.Append("     , WAREHOUSEDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STOCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSTCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , WAREHOUSEDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQODRDSPDIVSETRF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                sqlTxt.Append("     , PCCPRIWAREHOUSECD4RF").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVRF").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                sqlTxt.Append("     , ANSDELIDTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ANSDELIDTDSPDIVODRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                sqlTxt.Append("      FROM PCCCMPNYSTRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd))
                {
                    sqlTxt.Append("    INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                    // Prameterオブジェクトの作成
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    // Parameterオブジェクトへ値設定
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOtherEpCd))
                {
                    if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalSecCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append( Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalSecCd) || !string.IsNullOrEmpty(parsePccCmpnyStWork.InqOtherEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append( Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOtherSecCd);
                }
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromSearch(myReader, out al);

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCmpnyStDB.SearchProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            pccCmpnyStWorkList = al;

            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Read(ref object pccCmpnyStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref pccCmpnyStWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Read");
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
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int ReadProc(ref object pccCmpnyStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            PccCmpnyStWork wkPccCmpnyStWorkOld = null;
            PccCmpnyStWork wkPccCmpnyStWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (pccCmpnyStWorkList != null)
            {
                wkPccCmpnyStWorkOld = pccCmpnyStWorkList as PccCmpnyStWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCmpnyStWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCWAREHOUSECDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLKANARF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLSNMRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLPOSTNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLFAXNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT3RF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                sqlTxt.Append("     , WAREHOUSEDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STOCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSTCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , WAREHOUSEDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQODRDSPDIVSETRF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                sqlTxt.Append("     , PCCPRIWAREHOUSECD4RF").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVRF").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                sqlTxt.Append("     , ANSDELIDTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ANSDELIDTDSPDIVODRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                sqlTxt.Append("      FROM PCCCMPNYSTRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);

                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlCommand.CommandText = sqlTxt.ToString();

                //Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                
                //KEYコマンドを再設定
                //Redmind #24310
                findParaInqOriginalEpCd.Value = wkPccCmpnyStWorkOld.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value =wkPccCmpnyStWorkOld.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(wkPccCmpnyStWorkOld.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(wkPccCmpnyStWorkOld.InqOtherSecCd);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromRead(myReader, ref wkPccCmpnyStWorkNew);
                if (wkPccCmpnyStWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCmpnyStDB.ReadProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            pccCmpnyStWorkList = wkPccCmpnyStWorkNew;

            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int LogicalDelete(ref object pccCmpnyStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);
                status = LogicalDeleteProc(ref pccCmpnyStWorkList, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object pccCmpnyStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccCmpnyStWorkArrList = null;
            ArrayList pccCmpnyStWorkArrListNew = null;
            try
            {
                if (pccCmpnyStWorkList != null)
                {
                    pccCmpnyStWorkArrList = pccCmpnyStWorkList as ArrayList;

                }
                if (pccCmpnyStWorkArrList == null || pccCmpnyStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCmpnyStWorkArrListNew = new ArrayList();
                for (int i = 0; i < pccCmpnyStWorkArrList.Count; i++)
                {
                    PccCmpnyStWork pccCmpnyStWorkEach = pccCmpnyStWorkArrList[i] as PccCmpnyStWork;
                    status = LogicalDeleteProcCmpnyEach(ref pccCmpnyStWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCmpnyStWorkArrListNew.Add(pccCmpnyStWorkEach);


                }
                pccCmpnyStWorkList = pccCmpnyStWorkArrListNew as object;

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkEach">PCC自社設定</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteProcCmpnyEach(ref PccCmpnyStWork pccCmpnyStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCMPNYSTRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);


            //Parameterオブジェクトへ値設定
            //Redmind #24310
            findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCmpnyStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCCMPNYSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                //Redmind #24310
                findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);

                //更新ヘッダ情報を設定
                //更新ヘッダ情報を設定
                pccCmpnyStWorkEach.UpdateDateTime = DateTime.Now;

            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //論理削除モードの場合
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCmpnyStWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) pccCmpnyStWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }

            //Parameterオブジェクトの作成(更新用)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(更新用)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCmpnyStWorkEach.UpdateDateTime);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Delete(ref object pccCmpnyStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = DeleteProc(ref pccCmpnyStWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int DeleteProc(ref object pccCmpnyStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCmpnyStWorkArrList = null;
            ArrayList pccCmpnyStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCmpnyStWorkList != null)
                {
                    pccCmpnyStWorkArrList = pccCmpnyStWorkList as ArrayList;

                }
                if (pccCmpnyStWorkArrList == null || pccCmpnyStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCmpnyStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCmpnyStWorkArrList.Count; i++)
                {
                    PccCmpnyStWork pccCmpnyStWorkEach = pccCmpnyStWorkArrList[i] as PccCmpnyStWork;
                    status = DeleteProcCmpnyStEach(ref pccCmpnyStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCmpnyStWorkArrListNew.Add(pccCmpnyStWorkEach);

                }

                pccCmpnyStWorkList = pccCmpnyStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpWorkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpWorkDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkEach">PCC自社設定グループ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private int DeleteProcCmpnyStEach(ref PccCmpnyStWork pccCmpnyStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCMPNYSTRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            //Redmind #24310
            findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCmpnyStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCMPNYSTRF ").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                //Redmind #24310
                findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccCmpnyStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);
                status = RevivalLogicalDeleteProc(ref pccCmpnyStWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.RevivalLogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object pccCmpnyStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteProc(ref  pccCmpnyStWorkList, 1, ref sqlConnection, ref  sqlTransaction);
        }


        #endregion

        #region 内部処理
        /// <summary>
        /// PCC自社設定データ取得処理
        /// </summary>
        /// <param name="myReader">PCC自社設定データReader</param>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>PCC自社設定データ</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyListFromSearch(SqlDataReader myReader, out ArrayList pccCmpnyStWorkList)
        {
            pccCmpnyStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //問合せ元企業コード
            int colIndex_InqOriginalEpCd = 0;
            //問合せ元拠点コード
            int colIndex_InqOriginalSecCd = 0;
            //問合せ先企業コード
            int colIndex_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndex_InqOtherSecCd = 0;
            //PCC自社コード
            int colIndex_PccCompanyCode = 0;
            //PCC倉庫コード
            int colIndex_PccWarehouseCd = 0;
            //PCC優先倉庫コード1
            int colIndex_PccPriWarehouseCd1 = 0;
            //PCC優先倉庫コード2
            int colIndex_PccPriWarehouseCd2 = 0;
            //PCC優先倉庫コード3
            int colIndex_PccPriWarehouseCd3 = 0;
            //品番表示区分
            int colIndex_GoodsNoDspDiv = 0;
            //標準価格表示区分
            int colIndex_ListPrcDspDiv = 0;
            //仕切価格表示区分
            int colIndex_CostDspDiv = 0;
            //棚番表示区分
            int colIndex_ShelfDspDiv = 0;
            //コメント表示区分
            int colIndex_CommentDspDiv = 0;
            //出荷数表示区分
            int colIndex_SpmtCntDspDiv = 0;
            //受注数表示区分
            int colIndex_AcptCntDspDiv = 0;
            //部品選択品番表示区分
            int colIndex_PrtSelGdNoDspDiv = 0;
            //部品選択標準価格表示区分
            int colIndex_PrtSelLsPrDspDiv = 0;
            //部品選択棚番表示区分
            int colIndex_PrtSelSelfDspDiv = 0;
            //PCC発注先名称1
            int colIndex_PccSuplName1 = 0;
            //PCC発注先名称2
            int colIndex_PccSuplName2 = 0;
            //PCC発注先カナ名称
            int colIndex_PccSuplKana = 0;
            //PCC発注先略称
            int colIndex_PccSuplSnm = 0;
            //PCC発注先郵便番号
            int colIndex_PccSuplPostNo = 0;
            //PCC発注先住所1
            int colIndex_PccSuplAddr1 = 0;
            //PCC発注先住所2
            int colIndex_PccSuplAddr2 = 0;
            //PCC発注先住所3
            int colIndex_PccSuplAddr3 = 0;
            //PCC発注先電話番号1
            int colIndex_PccSuplTelNo1 = 0;
            //PCC発注先電話番号2
            int colIndex_PccSuplTelNo2 = 0;
            //PCC発注先FAX番号
            int colIndex_PccSuplFaxNo = 0;
            //伝票発行区分（PCC）
            int colIndex_PccSlipPrtDiv = 0;
            //伝票発行区分（PCC）
            int colIndex_StckStComment1 = 0;
            //伝票発行区分（PCC）
            int colIndex_StckStComment2 = 0;
            //伝票発行区分（PCC）
            int colIndex_StckStComment3 = 0;
            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            //倉庫表示区分(問合せ)
            int colIndex_WarehouseDspDiv = 0;
            //取消表示区分(問合せ)
            int colIndex_CancelDspDiv = 0;
            //品番表示区分(発注)
            int colIndex_GoodsNoDspDivOd = 0;
            //標準価格表示区分(発注)
            int colIndex_ListPrcDspDivOd = 0;
            //仕切価格表示区分(発注)
            int colIndex_CostDspDivOd = 0;
            //棚番表示区分(発注)
            int colIndex_ShelfDspDivOd = 0;
            //在庫表示区分(発注)
            int colIndex_StockDspDivOd = 0;
            //コメント表示区分(発注)
            int colIndex_CommentDspDivOd = 0;
            //出荷数表示区分(発注)
            int colIndex_SpmtCntDspDivOd = 0;
            //受注数表示区分(発注)
            int colIndex_AcptCntDspDivOd = 0;
            //部品選択品番表示区分(発注)
            int colIndex_PrtSelGdNoDspDivOd = 0;
            //部品選択標準価格表示区分(発注)
            int colIndex_PrtSelLsPrDspDivOd = 0;
            //部品選択棚番表示区分(発注)
            int colIndex_PrtSelSelfDspDivOd = 0;
            //部品選択在庫表示区分(発注)
            int colIndex_PrtSelStckDspDivOd = 0;
            //倉庫表示区分(発注)
            int colIndex_WarehouseDspDivOd = 0;
            //取消表示区分(発注)
            int colIndex_CancelDspDivOd = 0;
            //問合せ発注表示区分設定
            int colIndex_InqOdrDspDivSet = 0;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            int colIndex_PccPriWarehouseCd4 = 0;
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            int colIndex_PrsntStkCtDspDivOd = 0;
            //現在庫数表示区分(問合せ)
            int colIndex_PrsntStkCtDspDiv = 0;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            int colIndex_AnsDeliDtDspDiv = 0;
            // 回答納期表示区分(発注)
            int colIndex_AnsDeliDtDspDivOd = 0;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            if (myReader.HasRows)
            {
                //作成日時	
                colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                //更新日時	
                colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                //論理削除区分	
                colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                //問合せ元企業コード	
                colIndex_InqOriginalEpCd = myReader.GetOrdinal("INQORIGINALEPCDRF");
                //問合せ元拠点コード	
                colIndex_InqOriginalSecCd = myReader.GetOrdinal("INQORIGINALSECCDRF");
                //問合せ先企業コード	
                colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                //問合せ先拠点コード	
                colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                //PCC自社コード	
                colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                //PCC倉庫コード	
                colIndex_PccWarehouseCd = myReader.GetOrdinal("PCCWAREHOUSECDRF");
                //PCC優先倉庫コード1	
                colIndex_PccPriWarehouseCd1 = myReader.GetOrdinal("PCCPRIWAREHOUSECD1RF");
                //PCC優先倉庫コード2	
                colIndex_PccPriWarehouseCd2 = myReader.GetOrdinal("PCCPRIWAREHOUSECD2RF");
                //PCC優先倉庫コード3	
                colIndex_PccPriWarehouseCd3 = myReader.GetOrdinal("PCCPRIWAREHOUSECD3RF");
                //品番表示区分	
                colIndex_GoodsNoDspDiv = myReader.GetOrdinal("GOODSNODSPDIVRF");
                //標準価格表示区分	
                colIndex_ListPrcDspDiv = myReader.GetOrdinal("LISTPRCDSPDIVRF");
                //仕切価格表示区分	
                colIndex_CostDspDiv = myReader.GetOrdinal("COSTDSPDIVRF");
                //棚番表示区分	
                colIndex_ShelfDspDiv = myReader.GetOrdinal("SHELFDSPDIVRF");
                //コメント表示区分	
                colIndex_CommentDspDiv = myReader.GetOrdinal("COMMENTDSPDIVRF");
                //出荷数表示区分	
                colIndex_SpmtCntDspDiv = myReader.GetOrdinal("SPMTCNTDSPDIVRF");
                //受注数表示区分	
                colIndex_AcptCntDspDiv = myReader.GetOrdinal("ACPTCNTDSPDIVRF");
                //部品選択品番表示区分	
                colIndex_PrtSelGdNoDspDiv = myReader.GetOrdinal("PRTSELGDNODSPDIVRF");
                //部品選択標準価格表示区分	
                colIndex_PrtSelLsPrDspDiv = myReader.GetOrdinal("PRTSELLSPRDSPDIVRF");
                //部品選択棚番表示区分	
                colIndex_PrtSelSelfDspDiv = myReader.GetOrdinal("PRTSELSELFDSPDIVRF");
                //PCC発注先名称1	
                colIndex_PccSuplName1 = myReader.GetOrdinal("PCCSUPLNAME1RF");
                //PCC発注先名称2	
                colIndex_PccSuplName2 = myReader.GetOrdinal("PCCSUPLNAME2RF");
                //PCC発注先カナ名称	
                colIndex_PccSuplKana = myReader.GetOrdinal("PCCSUPLKANARF");
                //PCC発注先略称	
                colIndex_PccSuplSnm = myReader.GetOrdinal("PCCSUPLSNMRF");
                //PCC発注先郵便番号	
                colIndex_PccSuplPostNo = myReader.GetOrdinal("PCCSUPLPOSTNORF");
                //PCC発注先住所1	
                colIndex_PccSuplAddr1 = myReader.GetOrdinal("PCCSUPLADDR1RF");
                //PCC発注先住所2	
                colIndex_PccSuplAddr2 = myReader.GetOrdinal("PCCSUPLADDR2RF");
                //PCC発注先住所3	
                colIndex_PccSuplAddr3 = myReader.GetOrdinal("PCCSUPLADDR3RF");
                //PCC発注先電話番号1	
                colIndex_PccSuplTelNo1 = myReader.GetOrdinal("PCCSUPLTELNO1RF");
                //PCC発注先電話番号2	
                colIndex_PccSuplTelNo2 = myReader.GetOrdinal("PCCSUPLTELNO2RF");
                //PCC発注先FAX番号	
                colIndex_PccSuplFaxNo = myReader.GetOrdinal("PCCSUPLFAXNORF");
                //伝票発行区分（PCC）	
                colIndex_PccSlipPrtDiv = myReader.GetOrdinal("PCCSLIPPRTDIVRF");
                //在庫状況コメント1	
                colIndex_StckStComment1 = myReader.GetOrdinal("STCKSTCOMMENT1RF");
                //在庫状況コメント12	
                colIndex_StckStComment2 = myReader.GetOrdinal("STCKSTCOMMENT2RF");
                //在庫状況コメント3
                colIndex_StckStComment3 = myReader.GetOrdinal("STCKSTCOMMENT3RF");
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                //倉庫表示区分(問合せ)
                colIndex_WarehouseDspDiv = myReader.GetOrdinal("WAREHOUSEDSPDIVRF");
                //取消表示区分(問合せ)
                colIndex_CancelDspDiv = myReader.GetOrdinal("CANCELDSPDIVRF");
                //品番表示区分(発注)
                colIndex_GoodsNoDspDivOd = myReader.GetOrdinal("GOODSNODSPDIVODRF");
                //標準価格表示区分(発注)
                colIndex_ListPrcDspDivOd = myReader.GetOrdinal("LISTPRCDSPDIVODRF");
                //仕切価格表示区分(発注)
                colIndex_CostDspDivOd = myReader.GetOrdinal("COSTDSPDIVODRF");
                //棚番表示区分(発注)
                colIndex_ShelfDspDivOd = myReader.GetOrdinal("SHELFDSPDIVODRF");
                //在庫表示区分(発注)
                colIndex_StockDspDivOd = myReader.GetOrdinal("STOCKDSPDIVODRF");
                //コメント表示区分(発注)
                colIndex_CommentDspDivOd = myReader.GetOrdinal("COMMENTDSPDIVODRF");
                //出荷数表示区分(発注)
                colIndex_SpmtCntDspDivOd = myReader.GetOrdinal("SPMTCNTDSPDIVODRF");
                //受注数表示区分(発注)
                colIndex_AcptCntDspDivOd = myReader.GetOrdinal("ACPTCNTDSPDIVODRF");
                //部品選択品番表示区分(発注)
                colIndex_PrtSelGdNoDspDivOd = myReader.GetOrdinal("PRTSELGDNODSPDIVODRF");
                //部品選択標準価格表示区分(発注)
                colIndex_PrtSelLsPrDspDivOd = myReader.GetOrdinal("PRTSELLSPRDSPDIVODRF");
                //部品選択棚番表示区分(発注)
                colIndex_PrtSelSelfDspDivOd = myReader.GetOrdinal("PRTSELSELFDSPDIVODRF");
                //部品選択在庫表示区分(発注)
                colIndex_PrtSelStckDspDivOd = myReader.GetOrdinal("PRTSELSTCKDSPDIVODRF");
                //倉庫表示区分(発注)
                colIndex_WarehouseDspDivOd = myReader.GetOrdinal("WAREHOUSEDSPDIVODRF");
                //取消表示区分(発注)
                colIndex_CancelDspDivOd = myReader.GetOrdinal("CANCELDSPDIVODRF");
                //問合せ発注表示区分設定
                colIndex_InqOdrDspDivSet = myReader.GetOrdinal("INQODRDSPDIVSETRF");
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                //PCC優先倉庫コード4	
                colIndex_PccPriWarehouseCd4 = myReader.GetOrdinal("PCCPRIWAREHOUSECD4RF");
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                //現在庫数表示区分(発注)
                colIndex_PrsntStkCtDspDivOd = myReader.GetOrdinal("PRSNTSTKCTDSPDIVODRF");
                //現在庫数表示区分(問合せ)
                colIndex_PrsntStkCtDspDiv = myReader.GetOrdinal("PRSNTSTKCTDSPDIVRF");
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                // 回答納期表示区分(問合せ)
                colIndex_AnsDeliDtDspDiv = myReader.GetOrdinal("ANSDELIDTDSPDIVRF");
                // 回答納期表示区分(発注)
                colIndex_AnsDeliDtDspDivOd = myReader.GetOrdinal("ANSDELIDTDSPDIVODRF");
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            }
            while (myReader.Read())
            {

                PccCmpnyStWork pccCmpnyStWork = new PccCmpnyStWork();
                //作成日時	 
                pccCmpnyStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //更新日時	            
                pccCmpnyStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //論理削除区分	            
                pccCmpnyStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //問合せ元企業コード	            
                pccCmpnyStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //問合せ元拠点コード	            
                pccCmpnyStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //問合せ先企業コード	            
                pccCmpnyStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //問合せ先拠点コード	            
                pccCmpnyStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //PCC自社コード	            
                pccCmpnyStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                //PCC倉庫コード	            
                pccCmpnyStWork.PccWarehouseCd = SqlDataMediator.SqlGetString(myReader, colIndex_PccWarehouseCd);
                //PCC優先倉庫コード1	            
                pccCmpnyStWork.PccPriWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd1);
                //PCC優先倉庫コード2	            
                pccCmpnyStWork.PccPriWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd2);
                //PCC優先倉庫コード3	            
                pccCmpnyStWork.PccPriWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd3);
                //品番表示区分	            
                pccCmpnyStWork.GoodsNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDiv);
                //標準価格表示区分	            
                pccCmpnyStWork.ListPrcDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDiv);
                //仕切価格表示区分	            
                pccCmpnyStWork.CostDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDiv);
                //棚番表示区分	            
                pccCmpnyStWork.ShelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDiv);
                //コメント表示区分	            
                pccCmpnyStWork.CommentDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDiv);
                //出荷数表示区分	            
                pccCmpnyStWork.SpmtCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDiv);
                //受注数表示区分	            
                pccCmpnyStWork.AcptCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDiv);
                //部品選択品番表示区分	            
                pccCmpnyStWork.PrtSelGdNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDiv);
                //部品選択標準価格表示区分	            
                pccCmpnyStWork.PrtSelLsPrDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDiv);
                //部品選択棚番表示区分	            
                pccCmpnyStWork.PrtSelSelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDiv);
                //PCC発注先名称1	            
                pccCmpnyStWork.PccSuplName1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName1);
                //PCC発注先名称2	            
                pccCmpnyStWork.PccSuplName2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName2);
                //PCC発注先カナ名称	            
                pccCmpnyStWork.PccSuplKana = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplKana);
                //PCC発注先略称	            
                pccCmpnyStWork.PccSuplSnm = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplSnm);
                //PCC発注先郵便番号	            
                pccCmpnyStWork.PccSuplPostNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplPostNo);
                //PCC発注先住所1	            
                pccCmpnyStWork.PccSuplAddr1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr1);
                //PCC発注先住所2	            
                pccCmpnyStWork.PccSuplAddr2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr2);
                //PCC発注先住所3	            
                pccCmpnyStWork.PccSuplAddr3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr3);
                //PCC発注先電話番号1	            
                pccCmpnyStWork.PccSuplTelNo1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo1);
                //PCC発注先電話番号2	            
                pccCmpnyStWork.PccSuplTelNo2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo2);
                //PCC発注先FAX番号	            
                pccCmpnyStWork.PccSuplFaxNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplFaxNo);
                //伝票発行区分（PCC）	            
                pccCmpnyStWork.PccSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccSlipPrtDiv);
                //伝票発行区分（PCC）	            
                pccCmpnyStWork.StckStComment1 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment1);
                //伝票発行区分（PCC）	            
                pccCmpnyStWork.StckStComment2 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment2);
                //伝票発行区分（PCC）	            
                pccCmpnyStWork.StckStComment3 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment3);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                //倉庫表示区分(問合せ)
                pccCmpnyStWork.WarehouseDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDiv);
                //取消表示区分(問合せ)
                pccCmpnyStWork.CancelDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDiv);
                //品番表示区分(発注)
                pccCmpnyStWork.GoodsNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDivOd);
                //標準価格表示区分(発注)
                pccCmpnyStWork.ListPrcDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDivOd);
                //仕切価格表示区分(発注)
                pccCmpnyStWork.CostDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDivOd);
                //棚番表示区分(発注)
                pccCmpnyStWork.ShelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDivOd);
                //在庫表示区分(発注)
                pccCmpnyStWork.StockDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_StockDspDivOd);
                //コメント表示区分(発注)
                pccCmpnyStWork.CommentDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDivOd);
                //出荷数表示区分(発注)
                pccCmpnyStWork.SpmtCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDivOd);
                //受注数表示区分(発注)
                pccCmpnyStWork.AcptCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDivOd);
                //部品選択品番表示区分(発注)
                pccCmpnyStWork.PrtSelGdNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDivOd);
                //部品選択標準価格表示区分(発注)
                pccCmpnyStWork.PrtSelLsPrDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDivOd);
                //部品選択棚番表示区分(発注)
                pccCmpnyStWork.PrtSelSelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDivOd);
                //部品選択在庫表示区分(発注)
                pccCmpnyStWork.PrtSelStckDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelStckDspDivOd);
                //倉庫表示区分(発注)
                pccCmpnyStWork.WarehouseDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDivOd);
                //取消表示区分(発注)
                pccCmpnyStWork.CancelDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDivOd);
                //問合せ発注表示区分設定
                pccCmpnyStWork.InqOdrDspDivSet = SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOdrDspDivSet);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                //PCC優先倉庫コード4	            
                pccCmpnyStWork.PccPriWarehouseCd4 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd4);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                //現在庫数表示区分(発注)
                pccCmpnyStWork.PrsntStkCtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDivOd);
                //現在庫数表示区分(問合せ)
                pccCmpnyStWork.PrsntStkCtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDiv);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                pccCmpnyStWorkList.Add(pccCmpnyStWork);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                // 回答納期表示区分(問合せ)
                pccCmpnyStWork.AnsDeliDtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDiv);
                // 回答納期表示区分(発注)
                pccCmpnyStWork.AnsDeliDtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDivOd);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// PCC自社設定データ取得処理
        /// </summary>
        /// <param name="myReader">PCC自社設定データReader</param>
        /// <param name="pccCmpnyStWork">PCC自社設定データ</param>
        /// <returns>PCC自社設定データ</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyListFromRead(SqlDataReader myReader, ref PccCmpnyStWork pccCmpnyStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //問合せ元企業コード
            int colIndex_InqOriginalEpCd = 0;
            //問合せ元拠点コード
            int colIndex_InqOriginalSecCd = 0;
            //問合せ先企業コード
            int colIndex_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndex_InqOtherSecCd = 0;
            //PCC自社コード
            int colIndex_PccCompanyCode = 0;
            //PCC倉庫コード
            int colIndex_PccWarehouseCd = 0;
            //PCC優先倉庫コード1
            int colIndex_PccPriWarehouseCd1 = 0;
            //PCC優先倉庫コード2
            int colIndex_PccPriWarehouseCd2 = 0;
            //PCC優先倉庫コード3
            int colIndex_PccPriWarehouseCd3 = 0;
            //品番表示区分
            int colIndex_GoodsNoDspDiv = 0;
            //標準価格表示区分
            int colIndex_ListPrcDspDiv = 0;
            //仕切価格表示区分
            int colIndex_CostDspDiv = 0;
            //棚番表示区分
            int colIndex_ShelfDspDiv = 0;
            //コメント表示区分
            int colIndex_CommentDspDiv = 0;
            //出荷数表示区分
            int colIndex_SpmtCntDspDiv = 0;
            //受注数表示区分
            int colIndex_AcptCntDspDiv = 0;
            //部品選択品番表示区分
            int colIndex_PrtSelGdNoDspDiv = 0;
            //部品選択標準価格表示区分
            int colIndex_PrtSelLsPrDspDiv = 0;
            //部品選択棚番表示区分
            int colIndex_PrtSelSelfDspDiv = 0;
            //PCC発注先名称1
            int colIndex_PccSuplName1 = 0;
            //PCC発注先名称2
            int colIndex_PccSuplName2 = 0;
            //PCC発注先カナ名称
            int colIndex_PccSuplKana = 0;
            //PCC発注先略称
            int colIndex_PccSuplSnm = 0;
            //PCC発注先郵便番号
            int colIndex_PccSuplPostNo = 0;
            //PCC発注先住所1
            int colIndex_PccSuplAddr1 = 0;
            //PCC発注先住所2
            int colIndex_PccSuplAddr2 = 0;
            //PCC発注先住所3
            int colIndex_PccSuplAddr3 = 0;
            //PCC発注先電話番号1
            int colIndex_PccSuplTelNo1 = 0;
            //PCC発注先電話番号2
            int colIndex_PccSuplTelNo2 = 0;
            //PCC発注先FAX番号
            int colIndex_PccSuplFaxNo = 0;
            //伝票発行区分（PCC）
            int colIndex_PccSlipPrtDiv = 0;
            //伝票発行区分（PCC）
            int colIndex_StckStComment1 = 0;
            //伝票発行区分（PCC）
            int colIndex_StckStComment2 = 0;
            //伝票発行区分（PCC）
            int colIndex_StckStComment3 = 0;
            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            //倉庫表示区分(問合せ)
            int colIndex_WarehouseDspDiv = 0;
            //取消表示区分(問合せ)
            int colIndex_CancelDspDiv = 0;
            //品番表示区分(発注)
            int colIndex_GoodsNoDspDivOd = 0;
            //標準価格表示区分(発注)
            int colIndex_ListPrcDspDivOd = 0;
            //仕切価格表示区分(発注)
            int colIndex_CostDspDivOd = 0;
            //棚番表示区分(発注)
            int colIndex_ShelfDspDivOd = 0;
            //在庫表示区分(発注)
            int colIndex_StockDspDivOd = 0;
            //コメント表示区分(発注)
            int colIndex_CommentDspDivOd = 0;
            //出荷数表示区分(発注)
            int colIndex_SpmtCntDspDivOd = 0;
            //受注数表示区分(発注)
            int colIndex_AcptCntDspDivOd = 0;
            //部品選択品番表示区分(発注)
            int colIndex_PrtSelGdNoDspDivOd = 0;
            //部品選択標準価格表示区分(発注)
            int colIndex_PrtSelLsPrDspDivOd = 0;
            //部品選択棚番表示区分(発注)
            int colIndex_PrtSelSelfDspDivOd = 0;
            //部品選択在庫表示区分(発注)
            int colIndex_PrtSelStckDspDivOd = 0;
            //倉庫表示区分(発注)
            int colIndex_WarehouseDspDivOd = 0;
            //取消表示区分(発注)
            int colIndex_CancelDspDivOd = 0;
            //問合せ発注表示区分設定
            int colIndex_InqOdrDspDivSet = 0;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            int colIndex_PccPriWarehouseCd4 = 0;
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            int colIndex_PrsntStkCtDspDivOd = 0;
            //現在庫数表示区分(問合せ)
            int colIndex_PrsntStkCtDspDiv = 0;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            int colIndex_AnsDeliDtDspDiv = 0;
            // 回答納期表示区分(発注)
            int colIndex_AnsDeliDtDspDivOd = 0;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            if (myReader.HasRows)
            {
                pccCmpnyStWork = new PccCmpnyStWork();
                //作成日時	
                colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                //更新日時	
                colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                //論理削除区分	
                colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                //問合せ元企業コード	
                colIndex_InqOriginalEpCd = myReader.GetOrdinal("INQORIGINALEPCDRF");
                //問合せ元拠点コード	
                colIndex_InqOriginalSecCd = myReader.GetOrdinal("INQORIGINALSECCDRF");
                //問合せ先企業コード	
                colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                //問合せ先拠点コード	
                colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                //PCC自社コード	
                colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                //PCC倉庫コード	
                colIndex_PccWarehouseCd = myReader.GetOrdinal("PCCWAREHOUSECDRF");
                //PCC優先倉庫コード1	
                colIndex_PccPriWarehouseCd1 = myReader.GetOrdinal("PCCPRIWAREHOUSECD1RF");
                //PCC優先倉庫コード2	
                colIndex_PccPriWarehouseCd2 = myReader.GetOrdinal("PCCPRIWAREHOUSECD2RF");
                //PCC優先倉庫コード3	
                colIndex_PccPriWarehouseCd3 = myReader.GetOrdinal("PCCPRIWAREHOUSECD3RF");
                //品番表示区分	
                colIndex_GoodsNoDspDiv = myReader.GetOrdinal("GOODSNODSPDIVRF");
                //標準価格表示区分	
                colIndex_ListPrcDspDiv = myReader.GetOrdinal("LISTPRCDSPDIVRF");
                //仕切価格表示区分	
                colIndex_CostDspDiv = myReader.GetOrdinal("COSTDSPDIVRF");
                //棚番表示区分	
                colIndex_ShelfDspDiv = myReader.GetOrdinal("SHELFDSPDIVRF");
                //コメント表示区分	
                colIndex_CommentDspDiv = myReader.GetOrdinal("COMMENTDSPDIVRF");
                //出荷数表示区分	
                colIndex_SpmtCntDspDiv = myReader.GetOrdinal("SPMTCNTDSPDIVRF");
                //受注数表示区分	
                colIndex_AcptCntDspDiv = myReader.GetOrdinal("ACPTCNTDSPDIVRF");
                //部品選択品番表示区分	
                colIndex_PrtSelGdNoDspDiv = myReader.GetOrdinal("PRTSELGDNODSPDIVRF");
                //部品選択標準価格表示区分	
                colIndex_PrtSelLsPrDspDiv = myReader.GetOrdinal("PRTSELLSPRDSPDIVRF");
                //部品選択棚番表示区分	
                colIndex_PrtSelSelfDspDiv = myReader.GetOrdinal("PRTSELSELFDSPDIVRF");
                //PCC発注先名称1	
                colIndex_PccSuplName1 = myReader.GetOrdinal("PCCSUPLNAME1RF");
                //PCC発注先名称2	
                colIndex_PccSuplName2 = myReader.GetOrdinal("PCCSUPLNAME2RF");
                //PCC発注先カナ名称	
                colIndex_PccSuplKana = myReader.GetOrdinal("PCCSUPLKANARF");
                //PCC発注先略称	
                colIndex_PccSuplSnm = myReader.GetOrdinal("PCCSUPLSNMRF");
                //PCC発注先郵便番号	
                colIndex_PccSuplPostNo = myReader.GetOrdinal("PCCSUPLPOSTNORF");
                //PCC発注先住所1	
                colIndex_PccSuplAddr1 = myReader.GetOrdinal("PCCSUPLADDR1RF");
                //PCC発注先住所2	
                colIndex_PccSuplAddr2 = myReader.GetOrdinal("PCCSUPLADDR2RF");
                //PCC発注先住所3	
                colIndex_PccSuplAddr3 = myReader.GetOrdinal("PCCSUPLADDR3RF");
                //PCC発注先電話番号1	
                colIndex_PccSuplTelNo1 = myReader.GetOrdinal("PCCSUPLTELNO1RF");
                //PCC発注先電話番号2	
                colIndex_PccSuplTelNo2 = myReader.GetOrdinal("PCCSUPLTELNO2RF");
                //PCC発注先FAX番号	
                colIndex_PccSuplFaxNo = myReader.GetOrdinal("PCCSUPLFAXNORF");
                //伝票発行区分（PCC）	
                colIndex_PccSlipPrtDiv = myReader.GetOrdinal("PCCSLIPPRTDIVRF");
                //伝票発行区分（PCC）	
                colIndex_StckStComment1 = myReader.GetOrdinal("STCKSTCOMMENT1RF");
                //伝票発行区分（PCC）	
                colIndex_StckStComment2 = myReader.GetOrdinal("STCKSTCOMMENT2RF");
                //伝票発行区分（PCC）	
                colIndex_StckStComment3 = myReader.GetOrdinal("STCKSTCOMMENT3RF");
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                //倉庫表示区分(問合せ)
                colIndex_WarehouseDspDiv = myReader.GetOrdinal("WAREHOUSEDSPDIVRF");
                //取消表示区分(問合せ)
                colIndex_CancelDspDiv = myReader.GetOrdinal("CANCELDSPDIVRF");
                //品番表示区分(発注)
                colIndex_GoodsNoDspDivOd = myReader.GetOrdinal("GOODSNODSPDIVODRF");
                //標準価格表示区分(発注)
                colIndex_ListPrcDspDivOd = myReader.GetOrdinal("LISTPRCDSPDIVODRF");
                //仕切価格表示区分(発注)
                colIndex_CostDspDivOd = myReader.GetOrdinal("COSTDSPDIVODRF");
                //棚番表示区分(発注)
                colIndex_ShelfDspDivOd = myReader.GetOrdinal("SHELFDSPDIVODRF");
                //在庫表示区分(発注)
                colIndex_StockDspDivOd = myReader.GetOrdinal("STOCKDSPDIVODRF");
                //コメント表示区分(発注)
                colIndex_CommentDspDivOd = myReader.GetOrdinal("COMMENTDSPDIVODRF");
                //出荷数表示区分(発注)
                colIndex_SpmtCntDspDivOd = myReader.GetOrdinal("SPMTCNTDSPDIVODRF");
                //受注数表示区分(発注)
                colIndex_AcptCntDspDivOd = myReader.GetOrdinal("ACPTCNTDSPDIVODRF");
                //部品選択品番表示区分(発注)
                colIndex_PrtSelGdNoDspDivOd = myReader.GetOrdinal("PRTSELGDNODSPDIVODRF");
                //部品選択標準価格表示区分(発注)
                colIndex_PrtSelLsPrDspDivOd = myReader.GetOrdinal("PRTSELLSPRDSPDIVODRF");
                //部品選択棚番表示区分(発注)
                colIndex_PrtSelSelfDspDivOd = myReader.GetOrdinal("PRTSELSELFDSPDIVODRF");
                //部品選択在庫表示区分(発注)
                colIndex_PrtSelStckDspDivOd = myReader.GetOrdinal("PRTSELSTCKDSPDIVODRF");
                //倉庫表示区分(発注)
                colIndex_WarehouseDspDivOd = myReader.GetOrdinal("WAREHOUSEDSPDIVODRF");
                //取消表示区分(発注)
                colIndex_CancelDspDivOd = myReader.GetOrdinal("CANCELDSPDIVODRF");
                //問合せ発注表示区分設定
                colIndex_InqOdrDspDivSet = myReader.GetOrdinal("INQODRDSPDIVSETRF");
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                //PCC優先倉庫コード4	
                colIndex_PccPriWarehouseCd4 = myReader.GetOrdinal("PCCPRIWAREHOUSECD4RF");
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                //現在庫数表示区分(発注)
                colIndex_PrsntStkCtDspDivOd = myReader.GetOrdinal("PRSNTSTKCTDSPDIVODRF");
                //現在庫数表示区分(問合せ)
                colIndex_PrsntStkCtDspDiv = myReader.GetOrdinal("PRSNTSTKCTDSPDIVRF");
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                // 回答納期表示区分(問合せ)
                colIndex_AnsDeliDtDspDiv = myReader.GetOrdinal("ANSDELIDTDSPDIVRF");
                // 回答納期表示区分(発注)
                colIndex_AnsDeliDtDspDivOd = myReader.GetOrdinal("ANSDELIDTDSPDIVODRF");
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

            }
            if(myReader.Read())
            {

                //作成日時	 
                pccCmpnyStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //更新日時	            
                pccCmpnyStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //論理削除区分	            
                pccCmpnyStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //問合せ元企業コード	            
                pccCmpnyStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //問合せ元拠点コード	            
                pccCmpnyStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //問合せ先企業コード	            
                pccCmpnyStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //問合せ先拠点コード	            
                pccCmpnyStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //PCC自社コード	            
                pccCmpnyStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                //PCC倉庫コード	            
                pccCmpnyStWork.PccWarehouseCd = SqlDataMediator.SqlGetString(myReader, colIndex_PccWarehouseCd);
                //PCC優先倉庫コード1	            
                pccCmpnyStWork.PccPriWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd1);
                //PCC優先倉庫コード2	            
                pccCmpnyStWork.PccPriWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd2);
                //PCC優先倉庫コード3	            
                pccCmpnyStWork.PccPriWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd3);
                //品番表示区分	            
                pccCmpnyStWork.GoodsNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDiv);
                //標準価格表示区分	            
                pccCmpnyStWork.ListPrcDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDiv);
                //仕切価格表示区分	            
                pccCmpnyStWork.CostDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDiv);
                //棚番表示区分	            
                pccCmpnyStWork.ShelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDiv);
                //コメント表示区分	            
                pccCmpnyStWork.CommentDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDiv);
                //出荷数表示区分	            
                pccCmpnyStWork.SpmtCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDiv);
                //受注数表示区分	            
                pccCmpnyStWork.AcptCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDiv);
                //部品選択品番表示区分	            
                pccCmpnyStWork.PrtSelGdNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDiv);
                //部品選択標準価格表示区分	            
                pccCmpnyStWork.PrtSelLsPrDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDiv);
                //部品選択棚番表示区分	            
                pccCmpnyStWork.PrtSelSelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDiv);
                //PCC発注先名称1	            
                pccCmpnyStWork.PccSuplName1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName1);
                //PCC発注先名称2	            
                pccCmpnyStWork.PccSuplName2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName2);
                //PCC発注先カナ名称	            
                pccCmpnyStWork.PccSuplKana = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplKana);
                //PCC発注先略称	            
                pccCmpnyStWork.PccSuplSnm = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplSnm);
                //PCC発注先郵便番号	            
                pccCmpnyStWork.PccSuplPostNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplPostNo);
                //PCC発注先住所1	            
                pccCmpnyStWork.PccSuplAddr1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr1);
                //PCC発注先住所2	            
                pccCmpnyStWork.PccSuplAddr2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr2);
                //PCC発注先住所3	            
                pccCmpnyStWork.PccSuplAddr3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr3);
                //PCC発注先電話番号1	            
                pccCmpnyStWork.PccSuplTelNo1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo1);
                //PCC発注先電話番号2	            
                pccCmpnyStWork.PccSuplTelNo2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo2);
                //PCC発注先FAX番号	            
                pccCmpnyStWork.PccSuplFaxNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplFaxNo);
                //伝票発行区分（PCC）	            
                pccCmpnyStWork.PccSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccSlipPrtDiv);
                //在庫状況コメント1            
                pccCmpnyStWork.StckStComment1 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment1);
                //在庫状況コメント2            
                pccCmpnyStWork.StckStComment2 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment2);
                //在庫状況コメント3	            
                pccCmpnyStWork.StckStComment3 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment3);
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                //倉庫表示区分(問合せ)
                pccCmpnyStWork.WarehouseDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDiv);
                //取消表示区分(問合せ)
                pccCmpnyStWork.CancelDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDiv);
                //品番表示区分(発注)
                pccCmpnyStWork.GoodsNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDivOd);
                //標準価格表示区分(発注)
                pccCmpnyStWork.ListPrcDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDivOd);
                //仕切価格表示区分(発注)
                pccCmpnyStWork.CostDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDivOd);
                //棚番表示区分(発注)
                pccCmpnyStWork.ShelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDivOd);
                //在庫表示区分(発注)
                pccCmpnyStWork.StockDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_StockDspDivOd);
                //コメント表示区分(発注)
                pccCmpnyStWork.CommentDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDivOd);
                //出荷数表示区分(発注)
                pccCmpnyStWork.SpmtCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDivOd);
                //受注数表示区分(発注)
                pccCmpnyStWork.AcptCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDivOd);
                //部品選択品番表示区分(発注)
                pccCmpnyStWork.PrtSelGdNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDivOd);
                //部品選択標準価格表示区分(発注)
                pccCmpnyStWork.PrtSelLsPrDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDivOd);
                //部品選択棚番表示区分(発注)
                pccCmpnyStWork.PrtSelSelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDivOd);
                //部品選択在庫表示区分(発注)
                pccCmpnyStWork.PrtSelStckDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelStckDspDivOd);
                //倉庫表示区分(発注)
                pccCmpnyStWork.WarehouseDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDivOd);
                //取消表示区分(発注)
                pccCmpnyStWork.CancelDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDivOd);
                //問合せ発注表示区分設定
                pccCmpnyStWork.InqOdrDspDivSet = SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOdrDspDivSet);
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                //PCC優先倉庫コード4	            
                pccCmpnyStWork.PccPriWarehouseCd4 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd4);
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                //現在庫数表示区分(発注)
                pccCmpnyStWork.PrsntStkCtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDivOd);
                //現在庫数表示区分(問合せ)
                pccCmpnyStWork.PrsntStkCtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDiv);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分のSqlGetShort -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                // 回答納期表示区分(問合せ)
                pccCmpnyStWork.AnsDeliDtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDiv);
                // 回答納期表示区分(発注)
                pccCmpnyStWork.AnsDeliDtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDivOd);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }


        #endregion

    }
}
