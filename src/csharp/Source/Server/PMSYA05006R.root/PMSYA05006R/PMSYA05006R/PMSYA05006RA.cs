//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日更新
// プログラム概要   : 車検期日更新DBリモートオブジェクト。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/25  修正内容 : redmine #8013を対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 車検期日更新READDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 車検期日更新READの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 王海立</br>
	/// <br>Date       : 2010/04/21</br>
	/// </remarks>
	[Serializable]
	public class InspectDateUpdDB : RemoteWithAppLockDB, IInspectDateUpdDB
	{
		# region ■ Constructor ■
		/// <summary>
		/// 車検期日更新処理READDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 車検期日更新処理READの実データ操作を行うクラスです。</br>
		/// <br>Programmer : 王海立</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>
		public InspectDateUpdDB()
		{
		}
		#endregion


		#region ■ 車検期日更新処理 ■
		/// <summary>
		/// 車検期日更新処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="updateDate">更新年月</param>
		/// <param name="searchNum">抽出件数</param>
		/// <param name="updNum">更新件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 車検期日更新処理を行うクラスです。</br>
		/// <br>Programmer : 王海立</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>
		public int InspectDateUpdProc(string enterpriseCode, int updateDate, out int searchNum, out int updNum)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			searchNum = 0;
			updNum = 0;
			//--------------------------
			// データベースオープン
			//--------------------------
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			ShareCheckInfo info = new ShareCheckInfo();

			try
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (_connectionText == null || _connectionText == "")
				{
					return status;
				}

				sqlConnection = new SqlConnection(_connectionText);
				sqlConnection.Open();
				//●トランザクション開始
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				#region 排他制御
				//システムロック(企業)
				info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
				status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

				if (status != 0)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
					return status;
				}
				#endregion

				ArrayList carManagementWorkList = null;

				status = SearchCarManagement(enterpriseCode, updateDate, out carManagementWorkList, ref sqlConnection, ref sqlTransaction);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					searchNum = carManagementWorkList.Count;
					status = UpdateCarManagement(ref updNum, carManagementWorkList, ref sqlConnection, ref sqlTransaction);
				}
			}
			catch (Exception ex)
			{
				// 基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "InspectDateUpdDB.InspectDateUpdProc Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if (sqlConnection != null)
				{
					if (sqlTransaction.Connection != null)
					{
						//システムロック解除
						int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							status = st;
						}

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							sqlTransaction.Commit();
						}
						else
						{
							sqlTransaction.Rollback();
						}
					}
				}

				if (sqlTransaction != null) sqlTransaction.Dispose();
				if (sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			return status;
		}


		/// <summary>
		/// 指定された条件の車検期日情報を戻します(外部からのSqlConnectionを使用)
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="updateDate">更新年月</param>
		/// <param name="carManagementWorkList">車輌管理マスタ</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>  
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 車検期日更新処理を行うクラスです。</br>
		/// <br>Programmer : 王海立</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>        
		private int SearchCarManagement(string enterpriseCode, int updateDate, out ArrayList carManagementWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			//変数の宣言
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			//変数の初期化
			carManagementWorkList = new ArrayList();

			if (sqlConnection == null)
			{
				return status;
			}

			if (sqlTransaction == null)
			{
				return status;
			}

			SqlCommand command = new SqlCommand("", sqlConnection, sqlTransaction);
			SqlDataReader myReader = null;

			try
			{
				//Selectコマンドの生成
				StringBuilder sql = new StringBuilder();
				sql.Append("SELECT ");
				sql.Append("  UPDATEDATETIMERF, ");
				sql.Append("  ENTERPRISECODERF, ");
				sql.Append("  LOGICALDELETECODERF, ");
				sql.Append("  CUSTOMERCODERF, ");
				sql.Append("  CARMNGNORF, ");
				sql.Append("  CARMNGCODERF, ");// ADD 2010/05/25 by jiangk for add Primary Key CarMngCode
				sql.Append("  INSPECTMATURITYDATERF, ");
				sql.Append("  CARINSPECTYEARRF ");
				sql.Append("FROM   ");
				sql.Append("  CARMANAGEMENTRF WITH (READUNCOMMITTED) ");
				sql.Append("WHERE  ");
				sql.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE ");
				sql.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
				sql.Append("  AND INSPECTMATURITYDATERF >= @FINDINSPECTMATURITYDATEMIN ");
				sql.Append("  AND INSPECTMATURITYDATERF <= @FINDINSPECTMATURITYDATEMAX ");

				//パラメータクラスの生成をする
				SqlParameter findParaEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				SqlParameter findParaInspectMaturityDateMin = command.Parameters.Add("@FINDINSPECTMATURITYDATEMIN", SqlDbType.Int);
				SqlParameter findParaInspectMaturityDateMax = command.Parameters.Add("@FINDINSPECTMATURITYDATEMAX", SqlDbType.Int);

				//パラメータを設定する
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
				findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
				findParaInspectMaturityDateMin.Value = SqlDataMediator.SqlSetInt32(1);
				findParaInspectMaturityDateMax.Value = SqlDataMediator.SqlSetInt32(updateDate);

				command.CommandText = sql.ToString();

				//読み込む
				myReader = command.ExecuteReader();
				//読み込めた場合
				while (myReader.Read())
				{
					CarManagementWork work = new CarManagementWork();

					//データをセットする
					work.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					work.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
					work.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					work.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
					work.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
					work.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF")); // ADD 2010/05/25 by jiangk for add Primary Key CarMngCode
					int inspectMaturityDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));
					work.InspectMaturityDate = new DateTime(inspectMaturityDate / 10000, (inspectMaturityDate / 100) % 100, inspectMaturityDate % 100);
					work.CarInspectYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));

					//リストに設定する
					carManagementWorkList.Add(work);
					//戻り値を設定する
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "InspectDateUpdDB.SearchCarManagement");
			}
			finally
			{
				if (myReader != null)
					if (!myReader.IsClosed) myReader.Close();
			}

			return status;
		}


		/// <summary>
		/// 指定された条件の車検期日情報を更新します(外部からのSqlConnectionを使用)
		/// </summary>
		/// <param name="updNum">更新件数</param>
		/// <param name="carManagementWorkList">車輌管理マスタ</param>
		/// <param name="sqlConnection">ＤＢ接続オブジェクト</param>  
		/// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 車検期日更新処理を行うクラスです。</br>
		/// <br>Programmer : 王海立</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>        
		private int UpdateCarManagement(ref int updNum, ArrayList carManagementWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			//変数の宣言
			int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

			if (sqlConnection == null)
			{
				return status;
			}

			if (sqlTransaction == null)
			{
				return status;
			}

			SqlCommand command = new SqlCommand("", sqlConnection, sqlTransaction);
			SqlDataReader myReader = null;
			StringBuilder sql = null;

			try
			{
				//パラメータクラスの生成をする
				SqlParameter findParaEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				SqlParameter findParaCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
				SqlParameter findParaCarMngNo = command.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
				SqlParameter findParaCarMngCode = command.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NVarChar);// ADD 2010/05/25 by jiangk for add Primary Key CarMngCode

				int cnt = 0;

				#region Parameterオブジェクトの作成(更新用)
				//Prameterオブジェクトの作成
				//Parameterオブジェクトの作成(更新用)
				SqlParameter paraUpdateDateTime = null;
				SqlParameter paraUpdEmployeeCode = null;
				SqlParameter paraUpdAssemblyId1 = null;
				SqlParameter paraUpdAssemblyId2 = null;
				SqlParameter paraInspectMaturityDate = null;
				SqlParameter paraLTimeCiMatDate = null;
				#endregion

				foreach (CarManagementWork item in carManagementWorkList)
				{
					//Selectコマンドの生成
					sql = new StringBuilder();
					sql.Append("SELECT ");
					sql.Append("  UPDATEDATETIMERF ");
					sql.Append("FROM   ");
					sql.Append("  CARMANAGEMENTRF WITH (READUNCOMMITTED) ");
					sql.Append("WHERE  ");
					sql.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE ");
					sql.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
					sql.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE ");
					sql.Append("  AND CARMNGNORF = @FINDCARMNGNO ");
					sql.Append("  AND CARMNGCODERF = @FINDCARMNGCODE ");// ADD 2010/05/25 by jiangk for add Primary Key CarMngCode

					//パラメータを設定する
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);
					findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(item.LogicalDeleteCode);
					findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);
					findParaCarMngNo.Value = SqlDataMediator.SqlSetInt32(item.CarMngNo);
					findParaCarMngCode.Value = SqlDataMediator.SqlSetString(item.CarMngCode); // ADD 2010/05/25 by jiangk for add Primary Key CarMngCode

					command.CommandText = sql.ToString();

					//読み込む
					myReader = command.ExecuteReader();
					//読み込めた場合
					if (myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != item.UpdateDateTime)
						{
							//既存データで更新日時違いの場合には排他
							command.Cancel();
							if (myReader != null)
							{
								if (!myReader.IsClosed) myReader.Close();
								myReader.Dispose();
							}
							continue;
						}
					}

					# region [UPDATE文]
					string sqlText = string.Empty;
					sqlText += "UPDATE CARMANAGEMENTRF" + Environment.NewLine;
					sqlText += "SET" + Environment.NewLine;
					sqlText += " UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
					sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
					sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
					sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
					sqlText += " ,INSPECTMATURITYDATERF = @UPDINSPECTMATURITYDATE" + Environment.NewLine;
					sqlText += " ,LTIMECIMATDATERF = @UPDLTIMECIMATDATE" + Environment.NewLine;
					sqlText += "WHERE" + Environment.NewLine;
					sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
					sqlText += "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
					sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
					sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
					sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD 2010/05/25 by jiangk for adding Primary Key CarMngCode
					command.CommandText = sqlText;
					# endregion

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)item;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd, obj);

					if (myReader != null)
					{
						if (!myReader.IsClosed) myReader.Close();
						myReader.Dispose();
					}

					if (cnt == 0)
					{
						#region Parameterオブジェクトの作成(更新用)
						//Prameterオブジェクトの作成
						//Parameterオブジェクトの作成(更新用)
						paraUpdateDateTime = command.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
						paraUpdEmployeeCode = command.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
						paraUpdAssemblyId1 = command.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
						paraUpdAssemblyId2 = command.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
						paraInspectMaturityDate = command.Parameters.Add("@UPDINSPECTMATURITYDATE", SqlDbType.Int);
						paraLTimeCiMatDate = command.Parameters.Add("@UPDLTIMECIMATDATE", SqlDbType.Int);
						#endregion

						cnt++;
					}

					#region Parameterオブジェクトへ値設定(更新用)
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(item.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(item.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId2);

					//車検満期日の算出
					//車検満期日
					DateTime InspectMaturityDate = item.InspectMaturityDate;
					//車検期間
					int CarInspectYear = item.CarInspectYear;
					DateTime newInspectMaturityDate = InspectMaturityDate.AddYears(CarInspectYear);

					paraInspectMaturityDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newInspectMaturityDate.ToString("yyyyMMdd")));
					paraLTimeCiMatDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(InspectMaturityDate.ToString("yyyyMMdd")));
					#endregion

					command.ExecuteNonQuery();

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					updNum++;
				}
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "InspectDateUpdDB.UpdateCarManagement");
			}
			finally
			{
				if (myReader != null)
					if (!myReader.IsClosed) myReader.Close();
			}

			return status;
		}
		#endregion
	}
}
