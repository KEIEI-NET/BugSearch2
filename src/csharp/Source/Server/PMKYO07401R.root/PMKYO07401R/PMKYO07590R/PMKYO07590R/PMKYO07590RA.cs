//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : DC受取手形データ抽出・更新処理　リモートオブジェクト
// プログラム概要   : DC受取手形データ抽出・更新処理を行う
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
	/// 受取手形データリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 受取手形データの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 張莉莉</br>
	/// <br>Date       : 2011.07.21</br>
	/// <br></br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
	/// </remarks>
	[Serializable]
	public class DCRcvDraftDataDB : RemoteDB
	{
		/// <summary>
		/// 受取手形データDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		public DCRcvDraftDataDB()
			: base("PMKYO07591D", "Broadleaf.Application.Remoting.ParamData.DCRcvDraftDataWork", "RCVDRAFTDATA")
		{

		}

		# region [Read]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 受取手形データ取得
		/// </summary>
		/// <param name="rcvDraftDataList">受取手形データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int Search(out ArrayList rcvDraftDataList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchProc(out rcvDraftDataList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 受取手形データ取得
		/// </summary>
		/// <param name="rcvDraftDataList">受取手形データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchProc(out ArrayList rcvDraftDataList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			rcvDraftDataList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //  ADD dingjx  2011/11/01  -------------------------------->>>>>>
            if ((receiveDataWork.Kind == 0) && (receiveDataWork.SndLogExtraCondDiv == 1))
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF FROM RCVDRAFTDATARF WITH (READUNCOMMITTED) WHERE DEPOSITDATERF>=@FINDUPDATESTARTDATETIME AND DEPOSITDATERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // DEL 2011/11/30
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF FROM RCVDRAFTDATARF WITH (READUNCOMMITTED) WHERE ((DEPOSITDATERF>=@FINDUPDATESTARTDATETIME AND DEPOSITDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>=@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  DEPOSITDATERF<=@FINDUPDATEENDDATETIME)) AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // ADD 2011/11/30
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF FROM RCVDRAFTDATARF WITH (READUNCOMMITTED) WHERE ((DEPOSITDATERF>=@FINDUPDATESTARTDATETIME AND DEPOSITDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  DEPOSITDATERF<=@FINDUPDATEENDDATETIME)) AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
            else
            //  ADD dingjx  2011/11/01  --------------------------------<<<<<<
			    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF FROM RCVDRAFTDATARF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
				rcvDraftDataList.Add(this.CopyToRcvDraftDataWorkFromReader(ref myReader));
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
		/// クラス格納処理 Reader → dCRcvDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		private DCRcvDraftDataWork CopyToRcvDraftDataWorkFromReader(ref SqlDataReader myReader)
		{
			DCRcvDraftDataWork dCRcvDraftDataWork = new DCRcvDraftDataWork();

			this.CopyToRcvDraftDataWorkFromReader(ref myReader, ref dCRcvDraftDataWork);

			return dCRcvDraftDataWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → dCRcvDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="dCRcvDraftDataWork">dCRcvDraftDataWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		private void CopyToRcvDraftDataWorkFromReader(ref SqlDataReader myReader, ref DCRcvDraftDataWork dCRcvDraftDataWork)
		{
			if (myReader != null && dCRcvDraftDataWork != null)
			{
				# region クラスへ格納
				dCRcvDraftDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				dCRcvDraftDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				dCRcvDraftDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				dCRcvDraftDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				dCRcvDraftDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				dCRcvDraftDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				dCRcvDraftDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				dCRcvDraftDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				dCRcvDraftDataWork.RcvDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RCVDRAFTNORF"));
				dCRcvDraftDataWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
				dCRcvDraftDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
				dCRcvDraftDataWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
				dCRcvDraftDataWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
				dCRcvDraftDataWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
				dCRcvDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				dCRcvDraftDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				dCRcvDraftDataWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				dCRcvDraftDataWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				dCRcvDraftDataWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
				dCRcvDraftDataWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
				dCRcvDraftDataWork.ProcDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDATERF"));
				dCRcvDraftDataWork.DraftDrawingDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
				dCRcvDraftDataWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
				dCRcvDraftDataWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
				dCRcvDraftDataWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
				dCRcvDraftDataWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
				dCRcvDraftDataWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				dCRcvDraftDataWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
				dCRcvDraftDataWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
				dCRcvDraftDataWork.DepositDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDATERF"));

				# endregion
			}
		}

		#endregion

		# region [Delete]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 受取手形データ削除
		/// </summary>
		/// <param name="dCRcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Delete(ArrayList dCRcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			DeleteProc(dCRcvDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
		}

		/// <summary>
		/// 受取手形データ削除
		/// </summary>
		/// <param name="dCRcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
		private void DeleteProc(ArrayList dCRcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			//sqlCommand.CommandText = "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO ";// DEL zhuhh 2013/01/10 for Redmine #34123
            sqlCommand.CommandText = "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmine #34123
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NChar);
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
            SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

			foreach (DCRcvDraftDataWork dCRcvDraftDataWork in dCRcvDraftDataWorkList)
			{

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = dCRcvDraftDataWork.EnterpriseCode;
				findParaRcvDraftNo.Value = dCRcvDraftDataWork.RcvDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = dCRcvDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = dCRcvDraftDataWork.DraftDrawingDate;
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
		/// 受取手形データ登録
		/// </summary>
		/// <param name="dCRcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Insert(ArrayList dCRcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			InsertProc(dCRcvDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
		}

		/// <summary>
		/// 受取手形データ登録
		/// </summary>
		/// <param name="dCRcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void InsertProc(ArrayList dCRcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			sqlCommand.CommandText = "INSERT INTO RCVDRAFTDATARF ( CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF ) VALUES ( @CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @RCVDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @DEPOSIT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @ACPTANODRSTATUS, @DEPOSITSLIPNO, @DEPOSITROWNO, @DEPOSITDATE )";
			//Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraRcvDraftNo = sqlCommand.Parameters.Add("@RCVDRAFTNO", SqlDbType.NVarChar);
			SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
			SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
			SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
			SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
			SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
			SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
			SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
			SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
			SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
			SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
			SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
			SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
			SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
			SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
			SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
			SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
			SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
			SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
			SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
			SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);

			foreach (DCRcvDraftDataWork dCRcvDraftDataWork in dCRcvDraftDataWorkList)
			{				

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dCRcvDraftDataWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dCRcvDraftDataWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dCRcvDraftDataWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.LogicalDeleteCode);
				paraRcvDraftNo.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.RcvDraftNo);
				paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DraftKindCd);
				paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DraftDivide);
				paraDeposit.Value = SqlDataMediator.SqlSetInt64(dCRcvDraftDataWork.Deposit);
				paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.BankAndBranchCd);
				paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.BankAndBranchNm);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.SectionCode);
				paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.AddUpSecCode);
				paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.CustomerCode);
				paraCustomerName.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.CustomerName);
				paraCustomerName2.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.CustomerName2);
				paraCustomerSnm.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.CustomerSnm);
				paraProcDate.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.ProcDate);
				paraDraftDrawingDate.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DraftDrawingDate);
				paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.ValidityTerm);
				paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DraftStmntDate);
				paraOutline1.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.Outline1);
				paraOutline2.Value = SqlDataMediator.SqlSetString(dCRcvDraftDataWork.Outline2);
				paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.AcptAnOdrStatus);
				paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DepositSlipNo);
				paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DepositRowNo);
				paraDepositDate.Value = SqlDataMediator.SqlSetInt32(dCRcvDraftDataWork.DepositDate);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受取手形データを登録する
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
            sqlCommand.CommandText = "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND ADDUPSECCODERF =@FINDSECTIONCODERF";
            
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
