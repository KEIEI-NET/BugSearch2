//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : DC 入金引当マスタ抽出・更新処理　リモートオブジェクト
// プログラム概要   : DC 入金引当マスタ抽出・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/07/21  修正内容 : 新規作成
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
// 管理番号              作成担当 : 呉軍
// 修 正 日  2011/11/10 修正内容 :  Redmine#26228拠点管理改良／伝票日付による抽出対応
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
	/// <br>Date       : 2011.07.21</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class DCDepositAlwDB : RemoteDB
	{
		/// <summary>
		/// 入金引当マスタデータDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		public DCDepositAlwDB()
			: base("PMKYO07581D", "Broadleaf.Application.Remoting.ParamData.DCDepositAlwWork", "DEPOSITALW")
		{

		}

		# region [Read]
		
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 入金引当マスタデータ取得
		/// </summary>
		/// <param name="depositAlwList">入金引当マスタデータ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int Search(out ArrayList depositAlwList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchProc(out depositAlwList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}
		
		/// <summary>
		/// 入金引当マスタデータ取得
		/// </summary>
		/// <param name="depositAlwList">入金引当マスタデータ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchProc(out ArrayList depositAlwList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			depositAlwList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //  ADD dingjx  2011/11/01  ------------------------------>>>>>>
            if ((receiveDataWork.Kind == 0) && (receiveDataWork.SndLogExtraCondDiv == 1))
                // DEL BY 呉軍 2011/11/10  ------------------------------>>>>>>
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED) WHERE RECONCILEDATERF>=@FINDUPDATESTARTDATETIME AND RECONCILEDATERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE"; 
                // DEL BY 呉軍 2011/11/10  -----------------------------<<<<<<
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //// ADD BY 呉軍 2011/11/10  ------------------------------>>>>>>
                ////sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED) WHERE RECONCILEADDUPDATERF>=@FINDUPDATESTARTDATETIME AND RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // DEL 2011/11/30
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED) WHERE ((RECONCILEADDUPDATERF>=@FINDUPDATESTARTDATETIME AND RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>=@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME)) AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";   // ADD 2011/11/30
                //// ADD BY 呉軍 2011/11/10  -----------------------------<<<<<<
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED) WHERE ((RECONCILEADDUPDATERF>=@FINDUPDATESTARTDATETIME AND RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  RECONCILEADDUPDATERF<=@FINDUPDATEENDDATETIME)) AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
            else
            //  ADD dingjx  2011/11/01  ------------------------------<<<<<<
			    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF FROM DEPOSITALWRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ADDUPSECCODERF=@FINDADDUPSECCODE  AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
		/// クラス格納処理 Reader → dCDepositAlwWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		private DCDepositAlwWork CopyToDepositAlwWorkFromReader(ref SqlDataReader myReader)
		{
			DCDepositAlwWork dCDepositAlwWork = new DCDepositAlwWork();

			this.CopyToDepositAlwWorkFromReader(ref myReader, ref dCDepositAlwWork);

			return dCDepositAlwWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → dCDepositAlwWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="dCDepositAlwWork">dCDepositAlwWork オブジェクト</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		/// </remarks>
		private void CopyToDepositAlwWorkFromReader(ref SqlDataReader myReader, ref DCDepositAlwWork dCDepositAlwWork)
		{
			if (myReader != null && dCDepositAlwWork != null)
			{
				# region クラスへ格納
				dCDepositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				dCDepositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				dCDepositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				dCDepositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				dCDepositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				dCDepositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				dCDepositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				dCDepositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				dCDepositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
				dCDepositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				dCDepositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				dCDepositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
				dCDepositAlwWork.ReconcileDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEDATERF"));
				dCDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
				dCDepositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
				dCDepositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
				dCDepositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
				dCDepositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
				dCDepositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				dCDepositAlwWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				dCDepositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
				dCDepositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));

				# endregion
			}
		}

		#endregion

		# region [Delete]
		
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// 入金引当マスタデータ削除
		/// </summary>
		/// <param name="dCDepositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Delete(ArrayList dCDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			DeleteProc(dCDepositAlwWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
		}
		
		/// <summary>
		/// 入金引当マスタデータ削除
		/// </summary>
		/// <param name="dCDepositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void DeleteProc(ArrayList dCDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			sqlCommand.CommandText = "DELETE FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO ";
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
			SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
			SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

			foreach (DCDepositAlwWork dCDepositAlwWork in dCDepositAlwWorkList)
			{
				
				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = dCDepositAlwWork.EnterpriseCode;
				findParaAcptAnOdrStatus.Value = dCDepositAlwWork.AcptAnOdrStatus;
				findParaSalesSlipNum.Value = dCDepositAlwWork.SalesSlipNum;
				findParaDepositSlipNo.Value = dCDepositAlwWork.DepositSlipNo;

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
		/// <param name="dCDepositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Insert(ArrayList dCDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			InsertProc(dCDepositAlwWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
		}
		
		/// <summary>
		/// 入金引当マスタデータ登録
		/// </summary>
		/// <param name="dCDepositAlwWorkList">入金引当マスタデータ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void InsertProc(ArrayList dCDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
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

			foreach (DCDepositAlwWork dCDepositAlwWork in dCDepositAlwWorkList)
			{				

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dCDepositAlwWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dCDepositAlwWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dCDepositAlwWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.LogicalDeleteCode);
				paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.InputDepositSecCd);
				paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.AddUpSecCode);
				paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.AcptAnOdrStatus);
				paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.SalesSlipNum);
				paraReconcileDate.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.ReconcileDate);
				paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.ReconcileAddUpDate);
				paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.DepositSlipNo);
				paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(dCDepositAlwWork.DepositAllowance);
				paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.DepositAgentCode);
				paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.DepositAgentNm);
				paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.CustomerCode);
				paraCustomerName.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.CustomerName);
				paraCustomerName2.Value = SqlDataMediator.SqlSetString(dCDepositAlwWork.CustomerName2);
				paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(dCDepositAlwWork.DebitNoteOffSetCd);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 入金引当マスタデータを登録する
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
            //sqlCommand.CommandText = "DELETE FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND ADDUPSECCODERF =@FINDSECTIONCODERF";
            
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
