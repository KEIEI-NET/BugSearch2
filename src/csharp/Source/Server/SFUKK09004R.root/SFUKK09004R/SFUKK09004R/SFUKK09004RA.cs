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
	/// 税率設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 税率設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 95016　牟田口　昌彦</br>
	/// <br>Date       : 2005.05.06</br>
	/// <br></br>
    /// <br>Update Note: PM.NS用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.21</br>
    /// </remarks>
	[Serializable]
    public class TaxRateSetDB : RemoteDB, IRemoteDB, ITaxRateSetDB, IGetSyncdataList // MarshalByRefObject , ITaxRateSetDB
	{
//		private string _connectionText;		//コネクション文字列格納用

		/// <summary>
		/// 税率設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 95016　牟田口　昌彦</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public TaxRateSetDB() :
		base("SFUKK09006D", "Broadleaf.Application.Remoting.ParamData.TaxRateSetWork", "TAXRATESETRF")
		{
//			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
		}

		/// <summary>
		/// 指定された企業コードの税率設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:TaxRateSetWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
//			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status =  SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// 指定された企業コードの税率設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:TaxRateSetWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			TaxRateSetWork TaxRateSetWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

			try 
			{	
				// XMLの読み込み
				TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(TaxRateSetWork));

                // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑
                //
				////SQL文生成
				//sqlConnection = new SqlConnection(connectionText);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
               
                sqlConnection.Open();

                string sqlTxt = string.Empty; // 2008.05.21 add

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.21 upd start -------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.21 upd end ----------------------------------------------<<
                    //論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.21 upd start -------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.21 upd end ----------------------------------------------<<
                    //論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
                    // 2008.05.21 upd start -------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.21 upd end ----------------------------------------------<<
                }
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.EnterpriseCode);

				//データリード
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.SearchCntProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// 指定された企業コードの税率設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			bool nextData;
			int retTotalCnt;
//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            ArrayList retList = null;

            try
            {
                // XMLの読み込み
                TaxRateSetWork taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork));

                status = SearchProc(out retList, out retTotalCnt, out nextData, taxratesetWork, readMode, logicalMode, 0);

                // XMLへ変換し、文字列のバイナリ化
                TaxRateSetWork[] TaxRateSetWorks = (TaxRateSetWork[])retList.ToArray(typeof(TaxRateSetWork));
                retbyte = XmlByteSerializer.Serialize(TaxRateSetWorks);
            
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

        /// <summary>
        /// 指定された企業コードの税率設定LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(out object retList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new ArrayList();

            try
            {
                ArrayList taxRateSetWorkList = null;
                TaxRateSetWork paraTaxRateSetWork = paraWork as TaxRateSetWork;

                status = SearchProc(out taxRateSetWorkList, out retTotalCnt, out nextData, paraTaxRateSetWork, readMode, logicalMode, 0);
                retList = taxRateSetWorkList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TaxRateSetDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        
        /// <summary>
		/// 指定された企業コードの税率設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="taxRateSetWork">税率設定オブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int Search(ref object taxRateSetWork,int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			bool nextData;
			int retTotalCnt;
//			return SearchProc(ref taxRateSetWork,out retTotalCnt,out nextData,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  SearchProc(ref taxRateSetWork,out retTotalCnt,out nextData,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 指定された企業コードの税率設定LISTを指定件数分全て戻します（論理削除除く）
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
//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;

            ArrayList retList = null;
            try
            {
                // XMLの読み込み
                TaxRateSetWork taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork));

                status = SearchProc(out retList, out retTotalCnt, out nextData, taxratesetWork, readMode, logicalMode, readCnt);

                // XMLへ変換し、文字列のバイナリ化
                TaxRateSetWork[] TaxRateSetWorks = (TaxRateSetWork[])retList.ToArray(typeof(TaxRateSetWork));
                retbyte = XmlByteSerializer.Serialize(TaxRateSetWorks);

            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
		}

		/// <summary>
		/// 指定された企業コードの税率設定LISTを全て戻します
		/// </summary>
        /// <param name="retList">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
        /// <param name="taxratesetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, TaxRateSetWork taxratesetWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			//総件数を0で初期化
			retTotalCnt = 0;

			//件数指定リードの場合には指定件数＋１件リードする
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//次レコード無しで初期化
			nextData = false;

			ArrayList al = new ArrayList();
            retList = new ArrayList();

			try 
			{	
                // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑
                //
				////SQL文生成
				//sqlConnection = new SqlConnection(connectionText);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                
                sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得

                string sqlTxt = string.Empty; // 2008.05.21 add

				if ((readCnt > 0)&&(taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == "")))
				{
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.21 upd start ----------------------------------------->>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                        //論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.21 upd start ----------------------------------------->>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                        //論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.21 upd start ----------------------------------------->>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                    }
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

		//		SqlCommand sqlCommand;

                sqlTxt = string.Empty;   // 2008.05.21 add

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
                        // 2008.05.21 upd start ----------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);

                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                        sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                    }
					else
					{
						//一件目リードの場合
						if ((taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == ""))
						{
                            // 2008.05.21 upd start -------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);

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
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------<<
                        }
						//Nextリードの場合
						else
						{   
                            // 2008.05.21 upd start -------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND TAXRATECODERF>@FINDTAXRATECODE ORDER BY TAXRATECODERF", sqlConnection);

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
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND TAXRATECODERF>@FINDTAXRATECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------<<

                            SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);
							findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
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
                        // 2008.05.21 upd start ------------------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);

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
                        sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                        sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end --------------------------------------------<<
                    }
					else
					{
						//一件目リードの場合
						if ((taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == ""))
						{
                            // 2008.05.21 upd start -------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------<<
                        }
						//Nextリードの場合
						else
						{
                            // 2008.05.21 upd start -------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND TAXRATECODERF>@FINDTAXRATECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND TAXRATECODERF>@FINDTAXRATECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------<<

							SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);
							findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
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
                        // 2008.05.21 upd start ------------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY TAXRATECODERF", sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                        sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end ---------------------------------------------<<
                    }
					else
					{
						//一件目リードの場合
						if ((taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == ""))
						{
                            // 2008.05.21 upd start --------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end -----------------------------------------<<
                        }
						else
						{
                            // 2008.05.21 upd start --------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF>@FINDTAXRATECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND TAXRATECODERF>@FINDTAXRATECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end -----------------------------------------<<

							SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);
							findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);

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
					TaxRateSetWork wkTaxRateSetWork = new TaxRateSetWork();

					wkTaxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkTaxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkTaxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkTaxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkTaxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkTaxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkTaxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkTaxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkTaxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TAXRATECODERF"));
					wkTaxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
					wkTaxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATENAMERF"));
					wkTaxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
					wkTaxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATERF"));
					wkTaxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATERF"));
					wkTaxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATERF"));
					wkTaxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
					wkTaxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE2RF"));
					wkTaxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE2RF"));
					wkTaxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
					wkTaxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE3RF"));
					wkTaxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE3RF"));

					al.Add(wkTaxRateSetWork);

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
                base.WriteErrorLog(ex,"TaxRateSetDB.SearchProc Exception="+ex.Message);
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

            retList = al;

			return status;
		}
		
		/// <summary>
		/// 指定された企業コードの税率設定LISTを全て戻します
		/// </summary>
		/// <param name="taxRateSetWork">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		private int SearchProc(ref object taxRateSetWork,out int retTotalCnt,out bool nextData,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			//TaxRateSetWork taxratesetWork = new TaxRateSetWork();
			TaxRateSetWork taxratesetWork = null;

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
				ArrayList taxRateSetWorkList = taxRateSetWork as ArrayList;
				if(taxRateSetWorkList != null)
				{
					// XMLの読み込み
					taxratesetWork = taxRateSetWorkList[0] as TaxRateSetWork;

                    // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                    ////コネクション文字列取得対応↓↓↓↓↓
                    ////※各publicメソッドの開始時にコネクション文字列を取得
                    ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    //if (connectionText == null || connectionText == "") return status;
                    ////コネクション文字列取得対応↑↑↑↑↑
                    //
					////SQL文生成
					//sqlConnection = new SqlConnection(connectionText);

                    //コネクション生成
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;

                    sqlConnection.Open();

                    string sqlTxt = string.Empty;  // 2008.05.21 add

					//件数指定リードで一件目リードの場合データ総件数を取得

					if ((readCnt > 0)&&(taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == "")))
					{
						SqlCommand sqlCommandCount;
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
                            // 2008.05.21 upd start -------------------------------------------->>
							//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------------<<
                            //論理削除区分設定
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
                            // 2008.05.21 upd start -------------------------------------------->>
							//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------------<<
                            
                            //論理削除区分設定
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else 
						{
                            // 2008.05.21 upd start -------------------------------------------->>
							//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end ----------------------------------------------<<
                        }
						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);

						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
					}

			//		SqlCommand sqlCommand;

                    sqlTxt = string.Empty;  // 2008.05.21 add

					//データ読込
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						//件数指定無しの場合
						if (readCnt == 0)
						{
                            // 2008.05.21 upd start ------------------------------------>>
							//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end --------------------------------------<<
                        }
						else
						{
							//一件目リードの場合
							if ((taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == ""))
							{
                                // 2008.05.21 upd start ------------------------------------------------------>>
								//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                                // 2008.05.21 upd end --------------------------------------------------------<<
                            }
								//Nextリードの場合
							else
							{
                                // 2008.05.21 upd start ------------------------------------------------------>>
								//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND TAXRATECODERF>@FINDTAXRATECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND TAXRATECODERF>@FINDTAXRATECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                                // 2008.05.21 upd end --------------------------------------------------------<<

								SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);
								findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
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
                            // 2008.05.21 upd start ------------------------------------------------>>
							//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end --------------------------------------------------<<
                        }
						else
						{
							//一件目リードの場合
							if ((taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == ""))
							{
                                // 2008.05.21 upd start --------------------------------------------------->>
								//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                                // 2008.05.21 upd end --------------------------------------------------------<<
                            }
								//Nextリードの場合
							else
							{
                                // 2008.05.21 upd start ------------------------------------------------------>>
								//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND TAXRATECODERF>@FINDTAXRATECODE ORDER BY TAXRATECODERF", sqlConnection);
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
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                                sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                                // 2008.05.21 upd end --------------------------------------------------------<<

								SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);
								findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
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
                            // 2008.05.21 upd start ----------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY TAXRATECODERF", sqlConnection);
                            sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                            sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                            sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.21 upd end -------------------------------------------------<<
                        }
						else
						{
							//一件目リードの場合
							if ((taxratesetWork.TaxRateCode == 0))//||(TaxRateSetWork.TaxRateSetCode == ""))
							{
								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY TAXRATECODERF", sqlConnection);
							}
							else
							{
								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF>@FINDTAXRATECODE ORDER BY TAXRATECODERF", sqlConnection);

								SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);
								findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
							}
						}
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);

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
						TaxRateSetWork wkTaxRateSetWork = new TaxRateSetWork();

						wkTaxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkTaxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkTaxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkTaxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkTaxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkTaxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkTaxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkTaxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkTaxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TAXRATECODERF"));
						wkTaxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
						wkTaxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATENAMERF"));
						wkTaxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
						wkTaxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATERF"));
						wkTaxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATERF"));
						wkTaxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATERF"));
						wkTaxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
						wkTaxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE2RF"));
						wkTaxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE2RF"));
						wkTaxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
						wkTaxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE3RF"));
						wkTaxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE3RF"));

						al.Add(wkTaxRateSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.SearchProc Exception="+ex.Message);
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

			taxRateSetWork = al;

			return status;
		}


		
		#region インターフェースで公開しないメソッド
		/// <summary>
		/// 指定された企業コードの税率設定LISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="taxRateSetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="sqlConnection">コネクション</param>
		/// <returns>STATUS</returns>
		public int Search(out ArrayList retList, TaxRateSetWork taxRateSetWork,int readMode,ConstantManagement.LogicalMode logicalMode ,ref SqlConnection sqlConnection)
		{
            return this.SearchProc(out retList, taxRateSetWork, readMode, logicalMode, ref sqlConnection); 
            }
        private int SearchProc(out ArrayList retList, TaxRateSetWork taxRateSetWork,int readMode,ConstantManagement.LogicalMode logicalMode ,ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			ArrayList al = new ArrayList();
            retList = null;

			try 
			{	
		//		SqlCommand sqlCommand;

                string sqlTxt = string.Empty; // 2008.05.21 add

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.21 upd start ------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                    sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.21 upd end ---------------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.21 upd start ------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                    sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.21 upd end ---------------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.21 upd start ------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY TAXRATECODERF", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                    sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.21 upd end ---------------------------------------------<<
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					TaxRateSetWork wkTaxRateSetWork = new TaxRateSetWork();

					wkTaxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkTaxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkTaxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkTaxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkTaxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkTaxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkTaxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkTaxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkTaxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TAXRATECODERF"));
					wkTaxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
					wkTaxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATENAMERF"));
					wkTaxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
					wkTaxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATERF"));
					wkTaxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATERF"));
					wkTaxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATERF"));
					wkTaxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
					wkTaxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE2RF"));
					wkTaxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE2RF"));
					wkTaxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
					wkTaxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE3RF"));
					wkTaxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE3RF"));

					al.Add(wkTaxRateSetWork);

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
                base.WriteErrorLog(ex,"TaxRateSetDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			retList = al;

			return status;
		}

        /// <summary>
        /// 税率設定を読み込みます。
        /// </summary>
        /// <param name="taxRateSetWork">税率設定マスタ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>STATUS</returns>
        public int Read(ref TaxRateSetWork taxRateSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref taxRateSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        private int ReadProc(ref TaxRateSetWork taxRateSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                // 2008.05.21 upd start ------------------------------------------->>
                //string queryString = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                string queryString = string.Empty;

                queryString += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                queryString += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                queryString += "    ,ENTERPRISECODERF" + Environment.NewLine;
                queryString += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                queryString += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                queryString += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                queryString += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                queryString += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                queryString += "    ,TAXRATECODERF" + Environment.NewLine;
                queryString += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                queryString += "    ,TAXRATENAMERF" + Environment.NewLine;
                queryString += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                queryString += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                queryString += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                queryString += "    ,TAXRATERF" + Environment.NewLine;
                queryString += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                queryString += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                queryString += "    ,TAXRATE2RF" + Environment.NewLine;
                queryString += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                queryString += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                queryString += "    ,TAXRATE3RF" + Environment.NewLine;
                queryString += " FROM TAXRATESETRF" + Environment.NewLine;
                queryString += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                queryString += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                // 2008.05.21 upd end ---------------------------------------------<<

                if (sqlTransaction == null)
                    sqlCommand = new SqlCommand(queryString, sqlConnection);
                else
                    sqlCommand = new SqlCommand(queryString, sqlConnection, sqlTransaction);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
				findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

				myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    taxRateSetWork = CopyToTaxRateSetWorkFromReader(ref myReader);
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
                base.WriteErrorLog(ex,"TaxRateSetDB.Read(ref TaxRateSetWork,int,ref SqlConnection,ref SqlTransaction) Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 横川 昌令</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // ↓ 正式なサーバー環境が構築できたら復活させる。
            //if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        /// <summary>
		/// 指定された企業コードの税率設定を戻します
		/// </summary>
		/// <param name="parabyte">TaxRateSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        private int ReadProc(ref byte[] parabyte , int readMode)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			TaxRateSetWork TaxRateSetWork = new TaxRateSetWork();

			try 
			{			
				// XMLの読み込み
				TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(TaxRateSetWork));

                // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑
                //
				//sqlConnection = new SqlConnection(connectionText);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

				//Selectコマンドの生成	
				// 2008.05.21 upd start ------------------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.EnterpriseCode);
				findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(TaxRateSetWork.TaxRateCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					TaxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					TaxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					TaxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					TaxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					TaxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					TaxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					TaxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					TaxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					TaxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TAXRATECODERF"));
					TaxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
					TaxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TAXRATENAMERF"));
					TaxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
					TaxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATERF"));
					TaxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATERF"));
					TaxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATERF"));
					TaxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
					TaxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE2RF"));
					TaxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE2RF"));
					TaxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
					TaxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("TAXRATEENDDATE3RF"));
					TaxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("TAXRATE3RF"));

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
                base.WriteErrorLog(ex,"TaxRateSetDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(myReader != null && !myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(TaxRateSetWork);

			return status;
		}

		/// <summary>
		/// 税率設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">TaxRateSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        private int WriteProc(ref byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
				// XMLの読み込み
				TaxRateSetWork TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(TaxRateSetWork));

                // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑
                //
				//sqlConnection = new SqlConnection(connectionText);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

				//Selectコマンドの生成
                // 2008.05.21 upd start ------------------------------------------------>>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, TAXRATECODERF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.EnterpriseCode);
				findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(TaxRateSetWork.TaxRateCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != TaxRateSetWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (TaxRateSetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    // 2008.05.21 upd start ------------------------------------------->>
                    //sqlCommand.CommandText = "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , "
                    //    +"TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , TAXRATECODERF=@TAXRATECODE" + Environment.NewLine;
                    sqlTxt += " , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                    sqlTxt += " , TAXRATENAMERF=@TAXRATENAME" + Environment.NewLine;
                    sqlTxt += " , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                    sqlTxt += " , TAXRATESTARTDATERF=@TAXRATESTARTDATE" + Environment.NewLine;
                    sqlTxt += " , TAXRATEENDDATERF=@TAXRATEENDDATE" + Environment.NewLine;
                    sqlTxt += " , TAXRATERF=@TAXRATE" + Environment.NewLine;
                    sqlTxt += " , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2" + Environment.NewLine;
                    sqlTxt += " , TAXRATEENDDATE2RF=@TAXRATEENDDATE2" + Environment.NewLine;
                    sqlTxt += " , TAXRATE2RF=@TAXRATE2" + Environment.NewLine;
                    sqlTxt += " , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3" + Environment.NewLine;
                    sqlTxt += " , TAXRATEENDDATE3RF=@TAXRATEENDDATE3" + Environment.NewLine;
                    sqlTxt += " , TAXRATE3RF=@TAXRATE3" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end ---------------------------------------------<<

					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.EnterpriseCode);
					findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(TaxRateSetWork.TaxRateCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)TaxRateSetWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (TaxRateSetWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)  myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
					// 2008.05.21 upd start ------------------------------------------->>
                    //sqlCommand.CommandText = "INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, "
                    //    +"@ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                    sqlTxt = string.Empty;

                    sqlTxt += "INSERT INTO TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
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
                    sqlTxt += "    ,@TAXRATECODE" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATENAME" + Environment.NewLine;
                    sqlTxt += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATESTARTDATE" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATEENDDATE" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATE" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATESTARTDATE2" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATEENDDATE2" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATE2" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATESTARTDATE3" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATEENDDATE3" + Environment.NewLine;
                    sqlTxt += "    ,@TAXRATE3" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end ---------------------------------------------<<

					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)TaxRateSetWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(!myReader.IsClosed)myReader.Close();

                #region 値セット
				//Prameterオブジェクトの作成
				SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraTaxRateCode = sqlCommand.Parameters.Add("@TAXRATECODE", SqlDbType.Int);
				SqlParameter paraTaxRateProperNounNm = sqlCommand.Parameters.Add("@TAXRATEPROPERNOUNNM", SqlDbType.NVarChar);
				SqlParameter paraTaxRateName = sqlCommand.Parameters.Add("@TAXRATENAME", SqlDbType.NVarChar);
				SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
				SqlParameter paraTaxRateStartDate = sqlCommand.Parameters.Add("@TAXRATESTARTDATE", SqlDbType.Int);
				SqlParameter paraTaxRateEndDate = sqlCommand.Parameters.Add("@TAXRATEENDDATE", SqlDbType.Int);
				SqlParameter paraTaxRate = sqlCommand.Parameters.Add("@TAXRATE", SqlDbType.Float);
				SqlParameter paraTaxRateStartDate2 = sqlCommand.Parameters.Add("@TAXRATESTARTDATE2", SqlDbType.Int);
				SqlParameter paraTaxRateEndDate2 = sqlCommand.Parameters.Add("@TAXRATEENDDATE2", SqlDbType.Int);
				SqlParameter paraTaxRate2 = sqlCommand.Parameters.Add("@TAXRATE2", SqlDbType.Float);
				SqlParameter paraTaxRateStartDate3 = sqlCommand.Parameters.Add("@TAXRATESTARTDATE3", SqlDbType.Int);
				SqlParameter paraTaxRateEndDate3 = sqlCommand.Parameters.Add("@TAXRATEENDDATE3", SqlDbType.Int);
				SqlParameter paraTaxRate3 = sqlCommand.Parameters.Add("@TAXRATE3", SqlDbType.Float);

				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(TaxRateSetWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(TaxRateSetWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(TaxRateSetWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(TaxRateSetWork.LogicalDeleteCode);
				paraTaxRateCode.Value = SqlDataMediator.SqlSetInt32(TaxRateSetWork.TaxRateCode);
				paraTaxRateProperNounNm.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.TaxRateProperNounNm);
				paraTaxRateName.Value = SqlDataMediator.SqlSetString(TaxRateSetWork.TaxRateName);
				paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(TaxRateSetWork.ConsTaxLayMethod);
				paraTaxRateStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(TaxRateSetWork.TaxRateStartDate);
				paraTaxRateEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(TaxRateSetWork.TaxRateEndDate);
				paraTaxRate.Value = SqlDataMediator.SqlSetDouble(TaxRateSetWork.TaxRate);
				paraTaxRateStartDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(TaxRateSetWork.TaxRateStartDate2);
				paraTaxRateEndDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(TaxRateSetWork.TaxRateEndDate2);
				paraTaxRate2.Value = SqlDataMediator.SqlSetDouble(TaxRateSetWork.TaxRate2);
				paraTaxRateStartDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(TaxRateSetWork.TaxRateStartDate3);
				paraTaxRateEndDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(TaxRateSetWork.TaxRateEndDate3);
				paraTaxRate3.Value = SqlDataMediator.SqlSetDouble(TaxRateSetWork.TaxRate3);
                #endregion

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(TaxRateSetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.Write Exception="+ex.Message);
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
		/// 税率設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">TaxRateSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
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
                base.WriteErrorLog(ex,"TaxRateSetDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// 論理削除税率設定情報を復活します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
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
                base.WriteErrorLog(ex,"TaxRateSetDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// 税率設定情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">TaxRateSetWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try		
			{
				// XMLの読み込み
				TaxRateSetWork taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(TaxRateSetWork));

                // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑
                //
				//sqlConnection = new SqlConnection(connectionText);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();
                // 2008.05.21 upd start --------------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, TAXRATECODERF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end -----------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);
				findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != taxratesetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.21 upd start -------------------------------------------------------->>
					//sqlCommand.CommandText = "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "UPDATE TAXRATESETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , TAXRATECODERF=@TAXRATECODE" + Environment.NewLine;
                    sqlTxt += " , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                    sqlTxt += " , TAXRATENAMERF=@TAXRATENAME" + Environment.NewLine;
                    sqlTxt += " , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                    sqlTxt += " , TAXRATESTARTDATERF=@TAXRATESTARTDATE" + Environment.NewLine;
                    sqlTxt += " , TAXRATEENDDATERF=@TAXRATEENDDATE" + Environment.NewLine;
                    sqlTxt += " , TAXRATERF=@TAXRATE" + Environment.NewLine;
                    sqlTxt += " , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2" + Environment.NewLine;
                    sqlTxt += " , TAXRATEENDDATE2RF=@TAXRATEENDDATE2" + Environment.NewLine;
                    sqlTxt += " , TAXRATE2RF=@TAXRATE2" + Environment.NewLine;
                    sqlTxt += " , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3" + Environment.NewLine;
                    sqlTxt += " , TAXRATEENDDATE3RF=@TAXRATEENDDATE3" + Environment.NewLine;
                    sqlTxt += " , TAXRATE3RF=@TAXRATE3" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    
                    // 2008.05.21 upd end ----------------------------------------------------------<<

					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);
					findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)taxratesetWork;
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
					else if	(logicalDelCd == 0)	taxratesetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						taxratesetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	taxratesetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(taxratesetWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(taxratesetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(taxratesetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(taxratesetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.LogicalDeleteProc Exception="+ex.Message);
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
		/// 税率設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">税率設定オブジェクト</param>
		/// <returns></returns>
		public int Delete(byte[] parabyte)
		{
            return this.DeleteProc(parabyte);
        }
        private int DeleteProc(byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
				// XMLの読み込み
				TaxRateSetWork taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(TaxRateSetWork));

                // 2007.08.20 SqlConnectionを CreateSqlConnection関数へ移行
                ////コネクション文字列取得対応↓↓↓↓↓
                ////※各publicメソッドの開始時にコネクション文字列を取得
                ////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                ////コネクション文字列取得対応↑↑↑↑↑
                //
				//sqlConnection = new SqlConnection(connectionText);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // 2008.05.21 upd start ----------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, TAXRATECODERF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end -------------------------------------<<

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);
				findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != taxratesetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    // 2008.05.21 upd start --------------------------------->>
					//sqlCommand.CommandText = "DELETE FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end -----------------------------------<<

					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxratesetWork.EnterpriseCode);
					findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxratesetWork.TaxRateCode);
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
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"TaxRateSetDB.Delete Exception="+ex.Message);
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


        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.23</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.21 upd start ------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF ", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToTaxRateSetWorkFromReader(ref myReader));
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.23</br>
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

        /// <summary>
        /// SqlDataReader -> TaxRateSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TaxRateSetWork</returns>
        private TaxRateSetWork CopyToTaxRateSetWorkFromReader(ref SqlDataReader myReader)
        {
            TaxRateSetWork taxRateSetWork = new TaxRateSetWork();
            taxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            taxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            taxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            taxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            taxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            taxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            taxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            taxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            taxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATECODERF"));
            taxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
            taxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TAXRATENAMERF"));
            taxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            taxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));
            taxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));
            taxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
            taxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
            taxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));
            taxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
            taxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
            taxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));
            taxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
            return taxRateSetWork;
        }
        #endregion

    }

}

