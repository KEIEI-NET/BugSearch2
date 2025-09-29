//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 修 正 日  2010/07/20  修正内容 : テキスト出力
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/12  修正内容 : 障害ID:13038対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/10/09  修正内容 : 障害ID:15880対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/22  修正内容 : 照会プログラムのログ出力対応
//----------------------------------------------------------------------------//


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
    /// 担当者別実績照会 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者別実績照会実データ操作を行うクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2010/08/12 chenyd</br>
    /// <br>            ・障害ID:13038 テキスト出力対応</br>
    /// <br>Update Note: 2010/08/17、 2010/08/20　chenyd</br>
    /// <br>            ・障害ID:13038 テキスト出力対応</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EmployeeResultsListWorkDB : RemoteDB, IEmployeeResultsListDB
    {
        #region Const
        /// <summary> 全社コード [00] </summary>
        private const string WHOLE_SECTION_CODE = "00";
        /// <summary> 未登録 </summary>
        private const string NOINPUT = "未登録";
        #endregion

        /// <summary>
        /// 担当者別実績照会DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public EmployeeResultsListWorkDB()
            :
        base("PMHNB04167D", "Broadleaf.Application.Remoting.ParamData.EmployeeResultsListResultWork", "EmployeeResults") //基底クラスのコンストラクタ
        {
        }

        #region 担当者別実績照会
        /// <summary>
        /// 指定された企業コードの担当者別実績照会LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="employeeResultsListResultWork">検索結果</param>
        /// <param name="employeeResultsListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの担当者別実績照会LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        public int Search(out object employeeResultsListResultWork, object employeeResultsListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            employeeResultsListResultWork = null;

            EmployeeResultsListCndtnWork _employeeResultsListCndtnWork = employeeResultsListCndtnWork as EmployeeResultsListCndtnWork;

            try
            {
                status = SearchProc(out employeeResultsListResultWork, _employeeResultsListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeResultsListWorkDB.Search Exception=" + ex.Message);
                employeeResultsListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの担当者別実績照会LISTを全て戻します
        /// </summary>
        /// <param name="employeeResultsListResultWork">検索結果</param>
        /// <param name="_employeeResultsListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの担当者別実績照会LISTを全て戻します</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br></br>
        private int SearchProc(out object employeeResultsListResultWork, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            employeeResultsListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _employeeResultsListCndtnWork.EnterpriseCode, "担当者別実績照会", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                status = SearchEmployeeResultsProc(ref al, ref sqlConnection, _employeeResultsListCndtnWork, logicalMode);

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _employeeResultsListCndtnWork.EnterpriseCode, "担当者別実績照会", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeResultsListWorkDB.SearchProc Exception=" + ex.Message);
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

            employeeResultsListResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_employeeResultsListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            ・障害ID:13038 テキスト出力対応</br>
        /// <br>Update Note: 2010/08/17 chenyd</br>
        /// <br>            ・障害ID:13038 テキスト出力対応</br>
        /// <br>Update Note: 2010/10/09 朱 猛</br>
        /// <br>            ・障害ID:15880 テキスト出力対応</br>
        private int SearchEmployeeResultsProc(ref ArrayList al, ref SqlConnection sqlConnection, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);

                StringBuilder sqlCmd = new StringBuilder(string.Empty);
                if (1 == _employeeResultsListCndtnWork.DuringType)
                {
                    #region 日計 Select文作成
                    sqlCmd.Append(" SELECT");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    //コード
                    sqlCmd.Append(" A.TMPEMPLOYEECODE AS CODE, ");
                    //売上金額
                    sqlCmd.Append(" (A.SUMSALES + B.SUMSUMSALESB) AS SUMMONEY, ");
                    //返品額
                    sqlCmd.Append(" (A.SUMRETURNGOODS + B.SUMRETURNGOODSB) AS RETURNMONEY, ");
                    //値引額
                    sqlCmd.Append(" B.SUMSALESMONEYTAXEXCRFB AS  SUMSALESMONEYTAXEXCRFB, ");
                    //伝票枚数
                    sqlCmd.Append(" A.TMPSALESSLIPNUMRF AS TMPSALESSLIPNUMRF, ");
                    //売上目標額
                    sqlCmd.Append(" C.SUMSALESTARGETMONEYRF AS SUMSALESTARGETMONEYRF, ");
                    //名称
                    sqlCmd.Append(" D.NAMERF AS NAMERF, ");
                    //原価
                    sqlCmd.Append(" A.SUMTOTALCOSTRF AS SUMTOTALCOSTRF ");

                    sqlCmd.Append(" FROM");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //拠点コード
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //sqlCmd.Append(" SECTIONCODERF AS SECTIONCODE, ");
                    //    sqlCmd.Append(" RESULTSADDUPSECCDRF AS SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" RESULTSADDUPSECCDRF AS SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        //担当者
                        //sqlCmd.Append(" SALESINPUTCODERF AS TMPEMPLOYEECODE, ");// DEL 2010/08/12 障害ID:13038対応
                        sqlCmd.Append(" SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");// ADD 2010/08/12 障害ID:13038対応
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //受注者
                        sqlCmd.Append(" FRONTEMPLOYEECDRF AS TMPEMPLOYEECODE, ");

                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        //発行者
                        //sqlCmd.Append(" SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");
                        sqlCmd.Append(" SALESINPUTCODERF AS TMPEMPLOYEECODE, ");

                    }

                    sqlCmd.Append(" SUM(CASE WHEN SALESSLIPCDRF=0 AND SALESGOODSCDRF =0 THEN SALESNETPRICERF ELSE 0 END) AS SUMSALES, ");
                    sqlCmd.Append(" SUM(CASE WHEN SALESSLIPCDRF=1 AND SALESGOODSCDRF =0 THEN SALESNETPRICERF ELSE 0 END) AS SUMRETURNGOODS, ");
                    sqlCmd.Append(" COUNT(SALESSLIPNUMRF) AS TMPSALESSLIPNUMRF,");
                    sqlCmd.Append(" SUM(TOTALCOSTRF) AS SUMTOTALCOSTRF");
                    sqlCmd.Append(" FROM SALESHISTORYRF");
                    MakeWhereString_SalesHis(ref sqlCommand, _employeeResultsListCndtnWork, "", sqlCmd, 0);

                    sqlCmd.Append(" ) AS A");
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //拠点コード
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //sqlCmd.Append(" E.SECTIONCODERF AS SECTIONCODE, ");// DEL 2010/08/12 障害ID:13038対応
                    //    sqlCmd.Append(" E.RESULTSADDUPSECCDRF AS SECTIONCODE, ");// ADD 2010/08/12 障害ID:13038対応
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" E.RESULTSADDUPSECCDRF AS SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        //担当者
                        //sqlCmd.Append(" E.SALESINPUTCODERF AS TMPEMPLOYEECODE, ");
                        sqlCmd.Append(" E.SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //受注者
                        sqlCmd.Append(" E.FRONTEMPLOYEECDRF AS TMPEMPLOYEECODE, ");

                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        //発行者
                        //sqlCmd.Append(" E.SALESEMPLOYEECDRF AS TMPEMPLOYEECODE, ");
                        sqlCmd.Append(" E.SALESINPUTCODERF AS TMPEMPLOYEECODE, ");

                    }
                    sqlCmd.Append(" SUM(CASE WHEN E.SALESSLIPCDRF=0 AND E.SALESGOODSCDRF =0 AND F.SALESSLIPCDDTLRF=2 AND F.SHIPMENTCNTRF =0 THEN F.SALESMONEYTAXEXCRF ELSE 0 END) AS SUMSUMSALESB, ");
                    sqlCmd.Append(" SUM(CASE WHEN E.SALESSLIPCDRF=1 AND E.SALESGOODSCDRF =0 AND F.SALESSLIPCDDTLRF=2 AND F.SHIPMENTCNTRF =0 THEN F.SALESMONEYTAXEXCRF ELSE 0 END) AS SUMRETURNGOODSB, ");
                    sqlCmd.Append(" SUM(CASE WHEN (E.SALESSLIPCDRF=0 OR E.SALESSLIPCDRF=1) AND E.SALESGOODSCDRF =0 AND F.SALESSLIPCDDTLRF=2 AND F.SHIPMENTCNTRF <>0 THEN F.SALESMONEYTAXEXCRF ELSE 0 END) AS SUMSALESMONEYTAXEXCRFB");
                    sqlCmd.Append(" FROM SALESHISTORYRF AS E ");
                    sqlCmd.Append(" LEFT OUTER JOIN SALESHISTDTLRF AS F ");
                    sqlCmd.Append(" ON E.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                    sqlCmd.Append(" AND E.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                    sqlCmd.Append(" AND E.ACPTANODRSTATUSRF=F.ACPTANODRSTATUSRF ");
                    sqlCmd.Append(" AND E.SALESSLIPNUMRF=F.SALESSLIPNUMRF ");
                    MakeWhereString_SalesHis(ref sqlCommand, _employeeResultsListCndtnWork, "E.", sqlCmd, 1);
                    sqlCmd.Append(" )AS B ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = B.TMPEMPLOYEECODE ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" AND A.SECTIONCODE = B.SECTIONCODE ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" AND A.SECTIONCODE = B.SECTIONCODE ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    sqlCmd.Append(" SECTIONCODERF, ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" SECTIONCODERF, ");
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" SUM(SALESTARGETMONEYRF) AS SUMSALESTARGETMONEYRF ");
                    sqlCmd.Append(" FROM EMPSALESTARGETRF ");
                    MakeWhereString_Emp(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    else
                        // --- ADD 2010/07/20--------------------------------<<<<<
                        sqlCmd.Append(" GROUP BY EMPLOYEECODERF ");
                    sqlCmd.Append(" )AS C ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = C.EMPLOYEECODERF ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT");
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" NAMERF ");
                    sqlCmd.Append(" FROM EMPLOYEERF ");
                    MakeWhereString_Employee(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    sqlCmd.Append(" )AS D ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = D.EMPLOYEECODERF ");
                    // --- UPD 2010/10/09 ---------->>>
                    //sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.SECTIONCODE, A.TMPEMPLOYEECODE");
                    }
                    else if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    }
                    // --- UPD 2010/10/09 ----------<<<

                    #endregion
                }
                else
                {
                    #region 月計 当期 Select文作成
                    sqlCmd.Append(" SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" A.SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" A.TMPEMPLOYEECODE AS CODE, ");
                    sqlCmd.Append(" A.SUMSALES AS SUMMONEY, ");
                    sqlCmd.Append(" A.SUMRETURNGOODS AS RETURNMONEY, ");
                    sqlCmd.Append(" A.SUMDISCOUNTPRICERF AS SUMSALESMONEYTAXEXCRFB, ");
                    sqlCmd.Append(" A.SUMGROSSPROFITRF AS SUMGROSSPROFITRF, ");
                    sqlCmd.Append(" C.SUMSALESTARGETMONEYRF AS SUMSALESTARGETMONEYRF, ");
                    sqlCmd.Append(" D.NAMERF AS NAMERF ");
                    sqlCmd.Append(" FROM ");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" ADDUPSECCODERF AS SECTIONCODE, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" ADDUPSECCODERF AS SECTIONCODE, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" EMPLOYEECODERF AS TMPEMPLOYEECODE, ");
                    sqlCmd.Append(" SUM(SALESMONEYRF) AS SUMSALES, ");
                    sqlCmd.Append(" SUM(SALESRETGOODSPRICERF) AS SUMRETURNGOODS, ");
                    sqlCmd.Append(" SUM(DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF, ");
                    sqlCmd.Append(" SUM(GROSSPROFITRF) AS SUMGROSSPROFITRF ");
                    sqlCmd.Append(" FROM MTTLSALESSLIPRF");
                    MakeWhereString_MTtl(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    sqlCmd.Append(" ) AS A ");
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT ");
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" SECTIONCODERF, ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" SECTIONCODERF, ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" SUM(SALESTARGETMONEYRF) AS SUMSALESTARGETMONEYRF ");
                    sqlCmd.Append(" FROM EMPSALESTARGETRF ");
                    MakeWhereString_Emp(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        sqlCmd.Append(" GROUP BY SECTIONCODERF, EMPLOYEECODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    else
                        // --- ADD 2010/07/20--------------------------------<<<<<
                        sqlCmd.Append(" GROUP BY EMPLOYEECODERF ");
                    sqlCmd.Append(" )AS C ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = C.EMPLOYEECODERF ");
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    //拠点コード
                    //    sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17--------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        //拠点コード
                        sqlCmd.Append(" AND A.SECTIONCODE = C.SECTIONCODERF ");
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    sqlCmd.Append(" LEFT OUTER JOIN ");
                    sqlCmd.Append(" (SELECT");
                    sqlCmd.Append(" EMPLOYEECODERF, ");
                    sqlCmd.Append(" NAMERF ");
                    sqlCmd.Append(" FROM EMPLOYEERF ");
                    MakeWhereString_Employee(ref sqlCommand, _employeeResultsListCndtnWork, sqlCmd);
                    sqlCmd.Append(" )AS D ");
                    sqlCmd.Append(" ON A.TMPEMPLOYEECODE = D.EMPLOYEECODERF ");
                    // --- UPD 2010/10/09 ---------->>>
                    //sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.SECTIONCODE, A.TMPEMPLOYEECODE");
                    }
                    else if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                    {
                        sqlCmd.Append(" ORDER BY A.TMPEMPLOYEECODE");
                    }
                    // --- UPD 2010/10/09 ----------<<<

                    #endregion
                }

                sqlCommand.CommandText = sqlCmd.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット

                    EmployeeResultsListResultWork wkEmployeeResultsListResultWork = new EmployeeResultsListResultWork();

                    //従業員コード
                    string employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CODE"));
                    wkEmployeeResultsListResultWork.EmployeeCode = employeeCode;

                    //従業員名称
                    string name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));

                    if (string.IsNullOrEmpty(name))
                    {
                        wkEmployeeResultsListResultWork.EmployeeName = NOINPUT;
                    }
                    else
                    {
                        wkEmployeeResultsListResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    }
                    //売上金額  黒伝の売上伝票合計（税抜き）  
                    wkEmployeeResultsListResultWork.BackSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMMONEY"));
                    //返品金額  返品伝票の売上伝票合計（税抜き）  
                    wkEmployeeResultsListResultWork.RetGoodSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETURNMONEY"));
                    //値引金額  黒伝の売上値引金額計（税抜き）    
                    wkEmployeeResultsListResultWork.BackSalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXCRFB"));
                    //売上目標金額
                    wkEmployeeResultsListResultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESTARGETMONEYRF"));

                    if (1 != _employeeResultsListCndtnWork.DuringType)
                    {
                        //粗利金額 GROSSPROFITRF
                        wkEmployeeResultsListResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFITRF"));
                    }

                    //原価金額計
                    if (1 == _employeeResultsListCndtnWork.DuringType)
                    {
                        wkEmployeeResultsListResultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMTOTALCOSTRF"));
                    }
                    else
                    {
                        wkEmployeeResultsListResultWork.TotalCost = wkEmployeeResultsListResultWork.BackSalesTotalTaxExc
                            + wkEmployeeResultsListResultWork.RetGoodSalesTotalTaxExc
                            + wkEmployeeResultsListResultWork.BackSalesDisTtlTaxExc
                            - wkEmployeeResultsListResultWork.GrossProfit;
                    }
                    //伝票枚数
                    if (1 == _employeeResultsListCndtnWork.DuringType)
                    {
                        wkEmployeeResultsListResultWork.SlipNumCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TMPSALESSLIPNUMRF"));
                    }
                    // --- DEL 2010/08/17-------------------------------->>>>>
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
                    //    wkEmployeeResultsListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
                    // --- ADD 2010/07/20--------------------------------<<<<<
                    // --- DEL 2010/08/17-------------------------------<<<<<
                    // --- ADD 2010/08/17-------------------------------->>>>>
                    if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                        && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                        wkEmployeeResultsListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
                    // --- ADD 2010/08/17--------------------------------<<<<<
                    #endregion

                    // --- ADD 2010/09/21 ---------->>>>>
                    if (!string.IsNullOrEmpty(employeeCode.Trim()) && string.IsNullOrEmpty(name))
                    {
                        // 対象外とする
                    } 
                    else
                    {
                    // --- ADD 2010/09/21 ----------<<<<<
                        if (1 == _employeeResultsListCndtnWork.DuringType)
                        {
                            al.Add(wkEmployeeResultsListResultWork);
                        }
                        else
                        {
                            if (!(0 == wkEmployeeResultsListResultWork.BackSalesTotalTaxExc
                                && 0 == wkEmployeeResultsListResultWork.RetGoodSalesTotalTaxExc
                                && 0 == wkEmployeeResultsListResultWork.BackSalesDisTtlTaxExc
                                && 0 == wkEmployeeResultsListResultWork.GrossProfit))
                            {
                                al.Add(wkEmployeeResultsListResultWork);
                            }
                        }
                    } // ADD 2010/09/21

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
                base.WriteErrorLog(ex, "EmployeeResultsListWorkDB.SearchEmployeeResultsProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Where句生成処理]
        /// <summary>
        /// 売上履歴データマスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>売上履歴データマスタ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_SalesHis(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, string sTblNm, StringBuilder sqlCmd, int flag)
        {
            #region WHERE文作成
            sqlCmd.Append(" WHERE ");

            string stringflag = flag.ToString().Trim();
            //企業コード
            if (flag == 0)
            {
                sqlCmd.Append(" " + sTblNm + "ENTERPRISECODERF = @ENTERPRISECODEA");
                SqlParameter paraEnterpriseCodeA = sqlCommand.Parameters.Add("@ENTERPRISECODEA", SqlDbType.NChar);
                paraEnterpriseCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);
            }
            else
            {
                sqlCmd.Append(" " + sTblNm + "ENTERPRISECODERF = @ENTERPRISECODEAA");
                SqlParameter paraEnterpriseCodeAA = sqlCommand.Parameters.Add("@ENTERPRISECODEAA", SqlDbType.NChar);
                paraEnterpriseCodeAA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);
            }


            //削除区分
            sqlCmd.Append(" AND " + sTblNm + "LOGICALDELETECODERF = 0 ");

            //受注ステータス
            sqlCmd.Append(" AND " + sTblNm + "ACPTANODRSTATUSRF = 30 ");

            //赤伝区分
            sqlCmd.Append(" AND " + sTblNm + "DEBITNOTEDIVRF = 0 ");

            //拠点コード
            // --- DEL 2010/08/20-------------------------------->>>>>
            //if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
            //    && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode)))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && "OUTPUT" != _employeeResultsListCndtnWork.ViewFlg)
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                if (flag == 0)
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF=@SECTIONCODERFB ");
                    SqlParameter paraSectionCodeB = sqlCommand.Parameters.Add("@SECTIONCODERFB", SqlDbType.NChar);
                    paraSectionCodeB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
                }
                else
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF=@SECTIONCODERFA ");
                    SqlParameter paraSectionCodeA = sqlCommand.Parameters.Add("@SECTIONCODERFA", SqlDbType.NChar);
                    paraSectionCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
                }
            }
            // --- ADD 2010/09/21-------------------------------->>>>>
            // 拠点コードが"全社"場合の画面出力
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && !"OUTPUT".Equals(_employeeResultsListCndtnWork.ViewFlg))
            {
                if (flag == 0)
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                }
                else
                {
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                }
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            // --- DEL 2010/08/20-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if (string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)
            //    && (null != _employeeResultsListCndtnWork.SectionCodeList &&
            //    0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg
                && (null != _employeeResultsListCndtnWork.SectionCodeList &&
                0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                // 拠点コード
                string sectionString = "";
                foreach (string[] sectionCode in _employeeResultsListCndtnWork.SectionCodeList)
                {
                    if (!string.Empty.Equals(sectionCode[0]))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode[0] + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // 拠点コード
                    sqlCmd.Append(" AND " + sTblNm + "RESULTSADDUPSECCDRF IN (" + sectionString + ")  ");

                }
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //担当者
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                || (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode)))
            {
                if (flag == 0)
                {
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        ////担当者
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERF");
                        //    SqlParameter findStEmployeeCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                        //    findStEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERF ");
                        //    SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                        //    findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //発行者
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERF ");
                            SqlParameter findParaDspcInstsInpEmpCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                            findParaDspcInstsInpEmpCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERF ");
                            SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                            findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // 発注者、論理削除データが対象外
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //受注者
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF>=@FINDSTEMPLOYEECODERF ");
                            SqlParameter findStEmployeeCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                            findStEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF<=@FINDEDEMPLOYEECODERF ");
                            SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                            findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // 受注者、論理削除データが対象外
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        ////発行者
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERF ");
                        //    SqlParameter findParaDspcInstsInpEmpCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                        //    findParaDspcInstsInpEmpCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERF ");
                        //    SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                        //    findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //担当者
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERF");
                            SqlParameter findStEmployeeCode = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERF", SqlDbType.NChar);
                            findStEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERF ");
                            SqlParameter findEdEmployeeCode = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERF", SqlDbType.NChar);
                            findEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // 担当者、論理削除データが対象外
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                }
                else
                {
                    if (_employeeResultsListCndtnWork.ReferType == 1)
                    {
                        ////担当者
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERFA");
                        //    SqlParameter findStEmployeeCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findStEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERFA ");
                        //    SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //発行者
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERFA ");
                            SqlParameter findParaDspcInstsInpEmpCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                            findParaDspcInstsInpEmpCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERFA ");
                            SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                            findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // 発行者、論理削除データが対象外
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 2)
                    {
                        //受注者
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF>=@FINDSTEMPLOYEECODERFA ");
                            SqlParameter findStEmployeeCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                            findStEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF<=@FINDEDEMPLOYEECODERFA ");
                            SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                            findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // 受注者、論理削除データが対象外
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "FRONTEMPLOYEECDRF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                    else if (_employeeResultsListCndtnWork.ReferType == 3)
                    {
                        ////発行者
                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF>=@FINDSTEMPLOYEECODERFA ");
                        //    SqlParameter findParaDspcInstsInpEmpCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findParaDspcInstsInpEmpCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        //}

                        //if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        //{
                        //    sqlCmd.Append(" AND " + sTblNm + "SALESEMPLOYEECDRF<=@FINDEDEMPLOYEECODERFA ");
                        //    SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                        //    findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        //}

                        //担当者
                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF>=@FINDSTEMPLOYEECODERFA");
                            SqlParameter findStEmployeeCodeA = sqlCommand.Parameters.Add("@FINDSTEMPLOYEECODERFA", SqlDbType.NChar);
                            findStEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
                        }

                        if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF<=@FINDEDEMPLOYEECODERFA ");
                            SqlParameter findEdEmployeeCodeA = sqlCommand.Parameters.Add("@FINDEDEMPLOYEECODERFA", SqlDbType.NChar);
                            findEdEmployeeCodeA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode); ;
                        }

                        // --- ADD 2010/09/21-------------------------------->>>>>
                        // 担当者、論理削除データが対象外
                        if (flag == 0)
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEA AND LOGICALDELETECODERF = 0) ");
                        }
                        else
                        {
                            sqlCmd.Append(" AND " + sTblNm + "SALESINPUTCODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEAA AND LOGICALDELETECODERF = 0) ");
                        }
                        // --- ADD 2010/09/21--------------------------------<<<<<
                    }
                }
            }

            if (_employeeResultsListCndtnWork.DuringType == 1)
            {
                if (flag == 0)
                {
                    //売上日付
                    if (_employeeResultsListCndtnWork.St_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + " SALESDATERF>=@STSALESDATE");
                        SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                        paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.St_DuringTime);
                    }
                    if (_employeeResultsListCndtnWork.Ed_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + "SALESDATERF<=@EDSALESDATE");
                        SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                        paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.Ed_DuringTime);
                    }

                }
                else
                {
                    //売上日付
                    if (_employeeResultsListCndtnWork.St_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + " SALESDATERF>=@STSALESDATET");
                        SqlParameter paraSalesDateT = sqlCommand.Parameters.Add("@STSALESDATET", SqlDbType.Int);
                        paraSalesDateT.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.St_DuringTime);
                    }
                    if (_employeeResultsListCndtnWork.Ed_DuringTime != DateTime.MinValue)
                    {
                        sqlCmd.Append(" AND " + sTblNm + "SALESDATERF<=@EDSALESDATET");
                        SqlParameter paraEdSalesDateT = sqlCommand.Parameters.Add("@EDSALESDATET", SqlDbType.Int);
                        paraEdSalesDateT.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_employeeResultsListCndtnWork.Ed_DuringTime);
                    }

                }
            }
            else if (_employeeResultsListCndtnWork.DuringType == 2)
            {
                //売上日付
                if (_employeeResultsListCndtnWork.St_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND " + sTblNm + "SALESDATERF>=@STSALESDATE ");
                    SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_YearMonth);
                }
                if (_employeeResultsListCndtnWork.Ed_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND " + sTblNm + "SALESDATERF<=@EDSALESDATE ");
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.Ed_YearMonth);
                }
            }

            sqlCmd.Append(" GROUP BY ");
            // --- DEL 2010/08/17------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
            //    //拠点コード
            //    //sqlCmd.Append(sTblNm + "SECTIONCODERF, "); // DEL 2010/08/12 障害ID:13038対応 
            //    sqlCmd.Append(sTblNm + "RESULTSADDUPSECCDRF, "); // ADD 2010/08/12 障害ID:13038対応
            // --- ADD 2010/07/20--------------------------------<<<<<
            // --- DEL 2010/08/17-------------------------------<<<<<
            // --- ADD 2010/08/17-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                sqlCmd.Append(sTblNm + "RESULTSADDUPSECCDRF, ");
            // --- ADD 2010/08/17--------------------------------<<<<<
            if (_employeeResultsListCndtnWork.ReferType == 1)
            {
                ////担当者
                //sqlCmd.Append(sTblNm + "SALESINPUTCODERF ");

                //発行者
                sqlCmd.Append(sTblNm + "SALESEMPLOYEECDRF ");
            }
            else if (_employeeResultsListCndtnWork.ReferType == 2)
            {
                //受注者
                sqlCmd.Append(sTblNm + "FRONTEMPLOYEECDRF ");

            }
            else if (_employeeResultsListCndtnWork.ReferType == 3)
            {
                ////発行者
                //sqlCmd.Append(sTblNm + "SALESEMPLOYEECDRF ");

                //担当者
                sqlCmd.Append(sTblNm + "SALESINPUTCODERF ");

            }

            #endregion
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>従業員別売上目標設定マスタ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_Emp(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, StringBuilder sqlCmd)
        {
            #region WHERE文作成
            sqlCmd.Append(" WHERE ");

            //企業コード
            sqlCmd.Append("ENTERPRISECODERF=@ENTERPRISECODEB");
            SqlParameter paraEnterpriseCodeB = sqlCommand.Parameters.Add("@ENTERPRISECODEB", SqlDbType.NChar);
            paraEnterpriseCodeB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);

            //削除区分
            sqlCmd.Append(" AND LOGICALDELETECODERF = 0 ");

            //目標設定区分＝10:月間目標
            sqlCmd.Append(" AND TARGETSETCDRF = 10 ");

            //目標対比区分＝22:拠点+従業員
            sqlCmd.Append(" AND TARGETCONTRASTCDRF = 22 ");

            //目標区分コード＝画面の入力値「期間」の年月
            if (_employeeResultsListCndtnWork.DuringType == 1)
            {
                sqlCmd.Append(" AND TARGETDIVIDECODERF=@TARGETDIVIDECODEST ");
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@TARGETDIVIDECODEST", SqlDbType.Int);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_DuringTime);

            }
            else if (_employeeResultsListCndtnWork.DuringType == 2 || _employeeResultsListCndtnWork.DuringType == 3)
            {
                if (_employeeResultsListCndtnWork.St_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND TARGETDIVIDECODERF>=@STSALESDATEA ");
                    SqlParameter paraSalesDateA = sqlCommand.Parameters.Add("@STSALESDATEA", SqlDbType.Int);
                    paraSalesDateA.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_YearMonth);
                }
                if (_employeeResultsListCndtnWork.Ed_YearMonth != DateTime.MinValue)
                {
                    sqlCmd.Append(" AND TARGETDIVIDECODERF<=@EDSALESDATEB ");
                    SqlParameter paraEdSalesDateB = sqlCommand.Parameters.Add("@EDSALESDATEB", SqlDbType.Int);
                    paraEdSalesDateB.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.Ed_YearMonth);
                }

            }
            // --- DEL 2010/08/20-------------------------------->>>>>
            //拠点コード
            //if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
            //    && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode)))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && "OUTPUT" != _employeeResultsListCndtnWork.ViewFlg)
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                sqlCmd.Append(" AND SECTIONCODERF=@SECTIONCODERF ");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            // 拠点コードが"全社"場合の画面出力
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && !"OUTPUT".Equals(_employeeResultsListCndtnWork.ViewFlg))
            {
                sqlCmd.Append(" AND SECTIONCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODEB2 AND LOGICALDELETECODERF = 0) ");
                SqlParameter paraEnterpriseCodeB2 = sqlCommand.Parameters.Add("@ENTERPRISECODEB2", SqlDbType.NChar);
                paraEnterpriseCodeB2.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            // --- DEL 2010/08/20-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if (string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)
            //    && (null != _employeeResultsListCndtnWork.SectionCodeList &&
            //    0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg
                && (null != _employeeResultsListCndtnWork.SectionCodeList &&
                0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                // 拠点コード
                string sectionString = "";
                foreach (string[] sectionCode in _employeeResultsListCndtnWork.SectionCodeList)
                {
                    if (!string.Empty.Equals(sectionCode[0]))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode[0] + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // 拠点コード
                    sqlCmd.Append(" AND SECTIONCODERF IN (" + sectionString + ")  ");

                }
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //従業員区分
            sqlCmd.Append(" AND EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD");
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
            switch ((int)_employeeResultsListCndtnWork.ReferType)
            {
                case 1:    //Agent   -> 担当者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)10);
                    break;
                case 2:   //AcpOdr  -> 受注者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)20);
                    break;
                case 3:  //Pblsher -> 発行者別
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)30);
                    break;
                default:
                    break;
            }

            //従業員コード
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODERFBEF");
                SqlParameter paraEmployeeCdBef = sqlCommand.Parameters.Add("@EMPLOYEECODERFBEF", SqlDbType.NChar);
                paraEmployeeCdBef.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
            }

            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODERFEND");
                SqlParameter paraEmployeeCdEnd = sqlCommand.Parameters.Add("@EMPLOYEECODERFEND", SqlDbType.NChar);
                paraEmployeeCdEnd.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode) || !string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                // 従業員コード、論理削除データが対象外
                sqlCmd.Append(" AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEB AND LOGICALDELETECODERF = 0 UNION SELECT DISTINCT '         ' AS EMPLOYEECODERF FROM EMPLOYEERF) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<
            #endregion

        }

        /// <summary>
        /// 従業員マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>従業員マスタ用WHERE句</returns>
        /// <br>Note       : 売上履歴データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_Employee(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, StringBuilder sqlCmd)
        {
            #region WHERE文作成

            sqlCmd.Append(" WHERE ");

            //企業コード
            sqlCmd.Append("ENTERPRISECODERF=@ENTERPRISECODEC");
            SqlParameter paraEnterpriseCodeC = sqlCommand.Parameters.Add("@ENTERPRISECODEC", SqlDbType.NChar);
            paraEnterpriseCodeC.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);

            //削除区分
            sqlCmd.Append(" AND LOGICALDELETECODERF = 0 ");

            //従業員コード
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODERFBEFA");
                SqlParameter paraEmployeeCdBefA = sqlCommand.Parameters.Add("@EMPLOYEECODERFBEFA", SqlDbType.NChar);
                paraEmployeeCdBefA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
            }

            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODERFENDA");
                SqlParameter paraEmployeeCdEndA = sqlCommand.Parameters.Add("@EMPLOYEECODERFENDA", SqlDbType.NChar);
                paraEmployeeCdEndA.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode) || !string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                // 従業員コード、論理削除データが対象外
                sqlCmd.Append(" AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODEC AND LOGICALDELETECODERF = 0 UNION SELECT DISTINCT '         ' AS EMPLOYEECODERF FROM EMPLOYEERF) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            sqlCmd.Append(" GROUP BY ");

            sqlCmd.Append(" EMPLOYEECODERF, NAMERF ");

            #endregion
        }

        /// <summary>
        /// 売上月次集計マスタ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件</param>
        /// <returns>売上月次集計マスタ用WHERE句</returns>
        /// <br>Note       : 売上月次集計用WHERE句を作成して戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.11</br>
        private void MakeWhereString_MTtl(ref SqlCommand sqlCommand, EmployeeResultsListCndtnWork _employeeResultsListCndtnWork, StringBuilder sqlCmd)
        {
            #region WHERE文作成

            sqlCmd.Append(" WHERE ");

            //企業コード
            sqlCmd.Append("ENTERPRISECODERF=@ENTERPRISECODED");
            SqlParameter paraEnterpriseCodeD = sqlCommand.Parameters.Add("@ENTERPRISECODED", SqlDbType.NChar);
            paraEnterpriseCodeD.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.EnterpriseCode);

            //削除区分
            sqlCmd.Append(" AND LOGICALDELETECODERF = 0 ");

            //実績集計区分=0:部品合計
            sqlCmd.Append(" AND RSLTTTLDIVCDRF = 0 ");
            // --- DEL 2010/08/20-------------------------------->>>>>
            //拠点コード
            //if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
            //    && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode)))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && "OUTPUT" != _employeeResultsListCndtnWork.ViewFlg)
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                sqlCmd.Append(" AND ADDUPSECCODERF=@ADDUPSECCODERF ");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@ADDUPSECCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.SectionCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            // 拠点コードが"全社"場合の画面出力
            if ((!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode))
                && (WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && !"OUTPUT".Equals(_employeeResultsListCndtnWork.ViewFlg))
            {
                sqlCmd.Append(" AND ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODED AND LOGICALDELETECODERF = 0) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            // --- DEL 2010/08/20-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if (string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)
            //    && (null != _employeeResultsListCndtnWork.SectionCodeList &&
            //    0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- DEL 2010/08/20--------------------------------<<<<<
            // --- ADD 2010/08/20-------------------------------->>>>>
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg
               && (null != _employeeResultsListCndtnWork.SectionCodeList &&
               0 != _employeeResultsListCndtnWork.SectionCodeList.Count))
            // --- ADD 2010/08/20--------------------------------<<<<<
            {
                // 拠点コード
                string sectionString = "";
                foreach (string[] sectionCode in _employeeResultsListCndtnWork.SectionCodeList)
                {
                    if (!string.Empty.Equals(sectionCode[0]))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode[0] + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // 拠点コード
                    sqlCmd.Append(" AND ADDUPSECCODERF IN (" + sectionString + ")  ");

                }
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //従業員区分
            sqlCmd.Append(" AND EMPLOYEEDIVCDRF=@EMPLOYEEDIVCDA");
            SqlParameter paraEmployeeDivCdA = sqlCommand.Parameters.Add("@EMPLOYEEDIVCDA", SqlDbType.Int);
            switch ((int)_employeeResultsListCndtnWork.ReferType)
            {
                case 1:    //Agent   -> 担当者別
                    paraEmployeeDivCdA.Value = SqlDataMediator.SqlSetInt32((int)10);
                    break;
                case 2:   //AcpOdr  -> 受注者別
                    paraEmployeeDivCdA.Value = SqlDataMediator.SqlSetInt32((int)20);
                    break;
                case 3:  //Pblsher -> 発行者別
                    paraEmployeeDivCdA.Value = SqlDataMediator.SqlSetInt32((int)30);
                    break;
                default:
                    break;
            }

            //従業員コード
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODERFBEFB");
                SqlParameter paraEmployeeCdBefB = sqlCommand.Parameters.Add("@EMPLOYEECODERFBEFB", SqlDbType.NChar);
                paraEmployeeCdBefB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.St_EmployeeCode);
            }

            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                sqlCmd.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODERFENDB");
                SqlParameter paraEmployeeCdEndB = sqlCommand.Parameters.Add("@EMPLOYEECODERFENDB", SqlDbType.NChar);
                paraEmployeeCdEndB.Value = SqlDataMediator.SqlSetString(_employeeResultsListCndtnWork.Ed_EmployeeCode);
            }

            // --- ADD 2010/09/21-------------------------------->>>>>
            if (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.St_EmployeeCode) || !string.IsNullOrEmpty(_employeeResultsListCndtnWork.Ed_EmployeeCode))
            {
                // 従業員コード、論理削除データが対象外
                sqlCmd.Append(" AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODED AND LOGICALDELETECODERF = 0 UNION SELECT DISTINCT '         ' AS EMPLOYEECODERF FROM EMPLOYEERF) ");
            }
            // --- ADD 2010/09/21--------------------------------<<<<<

            //計上年月
            if (_employeeResultsListCndtnWork.St_YearMonth != DateTime.MinValue)
            {
                sqlCmd.Append(" AND ADDUPYEARMONTHRF>=@STSALESDATEC ");
                SqlParameter paraSalesDateC = sqlCommand.Parameters.Add("@STSALESDATEC", SqlDbType.Int);
                paraSalesDateC.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.St_YearMonth);
            }
            if (_employeeResultsListCndtnWork.Ed_YearMonth != DateTime.MinValue)
            {
                sqlCmd.Append(" AND ADDUPYEARMONTHRF<=@EDSALESDATED ");
                SqlParameter paraEdSalesDateD = sqlCommand.Parameters.Add("@EDSALESDATED", SqlDbType.Int);
                paraEdSalesDateD.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_employeeResultsListCndtnWork.Ed_YearMonth);
            }
            // --- DEL 2010/08/17-------------------------------->>>>>
            // --- ADD 2010/07/20-------------------------------->>>>>
            //if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg)
            //    sqlCmd.Append(" GROUP BY ADDUPSECCODERF, EMPLOYEECODERF ");
            // --- ADD 2010/08/17-------------------------------->>>>>
            // --- DEL 2010/08/17--------------------------------<<<<<
            if ("OUTPUT" == _employeeResultsListCndtnWork.ViewFlg && (!WHOLE_SECTION_CODE.Equals(_employeeResultsListCndtnWork.SectionCode))
                && (!string.IsNullOrEmpty(_employeeResultsListCndtnWork.SectionCode)))
                sqlCmd.Append(" GROUP BY ADDUPSECCODERF, EMPLOYEECODERF ");
            // --- ADD 2010/08/17--------------------------------<<<<<
            else
                // --- ADD 2010/07/20--------------------------------<<<<<
                sqlCmd.Append(" GROUP BY EMPLOYEECODERF ");

            #endregion

        }

        #endregion [ Where句生成処理]
    }
}
