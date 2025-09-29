//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
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
	/// 受取手形データリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 受取手形データの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 張莉莉</br>
	/// <br>Date       : 2011.7.28</br>
	/// <br></br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
	/// </remarks>
	[Serializable]
	public class APRcvDraftDataDB : RemoteDB
	{
		/// <summary>
		/// 受取手形データDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		public APRcvDraftDataDB()
			: base("PMKYO07201D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork", "RCVDRAFTDATA")
		{

		}

		# region [Read]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 受取手形データ取得
		/// </summary>
		/// <param name="rcvDraftDataList">受取手形データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int Search(out ArrayList rcvDraftDataList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchProc(out rcvDraftDataList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 受取手形データ取得
		/// </summary>
		/// <param name="rcvDraftDataList">受取手形データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchProc(out ArrayList rcvDraftDataList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			rcvDraftDataList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF FROM RCVDRAFTDATARF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE"; // DEL 2011/11/01 xupz
            // ----- ADD 2011/11/01 xupz---------->>>>>>
            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)";
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0) 
            {
                //受取手形データ.更新日時
                sqlText = sqlText + " WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME";
            }
            //データ送信抽出条件区分が「伝票日付」の場合
            else if (sendDataWork.SndMesExtraCondDiv == 1) 
            {
                //受取手形データ.支払日付
                //sqlText = sqlText + " WHERE DEPOSITDATERF>=@FINDUPDATESTARTDATETIME AND DEPOSITDATERF<=@FINDUPDATEENDDATETIME";  // DEL 2011/11/30
                sqlText = sqlText + " WHERE (( DEPOSITDATERF>=@FINDUPDATESTARTDATETIME AND DEPOSITDATERF<=@FINDUPDATEENDDATETIME)";  // ADD 2011/11/30

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sqlText = sqlText + " OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ";
                sqlText = sqlText + " OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ";
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sqlText = sqlText + " AND  UPDATEDATETIMERF<=@FINDENDTIMERF ";
                sqlText = sqlText + " AND  DEPOSITDATERF<=@FINDUPDATEENDDATETIME )) ";
                // ----- ADD 2011/11/30 tanh----------<<<<<<

            }
            sqlText = sqlText + " AND ADDUPSECCODERF=@FINDADDUPSECCODE";
            // ----- ADD 2011/11/01  xupz----------<<<<<<
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
		/// クラス格納処理 Reader → rcvDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APRcvDraftDataWork CopyToRcvDraftDataWorkFromReader(ref SqlDataReader myReader)
		{
			APRcvDraftDataWork rcvDraftDataWork = new APRcvDraftDataWork();

			this.CopyToRcvDraftDataWorkFromReader(ref myReader, ref rcvDraftDataWork);

			return rcvDraftDataWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → rcvDraftDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="rcvDraftDataWork">rcvDraftDataWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyToRcvDraftDataWorkFromReader(ref SqlDataReader myReader, ref APRcvDraftDataWork rcvDraftDataWork)
		{
			if (myReader != null && rcvDraftDataWork != null)
			{
				# region クラスへ格納
				rcvDraftDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				rcvDraftDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				rcvDraftDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				rcvDraftDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				rcvDraftDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				rcvDraftDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				rcvDraftDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				rcvDraftDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				rcvDraftDataWork.RcvDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RCVDRAFTNORF"));
				rcvDraftDataWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
				rcvDraftDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
				rcvDraftDataWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
				rcvDraftDataWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
				rcvDraftDataWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
				rcvDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				rcvDraftDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				rcvDraftDataWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				rcvDraftDataWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				rcvDraftDataWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
				rcvDraftDataWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
				rcvDraftDataWork.ProcDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDATERF"));
				rcvDraftDataWork.DraftDrawingDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
				rcvDraftDataWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
				rcvDraftDataWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
				rcvDraftDataWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
				rcvDraftDataWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
				rcvDraftDataWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				rcvDraftDataWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
				rcvDraftDataWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
				rcvDraftDataWork.DepositDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDATERF"));

				# endregion
			}
		}

		#endregion

		# region [Delete]

		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 受取手形データ削除
		/// </summary>
		/// <param name="rcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Delete(ArrayList rcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			DeleteProc(rcvDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand, enterPriseCode);
		}

		/// <summary>
		/// 受取手形データ削除
		/// </summary>
		/// <param name="rcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
		private void DeleteProc(ArrayList rcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
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

			foreach (APRcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
			{				
				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = enterPriseCode;
				findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = rcvDraftDataWork.DraftDrawingDate;
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
		/// <param name="rcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Insert(ArrayList rcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			InsertProc(rcvDraftDataWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand, enterPriseCode);
		}

		/// <summary>
		/// 受取手形データ登録
		/// </summary>
		/// <param name="rcvDraftDataWorkList">受取手形データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void InsertProc(ArrayList rcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
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

			foreach (APRcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
			{
				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rcvDraftDataWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.LogicalDeleteCode);
				paraRcvDraftNo.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.RcvDraftNo);
				paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftKindCd);
				paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftDivide);
				paraDeposit.Value = SqlDataMediator.SqlSetInt64(rcvDraftDataWork.Deposit);
				paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.BankAndBranchCd);
				paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.BankAndBranchNm);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.SectionCode);
				paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.AddUpSecCode);
				paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.CustomerCode);
				paraCustomerName.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName);
				paraCustomerName2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName2);
				paraCustomerSnm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerSnm);
				paraProcDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ProcDate);
				paraDraftDrawingDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftDrawingDate);
				paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ValidityTerm);
				paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftStmntDate);
				paraOutline1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline1);
				paraOutline2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline2);
				paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.AcptAnOdrStatus);
				paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositSlipNo);
				paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositRowNo);
				paraDepositDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositDate);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受取手形データを登録する
				sqlCommand.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
