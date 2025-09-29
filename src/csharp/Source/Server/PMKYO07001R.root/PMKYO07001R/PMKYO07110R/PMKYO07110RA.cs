//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
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
// 修 正 日  2011/12/05  修正内容 : Redmine#8482 拠点管理　値引のみの入金データについて
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
    /// 支払伝票マスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APPaymentSlpDB : RemoteDB
    {
        /// <summary>
        /// 支払伝票マスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APPaymentSlpDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 支払伝票マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="paymentSlpArrList">支払伝票マスタオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払伝票マスタREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchPaymentSlp(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList paymentSlpArrList, out string retMessage)
        {
            return SearchPaymentSlpProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  paymentSlpArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="paymentSlpArrList">支払伝票マスタオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払伝票マスタREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchPaymentSlpProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList paymentSlpArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            paymentSlpArrList = new ArrayList();
            APPaymentSlpWork paymentSlpWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, PAYMENTDATERF, ADDUPADATERF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, AUTOPAYMENTRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 支払伝票データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    paymentSlpWork = new APPaymentSlpWork();

                    paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    paymentSlpWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));


                    paymentSlpArrList.Add(paymentSlpWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
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
        /// 支払伝票マスタ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="paymentSlpList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdatePayementSlp(string enterPriseCode, ArrayList paymentSlpList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdatePayementSlpProc(enterPriseCode, paymentSlpList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="paymentSlpList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdatePayementSlpProc(string enterPriseCode, ArrayList paymentSlpList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeletePaymentSlp(enterPriseCode, paymentSlpList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertPaymentSlp(enterPriseCode, paymentSlpList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 支払伝票マスタ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="paymentSlpList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeletePaymentSlp(string enterPriseCode, ArrayList paymentSlpList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeletePaymentSlpProc(enterPriseCode, paymentSlpList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="paymentSlpList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeletePaymentSlpProc(string enterPriseCode, ArrayList paymentSlpList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APPaymentSlpWork paymentSlpWork in paymentSlpList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaPaymentSlipNo.Value = paymentSlpWork.PaymentSlipNo;

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
        /// 支払伝票マスタ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="paymentSlpList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertPaymentSlp(string enterPriseCode, ArrayList paymentSlpList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertPaymentSlpProc(enterPriseCode, paymentSlpList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="paymentSlpList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertPaymentSlpProc(string enterPriseCode, ArrayList paymentSlpList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APPaymentSlpWork paymentSlpWork in paymentSlpList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, PAYMENTDATERF, ADDUPADATERF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, AUTOPAYMENTRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEBITNOTEDIV, @PAYMENTSLIPNO, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @PAYMENTINPSECTIONCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @INPUTDAYRF, @PAYMENTDATE, @ADDUPADATE, @PAYMENTTOTAL, @PAYMENT, @FEEPAYMENT, @DISCOUNTPAYMENT, @AUTOPAYMENT, @DRAFTDRAWINGDATE, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEBITNOTELINKPAYNO, @PAYMENTAGENTCODE, @PAYMENTAGENTNAME, @PAYMENTINPUTAGENTCD, @PAYMENTINPUTAGENTNM, @OUTLINE, @BANKCODE, @BANKNAME)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAYRF", SqlDbType.Int);
                SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteDiv);
                paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierSlipNo);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierCd);
                paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm1);
                paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm2);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierSnm);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PayeeCode);
                paraPayeeName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName);
                paraPayeeName2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName2);
                paraPayeeSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeSnm);
                paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInpSectionCd);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.AddUpSecCode);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdateSecCd);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SubSectionCode);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.InputDay);
                paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.PaymentDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.AddUpADate);
                paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.PaymentTotal);
                paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.Payment);
                paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.FeePayment);
                paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.DiscountPayment);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.AutoPayment);
                paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftDrawingDate);
                paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftKind);
                paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftKindName);
                paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftDivide);
                paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftDivideName);
                paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftNo);
                paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentCode);
                paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentName);
                paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentCd);
                paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentNm);
                paraOutline.Value = SqlDataMediator.SqlSetString(paymentSlpWork.Outline);
                paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.BankCode);
                paraBankName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.BankName);

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
		/// <summary>
		/// 支払伝票マスタデータ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 支払伝票マスタデータ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchSCMProc(out ArrayList resultList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT M.CREATEDATETIMERF as M_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDATEDATETIMERF as M_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.ENTERPRISECODERF as M_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.FILEHEADERGUIDRF as M_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDEMPLOYEECODERF as M_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDASSEMBLYID1RF as M_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDASSEMBLYID2RF as M_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,M.LOGICALDELETECODERF as M_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DEBITNOTEDIVRF as M_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTSLIPNORF as M_PAYMENTSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERFORMALRF as M_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERSLIPNORF as M_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERCDRF as M_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERNM1RF as M_SUPPLIERNM1RF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERNM2RF as M_SUPPLIERNM2RF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERSNMRF as M_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEECODERF as M_PAYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEENAMERF as M_PAYEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEENAME2RF as M_PAYEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEESNMRF as M_PAYEESNMRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTINPSECTIONCDRF as M_PAYMENTINPSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.ADDUPSECCODERF as M_ADDUPSECCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDATESECCDRF as M_UPDATESECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUBSECTIONCODERF as M_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.INPUTDAYRF as M_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTDATERF as M_PAYMENTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,M.ADDUPADATERF as M_ADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTTOTALRF as M_PAYMENTTOTALRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTRF as M_PAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.FEEPAYMENTRF as M_FEEPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.DISCOUNTPAYMENTRF as M_DISCOUNTPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.AUTOPAYMENTRF as M_AUTOPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTDRAWINGDATERF as M_DRAFTDRAWINGDATERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTKINDRF as M_DRAFTKINDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTKINDNAMERF as M_DRAFTKINDNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTDIVIDERF as M_DRAFTDIVIDERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTDIVIDENAMERF as M_DRAFTDIVIDENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTNORF as M_DRAFTNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.DEBITNOTELINKPAYNORF as M_DEBITNOTELINKPAYNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTAGENTCODERF as M_PAYMENTAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTAGENTNAMERF as M_PAYMENTAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTINPUTAGENTCDRF as M_PAYMENTINPUTAGENTCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTINPUTAGENTNMRF as M_PAYMENTINPUTAGENTNMRF ").Append(Environment.NewLine);
			sb.Append(" ,M.OUTLINERF as M_OUTLINERF ").Append(Environment.NewLine);
			sb.Append(" ,M.BANKCODERF as M_BANKCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.BANKNAMERF as M_BANKNAMERF ").Append(Environment.NewLine);
			//支払明細データ
			sb.Append(" ,N.CREATEDATETIMERF as N_CREATEDATETIMERF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDATEDATETIMERF as N_UPDATEDATETIMERF").Append(Environment.NewLine);
			sb.Append(" ,N.ENTERPRISECODERF as N_ENTERPRISECODERF").Append(Environment.NewLine);
			sb.Append(" ,N.FILEHEADERGUIDRF as N_FILEHEADERGUIDRF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDEMPLOYEECODERF as N_UPDEMPLOYEECODERF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDASSEMBLYID1RF as N_UPDASSEMBLYID1RF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDASSEMBLYID2RF as N_UPDASSEMBLYID2RF").Append(Environment.NewLine);
			sb.Append(" ,N.LOGICALDELETECODERF as N_LOGICALDELETECODERF").Append(Environment.NewLine);
			sb.Append(" ,N.SUPPLIERFORMALRF as N_SUPPLIERFORMALRF").Append(Environment.NewLine);
			sb.Append(" ,N.PAYMENTSLIPNORF as N_PAYMENTSLIPNORF").Append(Environment.NewLine);
			sb.Append(" ,N.PAYMENTROWNORF as N_PAYMENTROWNORF").Append(Environment.NewLine);
			sb.Append(" ,N.MONEYKINDCODERF as N_MONEYKINDCODERF").Append(Environment.NewLine);
			sb.Append(" ,N.MONEYKINDNAMERF as N_MONEYKINDNAMERF").Append(Environment.NewLine);
			sb.Append(" ,N.MONEYKINDDIVRF as N_MONEYKINDDIVRF").Append(Environment.NewLine);
			sb.Append(" ,N.PAYMENTRF as N_PAYMENTRF").Append(Environment.NewLine);
			sb.Append(" ,N.VALIDITYTERMRF as N_VALIDITYTERMRF").Append(Environment.NewLine);

			sb.Append(" FROM PAYMENTSLPRF M WITH (READUNCOMMITTED)").Append(Environment.NewLine);

			//支払明細データ
            //sb.Append("  INNER JOIN PAYMENTDTLRF N WITH (READUNCOMMITTED) ").Append(Environment.NewLine); // DEL 2011/12/05
            sb.Append("  LEFT JOIN PAYMENTDTLRF N WITH (READUNCOMMITTED) ").Append(Environment.NewLine);  // ADD 2011/12/05
			//	支払伝票データ.企業コード　＝　支払明細データ.企業コード
			sb.Append(" ON M.ENTERPRISECODERF = N.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	支払伝票データ.支払伝票番号　＝　支払明細データ.支払伝票番号 PaymentSlipNoRF
			sb.Append(" AND M.PAYMENTSLIPNORF = N.PAYMENTSLIPNORF ").Append(Environment.NewLine);
                
            // ----- DEL 2011/11/01 xupz---------->>>>>
            ////	支払明細データ.更新日時　>　パラメータ.開始日付
            //sb.Append(" AND N.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_N ").Append(Environment.NewLine);
            ////	支払明細データ.更新日時　≦　パラメータ.終了日付
            //sb.Append(" AND N.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_N ").Append(Environment.NewLine);
            // ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0) 
            {
			//	支払明細データ.更新日時　>　パラメータ.開始日付
			sb.Append(" AND N.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_N ").Append(Environment.NewLine);
			//	支払明細データ.更新日時　≦　パラメータ.終了日付
			sb.Append(" AND N.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_N ").Append(Environment.NewLine);
            }
            // ----- ADD 2011/11/01 xupz----------<<<<<


			//	支払伝票データ.計上拠点コード　＝　パラメータ.拠点コード
			sb.Append(" WHERE M.ADDUPSECCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);

            // ----- DEL 2011/11/01 xupz---------->>>>>
            ////	支払伝票データ.更新日時　>　パラメータ.開始日付
            //sb.Append(" AND M.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);
            ////	支払伝票データ.更新日時　≦　パラメータ.終了日付
            //sb.Append(" AND M.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine);
            // ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>    
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0) 
            {
			//	支払伝票データ.更新日時　>　パラメータ.開始日付
			sb.Append(" AND M.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);
			//	支払伝票データ.更新日時　≦　パラメータ.終了日付
			sb.Append(" AND M.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine);
            }
            //データ送信抽出条件区分が「伝票日付」の場合
            else if (sendDataWork.SndMesExtraCondDiv == 1)
            {
                //	支払伝票データ.支払日付　>=　パラメータ.開始日付
                //sb.Append(" AND M.PAYMENTDATERF>=@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine); // DEL 2011/11/30
                ////	支払伝票データ.支払日付　≦　パラメータ.終了日付
                //sb.Append(" AND M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine); // DEL 2011/11/30

                //	支払伝票データ.支払日付　>=　パラメータ.開始日付
                sb.Append(" AND (( M.PAYMENTDATERF>=@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);  // ADD 2011/11/30
                //	支払伝票データ.支払日付　≦　パラメータ.終了日付
                sb.Append(" AND M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M ) ").Append(Environment.NewLine);  // ADD 2011/11/30

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sb.Append(" OR ( M.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR ( M.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sb.Append(" AND  M.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M )) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<
            }
            // ----- ADD 2011/11/01 xupz----------<<<<<

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" M_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M_PAYMENTSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,N_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,N_PAYMENTSLIPNORF  ").Append(Environment.NewLine);
			sb.Append(" ,N_PAYMENTROWNORF ").Append(Environment.NewLine);

			sqlText = sb.ToString();

			//Prameterオブジェクトの作成
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_M = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_M", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_M = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_M", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime_N = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_N", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_N = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_N", SqlDbType.BigInt);

			//Parameterオブジェクトへ値設定
			findParaSectionCode.Value = sendDataWork.PmSectionCode;
			findParaUpdateStartDateTime_M.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_M.Value = sendDataWork.EndDateTime;
			findParaUpdateStartDateTime_N.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_N.Value = sendDataWork.EndDateTime;

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //データ送信抽出条件区分が「伝票区分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = sendDataWork.SyncExecDate;
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
                findParaEndTime.Value = sendDataWork.EndDateTimeTicks; // ADD 2011/12/06
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

			// SQL文
			sqlCommand.CommandText = sqlText;
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

			myReader = sqlCommand.ExecuteReader();

			ArrayList paymentSlpList = new ArrayList();
			ArrayList paymentDtlList = new ArrayList();
			APPaymentDtlDB aPPaymentDtlDB = new APPaymentDtlDB();
			APPaymentSlpWork tmpWorkM = new APPaymentSlpWork();
			APPaymentDtlWork tmpWorkN = new APPaymentDtlWork();

			Dictionary<string, string> paymentSlpDic = new Dictionary<string, string>();
			Dictionary<string, string> paymentDtlDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				//	支払伝票データ
				tmpWorkM = this.CopyToPaymentSlpWorkFromReaderSCM(ref myReader, "M_");
				string workM_key = tmpWorkM.EnterpriseCode + tmpWorkM.PaymentSlipNo.ToString();
				if (!string.Empty.Equals(tmpWorkM.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkM.PaymentSlipNo.ToString())
					&& !paymentSlpDic.ContainsKey(workM_key))
				{
					paymentSlpDic.Add(workM_key, workM_key);
					paymentSlpList.Add(tmpWorkM);
				}
				//	支払明細データ
				tmpWorkN = aPPaymentDtlDB.CopyToPaymentDtlWorkFromReaderSCM(ref myReader, "N_");
				string workN_key = tmpWorkN.EnterpriseCode + tmpWorkN.PaymentSlipNo.ToString()
					              +tmpWorkN.SupplierFormal.ToString()+ tmpWorkN.PaymentRowNo.ToString();
				if (!string.Empty.Equals(tmpWorkN.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkN.PaymentSlipNo.ToString())
					&& !string.Empty.Equals(tmpWorkN.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkN.PaymentRowNo.ToString())
					&& !paymentDtlDic.ContainsKey(workN_key))
				{
					paymentDtlDic.Add(workN_key, workN_key);
					paymentDtlList.Add(tmpWorkN);
				}
			}
			// 支払伝票要否フラグ
			if (sendDataWork.DoPaymentSlpFlg)
			{
				resultList.Add(paymentSlpList);
			}
			// 支払明細要否フラグ
			if (sendDataWork.DoPaymentDtlFlg)
			{
				resultList.Add(paymentDtlList);
			}

			if (paymentSlpList.Count > 0)
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
		/// クラス格納処理 Reader → paymentSlpWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		private APPaymentSlpWork CopyToPaymentSlpWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APPaymentSlpWork paymentSlpWork = new APPaymentSlpWork();

			this.CopyToPaymentSlpWorkFromReaderSCM(ref myReader, ref paymentSlpWork, tableNm);

			return paymentSlpWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → paymentSlpWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="paymentSlpWork">paymentSlpWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToPaymentSlpWorkFromReaderSCM(ref SqlDataReader myReader, ref APPaymentSlpWork paymentSlpWork, string tableNm)
		{
			if (myReader != null && paymentSlpWork != null)
			{
				# region クラスへ格納
				paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYMENTSLIPNORF"));
				paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM1RF"));
				paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM2RF"));
				paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYEECODERF"));
				paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEENAMERF"));
				paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEENAME2RF"));
				paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEESNMRF"));
				paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTINPSECTIONCDRF"));
				paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDUPSECCODERF"));
				paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDATESECCDRF"));
				paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				paymentSlpWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "INPUTDAYRF"));
				paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "PAYMENTDATERF"));
				paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ADDUPADATERF"));
				paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PAYMENTTOTALRF"));
				paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PAYMENTRF"));
				paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "FEEPAYMENTRF"));
				paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DISCOUNTPAYMENTRF"));
				paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYMENTRF"));
				paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "DRAFTDRAWINGDATERF"));
				paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DRAFTKINDRF"));
				paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTKINDNAMERF"));
				paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DRAFTDIVIDERF"));
				paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTDIVIDENAMERF"));
				paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTNORF"));
				paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTELINKPAYNORF"));
				paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTAGENTCODERF"));
				paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTAGENTNAMERF"));
				paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTINPUTAGENTCDRF"));
				paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTINPUTAGENTNMRF"));
				paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "OUTLINERF"));
				paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BANKCODERF"));
				paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BANKNAMERF"));
				# endregion
			}
		}
		
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}
