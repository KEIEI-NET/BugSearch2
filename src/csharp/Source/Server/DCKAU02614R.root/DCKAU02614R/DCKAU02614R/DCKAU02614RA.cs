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
    /// 売掛残高元帳DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高元帳の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.09</br>
    /// <br></br>
    /// <br>Update Note: 2008.09.27 長内 PM.NS用に修正</br>
    /// <br>Update Note: 2013/10/24 gezh</br>
    /// <br>             Redmine#39753売掛残高元帳の消費税不正になる件の対応</br>
    /// </remarks>
    [Serializable]
    public class AccRecBalanceLedgerDB : RemoteDB, IAccRecBalanceLedgerDB
    {
        /// <summary>
        /// 売掛残高元帳DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        public AccRecBalanceLedgerDB()
            :
            base("DCKAU02616D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecBalanceWork", "CUSTACCRECRF")
        {
        }

        #region [SearchAccRecBalanceLedger]


        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        /// <summary>
        /// 指定された条件の売掛残高元帳を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛残高元帳を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        public int SearchAccRecBalanceLedger(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork = null;

            ArrayList extrInfo_AccRecBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_AccRecBalanceWorkList == null)
            {
                extrInfo_AccRecBalanceWork = paraObj as ExtrInfo_AccRecBalanceWork;
            }
            else
            {
                if (extrInfo_AccRecBalanceWorkList.Count > 0)
                    extrInfo_AccRecBalanceWork = extrInfo_AccRecBalanceWorkList[0] as ExtrInfo_AccRecBalanceWork;
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
                status = SearchAccRecBalanceLedgerProc(ref retList, extrInfo_AccRecBalanceWork, ref sqlConnection);
                 
                // ADD 2009.01.09 >>>
                //●未締分取得
                status = SearchDepsitSalesLedgerProc(ref retList, extrInfo_AccRecBalanceWork, ref sqlConnection);
                // ADD 2009.01.09 <<<
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchAccRecBalanceLedger");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                ////●暗号化キーCLOSE
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
        // ADD 2009.01.09 >>>
        /// <summary>
        /// 指定された条件の未締分の売掛残高元帳を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_AccRecBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の未締分の売掛残高元帳を戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.09</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753売掛残高元帳の消費税不正になる件の対応</br>
        private int SearchDepsitSalesLedgerProc(ref ArrayList retList, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList customerList = new ArrayList();
            RsltInfo_AccRecBalanceWork paraWork = new RsltInfo_AccRecBalanceWork();
            DateTime StAddUpYearMonth = DateTime.MinValue;

            try
            {
                //●得意先リスト作成
                status = SearchCustProc(ref customerList, extrInfo_AccRecBalanceWork, ref sqlConnection);

                //●最終締日算出(得意先売掛金額マスタ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = GetMonthlyAddUpHis(ref customerList, extrInfo_AccRecBalanceWork, ref sqlConnection);
                }
                
                //●集計対象期間の判定処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < customerList.Count; i++)
                    {
                        paraWork = customerList[i] as RsltInfo_AccRecBalanceWork;
                        DateTime addUpYearMonthBak = paraWork.AddUpYearMonth;  // 得意先最終締日クローン  // ADD 2013/10/24 gezh for Redmine#39753
                        if (paraWork.AddUpYearMonth < extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth)
                        {
                            StAddUpYearMonth = extrInfo_AccRecBalanceWork.St_AddUpYearMonth;
                            while (true)
                            {
                                //終了条件
                                if (StAddUpYearMonth > extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth)
                                {
                                    break;
                                }
                                // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>>
                                if (addUpYearMonthBak == StAddUpYearMonth.AddMonths(-1))
                                {
                                    paraWork.AddUpYearMonth = DateTime.MinValue;
                                }
                                else
                                {
                                    paraWork.AddUpYearMonth = addUpYearMonthBak;
                                }
                                // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
                                // 得意先最終締日 < 画面開始年月
                                if (paraWork.AddUpYearMonth < StAddUpYearMonth)
                                {
                                    // ●未締分集計処理
                                    MakeCustAccRecProc(ref retList, ref paraWork, extrInfo_AccRecBalanceWork, StAddUpYearMonth, ref sqlConnection);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchDepsitSalesLedgerProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }


        #region [MakeCustAccRecProc]
        /// <summary>
        /// 条件に該当する未締分の売掛残高元帳を抽出します。
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="extrInfo_AccRecBalanceWork">検索パラメータ</param>
        /// <param name="AddUpYearMonth">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 条件に該当する未締分の売掛残高元帳を抽出します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.09</br>
        private int MakeCustAccRecProc(ref ArrayList retList, ref RsltInfo_AccRecBalanceWork paraWork, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, DateTime AddUpYearMonth,  ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //■集計対象期間取得
            //自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccRecBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {                
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();
                CustAccRecWork custAccRecWork = new CustAccRecWork();

                #region 売掛金集計モジュール 呼出パラメータ設定
                custAccRecWork.EnterpriseCode = extrInfo_AccRecBalanceWork.EnterpriseCode;//企業コード    ※得意先リストから
                custAccRecWork.AddUpSecCode = paraWork.AddUpSecCode;    //請求拠点コード※得意先リストから
                custAccRecWork.CustomerCode = paraWork.ClaimCode;       //得意先コード  ※得意先リストから

                custAccRecWork.AddUpDate = EdMonthDate;          //計上年月日(終了)
                custAccRecWork.AddUpYearMonth = AddUpYearMonth;//計上年月
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // 更新履歴無 
                    custAccRecWork.StMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(開始)
                    custAccRecWork.LaMonCAddUpUpdDate = DateTime.MinValue; // 計上年月日(前回締日)
                }
                else
                {
                    // 更新履歴あり
                    custAccRecWork.StMonCAddUpUpdDate = StMonthDate; // 計上年月日(開始)
                    custAccRecWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// 計上年月日(前回締日)
                }

                object paraObj2 = (object)custAccRecWork;
                string retMsg = null;
                #endregion

                //売掛金集計モジュール呼出
                status = _monthlyAddUpDB.ReadCustAccRec(ref paraObj2, out retMsg,ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //取得結果キャスト
                    ArrayList custAccRecResult = new ArrayList();
                    custAccRecResult.Add((CustAccRecWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;
                    //取得結果セット
                    for (int j = 0; j < custAccRecResult.Count; j++)
                    {
                        RsltInfo_AccRecBalanceWork wkRsltInfo_AccRecBalanceWork = new RsltInfo_AccRecBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        #region 結果セット
                        wkRsltInfo_AccRecBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccRecBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccRecBalanceWork.ClaimCode = paraWork.ClaimCode;
                        wkRsltInfo_AccRecBalanceWork.ClaimName = paraWork.ClaimName;
                        wkRsltInfo_AccRecBalanceWork.ClaimName2 = paraWork.ClaimName2;
                        wkRsltInfo_AccRecBalanceWork.ClaimSnm = paraWork.ClaimSnm;
                        wkRsltInfo_AccRecBalanceWork.AddUpDate = ((CustAccRecWork)custAccRecResult[j]).AddUpDate;
                        wkRsltInfo_AccRecBalanceWork.AddUpYearMonth = ((CustAccRecWork)custAccRecResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccRecBalanceWork.LastTimeAccRec = ((CustAccRecWork)custAccRecResult[j]).LastTimeAccRec;
                        wkRsltInfo_AccRecBalanceWork.AcpOdrTtl2TmBfAccRec = ((CustAccRecWork)custAccRecResult[j]).AcpOdrTtl2TmBfAccRec;
                        wkRsltInfo_AccRecBalanceWork.AcpOdrTtl3TmBfAccRec = ((CustAccRecWork)custAccRecResult[j]).AcpOdrTtl3TmBfAccRec;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDmdNrml;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeFeeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeFeeDmdNrml;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeDisDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDisDmdNrml;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc = ((CustAccRecWork)custAccRecResult[j]).ThisTimeTtlBlcAcc;
                        wkRsltInfo_AccRecBalanceWork.OfsThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).OfsThisTimeSales;
                        wkRsltInfo_AccRecBalanceWork.OfsThisSalesTax = ((CustAccRecWork)custAccRecResult[j]).OfsThisSalesTax;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).ThisTimeSales;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesTax = ((CustAccRecWork)custAccRecResult[j]).ThisSalesTax;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPricRgds = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricRgds;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxRgds = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPrcTaxRgds;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPricDis = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricDis;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxDis = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPrcTaxDis;
                        wkRsltInfo_AccRecBalanceWork.TaxAdjust = ((CustAccRecWork)custAccRecResult[j]).TaxAdjust;
                        wkRsltInfo_AccRecBalanceWork.BalanceAdjust = ((CustAccRecWork)custAccRecResult[j]).BalanceAdjust;
                        wkRsltInfo_AccRecBalanceWork.AfCalTMonthAccRec = ((CustAccRecWork)custAccRecResult[j]).AfCalTMonthAccRec;
                        wkRsltInfo_AccRecBalanceWork.SalesSlipCount = ((CustAccRecWork)custAccRecResult[j]).SalesSlipCount;
                        wkRsltInfo_AccRecBalanceWork.CollectCond = paraWork.CollectCond;
                        wkRsltInfo_AccRecBalanceWork.TotalDay = paraWork.TotalDay;
                        wkRsltInfo_AccRecBalanceWork.CollectMoneyName = paraWork.CollectMoneyName;
                        wkRsltInfo_AccRecBalanceWork.CollectMoneyDay = paraWork.CollectMoneyDay;
                        wkRsltInfo_AccRecBalanceWork.BillCollecterCd = paraWork.BillCollecterCd;
                        wkRsltInfo_AccRecBalanceWork.BillCollecterNm = paraWork.BillCollecterNm;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((CustAccRecWork)custAccRecResult[j]).LaMonCAddUpUpdDate;

                        // 前回履歴が存在する場合、前月残高・繰越残高・当月末残高を計算
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccRecBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccRecBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccRecBalanceWork)retList[i]).ClaimCode == wkRsltInfo_AccRecBalanceWork.ClaimCode) &&
                                    (((RsltInfo_AccRecBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccRecBalanceWork.LastTimeAccRec = ((RsltInfo_AccRecBalanceWork)retList[i]).AfCalTMonthAccRec; // 前月残高
                                    // 今回繰越残高(売掛) = 前回請求残高 - 今回入金金額 
                                    wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc = (wkRsltInfo_AccRecBalanceWork.LastTimeAccRec) - wkRsltInfo_AccRecBalanceWork.ThisTimeDmdNrml;// 今回繰越残高(売掛)
                                    // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                                    wkRsltInfo_AccRecBalanceWork.AfCalTMonthAccRec = wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc + (wkRsltInfo_AccRecBalanceWork.OfsThisTimeSales + wkRsltInfo_AccRecBalanceWork.OfsThisSalesTax);// 計算後請求金額
                                }
                            }
                        }

                        retList.Add(wkRsltInfo_AccRecBalanceWork);

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
                base.WriteErrorLog(ex, "BillBalanceTableDB.MakeCustAccRecProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion  //[MakeCustAccRecProc]

        #region [GetMonthlyAddUpHis]
        /// <summary>
        /// 得意先売掛金額マスタから条件に該当する最終締日を抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="extrInfo_AccRecBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の最終締日を戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753売掛残高元帳の消費税不正になる件の対応</br>
        private int GetMonthlyAddUpHis(ref ArrayList al, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            RsltInfo_AccRecBalanceWork paraWork = new RsltInfo_AccRecBalanceWork();
            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < al.Count; i++)
                {
                    paraWork = al[i] as RsltInfo_AccRecBalanceWork;
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;


                    // 対象テーブル
                    // CUSTACCRECRF 得意先売掛金額マスタ
                    #region [Select文作成]
                    sqlText = string.Empty; 
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "   ADDUPYEARMONTHRF " + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF " + Environment.NewLine;
                    sqlText += " FROM CUSTACCRECRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += " WHERE " + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND CLAIMCODERF=@FINDCUSTOMERCODE " + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=0 " + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine;
                    sqlText += "  AND ADDUPDATERF= " + Environment.NewLine;
                    sqlText += "  ( " + Environment.NewLine;
                    sqlText += "   SELECT MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += "   FROM  CUSTACCRECRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "   WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "     AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "     AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "     AND CUSTOMERCODERF=0" + Environment.NewLine;
                    sqlText += "  ) " + Environment.NewLine;
                    #endregion  //[Select文作成]

                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccRecBalanceWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.ClaimCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode.Trim());

                    myReader = sqlCommand.ExecuteReader();

                    ((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;

                    while (myReader.Read())
                    {
                        //[抽出結果-値セット]
                        ((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM", SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")));
                        // ------ DEL 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>>
                        //if (((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth == extrInfo_AccRecBalanceWork.St_AddUpYearMonth.AddMonths(-1))
                        //{
                        //    //画面開始年月= 前回履歴-１ヶ月の場合、売掛金額集計モジュールにて前回情報を取得させる
                        //    // ※((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonthがDateTime.MinValueの場合、売掛金額集計モジュールにて前回情報を取得する
                        //    ((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;
                        //}
                        // ------ DEL 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustProc Exception=" + ex.Message);
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

        #region [SearchCustProc]
        /// <summary>
        /// 得意先マスタから条件に該当する得意先リストを抽出します。
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="extrInfo_AccRecBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先リストを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustProc(ref ArrayList al, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // CUSTOMERRF        CSTMER 得意先マスタ
                // SECINFOSETRF      SCINST 拠点情報設定マスタ

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SCINST.SECTIONGUIDESNMRF," + Environment.NewLine;
                selectTxt += " CSTMER.CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMCODERF," + Environment.NewLine;
                selectTxt += " CSTMER.NAMERF," + Environment.NewLine;
                selectTxt += " CSTMER.NAME2RF," + Environment.NewLine;
                selectTxt += " CSTMER.CUSTOMERSNMRF, " + Environment.NewLine;
                selectTxt += " CSTMER.TOTALDAYRF," + Environment.NewLine;
                selectTxt += " CSTMER.COLLECTCONDRF," + Environment.NewLine;
                selectTxt += " CSTMER.COLLECTMONEYNAMERF," + Environment.NewLine;
                selectTxt += " CSTMER.COLLECTMONEYDAYRF," + Environment.NewLine;
                selectTxt += " CSTMER.BILLCOLLECTERCDRF," + Environment.NewLine;
                selectTxt += " EMP.SHORTNAMERF AS BILLCOLLECTERNMRF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " CUSTOMERRF AS CSTMER" + Environment.NewLine;

                #region [JOIN]
                //拠点情報設定マスタ
                selectTxt += "LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=CSTMER.CLAIMSECTIONCODERF" + Environment.NewLine;
                //従業員マスタ
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += " ON  CSTMER.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CSTMER.BILLCOLLECTERCDRF=EMP.EMPLOYEECODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE句]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " CSTMER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccRecBalanceWork.EnterpriseCode);

                //論理削除区分
                selectTxt += " AND CSTMER.LOGICALDELETECODERF=0" + Environment.NewLine;

                // 親得意先コードのみ対象
                selectTxt += " AND CSTMER.CUSTOMERCODERF = CSTMER.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMSECTIONCODERF !=0 " + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMSECTIONCODERF IS NOT NULL " + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMCODERF !=0" + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMCODERF IS NOT NULL " + Environment.NewLine;

                //拠点コード
                if (extrInfo_AccRecBalanceWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in extrInfo_AccRecBalanceWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND CSTMER.CLAIMSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //得意先コード
                if (extrInfo_AccRecBalanceWork.St_ClaimCode != 0)
                {
                    selectTxt += " AND CSTMER.CLAIMCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                    SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCOD", SqlDbType.Int);
                    paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.St_ClaimCode);
                }
                if (extrInfo_AccRecBalanceWork.Ed_ClaimCode != 99999999 && extrInfo_AccRecBalanceWork.Ed_ClaimCode != 0)
                {
                    selectTxt += " AND CSTMER.CLAIMCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                    SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCOD", SqlDbType.Int);
                    paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.Ed_ClaimCode);
                }
                #endregion  //[WHERE句]

                #region [ORDER BY]
                selectTxt += "ORDER BY " + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMCODERF" + Environment.NewLine;
                #endregion

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RsltInfo_AccRecBalanceWork ResultWork = new RsltInfo_AccRecBalanceWork();

                    #region [抽出結果-値セット]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                    ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    ResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    ResultWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    ResultWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                    ResultWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                    ResultWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                    ResultWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                    ResultWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                    ResultWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                    ResultWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustProc Exception=" + ex.Message);
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
        #endregion  //[SearchCustProc]

        // ADD 2009.01.09 <<<

        /// <summary>
        /// 指定された条件の売掛残高元帳を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_AccRecBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売掛残高元帳を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        private int SearchAccRecBalanceLedgerProc(ref ArrayList retList, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
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
                selectTxt += "   CUSACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMNAMERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESTAXRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRCTAXDISRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,CUST.COLLECTCONDRF" + Environment.NewLine;
                selectTxt += "  ,CUST.TOTALDAYRF" + Environment.NewLine;
                selectTxt += "  ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                selectTxt += "  ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                selectTxt += "  ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                selectTxt += "  ,EMP.SHORTNAMERF AS BILLCOLLECTERNMRF" + Environment.NewLine;
                selectTxt += "FROM CUSTACCRECRF AS CUSACC" + Environment.NewLine;
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSACC.ENTERPRISECODERF=CUST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSACC.CLAIMCODERF=CUST.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSACC.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSACC.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSACC.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.BILLCOLLECTERCDRF=EMP.EMPLOYEECODERF" + Environment.NewLine;

                #endregion

                //Where句作成
                selectTxt += MakeWhereString(ref sqlCommand, extrInfo_AccRecBalanceWork);

                //計上拠点コード＋請求先コード＋計上年月順に並び替える
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "  CUSACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += ", CUSACC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += ", CUSACC.ADDUPYEARMONTHRF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;    
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_AccRecBalanceFromReader(ref myReader));

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

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_AccRecBalanceWork">検索条件格納クラス</param>
        /// <returns>売掛残高元帳抽出のSQL文字列</returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork)
        {
            //基本WHERE句の作成
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //●固定条件
            //企業コード
            retString.Append("CUSACC.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccRecBalanceWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND CUSACC.LOGICALDELETECODERF=0 ");

            //親レコードのみを対象とする(得意先コード=0のみ対象)
            retString.Append("AND CUSACC.CUSTOMERCODERF=0 ");

            //●これよりパラメータの値により動的変化の項目
            //計上拠点コード
            if (extrInfo_AccRecBalanceWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_AccRecBalanceWork.SectionCodes)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND CUSACC.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //請求先コード
            if (extrInfo_AccRecBalanceWork.St_ClaimCode > 0)
            {
                retString.Append("AND CUSACC.CLAIMCODERF>=@ST_CLAIMCODE ");
                SqlParameter paraSt_ClaimCode = sqlCommand.Parameters.Add("@ST_CLAIMCODE", SqlDbType.Int);
                paraSt_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.St_ClaimCode);
            }
            if (extrInfo_AccRecBalanceWork.Ed_ClaimCode > 0)
            {
                retString.Append("AND CUSACC.CLAIMCODERF<=@ED_CLAIMCODE ");
                SqlParameter paraEd_ClaimCode = sqlCommand.Parameters.Add("@ED_CLAIMCODE", SqlDbType.Int);
                paraEd_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.Ed_ClaimCode);
            }

            //対象年月
            if (extrInfo_AccRecBalanceWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND CUSACC.ADDUPYEARMONTHRF>=@ST_ADDUPYEARMONTH ");
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ST_ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccRecBalanceWork.St_AddUpYearMonth);
            }
            if (extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND CUSACC.ADDUPYEARMONTHRF<=@ED_ADDUPYEARMONTH ");
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_ADDUPYEARMONTH", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth);
            }


            return retString.ToString();
        }
        #endregion

        #region [売掛残高元帳抽出結果クラス格納処理]
        /// <summary>
        /// 売掛残高元帳抽出結果クラス格納処理 Reader → RsltInfo_AccRecBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_AccRecBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        private RsltInfo_AccRecBalanceWork CopyToRsltInfo_AccRecBalanceFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_AccRecBalanceWork wkRsltInfo_AccRecBalanceWork = new RsltInfo_AccRecBalanceWork();

            #region クラスへ格納
            wkRsltInfo_AccRecBalanceWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_AccRecBalanceWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_AccRecBalanceWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_AccRecBalanceWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_AccRecBalanceWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_AccRecBalanceWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_AccRecBalanceWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_AccRecBalanceWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_AccRecBalanceWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.AcpOdrTtl2TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.AcpOdrTtl3TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            wkRsltInfo_AccRecBalanceWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkRsltInfo_AccRecBalanceWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkRsltInfo_AccRecBalanceWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkRsltInfo_AccRecBalanceWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkRsltInfo_AccRecBalanceWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkRsltInfo_AccRecBalanceWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkRsltInfo_AccRecBalanceWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            wkRsltInfo_AccRecBalanceWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            wkRsltInfo_AccRecBalanceWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            wkRsltInfo_AccRecBalanceWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            wkRsltInfo_AccRecBalanceWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            #endregion

            return wkRsltInfo_AccRecBalanceWork;
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
