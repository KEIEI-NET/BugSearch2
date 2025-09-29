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
    /// 価格改正設定マスタ  リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 価格改正設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.19</br>
    /// <br></br>
    /// <br>Update Note: BLコード更新区分の追加(MANTIS[0014774])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/12/11</br>
    /// </remarks>
    [Serializable]
    public class PriceChgProcStDB : RemoteDB, IRemoteDB, IPriceChgProcStDB, IGetSyncdataList // MarshalByRefObject , ITaxRateSetDB
    {
        /// <summary>
        /// 価格改正設定マスタ  リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.19</br>
        /// </remarks>
        public PriceChgProcStDB()
            :
        base("PMKHN09227D", "Broadleaf.Application.Remoting.ParamData.PriceChgProcStWork", "PRICECHGPROCSTRF")
        {
            //			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="parabyte">検索パラメータ(readMode=0:PriceChgProcStWorkクラス：企業コード)</param>		
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int SearchCnt(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            //			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status = SearchCntProc(out retCnt, parabyte, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchCnt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="parabyte">検索パラメータ(readMode=0:PriceChgProcStWorkクラス：企業コード)</param>		
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            PriceChgProcStWork PriceChgProcStWork = null;

            retCnt = 0;

            ArrayList al = new ArrayList();

            try
            {
                // XMLの読み込み
                PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                string sqlTxt = string.Empty; // 2008.05.21 add

                SqlCommand sqlCommand;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                //データリード
                retCnt = (int)sqlCommand.ExecuteScalar();
                if (retCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchCntProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            sqlConnection.Close();

            return status;
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status = SearchProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="PriceChgProcStWork">価格改正設定オブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object PriceChgProcStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = SearchProc(ref PriceChgProcStWork, out retTotalCnt, out nextData, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTを指定件数分全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">検索件数</param>		
        /// <returns>STATUS</returns>
        public int SearchSpecification(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status = SearchProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, readCnt);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchSpecification Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTを全て戻します
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();
            PriceChgProcStWork = null;

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
                // XMLの読み込み
                PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                //件数指定リードで一件目リードの場合データ総件数を取得

                string sqlTxt = string.Empty; // 2008.05.21 add

                if (readCnt > 0)//&&(PriceChgProcStWork.TaxRateCode == 0))//||(PriceChgProcStWork.TaxRateSetCode == "")))
                {
                    SqlCommand sqlCommandCount;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.21 upd start ----------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        // 2008.05.21 upd start ----------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        // 2008.05.21 upd start ----------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                    }
                    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }

                //		SqlCommand sqlCommand;

                sqlTxt = string.Empty;   // 2008.05.21 add

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //件数指定無しの場合

                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;

                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
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

                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;

                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
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
                    PriceChgProcStWork wkPriceChgProcStWork = new PriceChgProcStWork();

                    wkPriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkPriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkPriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkPriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkPriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkPriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkPriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkPriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                    wkPriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                    wkPriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                    wkPriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkPriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                    wkPriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                    // 2009/12/11 Add >>>
                    wkPriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                    // 2009/12/11 Add <<<


                    al.Add(wkPriceChgProcStWork);

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
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // XMLへ変換し、文字列のバイナリ化
            PriceChgProcStWork[] PriceChgProcStWorks = (PriceChgProcStWork[])al.ToArray(typeof(PriceChgProcStWork));
            retbyte = XmlByteSerializer.Serialize(PriceChgProcStWorks);

            return status;
        }

        /// <summary>
        /// 指定された企業コードの価格改正設定LISTを全て戻します
        /// </summary>
        /// <param name="objPriceChgProcStWork">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref object objPriceChgProcStWork, out int retTotalCnt, out bool nextData, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();
            PriceChgProcStWork PriceChgProcStWork = null;

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
                ArrayList PriceChgProcStWorkList = objPriceChgProcStWork as ArrayList;
                if (PriceChgProcStWorkList != null)
                {
                    // XMLの読み込み
                    PriceChgProcStWork = PriceChgProcStWorkList[0] as PriceChgProcStWork;

                    //コネクション生成
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;

                    sqlConnection.Open();

                    string sqlTxt = string.Empty;

                    //件数指定リードで一件目リードの場合データ総件数を取得

                    if (readCnt > 0)
                    {
                        SqlCommand sqlCommandCount;
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                            //論理削除区分設定
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);

                            //論理削除区分設定
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                            else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                        }
                        else
                        {
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        }
                        SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                        retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    }

                    //		SqlCommand sqlCommand;

                    sqlTxt = string.Empty;  // 2008.05.21 add

                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.21 upd start ------------------------------------>>
                        //sqlCommand = new SqlCommand("SELECT * FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add >>>
                        sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add <<<
                        sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add >>>
                        sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add <<<
                        sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add >>>
                        sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add <<<
                        sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    int retCnt = 0;
                    while (myReader.Read())
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
                        PriceChgProcStWork wkPriceChgProcStWork = new PriceChgProcStWork();

                        wkPriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkPriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkPriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkPriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkPriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkPriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkPriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkPriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkPriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                        wkPriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                        wkPriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                        wkPriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                        wkPriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                        wkPriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                        // 2009/12/11 Add >>>
                        wkPriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                        // 2009/12/11 Add <<<

                        al.Add(wkPriceChgProcStWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objPriceChgProcStWork = al;

            return status;
        }


        #region インターフェースで公開しないメソッド
        /// <summary>
        /// 指定された企業コードの価格改正設定LISTを全て戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="PriceChgProcStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        public int Search(out ArrayList retList, PriceChgProcStWork PriceChgProcStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchProc(out retList, PriceChgProcStWork, readMode, logicalMode, ref sqlConnection);
        }
        private int SearchProc(out ArrayList retList, PriceChgProcStWork PriceChgProcStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    PriceChgProcStWork wkPriceChgProcStWork = new PriceChgProcStWork();

                    wkPriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkPriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkPriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkPriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkPriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkPriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkPriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkPriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                    wkPriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                    wkPriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                    wkPriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkPriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                    wkPriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                    // 2009/12/11 Add >>>
                    wkPriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                    // 2009/12/11 Add <<<

                    al.Add(wkPriceChgProcStWork);

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
                base.WriteErrorLog(ex, "PriceChgProcStDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            retList = al;

            return status;
        }

        /// <summary>
        /// 価格改正設定を読み込みます。
        /// </summary>
        /// <param name="PriceChgProcStWork">価格改正設定マスタ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>STATUS</returns>
        public int Read(ref PriceChgProcStWork PriceChgProcStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref PriceChgProcStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        private int ReadProc(ref PriceChgProcStWork PriceChgProcStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string queryString = string.Empty;

                queryString += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                queryString += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                queryString += "    ,ENTERPRISECODERF" + Environment.NewLine;
                queryString += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                queryString += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                queryString += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                queryString += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                queryString += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                queryString += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                queryString += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                queryString += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                queryString += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                queryString += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                queryString += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                queryString += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                queryString += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                queryString += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                if (sqlTransaction == null)
                    sqlCommand = new SqlCommand(queryString, sqlConnection);
                else
                    sqlCommand = new SqlCommand(queryString, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    PriceChgProcStWork = CopyToPriceChgProcStWorkFromReader(ref myReader);
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
                base.WriteErrorLog(ex, "PriceChgProcStDB.Read(ref PriceChgProcStWork,int,ref SqlConnection,ref SqlTransaction) Exception=" + ex.Message);
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

            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        /// <summary>
        /// 指定された企業コードの価格改正設定を戻します
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }

        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();

            try
            {
                // XMLの読み込み
                PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                //Selectコマンドの生成	
                // 2008.05.21 upd start ------------------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------------------------<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    PriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    PriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    PriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    PriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    PriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    PriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    PriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    PriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    PriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                    PriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                    PriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                    PriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    PriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                    PriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                    // 2009/12/11 Add >>>
                    PriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                    // 2009/12/11 Add <<<
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
                base.WriteErrorLog(ex, "PriceChgProcStDB.Read Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // XMLへ変換し、文字列のバイナリ化
            parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);

            return status;
        }

        /// <summary>
        /// 価格改正設定情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWorkオブジェクト</param>
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
                PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                //Selectコマンドの生成
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != PriceChgProcStWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (PriceChgProcStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //既存データで更新日時違いの場合には排他
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }

                    // 2008.05.21 upd start ------------------------------------------->>
                    //sqlCommand.CommandText = "UPDATE PRICECHGPROCSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , "
                    //    +"TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "UPDATE PRICECHGPROCSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , NAMEUPDDIVRF=@NAMEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PARTSLAYERUPDDIVRF=@PARTSLAYERUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEUPDDIVRF=@PRICEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEMNGCNTRF=@PRICEMNGCNT" + Environment.NewLine;
                    sqlTxt += " , PRICECHGPROCDIVRF=@PRICECHGPROCDIV" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += " , BLGOODSCDUPDDIVRF=@BLGOODSCDUPDDIV" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end ---------------------------------------------<<

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)PriceChgProcStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (PriceChgProcStWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }

                    //新規作成時のSQL文を生成
                    // 2008.05.21 upd start ------------------------------------------->>
                    //sqlCommand.CommandText = "INSERT INTO PRICECHGPROCSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, "
                    //    +"@ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                    sqlTxt = string.Empty;

                    sqlTxt += "INSERT INTO PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
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
                    sqlTxt += "    ,@NAMEUPDDIV" + Environment.NewLine;
                    sqlTxt += "    ,@PARTSLAYERUPDDIV" + Environment.NewLine;
                    sqlTxt += "    ,@PRICEUPDDIV" + Environment.NewLine;
                    sqlTxt += "    ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlTxt += "    ,@PRICEMNGCNT" + Environment.NewLine;
                    sqlTxt += "    ,@PRICECHGPROCDIV" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,@BLGOODSCDUPDDIV" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end ---------------------------------------------<<

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)PriceChgProcStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (!myReader.IsClosed) myReader.Close();

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

                SqlParameter paraNameUpdDiv = sqlCommand.Parameters.Add("@NAMEUPDDIV", SqlDbType.Int);
                SqlParameter paraPartsLayerUpdDiv = sqlCommand.Parameters.Add("@PARTSLAYERUPDDIV", SqlDbType.Int);
                SqlParameter paraPriceUpdDiv = sqlCommand.Parameters.Add("@PRICEUPDDIV", SqlDbType.Int);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraPriceMngCnt = sqlCommand.Parameters.Add("@PRICEMNGCNT", SqlDbType.Int);
                SqlParameter paraPriceChgProcDiv = sqlCommand.Parameters.Add("@PRICECHGPROCDIV", SqlDbType.Int);
                // 2009/12/11 Add >>>
                SqlParameter paraBLGoodsCdUpdDiv = sqlCommand.Parameters.Add("@BLGOODSCDUPDDIV", SqlDbType.Int);
                // 2009/12/11 Add <<<

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(PriceChgProcStWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(PriceChgProcStWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(PriceChgProcStWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.LogicalDeleteCode);
                paraNameUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.NameUpdDiv);
                paraPartsLayerUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PartsLayerUpdDiv);
                paraPriceUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PriceUpdDiv);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.OpenPriceDiv);
                paraPriceMngCnt.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PriceMngCnt);
                paraPriceChgProcDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PriceChgProcDiv);
                // 2009/12/11 Add >>>
                paraBLGoodsCdUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.BLGoodsCdUpdDiv);
                // 2009/12/11 Add <<<
                #endregion

                sqlCommand.ExecuteNonQuery();

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 価格改正設定情報を論理削除します
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        public int LogicalDelete(ref byte[] parabyte)
        {
            //			return LogicalDeleteProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteProc(ref parabyte, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.LogicalDelete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 論理削除価格改正設定情報を復活します
        /// </summary>
        /// <param name="parabyte">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref byte[] parabyte)
        {
            //			return LogicalDeleteProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteProc(ref parabyte, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.RevivalLogicalDelete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 価格改正設定情報の論理削除を操作します
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteProc(ref byte[] parabyte, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XMLの読み込み
                PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();
                // 2008.05.21 upd start --------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, TAXRATECODERF FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end -----------------------------------------<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != PriceChgProcStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    //現在の論理削除区分を取得
                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.21 upd start -------------------------------------------------------->>
                    //sqlCommand.CommandText = "UPDATE PRICECHGPROCSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "UPDATE PRICECHGPROCSTRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , NAMEUPDDIVRF=@NAMEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PARTSLAYERUPDDIVRF=@PARTSLAYERUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEUPDDIVRF=@PRICEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEMNGCNTRF=@PRICEMNGCNT" + Environment.NewLine;
                    sqlTxt += " , PRICECHGPROCDIVRF=@PRICECHGPROCDIV" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += " , BLGOODSCDUPDDIVRF=@BLGOODSCDUPDDIV" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;

                    // 2008.05.21 upd end ----------------------------------------------------------<<

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)PriceChgProcStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();

                //論理削除モードの場合
                if (procMode == 0)
                {
                    if (logicalDelCd == 3)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    else if (logicalDelCd == 0) PriceChgProcStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                    else PriceChgProcStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                }
                else
                {
                    if (logicalDelCd == 1) PriceChgProcStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                    else
                    {
                        if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                        else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
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
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(PriceChgProcStWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.LogicalDeleteCode);

                sqlCommand.ExecuteNonQuery();

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 価格改正設定情報を物理削除します
        /// </summary>
        /// <param name="parabyte">価格改正設定オブジェクト</param>
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
                PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // 2008.05.21 upd start ----------------------------------->>
                //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, TAXRATECODERF FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end -------------------------------------<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
                    if (_updateDateTime != PriceChgProcStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }

                    // 2008.05.21 upd start --------------------------------->>
                    //sqlCommand.CommandText = "DELETE FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end -----------------------------------<<

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
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
                //sqlCommand = new SqlCommand("SELECT * FROM PRICECHGPROCSTRF ", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToPriceChgProcStWorkFromReader(ref myReader));
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
        /// SqlDataReader -> PriceChgProcStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PriceChgProcStWork</returns>
        private PriceChgProcStWork CopyToPriceChgProcStWorkFromReader(ref SqlDataReader myReader)
        {
            PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();
            PriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            PriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            PriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            PriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            PriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            PriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            PriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            PriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            PriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
            PriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
            PriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
            PriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            PriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
            PriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
            // 2009/12/11 Add >>>
            PriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
            // 2009/12/11 Add <<<
            return PriceChgProcStWork;
        }
        #endregion

    }

}

