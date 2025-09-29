//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：出荷商品分析表
// プログラム概要   ：出荷商品分析表を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/12/09     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2009/01/08     修正内容：障害対応9678
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/03/09     修正内容：障害対応12226
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/15     修正内容：Mantis【13121】残案件No.19 端数処理
// ---------------------------------------------------------------------//

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
    /// <br>            ・障害対応9678</br>
    /// <br>Update Note : 2009.03.09 30414 忍 幸史</br>
    /// <br>            ・障害対応12226</br>
    /// </remarks>
	public class SalStcCompReportAcs
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
		public SalStcCompReportAcs()
		{
            //this._iSalStcCompReportResultDB = (ISalStcCompReportResultDB)MediationSalStcCompReportResultDB.GetSalStcCompReportResultDB(); // DEL 2008/12/09
            this._iSalStcCompReportResultWorkDB = (ISalStcCompReportResultWorkDB)MediationSalStcCompReportResultWorkDB.GetSalStcCompReportResultWorkDB(); // ADD 2008/12/09
		}

		/// <summary>
		/// 売上仕入対比表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上仕入対比表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		static SalStcCompReportAcs()
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
        //ISalStcCompReportResultDB _iSalStcCompReportResultDB; // DEL 2008/12/09
        ISalStcCompReportResultWorkDB _iSalStcCompReportResultWorkDB; // ADD 2008/12/09

		private DataTable _salStcCompReportDt;			// 印刷DataTable
		private DataView _salStcCompReportView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView SalStcCompReportView
		{
			get{ return this._salStcCompReportView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// 入金データ取得
		/// </summary>
		/// <param name="salStcCompReport">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する入金データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public int SearchSalStcCompReportProcMain(SalStcCompReport salStcCompReport, out string errMsg)
		{
			return this.SearchSalStcCompReportProc(salStcCompReport, out errMsg);
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
		/// <param name="salStcCompReport"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private int SearchSalStcCompReportProc(SalStcCompReport salStcCompReport, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCTOK02034EA.CreateDataTable(ref this._salStcCompReportDt);
				
				// 抽出条件展開  --------------------------------------------------------------
				SalStcCompReportParamWork salStcCompReportParamWork = new SalStcCompReportParamWork();
				status = this.DevSalesDayMonthReport(salStcCompReport, out salStcCompReportParamWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object salStcCompReportResultWork = null;
                //status = _iSalStcCompReportResultDB.Search(out salStcCompReportResultWork, salStcCompReportParamWork); // DEL 2008/12/09
                status = _iSalStcCompReportResultWorkDB.Search(out salStcCompReportResultWork, salStcCompReportParamWork, 0, ConstantManagement.LogicalMode.GetData0); // DEL 2008/12/09

                // テストデータ
                //status = testproc(out salStcCompReportResultWork);

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( salStcCompReport, (ArrayList)salStcCompReportResultWork );
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
		/// <param name="salStcCompReport">UI抽出条件クラス</param>
		/// <param name="stockMoveListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
		private int DevSalesDayMonthReport ( SalStcCompReport salStcCompReport, out SalStcCompReportParamWork salStcCompReportParamWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			salStcCompReportParamWork = new SalStcCompReportParamWork();
			try
			{
                // --- DEL 2008/12/09 -------------------------------->>>>>
                //salStcCompReportParamWork.EnterpriseCode = salStcCompReport.EnterpriseCode;
                //salStcCompReportParamWork.SectionCodes = salStcCompReport.SectionCodes;
                //salStcCompReportParamWork.SalesDateSt = salStcCompReport.SalesDateSt;
                //salStcCompReportParamWork.SalesDateEd = salStcCompReport.SalesDateEd;
                //salStcCompReportParamWork.MonthReportDateSt = salStcCompReport.MonthReportDateSt;
                //salStcCompReportParamWork.MonthReportDateEd = salStcCompReport.MonthReportDateEd;
                //salStcCompReportParamWork.SupplierCdSt = salStcCompReport.SupplierCdSt;
                //salStcCompReportParamWork.SupplierCdEd = salStcCompReport.SupplierCdEd;
                //salStcCompReportParamWork.PrintType = salStcCompReport.PrintType;
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- ADD 2008/12/09 -------------------------------->>>>>
                salStcCompReportParamWork.EnterpriseCode = salStcCompReport.EnterpriseCode; // 企業コード
                salStcCompReportParamWork.SectionCode = salStcCompReport.SectionCodes; // 拠点コード
                salStcCompReportParamWork.StReportDate = salStcCompReport.SalesDateSt; // 開始対象日付
                salStcCompReportParamWork.EdReportDate = salStcCompReport.SalesDateEd; // 終了対象日付
                salStcCompReportParamWork.StMonthReportDate = salStcCompReport.MonthReportDateSt; // 累計開始対象日付
                salStcCompReportParamWork.EdMonthReportDate = salStcCompReport.MonthReportDateEd; // 累計終了対象日付
                salStcCompReportParamWork.StSupplierCd = salStcCompReport.SupplierCdSt; // 開始仕入先
                if (salStcCompReport.SupplierCdEd == 0) salStcCompReportParamWork.EdSupplierCd = 999999;
                else salStcCompReportParamWork.EdSupplierCd = salStcCompReport.SupplierCdEd; // 終了仕入先
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
		/// <param name="salStcCompReport">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private void DevStockMoveData ( SalStcCompReport salStcCompReport, ArrayList list )
		{
			DataRow dr;

			foreach ( SalStcCompReportResultWork salStcCompReportResultWork in list )
			{
                // --- DEL 2008/12/09 -------------------------------->>>>>
                //if ((salStcCompReportResultWork.TermSalesByOrderTotalTaxExc == 0)
                //&& (salStcCompReportResultWork.TermSalesByStockTotalTaxExc == 0)
                //&& (salStcCompReportResultWork.TermTotalCost == 0)
                //&& (salStcCompReportResultWork.TermBuyForOrderTotalTaxExc == 0)
                //&& (salStcCompReportResultWork.TermBuyForStockTotalTaxExc == 0)

                //&& (salStcCompReportResultWork.MonthSalesByOrderTotalTaxExc == 0)
                //&& (salStcCompReportResultWork.MonthSalesByStockTotalTaxExc == 0)
                //&& (salStcCompReportResultWork.MonthTotalCost == 0)
                //&& (salStcCompReportResultWork.MonthBuyForOrderTotalTaxExc == 0)
                //&& (salStcCompReportResultWork.MonthBuyForStockTotalTaxExc == 0)
                //)
                //{
                //    continue;
                //}
                // --- DEL 2008/12/09 --------------------------------<<<<<

                dr = this._salStcCompReportDt.NewRow();
                // 取得データ展開
                #region 取得データ展開
                // --- DEL 2008/12/09 -------------------------------->>>>>
                //dr[DCTOK02034EA.ct_Col_SectionCode] = salStcCompReportResultWork.SectionCode;
                //dr[DCTOK02034EA.ct_Col_SectionGuideNm] = salStcCompReportResultWork.SectionGuideNm;
                //dr[DCTOK02034EA.ct_Col_SubSectionCode] = salStcCompReportResultWork.SubSectionCode;
                //dr[DCTOK02034EA.ct_Col_SubSectionName] = salStcCompReportResultWork.SubSectionName;
                //dr[DCTOK02034EA.ct_Col_MinSectionCode] = salStcCompReportResultWork.MinSectionCode;
                //dr[DCTOK02034EA.ct_Col_MinSectionName] = salStcCompReportResultWork.MinSectionName;
                //dr[DCTOK02034EA.ct_Col_SupplierCd] = salStcCompReportResultWork.SupplierCd;
                //dr[DCTOK02034EA.ct_Col_SupplierSnm] = salStcCompReportResultWork.SupplierSnm;
                //dr[DCTOK02034EA.ct_Col_TermSalesByOrderTotalTaxExc] = salStcCompReportResultWork.TermSalesByOrderTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_TermSalesByStockTotalTaxExc] = salStcCompReportResultWork.TermSalesByStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_TermTotalCost] = salStcCompReportResultWork.TermTotalCost;
                //dr[DCTOK02034EA.ct_Col_TermBuyForOrderTotalTaxExc] = salStcCompReportResultWork.TermBuyForOrderTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_TermBuyForStockTotalTaxExc] = salStcCompReportResultWork.TermBuyForStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_MonthSalesByOrderTotalTaxExc] = salStcCompReportResultWork.MonthSalesByOrderTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_MonthSalesByStockTotalTaxExc] = salStcCompReportResultWork.MonthSalesByStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_MonthTotalCost] = salStcCompReportResultWork.MonthTotalCost;
                //dr[DCTOK02034EA.ct_Col_MonthBuyForOrderTotalTaxExc] = salStcCompReportResultWork.MonthBuyForOrderTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_MonthBuyForStockTotalTaxExc] = salStcCompReportResultWork.MonthBuyForStockTotalTaxExc;
                ////dr[DCTOK02034EA.ct_Col_OrderDivCd] = salStcCompReportResultWork.OrderDivCd;
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- ADD 2008/12/09 -------------------------------->>>>>
                dr[DCTOK02034EA.ct_Col_SectionCode] = salStcCompReportResultWork.SecCode; // 拠点コード
                dr[DCTOK02034EA.ct_Col_SectionGuideNm] = salStcCompReportResultWork.SectionGuideSnm; // 拠点ガイド略称
                dr[DCTOK02034EA.ct_Col_SupplierCd] = salStcCompReportResultWork.SupplierCd; // 仕入先コード
                dr[DCTOK02034EA.ct_Col_SupplierSnm] = salStcCompReportResultWork.SupplierSnm; // 仕入先略称
                //dr[DCTOK02034EA.ct_Col_SalesMoney] = salStcCompReportResultWork.SalesMoney; // 売上金額(日計合計) // DEL 2009/01/08
                dr[DCTOK02034EA.ct_Col_SalesMoneyOrder] = salStcCompReportResultWork.SalesMoney; // 売上金額(日計取寄) // ADD 2009/01/08
                dr[DCTOK02034EA.ct_Col_SalesMoneyStock] = salStcCompReportResultWork.SalesMoneyStock; // 売上金額(日計在庫)
                dr[DCTOK02034EA.ct_Col_TotalCost] = salStcCompReportResultWork.TotalCost; // 原価金額計(日計)
                dr[DCTOK02034EA.ct_Col_MoveCountSales] = salStcCompReportResultWork.MoveCountSales; // 移動数(日計売上)
                dr[DCTOK02034EA.ct_Col_StockUnitPriceFlSales] = salStcCompReportResultWork.StockUnitPriceFlSales; // 仕入単価（日計売上）
                //dr[DCTOK02034EA.ct_Col_StockPriceTaxExc] = salStcCompReportResultWork.StockPriceTaxExc; // 仕入金額(日計合計) // DEL 2009/01/08
                dr[DCTOK02034EA.ct_Col_StockPriceTaxExcOrder] = salStcCompReportResultWork.StockPriceTaxExc; // 仕入金額(日計取寄) // ADD 2009/01/08
                dr[DCTOK02034EA.ct_Col_StockPriceTaxExcStock] = salStcCompReportResultWork.StockPriceTaxExcStock; // 仕入金額(日計在庫)
                dr[DCTOK02034EA.ct_Col_MoveCountSalesSlip] = salStcCompReportResultWork.MoveCountSalesSlip; // 移動数(日計仕入)
                dr[DCTOK02034EA.ct_Col_StockUnitPriceFlSalesSlip] = salStcCompReportResultWork.StockUnitPriceFlSalesSlip; // 仕入単価（日計仕入）

                //dr[DCTOK02034EA.ct_Col_MonthSalesMoney] = salStcCompReportResultWork.MonthSalesMoney; // 売上金額(累計合計) // DEL 2009/01/08
                dr[DCTOK02034EA.ct_Col_MonthSalesMoneyOrder] = salStcCompReportResultWork.MonthSalesMoney; // 売上金額(累計取寄) // ADD 2009/01/08
                dr[DCTOK02034EA.ct_Col_MonthSalesMoneyStock] = salStcCompReportResultWork.MonthSalesMoneyStock; // 売上金額(累計在庫)
                dr[DCTOK02034EA.ct_Col_MonthTotalCost] = salStcCompReportResultWork.MonthTotalCost; // 原価金額計(累計)
                dr[DCTOK02034EA.ct_Col_MonthMoveCountSales] = salStcCompReportResultWork.MonthMoveCountSales; // 移動数(累計売上)
                dr[DCTOK02034EA.ct_Col_MonthStockUnitPriceFlSales] = salStcCompReportResultWork.MonthStockUnitPriceFlSales; // 仕入単価（累計売上）
                //dr[DCTOK02034EA.ct_Col_MonthStockPriceTaxExc] = salStcCompReportResultWork.MonthStockPriceTaxExc; // 仕入金額(累計合計) // DEL 2009/01/08
                dr[DCTOK02034EA.ct_Col_MonthStockPriceTaxExcOrder] = salStcCompReportResultWork.MonthStockPriceTaxExc; // 仕入金額(累計取寄) // ADD 2009/01/08
                dr[DCTOK02034EA.ct_Col_MonthStockPriceTaxExcStock] = salStcCompReportResultWork.MonthStockPriceTaxExcStock; // 仕入金額(累計在庫)
                dr[DCTOK02034EA.ct_Col_MonthMoveCountSalesSlip] = salStcCompReportResultWork.MonthMoveCountSalesSlip; // 移動数(累計仕入)
                dr[DCTOK02034EA.ct_Col_MonthStockUnitPriceFlSalesSlip] = salStcCompReportResultWork.MonthStockUnitPriceFlSalesSlip; // 仕入単価（累計仕入）
                // --- ADD 2008/12/09 --------------------------------<<<<<

                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////期間売上合計（税抜き）
                //Int64 termSalesTotalTaxExc = salStcCompReportResultWork.TermSalesByOrderTotalTaxExc
                //                     + salStcCompReportResultWork.TermSalesByStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_TermSalesTotalTaxExc] = termSalesTotalTaxExc;

                ////月次売上合計（税抜き）
                //Int64 monthSalesTotalTaxExc = salStcCompReportResultWork.MonthSalesByOrderTotalTaxExc
                //                        + salStcCompReportResultWork.MonthSalesByStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_MonthSalesTotalTaxExc] = monthSalesTotalTaxExc;
                ////期間粗利益
                //Int64 termProfit = salStcCompReportResultWork.TermSalesByOrderTotalTaxExc
                //        + salStcCompReportResultWork.TermSalesByStockTotalTaxExc
                //        - salStcCompReportResultWork.TermTotalCost;
                //dr[DCTOK02034EA.ct_Col_TermProfit] = termProfit;

                ////月次粗利益
                //Int64 monthProfit = salStcCompReportResultWork.MonthSalesByOrderTotalTaxExc
                //        + salStcCompReportResultWork.MonthSalesByStockTotalTaxExc
                //        - salStcCompReportResultWork.MonthTotalCost;
                //dr[DCTOK02034EA.ct_Col_MonthProfit] = monthProfit;

                ////期間粗利率
                //if (termSalesTotalTaxExc == 0)
                //{
                //    dr[DCTOK02034EA.ct_Col_TermProfitRate] = 0;
                //}
                //else
                //{
                //    dr[DCTOK02034EA.ct_Col_TermProfitRate] = (double)termProfit * 100 / (double)termSalesTotalTaxExc;
                //}

                ////月次粗利率
                //if (monthSalesTotalTaxExc == 0)
                //{
                //    dr[DCTOK02034EA.ct_Col_MonthProfitRate] = 0;
                //}
                //else
                //{
                //    dr[DCTOK02034EA.ct_Col_MonthProfitRate] = (double)monthProfit * 100 / (double)monthSalesTotalTaxExc;
                //}

                ////期間仕入合計（税抜き）
                //Int64 termStockTotalTaxExc = salStcCompReportResultWork.TermBuyForOrderTotalTaxExc
                //                         + salStcCompReportResultWork.TermBuyForStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_TermStockTotalTaxExc] = termStockTotalTaxExc;

                ////月次仕入合計（税抜き）
                //Int64 monthStockTotalTaxExc = salStcCompReportResultWork.MonthBuyForOrderTotalTaxExc
                //                    + salStcCompReportResultWork.MonthBuyForStockTotalTaxExc;
                //dr[DCTOK02034EA.ct_Col_MonthStockTotalTaxExc] = monthStockTotalTaxExc;
                // --- DEL 2008/12/09 --------------------------------<<<<<

                // --- ADD 2008/12/09 -------------------------------->>>>>
                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// 売上金額(日計取寄) (合計 - 在庫)
                //dr[DCTOK02034EA.ct_Col_SalesMoneyOrder] 
                //    = salStcCompReportResultWork.SalesMoney - salStcCompReportResultWork.SalesMoneyStock;
                //// 粗利金額(日計)　(合計 - 原価)
                //dr[DCTOK02034EA.ct_Col_GrossProfit]
                //    = salStcCompReportResultWork.SalesMoney - salStcCompReportResultWork.TotalCost;
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // --- ADD 2009/01/08 -------------------------------->>>>>
                // 売上金額(日計合計) (取寄 + 在庫)
                dr[DCTOK02034EA.ct_Col_SalesMoney]
                    = salStcCompReportResultWork.SalesMoney + salStcCompReportResultWork.SalesMoneyStock;
                // 粗利金額(日計)　(合計 - 原価)
                dr[DCTOK02034EA.ct_Col_GrossProfit]
                    = salStcCompReportResultWork.SalesMoney + salStcCompReportResultWork.SalesMoneyStock - salStcCompReportResultWork.TotalCost;
                // --- ADD 2009/01/08 --------------------------------<<<<<

                // 移動出庫(日計売上) (移動数×仕入単価)
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------>>>>>
                //dr[DCTOK02034EA.ct_Col_MoveMoney] 
                //    = salStcCompReportResultWork.MoveCountSales * salStcCompReportResultWork.StockUnitPriceFlSales;
                dr[DCTOK02034EA.ct_Col_MoveMoney] = salStcCompReportResultWork.StockMovePriceSales;
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------<<<<<

                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// 仕入金額(日計取寄) (合計 - 在庫)
                //dr[DCTOK02034EA.ct_Col_StockPriceTaxExcOrder] 
                //    = salStcCompReportResultWork.StockPriceTaxExc - salStcCompReportResultWork.StockPriceTaxExcStock;
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // --- ADD 2009/01/08 -------------------------------->>>>>
                // 仕入金額(日計合計) (取寄 + 在庫)
                dr[DCTOK02034EA.ct_Col_StockPriceTaxExc]
                    = salStcCompReportResultWork.StockPriceTaxExc + salStcCompReportResultWork.StockPriceTaxExcStock;
                // --- ADD 2009/01/08 --------------------------------<<<<<
                
                // 移動入庫(日計仕入) (移動数×仕入単価)
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------>>>>>
                //dr[DCTOK02034EA.ct_Col_StockMoveMoney] 
                //    = salStcCompReportResultWork.MoveCountSalesSlip * salStcCompReportResultWork.StockUnitPriceFlSalesSlip;
                dr[DCTOK02034EA.ct_Col_StockMoveMoney] = salStcCompReportResultWork.StockMovePriceSlip;
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------<<<<<

                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// 売上金額(累計取寄) (合計 - 在庫)
                //dr[DCTOK02034EA.ct_Col_MonthSalesMoneyOrder] 
                //    = salStcCompReportResultWork.MonthSalesMoney - salStcCompReportResultWork.MonthSalesMoneyStock;
                //// 粗利金額(累計) (合計 - 原価)
                //dr[DCTOK02034EA.ct_Col_MonthGrossProfit]
                //    = salStcCompReportResultWork.MonthSalesMoney - salStcCompReportResultWork.MonthTotalCost;
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // --- ADD 2009/01/08 -------------------------------->>>>>
                // 売上金額(累計合計) (取寄 + 在庫)
                dr[DCTOK02034EA.ct_Col_MonthSalesMoney]
                    = salStcCompReportResultWork.MonthSalesMoney + salStcCompReportResultWork.MonthSalesMoneyStock;
                // 粗利金額(累計) (合計 - 原価)
                dr[DCTOK02034EA.ct_Col_MonthGrossProfit]
                    = salStcCompReportResultWork.MonthSalesMoney + salStcCompReportResultWork.MonthSalesMoneyStock - salStcCompReportResultWork.MonthTotalCost;
                // --- ADD 2009/01/08 --------------------------------<<<<<
                
                // 移動出庫(累計売上) (移動数×仕入単価)
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------>>>>>
                //dr[DCTOK02034EA.ct_Col_MonthMoveMoney]
                //    = salStcCompReportResultWork.MonthMoveCountSales * salStcCompReportResultWork.MonthStockUnitPriceFlSales;
                dr[DCTOK02034EA.ct_Col_MonthMoveMoney] = salStcCompReportResultWork.MonthStockMovePriceSales;
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------<<<<<

                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// 仕入金額(累計取寄) (合計 - 在庫)
                //dr[DCTOK02034EA.ct_Col_MonthStockPriceTaxExcOrder] 
                //    = salStcCompReportResultWork.MonthStockPriceTaxExc - salStcCompReportResultWork.MonthStockPriceTaxExcStock;
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // --- ADD 2009/01/08 -------------------------------->>>>>
                // 仕入金額(累計合計) (取寄 + 在庫)
                dr[DCTOK02034EA.ct_Col_MonthStockPriceTaxExc]
                    = salStcCompReportResultWork.MonthStockPriceTaxExc + salStcCompReportResultWork.MonthStockPriceTaxExcStock;
                // --- ADD 2009/01/08 --------------------------------<<<<<
                
                // 移動入庫(累計仕入) (移動数×仕入単価)
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------>>>>>
                //dr[DCTOK02034EA.ct_Col_MonthStockMoveMoney]
                //    = salStcCompReportResultWork.MonthMoveCountSalesSlip * salStcCompReportResultWork.MonthStockUnitPriceFlSalesSlip;
                dr[DCTOK02034EA.ct_Col_MonthStockMoveMoney] = salStcCompReportResultWork.MonthStockMovePriceSlip;
                // --- CHG 2009/03/09 障害ID:12226対応------------------------------------------------------<<<<<
                
                // --- ADD 2008/12/09 --------------------------------<<<<<

                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////期間売上対比
                //dr[DCTOK02034EA.ct_Col_TermSalesComp] = termSalesTotalTaxExc;
                ////月次売上対比
                //dr[DCTOK02034EA.ct_Col_MonthSalesComp] = monthSalesTotalTaxExc;
                ////期間仕入対比
                //dr[DCTOK02034EA.ct_Col_TermStockComp] = termStockTotalTaxExc;
                ////月次仕入対比
                //dr[DCTOK02034EA.ct_Col_MonthStockComp] = monthStockTotalTaxExc;
                ////期間差額
                //dr[DCTOK02034EA.ct_Col_TermBalance] = termSalesTotalTaxExc - termStockTotalTaxExc;
                ////月次差額
                //dr[DCTOK02034EA.ct_Col_MonthBalance] = monthSalesTotalTaxExc - monthStockTotalTaxExc;
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- DEL 2009/01/08 -------------------------------->>>>>
                //// --- ADD 2008/12/09 -------------------------------->>>>>
                //// 売上対比
                //dr[DCTOK02034EA.ct_Col_TermSalesComp] = salStcCompReportResultWork.SalesMoney;
                //// 累計売上対比
                //dr[DCTOK02034EA.ct_Col_MonthSalesComp] = salStcCompReportResultWork.MonthSalesMoney;
                //// 仕入対比
                //dr[DCTOK02034EA.ct_Col_TermStockComp] = salStcCompReportResultWork.StockPriceTaxExc;
                //// 累計仕入対比
                //dr[DCTOK02034EA.ct_Col_MonthStockComp] = salStcCompReportResultWork.MonthStockPriceTaxExc;
                //// 差額
                //dr[DCTOK02034EA.ct_Col_TermBalance] = salStcCompReportResultWork.SalesMoney - salStcCompReportResultWork.StockPriceTaxExc;
                //// 累計差額
                //dr[DCTOK02034EA.ct_Col_MonthBalance] = salStcCompReportResultWork.MonthSalesMoney - salStcCompReportResultWork.MonthStockPriceTaxExc;
                //// --- ADD 2008/12/09 --------------------------------<<<<<
                // --- DEL 2009/01/08 --------------------------------<<<<<
                // DEL 2009/04/15 ------>>>
                //// --- ADD 2009/01/08 -------------------------------->>>>>
                //// 売上対比 (売上合計 + 移動出庫)
                //dr[DCTOK02034EA.ct_Col_TermSalesComp] = salStcCompReportResultWork.SalesMoney + salStcCompReportResultWork.SalesMoneyStock 
                //    + (salStcCompReportResultWork.MoveCountSales * salStcCompReportResultWork.StockUnitPriceFlSales);
                //// 累計売上対比 (売上合計 + 移動出庫)
                //dr[DCTOK02034EA.ct_Col_MonthSalesComp] = salStcCompReportResultWork.MonthSalesMoney + salStcCompReportResultWork.MonthSalesMoneyStock
                //    + (salStcCompReportResultWork.MonthMoveCountSales * salStcCompReportResultWork.MonthStockUnitPriceFlSales);
                
                //// 仕入対比 (仕入合計 + 移動入庫)
                //dr[DCTOK02034EA.ct_Col_TermStockComp] = salStcCompReportResultWork.StockPriceTaxExc + salStcCompReportResultWork.StockPriceTaxExcStock
                //    + (salStcCompReportResultWork.MoveCountSalesSlip * salStcCompReportResultWork.StockUnitPriceFlSalesSlip);
                //// 累計仕入対比 (仕入合計 + 移動入庫)
                //dr[DCTOK02034EA.ct_Col_MonthStockComp] = salStcCompReportResultWork.MonthStockPriceTaxExc + salStcCompReportResultWork.MonthStockPriceTaxExcStock
                //    + (salStcCompReportResultWork.MonthMoveCountSalesSlip * salStcCompReportResultWork.MonthStockUnitPriceFlSalesSlip);

                //// 差額 (売上対比 - 仕入対比)
                //dr[DCTOK02034EA.ct_Col_TermBalance] = (Int64)dr[DCTOK02034EA.ct_Col_TermSalesComp] - (Int64)dr[DCTOK02034EA.ct_Col_TermStockComp];
                //// 累計差額 (累計売上対比 - 累計仕入対比)
                //dr[DCTOK02034EA.ct_Col_MonthBalance] = (Int64)dr[DCTOK02034EA.ct_Col_MonthSalesComp] - (Int64)dr[DCTOK02034EA.ct_Col_MonthStockComp];
                //// --- ADD 2009/01/08 --------------------------------<<<<<
                // DEL 2009/04/15 ------<<<
                // ADD 2009/04/15 ------>>>
                // 売上対比 (売上合計 + 移動出庫)
                dr[DCTOK02034EA.ct_Col_TermSalesComp] = salStcCompReportResultWork.SalesMoney + salStcCompReportResultWork.SalesMoneyStock
                                                      + salStcCompReportResultWork.StockMovePriceSales;
                // 累計売上対比 (売上合計 + 移動出庫)
                dr[DCTOK02034EA.ct_Col_MonthSalesComp] = salStcCompReportResultWork.MonthSalesMoney + salStcCompReportResultWork.MonthSalesMoneyStock
                                                       + salStcCompReportResultWork.MonthStockMovePriceSales;

                // 仕入対比 (仕入合計 + 移動入庫)
                dr[DCTOK02034EA.ct_Col_TermStockComp] = salStcCompReportResultWork.StockPriceTaxExc + salStcCompReportResultWork.StockPriceTaxExcStock
                                                      + salStcCompReportResultWork.StockMovePriceSlip;
                // 累計仕入対比 (仕入合計 + 移動入庫)
                dr[DCTOK02034EA.ct_Col_MonthStockComp] = salStcCompReportResultWork.MonthStockPriceTaxExc + salStcCompReportResultWork.MonthStockPriceTaxExcStock
                                                       + salStcCompReportResultWork.MonthStockMovePriceSlip;

                // 差額 (売上対比 - 仕入対比)
                dr[DCTOK02034EA.ct_Col_TermBalance] = (Int64)dr[DCTOK02034EA.ct_Col_TermSalesComp] - (Int64)dr[DCTOK02034EA.ct_Col_TermStockComp];
                // 累計差額 (累計売上対比 - 累計仕入対比)
                dr[DCTOK02034EA.ct_Col_MonthBalance] = (Int64)dr[DCTOK02034EA.ct_Col_MonthSalesComp] - (Int64)dr[DCTOK02034EA.ct_Col_MonthStockComp];
                // ADD 2009/04/15 ------<<<
                
                //拠点別の集計
                string sectionHeaderField = "";
                //sectionHeaderField = salStcCompReportResultWork.SectionCode; // DEL 2008/12/09
                sectionHeaderField = salStcCompReportResultWork.SecCode; // ADD 2008/12/09

                //0:拠点別 1:仕入先別
                switch (salStcCompReport.PrintType)
                {
                    //0:拠点別
                    case 0:
                        //dr[DCTOK02034EA.ct_Col_SectionHeaderField] = salStcCompReportResultWork.SectionCode; // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_SectionHeaderField] = salStcCompReportResultWork.SecCode; // ADD 2008/12/09
                        dr[DCTOK02034EA.ct_Col_DailyHeaderField] = "";

                        //dr[DCTOK02034EA.ct_Col_SectionHeaderLine] = salStcCompReportResultWork.SectionCode; // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_SectionHeaderLine] = salStcCompReportResultWork.SecCode; // ADD 2008/12/09
                        //dr[DCTOK02034EA.ct_Col_DetailLine] = salStcCompReportResultWork.SupplierCd.ToString("d9"); // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_DetailLine] = salStcCompReportResultWork.SupplierCd.ToString("d6"); // ADD 2008/12/09
                        //dr[DCTOK02034EA.ct_Col_SectionHeaderLineName] = salStcCompReportResultWork.SectionGuideNm; // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_SectionHeaderLineName] = salStcCompReportResultWork.SectionGuideSnm; // ADD 2008/12/09
                        dr[DCTOK02034EA.ct_Col_DetailLineName] = salStcCompReportResultWork.SupplierSnm;
                        break;
                    //1:仕入先別
                    case 1:
                        //dr[DCTOK02034EA.ct_Col_SectionHeaderField] = salStcCompReportResultWork.SectionCode;
                        //dr[DCTOK02034EA.ct_Col_DailyHeaderField] = salStcCompReportResultWork.SupplierCd;
                        //
                        //dr[DCTOK02034EA.ct_Col_SectionHeaderLine] = salStcCompReportResultWork.SectionCode
                        //									+ " " + salStcCompReportResultWork.SectionGuideNm;
                        //dr[DCTOK02034EA.ct_Col_DetailLine] = salStcCompReportResultWork.SupplierCd.ToString("d9")
                        //							 + " " + salStcCompReportResultWork.SupplierSnm;

                        dr[DCTOK02034EA.ct_Col_SectionHeaderField] = salStcCompReportResultWork.SupplierCd;
                        dr[DCTOK02034EA.ct_Col_DailyHeaderField] = "";

                        //dr[DCTOK02034EA.ct_Col_SectionHeaderLine] = salStcCompReportResultWork.SupplierCd.ToString("d9"); // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_SectionHeaderLine] = salStcCompReportResultWork.SupplierCd.ToString("d6"); // ADD 2008/12/09
                        //dr[DCTOK02034EA.ct_Col_DetailLine] = salStcCompReportResultWork.SectionCode; // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_DetailLine] = salStcCompReportResultWork.SecCode; // ADD 2008/12/09

                        dr[DCTOK02034EA.ct_Col_SectionHeaderLineName] = salStcCompReportResultWork.SupplierSnm;
                        //dr[DCTOK02034EA.ct_Col_DetailLineName] = salStcCompReportResultWork.SectionGuideNm; // DEL 2008/12/09
                        dr[DCTOK02034EA.ct_Col_DetailLineName] = salStcCompReportResultWork.SectionGuideSnm; // ADD 2008/12/09
                        break;
                }

                #endregion

				// TableにAdd
				this._salStcCompReportDt.Rows.Add( dr );
			}

			// DataView作成
			this._salStcCompReportView = new DataView( this._salStcCompReportDt, "", GetSortOrder(salStcCompReport), DataViewRowState.CurrentRows );
		}
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( SalStcCompReport salStcCompReport )
		{
			StringBuilder strSortOrder = new StringBuilder();

            if (salStcCompReport.PrintType == 0) // 拠点別
            {
                strSortOrder.Append(DCTOK02034EA.ct_Col_SectionCode);
                strSortOrder.Append(", ");
                strSortOrder.Append(DCTOK02034EA.ct_Col_SupplierCd);
            }
            else // 仕入先別
            {
                strSortOrder.Append(DCTOK02034EA.ct_Col_SupplierCd);
                strSortOrder.Append(", ");
                strSortOrder.Append(DCTOK02034EA.ct_Col_SectionCode);
            }

#if False
			//集計方法が営業所毎で集計単位が0:拠点別の場合
			strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SectionCode));

			//0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
			switch (salStcCompReport.PrintType)
			{
				//0:拠点別
				case 0:
					break;
				//1:部署別
				case 1:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SubSectionCode));
					break;
				//2:課別
				case 2:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SubSectionCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_MinSectionCode));
					break;
				//3:地区別
				case 3:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SalesAreaCode));
					break;
				//4:業種別
				case 4:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_BusinessTypeCode));
					break;
				//5:担当者別
				case 5:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SalesEmployeeCd));
					break;
				//6:受注者別
				case 6:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_FrontEmployeeNm));
					break;
				//7:発行者別
				case 7:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SalesInputCode));
					break;
				//8:得意先別
				case 8:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_CustomerCode));
					break;
				//9:地区別得意先別
				case 9:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SalesAreaCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_CustomerCode));
					break;
				//10:業種別得意先別意
				case 10:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_BusinessTypeCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_CustomerCode));
					break;
				// 11:担当者別得意先別
				case 11:
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_SalesEmployeeCd));
					strSortOrder.Append(string.Format("{0},", DCTOK02034EA.ct_Col_CustomerCode));
					break;
			}
#endif

			return strSortOrder.ToString();
		}
		#endregion

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

            SalStcCompReportResultWork param1 = new SalStcCompReportResultWork();

            param1.SecCode = "99"; // 拠点
            param1.SectionGuideSnm = "拠点名最大１０桁です";
            param1.SupplierCd = 999999; // 仕入先
            param1.SupplierSnm = "仕入名最大１０桁です";
            // 日計
            param1.SalesMoney = 888888888; // 売上金額(合計)
            param1.SalesMoneyStock = 222222222; // 売上金額(在庫)
            param1.TotalCost = 111111111; // 原価金額計
            param1.MoveCountSales = 111111111; // 移動数
            param1.StockUnitPriceFlSales = 3; // 仕入単価

            param1.StockPriceTaxExc = 333333333; // 仕入金額(合計)
            param1.StockPriceTaxExcStock = 111111111; // 仕入金額(在庫)
            param1.MoveCountSalesSlip = 222222222; // 移動数
            param1.StockUnitPriceFlSalesSlip = 4; // 仕入単価

            // 累計
            param1.MonthSalesMoney = 888888888; // 売上金額(合計)
            param1.MonthSalesMoneyStock = 222222222; // 売上金額(在庫)
            param1.MonthTotalCost = 111111111; // 原価金額計
            param1.MonthMoveCountSales = 111111111; // 移動数
            param1.MonthStockUnitPriceFlSales = 3; // 仕入単価

            param1.MonthStockPriceTaxExc = 333333333; // 仕入金額(合計)
            param1.MonthStockPriceTaxExcStock = 111111111; // 仕入金額(在庫)
            param1.MonthMoveCountSalesSlip = 222222222; // 移動数
            param1.MonthStockUnitPriceFlSalesSlip = 4; // 仕入単価

            paramlist.Add(param1);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
