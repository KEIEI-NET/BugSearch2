//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表DBリモートオブジェクト
// プログラム概要   : 返品理由一覧表実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希 
// 修 正 日  2011/07/29  修正内容 : イスコ対応・READUNCOMMITTED対応
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
    /// 返品理由一覧表 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品理由一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    [Serializable]
    public class RetGoodsReasonReportResultDB : RemoteDB , IRetGoodsReasonReportResultDB
    {
       #region クラスコンストラクタ
        /// <summary>
        /// 返品理由一覧表コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public RetGoodsReasonReportResultDB()
            : base("PMHNB02219D", "Broadleaf.Application.Remoting.ParamData.RetGoodsReasonReportResultWork", "RETGOODSREASONREPORTRESULT")
        {

        }
        #endregion

       #region [Search]
        #region 指定された条件の返品理由一覧表一覧表情報LISTの取得処理
        /// <summary>
        /// 指定された条件の返品理由一覧表一覧表情報LISTを戻します
        /// </summary>
        /// <param name="retGoodsReasonReportResultWork">検索結果</param>
        /// <param name="retGoodsReasonReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の返品理由一覧表情報LISTを戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public int Search(out object retGoodsReasonReportResultWork, object retGoodsReasonReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retGoodsReasonReportResultWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out retGoodsReasonReportResultWork, retGoodsReasonReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "RetGoodsReasonReportResultDB.Search");
                retGoodsReasonReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RetGoodsReasonReportResultDB.Search");
                retGoodsReasonReportResultWork = new ArrayList();
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

        #region 指定された条件の返品理由一覧表一覧表情報LIST(外部からのSqlConnectionを使用)
        /// <summary>
        /// 指定された条件の返品理由一覧表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果検索パラメータ</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の返品理由一覧表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            RetGoodsReasonReportParaWork paraWork = null;
            paraWork = paraObj as RetGoodsReasonReportParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // 売上履歴データsql
            StringBuilder selectTxt1 = new StringBuilder(string.Empty);
            // 売上データsql
            StringBuilder selectTxt2 = new StringBuilder(string.Empty);

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                // 画面で伝票種別：売上
                if (0 == paraWork.SlipKindCd)
                {
                    selectTxt = MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork);

                }
                // 画面で伝票種別：貸出含む
                else if (1 == paraWork.SlipKindCd)
                {
                    selectTxt.Append(MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork));
                    selectTxt.Append(" UNION ");
                    selectTxt.Append(MakeSearchSQL2(ref selectTxt2, ref sqlCommand, paraWork));
                }

                selectTxt = SortSql(selectTxt, paraWork, ref sqlCommand);

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToRetGoodsReasonReportResultWorkFromReader(ref myReader, paraWork));
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
                status = base.WriteSQLErrorLog(sqlex, "RetGoodsReasonReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RetGoodsReasonReportResultDB.SearchProc" + status);
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

        #region 検索用売上履歴データ取得処理
        /// <summary>
        /// 検索用売上履歴データ取得処理
        /// </summary>
        /// <param name="selectTxt1">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 検索用売上履歴データを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            #region [取得項目]
            selectTxt1 = SelectRow(paraWork, selectTxt1);    
            #endregion
            #region [テーブル]
            selectTxt1.Append("FROM ");
            // 2011/07/29 >>>
            //selectTxt1.Append("SALESHISTORYRF A ");               // 売上履歴データ
            selectTxt1.Append("SALESHISTORYRF A WITH (READUNCOMMITTED) ");               // 売上履歴データ
            // 2011/07/29 <<<
            #endregion
            #region [抽出条件]
            MakeWhereString1(ref selectTxt1, ref sqlCommand, paraWork);
            #endregion
            #region [集計]
            SortRetGoodsReasonReportResult(ref selectTxt1, paraWork.PrintType);
            #endregion [集計]

            return selectTxt1;
            
        }
        #endregion

        #region 検索用売上データ取得処理
        /// <summary>
        /// 検索用売上データ取得処理
        /// </summary>
        /// <param name="selectTxt2">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 検索用売上データを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            #region [取得項目]
            selectTxt2 = SelectRow(paraWork, selectTxt2);
            #endregion
            #region [テーブル]
            selectTxt2.Append("FROM ");
            // 2011/07/29 >>>
            //selectTxt2.Append("SALESSLIPRF A "); // 売上データ
            selectTxt2.Append("SALESSLIPRF A WITH (READUNCOMMITTED) "); // 売上データ
            // 2011/07/29 <<<
            #endregion
            #region [抽出条件]
            MakeWhereString2(ref selectTxt2, ref sqlCommand, paraWork);
            #endregion
            #region [集計]
            SortRetGoodsReasonReportResult(ref selectTxt2, paraWork.PrintType);
            #endregion [集計]

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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder SelectRow(RetGoodsReasonReportParaWork paraWork, StringBuilder selectTxt)
        {
            //　返品理由
            if (0 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // 件数
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // 実績計上拠点コード
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // 返品理由コード
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // 返品理由
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       　// 売上伝票合計（税抜き）
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // 受注ステータス
            }
            //　得意先
            else if (1 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // 件数
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // 実績計上拠点コード
                selectTxt.Append("A.CUSTOMERCODERF CUSTOMERCODERF, ");                      // 得意先コード
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // 返品理由コード
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // 返品理由
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       　// 売上伝票合計（税抜き）
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // 受注ステータス
            }
            //　担当者
            else if (2 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // 件数
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // 実績計上拠点コード
                selectTxt.Append("A.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, ");                // 販売従業員コード
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // 返品理由コード
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // 返品理由
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       　// 売上伝票合計（税抜き）
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // 受注ステータス
            }
            //　受注者
            else if (3 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // 件数
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // 実績計上拠点コード
                selectTxt.Append("A.FRONTEMPLOYEECDRF FRONTEMPLOYEECDRF, ");                // 受付従業員コード
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // 返品理由コード
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // 返品理由
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       　// 売上伝票合計（税抜き）
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // 受注ステータス
            }
            //　発行者
            else if (4 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // 件数
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // 実績計上拠点コード
                selectTxt.Append("A.SALESINPUTCODERF SALESINPUTCODERF, ");                  // 売上入力者コード
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // 返品理由コード
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // 返品理由
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       　// 売上伝票合計（税抜き）
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // 受注ステータス
            }
            return selectTxt;
        }
        #endregion [取得項目]

        #region [集計]
        /// <summary>
        /// グループ順を設定
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="printType">出力順</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder SortRetGoodsReasonReportResult(ref StringBuilder sql, int printType)
        {
            switch (printType)
            {   // 返品理由
                case(0):
                    {   
                        //実績計上拠点コード
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //返品理由コード
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //返品理由
                        sql.Append("A.RETGOODSREASONRF, ");
                        // 受注ステータス
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // 得意先
                case (1):
                    {
                        //実績計上拠点コード
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //得意先コード
                        sql.Append("A.CUSTOMERCODERF, ");
                        //返品理由コード
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //返品理由
                        sql.Append("A.RETGOODSREASONRF, ");
                        // 受注ステータス
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // 担当者
                case (2):
                    {
                        //実績計上拠点コード
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //販売従業員コード
                        sql.Append("A.SALESEMPLOYEECDRF, ");
                        //返品理由コード
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //返品理由
                        sql.Append("A.RETGOODSREASONRF, ");
                        // 受注ステータス
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // 受注者
                case (3):
                    {
                        //実績計上拠点コード
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //受付従業員コード
                        sql.Append("A.FRONTEMPLOYEECDRF, ");
                        //返品理由コード
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //返品理由
                        sql.Append("A.RETGOODSREASONRF, ");
                        // 受注ステータス
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // 発行者
                case (4):
                    {
                        //実績計上拠点コード
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //売上入力者コード
                        sql.Append("A.SALESINPUTCODERF, ");
                        //返品理由コード
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //返品理由
                        sql.Append("A.RETGOODSREASONRF, ");
                        // 受注ステータス
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
             }
             return sql;
         }
        #endregion [集計]

        #region [ソート順を設定]
        /// <summary>
        /// ソート順を設定
        /// </summary>
        /// <param name="selectTxt">sql文</param>
        /// <param name="paraWork">検索パラメータ</param>
         /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder SortSql(StringBuilder selectTxt,RetGoodsReasonReportParaWork paraWork,ref SqlCommand sqlCommand)
        {
            StringBuilder sql = new StringBuilder(string.Empty);
            switch (paraWork.PrintType)
            {   // 返品理由
                case (0):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // 件数
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // 実績計上拠点コード
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // 返品理由コード
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // 返品理由
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // 売上伝票合計（税抜き）
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // 受注ステータス
                        sql.Append("D.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // 拠点ガイド略称
                        sql.Append("FROM (" + selectTxt + ")  C ");

                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF D ");    // 拠点情報設定マスタ
                        sql.Append("LEFT JOIN  SECINFOSETRF D WITH (READUNCOMMITTED) ");    // 拠点情報設定マスタ
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = D.SECTIONCODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF = @ENTERPRISECODE3");
                        sql.Append(") ");

                        // 企業コード=パラメータ.企業コード
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);
                        //実績計上拠点コード
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //返品理由コード
                        sql.Append("C.RETGOODSREASONDIVRF,  ");
                        //返品理由名称
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //受注ステータス
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // 得意先
                case (1):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // 件数
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // 実績計上拠点コード
                        sql.Append("C.CUSTOMERCODERF CUSTOMERCODERF,  ");            // 得意先コード
                        sql.Append("D.CUSTOMERSNMRF CUSTOMERSNMRF,  ");              // 得意先略称
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // 返品理由コード
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // 返品理由
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // 売上伝票合計（税抜き）
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // 受注ステータス
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // 拠点ガイド略称
                        // 集計データ
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // 得意先マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  CUSTOMERRF D ");
                        sql.Append("LEFT JOIN  CUSTOMERRF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.CUSTOMERCODERF = D.CUSTOMERCODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // 拠点情報設定マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // 企業コード=パラメータ.企業コード
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);
                        //実績計上拠点コード
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //得意先コード
                        sql.Append("C.CUSTOMERCODERF, ");
                        //返品理由コード
                        sql.Append("C.RETGOODSREASONDIVRF, ");
                        //返品理由名称
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //受注ステータス
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // 担当者
                case (2):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // 件数
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // 実績計上拠点コード
                        sql.Append("C.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, ");       // 販売従業員コード
                        sql.Append("D.NAMERF NAMERF, ");                             // 販売従業員名称
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // 返品理由コード
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // 返品理由
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // 売上伝票合計（税抜き）
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // 受注ステータス
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // 拠点ガイド略称
                        // 集計データ
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // 従業員マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  EMPLOYEERF D ");
                        sql.Append("LEFT JOIN  EMPLOYEERF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.SALESEMPLOYEECDRF = D.EMPLOYEECODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // 拠点情報設定マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // 企業コード=パラメータ.企業コード
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                        //実績計上拠点コード
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //販売従業員コード
                        sql.Append("C.SALESEMPLOYEECDRF, ");
                        //返品理由コード
                        sql.Append("C.RETGOODSREASONDIVRF,");
                        //返品理由名称
                        sql.Append("C.RETGOODSREASONRF, ");
                        //受注ステータス
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // 受注者
                case (3):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // 件数
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // 実績計上拠点コード
                        sql.Append("C.FRONTEMPLOYEECDRF FRONTEMPLOYEECDRF, ");       // 受付従業員コード
                        sql.Append("D.NAMERF NAMERF, ");                             // 受付従業員名称
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // 返品理由コード
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // 返品理由
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // 売上伝票合計（税抜き）
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // 受注ステータス
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // 拠点ガイド略称
                        // 集計データ
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // 従業員マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  EMPLOYEERF D ");
                        sql.Append("LEFT JOIN  EMPLOYEERF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.FRONTEMPLOYEECDRF = D.EMPLOYEECODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // 拠点情報設定マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // 企業コード=パラメータ.企業コード
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                        //実績計上拠点コード
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //受付従業員コード
                        sql.Append("C.FRONTEMPLOYEECDRF, ");
                        //返品理由コード
                        sql.Append("C.RETGOODSREASONDIVRF, ");
                        //返品理由名称
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //受注ステータス
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // 発行者
                case (4):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // 件数
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // 実績計上拠点コード
                        sql.Append("C.SALESINPUTCODERF SALESINPUTCODERF, ");         // 売上入力者コード
                        sql.Append("D.NAMERF NAMERF, ");                             // 売上入力者名称
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // 返品理由コード
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // 返品理由
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // 売上伝票合計（税抜き）
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // 受注ステータス
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // 拠点ガイド略称
                        // 集計データ
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // 従業員マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  EMPLOYEERF D ");
                        sql.Append("LEFT JOIN  EMPLOYEERF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.SALESINPUTCODERF = D.EMPLOYEECODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // 拠点情報設定マスタ
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // 企業コード=パラメータ.企業コード
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                        //実績計上拠点コード
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //売上入力者コード
                        sql.Append("C.SALESINPUTCODERF, ");
                        //返品理由コード
                        sql.Append("C.RETGOODSREASONDIVRF, ");
                        //返品理由名称
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //受注ステータス
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
            }
            return sql;
        }
        #endregion  [ソート順を設定]

        #region [Where文作成処理]
        /// <summary>
        /// 売上履歴データ検索条件文字列生成処理と条件値設定処理
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder MakeWhereString1(ref StringBuilder sql, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            // 論理削除区分
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");
            // 売上伝票区分=「1:返品」
            sql.Append(" AND  A.SALESSLIPCDRF = 1  ");
            // 受注ステータス=「30:売上」
            sql.Append(" AND  A.ACPTANODRSTATUSRF = 30  ");
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
                    sql.Append(" AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ")  ");

                }
            }

            // 売上日付
            /*---------DEL 2007/07/13 PVCS326--------->>>>>
            // 今回締処理日はNULLではない場合
            if (paraWork.CurrentTotalDay != DateTime.MinValue)
            {   
                // 売上日付 >= 前回締処理日＋１
                sql.Append(" AND A.SALESDATERF >= @FINDPARAPREVTOTALDAY ");
                SqlParameter paraPrevTotalDay = sqlCommand.Parameters.Add("@FINDPARAPREVTOTALDAY", SqlDbType.Int);
                paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.PrevTotalDay.AddDays(1.0));
                // 売上日付 <=今回締処理日
                sql.Append(" AND A.SALESDATERF <= @FINDPARACURRENTTOTALDAY ");
                SqlParameter paraCurrentTotalDay = sqlCommand.Parameters.Add("@FINDPARACURRENTTOTALDAY", SqlDbType.Int);
                paraCurrentTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.CurrentTotalDay);
            }
            else
            {
                // 売上日付 >= 年度開始日＋１
                sql.Append(" AND A.SALESDATERF >= @FINDSTARTYEARDATE ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate.AddDays(1.0));
                // 売上日付 <=年度終了日
                sql.Append(" AND A.SALESDATERF <= @FINDENDYEARDATE ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }
            ---------DEL 2007/07/13 PVCS326--------->>>>>*/

            if (paraWork.StartYearDate != DateTime.MinValue)
            {
                // 売上日付 >= 開始年月日+１
                sql.Append(" AND A.SALESDATERF >= @FINDSTARTYEARDATE ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate);
            }
            if (paraWork.EndYearDate != DateTime.MinValue)
            {
                // 売上日付 <=終了年月日
                sql.Append(" AND A.SALESDATERF <= @FINDENDYEARDATE ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }
            // 画面の得意先(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt)) 　
            {
                sql.Append(" AND A.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // 画面の得意先(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd)) 　
            {
                sql.Append(" AND A.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }

            // 画面の担当者(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFSt))
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF >= @FINDSTSALESEMPLOYEECD ");
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSTSALESEMPLOYEECD", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFSt);
            }
            // 画面の担当者(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFEd)) 
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF <= @FINDEDSALESEMPLOYEECD ");
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDEDSALESEMPLOYEECD", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFEd);
            }

            // 画面の受注者(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFSt))
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF >= @FINDSTFRONTEMPLOYEECD ");
                SqlParameter paraStFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDSTFRONTEMPLOYEECD", SqlDbType.NChar);
                paraStFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFSt);
            }
            // 画面の受注者(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFEd)) 
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF <= @FINDEDFRONTEMPLOYEECD ");
                SqlParameter paraEdFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDEDFRONTEMPLOYEECD", SqlDbType.NChar);
                paraEdFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFEd);
            }

            // 画面の発行者(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFSt))
            {
                sql.Append(" AND A.SALESINPUTCODERF >= @FINDSTSALESINPUTCODE ");
                SqlParameter paraStSalesInputCd = sqlCommand.Parameters.Add("@FINDSTSALESINPUTCODE", SqlDbType.NChar);
                paraStSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFSt);
            }
            // 画面の発行者(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFEd)) 
            {
                sql.Append(" AND A.SALESINPUTCODERF <= @FINDEDSALESINPUTCODE ");
                SqlParameter paraEdSalesInputCd = sqlCommand.Parameters.Add("@FINDEDSALESINPUTCODE", SqlDbType.NChar);
                paraEdSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFEd);
            }
            // 画面の返品理由(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivSt))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF >= @FINDSTRETGOODSREASONDIV ");
                SqlParameter paraStRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDSTRETGOODSREASONDIV", SqlDbType.Int);
                paraStRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivSt));
            }
            // 画面の返品理由(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivEd))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF <= @FINDEDRETGOODSREASONDIV ");
                SqlParameter paraEdRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDEDRETGOODSREASONDIV", SqlDbType.Int);
                paraEdRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivEd));
            }

            return sql;
        }

        /// <summary>
        /// 売上データ検索条件文字列生成処理と条件値設定処理
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder MakeWhereString2(ref StringBuilder sql, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            // 論理削除区分
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");

            // 売上伝票区分=「1:返品」
            sql.Append(" AND  A.SALESSLIPCDRF = 1  ");

            // 受注ステータス=「40:出荷」
            sql.Append(" AND  A.ACPTANODRSTATUSRF = 40  ");

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
                    sql.Append(" AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ")  ");

                }
            }

            // 出荷日付
            /*---------DEL 2007/07/13 PVCS326------>>>>>
            // 今回締処理日はNULLではない場合
            if (paraWork.CurrentTotalDay != DateTime.MinValue)
            {
                // 出荷日付 >= 前回締処理日＋１
                sql.Append(" AND A.SHIPMENTDAYRF >= @FINDPARAPREVTOTALDAY2 ");
                SqlParameter paraPrevTotalDay = sqlCommand.Parameters.Add("@FINDPARAPREVTOTALDAY2", SqlDbType.Int);
                paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.PrevTotalDay.AddDays(1.0));
                // 出荷日付 <=今回締処理日
                sql.Append(" AND A.SHIPMENTDAYRF <= @FINDPARACURRENTTOTALDAY2 ");
                SqlParameter paraCurrentTotalDay = sqlCommand.Parameters.Add("@FINDPARACURRENTTOTALDAY2", SqlDbType.Int);
                paraCurrentTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.CurrentTotalDay);
            }
            else
            {
                // 出荷日付 >= 年度開始日＋１
                sql.Append(" AND A.SHIPMENTDAYRF >= @FINDSTARTYEARDATE2 ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE2", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate.AddDays(1.0));
                // 出荷日付 <=年度終了日
                sql.Append(" AND A.SHIPMENTDAYRF <= @FINDENDYEARDATE2 ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE2", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }
             ---------DEL 2007/07/13 PVCS326------>>>>>*/
            if (paraWork.StartYearDate != DateTime.MinValue)
            {
                // 出荷日付 >= 年度開始日＋１
                sql.Append(" AND A.SHIPMENTDAYRF >= @FINDSTARTYEARDATE2 ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE2", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate);
            }
            if (paraWork.EndYearDate != DateTime.MinValue)
            {
                // 出荷日付 <=年度終了日
                sql.Append(" AND A.SHIPMENTDAYRF <= @FINDENDYEARDATE2 ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE2", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }

            // 画面の得意先(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt))
            {
                sql.Append(" AND A.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE2 ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE2", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // 画面の得意先(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd))
            {
                sql.Append(" AND A.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE2  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE2", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }

            // 画面の担当者(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFSt))
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF >= @FINDSTSALESEMPLOYEECD2 ");
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSTSALESEMPLOYEECD2", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFSt);
            }
            // 画面の担当者(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFEd))
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF <= @FINDEDSALESEMPLOYEECD2 ");
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDEDSALESEMPLOYEECD2", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFEd);
            }

            // 画面の受注者(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFSt))
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF >= @FINDSTFRONTEMPLOYEECD2 ");
                SqlParameter paraStFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDSTFRONTEMPLOYEECD2", SqlDbType.NChar);
                paraStFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFSt);
            }
            // 画面の受注者(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFEd))
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF <= @FINDEDFRONTEMPLOYEECD2 ");
                SqlParameter paraEdFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDEDFRONTEMPLOYEECD2", SqlDbType.NChar);
                paraEdFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFEd);
            }

            // 画面の発行者(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFSt))
            {
                sql.Append(" AND A.SALESINPUTCODERF >= @FINDSTSALESINPUTCODE2 ");
                SqlParameter paraStSalesInputCd = sqlCommand.Parameters.Add("@FINDSTSALESINPUTCODE2", SqlDbType.NChar);
                paraStSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFSt);
            }
            // 画面の発行者(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFEd))
            {
                sql.Append(" AND A.SALESINPUTCODERF <= @FINDEDSALESINPUTCODE2 ");
                SqlParameter paraEdSalesInputCd = sqlCommand.Parameters.Add("@FINDEDSALESINPUTCODE2", SqlDbType.NChar);
                paraEdSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFEd);
            }
            // 画面の返品理由(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivSt))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF >= @FINDSTRETGOODSREASONDIV2 ");
                SqlParameter paraStRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDSTRETGOODSREASONDIV2", SqlDbType.Int);
                paraStRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivSt));
            }
            // 画面の返品理由(終了)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivEd))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF <= @FINDEDRETGOODSREASONDIV2 ");
                SqlParameter paraEdRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDEDRETGOODSREASONDIV2", SqlDbType.Int);
                paraEdRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivEd));
            }

            return sql;
        }
        #endregion

        #endregion

       #region クラス格納処理 Reader → GoodsReasonReportResultWork
        /// <summary>
        /// クラス格納処理 Reader → RetGoodsReasonReportResultWork
        /// </summary>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : ReaderからRetGoodsReasonReportResultWorkへ変換します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private RetGoodsReasonReportResultWork CopyToRetGoodsReasonReportResultWorkFromReader(ref SqlDataReader myReader, RetGoodsReasonReportParaWork paraWork)
        {
            RetGoodsReasonReportResultWork listWork = new RetGoodsReasonReportResultWork();
            #region クラスへ格納

            // 拠点ガイド略称
            listWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            // 実績計上拠点コード
            listWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));

            //出力順により選択
            switch (paraWork.PrintType)
            {
                case (0)://返品理由
                    {
                        // 返品理由コード
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // 返品理由
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    }
                    break;
                case (1)://得意先
                    {
                        // 得意先コード
                        listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // 得意先名称
                        listWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        // 返品理由コード
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // 返品理由
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;
                case (2)://担当者
                    {
                        // 販売従業員コード
                        listWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                        // 販売従業員名称
                        listWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        // 返品理由コード
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // 返品理由
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;
                case (3)://受注者
                    {
                        // 受付従業員コード
                        listWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                        // 受付従業員名称
                        listWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        // 返品理由コード
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // 返品理由
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;
                case (4)://発行者
                    {
                        // 売上入力者コード
                        listWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                        // 売上入力者名称
                        listWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        // 返品理由コード
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // 返品理由
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;

            }
            // 売上伝票合計（税抜き）
            listWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            // 種別
            int slipKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            if (30 == slipKind)
            {
                listWork.SlipKind = "売上";
            }
            if (40 == slipKind)
            {
                listWork.SlipKind = "貸出";
            }
            // 件数
            listWork.Count = Convert.ToInt64(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COUNT")));

            return listWork;
            #endregion
        }
        #endregion  クラス格納処理 Reader → GoodsReasonReportResultWork

       #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
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
