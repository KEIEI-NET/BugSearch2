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
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace  Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由帳票コンバートDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由帳票コンバートの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30015　橋本　裕毅</br>
    /// <br>Date       : 2007.05.16</br>
    /// </remarks>
    [Serializable]
    public class FPprSchmGrDB :  RemoteDB, IFPprSchmGrDB
    {
    	/// <summary>
		/// 自由帳票コンバートDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public FPprSchmGrDB() : 
			base("SFTKD08153D","Broadleaf.Application.Remoting.ParamData.FPprSchmGrWork","FPPRSCHMGRRF")
		{
		}

		/// <summary>
        /// 自由帳票コンバートマスタ取得処理（既存帳票の場合）
		/// </summary>
        /// <param name="fPprSchmGrWorkArray">自由帳票スキーマグループワークマスタ配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
		/// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
		/// <param name="dataInputSystemArray">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)配列</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された出力ファイル名の自由帳票スキーマグループLISTを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        public int SearchFPprSchmGr( out object fPprSchmGrWorkArray, out bool msgDiv, out string errMsg, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray )
        {
            return SearchFPprSchmGrProc( out fPprSchmGrWorkArray, out msgDiv, out errMsg, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray );
        }
        /// <summary>
        /// 自由帳票コンバートマスタ取得処理（既存帳票の場合）
        /// </summary>
        /// <param name="fPprSchmGrWorkArray">自由帳票スキーマグループワークマスタ配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystemArray">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)配列</param>
        /// <returns>STATUS</returns>
        private int SearchFPprSchmGrProc( out object fPprSchmGrWorkArray, out bool msgDiv, out string errMsg, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            fPprSchmGrWorkArray = new FPprSchmGrWork[0];
            msgDiv = false;
            errMsg = "";

            SqlConnection sqlConnection = null;
            try
            {
                List<FPprSchmGrWork> fPprSchmGrWorkList;

                // SQL文を作成します。
                sqlConnection = CreateSqlConnection();
                sqlConnection.Open();

                status = SearchFPprSchmGrProc(out fPprSchmGrWorkList, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray, sqlConnection);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					fPprSchmGrWorkArray = fPprSchmGrWorkList.ToArray();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    // メッセージ区分をtrue
                    msgDiv = true;
                    // エラーメッセージ
                    errMsg = "検索中にタイムアウトが発生しました。\r\nもう少々お待ちになられてから再度検索を行って下さい。";
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "FPprSchmGrDB.SearchFPprSchmGr");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            if(sqlConnection != null)
                sqlConnection.Close();

            return status;
        }

		/// <summary>
        /// 自由帳票コンバートマスタ取得処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
		/// <param name="freePrtPprSchmGrpCdArray">自由帳票スキーマグループコード配列</param>
		/// <param name="retObj">検索結果CustomSerializeArrayList</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自由帳票スキーマコンバートマスタ,自由帳票ソート順位初期値マスタ,自由帳票抽出条件初期値マスタのISTを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        public int SearchFPprSchmCv( int freePrtPprItemGrpCd, int[] freePrtPprSchmGrpCdArray, out object retObj, out bool msgDiv, out string errMsg )
        {
            return SearchFPprSchmCvProc( freePrtPprItemGrpCd, freePrtPprSchmGrpCdArray, out retObj, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票コンバートマスタ取得処理
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
        /// <param name="freePrtPprSchmGrpCdArray">自由帳票スキーマグループコード配列</param>
        /// <param name="retObj">検索結果CustomSerializeArrayList</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        private int SearchFPprSchmCvProc( int freePrtPprItemGrpCd, int[] freePrtPprSchmGrpCdArray, out object retObj, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            msgDiv = false;
            errMsg = "";

			CustomSerializeArrayList retList = new CustomSerializeArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                // SQL文を作成します。
                sqlConnection = CreateSqlConnection();
                sqlConnection.Open();

				// 自由帳票スキーマグループコードから0以外の値を取得
				List<int> wkInt = new List<int>();
				wkInt.AddRange(freePrtPprSchmGrpCdArray);

				int freePrtPprSchmGrpCd = wkInt.Find(
					delegate(int ix)
					{
						return ix > 0;
					}
				);

				if (freePrtPprSchmGrpCdArray != null || freePrtPprSchmGrpCdArray.Length > 0)
				{
					List<FPprSchmCvWork> fPprSchmCvWorkList;
					
					// 自由帳票コンバートマスタ取得処理
					status = SearchFPprSchmCvProc(out fPprSchmCvWorkList, freePrtPprSchmGrpCd, ref sqlConnection);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						retList.Add(new ArrayList(fPprSchmCvWorkList));
					}
					
					// 自由帳票ソート順位初期値マスタ
					if (freePrtPprItemGrpCd != 0)
					{
						List<FPSortInitWork> fPSortInitWorkList;
						status = SearchFPSortInitProc(out fPSortInitWorkList, freePrtPprItemGrpCd, freePrtPprSchmGrpCdArray, ref sqlConnection);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							retList.Add(new ArrayList(fPSortInitWorkList));

							// 自由帳票抽出条件初期値マスタ
							List<FPECndInitWork> fPECndInitWorkList;
							status = SearchFPECndInitProc(out fPECndInitWorkList, freePrtPprSchmGrpCd, ref sqlConnection);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								retList.Add(new ArrayList(fPECndInitWorkList));
							}
							else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
							{
								if(retList.Count > 0)
									status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
						else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
						{
							if(retList.Count > 0)
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					retObj = retList;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    // メッセージ区分をtrue
                    msgDiv = true;
                    // エラーメッセージ
                    errMsg = "検索中にタイムアウトが発生しました。\r\nもう少々お待ちになられてから再度検索を行って下さい。";
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "FPprSchmGrDB.SearchFPprSchmCv");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

            return status;
		}

		#region 20071011DEL
		//public int SearchFPprSchmCv(out object fPprSchmCvWorkArray, out bool msgDiv, out string errMsg, int freePrtPprSchmGrpCd)
		//{
		//    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//    fPprSchmCvWorkArray = new FPprSchmCvWork[0];
		//    msgDiv = false;
		//    errMsg = "";

		//    // PGIDとメソッド名を渡してサービスジョブアクセスクラスのインスタンス
		//    NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFTKD08154R", "FPprSchmGrDB.SearchFPprSchmCv");

		//    SqlConnection sqlConnection = null;
		//    try
		//    {
		//        List<FPprSchmCvWork> fPprSchmCvWorkList;

		//        // SQL文を作成します。
		//        sqlConnection = CreateSqlConnection();
		//        sqlConnection.Open();

		//        StringBuilder paraStr = new StringBuilder("SearchFPprSchmCv Para: ");
		//        paraStr.Append("freePrtPprSchmGrpCd ").Append(freePrtPprSchmGrpCd);
		//        jobAcs.StartWriteServiceJob(paraStr.ToString(), sqlConnection);

		//        status = SearchFPprSchmCvProc(out fPprSchmCvWorkList, freePrtPprSchmGrpCd, sqlConnection);

		//        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//            fPprSchmCvWorkArray = fPprSchmCvWorkList.ToArray();
		//    }
		//    catch (SqlException ex)
		//    {
		//        //基底クラスに例外を渡して処理してもらう
		//        status = base.WriteSQLErrorLog(ex);
		//        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
		//        {
		//            // メッセージ区分をtrue
		//            msgDiv = true;
		//            // エラーメッセージ
		//            errMsg = "検索中にタイムアウトが発生しました。\r\nもう少々お待ちになられてから再度検索を行って下さい。";
		//        }
		//    }
		//    catch(Exception ex)
		//    {
		//        base.WriteErrorLog(ex, "FPprSchmGrDB.SearchFPprSchmCv");
		//        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
		//    }

		//    if(sqlConnection != null)
		//        sqlConnection.Close();

		//    return status;
		//}
		#endregion

		/// <summary>
        /// 自由帳票スキーマグループマスタ取得処理（全件）
		/// </summary>
		/// <param name="FPprSchmGrWorkList">自由帳票スキーマグループワークマスタリスト</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
		/// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystemArray">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された出力ファイル名の自由帳票スキーマグループLISTを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        private int SearchFPprSchmGrProc(out List<FPprSchmGrWork> FPprSchmGrWorkList, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;

            FPprSchmGrWorkList = new List<FPprSchmGrWork>();
            try
            {
                // Selectコマンドの生成を行います。
                //SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, FREEPRTPPRSCHMGRPCDRF, OUTPUTFORMFILENAMERF, OUTPUTFILECLASSIDRF, FREEPRTPPRITEMGRPCDRF, DISPLAYNAMERF, DATAINPUTSYSTEMRF, SPECIALCONVTUSEDIVCDRF, OPTIONCODERF, FORMFEEDLINECOUNTRF, CRCHARCNTRF FROM FPPRSCHMGRRF", sqlConnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FPPRSCHMGRRF", sqlConnection);

				// WHERE文を生成
                sqlCommand.CommandText = sqlCommand.CommandText + this.MakeWhereString(ref sqlCommand, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray);

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    FPprSchmGrWork fPprSchmGrWork = new FPprSchmGrWork();

                    fPprSchmGrWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    fPprSchmGrWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    fPprSchmGrWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    fPprSchmGrWork.FreePrtPprSchmGrpCd  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSCHMGRPCDRF"));
                    fPprSchmGrWork.OutputFormFileName   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    fPprSchmGrWork.OutputFileClassId    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFILECLASSIDRF"));
                    fPprSchmGrWork.FreePrtPprItemGrpCd  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                    fPprSchmGrWork.DisplayName          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    fPprSchmGrWork.DataInputSystem      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
					fPprSchmGrWork.SpecialConvtUseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SPECIALCONVTUSEDIVCDRF"));
					fPprSchmGrWork.OptionCode			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
					fPprSchmGrWork.FormFeedLineCount    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
					fPprSchmGrWork.CrCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CRCHARCNTRF"));
					fPprSchmGrWork.TopMargin			= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
					fPprSchmGrWork.LeftMargin			= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
					fPprSchmGrWork.RightMargin			= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
					fPprSchmGrWork.BottomMargin			= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
                    FPprSchmGrWorkList.Add(fPprSchmGrWork);
                }

                if (FPprSchmGrWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if (myReader != null)
                {
                    if(!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }

		/// <summary>
        /// 自由帳票コンバートマスタ取得処理（全件）
		/// </summary>
		/// <param name="fPprSchmCvWorkList">自由帳票コンバートワークマスタリスト</param>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された出力ファイル名の自由帳票コンバートLISTを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        public int SearchFPprSchmCvProc( out List<FPprSchmCvWork> fPprSchmCvWorkList, int freePrtPprSchmGrpCd, ref SqlConnection sqlConnection )
        {
            return SearchFPprSchmCvProcProc( out fPprSchmCvWorkList, freePrtPprSchmGrpCd, ref sqlConnection );
        }
        /// <summary>
        /// 自由帳票コンバートマスタ取得処理（全件）
        /// </summary>
        /// <param name="fPprSchmCvWorkList">自由帳票コンバートワークマスタリスト</param>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        private int SearchFPprSchmCvProcProc( out List<FPprSchmCvWork> fPprSchmCvWorkList, int freePrtPprSchmGrpCd, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            fPprSchmCvWorkList = new List<FPprSchmCvWork>();
            try
            {
                // Selectコマンドの生成を行います。
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FPPRSCHMCVRF WHERE FREEPRTPPRSCHMGRPCDRF=@FINDFREEPRTPPRSCHMGRPCD", sqlConnection);
                SqlParameter findParaFreePrtPprSchmGrpCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRSCHMGRPCD", SqlDbType.Int);
                findParaFreePrtPprSchmGrpCd.Value = freePrtPprSchmGrpCd;

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FPprSchmCvWork fPprSchmCvWork = new FPprSchmCvWork();

                    fPprSchmCvWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    fPprSchmCvWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    fPprSchmCvWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    fPprSchmCvWork.FreePrtPprSchmGrpCd  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSCHMGRPCDRF"));
                    fPprSchmCvWork.FreePrtPprSchemaCd   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSCHEMACDRF"));
                    fPprSchmCvWork.FreePrtPaperItemCd   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPAPERITEMCDRF"));
                    fPprSchmCvWork.ActiveReportClassId  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACTIVEREPORTCLASSIDRF"));
                    fPprSchmCvWork.ActiveReportCtrlNm   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACTIVEREPORTCTRLNMRF"));
                    fPprSchmCvWork.CommaEditExistCd     = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMAEDITEXISTCDRF"));
                    fPprSchmCvWork.PrintPageCtrlDivCd   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAGECTRLDIVCDRF"));
                    fPprSchmCvWork.OutputFormFileName   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    fPprSchmCvWork.OutputFileClassId    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFILECLASSIDRF"));
                    fPprSchmCvWork.InitKitFreePprItemCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INITKITFREEPPRITEMCDRF"));

                    fPprSchmCvWorkList.Add(fPprSchmCvWork);
                }

                if (fPprSchmCvWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if (myReader != null)
                {
                    if(!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }

		/// <summary>
        /// 自由帳票ソート順位初期値マスタ取得処理
		/// </summary>
		/// <param name="fPSortInitWorkList">自由帳票ソート順位初期値マスタリスト</param>
        /// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
		/// <param name="freePrtPprSchmGrpCdArray">自由帳票スキーマグループコード配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自由帳票ソート順位初期値マスタのリストを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.10.11</br>
        public int SearchFPSortInitProc( out List<FPSortInitWork> fPSortInitWorkList, int freePrtPprItemGrpCd, int[] freePrtPprSchmGrpCdArray, ref SqlConnection sqlConnection )
        {
            return SearchFPSortInitProcProc( out fPSortInitWorkList, freePrtPprItemGrpCd, freePrtPprSchmGrpCdArray, ref sqlConnection );
        }
        /// <summary>
        /// 自由帳票ソート順位初期値マスタ取得処理
        /// </summary>
        /// <param name="fPSortInitWorkList">自由帳票ソート順位初期値マスタリスト</param>
        /// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
        /// <param name="freePrtPprSchmGrpCdArray">自由帳票スキーマグループコード配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        private int SearchFPSortInitProcProc( out List<FPSortInitWork> fPSortInitWorkList, int freePrtPprItemGrpCd, int[] freePrtPprSchmGrpCdArray, ref SqlConnection sqlConnection )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            fPSortInitWorkList = new List<FPSortInitWork>();
            try
            {
                // Selectコマンドの生成を行います。
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FPSORTINITRF", sqlConnection);

				// WHERE文を生成
                sqlCommand.CommandText = sqlCommand.CommandText + this.MakeWhereString(ref sqlCommand, freePrtPprItemGrpCd, freePrtPprSchmGrpCdArray);

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FPSortInitWork fPSortInitWork = new FPSortInitWork();

					fPSortInitWork.CreateDateTime      	= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					fPSortInitWork.UpdateDateTime      	= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					fPSortInitWork.LogicalDeleteCode   	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					fPSortInitWork.FreePrtPprItemGrpCd 	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
					fPSortInitWork.FreePrtPprSchmGrpCd 	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSCHMGRPCDRF"));
					fPSortInitWork.SortingOrderCode    	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SORTINGORDERCODERF"));
					fPSortInitWork.SortingOrder			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SORTINGORDERRF"));
					fPSortInitWork.FreePrtPaperItemNm   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPAPERITEMNMRF"));
					fPSortInitWork.DDName      			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DDNAMERF"));
					fPSortInitWork.FileNm      			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
					fPSortInitWork.SortingOrderDivCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SORTINGORDERDIVCDRF"));
					
                    fPSortInitWorkList.Add(fPSortInitWork);
                }

                if (fPSortInitWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if (myReader != null)
                {
                    if(!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;

		}

		/// <summary>
        /// 自由帳票抽出条件初期値マスタ取得処理
		/// </summary>
        /// <param name="fPECndInitWorkList">自由帳票抽出条件初期値マスタ配列</param>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自由帳票抽出条件初期値マスタのリストを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.10.11</br>
        public int SearchFPECndInitProc( out List<FPECndInitWork> fPECndInitWorkList, int freePrtPprSchmGrpCd, ref SqlConnection sqlConnection )
        {
            return SearchFPECndInitProcProc( out fPECndInitWorkList, freePrtPprSchmGrpCd, ref sqlConnection );
        }
        /// <summary>
        /// 自由帳票抽出条件初期値マスタ取得処理
        /// </summary>
        /// <param name="fPECndInitWorkList">自由帳票抽出条件初期値マスタ配列</param>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        private int SearchFPECndInitProcProc( out List<FPECndInitWork> fPECndInitWorkList, int freePrtPprSchmGrpCd, ref SqlConnection sqlConnection )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

			fPECndInitWorkList = new List<FPECndInitWork>();
            try
            {
                // Selectコマンドの生成を行います。
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FPECNDINITRF WHERE FREEPRTPPRSCHMGRPCDRF=@FINDFREEPRTPPRSCHMGRPCD", sqlConnection);
                SqlParameter findParaFreePrtPprSchmGrpCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRSCHMGRPCD", SqlDbType.Int);
                findParaFreePrtPprSchmGrpCd.Value = freePrtPprSchmGrpCd;

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FPECndInitWork fPECndInitWork = new FPECndInitWork();

					fPECndInitWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					fPECndInitWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					fPECndInitWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					fPECndInitWork.FreePrtPprSchmGrpCd  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSCHMGRPCDRF"));
					fPECndInitWork.FrePrtPprExtraCondCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREPRTPPREXTRACONDCDRF"));
					fPECndInitWork.DisplayOrder			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
					fPECndInitWork.StExtraNumCode      	= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STEXTRANUMCODERF"));
					fPECndInitWork.EdExtraNumCode      	= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EDEXTRANUMCODERF"));
					fPECndInitWork.StExtraCharCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STEXTRACHARCODERF"));
					fPECndInitWork.EdExtraCharCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDEXTRACHARCODERF"));
					fPECndInitWork.StExtraDateBaseCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATEBASECDRF"));
					fPECndInitWork.StExtraDateSignCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATESIGNCDRF"));
					fPECndInitWork.StExtraDateNum		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATENUMRF"));
					fPECndInitWork.StExtraDateUnitCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATEUNITCDRF"));
					fPECndInitWork.StartExtraDate		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTEXTRADATERF"));
					fPECndInitWork.EdExtraDateBaseCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATEBASECDRF"));
					fPECndInitWork.EdExtraDateSignCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATESIGNCDRF"));
					fPECndInitWork.EdExtraDateNum		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATENUMRF"));
					fPECndInitWork.EdExtraDateUnitCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATEUNITCDRF"));
					fPECndInitWork.EndExtraDate			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENDEXTRADATERF"));
					fPECndInitWork.CheckItemCode1      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE1RF"));
					fPECndInitWork.CheckItemCode2      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE2RF"));
					fPECndInitWork.CheckItemCode3      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE3RF"));
					fPECndInitWork.CheckItemCode4      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE4RF"));
					fPECndInitWork.CheckItemCode5      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE5RF"));
					fPECndInitWork.CheckItemCode6      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE6RF"));
					fPECndInitWork.CheckItemCode7      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE7RF"));
					fPECndInitWork.CheckItemCode8      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE8RF"));
					fPECndInitWork.CheckItemCode9      	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE9RF"));
					fPECndInitWork.CheckItemCode10      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE10RF"));

                    fPECndInitWorkList.Add(fPECndInitWork);
                }

                if (fPECndInitWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if (myReader != null)
                {
                    if(!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;

		}



		/// <summary>
		/// コネクション情報生成
		/// </summary>
		/// <returns>コネクション情報</returns>
		/// <returns>SqlConnection</returns>
		/// <br>Note       : コネクション情報を生成します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
		private SqlConnection CreateSqlConnection()
		{
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
			if (connectionText == null || connectionText == "") return null;

			return new SqlConnection(connectionText);
		}


		/// <summary>
		/// Where文条件作成処理(自由帳票スキーマグループマスタ)
		/// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
		/// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
		/// <param name="dataInputSystemArray">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)配列</param>
		/// <returns>Where文</returns>
		/// <br>Note       : 自由帳票スキーマグループマスタ取得の為に必要なWhere文を作成します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" WHERE ");
            // 帳票使用区分
            if (printPaperUseDivcd != 0)
            {
                builder.Append("PRINTPAPERUSEDIVCDRF=@FINDPRINTPAPERUSEDIVCD");
                sqlCommand.Parameters.Add("@FINDPRINTPAPERUSEDIVCD", SqlDbType.Int).Value = printPaperUseDivcd;
            }
            // 帳票区分コード
            if (printPaperDivCd != 0)
            {
                builder.Append(" AND ");
                builder.Append("PRINTPAPERDIVCDRF=@FINDPRINTPAPERDIVCD");
                sqlCommand.Parameters.Add("@FINDPRINTPAPERDIVCD", SqlDbType.Int).Value = printPaperDivCd;
            }
            // データ入力システム
            if ((dataInputSystemArray != null) && (dataInputSystemArray.Length > 0))
            {
                builder.Append(" AND ");
                builder.Append("DATAINPUTSYSTEMRF IN (");
                StringBuilder builder2 = new StringBuilder();
                foreach (int num in dataInputSystemArray)
                {
                    if (builder2.Length > 0)
                    {
                        builder2.Append(",");
                    }
                    builder2.Append(num);
                }
                builder.Append(builder2.ToString()).Append(")");
            }
            return builder.ToString();
        }

		/// <summary>
		/// Where文条件作成処理(自由帳票ソート順位初期値マスタ)
		/// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
		/// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
		/// <param name="freePrtPprSchmGrpCdArray">自由帳票スキーマグループコード配列(0は新規作成)</param>
		/// <returns>Where文</returns>
		/// <br>Note       : 自由帳票ソート順位初期値マスタ取得の為に必要なWhere文を作成します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.10.11</br>
		private string MakeWhereString(ref SqlCommand sqlCommand, int freePrtPprItemGrpCd, int[] freePrtPprSchmGrpCdArray)
		{
            StringBuilder builder = new StringBuilder();
            builder.Append(" WHERE ");

			// 自由帳票印字項目グループコード
            builder.Append("FREEPRTPPRITEMGRPCDRF=@FINDFREEPRTPPRITEMGRPCD");
            sqlCommand.Parameters.Add("@FINDFREEPRTPPRITEMGRPCD", SqlDbType.Int).Value = freePrtPprItemGrpCd;

            // 自由帳票スキーマグループコード配列
            if ((freePrtPprSchmGrpCdArray != null) && (freePrtPprSchmGrpCdArray.Length > 0))
            {
                builder.Append(" AND ");
                builder.Append("FREEPRTPPRSCHMGRPCDRF IN (");
                StringBuilder builder2 = new StringBuilder();
                foreach (int num in freePrtPprSchmGrpCdArray)
                {
                    if (builder2.Length > 0)
                    {
                        builder2.Append(",");
                    }
                    builder2.Append(num);
                }
                builder.Append(builder2.ToString()).Append(")");
            }

			return builder.ToString();
		}
 
    }
}
