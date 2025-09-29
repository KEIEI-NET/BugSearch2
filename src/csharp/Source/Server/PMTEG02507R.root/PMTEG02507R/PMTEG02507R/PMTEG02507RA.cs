//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形取引先別表DBリモートオブジェクト
// プログラム概要   : 手形取引先別表実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/4/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 手形取引先別表 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形取引先別表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    [Serializable]
    public class TegataTorihikisakiListReportResultDB : RemoteDB , ITegataTorihikisakiListReportResultDB
    {
       #region クラスコンストラクタ
        /// <summary>
        /// 手形取引先別表コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public TegataTorihikisakiListReportResultDB()
            : base("PMTEG02509D", "Broadleaf.Application.Remoting.ParamData.TegataTorihikisakiListReportResultWork", "TegataTorihikisakiListReportRESULT")
        {

        }
        #endregion

       #region [Search]
        #region 指定された条件の手形取引先別表一覧表情報LISTの取得処理
        /// <summary>
        /// 指定された条件の手形取引先別表一覧表情報LISTを戻します
        /// </summary>
        /// <param name="TegataTorihikisakiListReportResultWork">検索結果</param>
        /// <param name="TegataTorihikisakiListReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の手形取引先別表情報LISTを戻します</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int Search(out object TegataTorihikisakiListReportResultWork, object TegataTorihikisakiListReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TegataTorihikisakiListReportResultWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out TegataTorihikisakiListReportResultWork, TegataTorihikisakiListReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "TegataTorihikisakiListReportResultDB.Search");
                TegataTorihikisakiListReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TegataTorihikisakiListReportResultDB.Search");
                TegataTorihikisakiListReportResultWork = new ArrayList();
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
            return status;
        }
        #endregion

        #region 指定された条件の手形取引先別表一覧表情報LIST(外部からのSqlConnectionを使用)
        /// <summary>
        /// 指定された条件の手形取引先別表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果検索パラメータ</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の手形取引先別表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            TegataTorihikisakiListReportParaWork paraWork = null;
            paraWork = paraObj as TegataTorihikisakiListReportParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // 受取手形データsql
            StringBuilder selectTxt1 = new StringBuilder(string.Empty);
            // 支払手形データsql
            StringBuilder selectTxt2 = new StringBuilder(string.Empty);

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                // 画面指定の手形区分が「受取手形」の場合
                if (0 == paraWork.DraftDivide)
                {
                    selectTxt = MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork);

                }
                // 画面指定の手形区分が「支払手形」の場合
                else if (1 == paraWork.DraftDivide)
                {
                    selectTxt.Append(MakeSearchSQL2(ref selectTxt2, ref sqlCommand, paraWork));
                }
                if (0 == paraWork.DraftDivide)
                {
                    //拠点コード
                    selectTxt.Append("ORDER BY A.SECTIONCODERF, ");
                    //得意先コード
                    selectTxt.Append("A.CUSTOMERCODERF,  ");
                    //有効期限
                    selectTxt.Append("A.VALIDITYTERMRF  ");
                }
                else
                {
                    //拠点コード
                    selectTxt.Append("ORDER BY A.SECTIONCODERF, ");
                    //仕入先コード
                    selectTxt.Append("A.SUPPLIERCDRF,  ");
                    //有効期限
                    selectTxt.Append("A.VALIDITYTERMRF  ");
 
                }

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToTegataTorihikisakiListReportResultWorkFromReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "TegataTorihikisakiListReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TegataTorihikisakiListReportResultDB.SearchProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;
        }
        #endregion

        #region 検索用受取手形データ取得処理
        /// <summary>
        /// 検索用受取手形データ取得処理
        /// </summary>
        /// <param name="selectTxt1">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 検索用受取手形データを取得します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            #region [取得項目]
            selectTxt1 = SelectRow(paraWork, selectTxt1);    
            #endregion
            #region [テーブル]
            selectTxt1.Append("FROM ");
            selectTxt1.Append("RCVDRAFTDATARF A ");               // 受取手形データ
            #endregion
            #region [抽出条件]
            MakeWhereString1(ref selectTxt1, ref sqlCommand, paraWork);
            #endregion

            return selectTxt1;
            
        }
        #endregion

        #region 検索用支払手形データ取得処理
        /// <summary>
        /// 検索用支払手形データ取得処理
        /// </summary>
        /// <param name="selectTxt2">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 検索用支払手形データを取得します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            #region [取得項目]
            selectTxt2 = SelectRow(paraWork, selectTxt2);
            #endregion
            #region [テーブル]
            selectTxt2.Append("FROM ");
            selectTxt2.Append("PAYDRAFTDATARF A "); // 支払手形データ
            #endregion
            #region [抽出条件]
            MakeWhereString2(ref selectTxt2, ref sqlCommand, paraWork);
            #endregion

            return selectTxt2;
        }
        #endregion

        #region [取得項目]
        /// <summary>
        /// 取得項目
        /// </summary>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="selectTxt">sql文</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private StringBuilder SelectRow(TegataTorihikisakiListReportParaWork paraWork, StringBuilder selectTxt)
        {
            //　手形区分＝受取手形
            if (0 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.CUSTOMERCODERF CUSTOMERCODERF, ");            // 得意先コード
                selectTxt.Append("A.CUSTOMERSNMRF CUSTOMERSNMRF, ");            // 得意先略称
                selectTxt.Append("A.SECTIONCODERF SECTIONCODERF, ");            // 拠点コード
                selectTxt.Append("A.VALIDITYTERMRF VALIDITYTERMRF, ");            // 有効期限
                selectTxt.Append("A.DRAFTDIVIDERF DRAFTDIVIDERF, ");            // 手形区分
                selectTxt.Append("A.DEPOSITRF DEPOSITRF ");                  // 入金金額
            }
            //　手形区分＝支払手形
            else if (1 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.SUPPLIERCDRF CUSTOMERCODERF, ");            // 仕入先コード
                selectTxt.Append("A.SUPPLIERSNMRF CUSTOMERSNMRF, ");            // 仕入先略称
                selectTxt.Append("A.SECTIONCODERF SECTIONCODERF, ");            // 拠点コード
                selectTxt.Append("A.VALIDITYTERMRF VALIDITYTERMRF, ");            // 有効期限
                selectTxt.Append("A.DRAFTDIVIDERF DRAFTDIVIDERF, ");            // 手形区分
                selectTxt.Append("A.PAYMENTRF DEPOSITRF ");                  // 支払金額
            }
            return selectTxt;
        }
        #endregion [取得項目]

        #region [Where文作成処理]
        /// <summary>
        /// 受取手形データ検索条件文字列生成処理と条件値設定処理
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private StringBuilder MakeWhereString1(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            // 論理削除区分
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");
            // 企業コード=パラメータ.企業コード
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE1 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // 拠点コード
            if (paraWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCodes)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // 拠点コード
                    sql.Append(" AND A.SECTIONCODERF IN (" + sectionString + ")  ");

                }
            }

            // 有効期限 
            if (paraWork.SalesDate != DateTime.MinValue)
            {
                // 有効期限 >= 印刷範囲年月
                sql.Append(" AND A.VALIDITYTERMRF >= @FINDSTARTYEARDATE ");
                SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SalesDate);
            }
            // 画面の取引先(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt)) 　
            {
                sql.Append(" AND A.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // 画面の取引先(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd)) 　
            {
                sql.Append(" AND A.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }

            return sql;
        }

        /// <summary>
        /// 支払手形データ検索条件文字列生成処理と条件値設定処理
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private StringBuilder MakeWhereString2(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            // 論理削除区分
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");

            // 企業コード=パラメータ.企業コード
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE2 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // 拠点コード
            if (paraWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCodes)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // 拠点コード
                    sql.Append(" AND A.SECTIONCODERF IN (" + sectionString + ")  ");

                }
            }
            // 有効期限
            if (paraWork.SalesDate != DateTime.MinValue)
            {
                // 有効期限 >= 印刷範囲年月
                sql.Append(" AND A.VALIDITYTERMRF >= @FINDSTARTYEARDATE ");
                SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SalesDate);
            }

            // 画面の取引先(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt))
            {
                sql.Append(" AND A.SUPPLIERCDRF >= @FINDSTCUSTOMERCODE2 ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE2", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // 画面の取引先(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd))
            {
                sql.Append(" AND A.SUPPLIERCDRF <= @FINDEDCUSTOMERCODE2  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE2", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }
            return sql;
        }
        #endregion

        #endregion

       #region クラス格納処理
        /// <summary>
        /// クラス格納処理 Reader → TegataTorihikisakiListReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : ReaderからTegataTorihikisakiListReportResultWorkへ変換します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private TegataTorihikisakiListReportResultWork CopyToTegataTorihikisakiListReportResultWorkFromReader(ref SqlDataReader myReader)
        {
            TegataTorihikisakiListReportResultWork listWork = new TegataTorihikisakiListReportResultWork();
            #region クラスへ格納

            // 拠点
            listWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            // 得意先コード
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // 得意先略称
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // 手形区分
            listWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            // 有効期限
            listWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            // 入金金額
            listWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));

            return listWork;
            #endregion
        }
        #endregion  クラス格納処理

       #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
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
