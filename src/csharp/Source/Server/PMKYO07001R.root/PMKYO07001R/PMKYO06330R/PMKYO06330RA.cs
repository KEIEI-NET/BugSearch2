//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/06  修正内容 : Redmine#8293 画面の終了日付＋システム時刻仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 脇田 靖之
// 修 正 日  2014/02/20  修正内容 : 仕掛一覧№2292対応
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫調整データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockAdjustDB : RemoteDB
    {
        /// <summary>
        /// 在庫調整データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockAdjustDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockAdjustArrList">在庫調整データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データREADLISTを全て戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.06.11</br>
        /// 
        public int SearchStockAdjust(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage)
        {
            return SearchStockAdjustProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockAdjustArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockAdjustArrList">在庫調整データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データREADLISTを全て戻します</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchStockAdjustProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockAdjustArrList = new ArrayList();
            APStockAdjustWork stockAdjustWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 在庫調整データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockAdjustWork = new APStockAdjustWork();

                    stockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                    stockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    stockAdjustWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    stockAdjustWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    stockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    stockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    stockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                    stockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));

                    stockAdjustArrList.Add(stockAdjustWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockAdjustDB.SearchStockAdjust Exception=" + ex.Message);
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
*/
        // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockAdjust(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockAdjustProc(enterPriseCode, stockAdjustList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockAdjustProc(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockAdjust(enterPriseCode, stockAdjustList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockAdjust(enterPriseCode, stockAdjustList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        /// <summary>
        /// 在庫調整データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockAdjust(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustProc(enterPriseCode, stockAdjustList, ref  sqlConnection, ref  sqlTransaction);
        }
        /// <summary>
        /// 在庫調整データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockAdjustProc(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustWork stockAdjustWork in stockAdjustList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaStockAdjustSlipNo.Value = stockAdjustWork.StockAdjustSlipNo;

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                // 実行
                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockAdjust(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockAdjustProc(enterPriseCode, stockAdjustList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockAdjustProc(string enterPriseCode, ArrayList stockAdjustList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustWork stockAdjustWork in stockAdjustList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKADJUSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @STOCKSECTIONCD, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @STOCKSUBTTLPRICE, @SLIPNOTE)";

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
                SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockAdjustWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockAdjustWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockAdjustWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.SectionCode);
                paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.StockAdjustSlipNo);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.AcPaySlipCd);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.AcPayTransCd);
                paraAdjustDate.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.AdjustDate);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.InputDay);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockSectionCd);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockAdjustWork.StockAgentName);
                paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockAdjustWork.StockSubttlPrice);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(stockAdjustWork.SlipNote);

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		// Rクラスのpublic MethodでSQL文字が駄目

        //----- DEL 2011/11/01 xupz------->>>>>>
        ///// <summary>
        ///// 在庫調整データの検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="beginningDate">開始日付</param>
        ///// <param name="endingDate">終了日付</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="stockAdjustArrList">在庫調整データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <param name="SectionCd">SectionCd</param>
        ///// <returns>STATUS</returns>
        //public int SearchStockAdjustSCM(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)
        //{
        //    return SearchStockAdjustSCMProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
        //     sqlTransaction, out  stockAdjustArrList, out  retMessage, SectionCd);
        //}

        ///// <summary>
        ///// 在庫調整データの検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="beginningDate">開始日付</param>
        ///// <param name="endingDate">終了日付</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="stockAdjustArrList">在庫調整データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <param name="SectionCd">SectionCd</param>
        ///// <returns>STATUS</returns>
        //private int SearchStockAdjustSCMProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    stockAdjustArrList = new ArrayList();
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

        //        //Prameterオブジェクトの作成
        //        SqlParameter findParaSectionCd = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
        //        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

        //        //Parameterオブジェクトへ値設定
        //        findParaSectionCd.Value = SqlDataMediator.SqlSetString(SectionCd);
        //        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
        //        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

        //        // 在庫調整データ用SQL
        //        sqlCommand.CommandText = sqlStr;
        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            stockAdjustArrList.Add(this.CopyTostockAdjustWorkFromReader(ref myReader));
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "APStockAdjustDB.SearchStockAdjust Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //----- DEL 2011/11/01 xupz-------<<<<<<

        //----- ADD 2011/11/01 xupz------->>>>>>
		/// <summary>
		/// 在庫調整データの検索処理
		/// </summary>
		/// <param name="enterpriseCodes">企業コード</param>
		/// <param name="beginningDate">開始日付</param>
		/// <param name="endingDate">終了日付</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <param name="stockAdjustArrList">在庫調整データオブジェクト</param>
		/// <param name="retMessage">戻るメッセージ</param>
		/// <param name="SectionCd">SectionCd</param>
		/// <returns>STATUS</returns>
        //public int SearchStockAdjustSCM(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,   // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)                                          // DEL 2011/11/30
        //public int SearchStockAdjustSCM(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)    // ADD 2011/11/30 // DEL 2011/12/06
        public int SearchStockAdjustSCM(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/12/06
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)    // ADD 2011/12/06
		{
            //return SearchStockAdjustSCMProc(sedMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, sqlConnection, // DEL 2011/12/06
            // sqlTransaction, out  stockAdjustArrList, out  retMessage, SectionCd); // DEL 2011/12/06
            return SearchStockAdjustSCMProc(sedMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, endingDateTicks, sqlConnection, // ADD 2011/12/06
             sqlTransaction, out  stockAdjustArrList, out  retMessage, SectionCd); // ADD 2011/12/06
		} 

		/// <summary>
		/// 在庫調整データの検索処理
		/// </summary>
		/// <param name="enterpriseCodes">企業コード</param>
		/// <param name="beginningDate">開始日付</param>
		/// <param name="endingDate">終了日付</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <param name="stockAdjustArrList">在庫調整データオブジェクト</param>
		/// <param name="retMessage">戻るメッセージ</param>
		/// <param name="SectionCd">SectionCd</param>
		/// <returns>STATUS</returns>
        //private int SearchStockAdjustSCMProc(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection, // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd)   // DEL 2011/11/30
        //private int SearchStockAdjustSCMProc(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection, // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd) // ADD 2011/11/30 // DEL 2011/12/06
        private int SearchStockAdjustSCMProc(Int32 sedMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection, // ADD 2011/12/06
            SqlTransaction sqlTransaction, out ArrayList stockAdjustArrList, out string retMessage, string SectionCd) // ADD 2011/12/06
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			stockAdjustArrList = new ArrayList();
			retMessage = string.Empty;
			string sqlStr = string.Empty;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WHERE SECTIONCODERF=@FINDSECTIONCODE";
                //データ送信抽出条件区分が「差分」の場合
                if (sedMesExtraConDiv == 0)
                {
                    //在庫調整データ.更新日時
                    sqlStr = sqlStr + " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                }
                //データ送信抽出条件区分が「伝票日付」の場合 
                else if(sedMesExtraConDiv == 1)
                {
                    //在庫調整データ.調整日付
                    //sqlStr = sqlStr + " AND ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF ";  // DEL 2011/11/30
                    sqlStr = sqlStr + " AND (( ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF )"; // ADD 2011/11/30

                    // ----- ADD 2011/11/30 tanh---------->>>>>
                    // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                    //sqlStr = sqlStr + " OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ";
                    sqlStr = sqlStr + " OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ";
                    // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                    sqlStr = sqlStr + " AND  UPDATEDATETIMERF<=@FINDENDTIMERF ";
                    sqlStr = sqlStr + " AND  ADJUSTDATERF<=@UPDATEDATETIMEENDRF )) ";
                    // ----- ADD 2011/11/30 tanh----------<<<<<<
                }

				//Prameterオブジェクトの作成
				SqlParameter findParaSectionCd = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
				SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

				//Parameterオブジェクトへ値設定
				findParaSectionCd.Value = SqlDataMediator.SqlSetString(SectionCd);
				findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
				findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // ----- ADD 2011/11/30 tanh---------->>>>>
                //データ送信抽出条件区分が「伝票区分」の場合
                if (sedMesExtraConDiv == 1)
                {
                    SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                    findParaSyncExecDate.Value = SqlDataMediator.SqlSetInt64(syncExecDate);
                    SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                    // DEL 2011/12/06 ----------- >>>>>>>>>>>>>>>
                    //string endTimeStr = sendDataWork.EndDateTime.ToString();
                    //if (endTimeStr.Length == 8)
                    //{
                    //    DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                    //                                int.Parse(endTimeStr.Substring(4, 2)),
                    //                                int.Parse(endTimeStr.Substring(6, 2)),
                    //                                23, 59, 59);
                    //    findParaEndTime.Value = endTime.Ticks;
                    //}
                    //else
                    //{
                    //    findParaEndTime.Value = DateTime.MinValue.Ticks;
                    //}
                    // DEL 2011/12/06 ----------- <<<<<<<<<<<<<<<
                    findParaEndTime.Value = SqlDataMediator.SqlSetInt64(endingDateTicks); // ADD 2011/12/06
                }
                // ----- ADD 2011/11/30 tanh----------<<<<<

				// 在庫調整データ用SQL
				sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 読み込み
				myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
				{
					stockAdjustArrList.Add(this.CopyTostockAdjustWorkFromReader(ref myReader));
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "APStockAdjustDB.SearchStockAdjust Exception=" + ex.Message);
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
        // ----- ADD 2011/11/01 xupz----------<<<<<

		/// <summary>
		/// クラス格納処理 Reader → aPStockAdjustWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APStockAdjustWork CopyTostockAdjustWorkFromReader(ref SqlDataReader myReader)
		{
			APStockAdjustWork stockAdjustWork = new APStockAdjustWork();

			this.CopyTostockAdjustWorkFromReader(ref myReader, ref stockAdjustWork);

			return stockAdjustWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockAdjustWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockAdjustWork">stockAdjustWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyTostockAdjustWorkFromReader(ref SqlDataReader myReader, ref APStockAdjustWork stockAdjustWork)
		{
			if (myReader != null && stockAdjustWork != null)
			{
				# region クラスへ格納
				stockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				stockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
				stockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
				stockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
				stockAdjustWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
				stockAdjustWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				stockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
				stockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
				stockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
				stockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
				stockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
				stockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
				stockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));

				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}