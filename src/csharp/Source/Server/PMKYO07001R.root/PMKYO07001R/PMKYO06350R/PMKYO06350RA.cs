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
    /// 在庫移動データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockMoveDB : RemoteDB
    {
        /// <summary>
        /// 在庫移動データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockMoveDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫移動データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockMoveArrList">在庫移動データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動データREADLISTを全て戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.06.11</br>
        /// 
        public int SearchStockMove(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage)
        {
            return SearchStockMoveProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockMoveArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫移動データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockMoveArrList">在庫移動データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動データREADLISTを全て戻します</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchStockMoveProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockMoveArrList = new ArrayList();
            APStockMoveWork stockMoveWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 在庫移動データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockMoveWork = new APStockMoveWork();
                    stockMoveWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockMoveWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockMoveWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockMoveWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockMoveWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockMoveWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockMoveWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockMoveWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockMoveWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
                    stockMoveWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
                    stockMoveWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
                    stockMoveWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    stockMoveWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                    stockMoveWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                    stockMoveWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                    stockMoveWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                    stockMoveWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                    stockMoveWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
                    stockMoveWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                    stockMoveWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                    stockMoveWork.ShipmentScdlDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
                    stockMoveWork.ShipmentFixDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
                    stockMoveWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    stockMoveWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockMoveWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
                    stockMoveWork.StockMvEmpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
                    stockMoveWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
                    stockMoveWork.ShipAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTCDRF"));
                    stockMoveWork.ShipAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTNMRF"));
                    stockMoveWork.ReceiveAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTCDRF"));
                    stockMoveWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
                    stockMoveWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockMoveWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockMoveWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockMoveWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockMoveWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockMoveWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockMoveWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    stockMoveWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    stockMoveWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockMoveWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    stockMoveWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                    stockMoveWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                    stockMoveWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
                    stockMoveWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockMoveWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockMoveWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    stockMoveWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    stockMoveWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                    stockMoveWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    stockMoveWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));

                    stockMoveArrList.Add(stockMoveWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockMoveDB.SearchStockMove Exception=" + ex.Message);
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
        /// 在庫移動データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockMoveList">在庫移動データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockMove(string enterPriseCode, ArrayList stockMoveList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockMoveProc(enterPriseCode, stockMoveList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫移動データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockMoveList">在庫移動データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockMoveProc(string enterPriseCode, ArrayList stockMoveList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockMove(enterPriseCode, stockMoveList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockMove(enterPriseCode, stockMoveList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫移動データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockMoveList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockMove(string enterPriseCode, ArrayList stockMoveList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockMoveProc(enterPriseCode, stockMoveList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫移動データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockMoveList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockMoveProc(string enterPriseCode, ArrayList stockMoveList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockMoveWork stockMoveWork in stockMoveList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaStockMoveFormal.Value = stockMoveWork.StockMoveFormal;
                findParaStockMoveSlipNo.Value = stockMoveWork.StockMoveSlipNo;
                findParaStockMoveRowNo.Value = stockMoveWork.StockMoveRowNo;

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
        /// <param name="stockMoveList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockMove(string enterPriseCode, ArrayList stockMoveList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockMoveProc(enterPriseCode, stockMoveList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockMoveList">在庫調整データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockMoveProc(string enterPriseCode, ArrayList stockMoveList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockMoveWork stockMoveWork in stockMoveList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKMOVERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @STOCKMOVEFORMAL, @STOCKMOVESLIPNO, @STOCKMOVEROWNO, @UPDATESECCD, @BFSECTIONCODE, @BFSECTIONGUIDESNM, @BFENTERWAREHCODE, @BFENTERWAREHNAME, @AFSECTIONCODE, @AFSECTIONGUIDESNM, @AFENTERWAREHCODE, @AFENTERWAREHNAME, @SHIPMENTSCDLDAY, @SHIPMENTFIXDAY, @ARRIVALGOODSDAY, @INPUTDAY, @MOVESTATUS, @STOCKMVEMPCODE, @STOCKMVEMPNAME, @SHIPAGENTCD, @SHIPAGENTNM, @RECEIVEAGENTCD, @RECEIVEAGENTNM, @SUPPLIERCD, @SUPPLIERSNM, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @STOCKDIV, @STOCKUNITPRICEFL, @TAXATIONDIVCD, @MOVECOUNT, @BFSHELFNO, @AFSHELFNO, @BLGOODSCODE, @BLGOODSFULLNAME, @LISTPRICEFL, @OUTLINE, @WAREHOUSENOTE1, @SLIPPRINTFINISHCD, @STOCKMOVEPRICE)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraStockMoveFormal = sqlCommand.Parameters.Add("@STOCKMOVEFORMAL", SqlDbType.Int);
                SqlParameter paraStockMoveSlipNo = sqlCommand.Parameters.Add("@STOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter paraStockMoveRowNo = sqlCommand.Parameters.Add("@STOCKMOVEROWNO", SqlDbType.Int);
                SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraBfSectionGuideSnm = sqlCommand.Parameters.Add("@BFSECTIONGUIDESNM", SqlDbType.NVarChar);
                SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraAfSectionGuideSnm = sqlCommand.Parameters.Add("@AFSECTIONGUIDESNM", SqlDbType.NVarChar);
                SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraShipmentScdlDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLDAY", SqlDbType.Int);
                SqlParameter paraShipmentFixDay = sqlCommand.Parameters.Add("@SHIPMENTFIXDAY", SqlDbType.Int);
                SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
                SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@STOCKMVEMPCODE", SqlDbType.NChar);
                SqlParameter paraStockMvEmpName = sqlCommand.Parameters.Add("@STOCKMVEMPNAME", SqlDbType.NVarChar);
                SqlParameter paraShipAgentCd = sqlCommand.Parameters.Add("@SHIPAGENTCD", SqlDbType.NChar);
                SqlParameter paraShipAgentNm = sqlCommand.Parameters.Add("@SHIPAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraReceiveAgentCd = sqlCommand.Parameters.Add("@RECEIVEAGENTCD", SqlDbType.NChar);
                SqlParameter paraReceiveAgentNm = sqlCommand.Parameters.Add("@RECEIVEAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                SqlParameter paraMoveCount = sqlCommand.Parameters.Add("@MOVECOUNT", SqlDbType.Float);
                SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                SqlParameter paraWarehouseNote1 = sqlCommand.Parameters.Add("@WAREHOUSENOTE1", SqlDbType.NVarChar);
                SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                SqlParameter paraStockMovePrice = sqlCommand.Parameters.Add("@STOCKMOVEPRICE", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockMoveWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockMoveWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockMoveWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockMoveWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockMoveWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.LogicalDeleteCode);
                paraStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.StockMoveFormal);
                paraStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.StockMoveSlipNo);
                paraStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.StockMoveRowNo);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.UpdateSecCd);
                paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfSectionCode);
                paraBfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfSectionGuideSnm);
                paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfEnterWarehCode);
                paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfEnterWarehName);
                paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfSectionCode);
                paraAfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfSectionGuideSnm);
                paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfEnterWarehCode);
                paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfEnterWarehName);
                paraShipmentScdlDay.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.ShipmentScdlDay);
                paraShipmentFixDay.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.ShipmentFixDay);
                paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.ArrivalGoodsDay);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.InputDay);
                paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.MoveStatus);
                paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.StockMvEmpCode);
                paraStockMvEmpName.Value = SqlDataMediator.SqlSetString(stockMoveWork.StockMvEmpName);
                paraShipAgentCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.ShipAgentCd);
                paraShipAgentNm.Value = SqlDataMediator.SqlSetString(stockMoveWork.ShipAgentNm);
                paraReceiveAgentCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.ReceiveAgentCd);
                paraReceiveAgentNm.Value = SqlDataMediator.SqlSetString(stockMoveWork.ReceiveAgentNm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockMoveWork.SupplierSnm);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(stockMoveWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockMoveWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(stockMoveWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockMoveWork.GoodsNameKana);
                paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.StockDiv);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockMoveWork.StockUnitPriceFl);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.TaxationDivCd);
                paraMoveCount.Value = SqlDataMediator.SqlSetDouble(stockMoveWork.MoveCount);
                paraBfShelfNo.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfShelfNo);
                paraAfShelfNo.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfShelfNo);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockMoveWork.BLGoodsFullName);
                paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockMoveWork.ListPriceFl);
                paraOutline.Value = SqlDataMediator.SqlSetString(stockMoveWork.Outline);
                paraWarehouseNote1.Value = SqlDataMediator.SqlSetString(stockMoveWork.WarehouseNote1);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.SlipPrintFinishCd);
                paraStockMovePrice.Value = SqlDataMediator.SqlSetInt64(stockMoveWork.StockMovePrice);


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
        ///// 在庫移動データの検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="beginningDate">開始日付</param>
        ///// <param name="endingDate">終了日付</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="stockMoveArrList">在庫移動データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <param name="sectionCode">sectionCode</param>
        ///// <returns>STATUS</returns>
        //public int SearchStockMoveSCM(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)
        //{
        //    return SearchStockMoveSCMProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
        //     sqlTransaction, out  stockMoveArrList, out  retMessage, sectionCode);
        //}

        ///// <summary>
        ///// 在庫移動データの検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="beginningDate">開始日付</param>
        ///// <param name="endingDate">終了日付</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="stockMoveArrList">在庫移動データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <param name="sectionCode">sectionCode</param>
        ///// <returns>STATUS</returns>
        //private int SearchStockMoveSCMProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    stockMoveArrList = new ArrayList();
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WHERE UPDATESECCDRF=@FINDUPDATESECCD AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

        //        //Prameterオブジェクトの作成
        //        SqlParameter findParaUpdSecCode = sqlCommand.Parameters.Add("@FINDUPDATESECCD", SqlDbType.NChar);
        //        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

        //        //Parameterオブジェクトへ値設定
        //        findParaUpdSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
        //        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
        //        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

        //        // 在庫移動データ用SQL
        //        sqlCommand.CommandText = sqlStr;
        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            stockMoveArrList.Add(CopyToStockMoveWorkFromReader(ref myReader));
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "APStockMoveDB.SearchStockMove Exception=" + ex.Message);
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
		/// 在庫移動データの検索処理
		/// </summary>
		/// <param name="enterpriseCodes">企業コード</param>
		/// <param name="beginningDate">開始日付</param>
		/// <param name="endingDate">終了日付</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <param name="stockMoveArrList">在庫移動データオブジェクト</param>
		/// <param name="retMessage">戻るメッセージ</param>
		/// <param name="sectionCode">sectionCode</param>
		/// <returns>STATUS</returns>
        //public int SearchStockMoveSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection, // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)  // DEL 2011/11/30
        //public int SearchStockMoveSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection, // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)  // ADD 2011/11/30 // DEL 2011/12/06
        public int SearchStockMoveSCM(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection, // ADD 2011/12/06
            SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)  // ADD 2011/12/06
		{
            //return SearchStockMoveSCMProc(sendMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, sqlConnection, // DEL 2011/12/06
            // sqlTransaction, out  stockMoveArrList, out  retMessage, sectionCode); // DEL 2011/12/06
            return SearchStockMoveSCMProc(sendMesExtraConDiv, enterpriseCodes, beginningDate, endingDate, syncExecDate, endingDateTicks, sqlConnection, // ADD 2011/12/06
             sqlTransaction, out  stockMoveArrList, out  retMessage, sectionCode); // ADD 2011/12/06
		}

		/// <summary>
		/// 在庫移動データの検索処理
		/// </summary>
		/// <param name="enterpriseCodes">企業コード</param>
		/// <param name="beginningDate">開始日付</param>
		/// <param name="endingDate">終了日付</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <param name="stockMoveArrList">在庫移動データオブジェクト</param>
		/// <param name="retMessage">戻るメッセージ</param>
		/// <param name="sectionCode">sectionCode</param>
		/// <returns>STATUS</returns>
        //private int SearchStockMoveSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,  // DEL 2011/11/30
        //    SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)   // DEL 2011/11/30
        //private int SearchStockMoveSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, SqlConnection sqlConnection,  // ADD 2011/11/30 // DEL 2011/12/06
        //    SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)  // ADD 2011/11/30 // DEL 2011/12/06
        private int SearchStockMoveSCMProc(Int32 sendMesExtraConDiv, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, Int64 syncExecDate, Int64 endingDateTicks, SqlConnection sqlConnection,  // ADD 2011/12/06
            SqlTransaction sqlTransaction, out ArrayList stockMoveArrList, out string retMessage, string sectionCode)  // ADD 2011/12/06	
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			stockMoveArrList = new ArrayList();
			retMessage = string.Empty;
			string sqlStr = string.Empty;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
     
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WHERE UPDATESECCDRF=@FINDUPDATESECCD";

                //データ送信抽出条件区分が「差分」の場合
                if (sendMesExtraConDiv == 0)
                {
                    //在庫移動データ.更新日時
                    sqlStr = sqlStr + " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                }
                //データ送信抽出条件区分が「伝票日付」の場合
                else if (sendMesExtraConDiv == 1)
                {
                    //在庫移動データ.入荷日
                    //sqlStr = sqlStr + " AND ARRIVALGOODSDAYRF >= @UPDATEDATETIMEBEGRF AND ARRIVALGOODSDAYRF <= @UPDATEDATETIMEENDRF";   // DEL 2011/11/30
                    sqlStr = sqlStr + " AND (( ARRIVALGOODSDAYRF >= @UPDATEDATETIMEBEGRF AND ARRIVALGOODSDAYRF <= @UPDATEDATETIMEENDRF)"; // ADD 2011/11/30

                    // ----- ADD 2011/11/30 tanh---------->>>>>
                    // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                    //sqlStr = sqlStr + " OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ";
                    sqlStr = sqlStr + " OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ";
                    // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                    sqlStr = sqlStr + " AND  UPDATEDATETIMERF<=@FINDENDTIMERF ";
                    sqlStr = sqlStr + " AND  ARRIVALGOODSDAYRF<=@UPDATEDATETIMEENDRF )) ";
                    // ----- ADD 2011/11/30 tanh----------<<<<<<
                } 

				//Prameterオブジェクトの作成
				SqlParameter findParaUpdSecCode = sqlCommand.Parameters.Add("@FINDUPDATESECCD", SqlDbType.NChar);
				SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
				SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

				//Parameterオブジェクトへ値設定
				findParaUpdSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
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

				// 在庫移動データ用SQL
				sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 読み込み
				myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
				{
					stockMoveArrList.Add(CopyToStockMoveWorkFromReader(ref myReader));
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "APStockMoveDB.SearchStockMove Exception=" + ex.Message);
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
		/// クラス格納処理 Reader → depositAlwWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APStockMoveWork CopyToStockMoveWorkFromReader(ref SqlDataReader myReader)
		{
			APStockMoveWork stockMoveWork = new APStockMoveWork();

			this.CopyToStockMoveWorkFromReader(ref myReader, ref stockMoveWork);

			return stockMoveWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockMoveWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockMoveWork">stockMoveWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyToStockMoveWorkFromReader(ref SqlDataReader myReader, ref APStockMoveWork stockMoveWork)
		{
			if (myReader != null && stockMoveWork != null)
			{
				# region クラスへ格納
				stockMoveWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockMoveWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockMoveWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockMoveWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockMoveWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockMoveWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockMoveWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockMoveWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockMoveWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
				stockMoveWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
				stockMoveWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
				stockMoveWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
				stockMoveWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
				stockMoveWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
				stockMoveWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
				stockMoveWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
				stockMoveWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
				stockMoveWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
				stockMoveWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
				stockMoveWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
				stockMoveWork.ShipmentScdlDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
				stockMoveWork.ShipmentFixDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
				stockMoveWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
				stockMoveWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				stockMoveWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
				stockMoveWork.StockMvEmpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
				stockMoveWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
				stockMoveWork.ShipAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTCDRF"));
				stockMoveWork.ShipAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTNMRF"));
				stockMoveWork.ReceiveAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTCDRF"));
				stockMoveWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
				stockMoveWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
				stockMoveWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
				stockMoveWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
				stockMoveWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
				stockMoveWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
				stockMoveWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
				stockMoveWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
				stockMoveWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
				stockMoveWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
				stockMoveWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
				stockMoveWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
				stockMoveWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
				stockMoveWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
				stockMoveWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
				stockMoveWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
				stockMoveWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
				stockMoveWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
				stockMoveWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
				stockMoveWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
				stockMoveWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));

				# endregion
			}
		}

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}