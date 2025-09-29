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
    /// TBO検索マスタ（ユーザー登録分）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索マスタ（ユーザー登録分）データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCTBOSearchUDB : RemoteDB
    {
        /// <summary>
        /// TBO検索マスタ（ユーザー登録分）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCTBOSearchUDB()
            : base("PMKYO06601D", "Broadleaf.Application.Remoting.ParamData.DCTBOSearchUWork", "TBOSEARCHURF")
        {

        }

        #region [Read]
        /// <summary>
        /// TBO検索マスタ（ユーザー登録）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="tBOSearchUArrList">TBO検索マスタ（ユーザー登録）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ（ユーザー登録）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchTBOSearchU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList tBOSearchUArrList, out string retMessage)
        {
            return SearchTBOSearchUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                           sqlTransaction, out tBOSearchUArrList, out retMessage);
        }
        /// <summary>
        /// TBO検索マスタ（ユーザー登録）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="tBOSearchUArrList">TBO検索マスタ（ユーザー登録）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ（ユーザー登録）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchTBOSearchUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList tBOSearchUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            tBOSearchUArrList = new ArrayList();
            DCTBOSearchUWork tBOSearchUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGOODSCODERF, EQUIPGENRECODERF, EQUIPNAMERF, CARINFOJOINDISPORDERRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, EQUIPSPECIALNOTERF FROM TBOSEARCHURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //TBO検索マスタ（ユーザー登録）データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tBOSearchUWork = new DCTBOSearchUWork();

                    tBOSearchUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    tBOSearchUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    tBOSearchUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    tBOSearchUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    tBOSearchUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    tBOSearchUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    tBOSearchUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    tBOSearchUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    tBOSearchUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    tBOSearchUWork.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                    tBOSearchUWork.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));
                    tBOSearchUWork.CarInfoJoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINFOJOINDISPORDERRF"));
                    tBOSearchUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    tBOSearchUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    tBOSearchUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    tBOSearchUWork.EquipSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPSPECIALNOTERF"));

                    tBOSearchUArrList.Add(tBOSearchUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCTBOSearchUDB.SearchTBOSearchU Exception=" + ex.Message);
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
        ///  TBO検索マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="dcTBOSearchUWork">TBO検索マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : TBO検索マスタ（ユーザー登録）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCTBOSearchUWork dcTBOSearchUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  TBO検索マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="dcTBOSearchUWork">TBO検索マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : TBO検索マスタ（ユーザー登録）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCTBOSearchUWork dcTBOSearchUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM TBOSEARCHURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE AND EQUIPNAMERF=@FINDEQUIPNAME ";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
            SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
            // DEL 2009/06/09 --->>>
            //SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
            //SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
            // DEL 2009/06/09 ---<<<
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcTBOSearchUWork.EnterpriseCode;
            findParaEquipGenreCode.Value = dcTBOSearchUWork.EquipGenreCode;
            findParaEquipName.Value = dcTBOSearchUWork.EquipName;
            // DEL 2009/06/09 --->>>
            //findParaJoinDestMakerCd.Value = dcTBOSearchUWork.JoinDestMakerCd;
            //findParaJoinDestPartsNo.Value = dcTBOSearchUWork.JoinDestPartsNo;
            // DEL 2009/06/09 ---<<<

            // TBO検索マスタ（ユーザー登録分）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// TBO検索マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="dcTBOSearchUWork">TBO検索マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : TBO検索マスタ（ユーザー登録）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCTBOSearchUWork dcTBOSearchUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// TBO検索マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="dcTBOSearchUWork">TBO検索マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : TBO検索マスタ（ユーザー登録）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCTBOSearchUWork dcTBOSearchUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO TBOSEARCHURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGOODSCODERF, EQUIPGENRECODERF, EQUIPNAMERF, CARINFOJOINDISPORDERRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, EQUIPSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BLGOODSCODE, @EQUIPGENRECODE, @EQUIPNAME, @CARINFOJOINDISPORDER, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @EQUIPSPECIALNOTE)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraEquipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);
            SqlParameter paraEquipName = sqlCommand.Parameters.Add("@EQUIPNAME", SqlDbType.NVarChar);
            SqlParameter paraCarInfoJoinDispOrder = sqlCommand.Parameters.Add("@CARINFOJOINDISPORDER", SqlDbType.Int);
            SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
            SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
            SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
            SqlParameter paraEquipSpecialNote = sqlCommand.Parameters.Add("@EQUIPSPECIALNOTE", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcTBOSearchUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcTBOSearchUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcTBOSearchUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcTBOSearchUWork.LogicalDeleteCode);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcTBOSearchUWork.BLGoodsCode);
            paraEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(dcTBOSearchUWork.EquipGenreCode);
            if (string.IsNullOrEmpty(dcTBOSearchUWork.EquipName.Trim()))
            {
                paraEquipName.Value = dcTBOSearchUWork.EquipName;
            }
            else
            {
                paraEquipName.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.EquipName);
            }
            paraCarInfoJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(dcTBOSearchUWork.CarInfoJoinDispOrder);
            paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(dcTBOSearchUWork.JoinDestMakerCd);
            if (string.IsNullOrEmpty(dcTBOSearchUWork.JoinDestPartsNo.Trim()))
            {
                paraJoinDestPartsNo.Value = dcTBOSearchUWork.JoinDestPartsNo;
            }
            else
            {
                paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.JoinDestPartsNo);
            }
            paraJoinQty.Value = SqlDataMediator.SqlSetDouble(dcTBOSearchUWork.JoinQty);
            paraEquipSpecialNote.Value = SqlDataMediator.SqlSetString(dcTBOSearchUWork.EquipSpecialNote);

            // TBO検索マスタ（ユーザー登録分）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
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
        //    sqlCommand.CommandText = "DELETE FROM TBOSEARCHURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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