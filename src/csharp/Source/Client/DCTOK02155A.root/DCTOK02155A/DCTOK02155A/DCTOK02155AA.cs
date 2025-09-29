//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上仕入対比表(月報年報)
// プログラム概要   : 売上仕入対比表(月報年報)の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/12/09  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/01/08  修正内容 : 障害対応9507(対比項目の設定を修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13137】残案件No.19 端数処理
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 売上仕入対比表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上仕入対比表で使用するデータを取得する。</br>
    /// <br>Programmer	: 96186 立花 裕輔</br>
    /// <br>Date		: 2007.09.03</br>
    /// <br>Update Note : 2008.12.09 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>Update Note : 2009.01.08 30452 上野 俊治</br>
    /// <br>             ・障害対応9507(対比項目の設定を修正)</br>
    /// </remarks>
	public class SalStcCompMonthYearReportAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 売上仕入対比表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上仕入対比表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public SalStcCompMonthYearReportAcs()
		{
			this._iSalesSlipYearContrastResultWorkDB = 
                (ISalesSlipYearContrastResultWorkDB)MediationSalesSlipYearContrastResultWorkDB.GetSalesSlipYearContrastResultWorkDB();
		}

		/// <summary>
		/// 売上仕入対比表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上仕入対比表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		static SalStcCompMonthYearReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
        //ISalStcCompMonthYearReportDB _iSalStcCompMonthYearReportDB; // DEL 2008/12/09
        ISalesSlipYearContrastResultWorkDB _iSalesSlipYearContrastResultWorkDB; // ADD 2008/12/09

		private DataTable _salStcCompMonthYearReportDt;			// 印刷DataTable
		private DataView _salStcCompMonthYearReportView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView SalStcCompMonthYearReportView
		{
			get{ return this._salStcCompMonthYearReportView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// 入金データ取得
		/// </summary>
		/// <param name="salStcCompMonthYearReport">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する入金データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public int SearchSalStcCompMonthYearReportProcMain(SalStcCompMonthYearReport salStcCompMonthYearReport, out string errMsg)
		{
			return this.SearchSalStcCompMonthYearReportProc(salStcCompMonthYearReport, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="salStcCompMonthYearReport"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private int SearchSalStcCompMonthYearReportProc(SalStcCompMonthYearReport salStcCompMonthYearReport, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCTOK02154EA.CreateDataTable(ref this._salStcCompMonthYearReportDt);
				
				// 抽出条件展開  --------------------------------------------------------------
                SalesSlipYearContrastParamWork salesSlipYearContrastParamWork = new SalesSlipYearContrastParamWork();
                status = this.DevSalesDayMonthReport(salStcCompMonthYearReport, out salesSlipYearContrastParamWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object salStcCompMonthYearReportResultWork = null;
                status = _iSalesSlipYearContrastResultWorkDB.Search(
                out salStcCompMonthYearReportResultWork, salesSlipYearContrastParamWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テストデータ
                //status = testproc(out salStcCompMonthYearReportResultWork);

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( salStcCompMonthYearReport, (ArrayList)salStcCompMonthYearReportResultWork );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "売上履歴データの取得に失敗しました。";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票データ取得

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
		/// <param name="salStcCompMonthYearReport">UI抽出条件クラス</param>
		/// <param name="stockMoveListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        //private int DevSalesDayMonthReport(SalStcCompMonthYearReport salStcCompMonthYearReport, out SalStcCompMonthYearReportParamWork salStcCompMonthYearReportParamWork, out string errMsg) // DEL 2008/12/09
        private int DevSalesDayMonthReport(SalStcCompMonthYearReport salStcCompMonthYearReport, out SalesSlipYearContrastParamWork salesSlipYearContrastParamWork, out string errMsg) // ADD 2008/12/09
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            //salStcCompMonthYearReportParamWork = new SalStcCompMonthYearReportParamWork(); // DEL 2008/12/09
            salesSlipYearContrastParamWork = new SalesSlipYearContrastParamWork(); // ADD 2008/12/09

			try
			{
                // --- DEL 2008/12/09 -------------------------------->>>>>
                //salStcCompMonthYearReportParamWork.EnterpriseCode = salStcCompMonthYearReport.EnterpriseCode;
                //salStcCompMonthYearReportParamWork.SectionCodes = salStcCompMonthYearReport.SectionCodes;
                //salStcCompMonthYearReportParamWork.SalesDateSt = salStcCompMonthYearReport.SalesDateSt;
                //salStcCompMonthYearReportParamWork.SalesDateEd = salStcCompMonthYearReport.SalesDateEd;
                //salStcCompMonthYearReportParamWork.MonthReportDateSt = salStcCompMonthYearReport.MonthReportDateSt;
                //salStcCompMonthYearReportParamWork.MonthReportDateEd = salStcCompMonthYearReport.MonthReportDateEd;
                //salStcCompMonthYearReportParamWork.SupplierCdSt = salStcCompMonthYearReport.SupplierCdSt;
                //salStcCompMonthYearReportParamWork.SupplierCdEd = salStcCompMonthYearReport.SupplierCdEd;
                //salStcCompMonthYearReportParamWork.PrintType = salStcCompMonthYearReport.PrintType;
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- ADD 2008/12/09 -------------------------------->>>>>
                salesSlipYearContrastParamWork.EnterpriseCode = salStcCompMonthYearReport.EnterpriseCode;
                salesSlipYearContrastParamWork.SectionCodes = salStcCompMonthYearReport.SectionCodes;
                salesSlipYearContrastParamWork.StAddUpYearMonth = salStcCompMonthYearReport.SalesDateSt;
                salesSlipYearContrastParamWork.EdAddUpYearMonth = salStcCompMonthYearReport.SalesDateEd;
                salesSlipYearContrastParamWork.StAnnualAddUpYearMonth = salStcCompMonthYearReport.MonthReportDateSt;
                salesSlipYearContrastParamWork.EdAnnualAddUpYearMonth = salStcCompMonthYearReport.MonthReportDateEd;
                salesSlipYearContrastParamWork.StSupplierCd = salStcCompMonthYearReport.SupplierCdSt;
                if (salStcCompMonthYearReport.SupplierCdEd == 0) salesSlipYearContrastParamWork.EdSupplierCd = 999999;
                else salesSlipYearContrastParamWork.EdSupplierCd = salStcCompMonthYearReport.SupplierCdEd;
                //salesSlipYearContrastParamWork.PrintType = salStcCompMonthYearReport.PrintType;
                // --- ADD 2008/12/09 --------------------------------<<<<<
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
		/// <param name="salStcCompMonthYearReport">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private void DevStockMoveData ( SalStcCompMonthYearReport salStcCompMonthYearReport, ArrayList list )
		{
			DataRow dr;

            // --- DEL 2008/12/09 -------------------------------->>>>>
            ////金額単位 1円単位
            //Int64 moneyUnit = 1;
            //if (salStcCompMonthYearReport.MoneyUnit == 0)
            //{
            //    moneyUnit = 1;
            //}
            ////金額単位 1000円単位
            //else
            //{
            //    moneyUnit = 1000;
            //}
            // --- DEL 2008/12/09 --------------------------------<<<<<

            foreach (SalesSlipYearContrastResultWork salesSlipYearContrastResultWork in list)
			{
				dr = this._salStcCompMonthYearReportDt.NewRow();

                // 取得データ展開
                #region 取得データ展開
                // --- DEL 2008/12/09 -------------------------------->>>>>
                //dr[DCTOK02154EA.ct_Col_StockSectionCd] = salStcCompMonthYearReportResultWork.StockSectionCd;
                //dr[DCTOK02154EA.ct_Col_SectionGuideNm] = salStcCompMonthYearReportResultWork.SectionGuideNm;
                //dr[DCTOK02154EA.ct_Col_CustomerCode] = salStcCompMonthYearReportResultWork.CustomerCode;
                //dr[DCTOK02154EA.ct_Col_CustomerSnm] = salStcCompMonthYearReportResultWork.CustomerSnm;
                //dr[DCTOK02154EA.ct_Col_StockSalesMoney] = salStcCompMonthYearReportResultWork.StockSalesMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_OrderSalesMoney] = salStcCompMonthYearReportResultWork.OrderSalesMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_SalesMoney] = salStcCompMonthYearReportResultWork.SalesMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_GrossMoney] = salStcCompMonthYearReportResultWork.GrossMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_GrossMarginRate] = salStcCompMonthYearReportResultWork.GrossMarginRate;
                //dr[DCTOK02154EA.ct_Col_CostMoney] = salStcCompMonthYearReportResultWork.CostMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_StockStockMoney] = salStcCompMonthYearReportResultWork.StockStockMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_OrderStockMoney] = salStcCompMonthYearReportResultWork.OrderStockMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_StockMoney] = salStcCompMonthYearReportResultWork.StockMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_Difference] = salStcCompMonthYearReportResultWork.Difference / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalStockSalesMoney] = salStcCompMonthYearReportResultWork.TotalStockSalesMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalOrderSalesMoney] = salStcCompMonthYearReportResultWork.TotalOrderSalesMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalSalesMoney] = salStcCompMonthYearReportResultWork.TotalSalesMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalGrossMoney] = salStcCompMonthYearReportResultWork.TotalGrossMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalGrossMarginRate] = salStcCompMonthYearReportResultWork.TotalGrossMarginRate;
                //dr[DCTOK02154EA.ct_Col_TotalCostMoney] = salStcCompMonthYearReportResultWork.TotalCostMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalStockStockMoney] = salStcCompMonthYearReportResultWork.TotalStockStockMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalOrderStockMoney] = salStcCompMonthYearReportResultWork.TotalOrderStockMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalStockMoney] = salStcCompMonthYearReportResultWork.TotalStockMoney / moneyUnit;
                //dr[DCTOK02154EA.ct_Col_TotalDifference] = salStcCompMonthYearReportResultWork.TotalDifference / moneyUnit;
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- ADD 2008/12/09 -------------------------------->>>>>
                dr[DCTOK02154EA.ct_Col_SectionCd] = salesSlipYearContrastResultWork.AddUpSecCode; // 拠点
                dr[DCTOK02154EA.ct_Col_SectionGuideNm] = salesSlipYearContrastResultWork.SectionGuideSnm;
                dr[DCTOK02154EA.ct_Col_SupplierCode] = salesSlipYearContrastResultWork.SupplierCd; // 仕入先
                dr[DCTOK02154EA.ct_Col_SupplierSnm] = salesSlipYearContrastResultWork.SupplierSnm;
                // 当月
                dr[DCTOK02154EA.ct_Col_StockSalesMoney] = salesSlipYearContrastResultWork.SalesMoneyStock; // 売上金額(在庫)
                dr[DCTOK02154EA.ct_Col_SalesMoney] = salesSlipYearContrastResultWork.SalesMoney; // 売上金額(合計)
                dr[DCTOK02154EA.ct_Col_GrossMoney] = salesSlipYearContrastResultWork.GrossProfit; // 粗利金額
                dr[DCTOK02154EA.ct_Col_MoveShipmentPrice] = salesSlipYearContrastResultWork.MoveShipmentPrice; // 移動出荷額
                dr[DCTOK02154EA.ct_Col_StockStockMoney] = salesSlipYearContrastResultWork.StockTotalPriceStock; // 仕入金額(在庫)
                dr[DCTOK02154EA.ct_Col_StockMoney] = salesSlipYearContrastResultWork.StockTotalPrice; // 仕入金額(合計)
                dr[DCTOK02154EA.ct_Col_MoveArrivalPrice] = salesSlipYearContrastResultWork.MoveArrivalPrice; // 移動入荷額
                // 累計                
                dr[DCTOK02154EA.ct_Col_TotalStockSalesMoney] = salesSlipYearContrastResultWork.AnnualSalesMoneyStock; // 累計売上金額(在庫)
                dr[DCTOK02154EA.ct_Col_TotalSalesMoney] = salesSlipYearContrastResultWork.AnnualSalesMoney; // 累計売上金額(合計)
                dr[DCTOK02154EA.ct_Col_TotalGrossMoney] = salesSlipYearContrastResultWork.AnnualGrossProfit; // 累計粗利金額
                dr[DCTOK02154EA.ct_Col_TotalMoveShipmentPrice] = salesSlipYearContrastResultWork.AnnualMoveShipmentPrice; // 累計移動出荷額
                dr[DCTOK02154EA.ct_Col_TotalStockStockMoney] = salesSlipYearContrastResultWork.AnnualStockTotalPriceStock; // 累計仕入金額(在庫)
                dr[DCTOK02154EA.ct_Col_TotalStockMoney] = salesSlipYearContrastResultWork.AnnualStockTotalPrice; // 累計仕入金額(合計)
                dr[DCTOK02154EA.ct_Col_TotalMoveArrivalPrice] = salesSlipYearContrastResultWork.AnnualMoveArrivalPrice; // 累計移動入荷額
                // --- ADD 2008/12/09 --------------------------------<<<<<

                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////月売上合計（税抜き）
                //Int64 termSalesTotalTaxExc = salStcCompMonthYearReportResultWork.SalesMoney / moneyUnit;
                ////年売上合計（税抜き）
                //Int64 monthSalesTotalTaxExc = salStcCompMonthYearReportResultWork.TotalSalesMoney / moneyUnit;
                ////月仕入合計（税抜き）
                //Int64 termStockTotalTaxExc = salStcCompMonthYearReportResultWork.StockMoney / moneyUnit;
                ////年仕入合計（税抜き）
                //Int64 monthStockTotalTaxExc = salStcCompMonthYearReportResultWork.TotalStockMoney / moneyUnit;

                ////月売上対比
                //dr[DCTOK02154EA.ct_Col_TermSalesComp] = termSalesTotalTaxExc;
                ////年売上対比
                //dr[DCTOK02154EA.ct_Col_MonthSalesComp] = monthSalesTotalTaxExc;
                ////月仕入対比
                //dr[DCTOK02154EA.ct_Col_TermStockComp] = termStockTotalTaxExc;
                ////年仕入対比
                //dr[DCTOK02154EA.ct_Col_MonthStockComp] = monthStockTotalTaxExc;
                // --- DEL 2008/12/09 --------------------------------<<<<<

                // --- ADD 2008/12/09 -------------------------------->>>>>
                // 売上金額(取寄) (合計 - 在庫)
                dr[DCTOK02154EA.ct_Col_OrderSalesMoney] 
                    = salesSlipYearContrastResultWork.SalesMoney - salesSlipYearContrastResultWork.SalesMoneyStock;
                // 原価金額 (合計 - 粗利)
                dr[DCTOK02154EA.ct_Col_CostMoney]
                    = salesSlipYearContrastResultWork.SalesMoney - salesSlipYearContrastResultWork.GrossProfit;
                // 粗利率 (粗利 ÷ 合計 × 100)
                dr[DCTOK02154EA.ct_Col_GrossMarginRate]
                    = this.GetRatio(salesSlipYearContrastResultWork.GrossProfit, salesSlipYearContrastResultWork.SalesMoney);
                
                // 仕入金額(取寄) (合計 - 在庫)
                dr[DCTOK02154EA.ct_Col_OrderStockMoney] 
                    = salesSlipYearContrastResultWork.StockTotalPrice - salesSlipYearContrastResultWork.StockTotalPriceStock;
                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// 対比(売上) (売上合計)
                //dr[DCTOK02154EA.ct_Col_TermSalesComp] = salesSlipYearContrastResultWork.SalesMoney;
                //// 対比(仕入) (仕入合計)
                //dr[DCTOK02154EA.ct_Col_TermStockComp] = salesSlipYearContrastResultWork.StockTotalPrice;
                //// 対比(差額)　(売上合計 -　仕入合計)
                //dr[DCTOK02154EA.ct_Col_Difference] 
                //    = salesSlipYearContrastResultWork.SalesMoney - salesSlipYearContrastResultWork.StockTotalPrice;
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // --- ADD 2009/01/08 -------------------------------->>>>>
                // 対比(売上) (売上合計 + 移動出荷額)
                dr[DCTOK02154EA.ct_Col_TermSalesComp] = salesSlipYearContrastResultWork.SalesMoney + salesSlipYearContrastResultWork.MoveShipmentPrice;
                // 対比(仕入) (仕入合計 + 移動入荷額)
                dr[DCTOK02154EA.ct_Col_TermStockComp] = salesSlipYearContrastResultWork.StockTotalPrice + salesSlipYearContrastResultWork.MoveArrivalPrice;
                // 対比(差額) (対比(売上) -　対比(仕入))
                dr[DCTOK02154EA.ct_Col_Difference]
                    = (salesSlipYearContrastResultWork.SalesMoney + salesSlipYearContrastResultWork.MoveShipmentPrice)
                    - (salesSlipYearContrastResultWork.StockTotalPrice + salesSlipYearContrastResultWork.MoveArrivalPrice);
                // --- ADD 2009/01/08 --------------------------------<<<<<
                
                // 売上金額(合計) 金額適用なし(計部粗利率計算用)
                dr[DCTOK02154EA.ct_Col_SalesMoneyOrg] = salesSlipYearContrastResultWork.SalesMoney;
                // 粗利金額(合計) 金額適用なし(計部粗利率計算用)
                dr[DCTOK02154EA.ct_Col_GrossMoneyOrg] = salesSlipYearContrastResultWork.GrossProfit;


                // 累計売上金額(取寄) (合計 - 在庫)
                dr[DCTOK02154EA.ct_Col_TotalOrderSalesMoney]
                    = salesSlipYearContrastResultWork.AnnualSalesMoney - salesSlipYearContrastResultWork.AnnualSalesMoneyStock;
                // 累計原価金額 (合計 - 粗利)
                dr[DCTOK02154EA.ct_Col_TotalCostMoney]
                    = salesSlipYearContrastResultWork.AnnualSalesMoney - salesSlipYearContrastResultWork.AnnualGrossProfit;
                // 累計粗利率 (粗利 ÷ 合計 × 100)
                dr[DCTOK02154EA.ct_Col_TotalGrossMarginRate] 
                    = this.GetRatio(salesSlipYearContrastResultWork.AnnualGrossProfit, salesSlipYearContrastResultWork.AnnualSalesMoney);

                // 累計仕入金額(取寄) (合計 - 在庫)
                dr[DCTOK02154EA.ct_Col_TotalOrderStockMoney]
                    = salesSlipYearContrastResultWork.AnnualStockTotalPrice - salesSlipYearContrastResultWork.AnnualStockTotalPriceStock;
                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// 累計対比(売上) (売上合計)
                //dr[DCTOK02154EA.ct_Col_YearSalesComp] = salesSlipYearContrastResultWork.AnnualSalesMoney;
                //// 累計対比(仕入) (仕入合計)
                //dr[DCTOK02154EA.ct_Col_YearStockComp] = salesSlipYearContrastResultWork.AnnualStockTotalPrice;
                //// 累計対比(差額)　(売上合計 -　仕入合計)
                //dr[DCTOK02154EA.ct_Col_TotalDifference] 
                //    = salesSlipYearContrastResultWork.AnnualSalesMoney - salesSlipYearContrastResultWork.AnnualStockTotalPrice;
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // --- ADD 2009/01/08 -------------------------------->>>>>
                // 累計対比(売上) (売上合計 + 移動出荷額)
                dr[DCTOK02154EA.ct_Col_YearSalesComp] = salesSlipYearContrastResultWork.AnnualSalesMoney + salesSlipYearContrastResultWork.AnnualMoveShipmentPrice;
                // 累計対比(仕入) (仕入合計 + 移動入荷額)
                dr[DCTOK02154EA.ct_Col_YearStockComp] = salesSlipYearContrastResultWork.AnnualStockTotalPrice + salesSlipYearContrastResultWork.AnnualMoveArrivalPrice;
                // 累計対比(差額) (対比(売上) -　対比(仕入))
                dr[DCTOK02154EA.ct_Col_TotalDifference]
                    = (salesSlipYearContrastResultWork.AnnualSalesMoney + salesSlipYearContrastResultWork.AnnualMoveShipmentPrice)
                    - (salesSlipYearContrastResultWork.AnnualStockTotalPrice + salesSlipYearContrastResultWork.AnnualMoveArrivalPrice);
                // --- ADD 2009/01/08 --------------------------------<<<<<

                // 累計売上金額(合計) 金額適用なし(計部粗利率計算用)
                dr[DCTOK02154EA.ct_Col_TotalSalesMoneyOrg] = salesSlipYearContrastResultWork.AnnualSalesMoney;
                // 累計粗利金額(合計) 金額適用なし(計部粗利率計算用)
                dr[DCTOK02154EA.ct_Col_TotalGrossMoneyOrg] = salesSlipYearContrastResultWork.AnnualGrossProfit;
                // --- ADD 2008/12/09 --------------------------------<<<<<

                // --- DEL 2008/12/09 -------------------------------->>>>>
                //拠点別の集計
                //string sectionHeaderField = "";
                //sectionHeaderField = salStcCompMonthYearReportResultWork.StockSectionCd;

                ////0:拠点別 1:仕入先別
                //switch (salStcCompMonthYearReport.PrintType)
                //{
                //    //0:拠点別
                //    case 0:
                //        dr[DCTOK02154EA.ct_Col_SectionHeaderField] = salStcCompMonthYearReportResultWork.StockSectionCd;
                //        dr[DCTOK02154EA.ct_Col_DailyHeaderField] = "";

                //        dr[DCTOK02154EA.ct_Col_SectionHeaderLine] = salStcCompMonthYearReportResultWork.StockSectionCd;
                //        dr[DCTOK02154EA.ct_Col_SectionHeaderLineName] = salStcCompMonthYearReportResultWork.SectionGuideNm;

                //        dr[DCTOK02154EA.ct_Col_DetailLine] = salStcCompMonthYearReportResultWork.CustomerCode.ToString("d9");
                //        dr[DCTOK02154EA.ct_Col_DetailLineName] = salStcCompMonthYearReportResultWork.CustomerSnm;
                //        break;
                //    //1:仕入先別
                //    case 1:
                //        dr[DCTOK02154EA.ct_Col_SectionHeaderField] = salStcCompMonthYearReportResultWork.CustomerCode;
                //        dr[DCTOK02154EA.ct_Col_DailyHeaderField] = "";

                //        dr[DCTOK02154EA.ct_Col_SectionHeaderLine] = salStcCompMonthYearReportResultWork.CustomerCode.ToString("d9");
                //        dr[DCTOK02154EA.ct_Col_SectionHeaderLineName] = salStcCompMonthYearReportResultWork.CustomerSnm;
                //        dr[DCTOK02154EA.ct_Col_DetailLine] = salStcCompMonthYearReportResultWork.StockSectionCd;
                //        dr[DCTOK02154EA.ct_Col_DetailLineName] = salStcCompMonthYearReportResultWork.SectionGuideNm;
                //        break;
                //}
                // --- DEL 2008/12/09 --------------------------------<<<<<

                //0:拠点別 1:仕入先別
                switch (salStcCompMonthYearReport.PrintType)
                {
                    //0:拠点別
                    case 0:
                        dr[DCTOK02154EA.ct_Col_SectionHeaderField] = salesSlipYearContrastResultWork.AddUpSecCode;
                        dr[DCTOK02154EA.ct_Col_DailyHeaderField] = "";

                        dr[DCTOK02154EA.ct_Col_SectionHeaderLine] = salesSlipYearContrastResultWork.AddUpSecCode;
                        dr[DCTOK02154EA.ct_Col_SectionHeaderLineName] = salesSlipYearContrastResultWork.SectionGuideSnm;

                        dr[DCTOK02154EA.ct_Col_DetailLine] = salesSlipYearContrastResultWork.SupplierCd.ToString("d6");
                        dr[DCTOK02154EA.ct_Col_DetailLineName] = salesSlipYearContrastResultWork.SupplierSnm;
                        break;
                    //1:仕入先別
                    case 1:
                        dr[DCTOK02154EA.ct_Col_SectionHeaderField] = salesSlipYearContrastResultWork.SupplierCd;
                        dr[DCTOK02154EA.ct_Col_DailyHeaderField] = "";

                        dr[DCTOK02154EA.ct_Col_SectionHeaderLine] = salesSlipYearContrastResultWork.SupplierCd.ToString("d6");
                        dr[DCTOK02154EA.ct_Col_SectionHeaderLineName] = salesSlipYearContrastResultWork.SupplierSnm;
                        dr[DCTOK02154EA.ct_Col_DetailLine] = salesSlipYearContrastResultWork.AddUpSecCode;
                        dr[DCTOK02154EA.ct_Col_DetailLineName] = salesSlipYearContrastResultWork.SectionGuideSnm;
                        break;
                }

                #endregion

                // 金額単位の適用
                //this.SetMoneyUnit(salStcCompMonthYearReport, ref dr);     // DEL 2009/04/13

				// TableにAdd
				this._salStcCompMonthYearReportDt.Rows.Add( dr );
			}

			// DataView作成
			this._salStcCompMonthYearReportView = new DataView( this._salStcCompMonthYearReportDt, "", GetSortOrder(salStcCompMonthYearReport), DataViewRowState.CurrentRows );
		}
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( SalStcCompMonthYearReport salStcCompMonthYearReport )
		{
			StringBuilder strSortOrder = new StringBuilder();

            // --- ADD 2008/12/09 -------------------------------->>>>>
            if (salStcCompMonthYearReport.PrintType == 0) // 拠点別
            {
                strSortOrder.Append(DCTOK02154EA.ct_Col_SectionCd);
                strSortOrder.Append(", ");
                strSortOrder.Append(DCTOK02154EA.ct_Col_SupplierCode);
            }
            else // 仕入先別
            {
                strSortOrder.Append(DCTOK02154EA.ct_Col_SupplierCode);
                strSortOrder.Append(", ");
                strSortOrder.Append(DCTOK02154EA.ct_Col_SectionCd);
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<

#if False
			//集計方法が営業所毎で集計単位が0:拠点別の場合
			strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SectionCode));

			//0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
			switch (salStcCompMonthYearReport.PrintType)
			{
				//0:拠点別
				case 0:
					break;
				//1:部署別
				case 1:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SubSectionCode));
					break;
				//2:課別
				case 2:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SubSectionCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_MinSectionCode));
					break;
				//3:地区別
				case 3:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SalesAreaCode));
					break;
				//4:業種別
				case 4:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_BusinessTypeCode));
					break;
				//5:担当者別
				case 5:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SalesEmployeeCd));
					break;
				//6:受注者別
				case 6:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_FrontEmployeeNm));
					break;
				//7:発行者別
				case 7:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SalesInputCode));
					break;
				//8:得意先別
				case 8:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_CustomerCode));
					break;
				//9:地区別得意先別
				case 9:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SalesAreaCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_CustomerCode));
					break;
				//10:業種別得意先別意
				case 10:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_BusinessTypeCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_CustomerCode));
					break;
				// 11:担当者別得意先別
				case 11:
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_SalesEmployeeCd));
					strSortOrder.Append(string.Format("{0},", DCTOK02154EA.ct_Col_CustomerCode));
					break;
			}
#endif

			return strSortOrder.ToString();
		}
		#endregion

        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(Int64 numerator, Int64 denominator)
        {
            double workRate;
            double numeratorDb = Convert.ToDouble(numerator);
            double denominatorDb = Convert.ToDouble(denominator);

            if (denominatorDb == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numeratorDb / denominatorDb) * 100;
            }

            return workRate;
        }

        /// <summary>
        /// 金額単位適用処理
        /// </summary>
        /// <param name="salStcCompMonthYearReport"></param>
        /// <param name="dr"></param>
        private void SetMoneyUnit(SalStcCompMonthYearReport salStcCompMonthYearReport, ref DataRow dr)
        {
            if (salStcCompMonthYearReport.MoneyUnit == 0) // 円単位
            {
                // 処理なし
                return;
            }

            int moneyUnit = 1000;

            // 各種金額項目を丸める (金額 / 金額単位)
            dr[DCTOK02154EA.ct_Col_SalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_SalesMoney]) / (decimal)moneyUnit); ; // 売上金額(合計)
            dr[DCTOK02154EA.ct_Col_OrderSalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_OrderSalesMoney]) / (decimal)moneyUnit); // 売上金額(取寄)
            dr[DCTOK02154EA.ct_Col_StockSalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_StockSalesMoney]) / (decimal) moneyUnit); // 売上金額(在庫)
            dr[DCTOK02154EA.ct_Col_GrossMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_GrossMoney]) / (decimal)moneyUnit); // 粗利金額
            dr[DCTOK02154EA.ct_Col_MoveShipmentPrice] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_MoveShipmentPrice]) / (decimal)moneyUnit); // 移動出荷額
            dr[DCTOK02154EA.ct_Col_CostMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_CostMoney]) / (decimal)moneyUnit); // 原価金額

            dr[DCTOK02154EA.ct_Col_StockMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_StockMoney]) / (decimal)moneyUnit); // 仕入金額(合計)
            dr[DCTOK02154EA.ct_Col_OrderStockMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_OrderStockMoney]) / (decimal)moneyUnit); // 仕入金額(取寄)
            dr[DCTOK02154EA.ct_Col_StockStockMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_StockStockMoney]) / (decimal)moneyUnit); // 仕入金額(在庫)
            dr[DCTOK02154EA.ct_Col_MoveArrivalPrice] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_MoveArrivalPrice]) / (decimal)moneyUnit); // 移動入荷額

            dr[DCTOK02154EA.ct_Col_TermSalesComp] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TermSalesComp]) / (decimal)moneyUnit); // 対比(売上) (売上合計)
            dr[DCTOK02154EA.ct_Col_TermStockComp] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TermStockComp]) / (decimal)moneyUnit); // 対比(仕入) (仕入合計)
            dr[DCTOK02154EA.ct_Col_Difference] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_Difference]) / (decimal)moneyUnit); // 対比(差額)

            // 以下累計項目
            dr[DCTOK02154EA.ct_Col_TotalSalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalSalesMoney]) / (decimal)moneyUnit); ; // 累計売上金額(合計)
            dr[DCTOK02154EA.ct_Col_TotalOrderSalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalOrderSalesMoney]) / (decimal)moneyUnit); // 累計売上金額(取寄)
            dr[DCTOK02154EA.ct_Col_TotalStockSalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalStockSalesMoney]) / (decimal)moneyUnit); // 累計売上金額(在庫)
            dr[DCTOK02154EA.ct_Col_TotalGrossMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalGrossMoney]) / (decimal)moneyUnit); // 累計粗利金額
            dr[DCTOK02154EA.ct_Col_TotalMoveShipmentPrice] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalMoveShipmentPrice]) / (decimal)moneyUnit); // 累計移動出荷額
            dr[DCTOK02154EA.ct_Col_TotalCostMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalCostMoney]) / (decimal)moneyUnit); // 累計原価金額

            dr[DCTOK02154EA.ct_Col_TotalStockMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalStockMoney]) / (decimal)moneyUnit); // 累計仕入金額(合計)
            dr[DCTOK02154EA.ct_Col_TotalOrderStockMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalOrderStockMoney]) / (decimal)moneyUnit); // 累計仕入金額(取寄)
            dr[DCTOK02154EA.ct_Col_TotalStockStockMoney] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalStockStockMoney]) / (decimal)moneyUnit); // 累計仕入金額(在庫)
            dr[DCTOK02154EA.ct_Col_TotalMoveArrivalPrice] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalMoveArrivalPrice]) / (decimal)moneyUnit); // 累計移動入荷額

            dr[DCTOK02154EA.ct_Col_YearSalesComp] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_YearSalesComp]) / (decimal)moneyUnit); // 累計対比(売上) (売上合計)
            dr[DCTOK02154EA.ct_Col_YearStockComp] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_YearStockComp]) / (decimal)moneyUnit); // 累計対比(仕入) (仕入合計)
            dr[DCTOK02154EA.ct_Col_TotalDifference] = (Int64)((decimal)((Int64)dr[DCTOK02154EA.ct_Col_TotalDifference]) / (decimal)moneyUnit); // 累計対比(差額)
        }
        // --- ADD 2008/12/09 --------------------------------<<<<<

		#endregion ◆ データ展開処理

		#region ◆ 帳票設定データ取得
		#region ◎ 帳票出力設定取得処理
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 96186 kubo</br>
		/// <br>Date       : 2007.09.03</br>
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
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();		// 2007.06.27 kubo add
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "帳票出力設定の読込に失敗しました";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票設定データ取得
		#endregion ■ Private Method

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            SalesSlipYearContrastResultWork param1 = new SalesSlipYearContrastResultWork();

            param1.AddUpSecCode = "99"; // 拠点
            param1.SectionGuideSnm = "拠点名最大１０桁です";
            param1.SupplierCd = 999999; // 仕入先
            param1.SupplierSnm = "仕入名最大１０桁です";
            // 日計
            param1.SalesMoney = 888888888; // 売上金額(合計)
            param1.SalesMoneyStock = 222222222; // 売上金額(在庫)
            param1.GrossProfit = 111111111; // 粗利金額計
            param1.MoveShipmentPrice = 111111111; // 移動出荷額

            param1.StockTotalPrice = 333333333; // 仕入金額(合計)
            param1.StockTotalPriceStock = 111111111; // 仕入金額(在庫)
            param1.MoveArrivalPrice = 222222222; // 移動入荷額

            // 累計
            param1.AnnualSalesMoney = 88888888; // 売上金額(合計)
            param1.AnnualSalesMoneyStock = 22222222; // 売上金額(在庫)
            param1.AnnualGrossProfit = 11111111; // 粗利金額計
            param1.AnnualMoveShipmentPrice = 11111111; // 移動出荷額

            param1.AnnualStockTotalPrice = 33333333; // 仕入金額(合計)
            param1.AnnualStockTotalPriceStock = 11111111; // 仕入金額(在庫)
            param1.AnnualMoveArrivalPrice = 22222222; // 移動入荷額

            paramlist.Add(param1);

            SalesSlipYearContrastResultWork param2 = new SalesSlipYearContrastResultWork();

            param2.AddUpSecCode = ""; // 拠点
            param2.SectionGuideSnm = "";
            param2.SupplierCd = 0; // 仕入先
            param2.SupplierSnm = "";
            // 日計
            param2.SalesMoney = 0; // 売上金額(合計)
            param2.SalesMoneyStock = 0; // 売上金額(在庫)
            param2.GrossProfit = 0; // 粗利金額計
            param2.MoveShipmentPrice = 0; // 移動出荷額

            param2.StockTotalPrice = 0; // 仕入金額(合計)
            param2.StockTotalPriceStock = 0; // 仕入金額(在庫)
            param2.MoveArrivalPrice = 0; // 移動入荷額

            // 累計
            param2.AnnualSalesMoney = 0; // 売上金額(合計)
            param2.AnnualSalesMoneyStock = 0; // 売上金額(在庫)
            param2.AnnualGrossProfit = 0; // 粗利金額計
            param2.AnnualMoveShipmentPrice = 0; // 移動出荷額

            param2.AnnualStockTotalPrice = 0; // 仕入金額(合計)
            param2.AnnualStockTotalPriceStock = 0; // 仕入金額(在庫)
            param2.AnnualMoveArrivalPrice = 0; // 移動入荷額

            paramlist.Add(param2);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
	}
}
