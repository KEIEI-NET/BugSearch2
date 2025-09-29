using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票グループDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票グループの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 22011　柏原　頼人</br>
	/// <br>Date       : 2007.05.22</br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class FreePprGrpDB : RemoteDB, IRemoteDB, IFreePprGrpDB
	{
		#region Constructor
		/// <summary>
		/// 自由帳票グループDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 22011　柏原　頼人</br>
		/// <br>Date       : 2007.05.22</br>
		/// </remarks>
		public FreePprGrpDB() :
		base("SFANL08224D", "Broadleaf.Application.Remoting.ParamData.FreePprGrpWork", "FREEPPRGRPRF")
		{
		}
		#endregion

        #region 自由帳票グループLIST取得 Search
        /// <summary>
		/// 指定された企業コードの自由帳票グループLISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retObj">検索結果</param>
		/// <param name="paraObj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int SearchFreePprGrp( out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchFreePprGrpProc( out retObj, paraObj, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 指定された企業コードの自由帳票グループLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int SearchFreePprGrpProc( out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
		{
            msgDiv = false;
            errMsg = "";
            retObj = new ArrayList();
            SqlConnection sqlConnection = null;
            FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
            int status = 0;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            // XMLの読み込み
            freePprGrpWork = (FreePprGrpWork)paraObj;

            try
            {
                bool nextData;
                int retTotalCnt;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;


                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("SearchFreePprGrp Para: EnterpriseCode {0}", freePprGrpWork.EnterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                status = SearchFreePprGrpProc(out retObj, out retTotalCnt, out nextData, freePprGrpWork, readMode, logicalMode, 0, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFreePprGrp SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報検索中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFreePprGrp Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }


        /// <summary>
		/// 指定された企業コードの自由帳票グループLISTを全て戻します
		/// </summary>
		/// <param name="retObj">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
        /// <param name="freePprGrpWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        private int SearchFreePprGrpProc(out object retObj, out int retTotalCnt, out bool nextData, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

            retObj = new ArrayList();

			//総件数を0で初期化
			retTotalCnt = 0;

			//件数指定リードの場合には指定件数＋１件リードする
			int _readCnt = readCnt;
			if (_readCnt > 0) _readCnt += 1;

			//次レコード無しで初期化
			nextData = false;
			ArrayList al = new ArrayList();
			try 
			{	
                sqlCommand = new SqlCommand("SELECT * FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY FREEPRTPPRGROUPCDRF", sqlConnection);

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = freePprGrpWork.EnterpriseCode;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					FreePprGrpWork wkFreePprGrpWork = new FreePprGrpWork();

                    wkFreePprGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFreePprGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFreePprGrpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFreePprGrpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFreePprGrpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFreePprGrpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFreePprGrpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFreePprGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFreePprGrpWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    wkFreePprGrpWork.FreePrtPprGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPNMRF"));

					al.Add(wkFreePprGrpWork);
				}
                if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SectionInfo.SearchFreePprGrpProc SQL Exception=" + ex.Message, status);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"SectionInfo.SearchFreePprGrpProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }
            retObj = (object)al;
			return status;
        }

        /// <summary>
		/// 指定された企業コードの自由帳票グループLISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="freePprGrpWork">検索条件</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="sqlConnection">コネクション情報</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int SearchFreePprGrp( out ArrayList retList, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg )
        {
            return SearchFreePprGrpProc( out retList, freePprGrpWork, readMode, logicalMode, ref sqlConnection, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 指定された企業コードの自由帳票グループLISTを全て戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="freePprGrpWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int SearchFreePprGrpProc( out ArrayList retList, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";
			retList = new ArrayList();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try 
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("SearchFreePprGrp Para: EnterpriseCode {0}", freePprGrpWork.EnterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				//データ読込
                sqlCommand = new SqlCommand("SELECT * FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY FREEPRTPPRGROUPCDRF", sqlConnection);
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = freePprGrpWork.EnterpriseCode;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);
                myReader = sqlCommand.ExecuteReader();

				while(myReader.Read())
				{
					FreePprGrpWork wkFreePprGrpWork = new FreePprGrpWork();
                    wkFreePprGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFreePprGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFreePprGrpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFreePprGrpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFreePprGrpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFreePprGrpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFreePprGrpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFreePprGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFreePprGrpWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    wkFreePprGrpWork.FreePrtPprGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPNMRF"));
					retList.Add(wkFreePprGrpWork);
				}
				if(retList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpProc SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報検索中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			return status;
		}
		#endregion

		#region 自由帳票グループ情報取得 ReadFreePprGrp
		/// <summary>
		/// 指定された企業コードの自由帳票グループを戻します
		/// </summary>
		/// <param name="parabyte">FreePprGrpWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int ReadFreePprGrp( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
        {
            return ReadFreePprGrpProc( ref parabyte, readMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 指定された企業コードの自由帳票グループを戻します
        /// </summary>
        /// <param name="parabyte">FreePprGrpWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int ReadFreePprGrpProc( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
			SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.ReadFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
			
            try 
			{
				// XMLの読み込み
				freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte,typeof(FreePprGrpWork));

                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("ReadFreePprGrp Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", freePprGrpWork.EnterpriseCode, freePprGrpWork.FreePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				//Selectコマンドの生成	
                sqlCommand = new SqlCommand("SELECT * FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

				//Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
                    freePprGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    freePprGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    freePprGrpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    freePprGrpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    freePprGrpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    freePprGrpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    freePprGrpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    freePprGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    freePprGrpWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    freePprGrpWork.FreePrtPprGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPNMRF"));
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.ReadFreePprGrp SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報読込中にサーバーでタイムアウトが発生しました。";
                }
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.ReadFreePprGrp Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(freePprGrpWork);
			return status;
		}

		#endregion

		#region 自由帳票グループ情報登録＆更新 WriteFreePprGrp
		/// <summary>
		/// 自由帳票グループ情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">FreePprGrpWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int WriteFreePprGrp( ref byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            return WriteFreePprGrpProc( ref parabyte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票グループ情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">FreePprGrpWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int WriteFreePprGrpProc( ref byte[] parabyte, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.WriteFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try 
			{
				// XMLの読み込み
				FreePprGrpWork freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte,typeof(FreePprGrpWork));

                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

				//Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("WriteFreePprGrp Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", freePprGrpWork.EnterpriseCode, freePprGrpWork.FreePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				myReader = sqlCommand.ExecuteReader();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != freePprGrpWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (freePprGrpWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE FREEPPRGRPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FREEPRTPPRGROUPCDRF=@FREEPRTPPRGROUPCD , FREEPRTPPRGROUPNMRF=@FREEPRTPPRGROUPNM WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD";

					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)freePprGrpWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (freePprGrpWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO FREEPPRGRPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FREEPRTPPRGROUPCDRF, FREEPRTPPRGROUPNMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FREEPRTPPRGROUPCD, @FREEPRTPPRGROUPNM)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)freePprGrpWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(!myReader.IsClosed)myReader.Close();

				//Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupNm = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPNM", SqlDbType.NVarChar);

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freePprGrpWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freePprGrpWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(freePprGrpWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(freePprGrpWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(freePprGrpWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(freePprGrpWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(freePprGrpWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(freePprGrpWork.LogicalDeleteCode);
                paraFreePrtPprGroupCd.Value = SqlDataMediator.SqlSetInt32(freePprGrpWork.FreePrtPprGroupCd);
                paraFreePrtPprGroupNm.Value = SqlDataMediator.SqlSetString(freePprGrpWork.FreePrtPprGroupNm);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(freePprGrpWork);
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.WriteFreePprGrp SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報書き込み中にサーバーでタイムアウトが発生しました。";
                }
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.WriteFreePprGrp Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			return status;
		}

		#endregion

        #region 自由帳票グループ情報＆自由帳票グループ振替情報物理削除 DeleteFreePprGrpAll
        /// <summary>
		/// 自由帳票グループ情報を物理削除します
		/// </summary>
		/// <param name="parabyte1">自由帳票グループオブジェクト</param>
		/// <param name="parabyte2">自由帳票グループ振替オブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns></returns>
        public int DeleteFreePprGrpAll( ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg )
        {
            return DeleteFreePprGrpAllProc( ref parabyte1, ref parabyte2, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票グループ情報を物理削除します
        /// </summary>
        /// <param name="parabyte1">自由帳票グループオブジェクト</param>
        /// <param name="parabyte2">自由帳票グループ振替オブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns></returns>
        private int DeleteFreePprGrpAllProc( ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTrans = null;
            msgDiv = false;
            errMsg = "";
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            
            // XMLの読み込み
            FreePprGrpWork freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte1, typeof(FreePprGrpWork));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DeleteFreePprGrpAll");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

			sqlConnection = new SqlConnection(connectionText);
			sqlConnection.Open();

            try
            {
                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("DeleteFreePprGrpAll Para: EnterpriseCode {0}", freePprGrpWork.EnterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                status = DeleteFreePprGrp(ref freePprGrpWork, sqlConnection, sqlTrans);
            
                if (status == 0)
                {
                    if (parabyte2 != null)
                    {
                        status = DeleteFrePprGrTr(ref parabyte2, sqlConnection, sqlTrans);

                        if (status == 0)
                            sqlTrans.Commit();
                        else
                            sqlTrans.Rollback();
                    }
                    else
                    {
                        sqlTrans.Commit();
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                }


            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex,"FreePprGrpDB.DeleteFreePprGrpAll SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報削除中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFreePprGrpAll Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlTrans.Dispose();
            }
			return status;
		}

		/// <summary>
		/// 自由帳票グループ情報を物理削除します
		/// </summary>
        /// <param name="freePprGrpWork">自由帳票グループワーク</param>
		/// <param name="sqlConnection"></param>
		/// <param name="sqlTrans"></param>
        /// <returns></returns>
        private int DeleteFreePprGrp(ref FreePprGrpWork freePprGrpWork, SqlConnection sqlConnection, SqlTransaction sqlTrans)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection, sqlTrans);

				//Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != freePprGrpWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						return status;
					}

                    sqlCommand.CommandText = "DELETE FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					if(!myReader.IsClosed)myReader.Close();
					return status;
				}
				if(!myReader.IsClosed)myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
         	}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFreePprGrp Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			return status;
		}
		#endregion

		#region 自由帳票グループ振替LIST取得 SearchFrePprGrTr
		/// <summary>
		/// 指定された企業コードの自由帳票グループLISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="retbyte">検索結果(FrePprGrTrWorkの配列)</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
		/// <returns>STATUS</returns>
        public int SearchFrePprGrTr( out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchFrePprGrTrProc( out retbyte, parabyte, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 指定された企業コードの自由帳票グループLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retbyte">検索結果(FrePprGrTrWorkの配列)</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
        /// <returns>STATUS</returns>
        private int SearchFrePprGrTrProc( out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
		{
			bool nextData;
			int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            msgDiv = false;
            SqlConnection sqlConnection = null;
            FrePprGrTrWork frePprGrTrWork = null;
            errMsg = "";

            // XMLの読み込み
            frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePprGrTrWork));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFrePprGrTr");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            try
            {
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("SearchFrePprGrTr Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                status = SearchFrePprGrTrProc(out retbyte, out retTotalCnt, out nextData, frePprGrTrWork, readMode, logicalMode, 0, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ振替情報検索中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFrePprGrTr Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コード＆自由帳票グループコードの自由帳票グループLISTを全て戻します
		/// </summary>
        /// <param name="retbyte">検索結果(FrePprGrTrWorkの配列)</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
        /// <param name="frePprGrTrWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        private int SearchFrePprGrTrProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, FrePprGrTrWork frePprGrTrWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			retbyte = null;

			//総件数を0で初期化
			retTotalCnt = 0;

			//件数指定リードの場合には指定件数＋１件リードする
			int _readCnt = readCnt;
			if (_readCnt > 0) _readCnt += 1;
			//次レコード無しで初期化
			nextData = false;

			ArrayList al = new ArrayList();
			try
			{				
				//データ読込
                sqlCommand = new SqlCommand("SELECT * FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

                //パラメータ設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				//int retCnt = 0;
				while(myReader.Read())
				{
					FrePprGrTrWork wkFrePprGrTrWork = new FrePprGrTrWork();

                    frePprGrTrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    frePprGrTrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    frePprGrTrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    frePprGrTrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    frePprGrTrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    frePprGrTrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    frePprGrTrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    frePprGrTrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    frePprGrTrWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    frePprGrTrWork.TransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODERF"));
                    frePprGrTrWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    frePprGrTrWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    frePprGrTrWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    frePprGrTrWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));

                    al.Add(frePprGrTrWork);
				}
                if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.SearchFreePprGrpProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			// XMLへ変換し、文字列のバイナリ化
			FrePprGrTrWork[] FrePprGrTrWorks = (FrePprGrTrWork[])al.ToArray(typeof(FrePprGrTrWork));
			retbyte = XmlByteSerializer.Serialize(FrePprGrTrWorks);

			return status;
        }

        /// <summary>
        /// 指定された企業コード＆自由帳票グループコードの自由帳票グループ名称LISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="enterpriseCode">検索用企業コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int SearchFrePprGrTrAll( out object retObj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchFrePprGrTrAllProc( out retObj, enterpriseCode, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 指定された企業コード＆自由帳票グループコードの自由帳票グループ名称LISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="enterpriseCode">検索用企業コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int SearchFrePprGrTrAllProc( out object retObj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";
            retObj = new ArrayList();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFrePprGrTrAll");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //データ読込
                sqlCommand = new SqlCommand("SELECT * FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);


                //パラメータ設定
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = enterpriseCode;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("SearchFrePprGrTrAll Para: EnterpriseCode {0}", enterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePprGrTrWork wkFrePprGrTrWork = new FrePprGrTrWork();

                    wkFrePprGrTrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFrePprGrTrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFrePprGrTrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFrePprGrTrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFrePprGrTrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFrePprGrTrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFrePprGrTrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFrePprGrTrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFrePprGrTrWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    wkFrePprGrTrWork.TransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODERF"));
                    wkFrePprGrTrWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    wkFrePprGrTrWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    wkFrePprGrTrWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    wkFrePprGrTrWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));

                    al.Add(wkFrePprGrTrWork);
                }
                if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpAll SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpAll Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)al;

            return status;
        }
        #endregion

        #region 自由帳票グループ明細情報取得 ReadFreePprGrpDtl
        /// <summary>
        /// 指定された企業コード・自由帳票グループコード・自由帳票グループ振替コードの自由帳票グループ振替を戻します
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int ReadFrePprGrTr( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
        {
            return ReadFrePprGrTrProc( ref parabyte, readMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 指定された企業コード・自由帳票グループコード・自由帳票グループ振替コードの自由帳票グループ振替を戻します
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int ReadFrePprGrTrProc( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            FrePprGrTrWork frePprGrTrWork = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.Read");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            try
            {
                // XMLの読み込み
                frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePprGrTrWork));

                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("ReadFrePprGrTr Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}, TransferCode{2}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, frePprGrTrWork.TransferCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                //Selectコマンドの生成	
                sqlCommand = new SqlCommand("SELECT * FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE", sqlConnection);
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode.Value = frePprGrTrWork.TransferCode;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    frePprGrTrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    frePprGrTrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    frePprGrTrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    frePprGrTrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    frePprGrTrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    frePprGrTrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    frePprGrTrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    frePprGrTrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    frePprGrTrWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    frePprGrTrWork.TransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODERF"));
                    frePprGrTrWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    frePprGrTrWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    frePprGrTrWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    frePprGrTrWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.ReadFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ振替情報読込中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.ReadFrePprGrTr Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // XMLへ変換し、文字列のバイナリ化
            parabyte = XmlByteSerializer.Serialize(frePprGrTrWork);
            return status;
        }
        #endregion

        #region 自由帳票グループ振替情報登録＆更新 WriteFrePprGrTr
        /// <summary>
		/// 自由帳票グループ振替情報を登録、更新します
		/// </summary>
        /// <param name="paraobj">FrePprGrTrWorkList</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int WriteFrePprGrTr( ref object paraobj, out bool msgDiv, out string errMsg )
        {
            return WriteFrePprGrTrProc( ref paraobj, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票グループ振替情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">FrePprGrTrWorkList</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int WriteFrePprGrTrProc( ref object paraobj, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.WriteFrePprGrTr");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try 
			{
				// XMLの読み込み
				//FrePprGrTrWork frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));
                
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);


                foreach (FrePprGrTrWork frePprGrTrWork in (List<FrePprGrTrWork>)paraobj)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                    //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                    //jobAcs.StartWriteServiceJob(string.Format("WriteFrePprGrTr Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}, TransferCode{2}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, frePprGrTrWork.TransferCode), sqlConnection);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                    //振替コードの採番
                    if (frePprGrTrWork.TransferCode == 0)
                    {
                        frePprGrTrWork.TransferCode = (GetLastTransferCode(frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, out msgDiv, out errMsg) + 1);
                    }
                    //表示順位の採番
                    if (frePprGrTrWork.DisplayOrder == 0)
                    {
                        frePprGrTrWork.DisplayOrder = (GetLastDisplayOrder(frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, out msgDiv, out errMsg) + 1);
                        
                    }
                    //DBへ書き込み
                    status = WriteFrePprGrTr(frePprGrTrWork, ref sqlConnection, ref sqlTransaction);
                    if (status != 0) break;
                }
				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				//parabyte = XmlByteSerializer.Serialize(frePprGrTrWork);
			}
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.WriteFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ振替情報書き込み時にサーバーでタイムアウトが発生しました。";
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.WriteFrePprGrTr Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if(sqlConnection != null)
                {
                    // コミットorロールバック
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
			return status;
		}

        /// <summary>
        /// 自由帳票グループ振替情報を登録、更新します
        /// </summary>
        /// <param name="frePprGrTrWork">自由帳票グループ振替</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>ステータス</returns>
        private int WriteFrePprGrTr(FrePprGrTrWork frePprGrTrWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //同一グループ内に既に同じ印字位置情報が関連づけられているかチェック
                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF, DISPLAYORDERRF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF<>@FINDTRANSFERCODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode         = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd      = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode           = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);
                SqlParameter findParaOutPutFormFileName     = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NChar);
                SqlParameter findParaUserPrtPprIdDerivNo    = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.NChar);
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value        = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value     = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode.Value          = frePprGrTrWork.TransferCode;
                findParaOutPutFormFileName.Value    = frePprGrTrWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value   = frePprGrTrWork.UserPrtPprIdDerivNo;
                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    // グループ内に登録データが見つかった場合重複エラーとして処理
                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();


                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF, DISPLAYORDERRF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd2 = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode2 = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode2.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd2.Value = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode2.Value = frePprGrTrWork.TransferCode;

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != frePprGrTrWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (frePprGrTrWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE FREPPRGRTRRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FREEPRTPPRGROUPCDRF=@FREEPRTPPRGROUPCD , TRANSFERCODERF=@TRANSFERCODE , DISPLAYORDERRF=@DISPLAYORDER , DISPLAYNAMERF=@DISPLAYNAME , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , USERPRTPPRIDDERIVNORF=@USERPRTPPRIDDERIVNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                    findParaTransferCode.Value = frePprGrTrWork.TransferCode;
                    
					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)frePprGrTrWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (frePprGrTrWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO FREPPRGRTRRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FREEPRTPPRGROUPCDRF, TRANSFERCODERF, DISPLAYORDERRF, DISPLAYNAMERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FREEPRTPPRGROUPCD, @TRANSFERCODE, @DISPLAYORDER, @DISPLAYNAME, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)frePprGrTrWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(!myReader.IsClosed)myReader.Close();

				//Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter paraTransferCode = sqlCommand.Parameters.Add("@TRANSFERCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                SqlParameter paraDisplayName = sqlCommand.Parameters.Add("@DISPLAYNAME", SqlDbType.NVarChar);
                SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter paraUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(frePprGrTrWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(frePprGrTrWork.LogicalDeleteCode);

                paraFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                paraDisplayOrder.Value = frePprGrTrWork.DisplayOrder;
                paraDisplayName.Value = frePprGrTrWork.DisplayName;
                paraOutputFormFileName.Value = frePprGrTrWork.OutputFormFileName;
                paraUserPrtPprIdDerivNo.Value = frePprGrTrWork.UserPrtPprIdDerivNo;
                paraTransferCode.Value = frePprGrTrWork.TransferCode;

				sqlCommand.ExecuteNonQuery();
                
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch ( SqlException ex ) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch( Exception ex )
            {
                base.WriteErrorLog( ex, "FreePprGrpDB.WriteFrePprGrTrWork Exception=" + ex.Message );
                status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if( sqlCommand != null )sqlCommand.Dispose();
                if( !myReader.IsClosed )myReader.Close();
            }
			return status;
        }
		#endregion

        #region 自由帳票グループ振替情報初期登録処理
        /// <summary>
        /// 自由帳票グループ振替情報を全グループに登録します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="displayName">出力名称</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqltrance">トランザクション情報</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>ステータス</returns>
        public int EntryFrePprGrTr( string enterpriseCode, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqltrance, out bool msgDiv, out string errMsg )
        {
            return EntryFrePprGrTrProc( enterpriseCode, displayName, outputFormFileName, userPrtPprIdDerivNo, sqlConnection, sqltrance, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票グループ振替情報を全グループに登録します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="displayName">出力名称</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqltrance">トランザクション情報</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>ステータス</returns>
        private int EntryFrePprGrTrProc( string enterpriseCode, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqltrance, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.EntryFrePprGrTr");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            try
            {
                //パラメーターをワーククラスにセット
                FrePprGrTrWork frePprGrTrWork = new FrePprGrTrWork();
                frePprGrTrWork.EnterpriseCode = enterpriseCode;
                frePprGrTrWork.OutputFormFileName = outputFormFileName;
                frePprGrTrWork.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                frePprGrTrWork.DisplayName = displayName;
                frePprGrTrWork.DisplayOrder = (GetLastDisplayOrder(enterpriseCode, 0, out msgDiv, out errMsg)+1);
                frePprGrTrWork.TransferCode = (GetLastTransferCode(enterpriseCode, 0, out msgDiv, out errMsg)+1);
                frePprGrTrWork.FreePrtPprGroupCd = 0;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("EntryFrePprGrTr Para: enterpriseCode {0}, displayName{1}, outputFormFileName{2}, userPrtPprIdDerivNo{3}", enterpriseCode, displayName, outputFormFileName, userPrtPprIdDerivNo), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                //新規作成時のSQL文を生成
                sqlCommand = new SqlCommand("INSERT INTO FREPPRGRTRRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FREEPRTPPRGROUPCDRF, TRANSFERCODERF, DISPLAYORDERRF, DISPLAYNAMERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FREEPRTPPRGROUPCD, @TRANSFERCODE, @DISPLAYORDER, @DISPLAYNAME, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO)");
                // コネクション情報を設定
                sqlCommand.Connection = sqlConnection;

                //登録ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)frePprGrTrWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
            
                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                // トランザクションの設定
                if (sqltrance != null) sqlCommand.Transaction = sqltrance;// トランザクションの設定

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter paraTransferCode = sqlCommand.Parameters.Add("@TRANSFERCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                SqlParameter paraDisplayName = sqlCommand.Parameters.Add("@DISPLAYNAME", SqlDbType.NVarChar);
                SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter paraUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(frePprGrTrWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(frePprGrTrWork.LogicalDeleteCode);

                paraFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                paraDisplayOrder.Value = frePprGrTrWork.DisplayOrder;
                paraDisplayName.Value = frePprGrTrWork.DisplayName;
                paraOutputFormFileName.Value = frePprGrTrWork.OutputFormFileName;
                paraUserPrtPprIdDerivNo.Value = frePprGrTrWork.UserPrtPprIdDerivNo;
                paraTransferCode.Value = frePprGrTrWork.TransferCode;

                sqlCommand.ExecuteNonQuery();

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.EntryFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ振替(全グループ用)情報書き込み時にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.EntryFrePprGrTr Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            }

            return status;
        }
        #endregion

        #region 自由帳票グループ振替情報物理削除 DeleteFrePprGrTr
        /// <summary>
		/// 自由帳票グループ振替情報を物理削除します
		/// </summary>
		/// <param name="parabyte">自由帳票グループ振替オブジェクト</param>
		/// <param name="sqlConnection"></param>
		/// <param name="sqlTrans"></param>
        /// <returns></returns>
        private int DeleteFrePprGrTr(ref byte[] parabyte,SqlConnection sqlConnection, SqlTransaction sqlTrans)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
				// XMLの読み込み
               	FrePprGrTrWork[] ew = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork[]));
				FrePprGrTrWork frePprGrTrWork = ew[0];
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection,sqlTrans);
               
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
               
				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                
                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                myReader = sqlCommand.ExecuteReader();

                if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    sqlCommand.CommandText = "DELETE FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                }
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					if(!myReader.IsClosed)myReader.Close();
					return status;
				}
				if(!myReader.IsClosed)myReader.Close();
                
				sqlCommand.ExecuteNonQuery();
                
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.DeleteFrePprGrTr Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
			finally
			{
                if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}
			return status;
		}
		#endregion

        #region 自由帳票グループ振替情報物理削除
        /// <summary>
		/// 自由帳票グループ振替情報を物理削除します
		/// </summary>
		/// <param name="parabyte">FrePprGrTrWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int DtlDelete( byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            return DtlDeleteProc( parabyte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票グループ振替情報を物理削除します
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int DtlDeleteProc( byte[] parabyte, out bool msgDiv, out string errMsg )
		{
			int status;
			SqlConnection sqlConnection = null;
            msgDiv = false;
            errMsg = "";
            // XMLの読み込み
            FrePprGrTrWork frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePprGrTrWork));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DtlDelete");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

			sqlConnection = new SqlConnection(connectionText);
			sqlConnection.Open();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
            //jobAcs.StartWriteServiceJob(string.Format("DtlDelete Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}, TransferCode{2}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, frePprGrTrWork.TransferCode), sqlConnection);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = DtlDeleteProc(frePprGrTrWork, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DtlDelete SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報削除中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DtlDelete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            }
			sqlConnection.Close();
			return status;
		}

		/// <summary>
		/// 自由帳票グループ振替情報を物理削除します
		/// </summary>
        /// <param name="frePprGrTrWork">自由帳票グループ振替ワーク</param>
		/// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int DtlDeleteProc(FrePprGrTrWork frePprGrTrWork, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF, TRANSFERCODERF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE", sqlConnection);

				//Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode.Value = frePprGrTrWork.TransferCode;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

					if (_updateDateTime != frePprGrTrWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						return status;
					}

                    sqlCommand.CommandText = "DELETE FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                    findParaTransferCode.Value = frePprGrTrWork.TransferCode;
                }
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					return status;
				}
				if(!myReader.IsClosed)myReader.Close();

				sqlCommand.ExecuteNonQuery();
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                base.WriteErrorLog(ex, "FreePprGrpDB.DtlDeleteProc Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}
			return status;
		}
		#endregion

        #region 自由帳票グループ振替情報物理削除
        /// <summary>
        /// 自由帳票グループ振替情報を物理削除します(印字位置設定のキー指定)
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="outputFormFileName">出力ファイル名称</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTrans">トランザクション</param>
        /// <returns></returns>
        public int DeleteFrePprGrTrProc( string enterprisecode, string outputFormFileName, int userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqlTrans )
        {
            return DeleteFrePprGrTrProcProc( enterprisecode, outputFormFileName, userPrtPprIdDerivNo, sqlConnection, sqlTrans );
        }
        /// <summary>
        /// 自由帳票グループ振替情報を物理削除します(印字位置設定のキー指定)
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="outputFormFileName">出力ファイル名称</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTrans">トランザクション</param>
        /// <returns></returns>
        private int DeleteFrePprGrTrProcProc( string enterprisecode, string outputFormFileName, int userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqlTrans )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DtlDelete");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            
            try
            {
                sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO", sqlConnection, sqlTrans);
                                                                      　　　　　　　　　　　　　　
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterprisecode;
                findParaOutputFormFileName.Value = outputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = userPrtPprIdDerivNo;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("DeleteFrePprGrTrProc Para: EnterpriseCode {0}, outputFormFileName{1}, userPrtPprIdDerivNo{2}", enterprisecode, outputFormFileName, userPrtPprIdDerivNo), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sqlCommand.CommandText = "DELETE FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = enterprisecode;
                    findParaOutputFormFileName.Value = outputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = userPrtPprIdDerivNo;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DeleteFrePprGrTrProc Exception=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFrePprGrTrProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, string.Empty, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        #region 自由帳票グループマスタ削除チェック
        /// <summary>
		/// 自由帳票グループマスタ削除チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
		/// <param name="message">メッセージ</param>
		/// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int DeleteCheck( string enterpriseCode, Int32 freePrtPprGroupCd, out string message, out bool checkFlg, out bool msgDiv, out string errMsg )
        {
            return DeleteCheckProc( enterpriseCode, freePrtPprGroupCd, out message, out checkFlg, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票グループマスタ削除チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
        /// <param name="message">メッセージ</param>
        /// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int DeleteCheckProc( string enterpriseCode, Int32 freePrtPprGroupCd, out string message, out bool checkFlg, out bool msgDiv, out string errMsg )
		{
			int status = 0;
			SqlConnection sqlConnection = null;
			checkFlg = true;
			message = "";
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンスを起動
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DeleteCheck");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("DeleteCheck Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", enterpriseCode, freePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				status = ReadFreePprGrp(enterpriseCode, freePrtPprGroupCd, ref sqlConnection);



				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// OK
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					checkFlg = false;
					message = "この自由帳票グループは既に他端末にて削除されています。";
				}
				else
				{
					// エラー
				}
																															   
				if ((!checkFlg) || (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)) return status;

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
			}
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DeleteCheck SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票グループ情報削除チェック中にサーバーでタイムアウトが発生しました。";
                }
            }
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"FreePprGrpDB.DeleteCheck Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        	}
			finally
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
				if(sqlConnection != null)sqlConnection.Close();
			}
			return status;
		}

		/// <summary>
		/// 指定された自由帳票グループコードの存在チェックします
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
		/// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        private int ReadFreePprGrp(string enterpriseCode, Int32 freePrtPprGroupCd, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

            try
            {
                //Selectコマンドの生成	
                sqlCommand = new SqlCommand("SELECT FREEPRTPPRGROUPCDRF FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePrtPprGroupCd;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
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
                base.WriteErrorLog(ex, "FreePprGrpDB.ReadFreePprGrp Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}
			return status;
		}
		#endregion

        #region 最終振替コード採番処理
        /// <summary>
        /// 最終振替コード採番処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>最終振替コード</returns>
        public int GetLastTransferCode( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            return GetLastTransferCodeProc( enterpriseCode, freePrtPprGroupCd, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 最終振替コード採番処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>最終振替コード</returns>
        private int GetLastTransferCodeProc( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int lastTransferCode = 0;
            msgDiv = false;
            errMsg = string.Empty;


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンス
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.GetLastTransferCode");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            try
            {
                //SQL文生成
                sqlConnection = CreateSqlConnection();
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("GetLastTransferCode Para: enterpriseCode {0}, freePrtPprGroupCd {1}", enterpriseCode, freePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand("SELECT TRANSFERCODE=MAX(TRANSFERCODERF) FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);
                // 企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = enterpriseCode;
                // 自由帳票グループコード
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                findParaFreePrtPprGroupCd.Value = freePrtPprGroupCd;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    lastTransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODE"));
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.GetLastTransferCode SQLException = " + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "最終振替コード採番処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.GetLastTransferCode Exception = "+ ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null) sqlConnection.Close();
            }

            return lastTransferCode;
        }
        #endregion

        #region 最終振替コード採番処理
        /// <summary>
        /// 最終振替コード採番処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>最終振替コード</returns>
        public int GetLastDisplayOrder( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            return GetLastDisplayOrderProc( enterpriseCode, freePrtPprGroupCd, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 最終振替コード採番処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>最終振替コード</returns>
        private int GetLastDisplayOrderProc( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int lastDisplayOrder = 0;
            msgDiv = false;
            errMsg = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンス
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.GetLastDisplayOrder");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            try
            {
                //SQL文生成
                sqlConnection = CreateSqlConnection();
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                //jobAcs.StartWriteServiceJob(string.Format("GetLastDisplayOrder Para: enterpriseCode {0}, freePrtPprGroupCd {1}", enterpriseCode, freePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand("SELECT DISPLAYORDER=MAX(DISPLAYORDERRF) FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);
                // 企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = enterpriseCode;
                // 自由帳票グループコード
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                findParaFreePrtPprGroupCd.Value = freePrtPprGroupCd;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    lastDisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDER"));
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.GetLastDisplayOrder SQLException = " + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "最終表示順位採番処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.GetLastDisplayOrder Exception = "+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ステータス、メッセージ、メソッド固有情報、コネクションを渡してサービスジョブテーブルへ書き込み
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null) sqlConnection.Close();
            }

            return lastDisplayOrder;
        }
        #endregion

        #region コネクション情報生成
        /// <summary>
        /// コネクション情報生成
        /// </summary>
        /// <returns>コネクション情報</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            return new SqlConnection(connectionText);
        }
        #endregion
    }
}
