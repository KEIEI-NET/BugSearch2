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
using Broadleaf.Application.Resources;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2005.07.23</br>
	/// <br></br>
	/// <br>Update Note: 22008 長内 PM.NS用に修正</br>
	/// </remarks>
	[Serializable]
	public class DepositStDB : RemoteDB , IDepositStDB
	{
//		private string _connectionText;		//コネクション文字列格納用

		/// <summary>
		/// 入金設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		/// </remarks>
		public DepositStDB() :
		base("SFUKK09066D", "Broadleaf.Application.Remoting.ParamData.DepositStWork", "DEPOSITSTRF") //基底クラスのコンストラクタ
		{
		}

		/// <summary>
		/// 指定された企業コードの入金設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:DepositStWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTの件数を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status =  SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードの入金設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:DepositStWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTの件数を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			DepositStWork depositstWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

            try
            {
			try 
			{	
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else										    				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

				//データリード
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			sqlConnection.Close();			


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchCntProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// 指定された企業コードの入金設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status =  SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードの入金設定LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTを指定件数分全て戻します（論理削除除く）</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status =  SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// 指定された企業コードの入金設定LISTを全て戻します
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTを全て戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork depositstWork = new DepositStWork();
			depositstWork = null;

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
			try 
			{	
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得
                if ((readCnt > 0)&&(depositstWork.DepositStMngCd == 0))
                {
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else												    		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
							SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
							paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
                        }
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
                        }
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

				int retCnt = 0;
				while(myReader.Read())
				{
					//戻り値カウンタカウント
					retCnt += 1;
					if (readCnt > 0)
					{
						//戻り値の件数が取得指示件数を超えた場合終了
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}

					DepositStWork wkDepositStWork = new DepositStWork();

					wkDepositStWork.CreateDateTime         = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkDepositStWork.UpdateDateTime         = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkDepositStWork.EnterpriseCode         = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkDepositStWork.FileHeaderGuid         = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkDepositStWork.UpdEmployeeCode        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkDepositStWork.UpdAssemblyId1         = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkDepositStWork.UpdAssemblyId2         = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkDepositStWork.LogicalDeleteCode      = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkDepositStWork.DepositStMngCd         = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                    wkDepositStWork.DepositInitDspNo       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                    wkDepositStWork.InitSelMoneyKindCd     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                    wkDepositStWork.DepositStKindCd1       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                    wkDepositStWork.DepositStKindCd2       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                    wkDepositStWork.DepositStKindCd3       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                    wkDepositStWork.DepositStKindCd4       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                    wkDepositStWork.DepositStKindCd5       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                    wkDepositStWork.DepositStKindCd6       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                    wkDepositStWork.DepositStKindCd7       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                    wkDepositStWork.DepositStKindCd8       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                    wkDepositStWork.DepositStKindCd9       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                    wkDepositStWork.DepositStKindCd10      = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                    wkDepositStWork.AlwcDepoCallMonthsCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));

					al.Add(wkDepositStWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			DepositStWork[] DepositStWorks = (DepositStWork[])al.ToArray(typeof(DepositStWork));
			retbyte = XmlByteSerializer.Serialize(DepositStWorks);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// 指定された企業コードの入金設定を戻します
		/// </summary>
		/// <param name="parabyte">DepositStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork depositstWork = new DepositStWork();

            try
            {
			try 
			{			
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value    = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value    = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

					if(myReader.Read())
					{
						depositstWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						depositstWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						depositstWork.EnterpriseCode       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						depositstWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						depositstWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						depositstWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						depositstWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						depositstWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        depositstWork.DepositStMngCd       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                        depositstWork.DepositInitDspNo     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                        depositstWork.InitSelMoneyKindCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                        depositstWork.DepositStKindCd1     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                        depositstWork.DepositStKindCd2     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                        depositstWork.DepositStKindCd3     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                        depositstWork.DepositStKindCd4     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                        depositstWork.DepositStKindCd5     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                        depositstWork.DepositStKindCd6     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                        depositstWork.DepositStKindCd7     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                        depositstWork.DepositStKindCd8     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                        depositstWork.DepositStKindCd9     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                        depositstWork.DepositStKindCd10    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                        depositstWork.AlwcDepoCallMonthsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));


						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(depositstWork);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// 入金設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">DepositStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金設定情報を登録、更新します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				DepositStWork depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DEPOSITSTMNGCDRF   FROM DEPOSITSTRF   WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value    = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value    = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader();

					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != depositstWork.UpdateDateTime)
						{
							//新規登録で該当データ有りの場合には重複
							if (depositstWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//既存データで更新日時違いの場合には排他
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						sqlCommand.CommandText = "UPDATE DEPOSITSTRF  SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DEPOSITSTMNGCDRF=@DEPOSITSTMNGCD , DEPOSITINITDSPNORF=@DEPOSITINITDSPNO , INITSELMONEYKINDCDRF=@INITSELMONEYKINDCD , DEPOSITSTKINDCD1RF=@DEPOSITSTKINDCD1 , DEPOSITSTKINDCD2RF=@DEPOSITSTKINDCD2 , DEPOSITSTKINDCD3RF=@DEPOSITSTKINDCD3 , DEPOSITSTKINDCD4RF=@DEPOSITSTKINDCD4 , DEPOSITSTKINDCD5RF=@DEPOSITSTKINDCD5 , DEPOSITSTKINDCD6RF=@DEPOSITSTKINDCD6 , DEPOSITSTKINDCD7RF=@DEPOSITSTKINDCD7 , DEPOSITSTKINDCD8RF=@DEPOSITSTKINDCD8 , DEPOSITSTKINDCD9RF=@DEPOSITSTKINDCD9 , DEPOSITSTKINDCD10RF=@DEPOSITSTKINDCD10 , ALWCDEPOCALLMONTHSCDRF=@ALWCDEPOCALLMONTHSCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD";

						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                        findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)depositstWork;
                        FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						if (depositstWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						//新規作成時のSQL文を生成
                        sqlCommand.CommandText = "INSERT INTO DEPOSITSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITSTMNGCDRF, DEPOSITINITDSPNORF, INITSELMONEYKINDCDRF, DEPOSITSTKINDCD1RF, DEPOSITSTKINDCD2RF, DEPOSITSTKINDCD3RF, DEPOSITSTKINDCD4RF, DEPOSITSTKINDCD5RF, DEPOSITSTKINDCD6RF, DEPOSITSTKINDCD7RF, DEPOSITSTKINDCD8RF, DEPOSITSTKINDCD9RF, DEPOSITSTKINDCD10RF, ALWCDEPOCALLMONTHSCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEPOSITSTMNGCD, @DEPOSITINITDSPNO, @INITSELMONEYKINDCD, @DEPOSITSTKINDCD1, @DEPOSITSTKINDCD2, @DEPOSITSTKINDCD3, @DEPOSITSTKINDCD4, @DEPOSITSTKINDCD5, @DEPOSITSTKINDCD6, @DEPOSITSTKINDCD7, @DEPOSITSTKINDCD8, @DEPOSITSTKINDCD9, @DEPOSITSTKINDCD10, @ALWCDEPOCALLMONTHSCD)";

						//登録ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)depositstWork;
                        FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetInsertHeader(ref flhd,obj);
					}
					if(!myReader.IsClosed)myReader.Close();

                    #region 値セット
					//Prameterオブジェクトの作成
					SqlParameter paraCreateDateTime       = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdateDateTime       = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraEnterpriseCode       = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
					SqlParameter paraFileHeaderGuid       = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
					SqlParameter paraUpdEmployeeCode      = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1       = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2       = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode    = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraDepositStMngCd       = sqlCommand.Parameters.Add("@DEPOSITSTMNGCD", SqlDbType.Int);
                    SqlParameter paraDepositInitDspNo     = sqlCommand.Parameters.Add("@DEPOSITINITDSPNO", SqlDbType.Int);
                    SqlParameter paraInitSelMoneyKindCd   = sqlCommand.Parameters.Add("@INITSELMONEYKINDCD", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd1     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD1", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd2     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD2", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd3     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD3", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd4     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD4", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd5     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD5", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd6     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD6", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd7     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD7", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd8     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD8", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd9     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD9", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd10    = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD10", SqlDbType.Int);
                    SqlParameter paraAlwcDepoCallMonthsCd = sqlCommand.Parameters.Add("@ALWCDEPOCALLMONTHSCD", SqlDbType.Int);


                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(depositstWork.CreateDateTime);
                    paraUpdateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(depositstWork.UpdateDateTime);
                    paraEnterpriseCode.Value       = SqlDataMediator.SqlSetString(           depositstWork.EnterpriseCode);
                    paraFileHeaderGuid.Value       = SqlDataMediator.SqlSetGuid(             depositstWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value      = SqlDataMediator.SqlSetString(           depositstWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value       = SqlDataMediator.SqlSetString(           depositstWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value       = SqlDataMediator.SqlSetString(           depositstWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value    = SqlDataMediator.SqlSetInt32(            depositstWork.LogicalDeleteCode);

                    paraDepositStMngCd.Value       = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStMngCd);
                    paraDepositInitDspNo.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositInitDspNo);
                    paraInitSelMoneyKindCd.Value   = SqlDataMediator.SqlSetInt32(            depositstWork.InitSelMoneyKindCd);
                    paraDepositStKindCd1.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd1);
                    paraDepositStKindCd2.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd2);
                    paraDepositStKindCd3.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd3);
                    paraDepositStKindCd4.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd4);
                    paraDepositStKindCd5.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd5);
                    paraDepositStKindCd6.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd6);
                    paraDepositStKindCd7.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd7);
                    paraDepositStKindCd8.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd8);
                    paraDepositStKindCd9.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd9);
                    paraDepositStKindCd10.Value    = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd10);
                    paraAlwcDepoCallMonthsCd.Value = SqlDataMediator.SqlSetInt32(            depositstWork.AlwcDepoCallMonthsCd);
                    #endregion

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(depositstWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// 入金設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">DepositStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金設定情報を論理削除します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteProc(ref parabyte,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 論理削除入金設定情報を復活します
		/// </summary>
		/// <param name="parabyte">DepositStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除入金設定情報を復活します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteProc(ref parabyte,1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// 入金設定情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">DepositStWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金設定情報の論理削除を操作します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try		
			{
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				DepositStWork depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DEPOSITSTMNGCDRF FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != depositstWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//現在の論理削除区分を取得
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

						sqlCommand.CommandText = "UPDATE DEPOSITSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD";
						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                        findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)depositstWork;
                        FileHeader fileHeader = new FileHeader(obj); 
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					sqlCommand.Cancel();
					if(!myReader.IsClosed)myReader.Close();

					//論理削除モードの場合
					if (procMode == 0)
					{
						if		(logicalDelCd == 3)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						else if	(logicalDelCd == 0)	depositstWork.LogicalDeleteCode = 1;//論理削除フラグをセット
						else						depositstWork.LogicalDeleteCode = 3;//完全削除フラグをセット
					}
					else
					{
						if		(logicalDelCd == 1)	depositstWork.LogicalDeleteCode = 0;//論理削除フラグを解除
						else
						{
							if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
							else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
					}

					//Parameterオブジェクトの作成(更新用)
					SqlParameter paraUpdateDateTime    = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode   = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1    = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2    = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定(更新用)
					paraUpdateDateTime.Value    = SqlDataMediator.SqlSetDateTimeFromTicks(depositstWork.UpdateDateTime);
					paraUpdEmployeeCode.Value   = SqlDataMediator.SqlSetString(depositstWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value    = SqlDataMediator.SqlSetString(depositstWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value    = SqlDataMediator.SqlSetString(depositstWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositstWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(depositstWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.LogicalDeleteProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// 入金設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">入金設定オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 入金設定情報を物理削除します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				DepositStWork depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DEPOSITSTMNGCDRF FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
						if (_updateDateTime != depositstWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						sqlCommand.CommandText = "DELETE FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD";
						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                        findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
                    }
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					if(!myReader.IsClosed)myReader.Close();

					sqlCommand.ExecuteNonQuery();

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}



		#region カスタムシリアライズ

		/// <summary>
		/// 指定された企業コードの入金設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
//			return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retobj = null;
            try
            {
                status =  SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// 指定された企業コードの入金設定LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraobj">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTを指定件数分全て戻します（論理削除除く）</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int SearchSpecification(out object retobj,out int retTotalCnt,out bool nextData,object paraobj,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
//			return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj, readMode,logicalMode,readCnt);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retobj = null;
            try
            {
                status =  SearchProc(out retobj,out retTotalCnt,out nextData,paraobj, readMode,logicalMode,readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// 指定された企業コードの入金設定LISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定LISTを全て戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		private int SearchProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork depositstWork = new DepositStWork();
			depositstWork = null;

			retobj = null;

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
			try 
			{	
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				depositstWork = paraobj as DepositStWork;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得
                if ((readCnt > 0)&&(depositstWork.DepositStMngCd == 0))
				{
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else												    		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				int retCnt = 0;
				while(myReader.Read())
				{
					//戻り値カウンタカウント
					retCnt += 1;
					if (readCnt > 0)
					{
						//戻り値の件数が取得指示件数を超えた場合終了
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}
					DepositStWork wkDepositStWork = new DepositStWork();

					wkDepositStWork.CreateDateTime             = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkDepositStWork.UpdateDateTime             = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkDepositStWork.EnterpriseCode             = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkDepositStWork.FileHeaderGuid             = SqlDataMediator.SqlGetGuid(             myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkDepositStWork.UpdEmployeeCode            = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkDepositStWork.UpdAssemblyId1             = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkDepositStWork.UpdAssemblyId2             = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkDepositStWork.LogicalDeleteCode          = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkDepositStWork.DepositStMngCd             = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                    wkDepositStWork.DepositInitDspNo           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                    wkDepositStWork.InitSelMoneyKindCd         = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                    wkDepositStWork.DepositStKindCd1           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                    wkDepositStWork.DepositStKindCd2           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                    wkDepositStWork.DepositStKindCd3           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                    wkDepositStWork.DepositStKindCd4           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                    wkDepositStWork.DepositStKindCd5           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                    wkDepositStWork.DepositStKindCd6           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                    wkDepositStWork.DepositStKindCd7           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                    wkDepositStWork.DepositStKindCd8           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                    wkDepositStWork.DepositStKindCd9           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                    wkDepositStWork.DepositStKindCd10          = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                    wkDepositStWork.AlwcDepoCallMonthsCd       = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));

					al.Add(wkDepositStWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			retobj = al;


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// 指定された企業コードの入金設定を戻します
		/// </summary>
		/// <param name="depositStWork">DepositStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int Read(ref object depositStWork, int readMode)
		{
			DepositStWork wkDepositStWork = depositStWork as DepositStWork;
			if(wkDepositStWork == null)return (int)ConstantManagement.DB_Status.ctDB_ERROR;
//			return ReadDepositStWork(readMode , 0 , wkDepositStWork.EnterpriseCode , wkDepositStWork.DepositStMngCd , out depositStWork);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  ReadDepositStWork(readMode , 0 , wkDepositStWork.EnterpriseCode , wkDepositStWork.DepositStMngCd , out depositStWork);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }	

		/// <summary>
		/// 指定された企業コードの入金設定を戻します
		/// </summary>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="depositStMngCd">入金設定管理コード</param>
		/// <param name="depositStWork">取得データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの入金設定を戻します</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.07.23</br>
		public int ReadDepositStWork(int readMode, ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int depositStMngCd, out object depositStWork)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork wkdepositStWork = new DepositStWork();

            depositStWork = null;

            try
            {
			try 
			{			
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
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositStMngCd);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
						wkdepositStWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkdepositStWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkdepositStWork.EnterpriseCode       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkdepositStWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkdepositStWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkdepositStWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkdepositStWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkdepositStWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        wkdepositStWork.DepositStMngCd       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                        wkdepositStWork.DepositInitDspNo     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                        wkdepositStWork.InitSelMoneyKindCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                        wkdepositStWork.DepositStKindCd1     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                        wkdepositStWork.DepositStKindCd2     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                        wkdepositStWork.DepositStKindCd3     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                        wkdepositStWork.DepositStKindCd4     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                        wkdepositStWork.DepositStKindCd5     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                        wkdepositStWork.DepositStKindCd6     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                        wkdepositStWork.DepositStKindCd7     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                        wkdepositStWork.DepositStKindCd8     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                        wkdepositStWork.DepositStKindCd9     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                        wkdepositStWork.DepositStKindCd10    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                        wkdepositStWork.AlwcDepoCallMonthsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			depositStWork = wkdepositStWork;


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.ReadDepositStWork Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		#endregion


	}

}
