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
	/// 請求印刷設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求印刷設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.07.20</br>
	/// <br></br>
	/// <br>Update Note: ファイルレイアウト変更</br>
    /// <br>Note       : 20036　斉藤　雅明</br>
    /// <br>Programmer : 2007.06.27</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 PM.NS対応</br>
    /// <br></br>
    /// </remarks>
	[Serializable]
	public class BillPrtStDB : RemoteDB, IRemoteDB, IBillPrtStDB
	{
		/// <summary>
		/// 請求印刷設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>																	 
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>												
		/// </remarks>
		public BillPrtStDB() :																	
		base("SFUKK09086D", "Broadleaf.Application.Remoting.ParamData.BillPrtStWork", "BILLPRTSTRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("BillPrtStDBコンストラクタ");
		}
																						   
		/// <summary>
		/// 指定された企業コードの請求印刷設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobject">検索結果</param>
		/// <param name="paraobject">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの請求印刷設定LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		public int Search(out object retobject,object paraobject, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			Debug.WriteLine("Search");
            return SearchProc(out retobject,paraobject ,readMode,logicalMode);

        }

		/// <summary>
		/// 指定された企業コードの請求印刷設定LISTを全て戻します
		/// </summary>
		/// <param name="retobject">検索結果</param>
		/// <param name="paraobject">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの請求印刷設定LISTを全て戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
        public int SearchProc(out object retobject, object paraobject, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retobject = null;
            try 
			{	

				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
                
                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchProc(out retobject, paraobject, readMode, logicalMode, ref sqlConnection);
            }

            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillPrtStDB.SearchProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
                /// <summary>
        /// 指定された企業コードの請求印刷設定LISTを全て戻します
        /// </summary>
        /// <param name="retobject">検索結果</param>
        /// <param name="paraobject">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求印刷設定LISTを全て戻します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.07.20</br>
        public int SearchProc(out object retobject, object paraobject, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
             return SearchProcProc(out retobject, paraobject, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された企業コードの請求印刷設定LISTを全て戻します
        /// </summary>
        /// <param name="retobject">検索結果</param>
        /// <param name="paraobject">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求印刷設定LISTを全て戻します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.07.20</br>
        private int SearchProcProc(out object retobject, object paraobject, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			BillPrtStWork billprtstWork = new BillPrtStWork();
			billprtstWork = null;

			retobject = null;

			ArrayList al = new ArrayList();
			try 
			{	   
				// XMLの読み込み
				billprtstWork = paraobject as BillPrtStWork;
			
				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " +
						"ORDER BY BILLPRTSTMNGCDRF",
						sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
						"ORDER BY BILLPRTSTMNGCDRF",
						sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
						"ORDER BY BILLPRTSTMNGCDRF",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					BillPrtStWork wkBillPrtStWork = new BillPrtStWork();

                    wkBillPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkBillPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkBillPrtStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkBillPrtStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkBillPrtStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkBillPrtStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkBillPrtStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkBillPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkBillPrtStWork.BillPrtStMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPRTSTMNGCDRF"));
                    wkBillPrtStWork.BillTableOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLTABLEOUTCDRF"));
                    wkBillPrtStWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                    wkBillPrtStWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                    wkBillPrtStWork.BillLastDayPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLLASTDAYPRTDIVRF"));
                    wkBillPrtStWork.BillCoNmPrintOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLCONMPRINTOUTCDRF"));
                    wkBillPrtStWork.BillBankNmPrintOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLBANKNMPRINTOUTRF"));
                    wkBillPrtStWork.CustTelNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTTELNOPRTDIVCDRF"));

					al.Add(wkBillPrtStWork);
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
            
            }
        
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"BillPrtStDB.SearchProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();

			// XMLへ変換し、文字列のバイナリ化
			retobject = al;

			return status;

		}
		
		/// <summary>
		/// 指定された企業コードの請求印刷設定を戻します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの請求印刷設定を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// 指定された企業コードの請求印刷設定を戻します
        /// </summary>
        /// <param name="parabyte">BillPrtStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求印刷設定を戻します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.07.20</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
			Debug.WriteLine("Read");			

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			BillPrtStWork billprtstWork = new BillPrtStWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT * FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findparaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);
				
				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
                    // del 2007.06.27 saito ※一部項目削除
                    billprtstWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    billprtstWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    billprtstWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    billprtstWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    billprtstWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    billprtstWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    billprtstWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    billprtstWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    billprtstWork.BillPrtStMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPRTSTMNGCDRF"));
                    billprtstWork.BillTableOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLTABLEOUTCDRF"));
                    billprtstWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                    billprtstWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                    billprtstWork.BillLastDayPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLLASTDAYPRTDIVRF"));
                    billprtstWork.BillCoNmPrintOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLCONMPRINTOUTCDRF"));
                    billprtstWork.BillBankNmPrintOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLBANKNMPRINTOUTRF"));
                    billprtstWork.CustTelNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTTELNOPRTDIVCDRF"));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"BillPrtStDB.Read:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(billprtstWork);

			return status;
		}

		/// <summary>
		/// 請求印刷設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 請求印刷設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        /// <summary>
        /// 請求印刷設定情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">BillPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求印刷設定情報を登録、更新します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.07.20</br>
        private int WriteProc(ref byte[] parabyte)
        {
			Debug.WriteLine("Write");
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				BillPrtStWork billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findParaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != billprtstWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (billprtstWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE BILLPRTSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , BILLPRTSTMNGCDRF=@BILLPRTSTMNGCD , BILLTABLEOUTCDRF=@BILLTABLEOUTCD , TOTALBILLOUTPUTDIVRF=@TOTALBILLOUTPUTDIV , DETAILBILLOUTPUTCODERF=@DETAILBILLOUTPUTCODE , BILLLASTDAYPRTDIVRF=@BILLLASTDAYPRTDIV , BILLCONMPRINTOUTCDRF=@BILLCONMPRINTOUTCD , BILLBANKNMPRINTOUTRF=@BILLBANKNMPRINTOUT , CUSTTELNOPRTDIVCDRF=@CUSTTELNOPRTDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD ";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
					findParaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)billprtstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (billprtstWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO BILLPRTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BILLPRTSTMNGCDRF, BILLTABLEOUTCDRF, TOTALBILLOUTPUTDIVRF, DETAILBILLOUTPUTCODERF, BILLLASTDAYPRTDIVRF, BILLCONMPRINTOUTCDRF, BILLBANKNMPRINTOUTRF, CUSTTELNOPRTDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BILLPRTSTMNGCD, @BILLTABLEOUTCD, @TOTALBILLOUTPUTDIV, @DETAILBILLOUTPUTCODE, @BILLLASTDAYPRTDIV, @BILLCONMPRINTOUTCD, @BILLBANKNMPRINTOUT, @CUSTTELNOPRTDIVCD) ";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)billprtstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

                //Prameterオブジェクトの作成
                // del 2007.06.27 saito ※一部項目削除
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraBillPrtStMngCd = sqlCommand.Parameters.Add("@BILLPRTSTMNGCD", SqlDbType.Int);
                SqlParameter paraBillTableOutCd = sqlCommand.Parameters.Add("@BILLTABLEOUTCD", SqlDbType.Int);
                SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                SqlParameter paraBillLastDayPrtDiv = sqlCommand.Parameters.Add("@BILLLASTDAYPRTDIV", SqlDbType.Int);
                SqlParameter paraBillCoNmPrintOutCd = sqlCommand.Parameters.Add("@BILLCONMPRINTOUTCD", SqlDbType.Int);
                SqlParameter paraBillBankNmPrintOut = sqlCommand.Parameters.Add("@BILLBANKNMPRINTOUT", SqlDbType.Int);
                SqlParameter paraCustTelNoPrtDivCd = sqlCommand.Parameters.Add("@CUSTTELNOPRTDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                // del 2007.06.27 saito ※一部項目削除
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billprtstWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billprtstWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(billprtstWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billprtstWork.LogicalDeleteCode);
                paraBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);
                paraBillTableOutCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillTableOutCd);
                paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(billprtstWork.TotalBillOutputDiv);
                paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(billprtstWork.DetailBillOutputCode);
                paraBillLastDayPrtDiv.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillLastDayPrtDiv);
                paraBillCoNmPrintOutCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillCoNmPrintOutCd);
                paraBillBankNmPrintOut.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillBankNmPrintOut);
                paraCustTelNoPrtDivCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.CustTelNoPrtDivCd);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(billprtstWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"BillPrtStDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 請求印刷設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 請求印刷設定情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除請求印刷設定情報を復活します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除請求印刷設定情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// 請求印刷設定情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">BillPrtStWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 請求印刷設定情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			Debug.WriteLine("LogicalDelete");

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
				BillPrtStWork billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findparaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != billprtstWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE BILLPRTSTRF SET " +
						"UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
					findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)billprtstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					sqlConnection.Close();
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				//論理削除モードの場合
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	billprtstWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						billprtstWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	billprtstWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						if(myReader.IsClosed == false)myReader.Close();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billprtstWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billprtstWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(billprtstWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"BillPrtStDB.LogicalDeleteProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 請求印刷設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">請求印刷設定オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 請求印刷設定情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.07.20</br>
		public int Delete(byte[] parabyte)
		{
            return this.DeleteProc(parabyte);
        }
        /// <summary>
        /// 請求印刷設定情報を物理削除します
        /// </summary>
        /// <param name="parabyte">請求印刷設定オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 請求印刷設定情報を物理削除します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.07.20</br>
        private int DeleteProc(byte[] parabyte)
        {
			Debug.WriteLine("Delete");

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				BillPrtStWork billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findparaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != billprtstWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
																			 
					sqlCommand.CommandText = "DELETE FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
					findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					if(myReader.IsClosed == false)myReader.Close();
					sqlConnection.Close();
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

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
				base.WriteErrorLog(ex,"BillPrtStDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;
		}
	}
}
