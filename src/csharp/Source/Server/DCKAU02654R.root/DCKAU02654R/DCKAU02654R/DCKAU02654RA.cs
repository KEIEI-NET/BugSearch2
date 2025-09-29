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
    /// 与信管理表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 与信管理表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CreditMngListWorkDB : RemoteDB, ICreditMngListWorkDB
    {
        /// <summary>
        /// 与信管理表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public CreditMngListWorkDB()
            :
            base("DCKAU02656D", "Broadleaf.Application.Remoting.ParamData.CreditMngListResultWork", "CUSTOMERCHANGERF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の与信管理表を戻します
        /// </summary>
        /// <param name="creditMngListResultWork">検索結果</param>
        /// <param name="creditMngListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の与信管理表を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
        public int Search(out object creditMngListResultWork, object creditMngListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            creditMngListResultWork = null;

            CreditMngListCndtnWork _creditMngListCndtnWork = creditMngListCndtnWork as CreditMngListCndtnWork;

            try
            {
                status = SearchProc(out creditMngListResultWork, _creditMngListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CreditMngListWorkDB.Search Exception=" + ex.Message);
                creditMngListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの与信管理表LISTを全て戻します
        /// </summary>
        /// <param name="creditMngListResultWork">検索結果</param>
        /// <param name="_creditMngListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの与信管理表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.15</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object creditMngListResultWork, CreditMngListCndtnWork _creditMngListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            creditMngListResultWork = null;

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


                status = SearchCreditMngProc(ref al, ref sqlConnection, _creditMngListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CreditMngListWorkDB.SearchProc Exception=" + ex.Message);
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

            creditMngListResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_creditMngListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchCreditMngProc(ref ArrayList al, ref SqlConnection sqlConnection, CreditMngListCndtnWork _creditMngListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSCH.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSCH.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSCH.CREDITMONEYRF" + Environment.NewLine;
                selectTxt += " ,CUSCH.WARNINGCREDITMONEYRF" + Environment.NewLine;
                //selectTxt += " ,ROUND(CAST(CUSCH.PRSNTACCRECBALANCERF AS FLOAT)/CAST(CUSCH.CREDITMONEYRF AS FLOAT)*100,2) AS CREDITRATERF" + Environment.NewLine;
                selectTxt += " ,CUSCH.PRSNTACCRECBALANCERF" + Environment.NewLine;
                selectTxt += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                selectTxt += " ,CUST.CUSTOMERAGENTNMRF" + Environment.NewLine;
                selectTxt += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "FROM CUSTOMERCHANGERF AS CUSCH" + Environment.NewLine;
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      CUST.ENTERPRISECODERF=CUSCH.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CUST.CUSTOMERCODERF=CUSCH.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SEC.ENTERPRISECODERF=CUST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SEC.SECTIONCODERF=CUST.MNGSECTIONCODERF" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _creditMngListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //与信率判定
                    /*           
                    if (_creditMngListCndtnWork.CreditRate > 0)
                    {
                        if (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CREDITRATERF")) < _creditMngListCndtnWork.CreditRate)
                        {
                          continue;
                        }
                    }
                    */
                    
                    #region 抽出結果-値セット
                    CreditMngListResultWork wkCreditMngListResultWork = new CreditMngListResultWork();

                    //格納項目
                    wkCreditMngListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkCreditMngListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkCreditMngListResultWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF"));
                    wkCreditMngListResultWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF"));
                    wkCreditMngListResultWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF"));
                    //wkCreditMngListResultWork.CreditRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CREDITRATERF"));
                    wkCreditMngListResultWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                    wkCreditMngListResultWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
                    wkCreditMngListResultWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    wkCreditMngListResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));

                    #endregion

                    al.Add(wkCreditMngListResultWork);

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
                base.WriteErrorLog(ex, "CreditMngListWorkDB.SearchCreditMngProc Exception=" + ex.Message);
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_creditMngListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CreditMngListCndtnWork _creditMngListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " CUSCH.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_creditMngListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND CUSCH.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND CUSCH.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード
            if (_creditMngListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _creditMngListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND CUST.MNGSECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //担当者コード設定
            if (_creditMngListCndtnWork.St_AgentCd != "")
            {
                retstring += " AND CUST.CUSTOMERAGENTCDRF>=@STCUSTOMERAGENTCD" + Environment.NewLine;
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@STCUSTOMERAGENTCD", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_creditMngListCndtnWork.St_AgentCd);
            }
            if (_creditMngListCndtnWork.Ed_AgentCd != "")
            {
                retstring += " AND (CUST.CUSTOMERAGENTCDRF<=@EDCUSTOMERAGENTCD OR CUST.CUSTOMERAGENTCDRF LIKE @EDCUSTOMERAGENTCD)" + Environment.NewLine;
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@EDCUSTOMERAGENTCD", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_creditMngListCndtnWork.Ed_AgentCd + "%");
            }

            /*  ＵＩ側で判断する為削除
            //与信限度額設定
            if (_creditMngListCndtnWork.CreditMoney > 0)
            {
                retstring += " AND CUSCH.CREDITMONEYRF>=@CREDITMONEY" + Environment.NewLine;
                SqlParameter paraStCreditMoney = sqlCommand.Parameters.Add("@CREDITMONEY", SqlDbType.Int);
                paraStCreditMoney.Value = SqlDataMediator.SqlSetInt64(_creditMngListCndtnWork.CreditMoney);
            }
            */
            #endregion
            return retstring;
        }
    }
}
