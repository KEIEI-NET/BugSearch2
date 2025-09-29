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
	/// 仕入在庫全体設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入在庫全体設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note: MA.NS用にファイルレイアウトが変更になったため</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.02.23</br>
    /// <br></br>
    /// <br>Update Note: DC.NS用に変更</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.15</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.18 山田 明友</br>
    /// <br>           : 自動支払金種関連を追加</br>
    /// <br>Update Note: 2008.02.27 20081 疋田 勇人</br>
    /// <br>           : 入出荷数区分２を追加</br>
    /// <br>Update Note: 22008 長内 数馬 PM.NS用に修正</br>
    /// </remarks>
	[Serializable]
	public class StockTtlStDB : RemoteDB, IRemoteDB, IStockTtlStDB
	{
		/// <summary>
		/// 仕入在庫全体設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public StockTtlStDB() :
		base("SFSIR09006D", "Broadleaf.Application.Remoting.ParamData.StockTtlStWork", "STOCKTTLSTRF")
		{
		}

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入全体設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="stockTtlStWork">検索結果</param>
        /// <param name="parastockTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入全体マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.03</br>
        public int Search(out object stockTtlStWork, object parastockTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {   
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockTtlStWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out stockTtlStWork, parastockTtlStWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockTtlStDB.Search");
                stockTtlStWork = new ArrayList();
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
        /// 指定された条件の仕入全体設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retstockTtlStWork">検索結果</param>
        /// <param name="parastockTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入全体マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.03</br>
        public int SearchProc(out object retstockTtlStWork, object parastockTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockTtlStWork stockTtlStWork = null;

            ArrayList stockTtlStWorkList = parastockTtlStWork as ArrayList;
            if (stockTtlStWorkList == null)
            {
                stockTtlStWork = parastockTtlStWork as StockTtlStWork;
            }
            else
            {
                if (stockTtlStWorkList.Count > 0)
                    stockTtlStWork = stockTtlStWorkList[0] as StockTtlStWork;
            }

            int status = SearchStockTtlStProc(out stockTtlStWorkList, stockTtlStWork, readMode, logicalMode, ref sqlConnection);
            retstockTtlStWork = stockTtlStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の仕入全体設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockTtlStWorkList">検索結果</param>
        /// <param name="stockTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.03</br>
        public int SearchStockTtlStProc(out ArrayList stockTtlStWorkList, StockTtlStWork stockTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockTtlStProcProc(out stockTtlStWorkList, stockTtlStWork, readMode, logicalMode,ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の仕入全体設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockTtlStWorkList">検索結果</param>
        /// <param name="stockTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.03</br>
        private int SearchStockTtlStProcProc(out ArrayList stockTtlStWorkList, StockTtlStWork stockTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STK.*" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += " FROM STOCKTTLSTRF AS STK" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);


                selectTxt = "";
                selectTxt += "WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " STK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockTtlStWork.EnterpriseCode);

                //拠点コード
                if (string.IsNullOrEmpty(stockTtlStWork.SectionCode) == false)
                {
                    selectTxt += " AND STK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockTtlStWork.SectionCode);
                }

                string wkstring = "";
                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = " AND STK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = " AND STK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    selectTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockTtlStWorkFromReader(ref myReader));

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

            stockTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.03</br>
        /// </remarks>
        private StockTtlStWork CopyToStockTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            StockTtlStWork wkStockTtlStWork = new StockTtlStWork();

            #region クラスへ格納
            wkStockTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockTtlStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockTtlStWork.StockDiscountName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDISCOUNTNAMERF"));
            wkStockTtlStWork.RgdsSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RGDSSLIPPRTDIVRF"));
            wkStockTtlStWork.RgdsUnPrcPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RGDSUNPRCPRTDIVRF"));
            wkStockTtlStWork.RgdsZeroPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RGDSZEROPRTDIVRF"));
            wkStockTtlStWork.ListPriceInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEINPDIVRF"));
            wkStockTtlStWork.UnitPriceInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEINPDIVRF"));
            wkStockTtlStWork.DtlNoteDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLNOTEDISPDIVRF"));
            wkStockTtlStWork.AutoPayMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMONEYKINDCODERF"));
            wkStockTtlStWork.AutoPayMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTOPAYMONEYKINDNAMERF"));
            wkStockTtlStWork.AutoPayMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMONEYKINDDIVRF"));
            wkStockTtlStWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
            wkStockTtlStWork.PriceCostUpdtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECOSTUPDTDIVRF"));
            wkStockTtlStWork.AutoEntryGoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOENTRYGOODSDIVCDRF"));
            wkStockTtlStWork.PriceCheckDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHECKDIVCDRF"));
            wkStockTtlStWork.StockUnitChgDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHGDIVCDRF"));
            wkStockTtlStWork.SectDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTDSPDIVCDRF"));
            wkStockTtlStWork.SlipDateClrDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDATECLRDIVCDRF"));
            wkStockTtlStWork.PaySlipDateClrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSLIPDATECLRDIVRF"));
            wkStockTtlStWork.PaySlipDateAmbit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSLIPDATEAMBITRF"));
            wkStockTtlStWork.StockSearchDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSEARCHDIVRF"));
            wkStockTtlStWork.GoodsNmReDispDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNMREDISPDIVCDRF"));
            #endregion

            return wkStockTtlStWork;
        }
        #endregion
		
		
		/// <summary>
		/// 指定された企業コードの仕入在庫全体設定を戻します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの仕入在庫全体設定を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// 指定された企業コードの仕入在庫全体設定を戻します
        /// </summary>
        /// <param name="parabyte">StockTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入在庫全体設定を戻します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.04.12</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {            
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            StockTtlStWork stockttlstWork = new StockTtlStWork();
            
			try 
			{			
				// XMLの読み込み
				stockttlstWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(StockTtlStWork));

                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  STK.*, SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKTTLSTRF AS STK" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  STK.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND STK.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                //Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
				    stockttlstWork = CopyToStockTtlStWorkFromReader(ref myReader);
				    
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
				base.WriteErrorLog(ex,"StockTtlStDB.Read:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(stockttlstWork);

			return status;
		}

		/// <summary>
		/// 仕入在庫全体設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
        public int Write(ref byte[] parabyte)
        {
            return this.WriteProc(ref parabyte);
        }
		/// <summary>
		/// 仕入在庫全体設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		private int WriteProc(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try 
			{
				// XMLの読み込み
				StockTtlStWork stockttlstWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(StockTtlStWork));

                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
				sqlConnection.Open();

                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKTTLSTRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				
				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);
				
				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != stockttlstWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (stockttlstWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

                    sqlText = "";
                    sqlText += "UPDATE STOCKTTLSTRF SET " + Environment.NewLine;
                    sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sqlText += " , STOCKDISCOUNTNAMERF=@STOCKDISCOUNTNAME" + Environment.NewLine;
                    sqlText += " , RGDSSLIPPRTDIVRF=@RGDSSLIPPRTDIV" + Environment.NewLine;
                    sqlText += " , RGDSUNPRCPRTDIVRF=@RGDSUNPRCPRTDIV" + Environment.NewLine;
                    sqlText += " , RGDSZEROPRTDIVRF=@RGDSZEROPRTDIV" + Environment.NewLine;
                    sqlText += " , LISTPRICEINPDIVRF=@LISTPRICEINPDIV" + Environment.NewLine;
                    sqlText += " , UNITPRICEINPDIVRF=@UNITPRICEINPDIV" + Environment.NewLine;
                    sqlText += " , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV" + Environment.NewLine;
                    sqlText += " , AUTOPAYMONEYKINDCODERF=@AUTOPAYMONEYKINDCODE" + Environment.NewLine;
                    sqlText += " , AUTOPAYMONEYKINDNAMERF=@AUTOPAYMONEYKINDNAME" + Environment.NewLine;
                    sqlText += " , AUTOPAYMONEYKINDDIVRF=@AUTOPAYMONEYKINDDIV" + Environment.NewLine;
                    sqlText += " , AUTOPAYMENTRF=@AUTOPAYMENT" + Environment.NewLine;
                    sqlText += " , PRICECOSTUPDTDIVRF=@PRICECOSTUPDTDIV" + Environment.NewLine;
                    sqlText += " , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD" + Environment.NewLine;
                    sqlText += " , PRICECHECKDIVCDRF=@PRICECHECKDIVCD" + Environment.NewLine;
                    sqlText += " , STOCKUNITCHGDIVCDRF=@STOCKUNITCHGDIVCD" + Environment.NewLine;
                    sqlText += " , SECTDSPDIVCDRF=@SECTDSPDIVCD" + Environment.NewLine;
                    sqlText += " , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD" + Environment.NewLine;
                    sqlText += " , PAYSLIPDATECLRDIVRF=@PAYSLIPDATECLRDIV" + Environment.NewLine;
                    sqlText += " , PAYSLIPDATEAMBITRF=@PAYSLIPDATEAMBIT" + Environment.NewLine;
                    sqlText += " , STOCKSEARCHDIVRF=@STOCKSEARCHDIV" + Environment.NewLine;
                    sqlText += " , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);
					
					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)stockttlstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (stockttlstWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}

					//新規作成時のSQL文を生成
                    sqlText = "";

                    sqlText += "INSERT INTO STOCKTTLSTRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += "  ,STOCKDISCOUNTNAMERF" + Environment.NewLine;
                    sqlText += "  ,RGDSSLIPPRTDIVRF" + Environment.NewLine;
                    sqlText += "  ,RGDSUNPRCPRTDIVRF" + Environment.NewLine;
                    sqlText += "  ,RGDSZEROPRTDIVRF" + Environment.NewLine;
                    sqlText += "  ,LISTPRICEINPDIVRF" + Environment.NewLine;
                    sqlText += "  ,UNITPRICEINPDIVRF" + Environment.NewLine;
                    sqlText += "  ,DTLNOTEDISPDIVRF" + Environment.NewLine;
                    sqlText += "  ,AUTOPAYMONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "  ,AUTOPAYMONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "  ,AUTOPAYMONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "  ,AUTOPAYMENTRF" + Environment.NewLine;
                    sqlText += "  ,PRICECOSTUPDTDIVRF" + Environment.NewLine;
                    sqlText += "  ,AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,PRICECHECKDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,STOCKUNITCHGDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,SECTDSPDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,SLIPDATECLRDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,PAYSLIPDATECLRDIVRF" + Environment.NewLine;
                    sqlText += "  ,PAYSLIPDATEAMBITRF" + Environment.NewLine;
                    sqlText += "  ,STOCKSEARCHDIVRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += "  ,@STOCKDISCOUNTNAME" + Environment.NewLine;
                    sqlText += "  ,@RGDSSLIPPRTDIV" + Environment.NewLine;
                    sqlText += "  ,@RGDSUNPRCPRTDIV" + Environment.NewLine;
                    sqlText += "  ,@RGDSZEROPRTDIV" + Environment.NewLine;
                    sqlText += "  ,@LISTPRICEINPDIV" + Environment.NewLine;
                    sqlText += "  ,@UNITPRICEINPDIV" + Environment.NewLine;
                    sqlText += "  ,@DTLNOTEDISPDIV" + Environment.NewLine;
                    sqlText += "  ,@AUTOPAYMONEYKINDCODE" + Environment.NewLine;
                    sqlText += "  ,@AUTOPAYMONEYKINDNAME" + Environment.NewLine;
                    sqlText += "  ,@AUTOPAYMONEYKINDDIV" + Environment.NewLine;
                    sqlText += "  ,@AUTOPAYMENT" + Environment.NewLine;
                    sqlText += "  ,@PRICECOSTUPDTDIV" + Environment.NewLine;
                    sqlText += "  ,@AUTOENTRYGOODSDIVCD" + Environment.NewLine;
                    sqlText += "  ,@PRICECHECKDIVCD" + Environment.NewLine;
                    sqlText += "  ,@STOCKUNITCHGDIVCD" + Environment.NewLine;
                    sqlText += "  ,@SECTDSPDIVCD" + Environment.NewLine;
                    sqlText += "  ,@SLIPDATECLRDIVCD" + Environment.NewLine;
                    sqlText += "  ,@PAYSLIPDATECLRDIV" + Environment.NewLine;
                    sqlText += "  ,@PAYSLIPDATEAMBIT" + Environment.NewLine;
                    sqlText += "  ,@STOCKSEARCHDIV" + Environment.NewLine;
                    sqlText += "  ,@GOODSNMREDISPDIVCD" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    
                    //登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)stockttlstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

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
                SqlParameter paraStockDiscountName = sqlCommand.Parameters.Add("@STOCKDISCOUNTNAME", SqlDbType.NVarChar);
                SqlParameter paraRgdsSlipPrtDiv = sqlCommand.Parameters.Add("@RGDSSLIPPRTDIV", SqlDbType.Int);
                SqlParameter paraRgdsUnPrcPrtDiv = sqlCommand.Parameters.Add("@RGDSUNPRCPRTDIV", SqlDbType.Int);
                SqlParameter paraRgdsZeroPrtDiv = sqlCommand.Parameters.Add("@RGDSZEROPRTDIV", SqlDbType.Int);
                SqlParameter paraListPriceInpDiv = sqlCommand.Parameters.Add("@LISTPRICEINPDIV", SqlDbType.Int);
                SqlParameter paraUnitPriceInpDiv = sqlCommand.Parameters.Add("@UNITPRICEINPDIV", SqlDbType.Int);
                SqlParameter paraDtlNoteDispDiv = sqlCommand.Parameters.Add("@DTLNOTEDISPDIV", SqlDbType.Int);
                SqlParameter paraAutoPayMoneyKindCode = sqlCommand.Parameters.Add("@AUTOPAYMONEYKINDCODE", SqlDbType.Int);
                SqlParameter paraAutoPayMoneyKindName = sqlCommand.Parameters.Add("@AUTOPAYMONEYKINDNAME", SqlDbType.NVarChar);
                SqlParameter paraAutoPayMoneyKindDiv = sqlCommand.Parameters.Add("@AUTOPAYMONEYKINDDIV", SqlDbType.Int);
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                SqlParameter paraPriceCostUpdtDiv = sqlCommand.Parameters.Add("@PRICECOSTUPDTDIV", SqlDbType.Int);
                SqlParameter paraAutoEntryGoodsDivCd = sqlCommand.Parameters.Add("@AUTOENTRYGOODSDIVCD", SqlDbType.Int);
                SqlParameter paraPriceCheckDivCd = sqlCommand.Parameters.Add("@PRICECHECKDIVCD", SqlDbType.Int);
                SqlParameter paraStockUnitChgDivCd = sqlCommand.Parameters.Add("@STOCKUNITCHGDIVCD", SqlDbType.Int);
                SqlParameter paraSectDspDivCd = sqlCommand.Parameters.Add("@SECTDSPDIVCD", SqlDbType.Int);
                SqlParameter paraSlipDateClrDivCd = sqlCommand.Parameters.Add("@SLIPDATECLRDIVCD", SqlDbType.Int);
                SqlParameter paraPaySlipDateClrDiv = sqlCommand.Parameters.Add("@PAYSLIPDATECLRDIV", SqlDbType.Int);
                SqlParameter paraPaySlipDateAmbit = sqlCommand.Parameters.Add("@PAYSLIPDATEAMBIT", SqlDbType.Int);
                SqlParameter paraStockSearchDiv = sqlCommand.Parameters.Add("@STOCKSEARCHDIV", SqlDbType.Int);
                SqlParameter paraGoodsNmReDispDivCd = sqlCommand.Parameters.Add("@GOODSNMREDISPDIVCD", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockttlstWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockttlstWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockttlstWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockttlstWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockttlstWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);
                paraStockDiscountName.Value = SqlDataMediator.SqlSetString(stockttlstWork.StockDiscountName);
                paraRgdsSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.RgdsSlipPrtDiv);
                paraRgdsUnPrcPrtDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.RgdsUnPrcPrtDiv);
                paraRgdsZeroPrtDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.RgdsZeroPrtDiv);
                paraListPriceInpDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.ListPriceInpDiv);
                paraUnitPriceInpDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.UnitPriceInpDiv);
                paraDtlNoteDispDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.DtlNoteDispDiv);
                paraAutoPayMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.AutoPayMoneyKindCode);
                paraAutoPayMoneyKindName.Value = SqlDataMediator.SqlSetString(stockttlstWork.AutoPayMoneyKindName);
                paraAutoPayMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.AutoPayMoneyKindDiv);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.AutoPayment);
                paraPriceCostUpdtDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.PriceCostUpdtDiv);
                paraAutoEntryGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.AutoEntryGoodsDivCd);
                paraPriceCheckDivCd.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.PriceCheckDivCd);
                paraStockUnitChgDivCd.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.StockUnitChgDivCd);
                paraSectDspDivCd.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.SectDspDivCd);
                paraSlipDateClrDivCd.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.SlipDateClrDivCd);
                paraPaySlipDateClrDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.PaySlipDateClrDiv);
                paraPaySlipDateAmbit.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.PaySlipDateAmbit);
                paraStockSearchDiv.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.StockSearchDiv);
                paraGoodsNmReDispDivCd.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.GoodsNmReDispDivCd);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(stockttlstWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"StockTtlStDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;

		}

		/// <summary>
		/// 仕入在庫全体情報を論理削除します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除仕入在庫全体情報を復活します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除仕入在庫全体情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// 仕入在庫全体情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">StockTtlStWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 仕入在庫全体情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try		
			{
				// XMLの読み込み
				StockTtlStWork stockttlstWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(StockTtlStWork));

                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKTTLSTRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText,sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != stockttlstWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    sqlText = "";
                    sqlText += "UPDATE" + Environment.NewLine;
                    sqlText += "  STOCKTTLSTRF" + Environment.NewLine;
                    sqlText += "SET" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)stockttlstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				//論理削除モードの場合
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						return status;
					}
					else if	(logicalDelCd == 0)	stockttlstWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						stockttlstWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	stockttlstWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockttlstWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockttlstWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockttlstWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockttlstWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(stockttlstWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"StockTtlStDB.LogicalDeleteProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;

		}

		/// <summary>
		/// 仕入在庫全体情報を物理削除します
		/// </summary>
		/// <param name="parabyte">仕入在庫全体オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 仕入在庫全体情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.12</br>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }
        /// <summary>
        /// 仕入在庫全体情報を物理削除します
        /// </summary>
        /// <param name="parabyte">仕入在庫全体オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 仕入在庫全体情報を物理削除します</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.04.12</br>
        private int DeleteProc(byte[] parabyte)
        {

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try 
			{
				// XMLの読み込み
				StockTtlStWork stockttlstWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(StockTtlStWork));

                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKTTLSTRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != stockttlstWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

                    sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKTTLSTRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    
                    //KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockttlstWork.SectionCode);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
				base.WriteErrorLog(ex,"StockTtlStDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;
		}

        /// <summary>
        /// 仕入在庫全体設定マスタを1件読み込みます
        /// </summary>
        /// <param name="stockTtlStWork">仕入在庫全体設定マスタ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入在庫全体設定を戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.07.09</br>
        public int Read(ref StockTtlStWork stockTtlStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref stockTtlStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 仕入在庫全体設定マスタを1件読み込みます
        /// </summary>
        /// <param name="stockTtlStWork">仕入在庫全体設定マスタ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入在庫全体設定を戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.07.09</br>
        private int ReadProc(ref StockTtlStWork stockTtlStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlText = String.Empty;
            try
            {
                //Selectコマンドの生成
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  STK.* , SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKTTLSTRF AS STK" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  STK.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  STK.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText,sqlConnection, sqlTransaction);

                //Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockTtlStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockTtlStWork.SectionCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    stockTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockTtlStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    stockTtlStWork.StockDiscountName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDISCOUNTNAMERF"));
                    stockTtlStWork.RgdsSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RGDSSLIPPRTDIVRF"));
                    stockTtlStWork.RgdsUnPrcPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RGDSUNPRCPRTDIVRF"));
                    stockTtlStWork.RgdsZeroPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RGDSZEROPRTDIVRF"));
                    stockTtlStWork.ListPriceInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEINPDIVRF"));
                    stockTtlStWork.UnitPriceInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEINPDIVRF"));
                    stockTtlStWork.DtlNoteDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLNOTEDISPDIVRF"));
                    stockTtlStWork.AutoPayMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMONEYKINDCODERF"));
                    stockTtlStWork.AutoPayMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTOPAYMONEYKINDNAMERF"));
                    stockTtlStWork.AutoPayMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMONEYKINDDIVRF"));
                    stockTtlStWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    stockTtlStWork.PriceCostUpdtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECOSTUPDTDIVRF"));
                    stockTtlStWork.AutoEntryGoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOENTRYGOODSDIVCDRF"));
                    stockTtlStWork.PriceCheckDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHECKDIVCDRF"));
                    stockTtlStWork.StockUnitChgDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHGDIVCDRF"));
                    stockTtlStWork.SectDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTDSPDIVCDRF"));
                    stockTtlStWork.SlipDateClrDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDATECLRDIVCDRF"));
                    stockTtlStWork.PaySlipDateClrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSLIPDATECLRDIVRF"));
                    stockTtlStWork.PaySlipDateAmbit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSLIPDATEAMBITRF"));
                    stockTtlStWork.StockSearchDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSEARCHDIVRF"));
                    stockTtlStWork.GoodsNmReDispDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNMREDISPDIVCDRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockTtlStDB.Read:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();

                if (sqlCommand != null)
                    sqlCommand.Dispose();
            }

            return status;
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

	}
}
