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
    /// 売掛消費税差異表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛消費税差異表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081　山田 明友</br>
    /// <br>Date       : 2007.11.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.08  980081 山田 明友</br>
    /// <br>           : 消費税調整額の取得元変更(TaxAdjustRF→SalsePriceConsTaxRF)</br>
    /// <br>Update Note: 2008.09.30  22008 長内 数馬 PM.NS用に修正</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class AccRecConsTaxDiffDB : RemoteDB, IAccRecConsTaxDiffDB
    {
        /// <summary>
        /// 売掛消費税差異表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081　山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        /// </remarks>
        public AccRecConsTaxDiffDB()
            :
            base("DCKAU02626D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecConsTaxDiffWork", "SALESSLIPRF")
        {
        }

        /// <summary>
        /// 指定された条件の売掛消費税差異表LISTを戻します
        /// </summary>
        /// <param name="accRecConsTaxDiffWork">検索結果</param>
        /// <param name="paraAccRecConsTaxDiffWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛消費税差異表LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.08  980081 山田 明友</br>
        /// <br>           : 消費税調整額の取得元変更(TaxAdjustRF→SalsePriceConsTaxRF)</br>
        public int SearchAccRecConsTaxDiffProc(out object accRecConsTaxDiffWork, object paraAccRecConsTaxDiffWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            accRecConsTaxDiffWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAccRecConsTaxDiffProc(out accRecConsTaxDiffWork, paraAccRecConsTaxDiffWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecConsTaxDiffDB.SearchAccRecConsTaxDiffProc");
                accRecConsTaxDiffWork = new ArrayList();
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
        /// 指定された条件の売掛消費税差異表LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objAccRecConsTaxDiffWork">検索結果</param>
        /// <param name="paraAccRecConsTaxDiffWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛消費税差異表LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.08  980081 山田 明友</br>
        /// <br>           : 消費税調整額の取得元変更(TaxAdjustRF→SalsePriceConsTaxRF)</br>
        public int SearchAccRecConsTaxDiffProc(out object objAccRecConsTaxDiffWork, object paraAccRecConsTaxDiffWork, ref SqlConnection sqlConnection)
        {
            ExtrInfo_AccRecConsTaxDiffWork extrInfo_AccRecConsTaxDiffWork = null;

            ArrayList paraAccRecConsTaxDiffWorkList = paraAccRecConsTaxDiffWork as ArrayList;
            ArrayList accRecConsTaxDiffWorkList = new ArrayList();

            if (paraAccRecConsTaxDiffWorkList == null)
            {
                extrInfo_AccRecConsTaxDiffWork = paraAccRecConsTaxDiffWork as ExtrInfo_AccRecConsTaxDiffWork;
            }
            else
            {
                if (paraAccRecConsTaxDiffWorkList.Count > 0)
                    extrInfo_AccRecConsTaxDiffWork = paraAccRecConsTaxDiffWorkList[0] as ExtrInfo_AccRecConsTaxDiffWork;
            }

            int status = SearchAccRecConsTaxDiffProc(out accRecConsTaxDiffWorkList, extrInfo_AccRecConsTaxDiffWork, ref sqlConnection);
            objAccRecConsTaxDiffWork = accRecConsTaxDiffWorkList;
            return status;

        }

        /// <summary>
        /// 指定された条件の売掛消費税差異表LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="accRecConsTaxDiffWorkList">検索結果</param>
        /// <param name="extrInfo_AccRecConsTaxDiffWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛消費税差異表LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.08  980081 山田 明友</br>
        /// <br>           : 消費税調整額の取得元変更(TaxAdjustRF→SalsePriceConsTaxRF)</br>
        public int SearchAccRecConsTaxDiffProc(out ArrayList accRecConsTaxDiffWorkList, ExtrInfo_AccRecConsTaxDiffWork extrInfo_AccRecConsTaxDiffWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, extrInfo_AccRecConsTaxDiffWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAccRecConsTaxDiffWorkFromReader(ref myReader, extrInfo_AccRecConsTaxDiffWork));

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

            accRecConsTaxDiffWorkList = al;

            return status;
        }

        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="accRecConsTaxDiffWork">検索条件格納クラス</param>
        /// <returns>売掛消費税差異表のSQL文字列</returns>
        /// <br>Note       : 売掛消費税差異表のSQLを作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, ExtrInfo_AccRecConsTaxDiffWork accRecConsTaxDiffWork)
        {
            #region Select文
            string sqlString = "";
            sqlString += "SELECT" + Environment.NewLine;
            sqlString += "   SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
            sqlString += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
            sqlString += "  ,SAL.SALESDATERF" + Environment.NewLine;
            sqlString += "  ,SAL.CLAIMCODERF" + Environment.NewLine;
            sqlString += "  ,SAL.CLAIMSNMRF" + Environment.NewLine;
            sqlString += "  ,SAL.SALESSUBTOTALTAXRF" + Environment.NewLine;
            sqlString += "  ,SAL.SALESGOODSCDRF" + Environment.NewLine;
            sqlString += "FROM SALESSLIPRF SAL" + Environment.NewLine;
            sqlString += "LEFT JOIN SECINFOSETRF SEC ON(SEC.ENTERPRISECODERF = SAL.ENTERPRISECODERF AND SEC.SECTIONCODERF = SAL.SECTIONCODERF)" + Environment.NewLine;
            #endregion

            #region Where文
            sqlString += "WHERE ";

            //企業コード
            sqlString += "SAL.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(accRecConsTaxDiffWork.EnterpriseCode);

            //論理削除区分
            sqlString += "AND SAL.LOGICALDELETECODERF=0 ";

            //受注ステータス
            sqlString += "AND SAL.ACPTANODRSTATUSRF=30 ";

            //売上商品区分
            sqlString += "AND SAL.SALESGOODSCDRF IN (4,10) ";

            //0円以外を対象とする
            sqlString += "AND SAL.SALESSUBTOTALTAXRF!=0 ";

            //実績計上拠点コード
            if (accRecConsTaxDiffWork.SecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in accRecConsTaxDiffWork.SecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    sqlString += "AND SAL.RESULTSADDUPSECCDRF IN (" + sectionString + ") ";
                }
            }

            //売上日付(開始)
            if (accRecConsTaxDiffWork.St_SalesDate != 0)
            {
                sqlString += "AND SAL.SALESDATERF>=@ST_SALESDATE ";
                SqlParameter paraSt_SalesDate = sqlCommand.Parameters.Add("@ST_SALESDATE", SqlDbType.Int);
                paraSt_SalesDate.Value = SqlDataMediator.SqlSetInt32(accRecConsTaxDiffWork.St_SalesDate);
            }

            //売上日付(終了)
            if (accRecConsTaxDiffWork.Ed_SalesDate != 0)
            {
                sqlString += "AND SAL.SALESDATERF<=@ED_SALESDATE ";
                SqlParameter paraEd_SalesDate = sqlCommand.Parameters.Add("@ED_SALESDATE", SqlDbType.Int);
                paraEd_SalesDate.Value = SqlDataMediator.SqlSetInt32(accRecConsTaxDiffWork.Ed_SalesDate);
            }

            #endregion

            sqlString += "ORDER BY SAL.SECTIONCODERF, SAL.SALESDATERF, SAL.CLAIMCODERF, SAL.SALESSLIPNUMRF ";

            return sqlString;
        }

        /// <summary>
        /// クラス格納処理 Reader → RsltInfo_AccRecConsTaxDiffWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_AccRecConsTaxDiffWork">検索パラメータ</param>
        /// <returns>RsltInfo_AccRecConsTaxDiffWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
        /// </remarks>
        private RsltInfo_AccRecConsTaxDiffWork CopyToAccRecConsTaxDiffWorkFromReader(ref SqlDataReader myReader, ExtrInfo_AccRecConsTaxDiffWork extrInfo_AccRecConsTaxDiffWork)
        {
            RsltInfo_AccRecConsTaxDiffWork wkAccRecConsTaxDiffWork = new RsltInfo_AccRecConsTaxDiffWork();

            #region クラスへ格納
            wkAccRecConsTaxDiffWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            wkAccRecConsTaxDiffWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkAccRecConsTaxDiffWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkAccRecConsTaxDiffWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkAccRecConsTaxDiffWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkAccRecConsTaxDiffWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            wkAccRecConsTaxDiffWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            //消費税備考
            if (wkAccRecConsTaxDiffWork.SalesGoodsCd == 4)
            {
                wkAccRecConsTaxDiffWork.TaxNote = "売掛用消費税調整";
            }
            else if (wkAccRecConsTaxDiffWork.SalesGoodsCd == 10)
            {
                wkAccRecConsTaxDiffWork.TaxNote = "売掛用消費税調整(自動)";
            }
            #endregion

            return wkAccRecConsTaxDiffWork;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081　山田 明友</br>
        /// <br>Date       : 2007.11.13</br>
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
    }
}
