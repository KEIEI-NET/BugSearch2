using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先別取引分布表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 得意先別取引分布表で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.21</br>
    /// <br>Update Note  : 2011/11/09 凌小青</br>
    /// <br>             : Redmine#26432の対応</br> 
    /// <br>             : </br>
    /// </remarks>
    public class CustSalesDistributionReportAcs
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 得意先別取引分布表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先別取引分布表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
		/// </remarks>
		public CustSalesDistributionReportAcs()
		{
            this._iCustSalesDistributionReportResultDB = (ICustSalesDistributionReportResultDB)MediationCustSalesDistributionReportResultDB.GetCustSalesDistributionReportResultDB();
		}

		/// <summary>
        /// 得意先別取引分布表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先別取引分布表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
		/// </remarks>
        static CustSalesDistributionReportAcs()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // 拠点Dictionary

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // 追加
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
		#endregion

        #region ■ Static変数
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion

        #region private定数
        // 帳票印字する売上日付記号
        private const string CT_SalesDateStr = "*";
        #endregion

        #region ■ Private変数
        ICustSalesDistributionReportResultDB _iCustSalesDistributionReportResultDB;

        private DataTable _custSalesDistributionReportDt; // リモート抽出結果保持DataTable
        private DataTable _printDt;                       // 帳票印字データ保持DataTable
        private DataView  _custSalesDistributionReportDv; // 印刷DataView

        private HolidaySettingAcs _holidaySettingAcs; // 休業日設定アクセスクラス(営業日数取得用)
        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView CustSalesDistributionDataView
        {
            get { return this._custSalesDistributionReportDv; }
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        public int SearchMain(CustSalesDistributionReportParam custSalesDistributionReportParam, out string errMsg)
        {
            return this.SearchProc(custSalesDistributionReportParam, out errMsg);
        }

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ■ Privateメソッド

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private int SearchProc(CustSalesDistributionReportParam custSalesDistributionReportParam, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02185EA.CreateDataTable(ref this._custSalesDistributionReportDt);

                CustSalesDistributionReportParamWork custSalesDistributionReportParamWork = new CustSalesDistributionReportParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(custSalesDistributionReportParam, out custSalesDistributionReportParamWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iCustSalesDistributionReportResultDB.Search(out retWorkList, custSalesDistributionReportParamWork);

                // テスト用
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(custSalesDistributionReportParam, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "得意先別取引分布表データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="salesRsltListCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       　: 画面抽出条件をリモート抽出条件へ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private int DevListCndtn(CustSalesDistributionReportParam custSalesDistributionReportParam, out CustSalesDistributionReportParamWork custSalesDistributionReportParamWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            custSalesDistributionReportParamWork = new CustSalesDistributionReportParamWork();

            try
            {
                custSalesDistributionReportParamWork.EnterpriseCode = custSalesDistributionReportParam.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (custSalesDistributionReportParam.SectionCode.Length != 0)
                {
                    if (custSalesDistributionReportParam.IsSelectAllSection)
                    {
                        // 全社の時
                        custSalesDistributionReportParamWork.SectionCode = null;
                    }
                    else
                    {
                        custSalesDistributionReportParamWork.SectionCode = custSalesDistributionReportParam.SectionCode;
                    }
                }
                else
                {
                    custSalesDistributionReportParamWork.SectionCode = null;
                }

                custSalesDistributionReportParamWork.StSalesDate = custSalesDistributionReportParam.StSalesDate; // 開始対象日付
                custSalesDistributionReportParamWork.EdSalesDate = custSalesDistributionReportParam.EdSalesDate; // 終了対象日付

                custSalesDistributionReportParamWork.StSalesEmployeeCd = custSalesDistributionReportParam.StSalesEmployeeCd; // 開始担当者コード
                custSalesDistributionReportParamWork.EdSalesEmployeeCd = custSalesDistributionReportParam.EdSalesEmployeeCd; // 終了担当者コード

                custSalesDistributionReportParamWork.StSalesAreaCode = custSalesDistributionReportParam.StSalesAreaCode; // 開始地区コード
                if (custSalesDistributionReportParam.EdSalesAreaCode == 0) custSalesDistributionReportParamWork.EdSalesAreaCode = 9999;
                else custSalesDistributionReportParamWork.EdSalesAreaCode = custSalesDistributionReportParam.EdSalesAreaCode; // 終了地区コード

                custSalesDistributionReportParamWork.StCustomerCode = custSalesDistributionReportParam.StCustomerCode; // 開始得意先コード
                if (custSalesDistributionReportParam.EdCustomerCode == 0) custSalesDistributionReportParamWork.EdCustomerCode = 99999999;
                else custSalesDistributionReportParamWork.EdCustomerCode = custSalesDistributionReportParam.EdCustomerCode; // 終了得意先コード

                custSalesDistributionReportParamWork.SearchDiv = custSalesDistributionReportParam.SearchDiv; // 実績印刷区分
                custSalesDistributionReportParamWork.PrintDiv = (int)custSalesDistributionReportParam.PrintType; // 発行タイプ
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       　: リモート抽出結果を帳票印字用DataTableへ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void DevListData(CustSalesDistributionReportParam custSalesDistributionReportParam, ArrayList resultWork)
        {
            // リモート抽出結果をDataTableに展開
            DataRow dr;

            foreach (CustSalesDistributionReportResultWork custSalesDistributionReportResultWork in resultWork)
            {
                dr = this._custSalesDistributionReportDt.NewRow();

                dr[PMHNB02185EA.ct_Col_EnterpriseCode] = custSalesDistributionReportResultWork.EnterpriseCode; // 企業コード
                dr[PMHNB02185EA.ct_Col_SecCode] = custSalesDistributionReportResultWork.SecCode; // 拠点コード
                dr[PMHNB02185EA.ct_Col_SectionGuideSnm] = custSalesDistributionReportResultWork.SectionGuideSnm; // 拠点ガイド名称

                dr[PMHNB02185EA.ct_Col_CustomerCode] = custSalesDistributionReportResultWork.CustomerCode; // 得意先コード
                dr[PMHNB02185EA.ct_Col_CustomerSnm] = custSalesDistributionReportResultWork.CustomerSnm; // 得意先略称
                dr[PMHNB02185EA.ct_Col_SalesEmployeeCd] = custSalesDistributionReportResultWork.SalesEmployeeCd; // 担当者コード
                dr[PMHNB02185EA.ct_Col_SalesEmployeeNm] = custSalesDistributionReportResultWork.SalesEmployeeNm; // 担当者名称
                dr[PMHNB02185EA.ct_Col_SalesAreaCode] = custSalesDistributionReportResultWork.SalesAreaCode; // 販売エリアコード
                dr[PMHNB02185EA.ct_Col_SalesAreaName] = custSalesDistributionReportResultWork.SalesAreaName; // 販売エリア名称

                dr[PMHNB02185EA.ct_Col_SalesCount] = custSalesDistributionReportResultWork.SalesCount; // 伝票枚数
                dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc] = custSalesDistributionReportResultWork.SalesTotalTaxExc; //純売上
                dr[PMHNB02185EA.ct_Col_TotalCost] = custSalesDistributionReportResultWork.TotalCost; // 原価金額計
                dr[PMHNB02185EA.ct_Col_SalesDate] = custSalesDistributionReportResultWork.SalesDate; // 売上日付
                

                this._custSalesDistributionReportDt.Rows.Add(dr);
            }

            // 帳票印字用テーブルに詰替え
            this.MakePrintTable(custSalesDistributionReportParam);

            // 順位設定
            this.SetOrder(custSalesDistributionReportParam);

            // DataView作成
            // 順位によりフィルタ、発行タイプによりソート
            this._custSalesDistributionReportDv = new DataView(this._printDt, this.GetFilterStrForPrintDv(custSalesDistributionReportParam), this.GetSortStrForPrintDv(custSalesDistributionReportParam), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 帳票印字テーブル作成用ソート文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       　: ソート文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void GetSortStrForPrintDt(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            string sortString = string.Empty;
            // 拠点と発行タイプのコード毎にソート
            if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                sortString = PMHNB02185EA.ct_Col_SecCode + ", " + PMHNB02185EA.ct_Col_CustomerCode;
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                sortString = PMHNB02185EA.ct_Col_SecCode + ", " + PMHNB02185EA.ct_Col_SalesEmployeeCd;
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Area)
            {
                sortString = PMHNB02185EA.ct_Col_SecCode + ", " + PMHNB02185EA.ct_Col_SalesAreaCode;
            }

            DataTable workTable = this._custSalesDistributionReportDt.Copy();
            this._custSalesDistributionReportDt.Clear();

            DataRow[] workRowList = workTable.Select("", sortString);

            foreach (DataRow workDr in workRowList)
            {
                this._custSalesDistributionReportDt.ImportRow(workDr);
            }
        }

        /// <summary>
        /// 帳票印字テーブルを作成する
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       　: 帳票印字テーブルを作成する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void MakePrintTable(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            // テーブル作成
            PMHNB02185EB.CreateDataTable(ref this._printDt);

            // キー順にソート
            this.GetSortStrForPrintDt(custSalesDistributionReportParam);

            // 同キー値を保持
            string sectionKey = string.Empty;
            string codeKey = string.Empty;

            // キー値となるカラム名
            string codeColumnName;

            if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                codeColumnName = PMHNB02185EB.ct_Col_CustomerCode;
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                codeColumnName = PMHNB02185EB.ct_Col_SalesEmployeeCd;
            }
            else
            {
                codeColumnName = PMHNB02185EB.ct_Col_SalesAreaCode;
            }


            // リモート検索結果1行ずつ処理
            foreach (DataRow dr in this._custSalesDistributionReportDt.Rows)
            {
                if (sectionKey == dr[PMHNB02185EA.ct_Col_SecCode].ToString()
                    && codeKey == dr[codeColumnName].ToString())
                {
                    // 同キー値(帳票同行データ)
                    DataRow existRow = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    existRow[PMHNB02185EB.ct_Col_SalesCount] = (Int32)existRow[PMHNB02185EB.ct_Col_SalesCount]
                                                             + (Int32)dr[PMHNB02185EA.ct_Col_SalesCount]; // 伝票枚数
                    existRow[PMHNB02185EB.ct_Col_SalesTotalTaxExc] = (Int64)existRow[PMHNB02185EB.ct_Col_SalesTotalTaxExc]
                                                                   + (Int64)dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]; // 純売上
                    existRow[PMHNB02185EB.ct_Col_GrossProfit] = (Int64)existRow[PMHNB02185EB.ct_Col_GrossProfit]
                                                                   + (Int64)dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]
                                                                   - (Int64)dr[PMHNB02185EA.ct_Col_TotalCost]; // 粗利(純売上 - 原価金額計)

                    int salesDate = ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Year * 10000 
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Month * 100
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Day;

                    if (salesDate >= custSalesDistributionReportParam.StSalesDate
                        && salesDate <= custSalesDistributionReportParam.EdSalesDate)
                    {
                        // 売上日付が画面入力の範囲内であれば"*"を設定
                        this.SetSalesDate(ref existRow, (DateTime)dr[PMHNB02185EA.ct_Col_SalesDate], custSalesDistributionReportParam.StartDate); // 売上日付
                    }
                }
                else
                {
                    // 別キー値(帳票別行データ)
                    DataRow newRow = this._printDt.NewRow();

                    newRow[PMHNB02185EB.ct_Col_SecCode] = dr[PMHNB02185EA.ct_Col_SecCode]; // 拠点コード
                    newRow[PMHNB02185EB.ct_Col_SectionGuideSnm] = dr[PMHNB02185EA.ct_Col_SectionGuideSnm];// 拠点ガイド略称
                    newRow[PMHNB02185EB.ct_Col_CustomerCode] = dr[PMHNB02185EA.ct_Col_CustomerCode];// 得意先コード
                    newRow[PMHNB02185EB.ct_Col_CustomerSnm] = dr[PMHNB02185EA.ct_Col_CustomerSnm];// 得意先略称
                    newRow[PMHNB02185EB.ct_Col_SalesEmployeeCd] = dr[PMHNB02185EA.ct_Col_SalesEmployeeCd];// 販売従業員コード
                    newRow[PMHNB02185EB.ct_Col_SalesEmployeeNm] = dr[PMHNB02185EA.ct_Col_SalesEmployeeNm];// 販売従業員名称
                    newRow[PMHNB02185EB.ct_Col_SalesAreaCode] = dr[PMHNB02185EA.ct_Col_SalesAreaCode];// 販売エリアコード
                    newRow[PMHNB02185EB.ct_Col_SalesAreaName] = dr[PMHNB02185EA.ct_Col_SalesAreaName];// 販売エリア名称

                    newRow[PMHNB02185EB.ct_Col_SalesCount] = dr[PMHNB02185EA.ct_Col_SalesCount]; // 伝票枚数
                    newRow[PMHNB02185EB.ct_Col_SalesTotalTaxExc] = dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]; // 純売上
                    newRow[PMHNB02185EB.ct_Col_GrossProfit] = (Int64)dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]
                                                             - (Int64)dr[PMHNB02185EA.ct_Col_TotalCost]; // 粗利(純売上 - 原価金額計)                   
                    //newRow[PMHNB02185EB.ct_Col_BusinessDays] 
                    //    = this.GetBussinessDays(dr[PMHNB02185EA.ct_Col_SecCode].ToString(), custSalesDistributionReportParam.StartDate); // 営業日数 // DEL BY 凌小青 on 2011/11/09

                    // --------ADD BY  凌小青 on 2011/11/09 for Redmine#26432 ---------->>>>>>>>>>>>>
                    DateTime startDate = Convert.ToDateTime(custSalesDistributionReportParam.StSalesDate.ToString().Substring(0, 4)
                                      + "/" + custSalesDistributionReportParam.StSalesDate.ToString().Substring(4, 2)
                                      + "/" + custSalesDistributionReportParam.StSalesDate.ToString().Substring(6, 2));
                    DateTime endDate = Convert.ToDateTime(custSalesDistributionReportParam.EdSalesDate.ToString().Substring(0, 4) 
                                       + "/" + custSalesDistributionReportParam.EdSalesDate.ToString().Substring(4, 2) 
                                       + "/" + custSalesDistributionReportParam.EdSalesDate.ToString().Substring(6, 2));
                    newRow[PMHNB02185EB.ct_Col_BusinessDays]
                       = this.GetBussinessDays(dr[PMHNB02185EA.ct_Col_SecCode].ToString(), startDate, endDate); // 営業日数
                    // --------ADD BY  凌小青 on 2011/11/09 for Redmine#26432 ----------<<<<<<<<<<<<<<

                    int salesDate = ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Year * 10000
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Month * 100
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Day;

                    if (salesDate >= custSalesDistributionReportParam.StSalesDate
                        && salesDate <= custSalesDistributionReportParam.EdSalesDate)
                    {
                        // 売上日付が画面入力の範囲内であれば"*"を設定
                        this.SetSalesDate(ref newRow, (DateTime)dr[PMHNB02185EA.ct_Col_SalesDate], custSalesDistributionReportParam.StartDate); // 売上日付
                    }

                    this._printDt.Rows.Add(newRow);

                    // キー値の保存
                    sectionKey = dr[PMHNB02185EA.ct_Col_SecCode].ToString();
                    codeKey = dr[codeColumnName].ToString();

                }
            }
        }

        /// <summary>
        /// 営業日数取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="targetDay"></param>
        /// <param name="endDay"></param> //ADD BY 凌小青 on 2011/11/09
        /// <returns>営業日数</returns>
        //private int GetBussinessDays(string sectionCode, DateTime targetDay) //DEL BY 凌小青 on 2011/11/09
        private int GetBussinessDays(string sectionCode, DateTime targetDay, DateTime endDay)//ADD BY 凌小青 on 2011/11/09
        {
            if (_holidaySettingAcs == null)
            {
                _holidaySettingAcs = new HolidaySettingAcs();
            }

            // 営業日数
            int bussinessDays;

            // 拠点コードの指定が無い場合、自拠点の営業日数を取得する
            if (string.IsNullOrEmpty(sectionCode) ||
                sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionCode = stc_Employee.BelongSectionCode;
            }

            //_holidaySettingAcs.GetWorkDaysInRange(sectionCode, targetDay, targetDay.AddMonths(1).AddDays(-1), out bussinessDays);//DEL BY 凌小青 on 2011/11/09
            _holidaySettingAcs.GetWorkDaysInRange(sectionCode, targetDay, endDay, out bussinessDays);//ADD BY 凌小青 on 2011/11/09 for Redmine#26432

            return bussinessDays;
        }

        /// <summary>
        /// 売上日付の印字設定
        /// </summary>
        /// <param name="setRow">印刷用テーブル(PMHNB02185EB)のDataRow</param>
        /// <param name="setDate"></param>
        /// <param name="startDate"></param>
        /// <remarks>
        /// <br>Note       　: 売上日付の印字設定を行う</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void SetSalesDate(ref DataRow setRow, DateTime setDate, DateTime startDate)
        {
            int dayInterval = ((TimeSpan)(setDate - startDate)).Days;

            switch (dayInterval)
            {
                case 0:
                    setRow[PMHNB02185EB.ct_Col_SalesDate1] = CT_SalesDateStr;
                    break;
                case 1:
                    setRow[PMHNB02185EB.ct_Col_SalesDate2] = CT_SalesDateStr;
                    break;
                case 2:
                    setRow[PMHNB02185EB.ct_Col_SalesDate3] = CT_SalesDateStr;
                    break;
                case 3:
                    setRow[PMHNB02185EB.ct_Col_SalesDate4] = CT_SalesDateStr;
                    break;
                case 4:
                    setRow[PMHNB02185EB.ct_Col_SalesDate5] = CT_SalesDateStr;
                    break;
                case 5:
                    setRow[PMHNB02185EB.ct_Col_SalesDate6] = CT_SalesDateStr;
                    break;
                case 6:
                    setRow[PMHNB02185EB.ct_Col_SalesDate7] = CT_SalesDateStr;
                    break;
                case 7:
                    setRow[PMHNB02185EB.ct_Col_SalesDate8] = CT_SalesDateStr;
                    break;
                case 8:
                    setRow[PMHNB02185EB.ct_Col_SalesDate9] = CT_SalesDateStr;
                    break;
                case 9:
                    setRow[PMHNB02185EB.ct_Col_SalesDate10] = CT_SalesDateStr;
                    break;
                case 10:
                    setRow[PMHNB02185EB.ct_Col_SalesDate11] = CT_SalesDateStr;
                    break;
                case 11:
                    setRow[PMHNB02185EB.ct_Col_SalesDate12] = CT_SalesDateStr;
                    break;
                case 12:
                    setRow[PMHNB02185EB.ct_Col_SalesDate13] = CT_SalesDateStr;
                    break;
                case 13:
                    setRow[PMHNB02185EB.ct_Col_SalesDate14] = CT_SalesDateStr;
                    break;
                case 14:
                    setRow[PMHNB02185EB.ct_Col_SalesDate15] = CT_SalesDateStr;
                    break;
                case 15:
                    setRow[PMHNB02185EB.ct_Col_SalesDate16] = CT_SalesDateStr;
                    break;
                case 16:
                    setRow[PMHNB02185EB.ct_Col_SalesDate17] = CT_SalesDateStr;
                    break;
                case 17:
                    setRow[PMHNB02185EB.ct_Col_SalesDate18] = CT_SalesDateStr;
                    break;
                case 18:
                    setRow[PMHNB02185EB.ct_Col_SalesDate19] = CT_SalesDateStr;
                    break;
                case 19:
                    setRow[PMHNB02185EB.ct_Col_SalesDate20] = CT_SalesDateStr;
                    break;
                case 20:
                    setRow[PMHNB02185EB.ct_Col_SalesDate21] = CT_SalesDateStr;
                    break;
                case 21:
                    setRow[PMHNB02185EB.ct_Col_SalesDate22] = CT_SalesDateStr;
                    break;
                case 22:
                    setRow[PMHNB02185EB.ct_Col_SalesDate23] = CT_SalesDateStr;
                    break;
                case 23:
                    setRow[PMHNB02185EB.ct_Col_SalesDate24] = CT_SalesDateStr;
                    break;
                case 24:
                    setRow[PMHNB02185EB.ct_Col_SalesDate25] = CT_SalesDateStr;
                    break;
                case 25:
                    setRow[PMHNB02185EB.ct_Col_SalesDate26] = CT_SalesDateStr;
                    break;
                case 26:
                    setRow[PMHNB02185EB.ct_Col_SalesDate27] = CT_SalesDateStr;
                    break;
                case 27:
                    setRow[PMHNB02185EB.ct_Col_SalesDate28] = CT_SalesDateStr;
                    break;
                case 28:
                    setRow[PMHNB02185EB.ct_Col_SalesDate29] = CT_SalesDateStr;
                    break;
                case 29:
                    setRow[PMHNB02185EB.ct_Col_SalesDate30] = CT_SalesDateStr;
                    break;
                case 30:
                    setRow[PMHNB02185EB.ct_Col_SalesDate31] = CT_SalesDateStr;
                    break;

            }
        }

        /// <summary>
        /// 順位設定
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       　: 順位の設定を行う</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void SetOrder(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            string savAddUpSecCode = ""; // 拠点コード
            int orderNo = 0; // 順位
            int orderNoPls = 0; // 順位加算値
            Int64 savTotls = -1;
            Int64 nowTotls = 0;

            DataTable tmpTable = this._printDt.Copy();
            this._printDt.Clear();

            // 順位付設定順に並び替え
            DataRow[] sortedDrList = tmpTable.Select("", this.GetSortStrForOrder(custSalesDistributionReportParam));

            for (int i = 0; i < sortedDrList.Length; i++)
            {
                DataRow dr = sortedDrList[i];

                // 拠点
                string tmpAddUpSecCode = (string)dr[PMHNB02185EB.ct_Col_SecCode];

                if (custSalesDistributionReportParam.RankSection == CustSalesDistributionReportParam.RankSectionState.Section)
                {
                    // 順位付が拠点毎かつ拠点が異なる場合、順位付情報を初期化
                    if (custSalesDistributionReportParam.RankSection == CustSalesDistributionReportParam.RankSectionState.Section
                        && savAddUpSecCode.Trim() != tmpAddUpSecCode.Trim())
                    {
                        savAddUpSecCode = tmpAddUpSecCode;
                        orderNo = 0;
                        orderNoPls = 0;
                        savTotls = -1;
                    }
                }

                if (custSalesDistributionReportParam.RankStandard == CustSalesDistributionReportParam.RankStandardState.Sales)
                {
                    // 純売上
                    nowTotls = (Int64)dr[PMHNB02185EB.ct_Col_SalesTotalTaxExc];
                }
                else
                {
                    // 粗利
                    nowTotls = (Int64)dr[PMHNB02185EB.ct_Col_GrossProfit];
                }

                if (savTotls == nowTotls)
                {
                    orderNoPls++;
                }
                else
                {
                    // 順位は最大値以上も振る
                    savTotls = nowTotls;
                    orderNo += orderNoPls;
                    orderNoPls = 0;
                }

                if (orderNoPls == 0)
                {
                    orderNo++;
                }

                dr[PMHNB02185EB.ct_Col_Order] = orderNo;

                this._printDt.ImportRow(dr);
            }
        }

        /// <summary>
        /// 順位付用ソート文字列作成
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       　: 順位付用ソート文字列を作成する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private string GetSortStrForOrder(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            StringBuilder sb = new StringBuilder();

            if (custSalesDistributionReportParam.RankSection == CustSalesDistributionReportParam.RankSectionState.Section)
            {
                // 拠点毎の場合、拠点でソート
                sb.Append(PMHNB02185EB.ct_Col_SecCode);
                sb.Append(", ");
            }

            // 順位指定
            if (custSalesDistributionReportParam.RankStandard == CustSalesDistributionReportParam.RankStandardState.Sales)
            {
                // 純売上
                sb.Append(PMHNB02185EB.ct_Col_SalesTotalTaxExc);
            }
            else
            {
                // 粗利
                sb.Append(PMHNB02185EB.ct_Col_GrossProfit);
            }

            if (custSalesDistributionReportParam.RankHighLow == CustSalesDistributionReportParam.RankHighLowState.High)
            {
                sb.Append(" DESC");
            }
            else
            {
                sb.Append(" ASC");
            }

            return sb.ToString();
        }

        /// <summary>
        /// DataView用フィルタ文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>フィルタ文字列</returns>
        /// <remarks>
        /// <br>Note       　: フィルタ文字列を作成する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private string GetFilterStrForPrintDv(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            return PMHNB02185EB.ct_Col_Order + " <= " + custSalesDistributionReportParam.RankOrderMax.ToString();
        }

        /// <summary>
        /// DataView用ソート文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       　: ソート文字列を作成する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private string GetSortStrForPrintDv(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            StringBuilder sb = new StringBuilder();

            // 拠点
            sb.Append(PMHNB02185EB.ct_Col_SecCode);
            sb.Append(", ");

            // 印刷順が"順位"であれば、順位
            if (custSalesDistributionReportParam.PrintOrder == CustSalesDistributionReportParam.PrintOrderState.Order)
            {
                sb.Append(PMHNB02185EB.ct_Col_Order);
                sb.Append(", ");
            }

            // 発行タイプ設定値
            if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                // 得意先別
                sb.Append(PMHNB02185EB.ct_Col_CustomerCode);
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                // 担当者別
                sb.Append(PMHNB02185EB.ct_Col_SalesEmployeeCd);
            }
            else
            {
                // 地区別
                sb.Append(PMHNB02185EB.ct_Col_SalesAreaCode);
            }

            return sb.ToString();

        }
        #endregion

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            CustSalesDistributionReportResultWork param1 = new CustSalesDistributionReportResultWork();

            param1.EnterpriseCode = "0101150842020000";
            param1.SecCode = "1";
            param1.SectionGuideSnm = "拠点名最大１０桁です";
            param1.CustomerCode = 88888888;
            param1.CustomerSnm = "得意名称最大１５桁です。３４５";
            param1.SalesEmployeeCd = "9999";
            param1.SalesEmployeeNm = "従業は最大１０桁です";
            param1.SalesAreaCode = 8888;
            param1.SalesAreaName = "地区は最大１０桁です";

            param1.SalesCount = 123456; // 伝票枚数
            param1.SalesTotalTaxExc = 987654321; //純売上
            param1.TotalCost = 123456789; // 原価金額計
            param1.SalesDate = new DateTime(2008, 11, 22); // 売上日付


            paramlist.Add(param1);

            CustSalesDistributionReportResultWork param2 = new CustSalesDistributionReportResultWork();

            param2.EnterpriseCode = "0101150842020000";
            param2.SecCode = "";
            param2.SectionGuideSnm = "";
            param2.CustomerCode = 0;
            param2.CustomerSnm = "";
            param2.SalesEmployeeCd = "";
            param2.SalesEmployeeNm = "";
            param2.SalesAreaCode = 0;
            param2.SalesAreaName = "";

            param2.SalesCount = 0; // 伝票枚数
            param2.SalesTotalTaxExc = 0; //純売上
            param2.TotalCost = 0; // 原価金額計
            param2.SalesDate = new DateTime(2008, 11, 25); // 売上日付

            paramlist.Add(param2);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
