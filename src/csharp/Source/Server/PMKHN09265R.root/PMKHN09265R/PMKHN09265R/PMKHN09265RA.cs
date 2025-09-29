//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先マスタ（与信設定）DBリモートオブジェクト
//                  :   PMKHN09265R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ（与信設定）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（与信設定）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CustCreditDB : RemoteWithAppLockDB, ICustCreditDB
    {
        /// <summary>
        /// 得意先マスタ（与信設定）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        public CustCreditDB()
            : base("PMKHN09267D", "Broadleaf.Application.Remoting.ParamData.CustCreditWork", "CUSTCREDITRF")
        {

        }



        # region [Search]
        /// <summary>
        /// 得意先マスタリストを取得します。
        /// </summary>
        /// <param name="customerList">得意先マスタ（与信設定）情報を格納する ArrayList</param>
        /// <param name="paraWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（与信設定）のキー値が一致する、全ての得意先マスタ（与信設定）情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        public int Search(ref ArrayList customerList, CustCreditCndtnWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref customerList, paraWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 得意先マスタリストを取得します。
        /// </summary>
        /// <param name="customerList">得意先マスタ（与信設定）情報を格納する ArrayList</param>
        /// <param name="paraWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（与信設定）のキー値が一致する、全ての得意先マスタ（与信設定）情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        private int SearchProc(ref ArrayList customerList, CustCreditCndtnWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF" + Environment.NewLine;
                sqlText += ", CUSTOMERCODERF" + Environment.NewLine;
                sqlText += ", TOTALDAYRF" + Environment.NewLine;
                sqlText += ", CLAIMCODERF" + Environment.NewLine;
                sqlText += ", CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paraWork);
                # endregion
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    customerList.Add(this.CopyToCustomerFromReader(ref myReader));
                }

                if (customerList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustCreditCndtnWork paraWork)
        {
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

            // 論理削除区分
            retstring += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;

            if (paraWork.CustomerCodes == null)
            {
                //得意先コード範囲指定
                if (paraWork.St_CustomerCode != 0)
                {
                    retstring += " AND CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.St_CustomerCode);
                }
                if (paraWork.Ed_CustomerCode != 0)
                {
                    retstring += " AND CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.Ed_CustomerCode);
                }
            }
            else
            {
                //得意先コード単独指定
                string customerCodestr = "";
                foreach (Int32 cuscdstr in paraWork.CustomerCodes)
                {
                    if (customerCodestr != "")
                    {
                        customerCodestr += ",";
                    }
                    customerCodestr += "'" + cuscdstr.ToString() + "'";
                }

                if (customerCodestr != "")
                {
                    retstring += " AND CUSTOMERCODERF IN (" + customerCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //締日
            if (paraWork.TotalDay != 0)
            {
                retstring += " AND TOTALDAYRF=@TOTALDAY" + Environment.NewLine;
                SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                paraTotalDay.Value = SqlDataMediator.SqlSetInt32(paraWork.TotalDay);
            }

            //得意先コード＝請求先コード
            retstring += " AND CUSTOMERCODERF=CLAIMCODERF" + Environment.NewLine;

            //与信管理区分 1:する
            retstring += " AND CREDITMNGCODERF=1" + Environment.NewLine;

            return retstring;
        }

        /// <summary>
        /// クラス格納処理 Reader → CustomerWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustomerWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private CustomerWork CopyToCustomerFromReader(ref SqlDataReader myReader)
        {
            CustomerWork customerWork = new CustomerWork();

            this.CopyToCustomerFromReader(ref myReader, ref customerWork);

            return customerWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CustomerWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="customerWork">CustomerWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private void CopyToCustomerFromReader(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region クラスへ格納
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                # endregion
            }
        }

        /// <summary>
        /// 得意先マスタ（与信設定）情報を追加・更新します。
        /// </summary>
        /// <param name="resultList">追加・更新する得意先マスタ（与信設定）情報を格納する ArrayList</param>
        /// <param name="customerList">得意先マスタリスト</param>
        /// <param name="paraWork">抽出条件クラス</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : resultList に格納されている得意先マスタ（与信設定）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        private int SearchCustomerChange(ref ArrayList resultList, ArrayList customerList, CustCreditCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();
            try
            {
                if (customerList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    for (int i = 0; i < customerList.Count; i++)
                    {
                        CustomerWork customerWork = customerList[i] as CustomerWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CREDITMONEYRF" + Environment.NewLine;
                        sqlText += " ,WARNINGCREDITMONEYRF" + Environment.NewLine;
                        sqlText += " ,PRSNTACCRECBALANCERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {

                            CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();
                            //ＵＩ側での操作履歴更新の為、得意先変動情報Ｗｏｒｋを作成
                            CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                            customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; //企業コード
                            customerChangeWork.CustomerCode = customerWork.ClaimCode;    //請求先コード

                            if (paraWork.ProcDiv == 0)
                            {
                                //現在売掛残高設定

                                //現在売掛残高の算出を行う
                                custDmdPrcWork.EnterpriseCode = customerWork.EnterpriseCode; //企業コード
                                custDmdPrcWork.ClaimCode = customerWork.ClaimCode;           //請求先
                                custDmdPrcWork.CustomerCode = customerWork.CustomerCode;      //得意先（＝請求先）
                                custDmdPrcWork.AddUpSecCode = customerWork.ClaimSectionCode; //請求拠点コード
                                custDmdPrcWork.AddUpDate = DateTime.MaxValue;  //先打ち分も考慮して最大値をセット

                                #region 削除
                                /*
                                CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
                                //得意先マスタ、税率設定マスタ取得
                                status = custDmdPrcDB.GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //前回請求履歴情報取得
                                    status = custDmdPrcDB.GetDmdCAddUpHisAndCustDmdPrc(ref custDmdPrcWork, ref sqlConnection);
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (custDmdPrcWork.TotalAmntDspWayRef == 0)
                                        status = GetTotalAmount(ref custDmdPrcWork, ref sqlConnection);
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //入金額取得
                                    status = custDmdPrcDB.GetDepsitMain(ref custDmdPrcWork, ref sqlConnection);
                                }

                                ArrayList custDmdPrcChildWorkList = new ArrayList();
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //売上額取得
                                    status = custDmdPrcDB.GetSalesSlip(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection);
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //請求金額マスタ算出処理
                                    custDmdPrcDB.CalculateCustDmdPrc(ref custDmdPrcWork);
                                }

                                else return status;
                                */
                                #endregion

                                object objCustDmdPrcWork = (object)custDmdPrcWork;
                                string retMsg = string.Empty;

                                SqlConnection sqlConnectionDmd = null;
                                try
                                {

                                    sqlConnectionDmd = this.CreateSqlConnection(true);

                                    //締更新処理メソッド
                                    status = custDmdPrcDB.ReadCustDmdPrc(ref objCustDmdPrcWork, out retMsg, ref sqlConnectionDmd);
                                }
                                finally
                                {
                                    if (sqlConnectionDmd != null)
                                    {
                                        sqlConnectionDmd.Close();
                                        sqlConnectionDmd.Dispose();
                                    }
                                }

                                customerChangeWork.PrsntAccRecBalance = custDmdPrcWork.AfCalDemandPrice;

                                //前回値と変更あった場合のみ更新リストに追加
                                if (customerChangeWork.PrsntAccRecBalance != SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF")))
                                {
                                    //更新リストに追加
                                    al.Add(customerChangeWork);
                                }
                            }
                            else
                            {
                                bool changeFlg = false;

                                //与信額クリア
                                //与信額クリアフラグ
                                if (paraWork.CreditMoneyFlg)
                                {
                                    customerChangeWork.CreditMoney = 0;
                                    if (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF")) != 0) 
                                    {
                                        changeFlg = true;
                                    }

                                }

                                //警告与信額クリアフラグ
                                if (paraWork.WarningCrdMnyFrg)
                                {
                                    customerChangeWork.WarningCreditMoney = 0;

                                    if (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF")) != 0)
                                    {
                                        changeFlg = true;
                                    }
                                }

                                //現在売掛残高フラグ
                                if (paraWork.AccRecDiv)
                                {
                                    customerChangeWork.PrsntAccRecBalance = 0;

                                    if (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF")) != 0)
                                    {
                                        changeFlg = true;
                                    }
                                }

                                //前回値と変更あった場合のみ更新リストに追加
                                if (changeFlg)
                                {
                                    al.Add(customerChangeWork);
                                }
                            }

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                        else
                        {

                            //存在しない場合は算出しない
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                    }
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            resultList = al;

            return status;
        }

        # endregion

        # region [Write]
        /// <summary>
        /// 得意先マスタ（与信設定）情報を追加・更新します。
        /// </summary>
        /// <param name="objCustCreditList">追加・更新する得意先マスタ（与信設定）情報を含む ArrayList</param>
        /// <param name="paraCustCreditCndtn">抽出条件クラス CustCreditCndtnWork</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList に格納されている得意先マスタ（与信設定）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        public int Write(out object objCustCreditList, object paraCustCreditCndtn)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList resultList = new ArrayList();
            ArrayList customerChangeList = new ArrayList();
            try
            {
                // パラメータのキャスト
                ArrayList customerList = new ArrayList();
                CustCreditCndtnWork paraWork = paraCustCreditCndtn as CustCreditCndtnWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //得意先マスタ抽出
                status = this.Search(ref customerList, paraWork,ref sqlConnection, ref sqlTransaction);

                //得意先変動情報更新リストを作成
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.SearchCustomerChange(ref customerChangeList, customerList, paraWork, ref sqlConnection);
                }

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.Write(ref resultList, customerChangeList, paraWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objCustCreditList = resultList;
            return status;
        }

        /// <summary>
        /// 得意先マスタ（与信設定）情報を追加・更新します。
        /// </summary>
        /// <param name="resultList">追加・更新する得意先マスタ（与信設定）情報を格納する ArrayList</param>
        /// <param name="customerList">得意先マスタリスト</param>
        /// <param name="paraWork">抽出条件クラス</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList に格納されている得意先マスタ（与信設定）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        public int Write(ref ArrayList resultList,ArrayList customerList, CustCreditCndtnWork paraWork,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref resultList, customerList, paraWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 得意先マスタ（与信設定）情報を追加・更新します。
        /// </summary>
        /// <param name="resultList">追加・更新する得意先マスタ（与信設定）情報を格納する ArrayList</param>
        /// <param name="customerChangeList">得意先マスタリスト</param>
        /// <param name="paraWork">抽出条件クラス</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : resultList に格納されている得意先マスタ（与信設定）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        private int WriteProc(ref ArrayList resultList, ArrayList customerChangeList, CustCreditCndtnWork paraWork,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();
            
            try
            {
                if (customerChangeList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < customerChangeList.Count; i++)
                    {
                        CustomerChangeWork customerChangeWork = customerChangeList[i] as CustomerChangeWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerChangeWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            # region [UPDATE文]

                            sqlText = string.Empty;

                            sqlText += " UPDATE CUSTOMERCHANGERF SET" + Environment.NewLine;
                            sqlText += "    UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;

                            if (paraWork.ProcDiv == 0)
                            {
                                //現在売掛残高設定
                                sqlText += "  , PRSNTACCRECBALANCERF=@PRSNTACCRECBALANCE" + Environment.NewLine;
                            }
                            else
                            {
                                //与信額クリア
                                //与信額クリアフラグ
                                if (paraWork.CreditMoneyFlg)
                                {
                                    sqlText += "  , CREDITMONEYRF=@CREDITMONEY" + Environment.NewLine;
                                }
                                //警告与信額クリアフラグ
                                if (paraWork.WarningCrdMnyFrg)
                                {
                                    sqlText += "  , WARNINGCREDITMONEYRF=@WARNINGCREDITMONEY" + Environment.NewLine;
                                }
                                //現在売掛残高フラグ
                                if (paraWork.AccRecDiv)
                                {
                                    sqlText += "  , PRSNTACCRECBALANCERF=@PRSNTACCRECBALANCE" + Environment.NewLine;
                                }
                            }

                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerChangeWork.CustomerCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)customerChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            # region Parameterオブジェクトの作成(更新用)
                            //Parameterオブジェクトの作成(更新用)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerChangeWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.EnterpriseCode);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerChangeWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerChangeWork.UpdAssemblyId2);

                            CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

                            if (paraWork.ProcDiv == 0)
                            {
                                //現在売掛残高設定
                                SqlParameter paraPrsntAccRecBalance = sqlCommand.Parameters.Add("@PRSNTACCRECBALANCE", SqlDbType.BigInt);
                                paraPrsntAccRecBalance.Value = SqlDataMediator.SqlSetInt64(customerChangeWork.PrsntAccRecBalance); //計算後請求金額
                            }
                            else
                            {
                                //与信額クリア
                                //与信額クリアフラグ
                                if (paraWork.CreditMoneyFlg)
                                {
                                    SqlParameter paraCreditMoney = sqlCommand.Parameters.Add("@CREDITMONEY", SqlDbType.BigInt);
                                    paraCreditMoney.Value = 0;

                                }
                                //警告与信額クリアフラグ
                                if (paraWork.WarningCrdMnyFrg)
                                {
                                    SqlParameter paraWarningCreditMoney = sqlCommand.Parameters.Add("@WARNINGCREDITMONEY", SqlDbType.BigInt);
                                    paraWarningCreditMoney.Value = 0;
                                }
                                //現在売掛残高フラグ
                                if (paraWork.AccRecDiv)
                                {
                                    SqlParameter paraPrsntAccRecBalance = sqlCommand.Parameters.Add("@PRSNTACCRECBALANCE", SqlDbType.BigInt);
                                    paraPrsntAccRecBalance.Value = 0;
                                }
                            }

                            # endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(customerChangeWork);

                        }
                        else
                        {
                            //存在しない場合の追加は行わない
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                    }
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            resultList = al;

            return status;
        }
        # endregion

    }
}
