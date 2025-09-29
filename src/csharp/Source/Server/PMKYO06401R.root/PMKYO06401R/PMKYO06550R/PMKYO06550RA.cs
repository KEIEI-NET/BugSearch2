//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信処理                           　　 //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06550R.DLL							        //
// Programmer       :   呉元嘯	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2009.06.12　							//
//                  :   public MethodでSQL文字が駄目対応について        //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2011.08.26　							//
//                  :   DC履歴ログとDC各データのクリア処理を追加        //
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
    /// 部品代替マスタ（ユーザー登録分）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品代替マスタ（ユーザー登録分）データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCPartsSubstUDB : RemoteDB
    {
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCPartsSubstUDB()
            : base("PMKYO06551D", "Broadleaf.Application.Remoting.ParamData.DCPartsSubstUWork", "PARTSSUBSTURF")
        {

        }

        #region [Read]
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="partsSubstUArrList">部品代替マスタ（ユーザー登録分）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchPartsSubstU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList partsSubstUArrList, out string retMessage)
        {
            return SearchPartsSubstUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                       sqlTransaction, out partsSubstUArrList, out retMessage);
        }
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="partsSubstUArrList">部品代替マスタ（ユーザー登録分）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchPartsSubstUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList partsSubstUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            partsSubstUArrList = new ArrayList();
            DCPartsSubstUWork partsSubstUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CHGSRCMAKERCDRF, CHGSRCGOODSNORF, CHGSRCGOODSNONONEHPRF, CHGDESTMAKERCDRF, CHGDESTGOODSNORF, CHGDESTGOODSNONONEHPRF, APPLYSTADATERF, APPLYENDDATERF FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //部品代替マスタ（ユーザー登録分）データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsSubstUWork = new DCPartsSubstUWork();

                    partsSubstUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    partsSubstUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    partsSubstUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    partsSubstUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    partsSubstUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    partsSubstUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    partsSubstUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    partsSubstUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    partsSubstUWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    partsSubstUWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    partsSubstUWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHPRF"));
                    partsSubstUWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    partsSubstUWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    partsSubstUWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHPRF"));
                    partsSubstUWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    partsSubstUWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));

                    partsSubstUArrList.Add(partsSubstUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCPartsSubstUDB.SearchPartsSubstU Exception=" + ex.Message);
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
        ///  部品代替マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="dcPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcPartsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  部品代替マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="dcPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
            SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcPartsSubstUWork.EnterpriseCode;
            findParaChgSrcMakerCd.Value = dcPartsSubstUWork.ChgSrcMakerCd;
            findParaChgSrcGoodsNo.Value = dcPartsSubstUWork.ChgSrcGoodsNo;

            // 部品代替マスタ（ユーザー登録分）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="dcPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcPartsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="dcPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCPartsSubstUWork dcPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO PARTSSUBSTURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CHGSRCMAKERCDRF, CHGSRCGOODSNORF, CHGSRCGOODSNONONEHPRF, CHGDESTMAKERCDRF, CHGDESTGOODSNORF, CHGDESTGOODSNONONEHPRF, APPLYSTADATERF, APPLYENDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CHGSRCMAKERCD, @CHGSRCGOODSNO, @CHGSRCGOODSNONONEHP, @CHGDESTMAKERCD, @CHGDESTGOODSNO, @CHGDESTGOODSNONONEHP, @APPLYSTADATE, @APPLYENDDATE)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@CHGSRCMAKERCD", SqlDbType.Int);
            SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
            SqlParameter paraChgSrcGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGSRCGOODSNONONEHP", SqlDbType.NVarChar);
            SqlParameter paraChgDestMakerCd = sqlCommand.Parameters.Add("@CHGDESTMAKERCD", SqlDbType.Int);
            SqlParameter paraChgDestGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
            SqlParameter paraChgDestGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGDESTGOODSNONONEHP", SqlDbType.NVarChar);
            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);


            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPartsSubstUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPartsSubstUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcPartsSubstUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcPartsSubstUWork.LogicalDeleteCode);
            paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(dcPartsSubstUWork.ChgSrcMakerCd);
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgSrcGoodsNo.Trim()))
            {
                paraChgSrcGoodsNo.Value = dcPartsSubstUWork.ChgSrcGoodsNo;
            }
            else
            {
                paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgSrcGoodsNo);
            }
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgSrcGoodsNoNoneHp.Trim()))
            {
                paraChgSrcGoodsNoNoneHp.Value = dcPartsSubstUWork.ChgSrcGoodsNoNoneHp;
            }
            else
            {
                paraChgSrcGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgSrcGoodsNoNoneHp);
            }
            paraChgDestMakerCd.Value = SqlDataMediator.SqlSetInt32(dcPartsSubstUWork.ChgDestMakerCd);
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgDestGoodsNo.Trim()))
            {
                paraChgDestGoodsNo.Value = dcPartsSubstUWork.ChgDestGoodsNo;
            }
            else
            {
                paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgDestGoodsNo);
            }
            if (string.IsNullOrEmpty(dcPartsSubstUWork.ChgDestGoodsNoNoneHp.Trim()))
            {
                paraChgDestGoodsNoNoneHp.Value = dcPartsSubstUWork.ChgDestGoodsNoNoneHp;
            }
            else
            {
                paraChgDestGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(dcPartsSubstUWork.ChgDestGoodsNoNoneHp);
            }
            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPartsSubstUWork.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPartsSubstUWork.ApplyEndDate);


            // 部品代替マスタ（ユーザー登録分）データを登録する
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
        //    sqlCommand.CommandText = "DELETE FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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