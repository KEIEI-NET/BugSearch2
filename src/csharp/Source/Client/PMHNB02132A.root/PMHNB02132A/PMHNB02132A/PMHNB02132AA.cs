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
    /// 得意先別過年度統計表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 得意先別過年度統計表で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.10.31</br>
    /// <br>             : </br>
    /// </remarks>
    public class CustFinancialListAcs
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 得意先別過年度統計表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先別過年度統計表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.10.31</br>
		/// </remarks>
		public CustFinancialListAcs()
		{
            this._iCustFinancialListResultWorkDB = (ICustFinancialListResultWorkDB)MediationCustFinancialListResultWorkDB.GetCustFinancialListResultWorkDB();
		}

		/// <summary>
        /// 得意先別過年度統計表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先別過年度統計表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.10.31</br>
		/// </remarks>
        static CustFinancialListAcs()
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
        ICustFinancialListResultWorkDB _iCustFinancialListResultWorkDB;

        private DataTable _custFinancialRsltPrintListDt;                    // リモート抽出結果保持DataTable 
        private DataTable _custFinancialRsltPrintListForPrintDt;			// 印刷DataTable
        private DataView _custFinancialRsltPrintListForPrintDv;	            // 印刷DataView

        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView CustFinancialRsltPrintListForPrintDataView
        {
            get { return this._custFinancialRsltPrintListForPrintDv; }
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        public int SearchMain(CustFinancialListCndtn custFinancialListCndtn, out string errMsg)
        {
            return this.SearchProc(custFinancialListCndtn, out errMsg);
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private int SearchProc(CustFinancialListCndtn custFinancialListCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02135EA.CreateDataTable(ref this._custFinancialRsltPrintListDt);
                PMHNB02135EB.CreateDataTable(ref this._custFinancialRsltPrintListForPrintDt);

                CustFinancialListCndtnWork custFinancialListCndtnWork = new CustFinancialListCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(custFinancialListCndtn, out custFinancialListCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iCustFinancialListResultWorkDB.Search(out retWorkList, custFinancialListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テスト用
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(custFinancialListCndtn, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "得意先別過年度統計表データの取得に失敗しました。";
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private int DevListCndtn(CustFinancialListCndtn custFinancialListCndtn, out CustFinancialListCndtnWork custFinancialListCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            custFinancialListCndtnWork = new CustFinancialListCndtnWork();
            try
            {
                custFinancialListCndtnWork.EnterpriseCode = custFinancialListCndtn.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (custFinancialListCndtn.AddUpSecCodes.Length != 0)
                {
                    if (custFinancialListCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        custFinancialListCndtnWork.AddUpSecCodes = null;
                    }
                    else
                    {
                        custFinancialListCndtnWork.AddUpSecCodes = custFinancialListCndtn.AddUpSecCodes;
                    }
                }
                else
                {
                    custFinancialListCndtnWork.AddUpSecCodes = null;
                }
                
                custFinancialListCndtnWork.St_CustomerCode = custFinancialListCndtn.St_CustomerCode; // 開始得意先コード
                if (custFinancialListCndtn.Ed_CustomerCode == 0) custFinancialListCndtnWork.Ed_CustomerCode = 99999999;
                else custFinancialListCndtnWork.Ed_CustomerCode = custFinancialListCndtn.Ed_CustomerCode; // 終了得意先コード
                custFinancialListCndtnWork.St_Year = custFinancialListCndtn.St_Year; // 開始年度
                custFinancialListCndtnWork.Ed_Year = custFinancialListCndtn.Ed_Year; // 終了年度
                custFinancialListCndtnWork.St_AddUpYearMonth = custFinancialListCndtn.St_AddUpYearMonth; // 開始計上年月
                custFinancialListCndtnWork.Ed_AddUpYearMonth = custFinancialListCndtn.Ed_AddUpYearMonth; // 終了計上年月
                custFinancialListCndtnWork.PrintDiv = (int)custFinancialListCndtn.PrintDiv; // 発行タイプ
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private void DevListData(CustFinancialListCndtn custFinancialListCndtn, ArrayList resultWork)
        {
            // リモート抽出結果をリモート抽出結果用DataTable(PMHNB02135EA)に展開
            DataRow dr;

            foreach (CustFinancialListResultWork custFinancialListResultWork in resultWork)
            {
                dr = this._custFinancialRsltPrintListDt.NewRow();

                dr[PMHNB02135EA.ct_Col_EnterpriseCode] = custFinancialListResultWork.EnterpriseCode; // 企業コード
                dr[PMHNB02135EA.ct_Col_AddUpSecCode] = custFinancialListResultWork.AddUpSecCode; // 計上拠点コード
                dr[PMHNB02135EA.ct_Col_SectionGuideSnm] = custFinancialListResultWork.SectionGuideSnm; // 拠点ガイド名称
                dr[PMHNB02135EA.ct_Col_CustomerCode] = custFinancialListResultWork.CustomerCode; // 得意先コード
                dr[PMHNB02135EA.ct_Col_CustomerSnm] = custFinancialListResultWork.CustomerSnm; // 得意先略称
                dr[PMHNB02135EA.ct_Col_SalesMoney] = custFinancialListResultWork.SalesMoney; // 売上金額
                dr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] = custFinancialListResultWork.SalesRetGoodsPrice; // 返品額
                dr[PMHNB02135EA.ct_Col_DiscountPrice] = custFinancialListResultWork.DiscountPrice; // 値引金額
                dr[PMHNB02135EA.ct_Col_GrossProfit] = custFinancialListResultWork.GrossProfit; // 粗利金額
                dr[PMHNB02135EA.ct_Col_FinancialYear] = custFinancialListResultWork.FinancialYear; // 会計年度

                this._custFinancialRsltPrintListDt.Rows.Add(dr);
            }

            // 帳票印字用DataTable(PMHNB02135EB)に詰替え
            // 抽出結果DataRow配列
            DataRow[] workDrList;

            if (custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Section
                || custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.ManageSection)
            {
                // 拠点コードでソート
                // リモートで得意先を設定しないので、この分岐はなくてもよい
                workDrList = this._custFinancialRsltPrintListDt.Select("", PMHNB02135EA.ct_Col_AddUpSecCode);
            }
            else
            {
                // 拠点コード、得意先でソート
                workDrList = this._custFinancialRsltPrintListDt.Select("", PMHNB02135EA.ct_Col_AddUpSecCode + ", " + PMHNB02135EA.ct_Col_CustomerCode);
            }

            string workSectionCode = string.Empty;
            int workCustomerCode = 0;
            DataRow printDr; // 帳票印字用テーブルのDataRow

            for (int i = 0; i < workDrList.Length; i++)
            {
                // 抽出結果DataRow
                DataRow workDr = workDrList[i];

                if (i == 0
                    || workSectionCode != workDr[PMHNB02135EA.ct_Col_AddUpSecCode].ToString()
                    || ((custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Customer
                        || custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.CustomerSection
                        || custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Clame)
                        && workCustomerCode != (int)workDr[PMHNB02135EA.ct_Col_CustomerCode]))
                {
                    // 1行目の場合、拠点コードが異なる場合、（得意先別か得意先別拠点別か請求先別）かつ得意先が異なる場合は新規行作成
                    printDr = this._custFinancialRsltPrintListForPrintDt.NewRow();

                    printDr[PMHNB02135EB.ct_Col_SectionCode] = workDr[PMHNB02135EA.ct_Col_AddUpSecCode]; // 拠点コード
                    printDr[PMHNB02135EB.ct_Col_SectionName] = workDr[PMHNB02135EA.ct_Col_SectionGuideSnm];// 拠点名称
                    printDr[PMHNB02135EB.ct_Col_CustomerCode] = workDr[PMHNB02135EA.ct_Col_CustomerCode];// 得意先コード
                    printDr[PMHNB02135EB.ct_Col_CustomerName] = workDr[PMHNB02135EA.ct_Col_CustomerSnm];// 得意先名称

                    // 売上金額、粗利金額設定
                    this.SetFinancialMoneyData(custFinancialListCndtn, ref printDr, workDr);

                    this._custFinancialRsltPrintListForPrintDt.Rows.Add(printDr);

                    // 追加した行の拠点コードと得意先コードを保持
                    workSectionCode = workDr[PMHNB02135EA.ct_Col_AddUpSecCode].ToString();
                    workCustomerCode = (int)workDr[PMHNB02135EA.ct_Col_CustomerCode];
                }
                else
                {
                    // 帳票用DataTableの既存行にデータ追加
                    printDr = this._custFinancialRsltPrintListForPrintDt.Rows[this._custFinancialRsltPrintListForPrintDt.Rows.Count - 1];

                    // 売上金額、粗利金額設定
                    this.SetFinancialMoneyData(custFinancialListCndtn, ref printDr, workDr);
                }
            }

            // 2009.02.05 30413 犬飼 帳票内で金額単位を計算 >>>>>>START
            // 金額単位適用
            //ReflectMoneyUnit(custFinancialListCndtn);
            // 2009.02.05 30413 犬飼 帳票内で金額単位を計算 <<<<<<END
            
            // DataView作成
            // 発行タイプによりソート
            this._custFinancialRsltPrintListForPrintDv = new DataView(this._custFinancialRsltPrintListForPrintDt, "", this.GetSortStr(custFinancialListCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 売上金額、粗利金額設定処理
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <param name="printDr">帳票印字用DataRow</param>
        /// <param name="workDr">リモート抽出結果DataRow</param>
        /// <remarks>
        /// <br>Note       　: 売上金額、粗利金額を会計年度毎に応じた帳票項目に設定する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private void SetFinancialMoneyData(CustFinancialListCndtn custFinancialListCndtn, ref DataRow printDr, DataRow workDr)
        {
            // 会計年度 - 開始対象年 + 1 = 帳票の印字対象列index 
            int index = (Int32)workDr[PMHNB02135EA.ct_Col_FinancialYear] - custFinancialListCndtn.St_Year.Year + 1;

            switch (index)
            {
                case 1:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney1] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit1] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 2:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney2] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit2] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 3:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney3] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit3] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 4:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney4] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit4] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 5:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney5] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit5] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 6:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney6] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit6] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 7:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney7] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit7] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 8:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney8] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit8] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
            }
        }

        /// <summary>
        /// DataView用ソート文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       　: 売上金額、粗利金額を会計年度毎に応じた帳票項目に設定する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private string GetSortStr(CustFinancialListCndtn custFinancialListCndtn)
        {
            string sortStr = string.Empty;

            switch (custFinancialListCndtn.PrintDiv)
            {
                case CustFinancialListCndtn.PrintDivState.Customer:
                case CustFinancialListCndtn.PrintDivState.Clame:
                    {
                        // 拠点-得意先でソート
                        sortStr = PMHNB02135EB.ct_Col_SectionCode + ", " + PMHNB02135EB.ct_Col_CustomerCode;
                        break;
                    }
                case CustFinancialListCndtn.PrintDivState.Section:
                case CustFinancialListCndtn.PrintDivState.ManageSection:
                    {
                        // 拠点でソート
                        sortStr = PMHNB02135EB.ct_Col_SectionCode;
                        break;
                    }
                case CustFinancialListCndtn.PrintDivState.CustomerSection:
                    {
                        // 得意先-拠点でソート
                        sortStr = PMHNB02135EB.ct_Col_CustomerCode + ", " + PMHNB02135EB.ct_Col_SectionCode;
                        break;
                    }
            }

            return sortStr;

        }

        /// <summary>
        /// 金額単位設定
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       　: 売上金額、粗利金額に金額単位の反映を行う</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private void ReflectMoneyUnit(CustFinancialListCndtn custFinancialListCndtn)
        {
            int priceUnit = 1;

            if (custFinancialListCndtn.MoneyUnit == CustFinancialListCndtn.MoneyUnitState.One)
            {
                // 処理は不要
                return;
            }
            else if (custFinancialListCndtn.MoneyUnit == CustFinancialListCndtn.MoneyUnitState.Thousand)
            {
                // 千円単位
                priceUnit = 1000;
            }

            foreach(DataRow dr in this._custFinancialRsltPrintListForPrintDt.Rows)
            {
                dr[PMHNB02135EB.ct_Col_SalesMoney1] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney1]) / (decimal)priceUnit); // 売上金額１
                dr[PMHNB02135EB.ct_Col_SalesMoney2] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney2]) / (decimal)priceUnit); // 売上金額２
                dr[PMHNB02135EB.ct_Col_SalesMoney3] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney3]) / (decimal)priceUnit); // 売上金額３
                dr[PMHNB02135EB.ct_Col_SalesMoney4] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney4]) / (decimal)priceUnit); // 売上金額４
                dr[PMHNB02135EB.ct_Col_SalesMoney5] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney5]) / (decimal)priceUnit); // 売上金額５
                dr[PMHNB02135EB.ct_Col_SalesMoney6] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney6]) / (decimal)priceUnit); // 売上金額６
                dr[PMHNB02135EB.ct_Col_SalesMoney7] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney7]) / (decimal)priceUnit); // 売上金額７
                dr[PMHNB02135EB.ct_Col_SalesMoney8] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney8]) / (decimal)priceUnit); // 売上金額８

                dr[PMHNB02135EB.ct_Col_GrossProfit1] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit1]) / (decimal)priceUnit); // 粗利金額１
                dr[PMHNB02135EB.ct_Col_GrossProfit2] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit2]) / (decimal)priceUnit); // 粗利金額２
                dr[PMHNB02135EB.ct_Col_GrossProfit3] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit3]) / (decimal)priceUnit); // 粗利金額３
                dr[PMHNB02135EB.ct_Col_GrossProfit4] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit4]) / (decimal)priceUnit); // 粗利金額４
                dr[PMHNB02135EB.ct_Col_GrossProfit5] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit5]) / (decimal)priceUnit); // 粗利金額５
                dr[PMHNB02135EB.ct_Col_GrossProfit6] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit6]) / (decimal)priceUnit); // 粗利金額６
                dr[PMHNB02135EB.ct_Col_GrossProfit7] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit7]) / (decimal)priceUnit); // 粗利金額７
                dr[PMHNB02135EB.ct_Col_GrossProfit8] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit8]) / (decimal)priceUnit); // 粗利金額８
            }
        }
        #endregion

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            //CustFinancialListResultWork param1 = new CustFinancialListResultWork();

            //param1.AddUpSecCode = "1";
            //param1.SectionGuideSnm = "拠点名最大１０桁です";
            //param1.CustomerCode = 22;
            //param1.CustomerSnm = "得意名最大１０桁です";
            //param1.SalesMoney = 13;
            //param1.SalesRetGoodsPrice = -1;
            //param1.DiscountPrice = -2;
            //param1.GrossProfit = 111;
            //param1.FinancialYear = 2008;

            //paramlist.Add(param1);

            //CustFinancialListResultWork param2 = new CustFinancialListResultWork();

            //param2.AddUpSecCode = "1";
            //param2.SectionGuideSnm = "拠点名最大１０桁です";
            //param2.CustomerCode = 22;
            //param2.CustomerSnm = "得意名最大１０桁です";
            //param2.SalesMoney = 23;
            //param2.SalesRetGoodsPrice = -1;
            //param2.DiscountPrice = -2;
            //param2.GrossProfit = 222;
            //param2.FinancialYear = 2007;

            //paramlist.Add(param2);

            //CustFinancialListResultWork param3 = new CustFinancialListResultWork();

            //param3.AddUpSecCode = "1";
            //param3.SectionGuideSnm = "拠点名最大１０桁です";
            //param3.CustomerCode = 22;
            //param3.CustomerSnm = "得意名最大１０桁です";
            //param3.SalesMoney = 33;
            //param3.SalesRetGoodsPrice = -1;
            //param3.DiscountPrice = -2;
            //param3.GrossProfit = 333;
            //param3.FinancialYear = 2006;

            //paramlist.Add(param3);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
