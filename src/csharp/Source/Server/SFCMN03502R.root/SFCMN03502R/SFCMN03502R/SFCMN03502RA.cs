using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// フェリカ管理DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : フェリカ管理の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 22011　柏原頼人</br>
	/// <br>Date       : 2008.10.30</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.18  22018 鈴木 正臣</br>
    /// <br>           : PM.NS対応</br>
    /// <br>           : 　・NSServiceJobAccessを使用しないように変更。(SFCMN00060C.dllの参照も削除)</br>
    /// </remarks>
	[Serializable]
	public class FeliCaMngDB : RemoteDB , IFeliCaMngDB
	{
		/// <summary>
		/// フェリカ管理DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 22011　柏原頼人</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public FeliCaMngDB() : base("SFCMN03504D","Broadleaf.Application.Remoting.ParamData.FeliCaMngWork", "FELICAMNGRF")
		{
			//コネクション文字列取得対応↓↓↓↓↓
			//※注意：コンストラクタでコネクション文字列を取得しない
        }

        /// <summary>
        /// 指定された企業コードのフェリカ管理LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="felicaMngWork">検索結果</param>
        /// <param name="parafelicaMngWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(out object felicaMngWork, object parafelicaMngWork, ConstantManagement.LogicalMode logicalMode)
        {
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Search");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            felicaMngWork = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                FeliCaMngWork paraFelicaMngWk = parafelicaMngWork as FeliCaMngWork;
                //SQLコネクションオブジェクト作成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Search Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", paraFelicaMngWk.EnterpriseCode, paraFelicaMngWk.FeliCaIDm, paraFelicaMngWk.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
                
                status = Search(out felicaMngWork, paraFelicaMngWk, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FeliCaMngDB.Search Exception = " + ex.Message);
                felicaMngWork = new ArrayList();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                // ●コネクション破棄
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードのフェリカ管理LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="felicaMngWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        public int Search(out object retList, FeliCaMngWork felicaMngWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Search2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            ArrayList felicaMngLs = new ArrayList();
            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Search Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                }

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);

                //FeliCa管理種別が共通でなければ
                if (felicaMngWork.FeliCaMngKind != 0)
                {
                    sqlCommand.CommandText += " AND FELICAMNGKINDRF = @FELICAMNGKIND";
                    SqlParameter findParaFelicaMngKind = sqlCommand.Parameters.Add("@FELICAMNGKIND", SqlDbType.Int);
                    findParaFelicaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                }

                // タイムアウト時間を設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FeliCaMngWork wkFeliCaMngWork = new FeliCaMngWork();

                    wkFeliCaMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFeliCaMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFeliCaMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFeliCaMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFeliCaMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFeliCaMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFeliCaMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFeliCaMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFeliCaMngWork.FeliCaIDm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FELICAIDMRF"));
                    wkFeliCaMngWork.FeliCaMngKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FELICAMNGKINDRF"));
                    wkFeliCaMngWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));

                    felicaMngLs.Add(wkFeliCaMngWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            retList = felicaMngLs;

            return status;
        }

		/// <summary>
		/// 指定されたフェリカ管理Guidのフェリカ管理を戻します
		/// </summary>
		/// <param name="paraObj">FeliCaMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int Read(ref object paraObj )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Read");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try
			{
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				
                //SQLコネクションオブジェクト作成
				sqlConnection = new SqlConnection( connectionText );
				sqlConnection.Open();
				FeliCaMngWork felicaMngWork = paraObj as FeliCaMngWork;

                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Read Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				return Read(ref felicaMngWork, ref sqlConnection);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"FeliCaMngDB.Read Exception = "+ex.Message);
                errMsg = "FeliCaMngDB.Read Exception = " + ex.Message;
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, string.Empty, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                // ●コネクション破棄
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
		}

		/// <summary>
		/// 指定されたフェリカ管理Guidのフェリカ管理を戻します
		/// </summary>
		/// <param name="felicaMngWork">FeliCaMngWorkオブジェクト</param>
		/// <param name="sqlConnection">コネクション情報</param>
		/// <returns>STATUS</returns>
		public int Read(ref FeliCaMngWork felicaMngWork , ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Read2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Read Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // タイムアウト時間を設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    felicaMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    felicaMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    felicaMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    felicaMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    felicaMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    felicaMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    felicaMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    felicaMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    felicaMngWork.FeliCaIDm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FELICAIDMRF"));
                    felicaMngWork.FeliCaMngKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FELICAMNGKINDRF"));
                    felicaMngWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FeliCaMngDB.Read Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            }
            myReader.Close();
			return status;
		}

		/// <summary>
		/// フェリカ管理情報を登録、更新します
		/// </summary>
		/// <param name="paraobj">FeliCaMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : フェリカ管理情報を登録、更新します</br>
		/// <br>Programmer : 22011 柏原頼人</br>
		/// <br>Date       : 2008.10.30</br>
		public int Write(ref object paraobj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Write");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
				if ( connectionText == null || connectionText == "" ) return status;

				//SQLコネクションオブジェクト作成
				sqlConnection = new SqlConnection( connectionText );
				sqlConnection.Open();
				//トランザクション開始
				sqlTransaction = sqlConnection.BeginTransaction( ( IsolationLevel )ConstantManagement.DB_IsolationLevel.ctDB_Default );

				foreach( FeliCaMngWork felicaMngWork in (List<FeliCaMngWork>)paraobj )
				{
                    // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                    //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                    //jobAcs.StartWriteServiceJob(string.Format("Write Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
					// --- DEL m.suzuki 2009/00/00 ----------<<<<<
                    status = Write(felicaMngWork, ref sqlConnection, ref sqlTransaction);
					if( status != 0 ) break;
				}
			}
			catch( SqlException ex)
			{
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
				status = base.WriteSQLErrorLog( ex );
			}
			catch( Exception ex )
			{
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
				base.WriteErrorLog( ex, "FeliCaMngDB.Write:"+ex.Message );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				// ●コネクション破棄
				if ( sqlConnection.State == ConnectionState.Open ) 
				{
					if( sqlTransaction.Connection != null )
					{
						// ●コミットorロールバック
						if ( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL)
							sqlTransaction.Commit();
						else
							sqlTransaction.Rollback();
					}
					sqlTransaction.Dispose();
					sqlConnection.Close();
                    sqlConnection.Dispose();
				}
			}

			return status;
		}

        /// <summary>
        /// フェリカ管理情報を登録、更新します
        /// </summary>
        /// <param name="felicaMngWork">felicaMngWork</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : フェリカ管理情報を登録、更新します</br>
        /// <br>Programmer : 22011　柏原頼人</br>
        /// <br>Date       : 2008.10.30</br>
        public int Write(FeliCaMngWork felicaMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Write2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Wite Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FELICAIDMRF, FELICAMNGKINDRF FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);
      
                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // タイムアウト時間を設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != felicaMngWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (felicaMngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //既存データで更新日時違いの場合には排他
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }

                    sqlCommand.CommandText = "UPDATE FELICAMNGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FELICAIDMRF=@FELICAIDM , FELICAMNGKINDRF=@FELICAMNGKIND , EMPLOYEECODERF=@EMPLOYEECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND";
                    //KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                    findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                    findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)felicaMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (felicaMngWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        myReader.Close();
                        return status;
                    }

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO FELICAMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FELICAIDMRF, FELICAMNGKINDRF, EMPLOYEECODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FELICAIDM, @FELICAMNGKIND, @EMPLOYEECODE)";

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)felicaMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFeliCaIDm = sqlCommand.Parameters.Add("@FELICAIDM", SqlDbType.NChar);
                SqlParameter paraFeliCaMngKind = sqlCommand.Parameters.Add("@FELICAMNGKIND", SqlDbType.Int);
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(felicaMngWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(felicaMngWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(felicaMngWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.LogicalDeleteCode);
                paraFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                paraFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EmployeeCode);


                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FeliCaMngDB.Write Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

		/// <summary>
		/// フェリカ管理情報を論理削除します
		/// </summary>
		/// <param name="paraObj">FeliCaMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref object paraObj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			FeliCaMngWork felicaMngWork = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.LogicalDelete");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try 
			{
				felicaMngWork = paraObj as FeliCaMngWork;
				
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("LogicalDelete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                status = LogicalDelete(ref felicaMngWork, 0, ref sqlConnection, ref sqlTransaction);
			}
			catch(SqlException ex)
			{
                errMsg = "FeliCaMngDB.LogicalDelete Exception = " + ex.Message;
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                errMsg = "FeliCaMngDB.LogicalDelete Exception = " + ex.Message;
				base.WriteErrorLog(ex,"FeliCaMngDB.LogicalDelete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				// ●コネクション破棄
				if (sqlConnection != null) 
				{
					// ●コミットorロールバック
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						sqlTransaction.Commit();
					else
						sqlTransaction.Rollback();
					sqlTransaction.Dispose();
					sqlConnection.Close();
                    sqlConnection.Dispose();
				}
			}

			paraObj = (object)felicaMngWork;
			return status;
		}

        /// <summary>
        /// 論理削除フェリカ管理情報を復活します
        /// </summary>
        /// <param name="paraObj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            FeliCaMngWork felicaMngWork = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Revival");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                felicaMngWork = paraObj as FeliCaMngWork;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Revival Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
                status = LogicalDelete(ref felicaMngWork, 1, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Revival Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Revival Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FeliCaMngDB.RevivalLogicalDelete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                // ●コネクション破棄
                if (sqlConnection != null)
                {
                    // ●コミットorロールバック
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            paraObj = (object)felicaMngWork;
            return status;
        }

        /// <summary>
        /// フェリカ管理情報の論理削除を操作します
        /// </summary>
        /// <param name="felicaMngWork">FeliCaMngWork</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : フェリカ管理情報の論理削除を操作します</br>
        /// <br>Programmer : 22011　柏原頼人</br>
        /// <br>Date       : 2008.10.30</br>
        public int LogicalDelete(ref FeliCaMngWork felicaMngWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.LogicalDelete2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("LogicalDelete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}, procMode{3}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind, procMode), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF , FELICAIDMRF, FELICAMNGKINDRF FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // タイムアウト時間を設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != felicaMngWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }
                    //現在の論理削除区分を取得
                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    sqlCommand.CommandText = "UPDATE FELICAMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND";
					
                    //KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                    findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                    findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)felicaMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                    return status;
                }

                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();

                //論理削除モードの場合
                if (procMode == 0)
                {
                    if (logicalDelCd == 3)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                        myReader.Close();
                        if (sqlCommand != null) sqlCommand.Dispose();
                        return status;
                    }
                    else if (logicalDelCd == 0) felicaMngWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                    else felicaMngWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                }
                else
                {
                    if (logicalDelCd == 1) felicaMngWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                    else
                    {
                        if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                        else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                        myReader.Close();
                        if (sqlCommand != null) sqlCommand.Dispose();
                        return status;
                    }
                }

                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定(更新用)
                paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(felicaMngWork.UpdateDateTime);
                paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdEmployeeCode);
                paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId1);
                paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId2);
                paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.LogicalDeleteCode);
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.LogicalDelete Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;

        }

        /// <summary>
        /// フェリカ管理設定情報を物理削除します
        /// </summary>
        /// <param name="paraObj">フェリカ管理オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : フェリカ管理設定情報を物理削除します</br>
        /// <br>Programmer : 22011　柏原頼人</br>
        /// <br>Date       : 2008.10.30</br>
        public int Delete(object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Delete");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // パラメータを復元
                FeliCaMngWork felicaMngWork = paraObj as FeliCaMngWork ;
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Delete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                status = Delete(felicaMngWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FelicaMngDB.Delete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
                // ●コネクション破棄
                if (sqlConnection != null)
                {
                    // ●コミットorロールバック
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

		/// <summary>
		/// フェリカ管理情報を物理削除します
		/// </summary>
		/// <param name="felicaMngWork">FeliCaMngWork</param>
		/// <param name="sqlConnection">Sql接続情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns></returns>
		/// <br>Note       : フェリカ管理情報を物理削除します</br>
		/// <br>Programmer : 22011　柏原頼人</br>
		/// <br>Date       : 2008.10.30</br>
		public int Delete(FeliCaMngWork felicaMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Delete2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try 
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("Delete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FELICAIDMRF, FELICAMNGKINDRF FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // タイムアウト時間を設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != felicaMngWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}

                    sqlCommand.CommandText = "DELETE FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND";
					//KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                    findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                    findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                }
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					return status;
				}

                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
				
                sqlCommand.ExecuteNonQuery();
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
				base.WriteErrorLog(ex,"FeliCaMngDB.Delete Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;
		}	
	}
}