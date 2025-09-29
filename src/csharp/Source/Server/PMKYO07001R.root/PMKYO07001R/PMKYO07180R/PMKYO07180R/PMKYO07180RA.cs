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
// 管理番号              作成担当 : 陳建明
// 修 正 日  2011/11/10  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
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
	/// 入金引当マスタデータリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金引当マスタデータの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 張莉莉</br>
	/// <br>Date       : 2011.7.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class APDepositAlwDB : RemoteDB
	{
		/// <summary>
		/// 入金引当マスタデータDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		public APDepositAlwDB()
			: base("PMKYO07181D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork", "DEPOSITALW")
		{

		}

		# region [Read]
		
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 入金引当マスタデータ取得
		/// </summary>
		/// <param name="depositAlwList">入金引当マスタデータ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int Search(out ArrayList depositAlwList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchProc(out depositAlwList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}
		
		/// <summary>
		/// 入金引当マスタデータ取得
		/// </summary>
		/// <param name="depositAlwList">入金引当マスタデータ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchProc(out ArrayList depositAlwList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			depositAlwList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE"; // DEL 2011/11/01 xupz
            //-------ADD 2011/11/01 xupz------->>>>>>
            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED)";
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0)
            {
                //  入金引当マスタ.更新日時
                sqlText = sqlText + " WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME";
            }
            //データ送信抽出条件区分が「伝票日付」の場合
            else if (sendDataWork.SndMesExtraCondDiv == 1)
            {
                //  入金引当マスタ.消込み計上日付
                sqlText = sqlText + " WHERE (( RECONCILEADDUPDATERF>=@FINDUPDATESTARTDATETIME AND RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME)"; //ADD by 陳建明 2011/11/10　
                //sqlText = sqlText + " WHERE RECONCILEDATERF>=@FINDUPDATESTARTDATETIME AND RECONCILEDATERF<=@FINDUPDATEENDDATETIME"; //DELETE by 陳建明 2011/11/10

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sqlText = sqlText + " OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ";
                sqlText = sqlText + " OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ";
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sqlText = sqlText + " AND  UPDATEDATETIMERF<=@FINDENDTIMERF ";
                sqlText = sqlText + " AND  RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME )) ";
                // ----- ADD 2011/11/30 tanh----------<<<<<<
            }
            sqlText = sqlText + " AND ADDUPSECCODERF=@FINDADDUPSECCODE";
            //-------ADD 2011/11/01 xupz-------<<<<<<
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
				depositAlwList.Add(this.CopyToDepositAlwWorkFromReader(ref myReader));
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
		/// クラス格納処理 Reader → depositAlwWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private APDepositAlwWork CopyToDepositAlwWorkFromReader(ref SqlDataReader myReader)
		{
			APDepositAlwWork depositAlwWork = new APDepositAlwWork();

			this.CopyToDepositAlwWorkFromReader(ref myReader, ref depositAlwWork);

			return depositAlwWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → depositAlwWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="depositAlwWork">depositAlwWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.28</br>
		/// </remarks>
		private void CopyToDepositAlwWorkFromReader(ref SqlDataReader myReader, ref APDepositAlwWork depositAlwWork)
		{
			if (myReader != null && depositAlwWork != null)
			{
				# region クラスへ格納
				depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
				depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
				depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEDATERF"));
				depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
				depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
				depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
				depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
				depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
				depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
				depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));

				# endregion
			}
		}

		#endregion

		# region [Delete]
		
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 入金引当マスタデータ削除
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Delete(ArrayList depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			DeleteProc(depositAlwWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand, enterPriseCode);
		}
		
		/// <summary>
		/// 入金引当マスタデータ削除
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void DeleteProc(ArrayList depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			sqlCommand.CommandText = "DELETE FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO ";
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
			SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
			SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

			foreach (APDepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = enterPriseCode;
				findParaAcptAnOdrStatus.Value = depositAlwWork.AcptAnOdrStatus;
				findParaSalesSlipNum.Value = depositAlwWork.SalesSlipNum;
				findParaDepositSlipNo.Value = depositAlwWork.DepositSlipNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 入金引当マスタデータを削除する
				sqlCommand.ExecuteNonQuery();
			}
		}
		#endregion

		# region [Insert]
		
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 入金引当マスタデータ登録
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Insert(ArrayList depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			InsertProc(depositAlwWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand, enterPriseCode);
		}
		
		/// <summary>
		/// 入金引当マスタデータ登録
		/// </summary>
		/// <param name="depositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="enterPriseCode">enterPriseCode</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void InsertProc(ArrayList depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, string enterPriseCode)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			sqlCommand.CommandText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @ACPTANODRSTATUS, @SALESSLIPNUM, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEPOSITSLIPNO, @DEPOSITALLOWANCE, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @DEBITNOTEOFFSETCD)";
			//Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
			SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
			SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
			SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
			SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
			SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
			SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
			SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
			SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
			SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
			SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
			SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
			SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);

			foreach (APDepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
				paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
				paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
				paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
				paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
				paraReconcileDate.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.ReconcileDate);
				paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.ReconcileAddUpDate);
				paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
				paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
				paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
				paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
				paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
				paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
				paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
				paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 入金引当マスタデータを登録する
				sqlCommand.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
