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
	/// 従業員DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 従業員の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 96137　山田　圭</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note:</br>
	/// <br>20050705 yamada  カスタムシリアライズ対応 </br>
    /// <br></br>
    /// <br>Update Note: 従業員別目標値リモートを使用しない（SFANL09084R O,D）</br>
    /// <br>           : 2007.05.31 久保田 Readメソッドで論理削除ﾃﾞｰﾀはNotFoundを戻す（従業員ログイン用）</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: 20081  疋田 勇人</br>
    /// <br>Date       : 2008.05.29</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
	/// <br>Update Note: 2012.05.29 30182 立谷　亮介</br>
	/// <br>           :  「売上伝票入力起動枚数」「得意先電子元帳起動枚数」項目追加</br>
	/// </remarks>
	[Serializable]
    public class EmployeeDB : RemoteDB, IEmployeeDB, IGetSyncdataList
	{
		/// <summary>
		/// 従業員DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 96137　山田　圭</br>
		/// <br>Date       : 2005.03.17</br>
		/// </remarks>
		public EmployeeDB() : base("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork", "EMPLOYEERF")
		{
			//コネクション文字列取得対応↓↓↓↓↓
			//※注意：コンストラクタでコネクション文字列を取得しない
		}

		/// <summary>
		/// 指定された企業コードの従業員LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:EmployeeWorkクラス：企業コード)</param>	
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			try
			{
                // XMLの読み込み
                EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));

                int status = SearchCntProc(out retCnt, employeeWork, readMode, logicalMode);

                return status;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.SearchCnt Exception = "+ex.Message);
				retCnt = 0;
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

        /// <summary>
        /// 指定された企業コードの従業員LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="paraobj">検索パラメータ(readMode=0:EmployeeWorkクラス：企業コード)</param>	
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int SearchCnt(out int retCnt, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                EmployeeWork employeeWork = paraobj as EmployeeWork;

                return SearchCntProc(out retCnt, employeeWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.SearchCnt Exception = " + ex.Message);
                retCnt = 0;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }
        
        /// <summary>
		/// 指定された企業コードの従業員LISTの件数を戻します
		/// </summary>
        /// <param name="retCnt">検索結果</param>
        /// <param name="employeeWork">検索パラメータ(readMode=0:EmployeeWorkクラス：企業コード)</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
        private int SearchCntProc(out int retCnt, EmployeeWork employeeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;

            string sqlTxt = string.Empty; // 2008.05.29 add

			retCnt = 0;

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

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.29 upd start ------------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end --------------------------------------------<<
                    
                    //論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.29 upd start ------------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end --------------------------------------------<<
                    //論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
                    // 2008.05.29 upd start ------------------------------------------>>
                    //sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end --------------------------------------------<<
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

				//データリード
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// 指定された企業コードの従業員LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="employeeWork">検索結果</param>
		/// <param name="paraemployeeWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		public int Search(out object employeeWork,object paraemployeeWork, int readMode,ConstantManagement.LogicalMode logicalMode)
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		{	
			try
			{
				bool nextData;
				int retTotalCnt;
				////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
				return SearchProc(out employeeWork,out retTotalCnt,out nextData,paraemployeeWork ,readMode,logicalMode,0);
				////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Search Exception = "+ex.Message);
				employeeWork = new ArrayList();
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// 指定された企業コードの従業員LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="employeeWork">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraemployeeWork">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
//		{		
//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
//		}
		public int SearchSpecification(out object employeeWork,out int retTotalCnt,out bool nextData,object paraemployeeWork,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{	
			try
			{
				return SearchProc(out employeeWork,out retTotalCnt,out nextData,paraemployeeWork, readMode,logicalMode,readCnt);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.SearchSpecification Exception = "+ex.Message);
				employeeWork = new ArrayList();
				nextData = false;
				retTotalCnt = 0;
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 指定された企業コードの従業員LISTを全て戻します
		/// </summary>
		/// <param name="objemployeeWork">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraemployeeWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		private int SearchProc(out object objemployeeWork,out int retTotalCnt,out bool nextData,object paraemployeeWork, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommandCount = null;
			SqlCommand sqlCommand = null;

			EmployeeWork employeeWork = new EmployeeWork();
			employeeWork = null;

////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//			retbyte = null;
			objemployeeWork = null;
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			//総件数を0で初期化
			retTotalCnt = 0;

			//件数指定リードの場合には指定件数＋１件リードする
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//次レコード無しで初期化
			nextData = false;
            string sqlTxt = string.Empty; // 2008.05.29 add

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

////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//				// XMLの読み込み
//				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
				ArrayList employeeWorkList = paraemployeeWork as ArrayList;
				if(employeeWorkList == null)
				{
					employeeWork = paraemployeeWork as EmployeeWork;
				}
				else
				{	
					if(employeeWorkList.Count > 0)
						employeeWork = employeeWorkList[0] as EmployeeWork;
				}
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得
				if ((readCnt > 0)&&((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == "")))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                        //論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
								(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                        //論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

                sqlTxt = string.Empty; // 2008.05.29 add

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
						// -- Add St 2012.05.29 30182 R.Tachiya --
						sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
						sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                    }
					else
					{
						//一件目リードの場合
						if ((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == ""))
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            //sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                        }
							//Nextリードの場合
						else
						{
                            // 2008.05.29 upd start ------------------------------>>
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
							paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
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
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
						// -- Add St 2012.05.29 30182 R.Tachiya --
						sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
						sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                    }
					else
					{
						//一件目リードの場合
						if ((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == ""))
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                        }
							//Nextリードの場合
						else
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
							paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
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
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
						// -- Add St 2012.05.29 30182 R.Tachiya --
						sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
						sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                    }
					else
					{
						//一件目リードの場合
						if ((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == ""))
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                        }
						else
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                            SqlParameter paraEmployeeCode2 = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
							paraEmployeeCode2.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

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
					EmployeeWork wkEmployeeWork = new EmployeeWork();

					wkEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EMPLOYEECODERF"));
					wkEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NAMERF"));
					wkEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("KANARF"));
					wkEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SHORTNAMERF"));
					wkEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SEXCODERF"));
					wkEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SEXNAMERF"));
					wkEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("BIRTHDAYRF"));
					wkEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("COMPANYTELNORF"));
					wkEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("PORTABLETELNORF"));
					wkEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("POSTCODERF"));
					wkEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BUSINESSCODERF"));
					wkEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRONTMECHACODERF"));
					wkEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
					wkEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BELONGSECTIONCODERF"));
					wkEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTGENERALRF"));
					wkEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
					wkEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
					wkEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
					wkEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINIDRF"));
					wkEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINPASSWORDRF"));
					wkEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERADMINFLAGRF"));
					wkEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ENTERCOMPANYDATERF"));
					wkEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RETIREMENTDATERF"));
                    // add 2007.05.23 saito >>>>>>>>>>
                    wkEmployeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    wkEmployeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // add 2007.05.23 saito <<<<<<<<<<
					// -- Add St 2012.05.29 30182 R.Tachiya --
					wkEmployeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
					wkEmployeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
					// -- Add Ed 2012.05.29 30182 R.Tachiya --

                    al.Add(wkEmployeeWork); 

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//			// XMLへ変換し、文字列のバイナリ化
//			EmployeeWork[] EmployeeWorks = (EmployeeWork[])al.ToArray(typeof(EmployeeWork));
//			retbyte = XmlByteSerializer.Serialize(EmployeeWorks);
			objemployeeWork = al;
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return status;

		}

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
		/// <param name="parabyte">EmployeeWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		public int Read(ref byte[] parabyte , int readMode)
		{
			try
			{
				EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));

				int status = ReadProc(ref employeeWork,readMode);
				// XMLへ変換し、文字列のバイナリ化
				parabyte = XmlByteSerializer.Serialize(employeeWork);

				return status;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
		/// <param name="parabyte">EmployeeWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		public int Read(ref object parabyte , int readMode)
		{
			try
			{
				EmployeeWork employeeWork = parabyte as EmployeeWork;

				return ReadProc(ref employeeWork,readMode);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
		/// <param name="parabyte">EmployeeWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		public int Read(ref EmployeeWork parabyte , int readMode)
		{
			try
			{
				return ReadProc(ref parabyte,readMode);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
		/// <param name="employeeWork">EmployeeWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		private int ReadProc(ref EmployeeWork employeeWork, int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

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

                // 2008.05.29 upd start -------------------------------->>
				//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE " ,sqlConnection);
                string sqlTxt = string.Empty; 
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
				// -- Add St 2012.05.29 30182 R.Tachiya --
				sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
				sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --
				sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ----------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
								
				//ログインＩＤが入っていたら
				if(employeeWork.LoginId != "")
				{
					sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
					SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
					findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
				}
				else
				{
					sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
					SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				}

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EMPLOYEECODERF"));
					employeeWork.Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NAMERF"));
					employeeWork.Kana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("KANARF"));
					employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SHORTNAMERF"));
					employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SEXCODERF"));
					employeeWork.SexName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SEXNAMERF"));
					employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("BIRTHDAYRF"));
					employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("COMPANYTELNORF"));
					employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("PORTABLETELNORF"));
					employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("POSTCODERF"));
					employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BUSINESSCODERF"));
					employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRONTMECHACODERF"));
					employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
					employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BELONGSECTIONCODERF"));
					employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTGENERALRF"));
					employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
					employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
					employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
					employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINIDRF"));
					employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINPASSWORDRF"));
					employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERADMINFLAGRF"));
					employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ENTERCOMPANYDATERF"));
					employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RETIREMENTDATERF"));
                    // add 2007.05.23 saitoh >>>>>>>>>>
                    employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // add 2007.05.23 saitoh <<<<<<<<<<
					// -- Add St 2012.05.29 30182 R.Tachiya --
					employeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
					employeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
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

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
		/// <param name="employeeWork">EmployeeWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="sqlConnection">コネクション情報</param>
		/// <returns>STATUS</returns>
		public int Read(ref EmployeeWork employeeWork, int readMode , ref SqlConnection sqlConnection)
		{
            return this.ReadProc(ref employeeWork, readMode, ref sqlConnection);
        }
        /// <summary>
        /// 指定された従業員Guidの従業員を戻します
        /// </summary>
        /// <param name="employeeWork">EmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref EmployeeWork employeeWork, int readMode, ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;

			try 
			{
                // 2008.05.29 upd start -------------------------------->>
				//SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE " ,sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
				// -- Add St 2012.05.29 30182 R.Tachiya --
				sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
				sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --
				sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ----------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
								
				//ログインＩＤが入っていたら
				if(employeeWork.LoginId != "")
				{
					sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
					SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
					findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
				}
				else
				{
					sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
					SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				}

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
                    if (employeeWork.LogicalDeleteCode == SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF")))//2007.05.31 add 久保田
                    {
                        employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        employeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                        employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                        employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                        employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                        employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                        employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                        employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                        employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                        employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                        employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                        employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                        employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                        employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                        employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                        employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                        employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                        employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                        employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                        employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                        employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                        employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                        employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
						// -- Add St 2012.05.29 30182 R.Tachiya --
						employeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
						employeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
						// -- Add Ed 2012.05.29 30182 R.Tachiya --

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();

			return status;
		}

		/// <summary>
		/// 複数件数指定された企業コード、従業員コードの従業員情報を戻します
		/// </summary>
		/// <param name="retList">検索結果List</param>
		/// <param name="paraList">検索条件List</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		public int ReadList(out ArrayList retList, ArrayList paraList , int readMode)
		{
            return this.ReadListProc(out retList, paraList, readMode);

        }
        /// <summary>
        /// 複数件数指定された企業コード、従業員コードの従業員情報を戻します
        /// </summary>
        /// <param name="retList">検索結果List</param>
        /// <param name="paraList">検索条件List</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        private int ReadListProc(out ArrayList retList, ArrayList paraList, int readMode)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			EmployeeWork employeeWork = null;
			retList = new ArrayList();
			ArrayList al = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.29 add

			try 
			{		
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				foreach(EmployeeWork item in paraList)
				{
                    // 2008.05.29 upd start -------------------------------->>
                    //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                    //    + "AND EMPLOYEECODERF=@FINDEMPLOYEECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMERF" + Environment.NewLine;
                    sqlTxt += "    ,KANARF" + Environment.NewLine;
                    sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                    sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                    sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                    sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                    sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                    sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
					sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    sqlTxt = string.Empty;
                    // 2008.05.29 upd end ----------------------------------<< 
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

					//Parameterオブジェクトへ値設定
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);								
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						employeeWork = new EmployeeWork();
						employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EMPLOYEECODERF"));
						employeeWork.Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NAMERF"));
						employeeWork.Kana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("KANARF"));
						employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SHORTNAMERF"));
						employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SEXCODERF"));
						employeeWork.SexName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SEXNAMERF"));
						employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("BIRTHDAYRF"));
						employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("COMPANYTELNORF"));
						employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("PORTABLETELNORF"));
						employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("POSTCODERF"));
						employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BUSINESSCODERF"));
						employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRONTMECHACODERF"));
						employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
						employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BELONGSECTIONCODERF"));
						employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTGENERALRF"));
						employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
						employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
						employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
						employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINIDRF"));
						employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINPASSWORDRF"));
						employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERADMINFLAGRF"));
						employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ENTERCOMPANYDATERF"));
						employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RETIREMENTDATERF"));
                        // add 2007.05.17 saitoh >>>>>>>>>>
                        employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                        employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                        // add 2007.05.17 saitoh <<<<<<<<<<
						// -- Add St 2012.05.29 30182 R.Tachiya --
						employeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
						employeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						al.Add(employeeWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					if(myReader.IsClosed == false)myReader.Close();
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.ReadList Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			retList = al;
			return status;
		}

		/// <summary>
		/// 従業員情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">EmployeeWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			EmployeeWork employeeWork = null;

			try
			{
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));

				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQLコネクションオブジェクト作成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				//トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				status = Write(ref employeeWork, ref sqlConnection, ref sqlTransaction);
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
				// ●コネクション破棄
				if (sqlConnection.State == ConnectionState.Open) 
				{
					if(sqlTransaction.Connection != null)
					{
						// ●コミットorロールバック
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							sqlTransaction.Commit();
						else
							sqlTransaction.Rollback();
					}
					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}
			parabyte = XmlByteSerializer.Serialize(employeeWork);

			return status;
		}

        /// <summary>
        /// 従業員情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">EmployeeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        public int Write(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            EmployeeWork employeeWork = null;

            try
            {
                employeeWork = paraobj as EmployeeWork;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQLコネクションオブジェクト作成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = Write(ref employeeWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ●コネクション破棄
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        // ●コミットorロールバック
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            sqlTransaction.Commit();
                        else
                            sqlTransaction.Rollback();
                    }
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                }
            }

            return status;
        }
        
        /// <summary>
		/// 従業員情報を論理削除します
		/// </summary>
		/// <param name="parabyte">EmployeeWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			EmployeeWork employeeWork = null;

			try 
			{
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
				//コネクション文字列取得対応↓↓↓↓↓
				//※各publicメソッドの開始時にコネクション文字列を取得
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
				status = LogicalDelete(ref employeeWork, 0, ref sqlConnection, ref sqlTransaction);

                // del 2007.05.18 Saitoh >>>>>>>>>>
				//if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//{								  
				//	EmplTargetDB emplTargetDB = new EmplTargetDB();
				//	EmplTargetWork emplTargetWork = new EmplTargetWork();

				//	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
				//	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;

				//	status = emplTargetDB.LogicalDeleteProc(emplTargetWork, 0, ref sqlConnection, ref sqlTransaction);
				//}
                // del 2007.05.18 Saitoh <<<<<<<<<<
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.LogicalDelete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
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
				}
			}

			parabyte = XmlByteSerializer.Serialize(employeeWork);
			return status;
		}

        /// <summary>
        /// 従業員情報を論理削除します
        /// </summary>
        /// <param name="paraobj">EmployeeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        public int LogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            EmployeeWork employeeWork = null;

            try
            {
                employeeWork = paraobj as EmployeeWork;
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = LogicalDelete(ref employeeWork, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.LogicalDelete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
                }
            }

            return status;
        }
        
        /// <summary>
		/// 論理削除従業員情報を復活します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			EmployeeWork employeeWork = null;
			try 
			{
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
				//コネクション文字列取得対応↓↓↓↓↓
				//※各publicメソッドの開始時にコネクション文字列を取得
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
				status = LogicalDelete(ref employeeWork, 1, ref sqlConnection, ref sqlTransaction);

                // del 2007.05.18 Saitoh >>>>>>>>>>
				//if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//{								  
				//	EmplTargetDB emplTargetDB = new EmplTargetDB();
				//	EmplTargetWork emplTargetWork = new EmplTargetWork();

				//	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
				//	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;
				//	status = emplTargetDB.LogicalDeleteProc(emplTargetWork, 1, ref sqlConnection, ref sqlTransaction);
				//}
                // del 2007.05.18 Saitoh <<<<<<<<<<
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.LogicalDelete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
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
				}
			}
			parabyte = XmlByteSerializer.Serialize(employeeWork);
			return status;
		}

        /// <summary>
        /// 論理削除従業員情報を復活します
        /// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            EmployeeWork employeeWork = null;
            try
            {
                employeeWork = paraobj as EmployeeWork;
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = LogicalDelete(ref employeeWork, 1, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.LogicalDelete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
                }
            }
            return status;
        }
        
        /// <summary>
		/// 従業員情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">EmployeeWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			EmployeeWork employeeWork = null;

			try 
			{
				// XMLの読み込み
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
				//コネクション文字列取得対応↓↓↓↓↓
				//※各publicメソッドの開始時にコネクション文字列を取得
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//コネクション文字列取得対応↑↑↑↑↑

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.29 upd start ------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ---------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.29 upd start ------------------------------->>
					//sqlCommand.CommandText = "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end ---------------------------------<<
                    //KEYコマンドを再設定
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

					//コネクション文字列取得対応↓↓↓↓↓
					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
					//コネクション文字列取得対応↑↑↑↑↑
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
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
						sqlCommand.Cancel();
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	employeeWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						employeeWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	employeeWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						sqlCommand.Cancel();
						myReader.Close();
						sqlConnection.Close();
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
				paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
				paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
				paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
				paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
				paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(employeeWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
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

		/// <summary>
		/// 従業員情報を登録、更新します
		/// </summary>
		/// <param name="employeeWork">employeeWork</param>
		/// <param name="sqlConnection">Sql接続情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 従業員情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2006.02.04</br>
		private int Write(ref EmployeeWork employeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                // 2008.05.29 upd start ------------------------------------------------>>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE (ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE) OR (ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGINIDRF=@FINDLOGINID)", sqlConnection, sqlTransaction);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE" + Environment.NewLine;
                sqlTxt += "    (ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "        AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlTxt += "    )" + Environment.NewLine;
                sqlTxt += "    OR" + Environment.NewLine;
                sqlTxt += "    (ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "        AND LOGINIDRF=@FINDLOGINID" + Environment.NewLine;
                sqlTxt += "    )" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.29 upd end --------------------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (employeeWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}
                    // 2008.05.29 upd start ------------------------------------------------>>
                    //sqlCommand.CommandText = "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , EMPLOYEECODERF=@EMPLOYEECODE , NAMERF=@NAME , KANARF=@KANA , SHORTNAMERF=@SHORTNAME , SEXCODERF=@SEXCODE , SEXNAMERF=@SEXNAME , BIRTHDAYRF=@BIRTHDAY , COMPANYTELNORF=@COMPANYTELNO , PORTABLETELNORF=@PORTABLETELNO , POSTCODERF=@POSTCODE , BUSINESSCODERF=@BUSINESSCODE , FRONTMECHACODERF=@FRONTMECHACODE , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE , BELONGSECTIONCODERF=@BELONGSECTIONCODE , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR , LOGINIDRF=@LOGINID , LOGINPASSWORDRF=@LOGINPASSWORD , USERADMINFLAGRF=@USERADMINFLAG , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE , RETIREMENTDATERF=@RETIREMENTDATE , AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1 , AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , NAMERF=@NAME" + Environment.NewLine;
                    sqlTxt += " , KANARF=@KANA" + Environment.NewLine;
                    sqlTxt += " , SHORTNAMERF=@SHORTNAME" + Environment.NewLine;
                    sqlTxt += " , SEXCODERF=@SEXCODE" + Environment.NewLine;
                    sqlTxt += " , SEXNAMERF=@SEXNAME" + Environment.NewLine;
                    sqlTxt += " , BIRTHDAYRF=@BIRTHDAY" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELNORF=@COMPANYTELNO" + Environment.NewLine;
                    sqlTxt += " , PORTABLETELNORF=@PORTABLETELNO" + Environment.NewLine;
                    sqlTxt += " , POSTCODERF=@POSTCODE" + Environment.NewLine;
                    sqlTxt += " , BUSINESSCODERF=@BUSINESSCODE" + Environment.NewLine;
                    sqlTxt += " , FRONTMECHACODERF=@FRONTMECHACODE" + Environment.NewLine;
                    sqlTxt += " , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                    sqlTxt += " , BELONGSECTIONCODERF=@BELONGSECTIONCODE" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                    sqlTxt += " , LOGINIDRF=@LOGINID" + Environment.NewLine;
                    sqlTxt += " , LOGINPASSWORDRF=@LOGINPASSWORD" + Environment.NewLine;
                    sqlTxt += " , USERADMINFLAGRF=@USERADMINFLAG" + Environment.NewLine;
                    sqlTxt += " , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE" + Environment.NewLine;
                    sqlTxt += " , RETIREMENTDATERF=@RETIREMENTDATE" + Environment.NewLine;
                    sqlTxt += " , AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1" + Environment.NewLine;
                    sqlTxt += " , AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += " , SALSLIPINPBOOTCNTRF=@SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += " , CUSTLEDGERBOOTCNTRF=@CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
					sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end --------------------------------------------------<<
                    //KEYコマンドを再設定
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

					//コネクション文字列取得対応↓↓↓↓↓
					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
					//コネクション文字列取得対応↑↑↑↑↑
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (employeeWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						myReader.Close();
						return status;
					}

					//新規作成時のSQL文を生成
                    // 2008.05.29 upd start ------------------------------------------------>>
                    //sqlCommand.CommandText = "INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF, AUTHORITYLEVEL1RF, AUTHORITYLEVEL2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE, @AUTHORITYLEVEL1, @AUTHORITYLEVEL2)";
                    sqlTxt = string.Empty;
                    sqlTxt += "INSERT INTO EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMERF" + Environment.NewLine;
                    sqlTxt += "    ,KANARF" + Environment.NewLine;
                    sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                    sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                    sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                    sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                    sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                    sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
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
                    sqlTxt += "    ,@EMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "    ,@NAME" + Environment.NewLine;
                    sqlTxt += "    ,@KANA" + Environment.NewLine;
                    sqlTxt += "    ,@SHORTNAME" + Environment.NewLine;
                    sqlTxt += "    ,@SEXCODE" + Environment.NewLine;
                    sqlTxt += "    ,@SEXNAME" + Environment.NewLine;
                    sqlTxt += "    ,@BIRTHDAY" + Environment.NewLine;
                    sqlTxt += "    ,@COMPANYTELNO" + Environment.NewLine;
                    sqlTxt += "    ,@PORTABLETELNO" + Environment.NewLine;
                    sqlTxt += "    ,@POSTCODE" + Environment.NewLine;
                    sqlTxt += "    ,@BUSINESSCODE" + Environment.NewLine;
                    sqlTxt += "    ,@FRONTMECHACODE" + Environment.NewLine;
                    sqlTxt += "    ,@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                    sqlTxt += "    ,@BELONGSECTIONCODE" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTGENERAL" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTCARINSPECT" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTBODYPAINT" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                    sqlTxt += "    ,@LOGINID" + Environment.NewLine;
                    sqlTxt += "    ,@LOGINPASSWORD" + Environment.NewLine;
                    sqlTxt += "    ,@USERADMINFLAG" + Environment.NewLine;
                    sqlTxt += "    ,@ENTERCOMPANYDATE" + Environment.NewLine;
                    sqlTxt += "    ,@RETIREMENTDATE" + Environment.NewLine;
                    sqlTxt += "    ,@AUTHORITYLEVEL1" + Environment.NewLine;
                    sqlTxt += "    ,@AUTHORITYLEVEL2" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += "    ,@SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += "    ,@CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
                    sqlTxt += " )" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end --------------------------------------------------<<

                    //コネクション文字列取得対応↓↓↓↓↓
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
					//コネクション文字列取得対応↑↑↑↑↑
				}
				myReader.Close();

				//Prameterオブジェクトの作成
				SqlParameter paraCreatedatetime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterprisecode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileheaderguid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraEmployeecode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
				SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
				SqlParameter paraShortname = sqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.NVarChar);
				SqlParameter paraSexcode = sqlCommand.Parameters.Add("@SEXCODE", SqlDbType.Int);
				SqlParameter paraSexname = sqlCommand.Parameters.Add("@SEXNAME", SqlDbType.NVarChar);
				SqlParameter paraBirthday = sqlCommand.Parameters.Add("@BIRTHDAY", SqlDbType.Int);
				SqlParameter paraCompanytelno = sqlCommand.Parameters.Add("@COMPANYTELNO", SqlDbType.NVarChar);
				SqlParameter paraPortabletelno = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
				SqlParameter paraPostcode = sqlCommand.Parameters.Add("@POSTCODE", SqlDbType.Int);
				SqlParameter paraBusinesscode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
				SqlParameter paraFrontmechacode = sqlCommand.Parameters.Add("@FRONTMECHACODE", SqlDbType.Int);
				SqlParameter paraInoutsidecompanycode = sqlCommand.Parameters.Add("@INOUTSIDECOMPANYCODE", SqlDbType.Int);
				SqlParameter paraBelongsectioncode = sqlCommand.Parameters.Add("@BELONGSECTIONCODE", SqlDbType.NChar);
				SqlParameter paraLvrRtCstGeneral = sqlCommand.Parameters.Add("@LVRRTCSTGENERAL", SqlDbType.BigInt);
				SqlParameter paraLvrRtCstCarInspect = sqlCommand.Parameters.Add("@LVRRTCSTCARINSPECT", SqlDbType.BigInt);
				SqlParameter paraLvrRtCstBodyPaint = sqlCommand.Parameters.Add("@LVRRTCSTBODYPAINT", SqlDbType.BigInt);
				SqlParameter paraLvrRtCstBodyRepair = sqlCommand.Parameters.Add("@LVRRTCSTBODYREPAIR", SqlDbType.BigInt);
				SqlParameter paraLoginid = sqlCommand.Parameters.Add("@LOGINID", SqlDbType.NVarChar);
				SqlParameter paraLoginpassword = sqlCommand.Parameters.Add("@LOGINPASSWORD", SqlDbType.NVarChar);
				SqlParameter paraUserAdminFlag = sqlCommand.Parameters.Add("@USERADMINFLAG", SqlDbType.Int);
				SqlParameter paraEntercompanydate = sqlCommand.Parameters.Add("@ENTERCOMPANYDATE", SqlDbType.Int);
				SqlParameter paraRetirementdate = sqlCommand.Parameters.Add("@RETIREMENTDATE", SqlDbType.Int);
                // add 2007.05.23 saitoh >>>>>>>>>>
                SqlParameter paraAuthorityLevel1 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL1", SqlDbType.Int);
                SqlParameter paraAuthorityLevel2 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL2", SqlDbType.Int);
                // add 2007.05.23 saitoh <<<<<<<<<<
				// -- Add St 2012.05.29 30182 R.Tachiya --
				SqlParameter paraSalSlipInpBootCnt = sqlCommand.Parameters.Add("@SALSLIPINPBOOTCNTRF", SqlDbType.Int);
				SqlParameter paraCustLedgerBootCnt = sqlCommand.Parameters.Add("@CUSTLEDGERBOOTCNTRF", SqlDbType.Int);
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

                //Parameterオブジェクトへ値設定
				paraCreatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.CreateDateTime);
				paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
				paraEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				paraFileheaderguid.Value = SqlDataMediator.SqlSetGuid(employeeWork.FileHeaderGuid);
				paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
				paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
				paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
				paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);
				paraEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				paraName.Value = SqlDataMediator.SqlSetString(employeeWork.Name);
				paraKana.Value = SqlDataMediator.SqlSetString(employeeWork.Kana);
				paraShortname.Value = SqlDataMediator.SqlSetString(employeeWork.ShortName);
				paraSexcode.Value = SqlDataMediator.SqlSetInt32(employeeWork.SexCode);
				paraSexname.Value = SqlDataMediator.SqlSetString(employeeWork.SexName);
				paraBirthday.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.Birthday);
				paraCompanytelno.Value = SqlDataMediator.SqlSetString(employeeWork.CompanyTelNo);
				paraPortabletelno.Value = SqlDataMediator.SqlSetString(employeeWork.PortableTelNo);
				paraPostcode.Value = SqlDataMediator.SqlSetInt32(employeeWork.PostCode);
				paraBusinesscode.Value = SqlDataMediator.SqlSetInt32(employeeWork.BusinessCode);
				paraFrontmechacode.Value = SqlDataMediator.SqlSetInt32(employeeWork.FrontMechaCode);
				paraInoutsidecompanycode.Value = SqlDataMediator.SqlSetInt32(employeeWork.InOutsideCompanyCode);
				paraBelongsectioncode.Value = SqlDataMediator.SqlSetString(employeeWork.BelongSectionCode);
				paraLvrRtCstGeneral.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstGeneral);
				paraLvrRtCstCarInspect.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstCarInspect);
				paraLvrRtCstBodyPaint.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstBodyPaint);
				paraLvrRtCstBodyRepair.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstBodyRepair);
				paraLoginid.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
				paraLoginpassword.Value = SqlDataMediator.SqlSetString(employeeWork.LoginPassword);
				paraUserAdminFlag.Value = SqlDataMediator.SqlSetInt32(employeeWork.UserAdminFlag);
				paraEntercompanydate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.EnterCompanyDate);
				paraRetirementdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.RetirementDate);
                // add 2007.05.23 saitoh >>>>>>>>>>
                paraAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(employeeWork.AuthorityLevel1);
                paraAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(employeeWork.AuthorityLevel2);
                // add 2007.05.23 saitoh <<<<<<<<<<
				// -- Add St 2012.05.29 30182 R.Tachiya --
				paraSalSlipInpBootCnt.Value = SqlDataMediator.SqlSetInt32(employeeWork.SalSlipInpBootCnt);
				paraCustLedgerBootCnt.Value = SqlDataMediator.SqlSetInt32(employeeWork.CustLedgerBootCnt);
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Write Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;
		}

		/// <summary>
		/// 従業員・従業員目標実績設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">従業員オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 従業員・従業員目標実績設定情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2006.02.04</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

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
				EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				status = Delete(employeeWork, ref sqlConnection, ref sqlTransaction);
				
                // del 2007.05.18 Saitoh >>>>>>>>>>
                //if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//{
				//	EmplTargetDB emplTargetDB = new EmplTargetDB();
				//	EmplTargetWork emplTargetWork = new EmplTargetWork();
				//	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
				//	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;
					
				//	status = emplTargetDB.Delete(emplTargetWork, ref sqlConnection, ref sqlTransaction);
				//}
                // del 2007.05.18 Saitoh <<<<<<<<<<
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
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
				}
			}

			return status;
		}

        /// <summary>
        /// 従業員・従業員目標実績設定情報を物理削除します
        /// </summary>
        /// <param name="paraobj">従業員オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 従業員・従業員目標実績設定情報を物理削除します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2006.02.04</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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
                EmployeeWork employeeWork = paraobj as EmployeeWork;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = Delete(employeeWork, ref sqlConnection, ref sqlTransaction);

                // del 2007.05.18 Saitoh >>>>>>>>>>
                //if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //	EmplTargetDB emplTargetDB = new EmplTargetDB();
                //	EmplTargetWork emplTargetWork = new EmplTargetWork();
                //	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
                //	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;

                //	status = emplTargetDB.Delete(emplTargetWork, ref sqlConnection, ref sqlTransaction);
                //}
                // del 2007.05.18 Saitoh <<<<<<<<<<
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.Delete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
                }
            }

            return status;
        }
        
        /// <summary>
		/// 従業員情報を物理削除します
		/// </summary>
		/// <param name="employeeWork">EmployeeWork</param>
		/// <param name="sqlConnection">Sql接続情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns></returns>
		/// <br>Note       : 従業員情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2006.02.04</br>
		public int Delete(EmployeeWork employeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
            return this.DeleteProc(employeeWork, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 従業員情報を物理削除します
        /// </summary>
        /// <param name="employeeWork">EmployeeWork</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns></returns>
        /// <br>Note       : 従業員情報を物理削除します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2006.02.04</br>
        private int DeleteProc(EmployeeWork employeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                // 2008.05.29 upd start ---------------------------------->> 
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE",sqlConnection, sqlTransaction);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.29 upd end ------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}

                    // 2008.05.29 upd start ---------------------------------->>
					//sqlCommand.CommandText = "DELETE FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end ------------------------------------<<
                    //KEYコマンドを再設定
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
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
				base.WriteErrorLog(ex,"EmployeeDB.Delete Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;
		}

		/// <summary>
		/// 従業員情報の論理削除を操作します
		/// </summary>
		/// <param name="employeeWork">EmployeeWork</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <param name="sqlConnection">Sql接続情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 従業員情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2006.02.04</br>
		private int LogicalDelete(ref EmployeeWork employeeWork,int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                // 2008.05.29 upd start ---------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection, sqlTransaction);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.29 upd end ------------------------------------<<
				//Prameterオブジェクトの作成
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.29 upd start ---------------------------------->>
					//sqlCommand.CommandText = "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end ------------------------------------<<
                    //KEYコマンドを再設定
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

					//コネクション文字列取得対応↓↓↓↓↓
					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
					//コネクション文字列取得対応↑↑↑↑↑
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
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
						return status;
					}
					else if	(logicalDelCd == 0)	employeeWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						employeeWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	employeeWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						myReader.Close();
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
				paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
				paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
				paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
				paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
				paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
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
        /// <br>Note       : 指定された条件の従業員マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
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
        /// <br>Note       : 指定された条件の従業員マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.29 upd start ------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
				// -- Add St 2012.05.29 30182 R.Tachiya --
				sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
				sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --
				sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end --------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmployeeWorkFromReader(ref myReader));

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
        /// クラス格納処理 Reader → EmployeeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmployeeWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2006.12.06</br>
        /// </remarks>
        private EmployeeWork CopyToEmployeeWorkFromReader(ref SqlDataReader myReader)
        {
            EmployeeWork wkEmployeeWork = new EmployeeWork();

            #region クラスへ格納
            wkEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            wkEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            wkEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
            wkEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
            wkEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
            wkEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
            wkEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
            wkEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
            wkEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
            wkEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
            wkEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
            wkEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
            wkEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
            wkEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
            wkEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
            wkEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
            wkEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
            wkEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
            wkEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
            wkEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
            wkEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
            wkEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
            // add 2007.05.23 saitoh >>>>>>>>>>
            wkEmployeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
            wkEmployeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
            // add 2007.05.23 saitoh <<<<<<<<<<
			// -- Add St 2012.05.29 30182 R.Tachiya --
			wkEmployeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
			wkEmployeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

            #endregion

            return wkEmployeeWork;
        }
        #endregion



	}
}
