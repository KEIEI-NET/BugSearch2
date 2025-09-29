using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 出荷部品表示DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷部品表示の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class SPartsDspDB : RemoteDB, ISPartsDspDB
    {
        /// <summary>
        /// 出荷部品表示DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        /// </remarks>
        public SPartsDspDB()
            :
            base("PMHNB04107D", "Broadleaf.Application.Remoting.ParamData.ShipmentPartsDspResultWork", "MTTLSALESSLIPRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の出荷部品表示データを戻します
        /// </summary>
        /// <param name="shipmentPartsDspResultWork">検索結果</param>
        /// <param name="shipmentPartsDspParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷部品表示データを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(out object shipmentPartsDspResultWork, object shipmentPartsDspParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            shipmentPartsDspResultWork = null;
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();// ADD 2011/03/22
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((ShipmentPartsDspParamWork)shipmentPartsDspParamWork).EnterpriseCode, "出荷部品表示", "抽出開始");// ADD 2011/03/22
                return SearchSPartsDsp(out shipmentPartsDspResultWork, shipmentPartsDspParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SPartsDspDB.Search");
                shipmentPartsDspResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((ShipmentPartsDspParamWork)shipmentPartsDspParamWork).EnterpriseCode, "出荷部品表示", "抽出終了");// ADD 2011/03/22
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の出荷部品表示データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objShipmentPartsDspResultWork">検索結果</param>
        /// <param name="objShipmentPartsDspParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷部品表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        private int SearchSPartsDsp(out object objShipmentPartsDspResultWork, object objShipmentPartsDspParamWork, ref SqlConnection sqlConnection)
        {
            ShipmentPartsDspParamWork paramWork = null;

            ArrayList paramWorkList = objShipmentPartsDspParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objShipmentPartsDspParamWork as ShipmentPartsDspParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ShipmentPartsDspParamWork;
            }

            ArrayList shipmentPartsDspResultWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 出荷部品表示データを取得
            status = SearchSPartsDspProc(out shipmentPartsDspResultWork, paramWork, ref sqlConnection);

            objShipmentPartsDspResultWork = shipmentPartsDspResultWork;
            return status;

        }
        #endregion  //Search

        #region [SearchSPartsDspProc]
        /// <summary>
        /// 指定された条件の出荷部品表示データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="shipmentPartsDspResultWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷部品表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        private int SearchSPartsDspProc(out ArrayList shipmentPartsDspResultWorkList, ShipmentPartsDspParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SELECT]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "	ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "	,RSLTTTLDIVCDRF AS RSLTTTLDIVCD" + Environment.NewLine;
                sqlText += "	,SUM(SALESTIMESRF) AS SALESTIMES" + Environment.NewLine;
                sqlText += "	,SUM(GROSSPROFITRF) AS GROSSPROFIT" + Environment.NewLine;
                sqlText += "	,SUM(SALESMONEYRF+SALESRETGOODSPRICERF +DISCOUNTPRICERF) AS SALESMONEY" + Environment.NewLine; // ADD 2009.02.10
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "	MTTLSALESSLIPRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += " 	ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND LOGICALDELETECODERF=0" + Environment.NewLine;
                if (paramWork.SectionCode != "" && paramWork.SectionCode != "00")
                {
                    sqlText += " 	AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                }
                sqlText += " 	AND ADDUPYEARMONTHRF >= @STADDUPYEARMONTH" + Environment.NewLine;
                sqlText += " 	AND ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH" + Environment.NewLine;
                sqlText += " 	AND EMPLOYEEDIVCDRF = 10" + Environment.NewLine; // ADD 2009.02.10
                sqlText += "GROUP BY" + Environment.NewLine;
                sqlText += "	ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "	,RSLTTTLDIVCDRF" + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = sqlText;

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.StAddUpYearMonth);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.EdAddUpYearMonth);

                if (paramWork.SectionCode != "" && paramWork.SectionCode != "00")
                {
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                }

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 3600;
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSPartsDspWorkFromReader(ref myReader, paramWork));
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

            shipmentPartsDspResultWorkList = al;

            return status;
        }
        #endregion  //SearchSPartsDspProc

        #region [クラスへ格納]
        /// <summary>
        /// クラス格納処理 Reader → ShipmentPartsDspResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>ShipmentPartsDspResultWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
        /// </remarks>
        private ShipmentPartsDspResultWork CopyToSPartsDspWorkFromReader(ref SqlDataReader myReader, ShipmentPartsDspParamWork paramWork)
        {
            ShipmentPartsDspResultWork shipmentPartsDspResultWork = new ShipmentPartsDspResultWork();

            if (myReader != null)
            {
                # region クラスへ格納
                shipmentPartsDspResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                shipmentPartsDspResultWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCD"));
                shipmentPartsDspResultWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                shipmentPartsDspResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
                shipmentPartsDspResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                # endregion
            }

            return shipmentPartsDspResultWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.03</br>
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
        #endregion  //コネクション生成処理
    }

}
