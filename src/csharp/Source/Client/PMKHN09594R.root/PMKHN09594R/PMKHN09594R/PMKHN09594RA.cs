//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール情報設定マスタメンテナンス
// プログラム概要   : メール情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/05/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// メール情報設定マスタメンテナンスDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : メール情報設定マスタの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 李占川</br>
	/// <br>Date       : 2010/05/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class MailInfoSettingDB : RemoteDB , IMailInfoSettingDB
	{
		/// <summary>
		/// メール情報設定マスタメンテナンスDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		/// </remarks>
		public MailInfoSettingDB() :
        base("PMKHN09596D", "Broadleaf.Application.Remoting.ParamData.MailInfoSettingWork", "MAILINFOSETTINGRF")
		{
        }

        # region -- 検索処理 --
        /// <summary>
		/// 指定された企業コードのメール情報設定マスタLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:MailInfoSettingWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール情報設定マスタLISTの件数を戻します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status = SearchCntMailInfoSettingProc(out retCnt, parabyte, readMode, logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードのメール情報設定マスタLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:MailInfoSettingWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール情報設定マスタLISTの件数を戻します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
        private int SearchCntMailInfoSettingProc(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

            MailInfoSettingWork mailsndmngWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

            try
            {
			    try 
			    {	
				    // XMLの読み込み
                    mailsndmngWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    //SQL文生成
				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

				    SqlCommand sqlCommand;
				    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					    (logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				    {
                        sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
					    //論理削除区分設定
					    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				    }
				    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					    (logicalMode == ConstantManagement.LogicalMode.GetData012))
				    {
                        sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
					    //論理削除区分設定
					    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					    if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					    else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				    }
				    else 
				    {
                        sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
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
                base.WriteErrorLog(ex,"MailInfoSettingDB.SearchCntMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// 指定された企業コードのメール情報設定マスタLISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール情報設定マスタLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status = SearchMailInfoSettingProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, 0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードのメール情報設定マスタLISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール情報設定マスタLISTを指定件数分全て戻します（論理削除除く）</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status = SearchMailInfoSettingProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードのメール情報設定マスタLISTを全て戻します
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール情報設定マスタLISTを全て戻します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
        private int SearchMailInfoSettingProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();
			mailInfoSettingWork = null;

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
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    //SQL文生成
				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();				

				    //件数指定リードで一件目リードの場合データ総件数を取得
				    if ((readCnt > 0)&&(mailInfoSettingWork.MailSendMngNo == 0))
				    {
					    SqlCommand sqlCommandCount;
					    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						    (logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
					    {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
						    //論理削除区分設定
						    SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					    }
					    else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
					    {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
						    //論理削除区分設定
						    SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						    if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						    else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					    }
					    else 
					    {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
					    }
					    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);

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
                            sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
					    }
					    else
					    {
						    //一件目リードの場合
						    if ((mailInfoSettingWork.MailSendMngNo == 0))
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
						    }
							    //Nextリードの場合
						    else
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF", sqlConnection);
							    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
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
                            sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
					    }
					    else
					    {
						    //一件目リードの場合
						    if ((mailInfoSettingWork.MailSendMngNo == 0))
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
						    }
							    //Nextリードの場合
						    else
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF", sqlConnection);
							    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
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
                            sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
					    }
					    else
					    {
						    //一件目リードの場合
						    if ((mailInfoSettingWork.MailSendMngNo == 0))
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
						    }
						    else
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF", sqlConnection);
							    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
						    }
					    }
				    }
				    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);

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

					    al.Add(CopyToMailInfoSettingWorkFromReader(ref myReader));

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
                MailInfoSettingWork[] MailSndMngWorks = (MailInfoSettingWork[])al.ToArray(typeof(MailInfoSettingWork));
			    retbyte = XmlByteSerializer.Serialize(MailSndMngWorks);

            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "MailInfoSettingDB.SearchMailInfoSettingProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// 指定された企業コードのメール情報設定マスタを戻します
		/// </summary>
        /// <param name="parabyte">MailInfoSettingWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのメール情報設定マスタを戻します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();

            try
            {
			    try 
			    {			
				    // XMLの読み込み
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

				    //Selectコマンドの生成
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    //SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);
                    //findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);

				    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				    if(myReader.Read())
				    {
                        mailInfoSettingWork = CopyToMailInfoSettingWorkFromReader(ref myReader);

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
			    parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }

        /// <summary>
        /// 指定された企業コードのメール情報設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="mailInfoSettingWork">検索結果</param>
        /// <param name="paraMailInfoSettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのメール情報設定マスタLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        public int Search(out object mailInfoSettingWork, object paraMailInfoSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            mailInfoSettingWork = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                return SearchMailInfoSettingProc(out mailInfoSettingWork, paraMailInfoSettingWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MailInfoSettingDB.Search");
                mailInfoSettingWork = new ArrayList();
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
        /// 指定された企業コードのメール情報設定マスタLISTを全て戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="objMailInfoSettingWork">検索結果</param>
        /// <param name="paraMailInfoSettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのメール情報設定マスタLISTを全て戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        private int SearchMailInfoSettingProc(out object objMailInfoSettingWork, object paraMailInfoSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            MailInfoSettingWork mailsndmngWork = new MailInfoSettingWork();
            mailsndmngWork = null;

            objMailInfoSettingWork = null;

            ArrayList al = new ArrayList();
            try
            {
                ArrayList mailsndmngWorkList = paraMailInfoSettingWork as ArrayList;
                if (mailsndmngWorkList == null)
                {
                    mailsndmngWork = paraMailInfoSettingWork as MailInfoSettingWork;
                }
                else
                {
                    if (mailsndmngWorkList.Count > 0)
                    {
                        mailsndmngWork = mailsndmngWorkList[0] as MailInfoSettingWork;
                    }
                }

                sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ", sqlConnection);

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

                    al.Add(CopyToMailInfoSettingWorkFromReader(ref myReader));

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

            objMailInfoSettingWork = al;

            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /// <summary>
		/// メール情報設定マスタ情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MailInfoSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール情報設定マスタ情報を登録、更新します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
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
                    MailInfoSettingWork mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

				    //Selectコマンドの生成
                    SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, MAILSENDMNGNORF FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

				    myReader = sqlCommand.ExecuteReader();
				    if(myReader.Read())
				    {
					    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					    if (_updateDateTime != mailInfoSettingWork.UpdateDateTime)
					    {
						    //新規登録で該当データ有りの場合には重複
                            if (mailInfoSettingWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            //既存データで更新日時違いの場合には排他
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }

                        sqlCommand.CommandText = "UPDATE MAILINFOSETTINGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , MAILSENDMNGNORF=@MAILSENDMNGNO , MAILADDRESSRF=@MAILADDRESS , DIALUPCODERF=@DIALUPCODE , DIALUPCONNECTNAMERF=@DIALUPCONNECTNAME , DIALUPLOGINNAMERF=@DIALUPLOGINNAME , DIALUPPASSWORDRF=@DIALUPPASSWORD , ACCESSTELNORF=@ACCESSTELNO , POP3USERIDRF=@POP3USERID , POP3PASSWORDRF=@POP3PASSWORD , POP3SERVERNAMERF=@POP3SERVERNAME , SMTPSERVERNAMERF=@SMTPSERVERNAME , SMTPUSERIDRF=@SMTPUSERID , SMTPPASSWORDRF=@SMTPPASSWORD , SMTPAUTHUSEDIVRF=@SMTPAUTHUSEDIV , SENDERNAMERF=@SENDERNAME , POPBEFORESMTPUSEDIVRF=@POPBEFORESMTPUSEDIV , POPSERVERPORTNORF=@POPSERVERPORTNO , SMTPSERVERPORTNORF=@SMTPSERVERPORTNO , MAILSERVERTIMEOUTVALRF=@MAILSERVERTIMEOUTVAL , BACKUPSENDDIVCDRF=@BACKUPSENDDIVCD , BACKUPFORMALRF=@BACKUPFORMAL , MAILSENDDIVUNITCNTRF=@MAILSENDDIVUNITCNT , FILEPATHNMRF=@FILEPATHNM WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
					    //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

					    //更新ヘッダ情報を設定
					    object obj = (object)this;
					    IFileHeader flhd = (IFileHeader)mailInfoSettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
					    fileHeader.SetUpdateHeader(ref flhd,obj);
				    }
				    else
				    {
					    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					    if (mailInfoSettingWork.UpdateDateTime > DateTime.MinValue)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }

					    //新規作成時のSQL文を生成
                        sqlCommand.CommandText = "INSERT INTO MAILINFOSETTINGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAILSENDMNGNORF, MAILADDRESSRF, DIALUPCODERF, DIALUPCONNECTNAMERF, DIALUPLOGINNAMERF, DIALUPPASSWORDRF, ACCESSTELNORF, POP3USERIDRF, POP3PASSWORDRF, POP3SERVERNAMERF, SMTPSERVERNAMERF, SMTPUSERIDRF, SMTPPASSWORDRF, SMTPAUTHUSEDIVRF, SENDERNAMERF, POPBEFORESMTPUSEDIVRF, POPSERVERPORTNORF, SMTPSERVERPORTNORF, MAILSERVERTIMEOUTVALRF, BACKUPSENDDIVCDRF, BACKUPFORMALRF, MAILSENDDIVUNITCNTRF, FILEPATHNMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @MAILSENDMNGNO, @MAILADDRESS, @DIALUPCODE, @DIALUPCONNECTNAME, @DIALUPLOGINNAME, @DIALUPPASSWORD, @ACCESSTELNO, @POP3USERID, @POP3PASSWORD, @POP3SERVERNAME, @SMTPSERVERNAME, @SMTPUSERID, @SMTPPASSWORD, @SMTPAUTHUSEDIV, @SENDERNAME, @POPBEFORESMTPUSEDIV, @POPSERVERPORTNO, @SMTPSERVERPORTNO, @MAILSERVERTIMEOUTVAL, @BACKUPSENDDIVCD, @BACKUPFORMAL, @MAILSENDDIVUNITCNT, @FILEPATHNM)";
					    //登録ヘッダ情報を設定
					    object obj = (object)this;
					    IFileHeader flhd = (IFileHeader)mailInfoSettingWork;
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
                    SqlParameter paraAccessTelNo = sqlCommand.Parameters.Add("@ACCESSTELNO", SqlDbType.NVarChar);
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
                    SqlParameter paraFilePathNm = sqlCommand.Parameters.Add("@FILEPATHNM", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailInfoSettingWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailInfoSettingWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(mailInfoSettingWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);
                    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
                    paraMailAddress.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.MailAddress);
                    paraDialUpCode.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.DialUpCode);
                    paraDialUpConnectName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.DialUpConnectName);
                    paraDialUpLoginName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.DialUpLoginName);
                    paraDialUpPassword.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.DialUpPassword);
                    paraAccessTelNo.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.AccessTelNo);
                    paraPop3UserId.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.Pop3UserId);
                    paraPop3Password.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.Pop3Password);
                    paraPop3ServerName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.Pop3ServerName);
                    paraSmtpServerName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SmtpServerName);
                    paraSmtpUserId.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SmtpUserId);
                    paraSmtpPassword.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SmtpPassword);
                    paraSmtpAuthUseDiv.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.SmtpAuthUseDiv);
                    paraSenderName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SenderName);
                    paraPopBeforeSmtpUseDiv.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.PopBeforeSmtpUseDiv);
                    paraPopServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.PopServerPortNo);
                    paraSmtpServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.SmtpServerPortNo);
                    paraMailServerTimeoutVal.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailServerTimeoutVal);
                    paraBackupSendDivCd.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.BackupSendDivCd);
                    paraBackupFormal.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.BackupFormal);
                    paraMailSendDivUnitCnt.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendDivUnitCnt);
                    paraFilePathNm.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.FilePathNm);
                    #endregion

				    sqlCommand.ExecuteNonQuery();

				    // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				    parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

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
                base.WriteErrorLog(ex,"MailInfoSettingDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }
        # endregion

        #region -- 削除･復活処理 --
        /// <summary>
		/// メール情報設定マスタを論理削除します
		/// </summary>
        /// <param name="parabyte">MailInfoSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール情報設定マスタを論理削除します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteMailInfoSettingProc(ref parabyte, 0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 論理削除メール情報設定マスタを復活します
		/// </summary>
		/// <param name="parabyte">MailInfoSettingWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除メール情報設定マスタを復活します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteMailInfoSettingProc(ref parabyte, 1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// メール情報設定マスタの論理削除を操作します
		/// </summary>
        /// <param name="parabyte">MailInfoSettingWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール情報設定マスタの論理削除を操作します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
        private int LogicalDeleteMailInfoSettingProc(ref byte[] parabyte, int procMode)
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
                    MailInfoSettingWork mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

				    myReader = sqlCommand.ExecuteReader();
				    if(myReader.Read())
				    {
					    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					    if (_updateDateTime != mailInfoSettingWork.UpdateDateTime)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }
					    //現在の論理削除区分を取得
					    logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE MAILINFOSETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
					    //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

					    //更新ヘッダ情報を設定
					    object obj = (object)this;
					    IFileHeader flhd = (IFileHeader)mailInfoSettingWork;
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
					    if (logicalDelCd == 3)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }
                        else if (logicalDelCd == 0)
                        {
                            mailInfoSettingWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        }
                        else
                        {
                            mailInfoSettingWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
				    }
				    else
				    {
                        if (logicalDelCd == 1)
                        {
                            mailInfoSettingWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
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
				    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailInfoSettingWork.UpdateDateTime);
				    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdEmployeeCode);
				    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId1);
				    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId2);
				    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.LogicalDeleteCode);

				    sqlCommand.ExecuteNonQuery();

				    // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				    parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

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
                base.WriteErrorLog(ex,"MailInfoSettingDB.LogicalDeleteMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// メール情報設定マスタを物理削除します
		/// </summary>
		/// <param name="parabyte">メール情報設定マスタオブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : メール情報設定マスタを物理削除します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
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
                    MailInfoSettingWork mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

				    myReader = sqlCommand.ExecuteReader();
				    if(myReader.Read())
				    {
					    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					    if (_updateDateTime != mailInfoSettingWork.UpdateDateTime)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }

                        sqlCommand.CommandText = "DELETE FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
					    //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);
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
                base.WriteErrorLog(ex,"MailInfoSettingDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /// <summary>
        /// メール情報設定マスタクラス格納処理 Reader → MailInfoSettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MailInfoSettingWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private MailInfoSettingWork CopyToMailInfoSettingWorkFromReader(ref SqlDataReader myReader)
        {
            MailInfoSettingWork wkMailInfoSettingWork = new MailInfoSettingWork();

            #region クラスへ格納
            wkMailInfoSettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMailInfoSettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMailInfoSettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMailInfoSettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMailInfoSettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMailInfoSettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMailInfoSettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMailInfoSettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkMailInfoSettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkMailInfoSettingWork.MailSendMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDMNGNORF"));
            wkMailInfoSettingWork.MailAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESSRF"));
            wkMailInfoSettingWork.DialUpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIALUPCODERF"));
            wkMailInfoSettingWork.DialUpConnectName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPCONNECTNAMERF"));
            wkMailInfoSettingWork.DialUpLoginName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPLOGINNAMERF"));
            wkMailInfoSettingWork.DialUpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPPASSWORDRF"));
            wkMailInfoSettingWork.AccessTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCESSTELNORF"));
            wkMailInfoSettingWork.Pop3UserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3USERIDRF"));
            wkMailInfoSettingWork.Pop3Password = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3PASSWORDRF"));
            wkMailInfoSettingWork.Pop3ServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3SERVERNAMERF"));
            wkMailInfoSettingWork.SmtpServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPSERVERNAMERF"));
            wkMailInfoSettingWork.SmtpUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPUSERIDRF"));
            wkMailInfoSettingWork.SmtpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPPASSWORDRF"));
            wkMailInfoSettingWork.SmtpAuthUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPAUTHUSEDIVRF"));
            wkMailInfoSettingWork.SenderName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDERNAMERF"));
            wkMailInfoSettingWork.PopBeforeSmtpUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPBEFORESMTPUSEDIVRF"));
            wkMailInfoSettingWork.PopServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPSERVERPORTNORF"));
            wkMailInfoSettingWork.SmtpServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPSERVERPORTNORF"));
            wkMailInfoSettingWork.MailServerTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSERVERTIMEOUTVALRF"));
            wkMailInfoSettingWork.BackupSendDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPSENDDIVCDRF"));
            wkMailInfoSettingWork.BackupFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPFORMALRF"));
            wkMailInfoSettingWork.MailSendDivUnitCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDDIVUNITCNTRF"));
            wkMailInfoSettingWork.FilePathNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEPATHNMRF"));
            #endregion

            return wkMailInfoSettingWork;
        }
        #endregion
    }
}

