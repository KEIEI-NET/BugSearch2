using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上内容分析表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 売上内容分析表で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.11</br>
    /// <br>             : </br>
    /// </remarks>
    public class SalesHistAnalyzeAcs
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 売上内容分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売上内容分析表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.11</br>
		/// </remarks>
		public SalesHistAnalyzeAcs()
		{
            this._iSalesHistAnalyzeResultWorkDB = (ISalesHistAnalyzeResultWorkDB)MediationSalesHistAnalyzeResultWorkDB.GetSalesHistAnalyzeResultWorkDB();
		}

		/// <summary>
        /// 売上内容分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売上内容分析表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.11</br>
		/// </remarks>
        static SalesHistAnalyzeAcs()
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

        #region ■ Private変数

        ISalesHistAnalyzeResultWorkDB _iSalesHistAnalyzeResultWorkDB;

        private DataTable _salesHistAnalyzeResultDt; // 印刷DataTable
        private DataView _salesHistAnalyzeResultDv; // 印刷DataView

        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView SalesHistAnalyzeResultDataView
        {
            get { return this._salesHistAnalyzeResultDv; }
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        public int SearchMain(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, out string errMsg)
        {
            return this.SearchProc(salesHistAnalyzeCndtn, out errMsg);
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private int SearchProc(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02165EA.CreateDataTable(ref this._salesHistAnalyzeResultDt);

                SalesHistAnalyzeCndtnWork salesHistAnalyzeCndtnWork = new SalesHistAnalyzeCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(salesHistAnalyzeCndtn, out salesHistAnalyzeCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iSalesHistAnalyzeResultWorkDB.Search(out retWorkList, salesHistAnalyzeCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テスト用
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(salesHistAnalyzeCndtn, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "売上内容分析表データの取得に失敗しました。";
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private int DevListCndtn(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, out SalesHistAnalyzeCndtnWork salesHistAnalyzeCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            salesHistAnalyzeCndtnWork = new SalesHistAnalyzeCndtnWork();
            try
            {
                salesHistAnalyzeCndtnWork.EnterpriseCode = salesHistAnalyzeCndtn.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (salesHistAnalyzeCndtn.SectionCode.Length != 0)
                {
                    if (salesHistAnalyzeCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        salesHistAnalyzeCndtnWork.SectionCode = null;
                    }
                    else
                    {
                        salesHistAnalyzeCndtnWork.SectionCode = salesHistAnalyzeCndtn.SectionCode;
                    }
                }
                else
                {
                    salesHistAnalyzeCndtnWork.SectionCode = null;
                }

                salesHistAnalyzeCndtnWork.St_SalesDate = salesHistAnalyzeCndtn.St_SalesDate; // 開始対象日付
                salesHistAnalyzeCndtnWork.Ed_SalesDate = salesHistAnalyzeCndtn.Ed_SalesDate; // 終了対象日付
                salesHistAnalyzeCndtnWork.St_MonthReportDate = salesHistAnalyzeCndtn.St_MonthReportDate; // 開始対象日付(累計)
                salesHistAnalyzeCndtnWork.Ed_MonthReportDate = salesHistAnalyzeCndtn.Ed_MonthReportDate; // 終了対象日付(累計)

                salesHistAnalyzeCndtnWork.St_CustomerCode = salesHistAnalyzeCndtn.St_CustomerCode; // 開始得意先コード
                if (salesHistAnalyzeCndtn.Ed_CustomerCode == 0) salesHistAnalyzeCndtnWork.Ed_CustomerCode = 99999999;
                else salesHistAnalyzeCndtnWork.Ed_CustomerCode = salesHistAnalyzeCndtn.Ed_CustomerCode; // 終了得意先コード

                salesHistAnalyzeCndtnWork.St_SalesEmployeeCd = salesHistAnalyzeCndtn.St_SalesEmployeeCd; // 開始担当者コード
                salesHistAnalyzeCndtnWork.Ed_SalesEmployeeCd = salesHistAnalyzeCndtn.Ed_SalesEmployeeCd; // 終了担当者コード

                salesHistAnalyzeCndtnWork.St_SalesAreaCode = salesHistAnalyzeCndtn.St_SalesAreaCode; // 開始地区コード
                if (salesHistAnalyzeCndtn.Ed_SalesAreaCode == 0) salesHistAnalyzeCndtnWork.Ed_SalesAreaCode = 9999;
                else salesHistAnalyzeCndtnWork.Ed_SalesAreaCode = salesHistAnalyzeCndtn.Ed_SalesAreaCode; // 終了地区コード

                salesHistAnalyzeCndtnWork.PrintDiv = (int)salesHistAnalyzeCndtn.PrintDiv; // 発行タイプ
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private void DevListData(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, ArrayList resultWork)
        {
            // リモート抽出結果をDataTableに展開
            DataRow dr;

            foreach (SalesHistAnalyzeResultWork salesHistAnalyzeResultWork in resultWork)
            {
                dr = this._salesHistAnalyzeResultDt.NewRow();

                dr[PMHNB02165EA.ct_Col_EnterpriseCode] = salesHistAnalyzeResultWork.EnterpriseCode; // 企業コード
                dr[PMHNB02165EA.ct_Col_SecCode] = salesHistAnalyzeResultWork.SecCode; // 拠点コード
                dr[PMHNB02165EA.ct_Col_SectionGuideSnm] = salesHistAnalyzeResultWork.SectionGuideSnm; // 拠点ガイド名称
                dr[PMHNB02165EA.ct_Col_CustomerCode] = salesHistAnalyzeResultWork.CustomerCode; // 得意先コード
                dr[PMHNB02165EA.ct_Col_CustomerSnm] = salesHistAnalyzeResultWork.CustomerSnm; // 得意先略称
                dr[PMHNB02165EA.ct_Col_SalesEmployeeCd] = salesHistAnalyzeResultWork.SalesEmployeeCd; // 担当者コード
                dr[PMHNB02165EA.ct_Col_SalesEmployeeNm] = salesHistAnalyzeResultWork.SalesEmployeeNm; // 担当者名称
                dr[PMHNB02165EA.ct_Col_SalesAreaCode] = salesHistAnalyzeResultWork.SalesAreaCode; // 販売エリアコード
                dr[PMHNB02165EA.ct_Col_SalesAreaName] = salesHistAnalyzeResultWork.SalesAreaName; // 販売エリア名称

                dr[PMHNB02165EA.ct_Col_SalesMoneyOrder] = salesHistAnalyzeResultWork.SalesMoneyOrder; // 売上金額(日計取寄)
                dr[PMHNB02165EA.ct_Col_SalesMoneyStock] = salesHistAnalyzeResultWork.SalesMoneyStock; // 売上金額(日計在庫)
                dr[PMHNB02165EA.ct_Col_SalesMoneyGenuine] = salesHistAnalyzeResultWork.SalesMoneyGenuine; // 売上金額(日計純正)
                dr[PMHNB02165EA.ct_Col_SalesMoneyPrm] = salesHistAnalyzeResultWork.SalesMoneyPrm; // 売上金額(日計優良)
                dr[PMHNB02165EA.ct_Col_SalesMoneyOutside] = salesHistAnalyzeResultWork.SalesMoneyOutside; // 売上金額(日計外装)
                dr[PMHNB02165EA.ct_Col_SalesMoneyOther] = salesHistAnalyzeResultWork.SalesMoneyOther; // 売上金額(日計その他)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyOrder] = salesHistAnalyzeResultWork.MonthSalesMoneyOrder; // 売上金額(累計取寄)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyStock] = salesHistAnalyzeResultWork.MonthSalesMoneyStock; // 売上金額(累計在庫)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyGenuine] = salesHistAnalyzeResultWork.MonthSalesMoneyGenuine; // 売上金額(累計純正)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyPrm] = salesHistAnalyzeResultWork.MonthSalesMoneyPrm; // 売上金額(累計優良)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyOutside] = salesHistAnalyzeResultWork.MonthSalesMoneyOutside; // 売上金額(累計外装)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyOther] = salesHistAnalyzeResultWork.MonthSalesMoneyOther; // 売上金額(累計その他)

                dr[PMHNB02165EA.ct_Col_GrossProfitOrder] = salesHistAnalyzeResultWork.GrossProfitOrder; // 粗利金額(日計取寄)
                dr[PMHNB02165EA.ct_Col_GrossProfitStock] = salesHistAnalyzeResultWork.GrossProfitStock; // 粗利金額(日計在庫)
                dr[PMHNB02165EA.ct_Col_GrossProfitGenuine] = salesHistAnalyzeResultWork.GrossProfitGenuine; // 粗利金額(日計純正)
                dr[PMHNB02165EA.ct_Col_GrossProfitPrm] = salesHistAnalyzeResultWork.GrossProfitPrm; // 粗利金額(日計優良)
                dr[PMHNB02165EA.ct_Col_GrossProfitOutside] = salesHistAnalyzeResultWork.GrossProfitOutside; // 粗利金額(日計外装)
                dr[PMHNB02165EA.ct_Col_GrossProfitOther] = salesHistAnalyzeResultWork.GrossProfitOther; // 粗利金額(日計その他)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitOrder] = salesHistAnalyzeResultWork.MonthGrossProfitOrder; // 粗利金額(累計取寄)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitStock] = salesHistAnalyzeResultWork.MonthGrossProfitStock; // 粗利金額(累計在庫)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitGenuine] = salesHistAnalyzeResultWork.MonthGrossProfitGenuine; // 粗利金額(累計純正)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitPrm] = salesHistAnalyzeResultWork.MonthGrossProfitPrm; // 粗利金額(累計優良)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitOutside] = salesHistAnalyzeResultWork.MonthGrossProfitOutside; // 粗利金額(累計外装)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitOther] = salesHistAnalyzeResultWork.MonthGrossProfitOther; // 粗利金額(累計その他)

                this._salesHistAnalyzeResultDt.Rows.Add(dr);
            }

            // DataView作成
            // 発行タイプによりソート
            this._salesHistAnalyzeResultDv = new DataView(this._salesHistAnalyzeResultDt, "", this.GetSortStr(salesHistAnalyzeCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// DataView用ソート文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       　: ソート文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private string GetSortStr(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn)
        {
            string sortStr = string.Empty;

            switch (salesHistAnalyzeCndtn.PrintDiv)
            {
                case SalesHistAnalyzeCndtn.PrintDivState.Customer:
                    {
                        // 拠点-得意先でソート
                        sortStr = PMHNB02165EA.ct_Col_SecCode + ", " + PMHNB02165EA.ct_Col_CustomerCode;
                        break;
                    }
                case SalesHistAnalyzeCndtn.PrintDivState.Employee:
                    {
                        // 拠点-担当者でソート
                        sortStr = PMHNB02165EA.ct_Col_SecCode + ", " + PMHNB02165EA.ct_Col_SalesEmployeeCd;
                        break;
                    }
                case SalesHistAnalyzeCndtn.PrintDivState.SalesArea:
                    {
                        // 拠点-地区でソート
                        sortStr = PMHNB02165EA.ct_Col_SecCode + ", " + PMHNB02165EA.ct_Col_SalesAreaCode;
                        break;
                    }
            }

            return sortStr;

        }
        #endregion

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            SalesHistAnalyzeResultWork param1 = new SalesHistAnalyzeResultWork();

            param1.SecCode = "99";
            param1.SectionGuideSnm = "拠点名最大１０桁です";
            param1.CustomerCode = 88888888;
            param1.CustomerSnm = "得意名称最大１５桁です。３４５";
            param1.SalesEmployeeCd = "9999";
            param1.SalesEmployeeNm = "従業は最大１０桁です";
            param1.SalesAreaCode = 8888;
            param1.SalesAreaName = "地区は最大１０桁です";

            param1.SalesMoneyOrder = 2500000000; // 売上金額(日計取寄)
            param1.SalesMoneyStock = 7500000000; // 売上金額(日計在庫)
            param1.SalesMoneyGenuine = 2500000000; // 売上金額(日計純正)
            param1.SalesMoneyPrm = 7500000000; // 売上金額(日計優良)
            param1.SalesMoneyOutside = 2500000000; // 売上金額(日計外装)
            param1.SalesMoneyOther = 7500000000; // 売上金額(日計その他)

            param1.MonthSalesMoneyOrder = 2500000000; // 売上金額(累計取寄)
            param1.MonthSalesMoneyStock = 2500000000; // 売上金額(累計在庫)
            param1.MonthSalesMoneyGenuine = 2500000000; // 売上金額(累計純正)
            param1.MonthSalesMoneyPrm = 2500000000; // 売上金額(累計優良)
            param1.MonthSalesMoneyOutside = 2500000000; // 売上金額(累計外装)
            param1.MonthSalesMoneyOther = 2500000000; // 売上金額(累計その他)
            
            //paramlist.Add(param1);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
