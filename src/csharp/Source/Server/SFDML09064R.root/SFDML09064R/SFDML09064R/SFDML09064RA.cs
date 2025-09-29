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
	/// メール送信管理設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : メール送信管理設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class MailSndMngDB : RemoteDB , IMailSndMngDB
	{

		/// <summary>
		/// メール送信管理設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MailSndMngDB() :
		base("SFDML09066D", "Broadleaf.Application.Remoting.ParamData.MailSndMngWork", "MAILSNDMNGRF")
		{
		}

		/// <summary>
		/// 指定された企業コードのメール送信管理設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:MailSndMngWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール送信管理設定LISTの件数を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status =  SearchCntMailSndMngProc(out retCnt, parabyte, readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードのメール送信管理設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:MailSndMngWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール送信管理設定LISTの件数を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchCntMailSndMngProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			MailSndMngWork mailsndmngWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

            try
            {
			try 
			{	
				// XMLの読み込み
				mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

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
                base.WriteErrorLog(ex,"MailSndMngDB.SearchCntMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// 指定された企業コードのメール送信管理LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール送信管理LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
//			return SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status =  SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードのメール送信管理LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール送信管理LISTを指定件数分全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
//			return SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status =  SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードのメール送信管理LISTを全て戻します
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール送信管理LISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchMailSndMngProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			MailSndMngWork mailsndmngWork = new MailSndMngWork();
			mailsndmngWork = null;

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
				// XMLの読み込み
				mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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

				//件数指定リードで一件目リードの場合データ総件数を取得
				if ((readCnt > 0)&&(mailsndmngWork.MailSendMngNo == 0))
				{
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
						if ((mailsndmngWork.MailSendMngNo == 0))
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF",sqlConnection);
							SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
						if ((mailsndmngWork.MailSendMngNo == 0))
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF",sqlConnection);
							SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
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
						sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
					}
					else
					{
						//一件目リードの場合
						if ((mailsndmngWork.MailSendMngNo == 0))
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF",sqlConnection);
							SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

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

					al.Add(CopyToMailSndMngWorkFromReader(ref myReader));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			MailSndMngWork[] MailSndMngWorks = (MailSndMngWork[])al.ToArray(typeof(MailSndMngWork));
			retbyte = XmlByteSerializer.Serialize(MailSndMngWorks);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// 指定された企業コードのメール送信管理設定を戻します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール送信管理設定を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			MailSndMngWork mailsndmngWork = new MailSndMngWork();

            try
            {
			try 
			{			
				// XMLの読み込み
				mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
                    mailsndmngWork = CopyToMailSndMngWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(mailsndmngWork);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// メール送信管理設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール送信管理設定情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
				// XMLの読み込み
				MailSndMngWork mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, MAILSENDMNGNORF FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != mailsndmngWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (mailsndmngWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE MAILSNDMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , MAILSENDMNGNORF=@MAILSENDMNGNO , MAILADDRESSRF=@MAILADDRESS , DIALUPCODERF=@DIALUPCODE , DIALUPCONNECTNAMERF=@DIALUPCONNECTNAME , DIALUPLOGINNAMERF=@DIALUPLOGINNAME , DIALUPPASSWORDRF=@DIALUPPASSWORD , ACCESSTELNORF=@ACCESSTELNO , POP3USERIDRF=@POP3USERID , POP3PASSWORDRF=@POP3PASSWORD , POP3SERVERNAMERF=@POP3SERVERNAME , SMTPSERVERNAMERF=@SMTPSERVERNAME , SMTPUSERIDRF=@SMTPUSERID , SMTPPASSWORDRF=@SMTPPASSWORD , SMTPAUTHUSEDIVRF=@SMTPAUTHUSEDIV , SENDERNAMERF=@SENDERNAME , POPBEFORESMTPUSEDIVRF=@POPBEFORESMTPUSEDIV , POPSERVERPORTNORF=@POPSERVERPORTNO , SMTPSERVERPORTNORF=@SMTPSERVERPORTNO , MAILSERVERTIMEOUTVALRF=@MAILSERVERTIMEOUTVAL , BACKUPSENDDIVCDRF=@BACKUPSENDDIVCD , BACKUPFORMALRF=@BACKUPFORMAL , MAILSENDDIVUNITCNTRF=@MAILSENDDIVUNITCNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                    findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)mailsndmngWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (mailsndmngWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO MAILSNDMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAILSENDMNGNORF, MAILADDRESSRF, DIALUPCODERF, DIALUPCONNECTNAMERF, DIALUPLOGINNAMERF, DIALUPPASSWORDRF, ACCESSTELNORF, POP3USERIDRF, POP3PASSWORDRF, POP3SERVERNAMERF, SMTPSERVERNAMERF, SMTPUSERIDRF, SMTPPASSWORDRF, SMTPAUTHUSEDIVRF, SENDERNAMERF, POPBEFORESMTPUSEDIVRF, POPSERVERPORTNORF, SMTPSERVERPORTNORF, MAILSERVERTIMEOUTVALRF, BACKUPSENDDIVCDRF, BACKUPFORMALRF, MAILSENDDIVUNITCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @MAILSENDMNGNO, @MAILADDRESS, @DIALUPCODE, @DIALUPCONNECTNAME, @DIALUPLOGINNAME, @DIALUPPASSWORD, @ACCESSTELNO, @POP3USERID, @POP3PASSWORD, @POP3SERVERNAME, @SMTPSERVERNAME, @SMTPUSERID, @SMTPPASSWORD, @SMTPAUTHUSEDIV, @SENDERNAME, @POPBEFORESMTPUSEDIV, @POPSERVERPORTNO, @SMTPSERVERPORTNO, @MAILSERVERTIMEOUTVAL, @BACKUPSENDDIVCD, @BACKUPFORMAL, @MAILSENDDIVUNITCNT)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)mailsndmngWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

                #region 値セット
                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@MAILSENDMNGNO", SqlDbType.Int);
                SqlParameter paraMailAddress = sqlCommand.Parameters.Add("@MAILADDRESS", SqlDbType.NVarChar);
                SqlParameter paraDialUpCode = sqlCommand.Parameters.Add("@DIALUPCODE", SqlDbType.Int);
                SqlParameter paraDialUpConnectName = sqlCommand.Parameters.Add("@DIALUPCONNECTNAME", SqlDbType.NVarChar);
                SqlParameter paraDialUpLoginName = sqlCommand.Parameters.Add("@DIALUPLOGINNAME", SqlDbType.NVarChar);
                SqlParameter paraDialUpPassword = sqlCommand.Parameters.Add("@DIALUPPASSWORD", SqlDbType.NVarChar);
                SqlParameter paraAccessTelNo = sqlCommand.Parameters.Add("@ACCESSTELNO", SqlDbType.NChar);
                SqlParameter paraPop3UserId = sqlCommand.Parameters.Add("@POP3USERID", SqlDbType.NVarChar);
                SqlParameter paraPop3Password = sqlCommand.Parameters.Add("@POP3PASSWORD", SqlDbType.NVarChar);
                SqlParameter paraPop3ServerName = sqlCommand.Parameters.Add("@POP3SERVERNAME", SqlDbType.NVarChar);
                SqlParameter paraSmtpServerName = sqlCommand.Parameters.Add("@SMTPSERVERNAME", SqlDbType.NVarChar);
                SqlParameter paraSmtpUserId = sqlCommand.Parameters.Add("@SMTPUSERID", SqlDbType.NVarChar);
                SqlParameter paraSmtpPassword = sqlCommand.Parameters.Add("@SMTPPASSWORD", SqlDbType.NVarChar);
                SqlParameter paraSmtpAuthUseDiv = sqlCommand.Parameters.Add("@SMTPAUTHUSEDIV", SqlDbType.Int);
                SqlParameter paraSenderName = sqlCommand.Parameters.Add("@SENDERNAME", SqlDbType.NVarChar);
                SqlParameter paraPopBeforeSmtpUseDiv = sqlCommand.Parameters.Add("@POPBEFORESMTPUSEDIV", SqlDbType.Int);
                SqlParameter paraPopServerPortNo = sqlCommand.Parameters.Add("@POPSERVERPORTNO", SqlDbType.Int);
                SqlParameter paraSmtpServerPortNo = sqlCommand.Parameters.Add("@SMTPSERVERPORTNO", SqlDbType.Int);
                SqlParameter paraMailServerTimeoutVal = sqlCommand.Parameters.Add("@MAILSERVERTIMEOUTVAL", SqlDbType.Int);
                SqlParameter paraBackupSendDivCd = sqlCommand.Parameters.Add("@BACKUPSENDDIVCD", SqlDbType.Int);
                SqlParameter paraBackupFormal = sqlCommand.Parameters.Add("@BACKUPFORMAL", SqlDbType.Int);
                SqlParameter paraMailSendDivUnitCnt = sqlCommand.Parameters.Add("@MAILSENDDIVUNITCNT", SqlDbType.Int);

                //Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailsndmngWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailsndmngWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(mailsndmngWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
                paraMailAddress.Value = SqlDataMediator.SqlSetString(mailsndmngWork.MailAddress);
                paraDialUpCode.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.DialUpCode);
                paraDialUpConnectName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.DialUpConnectName);
                paraDialUpLoginName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.DialUpLoginName);
                paraDialUpPassword.Value = SqlDataMediator.SqlSetString(mailsndmngWork.DialUpPassword);
                paraAccessTelNo.Value = SqlDataMediator.SqlSetString(mailsndmngWork.AccessTelNo);
                paraPop3UserId.Value = SqlDataMediator.SqlSetString(mailsndmngWork.Pop3UserId);
                paraPop3Password.Value = SqlDataMediator.SqlSetString(mailsndmngWork.Pop3Password);
                paraPop3ServerName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.Pop3ServerName);
                paraSmtpServerName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SmtpServerName);
                paraSmtpUserId.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SmtpUserId);
                paraSmtpPassword.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SmtpPassword);
                paraSmtpAuthUseDiv.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.SmtpAuthUseDiv);
                paraSenderName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SenderName);
                paraPopBeforeSmtpUseDiv.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.PopBeforeSmtpUseDiv);
                paraPopServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.PopServerPortNo);
                paraSmtpServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.SmtpServerPortNo);
                paraMailServerTimeoutVal.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailServerTimeoutVal);
                paraBackupSendDivCd.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.BackupSendDivCd);
                paraBackupFormal.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.BackupFormal);
                paraMailSendDivUnitCnt.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendDivUnitCnt);
                #endregion

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(mailsndmngWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// メール送信管理を論理削除します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール送信管理を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteMailSndMngProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteMailSndMngProc(ref parabyte,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 論理削除メール送信管理を復活します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除メール送信管理を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteMailSndMngProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteMailSndMngProc(ref parabyte,1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// メール送信管理の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール送信管理の論理削除を操作します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int LogicalDeleteMailSndMngProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try		
			{
				// XMLの読み込み
				MailSndMngWork mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, MAILSENDMNGNORF FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != mailsndmngWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE MAILSNDMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                    findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)mailsndmngWork;
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
				sqlCommand.Cancel();
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
					else if	(logicalDelCd == 0)	mailsndmngWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						mailsndmngWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	mailsndmngWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						sqlCommand.Cancel();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailsndmngWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(mailsndmngWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.LogicalDeleteMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// メール送信管理を物理削除します
		/// </summary>
		/// <param name="parabyte">メール送信管理オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : メール送信管理を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
				// XMLの読み込み
				MailSndMngWork mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, MAILSENDMNGNORF FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != mailsndmngWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO";
					//KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                    findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
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

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }

        #region CustomMethod
        /// <summary>
        /// 指定された企業コードのメール送信管理LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="mailSndMngWork">検索結果</param>
        /// <param name="paramailSndMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのメール送信管理LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.06.17</br>
        public int Search(out object mailSndMngWork, object paramailSndMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            mailSndMngWork = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                return SearchMailSndMngProc(out mailSndMngWork, paramailSndMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MailSndMngDB.Search");
                mailSndMngWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された企業コードのメール送信管理LISTを全て戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="objmailSndMngWork">検索結果</param>
        /// <param name="paramailSndMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのメール送信管理LISTを全て戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.06.17</br>
        private int SearchMailSndMngProc(out object objmailSndMngWork, object paramailSndMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            MailSndMngWork mailsndmngWork = new MailSndMngWork();
            mailsndmngWork = null;

            objmailSndMngWork = null;

            ArrayList al = new ArrayList();
            try
            {
                ArrayList mailsndmngWorkList = paramailSndMngWork as ArrayList;
                if (mailsndmngWorkList == null)
                {
                    mailsndmngWork = paramailSndMngWork as MailSndMngWork;
                }
                else
                {
                    if (mailsndmngWorkList.Count > 0)
                        mailsndmngWork = mailsndmngWorkList[0] as MailSndMngWork;
                }

                sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ", sqlConnection);

                //企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                
                //論理削除区分
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (wkstring != "")
                {
                    sqlCommand.CommandText += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMailSndMngWorkFromReader(ref myReader));

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
                if (!myReader.IsClosed) myReader.Close();
            }

            objmailSndMngWork = al;

            return status;
        }

        #endregion

        #region CopyToClassFromReader

        /// <summary>
        /// メール送信管理クラス格納処理 Reader → MailSndMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MailSndMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.10.17</br>
        /// </remarks>
        private MailSndMngWork CopyToMailSndMngWorkFromReader(ref SqlDataReader myReader)
        {
            MailSndMngWork wkMailSndMngWork = new MailSndMngWork();

            #region クラスへ格納
            wkMailSndMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMailSndMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMailSndMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMailSndMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMailSndMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMailSndMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMailSndMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMailSndMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkMailSndMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkMailSndMngWork.MailSendMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDMNGNORF"));
            wkMailSndMngWork.MailAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESSRF"));
            wkMailSndMngWork.DialUpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIALUPCODERF"));
            wkMailSndMngWork.DialUpConnectName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPCONNECTNAMERF"));
            wkMailSndMngWork.DialUpLoginName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPLOGINNAMERF"));
            wkMailSndMngWork.DialUpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPPASSWORDRF"));
            wkMailSndMngWork.AccessTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCESSTELNORF"));
            wkMailSndMngWork.Pop3UserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3USERIDRF"));
            wkMailSndMngWork.Pop3Password = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3PASSWORDRF"));
            wkMailSndMngWork.Pop3ServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3SERVERNAMERF"));
            wkMailSndMngWork.SmtpServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPSERVERNAMERF"));
            wkMailSndMngWork.SmtpUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPUSERIDRF"));
            wkMailSndMngWork.SmtpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPPASSWORDRF"));
            wkMailSndMngWork.SmtpAuthUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPAUTHUSEDIVRF"));
            wkMailSndMngWork.SenderName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDERNAMERF"));
            wkMailSndMngWork.PopBeforeSmtpUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPBEFORESMTPUSEDIVRF"));
            wkMailSndMngWork.PopServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPSERVERPORTNORF"));
            wkMailSndMngWork.SmtpServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPSERVERPORTNORF"));
            wkMailSndMngWork.MailServerTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSERVERTIMEOUTVALRF"));
            wkMailSndMngWork.BackupSendDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPSENDDIVCDRF"));
            wkMailSndMngWork.BackupFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPFORMALRF"));
            wkMailSndMngWork.MailSendDivUnitCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDDIVUNITCNTRF"));
            #endregion

            return wkMailSndMngWork;
        }

        #endregion
    }

}

