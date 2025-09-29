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
// 管理番号              作成担当 : 陳建明
// 作 成 日  2011/11/01  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/05  修正内容 : Redmine#8482 拠点管理　値引のみの入金データについて
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
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 支払伝票マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払伝票マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCPaymentSlpDB : RemoteDB
    {
        /// <summary>
        /// 支払伝票マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCPaymentSlpDB()
            : base("PMKYO07511D", "Broadleaf.Application.Remoting.ParamData.DCPaymentSlpWork", "PAYMENTSLPRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 支払伝票マスタデータ取得
        /// </summary>
        /// <param name="paymentSlpList">支払伝票マスタデータ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList paymentSlpList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  paymentSlpList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタデータ取得
        /// </summary>
        /// <param name="paymentSlpList">支払伝票マスタデータ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList paymentSlpList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            paymentSlpList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, PAYMENTDATERF, ADDUPADATERF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, AUTOPAYMENTRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF FROM PAYMENTSLPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL文
			sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                paymentSlpList.Add(this.CopyToPaymentSlpWorkFromReader(ref myReader));
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
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCPaymentSlpWork CopyToPaymentSlpWorkFromReader(ref SqlDataReader myReader)
        {
            DCPaymentSlpWork paymentSlpWork = new DCPaymentSlpWork();

			this.CopyToPaymentSlpWorkFromReader(ref myReader, ref paymentSlpWork);

            return paymentSlpWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → paymentSlpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paymentSlpWork">paymentSlpWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToPaymentSlpWorkFromReader(ref SqlDataReader myReader, ref DCPaymentSlpWork paymentSlpWork)
        {
            if (myReader != null && paymentSlpWork != null)
			{
				# region クラスへ格納
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
				# endregion
            }
        }
  
  */
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// 支払伝票マスタデータ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 支払伝票マスタデータ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchSCMProc(out ArrayList resultList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
		    //-----Add 2011/11/01 陳建明 for #26228 start----->>>>>
            if (!(receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1))
            {
            //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<<    
                //	支払明細データ.更新日時　>　パラメータ.開始日付
                sb.Append(" AND N.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_N ").Append(Environment.NewLine);
                //	支払明細データ.更新日時　≦　パラメータ.終了日付
                sb.Append(" AND N.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_N ").Append(Environment.NewLine);
            }//Add 2011/11/01 陳建明 for #26228
			//	支払伝票データ.計上拠点コード　＝　パラメータ.拠点コード
			sb.Append(" WHERE M.ADDUPSECCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);
		    //-----Add 2011/11/01 陳建明 for #26228 start----->>>>>
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                //	支払伝票データ.支払日付　≧　パラメータ.開始日付
                //sb.Append(" AND M.PAYMENTDATERF>=@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine); // DEL 2011/11/30
                ////	支払伝票データ.支払日付　≦　パラメータ.終了日付
                //sb.Append(" AND M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine); // DEL 2011/11/30

                // ----- ADD 2011/11/30 tanh---------->>>>>

                //	支払伝票データ.支払日付　≧　パラメータ.開始日付
                sb.Append(" AND (( M.PAYMENTDATERF>=@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);
                //	支払伝票データ.支払日付　≦　パラメータ.終了日付
                sb.Append(" AND M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M ) ").Append(Environment.NewLine);

                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append(" OR ( M.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR ( M.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append(" AND  M.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M )) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<

            }
		    else
            {
            //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<<   
                //	支払伝票データ.更新日時　>　パラメータ.開始日付
                sb.Append(" AND M.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);
                //	支払伝票データ.更新日時　≦　パラメータ.終了日付
                sb.Append(" AND M.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine);
            }//Add 2011/11/01 陳建明 for #26228
			//	支払伝票データ.企業コード　＝　パラメータ.企業コード
			sb.Append(" AND M.ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);// ADD 2011/08/18 張莉莉　Redmine#23746

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
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);// ADD 2011/08/18 張莉莉　Redmine#23746

			//Parameterオブジェクトへ値設定
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_M.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_M.Value = receiveDataWork.EndDateTime;
			findParaUpdateStartDateTime_N.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_N.Value = receiveDataWork.EndDateTime;
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 張莉莉　Redmine#23746

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

			ArrayList paymentSlpList = new ArrayList();
			ArrayList paymentDtlList = new ArrayList();
			DCPaymentDtlDB dCPaymentDtlDB = new DCPaymentDtlDB();
			DCPaymentSlpWork tmpWorkM = new DCPaymentSlpWork();
			DCPaymentDtlWork tmpWorkN = new DCPaymentDtlWork();

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
				tmpWorkN = dCPaymentDtlDB.CopyToPaymentDtlWorkFromReaderSCM(ref myReader, "N_");
				string workN_key = tmpWorkN.EnterpriseCode + tmpWorkN.PaymentSlipNo.ToString()
								  + tmpWorkN.SupplierFormal.ToString() + tmpWorkN.PaymentRowNo.ToString();
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
			if (receiveDataWork.DoPaymentSlpFlg)
			{
				resultList.Add(paymentSlpList);
			}
			// 支払明細要否フラグ
			if (receiveDataWork.DoPaymentDtlFlg)
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
		private DCPaymentSlpWork CopyToPaymentSlpWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCPaymentSlpWork paymentSlpWork = new DCPaymentSlpWork();

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
		private void CopyToPaymentSlpWorkFromReaderSCM(ref SqlDataReader myReader, ref DCPaymentSlpWork paymentSlpWork, string tableNm)
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

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 支払伝票マスタ削除
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcPaymentSlpWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタ削除
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCPaymentSlpWork dcPaymentSlpWork in dcPaymentSlpWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO";
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcPaymentSlpWork.EnterpriseCode;
                findParaPaymentSlipNo.Value = dcPaymentSlpWork.PaymentSlipNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 支払伝票マスタを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 支払伝票マスタ登録
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcPaymentSlpWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 支払伝票マスタ登録
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">支払伝票マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCPaymentSlpWork dcPaymentSlpWork in dcPaymentSlpWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, PAYMENTDATERF, ADDUPADATERF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, AUTOPAYMENTRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEBITNOTEDIV, @PAYMENTSLIPNO, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @PAYMENTINPSECTIONCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @INPUTDAYRF, @PAYMENTDATE, @ADDUPADATE, @PAYMENTTOTAL, @PAYMENT, @FEEPAYMENT, @DISCOUNTPAYMENT, @AUTOPAYMENT, @DRAFTDRAWINGDATE, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEBITNOTELINKPAYNO, @PAYMENTAGENTCODE, @PAYMENTAGENTNAME, @PAYMENTINPUTAGENTCD, @PAYMENTINPUTAGENTNM, @OUTLINE, @BANKCODE, @BANKNAME)";
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPaymentSlpWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPaymentSlpWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcPaymentSlpWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.LogicalDeleteCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DebitNoteDiv);
                paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.PaymentSlipNo);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SupplierSlipNo);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SupplierCd);
                paraSupplierNm1.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.SupplierNm1);
                paraSupplierNm2.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.SupplierNm2);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.SupplierSnm);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.PayeeCode);
                paraPayeeName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PayeeName);
                paraPayeeName2.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PayeeName2);
                paraPayeeSnm.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PayeeSnm);
                paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentInpSectionCd);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.AddUpSecCode);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdateSecCd);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SubSectionCode);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.InputDay);
                paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.PaymentDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.AddUpADate);
                paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.PaymentTotal);
                paraPayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.Payment);
                paraFeePayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.FeePayment);
                paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.DiscountPayment);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.AutoPayment);
                paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.DraftDrawingDate);
                paraDraftKind.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DraftKind);
                paraDraftKindName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.DraftKindName);
                paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DraftDivide);
                paraDraftDivideName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.DraftDivideName);
                paraDraftNo.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.DraftNo);
                paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DebitNoteLinkPayNo);
                paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentAgentCode);
                paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentAgentName);
                paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentInputAgentCd);
                paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentInputAgentNm);
                paraOutline.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.Outline);
                paraBankCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.BankCode);
                paraBankName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.BankName);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 支払伝票マスタを登録する
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
            //sqlCommand.CommandText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND ADDUPSECCODERF = @FINDSECTIONCODERF";//ADD by Liangsd    2011/09/06
            
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
