//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/18  修正内容 : Redmine#23746
//                                  違う企業コード間の送受信についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : dingjx
// 修 正 日  2011/11/01 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 脇田 靖之
// 修 正 日  2014/03/26  修正内容 : 仕掛一覧№2292対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫調整明細データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫調整明細データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockAdjustDtlDB : RemoteDB
    {
        /// <summary>
        /// 在庫調整明細データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockAdjustDtlDB()
            : base("PMKYO07591D", "Broadleaf.Application.Remoting.ParamData.DCStockAdjustDtlWork", "STOCKADJUSTDTLRF")
        {

        }

        # region [Read]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整データ取得
        /// </summary>
        /// <param name="stockAdjustDtlList">在庫調整データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList stockAdjustDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockAdjustDtlList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データ取得
        /// </summary>
        /// <param name="stockAdjustDtlList">在庫調整データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockAdjustDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockAdjustDtlList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //  ADD dingjx  2011/11/01  -------------------------------->>>>>>
            if ((receiveDataWork.Kind == 0) && (receiveDataWork.SndLogExtraCondDiv == 1))
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WITH (READUNCOMMITTED) WHERE ADJUSTDATERF>=@FINDUPDATESTARTDATETIME AND ADJUSTDATERF<=@FINDUPDATEENDDATETIME AND  SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // DEL 2011/11/30
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WITH (READUNCOMMITTED) WHERE ((ADJUSTDATERF>=@FINDUPDATESTARTDATETIME AND ADJUSTDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>=@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  ADJUSTDATERF<=@FINDUPDATEENDDATETIME)) AND  SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // ADD 2011/11/30
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WITH (READUNCOMMITTED) WHERE ((ADJUSTDATERF>=@FINDUPDATESTARTDATETIME AND ADJUSTDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  ADJUSTDATERF<=@FINDUPDATEENDDATETIME)) AND  SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
            else
            //  ADD dingjx  2011/11/01  --------------------------------<<<<<<
			    // UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			    //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF FROM STOCKADJUSTDTLRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND  SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			    // UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);// ADD 2011/08/18 張莉莉　Redmine#23746
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 張莉莉　Redmine#23746
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //データ送信抽出条件区分が「伝票区分」の場合
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = receiveDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                findParaEndTime.Value = receiveDataWork.EndDateTimeTicks;
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

            // SQL文
			sqlCommand.CommandText = sqlText;

            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                stockAdjustDtlList.Add(this.CopyToStockAdjustDtlWorkFromReader(ref myReader));
            }

            if (stockAdjustDtlList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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

        /// <summary>
        /// クラス格納処理 Reader → stockAdjustDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockAdjustDtlWork CopyToStockAdjustDtlWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockAdjustDtlWork stockAdjustDtlWork = new DCStockAdjustDtlWork();

            this.CopyToStockAdjustDtlWorkFromReader(ref myReader, ref stockAdjustDtlWork);

            return stockAdjustDtlWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → stockAdjustDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockAdjustDtlWork">stockAdjustDtlWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToStockAdjustDtlWorkFromReader(ref SqlDataReader myReader, ref DCStockAdjustDtlWork stockAdjustDtlWork)
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

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整明細データ削除
        /// </summary>
        /// <param name="dcStockAdjustDtlWorkList">在庫調整明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockAdjustDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整明細データ削除
        /// </summary>
        /// <param name="dcStockAdjustDtlWorkList">在庫調整明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockAdjustDtlWork dcStockAdjustDtlWork in dcStockAdjustDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcStockAdjustDtlWork.EnterpriseCode;
                findParaStockAdjustSlipNo.Value = dcStockAdjustDtlWork.StockAdjustSlipNo;
                findParaStockAdjustRowNo.Value = dcStockAdjustDtlWork.StockAdjustRowNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 在庫調整明細データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整明細データ登録
        /// </summary>
        /// <param name="dcStockAdjustDtlWorkList">在庫調整明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockAdjustDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整明細データ登録
        /// </summary>
        /// <param name="dcStockAdjustDtlWorkList">在庫調整明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockAdjustDtlWork dcStockAdjustDtlWork in dcStockAdjustDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Insertコマンドの生成
                sqlCommand.CommandText = "INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)";

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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockAdjustDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockAdjustDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockAdjustDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.SectionCode);
                paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.StockAdjustSlipNo);
                paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.StockAdjustRowNo);
                paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.SupplierFormalSrc);
                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(dcStockAdjustDtlWork.StockSlipDtlNumSrc);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.AcPaySlipCd);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.AcPayTransCd);
                paraAdjustDate.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.AdjustDate);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.InputDay);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.GoodsName);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockAdjustDtlWork.StockUnitPriceFl);
                paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockAdjustDtlWork.BfStockUnitPriceFl);
                paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(dcStockAdjustDtlWork.AdjustCount);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.DtlNote);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.WarehouseName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.BLGoodsFullName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(dcStockAdjustDtlWork.WarehouseShelfNo);
                paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockAdjustDtlWork.ListPriceFl);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustDtlWork.OpenPriceDiv);
                paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(dcStockAdjustDtlWork.StockPriceTaxExc);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 在庫調整明細データを登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		# region [Clear]
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			//sqlCommand.CommandText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
            sqlCommand.CommandText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF = @FINDSECTIONCODERF";
          
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameterオブジェクトへ値設定
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // 売上データを削除する
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 張莉莉 ----------<<<<<
    }
}
