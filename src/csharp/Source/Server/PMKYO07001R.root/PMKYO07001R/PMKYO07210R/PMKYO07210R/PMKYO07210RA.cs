//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/07/28  修正内容 : 新規作成
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
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 脇田 靖之
// 修 正 日  2014/02/20  修正内容 : 仕掛一覧№2292対応
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
	/// 支払手形データリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払手形データの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 張莉莉</br>
	/// <br>Date       : 2011.7.28</br>
	/// <br></br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
	/// </remarks>
	[Serializable]
	public class APPayDraftDataDB : RemoteDB
	{
		/// <summary>
		/// 支払手形データDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		public APPayDraftDataDB()
			: base("PMKYO07211D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork", "PAYDRAFTDATA")
		{

		}

		# region [Read]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 支払手形データ取得
		/// </summary>
		/// <param name="payDraftDataList">支払手形データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int Search(out ArrayList payDraftDataList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchProc(out payDraftDataList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 支払手形データ取得
		/// </summary>
		/// <param name="payDraftDataList">支払手形データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchProc(out ArrayList payDraftDataList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			payDraftDataList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            
            //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF FROM PAYDRAFTDATARF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE";// DEL 2011/11/01 xupz
            // ----- ADD 2011/11/01 xupz---------->>>>>   
            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)";// DEL K2011/11/01
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0) 
            {
                //支払手形データ.更新日時
                sqlText = sqlText + " WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME";
            }
            //データ送信抽出条件区分が「伝票日付」の場合
            else if (sendDataWork.SndMesExtraCondDiv == 1) 
            {
                //支払手形データ.支払日付
                //sqlText = sqlText + " WHERE PAYMENTDATERF>=@FINDUPDATESTARTDATETIME AND PAYMENTDATERF<=@FINDUPDATEENDDATETIME "; // DEL 2011/11/30
                sqlText = sqlText + " WHERE (( PAYMENTDATERF>=@FINDUPDATESTARTDATETIME AND PAYMENTDATERF<=@FINDUPDATEENDDATETIME) ";  // ADD 2011/11/30

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sqlText = sqlText + " OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ";
                sqlText = sqlText + " OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ";
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sqlText = sqlText + " AND  UPDATEDATETIMERF<=@FINDENDTIMERF ";
                sqlText = sqlText + " AND  PAYMENTDATERF<=@FINDUPDATEENDDATETIME )) ";
                // ----- ADD 2011/11/30 tanh----------<<<<<<
            }
            sqlText = sqlText + " AND ADDUPSECCODERF=@FINDADDUPSECCODE";
            // ----- ADD 2011/11/01 xupz----------<<<<<

			//Prameterオブジェクトの作成
			SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

			//Parameterオブジェクトへ値設定
			findParaUpdateEndDateTime.Value = sendDataWork.StartDateTime;
			findParaUpdateStartDateTime.Value = sendDataWork.EndDateTime;
			findParaSectionCode.Value = sendDataWork.PmSectionCode;

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

			while (myReader.Read())
			{
				payDraftDataList.Add(this.CopyToPayDraftDataListWorkFromReader(ref myReader));
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

		/// <summary>
		/// クラス格納処理 Reader → payDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APPayDraftDataWork CopyToPayDraftDataListWorkFromReader(ref SqlDataReader myReader)
		{
			APPayDraftDataWork payDraftDataWork = new APPayDraftDataWork();

			this.CopyToPayDraftDataListWorkFromReader(ref myReader, ref payDraftDataWork);

			return payDraftDataWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → payDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="payDraftDataWork">payDraftDataWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyToPayDraftDataListWorkFromReader(ref SqlDataReader myReader, ref APPayDraftDataWork payDraftDataWork)
		{
			if (myReader != null && payDraftDataWork != null)
			{
				# region クラスへ格納
				payDraftDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				payDraftDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				payDraftDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				payDraftDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				payDraftDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				payDraftDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				payDraftDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				payDraftDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				payDraftDataWork.PayDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYDRAFTNORF"));
				payDraftDataWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
				payDraftDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
				payDraftDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
				payDraftDataWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
				payDraftDataWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
				payDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				payDraftDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				payDraftDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
				payDraftDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
				payDraftDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
				payDraftDataWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
				payDraftDataWork.ProcDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDATERF"));
				payDraftDataWork.DraftDrawingDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
				payDraftDataWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
				payDraftDataWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
				payDraftDataWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
				payDraftDataWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
				payDraftDataWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
				payDraftDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
				payDraftDataWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
				payDraftDataWork.PaymentDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDATERF"));

				# endregion
			}
		}

		#endregion

		# region [Delete]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 支払手形データ削除
		/// </summary>
		/// <param name="payDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Delete(ArrayList payDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			DeleteProc(payDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand, enterPriseCode);
		}

		/// <summary>
		/// 支払手形データ削除
		/// </summary>
		/// <param name="payDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
		private void DeleteProc(ArrayList payDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			//sqlCommand.CommandText = "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO ";// DEL zhuhh 2013/01/10 for Redmine #34123
            sqlCommand.CommandText = "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmine #34123
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NChar);
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
            SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

			foreach (APPayDraftDataWork payDraftDataWork in payDraftDataWorkList)
			{				
				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = enterPriseCode;
				findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = payDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = payDraftDataWork.DraftDrawingDate;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受取手形データを削除する
				sqlCommand.ExecuteNonQuery();
			}
		}
		#endregion

		# region [Insert]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 支払手形データ登録
		/// </summary>
		/// <param name="payDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Insert(ArrayList payDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			InsertProc(payDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand, enterPriseCode);
		}

		/// <summary>
		/// 支払手形データ登録
		/// </summary>
		/// <param name="payDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void InsertProc(ArrayList payDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			sqlCommand.CommandText = "INSERT INTO PAYDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @PAYMENT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @SUPPLIERFORMAL, @PAYMENTSLIPNO, @PAYMENTROWNO, @PAYMENTDATE)";
			//Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraPayDraftNo = sqlCommand.Parameters.Add("@PAYDRAFTNO", SqlDbType.NVarChar);
			SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
			SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
			SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
			SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
			SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
			SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
			SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
			SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
			SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
			SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
			SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
			SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
			SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
			SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
			SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
			SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
			SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
			SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
			SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
			SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
			SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE ", SqlDbType.Int);

			foreach (APPayDraftDataWork payDraftDataWork in payDraftDataWorkList)
			{
				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(payDraftDataWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.LogicalDeleteCode);
				paraPayDraftNo.Value = SqlDataMediator.SqlSetString(payDraftDataWork.PayDraftNo);
				paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftKindCd);
				paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftDivide);
				paraPayment.Value = SqlDataMediator.SqlSetInt64(payDraftDataWork.Payment);
				paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.BankAndBranchCd);
				paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.BankAndBranchNm);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SectionCode);
				paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.AddUpSecCode);
				paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierCd);
				paraSupplierNm1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm1);
				paraSupplierNm2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm2);
				paraSupplierSnm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierSnm);
				paraProcDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ProcDate);
				paraDraftDrawingDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftDrawingDate);
				paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ValidityTerm);
				paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftStmntDate);
				paraOutline1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline1);
				paraOutline2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline2);
				paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierFormal);
				paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentSlipNo);
				paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentRowNo);
				paraPaymentDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentDate);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

				// 支払手形データを登録する
				sqlCommand.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
