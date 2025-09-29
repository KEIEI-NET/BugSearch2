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
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 拠点情報リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点情報設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br>---------------------------------------------------------</br>
	/// <br>Update Note: 自社名称マスタレイアウト変更対応</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.16</br>
	/// <br>---------------------------------------------------------</br>
	/// <br>Update Note: 拠点情報設定マスタレイアウト変更対応</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2007.10.15</br>
    /// <br>---------------------------------------------------------</br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081　疋田 勇人</br>
    /// <br>Date       : 2008.06.05</br>
    /// </remarks>
	[Serializable]
	public class SectionInfo : RemoteDB , ISectionInfo
	{
		
		/// <summary>
		/// 拠点情報リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		public SectionInfo() :
		base("SFKTN09006D", "Broadleaf.Application.Remoting.ParamData.SecInfoSetWork", "SECINFOSETRF")
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
            CustomSerializeArrayList retList = null; //2006.06.21 kane add

			SecInfoSetWork _secInfoSetWork = secInfoSetWork as SecInfoSetWork;
			if(_secInfoSetWork == null)
			{
				base.WriteErrorLog("プログラムエラー。パラメータが未設定です : SectionInfo.Search");
				return status;
			}

            try
            {
                //2006.06.21 kane add start >>>
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //2006.06.21 kane add end   <<<

                //status = SearchProc(out SecInfoSetWork, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage);//2006.06.21 kane del
                status = SearchProc(out retList, _secInfoSetWork, readMode, logicalMode, out errorLevel, out errorCode, out errorMessage, ref sqlConnection);//2006.06.21 kane add
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SectionInfo.SearchSecInfoSetProc Exception=" + ex.Message);
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
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//コネクション文字列取得対応↑↑↑↑↑

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				sqlCommand = new SqlCommand("SELECT * FROM SECINFOSETRF " 
				,sqlConnection);

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
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SectionInfo.SearchSecInfoSetProc Exception="+ex.Message);
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
        public int Search(out CustomSerializeArrayList retList, SecInfoSetWork secInfoSetWork, ref SqlConnection sqlConnection, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int errorLevel = 0;
            string errorCode = "";
            string errorMessage = "";
            retList = null;
            if (secInfoSetWork == null)
            {
                base.WriteErrorLog("プログラムエラー。パラメータが未設定です : SectionInfo.Search");
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
		/// <param name="sqlConnection">コネクション</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの拠点情報LISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.07.04</br>
        //private int SearchProc(out object searchRetCSArrayList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage)//2006.06.21 kane del
        private int SearchProc(out CustomSerializeArrayList searchRetCSArrayList, SecInfoSetWork secInfoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, out int errorLevel, out string errorCode, out string errorMessage, ref SqlConnection sqlConnection)//2006.06.21 kane add
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
			CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

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
				//自社名称
				ArrayList CompanyNmWorkList = new ArrayList();

				//Select句の生成
				string SelectString = MakeSelectString(secInfoSetWork,0);
				using(sqlCommand = new SqlCommand(SelectString ,sqlConnection))
				{
					//WHERE文の作成
					sqlCommand.CommandText += MakeWhereString(ref sqlCommand,secInfoSetWork,logicalMode);

				
					//ORDER BYの指定
					sqlCommand.CommandText += "ORDER BY SECINFOSETRF.ENTERPRISECODERF ,SECINFOSETRF.SECTIONCODERF";
				
					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						//---拠点情報設定
						SecInfoSetWork wkSecInfoSetWork = CopyToSecInfoSetFromReader(myReader);
						if(SecInfoSetWorkList.Count <= 0)
							SecInfoSetWorkList.Add(wkSecInfoSetWork);
						else if(wkSecInfoSetWork.SectionCode != ((SecInfoSetWork)SecInfoSetWorkList[SecInfoSetWorkList.Count-1]).SectionCode)
							SecInfoSetWorkList.Add(wkSecInfoSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				
					if(myReader.IsClosed == false)myReader.Close();
				
					sqlCommand.CommandText = "SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@ENTERPRISECODE";

					myReader = sqlCommand.ExecuteReader();

					while(myReader.Read())
					{
						//---自社名称
						CompanyNmWork wkCompanyNmWork = CopyToCompanyNmFromReader(myReader);
						CompanyNmWorkList.Add(wkCompanyNmWork);
					}

					customSerializeArrayList.Add(SecInfoSetWorkList);
					customSerializeArrayList.Add(CompanyNmWorkList);
				}
			}			
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
				//エラーの場合設定します(現在仮)
				errorLevel		= ex.LineNumber;
				errorCode		= ex.Number.ToString();
				errorMessage	= ex.Message;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"SectionInfo.SearchProc Exception="+ex.Message);
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
			
			searchRetCSArrayList = customSerializeArrayList;
	

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
			string retstring = "SELECT * FROM SECINFOSETRF ";
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
        /// <returns>SecInfoSetWork</returns>
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
			//wkSecInfoSetWork.OthrSlipCompanyNmCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OTHRSLIPCOMPANYNMCDRF")); // 2008.06.05 del
			wkSecInfoSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkSecInfoSetWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));         // 2008.06.05 add  
            wkSecInfoSetWork.CompanyNameCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
            wkSecInfoSetWork.MainOfficeFuncFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MAINOFFICEFUNCFLAGRF"));
            wkSecInfoSetWork.IntroductionDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("INTRODUCTIONDATERF"));        // 2008.06.05 add  
            //wkSecInfoSetWork.SecCdForNumbering = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECCDFORNUMBERINGRF"));    // 2008.06.05 del
			
            // 2008.06.05 del start --------------------------------------------------------->>
            //wkSecInfoSetWork.CompanyNameCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD2RF"));
            //wkSecInfoSetWork.CompanyNameCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD3RF"));
            //wkSecInfoSetWork.CompanyNameCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD4RF"));
            //wkSecInfoSetWork.CompanyNameCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD5RF"));
            //wkSecInfoSetWork.CompanyNameCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD6RF"));
            //wkSecInfoSetWork.CompanyNameCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD7RF"));
            //wkSecInfoSetWork.CompanyNameCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD8RF"));
            //wkSecInfoSetWork.CompanyNameCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD9RF"));
            //wkSecInfoSetWork.CompanyNameCd10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYNAMECD10RF"));
            // 2008.06.05 del end -----------------------------------------------------------<<
			// 2007.10.15 sasaki >>
			wkSecInfoSetWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
			wkSecInfoSetWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
			wkSecInfoSetWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
            // 2008.06.05 del start --------------------------------------------------------->>
            //wkSecInfoSetWork.SectWarehouseNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM1RF"));
            //wkSecInfoSetWork.SectWarehouseNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM2RF"));
            //wkSecInfoSetWork.SectWarehouseNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSENM3RF"));
            // 2008.06.05 del end -----------------------------------------------------------<<
			// 2007.10.15 sasaki <<
			#endregion
			return wkSecInfoSetWork;
		}
	
		/// <summary>
		/// DataReaderからCompanyNmWorkクラスへ値を移します
		/// </summary>
		/// <param name="myReader"></param>
        /// <returns>CompanyNmWork</returns>
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
            //wkCompanyNmWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF")); // 2008.06.05 del
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
	}

}
