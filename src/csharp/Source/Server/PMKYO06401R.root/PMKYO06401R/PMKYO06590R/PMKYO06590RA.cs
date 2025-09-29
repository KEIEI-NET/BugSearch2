//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/09  修正内容 : マスタ送受信不備対応について 
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : FSI上北田 秀樹
// 修 正 日  2012/07/26  修正内容 : 拠点管理 抽出条件追加対応
//----------------------------------------------------------------------------//

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
    /// 結合マスタ（ユーザー登録分）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタ（ユーザー登録分）データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCJoinPartsUDB : RemoteDB
    {
        #region [Private]
        // --- ADD 2012/07/26 ----------->>>>>
        private int _createDateTime = 0;
        private int _updateDateTime = 0;
        private int _enterpriseCode = 0;
        private int _fileHeaderGuid = 0;
        private int _updEmployeeCode = 0;
        private int _updAssemblyId1 = 0;
        private int _updAssemblyId2 = 0;
        private int _logicalDeleteCode = 0;
        private int _joinDispOrder = 0;
        private int _joinSourceMakerCode = 0;
        private int _joinSourPartsNoWithH = 0;
        private int _joinSourPartsNoNoneH = 0;
        private int _joinDestMakerCd = 0;
        private int _joinDestPartsNo = 0;
        private int _joinQty = 0;
        private int _joinSpecialNote = 0;
        // --- ADD 2012/07/26 -----------<<<<<
        #endregion

        /// <summary>
        /// 結合マスタ（ユーザー登録分）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCJoinPartsUDB()
            : base("PMKYO06591D", "Broadleaf.Application.Remoting.ParamData.DCJoinPartsUWork", "JOINPARTSURF")
        {

        }

        #region [Read]
        /// <summary>
        /// 結合マスタ（ユーザー登録分）の検索処理（日付指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="joinPartsUArrList">結合マスタ（ユーザー登録分）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public int SearchJoinPartsU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            return SearchJoinPartsUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                               sqlTransaction, out joinPartsUArrList, out retMessage);
        }
        /// <summary>
        /// 結合マスタ（ユーザー登録分）の検索処理（日付指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="joinPartsUArrList">結合マスタ（ユーザー登録分）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private int SearchJoinPartsUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            joinPartsUArrList = new ArrayList();
            DCJoinPartsUWork joinPartsUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF FROM JOINPARTSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //結合マスタ（ユーザー登録分）データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    joinPartsUWork = new DCJoinPartsUWork();

                    joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                    joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    joinPartsUArrList.Add(joinPartsUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCJoinPartsUDB.SearchJoinPartsU Exception=" + ex.Message);
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
        ///  結合マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="dcJoinPartsUWork">結合マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  結合マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="dcJoinPartsUWork">結合マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM JOINPARTSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH ";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
            SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
            // DEL 2009/06/09 --->>>
            //SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
            //SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
            // DEL 2009/06/09 ---<<<
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcJoinPartsUWork.EnterpriseCode;
            findParaJoinSourceMakerCode.Value = dcJoinPartsUWork.JoinSourceMakerCode;
            findParaJoinSourPartsNoWithH.Value = dcJoinPartsUWork.JoinSourPartsNoWithH;
            // DEL 2009/06/09 --->>>
            //findParaJoinDestMakerCd.Value = dcJoinPartsUWork.JoinDestMakerCd;
            //findParaJoinDestPartsNo.Value = dcJoinPartsUWork.JoinDestPartsNo;
            // DEL 2009/06/09 ---<<<

            // 結合マスタ（ユーザー登録分）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 結合マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="dcJoinPartsUWork">結合マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 結合マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="dcJoinPartsUWork">結合マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCJoinPartsUWork dcJoinPartsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO JOINPARTSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @JOINDISPORDER, @JOINSOURCEMAKERCODE, @JOINSOURPARTSNOWITHH, @JOINSOURPARTSNONONEH, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @JOINSPECIALNOTE)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraJoinDispOrder = sqlCommand.Parameters.Add("@JOINDISPORDER", SqlDbType.Int);
            SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODE", SqlDbType.Int);
            SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
            SqlParameter paraJoinSourPartsNoNoneH = sqlCommand.Parameters.Add("@JOINSOURPARTSNONONEH", SqlDbType.NVarChar);
            SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
            SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
            SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
            SqlParameter paraJoinSpecialNote = sqlCommand.Parameters.Add("@JOINSPECIALNOTE", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcJoinPartsUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcJoinPartsUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcJoinPartsUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.LogicalDeleteCode);
            paraJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.JoinDispOrder);
            paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.JoinSourceMakerCode);
            if (string.IsNullOrEmpty(dcJoinPartsUWork.JoinSourPartsNoWithH.Trim()))
            {
                paraJoinSourPartsNoWithH.Value = dcJoinPartsUWork.JoinSourPartsNoWithH;
            }
            else
            {
                paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinSourPartsNoWithH);
            }
            if (string.IsNullOrEmpty(dcJoinPartsUWork.JoinSourPartsNoNoneH.Trim()))
            {
                paraJoinSourPartsNoNoneH.Value = dcJoinPartsUWork.JoinSourPartsNoNoneH;
            }
            else
            {
                paraJoinSourPartsNoNoneH.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinSourPartsNoNoneH);
            }
            paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(dcJoinPartsUWork.JoinDestMakerCd);
            if (string.IsNullOrEmpty(dcJoinPartsUWork.JoinDestPartsNo.Trim()))
            {
                paraJoinDestPartsNo.Value = dcJoinPartsUWork.JoinDestPartsNo;
            }
            else
            {
                paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinDestPartsNo);
            }
            paraJoinQty.Value = SqlDataMediator.SqlSetDouble(dcJoinPartsUWork.JoinQty);
            paraJoinSpecialNote.Value = SqlDataMediator.SqlSetString(dcJoinPartsUWork.JoinSpecialNote);

            // 結合マスタ（ユーザー登録分）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region [Read][拠点管理 抽出条件追加対応]
        // --- ADD 2012/07/26 ------------------------------------->>>>>
        /// <summary>
        /// 結合マスタ（ユーザー登録分）の検索処理（コード指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="joinPartsUArrList">結合マスタ（ユーザー登録分）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データREADLISTを全て戻します</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchJoinPartsU(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            return SearchJoinPartsUProc(enterpriseCodes, paramList, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
        }

        /// <summary>
        /// 結合マスタ（ユーザー登録分）の検索処理（コード指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="joinPartsUArrList">結合マスタ（ユーザー登録分）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データREADLISTを全て戻します</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchJoinPartsUProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList joinPartsUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            joinPartsUArrList = new ArrayList();
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            JoinPartsUProcParamWork param = paramList as JoinPartsUProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr.AppendLine("SELECT");
                sqlStr.AppendLine("    CREATEDATETIMERF, -- 作成日時");
                sqlStr.AppendLine("    UPDATEDATETIMERF, -- 更新日時");
                sqlStr.AppendLine("    ENTERPRISECODERF, -- 企業コード");
                sqlStr.AppendLine("    FILEHEADERGUIDRF, -- GUID");
                sqlStr.AppendLine("    UPDEMPLOYEECODERF, -- 更新従業員コード");
                sqlStr.AppendLine("    UPDASSEMBLYID1RF, -- 更新アセンブリID1");
                sqlStr.AppendLine("    UPDASSEMBLYID2RF, -- 更新アセンブリID2");
                sqlStr.AppendLine("    LOGICALDELETECODERF, -- 論理削除区分");
                sqlStr.AppendLine("    JOINDISPORDERRF, -- 結合表示順位");
                sqlStr.AppendLine("    JOINSOURCEMAKERCODERF, -- 結合元メーカーコード");
                sqlStr.AppendLine("    JOINSOURPARTSNOWITHHRF, -- 結合元品番(－付き品番)");
                sqlStr.AppendLine("    JOINSOURPARTSNONONEHRF, -- 結合元品番(－無し品番)");
                sqlStr.AppendLine("    JOINDESTMAKERCDRF, -- 結合先メーカーコード");
                sqlStr.AppendLine("    JOINDESTPARTSNORF, -- 結合先品番(－付き品番)");
                sqlStr.AppendLine("    JOINQTYRF, -- 結合QTY");
                sqlStr.AppendLine("    JOINSPECIALNOTERF -- 結合規格・特記事項");
                sqlStr.AppendLine("FROM");
                sqlStr.AppendLine("    JOINPARTSURF");

                #region WHERE
                sqlStr.AppendLine("WHERE");
                sqlStr.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");

                // 開始日時
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }

                // 終了日時
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }

                // 結合元品番
                if (!string.IsNullOrEmpty(param.JoinSourPartsNoWithHBeginRF))
                {
                    sqlStr.Append(" AND JOINSOURPARTSNOWITHHRF >= @JOINSOURPARTSNOWITHHBEGINRF");
                    SqlParameter joinSourPartsNoWithHBeginRF = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHHBEGINRF", SqlDbType.NVarChar);
                    joinSourPartsNoWithHBeginRF.Value = SqlDataMediator.SqlSetString(param.JoinSourPartsNoWithHBeginRF);
                }

                if (!string.IsNullOrEmpty(param.JoinSourPartsNoWithHEndRF))
                {
                    sqlStr.Append(" AND JOINSOURPARTSNOWITHHRF <= @JOINSOURPARTSNOWITHHENDRF");
                    SqlParameter joinSourPartsNoWithHEndRF = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHHENDRF", SqlDbType.NVarChar);
                    joinSourPartsNoWithHEndRF.Value = SqlDataMediator.SqlSetString(param.JoinSourPartsNoWithHEndRF);
                }

                // 結合元メーカーコード
                if (param.JoinSourceMakerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND JOINSOURCEMAKERCODERF >= @JOINSOURCEMAKERCODEBEGINRF");
                    SqlParameter joinSourceMakerCodeBeginRF = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODEBEGINRF", SqlDbType.Int);
                    joinSourceMakerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.JoinSourceMakerCodeBeginRF);
                }

                if (param.JoinSourceMakerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND JOINSOURCEMAKERCODERF <= @JOINSOURCEMAKERCODEENDRF");
                    SqlParameter joinSourceMakerCodeEndRF = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODEENDRF", SqlDbType.Int);
                    joinSourceMakerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.JoinSourceMakerCodeEndRF);
                }

                // 結合表示順位
                if (param.JoinDispOrderBeginRF != 0)
                {
                    sqlStr.Append(" AND JOINDISPORDERRF >= @JOINDISPORDERBEGINRF");
                    SqlParameter joinDispOrderBeginRF = sqlCommand.Parameters.Add("@JOINDISPORDERBEGINRF", SqlDbType.Int);
                    joinDispOrderBeginRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDispOrderBeginRF);
                }

                if (param.JoinDispOrderEndRF != 0)
                {
                    sqlStr.Append(" AND JOINDISPORDERRF <= @JOINDISPORDERENDRF");
                    SqlParameter joinSourceMakerCodeEndRF = sqlCommand.Parameters.Add("@JOINDISPORDERENDRF", SqlDbType.Int);
                    joinSourceMakerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDispOrderEndRF);
                }

                // 結合先メーカーコード
                if (param.JoinDestMakerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND JOINDESTMAKERCDRF >= @JOINDESTMAKERCODEBEGINRF");
                    SqlParameter joinDestMakerCodeBeginRF = sqlCommand.Parameters.Add("@JOINDESTMAKERCODEBEGINRF", SqlDbType.Int);
                    joinDestMakerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDestMakerCodeBeginRF);
                }

                if (param.JoinDestMakerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND JOINDESTMAKERCDRF <= @JOINDESTMAKERCODEENDRF");
                    SqlParameter joinDestMakerCodeEndRF = sqlCommand.Parameters.Add("@JOINDESTMAKERCODEENDRF", SqlDbType.Int);
                    joinDestMakerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.JoinDestMakerCodeEndRF);
                }

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                #endregion WHERE

                // 結合マスタ（ユーザー登録分）マスタデータ用SQL
                sqlCommand.CommandText = sqlStr.ToString();
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }

                while (myReader.Read())
                {
                    joinPartsUArrList.Add(CopyFromMyReaderToDCJoinPartsUWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCJoinPartsUDB.SearchJoinPartsU Exception=" + ex.Message);
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
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _createDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _updateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _enterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _fileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _updEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _updAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _updAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _logicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _joinDispOrder = myReader.GetOrdinal("JOINDISPORDERRF");
            _joinSourceMakerCode = myReader.GetOrdinal("JOINSOURCEMAKERCODERF");
            _joinSourPartsNoWithH = myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF");
            _joinSourPartsNoNoneH = myReader.GetOrdinal("JOINSOURPARTSNONONEHRF");
            _joinDestMakerCd = myReader.GetOrdinal("JOINDESTMAKERCDRF");
            _joinDestPartsNo = myReader.GetOrdinal("JOINDESTPARTSNORF");
            _joinQty = myReader.GetOrdinal("JOINQTYRF");
            _joinSpecialNote = myReader.GetOrdinal("JOINSPECIALNOTERF");
        }

        /// <summary>
        /// 結合マスタ（ユーザー登録分）データを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>結合マスタ（ユーザー登録分）データ</returns>
        /// <br>Note       : 結合マスタ（ユーザー登録分）データを戻します</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/07/26</br>
        /// 
        private DCJoinPartsUWork CopyFromMyReaderToDCJoinPartsUWork(SqlDataReader myReader)
        {
            DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();

            joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, _joinDispOrder);
            joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, _joinSourceMakerCode);
            joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, _joinSourPartsNoWithH);
            joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, _joinSourPartsNoNoneH);
            joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, _joinDestMakerCd);
            joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, _joinDestPartsNo);
            joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, _joinQty);
            joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, _joinSpecialNote);

            return joinPartsUWork;
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
        //    sqlCommand.CommandText = "DELETE FROM JOINPARTSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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