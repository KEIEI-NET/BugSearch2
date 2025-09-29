//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : DC支払手形データ抽出・更新処理　リモートオブジェクト
// プログラム概要   : DC支払手形データ抽出・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/07/28  修正内容 : 新規作成
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
// 修 正 日  2011/11/01 修正内容 :  Redmine#26228拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
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
	/// 支払手形データリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払手形データの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 張莉莉</br>
	/// <br>Date       : 2011.07.21</br>
	/// <br></br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
	/// </remarks>
	[Serializable]
	public class DCPayDraftDataDB : RemoteDB
	{
		/// <summary>
		/// 支払手形データDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		public DCPayDraftDataDB()
			: base("PMKYO07601D", "Broadleaf.Application.Remoting.ParamData.DCPayDraftDataWork", "PAYDRAFTDATA")
		{

		}

		# region [Read]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 支払手形データ取得
		/// </summary>
		/// <param name="payDraftDataList">支払手形データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int Search(out ArrayList payDraftDataList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchProc(out payDraftDataList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 支払手形データ取得
		/// </summary>
		/// <param name="payDraftDataList">支払手形データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchProc(out ArrayList payDraftDataList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			payDraftDataList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //  ADD dingjx  2011/11/01  ------------------------------------->>>>>>
            if ((receiveDataWork.Kind == 0) && (receiveDataWork.SndLogExtraCondDiv == 1))
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF FROM PAYDRAFTDATARF WITH (READUNCOMMITTED) WHERE PAYMENTDATERF>=@FINDUPDATESTARTDATETIME AND PAYMENTDATERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE"; // DEL 2011/11/30
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF FROM PAYDRAFTDATARF WITH (READUNCOMMITTED) WHERE ((PAYMENTDATERF>=@FINDUPDATESTARTDATETIME AND PAYMENTDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>=@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  PAYMENTDATERF<=@FINDUPDATEENDDATETIME)) AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // ADD 2011/11/30
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF FROM PAYDRAFTDATARF WITH (READUNCOMMITTED) WHERE ((PAYMENTDATERF>=@FINDUPDATESTARTDATETIME AND PAYMENTDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  PAYMENTDATERF<=@FINDUPDATEENDDATETIME)) AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
            else
            //  ADD dingjx  2011/11/01  -------------------------------------<<<<<<
			    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF FROM PAYDRAFTDATARF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";

			//Prameterオブジェクトの作成
			SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);// ADD 2011/08/18 張莉莉　Redmine#23746

			//Parameterオブジェクトへ値設定
			findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
			findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
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
		/// クラス格納処理 Reader → dCPayDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		private DCPayDraftDataWork CopyToPayDraftDataListWorkFromReader(ref SqlDataReader myReader)
		{
			DCPayDraftDataWork dCPayDraftDataWork = new DCPayDraftDataWork();

			this.CopyToPayDraftDataListWorkFromReader(ref myReader, ref dCPayDraftDataWork);

			return dCPayDraftDataWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → dCDepositAlwWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="dCPayDraftDataWork">dCPayDraftDataWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		private void CopyToPayDraftDataListWorkFromReader(ref SqlDataReader myReader, ref DCPayDraftDataWork dCPayDraftDataWork)
		{
			if (myReader != null && dCPayDraftDataWork != null)
			{
				# region クラスへ格納
				dCPayDraftDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				dCPayDraftDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				dCPayDraftDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				dCPayDraftDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				dCPayDraftDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				dCPayDraftDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				dCPayDraftDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				dCPayDraftDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				dCPayDraftDataWork.PayDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYDRAFTNORF"));
				dCPayDraftDataWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
				dCPayDraftDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
				dCPayDraftDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
				dCPayDraftDataWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
				dCPayDraftDataWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
				dCPayDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				dCPayDraftDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				dCPayDraftDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
				dCPayDraftDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
				dCPayDraftDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
				dCPayDraftDataWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
				dCPayDraftDataWork.ProcDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDATERF"));
				dCPayDraftDataWork.DraftDrawingDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
				dCPayDraftDataWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
				dCPayDraftDataWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
				dCPayDraftDataWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
				dCPayDraftDataWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
				dCPayDraftDataWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
				dCPayDraftDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
				dCPayDraftDataWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
				dCPayDraftDataWork.PaymentDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDATERF"));

				# endregion
			}
		}

		#endregion

		# region [Delete]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 支払手形データ削除
		/// </summary>
		/// <param name="dCPayDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Delete(ArrayList dCPayDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			DeleteProc(dCPayDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
		}

		/// <summary>
		/// 支払手形データ削除
		/// </summary>
		/// <param name="dCPayDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
		private void DeleteProc(ArrayList dCPayDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
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

			foreach (DCPayDraftDataWork dCPayDraftDataWork in dCPayDraftDataWorkList)
			{
				//sqlCommand.Parameters.Clear();
				
				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = dCPayDraftDataWork.EnterpriseCode;
				findParaPayDraftNo.Value = dCPayDraftDataWork.PayDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = dCPayDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = dCPayDraftDataWork.DraftDrawingDate;
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
		/// <param name="dCPayDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Insert(ArrayList dCPayDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			InsertProc(dCPayDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
		}

		/// <summary>
		/// 支払手形データ登録
		/// </summary>
		/// <param name="dCPayDraftDataWorkList">支払手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void InsertProc(ArrayList dCPayDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
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


			foreach (DCPayDraftDataWork dCPayDraftDataWork in dCPayDraftDataWorkList)
			{

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dCPayDraftDataWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dCPayDraftDataWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dCPayDraftDataWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.LogicalDeleteCode);
				paraPayDraftNo.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.PayDraftNo);
				paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.DraftKindCd);
				paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.DraftDivide);
				paraPayment.Value = SqlDataMediator.SqlSetInt64(dCPayDraftDataWork.Payment);
				paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.BankAndBranchCd);
				paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.BankAndBranchNm);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.SectionCode);
				paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.AddUpSecCode);
				paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.SupplierCd);
				paraSupplierNm1.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.SupplierNm1);
				paraSupplierNm2.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.SupplierNm2);
				paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.SupplierSnm);
				paraProcDate.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.ProcDate);
				paraDraftDrawingDate.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.DraftDrawingDate);
				paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.ValidityTerm);
				paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.DraftStmntDate);
				paraOutline1.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.Outline1);
				paraOutline2.Value = SqlDataMediator.SqlSetString(dCPayDraftDataWork.Outline2);
				paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.SupplierFormal);
				paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.PaymentSlipNo);
				paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.PaymentRowNo);
				paraPaymentDate.Value = SqlDataMediator.SqlSetInt32(dCPayDraftDataWork.PaymentDate);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 支払手形データを登録する
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
            sqlCommand.CommandText = "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDSECTIONCODERF";
           
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
