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
using Broadleaf.Library.Globarization;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 買掛残高元帳DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高元帳の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.09</br>
    /// <br></br>
    /// <br>Update Note: 未締分集計処理の追加</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// <br>Update Note: 仕入総括処理対応 仕入総括機能オプションの有効／無効判別と、有効時の仕入データ検索処理追加</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/10/02</br>
    /// <br></br>
    /// <br>Update Note: 画面入力の仕入先指定が正しく反映されない障害対応</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/11/08</br>
    /// <br>Update Note: 総括オプション有効時に支払先のみのデータを集計できていない障害対応</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/11/18</br>
    /// <br>Update Note: Redmine#47007 買掛残高元帳の消費税の対応</br>
    /// <br>Programmer : 田思春</br>
    /// <br>Date       : 2015/08/17</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class AccPayBalanceLedgerDB : RemoteDB, IAccPayBalanceLedgerDB
    {
        /// <summary>
        /// 買掛残高元帳DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        public AccPayBalanceLedgerDB()
            :
            base("AccPayBalanceLedgerDB", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecBalanceWork", "SUPLACCPAYRF")
        {
        }

        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;


        #region [SearchAccPayBalanceLedger]
        /// <summary>
        /// 指定された条件の買掛残高元帳を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の買掛残高元帳を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        public int SearchAccPayBalanceLedger(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork = null;

            ArrayList extrInfo_AccPayBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_AccPayBalanceWorkList == null)
            {
                extrInfo_AccPayBalanceWork = paraObj as ExtrInfo_AccPayBalanceWork;
            }
            else
            {
                if (extrInfo_AccPayBalanceWorkList.Count > 0)
                    extrInfo_AccPayBalanceWork = extrInfo_AccPayBalanceWorkList[0] as ExtrInfo_AccPayBalanceWork;
            }

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //●請求金額マスタ取得
                status = SearchAccPayBalanceLedgerProc(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                // ADD 2009.01.13 >>>
                //●未締分集計処理
                status = SearchPaymentSlipLedgerProc(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                // ADD 2009.01.13 <<<

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchAccPayBalanceLedger");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }
        // ADD 2009.01.13 >>>
        /// <summary>
        /// 指定された条件の未締分の売掛残高元帳を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の未締分の売掛残高元帳を戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.09</br>
        /// <br>Note       : Redmine#47007 買掛残高元帳の消費税の対応</br>
        /// <br>Programmer : 田思春</br>
        /// <br>Date       : 2015/08/17</br>
        private int SearchPaymentSlipLedgerProc(ref ArrayList retList, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList SupplierList = new ArrayList();
            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            DateTime StAddUpYearMonth = DateTime.MinValue;

            try
            {
                //●仕入先リスト作成
                status = SearchSupplierProc(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                //●最終締日算出(仕入先買掛金額マスタ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = GetMonthlyAddUpHis(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                }

                //●集計対象期間の判定処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        paraWork = SupplierList[i] as RsltInfo_AccPayBalanceWork;
                        DateTime addUpYearMonth = paraWork.AddUpYearMonth;   // ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 
                        if (paraWork.AddUpYearMonth < extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            StAddUpYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                            while (true)
                            {
                                //終了条件
                                if (StAddUpYearMonth > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                                {
                                    break;
                                }

                                // 得意先最終締日 < 画面開始年月
                                if (paraWork.AddUpYearMonth < StAddUpYearMonth)
                                {
                                    // ●未締分集計処理
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 ---------->>>>>
                                    DateTime tempAddUpYearMonth = DateTime.MinValue;
                                    //月度は最終締日の翌月の場合、計上年月はnullを設定して、「（MAKAU00133R）」の（前回情報取得GetMonthlyAddUpHisAndSuplAccPay）メッソドを利用して、前月売掛残高を取得する
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        tempAddUpYearMonth = paraWork.AddUpYearMonth;
                                        paraWork.AddUpYearMonth = DateTime.MinValue;
                                    }
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 ----------<<<<<<
                                    MakeSuplAccPayProc(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, ref sqlConnection);
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 ---------->>>>>
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        paraWork.AddUpYearMonth = tempAddUpYearMonth;
                                    }
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 ----------<<<<<<
                                }

                                //画面開始年月 + １ヶ月
                                StAddUpYearMonth = StAddUpYearMonth.AddMonths(1);
                            }
                        }
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
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchPaymentSlipLedgerProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }

        #region [SearchSupplierProc]
        /// <summary>
        /// 仕入先マスタから条件に該当する得意先リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先リストを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSupplierProc(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += " SUPL.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYEECODERF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM1RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM2RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERSNMRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTCONDRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTTOTALDAYRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTMONTHNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTDAYRF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " SUPPLIERRF AS SUPL" + Environment.NewLine;

                #region [JOIN]
                //拠点情報設定マスタ
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON SUPL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYMENTSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " SUPL.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);

                //論理削除区分
                selectTxt += " AND SUPL.LOGICALDELETECODERF=0" + Environment.NewLine;

                // 親仕入先コードのみ対象
                selectTxt += " AND SUPL.SUPPLIERCDRF = SUPL.PAYEECODERF" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYEECODERF IS NOT NULL" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYEECODERF != 0" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYMENTSECTIONCODERF IS NOT NULL" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYMENTSECTIONCODERF != 0 " + Environment.NewLine;

                //拠点コード
                if (extrInfo_AccPayBalanceWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in extrInfo_AccPayBalanceWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND SUPL.PAYMENTSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //支払先コード
                if (extrInfo_AccPayBalanceWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPL.PAYEECODERF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
                }
                // --- ADD 2012/11/08 ---------->>>>>
                //if (extrInfo_AccPayBalanceWork.St_PayeeCode != 99999999 && extrInfo_AccPayBalanceWork.St_PayeeCode != 0)
                if (extrInfo_AccPayBalanceWork.Ed_PayeeCode != 99999999 && extrInfo_AccPayBalanceWork.Ed_PayeeCode != 0)
                // --- ADD 2012/11/06 ----------<<<<<
                {
                    selectTxt += " AND SUPL.PAYEECODERF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_SupplierCd = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    // --- ADD 2012/11/08 ---------->>>>>
                    //paraEd_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
                    paraEd_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.Ed_PayeeCode);
                    // --- ADD 2012/11/06 ----------<<<<<
                }
                #endregion  //[WHERE句]

                #region [ORDER BY]
                selectTxt += "ORDER BY " + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYEECODERF" + Environment.NewLine;
                #endregion

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RsltInfo_AccPayBalanceWork ResultWork = new RsltInfo_AccPayBalanceWork();

                    #region [抽出結果-値セット]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    ResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                    ResultWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                    ResultWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                    ResultWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                    #endregion

                    al.Add(ResultWork);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchSupplierProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchSupplierProc]

        #region [GetMonthlyAddUpHis]
        /// <summary>
        /// 仕入先買掛金額マスタから条件に該当する最終締日を抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の最終締日を戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.13</br>
        private int GetMonthlyAddUpHis(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < al.Count; i++)
                {
                    paraWork = al[i] as RsltInfo_AccPayBalanceWork;
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;

                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " ADDUPDATERF," + Environment.NewLine;
                    sqlText += " ADDUPYEARMONTHRF" + Environment.NewLine;
                    sqlText += "FROM SUPLACCPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND PAYEECODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += " AND ADDUPDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "    SELECT MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += "    FROM SUPLACCPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    WHERE" + Environment.NewLine;
                    sqlText += "       ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "     AND PAYEECODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "     AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "   )" + Environment.NewLine;
                    #endregion  //[Select文作成]

                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.PayeeCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode.Trim());

                    myReader = sqlCommand.ExecuteReader();

                    ((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;

                    while (myReader.Read())
                    {
                        //[抽出結果-値セット]
                        ((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM", SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")));

                        if (((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth == extrInfo_AccPayBalanceWork.St_AddUpYearMonth.AddMonths(-1))
                        {
                            //画面開始年月= 前回履歴-１ヶ月の場合、売掛金額集計モジュールにて前回情報を取得させる
                            // ※((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonthがDateTime.MinValueの場合、売掛金額集計モジュールにて前回情報を取得する
                            ((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;
                        }

                    }
                    if (!myReader.IsClosed)
                        myReader.Close();

                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.GetMonthlyAddUpHis Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[GetMonthlyAddUpHis]

        #region [MakeSuplAccPayProc]
        /// <summary>
        /// 条件に該当する未締分の売掛残高元帳を抽出します。
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="AddUpYearMonth">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 条件に該当する未締分の売掛残高元帳を抽出します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.09</br>
        private int MakeSuplAccPayProc(ref ArrayList retList, ref RsltInfo_AccPayBalanceWork paraWork, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, DateTime AddUpYearMonth, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //■集計対象期間取得
            //自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();                
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                #region 買掛金集計モジュール 呼出パラメータ設定
                suplAccPayWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;//企業コード    ※得意先リストから
                suplAccPayWork.AddUpSecCode = paraWork.AddUpSecCode.Trim();    //請求拠点コード※仕入先リストから
                suplAccPayWork.PayeeCode = paraWork.PayeeCode;          //支払先コード  ※仕入先リストから
                suplAccPayWork.SupplierCd = paraWork.PayeeCode;

                suplAccPayWork.AddUpDate = EdMonthDate;                 //計上年月日(終了)
                suplAccPayWork.AddUpYearMonth = AddUpYearMonth;         //計上年月
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // 更新履歴無 
                    suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(開始)
                    suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(前回締日)
                }
                else
                {
                    // 更新履歴あり
                    suplAccPayWork.StMonCAddUpUpdDate = StMonthDate; // 計上年月日(開始)
                    suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// 計上年月日(前回締日)
                }

                object paraObj2 = (object)suplAccPayWork;
                string retMsg = null;
                #endregion

                //売掛金集計モジュール呼出
                status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //取得結果キャスト
                    ArrayList suplAccPayResult = new ArrayList();
                    suplAccPayResult.Add((SuplAccPayWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;
                    //取得結果セット
                    for (int j = 0; j < suplAccPayResult.Count; j++)
                    {
                        RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        #region 結果セット
                        wkRsltInfo_AccPayBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccPayBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccPayBalanceWork.PayeeCode = paraWork.PayeeCode;
                        wkRsltInfo_AccPayBalanceWork.PayeeName = paraWork.PayeeName;
                        wkRsltInfo_AccPayBalanceWork.PayeeName2 = paraWork.PayeeName2;
                        wkRsltInfo_AccPayBalanceWork.PayeeSnm = paraWork.PayeeSnm;
                        wkRsltInfo_AccPayBalanceWork.AddUpDate = ((SuplAccPayWork)suplAccPayResult[j]).AddUpDate;
                        wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = ((SuplAccPayWork)suplAccPayResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((SuplAccPayWork)suplAccPayResult[j]).LastTimeAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl2TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl3TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeFeePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeDisPayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeTtlBlcAcPay;
                        wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisTimeStock;
                        wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisStockTax;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeStockPrice;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTax;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricDis;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxDis;
                        wkRsltInfo_AccPayBalanceWork.TaxAdjust = ((SuplAccPayWork)suplAccPayResult[j]).TaxAdjust;
                        wkRsltInfo_AccPayBalanceWork.BalanceAdjust = ((SuplAccPayWork)suplAccPayResult[j]).BalanceAdjust;
                        wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = ((SuplAccPayWork)suplAccPayResult[j]).StckTtlAccPayBalance;
                        wkRsltInfo_AccPayBalanceWork.StockSlipCount = ((SuplAccPayWork)suplAccPayResult[j]).StockSlipCount;
                        wkRsltInfo_AccPayBalanceWork.PaymentCond = paraWork.PaymentCond;
                        wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                        wkRsltInfo_AccPayBalanceWork.PaymentMonthName = paraWork.PaymentMonthName;
                        wkRsltInfo_AccPayBalanceWork.PaymentDay = paraWork.PaymentDay;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((SuplAccPayWork)suplAccPayResult[j]).LaMonCAddUpUpdDate;

                        // 前回履歴が存在する場合、前月残高・繰越残高・当月末残高を計算
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccPayBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccPayBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).PayeeCode == wkRsltInfo_AccPayBalanceWork.PayeeCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((RsltInfo_AccPayBalanceWork)retList[i]).StckTtlAccPayBalance; // 前月残高
                                    // 今回繰越残高(買掛) = 前回残高 - 今回支払金額 
                                    wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = (wkRsltInfo_AccPayBalanceWork.LastTimeAccPay) - wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml;// 今回繰越残高(売掛)
                                    // 計算後金額 = 今回繰越残高 + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                                    wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay + (wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock + wkRsltInfo_AccPayBalanceWork.OfsThisStockTax);// 計算後請求金額
                                }
                            }
                        }
                        retList.Add(wkRsltInfo_AccPayBalanceWork);
                    }
                }
                paraWork.AddUpYearMonth = AddUpYearMonth;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.MakeSuplAccPayProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion  //[MakeSuplAccPayProc]


        // ADD 2009.01.13 <<<

        /// <summary>
        /// 指定された条件の買掛残高元帳を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の買掛残高元帳を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        private int SearchAccPayBalanceLedgerProc(ref ArrayList retList, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL文]

                string selectTxt = "";

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   SUPLACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEENAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEENAME2RF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STCKTTL2TMBFBLACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STCKTTL3TMBFBLACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMESTOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCPRCTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCKPRICRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCKPRICDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCPRCTAXDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTCONDRF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTTOTALDAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTMONTHNAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTDAYRF" + Environment.NewLine;
                selectTxt += "FROM SUPLACCPAYRF AS SUPLACC" + Environment.NewLine;

                selectTxt += "LEFT JOIN SUPPLIERRF AS SUPL" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     SUPLACC.ENTERPRISECODERF=SUPL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPLACC.PAYEECODERF=SUPL.SUPPLIERCDRF" + Environment.NewLine;

                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SUPLACC.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPLACC.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                #endregion

                //Where句作成
                selectTxt += MakeWhereString(ref sqlCommand, extrInfo_AccPayBalanceWork);

                //計上拠点コード＋請求先コード＋計上年月順に並び替える
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "  SUPLACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += ", SUPLACC.PAYEECODERF" + Environment.NewLine;
                selectTxt += ", SUPLACC.ADDUPYEARMONTHRF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;    
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_AccPayBalanceFromReader(ref myReader));

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

            return status;
        }

        #endregion

        // ---------- ADD 2012/10/02 ---------->>>>>
        #region [仕入総括オプション有効時メソッド群]

        #region [SearchAccPayBalanceLedgerForSumOptOn]
        /// <summary>
        /// 指定された条件の買掛残高元帳を戻します（仕入総括オプション有効時）
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の買掛残高元帳を戻します</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchAccPayBalanceLedgerForSumOptOn(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork = null;

            ArrayList extrInfo_AccPayBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_AccPayBalanceWorkList == null)
            {
                extrInfo_AccPayBalanceWork = paraObj as ExtrInfo_AccPayBalanceWork;
            }
            else
            {
                if (extrInfo_AccPayBalanceWorkList.Count > 0)
                    extrInfo_AccPayBalanceWork = extrInfo_AccPayBalanceWorkList[0] as ExtrInfo_AccPayBalanceWork;
            }

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●請求金額マスタ取得
                //  こちらの処理（締済データの取得）は、仕入総括オプション有効／無効に関わらず同じ処理を呼び出す
                status = SearchAccPayBalanceLedgerProc(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                //●未締分集計処理（仕入総括オプション有効時）
                status = SearchPaymentSlipLedgerProcForSumOptOn(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchAccPayBalanceLedgerForSumOptOn");
                retObj = new ArrayList();
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

            retObj = (object)retList;
            return status;
        }

        #endregion [SearchAccPayBalanceLedgerForSumOptOn]

        #region [SearchPaymentSlipLedgerProcForSumOptOn]
        /// <summary>
        /// 指定された条件の未締分の売掛残高元帳を戻します（仕入総括オプション有効時）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の未締分の売掛残高元帳を戻します</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        /// <br>Update Note: Redmine#47007 買掛残高元帳の消費税の対応</br>
        /// <br>Programmer : 田思春</br>
        /// <br>Date       : 2015/08/17</br>
        private int SearchPaymentSlipLedgerProcForSumOptOn(ref ArrayList retList, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList SupplierList = new ArrayList();
            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            DateTime StAddUpYearMonth = DateTime.MinValue;

            // 計上済リスト(集計レコードのコピー)
            ArrayList addUppedList = new ArrayList();
            addUppedList = (ArrayList)retList.Clone();
            //----- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 ---------->>>>>
            DateTime lastAddUpYearMonth = DateTime.MinValue;
            RsltInfo_AccPayBalanceWork currWork = null;
            RsltInfo_AccPayBalanceWork nextWork = null;
            // 前回月次処理月の取得
            for (int index = 0; index < addUppedList.Count; index++)
            {   
                currWork = addUppedList[index] as RsltInfo_AccPayBalanceWork;
                nextWork = null;
                if (index < addUppedList.Count - 1)
                {
                    nextWork = addUppedList[index + 1] as RsltInfo_AccPayBalanceWork;
                }

                if (nextWork != null)
                {
                    if (currWork.AddUpYearMonth < nextWork.AddUpYearMonth)
                    {
                        lastAddUpYearMonth = nextWork.AddUpYearMonth;
                    }
                    else
                    {
                        lastAddUpYearMonth = currWork.AddUpYearMonth;
                    }
                }
                else
                {
                    lastAddUpYearMonth = currWork.AddUpYearMonth;
                }
            }
            //----- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応 ----------<<<<<

            // 集計レコードに存在した仕入先⇔拠点はリアル集計してしまう。
            // 後で集計済を省く
            for (int cnt = 0; cnt < addUppedList.Count; cnt++)
            {
                paraWork = addUppedList[cnt] as RsltInfo_AccPayBalanceWork;
                
                #region ●計上拠点チェック
                // これから処理を行おうとする仕入先の計上拠点コードが、
                // 画面で指定されているコードと一致しない場合は、未締分集計処理をスキップする
                // 「全社」が指定されている場合は、このチェック処理自体がスキップされる
                if (extrInfo_AccPayBalanceWork.SectionCodes != null)
                {
                    bool flg = false;
                    foreach (string seccdstr in extrInfo_AccPayBalanceWork.SectionCodes)
                    {
                        if (seccdstr != "")
                        {
                            if (seccdstr == paraWork.AddUpSecCode.Trim())
                            {
                                flg = true;
                                break;
                            }
                        }
                    }
                    if (flg == false)
                        continue;
                }
                #endregion

                if ((paraWork.AddUpYearMonth.AddDays(1)).AddMonths(-1) < extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                {
                    StAddUpYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                    while (true)
                    {
                        //終了条件
                        if (StAddUpYearMonth > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            break;
                        }

                        // 得意先最終締日 < 画面開始年月
                        if ((paraWork.AddUpDate.AddDays(1)).AddMonths(-1) < StAddUpYearMonth)
                        {
                            // ★集計レコードから取得済みは省くように集計レコード取得済みリストを渡す
                            // ●未締分集計処理（仕入総括オプション有効時）
                            //MakeSuplAccPayProcForSumOptOn(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, ref sqlConnection);
                            //----- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応---------->>>>>
                            DateTime tempAddUpYearMonth = DateTime.MinValue;
                            // 画面の計上年月は前回月次更新月の翌月の場合、パラメータの計上年月はnullを設定して、
                            // 「（MAKAU00133R）」の（前回情報取得GetMonthlyAddUpHisAndSuplAccPay）メッソドを利用して、前月仕入残高を取得した後、消費税を計算する
                            if ((lastAddUpYearMonth.AddDays(1)).AddMonths(-1) == StAddUpYearMonth.AddMonths(-1))
                            {
                                tempAddUpYearMonth = paraWork.AddUpYearMonth;
                                paraWork.AddUpYearMonth = DateTime.MinValue;
                            }
                            //----- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応----------<<<<<
                            MakeSuplAccPayProcForAddedData_SumOptOn(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, addUppedList, ref sqlConnection);
                            //----- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応---------->>>>>
                            if ((lastAddUpYearMonth.AddDays(1)).AddMonths(-1) == StAddUpYearMonth.AddMonths(-1))
                            {
                                // パラメータの計上年月を元に戻す
                                paraWork.AddUpYearMonth = tempAddUpYearMonth;
                            }
                            //----- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応----------<<<<<
                        }

                        //画面開始年月 + １ヶ月
                        StAddUpYearMonth = StAddUpYearMonth.AddMonths(1);
                    }
                }
            }

            // retListを再度複製
            addUppedList = new ArrayList();
            addUppedList = (ArrayList)retList.Clone();
            
            try
            {
                //●仕入先リスト作成（仕入総括オプション有効時）
                status = SearchSupplierProcForSumOptOn(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                //●最終締日算出(仕入先買掛金額マスタ)
                //  この処理は仕入総括オプション有効時／無効に関係なく同じ処理を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = GetMonthlyAddUpHis(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                }

                //●仕入先データ追加取得(仕入先買掛金額マスタ)
                //  仕入履歴データを検索して、仕入先リスト内の「親」と同じ仕入先で仕入拠点（＝計上拠点）が違うデータを、
                //  仕入先リストに追加
                status = GetSupplierForDifferentStockSection(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //●集計対象期間の判定処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        paraWork = SupplierList[i] as RsltInfo_AccPayBalanceWork;
                        #region ●計上拠点チェック
                        // これから処理を行おうとする仕入先の計上拠点コードが、
                        // 画面で指定されているコードと一致しない場合は、未締分集計処理をスキップする
                        // 「全社」が指定されている場合は、このチェック処理自体がスキップされる
                        if (extrInfo_AccPayBalanceWork.SectionCodes != null)
                        {
                            bool flg = false;
                            foreach (string seccdstr in extrInfo_AccPayBalanceWork.SectionCodes)
                            {
                                if (seccdstr != "")
                                {
                                    if (seccdstr == paraWork.AddUpSecCode.Trim())
                                    {
                                        flg = true;
                                        break;
                                    }
                                }
                            }
                            if (flg == false)
                                continue;
                        }
                        #endregion

                        if (paraWork.AddUpYearMonth < extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            StAddUpYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                            DateTime addUpYearMonth = paraWork.AddUpYearMonth; // ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応
                            while (true)
                            {
                                //終了条件
                                if (StAddUpYearMonth > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                                {
                                    break;
                                }

                                // 得意先最終締日 < 画面開始年月
                                if (paraWork.AddUpYearMonth < StAddUpYearMonth)
                                {
                                    // ●未締分集計処理（仕入総括オプション有効時）
                                    // 画面の計上年月は前回月次更新月の翌月の場合、パラメータの計上年月はnullを設定して、
                                    // 「（MAKAU00133R）」の（前回情報取得GetMonthlyAddUpHisAndSuplAccPay）メッソドを利用して、前月仕入残高を取得した後、消費税を計算する
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応---------->>>>>
                                    DateTime tempAddUpYearMonth = DateTime.MinValue;
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        tempAddUpYearMonth = paraWork.AddUpYearMonth;
                                        paraWork.AddUpYearMonth = DateTime.MinValue;
                                    }
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応----------<<<<<<
                                    MakeSuplAccPayProcForSumOptOn(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, addUppedList, ref sqlConnection);
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応---------->>>>>
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        paraWork.AddUpYearMonth = tempAddUpYearMonth;
                                    }
                                    // ---------- ADD 2015/08/17 田思春 For Redmine#47007 買掛残高元帳の消費税の対応----------<<<<<<
                                }

                                //画面開始年月 + １ヶ月
                                StAddUpYearMonth = StAddUpYearMonth.AddMonths(1);
                            }
                        }
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
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchPaymentSlipLedgerProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }
        #endregion [SearchPaymentSlipLedgerProcForSumOptOn]

        #region [SearchSupplierProcForSumOptOn]
        /// <summary>
        /// 仕入先マスタから条件に該当する仕入先リストを抽出します。（仕入総括オプション有効時）
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先リストを戻します</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        private int SearchSupplierProcForSumOptOn(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += " SUPL.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += " SUPL.MNGSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM1RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM2RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERSNMRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTCONDRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTTOTALDAYRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTMONTHNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTDAYRF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERCDRF" + Environment.NewLine; // オプション無効時は支払先コードだったが、ここでは仕入先コードを取得
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " SUPPLIERRF AS SUPL" + Environment.NewLine;

                #region [JOIN]
                //拠点情報設定マスタ
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON SUPL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                // 仕入総括の場合は管理拠点コードが一致の場合（親子関係が無くなるため。仕入総括なしの場合は入力拠点コード）
                selectTxt += " AND SUPL.MNGSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " SUPL.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);

                //論理削除区分
                selectTxt += " AND SUPL.LOGICALDELETECODERF=0" + Environment.NewLine;

                // オプション無効時は支払先コードだったが、ここでは仕入先コードで検索
                // また、いわゆる支払先での「親」「子」に関係なくデータを取得する
                if (extrInfo_AccPayBalanceWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPL.SUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
                }
                if (extrInfo_AccPayBalanceWork.Ed_PayeeCode != 99999999 && extrInfo_AccPayBalanceWork.Ed_PayeeCode != 0)
                {
                    selectTxt += " AND SUPL.SUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_SupplierCd = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.Ed_PayeeCode);
                }
                #endregion  //[WHERE句]

                #region [ORDER BY]
                selectTxt += "ORDER BY " + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RsltInfo_AccPayBalanceWork ResultWork = new RsltInfo_AccPayBalanceWork();

                    #region [抽出結果-値セット]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    ResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                    ResultWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                    ResultWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                    ResultWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                    #endregion

                    al.Add(ResultWork);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchSupplierProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchSupplierProcForSumOptOn]

        #region [GetSupplierForDifferentStockSection]
        /// <summary>
        /// 別計上拠点仕入先データ取得（仕入総括オプション有効時のみ動作）
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入履歴データを検索し、仕入先リスト内の仕入先で仕入拠点（＝計上拠点）が違う仕入先を取得して仕入先リストに追加</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        private int GetSupplierForDifferentStockSection(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            string sqlText = string.Empty;

			// --- ADD 2012/11/18 ---------->>>>>
            //日付取得用
            DateTime startYearMonth = DateTime.MinValue;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            DateTime dateBuf = DateTime.MinValue;
			// --- ADD 2012/11/18 ----------<<<<<

            try
            {
                #region ●仕入履歴データ検索期間取得のため、自社情報取得
                CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                CompanyInfDB companyInfDB = new CompanyInfDB();
                ArrayList arrayList;

                paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
                status = companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                paraCompanyInfWork = (CompanyInfWork)arrayList[0];
                FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);
                #endregion ●仕入履歴データ検索期間取得のため、自社情報取得

                ArrayList orgList;
                orgList = (ArrayList)al.Clone();

                for (int i = 0; i < orgList.Count; i++)
                {
                    #region ●仕入履歴データ検索条件（仕入計上日付の範囲）決定
                    paraWork = al[i] as RsltInfo_AccPayBalanceWork;

                    // 最終締日の翌月を取得（これがこの仕入先＝支払先の未締分期間の開始年月になる）
                    DateTime dt = paraWork.AddUpYearMonth.AddMonths(1);

                    // この仕入先（＝支払先）の未締分期間の開始年月と、画面で指定された処理年月（開始）の翌月を比較し、
                    // 仕入データを検索する際の開始年月を決定
                    if (dt < extrInfo_AccPayBalanceWork.St_AddUpYearMonth)
                    {
                        // 未締分期間の開始年月が画面で指定された処理年月（開始）より前であり、
                        // 画面指定の範囲外となるため、開始年月は画面指定の処理年月（開始）とする
                        startYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                    }
                    else if (dt == extrInfo_AccPayBalanceWork.St_AddUpYearMonth)
                    {
                        // 未締分期間の開始年月と画面指定の処理年月（開始）が一致するので、
                        // 未締分期間の開始年月をそのまま開始年月とする
                        // 　ここでは、未締分のデータを取得するための仕入先（＝支払先）をリストに設定したいので、
                        //   最終締め日の翌月、つまり未締分の期間の最初の年月を開始年月とする
                        startYearMonth = dt;
                    }
                    else
                    {
                        // 未締分期間の開始年月が画面指定の処理年月（開始）より後なので、
                        // さらに画面指定の処理年月（終了）より後になっていないかチェック
                        if (dt > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            // 画面指定の範囲外となるため、この仕入先（＝支払先）については、
                            // 仕入履歴データの検索処理は行わない
                            continue;
                        }
                        else
                        {
                            // 画面指定の処理年月（終了）以前になっているので、
                            // 未締分期間の開始年月をそのまま開始年月とする
                            startYearMonth = dt;
                        }
                    }

                    // 決定した開始年月と、画面指定の処理年月（終了）から、検索範囲の開始日と終了日を取得
                    parafinYearTableGenerator.GetDaysFromMonth(startYearMonth, out startDate, out dateBuf);
                    parafinYearTableGenerator.GetDaysFromMonth(extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth, out dateBuf, out endDate);
                    #endregion ●仕入履歴データ検索条件（仕入計上日付の範囲）決定

                    #region ●仕入履歴データ検索

                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;

                    #region ●Select文作成
                    
#if false //旧コード
                    sqlText = string.Empty;
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;                                 // 抽出項目
                    sqlText += " STOCK.STOCKSECTIONCDRF AS SECTIONCDRF," + Environment.NewLine;    //  仕入拠点コード
                    sqlText += " SEC.SECTIONGUIDESNMRF AS SECNAMERF," + Environment.NewLine;       //  仕入拠点名（このカラムのみ拠点情報設定マスタから）
                    sqlText += " STOCK.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;             //  仕入先コード

                    sqlText += "FROM STOCKSLIPHISTRF AS STOCK,  SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;

                    sqlText += "WHERE" + Environment.NewLine;                                                       // ここから検索条件
                    sqlText += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;             //  企業コード
                    sqlText += " AND STOCK.LOGICALDELETECODERF = 0" + Environment.NewLine;                          //  論理削除区分「0」（有効）
                    sqlText += " AND STOCK.STOCKSECTIONCDRF<>@FINDSTOCKSECTIONCDRF" + Environment.NewLine;          //  仕入拠点コードは仕入先リスト内のデータと一致しないデータ
                    sqlText += " AND STOCK.SUPPLIERCDRF=@FINDPAYEECODERF" + Environment.NewLine;                    //  仕入先コードは一致
                    sqlText += " AND STOCK.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATERF" + Environment.NewLine;   //  仕入計上日付・開始
                    sqlText += " AND STOCK.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATERF" + Environment.NewLine;     //  仕入計上日付・終了
                    sqlText += " AND STOCK.SUPPLIERFORMALRF= 0" + Environment.NewLine;                              //  仕入形式「0」（仕入）
                    sqlText += " AND STOCK.DEBITNOTEDIVRF= 0" + Environment.NewLine;                                //  赤伝区分「0」（黒伝）
                    sqlText += " AND STOCK.SUPPLIERSLIPCDRF IN (10,20) " + Environment.NewLine;                     //  仕入伝票区分「10」（仕入）or 「20」（返品）
                    sqlText += " AND STOCK.STOCKGOODSCDRF IN (0,6) " + Environment.NewLine;                         //  仕入商品区分「0」（商品）or 「6」（合計入力）
                    sqlText += " AND STOCK.ENTERPRISECODERF = SEC.ENTERPRISECODERF " + Environment.NewLine;         //  これ以降は、拠点情報設定マスタの結合条件
                    sqlText += " AND STOCK.STOCKSECTIONCDRF = SEC.SECTIONCODERF " + Environment.NewLine;

                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "        STOCKSECTIONCDRF, SUPPLIERCDRF ASC" + Environment.NewLine;
#endif
					// --- ADD 2012/11/18 ---------->>>>>
                    sqlText = string.Empty;
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += " STOCK.STOCKSECTIONCDRF AS SECTIONCDRF," + Environment.NewLine;    // 仕入拠点コード
                    sqlText += " SEC.SECTIONGUIDESNMRF AS SECNAMERF," + Environment.NewLine;     // 仕入拠点名（このカラムのみ拠点情報設定マスタから）
                    sqlText += " STOCK.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;      // 仕入先コード
                    sqlText += "FROM STOCKSLIPHISTRF AS STOCK" + Environment.NewLine;
                    sqlText += "  LEFT JOIN SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON (STOCK.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;       // 拠点情報設定マスタ結合条件
                    sqlText += " AND STOCK.STOCKSECTIONCDRF = SEC.SECTIONCODERF" + Environment.NewLine;
                    sqlText += " AND SEC.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND STOCK.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += " AND STOCK.STOCKSECTIONCDRF<>@FINDSTOCKSECTIONCDRF" + Environment.NewLine;   // 仕入拠点コードは仕入先リスト内のデータと一致しないデータ
                    sqlText += " AND STOCK.SUPPLIERCDRF=@FINDPAYEECODERF" + Environment.NewLine;             // 仕入先コードは一致
                    sqlText += " AND STOCK.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATERF" + Environment.NewLine;        // 仕入計上日付・開始
                    sqlText += " AND STOCK.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATERF" + Environment.NewLine;          // 仕入計上日付・終了
                    sqlText += " AND STOCK.SUPPLIERFORMALRF= 0" + Environment.NewLine;                                   // 仕入形式「0」（仕入）
                    sqlText += " AND STOCK.SUPPLIERSLIPCDRF IN (10,20)" + Environment.NewLine;                           // 仕入伝票区分「10」（仕入）or 「20」（返品）
                    sqlText += " AND STOCK.STOCKGOODSCDRF IN (0,6)" + Environment.NewLine;                               // 仕入商品区分「0」（商品）or 「6」（合計入力）
                    sqlText += "UNION" + Environment.NewLine;
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += " PAY.ADDUPSECCODERF AS SECTIONCDRF," + Environment.NewLine;
                    sqlText += " SEC.SECTIONGUIDESNMRF AS SECNAMERF," + Environment.NewLine;
                    sqlText += " PAY.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "FROM PAYMENTSLPRF AS PAY" + Environment.NewLine;
                    sqlText += "  LEFT JOIN SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON (PAY.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPSECCODERF = SEC.SECTIONCODERF" + Environment.NewLine;
                    sqlText += " AND SEC.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "     PAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND PAY.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPSECCODERF<>@FINDSTOCKSECTIONCDRF" + Environment.NewLine;
                    sqlText += " AND PAY.SUPPLIERCDRF=@FINDPAYEECODERF" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPADATERF>=@FINDSTARTSTOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPADATERF<=@FINDENDSTOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += " AND PAY.SUPPLIERFORMALRF= 0" + Environment.NewLine;
                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "    SECTIONCDRF, SUPPLIERCDRF ASC" + Environment.NewLine;
					// --- ADD 2012/11/18 ----------<<<<<
                    #endregion  ●Select文作成

                    #region ●クエリ実行と抽出結果取得
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCDRF", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODERF", SqlDbType.Int);
                    SqlParameter findStartStockAddUpADate = sqlCommand.Parameters.Add("@FINDSTARTSTOCKADDUPADATERF", SqlDbType.Int);
                    SqlParameter findEndStockAddUpADate = sqlCommand.Parameters.Add("@FINDENDSTOCKADDUPADATERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);
                    findParaStockSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(paraWork.PayeeCode);
                    findStartStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(startDate);
                    findEndStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(endDate);

                    // クエリ実行
                    myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            #region [抽出結果-値セット]
                            RsltInfo_AccPayBalanceWork ResultWork = new RsltInfo_AccPayBalanceWork();

                            ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // 仕入先コード 設定先は支払先コードプロパティだが、設定する値は仕入先コード
                            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCDRF")); // 仕入拠点コード
                            ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECNAMERF"));   // 仕入拠点名称

                            // 上記以外の項目は、仕入先（＝支払先）が同じなので、仕入先リストのデータをコピー
                            //   仕入先名称については、支払先名称プロパティへ、同じく支払先名称プロパティの値を設定しているが、
                            //   仕入先リストにはもともと仕入先名称が設定されているので問題は無し
                            ResultWork.AddUpYearMonth = paraWork.AddUpYearMonth;
                            ResultWork.PayeeName = paraWork.PayeeName;
                            ResultWork.PayeeName2 = paraWork.PayeeName2;
                            ResultWork.PayeeSnm = paraWork.PayeeSnm;
                            ResultWork.PaymentCond = paraWork.PaymentCond;
                            ResultWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                            ResultWork.PaymentMonthName = paraWork.PaymentMonthName;
                            ResultWork.PaymentDay = paraWork.PaymentDay;
                            #endregion

                            // 仕入先リストに追加
                            al.Add(ResultWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        }
                    if (!myReader.IsClosed)
                        myReader.Close();
                    #endregion ●クエリ実行と抽出結果取得

                    #endregion ●仕入データ検索
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.GetSupplierForDifferentStockSection Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;

        }
        #endregion

        #region [MakeSuplAccPayProcForSumOptOn]
        /// <summary>
        /// 条件に該当する未締分の売掛残高元帳を抽出します。（仕入総括オプション有効時）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="AddUpYearMonth">検索パラメータ</param>
        /// <param name="uppedList">集計済みデータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 条件に該当する未締分の売掛残高元帳を抽出します</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        private int MakeSuplAccPayProcForSumOptOn(ref ArrayList retList, ref RsltInfo_AccPayBalanceWork paraWork, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, DateTime AddUpYearMonth, ArrayList uppedList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //■集計対象期間取得
            //自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                // ここで集計レコードに格納済みリストであればリアル集計しない
                foreach (RsltInfo_AccPayBalanceWork uppedWork in uppedList)
                {
                    if (paraWork.AddUpSecCode.Trim() == uppedWork.AddUpSecCode.Trim() &&
                        paraWork.PayeeCode == uppedWork.PayeeCode &&
                        EdMonthDate == uppedWork.AddUpDate)
                    {
                        // 集計レコードで計上済みなのでリアル集計しない
                        return status;
                    }
                }

                #region 買掛金集計モジュール 呼出パラメータ設定
                suplAccPayWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;  //企業コード
                suplAccPayWork.AddUpSecCode = paraWork.AddUpSecCode.Trim();                 //請求拠点コード※仕入先リストから
                suplAccPayWork.PayeeCode = paraWork.PayeeCode;                              //支払先コード  ※仕入先リストから
                suplAccPayWork.SupplierCd = paraWork.PayeeCode;

                suplAccPayWork.AddUpDate = EdMonthDate;                 //計上年月日(終了)
                suplAccPayWork.AddUpYearMonth = AddUpYearMonth;         //計上年月
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // 更新履歴無 
                    suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(開始)
                    suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(前回締日)
                }
                else
                {
                    // 更新履歴あり
                    suplAccPayWork.StMonCAddUpUpdDate = StMonthDate;            // 計上年月日(開始)
                    suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// 計上年月日(前回締日)
                }

                object paraObj2 = (object)suplAccPayWork;
                string retMsg = null;
                #endregion

                //売掛金集計モジュール呼出（仕入総括リアル集計メソッド）
                status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //取得結果キャスト
                    ArrayList suplAccPayResult = new ArrayList();
                    suplAccPayResult.Add((SuplAccPayWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;
                    //取得結果セット
                    for (int j = 0; j < suplAccPayResult.Count; j++)
                    {
                        RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        #region 結果セット
                        wkRsltInfo_AccPayBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccPayBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccPayBalanceWork.PayeeCode = paraWork.PayeeCode;
                        wkRsltInfo_AccPayBalanceWork.PayeeName = paraWork.PayeeName;
                        wkRsltInfo_AccPayBalanceWork.PayeeName2 = paraWork.PayeeName2;
                        wkRsltInfo_AccPayBalanceWork.PayeeSnm = paraWork.PayeeSnm;
                        wkRsltInfo_AccPayBalanceWork.AddUpDate = ((SuplAccPayWork)suplAccPayResult[j]).AddUpDate;
                        wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = ((SuplAccPayWork)suplAccPayResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((SuplAccPayWork)suplAccPayResult[j]).LastTimeAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl2TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl3TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeFeePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeDisPayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeTtlBlcAcPay;
                        wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisTimeStock;
                        wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisStockTax;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeStockPrice;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTax;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricDis;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxDis;
                        wkRsltInfo_AccPayBalanceWork.TaxAdjust = ((SuplAccPayWork)suplAccPayResult[j]).TaxAdjust;
                        wkRsltInfo_AccPayBalanceWork.BalanceAdjust = ((SuplAccPayWork)suplAccPayResult[j]).BalanceAdjust;
                        wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = ((SuplAccPayWork)suplAccPayResult[j]).StckTtlAccPayBalance;
                        wkRsltInfo_AccPayBalanceWork.StockSlipCount = ((SuplAccPayWork)suplAccPayResult[j]).StockSlipCount;
                        wkRsltInfo_AccPayBalanceWork.PaymentCond = paraWork.PaymentCond;
                        wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                        wkRsltInfo_AccPayBalanceWork.PaymentMonthName = paraWork.PaymentMonthName;
                        wkRsltInfo_AccPayBalanceWork.PaymentDay = paraWork.PaymentDay;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((SuplAccPayWork)suplAccPayResult[j]).LaMonCAddUpUpdDate;

                        // 前回履歴が存在する場合、前月残高・繰越残高・当月末残高を計算
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccPayBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccPayBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).PayeeCode == wkRsltInfo_AccPayBalanceWork.PayeeCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((RsltInfo_AccPayBalanceWork)retList[i]).StckTtlAccPayBalance; // 前月残高
                                    // 今回繰越残高(買掛) = 前回残高 - 今回支払金額 
                                    wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = (wkRsltInfo_AccPayBalanceWork.LastTimeAccPay) - wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml;// 今回繰越残高(売掛)
                                    // 計算後金額 = 今回繰越残高 + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                                    wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay + (wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock + wkRsltInfo_AccPayBalanceWork.OfsThisStockTax);// 計算後請求金額
                                }
                            }
                        }
                        retList.Add(wkRsltInfo_AccPayBalanceWork);
                    }
                }
                paraWork.AddUpYearMonth = AddUpYearMonth;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.MakeSuplAccPayProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion  //[MakeSuplAccPayProcForSumOptOn]

        #region ★集計レコードの未来日付用リアル集計取得メソッド
        /// <summary>
        /// 条件に該当する未締分の売掛残高元帳を抽出します。（仕入総括オプション有効時）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索パラメータ</param>
        /// <param name="AddUpYearMonth">検索パラメータ</param>
        /// <param name="uppedList">集計済みデータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 条件に該当する未締分の売掛残高元帳を抽出します</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/10/02</br>
        private int MakeSuplAccPayProcForAddedData_SumOptOn(ref ArrayList retList, ref RsltInfo_AccPayBalanceWork paraWork, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, DateTime AddUpYearMonth, ArrayList uppedList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //■集計対象期間取得
            //自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                 #region 買掛金集計モジュール 呼出パラメータ設定
                suplAccPayWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;  //企業コード
                suplAccPayWork.AddUpSecCode = paraWork.AddUpSecCode.Trim();                 //請求拠点コード※仕入先リストから
                suplAccPayWork.PayeeCode = paraWork.PayeeCode;                              //支払先コード  ※仕入先リストから
                suplAccPayWork.SupplierCd = paraWork.PayeeCode;

                suplAccPayWork.AddUpDate = EdMonthDate;                 //計上年月日(終了)
                suplAccPayWork.AddUpYearMonth = AddUpYearMonth;         //計上年月
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // 更新履歴無 
                    suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(開始)
                    suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(前回締日)
                }
                else
                {
                    // 更新履歴あり
                    suplAccPayWork.StMonCAddUpUpdDate = StMonthDate;            // 計上年月日(開始)
                    suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// 計上年月日(前回締日)
                }

                object paraObj2 = (object)suplAccPayWork;
                string retMsg = null;
                #endregion

                //売掛金集計モジュール呼出（仕入総括リアル集計メソッド）
                status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg, ref sqlConnection);

                // ここで集計レコードから取得済みのデータであれば、格納しない
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //取得結果キャスト
                    ArrayList suplAccPayResult = new ArrayList();
                    suplAccPayResult.Add((SuplAccPayWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;

                    //取得結果セット
                    for (int j = 0; j < suplAccPayResult.Count; j++)
                    {
                        RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        //集計レコードから取得済みのデータは処理しない
                        // ★集計レコードと同じものはリアル集計しない
                        foreach (RsltInfo_AccPayBalanceWork retWork in retList)
                        {
                            if ((retWork.AddUpDate == ((SuplAccPayWork)suplAccPayResult[0]).AddUpDate) &&
                                retWork.PayeeCode ==((SuplAccPayWork)suplAccPayResult[0]).PayeeCode &&
                                retWork.AddUpSecCode.Trim() == ((SuplAccPayWork)suplAccPayResult[0]).AddUpSecCode.Trim())                            
                            {
                                return status;
                            }
                        }

                        #region 結果セット
                        wkRsltInfo_AccPayBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccPayBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccPayBalanceWork.PayeeCode = paraWork.PayeeCode;
                        wkRsltInfo_AccPayBalanceWork.PayeeName = paraWork.PayeeName;
                        wkRsltInfo_AccPayBalanceWork.PayeeName2 = paraWork.PayeeName2;
                        wkRsltInfo_AccPayBalanceWork.PayeeSnm = paraWork.PayeeSnm;
                        wkRsltInfo_AccPayBalanceWork.AddUpDate = ((SuplAccPayWork)suplAccPayResult[j]).AddUpDate;
                        wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = ((SuplAccPayWork)suplAccPayResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((SuplAccPayWork)suplAccPayResult[j]).LastTimeAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl2TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl3TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeFeePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeDisPayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeTtlBlcAcPay;
                        wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisTimeStock;
                        wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisStockTax;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeStockPrice;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTax;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricDis;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxDis;
                        wkRsltInfo_AccPayBalanceWork.TaxAdjust = ((SuplAccPayWork)suplAccPayResult[j]).TaxAdjust;
                        wkRsltInfo_AccPayBalanceWork.BalanceAdjust = ((SuplAccPayWork)suplAccPayResult[j]).BalanceAdjust;
                        wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = ((SuplAccPayWork)suplAccPayResult[j]).StckTtlAccPayBalance;
                        wkRsltInfo_AccPayBalanceWork.StockSlipCount = ((SuplAccPayWork)suplAccPayResult[j]).StockSlipCount;
                        wkRsltInfo_AccPayBalanceWork.PaymentCond = paraWork.PaymentCond;
                        wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                        wkRsltInfo_AccPayBalanceWork.PaymentMonthName = paraWork.PaymentMonthName;
                        wkRsltInfo_AccPayBalanceWork.PaymentDay = paraWork.PaymentDay;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((SuplAccPayWork)suplAccPayResult[j]).LaMonCAddUpUpdDate;

                        // 前回履歴が存在する場合、前月残高・繰越残高・当月末残高を計算
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccPayBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccPayBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).PayeeCode == wkRsltInfo_AccPayBalanceWork.PayeeCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((RsltInfo_AccPayBalanceWork)retList[i]).StckTtlAccPayBalance; // 前月残高
                                    // 今回繰越残高(買掛) = 前回残高 - 今回支払金額 
                                    wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = (wkRsltInfo_AccPayBalanceWork.LastTimeAccPay) - wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml;// 今回繰越残高(売掛)
                                    // 計算後金額 = 今回繰越残高 + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                                    wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay + (wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock + wkRsltInfo_AccPayBalanceWork.OfsThisStockTax);// 計算後請求金額
                                }
                            }
                        }
                        retList.Add(wkRsltInfo_AccPayBalanceWork);
                    }
                }
               //paraWork.AddUpYearMonth = AddUpYearMonth;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.MakeSuplAccPayProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        #endregion



        #endregion [仕入総括オプション有効時メソッド群]
        // ---------- ADD 2012/10/02 ----------<<<<<

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_AccPayBalanceWork">検索条件格納クラス</param>
        /// <returns>買掛残高元帳抽出のSQL文字列</returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork)
        {
            //基本WHERE句の作成
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //●固定条件
            //企業コード
            retString.Append("SUPLACC.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND SUPLACC.LOGICALDELETECODERF=0 ");

            //親レコードのみを対象とする(得意先コード=0のみ対象)
            retString.Append("AND SUPLACC.SUPPLIERCDRF=0 ");

            //●これよりパラメータの値により動的変化の項目
            //計上拠点コード
            if (extrInfo_AccPayBalanceWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_AccPayBalanceWork.SectionCodes)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND SUPLACC.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //請求先コード
            if (extrInfo_AccPayBalanceWork.St_PayeeCode > 0)
            {
                retString.Append("AND SUPLACC.PAYEECODERF>=@ST_PAYEECODE ");
                SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
                paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
            }
            if (extrInfo_AccPayBalanceWork.Ed_PayeeCode > 0)
            {
                retString.Append("AND SUPLACC.PAYEECODERF<=@ED_PAYEECODE ");
                SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
                paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.Ed_PayeeCode);
            }

            //対象年月
            if (extrInfo_AccPayBalanceWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND SUPLACC.ADDUPYEARMONTHRF>=@ST_ADDUPYEARMONTH ");
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ST_ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccPayBalanceWork.St_AddUpYearMonth);
            }
            if (extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND SUPLACC.ADDUPYEARMONTHRF<=@ED_ADDUPYEARMONTH ");
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_ADDUPYEARMONTH", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth);
            }


            return retString.ToString();
        }
        #endregion

        #region [買掛残高元帳抽出結果クラス格納処理]
        /// <summary>
        /// 買掛残高元帳抽出結果クラス格納処理 Reader → RsltInfo_AccPayBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_AccPayBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        private RsltInfo_AccPayBalanceWork CopyToRsltInfo_AccPayBalanceFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();

            #region クラスへ格納
            wkRsltInfo_AccPayBalanceWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_AccPayBalanceWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_AccPayBalanceWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkRsltInfo_AccPayBalanceWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkRsltInfo_AccPayBalanceWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkRsltInfo_AccPayBalanceWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkRsltInfo_AccPayBalanceWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCPAYRF"));
            wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL2TMBFBLACCPAYRF"));
            wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL3TMBFBLACCPAYRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACPAYRF"));
            wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF"));
            wkRsltInfo_AccPayBalanceWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkRsltInfo_AccPayBalanceWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLACCPAYBALANCERF"));
            wkRsltInfo_AccPayBalanceWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkRsltInfo_AccPayBalanceWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
            wkRsltInfo_AccPayBalanceWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            wkRsltInfo_AccPayBalanceWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            #endregion

            return wkRsltInfo_AccPayBalanceWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
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
