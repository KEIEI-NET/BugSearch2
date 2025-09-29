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
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 拠点情報設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点情報設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br>           : 流通基幹対応(倉庫追加)</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.17  山田 明友</br>
    /// <br>             Searchメソッド(SqlTransaction付き)を追加</br>
    /// <br>Update Note: 2008.05.22  20081 疋田 勇人</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// </remarks>
	[Serializable]
    public class SecInfoSetDB : RemoteDB, ISecInfoSetDB, IGetSyncdataList
	{

		/// <summary>
		/// 拠点情報設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public SecInfoSetDB() :
			base("SFKTN09006D", "Broadleaf.Application.Remoting.ParamData.SecInfoSetWork", "SECINFOSETRF")
		{
		}

		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:SecInfoSetWorkクラス：拠点コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:SecInfoSetWorkクラス：拠点コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			SecInfoSetWork secinfosetWork = null;

			retCnt = 0;

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
				secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                string sqlTxt = string.Empty; // 2008.05.22 add

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.22 upd start ---------------------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ------------------------------------------------------<<
                        //論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.22 upd start ---------------------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ------------------------------------------------------<<
                        //論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.22 upd start ---------------------------------------------------->>
						//sqlCommand.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ------------------------------------------------------<<
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

					//データリード
					retCnt = (int)sqlCommand.ExecuteScalar();
					if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					sqlCommand.Cancel();
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.SearchCnt Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			
			return status;
		}

		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			bool nextData;
			int retTotalCnt;
			retbyte = null;
			try
			{
				status = SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Search Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			nextData = false;
			retTotalCnt = 0;
			retbyte = null;
			try
			{
				status = SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.SearchSpecification Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTを全て戻します
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			SecInfoSetWork secinfosetWork = new SecInfoSetWork();
			secinfosetWork = null;

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
				//コネクション文字列取得対応↓↓↓↓↓
				//※各publicメソッドの開始時にコネクション文字列を取得
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//コネクション文字列取得対応↑↑↑↑↑

				// XMLの読み込み
				secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

                string sqlTxt = string.Empty;  // 2008.05.22 add 

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得
				if ((readCnt > 0)&&((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == "")))
				{
					using(SqlCommand sqlCommandCount = new SqlCommand("",sqlConnection))
					{
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                            //論理削除区分設定
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                            //論理削除区分設定
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else 
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommandCount.CommandText = "SELECT COUNT (*) FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommandCount.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
						}
						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
						sqlCommandCount.Cancel();
					}
				}
                sqlTxt = string.Empty; // 2008.05.22 add

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//データ読込
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						//件数指定無しの場合
						if (readCnt == 0)
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                            sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt; 
                            // 2008.05.22 upd end ------------------------------------------------------<<
                        }
						else
						{
							//一件目リードの場合
							if ((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == ""))
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt; 
                                // 2008.05.22 upd end --------------------------------------------------<<
                            }
								//Nextリードの場合
							else
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                                
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
							}
						}
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						//件数指定無しの場合
						if (readCnt == 0)
						{
                            // 2008.05.22 upd start ---------------------------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                            sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                        }
						else
						{
							//一件目リードの場合
							if ((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == ""))
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                            }
								//Nextリードの場合
							else
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
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
                            // 2008.05.22 upd start----------------------------------------------------->>
							//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                            sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                            sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.22 upd end ------------------------------------------------------<<
                        }
						else
						{
							//一件目リードの場合
							if ((secinfosetWork.SectionCode == null)||(secinfosetWork.SectionCode == ""))
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                            }
							else
							{
                                // 2008.05.22 upd start ------------------------------------------------>>
								//sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF>@FINDSECTIONCODE ORDER BY SECTIONCODERF";
                                sqlTxt += "SELECT TOP" + Environment.NewLine;
                                sqlTxt += _readCnt.ToString() + Environment.NewLine;
                                sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF>@FINDSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText = sqlTxt;
                                // 2008.05.22 upd end --------------------------------------------------<<
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
								paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
							}
						}
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

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
						SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

						wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                        wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));    // 2008.05.22 add
						wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
                        wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                        wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));   // 2008.05.22 add
                        // ↓ 20070926 980081 a
                        wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                        wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                        wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                        // ↑ 20070926 980081 a
						al.Add(wkSecInfoSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					sqlCommand.Cancel();
				}
				// XMLへ変換し、文字列のバイナリ化
				SecInfoSetWork[] SecInfoSetWorks = (SecInfoSetWork[])al.ToArray(typeof(SecInfoSetWork));
				retbyte = XmlByteSerializer.Serialize(SecInfoSetWorks);
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.SearchProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}
		
		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="secinfosetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="sqlConnection">コネクション情報</param>
		/// <returns>STATUS</returns>
		public int Search(out ArrayList retList,SecInfoSetWork secinfosetWork, int readMode,ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection)
		{
            return this.SearchProc(out retList, secinfosetWork, readMode, logicalMode, ref sqlConnection);
        }
		/// <summary>
		/// 指定された拠点コードの拠点情報設定LISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="secinfosetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="sqlConnection">コネクション情報</param>
		/// <returns>STATUS</returns>
        /// 
        private int SearchProc(out ArrayList retList,SecInfoSetWork secinfosetWork, int readMode,ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			ArrayList al = new ArrayList();
			try 
			{
                string sqlTxt = string.Empty; // 2008.05.22 add

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//データ読込
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.22 upd start ----------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -------------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.22 upd start ----------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -------------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
                        // 2008.05.22 upd start ----------------------------------------->>
						//sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -------------------------------------------<<
                    }
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();

					while(myReader.Read())
					{
						SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

						wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
						wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                        wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));     // 2008.05.22 add
						wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
                        wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                        wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));    // 2008.05.22 add
                        // ↓ 20070926 980081 a
                        wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                        wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                        wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                        // ↑ 20070926 980081 a

						al.Add(wkSecInfoSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					sqlCommand.Cancel();
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();

			retList = al;

			return status;

		}

        // ↓ 2007.12.17 980081 a
        /// <summary>
        /// 指定された拠点コードの拠点情報設定LISTを全て戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="secinfosetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int Search(out ArrayList retList, SecInfoSetWork secinfosetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out retList, secinfosetWork, readMode, logicalMode, ref sqlConnection,ref sqlTransaction);
        }
        /// <summary>
        /// 指定された拠点コードの拠点情報設定LISTを全て戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="secinfosetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out ArrayList retList, SecInfoSetWork secinfosetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty; // 2008.05.22 add

                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                {
                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.22 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ----------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        // 2008.05.22 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ----------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        // 2008.05.22 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                        sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end ----------------------------------------<<
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

                        wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                        wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                        wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));  // 2008.05.22 add
                        wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                        wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                        wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF")); // 2008.05.22 add
                        // ↓ 20070926 980081 a
                        wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                        wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                        wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                        // ↑ 20070926 980081 a

                        al.Add(wkSecInfoSetWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    sqlCommand.Cancel();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }

            if (!myReader.IsClosed) myReader.Close();

            retList = al;

            return status;

        }
        // ↑ 2007.12.17 980081 a

		/// <summary>
		/// 指定された拠点コードの拠点情報設定を戻します
		/// </summary>
		/// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// 指定された拠点コードの拠点情報設定を戻します
        /// </summary>
        /// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			SecInfoSetWork secinfosetWork = new SecInfoSetWork();
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
				secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
                // 2008.05.22 upd start ------------------------------------------->>
				//SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.22 upd end ---------------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					secinfosetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					secinfosetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					secinfosetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					secinfosetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					secinfosetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					secinfosetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					secinfosetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					secinfosetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					secinfosetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
					secinfosetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secinfosetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));                 // 2008.05.22 add
					secinfosetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    secinfosetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
                    secinfosetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF")); // 2008.05.22 add
                    // ↓ 20070926 980081 a
                    secinfosetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
                    secinfosetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
                    secinfosetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
                    // ↑ 20070926 980081 a

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				// XMLへ変換し、文字列のバイナリ化
				parabyte = XmlByteSerializer.Serialize(secinfosetWork);
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Read Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// 拠点情報設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        /// <summary>
        /// 拠点情報設定情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        private int WriteProc(ref byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
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
				SecInfoSetWork secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
                // 2008.05.22 upd start ------------------------------------------------>>
				//SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.22 upd end --------------------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

                sqlTxt = string.Empty; // 2008.05.22 add

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != secinfosetWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (secinfosetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    // 2008.05.22 upd start -------------------------------------->>
					// ↓ 20070926 980081 c
                    //sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , OTHRSLIPCOMPANYNMCDRF=@OTHRSLIPCOMPANYNMCD , SECTIONGUIDENMRF=@SECTIONGUIDENM , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG , SECCDFORNUMBERINGRF=@SECCDFORNUMBERING , COMPANYNAMECD1RF=@COMPANYNAMECD1 , COMPANYNAMECD2RF=@COMPANYNAMECD2 , COMPANYNAMECD3RF=@COMPANYNAMECD3 , COMPANYNAMECD4RF=@COMPANYNAMECD4 , COMPANYNAMECD5RF=@COMPANYNAMECD5 , COMPANYNAMECD6RF=@COMPANYNAMECD6 , COMPANYNAMECD7RF=@COMPANYNAMECD7 , COMPANYNAMECD8RF=@COMPANYNAMECD8 , COMPANYNAMECD9RF=@COMPANYNAMECD9 , COMPANYNAMECD10RF=@COMPANYNAMECD10 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                    //sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , OTHRSLIPCOMPANYNMCDRF=@OTHRSLIPCOMPANYNMCD , SECTIONGUIDENMRF=@SECTIONGUIDENM , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG , SECCDFORNUMBERINGRF=@SECCDFORNUMBERING , COMPANYNAMECD1RF=@COMPANYNAMECD1 , COMPANYNAMECD2RF=@COMPANYNAMECD2 , COMPANYNAMECD3RF=@COMPANYNAMECD3 , COMPANYNAMECD4RF=@COMPANYNAMECD4 , COMPANYNAMECD5RF=@COMPANYNAMECD5 , COMPANYNAMECD6RF=@COMPANYNAMECD6 , COMPANYNAMECD7RF=@COMPANYNAMECD7 , COMPANYNAMECD8RF=@COMPANYNAMECD8 , COMPANYNAMECD9RF=@COMPANYNAMECD9 , COMPANYNAMECD10RF=@COMPANYNAMECD10 , SECTWAREHOUSECD1RF=@SECTWAREHOUSECD1 , SECTWAREHOUSENM1RF=@SECTWAREHOUSENM1 , SECTWAREHOUSECD2RF=@SECTWAREHOUSECD2 , SECTWAREHOUSENM2RF=@SECTWAREHOUSENM2 , SECTWAREHOUSECD3RF=@SECTWAREHOUSECD3 , SECTWAREHOUSENM3RF=@SECTWAREHOUSENM3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                    sqlTxt += "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += " , SECTIONGUIDENMRF=@SECTIONGUIDENM" + Environment.NewLine;
                    sqlTxt += " , SECTIONGUIDESNMRF=@SECTIONGUIDESNM" + Environment.NewLine;
                    sqlTxt += " , COMPANYNAMECD1RF=@COMPANYNAMECD1" + Environment.NewLine;
                    sqlTxt += " , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG" + Environment.NewLine;
                    sqlTxt += " , INTRODUCTIONDATERF=@INTRODUCTIONDATE" + Environment.NewLine;
                    sqlTxt += " , SECTWAREHOUSECD1RF=@SECTWAREHOUSECD1" + Environment.NewLine;
                    sqlTxt += " , SECTWAREHOUSECD2RF=@SECTWAREHOUSECD2" + Environment.NewLine;
                    sqlTxt += " , SECTWAREHOUSECD3RF=@SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // ↑ 20070926 980081 c
                    // 2008.05.22 upd end ----------------------------------------<<
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)secinfosetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (secinfosetWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
                    // 2008.05.22 upd start -------------------------------------------------->>
					// ↓ 20070926 980081 c
                    //sqlCommand.CommandText = "INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, SECCDFORNUMBERINGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @OTHRSLIPCOMPANYNMCD, @SECTIONGUIDENM, @MAINOFFICEFUNCFLAG, @SECCDFORNUMBERING, @COMPANYNAMECD1, @COMPANYNAMECD2, @COMPANYNAMECD3, @COMPANYNAMECD4, @COMPANYNAMECD5, @COMPANYNAMECD6, @COMPANYNAMECD7, @COMPANYNAMECD8, @COMPANYNAMECD9, @COMPANYNAMECD10)";
                    //sqlCommand.CommandText = "INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, SECCDFORNUMBERINGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF, SECTWAREHOUSECD1RF, SECTWAREHOUSENM1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSENM2RF, SECTWAREHOUSECD3RF, SECTWAREHOUSENM3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @OTHRSLIPCOMPANYNMCD, @SECTIONGUIDENM, @MAINOFFICEFUNCFLAG, @SECCDFORNUMBERING, @COMPANYNAMECD1, @COMPANYNAMECD2, @COMPANYNAMECD3, @COMPANYNAMECD4, @COMPANYNAMECD5, @COMPANYNAMECD6, @COMPANYNAMECD7, @COMPANYNAMECD8, @COMPANYNAMECD9, @COMPANYNAMECD10, @SECTWAREHOUSECD1, @SECTWAREHOUSENM1, @SECTWAREHOUSECD2, @SECTWAREHOUSENM2, @SECTWAREHOUSECD3, @SECTWAREHOUSENM3)";
                    // ↑ 20070926 980081 c
                    sqlTxt += "INSERT INTO SECINFOSETRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                    sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                    sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                    sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;
                    sqlTxt += " VALUES" + Environment.NewLine;
                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += "    ,@SECTIONGUIDENM" + Environment.NewLine;
                    sqlTxt += "    ,@SECTIONGUIDESNM" + Environment.NewLine;
                    sqlTxt += "    ,@COMPANYNAMECD1" + Environment.NewLine;
                    sqlTxt += "    ,@MAINOFFICEFUNCFLAG" + Environment.NewLine;
                    sqlTxt += "    ,@INTRODUCTIONDATE" + Environment.NewLine;
                    sqlTxt += "    ,@SECTWAREHOUSECD1" + Environment.NewLine;
                    sqlTxt += "    ,@SECTWAREHOUSECD2" + Environment.NewLine;
                    sqlTxt += "    ,@SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.22 upd end ----------------------------------------------------<<
                    //登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)secinfosetWork;
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
				SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
				SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
                SqlParameter paraSectionGuideSnm = sqlCommand.Parameters.Add("@SECTIONGUIDESNM", SqlDbType.NVarChar);   // 2008.05.22 add
				SqlParameter paraCompanyNameCd1 = sqlCommand.Parameters.Add("@COMPANYNAMECD1", SqlDbType.Int);
                SqlParameter paraMainOfficeFuncFlag = sqlCommand.Parameters.Add("@MAINOFFICEFUNCFLAG", SqlDbType.Int);
                SqlParameter paraIntroductionDate = sqlCommand.Parameters.Add("@INTRODUCTIONDATE", SqlDbType.Int);      // 2008.05.22 add
                // ↓ 20070926 980081 a
                SqlParameter paraSectWarehouseCd1 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD1", SqlDbType.NChar);
                SqlParameter paraSectWarehouseCd2 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD2", SqlDbType.NChar);
                SqlParameter paraSectWarehouseCd3 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD3", SqlDbType.NChar);
                // ↑ 20070926 980081 a

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secinfosetWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secinfosetWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secinfosetWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.LogicalDeleteCode);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
				paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionGuideNm);
                paraSectionGuideSnm.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionGuideSnm);      // 2008.05.22 add
				paraCompanyNameCd1.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.CompanyNameCd1);
                paraMainOfficeFuncFlag.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.MainOfficeFuncFlag);
                paraIntroductionDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(secinfosetWork.IntroductionDate);     // 2008.05.22 add
                // ↓ 20070926 980081 a
                paraSectWarehouseCd1.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectWarehouseCd1);
                paraSectWarehouseCd2.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectWarehouseCd2);
                paraSectWarehouseCd3.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectWarehouseCd3);
                // ↑ 20070926 980081 a

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(secinfosetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Write Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// 拠点情報設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return  LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除拠点情報設定情報を復活します
		/// </summary>
		/// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// 拠点情報設定情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">SecInfoSetWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
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
				SecInfoSetWork secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.22 upd start --------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.22 upd end -----------------------------------------------<<
                {
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != secinfosetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//現在の論理削除区分を取得
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // 2008.05.22 upd start --------------------------------------------->>
						//sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt += "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.22 upd end -----------------------------------------------<<
                        //KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)secinfosetWork;
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
						else if	(logicalDelCd == 0)	secinfosetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
						else						secinfosetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
					}
					else
					{
						if		(logicalDelCd == 1)	secinfosetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定(更新用)
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secinfosetWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secinfosetWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secinfosetWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(secinfosetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.LogicalDeleteProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;

		}

		/// <summary>
		/// 拠点情報設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">拠点情報設定オブジェクト</param>
		/// <returns></returns>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }
        /// <summary>
		/// 拠点情報設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">拠点情報設定オブジェクト</param>
		/// <returns></returns>
        private int DeleteProc(byte[] parabyte)
        {
        
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
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
				SecInfoSetWork secinfosetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.22 upd start ---------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
				string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using(SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.22 upd end ------------------------------------------------<<
                {
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != secinfosetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

                        // 2008.05.22 upd start ------------------------------->>
						//sqlCommand.CommandText = "DELETE FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt; 
                        // 2008.05.22 upd end ---------------------------------<<
                        //KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(secinfosetWork.SectionCode);
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
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SecInfoSetDB.Delete Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			
			return status;
		}

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品大分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝
        /// 也</br>
        /// <br>Date       : 2007.05.08</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品大分類マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝
        /// 也</br>
        /// <br>Date       : 2007.05.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.22 upd start ------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF  ", sqlConnection);
                string sqlTxt = string.Empty; 
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
                sqlTxt += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
                sqlTxt += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
                sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.22 upd end ---------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSecInfoSetWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SecInfoSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecInfoSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.09</br>
        /// </remarks>
        private SecInfoSetWork CopyToSecInfoSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

            #region クラスへ格納
            wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));  // 2008.05.22 add
            wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
            wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
            wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF")); // 2008.05.22 add
            // ↓ 20070926 980081 a
            wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
            wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
            wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
            // ↑ 20070926 980081 a
            #endregion

            return wkSecInfoSetWork;
        }
        #endregion


	}
}