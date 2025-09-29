//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部品代替マスタ（ユーザー登録分）READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品代替マスタ（ユーザー登録分）処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APPartsSubstUDB : RemoteDB
    {
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APPartsSubstUDB()
            : base("PMKYO06241D", "Broadleaf.Application.Remoting.ParamData.APPartsSubstUWork", "PARTSSUBSTURF")
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
            APPartsSubstUWork partsSubstUWork = null;
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
                    partsSubstUWork = new APPartsSubstUWork();

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
                base.WriteErrorLog(ex, "APPartsSubstUDB.SearchPartsSubstU Exception=" + ex.Message);
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
        /// 部品代替マスタ（ユーザー登録分）の計数検索処理
        /// </summary>
        /// <param name="partsSubstUWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchPartsSubstUCount(APPartsSubstUWork partsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchPartsSubstUCountProc(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）の計数検索処理
        /// </summary>
        /// <param name="partsSubstUWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchPartsSubstUCountProc(APPartsSubstUWork partsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                findParaChgSrcGoodsNo.Value = partsSubstUWork.ChgSrcGoodsNo;


                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APSecInfoSetDB.SearchSecInfoSet Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        ///  部品代替マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="apPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APPartsSubstUWork apPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apPartsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  部品代替マスタ（ユーザー登録分）データ削除
        /// </summary>
        /// <param name="apPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APPartsSubstUWork apPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM PARTSSUBSTURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
            SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apPartsSubstUWork.EnterpriseCode;
            findParaChgSrcMakerCd.Value = apPartsSubstUWork.ChgSrcMakerCd;
            findParaChgSrcGoodsNo.Value = apPartsSubstUWork.ChgSrcGoodsNo;

            // 部品代替マスタ（ユーザー登録分）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="apPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APPartsSubstUWork apPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apPartsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }

        /// <summary>
        /// 部品代替マスタ（ユーザー登録分）登録
        /// </summary>
        /// <param name="apPartsSubstUWork">部品代替マスタ（ユーザー登録分）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 部品代替マスタ（ユーザー登録分）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(APPartsSubstUWork apPartsSubstUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
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
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apPartsSubstUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apPartsSubstUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apPartsSubstUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apPartsSubstUWork.LogicalDeleteCode);
            paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(apPartsSubstUWork.ChgSrcMakerCd);
            if (string.IsNullOrEmpty(apPartsSubstUWork.ChgSrcGoodsNo.Trim()))
            {
                paraChgSrcGoodsNo.Value = apPartsSubstUWork.ChgSrcGoodsNo;
            }
            else
            {
                paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.ChgSrcGoodsNo);
            }
            if (string.IsNullOrEmpty(apPartsSubstUWork.ChgSrcGoodsNoNoneHp.Trim()))
            {
                paraChgSrcGoodsNoNoneHp.Value = apPartsSubstUWork.ChgSrcGoodsNoNoneHp;
            }
            else
            {
                paraChgSrcGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.ChgSrcGoodsNoNoneHp);
            }
            paraChgDestMakerCd.Value = SqlDataMediator.SqlSetInt32(apPartsSubstUWork.ChgDestMakerCd);
            if (string.IsNullOrEmpty(apPartsSubstUWork.ChgDestGoodsNo.Trim()))
            {
                paraChgDestGoodsNo.Value = apPartsSubstUWork.ChgDestGoodsNo;
            }
            else
            {
                paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.ChgDestGoodsNo);
            }
            if (string.IsNullOrEmpty(apPartsSubstUWork.ChgDestGoodsNoNoneHp.Trim()))
            {
                paraChgDestGoodsNoNoneHp.Value = apPartsSubstUWork.ChgDestGoodsNoNoneHp;
            }
            else
            {
                paraChgDestGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(apPartsSubstUWork.ChgDestGoodsNoNoneHp);
            }
            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apPartsSubstUWork.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apPartsSubstUWork.ApplyEndDate);


            // 部品代替マスタ（ユーザー登録分）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion
    }
}





