using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// 拠点情報設定LCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点情報設定LCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20098　村瀬　勝也</br>
    /// <br>Date       : 2007.04.05</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.01 980081 山田 明友</br>
    /// <br>           : 流通基幹対応(Read・WriteSyncLocalDataメソッド等追加)</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.27 20081 疋田 勇人</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// </remarks>
    public class SectionInfoLcDB
    {
        /// <summary>
        /// 拠点情報設定LCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        /// </remarks>
        public SectionInfoLcDB()
        {
        }


		/// <summary>
		/// 指定された企業コードの拠点情報LISTを全て戻します
		/// </summary>
        /// <param name="searchRetList">検索結果</param>
		/// <param name="secInfoSetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="errorLevel">エラーレベル</param>
		/// <param name="errorCode">エラーコード</param>
		/// <param name="errorMessage">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの拠点情報LISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.08.06</br>
        public int Search(out object searchRetList, object secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage)
		{
			// STATUS初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            searchRetList = null;
			errorLevel = 0;
			errorCode = "";
			errorMessage = "";
            SqlConnection sqlConnection = null; //2006.06.21 kane add
            ArrayList retList = null; //2006.06.21 kane add

			SecInfoSetWork _secInfoSetWork = secInfoSetWork as SecInfoSetWork;
			if(_secInfoSetWork == null)
			{
                WriteErrorLog("プログラムエラー。パラメータが未設定です : SectionInfo.Search");
                return status;
			}

            try
            {
                //2006.06.21 kane add start >>>
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                //コネクション文字列取得対応↑↑↑↑↑

                //SQL文生成
                sqlConnection.Open();
                //2006.06.21 kane add end   <<<

                //status = SearchProc(out SecInfoSetWork, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage);//2006.06.21 kane del
                status = SearchProc(out retList, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage, ref sqlConnection);//2006.06.21 kane add
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SectionInfoLcDB.SearchSecInfoSetProc Exception=" + ex.Message, 0);
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

            searchRetList = retList;//2006.06.21 kane add
			return status;
		}

		/// <summary>
		/// 指定された企業コードの拠点情報LISTを全て戻します
		/// </summary>
		/// <param name="SecInfoSetWork">検索結果</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="SectionCode">拠点コード</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="errorLevel">エラーレベル</param>
		/// <param name="errorCode">エラーコード</param>
		/// <param name="errorMessage">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの拠点情報LISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.08.06</br>
		public int Search(out object SecInfoSetWork, string EnterpriseCode, string SectionCode, int readMode,ConstantManagement.LogicalMode logicalMode,out int errorLevel,out string errorCode,out string errorMessage)
		{
			SecInfoSetWork _secInfoSetWork = new SecInfoSetWork();
			_secInfoSetWork.EnterpriseCode = EnterpriseCode;
			//return SearchProc(out SecInfoSetWork,_secInfoSetWork,readMode,logicalMode,out errorLevel,out errorCode,out errorMessage);//2006.06.21 kane del
            return Search(out SecInfoSetWork, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage);//2006.06.21 kane add
		}

		private int SearchSecInfoSetProc(out ArrayList secInfoSetWorkList, SecInfoSetWork secInfoSetWork, int CtrlFuncCode, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			secInfoSetWorkList = new ArrayList();
			try
			{
				//コネクション文字列取得対応↓↓↓↓↓
				//※各publicメソッドの開始時にコネクション文字列を取得
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                //コネクション文字列取得対応↑↑↑↑↑

				//SQL文生成
				sqlConnection.Open();				

                // 2008.05.27 upd start ------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF " 
                //    +"LEFT JOIN SECCTRLSETRF ON SECINFOSETRF.ENTERPRISECODERF=SECCTRLSETRF.ENTERPRISECODERF "
                //    +"AND SECINFOSETRF.SECTIONCODERF=SECCTRLSETRF.SECTIONCODERF "
                //+" "
                //,sqlConnection);
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
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.27 upd end --------------------------------<<

				//WHERE文の作成
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand,secInfoSetWork,logicalMode);

                //ORDER BYの指定
				sqlCommand.CommandText += "ORDER BY SECINFOSETRF.ENTERPRISECODERF ,SECINFOSETRF.SECTIONCODERF";
				
				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				while(myReader.Read())
				{
					//---拠点情報設定
					SecInfoSetWork wkSecInfoSetWork = CopyToSecInfoSetFromReader(myReader);
					secInfoSetWorkList.Add(wkSecInfoSetWork);

				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch(SqlException ex)
			{
                status = WriteSQLErrorLog(ex, "SectionInfoLcDB.SearchSecInfoSetProc", 0);
            }
			catch(Exception ex)
			{
                WriteErrorLog(ex, "SectionInfoLcDB.SearchSecInfoSetProc Exception=" + ex.Message, 0);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="secInfoSetWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの拠点系情報を全て戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.06.21</br>
        public int Search(out ArrayList retList, SecInfoSetWork secInfoSetWork, ref SqlConnection sqlConnection, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int errorLevel = 0;
            string errorCode = "";
            string errorMessage = "";
            retList = null;
            if (secInfoSetWork == null)
            {
                WriteErrorLog("プログラムエラー。パラメータが未設定です : SectionInfo.Search");
                return status;
            }

            status = SearchProc(out retList, secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage , ref sqlConnection);

            return status;
        }

		/// <summary>
		/// 指定された企業コードの拠点情報LISTを全て戻します
		/// </summary>
		/// <param name="searchRetCSArrayList">検索結果</param>
		/// <param name="secInfoSetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="errorLevel">エラーレベル</param>
		/// <param name="errorCode">エラーコード</param>
		/// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの拠点情報LISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.07.04</br>
        //private int SearchProc(out object searchRetCSArrayList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage)//2006.06.21 kane del
        private int SearchProc(out ArrayList searchRetCSArrayList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage, ref SqlConnection sqlConnection)//2006.06.21 kane add
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			//SqlConnection sqlConnection = null;//2006.06.21 kane del
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;;

			errorLevel		= 0;
			errorCode		= "";
			errorMessage	= "";

			searchRetCSArrayList = null;
			
			//戻り値格納用
			ArrayList arrayList = new ArrayList();

			try 
			{	
                //2006.06.21 kane del start >>>
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑

                ////SQL文生成
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();				
                //2006.06.21 kane del end   <<<
				
				//-------------------
				//結果格納用ArrayList
				//-------------------
				//拠点情報設定
				ArrayList SecInfoSetWorkList = new ArrayList();
				//拠点制御設定
				//ArrayList SecCtrlSetWorkList = new ArrayList(); // 2008.05.27 del
				//自社名称
				ArrayList CompanyNmWorkList = new ArrayList();

				//Select句の生成
				string SelectString = MakeSelectString(secInfoSetWork,0);
				using(sqlCommand = new SqlCommand(SelectString ,sqlConnection))
				{
					//WHERE文の作成
					sqlCommand.CommandText += MakeWhereString(ref sqlCommand,secInfoSetWork,logicalMode);

					//ORDER BYの指定
					//sqlCommand.CommandText += "ORDER BY SECINFOSETRF.ENTERPRISECODERF ,SECINFOSETRF.SECTIONCODERF ,SECCTRLSETRF.CTRLFUNCCODERF"; // 2008.05.27 del
                    sqlCommand.CommandText += "ORDER BY SECINFOSETRF.ENTERPRISECODERF ,SECINFOSETRF.SECTIONCODERF";                                // 2008.05.27 add

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						//---拠点情報設定
						SecInfoSetWork wkSecInfoSetWork = CopyToSecInfoSetFromReader(myReader);
						if(SecInfoSetWorkList.Count <= 0)
							SecInfoSetWorkList.Add(wkSecInfoSetWork);
						else if(wkSecInfoSetWork.SectionCode != ((SecInfoSetWork)SecInfoSetWorkList[SecInfoSetWorkList.Count-1]).SectionCode)
							SecInfoSetWorkList.Add(wkSecInfoSetWork);

                        // 2008.05.27 del start ---------------------------------------->>
						//---拠点制御設定
                        //SecCtrlSetWork wkSecCtrlSetWork = CopyToSecCtrlSetFromReader(myReader);
                        //if(SecCtrlSetWorkList.Count <= 0)
                        //    SecCtrlSetWorkList.Add(wkSecCtrlSetWork);
                        //else if(wkSecCtrlSetWork.CtrlFuncCode != ((SecCtrlSetWork)SecCtrlSetWorkList[SecCtrlSetWorkList.Count-1]).CtrlFuncCode)
                        //    SecCtrlSetWorkList.Add(wkSecCtrlSetWork);
                        // 2008.05.27 del end ------------------------------------------<<

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				
					if(myReader.IsClosed == false)myReader.Close();
				
                    // 2008.05.27 upd start ----------------------------->>
					//sqlCommand.CommandText = "SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@ENTERPRISECODE";
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                    sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                    sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                    sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                    sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                    sqlTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                    sqlTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                    sqlTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                    sqlTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                    sqlTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                    sqlTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                    sqlTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                    sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.27 upd end -------------------------------<<

					myReader = sqlCommand.ExecuteReader();

					while(myReader.Read())
					{
						//---自社名称
						CompanyNmWork wkCompanyNmWork = CopyToCompanyNmFromReader(myReader);
						CompanyNmWorkList.Add(wkCompanyNmWork);
					}

					arrayList.Add(SecInfoSetWorkList);
					//arrayList.Add(SecCtrlSetWorkList); // 2008.05.27 del
					arrayList.Add(CompanyNmWorkList);
				}
			}			
			catch (SqlException ex)
			{
                status = WriteSQLErrorLog(ex, "SectionInfoLcDB.SearchProc", 0);
                //エラーの場合設定します(現在仮)
				errorLevel		= ex.LineNumber;
				errorCode		= ex.Number.ToString();
				errorMessage	= ex.Message;
			}
			catch(Exception ex)
			{
                WriteErrorLog(ex, "SectionInfoLcDB.SearchProc Exception=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				//errorLevel = status;
				errorCode = status.ToString(); 
				errorMessage = ex.Message;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
                //2006.06.21 kane del start >>>
                //if(sqlConnection != null)
                //{
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //}
                //2006.06.21 kane del end   <<<
			}
			
			searchRetCSArrayList = arrayList;
	

			return status;
		}


		/// <summary>
		/// Select分生成処理
		/// </summary>
		/// <param name="secInfoSetWork">検索条件格納クラス</param>
		/// <param name="mode"></param>
		/// <returns>Select文字列</returns>
		/// <br>Note       : Select分の生成を行います</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.07.04</br>
		private string MakeSelectString(SecInfoSetWork secInfoSetWork, int mode)
		{
			//拠点情報設定、拠点制御設定、自社名称の３つのマスタを結合して全ての情報を取得します。
            // 2008.05.27 upd start ---------------------------------->> 
            //string retstring = "SELECT * FROM SECINFOSETRF "
            //    +"LEFT JOIN SECCTRLSETRF ON SECCTRLSETRF.ENTERPRISECODERF=SECINFOSETRF.ENTERPRISECODERF "
            //    +"AND SECCTRLSETRF.SECTIONCODERF=SECINFOSETRF.SECTIONCODERF ";
            string retstring = string.Empty;
            retstring += "SELECT CREATEDATETIMERF" + Environment.NewLine;
            retstring += "    ,UPDATEDATETIMERF" + Environment.NewLine;
            retstring += "    ,ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
            retstring += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
            retstring += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
            retstring += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
            retstring += "    ,LOGICALDELETECODERF" + Environment.NewLine;
            retstring += "    ,SECTIONCODERF" + Environment.NewLine;
            retstring += "    ,SECTIONGUIDENMRF" + Environment.NewLine;
            retstring += "    ,SECTIONGUIDESNMRF" + Environment.NewLine;
            retstring += "    ,COMPANYNAMECD1RF" + Environment.NewLine;
            retstring += "    ,MAINOFFICEFUNCFLAGRF" + Environment.NewLine;
            retstring += "    ,INTRODUCTIONDATERF" + Environment.NewLine;
            retstring += "    ,SECTWAREHOUSECD1RF" + Environment.NewLine;
            retstring += "    ,SECTWAREHOUSECD2RF" + Environment.NewLine;
            retstring += "    ,SECTWAREHOUSECD3RF" + Environment.NewLine;
            retstring += " FROM SECINFOSETRF" + Environment.NewLine;
            // 2008.05.27 upd end ------------------------------------<<
			return retstring;
		}

		/// <summary>
		/// 検索条件文字列生成＋条件値設定
		/// </summary>
		/// <param name="sqlCommand">SqlCommandオブジェクト</param>
		/// <param name="secInfoSetWork">検索条件格納クラス</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>Where条件文字列</returns>
		/// <br>Note       : 検索条件文字列生成＋条件値設定を行います</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.07.04</br>
		private string MakeWhereString(ref SqlCommand sqlCommand,SecInfoSetWork secInfoSetWork,ConstantManagement.LogicalMode logicalMode)
		{
			string retstring = "WHERE ";

			//企業コード
			retstring += "SECINFOSETRF.ENTERPRISECODERF=@ENTERPRISECODE ";
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.EnterpriseCode);

			//論理削除区分
			string logidelstr = "";
			if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
				(logicalMode == ConstantManagement.LogicalMode.GetData1)||
				(logicalMode == ConstantManagement.LogicalMode.GetData2)||
				(logicalMode == ConstantManagement.LogicalMode.GetData3))
			{
				logidelstr = "AND SECINFOSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
			}
			else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
				(logicalMode == ConstantManagement.LogicalMode.GetData012))
			{
				logidelstr = "AND SECINFOSETRF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
			}
			if(logidelstr != "")
			{
				retstring += logidelstr;
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
			}

			return retstring;
		}

		/// <summary>
		/// DataReaderからSecInfoSetWorkクラスへ値を移します
		/// </summary>
		/// <param name="myReader"></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private SecInfoSetWork CopyToSecInfoSetFromReader(SqlDataReader myReader)
		{
			SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();
			#region クラスへ代入
			wkSecInfoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
			wkSecInfoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
			wkSecInfoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
			wkSecInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
			wkSecInfoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
			wkSecInfoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
			wkSecInfoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
			wkSecInfoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
			wkSecInfoSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
			//wkSecInfoSetWork.OthrSlipCompanyNmCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OTHRSLIPCOMPANYNMCDRF")); // 2008.05.27 del
			wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
			wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
            //wkSecInfoSetWork.SecCdForNumbering = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECCDFORNUMBERINGRF"));    // 2008.05.27 del
            wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD1RF"));
            // 2008.05.27 del start -------------------------------->>
            //wkSecInfoSetWork.CompanyNameCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD2RF"));
            //wkSecInfoSetWork.CompanyNameCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD3RF"));
            //wkSecInfoSetWork.CompanyNameCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD4RF"));
            //wkSecInfoSetWork.CompanyNameCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD5RF"));
            //wkSecInfoSetWork.CompanyNameCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD6RF"));
            //wkSecInfoSetWork.CompanyNameCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD7RF"));
            //wkSecInfoSetWork.CompanyNameCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD8RF"));
            //wkSecInfoSetWork.CompanyNameCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD9RF"));
            //wkSecInfoSetWork.CompanyNameCd10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD10RF"));
            // 2008.05.27 del end ----------------------------------<<
            // ↓ 2008.02.01 980081 a
            wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
            //wkSecInfoSetWork.SectWarehouseNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM1RF")); // 2008.05.27 del
            wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
            //wkSecInfoSetWork.SectWarehouseNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM2RF")); // 2008.05.27 del
            wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
            //wkSecInfoSetWork.SectWarehouseNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM3RF")); // 2008.05.27 del
            // ↑ 2008.02.01 980081 a
            #endregion
			return wkSecInfoSetWork;
		}

        // 2008.05.27 del start -------------------------------->>
        ///// <summary>
        ///// DataReaderからSecCtrlSetWorkクラスへ値を移します
        ///// </summary>
        ///// <param name="myReader"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2005.08.06</br>
        ///// </remarks>
        //private SecCtrlSetWork CopyToSecCtrlSetFromReader(SqlDataReader myReader)
        //{
        //    SecCtrlSetWork wkSecCtrlSetWork = new SecCtrlSetWork();
        //    #region クラスへ代入
        //    wkSecCtrlSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
        //    wkSecCtrlSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    wkSecCtrlSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
        //    wkSecCtrlSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    wkSecCtrlSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    wkSecCtrlSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    wkSecCtrlSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    wkSecCtrlSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    wkSecCtrlSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
        //    wkSecCtrlSetWork.CtrlFuncCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CTRLFUNCCODERF"));
        //    wkSecCtrlSetWork.CtrlFuncSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
        //    wkSecCtrlSetWork.CtrlFuncName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CTRLFUNCNAMERF"));
        //    #endregion
        //    return wkSecCtrlSetWork;
        //}
        // 2008.05.27 del end ----------------------------------<<

		/// <summary>
		/// DataReaderからCompanyNmWorkクラスへ値を移します
		/// </summary>
		/// <param name="myReader"></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private CompanyNmWork CopyToCompanyNmFromReader(SqlDataReader myReader)
		{
			CompanyNmWork wkCompanyNmWork = new CompanyNmWork();
			#region クラスへ代入
            wkCompanyNmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCompanyNmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCompanyNmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCompanyNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCompanyNmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCompanyNmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCompanyNmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCompanyNmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCompanyNmWork.CompanyNameCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECDRF"));
            wkCompanyNmWork.CompanyPr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
            wkCompanyNmWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
            wkCompanyNmWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
            wkCompanyNmWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            wkCompanyNmWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //wkCompanyNmWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF")); // 2008.05.27 del
            wkCompanyNmWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            wkCompanyNmWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            wkCompanyNmWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
            wkCompanyNmWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
            wkCompanyNmWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
            wkCompanyNmWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
            wkCompanyNmWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
            wkCompanyNmWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
            wkCompanyNmWork.TransferGuidance = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
            wkCompanyNmWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
            wkCompanyNmWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
            wkCompanyNmWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
            wkCompanyNmWork.CompanySetNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
            wkCompanyNmWork.CompanySetNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
            wkCompanyNmWork.ImageInfoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
            wkCompanyNmWork.ImageInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
            wkCompanyNmWork.CompanyUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
            wkCompanyNmWork.CompanyPrSentence2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
            wkCompanyNmWork.ImageCommentForPrt1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
            wkCompanyNmWork.ImageCommentForPrt2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
            #endregion
			return wkCompanyNmWork;
		}

        // ↓ 2008.02.01 980081 a
        #region [Search]
        /// <summary>
        /// 指定された条件の拠点情報設定LC情報LISTを戻します
        /// </summary>
        /// <param name="secInfoSetWorkList">検索結果</param>
        /// <param name="paraSecInfoSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の拠点情報設定LC情報LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        public int Search(out List<SecInfoSetWork> secInfoSetWorkList, SecInfoSetWork paraSecInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            secInfoSetWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSecInfoSetWorkProcProc(out secInfoSetWorkList, paraSecInfoSetWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SecInfoSetWorkLcDB.Search", 0);
                secInfoSetWorkList = new List<SecInfoSetWork>();
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
        /// 指定された条件の拠点情報設定LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="secInfoSetWorkList">検索結果</param>
        /// <param name="secInfoSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の拠点情報設定LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        public int SearchSecInfoSetWorkProc(out List<SecInfoSetWork> secInfoSetWorkList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = SearchSecInfoSetWorkProcProc(out secInfoSetWorkList, secInfoSetWork, readMode, logicalMode, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// 指定された条件の拠点情報設定LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="secInfoSetWorkList">検索結果</param>
        /// <param name="secInfoSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の拠点情報設定LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        private int SearchSecInfoSetWorkProcProc(out List<SecInfoSetWork> secInfoSetWorkList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<SecInfoSetWork> listdata = new List<SecInfoSetWork>();
            try
            {
                // 2008.05.27 upd start ------------------------------>>
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
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.27 upd end --------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, secInfoSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToSecInfoSetFromReader(myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SecInfoSetWorkLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            secInfoSetWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の拠点情報設定LCを戻します
        /// </summary>
        /// <param name="secInfoSetWork">secInfoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の拠点情報設定LCを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        public int Read(ref SecInfoSetWork secInfoSetWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref secInfoSetWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SecInfoSetLcDB.Read", 0);
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
        /// 指定された条件の拠点情報設定LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="secInfoSetWork">secInfoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の拠点情報設定LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        private int ReadProc(ref SecInfoSetWork secInfoSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref secInfoSetWork, readMode, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// 指定された条件の拠点情報設定LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="secInfoSetWork">secInfoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の拠点情報設定LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        private int ReadProcProc(ref SecInfoSetWork secInfoSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.05.27 upd start ----------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
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
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.27 upd end -------------------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        secInfoSetWork = CopyToSecInfoSetFromReader(myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SecInfoSetLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [WriteSyncLocalData]
        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        public int WriteSyncLocalData(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList syncDataList = new ArrayList();
            try
            {
                if (syncServiceWork == null) return status;
                if (paraSyncDataList == null) return status;

                //使用するパラメータのキャスト
                SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == secInfoSetWork.GetType())
                    {
                        break;
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SecInfoSetLcDB.WriteSyncLocalData", 0);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
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
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        public int WriteSyncLocalDataProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList syncDataList = new ArrayList();
            status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);
            return status;
        }


        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.01</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.27 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.27 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM SECINFOSETRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM SECINFOSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.27 upd end ----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        SecInfoSetWork secInfoSetWork = paraSyncDataList[i] as SecInfoSetWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.05.27 upd start -------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SECCDFORNUMBERINGRF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF, SECTWAREHOUSECD1RF, SECTWAREHOUSENM1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSENM2RF, SECTWAREHOUSECD3RF, SECTWAREHOUSENM3RF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
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
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ----------------------------------<<

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectionCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Updateコマンドの生成
                                    // 2008.05.27 upd start -------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE SECINFOSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SECCDFORNUMBERINGRF=@SECCDFORNUMBERING , OTHRSLIPCOMPANYNMCDRF=@OTHRSLIPCOMPANYNMCD , SECTIONGUIDENMRF=@SECTIONGUIDENM , MAINOFFICEFUNCFLAGRF=@MAINOFFICEFUNCFLAG , COMPANYNAMECD1RF=@COMPANYNAMECD1 , COMPANYNAMECD2RF=@COMPANYNAMECD2 , COMPANYNAMECD3RF=@COMPANYNAMECD3 , COMPANYNAMECD4RF=@COMPANYNAMECD4 , COMPANYNAMECD5RF=@COMPANYNAMECD5 , COMPANYNAMECD6RF=@COMPANYNAMECD6 , COMPANYNAMECD7RF=@COMPANYNAMECD7 , COMPANYNAMECD8RF=@COMPANYNAMECD8 , COMPANYNAMECD9RF=@COMPANYNAMECD9 , COMPANYNAMECD10RF=@COMPANYNAMECD10 , SECTWAREHOUSECD1RF=@SECTWAREHOUSECD1 , SECTWAREHOUSENM1RF=@SECTWAREHOUSENM1 , SECTWAREHOUSECD2RF=@SECTWAREHOUSECD2 , SECTWAREHOUSENM2RF=@SECTWAREHOUSENM2 , SECTWAREHOUSECD3RF=@SECTWAREHOUSECD3 , SECTWAREHOUSENM3RF=@SECTWAREHOUSENM3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                                    sqlTxt = string.Empty;
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
                                    // 2008.05.27 upd end ----------------------------------<<
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectionCode);
                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    secInfoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)secInfoSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insertコマンドの生成
                                    // 2008.05.27 upd start -------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SECCDFORNUMBERINGRF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF, SECTWAREHOUSECD1RF, SECTWAREHOUSENM1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSENM2RF, SECTWAREHOUSECD3RF, SECTWAREHOUSENM3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SECCDFORNUMBERING, @OTHRSLIPCOMPANYNMCD, @SECTIONGUIDENM, @MAINOFFICEFUNCFLAG, @COMPANYNAMECD1, @COMPANYNAMECD2, @COMPANYNAMECD3, @COMPANYNAMECD4, @COMPANYNAMECD5, @COMPANYNAMECD6, @COMPANYNAMECD7, @COMPANYNAMECD8, @COMPANYNAMECD9, @COMPANYNAMECD10, @SECTWAREHOUSECD1, @SECTWAREHOUSENM1, @SECTWAREHOUSECD2, @SECTWAREHOUSENM2, @SECTWAREHOUSECD3, @SECTWAREHOUSENM3)";
                                    sqlTxt = string.Empty;
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
                                    // 2008.05.27 upd end ----------------------------------<<
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)secInfoSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //Insertコマンドの生成
                                // 2008.05.27 upd start -------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO SECINFOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SECCDFORNUMBERINGRF, OTHRSLIPCOMPANYNMCDRF, SECTIONGUIDENMRF, MAINOFFICEFUNCFLAGRF, COMPANYNAMECD1RF, COMPANYNAMECD2RF, COMPANYNAMECD3RF, COMPANYNAMECD4RF, COMPANYNAMECD5RF, COMPANYNAMECD6RF, COMPANYNAMECD7RF, COMPANYNAMECD8RF, COMPANYNAMECD9RF, COMPANYNAMECD10RF, SECTWAREHOUSECD1RF, SECTWAREHOUSENM1RF, SECTWAREHOUSECD2RF, SECTWAREHOUSENM2RF, SECTWAREHOUSECD3RF, SECTWAREHOUSENM3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SECCDFORNUMBERING, @OTHRSLIPCOMPANYNMCD, @SECTIONGUIDENM, @MAINOFFICEFUNCFLAG, @COMPANYNAMECD1, @COMPANYNAMECD2, @COMPANYNAMECD3, @COMPANYNAMECD4, @COMPANYNAMECD5, @COMPANYNAMECD6, @COMPANYNAMECD7, @COMPANYNAMECD8, @COMPANYNAMECD9, @COMPANYNAMECD10, @SECTWAREHOUSECD1, @SECTWAREHOUSENM1, @SECTWAREHOUSECD2, @SECTWAREHOUSENM2, @SECTWAREHOUSECD3, @SECTWAREHOUSENM3)", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
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
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ----------------------------------<<
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)secInfoSetWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        //SqlParameter paraSecCdForNumbering = sqlCommand.Parameters.Add("@SECCDFORNUMBERING", SqlDbType.NChar);   // 2008.05.27 del
                        //SqlParameter paraOthrSlipCompanyNmCd = sqlCommand.Parameters.Add("@OTHRSLIPCOMPANYNMCD", SqlDbType.Int); // 2008.05.27 del
                        SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
                        SqlParameter paraMainOfficeFuncFlag = sqlCommand.Parameters.Add("@MAINOFFICEFUNCFLAG", SqlDbType.Int);
                        SqlParameter paraCompanyNameCd1 = sqlCommand.Parameters.Add("@COMPANYNAMECD1", SqlDbType.Int);
                        // 2008.05.27 del start --------------------------------->>
                        //SqlParameter paraCompanyNameCd2 = sqlCommand.Parameters.Add("@COMPANYNAMECD2", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd3 = sqlCommand.Parameters.Add("@COMPANYNAMECD3", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd4 = sqlCommand.Parameters.Add("@COMPANYNAMECD4", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd5 = sqlCommand.Parameters.Add("@COMPANYNAMECD5", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd6 = sqlCommand.Parameters.Add("@COMPANYNAMECD6", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd7 = sqlCommand.Parameters.Add("@COMPANYNAMECD7", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd8 = sqlCommand.Parameters.Add("@COMPANYNAMECD8", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd9 = sqlCommand.Parameters.Add("@COMPANYNAMECD9", SqlDbType.Int);
                        //SqlParameter paraCompanyNameCd10 = sqlCommand.Parameters.Add("@COMPANYNAMECD10", SqlDbType.Int);
                        // 2008.05.27 del end -----------------------------------<<
                        SqlParameter paraSectWarehouseCd1 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD1", SqlDbType.NChar);
                        //SqlParameter paraSectWarehouseNm1 = sqlCommand.Parameters.Add("@SECTWAREHOUSENM1", SqlDbType.NVarChar); // 2008.05.27 del
                        SqlParameter paraSectWarehouseCd2 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD2", SqlDbType.NChar);
                        //SqlParameter paraSectWarehouseNm2 = sqlCommand.Parameters.Add("@SECTWAREHOUSENM2", SqlDbType.NVarChar); // 2008.05.27 del
                        SqlParameter paraSectWarehouseCd3 = sqlCommand.Parameters.Add("@SECTWAREHOUSECD3", SqlDbType.NChar);
                        //SqlParameter paraSectWarehouseNm3 = sqlCommand.Parameters.Add("@SECTWAREHOUSENM3", SqlDbType.NVarChar); // 2008.05.27 del
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secInfoSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secInfoSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secInfoSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secInfoSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secInfoSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectionCode);
                        //paraSecCdForNumbering.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SecCdForNumbering);    // 2008.05.27 del
                        //paraOthrSlipCompanyNmCd.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.OthrSlipCompanyNmCd); // 2008.05.27 del
                        paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectionGuideNm);
                        paraMainOfficeFuncFlag.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.MainOfficeFuncFlag);
                        paraCompanyNameCd1.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd1);
                        // 2008.05.27 del start -------------------------------->>
                        //paraCompanyNameCd2.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd2);
                        //paraCompanyNameCd3.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd3);
                        //paraCompanyNameCd4.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd4);
                        //paraCompanyNameCd5.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd5);
                        //paraCompanyNameCd6.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd6);
                        //paraCompanyNameCd7.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd7);
                        //paraCompanyNameCd8.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd8);
                        //paraCompanyNameCd9.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd9);
                        //paraCompanyNameCd10.Value = SqlDataMediator.SqlSetInt32(secInfoSetWork.CompanyNameCd10);
                        // 2008.05.27 del end ----------------------------------<<
                        paraSectWarehouseCd1.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectWarehouseCd1);
                        //paraSectWarehouseNm1.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectWarehouseNm1); // 2008.05.27 del
                        paraSectWarehouseCd2.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectWarehouseCd2);
                        //paraSectWarehouseNm2.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectWarehouseNm2); // 2008.05.27 del
                        paraSectWarehouseCd3.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectWarehouseCd3);
                        //paraSectWarehouseNm3.Value = SqlDataMediator.SqlSetString(secInfoSetWork.SectWarehouseNm3); // 2008.05.27 del
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    //ユーザデータシンク管理マスタへ更新
                    DataSyncMngWork dataSyncMngWork = new DataSyncMngWork();
                    DataSyncMngLcDB dataSyncMngLcDB = new DataSyncMngLcDB();
                    List<DataSyncMngWork> dataSyncMngWorkList = new List<DataSyncMngWork>();
                    dataSyncMngWork.EnterpriseCode = syncServiceWork.EnterpriseCode;
                    dataSyncMngWork.LastDataUpdDate = syncServiceWork.SyncDateTimeEd;
                    dataSyncMngWork.SyncExecDate = syncServiceWork.SyncExecDate;
                    dataSyncMngWork.ManagementTableName = syncServiceWork.ManagementTableName;
                    dataSyncMngWork.DataDeleteDateTime = syncServiceWork.DataDeleteDateTime;
                    dataSyncMngWorkList.Add(dataSyncMngWork);
                    status = dataSyncMngLcDB.WriteDataSyncMngProc(ref dataSyncMngWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SecInfoSetLcDB.WriteSyncLocalDataProc", 0);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion
        // ↑ 2008.02.01 980081 a

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [エラーログ出力処理]

        private void WriteErrorLog(string errorText)
        {
            string message = errorText;
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, 0);
        }


        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}
