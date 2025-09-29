//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信処理                          　　  //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06510R.DLL							        //
// Programmer       :   呉元嘯	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2009.06.12　							//
//                  :   public MethodでSQL文字が駄目対応について        //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2011.08.26　							//
//                  :   DC履歴ログとDC各データのクリア処理を追加        //
//----------------------------------------------------------------------//
// Update Note      :   FSI東 隆史　2012.07.26　						//
//                  :   拠点管理 抽出条件追加対応                       //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ユーザーガイドマスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザーガイドマスタデータの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCUserGdBdUDB : RemoteDB
    {
        #region [Private]
        // --- ADD 2012/07/26 -------->>>>>
        private int _CreateDateTime = 0;
        private int _UpdateDateTime = 0;
        private int _EnterpriseCode = 0;
        private int _FileHeaderGuid = 0;
        private int _UpdEmployeeCode = 0;
        private int _UpdAssemblyId1 = 0;
        private int _UpdAssemblyId2 = 0;
        private int _LogicalDeleteCode = 0;
        private int _UserGuideDivCd = 0;
        private int _GuideCode = 0;
        private int _GuideName = 0;
        private int _GuideType = 0;
        // --- ADD 2012/07/26 --------<<<<<
        #endregion

        /// <summary>
        /// ユーザーガイドマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCUserGdBdUDB()
            : base("PMKYO06511D", "Broadleaf.Application.Remoting.ParamData.DCUserGdBdUWork", "USERGDBDURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ユーザーガイドマスタの検索処理（日付指定）
        /// </summary>
        /// <param name="kubun">区分</param>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="userGdBdUArrList">ユーザーガイドマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザーガイドマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public int SearchUserGdBdU(Int32 kubun, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, ref ArrayList userGdBdUArrList, out string retMessage)
        {
            return SearchUserGdBdUProc(kubun, enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                    sqlTransaction, ref userGdBdUArrList, out retMessage);
        }
        /// <summary>
        /// ユーザーガイドマスタの検索処理（日付指定）
        /// </summary>
        /// <param name="kubun">区分</param>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="userGdBdUArrList">ユーザーガイドマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザーガイドマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private int SearchUserGdBdUProc(Int32 kubun, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, ref ArrayList userGdBdUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            DCUserGdBdUWork userGdBdUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, GUIDECODERF, GUIDENAMERF, GUIDETYPERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCDRF AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCDRF", SqlDbType.Int);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(kubun);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //ユーザーガイドマスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    userGdBdUWork = new DCUserGdBdUWork();

                    userGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    userGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    userGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    userGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    userGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    userGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    userGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    userGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    userGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    userGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    userGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    userGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    userGdBdUArrList.Add(userGdBdUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCUserGdBdUDB.SearchUserGdBdU Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        # region [Delete]
        /// <summary>
        ///  ユーザーガイドマスタデータ削除
        /// </summary>
        /// <param name="dcUserGdBdUWork">ユーザーガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : ユーザーガイドマスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcUserGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ユーザーガイドマスタデータ削除
        /// </summary>
        /// <param name="dcUserGdBdUWork">ユーザーガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : ユーザーガイドマスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
            SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcUserGdBdUWork.EnterpriseCode;
            findParaUserGuideDivCd.Value = dcUserGdBdUWork.UserGuideDivCd;
            findParaGuideCode.Value = dcUserGdBdUWork.GuideCode;


            // ユーザーガイドマスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ユーザーガイドマスタ登録
        /// </summary>
        /// <param name="dcUserGdBdUWork">ユーザーガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : ユーザーガイドマスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcUserGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ユーザーガイドマスタ登録
        /// </summary>
        /// <param name="dcUserGdBdUWork">ユーザーガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : ユーザーガイドマスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCUserGdBdUWork dcUserGdBdUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO USERGDBDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, GUIDECODERF, GUIDENAMERF, GUIDETYPERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @USERGUIDEDIVCD, @GUIDECODE, @GUIDENAME, @GUIDETYPE)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@GUIDECODE", SqlDbType.Int);
            SqlParameter paraGuideName = sqlCommand.Parameters.Add("@GUIDENAME", SqlDbType.NVarChar);
            SqlParameter paraGuideType = sqlCommand.Parameters.Add("@GUIDETYPE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcUserGdBdUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcUserGdBdUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcUserGdBdUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.LogicalDeleteCode);
            paraUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.UserGuideDivCd);
            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.GuideCode);
            paraGuideName.Value = SqlDataMediator.SqlSetString(dcUserGdBdUWork.GuideName);
            paraGuideType.Value = SqlDataMediator.SqlSetInt32(dcUserGdBdUWork.GuideType);

            // ユーザーガイドマスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region [Read][拠点管理 抽出条件追加対応]
        // --- ADD 2012/07/26 ------------------------------------->>>>>
        /// <summary>
        /// ユーザーガイドマスタの検索処理（コード指定）
        /// </summary>
        /// <param name="kubun">ユーザーガイド区分</param>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="userGdBdUArrList">ユーザーガイドマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザーガイドマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchUserGdBdU(Int32 kubun, string enterpriseCodes, object paramList, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList userGdBdUArrList, out string retMessage)
        {
            return SearchUserGdBdUProc(kubun, enterpriseCodes, paramList, sqlConnection,
                             sqlTransaction, out userGdBdUArrList, out retMessage);
        }

        /// <summary>
        /// ユーザーガイドマスタの検索処理（コード指定）
        /// </summary>
        /// <param name="kubun">ユーザーガイド区分</param>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="userGdBdUArrList">ユーザーガイドマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザーガイドマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        private int SearchUserGdBdUProc(Int32 kubun, string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList userGdBdUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            userGdBdUArrList = new ArrayList();
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr.AppendLine("SELECT");
                sqlStr.AppendLine("    CREATEDATETIMERF,");
                sqlStr.AppendLine("    UPDATEDATETIMERF,");
                sqlStr.AppendLine("    ENTERPRISECODERF,");
                sqlStr.AppendLine("    FILEHEADERGUIDRF,");
                sqlStr.AppendLine("    UPDEMPLOYEECODERF,");
                sqlStr.AppendLine("    UPDASSEMBLYID1RF,");
                sqlStr.AppendLine("    UPDASSEMBLYID2RF,");
                sqlStr.AppendLine("    LOGICALDELETECODERF,");
                sqlStr.AppendLine("    USERGUIDEDIVCDRF,");
                sqlStr.AppendLine("    GUIDECODERF,");
                sqlStr.AppendLine("    GUIDENAMERF,");
                sqlStr.AppendLine("    GUIDETYPERF");
                sqlStr.AppendLine("FROM");
                sqlStr.AppendLine("    USERGDBDURF");
                sqlStr.AppendLine("WHERE");
                sqlStr.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlStr.AppendLine("    AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCDRF");

                if (kubun == 71)
                {
                    // 販売区分
                    UserGdBuyDivUProcParamWork param = paramList as UserGdBuyDivUProcParamWork;

                    if (param.UpdateDateTimeBegin != 0)
                    {
                        sqlStr.AppendLine("    AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                    }

                    if (param.UpdateDateTimeEnd != 0)
                    {
                        sqlStr.AppendLine("    AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                    }

                    // ガイドコード
                    if (param.GuideCodeBeginRF != 0)
                    {
                        sqlStr.AppendLine("    AND GUIDECODERF >= @GUIDECODEBEGINRF");
                        SqlParameter guideCodeBeginRF = sqlCommand.Parameters.Add("@GUIDECODEBEGINRF", SqlDbType.Int);
                        guideCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GuideCodeBeginRF);
                    }

                    if (param.GuideCodeEndRF != 0)
                    {
                        sqlStr.AppendLine("    AND GUIDECODERF <= @GUIDECODEENDRF");
                        SqlParameter guideCodeEndRF = sqlCommand.Parameters.Add("@GUIDECODEENDRF", SqlDbType.Int);
                        guideCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.GuideCodeEndRF);
                    }
                }
                else
                {
                    // 検索処理は実行しない
                    return status;
                }


                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCDRF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(kubun);

                //ユーザーガイドマスタデータ用SQL
                sqlCommand.CommandText = sqlStr.ToString();
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }

                while (myReader.Read())
                {
                    userGdBdUArrList.Add(CopyFromMyReaderToDCUserGdBdUWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCUserGdBdUDB.SearchUserGdBdU Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// インデックス格納処理
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : カラムインデックス格納処理を行う</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _UserGuideDivCd = myReader.GetOrdinal("USERGUIDEDIVCDRF");
            _GuideCode = myReader.GetOrdinal("GUIDECODERF");
            _GuideName = myReader.GetOrdinal("GUIDENAMERF");
            _GuideType = myReader.GetOrdinal("GUIDETYPERF");
        }

        /// <summary>
        /// ユーザーガイドマスタデータを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ユーザーガイドマスタデータ</returns>
        /// <br>Note       : ユーザーガイドマスタデータを戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : K2012/07/02</br>
        private DCUserGdBdUWork CopyFromMyReaderToDCUserGdBdUWork(SqlDataReader myReader)
        {
            DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();

            userGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _CreateDateTime);
            userGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _UpdateDateTime);
            userGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _EnterpriseCode);
            userGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _FileHeaderGuid);
            userGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _UpdEmployeeCode);
            userGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _UpdAssemblyId1);
            userGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _UpdAssemblyId2);
            userGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _LogicalDeleteCode);
            userGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, _UserGuideDivCd);
            userGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, _GuideCode);
            userGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader, _GuideName);
            userGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, _GuideType);

            return userGdBdUWork;
        }
        // --- ADD 2012/07/26 -------------------------------------<<<<<
        #endregion

        // ADD 2011.08.26 ---------->>>>>
        # region [Clear]DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// Rクラスの MethodでSQL文字が駄目
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //}
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Deleteコマンドの生成
        //    sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
        //    //Prameterオブジェクトの作成
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    //Parameterオブジェクトへ値設定
        //    findParaEnterpriseCode.Value = enterpriseCode;

        //    // 拠点情報設定マスタデータを削除する
        //    sqlCommand.ExecuteNonQuery();
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
        #endregion
        // ADD 2011.08.26 ----------<<<<<
    }
}