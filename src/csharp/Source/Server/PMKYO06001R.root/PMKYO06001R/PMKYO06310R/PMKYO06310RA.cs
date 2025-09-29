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
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/08  修正内容 : マスタ送受信不備対応について
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
    /// BLコードガイドマスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードガイドマスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APBLCodeGuideDB : RemoteDB
    {
        /// <summary>
        /// BLコードガイドマスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APBLCodeGuideDB()
            : base("PMKYO06311D", "Broadleaf.Application.Remoting.ParamData.APBLCodeGuideWork", "BLCODEGUIDERF")
        {

        }

        #region [Read]
        /// <summary>
        /// BLコードガイドマスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="bLCodeGuideArrList">BLコードガイドマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchBLCodeGuide(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList bLCodeGuideArrList, out string retMessage)
        {
            return SearchBLCodeGuideProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                     sqlTransaction, out bLCodeGuideArrList, out retMessage);
        }
        /// <summary>
        /// BLコードガイドマスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="bLCodeGuideArrList">BLコードガイドマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchBLCodeGuideProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList bLCodeGuideArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            bLCodeGuideArrList = new ArrayList();
            APBLCodeGuideWork bLCodeGuideWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, BLCODEDSPPAGERF, BLCODEDSPROWRF, BLCODEDSPCOLRF, BLGOODSCODERF, BLGOODSNAMERF FROM BLCODEGUIDERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                // DEL 2009/06/09 --->>>
                //SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                // DEL 2009/06/09 ---<<<
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                // DEL 2009/06/09 --->>>
                //findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                //findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);
                // DEL 2009/06/09 ---<<<

                //BLコードガイドマスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    bLCodeGuideWork = new APBLCodeGuideWork();

                    bLCodeGuideWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    bLCodeGuideWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    bLCodeGuideWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    bLCodeGuideWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    bLCodeGuideWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    bLCodeGuideWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    bLCodeGuideWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    bLCodeGuideWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    bLCodeGuideWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    bLCodeGuideWork.BLCodeDspPage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPPAGERF"));
                    bLCodeGuideWork.BLCodeDspRow = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPROWRF"));
                    bLCodeGuideWork.BLCodeDspCol = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPCOLRF"));
                    bLCodeGuideWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    bLCodeGuideWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSNAMERF"));
                    bLCodeGuideArrList.Add(bLCodeGuideWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APBLCodeGuideDB.SearchBLCodeGuide Exception=" + ex.Message);
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
        /// BLコードガイドマスタの計数検索処理
        /// </summary>
        /// <param name="blCodeGuideWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchBLCodeGuideCount(APBLCodeGuideWork blCodeGuideWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchBLCodeGuideCountProc(blCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// BLコードガイドマスタの計数検索処理
        /// </summary>
        /// <param name="blCodeGuideWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchBLCodeGuideCountProc(APBLCodeGuideWork blCodeGuideWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM BLCODEGUIDERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE ";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                // DEL 2009/06/09 --->>>
                //SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                //SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                //SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                //SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                // DEL 2009/06/09 ---<<<
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeGuideWork.EnterpriseCode);
                findParaSectionCode.Value = blCodeGuideWork.SectionCode;
                // DEL 2009/06/09 --->>>
                //findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(blCodeGuideWork.BLCodeDspPage);
                //findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(blCodeGuideWork.BLCodeDspRow);
                //findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(blCodeGuideWork.BLCodeDspCol);
                //findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blCodeGuideWork.BLGoodsCode);
                // DEL 2009/06/09 ---<<<

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
        ///  BLコードガイドマスタデータ削除
        /// </summary>
        /// <param name="apBLCodeGuideWork">BLコードガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : BLコードガイドマスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APBLCodeGuideWork apBLCodeGuideWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  BLコードガイドマスタデータ削除
        /// </summary>
        /// <param name="apBLCodeGuideWork">BLコードガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : BLコードガイドマスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APBLCodeGuideWork apBLCodeGuideWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM BLCODEGUIDERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE ";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            // DEL 2009/06/09 --->>>
            //SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
            //SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
            //SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
            //SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            // DEL 2009/06/09 ---<<<
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apBLCodeGuideWork.EnterpriseCode;
            findParaSectionCode.Value = apBLCodeGuideWork.SectionCode;
            // DEL 2009/06/09 --->>>
            //findParaBLCodeDspPage.Value = apBLCodeGuideWork.BLCodeDspPage;
            //findParaBLCodeDspRow.Value = apBLCodeGuideWork.BLCodeDspRow;
            //findParaBLCodeDspCol.Value = apBLCodeGuideWork.BLCodeDspCol;
            //findParaBLGoodsCode.Value = apBLCodeGuideWork.BLGoodsCode;
            // DEL 2009/06/09 ---<<<

            // BLコードガイドマスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// BLコードガイドマスタ登録
        /// </summary>
        /// <param name="apBLCodeGuideWork">BLコードガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : BLコードガイドマスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APBLCodeGuideWork apBLCodeGuideWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// BLコードガイドマスタ登録
        /// </summary>
        /// <param name="apBLCodeGuideWork">BLコードガイドマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : BLコードガイドマスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(APBLCodeGuideWork apBLCodeGuideWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO BLCODEGUIDERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, BLCODEDSPPAGERF, BLCODEDSPROWRF, BLCODEDSPCOLRF, BLGOODSCODERF, BLGOODSNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @BLCODEDSPPAGE, @BLCODEDSPROW, @BLCODEDSPCOL, @BLGOODSCODE, @BLGOODSNAME)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraBLCodeDspPage = sqlCommand.Parameters.Add("@BLCODEDSPPAGE", SqlDbType.Int);
            SqlParameter paraBLCodeDspRow = sqlCommand.Parameters.Add("@BLCODEDSPROW", SqlDbType.Int);
            SqlParameter paraBLCodeDspCol = sqlCommand.Parameters.Add("@BLCODEDSPCOL", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsName = sqlCommand.Parameters.Add("@BLGOODSNAME", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apBLCodeGuideWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apBLCodeGuideWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apBLCodeGuideWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apBLCodeGuideWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apBLCodeGuideWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apBLCodeGuideWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apBLCodeGuideWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apBLCodeGuideWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apBLCodeGuideWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = apBLCodeGuideWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(apBLCodeGuideWork.SectionCode);
            }
            paraBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(apBLCodeGuideWork.BLCodeDspPage);
            paraBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(apBLCodeGuideWork.BLCodeDspRow);
            paraBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(apBLCodeGuideWork.BLCodeDspCol);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(apBLCodeGuideWork.BLGoodsCode);
            paraBLGoodsName.Value = SqlDataMediator.SqlSetString(apBLCodeGuideWork.BLGoodsName);

            // BLコードガイドマスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

    }
}






