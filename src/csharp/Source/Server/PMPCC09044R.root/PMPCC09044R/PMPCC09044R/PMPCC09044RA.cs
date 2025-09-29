//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC品目グループマスタメンテ
// プログラム概要   : PCC品目グループマスタメンテDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.07.20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/05/30  修正内容 : 2013/99/99配信 SCM障害№10541対応 
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
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC品目グループマスタメンテリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC品目グループマスタメンテの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccItemGrpDB : RemoteDB, IPccItemGrpDB
    {
        #region [Const]
        private const string SOFTWARESTR = "SOFTWARE";
        private const string USER_AP_PATH = "Broadleaf\\Product\\Partsman\\SCM_NS_AP";
        private const string DataBaseMess = ";DataBase=SCM_DB;uid=sa;pwd=bl.sun.japan";
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public PccItemGrpDB() : base("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork", "PCCITEMGRPRF")
        {
        }

        #region [コネクション生成処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
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
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //トランザクション生成処理

        #region IPccItemGrpDB メンバ

        /// <summary>
        /// PCC品目グループマスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Write(ref object pccItemGrpWorkList, ref object pccItemStWorkList)
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
                status = WriteGrpProc(ref pccItemGrpWorkList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (pccItemStWorkList != null)
                    {
                        // write実行
                        status = WriteStProc(ref pccItemStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Write");
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
        /// PCC品目グループマスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteGrpProc(ref object pccItemGrpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;

                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemGrpWorkArrList.Count; i++ )
                {
                    PccItemGrpWork pccItemGrpWorkEach = pccItemGrpWorkArrList[i] as PccItemGrpWork;
                    if (pccItemGrpWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcGrpEach(ref pccItemGrpWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = this.WriteGrpProcEach(ref pccItemGrpWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccItemGrpWorkArrListNew.Add(pccItemGrpWorkEach);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    
                }

                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
               
           }
           catch (SqlException ex)
           {
               status = base.WriteSQLErrorLog(ex, "PccItemGrpWork.Write", status);
           }
          catch (Exception ex)
           {
               base.WriteErrorLog(ex, "PccItemGrpWork.Write");
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkEach">PCC品目グループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteGrpProcEach(ref PccItemGrpWork pccItemGrpWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMGRPRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            //remdime 24299
            findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccItemGrpWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (pccItemGrpWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //既存データで更新日時違いの場合には排他
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCITEMGRPRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , PCCCOMPANYCODERF=@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGROUPCODERF=@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGROUPNAMERF=@ITEMGROUPNAME").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGRPDSPODRRF=@ITEMGRPDSPODR").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append(" , ITEMGRPIMGCODERF=@ITEMGRPIMGCODE").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEYコマンドを再設定
                //remdime 24299
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);

                //コネクション文字列取得対応↓↓↓↓↓
                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemGrpWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                //コネクション文字列取得対応↑↑↑↑↑
            }

            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (pccItemGrpWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("INSERT INTO PCCITEMGRPRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGROUPNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGRPDSPODRRF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append("    ,ITEMGRPIMGCODERF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGROUPNAME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGRPDSPODR").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append("    ,@ITEMGRPIMGCODE").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //登録ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemGrpWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
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
            SqlParameter paraItemGroupCode = sqlCommand.Parameters.Add("@ITEMGROUPCODE", SqlDbType.Int);
            SqlParameter paraItemGroupName = sqlCommand.Parameters.Add("@ITEMGROUPNAME", SqlDbType.NVarChar);
            SqlParameter paraItemGrpDspOdr = sqlCommand.Parameters.Add("@ITEMGRPDSPODR", SqlDbType.Int);
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            SqlParameter paraItemGrpImgCode = sqlCommand.Parameters.Add("@ITEMGRPIMGCODE", SqlDbType.SmallInt);
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemGrpWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemGrpWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.LogicalDeleteCode);
            //Remine 24299 の修正
            paraInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            paraInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.PccCompanyCode);
            paraItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            paraItemGroupName.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.ItemGroupName);
            paraItemGrpDspOdr.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGrpDspOdr);
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            paraItemGrpImgCode.Value = SqlDataMediator.SqlSetInt16(pccItemGrpWorkEach.ItemGrpImgCode);
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC品目設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteStProc(ref object pccItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


            SqlDataReader myReader = null;

            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccItemStWorkArrList.Count; i++)
                {
                    PccItemStWork pccItemStWorkEach = pccItemStWorkArrList[i] as PccItemStWork;
                    if (pccItemStWorkEach.UpdateFlag == 2)
                    {
                        status = DeleteStProcEach(ref pccItemStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = WriteStProcEach(ref pccItemStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccItemStWorkArrListNew.Add(pccItemStWorkEach);

                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                }
                pccItemStWorkList = pccItemStWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWork.Write", status);
            }
           
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWork.Write");
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemStWorkEach">PCC品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteStProcEach(ref PccItemStWork pccItemStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
            sqlTxt.Append(" FROM PCCITEMSTRF").Append(Environment.NewLine);
            sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            SqlParameter findParaItemDspPos1 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS1", SqlDbType.Int);
            SqlParameter findParaItemDspPos2 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS2", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            //remdime 24299
            findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccItemStWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (pccItemStWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //既存データで更新日時違いの場合には排他
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCITEMSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , PCCCOMPANYCODERF=@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGROUPCODERF=@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMDSPPOS1RF=@ITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMDSPPOS2RF=@ITEMDSPPOS2").Append(Environment.NewLine);
                sqlTxt.Append(" , BLGOODSCODERF=@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMQTYRF=@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMSELECTDIVRF=@ITEMSELECTDIV").Append(Environment.NewLine);

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                //remdime 24299
                findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
                findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
                findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
                //コネクション文字列取得対応↓↓↓↓↓
                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                //コネクション文字列取得対応↑↑↑↑↑
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (pccItemStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("INSERT INTO PCCITEMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMDSPPOS1RF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMDSPPOS2RF").Append(Environment.NewLine);
                sqlTxt.Append("    ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMSELECTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMDSPPOS2").Append(Environment.NewLine);
                sqlTxt.Append("    ,@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMSELECTDIV").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //登録ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
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
            SqlParameter paraItemGroupCode = sqlCommand.Parameters.Add("@ITEMGROUPCODE", SqlDbType.Int);
            SqlParameter paraItemDspPos1 = sqlCommand.Parameters.Add("@ITEMDSPPOS1", SqlDbType.Int);
            SqlParameter paraItemDspPos2 = sqlCommand.Parameters.Add("@ITEMDSPPOS2", SqlDbType.Int);
            SqlParameter paraBlGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraItemQty = sqlCommand.Parameters.Add("@ITEMQTY", SqlDbType.Int);
            SqlParameter paraItemSelectDiv = sqlCommand.Parameters.Add("@ITEMSELECTDIV", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.LogicalDeleteCode);
            //Redmine 24299
            paraInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            paraInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.PccCompanyCode);
            paraItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            paraItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            paraItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            paraBlGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.BLGoodsCode);
            paraItemQty.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemQty);
            paraItemSelectDiv.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemSelectDiv);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;

        }

        /// <summary>
        /// PCC品目グループマスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="parsePccItemGrpWork">PCC品目グループ検索パラメータ</param>
        /// <param name="parsePccItemStWork">PCC品目設定検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Search(out object pccItemGrpWorkList, out  object pccItemStWorkList, PccItemGrpWork parsePccItemGrpWork, PccItemStWork parsePccItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccItemGrpWorkList = null;
            pccItemStWorkList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchGrpProc(out pccItemGrpWorkList, parsePccItemGrpWork, readMode, logicalMode, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // write実行
                    status = SearchStProc(out  pccItemStWorkList, parsePccItemStWork,  readMode, logicalMode, ref  sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Search");
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
        /// PCC品目グループマスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="parsePccItemGrpWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchGrpProc(out object pccItemGrpWorkList, PccItemGrpWork parsePccItemGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccItemGrpWorkList = null;
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGROUPNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGRPDSPODRRF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append("      ,ITEMGRPIMGCODERF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                sqlTxt.Append("    FROM PCCITEMGRPRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd))
                {
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOtherSecCd);
                
                }

                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append(" INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOriginalSecCd);
                }

                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalEpCd.Trim()) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalSecCd))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();

                status = this.CopyToGrpWorkListFromReader(ref myReader, ref al);
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpDB.SearchGrpProc", status);
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
            pccItemGrpWorkList = al;

            return status;
        }
        
        /// <summary>
        /// PCC品目グループマスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="parsePccItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchStProc(out object pccItemStWorkList, PccItemStWork parsePccItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            pccItemStWorkList = null;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("      CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMDSPPOS1RF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMDSPPOS2RF").Append(Environment.NewLine);
                sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMSELECTDIVRF").Append(Environment.NewLine);

                sqlTxt.Append("    FROM PCCITEMSTRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd))
                {
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOtherSecCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOriginalSecCd);
                }
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOriginalEpCd.Trim()) || !string.IsNullOrEmpty(parsePccItemStWork.InqOriginalSecCd))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("    ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF,INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF, ITEMDSPPOS1RF,ITEMDSPPOS2RF").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = CopyToStWorkListFromReader(ref myReader, ref al);
               
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCmpnyStDB.Write", status);
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
            pccItemStWorkList = al;

            return status;
        }
       
        /// <summary>
        /// PCC品目グループマスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int Read(ref object pccItemGrpWorkList,ref object pccItemStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadGrpProc(ref pccItemGrpWorkList, readMode, logicalMode, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // write実行
                    status = ReadStProc(ref  pccItemStWorkList,  readMode, logicalMode, ref  sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Read");
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
        /// PCC品目グループマスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int ReadGrpProc(ref object pccItemGrpWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
           
            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                  
                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();
         
               
             foreach (PccItemGrpWork pccItemGrpWorkEach in pccItemGrpWorkArrList)
             {
                StringBuilder sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);

                //Selectコマンドの生成
                sqlTxt.Append("SELECT").Append(Environment.NewLine);
                sqlTxt.Append("  CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,ITEMGROUPNAMERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,ITEMGRPDSPODRRF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append(" ,ITEMGRPIMGCODERF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
              
                sqlTxt.Append("FROM").Append(Environment.NewLine);
                sqlTxt.Append("  PCCITEMGRPRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine); //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                
                //Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                
                //Parameterオブジェクトへ値設定
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyToGrpWorkListFromReader(ref myReader, ref pccItemGrpWorkArrListNew);
               
                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
            }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpWorkDB.ReadProc",status);
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
        /// PCC品目グループマスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int ReadStProc(ref object pccItemStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
           
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;
            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();

                foreach (PccItemStWork pccItemStWorkEach in pccItemStWorkArrList)
                {
                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("      CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMGROUPCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMDSPPOS1RF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMDSPPOS2RF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMSELECTDIVRF").Append(Environment.NewLine);

                    sqlTxt.Append("    FROM PCCITEMSTRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine); //論理削除区分
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF,ITEMDSPPOS1RF,ITEMDSPPOS2RF").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlTxt.ToString();

                    //Prameterオブジェクトの作成
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    
                    //Parameterオブジェクトへ値設定
                    //Remine 24299
                    findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                    findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    status = CopyToStWorkListFromReader(ref myReader, ref pccItemStWorkArrListNew);
                   
                    pccItemStWorkList = pccItemStWorkArrListNew as object;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.ReadProc", status);
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDelete(ref object pccItemGrpWorkList, ref object pccItemStWorkList)
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

                // LogicalDelete実行
                status = LogicalDeleteGrpProc(ref pccItemGrpWorkList, 0, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // write実行
                    if (pccItemStWorkList != null)
                    {
                        status = LogicalDeleteStProc(ref  pccItemStWorkList, 0, ref  sqlConnection, ref  sqlTransaction);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = null;
                        ArrayList pccItemGrpWorkArrList = null;
                         if (pccItemGrpWorkList != null)
                         {
                             pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                         }
                         if (pccItemGrpWorkArrList.Count > 0)
                         {
                             PccItemGrpWork pccItemGrpWork = pccItemGrpWorkArrList[0] as PccItemGrpWork;
                             if (pccItemGrpWork.PccCompanyCode != 0)
                             {
                                 pMBLGdsCdWork = new PMBLGdsCdWork();
                                 pMBLGdsCdWork.InqOriginalEpCd = pccItemGrpWork.InqOriginalEpCd.Trim();	//@@@@20230303
                                 pMBLGdsCdWork.InqOriginalSecCd = pccItemGrpWork.InqOriginalSecCd;
                                 pMBLGdsCdWork.InqOtherEpCd = pccItemGrpWork.InqOtherEpCd;
                                 pMBLGdsCdWork.InqOtherSecCd = pccItemGrpWork.InqOtherSecCd;
                                 status = LogicalDeletePMBLGdsCdProc(ref  pMBLGdsCdWork, 0, ref  sqlConnection, ref  sqlTransaction);
                             }
                         }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.LogicalDelete");
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
        /// PCC品目グループマスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteGrpProc(ref object pccItemGrpWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                   
                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccItemGrpWorkArrList.Count; i++ )
                {
                    PccItemGrpWork pccItemGrpWorkEach = pccItemGrpWorkArrList[i] as PccItemGrpWork;
                    status = LogicalDeleteProcGrpEach(ref pccItemGrpWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemGrpWorkArrListNew.Add(pccItemGrpWorkEach);
                   
                   
                }
                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkEach">PCC品目グループ</param>
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
        public int LogicalDeleteProcGrpEach(ref PccItemGrpWork pccItemGrpWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMGRPRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccItemGrpWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCITEMGRPRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
               
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);

                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemGrpWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
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
                if (logicalDelCd == 0) pccItemGrpWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット
            }
            else
            {
                if (logicalDelCd == 1) pccItemGrpWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除
            }

            //Parameterオブジェクトの作成(更新用)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(更新用)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemGrpWorkEach.UpdateDateTime);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
       
        /// <summary>
        /// PCC品目グループマスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int LogicalDeleteStProc(ref object pccItemStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;

            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemStWorkArrList.Count; i++)
                {
                    PccItemStWork pccItemStWorkEach = pccItemStWorkArrList[i] as PccItemStWork;
                    status = LogicalDeleteProcStEach(ref pccItemStWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemStWorkArrListNew.Add(pccItemStWorkEach);

                    pccItemStWorkList = pccItemStWorkArrListNew as object;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // myReaderの釈放
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemStWorkEach">PCC品目設定データリスト</param>
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
        public int LogicalDeleteProcStEach(ref PccItemStWork pccItemStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(",  LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("   AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            SqlParameter findParaItemDspPos1 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS1", SqlDbType.Int);
            SqlParameter findParaItemDspPos2 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS2", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccItemStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                sqlTxt.Append("UPDATE PCCITEMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
                findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
                findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                if (!myReader.IsClosed) myReader.Close();

                //論理削除モードの場合
                if (procMode == 0)
                {
                    if (logicalDelCd == 0) pccItemStWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット
                }
                else
                {
                    if (logicalDelCd == 1) pccItemStWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除
                }

                //Parameterオブジェクトの作成(更新用)

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定(更新用)

                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.LogicalDeleteCode);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemStWorkEach.UpdateDateTime);

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }
            return status;

        }

        /// <summary>
        /// PCC品目設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Delete(ref object pccItemGrpWorkList, ref object pccItemStWorkList)
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

                // Delete実行
                status = DeleteGrpProc(ref pccItemGrpWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (pccItemStWorkList != null)
                    {
                        // write実行
                        status = DeleteStProc(ref  pccItemStWorkList, ref  sqlConnection, ref  sqlTransaction);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = null;
                        ArrayList pccItemGrpWorkArrList = null;
                        if (pccItemGrpWorkList != null)
                        {
                            pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                        }
                        if (pccItemGrpWorkArrList.Count > 0)
                        {
                            PccItemGrpWork pccItemGrpWork = pccItemGrpWorkArrList[0] as PccItemGrpWork;
                            if (pccItemGrpWork.PccCompanyCode != 0)
                            {
                                pMBLGdsCdWork = new PMBLGdsCdWork();
                                pMBLGdsCdWork.InqOriginalEpCd = pccItemGrpWork.InqOriginalEpCd.Trim();	//@@@@20230303
                                pMBLGdsCdWork.InqOriginalSecCd = pccItemGrpWork.InqOriginalSecCd;
                                pMBLGdsCdWork.InqOtherEpCd = pccItemGrpWork.InqOtherEpCd;
                                pMBLGdsCdWork.InqOtherSecCd = pccItemGrpWork.InqOtherSecCd;
                                status = DeletePMBLGdsCdProc(ref  pMBLGdsCdWork, ref  sqlConnection, ref  sqlTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Delete");
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
        /// PCC品目グループマスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeleteGrpProc(ref object pccItemGrpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;

                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemGrpWorkArrList.Count; i++)
                {
                    PccItemGrpWork pccItemGrpWorkEach = pccItemGrpWorkArrList[i] as PccItemGrpWork;
                    status = DeleteProcGrpEach(ref pccItemGrpWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemGrpWorkArrListNew.Add(pccItemGrpWorkEach);

                }

                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkEach">PCC品目グループ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private int DeleteProcGrpEach(ref PccItemGrpWork pccItemGrpWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMGRPRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccItemGrpWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCITEMGRPRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeleteStProc(ref object pccItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;
            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemStWorkArrList.Count; i++)
                {
                    PccItemStWork pccItemStWorkEach = pccItemStWorkArrList[i] as PccItemStWork;
                    status = DeleteStProcEach(ref pccItemStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemStWorkArrListNew.Add(pccItemStWorkEach);
                }
                pccItemStWorkList = pccItemStWorkArrListNew as object;

            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.Delete Exception=" + ex.Message);
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
        /// PCC品目グループマスタメンテ復活処理
        /// </summary>
        /// <param name="pccItemStWorkEach">PCC品目グループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeleteStProcEach(ref PccItemStWork pccItemStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);

            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            SqlParameter findParaItemDspPos1 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS1", SqlDbType.Int);
            SqlParameter findParaItemDspPos2 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS2", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccItemStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCITEMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
                findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
                findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
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

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
  
        /// <summary>
        /// PCC品目設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccItemGrpWorkList,ref object pccItemStWorkList)
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

                // RevivalLogicalDelete実行
                status = RevivalLogicalDeleteGrpProc(ref pccItemGrpWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (pccItemStWorkList != null)
                    {
                        // write実行
                        status = RevivalLogicalDeleteStProc(ref  pccItemStWorkList, ref  sqlConnection, ref  sqlTransaction);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = null;
                        ArrayList pccItemGrpWorkArrList = null;
                        if (pccItemGrpWorkList != null)
                        {
                            pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                        }
                        if (pccItemGrpWorkArrList.Count > 0)
                        {
                            PccItemGrpWork pccItemGrpWork = pccItemGrpWorkArrList[0] as PccItemGrpWork;
                            if (pccItemGrpWork.PccCompanyCode != 0)
                            {
                                pMBLGdsCdWork = new PMBLGdsCdWork();
                                pMBLGdsCdWork.InqOriginalEpCd = pccItemGrpWork.InqOriginalEpCd.Trim();	//@@@@20230303
                                pMBLGdsCdWork.InqOriginalSecCd = pccItemGrpWork.InqOriginalSecCd;
                                pMBLGdsCdWork.InqOtherEpCd = pccItemGrpWork.InqOtherEpCd;
                                pMBLGdsCdWork.InqOtherSecCd = pccItemGrpWork.InqOtherSecCd;
                                status = RevivalLogicalDeletePMBLGdsCdProc(ref  pMBLGdsCdWork, ref  sqlConnection, ref  sqlTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.RevivalLogicalDelete");
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
        /// PCC品目グループマスタメンテ復活処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteGrpProc(ref object pccItemGrpWorkList,  ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteGrpProc(ref pccItemGrpWorkList, 1,ref sqlConnection,ref sqlTransaction);
        }
       
        /// <summary>
        /// PCC品目設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteStProc(ref object pccItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStProc(ref  pccItemStWorkList, 1, ref sqlConnection, ref  sqlTransaction);
        }

        /// <summary>
        /// PCCBLコードマスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePMBLGdsCd(ref object pMBLGdsCdWorkList)
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
                status = WritePMBLGdsCdProc(ref pMBLGdsCdWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.WritePMBLGdsCd");
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
        /// PCCBLコードマスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePMBLGdsCdProc(ref object pMBLGdsCdWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;

            ArrayList pMBLGdsCdWorkArrList = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pMBLGdsCdWorkList != null)
                {
                    pMBLGdsCdWorkArrList = pMBLGdsCdWorkList as ArrayList;

                }
                if (pMBLGdsCdWorkArrList == null || pMBLGdsCdWorkArrList.Count == 0)
                {
                    return status;
                }
                status = this.WritePMBLGdsCdProcEach(ref pMBLGdsCdWorkArrList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
               
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "WritePMBLGdsCdProc.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WritePMBLGdsCdProc.Write");
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
        /// PCCBLコード登録、更新処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCC自社設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePMBLGdsCdProcEach(ref ArrayList pMBLGdsCdWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            ArrayList pMBLGdsCdWorkListNew = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (pMBLGdsCdWorkList == null && pMBLGdsCdWorkList.Count == 0)
            {
                return status;
            }
            PMBLGdsCdWork pMBLGdsCdWork = pMBLGdsCdWorkList[0] as PMBLGdsCdWork;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append(" DELETE").Append(Environment.NewLine);
            sqlTxt.Append("  FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PMBLGDSCDRF ").Append(Environment.NewLine);
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
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOtherSecCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical); 
            sqlCommand.ExecuteNonQuery();

            foreach (PMBLGdsCdWork pMBLGdsCdWorkEach in pMBLGdsCdWorkList)
            {
                sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                //新規作成時のSQL文を生成
                sqlTxt.Append("     INSERT INTO PMBLGDSCDRF ").Append(Environment.NewLine);
                sqlTxt.Append("      (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     ) VALUES (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @BLGOODSFULLNAME").Append(Environment.NewLine);
                sqlTxt.Append("     , @BLGOODSHALFNAME").Append(Environment.NewLine);
                sqlTxt.Append("     )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //登録ヘッダ情報を設定
                pMBLGdsCdWorkEach.UpdateDateTime = DateTime.Now;
                pMBLGdsCdWorkEach.CreateDateTime = DateTime.Now;
                pMBLGdsCdWorkEach.LogicalDeleteCode = 0;

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                SqlParameter paraPccCompanyCode = sqlCommand.Parameters.Add("@PCCCOMPANYCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NVarChar);

                //Prameterオブジェクトの作成
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMBLGdsCdWorkEach.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMBLGdsCdWorkEach.UpdateDateTime);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.LogicalDeleteCode);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalEpCd);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalSecCd);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
                paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.PccCompanyCode);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.BLGoodsFullName);
                paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.BLGoodsHalfName);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                sqlCommand.ExecuteNonQuery();
                pMBLGdsCdWorkListNew.Add(pMBLGdsCdWorkEach);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            pMBLGdsCdWorkList = pMBLGdsCdWorkListNew;
            return status;
        }

        /// <summary>
        /// PCCBLコードマスタメンテ検索処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int ReadPMBLGdsCd(ref object pMBLGdsCdWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadPMBLGdsCdProc(ref pMBLGdsCdWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.ReadPMBLGdsCd");
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
        /// PCCBLコードマスタメンテ検索処理
        /// </summary>
        /// <param name="objPMBLGdsCdWork">PCCBLコードデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int ReadPMBLGdsCdProc(ref object objPMBLGdsCdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            PMBLGdsCdWork wkPMBLGdsCdWorkOld = null;
            PMBLGdsCdWork wkPMBLGdsCdWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (objPMBLGdsCdWork != null)
            {
                wkPMBLGdsCdWorkOld = objPMBLGdsCdWork as PMBLGdsCdWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
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
                sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("FROM").Append(Environment.NewLine);
                sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF=@FINDBLGOODSCODE").Append(Environment.NewLine);
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOriginalEpCd);
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOriginalSecCd);
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOtherSecCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(wkPMBLGdsCdWorkOld.BLGoodsCode);
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {

                    wkPMBLGdsCdWorkNew = CopyPMBLGdsCdWorkFromSQL(myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (wkPMBLGdsCdWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccItemGrpDB.ReadPMBLGdsCdProc", status);
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
            objPMBLGdsCdWork = wkPMBLGdsCdWorkNew;
            return status;
        }
       
        /// <summary>
        /// PCCBLコードマスタメンテ検索処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <param name="parsePMBLGdsCdWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchPMBLGdsCd(out object pMBLGdsCdWorkList, PMBLGdsCdWork parsePMBLGdsCdWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pMBLGdsCdWorkList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchPMBLGdsCdProc(out pMBLGdsCdWorkList, parsePMBLGdsCdWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Search");
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
        /// PCCBLコードマスタメンテ検索処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <param name="parsePMBLGdsCdWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchPMBLGdsCdProc(out object pMBLGdsCdWorkList, PMBLGdsCdWork parsePMBLGdsCdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pMBLGdsCdWorkList = null;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null; 
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
                sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("FROM").Append(Environment.NewLine);
                sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd))
                {
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    //Prameterオブジェクトの作成
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    //KEYコマンドを再設定
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOtherSecCd);
                }
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherSecCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOriginalSecCd);
                }
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyPMBLGdsCdWorkListFromReader(ref myReader, ref al);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccItemGrpDB.SearchPMBLGdsCdProc", status);
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
            pMBLGdsCdWorkList = al;
            return status;
        }

        /// <summary>
        /// PMBLコード,PCC品目グループ,PCC品目設定検索処理
        /// </summary>
        /// <param name="retInfosList">PMBLコード,PCC品目グループ,PCC品目設定データリスト</param>
        /// <param name="paraWorksList">PMBLコード,PCC品目グループ,PCC品目設定検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchFourInfos(out object retInfosList, ref object paraWorksList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retInfosList = null;
            CustomSerializeArrayList retInfosCustomSerializeList = new CustomSerializeArrayList();
            SqlConnection sqlConnection = null;
            //PMBLコード検索パラメータ
            PMBLGdsCdWork paraPMBLGdsCdWork = null;
            //PCC品目グループ検索パラメータ
            PccItemGrpWork paraPccItemGrpWork = null;
            //PCC品目設定検索パラメータ
            PccItemStWork paraPccItemStWork = null;
            //PCCBLコードデータリスト
            object pMBLGdsCdWorkObj = null;
            //PCC品目グループデータリスト
            object pccItemGrpWorkObj = null;
            //CC品目設定データリスト
            object pccItemStWorkObj = null;
            //PCCBLコードデータリスト
            ArrayList pMBLGdsCdWorkList = new ArrayList();
            //PCC品目グループデータリスト
            ArrayList pccItemGrpWorkList = new ArrayList();
            //CC品目設定データリスト
            ArrayList pccItemStWorkList = new ArrayList();
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //検索パラメータチェック
                CustomSerializeArrayList paramArray = paraWorksList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }
                //別々の検索パラメータの取得
                for (int i = 0; i < paramArray.Count; i++)
                {
                    //PMBLコード検索パラメータ
                    if (paramArray[i].GetType().Equals(typeof(PMBLGdsCdWork)))
                    {
                        paraPMBLGdsCdWork = paramArray[i] as PMBLGdsCdWork;
                        continue;
                    }
                    //PCC品目グループ検索パラメータ
                    if (paramArray[i].GetType().Equals(typeof(PccItemGrpWork)))
                    {
                        paraPccItemGrpWork = paramArray[i] as PccItemGrpWork;
                        continue;
                    }
                    //PCC品目設定検索パラメータ
                    if (paramArray[i].GetType().Equals(typeof(PccItemStWork)))
                    {
                        paraPccItemStWork = paramArray[i] as PccItemStWork;
                        continue;
                    }
                }
                int statusAll = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (paraPMBLGdsCdWork != null)
                {
                    //PCCBLコードマスタメンテ検索処理
                    status = SearchPMBLGdsCdProc(out pMBLGdsCdWorkObj, paraPMBLGdsCdWork, readMode, logicalMode, ref sqlConnection);
                    statusAll = status;
                }
                if (paraPccItemGrpWork != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //PCC品目グループ検索処理
                        status = SearchGrpProc(out pccItemGrpWorkObj, paraPccItemGrpWork, readMode, logicalMode, ref sqlConnection);
                        if (statusAll == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusAll = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                if (paraPccItemStWork != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //PCC品目設定検索処理
                        status = SearchStProc(out pccItemStWorkObj, paraPccItemStWork, readMode, logicalMode, ref sqlConnection);
                        if (statusAll == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusAll = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            status = statusAll;
                        }
                    }
                }
                if (pMBLGdsCdWorkObj != null)
                {
                    pMBLGdsCdWorkList = pMBLGdsCdWorkObj as ArrayList;
                }
                if (pccItemGrpWorkObj != null)
                {
                    pccItemGrpWorkList = pccItemGrpWorkObj as ArrayList;
                }
                if (pccItemStWorkObj != null)
                {
                    pccItemStWorkList = pccItemStWorkObj as ArrayList;
                }
                //PCCBLコードデータリスト
                retInfosCustomSerializeList.Add(pMBLGdsCdWorkList);
                //PCC品目グループデータリスト
                retInfosCustomSerializeList.Add(pccItemGrpWorkList);
                //CC品目設定データリスト
                retInfosCustomSerializeList.Add(pccItemStWorkList);
                retInfosList = retInfosCustomSerializeList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.SearchFourInfos");
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
        /// PCCBLコード論理削除処理
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCCBLコードデータリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int LogicalDeletePMBLGdsCdProc(ref PMBLGdsCdWork pMBLGdsCdWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                if (pMBLGdsCdWork == null)
                {
                    return status;
                }
                status = LogicalDeletePMBLGdsCdProcEach(ref pMBLGdsCdWork, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // myReaderの釈放
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCCBLコードマスタメンテ論理削除処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkEach">PCCBLコードデータリスト</param>
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
        public int LogicalDeletePMBLGdsCdProcEach(ref PMBLGdsCdWork pMBLGdsCdWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder(string.Empty);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);
            sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            
            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);

            //KEYコマンドを再設定
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
            sqlCommand.CommandText = sqlTxt.ToString();
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                sqlTxt.Append("UPDATE PMBLGDSCDRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = pMBLGdsCdWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pMBLGdsCdWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
                //更新ヘッダ情報を設定
                pMBLGdsCdWorkEach.UpdateDateTime = DateTime.Now;
                if (!myReader.IsClosed) myReader.Close();

                //論理削除モードの場合
                if (procMode == 0)
                {
                    if (logicalDelCd == 0) pMBLGdsCdWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット
                }
                else
                {
                    if (logicalDelCd == 1) pMBLGdsCdWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除
                }

                //Parameterオブジェクトの作成(更新用)

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定(更新用)

                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.LogicalDeleteCode);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMBLGdsCdWorkEach.UpdateDateTime);

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }
            return status;

        }

        /// <summary>
        /// PCCBLコードマスタメンテ論理削除処理
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCCBLコード定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeletePMBLGdsCdProc(ref PMBLGdsCdWork pMBLGdsCdWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pMBLGdsCdWork == null)
                {
                    return status;
                }
                status = DeletePMBLGdsCdProcEach(ref pMBLGdsCdWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
               
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.Delete Exception=" + ex.Message);
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
        /// PCCBLコードマスタメンテ復活処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkEach">PCCBLコードデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeletePMBLGdsCdProcEach(ref PMBLGdsCdWork pMBLGdsCdWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
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

            //KEYコマンドを再設定
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PMBLGDSCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = pMBLGdsCdWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pMBLGdsCdWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
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

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCBLコードマスタメンテ復活処理
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCC品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeletePMBLGdsCdProc(ref PMBLGdsCdWork pMBLGdsCdWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeletePMBLGdsCdProc(ref  pMBLGdsCdWork, 1, ref sqlConnection, ref  sqlTransaction);
        }

#endregion

        #region 内部処理

        /// <summary>
        /// ＰＭＢＬコードデータ取得処理
        /// </summary>
        /// <param name="myReader">ＰＭＢＬコードデータReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private PMBLGdsCdWork CopyPMBLGdsCdWorkFromSQL(SqlDataReader myReader)
        {
            PMBLGdsCdWork pMBLGdsCdWork = new PMBLGdsCdWork();
            //作成日時
            pMBLGdsCdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //更新日時
            pMBLGdsCdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //論理削除区分
            pMBLGdsCdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //問合せ元企業コード
            pMBLGdsCdWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();//@@@@20230303
            //問合せ元拠点コード
            pMBLGdsCdWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            //問合せ先企業コード
            pMBLGdsCdWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            //問合せ先拠点コード
            pMBLGdsCdWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            //PCC自社コード
            pMBLGdsCdWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PCCCOMPANYCODERF"));
            //BL商品コード
            pMBLGdsCdWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //BL商品コード名称（全角）
            pMBLGdsCdWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            //BL商品コード名称（半角）
            pMBLGdsCdWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            return pMBLGdsCdWork;
        }

        /// <summary>
        /// ＰＭＢＬコード取得処理
        /// </summary>
        /// <param name="myReader">ＰＭＢＬコードReader</param>
        /// <param name="pMBLGdsCdWorkList">ＰＭＢＬコードデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPMBLGdsCdWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pMBLGdsCdWorkList)
        {
            pMBLGdsCdWorkList = new ArrayList();
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
            //BL商品コード
            int colIndex_BLGoodsCode = 0;
            //BL商品コード名称（全角）
            int colIndex_BLGoodsFullName = 0;
            //BL商品コード名称（半角）
            int colIndex_BLGoodsHalfName = 0;
            try
            {
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
                    //BL商品コード
                    colIndex_BLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
                    //BL商品コード名称（全角）
                    colIndex_BLGoodsFullName = myReader.GetOrdinal("BLGOODSFULLNAMERF");
                    //BL商品コード名称（半角）
                    colIndex_BLGoodsHalfName = myReader.GetOrdinal("BLGOODSHALFNAMERF");
                }
                while (myReader.Read())
                {
                    PMBLGdsCdWork pMBLGdsCdWork = new PMBLGdsCdWork();
                    //作成日時
                    pMBLGdsCdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    pMBLGdsCdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    pMBLGdsCdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ元企業コード
                    pMBLGdsCdWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //問合せ元拠点コード
                    pMBLGdsCdWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //問合せ先企業コード
                    pMBLGdsCdWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    pMBLGdsCdWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //PCC自社コード
                    pMBLGdsCdWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                    //BL商品コード
                    pMBLGdsCdWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
                    //BL商品コード名称（全角）
                    pMBLGdsCdWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsFullName);
                    //BL商品コード名称（半角）
                    pMBLGdsCdWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsHalfName);
                    pMBLGdsCdWorkList.Add(pMBLGdsCdWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pMBLGdsCdWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCC品目グループ取得処理
        /// </summary>
        /// <param name="myReader">PPCC品目グループReader</param>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyToGrpWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccItemGrpWorkList)
        {
            pccItemGrpWorkList = new ArrayList();
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
            //品目グループコード
            int colIndex_ItemGroupCode = 0;
            //品目グループ名称
            int colIndex_ItemGroupName = 0;
            //品目グループ表示順位
            int colIndex_ItemGrpDspOdr = 0;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //品目グループ画像コード
            int colIndex_ItemGrpImgCode = 0;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            try
            {
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
                    //品目グループコード
                    colIndex_ItemGroupCode = myReader.GetOrdinal("ITEMGROUPCODERF");
                    //品目グループ名称
                    colIndex_ItemGroupName = myReader.GetOrdinal("ITEMGROUPNAMERF");
                    //品目グループ表示順位
                    colIndex_ItemGrpDspOdr = myReader.GetOrdinal("ITEMGRPDSPODRRF");
                    // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //品目グループ画像コード
                    colIndex_ItemGrpImgCode = myReader.GetOrdinal("ITEMGRPIMGCODERF");
                    // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
                while (myReader.Read())
                {
                    PccItemGrpWork wkPccItemGrpWork = new PccItemGrpWork();
                    //作成日時
                    wkPccItemGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    wkPccItemGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    wkPccItemGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ元企業コード
                    wkPccItemGrpWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //問合せ元拠点コード
                    wkPccItemGrpWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //問合せ先企業コード
                    wkPccItemGrpWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    wkPccItemGrpWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //PCC自社コード
                    wkPccItemGrpWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                    //品目グループコード
                    wkPccItemGrpWork.ItemGroupCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemGroupCode);
                    //品目グループ名称
                    wkPccItemGrpWork.ItemGroupName = SqlDataMediator.SqlGetString(myReader, colIndex_ItemGroupName);
                    //品目グループ表示順位
                    wkPccItemGrpWork.ItemGrpDspOdr = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemGrpDspOdr);
                    // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //品目グループ画像コード
                    wkPccItemGrpWork.ItemGrpImgCode = SqlDataMediator.SqlGetInt16(myReader, colIndex_ItemGrpImgCode);
                    // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    pccItemGrpWorkList.Add(wkPccItemGrpWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccItemGrpWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCC品目設定取得処理
        /// </summary>
        /// <param name="myReader">PPCC品目設定Reader</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyToStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccItemStWorkList)
        {
            pccItemStWorkList = new ArrayList();
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
            //品目グループコード
            int colIndex_ItemGroupCode = 0;
            //品目表示位置1
            int colIndex_ItemDspPos1 = 0;
            //品目表示位置2
            int colIndex_ItemDspPos2 = 0;
            //BL商品コード
            int colIndex_BLGoodsCode = 0;
            //品目QTY
            int colIndex_ItemQty = 0;
            //品目選択区分
            int colIndex_ItemSelectDiv = 0;
            try
            {
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
                    //品目グループコード
                    colIndex_ItemGroupCode = myReader.GetOrdinal("ITEMGROUPCODERF");
                    //品目表示位置1
                    colIndex_ItemDspPos1 = myReader.GetOrdinal("ITEMDSPPOS1RF");
                    //品目表示位置2
                    colIndex_ItemDspPos2 = myReader.GetOrdinal("ITEMDSPPOS2RF");
                    //BL商品コード
                    colIndex_BLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
                    //品目QTY
                    colIndex_ItemQty = myReader.GetOrdinal("ITEMQTYRF");
                    //品目選択区分
                    colIndex_ItemSelectDiv = myReader.GetOrdinal("ITEMSELECTDIVRF");
                }
                while (myReader.Read())
                {
                    PccItemStWork wkPccItemStWork = new PccItemStWork();
                    //作成日時
                    wkPccItemStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    wkPccItemStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    wkPccItemStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ元企業コード
                    wkPccItemStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //問合せ元拠点コード
                    wkPccItemStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //問合せ先企業コード
                    wkPccItemStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    wkPccItemStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //PCC自社コード
                    wkPccItemStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                    //品目グループコード
                    wkPccItemStWork.ItemGroupCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemGroupCode);
                    //品目表示位置1
                    wkPccItemStWork.ItemDspPos1 = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemDspPos1);
                    //品目表示位置2
                    wkPccItemStWork.ItemDspPos2 = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemDspPos2);
                    //BL商品コード
                    wkPccItemStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
                    //品目QTY
                    wkPccItemStWork.ItemQty = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemQty);
                    //品目選択区分
                    wkPccItemStWork.ItemSelectDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemSelectDiv);

                    pccItemStWorkList.Add(wkPccItemStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccItemStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        #endregion
    }
}
