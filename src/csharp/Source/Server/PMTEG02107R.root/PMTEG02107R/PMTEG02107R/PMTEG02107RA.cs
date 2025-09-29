//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形明細表DBリモートオブジェクト
// プログラム概要   : 手形明細表実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/4/28  修正内容 : 新規作成
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
    /// 手形明細表 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形明細表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.28</br>
    /// </remarks>
    [Serializable]
    public class TegataMeisaiListReportResultDB : RemoteDB , ITegataMeisaiListReportResultDB
    {
       #region クラスコンストラクタ
        /// <summary>
        /// 手形明細表コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public TegataMeisaiListReportResultDB()
            : base("PMTEG02109D", "Broadleaf.Application.Remoting.ParamData.TegataMeisaiListReportResultWork", "TegataMeisaiListReportRESULT")
        {

        }
        #endregion

       #region [Search]
        #region 指定された条件の手形明細表一覧表情報LISTの取得処理
        /// <summary>
        /// 指定された条件の手形明細表一覧表情報LISTを戻します
        /// </summary>
        /// <param name="TegataMeisaiListReportResultWork">検索結果</param>
        /// <param name="TegataMeisaiListReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の手形明細表情報LISTを戻します</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public int Search(out object TegataMeisaiListReportResultWork, object TegataMeisaiListReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TegataMeisaiListReportResultWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out TegataMeisaiListReportResultWork, TegataMeisaiListReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "TegataMeisaiListReportResultDB.Search");
                TegataMeisaiListReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TegataMeisaiListReportResultDB.Search");
                TegataMeisaiListReportResultWork = new ArrayList();
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

        #region 指定された条件の手形明細表一覧表情報LIST(外部からのSqlConnectionを使用)
        /// <summary>
        /// 指定された条件の手形明細表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果検索パラメータ</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の手形明細表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            TegataMeisaiListReportParaWork paraWork = null;
            paraWork = paraObj as TegataMeisaiListReportParaWork;

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

                // ソート順の設定
                selectTxt.Append(SortSql(paraWork));

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToTegataMeisaiListReportResultWorkFromReader(ref myReader, paraWork));
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
                status = base.WriteSQLErrorLog(sqlex, "TegataMeisaiListReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TegataMeisaiListReportResultDB.SearchProc" + status);
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
        /// <br>Date       : 2010.04.28</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, TegataMeisaiListReportParaWork paraWork)
        {
            #region [取得項目]
            selectTxt1 = SelectRow(paraWork, selectTxt1);    
            #endregion
            #region [テーブル]
            selectTxt1.Append("FROM ");
            selectTxt1.Append("RCVDRAFTDATARF A ");               // 受取手形データ
            #endregion
            #region [抽出条件]
            MakeWhereString(ref selectTxt1, ref sqlCommand, paraWork);
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
        /// <br>Date       : 2010.04.28</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, TegataMeisaiListReportParaWork paraWork)
        {
            #region [取得項目]
            selectTxt2 = SelectRow(paraWork, selectTxt2);
            #endregion
            #region [テーブル]
            selectTxt2.Append("FROM ");
            selectTxt2.Append("PAYDRAFTDATARF A "); // 支払手形データ
            #endregion
            #region [抽出条件]
            MakeWhereString(ref selectTxt2, ref sqlCommand, paraWork);
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
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private StringBuilder SelectRow(TegataMeisaiListReportParaWork paraWork, StringBuilder selectTxt)
        {
            //　手形区分＝受取手形
            if (0 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.ENTERPRISECODERF ENTERPRISECODERF, ");            // 企業コード
                selectTxt.Append("A.LOGICALDELETECODERF LOGICALDELETECODERF, ");            // 論理削除区分
                selectTxt.Append("A.RCVDRAFTNORF RCVDRAFTNORF, ");            // 受取手形番号
                selectTxt.Append("A.DRAFTKINDCDRF DRAFTKINDCDRF, ");            // 手形種別
                selectTxt.Append("A.BANKANDBRANCHCDRF BANKANDBRANCHCDRF, ");            // 銀行・支店コード
                selectTxt.Append("A.BANKANDBRANCHNMRF BANKANDBRANCHNMRF, ");            // 銀行・支店名称
                selectTxt.Append("A.ADDUPSECCODERF ADDUPSECCODERF, ");            // 計上拠点コード
                selectTxt.Append("A.DRAFTDRAWINGDATERF DRAFTDRAWINGDATERF, ");            // 手形振出日
                selectTxt.Append("A.OUTLINE1RF OUTLINE1RF, ");            // 伝票摘要1
                selectTxt.Append("A.OUTLINE2RF OUTLINE2RF, ");            //伝票摘要2
                selectTxt.Append("A.DEPOSITDATERF DEPOSITDATERF, ");            // 入金日
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
                selectTxt.Append("A.ENTERPRISECODERF ENTERPRISECODERF, ");            // 企業コード
                selectTxt.Append("A.LOGICALDELETECODERF LOGICALDELETECODERF, ");            // 論理削除区分
                selectTxt.Append("A.PAYDRAFTNORF RCVDRAFTNORF, ");            // 受取手形番号
                selectTxt.Append("A.DRAFTKINDCDRF DRAFTKINDCDRF, ");            // 手形種別
                selectTxt.Append("A.BANKANDBRANCHCDRF BANKANDBRANCHCDRF, ");            // 銀行・支店コード
                selectTxt.Append("A.BANKANDBRANCHNMRF BANKANDBRANCHNMRF, ");            // 銀行・支店名称
                selectTxt.Append("A.ADDUPSECCODERF ADDUPSECCODERF, ");            // 計上拠点コード
                selectTxt.Append("A.DRAFTDRAWINGDATERF DRAFTDRAWINGDATERF, ");            // 手形振出日
                selectTxt.Append("A.OUTLINE1RF OUTLINE1RF, ");            // 伝票摘要1
                selectTxt.Append("A.OUTLINE2RF OUTLINE2RF, ");            //伝票摘要2
                selectTxt.Append("A.PAYMENTDATERF DEPOSITDATERF, ");            // 支払日
                selectTxt.Append("A.SUPPLIERCDRF CUSTOMERCODERF, ");            // 仕入先コード
                selectTxt.Append("A.SUPPLIERSNMRF CUSTOMERSNMRF, ");            //仕入先略称
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
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataMeisaiListReportParaWork paraWork)
        {
            // 論理削除区分
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");
            // 企業コード=パラメータ.企業コード
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // 画面指定の手形区分が「受取手形」の場合
            if (paraWork.DraftDivide == 0)
            {
                // 画面の入金日(開始)が入力された場合
                if (paraWork.DepositDateSt != DateTime.MinValue)
                {
                    sql.Append(" AND A.DEPOSITDATERF >= @FINDDEPOSITDATEST ");
                    SqlParameter paraStDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEST", SqlDbType.Int);
                    paraStDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateSt);
                }
                // 画面の入金日(終了)が入力された場合
                if (paraWork.DepositDateEd != DateTime.MinValue)
                {
                    sql.Append(" AND A.DEPOSITDATERF <= @FINDDEPOSITDATEED ");
                    SqlParameter paraEdDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEED", SqlDbType.Int);
                    paraEdDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateEd);
                }
            }
            // 画面指定の手形区分が「支払手形」の場合
            else
            {
                // 画面の支払日(開始)が入力された場合
                if (paraWork.DepositDateSt != DateTime.MinValue)
                {
                    sql.Append(" AND A.PAYMENTDATERF >= @FINDDEPOSITDATEST ");
                    SqlParameter paraStDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEST", SqlDbType.Int);
                    paraStDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateSt);
                }
                // 画面の支払日(終了)が入力された場合
                if (paraWork.DepositDateEd != DateTime.MinValue)
                {
                    sql.Append(" AND A.PAYMENTDATERF <= @FINDDEPOSITDATEED ");
                    SqlParameter paraEdDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATEED", SqlDbType.Int);
                    paraEdDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.DepositDateEd);
                }
 
            }

            // 画面の満期日(開始)が入力された場合
            if (paraWork.MaturityDateSt != DateTime.MinValue)
            {
                sql.Append(" AND A.VALIDITYTERMRF >= @FINDMATURITYDATEST ");
                SqlParameter paraStMaturityDate = sqlCommand.Parameters.Add("@FINDMATURITYDATEST", SqlDbType.Int);
                paraStMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.MaturityDateSt);
            }
            // 画面の満期日(終了)が入力された場合
            if (paraWork.MaturityDateEd != DateTime.MinValue)
            {
                sql.Append(" AND A.VALIDITYTERMRF <= @FINDMATURITYDATEED ");
                SqlParameter paraEdMaturityDate = sqlCommand.Parameters.Add("@FINDMATURITYDATEED", SqlDbType.Int);
                paraEdMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.MaturityDateEd);
            }

            // 画面の銀行・支店コード(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.BankAndBranchCdSt)) 　
            {
                sql.Append(" AND A.BANKANDBRANCHCDRF >= @FINDSTBANKANDBRANCHCD ");
                SqlParameter paraStBankCode = sqlCommand.Parameters.Add("@FINDSTBANKANDBRANCHCD", SqlDbType.Int);
                paraStBankCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.BankAndBranchCdSt));
            }
            // 画面の銀行・支店コード(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.BankAndBranchCdEd)) 　
            {
                sql.Append(" AND A.BANKANDBRANCHCDRF <= @FINDEDBANKANDBRANCHCD  ");
                SqlParameter paraEdBankCode = sqlCommand.Parameters.Add("@FINDEDBANKANDBRANCHCD", SqlDbType.Int);
                paraEdBankCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.BankAndBranchCdEd));
            }

            // 手形種別
            if (paraWork.DraftKindCds != null)
            {
                string draftKindString = "";
                foreach (string draftKindCode in paraWork.DraftKindCds)
                {
                    if (!string.IsNullOrEmpty(draftKindCode))
                    {
                        if (!string.IsNullOrEmpty(draftKindString))
                        {
                            draftKindString += ",";
                        }
                        draftKindString += "'" + draftKindCode + "'";
                    }
                }
                if (!string.IsNullOrEmpty(draftKindString))
                {
                    // 手形種別
                    sql.Append(" AND A.DRAFTKINDCDRF IN (" + draftKindString + ")  ");

                }
            }
            return sql;
        }
        #endregion

        
        #region [ソート順を設定]
        /// <summary>
        /// ソート順の設定
        /// </summary>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : ソート順を設定する</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private StringBuilder SortSql(TegataMeisaiListReportParaWork paraWork)
        {
            StringBuilder sql = new StringBuilder(string.Empty);
            // 手形区分＝受取手形
            if (paraWork.DraftDivide == 0)
            {
                // 手形区分＝受取手形、出力順＝手形種別＋銀行/支店＋入金日＋満期日
                if (paraWork.SortOrder == 0)
                {
                    //手形種別
                    sql.Append("ORDER BY A.DRAFTKINDCDRF, ");
                    //銀行/支店
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //入金日
                    sql.Append("A.DEPOSITDATERF,  ");
                    //満期日
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //振出日
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //手形番号
                    sql.Append("A.RCVDRAFTNORF   ");
                }
                // 手形区分＝受取手形、出力順＝銀行/支店＋手形種別＋入金日＋満期日
                else if (paraWork.SortOrder == 1)
                {
                    //銀行/支店
                    sql.Append("ORDER BY A.BANKANDBRANCHCDRF,  ");
                    //手形種別
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //入金日
                    sql.Append("A.DEPOSITDATERF,  ");
                    //満期日
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //振出日
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //手形番号
                    sql.Append("A.RCVDRAFTNORF  ");

                }
                // 手形区分＝受取手形、出力順＝満期日＋銀行/支店＋手形種別＋入金日
                else
                {
                    //満期日
                    sql.Append("ORDER BY A.VALIDITYTERMRF,   ");
                    //銀行/支店
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //手形種別
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //入金日
                    sql.Append("A.DEPOSITDATERF,  ");
                    //振出日
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //手形番号
                    sql.Append("A.RCVDRAFTNORF  ");

                }
            }
            else
            {
                // 手形区分＝支払手形、出力順＝手形種別＋銀行/支店＋支払日＋満期日
                if (paraWork.SortOrder == 0)
                {
                    //手形種別
                    sql.Append("ORDER BY A.DRAFTKINDCDRF, ");
                    //銀行/支店
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //支払日
                    sql.Append("A.PAYMENTDATERF,  ");
                    //満期日
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //振出日
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //手形番号
                    sql.Append("A.PAYDRAFTNORF   ");
                }
                //手形区分＝支払手形、出力順＝銀行/支店＋手形種別＋支払日＋満期日
                else if (paraWork.SortOrder == 1)
                {
                    //銀行/支店
                    sql.Append("ORDER BY A.BANKANDBRANCHCDRF,  ");
                    //手形種別
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //支払日
                    sql.Append("A.PAYMENTDATERF,  ");
                    //満期日
                    sql.Append("A.VALIDITYTERMRF,   ");
                    //振出日
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //手形番号
                    sql.Append("A.PAYDRAFTNORF  ");

                }
                //手形区分＝支払手形、出力順＝満期日＋銀行/支店＋手形種別＋支払日
                else
                {
                    //満期日
                    sql.Append("ORDER BY A.VALIDITYTERMRF,   ");
                    //銀行/支店
                    sql.Append("A.BANKANDBRANCHCDRF,  ");
                    //手形種別
                    sql.Append("A.DRAFTKINDCDRF, ");
                    //支払日
                    sql.Append("A.PAYMENTDATERF,  ");
                    //振出日
                    sql.Append("A.DRAFTDRAWINGDATERF,  ");
                    //手形番号
                    sql.Append("A.PAYDRAFTNORF  ");
                }
            }
            return sql;
        }
        #endregion  [ソート順を設定]

       #endregion

        #region クラス格納処理
        /// <summary>
        /// クラス格納処理 Reader → TegataMeisaiListReportResultWork
        /// </summary>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : ReaderからTegataMeisaiListReportResultWorkへ変換します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private TegataMeisaiListReportResultWork CopyToTegataMeisaiListReportResultWorkFromReader(ref SqlDataReader myReader, TegataMeisaiListReportParaWork paraWork)
        {
            TegataMeisaiListReportResultWork listWork = new TegataMeisaiListReportResultWork();
            #region クラスへ格納

            // 手形種別
            listWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
            // 銀行・支店コード
            listWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
            // 銀行・支店名称
            listWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
            // 入金日/支払日
            listWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            // 振出日
            listWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            // 満期日
            listWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            // 手形区分
            listWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            // 受取手形番号
            listWork.RcvDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RCVDRAFTNORF"));
            // 計上拠点コード
            listWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            // 得意先コード
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // 得意先略称
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // 入金金額/支払金額
            listWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            // 伝票摘要1
            listWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
            // 伝票摘要2
            listWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));

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
        /// <br>Date       : 2010.04.28</br>
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
