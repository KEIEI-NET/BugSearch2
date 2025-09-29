//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理ログ参照ツール
// プログラム概要   : 送受信履歴の追加更新、抽出、物理削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/07/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/10/08  修正内容 : ソースのコメントがPG名称の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/10/16  修正内容 : 拠点管理ログ参照ツール不具合の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 董桂鈺
// 作 成 日  2012/12/18  修正内容 :Redmine#33961 拠点管理ログ参照ツールにて、
//　　　　　　　　　　　　　　　　送受信区分に「全て」を指定し検索不正の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宮本　利明
// 作 成 日  2013/02/20  修正内容 : 拠点管理DC送受信履歴情報のINSERT時に
//                                  更新従業員コードが空の場合は更新しない
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC送受信履歴　リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点管理DC送受信履歴の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/07/23</br>
    /// <br></br>
    /// <br>Update Note: 2012/10/08 李亜博</br>
    ///	<br>			 Redmine#31026 ソースのコメントがPG名称の修正</br>
    /// <br>Update Note: 2012/10/16 李亜博</br>
    ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// <br>Update Note: 2012/12/18 董桂鈺</br>
    ///	<br>			 Redmine#33961 拠点管理ログ参照ツールにて、
    ///　　　　　　　　　送受信区分に「全て」を指定し検索不正の対応</br>
    /// </remarks>
    [Serializable]
    public class SndRcvHisTableDB : RemoteDB, ISndRcvHisTableDB
    {
        /// <summary>
        /// 拠点管理DC送受信履歴DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public SndRcvHisTableDB()
            : base("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork", "SndRcvHisConRF")
        {

        }

        # region [Write]
        /// <summary>
        /// 拠点管理DC送受信履歴情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="sndRcvHisTableWorkList">sndRcvHisTableWorkListオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理DC送受信履歴を追加・更新します。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public int Write(ref object sndRcvHisTableWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList sndRcvHisTableList = new ArrayList();
            sndRcvHisTableList = sndRcvHisTableWorkList as ArrayList;
            try
            {
                //コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                foreach (SndRcvHisTableWork sndRcvHisTableWork in sndRcvHisTableList)
                {
                    //write実行
                    status = WriteProc(sndRcvHisTableWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisDB.Write(ref object sndRcvHisTableList)");
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
        /// 拠点管理DC送受信履歴情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="sndRcvHisTableWork">拠点管理DC送受信履歴情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理DC送受信履歴情報を登録、更新します</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private int WriteProc(SndRcvHisTableWork sndRcvHisTableWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2013/02/20 T.Miyamoto ------------------------------>>>>>
            //更新ヘッダ情報を設定
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)sndRcvHisTableWork;
            FileHeader fileHeader = new FileHeader(obj);
            fileHeader.SetInsertHeader(ref flhd, obj);
            if (sndRcvHisTableWork.UpdEmployeeCode.Trim().Equals(""))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }
            // ADD 2013/02/20 T.Miyamoto ------------------------------>>>>>

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            StringBuilder sqlText1 = new StringBuilder();

            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

            int sndRcvHisNoMax = 0;
            sqlText.Append(
                "SELECT MAX(SNDRCVHISSNDRCVNORF) SNDRCVHISSNDRCVNORF FROM SNDRCVHISTABLERF " +
                "WHERE" +
                " ENTERPRISECODERF = @FINDENTERPRISECODERF").Append(Environment.NewLine);
            sqlCommand.CommandText = sqlText.ToString();

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.EnterpriseCode);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                sndRcvHisNoMax = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISSNDRCVNORF"));
            }

            try
            {
                sndRcvHisTableWork.SndRcvHisSndRcvNo = sndRcvHisNoMax + 1;

                # region [INSERT文]
                sqlText1.Append("INSERT INTO" +
                "  SNDRCVHISTABLERF  " +
                " (" +
                "     CREATEDATETIMERF" +
                "    ,UPDATEDATETIMERF" +
                "    ,ENTERPRISECODERF" +
                "    ,FILEHEADERGUIDRF" +
                "    ,UPDEMPLOYEECODERF" +
                "    ,UPDASSEMBLYID1RF" +
                "    ,UPDASSEMBLYID2RF" +
                "    ,LOGICALDELETECODERF" +
                "    ,SNDRCVHISSNDRCVNORF" +
                "    ,SECTIONCODERF" +
                "    ,SNDRCVHISCONSNORF" +
                "    ,SNDRCVDATETIMERF" +
                "    ,SENDORRECEIVEDIVCDRF" +
                "    ,KINDRF" +
                "    ,SNDLOGEXTRACONDDIVRF" +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //"    ,PROCSTARTDATETIMERF" +
                //"    ,PROCENDDATETIMERF" +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                "    ,SENDDESTEPCODERF" +
                "    ,SENDDESTSECCODERF" +
                "    ,SNDRCVCONDITIONRF" +
                "    ,TEMPRECEIVEDIVRF" +
                "    ,SNDRCVERRCONTENTSRF" +
                "    ,SNDRCVFILEIDRF" +
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                "    ,SNDOBJSTARTDATERF" +
                "    ,SNDOBJENDDATERF" +
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                " )" +
                " VALUES" +
               " (@CREATEDATETIME" +
                "    ,@UPDATEDATETIME" +
                "    ,@ENTERPRISECODE" +
                "    ,@FILEHEADERGUID" +
                "    ,@UPDEMPLOYEECODE" +
                "    ,@UPDASSEMBLYID1" +
                "    ,@UPDASSEMBLYID2" +
                "    ,@LOGICALDELETECODE" +
                "    ,@SNDRCVHISSNDRCVNO" +
                "    ,@SECTIONCODE" +
                "    ,@SNDRCVHISCONSNO" +
                "    ,@SNDRCVDATETIME" +
                "    ,@SENDORRECEIVEDIVCD" +
                "    ,@KIND" +
                "    ,@SNDLOGEXTRACONDDIV" +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //"    ,@PROCSTARTDATETIME" +
                //"    ,@PROCENDDATETIME" +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                "    ,@SENDDESTEPCODE" +
                "    ,@SENDDESTSECCODE" +
                "    ,@SNDRCVCONDITION" +
                "    ,@TEMPRECEIVEDIV" +
                "    ,@SNDRCVERRCONTENTS" +
                "    ,@SNDRCVFILEID" +
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                "    ,@SNDOBJSTARTDATERF" +
                "    ,@SNDOBJENDDATERF" +
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                " )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlText1.ToString();
                # endregion

                // DEL 2013/02/20 T.Miyamoto ------------------------------>>>>>
                ////更新ヘッダ情報を設定
                //object obj = (object)this;
                //IFileHeader flhd = (IFileHeader)sndRcvHisTableWork;
                //FileHeader fileHeader = new FileHeader(obj);
                //fileHeader.SetInsertHeader(ref flhd, obj);
                // DEL 2013/02/20 T.Miyamoto ------------------------------<<<<<
                if (myReader.IsClosed == false) myReader.Close();
                #region Parameterオブジェクトの作成
                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSndRcvHisSndRcvNo = sqlCommand.Parameters.Add("@SNDRCVHISSNDRCVNO", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
                SqlParameter paraSndRcvDateTime = sqlCommand.Parameters.Add("@SNDRCVDATETIME", SqlDbType.BigInt);
                SqlParameter paraSendOrReceiveDivCd = sqlCommand.Parameters.Add("@SENDORRECEIVEDIVCD", SqlDbType.Int);
                SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
                SqlParameter paraSndLogExtraCondDiv = sqlCommand.Parameters.Add("@SNDLOGEXTRACONDDIV", SqlDbType.Int);
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //SqlParameter paraProcStartDateTime = sqlCommand.Parameters.Add("@PROCSTARTDATETIME", SqlDbType.BigInt);
                //SqlParameter paraProcEndDateTime = sqlCommand.Parameters.Add("@PROCENDDATETIME", SqlDbType.BigInt);
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                SqlParameter paraSendDestEpCode = sqlCommand.Parameters.Add("@SENDDESTEPCODE", SqlDbType.NChar);
                SqlParameter paraSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);
                SqlParameter paraSndRcvCondition = sqlCommand.Parameters.Add("@SNDRCVCONDITION", SqlDbType.Int);
                SqlParameter paraTempReceiveDiv = sqlCommand.Parameters.Add("@TEMPRECEIVEDIV", SqlDbType.Int);
                SqlParameter paraSndRcvErrContents = sqlCommand.Parameters.Add("@SNDRCVERRCONTENTS", SqlDbType.NChar);
                SqlParameter paraSndRcvFileID = sqlCommand.Parameters.Add("@SNDRCVFILEID", SqlDbType.NChar);
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                SqlParameter paraSndObjStartDateTime = sqlCommand.Parameters.Add("@SNDOBJSTARTDATERF", SqlDbType.BigInt);
                SqlParameter paraSndObjEndDateTime = sqlCommand.Parameters.Add("@SNDOBJENDDATERF", SqlDbType.BigInt);
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                #endregion

                #region Parameterオブジェクトへ値設定
                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisTableWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisTableWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sndRcvHisTableWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.LogicalDeleteCode);
                paraSndRcvHisSndRcvNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvHisSndRcvNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SectionCode);
                paraSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvHisConsNo);
                paraSndRcvDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.SndRcvDateTime);
                paraSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SendOrReceiveDivCd);
                paraKind.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.Kind);
                paraSndLogExtraCondDiv.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndLogExtraCondDiv);
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //paraProcStartDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.ProcStartDateTime);
                //paraProcEndDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.ProcEndDateTime);
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                paraSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SendDestEpCode);
                paraSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SendDestSecCode);
                paraSndRcvCondition.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvCondition);
                paraTempReceiveDiv.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.TempReceiveDiv);
                //paraSndRcvErrContents.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvErrContents);//DEL 2012/10/16 李亜博 for redmine#31026 
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                if (sndRcvHisTableWork.SndRcvErrContents.Length > 100)
                {
                    paraSndRcvErrContents.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvErrContents.Substring(0, 100));
                }
                else
                {
                    paraSndRcvErrContents.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvErrContents);
                }
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                paraSndRcvFileID.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvFileID);
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                paraSndObjStartDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.SndObjStartDate);
                paraSndObjEndDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.SndObjEndDate);
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                #endregion
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SndRcvHisTableDB.Write" + status, sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SndRcvHisTableDB.Write" + status);
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
        # endregion

        # region [Search]
        /// <summary>
        /// 拠点管理DC送受信履歴のリストを取得します。
        /// </summary> 
        /// <remarks>
        /// <param name="sndRcvHisConWork">検索条件</param>
        /// <param name="objSndRcvHisList">送受信履歴検索結果</param>
        /// <param name="objSndRcvEtrList">送受信抽出条件履歴ログデータ検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理DC送受信履歴のキー値が一致する、全ての拠点管理DC送受信履歴情報を取得します。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public int Search(SndRcvHisConWork sndRcvHisConWork, out object objSndRcvHisList, out object objSndRcvEtrList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            ArrayList sndRcvHisList = new ArrayList();
            ArrayList sndRcvEtrList = new ArrayList();
            objSndRcvHisList = new ArrayList();
            objSndRcvEtrList = new ArrayList();

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                {

                    return status;
                }

                sqlConnection.Open();

                return SearchHisProc(sndRcvHisConWork, out sndRcvHisList, out sndRcvEtrList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisTableDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                objSndRcvHisList = sndRcvHisList;
                objSndRcvEtrList = sndRcvEtrList;
            }
        }

        /// <summary>
        /// 指定された条件の送受信履歴戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="sndRcvHisConWork">検索パラメータ</param>
        /// <param name="sndRcvHisWorkList">送受信履歴検索結果</param>
        /// <param name="sndRcvEtrWorkList">送受信抽出条件履歴ログデータ検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の送受信履歴戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        private int SearchHisProc(SndRcvHisConWork sndRcvHisConWork, out ArrayList sndRcvHisWorkList, out ArrayList sndRcvEtrWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sndRcvHisWorkList = new ArrayList();
            sndRcvEtrWorkList = new ArrayList();
            ArrayList sndRcvEtrWorkSubList = new ArrayList();


            status = SearchHisProcProc(sndRcvHisConWork, out sndRcvHisWorkList, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (sndRcvHisWorkList != null && sndRcvHisWorkList.Count > 0)
                {
                    Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();//ADD 2012/10/16 李亜博 for redmine#31026
                    foreach (SndRcvHisTableWork sndRcvHisTableWork in sndRcvHisWorkList)
                    {
                        if (sndRcvHisTableWork.Kind == 1)
                        {
                            //子表検索
                            //status = this.SearchSubHisProcProc(sndRcvHisTableWork, out sndRcvEtrWorkSubList, ref sqlConnection);//DEL 2012/10/16 李亜博 for redmine#31026
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            sndRcvEtrWorkSubList = new ArrayList();
                            if (!tempSndRcvDic.ContainsKey(sndRcvHisTableWork.EnterpriseCode + sndRcvHisTableWork.SectionCode + sndRcvHisTableWork.SndRcvHisConsNo.ToString()))
                            {
                                status = this.SearchSubHisProcProc(sndRcvHisTableWork, out sndRcvEtrWorkSubList, ref sqlConnection);
                                tempSndRcvDic.Add(sndRcvHisTableWork.EnterpriseCode + sndRcvHisTableWork.SectionCode + sndRcvHisTableWork.SndRcvHisConsNo.ToString(), sndRcvHisTableWork.EnterpriseCode + sndRcvHisTableWork.SectionCode + sndRcvHisTableWork.SndRcvHisConsNo.ToString());
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                return status;
                            }

                            foreach (SndRcvEtrWork sndRcvEtrWork in sndRcvEtrWorkSubList)
                            {
                                sndRcvEtrWorkList.Add(sndRcvEtrWork);
                            }
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の送受信履歴戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="sndRcvHisConWork">検索パラメータ</param>
        /// <param name="sndRcvHisWorkList">送受信履歴検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        private int SearchHisProcProc(SndRcvHisConWork sndRcvHisConWork, out ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append(
                    "SELECT " +
                        "HISTAB.CREATEDATETIMERF," +
                        "HISTAB.UPDATEDATETIMERF," +
                        "HISTAB.ENTERPRISECODERF," +
                        "HISTAB.FILEHEADERGUIDRF," +
                        "HISTAB.UPDEMPLOYEECODERF," +
                        "HISTAB.UPDASSEMBLYID1RF," +
                        "HISTAB.UPDASSEMBLYID2RF," +
                        "HISTAB.LOGICALDELETECODERF," +
                        "HISTAB.SNDRCVHISSNDRCVNORF," +
                        "HISTAB.SECTIONCODERF," +
                        "HISTAB.SNDRCVHISCONSNORF," +
                        "HISTAB.SNDRCVDATETIMERF," +
                        "HISTAB.SENDORRECEIVEDIVCDRF," +
                        "HISTAB.KINDRF," +
                        "HISTAB.SNDLOGEXTRACONDDIVRF," +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        //"HISTAB.PROCSTARTDATETIMERF," +
                        //"HISTAB.PROCENDDATETIMERF," +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        "HISTAB.SENDDESTEPCODERF," +
                        "HISTAB.SENDDESTSECCODERF," +
                        "HISTAB.SNDRCVCONDITIONRF," +
                        "HISTAB.TEMPRECEIVEDIVRF," +
                        "HISTAB.SNDRCVERRCONTENTSRF," +
                        "HISTAB.SNDRCVFILEIDRF," +
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        "HISTAB.SNDOBJSTARTDATERF," +
                        "HISTAB.SNDOBJENDDATERF," +
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

                        "HIS.SENDDATETIMERF," +
                        "HIS.SNDLOGUSEDIVRF," +
                        "HIS.EXTRAOBJSECCODERF," +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        //"HIS.SNDOBJSTARTDATERF," +
                        //"HIS.SNDOBJENDDATERF, " +
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        "HIS.SYNCEXECDATERF " +
                      "FROM SNDRCVHISTABLERF AS HISTAB WITH (READUNCOMMITTED) " +
                      //"INNER JOIN SNDRCVHISRF AS HIS WITH (READUNCOMMITTED) " +//DEL 2012/10/16 李亜博 for redmine#31026
                      "LEFT JOIN SNDRCVHISRF AS HIS WITH (READUNCOMMITTED) " +//ADD 2012/10/16 李亜博 for redmine#31026
                      "ON HISTAB.ENTERPRISECODERF = HIS.ENTERPRISECODERF " +
                      "AND HISTAB.SECTIONCODERF = HIS.SECTIONCODERF " +
                      "AND HISTAB.LOGICALDELETECODERF = HIS.LOGICALDELETECODERF "+//ADD 2012/10/16 李亜博 for redmine#31026
                      "AND HISTAB.SNDRCVHISCONSNORF = HIS.SNDRCVHISCONSNORF ");
                sqlTxt.Append(MakeWhereString(ref sqlCommand, sndRcvHisConWork));
                sqlCommand.CommandText = sqlTxt.ToString();

                myReader = sqlCommand.ExecuteReader();

                int colIndex_CreateDateTime = 0;
                int colIndex_UpdateDateTime = 0;
                int colIndex_EnterpriseCode = 0;
                int colIndex_FileHeaderGuid = 0;
                int colIndex_UpdEmployeeCode = 0;
                int colIndex_UpdAssemblyId1 = 0;
                int colIndex_UpdAssemblyId2 = 0;
                int colIndex_LogicalDeleteCode = 0;
                int colIndex_SndRcvHisSndRcvNo = 0;
                int colIndex_SectionCode = 0;
                int colIndex_SndRcvHisConsNo = 0;
                int colIndex_SndRcvDateTime = 0;
                int colIndex_SendOrReceiveDivCd = 0;
                int colIndex_Kind = 0;
                int colIndex_SndLogExtraCondDiv = 0;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //int colIndex_ProcStartDateTime = 0;
                //int colIndex_ProcEndDateTime = 0;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                int colIndex_SendDestEpCode = 0;
                int colIndex_SendDestSecCode = 0;
                int colIndex_SndRcvCondition = 0;
                int colIndex_TempReceiveDiv = 0;
                int colIndex_SndRcvErrContents = 0;
                int colIndex_SndRcvFileID = 0;
                int colIndex_SndLogUseDiv = 0;
                int colIndex_ExtraObjSecCode = 0;
                int colIndex_SndObjStartDate = 0;
                int colIndex_SndObjEndDate = 0;
                int colIndex_SyncExecDate = 0;

                if (myReader.HasRows)
                {
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                    colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                    colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                    colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                    colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    colIndex_SndRcvHisSndRcvNo = myReader.GetOrdinal("SNDRCVHISSNDRCVNORF");
                    colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                    colIndex_SndRcvHisConsNo = myReader.GetOrdinal("SNDRCVHISCONSNORF");
                    colIndex_SndRcvDateTime = myReader.GetOrdinal("SNDRCVDATETIMERF");
                    colIndex_SendOrReceiveDivCd = myReader.GetOrdinal("SENDORRECEIVEDIVCDRF");
                    colIndex_Kind = myReader.GetOrdinal("KINDRF");
                    colIndex_SndLogExtraCondDiv = myReader.GetOrdinal("SNDLOGEXTRACONDDIVRF");
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                    //colIndex_ProcStartDateTime = myReader.GetOrdinal("PROCSTARTDATETIMERF");
                    //colIndex_ProcEndDateTime = myReader.GetOrdinal("PROCENDDATETIMERF");
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                    colIndex_SendDestEpCode = myReader.GetOrdinal("SENDDESTEPCODERF");
                    colIndex_SendDestSecCode = myReader.GetOrdinal("SENDDESTSECCODERF");
                    colIndex_SndRcvCondition = myReader.GetOrdinal("SNDRCVCONDITIONRF");
                    colIndex_TempReceiveDiv = myReader.GetOrdinal("TEMPRECEIVEDIVRF");
                    colIndex_SndRcvErrContents = myReader.GetOrdinal("SNDRCVERRCONTENTSRF");
                    colIndex_SndRcvFileID = myReader.GetOrdinal("SNDRCVFILEIDRF");

                    colIndex_SndLogUseDiv = myReader.GetOrdinal("SNDLOGUSEDIVRF");
                    colIndex_ExtraObjSecCode = myReader.GetOrdinal("EXTRAOBJSECCODERF");
                    colIndex_SndObjStartDate = myReader.GetOrdinal("SNDOBJSTARTDATERF");
                    colIndex_SndObjEndDate = myReader.GetOrdinal("SNDOBJENDDATERF");
                    colIndex_SyncExecDate = myReader.GetOrdinal("SYNCEXECDATERF");
                }

                while (myReader.Read())
                {
                    SndRcvHisTableWork wkLogWork = new SndRcvHisTableWork();
                    #region クラスへ格納

                    wkLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    wkLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    wkLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                    wkLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                    wkLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                    wkLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                    wkLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                    wkLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    wkLogWork.SndRcvHisSndRcvNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisSndRcvNo);
                    wkLogWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                    wkLogWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisConsNo);
                    wkLogWork.SndRcvDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_SndRcvDateTime);
                    wkLogWork.SendOrReceiveDivCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SendOrReceiveDivCd);
                    wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, colIndex_Kind);
                    wkLogWork.SndLogExtraCondDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndLogExtraCondDiv);
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                    //wkLogWork.ProcStartDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_ProcStartDateTime);
                    //wkLogWork.ProcEndDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_ProcEndDateTime);
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                    wkLogWork.SendDestEpCode = SqlDataMediator.SqlGetString(myReader, colIndex_SendDestEpCode);
                    wkLogWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, colIndex_SendDestSecCode);
                    wkLogWork.SndRcvCondition = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvCondition);
                    wkLogWork.TempReceiveDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_TempReceiveDiv);
                    wkLogWork.SndRcvErrContents = SqlDataMediator.SqlGetString(myReader, colIndex_SndRcvErrContents);
                    wkLogWork.SndRcvFileID = SqlDataMediator.SqlGetString(myReader, colIndex_SndRcvFileID);

                    wkLogWork.SndLogUseDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndLogUseDiv);
                    wkLogWork.ExtraObjSecCode = SqlDataMediator.SqlGetString(myReader, colIndex_ExtraObjSecCode);
                    wkLogWork.SndObjStartDate = SqlDataMediator.SqlGetInt64(myReader, colIndex_SndObjStartDate);
                    wkLogWork.SndObjEndDate = SqlDataMediator.SqlGetInt64(myReader, colIndex_SndObjEndDate);
                    wkLogWork.SyncExecDate = SqlDataMediator.SqlGetInt64(myReader, colIndex_SyncExecDate);
                    #endregion

                    al.Add(wkLogWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex, "SearchHisProcProc(out ArrayList sndRcvHisWorkList, SndRcvHisConWork sndRcvHisConWork, ref SqlConnection sqlConnection)", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SearchHisProcProc(out ArrayList sndRcvHisWorkList, SndRcvHisConWork sndRcvHisConWork, ref SqlConnection sqlConnection)", status);
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
            }
            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            sndRcvHisWorkList = al;

            return status;
        }

        /// <summary>
        /// 指定された条件の送受信抽出条件履歴ログデータ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="sndRcvHisTableWork">検索パラメータ</param>
        /// <param name="sndRcvEtrWorkSubList">送受信抽出条件履歴ログデータ検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        private int SearchSubHisProcProc(SndRcvHisTableWork sndRcvHisTableWork, out ArrayList sndRcvEtrWorkSubList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SndRcvEtrWork wkLogWork = new SndRcvEtrWork();
            sndRcvEtrWorkSubList = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append(
                    "SELECT " +
                      "CREATEDATETIMERF," +
                      "UPDATEDATETIMERF," +
                      "ENTERPRISECODERF," +
                      "FILEHEADERGUIDRF," +
                      "UPDEMPLOYEECODERF," +
                      "UPDASSEMBLYID1RF," +
                      "UPDASSEMBLYID2RF," +
                      "LOGICALDELETECODERF," +
                      "SECTIONCODERF," +
                      "SNDRCVHISCONSNORF," +
                      "SNDRCVHISCONSDERIVNORF," +
                      "KINDRF," +
                      "FILEIDRF," +
                      "EXTRASTARTDATERF," +
                      "EXTRAENDDATERF," +
                      "STARTCOND1RF," +
                      "ENDCOND1RF," +
                      "STARTCOND2RF," +
                      "ENDCOND2RF," +
                      "STARTCOND3RF," +
                      "ENDCOND3RF," +
                      "STARTCOND4RF," +
                      "ENDCOND4RF," +
                      "STARTCOND5RF," +
                      "ENDCOND5RF," +
                      "STARTCOND6RF," +
                      "ENDCOND6RF," +
                      "STARTCOND7RF," +
                      "ENDCOND7RF," +
                      "STARTCOND8RF," +
                      "ENDCOND8RF," +
                      "STARTCOND9RF," +
                      "ENDCOND9RF," +
                      "STARTCOND10RF," +
                      "ENDCOND10RF " +
                    "FROM SNDRCVETRRF ");
                sqlTxt.Append(MakeWhereStringSub(ref sqlCommand, sndRcvHisTableWork));
                sqlCommand.CommandText = sqlTxt.ToString();

                myReader = sqlCommand.ExecuteReader();

                int colIndex_CreateDateTime = 0;
                int colIndex_UpdateDateTime = 0;
                int colIndex_EnterpriseCode = 0;
                int colIndex_FileHeaderGuid = 0;
                int colIndex_UpdEmployeeCode = 0;
                int colIndex_UpdAssemblyId1 = 0;
                int colIndex_UpdAssemblyId2 = 0;
                int colIndex_LogicalDeleteCode = 0;
                int colIndex_SectionCode = 0;
                int colIndex_SndRcvHisConsNo = 0;
                int colIndex_SndRcvHisConsDerivNo = 0;
                int colIndex_Kind = 0;
                int colIndex_FileId = 0;
                int colIndex_ExtraStartDate = 0;
                int colIndex_ExtraEndDate = 0;
                int colIndex_StartCond1 = 0;
                int colIndex_EndCond1 = 0;
                int colIndex_StartCond2 = 0;
                int colIndex_EndCond2 = 0;
                int colIndex_StartCond3 = 0;
                int colIndex_EndCond3 = 0;
                int colIndex_StartCond4 = 0;
                int colIndex_EndCond4 = 0;
                int colIndex_StartCond5 = 0;
                int colIndex_EndCond5 = 0;
                int colIndex_StartCond6 = 0;
                int colIndex_EndCond6 = 0;
                int colIndex_StartCond7 = 0;
                int colIndex_EndCond7 = 0;
                int colIndex_StartCond8 = 0;
                int colIndex_EndCond8 = 0;
                int colIndex_StartCond9 = 0;
                int colIndex_EndCond9 = 0;
                int colIndex_StartCond10 = 0;
                int colIndex_EndCond10 = 0;

                if (myReader.HasRows)
                {
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                    colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                    colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                    colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                    colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                    colIndex_SndRcvHisConsNo = myReader.GetOrdinal("SNDRCVHISCONSNORF");
                    colIndex_SndRcvHisConsDerivNo = myReader.GetOrdinal("SNDRCVHISCONSDERIVNORF");
                    colIndex_Kind = myReader.GetOrdinal("KINDRF");
                    colIndex_FileId = myReader.GetOrdinal("FILEIDRF");
                    colIndex_ExtraStartDate = myReader.GetOrdinal("EXTRASTARTDATERF");
                    colIndex_ExtraEndDate = myReader.GetOrdinal("EXTRAENDDATERF");
                    colIndex_StartCond1 = myReader.GetOrdinal("STARTCOND1RF");
                    colIndex_EndCond1 = myReader.GetOrdinal("ENDCOND1RF");
                    colIndex_StartCond2 = myReader.GetOrdinal("STARTCOND2RF");
                    colIndex_EndCond2 = myReader.GetOrdinal("ENDCOND2RF");
                    colIndex_StartCond3 = myReader.GetOrdinal("STARTCOND3RF");
                    colIndex_EndCond3 = myReader.GetOrdinal("ENDCOND3RF");
                    colIndex_StartCond4 = myReader.GetOrdinal("STARTCOND4RF");
                    colIndex_EndCond4 = myReader.GetOrdinal("ENDCOND4RF");
                    colIndex_StartCond5 = myReader.GetOrdinal("STARTCOND5RF");
                    colIndex_EndCond5 = myReader.GetOrdinal("ENDCOND5RF");
                    colIndex_StartCond6 = myReader.GetOrdinal("STARTCOND6RF");
                    colIndex_EndCond6 = myReader.GetOrdinal("ENDCOND6RF");
                    colIndex_StartCond7 = myReader.GetOrdinal("STARTCOND7RF");
                    colIndex_EndCond7 = myReader.GetOrdinal("ENDCOND7RF");
                    colIndex_StartCond8 = myReader.GetOrdinal("STARTCOND8RF");
                    colIndex_EndCond8 = myReader.GetOrdinal("ENDCOND8RF");
                    colIndex_StartCond9 = myReader.GetOrdinal("STARTCOND9RF");
                    colIndex_EndCond9 = myReader.GetOrdinal("ENDCOND9RF");
                    colIndex_StartCond10 = myReader.GetOrdinal("STARTCOND10RF");
                    colIndex_EndCond10 = myReader.GetOrdinal("ENDCOND10RF");

                }

                while (myReader.Read())
                {

                    #region クラスへ格納
                    wkLogWork = new SndRcvEtrWork();//ADD 2012/10/16 李亜博 for redmine#31026
                    wkLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    wkLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    wkLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                    wkLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                    wkLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                    wkLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                    wkLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                    wkLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    wkLogWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                    wkLogWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisConsNo);
                    wkLogWork.SndRcvHisConsDerivNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisConsDerivNo);
                    wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, colIndex_Kind);
                    wkLogWork.FileId = SqlDataMediator.SqlGetString(myReader, colIndex_FileId);
                    wkLogWork.ExtraStartDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_ExtraStartDate);
                    wkLogWork.ExtraEndDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_ExtraEndDate);
                    wkLogWork.StartCond1 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond1);
                    wkLogWork.EndCond1 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond1);
                    wkLogWork.StartCond2 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond2);
                    wkLogWork.EndCond2 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond2);
                    wkLogWork.StartCond3 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond3);
                    wkLogWork.EndCond3 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond3);
                    wkLogWork.StartCond4 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond4);
                    wkLogWork.EndCond4 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond4);
                    wkLogWork.StartCond5 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond5);
                    wkLogWork.EndCond5 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond5);
                    wkLogWork.StartCond6 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond6);
                    wkLogWork.EndCond6 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond6);
                    wkLogWork.StartCond7 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond7);
                    wkLogWork.EndCond7 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond7);
                    wkLogWork.StartCond8 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond8);
                    wkLogWork.EndCond8 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond8);
                    wkLogWork.StartCond9 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond9);
                    wkLogWork.EndCond9 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond9);
                    wkLogWork.StartCond10 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond10);
                    wkLogWork.EndCond10 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond10);

                    sndRcvEtrWorkSubList.Add(wkLogWork);
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex, "SearchSubHisProcProc(SndRcvHisTableWork sndRcvHisTableWork, out ArrayList sndRcvEtrWorkSubList, ref SqlConnection sqlConnection)", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SearchSubHisProcProc(SndRcvHisTableWork sndRcvHisTableWork, out ArrayList sndRcvEtrWorkSubList, ref SqlConnection sqlConnection)", status);
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

        # endregion

        # region [Delete]
        /// <summary>
        ///  拠点管理DC送受信履歴情報を物理削除します
        /// </summary>
        /// <remarks>
        /// <param name="paraSndRcvHisConList">削除する送受信履歴データを含むArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理DC送受信履歴のキー値が一致する 拠点管理DC送受信履歴情報を物理削除します。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public int Delete(ref object paraSndRcvHisConList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList delList = paraSndRcvHisConList as ArrayList;

            try
            {
                if (paraSndRcvHisConList == null) return status;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return status;
                }

                sqlConnection.Open();

                //delete実行
                status = this.DeleteProc(delList, ref sqlConnection, ref sqlTransaction);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisConDB.Delete(ref object SndRcvHisConWork)", status);
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
        /// 拠点管理DC送受信履歴情報を物理削除します
        /// </summary>
        /// <remarks>
        /// <param name="delList">拠点管理DC送受信履歴情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理DC送受信履歴情報を物理削除します。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private int DeleteProc(ArrayList delList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                foreach (SndRcvHisTableWork sndRcvHisTableWork in delList)
                {
                    StringBuilder sqlTxt = new StringBuilder();

                    # region [SELECT文]
                    sqlTxt.Append(
                        "SELECT " +
                        "CREATEDATETIMERF," +
                        "UPDATEDATETIMERF," +
                        "ENTERPRISECODERF," +
                        "FILEHEADERGUIDRF," +
                        "UPDEMPLOYEECODERF," +
                        "UPDASSEMBLYID1RF," +
                        "UPDASSEMBLYID2RF," +
                        "LOGICALDELETECODERF," +
                        "SNDRCVHISSNDRCVNORF," +
                        "SECTIONCODERF," +
                        "SNDRCVHISCONSNORF," +
                        "SNDRCVDATETIMERF," +
                        "SENDORRECEIVEDIVCDRF," +
                        "KINDRF," +
                        "SNDLOGEXTRACONDDIVRF," +
                        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        //"PROCSTARTDATETIMERF," +
                        //"PROCENDDATETIMERF," +
                        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        "SENDDESTEPCODERF," +
                        "SENDDESTSECCODERF," +
                        "SNDRCVCONDITIONRF," +
                        "TEMPRECEIVEDIVRF," +
                        "SNDRCVERRCONTENTSRF," +
                        "SNDRCVFILEIDRF" +
                        " FROM SNDRCVHISTABLERF " +
                    "WHERE" +
                    "      ENTERPRISECODERF = @FINDENTERPRISECODE" +
                    "  AND SNDRCVHISSNDRCVNORF = @FINDSNDRCVHISNORF").Append(Environment.NewLine);
                    # endregion
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);
                    sqlCommand.CommandText = sqlTxt.ToString();

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisSndRcvNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISNORF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = sndRcvHisTableWork.EnterpriseCode;
                    findParaSndRcvHisSndRcvNo.Value = sndRcvHisTableWork.SndRcvHisSndRcvNo;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        # region [DELETE文]
                        StringBuilder sqlText1 = new StringBuilder();
                        sqlText1.Append(
                            " DELETE FROM SNDRCVHISTABLERF" +
                            " WHERE ENTERPRISECODERF = @FINDENTERPRISECODE" +
                            " AND SNDRCVHISSNDRCVNORF = @FINDSNDRCVHISNORF").Append(Environment.NewLine);
                        sqlCommand.CommandText = sqlText1.ToString();
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = sndRcvHisTableWork.EnterpriseCode;
                        findParaSndRcvHisSndRcvNo.Value = sndRcvHisTableWork.SndRcvHisSndRcvNo;
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SndRcvHisConDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SndRcvHisConDB.DeleteProc" + status);
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
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → sndRcvHisConWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>sndRcvHisConWork</returns>
        /// <remarks>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        private SndRcvHisConWork CopyToSecMngSetWorkFromReader(ref SqlDataReader myReader)
        {
            SndRcvHisConWork sndRcvHisConWork = new SndRcvHisConWork();

            if (myReader != null && sndRcvHisConWork != null)
            {
                # region クラスへ格納
                sndRcvHisConWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sndRcvHisConWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sndRcvHisConWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sndRcvHisConWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sndRcvHisConWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sndRcvHisConWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sndRcvHisConWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sndRcvHisConWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sndRcvHisConWork.SndRcvHisSndRcvNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISSNDRCVNORF"));
                sndRcvHisConWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                sndRcvHisConWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISCONSNORF"));
                sndRcvHisConWork.SndRcvDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SNDRCVDATETIMERF"));
                sndRcvHisConWork.SendOrReceiveDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDORRECEIVEDIVCDRF"));
                sndRcvHisConWork.Kind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("KINDRF"));
                sndRcvHisConWork.SndLogExtraCondDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDLOGEXTRACONDDIVRF"));
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //sndRcvHisConWork.ProcStartDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROCSTARTDATETIMERF"));
                //sndRcvHisConWork.ProcEndDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROCENDDATETIMERF"));
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                sndRcvHisConWork.SendDestEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTEPCODERF"));
                sndRcvHisConWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
                sndRcvHisConWork.SndRcvCondition = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVCONDITIONRF"));
                sndRcvHisConWork.TempReceiveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TEMPRECEIVEDIVRF"));
                sndRcvHisConWork.SndRcvErrContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SNDRCVERRCONTENTSRF"));
                sndRcvHisConWork.SndRcvFileID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SNDRCVFILEIDRF"));
                # endregion
            }
            return sndRcvHisConWork;
        }
        # endregion

        #region [Privateメソッド作成]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="sndRcvHisConWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// <br>Update Note: 2012/12/18 董桂鈺</br>
        ///	<br>			 Redmine#33961 拠点管理ログ参照ツールにて、
        ///　　　　　　　　　送受信区分に「全て」を指定し検索不正の対応</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SndRcvHisConWork sndRcvHisConWork)
        {

            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append(" WHERE ");

            //論理削除区分
            sqlTxt.Append("HISTAB.LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine); //送受信履歴履歴データ
            //sqlTxt.Append("AND HIS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine);  //送受信履歴ログデータ//DEL 2012/10/16 李亜博 for redmine#31026
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            if (sndRcvHisConWork != null)
            {
                if (sndRcvHisConWork.SendOrReceiveDivCd == 0)
                {
                    //パラメータ.企業コードがEmptyではない場合
                    if (sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals(""))
                    {
                        //企業コード
                        sqlTxt.Append("AND HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                    }
                    //パラメータ.拠点コードがEmptyではない場合
                    if (!sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00"))
                    {
                        //拠点コード
                        sqlTxt.Append("AND HISTAB.SECTIONCODERF = @FINDSECTIONCODE").Append(Environment.NewLine);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                }
                if (sndRcvHisConWork.SendOrReceiveDivCd == 1)
                {
                    //検索条件パラメータに送信先企業コード指定の時
                    if (sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals(""))
                    {
                        //送信先企業コード
                        sqlTxt.Append("AND HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE").Append(Environment.NewLine);
                        SqlParameter findParaSendDestEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
                        findParaSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                    }
                    if (!sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00"))
                    {
                        //送信先拠点コード
                        sqlTxt.Append("AND HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE").Append(Environment.NewLine);
                        SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
                        findParaSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                }

                //送受信区分
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                    //sqlTxt.Append("AND HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVCD").Append(Environment.NewLine);
                    //SqlParameter findParaSendOrReceiveDivCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVCD", SqlDbType.Int);
                    //findParaSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisConWork.SendOrReceiveDivCd);
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026---->>>>>
                if (sndRcvHisConWork.SendOrReceiveDivCd != 2)
                {
                    if (sndRcvHisConWork.SendOrReceiveDivCd == 0)
                    {
                        //送信処理（開始）
                        sqlTxt.Append("AND ( HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVSTRCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivStrCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVSTRCD", SqlDbType.Int);
                        findParaSendOrReceiveDivStrCd.Value = SqlDataMediator.SqlSetInt32(0);
                        //送信処理（終了）
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVENDCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivEndCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVENDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivEndCd.Value = SqlDataMediator.SqlSetInt32(1);
                        //送信処理（送受信履歴更新）
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVUPDCD )").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivUpdCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVUPDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivUpdCd.Value = SqlDataMediator.SqlSetInt32(2);
                    }
                    else if (sndRcvHisConWork.SendOrReceiveDivCd == 1)
                    {
                        //受信処理（開始）
                        sqlTxt.Append("AND ( HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVSTRCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivStrCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVSTRCD", SqlDbType.Int);
                        findParaSendOrReceiveDivStrCd.Value = SqlDataMediator.SqlSetInt32(3);
                        //受信処理（終了）
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVENDCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivEndCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVENDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivEndCd.Value = SqlDataMediator.SqlSetInt32(4);
                        //受信処理（送受信履歴更新）
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVUPDCD )").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivUpdCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVUPDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivUpdCd.Value = SqlDataMediator.SqlSetInt32(5);

                    }
                }
                else
                {
                    if (sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00"))
                    {
                        //パラメータ.企業コードがEmptyではない、パラメータ.拠点コードがEmptyではない場合
                        //企業コード
                        //sqlTxt.Append("AND (HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//DEL 董桂鈺 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND ((HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//ADD 董桂鈺 2012/12/18 for Redmine#33961
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                        //拠点コード
                        sqlTxt.Append("AND HISTAB.SECTIONCODERF = @FINDSECTIONCODE) ").Append(Environment.NewLine);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                        //送信先企業コード
                        sqlTxt.Append("OR (HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE ").Append(Environment.NewLine);
                        SqlParameter findParaSendDestEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
                        findParaSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                        //送信先拠点コード
                        //sqlTxt.Append("AND HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE) ").Append(Environment.NewLine);//DEL 董桂鈺 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE)) ").Append(Environment.NewLine);//ADD 董桂鈺 2012/12/18 for Redmine#33961
                        SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
                        findParaSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                    else if ((sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals("")) && (sndRcvHisConWork.SectionCode.Trim().Equals("") || sndRcvHisConWork.SectionCode.Trim().Equals("00")))
                    {
                        //パラメータ.企業コードがEmptyではない、パラメータ.拠点コードがEmpty場合
                        //企業コード
                        //sqlTxt.Append("AND HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//DEL 董桂鈺 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND ( HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//ADD 董桂鈺 2012/12/18 for Redmine#33961
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                        //送信先企業コード
                        //sqlTxt.Append("OR HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE ").Append(Environment.NewLine);//DEL 董桂鈺 2012/12/18 for Redmine#33961
                        sqlTxt.Append("OR HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE )").Append(Environment.NewLine);//ADD 董桂鈺 2012/12/18 for Redmine#33961
                        SqlParameter findParaSendDestEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
                        findParaSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                    }
                    else if ((sndRcvHisConWork.EnterpriseCode == null || sndRcvHisConWork.EnterpriseCode.Trim().Equals("")) && (!sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00")))
                    {
                        //パラメータ.企業コードがEmpty、パラメータ.拠点コードがEmptyではない場合
                        //拠点コード
                        //sqlTxt.Append("AND HISTAB.SECTIONCODERF = @FINDSECTIONCODE ").Append(Environment.NewLine);//DEL 董桂鈺 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND ( HISTAB.SECTIONCODERF = @FINDSECTIONCODE ").Append(Environment.NewLine);//ADD 董桂鈺 2012/12/18 for Redmine#33961
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                        //送信先拠点コード
                        //sqlTxt.Append("OR HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE ").Append(Environment.NewLine);//DEL 董桂鈺 2012/12/18 for Redmine#33961
                        sqlTxt.Append("OR HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE )").Append(Environment.NewLine);//ADD 董桂鈺 2012/12/18 for Redmine#33961
                        SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
                        findParaSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                }
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

                //パラメータ.送受信日(開始)>0の場合条件を追加
                if (sndRcvHisConWork.SndRcvStartDateTime > 0)
                {
                    //送受信日>=検索条件パラメータで指定された送受信日(開始)
                    sqlTxt.Append("AND HISTAB.SNDRCVDATETIMERF >= @FINDPROCSTARTDATETIME").Append(Environment.NewLine);
                    SqlParameter findParaSndRcvDateTime = sqlCommand.Parameters.Add("@FINDPROCSTARTDATETIME", SqlDbType.BigInt);
                    findParaSndRcvDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisConWork.SndRcvStartDateTime);
                }

                //パラメータ.送受信日(終了)>0の場合条件を追加
                if (sndRcvHisConWork.SndRcvEndDateTime > 0)
                {
                    //送受信日<=検索条件パラメータで指定された送受信日(終了)
                    sqlTxt.Append("AND HISTAB.SNDRCVDATETIMERF <= @FINDPROCENDDATETIME").Append(Environment.NewLine);
                    SqlParameter findParaSndRcvDateTime = sqlCommand.Parameters.Add("@FINDPROCENDDATETIME", SqlDbType.BigInt);
                    findParaSndRcvDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisConWork.SndRcvEndDateTime);
                }
            }
            //sqlTxt.Append(" ORDER BY HISTAB.ENTERPRISECODERF, HISTAB.SECTIONCODERF, HISTAB.SNDRCVHISCONSNORF ").Append(Environment.NewLine);//DEL 2012/10/16 李亜博 for redmine#31026
            sqlTxt.Append(" ORDER BY HISTAB.ENTERPRISECODERF, HISTAB.SNDRCVHISSNDRCVNORF ").Append(Environment.NewLine);//ADD 2012/10/16 李亜博 for redmine#31026

            return sqlTxt.ToString();
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="sndRcvHisTableWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/07/23</br>
        private string MakeWhereStringSub(ref SqlCommand sqlCommand, SndRcvHisTableWork sndRcvHisTableWork)
        {

            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append(" WHERE ");

            //企業コード
            sqlTxt.Append("ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.EnterpriseCode);

            //論理削除区分
            sqlTxt.Append("AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //拠点コード
            sqlTxt.Append("AND SECTIONCODERF = @SECTIONCODE").Append(Environment.NewLine);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SectionCode);

            //送受信履歴ログ送信番号
            sqlTxt.Append("AND SNDRCVHISCONSNORF = @SNDRCVHISCONSNO").Append(Environment.NewLine);
            SqlParameter parSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
            parSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvHisConsNo);

            return sqlTxt.ToString();
        }

        #endregion
    }
}
