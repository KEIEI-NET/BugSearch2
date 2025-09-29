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
    /// 商品別売上目標設定マスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品別売上目標設定マスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APGcdSalesTargetDB : RemoteDB
    {
        /// <summary>
        /// 商品別売上目標設定マスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APGcdSalesTargetDB()
            : base("PMKYO06251D", "Broadleaf.Application.Remoting.ParamData.APGcdSalesTargetWork", "GCDSALESTARGETRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 商品別売上目標設定マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="gcdSalesTargetArrList">商品別売上目標設定マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上目標設定マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchGcdSalesTarget(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList gcdSalesTargetArrList, out string retMessage)
        {
            return SearchGcdSalesTargetProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                     sqlTransaction, out gcdSalesTargetArrList, out retMessage);
        }
        /// <summary>
        /// 商品別売上目標設定マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="gcdSalesTargetArrList">商品別売上目標設定マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上目標設定マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchGcdSalesTargetProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList gcdSalesTargetArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            gcdSalesTargetArrList = new ArrayList();
            APGcdSalesTargetWork gcdSalesTargetWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, GOODSMAKERCDRF, GOODSNORF, BLGROUPCODERF, BLGOODSCODERF, SALESCODERF, ENTERPRISEGANRECODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF FROM GCDSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //商品別売上目標設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    gcdSalesTargetWork = new APGcdSalesTargetWork();

                    gcdSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    gcdSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    gcdSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    gcdSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    gcdSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    gcdSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    gcdSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    gcdSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    gcdSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    gcdSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
                    gcdSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
                    gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                    gcdSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
                    gcdSalesTargetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    gcdSalesTargetWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    gcdSalesTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    gcdSalesTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    gcdSalesTargetWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    gcdSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    gcdSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                    gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
                    gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
                    gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
                    gcdSalesTargetArrList.Add(gcdSalesTargetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APGcdSalesTargetDB.SearchGcdSalesTarget Exception=" + ex.Message);
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
        /// 商品別売上目標設定マスタの計数検索処理
        /// </summary>
        /// <param name="gcdSalesTargetWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上目標設定マスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGcdSalesTargetCount(APGcdSalesTargetWork gcdSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGcdSalesTargetCountProc(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 商品別売上目標設定マスタの計数検索処理
        /// </summary>
        /// <param name="gcdSalesTargetWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上目標設定マスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGcdSalesTargetCountProc(APGcdSalesTargetWork gcdSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GCDSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND SALESCODERF=@FINDSALESCODE AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.EnterpriseCode);
                findParaSectionCode.Value = gcdSalesTargetWork.SectionCode;
                findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.TargetSetCd);
                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.TargetContrastCd);
                findParaTargetDivideCode.Value = gcdSalesTargetWork.TargetDivideCode;
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.GoodsMakerCd);
                findParaGoodsNo.Value = gcdSalesTargetWork.GoodsNo;
                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.BLGroupCode);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.BLGoodsCode);
                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.SalesCode);
                findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.EnterpriseGanreCode);


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
        ///  商品別売上目標設定マスタデータ削除
        /// </summary>
        /// <param name="apGcdSalesTargetWork">商品別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品別売上目標設定マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APGcdSalesTargetWork apGcdSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apGcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  商品別売上目標設定マスタデータ削除
        /// </summary>
        /// <param name="apGcdSalesTargetWork">商品別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品別売上目標設定マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APGcdSalesTargetWork apGcdSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM GCDSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND SALESCODERF=@FINDSALESCODE AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
            SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
            SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
            SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apGcdSalesTargetWork.EnterpriseCode;
            findParaSectionCode.Value = apGcdSalesTargetWork.SectionCode;
            findParaTargetSetCd.Value = apGcdSalesTargetWork.TargetSetCd;
            findParaTargetContrastCd.Value = apGcdSalesTargetWork.TargetContrastCd;
            findParaTargetDivideCode.Value = apGcdSalesTargetWork.TargetDivideCode;
            findParaGoodsMakerCd.Value = apGcdSalesTargetWork.GoodsMakerCd;
            findParaGoodsNo.Value = apGcdSalesTargetWork.GoodsNo;
            findParaBLGroupCode.Value = apGcdSalesTargetWork.BLGroupCode;
            findParaBLGoodsCode.Value = apGcdSalesTargetWork.BLGoodsCode;
            findParaSalesCode.Value = apGcdSalesTargetWork.SalesCode;
            findParaEnterpriseGanreCode.Value = apGcdSalesTargetWork.EnterpriseGanreCode;


            // 商品別売上目標設定マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 商品別売上目標設定マスタ登録
        /// </summary>
        /// <param name="apGcdSalesTargetWork">商品別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品別売上目標設定マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APGcdSalesTargetWork apGcdSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apGcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 商品別売上目標設定マスタ登録
        /// </summary>
        /// <param name="apGcdSalesTargetWork">商品別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品別売上目標設定マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(APGcdSalesTargetWork apGcdSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO GCDSALESTARGETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, GOODSMAKERCDRF, GOODSNORF, BLGROUPCODERF, BLGOODSCODERF, SALESCODERF, ENTERPRISEGANRECODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TARGETSETCD, @TARGETCONTRASTCD, @TARGETDIVIDECODE, @TARGETDIVIDENAME, @GOODSMAKERCD, @GOODSNO, @BLGROUPCODE, @BLGOODSCODE, @SALESCODE, @ENTERPRISEGANRECODE, @APPLYSTADATE, @APPLYENDDATE, @SALESTARGETMONEY, @SALESTARGETPROFIT, @SALESTARGETCOUNT)";

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
            SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
            SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
            SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
            SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
            SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);


            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGcdSalesTargetWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGcdSalesTargetWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGcdSalesTargetWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apGcdSalesTargetWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = apGcdSalesTargetWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.SectionCode);
            }
            paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.TargetSetCd);
            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.TargetContrastCd);
            if (string.IsNullOrEmpty(apGcdSalesTargetWork.TargetDivideCode.Trim()))
            {
                paraTargetDivideCode.Value = apGcdSalesTargetWork.TargetDivideCode;
            }
            else
            {
                paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.TargetDivideCode);
            }
            paraTargetDivideName.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.TargetDivideName);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apGcdSalesTargetWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apGcdSalesTargetWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGcdSalesTargetWork.GoodsNo);
            }
            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.BLGroupCode);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.BLGoodsCode);
            paraSalesCode.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.SalesCode);
            paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(apGcdSalesTargetWork.EnterpriseGanreCode);
            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGcdSalesTargetWork.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGcdSalesTargetWork.ApplyEndDate);
            paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(apGcdSalesTargetWork.SalesTargetMoney);
            paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(apGcdSalesTargetWork.SalesTargetProfit);
            paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(apGcdSalesTargetWork.SalesTargetCount);

            // 商品別売上目標設定マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion


    }
}






