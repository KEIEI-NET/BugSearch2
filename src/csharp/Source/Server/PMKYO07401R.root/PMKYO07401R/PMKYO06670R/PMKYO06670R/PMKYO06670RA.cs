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
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫受払履歴データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫受払履歴データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockAcPayHistDB : RemoteDB
    {
        /// <summary>
        /// 在庫受払履歴データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockAcPayHistDB()
            : base("PMKYO07611D", "Broadleaf.Application.Remoting.ParamData.DCStockAcPayHistWork", "STOCKACPAYHISTRF")
        {

        }

        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
        # region [Read]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫調整データ取得
        /// </summary>
        /// <param name="stockAcPayHistList">在庫調整データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList stockAcPayHistList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockAcPayHistList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫調整データ取得
        /// </summary>
        /// <param name="stockAcPayHistList">在庫調整データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockAcPayHistList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockAcPayHistList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, IOGOODSDAYRF, ADDUPADATERF, ACPAYSLIPCDRF, ACPAYSLIPNUMRF, ACPAYSLIPROWNORF, ACPAYHISTDATETIMERF, ACPAYTRANSCDRF, INPUTSECTIONCDRF, INPUTSECTIONGUIDNMRF, INPUTAGENCDRF, INPUTAGENNMRF, MOVESTATUSRF, CUSTSLIPNORF, SLIPDTLNUMRF, ACPAYNOTERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, SECTIONCODERF, SECTIONGUIDENMRF, WAREHOUSECODERF, WAREHOUSENAMERF, SHELFNORF, BFSECTIONCODERF, BFSECTIONGUIDENMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, BFSHELFNORF, AFSECTIONCODERF, AFSECTIONGUIDENMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, AFSHELFNORF, CUSTOMERCODERF, CUSTOMERSNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, ARRIVALCNTRF, SHIPMENTCNTRF, OPENPRICEDIVRF, LISTPRICETAXEXCFLRF, STOCKUNITPRICEFLRF, STOCKPRICERF, SALESUNPRCTAXEXCFLRF, SALESMONEYRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, SALESORDERCOUNTRF, MOVINGSUPLISTOCKRF, NONADDUPSHIPMCNTRF, NONADDUPARRGDSCNTRF, SHIPMENTPOSCNTRF, PRESENTSTOCKCNTRF FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, IOGOODSDAYRF, ADDUPADATERF, ACPAYSLIPCDRF, ACPAYSLIPNUMRF, ACPAYSLIPROWNORF, ACPAYHISTDATETIMERF, ACPAYTRANSCDRF, INPUTSECTIONCDRF, INPUTSECTIONGUIDNMRF, INPUTAGENCDRF, INPUTAGENNMRF, MOVESTATUSRF, CUSTSLIPNORF, SLIPDTLNUMRF, ACPAYNOTERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, SECTIONCODERF, SECTIONGUIDENMRF, WAREHOUSECODERF, WAREHOUSENAMERF, SHELFNORF, BFSECTIONCODERF, BFSECTIONGUIDENMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, BFSHELFNORF, AFSECTIONCODERF, AFSECTIONGUIDENMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, AFSHELFNORF, CUSTOMERCODERF, CUSTOMERSNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, ARRIVALCNTRF, SHIPMENTCNTRF, OPENPRICEDIVRF, LISTPRICETAXEXCFLRF, STOCKUNITPRICEFLRF, STOCKPRICERF, SALESUNPRCTAXEXCFLRF, SALESMONEYRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, SALESORDERCOUNTRF, MOVINGSUPLISTOCKRF, NONADDUPSHIPMCNTRF, NONADDUPARRGDSCNTRF, SHIPMENTPOSCNTRF, PRESENTSTOCKCNTRF FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND SECTIONCODERF=@FINDSECTIONCODE";
			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
			//SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
			//findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

            // SQL文
			sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                stockAcPayHistList.Add(this.CopyToStockAcPayHistWorkFromReader(ref myReader));
            }

            if (stockAcPayHistList.Count > 0)
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
        /// クラス格納処理 Reader → stockAcPayHistWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockAcPayHistWork CopyToStockAcPayHistWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockAcPayHistWork stockAcPayHistWork = new DCStockAcPayHistWork();

            this.CopyToStockAcPayHistWorkFromReader(ref myReader, ref stockAcPayHistWork);

            return stockAcPayHistWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → stockAcPayHistWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockAcPayHistWork">stockAcPayHistWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToStockAcPayHistWorkFromReader(ref SqlDataReader myReader, ref DCStockAcPayHistWork stockAcPayHistWork)
        {
            if (myReader != null && stockAcPayHistWork != null)
            {
                # region クラスへ格納
                stockAcPayHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                stockAcPayHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                stockAcPayHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                stockAcPayHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                stockAcPayHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                stockAcPayHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                stockAcPayHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                stockAcPayHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IOGOODSDAYRF"));
                stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                stockAcPayHistWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
                stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
                stockAcPayHistWork.AcPayHistDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPAYHISTDATETIMERF"));
                stockAcPayHistWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCDRF"));
                stockAcPayHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONGUIDNMRF"));
                stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                stockAcPayHistWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
                stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
                stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
                stockAcPayHistWork.AcPayNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYNOTERF"));
                stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                stockAcPayHistWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
                stockAcPayHistWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                stockAcPayHistWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDENMRF"));
                stockAcPayHistWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                stockAcPayHistWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                stockAcPayHistWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                stockAcPayHistWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                stockAcPayHistWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDENMRF"));
                stockAcPayHistWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                stockAcPayHistWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                stockAcPayHistWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
                stockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                stockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                stockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                stockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                stockAcPayHistWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICERF"));
                stockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                stockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
                stockAcPayHistWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                stockAcPayHistWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                stockAcPayHistWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                stockAcPayHistWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                stockAcPayHistWork.NonAddUpShipmCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPSHIPMCNTRF"));
                stockAcPayHistWork.NonAddUpArrGdsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPARRGDSCNTRF"));
                stockAcPayHistWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                stockAcPayHistWork.PresentStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRESENTSTOCKCNTRF"));
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫受払履歴データ削除
        /// </summary>
        /// <param name="dcStockAcPayHistWorkList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockAcPayHistWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫受払履歴データ削除
        /// </summary>
        /// <param name="dcStockAcPayHistWorkList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockAcPayHistWork dcStockAcPayHistWork in dcStockAcPayHistWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM STOCKACPAYHISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO AND ACPAYHISTDATETIMERF=@FINDACPAYHISTDATETIME AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                SqlParameter findParaAcPayHistDateTime = sqlCommand.Parameters.Add("@FINDACPAYHISTDATETIME", SqlDbType.BigInt);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcStockAcPayHistWork.EnterpriseCode;
                findParaAcPaySlipCd.Value = dcStockAcPayHistWork.AcPaySlipCd;
                findParaAcPaySlipNum.Value = dcStockAcPayHistWork.AcPaySlipNum;
                findParaAcPaySlipRowNo.Value = dcStockAcPayHistWork.AcPaySlipRowNo;
                findParaAcPayHistDateTime.Value = dcStockAcPayHistWork.AcPayHistDateTime;
                findParaGoodsMakerCd.Value = dcStockAcPayHistWork.GoodsMakerCd;
                findParaGoodsNo.Value = dcStockAcPayHistWork.GoodsNo;
                findParaWarehouseCode.Value = dcStockAcPayHistWork.WarehouseCode;

                // 在庫受払履歴データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫受払履歴データ登録
        /// </summary>
        /// <param name="dcStockAcPayHistWorkList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockAcPayHistWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫受払履歴データ登録
        /// </summary>
        /// <param name="dcStockAcPayHistWorkList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockAcPayHistWork dcStockAcPayHistWork in dcStockAcPayHistWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Insertコマンドの生成
                sqlCommand.CommandText = "INSERT INTO STOCKACPAYHISTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, IOGOODSDAYRF, ADDUPADATERF, ACPAYSLIPCDRF, ACPAYSLIPNUMRF, ACPAYSLIPROWNORF, ACPAYHISTDATETIMERF, ACPAYTRANSCDRF, INPUTSECTIONCDRF, INPUTSECTIONGUIDNMRF, INPUTAGENCDRF, INPUTAGENNMRF, MOVESTATUSRF, CUSTSLIPNORF, SLIPDTLNUMRF, ACPAYNOTERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, SECTIONCODERF, SECTIONGUIDENMRF, WAREHOUSECODERF, WAREHOUSENAMERF, SHELFNORF, BFSECTIONCODERF, BFSECTIONGUIDENMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, BFSHELFNORF, AFSECTIONCODERF, AFSECTIONGUIDENMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, AFSHELFNORF, CUSTOMERCODERF, CUSTOMERSNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, ARRIVALCNTRF, SHIPMENTCNTRF, OPENPRICEDIVRF, LISTPRICETAXEXCFLRF, STOCKUNITPRICEFLRF, STOCKPRICERF, SALESUNPRCTAXEXCFLRF, SALESMONEYRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, SALESORDERCOUNTRF, MOVINGSUPLISTOCKRF, NONADDUPSHIPMCNTRF, NONADDUPARRGDSCNTRF, SHIPMENTPOSCNTRF, PRESENTSTOCKCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @IOGOODSDAY, @ADDUPADATE, @ACPAYSLIPCD, @ACPAYSLIPNUM, @ACPAYSLIPROWNO, @ACPAYHISTDATETIME, @ACPAYTRANSCD, @INPUTSECTIONCD, @INPUTSECTIONGUIDNM, @INPUTAGENCD, @INPUTAGENNM, @MOVESTATUS, @CUSTSLIPNO, @SLIPDTLNUM, @ACPAYNOTE, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @SECTIONCODE, @SECTIONGUIDENM, @WAREHOUSECODE, @WAREHOUSENAME, @SHELFNO, @BFSECTIONCODE, @BFSECTIONGUIDENM, @BFENTERWAREHCODE, @BFENTERWAREHNAME, @BFSHELFNO, @AFSECTIONCODE, @AFSECTIONGUIDENM, @AFENTERWAREHCODE, @AFENTERWAREHNAME, @AFSHELFNO, @CUSTOMERCODE, @CUSTOMERSNM, @SUPPLIERCD, @SUPPLIERSNM, @ARRIVALCNT, @SHIPMENTCNT, @OPENPRICEDIV, @LISTPRICETAXEXCFL, @STOCKUNITPRICEFL, @STOCKPRICE, @SALESUNPRCTAXEXCFL, @SALESMONEY, @SUPPLIERSTOCK, @ACPODRCOUNT, @SALESORDERCOUNT, @MOVINGSUPLISTOCK, @NONADDUPSHIPMCNT, @NONADDUPARRGDSCNT, @SHIPMENTPOSCNT, @PRESENTSTOCKCNT)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraIoGoodsDay = sqlCommand.Parameters.Add("@IOGOODSDAY", SqlDbType.Int);
                SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@ACPAYSLIPNUM", SqlDbType.NVarChar);
                SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@ACPAYSLIPROWNO", SqlDbType.Int);
                SqlParameter paraAcPayHistDateTime = sqlCommand.Parameters.Add("@ACPAYHISTDATETIME", SqlDbType.BigInt);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraInputSectionCd = sqlCommand.Parameters.Add("@INPUTSECTIONCD", SqlDbType.NChar);
                SqlParameter paraInputSectionGuidNm = sqlCommand.Parameters.Add("@INPUTSECTIONGUIDNM", SqlDbType.NVarChar);
                SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
                SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
                SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
                SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.NVarChar);
                SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraAcPayNote = sqlCommand.Parameters.Add("@ACPAYNOTE", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                SqlParameter paraShelfNo = sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
                SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraBfSectionGuideNm = sqlCommand.Parameters.Add("@BFSECTIONGUIDENM", SqlDbType.NChar);
                SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraAfSectionGuideNm = sqlCommand.Parameters.Add("@AFSECTIONGUIDENM", SqlDbType.NChar);
                SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraStockPrice = sqlCommand.Parameters.Add("@STOCKPRICE", SqlDbType.BigInt);
                SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
                SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                SqlParameter paraNonAddUpShipmCnt = sqlCommand.Parameters.Add("@NONADDUPSHIPMCNT", SqlDbType.Float);
                SqlParameter paraNonAddUpArrGdsCnt = sqlCommand.Parameters.Add("@NONADDUPARRGDSCNT", SqlDbType.Float);
                SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                SqlParameter paraPresentStockCnt = sqlCommand.Parameters.Add("@PRESENTSTOCKCNT", SqlDbType.Float);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockAcPayHistWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockAcPayHistWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockAcPayHistWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.LogicalDeleteCode);
                paraIoGoodsDay.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.IoGoodsDay);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockAcPayHistWork.AddUpADate);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.AcPaySlipCd);
                paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AcPaySlipNum);
                paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.AcPaySlipRowNo);
                paraAcPayHistDateTime.Value = SqlDataMediator.SqlSetInt64(dcStockAcPayHistWork.AcPayHistDateTime);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.AcPayTransCd);
                paraInputSectionCd.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.InputSectionCd);
                paraInputSectionGuidNm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.InputSectionGuidNm);
                paraInputAgenCd.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.InputAgenCd);
                paraInputAgenNm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.InputAgenNm);
                paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.MoveStatus);
                paraCustSlipNo.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.CustSlipNo);
                paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dcStockAcPayHistWork.SlipDtlNum);
                paraAcPayNote.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AcPayNote);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.GoodsName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.BLGoodsFullName);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.SectionCode);
                paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.SectionGuideNm);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.WarehouseName);
                paraShelfNo.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.ShelfNo);
                paraBfSectionCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.BfSectionCode);
                paraBfSectionGuideNm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.BfSectionGuideNm);
                paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.BfEnterWarehCode);
                paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.BfEnterWarehName);
                paraBfShelfNo.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.BfShelfNo);
                paraAfSectionCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AfSectionCode);
                paraAfSectionGuideNm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AfSectionGuideNm);
                paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AfEnterWarehCode);
                paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AfEnterWarehName);
                paraAfShelfNo.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.AfShelfNo);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.CustomerCode);
                paraCustomerSnm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.CustomerSnm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcStockAcPayHistWork.SupplierSnm);
                paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.ArrivalCnt);
                paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.ShipmentCnt);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(dcStockAcPayHistWork.OpenPriceDiv);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.ListPriceTaxExcFl);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.StockUnitPriceFl);
                paraStockPrice.Value = SqlDataMediator.SqlSetInt64(dcStockAcPayHistWork.StockPrice);
                paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.SalesUnPrcTaxExcFl);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(dcStockAcPayHistWork.SalesMoney);
                paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.SupplierStock);
                paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.AcpOdrCount);
                paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.SalesOrderCount);
                paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.MovingSupliStock);
                paraNonAddUpShipmCnt.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.NonAddUpShipmCnt);
                paraNonAddUpArrGdsCnt.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.NonAddUpArrGdsCnt);
                paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.ShipmentPosCnt);
                paraPresentStockCnt.Value = SqlDataMediator.SqlSetDouble(dcStockAcPayHistWork.PresentStockCnt);

                // 在庫受払履歴データを登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        */
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion
    }
}
