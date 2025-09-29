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
    /// 仕入日計累計表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入日計累計表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>             得意先・仕入先分離対応</br>
    /// </remarks>
    [Serializable]
    public class StockDayTotalDataDB : RemoteDB, IStockDayTotalDataDB
    {
        /// <summary>
        /// 仕入日計累計表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        public StockDayTotalDataDB()
            :
            base("DCKOU02156D", "Broadleaf.Application.Remoting.ParamData.StockDayTotalDataWork", "STOCKDAYTOTALDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入日計累計表情報LISTを戻します
        /// </summary>
        /// <param name="stockdaytotalDataWork">検索結果</param>
        /// <param name="parastockdaytotalDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(0:担当者別,1:担当者・仕入先別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日計累計表情報LISTを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        public int Search(out object stockdaytotalDataWork, object parastockdaytotalDataWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockdaytotalDataWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                return SearchStockDayTotalDataProc(out stockdaytotalDataWork, parastockdaytotalDataWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDayTotalDataDB.Search");
                stockdaytotalDataWork = new ArrayList();
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
        /// 指定された条件の仕入日計累計表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockdaytotalDataWork">検索結果</param>
        /// <param name="parastockdaytotalDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(0:担当者別,1:担当者・仕入先別)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日計累計表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        public int SearchStockDayTotalDataProc(out object objstockdaytotalDataWork, object parastockdaytotalDataWork, int readMode, ref SqlConnection sqlConnection)
        {
            StockDayTotalExtractWork stockdaytotalExtractWork = null;

            ArrayList stockdaytotaldataWorkList = parastockdaytotalDataWork as ArrayList;

            if (stockdaytotaldataWorkList == null)
            {
                stockdaytotalExtractWork = parastockdaytotalDataWork as StockDayTotalExtractWork;
            }
            else
            {
                if (stockdaytotaldataWorkList.Count > 0)
                {
                    stockdaytotalExtractWork = stockdaytotaldataWorkList[0] as StockDayTotalExtractWork;
                }
            }

            int status = SearchStockDayTotalDataProc(out stockdaytotaldataWorkList, stockdaytotalExtractWork, readMode, ref sqlConnection);

            objstockdaytotalDataWork = stockdaytotaldataWorkList;

            return status;
        }

        /// <summary>
        /// 指定された条件の仕入日計累計表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockdaytotaldataWorkList">検索結果</param>
        /// <param name="stockdaytotalExtractWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(0:担当者別,1:担当者・仕入先別)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日計累計表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
		public int SearchStockDayTotalDataProc(out ArrayList stockdaytotaldataWorkList, StockDayTotalExtractWork stockdaytotalExtractWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.SearchStockDayTotalDataProcProc(out stockdaytotaldataWorkList, stockdaytotalExtractWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の仕入日計累計表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockdaytotaldataWorkList">検索結果</param>
        /// <param name="stockdaytotalExtractWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(0:担当者別,1:担当者・仕入先別)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日計累計表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
		private int SearchStockDayTotalDataProcProc(out ArrayList stockdaytotaldataWorkList, StockDayTotalExtractWork stockdaytotalExtractWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = "";

                # region [SELECT句]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;

                switch (readMode)
                {
                    case 0:
                        {
                            // ダミーデータを設定する
                            sqlText += " ,NULL AS SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM1" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM2" + Environment.NewLine;
                            break;
                        }
                    case 1:
                        {
                            // 担当者別・仕入先別の場合にのみ仕入先情報を抽出する
                            sqlText += " ,SLIP.SUPPLIERCDRF AS SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERNM1RF AS SUPPLIERNM1" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERNM2RF AS SUPPLIERNM2" + Environment.NewLine;
                            break;
                        }
                    default:
                        {
                            // 不適切なパラメータが設定されている
                            base.WriteErrorLog(string.Format("SearchStockDayTotalDataProc: 検索区分に不適切な値が設定されています。({0})", readMode));
                            stockdaytotaldataWorkList = al;
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                }

                sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += " ,SUM(CASE DTIL.STOCKSLIPCDDTLRF WHEN 0 THEN DTIL.STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKTTLPRICERF" + Environment.NewLine;
                sqlText += " ,SUM(CASE DTIL.STOCKSLIPCDDTLRF WHEN 1 THEN DTIL.STOCKPRICETAXEXCRF ELSE 0 END) AS RETGOODSTTLPRICERF" + Environment.NewLine;
                sqlText += " ,SUM(CASE DTIL.STOCKSLIPCDDTLRF WHEN 2 THEN DTIL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISCOUNTTTLPRICERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "    INNER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "      AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "    LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [WHERE句]
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.EnterpriseCode);

                sqlText += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

                // 拠点コード
                if (stockdaytotalExtractWork.SectionCd != null && stockdaytotalExtractWork.SectionCd.Length > 0)
                {
                    string[] sections = stockdaytotalExtractWork.SectionCd;

                    for (int i = 0; i < sections.Length; i++)
                    {
                        sections[i] = "'" + sections[i] + "'";
                    }

                    string inText = string.Join(", ", sections);

                    sqlText += "  AND SLIP.SECTIONCODERF IN (" + inText + ")" + Environment.NewLine;
                }

                // 仕入日付(開始)
                if (stockdaytotalExtractWork.StockDateSt != 0)
                {
                    sqlText += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                    SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                    paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockdaytotalExtractWork.StockDateSt);
                }

                // 仕入日付(終了)
                if (stockdaytotalExtractWork.StockDateEd != 0)
                {
                    sqlText += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                    SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                    paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockdaytotalExtractWork.StockDateEd);
                }

                // 仕入担当者コード(開始)
                if (!string.IsNullOrEmpty(stockdaytotalExtractWork.StockAgentCodeSt) && stockdaytotalExtractWork.StockAgentCodeSt == stockdaytotalExtractWork.StockAgentCodeEd)
                {
                    // 開始と終了が同じ場合は後方一致の曖昧検索とする
                    sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeSt + "%");
                }
                else
                {
                    // 仕入担当者コード(開始)
                    if (!string.IsNullOrEmpty(stockdaytotalExtractWork.StockAgentCodeSt))
                    {
                        // 開始と終了が同じ場合は後方一致の曖昧検索とする
                        sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                        SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                        paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeSt);
                    }

                    // 仕入担当者コード(終了)
                    if (stockdaytotalExtractWork.StockAgentCodeEd != "")
                    {
                        if (string.IsNullOrEmpty(stockdaytotalExtractWork.StockAgentCodeSt))
                        {
                            sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;

                            SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                            paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd);

                            SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                            paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd + "%");
                        }
                        else
                        {
                            sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                            SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                            paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd);

                            SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                            paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd + "%");
                        }
                    }
                }

                sqlText += "GROUP BY" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;

                if (readMode == 1)
                {
                    // 担当者別・仕入先別の場合にのみ仕入先情報をグループ条件に入れる
                    sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += " ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                }
                
                sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
                #endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(sqlText);
#endif

                sqlCommand.CommandText = sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockDayTotalDataWorkFromReader(ref myReader));

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
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockdaytotaldataWorkList = al;

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockDayTotalDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockDayTotalDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        private StockDayTotalDataWork CopyToStockDayTotalDataWorkFromReader(ref SqlDataReader myReader)
        {
            StockDayTotalDataWork wkStockDayTotalDataWork = new StockDayTotalDataWork();

            #region クラスへ格納
            wkStockDayTotalDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));      // 企業コード
            wkStockDayTotalDataWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));         // 拠点コード
            wkStockDayTotalDataWork.StockSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));      // 拠点ガイド名称
            wkStockDayTotalDataWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));  // 仕入日付
            wkStockDayTotalDataWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));      // 仕入担当者コード
            wkStockDayTotalDataWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));      // 仕入担当者名
            wkStockDayTotalDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD"));               // 仕入先コード
            wkStockDayTotalDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1"));             // 仕入先名称１
            wkStockDayTotalDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2"));            // 仕入先名称２
            wkStockDayTotalDataWork.StockTtlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICERF"));         // 仕入額(日計)
            wkStockDayTotalDataWork.RetGoodsTtlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETGOODSTTLPRICERF"));   // 返品額(日計) ※マイナス値
            wkStockDayTotalDataWork.DiscountTtlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTTTLPRICERF"));   // 値引額(日計) ※マイナス値
            wkStockDayTotalDataWork.PureStockTtlPrice = wkStockDayTotalDataWork.StockTtlPrice +                                            // 純仕入額(日計: 仕入額＋返品額＋値引額)
                                                        wkStockDayTotalDataWork.RetGoodsTtlPrice +
                                                        wkStockDayTotalDataWork.DiscountTtlPrice;
            #endregion

            return wkStockDayTotalDataWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockDayTotalDataWork[] StockDayTotalDataWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockDayTotalDataWork)
                    {
                        StockDayTotalDataWork wkStockDayTotalDataWork = paraobj as StockDayTotalDataWork;
                        if (wkStockDayTotalDataWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockDayTotalDataWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockDayTotalDataWorkArray = (StockDayTotalDataWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockDayTotalDataWork[]));
                        }
                        catch (Exception) { }
                        if (StockDayTotalDataWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockDayTotalDataWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockDayTotalDataWork wkStockDayTotalDataWork = (StockDayTotalDataWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockDayTotalDataWork));
                                if (wkStockDayTotalDataWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockDayTotalDataWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
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
