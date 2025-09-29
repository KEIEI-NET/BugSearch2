//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信処理　                           　 //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06460R.DLL							        //
// Programmer       :   呉元嘯	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2009.06.12　							//
//                  :   public MethodでSQL文字が駄目対応について        //
//----------------------------------------------------------------------//
// Update Note      :   孫東響　2011.07.26　							//
//                  :   SCM対応-拠点管理（10704767-00）                 //
//----------------------------------------------------------------------//
// Update Note      :   馮文雄　2011.08.20　							//
//                  :   myReaderからDクラスへ項目転記を行っている個所   //
//                  :   はメソッド化する                                //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2011.08.26　							//
//                  :   DC履歴ログとDC各データのクリア処理を追加        //
//----------------------------------------------------------------------//
// Update Note      :   孫東響　2011.09.08　							//
//                  :   #23777 ソースレビュー                           //
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
    /// 仕入先マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタデータの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCSupplierDB : RemoteDB
    {
        #region [Private]
        //ADD 2011/09/08 sundx #23777 ソースレビュー ----------------------------->>>>>
        private int _createDateTime = 0;
        private int _updateDateTime = 0;
        private int _enterpriseCode = 0;
        private int _fileHeaderGuid = 0;
        private int _updEmployeeCode = 0;
        private int _updAssemblyId1 = 0;
        private int _updAssemblyId2 = 0;
        private int _logicalDeleteCode = 0;
        private int _supplierCd = 0;
        private int _mngSectionCode = 0;
        private int _inpSectionCode = 0;
        private int _paymentSectionCode = 0;
        private int _supplierNm1 = 0;
        private int _supplierNm2 = 0;
        private int _suppHonorificTitle = 0;
        private int _supplierKana = 0;
        private int _supplierSnm = 0;
        private int _orderHonorificTtl = 0;
        private int _businessTypeCode = 0;
        private int _salesAreaCode = 0;
        private int _supplierPostNo = 0;
        private int _supplierAddr1 = 0;
        private int _supplierAddr3 = 0;
        private int _supplierAddr4 = 0;
        private int _supplierTelNo = 0;
        private int _supplierTelNo1 = 0;
        private int _supplierTelNo2 = 0;
        private int _pureCode = 0;
        private int _paymentMonthCode = 0;
        private int _paymentMonthName = 0;
        private int _paymentDay = 0;
        private int _suppCTaxLayRefCd = 0;
        private int _suppCTaxLayCd = 0;
        private int _suppCTaxationCd = 0;
        private int _suppEnterpriseCd = 0;
        private int _payeeCode = 0;
        private int _supplierAttributeDiv = 0;
        private int _suppTtlAmntDspWayCd = 0;
        private int _stckTtlAmntDspWayRef = 0;
        private int _paymentCond = 0;
        private int _paymentTotalDay = 0;
        private int _paymentSight = 0;
        private int _stockAgentCode = 0;
        private int _stockUnPrcFrcProcCd = 0;
        private int _stockMoneyFrcProcCd = 0;
        private int _stockCnsTaxFrcProcCd = 0;
        private int _nTimeCalcStDate = 0;
        private int _supplierNote1 = 0;
        private int _supplierNote2 = 0;
        private int _supplierNote3 = 0;
        private int _supplierNote4 = 0;
        //ADD 2011/09/08 sundx #23777 ソースレビュー -----------------------------<<<<<
        #endregion

        /// <summary>
        /// 仕入先マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCSupplierDB()
            : base("PMKYO06461D", "Broadleaf.Application.Remoting.ParamData.DCSupplierWork", "SUPPLIERRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 仕入先マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="supplierArrList">仕入先マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchSupplier(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList supplierArrList, out string retMessage)
        {
            return SearchSupplierProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                  sqlTransaction, out supplierArrList, out retMessage);
        }
        /// <summary>
        /// 仕入先マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="supplierArrList">仕入先マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchSupplierProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList supplierArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            supplierArrList = new ArrayList();
            DCSupplierWork supplierWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERCDRF, MNGSECTIONCODERF, INPSECTIONCODERF, PAYMENTSECTIONCODERF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPHONORIFICTITLERF, SUPPLIERKANARF, SUPPLIERSNMRF, ORDERHONORIFICTTLRF, BUSINESSTYPECODERF, SALESAREACODERF, SUPPLIERPOSTNORF, SUPPLIERADDR1RF, SUPPLIERADDR3RF, SUPPLIERADDR4RF, SUPPLIERTELNORF, SUPPLIERTELNO1RF, SUPPLIERTELNO2RF, PURECODERF, PAYMENTMONTHCODERF, PAYMENTMONTHNAMERF, PAYMENTDAYRF, SUPPCTAXLAYREFCDRF, SUPPCTAXLAYCDRF, SUPPCTAXATIONCDRF, SUPPENTERPRISECDRF, PAYEECODERF, SUPPLIERATTRIBUTEDIVRF, SUPPTTLAMNTDSPWAYCDRF, STCKTTLAMNTDSPWAYREFRF, PAYMENTCONDRF, PAYMENTTOTALDAYRF, PAYMENTSIGHTRF, STOCKAGENTCODERF, STOCKUNPRCFRCPROCCDRF, STOCKMONEYFRCPROCCDRF, STOCKCNSTAXFRCPROCCDRF, NTIMECALCSTDATERF, SUPPLIERNOTE1RF, SUPPLIERNOTE2RF, SUPPLIERNOTE3RF, SUPPLIERNOTE4RF FROM SUPPLIERRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //仕入先マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    supplierWork = new DCSupplierWork();

                    supplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    supplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    supplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    supplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    supplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    supplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    supplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    supplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    supplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    supplierWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    supplierWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                    supplierWork.PaymentSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    supplierWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    supplierWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    supplierWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
                    supplierWork.SupplierKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
                    supplierWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    supplierWork.OrderHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERHONORIFICTTLRF"));
                    supplierWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    supplierWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    supplierWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERPOSTNORF"));
                    supplierWork.SupplierAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR1RF"));
                    supplierWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR3RF"));
                    supplierWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR4RF"));
                    supplierWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNORF"));
                    supplierWork.SupplierTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO1RF"));
                    supplierWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO2RF"));
                    supplierWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    supplierWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"));
                    supplierWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                    supplierWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                    supplierWork.SuppCTaxLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYREFCDRF"));
                    supplierWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    supplierWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXATIONCDRF"));
                    supplierWork.SuppEnterpriseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPENTERPRISECDRF"));
                    supplierWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    supplierWork.SupplierAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERATTRIBUTEDIVRF"));
                    supplierWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                    supplierWork.StckTtlAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKTTLAMNTDSPWAYREFRF"));
                    supplierWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                    supplierWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                    supplierWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSIGHTRF"));
                    supplierWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    supplierWork.StockUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNPRCFRCPROCCDRF"));
                    supplierWork.StockMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMONEYFRCPROCCDRF"));
                    supplierWork.StockCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCNSTAXFRCPROCCDRF"));
                    supplierWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                    supplierWork.SupplierNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
                    supplierWork.SupplierNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
                    supplierWork.SupplierNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
                    supplierWork.SupplierNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));

                    supplierArrList.Add(supplierWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCSupplierDB.SearchSupplier Exception=" + ex.Message);
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
        ///  仕入先マスタデータ削除
        /// </summary>
        /// <param name="dcSupplierWork">仕入先マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 仕入先マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCSupplierWork dcSupplierWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcSupplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  仕入先マスタデータ削除
        /// </summary>
        /// <param name="dcSupplierWork">仕入先マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 仕入先マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCSupplierWork dcSupplierWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM SUPPLIERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcSupplierWork.EnterpriseCode;
            findParaSupplierCd.Value = dcSupplierWork.SupplierCd;

            // 仕入先マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 仕入先マスタ登録
        /// </summary>
        /// <param name="dcSupplierWork">仕入先マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 仕入先マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCSupplierWork dcSupplierWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcSupplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 仕入先マスタ登録
        /// </summary>
        /// <param name="dcSupplierWork">仕入先マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 仕入先マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCSupplierWork dcSupplierWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO SUPPLIERRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERCDRF, MNGSECTIONCODERF, INPSECTIONCODERF, PAYMENTSECTIONCODERF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPHONORIFICTITLERF, SUPPLIERKANARF, SUPPLIERSNMRF, ORDERHONORIFICTTLRF, BUSINESSTYPECODERF, SALESAREACODERF, SUPPLIERPOSTNORF, SUPPLIERADDR1RF, SUPPLIERADDR3RF, SUPPLIERADDR4RF, SUPPLIERTELNORF, SUPPLIERTELNO1RF, SUPPLIERTELNO2RF, PURECODERF, PAYMENTMONTHCODERF, PAYMENTMONTHNAMERF, PAYMENTDAYRF, SUPPCTAXLAYREFCDRF, SUPPCTAXLAYCDRF, SUPPCTAXATIONCDRF, SUPPENTERPRISECDRF, PAYEECODERF, SUPPLIERATTRIBUTEDIVRF, SUPPTTLAMNTDSPWAYCDRF, STCKTTLAMNTDSPWAYREFRF, PAYMENTCONDRF, PAYMENTTOTALDAYRF, PAYMENTSIGHTRF, STOCKAGENTCODERF, STOCKUNPRCFRCPROCCDRF, STOCKMONEYFRCPROCCDRF, STOCKCNSTAXFRCPROCCDRF, NTIMECALCSTDATERF, SUPPLIERNOTE1RF, SUPPLIERNOTE2RF, SUPPLIERNOTE3RF, SUPPLIERNOTE4RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUPPLIERCD, @MNGSECTIONCODE, @INPSECTIONCODE, @PAYMENTSECTIONCODE, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPHONORIFICTITLE, @SUPPLIERKANA, @SUPPLIERSNM, @ORDERHONORIFICTTL, @BUSINESSTYPECODE, @SALESAREACODE, @SUPPLIERPOSTNO, @SUPPLIERADDR1, @SUPPLIERADDR3, @SUPPLIERADDR4, @SUPPLIERTELNO, @SUPPLIERTELNO1, @SUPPLIERTELNO2, @PURECODE, @PAYMENTMONTHCODE, @PAYMENTMONTHNAME, @PAYMENTDAY, @SUPPCTAXLAYREFCD, @SUPPCTAXLAYCD, @SUPPCTAXATIONCD, @SUPPENTERPRISECD, @PAYEECODE, @SUPPLIERATTRIBUTEDIV, @SUPPTTLAMNTDSPWAYCD, @STCKTTLAMNTDSPWAYREF, @PAYMENTCOND, @PAYMENTTOTALDAY, @PAYMENTSIGHT, @STOCKAGENTCODE, @STOCKUNPRCFRCPROCCD, @STOCKMONEYFRCPROCCD, @STOCKCNSTAXFRCPROCCD, @NTIMECALCSTDATE, @SUPPLIERNOTE1, @SUPPLIERNOTE2, @SUPPLIERNOTE3, @SUPPLIERNOTE4)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraPaymentSectionCode = sqlCommand.Parameters.Add("@PAYMENTSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
            SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
            SqlParameter paraSuppHonorificTitle = sqlCommand.Parameters.Add("@SUPPHONORIFICTITLE", SqlDbType.NVarChar);
            SqlParameter paraSupplierKana = sqlCommand.Parameters.Add("@SUPPLIERKANA", SqlDbType.NVarChar);
            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
            SqlParameter paraOrderHonorificTtl = sqlCommand.Parameters.Add("@ORDERHONORIFICTTL", SqlDbType.NVarChar);
            SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
            SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
            SqlParameter paraSupplierPostNo = sqlCommand.Parameters.Add("@SUPPLIERPOSTNO", SqlDbType.NVarChar);
            SqlParameter paraSupplierAddr1 = sqlCommand.Parameters.Add("@SUPPLIERADDR1", SqlDbType.NVarChar);
            SqlParameter paraSupplierAddr3 = sqlCommand.Parameters.Add("@SUPPLIERADDR3", SqlDbType.NVarChar);
            SqlParameter paraSupplierAddr4 = sqlCommand.Parameters.Add("@SUPPLIERADDR4", SqlDbType.NVarChar);
            SqlParameter paraSupplierTelNo = sqlCommand.Parameters.Add("@SUPPLIERTELNO", SqlDbType.NVarChar);
            SqlParameter paraSupplierTelNo1 = sqlCommand.Parameters.Add("@SUPPLIERTELNO1", SqlDbType.NVarChar);
            SqlParameter paraSupplierTelNo2 = sqlCommand.Parameters.Add("@SUPPLIERTELNO2", SqlDbType.NVarChar);
            SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
            SqlParameter paraPaymentMonthCode = sqlCommand.Parameters.Add("@PAYMENTMONTHCODE", SqlDbType.Int);
            SqlParameter paraPaymentMonthName = sqlCommand.Parameters.Add("@PAYMENTMONTHNAME", SqlDbType.NVarChar);
            SqlParameter paraPaymentDay = sqlCommand.Parameters.Add("@PAYMENTDAY", SqlDbType.Int);
            SqlParameter paraSuppCTaxLayRefCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYREFCD", SqlDbType.Int);
            SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
            SqlParameter paraSuppCTaxationCd = sqlCommand.Parameters.Add("@SUPPCTAXATIONCD", SqlDbType.Int);
            SqlParameter paraSuppEnterpriseCd = sqlCommand.Parameters.Add("@SUPPENTERPRISECD", SqlDbType.NChar);
            SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
            SqlParameter paraSupplierAttributeDiv = sqlCommand.Parameters.Add("@SUPPLIERATTRIBUTEDIV", SqlDbType.Int);
            SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);
            SqlParameter paraStckTtlAmntDspWayRef = sqlCommand.Parameters.Add("@STCKTTLAMNTDSPWAYREF", SqlDbType.Int);
            SqlParameter paraPaymentCond = sqlCommand.Parameters.Add("@PAYMENTCOND", SqlDbType.Int);
            SqlParameter paraPaymentTotalDay = sqlCommand.Parameters.Add("@PAYMENTTOTALDAY", SqlDbType.Int);
            SqlParameter paraPaymentSight = sqlCommand.Parameters.Add("@PAYMENTSIGHT", SqlDbType.Int);
            SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
            SqlParameter paraStockUnPrcFrcProcCd = sqlCommand.Parameters.Add("@STOCKUNPRCFRCPROCCD", SqlDbType.Int);
            SqlParameter paraStockMoneyFrcProcCd = sqlCommand.Parameters.Add("@STOCKMONEYFRCPROCCD", SqlDbType.Int);
            SqlParameter paraStockCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@STOCKCNSTAXFRCPROCCD", SqlDbType.Int);
            SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
            SqlParameter paraSupplierNote1 = sqlCommand.Parameters.Add("@SUPPLIERNOTE1", SqlDbType.NVarChar);
            SqlParameter paraSupplierNote2 = sqlCommand.Parameters.Add("@SUPPLIERNOTE2", SqlDbType.NVarChar);
            SqlParameter paraSupplierNote3 = sqlCommand.Parameters.Add("@SUPPLIERNOTE3", SqlDbType.NVarChar);
            SqlParameter paraSupplierNote4 = sqlCommand.Parameters.Add("@SUPPLIERNOTE4", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSupplierWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSupplierWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcSupplierWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcSupplierWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcSupplierWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcSupplierWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcSupplierWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.LogicalDeleteCode);
            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SupplierCd);
            paraMngSectionCode.Value = SqlDataMediator.SqlSetString(dcSupplierWork.MngSectionCode);
            paraInpSectionCode.Value = SqlDataMediator.SqlSetString(dcSupplierWork.InpSectionCode);
            paraPaymentSectionCode.Value = SqlDataMediator.SqlSetString(dcSupplierWork.PaymentSectionCode);
            paraSupplierNm1.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierNm1);
            paraSupplierNm2.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierNm2);
            paraSuppHonorificTitle.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SuppHonorificTitle);
            paraSupplierKana.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierKana);
            paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierSnm);
            paraOrderHonorificTtl.Value = SqlDataMediator.SqlSetString(dcSupplierWork.OrderHonorificTtl);
            paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.BusinessTypeCode);
            paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SalesAreaCode);
            paraSupplierPostNo.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierPostNo);
            paraSupplierAddr1.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierAddr1);
            paraSupplierAddr3.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierAddr3);
            paraSupplierAddr4.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierAddr4);
            paraSupplierTelNo.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierTelNo);
            paraSupplierTelNo1.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierTelNo1);
            paraSupplierTelNo2.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierTelNo2);
            paraPureCode.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PureCode);
            paraPaymentMonthCode.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PaymentMonthCode);
            paraPaymentMonthName.Value = SqlDataMediator.SqlSetString(dcSupplierWork.PaymentMonthName);
            paraPaymentDay.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PaymentDay);
            paraSuppCTaxLayRefCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SuppCTaxLayRefCd);
            paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SuppCTaxLayCd);
            paraSuppCTaxationCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SuppCTaxationCd);
            paraSuppEnterpriseCd.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SuppEnterpriseCd);
            paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PayeeCode);
            paraSupplierAttributeDiv.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SupplierAttributeDiv);
            paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.SuppTtlAmntDspWayCd);
            paraStckTtlAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.StckTtlAmntDspWayRef);
            paraPaymentCond.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PaymentCond);
            paraPaymentTotalDay.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PaymentTotalDay);
            paraPaymentSight.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.PaymentSight);
            paraStockAgentCode.Value = SqlDataMediator.SqlSetString(dcSupplierWork.StockAgentCode);
            paraStockUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.StockUnPrcFrcProcCd);
            paraStockMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.StockMoneyFrcProcCd);
            paraStockCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.StockCnsTaxFrcProcCd);
            paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(dcSupplierWork.NTimeCalcStDate);
            paraSupplierNote1.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierNote1);
            paraSupplierNote2.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierNote2);
            paraSupplierNote3.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierNote3);
            paraSupplierNote4.Value = SqlDataMediator.SqlSetString(dcSupplierWork.SupplierNote4);


            // 仕入先マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        /// <summary>
        /// 仕入先マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="supplierArrList">仕入先マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchSupplier(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList supplierArrList, out string retMessage)
        {
            return SearchSupplierProc(enterpriseCodes, paramList, sqlConnection,
                                  sqlTransaction, out supplierArrList, out retMessage);
        }
        /// <summary>
        /// 仕入先マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="supplierArrList">仕入先マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.07.26</br>
        private int SearchSupplierProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList supplierArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            supplierArrList = new ArrayList();
            //DCSupplierWork supplierWork = null;//DEL 2011/08/20 途中納品チェック
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/09/08 sundx #23777 ソースレビュー
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/09/08 sundx #23777 ソースレビュー
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SupplierProcParamWork param = paramList as SupplierProcParamWork;
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                #region DEL
                //DEL 2011/09/08 sundx #23777 ソースレビュー ----------------------------------------------------------------------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERCDRF, MNGSECTIONCODERF, INPSECTIONCODERF, PAYMENTSECTIONCODERF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPHONORIFICTITLERF, SUPPLIERKANARF, SUPPLIERSNMRF, ORDERHONORIFICTTLRF, BUSINESSTYPECODERF, SALESAREACODERF, SUPPLIERPOSTNORF, SUPPLIERADDR1RF, SUPPLIERADDR3RF, SUPPLIERADDR4RF, SUPPLIERTELNORF, SUPPLIERTELNO1RF, SUPPLIERTELNO2RF, PURECODERF, PAYMENTMONTHCODERF, PAYMENTMONTHNAMERF, PAYMENTDAYRF, SUPPCTAXLAYREFCDRF, SUPPCTAXLAYCDRF, SUPPCTAXATIONCDRF, SUPPENTERPRISECDRF, PAYEECODERF, SUPPLIERATTRIBUTEDIVRF, SUPPTTLAMNTDSPWAYCDRF, STCKTTLAMNTDSPWAYREFRF, PAYMENTCONDRF, PAYMENTTOTALDAYRF, PAYMENTSIGHTRF, STOCKAGENTCODERF, STOCKUNPRCFRCPROCCDRF, STOCKMONEYFRCPROCCDRF, STOCKCNSTAXFRCPROCCDRF, NTIMECALCSTDATERF, SUPPLIERNOTE1RF, SUPPLIERNOTE2RF, SUPPLIERNOTE3RF, SUPPLIERNOTE4RF FROM SUPPLIERRF ";
                //sqlStr += " WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}
                //DEL 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<
                #endregion
                //ADD 2011/09/08 sundx #23777 ソースレビュー ----------------------------------------------------------------------->>>>>
                sqlStr.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERCDRF, MNGSECTIONCODERF, INPSECTIONCODERF, PAYMENTSECTIONCODERF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPHONORIFICTITLERF, SUPPLIERKANARF, SUPPLIERSNMRF, ORDERHONORIFICTTLRF, BUSINESSTYPECODERF, SALESAREACODERF, SUPPLIERPOSTNORF, SUPPLIERADDR1RF, SUPPLIERADDR3RF, SUPPLIERADDR4RF, SUPPLIERTELNORF, SUPPLIERTELNO1RF, SUPPLIERTELNO2RF, PURECODERF, PAYMENTMONTHCODERF, PAYMENTMONTHNAMERF, PAYMENTDAYRF, SUPPCTAXLAYREFCDRF, SUPPCTAXLAYCDRF, SUPPCTAXATIONCDRF, SUPPENTERPRISECDRF, PAYEECODERF, SUPPLIERATTRIBUTEDIVRF, SUPPTTLAMNTDSPWAYCDRF, STCKTTLAMNTDSPWAYREFRF, PAYMENTCONDRF, PAYMENTTOTALDAYRF, PAYMENTSIGHTRF, STOCKAGENTCODERF, STOCKUNPRCFRCPROCCDRF, STOCKMONEYFRCPROCCDRF, STOCKCNSTAXFRCPROCCDRF, NTIMECALCSTDATERF, SUPPLIERNOTE1RF, SUPPLIERNOTE2RF, SUPPLIERNOTE3RF, SUPPLIERNOTE4RF FROM SUPPLIERRF ");
                sqlStr.Append(" WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                if (param.SupplierCdBeginRF != 0)
                {
                    sqlStr.Append(" AND SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                }

                if (param.SupplierCdEndRF != 0)
                {
                    sqlStr.Append(" AND SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                }
                //ADD 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //仕入先マスタデータ用SQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/09/08 sundx #23777 ソースレビュー 
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/09/08 sundx #23777 ソースレビュー

                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                //ADD 2011/09/08 sundx #23777 ソースレビュー --------------->>>>>
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }
                //ADD 2011/09/08 sundx #23777 ソースレビュー ---------------<<<<<
                while (myReader.Read())
                {
                    #region DEL
                    //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
                    //supplierWork = new DCSupplierWork();

                    //supplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //supplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //supplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //supplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //supplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //supplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //supplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //supplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    //supplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //supplierWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    //supplierWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                    //supplierWork.PaymentSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    //supplierWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    //supplierWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    //supplierWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
                    //supplierWork.SupplierKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
                    //supplierWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    //supplierWork.OrderHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERHONORIFICTTLRF"));
                    //supplierWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    //supplierWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    //supplierWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERPOSTNORF"));
                    //supplierWork.SupplierAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR1RF"));
                    //supplierWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR3RF"));
                    //supplierWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR4RF"));
                    //supplierWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNORF"));
                    //supplierWork.SupplierTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO1RF"));
                    //supplierWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO2RF"));
                    //supplierWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    //supplierWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"));
                    //supplierWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                    //supplierWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                    //supplierWork.SuppCTaxLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYREFCDRF"));
                    //supplierWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    //supplierWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXATIONCDRF"));
                    //supplierWork.SuppEnterpriseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPENTERPRISECDRF"));
                    //supplierWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    //supplierWork.SupplierAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERATTRIBUTEDIVRF"));
                    //supplierWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                    //supplierWork.StckTtlAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKTTLAMNTDSPWAYREFRF"));
                    //supplierWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                    //supplierWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                    //supplierWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSIGHTRF"));
                    //supplierWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    //supplierWork.StockUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNPRCFRCPROCCDRF"));
                    //supplierWork.StockMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMONEYFRCPROCCDRF"));
                    //supplierWork.StockCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCNSTAXFRCPROCCDRF"));
                    //supplierWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                    //supplierWork.SupplierNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
                    //supplierWork.SupplierNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
                    //supplierWork.SupplierNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
                    //supplierWork.SupplierNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));

                    //supplierArrList.Add(supplierWork);
                    //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
                    #endregion DEL
                    supplierArrList.Add(CopyFromMyReaderToDCSupplierWork(myReader));//ADD 2011/08/20 途中納品チェック
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCSupplierDB.SearchSupplier Exception=" + ex.Message);
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
        /// インデックス格納処理
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : カラムインデックス格納処理を行う</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011/09/08</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _createDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _updateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _enterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _fileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _updEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _updAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _updAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _logicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _supplierCd = myReader.GetOrdinal("SUPPLIERCDRF");
            _mngSectionCode = myReader.GetOrdinal("MNGSECTIONCODERF");
            _inpSectionCode = myReader.GetOrdinal("INPSECTIONCODERF");
            _paymentSectionCode = myReader.GetOrdinal("PAYMENTSECTIONCODERF");
            _supplierNm1 = myReader.GetOrdinal("SUPPLIERNM1RF");
            _supplierNm2 = myReader.GetOrdinal("SUPPLIERNM2RF");
            _suppHonorificTitle = myReader.GetOrdinal("SUPPHONORIFICTITLERF");
            _supplierKana = myReader.GetOrdinal("SUPPLIERKANARF");
            _supplierSnm = myReader.GetOrdinal("SUPPLIERSNMRF");
            _orderHonorificTtl = myReader.GetOrdinal("ORDERHONORIFICTTLRF");
            _businessTypeCode = myReader.GetOrdinal("BUSINESSTYPECODERF");
            _salesAreaCode = myReader.GetOrdinal("SALESAREACODERF");
            _supplierPostNo = myReader.GetOrdinal("SUPPLIERPOSTNORF");
            _supplierAddr1 = myReader.GetOrdinal("SUPPLIERADDR1RF");
            _supplierAddr3 = myReader.GetOrdinal("SUPPLIERADDR3RF");
            _supplierAddr4 = myReader.GetOrdinal("SUPPLIERADDR4RF");
            _supplierTelNo = myReader.GetOrdinal("SUPPLIERTELNORF");
            _supplierTelNo1 = myReader.GetOrdinal("SUPPLIERTELNO1RF");
            _supplierTelNo2 = myReader.GetOrdinal("SUPPLIERTELNO2RF");
            _pureCode = myReader.GetOrdinal("PURECODERF");
            _paymentMonthCode = myReader.GetOrdinal("PAYMENTMONTHCODERF");
            _paymentMonthName = myReader.GetOrdinal("PAYMENTMONTHNAMERF");
            _paymentDay = myReader.GetOrdinal("PAYMENTDAYRF");
            _suppCTaxLayRefCd = myReader.GetOrdinal("SUPPCTAXLAYREFCDRF");
            _suppCTaxLayCd = myReader.GetOrdinal("SUPPCTAXLAYCDRF");
            _suppCTaxationCd = myReader.GetOrdinal("SUPPCTAXATIONCDRF");
            _suppEnterpriseCd = myReader.GetOrdinal("SUPPENTERPRISECDRF");
            _payeeCode = myReader.GetOrdinal("PAYEECODERF");
            _supplierAttributeDiv = myReader.GetOrdinal("SUPPLIERATTRIBUTEDIVRF");
            _suppTtlAmntDspWayCd = myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF");
            _stckTtlAmntDspWayRef = myReader.GetOrdinal("STCKTTLAMNTDSPWAYREFRF");
            _paymentCond = myReader.GetOrdinal("PAYMENTCONDRF");
            _paymentTotalDay = myReader.GetOrdinal("PAYMENTTOTALDAYRF");
            _paymentSight = myReader.GetOrdinal("PAYMENTSIGHTRF");
            _stockAgentCode = myReader.GetOrdinal("STOCKAGENTCODERF");
            _stockUnPrcFrcProcCd = myReader.GetOrdinal("STOCKUNPRCFRCPROCCDRF");
            _stockMoneyFrcProcCd = myReader.GetOrdinal("STOCKMONEYFRCPROCCDRF");
            _stockCnsTaxFrcProcCd = myReader.GetOrdinal("STOCKCNSTAXFRCPROCCDRF");
            _nTimeCalcStDate = myReader.GetOrdinal("NTIMECALCSTDATERF");
            _supplierNote1 = myReader.GetOrdinal("SUPPLIERNOTE1RF");
            _supplierNote2 = myReader.GetOrdinal("SUPPLIERNOTE2RF");
            _supplierNote3 = myReader.GetOrdinal("SUPPLIERNOTE3RF");
            _supplierNote4 = myReader.GetOrdinal("SUPPLIERNOTE4RF");

        }

        //-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        /// <summary>
        /// 仕入先マスタデータを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>仕入先マスタデータ</returns>
        /// <br>Note       : 仕入先マスタデータを戻します</br>
        /// <br>Programmer : 馮文雄</br>
        /// <br>Date       : 2011/08/20</br>
        private DCSupplierWork CopyFromMyReaderToDCSupplierWork(SqlDataReader myReader)
        {
            DCSupplierWork supplierWork = new DCSupplierWork();
            #region DEL
            //DEL 2011/09/08 sundx #23777 ソースレビュー -------------------------------------------------------------------------------->>>>>
            //supplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //supplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //supplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //supplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //supplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //supplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //supplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //supplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //supplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //supplierWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            //supplierWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
            //supplierWork.PaymentSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
            //supplierWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            //supplierWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            //supplierWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
            //supplierWork.SupplierKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
            //supplierWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            //supplierWork.OrderHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERHONORIFICTTLRF"));
            //supplierWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            //supplierWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            //supplierWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERPOSTNORF"));
            //supplierWork.SupplierAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR1RF"));
            //supplierWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR3RF"));
            //supplierWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR4RF"));
            //supplierWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNORF"));
            //supplierWork.SupplierTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO1RF"));
            //supplierWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO2RF"));
            //supplierWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
            //supplierWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"));
            //supplierWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            //supplierWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            //supplierWork.SuppCTaxLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYREFCDRF"));
            //supplierWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            //supplierWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXATIONCDRF"));
            //supplierWork.SuppEnterpriseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPENTERPRISECDRF"));
            //supplierWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //supplierWork.SupplierAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERATTRIBUTEDIVRF"));
            //supplierWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            //supplierWork.StckTtlAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKTTLAMNTDSPWAYREFRF"));
            //supplierWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            //supplierWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
            //supplierWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSIGHTRF"));
            //supplierWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            //supplierWork.StockUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNPRCFRCPROCCDRF"));
            //supplierWork.StockMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMONEYFRCPROCCDRF"));
            //supplierWork.StockCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCNSTAXFRCPROCCDRF"));
            //supplierWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
            //supplierWork.SupplierNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
            //supplierWork.SupplierNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
            //supplierWork.SupplierNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
            //supplierWork.SupplierNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));
            //DEL 2011/09/08 sundx #23777 ソースレビュー --------------------------------------------------------------------------------<<<<<
            #endregion
            //ADD 2011/09/08 sundx #23777 ソースレビュー -------------------------------------------------------------------------------->>>>>
            supplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            supplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            supplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            supplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            supplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            supplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            supplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            supplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            supplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, _supplierCd);
            supplierWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, _mngSectionCode);
            supplierWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, _inpSectionCode);
            supplierWork.PaymentSectionCode = SqlDataMediator.SqlGetString(myReader, _paymentSectionCode);
            supplierWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, _supplierNm1);
            supplierWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, _supplierNm2);
            supplierWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, _suppHonorificTitle);
            supplierWork.SupplierKana = SqlDataMediator.SqlGetString(myReader, _supplierKana);
            supplierWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, _supplierSnm);
            supplierWork.OrderHonorificTtl = SqlDataMediator.SqlGetString(myReader, _orderHonorificTtl);
            supplierWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, _businessTypeCode);
            supplierWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, _salesAreaCode);
            supplierWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, _supplierPostNo);
            supplierWork.SupplierAddr1 = SqlDataMediator.SqlGetString(myReader, _supplierAddr1);
            supplierWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, _supplierAddr3);
            supplierWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, _supplierAddr4);
            supplierWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, _supplierTelNo);
            supplierWork.SupplierTelNo1 = SqlDataMediator.SqlGetString(myReader, _supplierTelNo1);
            supplierWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, _supplierTelNo2);
            supplierWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, _pureCode);
            supplierWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, _paymentMonthCode);
            supplierWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, _paymentMonthName);
            supplierWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, _paymentDay);
            supplierWork.SuppCTaxLayRefCd = SqlDataMediator.SqlGetInt32(myReader, _suppCTaxLayRefCd);
            supplierWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, _suppCTaxLayCd);
            supplierWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, _suppCTaxationCd);
            supplierWork.SuppEnterpriseCd = SqlDataMediator.SqlGetString(myReader, _suppEnterpriseCd);
            supplierWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, _payeeCode);
            supplierWork.SupplierAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, _supplierAttributeDiv);
            supplierWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, _suppTtlAmntDspWayCd);
            supplierWork.StckTtlAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, _stckTtlAmntDspWayRef);
            supplierWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, _paymentCond);
            supplierWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, _paymentTotalDay);
            supplierWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, _paymentSight);
            supplierWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, _stockAgentCode);
            supplierWork.StockUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, _stockUnPrcFrcProcCd);
            supplierWork.StockMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, _stockMoneyFrcProcCd);
            supplierWork.StockCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, _stockCnsTaxFrcProcCd);
            supplierWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, _nTimeCalcStDate);
            supplierWork.SupplierNote1 = SqlDataMediator.SqlGetString(myReader, _supplierNote1);
            supplierWork.SupplierNote2 = SqlDataMediator.SqlGetString(myReader, _supplierNote2);
            supplierWork.SupplierNote3 = SqlDataMediator.SqlGetString(myReader, _supplierNote3);
            supplierWork.SupplierNote4 = SqlDataMediator.SqlGetString(myReader, _supplierNote4);
            //ADD 2011/09/08 sundx #23777 ソースレビュー --------------------------------------------------------------------------------<<<<<

            return supplierWork;
        }
        //-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        #endregion
        #endregion 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）

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
        //    sqlCommand.CommandText = "DELETE FROM SUPPLIERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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