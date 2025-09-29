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
// 修 正 日  2009/06/11   修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
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
    /// 在庫調整明細データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockAdjustDtlDB : RemoteDB
    {
        /// <summary>
        /// 在庫調整明細データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockAdjustDtlDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockAdjustDtlArrList">在庫調整明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.06.11</br>
        /// 
        public int SearchStockAdjustDtl(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage)
        {
            return SearchStockAdjustDtlProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockAdjustDtlArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockAdjustDtlArrList">在庫調整明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchStockAdjustDtlProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockAdjustDtlArrList = new ArrayList();
            APStockAdjustDtlWork stockAdjustDtlWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 在庫調整明細データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockAdjustDtlWork = new APStockAdjustDtlWork();
                    stockAdjustDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockAdjustDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockAdjustDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockAdjustDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockAdjustDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockAdjustDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockAdjustDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockAdjustDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockAdjustDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockAdjustDtlWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                    stockAdjustDtlWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
                    stockAdjustDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
                    stockAdjustDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
                    stockAdjustDtlWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAdjustDtlWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    stockAdjustDtlWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    stockAdjustDtlWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockAdjustDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAdjustDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAdjustDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAdjustDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAdjustDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAdjustDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    stockAdjustDtlWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    stockAdjustDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    stockAdjustDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAdjustDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAdjustDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAdjustDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAdjustDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAdjustDtlWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    stockAdjustDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    stockAdjustDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    stockAdjustDtlArrList.Add(stockAdjustDtlWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockAdjustDtlDB.SearchStockAdjustDtl Exception=" + ex.Message);
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
        /// 在庫調整明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustDtlList">在庫調整明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockAdjustDtl(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockAdjustDtlProc(enterPriseCode, stockAdjustDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustDtlList">在庫調整明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockAdjustDtlProc(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockAdjustDtl(enterPriseCode, stockAdjustDtlList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockAdjustDtl(enterPriseCode, stockAdjustDtlList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustDtlList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockAdjustDtl(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustDtlProc(enterPriseCode, stockAdjustDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustDtlList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockAdjustDtlProc(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustDtlWork stockAdjustDtlWork in stockAdjustDtlList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaStockAdjustSlipNo.Value = stockAdjustDtlWork.StockAdjustSlipNo;
                findParaStockAdjustRowNo.Value = stockAdjustDtlWork.StockAdjustRowNo;

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
        /// <param name="stockAdjustDtlList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockAdjustDtl(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockAdjustDtlProc(enterPriseCode, stockAdjustDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAdjustDtlList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockAdjustDtlProc(string enterPriseCode, ArrayList stockAdjustDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAdjustDtlWork stockAdjustDtlWork in stockAdjustDtlList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)";

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
                SqlParameter paraStockAdjustRowNo = sqlCommand.Parameters.Add("@STOCKADJUSTROWNO", SqlDbType.Int);
                SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAdjustDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockAdjustDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.SectionCode);
                paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.StockAdjustSlipNo);
                paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.StockAdjustRowNo);
                paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.SupplierFormalSrc);
                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockAdjustDtlWork.StockSlipDtlNumSrc);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.AcPaySlipCd);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.AcPayTransCd);
                paraAdjustDate.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.AdjustDate);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.InputDay);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.GoodsName);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.StockUnitPriceFl);
                paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.BfStockUnitPriceFl);
                paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.AdjustCount);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.DtlNote);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.WarehouseName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.BLGoodsFullName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockAdjustDtlWork.WarehouseShelfNo);
                paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAdjustDtlWork.ListPriceFl);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockAdjustDtlWork.OpenPriceDiv);
                paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockAdjustDtlWork.StockPriceTaxExc);

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

        // ----- DEL 2011/11/01 xupz---------->>>>>
        ///// <summary>
        ///// 在庫調整明細データの検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="beginningDate">開始日付</param>
        ///// <param name="endingDate">終了日付</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="stockAdjustDtlArrList">在庫調整明細データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <param name="sectionCode">sectionCode</param>
        ///// <returns>STATUS</returns>
        //public int SearchStockAdjustDtlSCM(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)
        //{
        //    return SearchStockAdjustDtlSCMProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
        //     sqlTransaction, out  stockAdjustDtlArrList, out  retMessage, sectionCode);
        //}

        ///// <summary>
        ///// 在庫調整明細データの検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="beginningDate">開始日付</param>
        ///// <param name="endingDate">終了日付</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="stockAdjustDtlArrList">在庫調整明細データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <param name="sectionCode">sectionCode</param>
        ///// <returns>STATUS</returns>
        //private int SearchStockAdjustDtlSCMProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    stockAdjustDtlArrList = new ArrayList();
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WHERE SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

        //        //Prameterオブジェクトの作成
        //        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
        //        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

        //        //Parameterオブジェクトへ値設定
        //        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
        //        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
        //        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

        //        // 在庫調整明細データ用SQL
        //        sqlCommand.CommandText = sqlStr;
        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            stockAdjustDtlArrList.Add(this.CopyToStockAdjustDtlFromReader(ref myReader));
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "APStockAdjustDtlDB.SearchStockAdjustDtl Exception=" + ex.Message);
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
        // ----- DEL 2011/11/01 xupz----------<<<<<

        // ----- ADD 2011/11/01 xupz---------->>>>>
		/// <summary>
		/// 在庫調整明細データの検索処理
		/// </summary>
		/// <param name="enterpriseCodes">企業コード</param>
		/// <param name="beginningDate">開始日付</param>
		/// <param name="endingDate">終了日付</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <param name="stockAdjustDtlArrList">在庫調整明細データオブジェクト</param>
		/// <param name="retMessage">戻るメッセージ</param>
		/// <param name="sectionCode">sectionCode</param>
		/// <returns>STATUS</returns>
        //public int SearchStockAdjustDtlSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,  // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // DEL 2011/11/30
        //public int SearchStockAdjustDtlSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/11/30  // DEL 2011/12/06
        public int SearchStockAdjustDtlSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/12/06
    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/12/06
		{
            //return SearchStockAdjustDtlSCMProc(sendMesExtraConDiv,enterpriseCodes, beginningDate, endingDate, syncExecDate, sqlConnection, // DEL 2011/12/06
            // sqlTransaction, out  stockAdjustDtlArrList, out  retMessage, sectionCode);  // DEL 2011/12/06
            return SearchStockAdjustDtlSCMProc(sendMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, endingDateTicks, sqlConnection, // ADD 2011/12/06
                sqlTransaction, out  stockAdjustDtlArrList, out  retMessage, sectionCode); // ADD 2011/12/06
		}

		/// <summary>
		/// 在庫調整明細データの検索処理
		/// </summary>
		/// <param name="enterpriseCodes">企業コード</param>
		/// <param name="beginningDate">開始日付</param>
		/// <param name="endingDate">終了日付</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <param name="stockAdjustDtlArrList">在庫調整明細データオブジェクト</param>
		/// <param name="retMessage">戻るメッセージ</param>
		/// <param name="sectionCode">sectionCode</param>
		/// <returns>STATUS</returns>
        //private int SearchStockAdjustDtlSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,  // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // DEL 2011/11/30
        //private int SearchStockAdjustDtlSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/11/30 // DEL 2011/12/06
        private int SearchStockAdjustDtlSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/11/30
            SqlTransaction sqlTransaction, out ArrayList stockAdjustDtlArrList, out string retMessage, string sectionCode)  // ADD 2011/12/06
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			stockAdjustDtlArrList = new ArrayList();
			retMessage = string.Empty;
			string sqlStr = string.Empty;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);   
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WHERE SECTIONCODERF=@FINDSECTIONCODE";
                //データ送信抽出条件区分が「差分」の場合
                if (sendMesExtraConDiv == 0) 
                {
                    //在庫調整明細データ.更新日時
                    sqlStr = sqlStr + " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                }
                //データ送信抽出条件区分が「伝票日付」の場合
                else if (sendMesExtraConDiv == 1) 
                {
                    //在庫調整明細データ.調整日付
                    //sqlStr = sqlStr + " AND ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF ";  // DEL 2011/11/30
                    sqlStr = sqlStr + " AND (( ADJUSTDATERF >= @UPDATEDATETIMEBEGRF AND ADJUSTDATERF <= @UPDATEDATETIMEENDRF) "; // ADD 2011/11/30

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
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
				SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

				//Parameterオブジェクトへ値設定
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
				findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
				findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // ----- ADD 2011/11/30 tanh---------->>>>>
                //データ送信抽出条件区分が「伝票区分」の場合
                if (sendMesExtraConDiv == 1)
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

				// 在庫調整明細データ用SQL
				sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 読み込み
				myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
				{
					stockAdjustDtlArrList.Add(this.CopyToStockAdjustDtlFromReader(ref myReader));
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "APStockAdjustDtlDB.SearchStockAdjustDtl Exception=" + ex.Message);
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
		/// クラス格納処理 Reader → stockAdjustDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APStockAdjustDtlWork CopyToStockAdjustDtlFromReader(ref SqlDataReader myReader)
		{
			APStockAdjustDtlWork stockAdjustDtlWork = new APStockAdjustDtlWork();

			this.CopyToStockAdjustDtlFromReader(ref myReader, ref stockAdjustDtlWork);

			return stockAdjustDtlWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockAdjustDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockAdjustDtlWork">stockAdjustDtlWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyToStockAdjustDtlFromReader(ref SqlDataReader myReader, ref APStockAdjustDtlWork stockAdjustDtlWork)
		{
			if (myReader != null && stockAdjustDtlWork != null)
			{
				# region クラスへ格納
				stockAdjustDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockAdjustDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockAdjustDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockAdjustDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockAdjustDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockAdjustDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockAdjustDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockAdjustDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockAdjustDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				stockAdjustDtlWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
				stockAdjustDtlWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
				stockAdjustDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
				stockAdjustDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
				stockAdjustDtlWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
				stockAdjustDtlWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
				stockAdjustDtlWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
				stockAdjustDtlWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				stockAdjustDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
				stockAdjustDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
				stockAdjustDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
				stockAdjustDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
				stockAdjustDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
				stockAdjustDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
				stockAdjustDtlWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
				stockAdjustDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
				stockAdjustDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
				stockAdjustDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
				stockAdjustDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
				stockAdjustDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
				stockAdjustDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
				stockAdjustDtlWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
				stockAdjustDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
				stockAdjustDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
				# endregion
			}
		}

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}