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
using Broadleaf.Xml.Serialization;
using System.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 備考ガイドDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 備考ガイドの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.10.13</br>
	/// <br></br>
    /// <br>Update Note: 2007.05.29 iwa コンストラクタ部不正デバック削除</br>
	/// <br>Update Note: 2008.09.17 men VSS536 品管対応</br>
	/// </remarks>
	[Serializable]
	public class NoteGuidBdDB : RemoteDB , INoteGuidBdDB
	{
		/// <summary>
		/// 備考ガイドDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		public NoteGuidBdDB() :
			base("SFTOK09406D", "Broadleaf.Application.Remoting.ParamData.NoteGuidBdWork", "NOTEGUIDBDRF")
		{
			//Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));//2007.05.29 iwa del
			//Debug.WriteLine(this.ToString() + " Constructer");//2007.05.29 iwa del
		}

		#region 備考ガイドヘッダーメソッド
		/// <summary>
		/// 備考ガイドヘッダーLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchCntHeader(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntHeaderProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// 備考ガイドヘッダーLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:NoteGuidBdWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchCntHeaderProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
														  
			NoteGuidHdWork noteguidhdWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);

				//データリード
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchCntHeaderProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// 備考ガイドヘッダーLISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイドヘッダーLISTを全て戻します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchHeader(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchHeaderProc(out retobj,paraobj,readMode,logicalMode);
		}

        /// <summary>
        /// 備考ガイドヘッダーLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 備考ガイドヘッダーLISTを全て戻します。</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.10.13</br>
        public int SearchHeader(out ArrayList retList, NoteGuidHdWork noteGuidHdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            retList = null;
            return SearchHeaderProc(out retList, noteGuidHdWork, readMode, logicalMode, ref sqlConnection);
        }
        
        /// <summary>
		/// 備考ガイドヘッダーLISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定されたマスタののガイドLISTを全て戻します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		private int SearchHeaderProc(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidHdWork noteguidhdWork = new NoteGuidHdWork();
			noteguidhdWork = null;													

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				noteguidhdWork = paraobj as NoteGuidHdWork;
																								 
				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF",sqlConnection);
					
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF",sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOTEGUIDEDIVCODERF",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

				while(myReader.Read())
				{
					NoteGuidHdWork wkNoteGuidHdWork = new NoteGuidHdWork();

					wkNoteGuidHdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkNoteGuidHdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkNoteGuidHdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkNoteGuidHdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkNoteGuidHdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkNoteGuidHdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkNoteGuidHdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkNoteGuidHdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkNoteGuidHdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					wkNoteGuidHdWork.NoteGuideDivName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDEDIVNAMERF"));

					al.Add(wkNoteGuidHdWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchHeaderProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			retobj = al;

			return status;
		}

        /// <summary>
        /// 備考ガイドヘッダーLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定されたマスタののガイドLISTを全て戻します。</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.10.13</br>
        /// </remarks>
        private int SearchHeaderProc(out ArrayList retList, NoteGuidHdWork noteGuidHdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            retList = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlCommand sqlCommand;

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOTEGUIDEDIVCODERF", sqlConnection);
                }
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteGuidHdWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    NoteGuidHdWork wkNoteGuidHdWork = new NoteGuidHdWork();

                    wkNoteGuidHdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkNoteGuidHdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkNoteGuidHdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkNoteGuidHdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkNoteGuidHdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkNoteGuidHdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkNoteGuidHdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkNoteGuidHdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkNoteGuidHdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
                    wkNoteGuidHdWork.NoteGuideDivName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTEGUIDEDIVNAMERF"));

                    al.Add(wkNoteGuidHdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "NoteGuidBdDB.SearchHeaderProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            myReader.Close();

            retList = al;

            return status;
        }
        
        /// <summary>
		/// 指定されたコードの備考ガイドヘッダーを戻します
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたコードの備考ガイドを戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int ReadHeader(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidHdWork noteguidhdWork = new NoteGuidHdWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					noteguidhdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					noteguidhdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					noteguidhdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					noteguidhdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					noteguidhdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					noteguidhdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					noteguidhdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					noteguidhdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					noteguidhdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					noteguidhdWork.NoteGuideDivName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDEDIVNAMERF"));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.ReadHeader:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(noteguidhdWork);

			return status;
		}

		/// <summary>
		/// 備考ガイドヘッダー情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイドヘッダー情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int WriteHeader(ref byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				NoteGuidHdWork noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);
	
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != noteguidhdWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (noteguidhdWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "UPDATE NOTEGUIDHDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOTEGUIDEDIVCODERF=@NOTEGUIDEDIVCODE , NOTEGUIDEDIVNAMERF=@NOTEGUIDEDIVNAME " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidhdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (noteguidhdWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
					sqlCommand.CommandText = "INSERT INTO NOTEGUIDHDRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOTEGUIDEDIVCODERF, NOTEGUIDEDIVNAMERF) " +
						"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOTEGUIDEDIVCODE, @NOTEGUIDEDIVNAME)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidhdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				myReader.Close();

				//Prameterオブジェクトの作成
				SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraNoteGuideDivCode = sqlCommand.Parameters.Add("@NOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter paraNoteGuideDivName = sqlCommand.Parameters.Add("@NOTEGUIDEDIVNAME", SqlDbType.NVarChar);

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidhdWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidhdWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(noteguidhdWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.LogicalDeleteCode);
				paraNoteGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);
				paraNoteGuideDivName.Value = SqlDataMediator.SqlSetString(noteguidhdWork.NoteGuideDivName);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(noteguidhdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.WriteHeader:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 備考ガイドヘッダー情報を論理削除します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int LogicalDeleteHeader(ref byte[] parabyte)
		{
			return LogicalDeleteHeaderProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除備考ガイドヘッダー情報を復活します
		/// </summary>
		/// <param name="parabyte">パラメーターWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除備考ガイドヘッダー情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int RevivalLogicalDeleteHeader(ref byte[] parabyte)
		{
			return LogicalDeleteHeaderProc(ref parabyte,1);
		}

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		private int LogicalDeleteHeaderProc(ref byte[] parabyte,int procMode)
		{
		//	Debug.WriteLine("LogicalDeleteNoteGuidBdU");

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				NoteGuidHdWork noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != noteguidhdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE NOTEGUIDHDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidhdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					sqlConnection.Close();
					return status;
				}
				myReader.Close();

				//論理削除モードの場合
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	noteguidhdWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						noteguidhdWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	noteguidhdWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
				}

				//Parameterオブジェクトの作成(更新用)
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定(更新用)
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidhdWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(noteguidhdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.LogicalDeleteHeaderProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報を物理削除します
		/// </summary>
		/// <param name="parabyte">備考ガイドオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int DeleteHeader(byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				NoteGuidHdWork noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != noteguidhdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					sqlConnection.Close();
					return status;
				}
				myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.DeleteHeader:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;
		}
		#endregion

		#region 備考ガイドボディメソッド
		/// <summary>
		/// 備考ガイドボディLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:NoteGuidBdWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイドボディLISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchCntBody(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntBodyProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// 備考ガイドボディLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:NoteGuidBdWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchCntBodyProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
														  
			NoteGuidBdWork noteguidbdWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);

				//データリード
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchCntBodyProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			
			sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// 備考ガイドボディLISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchBody(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			retobj = null;
			return SearchBodyProc(out retobj, paraobj ,readMode,logicalMode);
		}

		/// <summary>
		/// 備考ガイドボディLISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTを全て戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchBodyProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidBdWork noteguidbdWork = new NoteGuidBdWork();
			noteguidbdWork = null;

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				noteguidbdWork = paraobj as NoteGuidBdWork;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				
				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);
																																											   
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				while(myReader.Read())
				{
					NoteGuidBdWork wkNoteGuidBdWork = new NoteGuidBdWork();

					wkNoteGuidBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkNoteGuidBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkNoteGuidBdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkNoteGuidBdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkNoteGuidBdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkNoteGuidBdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkNoteGuidBdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkNoteGuidBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkNoteGuidBdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					wkNoteGuidBdWork.NoteGuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDECODERF"));
					wkNoteGuidBdWork.NoteGuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDENAMERF"));
					
					al.Add(wkNoteGuidBdWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchBodyProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			retobj = al;

			return status;

		}
		
		/// <summary>
		/// 備考ガイドボディLISTを指定区分コード分戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchGuideDivCode(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			return SearchGuideDivCodeProc(out retobj, paraobj ,readMode,logicalMode);
		}

		/// <summary>
		/// 備考ガイドボディLISTを指定区分コード分戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドLISTを全て戻します</br>
		/// <br>Programmer : 21052 山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchGuideDivCodeProc(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidBdWork noteguidbdWork = new NoteGuidBdWork();
			noteguidbdWork = null;

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				ArrayList noteGuidBdWorkList = paraobj as ArrayList;
				if((noteGuidBdWorkList != null)&&(noteGuidBdWorkList.Count > 0))
				{
					string strsql = "";
					for(int iCnt=0; iCnt < noteGuidBdWorkList.Count; iCnt++)
					{
						if(iCnt == 0)																						
						{
							strsql = "SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE" + iCnt.ToString();
						}
						else
						{
							strsql = strsql + " UNION SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE" + iCnt.ToString();
						}

						//データ読込
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						}
					}

					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					//SQL文生成
					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();				

					SqlCommand sqlCommand;
					noteguidbdWork = noteGuidBdWorkList[0] as NoteGuidBdWork;

					//データ読込
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||	  
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS NOTEGUIDBD ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS NOTEGUIDBD ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
						sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS NOTEGUIDBD ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);
					}

					SqlParameter[] paraGuideDivCode = new SqlParameter[noteGuidBdWorkList.Count];
					for(int iCnt=0; iCnt < noteGuidBdWorkList.Count; iCnt++)
					{
						paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE" + iCnt.ToString(), SqlDbType.Int);
						paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((NoteGuidBdWork)noteGuidBdWorkList[iCnt]).NoteGuideDivCode);
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					while(myReader.Read())
					{
						NoteGuidBdWork wkNoteGuidBdWork = new NoteGuidBdWork();

						wkNoteGuidBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkNoteGuidBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkNoteGuidBdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkNoteGuidBdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkNoteGuidBdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkNoteGuidBdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkNoteGuidBdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkNoteGuidBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkNoteGuidBdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
						wkNoteGuidBdWork.NoteGuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDECODERF"));
						wkNoteGuidBdWork.NoteGuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDENAMERF"));

						al.Add(wkNoteGuidBdWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchGuideDivCodeProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if (myReader != null)		// 2008.09.17 men add
			{							// 2008.09.17 men add
				myReader.Close();
			}							// 2008.09.17 men add

			if (sqlConnection != null)	// 2008.09.17 men add
			{							// 2008.09.17 men add
				sqlConnection.Close();
			}							// 2008.09.17 men add

			retobj = al;

			return status;

		}

		/// <summary>
		/// 指定されたキーの備考ガイドボディを戻します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの備考ガイドを戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int ReadBody(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidBdWork noteguidbdWork = new NoteGuidBdWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					noteguidbdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					noteguidbdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					noteguidbdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					noteguidbdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					noteguidbdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					noteguidbdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					noteguidbdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					noteguidbdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					noteguidbdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					noteguidbdWork.NoteGuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDECODERF"));
					noteguidbdWork.NoteGuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDENAMERF"));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.ReadBody:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(noteguidbdWork);

			return status;
		}		

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int WriteBody(ref byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				NoteGuidBdWork noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF, NOTEGUIDECODERF FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);
	
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != noteguidbdWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (noteguidbdWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "UPDATE NOTEGUIDBDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOTEGUIDEDIVCODERF=@NOTEGUIDEDIVCODE , NOTEGUIDECODERF=@NOTEGUIDECODE , NOTEGUIDENAMERF=@NOTEGUIDENAME " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
					findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidbdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (noteguidbdWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
					sqlCommand.CommandText = "INSERT INTO NOTEGUIDBDRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOTEGUIDEDIVCODERF, NOTEGUIDECODERF, NOTEGUIDENAMERF) " +
						"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOTEGUIDEDIVCODE, @NOTEGUIDECODE, @NOTEGUIDENAME)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidbdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				myReader.Close();

				//Prameterオブジェクトの作成
				SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraNoteGuideDivCode = sqlCommand.Parameters.Add("@NOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter paraNoteGuideCode = sqlCommand.Parameters.Add("@NOTEGUIDECODE", SqlDbType.Int);
				SqlParameter paraNoteGuideName = sqlCommand.Parameters.Add("@NOTEGUIDENAME", SqlDbType.NVarChar);

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidbdWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidbdWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(noteguidbdWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.LogicalDeleteCode);
				paraNoteGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				paraNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);
				paraNoteGuideName.Value = SqlDataMediator.SqlSetString(noteguidbdWork.NoteGuideName);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(noteguidbdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.WriteBody:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報を論理削除します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int LogicalDeleteBody(ref byte[] parabyte)
		{
			return LogicalDeleteBodyProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除備考ガイドボディ(ユーザー変更分)情報を復活します
		/// </summary>
		/// <param name="parabyte">パラメーターWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除備考ガイド情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int RevivalLogicalDeleteBody(ref byte[] parabyte)
		{
			return LogicalDeleteBodyProc(ref parabyte,1);
		}

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		private int LogicalDeleteBodyProc(ref byte[] parabyte,int procMode)
		{
		//	Debug.WriteLine("LogicalDeleteNoteGuidBdU");

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				NoteGuidBdWork noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != noteguidbdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE NOTEGUIDBDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
					findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidbdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					sqlConnection.Close();
					return status;
				}
				myReader.Close();

				//論理削除モードの場合
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	noteguidbdWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						noteguidbdWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	noteguidbdWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
				}

				//Parameterオブジェクトの作成(更新用)
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定(更新用)
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidbdWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(noteguidbdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.LogicalDeleteBodyProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 備考ガイドボディ(ユーザー変更分)情報を物理削除します
		/// </summary>
		/// <param name="parabyte">備考ガイドオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 備考ガイド情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public int DeleteBody(byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				NoteGuidBdWork noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != noteguidbdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
					findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					sqlConnection.Close();
					return status;
				}
				myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.DeleteBody:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;
		}
		#endregion

	}
}
