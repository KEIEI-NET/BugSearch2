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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上年間実績DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上年間実績の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: 2009/04/30 22008 長内</br>
    /// <br>             入金データ論理削除対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/05/26 23012 畠中 啓次朗</br>
    /// <br>             不具合修正 (MANTIS ID:13331 )</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/07 22008 長内 数馬</br>
    /// <br>             不具合修正 (MANTIS ID:14011 )</br>
    /// <br>Update Note: 2010/08/02 徐後継</br>
    /// <br>               テキスト出力対応</br>
    /// <br>Update Note: 2010/08/25 chenyd</br>
    /// <br>            ・障害ID:13278 テキスト出力対応</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: FSI菅原　要</br>
    /// <br>Date       : 2012/09/24</br>
    /// <br>             集計区分＝得意先の場合の粗利表示不正対応</br>
    /// <br>Update Note: 2012/10/11 YANGMJ</br>
    /// <br>             REDMINE#32818 値引きの集計方法対応</br>
    /// <br>Update Note: 2015/09/08 許雪峰</br>
    /// <br>             Redmine#47027 「残高照会」タブに請求列の伝票枚数不正の対応</br>
    /// </remarks>
    [Serializable]
    public class SalesAnnualDataSelectResultDB : RemoteDB, ISalesAnnualDataSelectResultDB
    {
        /// <summary>
        /// 売上年間実績DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesAnnualDataSelectResultDB()
            :
            base("DCHNB04196D", "Broadleaf.Application.Remoting.ParamData.SalesAnnualDataSelectResultWork", "SALESANNUALDATASELECTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;
        /// <summary>売掛/買掛金額マスタ更新リモートオブジェクト</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;


        #region [Search]
        /// <summary>
        /// 指定された条件の売上年間実績データを戻します（出力用）
        /// </summary>
        /// <param name="retListObj">検索結果</param>
        /// <param name="paraList">検索パラメータリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上年間実績データを戻します（出力用）</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/08/02</br>
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            ・障害ID:13278 テキスト出力対応</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        //public int SearchAll(out object retListObj, object paraList) // DEL 2010/08/30
        public int SearchAll(out object retListObj, object paramWork)  // ADD 2010/08/30
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            retListObj = null;
            object retObj = null;

            ArrayList resultWorkList = new ArrayList();
            //ArrayList paraCndtnWorkList = paraList as ArrayList;
            ArrayList salesAnnualDataSelectResultWorkList = new ArrayList();
            try
            {
                SalesAnnualDataSelectParamWork _paramWork = paramWork as SalesAnnualDataSelectParamWork;
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _paramWork.EnterpriseCode, "売上年間実績照会", "抽出開始");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                // --- DEL 2010/08/25 -------------------------------->>>>>
                //foreach (SalesAnnualDataSelectParamWork paramWork in paraCndtnWorkList)
                //{
                //    status = SearchSalesAnnualData(out retObj, paramWork, ref sqlConnection); 
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        salesAnnualDataSelectResultWorkList = (ArrayList)retObj;
                //        foreach (SalesAnnualDataSelectResultWork resultWork in salesAnnualDataSelectResultWorkList)
                //        {
                //            resultWork.SectionCode = paramWork.SectionCode;
                //            resultWork.SectionName = paramWork.SectionName;
                //            resultWork.SelectionCode = paramWork.SelectionCode;
                //            resultWork.SelectionName = paramWork.SelectionName;
                //        }
                //        resultWorkList.Add(salesAnnualDataSelectResultWorkList);
                //    }
                //}
                // --- DEL 2010/08/25 --------------------------------<<<<<

                // --- ADD 2010/08/25 -------------------------------->>>>>
                List<string[]> sectionCodeList = _paramWork.SectionCodeList;
                string st_selectionCode = _paramWork.St_SelectionCode;
                string ed_selectionCode = _paramWork.Ed_SelectionCode;
                int employeeDivCd = _paramWork.EmployeeDivCd;
                foreach (string[] sectionCode in sectionCodeList)
                {
                    _paramWork.SectionCode = sectionCode[0];
                    _paramWork.St_SelectionCode = st_selectionCode;
                    _paramWork.Ed_SelectionCode = ed_selectionCode;
                    _paramWork.EmployeeDivCd = employeeDivCd;
                    status = SearchSalesAnnualData(out retObj, paramWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesAnnualDataSelectResultWorkList = (ArrayList)retObj;
                        foreach (SalesAnnualDataSelectResultWork resultWork in salesAnnualDataSelectResultWorkList)
                        {
                            resultWork.SectionCode = sectionCode[0];
                            resultWork.SectionName = sectionCode[1];
                        }
                        resultWorkList.Add(salesAnnualDataSelectResultWorkList);
                    }
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                if (resultWorkList.Count >= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                retListObj = (object)resultWorkList;
                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _paramWork.EnterpriseCode, "売上年間実績照会", "抽出終了");
                // --- ADD 2011/03/22-----------------------------------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesAnnualDataSelectResultDB.Search");
                resultWorkList = new ArrayList();
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

        /// <summary>
        /// 指定された条件の売上年間実績データを戻します
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上年間実績データを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(out object salesAnnualDataSelectResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesAnnualDataSelectResultWork = null;
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB(); // ADD 2011/03/22
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalesAnnualDataSelectParamWork)paramWork).EnterpriseCode, "売上年間実績照会", "抽出開始");// ADD 2011/03/22
                return SearchSalesAnnualData(out salesAnnualDataSelectResultWork, paramWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesAnnualDataSelectResultDB.Search");
                salesAnnualDataSelectResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalesAnnualDataSelectParamWork)paramWork).EnterpriseCode, "売上年間実績照会", "抽出終了"); // ADD 2011/03/22
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の売上年間実績データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">検索結果</param>
        /// <param name="objSalesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上年間実績データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchSalesAnnualData(out object objSalesAnnualDataSelectResultWork, object objSalesAnnualDataSelectParamWork, ref SqlConnection sqlConnection)
        {
            SalesAnnualDataSelectParamWork paramWork = null;

            ArrayList paramWorkList = objSalesAnnualDataSelectParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesAnnualDataSelectParamWork as SalesAnnualDataSelectParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesAnnualDataSelectParamWork;
            }

            ArrayList salesReportWorkList = null;

            switch (paramWork.TotalDiv)
            {
                // 修正 2008/09/22 >>>
                #region 修正前
                /*
                case (int)TotalDivs.Section:                //拠点別
                case (int)TotalDivs.SalesEmp:               //担当者別
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
                case (int)TotalDivs.Customer:               //得意先別
                case (int)TotalDivs.Area:                   //地区別
                case (int)TotalDivs.BizType:                //業種別
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                default:
                    break;
                */
                #endregion
                case (int)TotalDivs.Section:                //拠点別
                case (int)TotalDivs.SalesEmp:               //担当者別
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;   

                case (int)TotalDivs.Customer:               //得意先別
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;

                case (int)TotalDivs.Area:                   //地区別
                case (int)TotalDivs.BizType :               //業種別
                    mTtlSaSlip = new MTtlSaSlipAreaBizType();
                    break;
                default:
                    break;
                // 修正 2008/09/22 <<<
            }
            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 売上年間実績データを取込む
            status = SearchSalesHistoryDataProc(out salesReportWorkList, paramWork, ref sqlConnection);
            objSalesAnnualDataSelectResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// 指定された条件の売上年間実績データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">検索結果</param>
        /// <param name="salesAnnualDataSelectParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上年間実績データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                
                sqlCommand = new SqlCommand("", sqlConnection);

                //目標金額取得
                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, paramWork,0);

                //タイムアウト時間を設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToResultWorkFromReader(ref myReader, paramWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2008/09/22 >>>
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                switch (paramWork.TotalDiv)
                {

                    case (int)TotalDivs.Section: // 拠点別
                        // 売上履歴データ読込
                        status = SearchSalesHistDtl(ref al, paramWork, ref sqlConnection);
                        break;

                    case (int)TotalDivs.Customer: //得意先別
                        if (paramWork.SearchDiv == 0)
                        {
                            status = SearchSalesHistDtl(ref al, paramWork, ref sqlConnection);
                        }
                        break;
                    default:
                        break;
                }
                // ADD 2008/09/22 <<<

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

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc

        // ADD 2008/09/22 >>>>
        #region [CustSearch 得意先残高照会用Search処理]
        // ADD 2008/09/22 >>>
        /// <summary>
        /// 指定された条件の残高照会データを戻します
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の残高照会データを戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        public int CustSearch(out object custsalesAnnualDataSelectResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custsalesAnnualDataSelectResultWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                status =SearchCustSalesData(out custsalesAnnualDataSelectResultWork, paramWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchCustSalesData.CustSearch");
                custsalesAnnualDataSelectResultWork = new ArrayList();
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

        #region [SearchCustSalesData 得意先残高照会用Search処理]
        // ADD 2008/09/22 >>>
        /// <summary>
        /// 指定された条件の残高照会データを戻します
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の残高照会データを戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustSalesData(out object objCustsalesHistoryWorkList, object objSalesAnnualDataSelectParamWork, ref SqlConnection sqlConnection)
        {
            SalesAnnualDataSelectParamWork paramWork = null;

            ArrayList paramWorkList = objSalesAnnualDataSelectParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesAnnualDataSelectParamWork as SalesAnnualDataSelectParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesAnnualDataSelectParamWork;
            }

            ArrayList salesReportWorkList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 残高照会データを取込む
            status = SearchCustSalesDataProc(out salesReportWorkList, paramWork, ref sqlConnection);
            objCustsalesHistoryWorkList = salesReportWorkList;

            return status;
        }
        #endregion

        #region [SearchCustSalesDataProc 得意先残高照会用Search処理]
        // ADD 2008/09/22 >>>
        /// <summary>
        /// 指定された条件の残高照会データを戻します
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の残高照会データを戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// 
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustSalesDataProc(out ArrayList CustsalesHistoryWorkList, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {                
                if (paramWork.SearchDiv == 1)　// 0:年度実績,1:残高(請求・入金),2:残高(当月当期売上)
                {
                    #region 残高(請求・入金)取得処理
                    status = SearchCustSalesDataProc(ref al, paramWork, ref sqlConnection, 1);// 請求・入金データ取得
                    status = SearchCustSalesDataProc(ref al, paramWork, ref sqlConnection, 2);// 売掛データ取得
                    status = SearchCustSalesDataProc(ref al, paramWork, ref sqlConnection, 3);// 当月入金データ取得
                                       
                    //売掛金・買掛金集計モジュール呼出
                    this._monthlyAddUpDB = new MonthlyAddUpDB();

                    CustAccRecWork custAccRecWork = new CustAccRecWork();
                    custAccRecWork.EnterpriseCode = paramWork.EnterpriseCode;                         //企業コード
                    custAccRecWork.AddUpSecCode = paramWork.ClaimSectionCode;                         //得意先請求拠点
                    custAccRecWork.AddUpDate = TDateTime.LongDateToDateTime(paramWork.SecTotalDay);   //計上年月日
                    custAccRecWork.CustomerCode = paramWork.CustomerCode;                             //得意先コード   
                    object paraObj2 = (object)custAccRecWork;
                    string retMsg = null;
                    //売掛金・買掛金集計モジュール呼出
                    status = _monthlyAddUpDB.ReadCustAccRec(ref paraObj2, out retMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {                                            
                        //取得成功
                        //取得結果キャスト
                        ArrayList custAccRecResult = new ArrayList();
                        custAccRecResult.Add((CustAccRecWork)paraObj2);
                        #region [抽出結果-値セット]
                        //消費税
                        ((CustSalesAnnualDataSelectResultWork)al[0]).ThisMOfsThisSalesTax = ((CustAccRecWork)custAccRecResult[0]).OfsThisSalesTax;
                        //手数料
                        ((CustSalesAnnualDataSelectResultWork)al[0]).ThisMThisTimeFeeDmdNrml = ((CustAccRecWork)custAccRecResult[0]).ThisTimeFeeDmdNrml;
                        //値引
                        ((CustSalesAnnualDataSelectResultWork)al[0]).ThisMThisTimeDisDmdNrml = ((CustAccRecWork)custAccRecResult[0]).ThisTimeDisDmdNrml;
                        #endregion
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        //NOT_FOUND,EOFの場合は次へ
                    }
                    else
                    {
                        //取得失敗
                        throw new Exception("売掛金・買掛金集計モジュールからの取得に失敗。");
                    }
                    #endregion
                }
                if (paramWork.SearchDiv == 2)　// 0:年度実績,1:残高(請求・入金),2:残高(当月当期売上)
                {
                    status = SearchSalesHistDtlProc(ref al, paramWork, ref sqlConnection);
                   

                    //Del 2008.12.18 sakurai>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //
                    //#region 残高(当月当期売上)取得処理
                    //
                    //CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                    //status = SearchSalesHistDtlProc(ref al, paraCompanyInfWork, TDateTime.DateTimeToLongDate(paramWork.AddUpYearMonth), 0, 0, paramWork, ref sqlConnection, 1);
                    //
                    //#endregion
                    //
                    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    
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
            CustsalesHistoryWorkList = al;

            return status;
        }
        #endregion

        #region [SearchCustDepoTotalProc]
        /// <summary>
        /// 指定された条件の請求データ入金データを戻します
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の請求データ入金データを戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustSalesDataProc(ref ArrayList WorkList, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection, int SubSlip)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                IMTtlSaSlip mTtlSaSlipCust = new MTtlSaSlipCust();
                String sText = "";
                sqlCommand = new SqlCommand(sText, sqlConnection);

                if (SubSlip == 1) // 請求・入金データ取得
                {
                    #region [SELECT文]
                    sText += "SELECT" + Environment.NewLine;
                    sText += " CUSTDMD.LASTTIMEDEMANDRF AS LASTTIMEDEMANDRF," + Environment.NewLine;
                    sText += " CUSTDMD.THISTIMEFEEDMDNRMLRF AS THISTIMEFEEDMDNRMLRF," + Environment.NewLine;
                    sText += " CUSTDMD.THISTIMEDISDMDNRMLRF AS THISTIMEDISDMDNRMLRF," + Environment.NewLine;
                    sText += " CUSTDMD.OFSTHISSALESTAXRF AS OFSTHISSALESTAXRF," + Environment.NewLine;
                    sText += " CUSTDMD.ACPODRTTL2TMBFBLDMDRF AS ACPODRTTL2TMBFBLDMDRF," + Environment.NewLine;
                    sText += " CUSTDMD.ACPODRTTL3TMBFBLDMDRF AS ACPODRTTL3TMBFBLDMDRF," + Environment.NewLine;
                    sText += " CUSTDMD.SALESSLIPCOUNTRF AS SALESSLIPCOUNTRF," + Environment.NewLine;
                    sText += " CUSTDMD.ADDUPYEARMONTHRF  AS ADDUPYEARMONTHRF," + Environment.NewLine;
                    sText += " CUSTDMD.ADDUPDATERF AS ADDDAY," + Environment.NewLine;
                    sText += " DMDEPO.CASHDEPOSIT AS CASHDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.TRFRDEPOSIT As TRFRDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.CHECKDEPOSIT AS CHECKDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.DRAFTDEPOSIT AS DRAFTDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.OFFSETDEPOSIT AS OFFSETDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.FUNDTRANSFERDEPOSIT AS FUNDTRANSFERDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.EMONEYRDEPOSIT AS EMONEYRDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.OTHERDEPOSIT AS OTHERDEPOSIT" + Environment.NewLine;
                    sText += " FROM" + Environment.NewLine;
                    sText += " (" + Environment.NewLine;
                    sText += "  SELECT" + Environment.NewLine;
                    sText += "   ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                    sText += "   ADDUPSECCODERF AS ADDUPSECCODERF," + Environment.NewLine;
                    sText += "   CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                    sText += "   ADDUPDATERF AS ADDUPDATERF," + Environment.NewLine;
                    sText += "   ADDUPYEARMONTHRF  AS ADDUPYEARMONTHRF," + Environment.NewLine;
                    sText += "   LASTTIMEDEMANDRF AS LASTTIMEDEMANDRF," + Environment.NewLine;
                    sText += "   SALESSLIPCOUNTRF AS SALESSLIPCOUNTRF," + Environment.NewLine;
                    sText += "   THISTIMEFEEDMDNRMLRF AS THISTIMEFEEDMDNRMLRF," + Environment.NewLine;
                    sText += "   THISTIMEDISDMDNRMLRF AS THISTIMEDISDMDNRMLRF, " + Environment.NewLine;
                    sText += "   OFSTHISSALESTAXRF AS OFSTHISSALESTAXRF," + Environment.NewLine;
                    sText += "   ACPODRTTL2TMBFBLDMDRF AS ACPODRTTL2TMBFBLDMDRF," + Environment.NewLine;
                    sText += "   ACPODRTTL3TMBFBLDMDRF AS ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                    sText += "  FROM " + Environment.NewLine;
                    sText += "   CUSTDMDPRCRF AS CUSTDMDPRC" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "CUSTDMDPRC", SlipTargetDiv.TargetDay, SubSlip);
                    sText += "   AND CUSTDMDPRC.CUSTOMERCODERF=0" + Environment.NewLine;
                    sText += " ) AS CUSTDMD" + Environment.NewLine;
                    sText += " LEFT JOIN" + Environment.NewLine;
                    sText += " (" + Environment.NewLine;
                    sText += "   SELECT" + Environment.NewLine;
                    sText += "    DEPDTL.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                    sText += "    DEPDTL.ADDUPSECCODERF AS ADDUPSECCODERF," + Environment.NewLine;
                    sText += "    DEPDTL.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                    sText += "    DEPDTL.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                    sText += "    DEPDTL.ADDUPDATERF AS ADDUPDATERF," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=60 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS EMONEYRDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=58 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OTHERDEPOSIT" + Environment.NewLine;
                    sText += "   FROM DMDDEPOTOTALRF AS DEPDTL" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "DEPDTL", SlipTargetDiv.TargetDay, SubSlip);
                    sText += "   GROUP BY" + Environment.NewLine;
                    sText += "    ENTERPRISECODERF," + Environment.NewLine;
                    sText += "    ADDUPSECCODERF," + Environment.NewLine;
                    sText += "    CLAIMCODERF," + Environment.NewLine;
                    sText += "    CUSTOMERCODERF," + Environment.NewLine;
                    sText += "    ADDUPDATERF" + Environment.NewLine;
                    sText += "   ) AS DMDEPO" + Environment.NewLine;
                    sText += " ON" + Environment.NewLine;
                    sText += " CUSTDMD.ENTERPRISECODERF = DMDEPO.ENTERPRISECODERF" + Environment.NewLine;
                    sText += " AND CUSTDMD.ADDUPSECCODERF = DMDEPO.ADDUPSECCODERF" + Environment.NewLine;
                    sText += " AND CUSTDMD.CLAIMCODERF = DMDEPO.CLAIMCODERF" + Environment.NewLine;
                    sText += " AND CUSTDMD.ADDUPDATERF = DMDEPO.ADDUPDATERF" + Environment.NewLine;
                    #endregion

                }
                if (SubSlip == 2) // 売掛データ取得
                {
                    #region [SELECT文]
                    sText = "SELECT" + Environment.NewLine;
                    sText +=  "ADDUPDATERF AS ADDUPDATERF," + Environment.NewLine;
                    sText +=  "AFCALTMONTHACCRECRF AS LASTTIMEACCRECRF" + Environment.NewLine;
                    sText +=  "FROM" + Environment.NewLine;
                    sText +=  "CUSTACCRECRF" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.TargetDay, SubSlip);
                    sText +=  " AND CUSTOMERCODERF =0" + Environment.NewLine;
                    #endregion
                }
                if (SubSlip == 3) // 当月入金データ取得
                {
                    #region [SELECT文]
                    sText = "SELECT" + Environment.NewLine;
                    sText += "DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=60 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS EMONEYRDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=58 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OTHERDEPOSIT" + Environment.NewLine;
                    sText += " FROM DEPSITMAINRF AS DEPMIN" + Environment.NewLine;
                    sText += " INNER JOIN DEPSITDTLRF DEPDTL" + Environment.NewLine;
                    sText += " ON  DEPDTL.ENTERPRISECODERF=DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                    sText += " AND DEPDTL.ACPTANODRSTATUSRF=DEPMIN.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sText += " AND DEPDTL.DEPOSITSLIPNORF=DEPMIN.DEPOSITSLIPNORF" + Environment.NewLine;
                    sText += " AND DEPDTL.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "DEPMIN", SlipTargetDiv.TargetDay, SubSlip);
                    sText += " GROUP BY" + Environment.NewLine;
                    sText += "   DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                    #endregion
                }
                sqlCommand.CommandText = sText;

                //タイムアウト時間を設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (SubSlip == 1) // 請求・入金データ取得
                    {
                        #region 結果セット
                        CustSalesAnnualDataSelectResultWork CustSalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                        CustSalesDataResultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                        CustSalesDataResultWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));            //前回請求金額
                        CustSalesDataResultWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));  //受注2回前残高（請求計）
                        CustSalesDataResultWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));  //受注3回前残高（請求計）
                        CustSalesDataResultWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));            //売上伝票枚数
                        CustSalesDataResultWork.CasheDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));                   //請求入金情報(現金)
                        CustSalesDataResultWork.TrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));                    //請求入金情報(振込)
                        CustSalesDataResultWork.CheckKDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));                 //請求入金情報(小切手)
                        CustSalesDataResultWork.DraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));                  //請求入金情報(手形)
                        CustSalesDataResultWork.OffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));                //請求入金情報(相殺)
                        CustSalesDataResultWork.FundtransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));    //請求入金情報(口座振替)
                        CustSalesDataResultWork.EmoneyDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYRDEPOSIT"));               //請求入金情報(E-Money)
                        CustSalesDataResultWork.OtherDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERDEPOSIT"));                  //請求入金情報(その他)
                        CustSalesDataResultWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));      //請求入金情報(手数料)
                        CustSalesDataResultWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));      //請求入金情報(値引)
                        CustSalesDataResultWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));            //請求消費税
                        #endregion
                        WorkList.Add(CustSalesDataResultWork);
                    }
                    if (SubSlip == 2) // 売掛データ取得
                    {
                        #region 結果セット
                        if (WorkList.Count == 0)
                        {
                            CustSalesAnnualDataSelectResultWork CustSalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                            CustSalesDataResultWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF")); //前回売掛金額
                            WorkList.Add(CustSalesDataResultWork);
                        }
                        else
                        {
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF")); //前回売掛金額

                        }
                        #endregion
                    }
                    if (SubSlip == 3) // 当月入金データ取得
                    {
                        #region 結果セット
                        if (WorkList.Count == 0)
                        {
                            CustSalesAnnualDataSelectResultWork CustSalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                            CustSalesDataResultWork.ThisMCasheDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                            CustSalesDataResultWork.ThisMhTrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                            CustSalesDataResultWork.ThisMCheckKDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                            CustSalesDataResultWork.ThisMDraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                            CustSalesDataResultWork.ThisMOffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                            CustSalesDataResultWork.ThisMFundtransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));                                                                                                                                    
                            CustSalesDataResultWork.ThisMEmoneyDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYRDEPOSIT"));
                            CustSalesDataResultWork.ThisMOtherDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERDEPOSIT"));
                            WorkList.Add(CustSalesDataResultWork);
                        }
                        else
                        {
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMCasheDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMhTrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMCheckKDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMDraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMOffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMFundtransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMEmoneyDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYRDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMOtherDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERDEPOSIT"));
                        }
                        #endregion
                    }

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
        // ADD 2008/09/22 <<<

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
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

        // ADD 2008/09/22 >>>
        #region [売上履歴検索処理 SearchSalesHistDtl]
        /// <summary>
        /// 売上履歴データ 検索処理
        /// </summary>
        /// <param name="salesHistoryWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <returns>売上履歴データ 検索処理</returns>
        /// <br>Note       : 売上履歴データを検索し、伝票枚数を戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSalesHistDtl(ref ArrayList al, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SalesAnnualDataSelectResultWork SalesDataResultWork = null;
            int TermSalesSlipCount = 0;
            int AUPYearMonth;
            long SalesTargetM;
            long SalesTargetP;

            // 自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            paraCompanyInfWork.EnterpriseCode = paramWork.EnterpriseCode;
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            CompanyInfWork companyInfWork = (CompanyInfWork)arrayList[0];

            ArrayList ResultAl = new ArrayList();
            //ResultAl = null;

            for (int i = 0; i < al.Count; i++)
            {
                SalesDataResultWork = (SalesAnnualDataSelectResultWork)al[i];
                AUPYearMonth = SalesDataResultWork.AUPYearMonth;
                SalesTargetM = SalesDataResultWork.SalesTargetMoney;
                SalesTargetP = SalesDataResultWork.SalesTargetProfit;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == 1 && paramWork.SearDiv == 1)
                {
                    paramWork.St_SelectionCode = SalesDataResultWork.SelectionCode;
                    paramWork.Ed_SelectionCode = SalesDataResultWork.SelectionCode;

                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                if (paramWork.TotalDiv == 0) // 0:拠点
                {
                    //期間伝票枚数取得: TermSalesSlipCount
                    status = SearchSalesHistDtlProc(companyInfWork, AUPYearMonth, ref TermSalesSlipCount, paramWork, ref sqlConnection);
                    ((SalesAnnualDataSelectResultWork)al[i]).TermSalesSlipCount = TermSalesSlipCount;
                }
                if (paramWork.TotalDiv == 1) // 1:得意先
                {
                    status = SearchSalesHistDtlProc(ref ResultAl, companyInfWork, AUPYearMonth, SalesTargetM, SalesTargetP, paramWork, ref sqlConnection,0,ref al);
                    if (ResultAl.Count != 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;    
                }
            }
            if (paramWork.TotalDiv == 1) // 1:得意先
            {
                al = null;
                al = ResultAl;
            }
            return status;

        }

        #endregion

        #region [売上履歴検索処理 SearchSalesHistDtlProc]
        /// <summary>
        /// 売上履歴データ 検索処理
        /// </summary>
        /// <param name="salesHistoryWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <returns>売上履歴データ 検索処理</returns>
        /// <br>Note       : 売上履歴データを検索し、伝票枚数を戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSalesHistDtlProc(CompanyInfWork companyInfWork, int AUPYearMonth, ref int TermSalesSlipCount, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DateTime StADDUPADATE = DateTime.MinValue;
            DateTime EdADDUPADATE = DateTime.MinValue;
            try
            {               
                FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                finYearTableGenerator.GetDaysFromMonth(TDateTime.LongDateToDateTime("YYYYMM",AUPYearMonth), out StADDUPADATE, out EdADDUPADATE);

                string sText = "";
                sText = " SELECT COUNT(*) SALESDT_COUNT" + Environment.NewLine;
                sText += " FROM SALESHISTORYRF SALESDT" + Environment.NewLine;
                sText += " WHERE " + Environment.NewLine;
                sText += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------->>>
                //sText += " AND ADDUPADATERF>@STADDUPADATE" + Environment.NewLine;
                //sText += " AND ADDUPADATERF<=@EDADDUPADATE" + Environment.NewLine;
                //if (paramWork.SectionCode != "00")
                //{
                //    sText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                //}

                sText += " AND ACPTANODRSTATUSRF=30" + Environment.NewLine;
                sText += " AND SALESDATERF>=" + SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE)).ToString() + Environment.NewLine;
                sText += " AND SALESDATERF<=" + SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE)).ToString() + Environment.NewLine;
                if (paramWork.SectionCode != "00")
                {
                    //sText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sText += " AND RESULTSADDUPSECCDRF=@SECTIONCODE" + Environment.NewLine;
                }
                // -- UPD 2010/05/10 --------------------------<<<

                if (paramWork.CustomerCode != 0)
                {
                    sText += " AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sText, sqlConnection);

                //Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                // -- DEL 2010/05/10 ------------------------------>>>
                //SqlParameter findParaSTADDUPADATE = sqlCommand.Parameters.Add("@STADDUPADATE", SqlDbType.Int);
                //SqlParameter findParaEDADDUPADATE = sqlCommand.Parameters.Add("@EDADDUPADATE", SqlDbType.Int);
                // -- DEL 2010/05/10 ------------------------------<<<
                SqlParameter findParaLogicalDaleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);                
                
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                // -- DEL 2010/05/10 ------------------------------>>>
                //findParaSTADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE));
                //findParaEDADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE));
                // -- DEL 2010/05/10 ------------------------------<<<
                findParaLogicalDaleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                if (paramWork.SectionCode != "00")
                {
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                }
                if (paramWork.CustomerCode != 0)
                {
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
                }

                //タイムアウト時間を設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDT_COUNT"));
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

        #region [売上履歴検索処理 SearchSalesHistDtlProc]
        /// <summary>
        /// 売上履歴データ 検索処理
        /// </summary>
        /// <param name="salesHistoryWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <returns>売上履歴データ 検索処理</returns>
        /// <br>Note       : 売上履歴データを検索し、伝票枚数を戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSalesHistDtlProc(ref ArrayList ResultAl,SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DateTime StADDUPADATE = DateTime.MinValue;
            DateTime EdADDUPADATE = DateTime.MinValue;

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        // 修正 2009.01.23 >>>
                        //int stYear = paramWork.CustTotalDay / 10000;
                        //int dummyMonth = paramWork.CustTotalDay % 10000;
                        //int stMonth = dummyMonth / 100;
                        //int stDay = dummyMonth % 100;
                        //int stAddDay = stYear * 10000 + (stMonth - 1) * 100 + stDay + 1;
                        //StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.CustTotalDay);
                        //StADDUPADATE = StADDUPADATE.AddMonths(-1);
                        // 修正 2009.01.23 <<<

                        // -- UPD 2009/09/07 ---------------------->>>
                        //StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);
                        //EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.CustTotalDay);
                        StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.StAddUpDate);
                        EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);
                        // -- UPD 2009/09/07 ----------------------<<<
                    }
                    else if (i == 1)
                    {
                        // -- UPD 2009/09/07 ---------------------->>>
                        //StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.StAddUpDate);
                        //EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);

                        StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdSecAddUpDate);
                        EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.SecTotalDay);
                        // -- UPD 2009/09/07 ----------------------<<<
                    }

                    String sText = "";

                    IMTtlSaSlip mTtlSaSlipCust = new MTtlSaSlipCust();
                    sqlCommand = new SqlCommand("", sqlConnection);

                    sText += "SELECT" + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 0 AND DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS PSALES," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 1 AND DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS PRETURN," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 2 AND DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS PDOWN," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF - DT.COSTRF ELSE 0 END) AS PGROSS," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 0 AND DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS ESALES," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 1 AND DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS ERETURN," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 2 AND DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS EDOWN," + Environment.NewLine;
                    //sText += "SUM(CASE WHEN DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF - DT.COSTRF ELSE 0 END) AS EGROSS" + Environment.NewLine; // DEL 2009/09/07

                    sText += "SUM(CASE WHEN DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF - DT.COSTRF ELSE 0 END) AS EGROSS," + Environment.NewLine; // DEL 2009/09/07 最後尾に,を追加
                    sText += "SUM(CASE WHEN (HI.SALESSLIPCDRF IN (0,1) AND DT.SALESROWNORF=1) THEN 1 ELSE 0 END) AS SALESSLIPCNT" + Environment.NewLine; // ADD 2009/09/07
                    
                    sText += "FROM SALESHISTDTLRF DT" + Environment.NewLine;
                    sText += "LEFT JOIN SALESHISTORYRF HI" + Environment.NewLine;
                    sText += "ON  HI.ENTERPRISECODERF = DT.ENTERPRISECODERF" + Environment.NewLine;
                    // -- UPD 2009/09/07 ---------------------------------------->>>
                    //sText += "AND HI.SECTIONCODERF = DT.SECTIONCODERF" + Environment.NewLine; 
                    sText += "AND HI.ACPTANODRSTATUSRF = DT.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sText += "AND HI.SALESSLIPNUMRF = DT.SALESSLIPNUMRF" + Environment.NewLine;
                    sText += "AND HI.LOGICALDELETECODERF=@HILOGICALDELETECODE" + Environment.NewLine;// ADD BY 許雪峰 2015/09/08  For Redmine #47027 
                    // -- UPD 2009/09/07 ----------------------------------------<<<
                    sText += "WHERE" + Environment.NewLine;
                    sText += "DT.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    sText += "AND DT.SECTIONCODERF =@SECTIONCODE" + Environment.NewLine;
                    sText += "AND HI.CUSTOMERCODERF =@CUSTOMERCODE" + Environment.NewLine;
                    sText += "AND (DT.SALESSLIPCDDTLRF != 3 AND DT.SALESSLIPCDDTLRF !=4 AND DT.SALESSLIPCDDTLRF != 5)" + Environment.NewLine;
                    sText += "AND DT.LOGICALDELETECODERF=@DTLOGICALDELETECODE" + Environment.NewLine;//ADD BY 許雪峰 2015/09/08  For Redmine #47027
                    
                    if (i == 0)
                    {
                        // -- UPD 2009/09/07 ---------------------------------->>>
                        //sText += "AND HI.ADDUPADATERF > @STADDUPADATE" + Environment.NewLine;
                        sText += "AND HI.ADDUPADATERF >= @STADDUPADATE" + Environment.NewLine;
                        // -- UPD 2009/09/07 ----------------------------------<<<
                    }
                    else
                    {
                        // -- UPD 2009/09/07 ---------------------------------->>>
                        //sText += "AND HI.ADDUPADATERF >= @STADDUPADATE" + Environment.NewLine;
                        sText += "AND HI.ADDUPADATERF > @STADDUPADATE" + Environment.NewLine;
                        // -- UPD 2009/09/07 ----------------------------------<<<
                    }

                    sText += "AND HI.ADDUPADATERF <= @EDADDUPADATE" + Environment.NewLine;

                    sqlCommand.CommandText = sText;

                    //Parameterオブジェクトの作成
                    SqlParameter findParaSTADDUPADATE = sqlCommand.Parameters.Add("@STADDUPADATE", SqlDbType.Int);
                    SqlParameter findParaEDADDUPADATE = sqlCommand.Parameters.Add("@EDADDUPADATE", SqlDbType.Int);
                    SqlParameter findParaEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE",SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCUSTOMERCODERF = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // --- ADD BY 許雪峰 2015/09/08  For Redmine #47027 ---->>>>>
                    SqlParameter findParaDtLogicalDaleteCode = sqlCommand.Parameters.Add("@DTLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaHiLogicalDaleteCode = sqlCommand.Parameters.Add("@HILOGICALDELETECODE", SqlDbType.Int);
                    // --- ADD BY 許雪峰 2015/09/08  For Redmine #47027 ----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaSTADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE));
                    findParaEDADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE));
                    findParaEnterPriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    findParaCUSTOMERCODERF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);

                    // --- ADD BY 許雪峰 2015/09/08  For Redmine #47027 ---->>>>>
                    findParaDtLogicalDaleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    findParaHiLogicalDaleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    // --- ADD BY 許雪峰 2015/09/08  For Redmine #47027 ----<<<<<

                    //タイムアウト時間を設定（秒）
                    sqlCommand.CommandTimeout = 3600;

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        CustSalesAnnualDataSelectResultWork SalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                        #region 結果セット
                        SalesDataResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PSALES"));
                        SalesDataResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRETURN"));
                        SalesDataResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PDOWN"));
                        SalesDataResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PGROSS"));
                        SalesDataResultWork.ExSalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ESALES"));
                        SalesDataResultWork.ExSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ERETURN"));
                        SalesDataResultWork.ExDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EDOWN"));
                        SalesDataResultWork.ExGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EGROSS"));
                        SalesDataResultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCNT"));
                        SalesDataResultWork.claimDiv = i+1;
                        #endregion

                        ResultAl.Add(SalesDataResultWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
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




        #region [売上履歴検索処理 SearchSalesHistDtlProc]
        /// <summary>
        /// 売上履歴データ 検索処理
        /// </summary>
        /// <param name="salesHistoryWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <returns>売上履歴データ 検索処理</returns>
        /// <br>Note       : 売上履歴データを検索し、伝票枚数を戻します</br>
        /// <br>Programmer : 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            ・障害ID:13278 テキスト出力対応</br>
        /// <br>           : 2012/09/24 FSI菅原　要</br>
        /// <br>            　粗利表示不正対応</br>
        /// <br>Update Note: 2012/10/11 YANGMJ</br>
        /// <br>             REDMINE#32818 値引きの集計方法対応</br>
        private int SearchSalesHistDtlProc(ref ArrayList ResultAl, CompanyInfWork companyInfWork, int AUPYearMonth, long SalesTargetM, long SalesTargetP, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection, int subTotalDiv, ref ArrayList al)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DateTime StADDUPADATE = DateTime.MinValue;
            DateTime EdADDUPADATE = DateTime.MinValue;
            string key = string.Empty;
            try
            {
                if (subTotalDiv == 0)
                {
                    FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                    finYearTableGenerator.GetDaysFromMonth(TDateTime.LongDateToDateTime("YYYYMM", AUPYearMonth), out StADDUPADATE, out EdADDUPADATE);
                }
                else
                {
                    StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.StAddUpDate);
                    EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);
                }

                String sText = "";

                IMTtlSaSlip mTtlSaSlipCust = new MTtlSaSlipCust();
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select Del 2008/12/19 sakurai
                //Del 2008/12/19 sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //sText = " SELECT" + Environment.NewLine;
                //sText += " TOTAL.ENTERPRISECODERF," + Environment.NewLine;
                //sText += " TOTAL.CUSTOMERCODERF," + Environment.NewLine;
                //sText += " TOTAL.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF , " + Environment.NewLine;
                //sText += " TOTAL.SALESORDERDIVCDRF AS SALESORDERDIVCDRF," + Environment.NewLine;
                //sText += " TOTAL.GOODSKINDCODERF AS GOODSKINDCODERF," + Environment.NewLine;
                //sText += " TOTAL.SUM_SALESMONEYTAXEXCRF AS SALESMONEYTAXEXCRF," + Environment.NewLine;
                //sText += " TOTAL.SUM_COSTRF AS COSTRF," + Environment.NewLine;
                //sText += " COUNTDT.SALESDT_COUNT AS TERMSALESSLIPCOUNTRF" + Environment.NewLine;
                //sText += " FROM" + Environment.NewLine;
                //sText += " (" + Environment.NewLine;
                //sText += " SELECT" + Environment.NewLine;
                //sText += "  SALES.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                //sText += "  SALES.SECTIONCODERF AS SECTIONCODERF," + Environment.NewLine;
                //sText += "  SALES.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                //sText += " SALES.GOODSKINDCODERF AS GOODSKINDCODERF," + Environment.NewLine;
                //sText += " SALES.SALESORDERDIVCDRF AS SALESORDERDIVCDRF," + Environment.NewLine;
                //sText += " SALES.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF, " + Environment.NewLine;
                //sText += " SUM(SALESMONEYTAXEXCRF) AS SUM_SALESMONEYTAXEXCRF," + Environment.NewLine;
                //sText += " SUM(COSTRF) AS SUM_COSTRF " + Environment.NewLine;
                //sText += "FROM" + Environment.NewLine;
                //sText += "(" + Environment.NewLine;
                //sText += "SELECT" + Environment.NewLine;
                //sText += "SALESHIS.SALESSLIPNUMRF AS SALESHIS_SALESSLIPNUMRF," + Environment.NewLine;
                //sText += "SALESDT.SALESSLIPNUMRF AS SALESDT_SALESSLIPNUMRF," + Environment.NewLine;
                //sText += "SALESDT.SALESROWNORF AS SALESROWNORF," + Environment.NewLine;
                //sText += "SALESHIS.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                //sText += "SALESHIS.SECTIONCODERF AS  SECTIONCODERF," + Environment.NewLine;
                //sText += "SALESHIS.ADDUPADATERF AS ADDUPADATERF," + Environment.NewLine;
                //sText += "SALESHIS.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                //sText += "SALESDT.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF," + Environment.NewLine;
                //sText += "SALESDT.GOODSKINDCODERF AS GOODSKINDCODERF," + Environment.NewLine;
                //sText += "SALESDT.SALESORDERDIVCDRF AS SALESORDERDIVCDRF," + Environment.NewLine;
                //sText += "SALESDT.SALESMONEYTAXEXCRF AS SALESMONEYTAXEXCRF," + Environment.NewLine;
                //sText += "SALESDT.COSTRF AS COSTRF " + Environment.NewLine;
                //sText += "FROM SALESHISTORYRF AS SALESHIS" + Environment.NewLine;
                //sText += "LEFT JOIN" + Environment.NewLine;
                //sText += "SALESHISTDTLRF AS SALESDT" + Environment.NewLine;
                //sText += "ON " + Environment.NewLine;
                //sText += "SALESHIS.SALESSLIPNUMRF = SALESDT.SALESSLIPNUMRF" + Environment.NewLine;
                //sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "SALESHIS", SlipTargetDiv.SalesHist, 99);
                //sText += " AND SALESHIS.ADDUPADATERF>=@STADDUPADATE" + Environment.NewLine;
                //sText += " AND SALESHIS.ADDUPADATERF<=@EDADDUPADATE " + Environment.NewLine;
                //sText += ") AS SALES" + Environment.NewLine;
                //sText += "GROUP BY" + Environment.NewLine;
                //sText += " SALES.ENTERPRISECODERF," + Environment.NewLine;
                //sText += " SALES.SECTIONCODERF," + Environment.NewLine;
                //sText += " SALES.CUSTOMERCODERF," + Environment.NewLine;
                //sText += " SALES.GOODSKINDCODERF," + Environment.NewLine;
                //sText += " SALES.SALESSLIPCDDTLRF, " + Environment.NewLine;
                //sText += " SALES.SALESORDERDIVCDRF " + Environment.NewLine;
                //sText += " ) AS TOTAL" + Environment.NewLine;
                //sText += " Left Join" + Environment.NewLine;
                //sText += " (" + Environment.NewLine;
                //sText += " SELECT " + Environment.NewLine;
                //sText += " COUNT(*) AS SALESDT_COUNT," + Environment.NewLine;
                //sText += " ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                //sText += " SECTIONCODERF AS SECTIONCODERF" + Environment.NewLine;
                //sText += " FROM " + Environment.NewLine;
                //sText += " SALESHISTORYRF as SALESDTCOUNT" + Environment.NewLine;
                //sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "SALESDTCOUNT", SlipTargetDiv.SalesHist, 99);
                //sText += " AND SALESDTCOUNT.ADDUPADATERF>=@STADDUPADATE" + Environment.NewLine;
                //sText += " AND SALESDTCOUNT.ADDUPADATERF<=@EDADDUPADATE " + Environment.NewLine;
                //sText += " GROUP BY" + Environment.NewLine;
                //sText += " ENTERPRISECODERF," + Environment.NewLine;
                //sText += " SECTIONCODERF" + Environment.NewLine;
                //sText += " ) COUNTDT" + Environment.NewLine;
                //sText += " ON " + Environment.NewLine;
                //sText += " TOTAL.ENTERPRISECODERF = COUNTDT.ENTERPRISECODERF AND" + Environment.NewLine;
                //sText += " TOTAL.SECTIONCODERF = COUNTDT.SECTIONCODERF" + Environment.NewLine;
                //Del 2008/12/19 sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion

                #region Select Add 2008/12/19 sakurai
                // --- ADD 2010/10/09 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " SELECT A.*, CUST.CUSTOMERSNMRF AS CUSTOMERNAMERF FROM (" + Environment.NewLine;
                }
                // --- ADD 2010/10/09 --------------------------------<<<<<
                sText += " SELECT" + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " SA.ENTERPRISECODERF," + Environment.NewLine; // ADD 2010/10/09
                    sText += " SA.CUSTOMERCODERF," + Environment.NewLine;
                    //sText += " SA.CUSTOMERNAMERF," + Environment.NewLine; // DEL 2010/10/09
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                //sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 0 THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_SALES," + Environment.NewLine;//DEL YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 0 OR (SALESSLIPCDDTLRF = 2 AND GOODSNORF IS NULL) THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_SALES," + Environment.NewLine;//ADD YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 1 THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_RETSA," + Environment.NewLine;
                //sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 2 THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_DISCO," + Environment.NewLine;//DEL YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 2 AND GOODSNORF IS NOT NULL THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_DISCO," + Environment.NewLine;//ADD YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(HI.SALESMONEYTAXEXCRF) AS P_GROSS," + Environment.NewLine;
                sText += "  SUM(HI.COSTRF) AS COST," + Environment.NewLine;
                sText += "  SUM(CASE WHEN (SA.SALESSLIPCDRF IN (0,1) AND HI.SALESROWNORF=1) THEN 1 ELSE 0 END) AS SALESSLIPCNT," + Environment.NewLine; // ADD 2009/09/07
                sText += "  HI.GOODSKINDCODERF," + Environment.NewLine;
                sText += "  HI.SALESORDERDIVCDRF" + Environment.NewLine;
                sText += "  FROM SALESHISTDTLRF AS HI" + Environment.NewLine;
                sText += " LEFT JOIN SALESHISTORYRF AS SA" + Environment.NewLine;
                sText += "  ON  SA.ENTERPRISECODERF = HI.ENTERPRISECODERF" + Environment.NewLine;
                // -- UPD 2010/05/10 ------------------------------------->>>
                //sText += "  AND SA.SECTIONCODERF = HI.SECTIONCODERF" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------<<<
                sText += "  AND SA.ACPTANODRSTATUSRF = HI.ACPTANODRSTATUSRF" + Environment.NewLine;
                sText += "  AND SA.SALESSLIPNUMRF = HI.SALESSLIPNUMRF" + Environment.NewLine;
                //sText += " LEFT JOIN MTTLSALESSLIPRF AS MT" + Environment.NewLine;
                //sText += "  ON MT.ENTERPRISECODERF = HI.ENTERPRISECODERF" + Environment.NewLine;
                //sText += "  AND MT.ADDUPSECCODERF = HI.SECTIONCODERF" + Environment.NewLine;
                //sText += "  AND MT.CUSTOMERCODERF = SA.CUSTOMERCODERF" + Environment.NewLine;
                sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "SA", SlipTargetDiv.SalesHist, 99);
                sText += "  AND SA.ADDUPADATERF >= @STADDUPADATE" + Environment.NewLine;
                sText += "  AND SA.ADDUPADATERF <= @EDADDUPADATE" + Environment.NewLine;
                sText += "  AND SA.LOGICALDELETECODERF = 0" + Environment.NewLine; // ADD 2009/05/26
                sText += "  AND (HI.GOODSKINDCODERF =0 OR HI.GOODSKINDCODERF =1)" + Environment.NewLine;
                //sText += "  AND MT.EMPLOYEEDIVCDRF =10" + Environment.NewLine;
                sText += " GROUP BY " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " SA.ENTERPRISECODERF," + Environment.NewLine; // ADD 2010/10/09
                    sText += "  SA.CUSTOMERCODERF," + Environment.NewLine;
                    //sText += "  SA.CUSTOMERNAMERF," + Environment.NewLine; // DEL 2010/10/09
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                sText += "  HI.GOODSKINDCODERF," + Environment.NewLine;
                sText += "  HI.SALESORDERDIVCDRF" + Environment.NewLine;
                // --- ADD 2010/10/09 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " ) AS A" + Environment.NewLine;
                    sText += " LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                    sText += "  ON  A.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                    sText += "  AND A.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                    sText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                }
                // --- ADD 2010/10/09 --------------------------------<<<<<
                #endregion

                sqlCommand.CommandText = sText;

                //Parameterオブジェクトの作成
                SqlParameter findParaSTADDUPADATE = sqlCommand.Parameters.Add("@STADDUPADATE", SqlDbType.Int);
                SqlParameter findParaEDADDUPADATE = sqlCommand.Parameters.Add("@EDADDUPADATE", SqlDbType.Int);
                //Parameterオブジェクトへ値設定
                findParaSTADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE));
                findParaEDADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE));

                //タイムアウト時間を設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                #region
                while (myReader.Read())
                {
                    if (subTotalDiv == 0)
                    {
                        SalesAnnualDataSelectResultWork SalesDataResultWork = new SalesAnnualDataSelectResultWork();
                        #region 結果セット
                        SalesDataResultWork.AUPYearMonth = AUPYearMonth;                                                            // 計上年月                             
                        SalesDataResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_SALES"));        　      // 売上金額
                        SalesDataResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_RETSA"));        // 返品金額
                        SalesDataResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_DISCO"));             // 値引金額
                        //SalesDataResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_GROSS"));               // 粗利金額 // DEL 2009/09/07
                        SalesDataResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF")); // 在取区分
                        SalesDataResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));     // 商品属性
                        SalesDataResultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COST"));                         // 原価
                        SalesDataResultWork.SalesTargetMoney = SalesTargetM;                                                      　        　 // 売上目標
                        SalesDataResultWork.SalesTargetProfit = SalesTargetP;                                                                  // 粗利目標                                

                        // ---------- DEL 2012/09/24 ---------->>>>>
                        //SalesDataResultWork.GrossProfit = SalesDataResultWork.SalesMoney + SalesDataResultWork.SalesRetGoodsPrice - SalesDataResultWork.Cost;               // 粗利金額  // ADD 2009/09/07
                        // ---------- DEL 2012/09/24 ----------<<<<<
                        // ---------- ADD 2012/09/24 ---------->>>>>
                        SalesDataResultWork.GrossProfit = SalesDataResultWork.SalesMoney + SalesDataResultWork.SalesRetGoodsPrice - SalesDataResultWork.Cost + SalesDataResultWork.DiscountPrice;   // 粗利金額
                        // ---------- ADD 2012/09/24 ----------<<<<<
                        SalesDataResultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCNT")); // 月毎伝票枚数（当期の集計で使用） ADD 2009/09/07
                        // --- ADD 2010/08/25 -------------------------------->>>>>
                        if (paramWork.SearDiv == 1)
                        {
                            SalesDataResultWork.SelectionCode = Convert.ToString(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")));
                            SalesDataResultWork.SelectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        }
                        // --- ADD 2010/08/25 --------------------------------<<<<<
                        #endregion

                        ResultAl.Add(SalesDataResultWork);
                    }
                    else
                    {
                        CustSalesAnnualDataSelectResultWork SalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                        #region 結果セット
                        SalesDataResultWork.AUPYearMonth = AUPYearMonth;                                                              // 計上年月                             
                        SalesDataResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_SALES"));        　// 売上金額
                        SalesDataResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_RETSA"));        // 返品金額
                        SalesDataResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_DISCO"));             // 値引金額
                        //SalesDataResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_GROSS"));               // 粗利金額 // DEL 2009/09/07
                        SalesDataResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF")); // 在取区分
                        SalesDataResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));     // 商品属性
                        SalesDataResultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COST"));                         // 原価
                        SalesDataResultWork.SalesTargetMoney = SalesTargetM;                                                      　        　 // 売上目標
                        SalesDataResultWork.SalesTargetProfit = SalesTargetP;                                                                  // 粗利目標                                                                 
                        
                        SalesDataResultWork.GrossProfit = SalesDataResultWork.SalesMoneyTaxExc + SalesDataResultWork.SalesRetGoodsPrice - SalesDataResultWork.Cost;               // 粗利金額  // ADD 2009/09/07
                        SalesDataResultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCNT")); // 月毎伝票枚数（当期の集計で使用） ADD 2009/09/07
                        #endregion

                        ResultAl.Add(SalesDataResultWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion

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
        // ADD 2008/09/22 <<<

    }

}
